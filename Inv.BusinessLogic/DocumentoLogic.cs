using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Transactions;
using System.Data;
using System.Collections;
using Inv.BusinessEntities.DTO;
namespace Inv.BusinessLogic
{
    public class DocumentoLogic
    {
        //public ImportarMP importarMP = new ImportarMP();
        #region Singleton
        private static volatile DocumentoLogic instance;
        private static object syncRoot = new Object();

        private DocumentoLogic() { }

        public static DocumentoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DocumentoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public void InsertarDocumento(Documento documento, out string @cDocuNumer, out string @cMsgRetorno, string @numeroDocIngreso = "")
        {
            @cDocuNumer = string.Empty;
            @cMsgRetorno = string.Empty;
            Accessor.InsertarDocumento(documento.CodigoEmpresa, 
                                        documento.Anio, 
                                        documento.Mes, documento.TipoDoc, documento.ReferenciaDoc, 
                                        string.Format("{0:yyyyMMdd}", documento.FechaDoc),
                                        documento.CodigoTransa, documento.Transaccion, documento.Moneda, documento.TipoCambio, documento.CodigoProveedor,
                                        documento.CodigoCliente , documento.CodigoCentroCosto , documento.Responsable , documento.ResponsableReceptor, documento.CodigoObra ,
                                        documento.CodigoMaquina , documento.Lote, documento.Pedido , documento.CodigoAlmacenEmisor , 
                                        documento.CodigoAlmacenReceptor , documento.Observacion ,
                                        documento.Item , documento.AnioItem , documento.OrdenCompra , documento.IN06NOTASALIDAAA  ,documento.IN06NOTASALIDAMM ,
                                        documento.IN06NOTASALIDATIPDOC,documento.IN06NOTASALIDACODDOC, documento.IN06PRODNATURALEZA ,
                                        documento.IN06DOCRESCTACTETIPANA ,
                                        documento.IN06DOCRESCTACTENUMERO,documento.OrigenTipo,
                                        documento.codigoLinea , documento.codigoTurno , documento.codigoActiNivel1,
                                        out cDocuNumer, out cMsgRetorno, @numeroDocIngreso, documento.AnioOrdenCompra);
        }
        public void ActualizarDocumento(Documento documento, out string @cMsgRetorno)
        {
            cMsgRetorno = string.Empty;
            Accessor.ActualizarDocumento(documento.CodigoEmpresa, documento.Anio, documento.Mes, documento.TipoDoc, documento.CodigoDoc, documento.ReferenciaDoc, 
                                         string.Format("{0:yyyyMMdd}", documento.FechaDoc),
                                        documento.CodigoTransa, documento.Transaccion, documento.Moneda, documento.TipoCambio, documento.CodigoProveedor, 
                                        documento.CodigoCliente,
                                        documento.CodigoCentroCosto, documento.Responsable, documento.ResponsableReceptor, documento.CodigoObra, documento.CodigoMaquina,
                                        documento.Lote, documento.Pedido, documento.CodigoAlmacenEmisor, documento.CodigoAlmacenReceptor, documento.Observacion, 
                                        documento.Item,
                                        documento.AnioItem, documento.OrdenCompra,documento.IN06NOTASALIDAAA,documento.IN06NOTASALIDAMM,documento.IN06NOTASALIDATIPDOC,
                                        documento.IN06NOTASALIDACODDOC, documento.IN06DOCRESCTACTETIPANA, documento.IN06DOCRESCTACTENUMERO,
                                        documento.codigoLinea, documento.codigoTurno, documento.codigoActiNivel1, 
                                        documento.AnioOrdenCompra,
                                        out cMsgRetorno);
             
        }

        public void EliminarDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cTranMov,
                                                string @dFechaDoc, double @nTipoCambio, string @cMoneda, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.EliminarDocumento(@cCodEmp, @cAnno, @cMes, @cTipDoc, @cNumDoc, @cTranMov,
                                        @dFechaDoc, @nTipoCambio, @cMoneda, out @cMsgRetorno);
        }


