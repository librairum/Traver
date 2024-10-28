using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;
namespace Inv.DataAccess
{
    public abstract class ArticuloAccesor : AccessorBase<ArticuloAccesor>
    {

        [SprocName("Sp_Inv_Trae_Articulos_Valorizados")]
        public abstract DataTable TraerArticulo_Valorizado(string @Empresa, string @Ano, string @Mes, string @Almacen, string @Campo, string @Filtro);

        
        [SprocName("sp_Inv_Help_ArtiXAlma")]
        public abstract List<ArticuloResponse> TraerArticuloXAlmacen(string @cCodEmp, string @cAnno, string @cMes, string @cAlmacen, string @cCampo, string @cFiltro);

        [SprocName("Spu_Inv_Trae_ArticuloSumConStockXAlma")]
        public abstract List<ArticuloResponse> TraerArticuloSumXAlmacen(string @Empresa, string @Anio, string @Almacen);

        [SprocName("Spu_Inv_Trae_Proter")]
        public abstract List<Spu_Inv_Trae_Proter> TraerArticulo(string @IN01CODEMP, string @IN01AA, string @IN01PRODNATURALEZA);

        [SprocName("Spu_Inv_Trae_AlmacenesLibLegal")]
        public abstract DataTable Spu_Inv_Trae_AlmacenesLibLegal(string @in09codemp);
        [SprocName("Spu_Inv_Trae_ArtxNatyAlm")]
        public abstract DataTable TraerArticuloxNatyAlm(string @IN01CODEMP, 
        string @IN01AA, string @IN01PRODNATURALEZA, string @Almacen, string @Movimiento);

        [SprocName("Spu_Inv_Trae_PtStock")]
        public abstract List<Spu_Inv_Trae_PtStock> TraerPtStock(string @IN07CODEMP, string @IN07CODALM);
        
        [SprocName("Spu_Inv_Trae_ReservasXPv")]
        public abstract List<Spu_Inv_Trae_ReservasXPv> TraerReservaPTParaDespacho(string @In07codemp, string @in07pedvennum);
        
        [SprocName("Spu_Inv_Trae_PtXPedVenta")]
        public abstract List<Spu_Inv_Trae_PtXPedVenta> PtXPedVenta(string @come01empresa, string @IN01AA, string @come01pedvennum);

        [SprocName("Spu_Inv_Trae_Articulo")]
        public abstract Articulo ArticuloTraerRegistro(string @IN01CODEMP, string @IN01AA, string @IN01KEY);
        
        [SprocName("sp_Inv_Trae_Detalle_Articulo_Can")]
        public abstract List<sp_Inv_Trae_Detalle_Articulo_Can> TraerAlmacenxArticulo(string @cCodEmp, string @cAnno, string @cMes, string @cCodigo, string @cCodAlm);

        [SprocName("Spu_Glo_Help_GloCaracProTerm")]
        public abstract List<Articulo> TraerArticuloCaracteristicas(string @glo01codigotabla);

        [SprocName("Spu_Inv_Trae_ProterXAlmacen")]
        public abstract List<Spu_Inv_Trae_Proter> TraerProdTerXAlmacen(string @IN01CODEMP, string @IN01AA, string @IN04CODALM);

        [SprocName("Spu_Inv_Trae_ListaPTStock")]
        public abstract List<Articulo> TraerProdTerStock(string @empresa, string @anio, string @almacen);

        [SprocName("Spu_Inv_Trae_StockDet")]
        public abstract List<Spu_Inv_Trae_StockDet> TraerProdTerStockDet(string @IN07CODEMP, string @CodigoProducto);

        [SprocName("Spu_Inv_Trae_ConciliaAlmConGuias")]
        public abstract List<Spu_Inv_Trae_ConciliaAlmConGuias> TraeConciliaAlmConGuias(string @IN06CODEMP, string @IN06AA,string @IN06MM);

        [SprocName("Spu_Inv_Trae_ConciliaAlmConGuiasDet")]
        public abstract List<Spu_Inv_Trae_ConciliaAlmConGuiasDet> TraeConciliaAlmConGuiasDet(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @AlmacenTranCod, string @MotivoGuiaCod);
        
