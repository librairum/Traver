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
namespace Prod.UI.Win.Comunes
{
    public partial class frmBusqueda : frmBaseHelp
    {
        private int _positionX = 0;
        private int _positionY = 0;
        
        
        public object parametros { get; set; }
        public object parametros2 { get; set; }

        public frmBusqueda()
        {
            InitializeComponent();
        }
        private enmAyuda _tipoAyuda;
        private string codAlmacen = "";
        
        public frmBusqueda(enmAyuda tipoAyuda,int positionX = 0  ,
            int positionY = 0 )
        {

        InitializeComponent();
        this._tipoAyuda = tipoAyuda;
        this._positionX = positionX;
        this._positionY = positionY;
            /*codigo para traer el producto por almacen */               
        this.CrearColumnas(this._tipoAyuda);        
        }
        public frmBusqueda(enmAyuda tipoAyuda, object parametro , object parametro2 = null ,int ancho=644,int alto=474)
        {
            InitializeComponent();
            this.codAlmacen = parametro.ToString();
            this.parametros = parametro;
            this.parametros2 = parametro2;
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
            this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.gridControl.AutoGenerateColumns = false;
                        
            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:

                    this.CreateGridColumn(this.gridControl, "Código", "in12TipDoc", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "in12DesLar", 0, "", 300, true, false, true);
                    var tipDocs = TipoDocumentoLogic.Instance.TraerTipoDocumento2(Logueo.CodigoEmpresa, parametros.ToString(), Logueo.PP_codnaturaleza);
                    this.gridControl.DataSource = tipDocs;
                    this.lblTitulo.Text = "TIPOS DE DOCUMENTO";
                    break;
                case enmAyuda.enmTipoDocumentoAll:
                    this.CreateGridColumn(this.gridControl, "Código", "in12TipDoc", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "in12DesLar", 0, "", 300, true, false, true);
                    var tipdosDocumentos = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = tipdosDocumentos;
                    break;
                case enmAyuda.enmTransaccion:
                    this.CreateGridColumn(this.gridControl, "Código", "in15Codigo", 0, "", 60, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripción", "in15Descripcion", 0, "", 300, true, false, true);

                    var tipTrans = TipoTransaccionLogic.Instance.TraerTipoTransaccion1(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = tipTrans;

                    this.lblTitulo.Text = "TRANSACCIONES";
                    break;
                case enmAyuda.enmAlmacen:
                    this.CreateGridColumn(gridControl, "Codigo", "In09codigo", 0, "", 50);
                    this.CreateGridColumn(gridControl, "Descripcion", "In09descripcion", 0, "", 50);
                    
                    var almacenes = AlmacenLogic.Instance.AlmacenTraer(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = almacenes;
                    this.lblTitulo.Text = "Almacenes";
                    break;
                    
                case enmAyuda.enmAlmacenxlineaxactividad:
                    this.CreateGridColumn(gridControl, "Codigo", "In09codigo", 0, "", 50);
                    this.CreateGridColumn(gridControl, "Descripcion", "In09descripcion", 0, "", 50);

                    var almacenesxlineaxactividad = AlmacenLogic.Instance.traerAlmacenXLineaXActividad(Logueo.CodigoEmpresa, parametros.ToString(), parametros2.ToString());
                    this.gridControl.DataSource = almacenesxlineaxactividad;
                    this.lblTitulo.Text = "Almacenes x linea x actividad";
                    break;
                    
                case enmAyuda.enmAlmacenxNaturaleza:
                    this.CreateGridColumn(gridControl, "Codigo", "In09codigo", 0, "", 50);
                    this.CreateGridColumn(gridControl, "Descripcion", "In09descripcion", 0, "", 50);
                    var almxNaturaleza = AlmacenLogic.Instance.TraerAlmacen(Logueo.CodigoEmpresa, parametros.ToString());
                    this.gridControl.DataSource = almxNaturaleza;
                    this.lblTitulo.Text = "Almacenes";
                    break;
                case enmAyuda.enmLinea:
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 50);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 250);
                    var lineas = LineaLogic.Instance.LineaTraer(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = lineas;
                    this.lblTitulo.Text = "Lineas";
                    break;
                case enmAyuda.enmActividadNivel1:
                    //this.CreateGridColumn(gridControl, "Empresa", "codigoEmpresa", 0, "", 50, true, false, false);
                    //this.CreateGridColumn(gridControl, "Linea", "codigoLinea", 0, "", 1000);
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 100);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcion", 0, "", 150);
                    this.CreateGridColumn(gridControl, "Almacen", "codigoAlmacen", 0, "", 100, true, false, false);
                    this.CreateGridColumn(gridControl, "Alm:Defecto", "almacenxdefecto", 0, "", 100, true, false, false);
                    var actividad1 = ActividadNivel1Logic.Instance.ActividadNivel1Traer(Logueo.CodigoEmpresa, this.parametros.ToString());
                    this.gridControl.DataSource = actividad1;
                    this.lblTitulo.Text = "Actividad Nivel 1";
                    break;
                //PRO08COD	PRO08DESC
                case enmAyuda.enmTurnos:
                    //PRO12CODEMP , PRO12COD , PRO12DESC  from PRO12TURNOS where   
                    this.CreateGridColumn(gridControl, "Empresa", "codigoEmpresa", 0, "", 50, true, false, false);
                    this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 150);
                    this.CreateGridColumn(gridControl, "Descripcion", "descripcioncompleto", 0, "", 200);
                    var turno = TurnosLogic.Instance.TurnosListar(Logueo.CodigoEmpresa);
                    this.gridControl.DataSource = turno;
                    this.lblTitulo.Text = "Turnos";
                    break;
                case enmAyuda.enmProducObjetivo:
                    this.CreateGridColumn(this.gridControl, "Codigo", "codigo", 0, "", 40, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "descripcion", 0, "", 50, true, false, true);
                    this.gridControl.DataSource = ArticuloLogic.Instance.TraerArticuloXAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.parametros.ToString());
                    this.lblTitulo.Text = "Producto";
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    this.CreateGridColumn(this.gridControl, "Codigo", "Codigo", 0, "", 50);
                    this.CreateGridColumn(this.gridControl, "Descripcion Corta", "ProductoDescBreve", 0, "", 200);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "Descripcion", 0, "", 250);
                    this.CreateGridColumn(this.gridControl, "Unidad", "UnidadMedida", 0, "", 70);
                    this.gridControl.DataSource = ArticuloLogic.Instance.TraerArticuloXAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.parametros.ToString());
                    this.lblTitulo.Text = "Articulo x Almacen";
                    break;
                case enmAyuda.enmMaquina:
                    this.CreateGridColumn(this.gridControl, "Codigo", "codigo", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "descripcion", 0, "", 150);
                    this.gridControl.DataSource = MaquinaLogic.Instance.MaquinaTraer(Logueo.CodigoEmpresa);
                    this.lblTitulo.Text = "Maquinas";
                    break;
                case enmAyuda.enmCanastillasMultiple:
                    this.CreateGridColumn(this.gridControl, "Canastilla", "nrocaja", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Almacen", "in09descripcion", 0, "", 70);
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
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingPT", "DocingPT", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Orden", "Orden", 0, "", 70, true, false, false);

                    var listaCanastilla = DocumentoLogic.Instance.TraerCanastillaMP(Logueo.CodigoEmpresa, this.codAlmacen);
                    this.gridControl.DataSource = listaCanastilla;
                    

                    this.lblTitulo.Text = "Canastillas";
                    break;
                case enmAyuda.enmMateriaPrimaMultiple:
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
                    this.gridControl.DataSource = DocumentoLogic.Instance.TraerMateriaPrimaTodos(Logueo.CodigoEmpresa, this.parametros.ToString());
                    this.lblTitulo.Text = "Materia Prima";
                    break;
                case enmAyuda.enmCanastillas:
                     this.CreateGridColumn(this.gridControl, "Canastilla", "nrocaja", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Almacen", "in09descripcion", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Producto Cod", "codigo", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "producto Desc", "descripcion", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Uni Med", "unidadmedida", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Cantidad", "CanPiezas", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "Ancho", "PPAncho", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Largo", "PPLargo", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Espesor", "PPEspesor", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Area(M2)", "CanArea", 0, "{0:###,###0.00}", 100);                    
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingPT", "DocingPT", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Largo", "Largo", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Ancho", "Ancho", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Alto", "Alto", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Orden", "Orden", 0, "", 70, true, false, false);
                    
                    this.gridControl.DataSource = DocumentoLogic.Instance.TraerCanastillaMP(Logueo.CodigoEmpresa, this.codAlmacen);
                    this.lblTitulo.Text = "Canastillas";
                    break;
                case enmAyuda.enmMateriaPrima:
                     this.CreateGridColumn(this.gridControl, "Canastilla", "nrocaja", 0, "", 120);
                    this.CreateGridColumn(this.gridControl, "Almacen", "IN09CODIGO", 0, "", 70, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Producto", "CodigoProducto", 0, "", 120);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "descripcion", 0, "", 180);
                    this.CreateGridColumn(this.gridControl, "Unidad", "UnidadMedida", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Volumen", "StockRealVolumen", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "ancho", "MPAncho", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "alto", "MPAlto", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "largo", "MPlargo", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMP", "DocingMP", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 50, true, false, false);                    
                    this.gridControl.DataSource = DocumentoLogic.Instance.TraerMateriaPrimaTodos(Logueo.CodigoEmpresa, this.parametros.ToString());
                    this.lblTitulo.Text = "Materia Prima";
                    break;
                case enmAyuda.enmOperador:
                    this.CreateGridColumn(this.gridControl, "ccm02emp", "ccm02emp", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "ccm02tipana", "ccm02tipana", 0, "", 102, true, false, false);
                    this.CreateGridColumn(this.gridControl, "ccm02cod", "ccm02cod", 0, "", 90);
                    this.CreateGridColumn(this.gridControl, "ccm02nom", "ccm02nom", 0, "", 150);

                    var operadores = CuentaCorrienteLogic.Instance.Glo_Traer_CuentasCorrientes(Logueo.CodigoEmpresa, "14", "ccm02cod");
                    this.gridControl.DataSource = operadores;
                    this.lblTitulo.Text = "Operadores";
                    break;
                case enmAyuda.enmCanastillasMultiplePP:
                    //Esta region es visible para el usuario
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
                    // Control de check para seleccion multiple por el usuario.
                    this.CreateGridChkColumn(this.gridControl, "chkSelect", "chkSelect", 0, "", 50, false, true, true);

                    // Columnas con datos ocultos para generar mi xml del detalle del movimiento agrupado.
                    this.CreateGridColumn(this.gridControl, "Largo", "Largo", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Ancho", "Ancho", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Alto", "Alto", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 100, true, false, false);
                    
                    this.CreateGridColumn(this.gridControl, "DocingPT", "DocingPT", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Orden", "Orden", 0, "", 70, true, false, false);

                    listaCanastilla = DocumentoLogic.Instance.TraerCanastillaMP(Logueo.CodigoEmpresa, this.parametros.ToString());
                    this.gridControl.DataSource = listaCanastilla;
                    this.lblTitulo.Text = "Canastillas";
                    break;
                case enmAyuda.enmCanastMultiPPResumido:
                     this.CreateGridColumn(this.gridControl, "Fec.Ingreso", "FechaIngresoUltimo", 0, "{0:dd/MM/yyyy}", 120);
                    this.CreateGridColumn(this.gridControl, "Fec.Ingreso", "FechaIngresoUltimotexto", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "CodEmpresa", "Empresa", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Anio", "Anio", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Mes", "Mes", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Tip.Doc", "CodTipDoc", 0, "", 0, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Hora Salida", "HoraSalida", 0, "{0:##:##}", 70);
                    this.CreateGridColumn(this.gridControl, "Transancion", "TransaDesc", 0, "", 120);
                    this.CreateGridColumn(this.gridControl, "N° Doc.", "DocumentoCodigo", 0, "", 150, true, false, true);
                    this.CreateGridColumn(this.gridControl, "N° OT", "NroOrdenTrabajo", 0, "", 80);                    
                    this.CreateGridColumn(this.gridControl, "Canastilla", "nrocaja", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Almacen Cod", "AlmacenCodigo", 0, "", 100, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Almacen Desc", "AlmacenDescripcion", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Producto Cod", "ProductoCodigo", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "producto Desc", "ProductoDescripcion", 0, "", 100);
                    this.CreateGridColumn(this.gridControl, "Uni Med", "unidadmedida", 0, "", 50);
                    this.CreateGridColumn(this.gridControl, "Cantidad", "CanPiezas", 0, "{0:###,###0.00}", 100);
                    this.CreateGridColumn(this.gridControl, "Ancho", "Ancho", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Largo", "Largo", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Espesor", "Alto", 0, "{0:###,###0.00}", 70);
                    this.CreateGridColumn(this.gridControl, "Area(M2)", "CanArea", 0, "{0:###,###0.00}", 100);
                    // Control de check para seleccion multiple por el usuario.
                    this.CreateGridChkColumn(this.gridControl, "chkSelect", "chkSelect", 0, "", 50, false, true, true);

                    // Columnas con datos ocultos para generar mi xml del detalle del movimiento agrupado.                                                           
                    this.gridControl.DataSource =  DocumentoLogic.Instance.TraerAyudaPPResumido(Logueo.CodigoEmpresa, this.parametros.ToString());
                    
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
                    //Campos ocultos para usar en la generacion del xml detalle de cada movimiento 
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMP", "DocingMP", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 50, true, false, false);
                    this.gridControl.DataSource = DocumentoLogic.Instance.TraerMateriaPrimaTodos(Logueo.CodigoEmpresa, this.parametros.ToString());
                    this.lblTitulo.Text = "Materia Prima";
                    break;

                case enmAyuda.enmCanastillasMultipleMPConParametros:
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
                    //Campos ocultos para usar en la generacion del xml detalle de cada movimiento 
                    this.CreateGridColumn(this.gridControl, "DocingAA", "DocingAA", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMM", "DocingMM", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingTD", "DocingTD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingCD", "DocingCD", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingMP", "DocingMP", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "DocingNO", "DocingNO", 0, "", 50, true, false, false);

                    string[] datos;
                    datos = this.parametros.ToString().Split('|');
                    this.gridControl.DataSource =  DocumentoLogic.Instance.TraeMateriaPrimaFiltrado(Logueo.CodigoEmpresa, 
                                                                                            datos[0], datos[1], datos[2]);
                    this.lblTitulo.Text = "Materia Prima";
                    break;
                case enmAyuda.enmCanastMultiMPResumido:
                    break;
                case enmAyuda.enmActividadesRelacionadas:

                    this.CreateGridColumn(this.gridControl, "codigoLinea", "codigoLinea", 0, "", 50, true, false, false);
                    this.CreateGridColumn(this.gridControl, "codigo", "Codigo", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "descripcion", "Descripcion", 0, "", 120);
                    this.gridControl.DataSource = ActividadNivel1Logic.Instance.TraerActividadRelacionada(Logueo.CodigoEmpresa);
                    this.lblTitulo.Text = "Actividades Relacionadas";
                    break;
                case enmAyuda.enmMaquinaxLineaActividad:

                    this.CreateGridColumn(this.gridControl, "codigoEmpresa", "codigoEmpresa", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "codigo", "Codigo", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "descripcion", "Descripcion", 0, "", 120);
                    this.gridControl.DataSource = MaquinaLogic.Instance.TraerMaquinaxLineaActividad(Logueo.CodigoEmpresa, this.parametros.ToString());
                    this.lblTitulo.Text = "Maquina x Activi y Linea";

                    break;
                case enmAyuda.enmMotivoHoraMuerta:
                    this.CreateGridColumn(this.gridControl, "PRO01CODEMP", "PRO01CODEMP", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Codigo", "PRO01CODIGO", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "PRO01DESCRIPCION", 0, "", 120, true, false, true);
                    MotivoHoraMuerta mhm = new MotivoHoraMuerta();
                    mhm.PRO01CODEMP = Logueo.CodigoEmpresa;
                    this.gridControl.DataSource = MotivoHoraMuertaLogic.Instance.TraerMotivoHoraMuesta(mhm, "*");
                    this.lblTitulo.Text = "Motivos de Hora Muerta";
                    break;
                    
                case enmAyuda.enmProductoxColorFormat:
                     this.CreateGridColumn(this.gridControl, "Codigo", "Codigo", 0, "", 30);
                    this.CreateGridColumn(this.gridControl, "Descripcion Corta", "ProductoDescBreve", 0, "", 160);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "Descripcion", 0, "", 250, false, false, false);
                    this.CreateGridColumn(this.gridControl, "Unidad", "UnidadMedida", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Color", "Color", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Formato", "Formato", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Acabado", "Acabado", 0, "", 70);           

                    codAlmacen = this.parametros.ToString();
                    string codArtiAnterior = this.parametros2.ToString();

                    this.gridControl.DataSource =  ArticuloLogic.Instance.TraerAyudaxColorFormat(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                                            Logueo.Mes, codAlmacen, codArtiAnterior);                 
                    this.lblTitulo.Text = "Productos x Color x Formato x Acabado";
                    break;
                case enmAyuda.enmMotivo:                                                                    
                    this.CreateGridColumn(this.gridControl, "Empresa", "PRO15CODEMP", 0, "", 30, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Codigo", "PRO15CODIGO", 0, "", 70);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "PRO15DESCRIPCION", 0, "", 120);
                    this.gridControl.DataSource = MotivoLogic.Instance.TraerLista(Logueo.CodigoEmpresa);
                    break;
                case enmAyuda.enmOrdenTrabajoTipo:
                    this.CreateGridColumn(this.gridControl, "Empresa", "PRO01CODEMP", 0, "", 70, true, false, false);
                    this.CreateGridColumn(this.gridControl, "Codigo", "PRO01CODIGO", 0, "", 70, true, false, true);
                    this.CreateGridColumn(this.gridControl, "Descripcion", "PRO01DESCRIPCION", 0, "", 150, true, false, true);
                    this.gridControl.DataSource = OrdenTrabajoLogic.Instance.TraerOrdenTrabajoTipo(Logueo.CodigoEmpresa, "");
                    break;
                default:
                    break;
            }
        }
        //Asigno el foco de filtro en la region de busqueda de la ventana de busqueda, segun el tipo de ayuda
        void focoFiltro(enmAyuda tipoAyuda)
        {
            try
            {
                switch (tipoAyuda)
                {
                    case enmAyuda.enmCanastillas:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;
                    case enmAyuda.enmCanastillasMultiple:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;
                    case enmAyuda.enmMateriaPrima:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;
                    case enmAyuda.enmCanastillasMultipleMP:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;
                    case enmAyuda.enmCanastillasMultiplePP:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;
                    case enmAyuda.enmOperador:
                        this.gridControl.MasterView.TableFilteringRow.Cells["ccm02nom"].BeginEdit();
                        break;
                    case enmAyuda.enmCanastMultiPPResumido:
                        this.gridControl.MasterView.TableFilteringRow.Cells["nrocaja"].BeginEdit();
                        break;
                    case enmAyuda.enmCanastillasMultipleMPConParametros:
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
        
        protected override void OnAceptar()
        {
            if (this.gridControl.RowCount == 0) return;
            this.Result = string.Empty;
            Articulo art = new Articulo();
            Maquina maquina = new Maquina();
            ArticuloResponse artRes = new ArticuloResponse();
            Spu_Pro_Trae_PPStock canastilla = new Spu_Pro_Trae_PPStock();
            List<Spu_Pro_Trae_PPStock> listaCanastilla = new List<Spu_Pro_Trae_PPStock>();

            Spu_Inv_Trae_StockDetMPTodos canastillaMP= new Spu_Inv_Trae_StockDetMPTodos();
            List<Spu_Inv_Trae_StockDetMPTodos> listaCanastillaMP = new List<Spu_Inv_Trae_StockDetMPTodos>();

            Spu_Pro_Trae_MPResumida PPResumido = new Spu_Pro_Trae_MPResumida();
            List<Spu_Pro_Trae_MPResumida> listaPPResumida = new List<Spu_Pro_Trae_MPResumida>();
            switch (this._tipoAyuda) {

                case enmAyuda.enmTipoDocumento:
                    if (this.gridControl.CurrentRow.Cells["in12TipDoc"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["in12TipDoc"].Value.ToString();
                    break;
                case enmAyuda.enmTransaccion:
                    if (this.gridControl.CurrentRow.Cells["in15Codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["in15Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmAlmacen:
                    if (this.gridControl.CurrentRow.Cells["In09codigo"].Value == null) return;                    
                    this.Result = this.gridControl.CurrentRow.Cells["In09codigo"].Value.ToString();;
                 
                    break;
                case enmAyuda.enmAlmacenxlineaxactividad:
                    if (this.gridControl.CurrentRow.Cells["In09codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["In09codigo"].Value.ToString(); ;

                    break;
                case enmAyuda.enmAlmacenxNaturaleza:
                    if (this.gridControl.CurrentRow.Cells["In09codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["In09codigo"].Value.ToString();
                    break;
                case enmAyuda.enmLinea:
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();;
                    break;
                case enmAyuda.enmActividadNivel1:
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                    ActividadNivel1 actividad1 = new ActividadNivel1();                 
                    this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    break;
                case enmAyuda.enmTurnos:
                    //this.CreateGridColumn(gridControl, "Codigo", "codigo", 0, "", 150);
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                    Turnos turno = new Turnos();                    
                    this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    break;
                case enmAyuda.enmProducObjetivo:                                        
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;
                    art.IN01KEY = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    art.IN01DESLAR = this.gridControl.CurrentRow.Cells["descripcion"].Value.ToString();
                    this.Result = art;
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value == null) return;                 
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["Descripcion"].Value.ToString() + "/" +
                                    this.gridControl.CurrentRow.Cells["UnidadMedida"].Value.ToString();
                    break;
                case enmAyuda.enmMaquina:
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value == null) return;                 
                    this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    break;                
                case enmAyuda.enmCanastillas:
                    if (this.gridControl.CurrentRow.Cells["nrocaja"].Value == null) return;
                     canastilla = new Spu_Pro_Trae_PPStock();
                        canastilla.DocingAA = this.gridControl.CurrentRow.Cells["DocingAA"].Value.ToString();
                        canastilla.DocingMM = this.gridControl.CurrentRow.Cells["DocingMM"].Value.ToString();
                        canastilla.DocingTD = this.gridControl.CurrentRow.Cells["DocingTD"].Value.ToString();
                        canastilla.DocingCD = this.gridControl.CurrentRow.Cells["DocingCD"].Value.ToString();
                        canastilla.DocingPT = this.gridControl.CurrentRow.Cells["DocingPT"].Value.ToString();
                        canastilla.descripcion = this.gridControl.CurrentRow.Cells["descripcion"].Value.ToString();                    
                        canastilla.DocingNO = this.gridControl.CurrentRow.Cells["DocingNO"].Value.ToString();
                        canastilla.CanPiezas = this.gridControl.CurrentRow.Cells["CanPiezas"].Value.ToString();
                        canastilla.Largo = Convert.ToDouble(this.gridControl.CurrentRow.Cells["Largo"].Value);
                        canastilla.Ancho = Convert.ToDouble(this.gridControl.CurrentRow.Cells["Ancho"].Value);
                        canastilla.Alto = Convert.ToDouble(this.gridControl.CurrentRow.Cells["Alto"].Value);
                        canastilla.PPAncho = Convert.ToDouble(this.gridControl.CurrentRow.Cells["PPAncho"].Value);
                        canastilla.PPLargo = Convert.ToDouble(this.gridControl.CurrentRow.Cells["PPLargo"].Value);
                        canastilla.PPEspesor = Convert.ToDouble(this.gridControl.CurrentRow.Cells["PPEspesor"].Value);
                        canastilla.nrocaja = this.gridControl.CurrentRow.Cells["nrocaja"].Value.ToString();
                        canastilla.unidadmedida = this.gridControl.CurrentRow.Cells["unidadmedida"].Value.ToString();
                        this.Result = canastilla;
                    break;
                case enmAyuda.enmMateriaPrima:
                    if (this.gridControl.CurrentRow.Cells["nrocaja"].Value == null) return;
                    canastillaMP = new Spu_Inv_Trae_StockDetMPTodos();
                             canastillaMP.DocingAA = this.gridControl.CurrentRow.Cells["DocingAA"].Value.ToString();
                             canastillaMP.DocingMM = this.gridControl.CurrentRow.Cells["DocingMM"].Value.ToString();
                             canastillaMP.DocingTD = this.gridControl.CurrentRow.Cells["DocingTD"].Value.ToString();
                             canastillaMP.DocingCD = this.gridControl.CurrentRow.Cells["DocingCD"].Value.ToString();
                             canastillaMP.DocingMP = this.gridControl.CurrentRow.Cells["DocingMP"].Value.ToString();
                             canastillaMP.descripcion = this.gridControl.CurrentRow.Cells["descripcion"].Value.ToString();
                             canastillaMP.DocingNO = this.gridControl.CurrentRow.Cells["DocingNO"].Value.ToString();
                             canastillaMP.MPlargo = this.gridControl.CurrentRow.Cells["MPlargo"].Value.ToString();
                             canastillaMP.MPAlto = this.gridControl.CurrentRow.Cells["MPAlto"].Value.ToString();
                             canastillaMP.MPAncho = this.gridControl.CurrentRow.Cells["MPAncho"].Value.ToString();
                             canastillaMP.StockRealVolumen = this.gridControl.CurrentRow.Cells["StockRealVolumen"].Value.ToString();
                             canastillaMP.UnidadMedida = this.gridControl.CurrentRow.Cells["UnidadMedida"].Value.ToString();
                             canastillaMP.nrocaja = this.gridControl.CurrentRow.Cells["nrocaja"].Value.ToString();
                             this.Result = canastillaMP;
                    break;
                case enmAyuda.enmOperador:
                    if (this.gridControl.CurrentRow.Cells["ccm02cod"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["ccm02cod"].Value.ToString();                    
                    break;
                case  enmAyuda.enmTipoDocumentoAll:
                    if (this.gridControl.CurrentRow.Cells["in12TipDoc"].Value == null) return;
                    this.Result = this.gridControl.CurrentRow.Cells["in12TipDoc"].Value.ToString();
                    break;
                /*----------------------------------------CANASTILLAS MULTIPLE PRODUCTO EN PROCESO----------------------------------------------------------------------*/
                case enmAyuda.enmCanastillasMultiplePP:
                    if (this.gridControl.CurrentRow.Cells["nrocaja"].Value == null) return;
                    //int x = 0;                    

                    foreach (GridViewRowInfo row in gridControl.Rows)
                    {
                        bool isChecked = false;
                        var valor = row.Cells["chkSelect"].Value;
                        isChecked = Util.convertiracadena(valor) == "" ? false : true;                        
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
                    if (listaCanastilla.Count == 0)
                    {
                        MessageBox.Show("Debe seleccionar al menos un registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (listaCanastilla.Count > 0)
                    {
                        string[] registros = new string[listaCanastilla.Count];
                        int x = 0;
                        //Armar Xml
                        foreach (Spu_Pro_Trae_PPStock fila in listaCanastilla)
                        {
                            registros[x] = Logueo.CodigoEmpresa + "|" + fila.DocingAA + "|" +
                                            fila.DocingMM + "|" + fila.DocingTD + "|" + 
                                           fila.DocingCD + "|" + fila.DocingPT + "|" +
                                           fila.DocingNO + "|" +  fila.CanPiezas + "|" + 
                                           fila.OrdenTrabajo +  fila.nrocaja + fila.FechaIngresoUltimotexto + fila.HoraSalida + 
                                           "|" + "";
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

                    }
                    break;
                /*----------------------------------------CANASTILLAS MULTIPLE PRODUCTO EN PROCESO RESUMIDO----------------------------------------------------------------*/
                case enmAyuda.enmCanastMultiPPResumido:
                    
                    

                        foreach(GridViewRowInfo row in gridControl.Rows)
	                    {		
		                    bool isChecked = false;
		                    object value = row.Cells["chkSelect"].Value;


                            if (Util.convertiracadena(value) == "" )
                            {
                                isChecked = false;
                            }
                            else if (Util.convertiracadena(value) != "" &&
                                 ( Util.convertiracadena(value).ToUpper() == "TRUE" ||
                                   Util.convertiracadena(value).ToUpper() == "ON"))
                            {
                                isChecked = true;
                            }
		                    //isChecked = Util.convertiracadena(value) == "" ? false : true;
                            double area = 0;
		                    if(isChecked)
		                    {

                                area = Convert.ToDouble(row.Cells["CanArea"].Value);
                                if (area < 0)
                                {
                                    Util.ShowAlert("No puede seleccionar stock negativo");
                                    return;
                                }
                                PPResumido = new Spu_Pro_Trae_MPResumida();

                                PPResumido.Empresa = row.Cells["Empresa"].Value.ToString();                                    
                                PPResumido.Anio = row.Cells["Anio"].Value.ToString();
                                PPResumido.Mes = row.Cells["Mes"].Value.ToString();
                                PPResumido.CodTipDoc = row.Cells["CodTipDoc"].Value.ToString();
                                PPResumido.DocumentoCodigo = row.Cells["DocumentoCodigo"].Value.ToString();
                                PPResumido.NroOrdenTrabajo = row.Cells["NroOrdenTrabajo"].Value.ToString();
                                PPResumido.AlmacenCodigo = row.Cells["AlmacenCodigo"].Value.ToString();
                                PPResumido.ProductoCodigo = row.Cells["ProductoCodigo"].Value.ToString();
                                PPResumido.nrocaja = row.Cells["nrocaja"].Value.ToString();
                                PPResumido.HoraSalida = row.Cells["HoraSalida"].Value.ToString();
                                listaPPResumida.Add(PPResumido);
                          
                            }		
	                    }
                        if (listaPPResumida.Count == 0)
                        {		
			                        MessageBox.Show("Debe seleccionar al menos un registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
			                        return;

                            }
                            else if (listaPPResumida.Count > 0) 
                             {
                                 string[] registros = new string[listaPPResumida.Count];
			                        int x = 0;
                                    foreach (Spu_Pro_Trae_MPResumida fila in listaPPResumida)
			                        {
                                        registros[x] = fila.Empresa + "|" + fila.Anio + "|" +
                                                        fila.Mes + "|" + fila.CodTipDoc + "|" +
                                                        fila.DocumentoCodigo + "|" + fila.ProductoCodigo + "|" + 
                                                        fila.nrocaja + "|" + fila.HoraSalida;
					                        x++;
			                        }
                                    this.Result = listaPPResumida;
		                     }
                            
                    break;
                case enmAyuda.enmCanastillasMultipleMP:

                    if (this.gridControl.CurrentRow.Cells["nrocaja"].Value == null) return;
                    
                    foreach (GridViewRowInfo row in gridControl.Rows)
                    {
                        bool isChecked = false;
                        object valor = row.Cells["chkSelect"].Value;

                        if (Util.convertiracadena(valor) == "" )
                        {
                            isChecked = false;
                        }
                        else if (Util.convertiracadena(valor) != "" && 
                                 (Util.convertiracadena(valor).ToUpper()  == "TRUE" || 
                                   Util.convertiracadena(valor).ToUpper() == "ON") )
                        {
                            isChecked = true;
                        }
                       
                       // isChecked = valor == null ? false : true;
                        double area = 0;
                        if (isChecked)
                        {
                            area = Convert.ToDouble(row.Cells["StockRealVolumen"].Value);
                            if (area < 0)
                            {
                                Util.ShowAlert("No puede seleccionar stock negativo");
                                return;                                
                            }
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

                case enmAyuda.enmCanastillasMultipleMPConParametros:

                    if (this.gridControl.CurrentRow.Cells["nrocaja"].Value == null) return;

                    foreach (GridViewRowInfo row in gridControl.Rows)
                    {
                        bool isChecked = false;
                        object valor = row.Cells["chkSelect"].Value;

                        if (Util.convertiracadena(valor) == "")
                        {
                            isChecked = false;
                        }
                        else if (Util.convertiracadena(valor) != "" &&
                                 (Util.convertiracadena(valor).ToUpper() == "TRUE" ||
                                   Util.convertiracadena(valor).ToUpper() == "ON"))
                        {
                            isChecked = true;
                        }

                        // isChecked = valor == null ? false : true;
                        double area = 0;
                        if (isChecked)
                        {
                            area = Convert.ToDouble(row.Cells["StockRealVolumen"].Value);
                            if (area < 0)
                            {
                                Util.ShowAlert("No puede seleccionar stock negativo");
                                return;
                            }
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
                case enmAyuda.enmActividadesRelacionadas:                  
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value != null)
                    {
                        this.Result = this.gridControl.CurrentRow.Cells["codigoLinea"].Value.ToString() +
                                  this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    }                 

                    break;
                case enmAyuda.enmMaquinaxLineaActividad:
                    if (this.gridControl.CurrentRow.Cells["codigo"].Value != null) {
                        this.Result = this.gridControl.CurrentRow.Cells["codigo"].Value.ToString();
                    }
                    break;
                case enmAyuda.enmMotivoHoraMuerta:
                    if (this.gridControl.CurrentRow.Cells["PRO01CODIGO"].Value != null)
                    {
                        this.Result = this.gridControl.CurrentRow.Cells["PRO01CODIGO"].Value.ToString()+ "|" 
                                      + this.gridControl.CurrentRow.Cells["PRO01DESCRIPCION"].Value.ToString();
                                       
                    }
                    break;
                case enmAyuda.enmProductoxColorFormat:
                    if (this.gridControl.CurrentRow.Cells["Codigo"].Value != null)
                        this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString() + "|" +
                                        this.gridControl.CurrentRow.Cells["Descripcion"].Value.ToString() + "|" +
                                        this.gridControl.CurrentRow.Cells["UnidadMedida"].Value.ToString();                                   
                    break;
                case enmAyuda.enmMotivo:
                    if (this.gridControl.CurrentRow.Cells["PRO15CODIGO"].Value != null)
                        this.Result = this.gridControl.CurrentRow.Cells["PRO15CODIGO"].Value;
                        //this.Result = this.gridControl.CurrentRow.Cells["PRO15CODIGO"].Value + "|" + 
                        //              this.gridControl.CurrentRow.Cells["PRO15DESCRIPCION"].Value;

                    break;
                case enmAyuda.enmOrdenTrabajoTipo:
                    if (this.gridControl.CurrentRow.Cells["PRO01CODIGO"].Value != null)
                        this.Result = this.gridControl.CurrentRow.Cells["PRO01CODIGO"].Value + "|" +
                            this.gridControl.CurrentRow.Cells["PRO01DESCRIPCION"].Value;
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void frmBusqueda_Shown(object sender, EventArgs e)
        {
            focoFiltro(this._tipoAyuda);
        }

        private void frmBusqueda_Activated(object sender, EventArgs e)
        {
            //SendKeys.Send("{TAB}");
        }

        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            OnAceptar();
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter) {
                if (gridControl.Rows.Count == 0) return;
                if (gridControl.SelectedRows.Count == 0) return;
                OnAceptar();
            }
        }

        private void gridControl_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (_tipoAyuda == enmAyuda.enmCanastillasMultiplePP) { 
            
            
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

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
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
