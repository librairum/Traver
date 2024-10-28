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

namespace Fac.UI.Win
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
        public fabcGuiasTransporte formularioDetGuia { get; set; }
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
        //public frmBusqueda(enmAyuda tipoAyuda, string codigoTipDoc){
        //    InitializeComponent();
        //    this._tipoAyuda = tipoAyuda;
        //    this._codTipDocumento = codigoTipDoc;
        //    CrearColumnas(tipoAyuda);
        //}
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
                case enmAyuda.enmBuscaTipDoc:                   
                    CreateGridColumn(this.gridControl, "Codigo", "FAC01COD", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Descripcion", "FAC01DESC", 0, "", 120);
                    var bustatipdoc = SubPlantillaLogic.Instance.TraeAyudaTipDoc(Logueo.CodigoEmpresa, "FAC01COD", "*");
                    this.gridControl.DataSource = bustatipdoc;
                    this.lblTitulo.Text = "Tipo documento";
                    break;    
     
                case enmAyuda.enmBuscaPlantilla:
                    CreateGridColumn(this.gridControl, "Codigo", "FAC02COD", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Descripcion", "FAC02DESC", 0, "", 50);
                    var buscaplantilla = SubPlantillaLogic.Instance.TraeAyudaPlantilla(Logueo.CodigoEmpresa, "FAC02COD", "*");
                    this.gridControl.DataSource = buscaplantilla;
                    this.lblTitulo.Text = "Plantilla";
                    break;
                case enmAyuda.enmOperacionFE:
                    this.CreateGridColumn(this.gridControl, "´Codigo", "glo04Codigo", 0, "", 90, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "glo04descripcion", 0, "", 90, true, false, true);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("51");
                    break;

                case enmAyuda.enmEstablecimientoxSerie:
                    CreateGridColumn(this.gridControl, "Glo03Empresa", "Glo03Empresa", 0, "", 120, true, false, false);
                    CreateGridColumn(this.gridControl, "Codigo", "Glo03codigo", 0, "", 90);
                    CreateGridColumn(this.gridControl, "Descripcion", "Glo03Descripcion", 0, "", 120);
                    gridControl.DataSource = EstablecimientoLogic.Instance.TraerEstablecimiento(Logueo.CodigoEmpresa, "", "*");
                    this.lblTitulo.Text = "Establecimientos";
                    break;


                case enmAyuda.enmBuscaTipArt:
                    CreateGridColumn(this.gridControl, "Codigo", "glo01codigo", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Descripcion", "glo01descripcion", 0, "", 50);
                    var buscatipart = SubPlantillaLogic.Instance.TraeAyudaProductos("13", "glo01codigo", "*");
                    this.gridControl.DataSource = buscatipart;
                    this.lblTitulo.Text = "Tipo Articulo";
                    break;

                case enmAyuda.enmProductoSunat:
                   CreateGridColumn(this.gridControl, "Codigo", "Codigo", 0, "", 70); // 0
                   CreateGridColumn(this.gridControl, "Descripcion", "Descripcion", 0, "", 200); // 1

                   CreateGridColumn(this.gridControl, "Segmento", "SegmentoCodigo", 0, "", 70); // 2
                   CreateGridColumn(this.gridControl, "Descripcion", "SegmentoDescripcion", 0, "", 200);//3
                   CreateGridColumn(this.gridControl, "Familia", "FamiliaCodigo", 0, "", 70);//4
                   CreateGridColumn(this.gridControl, "Descripcion", "FamiliaDescripcion", 0, "", 200);//5
                   this.Width = 1200;

                   gridControl.DataSource = EquivProdSunatLogic.Instance.TraeAyudaEquivalencia("72");

                   this.Text = "Producto de equivalencia sunat";
                   break;
                    //AYUDA ESTADO SUNAT
                case enmAyuda.enmEstadoSUNAT:
                      CreateGridColumn(this.gridControl, "Codigo", "Codigo", 0, "", 70); 
                   CreateGridColumn(this.gridControl, "Descripcion", "Descripcion", 0, "", 200);
                   gridControl.DataSource = VoucherLogic.Instance.Traer_Spu_Fact_Trae_EStadoFacturas();
                   break;

                case enmAyuda.enmtipoVenta:
                    this.CreateGridColumn(this.gridControl, "CodigoTabla", "glo01codigotabla", 0, "", 90, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Codigo", "glo01codigo", 0, "", 90, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "glo01descripcion", 0, "", 90, true, false, true);
                    var tipodeventa = GlobalLogic.Instance.Spu_Glo_Trae_glo01tablas_Det("51", "glo01codigo", "*");

                    this.gridControl.DataSource = tipodeventa;

                    break;

                case enmAyuda.enmPlantillaFE:
                    this.CreateGridColumn(this.gridControl, "Fac70PlantillaFECod", "Fac70PlantillaFECod", 0, "", 90, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Fac70PlantillaFEDesc", "Fac70PlantillaFEDesc", 0, "", 90, true, false, true);
                    this.gridControl.DataSource = PlantillaLogic.Instance.TraePlantillaFE(this._variable.ToString());
                    break;
                //10/09/2020
                    //guia de transporte
                case enmAyuda.enmSubPlantilla:
                    this.CreateGridColumn(this.gridControl, "Codigo", "FAC03COD", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Descripcion", "FAC03DESC", 0, "", 50);
                    CreateGridColumn(this.gridControl, "FAC01COD", "FAC01COD", 0, "", 50,true,false,false);
                    CreateGridColumn(this.gridControl, "FAC02COD", "FAC02COD", 0, "", 50, true, false, false);
                    CreateGridColumn(this.gridControl, "FAC03CANITEMS", "FAC03CANITEMS", 0, "", 50, true, false, false);
                    CreateGridColumn(this.gridControl, "FAC03SERIEXDEF", "FAC03SERIEXDEF", 0, "", 50, true, false, false);
                    CreateGridColumn(this.gridControl, "FAC03TIPART", "FAC03TIPART", 0, "", 50, true, false, false);
                    var subplantilla = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC03_SUBPLANTILLA(Logueo.CodigoEmpresa, 
                                        "09", "FAC03COD", "*", Logueo.UserName);
                    this.gridControl.DataSource = subplantilla;
                    this.lblTitulo.Text = "SUBPLANTILLAS";

                    break;
                case enmAyuda.enmTransportista:
                    
                    CreateGridColumn(gridControl, "Codigo", "FAC60Codigo", 0, "", 50);
                    CreateGridColumn(gridControl, "Nombre", "FAC60Nombre", 0, "", 50);
                    var _transportista = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC60_TRANSPORTISTA(Logueo.CodigoEmpresa,
                        "", "*");
                    this.gridControl.DataSource = _transportista;
                    this.lblTitulo.Text = "Transportistas";
                    break;
                case enmAyuda.enmVehxTranporYchofer:
                    //string ructransportista = formularioDetGuia.txtRucTransportista.Text.Trim();
                    //string codchofer = formularioDetGuia.txtcodchofer.Text.Trim();
                    CreateGridColumn(this.gridControl, "Codigo", "FAC69codigo", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Marca remolque", "FAC69MarcaRemolque", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Placa remolque", "FAC69PlacaRemolque", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Marca SemiRemolque", "FAC69MarcaSemiRemolque", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Placa SemiRemolque", "FAC69PlacaSemiRemolque", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Cod.Chofer", "FAC69Codchofer", 0, "", 50);

                    string ructransportista = ((GuiaTransporte)this._variable).FAC02COD;
                    string codchofer = ((GuiaTransporte)this._variable).FAC03COD;
                     
                    var vehxTransporychofer = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_VehxTranporYchofer(Logueo.CodigoEmpresa, 
                       ructransportista , codchofer);
                    this.gridControl.DataSource = vehxTransporychofer;
                    this.lblTitulo.Text = "Vehiculos por chofer";
                    break;
                    
                case enmAyuda.enmchoferxtransportistas:

                    CreateGridColumn(this.gridControl, "Codigo", "FAC61Codigo", 0, "", 70);
                    CreateGridColumn(this.gridControl, "Nombres", "FAC61Nombres", 0, "", 70);
                    CreateGridColumn(this.gridControl, "Brevete", "FAC61Brevete", 0, "", 70);
                    //string _rucTransportista = txtRucTransportista.Text.Trim();

                    string rucTransportista = ((GuiaTransporte)this._variable).FAC02COD;
                    //formularioDetGuia.txtRucTransportista.Text.Trim();
                        ///((GuiaTransporte)Result).FAC02COD;
                    
                    var choferxtransportistas = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_choferxtransportistas(Logueo.CodigoEmpresa, rucTransportista);
                    this.gridControl.DataSource = choferxtransportistas;
                    this.lblTitulo.Text = "Chofer x Transportistas";
                    break;
                case enmAyuda.enmDestinatario:
                    //CreateGridColumn(this.gridControl, "Codigo", "FAC64CODIGO", 0, "", 70);
                    //CreateGridColumn(this.gridControl, "Nombre", "FAC64NOMBRE", 0, "", 70);
                    //var DESTINATARIO = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC64_DESTINATARIO(Logueo.CodigoEmpresa, 
                    //    "FAC64CODIGO", "*");
                    //this.gridControl.DataSource = DESTINATARIO;
                    //this.lblTitulo.Text = "Destinatario";

                    CreateGridColumn(this.gridControl, "Ruc", "ccm02cod", 0, "", 100);
                    CreateGridColumn(this.gridControl, "Empresa", "ccm02nom", 0, "", 300);

                    listaDestinatario = CuentaCorrienteLogic.Instance.Glo_Traer_CuentasCorrientes(Logueo.CodigoEmpresa, 
                                        "15", "ccm02cod");
                    this.gridControl.DataSource = listaDestinatario;
                    this.lblTitulo.Text = "Destinatario";

                    break;

                    case enmAyuda.enmdestinaEstab:
                    CreateGridColumn(gridControl, "Codigo", "FAC65CODEST", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "FAC65DESEST", 0, "", 70);
                    CreateGridColumn(gridControl, "Direccion", "FAC65DIRECCION", 0, "", 70);
                    string rucdestino =((GuiaTransporte)this._variable).FAC01COD;
                    
                        //formularioDetGuia.txtrucdestino.Text.Trim();
                    //var DESTINARIOESTAB = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC65_DESTINARIOESTAB(Logueo.CodigoEmpresa, 
                    //    rucdestino, "FAC65CODEST", "*");
                    var DESTINARIOESTAB = Fac_GuiaTransporteLogic.Instance.TraerDestinatarioDireccion(Logueo.CodigoEmpresa,
                        rucdestino, "come05sedeclientescod", "*");
                    
                    //05288399
                    gridControl.DataSource = DESTINARIOESTAB;
                    this.lblTitulo.Text = "Destinatario";
                    break;

                    case enmAyuda.enmMotvioDeTraslado:
                    CreateGridColumn(gridControl, "Direccion", "FAC65DIRECCION", 0, "", 70, true, false, false);
                    CreateGridColumn(gridControl, "Codigo", "FAC66CODMOTIVO", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "FAC66DESMOTIVO", 0, "", 70);

                    CreateGridColumn(gridControl, "flag", "FAC66FLAGDESEXTRA", 0, "", 70, true, false, false);
                    CreateGridColumn(gridControl, "Descrip.Defecto", "FAC66DESXDEFECTO", 0, "", 70, true, false, false);
                    var MOTIVODETRASLADO = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC66_MOTIVODETRASLADO("FAC66CODMOTIVO",
                        "*");
                    gridControl.DataSource = MOTIVODETRASLADO;
                    this.lblTitulo.Text = "Motivo de traslado";
                    break;

                    case enmAyuda.enmEstablecimientos:
                    //CreateGridColumn(tbHelp,"
                    CreateGridColumn(gridControl, "Codigo", "FAC63CODESTAB", 0, "", 70);
                    CreateGridColumn(gridControl, "Nombre", "FAC63DESESTAB", 0, "", 70);
                    CreateGridColumn(gridControl, "Direccion", "FAC63DIRESTAB", 0, "", 70);
                    CreateGridColumn(gridControl,"Sede","FAC63CODESTABLECISUNAT",0,"",70);
                    var ESTABLECIMIENTOS = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC63_ESTABLECIMIENTOS(Logueo.CodigoEmpresa, 
                        "FAC63CODESTAB", "*");
                    gridControl.DataSource = ESTABLECIMIENTOS;
                    this.lblTitulo.Text = "Establecimientos";
                    break;

                    case enmAyuda.enmEmpresa:                    
                    CreateGridColumn(gridControl, "Ruc", "Ruc", 0, "", 70);
                    CreateGridColumn(gridControl, "Nombre", "Nombre", 0, "", 70);
                    var dataEmpresa =Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_empresa(Logueo.nombreModulo, "Ruc", "*");
                    gridControl.DataSource = dataEmpresa;
                    this.lblTitulo.Text = "Empresa";
                    break;

                    case enmAyuda.enmEstados:
                    CreateGridColumn(gridControl, "Codigo", "FAC67CODESTADO", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "FAC67DESESTADO", 0, "", 70);                    
                        var  ESTADOS = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC67_ESTADOS("FAC67CODESTADO", "*");
                        gridControl.DataSource = ESTADOS;
                        this.lblTitulo.Text = "Estados";
                    //        Set dcHelp.Recordset = CLS_COMANDO.Ejec_Comando_1("Spu_Fact_Help_FAC67_ESTADOS", "FAC67CODESTADO", "*")
                        break;

                case enmAyuda.enmBuscaArti:
                        
                        this.Width = 900; this.Height = 474;       

                        if (_variable == null)
                        {
                            //codigo	descripcion	unimed	otros
                            this.CreateGridColumn(this.gridControl, "codigo", "codigo", 0, "", 150, true, false, true);
                            this.CreateGridColumn(this.gridControl, "descripcion", "descripcion", 0, "", 150, true, false, true);
                            this.CreateGridColumn(this.gridControl, "unimed", "unimed", 0, "", 150, true, false, true);
                            //this.CreateGridColumn(this.gridControl, "Uni.Venta", "unimedventa", 0, "", 70, true, false, true);
                            this.CreateGridColumn(this.gridControl, "otros", "otros", 0, "", 150, true, false, false);
                            
                            //OTROS	REMPLAZE LA DESCRIPCION	UNI	
                        }
                        else {
                           
                            this.CreateGridColumn(this.gridControl, "Codigo", "codigo", 0, "", 100, true, false, true);
                            this.CreateGridColumn(this.gridControl, "Desc.Breve", "descripcionbreve", 0, "", 120, true, false, true);
                            this.CreateGridColumn(this.gridControl, "Nombre", "descripcion", 0, "", 350, true, false, true);
                            this.CreateGridColumn(this.gridControl, "Uni.Med", "unimed", 0, "", 80, true, false, true);
                            //this.CreateGridColumn(this.gridControl, "Uni.Venta", "unimedventa", 0, "", 80, true, false, true);

                            //oculto los datos de productos deisi equialentes al producto del cliente.
                            this.CreateGridColumn(this.gridControl, "otros", "otros", 0, "", 150, true, false, false);
                            this.CreateGridColumn(this.gridControl, "Cod", "codigoprov", 0, "", 120, true, false, true);
                            this.CreateGridColumn(this.gridControl, "Des", "descripcionprov", 0, "", 400, true, false, false);
                            this.CreateGridColumn(this.gridControl, "Unidad", "unimedprov", 0, "", 70, true, false, false);
                            
                        }                         
                             
                        string opcion = _variable == null ? "" : _variable.ToString();

                   var  TraerArticuloClienteHelp = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Trae_ArtxTip(Logueo.CodigoEmpresa,
                        Logueo.Anio, Constantes.ProTerCarateristicas.almacen, opcion);

                   this.gridControl.DataSource = TraerArticuloClienteHelp;                        
                    this.lblTitulo.Text ="Busqueda";
                    break;
              
                case enmAyuda.enmBuscaConductor:
                  
                    CreateGridColumn(this.gridControl, "Codigo", "ccm02cod", 0, "", 70);
                    CreateGridColumn(this.gridControl, "Nombres", "ccm02nom", 0, "", 200);
                    var conductor = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, "12");
                    gridControl.DataSource = conductor;
                    this.lblTitulo.Text = "Busqueda";
                    break;
                case enmAyuda.enmBuscaTransportista:
                    CreateGridColumn(this.gridControl, "Codigo", "ccm02cod", 0, "", 70);
                    CreateGridColumn(this.gridControl, "Nombres", "ccm02nom", 0, "", 200);
                    var transportista  = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa,"11");
                    
                    gridControl.DataSource = transportista;
                    break;
                case enmAyuda.enmBuscaDestinatario:
                    CreateGridColumn(this.gridControl, "Codigo", "ccm02cod", 0, "", 70);
                    CreateGridColumn(this.gridControl, "Nombres", "ccm02nom", 0, "", 70);
                    listaDestinatario = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, "15");
                    this.gridControl.DataSource = listaDestinatario;
                    break;
                case enmAyuda.enmLibros:                    
                    CreateGridColumn(this.gridControl, "Codigo", "ccb02cod", 0, "", 70);
                    CreateGridColumn(this.gridControl, "Nombres", "ccb02des", 0, "", 70);
                     this.gridControl.DataSource =  AsientoTipoLogic.Instance.TraeAyudaLibros(Logueo.CodigoEmpresa, "ccb02cod", "*");
                    break;
                 case enmAyuda.enmCtaContable:
                    CreateGridColumn(this.gridControl, "Codigo", "ccm01cta", 0, "", 90);
                    CreateGridColumn(this.gridControl, "Descripcion", "ccm01des", 0, "", 120);
                    gridControl.DataSource = AsientoTipoLogic.Instance.TraeAyudaCuentaContable(Logueo.CodigoEmpresa,  "2018" , "ccm01cta", "*");
                    break;

                case enmAyuda.enmFlagCargoAbono:
                    CreateGridColumn(this.gridControl, "Codigo", "glo01codigo", 0, "", 90);
                    CreateGridColumn(this.gridControl, "Descripcion", "glo01descripcion", 0, "", 120);
                    gridControl.DataSource = AsientoTipoLogic.Instance.TraeAyudaTablaGlobal("20", "glo01codigo", "*");
                    break;
                case enmAyuda.enmTipoImporteDocu:
                    CreateGridColumn(this.gridControl, "Codigo", "glo01codigo", 0, "", 90);
                    CreateGridColumn(this.gridControl, "Descripcion", "glo01descripcion", 0, "", 120);
                    gridControl.DataSource = AsientoTipoLogic.Instance.TraeAyudaTablaGlobal("21", "glo01codigo", "*");
                    
                    break;
                    // Cabecera de factura 
                case enmAyuda.enmFactCab_SubPlantilla:
                    CreateGridColumn(gridControl, "Codigo", "FAC03COD", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "FAC03DESC", 0, "", 400);

                    CreateGridColumn(gridControl, "Tip.Doc", "FAC01COD", 0, "", 60, false, false, false);
                    CreateGridColumn(gridControl, "FAC02COD", "FAC02COD", 0, "", 60, false, false, false);
                    CreateGridColumn(gridControl, "Cant.Items", "FAC03CANITEMS", 0, "", 60, false, false, false);
                    CreateGridColumn(gridControl, "SeriexDef", "FAC03SERIEXDEF", 0, "", 60, false, false, false);
                    CreateGridColumn(gridControl, "Tip.Part", "FAC03TIPART", 0, "", 60, false, false, false);
                    CreateGridColumn(gridControl, "Tipo Venta", "FAC03TIPOVENTA", 0, "", 60, false, false, false);
                    CreateGridColumn(gridControl, "Tipo operacion", "FAC03TIPOOPERACIONFE", 0, "", 60, false, false, false);
                    //10/09/2020
                    gridControl.DataSource = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC03_SUBPLANTILLA(Logueo.CodigoEmpresa,
                                                                    this._variable.ToString(), "FAC03COD", "*", Logueo.UserName);
                    break;

                    //FAC03MOSTRAR PARA FAC89PLANTILLAXVOUCHER
                case enmAyuda.enmFAC03SubPlantillaFAC89:
                    CreateGridColumn(gridControl, "Empresa Cod", "FAC03CODEMP", 0, "", 70,true,true,false);
                    CreateGridColumn(gridControl, "TipDoc Cod", "FAC01COD", 0, "", 70, true, false, true);
                    CreateGridColumn(gridControl, "Plantilla Cod", "FAC03COD", 0, "", 70,true,true,true);
                    CreateGridColumn(gridControl, "Plantilla Desc", "FAC03DESC", 0, "", 70,true,false,true);
                    gridControl.DataSource = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Trae_FAC03_SUBPLANTILLAXVOUCHER(Logueo.CodigoEmpresa);
                    break;



                case enmAyuda.enmFactCab_TipoAnalisis:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 120);
                    gridControl.DataSource = 
                    GlobalLogic.Instance.Spu_Fact_Trae_ccb17ana(Logueo.CodigoEmpresa, "ccb17cdgo", "*");
                    break;
                case enmAyuda.enmFactCab_Cliente:
                    if (this._variable.ToString() == "")
                    {
                        Util.ShowAlert("Primero Seleccione el Tipo de Analisis");
                        return;
                    }
                    CreateGridColumn(gridControl, "Codigo", "ccm02cod", 0, "", 90);                     
                    CreateGridColumn(gridControl, "Descripcion", "ccm02nom", 0, "", 120);
                    CreateGridColumn(gridControl, "Direccion", "ccm02dir", 0, "", 120, false, false, false);
                    CreateGridColumn(gridControl, "Ruc", "ccm02ruc", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "Tip.Analisis", "ccm02tipana", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "Flag Desc Cli", "ccm02FlagDescripcionCliente", 0, "", 50, false, false, false);

                    //CreateGridColumn(gridControl, "ccm02tipana", "ccm02tipana", 0, "", 90);
                    gridControl.DataSource =  GlobalLogic.Instance.Spu_Fact_Trae_Clientes(Logueo.CodigoEmpresa,
                                                this._variable.ToString(), "ccm02cod", "*");
                    break;
                case enmAyuda.enmDetraccionCod:
                    CreateGridColumn(gridControl, "Codigo", "co01codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "co01descripcion", 0, "", 120);
                    CreateGridColumn(gridControl, "Porcentaje", "co01Tasaretencion", 0, "", 30);
                    
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Help_Detraccion(this._variable.ToString());
                    //gridControl.DataSource = MonedaLogic.Instance.TraerMoneda(Constantes.Tablas.CODIGO_TABLA_MONEDA);
                    break;
                case enmAyuda.enmFactCab_Moneda:
                    CreateGridColumn(gridControl, "Codigo", "FAC54CODIGO", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC54DESCRIPCION",0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Help_FAC54_MONEDA("FAC54CODIGO", "*");
                    //gridControl.DataSource = MonedaLogic.Instance.TraerMoneda(Constantes.Tablas.CODIGO_TABLA_MONEDA);
                    break;
                case enmAyuda.enmFormaPagoSunat:
                    CreateGridColumn(gridControl, "glo01codigo", "glo01codigo", 0, "", 90); // modicado
                    CreateGridColumn(gridControl, "glo01descripcion", "glo01descripcion", 0, "", 120);// modicado
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Glo_Trae_glo01tablas_Det("61", "glo01codigo", "*");
                    break;

                case enmAyuda.enmFactCab_Tienda: 
                    CreateGridColumn(gridControl, "Codigo", "FAC55COD", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC55DESC", 0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Help_FAC55_PuntoVenta(Logueo.CodigoEmpresa, "*", "*");                    
                    break;

                case enmAyuda.enmFactCab_Vendedor:
                    CreateGridColumn(gridControl, "Codigo", "FAC56COD", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC56Nombre", 0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Help_FAC56_Vendedor(Logueo.CodigoEmpresa, "*", "*");
                    break;
                case enmAyuda.enmFactCab_ExpPaisOrigen:
                    CreateGridColumn(gridControl, "Codigo", "FAC51CODPAIS", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC51DESCRIPCION", 0, "", 120);
                    gridControl.DataSource =GlobalLogic.Instance.Spu_Fact_Help_FAC51_PAISES("FAC51CODPAIS", "*");
                    break;
                case enmAyuda.enmFactCab_ExpPaisDestino: 
                    CreateGridColumn(gridControl, "Codigo", "FAC51CODPAIS", 0, "", 90);
                     CreateGridColumn(gridControl, "Descripcion", "FAC51DESCRIPCION", 0, "", 120);        
                    gridControl.DataSource =  GlobalLogic.Instance.Spu_Fact_Help_FAC51_PAISES("FAC51CODPAIS", "*");
        
                    break;
                case enmAyuda.enmFactCab_ExpCondPago: 
                    CreateGridColumn(gridControl, "Codigo", "FAC53COD", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC53DESCEEUU", 0, "", 120);        
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Help_FAC53_FORMAPAGO("FAC53COD", "*");        
                    break;
                case enmAyuda.enmFactCab_ExpConDespacho:
                    CreateGridColumn(gridControl, "glo01codigo", "glo01codigo", 0, "", 90); // modicado
                    CreateGridColumn(gridControl, "glo01descripcion", "glo01descripcion", 0, "", 120);// modicado
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Glo_Trae_glo01tablas_Det("52", "glo01codigo", "*");
                    break;
                case enmAyuda.enmUniMed:
                    CreateGridColumn(gridControl, "glo01codigo", "in21codigo", 0, "", 90); // modicado
                    CreateGridColumn(gridControl, "glo01descripcion", "in21descri", 0, "", 120);// modicado
                    gridControl.DataSource = ServiciosCompraLogic.Instance.TraeAyudaUnidadMedida(Logueo.CodigoEmpresa);
                    break;

                case enmAyuda.enmFactCab_ExpPuertoEmbarque: 
                    CreateGridColumn(gridControl, "Codigo", "FAC52CODPUERTO", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC52DESCRIPCION", 0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Help_FAC52_PUERTOS("FAC52CODPUERTO", "*");                                        
                    break;
                case enmAyuda.enmFactCab_ExpPuertoEmbarqueDes: 
                    CreateGridColumn(gridControl, "Codigo", "FAC52CODPUERTO", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC52DESCRIPCION", 0, "", 120);        
                    gridControl.DataSource =  GlobalLogic.Instance.Spu_Fact_Help_FAC52_PUERTOS("FAC52CODPUERTO", "*");        
                    break;
                case enmAyuda.enmFactCab_ExpBancoLocal:                     
                    CreateGridColumn(gridControl, "Codigo", "FAC50CODBANCO", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC50DESCRIPCION", 0, "", 120);
                    CreateGridColumn(gridControl, "Bank Code", "FAC50BANKCODE", 0, "", 90);
                    CreateGridColumn(gridControl, "Bank Number", "FAC50ACOUNTNUMBER", 0, "", 90);
                    gridControl.DataSource =  GlobalLogic.Instance.Spu_Fact_Help_FAC50_BANCOS("FAC50CODBANCO", "*");        
                    break;
                    
                    //uso en frmPackingListDet
                case enmAyuda.enmFactDet_ArtxTipo:
                    
                   CreateGridColumn(gridControl, "Codigo","codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripcion","descripcion", 0, "", 250);
                    CreateGridColumn(gridControl, "UniMed", "UniMed", 0, "", 90);
                    CreateGridColumn(gridControl, "ProdCodigoSunat", "ProdCodigoSunat", 0, "", 90);
                    CreateGridColumn(gridControl, "ProductoTipo", "ProductoTipo", 0, "", 90);
                    string  opcionarti = "";

                    GlobalLogic.Instance.DameDescripcionFA("13" + this._variable.ToString(), "GLODESCCOM", out opcionarti);
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Trae_ArtxTip(Logueo.CodigoEmpresa, Logueo.Anio, "", opcionarti);
                    this.Titulo = "Busqueda de articulo";
                    break;
                //uso en facturacab
                case enmAyuda.enmFacDet_ArtxCliente:
                    int ProductoRelacionado = Convert.ToInt32(Util.convertiracadena(this._variable).Split('|')[2]);
                            this.Width = 900; this.Height = 474;  
                            this.CreateGridColumn(this.gridControl, "Codigo", "codigo", 0, "", 100, true, false, true);                            
                            this.CreateGridColumn(this.gridControl, "Nombre", "descripcion", 0, "", 350, true, false, true);
                            this.CreateGridColumn(this.gridControl, "Uni.Med", "unimed", 0, "", 80, true, false, true);                            

                            this.CreateGridColumn(this.gridControl, "ProdCodigoSunat", "ProdCodigoSunat", 0, "", 70, true, false, false);
                            this.CreateGridColumn(this.gridControl, "ProductoTipo", "ProductoTipo", 0, "", 70, true, false, false);
                            
                            this.CreateGridColumn(this.gridControl, "CodProdProv", "codigoprov", 0, "", 70, true, false, true);
                            this.CreateGridColumn(this.gridControl, "DesProdProv", "descripcionprov", 0, "", 120, true, false, true);
                            this.CreateGridColumn(this.gridControl, "UniProdProv", "unimedprov", 0, "", 70, true, false, true);
                            
                            //oculto los datos de productos deisi equialentes al producto del cliente.                                                        
                            this.gridControl.Columns["codigoprov"].IsVisible = ProductoRelacionado > 0 ? true : false; ;
                            this.gridControl.Columns["descripcionprov"].IsVisible = ProductoRelacionado > 0 ? true : false; ;
                            this.gridControl.Columns["unimedprov"].IsVisible = ProductoRelacionado > 0 ? true : false; ;
                            
                            
                            opcionarti = "";
                            
                            //GlobalLogic.Instance.DameDescripcionFA("13" + Util.convertiracadena(this._variable), "GLODESCCOM", out opcionarti);
                            //GlobalLogic.Instance.DameDescripcionFA("1305", "GLODESCCOM", out opcionarti);
                            this.gridControl.DataSource =  GlobalLogic.Instance.TraeAyudaArtxCliente(Logueo.CodigoEmpresa, 
                                                           Logueo.Anio, Util.convertiracadena(this._variable));
                            //gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Trae_ArtxTip(Logueo.CodigoEmpresa, Logueo.Anio, "", opcionarti);
                            this.Titulo = "Busqueda de articulo";
                    break;

                 // Ayuda para Nota de Credito y Debito
                case enmAyuda.enmNotaCD_SubPlantilla:                                                 
                    CreateGridColumn(gridControl, "Codigo", "FAC03COD", 0, "",90);
                    CreateGridColumn(gridControl, "Descripcion", "FAC03DESC", 0, "",250);
                    CreateGridColumn(gridControl, "Tip.Doc", "FAC01COD", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "FAC02COD", "FAC02COD", 0, "", 70, false, false, false);
                    CreateGridColumn(gridControl, "Cant.Items", "FAC03CANITEMS", 0, "", 70, false, false, false);
                    CreateGridColumn(gridControl, "SerieXDefecto", "FAC03SERIEXDEF", 0, "", 120, false, false, false);
                    CreateGridColumn(gridControl, "Tip.Arti", "FAC03TIPART", 0, "", 70, false, false, false);
                    CreateGridColumn(gridControl, "Tip.Venta", "FAC03TIPOVENTA", 0, "", 70, false, false, false);
                    gridControl.DataSource = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Help_FAC03_SUBPLANTILLA(Logueo.CodigoEmpresa,
                            this._variable.ToString(), "FAC03COD", "*", Logueo.UserName);                    

                    break;
                case enmAyuda.enmNotaCD_TipoDocumento:
                      CreateGridColumn(gridControl, "Código", "FAC01COD", 0, "", 90);
                      CreateGridColumn(gridControl, "Descripción", "FAC01DESC", 0, "", 150);
                      gridControl.DataSource = DocumentoLogic.Instance.TraeAyudaTipoDocumento(Logueo.CodigoEmpresa, 
                                                                                                    "FAC01COD", "*");
                    break;

                case enmAyuda.enmNotaCD_ArtxTipo:
                    CreateGridColumn(gridControl, "Código", "codigo", 0, "", 90);
                    CreateGridColumn(gridControl, "Descripción", "descripcion", 0, "", 200);
                    CreateGridColumn(gridControl, "UniMed", "UniMed", 0, "", 90);
                    CreateGridColumn(gridControl, "ProdCodigoSunat", "ProdCodigoSunat", 0, "", 90);

                    GlobalLogic.Instance.DameDescripcionFA("13" + this._variable.ToString(), 
                                                            "GLODESCCOM", out opcionarti);
                    gridControl.DataSource = GlobalLogic.Instance.Spu_Fact_Trae_ArtxTip(Logueo.CodigoEmpresa, 
                                                                                Logueo.Anio, "", opcionarti);
                    

                    break;
                case enmAyuda.enmNotaCD_NroDocumento:
                    CreateGridColumn(gridControl, "Tip.Doc", "FAC01COD", 0, "", 90);                 
                    CreateGridColumn(gridControl, "Nro.Doc", "FAC04NUMDOC", 0, "", 150);
                    CreateGridColumn(gridControl, "Cliente", "FAC04CLINOMBRE", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "Direccionr", "FAC04CLIDIRECCION", 0, "", 120, false, false, false);
                    CreateGridColumn(gridControl, "Ruc", "FAC04CLIRUC", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "Fecha", "FAC04FECHA", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "Tip.Analisis", "FAC04TIPANA", 0, "", 120, false, false, false);
                    CreateGridColumn(gridControl, "Cli.Codigo", "FAC04CODCLI", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "Moneda", "FAC04MONEDA", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "Tienda", "FAC04TIENDA", 0, "", 90, false, false, false);
                    CreateGridColumn(gridControl, "TipoCambio", "FAC04TIPCAMBIO", 0, "", 90, false, true, false);
                    gridControl.DataSource = DocumentoLogic.Instance.TraeAyudaNroDocumento(Logueo.CodigoEmpresa,
                                                                                            this._variable.ToString(), "FAC04NUMDOC", "*");
                    break;
                case enmAyuda.enmNotaCD_Motivo:
                    CreateGridColumn(gridControl, "Codigo", "glo04Codigo",0, "", 90);                    
                    CreateGridColumn(gridControl, "Descripcion", "glo04descripcion", 0, "", 90);
                    CreateGridColumn(gridControl, "CampoTexto", "glo04campotexto1", 0, "", 120, true, false, false);
        
                    if(Logueo.FlagNotCreyDeb == "C")
                    {
                        gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("09");
                    }else if(Logueo.FlagNotCreyDeb == "D")
                    {
                        gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("10");
                    }
                
                break;
                case enmAyuda.enmMonedaFE:
                    CreateGridColumn(gridControl, "Codigo", "glo04Codigo",0, "", 90);                    
                    CreateGridColumn(gridControl, "Descripcion", "glo04descripcion", 0, "", 90);
                    gridControl.DataSource =  GlobalLogic.Instance.TraeAyudaCatalogoFE("02");
                break;
                case enmAyuda.enmModelo:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var modelo = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.modelo);
                    this.gridControl.DataSource = modelo;
                break;
                case enmAyuda.enmCalidad:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var calidad = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.calidad);
                    this.gridControl.DataSource = calidad;
                break;
                case enmAyuda.enmBorde:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var borde = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.borde);
                    this.gridControl.DataSource = borde;
                break;
                case enmAyuda.enmRelleno:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var relleno = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.relleno);
                    this.gridControl.DataSource = relleno;
                break;
                case enmAyuda.enmAcabado:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var acabado = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.acabado);
                    this.gridControl.DataSource = acabado;
                break;
                case enmAyuda.enmFormato:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var formato = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.formato);
                    this.gridControl.DataSource = formato;
                break;
                case enmAyuda.enmTonalidad:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var tonalidad = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.tonalidad);
                    this.gridControl.DataSource = tonalidad;
                break;
                case enmAyuda.enmColor:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var color = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.color);
                    this.gridControl.DataSource = color;
                break;
                case enmAyuda.enmTipo:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var tipo = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.tipo);
                    this.gridControl.DataSource = tipo;
                break;
                case enmAyuda.enmUniMedGuia:
                    this.CreateGridColumn(this.gridControl, "Código", "glo01codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "glo01descripcion", 0, "", 300, true, false, true);
                    
                    var unimed = GlobalLogic.Instance.Spu_Glo_Trae_glo01tablas_Det("65","","*");
                    this.gridControl.DataSource = unimed;
                break;
                case enmAyuda.enmGuiaPendientePorFactura:
                    CreateGridColumn(gridControl, "Empresa", "FAC34CODEMP", 0, "", 70);                    
                    CreateGridColumn(gridControl, "Anio", "FAC34AA", 0, "", 100);
                    CreateGridColumn(gridControl, "Mes","FAC34MM", 0, "", 70);
	                CreateGridColumn(gridControl, "Tip.Doc", "FAC01COD", 0, "", 70);
	                CreateGridColumn(gridControl, "GuiaNro", "FAC34NROGUIA", 0, "", 70);
	                CreateGridColumn(gridControl, "GuiaSerie", "FAC34SERIEGUIA", 0, "", 70);
                    CreateGridColumn(gridControl, "GuiaCorrelativo", "FAC34CORRELATIVOGUIA", 0, "", 70);
                    CreateGridChkColumn(gridControl, "Seleccionar", "chkSelect", 0, "", 70, false, true);
                    this.gridControl.DataSource = Fac_GuiaTransporteLogic.Instance.TraerGuiaPendientePorFacturar(Logueo.CodigoEmpresa, "09");
                break;
                case enmAyuda.enmCliente_TipoDoc:                    
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120);                    
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("05", "GLO", "", "*");
                    break;
                case enmAyuda.enmCliente_SituacionSunat:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 70);                    
                    gridControl.DataSource =  GlobalLogic.Instance.TraeAyudaGlobal("07", "GLO", "glo01codigo", "*");
                    break;
                case enmAyuda.enmCliente_SituacionDomi:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                     CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 70);
                     gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("08", "GLO", "glo01codigo", "*");
                    break;
                case enmAyuda.enmCliente_Pais:
                    CreateGridColumn(gridControl, "Codigo", "glo04Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo04descripcion", 0, "", 70);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("04");
                    break;
                case enmAyuda.enmCliente_Dpto:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Nombre", "Nombre", 0, "", 70);
                    gridControl.DataSource = GlobalLogic.Instance.TraeHelpDepartamentoFE(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmCliente_Prov:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Nombre", "Nombre", 0, "", 70);
                    gridControl.DataSource = GlobalLogic.Instance.TraeHelpProvinciaFE(this._variable.ToString());
                    break;
                case enmAyuda.enmCliente_Dist:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Nombre", "Nombre", 0, "", 70);
                    
                    datos = this._variable.ToString().Split('|');
                    gridControl.DataSource = GlobalLogic.Instance.TraeHelpDistritoFE(datos[0], datos[1]);

                    break;
                case enmAyuda.enmCliente_FormaPago:
                    CreateGridColumn(gridControl, "Codigo", "Co02codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "Co02descripcion", 0, "", 120);
                    gridControl.DataSource = FormaPagoLogic.Instance.TraeHelpFormaPago(Logueo.CodigoEmpresa, "Co02codigo", "*");
                    break;
                case enmAyuda.enmTablaFE:
                    CreateGridColumn(gridControl, "codigo", "Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "descripcion", "Descripcion", 0, "", 200);
                    gridControl.DataSource = GlobalLogic.Instance.TraeTablas("");
                    break;

                case enmAyuda.enmTipDocGlobal:
                    CreateGridColumn(gridControl, "Codigo", "glo04Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo04descripcion", 0, "", 70);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("01");
                    break;
                    //CATALOGO D-37 -NUEVO

                case enmAyuda.enmCatalogoD37:
                      CreateGridColumn(gridControl, "Codigo", "glo04Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo04descripcion", 0, "", 70);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("37");
                    break;

                    //CATALOGO 61
                case enmAyuda.enmCatalogo61:
                    CreateGridColumn(gridControl, "Codigo", "glo04Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo04descripcion", 0, "", 70);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaCatalogoFE("61");
                    break; 

                case enmAyuda.enmEmpAlmacen:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Nombre", "Nombre", 0, "", 200);
                    gridControl.DataSource = GlobalLogic.Instance.AyudaEmpresa("ALMACEN", "", "*");
                    break;
                case enmAyuda.enmEmpContable:
                     CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70);
                     CreateGridColumn(gridControl, "Nombre", "Nombre", 0, "", 200);
                    gridControl.DataSource = GlobalLogic.Instance.AyudaEmpresa("CONTABILID", "", "*");
                    break;
                case enmAyuda.enmTipoOrdenCompra:
                     CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("57", "GLO", "glo01codigo", "*");
                    break;
                case enmAyuda.enmCliente_TipoCliente:
                     CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("63", "GLO", "glo01codigo", "*");
                    break;
                case enmAyuda.enmPackingListDisponible:
                    CreateGridColumn(gridControl, "NumeroPacking", "numeroPacking", 0, "", 120);
                    CreateGridColumn(gridControl, "Cliente", "clienteDesc", 0, "", 250);
                    CreateGridColumn(gridControl, "Fecha", "FechaTexto", 0, "", 70);
                    CreateGridColumn(gridControl, "Estado", "Estado", 0, "", 70);
                    CreateGridColumn(gridControl, "NroCajas", "nroCajas", 0, "", 70);
                    CreateGridColumn(gridControl, "Cantidad", "Cantidad", 0, "", 70);
                    CreateGridColumn(gridControl, "Area", "Area", 0, "", 70);
                    CreateGridColumn(gridControl, "Peso", "Peso", 0, "", 70);
                    gridControl.DataSource = GlobalLogic.Instance.TraeAyudaPackingDisponible(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                    break;
                case enmAyuda.enmEquivalenciaProducto:
                    this.CreateGridColumn(this.gridControl, "CodCli", "In20clientecod", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Cliente", "NombreCliente", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Codigo producto", "In20Codigo", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "In20Descripcion", 0, "", 50, true, false, true);
                    //this.CreateGridColumn(this.gridControl, "UnidadMedida", "In20UndMed", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "UnidadMedida", "In20UndMed", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "UnidadCaja", "In20UndxCaja", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Piezas", "In20PiezasxCaja", 0, "", 50, true, false, false);
                    this.gridControl.DataSource = ArticuloClienteLogic.Instance.TraerArticuloClienteHelp(Logueo.CodigoEmpresa, "01");
                    this.lblTitulo.Text = "PRODUCTOS  POR CLIENTE";
                    break;
                case enmAyuda.enmSerie:
                    this.CreateGridColumn(this.gridControl, "Serie", "FAC07SERIE", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "FAC07DESC", 0, "", 250);
                    this.CreateGridColumn(this.gridControl, "Numero", "FAC07NUMERO", 0, "", 120);
                    
                    Series serie = new Series();
                    serie.FAC07CODEMP = Logueo.CodigoEmpresa;
                    serie.FAC01COD = this._variable.ToString();
                    

                    var listaSeries = SeriesLogic.Instance.TraeSeries(serie, "FAC07SERIE", "*");

                    this.gridControl.DataSource = listaSeries;
                    this.lblTitulo.Text = "Series";
                    break;

                case enmAyuda.enmLargo:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var largo = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.largo);
                    this.gridControl.DataSource = largo;
                    break;
                case enmAyuda.enmAncho:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var ancho = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.ancho);
                    this.gridControl.DataSource = ancho;
                    break;
                case enmAyuda.enmEspesor:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var espesor = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.espesor);
                    this.gridControl.DataSource = espesor;
                    break;
                case enmAyuda.enmAsiento:
                    CreateGridColumn(this.gridControl, "Codigo", "FAC08COD", 0, "", 50);
                    CreateGridColumn(this.gridControl, "Descripcion", "FAC08DES", 0, "", 70);
                    CreateGridColumn(this.gridControl, "FAC08CODLIBRO", "FAC08CODLIBRO", 0, "", 90, true, false, false);

                    var cabasientotipo = AsientoTipoLogic.Instance.TraeCabAsientoTipo(Logueo.CodigoEmpresa, "*", "*");
                    this.gridControl.DataSource = cabasientotipo;
                    this.Text = "Asientos";
                    break;
                case enmAyuda.enmSegTipoDocumento:
                    CreateGridColumn(gridControl, "Tipo \nDocumento", "FAC01COD", 0 , "", 50);
                    CreateGridColumn(gridControl, "Descripcion", "FAC01DESC", 0, "", 70);
                    CreateGridColumn(gridControl, "Serie", "FAC07SERIE", 0, "", 50);
                    CreateGridColumn(gridControl, "Descripcion", "FAC07DESC", 0, "", 120);
                    this.gridControl.DataSource = SeriesLogic.Instance.TraeTipoDocumentoySerie(Logueo.CodigoEmpresa);
                    this.Text = "Series de Documentos";
                    break;
                case enmAyuda.enmSegUsuario:
                    CreateGridColumn(gridControl, "Tipo \nDocumento", "Codigo", 0 , "", 90);
                    CreateGridColumn(gridControl, "Serie", "NombreUsuario", 0, "", 150);
                    this.gridControl.DataSource =  SegUsuarioLogic.Instance.TraeUsuarios(Logueo.CodigoEmpresa);
                    this.Text = "Usuario";
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
            switch (this._tipoAyuda)
            {
                case enmAyuda.enmBuscaTipArt:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "glo01codigo") + "|" +
                                   Util.GetCurrentCellText(gridControl.CurrentRow, "glo01descripcion");                    
                    break;


                case enmAyuda.enmFAC03SubPlantillaFAC89:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD") + "|" +
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "FAC03COD") + "|" +
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "FAC03DESC");



                    break;
                case enmAyuda.enmBuscaTipDoc:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD") + "|" +
                                   Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01DESC");                    
                    break;
                    //CATALOGO NRO D-37
                case enmAyuda.enmCatalogoD37:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "glo04Codigo") + "|" +
                                           Util.GetCurrentCellText(gridControl.CurrentRow, "glo04descripcion");   
                    break;
                    //CATALOGO61
                case enmAyuda.enmCatalogo61:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "glo04Codigo") + "|" +
                                           Util.GetCurrentCellText(gridControl.CurrentRow, "glo04descripcion");
                    break;

                case enmAyuda.enmBuscaPlantilla:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC02COD") + "|" +
                            Util.GetCurrentCellText(gridControl.CurrentRow, "FAC02DESC");  
                    break;

        
                case enmAyuda.enmSubPlantilla:
                   listaGuiaTransp = new List<GuiaTransporte>();
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC03COD = gridControl.CurrentRow.Cells["FAC03COD"].Value.ToString();
                   guiaTransporte.FAC02COD = gridControl.CurrentRow.Cells["FAC02COD"].Value.ToString();
                   guiaTransporte.FAC03TIPART = gridControl.CurrentRow.Cells["FAC03TIPART"].Value.ToString();
                   guiaTransporte.FAC01COD = gridControl.CurrentRow.Cells["FAC01COD"].Value.ToString();
                   guiaTransporte.FAC03SERIEXDEF = gridControl.CurrentRow.Cells["FAC03SERIEXDEF"].Value.ToString();
                   listaGuiaTransp.Add(guiaTransporte);
                   this.Result = listaGuiaTransp;
                   break;
                    //NUEVO FAC89SUBPLANTILLA

                case enmAyuda.enmProductoSunat:
                   if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString() + "|" +
                                 this.gridControl.CurrentRow.Cells["Descripcion"].Value.ToString() + "|" +
                                 this.gridControl.CurrentRow.Cells["SegmentoCodigo"].Value.ToString() + "|" +
                                 this.gridControl.CurrentRow.Cells["SegmentoDescripcion"].Value.ToString() + "|" +
                                  this.gridControl.CurrentRow.Cells["FamiliaCodigo"].Value.ToString() + "|" +
                                  this.gridControl.CurrentRow.Cells["FamiliaDescripcion"].Value.ToString();
                   break;


                case enmAyuda.enmVehxTranporYchofer:
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC34TRAYCODIGO = gridControl.CurrentRow.Cells["FAC69codigo"].Value.ToString();
                   guiaTransporte.FAC34TRAYMARCA = gridControl.CurrentRow.Cells["FAC69MarcaRemolque"].Value.ToString();
                   guiaTransporte.FAC34TRAYMARCASR = gridControl.CurrentRow.Cells["FAC69MarcaSemiRemolque"].Value.ToString();
                   guiaTransporte.FAC34TRAYPLACA = gridControl.CurrentRow.Cells["FAC69PlacaRemolque"].Value.ToString();
                   guiaTransporte.FAC34TRAYPLACASR = gridControl.CurrentRow.Cells["FAC69PlacaSemiRemolque"].Value.ToString();
                   this.Result = guiaTransporte;        
                   break;

                case enmAyuda.enmEstablecimientoxSerie:
                   this.Result = Util.GetCurrentCellText(this.gridControl.CurrentRow, "Glo03codigo") + "|" +
                               Util.GetCurrentCellText(this.gridControl.CurrentRow, "Glo03Descripcion");
                   break;

                case enmAyuda.enmTransportista:                   
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC34CHOFCOD= gridControl.CurrentRow.Cells["FAC60Codigo"].Value.ToString();
                   guiaTransporte.FAC34CHOFNOMBRE = gridControl.CurrentRow.Cells["FAC60Nombre"].Value.ToString();
                   this.Result = guiaTransporte;
                   
                   break;
                case enmAyuda.enmchoferxtransportistas:
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC34CHOFCOD = gridControl.CurrentRow.Cells["FAC61Codigo"].Value.ToString();
                   guiaTransporte.FAC34CHOFNOMBRE = gridControl.CurrentRow.Cells["FAC61Nombres"].Value.ToString();
                   guiaTransporte.FAC34CHOFLICCONDUCIR = gridControl.CurrentRow.Cells["FAC61Brevete"].Value.ToString();
                   this.Result = guiaTransporte;
                    
                        
                   break;
                case enmAyuda.enmDestinatario:
                   guiaTransporte = new GuiaTransporte();                    
                   guiaTransporte.FAC01COD = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                   guiaTransporte.FAC34DESTDIRECCION = gridControl.CurrentRow.Cells["ccm02nom"].Value.ToString();

                   this.Result = guiaTransporte;
                   break;
                case enmAyuda.enmdestinaEstab:
                    
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC34DESCODESTAB= gridControl.CurrentRow.Cells["FAC65CODEST"].Value.ToString();
                   guiaTransporte.FAC34DESDESESTAB = gridControl.CurrentRow.Cells["FAC65DESEST"].Value.ToString();
                    guiaTransporte.FAC34DESTDIRECCION = gridControl.CurrentRow.Cells["FAC65DIRECCION"].Value.ToString();

                    this.Result = guiaTransporte;
                   break;
                case enmAyuda.enmMotvioDeTraslado:
                    
                        guiaTransporte = new GuiaTransporte();
                    guiaTransporte.FAC34MOTRASLCOD = gridControl.CurrentRow.Cells["FAC66CODMOTIVO"].Value.ToString();
                    guiaTransporte.FAC34MOTRASLDESC  = gridControl.CurrentRow.Cells["FAC66DESMOTIVO"].Value.ToString();
                    //flag de traslado
                    guiaTransporte.FAC66FLAGDESEXTRA = gridControl.CurrentRow.Cells["FAC66FLAGDESEXTRA"].Value.ToString();
                    this.Result = guiaTransporte;
                                             
                   break;
                    //buque da de produco sin validacion codigo de proveedor
                    //Uso en frmabcGuiasTransporte
                case enmAyuda.enmBuscaArti:
                   detalleGuiaTranportista = new DetalleGuiaTransporte();
                   //if (ProdxProv == true) {       
                       var codprod = gridControl.CurrentRow.Cells["codigo"].Value == null ? "" : gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                       detalleGuiaTranportista.FAC35CODPROD = codprod;

                       var desprod = gridControl.CurrentRow.Cells["descripcion"].Value == null ? "" : gridControl.CurrentRow.Cells["descripcion"].Value.ToString();
                       detalleGuiaTranportista.FAC35DESCPROD = desprod;

                       var unimed = gridControl.CurrentRow.Cells["unimed"].Value == null ? "" : gridControl.CurrentRow.Cells["unimed"].Value.ToString();
                       detalleGuiaTranportista.FAC35UNIMED = unimed;

                       var codprod_prov = gridControl.CurrentRow.Cells["codigoprov"].Value == null ? "" : gridControl.CurrentRow.Cells["codigoprov"].Value.ToString();
                       detalleGuiaTranportista.FAC35CODPROD_PROV = codprod_prov;

                       var nomprod_prov = gridControl.CurrentRow.Cells["descripcionprov"].Value == null ? "" : gridControl.CurrentRow.Cells["descripcionprov"].Value.ToString();
                       detalleGuiaTranportista.FAC35DESCPROD_PROV = nomprod_prov;

                       var unimed_prov = gridControl.CurrentRow.Cells["unimedprov"].Value == null ? "" : gridControl.CurrentRow.Cells["unimedprov"].Value.ToString();
                       detalleGuiaTranportista.FAC35UNIMED_PROV = unimed_prov;

                       //var unimed_venta = gridControl.CurrentRow.Cells["unimedventa"].Value == null ? "" : gridControl.CurrentRow.Cells["unimedventa"].Value.ToString();
                       //detalleGuiaTranportista.IN01UNIMEDVENTA = unimed_venta;
                    this.Result = detalleGuiaTranportista;
                   break;
                //buque da de produco con validacion codigo de proveedor
                case enmAyuda.enmBuscaArtiProv:
                   detalleGuiaTranportista = new DetalleGuiaTransporte();
                  var _codprod = gridControl.CurrentRow.Cells["codigo"].Value == null ? "" : gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                  detalleGuiaTranportista.FAC35CODPROD = _codprod;

                   var _desprod = gridControl.CurrentRow.Cells["Descripcion"].Value == null ? "" : gridControl.CurrentRow.Cells["Descripcion"].Value.ToString();
                   detalleGuiaTranportista.FAC35DESCPROD = _desprod;

                   var _unimed = gridControl.CurrentRow.Cells["unimed"].Value == null ? "" : gridControl.CurrentRow.Cells["unimed"].Value.ToString();
                   detalleGuiaTranportista.FAC35UNIMED = _unimed;
                    
                    var _codprov_pv = gridControl.CurrentRow.Cells["codigoprov"].Value == null ? "" : gridControl.CurrentRow.Cells["codigoprov"].Value.ToString();
                    detalleGuiaTranportista.FAC35CODPROD_PROV = _codprov_pv;

                    var _descprod_pv = gridControl.CurrentRow.Cells["descripcionprov"].Value == null ? "" : gridControl.CurrentRow.Cells["descripcionprov"].Value.ToString();
                    detalleGuiaTranportista.FAC35DESCPROD_PROV = _descprod_pv;

                    var _unimed_pv = gridControl.CurrentRow.Cells["unimedprov"].Value == null ? "" : gridControl.CurrentRow.Cells["unimedprov"].Value.ToString();
                    detalleGuiaTranportista.FAC35UNIMED_PROV = _unimed_pv;

                    this.Result = detalleGuiaTranportista;
                   break;
                    case enmAyuda.enmEmpresa:
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC34CODEMP = gridControl.CurrentRow.Cells[0].Value.ToString();
                   guiaTransporte.FAC34DESCODEMP = gridControl.CurrentRow.Cells[0].Value.ToString();

                   this.Result = guiaTransporte;
                   break;
                case enmAyuda.enmEstablecimientos:
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC34DESCODESTAB = gridControl.CurrentRow.Cells["FAC63CODESTAB"].Value.ToString();
                   guiaTransporte.FAC34DESDESESTAB = gridControl.CurrentRow.Cells["FAC63DESESTAB"].Value.ToString();
                   guiaTransporte.FAC34DESTDIRECCION = gridControl.CurrentRow.Cells["FAC63DIRESTAB"].Value.ToString();
                   this.Result = guiaTransporte;
                   break; 
                  
                case enmAyuda.enmEstados:
                   guiaTransporte = new GuiaTransporte();
                   guiaTransporte.FAC34ESTADO = gridControl.CurrentRow.Cells[0].Value.ToString();
                   guiaTransporte.FAC34ESTADOLLENADO = gridControl.CurrentRow.Cells[1].Value.ToString();
                   this.Result = guiaTransporte;
                   break;

                case enmAyuda.enmBuscaConductor:
                   CuentaCorriente conductor = new CuentaCorriente();
                   conductor.ccm02cod = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                   conductor.ccm02nom = gridControl.CurrentRow.Cells["ccm02nom"].Value.ToString();
                   this.Result = conductor;
                   break;

                case enmAyuda.enmBuscaTransportista:
                   CuentaCorriente tranportista = new CuentaCorriente();
                   tranportista.ccm02cod = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                   tranportista.ccm02nom = gridControl.CurrentRow.Cells["ccm02nom"].Value.ToString();
                   this.Result = tranportista;
                   break;
                case enmAyuda.enmBuscaDestinatario:
                   
                   destinatario.ccm02cod = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                   destinatario.ccm02nom = gridControl.CurrentRow.Cells["ccm02nom"].Value.ToString();
                   break;
                case enmAyuda.enmLibros:
                    this.Result = 
                    Util.convertiracadena(gridControl.CurrentRow.Cells["ccb02cod"].Value) + "|" +
                    Util.convertiracadena(gridControl.CurrentRow.Cells["ccb02des"].Value);                   
                   break;

                case enmAyuda.enmCtaContable:
                   this.Result = Util.convertiracadena(gridControl.CurrentRow.Cells["ccm01cta"].Value) + "|"
                                    + Util.convertiracadena(gridControl.CurrentRow.Cells["ccm01des"].Value);                                                       
                   break;

                case enmAyuda.enmFlagCargoAbono:                   
                   this.Result = Util.convertiracadena(gridControl.CurrentRow.Cells["glo01codigo"].Value) + "|"
                                + Util.convertiracadena(gridControl.CurrentRow.Cells["glo01descripcion"].Value);                   
                   break;

                case enmAyuda.enmTipoImporteDocu:
                   this.Result = Util.convertiracadena(gridControl.CurrentRow.Cells["glo01codigo"].Value) + "|"
                               + Util.convertiracadena(gridControl.CurrentRow.Cells["glo01descripcion"].Value);                                      
                   break;

                 // Factura Cabcera de documento
                case enmAyuda.enmFactCab_SubPlantilla:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC03COD") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "FAC03DESC") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC01COD") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC02COD") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC03CANITEMS") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC03SERIEXDEF") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC03TIPART") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC03TIPOVENTA") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC03TIPOOPERACIONFE");  
                   break;
                case enmAyuda.enmFactCab_TipoAnalisis:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "Descripcion");
                                      
                   break;
                case enmAyuda.enmDetraccionCod:
                     this.Result =
                       Util.GetCurrentCellText(gridControl, "co01codigo") + "|" +
                       Util.GetCurrentCellText(gridControl, "co01descripcion") + "|" +
                       Util.GetCurrentCellText(gridControl, "co01Tasaretencion");
                   break;

                case enmAyuda.enmFactCab_Cliente:
                   this.Result =
                   Util.GetCurrentCellText(gridControl, "ccm02cod") + "|" +
                   Util.GetCurrentCellText(gridControl, "ccm02nom") + "|" +
                   Util.GetCurrentCellText(gridControl, "ccm02dir") + "|" +
                   Util.GetCurrentCellText(gridControl, "ccm02ruc") + "|" +
                   Util.GetCurrentCellText(gridControl, "ccm02tipana") + "|" +
                   Util.GetCurrentCellText(gridControl, "ccm02FlagDescripcionCliente");

                   //+ "|" +
                   //Util.GetCurrentCellText(gridControl, "ccm02tipana");
                   
                   break;
                case enmAyuda.enmFactCab_Moneda:
                    this.Result =    
                    Util.GetCurrentCellText(gridControl, "FAC54CODIGO") + "|" +                   
                       Util.GetCurrentCellText(gridControl, "FAC54DESCRIPCION");                   
                   break;

                case enmAyuda.enmFormaPagoSunat:
                   this.Result =
                   Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                      Util.GetCurrentCellText(gridControl, "glo01descripcion");
                   break;

                case enmAyuda.enmFactCab_Tienda:
                   this.Result =
                  Util.GetCurrentCellText(gridControl, "FAC55COD") + "|" +
                  Util.GetCurrentCellText(gridControl, "FAC55DESC");                   
                   break;
                case enmAyuda.enmFactCab_Vendedor:
                   this.Result =
                  Util.GetCurrentCellText(gridControl, "FAC56COD") + "|" +
                  Util.GetCurrentCellText(gridControl, "FAC56Nombre");
                   break;
                case enmAyuda.enmFactCab_ExpPaisOrigen:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC51CODPAIS") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "FAC51DESCRIPCION");                   
                   break;
                case enmAyuda.enmFactCab_ExpPaisDestino:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC51CODPAIS") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC51DESCRIPCION");
                   break;
                case enmAyuda.enmFactCab_ExpCondPago:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC53COD") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC53DESCEEUU");                                      
                   break;
                case enmAyuda.enmFactCab_ExpConDespacho:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + // modificado
                                 Util.GetCurrentCellText(gridControl, "glo01descripcion");  //modificado   
                   break;
                case enmAyuda.enmtipoVenta:
                   if (this.gridControl.CurrentRow.Cells["glo01codigo"].Value == null) return;
                   this.Result = Util.GetCurrentCellText(this.gridControl.CurrentRow, "glo01codigo") + "|" +
                                Util.GetCurrentCellText(this.gridControl.CurrentRow, "glo01descripcion");
                   break;
                case enmAyuda.enmPlantillaFE:
                   this.Result = Util.GetCurrentCellText(this.gridControl.CurrentRow, "Fac70PlantillaFECod") + "|" +
                               Util.GetCurrentCellText(this.gridControl.CurrentRow, "Fac70PlantillaFEDesc");
                   break;
                case enmAyuda.enmOperacionFE:
                   this.Result = Util.GetCurrentCellText(this.gridControl.CurrentRow, "glo04Codigo") + "|" +
                              Util.GetCurrentCellText(this.gridControl.CurrentRow, "glo04descripcion");
                   break;

                case enmAyuda.enmFactCab_ExpPuertoEmbarque:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC52CODPUERTO") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC52DESCRIPCION");                                      
                   break;
                case enmAyuda.enmFactCab_ExpPuertoEmbarqueDes:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC52CODPUERTO") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC52DESCRIPCION");                                      
                   break;
                case enmAyuda.enmFactCab_ExpBancoLocal:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC50CODBANCO") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC50DESCRIPCION") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC50BANKCODE") + "|" +
                                 Util.GetCurrentCellText(gridControl, "FAC50ACOUNTNUMBER");                                      
                   break;
                case enmAyuda.enmFactDet_ArtxTipo:
                   this.Result = Util.GetCurrentCellText(gridControl, "codigo") + "|" +
                                  Util.GetCurrentCellText(gridControl, "descripcion") + "|" +
                                  Util.GetCurrentCellText(gridControl, "UniMed") + "|" +
                                  Util.GetCurrentCellText(gridControl, "ProdCodigoSunat") + "|" +
                                  Util.GetCurrentCellText(gridControl, "ProductoTipo");
                   break;
                case enmAyuda.enmFacDet_ArtxCliente:
                   this.Result = Util.GetCurrentCellText(gridControl, "codigo") + "|" +
                                   Util.GetCurrentCellText(gridControl, "descripcion") + "|" +
                                   Util.GetCurrentCellText(gridControl, "unimed") + "|" +

                                   Util.GetCurrentCellText(gridControl, "ProdCodigoSunat") + "|" +
                                   Util.GetCurrentCellText(gridControl, "ProductoTipo") + "|" +

                                   Util.GetCurrentCellText(gridControl, "codigoprov") + "|" +
                                   Util.GetCurrentCellText(gridControl, "descripcionprov") + "|" +
                                   Util.GetCurrentCellText(gridControl, "unimedprov");
                             
                   break;
                // ======================== NOTA DE CREDITO O DEBITO ==============================
                case enmAyuda.enmNotaCD_SubPlantilla:
                    this.Result = Util.GetCurrentCellText(gridControl, "FAC03COD")  + "|" +   //0                                             
                                   Util.GetCurrentCellText(gridControl, "FAC03DESC")+ "|" + //1
                                   Util.GetCurrentCellText(gridControl,"FAC01COD")+ "|" +//2
                                   Util.GetCurrentCellText(gridControl,"FAC02COD")+ "|" + //3
                                   Util.GetCurrentCellText(gridControl,"FAC03CANITEMS")+ "|" + //4
                                   Util.GetCurrentCellText(gridControl,"FAC03SERIEXDEF")+ "|" + //5
                                   Util.GetCurrentCellText(gridControl,"FAC03TIPART") + "|" + //6
                                   Util.GetCurrentCellText(gridControl, "FAC03TIPOVENTA") + "|" + // 7
                                   Util.GetCurrentCellText(gridControl, "FAC03TIPOOPERACIONFE");  // 8
                   break;
                case enmAyuda.enmEstadoSUNAT:
                   this.Result = Util.GetCurrentCellText(gridControl,"Codigo")+ "|" +
                                 Util.GetCurrentCellText(gridControl,"Descripcion");
                   break;
                case enmAyuda.enmNotaCD_TipoDocumento:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC01COD") + "|" +
                                   Util.GetCurrentCellText(gridControl, "FAC01DESC");                                                         
                   break;

                case enmAyuda.enmNotaCD_ArtxTipo:
                   this.Result = Util.GetCurrentCellText(gridControl, "codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "descripcion") + "|" +
                                 Util.GetCurrentCellText(gridControl, "UniMed") + "|" +
                                  Util.GetCurrentCellText(gridControl, "ProdCodigoSunat");

                   break;
                case enmAyuda.enmNotaCD_NroDocumento:
                   this.Result = Util.GetCurrentCellText(gridControl, "FAC01COD") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04NUMDOC") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04CLINOMBRE") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04CLIDIRECCION") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04CLIRUC") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04FECHA") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04TIPANA") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04CODCLI") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04MONEDA") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04TIENDA") + "|" +
                                  Util.GetCurrentCellText(gridControl, "FAC04TIPCAMBIO");                   
                   break;
                case enmAyuda.enmNotaCD_Motivo:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo04Codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "glo04descripcion") + "|" +
                                 Util.GetCurrentCellText(gridControl, "glo04campotexto1");                  
                   break;
                case enmAyuda.enmMonedaFE:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo04Codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "glo04descripcion");
                   break;

                case enmAyuda.enmModelo:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "Descripcion");                   
                   break;
                    //UNIDAD DE MEDIDA GUIA -  AGREGADO
                case enmAyuda.enmUniMedGuia:
                      this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "glo01descripcion");                   
                   break;
                case enmAyuda.enmCalidad:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "Descripcion");                   
                   break;
                case enmAyuda.enmBorde:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "Descripcion");
                   
                   break;
                case enmAyuda.enmRelleno:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "Descripcion");
                   break;
                case enmAyuda.enmAcabado:
                   this.Result =  Util.GetCurrentCellText(gridControl, "Codigo") + "|" + 
                                  Util.GetCurrentCellText(gridControl, "Descripcion");                   
                   break;
                case enmAyuda.enmFormato:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                Util.GetCurrentCellText(gridControl, "Descripcion");                   
                   break;
                case enmAyuda.enmTonalidad:
                   this.Result =  Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                    Util.GetCurrentCellText(gridControl, "Descripcion");                   
                   break;
                case enmAyuda.enmColor:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "Descripcion");                   
                   break;
                case enmAyuda.enmTipo:
                   this.Result =  Util.GetCurrentCellText(gridControl, "Codigo") + "|" + 
                                  Util.GetCurrentCellText(gridControl, "Descripcion");
                   
                   break;
                case enmAyuda.enmUniMed:

                   this.Result = Util.GetCurrentCellText(gridControl, "in21codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "in21descri");
                    
                   break;
                case enmAyuda.enmGuiaPendientePorFactura:
                    //recorrer todo las filas de la grilla
                    //string xml = "";
                    //xml = "<DataSet>";
                   string[] GuiasPedientesSeleccionados = new string[CantidadRegistrosSeleccionados()];
                    int CantidadSeleccionados = 0;
                    foreach(GridViewRowInfo row in gridControl.Rows)
                    {
                        bool isCheckedGuiaPendiente = false;
                        object value = row.Cells["chkSelect"].Value;
                        isCheckedGuiaPendiente = isChkSelected(value);

                        if (isCheckedGuiaPendiente == true)
                        {
                            //Armar fila con 3 campos : Empresa, CodigoTipoDocumento, NumeroDocumento
                            GuiasPedientesSeleccionados[CantidadSeleccionados] =
                                Util.GetCurrentCellText(row, "FAC34CODEMP") + "|" + 
                                Util.GetCurrentCellText(row, "FAC01COD") + "|" +
                                Util.GetCurrentCellText(row, "FAC34NROGUIA");
                               
                            CantidadSeleccionados++;
                        }
                    }
                    //xml += "</DataSet>";
                    this.Result = GuiasPedientesSeleccionados;
                    // Verificar si tenemos el check marcado                                                                                                
                   break;
                    
                case enmAyuda.enmCliente_TipoDoc:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "glo01descripcion");                   
                   break;
                case enmAyuda.enmCliente_SituacionSunat:
                   this.Result  = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + 
                                  Util.GetCurrentCellText(gridControl, "glo01descripcion");
                   
                   break;
                case enmAyuda.enmCliente_SituacionDomi:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "glo01descripcion");                   
                   break;
                case enmAyuda.enmCliente_Pais:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo04Codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "glo04descripcion");
                   
                   break;
                case enmAyuda.enmCliente_Dpto:
                    this.Result =  Util.GetCurrentCellText(gridControl, "Codigo") + "|" + 
                                    Util.GetCurrentCellText(gridControl, "Nombre");
                                      
                   break;

                case enmAyuda.enmCliente_Prov:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "Nombre");                                      
                   break;

                case enmAyuda.enmCliente_Dist:
                   this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "Nombre");                                      
                   break;

                case enmAyuda.enmCliente_FormaPago:
                   this.Result = Util.GetCurrentCellText(gridControl, "Co02codigo") + "|" +
                                 Util.GetCurrentCellText(gridControl, "Co02descripcion");
       
                break;

                case enmAyuda.enmTablaFE:
                this.Result =  Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                              Util.GetCurrentCellText(gridControl, "Descripcion");                                       
                break;
                    case enmAyuda.enmTipDocGlobal:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo04Codigo") + "|" +
                              Util.GetCurrentCellText(gridControl, "glo04descripcion");                    
                    break;
                    case enmAyuda.enmEmpAlmacen:
                    this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                    Util.GetCurrentCellText(gridControl, "Nombre");
                    
                    break;
                    case enmAyuda.enmEmpContable:
                    this.Result = Util.GetCurrentCellText(gridControl, "Codigo") + "|" +
                                     Util.GetCurrentCellText(gridControl, "Nombre");
                    break;

                    case  enmAyuda.enmTipoOrdenCompra:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                                  Util.GetCurrentCellText(gridControl, "glo01descripcion");                     
                    break;
                    case enmAyuda.enmCliente_TipoCliente:
                    this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                                    Util.GetCurrentCellText(gridControl, "glo01descripcion");  
                    
                    break;
                case enmAyuda.enmPackingListDisponible:
                    this.Result = Util.GetCurrentCellText(gridControl, "numeroPacking");                    
                    break;

                case enmAyuda.enmEquivalenciaProducto:
                    if (this.gridControl.CurrentRow.Cells["In20Codigo"].Value == null) return;
                    List<ArticuloCliente> listaArtCli = new List<ArticuloCliente>();
                    ArticuloCliente entidad = new ArticuloCliente();
                    if (gridControl.SelectedRows.Count == 0)
                    {
                        return;
                    }
                    entidad.In20clientecod = this.gridControl.CurrentRow.Cells["In20clientecod"].Value.ToString();
                    entidad.In20Codigo = this.gridControl.CurrentRow.Cells["In20Codigo"].Value.ToString();
                    entidad.NombreCliente = this.gridControl.CurrentRow.Cells["NombreCliente"].Value.ToString();
                    entidad.In20Descripcion = this.gridControl.CurrentRow.Cells["In20Descripcion"].Value.ToString();
                    entidad.In20UndxCaja = Convert.ToDouble(this.gridControl.CurrentRow.Cells["In20UndxCaja"].Value.ToString());
                    entidad.In20PiezasxCaja = Convert.ToInt32(this.gridControl.CurrentRow.Cells["In20PiezasxCaja"].Value.ToString());
                    entidad.In20UndMed = Util.GetCurrentCellText(this.gridControl.CurrentRow, "In20UndMed");
                    listaArtCli.Add(entidad);
                    this.Result = listaArtCli;

                    break;
                case enmAyuda.enmSerie:
                    this.Result = this.gridControl.CurrentRow.Cells["FAC07SERIE"].Value.ToString() + "|" +
                     this.gridControl.CurrentRow.Cells["FAC07DESC"].Value.ToString();
                    //this.CreateGridColumn(this.gridControl, "Serie", "FAC07SERIE", 0, "", 100);
                    //this.CreateGridColumn(this.gridControl, "Descripcion", "FAC07DESC", 0, "", 250);
                    //this.CreateGridColumn(this.gridControl, "Numero", "FAC07NUMERO", 0, "", 120);
                    break;
                case enmAyuda.enmLargo:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmAncho:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmEspesor:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmAsiento:
                    if (this.gridControl.CurrentRow.Cells["FAC08COD"].Value == null) return;
                    this.Result = Util.GetCurrentCellText(this.gridControl.CurrentRow, "FAC08COD") + "|"
                        + Util.GetCurrentCellText(this.gridControl.CurrentRow, "FAC08CODLIBRO") + "|" +
                        Util.GetCurrentCellText(this.gridControl.CurrentRow, "FAC08DES") ;
                    break;
                case enmAyuda.enmSegTipoDocumento:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD") + "|" + 
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01DESC") + "|" + 
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "FAC07SERIE") + "|" +
                                  Util.GetCurrentCellText(gridControl.CurrentRow,"FAC07DESC");
                    break;
                case enmAyuda.enmSegUsuario:
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "Codigo") + "|" +
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "NombreUsuario");
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
