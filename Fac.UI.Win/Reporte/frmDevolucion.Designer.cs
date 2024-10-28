namespace Fac.UI.Win
{
    partial class frmDevolucion
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevolucion));
            this.gridDetalle = new Telerik.WinControls.UI.RadGridView();
            this.gridCabecera = new Telerik.WinControls.UI.RadGridView();
            this.rpControl = new Telerik.WinControls.UI.RadPanel();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            this.cbomesfin = new Telerik.WinControls.UI.RadDropDownList();
            this.cbomesini = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.rpCabecera = new Telerik.WinControls.UI.RadPanel();
            this.rpDetalle = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCabecera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCabecera.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpControl)).BeginInit();
            this.rpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpCabecera)).BeginInit();
            this.rpCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpDetalle)).BeginInit();
            this.rpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDetalle
            // 
            this.gridDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetalle.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridDetalle.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridDetalle.Name = "gridDetalle";
            // 
            // 
            // 
            this.gridDetalle.RootElement.AccessibleDescription = null;
            this.gridDetalle.RootElement.AccessibleName = null;
            this.gridDetalle.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.gridDetalle.RootElement.AngleTransform = 0F;
            this.gridDetalle.RootElement.FlipText = false;
            this.gridDetalle.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.gridDetalle.RootElement.Text = null;
            this.gridDetalle.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.gridDetalle.Size = new System.Drawing.Size(738, 190);
            this.gridDetalle.TabIndex = 23;
            this.gridDetalle.TabStop = false;
            this.gridDetalle.Text = "radGridView1";
            // 
            // gridCabecera
            // 
            this.gridCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCabecera.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridCabecera.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridCabecera.Name = "gridCabecera";
            // 
            // 
            // 
            this.gridCabecera.RootElement.AccessibleDescription = null;
            this.gridCabecera.RootElement.AccessibleName = null;
            this.gridCabecera.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.gridCabecera.RootElement.AngleTransform = 0F;
            this.gridCabecera.RootElement.FlipText = false;
            this.gridCabecera.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.gridCabecera.RootElement.Text = null;
            this.gridCabecera.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.gridCabecera.Size = new System.Drawing.Size(738, 149);
            this.gridCabecera.TabIndex = 24;
            this.gridCabecera.TabStop = false;
            this.gridCabecera.Text = "radGridView2";
            this.gridCabecera.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridCabecera_CurrentRowChanged);
            // 
            // rpControl
            // 
            this.rpControl.Controls.Add(this.btnBuscar);
            this.rpControl.Controls.Add(this.cbomesfin);
            this.rpControl.Controls.Add(this.cbomesini);
            this.rpControl.Controls.Add(this.radLabel1);
            this.rpControl.Controls.Add(this.radLabel14);
            this.rpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpControl.Location = new System.Drawing.Point(0, 33);
            this.rpControl.Name = "rpControl";
            this.rpControl.Size = new System.Drawing.Size(738, 33);
            this.rpControl.TabIndex = 27;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(415, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 29);
            this.btnBuscar.TabIndex = 37;
            this.btnBuscar.ThemeName = "Windows8";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbomesfin
            // 
            this.cbomesfin.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesfin.Location = new System.Drawing.Point(279, 6);
            this.cbomesfin.Name = "cbomesfin";
            this.cbomesfin.Size = new System.Drawing.Size(130, 20);
            this.cbomesfin.TabIndex = 36;
            // 
            // cbomesini
            // 
            this.cbomesini.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesini.Location = new System.Drawing.Point(75, 6);
            this.cbomesini.Name = "cbomesini";
            this.cbomesini.Size = new System.Drawing.Size(130, 20);
            this.cbomesini.TabIndex = 35;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(214, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 18);
            this.radLabel1.TabIndex = 34;
            this.radLabel1.Text = "Mes final :";
            // 
            // radLabel14
            // 
            this.radLabel14.Location = new System.Drawing.Point(10, 6);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(59, 18);
            this.radLabel14.TabIndex = 33;
            this.radLabel14.Text = "Mes inicio:";
            // 
            // rpCabecera
            // 
            this.rpCabecera.Controls.Add(this.gridCabecera);
            this.rpCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpCabecera.Location = new System.Drawing.Point(0, 66);
            this.rpCabecera.Name = "rpCabecera";
            this.rpCabecera.Size = new System.Drawing.Size(738, 149);
            this.rpCabecera.TabIndex = 28;
            // 
            // rpDetalle
            // 
            this.rpDetalle.Controls.Add(this.gridDetalle);
            this.rpDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpDetalle.Location = new System.Drawing.Point(0, 215);
            this.rpDetalle.Name = "rpDetalle";
            this.rpDetalle.Size = new System.Drawing.Size(738, 190);
            this.rpDetalle.TabIndex = 29;
            // 
            // frmDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 405);
            this.Controls.Add(this.rpDetalle);
            this.Controls.Add(this.rpCabecera);
            this.Controls.Add(this.rpControl);
            this.Name = "frmDevolucion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Devolucion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDevolucion_Load);
            this.Controls.SetChildIndex(this.rpControl, 0);
            this.Controls.SetChildIndex(this.rpCabecera, 0);
            this.Controls.SetChildIndex(this.rpDetalle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCabecera.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCabecera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpControl)).EndInit();
            this.rpControl.ResumeLayout(false);
            this.rpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpCabecera)).EndInit();
            this.rpCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpDetalle)).EndInit();
            this.rpDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridDetalle;
        private Telerik.WinControls.UI.RadGridView gridCabecera;
        private Telerik.WinControls.UI.RadPanel rpControl;
        private Telerik.WinControls.UI.RadDropDownList cbomesfin;
        private Telerik.WinControls.UI.RadDropDownList cbomesini;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadButton btnBuscar;
        private Telerik.WinControls.UI.RadPanel rpCabecera;
        private Telerik.WinControls.UI.RadPanel rpDetalle;
    }
}
