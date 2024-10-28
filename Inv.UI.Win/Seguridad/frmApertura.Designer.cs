namespace Inv.UI.Win
{
    partial class frmApertura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApertura));
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtAnioApertura = new Telerik.WinControls.UI.RadTextBox();
            this.txtAnioCerrar = new Telerik.WinControls.UI.RadTextBox();
            this.ddlPeriodo = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbCancelar = new Telerik.WinControls.UI.CommandBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioApertura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtAnioApertura);
            this.radPanel1.Controls.Add(this.txtAnioCerrar);
            this.radPanel1.Controls.Add(this.ddlPeriodo);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Location = new System.Drawing.Point(8, 39);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(439, 57);
            this.radPanel1.TabIndex = 5;
            // 
            // txtAnioApertura
            // 
            this.txtAnioApertura.Location = new System.Drawing.Point(307, 29);
            this.txtAnioApertura.Name = "txtAnioApertura";
            this.txtAnioApertura.Size = new System.Drawing.Size(100, 20);
            this.txtAnioApertura.TabIndex = 1;
            // 
            // txtAnioCerrar
            // 
            this.txtAnioCerrar.Location = new System.Drawing.Point(304, 3);
            this.txtAnioCerrar.Name = "txtAnioCerrar";
            this.txtAnioCerrar.Size = new System.Drawing.Size(100, 20);
            this.txtAnioCerrar.TabIndex = 0;
            // 
            // ddlPeriodo
            // 
            this.ddlPeriodo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlPeriodo.Location = new System.Drawing.Point(11, 29);
            this.ddlPeriodo.Name = "ddlPeriodo";
            this.ddlPeriodo.Size = new System.Drawing.Size(176, 20);
            this.ddlPeriodo.TabIndex = 6;
            this.ddlPeriodo.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlPeriodo_SelectedIndexChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(11, 7);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(94, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Desde el periodo:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(206, 31);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(83, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Año a apertura:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(206, 5);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(71, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Año a Cerrar:";
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.BackColor = System.Drawing.Color.White;
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(459, 33);
            this.radCommandBar1.TabIndex = 7;
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
            // frmApertura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 107);
            this.Controls.Add(this.radCommandBar1);
            this.Controls.Add(this.radPanel1);
            this.KeyPreview = true;
            this.Name = "frmApertura";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Apertura";
            this.ThemeName = "Office2013Light";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmApertura_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioApertura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnioCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
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
        private Telerik.WinControls.UI.RadDropDownList ddlPeriodo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadTextBox txtAnioApertura;
        private Telerik.WinControls.UI.RadTextBox txtAnioCerrar;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        public Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        protected internal Telerik.WinControls.UI.CommandBarButton cbbGuardar;
        protected internal Telerik.WinControls.UI.CommandBarButton cbbCancelar;
    }
}
