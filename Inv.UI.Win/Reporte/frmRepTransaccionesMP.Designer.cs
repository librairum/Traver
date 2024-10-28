namespace Inv.UI.Win
{
    partial class frmRepTransaccionesMP
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
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbtsalidaxlinea = new Telerik.WinControls.UI.RadRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.rbingresoxcompra = new Telerik.WinControls.UI.RadRadioButton();
            this.rbsalidasporproduccion = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtResumido = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpfechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.cboperiodosfin = new Telerik.WinControls.UI.RadDropDownList();
            this.cboperiodosini = new Telerik.WinControls.UI.RadDropDownList();
            this.rbtFecha = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.rbingresoxcompralima = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtsalidaxlinea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbingresoxcompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbsalidasporproduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtResumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbingresoxcompralima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radGroupBox3);
            this.radPanel2.Controls.Add(this.gridControl);
            this.radPanel2.Controls.Add(this.radGroupBox2);
            this.radPanel2.Controls.Add(this.radGroupBox1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(732, 352);
            this.radPanel2.TabIndex = 4;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.cboalmacenes);
            this.radGroupBox3.HeaderText = "Almacen";
            this.radGroupBox3.Location = new System.Drawing.Point(15, 6);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(222, 43);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "Almacen";
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboalmacenes.Location = new System.Drawing.Point(15, 18);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(202, 20);
            this.cboalmacenes.TabIndex = 11;
            this.cboalmacenes.Text = "radDropDownList1";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(243, 9);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(481, 329);
            this.gridControl.TabIndex = 2;
            this.gridControl.Text = "radGridView1";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbingresoxcompralima);
            this.radGroupBox2.Controls.Add(this.rbtsalidaxlinea);
            this.radGroupBox2.Controls.Add(this.label2);
            this.radGroupBox2.Controls.Add(this.rbDetallado);
            this.radGroupBox2.Controls.Add(this.rbingresoxcompra);
            this.radGroupBox2.Controls.Add(this.rbsalidasporproduccion);
            this.radGroupBox2.Controls.Add(this.rbtResumido);
            this.radGroupBox2.HeaderText = "Opcion datos";
            this.radGroupBox2.Location = new System.Drawing.Point(13, 189);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(222, 151);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Opcion datos";
            // 
            // rbtsalidaxlinea
            // 
            this.rbtsalidaxlinea.Location = new System.Drawing.Point(11, 100);
            this.rbtsalidaxlinea.Name = "rbtsalidaxlinea";
            this.rbtsalidaxlinea.Size = new System.Drawing.Size(153, 18);
            this.rbtsalidaxlinea.TabIndex = 34;
            this.rbtsalidaxlinea.Text = "Salida Producion Por Linea";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 2);
            this.label2.TabIndex = 33;
            // 
            // rbDetallado
            // 
            this.rbDetallado.Location = new System.Drawing.Point(118, 27);
            this.rbDetallado.Name = "rbDetallado";
            this.rbDetallado.Size = new System.Drawing.Size(68, 18);
            this.rbDetallado.TabIndex = 7;
            this.rbDetallado.TabStop = false;
            this.rbDetallado.Text = "Detallado";
            // 
            // rbingresoxcompra
            // 
            this.rbingresoxcompra.Location = new System.Drawing.Point(11, 75);
            this.rbingresoxcompra.Name = "rbingresoxcompra";
            this.rbingresoxcompra.Size = new System.Drawing.Size(120, 18);
            this.rbingresoxcompra.TabIndex = 5;
            this.rbingresoxcompra.TabStop = false;
            this.rbingresoxcompra.Text = "Ingreso Por Compra";
            // 
            // rbsalidasporproduccion
            // 
            this.rbsalidasporproduccion.Location = new System.Drawing.Point(11, 51);
            this.rbsalidasporproduccion.Name = "rbsalidasporproduccion";
            this.rbsalidasporproduccion.Size = new System.Drawing.Size(123, 18);
            this.rbsalidasporproduccion.TabIndex = 3;
            this.rbsalidasporproduccion.TabStop = false;
            this.rbsalidasporproduccion.Text = "Salidas a Produccion";
            // 
            // rbtResumido
            // 
            this.rbtResumido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtResumido.Location = new System.Drawing.Point(11, 27);
            this.rbtResumido.Name = "rbtResumido";
            this.rbtResumido.Size = new System.Drawing.Size(70, 18);
            this.rbtResumido.TabIndex = 2;
            this.rbtResumido.Text = "Resumido";
            this.rbtResumido.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.dtpFechaFin);
            this.radGroupBox1.Controls.Add(this.dtpfechaIni);
            this.radGroupBox1.Controls.Add(this.cboperiodosfin);
            this.radGroupBox1.Controls.Add(this.cboperiodosini);
            this.radGroupBox1.Controls.Add(this.rbtFecha);
            this.radGroupBox1.Controls.Add(this.rbtPeriodo);
            this.radGroupBox1.HeaderText = "Opciones de fecha";
            this.radGroupBox1.Location = new System.Drawing.Point(14, 55);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(222, 128);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Opciones de fecha";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(110, 100);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(87, 20);
            this.dtpFechaFin.TabIndex = 5;
            this.dtpFechaFin.TabStop = false;
            this.dtpFechaFin.Text = "17/05/2016";
            this.dtpFechaFin.Value = new System.DateTime(2016, 5, 17, 17, 29, 39, 423);
            // 
            // dtpfechaIni
            // 
            this.dtpfechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaIni.Location = new System.Drawing.Point(110, 77);
            this.dtpfechaIni.Name = "dtpfechaIni";
            this.dtpfechaIni.Size = new System.Drawing.Size(87, 20);
            this.dtpfechaIni.TabIndex = 4;
            this.dtpfechaIni.TabStop = false;
            this.dtpfechaIni.Text = "17/05/2016";
            this.dtpfechaIni.Value = new System.DateTime(2016, 5, 17, 17, 28, 59, 143);
            // 
            // cboperiodosfin
            // 
            this.cboperiodosfin.Location = new System.Drawing.Point(110, 48);
            this.cboperiodosfin.Name = "cboperiodosfin";
            this.cboperiodosfin.Size = new System.Drawing.Size(87, 20);
            this.cboperiodosfin.TabIndex = 3;
            this.cboperiodosfin.Text = "radDropDownList2";
            // 
            // cboperiodosini
            // 
            this.cboperiodosini.Location = new System.Drawing.Point(110, 25);
            this.cboperiodosini.Name = "cboperiodosini";
            this.cboperiodosini.Size = new System.Drawing.Size(87, 20);
            this.cboperiodosini.TabIndex = 2;
            this.cboperiodosini.Text = "radDropDownList1";
            // 
            // rbtFecha
            // 
            this.rbtFecha.Location = new System.Drawing.Point(20, 77);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(87, 18);
            this.rbtFecha.TabIndex = 1;
            this.rbtFecha.TabStop = false;
            this.rbtFecha.Text = "Fecha rango :";
            // 
            // rbtPeriodo
            // 
            this.rbtPeriodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtPeriodo.Location = new System.Drawing.Point(20, 27);
            this.rbtPeriodo.Name = "rbtPeriodo";
            this.rbtPeriodo.Size = new System.Drawing.Size(59, 18);
            this.rbtPeriodo.TabIndex = 0;
            this.rbtPeriodo.Text = "Periodo";
            this.rbtPeriodo.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rbingresoxcompralima
            // 
            this.rbingresoxcompralima.Location = new System.Drawing.Point(12, 122);
            this.rbingresoxcompralima.Name = "rbingresoxcompralima";
            this.rbingresoxcompralima.Size = new System.Drawing.Size(147, 18);
            this.rbingresoxcompralima.TabIndex = 35;
            this.rbingresoxcompralima.TabStop = false;
            this.rbingresoxcompralima.Text = "Ingreso Por Compra Lima";
            // 
            // frmRepTransaccionesMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 385);
            this.Controls.Add(this.radPanel2);
            this.Name = "frmRepTransaccionesMP";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte transacciones de Materia Prima";
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtsalidaxlinea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbingresoxcompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbsalidasporproduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtResumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbingresoxcompralima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton rbtPeriodo;
        private Telerik.WinControls.UI.RadRadioButton rbtFecha;
        private Telerik.WinControls.UI.RadDateTimePicker dtpfechaIni;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosfin;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosini;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadRadioButton rbDetallado;
        private Telerik.WinControls.UI.RadRadioButton rbingresoxcompra;
        private Telerik.WinControls.UI.RadRadioButton rbsalidasporproduccion;
        private Telerik.WinControls.UI.RadRadioButton rbtResumido;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadRadioButton rbtsalidaxlinea;
        private Telerik.WinControls.UI.RadRadioButton rbingresoxcompralima;
    }
}
