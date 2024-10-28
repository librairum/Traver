namespace Prod.UI.Win
{
    partial class FrmRepBloquesvsCortes
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboPeriodoInicio = new Telerik.WinControls.UI.RadDropDownList();
            this.cboPeriodoFin = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodoInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodoFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Size = new System.Drawing.Size(246, 32);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(82, 18);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "Periodo Inicial :";
            // 
            // cboPeriodoInicio
            // 
            this.cboPeriodoInicio.Location = new System.Drawing.Point(105, 39);
            this.cboPeriodoInicio.Name = "cboPeriodoInicio";
            this.cboPeriodoInicio.Size = new System.Drawing.Size(125, 20);
            this.cboPeriodoInicio.TabIndex = 6;
            // 
            // cboPeriodoFin
            // 
            this.cboPeriodoFin.Location = new System.Drawing.Point(105, 65);
            this.cboPeriodoFin.Name = "cboPeriodoFin";
            this.cboPeriodoFin.Size = new System.Drawing.Size(125, 20);
            this.cboPeriodoFin.TabIndex = 8;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 67);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(77, 18);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Periodo Final :";
            // 
            // FrmRepBloquesvsCortes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 95);
            this.Controls.Add(this.cboPeriodoFin);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.cboPeriodoInicio);
            this.Controls.Add(this.radLabel1);
            this.Name = "FrmRepBloquesvsCortes";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Bloques vs Cortes";
            this.Controls.SetChildIndex(this.radLabel1, 0);
            this.Controls.SetChildIndex(this.cboPeriodoInicio, 0);
            this.Controls.SetChildIndex(this.radLabel2, 0);
            this.Controls.SetChildIndex(this.cboPeriodoFin, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodoInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodoFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboPeriodoInicio;
        private Telerik.WinControls.UI.RadDropDownList cboPeriodoFin;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
