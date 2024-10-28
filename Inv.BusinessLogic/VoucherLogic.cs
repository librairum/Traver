using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Transactions;
using System.Data;
using System.Collections;
namespace Inv.BusinessLogic
{
    public class VoucherLogic
    {
         #region Singleton
        private static volatile VoucherLogic instance;
        private static object syncRoot = new Object();

        private VoucherLogic() { }

        public static VoucherLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new VoucherLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public void EliminarCabecera(Voucher entidad, 
            
        out int @flag, out string @cMsgRetorno)
        { 
            
            Accessor.Spu_Com_Del_CabeceraVoucher( entidad.CodigoEmpresa, entidad.Anio,  
                entidad.Mes, entidad.libro, entidad.numero, out  @flag, out @cMsgRetorno);
        }

        public void InsertarCabecera(Voucher entidad,string @cVoucherNro, out string  @cVoucherSalida, out int @flag, out string @cMsgRetorno)
            
        { 
            Accessor.Spu_Com_Ins_CabeceraVoucher(entidad.CodigoEmpresa,  entidad.Anio, entidad.Mes, entidad.libro,    
                string.Format("{0:yyyyMMdd}", entidad.fecha), entidad.detalle, entidad.astip, entidad.trans,@cVoucherNro,
                 out @cVoucherSalida, out @flag, out cMsgRetorno);
            
        }
        public void ActualizarCabecera(Voucher entidad, out int @flag, out string @cMsgRetorno)
        {
            //numero voucher = numero
            Accessor.Spu_Com_Upd_CabeceraVoucher(entidad.CodigoEmpresa, entidad.Anio, entidad.Mes, entidad.libro,
                                    entidad.numero, string.Format("{0:yyyyMMdd}", entidad.fecha), entidad.detalle, 
                                    out @flag, out @cMsgRetorno);
        }

        public void EliminarDetalle(Voucher entidad, out int flag, out string mensaje)
        {
            Accessor.Spu_Com_Del_DetallesVoucher(entidad.CodigoEmpresa, entidad.Anio, entidad.Mes, entidad.libro, 
                entidad.numero, out flag, out mensaje);
        }

        public  void InsertarDetalle(VoucherDetalle entidad, out int flag, out string @cMsgRetorno)
        { 
           
            Accessor.Spu_Com_Ins_DetalleVoucher(entidad.CodigoEmpresa, entidad.Anio, entidad.Mes, 
            entidad.libro, entidad.NumeroVoucher, entidad.cuenta, entidad.ImporteDebe, entidad.ImporteHaber, 
            entidad.glosa, entidad.TipoDocumento, entidad.NumDoc, string.Format("{0:yyyyMMdd}", entidad.FechaDoc), 
            string.Format("{0:yyyyMMdd}", entidad.FechaVencimiento), entidad.CuentaCorriente, 
            entidad.moneda, 
            entidad.TipoCambio, 
            entidad.Afecto, 
            entidad.CenCos, 
            entidad.CenGes, 
            entidad.AsientoTipo, 
            entidad.valida, 
            entidad.ImporteDebeEquivalencia, 
            entidad.ImporteHaberEquivalencia, 
            entidad.transa, 
            entidad.Amarre, 
            entidad.NroPago,
            string.Format("{0:yyyyMMdd}", entidad.FechaPago), 
            entidad.Porcentaje, 
            entidad.DocModTipo,entidad.DocModNumero,string.Format("{0:yyyyMMdd}", entidad.DocModFecha),
            out flag,  
            out @cMsgRetorno);
        }



        public List<VoucherDetalle> TraeDetalleVoucher(string @cEmpresa, string @cAno,
        string @cMes, string @cLibro, string @cVoucher, double @nroOrden)
        { 
            return Accessor.Spu_Com_Trae_DetalleVoucher(@cEmpresa, @cAno, @cMes,
                                                            @cLibro, @cVoucher, @nroOrden);
        }
        public List<VoucherDetalle> TraeDetalleVoucherCab(string @cEmpresa, string @cAno,
       string @cMes, string @cLibro, string @cVoucher)
        {
            return Accessor.Spu_Com_Trae_Detalle_VoucherCab(@cEmpresa, @cAno, @cMes,
                                                            @cLibro, @cVoucher);
        }

