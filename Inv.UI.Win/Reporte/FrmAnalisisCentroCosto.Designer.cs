namespace Inv.UI.Win
{
    partial class FrmAnalisisCentroCosto 
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
            this.rbResumida = new Telerik.WinControls.UI.RadRadioButton();
            this.rbDetallada = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpfechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.cboperiodos = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.rbPorFechas = new Telerik.WinControls.UI.RadRadioButton();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbResumida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPorFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.rbResumida);
            this.radGroupBox1.Controls.Add(this.rbDetallada);
            this.radGroupBox1.HeaderText = "Tipos de Reportes";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 39);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(217, 74);
            this.radGroupBox1.TabIndex = 6;
            this.radGroupBox1.Text = "Tipos de Reportes";
            // 
            // rbResumida
            // 
            this.rbResumida.Location = new System.Drawing.Point(28, 45);
            this.rbResumida.Name = "rbResumida";
            this.rbResumida.Size = new System.Drawing.Size(69, 18);
            this.rbResumida.TabIndex = 11;
            this.rbResumida.Text = "Resumida";
            // 
            // rbDetallada
            // 
            this.rbDetallada.Location = new System.Drawing.Point(28, 21);
            this.rbDetallada.Name = "rbDetallada";
            this.rbDetallada.Size = new System.Drawing.Size(67, 18);
            this.rbDetallada.TabIndex = 10;
            this.rbDetallada.Text = "Detallada";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(83, 135);
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
            this.dtpfechaIni.Location = new System.Drawing.Point(83, 110);
            this.dtpfechaIni.Name = "dtpfechaIni";
            this.dtpfechaIni.Size = new System.Drawing.Size(89, 20);
            this.dtpfechaIni.TabIndex = 6;
            this.dtpfechaIni.TabStop = false;
            this.dtpfechaIni.Text = "28/04/2015";
            this.dtpfechaIni.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // cboperiodos
            // 
            this.cboperiodos.Location = new System.Drawing.Point(17, 50);
            this.cboperiodos.Name = "cboperiodos";
            this.cboperiodos.Size = new System.Drawing.Size(155, 20);
            this.cboperiodos.TabIndex = 0;
            this.cboperiodos.Text = "radDropDownList1";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.radLabel3);
            this.radGroupBox2.Controls.Add(this.label2);
            this.radGroupBox2.Controls.Add(this.rbPeriodo);
            this.radGroupBox2.Controls.Add(this.dtpFechaFin);
            this.radGroupBox2.Controls.Add(this.rbPorFechas);
            this.radGroupBox2.Controls.Add(this.dtpfechaIni);
            this.radGroupBox2.Controls.Add(this.cboperiodos);
            this.radGroupBox2.HeaderText = "Rango de Impresion";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 120);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(219, 176);
            this.radGroupBox2.TabIndex = 7;
            this.radGroupBox2.Text = "Rango de Impresion";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(7, 135);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 18);
            this.radLabel1.TabIndex = 36;
            this.radLabel1.Text = "Fecha Final";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(7, 110);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(67, 18);
            this.radLabel3.TabIndex = 35;
            this.radLabel3.Text = "Fecha Inicial";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(-3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 2);
            this.label2.TabIndex = 34;
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.Location = new System.Drawing.Point(17, 21);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(79, 18);
            this.rbPeriodo.TabIndex = 12;
            this.rbPeriodo.Text = "Por Periodo";
            // 
            // rbPorFechas
            // 
            this.rbPorFechas.Location = new System.Drawing.Point(7, 88);
            this.rbPorFechas.Name = "rbPorFechas";
            this.rbPorFechas.Size = new System.Drawing.Size(74, 18);
            this.rbPorFechas.TabIndex = 12;
            this.rbPorFechas.Text = "Por Fechas";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(249, 39);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.MultiSelect = true;
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(501, 257);
            this.gridControl.TabIndex = 8;
            this.gridControl.Text = "Ingreso por devolucion";
            // 
            // FrmAnalisisCentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 318);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAnalisisCentroCosto";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Analisis Centro Costo";
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.radGroupBox2, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbResumida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPorFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton rbResumida;
        private Telerik.WinControls.UI.RadRadioButton rbDetallada;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpfechaIni;
        private Telerik.WinControls.UI.RadDropDownList cboperiodos;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadRadioButton rbPeriodo;
        private Telerik.WinControls.UI.RadRadioButton rbPorFechas;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
