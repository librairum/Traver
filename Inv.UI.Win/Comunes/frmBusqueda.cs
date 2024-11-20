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
using Inv.BusinessEntities.DTO;

namespace Inv.UI.Win
{
    public partial class frmBusqueda : frmBaseHelp
    {
        private string _codigoAlmacen = string.Empty;
        private string _PedidoVentaSeleccionado = string.Empty;
        private string _CodigoSeleccionado = string.Empty;
        private int _positionX = 0;
        private int _positionY = 0;
        private bool _esTipEntrada = false;
        private string _codTipDocumento = "";
        public object _parametros { get; set; }
        public object _parametros2 { get; set; }
        
        
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
        public frmBusqueda(enmAyuda tipoAyuda, object parametro1, object parametro2 = null, int ancho= 644, int alto = 474)
        {
            InitializeComponent();
            this._tipoAyuda = tipoAyuda;
            this._parametros = parametro1;
            this._parametros2 = parametro2;
            this._tipoAyuda = tipoAyuda;

            this.Width = ancho;
            this.Height = alto;
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
            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
                    //modificamos el moeto TraerTipoDocumento2 
                    this.CreateGridColumn(this.gridControl, "Código", "in12TipDoc", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "in12DesLar", 0, "", 300, true, false, true);
                    this.CreateGridColumn(this.gridControl, "CodigoManual", "in12FlagGeneraDocNum", 0, "", 300, true, false, false);
                        
                    //agrego parametor de Tipo de Naturaleza -- > this._codigoAlmacen
                    var tipEntrada = ((bool)_parametros) == false ? "S" : "E";
                    var tipDocs = TipoDocumentoLogic.Instance.Trae_TipDocParaMov(Logueo.CodigoEmpresa,
                                "04", tipEntrada.ToString());
                    //ORIGINAL
                    //var tipDocs = TipoDocumentoLogic.Instance.TraerTipoDocumento2(Logueo.CodigoEmpresa,
                            //    tipEntrada, this._parametros2.ToString());

                    this.gridControl.DataSource = tipDocs;                           
                    this.lblTitulo.Text = "TIPOS DE DOCUMENTO";                                                        
                    break;
                case enmAyuda.enmTransaccion:
                    this.CreateGridColumn(this.gridControl, "Código", "in15Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "in15Descripcion", 0, "", 300, true, false, true);
                    this.CreateGridColumn(this.gridControl, "in15ctactetipana", "in15ctactetipana", 0, "", 300, true, false, false);
                    var tipTrans = TipoTransaccionLogic.Instance.TraerTipoTransaccion1(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = tipTrans;

                    this.lblTitulo.Text = "TRANSACCIONES";
                    break;
                case enmAyuda.enmProveedor:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var proveedores = ProveedorLogic.Instance.TraerProveedor(Logueo.CodigoEmpresa, this._parametros.ToString());
                    this.gridControl.DataSource = proveedores;

                    this.lblTitulo.Text = "PROVEEDORES";
                    break;
                
                case enmAyuda.enmPedido:
                    break;
                case enmAyuda.enmCliente:
                    CreateGridColumn(this.gridControl, "Ruc", "ccm02cod", 0, "", 100);
                    CreateGridColumn(this.gridControl, "Empresa", "ccm02nom", 0, "", 300);
                    var clientes = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, Logueo.TipoAnalisisCliente);
                    this.gridControl.DataSource = clientes;
                    this.lblTitulo.Text = "CLIENTES";
                    break;
                case enmAyuda.enmCtaCteDesc:
                    CreateGridColumn(this.gridControl, "Ruc", "ccm02cod", 0, "", 100);
                    CreateGridColumn(this.gridControl, "Empresa", "ccm02nom", 0, "", 300);
                    var ctactedocrespaldo = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, this._parametros.ToString());
                    this.gridControl.DataSource = ctactedocrespaldo;
                    this.lblTitulo.Text = "CTA CTE DOC RESPALDO";
                    break;
                case enmAyuda.enmCentroCosto:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var cencos = CentroCostoLogic.Instance.TraerCentroCosto(Logueo.CodigoEmpresa, Logueo.Anio);
                    this.gridControl.DataSource = cencos;

                    this.lblTitulo.Text = "CENTRO DE COSTOS";
                    break;
                case enmAyuda.enmResponsableReceptor:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var respReceptor = ResponsableLogic.Instance.TraerResponsable(Logueo.CodigoEmpresa,"R");
                    this.gridControl.DataSource = respReceptor;

                    this.lblTitulo.Text = "RESPONSABLES";
                    break;
                case enmAyuda.enmResponsable:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var resp = ResponsableLogic.Instance.TraerResponsable(Logueo.CodigoEmpresa,"A");
                    this.gridControl.DataSource = resp;

                    this.lblTitulo.Text = "RESPONSABLES";
                    break;
                case enmAyuda.enmObra:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var obras = ObraLogic.Instance.TraerObra(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = obras;

                    this.lblTitulo.Text = "OBRAS";
                    break;
                case enmAyuda.enmMaquina:
                    this.CreateGridColumn(this.gridControl, "codigoEmpresa", "codigoEmpresa", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "codigo", "Codigo", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "descripcion", "Descripcion", 0, "", 120);
                    this.gridControl.DataSource = MaquinaLogic.Instance.TraerMaquinaxLineaActividad(Logueo.CodigoEmpresa, this._parametros.ToString());                    
                    this.lblTitulo.Text = "MAQUINAS";
                    break;

                case enmAyuda.enmLote:
                    break;
                case enmAyuda.enmProductoXAlmacen:
                   this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 250, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Unidad de medida", "UnidadMedida", 0, "", 70, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nro caja", "nrocaja", 0, "", 70, true, false, true);

                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 0, true, false,false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingPT", "DocingPT", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 0, true, false, false);

                    this.CreateGridColumn(this.gridControl, "CanPiezas", "CanPiezas",0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "CanArea", "CanArea", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "ClientePedidonro", "ClientePedidonro", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Cliente", "Cliente", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "clienteNombre", "clienteNombre", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "AreaxUni", "AreaxUni", 0, "", 50, true, false, true);
                    this.CreateGridChkColumn(this.gridControl, "Seleccionar", "chkSelect", 0, "", 20, false, true);
                    //-- Columnas ocultas
                    this.CreateGridColumn(this.gridControl, "IN07LARGO", "IN07LARGO", 0, "", 60, true, false, false);
                    this.CreateGridColumn(this.gridControl, "IN07ANCHO", "IN07ANCHO", 0, "", 60, true, false, false);
                    this.CreateGridColumn(this.gridControl, "IN07ALTO", "IN07ALTO", 0, "", 60, true, false, false);
                    this.CreateGridColumn(this.gridControl, "IN07CALIDADMP", "IN07CALIDADMP", 0, "", 60, true, false, false);
                    var spu_Inv_Trae_PtStock = ArticuloLogic.Instance.TraerPtStock(Logueo.CodigoEmpresa, this._parametros.ToString());
                    this.gridControl.DataSource = spu_Inv_Trae_PtStock;

                    this.lblTitulo.Text = "ARTÍCULOS";
                    break;


                case enmAyuda.enmProductoXPedVenSalida:
                    // Que se puedan seleccionar varias fila
                    this.gridControl.MultiSelect = true;

                    this.CreateGridColumn(this.gridControl, "Código", "in07pedvencodprod", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "IN01DESLAR", 0, "", 400, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Unidad de medida", "IN07UNIMED", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nro caja", "IN07NROCAJA", 0, "", 100, true, false, true);

                    this.CreateGridColumn(this.gridControl, "DocingAA", "IN07AA", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "IN07MM", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "IN07TIPDOC", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "IN07CODDOC", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingPT", "IN07KEY", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "IN07ORDEN", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "CanPiezas", "IN07CANART", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "CanArea", "IN07AREA", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "AreaxUni", "IN07AREAXUNI", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "in07pedvennum", "in07pedvennum", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "in07pedvenitem", "in07pedvenitem", 0, "", 50, true, false, false);


                    var Spu_Inv_Trae_ReservasXPv = ArticuloLogic.Instance.TraerReservaPTParaDespacho(Logueo.CodigoEmpresa, this._parametros.ToString());
                    this.gridControl.DataSource = Spu_Inv_Trae_ReservasXPv;

                    this.lblTitulo.Text = "Reservas por Pedido de Venta";
                    break;
                case enmAyuda.enmProductoXAlmacenIng:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 400, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Unidad de medida", "UnidadMedida", 0, "", 100, true, false, true);
                    
                    var Articulos = ArticuloLogic.Instance.TraerArticuloXAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this._parametros.ToString());
                    this.gridControl.DataSource = Articulos;

                    this.lblTitulo.Text = "ARTÍCULOS";
                    break;
                case enmAyuda.enmPedVentIng:
                    this.CreateGridColumn(this.gridControl, "Ped.Venta N°", "come01pedvennum", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Cliente", "ccm02nom", 0, "", 300, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Tip Doc Cliente", "come04pedventadoccliDesc", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Doc Cliente Nro", "come01clientenumdoc", 0, "", 100, true, false, true);

                    var Pedventacab = PedidoVentaLogic.Instance.PedVentaPend(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = Pedventacab;

                    this.lblTitulo.Text = "PEDIDOS DE VENTA";
                    break;
                case enmAyuda.enmPedVentIngPT:
                    this.CreateGridColumn(this.gridControl, "Codigo", "come01pedvencodprod", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "IN01DESLAR", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Item", "come01pedvenitem", 0, "", 400, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Cantidad", "come01prodcantequiprod", 0, "", 100, true, false, true);


                    var ArticulosxPV = ArticuloLogic.Instance.PtXPedVenta(Logueo.CodigoEmpresa, Logueo.Anio, this._parametros2.ToString());
                    this.gridControl.DataSource = ArticulosxPV;

                    this.lblTitulo.Text = "ARTÍCULOS POR PEDIDO DE VENTA";
                    break;
                case enmAyuda.enmarticulosconstocksuministros:
                    this.CreateGridColumn(this.gridControl, "Codigo", "in01key", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 400, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Uni Med", "UnidadMedida", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Stock", "StockXAlm", 0, "", 100, true, false, true);
                    this.gridControl.Columns[0].FilterDescriptor = new Telerik.WinControls.Data.FilterDescriptor(null, Telerik.WinControls.Data.FilterOperator.StartsWith, null);
        
                    var ArticulosSum = ArticuloLogic.Instance.TraerArticuloSumXAlmacen(Logueo.CodigoEmpresa, Logueo.Anio,this._parametros.ToString());
                    this.gridControl.DataSource = ArticulosSum;

                    this.lblTitulo.Text = "ARTÍCULOS";
                    break;


                case enmAyuda.enmAlmacen:
                    this.CreateGridColumn(this.gridControl, "Código", "In09codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "In09descripcion", 0, "", 300, true, false, true);                                      
                    var almacenes = AlmacenLogic.Instance.TraerAlmacen(Logueo.CodigoEmpresa, 
                        this._parametros.ToString());                    
                    this.gridControl.DataSource = almacenes;                                                                                              
                    this.lblTitulo.Text = "ALMACENES";
                    break;
                case enmAyuda.enmAlmacenTodos:
                        this.CreateGridColumn(this.gridControl, "Código", "In09codigo", 0, "", 60, true, false, true);
                        this.CreateGridColumn(this.gridControl, "Descripción", "In09descripcion", 0, "", 300, true, false, true);
                        var almacenestodos = AlmacenLogic.Instance.TraerTodos(Logueo.CodigoEmpresa);
                        this.gridControl.DataSource = almacenestodos;
                        this.lblTitulo.Text = "ALMACENES";
                    break;
                case enmAyuda.enmprovmateriaprima:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nombre", "Nombre", 0, "", 300, true, false, true);
                    var provmateriaprima = ProveedorLogic.Instance.TraerProveedor(Logueo.CodigoEmpresa, Logueo.TipoAnalisisMateriaPrima);                    
                    this.gridControl.DataSource = provmateriaprima;
                    this.lblTitulo.Text = "PROVEEDOR DE MATERIA PRIMA";
                    break;
                case enmAyuda.enmMoneda:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var monedas = MonedaLogic.Instance.TraerMoneda(Constantes.Tablas.CODIGO_TABLA_MONEDA);
                    this.gridControl.DataSource = monedas;
                    this.lblTitulo.Text = "TIPO DE MONEDA";
                    break;
                //Ayua de caracteristicas de los productos
                case enmAyuda.enmTipo:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var tipo = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.tipo);
                    this.gridControl.DataSource = tipo;                    
                    break;
                case enmAyuda.enmColor:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var color = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.color);
                    this.gridControl.DataSource = color;                    
                    break;
                case enmAyuda.enmTonalidad:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var tonalidad = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.tonalidad);
                    this.gridControl.DataSource = tonalidad;
                    break;
                case enmAyuda.enmFormato:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    var formato = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.formato);
                    this.gridControl.DataSource = formato;
                    break;
                case enmAyuda.enmAcabado:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var acabado = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.acabado);
                    this.gridControl.DataSource = acabado;
                    break;

