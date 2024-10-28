namespace Cos.UI.Win
{
    partial class frmPasarCostoProduccion
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
            this.rpImportacion = new Telerik.WinControls.UI.RadPanel();
            this.chkproductoproceso = new System.Windows.Forms.CheckBox();
            this.chkproductoterminado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.rpImportacion)).BeginInit();
            this.rpImportacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rpImportacion
            // 
            this.rpImportacion.Controls.Add(this.chkproductoterminado);
            this.rpImportacion.Controls.Add(this.chkproductoproceso);
            this.rpImportacion.Location = new System.Drawing.Point(12, 39);
            this.rpImportacion.Name = "rpImportacion";
            this.rpImportacion.Size = new System.Drawing.Size(826, 63);
            this.rpImportacion.TabIndex = 3;
            // 
            // chkproductoproceso
            // 
            this.chkproductoproceso.AutoSize = true;
            this.chkproductoproceso.Checked = true;
            this.chkproductoproceso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkproductoproceso.Location = new System.Drawing.Point(20, 4);
            this.chkproductoproceso.Name = "chkproductoproceso";
            this.chkproductoproceso.Size = new System.Drawing.Size(121, 17);
            this.chkproductoproceso.TabIndex = 0;
            this.chkproductoproceso.Text = "Productos Proceso";
            this.chkproductoproceso.UseVisualStyleBackColor = true;
            // 
            // chkproductoterminado
            // 
            this.chkproductoterminado.AutoSize = true;
            this.chkproductoterminado.Checked = true;
            this.chkproductoterminado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkproductoterminado.Location = new System.Drawing.Point(20, 28);
            this.chkproductoterminado.Name = "chkproductoterminado";
            this.chkproductoterminado.Size = new System.Drawing.Size(130, 17);
            this.chkproductoterminado.TabIndex = 1;
            this.chkproductoterminado.Text = "Producto Terminado";
            this.chkproductoterminado.UseVisualStyleBackColor = true;
            // 
            // frmPasarCostoProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 117);
            this.Controls.Add(this.rpImportacion);
            this.Name = "frmPasarCostoProduccion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Traspasar Costo Produccion a PP y PT";
            this.Controls.SetChildIndex(this.rpImportacion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rpImportacion)).EndInit();
            this.rpImportacion.ResumeLayout(false);
            this.rpImportacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpImportacion;
        private System.Windows.Forms.CheckBox chkproductoterminado;
        private System.Windows.Forms.CheckBox chkproductoproceso;


    }
}
