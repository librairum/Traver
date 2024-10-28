namespace Inv.UI.Win
{
    partial class FrmTransaccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransaccion));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtCodTipAnalisis = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtDesTipAnalisis = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtdescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.txtcodigo = new Telerik.WinControls.UI.RadTextBox();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodTipAnalisis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesTipAnalisis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).BeginInit();
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
            this.radCommandBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radCommandBar1.Size = new System.Drawing.Size(1106, 33);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtCodTipAnalisis);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.txtDesTipAnalisis);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtdescripcion);
            this.radGroupBox1.Controls.Add(this.txtcodigo);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 33);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1106, 36);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.TabStop = false;
            // 
            // txtCodTipAnalisis
            // 
            this.txtCodTipAnalisis.Location = new System.Drawing.Point(759, 9);
            this.txtCodTipAnalisis.Name = "txtCodTipAnalisis";
            this.txtCodTipAnalisis.Size = new System.Drawing.Size(51, 20);
            this.txtCodTipAnalisis.TabIndex = 6;
            this.txtCodTipAnalisis.Tag = "0";
            this.txtCodTipAnalisis.TextChanged += new System.EventHandler(this.txtCodTipAnalisis_TextChanged);
            this.txtCodTipAnalisis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodTipAnalisis_KeyDown);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(680, 11);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(73, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Tipo analisis :";
            // 
            // txtDesTipAnalisis
            // 
            this.txtDesTipAnalisis.Location = new System.Drawing.Point(816, 9);
            this.txtDesTipAnalisis.Name = "txtDesTipAnalisis";
            this.txtDesTipAnalisis.Size = new System.Drawing.Size(278, 20);
            this.txtDesTipAnalisis.TabIndex = 7;
            this.txtDesTipAnalisis.TabStop = false;
            this.txtDesTipAnalisis.Tag = "";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(190, 11);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(53, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Nombre :";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 11);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(48, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Codigo :";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(256, 9);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(412, 20);
            this.txtdescripcion.TabIndex = 4;
            this.txtdescripcion.Tag = "";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(84, 10);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 20);
            this.txtcodigo.TabIndex = 1;
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
            this.gridControl.Size = new System.Drawing.Size(1106, 348);
            this.gridControl.TabIndex = 4;
            this.gridControl.TabStop = false;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridControl);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 69);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1106, 348);
            this.radPanel2.TabIndex = 1003;
            // 
            // FrmTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1106, 417);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radGroupBox1);
            this.KeyPreview = true;
            this.Name = "FrmTransaccion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Documento Respaldo";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmTransaccion_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodTipAnalisis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesTipAnalisis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).EndInit();
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
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtdescripcion;
        private Telerik.WinControls.UI.RadTextBox txtcodigo;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtDesTipAnalisis;
        private Telerik.WinControls.UI.RadTextBox txtCodTipAnalisis;
    }
}
