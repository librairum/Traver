namespace Com.UI.Win
{
    partial class frmMoviDocumentoCompraRpt
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
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.OptAnual = new Telerik.WinControls.UI.RadRadioButton();
            this.OptMensual = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptMensual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(771, 45);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radLabel11);
            this.radGroupBox2.Controls.Add(this.OptAnual);
            this.radGroupBox2.Controls.Add(this.OptMensual);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox2.Enabled = false;
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 45);
            this.radGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(3, 28, 3, 3);
            this.radGroupBox2.Size = new System.Drawing.Size(771, 45);
            this.radGroupBox2.TabIndex = 35;
            this.radGroupBox2.ThemeName = "TelerikMetroTouch";
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(8, 6);
            this.radLabel11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(219, 26);
            this.radLabel11.TabIndex = 33;
            this.radLabel11.Text = "Estado contable de Factura :";
            // 
            // OptAnual
            // 
            this.OptAnual.Location = new System.Drawing.Point(237, 6);
            this.OptAnual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OptAnual.Name = "OptAnual";
            this.OptAnual.Size = new System.Drawing.Size(72, 28);
            this.OptAnual.TabIndex = 31;
            this.OptAnual.TabStop = false;
            this.OptAnual.Text = "Anual";
            this.OptAnual.ThemeName = "Office2013Light";
            // 
            // OptMensual
            // 
            this.OptMensual.Location = new System.Drawing.Point(368, 6);
            this.OptMensual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OptMensual.Name = "OptMensual";
            this.OptMensual.Size = new System.Drawing.Size(95, 28);
            this.OptMensual.TabIndex = 32;
            this.OptMensual.TabStop = false;
            this.OptMensual.Text = "Mensual";
            this.OptMensual.ThemeName = "Office2013Light";
            // 
            // frmMoviDocumentoCompraRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 378);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmMoviDocumentoCompraRpt";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Movimiento de documento de Compra";
            this.Load += new System.EventHandler(this.frmMoviDocumentoCompraRpt_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptMensual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadRadioButton OptAnual;
        private Telerik.WinControls.UI.RadRadioButton OptMensual;

    }
}
