namespace Fac.UI.Win
{
    partial class frmRepGuiasAdministracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepGuiasAdministracion));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pnlCab = new Telerik.WinControls.UI.RadPanel();
            this.btnVerReporte = new Telerik.WinControls.UI.RadButton();
            this.btnCopiarTodo = new Telerik.WinControls.UI.RadButton();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPlantilla = new Telerik.WinControls.UI.RadLabel();
            this.txtPlantillaCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.lblTipo = new Telerik.WinControls.UI.RadLabel();
            this.txtTipoCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.txtTipoDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.txtPlantillaDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCab)).BeginInit();
            this.pnlCab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopiarTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlantilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantillaCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantillaDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCab
            // 
            this.pnlCab.BackColor = System.Drawing.Color.White;
            this.pnlCab.Controls.Add(this.btnVerReporte);
            this.pnlCab.Controls.Add(this.btnCopiarTodo);
            this.pnlCab.Controls.Add(this.btnBuscar);
            this.pnlCab.Controls.Add(this.panel1);
            this.pnlCab.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCab.Location = new System.Drawing.Point(0, 33);
            this.pnlCab.Name = "pnlCab";
            // 
            // 
            // 
            this.pnlCab.RootElement.AccessibleDescription = null;
            this.pnlCab.RootElement.AccessibleName = null;
            this.pnlCab.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.pnlCab.RootElement.AngleTransform = 0F;
            this.pnlCab.RootElement.FlipText = false;
            this.pnlCab.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCab.RootElement.Text = null;
            this.pnlCab.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.pnlCab.Size = new System.Drawing.Size(856, 35);
            this.pnlCab.TabIndex = 4;
            this.pnlCab.TabStop = false;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlCab.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // btnVerReporte
            // 
            this.btnVerReporte.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVerReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnVerReporte.Image")));
            this.btnVerReporte.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerReporte.Location = new System.Drawing.Point(788, 0);
            this.btnVerReporte.Name = "btnVerReporte";
            this.btnVerReporte.Size = new System.Drawing.Size(34, 35);
            this.btnVerReporte.TabIndex = 9;
            this.btnVerReporte.ThemeName = "Windows8";
            this.btnVerReporte.Click += new System.EventHandler(this.btnVerReporte_Click);
            // 
            // btnCopiarTodo
            // 
            this.btnCopiarTodo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopiarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiarTodo.Image")));
            this.btnCopiarTodo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCopiarTodo.Location = new System.Drawing.Point(822, 0);
            this.btnCopiarTodo.Name = "btnCopiarTodo";
            this.btnCopiarTodo.Size = new System.Drawing.Size(34, 35);
            this.btnCopiarTodo.TabIndex = 8;
            this.btnCopiarTodo.ThemeName = "Windows8";
            this.btnCopiarTodo.Click += new System.EventHandler(this.btnCopiarTodo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(726, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 35);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.ThemeName = "Windows8";
            this.btnBuscar.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPlantilla);
            this.panel1.Controls.Add(this.txtPlantillaCodigo);
            this.panel1.Controls.Add(this.lblTipo);
            this.panel1.Controls.Add(this.txtTipoCodigo);
            this.panel1.Controls.Add(this.txtTipoDescripcion);
            this.panel1.Controls.Add(this.txtPlantillaDescripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 35);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            // 
            // lblPlantilla
            // 
            this.lblPlantilla.Location = new System.Drawing.Point(317, 8);
            this.lblPlantilla.Name = "lblPlantilla";
            // 
            // 
            // 
            this.lblPlantilla.RootElement.AccessibleDescription = null;
            this.lblPlantilla.RootElement.AccessibleName = null;
            this.lblPlantilla.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPlantilla.RootElement.AngleTransform = 0F;
            this.lblPlantilla.RootElement.FlipText = false;
            this.lblPlantilla.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlantilla.RootElement.Text = null;
            this.lblPlantilla.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.lblPlantilla.Size = new System.Drawing.Size(51, 18);
            this.lblPlantilla.TabIndex = 4;
            this.lblPlantilla.Text = "Plantilla :";
            // 
            // txtPlantillaCodigo
            // 
            this.txtPlantillaCodigo.Location = new System.Drawing.Point(369, 7);
            this.txtPlantillaCodigo.Name = "txtPlantillaCodigo";
            // 
            // 
            // 
            this.txtPlantillaCodigo.RootElement.AccessibleDescription = null;
            this.txtPlantillaCodigo.RootElement.AccessibleName = null;
            this.txtPlantillaCodigo.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtPlantillaCodigo.RootElement.AngleTransform = 0F;
            this.txtPlantillaCodigo.RootElement.FlipText = false;
            this.txtPlantillaCodigo.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.txtPlantillaCodigo.RootElement.Text = null;
            this.txtPlantillaCodigo.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtPlantillaCodigo.Size = new System.Drawing.Size(46, 20);
            this.txtPlantillaCodigo.TabIndex = 5;
            this.txtPlantillaCodigo.Tag = "";
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(11, 7);
            this.lblTipo.Name = "lblTipo";
            // 
            // 
            // 
            this.lblTipo.RootElement.AccessibleDescription = null;
            this.lblTipo.RootElement.AccessibleName = null;
            this.lblTipo.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblTipo.RootElement.AngleTransform = 0F;
            this.lblTipo.RootElement.FlipText = false;
            this.lblTipo.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.lblTipo.RootElement.Text = null;
            this.lblTipo.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.lblTipo.Size = new System.Drawing.Size(34, 18);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo: ";
            // 
            // txtTipoCodigo
            // 
            this.txtTipoCodigo.Location = new System.Drawing.Point(63, 6);
            this.txtTipoCodigo.Name = "txtTipoCodigo";
            // 
            // 
            // 
            this.txtTipoCodigo.RootElement.AccessibleDescription = null;
            this.txtTipoCodigo.RootElement.AccessibleName = null;
            this.txtTipoCodigo.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtTipoCodigo.RootElement.AngleTransform = 0F;
            this.txtTipoCodigo.RootElement.FlipText = false;
            this.txtTipoCodigo.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.txtTipoCodigo.RootElement.Text = null;
            this.txtTipoCodigo.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtTipoCodigo.Size = new System.Drawing.Size(46, 20);
            this.txtTipoCodigo.TabIndex = 1;
            this.txtTipoCodigo.Tag = "";
            // 
            // txtTipoDescripcion
            // 
            this.txtTipoDescripcion.Enabled = false;
            this.txtTipoDescripcion.Location = new System.Drawing.Point(115, 6);
            this.txtTipoDescripcion.Name = "txtTipoDescripcion";
            // 
            // 
            // 
            this.txtTipoDescripcion.RootElement.AccessibleDescription = null;
            this.txtTipoDescripcion.RootElement.AccessibleName = null;
            this.txtTipoDescripcion.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtTipoDescripcion.RootElement.AngleTransform = 0F;
            this.txtTipoDescripcion.RootElement.FlipText = false;
            this.txtTipoDescripcion.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.txtTipoDescripcion.RootElement.Text = null;
            this.txtTipoDescripcion.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtTipoDescripcion.Size = new System.Drawing.Size(167, 20);
            this.txtTipoDescripcion.TabIndex = 2;
            // 
            // txtPlantillaDescripcion
            // 
            this.txtPlantillaDescripcion.Enabled = false;
            this.txtPlantillaDescripcion.Location = new System.Drawing.Point(421, 7);
            this.txtPlantillaDescripcion.Name = "txtPlantillaDescripcion";
            // 
            // 
            // 
            this.txtPlantillaDescripcion.RootElement.AccessibleDescription = null;
            this.txtPlantillaDescripcion.RootElement.AccessibleName = null;
            this.txtPlantillaDescripcion.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtPlantillaDescripcion.RootElement.AngleTransform = 0F;
            this.txtPlantillaDescripcion.RootElement.FlipText = false;
            this.txtPlantillaDescripcion.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.txtPlantillaDescripcion.RootElement.Text = null;
            this.txtPlantillaDescripcion.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtPlantillaDescripcion.Size = new System.Drawing.Size(299, 20);
            this.txtPlantillaDescripcion.TabIndex = 6;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 68);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            // 
            // 
            // 
            this.gridControl.RootElement.AccessibleDescription = null;
            this.gridControl.RootElement.AccessibleName = null;
            this.gridControl.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.gridControl.RootElement.AngleTransform = 0F;
            this.gridControl.RootElement.FlipText = false;
            this.gridControl.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl.RootElement.Text = null;
            this.gridControl.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.gridControl.Size = new System.Drawing.Size(856, 337);
            this.gridControl.TabIndex = 23;
            this.gridControl.TabStop = false;
            this.gridControl.Text = "radGridView1";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // frmRepGuiasAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 405);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlCab);
            this.Name = "frmRepGuiasAdministracion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte de guias";
            this.Load += new System.EventHandler(this.frmRepGuiasAdministracion_Load);
            this.Controls.SetChildIndex(this.pnlCab, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCab)).EndInit();
            this.pnlCab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnVerReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopiarTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlantilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantillaCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantillaDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlCab;
        private Telerik.WinControls.UI.RadButton btnVerReporte;
        private Telerik.WinControls.UI.RadButton btnCopiarTodo;
        private Telerik.WinControls.UI.RadButton btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel lblPlantilla;
        private Telerik.WinControls.UI.RadTextBox txtPlantillaCodigo;
        private Telerik.WinControls.UI.RadLabel lblTipo;
        private Telerik.WinControls.UI.RadTextBox txtTipoCodigo;
        private Telerik.WinControls.UI.RadTextBox txtTipoDescripcion;
        private Telerik.WinControls.UI.RadTextBox txtPlantillaDescripcion;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    }
}
