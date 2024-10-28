using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data.SqlClient;
using System.Data;
namespace Inv.BusinessLogic
{
    public class TipoDocumentoLogic
    {
        public string Eliminar_Rango_Impresion(string @cEmpresa, string @cUsuario, string @cProceso, out string @cMsgRetorno) 
        {
           return Accessor.Eliminar_Rango_Impresion(@cEmpresa, @cUsuario, @cProceso,out @cMsgRetorno);
        }
        public DataTable Traer_Sp_Inv_Rep_Centro_Debe_Haber(string @cCodEmp, string @cMes, string @cAno, string @cFechaInicio, string @cFechaFinal, string @cCentroCosto, string @cPedido, string @cFiltro)
        {
            return Accessor.Traer_Sp_Inv_Rep_Centro_Debe_Haber(@cCodEmp, @cMes, @cAno, @cFechaInicio, @cFechaFinal, @cCentroCosto, @cPedido, @cFiltro);
        }
        #region Singleton
        private static volatile TipoDocumentoLogic instance;
        private static object syncRoot = new Object();

        private TipoDocumentoLogic() { }

        public static TipoDocumentoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TipoDocumentoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public List<TipoDocumento> TraerTipoDcoumentoxMovimiento(string @in12codemp, string @in12TipMov) {
            return Accessor.TraerTipoDcoumentoxMovimiento(@in12codemp, @in12TipMov);
        }
        public TipoDocumento TraerTipoDocumentoRegistro(string codigo, string tipodoc)
        {
            return Accessor.TipoDocumentoTraerRegistro(codigo, tipodoc);
        }
        public List<TipoDocumento> TraerTipoDocumento1(string codigoEmpresa)
        {
            return Accessor.TraerTipoDocumento1(codigoEmpresa, "In12tipDoc", "*");
        }
        public List<TipoDocumento> TraerTipoDocumentoxNaturaleza(string codigoEmpresa, string naturaleza) {
            return Accessor.TraerTipoDocumento1(codigoEmpresa, "In12tipDoc", "in12naturaleza = '"+ naturaleza +"'");
            //exec sp_Inv_Trae_Tipo_Documento '01', 'in12TipDoc', ' in12naturaleza = ''02'' '
        }
        public DataTable Traer_Transaccion_Empresa(string @cCodEmp) 
        {
            return Accessor.Traer_Transaccion_Empresa(@cCodEmp);
        }
        /// <summary>
        /// Traer ayuda por tipo de documento E -> Entrdad : S -> Salida.
        /// </summary>
        /// <param name="codigoEmpresa"></param>
        /// <param name="tipoMovimiento"></param>
        /// <returns></returns>
        public List<TipoDocumento> TraerTipoDocumento2(string codigoEmpresa,string tipoMovimiento) {
            return Accessor.TraerTipoDocumento1(codigoEmpresa, "In12tipDoc", " In12TipMov = '" + tipoMovimiento + "'");
        }
        
        //Se creo este metodo con el parametro tipoNatulera para filtrar los documento por movimiento y tipo de de naturaleza del mismo
        public List<TipoDocumento> TraerTipoDocumento2(string codigoEmpresa, string tipoMovimiento, string tipoNaturaleraza) {
            //return Accessor.TraerTipoDocumento1(codigoEmpresa, "In12tipDoc"," In12TipMov = '" + tipoMovimiento + "'" + " And in12naturaleza = '" + tipoNaturaleraza + "'");
            return Accessor.TraerTipoDocumento1(codigoEmpresa,tipoMovimiento,tipoNaturaleraza);
        }
        public DataTable Trae_TipDocParaMov(string @In12CodEmp, string @in12naturaleza, string @in12TipMov) 
        {
            return Accessor.Trae_TipDocParaMov(@In12CodEmp, @in12naturaleza, @in12TipMov);
        }
        public void TipoDocumentoInsertar(TipoDocumento tipodocumento, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.TipoDocumentoInsertar(tipodocumento.in12codemp,tipodocumento.In12tipDoc,tipodocumento.in12TipMov,
                tipodocumento.In12DesLar,tipodocumento.in12DesCor,tipodocumento.in12WorStr,tipodocumento.in12Serie,
                tipodocumento.In12NumCon, tipodocumento.In12ExigeDevu,tipodocumento.in12naturaleza,
                tipodocumento.in12longitudDocNum, tipodocumento.in12FlagCalCostoPromedio,
                tipodocumento.in12FlagGeneraAsientoContable,tipodocumento.in12FlagGeneraDocNum, out @cMsgRetorno);

        }
        public void TipoDocumentoModificar(TipoDocumento tipodocumento, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.TipoDocumentoModificar(tipodocumento.in12codemp, tipodocumento.In12tipDoc, tipodocumento.in12TipMov, 
                tipodocumento.In12DesLar, tipodocumento.in12DesCor, tipodocumento.in12WorStr, tipodocumento.in12Serie,
                tipodocumento.In12NumCon, tipodocumento.In12ExigeDevu, tipodocumento.in12naturaleza, tipodocumento.in12FlagCalCostoPromedio, tipodocumento.in12FlagGeneraDocNum, out @cMsgRetorno);
        }
        public void TipoDocumentoEliminar(TipoDocumento tipodocumento, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.TipoDocumentoEliminar(tipodocumento.in12codemp,tipodocumento.In12tipDoc, out @cMsgRetorno);
        }



