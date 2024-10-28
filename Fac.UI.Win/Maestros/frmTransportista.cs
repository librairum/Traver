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
using System.Reflection;
using System.Data.Linq;
using System.Linq;
namespace Fac.UI.Win.Maestros
{
    public partial class frmTransportista : frmBaseMante
    {
        private bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        CuentaCorriente cuenta = new CuentaCorriente();
        public frmTransportista()
        {
            InitializeComponent();
        }
        public frmTransportista(frmMDI formularioPadre) {
            InitializeComponent();
          menu =  radCommandBar1.CommandBarElement.Rows[0].Strips[0];
          cbbNuevo = menu.Items["cbbNuevo"];
          cbbGuardar = menu.Items["cbbGuardar"];
          cbbCancelar = menu.Items["cbbCancelar"];
          
        }
        private static frmTransportista _aForm;
        private frmMDI frmParent { get; set; }
        public static frmTransportista Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmTransportista(formParent);
            _aForm = new frmTransportista(formParent);
            return _aForm;
        }


        #region "eventos botones"
     
        void habilitaCajasTexto(bool valor) {
            txtruc.Enabled = valor;
            txtempresa.Enabled = valor;
            txttipdoc.Enabled = valor;
            txTEntidadEmisora.Enabled = valor;
            txtNroRegistroMTC.Enabled = valor;
            txtTarjetaUnicaCirculacion.Enabled = valor;
            txtEntidadAyuda.Enabled = valor;
            
            
        }

        void deshabilitaBotones()
        {
            gestionarBotones(true, true, true, true, true);
        }
        void cargarEntidad() {
            cuenta.ccm02emp = Logueo.CodigoEmpresa;
            cuenta.ccm02tipana = Logueo.TipoAnalisisTransportista;
            cuenta.ccm02cod = txtruc.Text.Trim();
            cuenta.ccm02nom = txtempresa.Text.Trim();
            cuenta.ccm02tipdocidentidad = txttipdoc.Text.Trim();
            cuenta.ccm02EntidadEmiCod = txtEntidadAyuda.Text.Trim();
            cuenta.ccm02NroRegistroMTC = txtNroRegistroMTC.Text.Trim();
            cuenta.ccm02TarjetaUnicaCirculacion = txtTarjetaUnicaCirculacion.Text.Trim();
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            limpiar();
            habilitaCajasTexto(true);
            txttipdoc.Focus();
            gestionarBotones(false, false, false, true, true);
           
        }

