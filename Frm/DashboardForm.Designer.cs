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
            lblIngresoPromedio = new Label();
            lblGastos = new Label();
            lblIngresos = new Label();
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
            ResumenCtrls = new Panel();
            splitContainer1 = new SplitContainer();
            dataGridViewIngresos = new DataGridView();
            dataGridViewPagos = new DataGridView();
            panelGraficos = new Panel();
            splitContainer2 = new SplitContainer();
            lblBalancePromedio = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablaDatos).BeginInit();
            panel1.SuspendLayout();
            panelFiltrosYMétricas.SuspendLayout();
            ResumenCtrls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngresos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagos).BeginInit();
            panelGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.SuspendLayout();
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
            splitContainerMain.Size = new Size(1089, 753);
            splitContainerMain.SplitterDistance = 425;
            splitContainerMain.TabIndex = 0;
            // 
            // tablaDatos
            // 
            tablaDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaDatos.Dock = DockStyle.Fill;
            tablaDatos.Location = new Point(0, 212);
            tablaDatos.Name = "tablaDatos";
            tablaDatos.Size = new Size(425, 541);
            tablaDatos.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblBalancePromedio);
            panel1.Controls.Add(lblIngresoPromedio);
            panel1.Controls.Add(lblGastos);
            panel1.Controls.Add(lblIngresos);
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
            panel1.Size = new Size(425, 212);
            panel1.TabIndex = 5;
            // 
            // lblIngresoPromedio
            // 
            lblIngresoPromedio.AutoSize = true;
            lblIngresoPromedio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIngresoPromedio.Location = new Point(200, 141);
            lblIngresoPromedio.Name = "lblIngresoPromedio";
            lblIngresoPromedio.Size = new Size(143, 15);
            lblIngresoPromedio.TabIndex = 39;
            lblIngresoPromedio.Text = "Ingreso Promedio: €0.00";
            lblIngresoPromedio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGastos
            // 
            lblGastos.AutoSize = true;
            lblGastos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGastos.Location = new Point(19, 163);
            lblGastos.Name = "lblGastos";
            lblGastos.Size = new Size(81, 15);
            lblGastos.TabIndex = 37;
            lblGastos.Text = "Gastos: €0.00";
            lblGastos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIngresos
            // 
            lblIngresos.AutoSize = true;
            lblIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIngresos.Location = new Point(19, 141);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(91, 15);
            lblIngresos.TabIndex = 36;
            lblIngresos.Text = "Ingresos: €0.00";
            lblIngresos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGastoPromedio
            // 
            lblGastoPromedio.AutoSize = true;
            lblGastoPromedio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGastoPromedio.Location = new Point(210, 163);
            lblGastoPromedio.Name = "lblGastoPromedio";
            lblGastoPromedio.Size = new Size(133, 15);
            lblGastoPromedio.TabIndex = 35;
            lblGastoPromedio.Text = "Gasto Promedio: €0.00";
            lblGastoPromedio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBalanceTotal
            // 
            lblBalanceTotal.AutoSize = true;
            lblBalanceTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBalanceTotal.Location = new Point(19, 185);
            lblBalanceTotal.Name = "lblBalanceTotal";
            lblBalanceTotal.Size = new Size(117, 15);
            lblBalanceTotal.TabIndex = 34;
            lblBalanceTotal.Text = "Balance Total: €0.00";
            lblBalanceTotal.TextAlign = ContentAlignment.MiddleRight;
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
            panelFiltrosYMétricas.Controls.Add(ResumenCtrls);
            panelFiltrosYMétricas.Controls.Add(panelGraficos);
            panelFiltrosYMétricas.Dock = DockStyle.Fill;
            panelFiltrosYMétricas.Location = new Point(0, 0);
            panelFiltrosYMétricas.Name = "panelFiltrosYMétricas";
            panelFiltrosYMétricas.Size = new Size(660, 753);
            panelFiltrosYMétricas.TabIndex = 0;
            // 
            // ResumenCtrls
            // 
            ResumenCtrls.Controls.Add(splitContainer1);
            ResumenCtrls.Dock = DockStyle.Fill;
            ResumenCtrls.Location = new Point(0, 0);
            ResumenCtrls.Name = "ResumenCtrls";
            ResumenCtrls.Size = new Size(660, 378);
            ResumenCtrls.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewIngresos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewPagos);
            splitContainer1.Size = new Size(660, 378);
            splitContainer1.SplitterDistance = 348;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewIngresos
            // 
            dataGridViewIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngresos.Dock = DockStyle.Fill;
            dataGridViewIngresos.Location = new Point(0, 0);
            dataGridViewIngresos.Name = "dataGridViewIngresos";
            dataGridViewIngresos.Size = new Size(348, 378);
            dataGridViewIngresos.TabIndex = 0;
            // 
            // dataGridViewPagos
            // 
            dataGridViewPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPagos.Dock = DockStyle.Fill;
            dataGridViewPagos.Location = new Point(0, 0);
            dataGridViewPagos.Name = "dataGridViewPagos";
            dataGridViewPagos.Size = new Size(308, 378);
            dataGridViewPagos.TabIndex = 0;
            // 
            // panelGraficos
            // 
            panelGraficos.Controls.Add(splitContainer2);
            panelGraficos.Dock = DockStyle.Bottom;
            panelGraficos.Location = new Point(0, 378);
            panelGraficos.Name = "panelGraficos";
            panelGraficos.Size = new Size(660, 375);
            panelGraficos.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Size = new Size(660, 375);
            splitContainer2.SplitterDistance = 334;
            splitContainer2.TabIndex = 0;
            // 
            // lblBalancePromedio
            // 
            lblBalancePromedio.AutoSize = true;
            lblBalancePromedio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBalancePromedio.Location = new Point(199, 185);
            lblBalancePromedio.Name = "lblBalancePromedio";
            lblBalancePromedio.Size = new Size(144, 15);
            lblBalancePromedio.TabIndex = 40;
            lblBalancePromedio.Text = "Balance Promedio: €0.00";
            lblBalancePromedio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 753);
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
            ResumenCtrls.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngresos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagos).EndInit();
            panelGraficos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel panelGraficos;
        private DataGridView tablaDatos;
        private Panel panel1;
        private Label lblIngresos;
        private Label lblGastoPromedio;
        private Label lblBalanceTotal;
        private Button btnAplicarFiltros;
        private DateTimePicker dtpFin;
        private Label lblFechaFin;
        private DateTimePicker dtpInicio;
        private Label lblFechaInicio;
        private ComboBox cbTipoCuenta;
        private Label lblTipoCuenta;
        private Panel ResumenCtrls;
        private SplitContainer splitContainer1;
        private DataGridView dataGridViewIngresos;
        private DataGridView dataGridViewPagos;
        private SplitContainer splitContainer2;
        private Label lblGastos;
        private Label lblIngresoPromedio;
        private Label lblBalancePromedio;
    }
}