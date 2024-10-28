namespace Inv.UI.Win
{
    partial class FrmValidaciones
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbvalidaciones = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbvalidaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.rbvalidaciones);
            this.radGroupBox1.HeaderText = "Opcion de Reporte";
            this.radGroupBox1.Location = new System.Drawing.Point(18, 9);
            this.radGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 3);
            this.radGroupBox1.Size = new System.Drawing.Size(1264, 77);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Opcion de Reporte";
            // 
            // rbvalidaciones
            // 
            this.rbvalidaciones.Location = new System.Drawing.Point(42, 32);
            this.rbvalidaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbvalidaciones.Name = "rbvalidaciones";
            this.rbvalidaciones.Size = new System.Drawing.Size(80, 26);
            this.rbvalidaciones.TabIndex = 10;
            this.rbvalidaciones.Text = "Periodo";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radGroupBox1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 51);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1323, 701);
            this.radPanel1.TabIndex = 3;
            // 
            // FrmValidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 752);
            this.Controls.Add(this.radPanel1);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "FrmValidaciones";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Validaciones";
            this.Load += new System.EventHandler(this.FrmValidaciones_Load);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbvalidaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton rbvalidaciones;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
