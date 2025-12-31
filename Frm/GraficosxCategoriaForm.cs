using CuentasIbercaja.Frm;
using CuentasIbercaja.Models;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestorGastos.Frm
{
    public partial class GraficosxCategoriaForm : Form
    {
        private readonly IEnumerable<Expense> expenses;

        private readonly TipoGrafico _tipo;

        public GraficosxCategoriaForm(BindingList<Expense> datos, TipoGrafico tipo)
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
               .GroupBy(e => e.Concepto)
               .Select(g => new
               {
                   Concepto = g.Key,
                   Total = g.Sum(x => x.Importe)
               })
               .OrderBy(x => x.Concepto)
               .ToDictionary(x => x.Concepto, x => x.Total);

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
               .GroupBy(e => e.Concepto)
               .Select(g => new
               {
                   Concepto = g.Key,
                   Total = g.Sum(x => x.Importe)
               })
               .OrderBy(x => x.Concepto)
               .ToDictionary(x => x.Concepto, x => x.Total);

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