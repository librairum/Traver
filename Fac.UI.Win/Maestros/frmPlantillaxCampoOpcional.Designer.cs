namespace Fac.UI.Win
{
    partial class frmPlantillaxCampoOpcional
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
            this.gridPlantilla = new Telerik.WinControls.UI.RadGridView();
            this.gridCampos = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlantilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlantilla.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCampos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(899, 33);
            // 
            // gridPlantilla
            // 
            this.gridPlantilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlantilla.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridPlantilla.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridPlantilla.Name = "gridPlantilla";
            this.gridPlantilla.Size = new System.Drawing.Size(298, 390);
            this.gridPlantilla.TabIndex = 10;
            this.gridPlantilla.Text = "radGridView1";
            // 
            // gridCampos
            // 
            this.gridCampos.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridCampos.Location = new System.Drawing.Point(298, 33);
            // 
            // 
            // 
            this.gridCampos.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridCampos.Name = "gridCampos";
            this.gridCampos.Size = new System.Drawing.Size(601, 390);
            this.gridCampos.TabIndex = 11;
            this.gridCampos.Text = "radGridView1";
            // 
            // frmPlantillaxCampoOpcional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 423);
            this.Controls.Add(this.gridPlantilla);
            this.Controls.Add(this.gridCampos);
            this.Name = "frmPlantillaxCampoOpcional";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Plantillas por campo opcional";
            this.Load += new System.EventHandler(this.frmPlantillaxCampoOpcional_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.gridCampos, 0);
            this.Controls.SetChildIndex(this.gridPlantilla, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlantilla.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlantilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCampos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Telerik.WinControls.UI.RadGridView gridPlantilla;
        public Telerik.WinControls.UI.RadGridView gridCampos;
    }
}
