using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ArticuloLogic
    {
        #region Singleton
        private static volatile ArticuloLogic instance;
        private static object syncRoot = new Object();

        private ArticuloLogic() { }

        public static ArticuloLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ArticuloLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<ArticuloResponse> TraerArticuloXAlmacen(string @cCodEmp, string @cAnno, string @cMes, string @cAlmacen)
        {
            return Accessor.TraerArticuloXAlmacen(cCodEmp, cAnno, cMes, cAlmacen, "In01Key", "*");
        }
        public List<ArticuloResponse> TraerArticuloSumXAlmacen(string @Empresa, string @Anio, string @Almacen)
        {
            return Accessor.TraerArticuloSumXAlmacen( @Empresa, @Anio, @Almacen);
        }
        public List<ArticuloResponse> TraerArticuloxAlmacenIngMasivo(string @cCodEmp, string @cAnno, string @cMes, string @cAlmacen)
        {
            return Accessor.TraerArticuloXAlmacen(cCodEmp, cAnno, cMes, cAlmacen, "ColorFormat", "");
        }
        public List<ArticuloResponse> AutocompleteArticulo(string @cCodEmp, string @cAnno, string @cMes, string @cAlmacen)
        {
            return Accessor.TraerArticuloXAlmacen(@cCodEmp, @cAnno, @cMes, @cAlmacen, "autocomplete", "");
        }
        
        public List<Spu_Inv_Trae_PtStock> TraerPtStock(string @empresa, string @almacen)
        {
            return Accessor.TraerPtStock(@empresa, @almacen);
        }

        public List<Spu_Inv_Trae_ReservasXPv> TraerReservaPTParaDespacho(string @In07codemp,string @in07pedvennum)
        {
            return Accessor.TraerReservaPTParaDespacho(@In07codemp, @in07pedvennum);
        }

        public List<Spu_Inv_Trae_PtXPedVenta> PtXPedVenta(string @come01empresa, string @IN01AA, string  @come01pedvennum)
        {
            return Accessor.PtXPedVenta(@come01empresa, @IN01AA, @come01pedvennum);
        }

        public void ArticuloInsertar(Articulo articulo, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.ArticuloInsertar(articulo.IN01CODEMP, articulo.IN01AA, articulo.IN01KEY, articulo.IN01DESLAR, articulo.IN01UNIMED, 
                articulo.IN01CODPRO, articulo.IN01MOV, articulo.IN01UNIDADEQUI, articulo.IN01MONTOEQUI, articulo.IN01UNIDADMAYOR, 
                articulo.IN01ESTADO, articulo.IN01TIPO, articulo.IN01FLAGTIPCALAREA, articulo.IN01PRODNATURALEZA, out @cMsgRetorno);
        }
        

        public void ArticuloModificar(Articulo articulo, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.ArticuloModificar(articulo.IN01CODEMP, articulo.IN01AA, articulo.IN01KEY, articulo.IN01DESLAR, articulo.IN01UNIMED, articulo.IN01CODPRO, 
                articulo.IN01MOV, articulo.IN01UNIDADEQUI, articulo.IN01MONTOEQUI, articulo.IN01UNIDADMAYOR, articulo.IN01ESTADO, 
                articulo.IN01TIPO, articulo.IN01FLAGTIPCALAREA, out @cMsgRetorno);
        }

        public void ArticuloEliminar(Articulo articulo, string @flag, string @mes, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.ArticuloEliminar(articulo.IN01CODEMP, articulo.IN01AA, @mes, articulo.IN01KEY, @flag, out @cMsgRetorno);
        }

        public List<Spu_Inv_Trae_Proter> TraerArticulo(string empresa, string anio, string productoNaturaleza)
        {
            return Accessor.TraerArticulo(empresa, anio, productoNaturaleza );
        }
        public DataTable Trae_AlmacenesLibLegal(string @in09codemp) 
        {
            return Accessor.Spu_Inv_Trae_AlmacenesLibLegal(@in09codemp);
        }
        public DataTable TraerArticuloxNatyAlm(string empresa, string anio,
            string productoNaturaleza, string almacen, string @Movimiento = "")
        {
            return Accessor.TraerArticuloxNatyAlm(empresa, anio, productoNaturaleza, almacen, @Movimiento);
        }
        

        public List<Spu_Inv_Trae_Proter> TraerProdTerXAlmacen(string empresa, string anio, string codalmacen)
        {
            return Accessor.TraerProdTerXAlmacen(empresa, anio, codalmacen);
        }
        public List<Articulo> TraerProdTerStock(string empresa, string anio, string almacen)
        {
            return Accessor.TraerProdTerStock(empresa, anio, almacen);
        }
        public List<Spu_Inv_Trae_StockDet> TraerProdTerStockDet(string empresa, string producto)
        {
            return Accessor.TraerProdTerStockDet(empresa, producto);
        }

        public List<Spu_Inv_Trae_ConciliaAlmConGuias> TraeConciliaAlmConGuias(string @IN06CODEMP, string @IN06AA, string @IN06MM)
        {
            return Accessor.TraeConciliaAlmConGuias(@IN06CODEMP, @IN06AA, @IN06MM);
        }

        public List<Spu_Inv_Trae_ConciliaAlmConGuiasDet> TraeConciliaAlmConGuiasDet(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @AlmacenTranCod, string @MotivoGuiaCod)
        {
            return Accessor.TraeConciliaAlmConGuiasDet(@IN06CODEMP, @IN06AA, @IN06MM, @AlmacenTranCod, @MotivoGuiaCod);
        }

        public List<sp_Inv_Trae_Detalle_Articulo_Can> TraerAlmacenxArticulo(string @cCodEmp, string @cAnno, string @cMes, string @cCodigo, string @cCodAlm)
        {
            return Accessor.TraerAlmacenxArticulo(@cCodEmp, @cAnno, @cMes, @cCodigo, @cCodAlm);
        }
        public Articulo ArticuloTraerRegistro(string @cCodEmp, string @cAnno, string @cCodigo)
        {
            return Accessor.ArticuloTraerRegistro(@cCodEmp, @cAnno, @cCodigo);
        }
        public Articulo ProterDescripcion(string @cCodigo)
        {
            return Accessor.ProterDescripcion(@cCodigo);
        }
        public Articulo ProterDescripcionFormato(string @cCodigo)
        {
            return Accessor.ProterDescripcionFormato(@cCodigo);
        }
        public Articulo ProterMedidas(string @cCodigo)
        {
            return Accessor.ProterMedidas(@cCodigo);
        }

        public Articulo ProterAreaxUni(string @Empresa, string @Anio, string @PTCodigo, double @PTAncho, double @PTLargo)
        {
            return Accessor.ProterAreaxUni( @Empresa, @Anio, @PTCodigo, @PTAncho, @PTLargo);
        }

        public Articulo AreaxUniGeneral(string @Empresa, string @Anio, string @PTCodigo, double @PTAncho, double @PTLargo, string @NaturalezaCod)
        {
            return Accessor.AreaxUniGeneral(@Empresa, @Anio, @PTCodigo, @PTAncho, @PTLargo, @NaturalezaCod);
        }
        

        public Articulo ProterMedidasSalida(Movimiento movimiento)
        {
            return Accessor.ProterMedidasSalida(movimiento.CodigoEmpresa,movimiento.Anio,movimiento.Mes,
			movimiento.CodigoTipoDocumento,movimiento.CodigoDocumento,movimiento.CodigoArticulo,
			movimiento.Orden);
        }

        public Articulo ProterMedidasPedVen(string @come01empresa, string @come01pedvennum, string @come01pedvencodprod, double @come01pedvenitem)
        {
            return Accessor.ProterMedidasPedVen(@come01empresa, @come01pedvennum, @come01pedvencodprod, @come01pedvenitem);
        }
        public List<Articulo> TraerMPStock(string empresa, string anio, string codigoAlmacen)
        {
            return Accessor.TraerMPStock(empresa, anio, codigoAlmacen);
        }
        public List<Articulo> TraerSUStock(string empresa, string anio, string codigoAlmacen)
        {
            return Accessor.TraerSUStock(empresa, anio, codigoAlmacen);
        }
        public List<Spu_Inv_Trae_StockDetMP> TraerMPStockDet(string empresa, string producto, string almacen)
        {
            return Accessor.TraerMPStockDet(empresa, producto, almacen);
        }
        public List<Spu_Inv_Trae_ListaSUStockXALM> TraerSUStockxAlm(string empresa, string anio, string almacen, string productocod)
        {
            return Accessor.TraerSUStockxAlm(empresa,anio, almacen, productocod);
        }
        public List<Spu_Inv_Trae_StockDetMP> TraerDetalledoMPDet(string @IN07CODEMP, string @codAlmacen)
        { 
            return Accessor.TraerDetalledoMPDet(@IN07CODEMP, @codAlmacen);
        }
        public List<Spu_Inv_Trae_StockDetMP> TraerMPStockDetTodos(string @IN07CODEMP) {
            return Accessor.TraerMPStockDetTodos(@IN07CODEMP);
        }

        public void TraerMovimientoxArticulo(string empresa, string anio, string codigoProducto,out double CanMovimientos ) {
             Accessor.TraerMovimientoxArticulo(empresa, anio, codigoProducto, out CanMovimientos );
             
        }
        public DataTable TraerArticulosxNaturaleza() {
            return Accessor.Spu_Inv_Traer_CantidadProductoxNaturaleza();
        }

        public void ActualizaArtiSuministro(string @Empresa, string @Anio, string @Ubicacion, 
         string @CodigoProducto,  out int @flag, out string @mensaje)
        {
            Accessor.Spu_Inv_Upd_StockSuministroRep(@Empresa, @Anio, @Ubicacion, @CodigoProducto, 
                out @flag, out @mensaje);
        }
        public DataTable TraerArticulo_Valorizado(string @Empresa, string @Ano, string @Mes, string @Almacen, string @Campo, string  @Filtro) 
        {
            return Accessor.TraerArticulo_Valorizado(@Empresa,@Ano,@Mes,@Almacen,@Campo,@Filtro);
        }
        //public void ActualizaArtiSuministro(string @Empresa,
        //    string @Anio, string @xml, out int @flag, out string @mensaje)
        //{ 
        //    Accessor.Spu_Inv_Upd_StockSuministroRep(@Empresa, @Anio, @xml, out @flag, out @mensaje);
        //}
       
        #region "Modulo Produccion"
        public List<Spu_Inv_Trae_ListaPPStock> TraerPPStock(string @empresa, string @anio, string @almacen)
        {
            return Accessor.TraerPPStock(@empresa, @anio, @almacen);
        }

        public List<Spu_Inv_Trae_StockDetPP> TraerPPStockDet(string @IN07CODEMP, string @CodigoProducto, string @codAlmacen) 
        {
            return Accessor.TraerPPStockDet(@IN07CODEMP, @CodigoProducto, @codAlmacen);
        }
        public void TraerAreaVolumenPP(string @IN07KEY, string @IN07UNIMED, double @IN07ANCHO, double @IN07LARGO, 
                                        double @IN07ALTO, double @IN07CANART,string @NaturalezaCod, out double @AreaPP, out double @VolumenPP) 
        {
            Accessor.TraerAreaVolumenPP(@IN07KEY, @IN07UNIMED, @IN07ANCHO, @IN07LARGO, @IN07ALTO, @IN07CANART, @NaturalezaCod, out @AreaPP, out @VolumenPP);
        }
        public List<Spu_Inv_Trae_StockDetPP> TraerCanastillaPP(string @IN07CODEMP, string @anio, string @codAlmacen)
        {
            return Accessor.TraerCanastillaPP(@IN07CODEMP, @anio, @codAlmacen);
        }
        public List<ArticuloResponse> TraerAyudaxColorFormat(string @cCodEmp, string @cAnno, string @cMes, string @cAlmacen, string @CodigoAnterior)
        { 
            return Accessor.TraerAyudaxColorFormat(@cCodEmp, @cAnno, @cMes, @cAlmacen, @CodigoAnterior);
        }
        public List<Spu_Inv_Trae_StockDetPP> TraerStockxCanastillaPP(string @empresa, string @almacen)
        { 
            return Accessor.Spu_Pro_Trae_StockxCanastillaPP( @empresa,  @almacen);
        }
        public DataTable TraerRptStockxCanastillaPP(string @empresa, string @almacen, string @XMLrango)
        {
            return Accessor.Spu_Pro_Rep_StockxCanastillaPP(@empresa, @almacen, @XMLrango);
        }
        public  DataTable TraerRptStockxCanastillaGeneral(string @IN07CODEMP)
        {
            return Accessor.TraerRptStockxCanastillaGeneral(@IN07CODEMP);
        }

        public DataTable Spu_Pro_Rep_StockxCanaxalmacen(string @in07codemp)
        {
            return Accessor.Spu_Pro_Rep_StockxCanaxalmacen(@in07codemp);
        }

        public DataTable Spu_Pro_Rep_StockxCanaDuplicadas(string @in07codemp)
        {
            return Accessor.Spu_Pro_Rep_StockxCanaDuplicadas(@in07codemp);
        }

        #endregion
		#region "Modulo Factura"

        //public List<Articulo> TraerProducto(string @cCodEmp, string @cAnno, string @cOrden, string @cFiltro, string @in01tipo,
        //string @in01estado)
        //{ 
        //    return Accessor.Spu_fact_Trae_In01arti(@cCodEmp, @cAnno, @cOrden, @cFiltro, @in01tipo, @in01estado);
        //}


        public void ProductoInsertar(Articulo pProducto, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_IN01ARTI(pProducto.IN01CODEMP,
            pProducto.IN01AA, pProducto.IN01KEY, pProducto.IN01DESLAR, pProducto.IN01UNIMED,
            pProducto.IN01UNIDADEQUI, pProducto.IN01MONTOEQUI, pProducto.IN01CODPRO, pProducto.IN01FECMAT, pProducto.@IN01MOV,
            pProducto.IN01UNIDADMAYOR, pProducto.IN01ESTADO, pProducto.IN01TIPO,
            pProducto.IN01FLAGTIPCALAREA, pProducto.IN01PRODNATURALEZA, pProducto.IN01DESINGLES,
            pProducto.IN01DESESPANIOL, pProducto.IN01UNIMEDVENTA,
            out @flag, out @msgretorno);
        }


        public void ProductoActualizar(Articulo pProducto,
        out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_in01arti(pProducto.IN01CODEMP,
            pProducto.IN01AA, pProducto.IN01KEY, pProducto.IN01DESLAR, pProducto.IN01UNIMED,
            pProducto.IN01UNIDADEQUI, pProducto.IN01MONTOEQUI, pProducto.IN01CODPRO, pProducto.IN01FECMAT, pProducto.@IN01MOV,
            pProducto.IN01UNIDADMAYOR, pProducto.IN01ESTADO, pProducto.IN01TIPO,
            pProducto.IN01FLAGTIPCALAREA, pProducto.IN01PRODNATURALEZA, pProducto.IN01DESINGLES,
            pProducto.IN01DESESPANIOL, pProducto.IN01UNIMEDVENTA, out @flag, out @msgretorno);
        }


        public void ProductoEliminar(string @IN01CODEMP, string @IN01AA, string @IN01KEY,
        out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Del_IN01ARTI(@IN01CODEMP, @IN01AA, @IN01KEY, out @flag, out @msgretorno);
        }
        public List<Spu_Fact_Trae_Proter> TraerProductos(string @IN01CODEMP, string @IN01AA, string @IN01PRODNATURALEZA)
        { 
            return Accessor.Spu_Fact_Trae_Proter(@IN01CODEMP, @IN01AA, @IN01PRODNATURALEZA);
        }

        public void TraeDescripcionProducto(string @codigo, out string @Descripcion)
        {
            Accessor.Spu_Inv_Trae_ProductoDesc(@codigo, out @Descripcion);
        }
        public DataTable TraeArtiClixArtiProd(string @IN01CODEMP, string @IN01AA, string @XMLrango)
        { 
            return Accessor.Spu_Fac_Rep_TraeArtiClixArtiProd(@IN01CODEMP, @IN01AA, @XMLrango);
        }

        #region "modulo Facturacion"
        public void InsertarTodoArticuloFact(CompraArticulo arti,
        string XmlDetalleSalida, out int flagSalida, out string mensajeSalida)
        {
            Accessor.InsertarArticuloTodoFact(arti.codigoEmpresa, arti.anio,
            arti.codigoArticulo, arti.descripcion, arti.unimed, arti.unidadEquivalencia,
            arti.montoEquivalencia, arti.codigoProveedor, arti.movimiento,
            arti.unidadMayor, arti.estado, arti.tipo,
            arti.codigoNaturaleza, arti.tipoPlactas,
            XmlDetalleSalida, out flagSalida, out mensajeSalida);
        }

        public void InsertarCabeceraFact(CompraArticulo entidad, out int flag, out string mensaje)
        {
            Accessor.InsertarCabeceraFact(entidad.codigoEmpresa, entidad.anio, entidad.codigoArticulo, entidad.descripcion,
            entidad.unimed, entidad.codigoProveedor, entidad.movimiento, entidad.unidadEquivalencia,
            entidad.tipo, entidad.estado, entidad.montoEquivalencia, entidad.unidadMayor,
            entidad.tipoPlactas, out flag, out mensaje);
        }


        


       

        public void ActualizarCabeceraFact(CompraArticulo entidad,
        out int flag, out string mensaje)
        {
            Accessor.ActualizarCabeceraFact(entidad.codigoEmpresa, entidad.anio, entidad.codigoArticulo, entidad.descripcion,
                entidad.unimed, entidad.codigoProveedor, entidad.movimiento, entidad.unidadEquivalencia,
                entidad.tipo, entidad.estado, entidad.montoEquivalencia, entidad.unidadMayor, entidad.tipoPlactas,
                out flag, out mensaje);

        }

        public void EliminarArticuloFact(string @cEmpresa, string @cAnno, string @cMes, string @cCodigo,
        string @cFlag, out int @flag, out string @cMsgRetorno)
        {

            Accessor.EliminarArticuloFact(@cEmpresa, @cAnno, @cMes, @cCodigo, @cFlag, out @flag, out @cMsgRetorno);
        }

        //EliminarArticuloFact
      


        #endregion

        #endregion
        #region "Modulo Compras"
        public List<Articulo> TraeAyudaArticuloCompras(string @cCodEmp, string @cAnno, string @cTipoOrd,string @cCampo,string @cFiltro)
        {
            return Accessor.TraeAyudaArticuloCompras(@cCodEmp, @cAnno, @cTipoOrd, @cCampo, @cFiltro);
        }

        public List<Articulo> TraeArticuloCompras(string @cCodEmp, string @cAnno, string @cFiltro, string @in01tipo, string @in01estado, string @IN01PRODNATURALEZA)
        {
            return Accessor.TraeArticuloCompras(@cCodEmp, @cAnno, @cFiltro, @in01tipo, @in01estado, @IN01PRODNATURALEZA);
        }
        public DataTable Traer_UltimoArticulo(string @cCodEmp, string @cFecIni, string @cFecFin, string @cAnno, string @cOrden, string @cFiltro) 
        {
            return Accessor.Traer_UltimoArticulo(@cCodEmp, @cFecIni, @cFecFin, @cAnno, @cOrden, @cFiltro);
        }
        //TraerReporteMovimientoDocumento
        public DataTable TraerReporteMovimiento(string @CO05CODEMP, string @CO05AA, string @CO05MES, string @Flag) 
        {
            return Accessor.TraerReporteMovimientoDocumento(@CO05CODEMP, @CO05AA, @CO05MES, @Flag);
        }

        public DataTable TraeReporteArticuloCompras(string @cCodEmp, string @cAnno, string @cFiltro, string @in01tipo,
            string @in01estado, string @IN01PRODNATURALEZA)
        {
            return Accessor.TraeReporteArticuloCompras(@cCodEmp, @cAnno, @cFiltro, @in01tipo,
                @in01estado, @IN01PRODNATURALEZA);
        }
        public DataTable CompraReporteUltimaCompraArticulo(string codigoEmpresa, string codigoArticulo, string codigoAnalisis)
        {
            return Accessor.Spu_Com_Rep_UltimaCompra(codigoEmpresa, codigoArticulo, codigoAnalisis);
        }
        
        public DataTable CompraReporteUltimaCompraArticulo_Grid(string codigoEmpresa, string codigoArticulo, string codigoAnalisis)
        {
            return Accessor.Spu_Com_Rep_Trae_UltimaCompra(codigoEmpresa, codigoArticulo, codigoAnalisis);
        }
        public DataTable TraerRepCatalogo(string cCodEmp, string cAnno) 
        {
            return Accessor.TraerRepCatalogo(cCodEmp,cAnno);
        }
        #endregion
        #region Accessor

        private static ArticuloAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ArticuloAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
