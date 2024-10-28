namespace Inv.UI.Win
{
    partial class FrmRepMovPorMesSum
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboperiodosfin = new Telerik.WinControls.UI.RadDropDownList();
            this.rbPeriodo = new Telerik.WinControls.UI.RadRadioButton();
            this.cboperiodosini = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbSalidas = new Telerik.WinControls.UI.RadRadioButton();
            this.rbIngresos = new Telerik.WinControls.UI.RadRadioButton();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cboperiodosfin);
            this.radGroupBox1.Controls.Add(this.rbPeriodo);
            this.radGroupBox1.Controls.Add(this.cboperiodosini);
            this.radGroupBox1.HeaderText = "Opcion de fecha";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 39);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(217, 73);
            this.radGroupBox1.TabIndex = 6;
            this.radGroupBox1.Text = "Opcion de fecha";
            // 
            // cboperiodosfin
            // 
            this.cboperiodosfin.Location = new System.Drawing.Point(118, 43);
            this.cboperiodosfin.Name = "cboperiodosfin";
            this.cboperiodosfin.Size = new System.Drawing.Size(91, 20);
            this.cboperiodosfin.TabIndex = 12;
            this.cboperiodosfin.Text = "radDropDownList1";
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.Location = new System.Drawing.Point(28, 21);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(59, 18);
            this.rbPeriodo.TabIndex = 10;
            this.rbPeriodo.Text = "Periodo";
            // 
            // cboperiodosini
            // 
            this.cboperiodosini.Location = new System.Drawing.Point(118, 21);
            this.cboperiodosini.Name = "cboperiodosini";
            this.cboperiodosini.Size = new System.Drawing.Size(91, 20);
            this.cboperiodosini.TabIndex = 0;
            this.cboperiodosini.Text = "radDropDownList1";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbSalidas);
            this.radGroupBox2.Controls.Add(this.rbIngresos);
            this.radGroupBox2.HeaderText = "Opcion datos";
            this.radGroupBox2.Location = new System.Drawing.Point(10, 118);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(219, 230);
            this.radGroupBox2.TabIndex = 7;
            this.radGroupBox2.Text = "Opcion datos";
            // 
            // rbSalidas
            // 
            this.rbSalidas.Location = new System.Drawing.Point(118, 21);
            this.rbSalidas.Name = "rbSalidas";
            this.rbSalidas.Size = new System.Drawing.Size(55, 18);
            this.rbSalidas.TabIndex = 13;
            this.rbSalidas.Text = "Salidas";
            // 
            // rbIngresos
            // 
            this.rbIngresos.Location = new System.Drawing.Point(17, 21);
            this.rbIngresos.Name = "rbIngresos";
            this.rbIngresos.Size = new System.Drawing.Size(62, 18);
            this.rbIngresos.TabIndex = 12;
            this.rbIngresos.Text = "Ingresos";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(249, 39);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.MultiSelect = true;
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(606, 361);
            this.gridControl.TabIndex = 8;
            this.gridControl.Text = "Ingreso por devolucion";
            // 
            // FrmRepMovPorMesSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 405);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "FrmRepMovPorMesSum";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Movimiento por Mes";
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.radGroupBox2, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodosini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosfin;
        private Telerik.WinControls.UI.RadRadioButton rbPeriodo;
        private Telerik.WinControls.UI.RadDropDownList cboperiodosini;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rbSalidas;
        private Telerik.WinControls.UI.RadRadioButton rbIngresos;
        private Telerik.WinControls.UI.RadGridView gridControl;
    }
}
