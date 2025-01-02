namespace Inv.UI.Win
{
    partial class FrmInvFisico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvFisico));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.gridControlDet = new Telerik.WinControls.UI.RadGridView();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rbtinvfisicodiferencias = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtinvfisicotoma = new Telerik.WinControls.UI.RadRadioButton();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.dtpFecha = new Telerik.WinControls.UI.RadDateTimePicker();
            this.gbnuevo = new Telerik.WinControls.UI.RadGroupBox();
            this.rbtinvfisicoTotal = new Telerik.WinControls.UI.RadRadioButton();
            this.btnImportarInventarioMasivo = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lblmensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtinvfisicodiferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtinvfisicotoma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbnuevo)).BeginInit();
            this.gbnuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtinvfisicoTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportarInventarioMasivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
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
            this.radCommandBar1.Size = new System.Drawing.Size(1168, 33);
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(3, 35);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(239, 253);
            this.gridControl.TabIndex = 0;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // gridControlDet
            // 
            this.gridControlDet.Location = new System.Drawing.Point(250, 35);
            // 
            // 
            // 
            this.gridControlDet.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControlDet.Name = "gridControlDet";
            this.gridControlDet.Size = new System.Drawing.Size(911, 253);
            this.gridControlDet.TabIndex = 1;
            this.gridControlDet.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gridControlDet_CellBeginEdit);
            this.gridControlDet.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControlDet_CellEndEdit);
            this.gridControlDet.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(this.gridControlDet_CellValidating);
            this.gridControlDet.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControlDet_CellValueChanged);
            this.gridControlDet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControlDet_KeyDown);
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(536, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Almacen";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(857, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(35, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Fecha";
            // 
            // rbtinvfisicodiferencias
            // 
            this.rbtinvfisicodiferencias.Location = new System.Drawing.Point(191, 3);
            this.rbtinvfisicodiferencias.Name = "rbtinvfisicodiferencias";
            this.rbtinvfisicodiferencias.Size = new System.Drawing.Size(122, 18);
            this.rbtinvfisicodiferencias.TabIndex = 6;
            this.rbtinvfisicodiferencias.TabStop = false;
            this.rbtinvfisicodiferencias.Text = "Listado Dif Inv Fisico";
            // 
            // rbtinvfisicotoma
            // 
            this.rbtinvfisicotoma.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtinvfisicotoma.Location = new System.Drawing.Point(15, 3);
            this.rbtinvfisicotoma.Name = "rbtinvfisicotoma";
            this.rbtinvfisicotoma.Size = new System.Drawing.Size(170, 18);
            this.rbtinvfisicotoma.TabIndex = 5;
            this.rbtinvfisicotoma.Text = "Listado para Tomar Inventario";
            this.rbtinvfisicotoma.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.Location = new System.Drawing.Point(591, 3);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(260, 20);
            this.cboalmacenes.TabIndex = 6;
            this.cboalmacenes.Text = "radDropDownList1";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(894, 3);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(134, 20);
            this.dtpFecha.TabIndex = 5;
            this.dtpFecha.TabStop = false;
            this.dtpFecha.Text = "17/07/2015";
            this.dtpFecha.Value = new System.DateTime(2015, 7, 17, 16, 24, 32, 23);
            // 
            // gbnuevo
            // 
            this.gbnuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbnuevo.Controls.Add(this.rbtinvfisicoTotal);
            this.gbnuevo.Controls.Add(this.btnImportarInventarioMasivo);
            this.gbnuevo.Controls.Add(this.rbtinvfisicodiferencias);
            this.gbnuevo.Controls.Add(this.rbtinvfisicotoma);
            this.gbnuevo.Controls.Add(this.cboalmacenes);
            this.gbnuevo.Controls.Add(this.dtpFecha);
            this.gbnuevo.Controls.Add(this.radLabel1);
            this.gbnuevo.Controls.Add(this.radLabel2);
            this.gbnuevo.HeaderText = "";
            this.gbnuevo.Location = new System.Drawing.Point(3, 6);
            this.gbnuevo.Name = "gbnuevo";
            this.gbnuevo.Size = new System.Drawing.Size(1158, 26);
            this.gbnuevo.TabIndex = 4;
            // 
            // rbtinvfisicoTotal
            // 
            this.rbtinvfisicoTotal.Location = new System.Drawing.Point(325, 2);
            this.rbtinvfisicoTotal.Name = "rbtinvfisicoTotal";
            this.rbtinvfisicoTotal.Size = new System.Drawing.Size(136, 18);
            this.rbtinvfisicoTotal.TabIndex = 9;
            this.rbtinvfisicoTotal.TabStop = false;
            this.rbtinvfisicoTotal.Text = "Listado Total Inv Fisico ";
            // 
            // btnImportarInventarioMasivo
            // 
            this.btnImportarInventarioMasivo.Location = new System.Drawing.Point(1034, 6);
            this.btnImportarInventarioMasivo.Name = "btnImportarInventarioMasivo";
            this.btnImportarInventarioMasivo.Size = new System.Drawing.Size(106, 15);
            this.btnImportarInventarioMasivo.TabIndex = 8;
            this.btnImportarInventarioMasivo.Text = "Importar Inventario";
            this.btnImportarInventarioMasivo.Click += new System.EventHandler(this.btnImportarInventarioMasivo_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.lblmensaje);
            this.radPanel1.Controls.Add(this.gbnuevo);
            this.radPanel1.Controls.Add(this.gridControlDet);
            this.radPanel1.Controls.Add(this.gridControl);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 33);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1168, 319);
            this.radPanel1.TabIndex = 5;
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmensaje.Location = new System.Drawing.Point(247, 297);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(522, 13);
            this.lblmensaje.TabIndex = 5;
            this.lblmensaje.Text = "Modo edicion : Al terminar de editar a la celda cantidad, se guardara automatica " +
                "el valor ingresado.\r\n";
            // 
            // FrmInvFisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1168, 352);
            this.Controls.Add(this.radPanel1);
            this.Name = "FrmInvFisico";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Inventario Fisico";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmInvFisico_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtinvfisicodiferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtinvfisicotoma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbnuevo)).EndInit();
            this.gbnuevo.ResumeLayout(false);
            this.gbnuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtinvfisicoTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportarInventarioMasivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadGridView gridControlDet;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFecha;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadRadioButton rbtinvfisicotoma;
        private Telerik.WinControls.UI.RadRadioButton rbtinvfisicodiferencias;
        private Telerik.WinControls.UI.RadGroupBox gbnuevo;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label lblmensaje;
        private Telerik.WinControls.UI.RadButton btnImportarInventarioMasivo;
        private Telerik.WinControls.UI.RadRadioButton rbtinvfisicoTotal;
    }
}
