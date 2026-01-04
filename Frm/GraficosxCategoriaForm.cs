using CuentasIbercaja.Frm;
using CuentasIbercaja.Models;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace GestorGastos.Frm
{
    public partial class GraficosxCategoriaForm : Form
    {
        private readonly IEnumerable<Expense> expenses;
        private readonly TipoGrafico _tipo;

        public GraficosxCategoriaForm(BindingList<Expense> datos, TipoGrafico tipo)
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
                .GroupBy(e => e.Concepto) // Agrupar por concepto
                .Select(g => new
                {
                    Concepto = g.Key,
                    Total = g.Sum(x => x.Importe)
                })
                .OrderBy(x => x.Concepto)
                .ToList();

            Chart chartComparativo = new() { Dock = DockStyle.Fill };
            chartComparativo.ChartAreas.Add(new ChartArea("ComparativoArea"));

            // Crear una serie para los conceptos
            Series serie = new("Conceptos")
            {
                ChartType = MapearTipoGrafico(_tipo),
                BorderWidth = 2
            };

            foreach (var valor in valores)
            {
                serie.Points.AddXY(valor.Concepto, valor.Total);
            }

            chartComparativo.Series.Add(serie);

            // Configurar la leyenda
            Legend legend = new()
            {
                Name = "ComparativoLegend",
                Title = "Conceptos",
                Docking = Docking.Top
            };
            chartComparativo.Legends.Add(legend);

            // Configurar el título del gráfico
            string titulo = esIngreso ? "Comparativa de Ingresos por Concepto" : "Comparativa de Gastos por Concepto";
            chartComparativo.Titles.Add(new Title(titulo, Docking.Top, new Font("Arial", 12, FontStyle.Bold), Color.Black));

            // Agregar el gráfico al panel
            panel.Controls.Add(chartComparativo);
        }

        private static SeriesChartType MapearTipoGrafico(TipoGrafico tipo)
        {
            return tipo switch
            {
                TipoGrafico.Linea => SeriesChartType.Line,
                TipoGrafico.Barra => SeriesChartType.Column,
                TipoGrafico.Columna => SeriesChartType.Column,
                TipoGrafico.Circular => SeriesChartType.Pie,
                TipoGrafico.Area => SeriesChartType.Area,
                TipoGrafico.Punto => SeriesChartType.Point,
                TipoGrafico.Radar => SeriesChartType.Radar,
                TipoGrafico.Burbuja => SeriesChartType.Bubble,                
                _ => SeriesChartType.Column // Valor predeterminado
            };
        }
    }
}