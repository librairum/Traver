namespace Cos.UI.Win
{
    partial class FormViewReport
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
            this.rpv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpv
            // 
            this.rpv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpv.Location = new System.Drawing.Point(0, 0);
            this.rpv.Name = "rpv";
            this.rpv.Size = new System.Drawing.Size(485, 308);
            this.rpv.TabIndex = 0;
            // 
            // FormViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 308);
            this.Controls.Add(this.rpv);
            this.Name = "FormViewReport";
            this.Text = "FormViewReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormViewReport_FormClosed);
            this.Load += new System.EventHandler(this.FormViewReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv;

    }
}