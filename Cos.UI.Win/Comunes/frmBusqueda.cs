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

namespace Cos.UI.Win
{
    public partial class frmBusqueda : frmBaseHelp
    {
        private string _codigoAlmacen = string.Empty;
        private string _PedidoVentaSeleccionado = string.Empty;
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
        public frmBusqueda(enmAyuda tipoAyuda, object parametro1, object parametro2 = null)
        {
            InitializeComponent();
            this._tipoAyuda = tipoAyuda;
            this._parametros = parametro1;
            this._parametros2 = parametro2;
            CrearColumnas(tipoAyuda);
        }
        //public frmBusqueda(enmAyuda tipoAyuda, string codigoTipDoc){
        //    InitializeComponent();
        //    this._tipoAyuda = tipoAyuda;
        //    this._codTipDocumento = codigoTipDoc;
            
        //    CrearColumnas(tipoAyuda);
        //}
        //public frmBusqueda(enmAyuda tipoAyuda, string codigoAlmacen,string pedidoventa)
        //{
        //    InitializeComponent();
        //    this._tipoAyuda = tipoAyuda;
        //    this._codigoAlmacen = codigoAlmacen;
        //    this._PedidoVentaSeleccionado = pedidoventa;            
        //    CrearColumnas(tipoAyuda);
        //}
        //public frmBusqueda(enmAyuda tipoAyuda, bool estipMovEntrada) {
        //    InitializeComponent();
        //    _esTipEntrada = estipMovEntrada;
        //    CrearColumnas(tipoAyuda);        
        //}
       
        //public frmBusqueda(enmAyuda tipoAyuda, bool estipMovEntrada, string codigoNaturaleza) {
        //    InitializeComponent();
        //    _esTipEntrada = estipMovEntrada;
        //    this._parametros = codigoNaturaleza;
        //    CrearColumnas(tipoAyuda);
        //}
        
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

            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
                //modificamos el moeto TraerTipoDocumento2 
                        this.CreateGridColumn(this.gridControl, "Código", "in12TipDoc", 0, "", 60, true, false, true);
                        this.CreateGridColumn(this.gridControl, "Descripción", "in12DesLar", 0, "", 300, true, false, true);
                        //if (_esTipEntrada == false)
                        //{
                        //    //agrego parametor de Tipo de Naturaleza -- > this._codigoAlmacen

                        var tipEntrada = ((bool)_parametros) == false ? "S" : "E";
                            var tipDocs = TipoDocumentoLogic.Instance.TraerTipoDocumento2(Logueo.CodigoEmpresa, tipEntrada, this._parametros2.ToString());
                            this.gridControl.DataSource = tipDocs;
                            
                        //}
                        //else
                        //{
                        //    //agrego parametor de Tipo de Naturaleza -- > this._codigoAlmacen
                        //    var tipDocs = TipoDocumentoLogic.Instance.TraerTipoDocumento2(Logueo.CodigoEmpresa, "E", this._parametros);
                        //    this.gridControl.DataSource = tipDocs;
                        //}
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
                          var clientes = CuentaCorrienteLogic.Instance.CuentaCorrienteTraer(Logueo.CodigoEmpresa, "01");
                          this.gridControl.DataSource = clientes;
                          this.lblTitulo.Text = "CLIENTES";
                    break;
                case enmAyuda.enmCentroCosto:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var cencos = CentroCostoLogic.Instance.TraerCentroCosto(Logueo.CodigoEmpresa,"");
                    this.gridControl.DataSource = cencos;

                    this.lblTitulo.Text = "CENTRO DE COSTOS";
                    break;
                case enmAyuda.enmResponsableReceptor:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var respReceptor = ResponsableLogic.Instance.TraerResponsable(Logueo.CodigoEmpresa, "");
                    this.gridControl.DataSource = respReceptor;

