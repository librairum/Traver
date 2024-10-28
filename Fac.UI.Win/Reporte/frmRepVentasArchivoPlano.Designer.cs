namespace Fac.UI.Win
{
    partial class frmRepVentasArchivoPlano
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepVentasArchivoPlano));
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rpCabecera = new Telerik.WinControls.UI.RadPanel();
            this.cbomesfin = new Telerik.WinControls.UI.RadDropDownList();
            this.cbomesini = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCopiarTodo = new Telerik.WinControls.UI.RadButton();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpCabecera)).BeginInit();
            this.rpCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopiarTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 64);
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
            this.gridControl.Size = new System.Drawing.Size(729, 341);
            this.gridControl.TabIndex = 22;
            this.gridControl.TabStop = false;
            this.gridControl.ContextMenuOpening += new Telerik.WinControls.UI.ContextMenuOpeningEventHandler(this.gridControl_ContextMenuOpening);
            // 
            // rpCabecera
            // 
            this.rpCabecera.Controls.Add(this.btnCopiarTodo);
            this.rpCabecera.Controls.Add(this.btnBuscar);
            this.rpCabecera.Controls.Add(this.cbomesfin);
            this.rpCabecera.Controls.Add(this.cbomesini);
            this.rpCabecera.Controls.Add(this.radLabel1);
            this.rpCabecera.Controls.Add(this.radLabel14);
            this.rpCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpCabecera.Location = new System.Drawing.Point(0, 33);
            this.rpCabecera.Name = "rpCabecera";
            this.rpCabecera.Size = new System.Drawing.Size(729, 31);
            this.rpCabecera.TabIndex = 23;
            // 
            // cbomesfin
            // 
            this.cbomesfin.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesfin.Location = new System.Drawing.Point(281, 6);
            this.cbomesfin.Name = "cbomesfin";
            this.cbomesfin.Size = new System.Drawing.Size(130, 20);
            this.cbomesfin.TabIndex = 32;
            // 
            // cbomesini
            // 
            this.cbomesini.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbomesini.Location = new System.Drawing.Point(77, 6);
            this.cbomesini.Name = "cbomesini";
            this.cbomesini.Size = new System.Drawing.Size(130, 20);
            this.cbomesini.TabIndex = 31;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(216, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 18);
            this.radLabel1.TabIndex = 29;
            this.radLabel1.Text = "Mes final :";
            // 
            // radLabel14
            // 
            this.radLabel14.Location = new System.Drawing.Point(12, 6);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(59, 18);
            this.radLabel14.TabIndex = 27;
            this.radLabel14.Text = "Mes inicio:";
            // 
            // btnCopiarTodo
            // 
            this.btnCopiarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiarTodo.Image")));
            this.btnCopiarTodo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCopiarTodo.Location = new System.Drawing.Point(497, 1);
            this.btnCopiarTodo.Name = "btnCopiarTodo";
            this.btnCopiarTodo.Size = new System.Drawing.Size(34, 29);
            this.btnCopiarTodo.TabIndex = 34;
            this.btnCopiarTodo.ThemeName = "Windows8";
            this.toolTip1.SetToolTip(this.btnCopiarTodo, "Copiar todas las filas");
            this.btnCopiarTodo.Click += new System.EventHandler(this.btnCopiarTodo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(423, 1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 29);
            this.btnBuscar.TabIndex = 33;
            this.btnBuscar.ThemeName = "Windows8";
            this.toolTip1.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmRepVentasArchivoPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 405);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.rpCabecera);
            this.Name = "frmRepVentasArchivoPlano";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Ventas General";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRepVentasArchivoPlano_Load);
            this.Controls.SetChildIndex(this.rpCabecera, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpCabecera)).EndInit();
            this.rpCabecera.ResumeLayout(false);
            this.rpCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopiarTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel rpCabecera;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadDropDownList cbomesfin;
        private Telerik.WinControls.UI.RadDropDownList cbomesini;
        private Telerik.WinControls.UI.RadButton btnBuscar;
        private Telerik.WinControls.UI.RadButton btnCopiarTodo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
