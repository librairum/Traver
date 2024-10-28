namespace Cos.UI.Win
{
    partial class frmVoucherCosto
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rpActividades = new Telerik.WinControls.UI.RadPanel();
            this.rpActApoyo = new Telerik.WinControls.UI.RadPanel();
            this.rgvEstadoCosto = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpActividades)).BeginInit();
            this.rpActividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpActApoyo)).BeginInit();
            this.rpActApoyo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstadoCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstadoCosto.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(719, 33);
            // 
            // rpActividades
            // 
            this.rpActividades.Controls.Add(this.rpActApoyo);
            this.rpActividades.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpActividades.Location = new System.Drawing.Point(0, 33);
            this.rpActividades.Name = "rpActividades";
            this.rpActividades.Size = new System.Drawing.Size(719, 313);
            this.rpActividades.TabIndex = 8;
            this.rpActividades.Text = "radPanel1";
            // 
            // rpActApoyo
            // 
            this.rpActApoyo.Controls.Add(this.rgvEstadoCosto);
            this.rpActApoyo.Controls.Add(this.radLabel1);
            this.rpActApoyo.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpActApoyo.Location = new System.Drawing.Point(0, 0);
            this.rpActApoyo.Name = "rpActApoyo";
            this.rpActApoyo.Size = new System.Drawing.Size(719, 313);
            this.rpActApoyo.TabIndex = 8;
            this.rpActApoyo.Text = "radPanel1";
            // 
            // rgvEstadoCosto
            // 
            this.rgvEstadoCosto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvEstadoCosto.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            this.rgvEstadoCosto.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgvEstadoCosto.Name = "rgvEstadoCosto";
            this.rgvEstadoCosto.Size = new System.Drawing.Size(719, 295);
            this.rgvEstadoCosto.TabIndex = 4;
            this.rgvEstadoCosto.Text = "radGridView1";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(177, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Estado Costo Produccion y Ventas";
            // 
            // frmVoucherCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 353);
            this.Controls.Add(this.rpActividades);
            this.Name = "frmVoucherCosto";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Distribucion de Produccion por lineas";
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.rpActividades, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpActividades)).EndInit();
            this.rpActividades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpActApoyo)).EndInit();
            this.rpActApoyo.ResumeLayout(false);
            this.rpActApoyo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstadoCosto.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstadoCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpActividades;
        private Telerik.WinControls.UI.RadPanel rpActApoyo;
        private Telerik.WinControls.UI.RadGridView rgvEstadoCosto;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
