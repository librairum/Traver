namespace Inv.UI.Win
{
    partial class frmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbVer = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbVista = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbRefrescar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbImportar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbExportarMovimientos = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbImportarMP = new Telerik.WinControls.UI.CommandBarButton();
            this.toolBar = new Telerik.WinControls.UI.RadCommandBar();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            // 
            // commandBarRowElement3
            // 
            this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
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
            this.cbbEditar,
            this.cbbEliminar,
            this.cbbVer,
            this.commandBarSeparator1,
            this.cbbVista,
            this.cbbImprimir,
            this.commandBarSeparator2,
            this.cbbRefrescar,
            this.cbbImportar,
            this.cbbExportarMovimientos,
            this.cbbImportarMP});
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
            // cbbEditar
            // 
            this.cbbEditar.AccessibleDescription = "Modificar";
            this.cbbEditar.AccessibleName = "Modificar";
            this.cbbEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEditar.DisplayName = "Modificar";
            this.cbbEditar.Image = ((System.Drawing.Image)(resources.GetObject("cbbEditar.Image")));
            this.cbbEditar.Name = "cbbEditar";
            this.cbbEditar.Text = "Modificar";
            this.cbbEditar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEditar.ToolTipText = "Modificar";
            this.cbbEditar.Click += new System.EventHandler(this.cbbEditar_Click);
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
            // cbbVer
            // 
            this.cbbVer.AccessibleDescription = "cbbVer";
            this.cbbVer.AccessibleName = "cbbVer";
            this.cbbVer.DisplayName = "Ver";
            this.cbbVer.Image = ((System.Drawing.Image)(resources.GetObject("cbbVer.Image")));
            this.cbbVer.Name = "cbbVer";
            this.cbbVer.Text = "commandBarButton1";
            this.cbbVer.Click += new System.EventHandler(this.cbbVer_Click);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // cbbVista
            // 
            this.cbbVista.AccessibleDescription = "Vista previa";
            this.cbbVista.AccessibleName = "Vista previa";
            this.cbbVista.DisplayName = "commandBarButton1";
            this.cbbVista.Image = ((System.Drawing.Image)(resources.GetObject("cbbVista.Image")));
            this.cbbVista.Name = "cbbVista";
            this.cbbVista.Text = "Vista previa";
            this.cbbVista.ToolTipText = "Vista previa";
            this.cbbVista.Click += new System.EventHandler(this.cbbVista_Click);
            // 
            // cbbImprimir
            // 
            this.cbbImprimir.AccessibleDescription = "Imprimir";
            this.cbbImprimir.AccessibleName = "Imprimir";
            this.cbbImprimir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbImprimir.DisplayName = "Imprimir";
            this.cbbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cbbImprimir.Image")));
            this.cbbImprimir.Name = "cbbImprimir";
            this.cbbImprimir.Text = "Imprimir";
            this.cbbImprimir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbImprimir.ToolTipText = "Imprimir";
            this.cbbImprimir.Click += new System.EventHandler(this.cbbImprimir_Click);
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
            this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // cbbRefrescar
            // 
            this.cbbRefrescar.AccessibleDescription = "cbbRefrescar";
            this.cbbRefrescar.AccessibleName = "cbbRefrescar";
            this.cbbRefrescar.DisplayName = "Refrescar";
            this.cbbRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("cbbRefrescar.Image")));
            this.cbbRefrescar.Name = "cbbRefrescar";
            this.cbbRefrescar.Text = "Refrescar";
            this.cbbRefrescar.ToolTipText = "Refresar la lista";
            this.cbbRefrescar.Click += new System.EventHandler(this.cbbRefrescar_Click);
            // 
            // cbbImportar
            // 
            this.cbbImportar.AccessibleDescription = "btnImportar";
            this.cbbImportar.AccessibleName = "btnImportar";
            this.cbbImportar.DisplayName = "commandBarButton1";
            this.cbbImportar.Image = ((System.Drawing.Image)(resources.GetObject("cbbImportar.Image")));
            this.cbbImportar.Name = "cbbImportar";
            this.cbbImportar.Text = "importar";
            this.cbbImportar.ToolTipText = "Importar documento";
            this.cbbImportar.Click += new System.EventHandler(this.cbbImportar_Click);
            // 
            // cbbExportarMovimientos
            // 
            this.cbbExportarMovimientos.AccessibleDescription = "commandBarButton1";
            this.cbbExportarMovimientos.AccessibleName = "commandBarButton1";
            this.cbbExportarMovimientos.DisplayName = "commandBarButton1";
            this.cbbExportarMovimientos.Image = ((System.Drawing.Image)(resources.GetObject("cbbExportarMovimientos.Image")));
            this.cbbExportarMovimientos.Name = "cbbExportarMovimientos";
            this.cbbExportarMovimientos.Text = "commandBarButton1";
            this.cbbExportarMovimientos.Click += new System.EventHandler(this.cbbExportarMovimientos_Click);
            // 
            // cbbImportarMP
            // 
            this.cbbImportarMP.AccessibleDescription = "Importar Materia Prima";
            this.cbbImportarMP.AccessibleName = "Importar Materia Prima";
            this.cbbImportarMP.DisplayName = "commandBarButton1";
            this.cbbImportarMP.Image = ((System.Drawing.Image)(resources.GetObject("cbbImportarMP.Image")));
            this.cbbImportarMP.Name = "cbbImportarMP";
            this.cbbImportarMP.Text = "Importar Materia Prima";
            this.cbbImportarMP.ToolTipText = "Importar Materia Prima";
            this.cbbImportarMP.Click += new System.EventHandler(this.cbbImportarMP_Click);
            // 
            // toolBar
            // 
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.toolBar.Size = new System.Drawing.Size(507, 59);
            this.toolBar.TabIndex = 2;
            this.toolBar.Text = "radCommandBar1";
            this.toolBar.ThemeName = "Office2013Light";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 407);
            this.Controls.Add(this.toolBar);
            this.Name = "frmBase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton cbbNuevo;
        private Telerik.WinControls.UI.CommandBarButton cbbEditar;
        private Telerik.WinControls.UI.CommandBarButton cbbEliminar;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton cbbVista;
        private Telerik.WinControls.UI.CommandBarButton cbbImprimir;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.UI.CommandBarButton cbbRefrescar;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.CommandBarButton cbbVer;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarButton cbbImportar;
        private Telerik.WinControls.UI.CommandBarButton cbbExportarMovimientos;
        protected Telerik.WinControls.UI.RadCommandBar toolBar;
        private Telerik.WinControls.UI.CommandBarButton cbbImportarMP;        

    }
}