                case enmAyuda.enmRelleno:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var relleno = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.relleno);
                    this.gridControl.DataSource = relleno;
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
                case enmAyuda.enmModelo:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var modelo = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(Constantes.ProTerCarateristicas.modelo);
                    this.gridControl.DataSource = modelo;
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

                // Ayuda del articulo

                case enmAyuda.enmUniMed:
                    this.CreateGridColumn(this.gridControl, "Código", "in21codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "in21descri", 0, "", 300, true, false, true);

                    var unimed = UnidaddeMedidaLogic.Instance.TraerUnidaddeMedida(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = unimed;
                    break;
                    //ayuda  para ver codigo y descripcion de artiulo a seleccionar para registrar en la grilla
                    // de formulario de cuenta currienta pestaña producto 
                    
                case enmAyuda.enmProductosxCliente:
                    this.CreateGridColumn(this.gridControl, "Codigo", "IN01KEY", 0, "", 40, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "IN01DESLAR", 0, "", 50, true, false, true);
                    
                    this.gridControl.DataSource = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa, Logueo.Anio,"03");
                    this.lblTitulo.Text = "ARTICULO POR CLIENTE";
                    break;

                case enmAyuda.enmEquivalenciaProducto:
                    this.CreateGridColumn(this.gridControl, "CodCli", "In20clientecod", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Cliente", "NombreCliente", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Codigo producto", "In20Codigo", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "In20Descripcion", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "UnidadCaja", "In20UndxCaja", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Piezas", "In20PiezasxCaja", 0, "", 50, true, false, false);
                    this.gridControl.DataSource = ArticuloClienteLogic.Instance.TraerArticuloClienteHelp(Logueo.CodigoEmpresa, "01");
                    this.lblTitulo.Text = "EQUIPOS POR CLIENTE";
                    break;
                case enmAyuda.enmNotaSalida:                    
                    this.CreateGridColumn(this.gridControl, "Codigo", "IN06CODDOC", 0, "", 50, true, false, true);
                        this.CreateGridColumn(this.gridControl, "Mes", "IN06MM", 0, "", 50, true, false, true);
                        this.CreateGridColumn(this.gridControl, "Anio", "IN06AA", 0, "", 50, true, false, true);
                        this.CreateGridColumn(this.gridControl, "Tipo documento", "Tipo_Documento", 0, "", 50, true, false, true);
                        this.CreateGridColumn(this.gridControl, "CodigoDoc", "in12TipDoc", 0, "", 50, true, false, false);
                        this.CreateGridColumn(this.gridControl, "Fecha", "FechaDoc", 0, "", 50, true, false, false);
                        var notas = DocumentoLogic.Instance.Spu_Inv_Trae_NotaSalida(Logueo.CodigoEmpresa);                        
                        this.gridControl.DataSource = notas;
                        this.lblTitulo.Text = "SALIDAS";                                                           
                    break;
                case enmAyuda.enmContratista:
                    this.CreateGridColumn(this.gridControl, "Codigo", "ccm02cod", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nombre", "ccm02nom", 0, "", 50, true, false, true);
                    var contratista = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, "13");
                    this.gridControl.DataSource = contratista;
                    this.lblTitulo.Text = "CONTRATISTA";
                    break;
                case enmAyuda.enmCantera:                    
                    this.CreateGridColumn(this.gridControl, "codigoEmpresa", "IN20CODEMP", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Codigo", "IN20CODIGO", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "IN20DESC", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "CodProv", "IN20CODPROVEEDOR", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Proveedor", "NOMPROV", 0, "", 120, true, false, true);
                    var canterasxcontratista = CanterasLogic.Instance.TraerCanteras(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = canterasxcontratista;
                    this.lblTitulo.Text = "CANTERAS";
                    break;

                case enmAyuda.enmCuentaCorriente:
                    this.CreateGridColumn(this.gridControl, "Codigo", "Codigo", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "Descripcion", 0, "", 120, true, false, true);
                    var cta = TipoAnalisisLogic.Instance.TraerTipoAnalisis(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = cta;
                    this.lblTitulo.Text = "CUENTAS CORRIENTES";
                    break;
                case enmAyuda.enmNaturaleza:
                    this.CreateGridColumn(this.gridControl, "Codigo", "Codigo", 0, "", 50);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "Descripcion", 0, "", 120);
                    var nat = NaturalezaLogic.Instance.TraerNaturaleza("*");
                    this.gridControl.DataSource = nat;
                    this.lblTitulo.Text = "NATURALEZA";
                    break;
                case enmAyuda.enmLinea:
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 50);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 50);
                    var lineas = LineaLogic.Instance.LineaTraer(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = lineas;
                    this.lblTitulo.Text = "LINEAS";
                    break;

                case enmAyuda.enmActividadNivel1:
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 100);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 150);
                    this.CreateGridColumn(gridControl, "Almacen", "codigoAlmacen", 0, "", 100, true, false, false);
                    this.CreateGridColumn(gridControl, "Alm:Defecto", "almacenxdefecto", 0, "", 100, true, false, false);
                    var actividad1 = ActividadNivel1Logic.Instance.ActividadNivel1TraerAyuda(Logueo.CodigoEmpresa, this._parametros.ToString());
                    this.gridControl.DataSource = actividad1;
                    this.lblTitulo.Text = "ACTIVIDAD NIVEL 1";
                    break;

