namespace Fac.UI.Win
{
    partial class frmRepArtiClixArtiProd
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
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            // 
            // 
            // 
            this.gridControl.RootElement.AccessibleDescription = null;
            this.gridControl.RootElement.AccessibleName = null;
            this.gridControl.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.gridControl.RootElement.AngleTransform = 0F;
            this.gridControl.RootElement.FlipText = false;
            this.gridControl.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl.RootElement.Text = null;
            this.gridControl.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.gridControl.Size = new System.Drawing.Size(475, 372);
            this.gridControl.TabIndex = 23;
            this.gridControl.TabStop = false;
            this.gridControl.Text = "radGridView1";
            // 
            // frmRepArtiClixArtiProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 405);
            this.Controls.Add(this.gridControl);
            this.Name = "frmRepArtiClixArtiProd";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Art.cliente por Art.Produccion";
            this.Load += new System.EventHandler(this.frmRepArtiClixArtiProd_Load);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
    }
}
