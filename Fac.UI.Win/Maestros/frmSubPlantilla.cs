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
namespace Fac.UI.Win.Maestros
{
    public partial class frmSubPlantilla : frmBaseMante
    {
        public frmSubPlantilla()
        {
            InitializeComponent();
        }
        #region "inicio de variables"
        bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGrabar;
        SubPlantilla subplantilla = new SubPlantilla();
        #endregion

        #region "metodo de formmulario"
        private static frmSubPlantilla _aForm;
        private frmMDI frmParent { get; set; }

        public static frmSubPlantilla Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmSubPlantilla(formParent);
            _aForm = new frmSubPlantilla(formParent);
            return _aForm;
        }
        public frmSubPlantilla(frmMDI frmPadre)
        {
            InitializeComponent();                       

        }
        #endregion

        #region "metodos grilla"

        void crearColumnas()
        {    

            CreateGridVista(this.gridControl);
            this.CreateGridColumn(gridControl, "Filtro", "Filtro", 0, "", 100, true, false, false); // oculto
            //Codigo
            
            this.CreateGridColumn(gridControl,"Codigo","FAC03COD",0,"",70);
            //descripcion
            this.CreateGridColumn(gridControl,"Descripcion","FAC03DESC",0,"",250);
            //Tip Documento
            this.CreateGridColumn(gridControl, "TipDocumento", "FAC01DESC", 0, "", 250);
            //Plantilla 
            this.CreateGridColumn(gridControl, "Plantilla", "FAC02DESC", 0, "", 250);

            //FAC03CANITEMS
            this.CreateGridColumn(gridControl, "FAC03CANITEMS", "FAC03CANITEMS", 0, "", 100,true,true,false);
            
            //FAC03SERIEXDEF            
            this.CreateGridColumn(gridControl, "FAC03SERIEXDEF", "FAC03SERIEXDEF", 0, "", 100, true, true, false);            
            
            //FAC03TIPART
            this.CreateGridColumn(gridControl, "FAC03TIPART", "FAC03TIPART", 0, "", 100, true, true, false);
            this.CreateGridColumn(gridControl, "FAC01COD", "FAC01COD", 0, "", 100, true, true, false);
            //Codigo plantilla 
            this.CreateGridColumn(gridControl, "FAC02COD", "FAC02COD", 0, "", 100, true, true, false);

            this.CreateGridColumn(gridControl, "FAC03TIPOVENTA", "FAC03TIPOVENTA", 0, "", 100, true, true, false);
            this.CreateGridColumn(gridControl, "FAC03PLANTILLAFE", "FAC03PLANTILLAFE", 0, "", 100, true, true, false);
            this.CreateGridColumn(gridControl, "FAC03TIPOOPERACIONFE", "FAC03TIPOOPERACIONFE", 0, "", 100, true, true, false);
            

        }

        //seleccioanr un registro de gridControl
        void cargarDetalle() {
            GridViewRowInfo info = this.gridControl.CurrentRow;
            txtcodigo.Text = info.Cells["FAC03COD"].Value.ToString();
            txtdescripcion.Text = info.Cells["FAC03DESC"].Value.ToString();
            txttipdoc.Text = info.Cells["FAC01COD"].Value.ToString();
            txtplantilla.Text = info.Cells["FAC02COD"].Value.ToString();
            
            string cuenta0 = string.Empty;
            SubPlantillaLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txttipdoc.Text.Trim(), "1000", out cuenta0);
            txttipdocdesc.Text = cuenta0;
                    
