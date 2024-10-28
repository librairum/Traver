namespace Prod.UI.Win
{
    partial class frmMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDI));
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.cboperiodos = new Telerik.WinControls.UI.RadDropDownList();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            this.lblUsuario = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElement2 = new Telerik.WinControls.UI.RadLabelElement();
            this.lblPerfil = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElement3 = new Telerik.WinControls.UI.RadLabelElement();
            this.lblNomEmpresa = new Telerik.WinControls.UI.RadLabelElement();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.office2013LightTheme2 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            this.radRibbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.radRibbonBar1.Controls.Add(this.cboperiodos);
            this.radRibbonBar1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.MaximumSize = new System.Drawing.Size(0, 120);
            this.radRibbonBar1.MinimumSize = new System.Drawing.Size(0, 120);
            this.radRibbonBar1.Name = "radRibbonBar1";
            // 
            // 
            // 
            this.radRibbonBar1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radRibbonBar1.RootElement.MaxSize = new System.Drawing.Size(0, 120);
            this.radRibbonBar1.RootElement.MinSize = new System.Drawing.Size(0, 120);
            this.radRibbonBar1.Size = new System.Drawing.Size(1268, 120);
            this.radRibbonBar1.StartButtonImage = ((System.Drawing.Image)(resources.GetObject("radRibbonBar1.StartButtonImage")));
            this.radRibbonBar1.TabIndex = 0;
            this.radRibbonBar1.Text = "..::. PRODUCCION ..::..";
            this.radRibbonBar1.ThemeName = "Office2013Light";
            // 
            // cboperiodos
            // 
            this.cboperiodos.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboperiodos.Location = new System.Drawing.Point(936, 77);
            this.cboperiodos.Name = "cboperiodos";
            // 
            // 
            // 
            this.cboperiodos.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.cboperiodos.Size = new System.Drawing.Size(209, 20);
            this.cboperiodos.TabIndex = 1;
            this.cboperiodos.SelectedIndexChanging += new Telerik.WinControls.UI.Data.PositionChangingEventHandler(this.cboperiodos_SelectedIndexChanging);
            this.cboperiodos.SelectedValueChanged += new System.EventHandler(this.cboperiodos_SelectedValueChanged);
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radLabelElement1,
            this.lblUsuario,
            this.radLabelElement2,
            this.lblPerfil,
            this.radLabelElement3,
            this.lblNomEmpresa});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 398);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(1268, 27);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadStatusBarElement)(this.radStatusStrip1.GetChildAt(0))).Text = "radStatusStrip1";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radStatusStrip1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
            // 
            // radLabelElement1
            // 
            this.radLabelElement1.AccessibleDescription = "Usuario :";
            this.radLabelElement1.AccessibleName = "Usuario :";
            this.radLabelElement1.Name = "radLabelElement1";
            this.radStatusStrip1.SetSpring(this.radLabelElement1, false);
            this.radLabelElement1.Text = "Usuario :";
            this.radLabelElement1.TextWrap = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AccessibleDescription = "radLabelElement2";
            this.lblUsuario.AccessibleName = "radLabelElement2";
            this.lblUsuario.Name = "lblUsuario";
            this.radStatusStrip1.SetSpring(this.lblUsuario, false);
            this.lblUsuario.Text = "radLabelElement2";
            this.lblUsuario.TextWrap = true;
            // 
            // radLabelElement2
            // 
            this.radLabelElement2.AccessibleDescription = "Perfil :";
            this.radLabelElement2.AccessibleName = "Perfil :";
            this.radLabelElement2.Name = "radLabelElement2";
            this.radStatusStrip1.SetSpring(this.radLabelElement2, false);
            this.radLabelElement2.Text = "Perfil :";
            this.radLabelElement2.TextWrap = true;
            // 
            // lblPerfil
            // 
            this.lblPerfil.AccessibleDescription = "radLabelElement3";
            this.lblPerfil.AccessibleName = "radLabelElement3";
            this.lblPerfil.Name = "lblPerfil";
            this.radStatusStrip1.SetSpring(this.lblPerfil, false);
            this.lblPerfil.Text = "radLabelElement3";
            this.lblPerfil.TextWrap = true;
            // 
            // radLabelElement3
            // 
            this.radLabelElement3.AccessibleDescription = "Empresa :";
            this.radLabelElement3.AccessibleName = "Empresa :";
            this.radLabelElement3.Name = "radLabelElement3";
            this.radStatusStrip1.SetSpring(this.radLabelElement3, false);
            this.radLabelElement3.Text = "Empresa :";
            this.radLabelElement3.TextWrap = true;
            // 
            // lblNomEmpresa
            // 
            this.lblNomEmpresa.AccessibleDescription = "radLabelElement4";
            this.lblNomEmpresa.AccessibleName = "radLabelElement4";
            this.lblNomEmpresa.Name = "lblNomEmpresa";
            this.radStatusStrip1.SetSpring(this.lblNomEmpresa, false);
            this.lblNomEmpresa.Text = "radLabelElement4";
            this.lblNomEmpresa.TextWrap = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radDock1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 278);
            this.panel1.TabIndex = 2;
            // 
            // radDock1
            // 
            this.radDock1.BackColor = System.Drawing.Color.White;
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 0);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            this.radDock1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.Size = new System.Drawing.Size(1266, 276);
            this.radDock1.SplitterWidth = 2;
            this.radDock1.TabIndex = 1;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            this.radDock1.ThemeName = "Office2013Light";
            this.radDock1.DockWindowAdded += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock1_DockWindowAdded);
            this.radDock1.DockWindowClosed += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock1_DockWindowClosed);
            this.radDock1.SelectedTabChanging += new Telerik.WinControls.UI.Docking.SelectedTabChangingEventHandler(this.radDock1_SelectedTabChanging);
            this.radDock1.SelectedTabChanged += new Telerik.WinControls.UI.Docking.SelectedTabChangedEventHandler(this.radDock1_SelectedTabChanged);
            this.radDock1.ActiveWindowChanged += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock1_ActiveWindowChanged);
            ((Telerik.WinControls.UI.SplitPanelElement)(this.radDock1.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(144)))), ((int)(((byte)(196)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(138)))), ((int)(((byte)(230)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(138)))), ((int)(((byte)(230)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(138)))), ((int)(((byte)(230)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radDock1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.SplitContainerElement)(this.radDock1.GetChildAt(1))).SplitterWidth = 2;
            ((Telerik.WinControls.UI.SplitContainerElement)(this.radDock1.GetChildAt(1))).BackColor = System.Drawing.Color.White;
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 2;
            this.documentContainer1.ThemeName = "Office2013Light";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 425);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radRibbonBar1);
            this.Name = "frmMDI";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "..::. PRODUCCION ..::..";
            this.ThemeName = "Office2013Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMDI_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMDI_FormClosed);
            this.Load += new System.EventHandler(this.frmMDI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            this.radRibbonBar1.ResumeLayout(false);
            this.radRibbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadDropDownList cboperiodos;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Telerik.WinControls.UI.RadLabelElement lblUsuario;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement2;
        private Telerik.WinControls.UI.RadLabelElement lblPerfil;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement3;
        private Telerik.WinControls.UI.RadLabelElement lblNomEmpresa;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme2;
        public Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        //private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        //private Telerik.WinControls.UI.RadLabelElement lblUsuario;
        //private Telerik.WinControls.UI.RadLabelElement radLabelElement3;
        //private Telerik.WinControls.UI.RadLabelElement lblPerfil;
        //private Telerik.WinControls.UI.RadLabelElement radLabelElement2;
        //private Telerik.WinControls.UI.RadLabelElement lblNomEmpresa;
    }
}
