namespace Inv.UI.Win
{
    partial class frmLineaArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLineaArticulo));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rpInferior1 = new Telerik.WinControls.UI.RadPanel();
            this.gridLineaArticulo = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnAgregarLineaArticulo = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rpInferior2 = new Telerik.WinControls.UI.RadPanel();
            this.gridGrupoArticulo = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnAgregarGrupoArticulo = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rpInferior3 = new Telerik.WinControls.UI.RadPanel();
            this.gridSubGrupoArticulo = new Telerik.WinControls.UI.RadGridView();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.btnAgregaSubGrupoArticulo = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpInferior1)).BeginInit();
            this.rpInferior1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaArticulo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregarLineaArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpInferior2)).BeginInit();
            this.rpInferior2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoArticulo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregarGrupoArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpInferior3)).BeginInit();
            this.rpInferior3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubGrupoArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubGrupoArticulo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregaSubGrupoArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toolBar.Size = new System.Drawing.Size(926, 33);
            // 
            // rpInferior1
            // 
            this.rpInferior1.Controls.Add(this.gridLineaArticulo);
            this.rpInferior1.Controls.Add(this.radPanel2);
            this.rpInferior1.Controls.Add(this.radLabel1);
            this.rpInferior1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpInferior1.Location = new System.Drawing.Point(0, 33);
            this.rpInferior1.Name = "rpInferior1";
            this.rpInferior1.Size = new System.Drawing.Size(381, 416);
            this.rpInferior1.TabIndex = 199;
            // 
            // gridLineaArticulo
            // 
            this.gridLineaArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLineaArticulo.Location = new System.Drawing.Point(0, 42);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridLineaArticulo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridLineaArticulo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridLineaArticulo.Name = "gridLineaArticulo";
            this.gridLineaArticulo.Size = new System.Drawing.Size(381, 374);
            this.gridLineaArticulo.TabIndex = 225;
            this.gridLineaArticulo.Tag = "linea";
            this.gridLineaArticulo.Text = "radGridView1";
            this.gridLineaArticulo.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gridLineaArticulo_CellFormatting);
            this.gridLineaArticulo.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gridLineaArticulo_CellBeginEdit);
            this.gridLineaArticulo.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridLineaArticulo_CurrentRowChanged);
            this.gridLineaArticulo.CurrentRowChanging += new Telerik.WinControls.UI.CurrentRowChangingEventHandler(this.gridLineaArticulo_CurrentRowChanging);
            this.gridLineaArticulo.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridLineaArticulo_CommandCellClick);
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.White;
            this.radPanel2.Controls.Add(this.btnAgregarLineaArticulo);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 18);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(381, 24);
            this.radPanel2.TabIndex = 227;
            this.radPanel2.ThemeName = "ControlDefault";
            // 
            // btnAgregarLineaArticulo
            // 
            this.btnAgregarLineaArticulo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregarLineaArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarLineaArticulo.Image")));
            this.btnAgregarLineaArticulo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregarLineaArticulo.Location = new System.Drawing.Point(351, 0);
            this.btnAgregarLineaArticulo.Name = "btnAgregarLineaArticulo";
            this.btnAgregarLineaArticulo.Size = new System.Drawing.Size(30, 24);
            this.btnAgregarLineaArticulo.TabIndex = 226;
            this.btnAgregarLineaArticulo.ThemeName = "Office2013Light";
            this.btnAgregarLineaArticulo.Click += new System.EventHandler(this.btnAgregarLineaArticulo_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(381, 18);
            this.radLabel1.TabIndex = 198;
            this.radLabel1.Text = "Linea Articulo";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rpInferior2
            // 
            this.rpInferior2.Controls.Add(this.gridGrupoArticulo);
            this.rpInferior2.Controls.Add(this.radPanel1);
            this.rpInferior2.Controls.Add(this.radLabel2);
            this.rpInferior2.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpInferior2.Location = new System.Drawing.Point(381, 33);
            this.rpInferior2.Name = "rpInferior2";
            this.rpInferior2.Size = new System.Drawing.Size(482, 416);
            this.rpInferior2.TabIndex = 200;
            // 
            // gridGrupoArticulo
            // 
            this.gridGrupoArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGrupoArticulo.Location = new System.Drawing.Point(0, 42);
            // 
            // 
            // 
            gridViewTextBoxColumn2.HeaderText = "column1";
            gridViewTextBoxColumn2.Name = "column1";
            this.gridGrupoArticulo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn2});
            this.gridGrupoArticulo.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridGrupoArticulo.Name = "gridGrupoArticulo";
            this.gridGrupoArticulo.Size = new System.Drawing.Size(482, 374);
            this.gridGrupoArticulo.TabIndex = 225;
            this.gridGrupoArticulo.Tag = "grupo";
            this.gridGrupoArticulo.Text = "radGridView1";
            this.gridGrupoArticulo.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gridGrupoArticulo_CellFormatting);
            this.gridGrupoArticulo.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gridGrupoArticulo_CellBeginEdit);
            this.gridGrupoArticulo.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridGrupoArticulo_CurrentRowChanged);
            this.gridGrupoArticulo.CurrentRowChanging += new Telerik.WinControls.UI.CurrentRowChangingEventHandler(this.gridGrupoArticulo_CurrentRowChanging);
            this.gridGrupoArticulo.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridGrupoArticulo_CommandCellClick);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.White;
            this.radPanel1.Controls.Add(this.btnAgregarGrupoArticulo);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 18);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(482, 24);
            this.radPanel1.TabIndex = 227;
            this.radPanel1.ThemeName = "ControlDefault";
            // 
            // btnAgregarGrupoArticulo
            // 
            this.btnAgregarGrupoArticulo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregarGrupoArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarGrupoArticulo.Image")));
            this.btnAgregarGrupoArticulo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregarGrupoArticulo.Location = new System.Drawing.Point(447, 0);
            this.btnAgregarGrupoArticulo.Name = "btnAgregarGrupoArticulo";
            this.btnAgregarGrupoArticulo.Size = new System.Drawing.Size(35, 24);
            this.btnAgregarGrupoArticulo.TabIndex = 226;
            this.btnAgregarGrupoArticulo.ThemeName = "Office2013Light";
            this.btnAgregarGrupoArticulo.Click += new System.EventHandler(this.btnAgregarGrupoArticulo_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel2.Location = new System.Drawing.Point(0, 0);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(482, 18);
            this.radLabel2.TabIndex = 198;
            this.radLabel2.Text = "Grupo Articulo";
            // 
            // rpInferior3
            // 
            this.rpInferior3.Controls.Add(this.gridSubGrupoArticulo);
            this.rpInferior3.Controls.Add(this.radPanel3);
            this.rpInferior3.Controls.Add(this.radLabel3);
            this.rpInferior3.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpInferior3.Location = new System.Drawing.Point(863, 33);
            this.rpInferior3.Name = "rpInferior3";
            this.rpInferior3.Size = new System.Drawing.Size(427, 416);
            this.rpInferior3.TabIndex = 201;
            // 
            // gridSubGrupoArticulo
            // 
            this.gridSubGrupoArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSubGrupoArticulo.Location = new System.Drawing.Point(0, 42);
            // 
            // 
            // 
            gridViewTextBoxColumn3.HeaderText = "column1";
            gridViewTextBoxColumn3.Name = "column1";
            this.gridSubGrupoArticulo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3});
            this.gridSubGrupoArticulo.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gridSubGrupoArticulo.Name = "gridSubGrupoArticulo";
            this.gridSubGrupoArticulo.Size = new System.Drawing.Size(427, 374);
            this.gridSubGrupoArticulo.TabIndex = 225;
            this.gridSubGrupoArticulo.Tag = "subgrupo";
            this.gridSubGrupoArticulo.Text = "radGridView1";
            this.gridSubGrupoArticulo.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gridSubGrupoArticulo_CellFormatting);
            this.gridSubGrupoArticulo.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gridSubGrupoArticulo_CellBeginEdit);
            this.gridSubGrupoArticulo.CurrentRowChanging += new Telerik.WinControls.UI.CurrentRowChangingEventHandler(this.gridSubGrupoArticulo_CurrentRowChanging);
            this.gridSubGrupoArticulo.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridSubGrupoArticulo_CommandCellClick);
            // 
            // radPanel3
            // 
            this.radPanel3.BackColor = System.Drawing.Color.White;
            this.radPanel3.Controls.Add(this.btnAgregaSubGrupoArticulo);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel3.Location = new System.Drawing.Point(0, 18);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(427, 24);
            this.radPanel3.TabIndex = 227;
            this.radPanel3.ThemeName = "ControlDefault";
            // 
            // btnAgregaSubGrupoArticulo
            // 
            this.btnAgregaSubGrupoArticulo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregaSubGrupoArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregaSubGrupoArticulo.Image")));
            this.btnAgregaSubGrupoArticulo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregaSubGrupoArticulo.Location = new System.Drawing.Point(398, 0);
            this.btnAgregaSubGrupoArticulo.Name = "btnAgregaSubGrupoArticulo";
            this.btnAgregaSubGrupoArticulo.Size = new System.Drawing.Size(29, 24);
            this.btnAgregaSubGrupoArticulo.TabIndex = 226;
            this.btnAgregaSubGrupoArticulo.ThemeName = "Office2013Light";
            this.btnAgregaSubGrupoArticulo.Click += new System.EventHandler(this.btnAgregaSubGrupoArticulo_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel3.Location = new System.Drawing.Point(0, 0);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(427, 18);
            this.radLabel3.TabIndex = 198;
            this.radLabel3.Text = "Sub Grupo Articulo";
            // 
            // frmLineaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 449);
            this.Controls.Add(this.rpInferior3);
            this.Controls.Add(this.rpInferior2);
            this.Controls.Add(this.rpInferior1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLineaArticulo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmLineaArticulo";
            this.Load += new System.EventHandler(this.frmLineaArticulo_Load);
            this.Controls.SetChildIndex(this.toolBar, 0);
            this.Controls.SetChildIndex(this.rpInferior1, 0);
            this.Controls.SetChildIndex(this.rpInferior2, 0);
            this.Controls.SetChildIndex(this.rpInferior3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpInferior1)).EndInit();
            this.rpInferior1.ResumeLayout(false);
            this.rpInferior1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaArticulo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineaArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregarLineaArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpInferior2)).EndInit();
            this.rpInferior2.ResumeLayout(false);
            this.rpInferior2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoArticulo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregarGrupoArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpInferior3)).EndInit();
            this.rpInferior3.ResumeLayout(false);
            this.rpInferior3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubGrupoArticulo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubGrupoArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregaSubGrupoArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpInferior1;
        internal Telerik.WinControls.UI.RadGridView gridLineaArticulo;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnAgregarLineaArticulo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPanel rpInferior2;
        internal Telerik.WinControls.UI.RadGridView gridGrupoArticulo;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnAgregarGrupoArticulo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadPanel rpInferior3;
        internal Telerik.WinControls.UI.RadGridView gridSubGrupoArticulo;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadButton btnAgregaSubGrupoArticulo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
