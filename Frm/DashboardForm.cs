using CuentasIbercaja.Comun;
using CuentasIbercaja.Models;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace CuentasIbercaja.Frm
{
    public partial class DashboardForm : Form
    {
        private readonly IEnumerable<Expense> expenses;

        public DashboardForm(BindingList<Expense> datos)
        {
            expenses = datos;
            InitializeComponent(); // Asegúrate de que esto se llame antes de cualquier acceso a tablaDatos
            ConfigurarTablaDatos();
            ConfigurarTipoCuenta();
        }

        private void ConfigurarTipoCuenta()
        {
            cbTipoCuenta.Items.AddRange(Enum.GetNames<TipoCuenta>());
        }

        public static (IEnumerable<ResumenConcepto> ingresos, IEnumerable<ResumenConcepto> pagos) ObtenerTablasAgrupadas(IEnumerable<Expense> datos)
        {
            // Tabla de ingresos agrupados por concepto
            var ingresos = datos
                .Where(e => e.EsIngreso)
                .GroupBy(e => e.Concepto)
                .Select(g => new ResumenConcepto
                {
                    Concepto = g.Key,
                    Total = g.Sum(x => x.Importe)
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            // Tabla de pagos agrupados por concepto
            var pagos = datos
                .Where(e => !e.EsIngreso) // incluye false y null
                .GroupBy(e => e.Concepto)
                .Select(g => new ResumenConcepto
                {
                    Concepto = g.Key,
                    Total = g.Sum(x => x.Importe)
                })
                .OrderBy(x => x.Total) // más negativos primero
                .ToList();

            return (ingresos, pagos);
        }

        private void ConfigurarTablaDatos()
        {
            tablaDatos.Columns.Clear();
            tablaDatos.Dock = DockStyle.Fill;
            tablaDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tablaDatos.AllowUserToAddRows = false;
            tablaDatos.AllowUserToDeleteRows = false;
            tablaDatos.ReadOnly = true;

            tablaDatos.Columns.Add(ConstantesFinanzas.ColumnaConcepto, "Concepto");
            tablaDatos.Columns.Add(ConstantesFinanzas.ColumnaImporte, "Importe");
            tablaDatos.Columns.Add(ConstantesFinanzas.ColumnaFecha, "Fecha");
        }

        private IEnumerable<Expense> FiltrarDatos(string tipoCuenta, DateTime inicio, DateTime fin)
        {
            return expenses
                .Where(e =>
                    (string.IsNullOrEmpty(tipoCuenta) || e.TipoCuenta.ToString() == tipoCuenta) &&
                    e.Fecha >= inicio &&
                    e.Fecha <= fin);
        }

        private void ActualizarTabla(IEnumerable<Expense> datosFiltrados)
        {
            // Actualizar la tabla con los datos filtrados
            tablaDatos.Rows.Clear();
            foreach (var expense in datosFiltrados)
            {
                tablaDatos.Rows.Add(expense.Concepto, expense.Importe.ToString("N2"), expense.Fecha.ToShortDateString());
            }
        }

        private void ActualizarMetricas(IEnumerable<Expense> datosFiltrados)
        {
            // Calcular y mostrar las métricas clave
            var totalIngresos = datosFiltrados.Where(e => e.EsIngreso).Sum(e => e.Importe);
            var totalGastos = datosFiltrados.Where(e => !e.EsIngreso).Sum(e => e.Importe);
            var balanceTotal = totalIngresos + totalGastos;
            float gastoPromedio = datosFiltrados.Where(e => !e.EsIngreso).GroupBy(static e => new { e.Fecha.Year, e.Fecha.Month }).Average(g =>
            {
                static float importeSelector(Expense x)
                {
                    ArgumentNullException.ThrowIfNull(x);
                    return x.Importe;
                }
                return g.Sum(importeSelector);
            });

            float ingresoPromedio = datosFiltrados.Where(e => e.EsIngreso).GroupBy(static e => new { e.Fecha.Year, e.Fecha.Month }).Average(g =>
            {
                static float importeSelector(Expense x)
                {
                    ArgumentNullException.ThrowIfNull(x);
                    return x.Importe;
                }
                return g.Sum(importeSelector);
            });

            var balancePromedio = ingresoPromedio + gastoPromedio;

            lblGastoPromedio.Text = $"Gasto Promedio: €{Math.Abs(gastoPromedio):N2}";
            lblIngresoPromedio.Text = $"Ingreso Promedio: €{ingresoPromedio:N2}";
            lblBalancePromedio.Text = $"Balance Promedio: €{balancePromedio:N2}";
            lblIngresos.Text = $"Ingresos: €{totalIngresos:N2}";
            lblGastos.Text = $"Gastos: €{Math.Abs(totalGastos):N2}";
            lblBalanceTotal.Text = $"Balance Total: €{balanceTotal:N2}";
        }

        private void BtnAplicarFiltros_Click(object sender, EventArgs e)
        {
            var datosFiltrados = FiltrarDatos(cbTipoCuenta.SelectedItem?.ToString() ?? string.Empty, dtpInicio.Value, dtpFin.Value);
            if (!datosFiltrados.Any())
            {
                return;
            }

            var (tablaIngresos, tablaPagos) = ObtenerTablasAgrupadas(datosFiltrados);
            ActualizarTabla(datosFiltrados);
            ActualizarMetricas(datosFiltrados);
            MostrarResumenIngresosGastos(tablaIngresos, tablaPagos);
            CrearGraficosResumen(tablaIngresos, tablaPagos);
        }

        private static Chart CrearGraficoTartaIngresos(IEnumerable<ResumenConcepto> ingresos)
        {
            Chart chart = new() { Dock = DockStyle.Top, Height = 350 };

            ChartArea area = new("AreaIngresos");
            chart.ChartAreas.Add(area);

            Series serie = new("Ingresos")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "N2"
            };

            foreach (var item in ingresos)
                serie.Points.AddXY(item.Concepto, item.Total);

            chart.Series.Add(serie);

            Legend legend = new()
            {
                Name = "LeyendaIngresos",
                Title = "Ingresos por Concepto",
                Docking = Docking.Right
            };

            chart.Legends.Add(legend);

            return chart;
        }

        private static Chart CrearGraficoTartaPagos(IEnumerable<ResumenConcepto> pagos)
        {
            Chart chart = new() { Dock = DockStyle.Top, Height = 350 };

            ChartArea area = new("AreaPagos");
            chart.ChartAreas.Add(area);

            Series serie = new("Pagos")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "N2"
            };

            foreach (var item in pagos)
                serie.Points.AddXY(item.Concepto, Math.Abs(item.Total)); // valores positivos en tarta

            chart.Series.Add(serie);

            Legend legend = new()
            {
                Name = "LeyendaPagos",
                Title = "Pagos por Concepto",
                Docking = Docking.Right
            };

            chart.Legends.Add(legend);

            return chart;
        }

        private static void ConfigurarDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // Columna Concepto
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Concepto",
                HeaderText = ConstantesFinanzas.ColumnaConcepto,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Columna Total formateada como moneda
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total (€)",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",          // 2 decimales
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                Width = 120
            });
        }

        private void MostrarResumenIngresosGastos(IEnumerable<ResumenConcepto> ingresos, IEnumerable<ResumenConcepto> pagos)
        {
            ConfigurarDataGridView(dataGridViewIngresos);
            ConfigurarDataGridView(dataGridViewPagos);

            dataGridViewIngresos.DataSource = ingresos.ToList();
            dataGridViewPagos.DataSource = pagos.ToList();
        }

        private void CrearGraficosResumen(IEnumerable<ResumenConcepto> ingresos, IEnumerable<ResumenConcepto> pagos)
        {
            var graficoIngresos = CrearGraficoTartaIngresos(ingresos);
            var graficoPagos = CrearGraficoTartaPagos(pagos);

            splitContainer2.Panel1.Controls.Add(graficoIngresos);
            splitContainer2.Panel2.Controls.Add(graficoPagos);
        }
    }
}