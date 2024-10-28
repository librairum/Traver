namespace Fac.UI.Win
{
    partial class frmPackingList
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackingList));
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.gpxImportarPacking = new Telerik.WinControls.UI.RadGroupBox();
            this.txtImportado = new Telerik.WinControls.UI.RadTextBox();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.gridValidacion = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnGuardarImportacion = new Telerik.WinControls.UI.RadButton();
            this.btnCancelarImportacion = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            this.gridControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpxImportarPacking)).BeginInit();
            this.gpxImportarPacking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImportado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridValidacion.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardarImportacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarImportacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Controls.Add(this.gpxImportarPacking);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1022, 492);
            this.gridControl.TabIndex = 3;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellDoubleClick);
            this.gridControl.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellValueChanged);
            // 
            // gpxImportarPacking
            // 
            this.gpxImportarPacking.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gpxImportarPacking.Controls.Add(this.txtImportado);
            this.gpxImportarPacking.Controls.Add(this.radPanel2);
            this.gpxImportarPacking.Controls.Add(this.radPanel1);
            this.gpxImportarPacking.HeaderText = "Ingresar datos packing list";
            this.gpxImportarPacking.Location = new System.Drawing.Point(12, 22);
            this.gpxImportarPacking.Name = "gpxImportarPacking";
            this.gpxImportarPacking.Size = new System.Drawing.Size(998, 446);
            this.gpxImportarPacking.TabIndex = 75;
            this.gpxImportarPacking.Text = "Ingresar datos packing list";
            this.gpxImportarPacking.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gpxImportarPacking_MouseDown);
            this.gpxImportarPacking.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gpxImportarPacking_MouseMove);
            // 
            // txtImportado
            // 
            this.txtImportado.AutoSize = false;
            this.txtImportado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImportado.Location = new System.Drawing.Point(2, 18);
            this.txtImportado.Multiline = true;
            this.txtImportado.Name = "txtImportado";
            this.txtImportado.Size = new System.Drawing.Size(994, 141);
            this.txtImportado.TabIndex = 29;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridValidacion);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(2, 159);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(994, 264);
            this.radPanel2.TabIndex = 73;
            // 
            // gridValidacion
            // 
            this.gridValidacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridValidacion.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridValidacion.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridValidacion.Name = "gridValidacion";
            this.gridValidacion.Size = new System.Drawing.Size(994, 264);
            this.gridValidacion.TabIndex = 74;
            this.gridValidacion.Text = "radGridView1";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnGuardarImportacion);
            this.radPanel1.Controls.Add(this.btnCancelarImportacion);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(2, 423);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(994, 21);
            this.radPanel1.TabIndex = 72;
            // 
            // btnGuardarImportacion
            // 
            this.btnGuardarImportacion.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardarImportacion.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarImportacion.Image")));
            this.btnGuardarImportacion.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardarImportacion.Location = new System.Drawing.Point(950, 0);
            this.btnGuardarImportacion.Name = "btnGuardarImportacion";
            this.btnGuardarImportacion.Size = new System.Drawing.Size(22, 21);
            this.btnGuardarImportacion.TabIndex = 31;
            this.btnGuardarImportacion.ThemeName = "Office2013Light";
            this.btnGuardarImportacion.Click += new System.EventHandler(this.btnGuardarImportacion_Click);
            // 
            // btnCancelarImportacion
            // 
            this.btnCancelarImportacion.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelarImportacion.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarImportacion.Image")));
            this.btnCancelarImportacion.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelarImportacion.Location = new System.Drawing.Point(972, 0);
            this.btnCancelarImportacion.Name = "btnCancelarImportacion";
            this.btnCancelarImportacion.Size = new System.Drawing.Size(22, 21);
            this.btnCancelarImportacion.TabIndex = 15;
            this.btnCancelarImportacion.ThemeName = "Office2013Light";
            this.btnCancelarImportacion.Click += new System.EventHandler(this.btnCancelarImportacion_Click);
            // 
            // frmPackingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 525);
            this.Controls.Add(this.gridControl);
            this.Name = "frmPackingList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "PackingList";
            this.Load += new System.EventHandler(this.frmPackingList_Load);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.gridControl.ResumeLayout(false);
            this.gridControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpxImportarPacking)).EndInit();
            this.gpxImportarPacking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtImportado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridValidacion.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardarImportacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarImportacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gpxImportarPacking;
        private Telerik.WinControls.UI.RadTextBox txtImportado;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnGuardarImportacion;
        private Telerik.WinControls.UI.RadButton btnCancelarImportacion;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView gridValidacion;
        internal Telerik.WinControls.UI.RadGridView gridControl;
    }
}
