using CuentasIbercaja.Models;
using System.ComponentModel;
using System.Data;

namespace CuentasIbercaja.Frm
{
    public partial class ResumenConceptosForm : Form
    {
        private readonly IEnumerable<Expense> expenses;

        public ResumenConceptosForm(BindingList<Expense> datos)
        {
            InitializeComponent();
            expenses = datos;

            ConfigurarTabControl();
        }

        private void ConfigurarTabControl()
        {
            tabControl1.TabPages.Clear();

            // Crear una pestaña para cada TipoCuenta
            foreach (TipoCuenta tipoCuenta in Enum.GetValues<TipoCuenta>())
            {
                if (tipoCuenta == TipoCuenta.None) continue;

                // Simplificar la creación de TabPage usando inicializador de objeto
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
                    MostrarDatosPorTipoCuenta(tipoCuentaSeleccionado, tabControl1.SelectedTab);
                }
            };

            // Mostrar los gráficos de la primera pestaña al inicio
            if (tabControl1.TabPages.Count > 0 && tabControl1.TabPages[0].Tag is TipoCuenta tipoCuentaInicial)
            {
                MostrarDatosPorTipoCuenta(tipoCuentaInicial, tabControl1.TabPages[0]);
            }

            // Agregar el TabControl al formulario
            Controls.Add(tabControl1);
        }

        private void MostrarDatosPorTipoCuenta(TipoCuenta tipoCuentaSeleccionado, TabPage selectedTab)
        {
            // Limpiar los controles existentes en la pestaña
            selectedTab.Controls.Clear();

            // Filtrar los datos por TipoCuenta
            var datosFiltrados = expenses.Where(e => e.TipoCuenta == tipoCuentaSeleccionado).ToList();

            // Crear tablas para ingresos y gastos
            var tablaIngresos = CrearTabla([.. datosFiltrados.Where(e => e.EsIngreso)], "Ingresos");
            var tablaGastos = CrearTabla([.. datosFiltrados.Where(e => !e.EsIngreso)], "Gastos");

            // Crear un SplitContainer para mostrar ambas tablas
            SplitContainer splitContainer = new()
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical
            };

            splitContainer.Panel1.Controls.Add(tablaIngresos);
            splitContainer.Panel2.Controls.Add(tablaGastos);

            // Agregar el SplitContainer a la pestaña
            selectedTab.Controls.Add(splitContainer);
        }

        private static DataGridView CrearTabla(List<Expense> datos, string titulo)
        {
            // Agrupar los datos por concepto y año
            var agrupados = datos
                .GroupBy(e => new { e.Concepto, e.Fecha.Year })
                .Select(g => new
                {
                    g.Key.Concepto,
                    Año = g.Key.Year,
                    Total = g.Sum(x => x.Importe)
                })
                .ToList();

            // Obtener los conceptos y años únicos
            var conceptos = agrupados.Select(a => a.Concepto).Distinct().OrderBy(c => c).ToList();
            var años = agrupados.Select(a => a.Año).Distinct().OrderBy(a => a).ToList();

            // Crear el DataGridView
            DataGridView dgv = new()
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinear a la derecha
                    Format = "N2" // Formatear a 2 decimales
                }
            };

            // Configurar las columnas
            dgv.Columns.Add("Concepto", "Concepto");
            foreach (var año in años)
            {
                dgv.Columns.Add($"Año_{año}", año.ToString());
            }

            // Agregar las filas
            foreach (var concepto in conceptos)
            {
                var fila = new object[años.Count + 1];
                fila[0] = concepto; // Primera columna: Concepto

                for (int i = 0; i < años.Count; i++)
                {
                    var total = agrupados
                        .Where(a => a.Concepto == concepto && a.Año == años[i])
                        .Sum(a => a.Total);

                    fila[i + 1] = total; // Columnas siguientes: Totales por año
                }

                dgv.Rows.Add(fila);
            }

            // Calcular los totales por columna
            var filaTotales = new object[años.Count + 1];
            filaTotales[0] = "Totales"; // Primera columna: Etiqueta "Totales"

            for (int i = 0; i < años.Count; i++)
            {
                var totalColumna = agrupados
                    .Where(a => a.Año == años[i])
                    .Sum(a => a.Total);

                filaTotales[i + 1] = totalColumna; // Columnas siguientes: Totales por año
            }

            // Agregar la fila de totales al DataGridView
            dgv.Rows.Add(filaTotales);

            // Agregar un título a la tabla
            Label labelTitulo = new()
            {
                Text = titulo,
                Dock = DockStyle.Top,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Crear un panel para contener la tabla y el título
            Panel panel = new() { Dock = DockStyle.Fill };
            panel.Controls.Add(dgv);
            panel.Controls.Add(labelTitulo);

            return dgv;
        }
    }
}