        [SprocName("sp_Inv_Ins_Cabecera_Articulo_Can")]
        public abstract void ArticuloInsertar(string @cEmpresa, string @cAnno, string @cCodigo, string @cDescripcion, string @cUnidad, string @cProveedor, 
        string @cMovimiento, string @cUnidadEquivalente, double @nMontoEquivalente, string @cUnidadMayor, string @IN01ESTADO, string @IN01TIPO,
        string @IN01FLAGTIPCALAREA, string @IN01PRODNATURALEZA, out string @cMsgRetorno);

        
        [SprocName("sp_Inv_Upd_Cabecera_Articulo_Can")]
        public abstract void ArticuloModificar(string @cEmpresa, string @cAnno, string @cCodigo, string @cDescripcion, string @cUnidad, string @cProveedor,
            string @cMovimiento, string @cUnidadEquivalente, double @nMontoEquivalente, string @cUnidadMayor, string @IN01ESTADO, string @IN01TIPO, 
            string @IN01FLAGTIPCALAREA, out string @cMsgRetorno);

        [SprocName("sp_Inv_Del_Articulo_Can")]
        public abstract void ArticuloEliminar(string @cEmpresa, string @cAnno, string @cMes, string @cCodigo, string @cFlag, out string @cMsgRetorno);

        [SprocName("Spu_Inv_Trae_ProterDesc")]
        public abstract Articulo ProterDescripcion(string @codigo);

        [SprocName("Spu_Inv_Trae_ProterDescFormato")]
        public abstract Articulo ProterDescripcionFormato(string @codigo);

        [SprocName("Spu_Inv_Trae_ProterMed")]
        public abstract Articulo ProterMedidas(string @codigo);

        [SprocName("Spu_Inv_Trae_AreaxUni")]
        public abstract Articulo ProterAreaxUni(string @Empresa, string @Anio, string @PTCodigo, double @PTAncho, double @PTLargo);

        [SprocName("Spu_Inv_Trae_AreaxUniGeneral")]
        public abstract Articulo AreaxUniGeneral(string @Empresa, string @Anio, string @PTCodigo, double @PTAncho, double @PTLargo, string @NaturalezaCod);
        
        [SprocName("Spu_Inv_Trae_ProterMedSal")]
        public abstract Articulo ProterMedidasSalida(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC, string @IN07CODDOC, string @IN07KEY, double @IN07ORDEN);

        [SprocName("Spu_Inv_Trae_ProterMedPedVen")]
        public abstract Articulo ProterMedidasPedVen(string @come01empresa, string @come01pedvennum, string @come01pedvencodprod,double @come01pedvenitem);
        
        [SprocName("Spu_Inv_Trae_ListaMPStock")]
        public abstract List<Articulo> TraerMPStock(string @empresa, string @anio, string @almacen);

        [SprocName("Spu_Inv_Trae_ListaSUStock")]
        public abstract List<Articulo> TraerSUStock(string @empresa, string @anio, string @almacen);

        [SprocName("Spu_Inv_Trae_StockDetMP")]
        public abstract List<Spu_Inv_Trae_StockDetMP> TraerMPStockDet(string @IN07CODEMP, string @CodigoProducto, string @codAlmacen);

        [SprocName("Spu_Inv_Trae_ListaSUStockXALM")]
        public abstract List<Spu_Inv_Trae_ListaSUStockXALM> TraerSUStockxAlm(string @empresa, string @anio, string @almacen,string @In01key);
        
        //== Stock detallado 
        [SprocName("Spu_Inv_Trae_StockDetalladoMP")]
        public abstract List<Spu_Inv_Trae_StockDetMP> TraerDetalledoMPDet(string @IN07CODEMP, string @codAlmacen);

        //sp de ayuda para produccion 
        [SprocName("Spu_Inv_Trae_StockDetMPTodos")]
        public abstract List<Spu_Inv_Trae_StockDetMP> TraerMPStockDetTodos(string @IN07CODEMP);

        [SprocName("Spu_Inv_Trae_MovimientosxArticulo")]
        public abstract void TraerMovimientoxArticulo(string @IN07CODEMP, string @IN07AA, string @IN07KEY, out double @CanMovimientos );

        [SprocName("Spu_Inv_Traer_CantidadProductoxNaturaleza")]
        public abstract DataTable Spu_Inv_Traer_CantidadProductoxNaturaleza();

