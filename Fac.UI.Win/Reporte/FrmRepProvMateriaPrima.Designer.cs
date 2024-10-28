namespace Fac.UI.Win
{
    partial class FrmRepProvMateriaPrima
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbomesfin = new Telerik.WinControls.UI.RadDropDownList();
            this.cbomesini = new Telerik.WinControls.UI.RadDropDownList();
            this.rbtrangoperiodo = new Telerik.WinControls.UI.RadRadioButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.gridcontrol = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cbomesfin);
            this.radGroupBox1.Controls.Add(this.cbomesini);
            this.radGroupBox1.Controls.Add(this.rbtrangoperiodo);
            this.radGroupBox1.HeaderText = "Opciones de fecha";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 6);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(156, 95);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Opciones de fecha";
            // 
            // cbomesfin
            // 
            this.cbomesfin.Location = new System.Drawing.Point(29, 71);
            this.cbomesfin.Name = "cbomesfin";
            this.cbomesfin.Size = new System.Drawing.Size(120, 20);
            this.cbomesfin.TabIndex = 7;
            // 
            // cbomesini
            // 
            this.cbomesini.Location = new System.Drawing.Point(28, 45);
            this.cbomesini.Name = "cbomesini";
            this.cbomesini.Size = new System.Drawing.Size(121, 20);
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
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gridcontrol);
            this.radPanel2.Controls.Add(this.radGroupBox1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 33);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(567, 337);
            this.radPanel2.TabIndex = 6;
            // 
            // gridcontrol
            // 
            this.gridcontrol.Location = new System.Drawing.Point(165, 6);
            // 
            // gridcontrol
            // 
            this.gridcontrol.MasterTemplate.MultiSelect = true;
            this.gridcontrol.Name = "gridcontrol";
            this.gridcontrol.Size = new System.Drawing.Size(387, 306);
            this.gridcontrol.TabIndex = 6;
            this.gridcontrol.Text = "radGridView1";
            // 
            // FrmRepProvMateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 370);
            this.Controls.Add(this.radPanel2);
            this.Name = "FrmRepProvMateriaPrima";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Proveedor Materia Prima";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmRepProvMateriaPrima_Load);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesfin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbomesini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtrangoperiodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDropDownList cbomesfin;
        private Telerik.WinControls.UI.RadDropDownList cbomesini;
        private Telerik.WinControls.UI.RadRadioButton rbtrangoperiodo;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView gridcontrol;



    }
}
