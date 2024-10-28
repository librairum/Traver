namespace Com.UI.Win
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
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.radLabelElement3 = new Telerik.WinControls.UI.RadLabelElement();
            this.lblUsuario = new Telerik.WinControls.UI.RadLabelElement();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.radLabelElement4 = new Telerik.WinControls.UI.RadLabelElement();
            this.lblPerfil = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElement5 = new Telerik.WinControls.UI.RadLabelElement();
            this.lblNomEmpresa = new Telerik.WinControls.UI.RadLabelElement();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            this.radLabelElement2 = new Telerik.WinControls.UI.RadLabelElement();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.cboperiodos = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            this.radRibbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radLabelElement3,
            this.lblUsuario,
            this.commandBarSeparator1,
            this.radLabelElement4,
            this.lblPerfil,
            this.radLabelElement5,
            this.lblNomEmpresa});
            resources.ApplyResources(this.radStatusStrip1, "radStatusStrip1");
            this.radStatusStrip1.Name = "radStatusStrip1";
            // 
            // 
            // 
            this.radStatusStrip1.RootElement.AccessibleDescription = resources.GetString("radStatusStrip1.RootElement.AccessibleDescription");
            this.radStatusStrip1.RootElement.AccessibleName = resources.GetString("radStatusStrip1.RootElement.AccessibleName");
            this.radStatusStrip1.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("radStatusStrip1.RootElement.Alignment")));
            this.radStatusStrip1.RootElement.AngleTransform = ((float)(resources.GetObject("radStatusStrip1.RootElement.AngleTransform")));
            this.radStatusStrip1.RootElement.FlipText = ((bool)(resources.GetObject("radStatusStrip1.RootElement.FlipText")));
            this.radStatusStrip1.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("radStatusStrip1.RootElement.Margin")));
            this.radStatusStrip1.RootElement.Text = resources.GetString("radStatusStrip1.RootElement.Text");
            this.radStatusStrip1.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("radStatusStrip1.RootElement.TextOrientation")));
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.ThemeName = "Office2013Light";
            // 
            // radLabelElement3
            // 
            resources.ApplyResources(this.radLabelElement3, "radLabelElement3");
            this.radLabelElement3.Name = "radLabelElement3";
            this.radStatusStrip1.SetSpring(this.radLabelElement3, false);
            this.radLabelElement3.TextWrap = true;
            // 
            // lblUsuario
            // 
            resources.ApplyResources(this.lblUsuario, "lblUsuario");
            this.lblUsuario.Name = "lblUsuario";
            this.radStatusStrip1.SetSpring(this.lblUsuario, false);
            this.lblUsuario.TextWrap = true;
            // 
            // commandBarSeparator1
            // 
            resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.radStatusStrip1.SetSpring(this.commandBarSeparator1, false);
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // radLabelElement4
            // 
            resources.ApplyResources(this.radLabelElement4, "radLabelElement4");
            this.radLabelElement4.Name = "radLabelElement4";
            this.radStatusStrip1.SetSpring(this.radLabelElement4, false);
            this.radLabelElement4.TextWrap = true;
            this.radLabelElement4.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // lblPerfil
            // 
            resources.ApplyResources(this.lblPerfil, "lblPerfil");
            this.lblPerfil.Name = "lblPerfil";
            this.radStatusStrip1.SetSpring(this.lblPerfil, false);
            this.lblPerfil.TextWrap = true;
            // 
            // radLabelElement5
            // 
            resources.ApplyResources(this.radLabelElement5, "radLabelElement5");
            this.radLabelElement5.Name = "radLabelElement5";
            this.radStatusStrip1.SetSpring(this.radLabelElement5, false);
            this.radLabelElement5.TextWrap = true;
            // 
            // lblNomEmpresa
            // 
            resources.ApplyResources(this.lblNomEmpresa, "lblNomEmpresa");
            this.lblNomEmpresa.Name = "lblNomEmpresa";
            this.radStatusStrip1.SetSpring(this.lblNomEmpresa, false);
            this.lblNomEmpresa.TextWrap = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radDock1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // radDock1
            // 
            this.radDock1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.radDock1.Controls.Add(this.documentContainer1);
            resources.ApplyResources(this.radDock1, "radDock1");
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            // 
            // 
            // 
            this.radDock1.RootElement.AccessibleDescription = resources.GetString("radDock1.RootElement.AccessibleDescription");
            this.radDock1.RootElement.AccessibleName = resources.GetString("radDock1.RootElement.AccessibleName");
            this.radDock1.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("radDock1.RootElement.Alignment")));
            this.radDock1.RootElement.AngleTransform = ((float)(resources.GetObject("radDock1.RootElement.AngleTransform")));
            this.radDock1.RootElement.FlipText = ((bool)(resources.GetObject("radDock1.RootElement.FlipText")));
            this.radDock1.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("radDock1.RootElement.Margin")));
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.RootElement.Text = resources.GetString("radDock1.RootElement.Text");
            this.radDock1.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("radDock1.RootElement.TextOrientation")));
            this.radDock1.SplitterWidth = 2;
            this.radDock1.TabStop = false;
            this.radDock1.ThemeName = "Windows8";
            this.radDock1.DockWindowAdded += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock1_DockWindowAdded);
            this.radDock1.DockWindowClosed += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock1_DockWindowClosed);
            this.radDock1.SelectedTabChanging += new Telerik.WinControls.UI.Docking.SelectedTabChangingEventHandler(this.radDock1_SelectedTabChanging);
            this.radDock1.SelectedTabChanged += new Telerik.WinControls.UI.Docking.SelectedTabChangedEventHandler(this.radDock1_SelectedTabChanged);
            ((Telerik.WinControls.UI.SplitPanelElement)(this.radDock1.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(144)))), ((int)(((byte)(196)))));
            ((Telerik.WinControls.UI.SplitPanelElement)(this.radDock1.GetChildAt(0))).Padding = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Padding")));
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
            this.documentContainer1.RootElement.AccessibleDescription = resources.GetString("documentContainer1.RootElement.AccessibleDescription");
            this.documentContainer1.RootElement.AccessibleName = resources.GetString("documentContainer1.RootElement.AccessibleName");
            this.documentContainer1.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("documentContainer1.RootElement.Alignment")));
            this.documentContainer1.RootElement.AngleTransform = ((float)(resources.GetObject("documentContainer1.RootElement.AngleTransform")));
            this.documentContainer1.RootElement.FlipText = ((bool)(resources.GetObject("documentContainer1.RootElement.FlipText")));
            this.documentContainer1.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("documentContainer1.RootElement.Margin")));
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.RootElement.Text = resources.GetString("documentContainer1.RootElement.Text");
            this.documentContainer1.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("documentContainer1.RootElement.TextOrientation")));
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 2;
            this.documentContainer1.ThemeName = "Windows8";
            // 
            // radLabelElement1
            // 
            resources.ApplyResources(this.radLabelElement1, "radLabelElement1");
            this.radLabelElement1.Name = "radLabelElement1";
            this.radLabelElement1.TextWrap = true;
            // 
            // radLabelElement2
            // 
            resources.ApplyResources(this.radLabelElement2, "radLabelElement2");
            this.radLabelElement2.Name = "radLabelElement2";
            this.radLabelElement2.TextWrap = true;
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.BackColor = System.Drawing.Color.LemonChiffon;
            this.radRibbonBar1.Controls.Add(this.cboperiodos);
            resources.ApplyResources(this.radRibbonBar1, "radRibbonBar1");
            this.radRibbonBar1.Name = "radRibbonBar1";
            // 
            // 
            // 
            this.radRibbonBar1.RootElement.AccessibleDescription = resources.GetString("radRibbonBar1.RootElement.AccessibleDescription");
            this.radRibbonBar1.RootElement.AccessibleName = resources.GetString("radRibbonBar1.RootElement.AccessibleName");
            this.radRibbonBar1.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("radRibbonBar1.RootElement.Alignment")));
            this.radRibbonBar1.RootElement.AngleTransform = ((float)(resources.GetObject("radRibbonBar1.RootElement.AngleTransform")));
            this.radRibbonBar1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radRibbonBar1.RootElement.FlipText = ((bool)(resources.GetObject("radRibbonBar1.RootElement.FlipText")));
            this.radRibbonBar1.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("radRibbonBar1.RootElement.Margin")));
            this.radRibbonBar1.RootElement.MaxSize = new System.Drawing.Size(0, 130);
            this.radRibbonBar1.RootElement.MinSize = new System.Drawing.Size(0, 130);
            this.radRibbonBar1.RootElement.Text = resources.GetString("radRibbonBar1.RootElement.Text");
            this.radRibbonBar1.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("radRibbonBar1.RootElement.TextOrientation")));
            this.radRibbonBar1.ThemeName = "Office2013Light";
            // 
            // cboperiodos
            // 
            this.cboperiodos.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            resources.ApplyResources(this.cboperiodos, "cboperiodos");
            this.cboperiodos.Name = "cboperiodos";
            // 
            // 
            // 
            this.cboperiodos.RootElement.AccessibleDescription = resources.GetString("cboperiodos.RootElement.AccessibleDescription");
            this.cboperiodos.RootElement.AccessibleName = resources.GetString("cboperiodos.RootElement.AccessibleName");
            this.cboperiodos.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("cboperiodos.RootElement.Alignment")));
            this.cboperiodos.RootElement.AngleTransform = ((float)(resources.GetObject("cboperiodos.RootElement.AngleTransform")));
            this.cboperiodos.RootElement.FlipText = ((bool)(resources.GetObject("cboperiodos.RootElement.FlipText")));
            this.cboperiodos.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("cboperiodos.RootElement.Margin")));
            this.cboperiodos.RootElement.Text = resources.GetString("cboperiodos.RootElement.Text");
            this.cboperiodos.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("cboperiodos.RootElement.TextOrientation")));
            this.cboperiodos.SelectedValueChanged += new System.EventHandler(this.cboperiodos_SelectedValueChanged);
            // 
            // frmMDI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radRibbonBar1);
            this.MainMenuStrip = null;
            this.Name = "frmMDI";
            // 
            // 
            // 
            this.RootElement.AccessibleDescription = resources.GetString("frmMDI.RootElement.AccessibleDescription");
            this.RootElement.AccessibleName = resources.GetString("frmMDI.RootElement.AccessibleName");
            this.RootElement.Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("frmMDI.RootElement.Alignment")));
            this.RootElement.AngleTransform = ((float)(resources.GetObject("frmMDI.RootElement.AngleTransform")));
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.FlipText = ((bool)(resources.GetObject("frmMDI.RootElement.FlipText")));
            this.RootElement.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("frmMDI.RootElement.Margin")));
            this.RootElement.Text = resources.GetString("frmMDI.RootElement.Text");
            this.RootElement.TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("frmMDI.RootElement.TextOrientation")));
            this.ThemeName = "Office2013Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMDI_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMDI_FormClosed);
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.Shown += new System.EventHandler(this.frm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            this.radRibbonBar1.ResumeLayout(false);
            this.radRibbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private System.Windows.Forms.Panel panel1;
        public Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement2;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement3;
        private Telerik.WinControls.UI.RadLabelElement lblUsuario;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement4;
        private Telerik.WinControls.UI.RadLabelElement lblPerfil;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement5;
        private Telerik.WinControls.UI.RadLabelElement lblNomEmpresa;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadDropDownList cboperiodos;
    }
}