        [SprocName("Spu_Pro_Trae_StockxCanastillaPP")]
        public abstract List<Spu_Inv_Trae_StockDetPP> Spu_Pro_Trae_StockxCanastillaPP(string @empresa, string @almacen);
        [SprocName("Spu_Pro_Rep_StockxCanastillaPP")]
        public abstract DataTable Spu_Pro_Rep_StockxCanastillaPP(string @empresa, string @almacen, string @XMLrango);
        //Procedimiento para actualizar desde el Menu Reporte Stock Suministro
        [SprocName("Spu_Inv_Upd_StockSuministroRep")]
        public abstract void Spu_Inv_Upd_StockSuministroRep(string @Empresa, string @Anio, string @Ubicacion,  
        string @CodigoProducto, out int @flag, out string @mensaje);
        //public abstract void Spu_Inv_Upd_StockSuministroRep(string @Empresa, string @Anio, string @XMLRango,  
        //out int @flag, out string @mensaje);
        #region "Modulo Produccion"
        [SprocName("Spu_Inv_Trae_ListaPPStock")]
        public abstract List<Spu_Inv_Trae_ListaPPStock> TraerPPStock(string @empresa, string @anio, string @almacen);

        [SprocName("Spu_Inv_Trae_StockDetPP")]
        public abstract List<Spu_Inv_Trae_StockDetPP> TraerPPStockDet(string @IN07CODEMP, string @CodigoProducto, string @codAlmacen);

        [SprocName("sp_Pro_Trae_AreaVolumenxUniPP")]
        public abstract void TraerAreaVolumenPP(string @IN07KEY, string @IN07UNIMED, double @IN07ANCHO, double @IN07LARGO,
                                                double @IN07ALTO, double @IN07CANART, string @NaturalezaCod, out double @AreaPP, out double @VolumenPP);
        
        [SprocName("Spu_Inv_Trae_CanastillasPP")]
        public abstract List<Spu_Inv_Trae_StockDetPP> TraerCanastillaPP(string @IN07CODEMP, string @anio, string @codAlmacen);
        [SprocName("sp_Inv_Help_ArtiXColorFormat")]
        public abstract List<ArticuloResponse> TraerAyudaxColorFormat(string @cCodEmp, string @cAnno, string @cMes, string @cAlmacen, string @CodigoAnterior);
        
        [SprocName("Spu_Pro_Rep_StockxCanastillaGeneral")]
        public abstract DataTable TraerRptStockxCanastillaGeneral(string @IN07CODEMP);

        [SprocName("Spu_Pro_Rep_StockxCanaxalmacen")]
        public abstract DataTable Spu_Pro_Rep_StockxCanaxalmacen(string @in07codemp);

        [SprocName("Spu_Pro_Rep_StockxCanaDuplicadas")]
        public abstract DataTable Spu_Pro_Rep_StockxCanaDuplicadas(string @in07codemp);

        #endregion
        #region "Modulo Factura"

        //[SprocName("Spu_Fact_Trae_in01arti")]
        //public abstract List<Articulo> Spu_fact_Trae_In01arti(string @cCodEmp, string @cAnno, string @cOrden, string @cFiltro, string @in01tipo,
        //string @in01estado);

