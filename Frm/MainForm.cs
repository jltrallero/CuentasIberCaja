using CuentasIbercaja.Data;
using CuentasIbercaja.Frm;
using CuentasIbercaja.Models;
using CuentasIbercaja.Utils;
using GestorGastos.Frm;
using System.ComponentModel;
using System.Data;

namespace GestorGastos
{
    public partial class MainForm : Form
    {
        // Inicialización explícita de los campos para evitar CS8618
        private readonly ExpenseRepository _repo = new();

        private BindingList<Expense> _binding = [];

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            ConfigurarTiposGraficos();

            // Registrar handlers adicionales tras InitializeComponent (dgv viene del diseñador)
            Shown += (s, e) =>
            {
                if (dgv != null)
                {
                    dgv.KeyDown -= Dgv_KeyDown;
                    dgv.KeyDown += Dgv_KeyDown;

                    // Context menu para eliminar filas
                    var cms = new ContextMenuStrip();
                    cms.Items.Add("Eliminar", null, async (sender, args) => await DeleteSelectedAsync());
                    dgv.ContextMenuStrip = cms;

                    // Asegurar selección de fila al hacer clic derecho
                    dgv.CellMouseDown -= Dgv_CellMouseDown;
                    dgv.CellMouseDown += Dgv_CellMouseDown;
                }
            };
        }

        private void ConfigurarTiposGraficos()
        {
            gxMesMenuLinea.Tag = TipoGrafico.Linea;
            gxMesMenuBarrasH.Tag = TipoGrafico.Barra;
            gxMesMenuBarrasV.Tag = TipoGrafico.Columna;
            gxMesMenuCircular.Tag = TipoGrafico.Circular;
            gxMesMenuAreas.Tag = TipoGrafico.Area;
            gxMesMenuDispersion.Tag = TipoGrafico.Punto;
            gxMesMenuRadar.Tag = TipoGrafico.Radar;
            gxMesMenuBurbujas.Tag = TipoGrafico.Burbuja;

            gxCategoriaMenuLinea.Tag = TipoGrafico.Linea;
            gxCategoriaBarrasH.Tag = TipoGrafico.Barra;
            gxCategoriaBarrasV.Tag = TipoGrafico.Columna;
            gxCategoriaCircular.Tag = TipoGrafico.Circular;
            gxCategoriaAreas.Tag = TipoGrafico.Area;
            gxCategoriaDispersion.Tag = TipoGrafico.Punto;
            gxCategoriaRadar.Tag = TipoGrafico.Radar;
            gxCategoriaBurbujas.Tag = TipoGrafico.Burbuja;
        }

