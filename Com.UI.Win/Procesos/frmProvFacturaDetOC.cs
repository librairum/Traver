using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using System.Linq;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
namespace Com.UI.Win
{
    public partial class frmProvFacturaDetOC : frmBaseMante
    {

        internal string tipoDocumento = "", nroDocumento = "",
        fechaDocumento = "", fechaVencimiento = "", libro = "",
        nroVoucher = "", tipoMoneda = "", tipoCambio = "",
        porcentajeIgv = "", importeAfecto = "", importeInafecto = "",
        importeIgv = "", importeDocumento = "", mesProvision = "",
        concepto = "", asientoTipo = "";
        
        internal string mesOrdenCompra = "", tipoOrdenCompra = "", nroDocumentoOrdenCompra = "", fechaOrdenCompra = "", anioOrdenCompra = "";
        internal bool tieneDetraccion = false;

        //Leer datos de Guia
        internal string tipoTransaccionGuia = "", codigoProveedor = "", fechaGuia = "", tipoDocumentoGuia = "", nroGuia = "", mesGuia = "";
        internal string CodTranfInventario = "", NroTransfInventario = "";

        private static frmProvFacturaDetOC _aForm;
        internal RadGridView gridFacturaConOc = new RadGridView();
        //bool esProvFactParaOC = false;
        ProvisionFacturaLogic ProvFactura = ProvisionFacturaLogic.Instance;

        #region "Instancia Provision Factura de Orden de Compra"
        private frmProvisionFacturas FrmParentConOC { get; set; }

        public static frmProvFacturaDetOC Instance(frmProvisionFacturas padre) 
        {
            if (_aForm != null) return new frmProvFacturaDetOC(padre);
            _aForm = new frmProvFacturaDetOC(padre);
            return _aForm;
        }
        public frmProvFacturaDetOC(frmProvisionFacturas padre)
        {
            InitializeComponent();
            FrmParentConOC = padre;
            this.Text = "Detalle de factura para Orden de Compra";
            //esProvFactParaOC = true;
        }
        #endregion
        string formatonumero = "{0:###,###,##0.00}";
        //boton nuevo es Ver cuenta contable
        protected override void OnNuevo()
        {
            
            var frmInstance = frmProvFactRegContable.Instance(this);

            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenCompraDetalle);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);

