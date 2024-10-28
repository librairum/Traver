using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using System.Reflection;
namespace Fac.UI.Win.Maestros
{
    public partial class frmConductores : frmBaseMante
    {
        private bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        CuentaCorriente cuenta = new CuentaCorriente();
        public frmConductores()
        {
            InitializeComponent();
        }
        public frmConductores(frmMDI frmPadre) {
            InitializeComponent();
            crearcolumnas();
            OnCargar();
            
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            txtCodigo.MaxLength = 8;            

            deshabilitaBotones();
            habilitaCajasTexto(false);
            
            gestionarBotones(true, true, true, false, false);
            if (gridControl.RowCount > 0)
                CargarRegistro();
            isLoaded = true;
            Estado = FormEstate.List;
        }
        private static frmConductores _aForm;
        private frmMDI frmParent { get; set; }
        public static frmConductores Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmConductores(formParent);
            _aForm = new frmConductores(formParent);
            return _aForm;
        }


        
        private void limpiar() {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtBrevete.Text = "";
            txttipdoc.Text = "";
            txtApePaterno.Text = "";
            txtApeMaterno.Text = "";
        }
        private void habilitaCajasTexto(bool valor) {
            txtCodigo.Enabled = valor;
            txtNombre.Enabled = valor;
            txtDireccion.Enabled = valor;
            txtBrevete.Enabled = valor;
            txttipdoc.Enabled = valor;
            txtApePaterno.Enabled = valor;
            txtApeMaterno.Enabled = valor;
            
        }
        private bool Validar() {
            cbbGuardar.IsMouseOver = false;
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim())) {
                MessageBox.Show("Ingresar Dni");
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text.Trim())) {
                MessageBox.Show("Ingresar Nombre.");
                txtNombre.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtBrevete.Text.Trim())) {
                MessageBox.Show("Ingresar brevete.");
                txtBrevete.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txttipdoc.Text.Trim()))
            {
                MessageBox.Show("Ingresar brevete.");
                txttipdoc.Focus();
                return false;
            }
            return true;
        }
        private void deshabilitaBotones(){
            gestionarBotones(true, true, true, true, true);
        }
        #region "eventos botones"
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            limpiar();
            habilitaCajasTexto(true);
            txtCodigo.Focus();
            gestionarBotones(false, false, false, true, true);                        
        }
        
        protected override void OnEditar()
        {
            if (gridControl.MasterView.Rows.Count == 0) return;
            Estado = FormEstate.Edit;
            habilitaCajasTexto(true);
            txtCodigo.Enabled = false;            
            txtNombre.Focus();
            gestionarBotones(false, false, false, true, true);
        }
        
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            limpiar();
            habilitaCajasTexto(false);
            CargarRegistro();
           gestionarBotones(true, true, true, false, false);           
        }
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.CurrentRow.Index;
            OnCargar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }                
        }
        void cargarEntidad() {
            cuenta.ccm02emp = Logueo.CodigoEmpresa;
            cuenta.ccm02tipana = Logueo.TipoAnalisisChofer;
            cuenta.ccm02cod = txtCodigo.Text.Trim();
            //cuenta.ccm02nom = txtNombre.Text.Trim();
            cuenta.ccm02dir = txtDireccion.Text.Trim();
            cuenta.ccm02Brevete = txtBrevete.Text.Trim();
            cuenta.ccm02tipdocidentidad = txttipdoc.Text.Trim();
            cuenta.ccm02nom = txtApePaterno.Text.Trim() +" "+ txtApeMaterno.Text.Trim() +" "+ txtNombre.Text.Trim();
            
            cuenta.ccm02ApePaterno = txtApePaterno.Text.Trim();
            cuenta.ccm02ApeMaterno = txtApeMaterno.Text.Trim();
            cuenta.ccm02Nombres = txtNombre.Text.Trim();
        }
        protected override void OnEliminar()
        {
            try
            {
                if (gridControl.Rows.Count == 0) return;
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
                        enfocaRegistroAnterior();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar: " + ex.Message);
            }
        }

        protected override void OnGuardar()
        {
            try
            {
                if (!Validar()) return;

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
                OnCancelar();
                OnCargar();

                Util.enfocarFila(this.gridControl, "ccm02cod", cuenta.ccm02cod);

                MessageBox.Show(msj);
                Estado = FormEstate.List;
                cbbGuardar.IsMouseOver = false;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar: " + ex.Message);
            }
         
        }
        #endregion

        #region "evento grilla"
        private void crearcolumnas()
        {
            RadGridView dgv = CreateGridVista(gridControl);
            CreateGridColumn(dgv, "Dni", "ccm02cod", 0, "", 200);
            CreateGridColumn(dgv, "Nombre", "ccm02nom", 0, "", 500);
            CreateGridColumn(dgv, "Direccion", "ccm02dir", 0, "", 200);
            CreateGridColumn(dgv, "Brevete", "ccm02Brevete", 0, "", 200);
            CreateGridColumn(dgv, "TipDoc", "ccm02tipdocidentidad", 0, "", 60, true, true, false); //oculto
            CreateGridColumn(dgv, "Tipo documento", "TipDocDesc", 0, "", 150);
            CreateGridColumn(dgv, "ccm02ApePaterno", "ccm02ApePaterno", 0, "", 60, true, true, false); //oculto
            CreateGridColumn(dgv, "ccm02ApeMaterno", "ccm02ApeMaterno", 0, "", 60, true, true, false); //oculto
            CreateGridColumn(dgv, "ccm02Nombres", "ccm02Nombres", 0, "", 60, true, true, false); //oculto
        }
        private void OnCargar()
        {
            //var lista = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, "12");
            var lista = CuentaCorrienteLogic.Instance.TraeCliente(Logueo.CodigoEmpresa, Logueo.TipoAnalisisChofer, "", "*");
            this.gridControl.DataSource = lista;
        }
        private int LimitarCaracteresPorTipoDocumento(string codigoTipDoc)
        {
            int maximoCaracteres = 0;
            if (codigoTipDoc == "1")
            {
                maximoCaracteres = 8;
            }
            else if (codigoTipDoc == "6")
            {
                maximoCaracteres = 11;
            }
            else {
                maximoCaracteres = 0;
            }
            
            return maximoCaracteres;
        }
        private void CargarRegistro()
        {
            try
            {
                if (gridControl.RowCount == 0) return;
                string codigo = string.Empty;
                //codigo = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                txtCodigo.Text = Util.GetCurrentCellText(gridControl, "ccm02cod");
               // txtNombre.Text = Util.GetCurrentCellText(gridControl, "ccm02nom");
                txtDireccion.Text = Util.GetCurrentCellText(gridControl, "ccm02dir");
                txtBrevete.Text = Util.GetCurrentCellText(gridControl, "ccm02Brevete");
                txttipdoc.Text = Util.GetCurrentCellText(gridControl, "ccm02tipdocidentidad");
                lbltipdoc.Text = Util.GetCurrentCellText(gridControl, "TipDocDesc");
                txtApePaterno.Text = Util.GetCurrentCellText(gridControl, "ccm02ApePaterno");
                txtApeMaterno.Text = Util.GetCurrentCellText(gridControl, "ccm02ApeMaterno");
                txtNombre.Text = Util.GetCurrentCellText(gridControl, "ccm02Nombres");


                int longitud = LimitarCaracteresPorTipoDocumento(txttipdoc.Text.Trim());
                if (longitud > 0)
                {
                    txtCodigo.MaxLength = longitud;
                }
                
                //var dato = CuentaCorrienteLogic.Instance.CuentaCorrienteTraerRegistro(Logueo.CodigoEmpresa, "12", codigo);
                //var dato = CuentaCorrienteLogic.Instance.TraeCliente(Logueo.CodigoEmpresa, "12", "ccm02cod", codigo)[0];                
                //if (dato != null)
                //{
                    //txtCodigo.Text = dato.ccm02cod;
                    //txtNombre.Text = dato.ccm02nom;
                    //txtDireccion.Text = dato.ccm02dir;
                    //txtBrevete.Text = dato.ccm02Brevete;
                    //txttipdoc.Text = dato.ccm02tipdocidentidad;
                    //lbltipdoc.Text = dato.TipDocDesc;
                //}
                                                        
            }
           catch (Exception ex) { 
            
            }            
        }
        #endregion

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
            catch (Exception ex)
            {

            }
        }

       
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
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda : " + ex.Message);
            }
            return datos;
        }
       
        private void txttipdoc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_TipoDoc, "");
                    if (datos == null) return;
                    txttipdoc.Text = datos[0];
                    lbltipdoc.Text = datos[1];

                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }                
    }
}
