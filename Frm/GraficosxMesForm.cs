using CuentasIbercaja.Frm;
using CuentasIbercaja.Models;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestorGastos.Frm
{
    public partial class GraficosxMesForm : Form
    {
        private readonly IEnumerable<Expense> expenses;
        private readonly TipoGrafico _tipo;

        public GraficosxMesForm(BindingList<Expense> datos, TipoGrafico tipo)
        {
            InitializeComponent();
            expenses = datos;
            _tipo = tipo;

            ConfigurarTabControl();
        }

        private void ConfigurarTabControl()
        {
            tabControl1.TabPages.Clear();

            // Crear una pestaña para cada TipoCuenta
            foreach (TipoCuenta tipoCuenta in Enum.GetValues<TipoCuenta>())
            {
                if (tipoCuenta == TipoCuenta.None) continue;

                TabPage tabPage = new($"{tipoCuenta}")
                {
                    Tag = tipoCuenta // Guardar el TipoCuenta en la propiedad Tag
                };

                tabControl1.TabPages.Add(tabPage);
            }

            // Manejar el evento de cambio de pestaña
            tabControl1.SelectedIndexChanged += (s, e) =>
            {
                if (tabControl1.SelectedTab?.Tag is TipoCuenta tipoCuentaSeleccionado)
                {
                    MostrarGraficosPorTipoCuenta(tipoCuentaSeleccionado, tabControl1.SelectedTab);
                }
            };

            // Mostrar los gráficos de la primera pestaña al inicio
            if (tabControl1.TabPages.Count > 0 && tabControl1.TabPages[0].Tag is TipoCuenta tipoCuentaInicial)
            {
                MostrarGraficosPorTipoCuenta(tipoCuentaInicial, tabControl1.TabPages[0]);
            }

            // Agregar el TabControl al formulario
            Controls.Add(tabControl1);
        }

        private void MostrarGraficosPorTipoCuenta(TipoCuenta tipoCuenta, TabPage tabPage)
        {
            // Limpiar los controles existentes en la pestaña
            tabPage.Controls.Clear();

            // Filtrar los datos por TipoCuenta
            var datosFiltrados = expenses.Where(e => e.TipoCuenta == tipoCuenta).ToList();

            // Crear un SplitContainer para los gráficos de ingresos y gastos
            SplitContainer splitContainer = new()
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal
            };

            // Crear gráficos para ingresos y gastos
            CrearGraficoComparativo(splitContainer.Panel1, datosFiltrados, true);  // Ingresos
            CrearGraficoComparativo(splitContainer.Panel2, datosFiltrados, false); // Gastos

            // Agregar el SplitContainer a la pestaña
            tabPage.Controls.Add(splitContainer);
        }

        private void CrearGraficoComparativo(Control panel, IEnumerable<Expense> datos, bool esIngreso)
        {
            var valores = datos
                .Where(e => e.EsIngreso == esIngreso)
                .GroupBy(e => new { e.Fecha.Year, e.Fecha.Month })
                .Select(g => new
                {
                    Año = g.Key.Year,
                    Mes = g.Key.Month,
                    Total = g.Sum(x => x.Importe)
                })
                .OrderBy(x => x.Mes)
                .ThenBy(x => x.Año)
                .ToList();

            // Crear un diccionario para agrupar los datos por mes y luego por año
            var datosPorMes = valores
                .GroupBy(v => v.Mes)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToDictionary(v => v.Año, v => v.Total)
                );

            Chart chartComparativo = new() { Dock = DockStyle.Fill };
            chartComparativo.ChartAreas.Add(new ChartArea("ComparativoArea"));

            // Configurar las series para cada año
            foreach (var año in valores.Select(v => v.Año).Distinct().OrderBy(a => a))
            {
                Series serie = new($"Año {año}")
                {
                    ChartType = GraficosxConceptoFormHelpers.MapearTipoGrafico(_tipo),
                    BorderWidth = 2
                };

                foreach (var mes in Enumerable.Range(1, 12))
                {
                    var total = datosPorMes.TryGetValue(mes, out Dictionary<int, float>? value) && value.ContainsKey(año)
                        ? value[año]
                        : 0;

                    serie.Points.AddXY(mes, total);
                }

                chartComparativo.Series.Add(serie);
            }

            // Configurar la leyenda
            Legend legend = new()
            {
                Name = "ComparativoLegend",
                Title = "Años",
                Docking = Docking.Top
            };
            chartComparativo.Legends.Add(legend);

            // Configurar el título del gráfico
            string titulo = esIngreso ? "Comparativa de Ingresos por Mes y Año" : "Comparativa de Gastos por Mes y Año";
            chartComparativo.Titles.Add(new Title(titulo, Docking.Top, new Font("Arial", 12, FontStyle.Bold), Color.Black));

            // Agregar el gráfico al panel
            panel.Controls.Add(chartComparativo);
        }
    }
}