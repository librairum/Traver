namespace Inv.UI.Win.Procesos
{
    partial class frmEntradaSalida
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtpfechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnbuscar = new Telerik.WinControls.UI.RadButton();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).BeginInit();
            this.radPageView.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView
            // 
            this.radPageView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView.Location = new System.Drawing.Point(0, 28);
            this.radPageView.Size = new System.Drawing.Size(1228, 390);
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.gridControl);
            this.radPageViewPage1.Controls.Add(this.radGroupBox1);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.radPageViewPage1.Location = new System.Drawing.Point(5, 31);
            this.radPageViewPage1.Size = new System.Drawing.Size(1218, 354);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 71);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1218, 283);
            this.gridControl.TabIndex = 0;
            this.gridControl.Text = "radGridView1";
            this.gridControl.ThemeName = "Office2013Light";
            this.gridControl.FilterPopupRequired += new Telerik.WinControls.UI.FilterPopupRequiredEventHandler(this.gridControl_FilterPopupRequired);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(18, 9);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(76, 18);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "Rango fechas:";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.dtpfechaFin);
            this.radGroupBox1.Controls.Add(this.dtpFechaini);
            this.radGroupBox1.Controls.Add(this.btnbuscar);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1218, 71);
            this.radGroupBox1.TabIndex = 9;
            // 
            // dtpfechaFin
            // 
            this.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaFin.Location = new System.Drawing.Point(112, 35);
            this.dtpfechaFin.Name = "dtpfechaFin";
            this.dtpfechaFin.Size = new System.Drawing.Size(89, 20);
            this.dtpfechaFin.TabIndex = 12;
            this.dtpfechaFin.TabStop = false;
            this.dtpfechaFin.Text = "28/04/2015";
            this.dtpfechaFin.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // dtpFechaini
            // 
            this.dtpFechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaini.Location = new System.Drawing.Point(112, 9);
            this.dtpFechaini.Name = "dtpFechaini";
            this.dtpFechaini.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaini.TabIndex = 11;
            this.dtpFechaini.TabStop = false;
            this.dtpFechaini.Text = "28/04/2015";
            this.dtpFechaini.Value = new System.DateTime(2015, 4, 28, 12, 23, 27, 422);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(218, 8);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(66, 23);
            this.btnbuscar.TabIndex = 10;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // frmEntradaSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 469);
            this.Name = "frmEntradaSalida";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Entrada y salida";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).EndInit();
            this.radPageView.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpfechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadButton btnbuscar;
        private Telerik.WinControls.UI.RadDateTimePicker dtpfechaFin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaini;
    }
}
