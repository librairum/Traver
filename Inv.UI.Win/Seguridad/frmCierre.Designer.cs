namespace Inv.UI.Win
{
    partial class frmCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierre));
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtAnioGenera = new Telerik.WinControls.UI.RadTextBox();
            this.txtAnioCerrar = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbCancelar = new Telerik.WinControls.UI.CommandBarButton();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioGenera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtAnioGenera);
            this.radPanel1.Controls.Add(this.txtAnioCerrar);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Location = new System.Drawing.Point(12, 39);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(258, 81);
            this.radPanel1.TabIndex = 5;
            // 
            // txtAnioGenera
            // 
            this.txtAnioGenera.Location = new System.Drawing.Point(126, 43);
            this.txtAnioGenera.Name = "txtAnioGenera";
            this.txtAnioGenera.Size = new System.Drawing.Size(100, 20);
            this.txtAnioGenera.TabIndex = 1;
            // 
            // txtAnioCerrar
            // 
            this.txtAnioCerrar.Location = new System.Drawing.Point(126, 17);
            this.txtAnioCerrar.Name = "txtAnioCerrar";
            this.txtAnioCerrar.Size = new System.Drawing.Size(100, 20);
            this.txtAnioCerrar.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 45);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(81, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Año a Generar:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 19);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(71, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Año a Cerrar:";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Ayuda";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.BorderBottomColor = System.Drawing.Color.Black;
            this.commandBarRowElement1.BorderBottomWidth = 1F;
            this.commandBarRowElement1.BorderColor = System.Drawing.Color.Black;
            this.commandBarRowElement1.BorderLeftColor = System.Drawing.Color.Transparent;
            this.commandBarRowElement1.BorderLeftWidth = 0F;
            this.commandBarRowElement1.BorderRightColor = System.Drawing.Color.Transparent;
            this.commandBarRowElement1.BorderRightWidth = 0F;
            this.commandBarRowElement1.BorderTopColor = System.Drawing.Color.Black;
            this.commandBarRowElement1.BorderTopWidth = 1F;
            this.commandBarRowElement1.BorderWidth = 0F;
            this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            this.commandBarRowElement1.Text = "";
            this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.BorderBottomColor = System.Drawing.Color.White;
            this.commandBarStripElement1.BorderBottomWidth = 1F;
            this.commandBarStripElement1.BorderLeftWidth = 1F;
            this.commandBarStripElement1.BorderRightWidth = 1F;
            this.commandBarStripElement1.BorderTopWidth = 1F;
            this.commandBarStripElement1.BorderWidth = 1F;
            this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cbbGuardar,
            this.cbbCancelar});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.StretchHorizontally = true;
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // cbbGuardar
            // 
            this.cbbGuardar.AccessibleDescription = "Guardar";
            this.cbbGuardar.AccessibleName = "Guardar";
            this.cbbGuardar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGuardar.DisplayName = "commandBarButton1";
            this.cbbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cbbGuardar.Image")));
            this.cbbGuardar.Name = "cbbGuardar";
            this.cbbGuardar.Text = "";
            this.cbbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
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
            this.cbbCancelar.Text = "";
            this.cbbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbbCancelar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbCancelar.ToolTipText = "Cancelar";
            this.cbbCancelar.Click += new System.EventHandler(this.cbbCancelar_Click);
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.BackColor = System.Drawing.Color.White;
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(278, 33);
            this.radCommandBar1.TabIndex = 6;
            this.radCommandBar1.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderLeftWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderTopWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderRightWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderBottomWidth = 1F;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderColor3 = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderColor4 = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderLeftColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderTopColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderRightColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radCommandBar1.GetChildAt(0))).BorderBottomColor = System.Drawing.Color.Black;
            // 
            // frmCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 126);
            this.Controls.Add(this.radCommandBar1);
            this.Controls.Add(this.radPanel1);
            this.KeyPreview = true;
            this.Name = "frmCierre";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Cierre";
            this.ThemeName = "Office2013Light";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCierre_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioGenera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        protected System.Windows.Forms.ToolTip toolTip;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        public Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        protected internal Telerik.WinControls.UI.CommandBarButton cbbGuardar;
        protected internal Telerik.WinControls.UI.CommandBarButton cbbCancelar;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.RadTextBox txtAnioGenera;
        private Telerik.WinControls.UI.RadTextBox txtAnioCerrar;
    }
}
