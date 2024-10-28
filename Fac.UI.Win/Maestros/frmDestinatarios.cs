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
using Fac.UI.Win;
using System.Linq;
using System.Data.Linq;
namespace Fac.UI.Win.Maestros
{
    public partial class frmDestinatarios : frmBaseMante
    {
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;
        CuentaCorriente cuenta = new CuentaCorriente();
        Sede sede = new Sede();
        private bool isLoaded = false;


        public frmDestinatarios()
        {
            InitializeComponent();
        }
        public frmDestinatarios(frmMDI formularioPadre)
        {
            InitializeComponent();

            crearcolumnas();
            OnCargar();
            Estado = FormEstate.List;
            deshabilitaBotonesDestinatario();
            habilitaCajasTexto(false);
            isLoaded = true;
            gestionarBotones(true, true, true, false, false);
            if (gridControl.RowCount > 0)
                CargarRegistro();
            //Domiciolios del destinario 
            OnLoadDomicilio();

            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbCancelar = menu.Items["cbbCancelar"];
            cbbGuardar = menu.Items["cbbGuardar"];
            cbbEditar = menu.Items["cbbEditar"];
            cbbEliminar = menu.Items["cbbEliminar"];
            txtruc.MaxLength = 11;
        }
        private static frmDestinatarios _aForm;
        private frmMDI frmParent { get; set; }

        public static frmDestinatarios Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmDestinatarios(formParent);
            _aForm = new frmDestinatarios(formParent);
            return _aForm;
        }

        #region "metodos botones"
             
        protected override void OnNuevo()
        {
        
            Estado = FormEstate.New;

            gestionarBotones(false, false, false, true, true);

            habilitaCajasTexto(true);
            txtruc.Focus();
            limpiar();
                                                                                    
            //botones de mantenimiento de domicilio
            habilitoBotonesDomicilio(false);                        
            //cajas de domicilio
            habilitoCajasDomicilio(false);                        
            //foco de boton nuevo
           
        }

        protected override void OnEditar()
        {
          
            if (gridControl.MasterView.Rows.Count == 0)
                return;
            Estado = FormEstate.Edit;

            gestionarBotones(false, false, false, true, true);

            habilitaCajasTexto(true);
            txtruc.Enabled = false;
            txtempresa.Focus();

                        
            //botones de mantenimiento de domicilio
            habilitoBotonesDomicilio(false);            
            //cajas de domicilio
            habilitoCajasDomicilio(false);            
        }
   
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            limpiar();
            habilitaCajasTexto(false);
            CargarRegistro();
            //botones de formulario destino
            gestionarBotones(true, true, true, false, false);
            

