namespace Prod.UI.Win.Procesos
{
    partial class frmProduccion
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
            this.rbIngreso = new Telerik.WinControls.UI.RadRadioButton();
            this.rbSalida = new Telerik.WinControls.UI.RadRadioButton();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Size = new System.Drawing.Size(689, 59);
            // 
            // rbIngreso
            // 
            this.rbIngreso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbIngreso.Location = new System.Drawing.Point(12, 6);
            this.rbIngreso.Name = "rbIngreso";
            this.rbIngreso.Size = new System.Drawing.Size(133, 18);
            this.rbIngreso.TabIndex = 0;
            this.rbIngreso.Text = "Ingreso de produccion";
            this.rbIngreso.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.rbIngreso.CheckStateChanged += new System.EventHandler(this.rbIngreso_CheckStateChanged);
            // 
            // rbSalida
            // 
            this.rbSalida.Location = new System.Drawing.Point(160, 6);
            this.rbSalida.Name = "rbSalida";
            this.rbSalida.Size = new System.Drawing.Size(141, 18);
            this.rbSalida.TabIndex = 1;
            this.rbSalida.TabStop = false;
            this.rbSalida.Text = "Consumo materia prima";
            this.rbSalida.CheckStateChanged += new System.EventHandler(this.rbSalida_CheckStateChanged);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 87);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(689, 324);
            this.gridControl.TabIndex = 4;
            this.gridControl.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridControl_CellDoubleClick);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.rbIngreso);
            this.radPanel1.Controls.Add(this.rbSalida);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 59);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(689, 28);
            this.radPanel1.TabIndex = 5;
            // 
            // frmProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 411);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmProduccion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Produccion";
            this.ThemeName = "ControlDefault";
            this.Controls.SetChildIndex(this.toolBar, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRadioButton rbSalida;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        public Telerik.WinControls.UI.RadGridView gridControl;
        public Telerik.WinControls.UI.RadRadioButton rbIngreso;
    }
}
