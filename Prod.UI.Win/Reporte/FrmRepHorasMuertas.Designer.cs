namespace Prod.UI.Win
{
    partial class FrmRepHorasMuertas
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rpControlOpciones = new Telerik.WinControls.UI.RadPanel();
            this.RgbTipoReporte = new Telerik.WinControls.UI.RadGroupBox();
            this.RbtDiario = new Telerik.WinControls.UI.RadRadioButton();
            this.RbtMensual = new Telerik.WinControls.UI.RadRadioButton();
            this.rgbOpciones = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboLineas = new Telerik.WinControls.UI.RadDropDownList();
            this.rgbOpcionFecha = new Telerik.WinControls.UI.RadGroupBox();
            this.rbFecha = new Telerik.WinControls.UI.RadRadioButton();
            this.cboperiodosfin = new Telerik.WinControls.UI.RadDropDownList();
            this.rbPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.cboperiodosini = new Telerik.WinControls.UI.RadDropDownList();
            this.dtpFechafin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpControlOpciones)).BeginInit();
            this.rpControlOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RgbTipoReporte)).BeginInit();
            this.RgbTipoReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RbtDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RbtMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbOpciones)).BeginInit();
            this.rgbOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbOpcionFecha)).BeginInit();
            this.rgbOpcionFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Size = new System.Drawing.Size(674, 33);
            // 
            // rpControlOpciones
            // 
            this.rpControlOpciones.BackColor = System.Drawing.Color.White;
            this.rpControlOpciones.Controls.Add(this.RgbTipoReporte);
            this.rpControlOpciones.Controls.Add(this.rgbOpciones);
            this.rpControlOpciones.Controls.Add(this.rgbOpcionFecha);
            this.rpControlOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpControlOpciones.Location = new System.Drawing.Point(0, 33);
            this.rpControlOpciones.Name = "rpControlOpciones";
            this.rpControlOpciones.Size = new System.Drawing.Size(230, 389);
            this.rpControlOpciones.TabIndex = 9;
            this.rpControlOpciones.ThemeName = "Office2013Light";
            // 
            // RgbTipoReporte
            // 
            this.RgbTipoReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.RgbTipoReporte.Controls.Add(this.RbtDiario);
            this.RgbTipoReporte.Controls.Add(this.RbtMensual);
            this.RgbTipoReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.RgbTipoReporte.HeaderText = "Tipo Reporte";
            this.RgbTipoReporte.Location = new System.Drawing.Point(0, 0);
            this.RgbTipoReporte.Name = "RgbTipoReporte";
            this.RgbTipoReporte.Size = new System.Drawing.Size(230, 76);
            this.RgbTipoReporte.TabIndex = 8;
            this.RgbTipoReporte.Text = "Tipo Reporte";
            // 
            // RbtDiario
            // 
            this.RbtDiario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RbtDiario.Location = new System.Drawing.Point(6, 22);
            this.RbtDiario.Name = "RbtDiario";
            this.RbtDiario.Size = new System.Drawing.Size(90, 18);
            this.RbtDiario.TabIndex = 1;
            this.RbtDiario.Text = "Analisis Diario";
            this.RbtDiario.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // RbtMensual
            // 
            this.RbtMensual.Location = new System.Drawing.Point(6, 46);
            this.RbtMensual.Name = "RbtMensual";
            this.RbtMensual.Size = new System.Drawing.Size(103, 18);
            this.RbtMensual.TabIndex = 0;
            this.RbtMensual.TabStop = false;
            this.RbtMensual.Text = "Analisis Mensual";
            // 
            // rgbOpciones
            // 
            this.rgbOpciones.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rgbOpciones.Controls.Add(this.radLabel1);
            this.rgbOpciones.Controls.Add(this.cboLineas);
            this.rgbOpciones.HeaderText = "Opciones";
            this.rgbOpciones.Location = new System.Drawing.Point(3, 261);
            this.rgbOpciones.Name = "rgbOpciones";
            this.rgbOpciones.Size = new System.Drawing.Size(224, 52);
            this.rgbOpciones.TabIndex = 5;
            this.rgbOpciones.Text = "Opciones";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 21);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(32, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Linea";
            // 
            // cboLineas
            // 
            this.cboLineas.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboLineas.Location = new System.Drawing.Point(112, 21);
            this.cboLineas.Name = "cboLineas";
            this.cboLineas.Size = new System.Drawing.Size(103, 20);
            this.cboLineas.TabIndex = 0;
            this.cboLineas.SelectedValueChanged += new System.EventHandler(this.cboLineas_SelectedValueChanged);
            // 
            // rgbOpcionFecha
            // 
            this.rgbOpcionFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rgbOpcionFecha.Controls.Add(this.rbFecha);
            this.rgbOpcionFecha.Controls.Add(this.cboperiodosfin);
            this.rgbOpcionFecha.Controls.Add(this.rbPeriodo);
            this.rgbOpcionFecha.Controls.Add(this.cboperiodosini);
            this.rgbOpcionFecha.Controls.Add(this.dtpFechafin);
            this.rgbOpcionFecha.Controls.Add(this.dtpFechaini);
            this.rgbOpcionFecha.Controls.Add(this.radLabel2);
            this.rgbOpcionFecha.HeaderText = "Opciones de fecha";
            this.rgbOpcionFecha.Location = new System.Drawing.Point(3, 85);
            this.rgbOpcionFecha.Name = "rgbOpcionFecha";
            this.rgbOpcionFecha.Size = new System.Drawing.Size(224, 170);
            this.rgbOpcionFecha.TabIndex = 7;
            this.rgbOpcionFecha.Text = "Opciones de fecha";
            // 
            // rbFecha
            // 
            this.rbFecha.Location = new System.Drawing.Point(12, 49);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(84, 18);
            this.rbFecha.TabIndex = 16;
            this.rbFecha.Text = "Fecha rango:";
            // 
            // cboperiodosfin
            // 
            this.cboperiodosfin.Location = new System.Drawing.Point(112, 140);
            this.cboperiodosfin.Name = "cboperiodosfin";
            this.cboperiodosfin.Size = new System.Drawing.Size(91, 20);
            this.cboperiodosfin.TabIndex = 15;
            this.cboperiodosfin.Text = "radDropDownList1";
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.Location = new System.Drawing.Point(12, 118);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(59, 18);
            this.rbPeriodo.TabIndex = 14;
            this.rbPeriodo.Text = "Periodo";
            // 
            // cboperiodosini
            // 
            this.cboperiodosini.Location = new System.Drawing.Point(112, 118);
            this.cboperiodosini.Name = "cboperiodosini";
            this.cboperiodosini.Size = new System.Drawing.Size(91, 20);
            this.cboperiodosini.TabIndex = 13;
            this.cboperiodosini.Text = "radDropDownList1";
            // 
            // dtpFechafin
            // 
            this.dtpFechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechafin.Location = new System.Drawing.Point(112, 75);
            this.dtpFechafin.Name = "dtpFechafin";
            this.dtpFechafin.Size = new System.Drawing.Size(91, 20);
            this.dtpFechafin.TabIndex = 2;
            this.dtpFechafin.TabStop = false;
            this.dtpFechafin.Text = "26/07/2016";
            this.dtpFechafin.Value = new System.DateTime(2016, 7, 26, 12, 53, 26, 590);
            // 
            // dtpFechaini
            // 
            this.dtpFechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaini.Location = new System.Drawing.Point(112, 49);
            this.dtpFechaini.Name = "dtpFechaini";
            this.dtpFechaini.Size = new System.Drawing.Size(91, 20);
            this.dtpFechaini.TabIndex = 1;
            this.dtpFechaini.TabStop = false;
            this.dtpFechaini.Text = "26/07/2016";
            this.dtpFechaini.Value = new System.DateTime(2016, 7, 26, 12, 53, 26, 590);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 21);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(94, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Rango de fechas :";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(230, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(444, 389);
            this.gridControl.TabIndex = 10;
            this.gridControl.Text = "radGridView1";
            // 
            // FrmRepHorasMuertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 422);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.rpControlOpciones);
            this.Name = "FrmRepHorasMuertas";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte por horas Muertas";
            this.ThemeName = "ControlDefault";
            this.Controls.SetChildIndex(this.rpControlOpciones, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpControlOpciones)).EndInit();
            this.rpControlOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RgbTipoReporte)).EndInit();
            this.RgbTipoReporte.ResumeLayout(false);
            this.RgbTipoReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RbtDiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RbtMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbOpciones)).EndInit();
            this.rgbOpciones.ResumeLayout(false);
            this.rgbOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgbOpcionFecha)).EndInit();
            this.rgbOpcionFecha.ResumeLayout(false);
            this.rgbOpcionFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpControlOpciones;
        private Telerik.WinControls.UI.RadGroupBox RgbTipoReporte;
        private Telerik.WinControls.UI.RadRadioButton RbtDiario;
        private Telerik.WinControls.UI.RadRadioButton RbtMensual;
        private Telerik.WinControls.UI.RadGroupBox rgbOpciones;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboLineas;
        private Telerik.WinControls.UI.RadGroupBox rgbOpcionFecha;
        private Telerik.WinControls.UI.RadRadioButton rbFecha;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosfin;
        private Telerik.WinControls.UI.RadRadioButton rbPeriodo;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosini;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechafin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaini;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGridView gridControl;
    }
}
