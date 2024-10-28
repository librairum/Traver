namespace Com.UI.Win
{
    partial class frmPagoDetracciones : frmBaseMante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoDetracciones));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dtpFecPago = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.txtImpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radDateTimePicker2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtImpFechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridcontrolDet = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.radLabel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaIni)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrolDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrolDet.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
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
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.radGroupBox4.Controls.Add(this.radButton1);
            this.radGroupBox4.Controls.Add(this.txtImpFechaFin);
            this.radGroupBox4.Controls.Add(this.radLabel10);
            this.radGroupBox4.Controls.Add(this.radLabel3);
            this.radGroupBox4.Controls.Add(this.txtImpFechaIni);
            this.radGroupBox4.HeaderText = "Fecha de descarga de la Sunat";
            this.radGroupBox4.Location = new System.Drawing.Point(8, 4);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(447, 46);
            this.radGroupBox4.TabIndex = 7;
            this.radGroupBox4.Text = "Fecha de descarga de la Sunat";
            this.radGroupBox4.Click += new System.EventHandler(this.radGroupBox4_Click);
            // 
            // radButton1
            // 
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(339, 14);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(96, 25);
            this.radButton1.TabIndex = 280;
            this.radButton1.TabStop = false;
            this.radButton1.Text = "Importar";
            this.radButton1.ThemeName = "Office2013Light";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // txtImpFechaFin
            // 
            this.txtImpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtImpFechaFin.Location = new System.Drawing.Point(250, 19);
            this.txtImpFechaFin.Name = "txtImpFechaFin";
            this.txtImpFechaFin.Size = new System.Drawing.Size(83, 20);
            this.txtImpFechaFin.TabIndex = 279;
            this.txtImpFechaFin.TabStop = false;
            this.txtImpFechaFin.Value = new System.DateTime(((long)(0)));
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(13, 19);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(69, 18);
            this.radLabel10.TabIndex = 230;
            this.radLabel10.Text = "Fecha Inicial:";
            // 
            // radLabel3
            // 
            this.radLabel3.Controls.Add(this.radDateTimePicker2);
            this.radLabel3.Location = new System.Drawing.Point(188, 20);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(64, 18);
            this.radLabel3.TabIndex = 278;
            this.radLabel3.Text = "Fecha Final:";
            // 
            // radDateTimePicker2
            // 
            this.radDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.radDateTimePicker2.Location = new System.Drawing.Point(62, 0);
            this.radDateTimePicker2.Name = "radDateTimePicker2";
            this.radDateTimePicker2.Size = new System.Drawing.Size(83, 20);
            this.radDateTimePicker2.TabIndex = 279;
            this.radDateTimePicker2.TabStop = false;
            this.radDateTimePicker2.Value = new System.DateTime(((long)(0)));
            // 
            // txtImpFechaIni
            // 
            this.txtImpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtImpFechaIni.Location = new System.Drawing.Point(82, 19);
            this.txtImpFechaIni.Name = "txtImpFechaIni";
            this.txtImpFechaIni.Size = new System.Drawing.Size(83, 20);
            this.txtImpFechaIni.TabIndex = 277;
            this.txtImpFechaIni.TabStop = false;
            this.txtImpFechaIni.Value = new System.DateTime(((long)(0)));
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radGroupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 56);
            this.panel1.TabIndex = 274;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl.Location = new System.Drawing.Point(0, 89);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(910, 124);
            this.gridControl.TabIndex = 275;
            this.gridControl.Text = "radGridView1";
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click_2);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 17);
            this.panel2.TabIndex = 276;
            // 
            // gridcontrolDet
            // 
            this.gridcontrolDet.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridcontrolDet.Location = new System.Drawing.Point(0, 230);
            // 
            // 
            // 
            gridViewTextBoxColumn2.HeaderText = "column1";
            gridViewTextBoxColumn2.Name = "column1";
            this.gridcontrolDet.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn2});
            this.gridcontrolDet.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridcontrolDet.Name = "gridcontrolDet";
            this.gridcontrolDet.Size = new System.Drawing.Size(910, 216);
            this.gridcontrolDet.TabIndex = 277;
            this.gridcontrolDet.Text = "radGridView1";
            // 
            // frmPagoDetracciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 446);
            this.Controls.Add(this.gridcontrolDet);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPagoDetracciones";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Detraccion Importar";
            this.Load += new System.EventHandler(this.frmPagoDetracciones_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.gridcontrolDet, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.radLabel3.ResumeLayout(false);
            this.radLabel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpFechaIni)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrolDet.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrolDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDateTimePicker dtpFecPago;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadDateTimePicker txtImpFechaFin;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;
        private Telerik.WinControls.UI.RadDateTimePicker txtImpFechaIni;
        private System.Windows.Forms.Panel panel1;
        internal Telerik.WinControls.UI.RadGridView gridControl;
        private System.Windows.Forms.Panel panel2;
        internal Telerik.WinControls.UI.RadGridView gridcontrolDet;
    }
}
