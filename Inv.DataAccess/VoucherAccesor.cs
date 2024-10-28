using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using System.Data;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
    public abstract class VoucherAccesor : AccessorBase<VoucherAccesor>
    {
        [SprocName("Spu_Com_Del_CabeceraVoucher")]
        public abstract void Spu_Com_Del_CabeceraVoucher(string @cEmpresa,
        string @cAno,string @cMes,string @cLibro,string @cVoucher,
        out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Ins_CabeceraVoucher")]
        public abstract void Spu_Com_Ins_CabeceraVoucher(string @cEmpresa,string @cAno,
        string @cMes,string @cLibro,string @dFecha,string @cDetalle,string @cAsiTipo,string @cTrans,string @cVoucherNro,
        out string @cVoucher, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_DetallesVoucher")]
        public abstract void Spu_Com_Del_DetallesVoucher(string @cEmpresa,  
        string @cAno, string @cMes, string @cLibro, string @cVoucher,  
        out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Ins_DetalleVoucher")]
        public abstract void Spu_Com_Ins_DetalleVoucher(string @cEmpresa, string @cAno, string @cMes,
        string @cLibro, string @cVoucher, string @cCuenta, double @nDebSol, double @nHabSol, string @cGlosa,  
        string @cTipDoc, string @cNumDoc, string @dFecDoc, string @dFecVen, string @cCtaCte,  string @cMoneda,
        double @nTipCam, string @cAfecto, string @cCenCos, string @cCenGes, string @cAsiTipo, string @cValida,
        double @nDebDol, double @nHabDol, string @cTrans, string @cAmarre, string @ccd01NroPago, string @ccd01FecPago,  
        string @ccd01porcentaje,  
        string @ccd01cqmtipo,string @ccd01cqmnumero,string @ccd01cqmfecha,    
        out int flag , out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_DetalleVoucher")]
        public abstract List<VoucherDetalle> Spu_Com_Trae_DetalleVoucher(string @cEmpresa, string @cAno,
        string @cMes, string @cLibro, string @cVoucher, double @nroOrden);

        //CAB
        [SprocName("Spu_Com_Trae_Detalle_Voucher")]
        public abstract List<VoucherDetalle> Spu_Com_Trae_Detalle_VoucherCab(string @cEmpresa, string @cAno,
        string @cMes, string @cLibro, string @cVoucher);


        [SprocName("Spu_Com_Trae_DameTotalVoucher")]
        public abstract void Spu_Com_Trae_DameTotalVoucher(string @cEmpresa, string @cAno, string @cMes,
        string @cLibro, string @cVoucher, out double @nTotDebSol, out double @nTotHabSol,
        out double @nTotDebDol, out double @nTotHabDol);


        [SprocName("Spu_Com_Trae_VoucherCuadrado")]
        public abstract void Spu_Com_Trae_VoucherCuadrado(string @ccd01emp, string @ccd01ano,
        string @ccd01mes, string @ccd01subd, string @ccd01numer,
        string @Flag, out double @valor);


        [SprocName("Spu_Glo_Trae_DimeExisteTiCambio")]
        public abstract void Spu_Glo_Trae_DimeExisteTiCambio(string @dFecha, out double @nRegistros);

        [SprocName("Spu_Com_Del_DetalleVoucher")]
        public abstract void Spu_Com_Del_DetalleVoucher(string @cEmpresa, string @cAno, string @cMes, string @cLibro,
        string @cVoucher,  double @nOrden, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_HelpCuentasHabYMov")]
        public abstract List<CuentaContable> Spu_Com_Trae_HelpCuentasHabYMov(string @cEmpresa, string @ccm01aa, string @cCampo, string @cFiltro);

        [SprocName("Spu_Com_Trae_HelpCenGesTipoSoloMo")]
        public abstract List<CentroGestion> Spu_Com_Trae_HelpCenGesTipoSoloMo(string @cEmpresa, string @cCampo, string @cFiltro, string @cTipo);
        //Spu_Com_Trae_HelpDocumPendientes

        [SprocName("Spu_Com_Trae_HelpDocumPendientes")]
        public abstract List<DocumentosPendiente> Spu_Com_Trae_HelpDocumPendientes(string @cEmpresa, string @ccm01aa, string @cCuenta, string @cCtaCte,
        string @dFecha, string @cCampo, string @cFiltro);

        [SprocName("Spu_Com_Upd_DetalleVoucher")]
        public abstract void Spu_Com_Upd_DetalleVoucher(string @cEmpresa, string @cAno, string @cMes, string @cLibro,
        string @cVoucher, string @cCuenta, double @nDebSol, double @nHabSol, string @cGlosa, string @cTipDoc,
        string @cNumDoc, string @dFecDoc, string @dFecVen, string @cCtaCte, string @cMoneda,
        double @nTipCam, string @cAfecto, string @cCenCos, string @cCenGes, string @cAsiTipo,
        string @cValida, double @nDebDol, double @nHabDol, string @cTrans, double @nOrden,
        string @ccd01NroPago, string @ccd01FecPago, string @ccd01porcentaje,
        string @ccd01cqmtipo, string @ccd01cqmnumero, string @ccd01cqmfecha,    

            out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_VoucherCabecera")]
        public abstract List<Voucher> Spu_Com_Trae_VoucherCabecera( string @Empresa,string @Anio, string @Mes, 
                                                                    string @libro,string @numeroVoucher);

        [SprocName("sp_Com_Dame_TiCambio_Cuenta")]
        public abstract void TraeTipoCambioCuenta(string @cEmpresa, string @ccm01aa, string @cCuenta,
        string @dFecha, out double @nTipCam);
        
        [SprocName("sp_Glo_Trae_TiCambio_Fecha")]
        public abstract void TraeTipoCambioFecha(string @dFecha, string @cTipCam, string @cValCam, out double @nTipCam);
        [SprocName("Spu_Com_Trae_OrdenRegistroContable")]
        public abstract void Spu_Com_Trae_OrdenRegistroContable(string @ccd01emp, string @ccd01ano, string @ccd01mes,
            string @ccd01subd, string @ccd01numer, string @flagMantenimiento, out double @numeroOrden);

        [SprocName("Spu_Com_Upd_CabeceraVoucher")]
        public abstract void Spu_Com_Upd_CabeceraVoucher(string @cEmpresa, string @cAno, string @cMes, 
        string @cLibro,string @cVoucher, string @dFecha,string @cDetalle,out int @flag,out string @cMsgRetorno);


        [SprocName("sp_Glo_Dime_Existe_Voucher")]
        public abstract void sp_Glo_Dime_Existe_Voucher(string @cEmpresa, string @cAno, string @cMes,
        string @cLibro, string @cVoucher, out double @nRegistros);
        
        
        //Insertar detalle para Generar Voucher
        [SprocName("sp_Inv_Ins_Detalle_Voucher")]
        public abstract void sp_Inv_Ins_Detalle_Voucher(string @cEmpresa, string @cAno, string @cMes, string @cLibro,
        string @cVoucher, string @cCuenta, double @nDebSol, double @nHabSol, string @cGlosa, string @cTipDoc, string @cNumDoc, string @dFecDoc,
        string @dFecVen,string @cCtaCte,string @cMoneda,double @nTipCam,string @cAfecto, string @cCenCos,
        string @cCenGes,string @cAsiTipo,string @cValida, double @nDebDol,double @nHabDol, string @cTrans,string @cAmarre,
        out string @cMsgRetorno);


        //Insertar cabecera para Generar Voucher
        [SprocName("sp_Inv_Ins_Cabecera_Voucher")]
        public abstract void sp_Inv_Ins_Cabecera_Voucher(string @cEmpresa,   string @cAno,  string @cMes,  
        string @cLibro,  string @dFecha,  string @cDetalle, string @cAsiTipo,string @cTrans,
        string @cVoucher,out string @cMsgRetorno);


        [SprocName("Spu_Inv_Gen_VoucherContable")]
        public abstract DataTable Spu_Inv_Gen_VoucherContable(string @cCodEmp, string @cAno, string @cPeriodo);

        [SprocName("Spu_Inv_Gen_VoucherContablexTipTran")]
        public abstract DataTable Spu_Inv_Gen_VoucherContablexTipTran(string @Empresacod, string @Anio, string @Mes);
    
    
        //PLANTILLA VOUCHER ---------------------
        [SprocName("Spu_Fact_Traer_FAC89_SUBPLANTILLA_X_VOUCHER")]
        public abstract DataTable Spu_Fact_Traer_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP);

        [SprocName("Spu_Fact_Ins_FAC89_SUBPLANTILLA_X_VOUCHER")]
        public abstract string Spu_Fact_Ins_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP, string @FAC89TIPDOCCOD, string @FAC89SUBPLANTILLACOD, int @FAC89CORRELATIVO, string @FAC89ASIENTOTIPOCOD, string @FAC89DOCMONEDA, string @FAC89DOCESTADOSUNAT, string @FAC89NUMERACIONNOMENCLATURA, out string @Msg, out int  @flag);

         [SprocName("Spu_Fact_Upd_FAC89_SUBPLANTILLA_X_VOUCHER")]
        public abstract string Spu_Fact_Upd_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP, string @FAC89TIPDOCCOD, string @FAC89SUBPLANTILLACOD, int @FAC89CORRELATIVO, string @FAC89ASIENTOTIPOCOD, string @FAC89DOCMONEDA, string @FAC89DOCESTADOSUNAT, string @FAC89NUMERACIONNOMENCLATURA, out string @Msg, out int @flag);



             [SprocName("Spu_Fact_Del_FAC89_SUBPLANTILLA_X_VOUCHER")]
         public abstract string Spu_Fact_Del_FAC89_SUBPLANTILLA_X_VOUCHER(string @FAC89CODEMP, string @FAC89TIPDOCCOD, string @FAC89SUBPLANTILLACOD, int @FAC89CORRELATIVO, out string @Msg, out int @flag);
        
        //AYUDA SP_ESTADOSUNAT
             [SprocName("Spu_Fact_Trae_EStadoFacturas")]
             public abstract DataTable Spu_Fact_Trae_EStadoFacturas();

    
    }
}
