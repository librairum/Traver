namespace Inv.UI.Win
{
    partial class FrmRepProdFabricante
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
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbtresumido = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbomesfin = new Telerik.WinControls.UI.RadDropDownList();
            this.cbomesini = new Telerik.WinControls.UI.RadDropDownList();
            this.rbtrangoperiodo = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpranfechafin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtrangofechas = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpranfechaini = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rbtdetallado = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtresumido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpranfechafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangofechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpranfechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtdetallado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rbtresumido);
            this.radGroupBox2.Controls.Add(this.radGroupBox1);
            this.radGroupBox2.Controls.Add(this.rbtdetallado);
            this.radGroupBox2.HeaderText = "Opciones";
            this.radGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(337, 141);
            this.radGroupBox2.TabIndex = 9;
            this.radGroupBox2.Text = "Opciones";
            // 
            // rbtresumido
            // 
            this.rbtresumido.Location = new System.Drawing.Point(81, 21);
            this.rbtresumido.Name = "rbtresumido";
            this.rbtresumido.Size = new System.Drawing.Size(70, 18);
            this.rbtresumido.TabIndex = 7;
            this.rbtresumido.Text = "Resumido";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cbomesfin);
            this.radGroupBox1.Controls.Add(this.cbomesini);
            this.radGroupBox1.Controls.Add(this.rbtrangoperiodo);
            this.radGroupBox1.Controls.Add(this.dtpranfechafin);
            this.radGroupBox1.Controls.Add(this.rbtrangofechas);
            this.radGroupBox1.Controls.Add(this.dtpranfechaini);
            this.radGroupBox1.HeaderText = "Opciones de fecha";
            this.radGroupBox1.Location = new System.Drawing.Point(7, 55);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(319, 81);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Opciones de fecha";
            // 
            // cbomesfin
            // 
            this.cbomesfin.Location = new System.Drawing.Point(225, 20);
            this.cbomesfin.Name = "cbomesfin";
            this.cbomesfin.Size = new System.Drawing.Size(89, 20);
            this.cbomesfin.TabIndex = 7;
            // 
            // cbomesini
            // 
            this.cbomesini.Location = new System.Drawing.Point(129, 20);
            this.cbomesini.Name = "cbomesini";
            this.cbomesini.Size = new System.Drawing.Size(90, 20);
            this.cbomesini.TabIndex = 6;
            // 
            // rbtrangoperiodo
            // 
            this.rbtrangoperiodo.Location = new System.Drawing.Point(5, 21);
            this.rbtrangoperiodo.Name = "rbtrangoperiodo";
            this.rbtrangoperiodo.Size = new System.Drawing.Size(87, 18);
            this.rbtrangoperiodo.TabIndex = 5;
            this.rbtrangoperiodo.Text = "Rango Meses";
            // 
            // dtpranfechafin
            // 
            this.dtpranfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpranfechafin.Location = new System.Drawing.Point(225, 42);
            this.dtpranfechafin.Name = "dtpranfechafin";
            this.dtpranfechafin.Size = new System.Drawing.Size(89, 20);
            this.dtpranfechafin.TabIndex = 4;
            this.dtpranfechafin.TabStop = false;
            this.dtpranfechafin.Text = "28/04/2015";
            this.dtpranfechafin.Value = new System.DateTime(2015, 4, 28, 12, 24, 53, 639);
            // 
            // rbtrangofechas
            // 
            this.rbtrangofechas.Location = new System.Drawing.Point(5, 45);
            this.rbtrangofechas.Name = "rbtrangofechas";
            this.rbtrangofechas.Size = new System.Drawing.Size(89, 18);
            this.rbtrangofechas.TabIndex = 1;
            this.rbtrangofechas.Text = "Rango Fechas";
            // 
            // dtpranfechaini
            // 
            this.dtpranfechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpranfechaini.Location = new System.Drawing.Point(129, 42);
            this.dtpranfechaini.Name = "dtpranfechaini";
            this.dtpranfechaini.Size = new System.Drawing.Size(90, 20);
            this.dtpranfechaini.TabIndex = 3;
            this.dtpranfechaini.TabStop = false;
            this.dtpranfechaini.Text = "28/04/2015";
            this.dtpranfechaini.Value = new System.DateTime(2015, 4, 28, 12, 24, 44, 569);
            // 
            // rbtdetallado
            // 
            this.rbtdetallado.Location = new System.Drawing.Point(7, 21);
            this.rbtdetallado.Name = "rbtdetallado";
            this.rbtdetallado.Size = new System.Drawing.Size(68, 18);
            this.rbtdetallado.TabIndex = 6;
            this.rbtdetallado.Text = "Detallado";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radGroupBox2);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(392, 188);
            this.radPanel2.TabIndex = 10;
            // 
            // FrmRepProdFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 221);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmRepProdFabricante";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Transaccion x Fabricante";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmRepProdFabricante_Load);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtresumido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpranfechafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangofechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpranfechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtdetallado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rbtresumido;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cbomesfin;
        private Telerik.WinControls.UI.RadDropDownList cbomesini;
        private Telerik.WinControls.UI.RadRadioButton rbtrangoperiodo;
        private Telerik.WinControls.UI.RadDateTimePicker dtpranfechafin;
        private Telerik.WinControls.UI.RadRadioButton rbtrangofechas;
        private Telerik.WinControls.UI.RadDateTimePicker dtpranfechaini;
        private Telerik.WinControls.UI.RadRadioButton rbtdetallado;
        private Telerik.WinControls.UI.RadPanel radPanel2;



    }
}
