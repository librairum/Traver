using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Inv.UI.Win
{
    public partial class FrmPeriodos : frmBaseMante
    {
        private bool isLoaded = false;
        public FrmPeriodos()
        {
            InitializeComponent();
            Crearcolumnas();
            //radCommandBar1.

            //btnguardar.Visible = false;
            //btncancelar.Visible = false;
            gbclave.Visible = false;
            // The password character is an asterisk.
            txtclave.Text = "";
            txtclave.PasswordChar = '*';
           }
        private frmMDI FrmParent { get; set; }
        private static FrmPeriodos _aForm;

         public static FrmPeriodos Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmPeriodos(mdiPrincipal);
            _aForm = new FrmPeriodos(mdiPrincipal);
            return _aForm;
        }

         public FrmPeriodos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
       
            gbclave.Visible = false;
            // The password character is an asterisk.
            txtclave.Text = "";
            txtclave.PasswordChar = '*';
             
             //deshabilito todo los botones para este formulario
            HabilitarBotones(false, false, false, false, false, false);
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = PeriodoLogic.Instance.PeriodoTraer(Logueo.CodigoEmpresa,Logueo.Anio);
            this.gridControl.DataSource = lista;
        }
        
        private void OnGuardar()
        {
           string mensajeRetorno = string.Empty;
           string periodocodigo;
           bool periodoestado;
           int flagok=0;

           if (this.gridControl.RowCount == 0)
               return;

            try
            {

                periodocodigo = Logueo.Anio + gridControl.CurrentRow.Cells["ccb03cod"].Value.ToString();
                periodoestado = bool.Parse(gridControl.CurrentRow.Cells["ccb03proc"].Value.ToString());

                // Cambio el estado
                if (periodoestado == true)
                    periodoestado = false;
                else
                    periodoestado = true;


                Periodo periodo = new Periodo();
                periodo.ccb03emp = Logueo.CodigoEmpresa;
                periodo.ccb03cod = periodocodigo;
                periodo.ccb03proc = periodoestado;


                
                PeriodoLogic.Instance.PeriodoModificarEstado(periodo, out flagok, out mensajeRetorno);

                if(flagok!=1)
                {
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else
                {
                        OnBuscar();
                }

                
            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado ", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #region metodosdemantenimineto
        private void Crearcolumnas()
        {
            this.gridControl.Columns.Clear();
            this.gridControl.AllowAddNewRow = false;
            this.gridControl.ShowGroupPanel = false;
            this.gridControl.ShowFilteringRow = true;
            this.gridControl.AllowColumnReorder = true;

            this.gridControl.AutoGenerateColumns = false;
            //this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            //this.gridControl.AllowSearchRow = true;
            //this.gridControl.SearchRowPosition = SystemRowPosition.Top;

            this.gridControl.EnableHotTracking = true;
            this.gridControl.ShowFilteringRow = true;
            this.gridControl.EnableFiltering = true;


            this.CreateGridColumn(this.gridControl, "Codigo", "ccb03cod", 0, "", 50, true, false,true);
            this.CreateGridColumn(this.gridControl, "Descripcion", "ccb03des", 0, "", 250, true, false, true);
            this.CreateGridColumn(this.gridControl, "Estado", "ccb03proc", 0, "", 50, true, false,false);
            
            // Agregar columna boton
            Telerik.WinControls.UI.GridViewCommandColumn newColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            newColumn.HeaderText = "Accion";
            newColumn.FieldName = "PeriodoEstado";
            newColumn.Name = "PeriodoEstado";
            gridControl.MasterTemplate.Columns.Add(newColumn);

                             
        } 
        #endregion metodosdemantenimineto
        private void FrmPeriodos_Load(object sender, EventArgs e)
        {
            OnBuscar();
            //Capturo el primer registro valido 
         isLoaded = true;
        }
        private void gridControl_Click(object sender, EventArgs e)
        {

        }
        void gridControl_CommandCellClick(object sender, EventArgs e)
        {
           if (this.gridControl.RowCount == 0)
            return;

            try
            {
                    Telerik.WinControls.UI.GridCommandCellElement _cmd = (Telerik.WinControls.UI.GridCommandCellElement)(sender);
                    // if  text for delete button = X
                    if (_cmd.Value.ToString() == "Abierto" || _cmd.Value.ToString() == "Cerrado")
                    {
                        this.OnGuardar();
                        // LLamo al metodo guardar
                        //this.mostrarclave();
                    }
            }
            catch (Exception)
            {
                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }

            }
        private void gridControl_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement != null)
            {
                if (e.RowElement.RowInfo.Cells["PeriodoEstado"].Value.ToString() == "Abierto")
                {
                    e.RowElement.ForeColor = Color.DarkBlue;
                }
                else
                {
                    e.RowElement.ForeColor = Color.DarkRed;
                }
            }
        }

        private void btnacepta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtclave.Text == "jbaez$1")
                {
                    this.OnGuardar();
                    this.ocultarclave();
                }
                else
                {
                    RadMessageBox.Show("Clave no valida", Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            catch(Exception)
            {
                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        private void mostrarclave()
        { 
                gbclave.Visible = true;
                txtclave.Text = "";
                gridControl.Enabled = false;
                txtclave.Focus();
        }

        private void ocultarclave()
        {
            gbclave.Visible = false;
            gridControl.Enabled = true;
            gridControl.Focus();
        }
        private void btncancela_Click(object sender, EventArgs e)
        {
            this.ocultarclave();
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
     }
}