        public void TraeDameTotalVoucher(string @cEmpresa, string @cAno, string @cMes,
        string @cLibro, string @cVoucher, out double @nTotDebSol, out double @nTotHabSol,
        out double @nTotDebDol, out double @nTotHabDol)
        { 
            Accessor.Spu_Com_Trae_DameTotalVoucher(@cEmpresa, @cAno, @cMes,
                        @cLibro, @cVoucher, out @nTotDebSol, out @nTotHabSol,
                        out @nTotDebDol, out @nTotHabDol);
        }



        public void TraeVoucherCuadrado(string @ccd01emp, string @ccd01ano,
        string @ccd01mes, string @ccd01subd, string @ccd01numer,
        string @Flag, out double @valor)
        {
            Accessor.Spu_Com_Trae_VoucherCuadrado(@ccd01emp, @ccd01ano, @ccd01mes,
                                        @ccd01subd, @ccd01numer, @Flag, out @valor);
        }



        public void TraeDimeExisteTiCambio(string @dFecha, out double @nRegistros)
        { 
            Accessor.Spu_Glo_Trae_DimeExisteTiCambio(@dFecha, out @nRegistros);
        }


        public void EliminaDetalle(string @cEmpresa, string @cAno, string @cMes, string @cLibro,
        string @cVoucher,  double @nOrden, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.Spu_Com_Del_DetalleVoucher(@cEmpresa, @cAno, @cMes, @cLibro, @cVoucher, 
                                                     @nOrden, out @flag, out @cMsgRetorno);
        }

        //Ayuda de HabyMov
        public List<CuentaContable> TraeCuentasHabYMov(string @cEmpresa, string @ccm01aa, string @cCampo, string @cFiltro)
        { 
            return Accessor.Spu_Com_Trae_HelpCuentasHabYMov(@cEmpresa, @ccm01aa, @cCampo, @cFiltro);
        }

        
        public  List<CentroGestion> TraeCenGesTipoSoloMo(string @cEmpresa, string @cCampo, string @cFiltro, string @cTipo)
        {
            return Accessor.Spu_Com_Trae_HelpCenGesTipoSoloMo(@cEmpresa, @cCampo, @cFiltro, @cTipo);
        }
        //Spu_Com_Trae_HelpDocumPendientes


        public List<DocumentosPendiente> TraeDocumPendientes(string @cEmpresa, string @ccm01aa, string @cCuenta, string @cCtaCte,
        string @dFecha, string @cCampo, string @cFiltro)
        { 
            return Accessor.Spu_Com_Trae_HelpDocumPendientes(@cEmpresa, @ccm01aa, @cCuenta, @cCtaCte,
                    string.Format("{0:ddMMyyy}", @dFecha), @cCampo, @cFiltro);
        }


        public void ActualizoDetalle(VoucherDetalle entidad,
        out int @flag, out string @cMsgRetorno)
        {
            Accessor.Spu_Com_Upd_DetalleVoucher(entidad.CodigoEmpresa, entidad.Anio, entidad.Mes, entidad.libro,
             entidad.NumeroVoucher, entidad.cuenta, entidad.ImporteDebe, entidad.ImporteHaber, entidad.glosa, entidad.TipoDocumento,
             entidad.NumDoc, string.Format("{0:yyyyMMdd}", entidad.FechaDoc), string.Format("{0:yyyyMMdd}", entidad.FechaVencimiento), 
             entidad.CuentaCorriente, entidad.moneda, entidad.TipoCambio, entidad.Afecto, entidad.CenCos, entidad.CenGes, 
             entidad.AsientoTipo, entidad.valida, entidad.ImporteDebeEquivalencia, entidad.ImporteHaberEquivalencia, entidad.transa, entidad.orden,
             entidad.NroPago, string.Format("{0:yyyyMMdd}", entidad.FechaPago), entidad.Porcentaje,
             entidad.DocModTipo, entidad.DocModNumero, string.Format("{0:yyyyMMdd}", entidad.DocModFecha),
             out  @flag, out  @cMsgRetorno);
        }

