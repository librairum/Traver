namespace Inv.UI.Win
{
    partial class FrmCalcularcostopromedio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalcularcostopromedio));
            this.btnCalcular = new System.Windows.Forms.Button();
            this.rbCostoPromedio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.radCommandBar1.Size = new System.Drawing.Size(301, 33);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(135, 21);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // rbCostoPromedio
            // 
            this.rbCostoPromedio.AutoSize = true;
            this.rbCostoPromedio.Checked = true;
            this.rbCostoPromedio.Location = new System.Drawing.Point(11, 27);
            this.rbCostoPromedio.Name = "rbCostoPromedio";
            this.rbCostoPromedio.Size = new System.Drawing.Size(108, 17);
            this.rbCostoPromedio.TabIndex = 1;
            this.rbCostoPromedio.TabStop = true;
            this.rbCostoPromedio.Text = "Costo promedio";
            this.rbCostoPromedio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalcular);
            this.groupBox1.Controls.Add(this.rbCostoPromedio);
            this.groupBox1.Location = new System.Drawing.Point(26, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // FrmCalcularcostopromedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(301, 130);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCalcularcostopromedio";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Calcular costos promedio";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmCalcularcostopromedio_Load);
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.RadioButton rbCostoPromedio;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
