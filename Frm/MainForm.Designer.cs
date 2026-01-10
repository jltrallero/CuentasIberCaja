using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Wordprocessing;

namespace GestorGastos
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            importarTorreroToolStripMenuItem = new ToolStripMenuItem();
            importarMamaToolStripMenuItem = new ToolStripMenuItem();
            importarJoséLuisToolStripMenuItem = new ToolStripMenuItem();
            importarGastosToolStripMenuItem = new ToolStripMenuItem();
            EdicionRejillaTs = new ToolStripDropDownButton();
            editarFilaToolStripMenuItem = new ToolStripMenuItem();
            borrarToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            Datos = new ToolStripDropDownButton();
            GuardarEnBaseDeDatosToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            BorrarTodosLosDatosToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            borrarDatosGastosToolStripMenuItem = new ToolStripMenuItem();
            borrarDatosMamáToolStripMenuItem = new ToolStripMenuItem();
            borrarDatosTorreroToolStripMenuItem = new ToolStripMenuItem();
            borrarDatosJLToolStripMenuItem = new ToolStripMenuItem();
            VisualizacionTS = new ToolStripDropDownButton();
            graficoPorMesesToolStripMenuItem = new ToolStripMenuItem();
            graficosPorConceptosToolStripMenuItem = new ToolStripMenuItem();
            resumenAgrupadoToolStripMenuItem = new ToolStripMenuItem();
            dashBoardToolStripMenuItem = new ToolStripMenuItem();
            GraficoxConceptoTS = new ToolStripMenuItem();
            agrupadoPorConceptosToolStripMenuItem = new ToolStripMenuItem();
            dashboardInteractivoToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            dgv = new DataGridView();
            panel2 = new Panel();
            clbCategorias = new CheckedListBox();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator2, toolStripDropDownButton1, EdicionRejillaTs, toolStripSeparator1, Datos, VisualizacionTS });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "Menú ";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { importarTorreroToolStripMenuItem, importarMamaToolStripMenuItem, importarJoséLuisToolStripMenuItem, importarGastosToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(66, 22);
            toolStripDropDownButton1.Text = "Importar";
            // 
            // importarTorreroToolStripMenuItem
            // 
            importarTorreroToolStripMenuItem.Name = "importarTorreroToolStripMenuItem";
            importarTorreroToolStripMenuItem.Size = new Size(169, 22);
            importarTorreroToolStripMenuItem.Text = "Importar Torrero";
            importarTorreroToolStripMenuItem.Click += ImportarTorreroToolStripMenuItem_Click;
            // 
            // importarMamaToolStripMenuItem
            // 
            importarMamaToolStripMenuItem.Name = "importarMamaToolStripMenuItem";
            importarMamaToolStripMenuItem.Size = new Size(169, 22);
            importarMamaToolStripMenuItem.Text = "Importar Mama";
            importarMamaToolStripMenuItem.Click += ImportarMamaToolStripMenuItem_Click;
            // 
            // importarJoséLuisToolStripMenuItem
            // 
            importarJoséLuisToolStripMenuItem.Name = "importarJoséLuisToolStripMenuItem";
            importarJoséLuisToolStripMenuItem.Size = new Size(169, 22);
            importarJoséLuisToolStripMenuItem.Text = "Importar José Luis";
            importarJoséLuisToolStripMenuItem.Click += ImportarJoséLuisToolStripMenuItem_Click;
            // 
            // importarGastosToolStripMenuItem
            // 
            importarGastosToolStripMenuItem.Name = "importarGastosToolStripMenuItem";
            importarGastosToolStripMenuItem.Size = new Size(169, 22);
            importarGastosToolStripMenuItem.Text = "Importar Gastos";
            importarGastosToolStripMenuItem.Click += ImportarGastosToolStripMenuItem_Click;
            // 
            // EdicionRejillaTs
            // 
            EdicionRejillaTs.DisplayStyle = ToolStripItemDisplayStyle.Text;
            EdicionRejillaTs.DropDownItems.AddRange(new ToolStripItem[] { editarFilaToolStripMenuItem, borrarToolStripMenuItem });
            EdicionRejillaTs.Image = (Image)resources.GetObject("EdicionRejillaTs.Image");
            EdicionRejillaTs.ImageTransparentColor = System.Drawing.Color.Magenta;
            EdicionRejillaTs.Name = "EdicionRejillaTs";
            EdicionRejillaTs.Size = new Size(118, 22);
            EdicionRejillaTs.Text = "Edición de la rejilla";
            // 
            // editarFilaToolStripMenuItem
            // 
            editarFilaToolStripMenuItem.Name = "editarFilaToolStripMenuItem";
            editarFilaToolStripMenuItem.Size = new Size(123, 22);
            editarFilaToolStripMenuItem.Text = "Editar fila";
            editarFilaToolStripMenuItem.Click += EditarFila_Click;
            // 
            // borrarToolStripMenuItem
            // 
            borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            borrarToolStripMenuItem.Size = new Size(123, 22);
            borrarToolStripMenuItem.Text = "Borrar";
            borrarToolStripMenuItem.Click += BorrarTs_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // Datos
            // 
            Datos.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Datos.DropDownItems.AddRange(new ToolStripItem[] { GuardarEnBaseDeDatosToolStripMenuItem, toolStripSeparator4, BorrarTodosLosDatosToolStripMenuItem, toolStripSeparator3, borrarDatosGastosToolStripMenuItem, borrarDatosMamáToolStripMenuItem, borrarDatosTorreroToolStripMenuItem, borrarDatosJLToolStripMenuItem });
            Datos.Image = (Image)resources.GetObject("Datos.Image");
            Datos.ImageTransparentColor = System.Drawing.Color.Magenta;
            Datos.Name = "Datos";
            Datos.Size = new Size(177, 22);
            Datos.Text = "Operaciones en Base de datos";
            // 
            // GuardarEnBaseDeDatosToolStripMenuItem
            // 
            GuardarEnBaseDeDatosToolStripMenuItem.Name = "GuardarEnBaseDeDatosToolStripMenuItem";
            GuardarEnBaseDeDatosToolStripMenuItem.Size = new Size(207, 22);
            GuardarEnBaseDeDatosToolStripMenuItem.Text = "Guardar en Base de datos";
            GuardarEnBaseDeDatosToolStripMenuItem.Click += GuardarDatosBD_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(204, 6);
            // 
            // BorrarTodosLosDatosToolStripMenuItem
            // 
            BorrarTodosLosDatosToolStripMenuItem.Name = "BorrarTodosLosDatosToolStripMenuItem";
            BorrarTodosLosDatosToolStripMenuItem.Size = new Size(207, 22);
            BorrarTodosLosDatosToolStripMenuItem.Text = "Borrar todos los datos";
            BorrarTodosLosDatosToolStripMenuItem.Click += BorrarTodosLosDatosToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(204, 6);
            // 
            // borrarDatosGastosToolStripMenuItem
            // 
            borrarDatosGastosToolStripMenuItem.Name = "borrarDatosGastosToolStripMenuItem";
            borrarDatosGastosToolStripMenuItem.Size = new Size(207, 22);
            borrarDatosGastosToolStripMenuItem.Text = "Borrar datos Gastos";
            borrarDatosGastosToolStripMenuItem.Click += BorrarDatosGastosToolStripMenuItem_Click;
            // 
            // borrarDatosMamáToolStripMenuItem
            // 
            borrarDatosMamáToolStripMenuItem.Name = "borrarDatosMamáToolStripMenuItem";
            borrarDatosMamáToolStripMenuItem.Size = new Size(207, 22);
            borrarDatosMamáToolStripMenuItem.Text = "Borrar datos Mamá";
            borrarDatosMamáToolStripMenuItem.Click += BorrarDatosMamáToolStripMenuItem_Click;
            // 
            // borrarDatosTorreroToolStripMenuItem
            // 
            borrarDatosTorreroToolStripMenuItem.Name = "borrarDatosTorreroToolStripMenuItem";
            borrarDatosTorreroToolStripMenuItem.Size = new Size(207, 22);
            borrarDatosTorreroToolStripMenuItem.Text = "Borrar datos Torrero";
            borrarDatosTorreroToolStripMenuItem.Click += BorrarDatosTorreroToolStripMenuItem_Click;
            // 
            // borrarDatosJLToolStripMenuItem
            // 
            borrarDatosJLToolStripMenuItem.Name = "borrarDatosJLToolStripMenuItem";
            borrarDatosJLToolStripMenuItem.Size = new Size(207, 22);
            borrarDatosJLToolStripMenuItem.Text = "Borrar datos J.L.";
            borrarDatosJLToolStripMenuItem.Click += BorrarDatosJLToolStripMenuItem_Click;
            // 
            // VisualizacionTS
            // 
            VisualizacionTS.DropDownItems.AddRange(new ToolStripItem[] { graficoPorMesesToolStripMenuItem, graficosPorConceptosToolStripMenuItem, resumenAgrupadoToolStripMenuItem, dashBoardToolStripMenuItem });
            VisualizacionTS.Name = "VisualizacionTS";
            VisualizacionTS.Size = new Size(88, 22);
            VisualizacionTS.Text = "Visualización";
            // 
            // graficoPorMesesToolStripMenuItem
            // 
            graficoPorMesesToolStripMenuItem.Name = "graficoPorMesesToolStripMenuItem";
            graficoPorMesesToolStripMenuItem.Size = new Size(198, 22);
            graficoPorMesesToolStripMenuItem.Text = "Grafico por meses";
            graficoPorMesesToolStripMenuItem.Click += GraficoTS_Click;
            // 
            // graficosPorConceptosToolStripMenuItem
            // 
            graficosPorConceptosToolStripMenuItem.Name = "graficosPorConceptosToolStripMenuItem";
            graficosPorConceptosToolStripMenuItem.Size = new Size(198, 22);
            graficosPorConceptosToolStripMenuItem.Text = "Graficos por Conceptos";
            graficosPorConceptosToolStripMenuItem.Click += GxCategoriasMenu_Click;
            // 
            // resumenAgrupadoToolStripMenuItem
            // 
            resumenAgrupadoToolStripMenuItem.Name = "resumenAgrupadoToolStripMenuItem";
            resumenAgrupadoToolStripMenuItem.Size = new Size(198, 22);
            resumenAgrupadoToolStripMenuItem.Text = "Resumen agrupado";
            resumenAgrupadoToolStripMenuItem.Click += AgrupadoPorConceptosToolStripMenuItem_Click;
            // 
            // dashBoardToolStripMenuItem
            // 
            dashBoardToolStripMenuItem.Name = "dashBoardToolStripMenuItem";
            dashBoardToolStripMenuItem.Size = new Size(198, 22);
            dashBoardToolStripMenuItem.Text = "DashBoard";
            dashBoardToolStripMenuItem.Click += DashboardInteractivoToolStripMenuItem_Click;
            // 
            // GraficoxConceptoTS
            // 
            GraficoxConceptoTS.Name = "GraficoxConceptoTS";
            GraficoxConceptoTS.Size = new Size(206, 22);
            GraficoxConceptoTS.Text = "Gráfico por conceptos";
            GraficoxConceptoTS.Click += GxCategoriasMenu_Click;
            // 
            // agrupadoPorConceptosToolStripMenuItem
            // 
            agrupadoPorConceptosToolStripMenuItem.Name = "agrupadoPorConceptosToolStripMenuItem";
            agrupadoPorConceptosToolStripMenuItem.Size = new Size(206, 22);
            agrupadoPorConceptosToolStripMenuItem.Text = "Agrupado por conceptos";
            agrupadoPorConceptosToolStripMenuItem.Click += AgrupadoPorConceptosToolStripMenuItem_Click;
            // 
            // dashboardInteractivoToolStripMenuItem
            // 
            dashboardInteractivoToolStripMenuItem.Name = "dashboardInteractivoToolStripMenuItem";
            dashboardInteractivoToolStripMenuItem.Size = new Size(206, 22);
            dashboardInteractivoToolStripMenuItem.Text = "Dashboard Interactivo";
            dashboardInteractivoToolStripMenuItem.Click += DashboardInteractivoToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgv);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 561);
            panel1.TabIndex = 4;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 24);
            dgv.Name = "dgv";
            dgv.Size = new Size(800, 537);
            dgv.TabIndex = 6;
            dgv.ColumnHeaderMouseClick += Dgv_ColumnHeaderMouseClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(clbCategorias);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 24);
            panel2.TabIndex = 5;
            // 
            // clbCategorias
            // 
            clbCategorias.Dock = DockStyle.Fill;
            clbCategorias.FormattingEnabled = true;
            clbCategorias.Location = new Point(0, 0);
            clbCategorias.MultiColumn = true;
            clbCategorias.Name = "clbCategorias";
            clbCategorias.Size = new Size(800, 24);
            clbCategorias.TabIndex = 2;
            clbCategorias.ItemCheck += ClbCategorias_ItemCheck;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 586);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor de Gastos";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripDropDownButton EdicionRejillaTs;
        private ToolStripMenuItem editarFilaToolStripMenuItem;
        private ToolStripMenuItem borrarToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton Datos;
        private ToolStripMenuItem GuardarEnBaseDeDatosToolStripMenuItem;
        private ToolStripMenuItem BorrarTodosLosDatosToolStripMenuItem;
        private ToolStripDropDownButton VisualizacionTS;        
        private ToolStripMenuItem GraficoxConceptoTS;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem importarTorreroToolStripMenuItem;
        private ToolStripMenuItem importarMamaToolStripMenuItem;
        private ToolStripMenuItem importarJoséLuisToolStripMenuItem;
        private ToolStripMenuItem agrupadoPorConceptosToolStripMenuItem;
        private ToolStripMenuItem dashboardInteractivoToolStripMenuItem;
        private ToolStripMenuItem importarGastosToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem borrarDatosGastosToolStripMenuItem;
        private ToolStripMenuItem borrarDatosMamáToolStripMenuItem;
        private ToolStripMenuItem borrarDatosTorreroToolStripMenuItem;
        private ToolStripMenuItem borrarDatosJLToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private CheckedListBox clbCategorias;
        private DataGridView dgv;
        private ToolStripMenuItem graficoPorMesesToolStripMenuItem;
        private ToolStripMenuItem graficosPorConceptosToolStripMenuItem;
        private ToolStripMenuItem resumenAgrupadoToolStripMenuItem;
        private ToolStripMenuItem dashBoardToolStripMenuItem;
    }
}