        public List<Voucher> TraeCabecera(string @Empresa, string @Anio, string @Mes,
                                                                    string @libro, string @numeroVoucher)
        { 
            return Accessor.Spu_Com_Trae_VoucherCabecera(@Empresa, @Anio, @Mes,
                                                                    @libro, @numeroVoucher);
        }

        public void TraeTipoCambioCuenta(string @cEmpresa, string @ccm01aa, string @cCuenta,
                                         string @dFecha, out double @nTipCam)
        {
            Accessor.TraeTipoCambioCuenta(@cEmpresa, @ccm01aa, @cCuenta, @dFecha, out @nTipCam);
        }
        public void TraeTipoCambioFecha(string @dFecha, string @cTipCam, string @cValCam, out double @nTipCam)
        { 
            Accessor.TraeTipoCambioFecha(@dFecha, @cTipCam, @cValCam, out @nTipCam);
        }
        //    Spu_Com_Del_DetallesVoucher(string @cEmpresa,
        //string @cAno, string @cMes, string @cLibro, string @cVoucher,
        //out int @flag, out string @cMsgRetorno);
        public void TraenroOrdenDetalle(string @ccd01emp, string @ccd01ano, string @ccd01mes,
            string @ccd01subd, string @ccd01numer, string @flagMantenimiento, out double @numeroOrden)
        {
            Accessor.Spu_Com_Trae_OrdenRegistroContable(@ccd01emp, @ccd01ano, @ccd01mes,
            @ccd01subd, @ccd01numer, @flagMantenimiento, out @numeroOrden);
        }

        public void ExisteDocumento(string @cEmpresa, string @cAno, string @cMes,
        string @cLibro, string @cVoucher, out double @nRegistros)
        {
            Accessor.sp_Glo_Dime_Existe_Voucher(@cEmpresa, @cAno, @cMes,
                @cLibro, @cVoucher, out @nRegistros);
        }
        /// <summary>
        /// Generar el detalle de Voucher
        /// </summary>
        /// <param name="entidad">Parametro de tipo voucher detalle</param>
        /// <param name="cMsgRetorno">Respuesta de exitos del procedimiento</param>
        public void  GeneraDetalle(VoucherDetalle entidad, 
        out string @cMsgRetorno)
        {
            Accessor.sp_Inv_Ins_Detalle_Voucher(entidad.CodigoEmpresa, entidad.Anio, entidad.Mes, entidad.libro,
                entidad.NumeroVoucher, entidad.cuenta, entidad.ImporteDebe, entidad.ImporteHaber, entidad.glosa,
                entidad.TipoDocumento, entidad.NumDoc, string.Format("{0:yyyyMMdd}",entidad.FechaDoc), 
                string.Format("{0:yyyyMMdd}", entidad.FechaVencimiento),
                entidad.CuentaCorriente, entidad.moneda, entidad.TipoCambio, entidad.Afecto, entidad.CenCos,
                entidad.CenGes, entidad.AsientoTipo, entidad.valida, entidad.ImporteDebeEquivalencia, 
                entidad.ImporteHaberEquivalencia, 
                entidad.transa,entidad.Amarre, out @cMsgRetorno);

                /*
                 string @cEmpresa, string @cAno, string @cMes, string @cLibro,
        string @cVoucher, string @cCuenta, double @nDebSol, double @nHabSol, string @cGlosa, string @cTipDoc, string @cNumDoc, string @dFecDoc,
        string @dFecVen,string @cCtaCte,string @cMoneda,double @nTipCam,string @cAfecto, string @cCenCos,
        string @cCenGes,string @cAsiTipo,string @cValida, double @nDebDol,double @nHabDol, string @cTrans,string @cAmarre,
                 */
        }

