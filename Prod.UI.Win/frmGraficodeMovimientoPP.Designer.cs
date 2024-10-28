namespace Prod.UI.Win
{
    partial class frmGraficodeMovimientoPP
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
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            this.radPivotGrid1 = new Telerik.WinControls.UI.RadPivotGrid();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPivotGrid1
            // 
            this.radPivotGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPivotGrid1.Location = new System.Drawing.Point(0, 320);
            this.radPivotGrid1.Name = "radPivotGrid1";
            this.radPivotGrid1.Size = new System.Drawing.Size(1165, 170);
            this.radPivotGrid1.TabIndex = 0;
            this.radPivotGrid1.Text = "radPivotGrid1";
            // 
            // radChartView1
            // 
            this.radChartView1.AreaDesign = cartesianArea1;
            this.radChartView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radChartView1.Location = new System.Drawing.Point(0, 0);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.ShowGrid = false;
            this.radChartView1.Size = new System.Drawing.Size(1165, 320);
            this.radChartView1.TabIndex = 1;
            this.radChartView1.Text = "radChartView1";
            // 
            // frmGraficodeMovimientoPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 490);
            this.Controls.Add(this.radPivotGrid1);
            this.Controls.Add(this.radChartView1);
            this.Name = "frmGraficodeMovimientoPP";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmGraficodeMovimientoPP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
        private Telerik.WinControls.UI.RadChartView radChartView1;
    }
}
