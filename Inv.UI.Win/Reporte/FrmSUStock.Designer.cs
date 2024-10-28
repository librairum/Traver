namespace Inv.UI.Win
{
    partial class FrmSUStock
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
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.rpvGeneral = new Telerik.WinControls.UI.RadPageView();
            this.rpvStockResumido = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpvGeneral)).BeginInit();
            this.rpvGeneral.SuspendLayout();
            this.rpvStockResumido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.gridControl.Size = new System.Drawing.Size(1235, 295);
            this.gridControl.TabIndex = 0;
            this.gridControl.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellEndEdit);
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            // 
            // gridControlDet
            // 
            this.gridControlDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDet.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            gridViewTextBoxColumn2.HeaderText = "column1";
            gridViewTextBoxColumn2.Name = "column1";
            this.gridControlDet.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn2});
            this.gridControlDet.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControlDet.Name = "gridControlDet";
            this.gridControlDet.Size = new System.Drawing.Size(1235, 116);
            this.gridControlDet.TabIndex = 1;
            this.gridControlDet.Text = "radGridView1";
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
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel1.Size = new System.Drawing.Size(111, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Stock Por Almacenes";
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.btnGuardar);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.cboalmacenes);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 21);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1256, 38);
            this.radPanel1.TabIndex = 7;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(852, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nota : Si requiere mostrar stock x periodo, Visualice el reporte.";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(352, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 24);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar Ubicaciones";
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 7);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(49, 18);
            this.radLabel3.TabIndex = 11;
            this.radLabel3.Text = "Almacen";
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboalmacenes.Location = new System.Drawing.Point(67, 7);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(279, 20);
            this.cboalmacenes.TabIndex = 10;
            this.cboalmacenes.Text = "radDropDownList1";
            this.cboalmacenes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboalmacenes_SelectedIndexChanged);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridControlDet);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 325);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1235, 134);
            this.radPanel2.TabIndex = 8;
            // 
            // radPanel5
            // 
            this.radPanel5.Controls.Add(this.gridControl);
            this.radPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel5.Location = new System.Drawing.Point(0, 0);
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.Size = new System.Drawing.Size(1235, 295);
            this.radPanel5.TabIndex = 1;
            this.radPanel5.Text = "radPanel5";
            // 
            // commandBarRowElement3
            // 
            this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
            // 
            // rpvGeneral
            // 
            this.rpvGeneral.Controls.Add(this.rpvStockResumido);
            this.rpvGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvGeneral.Location = new System.Drawing.Point(0, 59);
            this.rpvGeneral.Name = "rpvGeneral";
            this.rpvGeneral.SelectedPage = this.rpvStockResumido;
            this.rpvGeneral.Size = new System.Drawing.Size(1256, 507);
            this.rpvGeneral.TabIndex = 1;
            this.rpvGeneral.Text = "radPageView1";
            // 
            // rpvStockResumido
            // 
            this.rpvStockResumido.Controls.Add(this.radPanel2);
            this.rpvStockResumido.Controls.Add(this.radPanel5);
            this.rpvStockResumido.ItemSize = new System.Drawing.SizeF(78F, 28F);
            this.rpvStockResumido.Location = new System.Drawing.Point(10, 37);
            this.rpvStockResumido.Name = "rpvStockResumido";
            this.rpvStockResumido.Size = new System.Drawing.Size(1235, 459);
            this.rpvStockResumido.Text = "Stock Actual";
            // 
            // FrmSUStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1256, 566);
            this.Controls.Add(this.rpvGeneral);
            this.Controls.Add(this.radPanel1);
            this.Name = "FrmSUStock";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Stock";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmSUStock_Load);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.rpvGeneral, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpvGeneral)).EndInit();
            this.rpvGeneral.ResumeLayout(false);
            this.rpvStockResumido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadGridView gridControlDet;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadPageView rpvGeneral;
        private Telerik.WinControls.UI.RadPageViewPage rpvStockResumido;
        private Telerik.WinControls.UI.RadButton btnGuardar;
        private System.Windows.Forms.Label label1;

    }
}