        protected override void OnEditar()
        {
            if (gridControl.MasterView.Rows.Count == 0) return;
            Estado = FormEstate.Edit;
            habilitaCajasTexto(true);
            txtruc.Enabled = false;
            txtempresa.Focus();
            gestionarBotones(false, false, false, true, true);
            
        }

        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            limpiar();
            habilitaCajasTexto(false);                       
            gestionarBotones(true, true, true, false, false);
            CargarRegistro();            
        }
        void enfocarRegistroAnterior() {
            int indice = gridControl.MasterView.CurrentRow.Index;
            OnCargar();

            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        protected override void OnEliminar()
        {
            try
            {
                if (gridControl.MasterView.Rows.Count == 0)
                    return;
                //Valido si tiene un transportista asigando a un vehiculo.
                cargarEntidad();
                string msj = string.Empty;
                int flag = 0;
                
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro " + cuenta.ccm02cod + "?");
                if (respuesta == true)
                {
                    CuentaCorrienteLogic.Instance.Fac_CuentaCorrienteEliminar(cuenta, out flag, out msj);
                    Util.ShowMessage(msj, flag);
                    if (flag == 1)
                    {
                        enfocarRegistroAnterior();    
                    }                                        
                }
                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        private  void limpiar() {
            txtruc.Text = "";
            txtempresa.Text = "";
            txttipdoc.Text = "";
            txTEntidadEmisora.Text = "";
            txtNroRegistroMTC.Text = "";
            txtTarjetaUnicaCirculacion.Text = "";

        }
                
        protected override void OnGuardar()
        {
            
            try
            {
                if (!Validar())
                    return;
               
                cargarEntidad();
               
                string msj = string.Empty;
                int flag = 0;
                if (Estado == FormEstate.New)
                {
                    CuentaCorrienteLogic.Instance.Fac_CuentaCorrienteInsertar(cuenta, out flag, out msj);                    
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                }
                else if (Estado == FormEstate.Edit)
                {
                    CuentaCorrienteLogic.Instance.Fac_CuentaCorrienteActualizar(cuenta, out flag, out msj);                    
                    cbbNuevo.IsMouseOver = false;
                }
                if (flag == 0)
                { 
                
                }
                OnCancelar();
                OnCargar();                
                Util.enfocarFila(this.gridControl, "ccm02cod", cuenta.ccm02cod);
                MessageBox.Show(msj);
                Estado = FormEstate.List;
                //cbbGuardar.IsMouseOver = false;
            }catch (Exception ex) {
                Util.ShowError(ex.Message);
                OnCancelar();
            }
        }
        #endregion

        #region "eventos grilla"

        private bool Validar() 
        {
            cbbGuardar.IsMouseOver = false;
            if (string.IsNullOrEmpty(txtruc.Text.Trim()))
            {
                MessageBox.Show("Ingresar ruc.");
                txtruc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtempresa.Text.Trim()) ) {
                MessageBox.Show("Ingresar empresa.");
                txtempresa.Focus();
                return false;
            }

            //Validar que valores de ser numericos
            if (txttipdoc.Text.Trim()=="1")
                {
                    if (txtruc.Text.Length !=8)
                        {
                            MessageBox.Show("Longitud de DNI No Valida");
                            txtruc.Focus();
                            return false;
                        }
                }


            if (txttipdoc.Text.Trim() == "6")
            {
                if (txtruc.Text.Length != 11)
                {
                    MessageBox.Show("Longitud de RUC No Valida");
                    txtruc.Focus();
                    return false;
                }
            }

           
            return true;
        }
      
        private void frmTransportista_Load(object sender, EventArgs e)
        {
            Util.ResaltarAyuda(txtEntidadAyuda);
            Util.ResaltarAyuda(txttipdoc);
            crearcolumnas();
            OnCargar();
            Estado = FormEstate.List;
            deshabilitaBotones();
            habilitaCajasTexto(false);
            isLoaded = true;
            gestionarBotones(true, true, true, false, false);
            
            //cbbNuevo.IsMouseOver = true;
            
            if (gridControl.RowCount > 0)
                CargarRegistro();

        }

        void crearcolumnas()
        {
            RadGridView dgv = CreateGridVista(gridControl);
            CreateGridColumn(dgv, "Documento", "ccm02cod", 0, "", 200);
            CreateGridColumn(dgv, "Transportistas", "ccm02nom", 0, "", 500);
            CreateGridColumn(dgv, "TipDoc", "ccm02tipdocidentidad", 0, "", 60, true, false, false); // oculto
            CreateGridColumn(dgv, "Tipo documento", "TipDocDesc", 0, "", 150);
            CreateGridColumn(dgv, "ccm02EntidadEmiCod", "ccm02EntidadEmiCod", 0, "", 60, true, false, false); // oculto
            CreateGridColumn(dgv, "ccm02NroRegistroMTC", "ccm02NroRegistroMTC", 0, "", 60, true, false, false); // oculto
            CreateGridColumn(dgv, "ccm02TarjetaUnicaCirculacion", "ccm02TarjetaUnicaCirculacion", 0, "", 60, true, false, false); // oculto
        }
        void OnCargar()
        {
            try
            {
                var lista = CuentaCorrienteLogic.Instance.TraeCliente(Logueo.CodigoEmpresa, Logueo.TipoAnalisisTransportista, "", "*");
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex) { 
            
            }
            
        }
       

        private void CargarRegistro()
        {
            try
            {
                if (gridControl.RowCount == 0)
                    return;
                string codigo = string.Empty;

                codigo = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                txtruc.Text =  Util.GetCurrentCellText(gridControl, "ccm02cod");
                txtempresa.Text = Util.GetCurrentCellText(gridControl, "ccm02nom");
                txttipdoc.Text = Util.GetCurrentCellText(gridControl, "ccm02tipdocidentidad");
                lbltipdoc.Text = Util.GetCurrentCellText(gridControl, "TipDocDesc");
                txtEntidadAyuda.Text = Util.GetCurrentCellText(gridControl, "ccm02EntidadEmiCod");
                txtNroRegistroMTC.Text = Util.GetCurrentCellText(gridControl, "ccm02NroRegistroMTC");
                txtTarjetaUnicaCirculacion.Text = Util.GetCurrentCellText(gridControl, "ccm02TarjetaUnicaCirculacion");
                //1 //LIBRETA ELECTORAL O DNI
                //6 //REG.UNICO DE CONTRIBUYENTES
                string codigoDescripcion = Convert.ToString(37 + txtEntidadAyuda.Text);
                string Descripcion = "";
                GlobalLogic.Instance.DameDescripcionFA(codigoDescripcion, "CATALOGOFE", out Descripcion);
                txTEntidadEmisora.Text = Descripcion;
            }
            catch (Exception ex) { 
            
            }
            
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (!isLoaded) return;
                if (Estado == FormEstate.New) return;
                var row = e.CurrentRow.Cells;
             
                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["ccm02nom"].Value != null)
                    {
                        CargarRegistro();
                    }
                }
            }
            catch (Exception ex) { 
            
            }
        }
        #endregion

     

        string[] TraerRespuestaDeAyuda(enmAyuda TipoBusqueda, object parametro1)
        {
            string[] datos = null;
            try
            {

                
                frmBusqueda frm = new frmBusqueda(TipoBusqueda, parametro1);
                frm.ShowDialog();
                if (frm.Result != null)
                {
                    if (frm.Result.ToString() != "")
                    {
                        datos = frm.Result.ToString().Split('|');
                    }
                }
                
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
            }
            return datos;
        }
        private void txttipdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_TipoDoc, "");
                if (datos == null) return;
                txttipdoc.Text = datos[0];
                lbltipdoc.Text = datos[1];
            }
        }

     

        private void txtEntidadAyuda_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmCatalogoD37, "");
                    if (datos == null) return;
                    //if (datos == null) return;
                    txtEntidadAyuda.Text = datos[0];
                    txTEntidadEmisora.Text = datos[1];
                    //txttipdoc.Text = datos[0];
                    //lbltipdoc.Text = datos[1];
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error :: "+ex);
            }
        }

    }
}
