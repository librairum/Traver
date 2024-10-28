namespace Inv.UI.Win
{
    partial class frmGraficoMovimiento
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
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            this.radPivotGrid1 = new Telerik.WinControls.UI.RadPivotGrid();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnVista = new Telerik.WinControls.UI.RadButton();
            this.btnbuscar = new Telerik.WinControls.UI.RadButton();
            this.dtpFechafin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtRangoFechas = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtHistorico = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtMensual = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtAnual = new Telerik.WinControls.UI.RadRadioButton();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPivotGrid1
            // 
            this.radPivotGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPivotGrid1.Location = new System.Drawing.Point(0, 327);
            this.radPivotGrid1.Name = "radPivotGrid1";
            this.radPivotGrid1.Size = new System.Drawing.Size(1159, 144);
            this.radPivotGrid1.TabIndex = 0;
            this.radPivotGrid1.Text = "radPivotGrid1";
            this.radPivotGrid1.PrintElementFormatting += new Telerik.WinControls.UI.PrintElementEventHandler(this.radPivotGrid1_PrintElementFormatting);
            this.radPivotGrid1.PrintElementPaint += new Telerik.WinControls.UI.PrintElementPaintEventHandler(this.radPivotGrid1_PrintElementPaint);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.White;
            this.radGroupBox1.Controls.Add(this.btnVista);
            this.radGroupBox1.Controls.Add(this.btnbuscar);
            this.radGroupBox1.Controls.Add(this.dtpFechafin);
            this.radGroupBox1.Controls.Add(this.dtpFechaini);
            this.radGroupBox1.Controls.Add(this.rbtRangoFechas);
            this.radGroupBox1.Controls.Add(this.rbtHistorico);
            this.radGroupBox1.Controls.Add(this.rbtMensual);
            this.radGroupBox1.Controls.Add(this.rbtAnual);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1159, 30);
            this.radGroupBox1.TabIndex = 2;
            // 
            // btnVista
            // 
            this.btnVista.Location = new System.Drawing.Point(601, 3);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(110, 24);
            this.btnVista.TabIndex = 7;
            this.btnVista.Text = "Vista Previa";
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(506, 3);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(66, 23);
            this.btnbuscar.TabIndex = 6;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // dtpFechafin
            // 
            this.dtpFechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechafin.Location = new System.Drawing.Point(394, 3);
            this.dtpFechafin.Name = "dtpFechafin";
            this.dtpFechafin.Size = new System.Drawing.Size(89, 20);
            this.dtpFechafin.TabIndex = 5;
            this.dtpFechafin.TabStop = false;
            this.dtpFechafin.Text = "28/04/2015";
            this.dtpFechafin.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // dtpFechaini
            // 
            this.dtpFechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaini.Location = new System.Drawing.Point(299, 3);
            this.dtpFechaini.Name = "dtpFechaini";
            this.dtpFechaini.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaini.TabIndex = 4;
            this.dtpFechaini.TabStop = false;
            this.dtpFechaini.Text = "28/04/2015";
            this.dtpFechaini.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // rbtRangoFechas
            // 
            this.rbtRangoFechas.Location = new System.Drawing.Point(204, 3);
            this.rbtRangoFechas.Name = "rbtRangoFechas";
            this.rbtRangoFechas.Size = new System.Drawing.Size(89, 18);
            this.rbtRangoFechas.TabIndex = 3;
            this.rbtRangoFechas.TabStop = false;
            this.rbtRangoFechas.Text = "Rango Fechas";
            // 
            // rbtHistorico
            // 
            this.rbtHistorico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtHistorico.Location = new System.Drawing.Point(126, 3);
            this.rbtHistorico.Name = "rbtHistorico";
            this.rbtHistorico.Size = new System.Drawing.Size(65, 18);
            this.rbtHistorico.TabIndex = 2;
            this.rbtHistorico.Text = "Historico";
            this.rbtHistorico.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rbtMensual
            // 
            this.rbtMensual.Location = new System.Drawing.Point(21, 3);
            this.rbtMensual.Name = "rbtMensual";
            this.rbtMensual.Size = new System.Drawing.Size(41, 18);
            this.rbtMensual.TabIndex = 1;
            this.rbtMensual.TabStop = false;
            this.rbtMensual.Text = "Mes";
            // 
            // rbtAnual
            // 
            this.rbtAnual.Location = new System.Drawing.Point(71, 3);
            this.rbtAnual.Name = "rbtAnual";
            this.rbtAnual.Size = new System.Drawing.Size(49, 18);
            this.rbtAnual.TabIndex = 0;
            this.rbtAnual.TabStop = false;
            this.rbtAnual.Text = "Anual";
            // 
            // radChartView1
            // 
            this.radChartView1.AreaDesign = cartesianArea1;
            this.radChartView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radChartView1.Location = new System.Drawing.Point(0, 30);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.ShowGrid = false;
            this.radChartView1.Size = new System.Drawing.Size(1159, 297);
            this.radChartView1.TabIndex = 0;
            this.radChartView1.Text = "radChartView1";
            // 
            // frmGraficoMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 471);
            this.Controls.Add(this.radPivotGrid1);
            this.Controls.Add(this.radChartView1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmGraficoMovimiento";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmGraficoMovimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnbuscar;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechafin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaini;
        private Telerik.WinControls.UI.RadRadioButton rbtRangoFechas;
        private Telerik.WinControls.UI.RadRadioButton rbtHistorico;
        private Telerik.WinControls.UI.RadRadioButton rbtMensual;
        private Telerik.WinControls.UI.RadRadioButton rbtAnual;
        private Telerik.WinControls.UI.RadChartView radChartView1;
        private Telerik.WinControls.UI.RadButton btnVista;



    }
}
