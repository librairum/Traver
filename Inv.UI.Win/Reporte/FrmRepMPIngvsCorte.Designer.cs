namespace Inv.UI.Win
{
    partial class FrmRepMPIngvsCorte
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
            this.cbomesini = new Telerik.WinControls.UI.RadDropDownList();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cbomesfin = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cbomesini
            // 
            this.cbomesini.Location = new System.Drawing.Point(92, 8);
            this.cbomesini.Name = "cbomesini";
            this.cbomesini.Size = new System.Drawing.Size(125, 20);
            this.cbomesini.TabIndex = 4;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radLabel2);
            this.radPanel2.Controls.Add(this.cbomesini);
            this.radPanel2.Controls.Add(this.cbomesfin);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Location = new System.Drawing.Point(12, 49);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(228, 65);
            this.radPanel2.TabIndex = 5;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 34);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(77, 18);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "Periodo Final :";
            // 
            // cbomesfin
            // 
            this.cbomesfin.Location = new System.Drawing.Point(92, 34);
            this.cbomesfin.Name = "cbomesfin";
            this.cbomesfin.Size = new System.Drawing.Size(125, 20);
            this.cbomesfin.TabIndex = 7;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(81, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Periodo Inicio :";
            // 
            // FrmRepMPIngvsCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 131);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmRepMPIngvsCorte";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Ingreso Materia Prima vs Ingreso Corte";
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cbomesini;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList cbomesfin;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
