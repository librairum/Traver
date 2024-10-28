namespace Inv.UI.Win

{
    partial class FrmRepKardexMP
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
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbtopcresumidoxprod = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtopcdetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtopcresumido = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.dtpFechafin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtRangoFechas = new Telerik.WinControls.UI.RadRadioButton();
            this.cbomesfin = new Telerik.WinControls.UI.RadDropDownList();
            this.cbomesini = new Telerik.WinControls.UI.RadDropDownList();
            this.rbtrangoperiodo = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcresumidoxprod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcdetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcresumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).BeginInit();
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
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.cboalmacenes);
            this.radGroupBox1.Controls.Add(this.dtpFechafin);
            this.radGroupBox1.Controls.Add(this.dtpFechaini);
            this.radGroupBox1.Controls.Add(this.rbtRangoFechas);
            this.radGroupBox1.Controls.Add(this.cbomesfin);
            this.radGroupBox1.Controls.Add(this.cbomesini);
            this.radGroupBox1.Controls.Add(this.rbtrangoperiodo);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(985, 53);
            this.radGroupBox1.TabIndex = 4;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbtopcresumidoxprod);
            this.radGroupBox2.Controls.Add(this.rbtopcdetallado);
            this.radGroupBox2.Controls.Add(this.rbtopcresumido);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(652, 5);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(328, 23);
            this.radGroupBox2.TabIndex = 16;
            // 
            // rbtopcresumidoxprod
            // 
            this.rbtopcresumidoxprod.Location = new System.Drawing.Point(156, 1);
            this.rbtopcresumidoxprod.Name = "rbtopcresumidoxprod";
            this.rbtopcresumidoxprod.Size = new System.Drawing.Size(139, 18);
            this.rbtopcresumidoxprod.TabIndex = 2;
            this.rbtopcresumidoxprod.Text = "Resumido Por Producto";
            // 
            // rbtopcdetallado
            // 
            this.rbtopcdetallado.Location = new System.Drawing.Point(5, 1);
            this.rbtopcdetallado.Name = "rbtopcdetallado";
            this.rbtopcdetallado.Size = new System.Drawing.Size(68, 18);
            this.rbtopcdetallado.TabIndex = 1;
            this.rbtopcdetallado.Text = "Detallado";
            // 
            // rbtopcresumido
            // 
            this.rbtopcresumido.Location = new System.Drawing.Point(79, 1);
            this.rbtopcresumido.Name = "rbtopcresumido";
            this.rbtopcresumido.Size = new System.Drawing.Size(70, 18);
            this.rbtopcresumido.TabIndex = 0;
            this.rbtopcresumido.Text = "Resumido";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(407, 7);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 18);
            this.radLabel1.TabIndex = 15;
            this.radLabel1.Text = "Almacen";
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboalmacenes.Location = new System.Drawing.Point(462, 7);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(177, 20);
            this.cboalmacenes.TabIndex = 14;
            this.cboalmacenes.Text = "radDropDownList1";
            this.cboalmacenes.SelectedValueChanged += new System.EventHandler(this.cboalmacenes_SelectedValueChanged);
            // 
            // dtpFechafin
            // 
            this.dtpFechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechafin.Location = new System.Drawing.Point(303, 30);
            this.dtpFechafin.Name = "dtpFechafin";
            this.dtpFechafin.Size = new System.Drawing.Size(89, 20);
            this.dtpFechafin.TabIndex = 13;
            this.dtpFechafin.TabStop = false;
            this.dtpFechafin.Text = "28/04/2015";
            this.dtpFechafin.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // dtpFechaini
            // 
            this.dtpFechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaini.Location = new System.Drawing.Point(303, 9);
            this.dtpFechaini.Name = "dtpFechaini";
            this.dtpFechaini.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaini.TabIndex = 12;
            this.dtpFechaini.TabStop = false;
            this.dtpFechaini.Text = "28/04/2015";
            this.dtpFechaini.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // rbtRangoFechas
            // 
            this.rbtRangoFechas.Location = new System.Drawing.Point(208, 10);
            this.rbtRangoFechas.Name = "rbtRangoFechas";
            this.rbtRangoFechas.Size = new System.Drawing.Size(89, 18);
            this.rbtRangoFechas.TabIndex = 11;
            this.rbtRangoFechas.Text = "Rango Fechas";
            // 
            // cbomesfin
            // 
            this.cbomesfin.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesfin.Location = new System.Drawing.Point(104, 30);
            this.cbomesfin.Name = "cbomesfin";
            this.cbomesfin.Size = new System.Drawing.Size(89, 20);
            this.cbomesfin.TabIndex = 10;
            // 
            // cbomesini
            // 
            this.cbomesini.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesini.Location = new System.Drawing.Point(104, 9);
            this.cbomesini.Name = "cbomesini";
            this.cbomesini.Size = new System.Drawing.Size(90, 20);
            this.cbomesini.TabIndex = 9;
            // 
            // rbtrangoperiodo
            // 
            this.rbtrangoperiodo.Location = new System.Drawing.Point(11, 9);
            this.rbtrangoperiodo.Name = "rbtrangoperiodo";
            this.rbtrangoperiodo.Size = new System.Drawing.Size(87, 18);
            this.rbtrangoperiodo.TabIndex = 8;
            this.rbtrangoperiodo.Text = "Rango Meses";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridControl);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 86);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(985, 402);
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
            this.gridControl.Size = new System.Drawing.Size(985, 402);
            this.gridControl.TabIndex = 0;
            // 
            // FrmRepKardexMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 488);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "FrmRepKardexMP";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Kardex de Materia Prima";
            this.Load += new System.EventHandler(this.FrmRepKardexMP_Load);
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcresumidoxprod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcdetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcresumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cbomesfin;
        private Telerik.WinControls.UI.RadDropDownList cbomesini;
        private Telerik.WinControls.UI.RadRadioButton rbtrangoperiodo;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechafin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaini;
        private Telerik.WinControls.UI.RadRadioButton rbtRangoFechas;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rbtopcresumidoxprod;
        private Telerik.WinControls.UI.RadRadioButton rbtopcdetallado;
        private Telerik.WinControls.UI.RadRadioButton rbtopcresumido;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView gridControl;

    }
}
