namespace Prod.UI.Win
{
    partial class FrmRepErroresComunes
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
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbDetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.rbResumido = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboperiodosfin = new Telerik.WinControls.UI.RadDropDownList();
            this.rbFecha = new Telerik.WinControls.UI.RadRadioButton();
            this.rbPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpfechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.cboperiodosini = new Telerik.WinControls.UI.RadDropDownList();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbResumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Size = new System.Drawing.Size(683, 32);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radGroupBox2);
            this.radPanel2.Controls.Add(this.radGroupBox1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(294, 400);
            this.radPanel2.TabIndex = 10;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbDetallado);
            this.radGroupBox2.Controls.Add(this.rbResumido);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox2.HeaderText = "Opciones tipo";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 124);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(294, 85);
            this.radGroupBox2.TabIndex = 6;
            this.radGroupBox2.Text = "Opciones tipo";
            // 
            // rbDetallado
            // 
            this.rbDetallado.Location = new System.Drawing.Point(28, 55);
            this.rbDetallado.Name = "rbDetallado";
            this.rbDetallado.Size = new System.Drawing.Size(68, 18);
            this.rbDetallado.TabIndex = 12;
            this.rbDetallado.TabStop = false;
            this.rbDetallado.Text = "Detallado";
            // 
            // rbResumido
            // 
            this.rbResumido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbResumido.Location = new System.Drawing.Point(28, 31);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(70, 18);
            this.rbResumido.TabIndex = 11;
            this.rbResumido.Text = "Resumido";
            this.rbResumido.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cboperiodosfin);
            this.radGroupBox1.Controls.Add(this.rbFecha);
            this.radGroupBox1.Controls.Add(this.rbPeriodo);
            this.radGroupBox1.Controls.Add(this.dtpFechaFin);
            this.radGroupBox1.Controls.Add(this.dtpfechaIni);
            this.radGroupBox1.Controls.Add(this.cboperiodosini);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "Opcion de fecha";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(294, 124);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Opcion de fecha";
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
            this.rbFecha.TabStop = false;
            this.rbFecha.Text = "Fecha rango:";
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbPeriodo.Location = new System.Drawing.Point(28, 21);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(59, 18);
            this.rbPeriodo.TabIndex = 10;
            this.rbPeriodo.Text = "Periodo";
            this.rbPeriodo.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
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
            this.gridControl.Size = new System.Drawing.Size(389, 400);
            this.gridControl.TabIndex = 11;
            // 
            // FrmRepErroresComunes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 433);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmRepErroresComunes";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Errores Comunes";
            this.Controls.SetChildIndex(this.radPanel2, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbResumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosfin;
        private Telerik.WinControls.UI.RadRadioButton rbFecha;
        private Telerik.WinControls.UI.RadRadioButton rbPeriodo;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpfechaIni;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosini;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rbDetallado;
        private Telerik.WinControls.UI.RadRadioButton rbResumido;
    }
}
