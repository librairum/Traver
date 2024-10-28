namespace Fac.UI.Win
{
    partial class frmVoucherContable
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.OptEstado2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.OptEstado0 = new Telerik.WinControls.UI.RadRadioButton();
            this.OptEstado1 = new Telerik.WinControls.UI.RadRadioButton();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptEstado2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptEstado0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptEstado1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(766, 33);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.OptEstado2);
            this.radGroupBox2.Controls.Add(this.radLabel11);
            this.radGroupBox2.Controls.Add(this.OptEstado0);
            this.radGroupBox2.Controls.Add(this.OptEstado1);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(766, 29);
            this.radGroupBox2.TabIndex = 34;
            this.radGroupBox2.ThemeName = "TelerikMetroTouch";
            // 
            // OptEstado2
            // 
            this.OptEstado2.Location = new System.Drawing.Point(385, 4);
            this.OptEstado2.Name = "OptEstado2";
            this.OptEstado2.Size = new System.Drawing.Size(56, 19);
            this.OptEstado2.TabIndex = 34;
            this.OptEstado2.TabStop = false;
            this.OptEstado2.Text = "Todas";
            this.OptEstado2.ThemeName = "Office2013Light";
            this.OptEstado2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.OptEstado2_ToggleStateChanged);
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(5, 4);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(147, 18);
            this.radLabel11.TabIndex = 33;
            this.radLabel11.Text = "Estado contable de Factura :";
            // 
            // OptEstado0
            // 
            this.OptEstado0.Location = new System.Drawing.Point(158, 4);
            this.OptEstado0.Name = "OptEstado0";
            this.OptEstado0.Size = new System.Drawing.Size(110, 19);
            this.OptEstado0.TabIndex = 31;
            this.OptEstado0.TabStop = false;
            this.OptEstado0.Text = "Por Contabilizar";
            this.OptEstado0.ThemeName = "Office2013Light";
            this.OptEstado0.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.OptEstado0_ToggleStateChanged);
            // 
            // OptEstado1
            // 
            this.OptEstado1.Location = new System.Drawing.Point(274, 4);
            this.OptEstado1.Name = "OptEstado1";
            this.OptEstado1.Size = new System.Drawing.Size(105, 19);
            this.OptEstado1.TabIndex = 32;
            this.OptEstado1.TabStop = false;
            this.OptEstado1.Text = "Contabilidades";
            this.OptEstado1.ThemeName = "Office2013Light";
            this.OptEstado1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.OptEstado1_ToggleStateChanged);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 62);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(766, 361);
            this.gridControl.TabIndex = 35;
            this.gridControl.Text = "radGridView1";
            this.gridControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl_KeyDown);
            // 
            // frmVoucherContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 423);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmVoucherContable";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Voucher contable";
            this.Load += new System.EventHandler(this.frmVoucherContable_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radGroupBox2, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptEstado2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptEstado0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptEstado1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton OptEstado0;
        private Telerik.WinControls.UI.RadRadioButton OptEstado1;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadRadioButton OptEstado2;
        public Telerik.WinControls.UI.RadGridView gridControl;
    }
}
