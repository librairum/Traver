using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using CrystalDecisions.Shared;
namespace Fac.UI.Win
{
    public partial class frmfacturacab : frmBaseReg
    {
        internal string tipoDocumento = "";
        private string InsertaroActualizarDetalle = ""; // N=Nuevo,M=Modificar,""=Ninguna Operacion
        int ultimacolumnavisibledelagrilla=0;
       
        DocumentoLogic datosDoc = DocumentoLogic.Instance;
      
        
        // == VARIABLES DE GENERAR FACTURA DESDE GUIA DE TRANSPORTE
        // == Declaracion de variables de cliente : codigo, descripcion,
        internal string ClienteCod = "", ClienteDesc = "", ClienteRuc = "";
        internal string[] GuiasSeleccionados = new string [1000];
        
        Fac_GuiaTransporteLogic LogicaGuia = Fac_GuiaTransporteLogic.Instance;
        DocumentoLogic LogicaDocumento = DocumentoLogic.Instance;
        // == VARIABLES DE FACTURA CABECERA
        // == Esta variable es activado cuando el usuario agregar 
        // == detalle de una guia a la guai de la factura.
        private bool EsModoGuiaTransporte = false;
        

        // == INSTANCIA
        
        // == Instancia para Listado de Factura
        #region "Instancia desde Listado de factura"
        private static frmfacturacab _aForm;
        private frmFacturas FrmParent { get; set; }
        
        public static frmfacturacab Instance(frmFacturas padre)
        {
            if (_aForm != null) return new frmfacturacab(padre);
            _aForm = new frmfacturacab(padre);
            return _aForm;
        }
        #endregion

        // == Instancia para Generar Factura desde Guia.
        #region "Instancia desde Generar Factura"
        private static frmfacturacab _aFormFacturaxGuia;
        private frmGenerarFacturaxGuia FrmParentFacturaxGuia { get; set; }
        public static frmfacturacab Instance(frmGenerarFacturaxGuia padre)
        {
            if (_aFormFacturaxGuia != null) return new frmfacturacab(padre);
            _aFormFacturaxGuia = new frmfacturacab(padre);
            return _aFormFacturaxGuia;
        }
        #endregion

        #region "Seguridad"
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
          cancelar_a, expmovi_a;
        private void ComportarmientoBotones(string accion)
        {
            OcultarBotones();
            //leer variables boolean de frmListaDocumentos
            this.nuevo_a = FrmParent.nuevo_a;
            this.editar_a = FrmParent.editar_a;
            this.eliminar_a = FrmParent.eliminar_a;
            this.ver_a = FrmParent.ver_a;
            this.imprimir_a = FrmParent.imprimir_a;
            this.refrescar_a = FrmParent.refrescar_a;
            this.importar_a = FrmParent.importar_a;
            this.vista_a = FrmParent.vista_a;
            this.guardar_a = FrmParent.guardar_a;
            this.cancelar_a = FrmParent.cancelar_a;
            this.expmovi_a = FrmParent.expmovi_a;
            switch (accion)
            {
                case "cargar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }                                        
                    break;

                case "nuevo":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "editar":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "grabar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    break;

                case "cancelar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    break;

                case "ver":
                    //if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    //if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    //if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    if (ver_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVer); }
                    if (vista_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia); }
                    //if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    
                    break;
            }

        }
        #endregion

        // == CONSTRUCTOR
        public frmfacturacab(frmGenerarFacturaxGuia padre)
        { 
            InitializeComponent();
            FrmParentFacturaxGuia = padre;
            TipoOrigen = OrigenInstancia.Externo1;
            AgregarEventos();

            
            // ================================================ Asignar configueracion de navegacion . ======================================================   
            Util.ConfigGridToEnterNavigation(gridControlDetalle);

            // ================================================ Enfocar todo al fila de la grilla. ==========================================================        
            SeleccionarFilaCompleta(gridControlDetalle);
            OcultarCopiarDoc();
            CargarPeriodos();
            OcultarDarBaja();

            // == Asignar valor de plantilla por defecto.            
            CrearColumnas();
            CrearColumnasCuotas();
            txtcodplantilla.Text = "02";

            // == Asignar valor de modo guia de transporte
            EsModoGuiaTransporte = true;

            // == Modificar image de botones 
        }          
        public frmfacturacab(frmFacturas padre)
        {
            InitializeComponent();
            FrmParent = padre;
            TipoOrigen = OrigenInstancia.Principal;
            AgregarEventos();
            // ================================================ Asignar configueracion de navegacion . ======================================================                        
            Util.ConfigGridToEnterNavigation(gridControlDetalle);

            // ================================================ Enfocar todo al fila de la grilla. ==========================================================        
            SeleccionarFilaCompleta(gridControlDetalle);
            OcultarCopiarDoc();
            CargarPeriodos();
            OcultarDarBaja();
           
            // == Asignar valor por defecta en codigo de plantilla            
            CrearColumnas();
            CrearColumnasCuotas();

            //gridControlDetalle.KeyDown -= new KeyEventHandler(gridControlDetalle_KeyDown);
        }
       
        private void AgregarEventos()
        {
            txtcodplantilla.TextChanged += new EventHandler(txtcodplantilla_TextChanged);
            #region"Eventos keydown"
          
            #endregion
            #region "Eventos click"
            btnGuardarCopia.Click += new EventHandler(btnGuardarCopia_Click);
            btnCancelarCopia.Click += new EventHandler(btnCancelarCopia_Click);
            btnGuardarBaja.Click += new EventHandler(btnGuardarBaja_Click);
            btnCancelarBaja.Click += new EventHandler(btnCancelarBaja_Click);
            btnEditar.Click += new EventHandler(btnEditar_Click);
            #endregion
        }
        private int CantidadProductoRelacionado = 0;
        void TxtCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                string codigo = TxtCliente.Text.Trim();
                string tipoAnalisis = txttipanalisis.Text.Trim();
                CuentaCorriente cliente = CuentaCorrienteLogic.Instance.CuentaCorrienteTraerRegistro(Logueo.CodigoEmpresa, tipoAnalisis, codigo );
               
                if (cliente != null)
                {
                    txtRazon.Text = cliente.ccm02nom.Trim();
                    TxtRuc.Text = cliente.ccm02ruc.Trim();
                    txtDireccion.Text = cliente.ccm02dir.Trim();
                }
                else {
                    txtRazon.Text = ""; 
                    TxtRuc.Text = "";
                    txtDireccion.Text = "";
                }

                
                bool verColumna = false;
                ArticuloClienteLogic.Instance.TraeFlagProductoCliente(Logueo.CodigoEmpresa, TxtCliente.Text.Trim(), out CantidadProductoRelacionado);
                //Si cliente no tiene productos relacionado a deisi
                verColumna = CantidadProductoRelacionado == 0 ? false : true; 
                
