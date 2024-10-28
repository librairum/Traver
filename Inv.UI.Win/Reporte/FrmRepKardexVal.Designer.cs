namespace Inv.UI.Win
{
    partial class FrmRepKardexVal
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbtopcresumidoxprod = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtopcdetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.cbomesfin = new Telerik.WinControls.UI.RadDropDownList();
            this.cbomesini = new Telerik.WinControls.UI.RadDropDownList();
            this.dtpFechafin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtrangoperiodo = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpFechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtRangoFechas = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcresumidoxprod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcdetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1057, 420);
            this.gridControl.TabIndex = 0;
            this.gridControl.Text = "radGridView1";
            this.gridControl.FilterPopupRequired += new Telerik.WinControls.UI.FilterPopupRequiredEventHandler(this.gridControl_FilterPopupRequired);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.cboalmacenes);
            this.radGroupBox1.Controls.Add(this.cbomesfin);
            this.radGroupBox1.Controls.Add(this.cbomesini);
            this.radGroupBox1.Controls.Add(this.dtpFechafin);
            this.radGroupBox1.Controls.Add(this.rbtrangoperiodo);
            this.radGroupBox1.Controls.Add(this.dtpFechaini);
            this.radGroupBox1.Controls.Add(this.rbtRangoFechas);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1057, 47);
            this.radGroupBox1.TabIndex = 1;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbtopcresumidoxprod);
            this.radGroupBox2.Controls.Add(this.rbtopcdetallado);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(717, 4);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(328, 23);
            this.radGroupBox2.TabIndex = 10;
            // 
            // rbtopcresumidoxprod
            // 
            this.rbtopcresumidoxprod.Location = new System.Drawing.Point(79, 1);
            this.rbtopcresumidoxprod.Name = "rbtopcresumidoxprod";
            this.rbtopcresumidoxprod.Size = new System.Drawing.Size(70, 18);
            this.rbtopcresumidoxprod.TabIndex = 2;
            this.rbtopcresumidoxprod.Text = "Resumido";
            // 
            // rbtopcdetallado
            // 
            this.rbtopcdetallado.Location = new System.Drawing.Point(5, 1);
            this.rbtopcdetallado.Name = "rbtopcdetallado";
            this.rbtopcdetallado.Size = new System.Drawing.Size(68, 18);
            this.rbtopcdetallado.TabIndex = 1;
            this.rbtopcdetallado.Text = "Detallado";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(439, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 18);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "Almacen";
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboalmacenes.Location = new System.Drawing.Point(494, 3);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(177, 20);
            this.cboalmacenes.TabIndex = 8;
            this.cboalmacenes.Text = "radDropDownList1";
            this.cboalmacenes.SelectedValueChanged += new System.EventHandler(this.cboalmacenes_SelectedValueChanged);
            // 
            // cbomesfin
            // 
            this.cbomesfin.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesfin.Location = new System.Drawing.Point(109, 25);
            this.cbomesfin.Name = "cbomesfin";
            this.cbomesfin.Size = new System.Drawing.Size(89, 20);
            this.cbomesfin.TabIndex = 7;
            // 
            // cbomesini
            // 
            this.cbomesini.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesini.Location = new System.Drawing.Point(109, 4);
            this.cbomesini.Name = "cbomesini";
            this.cbomesini.Size = new System.Drawing.Size(90, 20);
            this.cbomesini.TabIndex = 6;
            // 
            // dtpFechafin
            // 
            this.dtpFechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechafin.Location = new System.Drawing.Point(313, 24);
            this.dtpFechafin.Name = "dtpFechafin";
            this.dtpFechafin.Size = new System.Drawing.Size(89, 20);
            this.dtpFechafin.TabIndex = 5;
            this.dtpFechafin.TabStop = false;
            this.dtpFechafin.Text = "28/04/2015";
            this.dtpFechafin.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // rbtrangoperiodo
            // 
            this.rbtrangoperiodo.Location = new System.Drawing.Point(16, 4);
            this.rbtrangoperiodo.Name = "rbtrangoperiodo";
            this.rbtrangoperiodo.Size = new System.Drawing.Size(87, 18);
            this.rbtrangoperiodo.TabIndex = 5;
            this.rbtrangoperiodo.Text = "Rango Meses";
            // 
            // dtpFechaini
            // 
            this.dtpFechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaini.Location = new System.Drawing.Point(313, 3);
            this.dtpFechaini.Name = "dtpFechaini";
            this.dtpFechaini.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaini.TabIndex = 4;
            this.dtpFechaini.TabStop = false;
            this.dtpFechaini.Text = "28/04/2015";
            this.dtpFechaini.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // rbtRangoFechas
            // 
            this.rbtRangoFechas.Location = new System.Drawing.Point(218, 4);
            this.rbtRangoFechas.Name = "rbtRangoFechas";
            this.rbtRangoFechas.Size = new System.Drawing.Size(89, 18);
            this.rbtRangoFechas.TabIndex = 3;
            this.rbtRangoFechas.Text = "Rango Fechas";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.gridControl);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 80);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1057, 420);
            this.radPanel1.TabIndex = 2;
            // 
            // FrmRepKardexVal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1057, 500);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "FrmRepKardexVal";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Kardex Valorizado";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmRepKardexVal_Load);
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcresumidoxprod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtopcdetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRangoFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechafin;
        private Telerik.WinControls.UI.RadDropDownList cbomesfin;
        private Telerik.WinControls.UI.RadDropDownList cbomesini;
        private Telerik.WinControls.UI.RadRadioButton rbtrangoperiodo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rbtopcdetallado;
        private Telerik.WinControls.UI.RadRadioButton rbtopcresumidoxprod;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaini;
        private Telerik.WinControls.UI.RadRadioButton rbtRangoFechas;

    }
}
