namespace Prod.UI.Win
{
    partial class FrmPPStockVal
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.rbtRefresh = new Telerik.WinControls.UI.RadButton();
            this.rbtrepstockresumido = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtrepstockdetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.gridControlDet = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.rpvStock = new Telerik.WinControls.UI.RadPageView();
            this.rpProductos = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rpCanastillas = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridCanastillas = new Telerik.WinControls.UI.RadGridView();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockresumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockdetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpvStock)).BeginInit();
            this.rpvStock.SuspendLayout();
            this.rpProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            this.rpCanastillas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCanastillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCanastillas.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.Color.White;
            this.toolBar.Size = new System.Drawing.Size(968, 32);
            this.toolBar.ThemeName = "";
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.White;
            this.radPanel2.Controls.Add(this.radLabel3);
            this.radPanel2.Controls.Add(this.cboalmacenes);
            this.radPanel2.Controls.Add(this.rbtRefresh);
            this.radPanel2.Controls.Add(this.rbtrepstockresumido);
            this.radPanel2.Controls.Add(this.rbtrepstockdetallado);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(968, 51);
            this.radPanel2.TabIndex = 5;
            this.radPanel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(505, 9);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(49, 18);
            this.radLabel3.TabIndex = 16;
            this.radLabel3.Text = "Almacen";
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboalmacenes.Location = new System.Drawing.Point(560, 9);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(279, 20);
            this.cboalmacenes.TabIndex = 15;
            this.cboalmacenes.Text = "radDropDownList1";
            this.cboalmacenes.SelectedValueChanged += new System.EventHandler(this.cboalmacenes_SelectedValueChanged);
            // 
            // rbtRefresh
            // 
            this.rbtRefresh.Location = new System.Drawing.Point(845, 7);
            this.rbtRefresh.Name = "rbtRefresh";
            this.rbtRefresh.Size = new System.Drawing.Size(110, 24);
            this.rbtRefresh.TabIndex = 14;
            this.rbtRefresh.Text = "Refrescar Stock";
            this.rbtRefresh.Visible = false;
            // 
            // rbtrepstockresumido
            // 
            this.rbtrepstockresumido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtrepstockresumido.Location = new System.Drawing.Point(14, 9);
            this.rbtrepstockresumido.Name = "rbtrepstockresumido";
            this.rbtrepstockresumido.Size = new System.Drawing.Size(143, 18);
            this.rbtrepstockresumido.TabIndex = 13;
            this.rbtrepstockresumido.Text = "Reporte Stock Resumido";
            this.rbtrepstockresumido.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.rbtrepstockresumido.CheckStateChanged += new System.EventHandler(this.rbtrepstockresumido_CheckStateChanged);
            // 
            // rbtrepstockdetallado
            // 
            this.rbtrepstockdetallado.Location = new System.Drawing.Point(163, 9);
            this.rbtrepstockdetallado.Name = "rbtrepstockdetallado";
            this.rbtrepstockdetallado.Size = new System.Drawing.Size(141, 18);
            this.rbtrepstockdetallado.TabIndex = 12;
            this.rbtrepstockdetallado.TabStop = false;
            this.rbtrepstockdetallado.Text = "Reporte Stock Detallado";
            this.rbtrepstockdetallado.CheckStateChanged += new System.EventHandler(this.rbtrepstockdetallado_CheckStateChanged);
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.gridControlDet);
            this.radPanel3.Controls.Add(this.radLabel1);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel3.Location = new System.Drawing.Point(0, 165);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(947, 214);
            this.radPanel3.TabIndex = 6;
            // 
            // gridControlDet
            // 
            this.gridControlDet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControlDet.Location = new System.Drawing.Point(0, 21);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControlDet.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControlDet.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControlDet.Name = "gridControlDet";
            this.gridControlDet.Size = new System.Drawing.Size(947, 193);
            this.gridControlDet.TabIndex = 5;
            this.gridControlDet.Text = "radGridView1";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(4, 5);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel1.Size = new System.Drawing.Size(120, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Producto Detalle Stock";
            // 
            // radPanel4
            // 
            this.radPanel4.BackColor = System.Drawing.Color.White;
            this.radPanel4.Controls.Add(this.rpvStock);
            this.radPanel4.Controls.Add(this.radLabel2);
            this.radPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel4.Location = new System.Drawing.Point(0, 84);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(968, 445);
            this.radPanel4.TabIndex = 7;
            this.radPanel4.ThemeName = "ControlDefault";
            // 
            // rpvStock
            // 
            this.rpvStock.BackColor = System.Drawing.Color.White;
            this.rpvStock.Controls.Add(this.rpProductos);
            this.rpvStock.Controls.Add(this.rpCanastillas);
            this.rpvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvStock.Location = new System.Drawing.Point(0, 18);
            this.rpvStock.Name = "rpvStock";
            this.rpvStock.SelectedPage = this.rpProductos;
            this.rpvStock.Size = new System.Drawing.Size(968, 427);
            this.rpvStock.TabIndex = 8;
            this.rpvStock.SelectedPageChanged += new System.EventHandler(this.rpvStock_SelectedPageChanged);
            // 
            // rpProductos
            // 
            this.rpProductos.BackColor = System.Drawing.Color.White;
            this.rpProductos.Controls.Add(this.gridControl);
            this.rpProductos.Controls.Add(this.radPanel3);
            this.rpProductos.ItemSize = new System.Drawing.SizeF(96F, 28F);
            this.rpProductos.Location = new System.Drawing.Point(10, 37);
            this.rpProductos.Name = "rpProductos";
            this.rpProductos.Size = new System.Drawing.Size(947, 379);
            this.rpProductos.Text = "Stock Resumido";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            gridViewTextBoxColumn2.HeaderText = "column1";
            gridViewTextBoxColumn2.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn2});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(947, 165);
            this.gridControl.TabIndex = 7;
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            // 
            // rpCanastillas
            // 
            this.rpCanastillas.Controls.Add(this.gridCanastillas);
            this.rpCanastillas.ItemSize = new System.Drawing.SizeF(95F, 28F);
            this.rpCanastillas.Location = new System.Drawing.Point(10, 37);
            this.rpCanastillas.Name = "rpCanastillas";
            this.rpCanastillas.Size = new System.Drawing.Size(947, 379);
            this.rpCanastillas.Text = "Stock Detallado";
            // 
            // gridCanastillas
            // 
            this.gridCanastillas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCanastillas.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridCanastillas.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gridCanastillas.Name = "gridCanastillas";
            this.gridCanastillas.Size = new System.Drawing.Size(947, 379);
            this.gridCanastillas.TabIndex = 0;
            this.gridCanastillas.Text = "radGridView1";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel2.Location = new System.Drawing.Point(0, 0);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel2.Size = new System.Drawing.Size(968, 18);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Maestro de Productos Terminados";
            // 
            // FrmPPStockVal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 529);
            this.Controls.Add(this.radPanel4);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmPPStockVal";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Stock en Productos en Proceso";
            this.ThemeName = "";
            this.Controls.SetChildIndex(this.radPanel2, 0);
            this.Controls.SetChildIndex(this.radPanel4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockresumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockdetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            this.radPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpvStock)).EndInit();
            this.rpvStock.ResumeLayout(false);
            this.rpProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.rpCanastillas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCanastillas.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCanastillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadButton rbtRefresh;
        private Telerik.WinControls.UI.RadRadioButton rbtrepstockresumido;
        private Telerik.WinControls.UI.RadRadioButton rbtrepstockdetallado;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView gridControlDet;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPageView rpvStock;
        private Telerik.WinControls.UI.RadPageViewPage rpProductos;
        private Telerik.WinControls.UI.RadPageViewPage rpCanastillas;
        private Telerik.WinControls.UI.RadGridView gridCanastillas;
    }
}
