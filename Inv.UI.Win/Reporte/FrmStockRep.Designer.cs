namespace Inv.UI.Win
{
    partial class FrmStockRep
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
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.gridControlDet = new Telerik.WinControls.UI.RadGridView();
            this.rbtrepstockdetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtrepstockresumido = new Telerik.WinControls.UI.RadRadioButton();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rbtRefresh = new Telerik.WinControls.UI.RadButton();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.rbtrepstockcontabilidad = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.rbtstockxprovmatprima = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockdetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockresumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockcontabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtstockxprovmatprima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl.Location = new System.Drawing.Point(0, 31);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1256, 217);
            this.gridControl.TabIndex = 0;
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            this.gridControl.ContextMenuOpening += new Telerik.WinControls.UI.ContextMenuOpeningEventHandler(this.gridControl_ContextMenuOpening);
            // 
            // gridControlDet
            // 
            this.gridControlDet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControlDet.Location = new System.Drawing.Point(0, 30);
            // 
            // 
            // 
            gridViewTextBoxColumn2.HeaderText = "column1";
            gridViewTextBoxColumn2.Name = "column1";
            this.gridControlDet.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn2});
            this.gridControlDet.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControlDet.Name = "gridControlDet";
            this.gridControlDet.Size = new System.Drawing.Size(1256, 200);
            this.gridControlDet.TabIndex = 1;
            this.gridControlDet.Text = "radGridView1";
            // 
            // rbtrepstockdetallado
            // 
            this.rbtrepstockdetallado.Location = new System.Drawing.Point(161, 6);
            this.rbtrepstockdetallado.Name = "rbtrepstockdetallado";
            this.rbtrepstockdetallado.Size = new System.Drawing.Size(141, 18);
            this.rbtrepstockdetallado.TabIndex = 2;
            this.rbtrepstockdetallado.TabStop = false;
            this.rbtrepstockdetallado.Text = "Reporte Stock Detallado";
            // 
            // rbtrepstockresumido
            // 
            this.rbtrepstockresumido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtrepstockresumido.Location = new System.Drawing.Point(12, 6);
            this.rbtrepstockresumido.Name = "rbtrepstockresumido";
            this.rbtrepstockresumido.Size = new System.Drawing.Size(143, 18);
            this.rbtrepstockresumido.TabIndex = 3;
            this.rbtrepstockresumido.Text = "Reporte Stock Resumido";
            this.rbtrepstockresumido.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel1.Size = new System.Drawing.Size(120, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Producto Detalle Stock";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 7);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel2.Size = new System.Drawing.Size(178, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Maestro de Productos Terminados";
            // 
            // rbtRefresh
            // 
            this.rbtRefresh.Location = new System.Drawing.Point(1134, 4);
            this.rbtRefresh.Name = "rbtRefresh";
            this.rbtRefresh.Size = new System.Drawing.Size(110, 24);
            this.rbtRefresh.TabIndex = 6;
            this.rbtRefresh.Text = "Refrescar Stock";
            this.rbtRefresh.Visible = false;
            this.rbtRefresh.Click += new System.EventHandler(this.rbtRefresh_Click);
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.rbtstockxprovmatprima);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.cboalmacenes);
            this.radPanel1.Controls.Add(this.rbtrepstockcontabilidad);
            this.radPanel1.Controls.Add(this.rbtRefresh);
            this.radPanel1.Controls.Add(this.rbtrepstockresumido);
            this.radPanel1.Controls.Add(this.rbtrepstockdetallado);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 33);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1256, 31);
            this.radPanel1.TabIndex = 7;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.Transparent;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(888, 6);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(49, 18);
            this.radLabel3.TabIndex = 13;
            this.radLabel3.Text = "Almacen";
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboalmacenes.Location = new System.Drawing.Point(943, 6);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(185, 20);
            this.cboalmacenes.TabIndex = 12;
            this.cboalmacenes.Text = "radDropDownList1";
            this.cboalmacenes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboalmacenes_SelectedIndexChanged);
            this.cboalmacenes.SelectedValueChanged += new System.EventHandler(this.cboalmacenes_SelectedValueChanged);
            // 
            // rbtrepstockcontabilidad
            // 
            this.rbtrepstockcontabilidad.Location = new System.Drawing.Point(318, 6);
            this.rbtrepstockcontabilidad.Name = "rbtrepstockcontabilidad";
            this.rbtrepstockcontabilidad.Size = new System.Drawing.Size(165, 18);
            this.rbtrepstockcontabilidad.TabIndex = 7;
            this.rbtrepstockcontabilidad.Text = "Stock Detallado Contabilidad";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.gridControlDet);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 317);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1256, 230);
            this.radPanel2.TabIndex = 8;
            // 
            // radPanel5
            // 
            this.radPanel5.Controls.Add(this.radLabel2);
            this.radPanel5.Controls.Add(this.gridControl);
            this.radPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel5.Location = new System.Drawing.Point(0, 69);
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.Size = new System.Drawing.Size(1256, 248);
            this.radPanel5.TabIndex = 1;
            this.radPanel5.Text = "radPanel5";
            // 
            // commandBarRowElement3
            // 
            this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
            // 
            // rbtstockxprovmatprima
            // 
            this.rbtstockxprovmatprima.Location = new System.Drawing.Point(504, 6);
            this.rbtstockxprovmatprima.Name = "rbtstockxprovmatprima";
            this.rbtstockxprovmatprima.Size = new System.Drawing.Size(158, 18);
            this.rbtstockxprovmatprima.TabIndex = 14;
            this.rbtstockxprovmatprima.Text = "Stock X Prov. Materia Prima";
            // 
            // FrmStockRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1256, 547);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radPanel5);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmStockRep";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Stock";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmStockRep_Load);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            this.Controls.SetChildIndex(this.radPanel5, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockdetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockresumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrepstockcontabilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtstockxprovmatprima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadGridView gridControlDet;
        private Telerik.WinControls.UI.RadRadioButton rbtrepstockresumido;
        private Telerik.WinControls.UI.RadRadioButton rbtrepstockdetallado;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton rbtRefresh;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
        private Telerik.WinControls.UI.RadRadioButton rbtrepstockcontabilidad;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadRadioButton rbtstockxprovmatprima;

    }
}
