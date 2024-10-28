namespace Prod.UI.Win
{
    partial class FrmSeguirCanastilla
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pnlBusqueda = new Telerik.WinControls.UI.RadPanel();
            this.rbMovimientos = new Telerik.WinControls.UI.RadRadioButton();
            this.rbEntradaSalida = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpFechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtNroCaja = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            this.pnlData = new Telerik.WinControls.UI.RadPanel();
            this.rpvSeguimiento = new Telerik.WinControls.UI.RadPageView();
            this.rpEntradaSalida = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rpMovimientos = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridMovimientos = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBusqueda)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbEntradaSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlData)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpvSeguimiento)).BeginInit();
            this.rpvSeguimiento.SuspendLayout();
            this.rpEntradaSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            this.rpMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Size = new System.Drawing.Size(1115, 33);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.rbMovimientos);
            this.pnlBusqueda.Controls.Add(this.rbEntradaSalida);
            this.pnlBusqueda.Controls.Add(this.dtpFechaIni);
            this.pnlBusqueda.Controls.Add(this.dtpFechaFin);
            this.pnlBusqueda.Controls.Add(this.txtNroCaja);
            this.pnlBusqueda.Controls.Add(this.radLabel3);
            this.pnlBusqueda.Controls.Add(this.radLabel2);
            this.pnlBusqueda.Controls.Add(this.radLabel1);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 33);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(1115, 28);
            this.pnlBusqueda.TabIndex = 4;
            // 
            // rbMovimientos
            // 
            this.rbMovimientos.Location = new System.Drawing.Point(133, 7);
            this.rbMovimientos.Name = "rbMovimientos";
            this.rbMovimientos.Size = new System.Drawing.Size(85, 18);
            this.rbMovimientos.TabIndex = 10;
            this.rbMovimientos.Text = "Movimientos";
            this.rbMovimientos.CheckStateChanged += new System.EventHandler(this.rbMovimientos_CheckStateChanged);
            // 
            // rbEntradaSalida
            // 
            this.rbEntradaSalida.Location = new System.Drawing.Point(13, 7);
            this.rbEntradaSalida.Name = "rbEntradaSalida";
            this.rbEntradaSalida.Size = new System.Drawing.Size(114, 18);
            this.rbEntradaSalida.TabIndex = 9;
            this.rbEntradaSalida.Text = "Entradas vs Salidas";
            this.rbEntradaSalida.CheckStateChanged += new System.EventHandler(this.rbEntradaSalida_CheckStateChanged);
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Location = new System.Drawing.Point(305, 5);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(90, 20);
            this.dtpFechaIni.TabIndex = 8;
            this.dtpFechaIni.TabStop = false;
            this.dtpFechaIni.Text = "lunes, 10 de octubre de 2016";
            this.dtpFechaIni.Value = new System.DateTime(2016, 10, 10, 17, 28, 29, 495);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(465, 5);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(92, 20);
            this.dtpFechaFin.TabIndex = 7;
            this.dtpFechaFin.TabStop = false;
            this.dtpFechaFin.Text = "lunes, 10 de octubre de 2016";
            this.dtpFechaFin.Value = new System.DateTime(2016, 10, 10, 17, 28, 29, 495);
            // 
            // txtNroCaja
            // 
            this.txtNroCaja.Location = new System.Drawing.Point(673, 5);
            this.txtNroCaja.Name = "txtNroCaja";
            this.txtNroCaja.Size = new System.Drawing.Size(90, 20);
            this.txtNroCaja.TabIndex = 6;
            this.txtNroCaja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroCaja_KeyDown);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(569, 5);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(98, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Ingresar Nro.Caja :";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(401, 5);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(58, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Fecha Fin :";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(234, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(65, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Fecha Inicio";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(769, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(51, 20);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.rpvSeguimiento);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 61);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1115, 430);
            this.pnlData.TabIndex = 5;
            // 
            // rpvSeguimiento
            // 
            this.rpvSeguimiento.Controls.Add(this.rpEntradaSalida);
            this.rpvSeguimiento.Controls.Add(this.rpMovimientos);
            this.rpvSeguimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvSeguimiento.Location = new System.Drawing.Point(0, 0);
            this.rpvSeguimiento.Name = "rpvSeguimiento";
            this.rpvSeguimiento.SelectedPage = this.rpEntradaSalida;
            this.rpvSeguimiento.Size = new System.Drawing.Size(1115, 430);
            this.rpvSeguimiento.TabIndex = 2;
            this.rpvSeguimiento.Text = "radPageView1";
            this.rpvSeguimiento.SelectedPageChanged += new System.EventHandler(this.rpvSeguimiento_SelectedPageChanged);
            // 
            // rpEntradaSalida
            // 
            this.rpEntradaSalida.Controls.Add(this.gridControl);
            this.rpEntradaSalida.ItemSize = new System.Drawing.SizeF(110F, 28F);
            this.rpEntradaSalida.Location = new System.Drawing.Point(10, 37);
            this.rpEntradaSalida.Name = "rpEntradaSalida";
            this.rpEntradaSalida.Size = new System.Drawing.Size(1094, 382);
            this.rpEntradaSalida.Text = "Entradas vs Salidas";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1094, 382);
            this.gridControl.TabIndex = 0;
            // 
            // rpMovimientos
            // 
            this.rpMovimientos.Controls.Add(this.gridMovimientos);
            this.rpMovimientos.ItemSize = new System.Drawing.SizeF(81F, 28F);
            this.rpMovimientos.Location = new System.Drawing.Point(10, 37);
            this.rpMovimientos.Name = "rpMovimientos";
            this.rpMovimientos.Size = new System.Drawing.Size(1094, 382);
            this.rpMovimientos.Text = "Movimientos";
            // 
            // gridMovimientos
            // 
            this.gridMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMovimientos.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridMovimientos.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridMovimientos.Name = "gridMovimientos";
            this.gridMovimientos.Size = new System.Drawing.Size(1094, 382);
            this.gridMovimientos.TabIndex = 1;
            this.gridMovimientos.Text = "radGridView1";
            // 
            // FrmSeguirCanastilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 491);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlBusqueda);
            this.Name = "FrmSeguirCanastilla";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Seguimiento de Canastilla";
            this.Controls.SetChildIndex(this.pnlBusqueda, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBusqueda)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbEntradaSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlData)).EndInit();
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpvSeguimiento)).EndInit();
            this.rpvSeguimiento.ResumeLayout(false);
            this.rpEntradaSalida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.rpMovimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlBusqueda;
        private Telerik.WinControls.UI.RadTextBox txtNroCaja;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnBuscar;
        private Telerik.WinControls.UI.RadPanel pnlData;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaIni;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadPageView rpvSeguimiento;
        private Telerik.WinControls.UI.RadPageViewPage rpEntradaSalida;
        private Telerik.WinControls.UI.RadPageViewPage rpMovimientos;
        private Telerik.WinControls.UI.RadGridView gridMovimientos;
        private Telerik.WinControls.UI.RadRadioButton rbMovimientos;
        private Telerik.WinControls.UI.RadRadioButton rbEntradaSalida;
    }
}
