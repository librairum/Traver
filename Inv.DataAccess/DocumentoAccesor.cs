using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;
using Inv.BusinessEntities.DTO;
namespace Inv.DataAccess
{
    public abstract class DocumentoAccesor : AccessorBase<DocumentoAccesor>
    {
        [SprocName("sp_Inv_Ins_Cabecera_Documento_Can")]
        public abstract void InsertarDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cTipoDocu, string @cDocumento, string @dFechaDoc,
        string @cCodTra, string @cTransac, string @cMoneda, double @nTipoCambio, string @cProveedor,
        string @cCliente, string @cCenCosto, string @cResponsable, string @cResponsablerec, string @cObra,
        string @cMaquinas, string @cLotes, string @cPedidos, string @cAlmaEm, string @cAlmaRe, string @cObserva,
        string @cItem, string @cAnoItem, string @cOrdCompra,string @IN06NOTASALIDAAA ,
        string @IN06NOTASALIDAMM  ,string @IN06NOTASALIDATIPDOC ,string @IN06NOTASALIDACODDOC, string @IN06PRODNATURALEZA,
        string @IN06DOCRESCTACTETIPANA, string @IN06DOCRESCTACTENUMERO, string @IN06ORIGENTIPO,
        string @in06prodlineacod,  string @in06prodTurnoCod,
        string @in06prodActiNivel1Cod, out string @cDocuNumer, out string @cMsgRetorno, string @numeroDocIngreso, 
            string @IN06ANOORDCOMP);
             
