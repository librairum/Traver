namespace Cos.UI.Win
{
    partial class frmCalcularCosto
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rpDerecho = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.gridMovProduccion = new Telerik.WinControls.UI.RadGridView();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.gridGastosContables = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnDistribuir = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            this.gridControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpDerecho)).BeginInit();
            this.rpDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovProduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovProduccion.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGastosContables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGastosContables.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDistribuir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Controls.Add(this.btnDistribuir);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(488, 411);
            this.gridControl.TabIndex = 3;
            // 
            // rpDerecho
            // 
            this.rpDerecho.Controls.Add(this.radPanel2);
            this.rpDerecho.Controls.Add(this.radPanel1);
            this.rpDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.rpDerecho.Location = new System.Drawing.Point(488, 33);
            this.rpDerecho.Name = "rpDerecho";
            this.rpDerecho.Size = new System.Drawing.Size(431, 411);
            this.rpDerecho.TabIndex = 1;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridMovProduccion);
            this.radPanel2.Controls.Add(this.radLabel2);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 187);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(431, 224);
            this.radPanel2.TabIndex = 1;
            this.radPanel2.Text = "radPanel2";
            // 
            // gridMovProduccion
            // 
            this.gridMovProduccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMovProduccion.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            this.gridMovProduccion.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridMovProduccion.Name = "gridMovProduccion";
            this.gridMovProduccion.Size = new System.Drawing.Size(431, 206);
            this.gridMovProduccion.TabIndex = 1;
            this.gridMovProduccion.Text = "radGridView2";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel2.Location = new System.Drawing.Point(0, 0);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(431, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Movimientos Produccion Importados";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.gridGastosContables);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(431, 187);
            this.radPanel1.TabIndex = 1;
            this.radPanel1.Text = "radPanel1";
            // 
            // gridGastosContables
            // 
            this.gridGastosContables.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridGastosContables.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            this.gridGastosContables.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gridGastosContables.Name = "gridGastosContables";
            this.gridGastosContables.Size = new System.Drawing.Size(431, 169);
            this.gridGastosContables.TabIndex = 0;
            this.gridGastosContables.Text = "radGridView1";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(431, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Gastos Contables Importados";
            // 
            // btnDistribuir
            // 
            this.btnDistribuir.Location = new System.Drawing.Point(177, 194);
            this.btnDistribuir.Name = "btnDistribuir";
            this.btnDistribuir.Size = new System.Drawing.Size(135, 23);
            this.btnDistribuir.TabIndex = 3;
            this.btnDistribuir.Text = "Procesar Costeo";
            // 
            // frmCalcularCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 444);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.rpDerecho);
            this.Name = "frmCalcularCosto";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Costear";
            this.Controls.SetChildIndex(this.rpDerecho, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.gridControl.ResumeLayout(false);
            this.gridControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpDerecho)).EndInit();
            this.rpDerecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovProduccion.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovProduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGastosContables.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGastosContables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDistribuir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel rpDerecho;
        private Telerik.WinControls.UI.RadGridView gridMovProduccion;
        private Telerik.WinControls.UI.RadGridView gridGastosContables;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnDistribuir;
    }
}
