namespace Fac.UI.Win
{
    partial class frmGenerarDocProvisional
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.pnlCab = new Telerik.WinControls.UI.RadPanel();
            this.chkImprimeFactProvisional = new System.Windows.Forms.CheckBox();
            this.chkImprimirCertificado = new System.Windows.Forms.CheckBox();
            this.chkImprimePacking = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCab)).BeginInit();
            this.pnlCab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 55);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(555, 350);
            this.gridControl.TabIndex = 7;
            this.gridControl.Text = "radGridView1";
            this.gridControl.ThemeName = "Office2013Light";
            // 
            // pnlCab
            // 
            this.pnlCab.BackColor = System.Drawing.Color.White;
            this.pnlCab.Controls.Add(this.chkImprimeFactProvisional);
            this.pnlCab.Controls.Add(this.chkImprimirCertificado);
            this.pnlCab.Controls.Add(this.chkImprimePacking);
            this.pnlCab.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCab.Location = new System.Drawing.Point(0, 33);
            this.pnlCab.Name = "pnlCab";
            this.pnlCab.Size = new System.Drawing.Size(555, 22);
            this.pnlCab.TabIndex = 16;
            this.pnlCab.TabStop = false;
            // 
            // chkImprimeFactProvisional
            // 
            this.chkImprimeFactProvisional.AutoSize = true;
            this.chkImprimeFactProvisional.Location = new System.Drawing.Point(307, 3);
            this.chkImprimeFactProvisional.Name = "chkImprimeFactProvisional";
            this.chkImprimeFactProvisional.Size = new System.Drawing.Size(168, 17);
            this.chkImprimeFactProvisional.TabIndex = 2;
            this.chkImprimeFactProvisional.Text = "Imprimir Factura Provisional";
            this.chkImprimeFactProvisional.UseVisualStyleBackColor = true;
            // 
            // chkImprimirCertificado
            // 
            this.chkImprimirCertificado.AutoSize = true;
            this.chkImprimirCertificado.Location = new System.Drawing.Point(142, 3);
            this.chkImprimirCertificado.Name = "chkImprimirCertificado";
            this.chkImprimirCertificado.Size = new System.Drawing.Size(164, 17);
            this.chkImprimirCertificado.TabIndex = 1;
            this.chkImprimirCertificado.Text = "Imprimir Certificado origen";
            this.chkImprimirCertificado.UseVisualStyleBackColor = true;
            // 
            // chkImprimePacking
            // 
            this.chkImprimePacking.AutoSize = true;
            this.chkImprimePacking.Location = new System.Drawing.Point(12, 3);
            this.chkImprimePacking.Name = "chkImprimePacking";
            this.chkImprimePacking.Size = new System.Drawing.Size(131, 17);
            this.chkImprimePacking.TabIndex = 0;
            this.chkImprimePacking.Text = "Imprimir Packing List";
            this.chkImprimePacking.UseVisualStyleBackColor = true;
            // 
            // frmGenerarDocProvisional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 405);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlCab);
            this.Name = "frmGenerarDocProvisional";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Generar documentos provisionales";
            this.Controls.SetChildIndex(this.pnlCab, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCab)).EndInit();
            this.pnlCab.ResumeLayout(false);
            this.pnlCab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel pnlCab;
        private System.Windows.Forms.CheckBox chkImprimeFactProvisional;
        private System.Windows.Forms.CheckBox chkImprimirCertificado;
        private System.Windows.Forms.CheckBox chkImprimePacking;
    }
}
