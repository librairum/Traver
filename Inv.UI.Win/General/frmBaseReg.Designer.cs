namespace Inv.UI.Win
{
    partial class frmBaseReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseReg));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbCancelar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbVistaPrevia = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cmdPrimero = new Telerik.WinControls.UI.CommandBarButton();
            this.cmdAnterior = new Telerik.WinControls.UI.CommandBarButton();
            this.cmdSiguiente = new Telerik.WinControls.UI.CommandBarButton();
            this.cmdUltimo = new Telerik.WinControls.UI.CommandBarButton();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Ayuda";
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.AccessibleDescription = "Guardar";
            this.commandBarButton1.AccessibleName = "Guardar";
            this.commandBarButton1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.DisplayName = "commandBarButton1";
            this.commandBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton1.Image")));
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.Text = "Guardar";
            this.commandBarButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.ToolTipText = "Guardar";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1,
            this.commandBarStripElement2});
            this.commandBarRowElement1.Text = "";
            this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cbbGuardar,
            this.cbbCancelar,
            this.commandBarSeparator1,
            this.cbbVistaPrevia,
            this.cbbImprimir,
            this.cbbNuevo,
            this.cbbEditar,
            this.cbbEliminar});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cbbGuardar
            // 
            this.cbbGuardar.AccessibleDescription = "Guardar";
            this.cbbGuardar.AccessibleName = "Guardar";
            this.cbbGuardar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGuardar.DisplayName = "commandBarButton1";
            this.cbbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cbbGuardar.Image")));
            this.cbbGuardar.Name = "cbbGuardar";
            this.cbbGuardar.Text = "Guardar";
            this.cbbGuardar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGuardar.ToolTipText = "Guardar";
            this.cbbGuardar.Click += new System.EventHandler(this.cbbGuardar_Click);
            // 
            // cbbCancelar
            // 
            this.cbbCancelar.AccessibleDescription = "Cancelar";
            this.cbbCancelar.AccessibleName = "Cancelar";
            this.cbbCancelar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbCancelar.DisplayName = "commandBarButton2";
            this.cbbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cbbCancelar.Image")));
            this.cbbCancelar.Name = "cbbCancelar";
            this.cbbCancelar.Text = "Cancelar";
            this.cbbCancelar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbCancelar.ToolTipText = "Cancelar";
            this.cbbCancelar.Click += new System.EventHandler(this.cbbCancelar_Click);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.BorderBottomColor = System.Drawing.SystemColors.ControlDarkDark;
            this.commandBarSeparator1.BorderInnerColor = System.Drawing.SystemColors.ControlDarkDark;
            this.commandBarSeparator1.BorderLeftColor = System.Drawing.SystemColors.ControlDarkDark;
            this.commandBarSeparator1.BorderRightColor = System.Drawing.SystemColors.ControlDarkDark;
            this.commandBarSeparator1.BorderTopColor = System.Drawing.SystemColors.ControlDarkDark;
            this.commandBarSeparator1.BorderWidth = 2F;
            this.commandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // cbbVistaPrevia
            // 
            this.cbbVistaPrevia.AccessibleDescription = "Vista previa";
            this.cbbVistaPrevia.AccessibleName = "VistaPrevia";
            this.cbbVistaPrevia.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVistaPrevia.DisplayName = "commandBarButton1";
            this.cbbVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("cbbVistaPrevia.Image")));
            this.cbbVistaPrevia.Name = "cbbVistaPrevia";
            this.cbbVistaPrevia.Text = "Vista previa";
            this.cbbVistaPrevia.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVistaPrevia.ToolTipText = "Vista previa";
            this.cbbVistaPrevia.Click += new System.EventHandler(this.cbbVistaPrevia_Click);
            // 
            // cbbImprimir
            // 
            this.cbbImprimir.AccessibleDescription = "Imprimir";
            this.cbbImprimir.AccessibleName = "Imprimir";
            this.cbbImprimir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbImprimir.DisplayName = "commandBarButton1";
            this.cbbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cbbImprimir.Image")));
            this.cbbImprimir.Name = "cbbImprimir";
            this.cbbImprimir.Text = "Imprimir";
            this.cbbImprimir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbImprimir.ToolTipText = "Imprimir";
            this.cbbImprimir.Click += new System.EventHandler(this.cbbImprimir_Click);
            // 
            // cbbNuevo
            // 
            this.cbbNuevo.AccessibleDescription = "commandBarButton1";
            this.cbbNuevo.AccessibleName = "commandBarButton1";
            this.cbbNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbNuevo.DisplayName = "commandBarButton1";
            this.cbbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("cbbNuevo.Image")));
            this.cbbNuevo.Name = "cbbNuevo";
            this.cbbNuevo.Tag = "Nuevo";
            this.cbbNuevo.Text = "commandBarButton1";
            this.cbbNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbNuevo.Click += new System.EventHandler(this.cbbNuevo_Click);
            // 
            // cbbEditar
            // 
            this.cbbEditar.AccessibleDescription = "commandBarButton2";
            this.cbbEditar.AccessibleName = "commandBarButton2";
            this.cbbEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEditar.DisplayName = "commandBarButton2";
            this.cbbEditar.Image = ((System.Drawing.Image)(resources.GetObject("cbbEditar.Image")));
            this.cbbEditar.Name = "cbbEditar";
            this.cbbEditar.Tag = "Modificar";
            this.cbbEditar.Text = "commandBarButton2";
            this.cbbEditar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEditar.Click += new System.EventHandler(this.cbbEditar_Click);
            // 
            // cbbEliminar
            // 
            this.cbbEliminar.AccessibleDescription = "commandBarButton2";
            this.cbbEliminar.AccessibleName = "commandBarButton2";
            this.cbbEliminar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEliminar.DisplayName = "commandBarButton2";
            this.cbbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("cbbEliminar.Image")));
            this.cbbEliminar.Name = "cbbEliminar";
            this.cbbEliminar.Text = "commandBarButton2";
            this.cbbEliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEliminar.Click += new System.EventHandler(this.cbbEliminar_Click);
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cmdPrimero,
            this.cmdAnterior,
            this.cmdSiguiente,
            this.cmdUltimo});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            this.commandBarStripElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmdPrimero
            // 
            this.cmdPrimero.AccessibleDescription = "commandBarButton1";
            this.cmdPrimero.AccessibleName = "commandBarButton1";
            this.cmdPrimero.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdPrimero.DisplayName = "commandBarButton1";
            this.cmdPrimero.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrimero.Image")));
            this.cmdPrimero.Name = "cmdPrimero";
            this.cmdPrimero.Text = "<<";
            this.cmdPrimero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdPrimero.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdPrimero.Click += new System.EventHandler(this.cmdPrimero_Click);
            // 
            // cmdAnterior
            // 
            this.cmdAnterior.AccessibleDescription = "commandBarButton2";
            this.cmdAnterior.AccessibleName = "commandBarButton2";
            this.cmdAnterior.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdAnterior.DisplayName = "commandBarButton2";
            this.cmdAnterior.Image = ((System.Drawing.Image)(resources.GetObject("cmdAnterior.Image")));
            this.cmdAnterior.Name = "cmdAnterior";
            this.cmdAnterior.Text = "<";
            this.cmdAnterior.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdAnterior.Click += new System.EventHandler(this.cmdAnterior_Click);
            // 
            // cmdSiguiente
            // 
            this.cmdSiguiente.AccessibleDescription = "commandBarButton3";
            this.cmdSiguiente.AccessibleName = "commandBarButton3";
            this.cmdSiguiente.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdSiguiente.DisplayName = "commandBarButton3";
            this.cmdSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("cmdSiguiente.Image")));
            this.cmdSiguiente.Name = "cmdSiguiente";
            this.cmdSiguiente.Text = ">";
            this.cmdSiguiente.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdSiguiente.Click += new System.EventHandler(this.cmdSiguiente_Click);
            // 
            // cmdUltimo
            // 
            this.cmdUltimo.AccessibleDescription = "commandBarButton4";
            this.cmdUltimo.AccessibleName = "commandBarButton4";
            this.cmdUltimo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdUltimo.DisplayName = "commandBarButton4";
            this.cmdUltimo.Image = ((System.Drawing.Image)(resources.GetObject("cmdUltimo.Image")));
            this.cmdUltimo.Name = "cmdUltimo";
            this.cmdUltimo.Text = ">>";
            this.cmdUltimo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdUltimo.Click += new System.EventHandler(this.cmdUltimo_Click);
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(471, 59);
            this.radCommandBar1.TabIndex = 3;
            this.radCommandBar1.Text = "radCommandBar1";
            this.radCommandBar1.ThemeName = "Office2013Light";
            // 
            // frmBaseReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 426);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "frmBaseReg";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2013Light";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaseReg_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBaseReg_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        protected System.Windows.Forms.ToolTip toolTip;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton cbbGuardar;
        private Telerik.WinControls.UI.CommandBarButton cbbCancelar;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton cbbVistaPrevia;
        private Telerik.WinControls.UI.CommandBarButton cbbImprimir;
        private Telerik.WinControls.UI.CommandBarButton cbbNuevo;
        private Telerik.WinControls.UI.CommandBarButton cbbEditar;
        private Telerik.WinControls.UI.CommandBarButton cbbEliminar;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarButton cmdPrimero;
        private Telerik.WinControls.UI.CommandBarButton cmdAnterior;
        private Telerik.WinControls.UI.CommandBarButton cmdSiguiente;
        private Telerik.WinControls.UI.CommandBarButton cmdUltimo;
        protected Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    }
}
