namespace Cos.UI.Win
{
    partial class frmImpCostosProduccion
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpCostosProduccion));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            this.rpImportacion = new Telerik.WinControls.UI.RadPanel();
            this.btnSalirImprotacion = new Telerik.WinControls.UI.RadButton();
            this.btnImportar = new Telerik.WinControls.UI.RadButton();
            this.rbImportarDirecto = new Telerik.WinControls.UI.RadRadioButton();
            this.rbArchivoTexto = new Telerik.WinControls.UI.RadRadioButton();
            this.btnProcesarImportacion = new Telerik.WinControls.UI.RadButton();
            this.gridImportacion = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            this.gridControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpImportacion)).BeginInit();
            this.rpImportacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalirImprotacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbImportarDirecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbArchivoTexto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesarImportacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImportacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImportacion.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Controls.Add(this.rpImportacion);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1281, 396);
            this.gridControl.TabIndex = 4;
            this.gridControl.Text = "radGridView1";
            // 
            // rpImportacion
            // 
            this.rpImportacion.Controls.Add(this.btnSalirImprotacion);
            this.rpImportacion.Controls.Add(this.btnImportar);
            this.rpImportacion.Controls.Add(this.rbImportarDirecto);
            this.rpImportacion.Controls.Add(this.rbArchivoTexto);
            this.rpImportacion.Controls.Add(this.btnProcesarImportacion);
            this.rpImportacion.Controls.Add(this.gridImportacion);
            this.rpImportacion.Location = new System.Drawing.Point(7, 13);
            this.rpImportacion.Name = "rpImportacion";
            this.rpImportacion.Size = new System.Drawing.Size(1269, 250);
            this.rpImportacion.TabIndex = 5;
            this.rpImportacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rpImportacion_MouseDown);
            this.rpImportacion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rpImportacion_MouseMove);
            // 
            // btnSalirImprotacion
            // 
            this.btnSalirImprotacion.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnSalirImprotacion.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirImprotacion.Image")));
            this.btnSalirImprotacion.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSalirImprotacion.Location = new System.Drawing.Point(1239, 2);
            this.btnSalirImprotacion.Name = "btnSalirImprotacion";
            this.btnSalirImprotacion.Size = new System.Drawing.Size(27, 30);
            this.btnSalirImprotacion.TabIndex = 6;
            this.btnSalirImprotacion.Text = "Salir";
            this.btnSalirImprotacion.ThemeName = "Office2013Light";
            this.btnSalirImprotacion.Click += new System.EventHandler(this.btnSalirImprotacion_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImportar.Location = new System.Drawing.Point(1175, 2);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(27, 30);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar";
            this.btnImportar.ThemeName = "Office2013Light";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // rbImportarDirecto
            // 
            this.rbImportarDirecto.Location = new System.Drawing.Point(14, 8);
            this.rbImportarDirecto.Name = "rbImportarDirecto";
            this.rbImportarDirecto.Size = new System.Drawing.Size(56, 18);
            this.rbImportarDirecto.TabIndex = 1;
            this.rbImportarDirecto.TabStop = false;
            this.rbImportarDirecto.Text = "Directo";
            this.rbImportarDirecto.CheckStateChanged += new System.EventHandler(this.rbImportarDirecto_CheckStateChanged);
            // 
            // rbArchivoTexto
            // 
            this.rbArchivoTexto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbArchivoTexto.Location = new System.Drawing.Point(82, 6);
            this.rbArchivoTexto.Name = "rbArchivoTexto";
            this.rbArchivoTexto.Size = new System.Drawing.Size(102, 18);
            this.rbArchivoTexto.TabIndex = 0;
            this.rbArchivoTexto.Text = "Archivo de texto";
            this.rbArchivoTexto.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.rbArchivoTexto.CheckStateChanged += new System.EventHandler(this.rbArchivoTexto_CheckStateChanged);
            // 
            // btnProcesarImportacion
            // 
            this.btnProcesarImportacion.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnProcesarImportacion.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesarImportacion.Image")));
            this.btnProcesarImportacion.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProcesarImportacion.Location = new System.Drawing.Point(1208, 2);
            this.btnProcesarImportacion.Name = "btnProcesarImportacion";
            this.btnProcesarImportacion.Size = new System.Drawing.Size(27, 30);
            this.btnProcesarImportacion.TabIndex = 4;
            this.btnProcesarImportacion.Text = "Procesar Importacion";
            this.btnProcesarImportacion.ThemeName = "Office2013Light";
            this.btnProcesarImportacion.Click += new System.EventHandler(this.btnProcesarImportacion_Click);
            // 
            // gridImportacion
            // 
            this.gridImportacion.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gridImportacion.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridImportacion.Name = "gridImportacion";
            this.gridImportacion.Size = new System.Drawing.Size(1266, 214);
            this.gridImportacion.TabIndex = 5;
            this.gridImportacion.Text = "radGridView1";
            // 
            // frmImpCostosProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 429);
            this.Controls.Add(this.gridControl);
            this.Name = "frmImpCostosProduccion";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Importacion costos produccion";
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.gridControl.ResumeLayout(false);
            this.gridControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpImportacion)).EndInit();
            this.rpImportacion.ResumeLayout(false);
            this.rpImportacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalirImprotacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbImportarDirecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbArchivoTexto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesarImportacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImportacion.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImportacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadPanel rpImportacion;
        private Telerik.WinControls.UI.RadButton btnSalirImprotacion;
        private Telerik.WinControls.UI.RadButton btnImportar;
        private Telerik.WinControls.UI.RadRadioButton rbImportarDirecto;
        private Telerik.WinControls.UI.RadRadioButton rbArchivoTexto;
        private Telerik.WinControls.UI.RadButton btnProcesarImportacion;
        private Telerik.WinControls.UI.RadGridView gridImportacion;
    }
}