        private void Dgv_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && dgv.Rows.Count > e.RowIndex)
            {
                dgv.ClearSelection();
                dgv.Rows[e.RowIndex].Selected = true;
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[Math.Max(0, e.ColumnIndex)];
            }
        }

        private async Task DeleteSelectedAsync()
        {
            if (dgv == null) return;
            var selectedRows = dgv.SelectedRows.Cast<DataGridViewRow>().ToList();

            var count = selectedRows.Count;
            if (count == 0) return;

            var dialogResult = MessageBox.Show(this,
                $"¿Deseas eliminar {count} registro(s)? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult != DialogResult.Yes) return;

            // Recorremos una copia para evitar modificar la colección mientras iteramos
            foreach (var row in selectedRows)
            {
                if (row.DataBoundItem is not Expense exp) continue;

                try
                {
                    if (exp.Id != 0)
                    {
                        await _repo.DeleteAsync(exp.Id);
                    }
                    _binding.Remove(exp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void Dgv_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                await DeleteSelectedAsync();
            }
        }

        private async Task LimpiarDatos()
        {
            await _repo.DeleteAllAsync();
            _binding.Clear();
        }

        private async Task LimpiarDatosxTipo(TipoCuenta tipocuenta)
        {
            await _repo.DeleteCategoryAsync(tipocuenta);
            _binding.Clear();
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var items = (await _repo.GetAllAsync()).ToList();
            _binding = new BindingList<Expense>(items);
            dgv.DataSource = _binding;
        }

        private async Task ImportarDesdeArchivoAsync(TipoCuenta cuenta)
        {
            string titulo = cuenta switch
            {
                TipoCuenta.Torrero => "Importar archivo de Torrero",
                TipoCuenta.Mama => "Importar archivo de Mama",
                TipoCuenta.JL => "Importar archivo de José Luis",
                TipoCuenta.Ingresos_Gastos => "Importar archivo de aplicación Gestor de gastos",
                _ => "Importar archivo"
            };

            using var ofd = new OpenFileDialog
            {
                Filter = "Excel files|*.xlsx;*.xls",
                Multiselect = true,
                Title = titulo
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            int totalImportados = 0;

            foreach (var fileName in ofd.FileNames)
            {
                try
                {
                    IEnumerable<Expense> imported = cuenta switch
                    {
                        TipoCuenta.Ingresos_Gastos => ExcelImporterGastos.Import(fileName),
                        TipoCuenta.None => [],
                        _ => ExcelImporterIbercaja.Import(cuenta, fileName)
                    };

                    foreach (var ex in imported)
                    {
                        _binding.Insert(0, ex);

                        long id = await _repo.InsertAsync(ex); // ahora sí async
                        ex.Id = id;
                    }

                    totalImportados += imported.Count();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al importar el archivo {fileName}: {ex.Message}", "Error de Importación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show($"Importadas {totalImportados} filas en total.", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void GuardarDatosBD_Click(object? sender, EventArgs e)
        {
            // Guarda todos los elementos (update o insert ya hecho durante import); aquí actualizar los que tengan Id != 0
            foreach (var eItem in _binding)
            {
                if (eItem.Id == 0)
                {
                    var id = await _repo.InsertAsync(eItem);
                    eItem.Id = id;
                }
                else
                {
                    await _repo.UpdateAsync(eItem);
                }
            }
            MessageBox.Show("Guardado en la base de datos.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditarFila_Click(object? sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            if (dgv.CurrentRow.DataBoundItem is not Expense exp) return;

            using var dlg = new EditExpenseForm(exp);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                dgv.Refresh();
            }
        }

        private async void BorrarTs_Click(object sender, EventArgs e)
        {
            await DeleteSelectedAsync();
        }

        private async void BorrarTodosLosDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LimpiarDatos();
        }

        private void GraficoTS_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is TipoGrafico tipo)
            {
                var F = new GraficosxMesForm(_binding, tipo);
                F.ShowDialog();
            }
        }

        private void GraficoTSCategorias_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is TipoGrafico tipo)
            {
                var F = new GraficosxConceptoForm(_binding, tipo);
                F.ShowDialog();
            }
        }

        private async void ImportarTorreroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ImportarDesdeArchivoAsync(TipoCuenta.Torrero);
        }

        private async void ImportarMamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ImportarDesdeArchivoAsync(TipoCuenta.Mama);
        }

        private async void ImportarJoséLuisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ImportarDesdeArchivoAsync(TipoCuenta.JL);
        }

        private void AgrupadoPorConceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F = new ResumenConceptosForm(_binding);
            F.ShowDialog();
        }

        private void DashboardInteractivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F = new DashboardForm(_binding);
            F.ShowDialog();
        }

        private async void ImportarGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ImportarDesdeArchivoAsync(TipoCuenta.Ingresos_Gastos);
        }

        private async void BorrarDatosGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LimpiarDatosxTipo(TipoCuenta.Ingresos_Gastos);
        }

        private async void BorrarDatosMamáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LimpiarDatosxTipo(TipoCuenta.Mama);
        }

        private async void BorrarDatosTorreroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LimpiarDatosxTipo(TipoCuenta.Torrero);
        }

        private async void BorrarDatosJLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LimpiarDatosxTipo(TipoCuenta.JL);
        }
    }
}