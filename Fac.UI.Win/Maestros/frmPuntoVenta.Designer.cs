namespace Fac.UI.Win
{
    partial class frmPuntoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuntoVenta));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // barGuardaCancel
            // 
            this.barGuardaCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.barGuardaCancel.BackColor2 = System.Drawing.Color.Silver;
            this.barGuardaCancel.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.barGuardaCancel.BorderColor3 = System.Drawing.Color.White;
            this.barGuardaCancel.BorderColor4 = System.Drawing.Color.White;
            this.barGuardaCancel.Bounds = new System.Drawing.Rectangle(0, 0, 1, 26);
            this.barGuardaCancel.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.barGuardaCancel.DrawFill = true;
            this.barGuardaCancel.DrawText = false;
            this.barGuardaCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barGuardaCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.barGuardaCancel.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.barGuardaCancel.Margin = new System.Windows.Forms.Padding(2);
            this.barGuardaCancel.MaxSize = new System.Drawing.Size(1, 0);
            this.barGuardaCancel.MinSize = new System.Drawing.Size(2, 0);
            this.barGuardaCancel.StretchHorizontally = false;
            this.barGuardaCancel.Text = "";
            this.barGuardaCancel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.BackColor = System.Drawing.Color.White;
            this.commandBarStripElement1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.commandBarStripElement1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.commandBarStripElement1.BorderColor3 = System.Drawing.Color.White;
            this.commandBarStripElement1.BorderColor4 = System.Drawing.Color.White;
            this.commandBarStripElement1.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.commandBarStripElement1.Bounds = new System.Drawing.Rectangle(0, 0, 250, 30);
            this.commandBarStripElement1.DesiredLocation = ((System.Drawing.PointF)(resources.GetObject("commandBarStripElement1.DesiredLocation")));
            this.commandBarStripElement1.DrawBorder = true;
            this.commandBarStripElement1.DrawFill = true;
            this.commandBarStripElement1.DrawText = false;
            this.commandBarStripElement1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.commandBarStripElement1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.commandBarStripElement1.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            // 
            // 
            // 
            this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(790, 33);
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.BackColor = System.Drawing.Color.White;
            this.commandBarRowElement1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.commandBarRowElement1.BorderColor3 = System.Drawing.Color.White;
            this.commandBarRowElement1.BorderColor4 = System.Drawing.Color.White;
            this.commandBarRowElement1.Bounds = new System.Drawing.Rectangle(0, 0, 788, 30);
            this.commandBarRowElement1.DrawText = false;
            this.commandBarRowElement1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.commandBarRowElement1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.commandBarRowElement1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.commandBarRowElement1.StretchVertically = false;
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
            this.gridControl.Size = new System.Drawing.Size(790, 390);
            this.gridControl.TabIndex = 9;
            this.gridControl.Text = "radGridView1";
            // 
            // frmPuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 423);
            this.Controls.Add(this.gridControl);
            this.Name = "frmPuntoVenta";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Punto de venta";
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView gridControl;

    }
}
