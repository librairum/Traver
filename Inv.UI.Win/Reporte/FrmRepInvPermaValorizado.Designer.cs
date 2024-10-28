namespace Inv.UI.Win
{
    partial class frmRepInvPermanenteValo
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
            this.cboperiodos = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rbRegistroInv121 = new Telerik.WinControls.UI.RadRadioButton();
            this.rbRegistroInv131 = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRegistroInv121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRegistroInv131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cboperiodos
            // 
            this.cboperiodos.Location = new System.Drawing.Point(67, 48);
            this.cboperiodos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboperiodos.Name = "cboperiodos";
            this.cboperiodos.Size = new System.Drawing.Size(232, 20);
            this.cboperiodos.TabIndex = 3;
            this.cboperiodos.Text = "radDropDownList1";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 48);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(48, 18);
            this.radLabel3.TabIndex = 36;
            this.radLabel3.Text = "Periodo:";
            // 
            // gridControl
            // 
            this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl.Location = new System.Drawing.Point(0, 74);
            this.gridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.MultiSelect = true;
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1115, 378);
            this.gridControl.TabIndex = 37;
            this.gridControl.Text = "Ingreso por devolucion";
            // 
            // rbRegistroInv121
            // 
            this.rbRegistroInv121.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbRegistroInv121.Location = new System.Drawing.Point(322, 48);
            this.rbRegistroInv121.Name = "rbRegistroInv121";
            this.rbRegistroInv121.Size = new System.Drawing.Size(446, 18);
            this.rbRegistroInv121.TabIndex = 38;
            this.rbRegistroInv121.Text = "12.1 REGISTRO DEL INVENTARIO PERMANENTE EN UNIDADES FÍSICAS(EXONERADO)";
            this.rbRegistroInv121.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rbRegistroInv131
            // 
            this.rbRegistroInv131.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbRegistroInv131.Location = new System.Drawing.Point(774, 48);
            this.rbRegistroInv131.Name = "rbRegistroInv131";
            this.rbRegistroInv131.Size = new System.Drawing.Size(332, 18);
            this.rbRegistroInv131.TabIndex = 39;
            this.rbRegistroInv131.Text = "13.1 REGISTRO DEL INVENTARIO PERMANENTE VALORIZADO ";
            this.rbRegistroInv131.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // frmRepInvPermanenteValo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1115, 458);
            this.Controls.Add(this.rbRegistroInv131);
            this.Controls.Add(this.rbRegistroInv121);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.cboperiodos);
            this.Name = "frmRepInvPermanenteValo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Inventario Valorizado";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmRepInvPermanenteValo_Load);
            this.Controls.SetChildIndex(this.cboperiodos, 0);
            this.Controls.SetChildIndex(this.radLabel3, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            this.Controls.SetChildIndex(this.rbRegistroInv121, 0);
            this.Controls.SetChildIndex(this.rbRegistroInv131, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cboperiodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRegistroInv121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbRegistroInv131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cboperiodos;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadRadioButton rbRegistroInv121;
        private Telerik.WinControls.UI.RadRadioButton rbRegistroInv131;




    }
}