                this.gridControlDetalle.Columns["FAC05CODPROD_PROV"].IsVisible = verColumna;
                this.gridControlDetalle.Columns["FAC05DESPROD_PROV"].IsVisible = verColumna;
                this.gridControlDetalle.Columns["FAC05UNIMED_PROV"].IsVisible = verColumna;                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer descripcion de cliente : " + ex.Message);
            }
        }

        void txtcodtienda_Leave(object sender, EventArgs e)
        {
            try
            {
                string descripcion = "";
                GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txtcodtienda.Text, "PUNTOVENTA", out descripcion);                
                LblHelp4.Text = descripcion;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer descripcion de tienda: " + ex.Message);
            }
        }
        
        #region "Desarrollo de eventos"
        void txtcodplantilla_TextChanged(object sender, EventArgs e)
        {
            if (txtcodplantilla.Text.Trim() != "")
            {
                VerColumnasPorPlantilla(txtcodplantilla.Text.Trim());
            }
        }

        void btnEditar_Click(object sender, EventArgs e)
        {

            //if (ValidarCabeceraFacturaEstaGrabado() == false) return;
            if (this.gridControlDetalle.Rows.Count == 0)
            {
                Util.ShowAlert("Debe ingresar registro al detalle");
                return;
            }
            // Estado de detalle es modificar
            InsertaroActualizarDetalle = "M";

            //EsModoGuiaTransporte = true;
            HabilitarEdicionDelDetalle();
            OcultarBotones();
            DesactivaTodoBootonesCabDetalle();
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            
            Util.ResaltarAyuda(gridControlDetalle, "FAC05CODPROD");
        }


        void txtExpNroprecinto_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void txtExpContainer_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void txtExpAccountNumber_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void txtExpBankCode_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void txtExpLC_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void txtExpCD_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void txtExpConEmbarque_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void dtpFechaDoc_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }


        void txtguias_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }
        #endregion
        void HabilitarEdicionDelDetalle()
        {
            foreach (GridViewRowInfo row in gridControlDetalle.Rows)
            {
                Util.SetValueCurrentCellText(row, "flag", "1");
            }
        }
        
        #region "Copiar Documento"
        private void CargarPeriodos()
        {
            try
            {
                var periodo = PeriodoLogic.Instance.PeriodoTraerTodos(Logueo.CodigoEmpresa);
                cboCopiarPeriodo.DataSource = periodo;
                cboCopiarPeriodo.DisplayMember = "ccb03des";
                cboCopiarPeriodo.ValueMember = "ccb03cod";


                string anio = "";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();

                cboCopiarPeriodo.SelectedValue = anio + mes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void OcultarCopiarDoc()
        {
            gpxCopiar.Hide();
            gpxCopiar.SendToBack();
            txtCopiarSerie.Text = ""; txtCopiarDocNro.Text = "";
            dtpCopiarFecha.Value = DateTime.Now;
        }
        private void MostarCopiarDoc()
        {
            try
            {
                string str_nroDocumento = "";

                gpxCopiar.Show();
                gpxCopiar.BringToFront();
                txtCopiarSerie.Text = txtserie.Text.Trim();

                GlobalLogic.Instance.DameNroDocumento(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(),
                    txtCopiarSerie.Text.Trim(), out str_nroDocumento);

                //txtNumeroDocumento.Text = str_nroDocumento;
                txtCopiarDocNro.Text = str_nroDocumento;
                //Copiar fecha
                if (dtpFechaDoc.Text == "")
                {
                    dtpFechaDoc.Text = "";
                }
                else { dtpFechaDoc.Value = dtpFechaDoc.Value; }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }

        }
        void btnGuardarCopia_Click(object sender, EventArgs e)
        {
            string MesdocCopiar, facturaorigenNro, str_mensaje;
            int int_flag = 0;
            MesdocCopiar = ""; facturaorigenNro = ""; str_mensaje = "";
            try
            {
                // validaciones que la fecha pertenesca al periodo.
                MesdocCopiar = cboCopiarPeriodo.SelectedValue.ToString();
                facturaorigenNro = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();
                
                if (Validar_fecha_vs_periodo(dtpCopiarFecha.Value, MesdocCopiar) == true)
                {
                    return;
                }

                if (txtCopiarDocNro.Text.Trim() == "")
                {
                    Util.ShowAlert("Ingrese Nro Factura"); return;
                }
                if (dtpCopiarFecha.Text == "")
                {
                    Util.ShowAlert("Fecha no Valida"); return;
                }
                if (txtCopiarSerie.Text == "")
                {
                    Util.ShowAlert("Ingrese serie"); return;
                }
                if (txtsubplantilla.Text == "")
                {
                    Util.ShowAlert("Ingrese tipo de factura");
                }
                // Asigno el procedimiento para guardar la copia
                DocumentoLogic.Instance.CopiarFactura(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(),
                    txtCopiarSerie.Text.Trim(), txtCopiarDocNro.Text.Trim(), facturaorigenNro,
                    Logueo.Anio, MesdocCopiar.Substring(4, 2), dtpCopiarFecha.Text, out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);
                
                //Refresco el Data Control y el Browse
                if (int_flag == 1)
                {
                    //Refrescar la grilla de documento de factuas
                    FrmParent.Cargar();
                    string nuevoNumeroDocumento = "";
                    nuevoNumeroDocumento = txtCopiarSerie.Text.Trim() + "-" + txtCopiarDocNro.Text.Trim();
                    Util.enfocarFila(FrmParent.gridControl, "FAC04NUMDOC", nuevoNumeroDocumento);

                    Estado = FormEstate.Edit;
                    IniciarFormularioSegunEstado(Estado);
                    OcultarCopiarDoc();

                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        void btnCancelarCopia_Click(object sender, EventArgs e)
        {
            OcultarCopiarDoc();
        }
        #endregion
        #region "Metodos cabecera"
        private void FocusNextControl(KeyEventArgs paramEvent)
        {
            if (paramEvent.KeyValue == (char)Keys.Enter || paramEvent.KeyValue == (char)Keys.Down)
                SendKeys.Send("{TAB}");
            else if (paramEvent.KeyValue == (char)Keys.Up)
                SendKeys.Send("+{TAB}");
        }
        void CargaDetalle()
        {
            try
            {
                if (FrmParent.gridControl.MasterView.Rows.Count > 0)
                {
                    string sDescripcion = "";
                    GridViewRowInfo row = FrmParent.gridControl.MasterView.CurrentRow;
                    
                    txttipdoc.Text = Util.GetCurrentCellText(row, "FAC01COD");
                    txtcodplantilla.Text = Util.GetCurrentCellText(row, "FAC02COD");

                    txtsubplantilla.Text = Util.GetCurrentCellText(row, "FAC03COD");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txttipdoc.Text + txtsubplantilla.Text.Trim(), "PLANTI", out sDescripcion);
                    LblHelp0.Text = sDescripcion;

                    txttipoarticulo.Text = Util.GetCurrentCellText(row, "FAC03TIPART");

                    txtNumeroDocumento.Text = Util.GetCurrentCellText(row, "FAC04NRODOC");
                    txtserie.Text = Util.GetCurrentCellText(row, "FAC04SERIEDOC");

                    txttipanalisis.Text = Util.GetCurrentCellText(row, "FAC04TIPANA");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txttipanalisis.Text.Trim(), "1003", out sDescripcion);
                    LblHelp1.Text = sDescripcion;

                    TxtCliente.Text = Util.GetCurrentCellText(row, "FAC04CODCLI");                    
                    txtDireccion.Text = Util.GetCurrentCellText(row, "FAC04CLIDIRECCION");
                    txtdonigv.Text = Util.GetCurrentCellText(row, "FAC04DONIGV");
                    txtdonsubtotal.Text = Util.GetCurrentCellText(row, "FAC04DONSUBTOTAL");
                    txtdontotal.Text = Util.GetCurrentCellText(row, "FAC04DONTOTAL");
                    txtRazon.Text = Util.GetCurrentCellText(row, "FAC04CLINOMBRE");
                    TxtObservacion.Text = Util.GetCurrentCellText(row, "FAC04GLOSA");
                    TxtRuc.Text = Util.GetCurrentCellText(row, "FAC04CLIRUC");

                    string sFlag = Util.GetCurrentCellText(row, "FAC04DONGLAG");

                    chkdonacion.Checked = sFlag == "S" ? true : false;
                    
                    txtmoneda.Text = Util.GetCurrentCellText(row, "FAC04MONEDA");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(txtmoneda.Text, "MONEDAFAC", out sDescripcion);
                    LblHelp2.Text = sDescripcion;

                    
                    txtdetraccionCodServ.Text = Util.GetCurrentCellText(row, "FAC04FECODBIENOSERVDETRACCION");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(txtdetraccionCodServ.Text, "DETRACCION", out sDescripcion);
                    LblHelpDetraccion.Text = sDescripcion;

                    txtdetraccionPorcentaje.Text = Util.GetCurrentCellText(row, "FAC04FEPORCEDETRACCION");
                    txtdetraccionImporte.Text = string.Format("{0:###,###0.00}", Util.GetCurrentCellDbl(row, "FAC04FETOTALDETRACCION"));
                    

                    //string.Format("{0:yyyyMMdd}"

                    txtformapagosunat.Text = Util.GetCurrentCellText(row, "FAC04FORMAPAGOSUNAT");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA("61" + txtformapagosunat.Text.Trim(), "GLODESC", out sDescripcion);
                    LblhelpFormapagosunat.Text = sDescripcion;

                    txtcuotasnro.Text = Util.GetCurrentCellText(row, "FAC04FORMAPAGOSUNATCUOTAS");
                    txtcuotadias.Text = Util.GetCurrentCellText(row, "FAC04FORMAPAGOSUNATDIAS"); 
                    

                    txtcodtienda.Text = Util.GetCurrentCellText(row, "FAC04TIENDA");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa +  txtcodtienda.Text, "PUNTOVENTA", out sDescripcion);
                    LblHelp4.Text = sDescripcion;

                    txtcodvendedor.Text = Util.GetCurrentCellText(row, "FAC04VENDEDORCOD");
                    LblVendedorNombre.Text = Util.GetCurrentCellText(row, "FAC04VENDEDORNOMBRE");

                    txtTipoCambio.Text = Util.GetCurrentCellText(row, "FAC04TIPCAMBIO");
                    dtpFechaDoc.Text = Util.GetCurrentCellText(row, "FAC04FECHA");
                    dtpFechaDoc.Value = Convert.ToDateTime(Util.GetCurrentCellText(row, "FAC04FECHA")); 

                    txtIgvPercent.Text = Util.GetCurrentCellText(row, "FAC04IGV");
                                        
                    txtguias.Text = Util.GetCurrentCellText(row, "FAC04GUIAS");
                    
                    txttipoventa.Text = Util.GetCurrentCellText(row, "FAC04CODTIPOVENTA");
                    
                    ActivarDesactivarTab(txttipoventa.Text.Trim());

                    //====================================== 'DATOS DE EXPORTACION =========================================
                    // Condiciones de Embarque
                    txtExpConEmbarque.Text = Util.GetCurrentCellText(row, "FAC04EXPCONOEMBARQUE");

                    // Pais origen 
                    txtExpPaisOrigen.Text = Util.GetCurrentCellText(row, "FAC04EXPCODPAISORIGEN");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(txtExpPaisOrigen.Text.Trim(), "PAISES", out sDescripcion);
                    LblHelp5.Text = sDescripcion;
                    // Pais destino
                    txtExpPaisDestino.Text = Util.GetCurrentCellText(row, "FAC04EXPCODPAISDESTINO");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(txtExpPaisDestino.Text.Trim(), "PAISES", out sDescripcion);
                    LblHelp6.Text = sDescripcion;

                    // Condiciones de pago
                    txtExpCondPago.Text = Util.GetCurrentCellText(row, "FAC04EXPCODCONDPAGO");
                    LblHelp7.Text = Util.GetCurrentCellText(row, "ExpCondPagoDesc");

                    // Condiciones de despacho
                    txtExpConDespacho.Text = Util.GetCurrentCellText(row, "FAC04EXPCODCONDDESPACHO");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA("52" + txtExpConDespacho.Text.Trim(), "GLODESC", out sDescripcion);
                    LblHelp8.Text = sDescripcion;

                    // Puerto de embarque Carga
                    txtExpPuertoEmbarque.Text = Util.GetCurrentCellText(row, "FAC04EXPCODPUERTO");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(txtExpPuertoEmbarque.Text.Trim(), "PUERTOS", out sDescripcion);

                    // Descripcion Puerto de embarque Carga
                    LblHelp9.Text = sDescripcion;

                    // Puerto de Embarque Descarga
                    txtExpPuertoEmbarqueDes.Text = Util.GetCurrentCellText(row, "FAC04EXPCODPUERTODES");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(txtExpPuertoEmbarqueDes.Text.Trim(), "PUERTOS", out sDescripcion);

                    // Descripcion Puerto de Embarque Descarga
                    LblHelp12.Text = sDescripcion;

                    // Banco 
                    txtExpBancoLocal.Text = Util.GetCurrentCellText(row, "FAC04EXPCODBCOLOCAL");
                    sDescripcion = "";
                    GlobalLogic.Instance.DameDescripcionFA(txtExpBancoLocal.Text.Trim(), "BANCOS", out sDescripcion);
                    LblHelp10.Text = sDescripcion;

                    txtExpCD.Text = Util.GetCurrentCellText(row, "FAC04EXPCDDOCCRED");
                    txtExpLC.Text = Util.GetCurrentCellText(row, "FAC04EXPLCEMITIDA");
                    txtExpBankCode.Text = Util.GetCurrentCellText(row, "FAC04EXPBANKCODE");
                    txtExpAccountNumber.Text = Util.GetCurrentCellText(row, "FAC04EXPNUMCUENTA");
                    txtExpContainer.Text = Util.GetCurrentCellText(row, "FAC04EXPNROCONTAINER");
                    txtExpNroprecinto.Text = Util.GetCurrentCellText(row, "FAC04EXPNROPRECINTO");
                    if (Util.GetCurrentCellText(row, "FAC04FECORDCOMPRA") == "")
                    { dtpFechaOrdCom.SetToNullValue(); }
                    else { dtpFechaOrdCom.Text = Util.GetCurrentCellText(row, "FAC04FECORDCOMPRA"); }
                    //dtpFechaOrdCom.Text = Util.GetCurrentCellText(row, "FAC04FECORDCOMPRA");

                    

                    //'Otros Datos
                    txtordcompra.Text = Util.GetCurrentCellText(row, "FAC04ORDENCOMPRA");
                    txtliquidacionnro.Text = Util.GetCurrentCellText(row, "FAC04LIQUIDACIONNRO");

                    if (Util.GetCurrentCellText(row, "FAC04ESTADODEPROCESO") == "D")
                    {
                        rbProcesoDraft.CheckState = CheckState.Checked;
                    }
                    else if (Util.GetCurrentCellText(row, "FAC04ESTADODEPROCESO") == "L")
                    {
                        rbProcesoLimpio.CheckState = CheckState.Checked;
                    }
                    else if (Util.GetCurrentCellText(row, "FAC04ESTADODEPROCESO") == "")
                    {
                        rbProcesoDraft.CheckState = CheckState.Unchecked;
                        rbProcesoLimpio.CheckState = CheckState.Unchecked;
                    }
                   
                    txtTipoOperacionFE.Text = Util.GetCurrentCellText(row, "FAC04FETIPODEOPERACION");
                    txtCodigoAnexoEmisorFE.Text = Util.GetCurrentCellText(row, "FAC04FECODIGOANEXOEMISOR");

                    
        

                    //Ocultar columasn de producto client esi esta no tiene productos relaciona deisi.
                    bool verColumna = false;
                    ArticuloClienteLogic.Instance.TraeFlagProductoCliente(Logueo.CodigoEmpresa, TxtCliente.Text.Trim(), out CantidadProductoRelacionado);
                    //Si cliente no tiene productos relacionado a deisi
                    verColumna = CantidadProductoRelacionado == 0 ? false : true;

                    this.gridControlDetalle.Columns["FAC05CODPROD_PROV"].IsVisible = verColumna;
                    this.gridControlDetalle.Columns["FAC05DESPROD_PROV"].IsVisible = verColumna;
                    this.gridControlDetalle.Columns["FAC05UNIMED_PROV"].IsVisible = verColumna; 


                    traesubdetalle();
                    traeCuotasFactura();

                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        void ActivaModoVer()
        {
            // Método para ver solo el contenido de los formularios
            #region "cabecera de documento"
            txtsubplantilla.Enabled = false;
            txttipanalisis.Enabled = false;
            TxtCliente.Enabled = false;

            txtNumeroDocumento.Enabled = false;
            txtserie.Enabled = false;
            txtDireccion.Enabled = false;
            txtdonigv.Enabled = false;
            txtdonsubtotal.Enabled = false;
            txtsubplantilla.Enabled = false;
            txtRazon.Enabled = false;
            TxtObservacion.Enabled = false;
            TxtRuc.Enabled = false;
            chkdonacion.Enabled = false;
            txtmoneda.Enabled = false;
            txtdetraccionCodServ.Enabled = false;
            txtdetraccionPorcentaje.Enabled = false;
            txtdetraccionImporte.Enabled = false;
            txtcodtienda.Enabled = false;
            txtcodvendedor.Enabled = false;
            txtTipoCambio.Enabled = false;
            gridControlDetalle.Visible = true;
            dtpFechaDoc.Enabled = false;
            txtguias.Enabled = false;
            #endregion
            //Datos de exportacion
            #region "Datos de exportacion"
            txtExpConEmbarque.Enabled = false;
            txtExpPaisOrigen.Enabled = false;
            txtExpPaisDestino.Enabled = false;
            txtExpCondPago.Enabled = false;
            txtExpConDespacho.Enabled = false;
            txtExpPuertoEmbarque.Enabled = false;
            txtExpPuertoEmbarqueDes.Enabled = false;
            txtExpBancoLocal.Enabled = false;
            txtExpCD.Enabled = false;
            txtExpLC.Enabled = false;
            txtExpBankCode.Enabled = false;
            txtExpAccountNumber.Enabled = false;
            txtExpContainer.Enabled = false;
            txtExpNroprecinto.Enabled = false;
            #endregion
            //Otros datos
            #region "otros datos"
            txtordcompra.Enabled = false;
            txtliquidacionnro.Enabled = false;
            dtpFechaOrdCom.Enabled = false;
            txttipoventa.Enabled = false;

            rbProcesoDraft.Enabled = false;
            rbProcesoLimpio.Enabled = false;

            txtformapagosunat.Enabled = false;
            gbpagocredito.Enabled = false;
            #endregion
           ResaltarControlesAyuda(false);
            
        }
        void EditarControles()
        {
            #region "cabecera de documento"
            txtsubplantilla.Enabled = false;
            txtserie.Enabled = false;
            txtNumeroDocumento.Enabled = false;
            txttipanalisis.Enabled = true;
            TxtCliente.Enabled = true;
            txtDireccion.Enabled = false;
            txtRazon.Enabled = false;
            TxtRuc.Enabled = false;

            txtdonigv.Enabled = true;
            txtdonsubtotal.Enabled = true;
            txtdontotal.Enabled = true;
            TxtObservacion.Enabled = true;
            chkdonacion.Enabled = true;
            txtmoneda.Enabled = true;
            txtdetraccionCodServ.Enabled = true;
            txtdetraccionPorcentaje.Enabled = true;
            txtdetraccionImporte.Enabled = true;
            txtcodtienda.Enabled = true;
            txtcodvendedor.Enabled = true;
            txtTipoCambio.Enabled = false;
            dtpFechaDoc.Enabled = true;
            txtguias.Enabled = true;
            #endregion
            //'Datos de Exportacion
            #region "datos de exportacion"
            txtExpConEmbarque.Enabled = true;
            txtExpPaisOrigen.Enabled = true;
            txtExpPaisDestino.Enabled = true;
            txtExpCondPago.Enabled = true;
            txtExpConDespacho.Enabled = true;
            txtExpPuertoEmbarque.Enabled = true;
            txtExpPuertoEmbarqueDes.Enabled = true;
            txtExpBancoLocal.Enabled = true;
            txtExpCD.Enabled = true;
            txtExpLC.Enabled = true;
            txtExpBankCode.Enabled = true;
            txtExpAccountNumber.Enabled = true;
            txtExpContainer.Enabled = true;
            txtExpNroprecinto.Enabled = true;
            #endregion
            //'Otros Datos
            #region "Otros datos"
            txtordcompra.Enabled = true;
            txtliquidacionnro.Enabled = true;

            txtformapagosunat.Enabled = true;
            if (txtformapagosunat.Text=="02")
                {
                    gbpagocredito.Enabled = true; // Solo se habilita cuando es credito
                }
            else
            {
                gbpagocredito.Enabled = false; // Solo se habilita cuando es credito
            }

            dtpFechaOrdCom.Enabled = true;
            txttipoventa.Enabled = true;
            rbProcesoDraft.Enabled = true;
            rbProcesoLimpio.Enabled = true;
            #endregion
        }
        void Iniciacontroles()
        {
            string sDescripcion = "";
            rpvFactura.SelectedPage = pvGenerales;
            pvExportacion.Enabled = false;
            TxtCliente.Text = "";

            // tipo de analissi
            txttipanalisis.Text = "01";
            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txttipanalisis.Text.Trim(), "1003", out sDescripcion);
            LblHelp1.Text = sDescripcion;


            txtDireccion.Text = "";
            txtdonigv.Text = "0.18";
            txtdonsubtotal.Text = "0.00";
            txtdontotal.Text = "0.00";
            txtNumeroDocumento.Text = "";
            txtserie.Text = "";
            txtsubplantilla.Text = "";
            LblHelp0.Text = "";
            txtRazon.Text = "";
            TxtObservacion.Text = "";
            TxtRuc.Text = "";
            chkdonacion.Checked = false;
            txtmoneda.Text = "";
            txtdetraccionCodServ.Text = "";
            txtdetraccionPorcentaje.Text = "0";
            txtdetraccionImporte.Text = "0";
            txtformapagosunat.Text = "";
            txtcodtienda.Text = "";
            txtcodvendedor.Text = "";
            LblVendedorNombre.Text = "";
            LblHelp4.Text = "";
            LblHelp2.Text = "";
            txtTipoCambio.Text = "1.000";
            txtIgvPercent.Text = "0";
            txttipdoc.Text = "";
            txtcodplantilla.Text = "";
            txttipoarticulo.Text = "";
            //txtTotal.Text = "0.00";
            //txtBruto.Text = "0.00";
            //txtPesobruto.Text = "0.00";
            //txtPesoAduana.Text = "0.00";
            txtguias.Text = "";
            dtpFechaDoc.Text = "";

            // Datos de exportacion
            txtExpConEmbarque.Text = "";
            // Pais origen
            txtExpPaisOrigen.Text = "PE";
            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPaisOrigen.Text.Trim(), "PAISES", out sDescripcion);
            LblHelp5.Text = sDescripcion;

            // Pais destino
            txtExpPaisDestino.Text = "";
            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPaisDestino.Text.Trim(), "PAISES", out sDescripcion);
            LblHelp6.Text = sDescripcion;

            // Condiciones de pago
            txtExpCondPago.Text = "";

            //Condiciones de despacho
            txtExpConDespacho.Text = "01";
            GlobalLogic.Instance.DameDescripcionFA("52" + txtExpConDespacho.Text.Trim(), "GLODESC", out sDescripcion);
            LblHelp8.Text = sDescripcion;


            //-- Puerto de embarque
            txtExpPuertoEmbarque.Text = "01";
            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPuertoEmbarque.Text.Trim(), "PUERTOS", out sDescripcion);
            LblHelp9.Text = sDescripcion;

            // Puerto de desembarque
            txtExpPuertoEmbarqueDes.Text = "01";
            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPuertoEmbarque.Text.Trim(), "PUERTOS", out sDescripcion);
            LblHelp12.Text = sDescripcion;


            txtExpBancoLocal.Text = "38";
            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpBancoLocal.Text.Trim(), "BANCOS", out sDescripcion);
            LblHelp10.Text = sDescripcion;

            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpBancoLocal.Text.Trim(), "1012", out sDescripcion);
            txtExpBankCode.Text = sDescripcion;

            sDescripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpBancoLocal.Text.Trim(), "1013", out sDescripcion);
            txtExpAccountNumber.Text = sDescripcion;

            //LblHelp(10).Caption = DameDescripcion(Trim(txtExpBancoLocal.Text), "1008") -- metodo pendiente para trabajar
            //txtExpBankCode.Text = DameDescripcion(Trim(txtExpBancoLocal.Text), "1012")-- metodo pendiente para trabajar
            //txtExpAccountNumber.Text = DameDescripcion(Trim(txtExpBancoLocal.Text), "1013")-- metodo pendiente para trabajar
            txtExpCD.Text = "";
            txtExpLC.Text = "";
            txtExpContainer.Text = "";
            txtExpNroprecinto.Text = "";
            rbProcesoDraft.IsChecked = true;
            rbProcesoLimpio.IsChecked = false;
            LblHelp6.Text = "";
            LblHelp7.Text = "";


            //LblHelp(11).Caption = ""

            //Otros
            txtordcompra.Text = "";
            txtliquidacionnro.Text = "";
            dtpFechaOrdCom.Text = "";
            txttipoventa.Text = "";

            // Iniciar los controles de fecha con fecha del dia.            
            dtpFechaDoc.SetToNullValue();
            dtpFechaOrdCom.SetToNullValue();
            // Fecha del sistema por defecto
            dtpFechaDoc.Value = DateTime.Now;

            //Traer tipo de cambio por defecto
            double TipoCambio;
            GlobalLogic.Instance.TipoCambioTraer(dtpFechaDoc.Text, out TipoCambio);
            txtTipoCambio.Text = TipoCambio.ToString();

            // Control de Ventan de Motivo de baja al documento
            dtpFechaBaja.Text = "";

            txtTipoOperacionFE.Text = "";
            txtCodigoAnexoEmisorFE.Text = "";

            
            txtformapagosunat.Text = "";
            txtcuotasnro.Text = "0";
            txtcuotadias.Text = "0";
        }

        void ActivarDesactivarTab(string tipoventa)
        {
            if (tipoventa == "01")
            {
                pvGenerales.Enabled = true;
                pvExportacion.Enabled = false;
                if (Estado == FormEstate.New)
                {
                    txtIgvPercent.Text = Util.convertiracadena(Logueo.Igv);
                }

                // Ocultar el panel Estado de proceso factura
                radLabel30.Visible = false;
                rpEstadoProceso.Visible = false;
                rbProcesoLimpio.CheckState = CheckState.Checked;

            }
            else if (tipoventa == "02")
            {
                pvGenerales.Enabled = true; pvExportacion.Enabled = true;

                if (Estado == FormEstate.New)
                {
                    txtIgvPercent.Text = "0";
                }

                // Mostrar el panel Estado de proceso factura
                radLabel30.Visible = true;
                rpEstadoProceso.Visible = true;
                rbProcesoDraft.CheckState = CheckState.Checked;

            }
            else
            {

                txtsubplantilla.Text = "";
                Util.ShowAlert("..:::ERROR DE CONFIGURACION:::.. Operacion No Valida, No se Especifico Si la Factura " +
                                "es nacional O Importada ; Asigne el valor en la configuracionde Sub Plantillas ");
                txttipoventa.Text = "";
            }
        }
        private bool ValidarCabecera()
        {
            string str_EstadoProceso;
            
            //'Establecer que si no se muestra la opcion estado de proceso la factura por defecto sea L = Limpio
            if (rpEstadoProceso.Visible == true) { 
                str_EstadoProceso = rbProcesoDraft.CheckState == CheckState.Checked ? "D" : "L"; }
            else { str_EstadoProceso = "L"; }

            if (dtpFechaDoc.Text == "") { 
                Util.ShowAlert("Seleccionar Fecha De Documento");
                this.rpvFactura.SelectedPage = pvGenerales;
                dtpFechaDoc.Focus();
                return false; }
            // Validar Forma de pago
            if (LblhelpFormapagosunat.Text == "" || LblhelpFormapagosunat.Text == "???")
            {
                Util.ShowAlert("Forma Pago Sunat No valido");
                txtformapagosunat.Focus();
                return false;
            }

            // Validaciones
            if (Validar_fecha_vs_periodo(dtpFechaDoc.Value, Logueo.periodo) == true) { return false; }
            
            if (txtNumeroDocumento.Text.Trim() == "") { 
                Util.ShowAlert("Ingrese Nro Factura");
                this.rpvFactura.SelectedPage = pvGenerales;
                txtNumeroDocumento.Focus(); 
                return false; }
            if (dtpFechaDoc.Text == "") { 
                Util.ShowAlert("Seleccionar fecha");
                this.rpvFactura.SelectedPage = pvGenerales;
                dtpFechaDoc.Focus(); return false; }
            if (txtserie.Text == "") { 
                Util.ShowAlert("Ingresar serie");
                this.rpvFactura.SelectedPage = pvGenerales;                
                txtserie.Focus(); return false; }
            if (txtsubplantilla.Text == "") { 
                Util.ShowAlert("Ingrese Tipo de Factura");
                this.rpvFactura.SelectedPage = pvGenerales;
                txtsubplantilla.Focus();
                txtsubplantilla.Focus();
                return false; }
            if (LblHelp0.Text == "") { 
                Util.ShowAlert("Tipo de factura no validar");
                this.rpvFactura.SelectedPage = pvGenerales;
                return false; }
            if (txttipanalisis.Text == "") { 
                Util.ShowAlert("Ingrese Tipo Analisis Cliente");
                this.rpvFactura.SelectedPage = pvGenerales;
                txttipanalisis.Focus();
                return false; }
            if (TxtCliente.Text == "") { 
                Util.ShowAlert("Ingrese Cliente");
                this.rpvFactura.SelectedPage = pvGenerales;
                TxtCliente.Focus();
                return false; }
            if (txtRazon.Text == "") { 
                Util.ShowAlert("Razon Social No Valido");
                this.rpvFactura.SelectedPage = pvGenerales;
                txtRazon.Focus();
                return false; }
            
            if (txtDireccion.Text == "") { 
                Util.ShowAlert("Direccion No Valido");
                this.rpvFactura.SelectedPage = pvGenerales;
                txtDireccion.Focus();
                return false; }
            
            if (TxtRuc.Text == "") { 
                Util.ShowAlert("RUC No Valido");
                this.rpvFactura.SelectedPage = pvGenerales;
                TxtRuc.Focus();
                return false; }
            
            if (LblHelp2.Text == "") { 
                Util.ShowAlert("Moneda No Valido");
                this.rpvFactura.SelectedPage = pvGenerales;

                return false; }
            if (Convert.ToDouble(txtIgvPercent.Text) < 0) { Util.ShowAlert("IGV No Valido"); return false; }
            
            if (txttipoventa.Text == "") { 
                Util.ShowAlert("Tipo de venta No Valido");
                this.rpvFactura.SelectedPage = pvGenerales;
                return false; }


            if (txtformapagosunat.Text == "" || LblhelpFormapagosunat.Text == "???")
            {
                Util.ShowAlert("Ingrese Forma Pago Factura Negociable");
                //rpvFactura.SelectedPage = pvExportacion;
                txtformapagosunat.Focus();
                return false;
            }


            if (pvExportacion.Enabled == true)
            {
                if (txtExpPaisOrigen.Text == "") { 
                    Util.ShowAlert("Ingrese Pais Origen");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpPaisOrigen.Focus();
                    return false; 
                
                }
                if (txtExpPaisDestino.Text == "") { 
                    Util.ShowAlert("Ingrese Pais Destino");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpPaisDestino.Focus();
                    return false; }

                if (txtExpCondPago.Text == "") { 
                    Util.ShowAlert("Condicion de Pago No Valido"); 
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpCondPago.Focus();
                    return false; }

                if (txtExpConDespacho.Text == "") { 
                    Util.ShowAlert("Condicion De Despacho No Valido");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpConDespacho.Focus();
                    return false; }

                if (txtExpPuertoEmbarque.Text == "") { 
                    Util.ShowAlert("Puerto De Embarque No Valido");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpPuertoEmbarque.Focus();
                    return false; }

                if (txtExpPuertoEmbarqueDes.Text == "") { 
                    Util.ShowAlert("Puerto de Destino No Valido");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpPuertoEmbarqueDes.Focus();
                    return false; }

                if (txtExpBancoLocal.Text == "") { 
                    Util.ShowAlert("Ingrese Banco Local");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpBancoLocal.Focus();
                    return false; }
                
                if (txtExpBankCode.Text == "") { 
                    Util.ShowAlert("Ingrese bank code");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpBankCode.Focus();
                    return false; }

                if (txtExpAccountNumber.Text == "") { 
                    Util.ShowAlert("Ingrese Account Number");
                    rpvFactura.SelectedPage = pvExportacion;
                    txtExpAccountNumber.Focus();
                    return false; }

                if (str_EstadoProceso == "L")
                {
                    if (txtExpConEmbarque.Text == "") { 
                        Util.ShowAlert("Ingrese Conocimiento de Embarque");
                        rpvFactura.SelectedPage = pvExportacion;
                        txtExpConEmbarque.Focus();
                        return false; }

                    if (txtExpContainer.Text == "") { 
                        Util.ShowAlert("Ingrese container");
                        rpvFactura.SelectedPage = pvExportacion;
                        txtExpContainer.Focus();
                        return false; }

                    if (txtExpNroprecinto.Text == "") { 
                        Util.ShowAlert("Ingresar Nro de Precinto");
                        rpvFactura.SelectedPage = pvExportacion;
                        txtExpNroprecinto.Focus();
                        return false; }
                }

            }

            return true;
        }
        #endregion
        #region "Eventos cabecera"
        private void IniciarFormularioSegunOrigen(OrigenInstancia tipo)
        {
            this.rpvFactura.SelectedPage = pvGenerales;
            
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);            
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            
            if (tipo == OrigenInstancia.Principal)
            {                                
                Estado = FrmParent.Estado;
                EstadoDocumento = FrmParent.EstadoDocumento;
                this.Text = EstadoDocumento == BaseTipoDocumento.enmBoleta ? "Boleta Detalle" : "Factura Detalle";
                IniciarFormularioSegunEstado(Estado);
                
            }
            else if (tipo == OrigenInstancia.Externo1)
            {
                                
                // == Asignar nombre de cabecera de formula.
                
                Estado = FrmParentFacturaxGuia.Estado;
                EstadoDocumento = FrmParentFacturaxGuia.EstadoDocumento;

                //Asigno el tipo de documento si es Factura 01 , Boleta 03
                tipoDocumento = EstadoDocumento == BaseTipoDocumento.enmFactura ? "01" : "03";

                this.Text = EstadoDocumento == BaseTipoDocumento.enmBoleta ? "Boleta Detalle" : "Factura Detalle";
                                                
                // Inicio la configuracion del formulario por estado de formulario
                IniciarFormularioSegunEstado(Estado);

                TraerDatosClienteDesdeGuia();
                TraerDatosDetalleDesdeGuia();
                
                DesactivaTodoBootonesCabDetalle();
                HabilitarEdicionDelDetalle();
            }
        }
        void TraerDatosClienteDesdeGuia()
        {
            try
            {
                // == Cargar datos de cliente desde guia
                // == Consultar los datos de la guia
                #region "Consultar datos de guia"
                List<GuiaTransporte> DatosDocGuia = new List<GuiaTransporte>();

                string nrodocumento = GuiasSeleccionados[0].Split('|')[0];
                string mesdocumento = "", aniodocumento = "";
                string descripcion = "";

                aniodocumento = GuiasSeleccionados[0].Split('|')[2];
                mesdocumento = GuiasSeleccionados[0].Split('|')[3];

                
                DatosDocGuia = LogicaGuia.TraerGuiasTransporte(Logueo.CodigoEmpresa, aniodocumento,
                                                                mesdocumento, "FAC34NROGUIA", nrodocumento);
                #endregion
                // == traer datos de cliente
                #region "Datos de cabecera"
                GuiaTransporte RegistroGuia = DatosDocGuia[0];
                
                TxtCliente.Text = RegistroGuia.FAC34CLICOD.Trim();
                //txtRazon.Text = RegistroGuia.FAC34DESDESEMP.Trim();
                //txtDireccion.Text = RegistroGuia.FAC34DESTDIRECCION.Trim();
                //TxtRuc.Text = TxtCliente.Text.Trim();

                //Traer los datos del Cliente segun codigo
                if (TxtCliente.Text != "")
                {
                    List<CuentaCorriente> RegistroCliente = GlobalLogic.Instance.Spu_Fact_Trae_Clientes(Logueo.CodigoEmpresa,
                    txttipanalisis.Text, "ccm02cod", TxtCliente.Text);
                    //Error por no ecnotnrar cliente segun los parametros enviado.
                    if (RegistroCliente.Count > 0)
                    {
                        txtRazon.Text = RegistroCliente[0].ccm02nom;
                        txtDireccion.Text = RegistroCliente[0].ccm02dir;
                        TxtRuc.Text = RegistroCliente[0].ccm02ruc;
                    }

                    //Ver columna si el cliente tiene productos

                    bool verColumna = false;
                    ArticuloClienteLogic.Instance.TraeFlagProductoCliente(Logueo.CodigoEmpresa, TxtCliente.Text.Trim(), out CantidadProductoRelacionado);
                    //Si cliente no tiene productos relacionado a deisi
                    verColumna = CantidadProductoRelacionado == 0 ? false : true;

                    this.gridControlDetalle.Columns["FAC05CODPROD_PROV"].IsVisible = verColumna;
                    this.gridControlDetalle.Columns["FAC05DESPROD_PROV"].IsVisible = verColumna;
                    this.gridControlDetalle.Columns["FAC05UNIMED_PROV"].IsVisible = verColumna;   
                }

                
             
                txtExpContainer.Text = RegistroGuia.FAC34CONTENEDOR.Trim();
                txtExpNroprecinto.Text = RegistroGuia.FAC34PRECINTO.Trim();
                //Asigno el tipo de documento si es Factura 01 , Boleta 03
                txttipdoc.Text = tipoDocumento;
                // valore por defecto para analisis PARA TRAER CLIENTES
                txttipanalisis.Text = Logueo.TipoAnalisisCliente;
                
                //Llenar OC y Guias
                for (int x = 0; x < FrmParentFacturaxGuia.CantidadRegistros; x++)
                {
                    #region "Como es la lectura la lista GuiasSeleccionados"
                    //GuiasSeleccioando -> tiene varias lineas con este foromato :
                    /*
                        string[] GuiasSeleccionados = 1|AM001|100     [0]
                     *                                2|AM002|150.80  [1]
                                                      3|AM003|210.40  [2]                  
                     * Lectura de registro arreglo cadena 
                     * GuiasSeleccionados[0] = 1|AM001|100 
                     * GuiasSeleccionados[0].split('|') -> 1 [0]
                     *                                     AM001 [1]
                     *                                     100  [2]
                     
                     * NumeroDocumento = GuiaseSeleccionados[0].split('|')[1] ->  AM001
                     */
                    #endregion
                    if (FrmParentFacturaxGuia.CantidadRegistros == 1)
                    {
                        txtordcompra.Text = GuiasSeleccionados[x].Split('|')[4];
                        txtguias.Text += GuiasSeleccionados[x].Split('|')[0];
                    }
                    else if (FrmParentFacturaxGuia.CantidadRegistros > 1)
                    {
                        if (x == (FrmParentFacturaxGuia.CantidadRegistros - 1))
                        {
                            txtordcompra.Text += GuiasSeleccionados[x].Split('|')[4];
                            txtguias.Text += GuiasSeleccionados[x].Split('|')[0];
                        }
                        else if (x < FrmParentFacturaxGuia.CantidadRegistros)
                        {
                            txtordcompra.Text += GuiasSeleccionados[x].Split('|')[4] + ",";
                            txtguias.Text += GuiasSeleccionados[x].Split('|')[0] + ",";
                        }
                    }
                    
                }                                
                #endregion
                /*
                * 1. Cargar por defecto el tipo 02 : Cuando es  venta y tipo 01 cuando es exportación, para el resto dejar en blanco
                Nota : cuando carga 01 o 02, debe jalar el número de factura (Tal como si se hubiese seleccionado)
                */
                //Validar esta generacion es solo para Factura 
                //con motivo de traslado venta o exportacion 
                #region "Carga de datos de documento por defecto segun motivo de traslado"
                if (RegistroGuia.FAC34MOTRASLCOD.Trim() == "01" ||
                        RegistroGuia.FAC34MOTRASLCOD.Trim() == "12") // venta o exportacion
                    {
                        
                        //Valida por tipo de documento si es factura o boleta
                        if (EstadoDocumento == BaseTipoDocumento.enmFactura)
                        {
                            //Valido el motivo de traslado
                            if (RegistroGuia.FAC34MOTRASLCOD == "01")  // venta
                            {
                                //Factura para venta nacional de travertino
                                txtsubplantilla.Text = "02";
                            }
                            else if (RegistroGuia.FAC34MOTRASLCOD == "12") // exportacion
                            {
                                //Asigno el codigo de plantilla -> Factura por exportacion de travertinos
                                txtsubplantilla.Text = "01";
                            }
                        }
                        else if (EstadoDocumento == BaseTipoDocumento.enmBoleta)
                        {
                            txtsubplantilla.Text = "16";
                        }
                        //10/09/2020
                        //Lectura en general de todo las plantillas de documento disponible
                        DataTable datos = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC03_SUBPLANTILLA(Logueo.CodigoEmpresa,
                                          tipoDocumento, "FAC03COD", txtsubplantilla.Text.Trim(), "");

                        if (datos.Rows.Count == 0)
                        {
                            Util.ShowAlert("El registro de esta subpolantilla no existe");
                            return;
                        }

                        txtsubplantilla.Text = datos.Rows[0]["FAC03COD"].ToString();
                        LblHelp0.Text = datos.Rows[0]["FAC03DESC"].ToString();
                        //txttipdoc.Text = datos.Rows[0]["FAC01COD"].ToString();
                        txtcodplantilla.Text = datos.Rows[0]["FAC02COD"].ToString();
                        txtserie.Text = datos.Rows[0]["FAC03SERIEXDEF"].ToString();
                        txttipoarticulo.Text = datos.Rows[0]["FAC03TIPART"].ToString();
                        txttipoventa.Text = datos.Rows[0]["FAC03TIPOVENTA"].ToString();
                        if (txttipoventa.Text == "01")
                        {
                            txtIgvPercent.Text = Util.convertiracadena(Logueo.Igv);
                        }
                        else
                        {
                            txtIgvPercent.Text = "0";
                        }
                        
                        txtTipoOperacionFE.Text = Util.convertiracadena(datos.Rows[0]["FAC03TIPOOPERACIONFE"]);
                        string establecimientocod;
                        GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + tipoDocumento + txtserie.Text, "ESTABLECIMIENTO", out establecimientocod);
                        txtCodigoAnexoEmisorFE.Text = establecimientocod;
                        ActivarDesactivarTab(txttipoventa.Text.Trim());

                        string sNroDocumento = "";
                        GlobalLogic.Instance.DameNroDocumento(Logueo.CodigoEmpresa,
                                            txttipdoc.Text.Trim(), txtserie.Text.Trim(), out sNroDocumento);
                        txtNumeroDocumento.Text = sNroDocumento;
                    }
                #endregion
                //trae codigo de moenda de cliente
                GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa +
                 txttipanalisis.Text.Trim() + TxtCliente.Text.Trim(),
                 "MONEDAXCLI", out descripcion);
                txtmoneda.Text = descripcion;

                //traer descripcion de moneda
                GlobalLogic.Instance.DameDescripcionFA(txtmoneda.Text, "MONEDAFAC", out descripcion);
                LblHelp2.Text = descripcion;

                


            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        void TraerDatosDetalleDesdeGuia()
        {
            try
            {
                // Parche, para que respete el formato de decimales 
                traesubdetalle();

                // == Insertar detalle de guia  al detalle de factura.
                int i = 0;
                for (i = 0; i < FrmParentFacturaxGuia.CantidadRegistros; i++)
                {
                    string GuiaTipoDocumento, GuiaNroDocumento = "";

                    GuiaNroDocumento = GuiasSeleccionados[i].Split('|')[0].ToString();
                    GuiaTipoDocumento = GuiasSeleccionados[i].Split('|')[1].ToString();

                    List<DetalleGuiaTransporte> Detalles = new List<DetalleGuiaTransporte>();

                    Detalles = LogicaDocumento.TraeAyudaGuiaTransporte(Logueo.CodigoEmpresa, GuiaTipoDocumento, GuiaNroDocumento);

                    // Agregar Nueva Fila.
                    #region "agregar fila a xml"
                    for (int y = 0; y < Detalles.Count; y++)
                    {
                        GridViewRowInfo row = this.gridControlDetalle.Rows.AddNew();
                        Util.SetValueCurrentCellText(row, "FAC05CODEMP", Logueo.CodigoEmpresa);
                        Util.SetValueCurrentCellText(row, "FAC01COD", txttipdoc.Text.Trim());
                        Util.SetValueCurrentCellText(row, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());

                        Util.SetValueCurrentCellInt(row, "FAC05CODFACDET", 0);
                        Util.SetValueCurrentCellText(row, "FAC05CODPROD", Detalles[y].FAC35CODPROD);
                        Util.SetValueCurrentCellText(row, "FAC05DESCPROD", Detalles[y].FAC35DESCPROD);
                        Util.SetValueCurrentCellText(row, "FAC05UNIMED", Detalles[y].FAC35UNIMED);

                        Util.SetValueCurrentCellDbl(row, "FAC05PRECIO", 0);
                        Util.SetValueCurrentCellDbl(row, "FAC05SUBTOTAL", 0);
                        Util.SetValueCurrentCellDbl(row, "FAC05IGV", 0);
                        Util.SetValueCurrentCellDbl(row, "FAC05IMPTOTAL", 0);


                        Util.SetValueCurrentCellText(row, "FAC05GUIATIPDOC", Detalles[y].FAC01COD); //Tipo de documento Guia "09"
                        Util.SetValueCurrentCellText(row, "FAC05GUIANUMERO", Detalles[y].FAC34NROGUIA);
                        Util.SetValueCurrentCellText(row, "FAC05GUIAITEM", Detalles[y].FAC35CODGUIADET);

                        //Traer Codigo de SUNAT
                            string opcionarti = "";
                            string codigoProductoSunat = "";

                            // Trae tabla de donde leer el articulo
                            GlobalLogic.Instance.DameDescripcionFA("13" + txttipoarticulo.Text, "GLODESCCOM", out opcionarti);


                            //Traer codigo de producto sunat
                            GlobalLogic.Instance.TraeCodigoProductoSunat(Logueo.CodigoEmpresa, Logueo.Anio, Detalles[y].FAC35CODPROD, opcionarti, out codigoProductoSunat);
                            Util.SetValueCurrentCellText(row, "FAC05FECODPRODSUNAT", codigoProductoSunat);

                        //Asignar IGV de cabecera

                         Util.SetValueCurrentCellText(row, "FAC05FEIGVTASA", txtIgvPercent.Text);

                        // Asignar valores por defecto por el tipo de documento
                        TraerValoresDefectoxTipDocuyPlantilla(row);

                        Util.SetValueCurrentCellDbl(row, "FAC05CANTIDAD", Detalles[y].FAC35CANTIDAD);
                        Util.SetValueCurrentCellDbl(row, "FAC05PESO", Detalles[y].FA35PESO);
                        Util.SetValueCurrentCellDbl(row, "FAC05NROCAJA", Detalles[y].FA35NROCAJAS);

                        Util.SetValueCurrentCellText(row, "FAC05CODPROD_PROV", Detalles[y].FAC35CODPROD_PROV);
                        Util.SetValueCurrentCellText(row, "FAC05DESPROD_PROV", Detalles[y].FAC35DESCPROD_PROV);
                        Util.SetValueCurrentCellText(row, "FAC05UNIMED_PROV", Detalles[y].FAC35UNIMED_PROV);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        void IniciarFormularioSegunEstado(FormEstate tipo)
        {
            // Configurar estado y carga de controles del formulario.
            if (Estado == FormEstate.New)
            {
                Iniciacontroles();
                SendKeys.Send("{TAB}");
                ResaltarControlesAyuda(true);
                //Botones de la cabecera
                VerBotonesCabGuardar();
                //Botones del detalle
                OcultarBotonesDelDetalle();
            }
            else if (Estado == FormEstate.Edit)
            {                
                ResaltarControlesAyuda(false);
                CargaDetalle();
                traesubdetalle();
                ActivaModoVer();
                // 1.Vemos los botones de Nuevo, Editar, Cancelar, navegacion
                VerBotonesCabVer();
                VerBotonesDelDetalle();
                //dehsabilita estos botones cuando ingreso en modo editar al formulario
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                

            }
            else if (Estado == FormEstate.View)
            {
               
                //EditarControles();
                SendKeys.Send("{TAB}");
                ResaltarControlesAyuda(true);
                CargaDetalle();
                traesubdetalle();
                ActivaModoVer();
                //Botones de la cabecera
                //VerBotonesCabGuardar();

                //Botones del detalle
                OcultarBotonesDelDetalle();
                ComportarmientoBotones("ver");
            }
        }
        private void frmfacturacab_Load(object sender, EventArgs e)
        {
            IniciarFormularioSegunOrigen(TipoOrigen);
        }
        void OcultarBotonesDelDetalle()
        {
            btnCancelar.Visible = false;
            btnGrabar.Visible = false;
            btnEditar.Visible = false;
            btnNuevoGuia.Visible = false;
            btnAdd.Visible = false;
            
        }
        void VerBotonesDelDetalle()
        {
            btnCancelar.Visible = true;
            btnGrabar.Visible = true;
            btnEditar.Visible = true;
            btnAdd.Visible = true;
            btnNuevoGuia.Visible = true;
            
        }
        void txtExpBancoLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_ExpBancoLocal);
            else
                FocusNextControl(e);
        }
        void txtExpPuertoEmbarqueDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_ExpPuertoEmbarqueDes);
            else
                FocusNextControl(e);
        }
        void txtExpPuertoEmbarque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_ExpPuertoEmbarque);
            else
                FocusNextControl(e);
        }
        void txtExpConDespacho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_ExpConDespacho);
            else
                FocusNextControl(e);
        }
        void txtExpCondPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_ExpCondPago);
            else
                FocusNextControl(e);
        }
        void txtExpPaisDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_ExpPaisDestino);
            else
                FocusNextControl(e);
        }
        void txtExpPaisOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_ExpPaisOrigen);
            else
                FocusNextControl(e);
        }
        void txtcodtienda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_Tienda);
            else
                FocusNextControl(e);
        }
        void txtmoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_Moneda);
            else
                FocusNextControl(e);
        }

        void txtdetraccionCodServ_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmDetraccionCod);
               
            else
                FocusNextControl(e);
        }

        void txtformapagosunat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFormaPagoSunat);
            else
                FocusNextControl(e);
        }

        void txtTipoCambio_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);

        }
        //void TxtCliente_Te
        void TxtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_Cliente);
            else
                FocusNextControl(e);
        }
        void txttipanalisis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_TipoAnalisis);
            else
                FocusNextControl(e);
            //else if (e.KeyValue == (char)Keys.Enter)
            //SendKeys.Send("{TAB}");
        }
        void txtsubplantilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_SubPlantilla);
            else
                //FocusNextControl(e);
                if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Down)
                    dtpFechaDoc.Focus();
        }
        void txtRazon_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }
        void TxtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }
        void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }
        #endregion
        #region "Dar Baja"
        private void OcultarDarBaja()
        {
            gpxDarBaja.Hide();
            gpxDarBaja.SendToBack();
            dtpFechaBaja.Text = ""; txtMotivoBaja.Text = "";
            dtpFechaBaja.Value = DateTime.Now;
        }
        private void MostrarDarBaja()
        {
            dtpFechaBaja.Focus();
            gpxDarBaja.BringToFront();
            gpxDarBaja.Show();
        }
        void btnCancelarBaja_Click(object sender, EventArgs e)
        {
            OcultarDarBaja();
        }

        void btnGuardarBaja_Click(object sender, EventArgs e)
        {            
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea dar de baja el documento?");
                if (respuesta == false) return;
                int int_flag = 0; string str_mensaje = "";
                if (dtpFechaBaja.Text == "") { Util.ShowAlert("Ingresar fecha"); return; }
                if (txtMotivoBaja.Text == "") { Util.ShowAlert("Ingresar motivo"); return; }

                // ==== Comentar el metodo para generar el documento , pues esta a prueba 
                // ==== la generacion de factura electronica
                DocumentoLogic.Instance.DarComunicadoBaja(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(),
                    txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), dtpFechaDoc.Text.Trim(),
                    dtpFechaBaja.Text.Trim(), txtMotivoBaja.Text.Trim(), out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1)
                {
                    OcultarDarBaja();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        #endregion
        #region "Metodos Base"
        protected override void OnCopiar()
        {
            MostarCopiarDoc();
        }
        protected override void OnAnterior()
        {

            int int_indice = FrmParent.gridControl.MasterView.CurrentRow.Index - 1;
            if (int_indice < 0)
            {
                return;
            }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            CargaDetalle();
        }
        protected override void OnSiguiente()
        {

            int int_indice = FrmParent.gridControl.MasterView.CurrentRow.Index + 1;
            if (int_indice > FrmParent.gridControl.MasterView.Rows.Count - 1)
            { 
                return; 
            }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];

            CargaDetalle();
        }
        protected override void OnPrimero()
        {
            int int_indice = 0;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            //FrmParent.gridControl.CurrentRow = FrmParent.gridControl.Rows[int_indice];
            
            CargaDetalle();
        }
        protected override void OnUltimo()
        {
            int int_indice = FrmParent.gridControl.MasterView.Rows.Count - 1;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            CargaDetalle();
        }
        protected override void OnCancelar()
        {

            // 1.Si llamo este formulario desde frmGenerardesdeGuiaDet
            if (FrmParentFacturaxGuia != null)
            {
                this.Close();
            }
            else if (FrmParent != null) //Si llamo a este formulario desde frmFacturas , hacer lo siguiente
            {
                // 1.Bloquea los controles de ingreso de datos
                ActivaModoVer();
                // 2.Veo los botones utiles para el modo ver en nuestro formulario
                VerBotonesCabVer();
                // 3.Ocultamos los botones del detalle del formulario.
                VerBotonesDelDetalle();
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                // 4.Trae datos del ultimo registro seleccionado
                CargaDetalle();
                // 5.Recorrer la grilla para refrescar los botones de eliminar
                RefrescarGrilla();
                InsertaroActualizarDetalle = "";
            }
            ResaltarControlesAyuda(false);
            Estado = FormEstate.View;
        }

        private void RefrescarGrilla()
        {
            for (int x = 0; x < gridControlDetalle.Rows.Count; x++)
            {
                //gridControlDetalle.Rows[x].IsSelected = true;
                gridControlDetalle.CurrentRow = gridControlDetalle.Rows[x];
            }
        }

        protected override void OnGenerarFE()
        {
            try
            {
                string str_mensaje = ""; int int_flag = 0;
                string str_mensajeError = "";
                bool respuesta = Util.ShowQuestion("¿Desea Generar el Documento Electronico?");
                
                if (respuesta == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    datosDoc.GenerarFacturaElectronica(Logueo.CodigoEmpresa,
                        txttipdoc.Text.Trim(),
                        txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(),
                        out int_flag, out str_mensaje);

                    //Esperar 1 segundos para validar tabla errore
                    System.Threading.Thread.Sleep(2000);
                    // Verirficar que no hay habido error en 
                    if (int_flag == 1)
                    {
                        datosDoc.Spu_Fac_Trae_ErrorLocalFE(txttipdoc.Text.Trim(), txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), out str_mensajeError);

                        if (str_mensajeError != "")
                        {
                            Util.ShowMessage(str_mensajeError, -1);
                        }

                        else
                        {
                            Util.ShowMessage(str_mensaje, int_flag);
                            if (FrmParent != null)
                            {
                                FrmParent.Cargar();
                                Util.enfocarFila(FrmParent.gridControl, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());
                            }

                        }
                    }
                    else
                    {
                        Util.ShowMessage(str_mensaje, int_flag);
                        if (FrmParent != null)
                        {
                            FrmParent.Cargar();
                            Util.enfocarFila(FrmParent.gridControl, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());
                        }

                    }

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void OnVerFE()
        {
            string str_result, str_pdfWebPath;
            str_result = ""; str_pdfWebPath = "";
            try
            {
                datosDoc.TraeFacturaElectronicaOnline(Logueo.CodigoEmpresa, "6",
                    Logueo.RucEmpresa, txttipdoc.Text.Trim(),
                    txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(),
                    out str_pdfWebPath);
                if (str_pdfWebPath == "")
                {
                    Util.ShowAlert("Documento no disponible, Vuelva  Intentarlo");
                }
                else
                {
                    System.Diagnostics.Process.Start(str_pdfWebPath);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        protected override void OnDarBaja()
        {
            MostrarDarBaja();            
        }
        private void LimpiarControles()
        { 
            txtsubplantilla.Text = "";
            LblHelp0.Text = "";
            TxtCliente.Text = "";
            txtRazon.Text = "";
            TxtRuc.Text = "";
            txtDireccion.Text = "";

            txtmoneda.Text = "";
            LblHelp2.Text = "";

            txtformapagosunat.Text = "";
            LblhelpFormapagosunat.Text = "";

            rbProcesoDraft.CheckState = CheckState.Unchecked;
            rbProcesoLimpio.CheckState = CheckState.Unchecked;

            gridControlDetalle.DataSource = null;
            gridcuotas.DataSource = null;
        }
        // == Mantenimiento desde el mantenimiento de factura.
        protected override void OnNuevo()
        {
            // Si la operacion es llamado desde frmfacturacab
            if (FrmParent != null)
            {
                // Limpiar los campos de cabecera y detalle del fromulario
                LimpiarControles();
                // 1.Ver los botones de guardar y cancelar
                Iniciacontroles();
                VerBotonesCabGuardar();
                
                //2.Asignar el valor de tipo de documento a nuestro control.
                txttipdoc.Text = tipoDocumento;

                // 3.Activar el resto de campos necesarios del formulario.
                // 3.1.Activar los campos 
                EditarControles();
                txtsubplantilla.Enabled = true;
                
                //habilitar el campo serie
                //txtserie.Enabled = true; //10/09/2020
                txtserie.Enabled = true;

                //txtNumeroDocumento.Enabled = true;
                //SendKeys.Send("{TAB}");
                btnGrabar.Enabled = false;
                // 4.Ocultamos los botones del detalle
                OcultarBotonesDelDetalle();
                ResaltarControlesAyuda(true);
                txttipdoc.Focus();
                Estado = FormEstate.New;
            }
            else if (FrmParent == null)
            {
                Util.ShowAlert("Esta accion no permitido desde esta opcion");
            }
        }

        protected override void OnEditar()
        {
            EditarControles();
            btnGrabar.Enabled = false;
            // 3.Ver los botones 
            VerBotonesCabGuardar();
            // 4:Ver botones de la cabecera del documento            
            //VerTodoBotonesCabDetalle();
            OcultarBotonesDelDetalle();
            // 5:Habilitar los botones para el mantenimiento de la grilla
            //btnCancelar.Enabled = false;
            //btnGrabar.Enabled = false;
            //btnEditar.Enabled = true;
            //btnAdd.Enabled = true;
            //btnNuevoGuia.Enabled = true;            
            ResaltarControlesAyuda(true);
            Estado = FormEstate.Edit;
        }

        protected override void OnEliminar()
        {
            try
            {
                if (txtserie.Text.Trim() == "")
                {
                    Util.ShowAlert("serie No Valida"); 
                    return;
                }

                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    Util.ShowAlert("Numero de documento no valido"); 
                    return;
                }

                bool res = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (res == true)
                {
                 
                    int int_flag = 0; string str_mensaje = "";

                    DocumentoFA doc = new DocumentoFA();
                    doc.FAC04CODEMP = Logueo.CodigoEmpresa;
                    doc.FAC01COD = txttipdoc.Text.Trim();
                    doc.FAC04NUMDOC = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();

                    Cursor.Current = Cursors.WaitCursor;

                    DocumentoLogic.Instance.Spu_Fact_Del_FAC04_CABFACTURA(doc, out int_flag, out str_mensaje);

                    Util.ShowMessage(str_mensaje, int_flag);

                    if (int_flag == 1) {
                        if (FrmParent != null)
                        {
                            // 1.Refrescar la grilla de lista de facturas    
                            FrmParent.Cargar();
                            // 2.Cerrar el formulario
                            this.Close();
                        }
                        else if (FrmParent == null)
                        {
                            this.Close();
                        }
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        protected override void OnGenerarPDF()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string codigoTipoDocumento = "";
                string numeroDocumento = "";
                string codigoPlantilla = "";
                codigoTipoDocumento = tipoDocumento;
                numeroDocumento = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();
                codigoPlantilla = txtcodplantilla.Text.Trim();

                DataTable datosFactura = new DataTable();
                datosFactura = VentaDocumentoLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa, codigoTipoDocumento, numeroDocumento);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                if (codigoTipoDocumento == "01")
                {
                    if (codigoPlantilla == "01") //factura exportacion
                    {
                        reporte.Nombre = "RptFacturaExportacion.rpt";
                    }
                    else if (codigoPlantilla == "02") //factura nacional
                    {
                        reporte.Nombre = "RptFacturaNacional.rpt";
                    }
                }
                else if (codigoTipoDocumento == "03")
                {
                    reporte.Nombre = "RptBoleta.rpt";
                }
                if (datosFactura.Rows.Count == 0)
                {
                    Util.ShowAlert("No tiene registro el documento seleccionado");
                    return;
                }
                reporte.DataSource = datosFactura;

                ReporteControladora control = new ReporteControladora(reporte);

                control.VistaPDF(enmWindowState.Normal, numeroDocumento);
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }


        // == Guardar factura
        private void GuardarPorOrigenInstancia(OrigenInstancia tipo)
        {
            if (tipo == OrigenInstancia.Principal)
            {
                GuardarFactura();
            } else if(tipo == OrigenInstancia.Externo1) {
                GuardarFacturaTemporal();
            }
        }

        private DocumentoFA CargarEntidad()
        {
            DocumentoFA entidadDocumento = new DocumentoFA();
            entidadDocumento.FAC04CODEMP = Logueo.CodigoEmpresa;
            entidadDocumento.FAC02COD = txtcodplantilla.Text;
            entidadDocumento.FAC03COD = txtsubplantilla.Text;
            entidadDocumento.FAC03TIPART = txttipoarticulo.Text;
            entidadDocumento.FAC01COD = txttipdoc.Text.Trim();
            entidadDocumento.FAC04NUMDOC = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();
            entidadDocumento.FAC04AA = Logueo.Anio;
            entidadDocumento.FAC04MM = Logueo.Mes;
            entidadDocumento.FAC04NRODOC = txtNumeroDocumento.Text.Trim();
            entidadDocumento.FAC04SERIEDOC = txtserie.Text.Trim();
            entidadDocumento.FAC04FECHA = dtpFechaDoc.Value;
            entidadDocumento.FAC04TIPANA = txttipanalisis.Text.Trim();
            entidadDocumento.FAC04CODCLI = TxtCliente.Text.Trim();
            entidadDocumento.FAC04MONEDA = txtmoneda.Text.Trim();
            entidadDocumento.FAC04TIPCAMBIO = Convert.ToDouble(txtTipoCambio.Text.Trim());
            entidadDocumento.FAC04DONSUBTOTAL = Convert.ToDouble(txtdonsubtotal.Text);
            entidadDocumento.FAC04DONIGV = Convert.ToDouble(txtdonigv.Text);
            entidadDocumento.FAC04DONTOTAL = Convert.ToDouble(txtdontotal.Text);
            entidadDocumento.FAC04CLINOMBRE = txtRazon.Text;
            entidadDocumento.FAC04CLIDIRECCION = txtDireccion.Text;
            entidadDocumento.FAC04CLIRUC = TxtRuc.Text;
            entidadDocumento.FAC04GLOSA = TxtObservacion.Text;
            entidadDocumento.FAC04DONGLAG = chkdonacion.Checked == true ? "S" : "N";
            entidadDocumento.FAC04IGV = Convert.ToDouble(txtIgvPercent.Text);
            entidadDocumento.FAC04GUIAS = txtguias.Text;
            entidadDocumento.FAC04DOCMODTIPDOC = "";
            entidadDocumento.FAC04DOCMODNRO = "";
            entidadDocumento.FAC04DOCMODFECHA = null;
            entidadDocumento.FAC04TIPMOTEMI = "";
            entidadDocumento.FAC04TIPMOTEMIDES = "";
            entidadDocumento.FAC04EXPCONOEMBARQUE = txtExpConEmbarque.Text;
            entidadDocumento.FAC04EXPCODPAISORIGEN = txtExpPaisOrigen.Text;
            entidadDocumento.FAC04EXPCODPAISDESTINO = txtExpPaisDestino.Text;
            entidadDocumento.FAC04EXPCODCONDPAGO = txtExpCondPago.Text;
            entidadDocumento.FAC04EXPCODCONDDESPACHO = txtExpConDespacho.Text;
            entidadDocumento.FAC04EXPCODPUERTO = txtExpPuertoEmbarque.Text;
            entidadDocumento.FAC04EXPCODPUERTODES = txtExpPuertoEmbarqueDes.Text;
            entidadDocumento.FAC04EXPCODBCOLOCAL = txtExpBancoLocal.Text;
            entidadDocumento.FAC04EXPCDDOCCRED = txtExpCD.Text;
            entidadDocumento.FAC04EXPLCEMITIDA = txtExpLC.Text;
            entidadDocumento.FAC04EXPBANKCODE = txtExpBankCode.Text;
            entidadDocumento.FAC04EXPNUMCUENTA = txtExpAccountNumber.Text;
            entidadDocumento.FAC04EXPNROCONTAINER = txtExpContainer.Text;
            entidadDocumento.FAC04EXPNROPRECINTO = txtExpNroprecinto.Text;
            entidadDocumento.FAC04ORDENCOMPRA = txtordcompra.Text;
            entidadDocumento.FAC04LIQUIDACIONNRO = txtliquidacionnro.Text;

            entidadDocumento.FAC04FETIPODEOPERACION = txtTipoOperacionFE.Text;
            entidadDocumento.FAC04FECODIGOANEXOEMISOR = txtCodigoAnexoEmisorFE.Text;


            if (dtpFechaOrdCom.Text == "")
            {
                entidadDocumento.FAC04FECORDCOMPRA = null;
            }
            else
            {
                entidadDocumento.FAC04FECORDCOMPRA = dtpFechaOrdCom.Value;
            }


            entidadDocumento.FAC04CODTIPOVENTA = txttipoventa.Text;
            if (rbProcesoDraft.IsChecked == true
                && rbProcesoLimpio.IsChecked == false)
            {
                entidadDocumento.FAC04ESTADODEPROCESO = "D";
            }
            else if (rbProcesoDraft.IsChecked == false
                   && rbProcesoLimpio.IsChecked == true)
            {
                entidadDocumento.FAC04ESTADODEPROCESO = "L";
            }
            else if (rbProcesoLimpio.IsChecked == false
               && rbProcesoDraft.IsChecked == false)
            {
                entidadDocumento.FAC04ESTADODEPROCESO = "";
            }

            entidadDocumento.FAC04TIENDA = txtcodtienda.Text.Trim();
            entidadDocumento.FAC04VENDEDORCOD = txtcodvendedor.Text.Trim();
            entidadDocumento.FAC04VENDEDORNOMBRE = LblVendedorNombre.Text.Trim();

            entidadDocumento.FAC04DESCUENTOGLOBAL = 0;
            entidadDocumento.FAC04FETIPONOTA = "";
            entidadDocumento.FAC04FORMAPAGOSUNAT = txtformapagosunat.Text.Trim();
            entidadDocumento.FAC04FORMAPAGOSUNATCUOTAS= Convert.ToInt32(txtcuotasnro.Text);
            entidadDocumento.FAC04FORMAPAGOSUNATDIAS = Convert.ToInt32(txtcuotadias.Text);

            entidadDocumento.FAC04FECODBIENOSERVDETRACCION = txtdetraccionCodServ.Text.Trim();
            entidadDocumento.FAC04FEPORCEDETRACCION = Convert.ToDouble(txtdetraccionPorcentaje.Text);
            entidadDocumento.FAC04FETOTALDETRACCION = Convert.ToDouble(txtdetraccionImporte.Text);
            
            return entidadDocumento;
        }

        private void GuardarFactura()
        {
            if (ValidarCabecera() == false) return;
            
            bool EsExistoso = false;
            EsExistoso = GuardarCabeceraDocumento();
            
            if (EsExistoso == true)
            {
                // == 1.Bloqueo todo los controles de ingreso de datos
                ActivaModoVer();

                // == 2.Ver botones de la cabecera del documento
                VerBotonesCabVer();

                // == 3.Ver botones del detalle del documento.                                
                VerBotonesDelDetalle();

                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;

                Estado = FormEstate.Edit;
                ComportarmientoBotones("cargar");
            }
        }

        private bool GuardarCabeceraDocumento()
        {
            
            Cursor.Current = Cursors.WaitCursor;

            //1.Iniciar flag de validacion de proceso
            bool procesoexitoso = false;

            try
            {
                DocumentoFA entidadDocumento = CargarEntidad();
                string MensajeRespuesta = "";
                int int_Flag = 0;

                if (Estado == FormEstate.New)
                {
                    DocumentoLogic.Instance.Spu_Fact_Ins_FAC04_CABFACTURA(entidadDocumento, out int_Flag, out MensajeRespuesta);
                }
                else if (Estado == FormEstate.Edit)
                {
                    DocumentoLogic.Instance.Spu_Fact_Upd_FAC04_CABFACTURA(entidadDocumento, out int_Flag, out MensajeRespuesta);
                }

                Util.ShowMessage(MensajeRespuesta, int_Flag);

                if (int_Flag == 1)
                {
                    //Refrescar grilla de Facturas
                    if(FrmParent != null)
                    {
                        FrmParent.Cargar();
                        Util.enfocarFila(FrmParent.gridControl, "FAC04NUMDOC", entidadDocumento.FAC04NUMDOC);
                        //Refresco cabecera
                        CargaDetalle();
                        // Traer detalle del  
                        traesubdetalle();
                    }                                                         
                    
                    Estado = FormEstate.Edit;                    
                    procesoexitoso = true;
                }


            }
            catch (Exception ex) {
                procesoexitoso = false;
                Util.ShowError(ex.Message);
            
            }

            Cursor.Current = Cursors.Default;

            return procesoexitoso;
        }
        //Generar Factura o boleta desde ua guia de remision
        private bool GuardarComprobantePagoDesdeGuiaRemision()
        {
            bool procesoExitoso = false;
            try
            {
                DocumentoFA entidadDocumento = CargarEntidad();
                //Generar XML
                #region "Generar XML"
                string[] str_ListaCampos = new string[gridControlDetalle.Rows.Count];
                int x = 0;
                foreach (GridViewRowInfo row in gridControlDetalle.Rows)
                {
                    str_ListaCampos[x] = Logueo.CodigoEmpresa + "|" +
                                         txttipdoc.Text.Trim() + "|" +
                                        txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim() + "|" +
                                        (x + 1) + "|" +
                                        Util.GetCurrentCellText(row, "FAC05CODPROD") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05DESCPROD") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05UNIMED") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05CANTIDAD") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05PRECIO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05SUBTOTAL") + "|" +

                                        // Campos llenado con valor por defecto
                                        Util.GetCurrentCellText(row, "FAC05PARTARAN") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05PESO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05PESOADUANA") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05NROCAJA") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05SUBGRUPO") + "|" +

                                        // Campos ocultos de facturacion electronica
                                        Util.GetCurrentCellText(row, "FAC05FECODRAZEXONERACION") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEIMPDSCTO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FECODIMPREF") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEPRODUCTOTIPO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEIMPORTEREFERENCIAL") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEIMPORTECARGO") + "|" +

                                        Util.GetCurrentCellText(row, "FAC05GUIATIPDOC") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05GUIANUMERO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05GUIAITEM") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FECODPRODSUNAT") + "|" +
                                        txtIgvPercent.Text.Trim() + "|" +
                                        Util.GetCurrentCellText(row, "FAC05CODPROD_PROV") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05DESPROD_PROV") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05UNIMED_PROV");
                                        
                    x++;
                }
                #endregion
                string xml = Util.ConvertiraXMLdinamico(str_ListaCampos);
                int int_flag = 0;
                string str_mensaje = "";

                DocumentoLogic.Instance.GuardarGuiaRemisionEnComprobantePago(entidadDocumento, xml, out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1)
                {
                    #region "Acciones despues de insercion exitosa"
                    procesoExitoso = true;
                    EsModoGuiaTransporte = false;

                    traesubdetalle();
                    traeCuotasFactura();

                    // == Ver los botones de Guardar, Cancelar, Importar y Exportar.   
                    // == de la cabecera de la factura
                    VerBotonesCabVer();
                    // == Bloquear controles de la cabecera , oclutar, 
                    // == botones e inhabilitar botones de cabecera detalle
                    ActivaModoVer();

                    // == Muestra los botones y activampos todos
                    VerBotonesDelDetalle();
                    ActivarBotonesDelDetalle();

                    // == Deshabilitar los botones de Grabar y cancelar.                    
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;

                    if (FrmParent != null)
                    {
                        //Refrescar grilla de facturas
                        FrmParent.Cargar();
                    }
                    else if (FrmParentFacturaxGuia != null)
                    {
                        // Refrescar la grilla de Generar facturas desde Guia 
                        FrmParentFacturaxGuia.Oncargar();
                    }

                    // == Asignar origen al comportamiento desde frmFacturacab.cs
                    TipoOrigen = OrigenInstancia.Principal;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar comprobante desde guia de remision," + ex.Message);
                procesoExitoso = false;
            }
            return procesoExitoso;
        }


        private void VerBotonesCabGuardar()
        {            
            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);         
        }
        private void VerBotonesCabCancelar()
        {           
            OcultarBotones();

            //HabilitaBotonPorNombre(BaseRegBotones.cbbGeneraPDF);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVerFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);         
        }
        private void VerBotonesCabVer()
        {            
            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbNavegacion);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCopiar);

            //HabilitaBotonPorNombre(BaseRegBotones.cbbGeneraPDF);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbDarBaja);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVerFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
            
        }

        private void GuardarFacturaTemporal()
        {
            try
            {
                // 1.Validar cabecera
                if (ValidarCabecera() == false) return;

                //====  2. validar detalle                
                if (this.gridControlDetalle.Rows.Count == 0)
                {
                    Util.ShowAlert("Debe ingresar registros");
                    return;
                }

                // ====  2.validacion que todas las filas tiene datos 
                foreach (GridViewRowInfo row in gridControlDetalle.Rows)
                {
                    if (ValidarDetalle(row) == false) return;
                }

                // ==== 2. validar valores de la cuotas
                if ((Util.NumerNoNegativo(txtcuotasnro.Text)) != "")
                {
                    Util.ShowAlert("Cuotas NO Valido");
                    return;
                }

                if ((Util.NumerNoNegativo(txtcuotadias.Text)) != "")
                {
                    Util.ShowAlert("Dias de Cuota NO Valido");
                    return;
                }

                //3.Guardar  el documento
                bool estado = GuardarComprobantePagoDesdeGuiaRemision();
                // 4.Si estado es exitoso
                if (estado == false) return;
                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        protected override void OnGuardar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GuardarPorOrigenInstancia(TipoOrigen);
                Cursor.Current = Cursors.Default;
               
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Util.ShowError(ex.Message);
            }
        }

        // ===
        void traerAyuda(enmAyuda tipo)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                frmBusqueda frm;
                string[] datos;

                switch (tipo)
                {
                    #region "Datos Generales"
                    case enmAyuda.enmFactCab_SubPlantilla:

                        frm = new frmBusqueda(tipo, tipoDocumento);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtsubplantilla.Text = datos[0];
                        LblHelp0.Text = datos[1];
                        txtcodplantilla.Text = datos[3];
                        txttipoarticulo.Text = datos[6];
                        txttipdoc.Text = datos[2];
                        txtserie.Text = datos[5];
                        txttipoventa.Text = datos[7];
                        txtTipoOperacionFE.Text = datos[8];
                        ActivarDesactivarTab(txttipoventa.Text.Trim());

                        

                        string sNroDocumento = "";
                        GlobalLogic.Instance.DameNroDocumento(Logueo.CodigoEmpresa,
                                            txttipdoc.Text.Trim(), txtserie.Text.Trim(), out sNroDocumento);
                        txtNumeroDocumento.Text = sNroDocumento;

                        //Trae codigo anexo emisor       
                        string anexocod = "";
                        GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + tipoDocumento + txtserie.Text, "ESTABLECIMIENTO", out anexocod);
                        txtCodigoAnexoEmisorFE.Text = anexocod;

                                                
                        break;
                    case enmAyuda.enmFactCab_TipoAnalisis:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txttipanalisis.Text = datos[0];
                        LblHelp1.Text = datos[1];
                        TxtCliente.Focus();

                        //txttipanalisis.Focus();
                        break;
                    case enmAyuda.enmFactCab_Cliente:
                        frm = new frmBusqueda(tipo, txttipanalisis.Text);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        TxtCliente.Text = datos[0];
                        txtRazon.Text = datos[1];
                        TxtRuc.Text = datos[3];
                        txtDireccion.Text = datos[2];
                        txtmoneda.Focus();
                        //TxtCliente.Focus();
                        break;
                    case enmAyuda.enmDetraccionCod:
                        frm = new frmBusqueda(tipo, dtpFechaDoc.Text);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtdetraccionCodServ.Text = datos[0];
                        LblHelpDetraccion.Text = datos[1];
                        txtdetraccionPorcentaje.Text = datos[2];
                        txtdetraccionImporte.Text = "0";
                        TxtObservacion.Focus();
                        //TxtCliente.Focus();
                        break;
                    case enmAyuda.enmFormaPagoSunat:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtformapagosunat.Text = datos[0];
                        LblhelpFormapagosunat.Text = datos[1];

                        if (txtformapagosunat.Text == "02") // Si es credito habilito grupo de credito
                        {
                            gbpagocredito.Enabled = true;
                        }
                        else
                        {
                            gbpagocredito.Enabled = false;
                            txtcuotasnro.Text = "0";
                            txtcuotadias.Text = "0";
                            
                        }
            
                        //txtmoneda.Focus();
                        txtTipoCambio.Focus();
                        break;
                    case enmAyuda.enmFactCab_Moneda:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtmoneda.Text = datos[0];
                        LblHelp2.Text = datos[1];
                        //txtmoneda.Focus();
                        txtTipoCambio.Focus();
                        break;
                    case enmAyuda.enmFactCab_Tienda:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtcodtienda.Text = datos[0];
                        LblHelp4.Text = datos[1];
                        txtcodtienda.Focus();
                        break;
                    case enmAyuda.enmFactCab_Vendedor:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtcodvendedor.Text = datos[0];
                        LblVendedorNombre.Text = datos[1];
                        txtcodvendedor.Focus();
                        break;
                    #endregion
                    #region "Datos de exportacion"
                    case enmAyuda.enmFactCab_ExpPaisOrigen:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtExpPaisOrigen.Text = datos[0];
                        LblHelp5.Text = datos[1];
                        txtExpPaisOrigen.Focus();
                        break;
                    case enmAyuda.enmFactCab_ExpPaisDestino:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtExpPaisDestino.Text = datos[0];
                        LblHelp6.Text = datos[1];
                        break;
                    case enmAyuda.enmFactCab_ExpCondPago:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtExpCondPago.Text = datos[0];
                        LblHelp7.Text = datos[1];
                        //txtExpCondPago.Focus();
                        txtordcompra.Focus();
                        break;
                    case enmAyuda.enmFactCab_ExpConDespacho:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtExpConDespacho.Text = datos[0];
                        LblHelp8.Text = datos[1];
                        txtExpConDespacho.Focus();
                        break;
                    case enmAyuda.enmFactCab_ExpPuertoEmbarque:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtExpPuertoEmbarque.Text = datos[0];
                        LblHelp9.Text = datos[1];
                        txtExpPuertoEmbarque.Focus();
                        break;
                    case enmAyuda.enmFactCab_ExpPuertoEmbarqueDes:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtExpPuertoEmbarqueDes.Text = datos[0];
                        LblHelp12.Text = datos[1];
                        txtExpPuertoEmbarqueDes.Focus();
                        break;
                    case enmAyuda.enmFactCab_ExpBancoLocal:

                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtExpBancoLocal.Text = datos[0];
                        txtExpBankCode.Text = datos[2];
                        txtExpAccountNumber.Text = datos[3];
                        LblHelp10.Text = datos[1];
                        txtExpBancoLocal.Focus();
                        break;
                    #endregion
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        #endregion
        #region "Metodos-tabla Proveedor"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Flag de detalle Nuevo
            InsertaroActualizarDetalle = "N";
            // Capturo ultima columna visible de la grilla de detalle
            ultimacolumnavisibledelagrilla = ObtenerUltimaColumnaVisible();

            // Agrego Fila
            AgregarFila();

            OcultarBotones();
            DesactivaTodoBootonesCabDetalle();
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        void traesubdetalle()
        {
            gridControlDetalle.DataSource = DocumentoLogic.Instance.TraerDetalleFactura(Logueo.CodigoEmpresa,
               txtserie.Text + "-" + txtNumeroDocumento.Text, txttipdoc.Text);
        }

        void traeCuotasFactura()
        {
            gridcuotas.DataSource = DocumentoLogic.Instance.TraerCuotasFactura(Logueo.CodigoEmpresa,
                txttipdoc.Text, txtserie.Text + "-" + txtNumeroDocumento.Text);
        }
        void SeleccionarFilaCompleta(RadGridView Grid)
        {
            Grid.SelectionMode = GridViewSelectionMode.FullRowSelect;
        }

        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
                                            bool bCancelar, bool bEliminar, bool bEditar)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelarDet":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminarDet":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.delete_enabled : Properties.Resources.delete_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditarDet":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edit_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;

                default:
                    break;
            }
        }

        void CrearColumnas()
        {
            bool bVisibleON = true, bVisibleOFF = false, bEditableON = true,
                bEditableOFF = false, bReadOnlyON = true, bReadOnlyOFF = false;
            RadGridView Grid = CreateGridVista(gridControlDetalle);
            // Quitar el filtro , para acortar cabecera de descripcion
            Grid.EnableFiltering = false;

            CreateGridColumn(Grid, "Empresa", "FAC05CODEMP", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "Codigo", "FAC01COD", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "Nro.Doc", "FAC04NUMDOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)

            // Nro de Guia
            CreateGridColumn(Grid, "Guia", "FAC05GUIANUMERO", 0, "", 80, bReadOnlyON, bEditableOFF, bVisibleOFF);//FAC34NROGUIA

            CreateGridColumn(Grid, "Cod.Det", "FAC05CODFACDET", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//int()

            CreateGridColumn(Grid, "Codigo", "FAC05CODPROD", 0, "", 110, bReadOnlyOFF, bEditableON, bVisibleON);//varchar(20)
            CreateGridColumn(Grid, "Descripcion", "FAC05DESCPROD", 0, "", 300, bReadOnlyOFF, bEditableON, bVisibleON);//varchar(250)
            CreateGridColumn(Grid, "Uni", "FAC05UNIMED", 0, "", 35, bReadOnlyOFF, bEditableON, bVisibleON);//varchar(5) 
            CreateGridColumn(Grid, "Cant.", "FAC05CANTIDAD", 0, "{0:###,###0.00}", 100, bReadOnlyOFF, bEditableON, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "Precio", "FAC05PRECIO", 0, "{0:###,###0.000000}", 130, bReadOnlyOFF, bEditableON, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "Sub Total", "FAC05SUBTOTAL", 0, "{0:###,###0.00}", 100, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");//float()
            
            CreateGridColumn(Grid, "Dscto", "FAC05FEIMPDSCTO", 0, "{0:###,###0.000000}", 130, bReadOnlyOFF, bEditableON, bVisibleON, true, "right");//float()
            
            CreateGridColumn(Grid, "Igv", "FAC05IGV", 0, "{0:###,###0.00}", 100, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");//float()
            

            CreateGridColumn(Grid, "Total", "FAC05IMPTOTAL", 0, "{0:###,###0.00}", 100, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");//float()
            

            CreateGridColumn(Grid, "N.Caja", "FAC05NROCAJA", 0, "{0:###,###0.00}", 60, bReadOnlyOFF, bEditableON, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "P.Planta ", "FAC05PESO", 0, "{0:###,###0.00}", 100, bReadOnlyOFF, bEditableON, bVisibleOFF, true, "right");//float()
            CreateGridColumn(Grid, "P.Aduana", "FAC05PESOADUANA", 0, "{0:###,###0.00}", 100, bReadOnlyOFF, bEditableON, bVisibleON, true, "right");//float()
            
            CreateGridColumn(Grid, "Part.Arancel", "FAC05PARTARAN", 0, "", 50, bReadOnlyOFF, bEditableON, bVisibleON);//varchar()
            CreateGridColumn(Grid, "SubGrupo", "FAC05SUBGRUPO", 0, "", 90, bReadOnlyOFF, bEditableON, bVisibleOFF);//varchar   

            // Campos ocultos
            CreateGridColumn(Grid, "FAC05FECODRAZEXONERACION", "FAC05FECODRAZEXONERACION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FECODIMPREF", "FAC05FECODIMPREF", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FEPRODUCTOTIPO", "FAC05FEPRODUCTOTIPO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FEIMPORTEREFERENCIAL", "FAC05FEIMPORTEREFERENCIAL", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(15)
            CreateGridColumn(Grid, "FAC05FEIMPORTECARGO", "FAC05FEIMPORTECARGO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char

            

            CreateGridColumn(Grid, "GuiaTipDoc", "FAC05GUIATIPDOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//FAC01COD
            CreateGridColumn(Grid, "GuiaItem", "FAC05GUIAITEM", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//FAC35CODGUIADET                    
            CreateGridColumn(Grid, "FAC05FECODPRODSUNAT", "FAC05FECODPRODSUNAT", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FEIGVTASA", "FAC05FEIGVTASA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            
            //Campos ocultos
            CreateGridColumn(Grid, "CodigoProdProv", "FAC05CODPROD_PROV", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "DescProdProv", "FAC05DESPROD_PROV", 0, "", 150, true, false, true);
            CreateGridColumn(Grid, "UniProdProv", "FAC05UNIMED_PROV", 0, "", 70, true, false, true);
            
            //CreateGridColumn(Grid, ""
            //Personalizar columnas
            //Dar formato de mascara de 6 decimales a columna precio
            GridViewDataColumn columnaPrecio = this.gridControlDetalle.Columns["FAC05PRECIO"];
            ((GridViewMaskBoxColumn)columnaPrecio).Mask = "f6";

                        //Columnas para la sumatoria

            // Columnas agregado para el mantenimiento de la grilla
            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 90, true, false, false);
            if (FrmParent != null)
            {
                AddButonsToGrid();
            }
            else if (FrmParent == null)
            {
                AddButtonsToGrid2();
            }
            if (gridControlDetalle.MasterView.SummaryRows.Count == 0)
            {
                string[] fieldstosummary = { "FAC05CANTIDAD","FAC05SUBTOTAL","FAC05IGV","FAC05IMPTOTAL", "FAC05PESO", "FAC05PESOADUANA","FAC05NROCAJA"};

                Util.AddGridSummarySum(gridControlDetalle, fieldstosummary);
            }

        }
        void CrearColumnasCuotas()
        {
            bool bVisibleON = true, bVisibleOFF = false, bEditableON = true,
                bEditableOFF = false, bReadOnlyON = true, bReadOnlyOFF = false;
            RadGridView Grid = CreateGridVista(gridcuotas);
            // Quitar el filtro , para acortar cabecera de descripcion
            Grid.EnableFiltering = false;

            CreateGridColumn(Grid, "Empresa", "FAC12CODEMP", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "Codigo", "FAC12COD", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "Nro.Doc", "FAC12NUMDOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "Nro Cuota", "FAC12CUOTANRO", 0, "", 30, bReadOnlyON, bEditableOFF, bVisibleON);//FAC34NROGUIA
            CreateGridColumn(Grid, "Dias", "FAC12DIAS", 0, "", 30, bReadOnlyON, bEditableOFF, bVisibleON);//int()
            CreateGridColumn(Grid, "Fecha", "FAC12FECHA", 0, "{0:dd/MM/yyyy}", 90, bReadOnlyON, bEditableOFF, bVisibleON);//varchar(20)
            CreateGridColumn(Grid, "Cuota", "FAC12IMPORTECUOTANETO", 0, "{0:###,###0.000000}", 100, bReadOnlyOFF, bEditableOFF, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "Base", "FAC12IMPORTEBASE", 0, "{0:###,###0.000000}", 100, bReadOnlyOFF, bEditableOFF, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "IGV", "FAC12IMPORTEIGV", 0, "{0:###,###0.000000}", 100, bReadOnlyOFF, bEditableOFF, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "DCTO DETRACCION", "FAC12IMPORTEDETRACCION", 0, "{0:###,###0.000000}", 100, bReadOnlyOFF, bEditableOFF, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "DCTO RETENCION", "FAC12IMPORTERETENCION", 0, "{0:###,###0.000000}", 100, bReadOnlyOFF, bEditableOFF, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "DCTO OTROS", "FAC12IMPORTEOTROSDCTOS", 0, "{0:###,###0.000000}", 100, bReadOnlyOFF, bEditableOFF, bVisibleON, true, "right");//float()

            //Columnas para la sumatoria
            // Columnas agregado para el mantenimiento de la grilla
            
            if (gridcuotas.MasterView.SummaryRows.Count == 0)
            {
                string[] fieldstosummary = { "FAC12IMPORTECUOTANETO", "FAC12IMPORTEBASE", "FAC12IMPORTEIGV", "FAC12IMPORTEDETRACCION", "FAC12IMPORTERETENCION", "FAC12IMPORTEOTROSDCTOS" };

                Util.AddGridSummarySum(gridcuotas, fieldstosummary);
            }

        }
        private void VerColumnasPorPlantilla(string parCodigoPlantilla)
        {            
            //leer el flag de productos de cliente relacionado a producto deisi
            
            if (parCodigoPlantilla == "01") // Plantilla Exportacion 
            {
                // Campos llenado con valor por defecto
                gridControlDetalle.Columns["FAC05PARTARAN"].IsVisible = true;
                gridControlDetalle.Columns["FAC05PARTARAN"].ReadOnly = false;

                gridControlDetalle.Columns["FAC05NROCAJA"].IsVisible = true;
                gridControlDetalle.Columns["FAC05NROCAJA"].ReadOnly = false;

                //gridControlDetalle.Columns["FAC05PESO"].IsVisible = true;
                //gridControlDetalle.Columns["FAC05PESO"].ReadOnly = false;

                gridControlDetalle.Columns["FAC05PESOADUANA"].IsVisible = true;
                gridControlDetalle.Columns["FAC05PESOADUANA"].ReadOnly = false;

                gridControlDetalle.Columns["FAC05SUBGRUPO"].IsVisible = false;
                gridControlDetalle.Columns["FAC05SUBGRUPO"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05FEIMPDSCTO"].IsVisible = false;
                gridControlDetalle.Columns["FAC05FEIMPDSCTO"].ReadOnly = true;
            }
            else if (parCodigoPlantilla == "02") // Plantilla Venta Nacional
            {
                gridControlDetalle.Columns["FAC05PARTARAN"].IsVisible = false;
                gridControlDetalle.Columns["FAC05PARTARAN"].ReadOnly = true;

                //gridControlDetalle.Columns["FAC05PESO"].IsVisible = false;
                //gridControlDetalle.Columns["FAC05PESO"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05NROCAJA"].IsVisible = false;
                gridControlDetalle.Columns["FAC05NROCAJA"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05PESOADUANA"].IsVisible = false;
                gridControlDetalle.Columns["FAC05PESOADUANA"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05SUBGRUPO"].IsVisible = false;
                gridControlDetalle.Columns["FAC05SUBGRUPO"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05FEIMPDSCTO"].IsVisible = true;
                gridControlDetalle.Columns["FAC05FEIMPDSCTO"].ReadOnly = false;
                
            }
            else if (parCodigoPlantilla == "03") // Plantilla Servicio Nacional
            {

                gridControlDetalle.Columns["FAC05PARTARAN"].IsVisible = false;
                gridControlDetalle.Columns["FAC05PARTARAN"].ReadOnly = true;

                //gridControlDetalle.Columns["FAC05PESO"].IsVisible = false;
                //gridControlDetalle.Columns["FAC05PESO"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05NROCAJA"].IsVisible = false;
                gridControlDetalle.Columns["FAC05NROCAJA"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05PESOADUANA"].IsVisible = false;
                gridControlDetalle.Columns["FAC05PESOADUANA"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05SUBGRUPO"].IsVisible = false;
                gridControlDetalle.Columns["FAC05SUBGRUPO"].ReadOnly = true;

                gridControlDetalle.Columns["FAC05FEIMPDSCTO"].IsVisible = true;
                gridControlDetalle.Columns["FAC05FEIMPDSCTO"].ReadOnly = false;
            }
        }
        private void EliminarDetalleAnticipo(string TipoDocumento, string NumeroDocumento,
            string NumeroItem)
        { 
            
        }
        private void EliminarDetallePorNroGuia(string FacturaTipoDocumento, string FactNumeroDocumento, 
                                 string GuiaTipDocumento, string GuiaNroDocumento, int GuiaCodigoDetalle)
        {
            try
            {
                StringBuilder mensaje = new StringBuilder();
                mensaje.AppendLine("El origen de este registro es una Guia");
                mensaje.AppendLine("Si marca la opcion SI, eliminara los detalle relacionado al numero de Guia");
                //mensaje.AppendLine("Si marca la opcion NO, eliminara solo el registro seleccionado");

                int int_flag = 0; string str_mensaje = "";
                bool respuesta = Util.ShowQuestion(mensaje.ToString());

                if (respuesta == true)
                {
                    DocumentoLogic.Instance.EliminarDetFacturaPorGuiaDetalle(Logueo.CodigoEmpresa, FacturaTipoDocumento,
                       FactNumeroDocumento, GuiaTipDocumento, GuiaNroDocumento, GuiaCodigoDetalle, "S", out int_flag, out str_mensaje);
                }
                else { 
                    // No eliminar  registro
                }
              

                if (respuesta == true)
                    Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                {
                    traesubdetalle();
                    //  == 1.Validar si la instancia es de frmFacturas 
                    if (FrmParent != null)
                    {
                        // 2.Refresacar 
                        FrmParent.Cargar();
                    }
                }


            }
            catch (Exception ex)
            {
                Util.ShowAlert(ex.Message);
            }
        }
        private void EliminarDetallePorCodigoDetalleFactura(string CodigoTipoDocumento, string NumeroDocumento, 
                                                            int CodigoFacturaDetalle)
        {
            try
            {

                string mensajePregunta = "";
                mensajePregunta = "¿Desea eliminar el registro?";

                int flagExito = 0;
                string MensajeSistema = "";
                bool respuesta = Util.ShowQuestion(mensajePregunta);
                if (respuesta == true)
                {
                    DocumentoLogic.Instance.Spu_Fact_Del_FAC05_DETFACTURA(Logueo.CodigoEmpresa, CodigoTipoDocumento,
                                                        NumeroDocumento, CodigoFacturaDetalle, out flagExito, out MensajeSistema);

                    Util.ShowMessage(MensajeSistema, flagExito);
                    if (flagExito == 1)
                    {
                        traesubdetalle();
                        // 1.Validar si este formulario es hijo de frmFacturas(Padre).
                        if (FrmParent != null)
                        {
                            // 2.Refrescar la grilla de frmFacturas(Padre).
                            FrmParent.Cargar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowAlert(ex.Message);
            }
        }
        private void EliminarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                string GuiaTipoDocumento = Util.GetCurrentCellText(gridControlDetalle, "FAC05GUIATIPDOC");
                string GuiaNumero = Util.GetCurrentCellText(gridControlDetalle, "FAC05GUIANUMERO");
                string GuiaItem = Util.GetCurrentCellText(gridControlDetalle, "FAC05GUIAITEM");

                string str_TipDocuCodigo = Util.GetCurrentCellText(gridControlDetalle, "FAC01COD");
                string str_NumeroDocumento = Util.GetCurrentCellText(gridControlDetalle, "FAC04NUMDOC");
                int int_CodigoFacturaDetalle = Util.GetCurrentCellInt(gridControlDetalle, "FAC05CODFACDET");
                string flag = Util.GetCurrentCellText(gridControlDetalle, "flag");
                string tipoDetalle = Util.GetCurrentCellText(gridControlDetalle, "TipoDetalle");
                //Valida si el registro a eliminar es una guardado o no                 

                //Valido si el registro seleccionado viene de un detalle de guia.
                //Si el detalle no tiene relacion con NroGuia , entonces, elimino por detalle de factrau
                //if (GuiaNumero == "" && (GuiaItem == "" || GuiaItem == "0"))
                int flagEstado = 0; string mensaje = "";
                if (tipoDetalle == "A") // es detalle de Anticipo de Factura
                {
                    if (Util.ShowQuestion("¿Desea elminar el registro?") == true)
                    {
                        DocumentoLogic.Instance.EliminarFacturaAnticipo(Logueo.CodigoEmpresa, str_TipDocuCodigo,
                             str_NumeroDocumento, int_CodigoFacturaDetalle, out mensaje, out flagEstado);
                        Util.ShowMessage(mensaje, flagEstado);
                        //operacion exitosa es exitosa, entonces, refrescar grilla.
                        if (flagEstado == 1)
                        {
                            traesubdetalle();
                        }
                    }
                }else { 
                    if (flag == "0") // Eliminar detalle sin grabar
                    {
                        this.gridControlDetalle.Rows.RemoveAt(this.gridControlDetalle.CurrentRow.Index);
                    }
                    else
                    {
                    
                        if (GuiaNumero == "")
                        {
                            EliminarDetallePorCodigoDetalleFactura(str_TipDocuCodigo, str_NumeroDocumento, int_CodigoFacturaDetalle);
                        }// Si viene de un detalle entonces, eliminar desde el metodo Eliminar Detalle Por  Nro de Guia
                        //else if (GuiaNumero != "" && (GuiaItem != "" || GuiaItem != "0"))
                        else if (GuiaNumero != "")
                        {
                            int int_GuiaItem = Convert.ToInt32(GuiaItem);
                            EliminarDetallePorNroGuia(str_TipDocuCodigo, str_NumeroDocumento, GuiaTipoDocumento, GuiaNumero, int_CodigoFacturaDetalle);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void CancelarDetalle()
        {
            traesubdetalle();
        }
        
        private void calculartotales()
        {
            double dbl_cantidad = Util.GetCurrentCellDbl(gridControlDetalle, "FAC05CANTIDAD");
            double dbl_precio = Util.GetCurrentCellDbl(gridControlDetalle, "FAC05PRECIO");
            double dbl_descuento = Util.GetCurrentCellDbl(gridControlDetalle, "FAC05FEIMPDSCTO");

            double dbl_subtotal = 0, dbl_total = 0;
            
            //double dbl_importe = 0;
            
            if (txtIgvPercent.Text == "")
            {
                txtIgvPercent.Text = "0";
            }

            double dbl_igv = Convert.ToDouble(txtIgvPercent.Text) / 100;

            dbl_subtotal = (Math.Round((dbl_cantidad * dbl_precio),2) - dbl_descuento);
            
            dbl_total = Math.Round(dbl_subtotal + Math.Round((dbl_subtotal * dbl_igv),2),2);

            //dbl_importe = dbl_cantidad * dbl_precio;
            Util.SetValueCurrentCellDbl(gridControlDetalle, "FAC05SUBTOTAL", dbl_subtotal);
            Util.SetValueCurrentCellDbl(gridControlDetalle, "FAC05IGV", dbl_igv * dbl_subtotal);
            Util.SetValueCurrentCellDbl(gridControlDetalle, "FAC05IMPTOTAL", dbl_total);

        }
        private void AgregarFila()
        {
            try
            {
                //
                if (gridControlDetalle.Rows.Count > 0)
                {
                    //validar la fila  anterior tiene valores ingresados
                    if (ValidarDetalle(gridControlDetalle.CurrentRow) == false) return;
                }

                //
                gridControlDetalle.Rows.AddNew();
                GridViewRowInfo row = this.gridControlDetalle.CurrentRow;

                //Inicio de valores por defecto  de campos para la plantilla factura
                Util.SetValueCurrentCellText(row, "FAC05CODEMP", Logueo.CodigoEmpresa);
                Util.SetValueCurrentCellText(row, "FAC01COD", txttipdoc.Text.Trim());
                Util.SetValueCurrentCellText(row, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());

                Util.SetValueCurrentCellText(row, "FAC05CODPROD", "");
                Util.SetValueCurrentCellText(row, "FAC05DESCPROD", "");
                Util.SetValueCurrentCellText(row, "FAC05UNIMED", "");

                Util.SetValueCurrentCellDbl(row, "FAC05PRECIO", 0);
                Util.SetValueCurrentCellDbl(row, "FAC05SUBTOTAL", 0);
                Util.SetValueCurrentCellInt(row, "FAC05CODFACDET", 0);
                Util.SetValueCurrentCellText(row, "FAC05FEIGVTASA", txtIgvPercent.Text);

                Util.SetValueCurrentCellText(row, "flag", "0");
                Util.SetValueCurrentCellText(row, "flagBotones", "E");
                // Asignar valores por tipo de documento                
                TraerValoresDefectoxTipDocuyPlantilla(row);

                // Enfocar al fila y la celda de la nueva fila
                
                
                this.gridControlDetalle.Focus();                
                Util.ResaltarAyuda(this.gridControlDetalle, "FAC05CODPROD");
                //Util.SetCellGridFocus(row, "FAC05CODPROD");
                Util.SetCellInitEdit(gridControlDetalle, "FAC05CODPROD");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }

            

        }
        // Asignar valores por defecto a los campos de nuevo registro
        void TraerValoresDefectoxTipDocuyPlantilla(GridViewRowInfo row)
        {
            if (FrmParentFacturaxGuia != null)
            {
                if (txtcodplantilla.Text == "01")
                {
                    Util.SetValueCurrentCellDbl(row, "FAC05CANTIDAD", 0);
                    Util.SetValueCurrentCellText(row, "FAC05PARTARAN", "68.02.21.00.00");
                    Util.SetValueCurrentCellDbl(row, "FAC05PESO", 0);
                    Util.SetValueCurrentCellDbl(row, "FAC05PESOADUANA", 0);
                    Util.SetValueCurrentCellDbl(row, "FAC05NROCAJA", 0);
                    Util.SetValueCurrentCellText(row, "FAC05SUBGRUPO", "");
                }
            }
            else if (FrmParentFacturaxGuia == null)
            {
                // Si el tipo de documento es factura
                if (FrmParent.EstadoDocumento == BaseTipoDocumento.enmFactura)
                {

                    // Tabla de Plantilla
                    /*
                     01	VENTA CON : PLANTILLA DE EXPORTACION
                     02	PLANTILLA GUIAS NACIONAL
                     03	PLANTILLA GUIAS OTROS
                     */
                    if (txtcodplantilla.Text == "01")
                    {
                        Util.SetValueCurrentCellDbl(row, "FAC05CANTIDAD", 0);
                        Util.SetValueCurrentCellText(row, "FAC05PARTARAN", "68.02.21.00.00");
                        Util.SetValueCurrentCellDbl(row, "FAC05PESO", 0);
                        Util.SetValueCurrentCellDbl(row, "FAC05PESOADUANA", 0);
                        Util.SetValueCurrentCellDbl(row, "FAC05NROCAJA", 0);
                        Util.SetValueCurrentCellText(row, "FAC05SUBGRUPO", "");
                    }
                    else if (txtcodplantilla.Text == "02")
                    {
                        Util.SetValueCurrentCellDbl(row, "FAC05CANTIDAD", 1);
                    }
                    else if (txtcodplantilla.Text == "03")    
                    {
                        Util.SetValueCurrentCellDbl(row, "FAC05CANTIDAD", 1);
                    }


                }
                else if (FrmParent.EstadoDocumento == BaseTipoDocumento.enmBoleta)
                {
                    Util.SetValueCurrentCellDbl(row, "FAC05CANTIDAD", 0);
                }
            }
            
        }
        private void AddButonsToGrid()
        {

            if (FrmParent.EstadoDocumento == BaseTipoDocumento.enmFactura
                || FrmParent.EstadoDocumento == BaseTipoDocumento.enmBoleta)
            {                                
                AddCmdButtonToGrid(gridControlDetalle, "btnEliminarDet", "", "btnEliminarDet");                
            }
            else if (FrmParent.EstadoDocumento == BaseTipoDocumento.enmNotaCredito ||
                     FrmParent.EstadoDocumento == BaseTipoDocumento.enmNotaDebito)
            {
                AddCmdButtonToGrid(gridControlDetalle, "btnGrabarDet", "", "btnGrabarDet");
                AddCmdButtonToGrid(gridControlDetalle, "btnCancelarDet", "", "btnCancelarDet");
                AddCmdButtonToGrid(gridControlDetalle, "btnEliminarDet", "", "btnEliminarDet");
                AddCmdButtonToGrid(gridControlDetalle, "btnEditarDet", "", "btnEditarDet");
            }

        }
        private void AddButtonsToGrid2()
        {
            if (FrmParentFacturaxGuia.EstadoDocumento == BaseTipoDocumento.enmBoleta ||
                FrmParentFacturaxGuia.EstadoDocumento == BaseTipoDocumento.enmFactura)
            {
                AddCmdButtonToGrid(gridControlDetalle, "btnEliminarDet", "", "btnEliminarDet");
            }
        }
        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
            //Grid.Columns[NameButon].BestFit();
        }
        private void deshabilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":

                    cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnCancelarDet":
                    cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;

                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEliminarDet":
                    cellElement.CommandButton.Image = Properties.Resources.delete_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEditarDet":
                    cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                default:
                    break;
            }

        }
        private int HasRowToSave()
        {
            int rowsaffected = 0;

            foreach (GridViewRowInfo row in gridControlDetalle.Rows)
            {
                if (Util.GetCurrentCellText(row, "flagBotones") == "E")
                    rowsaffected++;
            }
            return rowsaffected;
        }
        private bool Validar_fecha_vs_periodo(DateTime fecha, string periodoactivo)
        {
            string str_mesdefecha;
            string str_aniodefecha;
            //inicializo la funcion
            bool b_flag = false;
            str_mesdefecha = fecha.Month.ToString();
            if (str_mesdefecha.Length == 2)
            {
                str_mesdefecha = fecha.Month.ToString();
            }
            else
            {
                str_mesdefecha = "0" + str_mesdefecha;
            }
            str_aniodefecha = fecha.Year.ToString();

            if (Convert.ToDouble(str_aniodefecha + str_mesdefecha) == Convert.ToDouble(periodoactivo))
            {

            }
            else
            {
                if (Convert.ToDouble(str_aniodefecha + str_mesdefecha) > Convert.ToDouble(periodoactivo))
                {
                    Util.ShowAlert("Error: Fecha no valida.Posiblemente sea de un periodo posterior al periodo actual, DEBE CORREGIR LA FECHA PARA SEGUI TRABAJANDO");
                    b_flag = true;
                }
                else
                {
                    bool respuesta = Util.ShowQuestion("Error: Fecha No Valida.Posiblemente Sea De Un Periodo Anterior Al Periodo Actual,¿ESTA SEGURO QUE LA FECHA QUE ESTA INGRESANDO ES CORRECTA?");
                    if (respuesta == true)
                        b_flag = false;
                    else
                        b_flag = true;

                }

            }
            return b_flag;
        }
        #endregion
        void ActivarBotonesDelDetalle()
        {
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            btnEditar.Enabled = true;
            btnNuevoGuia.Enabled = true;
            btnAdd.Enabled = true;
            
        }
        void DesactivaTodoBootonesCabDetalle()
        {
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnNuevoGuia.Enabled = false;
            btnAdd.Enabled = false;
            
        }                
        private bool TraerAyudaNuevoGuias()
        {
            bool procesoExitoso = false;
            try
            {
                // desactivar el boton nuevo normal


                //enmGuiaPendientePorFactura
                Cursor.Current = Cursors.WaitCursor;
                frmBusqueda frm;
                frm = new frmBusqueda(enmAyuda.enmGuiaPendientePorFactura, "");
                frm.ShowDialog();
                Cursor.Current = Cursors.Default;

                if (frm.Result != null)
                {

                    // Agregar despues del resto de filas.
                    // Iniciar variable de arreglo tipo cadena, y asignar el valor de nuestra busqueda.
                    string[] registros = ((string[])frm.Result);

                    // variable para almacenar los datos la busqueda
                    string[] datos;

                    for (int x = 0; x < registros.Length; x++)
                    {
                        datos = registros[x].ToString().Split('|');

                        //Traer los detalles de las guias seleccionadas
                        List<DetalleGuiaTransporte> Detalles = DocumentoLogic.Instance.TraeAyudaGuiaTransporte(datos[0].ToString(),
                                                                 datos[1].ToString(), datos[2].ToString());


                        // Asignar flag de Guia de transporte por traer registros desde ese documento.
                        EsModoGuiaTransporte = true;
                        // Agregar Nueva Fila.
                        for (int y = 0; y < Detalles.Count; y++)
                        {
                            GridViewRowInfo row = this.gridControlDetalle.Rows.AddNew();
                            Util.SetValueCurrentCellText(row, "FAC05CODEMP", Logueo.CodigoEmpresa);
                            Util.SetValueCurrentCellText(row, "FAC01COD", txttipdoc.Text.Trim());
                            Util.SetValueCurrentCellText(row, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());

                            Util.SetValueCurrentCellInt(row, "FAC05CODFACDET", 0);
                            Util.SetValueCurrentCellText(row, "FAC05CODPROD", Detalles[y].FAC35CODPROD);
                            Util.SetValueCurrentCellText(row, "FAC05DESCPROD", Detalles[y].FAC35DESCPROD);
                            Util.SetValueCurrentCellText(row, "FAC05UNIMED", Detalles[y].FAC35UNIMED);

                            Util.SetValueCurrentCellDbl(row, "FAC05PRECIO", 0);
                            Util.SetValueCurrentCellDbl(row, "FAC05SUBTOTAL", 0);
                            Util.SetValueCurrentCellDbl(row, "FAC05IGV", 0);
                            Util.SetValueCurrentCellDbl(row, "FAC05IMPTOTAL", 0);

                            Util.SetValueCurrentCellText(row, "FAC05GUIATIPDOC", txttipdoc.Text.Trim());
                            Util.SetValueCurrentCellText(row, "FAC05GUIANUMERO", Detalles[y].FAC34NROGUIA);
                            Util.SetValueCurrentCellText(row, "FAC05GUIAITEM", Detalles[y].FAC35CODGUIADET);

                            // Asignar valores por defecto por el tipo de documento
                            TraerValoresDefectoxTipDocuyPlantilla(row);

                            Util.SetValueCurrentCellDbl(row, "FAC05CANTIDAD", Detalles[y].FAC35CANTIDAD);
                            Util.SetValueCurrentCellDbl(row, "FAC05PESO", Detalles[y].FA35PESO);
                            Util.SetValueCurrentCellDbl(row, "FAC05NROCAJA", Detalles[y].FA35NROCAJAS);
                        }
                    }
                    procesoExitoso = true;
                }
                else if (frm.Result == null)
                {
                    // si no selecciona un registro, encontes, enviar proceso con valor false.
                    procesoExitoso = false;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
                procesoExitoso = false;
            }
            return procesoExitoso;
        }
        private void btnNuevoGuia_Click(object sender, EventArgs e)
        {
            // 1.Validar si frmfacturas es el formulario padre
            if (FrmParent != null)
            {
            
                //Validar si no tenemos Grabado una cabecera.
                if (ValidarCabeceraFacturaEstaGrabado() == false) return;

                //Flag de detalle Nuevo
                InsertaroActualizarDetalle = "N";
                // Capturo ultima columna visible de la grilla de detalle
                ultimacolumnavisibledelagrilla = ObtenerUltimaColumnaVisible();

                if (TraerAyudaNuevoGuias() == true)
                {

                    DesactivaTodoBootonesCabDetalle();
                    HabilitarEdicionDelDetalle();

                    // Activar los botones de la cabecera de la grilla.
                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
            }
            else if (FrmParent == null)
            {
                Util.ShowAlert("Esta opcion debe ser llamado desde otra opcion");
                return;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            // Sale no no acepta la cancelacion
            bool res = Util.ShowQuestion("NO se guardara ningun cambio, Esta seguro de cancelar?");
            if (res == false)
            {
                return;
            }


            // Refrescar
            EsModoGuiaTransporte = false;
            //retirar el valor de insertar o actualizar grilla antes de refrescar la grilla
            InsertaroActualizarDetalle = "";

            traesubdetalle();

            //Ver todo los botones de la cabecera del documento
            VerBotonesCabVer();

            //Ver todo los botones del detalle
            ActivarBotonesDelDetalle();
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            
        }
        // La funcion valida si este cabecera esta grabado
        bool ValidarCabeceraFacturaEstaGrabado()
        {
            //Validar si no tenemos Grabado una cabecera.
            if (txtsubplantilla.Enabled == true)
            {
                Util.ShowAlert("Debe guardar cabecera de documento");
                return false;
            }
            if (Estado == FormEstate.New)
            {
                Util.ShowAlert("Debe guardar cabecera de documento");
                return false;
            }
            return true;
        }



        private void GuardarDetGuiaEnDetFactura()
        {
            try
            {
                #region "Validacion"
                //valida debe tener registros en el detalle 
                if (this.gridControlDetalle.Rows.Count == 0)
                {
                    Util.ShowAlert("Debe ingresar registros");
                    return;
                }


                //validacion que todas las filas tengan los datos minimos
                foreach (GridViewRowInfo row in gridControlDetalle.Rows)
                {
                    if (ValidarDetalle(row) == false) return;
                }

                #endregion
                Cursor.Current = Cursors.WaitCursor;


                string[] str_ListaCampos = new string[gridControlDetalle.Rows.Count];
                int x = 0;

                //if (EsModoGuiaTransporte == false)
                //{
                #region "Construccion de xml"
                foreach (GridViewRowInfo row in gridControlDetalle.Rows)
                {
                    str_ListaCampos[x] = Logueo.CodigoEmpresa + "|" +
                                         txttipdoc.Text.Trim() + "|" +
                                        txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim() + "|" +
                                        (x + 1) + "|" +
                                        Util.GetCurrentCellText(row, "FAC05CODPROD") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05DESCPROD") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05UNIMED") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05CANTIDAD") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05PRECIO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05SUBTOTAL") + "|" +

                                        // Campos llenado con valor por defecto
                                        Util.GetCurrentCellText(row, "FAC05PARTARAN") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05PESO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05PESOADUANA") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05NROCAJA") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05SUBGRUPO") + "|" +

                                        // Campos ocultos de facturacion electronica
                                        Util.GetCurrentCellText(row, "FAC05FECODRAZEXONERACION") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEIMPDSCTO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FECODIMPREF") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEPRODUCTOTIPO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEIMPORTEREFERENCIAL") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FEIMPORTECARGO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05GUIATIPDOC") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05GUIANUMERO") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05GUIAITEM") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05FECODPRODSUNAT") + "|" +
                                        txtIgvPercent.Text.Trim() + "|"+
                                        Util.GetCurrentCellText(row, "FAC05CODPROD_PROV") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05DESPROD_PROV") + "|" +
                                        Util.GetCurrentCellText(row, "FAC05UNIMED_PROV");
                    x++;
                }
                #endregion
                // Procedimiento de grabar masivo
                string xml = Util.ConvertiraXMLdinamico(str_ListaCampos);
                int int_flag = 0;
                string str_mensaje = "";

                DocumentoLogic.Instance.InsertarGuiasDetalle(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(),
                txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), xml, out int_flag,
                out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1)
                {
                    #region "Acciones despues de insercion exitosa"
                    //limpiar flag de agregado masivvo antes refrescar refrescar la grilla
                    // el evento selectedchanged se dispara cuando se ejecuta el trasubdetalle
                    InsertaroActualizarDetalle = "";

                    //EsModoGuiaTransporte = false;
                    traesubdetalle();


                    // == Ver los botones de Guardar, Cancelar, Importar y Exportar.   
                    // == de la cabecera de la factura
                    VerBotonesCabVer();
                    // == Bloquear controles de la cabecera , oclutar, 
                    // == botones e inhabilitar botones de cabecera detalle
                    ActivaModoVer();
                    // == Muestra los botones y activampos todos
                    VerBotonesDelDetalle();
                    ActivarBotonesDelDetalle();

                    // == Deshabilitar los botones de Grabar y cancelar.
                    //OcultarBotonesDelDetalle();
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;


                    

                    // Refrescar la grilla de frmFacturas
                    if (FrmParent != null)
                    {
                        FrmParent.Cargar();
                        Util.enfocarFila(FrmParent.gridControl, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());
                    }
                    
                    // == Asignar origen al comportamiento desde frmFacturacab.cs
                    TipoOrigen = OrigenInstancia.Principal;
                    #endregion
                }
                //}
                //else
                //{
                //    Util.ShowAlert("Funciona para guardar masivo");
                //}
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle: " + ex.Message);
            }
        }

        
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GuardarDetGuiaEnDetFactura();  
        }
        void ResaltarControlesAyuda(bool resaltarControles)
        {
            if (resaltarControles == true)
            {
                Util.ResaltarAyuda(txtsubplantilla);
                Util.ResaltarAyuda(txttipanalisis);
                Util.ResaltarAyuda(txtmoneda);
                Util.ResaltarAyuda(txtdetraccionCodServ);
                Util.ResaltarAyuda(txtformapagosunat);
                Util.ResaltarAyuda(txtcodtienda);
                Util.ResaltarAyuda(txtcodvendedor);
                Util.ResaltarAyuda(TxtCliente);
                Util.ResaltarAyuda(txtExpPaisOrigen);
                Util.ResaltarAyuda(txtExpPaisDestino);
                Util.ResaltarAyuda(txtExpCondPago);
                Util.ResaltarAyuda(txtExpConDespacho);
                Util.ResaltarAyuda(txtExpPuertoEmbarque);
                Util.ResaltarAyuda(txtExpPuertoEmbarqueDes);
                Util.ResaltarAyuda(txtExpBancoLocal);

            }
            else
            {
                Util.ResetearAyuda(txtsubplantilla);
                Util.ResetearAyuda(txttipanalisis);
                Util.ResetearAyuda(txtmoneda);
                Util.ResetearAyuda(txtdetraccionCodServ);
                Util.ResetearAyuda(txtformapagosunat);
                Util.ResetearAyuda(txtcodtienda);
                Util.ResetearAyuda(txtcodvendedor);
                Util.ResetearAyuda(TxtCliente);
                Util.ResetearAyuda(txtExpPaisOrigen);
                Util.ResetearAyuda(txtExpPaisDestino);
                Util.ResetearAyuda(txtExpCondPago);
                Util.ResetearAyuda(txtExpConDespacho);
                Util.ResetearAyuda(txtExpPuertoEmbarque);
                Util.ResetearAyuda(txtExpPuertoEmbarqueDes);
                Util.ResetearAyuda(txtExpBancoLocal);
            }
        }
        void txtordcompra_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }
        void dtpFechaOrdCom_KeyDown(object sender, KeyEventArgs e)
        {
            //FocusNextControl(e);
            if (e.KeyValue == (char)Keys.Down)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyValue == (char)Keys.Up)
            {
                e.Handled = true;
                SendKeys.Send("+{TAB}");
            }
        }
        void dtpFechaOrdCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        void txtliquidacionnro_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        void TxtObservacion_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
            
        }

        //obtiene la ultima columan visible de la grilla detalle del documento
        private int ObtenerUltimaColumnaVisible()
        {
            int indiceMayor;
            indiceMayor=0;
            foreach (GridViewColumn col in this.gridControlDetalle.Columns)
            {
                if (col.IsVisible && !(col is GridViewCommandColumn))
                {
                    //indiceMayor = col.Index;
                    if (col.Index > indiceMayor)
                    {
                        indiceMayor = col.Index;
                    }
                }
            }
            return indiceMayor;
        }

        //Valida detalle de la grilla del documento
        private bool ValidarDetalle(GridViewRowInfo fila)
        {
            if (Util.GetCurrentCellText(fila, "FAC05CODEMP") == ""
                            || Util.GetCurrentCellText(fila, "FAC01COD") == ""
                            || Util.GetCurrentCellText(fila, "FAC04NUMDOC") == ""
                            || Util.GetCurrentCellText(fila, "FAC05CODPROD") == ""
                            || Util.GetCurrentCellText(fila, "FAC05DESCPROD") == "")
            {
                Util.ShowAlert("Debe ingresar datos en el registro vacio");
                Util.SetCellInitEdit(fila, "FAC05CODPROD");
                return false;
            }
            if (Util.GetCurrentCellText(fila, "FAC05DESCPROD").Contains('|'))
            {
                Util.ShowAlert("La descripcion de producto no debe tener el caracter | en su descripcion");
                Util.SetCellInitEdit(fila, "FAC05DESCPROD");
                return false;
            }
            return true;
        }

        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string codigoTipoDocumento = "";
                string numeroDocumento = "";
                string codigoPlantilla = "";
                codigoTipoDocumento = tipoDocumento;
                numeroDocumento = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();
                codigoPlantilla = txtcodplantilla.Text.Trim();
                DataTable datosFactura = new DataTable();

                datosFactura = VentaDocumentoLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa, codigoTipoDocumento, numeroDocumento);

                Reporte reporte = new Reporte("Documento");

                //Codigo para reportes con logos dinamicos
                string rutalogo = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", Util.convertiracadena(Logueo.RucEmpresa) + ".png");
                string rutalogoxdefecto = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", "Logopordefecto.png");

                if (System.IO.File.Exists(rutalogo) == true)
                {
                    //Util.ShowAlert("No existe el archivo logo en la ruta :" + rutalogo);
                    //return;
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogo));
                }
                else
                {
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogoxdefecto));
                }
                

                reporte.Ruta = Logueo.GetRutaReporte();
                if (codigoTipoDocumento == "01")
                {
                    reporte.Nombre = "RptFactura.rpt";
                }
                else if (codigoTipoDocumento == "03")
                {
                    reporte.Nombre = "RptBoleta.rpt";
                }
                else { 
                
                }
                
                reporte.DataSource = datosFactura;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error en vista: " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }


        
        private void txtmoneda_Leave(object sender, EventArgs e)
        {
            if (Estado == FormEstate.New)
            {
                string sDescripcion;
                sDescripcion = "";
                GlobalLogic.Instance.DameDescripcionFA(txtmoneda.Text, "MONEDAFAC", out sDescripcion);
                LblHelp2.Text = sDescripcion;
            }
        }

        private void txtformapagosunat_Leave(object sender, EventArgs e)
        {
            if (Estado == FormEstate.New)
            {
                string descripcion = "";
                GlobalLogic.Instance.DameDescripcionFA("61" + txtformapagosunat.Text.Trim(), "GLODESC", out descripcion);
                LblhelpFormapagosunat.Text = descripcion;
            }

            
        }
        private void dtpFechaDoc_Leave(object sender, EventArgs e)
        {
            double TipoCambo;    
            //Validar si la fecha es valida
            if (dtpFechaDoc.Text != "")
            {
                GlobalLogic.Instance.TipoCambioTraer(dtpFechaDoc.Text, out TipoCambo);
                txtTipoCambio.Text = TipoCambo.ToString();
            }
            else
            {
                Util.ShowAlert("Fecha No Valida");
                dtpFechaDoc.Focus();
            }
        }

        #region "Eventos de grilla"

        private void gridControlDetalle_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {

                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                if (EsModoGuiaTransporte == true) { deshabilitarBotonProdDet(e.Column.Name, cellElement); return; }

                if (gridControlDetalle.Rows[e.RowIndex].Cells["flag"].Value == null)
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, false);
                else
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, false);


            }
        }

        private void gridControlDetalle_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridControlDetalle.Columns["btnEliminarDet"].IsCurrent)
                {
                    EliminarDetalle();
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al llamar metodo del detalle : " + ex.Message);
            }
        }
        BaseGridEditor _gridEditor;

        private void gridControlDetalle_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.Row == null) return;


                #region "Flag"
                string str_flag = Util.GetCurrentCellText(e.Row, "flag");
                // Si el flag es modo lectura
                if (str_flag == "") { e.Cancel = true; return; }


                if (str_flag == "0" || str_flag == "1") // Si el flag no es modo lectura, 0 -> Nuevo y 1 -> Edito
                {
                    if (Util.GetCurrentCellText(e.Row, "FAC05GUIANUMERO") == "") // registros ingresados desde el detalle factura
                    {
                        //habilitar la edicion para los campos
                        e.Cancel = false;


                    }
                    else if (Util.GetCurrentCellText(e.Row, "FAC05GUIANUMERO") != "") // registros ingresados desde una guia
                    {
                        // inhabilitar edicion solo para los siguientes campos.
                        e.Cancel = (e.Column.Name == "FAC05UNIMED" ||
                            // e.Column.Name == "FAC05CANTIDAD" ||
                                    e.Column.Name == "FAC05PESO" ||
                                    e.Column.Name == "FAC05NROCAJA"
                            //|| e.Column.Name == "FAC05DESCPROD"
                                    );

                    }
                }
                #endregion

                _gridEditor = this.gridControlDetalle.ActiveEditor as BaseGridEditor;

                if (_gridEditor != null)
                {
                    RadItem editorElement = _gridEditor.EditorElement as RadItem;
                    editorElement.KeyDown += new KeyEventHandler(gridControlDetalle_KeyDown);
                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != (char)Keys.F1)
            {
                e.Handled = false;
            }
        }
        private void gridControlDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            //Si el boton de guardar detalle noe sta activado , entonces, no activamos la ayuda de la grilla.
            if (btnGrabar.Enabled == false) return;

            frmBusqueda frm;
            string[] datos;

            if (e.KeyValue == (char)Keys.F1)
            {
                if (Util.IsCurrentColumn(this.gridControlDetalle.CurrentColumn, "FAC05CODPROD") == true)
                {

                    if (txtcodplantilla.Text == "01" || txtcodplantilla.Text == "02" || txtcodplantilla.Text == "03")
                    {

                        frm = new frmBusqueda(enmAyuda.enmFacDet_ArtxCliente,
                            txttipoarticulo.Text.Trim() + "|" + TxtCliente.Text.Trim() + "|" + CantidadProductoRelacionado);
                        //frm = new frmBusqueda(enmAyuda.enmFacDet_ArtxCliente, "05");
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');


                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05CODPROD", datos[0]);
                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05DESCPROD", datos[1]);
                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05UNIMED", datos[2]);

                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05FECODPRODSUNAT", datos[3]);
                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05FEPRODUCTOTIPO", datos[4]);

                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05CODPROD_PROV", datos[5]);
                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05DESPROD_PROV", datos[6]);
                        Util.SetValueCurrentCellText(gridControlDetalle, "FAC05UNIMED_PROV", datos[7]);


                        Util.SetCellGridFocus(gridControlDetalle, "FAC05DESCPROD");
                        SendKeys.Send("{TAB}");


                        #region "Codigo original"
                        /*
                            frm = new frmBusqueda(enmAyuda.enmFactDet_ArtxTipo, txttipoarticulo.Text);
                            frm.ShowDialog();
                            if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                            if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                            datos = frm.Result.ToString().Split('|');

                            Util.SetValueCurrentCellText(gridControlDetalle, "FAC05CODPROD", datos[0]);
                            Util.SetValueCurrentCellText(gridControlDetalle, "FAC05DESCPROD", datos[1]);
                            Util.SetValueCurrentCellText(gridControlDetalle, "FAC05UNIMED", datos[2]);
                            Util.SetValueCurrentCellText(gridControlDetalle, "FAC05FECODPRODSUNAT", datos[3]);
                            Util.SetValueCurrentCellText(gridControlDetalle, "FAC05FEPRODUCTOTIPO", datos[4]);
                            Util.SetCellGridFocus(gridControlDetalle, "FAC05DESCPROD");
                            SendKeys.Send("{TAB}");
                        */
                        #endregion

                    }
                }
            }

        }

        void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }

        private void gridControlDetalle_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "FAC05CANTIDAD" || e.Column.Name == "FAC05PRECIO" || e.Column.Name == "FAC05FEIMPDSCTO")
            {
                calculartotales();
            }
        }
        private void gridControlDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            // Si  no hay detalles sale
            if (gridControlDetalle.Rows.Count == 0) return;

            // Si no hay ultiam columna visisble sale 
            if (ultimacolumnavisibledelagrilla == 0) return;

            //
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (InsertaroActualizarDetalle == "N")
                {
                    if (gridControlDetalle.CurrentColumn.IsVisible == true)
                    {
                        if (gridControlDetalle.CurrentColumn.Index == ultimacolumnavisibledelagrilla)
                        {
                            //agregar nueva fila
                            AgregarFila();
                            //Durante este evento aparte de agregar la fila salta la primera celda de la siguiente
                            // fila agregado, por ello , agrego este código para ubicar mi foco en la column del producto.
                            SendKeys.Send("+{TAB}");
                        }
                    }
                }
            }

        }


        private void gridControlDetalle_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is Telerik.WinControls.UI.GridSummaryCellElement)
            {
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
                e.CellElement.UpdateLayout();
            }
        }
        
        bool tbSubscribed = false;
        void tbElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "FAC05CODPROD"))
            {
                if (e.KeyChar != (char)Keys.F1)
                {
                    e.Handled = true;
                }
            }
        }
        private void gridControlDetalle_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {           
            RadTextBoxEditor tbEditor = this.gridControlDetalle.ActiveEditor as RadTextBoxEditor;
            if (tbEditor != null)
            {
                if (!tbSubscribed)
                {
                    tbSubscribed = true;
                    RadTextBoxEditorElement tbElement = (RadTextBoxEditorElement)tbEditor.EditorElement;                    
                    tbElement.KeyPress += new KeyPressEventHandler(tbElement_KeyPress);   
                }
            }
        }
        private void gridControlDetalle_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (_gridEditor != null)
            {
                RadItem editorElement = _gridEditor.EditorElement as RadItem;
                editorElement.KeyDown -= gridControlDetalle_KeyDown;
            }
            _gridEditor = null;

        }
        private void gridControlDetalle_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                //Caso cuando presiona Cancelar         // refrescar grilla y no ResatalEstiloCelda
                //Caso cuando presiona EliminarDetalle // ResaltarEstiloCelda (anterior)

                //Caseo cuando presioan nuevo  // ResaltarEstiloCelda(seleccionado)
                //Caso cuando presioan editar //  ResaltarEstiloCelda(seleccionado)

                if (gridControlDetalle.Rows.Count == 0) return;
                if (InsertaroActualizarDetalle == "N" || InsertaroActualizarDetalle == "M")
                {
                    if (e.CurrentRow != null)
                    {
                        Util.ResaltarAyuda(gridControlDetalle, e.CurrentRow.Index, "FAC05CODPROD");

                    }

                    //Si  tenemos solo una fila omitir el metodo para retirar 
                    // el resaltado de ayuda de la fila anterio
                    if (gridControlDetalle.Rows.Count == 1) return;


                    if (e.OldRow != null)
                    {
                        Util.ResetearAyuda(gridControlDetalle, e.OldRow.Index, "FAC05CODPROD");
                    }
                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        #endregion
        private void txtsubplantilla_Leave(object sender, EventArgs e)
        {
            SubPlantilla subplantilla = new SubPlantilla();
            subplantilla.FAC03CODEMP = Logueo.CodigoEmpresa;
            List<SubPlantilla> lista =  SubPlantillaLogic.Instance.TraeSubPlantilla(subplantilla, 
                                                          "FAC03COD", txtsubplantilla.Text.Trim());
            if (lista.Count == 0) return;

            txtsubplantilla.Text =  Util.convertiracadena(lista[0].FAC03COD).Trim();
            LblHelp0.Text = Util.convertiracadena(lista[0].FAC03DESC);
            txtcodplantilla.Text = Util.convertiracadena(lista[0].FAC02COD);
            txttipoarticulo.Text = Util.convertiracadena(lista[0].FAC03TIPART);
            txttipdoc.Text = Util.convertiracadena(lista[0].FAC01COD);
            txtserie.Text = Util.convertiracadena(lista[0].FAC03SERIEXDEF);
            txttipoventa.Text = Util.convertiracadena(lista[0].FAC03TIPOVENTA);
            txtTipoOperacionFE.Text = Util.convertiracadena(lista[0].FAC03TIPOOPERACIONFE);
            ActivarDesactivarTab(txttipoventa.Text.Trim());
            
        }

        private void txtExpPaisOrigen_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPaisOrigen.Text.Trim(),
                "PAISES", out descripcion);
            LblHelp5.Text = descripcion;
        }

        private void txtExpPaisDestino_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPaisDestino.Text.Trim(),
                "PAISES", out descripcion);
            LblHelp6.Text = descripcion;
        }

        private void txtExpCondPago_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpCondPago.Text.Trim(),
                "1011", out descripcion);

            LblHelp7.Text = descripcion;
        }

        private void txtExpConDespacho_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcionFA("52"+txtExpConDespacho.Text.Trim(),
                "GLODESC", out descripcion);

            LblHelp8.Text = descripcion;
        }

        private void txtExpPuertoEmbarque_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPuertoEmbarque.Text.Trim(),
                "PUERTOS", out descripcion);

            LblHelp9.Text = descripcion;
        }

        private void txtExpPuertoEmbarqueDes_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpPuertoEmbarqueDes.Text.Trim(),
                "PUERTOS", out descripcion);

            LblHelp12.Text = descripcion;
        }

        private void txtExpBancoLocal_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcionFA(txtExpBancoLocal.Text.Trim(),
                "1012", out descripcion);

            LblHelp10.Text = descripcion;
        }
        private void gridControlDetalle_Click(object sender, EventArgs e)
        {
        }
        private void frmfacturacab_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FrmParent != null)
            {
                FrmParent.formularioHijoAbierto = false;
            }    
        }

        private void btngeneracuotas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string MensajeRespuesta = "";
                int int_Flag = 0;

                if ((Util.NumerNoNegativo(txtcuotasnro.Text)) != "")
                {
                    Util.ShowAlert("Cuotas NO Valido");
                    return;
                }

                if ((Util.NumerNoNegativo(txtcuotadias.Text)) != "")
                {
                    Util.ShowAlert("Dias de Cuota NO Valido");
                    return;
                }
                    
                DocumentoLogic.Instance.Spu_Fact_Ins_CuotasFactura(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(), txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(),
                        Convert.ToInt16(txtcuotasnro.Text), Convert.ToInt16(txtcuotadias.Text), Convert.ToString(dtpFechaDoc.Value), out int_Flag, out MensajeRespuesta);

                Util.ShowMessage(MensajeRespuesta, int_Flag);

                if (int_Flag == 1)
                {
                    //Refrescar grilla de Facturas
                    traeCuotasFactura();

                    //Refrescar grilla de Facturas
                    if (FrmParent != null)
                    {
                        FrmParent.Cargar();
                        Util.enfocarFila(FrmParent.gridControl, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());
                        // Traer detalle del  
                        traesubdetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void radLabel42_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminarCuotas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string MensajeRespuesta = "";
                int int_Flag = 0;

                DocumentoLogic.Instance.Spu_Fact_Del_FacturaCuotas(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(), txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(),
                out int_Flag, out MensajeRespuesta);

                Util.ShowMessage(MensajeRespuesta, int_Flag);

                if (int_Flag == 1)
                {
                    //Refrescar grilla de Facturas
                    traeCuotasFactura();
                    //Asignar cero a cuotas y dias
                    txtcuotadias.Text = "0";
                    txtcuotasnro.Text = "0";

                    //Refrescar grilla de Facturas
                    if (FrmParent != null)
                    {
                        FrmParent.Cargar();
                        Util.enfocarFila(FrmParent.gridControl, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());
                        // Traer detalle del  
                        traesubdetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void rpGeneralesDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcodvendedor_Leave(object sender, EventArgs e)
        {
            try
            {
                string descripcion = "";
                GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txtcodvendedor.Text, "VENDEDOR", out descripcion);
                LblVendedorNombre.Text = descripcion;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer descripcion de Vendedor: " + ex.Message);
            }

        }

        private void txtcodvendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_Vendedor);
            else
                FocusNextControl(e);
        }

       
        
    }
}
