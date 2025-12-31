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
            EdicionRejillaTs = new ToolStripDropDownButton();
            editarFilaToolStripMenuItem = new ToolStripMenuItem();
            borrarToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            Datos = new ToolStripDropDownButton();
            GuardarEnBaseDeDatosToolStripMenuItem = new ToolStripMenuItem();
            BorrarTodosLosDatosToolStripMenuItem = new ToolStripMenuItem();
            VisualizacionTS = new ToolStripDropDownButton();
            GraficoTS = new ToolStripMenuItem();
            gxMesMenuLinea = new ToolStripMenuItem();
            gxMesMenuBarrasH = new ToolStripMenuItem();
            gxMesMenuBarrasV = new ToolStripMenuItem();
            gxMesMenuCircular = new ToolStripMenuItem();
            gxMesMenuAreas = new ToolStripMenuItem();
            gxMesMenuDispersion = new ToolStripMenuItem();
            gxMesMenuRadar = new ToolStripMenuItem();
            gxMesMenuBurbujas = new ToolStripMenuItem();
            gxCategoriasMenu = new ToolStripMenuItem();
            gxCategoriaMenuLinea = new ToolStripMenuItem();
            gxCategoriaBarrasH = new ToolStripMenuItem();
            gxCategoriaBarrasV = new ToolStripMenuItem();
            gxCategoriaCircular = new ToolStripMenuItem();
            gxCategoriaAreas = new ToolStripMenuItem();
            gxCategoriaDispersion = new ToolStripMenuItem();
            gxCategoriaRadar = new ToolStripMenuItem();
            gxCategoriaBurbujas = new ToolStripMenuItem();
            dgv = new DataGridView();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
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
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { importarTorreroToolStripMenuItem, importarMamaToolStripMenuItem, importarJoséLuisToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(66, 22);
            toolStripDropDownButton1.Text = "Importar";
            // 
            // importarTorreroToolStripMenuItem
            // 
            importarTorreroToolStripMenuItem.Name = "importarTorreroToolStripMenuItem";
            importarTorreroToolStripMenuItem.Size = new Size(180, 22);
            importarTorreroToolStripMenuItem.Text = "Importar Torrero";
            importarTorreroToolStripMenuItem.Click += ImportarTorreroToolStripMenuItem_Click;
            // 
            // importarMamaToolStripMenuItem
            // 
            importarMamaToolStripMenuItem.Name = "importarMamaToolStripMenuItem";
            importarMamaToolStripMenuItem.Size = new Size(180, 22);
            importarMamaToolStripMenuItem.Text = "Importar Mama";
            importarMamaToolStripMenuItem.Click += ImportarMamaToolStripMenuItem_Click;
            // 
            // importarJoséLuisToolStripMenuItem
            // 
            importarJoséLuisToolStripMenuItem.Name = "importarJoséLuisToolStripMenuItem";
            importarJoséLuisToolStripMenuItem.Size = new Size(180, 22);
            importarJoséLuisToolStripMenuItem.Text = "Importar José Luis";
            importarJoséLuisToolStripMenuItem.Click += ImportarJoséLuisToolStripMenuItem_Click;
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
            Datos.DropDownItems.AddRange(new ToolStripItem[] { GuardarEnBaseDeDatosToolStripMenuItem, BorrarTodosLosDatosToolStripMenuItem });
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
            // BorrarTodosLosDatosToolStripMenuItem
            // 
            BorrarTodosLosDatosToolStripMenuItem.Name = "BorrarTodosLosDatosToolStripMenuItem";
            BorrarTodosLosDatosToolStripMenuItem.Size = new Size(207, 22);
            BorrarTodosLosDatosToolStripMenuItem.Text = "Borrar todos los datos";
            BorrarTodosLosDatosToolStripMenuItem.Click += BorrarTodosLosDatosToolStripMenuItem_Click;
            // 
            // VisualizacionTS
            // 
            VisualizacionTS.DisplayStyle = ToolStripItemDisplayStyle.Text;
            VisualizacionTS.DropDownItems.AddRange(new ToolStripItem[] { GraficoTS, gxCategoriasMenu });
            VisualizacionTS.Image = (Image)resources.GetObject("VisualizacionTS.Image");
            VisualizacionTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            VisualizacionTS.Name = "VisualizacionTS";
            VisualizacionTS.Size = new Size(88, 22);
            VisualizacionTS.Text = "Visualización";
            // 
            // GraficoTS
            // 
            GraficoTS.DropDownItems.AddRange(new ToolStripItem[] { gxMesMenuLinea, gxMesMenuBarrasH, gxMesMenuBarrasV, gxMesMenuCircular, gxMesMenuAreas, gxMesMenuDispersion, gxMesMenuRadar, gxMesMenuBurbujas });
            GraficoTS.Name = "GraficoTS";
            GraficoTS.Size = new Size(190, 22);
            GraficoTS.Text = "Gráfico por meses";
            GraficoTS.Click += GraficoTS_Click;
            // 
            // gxMesMenuLinea
            // 
            gxMesMenuLinea.Name = "gxMesMenuLinea";
            gxMesMenuLinea.Size = new Size(232, 22);
            gxMesMenuLinea.Text = "Gráfico de líneas";
            gxMesMenuLinea.Click += GraficoTS_Click;
            // 
            // gxMesMenuBarrasH
            // 
            gxMesMenuBarrasH.Name = "gxMesMenuBarrasH";
            gxMesMenuBarrasH.Size = new Size(232, 22);
            gxMesMenuBarrasH.Text = "Barras horizontales";
            gxMesMenuBarrasH.Click += GraficoTS_Click;
            // 
            // gxMesMenuBarrasV
            // 
            gxMesMenuBarrasV.Name = "gxMesMenuBarrasV";
            gxMesMenuBarrasV.Size = new Size(232, 22);
            gxMesMenuBarrasV.Text = "Barras verticales";
            gxMesMenuBarrasV.Click += GraficoTS_Click;
            // 
            // gxMesMenuCircular
            // 
            gxMesMenuCircular.Name = "gxMesMenuCircular";
            gxMesMenuCircular.Size = new Size(232, 22);
            gxMesMenuCircular.Text = "Gráfico circular (Pie)";
            gxMesMenuCircular.Click += GraficoTS_Click;
            // 
            // gxMesMenuAreas
            // 
            gxMesMenuAreas.Name = "gxMesMenuAreas";
            gxMesMenuAreas.Size = new Size(232, 22);
            gxMesMenuAreas.Text = "Gráfico de áreas";
            gxMesMenuAreas.Click += GraficoTS_Click;
            // 
            // gxMesMenuDispersion
            // 
            gxMesMenuDispersion.Name = "gxMesMenuDispersion";
            gxMesMenuDispersion.Size = new Size(232, 22);
            gxMesMenuDispersion.Text = "Gráfico de dispersión (Scatter)";
            gxMesMenuDispersion.Click += GraficoTS_Click;
            // 
            // gxMesMenuRadar
            // 
            gxMesMenuRadar.Name = "gxMesMenuRadar";
            gxMesMenuRadar.Size = new Size(232, 22);
            gxMesMenuRadar.Text = "Gráfico tipo radar";
            gxMesMenuRadar.Click += GraficoTS_Click;
            // 
            // gxMesMenuBurbujas
            // 
            gxMesMenuBurbujas.Name = "gxMesMenuBurbujas";
            gxMesMenuBurbujas.Size = new Size(232, 22);
            gxMesMenuBurbujas.Text = "Gráfico de burbujas";
            gxMesMenuBurbujas.Click += GraficoTS_Click;
            // 
            // gxCategoriasMenu
            // 
            gxCategoriasMenu.DropDownItems.AddRange(new ToolStripItem[] { gxCategoriaMenuLinea, gxCategoriaBarrasH, gxCategoriaBarrasV, gxCategoriaCircular, gxCategoriaAreas, gxCategoriaDispersion, gxCategoriaRadar, gxCategoriaBurbujas });
            gxCategoriasMenu.Name = "gxCategoriasMenu";
            gxCategoriasMenu.Size = new Size(190, 22);
            gxCategoriasMenu.Text = "Gráfico por categorías";
            // 
            // gxCategoriaMenuLinea
            // 
            gxCategoriaMenuLinea.Name = "gxCategoriaMenuLinea";
            gxCategoriaMenuLinea.Size = new Size(232, 22);
            gxCategoriaMenuLinea.Text = "Gráfico de líneas";
            gxCategoriaMenuLinea.Click += GraficoTSCategorias_Click;
            // 
            // gxCategoriaBarrasH
            // 
            gxCategoriaBarrasH.Name = "gxCategoriaBarrasH";
            gxCategoriaBarrasH.Size = new Size(232, 22);
            gxCategoriaBarrasH.Text = "Barras horizontales";
            gxCategoriaBarrasH.Click += GraficoTSCategorias_Click;
            // 
            // gxCategoriaBarrasV
            // 
            gxCategoriaBarrasV.Name = "gxCategoriaBarrasV";
            gxCategoriaBarrasV.Size = new Size(232, 22);
            gxCategoriaBarrasV.Text = "Barras verticales";
            gxCategoriaBarrasV.Click += GraficoTSCategorias_Click;
            // 
            // gxCategoriaCircular
            // 
            gxCategoriaCircular.Name = "gxCategoriaCircular";
            gxCategoriaCircular.Size = new Size(232, 22);
            gxCategoriaCircular.Text = "Gráfico circular (Pie)";
            gxCategoriaCircular.Click += GraficoTSCategorias_Click;
            // 
            // gxCategoriaAreas
            // 
            gxCategoriaAreas.Name = "gxCategoriaAreas";
            gxCategoriaAreas.Size = new Size(232, 22);
            gxCategoriaAreas.Text = "Gráfico de áreas";
            gxCategoriaAreas.Click += GraficoTSCategorias_Click;
            // 
            // gxCategoriaDispersion
            // 
            gxCategoriaDispersion.Name = "gxCategoriaDispersion";
            gxCategoriaDispersion.Size = new Size(232, 22);
            gxCategoriaDispersion.Text = "Gráfico de dispersión (Scatter)";
            gxCategoriaDispersion.Click += GraficoTSCategorias_Click;
            // 
            // gxCategoriaRadar
            // 
            gxCategoriaRadar.Name = "gxCategoriaRadar";
            gxCategoriaRadar.Size = new Size(232, 22);
            gxCategoriaRadar.Text = "Gráfico tipo radar";
            gxCategoriaRadar.Click += GraficoTSCategorias_Click;
            // 
            // gxCategoriaBurbujas
            // 
            gxCategoriaBurbujas.Name = "gxCategoriaBurbujas";
            gxCategoriaBurbujas.Size = new Size(232, 22);
            gxCategoriaBurbujas.Text = "Gráfico de burbujas";
            gxCategoriaBurbujas.Click += GraficoTSCategorias_Click;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 25);
            dgv.Name = "dgv";
            dgv.Size = new Size(800, 425);
            dgv.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor de Gastos";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
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
        private DataGridView dgv;
        private ToolStripDropDownButton Datos;
        private ToolStripMenuItem GuardarEnBaseDeDatosToolStripMenuItem;
        private ToolStripMenuItem BorrarTodosLosDatosToolStripMenuItem;
        private ToolStripDropDownButton VisualizacionTS;
        private ToolStripMenuItem GraficoTS;
        private ToolStripMenuItem gxMesMenuLinea;
        private ToolStripMenuItem gxMesMenuBarrasH;
        private ToolStripMenuItem gxMesMenuBarrasV;
        private ToolStripMenuItem gxMesMenuCircular;
        private ToolStripMenuItem gxMesMenuAreas;
        private ToolStripMenuItem gxMesMenuDispersion;
        private ToolStripMenuItem gxMesMenuRadar;
        private ToolStripMenuItem gxMesMenuBurbujas;
        private ToolStripMenuItem gxCategoriasMenu;
        private ToolStripMenuItem gxCategoriaMenuLinea;
        private ToolStripMenuItem gxCategoriaBarrasH;
        private ToolStripMenuItem gxCategoriaBarrasV;
        private ToolStripMenuItem gxCategoriaCircular;
        private ToolStripMenuItem gxCategoriaAreas;
        private ToolStripMenuItem gxCategoriaDispersion;
        private ToolStripMenuItem gxCategoriaRadar;
        private ToolStripMenuItem gxCategoriaBurbujas;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem importarTorreroToolStripMenuItem;
        private ToolStripMenuItem importarMamaToolStripMenuItem;
        private ToolStripMenuItem importarJoséLuisToolStripMenuItem;
    }
}