                    this.lblTitulo.Text = "RESPONSABLES";
                    break;
                case enmAyuda.enmResponsable:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var resp = ResponsableLogic.Instance.TraerResponsable(Logueo.CodigoEmpresa, "");
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
                    break;
                case enmAyuda.enmLote:
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    this.CreateGridColumn(this.gridControl, "Código", "Codigo", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "Descripcion", 0, "", 400, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Unidad de medida", "UnidadMedida", 0, "", 100, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Nro caja", "nrocaja", 0, "", 100, true, false, true);

                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 0, true, false,false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingPT", "DocingPT", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "CanPiezas", "CanPiezas",0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "CanArea", "CanArea", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "ClientePedidonro", "ClientePedidonro", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Cliente", "Cliente", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "clienteNombre", "clienteNombre", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "AreaxUni", "AreaxUni", 0, "", 50, true, false, true);


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

                case enmAyuda.enmAlmacen:
                    this.CreateGridColumn(this.gridControl, "Código", "In09codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "In09descripcion", 0, "", 300, true, false, true);
                  
                        var almacenes = AlmacenLogic.Instance.TraerAlmacen(Logueo.CodigoEmpresa, this._parametros.ToString());
                        this.gridControl.DataSource = almacenes;
                    
                                                                          
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
                        //var notas = DocumentoLogic.Instance.Spu_Inv_Trae_NotaSalida(Logueo.CodigoEmpresa);
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
                    /*
                     IN20CODEMP, IN20CODIGO, IN20DESC, IN20CODPROVEEDOR
                     */
                    this.CreateGridColumn(this.gridControl, "codigoEmpresa", "IN20CODEMP", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Codigo", "IN20CODIGO", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "IN20DESC", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridControl, "CodProv", "IN20CODPROVEEDOR", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Proveedor", "NOMPROV", 0, "", 120, true, false, true);
                    var canteras = CanterasLogic.Instance.TraerCanteras(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = canteras;
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
                case enmAyuda.enmActCtbleTipo:
                    this.CreateGridColumn(this.gridControl, "Codigo", "COS02CODIGO", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "COS02DESCRIPCION", 0, "", 150);
                    var ActiContTip = ActividadContableTipoLogic.Instance.TraerTipoActividadContable();
                    this.gridControl.DataSource = ActiContTip;
                    this.lblTitulo.Text = "TIPO ACTIVIDAD CONTABLE";
                    break;
                case enmAyuda.enmLinea:
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 50);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 250);
                    var lineas = LineaLogic.Instance.LineaTraer(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = lineas;
                    this.lblTitulo.Text = "Lineas";
                    break;
                case enmAyuda.enmActNivel1:
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 100);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 150);
                    this.CreateGridColumn(gridControl, "Almacen", "codigoAlmacen", 0, "", 100, true, false, false);
                    this.CreateGridColumn(gridControl, "Alm:Defecto", "almacenxdefecto", 0, "", 100, true, false, false);
                    var actividad1 = ActividadNivel1Logic.Instance.ActividadNivel1Traer(Logueo.CodigoEmpresa, this._parametros.ToString());
                    //var actividad1 = ActividadNivel1Logic.Instance.ActividadNivel1Traer(Logueo.CodigoEmpresa, this.parametros.ToString());
                    this.gridControl.DataSource = actividad1;
                    this.lblTitulo.Text = "Actividades De Produccion";
                    break;
                case enmAyuda.enmActCtble:
                    this.CreateGridColumn(gridControl, "Codigo", "COS01CODIGO", 0, "", 70);
                     this.CreateGridColumn(gridControl, "Descripcion", "COS01DESCRIPCION", 0, "", 120);
                     //var ActContables = ActividadesContableLogic.Instance.TraerActividadesContables(Logueo.CodigoEmpresa);
                     var ActContables = ActividadesContableLogic.Instance.TraerActCtblxTipo(Logueo.CodigoEmpresa, "01");
                     this.gridControl.DataSource = ActContables;
                     this.lblTitulo.Text = "Actividades Contables";
                    break;
                default:
                    break;
            }

        }
        protected override void OnAceptar()
        {
            if (this.gridControl.RowCount == 0) return;
            
            this.Result = string.Empty;
            CuentaCorriente cuenta = new CuentaCorriente();
            Canteras cantera = new Canteras();
            TipoAnalisis tipana = new TipoAnalisis();
            TipoTransaccion transaccion = new TipoTransaccion();
            Proveedor materiaPrima = new Proveedor();
            switch (this._tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
                    if (this.gridControl.CurrentRow.Cells["in12TipDoc"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["in12TipDoc"].Value.ToString();
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
                    break;
                case enmAyuda.enmLote:
                    break;
                    
                case enmAyuda.enmProductoXAlmacen:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;

                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["DocingAA"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["DocingMM"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["DocingTD"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["DocingCD"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["DocingPT"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["DocingNO"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["CanPiezas"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["CanArea"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["nrocaja"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["Cliente"].Value.ToString() + "/" + 
                                    this.gridControl.CurrentRow.Cells["clienteNombre"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["ClientePedidonro"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["AreaxUni"].Value.ToString();
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
                case enmAyuda.enmPedVentIng:
                    if (this.gridControl.CurrentRow.Cells["come01pedvennum"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["come01pedvennum"].Value.ToString();
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
                    //this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
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
                    cuenta = new CuentaCorriente();
                    cuenta.ccm02cod = gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();
                    cuenta.ccm02nom = gridControl.CurrentRow.Cells["ccm02nom"].Value.ToString();
                    this.Result = cuenta;
                    //  this.CreateGridColumn(this.gridControl, "Codigo", "ccm02cod", 0, "", 50, true, false, true);
                    //this.CreateGridColumn(this.gridControl, "Nombre", "ccm02nom", 0, "", 50, true, false, true);
                    

                   break;
                case enmAyuda.enmCantera:
                   if (this.gridControl.CurrentRow.Cells["IN20CODIGO"].Value == null) return;
                   cantera = new Canteras();

                   cantera.IN20CODEMP = gridControl.CurrentRow.Cells["IN20CODEMP"].Value.ToString();
                   cantera.IN20CODIGO = gridControl.CurrentRow.Cells["IN20CODIGO"].Value.ToString();
                   cantera.IN20DESC = gridControl.CurrentRow.Cells["IN20DESC"].Value.ToString();
                   cantera.IN20CODPROVEEDOR = gridControl.CurrentRow.Cells["IN20CODPROVEEDOR"].Value.ToString();
                   this.Result = cantera;
                   /*
                      this.CreateGridColumn(this.gridControl, "codigoEmpresa", "IN20CODEMP", 0, "", 50, true, false, false);
                   this.CreateGridColumn(this.gridControl, "Codigo", "IN20CODIGO", 0, "", 50, true, false, true);
                   this.CreateGridColumn(this.gridControl, "Descripcion", "IN20DESC", 0, "", 50, true, false, true);
                   this.CreateGridColumn(this.gridControl, "CodProv", "IN20CODPROVEEDOR", 0, "", 50, true, false, false);
                    */
                  
                   break;
                case enmAyuda.enmCuentaCorriente:
                   if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                   tipana.Codigo = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                   tipana.Descripcion = this.gridControl.CurrentRow.Cells["Descripcion"].Value.ToString();
                   this.Result = tipana;
                   break;
                case enmAyuda.enmNaturaleza:
                   if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                   break;
                case enmAyuda.enmActCtbleTipo:
                   if (this.gridControl.CurrentRow.Cells["COS02CODIGO"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["COS02CODIGO"].Value.ToString();
                   break;
                case enmAyuda.enmLinea:
                   if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    //this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 50);
                    //this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 250);
                   break;
                case enmAyuda.enmActNivel1:
                   if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                   //this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 100);
                   break;
                case enmAyuda.enmActCtble:
                   if (this.gridControl.CurrentRow.Cells["COS01CODIGO"].Value == null) return;
                   this.Result = this.gridControl.CurrentRow.Cells["COS01CODIGO"].Value.ToString();
                     //this.CreateGridColumn(gridControl, "Codigo", "COS01CODIGO", 0, "", 70);
                     //this.CreateGridColumn(gridControl, "Descripcion", "COS01DESCRIPCION ", 0, "", 120);
                   break;
                default:
                    break;
            }

            this.Close();
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

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            
            //if (e.KeyValue == (char)Keys.Enter) {
            //    if (gridControl.Rows.Count == 0) return;
            //    OnAceptar();
            //}
        }

    }
}
