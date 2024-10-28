namespace Inv.UI.Win
{
    partial class frmVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucher));
            this.txtMesProvision = new Telerik.WinControls.UI.RadTextBox();
            this.txtTipoCambio = new Telerik.WinControls.UI.RadTextBox();
            this.txtNroVoucher = new Telerik.WinControls.UI.RadTextBox();
            this.txtcodLibro = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaVoucher = new System.Windows.Forms.DateTimePicker();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtConcepto = new Telerik.WinControls.UI.RadTextBox();
            this.txtLibro = new Telerik.WinControls.UI.RadTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMesProvision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodLibro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibro)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // barraComando
            // 
            this.barraComando.BackColor = System.Drawing.Color.White;
            this.barraComando.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.barraComando.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.barraComando.BorderColor3 = System.Drawing.Color.White;
            this.barraComando.BorderColor4 = System.Drawing.Color.White;
            this.barraComando.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.barraComando.Bounds = new System.Drawing.Rectangle(0, 0, 227, 30);
            this.barraComando.DesiredLocation = ((System.Drawing.PointF)(resources.GetObject("barraComando.DesiredLocation")));
            this.barraComando.DisplayName = "barraComando";
            this.barraComando.DrawBorder = true;
            this.barraComando.DrawFill = true;
            this.barraComando.DrawText = false;
            this.barraComando.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraComando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.barraComando.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            // 
            // 
            // 
            this.barraComando.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.barraComando.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(896, 33);
            // 
            // txtMesProvision
            // 
            this.txtMesProvision.Location = new System.Drawing.Point(73, 25);
            this.txtMesProvision.Name = "txtMesProvision";
            this.txtMesProvision.Size = new System.Drawing.Size(61, 20);
            this.txtMesProvision.TabIndex = 7;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(358, 47);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(100, 20);
            this.txtTipoCambio.TabIndex = 17;
            // 
            // txtNroVoucher
            // 
            this.txtNroVoucher.Location = new System.Drawing.Point(73, 71);
            this.txtNroVoucher.Name = "txtNroVoucher";
            this.txtNroVoucher.Size = new System.Drawing.Size(61, 20);
            this.txtNroVoucher.TabIndex = 11;
            // 
            // txtcodLibro
            // 
            this.txtcodLibro.Location = new System.Drawing.Point(73, 48);
            this.txtcodLibro.Name = "txtcodLibro";
            this.txtcodLibro.Size = new System.Drawing.Size(61, 20);
            this.txtcodLibro.TabIndex = 21;
            this.txtcodLibro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodLibro_KeyDown);
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(299, 48);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(53, 18);
            this.radLabel6.TabIndex = 18;
            this.radLabel6.Text = "T.Cambio";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(4, 74);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(67, 18);
            this.radLabel3.TabIndex = 12;
            this.radLabel3.Text = "nro.Voucher";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(38, 48);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(29, 18);
            this.radLabel2.TabIndex = 10;
            this.radLabel2.Text = "libro";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(16, 100);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(55, 18);
            this.radLabel4.TabIndex = 14;
            this.radLabel4.Text = "Concepto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 26);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mes de \r\nProvision";
            // 
            // dtpFechaVoucher
            // 
            this.dtpFechaVoucher.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVoucher.Location = new System.Drawing.Point(360, 21);
            this.dtpFechaVoucher.Name = "dtpFechaVoucher";
            this.dtpFechaVoucher.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaVoucher.TabIndex = 20;
            this.dtpFechaVoucher.Leave += new System.EventHandler(this.dtpFechaVoucher_Leave);
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(317, 21);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(35, 18);
            this.radLabel5.TabIndex = 16;
            this.radLabel5.Text = "Fecha";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(73, 95);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(385, 20);
            this.txtConcepto.TabIndex = 13;
            // 
            // txtLibro
            // 
            this.txtLibro.Location = new System.Drawing.Point(140, 48);
            this.txtLibro.Name = "txtLibro";
            this.txtLibro.Size = new System.Drawing.Size(145, 20);
            this.txtLibro.TabIndex = 9;
            this.txtLibro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLibro_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLabel5);
            this.groupBox1.Controls.Add(this.txtMesProvision);
            this.groupBox1.Controls.Add(this.txtLibro);
            this.groupBox1.Controls.Add(this.txtTipoCambio);
            this.groupBox1.Controls.Add(this.txtConcepto);
            this.groupBox1.Controls.Add(this.txtNroVoucher);
            this.groupBox1.Controls.Add(this.dtpFechaVoucher);
            this.groupBox1.Controls.Add(this.txtcodLibro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radLabel6);
            this.groupBox1.Controls.Add(this.radLabel4);
            this.groupBox1.Controls.Add(this.radLabel3);
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 133);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 399);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVoucher";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Generar voucher";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMesProvision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodLibro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibro)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadTextBox txtTipoCambio;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtConcepto;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtNroVoucher;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtLibro;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtMesProvision;
        private System.Windows.Forms.DateTimePicker dtpFechaVoucher;
        private Telerik.WinControls.UI.RadTextBox txtcodLibro;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
