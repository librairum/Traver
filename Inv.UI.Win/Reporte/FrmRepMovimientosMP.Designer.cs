namespace Inv.UI.Win
{
    partial class FrmRepMovimientosMP
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtpFechafin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnbuscar = new Telerik.WinControls.UI.RadButton();
            this.rbtRangoFechas = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtHistorico = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtAnual = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtMensual = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.dtpFechafin);
            this.radGroupBox1.Controls.Add(this.dtpFechaini);
            this.radGroupBox1.Controls.Add(this.btnbuscar);
            this.radGroupBox1.Controls.Add(this.rbtRangoFechas);
            this.radGroupBox1.Controls.Add(this.rbtHistorico);
            this.radGroupBox1.Controls.Add(this.rbtAnual);
            this.radGroupBox1.Controls.Add(this.rbtMensual);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1000, 67);
            this.radGroupBox1.TabIndex = 4;
            // 
            // dtpFechafin
            // 
            this.dtpFechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechafin.Location = new System.Drawing.Point(218, 31);
            this.dtpFechafin.Name = "dtpFechafin";
            this.dtpFechafin.Size = new System.Drawing.Size(79, 20);
            this.dtpFechafin.TabIndex = 8;
            this.dtpFechafin.TabStop = false;
            this.dtpFechafin.Text = "17/05/2016";
            this.dtpFechafin.Value = new System.DateTime(2016, 5, 17, 17, 20, 47, 40);
            // 
            // dtpFechaini
            // 
            this.dtpFechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaini.Location = new System.Drawing.Point(218, 5);
            this.dtpFechaini.Name = "dtpFechaini";
            this.dtpFechaini.Size = new System.Drawing.Size(79, 20);
            this.dtpFechaini.TabIndex = 7;
            this.dtpFechaini.TabStop = false;
            this.dtpFechaini.Text = "17/05/2016";
            this.dtpFechaini.Value = new System.DateTime(2016, 5, 17, 17, 20, 47, 40);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(303, 6);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(65, 22);
            this.btnbuscar.TabIndex = 6;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // rbtRangoFechas
            // 
            this.rbtRangoFechas.Location = new System.Drawing.Point(107, 7);
            this.rbtRangoFechas.Name = "rbtRangoFechas";
            this.rbtRangoFechas.Size = new System.Drawing.Size(92, 18);
            this.rbtRangoFechas.TabIndex = 3;
            this.rbtRangoFechas.Text = "Rango Fechas ";
            // 
            // rbtHistorico
            // 
            this.rbtHistorico.Location = new System.Drawing.Point(23, 43);
            this.rbtHistorico.Name = "rbtHistorico";
            this.rbtHistorico.Size = new System.Drawing.Size(65, 18);
            this.rbtHistorico.TabIndex = 2;
            this.rbtHistorico.Text = "Historico";
            // 
            // rbtAnual
            // 
            this.rbtAnual.Location = new System.Drawing.Point(23, 24);
            this.rbtAnual.Name = "rbtAnual";
            this.rbtAnual.Size = new System.Drawing.Size(49, 18);
            this.rbtAnual.TabIndex = 1;
            this.rbtAnual.Text = "Anual";
            // 
            // rbtMensual
            // 
            this.rbtMensual.Location = new System.Drawing.Point(23, 7);
            this.rbtMensual.Name = "rbtMensual";
            this.rbtMensual.Size = new System.Drawing.Size(41, 18);
            this.rbtMensual.TabIndex = 0;
            this.rbtMensual.Text = "Mes";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridControl);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 100);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1000, 396);
            this.radPanel2.TabIndex = 5;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1000, 396);
            this.gridControl.TabIndex = 0;
            this.gridControl.Text = "radGridView1";
            // 
            // FrmRepMovimientosMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 496);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "FrmRepMovimientosMP";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Movimientos Materia Prima";
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadRadioButton rbtMensual;
        private Telerik.WinControls.UI.RadRadioButton rbtHistorico;
        private Telerik.WinControls.UI.RadRadioButton rbtAnual;
        private Telerik.WinControls.UI.RadRadioButton rbtRangoFechas;
        private Telerik.WinControls.UI.RadButton btnbuscar;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaini;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechafin;
    }
}
