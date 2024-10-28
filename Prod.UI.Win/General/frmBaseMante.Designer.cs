namespace Prod.UI.Win
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMante));
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.barraComando = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbCancelar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cbbVistaPrevia = new Telerik.WinControls.UI.CommandBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.BackColor = System.Drawing.Color.White;
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(292, 33);
            this.radCommandBar1.TabIndex = 4;
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
            this.barraComando});
            this.commandBarRowElement1.Text = "";
            this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // barraComando
            // 
            this.barraComando.BorderBottomColor = System.Drawing.Color.White;
            this.barraComando.BorderBottomWidth = 1F;
            this.barraComando.BorderLeftWidth = 1F;
            this.barraComando.BorderRightWidth = 1F;
            this.barraComando.BorderTopWidth = 1F;
            this.barraComando.BorderWidth = 1F;
            this.barraComando.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.barraComando.DisplayName = "commandBarStripElement1";
            this.barraComando.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cbbNuevo,
            this.cbbEditar,
            this.cbbEliminar,
            this.commandBarSeparator2,
            this.cbbGuardar,
            this.cbbCancelar,
            this.commandBarSeparator1,
            this.cbbVistaPrevia});
            this.barraComando.Name = "barraComando";
            this.barraComando.StretchHorizontally = true;
            this.barraComando.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // cbbNuevo
            // 
            this.cbbNuevo.AccessibleDescription = "Agregar";
            this.cbbNuevo.AccessibleName = "Agregar";
            this.cbbNuevo.AutoSize = true;
            this.cbbNuevo.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.cbbNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbNuevo.DisplayName = "Nuevo";
            this.cbbNuevo.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.cbbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("cbbNuevo.Image")));
            this.cbbNuevo.Name = "cbbNuevo";
            this.cbbNuevo.Text = "";
            this.cbbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
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
            this.cbbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("cbbEliminar.Image")));
            this.cbbEliminar.Name = "cbbEliminar";
            this.cbbEliminar.Text = "";
            this.cbbEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.cbbEliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbEliminar.ToolTipText = "Eliminar";
            this.cbbEliminar.Click += new System.EventHandler(this.cbbEliminar_Click);
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
            this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
            this.commandBarSeparator2.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.commandBarSeparator2.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.commandBarSeparator2.BorderWidth = 1F;
            this.commandBarSeparator2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
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
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.StretchHorizontally = false;
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
            this.cbbVistaPrevia.Text = "";
            this.cbbVistaPrevia.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cbbVistaPrevia.ToolTipText = "Vista previa";
            this.cbbVistaPrevia.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.cbbVistaPrevia.Click += new System.EventHandler(this.cbbVistaPrevia_Click);
            // 
            // frmBaseMante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 270);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "frmBaseMante";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2013Light";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaseMante_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBaseMante_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        public Telerik.WinControls.UI.CommandBarStripElement barraComando;
        private Telerik.WinControls.UI.CommandBarButton cbbNuevo;
        private Telerik.WinControls.UI.CommandBarButton cbbEditar;
        private Telerik.WinControls.UI.CommandBarButton cbbEliminar;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarButton cbbGuardar;
        private Telerik.WinControls.UI.CommandBarButton cbbCancelar;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton cbbVistaPrevia;
    }
}
