namespace Com.UI.Win
{
    partial class frmUltimoArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUltimoArticulo));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rpOpciones = new Telerik.WinControls.UI.RadPanel();
            this.btnCopiarTodo = new Telerik.WinControls.UI.RadButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnAgregar = new Telerik.WinControls.UI.RadButton();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbOrdenTrabajo = new System.Windows.Forms.RadioButton();
            this.rbOrdenCompra = new System.Windows.Forms.RadioButton();
            this.gridUltimaCompra = new Telerik.WinControls.UI.RadGridView();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            ((System.ComponentModel.ISupportInitialize)(this.rpOpciones)).BeginInit();
            this.rpOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopiarTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUltimaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUltimaCompra.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rpOpciones
            // 
            this.rpOpciones.Controls.Add(this.btnCopiarTodo);
            this.rpOpciones.Controls.Add(this.radPanel2);
            this.rpOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpOpciones.Location = new System.Drawing.Point(0, 51);
            this.rpOpciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rpOpciones.Name = "rpOpciones";
            this.rpOpciones.Size = new System.Drawing.Size(1395, 54);
            this.rpOpciones.TabIndex = 75;
            // 
            // btnCopiarTodo
            // 
            this.btnCopiarTodo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopiarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiarTodo.Image")));
            this.btnCopiarTodo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCopiarTodo.Location = new System.Drawing.Point(1344, 0);
            this.btnCopiarTodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCopiarTodo.Name = "btnCopiarTodo";
            this.btnCopiarTodo.Size = new System.Drawing.Size(51, 54);
            this.btnCopiarTodo.TabIndex = 77;
            this.btnCopiarTodo.ThemeName = "Windows8";
            this.btnCopiarTodo.Click += new System.EventHandler(this.btnCopiarTodo_Click);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnAgregar);
            this.radPanel2.Controls.Add(this.dtpFechaFin);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.dtpFechaIni);
            this.radPanel2.Controls.Add(this.radLabel4);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1113, 54);
            this.radPanel2.TabIndex = 76;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.Location = new System.Drawing.Point(486, 3);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(76, 38);
            this.btnAgregar.TabIndex = 168;
            this.btnAgregar.ThemeName = "Office2013Light";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(336, 8);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(135, 27);
            this.dtpFechaFin.TabIndex = 167;
            this.dtpFechaFin.TabStop = false;
            this.dtpFechaFin.Text = "31/12/2017";
            this.dtpFechaFin.Value = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(248, 9);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(82, 26);
            this.radLabel1.TabIndex = 166;
            this.radLabel1.Text = "Fecha Fin:";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(104, 9);
            this.dtpFechaIni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(135, 27);
            this.dtpFechaIni.TabIndex = 165;
            this.dtpFechaIni.TabStop = false;
            this.dtpFechaIni.Text = "01/12/2017";
            this.dtpFechaIni.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(15, 11);
            this.radLabel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(77, 26);
            this.radLabel4.TabIndex = 164;
            this.radLabel4.Text = "Fecha ini:";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.rbTodo);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.rbOrdenTrabajo);
            this.radPanel1.Controls.Add(this.rbOrdenCompra);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(524, 46);
            this.radPanel1.TabIndex = 75;
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Location = new System.Drawing.Point(416, 11);
            this.rbTodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(72, 27);
            this.rbTodo.TabIndex = 3;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo :";
            // 
            // rbOrdenTrabajo
            // 
            this.rbOrdenTrabajo.AutoSize = true;
            this.rbOrdenTrabajo.Location = new System.Drawing.Point(258, 9);
            this.rbOrdenTrabajo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbOrdenTrabajo.Name = "rbOrdenTrabajo";
            this.rbOrdenTrabajo.Size = new System.Drawing.Size(144, 27);
            this.rbOrdenTrabajo.TabIndex = 1;
            this.rbOrdenTrabajo.Text = "Orden Trabajo";
            this.rbOrdenTrabajo.UseVisualStyleBackColor = true;
            // 
            // rbOrdenCompra
            // 
            this.rbOrdenCompra.AutoSize = true;
            this.rbOrdenCompra.Checked = true;
            this.rbOrdenCompra.Location = new System.Drawing.Point(87, 9);
            this.rbOrdenCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbOrdenCompra.Name = "rbOrdenCompra";
            this.rbOrdenCompra.Size = new System.Drawing.Size(146, 27);
            this.rbOrdenCompra.TabIndex = 0;
            this.rbOrdenCompra.TabStop = true;
            this.rbOrdenCompra.Text = "Orden compra";
            this.rbOrdenCompra.UseVisualStyleBackColor = true;
            // 
            // gridUltimaCompra
            // 
            this.gridUltimaCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridUltimaCompra.Location = new System.Drawing.Point(0, 105);
            this.gridUltimaCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridUltimaCompra.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridUltimaCompra.MasterTemplate.EnableFiltering = true;
            this.gridUltimaCompra.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridUltimaCompra.Name = "gridUltimaCompra";
            this.gridUltimaCompra.Size = new System.Drawing.Size(1395, 658);
            this.gridUltimaCompra.TabIndex = 76;
            this.gridUltimaCompra.Text = "radGridView1";
            // 
            // radPanel3
            // 
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel3.Location = new System.Drawing.Point(0, 763);
            this.radPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(1395, 0);
            this.radPanel3.TabIndex = 197;
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // frmUltimoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 512);
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.gridUltimaCompra);
            this.Controls.Add(this.rpOpciones);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmUltimoArticulo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Ultima Compra";
            this.Load += new System.EventHandler(this.frmRepUltimaCompra_Load);
            this.Controls.SetChildIndex(this.rpOpciones, 0);
            this.Controls.SetChildIndex(this.gridUltimaCompra, 0);
            this.Controls.SetChildIndex(this.radPanel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rpOpciones)).EndInit();
            this.rpOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCopiarTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUltimaCompra.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUltimaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpOpciones;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnAgregar;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaIni;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.RadioButton rbTodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbOrdenTrabajo;
        private System.Windows.Forms.RadioButton rbOrdenCompra;
        internal Telerik.WinControls.UI.RadGridView gridUltimaCompra;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadButton btnCopiarTodo;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    }
}
