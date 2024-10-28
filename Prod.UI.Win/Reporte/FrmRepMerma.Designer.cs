namespace Prod.UI.Win
{
    partial class FrmRepMerma
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
            this.rgbOpcionFecha = new Telerik.WinControls.UI.RadGroupBox();
            this.rbFecha = new Telerik.WinControls.UI.RadRadioButton();
            this.cboperiodosfin = new Telerik.WinControls.UI.RadDropDownList();
            this.rbPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.cboperiodosini = new Telerik.WinControls.UI.RadDropDownList();
            this.dtpFechafin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rbtrendiymerma = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.rbtrendiymerma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.Color.White;
            this.toolBar.Size = new System.Drawing.Size(732, 33);
            // 
            // rgbOpcionFecha
            // 
            this.rgbOpcionFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rgbOpcionFecha.BackColor = System.Drawing.Color.White;
            this.rgbOpcionFecha.Controls.Add(this.radPanel2);
            this.rgbOpcionFecha.Controls.Add(this.rbFecha);
            this.rgbOpcionFecha.Controls.Add(this.cboperiodosfin);
            this.rgbOpcionFecha.Controls.Add(this.rbPeriodo);
            this.rgbOpcionFecha.Controls.Add(this.cboperiodosini);
            this.rgbOpcionFecha.Controls.Add(this.dtpFechafin);
            this.rgbOpcionFecha.Controls.Add(this.dtpFechaini);
            this.rgbOpcionFecha.Controls.Add(this.radLabel2);
            this.rgbOpcionFecha.Dock = System.Windows.Forms.DockStyle.Left;
            this.rgbOpcionFecha.HeaderText = "Opciones de fecha";
            this.rgbOpcionFecha.Location = new System.Drawing.Point(0, 33);
            this.rgbOpcionFecha.Name = "rgbOpcionFecha";
            this.rgbOpcionFecha.Size = new System.Drawing.Size(224, 469);
            this.rgbOpcionFecha.TabIndex = 8;
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
            this.gridControl.Location = new System.Drawing.Point(224, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(508, 469);
            this.gridControl.TabIndex = 9;
            this.gridControl.Text = "radGridView1";
            // 
            // rbtrendiymerma
            // 
            this.rbtrendiymerma.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtrendiymerma.Location = new System.Drawing.Point(14, 12);
            this.rbtrendiymerma.Name = "rbtrendiymerma";
            this.rbtrendiymerma.Size = new System.Drawing.Size(169, 18);
            this.rbtrendiymerma.TabIndex = 17;
            this.rbtrendiymerma.Text = "Rendimiento y Merma Bloque";
            this.rbtrendiymerma.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.rbtrendiymerma);
            this.radPanel2.Location = new System.Drawing.Point(13, 219);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(200, 100);
            this.radPanel2.TabIndex = 18;
            // 
            // FrmRepMerma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 502);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.rgbOpcionFecha);
            this.Name = "FrmRepMerma";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte de merma";
            this.Controls.SetChildIndex(this.rgbOpcionFecha, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.rbtrendiymerma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox rgbOpcionFecha;
        private Telerik.WinControls.UI.RadRadioButton rbFecha;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosfin;
        private Telerik.WinControls.UI.RadRadioButton rbPeriodo;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosini;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechafin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaini;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadRadioButton rbtrendiymerma;
    }
}
