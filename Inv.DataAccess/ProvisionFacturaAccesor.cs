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
    public abstract class ProvisionFacturaAccesor: AccessorBase<ProvisionFacturaAccesor>
    {

        [SprocName("Spu_Com_Ins_ProvisionFactura")]
        public abstract void Spu_Com_Ins_ProvisionFactura(string @cCodEmp, string @cAno, string @cMes, string @cTipoOrd, 
        string @cNroOrd,string @TipoDocumento, string @Nrodocumento,string @FechaDocumento, string @FechaVencimiento, 
        string @FechaPago,double @PorIgv,
        double @ImporteAfecto,
        double @ImporteInafecto, 
        double @ImporteIgv, 
        double @ImporteDocumento,

        double @ImporteAfDol,
        double @ImporteInafDol,
        double @ImporteIgvDol,
        double @ImporteDocDol, 
             
        string @TipoMoneda, string @Libro, string @NumVou, string @AsientoTipo, string @TipDocGuia, string @TipTransGuia, 
        string @cNroguia, string @FechaGuia,double @Tipocambio,
            string @Concepto,string @Proveedor,string @CO05ANOORDCOM, 
        string @CO05MESORDCOM, string @CO05AFECTODETRACCION, string @CO05AFECTORET, string @CO05NROAUTORIZACION, 
        string @CO05DETRATIPOPERACION, string @CO05DETRATIPOSERVICIO, double @CO05DETRAPORCENTAJE,
        double @CO05DETRAIMPORTE, double @CO05DETRAIMPORTE_EQUI, string @CO05BIENOSERVSUNAT, 
        string @CO05INVREFDOC,string @CO05CENTRODECOSTO,
        string @CO05DOCMODTIPO, string @CO05DOCMODNUMERO,string @CO05DOCMODFECHA,
        out int @flag,out string @cMsgRetorno);


        [SprocName("Spu_Com_Upd_ProvisionFacturaPagos")]
        public abstract void Spu_Com_Upd_ProvisionFacturaPagos(string @cCodEmp,string @cAno,string @cMes,string @cTipoOrd,string @cNroOrd,
        string @TipoDocumento,string @Nrodocumento,double @ImporteDocumento,double @ImportePagos,string @CO05ANOORDCOM,string @CO05MESORDCOM,
        string @Proveedor,string @CO05AFECTODETRACCION,string @CO05DETRATIPOPERACION, string @CO05DETRATIPOSERVICIO, double @CO05DETRAPORCENTAJE, 
        double @CO05DETRAIMPORTE, double @CO05DETRAIMPORTE_EQUI);
        //NUEVO
        [SprocName("Sp_Com_Upd_ProvisionFactura_AsienCont")]
        public abstract string Sp_Com_Upd_ProvisionFactura_AsienCont(string @cCodEmp, string @cAno, string @cMes, string @cTipoOrd, string @cNroOrd, string @TipoDocumento, string @Nrodocumento, string @Proveedor, string @CO05ANOORDCOM, string @CO05MESORDCOM, string @Libro, string @NumVou, string @AsientoTipo, out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_ProvisionFactura")]
        public abstract void Spu_Com_Upd_ProvisionFactura(string @cCodEmp, string @cAno, string @cMes, string @cTipoOrd, string @cNroOrd,
        string @TipoDocumento,string @Nrodocumento,string @FechaDocumento,string @FechaVencimiento,string @FechaPago,double @PorIgv,
        double @ImporteAfecto,double @ImporteInafecto,double @ImporteIgv,double @ImporteDocumento,
        double @ImporteAfDol,double @ImporteInafDol,double @ImporteIgvDol,double @ImporteDocDol,string @TipoMoneda,string @Libro,
        string @NumVou,string @AsientoTipo,string @TipDocGuia,string @TipTransGuia,string @cNroguia,string @FechaGuia,
        double @Tipocambio,string @Concepto,string @Proveedor,
        string @CO05ANOORDCOM, string @CO05MESORDCOM, string @CO05AFECTODETRACCION, string @CO05AFECTORET, string @CO05NROAUTORIZACION, 
        string @CO05DETRATIPOPERACION, string @CO05DETRATIPOSERVICIO, double @CO05DETRAPORCENTAJE,
        double @CO05DETRAIMPORTE, double @CO05DETRAIMPORTE_EQUI, string @CO05BIENOSERVSUNAT,  string @CO05INVREFDOC,
        string @CO05CENTRODECOSTO,
        string @CO05DOCMODTIPO, string @CO05DOCMODNUMERO, string @CO05DOCMODFECHA,
        out int @flag,out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_Concepto_co07MotivosDocPorPagar")]
        public abstract DataTable Spu_Com_Trae_Concepto_co07MotivosDocPorPagar(string @CO07CODEMP, string @CO07DESCRIPCION); 

        [SprocName("Spu_Com_Trae_FlujoDePago")]
        public abstract List<Spu_Com_Trae_FlujoDePago> Spu_Com_Trae_FlujoDePago(string @CO05CODEMP,string @CO05CODCTE,
        string @co05tipdoc,string @co05nrodoc);


        [SprocName("Spu_Com_Trae_ComAyudaLibroTodos")]
        public abstract List<Libro> Spu_Com_Trae_ComAyudaLibroTodos(string @cEmpresa, string @cAnio, string @cCampo, string @cFiltro);

        [SprocName("Spu_com_trae_retencion")]
        public abstract void Spu_com_trae_retencion(string @ccm02Emp, string @ccm02tipana, string @ccm02cod,
        string @facturafecha, double @facturavaloensoles, string @flagafectodetraccion,
        string @DocumentoTipoCodigo, out int @afecto);


        [SprocName("Spu_Com_Ins_DoumentoMovimiento")]
        public abstract void Spu_Com_Ins_DoumentoMovimiento(string @cCodEmp, string @cAnno, string @cMes, string @cTipoDocu, 
        string @cDocumento,string @dFechaDoc, string @cCodTra, string @cTransac, string @cMoneda, double @nTipoCambio, 
        string @cProveedor, string @cCliente, string @cCenCosto, string @cResponsable, string @cObra, string @cMaquinas, 
        string @cOrdCom, string @cLotes, string @cPedidos, string @cAlmaEm, string @cAlmaRe, string @cDocuNumer,
        string @IN06ANOORDCOMP, string @IN06PRODNATURALEZA, out int @flag, out string @cMsgRetorno);


        [SprocName("Spu_Com_Trae_CorrelativoVoucher")]
        public abstract void Spu_Com_Trae_CorrelativoVoucher(string @ccd01emp, string @ccd01ano, string @ccd01mes, string @ccd01subd, 
        string @ccd01numer,out string @Newccd01numer);

        [SprocName("Spu_Com_Trae_ProvisionesSinOC")]
        public abstract List<ProvisionamientoOrdenCompraDetalle> Spu_Com_Trae_ProvisionesSinOC(string @cCodemp, string @cAno, string @cTipAna,
        string @cTipo, string @cCodigo, string @cFecIni, string @cFecFin, string @cFiltro, 
        string @FacturaTipo, string @FacturaNro);

        [SprocName("Spu_Com_Trae_ProvisionesSinOCPorPeriodo")]
        public abstract List<ProvisionamientoOrdenCompraDetalle> Spu_Com_Trae_ProvisionesSinOCPorPeriodo(string @cCodemp, string @cAno, string @cMes, string @cTipo, string @cTipAna);
        //NUEVO
        [SprocName("Spu_Com_Trae_AutoCompletarMotivoProvision")]
        public abstract DataTable Spu_Com_Trae_AutoCompletarMotivoProvision(string @cCodEmp, string @filtro);

        //NUEVO 
        [SprocName("Spu_Com_Trae_co07MotivosDocPorPagar")]
        public abstract DataTable Spu_Com_Trae_co07MotivosDocPorPagar(string @CO07CODEMP, string @Anio);
        //NUEVO
        [SprocName("Spu_Com_Trae_AsientoContable")]
        public abstract DataTable Spu_Com_Trae_AsientoContable(string @CO05CODEMP, string @CO05AA, string @CO05MES, string @opcion,string @Opcionfiltro,string @XMLrango);

        //NUEVO 
        [SprocName("Spu_Com_Upd_co07MotivosDocPorPagar")]
        public abstract string Spu_Com_Upd_co07MotivosDocPorPagar(string @CO07CODEMP, string @co07descripcion, int @CO07ITEM, string @AsientoTipoCod, string @NOMENCLATURA, out int @flag, out string @Msg);

        [SprocName("Spu_Com_Ins_co07MotivosDocPorPagar")]
        public abstract string Spu_Com_Ins_co07MotivosDocPorPagar(string @CO07CODEMP,string @co07descripcion, string @AsientoTipoCod, string @NOMENCLATURA, out int @flag, out string @Msg);
       

        //NUEVO 
        [SprocName("Spu_Com_Del_co07MotivosDocPorPagar")]
        public abstract string Spu_Com_Del_co07MotivosDocPorPagar(string @CO07CODEMP, string @co07descripcion, int @CO07ITEM, out int @flag, out string @Msg);

        [SprocName("Spu_Com_Trae_ValidaProvSunat")]
        public abstract void Spu_Com_Trae_ValidaProvSunat(string @ccm02emp, string @flag_tipo_actualizacion, 
                                                string @ccm02tipana, string @ccm02cod, out string @msgretorno);



        [SprocName("Spu_Com_Del_ProvisionFactura")]
        public abstract void Spu_Com_Del_ProvisionFactura(string @cCodemp, string @cAno, string @cMes, string @cTipoOrd, 
        string @cCodigoOrd, string @cTipDoc, string @cNroDoc, string @CO05ANOORDCOM, string @CO05MESORDCOM, string @ctacte,
        out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_Voucher")]
        public abstract void Spu_Com_Del_Voucher(string @cEmpresa,string @cAno,string @cMes,
        string @cLibro,string @cVoucher,out int @flag,out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_Documento")]
        public abstract void Spu_Com_Del_Documento(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
        string @cNumDoc,string @cTranMov,string @dFechaDoc, string @nTipoCambio,string @cMoneda,
        out int @flag,out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_ControlOrdCompXOrdCom")]
        public abstract void Spu_Com_Trae_ControlOrdCompXOrdCom(string @co04codemp, string @co04aa, string @CO04MES,
        string @co04tipo,string @co04codigo);

        //[SprocName("Sp_Com_Control_OrdenCompra")]
        //public abstract void Sp_Com_Control_OrdenCompra(string @co04codemp, string @co04aa, string @co04tipo, 
        //string @co04codigo,string @Co04ARTICU,string @CO04CORREL);



    }
}
