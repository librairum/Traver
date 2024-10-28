namespace Prod.UI.Win
{
    partial class FrmRepRendimiento
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
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboLineas = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnRefrescar = new Telerik.WinControls.UI.RadButton();
            this.cboperiodosfin = new Telerik.WinControls.UI.RadDropDownList();
            this.rbFecha = new Telerik.WinControls.UI.RadRadioButton();
            this.rbPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpfechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.cboperiodosini = new Telerik.WinControls.UI.RadDropDownList();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbtValidaCanastillas = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtGraficoRendimiento = new Telerik.WinControls.UI.RadRadioButton();
            this.rbRendimientoxColorAncho = new Telerik.WinControls.UI.RadRadioButton();
            this.rbRendimientoxAncho = new Telerik.WinControls.UI.RadRadioButton();
            this.rbRendimientoxColor = new Telerik.WinControls.UI.RadRadioButton();
            this.rbReporteGeneral = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtValidaCanastillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtGraficoRendimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRendimientoxColorAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRendimientoxAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRendimientoxColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbReporteGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Size = new System.Drawing.Size(1171, 32);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.cboLineas);
            this.radGroupBox3.HeaderText = "Linea";
            this.radGroupBox3.Location = new System.Drawing.Point(17, 8);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(222, 43);
            this.radGroupBox3.TabIndex = 6;
            this.radGroupBox3.Text = "Linea";
            // 
            // cboLineas
            // 
            this.cboLineas.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboLineas.Location = new System.Drawing.Point(15, 18);
            this.cboLineas.Name = "cboLineas";
            this.cboLineas.Size = new System.Drawing.Size(202, 20);
            this.cboLineas.TabIndex = 11;
            this.cboLineas.Text = "radDropDownList1";
            this.cboLineas.SelectedValueChanged += new System.EventHandler(this.cboLineas_SelectedValueChanged);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnRefrescar);
            this.radGroupBox1.Controls.Add(this.cboperiodosfin);
            this.radGroupBox1.Controls.Add(this.rbFecha);
            this.radGroupBox1.Controls.Add(this.rbPeriodo);
            this.radGroupBox1.Controls.Add(this.dtpFechaFin);
            this.radGroupBox1.Controls.Add(this.dtpfechaIni);
            this.radGroupBox1.Controls.Add(this.cboperiodosini);
            this.radGroupBox1.HeaderText = "Opcion de fecha";
            this.radGroupBox1.Location = new System.Drawing.Point(22, 57);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(217, 145);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Opcion de fecha";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(115, 116);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(87, 25);
            this.btnRefrescar.TabIndex = 13;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // cboperiodosfin
            // 
            this.cboperiodosfin.Location = new System.Drawing.Point(118, 43);
            this.cboperiodosfin.Name = "cboperiodosfin";
            this.cboperiodosfin.Size = new System.Drawing.Size(91, 20);
            this.cboperiodosfin.TabIndex = 12;
            this.cboperiodosfin.Text = "radDropDownList1";
            // 
            // rbFecha
            // 
            this.rbFecha.Location = new System.Drawing.Point(28, 72);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(84, 18);
            this.rbFecha.TabIndex = 11;
            this.rbFecha.Text = "Fecha rango:";
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.Location = new System.Drawing.Point(28, 21);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(59, 18);
            this.rbPeriodo.TabIndex = 10;
            this.rbPeriodo.Text = "Periodo";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(118, 94);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaFin.TabIndex = 8;
            this.dtpFechaFin.TabStop = false;
            this.dtpFechaFin.Text = "28/04/2015";
            this.dtpFechaFin.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // dtpfechaIni
            // 
            this.dtpfechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaIni.Location = new System.Drawing.Point(118, 70);
            this.dtpfechaIni.Name = "dtpfechaIni";
            this.dtpfechaIni.Size = new System.Drawing.Size(89, 20);
            this.dtpfechaIni.TabIndex = 6;
            this.dtpfechaIni.TabStop = false;
            this.dtpfechaIni.Text = "28/04/2015";
            this.dtpfechaIni.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // cboperiodosini
            // 
            this.cboperiodosini.Location = new System.Drawing.Point(118, 21);
            this.cboperiodosini.Name = "cboperiodosini";
            this.cboperiodosini.Size = new System.Drawing.Size(91, 20);
            this.cboperiodosini.TabIndex = 0;
            this.cboperiodosini.Text = "radDropDownList1";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(294, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.MultiSelect = true;
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(877, 454);
            this.gridControl.TabIndex = 7;
            this.gridControl.Text = "radGridView1";
            this.gridControl.ContextMenuOpening += new Telerik.WinControls.UI.ContextMenuOpeningEventHandler(this.gridControl_ContextMenuOpening);
            this.gridControl.FilterChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(this.gridControl_FilterChanging);
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbtValidaCanastillas);
            this.radGroupBox2.Controls.Add(this.rbtGraficoRendimiento);
            this.radGroupBox2.Controls.Add(this.rbRendimientoxColorAncho);
            this.radGroupBox2.Controls.Add(this.rbRendimientoxAncho);
            this.radGroupBox2.Controls.Add(this.rbRendimientoxColor);
            this.radGroupBox2.Controls.Add(this.rbReporteGeneral);
            this.radGroupBox2.HeaderText = "Opcion datos";
            this.radGroupBox2.Location = new System.Drawing.Point(22, 208);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(217, 118);
            this.radGroupBox2.TabIndex = 8;
            this.radGroupBox2.Text = "Opcion datos";
            // 
            // rbtValidaCanastillas
            // 
            this.rbtValidaCanastillas.Location = new System.Drawing.Point(17, 154);
            this.rbtValidaCanastillas.Name = "rbtValidaCanastillas";
            this.rbtValidaCanastillas.Size = new System.Drawing.Size(143, 18);
            this.rbtValidaCanastillas.TabIndex = 20;
            this.rbtValidaCanastillas.Text = "Validacion Canastillas PP";
            // 
            // rbtGraficoRendimiento
            // 
            this.rbtGraficoRendimiento.Location = new System.Drawing.Point(15, 129);
            this.rbtGraficoRendimiento.Name = "rbtGraficoRendimiento";
            this.rbtGraficoRendimiento.Size = new System.Drawing.Size(56, 18);
            this.rbtGraficoRendimiento.TabIndex = 19;
            this.rbtGraficoRendimiento.Text = "Grafico";
            // 
            // rbRendimientoxColorAncho
            // 
            this.rbRendimientoxColorAncho.Location = new System.Drawing.Point(15, 93);
            this.rbRendimientoxColorAncho.Name = "rbRendimientoxColorAncho";
            this.rbRendimientoxColorAncho.Size = new System.Drawing.Size(175, 18);
            this.rbRendimientoxColorAncho.TabIndex = 18;
            this.rbRendimientoxColorAncho.Text = "Rendimiento por color y ancho";
            // 
            // rbRendimientoxAncho
            // 
            this.rbRendimientoxAncho.Location = new System.Drawing.Point(15, 69);
            this.rbRendimientoxAncho.Name = "rbRendimientoxAncho";
            this.rbRendimientoxAncho.Size = new System.Drawing.Size(138, 18);
            this.rbRendimientoxAncho.TabIndex = 17;
            this.rbRendimientoxAncho.Text = "Rendimiento por ancho";
            // 
            // rbRendimientoxColor
            // 
            this.rbRendimientoxColor.Location = new System.Drawing.Point(17, 45);
            this.rbRendimientoxColor.Name = "rbRendimientoxColor";
            this.rbRendimientoxColor.Size = new System.Drawing.Size(133, 18);
            this.rbRendimientoxColor.TabIndex = 16;
            this.rbRendimientoxColor.Text = "Rendimiento por color";
            // 
            // rbReporteGeneral
            // 
            this.rbReporteGeneral.Location = new System.Drawing.Point(17, 21);
            this.rbReporteGeneral.Name = "rbReporteGeneral";
            this.rbReporteGeneral.Size = new System.Drawing.Size(125, 18);
            this.rbReporteGeneral.TabIndex = 15;
            this.rbReporteGeneral.Text = "Rendimiento general";
            this.rbReporteGeneral.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbReporteGeneral_ToggleStateChanged);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radGroupBox3);
            this.radPanel2.Controls.Add(this.radGroupBox2);
            this.radPanel2.Controls.Add(this.radGroupBox1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(294, 454);
            this.radPanel2.TabIndex = 9;
            // 
            // FrmRepRendimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 487);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmRepRendimiento";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte de rendimiento";
            this.Controls.SetChildIndex(this.radPanel2, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtValidaCanastillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtGraficoRendimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRendimientoxColorAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRendimientoxAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRendimientoxColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbReporteGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadDropDownList cboLineas;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosfin;
        private Telerik.WinControls.UI.RadRadioButton rbFecha;
        private Telerik.WinControls.UI.RadRadioButton rbPeriodo;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpfechaIni;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosini;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rbReporteGeneral;
        private Telerik.WinControls.UI.RadRadioButton rbRendimientoxColorAncho;
        private Telerik.WinControls.UI.RadRadioButton rbRendimientoxAncho;
        private Telerik.WinControls.UI.RadRadioButton rbRendimientoxColor;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnRefrescar;
        private Telerik.WinControls.UI.RadRadioButton rbtValidaCanastillas;
        private Telerik.WinControls.UI.RadRadioButton rbtGraficoRendimiento;
    }
}
