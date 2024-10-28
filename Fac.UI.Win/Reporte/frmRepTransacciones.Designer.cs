namespace Fac.UI.Win
{
    partial class frmRepTransacciones
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
            this.cboperiodosfin = new Telerik.WinControls.UI.RadDropDownList();
            this.rbFecha = new Telerik.WinControls.UI.RadRadioButton();
            this.rbPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpfechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.cboperiodosini = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbsalidasporventasguia = new Telerik.WinControls.UI.RadRadioButton();
            this.rbingresoxproduccion = new Telerik.WinControls.UI.RadRadioButton();
            this.rbsalidasporventas = new Telerik.WinControls.UI.RadRadioButton();
            this.rbDetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.rbResumido = new Telerik.WinControls.UI.RadRadioButton();
            this.gridcontrol = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbsalidasporventasguia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbingresoxproduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbsalidasporventas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbResumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.radGroupBox1.HeaderText = "Opcion de fecha";
            this.radGroupBox1.Location = new System.Drawing.Point(23, 21);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(217, 119);
            this.radGroupBox1.TabIndex = 0;
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
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbsalidasporventasguia);
            this.radGroupBox2.Controls.Add(this.rbingresoxproduccion);
            this.radGroupBox2.Controls.Add(this.rbsalidasporventas);
            this.radGroupBox2.Controls.Add(this.rbDetallado);
            this.radGroupBox2.Controls.Add(this.rbResumido);
            this.radGroupBox2.HeaderText = "Opcion datos";
            this.radGroupBox2.Location = new System.Drawing.Point(26, 146);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(217, 155);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Opcion datos";
            // 
            // rbsalidasporventasguia
            // 
            this.rbsalidasporventasguia.Location = new System.Drawing.Point(17, 67);
            this.rbsalidasporventasguia.Name = "rbsalidasporventasguia";
            this.rbsalidasporventasguia.Size = new System.Drawing.Size(152, 18);
            this.rbsalidasporventasguia.TabIndex = 17;
            this.rbsalidasporventasguia.Text = "Salidas por venta por Guia";
            // 
            // rbingresoxproduccion
            // 
            this.rbingresoxproduccion.Location = new System.Drawing.Point(17, 91);
            this.rbingresoxproduccion.Name = "rbingresoxproduccion";
            this.rbingresoxproduccion.Size = new System.Drawing.Size(137, 18);
            this.rbingresoxproduccion.TabIndex = 16;
            this.rbingresoxproduccion.Text = "Ingreso por Produccion";
            // 
            // rbsalidasporventas
            // 
            this.rbsalidasporventas.Location = new System.Drawing.Point(17, 43);
            this.rbsalidasporventas.Name = "rbsalidasporventas";
            this.rbsalidasporventas.Size = new System.Drawing.Size(105, 18);
            this.rbsalidasporventas.TabIndex = 15;
            this.rbsalidasporventas.Text = "Salidas por venta";
            // 
            // rbDetallado
            // 
            this.rbDetallado.Location = new System.Drawing.Point(118, 21);
            this.rbDetallado.Name = "rbDetallado";
            this.rbDetallado.Size = new System.Drawing.Size(68, 18);
            this.rbDetallado.TabIndex = 13;
            this.rbDetallado.Text = "Detallado";
            // 
            // rbResumido
            // 
            this.rbResumido.Location = new System.Drawing.Point(17, 21);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(70, 18);
            this.rbResumido.TabIndex = 12;
            this.rbResumido.Text = "Resumido";
            // 
            // gridcontrol
            // 
            this.gridcontrol.Location = new System.Drawing.Point(328, 21);
            // 
            // 
            // 
            this.gridcontrol.MasterTemplate.MultiSelect = true;
            this.gridcontrol.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridcontrol.Name = "gridcontrol";
            this.gridcontrol.Size = new System.Drawing.Size(435, 306);
            this.gridcontrol.TabIndex = 2;
            this.gridcontrol.Text = "radGridView1";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radGroupBox1);
            this.radPanel1.Controls.Add(this.gridcontrol);
            this.radPanel1.Controls.Add(this.radGroupBox2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 33);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(878, 444);
            this.radPanel1.TabIndex = 3;
            this.radPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.radPanel1_Paint);
            // 
            // frmRepTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 477);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmRepTransacciones";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte transacciones";
            this.Load += new System.EventHandler(this.frmRepTransacciones_Load);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbsalidasporventasguia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbingresoxproduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbsalidasporventas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbResumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosini;
        private Telerik.WinControls.UI.RadDateTimePicker dtpfechaIni;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadRadioButton rbPeriodo;
        private Telerik.WinControls.UI.RadRadioButton rbFecha;
        private Telerik.WinControls.UI.RadRadioButton rbDetallado;
        private Telerik.WinControls.UI.RadRadioButton rbResumido;
        private Telerik.WinControls.UI.RadGridView gridcontrol;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosfin;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadRadioButton rbingresoxproduccion;
        private Telerik.WinControls.UI.RadRadioButton rbsalidasporventas;
        private Telerik.WinControls.UI.RadRadioButton rbsalidasporventasguia;
    }
}
