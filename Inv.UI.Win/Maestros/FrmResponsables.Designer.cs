namespace Inv.UI.Win
{
    partial class FrmResponsables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResponsables));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtdescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.txtcodigo = new Telerik.WinControls.UI.RadTextBox();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtemisor = new System.Windows.Forms.RadioButton();
            this.rbtreceptor = new System.Windows.Forms.RadioButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
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
            this.radCommandBar1.Size = new System.Drawing.Size(694, 33);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.groupBox1);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.txtdescripcion);
            this.radPanel1.Controls.Add(this.txtcodigo);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 33);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(694, 34);
            this.radPanel1.TabIndex = 4;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(116, 6);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(64, 18);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Descripcion";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(15, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(43, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Codigo";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(186, 6);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(297, 20);
            this.txtdescripcion.TabIndex = 7;
            this.txtdescripcion.Tag = "";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(64, 6);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(46, 20);
            this.txtcodigo.TabIndex = 5;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 67);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(694, 282);
            this.gridControl.TabIndex = 5;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            this.gridControl.CurrentRowChanging += new Telerik.WinControls.UI.CurrentRowChangingEventHandler(this.gridControl_CurrentRowChanging);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtreceptor);
            this.groupBox1.Controls.Add(this.rbtemisor);
            this.groupBox1.Location = new System.Drawing.Point(545, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 30);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // rbtemisor
            // 
            this.rbtemisor.AutoSize = true;
            this.rbtemisor.Location = new System.Drawing.Point(6, 8);
            this.rbtemisor.Name = "rbtemisor";
            this.rbtemisor.Size = new System.Drawing.Size(59, 17);
            this.rbtemisor.TabIndex = 0;
            this.rbtemisor.Text = "Emisor";
            this.rbtemisor.UseVisualStyleBackColor = true;
            // 
            // rbtreceptor
            // 
            this.rbtreceptor.AutoSize = true;
            this.rbtreceptor.Checked = true;
            this.rbtreceptor.Location = new System.Drawing.Point(71, 9);
            this.rbtreceptor.Name = "rbtreceptor";
            this.rbtreceptor.Size = new System.Drawing.Size(71, 17);
            this.rbtreceptor.TabIndex = 1;
            this.rbtreceptor.TabStop = true;
            this.rbtreceptor.Text = "Receptor";
            this.rbtreceptor.UseVisualStyleBackColor = true;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(511, 7);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(28, 18);
            this.radLabel3.TabIndex = 9;
            this.radLabel3.Text = "Tipo";
            // 
            // FrmResponsables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 349);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radPanel1);
            this.Name = "FrmResponsables";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Responsables";
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtdescripcion;
        private Telerik.WinControls.UI.RadTextBox txtcodigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtreceptor;
        private System.Windows.Forms.RadioButton rbtemisor;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
