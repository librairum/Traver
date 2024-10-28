namespace Com.UI.Win
{
    partial class FrmRetencionVoucher : frmBaseMante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRetencionVoucher));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.dtpFecPago = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtImpFechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtImpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaFin)).BeginInit();
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
            this.commandBarStripElement1.Bounds = new System.Drawing.Rectangle(0, 0, 378, 30);
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
            ((Telerik.WinControls.UI.CommandBarButton)(this.commandBarStripElement1.GetChildAt(1).GetChildAt(16))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.commandBarStripElement1.GetChildAt(1).GetChildAt(16))).Text = "commandBarButton1";
            ((Telerik.WinControls.UI.CommandBarButton)(this.commandBarStripElement1.GetChildAt(1).GetChildAt(16))).ToolTipText = "Generar Voucher";
            ((Telerik.WinControls.UI.CommandBarButton)(this.commandBarStripElement1.GetChildAt(1).GetChildAt(16))).Name = "cbbGenerarVoucher";
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radCommandBar1.Size = new System.Drawing.Size(910, 33);
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.BackColor = System.Drawing.Color.White;
            this.commandBarRowElement1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.commandBarRowElement1.BorderColor3 = System.Drawing.Color.White;
            this.commandBarRowElement1.BorderColor4 = System.Drawing.Color.White;
            this.commandBarRowElement1.Bounds = new System.Drawing.Rectangle(0, 0, 908, 30);
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
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(910, 413);
            this.gridControl.TabIndex = 225;
            this.gridControl.Text = "radGridView1";
            // 
            // dtpFecPago
            // 
            this.dtpFecPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecPago.Location = new System.Drawing.Point(358, 31);
            this.dtpFecPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFecPago.Name = "dtpFecPago";
            this.dtpFecPago.Size = new System.Drawing.Size(110, 27);
            this.dtpFecPago.TabIndex = 249;
            this.dtpFecPago.TabStop = false;
            this.dtpFecPago.Text = "01/03/2013";
            this.dtpFecPago.Value = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            // 
            // txtImpFechaIni
            // 
            this.txtImpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtImpFechaIni.Location = new System.Drawing.Point(136, 67);
            this.txtImpFechaIni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtImpFechaIni.Name = "txtImpFechaIni";
            this.txtImpFechaIni.Size = new System.Drawing.Size(124, 27);
            this.txtImpFechaIni.TabIndex = 277;
            this.txtImpFechaIni.TabStop = false;
            this.txtImpFechaIni.Value = new System.DateTime(((long)(0)));
            // 
            // txtImpFechaFin
            // 
            this.txtImpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtImpFechaFin.Location = new System.Drawing.Point(382, 66);
            this.txtImpFechaFin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtImpFechaFin.Name = "txtImpFechaFin";
            this.txtImpFechaFin.Size = new System.Drawing.Size(124, 27);
            this.txtImpFechaFin.TabIndex = 279;
            this.txtImpFechaFin.TabStop = false;
            this.txtImpFechaFin.Value = new System.DateTime(((long)(0)));
            // 
            // FrmRetencionVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 446);
            this.Controls.Add(this.gridControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRetencionVoucher";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Generar Asiento Retencion";
            this.Load += new System.EventHandler(this.FrmRetencionVoucher_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFecPago;
        private Telerik.WinControls.UI.RadDateTimePicker txtImpFechaIni;
        private Telerik.WinControls.UI.RadDateTimePicker txtImpFechaFin;
    }
}
