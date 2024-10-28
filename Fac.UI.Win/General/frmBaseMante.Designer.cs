namespace Fac.UI.Win
{
    partial class frmBaseMante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMante));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.barGuardaCancel = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbCancelar = new Telerik.WinControls.UI.CommandBarButton();
            this.barImprimir = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbVistaPrevia = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.barNavegacion = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbPrimero = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbAnterior = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbSiguiente = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbUltimo = new Telerik.WinControls.UI.CommandBarButton();
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
            this.cbbNuevo,
            this.cbbEditar,
            this.cbbEliminar,
            this.barGuardaCancel,
            this.cbbGuardar,
            this.cbbCancelar,
            this.barImprimir,
            this.cbbVistaPrevia,
            this.cbbImprimir,
            this.barNavegacion,
            this.cbbPrimero,
            this.cbbAnterior,
            this.cbbSiguiente,
            this.cbbUltimo});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.StretchHorizontally = true;
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.ItemOverflowed += new System.EventHandler(this.commandBarStripElement1_ItemOverflowed);
            this.commandBarStripElement1.ItemOutOfOverflow += new System.EventHandler(this.commandBarStripElement1_ItemOutOfOverflow);
            // 
            // cbbNuevo
            // 
            this.cbbNuevo.AccessibleDescription = "Agregar";
            this.cbbNuevo.AccessibleName = "Agregar";
            this.cbbNuevo.DisplayName = "Nuevo";
            this.cbbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("cbbNuevo.Image")));
            this.cbbNuevo.Name = "cbbNuevo";
            this.cbbNuevo.Text = "Nuevo";
            this.cbbNuevo.ToolTipText = "Agregar";
            this.cbbNuevo.Click += new System.EventHandler(this.cbbNuevo_Click);
            // 
            // cbbEditar
            // 
            this.cbbEditar.AccessibleDescription = "Modificar";
            this.cbbEditar.AccessibleName = "Modificar";
            this.cbbEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEditar.DisplayName = "Modificar";
            this.cbbEditar.Image = global::Fac.UI.Win.Properties.Resources.editrowred1;
            this.cbbEditar.Name = "cbbEditar";
            this.cbbEditar.Tag = "1";
            this.cbbEditar.Text = "";
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
            this.cbbEliminar.Image = global::Fac.UI.Win.Properties.Resources.remove;
            this.cbbEliminar.Name = "cbbEliminar";
            this.cbbEliminar.Tag = "2";
            this.cbbEliminar.Text = "";
            this.cbbEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.cbbEliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEliminar.ToolTipText = "Eliminar";
            this.cbbEliminar.Click += new System.EventHandler(this.cbbEliminar_Click);
            // 
            // barGuardaCancel
            // 
            this.barGuardaCancel.AccessibleDescription = "barGuardaCancel";
            this.barGuardaCancel.AccessibleName = "barGuardaCancel";
            this.barGuardaCancel.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.barGuardaCancel.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.barGuardaCancel.BorderWidth = 1F;
            this.barGuardaCancel.DisplayName = "commandBarSeparator2";
            this.barGuardaCancel.Name = "barGuardaCancel";
            this.barGuardaCancel.VisibleInOverflowMenu = false;
            // 
            // cbbGuardar
            // 
            this.cbbGuardar.AccessibleDescription = "Guardar";
            this.cbbGuardar.AccessibleName = "Guardar";
            this.cbbGuardar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbGuardar.DisplayName = "Guardar";
            this.cbbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cbbGuardar.Image")));
            this.cbbGuardar.Name = "cbbGuardar";
            this.cbbGuardar.Tag = "3";
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
            this.cbbCancelar.DisplayName = "Cancelar";
            this.cbbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cbbCancelar.Image")));
            this.cbbCancelar.Name = "cbbCancelar";
            this.cbbCancelar.Tag = "4";
            this.cbbCancelar.Text = "";
            this.cbbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbbCancelar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbCancelar.ToolTipText = "Cancelar";
            this.cbbCancelar.Click += new System.EventHandler(this.cbbCancelar_Click);
            // 
            // barImprimir
            // 
            this.barImprimir.AccessibleDescription = "barImprimir";
            this.barImprimir.AccessibleName = "barImprimir";
            this.barImprimir.DisplayName = "commandBarSeparator4";
            this.barImprimir.Name = "barImprimir";
            this.barImprimir.VisibleInOverflowMenu = false;
            // 
            // cbbVistaPrevia
            // 
            this.cbbVistaPrevia.AccessibleDescription = "Vista previa";
            this.cbbVistaPrevia.AccessibleName = "VistaPrevia";
            this.cbbVistaPrevia.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVistaPrevia.DisplayName = "commandBarButton1";
            this.cbbVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("cbbVistaPrevia.Image")));
            this.cbbVistaPrevia.Name = "cbbVistaPrevia";
            this.cbbVistaPrevia.Tag = "5";
            this.cbbVistaPrevia.Text = "";
            this.cbbVistaPrevia.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVistaPrevia.ToolTipText = "Vista previa";
            this.cbbVistaPrevia.Click += new System.EventHandler(this.cbbVistaPrevia_Click);
            // 
            // cbbImprimir
            // 
            this.cbbImprimir.AccessibleDescription = "imprmir";
            this.cbbImprimir.AccessibleName = "imprmir";
            this.cbbImprimir.DisplayName = "commandBarButton1";
            this.cbbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cbbImprimir.Image")));
            this.cbbImprimir.Name = "cbbImprimir";
            this.cbbImprimir.Tag = "6";
            this.cbbImprimir.Text = "imprmir";
            this.cbbImprimir.ToolTipText = "imprimir";
            this.cbbImprimir.Click += new System.EventHandler(this.cbbImprimir_Click);
            // 
            // barNavegacion
            // 
            this.barNavegacion.AccessibleDescription = "barNavegacion";
            this.barNavegacion.AccessibleName = "barNavegacion";
            this.barNavegacion.DisplayName = "commandBarSeparator1";
            this.barNavegacion.Name = "barNavegacion";
            this.barNavegacion.VisibleInOverflowMenu = false;
            // 
            // cbbPrimero
            // 
            this.cbbPrimero.AccessibleDescription = "commandBarButton3";
            this.cbbPrimero.AccessibleName = "commandBarButton3";
            this.cbbPrimero.DisplayName = "commandBarButton3";
            this.cbbPrimero.Image = ((System.Drawing.Image)(resources.GetObject("cbbPrimero.Image")));
            this.cbbPrimero.Name = "cbbPrimero";
            this.cbbPrimero.Text = "commandBarButton3";
            this.cbbPrimero.ToolTipText = "primero";
            this.cbbPrimero.Click += new System.EventHandler(this.cbbPrimero_Click);
            // 
            // cbbAnterior
            // 
            this.cbbAnterior.AccessibleDescription = "commandBarButton4";
            this.cbbAnterior.AccessibleName = "commandBarButton4";
            this.cbbAnterior.DisplayName = "commandBarButton4";
            this.cbbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("cbbAnterior.Image")));
            this.cbbAnterior.Name = "cbbAnterior";
            this.cbbAnterior.Text = "commandBarButton4";
            this.cbbAnterior.ToolTipText = "anterior";
            this.cbbAnterior.Click += new System.EventHandler(this.cbbAnterior_Click);
            // 
            // cbbSiguiente
            // 
            this.cbbSiguiente.AccessibleDescription = "commandBarButton5";
            this.cbbSiguiente.AccessibleName = "commandBarButton5";
            this.cbbSiguiente.DisplayName = "commandBarButton5";
            this.cbbSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("cbbSiguiente.Image")));
            this.cbbSiguiente.Name = "cbbSiguiente";
            this.cbbSiguiente.Text = "commandBarButton5";
            this.cbbSiguiente.ToolTipText = "siguiente";
            this.cbbSiguiente.Click += new System.EventHandler(this.cbbSiguiente_Click);
            // 
            // cbbUltimo
            // 
            this.cbbUltimo.AccessibleDescription = "commandBarButton6";
            this.cbbUltimo.AccessibleName = "commandBarButton6";
            this.cbbUltimo.DisplayName = "commandBarButton6";
            this.cbbUltimo.Image = ((System.Drawing.Image)(resources.GetObject("cbbUltimo.Image")));
            this.cbbUltimo.Name = "cbbUltimo";
            this.cbbUltimo.Text = "commandBarButton6";
            this.cbbUltimo.ToolTipText = "ultimo";
            this.cbbUltimo.Click += new System.EventHandler(this.cbbUltimo_Click);
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.BackColor = System.Drawing.Color.White;
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(790, 33);
            this.radCommandBar1.TabIndex = 2;
            this.radCommandBar1.TabStop = false;
            this.radCommandBar1.ThemeName = "Office2013Light";
            this.radCommandBar1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radCommandBar1_KeyUp);
            this.radCommandBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radCommandBar1_MouseDown);
            this.radCommandBar1.MouseHover += new System.EventHandler(this.radCommandBar1_MouseHover);
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
            // frmBaseMante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 423);
            this.Controls.Add(this.radCommandBar1);
            this.KeyPreview = true;
            this.Name = "frmBaseMante";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2013Light";
            this.Activated += new System.EventHandler(this.frmBaseMante_Activated);
            this.Load += new System.EventHandler(this.frmBaseMante_Load);
            this.Click += new System.EventHandler(this.frmBaseMante_Click);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBaseMante_KeyUp);
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
        //protected internal Telerik.WinControls.UI.CommandBarButton cbbImprimir;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        protected Telerik.WinControls.UI.CommandBarSeparator barGuardaCancel;
        protected Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        protected Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        protected Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarButton cbbPrimero;
        private Telerik.WinControls.UI.CommandBarButton cbbAnterior;
        private Telerik.WinControls.UI.CommandBarButton cbbSiguiente;
        private Telerik.WinControls.UI.CommandBarButton cbbUltimo;
        private Telerik.WinControls.UI.CommandBarSeparator barImprimir;
        private Telerik.WinControls.UI.CommandBarSeparator barNavegacion;
        private Telerik.WinControls.UI.CommandBarButton cbbEditar;
        private Telerik.WinControls.UI.CommandBarButton cbbEliminar;
        private Telerik.WinControls.UI.CommandBarButton cbbGuardar;
        private Telerik.WinControls.UI.CommandBarButton cbbCancelar;
        private Telerik.WinControls.UI.CommandBarButton cbbVistaPrevia;
        private Telerik.WinControls.UI.CommandBarButton cbbImprimir;
        private Telerik.WinControls.UI.CommandBarButton cbbNuevo;
    }
}
