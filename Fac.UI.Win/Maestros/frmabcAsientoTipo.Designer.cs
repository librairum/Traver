namespace Fac.UI.Win
{
    partial class frmabcAsientoTipo
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
            this.pnlCabecera = new Telerik.WinControls.UI.RadPanel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtLibroDesc = new Telerik.WinControls.UI.RadTextBox();
            this.txtLibroCod = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.btnAgregar = new Telerik.WinControls.UI.RadButton();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCabecera)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibroDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibroCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(829, 33);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.radLabel3);
            this.pnlCabecera.Controls.Add(this.txtLibroDesc);
            this.pnlCabecera.Controls.Add(this.txtLibroCod);
            this.pnlCabecera.Controls.Add(this.radLabel2);
            this.pnlCabecera.Controls.Add(this.txtDescripcion);
            this.pnlCabecera.Controls.Add(this.radLabel1);
            this.pnlCabecera.Controls.Add(this.txtCodigo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 33);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(829, 30);
            this.pnlCabecera.TabIndex = 4;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(488, 6);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(37, 18);
            this.radLabel3.TabIndex = 10;
            this.radLabel3.Text = "Libro :";
            // 
            // txtLibroDesc
            // 
            this.txtLibroDesc.Location = new System.Drawing.Point(579, 6);
            this.txtLibroDesc.Name = "txtLibroDesc";
            this.txtLibroDesc.Size = new System.Drawing.Size(247, 20);
            this.txtLibroDesc.TabIndex = 3;
            this.txtLibroDesc.Tag = "0";
            // 
            // txtLibroCod
            // 
            this.txtLibroCod.Location = new System.Drawing.Point(531, 6);
            this.txtLibroCod.Name = "txtLibroCod";
            this.txtLibroCod.Size = new System.Drawing.Size(42, 20);
            this.txtLibroCod.TabIndex = 2;
            this.txtLibroCod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLibroCod_KeyDown);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(179, 6);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(70, 18);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "Descripcion :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(255, 6);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(218, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(43, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(49, 6);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(124, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAgregar.Image = global::Fac.UI.Win.Properties.Resources.add1;
            this.btnAgregar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.Location = new System.Drawing.Point(0, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 25);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.ThemeName = "Office2013Light";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 88);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
            this.gridControl.Size = new System.Drawing.Size(829, 347);
            this.gridControl.TabIndex = 21;
            this.gridControl.TabStop = false;
            this.gridControl.Text = "gridControl";
            this.gridControl.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gridControl_CellFormatting);
            this.gridControl.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gridControl_CellBeginEdit);
            this.gridControl.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridControl_CommandCellClick);
            this.gridControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl_KeyDown);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnAgregar);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 63);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(829, 25);
            this.radPanel1.TabIndex = 22;
            // 
            // frmabcAsientoTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 435);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.pnlCabecera);
            this.Name = "frmabcAsientoTipo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Detalle de Tipo de Asiento";
            this.Activated += new System.EventHandler(this.frmabcAsientoTipo_Activated);
            this.Load += new System.EventHandler(this.frmabcAsientoTipo_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.pnlCabecera, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCabecera)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibroDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibroCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlCabecera;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtLibroDesc;
        private Telerik.WinControls.UI.RadTextBox txtLibroCod;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtDescripcion;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtCodigo;
        private Telerik.WinControls.UI.RadButton btnAgregar;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel radPanel1;

    }
}
