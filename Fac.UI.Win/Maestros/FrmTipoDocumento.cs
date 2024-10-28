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
using Telerik.WinControls.UI;

namespace Fac.UI.Win
{
    public partial class FrmTipoDocumento : frmBaseMante
    {
        private bool isLoaded = false;
        public FrmTipoDocumento()
        {
             
            InitializeComponent();
            Crearcolumnas();
            //activa botones nuevo,editar,eliminar  deshabilita guardar y cancelar
            habilitarBotones(true, false);
        }

         private frmMDI FrmParent { get; set; }
        private static FrmTipoDocumento _aForm;
        public static FrmTipoDocumento Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmTipoDocumento(mdiPrincipal);
            _aForm = new FrmTipoDocumento(mdiPrincipal);
            return _aForm;
        }
        public FrmTipoDocumento(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            habilitarBotones(true, false);
            //ConfigurarEventos();
        }


        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
       
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            Habilitar(true);
            Limpiar();
            this.txtcodigo.Focus();
            habilitarBotones(false,true);
        }
        protected override void OnCancelar()
        {
            Habilitar(false);
            habilitarBotones(true, false);

        }
        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            Habilitar(true);
            //Deshabilito los valores que no se pueden modificar
            txtcodigo.Enabled = false;
            habilitarBotones(false,true);
        }
        void asignarIndice() {
            radGroupBox2.Focusable = false;
            radGroupBox3.Focusable = false;
            rbtingreso.TabStop = false;
            rbtsalida.TabStop = false;
            rbtingreso.Focusable = false;
            rbtsalida.Focusable = false;
            gridControl.Focusable = false;
            gridControl.TabStop = false;
        }
        protected override void OnEliminar()
        {
            if (this.gridControl.RowCount == 0)
                return;

            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", 
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    string codigotipodocumento = string.Empty;
                    codigotipodocumento = this.gridControl.CurrentRow.Cells["In12tipDoc"].Value.ToString();

                    TipoDocumento tipodocumento = new TipoDocumento();
                    tipodocumento.in12codemp = Logueo.CodigoEmpresa;
                    tipodocumento.In12tipDoc = codigotipodocumento;
                    tipodocumento.in12WorStr = OnCargarOpciones(); // Por Mientras


                    TipoDocumentoLogic.Instance.TipoDocumentoEliminar(tipodocumento, out msgRetorno);
                    RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscar();
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }

            OnCancelar();
        }
        private string OnCargarOpciones() {
            string cCadena = "";
            cCadena += (chkopcion1.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion2.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion3.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion4.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion5.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion6.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion7.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion8.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion9.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion10.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion11.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion12.CheckState == CheckState.Checked) ? "1" : "0";
            cCadena += (chkopcion13.CheckState == CheckState.Checked) ? "1" : "0";
          
            return cCadena;
        }
        protected override void OnGuardar()
        {
             
            if (!Validar())
                return;
            TipoDocumento tipodocumento = new TipoDocumento();
            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
            string tipomovimiento = string.Empty;
            try
            {

                if (rbtingreso.CheckState==CheckState.Checked)
                {
                    tipomovimiento="E";
                }
                else
                {
                    tipomovimiento="S";
                }
                
               
                tipodocumento.in12codemp = Logueo.CodigoEmpresa;
                tipodocumento.In12tipDoc = txtcodigo.Text;
                tipodocumento.In12DesLar = txtdescripcion.Text;
                tipodocumento.in12TipMov = tipomovimiento;                
                tipodocumento.In12ExigeDevu = (chkExigeDev.CheckState == CheckState.Checked) ? "1" : "0";                           
                tipodocumento.in12WorStr = OnCargarOpciones(); // Por Mientras

                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    TipoDocumentoLogic.Instance.TipoDocumentoInsertar(tipodocumento, out mensajeRetorno);

                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    Habilitar(false);
                    this.txtcodigo.Focus();
                }
                else if (this.Estado == FormEstate.Edit)
                {
                    //Modificar
                    TipoDocumentoLogic.Instance.TipoDocumentoModificar(tipodocumento, out mensajeRetorno);

                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    Habilitar(false);
                    
                }
                else
                {
                    RadMessageBox.Show("Opcion no validad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar ", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            OnCancelar();
            if (Estado == FormEstate.New) {
                this.OnEnfocarRegistro(true, gridControl, tipodocumento.In12tipDoc, "In12tipDoc");
            }
            else if (Estado == FormEstate.Edit) {
                this.OnEnfocarRegistro(false, gridControl, tipodocumento.In12tipDoc, "In12tipDoc");
            }
            this.Estado = FormEstate.List;
        }

        private bool Validar()
        {
            if (this.txtcodigo.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }

            if (this.txtdescripcion.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcion.Focus();
                return false;
            }


          
            return true;
        }
    
        #region metodosdemantenimineto

        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            this.txtcodigo.Enabled = valor;
            this.txtdescripcion.Enabled = valor;
            this.rbtingreso.Enabled = valor;
            this.rbtsalida.Enabled = valor;
            this.radGroupBox3.Enabled = valor;
            this.chkExigeDev.Enabled = valor;
        }

        public void Limpiar()
        {
            this.txtcodigo.Text = "";
            this.txtdescripcion.Text = "";
            this.rbtingreso.CheckState = CheckState.Checked;
        }

        private void CargarRegistro()
        {

            if (this.gridControl.RowCount == 0)
                return;

            string codigo = string.Empty;
            codigo = this.gridControl.CurrentRow.Cells["In12tipDoc"].Value.ToString();


            var tipodocumento = TipoDocumentoLogic.Instance.TraerTipoDocumentoRegistro(Logueo.CodigoEmpresa, codigo);
            
            if (tipodocumento != null)
            {
                this.txtcodigo.Text = tipodocumento.In12tipDoc;
                this.txtdescripcion.Text = tipodocumento.In12DesLar;
                if (tipodocumento.in12TipMov == "E")
                {
                    rbtingreso.CheckState = CheckState.Checked;
                }
                else
                {
                    rbtsalida.CheckState = CheckState.Checked;
                }

                if (tipodocumento.In12ExigeDevu == "1")
                {
                    chkExigeDev.CheckState = CheckState.Checked;
                }
                else {
                    chkExigeDev.CheckState = CheckState.Unchecked;
                }
                string miCadena = TipoDocumentoLogic.Instance.DameVariable(Logueo.CodigoEmpresa,tipodocumento.In12tipDoc);
                //proveedor
                chkopcion1.CheckState = (miCadena.Substring(0, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //centro de costo
                chkopcion2.CheckState = (miCadena.Substring(1, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //responsable de almacen
                chkopcion3.CheckState = (miCadena.Substring(2, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //responsable de recepcion
                chkopcion4.CheckState = (miCadena.Substring(3, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion5.CheckState = (miCadena.Substring(4, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion6.CheckState = (miCadena.Substring(5, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion7.CheckState = (miCadena.Substring(6, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion8.CheckState = (miCadena.Substring(7, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion9.CheckState = (miCadena.Substring(8, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion10.CheckState = (miCadena.Substring(9, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion11.CheckState = (miCadena.Substring(10, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible
                chkopcion12.CheckState = (miCadena.Substring(11, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //Comprobante salida almacen.
                chkopcion13.CheckState = (miCadena.Substring(12, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;


            }
        }

        private void Crearcolumnas()
        {            
            RadGridView grilla =  this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(this.gridControl, "Codigo", "In12tipDoc", 0, "", 50, true, false, true);
            this.CreateGridColumn(this.gridControl, "Descripcion", "In12DesLar", 0, "", 350, true, false, true);
       

        }
        #endregion metodosdemantenimineto

        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["In12tipDoc"].Value != null)
                    {
                        CargarRegistro();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmTipoDocumento_Load(object sender, EventArgs e)
        {
            OnBuscar();
            //Capturo el primer registro valido 
            CargarRegistro();
            isLoaded = true;
            //habilitarBotones nuevo ,edita,eliminar y deshabilita guardar y cancelar del formulario padre
            habilitarBotones(true, false);
            Habilitar(false);
            
        }
        
        private void Ctrl_Up(object sender, KeyEventArgs e) {
            Util.SendEnter(e, sender,this);
        }              
    }
}