        [SprocName("Spu_Fact_Ins_IN01ARTI")]
        public abstract void Spu_Fact_Ins_IN01ARTI(string @IN01CODEMP,
        string @IN01AA, string @IN01KEY, string @IN01DESLAR, string @IN01UNIMED,
        string @IN01UNIDADEQUI,double @IN01MONTOEQUI, string @IN01CODPRO, string @IN01FECMAT,string @IN01MOV,
        string @IN01UNIDADMAYOR, string @IN01ESTADO, string @IN01TIPO,
        string @IN01FLAGTIPCALAREA, string @IN01PRODNATURALEZA, string @IN01DESINGLES,
        string @IN01DESESPANIOL, string @IN01UNIMEDVENTA, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Upd_in01arti")]
        public abstract void Spu_Fact_Upd_in01arti(string @IN01CODEMP,
        string @IN01AA, string @IN01KEY, string @IN01DESLAR, string @IN01UNIMED,
        string @IN01UNIDADEQUI, double @IN01MONTOEQUI, string @IN01CODPRO, string @IN01FECMAT, string @IN01MOV,
        string @IN01UNIDADMAYOR, string @IN01ESTADO, string @IN01TIPO,
        string @IN01FLAGTIPCALAREA, string @IN01PRODNATURALEZA, string @IN01DESINGLES,
        string @IN01DESESPANIOL, string @IN01UNIMEDVENTA, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Del_IN01ARTI")]
        public abstract void Spu_Fact_Del_IN01ARTI(string @IN01CODEMP, string @IN01AA, string @IN01KEY,
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Trae_Proter")]
        public abstract List<Spu_Fact_Trae_Proter> Spu_Fact_Trae_Proter(string @IN01CODEMP, string @IN01AA, string @IN01PRODNATURALEZA);

        [SprocName("Spu_Inv_Trae_ProductoDesc")]
        public abstract void Spu_Inv_Trae_ProductoDesc(string @codigo, out string @Descripcion);

        [SprocName("Spu_Fac_Rep_TraeArtiClixArtiProd")]
        public abstract DataTable Spu_Fac_Rep_TraeArtiClixArtiProd(string @IN01CODEMP, string @IN01AA, string @XMLrango);

        [SprocName("Spu_Fac_Ins_ArticuloTodo")]
        public abstract void InsertarArticuloTodoFact(string @cIN01CODEMP, string @cIN01AA, string @cIN01KEY, string @cIN01DESLAR,
        string @cIN01UNIMED, string @cIN01UNIDADEQUI, double @nIN01MONTOEQUI, string @cIN01CODPRO, string @cIN01MOV,
        string @cIN01UNIDADMAYOR, string @cIN01ESTADO, string @cIN01TIPO, string @cIN01PRODNATURALEZA, string @cIN01TIPOPLACTAS,
        string @XmlDetalle, out int @flag, out string @mensaje);


        [SprocName("Spu_Fac_Ins_CabeceraArticulo")]
        public abstract void InsertarCabeceraFact(string @cEmpresa, string @cAnno, string @cCodigo, string @cDescripcion,
        string @cUnidad, string @cProveedor, string @cMovimiento, string @cUnidadEquivalente,
        string @in01tipo, string @in01estado, double @IN01MONTOEQUI, string @IN01UNIDADMAYOR,
        string @IN01TIPOPLACTAS, out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Fac_Upd_CabeceraArticulo")]
        public abstract void ActualizarCabeceraFact(string @cEmpresa, string @cAnno, string @cCodigo,
        string @cDescripcion, string @cUnidad, string @cProveedor, string @cMovimiento,
        string @cUnidadEquivalente, string @in01tipo, string @in01estado,
        double @IN01MONTOEQUI, string @IN01UNIDADMAYOR, string @IN01TIPOPLACTAS,
        out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Fac_Del_Articulo")]
        public abstract void EliminarArticuloFact(string @cEmpresa, string @cAnno, string @cMes, 
            string @cCodigo, string @cFlag, out int @flag, out string @cMsgRetorno);
        #endregion
        

        
        #region "Modulo de Compras"
        [SprocName("Spu_Com_Trae_AyudaArticulo")]
        public abstract List<Articulo> TraeAyudaArticuloCompras(string @cCodEmp, string @cAnno, string @cTipoOrd, string @cCampo,string @cFiltro);

        [SprocName("Spu_Com_Trae_Articulo")]
        public abstract DataTable TraeReporteArticuloCompras(string @cCodEmp, string @cAnno, string @cFiltro,
        string @in01tipo, string @in01estado, string @IN01PRODNATURALEZA);

        [SprocName("Spu_Com_Rep_UltimaCompra")]
        public abstract DataTable Spu_Com_Rep_UltimaCompra(string @cCodEmp, string @cArticulo,  string @cAnalisis);

        [SprocName("Spu_Com_Rep_Trae_UltimaCompra")]
        public abstract DataTable Spu_Com_Rep_Trae_UltimaCompra(string @cCodEmp, string @cArticulo, string @cAnalisis);

        [SprocName("Spu_Com_Trae_Articulo")]
        public abstract List<Articulo> TraeArticuloCompras(string @cCodEmp, string @cAnno, string @cFiltro, string @in01tipo, string @in01estado, string @IN01PRODNATURALEZA);

        //ULTIMO ARTICULO
        [SprocName("sp_Com_Rep_UltArticulo")]
        public abstract DataTable Traer_UltimoArticulo(string @cCodEmp, string @cFecIni, string @cFecFin, string @cAnno, string @cOrden, string @cFiltro);

        [SprocName("Spu_Com_Rep_co05docu")]
        public abstract DataTable TraerReporteMovimientoDocumento(string @CO05CODEMP, string @CO05AA, string @CO05MES, string @Flag);

        [SprocName("sp_Inv_Rep_Catalogo")]
        public abstract DataTable TraerRepCatalogo(string @cCodEmp, string @cAnno);
        #endregion
    }
}