        public List<ItemsList> ObtenerListItems(string codigoEmpresa)
        {
            var lista = Accessor.TraerTipoDocumento(codigoEmpresa, "*", "*");
            return lista.Select(x => new ItemsList { Value = x.In12tipDoc, Text = x.In12DesLar }).ToList();
        }
        public string DameVariable(string @cCodEmp, string @cCodigo)
        {
            string variable = string.Empty;
            Accessor.DameVariable(cCodEmp, cCodigo, "TIPODOCUMENTO", out variable);
            return variable;
        }
        public List<TipoDocumento> TraerTipoDocumento(string codigoEmpresa)
        {
            return Accessor.TraerTipoDocumento(codigoEmpresa, "in12DesLar", "*");
        }
        public DataTable Spu_Inv_Rep_Transaccion_Res(string IN07CODEMP, string IN07AA, string fechaIni, string fechaFin,
            string XMLrango,string bandera) {
            return Accessor.Spu_Inv_Rep_Transaccion_Res(IN07CODEMP, IN07AA, fechaIni, fechaFin, XMLrango,bandera);
        }

        public DataTable Spu_Inv_Rep_TransaccionSum(string IN07CODEMP, string IN07AA, string fechaIni, string fechaFin,
            string XMLrango,string Almacen, string bandera)
        {
            return Accessor.Spu_Inv_Rep_TransaccionSum(IN07CODEMP, IN07AA, fechaIni, fechaFin, XMLrango,Almacen, bandera);
        }

        public DataTable Spu_Inv_Rep_MovPorMes(string @Empresa, string @Anio, string @MesIni, string @MesFin, string @Transa, string @XMLrango)
        {
            return Accessor.Spu_Inv_Rep_MovPorMes(@Empresa, @Anio, @MesIni, @MesFin, @Transa, @XMLrango);
        }

        
        public DataTable Spu_Pro_Rep_prodxoperador(string IN07CODEMP, string IN07AA, string fechaIni, string 
                                                            fechaFin,string flag,string IN06PRODNATURALEZA, string XMLrango)
        {
            return Accessor.Spu_Pro_Rep_prodxoperador(IN07CODEMP, IN07AA, fechaIni,fechaFin,flag,IN06PRODNATURALEZA,XMLrango);
        }

        //public DataTable Spu_Pro_Rep_RendimientoBloque(string IN07CODEMP, string IN07AA, string fechaIni, string
        //                                                    fechaFin, string flag, string IN06PRODNATURALEZA, string XMLrango)
        //{
        //    return Accessor.Spu_Pro_Rep_RendimientoBloque(IN07CODEMP, IN07AA, fechaIni, fechaFin, flag, IN06PRODNATURALEZA, XMLrango);
        //}

        //public DataTable Spu_Pro_Rep_RendixProducto(string IN07CODEMP, string IN07AA, string fechaIni, string
        //                                                    fechaFin, string flag, string IN06PRODNATURALEZA, string XMLrango)
        //{
        //    return Accessor.Spu_Pro_Rep_RendixProducto(IN07CODEMP, IN07AA, fechaIni, fechaFin, flag, IN06PRODNATURALEZA, XMLrango);
        //}

        public DataTable Spu_Pro_Rep_Rendimiento(string @IN07CODEMP, string @IN07AA,  string @fechaIni, string @fechaFin, 
                                                        string @flag, string @XMLrango, string @Linea) {
            return Accessor.Spu_Pro_Rep_Rendimiento(@IN07CODEMP, @IN07AA, @fechaIni, @fechaFin, @flag, @XMLrango, @Linea);
        }

        public DataTable Spu_Pro_Trae_Prodxdia(string @empresa, string @anio, string @linea, string @fechaIni, string @fechaFin,
                                                        string @flag, string @XMLrango)
        {
            return Accessor.Spu_Pro_Trae_Prodxdia(@empresa, @anio, @linea, @fechaIni, @fechaFin, @flag, @XMLrango);
        }

        public DataTable Spu_Pro_Trae_ProdDiaria(string @empresa, string @anio, string @linea, string @fechaIni, string @fechaFin,
                                                        string @flag, string @XMLrango)
        {
            return Accessor.Spu_Pro_Trae_ProdDiaria(@empresa, @anio, @linea, @fechaIni, @fechaFin, @flag, @XMLrango);
        }

        public DataTable Spu_Pro_Rep_Validaciones(string @empresa)
        {
            return Accessor.Spu_Pro_Rep_Validaciones(@empresa);
        }

        

        public DataTable Spu_Inv_Rep_Valida(string IN07CODEMP, string IN07AA, string @IN07MM)
        {
            return Accessor.Spu_Inv_Rep_Valida(IN07CODEMP, IN07AA, @IN07MM);
        }

