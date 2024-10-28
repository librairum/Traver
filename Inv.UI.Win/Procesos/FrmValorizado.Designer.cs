namespace Inv.UI.Win
{
    partial class FrmValorizado
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
            this.chktipoArti = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtTipoCambio = new Telerik.WinControls.UI.RadTextBox();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboalmacenes = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chktipoArti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chktipoArti
            // 
            this.chktipoArti.Location = new System.Drawing.Point(8, 25);
            this.chktipoArti.Name = "chktipoArti";
            this.chktipoArti.Size = new System.Drawing.Size(145, 18);
            this.chktipoArti.TabIndex = 115;
            this.chktipoArti.TabStop = false;
            this.chktipoArti.Text = "Agrupar por tipo articulo";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.radGroupBox4.Controls.Add(this.chktipoArti);
            this.radGroupBox4.HeaderText = "Tipo Agrupacion";
            this.radGroupBox4.Location = new System.Drawing.Point(11, 76);
            this.radGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Padding = new System.Windows.Forms.Padding(3, 28, 3, 3);
            this.radGroupBox4.Size = new System.Drawing.Size(286, 58);
            this.radGroupBox4.TabIndex = 136;
            this.radGroupBox4.Text = "Tipo Agrupacion";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(8, 50);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(59, 18);
            this.radLabel4.TabIndex = 107;
            this.radLabel4.Text = "T. Cambio:";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(72, 49);
            this.txtTipoCambio.Margin = new System.Windows.Forms.Padding(2);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(76, 20);
            this.txtTipoCambio.TabIndex = 106;
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(324, 23);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(437, 232);
            this.gridControl.TabIndex = 1004;
            this.gridControl.Text = "radGridView1";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(11, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 18);
            this.radLabel1.TabIndex = 1005;
            this.radLabel1.Text = "Almacen :";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.radGroupBox1.Controls.Add(this.cboalmacenes);
            this.radGroupBox1.Controls.Add(this.txtTipoCambio);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radGroupBox4);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 23);
            this.radGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 3);
            this.radGroupBox1.Size = new System.Drawing.Size(304, 232);
            this.radGroupBox1.TabIndex = 1006;
            // 
            // cboalmacenes
            // 
            this.cboalmacenes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboalmacenes.Location = new System.Drawing.Point(72, 20);
            this.cboalmacenes.Name = "cboalmacenes";
            this.cboalmacenes.Size = new System.Drawing.Size(220, 20);
            this.cboalmacenes.TabIndex = 1006;
            this.cboalmacenes.Text = "radDropDownList1";
            this.cboalmacenes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboalmacenes_SelectedIndexChanged);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radGroupBox1);
            this.radGroupBox2.Controls.Add(this.gridControl);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(890, 454);
            this.radGroupBox2.TabIndex = 1007;
            // 
            // FrmValorizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 499);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "FrmValorizado";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Frm Valorizado";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmValorizado_Load);
            this.Controls.SetChildIndex(this.radGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chktipoArti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboalmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadCheckBox chktipoArti;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtTipoCambio;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cboalmacenes;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;

    }
}
