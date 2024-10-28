namespace Inv.UI.Win
{
    partial class FrmCostoCantera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCostoCantera));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.tabDestino = new Telerik.WinControls.UI.RadPageView();
            this.rpvDomicilio = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridDetalle = new Telerik.WinControls.UI.RadGridView();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.txtImporte = new Telerik.WinControls.UI.RadTextBox();
            this.txtDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.radCommandBar2 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnCancelar = new Telerik.WinControls.UI.CommandBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDestino)).BeginInit();
            this.tabDestino.SuspendLayout();
            this.rpvDomicilio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // barraComando
            // 
            this.barraComando.BackColor = System.Drawing.Color.White;
            this.barraComando.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.barraComando.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.barraComando.BorderColor3 = System.Drawing.Color.White;
            this.barraComando.BorderColor4 = System.Drawing.Color.White;
            this.barraComando.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.barraComando.Bounds = new System.Drawing.Rectangle(0, 0, 227, 30);
            this.barraComando.DesiredLocation = ((System.Drawing.PointF)(resources.GetObject("barraComando.DesiredLocation")));
            this.barraComando.DisplayName = "barraComando";
            this.barraComando.DrawBorder = true;
            this.barraComando.DrawFill = true;
            this.barraComando.DrawText = false;
            this.barraComando.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraComando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.barraComando.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            // 
            // 
            // 
            this.barraComando.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.barraComando.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radCommandBar1.Size = new System.Drawing.Size(926, 33);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(461, 335);
            this.gridControl.TabIndex = 20;
            this.gridControl.TabStop = false;
            this.gridControl.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellClick);
            // 
            // tabDestino
            // 
            this.tabDestino.Controls.Add(this.rpvDomicilio);
            this.tabDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDestino.Location = new System.Drawing.Point(461, 33);
            this.tabDestino.Name = "tabDestino";
            this.tabDestino.SelectedPage = this.rpvDomicilio;
            this.tabDestino.Size = new System.Drawing.Size(465, 335);
            this.tabDestino.TabIndex = 0;
            this.tabDestino.TabStop = false;
            this.tabDestino.Text = "Detalle Tipo Costo x Cantera";
            this.tabDestino.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.tabDestino.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).ToolTipText = "Close Selected Page";
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.tabDestino.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).Enabled = true;
            // 
            // rpvDomicilio
            // 
            this.rpvDomicilio.Controls.Add(this.gridDetalle);
            this.rpvDomicilio.Controls.Add(this.radLabel6);
            this.rpvDomicilio.Controls.Add(this.txtImporte);
            this.rpvDomicilio.Controls.Add(this.txtDescripcion);
            this.rpvDomicilio.Controls.Add(this.radLabel4);
            this.rpvDomicilio.Controls.Add(this.txtCodigo);
            this.rpvDomicilio.Controls.Add(this.radCommandBar2);
            this.rpvDomicilio.ItemSize = new System.Drawing.SizeF(88F, 27F);
            this.rpvDomicilio.Location = new System.Drawing.Point(5, 31);
            this.rpvDomicilio.Name = "rpvDomicilio";
            this.rpvDomicilio.Size = new System.Drawing.Size(455, 299);
            this.rpvDomicilio.Text = "Costo Detalle";
            // 
            // gridDetalle
            // 
            this.gridDetalle.Location = new System.Drawing.Point(1, 90);
            // 
            // 
            // 
            this.gridDetalle.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.Size = new System.Drawing.Size(454, 168);
            this.gridDetalle.TabIndex = 18;
            this.gridDetalle.Text = "radGridView1";
            this.gridDetalle.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridDetalle_CellClick);
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(16, 64);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(51, 18);
            this.radLabel6.TabIndex = 17;
            this.radLabel6.Text = "Importe :";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(79, 62);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(101, 20);
            this.txtImporte.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(128, 40);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(155, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(6, 40);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(61, 18);
            this.radLabel4.TabIndex = 13;
            this.radLabel4.Text = "Tipo costo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(79, 40);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // radCommandBar2
            // 
            this.radCommandBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar2.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar2.Name = "radCommandBar2";
            this.radCommandBar2.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
            this.radCommandBar2.Size = new System.Drawing.Size(455, 33);
            this.radCommandBar2.TabIndex = 0;
            this.radCommandBar2.TabStop = false;
            this.radCommandBar2.Text = "radCommandBar2";
            this.radCommandBar2.ThemeName = "Office2013Light";
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement2});
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.btnGuardar,
            this.btnCancelar});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "commandBarButton1";
            this.btnNuevo.AccessibleName = "commandBarButton1";
            this.btnNuevo.DisplayName = "commandBarButton1";
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "commandBarButton1";
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleDescription = "commandBarButton2";
            this.btnEditar.AccessibleName = "commandBarButton2";
            this.btnEditar.DisplayName = "commandBarButton2";
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "commandBarButton2";
            this.btnEditar.ToolTipText = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleDescription = "commandBarButton3";
            this.btnEliminar.AccessibleName = "commandBarButton3";
            this.btnEliminar.DisplayName = "commandBarButton3";
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "commandBarButton3";
            this.btnEliminar.ToolTipText = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleDescription = "commandBarButton4";
            this.btnGuardar.AccessibleName = "commandBarButton4";
            this.btnGuardar.DisplayName = "commandBarButton4";
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "commandBarButton4";
            this.btnGuardar.ToolTipText = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleDescription = "commandBarButton5";
            this.btnCancelar.AccessibleName = "commandBarButton5";
            this.btnCancelar.DisplayName = "commandBarButton5";
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Text = "commandBarButton5";
            this.btnCancelar.ToolTipText = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmCostoCantera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 368);
            this.Controls.Add(this.tabDestino);
            this.Controls.Add(this.gridControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCostoCantera";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Costo Cantera";
            this.Load += new System.EventHandler(this.FrmCostoCantera_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            this.Controls.SetChildIndex(this.tabDestino, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDestino)).EndInit();
            this.tabDestino.ResumeLayout(false);
            this.rpvDomicilio.ResumeLayout(false);
            this.rpvDomicilio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPageView tabDestino;
        private Telerik.WinControls.UI.RadPageViewPage rpvDomicilio;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar2;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnEditar;
        private Telerik.WinControls.UI.CommandBarButton btnEliminar;
        private Telerik.WinControls.UI.CommandBarButton btnGuardar;
        private Telerik.WinControls.UI.CommandBarButton btnCancelar;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtCodigo;
        private Telerik.WinControls.UI.RadTextBox txtDescripcion;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTextBox txtImporte;
        private Telerik.WinControls.UI.RadGridView gridDetalle;
    }
}
