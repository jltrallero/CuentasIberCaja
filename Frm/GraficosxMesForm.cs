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
            CrearGraficoIngresos();
            CrearGraficoGastos();
        }

        private void CrearGraficoIngresos()
        {
            var valores = expenses
                .Where(e => e.EsIngreso)
                .GroupBy(e => new { e.Fecha.Year, e.Fecha.Month })
                .Select(g => new
                {
                    Periodo = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Total = g.Sum(x => x.Importe)
                })
                .OrderBy(x => x.Periodo)
                .ToDictionary(x => x.Periodo, x => x.Total);

            Chart chartIngresos = new() { Dock = DockStyle.Fill };
            chartIngresos.ChartAreas.Add(new ChartArea("GastosArea"));
            GraficosHelpers.ConfigurarChart(chartIngresos,
                             _tipo,
                            "Ingresos por Mes",
                            valores);

            splitContainer1.Panel1.Controls.Add(chartIngresos);
        }

        private void CrearGraficoGastos()
        {
            var valores = expenses
                .Where(e => !e.EsIngreso)
                .GroupBy(e => new { e.Fecha.Year, e.Fecha.Month })
                .Select(g => new
                {
                    Periodo = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Total = g.Sum(x => x.Importe)
                })
                .OrderBy(x => x.Periodo)
                .ToDictionary(x => x.Periodo, x => x.Total);

            Chart chartGastos = new() { Dock = DockStyle.Fill };
            chartGastos.ChartAreas.Add(new ChartArea("GastosArea"));
            GraficosHelpers.ConfigurarChart(chartGastos,
                            _tipo,
                            "Gastos por Mes",
                            valores);

            splitContainer1.Panel2.Controls.Add(chartGastos);
        }
    }
}