using CuentasIbercaja.Frm;
using CuentasIbercaja.Models;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestorGastos.Frm
{
    public partial class GraficosxConceptoForm : Form
    {
        private readonly IEnumerable<Expense> expenses;
        private readonly TipoGrafico _tipo;

        public GraficosxConceptoForm(IEnumerable<Expense> datos, TipoGrafico tipo)
        {
            InitializeComponent();
            expenses = datos;
            _tipo = tipo;

            ConfigurarTabControl();
        }

        private void ConfigurarTabControl()
        {
            tabControl1.TabPages.Clear();

            var tipos = expenses.Select(e => e.TipoCuenta).Distinct().ToList();

            // Crear una pestaña para cada TipoCuenta
            foreach (TipoCuenta tipoCuenta in tipos)
            {
                if (tipoCuenta == TipoCuenta.None) 
                   continue;

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
                .GroupBy(e => new { e.Concepto, e.Fecha.Year }) // Agrupar por concepto y año
                .Select(g => new
                {
                    Concepto = g.Key.Concepto ?? "Sin Concepto", // Manejar conceptos nulos
                    Año = g.Key.Year,
                    Total = g.Sum(x => x.Importe)
                })
                .ToList();

            // Obtener todos los conceptos únicos
            var conceptos = valores.Select(v => v.Concepto).Distinct().OrderBy(c => c).ToList();

            Chart chartComparativo = new() { Dock = DockStyle.Fill };
            ChartArea chartArea = new("ComparativoArea");

            // Configurar el formato del eje Y para mostrar 2 decimales
            chartArea.AxisY.LabelStyle.Format = "N2";
            chartArea.AxisY.Title = "Importe (en €)";
            chartArea.AxisX.Title = "Conceptos";
            chartArea.AxisX.Interval = 1; // Asegurar que se muestren todas las etiquetas en el eje X

            chartComparativo.ChartAreas.Add(chartArea);

            // Crear una serie para cada año
            foreach (var año in valores.Select(v => v.Año).Distinct())
            {
                Series serie = new($"Año: {año}")
                {
                    ChartType = GraficosxConceptoFormHelpers.MapearTipoGrafico(_tipo),
                    BorderWidth = 2
                };

                // Agregar un punto para cada concepto, incluso si el valor es 0
                foreach (var concepto in conceptos)
                {
                    var total = valores
                        .Where(v => v.Año == año && v.Concepto == concepto)
                        .Sum(v => v.Total);

                    serie.Points.AddXY(concepto, total);
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
            string titulo = esIngreso ? "Comparativa de Ingresos por Concepto y Año" : "Comparativa de Gastos por Concepto y Año";
            chartComparativo.Titles.Add(new Title(titulo, Docking.Top, new Font("Arial", 12, FontStyle.Bold), Color.Black));

            // Agregar el gráfico al panel
            panel.Controls.Add(chartComparativo);
        }
    }
}