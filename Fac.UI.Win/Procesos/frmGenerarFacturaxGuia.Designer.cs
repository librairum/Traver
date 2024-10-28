namespace Fac.UI.Win
{
    partial class frmGenerarFacturaxGuia
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarFacturaxGuia));
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            this.dtpFechaFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpFechaIni = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtmes = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtrangofechas = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtmes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangofechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(972, 33);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 62);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(972, 402);
            this.gridControl.TabIndex = 6;
            this.gridControl.Text = "radGridView1";
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnBuscar);
            this.radGroupBox2.Controls.Add(this.dtpFechaFin);
            this.radGroupBox2.Controls.Add(this.dtpFechaIni);
            this.radGroupBox2.Controls.Add(this.rbtmes);
            this.radGroupBox2.Controls.Add(this.rbtrangofechas);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(972, 29);
            this.radGroupBox2.TabIndex = 35;
            this.radGroupBox2.ThemeName = "TelerikMetroTouch";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(923, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 23);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.ThemeName = "Office2013Light";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(831, 4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaFin.TabIndex = 35;
            this.dtpFechaFin.TabStop = false;
            this.dtpFechaFin.Text = "01/03/2013";
            this.dtpFechaFin.Value = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(739, 4);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaIni.TabIndex = 34;
            this.dtpFechaIni.TabStop = false;
            this.dtpFechaIni.Text = "01/03/2013";
            this.dtpFechaIni.Value = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            // 
            // rbtmes
            // 
            this.rbtmes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtmes.Location = new System.Drawing.Point(576, 4);
            this.rbtmes.Name = "rbtmes";
            this.rbtmes.Size = new System.Drawing.Size(46, 19);
            this.rbtmes.TabIndex = 31;
            this.rbtmes.Text = "mes";
            this.rbtmes.ThemeName = "Office2013Light";
            this.rbtmes.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.rbtmes.CheckStateChanged += new System.EventHandler(this.rbtmes_CheckStateChanged);
            // 
            // rbtrangofechas
            // 
            this.rbtrangofechas.Location = new System.Drawing.Point(628, 4);
            this.rbtrangofechas.Name = "rbtrangofechas";
            this.rbtrangofechas.Size = new System.Drawing.Size(105, 19);
            this.rbtrangofechas.TabIndex = 32;
            this.rbtrangofechas.TabStop = false;
            this.rbtrangofechas.Text = "rango de fecha";
            this.rbtrangofechas.ThemeName = "Office2013Light";
            this.rbtrangofechas.CheckStateChanged += new System.EventHandler(this.rbtrangofechas_CheckStateChanged);
            // 
            // frmGenerarFacturaxGuia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 464);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmGenerarFacturaxGuia";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Generar factura desde Guia";
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radGroupBox2, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtmes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangofechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rbtmes;
        private Telerik.WinControls.UI.RadRadioButton rbtrangofechas;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaFin;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFechaIni;
        private Telerik.WinControls.UI.RadButton btnBuscar;
    }
}
