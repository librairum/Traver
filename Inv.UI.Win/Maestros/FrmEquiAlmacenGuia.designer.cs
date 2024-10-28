namespace Inv.UI.Win
{
    partial class FrmEquiAlmacenGuia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEquiAlmacenGuia));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.TxtGuiaMotivoCod = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.TxtGuiaMotivoDesc = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtAlmTranDesc = new Telerik.WinControls.UI.RadTextBox();
            this.txtAlmTranCod = new Telerik.WinControls.UI.RadTextBox();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGuiaMotivoCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGuiaMotivoDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlmTranDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlmTranCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // barraComando
            // 
            this.barraComando.BackColor = System.Drawing.Color.White;
            this.barraComando.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.barraComando.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.barraComando.BorderColor3 = System.Drawing.Color.White;
            this.barraComando.BorderColor4 = System.Drawing.Color.White;
            this.barraComando.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.barraComando.Bounds = new System.Drawing.Rectangle(0, 0, 227, 30);
            this.barraComando.DesiredLocation = ((System.Drawing.PointF)(resources.GetObject("barraComando.DesiredLocation")));
            this.barraComando.DisplayName = "barraComando";
            this.barraComando.DrawBorder = true;
            this.barraComando.DrawFill = true;
            this.barraComando.DrawText = false;
            this.barraComando.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraComando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.barraComando.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            // 
            // 
            // 
            this.barraComando.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.barraComando.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(939, 33);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.TxtGuiaMotivoCod);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.TxtGuiaMotivoDesc);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtAlmTranDesc);
            this.radGroupBox1.Controls.Add(this.txtAlmTranCod);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(939, 35);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.TabStop = false;
            // 
            // TxtGuiaMotivoCod
            // 
            this.TxtGuiaMotivoCod.Location = new System.Drawing.Point(546, 7);
            this.TxtGuiaMotivoCod.Name = "TxtGuiaMotivoCod";
            this.TxtGuiaMotivoCod.Size = new System.Drawing.Size(34, 20);
            this.TxtGuiaMotivoCod.TabIndex = 6;
            this.TxtGuiaMotivoCod.Tag = "0";
            this.TxtGuiaMotivoCod.TextChanged += new System.EventHandler(this.TxtGuiaMotivoCod_TextChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(467, 9);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(70, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Guia Motivo:";
            // 
            // TxtGuiaMotivoDesc
            // 
            this.TxtGuiaMotivoDesc.Location = new System.Drawing.Point(586, 7);
            this.TxtGuiaMotivoDesc.Name = "TxtGuiaMotivoDesc";
            this.TxtGuiaMotivoDesc.ReadOnly = true;
            this.TxtGuiaMotivoDesc.Size = new System.Drawing.Size(338, 20);
            this.TxtGuiaMotivoDesc.TabIndex = 7;
            this.TxtGuiaMotivoDesc.TabStop = false;
            this.TxtGuiaMotivoDesc.Tag = "";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 11);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(117, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Almacen Transaccion :";
            // 
            // txtAlmTranDesc
            // 
            this.txtAlmTranDesc.Location = new System.Drawing.Point(177, 9);
            this.txtAlmTranDesc.Name = "txtAlmTranDesc";
            this.txtAlmTranDesc.ReadOnly = true;
            this.txtAlmTranDesc.Size = new System.Drawing.Size(254, 20);
            this.txtAlmTranDesc.TabIndex = 4;
            this.txtAlmTranDesc.Tag = "";
            // 
            // txtAlmTranCod
            // 
            this.txtAlmTranCod.Location = new System.Drawing.Point(136, 10);
            this.txtAlmTranCod.Name = "txtAlmTranCod";
            this.txtAlmTranCod.Size = new System.Drawing.Size(35, 20);
            this.txtAlmTranCod.TabIndex = 1;
            this.txtAlmTranCod.TextChanged += new System.EventHandler(this.txtAlmTranCod_TextChanged);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(939, 289);
            this.gridControl.TabIndex = 4;
            this.gridControl.TabStop = false;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridControl);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 68);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(939, 289);
            this.radPanel2.TabIndex = 1003;
            // 
            // FrmEquiAlmacenGuia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 357);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radGroupBox1);
            this.KeyPreview = true;
            this.Name = "FrmEquiAlmacenGuia";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Equivalencia Almacen vs Guia ";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmEquiAlmacenGuia_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGuiaMotivoCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGuiaMotivoDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlmTranDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlmTranCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtAlmTranDesc;
        private Telerik.WinControls.UI.RadTextBox txtAlmTranCod;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox TxtGuiaMotivoDesc;
        private Telerik.WinControls.UI.RadTextBox TxtGuiaMotivoCod;
    }
}