        public void GeneraCabecera(Voucher entidad,  string @cVoucher, out string @cMsgRetorno) {
            Accessor.sp_Inv_Ins_Cabecera_Voucher(entidad.CodigoEmpresa, entidad.Anio, entidad.Mes,
                entidad.libro, string.Format("{0:yyyyMMdd}", entidad.fecha), entidad.detalle, "", "N",
                cVoucher, out cMsgRetorno);

        }

        //public void Spu_Inv_Gen_VoucherContable
        /*
         * public abstract void sp_Inv_Ins_Cabecera_Voucher(string @cEmpresa, string @cAno, string @cMes,
        string @cLibro, string @dFecha, string @cDetalle, string @cAsiTipo, string @cTrans,
        out string @cVoucher, out string @cMsgRetorno);
         * */
        public DataTable GeneraVoucherContable(string @cCodEmp, string @cAno, string @cPeriodo)
        {
           return  Accessor.Spu_Inv_Gen_VoucherContable(@cCodEmp, @cAno, @cPeriodo);
        }

        public DataTable GeneraVoucherContablexTipTran(string @Empresacod, string @Anio, string @Mes)
        {
            return Accessor.Spu_Inv_Gen_VoucherContablexTipTran(@Empresacod, @Anio, @Mes);
        }
        public DataTable Traer_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP) 
        {
            return Accessor.Spu_Fact_Traer_FAC89_SUBPLANTILLA_X_VOUCHER(@FAC89CODEMP);
        }


        public string Insertar_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP, string @FAC89TIPDOCCOD, string @FAC89SUBPLANTILLACOD, int @FAC89CORRELATIVO, string @FAC89ASIENTOTIPOCOD, string @FAC89DOCMONEDA, string @FAC89DOCESTADOSUNAT, string @FAC89NUMERACIONNOMENCLATURA, out string @Msg, out int @flag) 
        {
            return Accessor.Spu_Fact_Ins_FAC89_SUBPLANTILLA_X_VOUCHER(@FAC89CODEMP, @FAC89TIPDOCCOD, @FAC89SUBPLANTILLACOD, @FAC89CORRELATIVO, @FAC89ASIENTOTIPOCOD, @FAC89DOCMONEDA, @FAC89DOCESTADOSUNAT, @FAC89NUMERACIONNOMENCLATURA, out @Msg, out @flag);
        }
        public DataTable Traer_Spu_Fact_Trae_EStadoFacturas() 
        {
            return Accessor.Spu_Fact_Trae_EStadoFacturas();
        }
        
        public string Actualizar_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP, string @FAC89TIPDOCCOD, string @FAC89SUBPLANTILLACOD, int @FAC89CORRELATIVO, string @FAC89ASIENTOTIPOCOD, string @FAC89DOCMONEDA, string @FAC89DOCESTADOSUNAT, string @FAC89NUMERACIONNOMENCLATURA, out string @Msg, out int flag) 
        {
            return Accessor.Spu_Fact_Upd_FAC89_SUBPLANTILLA_X_VOUCHER(@FAC89CODEMP, @FAC89TIPDOCCOD, @FAC89SUBPLANTILLACOD, @FAC89CORRELATIVO, @FAC89ASIENTOTIPOCOD, @FAC89DOCMONEDA, @FAC89DOCESTADOSUNAT, @FAC89NUMERACIONNOMENCLATURA, out @Msg, out flag);
        }
        
        public string Eliminar_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP, string @FAC89TIPDOCCOD, string @FAC89SUBPLANTILLACOD, int @FAC89CORRELATIVO,out string @Msg, out int @flag) 
        {
            return Accessor.Spu_Fact_Del_FAC89_SUBPLANTILLA_X_VOUCHER( @FAC89CODEMP,  @FAC89TIPDOCCOD,  @FAC89SUBPLANTILLACOD,  @FAC89CORRELATIVO,out @Msg, out @flag);
        }
        #region Accessor

        private static VoucherAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return VoucherAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
