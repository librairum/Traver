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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Com.UI.Win
{
    public partial class frmBusqueda : frmBaseHelp
    {
        private string _codigoAlmacen = string.Empty;
        private string _PedidoVentaSeleccionado = string.Empty;
        
        private int _positionX = 0;
        private int _positionY = 0;
        private bool _esTipEntrada = false;
        private bool ProdxProv = false;
        private string _codTipDocumento = "";
        private object _variable;
        public frmBusqueda()
        {
            InitializeComponent();
        }
        private enmAyuda _tipoAyuda;
        public frmBusqueda(enmAyuda tipoAyuda, int positionX = 0, int positionY = 0)
        {
            InitializeComponent();
            this._tipoAyuda = tipoAyuda;
            this._positionX = positionX;
            this._positionY = positionY;

            CrearColumnas(tipoAyuda);
        }
        
        public frmBusqueda(enmAyuda tipoAyuda, string codigoAlmacen,string pedidoventa)
        {
            InitializeComponent();
            this._tipoAyuda = tipoAyuda;
            this._codigoAlmacen = codigoAlmacen;
            this._PedidoVentaSeleccionado = pedidoventa;

            //this.gridControl.DoubleClick += new HandledEventHandler(gridControl_DoubleClick);

            CrearColumnas(tipoAyuda);
        }
        public frmBusqueda(enmAyuda tipoAyuda, bool estipMovEntrada) {
            InitializeComponent();
            _esTipEntrada = estipMovEntrada;
            CrearColumnas(tipoAyuda);
        
        }
        
        public frmBusqueda(enmAyuda tipoAyuda, object variables) {
            InitializeComponent();
            this._tipoAyuda = tipoAyuda;
            this._variable = variables;
            //this.ProdxProv = codigoProv;
            CrearColumnas(tipoAyuda);
        }
        private void CrearColumnas(enmAyuda tipoAyuda)
        {

            this.gridControl.Columns.Clear();
            this.gridControl.ShowGroupPanel = false;
            this.gridControl.AllowAddNewRow = false;
            this.gridControl.EnableHotTracking = true;
            this.gridControl.AllowColumnReorder = true;
            this.gridControl.ShowFilteringRow = true;


            this.gridControl.EnableFiltering = true;
            //this.gridControl.EnableCustomFiltering = true;

            this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.gridControl.AutoGenerateColumns = false;
            string[] datos;
            List<CuentaCorriente> listaDestinatario = new List<CuentaCorriente>();
            switch (tipoAyuda)
            {


                case enmAyuda.enmComprasFormaPago:
                    CreateGridColumn(gridControl, "Codigo", "Co02codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "Co02descripcion", 0, "", 120);
                    gridControl.DataSource = FormaPagoLogic.Instance.TraeFormaPagoCompras(Logueo.CodigoEmpresa);
                    break;
            //PROVEEDOR 2 COLUMNAS MOSTRAR
                    //PENDIENTE EL SEGUNDO PARAMETRO DE TRAEAYUDAPROVEEDOR
                case enmAyuda.enmProveedor:
                    CreateGridColumn(gridControl, "Codigo", "ccm02cod", 0, "", 70);
                    CreateGridColumn(gridControl, "nombre", "ccm02nom", 0, "", 90);
                    CreateGridColumn(gridControl, "direccion", "ccm02dir", 0, "", 170, true, false, false);
                    CreateGridColumn(gridControl, "telefono", "ccm02tel", 0, "", 70, true, false, false);
                    CreateGridColumn(gridControl, "ruc", "ccm02ruc", 0, "", 90, true, false, false);
                    CreateGridColumn(gridControl, "ccm02Aten", "ccm02Aten", 0, "", 90, true, false, false);
                    CreateGridColumn(gridControl, "ccm02moneda", "ccm02moneda", 0, "", 90, true, false, false);
                    CreateGridColumn(gridControl, "Ccm02Forpag", "Ccm02Forpag", 0, "", 90, true, false, false);
                     
                    gridControl.DataSource =  CuentaCorrienteLogic.Instance.TraeAyudaProveedor(Logueo.CodigoEmpresa, Logueo.TipoAnalisisProveedor);
                    //CODIGO QUE SE COLOCA STARWITH
                    this.gridControl.Columns[0].FilterDescriptor = new Telerik.WinControls.Data.FilterDescriptor(null, Telerik.WinControls.Data.FilterOperator.StartsWith, null);
                    this.Titulo = "Proveedores";
                    break;

                    //PENDIENTE TRAE DOCUMENTOX PROVEEDOR SEGUNDO PARAMETRO
                    //AGREGAR DOCUMENTOXPROVEEDOR
                case enmAyuda.enmDocXProveedor:
                    CreateGridColumn(gridControl, "CO05TIPDOC", "CO05TIPDOC", 0, "", 90, true, false, true);
                    CreateGridColumn(gridControl, "CO05NRODOC", "CO05NRODOC", 0, "", 90, true, false, true);
                    CreateGridColumn(gridControl, "CO05FECHA", "CO05FECHA", 0, "", 90, true, false, true);
                    CreateGridColumn(gridControl, "CO05MONEDA", "CO05MONEDA", 0, "", 90, true, false, true);
                    CreateGridColumn(gridControl, "CO05IMPORT", "CO05IMPORT", 0, "", 90, true, false, false);
                    CreateGridColumn(gridControl, "CO05IMPDOL", "CO05IMPDOL", 0, "", 90, true, false, false);
                   
                    gridControl.DataSource = RetencionLogic.Instance.TraerDocumentoXProveedor(Logueo.CodigoEmpresa, this._variable.ToString(),"","*");
                    break;
                case enmAyuda.enmDirEntrega:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 250);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 250);                                        
                    gridControl.DataSource = GlobalLogic.Instance.TraeRegistrosDeTablaGlobal("35", "", "*");
                    this.Titulo = "Direfccion de Entrega";
                    break;
                case enmAyuda.LugarDeEntra:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 250);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 250);
                    gridControl.DataSource = GlobalLogic.Instance.TraeRegistrosDeTablaGlobal("66", "", "*");
                    this.Titulo = "Lugar De Entra";
                    break;
                case enmAyuda.enmusuariologistica:
                    CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Nombre", "nombre", 0, "", 90);
                    CreateGridColumn(gridControl, "Cargo", "cargo", 0, "", 170, true, false, false);
                    gridControl.DataSource = usuariologisticalogic.Instance.TraeAyudausuariologistica(Logueo.CodigoEmpresa);
                    break;

                case enmAyuda.enmMoneda:
                    
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 250);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 250);
                    CreateGridColumn(gridControl, "newColumn", "newColumn", 0, "", 250);
                    //CreateGridColumn(gridControl, "Tipo de Cambio", "", 0, "", 250);

                    //gridControl.DataSource = GlobalLogic.Instance.TraeRegistrosDeTablaGlobal("28", "", "*");
                    //cambiado a valor 56  un parametro,para llamar la ventana de ayuda 
      

                    gridControl.DataSource = GlobalLogic.Instance.TraeRegistrosDeTablaGlobal("56", "", "*");

                    break;
                    //NUEVO AYUDA enmCliente_TipoDoc
                case enmAyuda.enmCliente_TipoDoc:
                    CreateGridColumn(gridControl, "glo01codigo", "glo01codigo", 0, "", 250);
                     CreateGridColumn(gridControl, "glo01descripcion", "glo01descripcion", 0, "", 250);
                    //this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                    //              Util.GetCurrentCellText(gridControl, "glo01descripcion");
                     gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("05", "GLO", "", "*");
                    break;
                case enmAyuda.enmCentroCosto:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 200);
                    gridControl.DataSource = CentroCostoLogic.Instance.TraeCentroCostoCompras(Logueo.CodigoEmpresa,Logueo.Anio);
                    break;
                case enmAyuda.enmBuscaArti:
                    //this variable -> C o T
                    if(Util.convertiracadena(this._variable) == "C"){
                        CreateGridColumn(gridControl, "Codigo", "In01key", 0, "", 90);
                    }else if(Util.convertiracadena(this._variable) == "T"){
                        CreateGridColumn(gridControl, "Codigo", "In01key1", 0, "", 90);
                    }                                                            
                    CreateGridColumn(gridControl, "Descripcion", "In01Deslar", 0, "", 200);                    
                    CreateGridColumn(gridControl, "Unidad", "IN01UNIMED", 0, "", 200);
                    CreateGridColumn(gridControl, "UnidadEquivalente", "IN01UNIDADEQUI", 0, "", 200);
                    gridControl.DataSource = ArticuloLogic.Instance.TraeAyudaArticuloCompras(Logueo.CodigoEmpresa, Logueo.Anio, Util.convertiracadena(this._variable), "Naturaleza", Logueo.PS_codnaturaleza);
                    //ArticuloLogic.Instance.TraeAyudaArticuloCompras(Logueo.CodigoEmpresa,Logueo.Anio,this._variable,"xx","")
                    break;
                case enmAyuda.enmCuentaMovimiento:
                    CreateGridColumn(gridControl, "ccm01cta", "ccm01cta", 0, "", 90);
                    CreateGridColumn(gridControl, "ccm01des", "ccm01des", 0, "", 90);
                    CreateGridColumn(gridControl, "ccm01dn", "ccm01dn", 0, "", 90);
                    CreateGridColumn(gridControl, "ccm01mov", "ccm01mov", 0, "", 90);
                    gridControl.DataSource = ServiciosCompraLogic.Instance.TraeAyudaCuentasSoloMov(Logueo.CodigoEmpresa, Logueo.Anio);
                    break;
                case enmAyuda.enmUniMed:
                    CreateGridColumn(gridControl, "in21codigo", "in21codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "in21descri", "in21descri", 0, "", 150);
                    gridControl.DataSource = ServiciosCompraLogic.Instance.TraeAyudaUnidadMedida(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmLineaArti:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 90, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 150, true, false, true);
                    gridControl.DataSource = LineaArticuloLogic.Instance.TraeLineaArticulo(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmGrupoArti:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 120, true, false, true);
                    datos = this._variable.ToString().Split('|');
                    this.gridControl.DataSource = LineaArticuloLogic.Instance.TraeGrupoArticulo(Logueo.CodigoEmpresa, datos[0]);
                    break;
                case enmAyuda.enmSubGrupoArti:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 150, true, false, true);
                    datos = this._variable.ToString().Split('|');
                    this.gridControl.DataSource = LineaArticuloLogic.Instance.TraeSubGrupoArticulo(Logueo.CodigoEmpresa, datos[0], datos[1]);
                    break;
                case enmAyuda.enmCuentaContable:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120, true, false, true);
                    this.gridControl.DataSource = GlobalLogic.Instance.TraeRegistrosDeTablaGlobal("27", "", "*");
                    break;
                case enmAyuda.enmUniMedEquiv:
                    CreateGridColumn(gridControl, "in21codigo", "in21codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "in21descri", "in21descri", 0, "", 150);
                    gridControl.DataSource = ServiciosCompraLogic.Instance.TraeAyudaUnidadMedida(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmAlmacen:
                    DetalleAlmacen da = new DetalleAlmacen();
                    CreateGridColumn(gridControl, "Codigo", "In09codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "In09Descripcion", 0, "", 150);
                    this.gridControl.DataSource =  da.TraeAyuda();
                    break;

                case enmAyuda.enmCliente_FormaPago:
                    CreateGridColumn(gridControl, "Codigo", "Co02codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "Co02descripcion", 0, "", 200);
                    gridControl.DataSource = FormaPagoLogic.Instance.TraeHelpFormaPago(Logueo.CodigoEmpresa, "", "*");
                    break;

                case enmAyuda.enmCliente_SituacionSunat:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("07", "GLO", "", "*");
                    break;

                case enmAyuda.enmCliente_SituacionDomi:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("08", "GLO", "", "*");
                    break;

                case enmAyuda.enmCliente_Pais:
                    CreateGridColumn(gridControl, "Codigo", "glo04Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo04descripcion", 0, "", 120);
                    //gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("35", "GLO", "", "*");
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("04");
                    break;

                case enmAyuda.enmTipoDocumento:

                    CreateGridColumn(gridControl, "codigo", "codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "descripcion", "descripcion", 0, "", 70);
                    gridControl.DataSource = TipoDocumentoLogic.Instance.ComprasTraeAyudaTiposDocumentos(Logueo.CodigoEmpresa, "ccb02cod", "*");
                    break;
                case enmAyuda.enmDocuModificaTipo:

                    CreateGridColumn(gridControl, "codigo", "codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "descripcion", "descripcion", 0, "", 70);
                    gridControl.DataSource = TipoDocumentoLogic.Instance.ComprasTraeAyudaTiposDocumentos(Logueo.CodigoEmpresa, "ccb02cod", "*");
                    break;
                    
                case enmAyuda.enmTransaccion:
                    CreateGridColumn(gridControl, "Codigo", "In12tipDoc", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "In12DesLar", 0, "", 70);
                    gridControl.DataSource = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmTipoDocumentoGuia:
                    CreateGridColumn(gridControl, "Codigo", "in15Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "in15Descripcion", 0, "", 70);
                    gridControl.DataSource =   TransaccionLogic.Instance.TraerTransaccion(Logueo.CodigoEmpresa);

                    
                    break;

                case enmAyuda.enmAsiento:
                    CreateGridColumn(gridControl, "Codigo", "ccc03cod", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "ccc03des", 0, "", 70);
                    CreateGridColumn(gridControl, "Libro", "ccc03lib", 0, "", 70, true, false, false);
                    gridControl.DataSource = AsientoTipoLogic.Instance.ComprasTraeAsientosTipo(Logueo.CodigoEmpresa, Logueo.Anio, "ccc03cod", "*");
                    break;
                case enmAyuda.enmLibros:
                    CreateGridColumn(gridControl, "Codigo", "ccb02cod", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "ccb02des", 0, "", 70);
                    gridControl.DataSource = ProvisionFacturaLogic.Instance.TraeAyudaLibroTodos(Logueo.CodigoEmpresa,Logueo.Anio, "", "*");
                    break;
                case enmAyuda.enmBienServicio:
                    CreateGridColumn(gridControl, "Codigo", "glo02codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo02descripcion", 0, "", 70);
                    gridControl.DataSource =  GlobalLogic.Instance.TraeLibros("30", "glo02codigo", "*");
                    break;
                case enmAyuda.enmServicioDetraccion:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 70);
                    CreateGridColumn(gridControl, "TasaRetencion", "TasaRetencion", 0, "", 70);
                    gridControl.DataSource = ServicioDetraccionLogic.Instance.TraeAyuda("", "*", this._variable.ToString());                    
                    break;
                case enmAyuda.enmTipoOperacionDetraccion:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 70);                                            
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("15", "GLO", "", "*");
                    break;
                case enmAyuda.enmHabyMov:
                    CreateGridColumn(gridControl, "Codigo", "ccm01cta", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "ccm01des", 0, "", 70);
                    //tipo de moneda S-> Soles y D -> Dolares
                    CreateGridColumn(gridControl, "ccm01dn", "ccm01dn", 0, "", 70);
                    //analisis para habilitar cuenta corriente
                    CreateGridColumn(gridControl, "ccm01ana", "ccm01ana", 0, "", 70, true, false, false);
                    //centro de costo flag para habilitar en la grilla
                    CreateGridColumn(gridControl, "ccm01cc", "ccm01cc", 0, "", 70, true, false, false);
                    //centro de gestion flag para habilitar en al grilla
                    CreateGridColumn(gridControl, "ccm01cg", "ccm01cg", 0, "", 70, true, false, false);
                    ////columna de registrar afecta e infacto
                    //CreateGridColumn(gridControl, "ccm01ColReg", "ccm01ColReg", 0, "", 70, true, false, false);
                    //columna nueva!!!!!!!!!!!
                    CreateGridColumn(gridControl, "ccm01ams", "ccm01ams", 0, "", 70, true, false, false);
                    
                    gridControl.DataSource = VoucherLogic.Instance.TraeCuentasHabYMov(Logueo.CodigoEmpresa, Logueo.Anio, "", "*");
                    this.gridControl.Columns[0].FilterDescriptor = new Telerik.WinControls.Data.FilterDescriptor(null, Telerik.WinControls.Data.FilterOperator.StartsWith, null);

                    break;
                case enmAyuda.enmCentroGestion:

                    CreateGridColumn(gridControl, "Codigo", "ccb02cod", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "ccb02des", 0, "", 70);
                    /*
                     tblHelp.Columns(0).DataField = "ccb02cod"
                    tblHelp.Columns(1).DataField = "ccb02des"
                     */

                    string flagGestion = "";
                    GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + Logueo.Anio + this._variable.ToString(), "UG", out flagGestion);
                    
                    this.gridControl.DataSource = VoucherLogic.Instance.TraeCenGesTipoSoloMo(Logueo.CodigoEmpresa, "", "*", flagGestion);
                    //GlobalLogic.Instance.DameDescripcionCompras(Logueo.CodigoEmpresa + Logueo.Anio + this._variable.ToString(), "UG", out flagGestion);
                    break;
                case enmAyuda.enmDocumentosPendientes:
                    
                    string cuentaContable = "", cuentaCorriente = "", fechaDocumento = "";
                    CreateGridColumn(gridControl, "T/D", "ccb13tipdoc", 0, "", 70);
                    CreateGridColumn(gridControl, "Num.Doc.", "ccb13ndoc", 0, "", 100);
                    CreateGridColumn(gridControl, "Fec.Doc.", "ccb13fedoc", 0, "{0:dd/MM/yyyy}", 90);
                    CreateGridColumn(gridControl, "Saldo S/.", "ccb13salsol", 0, "{0:####.##0000.00}", 70);
                    CreateGridColumn(gridControl, "Saldo US$", "ccb13saldol", 0, "{0:####.##0000.00}", 70);
                    cuentaContable = this._variable.ToString().Split('|')[0];
                    cuentaCorriente = this._variable.ToString().Split('|')[1];
                    fechaDocumento = this._variable.ToString().Split('|')[2];
                        
                      this.gridControl.DataSource =  VoucherLogic.Instance.TraeDocumPendientes(Logueo.CodigoEmpresa, Logueo.Anio, 
                                                                            cuentaContable, cuentaCorriente, fechaDocumento, "", "*");
                    break;
                case enmAyuda.enmTipDocParaVoucher:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120);                                           
                    this.gridControl.DataSource =  GlobalLogic.Instance.ComprasTraeTablas("06", "GLO", "", "*");
                    break;
                case enmAyuda.enmArticulosOrdenCompra:
                    CreateGridColumn(gridControl, "Codigo", "CodigoArticulo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "NombreArticulo", 0, "", 70);
                    CreateGridColumn(gridControl, "Cantidad", "Cantidad", 0, "", 70);
                    CreateGridColumn(gridControl, "Codigo", "CantidadAtendida", 0, "", 70, false, false, false);
                    CreateGridColumn(gridControl, "Codigo", "ImporteBruto", 0, "", 70, false, false, false);
                    CreateGridColumn(gridControl, "Codigo", "Item", 0, "", 70, false, false, false);
                    CreateGridColumn(gridControl, "Unidad", "Unidad", 0, "", 70, false, false, false);
                    datos = this._variable.ToString().Split('|');
                    this.gridControl.DataSource = 
                    GuiaCompraLogic.Instance.TraeAyudaArticulosOC(Logueo.CodigoEmpresa,
                        datos[0], datos[1], datos[2], datos[3]);

                    break;
               default:
                    break;
            }

        }



        protected override void OnAceptar()
        {
            if (this.gridControl.RowCount == 0) return;
            if (this.gridControl.SelectedRows.Count == 0) return;
            this.Result = string.Empty;
            List<GuiaTransporte> listaGuiaTransp;
            GuiaTransporte guiaTransporte;
            DetalleGuiaTransporte detalleGuiaTranportista;
            TipoDocumentoVentas tipdocVentas;
            CuentaCorriente destinatario = new CuentaCorriente();

            //DetalleGuiaTransportista detalleGuiaTranportista ;
            //AQUI ES EL RESULT
            switch (this._tipoAyuda)
            {

                
                case enmAyuda.enmComprasFormaPago:
                    this.Result = Util.GetCurrentCellText(gridControl, "Co02codigo") + "|" + 
                                  Util.GetCurrentCellText(gridControl, "Co02descripcion");                          
                    break;
                 
                    case enmAyuda.enmProveedor:
                    this.Result = Util.GetCurrentCellText(gridControl, "ccm02cod") + "|" +
                                    Util.GetCurrentCellText(gridControl, "ccm02nom") + "|" +
                                    Util.GetCurrentCellText(gridControl, "ccm02dir") + "|" +
                                    Util.GetCurrentCellText(gridControl, "ccm02tel") + "|" +
                                    Util.GetCurrentCellText(gridControl, "ccm02ruc") + "|" +
                                    Util.GetCurrentCellText(gridControl, "ccm02Aten") + "|" +
                                    Util.GetCurrentCellText(gridControl, "ccm02moneda") + "|" + 
                                    Util.GetCurrentCellText(gridControl, "Ccm02Forpag");                                                            
                    break;
                case enmAyuda.enmDirEntrega:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                                Util.GetCurrentCellText(gridControl, "glo01descripcion");
                    
                    break;
                case enmAyuda.LugarDeEntra:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                              Util.GetCurrentCellText(gridControl, "glo01descripcion");
                    break;
              case enmAyuda.enmusuariologistica:
                    this.Result = Util.GetCurrentCellText(gridControl, "codigo") + "|" +
                       Util.GetCurrentCellText(gridControl, "nombre");
                    break;


                case enmAyuda.enmMoneda:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo").Trim() + "|" + 
                                  Util.GetCurrentCellText(gridControl, "glo01descripcion").Trim();                    
                    break;
                   // AGREGAR OTRO MAS DOCUMENTOXPROVEEDOR
                case enmAyuda.enmDocXProveedor:
                    this.Result = Util.GetCurrentCellText(gridControl, "CO05TIPDOC").Trim() + "|" +
                                  Util.GetCurrentCellText(gridControl, "CO05NRODOC").Trim() + "|" +
                                  Util.GetCurrentCellText(gridControl, "CO05FECHA").Trim() + "|" +
                                  Util.GetCurrentCellText(gridControl, "CO05MONEDA").Trim() + "|" +
                                  Util.GetCurrentCellText(gridControl, "CO05IMPORT").Trim() + "|" +
                                  Util.GetCurrentCellText(gridControl, "CO05IMPDOL").Trim();
                    break;
                case enmAyuda.enmCentroCosto:
                    this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                    Util.GetCurrentCellText(gridControl, "Descripcion");
                    break;
                case enmAyuda.enmBuscaArti:
                    if (Util.convertiracadena(this._variable) == "C")
                    {
                        this.Result = Util.GetCurrentCellText(gridControl, "In01key") + "|" +
                                      Util.GetCurrentCellText(gridControl, "In01Deslar") + "|" +
                                      Util.GetCurrentCellText(gridControl, "IN01UNIDADEQUI");
                    }
                    else if(Util.convertiracadena(this._variable) == "T") {
                        this.Result = Util.GetCurrentCellText(gridControl, "In01key1") + "|" +
                                          Util.GetCurrentCellText(gridControl, "In01Deslar") + "|" +
                                          Util.GetCurrentCellText(gridControl, "IN01UNIMED");
                    }
                    break;
                case enmAyuda.enmCuentaMovimiento:
                    this.Result = Util.GetCurrentCellText(gridControl, "ccm01cta") + "|" + Util.GetCurrentCellText(gridControl, "ccm01des");                    
                    
                    break;
                case enmAyuda.enmUniMed:
                    this.Result = Util.GetCurrentCellText(gridControl, "in21codigo") + "|" + Util.GetCurrentCellText(gridControl, "in21descri");
                                        
                    break;
                    //NUEVO enmCLiente_TipoDoc
                case enmAyuda.enmCliente_TipoDoc:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                                  Util.GetCurrentCellText(gridControl, "glo01descripcion");
                    break;
                case enmAyuda.enmLineaArti:
                    this.Result = Util.GetCurrentCellText(gridControl, "Codigo");
                    
                    break;
                case enmAyuda.enmGrupoArti:
                    this.Result = Util.GetCurrentCellText(gridControl, "Codigo");
                                                            
                    break;
                case enmAyuda.enmSubGrupoArti:
                    this.Result = Util.GetCurrentCellText(gridControl, "Codigo");
                    break;
                case enmAyuda.enmCuentaContable:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + Util.GetCurrentCellText(gridControl, "glo01descripcion");                                    
                    break;
                case enmAyuda.enmUniMedEquiv:
                    this.Result = Util.GetCurrentCellText(gridControl, "in21codigo") + "|" + Util.GetCurrentCellText(gridControl, "in21descri");
                    break;
                case enmAyuda.enmAlmacen:
                    this.Result = Util.GetCurrentCellText(gridControl, "In09codigo") + "|" + Util.GetCurrentCellText(gridControl, "In09Descripcion");                    
                    break;
                case enmAyuda.enmCliente_FormaPago:
                    this.Result = Util.GetCurrentCellText(gridControl, "Co02codigo") + "|" + Util.GetCurrentCellText(gridControl, "Co02descripcion");
                    break;
                case enmAyuda.enmCliente_SituacionSunat:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + Util.GetCurrentCellText(gridControl, "glo01descripcion");                    
                    break;
                case enmAyuda.enmCliente_SituacionDomi:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + Util.GetCurrentCellText(gridControl, "glo01descripcion");                    
                    break;
                case enmAyuda.enmCliente_Pais:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo04Codigo") + "|" + Util.GetCurrentCellText(gridControl, "glo04descripcion");                    
                    break;

                case enmAyuda.enmTipoDocumento:
                    this.Result = Util.GetCurrentCellText(gridControl, "codigo") + "|" + Util.GetCurrentCellText(gridControl, "descripcion");

                    break;
                case enmAyuda.enmDocuModificaTipo:
                    this.Result = Util.GetCurrentCellText(gridControl, "codigo") + "|" + Util.GetCurrentCellText(gridControl, "descripcion");

                    break;
                case enmAyuda.enmTransaccion:
                    
                    this.Result = Util.GetCurrentCellText(gridControl, "In12tipDoc") + "|" + Util.GetCurrentCellText(gridControl, "In12DesLar");                        
                    break;
                case enmAyuda.enmTipoDocumentoGuia:
                    this.Result = Util.GetCurrentCellText(gridControl, "in15Codigo") + "|" + Util.GetCurrentCellText(gridControl, "in15Descripcion");
                    break;

                 case enmAyuda.enmAsiento:
                    this.Result = Util.GetCurrentCellText(gridControl, "ccc03cod") + "|" + Util.GetCurrentCellText(gridControl, "ccc03des") + "|" + Util.GetCurrentCellText(gridControl, "ccc03lib");  
                    break;

                case enmAyuda.enmLibros:
                    this.Result = Util.GetCurrentCellText(gridControl, "ccb02cod") + "|" + Util.GetCurrentCellText(gridControl, "ccb02des");                    
                    break;

                case enmAyuda.enmBienServicio:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo02codigo") + "|" + Util.GetCurrentCellText(gridControl, "glo02descripcion");
                    break;

                case enmAyuda.enmServicioDetraccion:
                    this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" + Util.GetCurrentCellText(gridControl, "Descripcion") + "|"
                        + Util.GetCurrentCellText(gridControl, "TasaRetencion");
                    break;
                case enmAyuda.enmTipoOperacionDetraccion:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + Util.GetCurrentCellText(gridControl, "glo01descripcion");
                    
                    break;
                //ccm01ColReg 
                case enmAyuda.enmHabyMov:
                    this.Result = Util.GetCurrentCellText(gridControl, "ccm01cta") + "|" +
                        Util.GetCurrentCellText(gridControl, "ccm01des") + "|" +
                        Util.GetCurrentCellText(gridControl, "ccm01dn") + "|" +
                    Util.GetCurrentCellText(gridControl, "ccm01ana") + "|" +
                     Util.GetCurrentCellText(gridControl, "ccm01cc") + "|" +
                     Util.GetCurrentCellText(gridControl, "ccm01cg") + "|" +
                       Util.GetCurrentCellText(gridControl, "ccm01ams");
                    break;
                case enmAyuda.enmCentroGestion:
                    this.Result = Util.GetCurrentCellText(gridControl, "ccb02cod") + "|" + Util.GetCurrentCellText(gridControl, "ccb02des");
                     
                    break;
                case enmAyuda.enmDocumentosPendientes:
                    this.Result = Util.GetCurrentCellText(gridControl, "ccb13tipdoc") + "|" +
                    Util.GetCurrentCellText(gridControl, "ccb13ndoc") + "|" +
                    Util.GetCurrentCellText(gridControl, "ccb13fedoc") + "|" +
                    Util.GetCurrentCellText(gridControl, "ccb13salsol") + "|" +
                    Util.GetCurrentCellText(gridControl, "ccb13saldol");
                    break;
                case enmAyuda.enmTipDocParaVoucher:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + Util.GetCurrentCellText(gridControl, "glo01descripcion");                       
                    break;
                case enmAyuda.enmArticulosOrdenCompra:
                    this.Result = Util.GetCurrentCellText(gridControl, "CodigoArticulo") + "|" +
                     Util.GetCurrentCellText(gridControl, "NombreArticulo") + "|" +
                    Util.GetCurrentCellText(gridControl, "Cantidad") + "|" +
                    Util.GetCurrentCellText(gridControl, "CantidadAtendida") + "|" +
                     Util.GetCurrentCellText(gridControl, "ImporteBruto") + "|" +
                    Util.GetCurrentCellText(gridControl, "Item") + "|" +
                     Util.GetCurrentCellText(gridControl, "Unidad");
                    break;
                default:
                    break;
            }

            this.Close();
        }

        int CantidadRegistrosSeleccionados()
        {
            int registroseleccionados = 0;
            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                bool isCheckedGuiaPendiente = false;
                object value = row.Cells["chkSelect"].Value;
                isCheckedGuiaPendiente = isChkSelected(value);
                if(isCheckedGuiaPendiente)
                {
                    registroseleccionados++;    
                }
            }
            return registroseleccionados;
        }
        bool isChkSelected(object valorseleccionado)
        { 
            bool respuesta = false;
            string valorCampo = Util.convertiracadena(valorseleccionado);
            string registroSeleccionado = Util.convertiracadena(valorseleccionado).ToUpper();
            if (valorCampo == "")
            {
                respuesta = false;
            }
            else if(valorCampo != "")
            { 
                if(registroSeleccionado == "TRUE" || registroSeleccionado == "ON")
                {
                    respuesta = true;
                }
            }
            
            return respuesta;

        }
        void focoFiltro()
        {
            try
            {
                this.gridControl.MasterView.TableFilteringRow.Cells[1].BeginEdit();
                
                //this.gridControl.TableElement.ViewInfo.TableFilteringRow.Cells[0].BeginEdit();

            }
            catch (Exception ex)
            {

            }
        }
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            OnAceptar();
        }

        private void frmBusqueda_Activated(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void frmBusqueda_Load(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location.X = this._positionX;
            //this.Location.Y = this._positionY;
                
        }

        private void frmBusqueda_Shown(object sender, EventArgs e)
        {
            focoFiltro();  
        }

    }
}