        [SprocName("sp_Inv_Upd_Cabecera_Documento_Can")]
        public abstract void ActualizarDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cDocumento, string @dFechaDoc,
                                                    string @cCodTra, string @cTransac, string @cMoneda, double @nCambio, string @cProveedor, string @cCliente,
                                                    string @cCenCosto, string @cResponsable, string @cResponsablerec, string @cObra, string @cMaquina,
                                                    string @cLote, string @cPedido, string @cAlmaEm, string @cAlmaRe, string @cObserva, string @cItem,
                                                    string @cAnoItem, string @cOrdCompra, 
                                                    string @IN06NOTASALIDAAA ,string @IN06NOTASALIDAMM,string @IN06NOTASALIDATIPDOC,string @IN06NOTASALIDACODDOC,
                                                    string @IN06DOCRESCTACTETIPANA, string @IN06DOCRESCTACTENUMERO,
                                                    string @in06prodlineacod,          
                                                    string @in06prodTurnoCod ,          
                                                    string @in06prodActiNivel1Cod, string @IN06ANOORDCOMP ,
                                                    out string @cMsgRetorno);

        [SprocName("sp_Inv_Del_Documento_Can")]
        public abstract void EliminarDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cTranMov,
                                                string @dFechaDoc, double @nTipoCambio, string @cMoneda, out string @cMsgRetorno);

        [SprocName("sp_Inv_Trae_Documento")]
        public abstract List<Documento> TraerDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cOrden, string @cCampo, string @cFiltro, 
            string @cVer , string @IN06PRODNATURALEZA);

        [SprocName("Spu_Inv_Trae_CabeDocuRegistro")]
        public abstract Documento ObtenerDocumento(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, string @IN06CODDOC);

        [SprocName("Spu_Inv_Trae_ResExpSalMP")]
        public abstract List<Documento> Spu_Inv_Trae_ResExpSalMP(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango);

        [SprocName("Spu_Inv_Trae_ResExpSalMPDet")]
        public abstract List<MovimientoResponse> Spu_Inv_Trae_ResExpSalMPDet(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango);

        [SprocName("Spu_Inv_Trae_NotaSalida")]
        public abstract DataTable Spu_Inv_Trae_NotaSalida(string @codemp);
        
        [SprocName("Spu_Inv_Trae_OrdenCompra")]
        public abstract List<DodcumentoOrdenCompra> TraeAyudaOrdenCompra(string @cCodEmp, string @cAno, string @cMes, string @cTipo,
        string @cTipAna, string @cCampo, string @cFiltro);

        

        #region Detalle de documento

        [SprocName("sp_Inv_Ins_Detalle_Documento_Can")]
        public abstract void InsertarDetalle(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, string @cCodAlm,
                                            string @cCodTra, string @cTransa, double @nCanArt, double @nCosUni, double @nImport, string @dFechaDoc,
                                            double @nTipoCambio, string @cMoneda, double @nOrden, string @cUnidad, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV,
                                            double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN,
                                            string @IN07STATUS, string @IN07NROCAJA, string @IN07ORDPROD, string @IN07PEDVEN, 
                                            string @IN07DocIngAA,string @IN07DocIngMM,string @IN07DocIngTIPDOC,string @IN07DocIngCODDOC,
                                            string @IN07DocIngKEY,double @IN07DocIngORDEN, string @IN07FLAGSTOCKREAL, 
                                            string @IN07PROVMATPRIMA, double @IN07AREAXUNI, string @in07pedvennum,
                                            string @in07pedvencodprod, double @in07pedvenitem,string @IN07CODCLI, string @in07observacion,
                                            string @IN07ORDENTRABAJO, string @IN07CALIDADMP,
                                            out int @flagReturn,
                                            out string @cMsgRetorno);

        [SprocName("Spu_Inv_Ins_DetDocuSalidasMultiple")]
        public abstract void InsertarDetalleSalMultiple(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC, string @IN07CODDOC,
        string @IN07FECDOC, string @IN07CODALM, string @IN07CODTRA, string @XMLdetalle, out int @Flag, out string @Msgretorno);

        [SprocName("sp_Inv_Upd_Detalle_Documento_Can")]
        public abstract void ActualizarDetalle(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, string @cCodAlm,
                                            string @cCodTra, string @cTransa, double @nCanArt, double @nCosUni, double @nImport, string @dFechaDoc,
                                            double @nTipoCambio, string @cMoneda, double @nOrden, string @cUnidad, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV,
                                            double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN,
                                            string @IN07STATUS, string @IN07NROCAJA, string @IN07ORDPROD, string @IN07PEDVEN,
                                            string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC,
                                            string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07FLAGSTOCKREAL,
                                            string @IN07PROVMATPRIMA, double @IN07AREAXUNI, string @in07pedvennum,
                                            string @in07pedvencodprod, double @in07pedvenitem, string @IN07CODCLI, string @in07observacion, 
                                            string @IN07ORDENTRABAJO, string @IN07CALIDADMP,
                                            out int @flagReturn,
                                            out string @cMsgRetorno);
        [SprocName("sp_Inv_Del_Detalles_Documento_Art")]
        public abstract void EliminarDetalle(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cArticulo,
                                             double @IN07ORDEN, out string @cMsgRetorno);

        [SprocName("sp_Inv_Trae_Detalle_Documento_Can")]
        public abstract List<MovimientoResponse> TraerMovimiento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @IN07ORDENTRABAJO);


        [SprocName("Sp_Inv_Trae_nro_orden")]
        public abstract void TraerNroOrden(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, out double @nroorden);

        [SprocName("Sp_Inv_Trae_TipoAnalisisxTipDocRespaldo")]
        public abstract void TraerAnalisisxDocumentoRespaldo(string @cCodEmp, string @cCodTran, out string @cTipoAnalisis);

        [SprocName("Spu_Come_Rep_ControlDevoluciones")]
        public abstract DataTable Spu_Come_Rep_ControlDevoluciones(string @IN06CODEMP);
        [SprocName("Spu_Inv_Traer_StockLineaxDocyOT")]
        public abstract List<MovimientoResponse> Spu_Inv_Traer_StockLineaxDocyOT(string @IN07CODEMP,  string @IN07AA, string @IN07MM,  
                                                            string @IN07TIPDOC,  string @IN07CODDOC, string @IN07ORDENTRABAJO);

        [SprocName("Spu_Pro_Upd_CambiarDeAlmacen")]
        public abstract void Spu_Pro_Upd_CambiarDeAlmacen(string @IN07CODEMP, string @IN07AA,
        string @IN07MM, string @IN07TIPDOC, string @IN07CODDOC, string @IN07KEY,
        string @IN07ORDENTRABAJO, string @IN07CODALM, string @IN07NROCAJA, string @IN07HORASALIDA,
        string @Almacenuevo, string @IN07NROCAJANEW, string @IN07KEYNEW, string @IN07HORASALIDANUEVA,
        string @FlagCampoaActualizar, out int @flagReturn, out string @cMsgRetorno);

        #endregion

        #region importacion
        [SprocName("Spu_Inv_Del_in07movi_Importar")]
        public abstract void DocumentoImportarEliminar(string @IN07CODEMP, string @usuario , out string @msgretorno);

        [SprocName("Spu_Inv_Ins_in07movi_Importar")]
        public abstract void DocumentoImportarInsertar(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC,
        string @IN07CODDOC, string @IN07KEY, double @IN07ORDEN, string @IN07UNIMED, string @IN07FECDOC, string @IN07CODALM,
        string @IN07TRANSA, double @IN07CANART, double @IN07COSUNI, double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO,
        string @IN07ORDPROD, string @IN07NROCAJA, string @IN07PEDVEN, double @IN07AREAXUNI, string @IN07PROVMATPRIMA,
        string @IN06CODTRA, string @IN06REFDOC, string @IN06MONEDA, string @IN06CODPRO, string @IN06CENCOS, string @IN06OBRA, string @IN07CODCLI, string @flag, 
        string @codigousuario, string @sistema , out string @msgretorno);

        [SprocName("Spu_Inv_Trae_ValidaImportacion")]
        public abstract List<ImportarDocumento> TraerImportacion(string @empresa, string @Anio, string @Mes,string @sistema,string @usuario);
        
        [SprocName("Spu_Inv_Ins_DocumentoImportacion")]
        public abstract void DocumentoImportarGenerar(string @IN06CODEMP, string @USUARIO, out string @msgretorno);

        #endregion
        #region "Importacion Movimientos - Costo"
        [SprocName("Spu_Inv_Ins_MovimientosImportados")]
        public abstract void InsertarMovimientosImportados(
                string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC, string @IN07CODDOC,
                 string @IN07KEY, double @IN07ORDEN, string @IN07UNIMED, string @IN07FECDOC, string @IN07CODALM,
                 string @IN07CODTRA, string @IN07TRANSA, double @IN07CANART, double @IN07COSUNI, double @IN07COUNSO,
                 double @IN07COUNDO, double @IN07IMPORT, double @IN07IMPSOL, double @IN07IMPDOL, double @IN07COSALM,
                 double @IN07IMPALM, double @IN07COALSO, double @IN07IMALSO, double @IN07COALDO, double @IN07IMALDO,
                 string @IN07CTAGTO, string @IN07CTAING, double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO,
                 double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN, double @IN07PROMSOL, double @IN07PROMDOL, 
                 string @IN07STATUS, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV, string @IN07PEDVENTA,
                 string @IN07ORDPROD, string @IN07NROCAJA, string @IN07PEDVEN, string @in07pedvendestino, string @IN07DocIngAA,
                 string @IN07DocIngMM,
                 string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC, string @IN07DocIngKEY, double @IN07DocIngORDEN,string @in07pedvennum,
                 string @in07pedvencodprod, double @in07pedvenitem, string @in07observacion, double @IN07AREAXUNI, string @IN07FLAGSTOCKREAL, 
                 string @IN07PROVMATPRIMA, string @IN07CODCLI,
                 string @IN07ORDENTRABAJO, string @IN07OPERADOR, string @IN06CODTRA, string @IN06REFDOC, string @IN06MONEDA,
                 string @IN06CODPRO, string @IN06CENCOS, string @IN06OBRA, string @FLAG,
                 string @ERRORES, int @CANTERRORES, string @CODIGOUSUARIO, string @SISTEMA, 
            string @IN06MAQUINA, string @in06prodlineacod, string @in06prodActiNivel1Cod, string @IN06CANTERACOD, string @IN06CONTRATISTACOD,
           string @IN06PRODNATURALEZA, string @IN06ORIGENTIPO
                ,out string @msgretorno);

        [SprocName("Spu_Inv_Del_MovimientosImportados")]
        public abstract void EliminarMovimientosImportados(string @IN07CODEMP, string @CODIGOUSUARIO, string @SISTEMA);
        #endregion

        #region Reportes

        [SprocName("Sp_Inv_Rep_Movimientos_Mina")]
        public abstract DataTable ReporteDocumento(string @CodEmp, string @Ano, string @Mes);

        [SprocName("Spu_inv_Rep_StockProdter")]
        public abstract DataTable RptStockProdter(string @IN07CODEMP, string @IN07CODALM, string @IN07AA, string @in07mm, string @XMLrango);

        [SprocName("Spu_Inv_Rep_KardexDet")]
        public abstract DataTable RptKardexDet(string @empresa, string @Anio, string @Almacen, string @fechaini, string @fechafin,string @Flag,string @XMLrango);

        [SprocName("Spu_Inv_Rep_KardexSuministros")]
        public abstract DataTable RptKardexSuministros(string @empresa, string @Anio, string @Almacen, string @fechaini, string @fechafin, string @Flag, string @XMLrango, string @SedeTipo);

        [SprocName("Spu_Inv_Rep_StockSUM")]
        public abstract DataTable Spu_Inv_Rep_StockSUM(string @empresa, string @anio, string @mes, string @almacen, string @Flag, string @XMLrango);

        [SprocName("Spu_Inv_Rep_StockSuministrosVal")]
        public abstract DataTable Spu_Inv_Rep_StockSuministrosVal(string @empresa, string @Anio, string @Mes, string @Almacen, string @Moneda, string @XMLrango);



        [SprocName("Spu_Inv_Rep_KardexDetPP")]
        public abstract DataTable RptKardexDetPP(string @empresa, string @Anio, string @Almacen, string @fechaini, string @fechafin, string @Flag, string @XMLrango, string @Naturaleza);



        [SprocName("Spu_Inv_Rep_StockRes")]
        public abstract DataTable RptStockProdterRes(string @empresa, string @periodo, string @almacen);

        [SprocName("Spu_Inv_Rep_StockResXProvMatPrima")]
        public abstract DataTable RptStocxProvMatPrimakProdterRes(string @empresa, string @periodo, string @almacen);

        [SprocName("Spu_Inv_Rep_KardexRes")]
        public abstract DataTable RptKardexRes(string @empresa, string @fechaini, string @fechafin, string @Flag);

        [SprocName("Spu_Inv_Rep_Movimientos")]
        public abstract List<Spu_Inv_Rep_Movimientos> RptMovimientoDet(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @Flag, string @Fechaini, string @Fechafin);

        [SprocName("Spu_Inv_Rep_MovimientosMP")]
        public abstract List<Spu_Inv_Rep_MovimientosMP> RptMovimientosMP(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @Flag, string @Fechaini, string @Fechafin);

        [SprocName("Spu_Inv_Rep_ArchiPlanoAlmacenes")]
        public abstract DataTable TraeArchivoPlanoAlmacen(string @empresa, string @anio, string @mesini, string @mesfin);

        [SprocName("Spu_Inv_Rep_ProdxFabricante")]
        public abstract List<Spu_Inv_Rep_ProdxFabricante> RptProdFabricante(string @IN06CODEMP, string @IN06AA, string @TipAnalisisctacte, string @Flag, string @PeriodoIni, string @PeriodoFin);

        [SprocName("Spu_Inv_Rep_ProvMateriaPrima")]
        public abstract List<Spu_Inv_Rep_ProvMateriaPrima> RptProvMateriaPrima(string @IN06CODEMP, string @IN06AA, string @TipAnalisisctacte, string @PeriodoIni, string @PeriodoFin);

        //funciona para traver de huaral
        [SprocName("Spu_Inv_Trae_Ubicacion")]
        public abstract List<UbicacionFisica> TraerUbicacionFisica(string @IN07CODEMP, string @naturaleza);

        [SprocName("Spu_Inv_Upd_Ubicacion")]
        public abstract void UbicacionFisicaActualizar(string @IN07CODEMP, string @IN07UBICACION, string @IN07NROCAJA, string @IN07USUARIO, 
            string @in07naturalezacod,out string @FlagOK, 
            out string @cMsgRetorno);

        [SprocName("Spu_Inv_Trae_ProductoxNroCaja")]
        public abstract List<Spu_Inv_Trae_ProductoxNroCaja> TraerProductosxNroCaja(string @cCodEmp,string @naturaleza, string @XMLrango);

        [SprocName("Spu_Inv_Trae_ProductoxNroCaja")]
        public abstract DataTable Reporte_ProductosNroCaja(string @cCodEmp, string @naturaleza, string @XMLrango);

        [SprocName("Spu_Inv_IngresoSalida")]
        public abstract DataTable Spu_Inv_Ing_Sal(string @codemp, string @fechaIni, string @fechaFin);
        
        [SprocName("Spu_Inv_Rep_IngresosVsSalidas")]
        public abstract DataTable Spu_Inv_Rep_IngresosVsSalidas(string @IN07CODEMP);
        [SprocName("Spu_Pro_Rep_BloqueMerma")]
        public abstract DataTable Spu_Pro_Rep_BloqueMerma(string @IN07CODEMP, string @FechaIni, string @FechaFin, string @Flag,string @BloqueNro);
        #endregion

        #region "Produccion"
        [SprocName("Spu_Pro_Ins_Produccion")]
        public abstract void Spu_Pro_Ins_Produccion(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, 
                                                 string @IN06FECDOC, string @IN06CODTRA, string @IN06TRANSA, 
                                                 string @IN06REFDOC, string @in06prodlineacod,string @in06prodTurnoCod,
                                                 string @in06prodActiNivel1Cod, string @IN06PRODNATURALEZA, string @IN06MAQUINA, string @IN06ORIGENTIPO,
                                                  out string @cDocuNumer, out int @flag, out string @cMsgRetorno);
        [SprocName("Spu_Pro_Trae_Produccion")]
        public abstract List<Documento> Spu_Pro_Trae_Produccion(string @cCodEmp, string @cAnno, string @cMes, 
                                                                string @cTransa, string @cNaturaleza);
        [SprocName("Spu_Pro_Upd_Produccion")]
        public abstract void Spu_Pro_Upd_Produccion(string @IN06CODEMP, string @IN06AA, string @IN06MM,string @IN06TIPDOC, 
                                                    string @IN06FECDOC, string @IN06CODTRA, string @IN06TRANSA, string @IN06REFDOC, 
                                                    string @in06prodTurnoCod, string @IN06PRODNATURALEZA, string @IN06MAQUINA, string @IN06ORIGENTIPO, 
                                                    string @cDocuNumer, out int @flag,   out string @cMsgRetorno);

        /*Eliminar cabecera de documento de producccion.*/
        [SprocName("sp_Inv_Del_CabeceraDocumentoProduccion")]
        public abstract void sp_Inv_Del_CabeceraDocumentoProduccion(string @cCodEmp, string @cAnno, string @cMes, 
                                                                    string @cTipDoc, string @cNumDoc, out string @cMsgRetorno);

        [SprocName("Spu_Pro_Ins_ProduccionDet")]
        public abstract void Spu_Pro_Ins_ProduccionDet(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC,
                                                       string @IN07CODALM, string @IN07CODDOC, string @IN07KEY, string @IN07UNIMED,
                                                        string @IN07FECDOC, double @IN07ORDEN, string @IN07CODTRA,
                                                        string @IN07TRANSA, double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO,
                                                        double @IN07CANART, string @IN07NROCAJA, string @IN07CODCLI, string @IN07ORDPROD,
                                                        double @IN07AREAXUNI, string @IN07ORDENTRABAJO, string @IN07OPERADOR,
                                                        string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC,
                                                        string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07HORASALIDA,
                                                        string @IN07NROCAJAINGRESO, string @IN07HORAINICIO, string @IN07HORAFINAL,
                                                        string @IN07FECHAPROCESO, string @IN07MOTIVOCOD, double @Secuencia,
                                                        string @in07prodTurnoCod,
                                                        double @IN07DESCABEZADOSUP, double @IN07DESCABEZADOINF,
                                                        string @Flagnuevooinsercion, out int @flagReturn,
                                                        out string @cMsgRetorno);
        [SprocName("Spu_Pro_Ins_ProduccionDetValida")]
        public abstract void Spu_Pro_Ins_ProduccionDetValida(string @IN07CODEMP , string @IN07AA , string @IN07MM, 
            string @IN07TIPDOC,string @IN07CODDOC, string @IN07NROCAJA, string @IN07ORDENTRABAJO, string @IN07KEY, 
            string @IN07UNIMED, double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, string @IN07TRANSACCION, 
            double @IN07CANART, double @MoviOrden, string @FlagInsert, out string @cMensaje, out int @cFlagValidar);

        [SprocName("Spu_Pro_Trae_ValidacionMPSinConsumir")]
        public abstract void Spu_Pro_Trae_ValidacionMPSinConsumir(string @IN07CODEMP, string @IN06AA, string @IN06MM, 
                                                    string @IN06TIPDOC, string @IN06CODDOC, string @IN07ORDENTRABAJO,
                                                    string @Transaccion, string @linea, string @Actividad, out string @cMensaje, 
                                                    out int @cFlag);
        

        [SprocName("Spu_Pro_Upd_ProduccionDet")]
        public abstract void Spu_Pro_Upd_ProduccionDet(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC,
                                                       string @IN07CODALM, string @IN07CODDOC, string @IN07KEY, double @IN07ORDEN,
                                                        string @IN07UNIMED,
                                                        string @IN07FECDOC, string @IN07CODTRA,
                                                        string @IN07TRANSA, double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO,
                                                        double @IN07CANART, string @IN07NROCAJA, string @IN07CODCLI, string @IN07ORDPROD,
                                                        double @IN07AREAXUNI, string @IN07ORDENTRABAJO, string @IN07OPERADOR,
                                                        string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC,
                                                        string @IN07DocIngCODDOC,
                                                        string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07HORASALIDA,
                                                        string @IN07NROCAJAINGRESO, string @IN07HORAINICIO, string @IN07HORAFINAL,
                                                        string @IN07FECHAPROCESO, string @IN07MOTIVOCOD, string @in07prodTurnoCod,
                                                        double @IN07DESCABEZADOSUP,
                                                        double @IN07DESCABEZADOINF,
                                                        out int @flagReturn, out string @cMsgRetorno);


        [SprocName("sp_Pro_Trae_DetalleProduccion")]
        public abstract List<MovimientoResponse>  sp_Pro_Trae_DetalleProduccion(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc,
                                                                                string @IN07ORDENTRABAJO);

        /*Eliminar un registro de la grilla del documento (gridControL) */
        [SprocName("sp_Pro_Del_DetalleProduccion")]
        public abstract void sp_Pro_Del_DetalleProduccion( string @cCodEmp,string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cTranMov, 
                                                            string @dFechaDoc, string @cArticulo, string @cUniMed, 
                                                            double @IN07ORDEN, out string @cMsgRetorno);
        
        [SprocName("Spu_Pro_Trae_PPStock")]
        public abstract List<Spu_Pro_Trae_PPStock> Spu_Pro_Trae_PPStock(string @IN07CODEMP, string @IN07CODALM);

        //Traer ayuda con Stock De Linea 
        [SprocName("Spu_Inv_Traer_StockLinea")]
        public abstract List<Movimiento> Spu_Inv_Traer_StockLinea(string @Empresa);
        //Eliminar Stock Linea
        [SprocName("Spu_Inv_Del_ELiminarStockLinea")]
        public abstract void Spu_Inv_Del_ELiminarStockLinea(string @IN07CODEMP, string @IN07AA, string @IN07MM, 
                                                            string @IN07TIPDOC,string @IN07CODDOC, string @IN07KEY, 
                                                            double @IN07ORDEN, string @IN07ORDENTRABAJO,  
                                                            out int @flag, out string @msg);
        //Traer el stock por codigo de Almacen
        [SprocName("Spu_Pro_Trae_StockPPxAlmacen")]
        public abstract List<Spu_Pro_Trae_PPStock> Spu_Pro_Trae_StockPPxAlmacen(string @IN07CODEMP, string @IN07CODALM);

        [SprocName("Spu_Pro_Ins_SalidasPP")]
        public abstract void Spu_Pro_Ins_SalidasPP(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06FECDOC, string @OTNUMERO, string @IN06ORIGENTIPO,
                                                    string @XMLdetalle, string @FlagValidacion, out string @FlagDeretorno,
                                                    out string @msgretorno);
        [SprocName("Spu_Pro_Trae_ValidacionSalidasPP")]
        public abstract void Spu_Pro_Trae_ValidacionSalidasPP(string @XMLdetalle, string @FlagValidacion, out string @FlagDeretorno, out string @msgretorno);
        
        [SprocName("Spu_Pro_trae_MatPrimaxOT")]
        public abstract List<Movimiento> Spu_Pro_trae_MatPrimaxOT(string @IN07CODEMP,  string @IN06AA,string @IN06MM,string @IN06TIPDOC,string @IN06CODDOC, 
                                                                  string @IN07ORDENTRABAJO);
        

        [SprocName("Spu_Pro_Del_SalidasPP")]
        public abstract void Spu_Pro_Del_SalidasPP(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @N06TIPDOC, string @IN06CODDOC,
                                                   string @IN07NROCAJA, string @IN07ORDENTRABAJO, out string @cMsgRetorno);    
        
  	    [SprocName("sp_Pro_Trae_TodosDetalleProduccion")]
        public abstract List<MovimientoResponse> sp_Pro_Trae_TodosDetalleProduccion(string @cCodEmp,  string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc);

        [SprocName("Spu_Inv_Trae_StockDetMPTodos")]
        public abstract List<Spu_Inv_Trae_StockDetMPTodos> Spu_Inv_Trae_StockDetMPTodos(string @IN07CODEMP, string @IN07CODALM);

        
        

        [SprocName("Spu_Pro_trae_MateriaPrimaRegistro")]
        public abstract Movimiento Spu_Pro_trae_MateriaPrimaRegistro(string @IN07CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, string @IN06CODDOC,
                                                                    string @IN07ORDENTRABAJO, string @IN07NROCAJA);
        [SprocName("Spu_Pro_Trae_CajaSeguimineto")]
        public abstract List<Spu_Pro_Trae_CajaSeguimineto> TraerSeguimientosCajas(string @IN07CODEMP, string @Fechaini, string @FechaFin, string @IN07NROCAJA);
        [SprocName("Spu_Pro_Ins_GenerarSalidas")]
        public abstract void Spu_Pro_Ins_GenerarSalidas(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango, string @IN06PRODNATURALEZA,
                                                        out int @cFlag, out string @cMensaje);
        [SprocName("Spu_Pro_Trae_CajaMovimiento")]
        public abstract List<Spu_Pro_Trae_CajaSeguimineto> TraerMovimientosCajas(string @IN07CODEMP, string @Fechaini, string @FechaFin, string @IN07NROCAJA);
        [SprocName("Spu_Pro_Trae_DetallexNroCajaArti")]
        public abstract List<Movimiento> TraerDetallexNroCaja( string @IN07CODEMP, string @IN07KEY, 
                                                            string @IN07NROCAJA, string @IN07CODALM);
        [SprocName("spu_Inv_Ins_Detalle_Documento_CanastIng")]
        public abstract void InsertarDetalleDocumentoxCanastIng(
        string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, string @cCodAlm,
                                            string @cCodTra, string @cTransa, double @nCanArt, double @nCosUni, double @nImport, string @dFechaDoc,
                                            double @nTipoCambio, string @cMoneda, double @nOrden, string @cUnidad, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV,
                                            double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN,
                                            string @IN07STATUS, string @IN07NROCAJA, string @IN07ORDPROD, string @IN07PEDVEN,
                                            string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC,
                                            string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07FLAGSTOCKREAL,
                                            string @IN07PROVMATPRIMA, double @IN07AREAXUNI, string @in07pedvennum,
                                            string @in07pedvencodprod, double @in07pedvenitem, string @IN07CODCLI, string @in07observacion,
                                            string @IN07ORDENTRABAJO, string @IN07NROCAJAINGRESO,
                                            string @IN06ORIGENTIPO, string @XMLDetalle,
                                            out int @flagReturn,
                                            out string @cMsgRetorno);
        [SprocName("Spu_Inv_Del_SalidaLinea")]
        public abstract void EliminarSalidasPPLinea(string @IN07CODEMP, string @IN07AA_ING, string @IN07MM_ING, string @IN07TIPDOC_ING,
                                                    string @IN07CODDOC_ING, string @IN07KEY_ING, double @IN07ORDEN_ING, out string @cMsgRetorno);

        [SprocName("spu_Inv_Upd_Detalle_Documento_CanastIng")]
        public abstract void ActualizarDetalleDocumentoCanastIng(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc,
            string @cKey, string @cCodAlm, string @cCodTra, string @cTransa, string @dFechaDoc, double @nTipoCambio, string @IN07CODBLOQUEEMP,
            string @IN07CODBLOQUEPROV, string @IN07NROCAJA, string @IN07PEDVEN, string @IN07PROVMATPRIMA,
            string @in07pedvennum, string @in07pedvencodprod, double @in07pedvenitem,
            string @IN07CODCLI, string @in07observacion, string @IN07ORDENTRABAJO, 
            double @nOrden, out int @flagReturn,out string @cMsgRetorno);

        [SprocName("Spu_Pro_Ins_Escalla")]
        public abstract void InsercionEscalla(string @PRO16CODEMP, string @PRO16BLOQUENRO,
            double @PRO16BLOQUEANCHO, double @PRO16BLOQUELARGO, double @PRO16BLOQUEALTO, double @PRO16BLOQUEESCLAT1,
            double @PRO16BLOQUEESCLAT2, double @PRO16BLOQUEESCSUP, string @PRO16BLOQUELADODELCORTE,
            string @PRO16ESCALLAALMACENCOD, string @PRO16ESCALLAPRODUCTOCOD, string @PRO16COSTRAALMACENCOD,
            string @PRO16COSTRAPRODUCTOCOD, double @PRO16BLOQUEALTOCOSTRA, string @XmlDetalle,
            out string @MsgRetorno, out int @Flag);


        [SprocName("Spu_Pro_Del_Escalla")]        
        public abstract void Spu_Pro_Del_Escalla(string @PRO16CODEMP, string @PRO16BLOQUENRO, int @PRO16CORRELATIVO,
                                                    out int @cFlag, out string @cMsgRetorno);

        [SprocName("Spu_Pro_Traer_Escalla")]                
        public abstract List<BloqueCorteDetalle> Spu_Pro_Traer_Escalla(string @PRO16CODEMP, string @PRO16AA,
                                            string @PRO16BLOQUENRO);
        
        [SprocName("Spu_Pro_Trae_SaldoxOT")]
        public abstract List<MovimientoResponse> TraerSaldoxOT(string @IN07CODEMP, string @IN06AA, 
                                            string @IN06MM,  string @IN06TIPDOC, 
                                            string @IN06CODDOC,  string @IN07ORDENTRABAJO,
                                            string @IN07CODALM);


        //Validacion de articulo si existe al almacen
        [SprocName("Spu_Pro_Traer_ExistenciaArticuloxAlmacen")]
        public abstract void Spu_Pro_Traer_ExistenciaArticuloxAlmacen(string @Empresa, string @Mes,
                       string @Anio, string @Almacen, string @ArticuloIn, out string @ArticuloOut);

        //[SprocName("Spu_Pro_Upd_CambiarDeAlmacen")]
        //public abstract void Spu_Pro_Upd_CambiarDeAlmacen(string @IN07CODEMP, string @IN07AA,
        //string @IN07MM, string @IN07TIPDOC, string @IN07CODDOC, string @IN07KEY, 
        //string @IN07ORDENTRABAJO, string @IN07CODALM, string @IN07NROCAJA, string @IN07HORASALIDA,
        //string @Almacenuevo, string @IN07NROCAJANEW, string @IN07KEYNEW, string @IN07HORASALIDANUEVA,
        //string @FlagCampoaActualizar, out int @flagReturn, out string @cMsgRetorno);


        [SprocName("Spu_Pro_Trae_CodigoGeneradoProducto")]
        public abstract void Spu_Pro_Trae_CodigoGeneradoProducto(string @cEmpresa, string @cCodModulo,
                                string @cCodigoGlobal, string @cMPCodigo, out string @cProductonuevo);
        
        
        #endregion
        #region "Produccion Reportes"
        [SprocName("Spu_Inv_Rep_StockMP")]
        public abstract DataTable Spu_Inv_Rep_StockMP(string @empresa, string @periodo, string @almacen,string @flagfiltro, string @XMLrango);

        [SprocName("Spu_Inv_Rep_StockPP")]
        public abstract DataTable Spu_Inv_Rep_StockPP(string @empresa, string @anio, string @mes, string @almacen, string @XMLrango);
        #endregion
        #region "Documento MP"


        [SprocName("Spu_Inv_Ins_Cabecera_Documento_MP")]
        public abstract void Spu_Inv_Ins_Cabecera_Documento_MP(string @cCodEmp, string @cAnno, string @cMes, string @cTipoDocu, string @cDocumento, string @dFechaDoc,
                                            string @cCodTra, string @cTransac, string @cMoneda, double @nTipoCambio, string @cProveedor,
                                            string @cCliente, string @cCenCosto, string @cResponsable, string @cResponsablerec, string @cObra,
                                            string @cMaquinas, string @cLotes, string @cPedidos, string @cAlmaEm, string @cAlmaRe, string @cObserva,
                                            string @cItem, string @cAnoItem, string @cOrdCompra, string @IN06NOTASALIDAAA,
                                            string @IN06NOTASALIDAMM, string @IN06NOTASALIDATIPDOC,
                                            string @IN06NOTASALIDACODDOC, string @IN06CANTERACOD, string @IN06CONTRATISTACOD,
                                            string @IN06PRODNATURALEZA, string @IN06DOCRESCTACTETIPANA, string @IN06DOCRESCTACTENUMERO, 
                                            string @IN06ORIGENTIPO,
                                            out string @cDocuNumer, out string @cMsgRetorno);

        [SprocName("Spu_Inv_Upd_Cabecera_Documento_MP")]
        public abstract void Spu_Inv_Upd_Cabecera_Documento_MP(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cDocumento,
                                                    string @dFechaDoc, string @cCodTra, string @cTransac, string @cMoneda, double @nCambio,
                                                    string @cProveedor, string @cCliente,
                                                    string @cCenCosto, string @cResponsable, string @cResponsablerec, string @cObra, string @cMaquina,
                                                    string @cLote, string @cPedido, string @cAlmaEm, string @cAlmaRe, string @cObserva, string @cItem,
                                                    string @cAnoItem, string @cOrdCompra,
                                                    string @IN06NOTASALIDAAA, string @IN06NOTASALIDAMM, string @IN06NOTASALIDATIPDOC, string @IN06NOTASALIDACODDOC,
                                                    string @IN06CANTERACOD, string @IN06CONTRATISTACOD, string @IN06DOCRESCTACTETIPANA, string @IN06DOCRESCTACTENUMERO, 
                                                    out string @cMsgRetorno);
        
        
        /*Eliminar el detalle de la grilla de materia prima*/
        [SprocName("sp_Inv_Del_Detalles_Documento_MP")]
        public abstract void sp_Inv_Del_Detalles_Documento_MP(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, 
                                                              string @cNumDoc, string @cTranMov, 
                                                            string @dFechaDoc, double @nTipoCambio, string @cMoneda, string @cAlmacen, 
                                                            string @cArticulo, string @cUniMed, double @cCantidad, double @cCosto, 
                                                            double @IN07ORDEN, 
                                                            out string @cMsgRetorno);
        
        
        
        [SprocName("sp_Inv_Ins_Detalle_Documento_MP")]
        public abstract void sp_Inv_Ins_Detalle_Documento_MP(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, string @cCodAlm,
                                            string @cCodTra, string @cTransa, double @nCanArt, double @nCosUni, double @nImport, string @dFechaDoc,
                                            double @nTipoCambio, string @cMoneda, double @nOrden, string @cUnidad, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV,
                                            double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN,
                                            string @IN07STATUS, string @IN07NROCAJA, string @IN07ORDPROD, string @IN07PEDVEN,
                                            string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC,
                                            string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07FLAGSTOCKREAL,
                                            string @IN07PROVMATPRIMA, double @IN07AREAXUNI, string @in07pedvennum,
                                            string @in07pedvencodprod, double @in07pedvenitem, string @IN07CODCLI, string @in07observacion,
                                            string @IN07MOTIVOCOD, out int @flagReturn, out string @cMsgRetorno);
        [SprocName("sp_Inv_Upd_DetalleDocumentoMP")]
        public abstract void sp_Inv_Upd_DetalleDocumentoMP(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, string @cCodAlm,
                                            string @cCodTra, string @cTransa, double @nCanArt, double @nCosUni, double @nImport, string @dFechaDoc,
                                            double @nTipoCambio, string @cMoneda, double @nOrden, string @cUnidad, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV,
                                            double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN,
                                            string @IN07STATUS, string @IN07NROCAJA, string @IN07ORDPROD, string @IN07PEDVEN,
                                            string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC,
                                            string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07FLAGSTOCKREAL,
                                            string @IN07PROVMATPRIMA, double @IN07AREAXUNI, string @in07pedvennum,
                                            string @in07pedvencodprod, double @in07pedvenitem, string @IN07CODCLI, string @in07observacion,
                                            string @IN07MOTIVOCOD, out int @flagReturn, out string @cMsgRetorno);


        [SprocName("Spu_Inv_Ins_ValidaDetalleDocumentoMP")]
        public abstract void Spu_Inv_Ins_ValidaDetalleDocumentoMP(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
                                            string @cNumDoc, string @cKey, string @cCodAlm, string @cCodTra, string @cTransa,
                                            double @nCanArt, double @nCosUni, double @nImport, string @dFechaDoc,
                                            double @nTipoCambio, string @cMoneda, double @nOrden, string @cUnidad, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV,
                                            double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN,
                                            string @IN07STATUS, string @IN07NROCAJA, string @IN07ORDPROD, string @IN07PEDVEN,
                                            string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC,
                                            string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07FLAGSTOCKREAL,
                                            string @IN07PROVMATPRIMA, double @IN07AREAXUNI, string @in07pedvennum,
                                            string @in07pedvencodprod, double @in07pedvenitem, string @IN07CODCLI, string @in07observacion,
                                            string @FlagValida, out string @FlagValidaRetorna, out int @flagReturn,
                                            out string @cMsgRetorno);
        [SprocName("Spu_Inv_Upd_ValidaDetalleDocumentoMP")]
        public abstract void Spu_Inv_Upd_ValidaDetalleDocumentoMP(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
                                            string @cNumDoc, string @cKey, string @cCodAlm, string @cCodTra, string @cTransa,
                                            double @nCanArt, double @nCosUni, double @nImport, string @dFechaDoc,
                                            double @nTipoCambio, string @cMoneda, double @nOrden, string @cUnidad, string @IN07CODBLOQUEEMP, string @IN07CODBLOQUEPROV,
                                            double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, double @IN07LARGOCAN, double @IN07ANCHOCAN, double @IN07ALTOCAN,
                                            string @IN07STATUS, string @IN07NROCAJA, string @IN07ORDPROD, string @IN07PEDVEN,
                                            string @IN07DocIngAA, string @IN07DocIngMM, string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC,
                                            string @IN07DocIngKEY, double @IN07DocIngORDEN, string @IN07FLAGSTOCKREAL,
                                            string @IN07PROVMATPRIMA, double @IN07AREAXUNI, string @in07pedvennum,
                                            string @in07pedvencodprod, double @in07pedvenitem, string @IN07CODCLI, string @in07observacion,
                                            string @FlagValida, out string @FlagValidaRetorna, out int @flagReturn,
                                            out string @cMsgRetorno);
        [SprocName("Spu_Pro_Traer_CantidadDetallexNroDocumento")]
        public abstract void Spu_Pro_Traer_CantidadDetallexNroDocumento( string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC, 
                                                                         string @IN07CODDOC, out int @CANTIDAD);
        [SprocName("Spu_Pro_Traer_CantidadOrdenesxNroDocumento")]
        public abstract void Spu_Pro_Traer_CantidadOrdenesxNroDocumento(string @PRO13CODEMP, string @PRO13DOCINGALMAA, string @PRO13DOCINGALMMM, 
                                                                        string @PRO13DOCINGALMTIPDOC, string @PRO13DOCINGALMCODDOC, out int @CANTIDAD);

        //metodo de tabla temporal movimiento
        [SprocName("Spu_Pro_Ins_MoviMasivoTemporal")]
        public abstract void Spu_Pro_Ins_MoviMasivoTemporal( string @empresa, string @usuario,string @XMLdetalle);
        [SprocName("Spu_Pro_Del_MoviMasivoTemporal")]
        public abstract void Spu_Pro_Del_MoviMasivoTemporal(string @empresa, string @usuario);
        [SprocName("Spu_Pro_Ins_MoviMasivoValida")]
        public abstract DataTable Spu_Pro_Ins_MoviMasivoValida(string @empresa, string @usuario, string @IN06AA, string @IN06MM, string @IN06TIPDOC,
            string @IN06CODDOC, string @IN07ORDENTRABAJO);
        [SprocName("Spu_Pro_Ins_MoviMasivo")]
        public abstract void Spu_Pro_Ins_MoviMasivo(string @empresa, string @usuario, out string @mensaje);
        [SprocName("Spu_Inv_Rep_MPIngVCortes")]
        public abstract DataTable Spu_Inv_Rep_MPIngVCortes(string @IN07CODEMP, string @perini, string @perfin);

        //  Insercion de saldos
        [SprocName("Spu_Pro_Ins_MoviSaldos")]
        public abstract void Spu_Pro_Ins_MoviSaldos(string @XMLdetalle, out string @cMensaje, out int @cFlag);
        #endregion
        #region "MP Resumido"
        [SprocName("Spu_Pro_Trae_MPResumida")]
        public abstract List<Spu_Pro_Trae_MPResumida> TraerMPResumido(string @IN07CODEMP, string @IN07CODALM);
        [SprocName("Spu_Pro_Ins_SalidaPPResumido")]
        public abstract void Spu_Pro_Ins_SalidaPPResumido( string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06FECDOC, string @OTNUMERO, 
                    string @IN06ORIGENTIPO, string @XMLdetalle, out int @cFlag, out string @cMsgretorno);
        [SprocName("Spu_Pro_Trae_SalidaMPResumida")]
        public abstract List<Spu_Pro_Trae_SalidaMPResumida> Spu_Pro_Trae_SalidaMPResumida(string @IN07CODEMP, string @IN07AA, 
                                                                                    string @IN07MM, string @IN07ORDENTRABAJO);
        [SprocName("Spu_Pro_Del_SalidaMPResumida")]
        public abstract void Spu_Pro_Del_SalidaMPResumida(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07DocIngAA, string @IN07DocIngMM, 
                                string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC, string @IN07DocIngKEY, string @IN07ORDENTRABAJO,  string @IN07CODALM, 
                                string @IN07NROCAJA, string @IN07HORASALIDA, out int  @cFlag , out string @cMensaje);
		[SprocName("Spu_Inv_Trae_DetalleSalidaAgrupado")]
        public abstract List<Movimiento> Spu_Inv_Trae_DetalleSalidaAgrupado(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC,
        string @IN06CODTRA, string @IN06CODDOC, string @parIN06REFDOC);


        [SprocName("Spu_Inv_Trae_DetGuiaxNroRefdeDocSalida")]
        public abstract List<Movimiento> Spu_Inv_Trae_DetGuiaxNroRefdeDocSalida(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA);

        [SprocName("Spu_Inv_Ins_DetGuiaADetMovimiento")]
        public abstract void Spu_Inv_Ins_DetGuiaADetMovimiento(string @XMLdetalle, out int @flag, out string @msgretorno);
        #endregion
        #region "Metodos de Stock Linea"
        [SprocName("Spu_Inv_Ins_StockLinea")]
        public abstract void Spu_Inv_Ins_StockLinea(string @DocIngPTIN07CODEMP, string @DocIngPTIN07AA,
                        string @DocIngPTIN07MM, string @DocIngPTIN07TIPDOC, string @DocIngPTIN07CODDOC,
                        string @DocIngPTIN07CodTransa, string @XMLrango);
        [SprocName("Spu_Inv_Ins_StockLinea")]
        public abstract void Spu_Inv_Ins_StockLinea(
        string @PTIN07CODEMP, string @PTIN07AA, string @PTIN07MM, string @PTIN07TIPDOC, string @PTIN07CODDOC, string @PTIN06CODTRA,
            string @PTIN07FechaDoc, string @XMLrango, out int @FlagDeretorno, out string @msgretorno);
     
        #endregion
        #region "Costos"
        [SprocName("Spu_Cos_Ins_MovimientosProduccion")]
        public abstract void Spu_Cos_Ins_MovimientosProduccion(string @Empresa, string @Anio, string @Mes, string @Linea,
                                                              string @Lote, out string @mensaje, out int @flag);
        [SprocName("Spu_Cos_Traer_MovimientoProduccion")]
        public abstract List<MovimientosProduccion> Spu_Cos_Traer_MovimientoProduccion(string @Empresa, string @Anio,
                                                                            string @Mes, string @Linea, string @Lote);

        //metodos para la importacion x texto de  costos produccion
        [SprocName("Spu_Cos_Ins_CostosProduccionImportacion")]
        public abstract void Spu_Cos_Ins_CostosProduccionImportacion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
        string @COS01CONTGASMOVANO, string @COS01CONTGASMOVMES, string @COS01CONTGASMOVSUBD, string @COS01CONTGASMOVNUMER,
        double @COS01CONTGASMOVORD, string @COS01CTACBLECOD, string @COS01CTACBLEDESC, string @COS01TIPOCOSTOCOD, string @COS01TIPOCOSTODESC,
        string @COS01COSTOCOD, string @COS01COSTODESC, double @COS01IMPORTE, string @COS01FIJOOVARIABLE, string @COS01DIRECTOOINDIRECTO,
        string @COS01FLAG, string @COS01ERRORES, int @COS01CANTERRORES, string @COS01CODIGOUSUARIO, string @COS01SISTEMA,
        out string @mensaje, out int @flag);

        [SprocName("Spu_Cos_Trae_CostosProduccionimportacion")]
        public abstract List<CostosProduccion> Spu_Cos_Trae_CostosProduccionimportacion(string @COS01CODEMP, string @COS01ANIO,
                                                                                    string @COS01MES, string @COS01CODIGOUSUARIO);

        [SprocName("Spu_Cos_Ins_CostosProduccionImpxusuario")]
        public abstract void Spu_Cos_Ins_CostosProduccionImpxusuario(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
                                                            string @COS01CODIGOUSUARIO, out int @flag, out string @mensaje);

        // Costos detalle
        
        [SprocName("Spu_Cos_Traer_CostosDetalle")]
        public abstract List<CostosDetalle> Spu_Cos_Traer_CostosDetalle(string @COS03CODEMP, string @COS03ANIO,
                                                        string @COS03MES, string @COS03LINEA, string @CO03LOTE);

        //Metodos de Moviemiento produccion importacion
        [SprocName("Spu_Cos_Ins_MovimientosProduccionImp")]
        public abstract void Spu_Cos_Ins_MovimientosProduccionImp(string @COS01CODEMP, string @COS01ANIO,
        string @COS01MES, string @COS01LINEA, string @COS01LOTE, string @COS01MOVIPRODAA,
        string @COS01MOVIPRODMM, string @COS01MOVIPRODTIPDOC, string @COS01MOVIPRODCODDOC,
        string @COS01MOVIPRODKEY, double @COS01MOVIPRODORDEN,
        string @COS01PRODLINEACOD, string @COS01RODACTNIV1COD, string @COS01ORDENTRABAJO,
        string @COS01PRODNATURALEZA, string @COS01UNIMED, string @COS01FECDOC,
        string @COS01CODALM, string @COS01CODTRA, string @COS01TRANSA, double @COS01CANART, double @COS01COSUNI,
        double @COS01COUNSO, double @COS01COUNDO, double @COS03IMPORT, double @COS01IMPSOL,
        double @COS01IMPDOL, double @COS01LARGO, double @COS01ANCHO, double @COS01ALTO,
        string @COS01NROCAJA, string @COS01DocIngAA, string @COS01DocIngMM,
        string @COS01DocIngTIPDOC, string @COS01DocIngCODDOC, string @COS01DocIngKEY,
        double @COS01DocIngORDEN, double @COS01AREAXUNI, double @COS01AREA,
        double @COS01VOLUMEN, double @COS01COSPROMSOL, double @COS01COSPROMDOL,
        string @COS01FLAG, string @COS01ERRORES, int @COS01CANTERRORES,
        string @COS01CODIGOUSUARIO, string @COS01SISTEMA, out int @flag, out string @mensaje);

        [SprocName("Spu_Cos_Del_MovimientosProduccionImp")]
        public abstract void Spu_Cos_Del_MovimientosProduccionImp(string @COS01CODEMP, string @COS01CODIGOUSUARIO,
                                                                        string @COS01SISTEMA, out string @mensaje);

        [SprocName("Spu_Cos_Ins_MovimientosProduccionImpxusuario")]
        public abstract void Spu_Cos_Ins_MovimientosProduccionImpxusuario(string @COS01CODEMP, string @COS01ANIO,
        string @COS01MES, string @COS01LINEA, string @COS01LOTE, string @COS01CODIGOUSUARIO, out int @flag, out string @mensaje);

        [SprocName("Spu_Cos_Trae_MovimientosProduccionImp")]
        public abstract List<MovimientosProduccion> Spu_Cos_Trae_MovimientosProduccionImp(string @COS01CODEMP, string @COS01ANIO,
                                                            string @COS01MES, string @COS01CODIGOUSUARIO);

        #endregion
       

        #region "Saldo x Bloque"
        [SprocName("Spu_Pro_Trae_SaldoxBloque")]
        public abstract List<Movimiento> Spu_Pro_Trae_SaldoxBloque(string @IN07CODEMP, string @IN07NROCAJAINGRESO);
        
        [SprocName("Spu_Pro_Ins_SaldoxBloque")]
        public abstract void Spu_Pro_Ins_SaldoxBloque(string @IN06CODEMP, 
            string @IN06AA, 
            string @IN06MM, 
            string @IN06FECDOC,  
            string @IN07KEY, 
            string @IN07UNIMED, 
            double @IN07CANART, 
            double @IN07LARGO, 
            double @IN07ANCHO, 
            double @IN07ALTO, 
            string @IN07NROCAJA, 
            string @IN07ORDENTRABAJO, 
            string @IN07OBSERVACION,
            out int @flag, 
            out string @mensaje);
        
        [SprocName("Spu_Pro_Del_SaldoxBloque")]
        public abstract void Spu_Pro_Del_SaldoxBloque(string @IN06CODEMP, string @IN06AA,string @IN06MM,string @IN06TIPDOC,
        string @IN06CODDOC, string @IN07KEY, double @IN07ORDEN, string @IN07NROCAJA, out int @flag, out string @mensaje);
        #endregion
        
        #region "Modulo facturacion"
        [SprocName("Spu_Fact_Trae_FacturaCuotas")]
        public abstract List<CuotasFactura> Spu_Fact_Trae_FacturaCuotas(string @FAC12CODEMP, string @FAC12COD, string @FAC12NUMDOC);

        [SprocName("Spu_Fact_Del_FacturaCuotas")]
        public abstract void Spu_Fact_Del_FacturaCuotas(string @FAC12CODEMP, string @FAC12COD, string @FAC12NUMDOC, out int @flag, out string @msgretorno);
 
        [SprocName("Spu_Fact_Trae_FAC05_DETFACTURAXFACT")]
        public abstract List<Spu_Fact_Trae_FAC05_DETFACTURAXFACT> Spu_Fact_Trae_FAC05_DETFACTURAXFACT(string @FAC05CODEMP, string @FAC04NUMDOC, string @FAC01COD);
        
        [SprocName("Spu_Fact_Ins_FAC04_CABFACTURA")]
        public abstract void Spu_Fact_Ins_FAC04_CABFACTURA(string @FAC04CODEMP,string @FAC01COD, string @FAC04NUMDOC,                        
        string @FAC04AA ,string @FAC04MM , string @FAC04NRODOC, string @FAC04SERIEDOC, string @FAC04FECHA, string @FAC04TIPANA,
        string @FAC04CODCLI, string @FAC04MONEDA , double @FAC04TIPCAMBIO, double @FAC04DONSUBTOTAL, double @FAC04DONIGV,
        double @FAC04DONTOTAL,string @FAC02COD,string @FAC03COD,string @FAC03TIPART,string @FAC04CLINOMBRE, string @FAC04CLIDIRECCION, 
        string @FAC04CLIRUC, string @FAC04GLOSA, string @FAC04DONGLAG, double @FAC04IGV, string @FAC04GUIAS,string @FAC04DOCMODTIPDOC,
        string @FAC04DOCMODNRO,string @FAC04DOCMODFECHA,string @FAC04TIPMOTEMI,string @FAC04TIPMOTEMIDES,string @FAC04EXPCONOEMBARQUE,
        string @FAC04EXPCODPAISORIGEN,string @FAC04EXPCODPAISDESTINO,string @FAC04EXPCODCONDPAGO,
        string @FAC04EXPCODCONDDESPACHO,string @FAC04EXPCODPUERTO,string @FAC04EXPCODPUERTODES,string @FAC04EXPCODBCOLOCAL,string @FAC04EXPCDDOCCRED,string @FAC04EXPLCEMITIDA,
        string @FAC04EXPBANKCODE,  string @FAC04EXPNUMCUENTA,string @FAC04EXPNROCONTAINER,string @FAC04EXPNROPRECINTO,string @FAC04ORDENCOMPRA, 
        string @FAC04FECORDCOMPRA,string @FAC04CODTIPOVENTA, string @FAC04ESTADODEPROCESO, string @FAC04TIENDA, double @FAC04DESCUENTOGLOBAL,
        string @FAC04FETIPONOTA, string @FAC04LIQUIDACIONNRO, string @FAC04FETIPODEOPERACION, string @FAC04FECODIGOANEXOEMISOR,
        string @FAC04FORMAPAGOSUNAT, int @FAC04FORMAPAGOSUNATCUOTAS, int @FAC04FORMAPAGOSUNATDIAS,
        string @FAC04FECODBIENOSERVDETRACCION, double @FAC04FEPORCEDETRACCION, double @FAC04FETOTALDETRACCION,
        string @FAC04VENDEDORCOD, string @FAC04VENDEDORNOMBRE,
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC04_CABFACTURA")]
        public abstract void Spu_Fact_Upd_FAC04_CABFACTURA(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC, string @FAC04AA, string @FAC04MM,
        string @FAC04NRODOC, string @FAC04SERIEDOC, string @FAC04FECHA, string @FAC04TIPANA, string @FAC04CODCLI, string @FAC04MONEDA,
        double @FAC04TIPCAMBIO, double @FAC04DONSUBTOTAL, double @FAC04DONIGV, double @FAC04DONTOTAL, string @FAC03COD, string @FAC02COD, 
        string @FAC03TIPART, string @FAC04CLINOMBRE, string @FAC04CLIDIRECCION, string @FAC04CLIRUC, string @FAC04GLOSA, string @FAC04DONGLAG, 
        double @FAC04IGV, string @FAC04GUIAS, string @FAC04DOCMODTIPDOC, string @FAC04DOCMODNRO, string @FAC04DOCMODFECHA, string @FAC04TIPMOTEMI, 
        string @FAC04TIPMOTEMIDES, string @FAC04EXPCONOEMBARQUE, string @FAC04EXPCODPAISORIGEN, string @FAC04EXPCODPAISDESTINO, 
        string @FAC04EXPCODCONDPAGO, string @FAC04EXPCODCONDDESPACHO, string @FAC04EXPCODPUERTO, string @FAC04EXPCODPUERTODES, string @FAC04EXPCODBCOLOCAL, 
        string @FAC04EXPCDDOCCRED, string @FAC04EXPLCEMITIDA, string @FAC04EXPBANKCODE, string @FAC04EXPNUMCUENTA, string @FAC04EXPNROCONTAINER,
        string @FAC04EXPNROPRECINTO, string @FAC04ORDENCOMPRA, string @FAC04FECORDCOMPRA, string @FAC04CODTIPOVENTA, string @FAC04ESTADODEPROCESO,
        string @FAC04TIENDA, double @FAC04DESCUENTOGLOBAL, string @FAC04FETIPONOTA, string @FAC04LIQUIDACIONNRO, string @FAC04FETIPODEOPERACION, string @FAC04FECODIGOANEXOEMISOR,
        string @FAC04FORMAPAGOSUNAT, int @FAC04FORMAPAGOSUNATCUOTAS, int @FAC04FORMAPAGOSUNATDIAS,    
        string @FAC04FECODBIENOSERVDETRACCION, double @FAC04FEPORCEDETRACCION, double @FAC04FETOTALDETRACCION,
        string @FAC04VENDEDORCOD,string @FAC04VENDEDORNOMBRE,
        out int @flag, out string @msgretorno);

        // Insercion del detalle de la factura
        [SprocName("Spu_Fact_Ins_FAC05_DETFACTURA")]
        public abstract void Spu_Fact_Ins_FAC05_DETFACTURA(string @FAC05CODEMP, string @FAC01COD, string @FAC04NUMDOC, int @FAC05CODFACDET,
        string @FAC05CODPROD, string @FAC05DESCPROD, string @FAC05UNIMED, double @FAC05CANTIDAD,
        double @FAC05PRECIO, double @FAC05SUBTOTAL, string @FAC05PARTARAN, double @FAC05PESO, double @FAC05NROCAJA, double @FAC05PESOADUANA,
        string @FAC05SUBGRUPO, string @FAC05FECODRAZEXONERACION, double @FAC05FEIMPDSCTO, string @FAC05FECODIMPREF,
        string @FAC05FEPRODUCTOTIPO, string @FAC05FEIMPORTEREFERENCIAL, string @FAC05FEIMPORTECARGO, string @FAC05FECODPRODSUNAT, double @FAC05FEIGVTASA, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC05_DETFACTURA")]
        public abstract void Spu_Fact_Upd_FAC05_DETFACTURA(string @FAC05CODEMP, string @FAC01COD, string @FAC04NUMDOC,
        int @FAC05CODFACDET, string @FAC05CODPROD, string @FAC05DESCPROD, string @FAC05UNIMED, double @FAC05CANTIDAD,
        double @FAC05PRECIO, double @FAC05SUBTOTAL, string @FAC05PARTARAN, double @FAC05PESO, 
        double @FAC05NROCAJA, double @FAC05PESOADUANA, string @FAC05SUBGRUPO, string @FAC05FECODRAZEXONERACION, 
        double @FAC05FEIMPDSCTO, string @FAC05FECODIMPREF, string @FAC05FEPRODUCTOTIPO,
        string @FAC05FEIMPORTEREFERENCIAL, string @FAC05FEIMPORTECARGO, string @FAC05FECODPRODSUNAT, double @FAC05FEIGVTASA,
        out int @flag, out string msgretorno);

        [SprocName("Spu_Fact_Del_FAC04_CABFACTURA")]
        public abstract void Spu_Fact_Del_FAC04_CABFACTURA(string @FAC04CODEMP,string @FAC01COD, string @FAC04NUMDOC, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Del_FAC05_DETFACTURA")]
        public abstract void Spu_Fact_Del_FAC05_DETFACTURA(string @FAC05CODEMP, string @FAC01COD, string @FAC04NUMDOC,
                                                            int @FAC05CODFACDET, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Help_FAC03_SUBPLANTILLA")]
        public abstract List<SubPlantilla> Spu_Fact_Help_FAC03_SUBPLANTILLA(string @FAC03CODEMP, string @FAC01COD, string @campo, string @Filtro);

        [SprocName("Spu_Fact_Help_FAC01_TIPDOC")]
        public abstract List<TipoDocumentoVentas> Spu_Fact_Help_FAC01_TIPDOC(string @FAC01CODEMP, string @campo, string @filro);

        [SprocName("Spu_Fact_Help_FAC04_CABFACTURA")]
        public abstract List<Spu_Fact_Help_FAC04_CABFACTURA> Spu_Fact_Help_FAC04_CABFACTURA(string @FAC04CODEMP, string @FAC01COD, string @campo, string @filro);

        [SprocName("Spu_Fac_Ins_FEComunicacionBaja")]
        public abstract void Spu_Fac_Ins_FEComunicacionBaja(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC,
                            string @FechaDocumento, string @FechaBaja, string @motivoBaja, out int @flag,out string @msgretorno);

        [SprocName("Spu_Fact_Ins_CuotasFactura")]
        public abstract void Spu_Fact_Ins_CuotasFactura(string @FAC12CODEMP ,  string @FAC12COD ,  string @FAC12NUMDOC ,  int @cuotascantidad ,int @cuotasdias ,  
            string @fechaDoc , out int @flag,out string @msgretorno);

        [SprocName("Spu_Fac_Ins_DocumentosElectronicos")]
        public abstract void Spu_Fac_Ins_DocumentosElectronicos(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Trae_ErrorLocalFE")]
        public abstract void Spu_Fac_Trae_ErrorLocalFE(string @FAC01COD, string @FAC04NUMDOC, out string @msgretorno);

        
        [SprocName("Spu_Fact_Trae_FacturaElectronicaOnline")]
        public abstract DataTable Spu_Fact_Trae_FacturaElectronicaOnline(string @empresa, string @tipoDocumentoEmisor,string @numeroDocumentoEmisor,
            string @tipoDocumento, string @serieNumero, out string @linkFacturaElectronica);


        [SprocName("Spu_Fact_Ins_CopiarFactura")]
        public abstract void Spu_Fact_Ins_CopiarFactura(string @FAC04CODEMP, string @FAC01COD, string @FAC04SERIEDOC,
        string @FAC04NRODOC, string @FACTURAORIGENNRO, string @FAC04AA, string @FAC04MM, string @FAC04FECHA, 
        out int @flag, out string @msgretorno);
        [SprocName("Spu_Fact_Trae_DetalleGuiaPorNroGuia")]
        public abstract List<DetalleGuiaTransporte> Spu_Fact_Trae_DetalleGuiPorNroGuia(string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA);

        [SprocName("Spu_Fact_Ins_DetalleResumido")]
        public abstract void Spu_Fact_Ins_DetalleResumido(string @FAC05CODEMP,string @FAC01COD,string @FAC04NUMDOC,string @XMLdetalle, 
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Del_DetFacturaPorGuiaDetalle")]
        public abstract void Spu_Fact_Del_DetFacturaPorGuiaDetalle(string @FAC05CODEMP,string @FAC01COD,
        string @FAC04NUMDOC, string @FAC05GUIATIPDOC, string @FAC05GUIANUMERO, int @FAC05CODFACDET, 
        string @FlagRespuesta, out int @flag, out string @msgretorno);
        
        [SprocName("Spu_Fact_Ins_GuiaRemisionEnComprobanteDePago")]
        public abstract void Spu_Fact_Ins_GuiaRemisionEnComprobanteDePago(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC,
        string @FAC04AA, string @FAC04MM, string @FAC04NRODOC, string @FAC04SERIEDOC, string @FAC04FECHA, string @FAC04TIPANA,
        string @FAC04CODCLI, string @FAC04MONEDA, double @FAC04TIPCAMBIO, double @FAC04DONSUBTOTAL, double @FAC04DONIGV,
        double @FAC04DONTOTAL, string @FAC02COD, string @FAC03COD, string @FAC03TIPART, string @FAC04CLINOMBRE, string @FAC04CLIDIRECCION,
        string @FAC04CLIRUC, string @FAC04GLOSA, string @FAC04DONGLAG, double @FAC04IGV, string @FAC04GUIAS, string @FAC04DOCMODTIPDOC,
        string @FAC04DOCMODNRO, string @FAC04DOCMODFECHA, string @FAC04TIPMOTEMI, string @FAC04TIPMOTEMIDES, string @FAC04EXPCONOEMBARQUE,
        string @FAC04EXPCODPAISORIGEN, string @FAC04EXPCODPAISDESTINO, string @FAC04EXPCODCONDPAGO,
        string @FAC04EXPCODCONDDESPACHO, string @FAC04EXPCODPUERTO, string @FAC04EXPCODPUERTODES, string @FAC04EXPCODBCOLOCAL, string @FAC04EXPCDDOCCRED, string @FAC04EXPLCEMITIDA,
        string @FAC04EXPBANKCODE, string @FAC04EXPNUMCUENTA, string @FAC04EXPNROCONTAINER, string @FAC04EXPNROPRECINTO, string @FAC04ORDENCOMPRA,
        string @FAC04FECORDCOMPRA, string @FAC04CODTIPOVENTA, string @FAC04ESTADODEPROCESO, string @FAC04TIENDA, double @FAC04DESCUENTOGLOBAL,
        string @FAC04FETIPONOTA, string @FAC04LIQUIDACIONNRO, string @FAC04FETIPODEOPERACION, string @FAC04FECODIGOANEXOEMISOR,
        string @FAC04FORMAPAGOSUNAT, int FAC04FORMAPAGOSUNATCUOTAS, int FAC04FORMAPAGOSUNATDIAS,
        string @FAC04FECODBIENOSERVDETRACCION, double @FAC04FEPORCEDETRACCION, double @FAC04FETOTALDETRACCION,
        string @FAC04VENDEDORCOD,string @FAC04VENDEDORNOMBRE,
        string @XMLdetalle, out int @flag, out string @msgretorno);
        

        [SprocName("Spu_Fact_Ins_CopiaGuiaRemision")]
        public abstract void Spu_Fact_Ins_CopiaGuiaRemision(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, string @FAC34SERIEGUIA,
        string @FAC34CORRELATIVOGUIA, string @FAC34AA, string @FAC34MM, string @FAC34FECHA, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FacturaEstadoPago")]
        public abstract void Spu_Fact_Upd_FacturaEstadoPago(string @empresa, string @tipoDocumento, string @numeroDocumento,
        string @estadoPago, out int @flag, out string @mensaje);

        [SprocName("Spu_Fact_Trae_ClientesConLineaCredito")]
        public abstract List<CuentaCorriente> Spu_Fact_Trae_ClientesConLineaCredito(string @ccm02emp, string @ccm02tipana);

        [SprocName("Spu_Fact_Trae_FacxCliLineaCredito")]
        public abstract List<Spu_Fact_Trae_FacxCliLineaCredito> Spu_Fact_Trae_FacxCliLineaCredito(string @FAC04CODEMP,
        string @FAC01COD, string @FAC04CODCLI);

        [SprocName("Spu_Fact_Upd_InformarSecret")]
        public abstract void Spu_Fact_Upd_InformarSecret(string @empresa, string @tipoDocumento, string @numeroDocumento,
        string @informarSecrex, out int @flag, out string @mensaje);

        [SprocName("Spu_Fac_Trae_DevolucionCab")]
        public abstract List<Devolucion> Spu_Fac_Trae_DevolucionCab(string @IN06CODEMP, string @IN06AA,
        string @IN06MMINICIAL, string @IN06MMFINAL);

        [SprocName("Spu_Fac_Trae_DevolucionDet")]
        public abstract List<Devolucion> Spu_Fac_Trae_DevolucionDet(string @IN06CODEMP, string @IN06AA,
        string @IN07MM, string @IN06TIPDOC, string @IN06CODDOC);

        [SprocName("Spu_Pro_Trae_StockDetMPFiltrado")]
        public abstract List<Spu_Inv_Trae_StockDetMPTodos> Spu_Pro_Trae_StockDetMPFiltrado(string @IN07CODEMP, string @IN07CODALM,
            string @filtro, string @campo);

        [SprocName("Spu_Fac_Trae_AnticiposPorAplicar")]
        public abstract List<TraeAnticiposPorAplicar> Spu_Fac_Trae_AnticiposPorAplicar(string @FAC04CODEMP, string @FAC04CODCLI);
        [SprocName("Spu_Fac_Ins_AnticiposPorAplicar")]
        public abstract void Spu_Fac_Ins_AnticiposPorAplicar(string @FAC04CODEMP, string @FAC01COD, 
        string @FAC04NUMDOC, string @xmlAnticipos, out string @mensaje, out int @flag);

        [SprocName("Spu_Fac_Del_FacturaAnticipo")]
        public abstract void Spu_Fac_Del_FacturaAnticipo(string @FAC75CODEMP, string @FAC75CODFACTPRINCIPAL,
            string @FAC75NUMDOCFACTPRINCIPAL, int @FAC75ITEM, out string @mensaje, out int @flag);
        
        
        [SprocName("Spu_Com_Trae_DimeExisteMovimiento")]
        public abstract void Spu_Com_Trae_DimeExisteMovimiento(string @cEmpresa,  string @cAno,  string @cMes,  string @cTipdoc,  
        string @cCoddoc,  out float @nRegistros);

        #endregion


        [SprocName("Spu_Inv_Rep_MovimientosSuministro")]
        public abstract DataTable Spu_Inv_Rep_MovimientosSuministro(string @CodEmp, string @Ano, string @Mes, string @XMLRango);

        [SprocName("Spu_Inv_Trae_ResExpSalMPDet")]
        public abstract DataTable TraeRepResExpSalMPDet(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango);

        [SprocName("sp_Inv_Dame_Numero_Documento")]
        public abstract void sp_Inv_Dame_Numero_Documento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
                                                          out string @cNumDoc);


        [SprocName("sp_Inv_Calculo_Stock_Y_Costos")]
        public abstract void sp_Inv_Calculo_Stock_Y_Costos(string @cCodEmp, string @cAno, string @cMes, out string @cMsgRetorno);



		[SprocName("Spu_Fac_Ins_GuiasImportar")]
        public abstract void Spu_Fac_Ins_GuiasImportar(string @Empresa,
string @Anio ,
string @Mes ,
int @Contador ,
int @Item , 
double @CANTIDAD ,
string @UNIMED  ,
string @PRODUCTO , 
double @PESO ,
string @FECHA ,
string @GUIA_SERIE ,
string @GUIA_NRO ,
string @MOTIVO_DEL_TRASLADO ,
string @DOMICILIO_DE_PARTIDA ,
string @DOMICILIO_DE_DESTINO  ,
string @CLIENTE_RUC  ,
string @CLIENTE ,
string @TRANSPORTISTA_RUC  ,
string @TRANSPORTISTA ,
string @LICENCIA_CONDUCTOR_NRO ,
string @CONDUCTOR ,
string @VEHICULO_MARCA  , 
string @VEHICULO_PLACA ,
string @REMOLQUE_MARCA  ,
string @REMOLQUE_PLACA  ,
string @CONTRATISTA ,
string @LABOR  ,
string @USUARIO  ,
out int  @flag ,  
out string @mensaje );


        [SprocName("Spu_Inv_Del_MovimientoAlmacenImportado")]
        public abstract void Spu_Inv_Del_MovimientoAlmacenImportado(string @Empresa, string @USUARIO);


        //Guarda txt leido
        [SprocName("Spu_Inv_Ins_MovimientoAlmacenImportado")]
        public abstract void Spu_Inv_Ins_MovimientoAlmacenImportado(string @Empresa, string @Anio, string @Mes, int @contador, string @DOCUMENTO_FECHA,
        string @DOCUMENTO_TIPO, string @DOCUMENTO_NUMERO, string @DOCUMENTO_TIPOOPERACION,
        double @ENTRADA_CANTIDAD, double @ENTRADA_COSTOUNITARIO, double @ENTRADA_COSTOTOTAL, double @SALIDA_CANTIDAD, double @SALIDA_COSTOUNITARIO,
        double @SALIDA_COSTOTOTAL, double @SALDOFINAL_CANTIDAD, double @SALDOFINAL_COSTOUNITARIO, double @SALDOFINAL_COSTOTOTAL,
        string @ALMACEN, string @PRODUCTO_CODIGOCONTASIS, string @PRODUCTO_DESCRIPCIONCONTASIS, string @PRODUCTO_UNIMED,
        string @PRODUCTO_CODIGOTRAVER, string @PRODUCTO_CODIGOSAP,
        string @RUC, string @RAZONSOCIAL, string @ORDENDECOMPRA, string @COMENTARIOS, string @CAMPOADICIONAL1, string @CAMPOADICIONAL2,
        string @USUARIO, out int @flag, out string @mensaje);

        //traer txt guardado en temporal
        [SprocName("Spu_Inv_Trae_MovimientoAlmacenImportado")]
        public abstract DataTable Spu_Inv_Trae_MovimientoAlmacenImportado(string @Empresa, string @USUARIO);


        //Validar guardado en temporal
        [SprocName("Spu_Inv_Trae_ValImpMovAlmacen")]
        public abstract DataTable Spu_Inv_Trae_ValImpMovAlmacen(string @Empresa, string @Anio, string @Mes, string @Usuario);

        //Guardar en tablas originales
        [SprocName("Spu_Inv_Ins_ImpMovAlmacen")]
        public abstract void Spu_Inv_Ins_ImpMovAlmacen(string @Empresa, string @Anio, string @Mes, string @Usuario, out int @flag, out string @Msgretorno);

        [SprocName("Spu_Inv_Del_MovimientoSuministroBloque")]
        public abstract void Spu_Inv_Del_MovimientoSuministroBloque(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango, out int @flag, out string @mensaje);

        //CENTRO COSTO 

        [SprocName("sp_Inv_Trae_Centros_Costo")]
        public abstract DataTable Trae_Centros_Costo(string @cCodEmp, string @ccb02aa);

        //IMPORTAR MATERIA PRIMA CABECERA
        [SprocName("sp_Inv_Ins_Importa_MPCab")]
        public abstract string ImportarMPCab(string @cCodEmp,string @cAnno,string @cMes,string @cTipoDocu,string @cDocumento,string @dFechaDoc,      
string @cCodTra,      
string @cTransac,      
string @cMoneda,      
float @nTipoCambio,      
string @cProveedor,      
string @cCliente,      
string @cCenCosto,      
string @cResponsable,      
string @cObra,      
string @cMaquinas,      
string @cLotes,      
string @cPedidos,      
string @cAlmaEm,      
string @cAlmaRe,      
out string  @cDocuNumer,
 out string @cMsgRetorno  
            
            );
        //IMPORTAR MATERIA PRIMA DETALLE
        [SprocName("Sp_Inv_Ins_Importa_MP")]
        public abstract string ImportarMPDetalle(
string @cCodEmp,          
string @cAnno       ,          
string @cMes        ,          
string @cTipDoc     ,          
string @cNumDoc     ,          
string @cKey        ,          
string @cCodAlm     ,          
string @cCodTra     ,          
string @cTransa     ,          
float@nCanArt     ,          
float @nCosUni     ,          
float @nImport     ,          
string @dFechaDoc  ,          
float @nTipoCambio ,          
string @cMoneda    ,          
float @nOrden      ,          
string @cUnidad     ,          
string @IN07CODBLOQUEEMP ,          
string @IN07CODBLOQUEPROV ,          
decimal @IN07LARGO  ,          
decimal @IN07ANCHO  ,          
decimal @IN07ALTO  ,          
decimal @IN07LARGOCAN ,          
decimal @IN07ANCHOCAN ,          
decimal @IN07ALTOCAN  ,          
string @IN07STATUS  ,          
out string @cMsgRetorno 
            );



        //IMPORTAR CABECERA DOCUMENTO
        [SprocName("sp_Inv_Ins_Cabecera_Documento")]
        public abstract string ImportarCabDOCU(string @cCodEmp,
string @cAnno,
string @cMes,
string @cTipoDocu,
string @cDocumento,
string @dFechaDoc,
string @cCodTra,
string @cTransac,
string @cMoneda,
float @nTipoCambio,
string @cProveedor,
string @cCliente,
string @cCenCosto,
string @cResponsable,
string @cObra,
string @cMaquinas,
string @cLotes,
string @cPedidos,
string @cAlmaEm,
string @cAlmaRe,
string @IN06PRODNATURALEZA,
out string @cDocuNumer,
out string @cMsgRetorno);


        [SprocName("sp_Inv_Ins_Detalle_Documento_Can")]
        public abstract string ImportarDETDOCU(string @cCodEmp,
string @cAnno,
string @cMes,
string @cTipDoc,
string @cNumDoc,
string @cKey,
string @cCodAlm,
string @cCodTra,
string @cTransa,
float @nCanArt,
float @nCosUni,
float @nImport,
string @dFechaDoc,
float @nTipoCambio,
string @cMoneda,
float @nOrden,
string @cUnidad,
string @IN07CODBLOQUEEMP ,          
string @IN07CODBLOQUEPROV ,          
decimal @IN07LARGO  ,          
decimal @IN07ANCHO  ,          
decimal @IN07ALTO  ,          
decimal @IN07LARGOCAN ,          
decimal @IN07ANCHOCAN ,          
decimal @IN07ALTOCAN  ,
string @IN07STATUS ,

string @IN07NROCAJA,
string @IN07ORDPROD,
string @IN07PEDVEN,
string @IN07DocIngAA,
string @IN07DocIngMM,
string @IN07DocIngTIPDOC,
string @IN07DocIngCODDOC,
string @IN07DocIngKEY,
float @IN07DocIngORDEN,
string @IN07FLAGSTOCKREAL,
string @IN07PROVMATPRIMA,
float @IN07AREAXUNI,
string @in07pedvennum,
string @in07pedvencodprod,
float @in07pedvenitem,
string @IN07CODCLI,
string @in07observacion,
string @IN07ORDENTRABAJO,
string @IN07CALIDADMP,

out int @flagReturn  ,              
out string @cMsgRetorno 
            );

  
    }
}

