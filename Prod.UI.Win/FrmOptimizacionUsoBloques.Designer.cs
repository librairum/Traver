namespace Prod.UI.Win
{
    partial class FrmOptimizacionUsoBloques
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
            this.button1 = new System.Windows.Forms.Button();
            this.dgvoptimizacion = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.txtareamaxima = new System.Windows.Forms.TextBox();
            this.txtmargensuperior = new System.Windows.Forms.TextBox();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtprodancho = new System.Windows.Forms.TextBox();
            this.txtprodlargo = new System.Windows.Forms.TextBox();
            this.txtprodespesor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvoptimizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Optimizar uso Bloque";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvoptimizacion
            // 
            this.dgvoptimizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvoptimizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.descripcion,
            this.Column11});
            this.dgvoptimizacion.Location = new System.Drawing.Point(52, 167);
            this.dgvoptimizacion.Name = "dgvoptimizacion";
            this.dgvoptimizacion.Size = new System.Drawing.Size(942, 150);
            this.dgvoptimizacion.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ejemplo Original";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtareamaxima
            // 
            this.txtareamaxima.Location = new System.Drawing.Point(315, 114);
            this.txtareamaxima.Name = "txtareamaxima";
            this.txtareamaxima.Size = new System.Drawing.Size(100, 20);
            this.txtareamaxima.TabIndex = 3;
            // 
            // txtmargensuperior
            // 
            this.txtmargensuperior.Location = new System.Drawing.Point(431, 114);
            this.txtmargensuperior.Name = "txtmargensuperior";
            this.txtmargensuperior.Size = new System.Drawing.Size(124, 20);
            this.txtmargensuperior.TabIndex = 4;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Seleccionado";
            this.codigo.Name = "codigo";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "BloqueNro";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "BloqueAncho";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Bloque Largo";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Bloque Alto";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Bloque Volumen";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Bloque Area";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Forma Corte";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Baldosa Area";
            this.Column10.Name = "Column10";
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Baldosa Merma";
            this.descripcion.Name = "descripcion";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Merma Ratio";
            this.Column11.Name = "Column11";
            // 
            // txtprodancho
            // 
            this.txtprodancho.Location = new System.Drawing.Point(62, 114);
            this.txtprodancho.Name = "txtprodancho";
            this.txtprodancho.Size = new System.Drawing.Size(69, 20);
            this.txtprodancho.TabIndex = 5;
            // 
            // txtprodlargo
            // 
            this.txtprodlargo.Location = new System.Drawing.Point(134, 114);
            this.txtprodlargo.Name = "txtprodlargo";
            this.txtprodlargo.Size = new System.Drawing.Size(65, 20);
            this.txtprodlargo.TabIndex = 6;
            // 
            // txtprodespesor
            // 
            this.txtprodespesor.Location = new System.Drawing.Point(205, 114);
            this.txtprodespesor.Name = "txtprodespesor";
            this.txtprodespesor.Size = new System.Drawing.Size(65, 20);
            this.txtprodespesor.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ancho (Pulg)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Largo (pulg)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Espesor (mm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Producto Solicitado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Area Solicitada (M2)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Maximo Margen Superior ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Lista bloques  a cortar";
            // 
            // FrmOptimizacionUsoBloques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 360);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtprodespesor);
            this.Controls.Add(this.txtprodlargo);
            this.Controls.Add(this.txtprodancho);
            this.Controls.Add(this.txtmargensuperior);
            this.Controls.Add(this.txtareamaxima);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvoptimizacion);
            this.Controls.Add(this.button1);
            this.Name = "FrmOptimizacionUsoBloques";
            this.Text = "FrmOptimizacionUsoBloques";
            ((System.ComponentModel.ISupportInitialize)(this.dgvoptimizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvoptimizacion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtareamaxima;
        private System.Windows.Forms.TextBox txtmargensuperior;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.TextBox txtprodancho;
        private System.Windows.Forms.TextBox txtprodlargo;
        private System.Windows.Forms.TextBox txtprodespesor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        
    }
}