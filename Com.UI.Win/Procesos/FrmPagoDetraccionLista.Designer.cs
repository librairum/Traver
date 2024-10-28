namespace Com.UI.Win
{
    partial class FrmPagoDetraccionLista
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
            this.rpOpcionesReporte = new Telerik.WinControls.UI.RadPanel();
            this.lblReporte = new System.Windows.Forms.Label();
            this.Detalle = new System.Windows.Forms.RadioButton();
            this.Resumen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpOpcionesReporte)).BeginInit();
            this.rpOpcionesReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl.Location = new System.Drawing.Point(0, 116);
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
            this.gridControl.Size = new System.Drawing.Size(1352, 657);
            this.gridControl.TabIndex = 74;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellDoubleClick);
            // 
            // rpOpcionesReporte
            // 
            this.rpOpcionesReporte.Controls.Add(this.lblReporte);
            this.rpOpcionesReporte.Controls.Add(this.Detalle);
            this.rpOpcionesReporte.Controls.Add(this.Resumen);
            this.rpOpcionesReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpOpcionesReporte.Location = new System.Drawing.Point(0, 47);
            this.rpOpcionesReporte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rpOpcionesReporte.Name = "rpOpcionesReporte";
            this.rpOpcionesReporte.Size = new System.Drawing.Size(1352, 69);
            this.rpOpcionesReporte.TabIndex = 75;
            // 
            // lblReporte
            // 
            this.lblReporte.AutoSize = true;
            this.lblReporte.Location = new System.Drawing.Point(4, 6);
            this.lblReporte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(155, 23);
            this.lblReporte.TabIndex = 2;
            this.lblReporte.Text = "Opciones Reporte :";
            // 
            // Detalle
            // 
            this.Detalle.AutoSize = true;
            this.Detalle.Location = new System.Drawing.Point(296, 5);
            this.Detalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Detalle.Name = "Detalle";
            this.Detalle.Size = new System.Drawing.Size(88, 27);
            this.Detalle.TabIndex = 1;
            this.Detalle.Text = "Detalle";
            this.Detalle.UseVisualStyleBackColor = true;
            // 
            // Resumen
            // 
            this.Resumen.AutoSize = true;
            this.Resumen.Checked = true;
            this.Resumen.Location = new System.Drawing.Point(183, 5);
            this.Resumen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Resumen.Name = "Resumen";
            this.Resumen.Size = new System.Drawing.Size(105, 27);
            this.Resumen.TabIndex = 0;
            this.Resumen.TabStop = true;
            this.Resumen.Text = "Resumen";
            this.Resumen.UseVisualStyleBackColor = true;
            // 
            // FrmPagoDetraccionLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 773);
            this.Controls.Add(this.rpOpcionesReporte);
            this.Controls.Add(this.gridControl);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "FrmPagoDetraccionLista";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Detracciones";
            this.Load += new System.EventHandler(this.FrmPagoDetraccionLista_Load);
            this.Controls.SetChildIndex(this.gridControl, 0);
            this.Controls.SetChildIndex(this.rpOpcionesReporte, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpOpcionesReporte)).EndInit();
            this.rpOpcionesReporte.ResumeLayout(false);
            this.rpOpcionesReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel rpOpcionesReporte;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.RadioButton Detalle;
        private System.Windows.Forms.RadioButton Resumen;

    }
}
