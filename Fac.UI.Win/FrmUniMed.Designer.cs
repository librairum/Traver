namespace Fac.UI.Win
{
    partial class FrmUniMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUniMed));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbImprimir
            // 
            //this.cbbImprimir.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            //this.cbbImprimir.DrawText = false;
            //this.cbbImprimir.StretchHorizontally = false;
            // 
            // barraComando
            // 
            this.commandBarStripElement1.BackColor = System.Drawing.Color.White;
            this.commandBarStripElement1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.commandBarStripElement1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.commandBarStripElement1.BorderColor3 = System.Drawing.Color.White;
            this.commandBarStripElement1.BorderColor4 = System.Drawing.Color.White;
            this.commandBarStripElement1.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.commandBarStripElement1.Bounds = new System.Drawing.Rectangle(0, 0, 137, 30);
            this.commandBarStripElement1.DesiredLocation = ((System.Drawing.PointF)(resources.GetObject("barraComando.DesiredLocation")));
            this.commandBarStripElement1.DisplayName = "barraComando";
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
            this.radCommandBar1.Size = new System.Drawing.Size(896, 33);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.AllowAddNewRow = false;
            this.gridControl.MasterTemplate.AllowDragToGroup = false;
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(896, 366);
            this.gridControl.TabIndex = 0;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gridControl_CellBeginEdit);
            this.gridControl.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellEndEdit);
            this.gridControl.CurrentRowChanging += new Telerik.WinControls.UI.CurrentRowChangingEventHandler(this.gridControl_CurrentRowChanging);
            this.gridControl.SelectionChanged += new System.EventHandler(this.gridControl_SelectionChanged);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridControl);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(896, 366);
            this.radPanel2.TabIndex = 1003;
            // 
            // FrmUniMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 399);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmUniMed";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Unidad Medida";
            this.ThemeName = "ControlDefault";
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel radPanel2;
    }
}
