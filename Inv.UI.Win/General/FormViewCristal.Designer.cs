namespace Inv.UI.Win
{
    partial class FormViewCristal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewCristal));
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv.Location = new System.Drawing.Point(0, 0);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(804, 585);
            this.crv.TabIndex = 0;
            // 
            // FormViewCristal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 585);
            this.Controls.Add(this.crv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormViewCristal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor de Reporte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormViewCristal_FormClosed);
            this.Load += new System.EventHandler(this.FormViewCristal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Drawing.Printing.PrintDocument PrintDocument1;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
    }
}