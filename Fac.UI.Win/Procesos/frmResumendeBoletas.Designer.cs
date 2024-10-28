namespace Fac.UI.Win
{
    partial class frmResumendeBoletas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumendeBoletas));
            this.gridBoletasxResumenDetBoleta = new Telerik.WinControls.UI.RadGridView();
            this.pnlResumen = new Telerik.WinControls.UI.RadPanel();
            this.btnCancelarGenerar = new Telerik.WinControls.UI.RadButton();
            this.btnAceptarGenerar = new Telerik.WinControls.UI.RadButton();
            this.dtpFecResumen = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFecDocumento = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoletasxResumenDetBoleta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoletasxResumenDetBoleta.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResumen)).BeginInit();
            this.pnlResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarGenerar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptarGenerar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecResumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(1199, 33);
            // 
            // gridBoletasxResumenDetBoleta
            // 
            this.gridBoletasxResumenDetBoleta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBoletasxResumenDetBoleta.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridBoletasxResumenDetBoleta.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridBoletasxResumenDetBoleta.Name = "gridBoletasxResumenDetBoleta";
            this.gridBoletasxResumenDetBoleta.Size = new System.Drawing.Size(1199, 416);
            this.gridBoletasxResumenDetBoleta.TabIndex = 14;
            this.gridBoletasxResumenDetBoleta.Text = "radGridView1";
            this.gridBoletasxResumenDetBoleta.ThemeName = "ControlDefault";
            // 
            // pnlResumen
            // 
            this.pnlResumen.Controls.Add(this.btnCancelarGenerar);
            this.pnlResumen.Controls.Add(this.btnAceptarGenerar);
            this.pnlResumen.Controls.Add(this.dtpFecResumen);
            this.pnlResumen.Controls.Add(this.dtpFecDocumento);
            this.pnlResumen.Controls.Add(this.radLabel1);
            this.pnlResumen.Controls.Add(this.radLabel9);
            this.pnlResumen.Location = new System.Drawing.Point(391, 118);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(193, 81);
            this.pnlResumen.TabIndex = 4;
            // 
            // btnCancelarGenerar
            // 
            this.btnCancelarGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarGenerar.Image")));
            this.btnCancelarGenerar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelarGenerar.Location = new System.Drawing.Point(166, 55);
            this.btnCancelarGenerar.Name = "btnCancelarGenerar";
            this.btnCancelarGenerar.Size = new System.Drawing.Size(24, 24);
            this.btnCancelarGenerar.TabIndex = 69;
            this.btnCancelarGenerar.TabStop = false;
            this.btnCancelarGenerar.ThemeName = "Office2013Light";
            // 
            // btnAceptarGenerar
            // 
            this.btnAceptarGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptarGenerar.Image")));
            this.btnAceptarGenerar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAceptarGenerar.Location = new System.Drawing.Point(138, 55);
            this.btnAceptarGenerar.Name = "btnAceptarGenerar";
            this.btnAceptarGenerar.Size = new System.Drawing.Size(24, 24);
            this.btnAceptarGenerar.TabIndex = 68;
            this.btnAceptarGenerar.TabStop = false;
            this.btnAceptarGenerar.ThemeName = "Office2013Light";
            // 
            // dtpFecResumen
            // 
            this.dtpFecResumen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecResumen.Location = new System.Drawing.Point(104, 28);
            this.dtpFecResumen.Name = "dtpFecResumen";
            this.dtpFecResumen.Size = new System.Drawing.Size(86, 21);
            this.dtpFecResumen.TabIndex = 67;
            this.dtpFecResumen.TabStop = false;
            this.dtpFecResumen.Text = "3/1/2013";
            this.dtpFecResumen.ThemeName = "Office2013Light";
            this.dtpFecResumen.Value = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            // 
            // dtpFecDocumento
            // 
            this.dtpFecDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDocumento.Location = new System.Drawing.Point(104, 3);
            this.dtpFecDocumento.Name = "dtpFecDocumento";
            this.dtpFecDocumento.Size = new System.Drawing.Size(86, 21);
            this.dtpFecDocumento.TabIndex = 66;
            this.dtpFecDocumento.TabStop = false;
            this.dtpFecDocumento.Text = "3/1/2013";
            this.dtpFecDocumento.ThemeName = "Office2013Light";
            this.dtpFecDocumento.Value = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(24, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(74, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Fec.Resumen:";
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(11, 5);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(87, 18);
            this.radLabel9.TabIndex = 5;
            this.radLabel9.Text = "Fec.Documento:";
            // 
            // frmResumendeBoletas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 449);
            this.Controls.Add(this.gridBoletasxResumenDetBoleta);
            this.Controls.Add(this.pnlResumen);
            this.Name = "frmResumendeBoletas";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Resumen de Boletas";
            this.Load += new System.EventHandler(this.frmResumendeBoletas_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.pnlResumen, 0);
            this.Controls.SetChildIndex(this.gridBoletasxResumenDetBoleta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoletasxResumenDetBoleta.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoletasxResumenDetBoleta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResumen)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarGenerar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptarGenerar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecResumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView gridBoletasxResumenDetBoleta;
        private Telerik.WinControls.UI.RadPanel pnlResumen;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFecResumen;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFecDocumento;
        private Telerik.WinControls.UI.RadButton btnCancelarGenerar;
        private Telerik.WinControls.UI.RadButton btnAceptarGenerar;
    }
}
