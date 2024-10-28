namespace Fac.UI.Win
{
    partial class frmRepControlDevoluciones
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
            this.rbResumido = new Telerik.WinControls.UI.RadRadioButton();
            this.rbDetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.rbResumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rbResumido
            // 
            this.rbResumido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbResumido.Location = new System.Drawing.Point(17, 21);
            this.rbResumido.Name = "rbResumido";
            this.rbResumido.Size = new System.Drawing.Size(112, 18);
            this.rbResumido.TabIndex = 0;
            this.rbResumido.Text = "Reporte resumido.";
            this.rbResumido.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rbDetallado
            // 
            this.rbDetallado.Location = new System.Drawing.Point(152, 21);
            this.rbDetallado.Name = "rbDetallado";
            this.rbDetallado.Size = new System.Drawing.Size(112, 18);
            this.rbDetallado.TabIndex = 1;
            this.rbDetallado.TabStop = false;
            this.rbDetallado.Text = "Reporte detallado.";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.rbResumido);
            this.radGroupBox1.Controls.Add(this.rbDetallado);
            this.radGroupBox1.HeaderText = "Opciones";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(281, 49);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Opciones";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radGroupBox1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(594, 230);
            this.radPanel2.TabIndex = 4;
            // 
            // frmRepControlDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 263);
            this.Controls.Add(this.radPanel2);
            this.Name = "frmRepControlDevoluciones";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte devoluciones";
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbResumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadRadioButton rbDetallado;
        private Telerik.WinControls.UI.RadRadioButton rbResumido;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
    }
}