            string cuenta1 = string.Empty;
            SubPlantillaLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtplantilla.Text, "1001", out cuenta1);
            txtplantilladesc.Text = cuenta1;

            //Datos de configuracion
            txtcantItem.Text = info.Cells["FAC03CANITEMS"].Value.ToString();    
            txtserie.Text = info.Cells["FAC03SERIEXDEF"].Value.ToString();    
            txttipart.Text = info.Cells["FAC03TIPART"].Value.ToString();

            txttipoventa.Text = info.Cells["FAC03TIPOVENTA"].Value.ToString();
            txtplantillafe.Text = info.Cells["FAC03PLANTILLAFE"].Value.ToString();
            txttipooperacion.Text = info.Cells["FAC03TIPOOPERACIONFE"].Value.ToString();
            

            string cuenta2 = string.Empty;
            SubPlantillaLogic.Instance.DameDescripcion("13" + txttipart.Text, "GLODESC",out cuenta2);
            txttipartdesc.Text = cuenta2; 
            
            string tipoventadescripcion = "";
            SubPlantillaLogic.Instance.DameDescripcion("51" + txttipoventa.Text, "GLODESC", out tipoventadescripcion);
            txttipoventadesc.Text = tipoventadescripcion;

            //SubPlantillaLogic.Instance.DameDescripcion(
            //txttipoventa
            //txttipoventadesc

            string plantillafedescripcion = "";
            SubPlantillaLogic.Instance.DameDescripcion(txtplantillafe.Text, "PLANTILLAFE", out plantillafedescripcion);
            txtplantillafedesc.Text = plantillafedescripcion;
            //txtplantillafe
            //txtplantillafedesc

            string tipooperaciondescripcion = "";

            SubPlantillaLogic.Instance.DameDescripcion("51" + txttipooperacion.Text, "CATALOGOFE", out tipooperaciondescripcion);
            txttipooperaciondesc.Text = tipooperaciondescripcion;
            //txttipooperacion
            //txttipooperaciondesc

        }

        void OnCargar()
        {
            
            cargarEntidad();
            var lista = SubPlantillaLogic.Instance.TraeSubPlantilla(subplantilla, "FAC03COD", "*");
            this.gridControl.DataSource = lista;
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                
                if (gridControl.Rows.Count == 0) return;
                if (Estado == FormEstate.New) return;                               
                if (Util.GetCurrentCellText(gridControl.CurrentRow, "FAC03COD") != "")
                {
                    cargarDetalle();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        #endregion

        #region "metodos , botones del formulario"
        void cargarEntidad() {
            subplantilla.FAC03CODEMP = Logueo.CodigoEmpresa;
            subplantilla.FAC03COD = txtcodigo.Text.Trim();
            subplantilla.FAC01COD = txttipdoc.Text.Trim();
            subplantilla.FAC02COD = txtplantilla.Text.Trim();
            subplantilla.FAC03DESC = txtdescripcion.Text.Trim();            
            subplantilla.FAC03CANITEMS = txtcantItem.Text.Trim() == "" ? 0 : Convert.ToInt32(txtcantItem.Text.Trim());
            subplantilla.FAC03SERIEXDEF = txtserie.Text.Trim();
            subplantilla.FAC03TIPART = txttipart.Text.Trim();
            subplantilla.FAC03TIPOVENTA=  txttipoventa.Text.Trim();
            subplantilla.FAC03PLANTILLAFE = txtplantillafe.Text.Trim();
            subplantilla.FAC03TIPOOPERACIONFE = txttipooperacion.Text.Trim();
                                    
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            BaselimpiarCajas(this);
            BaseHabilitarCajas(this, true);
            txttipdoc.Focus();

            txttipdocdesc.Enabled = false;
            txtplantilladesc.Enabled = false;
            txttipartdesc.Enabled = false;
            txttipoventadesc.Enabled = false;
            txtplantillafedesc.Enabled = false;
            txttipooperaciondesc.Enabled = false;

            ActivarAyuda(true);
            gestionarBotones(false, false, false, true, true);
        }
    
        protected override void OnEditar()
        {
            if (gridControl.Rows.Count == 0) return;
            Estado = FormEstate.Edit;
            
            BaseHabilitarCajas(this, true);
            txtcodigo.Enabled = false;
            txtdescripcion.Focus();
            txttipdoc.Enabled = false;            
            txttipdocdesc.Enabled = false;
            txtplantilladesc.Enabled = false;
            txttipartdesc.Enabled = false;
            txttipoventadesc.Enabled = false;
            txtplantillafedesc.Enabled = false;
            txttipooperaciondesc.Enabled = false;
            ActivarAyuda(true);

            gestionarBotones(false, false, false, true, true);
        }
        void enfocaRegistroAnterior()
        {
            try
            {
                int indice = gridControl.MasterView.CurrentRow.Index;
                OnCargar();
                if (indice > 0)
                {
                    gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                    gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        protected override void OnEliminar()
        {
            try
            {
                if (this.gridControl.MasterView.Rows.Count == 0) return;
                cargarEntidad();
                string msj = string.Empty;
                int flag = 0;

                
                bool respuesta = Util.ShowQuestion("¿Esta seguro de eliminar el registro seleccionado?");
                if (respuesta == true)
                {
                    SubPlantillaLogic.Instance.EliminarSubPlantilla(subplantilla, out flag, out msj);

                    Util.ShowMessage(msj, flag);
                    if (flag == 1)
                    {
                        enfocaRegistroAnterior();
                    }
                 
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }    
        }
        bool Validar() 
        {
  
            if(string.IsNullOrEmpty(txtplantilla.Text.Trim())){                
                Util.ShowAlert("Ingresar subplantilla");
                txtplantilla.Focus();
                return false;
            }
          
            if (string.IsNullOrEmpty(txttipdoc.Text.Trim())) {                
                Util.ShowAlert("Ingresar tipo de documento");
                txttipdoc.Focus();
                return false;
            }                
   
            if (string.IsNullOrEmpty(txtcodigo.Text.Trim())) {                
                Util.ShowAlert("Ingresar codigo");
                txtcodigo.Focus();
                return false;
            }
   
            if (string.IsNullOrEmpty(txtdescripcion.Text.Trim())) {                
                Util.ShowAlert("Ingresar descripcion");
                txtdescripcion.Focus();
                return false;
            }
    
            if (string.IsNullOrEmpty(txtserie.Text.Trim())) {                
                Util.ShowAlert("Serie no valida");
                txtserie.Focus();
                return false;
            }
    
            if (string.IsNullOrEmpty(txttipart.Text.Trim())) {                
                Util.ShowAlert("Tipo de articulo no valido");
                txttipart.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txttipartdesc.Text.Trim()) || txttipartdesc.Text.Trim() == "???") {                
                Util.ShowAlert("Tipo de articulo no valido");
                txttipartdesc.Focus();
                return false;
            }
    
            if (string.IsNullOrEmpty(txtplantilladesc.Text.Trim()) || txtplantilladesc.Text.Trim() == "???") {                
                Util.ShowAlert("Tipo de plantilla no valido");
                return false;
            }
            
            if (string.IsNullOrEmpty(txttipdocdesc.Text.Trim()) || txttipdocdesc.Text.Trim() == "???") {                
                Util.ShowAlert("Tipo de documento no valido");
                return false;
            }
            return true;   
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
                    SubPlantillaLogic.Instance.InsertarSubPlantilla(subplantilla, out flag, out msj);                    
                }
                else if (Estado == FormEstate.Edit)
                {
                    SubPlantillaLogic.Instance.ActualizarSubPlantilla(subplantilla, out flag, out msj);
                    
                }

                Util.ShowMessage(msj, flag);
                if (flag == 1)
                {
                    //enfocar en el boton nuevo
                    cbbNuevo.IsMouseOver = false;
                    cbbNuevo.Focus();
                    
                    //desenfocar el boton grabar
                    cbbGrabar.IsMouseOver = false;

                    //Refresca la grilla
                    OnCargar();
                    
                    //Busca el registro insertado en la grilla actualizada
                    string buscarCod = subplantilla.FAC03COD + subplantilla.FAC01COD + subplantilla.FAC02COD;
                    Util.enfocarFila(this.gridControl, "Filtro", buscarCod);

                    //bloque los controles del mantenimiento
                    OnCancelar();
                    Estado = FormEstate.List;
                    
                }
               
                
              
            }
            catch (Exception ex) {
                OnCancelar();
            }
            
        }

        protected override void OnCancelar()
        {            
            BaseHabilitarCajas(this,false);
            cargarDetalle();
            Estado = FormEstate.List;
            ActivarAyuda(false);
            gestionarBotones(true, true, true, false, false);
        }
        #endregion

      
        private void txttipdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) {
                TraerAyuda(enmAyuda.enmBuscaTipDoc);                
            }
        }

        private void txttipart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) {
                TraerAyuda(enmAyuda.enmBuscaTipArt);                
            }
        }
 
        private void txtplantilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) {
                TraerAyuda(enmAyuda.enmBuscaPlantilla);            
            }
        }

        private void txttipart_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            
            if (txttipart.Text.Length == 0 || string.IsNullOrEmpty(txttipart.Text.Trim()))
            {
                txttipartdesc.Text = "";
                return;
            }

            string nombre = string.Empty;           
            string cCodigo = "13" + txttipart.Text.Trim();
            SubPlantillaLogic.Instance.DameDescripcion(cCodigo, "GLODESC", out nombre);          
            txttipartdesc.Text = nombre;
                      
        }

        private void txttipdoc_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            
            
            if (txttipdoc.Text.Length == 0 || string.IsNullOrEmpty(txttipdoc.Text.Trim()))
            {
                txttipdocdesc.Text = "";
                return;
            }
            string nombre = string.Empty;
            string cCodigo = Logueo.CodigoEmpresa + txttipdoc.Text.Trim();
            SubPlantillaLogic.Instance.DameDescripcion(cCodigo, "1000", out nombre);
            txttipdocdesc.Text = nombre;
        }

        private void txtplantilla_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            

            if (txtplantilla.Text.Length == 0 || string.IsNullOrEmpty(txtplantilla.Text.Trim()))
            {
                txttipdocdesc.Text = "";
                return;
            }
            string nombre = string.Empty;
            string cCodigo = Logueo.CodigoEmpresa + txtplantilla.Text.Trim();
            SubPlantillaLogic.Instance.DameDescripcion(cCodigo, "1001", out nombre);
            txtplantilladesc.Text = nombre;
        }
        
        //29092019
        private void txtserie_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.F1)
            {
                TraerAyuda(enmAyuda.enmSerie);
            }
        }
        //29092019
        private void txttipoventa_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmtipoVenta);                              
            }
            
            
        }
        //29022019
        private void frmSubPlantilla_Load(object sender, EventArgs e)
        {
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGrabar = menu.Items["cbbGuardar"];

            crearColumnas();
            OnCargar();

            BaseHabilitarCajas(this, false);
            gestionarBotones(true, true, true, false, false);

            txttipdoc.MaxLength = 2;
            txtcodigo.MaxLength = 2;
            txttipart.MaxLength = 2;
            txtserie.MaxLength = 4;
            txtplantilla.MaxLength = 2;


            isLoaded = true;
        }

        private void txtplantillafecod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmPlantillaFE);
            }
        }
        private void TraerAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm;
            string[] datos;
            try
            {
                switch (tipoAyuda)
                {
                    case enmAyuda.enmtipoVenta:
                        frm = new frmBusqueda(tipoAyuda);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        txttipoventa.Text = datos[0];
                        txttipoventadesc.Text = datos[1];
                        break;
                    case enmAyuda.enmPlantillaFE:
                        frm = new frmBusqueda(tipoAyuda, txttipdoc.Text);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        txtplantillafe.Text = datos[0];
                        txtplantillafedesc.Text = datos[1];
                        break;
                    case enmAyuda.enmBuscaPlantilla:
                        frm = new frmBusqueda(tipoAyuda);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        txtplantilla.Text = datos[0];
                        txtplantilladesc.Text = datos[1];
                        txtplantilla.Focus();
                        break;
                    case enmAyuda.enmBuscaTipArt:
                        frm = new frmBusqueda(tipoAyuda);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        txttipart.Text = datos[0];
                        txttipartdesc.Text = datos[1];
                        txttipart.Focus();                        
                        break;
                    case enmAyuda.enmBuscaTipDoc:
                        frm = new frmBusqueda(tipoAyuda);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        txttipdoc.Text = datos[0];
                        txttipdocdesc.Text = datos[1];
                        txttipdoc.Focus();                        
                        break;
                    case enmAyuda.enmSerie:
                        frm = new frmBusqueda(tipoAyuda, txttipdoc.Text);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        txtserie.Text = datos[0];
                        break;
                    case enmAyuda.enmOperacionFE:
                        frm = new frmBusqueda(tipoAyuda);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        txttipooperacion.Text = datos[0];
                        txttipooperaciondesc.Text = datos[1];
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        private void ActivarAyuda(bool resaltaControles)
        {
            if (resaltaControles == true)
            {
                Util.ResaltarAyuda(txttipoventa);
                Util.ResaltarAyuda(txtplantillafe);
                Util.ResaltarAyuda(txtplantilla);
                Util.ResaltarAyuda(txttipart);
                Util.ResaltarAyuda(txttipdoc);
                Util.ResaltarAyuda(txttipooperacion);
            }
            else if (resaltaControles == false)
            {
                Util.ResetearAyuda(txttipoventa);
                Util.ResetearAyuda(txtplantillafe);
                Util.ResetearAyuda(txtplantilla);
                Util.ResetearAyuda(txttipart);
                Util.ResetearAyuda(txttipdoc);
                Util.ResetearAyuda(txttipooperacion);
            }
            
        }

        private void txttipooperacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmOperacionFE);
            }
        }
    }
}
