namespace Cos.UI.Win
{
    partial class frmDistriProduccionxLineas
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rpDistribucion = new Telerik.WinControls.UI.RadPanel();
            this.btnDistribuir = new Telerik.WinControls.UI.RadButton();
            this.gridActDistribuida = new Telerik.WinControls.UI.RadGridView();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.rpActividades = new Telerik.WinControls.UI.RadPanel();
            this.rpActPrincipal = new Telerik.WinControls.UI.RadPanel();
            this.gridLineas = new Telerik.WinControls.UI.RadGridView();
            this.rpCabeceraActPrincipal = new Telerik.WinControls.UI.RadPanel();
            this.btnGrabaDistribuir = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rpActApoyo = new Telerik.WinControls.UI.RadPanel();
            this.gridActApoyo = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpDistribucion)).BeginInit();
            this.rpDistribucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDistribuir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActDistribuida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActDistribuida.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpActividades)).BeginInit();
            this.rpActividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpActPrincipal)).BeginInit();
            this.rpActPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineas.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpCabeceraActPrincipal)).BeginInit();
            this.rpCabeceraActPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabaDistribuir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpActApoyo)).BeginInit();
            this.rpActApoyo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActApoyo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActApoyo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(765, 33);
            // 
            // rpDistribucion
            // 
            this.rpDistribucion.Controls.Add(this.btnDistribuir);
            this.rpDistribucion.Controls.Add(this.gridActDistribuida);
            this.rpDistribucion.Controls.Add(this.radLabel3);
            this.rpDistribucion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpDistribucion.Location = new System.Drawing.Point(0, 346);
            this.rpDistribucion.Name = "rpDistribucion";
            this.rpDistribucion.Size = new System.Drawing.Size(765, 143);
            this.rpDistribucion.TabIndex = 4;
            this.rpDistribucion.Text = "radPanel1";
            // 
            // btnDistribuir
            // 
            this.btnDistribuir.Location = new System.Drawing.Point(201, 0);
            this.btnDistribuir.Name = "btnDistribuir";
            this.btnDistribuir.Size = new System.Drawing.Size(110, 18);
            this.btnDistribuir.TabIndex = 0;
            this.btnDistribuir.Text = "Distribuir";
            this.btnDistribuir.Click += new System.EventHandler(this.btnDistribuir_Click);
            // 
            // gridActDistribuida
            // 
            this.gridActDistribuida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridActDistribuida.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            this.gridActDistribuida.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridActDistribuida.Name = "gridActDistribuida";
            this.gridActDistribuida.Size = new System.Drawing.Size(765, 125);
            this.gridActDistribuida.TabIndex = 6;
            this.gridActDistribuida.Text = "radGridView3";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel3.Location = new System.Drawing.Point(0, 0);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(765, 18);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "Lista de Actividades Distribuidas";
            // 
            // rpActividades
            // 
            this.rpActividades.Controls.Add(this.rpActPrincipal);
            this.rpActividades.Controls.Add(this.rpActApoyo);
            this.rpActividades.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpActividades.Location = new System.Drawing.Point(0, 33);
            this.rpActividades.Name = "rpActividades";
            this.rpActividades.Size = new System.Drawing.Size(765, 313);
            this.rpActividades.TabIndex = 8;
            this.rpActividades.Text = "radPanel1";
            // 
            // rpActPrincipal
            // 
            this.rpActPrincipal.Controls.Add(this.gridLineas);
            this.rpActPrincipal.Controls.Add(this.rpCabeceraActPrincipal);
            this.rpActPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpActPrincipal.Location = new System.Drawing.Point(317, 0);
            this.rpActPrincipal.Name = "rpActPrincipal";
            this.rpActPrincipal.Size = new System.Drawing.Size(449, 313);
            this.rpActPrincipal.TabIndex = 8;
            this.rpActPrincipal.Text = "radPanel1";
            // 
            // gridLineas
            // 
            this.gridLineas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLineas.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            this.gridLineas.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridLineas.Name = "gridLineas";
            this.gridLineas.Size = new System.Drawing.Size(449, 295);
            this.gridLineas.TabIndex = 5;
            this.gridLineas.Text = "radGridView2";
            this.gridLineas.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridLineas_CurrentRowChanged);
            // 
            // rpCabeceraActPrincipal
            // 
            this.rpCabeceraActPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.rpCabeceraActPrincipal.Controls.Add(this.btnGrabaDistribuir);
            this.rpCabeceraActPrincipal.Controls.Add(this.radLabel2);
            this.rpCabeceraActPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpCabeceraActPrincipal.Location = new System.Drawing.Point(0, 0);
            this.rpCabeceraActPrincipal.Name = "rpCabeceraActPrincipal";
            this.rpCabeceraActPrincipal.Size = new System.Drawing.Size(449, 18);
            this.rpCabeceraActPrincipal.TabIndex = 1;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rpCabeceraActPrincipal.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // btnGrabaDistribuir
            // 
            this.btnGrabaDistribuir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGrabaDistribuir.Location = new System.Drawing.Point(291, 0);
            this.btnGrabaDistribuir.Name = "btnGrabaDistribuir";
            this.btnGrabaDistribuir.Size = new System.Drawing.Size(158, 18);
            this.btnGrabaDistribuir.TabIndex = 1;
            this.btnGrabaDistribuir.Text = "Grabar Distribucion";
            this.btnGrabaDistribuir.Visible = false;
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radLabel2.Location = new System.Drawing.Point(0, 0);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(37, 18);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "Lineas";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel2.GetChildAt(0))).Text = "Lineas";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel2.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel2.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel2.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Transparent;
            // 
            // rpActApoyo
            // 
            this.rpActApoyo.Controls.Add(this.gridActApoyo);
            this.rpActApoyo.Controls.Add(this.radLabel1);
            this.rpActApoyo.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpActApoyo.Location = new System.Drawing.Point(0, 0);
            this.rpActApoyo.Name = "rpActApoyo";
            this.rpActApoyo.Size = new System.Drawing.Size(317, 313);
            this.rpActApoyo.TabIndex = 8;
            this.rpActApoyo.Text = "radPanel1";
            // 
            // gridActApoyo
            // 
            this.gridActApoyo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridActApoyo.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            this.gridActApoyo.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gridActApoyo.Name = "gridActApoyo";
            this.gridActApoyo.Size = new System.Drawing.Size(317, 295);
            this.gridActApoyo.TabIndex = 4;
            this.gridActApoyo.Text = "radGridView1";
            this.gridActApoyo.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridActApoyo_CurrentRowChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(317, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Actividades de Apoyo";
            // 
            // frmDistriProduccionxLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 489);
            this.Controls.Add(this.rpDistribucion);
            this.Controls.Add(this.rpActividades);
            this.Name = "frmDistriProduccionxLineas";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Distribucion de Produccion por lineas";
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.rpActividades, 0);
            this.Controls.SetChildIndex(this.rpDistribucion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpDistribucion)).EndInit();
            this.rpDistribucion.ResumeLayout(false);
            this.rpDistribucion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDistribuir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActDistribuida.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActDistribuida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpActividades)).EndInit();
            this.rpActividades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpActPrincipal)).EndInit();
            this.rpActPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLineas.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpCabeceraActPrincipal)).EndInit();
            this.rpCabeceraActPrincipal.ResumeLayout(false);
            this.rpCabeceraActPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabaDistribuir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpActApoyo)).EndInit();
            this.rpActApoyo.ResumeLayout(false);
            this.rpActApoyo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActApoyo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActApoyo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpDistribucion;
        private Telerik.WinControls.UI.RadButton btnDistribuir;
        private Telerik.WinControls.UI.RadGridView gridActDistribuida;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadPanel rpActividades;
        private Telerik.WinControls.UI.RadPanel rpActPrincipal;
        private Telerik.WinControls.UI.RadGridView gridLineas;
        private Telerik.WinControls.UI.RadPanel rpCabeceraActPrincipal;
        private Telerik.WinControls.UI.RadButton btnGrabaDistribuir;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadPanel rpActApoyo;
        private Telerik.WinControls.UI.RadGridView gridActApoyo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
