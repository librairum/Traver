namespace Inv.UI.Win
{
    partial class frmDocu
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocu));
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.panelErrores = new Telerik.WinControls.UI.RadPanel();
            this.btnCerrarModal = new Telerik.WinControls.UI.RadButton();
            this.dgvErrores = new Telerik.WinControls.UI.RadGridView();
            this.btnGuardar = new Telerik.WinControls.UI.RadButton();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rbEntradas = new Telerik.WinControls.UI.RadRadioButton();
            this.rbSalidas = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnImportar = new Telerik.WinControls.UI.RadButton();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            this.gridControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelErrores)).BeginInit();
            this.panelErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarModal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.BackColor = System.Drawing.Color.Aqua;
            this.gridControl.Controls.Add(this.panelErrores);
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridControl.ForeColor = System.Drawing.Color.Black;
            this.gridControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControl.Name = "gridControl";
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridControl.Size = new System.Drawing.Size(1150, 364);
            this.gridControl.TabIndex = 0;
            this.gridControl.Text = "gridView";
            this.gridControl.ThemeName = "Office2013Light";
            this.gridControl.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellDoubleClick);
            this.gridControl.FilterPopupRequired += new Telerik.WinControls.UI.FilterPopupRequiredEventHandler(this.gridControl_FilterPopupRequired);
            // 
            // panelErrores
            // 
            this.panelErrores.BackColor = System.Drawing.Color.OldLace;
            this.panelErrores.Controls.Add(this.btnCerrarModal);
            this.panelErrores.Controls.Add(this.dgvErrores);
            this.panelErrores.Controls.Add(this.btnGuardar);
            this.panelErrores.Location = new System.Drawing.Point(12, 6);
            this.panelErrores.Name = "panelErrores";
            this.panelErrores.Size = new System.Drawing.Size(1102, 292);
            this.panelErrores.TabIndex = 2;
            // 
            // btnCerrarModal
            // 
            this.btnCerrarModal.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.btnCerrarModal.Location = new System.Drawing.Point(1073, 3);
            this.btnCerrarModal.Name = "btnCerrarModal";
            this.btnCerrarModal.Size = new System.Drawing.Size(26, 20);
            this.btnCerrarModal.TabIndex = 1;
            this.btnCerrarModal.Text = "x";
            // 
            // dgvErrores
            // 
            this.dgvErrores.Location = new System.Drawing.Point(3, 29);
            // 
            // 
            // 
            this.dgvErrores.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.Size = new System.Drawing.Size(1099, 260);
            this.dgvErrores.TabIndex = 0;
            this.dgvErrores.Text = "radGridView1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(957, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 20);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Generar documento";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "in.png");
            this.imageList1.Images.SetKeyName(1, "out.png");
            // 
            // rbEntradas
            // 
            this.rbEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbEntradas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbEntradas.Image = ((System.Drawing.Image)(resources.GetObject("rbEntradas.Image")));
            this.rbEntradas.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.rbEntradas.Location = new System.Drawing.Point(969, 13);
            this.rbEntradas.Name = "rbEntradas";
            this.rbEntradas.Size = new System.Drawing.Size(86, 19);
            this.rbEntradas.TabIndex = 1;
            this.rbEntradas.Text = "Entradas";
            this.rbEntradas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbEntradas.ThemeName = "Office2013Light";
            this.rbEntradas.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.rbEntradas.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbEntradas_ToggleStateChanged);
            // 
            // rbSalidas
            // 
            this.rbSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSalidas.Image = ((System.Drawing.Image)(resources.GetObject("rbSalidas.Image")));
            this.rbSalidas.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.rbSalidas.Location = new System.Drawing.Point(1061, 13);
            this.rbSalidas.Name = "rbSalidas";
            this.rbSalidas.Size = new System.Drawing.Size(77, 19);
            this.rbSalidas.TabIndex = 2;
            this.rbSalidas.TabStop = false;
            this.rbSalidas.Text = "Salidas";
            this.rbSalidas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbSalidas.ThemeName = "Office2013Light";
            this.rbSalidas.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbSalidas_ToggleStateChanged);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.gridControl);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1150, 364);
            this.radPanel1.TabIndex = 3;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnImportar);
            this.radPanel2.Controls.Add(this.rbSalidas);
            this.radPanel2.Controls.Add(this.rbEntradas);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1150, 38);
            this.radPanel2.TabIndex = 4;
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(573, 10);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(82, 19);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Text = "Importar";
            this.btnImportar.Visible = false;
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.radPanel1);
            this.radPanel3.Controls.Add(this.radPanel2);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel3.Location = new System.Drawing.Point(0, 33);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(1150, 402);
            this.radPanel3.TabIndex = 1;
            this.radPanel3.Text = "radPanel3";
            // 
            // frmDocu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 435);
            this.Controls.Add(this.radPanel3);
            this.Name = "frmDocu";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Movimientos";
            this.Controls.SetChildIndex(this.radPanel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.gridControl.ResumeLayout(false);
            this.gridControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelErrores)).EndInit();
            this.panelErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarModal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private System.Windows.Forms.ImageList imageList1;
        private Telerik.WinControls.UI.RadRadioButton rbSalidas;
        public Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadPanel panelErrores;
        private Telerik.WinControls.UI.RadButton btnGuardar;
        private Telerik.WinControls.UI.RadButton btnCerrarModal;
        private Telerik.WinControls.UI.RadGridView dgvErrores;
        private Telerik.WinControls.UI.RadButton btnImportar;
        public Telerik.WinControls.UI.RadRadioButton rbEntradas;
    }
}