            //botones de mantenimiento de domicilio
            mostrarXocultaBtnDomicilio(true);                      
            //cajas de domiclio            
            habilitoCajasDomicilio(false);
            habilitoBotonesDomicilio(true);
        }
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.MasterView.CurrentRow.Index;
            OnCargar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        void cargarEntidad() {
            cuenta.ccm02emp = Logueo.CodigoEmpresa;
            cuenta.ccm02tipana = Logueo.TipoAnalisisDestinatario; //tipo de analisis de destinatario
            cuenta.ccm02cod = txtruc.Text.Trim();
            cuenta.ccm02nom = txtempresa.Text.Trim();
            cuenta.ccm02tipdocidentidad = txttipdoc.Text.Trim();
            cuenta.ccm02correo = txtemailguia.Text.Trim();
        }
        protected override void OnEliminar()
        {
            try
            {
                if (gridControl.MasterView.Rows.Count == 0)
                    return;
                if (gridDomicilios.MasterView.Rows.Count > 0)
                {
                    Util.ShowError("Debe eliminar los domicilios del destinario");
                    return;
                }

                cargarEntidad();

                string msj = string.Empty;
                int flag = 0;
                DialogResult res = MessageBox.Show("¿Desea eliminar el registro " + cuenta.ccm02cod + "?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    CuentaCorrienteLogic.Instance.Fac_CuentaCorrienteEliminar(cuenta, out flag, out msj);
                    MessageBox.Show(msj);
                    enfocaRegistroAnterior();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }
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
                    //INSERTAR CUANDO ES NUEVO
                    sede.come05empresa = Logueo.CodigoEmpresa;
                    sede.come05clientetipana = Logueo.TipoAnalisisDestinatario;
                    sede.come05clientecod = txtruc.Text.Trim();
                    sede.come05sedeclientescod = Logueo.DomicilioFiscalCodigo;
                    sede.come05sedeclientesdesc = Logueo.DomicilioFiscalDescripcion;
                    sede.come05FlagDimiFiscal = "1";
                    SedeLogic.Instance.Glo_InsertarSede(sede, out flag, out msj);
                
                }
                else if (Estado == FormEstate.Edit)
                {                    
                    CuentaCorrienteLogic.Instance.Fac_CuentaCorrienteActualizar(cuenta, out flag, out msj);
                }
                if (flag == 1)
                    {

                cbbNuevo.IsMouseOver = true;
                cbbNuevo.Focus();

                OnCancelar();
                OnCargar();
                //buscarFila(cuenta.ccm02cod);
                Util.enfocarFila(this.gridControl, "ccm02cod", cuenta.ccm02cod);
                MessageBox.Show(msj);

                Estado = FormEstate.List;                           
                    
                //botones mantenimiento de domicilio                
                mostrarXocultaBtnDomicilio(true);
                habilitoBotonesDomicilio(true);
                }
                else
                     {
                    MessageBox.Show(msj);
                    return;
                    }

            }
            catch (Exception ex) {
                Util.ShowError("Error al guardar: " + ex.Message);
            }
        }

        #endregion



        #region "metodos formulario"

        private void frmDestinatarios_Load(object sender, EventArgs e)
        {             
            
            //focoMenu();
            ResaltarCajasAyuda();
        }

        private void crearcolumnas()
        {
            RadGridView dgv = CreateGridVista(gridControl);                        
            CreateGridColumn(dgv, "Ruc", "ccm02cod", 0, "", 100, true, false, true); 
            CreateGridColumn(dgv, "Empresa", "ccm02nom", 0, "", 300, true, false, true);
            CreateGridColumn(dgv, "TipDoc", "ccm02tipdocidentidad", 0, "", 60, true, false, false);//oculto
            CreateGridColumn(dgv, "Tipo documento", "TipDocDesc", 0, "", 150);
            CreateGridColumn(dgv, "ccm02correo", "ccm02correo", 0, "", 60, true, false, false);//oculto
        }

        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (string.IsNullOrEmpty(txtempresa.Text.Trim()))
            {
                MessageBox.Show("Ingresar empresa.");
                txtempresa.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtruc.Text.Trim()))
            {
                MessageBox.Show("Ingresar ruc.");
                txtruc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txttipdoc.Text.Trim()))
            {
                txttipdoc.Focus();
                MessageBox.Show("Ingresar tipo de documento.");
                return false;
            }
            return true;
        }     

        private void limpiar()
        {
            txtruc.Text = "";
            txtempresa.Text = "";
            txttipdoc.Text = "";
            lbltipdoc.Text = "";
            txtemailguia.Text = "";
        }

        private void habilitaCajasTexto(bool valor)
        {
            txtruc.Enabled = valor;
            txtempresa.Enabled = valor;
            txttipdoc.Enabled = valor;
            txtemailguia.Enabled = valor;
            txtAyudaDpto.Enabled = valor;
            txtDpto.Enabled = valor;
            txtAyudaProv.Enabled = valor;
            txtProv.Enabled = valor;
            txtAyudaDist.Enabled = valor;
            txtDist.Enabled = valor;
            txtAyudaPuerto.Enabled = valor;
            txtPuerto.Enabled = valor;
            chkDomicilio.Enabled = valor;
        }

        private void deshabilitaBotonesDestinatario()
        {
            gestionarBotones(true, true, true, true, true);
        }

        #endregion




        #region "Evento Grilla"

        void OnCargar()
        {
            try
            {
                var lista = CuentaCorrienteLogic.Instance.TraeCliente(Logueo.CodigoEmpresa, Logueo.TipoAnalisisDestinatario, "", "*");
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar: " + ex.Message);
            }
        }
    
        private void CargarRegistro()
        {
            try
            {
                if (gridControl.RowCount == 0) return;
                string codigo = string.Empty;

                //codigo = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                //var dato = CuentaCorrienteLogic.Instance.CuentaCorrienteTraerRegistro(Logueo.CodigoEmpresa, "15", codigo);
                txtruc.Text = Util.GetCurrentCellText(gridControl, "ccm02cod");
                txtempresa.Text = Util.GetCurrentCellText(gridControl, "ccm02nom");
                txttipdoc.Text = Util.GetCurrentCellText(gridControl, "ccm02tipdocidentidad");
                lbltipdoc.Text = Util.GetCurrentCellText(gridControl, "TipDocDesc");
                txtemailguia.Text = Util.GetCurrentCellText(gridControl, "ccm02correo");
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
                        limpiarCajasDomicilio();
                        OnCargarDomicilio();
                        OnCargarRegistroDomicilio();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion
   


      
        #region "Domicilio x destinario"

         string EstadoOperacionDomicilio="V";
        void habilitoBotonesDomicilio(bool valor)
        {
            btnNuevo.Enabled = valor;
            btnEditar.Enabled = valor;
            btnEliminar.Enabled = valor;
        }

        void habilitoCajasDomicilio(bool valor)
        {
            txtdomiclioCod.Enabled = valor;
            txtdomicilioDir.Enabled = valor;
            txtdomicilioDes.Enabled = valor;
            txtAyudaDpto.Enabled = valor;
            txtAyudaProv.Enabled = valor;
            txtAyudaDist.Enabled = valor;
            chkDomicilio.Enabled = valor;
            txtAyudaPuerto.Enabled = valor;
        }


       

        private void deshabilitaDomicilio() {
            btnNuevo.Enabled = false; btnEditar.Enabled = false;
            btnEliminar.Enabled = false; btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        
        private bool ValidarDomicilio() {
            if (string.IsNullOrEmpty(txtdomiclioCod.Text.Trim())) {
                MessageBox.Show("Ingresar codigo de  domicilio.");
                txtdomiclioCod.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtdomicilioDes.Text.Trim())) {
                txtdomicilioDes.Focus();
                MessageBox.Show("Ingresar descripcion de domicilio.");
                return false;
            }
           
            return true;
        }
       
       private void mostrarXocultaBtnDomicilio(bool valor) {            
            btnNuevo.Visibility= valor == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnEditar.Visibility = valor == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnEliminar.Visibility = valor == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnGuardar.Visibility = valor == true ? ElementVisibility.Collapsed : ElementVisibility.Visible;
            btnCancelar.Visibility = valor == true ? ElementVisibility.Collapsed : ElementVisibility.Visible;
           
        }

       private void limpiarCajasDomicilio() {                                    
            txtdomiclioCod.Text = "";
            txtdomicilioDir.Text = "";
            txtdomicilioDes.Text = "";
            txtAyudaDpto.Text = "";
            txtAyudaProv.Text = "";
            txtAyudaDist.Text = "";
            txtAyudaPuerto.Text = "";
            txtPuerto.Text = "";
            chkDomicilio.Checked = false;

            txtProv.Text = "";
            txtDpto.Text = "";
            txtDist.Text = "";
            txtPuerto.Text = "";
            //txtemailguia.Text = "";
     
        }

        private void crearColumnaDomicilio() { 
            RadGridView dgv = CreateGridVista(this.gridDomicilios);
            CreateGridColumn(dgv,"Codigo","come05sedeclientescod",0,"",70);
            CreateGridColumn(dgv,"Nombre","come05sedeclientesdesc",0,"",150);
            CreateGridColumn(dgv,"Direccion","come05sedeclientesdireccion",0,"",120);

            CreateGridColumn(dgv, "come05DepCod", "come05DepCod", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "come05ProvCod", "come05ProvCod", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "come05DistCod", "come05DistCod", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "come05FlagDimiFiscal", "come05FlagDimiFiscal", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "come05PuertoCod", "come05PuertoCod", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "DptoDescripcion", "DptoDescripcion", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "ProvDescripcion", "ProvDescripcion", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "DistDescripcion", "DistDescripcion", 0, "", 120, true, false, false);
            CreateGridColumn(dgv, "PuertoDescripcion", "PuertoDescripcion", 0, "", 120, true, false, false);
           
        }

        private void OnCargarDomicilio() {
            var lista = SedeLogic.Instance.TraeDireccionDestinatario(Logueo.CodigoEmpresa, Logueo.TipoAnalisisDestinatario, txtruc.Text);
            gridDomicilios.DataSource = lista;            
        }

        private void OnCargarRegistroDomicilio() {
            if (gridDomicilios.RowCount > 0) { 
                GridViewRowInfo fila = gridDomicilios.CurrentRow;
                txtdomiclioCod.Text = fila.Cells["come05sedeclientescod"].Value == null ? "" : fila.Cells["come05sedeclientescod"].Value.ToString();
                txtdomicilioDes.Text = fila.Cells["come05sedeclientesdesc"].Value == null ? "" : fila.Cells["come05sedeclientesdesc"].Value.ToString();
                txtdomicilioDir.Text = fila.Cells["come05sedeclientesdireccion"].Value == null ? "" : fila.Cells["come05sedeclientesdireccion"].Value.ToString();
                txtAyudaDpto.Text = fila.Cells["come05DepCod"].Value == null ? "" : fila.Cells["come05DepCod"].Value.ToString();
                txtAyudaProv.Text = fila.Cells["come05ProvCod"].Value == null ? "" : fila.Cells["come05ProvCod"].Value.ToString();
                txtAyudaDist.Text = fila.Cells["come05DistCod"].Value == null ? "" : fila.Cells["come05DistCod"].Value.ToString();
                //chkDomicilio.Checked = fila.Cells["come05FlagDimiFiscal"].Value == "1" ? chkDomicilio.Checked = true : fila.Cells["come05FlagDimiFiscal"].Value.ToString();
                string checkedfiscal = fila.Cells["come05FlagDimiFiscal"].Value.ToString();
                if (checkedfiscal == "1")
                {
                    chkDomicilio.Checked = true;
                }
                else 
                {
                    chkDomicilio.Checked = false;
                }
                txtAyudaPuerto.Text = fila.Cells["come05PuertoCod"].Value == null ? "" : fila.Cells["come05PuertoCod"].Value.ToString();
                txtDpto.Text = fila.Cells["DptoDescripcion"].Value == null ? "" : fila.Cells["DptoDescripcion"].Value.ToString();
                txtProv.Text = fila.Cells["ProvDescripcion"].Value == null ? "" : fila.Cells["ProvDescripcion"].Value.ToString();
                txtDist.Text = fila.Cells["DistDescripcion"].Value == null ? "" : fila.Cells["DistDescripcion"].Value.ToString();
                txtPuerto.Text = fila.Cells["PuertoDescripcion"].Value == null ? "" : fila.Cells["PuertoDescripcion"].Value.ToString();


                //string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Dpto, txtAyudaDpto);
                //txtDpto.Text = datos[1].ToString();
            }
        }

        private void OnLoadDomicilio() {
            crearColumnaDomicilio();
            OnCargarDomicilio();
            habilitoCajasDomicilio(false);
            mostrarXocultaBtnDomicilio(true);
        }

        void habilitaBotonesDestinario(bool valor) {
            cbbNuevo.Enabled = valor;
            cbbEditar.Enabled = valor;
            cbbEliminar.Enabled = valor;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtdomiclioCod.MaxLength = 4;
            try
            {
                mostrarXocultaBtnDomicilio(false);
                habilitoCajasDomicilio(true);
                limpiarCajasDomicilio();
                //chkDomicilio.Enabled = true;
                EstadoOperacionDomicilio = "N";
                //txtdomiclioCod.Enabled = false;
                //menu de formulario destinatario
                habilitaBotonesDestinario(false);

                string codigo = string.Empty;
                
                

                SedeLogic.Instance.Glo_SedeGeneraCodigo(Logueo.CodigoEmpresa, Logueo.TipoAnalisisDestinatario, txtruc.Text, out codigo);
                txtdomiclioCod.Text = codigo;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al iniciar nuevo registro: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtdomiclioCod.MaxLength = 4;
            if (gridDomicilios.Rows.Count == 0 || gridDomicilios.SelectedRows.Count == 0)
                return;
            mostrarXocultaBtnDomicilio(false);
            txtdomicilioDir.Enabled = true;
            txtdomicilioDes.Enabled = true;
            EstadoOperacionDomicilio = "E";
            habilitoCajasDomicilio(true);
            habilitaBotonesDestinario(false);

            txtdomiclioCod.Enabled = false;
            //radCommandBar1.CommandBarElement.Rows[0].Strips[0].Enabled = false;
            
        }
        void cargarEntidadSede() {
            sede.come05empresa = Logueo.CodigoEmpresa;
            sede.come05clientetipana = Logueo.TipoAnalisisDestinatario;
            sede.come05clientecod = txtruc.Text.Trim();
            sede.come05sedeclientescod = txtdomiclioCod.Text.Trim();
            sede.come05sedeclientesdesc = txtdomicilioDes.Text.Trim();
            sede.come05sedeclientesdireccion = txtdomicilioDir.Text.Trim();
            
            //HARCODEADO
           sede.come05sedeclientesreferencia = "";
            //COME05 AGREGADOS
            
            sede.come05DepCod = txtAyudaDpto.Text.Trim();
            sede.come05ProvCod = txtAyudaProv.Text.Trim();
            sede.come05DistCod = txtAyudaDist.Text.Trim();
            if(chkDomicilio.Checked == true){
                sede.come05FlagDimiFiscal = "1";
           }
            else
            {
                sede.come05FlagDimiFiscal = "0";
            }
            sede.come05PuertoCod = txtAyudaPuerto.Text.Trim();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (gridDomicilios.Rows.Count == 0 || gridControl.SelectedRows.Count == 0)
                    return;

                cargarEntidadSede();

                string msj = string.Empty;
                DialogResult res = MessageBox.Show("Desea eliminar el registro", "Sistema", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    SedeLogic.Instance.Glo_EliminarSede(sede, out msj);
                    MessageBox.Show(msj);

                }
                //MessageBox.Show(msj);

                mostrarXocultaBtnDomicilio(true);
                EstadoOperacionDomicilio = "V";
                limpiarCajasDomicilio();
                OnCargarDomicilio();
                OnCargarRegistroDomicilio();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error eliminar : " + ex.Message);
            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //CuentaCorriente cuenta = new CuentaCorriente();
            if (!ValidarDomicilio())
                return;

            cargarEntidadSede();
            string msj = string.Empty;
            int flag = 0;
            if ( EstadoOperacionDomicilio=="N")
            {
                SedeLogic.Instance.Glo_InsertarSede(sede, out flag,out msj);
                
            }
            else if (EstadoOperacionDomicilio == "E")
            {
                    SedeLogic.Instance.Glo_ActualizarSede(sede, out flag,out msj);
            }
           
            if(flag != 1)
            {
                Util.ShowError(msj);
                return;
            }
            Util.ShowMessage(msj,flag);
            mostrarXocultaBtnDomicilio(true);
            //habilitaDomicilio(false);
            habilitoCajasDomicilio(false);
            OnCargarDomicilio();
            OnCargarRegistroDomicilio();
            habilitaBotonesDestinario(true);            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mostrarXocultaBtnDomicilio(true);
            habilitoCajasDomicilio(false);
            
            OnCargarRegistroDomicilio();
             EstadoOperacionDomicilio="V";
            
            habilitaBotonesDestinario(true);
            //radCommandBar1.Enabled = true;
        }

        private void gridDomicilios_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!isLoaded) return;
            if (txtdomicilioDes.Enabled == true) return;
            if (e.CurrentRow.Cells[0].Value != null) {
                txtdomiclioCod.Text = e.CurrentRow.Cells["come05sedeclientescod"].Value == null ? "" : e.CurrentRow.Cells["come05sedeclientescod"].Value.ToString();
                  txtdomicilioDes.Text = e.CurrentRow.Cells["come05sedeclientesdesc"].Value == null ? "" : e.CurrentRow.Cells["come05sedeclientesdesc"].Value.ToString();
                  txtdomicilioDir.Text = e.CurrentRow.Cells["come05sedeclientesdireccion"].Value == null ? "" : e.CurrentRow.Cells["come05sedeclientesdireccion"].Value.ToString();
                  txtAyudaDpto.Text = e.CurrentRow.Cells["come05DepCod"].Value == null ? "" : e.CurrentRow.Cells["come05DepCod"].Value.ToString();
                  txtAyudaProv.Text = e.CurrentRow.Cells["come05ProvCod"].Value == null ? "" : e.CurrentRow.Cells["come05ProvCod"].Value.ToString();
                  txtAyudaDist.Text = e.CurrentRow.Cells["come05DistCod"].Value == null ? "" : e.CurrentRow.Cells["come05DistCod"].Value.ToString();
                  txtAyudaPuerto.Text = e.CurrentRow.Cells["come05PuertoCod"].Value == null ? "" : e.CurrentRow.Cells["come05PuertoCod"].Value.ToString();
                  string checkFiscal = e.CurrentRow.Cells["come05FlagDimiFiscal"].Value == null ? "" : e.CurrentRow.Cells["come05FlagDimiFiscal"].Value.ToString();
                  txtDpto.Text = e.CurrentRow.Cells["DptoDescripcion"].Value == null ? "" : e.CurrentRow.Cells["DptoDescripcion"].Value.ToString();
                  txtProv.Text = e.CurrentRow.Cells["ProvDescripcion"].Value == null ? "" : e.CurrentRow.Cells["ProvDescripcion"].Value.ToString();
                  txtDist.Text = e.CurrentRow.Cells["DistDescripcion"].Value == null ? "" : e.CurrentRow.Cells["DistDescripcion"].Value.ToString();
                  txtPuerto.Text = e.CurrentRow.Cells["PuertoDescripcion"].Value == null ? "" : e.CurrentRow.Cells["PuertoDescripcion"].Value.ToString();
                if (checkFiscal == "1")
                  {
                      chkDomicilio.Checked = true;
                  }
                  else
                  {
                      chkDomicilio.Checked = false;
                  }

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
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda: " + ex.Message);
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

        private void txtAyudaDpto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                
                string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Dpto, "");
                if (datos == null) return;
                //txttipdoc.Text = datos[0];
                //lbltipdoc.Text = datos[1];
                txtAyudaDpto.Text = datos[0];
                txtDpto.Text = datos[1];
                
            }
        }

        private void txtAyudaProv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                string ayudadpto = txtAyudaDpto.Text;
                string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Prov, ayudadpto);
                if (datos == null) return;
                txtAyudaProv.Text = datos[0];
                txtProv.Text = datos[1];
            }
        }

        private void txtAyudaDist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                string ayudaprov = txtAyudaProv.Text;
                string ayudaDepto = txtAyudaDpto.Text;
                
                string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmCliente_Dist, ayudaDepto.Trim() + "|" + ayudaprov.Trim());
                if (datos == null) return;
                txtAyudaDist.Text = datos[0];
                txtDist.Text = datos[1];
            }
        }

        private void txtAyudaPuerto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {

                string[] datos = TraerRespuestaDeAyuda(enmAyuda.enmFactCab_ExpPuertoEmbarqueDes, "");
                if (datos == null) return;
                txtAyudaPuerto.Text = datos[0];
                txtPuerto.Text = datos[1];
            }
        }

        private void ResaltarCajasAyuda()
        {
            Util.ResaltarAyuda(txtAyudaDpto);
            Util.ResaltarAyuda(txtAyudaProv);
            Util.ResaltarAyuda(txtAyudaDist);
            Util.ResaltarAyuda(txtAyudaPuerto);
        }
      

    }
}
