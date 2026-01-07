using CuentasIbercaja.Models;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace CuentasIbercaja.Frm
{
    public partial class DashboardForm : Form
    {
        private readonly IEnumerable<Expense> expenses;
        private IEnumerable<Expense> datosFiltrados;

        public DashboardForm(BindingList<Expense> datos)
        {
            expenses = datos;
            datosFiltrados = datos;
            InitializeComponent(); // Asegúrate de que esto se llame antes de cualquier acceso a tablaDatos
            ConfigurarTablaDatos();
            ConfigurarTipoCuenta();
        }

        private void ConfigurarTipoCuenta()
        {
            cbTipoCuenta.Items.AddRange(Enum.GetNames<TipoCuenta>());
        }

        private void ActualizarGraficos()
        {
            // Verificar si el panel de gráficos está inicializado
            if (panelGraficos == null)
            {
                MessageBox.Show("El panel de gráficos no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (panelGraficos == null)
            {
                MessageBox.Show("El panel de gráficos no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear nuevos gráficos con los datos filtrados
            Chart nuevoChartIngresosGastos = CrearGraficoIngresosGastos(datosFiltrados);
            Chart nuevoChartTendencias = CrearGraficoTendencias(datosFiltrados);

            // Limpiar gráficos anteriores
            panelGraficos.Controls.Clear();

            // Agregar los nuevos gráficos al panel
            nuevoChartIngresosGastos.Dock = DockStyle.Top;
            nuevoChartTendencias.Dock = DockStyle.Top;

            panelGraficos.Controls.Add(nuevoChartTendencias); // Tendencias primero para que quede abajo
            panelGraficos.Controls.Add(nuevoChartIngresosGastos); // Ingresos y gastos arriba
        }

        private static Chart CrearGraficoIngresosGastos(IEnumerable<Expense> datos)
        {
            Chart chart = new() { Dock = DockStyle.Top, Height = 200 };
            ChartArea chartArea = new("IngresosGastosArea");
            chart.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = "Conceptos";
            chartArea.AxisY.Title = "Importe (en €)";
            chartArea.AxisY.LabelStyle.Format = "N2";

            Series ingresos = new("Ingresos")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green
            };

            Series gastos = new("Gastos")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Red
            };

            var ingresosData = datos.Where(e => e.EsIngreso)
                .GroupBy(e => e.Concepto)
                .Select(g => new { Concepto = g.Key, Total = g.Sum(x => x.Importe) });

            var gastosData = datos.Where(e => !e.EsIngreso)
                .GroupBy(e => e.Concepto)
                .Select(g => new { Concepto = g.Key, Total = g.Sum(x => x.Importe) });

            foreach (var ingreso in ingresosData)
            {
                ingresos.Points.AddXY(ingreso.Concepto, ingreso.Total);
            }

            foreach (var gasto in gastosData)
            {
                gastos.Points.AddXY(gasto.Concepto, gasto.Total);
            }

            chart.Series.Add(ingresos);
            chart.Series.Add(gastos);

            // Configurar la leyenda
            Legend legend = new()
            {
                Name = "IngresosGastosLegend",
                Title = "Leyenda",
                Docking = Docking.Bottom
            };
            chart.Legends.Add(legend);

            // Añadir descripciones a la leyenda
            ingresos.LegendText = "Ingresos por Concepto";
            gastos.LegendText = "Gastos por Concepto";

            return chart;
        }

        private static Chart CrearGraficoTendencias(IEnumerable<Expense> datos)
        {
            Chart chart = new() { Dock = DockStyle.Top, Height = 200 };
            ChartArea chartArea = new("TendenciasArea");
            chart.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = "Mes";
            chartArea.AxisY.Title = "Importe (en €)";
            chartArea.AxisY.LabelStyle.Format = "N2";

            Series ingresos = new("Ingresos")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Green
            };

            Series gastos = new("Gastos")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red
            };

            var ingresosData = datos.Where(e => e.EsIngreso)
                .GroupBy(e => new { e.Fecha.Year, e.Fecha.Month })
                .Select(g => new { Periodo = $"{g.Key.Year}-{g.Key.Month:D2}", Total = g.Sum(x => x.Importe) });

            var gastosData = datos.Where(e => !e.EsIngreso)
                .GroupBy(e => new { e.Fecha.Year, e.Fecha.Month })
                .Select(g => new { Periodo = $"{g.Key.Year}-{g.Key.Month:D2}", Total = g.Sum(x => x.Importe) });

            foreach (var ingreso in ingresosData)
            {
                ingresos.Points.AddXY(ingreso.Periodo, ingreso.Total);
            }

            foreach (var gasto in gastosData)
            {
                gastos.Points.AddXY(gasto.Periodo, gasto.Total);
            }

            chart.Series.Add(ingresos);
            chart.Series.Add(gastos);

            // Configurar la leyenda
            Legend legend = new()
            {
                Name = "TendenciasLegend",
                Title = "Leyenda",
                Docking = Docking.Bottom
            };
            chart.Legends.Add(legend);

            // Añadir descripciones a la leyenda
            ingresos.LegendText = "Ingresos por Mes";
            gastos.LegendText = "Gastos por Mes";

            return chart;
        }

        private void ConfigurarTablaDatos()
        {
            tablaDatos.Columns.Clear();
            tablaDatos.Dock = DockStyle.Fill;
            tablaDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tablaDatos.AllowUserToAddRows = false;
            tablaDatos.AllowUserToDeleteRows = false;
            tablaDatos.ReadOnly = true;

            tablaDatos.Columns.Add("Concepto", "Concepto");
            tablaDatos.Columns.Add("Importe", "Importe");
            tablaDatos.Columns.Add("Fecha", "Fecha");
        }

        private void FiltrarDatos(string tipoCuenta, DateTime inicio, DateTime fin)
        {
            datosFiltrados = [.. expenses.Where(e =>
                (string.IsNullOrEmpty(tipoCuenta) || e.TipoCuenta.ToString() == tipoCuenta) &&
                e.Fecha >= inicio && e.Fecha <= fin)];
        }

        private void ActualizarTabla()
        {
            // Actualizar la tabla con los datos filtrados
            tablaDatos.Rows.Clear();
            foreach (var expense in datosFiltrados)
            {
                tablaDatos.Rows.Add(expense.Concepto, expense.Importe.ToString("N2"), expense.Fecha.ToShortDateString());
            }
        }

        private void ActualizarMetricas()
        {
            // Calcular y mostrar las métricas clave
            var totalIngresos = datosFiltrados.Where(e => e.EsIngreso).Sum(e => e.Importe);
            var totalGastos = datosFiltrados.Where(e => !e.EsIngreso).Sum(e => e.Importe);
            var balanceTotal = totalIngresos - totalGastos;
            float gastoPromedio = datosFiltrados.Where(e => !e.EsIngreso).GroupBy(static e => new { e.Fecha.Year, e.Fecha.Month }).Average(g =>
            {
                static float importeSelector(Expense x)
                {
                    ArgumentNullException.ThrowIfNull(x);
                    return x.Importe;
                }
                return g.Sum(importeSelector);
            });
            var mayorGasto = datosFiltrados.Where(e => !e.EsIngreso).Max(e => e.Importe);

            lblBalanceTotal.Text = $"Balance Total: €{balanceTotal:N2}";
            lblGastoPromedio.Text = $"Gasto Promedio: €{gastoPromedio:N2}";
            lblMayorGasto.Text = $"Mayor Gasto: €{mayorGasto:N2}";
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Lógica adicional aquí
        }

        private void BtnAplicarFiltros_Click(object sender, EventArgs e)
        {
            FiltrarDatos(cbTipoCuenta.SelectedItem?.ToString() ?? string.Empty, dtpInicio.Value, dtpFin.Value);
            ActualizarGraficos();
            ActualizarTabla();
            ActualizarMetricas();
        }
    }
}