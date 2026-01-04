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
            expenses = [.. datos];
            _tipo = tipo;
            CrearGraficoComparativo(true);  // Para ingresos
            CrearGraficoComparativo(false); // Para gastos
        }

        private void CrearGraficoComparativo(bool esIngreso)
        {
            var valores = expenses
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
                    ChartType = MapearTipoGrafico(_tipo), // Aplicar TipoGrafico
                    BorderWidth = 2
                };

                foreach (var mes in Enumerable.Range(1, 12))
                {
                    var total = datosPorMes.ContainsKey(mes) && datosPorMes[mes].ContainsKey(año)
                        ? datosPorMes[mes][año]
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

            // Añadir el gráfico al panel correspondiente
            if (esIngreso)
            {
                splitContainer1.Panel1.Controls.Add(chartComparativo);
            }
            else
            {
                splitContainer1.Panel2.Controls.Add(chartComparativo);
            }
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