        public DataTable Spu_Inv_Rep_ProvMatPriSalida(string @IN07CODEMP, string @IN07AA, string @IN07MMINI, string @IN07MMFIN, string @XMLrango, string @XMLrango2, string @tipoanalisi)
        {
            return Accessor.Spu_Inv_Rep_ProvMatPriSalida(@IN07CODEMP, @IN07AA, @IN07MMINI, @IN07MMFIN, 
                                                         @XMLrango, @XMLrango2, @tipoanalisi);
        }

        public DataTable Spu_Inv_Rep_MovXResponsable(string @CodEmp, string @Ano, string @FlagRango, string @FechaIni, string @FechaFin, string @FlagEntregaORecep, string @CodResp, string @XMLrango)
        {
            return Accessor.Spu_Inv_Rep_MovXResponsable(@CodEmp, @Ano, @FlagRango, @FechaIni, @FechaFin, @FlagEntregaORecep, @CodResp, @XMLrango);
        }

        public DataTable Spu_Inv_Rep_MovXDocRespaldo(string IN07CODEMP, string IN07AA, string fechaIni, string fechaFin,
            string bandera, string XMLrango)
        {
            return Accessor.Spu_Inv_Rep_MovXDocRespaldo(IN07CODEMP, IN07AA, fechaIni, fechaFin, bandera, XMLrango);
        }

        public DataTable Spu_Inv_Rep_IngProduccion(string IN07CODEMP, string IN07AA, string fechaIni, string fechaFin,
            string bandera, string tipanaliproductor, string XMLrango)
        {
            return Accessor.Spu_Inv_Rep_IngProduccion(IN07CODEMP, IN07AA, fechaIni, fechaFin, bandera, tipanaliproductor, XMLrango);
        }
        public List<TipoDocumentoVentas> TraerTipoDocumentoFA(string @FAC01CODEMP, string @campo, string @filtro)
        { 
            return Accessor.Spu_Fact_Trae_FAC01_TIPDOC(@FAC01CODEMP, @campo, @filtro);
        }

        public List<Spu_Fact_Trae_Por_Periodo> TraerDocumentoxPeriodoFA(string @FAC04CODEMP, string @FAC01COD,
            string @FAC04AA, string @FAC04MM, string @campo, string @filro, string @NombreUsuario)
        {
            return Accessor.Spu_Fact_Trae_Por_Periodo(@FAC04CODEMP, @FAC01COD,
                                            @FAC04AA, @FAC04MM, @campo, @filro, @NombreUsuario);
        }
        public List<ComprasTipoDocumento> ComprasTraeAyudaTiposDocumentos(string @cEmpresa, string @cCampo, string @cFiltro)
        { 
            return Accessor.Spu_Com_Trae_ComAyudaTiposDocumentos(@cEmpresa, @cCampo, @cFiltro);
        }
        #region "Reportes - Transacciones de Materia Prima"

        public DataTable Spu_Inv_Rep_TranSalMPaProd(string @IN07CODEMP, string @IN07AA, string @fechaIni, string @fechaFin,
                                                            string @flag, string @IN06PRODNATURALEZA,
                                                            string @IN07CODALM, string @XMLrango)
        { 
            return Accessor.Spu_Inv_Rep_TranSalMPaProd(@IN07CODEMP, @IN07AA, @fechaIni, @fechaFin,
                                                            @flag, @IN06PRODNATURALEZA,
                                                            @IN07CODALM, @XMLrango);
        }

        public DataTable Spu_Inv_Rep_TransIngXCompra(string @IN07CODEMP, string @IN07AA, string @fechaIni,
                                                              string @fechaFin, string @flag, string @IN06PRODNATURALEZA,
                                                              string @IN07CODALM, string @XMLrango)
        { 
            return Accessor.Spu_Inv_Rep_TransIngXCompra(@IN07CODEMP, @IN07AA, @fechaIni,
                                                              @fechaFin, @flag, @IN06PRODNATURALEZA,
                                                              @IN07CODALM, @XMLrango);
        }

        public DataTable Spu_Inv_Rep_TransaccionMP(string @IN07CODEMP, string @IN07AA, string @fechaIni,
                                                            string @fechaFin, string @flag, string @IN06PRODNATURALEZA,
                                                            string @IN07CODALM, string @XMLrango) 
        {
            return Accessor.Spu_Inv_Rep_TransaccionMP(@IN07CODEMP, @IN07AA, @fechaIni,
                                                            @fechaFin, @flag, @IN06PRODNATURALEZA,
                                                            @IN07CODALM, @XMLrango);
        }
        public DataTable Spu_Pro_Rep_TransaccionPP(string @IN07CODEMP, string @IN07AA, string @fechaIni,
                                                           string @fechaFin, string @flag, string @IN06PRODNATURALEZA,
                                                           string @IN07CODALM, string @XMLrango)
        {
            return Accessor.Spu_Pro_Rep_TransaccionPP(@IN07CODEMP, @IN07AA, @fechaIni,
                                                            @fechaFin, @flag, @IN06PRODNATURALEZA,
                                                            @IN07CODALM, @XMLrango);
        }




        #endregion

        
        #region Accessor

        private static TipoDocumentoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TipoDocumentoAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
