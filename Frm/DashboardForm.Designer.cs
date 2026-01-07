namespace CuentasIbercaja.Frm
{
    partial class DashboardForm
    {
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelFiltrosYMétricas;

        private void InitializeComponent()
        {
            splitContainerMain = new SplitContainer();
            tablaDatos = new DataGridView();
            panel1 = new Panel();
            lblMayorGasto = new Label();
            lblGastoPromedio = new Label();
            lblBalanceTotal = new Label();
            btnAplicarFiltros = new Button();
            dtpFin = new DateTimePicker();
            lblFechaFin = new Label();
            dtpInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            cbTipoCuenta = new ComboBox();
            lblTipoCuenta = new Label();
            panelFiltrosYMétricas = new Panel();
            panelGraficos = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablaDatos).BeginInit();
            panel1.SuspendLayout();
            panelFiltrosYMétricas.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(tablaDatos);
            splitContainerMain.Panel1.Controls.Add(panel1);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelFiltrosYMétricas);
            splitContainerMain.Size = new Size(932, 596);
            splitContainerMain.SplitterDistance = 364;
            splitContainerMain.TabIndex = 0;
            // 
            // tablaDatos
            // 
            tablaDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaDatos.Dock = DockStyle.Fill;
            tablaDatos.Location = new Point(0, 212);
            tablaDatos.Name = "tablaDatos";
            tablaDatos.Size = new Size(364, 384);
            tablaDatos.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblMayorGasto);
            panel1.Controls.Add(lblGastoPromedio);
            panel1.Controls.Add(lblBalanceTotal);
            panel1.Controls.Add(btnAplicarFiltros);
            panel1.Controls.Add(dtpFin);
            panel1.Controls.Add(lblFechaFin);
            panel1.Controls.Add(dtpInicio);
            panel1.Controls.Add(lblFechaInicio);
            panel1.Controls.Add(cbTipoCuenta);
            panel1.Controls.Add(lblTipoCuenta);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(364, 212);
            panel1.TabIndex = 5;
            // 
            // lblMayorGasto
            // 
            lblMayorGasto.AutoSize = true;
            lblMayorGasto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMayorGasto.Location = new Point(194, 181);
            lblMayorGasto.Name = "lblMayorGasto";
            lblMayorGasto.Size = new Size(114, 15);
            lblMayorGasto.TabIndex = 36;
            lblMayorGasto.Text = "Mayor Gasto: €0.00";
            // 
            // lblGastoPromedio
            // 
            lblGastoPromedio.AutoSize = true;
            lblGastoPromedio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGastoPromedio.Location = new Point(176, 162);
            lblGastoPromedio.Name = "lblGastoPromedio";
            lblGastoPromedio.Size = new Size(133, 15);
            lblGastoPromedio.TabIndex = 35;
            lblGastoPromedio.Text = "Gasto Promedio: €0.00";
            // 
            // lblBalanceTotal
            // 
            lblBalanceTotal.AutoSize = true;
            lblBalanceTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBalanceTotal.Location = new Point(191, 143);
            lblBalanceTotal.Name = "lblBalanceTotal";
            lblBalanceTotal.Size = new Size(117, 15);
            lblBalanceTotal.TabIndex = 34;
            lblBalanceTotal.Text = "Balance Total: €0.00";
            // 
            // btnAplicarFiltros
            // 
            btnAplicarFiltros.Location = new Point(243, 101);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(100, 23);
            btnAplicarFiltros.TabIndex = 33;
            btnAplicarFiltros.Text = "Aplicar Filtros";
            btnAplicarFiltros.UseVisualStyleBackColor = true;
            btnAplicarFiltros.Click += BtnAplicarFiltros_Click;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(109, 72);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(234, 23);
            dtpFin.TabIndex = 31;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(19, 75);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(57, 15);
            lblFechaFin.TabIndex = 32;
            lblFechaFin.Text = "Fecha Fin";
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(109, 42);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(234, 23);
            dtpInicio.TabIndex = 29;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(19, 45);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(70, 15);
            lblFechaInicio.TabIndex = 30;
            lblFechaInicio.Text = "Fecha Inicio";
            // 
            // cbTipoCuenta
            // 
            cbTipoCuenta.FormattingEnabled = true;
            cbTipoCuenta.Location = new Point(109, 12);
            cbTipoCuenta.Name = "cbTipoCuenta";
            cbTipoCuenta.Size = new Size(200, 23);
            cbTipoCuenta.TabIndex = 27;
            // 
            // lblTipoCuenta
            // 
            lblTipoCuenta.AutoSize = true;
            lblTipoCuenta.Location = new Point(19, 15);
            lblTipoCuenta.Name = "lblTipoCuenta";
            lblTipoCuenta.Size = new Size(88, 15);
            lblTipoCuenta.TabIndex = 28;
            lblTipoCuenta.Text = "Tipo de Cuenta";
            // 
            // panelFiltrosYMétricas
            // 
            panelFiltrosYMétricas.Controls.Add(panelGraficos);
            panelFiltrosYMétricas.Dock = DockStyle.Fill;
            panelFiltrosYMétricas.Location = new Point(0, 0);
            panelFiltrosYMétricas.Name = "panelFiltrosYMétricas";
            panelFiltrosYMétricas.Size = new Size(564, 596);
            panelFiltrosYMétricas.TabIndex = 0;
            // 
            // panelGraficos
            // 
            panelGraficos.Dock = DockStyle.Fill;
            panelGraficos.Location = new Point(0, 0);
            panelGraficos.Name = "panelGraficos";
            panelGraficos.Size = new Size(564, 596);
            panelGraficos.TabIndex = 0;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 596);
            Controls.Add(splitContainerMain);
            Name = "DashboardForm";
            Text = "DashboardForm";
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablaDatos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelFiltrosYMétricas.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel panelGraficos;
        private DataGridView tablaDatos;
        private Panel panel1;
        private Label lblMayorGasto;
        private Label lblGastoPromedio;
        private Label lblBalanceTotal;
        private Button btnAplicarFiltros;
        private DateTimePicker dtpFin;
        private Label lblFechaFin;
        private DateTimePicker dtpInicio;
        private Label lblFechaInicio;
        private ComboBox cbTipoCuenta;
        private Label lblTipoCuenta;
    }
}