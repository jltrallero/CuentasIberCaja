namespace GestorGastos.Frm
{
    partial class GraficosxMesForm
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
            SelectorTipoGraficoCtrl = new Panel();
            clbTipoGrafico = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            tabPage2 = new TabPage();
            SelectorTipoGraficoCtrl.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // SelectorTipoGraficoCtrl
            // 
            SelectorTipoGraficoCtrl.Controls.Add(clbTipoGrafico);
            SelectorTipoGraficoCtrl.Dock = DockStyle.Top;
            SelectorTipoGraficoCtrl.Location = new Point(0, 0);
            SelectorTipoGraficoCtrl.Name = "SelectorTipoGraficoCtrl";
            SelectorTipoGraficoCtrl.Size = new Size(1184, 24);
            SelectorTipoGraficoCtrl.TabIndex = 6;
            // 
            // clbTipoGrafico
            // 
            clbTipoGrafico.Dock = DockStyle.Fill;
            clbTipoGrafico.FormattingEnabled = true;
            clbTipoGrafico.Location = new Point(0, 0);
            clbTipoGrafico.Name = "clbTipoGrafico";
            clbTipoGrafico.Size = new Size(1184, 23);
            clbTipoGrafico.TabIndex = 1;
            clbTipoGrafico.SelectedIndexChanged += ClbTipoGrafico_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1184, 579);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1176, 551);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(1170, 545);
            splitContainer1.SplitterDistance = 610;
            splitContainer1.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1176, 551);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // GraficosxMesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 603);
            Controls.Add(tabControl1);
            Controls.Add(SelectorTipoGraficoCtrl);
            Name = "GraficosxMesForm";
            Text = "Ingresos y gastos por meses";
            SelectorTipoGraficoCtrl.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel SelectorTipoGraficoCtrl;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private SplitContainer splitContainer1;
        private TabPage tabPage2;
        private ComboBox clbTipoGrafico;
    }
}