            frmInstance.Show();
        }
        //boton editar es ver Guia
        protected override void OnEditar()
        {

            var frmInstance = frmProvRegInventario.Instance(this);

            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenCompraDetalle);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            
            frmInstance.Show();

        }
        //General
        private void ActualizaPagos() {
            double ImpDocumento = 0;
            if (chkCancelacion.Checked)
            {
                ImpDocumento = double.Parse(txtImporteDocumento.Text);
            }
            else
            {
                ImpDocumento = 0;
            }
            string esAfectoDetraccion = "";
            esAfectoDetraccion = chkAfectoDetraccion.Checked ? "S" : "N";


            if (txtporcentaje.Text == "")
            {
                txtporcentaje.Text = "0";
            }

            if (txtimportedetraccion.Text == "")
            {
                txtimportedetraccion.Text = "0";
            }
            
            if (txtimportedetraccion_equi.Text == "")
            {
                //txtimportedetraccion_equi.Text = "0";                
                txtimportedetraccion_equi.Text  = Util.NumberFormat("0", formatonumero);

            }
            
            string tipoOrden = "", nroOrden = "", anio = "", mes = "", codigoProveedor = "";
            
            
            tipoOrden = FrmParentConOC.tipoOrden;
            nroOrden = FrmParentConOC.nroOrden;
            anio = FrmParentConOC.anio;
            ProvisionFacturaLogic.Instance.ActualizaProvisionFacturaPago(Logueo.CodigoEmpresa,
                Logueo.Anio, txtMesProvision.Text,
                tipoOrden,
                nroOrden,
                txtTipoDocumento.Text,
                txtnrodocumento.Text,
                double.Parse(txtImporteDocumento.Text),
                ImpDocumento,
                anio,
                mes,
                codigoProveedor,
                esAfectoDetraccion,
                txttipooperacion.Text,
                txttiposervicio.Text,
                double.Parse(txtporcentaje.Text),
                double.Parse(txtimportedetraccion.Text),
                double.Parse(txtimportedetraccion_equi.Text));

            //Refresar grilla de factura si valor es diferente a -1( Error)
            
            //FrmParentConOC.CargarFactura();
        }
        
        private ProvisionFactura LeerProvisionFactura()
        {
            string tipo = "", codigo = "";
            
            tipo = FrmParentConOC.tipoOrden;
            codigo = FrmParentConOC.nroOrden;

            ProvisionFactura provision = new ProvisionFactura();
            provision.Empresa = Logueo.CodigoEmpresa;
            provision.Anio = Logueo.Anio;
            provision.Mes = txtMesProvision.Text.Trim();
            //provision.Tipo = FrmParent.tipoOrden; // co03Tipo
            provision.Tipo = tipo;
            //provision.Codigo = FrmParent.nroOrden; // cc03codigo
            provision.Codigo = codigo;
            provision.TipoDocumento = txtTipoDocumento.Text;
            provision.NroDoc = txtnrodocumento.Text;
            provision.FechaDocumento = dtpFechaDocumento.Value;
            provision.FechaVencimiento = dtpFechaVencimiento.Value;
            provision.FechaPago = dtpFechaPago.Value;
            provision.PorIgv = double.Parse(txtPorIgv.Text);


          
            double ImpAfecto = 0, ImpAfectoEquiv = 0, ImpInafecto = 0,
                    ImpInafectoEquiv = 0, ImpIgv = 0, ImpIgvEquiv = 0,
                    ImpDocumento = 0, ImpDocumentoEquiv = 0;

            ImpAfecto = double.Parse(txtImporteAfecto.Text);
            ImpAfectoEquiv = double.Parse(txtImporteAfectoEquiv.Text);

            ImpInafecto = double.Parse(txtImporteInafecto.Text);
            ImpInafectoEquiv = double.Parse(txtImporteInafectoEquiv.Text);

            ImpDocumento = double.Parse(txtImporteDocumento.Text);
            ImpDocumentoEquiv = double.Parse(txtImporteDocumentoEquiv.Text);

            ImpIgv = double.Parse(txtImporteIgv.Text);
            ImpIgvEquiv = double.Parse(txtImporteIgvEquiv.Text);

            bool esTipoMonedaSoles = false;
            if (txtTipoMoneda.Text == "S")
            {
                esTipoMonedaSoles = true;
            }

            provision.ImporteAfecto = esTipoMonedaSoles ? ImpAfecto : ImpAfectoEquiv;
            provision.ImporteInafecto = esTipoMonedaSoles ? ImpInafecto : ImpInafectoEquiv;
            provision.ImporteIgv = esTipoMonedaSoles ? ImpIgv : ImpIgvEquiv;
            provision.Importe = esTipoMonedaSoles ? ImpDocumento : ImpDocumentoEquiv;

            provision.ImporteAfDol = esTipoMonedaSoles ? ImpAfectoEquiv : ImpAfecto;
            provision.ImporteInafDol = esTipoMonedaSoles ? ImpInafectoEquiv : ImpInafecto;
            provision.ImporteIgvDol = esTipoMonedaSoles ? ImpIgvEquiv : ImpIgv;
            provision.ImporteDocDol = esTipoMonedaSoles ? ImpDocumentoEquiv : ImpDocumento;
            provision.Moneda = txtTipoMoneda.Text.Trim().ToUpper();
            provision.TipoCambio = double.Parse(txtTipocambio.Text);
            provision.Concepto = txtConcepto.Text;
            string codCte = "", aniOrdCom = "", mesOrdCom = "";
            
            codCte = FrmParentConOC.codigoProveedor;
            aniOrdCom = FrmParentConOC.anio;
            mesOrdCom = FrmParentConOC.mes;
            provision.CodCte = codCte;
            provision.AnioOrdCom = aniOrdCom; // anio de orden de compra
            provision.MesOrdCom = mesOrdCom; // mes de orden de compra
            provision.AfectoDetraccion = chkAfectoDetraccion.Checked ? "S" : "N";
            provision.AfectoRet = rbAfectoRet.Checked ? "S" : "N";
            provision.NroAutorizacion = ""; // el contro fue retirado del diseño
            provision.BienesoServicioSunat = txtbienoservicio.Text.Trim();
            provision.CentroCosto = txtCentroCosto.Text.Trim();
            
            // Datos para notas de credito
            provision.DocModTipo = txtdocmodtipo.Text.Trim();
            provision.DocModNumero = txtdocmodnumero.Text.Trim();
            provision.DocModFecha = dtpdocmodfecha.Value;
            //Inventario
            LeerContabilidad(provision);
            //Inventario
            LeerInventario(provision);
            //Detraccion
            LeerDetraccion(provision);
            return provision;
        }

        private void GrabaryDesactivar() {
            float CantidadRegistros = 0;
            bool esDocumentoInventariado = false, esDocumentoContabilizado = false;

            //Formulario principal
            txtMesProvision.Enabled = false;
            txtTipoDocumento.Enabled = false;
            txtnrodocumento.Enabled = false;

            string anio = "";
            
            anio = Util.GetCurrentCellText(FrmParentConOC.gridFactura.CurrentRow, "Anio");
            //Contabilidad
            CantidadRegistros = 0;
            
            GlobalLogic.Instance.ComprasTraeDimeExisteVoucher(Logueo.CodigoEmpresa,
            anio,
            txtMesProvision.Text, txtLibro.Text, txtNroVoucher.Text, out CantidadRegistros);

            esDocumentoContabilizado = CantidadRegistros > 0 ? true : false;

            //Movimiento
            CantidadRegistros = 0;
            DocumentoLogic.Instance.ComprasExisteInvMovimiento(Logueo.CodigoEmpresa,
                anio, txtMesProvision.Text, txtCodTransInventario.Text,
                txtNroDocInventario.Text, out CantidadRegistros);

            esDocumentoInventariado = CantidadRegistros > 0 ? true : false;

            if (esDocumentoContabilizado == true)
            {
                txtLibro.Enabled = false;
                txtNroVoucher.Enabled = false;
                txtAsientoTipo.Enabled = false;
            }

            if (esDocumentoInventariado == true)
            {
                txtCodTransInventario.Enabled = false;
                txtNroDocInventario.Enabled = false;
                txtTipDocRespInventario.Enabled = false;
            }

            if (esDocumentoContabilizado == true || esDocumentoInventariado == true)
            {
                MuestrayOcultaDatos(false);
            }
        }
        private void CrearColumnasSugerencia()
        {
            RadGridView Grid = CreateGridVista(this.gridSugerencia);
            Grid.ShowColumnHeaders = false;
            CreateGridColumn(Grid, "Codigo", "CO07ITEM", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Descripcion", "CO07DESCRIPCION", 0, "", 250);
        }
        protected override void OnGuardar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                #region"Validaciones General"
                if (ValidarFechaPeriodo(dtpFechaDocumento.Value, Logueo.periodo) == false) {
                    return;
                }


                //validacion de campos de documentos Provision Factura

                if(txtTipoDocumento.Text.Trim() == ""){
                    Util.ShowAlert("Ingresar tipo de documento");
                    return;
                }

                if(txtnrodocumento.Text.Trim() == ""){
                    Util.ShowAlert("Ingresar numero de documento"); return;
                }

                if(txtTipoMoneda.Text.Trim() == ""){
                    Util.ShowAlert("Ingresar tipo de moneda"); return;
                }

                if (txtTipocambio.Text.Trim() == "") {
                    Util.ShowAlert("Ingresar tipo de cambio"); return;
                }

                if (gboxdocmodifica.Visible == true)
                {
                    if (txtdocmodtipo.Text == "" || txtdocmodnumero.Text == "")
                    {

                        Util.ShowAlert("Ingrese Documento de Referencia");
                        return;
                    }
                }
                //PENDIENTE
                //if (txtCentroCosto.Text == "")
                //{
                //    Util.ShowAlert("ERROR:: Ingrese un Centro de Costo");
                //    txtCentroCosto.Focus();
                //    return;
                //}
                //VerificaRetencion();
                #endregion
                #region"Validaciones Montos"
                // 'Validar los importes
                decimal ImporteAfecto = 0, TipoCambio = 0, ImporteAfectoEquivalente = 0;
                    ImporteAfecto = decimal.Parse(txtImporteAfecto.Text);
                    TipoCambio = decimal.Parse(txtTipocambio.Text);
                    ImporteAfectoEquivalente = decimal.Parse(txtImporteAfectoEquiv.Text);
                if (txtTipoMoneda.Text == "S")
                {
                    
                    if (decimal.Round((ImporteAfecto / TipoCambio), 2) != decimal.Round(ImporteAfectoEquivalente, 2))
                    {
                        bool respuesta = Util.ShowQuestion("Importe de soles / Tipo Cambio <> Importe Dolares , ¿Desea continuar?");
                        if (respuesta == false) return;
                    }                                        
                }
                else {

                    if (decimal.Round(ImporteAfecto * TipoCambio, 2) != decimal.Round(ImporteAfectoEquivalente, 2))
                    {
                        bool respuesta = Util.ShowQuestion(" Importe de soles * Tipo Cambio <> Importe Dolares , ¿Desea continuar?");
                        if (respuesta == false) return;
                    }
                }
                #endregion
             
                ProvisionFactura provision = new ProvisionFactura();
                provision = LeerProvisionFactura();
                int flagSalida = 0; string mensajeSalida = "";

                if (Estado == FormEstate.New)
                {
                    ProcesarContabilidad();
                    ProcesarInventario();

                    ProvisionFacturaLogic.Instance.Insertar(provision, out flagSalida, out mensajeSalida);
                    Util.ShowMessage(mensajeSalida, flagSalida);

                    if (flagSalida == 1) {
                        FrmParentConOC.CargarFactura();
                        ActualizaPagos();
                        GrabaryDesactivar();
                      ////Nuevo
                        InicializaDatos();
                        HabilitarControles(true);
                        txtMesProvision.Enabled = false;
                        txtTipoDocumento.Focus();
                        gpxFlotante.Visible = false;
                    }
                
                }
                else if (Estado == FormEstate.Edit)
                {
                    if ( (txtLibro.Enabled == false && txtNroVoucher.Enabled == false
                            && txtAsientoTipo.Enabled == false) && (txtCodTransInventario.Enabled == false && txtTipDocRespInventario.Enabled == false
                            && txtNroDocInventario.Enabled == false)) 
                    {
                        //Actualiza Factura Pagos
                    }else{
                    
                        
                        ProcesarContabilidad();
                        ProcesarInventario();
                        //TRAER CO07ITEM, PARA ACTUALIZAR
                        GridViewRowInfo row = gridSugerencia.CurrentRow;
                        string CO07DESCRIPCION = txtConcepto.Text;

                        //SP PARA ACTUALIZAR 
                        DataTable dt = ProvisionFacturaLogic.Instance.TraerConcepto_Spu_Com_Trae_Concepto_co07MotivosDocPorPagar(Logueo.CodigoEmpresa, CO07DESCRIPCION);

                        int CO07ITEM = 0;
                        if (dt.Rows.Count > 0)
                        {
                            CO07ITEM = Convert.ToInt32(dt.Rows[0]["CO07ITEM"].ToString());
                        }
                        //END CO07ITEM PARA ACTUALIZAR

                        provision = LeerProvisionFactura();
                        flagSalida = 0; mensajeSalida = "";
                        ProvisionFacturaLogic.Instance.Actualizar(provision, out flagSalida, out mensajeSalida);
                        Util.ShowMessage(mensajeSalida, flagSalida);
                        if (flagSalida == 1)
                        {
                            FrmParentConOC.CargarFactura();
                            ////Nuevo borra los elementos 
                            //InicializaDatos();
                            //HabilitarControles(true);
                            //txtMesProvision.Enabled = false;
                            //txtTipoDocumento.Focus();
                            //gpxFlotante.Visible = false;
                            //END NUEVO

                            GrabaryDesactivar();

                            FrmParentConOC.UbicarCursor(Logueo.CodigoEmpresa, Logueo.Anio, provision.Mes,
                               provision.Tipo, provision.Codigo, provision.TipoDocumento,
                               provision.NroDoc, provision.CodCte);
                        }
                    }
                    
                    
                }
                else {
                    Util.ShowAlert("Opcion no valido");
                }

                //Inicializa datos
            }
            catch (Exception ex) {
                Util.ShowError("Error al guardar"); 
            }
            Cursor.Current = Cursors.Default;
        }
       
        private void VerificaRetencion() {                
            //string FacturaConRetencion , FacturaConDetraccion, FacturaFecha, DocumentoTipoCodigo;
            //double FacturaValorEnSoles;

            //try
            //{
            //    string TipoMoneda, TipoDocumento, NroDocumento;

            //    TipoMoneda = txtTipoMoneda.Text;
            //    TipoDocumento = txtTipoDocumento.Text;
            //    NroDocumento = txtnrodocumento.Text;
            //    FacturaConDetraccion = chkAfectoDetraccion.Checked ? "S" : "N";
            //    FacturaFecha = dtpFechaDocumento.Value.ToShortDateString();

            //    //Capturar el importe en soles
            //    if (TipoMoneda == "S")
            //    {
            //        FacturaValorEnSoles = Convert.ToDouble(txtImporteDocumento.Text) - Convert.ToDouble(txtImporteInafecto.Text);

            //    }
            //    else if (TipoMoneda == "D")
            //    {
            //        FacturaValorEnSoles = Convert.ToDouble(txtImporteDocumentoEquiv.Text) - Convert.ToDouble(txtImporteInafectoEquiv.Text);
            //    }
            //    else
            //    {
            //        FacturaValorEnSoles = 0;
            //        Util.ShowAlert("Moneda No Valida");
            //    }


            //    //Analisis -> 02
                
            //    string codigoProveedor = FrmParentConOC.codigoProveedor;
            //    int esAfectaRetencion = 0;
            //    ProvisionFacturaLogic.Instance.TraeRetencion(Logueo.CodigoEmpresa, "02",
            //    codigoProveedor, FacturaFecha, FacturaValorEnSoles,
            //    FacturaConDetraccion, TipoDocumento, out esAfectaRetencion);

            //    if (esAfectaRetencion == 1)
            //    {
            //        rbAfectoRet.Checked = true;
            //        rbNoAfectoRet.Checked = false;
            //    }
            //    else
            //    {
            //        rbNoAfectoRet.Checked = true;
            //        rbAfectoRet.Checked = false;
            //    }
            //}
            //catch (Exception ex) {
            //    Util.ShowError("Error al verificar retencion");
            //}
        }
        private void CrearColumnas()
        {
            
            Telerik.WinControls.UI.RadGridView Grid = CreateGridVista(grdiCtaCte);
            CreateGridColumn(Grid, "Tipo", "Tipo", 0, "", 70);
            CreateGridColumn(Grid, "PagoFecha", "PagoFecha", 0, "", 90);
            CreateGridColumn(Grid, "Banco", "Banco", 0, "", 70);
            CreateGridColumn(Grid, "PagoNro", "PagoNro", 0, "", 100);
            CreateGridColumn(Grid, "ImporteSol", "ImporteSol", 0, "{0:###,###0.00}", 100, true, false, true, true, "right");
            CreateGridColumn(Grid, "ImporteDol", "ImporteDol", 0, "{0:###,###0.00}", 100, true, false, true, true, "right");     
        }

        private void InicializaDatos() {

            txtMesProvision.Enabled = false;
            txtTipoDocumento.Enabled = true;
            txtnrodocumento.Enabled = true;
            txtMesProvision.Text = Logueo.Mes;
            txtTipoDocumento.Text = "";
            txtnrodocumento.Text = "";
            dtpFechaDocumento.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now;
            dtpFechaPago.Value = DateTime.Now;
            txtPorIgv.Text = Logueo.Igv.ToString();
           // gpxCtaCte.Text = FrmParentConOC.nombreProveedor;
            
            
            //txtImporteAfecto.Text = "0,00";
            txtImporteAfecto.Text = Util.NumberFormat("0", formatonumero);

            //txtImporteInafecto.Text = "0,00";
            txtImporteInafecto.Text = Util.NumberFormat("0", formatonumero);
            
            //txtImporteIgv.Text = "0,00";
            txtImporteIgv.Text = Util.NumberFormat("0", formatonumero);
            //txtImporteDocumento.Text = "0,00";
            txtImporteDocumento.Text = Util.NumberFormat("0", formatonumero);

            //txtImporteAfectoEquiv.Text = "0,00";
            txtImporteAfectoEquiv.Text = Util.NumberFormat("0", formatonumero);
            //txtImporteInafectoEquiv.Text = "0,00";
            txtImporteInafectoEquiv.Text = Util.NumberFormat("0", formatonumero);
            //txtImporteIgvEquiv.Text = "0,00";
            txtImporteIgvEquiv.Text = Util.NumberFormat("0", formatonumero);
            //txtImporteDocumentoEquiv.Text = "0,00";            
            txtImporteDocumentoEquiv.Text = Util.NumberFormat("0", formatonumero);

            txtTipoMoneda.Text = FrmParentConOC.tipoMoneda;
            txtTipocambio.Text = Util.NumberFormat("1","{0:#,####0.0000}");
            
            txtConcepto.Text = "";
            txtbienoservicio.Text = "";
            rbNoAfectoRet.Checked = true;
            chkAfectoDetraccion.Checked = false;


            //contabilidad
            txtLibro.Text = "";
            txtNroVoucher.Text = "";
            txtAsientoTipo.Text = "";

            //Inventario            
            txtTipDocRespInventario.Text = "";
            txtCodTransInventario.Text = "";
            txtNroDocInventario.Text = "";
            dtpFechaDocInventario.Value = DateTime.Now;

            //detraccion
            txttipooperacion.Text = "";
            txttiposervicio.Text = "";

            txtporcentaje.Text = Util.NumberFormat("0", formatonumero);
            txtimportedetraccion.Text = Util.NumberFormat("0", formatonumero);
            txtimportedetraccion_equi.Text = Util.NumberFormat("0", formatonumero);

            //
            gboxdocmodifica.Visible = false;
            txtdocmodtipo.Text = "";
            txtdocmodnumero.Text = "";
            dtpdocmodfecha.Value = DateTime.Now;

            //SETEAR EL NRO Y NOMBRE DEL PROVEEDOR
            GridViewRowInfo filaOrdenCompra = FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow;
            string NroProveedor = Util.GetCurrentCellText(filaOrdenCompra, "Proveed");
            string NombreProveedor = Util.GetCurrentCellText(filaOrdenCompra, "NombreProveedor");
            //FrmParentConOC.nombreProveedor;
            // gpxCtaCte.Text = nombreProveedor;
          //  lblProveedorNro.Text = NroProveedor;
            gpxCtaCte.Text = NroProveedor;
            lblNombreProvee.Text = NombreProveedor;
           

        }
        
        private bool verifica_agente_y_buenaportador(string rucctatcte) {
            bool flagExitoso = false;
            //try
            //{  
            //    int datoSalida = 0;
            //    GlobalLogic.Instance.ComprasTraeTipoProveedor(rucctatcte, out datoSalida);

            //    if (datoSalida == 0)
            //    {
            //        flagExitoso = true;
            //    }
            //    else {
            //        flagExitoso = false;
            //    }
                
            //}
            //catch (Exception ex) {
            //    Util.ShowError("Error al verificar agente y buen aportador");
            //    flagExitoso = false;
            //}
            return flagExitoso;
        }
        /// <summary>
        /// Retornra el importe formateado a double, el valor de importe1 es retornado si la condicion es verdadeor , caso contrario retornara el imporete 2
        /// </summary>
        /// <param name="tipoMoneda">Valor de Moneda S (soles)</param>
        /// <param name="Importe1">Si Moneda es 'S' importe 1 es retornado</param>
        /// <param name="Importe2">Si Moneda no  es 'S' importe 2 es retornado</param>
        /// <returns></returns>
        
        
        private void GrabarVoucher() {
            GlobalLogic LogicaGlobal = GlobalLogic.Instance;
            VoucherLogic LogicaVoucher = VoucherLogic.Instance;
            AsientoTipoLogic LogicaAsientoTipo = AsientoTipoLogic.Instance;
            
            try
            {
                float cantidadRegistros = 0;
                LogicaGlobal.ComprasTraeDimeExisteVoucher(Logueo.CodigoEmpresa, Logueo.Anio, 
                txtMesProvision.Text, txtLibro.Text, txtNroVoucher.Text, out cantidadRegistros);

                if (cantidadRegistros > 0) {
                    Util.ShowAlert("VALIDAR :: Ya existe voucher"); return;
                }
                
                Voucher entidad = new Voucher();
                int flag = 0; string msj = "";

                entidad  = new Voucher();
                entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                entidad.Anio = Logueo.Anio;
                entidad.Mes = txtMesProvision.Text;
                entidad.libro = txtLibro.Text;
                entidad.fecha = dtpFechaDocumento.Value;
                entidad.detalle = txtConcepto.Text;
                entidad.astip = txtAsientoTipo.Text;
                entidad.trans = "N";
                
          
                string nroVoucher = "";

                //insercion de cabecera voucher
                LogicaVoucher.InsertarCabecera(entidad, txtNroVoucher.Text.Trim().ToUpper(),out nroVoucher, out flag, out msj);
                
                if (flag != 1)
                {
                    // Muestra error si es diferente de 1
                    Util.ShowMessage(msj, flag);
                    return;
                }
                

                //insercion Detalle voucher
                    //Traer detalle asiento tipo
                List<ComprasAsientoTipoDetalle> listaDetAsientoTipo = new List<ComprasAsientoTipoDetalle>();
                if (flag == 1) {
                    listaDetAsientoTipo = LogicaAsientoTipo.TraeDetalleAsientoTipo(Logueo.CodigoEmpresa, txtAsientoTipo.Text,Logueo.Anio);
                }

                if (Estado == FormEstate.Edit) { 
                    entidad = new Voucher();
                    entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                    entidad.Anio = Logueo.Anio;
                    entidad.Mes = txtMesProvision.Text;
                    entidad.libro = txtLibro.Text;
                    entidad.numero = txtNroVoucher.Text;
                    LogicaVoucher.EliminarDetalle(entidad, out flag, out msj);
                    txtLibro.Enabled = true;
                }

                string descripcion = "";
                LogicaGlobal.ComprasDameDescripcion(Logueo.CodigoEmpresa, txtTipoDocumento.Text, "SG", out descripcion);

                //
                foreach (ComprasAsientoTipoDetalle itm in listaDetAsientoTipo) {
                    double DebSol = 0, DebDol = 0;
                    double HabSol = 0, HabDol = 0;
                    if (itm.ccd03ca == "C")
                    {                                                                        
                        if (descripcion == "+")
                        {
                            HabSol = 0; HabDol = 0;
                            AsignarDebSolesyDebDolares(itm.ccd03afin, out DebSol, out DebDol);
                        }
                        else
                        {
                            DebSol = 0;
                            DebDol = 0;
                            AsignarHabSolesyHabDolares(itm.ccd03afin, out HabSol, out HabDol);
                        }
                    }
                    else {
                        if (descripcion == "+")
                        {
                            DebSol = 0; DebDol = 0;
                            HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                            HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text);
                        }
                        else {
                            HabSol = 0; HabDol = 0;
                            DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                            DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text);
                        }
                    }
                    string descripcionSalida = "";
                    string centroCosto = "";
                    LogicaGlobal.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + Logueo.Anio + itm.ccd03def, 
                                                                "FC", out descripcionSalida);
                     centroCosto = descripcionSalida;

                    double factor = Convert.ToDouble(decimal.Round( decimal.Parse(itm.ccd03porcen.ToString()) / 100, 4));

                    DebSol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(DebSol * factor),2));
                    HabSol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(HabSol * factor), 2));
                    DebDol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(DebDol * factor), 2));
                    HabDol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(HabDol * factor), 2));

                    if (txtLibro.Enabled) { 
                       
                        VoucherDetalle detalle = new VoucherDetalle();
                        
                        detalle =  LeerDetalleVoucher(itm, DebSol, HabSol, DebDol, HabDol, centroCosto);
                        string mensajeSalida = "";
                        int flagSalida = 0;

                        if ((DebSol + HabSol + DebDol + HabDol) != 0) // Solo se genera el detalle si hay un monto mayor a cero
                        {
                            LogicaVoucher.InsertarDetalle(detalle, out flagSalida, out mensajeSalida);
                        }

                        if (flagSalida != 1)
                        {
                            // Muestra error si es diferente de 1
                            Util.ShowMessage(msj, flag);
                            return;
                        }
                    }
               
                }
                // Si no salto el error , significa que todo salio bien
                Util.ShowAlert("OK :: Se Genero Voucher Contable");

            }catch (Exception ex) {
                Util.ShowAlert("ERROR :: No se Genero Voucher Contable");
            }
        }
                        
        private void AsignarValoresaImportes(string tipoMoneda) {
            
            GridViewRowInfo fila = FrmParentConOC.gridFactura.MasterView.CurrentRow;
            //Controles de Montos
            if (txtImporteAfecto.Text == "")
            {
                txtImporteAfecto.Text = Util.NumberFormat("0", formatonumero); ;
                
            }

            string importeBrutoDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPBDOL");
            string importeInafectaDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPINADOL");
            string importeIgvDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPIGVDOL");
            string importeDolares = Util.GetCurrentCellTextNumero(fila, "CO05IMPDOL");

            string importeBruto = Util.GetCurrentCellTextNumero(fila, "ImpBruto");
            string importeInafecto = Util.GetCurrentCellTextNumero(fila, "ImpIna");
            string importeIgv = Util.GetCurrentCellTextNumero(fila, "ImpIgv");

            string valorpordefecto = Util.NumberFormat("0", formatonumero);

            if (tipoMoneda == "S") { 
            



                string importe = Util.GetCurrentCellTextNumero(fila, "Importe");

                //carga de soles
                txtImporteAfecto.Text = importeBruto == "" ? valorpordefecto :  Util.NumberFormat(importeBruto, formatonumero);
                txtImporteInafecto.Text = importeInafecto == "" ? valorpordefecto :  Util.NumberFormat(importeInafecto, formatonumero);
                txtImporteIgv.Text = importeIgv == "" ? valorpordefecto: Util.NumberFormat(importeIgv, formatonumero);
                txtImporteDocumento.Text = importe == "" ? valorpordefecto: Util.NumberFormat(importe, formatonumero);       
         
                //carga de dolares equivalente de soles
                txtImporteAfectoEquiv.Text = importeBrutoDolares == "" ? valorpordefecto: Util.NumberFormat(importeBrutoDolares, formatonumero);
                txtImporteInafectoEquiv.Text = importeInafectaDolares == "" ? valorpordefecto : Util.NumberFormat(importeInafectaDolares, formatonumero);
                txtImporteIgvEquiv.Text = importeIgvDolares == "" ? valorpordefecto :  Util.NumberFormat(importeIgvDolares, formatonumero);
                txtImporteDocumentoEquiv.Text = importeDolares == "" ? valorpordefecto : Util.NumberFormat(importeDolares, formatonumero);

                
            }
            else
            {
                
                string importe = Util.GetCurrentCellTextNumero(fila, "ImpTotal");


                
                //carga de dolares
                txtImporteAfecto.Text = importeBrutoDolares == "" ? valorpordefecto : Util.NumberFormat(importeBrutoDolares, formatonumero);
                txtImporteInafecto.Text = importeInafectaDolares == "" ? valorpordefecto : Util.NumberFormat(importeInafectaDolares, formatonumero);
                txtImporteIgv.Text = importeIgvDolares == "" ? valorpordefecto : Util.NumberFormat(importeIgvDolares, formatonumero);
                txtImporteDocumento.Text = importeDolares == "" ?  valorpordefecto : Util.NumberFormat(importeDolares, formatonumero);


                //carga de soles equivalente de lso dolares
                txtImporteAfectoEquiv.Text = importeBruto == "" ? valorpordefecto :  Util.NumberFormat(importeBruto, formatonumero);
                txtImporteInafectoEquiv.Text = importeInafecto == "" ? valorpordefecto : Util.NumberFormat(importeInafecto, formatonumero);
                txtImporteIgvEquiv.Text = importeIgv == "" ?  valorpordefecto : Util.NumberFormat(importeIgv, formatonumero);
                txtImporteDocumentoEquiv.Text = importe == "" ? valorpordefecto : Util.NumberFormat(importe, formatonumero);
            }

            //txtImporteAfecto.Text = txtImporteAfecto.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteAfecto.Text;
            //txtImporteInafecto.Text = txtImporteInafecto.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteInafecto.Text;
            //txtImporteIgv.Text = txtImporteIgv.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteIgv.Text;
            //txtImporteDocumento.Text = txtImporteDocumento.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteDocumento.Text;

            //txtImporteAfectoEquiv.Text = txtImporteAfectoEquiv.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteAfectoEquiv.Text;
            //txtImporteInafectoEquiv.Text = txtImporteInafectoEquiv.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteInafectoEquiv.Text;
            //txtImporteIgvEquiv.Text = txtImporteIgvEquiv.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteIgvEquiv.Text;
            //txtImporteDocumentoEquiv.Text = txtImporteDocumentoEquiv.Text == "" ? Util.NumberFormat("0", formatonumero) : txtImporteDocumentoEquiv.Text;

        }
                        
        private void HabilitarCamposPorEstadoPeriodo(bool esPeriodoCerrado) {
            

            //if (esValidoPeriodoCerrado == true)
            if (esPeriodoCerrado == true) 
            {
                MuestrayOcultaDatos(false);
                Logueo.ComprasPeriodoCerrado = "S";
            }
            else
            {
                Logueo.ComprasPeriodoCerrado = "N";

                bool activarControlContabilidad = true, activarControlInventario = true;
                //si encontre registor mayor a cero en esDocumentoContabilidad, su valor es false
                activarControlContabilidad = esDocumentoContabilizado() == true ? false : true;                                
                //Contabilidad                
                txtLibro.Enabled = activarControlContabilidad;
                txtNroVoucher.Enabled = activarControlContabilidad;
                txtAsientoTipo.Enabled = activarControlContabilidad;
                                
               
                activarControlInventario = esDocumentoInventariado() == true? false: true;
                //Inventario
                txtCodTransInventario.Enabled = activarControlInventario;
                txtNroDocInventario.Enabled = activarControlInventario;
                txtTipDocRespInventario.Enabled = activarControlInventario;
                dtpFechaDocInventario.Enabled = activarControlInventario;
                txtNroDocRespInventario.Enabled = activarControlInventario;
                
                //desactivar el control de igv
                //txtPorIgv.Enabled = false;
                //if (activarControlContabilidad) { 
                    
                //}
                //if (activarControlInventario) { 
                
                //}
                //if (activarControlContabilidad || activarControlInventario)
                //{
                //    MuestrayOcultaDatos(false);
                //}
                //else 
                if(activarControlContabilidad == false && activarControlInventario == false)
                {
                    MuestrayOcultaDatos(false);
                }


            }

            #region "resalta ayuda"
            Util.ResaltaAyudaPorEstado(txtTipoDocumento);
            Util.ResaltaAyudaPorEstado(txtbienoservicio);
            Util.ResaltaAyudaPorEstado(txtLibro);
            Util.ResaltaAyudaPorEstado(txtAsientoTipo);
            Util.ResaltaAyudaPorEstado(txtCodTransInventario);
            Util.ResaltaAyudaPorEstado(txtTipDocRespInventario);
            Util.ResaltaAyudaPorEstado(txttipooperacion);
            Util.ResaltaAyudaPorEstado(txttiposervicio);
            #endregion

        }

        protected override void OnPrimero()
        {
            int iIndice = 0;
            FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow = FrmParentConOC.gridOrdenCompra.MasterView.Rows[iIndice];
            CargarDatos();
            Estado = FormEstate.View;
            this.gpxFlotante.Visible = false;

        }

        protected override void OnAnterior()
        {
            int iIndice = FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow.Index - 1;
            if (iIndice < 0)
            {
                return;
            }
            FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow = FrmParentConOC.gridOrdenCompra.MasterView.Rows[iIndice];
            CargarDatos();
            Estado = FormEstate.View;
            this.gpxFlotante.Visible = false;

        }

        protected override void OnSiguiente()
        {
            int iIndice = FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow.Index + 1;
            if (iIndice > FrmParentConOC.gridOrdenCompra.MasterView.Rows.Count - 1)
            {
                return;
            }
            FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow = FrmParentConOC.gridOrdenCompra.MasterView.Rows[iIndice];
            CargarDatos();
            Estado = FormEstate.View;
            this.gpxFlotante.Visible = false;

        }

        protected override void OnUltimo()
        {
            int iIndice = FrmParentConOC.gridOrdenCompra.MasterView.Rows.Count - 1;
            FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow = FrmParentConOC.gridOrdenCompra.MasterView.Rows[iIndice];
            CargarDatos();
            Estado = FormEstate.View;
            this.gpxFlotante.Visible = false;

        }
        private void frmProvFacturaDet_Load(object sender, EventArgs e)
        {
            //Iniciar ubicacion en txtConcepto
            Point ubicacionGrupoFlotante = new Point();
            ubicacionGrupoFlotante.X = this.txtConcepto.Location.X;
            ubicacionGrupoFlotante.Y = this.txtConcepto.Location.Y + this.txtConcepto.Height;
            this.gpxFlotante.Location = ubicacionGrupoFlotante;
            this.gpxFlotante.Visible = false;
            this.gpxFlotante.Height = 200;
            this.gpxFlotante.Width = 300;

            //END UBICACION
            OcultarBotones();
            
            gpxDetraccion.Visible = chkAfectoDetraccion.Checked ? true : false;

           

            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

            txtTipoMoneda.MaxLength = 1;
            CrearColumnas();
            CrearColumnasSugerencia();
            
                Estado = FrmParentConOC.Estado;    

                switch (Estado) { 

                    case FormEstate.New:
                        InicializaDatos();
                        HabilitarControles(true);
                        txtMesProvision.Enabled = false;
                        //txtPorIgv.Enabled = false;
                        HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                        HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                        break;

                    case FormEstate.Edit:
                        InicializaDatos();
                        HabilitarControles(true);
                        txtMesProvision.Enabled = false;
                        txtTipoDocumento.Enabled = false;
                        txtnrodocumento.Enabled = false;
                        HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                        HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

                        CargarDatos();
                        break;
                    case FormEstate.View:
                      InicializaDatos();
                        HabilitarControles(false);
                        HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
                        HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
                        HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
                        HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);
                        CargarDatos();
                        break;
                    default: break;
                }
                gpxFlotante.Visible = false;                                     
        }
        private void CargarDatos(){
            string descripcionref;
            try
            {
                GridViewRowInfo fila = FrmParentConOC.gridFactura.MasterView.CurrentRow;
                GridViewRowInfo filaOrdenCompra = FrmParentConOC.gridOrdenCompra.MasterView.CurrentRow;
                txtMesProvision.Text = Util.GetCurrentCellText(fila, "Mes");
                txtTipoDocumento.Text = Util.GetCurrentCellText(fila, "TipoDocumento");
                txtnrodocumento.Text = Util.GetCurrentCellText(fila, "NumeroDocumento");
                dtpFechaDocumento.Text = Util.GetCurrentCellText(fila, "Fecha");
                dtpFechaVencimiento.Text = Util.GetCurrentCellText(fila, "FechaVencimiento");
                dtpFechaPago.Text = Util.GetCurrentCellText(fila, "FechaPago");
                txtPorIgv.Text = Util.GetCurrentCellText(fila, "PorIgv");
                txtTipoMoneda.Text = Util.GetCurrentCellText(fila, "TipoMoneda");
                //Traer descripcion de Nombre Proveedor
                string NroProveedor = Util.GetCurrentCellText(filaOrdenCompra, "Proveed");
                string NombreProveedor = Util.GetCurrentCellText(filaOrdenCompra, "NombreProveedor");
                    //FrmParentConOC.nombreProveedor;
               // gpxCtaCte.Text = nombreProveedor;
                gpxCtaCte.Text = NroProveedor;
                lblNombreProvee.Text = NombreProveedor;
                
                string valor = Util.GetCurrentCellText(fila, "TipoCambio").Trim() == "" ? "1" : Util.GetCurrentCellText(fila, "TipoCambio").Trim();                
                txtTipocambio.Text = Util.NumberFormat(valor, "{0:#,###0.0000}");

                txtConcepto.Text = Util.GetCurrentCellText(fila, "CO05CON");
                txtbienoservicio.Text = Util.GetCurrentCellText(fila, "CO05BIENOSERVSUNAT");

                chkCancelacion.Checked = Util.GetCurrentCellText(fila, "Estado") == "3" ? true : false;
                chkAfectoDetraccion.Checked = Util.GetCurrentCellText(fila, "CO05AFECTODETRACCION") == "S" ? true : false;
                txtCentroCosto.Text = Util.GetCurrentCellText(fila, "CentroCosto");
                txtCentroCostoDesc.Text = Util.GetCurrentCellText(fila, "CentroCostoDescripcion");

                txtdocmodtipo.Text = Util.GetCurrentCellText(fila, "docmodtipo");
                txtdocmodnumero.Text = Util.GetCurrentCellText(fila, "docmodnumero");
                dtpdocmodfecha.Text = Util.GetCurrentCellText(fila, "docmodfecha");

                descripcionref = DameDescripcion(txtTipoDocumento.Text, "TDREF");
  
                if (descripcionref == "S")
                {
                    gboxdocmodifica.Visible = true;
                }
                else
                {
                    gboxdocmodifica.Visible = false;
                }


                //Traer bien o servicio descricpion
                string afectoaRetencion = Util.GetCurrentCellText(fila, "CO05AFECTORET");

                if (afectoaRetencion != "")
                {
                    rbAfectoRet.Checked = afectoaRetencion == "S" ? true : false;
                    rbNoAfectoRet.Checked = afectoaRetencion == "S" ? false : true;
                }


                AsignarValoresaImportes(txtTipoMoneda.Text.Trim());

                #region "Campos Adicionales"
                
                
                
                //Validacion de bloque Contabilidad         
                CargarContabidad(fila);                                
                CargarInventario(fila);
                CargarDetraccion(fila);
                #endregion
                #region"Comentarios"
                //if (fechaInventario == "")
                //{
                //    dtpFechaGuia.Value = DateTime.Now;
                //}
                //else
                //{
                //    dtpFechaGuia.Value = Convert.ToDateTime(fechaInventario);
                //    dtpFechaGuia.Text = Util.GetCurrentCellText(fila, "CO05INVFEC");
                //}
                //if (Util.GetCurrentCellText(fila, "CO05AFECTORET") == "S")
                //{
                //    rbAfectoRet.Checked = true;
                //    rbNoAfectoRet.Checked = false;
                //}
                //else if (Util.GetCurrentCellText(fila, "CO05AFECTORET") == "N")
                //{
                //    rbAfectoRet.Checked = false;
                //    rbNoAfectoRet.Checked = true;
                //}
                #endregion
                

                //trae descripcion de detraccion tipo operacion
                DateTime FechaDocumento = Convert.ToDateTime(Util.GetCurrentCellText(fila, "Fecha"));
                                
                

                //bool esValidoPeriodoCerrado = ValidaPeriodoCerrado(Util.GetCurrentCellText(fila, "Anio"), txtMesProvision.Text);
                bool esPeriodoCerrado = false;
                HabilitarCamposPorEstadoPeriodo(esPeriodoCerrado);
                //Cargar el flujo de la caja
                string codigoProveedor = FrmParentConOC.codigoProveedor;
               // TraeSubFlujoPago(codigoProveedor, txtTipoDocumento.Text, txtnrodocumento.Text); 

            }
            catch (Exception ex) {
                Util.ShowAlert("Error al cargar datos");
            }
                
     
        }
        private bool ValidaPeriodoCerrado(string AnioFactura, string MesProvision) {
            bool procesoExitoso = true;

            return procesoExitoso;
        }
       

        private void HabilitarControles(bool valor) {
            txtMesProvision.Enabled = valor;
            txtTipoDocumento.Enabled = valor;
            txtnrodocumento.Enabled = valor;
            dtpFechaDocumento.Enabled = valor;
            dtpFechaVencimiento.Enabled = valor;
            dtpFechaPago.Enabled = valor;
            txtPorIgv.Enabled = valor;
        //    gpxCtaCte.Text = "Nombre de cuenta corriente";
            txtImporteAfecto.Enabled = valor;
            txtImporteInafecto.Enabled = valor;
            txtImporteIgv.Enabled = valor;
            txtImporteDocumento.Enabled = valor;

            txtImporteAfectoEquiv.Enabled = valor;
            txtImporteInafectoEquiv.Enabled = valor;
            txtImporteIgvEquiv.Enabled = valor;
            txtImporteDocumentoEquiv.Enabled = valor;
            txtTipoMoneda.Enabled = valor;
            
            txtLibro.Enabled = valor;
            txtNroVoucher.Enabled = valor;
            txtAsientoTipo.Enabled = valor;

            txtCodTransInventario.Enabled = valor;
            txtNroDocInventario.Enabled = valor;

            txtTipocambio.Enabled = valor;

            //txtnroautorizacion esta retirado del diseño
            txtConcepto.Enabled = valor;
            txtbienoservicio.Enabled = valor;
            rbAfectoRet.Enabled = valor;
            rbNoAfectoRet.Enabled = valor;
            chkCancelacion.Enabled = valor;
            chkAfectoDetraccion.Enabled = valor;

            txtdocmodtipo.Enabled = valor;
            txtdocmodnumero.Enabled = valor;
            dtpdocmodfecha.Enabled = valor;


            #region "resalta ayuda controles"
            Util.ResaltaAyudaPorEstado(txtTipoDocumento);
            Util.ResaltaAyudaPorEstado(txtbienoservicio);
            Util.ResaltaAyudaPorEstado(txtLibro);
            Util.ResaltaAyudaPorEstado(txtAsientoTipo);
            Util.ResaltaAyudaPorEstado(txtCodTransInventario);
            Util.ResaltaAyudaPorEstado(txtTipDocRespInventario);
            Util.ResaltaAyudaPorEstado(txttipooperacion);
            Util.ResaltaAyudaPorEstado(txttiposervicio);
            Util.ResaltaAyudaPorEstado(txtCentroCosto);
            Util.ResaltaAyudaPorEstado(txtdocmodtipo);
            #endregion
        }
        private void MuestrayOcultaDatos(bool valor) {

            txtMesProvision.Enabled = valor;
            txtTipoDocumento.Enabled = valor;
            txtnrodocumento.Enabled = valor;
            dtpFechaDocumento.Enabled = valor;
            dtpFechaVencimiento.Enabled = valor;
            dtpFechaPago.Enabled = valor;

            txtTipoMoneda.Enabled = valor;
            txtTipocambio.Enabled = valor;
            txtPorIgv.Enabled = valor;

            chkCancelacion.Enabled = valor;
            chkAfectoDetraccion.Enabled = valor;

            txtConcepto.Enabled = valor;
            txtbienoservicio.Enabled = valor;

         //   gpxCtaCte.Text = FrmParentConOC.nombreProveedor;
            txtImporteAfecto.Enabled = valor;
            txtImporteInafecto.Enabled = valor;
            txtImporteIgv.Enabled = valor;
            txtImporteDocumento.Enabled = valor;
            
            txtImporteAfectoEquiv.Enabled = valor;
            txtImporteInafectoEquiv.Enabled = valor;
            txtImporteIgvEquiv.Enabled = valor;
            txtImporteDocumentoEquiv.Enabled = valor;


            rbAfectoRet.Enabled = valor;
            rbNoAfectoRet.Enabled = valor;

            ////Contabilidad
            //txtLibro.Enabled = valor;
            //txtNroVoucher.Enabled = valor;
            //txtAsientoTipo.Enabled = valor;

            ////Inventario
            //txtNroGuia.Enabled = valor;
            //txtnroautorizacion esta retirado del diseño
            
            //Detraccion
            txttipooperacion.Enabled = valor;
            txttiposervicio.Enabled = valor;
            txtporcentaje.Enabled = valor;
            txtimportedetraccion.Enabled = valor;
            txtimportedetraccion_equi.Enabled = valor;
            txtCentroCosto.Enabled = valor;
            //
            txtdocmodtipo.Enabled = valor;
            txtdocmodnumero.Enabled = valor;
            dtpdocmodfecha.Enabled = valor;

        }
        private void TraeSubFlujoPago(string CtaCte, string TipDoc,  string NroDoc) {


            //List
            List<Spu_Com_Trae_FlujoDePago> listaFlujoPago = 
            ProvFactura.ComprasTraeFlujoPago(Logueo.CodigoEmpresa,CtaCte, TipDoc, NroDoc);

            
        }

        private void TraerAyuda(enmAyuda tipo)
        {

            string[] datos;
            Cursor.Current = Cursors.WaitCursor;
            frmBusqueda frm;
            if (tipo == enmAyuda.enmServicioDetraccion)
            {
                frm = new frmBusqueda(tipo, dtpFechaDocumento.Value.ToString());
            }
            else {
                frm = new frmBusqueda(tipo);
            }
            Cursor.Current = Cursors.Default;
            frm.ShowDialog();
            if (frm.Result == null) return;
            if (frm.Result.ToString() == "") return;
            datos = frm.Result.ToString().Split('|');


            
            switch (tipo){
                
                case enmAyuda.enmTipoDocumento:
                    txtTipoDocumento.Text = datos[0]; //ccb02cod
                    txtTipoDocumento.Focus();
                    break;

                case enmAyuda.enmTransaccion:
                    txtCodTransInventario.Text = datos[0];
                    txtCodTransInventarioDesc.Text = datos[1];
                    txtCodTransInventario.Focus();

                    break;

                case enmAyuda.enmTipoDocumentoGuia:
                    txtTipDocRespInventario.Text = datos[0];
                    txtTipDocRespInventarioDesc.Text = datos[1];
                    txtTipDocRespInventario.Focus();
                    break;

                case enmAyuda.enmAsiento:
                    txtAsientoTipo.Text = datos[0];
                    txtAsientoTipoDesc.Text = datos[1];
                    txtAsientoTipo.Focus();
                    break;

                case enmAyuda.enmLibros:
                    txtLibro.Text = datos[0];
                    txtLibroDesc.Text = datos[1];
                    txtLibro.Focus();
                    break;
                case enmAyuda.enmBienServicio:
                    txtbienoservicio.Text = datos[0];
                    lblBienOServicio.Text = datos[1];
                    break;
                case enmAyuda.enmTipoOperacionDetraccion:
                    txttipooperacion.Text = datos[0];
                    txttipooperacionDesc.Text = datos[1];
                    break;

                case enmAyuda.enmServicioDetraccion:
                    txttiposervicio.Text = datos[0];
                    txttiposervicioDesc.Text = datos[1];
                    txtporcentaje.Text = datos[2];
                    break;
                case enmAyuda.enmCentroCosto:
                    txtCentroCosto.Text = datos[0];
                    txtCentroCostoDesc.Text = datos[1];
                    break;
                case enmAyuda.enmDocuModificaTipo:
                    txtdocmodtipo.Text = datos[0]; //ccb02cod
                    txtdocmodtipo.Focus();
                    break;     
            }
            
        }
        private void CalcularTotales()
        {

            try
            {
                decimal ValorBruto, ValorInafecto, ValorIgv, ValorTotal;
                decimal ValorBrutoEquivalente, ValorInafectoEquivalente,
                             ValorIgvEquivalente, ValorTotalEquivalente;

                //No procesar calculo tota en modo editar
                //if (Estado == FormEstate.Edit) return;
                if (txtImporteAfecto.Text == "")
                {
                    txtImporteAfecto.Text = Util.NumberFormat("0", formatonumero);
                }

                if (txtImporteInafecto.Text == "")
                {

                    txtImporteInafecto.Text = Util.NumberFormat("0", formatonumero);
                }

                ValorBruto = decimal.Parse(txtImporteAfecto.Text);
                ValorInafecto = decimal.Parse(txtImporteInafecto.Text);
                ValorIgv = (ValorBruto * decimal.Parse(txtPorIgv.Text)) / 100;
                ValorTotal = ValorBruto + ValorInafecto + ValorIgv;
                
                txtImporteIgv.Text = Util.NumberFormat(ValorIgv.ToString(), formatonumero);                
                txtImporteDocumento.Text = Util.NumberFormat(ValorTotal.ToString(), formatonumero);
                                                
                
                decimal tipoCambio = decimal.Parse(txtTipocambio.Text);

                if (txtTipoMoneda.Text == "S")
                {                    
                    ValorBrutoEquivalente = decimal.Round((ValorBruto / tipoCambio), 2);
                }
                else
                {
                    ValorBrutoEquivalente = decimal.Round((ValorBruto * tipoCambio), 2);
                }
                

                //txtImporteAfectoEquiv.Text = ValorBrutoEquivalente.ToString();



                if (txtTipoMoneda.Text == "S")
                {
                    ValorInafectoEquivalente = decimal.Round((ValorInafecto / tipoCambio), 2);
                }
                else
                {
                    ValorInafectoEquivalente = decimal.Round((ValorInafecto * tipoCambio), 2);
                }


                ValorIgvEquivalente = (ValorBrutoEquivalente * decimal.Parse(txtPorIgv.Text)) / 100;
                ValorTotalEquivalente = ValorBrutoEquivalente + ValorInafectoEquivalente + ValorIgvEquivalente;                
                txtImporteAfectoEquiv.Text = Util.NumberFormat(ValorBrutoEquivalente.ToString(), formatonumero);                
                txtImporteInafectoEquiv.Text = Util.NumberFormat(ValorInafectoEquivalente.ToString(), formatonumero);
                txtImporteIgvEquiv.Text = Util.NumberFormat(ValorIgvEquivalente.ToString(), formatonumero);                
                txtImporteDocumentoEquiv.Text = Util.NumberFormat(ValorTotalEquivalente.ToString(), formatonumero);
                                

                //VerificaRetencion();
                if (txtporcentaje.Text == "")
                {
                    txtporcentaje.Text = Util.NumberFormat("0", formatonumero);
                }
                CalcularImporteDetraccion(decimal.Parse(txtporcentaje.Text.Trim()));

            }
            catch (Exception ex)
            {
                Util.ShowError("Error en calcular totales");
            }

        }
        private void AsignaRetencionMontoEquivalente(bool esMontoEquivalente = false)
        {
            if (esMontoEquivalente)
            {
                if (txtImporteAfectoEquiv.Text.Trim() == "")
                {
                    //txtImporteAfectoEquiv.Text = "0,00";
                    txtImporteAfectoEquiv.Text = Util.NumberFormat("0", formatonumero);
                }
                if (txtImporteInafectoEquiv.Text.Trim() == "")
                {
                    //txtImporteInafectoEquiv.Text = "0,00";
                    txtImporteInafectoEquiv.Text = Util.NumberFormat("0", formatonumero);
                }
            }
            else
            {
                CalcularTotales();
                //if (txtImporteAfecto.Text.Trim() == "")
                //{
                //    //txtImporteAfecto.Text = "0,00";
                //    txtImporteAfecto.Text = Util.NumberFormat("0", formatonumero);
                //}
                //if (txtImporteInafecto.Text.Trim() == "")
                //{
                //    //txtImporteInafecto.Text = "0,00";
                //    txtImporteInafecto.Text = Util.NumberFormat("0", formatonumero);
                //}
            }

            string tipoMoneda = txtTipoMoneda.Text.Trim().ToUpper();

            double ImporteRetencion = double.Parse(Logueo.ImporteRetencion);


            if (Logueo.FlagRetencion == "S")
            {
                //if(FrmParent.codigoProveedor)
                string codigoProveedor = FrmParentConOC.codigoProveedor;
                if (verifica_agente_y_buenaportador(codigoProveedor) == true)
                {
                    switch (tipoMoneda)
                    {
                        case "S":

                            double ImporteDocumento = double.Parse(txtImporteDocumento.Text.Trim());
                            double ImporteInafecto = double.Parse(txtImporteInafecto.Text.Trim());

                            rbAfectoRet.Checked = (ImporteDocumento - ImporteInafecto > ImporteRetencion) ? true : false;
                            rbNoAfectoRet.Checked = (ImporteDocumento - ImporteInafecto > ImporteRetencion) ? false : true;
                            break;

                        case "D":

                            double ImporteDocumentoEquiv = double.Parse(txtImporteDocumentoEquiv.Text.Trim());
                            double ImporteInafectoEquiv = double.Parse(txtImporteInafectoEquiv.Text.Trim());

                            rbAfectoRet.Checked = (ImporteDocumentoEquiv - ImporteInafectoEquiv > ImporteRetencion) ? true : false;
                            rbNoAfectoRet.Checked = (ImporteDocumentoEquiv - ImporteInafectoEquiv > ImporteRetencion) ? false : true;
                            break;

                        default:
                            Util.ShowAlert("Moneda No Valida");
                            break;
                    }

                }
                else
                {
                    rbNoAfectoRet.Checked = true;
                }
            }


        }
        private void TraeDescripcion(string flag, string codigo, out string descripcion)
        {
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, codigo, flag, out descripcion);
        }
        private bool ValidarFechaPeriodo(DateTime fecha, string periodo)
        {

            bool fechaValida = false;
            string mes = fecha.Month.ToString("0#");
            string anio = fecha.Year.ToString();
            bool respuesta = false;
            string mensaje = "";
            if (double.Parse(anio + mes) > double.Parse(periodo))
            {
                mensaje = "La fecha de factura que esta registrando no es valida, \n" +
                            " posiblemente esta fecha pertenece a un periodo posterior \n" +
                            "Debe corregir la fecha para seguir trabajando";
                Util.ShowAlert(mensaje);
                fechaValida = false;
            }
            else if (double.Parse(anio + mes) < double.Parse(periodo))
            {
                mensaje = "La fecha de factura que esta registrando no es valida, \n" +
                           " posiblemente esta fecha pertenece a un periodo anterior \n" +
                           " ¿Esta seguro de registrar esta fecha en el documento?";
                respuesta = Util.ShowQuestion(mensaje);
                if (respuesta)
                {
                    fechaValida = false;
                }
                else {
                    fechaValida = true;
                }
                //Util.ShowAlert("El fecha de factura que esta registrando no es valida, posiblemente esta fecha pertenece a un periodo anterior");
                //fechaValida = false;
            }
            else if (double.Parse(anio + mes) == double.Parse(periodo))
            {
                fechaValida = true;
            }


            return fechaValida;
        }

        //chkAfectoDetraccion
        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            gpxDetraccion.Visible = chkAfectoDetraccion.Checked;

            //if (chkAfectacion.Checked) {
            //    gpxDerecha1.Visible = chkAfectacion.Checked;
            //}
        }
        private void txtCentroCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmCentroCosto);
            }
        }
        private void txtbienoservicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmBienServicio);
            }
        }     

        private void txtTipoDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmTipoDocumento);
            }
        }
		private void txtCentroCosto_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtCentroCosto.Text.Trim(), "CENTROCOSTO"); //CC -> CENTROCOSTO
            txtCentroCostoDesc.Text = descripcion;
        }      

        private void txtImporteAfecto_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteAfecto.Text.Trim() == "" ? "0" : txtImporteAfecto.Text.Trim();
            txtImporteAfecto.Text = Util.NumberFormat(valor, formatonumero);                        
            
            AsignaRetencionMontoEquivalente(false);
        }

        private void txtImporteInafecto_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteInafecto.Text.Trim() == "" ? "0" : txtImporteInafecto.Text.Trim();
            txtImporteInafecto.Text = Util.NumberFormat(valor, formatonumero);            
            
            AsignaRetencionMontoEquivalente(false);


        }

        private void txtImporteAfectoEquiv_Leave(object sender, EventArgs e)
        {
            
            string valor = txtImporteAfectoEquiv.Text.Trim() == "" ? "0" : txtImporteAfectoEquiv.Text.Trim();
            txtImporteAfectoEquiv.Text = Util.NumberFormat(valor, formatonumero);  
            
            AsignaRetencionMontoEquivalente(true);
        }

        private void txtImporteInafectoEquiv_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteInafectoEquiv.Text.Trim() == "" ? "0" : txtImporteInafectoEquiv.Text.Trim();
            txtImporteInafectoEquiv.Text = Util.NumberFormat(valor, formatonumero);
                        
            AsignaRetencionMontoEquivalente(true);
        }
                   
        private void dtpFechaDocumento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Estado == FormEstate.Edit) return;

                //bool esFechaValida = ValidarFechaPeriodo(dtpFechaDocumento.Value, Logueo.Anio + Logueo.Mes);
                //if (esFechaValida == false)
                //{
                //    dtpFechaDocumento.Focus();
                //    return;
                //}

                /* Observacion */
                //If CDate(Format(cmbFechaDocumento, "dd/mm/yyyy")) < CDate("01/03/2011") Then
                //txtPorIgv.Text = "19" ' Igv antes del 01/03/2011
                //Else
                //txtPorIgv.Text = gbIgv 'IGv Actual
                //End If

                // Logueo.Igv --> 18 es el valor de esta variable existente en el archivo Logueo.            
                txtPorIgv.Text = Logueo.Igv.ToString();

                float TipoCambio = 0;
                GlobalLogic.Instance.ComprasTraeTiCambioFecha(dtpFechaDocumento.Value.ToShortDateString(), "B", "V", out TipoCambio);
                txtTipocambio.Text = TipoCambio.ToString();

                if (txtImporteAfecto.Text != "")
                {
                    if (double.Parse(txtImporteAfecto.Text) > 0)
                    {
                        CalcularTotales();

                    }
                }
                string cantidadDias = "";
                
                    string formaPago = FrmParentConOC.formaPago;
                    GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa,
                    Logueo.CodigoEmpresa + formaPago, "DFP", out cantidadDias); ;
               
                int dias;  
                
                if (Util.EsNumero(cantidadDias) ==true)
                {    
                    dias = Convert.ToInt32(cantidadDias);
                }
                    else
                 {
                     dias = 0;
                 }
                    
                dtpFechaVencimiento.Value = dtpFechaDocumento.Value.AddDays(dias);
                dtpFechaPago.Value = dtpFechaDocumento.Value.AddDays(dias);
            }
            catch (Exception ex) {
                Util.ShowError("Error en Fecha de documento");
            }
            
        }              

        private void txtTipocambio_Leave(object sender, EventArgs e)
        {
            try
            {
                string valor = txtTipocambio.Text.Trim() == "" ? "1" : txtTipocambio.Text.Trim();
                txtTipocambio.Text = Util.NumberFormat(valor, "{0:#,###0.0000}");
                

                double numero = 0;
                bool numeroValido = double.TryParse(txtImporteAfecto.Text.Trim(), out numero);

                if (numero > 0) {
                    CalcularTotales();
                }
                

            }
            catch (Exception ex) {
                Util.ShowAlert("Error al formatear numero tipo cambio");
            }                                                             
        }
                              
        private void txtbienoservicio_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            TraeDescripcion("GLO02",  "30" + txtbienoservicio.Text, out descripcion);
            lblBienOServicio.Text = descripcion;
        }

        #region "Metodos General"

        #endregion
        #region "Metodos Detraccion"
        private void CalcularImporteDetraccion(decimal Porcentaje)
        {
            try
            {
                if (chkAfectoDetraccion.Checked == false) { return; }
                if (txtTipoMoneda.Text != "S" && txtTipoMoneda.Text != "D")
                {
                    Util.ShowAlert("Debe Especificar Moneda"); return;
                }
                if (txtTipocambio.Text == "") { Util.ShowAlert("Tipo de cambio No Valido"); return; }
                if (txtImporteDocumento.Text == "" || txtImporteDocumentoEquiv.Text == "") { Util.ShowAlert("Importe No Valido"); return; }
                if (txtporcentaje.Text == "") { Util.ShowAlert("Porcentaje No Valido"); return; }
                if (Util.EsNumero(txtporcentaje.Text) == false) { Util.ShowAlert("Porcentaje No Valido"); return; }


                //'Calcular detraccion sobre la moneda original
                decimal ImporteDetraccion = Convert.ToDecimal(txtImporteDocumento.Text) * (Porcentaje / 100);
                decimal ImporteDetraccionOriginal = 0, ImporteDetraccionEquivalente = 0;

                if (txtTipoMoneda.Text.ToUpper() == "S")
                {
                    ImporteDetraccionOriginal = decimal.Round(ImporteDetraccion, 2);
                    ImporteDetraccionEquivalente = decimal.Round(ImporteDetraccion / decimal.Parse(txtTipocambio.Text), 2);
                }
                else if (txtTipoMoneda.Text.ToUpper() == "D")
                {
                    ImporteDetraccionOriginal = decimal.Round(ImporteDetraccion * decimal.Parse(txtTipocambio.Text), 2);
                    ImporteDetraccionEquivalente = decimal.Round(ImporteDetraccion, 2);
                }


                txtimportedetraccion.Text = Util.NumberFormat(ImporteDetraccionOriginal.ToString(), formatonumero);
                txtimportedetraccion_equi.Text = Util.NumberFormat(ImporteDetraccionEquivalente.ToString(), formatonumero);


            }
            catch (Exception ex)
            {

            }
        }
        private void LeerDetraccion(ProvisionFactura entidad)
        {

            entidad.DetraTipoOperacion = txttipooperacion.Text;
            entidad.DetraTipoServicio = txttiposervicio.Text;

            string porcentajeCadena = (txtporcentaje.Text == "" ? "0" : txtporcentaje.Text);
            entidad.DetraPorcentaje = double.Parse(porcentajeCadena);

            string ImporteDetraccionCadena = (txtimportedetraccion.Text == "" ? "0" : txtimportedetraccion.Text);
            entidad.DetraImporte = double.Parse(ImporteDetraccionCadena);

            string ImporteDetraccionEquivCadena = (txtimportedetraccion_equi.Text == "" ? "0" : txtimportedetraccion_equi.Text);
            entidad.DetraImporte_Equiv = double.Parse(ImporteDetraccionEquivCadena);
        }
        #endregion

        #region "Metodos Inventario"
        private void ProcesarInventario()
        {
            if (txtNroDocInventario.Enabled == true && txtTipDocRespInventario.Enabled == true 
                && txtCodTransInventario.Enabled == true && txtNroDocRespInventario.Enabled == true)
            {
                if (txtNroDocInventario.Text.Trim() != "" && txtTipDocRespInventario.Text.Trim() != "" 
                    && txtCodTransInventario.Text.Trim() != "" && txtNroDocRespInventario.Text.Trim() != "")
                {
                    GrabarMovimiento();
                }
            }
        }
        private void GrabarMovimiento()
        {
            try
            {
                //Valida Ingreso Almacen
                float cantidadRegistro = 0;
                //string mes = txtMesProvision.Text.Trim().forma;
                
                DocumentoLogic.Instance.ComprasExisteInvMovimiento(Logueo.CodigoEmpresa,
                    Logueo.Anio, Logueo.Mes, txtCodTransInventario.Text, 
                    txtNroDocInventario.Text, out cantidadRegistro);

                bool esValidoIngresoMovimiento = cantidadRegistro == 0 ? true : false;
                if (esValidoIngresoMovimiento == false && txtNroDocInventario.Enabled)
                {
                    Util.ShowAlert("Movimiento ingresado en almacen");
                    return;
                }
                if (txtCodTransInventario.Enabled == false) return;
                int flagSalida = 0; string mensajeSalida = "";
                string codigoProveedor = "", nroOrden = "", anio = "";
                
                    anio = FrmParentConOC.anio;
                    codigoProveedor = FrmParentConOC.codigoProveedor;
                    nroOrden = FrmParentConOC.nroOrden;

               string numeroDocumento = "", numeroDocumentoReferencia = "";
                numeroDocumentoReferencia = txtNroDocRespInventario.Text.Trim();
                numeroDocumento = txtNroDocInventario.Text.Trim();

                ProvisionFacturaLogic.Instance.InsertarMovimiento(Logueo.CodigoEmpresa,
                    Logueo.Anio, Logueo.Mes,
                    txtCodTransInventario.Text, numeroDocumento, dtpFechaDocInventario.Value.ToShortDateString(),
                    txtTipDocRespInventario.Text, "E", txtTipoMoneda.Text, Convert.ToDouble(txtTipocambio.Text),
                    codigoProveedor, "", "", "", "", "", nroOrden, "", "", "",
                    "", numeroDocumentoReferencia, anio,Logueo.PS_codnaturaleza, out flagSalida, out mensajeSalida); 
         
                Util.ShowMessage(mensajeSalida, flagSalida);
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al grabar movimiento");
            }
        }
        private bool esDocumentoInventariado()
        {
            bool esInventariado = false;
            float CantidadRegistros = 0;
            DocumentoLogic.Instance.ComprasExisteInvMovimiento(Logueo.CodigoEmpresa,
                Logueo.Anio, txtMesProvision.Text, txtCodTransInventario.Text,
                txtNroDocInventario.Text, out CantidadRegistros);
            esInventariado = CantidadRegistros > 0 ? true : false;
            return esInventariado;
        }


        private void LeerInventario(ProvisionFactura entidad)
        {
            //Datos para transaccion del inventario
            entidad.TipDocGuia = txtCodTransInventario.Text;
            entidad.NroGuia = txtNroDocInventario.Text;
            entidad.FechaGuia = string.Format("{0:yyyyMMdd} ", dtpFechaDocInventario.Value);
            //Datos para el documento respaldo del inventario
            entidad.TipTransGuia = txtTipDocRespInventario.Text;
            entidad.NroDocRef = txtNroDocRespInventario.Text.Trim();
            
        }
        #endregion

        #region "Metodos Contabilidad"
        private VoucherDetalle LeerDetalleVoucher(ComprasAsientoTipoDetalle registro, double importeDebe, double importeHaber,
                                                     double importeDebeEquivalencia, double importeHaberEquivalencia, string CentroCosto)
        {
            VoucherDetalle detalle = new VoucherDetalle();
            detalle.CodigoEmpresa = Logueo.CodigoEmpresa;
            detalle.Anio = Logueo.Anio;
            detalle.Mes = txtMesProvision.Text;
            detalle.libro = txtLibro.Text;
            detalle.NumeroVoucher = txtNroVoucher.Text;
            detalle.cuenta = registro.ccd03def;
            detalle.ImporteDebe = importeDebe;
            detalle.ImporteHaber = importeHaber;
            detalle.glosa = txtConcepto.Text;
            detalle.TipoDocumento = txtTipoDocumento.Text;
            detalle.NumDoc = txtnrodocumento.Text;
            detalle.FechaDoc = dtpFechaDocumento.Value;
            detalle.FechaVencimiento = dtpFechaVencimiento.Value;

            //
            detalle.DocModTipo = txtdocmodtipo.Text.Trim();
            detalle.DocModNumero = txtdocmodnumero.Text.Trim();
            detalle.DocModFecha = dtpdocmodfecha.Value;

            string codigoProveedor = FrmParentConOC.codigoProveedor;
            detalle.CuentaCorriente = codigoProveedor;
            detalle.moneda = txtTipoMoneda.Text.Trim().ToUpper();
            detalle.TipoCambio = double.Parse(txtTipocambio.Text);
            detalle.Afecto = registro.ccd03afin;
            detalle.CenCos = CentroCosto;
            detalle.CenGes = "";
            detalle.AsientoTipo = txtAsientoTipo.Text;
            detalle.valida = "";
            detalle.ImporteDebeEquivalencia = importeDebeEquivalencia;
            detalle.ImporteHaberEquivalencia = importeHaberEquivalencia;
            detalle.transa = "N";
            detalle.Amarre = "";
            detalle.NroPago = "";
            detalle.FechaPago = null;
            detalle.Porcentaje = "";

            return detalle;
        }
        private void CargarContabidad(GridViewRowInfo fila)
        {
            bool activarControlesContabilidad = true;
            activarControlesContabilidad = esDocumentoContabilizado();
            txtLibro.Enabled = activarControlesContabilidad;
            txtNroVoucher.Enabled = activarControlesContabilidad;
            txtAsientoTipo.Enabled = activarControlesContabilidad;

            txtLibro.Text = Util.GetCurrentCellText(fila, "Libro");
            txtNroVoucher.Text = Util.GetCurrentCellText(fila, "Voucher");
            txtAsientoTipo.Text = Util.GetCurrentCellText(fila, "CO05ASITIP");
        }
        private void LeerContabilidad(ProvisionFactura entidad)
        {
            entidad.libro = txtLibro.Text;
            entidad.NumeroVoucher = txtNroVoucher.Text;
            entidad.AsientoTipo = txtAsientoTipo.Text;

        }
        private void ProcesarContabilidad()
        {
            if (txtAsientoTipo.Enabled == true && txtNroVoucher.Enabled == true && txtLibro.Enabled == true)
            {
                if (txtAsientoTipo.Text != "" && txtNroVoucher.Text != "" && txtLibro.Text != "")
                {
                    GrabarVoucher();
                }
            }
        }
        private double DevolverImportePorMoneda(string tipoMoneda, string Importe1, string Importe2)
        {
            double importeSalida = 0;
            if (tipoMoneda == "S")
            {
                importeSalida = Convert.ToDouble(Importe1);
            }
            else
            {
                importeSalida = Convert.ToDouble(Importe2);
            }
            return importeSalida;

        }
        private void AsignarHabSolesyHabDolares(string ValorAfin, out double SalidaHabSoles, out double SalidaHabDolares)
        {
            double HabSol = 0, HabDol = 0;
            if (ValorAfin == "1" || ValorAfin == "2" || ValorAfin == "3")
            {

                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfecto.Text, txtImporteAfectoEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfectoEquiv.Text, txtImporteAfecto.Text);
            }

            if (ValorAfin == "4" || ValorAfin == "5" || ValorAfin == "9" || ValorAfin == "2")
            {
                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafecto.Text, txtImporteInafectoEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafectoEquiv.Text, txtImporteInafecto.Text);
            }

            if (ValorAfin == "6" || ValorAfin == "7" || ValorAfin == "8")
            {
                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgv.Text, txtImporteIgvEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgvEquiv.Text, txtImporteIgv.Text);
            }

            if (ValorAfin == "0")
            {
                HabSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                HabDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text);
            }
            SalidaHabSoles = HabSol;
            SalidaHabDolares = HabDol;

        }
        private void AsignarDebSolesyDebDolares(string ValorAfin, out double SalidaDebSoles, out double SalidaDebDolares)
        {

            double DebSol = 0, DebDol = 0;
            if (ValorAfin == "1" || ValorAfin == "2" || ValorAfin == "3")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfecto.Text, txtImporteAfectoEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteAfectoEquiv.Text, txtImporteAfecto.Text);
            }

            if (ValorAfin == "4" || ValorAfin == "5" || ValorAfin == "9")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafecto.Text, txtImporteInafectoEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteInafectoEquiv.Text, txtImporteInafecto.Text);
            }
            if (ValorAfin == "6" || ValorAfin == "7" || ValorAfin == "8")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgv.Text, txtImporteIgvEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteIgvEquiv.Text, txtImporteIgv.Text);
            }

            if (ValorAfin == "0")
            {
                DebSol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumento.Text, txtImporteDocumentoEquiv.Text);
                DebDol = DevolverImportePorMoneda(txtTipoMoneda.Text.ToUpper().Trim(), txtImporteDocumentoEquiv.Text, txtImporteDocumento.Text);
            }

            SalidaDebSoles = DebSol;
            SalidaDebDolares = DebDol;
        }
        private bool esDocumentoContabilizado()
        {
            bool encontroRegistros = false;
            float CantidadRegistros = 0;
            GlobalLogic.Instance.ComprasTraeDimeExisteVoucher(Logueo.CodigoEmpresa,
                    Logueo.Anio, txtMesProvision.Text, txtLibro.Text, txtNroVoucher.Text,
                    out CantidadRegistros);
            //encontroRegistros = CantidadRegistros > 0 ? false : true;
            encontroRegistros = CantidadRegistros > 0 ? true : false;
            return encontroRegistros;
        }
        #endregion

        #region "Detraccion"
        //Detraccion
        private void CargarDetraccion(GridViewRowInfo fila)
        {
            txttipooperacion.Text = Util.GetCurrentCellText(fila, "CO05DETRATIPOPERACION");
            txttiposervicio.Text = Util.GetCurrentCellText(fila, "CO05DETRATIPOSERVICIO");
            txtporcentaje.Text = Util.GetCurrentCellText(fila, "CO05DETRAPORCENTAJE");
            string detraccionimporte = Util.GetCurrentCellText(fila, "CO05DETRAIMPORTE");
            txtimportedetraccion.Text = Util.NumberFormat(detraccionimporte, formatonumero);
            string detraccionImporteEquivalente = Util.GetCurrentCellText(fila, "CO05DETRAIMPORTE_EQUI");
            txtimportedetraccion_equi.Text = Util.NumberFormat(detraccionImporteEquivalente, formatonumero);
        }
        private void txttipooperacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                //TraerAyuda(enmAyuda.servicio
                TraerAyuda(enmAyuda.enmTipoOperacionDetraccion);
            }
        }

        private void txttiposervicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmServicioDetraccion);
            }
        }
       
        
        private void txtporcentaje_Leave(object sender, EventArgs e)
        {
            try
            {
                CalcularImporteDetraccion(Convert.ToDecimal(txtporcentaje.Text));
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al calcular conversion");
            }

            
        }
        #endregion
        #region "Inventario"
        //Inventario
        private void CargarInventario(GridViewRowInfo fila)
        {

            bool activarControlInventario = esDocumentoInventariado();
            txtCodTransInventario.Enabled = activarControlInventario;
            txtNroDocInventario.Enabled = activarControlInventario;
            txtTipDocRespInventario.Enabled = activarControlInventario;


            txtCodTransInventario.Text = Util.GetCurrentCellText(fila, "InvTipo");
            txtCodTransInventarioDesc.Text = DameDescripcion(Logueo.CodigoEmpresa + txtCodTransInventario.Text, "TRANSA");


            txtNroDocInventario.Text = Util.GetCurrentCellText(fila, "CO05INVNRO");

            txtTipDocRespInventario.Text = Util.GetCurrentCellText(fila, "CO05INVTRANS");
            txtTipDocRespInventarioDesc.Text = DameDescripcion(Logueo.CodigoEmpresa + txtTipDocRespInventario.Text,"TDG");


            txtNroDocRespInventario.Text = Util.GetCurrentCellText(fila, "DocumentoReferencia");
            string fechaInventario = Util.GetCurrentCellText(fila, "CO05INVFEC");
            dtpFechaDocInventario.Value = fechaInventario == "" ? DateTime.Now : Convert.ToDateTime(fechaInventario);
            
        }

        private void btnVerInventario_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //NUEVO
            this.tipoDocumento = txtnrodocumento.Text;
            //END

            this.CodTranfInventario = txtCodTransInventario.Text.Trim();
            this.NroTransfInventario = txtNroDocInventario.Text.Trim();
            this.anioOrdenCompra = FrmParentConOC.anio;
            this.mesOrdenCompra = FrmParentConOC.mes;
            this.tipoOrdenCompra = FrmParentConOC.tipoOrden;
            this.nroDocumentoOrdenCompra = FrmParentConOC.nroOrden;
            
            var frmInstance = frmProvRegInventario.Instance(this);
           

           var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvRegInventario);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);

            frmInstance.Show();
            
            Cursor.Current = Cursors.Default;
        }
        private void txtTipDocRespInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmTipoDocumentoGuia);
                //TraerAyuda(enmAyuda.enmTransaccion);
            }
        }

        private void txtCodTransInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmTransaccion);
                //TraerAyuda(enmAyuda.enmTipoDocumentoGuia);
            }
        }
        #endregion
        #region"Contabilidad"
        //Contabilidad
       
        private void btnVerContabilidad_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //
            //Llevar datos de Contabilidad del formulario padre
            Logueo.TipoProvision = "C/OC";
            Logueo.gridProvFactura = FrmParentConOC.gridOrdenCompra;
            this.tipoDocumento = txtTipoDocumento.Text.Trim();
            this.nroDocumento = txtnrodocumento.Text.Trim();
            this.fechaDocumento = dtpFechaDocumento.Value.ToShortDateString();
            this.fechaVencimiento = dtpFechaVencimiento.Value.ToShortDateString();
            this.libro = txtLibro.Text.Trim();
            this.nroVoucher = txtNroVoucher.Text.Trim();
            this.tipoMoneda = txtTipoMoneda.Text.Trim().Trim().ToUpper();
            this.tipoCambio = txtTipocambio.Text.Trim();
            //txtPorigv -> Provision, txtporcentaje -> detraccion
            this.porcentajeIgv = txtPorIgv.Text.Trim();
            this.importeAfecto = txtImporteAfecto.Text;
            this.importeInafecto = txtImporteAfecto.Text;
            this.importeIgv = txtImporteIgv.Text;
            this.importeDocumento = txtImporteDocumento.Text;
            this.mesProvision = txtMesProvision.Text;
            this.tieneDetraccion = chkAfectoDetraccion.Checked;
            this.concepto = txtConcepto.Text.Trim();
            this.asientoTipo = txtAsientoTipo.Text;            
            //this.anioDocumento = FrmParentConOC.anio;
            this.anioOrdenCompra = FrmParentConOC.anio;
            //this.gridFacturaConOc.DataSource = FrmParentConOC.gridOrdenCompra;
            var frmInstance = frmProvFactRegContable.Instance(this);
            
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenCompraDetalle);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);

            frmInstance.Show();
            Cursor.Current = Cursors.Default;
        }
        private void txtLibro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmLibros);
            }
        }

        private void txtAsientoTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmAsiento);
            }
        }
        private void txtNroVoucher_Leave(object sender, EventArgs e)
        {
            if (txtLibro.Text != "")
            {
                string nuevoNumeroVoucher = "";
                ProvisionFacturaLogic.Instance.TraeCorrelativoVoucher(Logueo.CodigoEmpresa, Logueo.Anio,
                                Logueo.Mes, txtLibro.Text, txtNroVoucher.Text, out nuevoNumeroVoucher);
                //Poner valor por defecto a referencia inventario
                txtNroDocRespInventario.Text = nuevoNumeroVoucher;
                txtNroVoucher.Text = nuevoNumeroVoucher;

         
            }
        }
        #endregion
        private string DameDescripcion(string codigo, string flag)
        {

            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, codigo, flag, out descripcion);
            return descripcion;
        }
        private void txtTipoDocumento_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            string descripcionref = "";

            if (txtTipoDocumento.Text != "")
            {
                descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtTipoDocumento.Text, "TD");
                if (descripcion == "???" || descripcion == "")
                {
                    Util.ShowAlert("Tipo de documento No Valido");
                    return;
                }

                //
                // Traer Referencia Tipo Documento
                descripcionref = DameDescripcion(txtTipoDocumento.Text, "TDREF");
                if (descripcionref == "S")
                {
                    gboxdocmodifica.Visible = true;
                }
                else
                {
                    gboxdocmodifica.Visible = false;
                }
            }
        }

        private void txtbienoservicio_Leave(object sender, EventArgs e)
        {
            string descripcion = DameDescripcion("30" + txtbienoservicio.Text.Trim(), "GLO02");
            lblBienOServicio.Text = descripcion;
            txtCodTransInventario.Focus();
        }

        private void txtLibro_Leave(object sender, EventArgs e)
        {
            string descripcion = DameDescripcion(txtLibro.Text, "LI");
            txtLibroDesc.Text = descripcion;
        }

        private void txtAsientoTipo_Leave(object sender, EventArgs e)
        {
            string descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtAsientoTipo.Text.Trim(), "AST");
            txtAsientoTipoDesc.Text = descripcion;
        }

        private void txtCodTransInventario_Leave(object sender, EventArgs e)
        {
            //string descripcion = DameDescripcion
            string descripcion = DameDescripcion(Logueo.CodigoEmpresa+txtCodTransInventario.Text, "TRANSA");
            txtCodTransInventarioDesc.Text = descripcion;
        }

        private void txtTipDocRespInventario_Leave(object sender, EventArgs e)
        {
            txtTipDocRespInventarioDesc.Text =  DameDescripcion(Logueo.CodigoEmpresa + txtTipDocRespInventario.Text, "TDG");

        }

        private void txttipooperacion_Leave(object sender, EventArgs e)
        {
            txttipooperacionDesc.Text = DameDescripcion("15" + txttipooperacion.Text, "GL");
        }

        private void txttiposervicio_Leave(object sender, EventArgs e)
        {
            string codigoBusqueda = txttiposervicio.Text+ dtpFechaDocumento.Value.ToShortDateString();

            string descripcion = DameDescripcion(codigoBusqueda, "DETRADESCRI");
            txttiposervicioDesc.Text = descripcion;

            string porcentaje = DameDescripcion(txttiposervicio.Text +
                 dtpFechaDocumento.Value.ToShortDateString(), "DETRATASA");

            txtporcentaje.Text = porcentaje;  
        }

        private void txtLibro_TextChanged(object sender, EventArgs e)
        {
            if (txtLibro.Text != "")
            { 
                txtLibroDesc.Text =  DameDescripcion(txtLibro.Text, "LI");
            }
        }

        private void txtAsientoTipo_TextChanged(object sender, EventArgs e)
        {
            if (txtAsientoTipo.Text != "")
            {
                txtAsientoTipoDesc.Text = DameDescripcion(Logueo.CodigoEmpresa + txtAsientoTipo.Text, "AST");
            }
        }

        private void txtTipDocRespInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtTipDocRespInventario.Text != "")
            {
                txtTipDocRespInventarioDesc.Text = DameDescripcion(Logueo.CodigoEmpresa + txtTipDocRespInventario.Text, "TDG");
            }            
        }

        private void txtCodTransInventario_TextChanged(object sender, EventArgs e)
        {
            if (txtCodTransInventario.Text != "")
            {
                string descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtCodTransInventario.Text, "TRANSA");
                txtCodTransInventarioDesc.Text = descripcion;
            }
        }

        private void txttipooperacion_TextChanged(object sender, EventArgs e)
        {
            if (txttipooperacion.Text != "")
            {
                
                string descripcion = DameDescripcion("15" + txttipooperacion.Text.Trim(), "GL");                
                txttipooperacionDesc.Text = descripcion;
            }
        }

        private void txttiposervicio_TextChanged(object sender, EventArgs e)
        {
            if (txttiposervicio.Text != "")
            {

                string codigoBusqueda = txttiposervicio.Text + dtpFechaDocumento.Value.ToShortDateString();

                string descripcion = DameDescripcion(codigoBusqueda, "DETRADESCRI");
                txttiposervicioDesc.Text = descripcion;
            }
        }
        private void txtnrodocumento_Leave(object sender, EventArgs e)
        {
            //if (txtNroDocRespInventario.Text.Trim() == "")
            //{
            //   // txtNroDocRespInventario.Text = txtnrodocumento.Text.Trim();
            //}
        }

        

        private void txtImporteAfecto_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteInafecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteIgvEquiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }
        
        private void txtImporteDocumentoEquiv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteIgvEquiv_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteIgvEquiv.Text.Trim() == "" ? "0" : txtImporteIgvEquiv.Text.Trim();
            txtImporteIgvEquiv.Text = Util.NumberFormat(valor, formatonumero);
            
        }

        

        private void txtImporteDocumentoEquiv_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteDocumentoEquiv.Text.Trim() == "" ? "0" : txtImporteDocumentoEquiv.Text.Trim();
            txtImporteDocumentoEquiv.Text = Util.NumberFormat(valor, formatonumero);
        }

        private void txtTipocambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Util.ValidaFormatoDecimal(e);
        }

        private void txtImporteIgv_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteIgv.Text.Trim() == "" ? "0" : txtImporteIgv.Text.Trim();
            txtImporteIgv.Text = Util.NumberFormat(valor, formatonumero);
        }

        private void txtImporteDocumento_Leave(object sender, EventArgs e)
        {
            string valor = txtImporteDocumento.Text.Trim() == "" ? "0" : txtImporteDocumento.Text.Trim();
            txtImporteDocumento.Text = Util.NumberFormat(valor);
        }

        private void txtPorIgv_Leave(object sender, EventArgs e)
        {
            if (Util.EsNumero(txtPorIgv.Text) == true)
            {
                CalcularTotales();
            }
        }

        private void txtdocmodtipo_KeyDown(object sender, KeyEventArgs e)
        {
               if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmDocuModificaTipo);
            }
        }

        private void txtdocmodtipo_Leave(object sender, EventArgs e)
        {
            string descripcion = "";

            if (txtdocmodtipo.Text != "")
            {
                // Traer Descripcion Tipo Documento
                descripcion = DameDescripcion(Logueo.CodigoEmpresa + txtdocmodtipo.Text, "TD");
                txtdocmodtipodesc.Text = descripcion;
            }
        }

        private void dtpFechaDocumento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {
                      //LLENA LOS DATOS DEL SP A TRAER DE LA BASE DE DATOS
            if (txtConcepto.Enabled == true)
            {
                this.gridSugerencia.DataSource = ProvisionFacturaLogic.Instance.AutoCompletaMotivoProvision(Logueo.CodigoEmpresa, txtConcepto.Text);
                if (gridSugerencia.Rows.Count == 0)
                {
                    this.gpxFlotante.Visible = false;
                    txtConcepto.Focus();
                }
                else
                {
                    this.gpxFlotante.Visible = true;
                    txtConcepto.Focus();

                }

            }
        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {
             string textconcepto = txtConcepto.Text;
            int contador = textconcepto.Length;
            //MOSTRAR GRILLA FLOTANTE
            if (e.KeyValue == (char)Keys.Back || txtConcepto.Text == String.Empty)
            {
                this.gpxFlotante.Visible = false;
            }
            else 
            {
                  gridSugerencia.Focus();
            }
           
        }

        private void gridSugerencia_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
                      GridViewRowInfo row = this.gridSugerencia.CurrentRow;
            string Concepto = Util.GetCurrentCellText(row, "CO07DESCRIPCION");
            txtConcepto.Text = Concepto;

        }

        private void gridSugerencia_KeyDown(object sender, KeyEventArgs e)
        {
            GridViewRowInfo row = gridSugerencia.CurrentRow;
            if (e.KeyValue == (char)Keys.Enter)
            {
                string DescripcionConcepto = Util.GetCurrentCellText(row, "CO07DESCRIPCION");
                txtConcepto.Text = DescripcionConcepto;
                gpxFlotante.Visible = false;

            }
            txtConcepto.Focus();
            //txtbienoservicio.Focus();
        }

        private void txtCodTransInventario_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gridSugerencia_DoubleClick(object sender, EventArgs e)
        {
            this.gpxFlotante.Visible = false;
            
        }

        private void gridSugerencia_Click(object sender, EventArgs e)
        {
            
            GridViewRowInfo row = gridSugerencia.CurrentRow;
            string DescripcionConcepto = Util.GetCurrentCellText(row, "CO07DESCRIPCION");
            txtConcepto.Text = DescripcionConcepto;
            this.gpxFlotante.Visible = false;
        }

        

        

               
    }
}

