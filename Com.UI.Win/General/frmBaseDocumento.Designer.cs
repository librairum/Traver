namespace Com.UI.Win
{
    partial class frmBaseDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseDocumento));
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.toolBar = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbAnulado = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbCopiar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbVer = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbAgregarDetalle = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbGeneraPDF = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbVistaPreliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbGenerarFE = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbVerFE = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbDarBajaFE = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbCancelar = new Telerik.WinControls.UI.CommandBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.toolBar.Size = new System.Drawing.Size(388, 33);
            this.toolBar.TabIndex = 4;
            this.toolBar.Text = "radCommandBar1";
            this.toolBar.ThemeName = "Office2013Light";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            this.commandBarRowElement1.Text = "";
            this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cbbNuevo,
            this.cbbEliminar,
            this.cbbEditar,
            this.cbbAnulado,
            this.cbbCopiar,
            this.cbbVer,
            this.commandBarButton1,
            this.cbbAgregarDetalle,
            this.commandBarButton2,
            this.cbbGeneraPDF,
            this.cbbImprimir,
            this.cbbVistaPreliminar,
            this.commandBarButton3,
            this.cbbGenerarFE,
            this.cbbVerFE,
            this.cbbDarBajaFE,
            this.cbbCancelar});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // cbbNuevo
            // 
            this.cbbNuevo.AccessibleDescription = "Agregar";
            this.cbbNuevo.AccessibleName = "Agregar";
            this.cbbNuevo.AutoSize = true;
            this.cbbNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbNuevo.DisplayName = "Nuevo";
            this.cbbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("cbbNuevo.Image")));
            this.cbbNuevo.Name = "cbbNuevo";
            this.cbbNuevo.Text = "Agregar";
            this.cbbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbbNuevo.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cbbNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbNuevo.ToolTipText = "Agregar";
            this.cbbNuevo.Click += new System.EventHandler(this.cbbNuevo_Click);
            // 
            // cbbEliminar
            // 
            this.cbbEliminar.AccessibleDescription = "Eliminar";
            this.cbbEliminar.AccessibleName = "Eliminar";
            this.cbbEliminar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEliminar.DisplayName = "Eliminar";
            this.cbbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("cbbEliminar.Image")));
            this.cbbEliminar.Name = "cbbEliminar";
            this.cbbEliminar.Text = "Eliminar";
            this.cbbEliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEliminar.ToolTipText = "Eliminar";
            this.cbbEliminar.Click += new System.EventHandler(this.cbbEliminar_Click);
            // 
            // cbbEditar
            // 
            this.cbbEditar.AccessibleDescription = "cbbEditar";
            this.cbbEditar.AccessibleName = "cbbEditar";
            this.cbbEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEditar.DisplayName = "Modificar";
            this.cbbEditar.Image = ((System.Drawing.Image)(resources.GetObject("cbbEditar.Image")));
            this.cbbEditar.Name = "cbbEditar";
            this.cbbEditar.Text = "Modificar";
            this.cbbEditar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEditar.ToolTipText = "Modificar";
            this.cbbEditar.Click += new System.EventHandler(this.cbbEditar_Click);
            // 
            // cbbAnulado
            // 
            this.cbbAnulado.AccessibleDescription = "cbbAnulado";
            this.cbbAnulado.AccessibleName = "cbbAnulado";
            this.cbbAnulado.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbAnulado.DisplayName = "Cambiar estado";
            this.cbbAnulado.Image = ((System.Drawing.Image)(resources.GetObject("cbbAnulado.Image")));
            this.cbbAnulado.Name = "cbbAnulado";
            this.cbbAnulado.Text = "Cambiar estado";
            this.cbbAnulado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbAnulado.ToolTipText = "Cambio estado";
            this.cbbAnulado.Click += new System.EventHandler(this.cbbAnulado_Click);
            // 
            // cbbCopiar
            // 
            this.cbbCopiar.AccessibleDescription = "cbbCopiar";
            this.cbbCopiar.AccessibleName = "cbbCopiar";
            this.cbbCopiar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbCopiar.DisplayName = "Ver";
            this.cbbCopiar.Image = ((System.Drawing.Image)(resources.GetObject("cbbCopiar.Image")));
            this.cbbCopiar.Name = "cbbCopiar";
            this.cbbCopiar.Text = "commandBarButton1";
            this.cbbCopiar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbCopiar.ToolTipText = "Copiar Documento";
            this.cbbCopiar.Click += new System.EventHandler(this.cbbCopiar_Click);
            // 
            // cbbVer
            // 
            this.cbbVer.AccessibleDescription = "Ver";
            this.cbbVer.AccessibleName = "Ver";
            this.cbbVer.DisplayName = "commandBarButton4";
            this.cbbVer.Image = ((System.Drawing.Image)(resources.GetObject("cbbVer.Image")));
            this.cbbVer.Name = "cbbVer";
            this.cbbVer.Text = "Ver";
            this.cbbVer.ToolTipText = "Ver Documento";
            this.cbbVer.Click += new System.EventHandler(this.cbbVer_Click);
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.AccessibleDescription = "___";
            this.commandBarButton1.AccessibleName = "___";
            this.commandBarButton1.DisplayName = "commandBarButton1";
            this.commandBarButton1.DrawText = true;
            this.commandBarButton1.EnableImageTransparency = false;
            this.commandBarButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.commandBarButton1.Image = null;
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.Text = "___";
            // 
            // cbbAgregarDetalle
            // 
            this.cbbAgregarDetalle.AccessibleDescription = "cbbAgregarDetalle";
            this.cbbAgregarDetalle.AccessibleName = "cbbAgregarDetalle";
            this.cbbAgregarDetalle.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbAgregarDetalle.DisplayName = "commandBarButton1";
            this.cbbAgregarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("cbbAgregarDetalle.Image")));
            this.cbbAgregarDetalle.Name = "cbbAgregarDetalle";
            this.cbbAgregarDetalle.Text = "Vista previa";
            this.cbbAgregarDetalle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbAgregarDetalle.ToolTipText = "Agregar Detalle";
            this.cbbAgregarDetalle.Click += new System.EventHandler(this.cbbAgregarDetalle_Click);
            // 
            // commandBarButton2
            // 
            this.commandBarButton2.AccessibleDescription = "___";
            this.commandBarButton2.AccessibleName = "___";
            this.commandBarButton2.DisplayName = "commandBarButton2";
            this.commandBarButton2.DrawText = true;
            this.commandBarButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.commandBarButton2.Image = null;
            this.commandBarButton2.Name = "commandBarButton2";
            this.commandBarButton2.Text = "___";
            // 
            // cbbGeneraPDF
            // 
            this.cbbGeneraPDF.AccessibleDescription = "cbbGeneraPDF";
            this.cbbGeneraPDF.AccessibleName = "cbbGeneraPDF";
            this.cbbGeneraPDF.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGeneraPDF.DisplayName = "Imprimir";
            this.cbbGeneraPDF.Image = ((System.Drawing.Image)(resources.GetObject("cbbGeneraPDF.Image")));
            this.cbbGeneraPDF.Name = "cbbGeneraPDF";
            this.cbbGeneraPDF.Text = "Generar PDF";
            this.cbbGeneraPDF.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGeneraPDF.ToolTipText = "Generar PDF";
            this.cbbGeneraPDF.Click += new System.EventHandler(this.cbbGeneraPDF_Click);
            // 
            // cbbImprimir
            // 
            this.cbbImprimir.AccessibleDescription = "cbbImprimir";
            this.cbbImprimir.AccessibleName = "cbbImprimir";
            this.cbbImprimir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbImprimir.DisplayName = "Refrescar";
            this.cbbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cbbImprimir.Image")));
            this.cbbImprimir.Name = "cbbImprimir";
            this.cbbImprimir.Text = "Refrescar";
            this.cbbImprimir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbImprimir.ToolTipText = "Imprimir";
            this.cbbImprimir.Click += new System.EventHandler(this.cbbImprimir_Click);
            // 
            // cbbVistaPreliminar
            // 
            this.cbbVistaPreliminar.AccessibleDescription = "btnImportar";
            this.cbbVistaPreliminar.AccessibleName = "btnImportar";
            this.cbbVistaPreliminar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVistaPreliminar.DisplayName = "commandBarButton1";
            this.cbbVistaPreliminar.Image = ((System.Drawing.Image)(resources.GetObject("cbbVistaPreliminar.Image")));
            this.cbbVistaPreliminar.Name = "cbbVistaPreliminar";
            this.cbbVistaPreliminar.Text = "importar";
            this.cbbVistaPreliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVistaPreliminar.ToolTipText = "Vista preliminar";
            this.cbbVistaPreliminar.Click += new System.EventHandler(this.cbbVistaPreliminar_Click);
            // 
            // commandBarButton3
            // 
            this.commandBarButton3.AccessibleDescription = "___";
            this.commandBarButton3.AccessibleName = "___";
            this.commandBarButton3.DisplayName = "commandBarButton3";
            this.commandBarButton3.DrawText = true;
            this.commandBarButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.commandBarButton3.Image = null;
            this.commandBarButton3.Name = "commandBarButton3";
            this.commandBarButton3.Text = "___";
            // 
            // cbbGenerarFE
            // 
            this.cbbGenerarFE.AccessibleDescription = "commandBarButton1";
            this.cbbGenerarFE.AccessibleName = "commandBarButton1";
            this.cbbGenerarFE.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGenerarFE.DisplayName = "commandBarButton1";
            this.cbbGenerarFE.Image = ((System.Drawing.Image)(resources.GetObject("cbbGenerarFE.Image")));
            this.cbbGenerarFE.Name = "cbbGenerarFE";
            this.cbbGenerarFE.Text = "commandBarButton1";
            this.cbbGenerarFE.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGenerarFE.ToolTipText = "Generar factura electronica";
            this.cbbGenerarFE.Click += new System.EventHandler(this.cbbGenerarFE_Click);
            // 
            // cbbVerFE
            // 
            this.cbbVerFE.AccessibleDescription = "commandBarButton2";
            this.cbbVerFE.AccessibleName = "commandBarButton2";
            this.cbbVerFE.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVerFE.DisplayName = "commandBarButton2";
            this.cbbVerFE.Image = ((System.Drawing.Image)(resources.GetObject("cbbVerFE.Image")));
            this.cbbVerFE.Name = "cbbVerFE";
            this.cbbVerFE.Text = "commandBarButton2";
            this.cbbVerFE.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVerFE.ToolTipText = "Ver Factura Electronica";
            this.cbbVerFE.Click += new System.EventHandler(this.cbbVerFE_Click);
            // 
            // cbbDarBajaFE
            // 
            this.cbbDarBajaFE.AccessibleDescription = "commandBarButton3";
            this.cbbDarBajaFE.AccessibleName = "commandBarButton3";
            this.cbbDarBajaFE.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbDarBajaFE.DisplayName = "commandBarButton3";
            this.cbbDarBajaFE.Image = ((System.Drawing.Image)(resources.GetObject("cbbDarBajaFE.Image")));
            this.cbbDarBajaFE.Name = "cbbDarBajaFE";
            this.cbbDarBajaFE.Text = "commandBarButton3";
            this.cbbDarBajaFE.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbDarBajaFE.ToolTipText = "Dar baja Factura electronica";
            this.cbbDarBajaFE.Click += new System.EventHandler(this.cbbDarBajaFE_Click);
            // 
            // cbbCancelar
            // 
            this.cbbCancelar.AccessibleDescription = "commandBarButton4";
            this.cbbCancelar.AccessibleName = "commandBarButton4";
            this.cbbCancelar.DisplayName = "commandBarButton4";
            this.cbbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cbbCancelar.Image")));
            this.cbbCancelar.Name = "cbbCancelar";
            this.cbbCancelar.Text = "commandBarButton4";
            this.cbbCancelar.Click += new System.EventHandler(this.cbbCancelar_Click);
            // 
            // frmBaseDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 413);
            this.Controls.Add(this.toolBar);
            this.Name = "frmBaseDocumento";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmBaseDocumento2";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadCommandBar toolBar;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton cbbNuevo;
        private Telerik.WinControls.UI.CommandBarButton cbbEliminar;
        private Telerik.WinControls.UI.CommandBarButton cbbEditar;
        private Telerik.WinControls.UI.CommandBarButton cbbAnulado;
        private Telerik.WinControls.UI.CommandBarButton cbbCopiar;
        private Telerik.WinControls.UI.CommandBarButton cbbAgregarDetalle;
        private Telerik.WinControls.UI.CommandBarButton cbbGeneraPDF;
        private Telerik.WinControls.UI.CommandBarButton cbbImprimir;
        private Telerik.WinControls.UI.CommandBarButton cbbVistaPreliminar;
        private Telerik.WinControls.UI.CommandBarButton cbbGenerarFE;
        private Telerik.WinControls.UI.CommandBarButton cbbVerFE;
        private Telerik.WinControls.UI.CommandBarButton cbbDarBajaFE;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton3;
        private Telerik.WinControls.UI.CommandBarButton cbbVer;
        private Telerik.WinControls.UI.CommandBarButton cbbCancelar;
    }
}
