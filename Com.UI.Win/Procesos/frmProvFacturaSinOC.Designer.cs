namespace Com.UI.Win
{
    partial class frmProvFacturaSinOC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProvFacturaSinOC));
            this.gridFactura = new Telerik.WinControls.UI.RadGridView();
            this.rpOpciones = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnRefrescar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFactura.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpOpciones)).BeginInit();
            this.rpOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFactura
            // 
            this.gridFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFactura.Location = new System.Drawing.Point(0, 93);
            this.gridFactura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridFactura.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridFactura.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridFactura.Name = "gridFactura";
            this.gridFactura.Size = new System.Drawing.Size(1148, 610);
            this.gridFactura.TabIndex = 78;
            this.gridFactura.Text = "radGridView1";
            this.gridFactura.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridFactura_CellDoubleClick);
            
            // rpOpciones
            // 
            this.rpOpciones.Controls.Add(this.radPanel2);
            this.rpOpciones.Controls.Add(this.radPanel1);
            this.rpOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpOpciones.Location = new System.Drawing.Point(0, 47);
            this.rpOpciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rpOpciones.Name = "rpOpciones";
            this.rpOpciones.Size = new System.Drawing.Size(1148, 46);
            this.rpOpciones.TabIndex = 79;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radButton1);
            this.radPanel2.Controls.Add(this.radTextBox1);
            this.radPanel2.Controls.Add(this.radLabel3);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel2.Location = new System.Drawing.Point(524, 0);
            this.radPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1113, 46);
            this.radPanel2.TabIndex = 76;
            // 
            // radButton1
            // 
            this.radButton1.Image = ((System.Drawing.Image)(resources.GetObject("radButton1.Image")));
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(849, 5);
            this.radButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(50, 37);
            this.radButton1.TabIndex = 200;
            this.radButton1.ThemeName = "Office2013Light";
            this.radButton1.Visible = false;
            // 
            // radTextBox1
            // 
            this.radTextBox1.Enabled = false;
            this.radTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBox1.Location = new System.Drawing.Point(736, 5);
            this.radTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(104, 31);
            this.radTextBox1.TabIndex = 199;
            this.radTextBox1.Visible = false;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(628, 11);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(95, 26);
            this.radLabel3.TabIndex = 169;
            this.radLabel3.Text = "Regularizar:";
            this.radLabel3.Visible = false;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnRefrescar);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(524, 46);
            this.radPanel1.TabIndex = 75;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefrescar.Location = new System.Drawing.Point(4, 5);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(76, 38);
            this.btnRefrescar.TabIndex = 168;
            this.btnRefrescar.ThemeName = "Office2013Light";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // frmProvFacturaSinOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 703);
            this.Controls.Add(this.gridFactura);
            this.Controls.Add(this.rpOpciones);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmProvFacturaSinOC";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Provision de Facturas sin Orden de compra";
            this.Load += new System.EventHandler(this.frmProvFacturaSinOC_Load);
            this.Controls.SetChildIndex(this.rpOpciones, 0);
            this.Controls.SetChildIndex(this.gridFactura, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridFactura.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpOpciones)).EndInit();
            this.rpOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Telerik.WinControls.UI.RadGridView gridFactura;
        private Telerik.WinControls.UI.RadPanel rpOpciones;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnRefrescar;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
