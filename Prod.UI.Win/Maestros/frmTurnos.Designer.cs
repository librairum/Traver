namespace Prod.UI.Win
{
    partial class frmTurnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurnos));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pnlControl = new Telerik.WinControls.UI.RadPanel();
            this.txtHoraFinExt = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtHoraInicioExt = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtHoraFin = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtHoraInicio = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.gridControl = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraFinExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraInicioExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Size = new System.Drawing.Size(874, 33);
            // 
            // barraComando
            // 
            this.barraComando.BackColor = System.Drawing.Color.White;
            this.barraComando.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.barraComando.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.barraComando.BorderColor3 = System.Drawing.Color.White;
            this.barraComando.BorderColor4 = System.Drawing.Color.White;
            this.barraComando.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.barraComando.Bounds = new System.Drawing.Rectangle(0, 0, 159, 30);
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
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.txtHoraFinExt);
            this.pnlControl.Controls.Add(this.txtHoraInicioExt);
            this.pnlControl.Controls.Add(this.txtHoraFin);
            this.pnlControl.Controls.Add(this.txtHoraInicio);
            this.pnlControl.Controls.Add(this.radLabel6);
            this.pnlControl.Controls.Add(this.radLabel5);
            this.pnlControl.Controls.Add(this.radLabel4);
            this.pnlControl.Controls.Add(this.radLabel3);
            this.pnlControl.Controls.Add(this.radLabel2);
            this.pnlControl.Controls.Add(this.txtDescripcion);
            this.pnlControl.Controls.Add(this.radLabel1);
            this.pnlControl.Controls.Add(this.txtCodigo);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 33);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(874, 176);
            this.pnlControl.TabIndex = 27;
            // 
            // txtHoraFinExt
            // 
            this.txtHoraFinExt.Location = new System.Drawing.Point(108, 139);
            this.txtHoraFinExt.Mask = "00:00";
            this.txtHoraFinExt.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtHoraFinExt.Name = "txtHoraFinExt";
            this.txtHoraFinExt.Size = new System.Drawing.Size(125, 20);
            this.txtHoraFinExt.TabIndex = 41;
            this.txtHoraFinExt.TabStop = false;
            this.txtHoraFinExt.Text = "__:__";
            // 
            // txtHoraInicioExt
            // 
            this.txtHoraInicioExt.Location = new System.Drawing.Point(108, 114);
            this.txtHoraInicioExt.Mask = "00:00";
            this.txtHoraInicioExt.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtHoraInicioExt.Name = "txtHoraInicioExt";
            this.txtHoraInicioExt.Size = new System.Drawing.Size(125, 20);
            this.txtHoraInicioExt.TabIndex = 40;
            this.txtHoraInicioExt.TabStop = false;
            this.txtHoraInicioExt.Text = "__:__";
            // 
            // txtHoraFin
            // 
            this.txtHoraFin.Location = new System.Drawing.Point(108, 90);
            this.txtHoraFin.Mask = "00:00";
            this.txtHoraFin.MaskType = Telerik.WinControls.UI.MaskType.FreeFormDateTime;
            this.txtHoraFin.Name = "txtHoraFin";
            this.txtHoraFin.Size = new System.Drawing.Size(125, 20);
            this.txtHoraFin.TabIndex = 39;
            this.txtHoraFin.TabStop = false;
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(108, 65);
            this.txtHoraInicio.Mask = "00:00";
            this.txtHoraInicio.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(125, 20);
            this.txtHoraInicio.TabIndex = 38;
            this.txtHoraInicio.TabStop = false;
            this.txtHoraInicio.Text = "__:__";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(11, 142);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(91, 18);
            this.radLabel6.TabIndex = 37;
            this.radLabel6.Text = "Hora Salida Extra";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(10, 116);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(94, 18);
            this.radLabel5.TabIndex = 35;
            this.radLabel5.Text = "Hora Inicio Extra :";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(48, 92);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(54, 18);
            this.radLabel4.TabIndex = 33;
            this.radLabel4.Text = "Hora Fin :";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(36, 68);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(66, 18);
            this.radLabel3.TabIndex = 31;
            this.radLabel3.Text = "Hora Inicio :";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(32, 41);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(70, 18);
            this.radLabel2.TabIndex = 29;
            this.radLabel2.Text = "Descripcion :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(108, 39);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(229, 20);
            this.txtDescripcion.TabIndex = 30;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(59, 17);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(43, 18);
            this.radLabel1.TabIndex = 27;
            this.radLabel1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(108, 15);
            this.txtCodigo.MaxLength = 2;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(229, 20);
            this.txtCodigo.TabIndex = 28;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 209);
            // 
            // 
            // 
            this.gridControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(874, 224);
            this.gridControl.TabIndex = 29;
            this.gridControl.Text = "radGridView1";
            this.gridControl.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gridControl_CurrentRowChanged);
            // 
            // frmTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 433);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlControl);
            this.Name = "frmTurnos";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Mantenimiento de turnos";
            this.Controls.SetChildIndex(this.radCommandBar1, 0);
            this.Controls.SetChildIndex(this.pnlControl, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraFinExt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraInicioExt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlControl;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtDescripcion;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtCodigo;
        private Telerik.WinControls.UI.RadGridView gridControl;
        private Telerik.WinControls.UI.RadMaskedEditBox txtHoraFinExt;
        private Telerik.WinControls.UI.RadMaskedEditBox txtHoraInicioExt;
        private Telerik.WinControls.UI.RadMaskedEditBox txtHoraFin;
        private Telerik.WinControls.UI.RadMaskedEditBox txtHoraInicio;
    }
}
