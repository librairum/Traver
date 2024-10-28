namespace Fac.UI.Win
{
    partial class frmFacturasCancelar
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
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.gridClientes = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCabecera = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCabecera)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 13);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(501, 514);
            this.gridControl.TabIndex = 6;
            this.gridControl.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gridControl_CellFormatting);
            this.gridControl.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellDoubleClick);
            this.gridControl.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridControl_CommandCellClick);
            // 
            // gridClientes
            // 
            this.gridClientes.Location = new System.Drawing.Point(0, 3);
            // 
            // 
            // 
            this.gridClientes.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.Size = new System.Drawing.Size(618, 527);
            this.gridClientes.TabIndex = 7;
            this.gridClientes.SelectionChanged += new System.EventHandler(this.gridClientes_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CLLIENTE : SANIHOLD";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.gridControl);
            this.pnlCabecera.Controls.Add(this.label1);
            this.pnlCabecera.Location = new System.Drawing.Point(745, 3);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(501, 527);
            this.pnlCabecera.TabIndex = 9;
            // 
            // frmFacturasCancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 491);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.gridClientes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmFacturasCancelar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Facturas por cancelar";
            this.Load += new System.EventHandler(this.frmFacturasCancelar_Load);
            this.Controls.SetChildIndex(this.gridClientes, 0);
            this.Controls.SetChildIndex(this.pnlCabecera, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCabecera)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal Telerik.WinControls.UI.RadGridView gridControl;
        protected internal Telerik.WinControls.UI.RadGridView gridClientes;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadPanel pnlCabecera;
    }
}