        public List<Documento> TraerDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cOrden, 
                                string @cCampo, string @cFiltro,  string @cVer, string @IN06PRODNATURALEZA)
        {
            return Accessor.TraerDocumento(cCodEmp, cAnno, cMes, cOrden, cCampo, cFiltro, cVer, IN06PRODNATURALEZA);
        }
        public DataTable Spu_Inv_Trae_NotaSalida(string xcodemp)
        {
            return Accessor.Spu_Inv_Trae_NotaSalida(xcodemp);
        }
        public Documento ObtenerDocumento(string @codigoEmpresa, string @anio, string @mes, string @tipoDoc, string @codigoDoc)
        {
            return Accessor.ObtenerDocumento(codigoEmpresa, anio, mes, tipoDoc, codigoDoc);
        }

        public List<Documento> TraeResExpSalMP(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango)
        {
            return Accessor.Spu_Inv_Trae_ResExpSalMP(@IN06CODEMP, @IN06AA, @IN06MM, @XMLrango);
        }

        public List<MovimientoResponse> TraeResExpSalMPDet(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango)
        {
            return Accessor.Spu_Inv_Trae_ResExpSalMPDet(@IN06CODEMP, @IN06AA, @IN06MM, @XMLrango);
        }

        public DataTable TraeRepResExpSalMPDet(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango)
        {
            return Accessor.TraeRepResExpSalMPDet(@IN06CODEMP, @IN06AA, @IN06MM, @XMLrango);

        }

        
        public List<DodcumentoOrdenCompra> TraeAyudaOrdenCompra(string @cCodEmp, string @cAno, string @cMes, string @cTipo,
                                                                        string @cTipAna, string @cCampo, string @cFiltro)
        { 
            return Accessor.TraeAyudaOrdenCompra(@cCodEmp, @cAno, @cMes, @cTipo, @cTipAna, @cCampo, @cFiltro);
        }
        #region  Detalle de documento

        public void InsertarDetalle(Movimiento mov, double tipoCambio, string moneda, out int cflagReturn, out string cMsgRetorno)
        {
            cMsgRetorno = string.Empty;
            Accessor.InsertarDetalle(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, mov.CodigoArticulo, mov.CodigoAlmacen,
                                     mov.CodigoTransaccion, mov.Transaccion, mov.Cantidad, mov.CostoUnidad, mov.Importe, string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY, 
                                     mov.IN07DocIngORDEN,mov.IN07FLAGSTOCKREAL, mov.IN07PROVMATPRIMA,mov.Areaxuni,mov.in07pedvennum, 
                                     mov.in07pedvencodprod,mov.in07pedvenitem, mov.in07codcli, mov.in07observacion,mov.IN07ORDENTRABAJO,
                                     mov.IN07CALIDADMP,
                                     out cflagReturn, out cMsgRetorno);
        }
        public void InsertarDetalleSalMultiple(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC, string @IN07CODDOC,
        string @IN07FECDOC, string @IN07CODALM, string @IN07CODTRA, string @XMLdetalle, out int @Flag, out string @Msgretorno)
        { 
            Accessor.InsertarDetalleSalMultiple(@IN07CODEMP, @IN07AA, @IN07MM, @IN07TIPDOC, @IN07CODDOC, @IN07FECDOC,@IN07CODALM, 
             @IN07CODTRA, @XMLdetalle, out @Flag, out @Msgretorno);
        }

        public void ModificarDetalle(Movimiento mov, double tipoCambio, string moneda, out int cflagReturn, out string cMsgRetorno)
        {
            //Primero elimina el detalle actual     
            //Capturo el nrodeorde
            Accessor.EliminarDetalle(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, mov.CodigoArticulo, mov.Orden, out @cMsgRetorno);

            //Se inserta con el mismo numero de orden
            cMsgRetorno = string.Empty;
            Accessor.InsertarDetalle(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, mov.CodigoArticulo, mov.CodigoAlmacen,
                                     mov.CodigoTransaccion, mov.Transaccion, mov.Cantidad, mov.CostoUnidad, mov.Importe, string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY, mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL,
                                     mov.IN07PROVMATPRIMA, mov.Areaxuni, mov.in07pedvennum, mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli,
                                     mov.in07observacion, mov.IN07ORDENTRABAJO, mov.IN07CALIDADMP,
                                     out cflagReturn,
                                     out cMsgRetorno);

            //    transaction.Complete();
            //}
        }
        public void ActualizarDetalle(Movimiento mov, double tipoCambio, string moneda, out int cflagReturn, out string cMsgRetorno) {
            cMsgRetorno = string.Empty;
            Accessor.ActualizarDetalle(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, mov.CodigoArticulo, mov.CodigoAlmacen,
                                     mov.CodigoTransaccion, mov.Transaccion, mov.Cantidad, mov.CostoUnidad, mov.Importe, string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY, 
                                     mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL,
                                     mov.IN07PROVMATPRIMA, mov.Areaxuni, mov.in07pedvennum, mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli,
                                     mov.in07observacion, mov.IN07ORDENTRABAJO, mov.IN07CALIDADMP,
                                     out cflagReturn,
                                     out cMsgRetorno);
        }
        public void EliminarDetalle(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cArticulo, 
            double @IN07ORDEN, out string @cMsgRetorno)
        {
            Accessor.EliminarDetalle(@cCodEmp, @cAnno, @cMes, @cTipDoc, @cNumDoc,@cArticulo, @IN07ORDEN, out @cMsgRetorno);
        }

        public List<MovimientoResponse> TraerMovimiento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
            string @cNumDoc, string @IN07ORDENTRABAJO)
        {

            return Accessor.TraerMovimiento(cCodEmp, cAnno, cMes, cTipDoc, cNumDoc, IN07ORDENTRABAJO);
        }

        
        public void TraerNroOrden(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cKey, out double @nroorden)
        {
            Accessor.TraerNroOrden(cCodEmp, cAnno, cMes, cTipDoc, cNumDoc, cKey, out nroorden);
        }
        public void TraerAnalisisxDocumentoRespaldo(string @cCodEmp, string @cCodTran, out string @cTipoAnalisis) {
            Accessor.TraerAnalisisxDocumentoRespaldo(@cCodEmp, @cCodTran, out @cTipoAnalisis);
        }
        public List<Movimiento> TraerAyudaStockLinea(string @Empresa)
        {
            return Accessor.Spu_Inv_Traer_StockLinea(@Empresa);
        }

        public List<MovimientoResponse> TraerResumen(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC, 
                                            string @IN07CODDOC, string @IN07ORDENTRABAJO)
        { 
           return  Accessor.Spu_Inv_Traer_StockLineaxDocyOT(@IN07CODEMP, @IN07AA, @IN07MM, @IN07TIPDOC, 
                                                    @IN07CODDOC, @IN07ORDENTRABAJO);
        }

        #endregion
        #region importar
        public void DocumentoImportarInsertar(ImportarDocumento iDoc, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.DocumentoImportarInsertar(
                iDoc.IN07CODEMP,
                iDoc.IN07AA,
                iDoc.IN07MM,
                iDoc.IN07TIPDOC,
                iDoc.IN07CODDOC,
                iDoc.IN07KEY,
                iDoc.IN07ORDEN,
                iDoc.IN07UNIMED,
                iDoc.IN07FECDOC,
                iDoc.IN07CODALM,
                iDoc.IN07TRANSA,
                iDoc.IN07CANART,
                iDoc.IN07COSUNI,
                iDoc.IN07LARGO,
                iDoc.IN07ANCHO,
                iDoc.IN07ALTO,
                iDoc.IN07ORDPROD,
                iDoc.IN07NROCAJA,
                iDoc.IN07PEDVEN,
                iDoc.IN07AREAXUNI,
                iDoc.IN07PROVMATPRIMA,
                iDoc.IN06CODTRA,
                iDoc.IN06REFDOC,
                iDoc.IN06MONEDA,
                iDoc.IN06CODPRO,
                iDoc.IN06CENCOS,
                iDoc.IN06OBRA,
                iDoc.IN07CODCLI,
                iDoc.flag, iDoc.codigousuario,iDoc.sistema,out @cMsgRetorno);

        }
        public void DocumentoImportarEliminar(string @IN07CODEMP,string @usuario,out string @msgretorno)
        {
            Accessor.DocumentoImportarEliminar(@IN07CODEMP, @usuario,out @msgretorno);
        }
        public void DocumentoImportarGenerar(string @IN06CODEMP,string @USUARIO,out string @msgretorno)
        {
            Accessor.DocumentoImportarGenerar(@IN06CODEMP,@USUARIO, out @msgretorno);
        }
        

        public List<ImportarDocumento> TraerImportacion(string empresa, string anio, string mes,string sistema,string usuario)
        {
            return Accessor.TraerImportacion(empresa, anio, mes,sistema,usuario);
        }



        #endregion
        #region "importar Movimientos - Costos
        public void InsertarMovimientosImportados(ImportarMovimientos importacion, out string @msgretorno) 
        {
            @msgretorno = string.Empty;
            Accessor.InsertarMovimientosImportados(
            importacion.IN07CODEMP, importacion.IN07AA, importacion.IN07MM, importacion.IN07TIPDOC, importacion.IN07CODDOC,
            importacion.IN07KEY, importacion.IN07ORDEN, importacion.IN07UNIMED, importacion.IN07FECDOC, 
            importacion.IN07CODALM, importacion.IN07CODTRA, importacion.IN07TRANSA, 
            importacion.IN07CANART, importacion.IN07COSUNI, importacion.IN07COUNSO,
            importacion.IN07COUNDO, importacion.IN07IMPORT, importacion.IN07IMPSOL, importacion.IN07IMPDOL, importacion.IN07COSALM,
            importacion.IN07IMPALM, importacion.IN07COALSO, importacion.IN07IMALSO, importacion.IN07COALDO, importacion.IN07IMALDO,
            importacion.IN07CTAGTO, importacion.IN07CTAING, importacion.IN07LARGO, importacion.IN07ANCHO, importacion.IN07ALTO,
            importacion.IN07LARGOCAN, importacion.IN07ANCHOCAN, importacion.IN07ALTOCAN, importacion.IN07PROMSOL, importacion.IN07PROMDOL,
            importacion.IN07STATUS, importacion.IN07CODBLOQUEEMP, importacion.IN07CODBLOQUEPROV, importacion.IN07PEDVENTA,
            importacion.IN07ORDPROD, importacion.IN07NROCAJA, importacion.IN07PEDVEN, importacion.in07pedvendestino, importacion.IN07DocIngAA,
            importacion.IN07DocIngMM,
            importacion.IN07DocIngTIPDOC, importacion.IN07DocIngCODDOC, importacion.IN07DocIngKEY, importacion.IN07DocIngORDEN, importacion.in07pedvennum,
            importacion.in07pedvencodprod, importacion.in07pedvenitem, importacion.in07observacion, importacion.IN07AREAXUNI, importacion.IN07FLAGSTOCKREAL,
            importacion.IN07PROVMATPRIMA, importacion.IN07CODCLI,
            importacion.IN07ORDENTRABAJO, importacion.IN07OPERADOR, importacion.IN06CODTRA, importacion.IN06REFDOC, importacion.IN06MONEDA,
            importacion.IN06CODPRO, importacion.IN06CENCOS, importacion.IN06OBRA, importacion.FLAG,
            importacion.ERRORES, importacion.CANTERRORES, importacion.CODIGOUSUARIO, importacion.SISTEMA, 
            //Datos de Produccion 
            importacion.IN06MAQUINA, importacion.in06prodlineacod, 
            importacion.in06prodActiNivel1Cod, importacion.IN06CANTERACOD, 
            importacion.IN06CONTRATISTACOD,
            importacion.IN06PRODNATURALEZA, importacion.IN06ORIGENTIPO,
            out @msgretorno);
        }
        public void EliminarMovimientosImportados(string @IN07CODEMP, string @CODIGOUSUARIO, string @SISTEMA) {
            Accessor.EliminarMovimientosImportados(@IN07CODEMP, @CODIGOUSUARIO, @SISTEMA);
        }
        #endregion

        #region Reportes

        public DataTable ReporteDocumento(string @CodEmp, string @Ano, string @Mes)
        {
            return Accessor.ReporteDocumento(CodEmp, Ano, Mes);
        }

        public DataTable RptStockProdter(string @IN07CODEMP, string @IN07CODALM, string @IN07AA, string @in07mm, string @XMLrango)
        {
            return Accessor.RptStockProdter(@IN07CODEMP, @IN07CODALM, @IN07AA, @in07mm, @XMLrango);
        }

        public DataTable RptKardexDet(string @empresa, string @Anio, string @Almacen, string @fechaini, string @fechafin, string @Flag, string @XMLrango)
        {
            return Accessor.RptKardexDet(@empresa, @Anio, @Almacen, @fechaini, @fechafin, @Flag, @XMLrango);
        }

        public DataTable RptKardexSuministros(string @empresa, string @Anio, string @Almacen, string @fechaini, string @fechafin, string @Flag, string @XMLrango,string @sedetipo)
        {
            return Accessor.RptKardexSuministros(@empresa, @Anio, @Almacen, @fechaini, @fechafin, @Flag, @XMLrango,@sedetipo);
        }


        public DataTable RptKardexDetPP(string @empresa, string @Anio, string @Almacen, string @fechaini, string @fechafin, string @Flag, string @XMLrango,string @Naturaleza)
        {
            return Accessor.RptKardexDetPP(@empresa, @Anio, @Almacen, @fechaini, @fechafin, @Flag, @XMLrango,@Naturaleza);
        }

        public DataTable RptControlDevoluciones(string @IN06CODEMP) {
            return Accessor.Spu_Come_Rep_ControlDevoluciones(@IN06CODEMP);
        }
        public DataTable RptStockProdterRes(string @empresa, string @periodo, string @almacen)
        {
            return Accessor.RptStockProdterRes(@empresa, @periodo, @almacen);
        }
        public DataTable RptStocxProvMatPrimakProdterRes(string @empresa, string @periodo, string @almacen)
        {
            return Accessor.RptStocxProvMatPrimakProdterRes(@empresa, @periodo, @almacen);
        }
        
        public DataTable RptKardexRes(string @empresa, string @fechaini, string @fechafin, string @Flag)
        {
            return Accessor.RptKardexRes(@empresa, @fechaini, @fechafin, @Flag);
        }

        public List<Spu_Inv_Rep_Movimientos> RptMovimientoDet(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @Flag, string @Fechaini, string @Fechafin)
        {
            return Accessor.RptMovimientoDet(@IN07CODEMP, @IN07AA, @IN07MM, @Flag, @Fechaini, @Fechafin);
        }

        public List<Spu_Inv_Rep_MovimientosMP> RptMovimientosMP(string @IN07CODEMP, string @IN07AA, string @IN07MM, 
                                                                string @Flag, string @Fechaini, string @Fechafin) 
        {
            return Accessor.RptMovimientosMP( @IN07CODEMP, @IN07AA, @IN07MM, @Flag, @Fechaini, @Fechafin);
        }

        public DataTable TraeArchivoPlanoAlmacen(string @empresa, string @anio, string @mesini, string @mesfin)
        {
            return Accessor.TraeArchivoPlanoAlmacen(@empresa, @anio, @mesini, @mesfin);
        }

        public List<Spu_Inv_Rep_ProdxFabricante> RptProdFabricante(string @IN06CODEMP, string @IN06AA, string @TipAnalisisctacte, string @Flag, string @PeriodoIni, string @PeriodoFin)
        {
            return Accessor.RptProdFabricante(@IN06CODEMP, @IN06AA, @TipAnalisisctacte, @Flag, @PeriodoIni, @PeriodoFin);
        }

        public List<Spu_Inv_Rep_ProvMateriaPrima> RptProvMateriaPrima(string @IN06CODEMP, string @IN06AA, string @TipAnalisisctacte, string @PeriodoIni, string @PeriodoFin)
        {
            return Accessor.RptProvMateriaPrima(@IN06CODEMP, @IN06AA, @TipAnalisisctacte, @PeriodoIni, @PeriodoFin);
        }

        public List<UbicacionFisica> TraerUbicacionFisica(string @IN07CODEMP)
        {
            return Accessor.TraerUbicacionFisica(@IN07CODEMP);
        }

        public void UbicacionFisicaActualizar(UbicacionFisica ubifis, out string flagok, out string cMsgRetorno)
        {
            cMsgRetorno = string.Empty;
            Accessor.UbicacionFisicaActualizar(ubifis.IN07CODEMP, ubifis.IN07UBICACION, ubifis.IN07NROCAJA, ubifis.IN07USUARIO,out flagok, out cMsgRetorno);
        }

        public List<Spu_Inv_Trae_ProductoxNroCaja> TraerProductosxNroCaja(string @cCodEmp,string @XMLrango)
        {
            return Accessor.TraerProductosxNroCaja(@cCodEmp, @XMLrango);
        }
        public DataTable Reporte_ProductosNroCaja(string @cCodEmp, string @XMLrango)
        {
            return Accessor.Reporte_ProductosNroCaja(@cCodEmp, @XMLrango);
        }
        public DataTable Spu_Inv_Ing_Sal(string codemp, string fecnini, string fecfin) {
            return Accessor.Spu_Inv_Ing_Sal(codemp, fecnini, fecfin);
        }
        public DataTable Spu_Inv_Rep_IngresosVsSalidas(string @IN07CODEMP) {
            return Accessor.Spu_Inv_Rep_IngresosVsSalidas(@IN07CODEMP);
        }

        public DataTable Spu_Pro_Rep_BloqueMerma(string @IN07CODEMP, string @FechaIni, string @FechaFin, string @Flag, string @BloqueNro)
        { 
            return Accessor.Spu_Pro_Rep_BloqueMerma(@IN07CODEMP, @FechaIni, @FechaFin, @Flag,@BloqueNro);
        }
        #endregion

        #region "Produccion"
        public void InsertarProduccionCabecera(Documento doc ,
                                             out string @cDocuNumer, out int @flag, out string @cMsgRetorno) 
        {
            Accessor.Spu_Pro_Ins_Produccion(doc.CodigoEmpresa, doc.Anio, doc.Mes, doc.TipoDoc,
                                             string.Format("{0:yyyyMMdd}", doc.FechaDoc), doc.CodigoTransa, doc.Transaccion, doc.ReferenciaDoc,
                                             doc.codigoLinea, doc.codigoTurno, doc.codigoActiNivel1, doc.IN06PRODNATURALEZA, doc.CodigoMaquina,
                                             doc.OrigenTipo, out @cDocuNumer, out @flag,out @cMsgRetorno);
        }
        //lista todo los documento de produccion
        public List<Documento> TraerProduccion(string @cCodEmp, string @cAnno, string @cMes, string @cTransa, string @cNaturaleza)
        {
            return Accessor.Spu_Pro_Trae_Produccion(@cCodEmp, @cAnno, @cMes, @cTransa, @cNaturaleza);
        }

        public void ActualizarProduccionCabecera(Documento doc,  out int @flag, out string @cMsgRetorno)
        {
            Accessor.Spu_Pro_Upd_Produccion(doc.CodigoEmpresa, doc.Anio, doc.Mes, doc.TipoDoc, string.Format("{0:yyyyMMdd}", doc.FechaDoc),
                                            doc.CodigoTransa, doc.Transaccion, doc.ReferenciaDoc, doc.codigoTurno,
                                            doc.IN06PRODNATURALEZA, doc.CodigoMaquina, doc.OrigenTipo, doc.CodigoDoc, 
                                            out @flag,
                                            out @cMsgRetorno);
        }
        /// <summary>
        /// Eliminar la cabecera de documento del produccion
        /// </summary>
        /// <param name="doc">variable tipo documento</param>
        /// <param name="cMsgRetorno">variable de salida para el mensaje sobre el proceso de eliminacion</param>
        public void EliminarProduccionCabecera(Documento doc, out string @cMsgRetorno) {
            Accessor.sp_Inv_Del_CabeceraDocumentoProduccion(doc.CodigoEmpresa, doc.Anio, doc.Mes, doc.TipoDoc, doc.CodigoDoc, out @cMsgRetorno);
        }

        public void InsertarProduccionDetalle(Movimiento mov, string flagnuevoinsercion, out int cflagReturn, out string @cMsgRetorno)
        {
            Accessor.Spu_Pro_Ins_ProduccionDet(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoAlmacen, mov.CodigoDocumento, mov.CodigoArticulo,
                mov.UnidadMedida, string.Format("{0:yyyyMMdd}", mov.FechaDoc, 103), mov.Orden, mov.CodigoTransaccion, mov.Transaccion, mov.Largo, mov.Ancho, mov.Alto,
                mov.Cantidad, mov.NroCaja, mov.in07codcli, mov.OrdenProduccion, mov.Areaxuni, mov.IN07ORDENTRABAJO, mov.operador,
                mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY, mov.IN07DocIngORDEN, mov.IN07HORASALIDA,
                mov.IN07NROCAJAINGRESO, mov.IN07HORAINICIO, mov.IN07HORAFINAL, string.Format("{0:yyyyMMdd}", mov.IN07FECHAPROCESO, 103),
                mov.IN07MOTIVOCOD,
                mov.IN07SECUENCIA, mov.in07prodTurnoCod, mov.IN07DESCABEZADOSUP,
                mov.IN07DESCABEZADOINF, flagnuevoinsercion,
                out cflagReturn,
                out @cMsgRetorno);

        }
        public void ValidarInsertarProduccionDetalle(Movimiento mov, string pflagInsert ,out string @cMensaje, out int @cFlagValidar)
        {            
            Accessor.Spu_Pro_Ins_ProduccionDetValida(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento,
            mov.CodigoDocumento, mov.NroCaja, mov.IN07ORDENTRABAJO, mov.CodigoArticulo, mov.UnidadMedida,
            mov.Largo, mov.Ancho, mov.Alto, mov.Transaccion, mov.Cantidad, mov.Orden, pflagInsert ,
            out @cMensaje, out @cFlagValidar);
        }
        public void ValidarMPSinConsumir(string @IN07CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, 
                                         string @IN06CODDOC, string @IN07ORDENTRABAJO, string @Transaccion, 
                                         string @linea, string @Actividad, out string @cMensaje, 
                                         out int @cFlag)
        {
            Accessor.Spu_Pro_Trae_ValidacionMPSinConsumir(@IN07CODEMP, @IN06AA, @IN06MM,
                                                        @IN06TIPDOC, @IN06CODDOC, @IN07ORDENTRABAJO,
                                                        @Transaccion, @linea, @Actividad, out @cMensaje,
                                                        out @cFlag);
        }
        public void ActualizarProduccionDetalle(Movimiento mov, out int cflagReturn, out string @cMsgRetorno)
        {
            Accessor.Spu_Pro_Upd_ProduccionDet(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoAlmacen, mov.CodigoDocumento, mov.CodigoArticulo,
                mov.Orden, mov.UnidadMedida, string.Format("{0:yyyyMMdd}", mov.FechaDoc, 103), mov.CodigoTransaccion, mov.Transaccion, mov.Largo, mov.Ancho, mov.Alto,
                mov.Cantidad, mov.NroCaja, mov.in07codcli, mov.OrdenProduccion, mov.Areaxuni, mov.IN07ORDENTRABAJO, mov.operador,
                mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY, mov.IN07DocIngORDEN,
                mov.IN07HORASALIDA, mov.IN07NROCAJAINGRESO, mov.IN07HORAINICIO, mov.IN07HORAFINAL, string.Format("{0:yyyyMMdd}", mov.IN07FECHAPROCESO, 103),
                mov.IN07MOTIVOCOD, mov.in07prodTurnoCod, mov.IN07DESCABEZADOSUP, mov.IN07DESCABEZADOINF,
                out cflagReturn,
                out @cMsgRetorno);
        }

        public List<MovimientoResponse> TraerProduccionDetalle(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, 
                                                                string @IN07ORDENTRABAJO)
        {
            return Accessor.sp_Pro_Trae_DetalleProduccion(@cCodEmp, @cAnno, @cMes, @cTipDoc, @cNumDoc, @IN07ORDENTRABAJO);
        }
        /*Eliminar un registro de la grilla del documento (gridControL) */
        public void EliminarProduccionDetalle(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cTranMov,
                                                            string @dFechaDoc, string @cArticulo, string @cUniMed,
                                                            double @IN07ORDEN, out string @cMsgRetorno) { 
            Accessor.sp_Pro_Del_DetalleProduccion(@cCodEmp, @cAnno, @cMes, @cTipDoc, @cNumDoc, @cTranMov,
                                                            @dFechaDoc, @cArticulo, @cUniMed, 
                                                            @IN07ORDEN, out @cMsgRetorno);

        }
        public void ModificarProduccionDetalle(Movimiento mov, out int cflagReturn, out string cMsgRetorno) {

            //EliminarProduccionDetalle(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, mov.Transaccion,
            //    string.Format("{0:yyyyMMdd}", mov.FechaDoc), mov.CodigoArticulo, mov.UnidadMedida, mov.Orden, out cMsgRetorno);
            //cMsgRetorno = string.Empty;

            //InsertarProduccionDetalle(mov, out cflagReturn, out cMsgRetorno);
            ActualizarProduccionDetalle(mov, out cflagReturn, out cMsgRetorno);
        }

        public  List<Spu_Pro_Trae_PPStock> TraerCanastillaMP(string @IN07CODEMP, string @IN07CODALM){
            return Accessor.Spu_Pro_Trae_PPStock(@IN07CODEMP, @IN07CODALM);
        }
        public List<Spu_Pro_Trae_PPStock> TraerStockPPxAlmacen(string @IN07CODEMP, string @IN07CODALM) 
        {
            //return Accessor.Spu_Pro_Trae_StockPPxAlmacen(@IN07CODEMP, @IN07CODALM);
            return Accessor.Spu_Pro_Trae_PPStock(@IN07CODEMP, @IN07CODALM);
        }
            //return Spu_Pro_Trae_PPStock
        public void SalidasProductosProduccion(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06FECDOC, string @OTNUMERO,
                                                string @IN06ORIGENTIPO, string @XMLdetalle,
                                                string @FlagValidacion, out string @FlagDeretorno,
                                                out string @msgretorno)
        {
            Accessor.Spu_Pro_Ins_SalidasPP(@IN06CODEMP, @IN06AA, @IN06MM, @IN06FECDOC, @OTNUMERO, @IN06ORIGENTIPO,
                                            @XMLdetalle, @FlagValidacion, out @FlagDeretorno, out @msgretorno);
        }
        public void TraerValidacionSalidasPP(string cXMLdetalle, string cFlagValidacion, out string cFlagDeretorno, out string cmsgretorno)
        {
            Accessor.Spu_Pro_Trae_ValidacionSalidasPP(cXMLdetalle, cFlagValidacion, out cFlagDeretorno, out cmsgretorno);
        }
        public List<Movimiento> TraerMateriaPrimaxOT(string @IN07CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, string @IN06CODDOC,
                                                                    string @IN07ORDENTRABAJO)
        {
            return Accessor.Spu_Pro_trae_MatPrimaxOT(@IN07CODEMP,   @IN06AA,@IN06MM,@IN06TIPDOC,@IN06CODDOC, 
                                                                    @IN07ORDENTRABAJO);
        }
        //revisar como actualizar el stock de invetario.
        public void EliminarMateriaPrima(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @N06TIPDOC, string @IN06CODDOC,
                                        string @IN07NROCAJA, string @IN07ORDENTRABAJO,out string @cMsgRetorno) { 
           
                Accessor.Spu_Pro_Del_SalidasPP( @IN06CODEMP, @IN06AA, @IN06MM, @N06TIPDOC, @IN06CODDOC,
                                                @IN07NROCAJA, @IN07ORDENTRABAJO, out @cMsgRetorno);
        }
        public List<MovimientoResponse> TraerTodosDetalleProduccion(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc) { 
            return Accessor.sp_Pro_Trae_TodosDetalleProduccion(@cCodEmp, @cAnno, @cMes, @cTipDoc, @cNumDoc);
        }

        public List<Spu_Inv_Trae_StockDetMPTodos> TraerMateriaPrimaTodos(string @IN07CODEMP, string @IN07CODALM)
        {
            return Accessor.Spu_Inv_Trae_StockDetMPTodos(@IN07CODEMP, @IN07CODALM);
        }
        public DataTable RptMateriaPrimaStock(string @empresa, string @periodo, string @almacen, string @flagfiltro, string @XMLrango) 
        {
            return Accessor.Spu_Inv_Rep_StockMP(@empresa, @periodo, @almacen, @flagfiltro, @XMLrango);
        }

        public DataTable RptStockSuministros(string @empresa, string @anio, string @mes, string @almacen, string @Flag, string @XMLrango)
        {
            return Accessor.Spu_Inv_Rep_StockSUM(@empresa, @anio, @mes, @almacen, @Flag, @XMLrango);
        }

        public DataTable Spu_Inv_Rep_StockSuministrosVal(string @empresa, string @Anio, string @Mes, string @Almacen, string @Moneda, string @XMLrango)
        {
            return Accessor.Spu_Inv_Rep_StockSuministrosVal(@empresa, @Anio, @Mes, @Almacen, @Moneda, @XMLrango);
        }

               
       public DataTable RptProductoProcesoStock(string @empresa, string @anio, string @mes, string @almacen, string @XMLrango)
        {
            return Accessor.Spu_Inv_Rep_StockPP(@empresa, @anio,@mes, @almacen, @XMLrango);
        }
        public Movimiento TraerMateriaPrimaRegistro(string @IN07CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC, string @IN06CODDOC,
                                                                    string @IN07ORDENTRABAJO, string @IN07NROCAJA){
            return Accessor.Spu_Pro_trae_MateriaPrimaRegistro(@IN07CODEMP, @IN06AA, @IN06MM, @IN06TIPDOC, @IN06CODDOC, @IN07ORDENTRABAJO, @IN07NROCAJA);
        }

        public List<Spu_Pro_Trae_CajaSeguimineto> TraerSeguimientosCajas(string @IN07CODEMP, string @Fechaini, string @FechaFin, string @IN07NROCAJA) 
        {
            return Accessor.TraerSeguimientosCajas(@IN07CODEMP, @Fechaini, @FechaFin, @IN07NROCAJA);
        }

        public void InsertarSalidasxRegularizacion(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango,string @IN06PRODNATURALEZA,
                                                        out int @cFlag, out string @cMensaje)
        {
            Accessor.Spu_Pro_Ins_GenerarSalidas(@IN06CODEMP, @IN06AA, @IN06MM, @XMLrango,@IN06PRODNATURALEZA,
                                                        out @cFlag, out @cMensaje);
        }
        public List<Spu_Pro_Trae_CajaSeguimineto> TraerMovimientosCajas(string @IN07CODEMP, string @Fechaini, string @FechaFin, string @IN07NROCAJA) 
        {
            return Accessor.TraerMovimientosCajas(@IN07CODEMP, @Fechaini, @FechaFin, @IN07NROCAJA);
        }
        public List<Movimiento> TraerDetallexNroCaja(string @IN07CODEMP, string @IN07KEY,
                                                            string @IN07NROCAJA, string @IN07CODALM)
        { 
            return Accessor.TraerDetallexNroCaja(@IN07CODEMP, @IN07KEY, @IN07NROCAJA, @IN07CODALM);
        }
        public void InsertarDetalleDocumentoxCanastIng(Movimiento mov, double tipoCambio, string moneda, string IN06ORIGENTIPO, 
                                                               string @xml, out int @flagReturn, out string @cMsgRetorno)
        {
            Accessor.InsertarDetalleDocumentoxCanastIng(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento,
                                     mov.CodigoArticulo, mov.CodigoAlmacen,mov.CodigoTransaccion, mov.Transaccion, mov.Cantidad, 
                                     mov.CostoUnidad, mov.Importe, string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY,
                                     mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL, mov.IN07PROVMATPRIMA, mov.Areaxuni, mov.in07pedvennum,
                                     mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli, mov.in07observacion, mov.IN07ORDENTRABAJO,
                                     mov.IN07NROCAJAINGRESO,
                                     IN06ORIGENTIPO, @xml, out @flagReturn , out @cMsgRetorno); 
        }
        public void InsercionEscalla(string @PRO16CODEMP, string @PRO16BLOQUENRO,
                    double @PRO16BLOQUEANCHO, double @PRO16BLOQUELARGO, double @PRO16BLOQUEALTO, double @PRO16BLOQUEESCLAT1,
                    double @PRO16BLOQUEESCLAT2, double @PRO16BLOQUEESCSUP, string @PRO16BLOQUELADODELCORTE,
                    string @PRO16ESCALLAALMACENCOD, string @PRO16ESCALLAPRODUCTOCOD, string @PRO16COSTRAALMACENCOD,
                    string @PRO16COSTRAPRODUCTOCOD, double @PRO16BLOQUEALTOCOSTRA,
                    string @XmlDetalle, out string @MsgRetorno, out int @Flag)
        {
            Accessor.InsercionEscalla(@PRO16CODEMP, @PRO16BLOQUENRO,
            @PRO16BLOQUEANCHO, @PRO16BLOQUELARGO, @PRO16BLOQUEALTO, @PRO16BLOQUEESCLAT1,
            @PRO16BLOQUEESCLAT2, @PRO16BLOQUEESCSUP, @PRO16BLOQUELADODELCORTE,
            @PRO16ESCALLAALMACENCOD, @PRO16ESCALLAPRODUCTOCOD, @PRO16COSTRAALMACENCOD,
            @PRO16COSTRAPRODUCTOCOD, @PRO16BLOQUEALTOCOSTRA, @XmlDetalle, out @MsgRetorno, out @Flag);
        }
        public List<BloqueCorteDetalle> TraerEscalla(string @PRO16CODEMP, string @PRO16AA,
                                            string @PRO16BLOQUENRO)
        {
            return Accessor.Spu_Pro_Traer_Escalla(@PRO16CODEMP, @PRO16AA, @PRO16BLOQUENRO);
        }
        //public List<BloqueCorteDetalle> TraerEscalla(string @PRO16CODEMP, string @PRO16AA, string @PRO16MM, string @PRO16TIPDOC, 
        //                                            string @PRO16CODDOC, string @PRO16KEY)
        //{
        //    return Accessor.Spu_Pro_Traer_Escalla(@PRO16CODEMP, @PRO16AA, @PRO16MM, @PRO16TIPDOC, @PRO16CODDOC, @PRO16KEY);
        //}


        public void EliminarEscalla(string @PRO16CODEMP, string @PRO16BLOQUENRO, int @PRO16CORRELATIVO, out int @cFlag, out string @cMsgRetorno)
        {
            Accessor.Spu_Pro_Del_Escalla(@PRO16CODEMP, @PRO16BLOQUENRO, @PRO16CORRELATIVO, out @cFlag, out @cMsgRetorno);
        }
        

        public void TraerCodProdGeneradoxBloqueMP(string @cEmpresa, string @cCodModulo,
                                string @cCodigoGlobal, string @cMPCodigo, out string @cProductonuevo)
        { 
            Accessor.Spu_Pro_Trae_CodigoGeneradoProducto(@cEmpresa, @cCodModulo, @cCodigoGlobal, 
                                                                @cMPCodigo, out @cProductonuevo);
        }
        public DataTable TraerReportIngVsCortes(string @IN07CODEMP, string @perini, string @perfin)
        {
            return Accessor.Spu_Inv_Rep_MPIngVCortes(@IN07CODEMP, @perini, @perfin);
        }
        public  List<MovimientoResponse> TraerSaldoxOT(string @IN07CODEMP, string @IN06AA,
                                            string @IN06MM, string @IN06TIPDOC,
                                            string @IN06CODDOC, string @IN07ORDENTRABAJO,
                                            string @IN07CODALM)
        { 
            return Accessor.TraerSaldoxOT(@IN07CODEMP, @IN06AA,@IN06MM, 
                                          @IN06TIPDOC,@IN06CODDOC, 
                                          @IN07ORDENTRABAJO,@IN07CODALM);
        }
       //validacion de existencia de articulo en almacen
        public void TraerValidacionArtixAlm(string @Empresa, string @Mes, string @Anio, 
            string @Almacen, string @ArticuloIn, out string @ArticuloOut)
        {

            Accessor.Spu_Pro_Traer_ExistenciaArticuloxAlmacen(@Empresa, @Mes, @Anio, @Almacen, @ArticuloIn, out @ArticuloOut);
        }
        public void ActualizarResumenxFlag(Movimiento mov, string almacennuevo, string nrocajanuevo,string HoraSalidaNueva,
            string productonuevo, string @FlagCampoaActualizar,  out int @flagReturn, out string @cMsgRetorno)
        { 
            Accessor.Spu_Pro_Upd_CambiarDeAlmacen(mov.CodigoEmpresa, mov.Anio,
            mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, mov.CodigoArticulo,
         mov.IN07ORDENTRABAJO, mov.CodigoAlmacen, mov.NroCaja, mov.IN07HORASALIDA,
         almacennuevo,nrocajanuevo, productonuevo,HoraSalidaNueva, 
         FlagCampoaActualizar,out @flagReturn, out @cMsgRetorno);
        }
        #endregion

        #region "Documento MP"
        public void InsertarDocumentoMP(Documento documento,out string @cDocuNumer, out string @cMsgRetorno) {
                    Accessor.Spu_Inv_Ins_Cabecera_Documento_MP(documento.CodigoEmpresa, documento.Anio, documento.Mes, documento.TipoDoc, documento.ReferenciaDoc,
                             string.Format("{0:yyyyMMdd}", documento.FechaDoc), documento.CodigoTransa, documento.Transaccion, documento.Moneda, documento.TipoCambio,                  
                             documento.CodigoProveedor, documento.CodigoCliente, documento.CodigoCentroCosto, documento.Responsable, documento.ResponsableReceptor, 
                             documento.CodigoObra, documento.CodigoMaquina, documento.Lote, documento.Pedido, documento.CodigoAlmacenEmisor, 
                             documento.CodigoAlmacenReceptor, documento.Observacion, documento.Item, documento.AnioItem, documento.OrdenCompra, documento.IN06NOTASALIDAAA,     
                             documento.IN06NOTASALIDAMM,documento.IN06NOTASALIDATIPDOC, documento.IN06NOTASALIDACODDOC, documento.IN06CANTERACOD, 
                             documento.IN06CONTRATISTACOD, documento.IN06PRODNATURALEZA, documento.IN06DOCRESCTACTETIPANA,
                             documento.IN06DOCRESCTACTENUMERO, documento.OrigenTipo,
                             out @cDocuNumer, out @cMsgRetorno);
             
        }
        public void ActualizarDocumentoMP(Documento documento, out string @cMsgRetorno)
        {
            Accessor.Spu_Inv_Upd_Cabecera_Documento_MP(documento.CodigoEmpresa, documento.Anio, documento.Mes, documento.TipoDoc, 
                                        documento.CodigoDoc, documento.ReferenciaDoc, string.Format("{0:yyyyMMdd}", documento.FechaDoc),
                                        documento.CodigoTransa, documento.Transaccion, documento.Moneda, 
                                        documento.TipoCambio, documento.CodigoProveedor, documento.CodigoCliente,
                                        documento.CodigoCentroCosto, documento.Responsable, documento.ResponsableReceptor, 
                                        documento.CodigoObra, documento.CodigoMaquina, documento.Lote, documento.Pedido, 
                                        documento.CodigoAlmacenEmisor,documento.CodigoAlmacenReceptor, documento.Observacion, documento.Item,
                                        documento.AnioItem, documento.OrdenCompra, documento.IN06NOTASALIDAAA, documento.IN06NOTASALIDAMM, 
                                        documento.IN06NOTASALIDATIPDOC, documento.IN06NOTASALIDACODDOC,documento.IN06CANTERACOD, 
                                        documento.IN06CONTRATISTACOD, documento.IN06DOCRESCTACTETIPANA,
                                        documento.IN06DOCRESCTACTENUMERO , out @cMsgRetorno);
        }
        public void InsertarDetalleMP(Movimiento mov, double tipoCambio, string moneda, out int cflagReturn, out string cMsgRetorno)
        {
            cMsgRetorno = string.Empty;
            Accessor.sp_Inv_Ins_Detalle_Documento_MP(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, 
                                     mov.CodigoDocumento, mov.CodigoArticulo, mov.CodigoAlmacen, mov.CodigoTransaccion, 
                                     mov.Transaccion, mov.Cantidad, mov.CostoUnidad, mov.Importe, 
                                     string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, 
                                     mov.IN07DocIngCODDOC, mov.IN07DocIngKEY,
                                     mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL,
                                     mov.IN07PROVMATPRIMA, mov.Areaxuni, mov.in07pedvennum, 
                                     mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli,
                                     mov.in07observacion, mov.IN07MOTIVOCOD,
                                     out cflagReturn, out cMsgRetorno);
            
        }

        public void ActualizarDetalleMP(Movimiento mov, double tipoCambio, string moneda, out int cflagReturn, out string cMsgRetorno)
        {
            cMsgRetorno = string.Empty;
            Accessor.sp_Inv_Upd_DetalleDocumentoMP(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, mov.CodigoArticulo,
                mov.CodigoAlmacen,
                                     mov.CodigoTransaccion, mov.Transaccion, mov.Cantidad, mov.CostoUnidad, mov.Importe, string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY,
                                     mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL,
                                     mov.IN07PROVMATPRIMA, mov.Areaxuni, mov.in07pedvennum, mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli,
                                     mov.in07observacion, mov.IN07MOTIVOCOD, out cflagReturn, out cMsgRetorno);
        }
        public void ValidaInsertarDetalleMP(Movimiento mov, double tipoCambio, string moneda, string @FlagValida, 
                                        out string @FlagValidaRetorna , out int cflagReturn, out string cMsgRetorno)
        {
            Accessor.Spu_Inv_Ins_ValidaDetalleDocumentoMP(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento,
                                     mov.CodigoDocumento, mov.CodigoArticulo, mov.CodigoAlmacen, mov.CodigoTransaccion,
                                     mov.Transaccion, mov.Cantidad, mov.CostoUnidad, mov.Importe,
                                     string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC,
                                     mov.IN07DocIngCODDOC, mov.IN07DocIngKEY,
                                     mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL,
                                     mov.IN07PROVMATPRIMA, mov.Areaxuni, mov.in07pedvennum,
                                     mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli,
                                     mov.in07observacion, @FlagValida, out @FlagValidaRetorna,
                                     out cflagReturn, out cMsgRetorno);
        }

        public void ValidarActualizarDetalleMP(Movimiento mov, double tipoCambio, string moneda, string @FlagValida,
                                        out string @FlagValidaRetorna, out int cflagReturn, out string cMsgRetorno) 
        {
            Accessor.Spu_Inv_Upd_ValidaDetalleDocumentoMP(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento,
                                     mov.CodigoDocumento, mov.CodigoArticulo, mov.CodigoAlmacen, mov.CodigoTransaccion,
                                     mov.Transaccion, mov.Cantidad, mov.CostoUnidad, mov.Importe,
                                     string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                     tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                     mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                     mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                     mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC,
                                     mov.IN07DocIngCODDOC, mov.IN07DocIngKEY,
                                     mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL,
                                     mov.IN07PROVMATPRIMA, mov.Areaxuni, mov.in07pedvennum,
                                     mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli,
                                     mov.in07observacion, @FlagValida, out @FlagValidaRetorna,
                                     out cflagReturn, out cMsgRetorno);
        }
           
        public void EliminarDetalleMP(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc, string @cNumDoc, string @cTranMov, 
                                                            string @dFechaDoc, double @nTipoCambio, string @cMoneda, string @cAlmacen, 
                                                            string @cArticulo, string @cUniMed, double @cCantidad, double @cCosto,
                                                            double @IN07ORDEN, out string @cMsgRetorno)
        {
            
            Accessor.sp_Inv_Del_Detalles_Documento_MP(@cCodEmp, @cAnno, @cMes, @cTipDoc, @cNumDoc, @cTranMov, 
                                                            @dFechaDoc, @nTipoCambio, @cMoneda, @cAlmacen, 
                                                            @cArticulo, @cUniMed, @cCantidad, @cCosto, @IN07ORDEN, 
                                                            out @cMsgRetorno);
        }

        public void ModificarDetalleMP(Movimiento mov, double tipoCambio, string moneda,  out int cflagReturn, out string cMsgRetorno) 
        {

            Accessor.sp_Inv_Del_Detalles_Documento_MP(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, 
                                                      mov.CodigoDocumento, mov.Transaccion, string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                               tipoCambio, moneda, mov.CodigoAlmacen, mov.CodigoArticulo, mov.UnidadMedida, mov.Cantidad,
                                                mov.CostoUnidad, mov.Orden, out cMsgRetorno);

            Accessor.sp_Inv_Ins_Detalle_Documento_MP(mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento, mov.CodigoDocumento, 
                                                      mov.CodigoArticulo, mov.CodigoAlmacen, mov.CodigoTransaccion, mov.Transaccion, 
                                                      mov.Cantidad, mov.CostoUnidad, mov.Importe, string.Format("{0:yyyyMMdd}", mov.FechaDoc),
                                                      tipoCambio, moneda, mov.Orden, mov.UnidadMedida, mov.CodBloEmp, mov.CodBloqProv,
                                                      mov.Largo, mov.Ancho, mov.Alto, mov.LargoCan, mov.AnchoCan, mov.AltoCan,
                                                      mov.Estado, mov.NroCaja, mov.OrdenProduccion, mov.NroPedidoVenta,
                                                      mov.IN07DocIngAA, mov.IN07DocIngMM, mov.IN07DocIngTIPDOC, mov.IN07DocIngCODDOC, mov.IN07DocIngKEY,
                                                      mov.IN07DocIngORDEN, mov.IN07FLAGSTOCKREAL, mov.IN07PROVMATPRIMA, mov.Areaxuni, 
                                                      mov.in07pedvennum, mov.in07pedvencodprod, mov.in07pedvenitem, mov.in07codcli,mov.in07observacion,
                                                      mov.IN07MOTIVOCOD,
                                                      out cflagReturn, out cMsgRetorno);
        }
        public void TraerCantidadDetallexNroDocumento(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC,
                                                                         string @IN07CODDOC, out int @CANTIDAD) 
        {
            Accessor.Spu_Pro_Traer_CantidadDetallexNroDocumento(@IN07CODEMP, @IN07AA, @IN07MM, @IN07TIPDOC, @IN07CODDOC, out @CANTIDAD);
        }
        public void TraerCantidadOrdenesxNroDocumento(string @PRO13CODEMP, string @PRO13DOCINGALMAA, string @PRO13DOCINGALMMM,
                                                                        string @PRO13DOCINGALMTIPDOC, string @PRO13DOCINGALMCODDOC, out int @CANTIDAD)
        {
           Accessor.Spu_Pro_Traer_CantidadOrdenesxNroDocumento(@PRO13CODEMP, @PRO13DOCINGALMAA,  @PRO13DOCINGALMMM, @PRO13DOCINGALMTIPDOC, @PRO13DOCINGALMCODDOC,
                                                                out @CANTIDAD);
        }

        //Metodo de ingreso masivo a movimiento
        public  void InsertarMoviMasivoTemporal(string @empresa, string @usuario, string @XMLdetalle) {
            Accessor.Spu_Pro_Ins_MoviMasivoTemporal(@empresa, @usuario, @XMLdetalle);
        }
        public void EliminarMovMasivoTemporal(string @empresa, string @usuario)
        {
            Accessor.Spu_Pro_Del_MoviMasivoTemporal(@empresa, @usuario);
        }
        public DataTable cargarMensajeValidacion(string @empresa, string @usuario, string @IN06AA, string @IN06MM, string @IN06TIPDOC,
            string @IN06CODDOC, string @IN07ORDENTRABAJO)
        {
            return Accessor.Spu_Pro_Ins_MoviMasivoValida(empresa, usuario, @IN06AA, @IN06MM, @IN06TIPDOC, @IN06CODDOC, @IN07ORDENTRABAJO);
        }
        public void InsertarMoviMasivo(string @empresa, string @usuario, out string @mensaje) 
        {
            Accessor.Spu_Pro_Ins_MoviMasivo(@empresa, @usuario, out @mensaje);
        }
        public void EliminarSalidasPPLinea(string @IN07CODEMP, string @IN07AA_ING, string @IN07MM_ING, string @IN07TIPDOC_ING,
                                                    string @IN07CODDOC_ING, string @IN07KEY_ING, double @IN07ORDEN_ING, out string @cMsgRetorno)
        { 
            Accessor.EliminarSalidasPPLinea(@IN07CODEMP, @IN07AA_ING, @IN07MM_ING, @IN07TIPDOC_ING,
                                                    @IN07CODDOC_ING, @IN07KEY_ING, @IN07ORDEN_ING, out @cMsgRetorno);
        }
        //public void ActualizarDetCanastIng(Movimiento mov, out int @flagReturn,out string @cMsgRetorno) { 
        //    Accessor.ActualizarDetalleDocumentoCanastIng(
        //        mov.CodigoEmpresa, mov.Anio, mov.Mes, mov.CodigoTipoDocumento
        //        , mov.CodigoDocumento,
        //        mov.CodigoArticulo
        //    , 
        //    mov.CodigoAlmacen, 
        //    mov.CodigoTransaccion,
        //    , mov.Transaccion, 
        //    mov.FechaDoc, 
        //    @nTipoCambio  mov., @IN07CODBLOQUEEMP,
        //    @IN07CODBLOQUEPROV, @IN07NROCAJA, @IN07PEDVEN, @IN07PROVMATPRIMA,
        //    @in07pedvennum, @in07pedvencodprod, @in07pedvenitem,
        //    @IN07CODCLI, @in07observacion, @IN07ORDENTRABAJO, 
        //    @nOrden, out @flagReturn,out @cMsgRetorno);
        //}
        
        #endregion
        #region "Costos"
        public void ImportarMovimientosProduccion(string @Empresa,string @Anio, string @Mes, string @Linea,
                                                           string @Lote, out string @mensaje, out int @flag) 
        {
           Accessor.Spu_Cos_Ins_MovimientosProduccion(@Empresa, @Anio, @Mes, @Linea, @Lote, out @mensaje, out @flag);
        }
        public List<MovimientosProduccion> TraerImportarMovimientosProduccion(string @Empresa, string @Anio, string @Mes, string @Linea,
                                                             string @Lote)
        {
            return Accessor.Spu_Cos_Traer_MovimientoProduccion(@Empresa, @Anio, @Mes, @Linea, @Lote);
        }
        public List<CostosDetalle> TraerDetalleCostos(string @COS03CODEMP, string @COS03ANIO, string @COS03MES,
                                                      string @COS03LINEA, string @CO03LOTE)
        {

            return Accessor.Spu_Cos_Traer_CostosDetalle(@COS03CODEMP, @COS03ANIO, @COS03MES, @COS03LINEA, @CO03LOTE);
        }

        #endregion
        public void InsertarStockLinea(string @PTIN07CODEMP, string @PTIN07AA, string @PTIN07MM, 
                                       string @PTIN07TIPDOC, string @PTIN07CODDOC, string @PTIN06CODTRA,
                                       string @PTIN07FechaDoc, string @XMLrango, out int @FlagDeretorno, 
                                       out string @msgretorno) {
            Accessor.Spu_Inv_Ins_StockLinea(@PTIN07CODEMP, @PTIN07AA, @PTIN07MM,
             @PTIN07TIPDOC, @PTIN07CODDOC, @PTIN06CODTRA,
              @PTIN07FechaDoc, @XMLrango, out  @FlagDeretorno, out  @msgretorno);
        }
        public void EliminarStockLinea(string @IN07CODEMP, string @IN07AA, string @IN07MM,
                                                            string @IN07TIPDOC, string @IN07CODDOC, string @IN07KEY,
                                                            double @IN07ORDEN, string @IN07ORDENTRABAJO,
                                                            out int @flag, out string @msg)
        {
            Accessor.Spu_Inv_Del_ELiminarStockLinea(@IN07CODEMP, @IN07AA, @IN07MM,
                                                             @IN07TIPDOC, @IN07CODDOC, @IN07KEY,
                                                             @IN07ORDEN, @IN07ORDENTRABAJO,
                                                            out  @flag, out  @msg);
        }
        public void InsertarSaldos(string @XMLdetalle, out string @cMensaje, out int @cFlag)
        {
            Accessor.Spu_Pro_Ins_MoviSaldos(@XMLdetalle, out @cMensaje, out @cFlag);
        }

        public void InsertarMovProduccionImp(MovimientosProduccion entidad, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Cos_Ins_MovimientosProduccionImp(entidad.COS01CODEMP, entidad.COS01ANIO,
            entidad.COS01MES, entidad.COS01LINEA, entidad.COS01LOTE, entidad.COS01MOVIPRODAA,
            entidad.COS01MOVIPRODMM, entidad.COS01MOVIPRODTIPDOC, entidad.COS01MOVIPRODCODDOC,
            entidad.COS01MOVIPRODKEY, entidad.COS01MOVIPRODORDEN, entidad.COS01PRODLINEACOD,
            entidad.COS01RODACTNIV1COD, entidad.COS01ORDENTRABAJO,
            entidad.COS01PRODNATURALEZA, entidad.COS01UNIMED, string.Format("{0:yyyyMMdd}", entidad.COS01FECDOC),
            entidad.COS01CODALM, entidad.COS01CODTRA, entidad.COS01TRANSA, Convert.ToDouble(entidad.COS01CANART),
            Convert.ToDouble(entidad.COS01COSUNI), Convert.ToDouble(entidad.COS01COUNSO),
            Convert.ToDouble(entidad.COS01COUNDO), Convert.ToDouble(entidad.COS03IMPORT),
            Convert.ToDouble(entidad.COS01IMPSOL), Convert.ToDouble(entidad.COS01IMPDOL),
            entidad.COS01LARGO, entidad.COS01ANCHO, entidad.COS01ALTO,
            entidad.COS01NROCAJA, entidad.COS01DocIngAA, entidad.COS01DocIngMM,
            entidad.COS01DocIngTIPDOC, entidad.COS01DocIngCODDOC, entidad.COS01DocIngKEY,
            entidad.COS01DocIngORDEN, entidad.COS01AREAXUNI, entidad.COS01AREA,
            entidad.COS01VOLUMEN, entidad.COS01COSPROMSOL, entidad.COS01COSPROMDOL,
            entidad.COS01FLAG, entidad.COS01ERRORES, entidad.COS01CANTERRORES,
            entidad.COS01CODIGOUSUARIO, entidad.COS01SISTEMA, out @flag, out @mensaje);
        }
        public void EliminarMovProduccionImp(string @COS01CODEMP, string @COS01CODIGOUSUARIO,
                                                                       string @COS01SISTEMA, out string @mensaje)
        {
            Accessor.Spu_Cos_Del_MovimientosProduccionImp(@COS01CODEMP, @COS01CODIGOUSUARIO, @COS01SISTEMA, out @mensaje);
        }
        public void GuardarMovProduccionImp(string @COS01CODEMP, string @COS01ANIO,
        string @COS01MES, string @COS01LINEA, string @COS01LOTE, string @COS01CODIGOUSUARIO,
            out int @flag, out string @mensaje)
        {
            Accessor.Spu_Cos_Ins_MovimientosProduccionImpxusuario(@COS01CODEMP, @COS01ANIO,
                @COS01MES, @COS01LINEA, @COS01LOTE, @COS01CODIGOUSUARIO, out @flag, out @mensaje);
        }
        public List<MovimientosProduccion> TraeMovimientosProduccionImp(string @COS01CODEMP, string @COS01ANIO,
                                                           string @COS01MES, string @COS01CODIGOUSUARIO)
        {
            return Accessor.Spu_Cos_Trae_MovimientosProduccionImp(@COS01CODEMP, @COS01ANIO,
                                                            @COS01MES, @COS01CODIGOUSUARIO);
        }

        //public void InsertarDetalleSalMultiple(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07TIPDOC, string @IN07CODDOC,
        //string @IN07FECDOC, string @IN07CODALM, string @IN07CODTRA, string @XMLdetalle, out int @Flag, out string @Msgretorno)
        //{
        //    Accessor.InsertarDetalleSalMultiple(@IN07CODEMP, @IN07AA, @IN07MM, @IN07TIPDOC, @IN07CODDOC, @IN07FECDOC, @IN07CODALM,
        //     @IN07CODTRA, @XMLdetalle, out @Flag, out @Msgretorno);
        //}

        #region "MP Resumido"
        public List<Spu_Pro_Trae_MPResumida> TraerAyudaPPResumido(string @IN07CODEMP, string @IN07CODALM)
        {
            return Accessor.TraerMPResumido(@IN07CODEMP, @IN07CODALM);
        }
        public void InsertarSalidasPPResumido(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06FECDOC, string @OTNUMERO,
                    string @IN06ORIGENTIPO, string @XMLdetalle, out int @cFlag, out string @cMsgretorno)
        {
            Accessor.Spu_Pro_Ins_SalidaPPResumido(@IN06CODEMP, @IN06AA, @IN06MM, @IN06FECDOC, @OTNUMERO,
            @IN06ORIGENTIPO, @XMLdetalle, out @cFlag, out @cMsgretorno);
        }
        public List<Spu_Pro_Trae_SalidaMPResumida> TraerSalidaMPResumida(string @IN07CODEMP, string @IN07AA,
                                                                                    string @IN07MM, string @IN07ORDENTRABAJO)
        { 
            return Accessor.Spu_Pro_Trae_SalidaMPResumida(@IN07CODEMP, @IN07AA, @IN07MM, @IN07ORDENTRABAJO);
        }
        public void EliminarSalidaMPResumida(string @IN07CODEMP, string @IN07AA, string @IN07MM, string @IN07DocIngAA, string @IN07DocIngMM,
                                string @IN07DocIngTIPDOC, string @IN07DocIngCODDOC, string @IN07DocIngKEY, string @IN07ORDENTRABAJO, string @IN07CODALM,
                                string @IN07NROCAJA, string @IN07HORASALIDA, out int @cFlag, out string @cMensaje)
        { 
            Accessor.Spu_Pro_Del_SalidaMPResumida(@IN07CODEMP, @IN07AA, @IN07MM, @IN07DocIngAA, @IN07DocIngMM,
                                @IN07DocIngTIPDOC, @IN07DocIngCODDOC, @IN07DocIngKEY, @IN07ORDENTRABAJO, @IN07CODALM,
                                @IN07NROCAJA, @IN07HORASALIDA, out @cFlag, out @cMensaje);
        }

        #endregion
        #region "Saldo x bloque"
        public List<Movimiento> TraeSaldoxBloque(string @IN07CODEMP, string @IN07NROCAJAINGRESO)
        {
            return Accessor.Spu_Pro_Trae_SaldoxBloque(@IN07CODEMP, @IN07NROCAJAINGRESO);
        }

        public void InsertarSaldoxBloque(string @IN06CODEMP, string @IN06AA, string @IN06MM, Nullable<DateTime> @IN06FECDOC, string @IN07KEY,
        string @IN07UNIMED, double @IN07CANART, double @IN07LARGO, double @IN07ANCHO, double @IN07ALTO, string @IN07NROCAJA,
        string @IN07ORDENTRABAJO, string @IN07OBSERVACION, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Pro_Ins_SaldoxBloque(@IN06CODEMP, 
                @IN06AA, 
                @IN06MM, 
                string.Format("{0:yyyyMMdd}", @IN06FECDOC), 
                @IN07KEY,
                @IN07UNIMED, 
                Convert.ToDouble(@IN07CANART), 
                Convert.ToDouble(@IN07LARGO), 
                Convert.ToDouble(@IN07ANCHO), 
                Convert.ToDouble(@IN07ALTO), 
                @IN07NROCAJA,
                @IN07ORDENTRABAJO, 
                @IN07OBSERVACION,
                out @flag, 
                out @mensaje);
        }


        public void EliminarSaldoxBloque(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @IN06TIPDOC,
        string @IN06CODDOC, string @IN07KEY, double @IN07ORDEN, string @IN07NROCAJA, out int @flag, out string @mensaje)
        { 
            Accessor.Spu_Pro_Del_SaldoxBloque(@IN06CODEMP, @IN06AA, @IN06MM, @IN06TIPDOC, @IN06CODDOC, 
                                              @IN07KEY, @IN07ORDEN, @IN07NROCAJA, out @flag, out @mensaje);
        }
        #endregion
        #region "Modulo facturacion"
        public List<Spu_Fact_Trae_FAC05_DETFACTURAXFACT> TraerDetalleFactura(string @FAC05CODEMP, 
        string @FAC04NUMDOC, string @FAC01COD)        
        {                            
            return Accessor.Spu_Fact_Trae_FAC05_DETFACTURAXFACT(@FAC05CODEMP, @FAC04NUMDOC, @FAC01COD);
        }
        public List<CuotasFactura> TraerCuotasFactura(string @FAC12CODEMP, string @FAC12COD, string @FAC12NUMDOC)
        {
            return Accessor.Spu_Fact_Trae_FacturaCuotas(@FAC12CODEMP, @FAC12COD, @FAC12NUMDOC);
        }

        public void Spu_Fact_Del_FacturaCuotas(string @FAC12CODEMP, string @FAC12COD, string @FAC12NUMDOC, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FacturaCuotas(@FAC12CODEMP, @FAC12COD, @FAC12NUMDOC, out @flag, out @msgretorno);
        }

        public void Spu_Fact_Ins_CuotasFactura(string @FAC12CODEMP, string @FAC12COD, string @FAC12NUMDOC, int @cuotascantidad, int @cuotasdias,
            string @fechaDoc, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_CuotasFactura(@FAC12CODEMP, @FAC12COD, @FAC12NUMDOC, @cuotascantidad, @cuotasdias,
            @fechaDoc, out @flag, out @msgretorno);
        }


        public void Spu_Fact_Ins_FAC04_CABFACTURA(DocumentoFA doc, out int @flag,
        out string @msgretorno)
        { 
            Accessor.Spu_Fact_Ins_FAC04_CABFACTURA(doc.FAC04CODEMP, doc.FAC01COD, doc.FAC04NUMDOC,
            doc.FAC04AA, doc.FAC04MM, doc.FAC04NRODOC, doc.FAC04SERIEDOC,string.Format("{0:yyyyMMdd}", 
            doc.FAC04FECHA), doc.FAC04TIPANA, doc.FAC04CODCLI, doc.FAC04MONEDA, doc.FAC04TIPCAMBIO, 
            doc.FAC04DONSUBTOTAL, doc.FAC04DONIGV, doc.FAC04DONTOTAL, doc.FAC02COD, doc.FAC03COD, 
            doc.FAC03TIPART, doc.FAC04CLINOMBRE, doc.FAC04CLIDIRECCION, doc.FAC04CLIRUC, doc.FAC04GLOSA, 
            doc.FAC04DONGLAG, doc.FAC04IGV, doc.FAC04GUIAS, doc.FAC04DOCMODTIPDOC, doc.FAC04DOCMODNRO, 
            string.Format("{0:yyyyMMdd}",doc.FAC04DOCMODFECHA), doc.FAC04TIPMOTEMI, doc.FAC04TIPMOTEMIDES, 
            doc.FAC04EXPCONOEMBARQUE, doc.FAC04EXPCODPAISORIGEN, doc.FAC04EXPCODPAISDESTINO, doc.FAC04EXPCODCONDPAGO,
            doc.FAC04EXPCODCONDDESPACHO, doc.FAC04EXPCODPUERTO, doc.FAC04EXPCODPUERTODES, doc.FAC04EXPCODBCOLOCAL, 
            doc.FAC04EXPCDDOCCRED, doc.FAC04EXPLCEMITIDA, doc.FAC04EXPBANKCODE, doc.FAC04EXPNUMCUENTA, 
            doc.FAC04EXPNROCONTAINER, doc.FAC04EXPNROPRECINTO, doc.FAC04ORDENCOMPRA,
            string.Format("{0:yyyyMMdd}",doc.FAC04FECORDCOMPRA), doc.FAC04CODTIPOVENTA, doc.FAC04ESTADODEPROCESO,
            doc.FAC04TIENDA, doc.FAC04DESCUENTOGLOBAL, doc.FAC04FETIPONOTA, doc.FAC04LIQUIDACIONNRO, doc.FAC04FETIPODEOPERACION, doc.FAC04FECODIGOANEXOEMISOR,
            doc.FAC04FORMAPAGOSUNAT, doc.FAC04FORMAPAGOSUNATCUOTAS, doc.FAC04FORMAPAGOSUNATDIAS,
            doc.FAC04FECODBIENOSERVDETRACCION, doc.FAC04FEPORCEDETRACCION, doc.FAC04FETOTALDETRACCION,
            doc.FAC04VENDEDORCOD,doc.FAC04VENDEDORNOMBRE,
            out @flag, out @msgretorno);
        }
        public void Spu_Fact_Upd_FAC04_CABFACTURA(DocumentoFA doc,out  int @flag , out string @msgretorno)
        { 
            Accessor.Spu_Fact_Upd_FAC04_CABFACTURA( doc.FAC04CODEMP,  doc.FAC01COD,  doc.FAC04NUMDOC,  doc.FAC04AA,  doc.FAC04MM,
        doc.FAC04NRODOC,  doc.FAC04SERIEDOC,  string.Format("{0:yyyyMMdd}",doc.FAC04FECHA),  doc.FAC04TIPANA,  doc.FAC04CODCLI,  doc.FAC04MONEDA,
        doc.FAC04TIPCAMBIO,  doc.FAC04DONSUBTOTAL,  doc.FAC04DONIGV,  doc.FAC04DONTOTAL,  doc.FAC03COD,  doc.FAC02COD,
        doc.FAC03TIPART,  doc.FAC04CLINOMBRE,  doc.FAC04CLIDIRECCION,  doc.FAC04CLIRUC,  doc.FAC04GLOSA,  doc.FAC04DONGLAG,
        doc.FAC04IGV,  doc.FAC04GUIAS,  doc.FAC04DOCMODTIPDOC,  doc.FAC04DOCMODNRO, string.Format("{0:yyyyMMdd}", doc.FAC04DOCMODFECHA),  doc.FAC04TIPMOTEMI,
        doc.FAC04TIPMOTEMIDES,  doc.FAC04EXPCONOEMBARQUE,  doc.FAC04EXPCODPAISORIGEN,  doc.FAC04EXPCODPAISDESTINO,
        doc.FAC04EXPCODCONDPAGO,  doc.FAC04EXPCODCONDDESPACHO,  doc.FAC04EXPCODPUERTO,  doc.FAC04EXPCODPUERTODES,  doc.FAC04EXPCODBCOLOCAL,
        doc.FAC04EXPCDDOCCRED,  doc.FAC04EXPLCEMITIDA,  doc.FAC04EXPBANKCODE,  doc.FAC04EXPNUMCUENTA,  doc.FAC04EXPNROCONTAINER,
        doc.FAC04EXPNROPRECINTO,  doc.FAC04ORDENCOMPRA, string.Format("{0:yyyyMMdd}", doc.FAC04FECORDCOMPRA),  doc.FAC04CODTIPOVENTA,  doc.FAC04ESTADODEPROCESO,
        doc.FAC04TIENDA, doc.FAC04DESCUENTOGLOBAL, doc.FAC04FETIPONOTA, doc.FAC04LIQUIDACIONNRO, doc.FAC04FETIPODEOPERACION, doc.FAC04FECODIGOANEXOEMISOR,
        doc.FAC04FORMAPAGOSUNAT, doc.FAC04FORMAPAGOSUNATCUOTAS, doc.FAC04FORMAPAGOSUNATDIAS,
        doc.FAC04FECODBIENOSERVDETRACCION, doc.FAC04FEPORCEDETRACCION, doc.FAC04FETOTALDETRACCION,
        doc.FAC04VENDEDORCOD, doc.FAC04VENDEDORNOMBRE,
        out @flag, out @msgretorno);
        }
        public void Spu_Fact_Del_FAC04_CABFACTURA(DocumentoFA doc, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FAC04_CABFACTURA(doc.FAC04CODEMP, doc.FAC01COD,
                                    doc.FAC04NUMDOC, out @flag, out @msgretorno);
        }
        
        public  void Spu_Fact_Ins_FAC05_DETFACTURA(DocumentoFA doc, out int @flag,out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_FAC05_DETFACTURA( doc.FAC05CODEMP,  doc.FAC01COD,  doc.FAC04NUMDOC,  doc.FAC05CODFACDET,
         doc.FAC05CODPROD,  doc.FAC05DESCPROD,  doc.FAC05UNIMED,  doc.FAC05CANTIDAD,
         doc.FAC05PRECIO,  doc.FAC05SUBTOTAL,  doc.FAC05PARTARAN,  doc.FAC05PESO,  doc.FAC05NROCAJA,  doc.FAC05PESOADUANA,
         doc.FAC05SUBGRUPO,  doc.FAC05FECODRAZEXONERACION,  doc.FAC05FEIMPDSCTO,  doc.FAC05FECODIMPREF,
         doc.FAC05FEPRODUCTOTIPO,  doc.FAC05FEIMPORTEREFERENCIAL.ToString(),  doc.FAC05FEIMPORTECARGO.ToString(),
         doc.FAC05FECODPRODSUNAT, doc.FAC05FEIGVTASA,out @flag, out @msgretorno); 
        }


        public  void Spu_Fact_Upd_FAC05_DETFACTURA(DocumentoFA doc, out int @flag,out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_FAC05_DETFACTURA(doc.FAC05CODEMP, doc.FAC01COD, doc.FAC04NUMDOC, doc.FAC05CODFACDET,
         doc.FAC05CODPROD, doc.FAC05DESCPROD,  doc.FAC05UNIMED,  doc.FAC05CANTIDAD,
         doc.FAC05PRECIO, doc.FAC05SUBTOTAL, doc.FAC05PARTARAN,  doc.FAC05PESO,  
         doc.FAC05NROCAJA, doc.FAC05PESOADUANA, doc.FAC05SUBGRUPO,  doc.FAC05FECODRAZEXONERACION,  
         doc.FAC05FEIMPDSCTO, doc.FAC05FECODIMPREF, doc.FAC05FEPRODUCTOTIPO,  
         doc.FAC05FEIMPORTEREFERENCIAL.ToString(),  doc.FAC05FEIMPORTECARGO.ToString(),
         doc.FAC05FECODPRODSUNAT, doc.FAC05FEIGVTASA,out @flag, out @msgretorno);
        }
        public void Spu_Fact_Del_FAC05_DETFACTURA(string @FAC05CODEMP, string @FAC01COD, 
        string @FAC04NUMDOC, int @FAC05CODFACDET, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FAC05_DETFACTURA(@FAC05CODEMP, @FAC01COD, 
                 @FAC04NUMDOC, @FAC05CODFACDET, out @flag, out @msgretorno);
        }

        public List<SubPlantilla> TraeAyudaSubPlantilla(string @FAC03CODEMP, string @FAC01COD, string @campo, string @Filtro)
        { 
            return  Accessor.Spu_Fact_Help_FAC03_SUBPLANTILLA(@FAC03CODEMP, @FAC01COD, @campo, @Filtro);
        }
        public List<TipoDocumentoVentas> TraeAyudaTipoDocumento(string @FAC01CODEMP, string @campo, string @filro)
        {
            return Accessor.Spu_Fact_Help_FAC01_TIPDOC(@FAC01CODEMP, @campo, @filro);
        }
        public List<Spu_Fact_Help_FAC04_CABFACTURA> TraeAyudaNroDocumento(string @FAC04CODEMP, string @FAC01COD, 
                                                                          string @campo, string @filro)
        {
            return Accessor.Spu_Fact_Help_FAC04_CABFACTURA(@FAC04CODEMP, @FAC01COD, @campo, @filro);
        }
        public void DarComunicadoBaja(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC,
                        string @FechaDocumento, string @FechaBaja, string @motivoBaja, out int @flag,out string @msgretorno)
        {
            Accessor.Spu_Fac_Ins_FEComunicacionBaja(@FAC04CODEMP, @FAC01COD, @FAC04NUMDOC, @FechaDocumento, 
                                                                 @FechaBaja, @motivoBaja, out @flag, out @msgretorno);
        }
        public void GenerarFacturaElectronica(string @FAC04CODEMP, string @FAC01COD, string @FAC04NUMDOC, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fac_Ins_DocumentosElectronicos(@FAC04CODEMP, @FAC01COD, @FAC04NUMDOC, out @flag, out @msgretorno);
        }

        public void Spu_Fac_Trae_ErrorLocalFE(string @FAC01COD, string @FAC04NUMDOC, out string @msgretorno)
        {
            Accessor.Spu_Fac_Trae_ErrorLocalFE(@FAC01COD, @FAC04NUMDOC,out @msgretorno);
        }

        public DataTable TraeFacturaElectronicaOnline(string @empresa, string @tipoDocumentoEmisor,
            string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero, out string @linkFacturaElectronica)
        { 
            return Accessor.Spu_Fact_Trae_FacturaElectronicaOnline(@empresa, @tipoDocumentoEmisor,
                @numeroDocumentoEmisor, @tipoDocumento, @serieNumero, out @linkFacturaElectronica);
        }

        public void CopiarFactura(string @FAC04CODEMP, string @FAC01COD, string @FAC04SERIEDOC,
        string @FAC04NRODOC, string @FACTURAORIGENNRO, string @FAC04AA, string @FAC04MM, string @FAC04FECHA,
        out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Ins_CopiarFactura(@FAC04CODEMP, @FAC01COD, @FAC04SERIEDOC, @FAC04NRODOC, 
                     @FACTURAORIGENNRO, @FAC04AA, @FAC04MM, @FAC04FECHA, out @flag, out @msgretorno);
        }
        public List<DetalleGuiaTransporte> TraeAyudaGuiaTransporte(string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA)
        { 
            return Accessor.Spu_Fact_Trae_DetalleGuiPorNroGuia(@FAC35CODEMP, @FAC01COD, @FAC34NROGUIA);
        }
        public void InsertarGuiasDetalle(string @FAC05CODEMP, string @FAC01COD, string @FAC04NUMDOC, string @XMLdetalle,
        out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Ins_DetalleResumido(@FAC05CODEMP, @FAC01COD, @FAC04NUMDOC, @XMLdetalle, out @flag, out @msgretorno);
        }
        public void EliminarDetFacturaPorGuiaDetalle(string @FAC05CODEMP, string @FAC01COD,
        string @FAC04NUMDOC, string @FAC05GUIATIPDOC, string @FAC05GUIANUMERO,int @FAC05CODFACDET, 
        string @FlagRespuesta, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Del_DetFacturaPorGuiaDetalle(@FAC05CODEMP, @FAC01COD, @FAC04NUMDOC, @FAC05GUIATIPDOC, 
                     @FAC05GUIANUMERO, @FAC05CODFACDET, @FlagRespuesta, out @flag, out @msgretorno);
        }


        public void GuardarGuiaRemisionEnComprobantePago(DocumentoFA doc, string @XMLdetalle, out int @flag,
        out string @msgretorno) 
        {
            Accessor.Spu_Fact_Ins_GuiaRemisionEnComprobanteDePago(doc.FAC04CODEMP, doc.FAC01COD, doc.FAC04NUMDOC,
                doc.FAC04AA, doc.FAC04MM, doc.FAC04NRODOC, doc.FAC04SERIEDOC, string.Format("{0:yyyyMMdd}",
                doc.FAC04FECHA), doc.FAC04TIPANA, doc.FAC04CODCLI, doc.FAC04MONEDA, doc.FAC04TIPCAMBIO,
                doc.FAC04DONSUBTOTAL, doc.FAC04DONIGV, doc.FAC04DONTOTAL, doc.FAC02COD, doc.FAC03COD,
                doc.FAC03TIPART, doc.FAC04CLINOMBRE, doc.FAC04CLIDIRECCION, doc.FAC04CLIRUC, doc.FAC04GLOSA,
                doc.FAC04DONGLAG, doc.FAC04IGV, doc.FAC04GUIAS, doc.FAC04DOCMODTIPDOC, doc.FAC04DOCMODNRO,
                string.Format("{0:yyyyMMdd}", doc.FAC04DOCMODFECHA), doc.FAC04TIPMOTEMI, doc.FAC04TIPMOTEMIDES,
                doc.FAC04EXPCONOEMBARQUE, doc.FAC04EXPCODPAISORIGEN, doc.FAC04EXPCODPAISDESTINO, doc.FAC04EXPCODCONDPAGO,
                doc.FAC04EXPCODCONDDESPACHO, doc.FAC04EXPCODPUERTO, doc.FAC04EXPCODPUERTODES, doc.FAC04EXPCODBCOLOCAL,
                doc.FAC04EXPCDDOCCRED, doc.FAC04EXPLCEMITIDA, doc.FAC04EXPBANKCODE, doc.FAC04EXPNUMCUENTA,
                doc.FAC04EXPNROCONTAINER, doc.FAC04EXPNROPRECINTO, doc.FAC04ORDENCOMPRA,
                string.Format("{0:yyyyMMdd}", doc.FAC04FECORDCOMPRA), doc.FAC04CODTIPOVENTA, doc.FAC04ESTADODEPROCESO,
                doc.FAC04TIENDA, doc.FAC04DESCUENTOGLOBAL, doc.FAC04FETIPONOTA, doc.FAC04LIQUIDACIONNRO, doc.FAC04FETIPODEOPERACION, doc.FAC04FECODIGOANEXOEMISOR,
                doc.FAC04FORMAPAGOSUNAT,doc.FAC04FORMAPAGOSUNATCUOTAS,doc.FAC04FORMAPAGOSUNATDIAS,
                doc.FAC04FECODBIENOSERVDETRACCION, doc.FAC04FEPORCEDETRACCION, doc.FAC04FETOTALDETRACCION,
                doc.FAC04VENDEDORCOD,doc.FAC04VENDEDORNOMBRE,
                @XMLdetalle, out @flag, out @msgretorno);

        }

        public List<Movimiento> TraeDetalleSalidaAgrupado(string @IN06CODEMP, string @IN06AA, string @IN06MM,
        string @IN06TIPDOC, string @IN06CODTRA, string @IN06CODDOC, string @parIN06REFDOC)
        { 
           return Accessor.Spu_Inv_Trae_DetalleSalidaAgrupado(@IN06CODEMP, @IN06AA, @IN06MM,
                @IN06TIPDOC, @IN06CODTRA, @IN06CODDOC, @parIN06REFDOC);
        }
        public List<Movimiento> TraeDetalleGuiaxNroRef(string codigoEmpresa, string tipoDocumento, string nroGuiaRemision)
        {
            return Accessor.Spu_Inv_Trae_DetGuiaxNroRefdeDocSalida(codigoEmpresa, tipoDocumento, nroGuiaRemision);
        }
        public void InsertarDetGuiaADetMovi(string @XMLdetalle, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Inv_Ins_DetGuiaADetMovimiento(@XMLdetalle, out @flag, out @msgretorno);
        }

        public void CopiarGuiaRemision(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, string @FAC34SERIEGUIA,
        string @FAC34CORRELATIVOGUIA, string @FAC34AA, string @FAC34MM, string @FAC34FECHA, out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Ins_CopiaGuiaRemision(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, @FAC34SERIEGUIA,
                @FAC34CORRELATIVOGUIA, @FAC34AA, @FAC34MM, @FAC34FECHA, out @flag, out @msgretorno);
        }

        public void ActualizarFacturaEstadoPago(string @empresa, string @tipoDocumento, string @numeroDocumento,
                                                                   string @estadoPago, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Fact_Upd_FacturaEstadoPago(@empresa, @tipoDocumento, @numeroDocumento, @estadoPago,
             out @flag, out  @mensaje);
        }

        public List<CuentaCorriente> TraeClientesConLineaCredito(string @ccm02emp, string @ccm02tipana)
        {
            return Accessor.Spu_Fact_Trae_ClientesConLineaCredito(@ccm02emp, @ccm02tipana);
        }

        public List<Spu_Fact_Trae_FacxCliLineaCredito> TraeFacxCliLineaCredito(string @FAC04CODEMP,
                string @FAC01COD, string @FAC04CODCLI)
        {
            return Accessor.Spu_Fact_Trae_FacxCliLineaCredito(@FAC04CODEMP, @FAC01COD, @FAC04CODCLI);
        }

        public void ActualizarInformarSecret(string @empresa, string @tipoDocumento, string @numeroDocumento,
                string @informarSecrex, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Fact_Upd_InformarSecret(@empresa, @tipoDocumento, @numeroDocumento, @informarSecrex,
                                                out @flag, out  @mensaje);
        }


        public List<Devolucion> TraeDevolucionCab(string @IN06CODEMP, string @IN06AA,
        string @IN06MMINICIAL, string @IN06MMFINAL)
        {
            return Accessor.Spu_Fac_Trae_DevolucionCab(@IN06CODEMP, @IN06AA,
                                            @IN06MMINICIAL, @IN06MMFINAL);
        }


        public List<Devolucion> TraeDevolucionDet(string @IN06CODEMP, string @IN06AA,
        string @IN07MM,string @IN06TIPDOC, string @IN06CODDOC)
        {
            return Accessor.Spu_Fac_Trae_DevolucionDet(@IN06CODEMP, @IN06AA,
                            @IN07MM, @IN06TIPDOC, @IN06CODDOC);
        }

        public List<Spu_Inv_Trae_StockDetMPTodos> TraeMateriaPrimaFiltrado(string @IN07CODEMP, string @IN07CODALM,
                                                                                   string @filtro, string @campo)
        {
            return Accessor.Spu_Pro_Trae_StockDetMPFiltrado(@IN07CODEMP, @IN07CODALM, @filtro, @campo);
        }

        public List<TraeAnticiposPorAplicar> TraeAnticiposPorAplicar(string @FAC04CODEMP, string @FAC04CODCLI)
        {
            return Accessor.Spu_Fac_Trae_AnticiposPorAplicar(@FAC04CODEMP, @FAC04CODCLI);
        }

        public void InsertarAnticiposPorAplicar(string @FAC04CODEMP, string @FAC01COD,
        string @FAC04NUMDOC, string @xmlAnticipos, out string @mensaje, out int @flag)
        { 
            Accessor.Spu_Fac_Ins_AnticiposPorAplicar(@FAC04CODEMP, @FAC01COD,
                            @FAC04NUMDOC, @xmlAnticipos, out @mensaje, out @flag);
        }
        public void EliminarFacturaAnticipo(string @FAC75CODEMP, string @FAC75CODFACTPRINCIPAL, string @FAC75NUMDOCFACTPRINCIPAL,
            int @FAC75ITEM, out string @mensaje, out int @flag)
        {
            Accessor.Spu_Fac_Del_FacturaAnticipo(@FAC75CODEMP, @FAC75CODFACTPRINCIPAL, @FAC75NUMDOCFACTPRINCIPAL, 
                @FAC75ITEM, out @mensaje, out @flag);




        }
        #endregion

        public void ComprasExisteInvMovimiento(string @cEmpresa, string @cAno, string @cMes, string @cTipdoc,
        string @cCoddoc, out float @nRegistros)
        { 
              Accessor.Spu_Com_Trae_DimeExisteMovimiento(@cEmpresa,  @cAno,  @cMes,  @cTipdoc,   @cCoddoc,  out @nRegistros);
        }
        public DataTable TraeReportesMovimientosSuministro(string @CodEmp, string @Ano, string @Mes, string @XMLRango)
        {
            return Accessor.Spu_Inv_Rep_MovimientosSuministro(@CodEmp, @Ano, @Mes, @XMLRango);

        }

        public void DameNumeroDocumento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
                                                          out string @cNumDoc)
        {
            Accessor.sp_Inv_Dame_Numero_Documento(@cCodEmp, @cAnno, @cMes, @cTipDoc, out @cNumDoc);
        }

        public void CalculoStockyCostos(string @cCodEmp, string @cAno, string @cMes, out string @cMsgRetorno)
        {
            Accessor.sp_Inv_Calculo_Stock_Y_Costos(@cCodEmp, @cAno, @cMes, out @cMsgRetorno);
        }

        public void EliminarMovimientoAlmacenImportado(string @Empresa, string @USUARIO)
        {
            Accessor.Spu_Inv_Del_MovimientoAlmacenImportado(@Empresa, @USUARIO);
        }



        public void InsertarMovimientoAlmacenImportado(string @Empresa, string @Anio, string @Mes, int @contador, string @DOCUMENTO_FECHA,
        string @DOCUMENTO_TIPO, string @DOCUMENTO_NUMERO, string @DOCUMENTO_TIPOOPERACION,
        double @ENTRADA_CANTIDAD, double @ENTRADA_COSTOUNITARIO, double @ENTRADA_COSTOTOTAL, double @SALIDA_CANTIDAD, double @SALIDA_COSTOUNITARIO,
        double @SALIDA_COSTOTOTAL, double @SALDOFINAL_CANTIDAD, double @SALDOFINAL_COSTOUNITARIO, double @SALDOFINAL_COSTOTOTAL, 
        string @ALMACEN,  string @PRODUCTO_CODIGOCONTASIS, string @PRODUCTO_DESCRIPCIONCONTASIS, string @PRODUCTO_UNIMED, 
        string @PRODUCTO_CODIGOTRAVER, string @PRODUCTO_CODIGOSAP, string @RUC, string @RAZONSOCIAL, string @ORDENDECOMPRA, 
        string @COMENTARIOS, string @CAMPOADICIONAL1, string @CAMPOADICIONAL2,

            string @USUARIO, out int @flag, out string @mensaje)

        { 
            Accessor.Spu_Inv_Ins_MovimientoAlmacenImportado(@Empresa, @Anio, @Mes, @contador, @DOCUMENTO_FECHA,
            @DOCUMENTO_TIPO, @DOCUMENTO_NUMERO, @DOCUMENTO_TIPOOPERACION,
            @ENTRADA_CANTIDAD, @ENTRADA_COSTOUNITARIO, @ENTRADA_COSTOTOTAL, @SALIDA_CANTIDAD, @SALIDA_COSTOUNITARIO,
            @SALIDA_COSTOTOTAL, @SALDOFINAL_CANTIDAD, @SALDOFINAL_COSTOUNITARIO, @SALDOFINAL_COSTOTOTAL, @ALMACEN, 
            @PRODUCTO_CODIGOCONTASIS,
            @PRODUCTO_DESCRIPCIONCONTASIS, @PRODUCTO_UNIMED, @PRODUCTO_CODIGOTRAVER, @PRODUCTO_CODIGOSAP,
            @RUC, @RAZONSOCIAL, @ORDENDECOMPRA, @COMENTARIOS, @CAMPOADICIONAL1, @CAMPOADICIONAL2,
            @USUARIO, out @flag, out @mensaje);
        }


        public DataTable TraeMovimientoAlmacenImportado(string @Empresa, string @USUARIO)
        { 
            return Accessor.Spu_Inv_Trae_MovimientoAlmacenImportado(@Empresa, @USUARIO);
        }
        
        public DataTable ValidacionMovimientoAlmacen(string @Empresa, string @Anio, string @Mes, string @Usuario)
        { 
            return Accessor.Spu_Inv_Trae_ValImpMovAlmacen(@Empresa, @Anio, @Mes, @Usuario);
        }

        public void InsertarImpMovAlmacen(string @Empresa, string @Anio, string @Mes, string @Usuario, out int @flag, out string @Msgretorno)
        {
            Accessor.Spu_Inv_Ins_ImpMovAlmacen(@Empresa, @Anio, @Mes, @Usuario, out @flag, out @Msgretorno);
        }

        public void EliminarMovimientoSuministroBloque(string @IN06CODEMP, string @IN06AA, string @IN06MM, string @XMLrango, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Inv_Del_MovimientoSuministroBloque(@IN06CODEMP, @IN06AA, @IN06MM, @XMLrango, out @flag, out @mensaje);
        }
        public DataTable Trae_Centros_Costo(string @cCodEmp, string @ccb02aa) 
        {
            return Accessor.Trae_Centros_Costo(@cCodEmp, @ccb02aa);
        }

        //IMPORTAR CABECERA DOCU

        public string ImportarCabDOCU(string @cCodEmp,
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
out string @cMsgRetorno) 
        {
            return Accessor.ImportarCabDOCU(@cCodEmp,
 @cAnno,
 @cMes,
 @cTipoDocu,
 @cDocumento,
 @dFechaDoc,
 @cCodTra,
 @cTransac,
 @cMoneda,
 @nTipoCambio,
 @cProveedor,
 @cCliente,
 @cCenCosto,
 @cResponsable,
 @cObra,
 @cMaquinas,
 @cLotes,
 @cPedidos,
 @cAlmaEm,
 @cAlmaRe,
 @IN06PRODNATURALEZA,
out  @cDocuNumer,
out  @cMsgRetorno);
        }


        //IMPORTAR MPCAB 

        public string ImportarMPCab(string @cCodEmp, string @cAnno, string @cMes, string @cTipoDocu, string @cDocumento, string @dFechaDoc,
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
out string @cDocuNumer,
 out string @cMsgRetorno) 
        {
            return Accessor.ImportarMPCab(@cCodEmp,@cAnno,@cMes,@cTipoDocu,@cDocumento,@dFechaDoc,      
@cCodTra,      
@cTransac,      
@cMoneda,      
@nTipoCambio,      
@cProveedor,      
@cCliente,      
@cCenCosto,      
@cResponsable,      
@cObra,      
@cMaquinas,      
@cLotes,      
@cPedidos,      
@cAlmaEm,      
@cAlmaRe,      
out@cDocuNumer,
 out@cMsgRetorno );
        }
        //IMPORTAR MPDETALLE
        public string ImportarMPDet(string @cCodEmp,
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
string @IN07CODBLOQUEEMP,
string @IN07CODBLOQUEPROV,
decimal @IN07LARGO,
decimal @IN07ANCHO,
decimal @IN07ALTO,
decimal @IN07LARGOCAN,
decimal @IN07ANCHOCAN,
decimal @IN07ALTOCAN,
string @IN07STATUS,
out string @cMsgRetorno) 
        {
            return Accessor.ImportarMPDetalle( @cCodEmp,          
 @cAnno       ,          
 @cMes        ,          
 @cTipDoc     ,          
 @cNumDoc     ,          
 @cKey        ,          
 @cCodAlm     ,          
 @cCodTra     ,          
 @cTransa     ,          
@nCanArt     ,          
 @nCosUni     ,          
 @nImport     ,          
 @dFechaDoc  ,          
 @nTipoCambio ,          
 @cMoneda    ,          
 @nOrden      ,          
 @cUnidad     ,          
 @IN07CODBLOQUEEMP ,          
 @IN07CODBLOQUEPROV ,          
 @IN07LARGO  ,          
 @IN07ANCHO  ,          
 @IN07ALTO  ,          
 @IN07LARGOCAN ,          
 @IN07ANCHOCAN ,          
 @IN07ALTOCAN  ,          
 @IN07STATUS  ,          
out  @cMsgRetorno);
        }

        public string ImportarDETDOCU(string @cCodEmp,
string @cAnno,
string @cMes,
string @cTipoDocu,
string @cDocumento,
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
string @IN07CODBLOQUEEMP,
string @IN07CODBLOQUEPROV,
decimal @IN07LARGO,
decimal @IN07ANCHO,
decimal @IN07ALTO,
decimal @IN07LARGOCAN,
decimal @IN07ANCHOCAN,
decimal @IN07ALTOCAN,
string @IN07STATUS,

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
out int @flagReturn,
out string @cMsgRetorno) 
        {
            return Accessor.ImportarDETDOCU( @cCodEmp,
 @cAnno,
 @cMes,
 @cTipoDocu,
 @cDocumento,
 @cKey,
 @cCodAlm,
 @cCodTra,
 @cTransa,
 @nCanArt,
 @nCosUni,
 @nImport,
 @dFechaDoc,
 @nTipoCambio,
 @cMoneda,
 @nOrden,
 @cUnidad,
 @IN07CODBLOQUEEMP ,          
 @IN07CODBLOQUEPROV ,          
 @IN07LARGO  ,          
 @IN07ANCHO  ,          
 @IN07ALTO  ,          
 @IN07LARGOCAN ,          
 @IN07ANCHOCAN ,          
 @IN07ALTOCAN  ,          
 @IN07STATUS  ,

 @IN07NROCAJA,
 @IN07ORDPROD,
 @IN07PEDVEN,
 @IN07DocIngAA,
 @IN07DocIngMM,
 @IN07DocIngTIPDOC,
 @IN07DocIngCODDOC,
 @IN07DocIngKEY,
 @IN07DocIngORDEN,
 @IN07FLAGSTOCKREAL,
 @IN07PROVMATPRIMA,
 @IN07AREAXUNI,
 @in07pedvennum,
 @in07pedvencodprod,
 @in07pedvenitem,
 @IN07CODCLI,
 @in07observacion,
 @IN07ORDENTRABAJO,
 @IN07CALIDADMP, 
   
out  @flagReturn  ,              
out  @cMsgRetorno );
        }

        #region Accessor

        private static DocumentoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DocumentoAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
