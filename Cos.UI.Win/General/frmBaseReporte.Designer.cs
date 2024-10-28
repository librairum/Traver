namespace Cos.UI.Win
{
    partial class frmBaseReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseReporte));
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbVista = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbRefrescar = new Telerik.WinControls.UI.CommandBarButton();
            this.toolBar = new Telerik.WinControls.UI.RadCommandBar();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
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
            this.commandBarStripElement1.BorderBottomWidth = 1F;
            this.commandBarStripElement1.BorderLeftWidth = 1F;
            this.commandBarStripElement1.BorderRightWidth = 1F;
            this.commandBarStripElement1.BorderTopWidth = 1F;
            this.commandBarStripElement1.BorderWidth = 1F;
            this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarSeparator1,
            this.cbbVista,
            this.cbbImprimir,
            this.commandBarSeparator2,
            this.cbbRefrescar});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
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
            this.cbbVista.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVista.DisplayName = "commandBarButton1";
            this.cbbVista.Image = ((System.Drawing.Image)(resources.GetObject("cbbVista.Image")));
            this.cbbVista.Name = "cbbVista";
            this.cbbVista.Text = "Vista previa";
            this.cbbVista.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
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
            this.cbbRefrescar.DisplayName = "commandBarButton1";
            this.cbbRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("cbbRefrescar.Image")));
            this.cbbRefrescar.Name = "cbbRefrescar";
            this.cbbRefrescar.Text = "Refrescar";
            this.cbbRefrescar.Click += new System.EventHandler(this.cbbRefrescar_Click);
            // 
            // toolBar
            // 
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.toolBar.Size = new System.Drawing.Size(475, 59);
            this.toolBar.TabIndex = 2;
            this.toolBar.Text = "radCommandBar1";
            this.toolBar.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.toolBar.GetChildAt(0))).DrawBorder = true;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.toolBar.GetChildAt(0))).BorderWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.toolBar.GetChildAt(0))).BorderLeftWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.toolBar.GetChildAt(0))).BorderTopWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.toolBar.GetChildAt(0))).BorderRightWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.toolBar.GetChildAt(0))).BorderBottomWidth = 1F;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.toolBar);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(475, 33);
            this.radPanel1.TabIndex = 3;
            // 
            // frmBaseReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 405);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmBaseReporte";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton cbbVista;
        private Telerik.WinControls.UI.CommandBarButton cbbImprimir;
        private Telerik.WinControls.UI.RadCommandBar toolBar;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarButton cbbRefrescar;        

    }
}