                case enmAyuda.enmTurnos:
                    this.CreateGridColumn(gridControl, "Empresa", "codigoEmpresa", 0, "", 50, true, false, false);
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 150);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 200);
                    var turno = TurnosLogic.Instance.TurnosListar(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = turno;
                    this.lblTitulo.Text = "TURNOS";
                    break;
                case enmAyuda.enmProducObjetivo:
                    this.CreateGridColumn(this.gridControl, "Codigo", "codigo", 0, "", 40, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "descripcion", 0, "", 50, true, false, true);
                    this.gridControl.DataSource = ArticuloLogic.Instance.TraerArticuloXAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this._parametros.ToString());
                    this.lblTitulo.Text = "Producto";
                    break;
                case enmAyuda.enmAlmacenxNaturaleza:
                    this.CreateGridColumn(gridControl, "Codigo", "In09codigo", 0, "", 50);
                    this.CreateGridColumn(gridControl, "Descripcion", "In09descripcion", 0, "", 50);
                    var almxNaturaleza = AlmacenLogic.Instance.TraerAlmacen(Logueo.CodigoEmpresa, this._parametros.ToString());
                    this.gridControl.DataSource = almxNaturaleza;
                    this.lblTitulo.Text = "Almacenes";
                    break;
                case enmAyuda.enmCanastillasMultiplePP:
                    this.CreateGridColumn(this.gridControl, "Fec.Ingreso", "FechaIngresoUltimo", 0, "{0:dd/MM/yyyy}", 120);
                    this.CreateGridColumn(this.gridControl, "Fec.Ingreso", "FechaIngresoUltimotexto", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Hora Salida", "HoraSalida", 0, "{0:##:##}", 70);
                    this.CreateGridColumn(this.gridControl, "Transancion", "TransaDesc", 0, "", 120);
                    this.CreateGridColumn(this.gridControl, "N° Doc.Ingreso", "DocingCD", 0, "", 150,true,false,true);
                    this.CreateGridColumn(this.gridControl, "N° OT", "OrdenTrabajo", 0, "", 80);                    

                    this.CreateGridColumn(this.gridControl, "Canastilla", "nrocaja", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Almacen", "in09descripcion", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Producto Cod", "codigo", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "producto Desc", "descripcion", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Uni Med", "unidadmedida", 0, "", 50);
                    this.CreateGridColumn(this.gridControl, "Cantidad", "CanPiezas", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "Ancho", "PPAncho", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Largo", "PPLargo", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Espesor", "PPEspesor", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Area(M2)", "CanArea", 0, "{0:###,###0.00}", 100);

                    this.CreateGridChkColumn(this.gridControl, "chkSelect", "chkSelect", 0, "", 50, false, true, true);
                    
                    this.CreateGridColumn(this.gridControl, "Largo", "Largo", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Ancho", "Ancho", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Alto", "Alto", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 100, true, false, false);
                    
                    this.CreateGridColumn(this.gridControl, "DocingPT", "DocingPT", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Orden", "Orden", 0, "", 70, true, false, false);

                    var listaCanastilla = DocumentoLogic.Instance.TraerCanastillaMP(Logueo.CodigoEmpresa, this._parametros.ToString());
                    this.gridControl.DataSource = listaCanastilla;

                    this.lblTitulo.Text = "Canastillas";
                    break;

                case enmAyuda.enmCanastillasMultipleMP:
                     this.CreateGridColumn(this.gridControl, "Canastilla", "nrocaja", 0, "", 120);
                    this.CreateGridColumn(this.gridControl, "Almacen", "IN09CODIGO", 0, "", 70, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Producto", "CodigoProducto", 0, "", 120);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "descripcion", 0, "", 180);
                    this.CreateGridColumn(this.gridControl, "Unidad", "UnidadMedida", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Volumen", "StockRealVolumen", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "ancho", "MPAncho", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "alto", "MPAlto", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "largo", "MPlargo", 0, "{0:###,###0.00}", 100);
                    this.CreateGridChkColumn(this.gridControl, "Seleccionar", "chkSelect", 0, "", 50, false, true, true);
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMP", "DocingMP", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 50, true, false, false);
                    this.gridControl.DataSource = DocumentoLogic.Instance.TraerMateriaPrimaTodos(Logueo.CodigoEmpresa,
                                                  this._parametros.ToString());
                    this.lblTitulo.Text = "Materia Prima";
                    break;
                case enmAyuda.enmOrdenTrabajo:

                    this.CreateGridColumn(this.gridControl, "Fec.Ingreso", "FechaIngresoUltimo", 0, "{0:dd/MM/yyyy}", 120);
                    this.CreateGridColumn(this.gridControl, "Fec.Ingreso", "FechaIngresoUltimotexto", 0, "", 0, true, false, false);                    
                    this.CreateGridColumn(this.gridControl, "Transancion", "TransaDesc", 0, "", 120);                    
                    this.CreateGridColumn(this.gridControl, "N° OT", "OrdenTrabajo", 0, "", 80);                    

                    this.CreateGridColumn(this.gridControl, "Canastilla", "nrocaja", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "CodAlm", "in09codigo", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Almacen", "in09descripcion", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Producto Cod", "codigo", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "producto Desc", "descripcion", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Uni Med", "unidadmedida", 0, "", 50);
                    this.CreateGridColumn(this.gridControl, "Cantidad", "CanPiezas", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "Ancho", "Ancho", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Largo", "Largo", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Espesor", "Alto", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Area(M2)", "CanArea", 0, "{0:###,###0.00}", 100);                    
                    
                    
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 100, true, false, false);                    
                    this.CreateGridColumn(this.gridControl, "DocingPT", "DocingPT", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "AreaxUni", "AreaxUni", 0, "", 100, true, false);
                    this.CreateGridColumn(this.gridControl, "Alm.Defecto", "almptxdefecto", 0, "", 100, true, false, false);
                    
                    //Codigo de Almacen de Linea - > 14
                    this.gridControl.DataSource = DocumentoLogic.Instance.TraerStockPPxAlmacen(Logueo.CodigoEmpresa, "14");
                    this.lblTitulo.Text = "Canastillas";                                        
                    break;
                case enmAyuda.enmMotivo:
                    this.CreateGridColumn(this.gridControl, "Empresa", "PRO15CODEMP", 0, "", 30, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Codigo", "PRO15CODIGO", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "PRO15DESCRIPCION", 0, "", 120);
                    this.gridControl.DataSource = MotivoLogic.Instance.TraerLista(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmStockLinea:
                    this.CreateGridColumn(this.gridControl, "OT", "IN07ORDENTRABAJO", 0, "", 30, true, false);
                    this.CreateGridColumn(this.gridControl, "Cod.Alm", "CodigoAlmacen", 0, "", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Des.Alm", "AlmacenDesc", 0, "", 50, true, false);

                    this.CreateGridColumn(this.gridControl, "NroCaja", "NroCaja", 0, "", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Cod.Prod", "CodigoArticulo", 0, "", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Des.Prod", "IN01DESLAR", 0, "", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "UM", "UnidadMedida", 0, "", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Fec.Ultimo", "FechaIngresoUltima", 0, "{0:dd/MM/yyyy}", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Stock", "Stock", 0, "{0:###,###0.00}", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Ancho", "Ancho", 0, "{0:###,###0.00}", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Alto", "Alto", 0, "{0:###,###0.00}", 50, true, false);
                    this.CreateGridColumn(this.gridControl, "Largo", "Largo", 0, "{0:###,###0.00}", 50, true, false);
                    // columnas de area

                    this.CreateGridColumn(this.gridControl, "AreaxUni", "Areaxuni", 0, "{0:###,###0.00}", 60, true, false);
                    this.CreateGridColumn(this.gridControl, "Area", "Area", 0, "{0:###,###0.00}", 60, true, false);
                    this.CreateGridChkColumn(this.gridControl, "Seleccionar", "chkSelect", 0, "", 50, false, true);
                    this.gridControl.DataSource = DocumentoLogic.Instance.TraerAyudaStockLinea(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmLineaArti:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 90, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 150, true, false, true);
                    gridControl.DataSource = LineaArticuloLogic.Instance.TraeLineaArticulo(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmGrupoArti:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 120, true, false, true);

                    datos = this._parametros.ToString().Split('|');
                    this.gridControl.DataSource = LineaArticuloLogic.Instance.TraeGrupoArticulo(Logueo.CodigoEmpresa, datos[0]);
                    break;
                case enmAyuda.enmSubGrupoArti:
                    CreateGridColumn(gridControl, "Codigo", "Codigo", 0, "", 70, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "Descripcion", 0, "", 150, true, false, true);
                    datos = this._parametros.ToString().Split('|');
                    this.gridControl.DataSource = LineaArticuloLogic.Instance.TraeSubGrupoArticulo(Logueo.CodigoEmpresa, datos[0], datos[1]);
                    break;
                case enmAyuda.enmUniMedEquiv:
                     this.CreateGridColumn(this.gridControl, "Código", "in21codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "in21descri", 0, "", 300, true, false, true);

                    unimed = UnidaddeMedidaLogic.Instance.TraerUnidaddeMedida(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = unimed;
                    break;
                case enmAyuda.enmCalidadMP:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120, true, false, true);
                    this.gridControl.DataSource =  GlobalLogic.Instance.TraeAyudaGlobal("60", "GLO", "", "*");
                    break;
                    //NUEVO
                case enmAyuda.enmTipoCostoMP:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120, true, false, true);
                    this.gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("70", "GLO", "glo01codigo", "*");

                    break;
                    //NUEVO BLOQUE COSTEO
                case enmAyuda.enmBloquesCosteo:
                    CreateGridColumn(gridControl, "Codigo", "IN07CODBLOQUEEMP", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "IN01DESLAR", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Uni Med", "IN07UNIMED", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Cantidad", "IN07CANART", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Codigo Proveedor", "IN07CODBLOQUEPROV", 0, "", 120, true, false, true);
                    this.gridControl.DataSource = AlmacenLogic.Instance.Traer_BloqueCosteo(Logueo.CodigoEmpresa,Logueo.Anio,Logueo.Mes);

                    break;
                case enmAyuda.enmFactTransportBloques:
                    CreateGridColumn(gridControl, "Tip Documento", "CO05TIPDOC", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Nro Documento", "CO05NRODOC", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Nro Cliente", "CO05CODCTE", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Fecha", "CO05FECHA", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Moneda", "CO05MONEDA", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Importe", "importe", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Concepto", "Concepto", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "ccm02nom", 0, "", 120, true, false, true);




                    this.gridControl.DataSource = AlmacenLogic.Instance.Traer_FactTransporteBloques(Logueo.CodigoEmpresa,Logueo.Anio,Logueo.Mes);

                    break;
                case enmAyuda.enmOrdenCompra:
                    CreateGridColumn(gridControl, "Nombre", "ccm02nom", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "NroOrdenCompra", "CodigoOrdenCompra", 0, "", 120, true, false, true);                    
                    this.gridControl.DataSource =  DocumentoLogic.Instance.TraeAyudaOrdenCompra(Logueo.CodigoEmpresa,
                                                    this._parametros.ToString(), Logueo.Mes, "C", "02", "", "*");
                    this.Text = "Orden de compra";
                    break;
                case enmAyuda.enmMaquinaInventario:
                    CreateGridColumn(gridControl, "Codigo", "In20Codigo", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Nombre", "In20Descripcion", 0, "", 120, true, false, true);
                    this.gridControl.DataSource =  MaquinaLogic.Instance.TraeMaquinaInventario(Logueo.CodigoEmpresa, "", "*");
                    this.Text = "Maquina";
                    break;
                case enmAyuda.enmLibro:
                    CreateGridColumn(gridControl, "Codigo", "ccb02cod", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "ccb02des", 0, "", 120, true, false, true);
                    this.gridControl.DataSource = GlobalLogic.Instance.TraeAyudaLibroInventario(Logueo.CodigoEmpresa,Logueo.Anio, "ccb02cod", "*");
                    this.Text = "Libro";
                    break;

                case enmAyuda.enmCuentaContable:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 70, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120, true, false, true);
                    this.gridControl.DataSource = GlobalLogic.Instance.TraeRegistrosDeTablaGlobal("55", "", "*");
                    this.Text = "Cuenta contable";
                    break;

                case enmAyuda.enmEstadoInventarioFisico:
                    CreateGridColumn(gridControl, "Codigo", "glo01codigo", 0, "", 120, true, false, true);
                    CreateGridColumn(gridControl, "Descripcion", "glo01descripcion", 0, "", 120, true, false, true);
                    this.gridControl.DataSource = GlobalLogic.Instance.TraeAyudaGlobal("71", "GLO", "glo01codigo", "*");

                    break;
                default:
                    break;
            }

        }
        protected override void OnAceptar()
        {
            if (this.gridControl.RowCount == 0) return;
            
            this.Result = string.Empty;
            Articulo art = new Articulo();
            CuentaCorriente cuenta = new CuentaCorriente();
            Canteras cantera = new Canteras();
            TipoAnalisis tipana = new TipoAnalisis();
            TipoTransaccion transaccion = new TipoTransaccion();
            Proveedor materiaPrima = new Proveedor();

            string[] registroSeleccionados;
            bool isChecked = false;
            object valor = null;

            int indiceFila = 0;
            int cantSeleccionados = 0;

            Spu_Pro_Trae_PPStock canastilla = new Spu_Pro_Trae_PPStock();

            List<Spu_Pro_Trae_PPStock> listaCanastilla = new List<Spu_Pro_Trae_PPStock>();
            Spu_Inv_Trae_StockDetMPTodos canastillaMP = new Spu_Inv_Trae_StockDetMPTodos();
            List<Spu_Inv_Trae_StockDetMPTodos> listaCanastillaMP = new List<Spu_Inv_Trae_StockDetMPTodos>();
            switch (this._tipoAyuda)
            {
                    
                case enmAyuda.enmTipoDocumento:
                    string[] arreglo = new string[3];
                    if (this.gridControl.CurrentRow.Cells["in12TipDoc"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["in12TipDoc"].Value.ToString() + "|" +
                          this.gridControl.CurrentRow.Cells["in12DesLar"].Value.ToString() + "|" +
                          this.gridControl.CurrentRow.Cells["in12FlagGeneraDocNum"].Value.ToString();

                    break;
                case enmAyuda.enmTransaccion:
                     transaccion = new TipoTransaccion();
                    if (this.gridControl.CurrentRow.Cells["in15Codigo"].Value == null) return;     
                    this.Result = this.gridControl.CurrentRow.Cells["in15Codigo"].Value.ToString();;
                    break;
                case enmAyuda.enmProveedor:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmPedido:
                    break;
                case enmAyuda.enmCliente:
                    if (this.gridControl.CurrentRow.Cells["ccm02nom"].Value == null) return;                    
                    this.Result = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();                        
                    break;
                case enmAyuda.enmCtaCteDesc:
                    if (this.gridControl.CurrentRow.Cells["ccm02nom"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                    break;
                case enmAyuda.enmCentroCosto:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmResponsableReceptor:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmResponsable:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmObra:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmMaquina:
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;                 
                    this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    break;

                case enmAyuda.enmLote:
                    break;
                    
                case enmAyuda.enmProductoXAlmacen:
                    isChecked = false;
                    valor = null;
                    foreach (GridViewRowInfo row in gridControl.Rows)
                    {
                        valor = row.Cells["chkSelect"].Value;
                        isChecked = Util.convertiracadena(valor) == "" ? false : true;
                        if (isChecked)
                        {
                            cantSeleccionados = cantSeleccionados + 1;
                        }
                        
                    }
                    registroSeleccionados = new string[cantSeleccionados];

                    foreach (GridViewRowInfo row in gridControl.Rows)
                    {
                        
                        valor = row.Cells["chkSelect"].Value;
                        isChecked = Util.convertiracadena(valor) == "" ? false : true;
                        if (isChecked)
                        {
                                registroSeleccionados[indiceFila] = 
                                Util.GetCurrentCellText(row, "Codigo") + "|" + // IN07KEY                                 
                                Util.GetCurrentCellText(row, "UnidadMedida") + "|" + // IN07UNIMED
                                Util.GetCurrentCellText(row, "CanPiezas") + "|" + //IN07CANART
                                Util.GetCurrentCellText(row, "IN07LARGO") + "|" + // IN07LARGO
                                Util.GetCurrentCellText(row, "IN07ANCHO") + "|" + // IN07ANCHO
                                Util.GetCurrentCellText(row, "IN07ALTO") + "|"+   // IN07ALTO       

                                Util.GetCurrentCellText(row, "nrocaja") + "|" + //IN07NROCAJA
                                Util.GetCurrentCellText(row, "DocingAA") + "|" + //IN07DocIngAA
                                Util.GetCurrentCellText(row, "DocingMM") + "|" + //IN07DocIngMM
                                Util.GetCurrentCellText(row, "DocingTD") + "|" + //IN07DocIngTIPDOC
                                Util.GetCurrentCellText(row, "DocingCD") + "|" + //IN07DocIngCODDOC
                                Util.GetCurrentCellText(row, "DocingPT") + "|" + //IN07DocIngKEY
                                Util.GetCurrentCellText(row, "DocingNO") + "|" + //IN07DocIngORDEN
                                Util.GetCurrentCellText(row, "AreaxUni")+ "|" + // IN07AREAXUNI
                                Util.GetCurrentCellText(row, "Cliente") + "|" +
                                Util.GetCurrentCellText(row, "ClientePedidonro") + "|" +  //IN07CODCLI
                                Util.GetCurrentCellText(row, "IN07CALIDADMP");  //IN07CALIDADMP
                                                 
                                //Util.GetCurrentCellText(row, "clienteNombre") + "|" +
                                //Util.GetCurrentCellText(row, "ClientePedidonro") + "|" +                                                                    
                                indiceFila = indiceFila + 1;
                            
                        }

                    }

                    this.Result = Util.ConvertiraXMLdinamico(registroSeleccionados);
              
                    // Seleccion multiple
                    
                    break;

                case enmAyuda.enmProductoXPedVenSalida:
                // Recorro las grilla con las filas seleccionadas
               var x = 0;
               List<EntidadAyuda> listaValores = new List<EntidadAyuda>();
            foreach (var filaSeleccionado in gridControl.SelectedRows)
            {
                // AÑADES LOS VALORES CAPTURADOS
                string campotexto1 = filaSeleccionado.Cells["in07pedvencodprod"].Value.ToString();
                string campotexto2 = filaSeleccionado.Cells["IN07AA"].Value.ToString();
                string campotexto3 = filaSeleccionado.Cells["IN07MM"].Value.ToString();
                string campotexto4 = filaSeleccionado.Cells["IN07TIPDOC"].Value.ToString();
                string campotexto5 = filaSeleccionado.Cells["IN07CODDOC"].Value.ToString();
                string campotexto6 = filaSeleccionado.Cells["IN07KEY"].Value.ToString();
                string campotexto7 = filaSeleccionado.Cells["IN07ORDEN"].Value.ToString();
                string campotexto8 = filaSeleccionado.Cells["IN07CANART"].Value.ToString();
                string campotexto9 = filaSeleccionado.Cells["IN07AREA"].Value.ToString();
                string campotexto10 = filaSeleccionado.Cells["IN07NROCAJA"].Value.ToString();
                string campotexto11 = filaSeleccionado.Cells["in07pedvennum"].Value.ToString();
                string campotexto12 = filaSeleccionado.Cells["in07pedvenitem"].Value.ToString();
                string campotexto13 = "";
                string campotexto14 = "";
                string campotexto15 = "";


                double camponumero1 = double.Parse(filaSeleccionado.Cells["IN07AREAXUNI"].Value.ToString());
                double camponumero2 = 0;
                double camponumero3 = 0;
                double camponumero4 = 0;
                double camponumero5 = 0;

                listaValores.Add(new EntidadAyuda(campotexto1, campotexto2, campotexto3, campotexto4, campotexto5, 
                                                    campotexto6,campotexto7, campotexto8, campotexto9, campotexto10,
                                                    campotexto11, campotexto12, campotexto13, campotexto14, campotexto15, 
                                                    camponumero1, camponumero2,camponumero3, camponumero4, camponumero5));
                x++;
            } 
             
            this.Result = listaValores;
            break;

            case enmAyuda.enmProductoXAlmacenIng:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmAlmacen:
                    if (this.gridControl.CurrentRow.Cells["In09codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["In09codigo"].Value.ToString();
                    break;
                case enmAyuda.enmAlmacenTodos:
                    if (this.gridControl.CurrentRow.Cells["In09codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["In09codigo"].Value.ToString();
                    break;
                case enmAyuda.enmPedVentIng:
                    if (this.gridControl.CurrentRow.Cells["come01pedvennum"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["come01pedvennum"].Value.ToString();
                    break;
                case enmAyuda.enmarticulosconstocksuministros:
                    if (this.gridControl.CurrentRow.Cells["in01key"].Value == null) return;

                    this.Result =   this.gridControl.CurrentRow.Cells["in01key"].Value.ToString() + "¦" +
                                    this.gridControl.CurrentRow.Cells["Descripcion"].Value.ToString() + "¦" +
                                    this.gridControl.CurrentRow.Cells["UnidadMedida"].Value.ToString() + "¦" +
                                    this.gridControl.CurrentRow.Cells["StockXAlm"].Value.ToString() ;

                    break;
                    
                case enmAyuda.enmPedVentIngPT:
                    
                    if (this.gridControl.CurrentRow.Cells["come01pedvencodprod"].Value == null) return;

                    this.Result = _PedidoVentaSeleccionado + "/" +
                                    this.gridControl.CurrentRow.Cells["come01pedvencodprod"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["come01pedvenitem"].Value.ToString();
                    break;

                case enmAyuda.enmprovmateriaprima:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;                                                            
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();                    
                    break;
                case enmAyuda.enmMoneda:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmTipo:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmColor:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmTonalidad:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmFormato:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmAcabado:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmRelleno:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmBorde:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmCalidad:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmModelo:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
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
                case enmAyuda.enmUniMed:
                    if (this.gridControl.CurrentRow.Cells["in21codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["in21codigo"].Value.ToString();
                    break;
                 /************Linea añadido por Ivan para listar Producto************************/
                case enmAyuda.enmProductosxCliente:

                    if (this.gridControl.CurrentRow.Cells["IN01KEY"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["IN01KEY"].Value + "";
                    break;
                /************Linea añadido por Ivan para listar Producto***********************/

                case enmAyuda.enmEquivalenciaProducto:
                    if (this.gridControl.CurrentRow.Cells["In20Codigo"].Value == null) return;
                    List<ArticuloCliente> listaArtCli = new List<ArticuloCliente>();
                    ArticuloCliente entidad = new ArticuloCliente();
                    if (gridControl.SelectedRows.Count == 0) {
                        return;                        
                    }
                    entidad.In20clientecod = this.gridControl.CurrentRow.Cells["In20clientecod"].Value.ToString();
                        entidad.In20Codigo = this.gridControl.CurrentRow.Cells["In20Codigo"].Value.ToString();
                        entidad.NombreCliente = this.gridControl.CurrentRow.Cells["NombreCliente"].Value.ToString();
                        entidad.In20Descripcion = this.gridControl.CurrentRow.Cells["In20Descripcion"].Value.ToString();
                        entidad.In20UndxCaja = Convert.ToDouble(this.gridControl.CurrentRow.Cells["In20UndxCaja"].Value.ToString());
                        entidad.In20PiezasxCaja = Convert.ToInt32(this.gridControl.CurrentRow.Cells["In20PiezasxCaja"].Value.ToString());
                        listaArtCli.Add(entidad);
                        this.Result = listaArtCli;
                    
                    break;
                case enmAyuda.enmNotaSalida:
                    if (this.gridControl.CurrentRow.Cells["IN06CODDOC"].Value == null) return;
                    this.Result = gridControl.CurrentRow.Cells["IN06AA"].Value.ToString() +
                                  gridControl.CurrentRow.Cells["IN06MM"].Value.ToString() +
                                  gridControl.CurrentRow.Cells["in12TipDoc"].Value.ToString() +
                                  gridControl.CurrentRow.Cells["IN06CODDOC"].Value.ToString();
                   break;
                case enmAyuda.enmContratista:
                   if (this.gridControl.CurrentRow.Cells["ccm02cod"].Value == null) return;                   
                    this.Result = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();                    
                   break;
                case enmAyuda.enmCanterasxContratista:
                   if (this.gridControl.CurrentRow.Cells["IN20CODIGO"].Value == null) return;
                   this.Result = gridControl.CurrentRow.Cells["IN20CODIGO"].Value.ToString();
                   break;
                case enmAyuda.enmCantera:
                   if (this.gridControl.CurrentRow.Cells["IN20CODIGO"].Value == null) return;
                   this.Result = gridControl.CurrentRow.Cells["IN20CODIGO"].Value.ToString();
                   break;
                case enmAyuda.enmCuentaCorriente:
                   if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;                   
                   this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                   break;
                case enmAyuda.enmNaturaleza:
                   if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                   break;
                case enmAyuda.enmLinea:
                   if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                   break;
                case enmAyuda.enmActividadNivel1:
                   if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                   break;
                case enmAyuda.enmTurnos:
                   if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                   break;
                case enmAyuda.enmProducObjetivo:
                   if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                   art.IN01KEY = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                   art.IN01DESLAR = this.gridControl.CurrentRow.Cells["descripcion"].Value.ToString();
                   this.Result = art;
                   break;
                case enmAyuda.enmAlmacenxNaturaleza:
                   if (this.gridControl.CurrentRow.Cells["In09codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["In09codigo"].Value.ToString();
                   break;
                case enmAyuda.enmCanastillasMultiplePP:
                     if (this.gridControl.CurrentRow.Cells["nrocaja"].Value == null) return;
                         //x = 0;
                        
                    
                    foreach (GridViewRowInfo row in gridControl.Rows) {
                        isChecked = false;
                        valor = row.Cells["chkSelect"].Value;
                        isChecked = valor == null ? false : true;                               
                        
                        if (isChecked)
                        {                        
                            canastilla = new Spu_Pro_Trae_PPStock();                            
                            canastilla.DocingAA = row.Cells["DocingAA"].Value.ToString();
                            canastilla.DocingMM = row.Cells["DocingMM"].Value.ToString();
                            canastilla.DocingTD = row.Cells["DocingTD"].Value.ToString();
                            canastilla.DocingCD = row.Cells["DocingCD"].Value.ToString();
                            canastilla.DocingPT = row.Cells["DocingPT"].Value.ToString();
                            canastilla.DocingNO = row.Cells["DocingNO"].Value.ToString();
                            canastilla.CanPiezas = row.Cells["CanPiezas"].Value.ToString();
                            canastilla.Largo = Convert.ToDouble(row.Cells["Largo"].Value);
                            canastilla.Ancho = Convert.ToDouble(row.Cells["Ancho"].Value);
                            canastilla.Alto = Convert.ToDouble(row.Cells["Alto"].Value);
                            canastilla.PPAncho = Convert.ToDouble(row.Cells["PPAncho"].Value);
                            canastilla.PPLargo = Convert.ToDouble(row.Cells["PPLargo"].Value);
                            canastilla.PPEspesor = Convert.ToDouble(row.Cells["PPEspesor"].Value);
                            canastilla.nrocaja = row.Cells["nrocaja"].Value.ToString();
                            canastilla.unidadmedida = row.Cells["unidadmedida"].Value.ToString();
                            canastilla.OrdenTrabajo = row.Cells["OrdenTrabajo"].Value.ToString();
                            canastilla.FechaIngresoUltimotexto = row.Cells["FechaIngresoUltimotexto"].Value.ToString();
                            canastilla.HoraSalida = row.Cells["HoraSalida"].Value.ToString();
                            listaCanastilla.Add(canastilla);                                                      
                        }
                                       
                    }
                    if (listaCanastilla.Count == 0) {
                        MessageBox.Show("Debe seleccionar al menos un registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (listaCanastilla.Count > 0) {                       
                        string[] registros = new string[listaCanastilla.Count];
                        x = 0;
                        //Armar Xml
                        foreach (Spu_Pro_Trae_PPStock fila in listaCanastilla)
                        {
                            registros[x] = Logueo.CodigoEmpresa + "|" + fila.DocingAA + "|" + fila.DocingMM + "|" + fila.DocingTD + "|" +
                                           fila.DocingCD + "|" + fila.DocingPT + "|" + fila.DocingNO + "|" +
                                           fila.CanPiezas + "|" + fila.OrdenTrabajo +
                                           fila.nrocaja + fila.FechaIngresoUltimotexto + fila.HoraSalida + "|" + "";
                            x++;
                        }
                        string FlagValidacion = "";
                        FlagValidacion = "1";
                        string FlagDeRetorno = "";
                        string msgRetorno = "";
                        DocumentoLogic.Instance.TraerValidacionSalidasPP(Util.ConvertiraXMLMateriaPrima(registros), FlagValidacion,
                                                                          out FlagDeRetorno, out msgRetorno);
                        if (FlagDeRetorno == "2")
                        {
                            RadMessageBox.Show(msgRetorno, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            //limpio el mensaje
                            msgRetorno = string.Empty;
                            DialogResult res = RadMessageBox.Show("¿Desea continuar?",
                                                     "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                            if (res == System.Windows.Forms.DialogResult.Yes)
                            {
                                //flag para saltar el proceso de validacion
                                this.Result = listaCanastilla;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            this.Result = listaCanastilla;
                        }
                        //
                    }
                   break;
                case enmAyuda.enmCanastillasMultipleMP:

                   if (this.gridControl.CurrentRow.Cells["nrocaja"].Value == null) return;
                   string[] registrosMP;
                   foreach (GridViewRowInfo row in gridControl.Rows)
                   {
                       isChecked = false;
                       valor = row.Cells["chkSelect"].Value;
                       isChecked = valor == null ? false : true;

                       if (isChecked)
                       {

                           canastillaMP = new Spu_Inv_Trae_StockDetMPTodos();
                           canastillaMP.DocingAA = row.Cells["DocingAA"].Value.ToString();
                           canastillaMP.DocingMM = row.Cells["DocingMM"].Value.ToString();
                           canastillaMP.DocingTD = row.Cells["DocingTD"].Value.ToString();
                           canastillaMP.DocingCD = row.Cells["DocingCD"].Value.ToString();
                           canastillaMP.DocingMP = row.Cells["DocingMP"].Value.ToString();
                           canastillaMP.DocingNO = row.Cells["DocingNO"].Value.ToString();
                           canastillaMP.MPlargo = row.Cells["MPlargo"].Value.ToString();
                           canastillaMP.MPAlto = row.Cells["MPAlto"].Value.ToString();
                           canastillaMP.MPAncho = row.Cells["MPAncho"].Value.ToString();
                           canastillaMP.StockRealVolumen = row.Cells["StockRealVolumen"].Value.ToString();
                           canastillaMP.UnidadMedida = row.Cells["UnidadMedida"].Value.ToString();
                           canastillaMP.nrocaja = row.Cells["nrocaja"].Value.ToString();

                           listaCanastillaMP.Add(canastillaMP);
                       }
                   }
                   if (listaCanastillaMP.Count == 0)
                   {
                       MessageBox.Show("Debe seleccionar al menos un registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       return;
                   }
                   else if (listaCanastillaMP.Count > 0)
                   {
                       this.Result = listaCanastillaMP;
                   }

                   break;
                case enmAyuda.enmOrdenTrabajo:
                    //Armar XML de detalle de la caja seleccionado 

                   string ordentrabajo = this.gridControl.CurrentRow.Cells["OrdenTrabajo"].Value.ToString();
                   string codArti = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                   string nrocaja = this.gridControl.CurrentRow.Cells["nrocaja"].Value.ToString();
                   string codAlma = this.gridControl.CurrentRow.Cells["in09codigo"].Value.ToString();
                    
                    //Este metodo trae el detalle x Nro de Caja , Articulo , Almacen
                   List<Movimiento> detalles =  DocumentoLogic.Instance.TraerDetallexNroCaja(Logueo.CodigoEmpresa,
                       codArti, nrocaja, codAlma);
                    //iniciazar arreglo
                    
                   string[] detallesxnrocaja = new string[detalles.Count];
                   x = 0;
                    //crear el xml de los detalles
                   foreach (Movimiento mov in detalles) {
                       detallesxnrocaja[x] = mov.CodigoEmpresa + "|" + mov.Anio + "|" + 
                                             mov.Mes + "|" + mov.CodigoTipoDocumento+ "|" + 
                                             mov.CodigoDocumento + "|" + mov.CodigoArticulo + "|" + 
                                             mov.Orden + "|" + mov.Cantidad + "|" +  mov.NroCaja + "|" +"";
                           
                           x++;      
                   }

                   this.Result = this.gridControl.CurrentRow.Cells["OrdenTrabajo"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["codigo"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["descripcion"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["unidadmedida"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["CanPiezas"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["almptxdefecto"].Value.ToString() + "|" +
                       
                       this.gridControl.CurrentRow.Cells["Ancho"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["Largo"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["Alto"].Value.ToString() + "|" +
                        this.gridControl.CurrentRow.Cells["CanArea"].Value.ToString() + "|"+
                        this.gridControl.CurrentRow.Cells["AreaxUni"].Value.ToString() + "|"+
                        this.gridControl.CurrentRow.Cells["nrocaja"].Value.ToString() + "|"+
                        Util.ConvertiraXMLMateriaPrima(detallesxnrocaja);
            
                   break;
                case enmAyuda.enmMotivo:
                   if (this.gridControl.CurrentRow.Cells["PRO15CODIGO"].Value != null)
                       this.Result = this.gridControl.CurrentRow.Cells["PRO15CODIGO"].Value + "|" +
                                     this.gridControl.CurrentRow.Cells["PRO15DESCRIPCION"].Value;

                   break;

                case enmAyuda.enmStockLinea:
                    

                   string[] filas;
                   GridViewRowInfo currentstocklinea = this.gridControl.CurrentRow;
                    // iniciar el valor de la longitud
                    int longitud  = 0;
                    foreach (GridViewRowInfo row in gridControl.Rows)
                    { 
                        isChecked = false;
                        valor = row.Cells["chkSelect"].Value;
                        isChecked = valor == null ? false : true;
                        if (isChecked)
                        {
                            longitud++;
                        }
                    }
                    // validar si marco un registro para almacenar sus datos en nuestro arreglo filas
                    if (longitud == 0)
                    {
                        RadMessageBox.Show("Debe seleccionar al menos un registros", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        return;
                    }
                    // asginar longitud al arreglo
                   filas = new string[longitud];
                   int filascheck = 0;
                   foreach (GridViewRowInfo row in gridControl.Rows)
                   {
                       if (currentstocklinea.Cells["chkSelect"].Value != null)
                       {
                           isChecked = false;
                           valor = row.Cells["chkSelect"].Value;
                           isChecked = valor == null ? false : true;
                            
                           if(isChecked)
                           {
                               
                               filas[filascheck] =
                                   row.Cells["IN07ORDENTRABAJO"].Value + "|" +
                                         row.Cells["CodigoAlmacen"].Value + "|" +
                                         row.Cells["AlmacenDesc"].Value + "|" +
                                         row.Cells["CodigoArticulo"].Value + "|" +
                                         row.Cells["IN01DESLAR"].Value + "|" +
                                         row.Cells["UnidadMedida"].Value + "|" +
                                         row.Cells["FechaIngresoUltima"].Value + "|" +
                                         row.Cells["Stock"].Value + "|" +
                                         row.Cells["Ancho"].Value + "|" +
                                         row.Cells["Alto"].Value + "|" +
                                         row.Cells["Largo"].Value + "|" +
                                         row.Cells["Areaxuni"].Value + "|" +
                                         row.Cells["Area"].Value + "|" +  row.Cells["NroCaja"].Value;
                               filascheck++;
                           }
                       }
                   }
                   this.Result = filas;                                                                 
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
                case enmAyuda.enmUniMedEquiv:
                    if (this.gridControl.CurrentRow.Cells["in21codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["in21codigo"].Value.ToString();
                   break;
                case enmAyuda.enmCalidadMP:
                   if (this.gridControl.CurrentRow.Cells["glo01codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["glo01codigo"].Value.ToString();
                   break;

                case enmAyuda.enmTipoCostoMP:
                   if (this.gridControl.CurrentRow.Cells["glo01codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["glo01codigo"].Value.ToString() + "|" +
                                this.gridControl.CurrentRow.Cells["glo01descripcion"].Value.ToString();
                   break;
                case enmAyuda.enmBloquesCosteo:
                   if (this.gridControl.CurrentRow.Cells["IN07CODBLOQUEEMP"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["IN07CODBLOQUEEMP"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["IN01DESLAR"].Value.ToString() + "|" +
                                this.gridControl.CurrentRow.Cells["IN07UNIMED"].Value.ToString() + "|" +
                                this.gridControl.CurrentRow.Cells["IN07CANART"].Value.ToString();
                   break;
                case enmAyuda.enmFactTransportBloques:
                   if (this.gridControl.CurrentRow.Cells["CO05TIPDOC"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["CO05TIPDOC"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["CO05NRODOC"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["CO05CODCTE"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["CO05FECHA"].Value.ToString() + "|" +
                        this.gridControl.CurrentRow.Cells["CO05MONEDA"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["importe"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["Concepto"].Value.ToString() + "|" +
                       this.gridControl.CurrentRow.Cells["ccm02nom"].Value.ToString().ToString();



                   break;

                case enmAyuda.enmOrdenCompra:
                   if (this.gridControl.CurrentRow.Cells["ccm02nom"].Value == null) return;
                   this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "ccm02nom") + "|" +
                                 Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoOrdenCompra");
                   break;
                case enmAyuda.enmMaquinaInventario:
                   if (this.gridControl.CurrentRow.Cells["In20Codigo"].Value == null) return;
                   this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "In20Codigo") + "|" +
                                Util.GetCurrentCellText(gridControl.CurrentRow, "In20Descripcion");                    
                   break;
                case enmAyuda.enmLibro:
                    if(this.gridControl.CurrentRow.Cells["ccb02cod"].Value == null) return;
                    this.Result = Util.GetCurrentCellText(gridControl.CurrentRow, "ccb02cod") + "|" +
                        Util.GetCurrentCellText(gridControl.CurrentRow, "ccb02des");
                   break;
                case enmAyuda.enmCuentaContable:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" + 
                                 Util.GetCurrentCellText(gridControl, "glo01descripcion");
                   break;
                case enmAyuda.enmEstadoInventarioFisico:
                   this.Result = Util.GetCurrentCellText(gridControl, "glo01codigo") + "|" +
                                Util.GetCurrentCellText(gridControl, "glo01descripcion");
                   break;
                default:
                    break;
            }
          
            
            this.Close();
            
        }
        void focoFiltro(enmAyuda tipoAyuda) // da el foco en la columna de filtro del formulario de busqueda
        {
            try
            {
                this.gridControl.MasterView.TableFilteringRow.Cells[1].BeginEdit(); // enfocando a la 2da columna del fromulario de busqueda
                switch (tipoAyuda) 
                {                    
                    case enmAyuda.enmCanastillasMultiplePP:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;                    
                    case enmAyuda.enmCanastillasMultipleMP:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;
                   
                    default:
                        this.gridControl.MasterView.TableFilteringRow.Cells[1].BeginEdit();
                        break;
                }
                

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
            focoFiltro(this._tipoAyuda);  
        }
        
        private void gridControl_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (_tipoAyuda == enmAyuda.enmCanastillasMultiplePP)
            {
                e.ContextMenu.Items.Clear();
                RadMenuItem itmEditar = new RadMenuItem();
                itmEditar.Name = "itmEditar";
                itmEditar.Text = "Editar";
                itmEditar.Click += new EventHandler(delegate(object r, EventArgs a)
                {
                    this.gridControl.Columns["CanPiezas"].ReadOnly = false;
                    this.gridControl.CurrentRow.Cells["CanPiezas"].BeginEdit();
                });
                e.ContextMenu.Items.Add(itmEditar);
            }
        }

        private void gridControl_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (_tipoAyuda == enmAyuda.enmCanastillasMultiplePP)
            {
                this.gridControl.Columns["CanPiezas"].ReadOnly = true;
            }
        }

        private void gridControl_CellMouseMove(object sender, MouseEventArgs e)
        {
            GridCellElement cell = this.gridControl.ElementTree.GetElementAtPoint(e.Location) as GridCellElement;
            if (cell != null && cell.Value != null)
            {

                cell.ToolTipText = Util.convertiracadena(cell.Value);
            }

        }

    }
}
