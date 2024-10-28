namespace Com.UI.Win
{
    partial class frmOrdenesdeCompra
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
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rpOpciones = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbOrdenTrabajo = new System.Windows.Forms.RadioButton();
            this.rbOrdenCompra = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpOpciones)).BeginInit();
            this.rpOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 119);
            this.gridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.Name = "column1";
            this.gridControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1335, 691);
            this.gridControl.TabIndex = 74;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellDoubleClick);
            // 
            // rpOpciones
            // 
            this.rpOpciones.Controls.Add(this.label1);
            this.rpOpciones.Controls.Add(this.rbOrdenTrabajo);
            this.rpOpciones.Controls.Add(this.rbOrdenCompra);
            this.rpOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpOpciones.Location = new System.Drawing.Point(0, 73);
            this.rpOpciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rpOpciones.Name = "rpOpciones";
            this.rpOpciones.Size = new System.Drawing.Size(1335, 46);
            this.rpOpciones.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo :";
            // 
            // rbOrdenTrabajo
            // 
            this.rbOrdenTrabajo.AutoSize = true;
            this.rbOrdenTrabajo.Location = new System.Drawing.Point(258, 9);
            this.rbOrdenTrabajo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbOrdenTrabajo.Name = "rbOrdenTrabajo";
            this.rbOrdenTrabajo.Size = new System.Drawing.Size(144, 27);
            this.rbOrdenTrabajo.TabIndex = 1;
            this.rbOrdenTrabajo.Text = "Orden Trabajo";
            this.rbOrdenTrabajo.UseVisualStyleBackColor = true;
            this.rbOrdenTrabajo.CheckedChanged += new System.EventHandler(this.rbOrdenTrabajo_CheckedChanged);
            // 
            // rbOrdenCompra
            // 
            this.rbOrdenCompra.AutoSize = true;
            this.rbOrdenCompra.Checked = true;
            this.rbOrdenCompra.Location = new System.Drawing.Point(87, 9);
            this.rbOrdenCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbOrdenCompra.Name = "rbOrdenCompra";
            this.rbOrdenCompra.Size = new System.Drawing.Size(146, 27);
            this.rbOrdenCompra.TabIndex = 0;
            this.rbOrdenCompra.TabStop = true;
            this.rbOrdenCompra.Text = "Orden compra";
            this.rbOrdenCompra.UseVisualStyleBackColor = true;
            this.rbOrdenCompra.CheckedChanged += new System.EventHandler(this.rbOrdenCompra_CheckedChanged);
            // 
            // frmOrdenesdeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 810);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.rpOpciones);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmOrdenesdeCompra";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Orden de Compra";
            this.Load += new System.EventHandler(this.frmOrdenesdeCompra_Load);
            this.Controls.SetChildIndex(this.rpOpciones, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpOpciones)).EndInit();
            this.rpOpciones.ResumeLayout(false);
            this.rpOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpOpciones;
        private System.Windows.Forms.RadioButton rbOrdenTrabajo;
        private System.Windows.Forms.RadioButton rbOrdenCompra;
        private System.Windows.Forms.Label label1;
        internal Telerik.WinControls.UI.RadGridView gridControl;

    }
}
