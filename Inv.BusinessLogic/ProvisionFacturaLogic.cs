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
    public class ProvisionFacturaLogic
    {
        #region Singleton
        private static volatile ProvisionFacturaLogic instance;
        private static object syncRoot = new Object();

        private ProvisionFacturaLogic() { }

        public static ProvisionFacturaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ProvisionFacturaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public void Insertar(ProvisionFactura entidad , out int @flag, out string @cMsgRetorno)
        { 
            Accessor.Spu_Com_Ins_ProvisionFactura(entidad.Empresa, entidad.Anio, entidad.Mes, entidad.Tipo, entidad.Codigo, 
            entidad.TipoDocumento, entidad.NroDoc,  string.Format("{0:yyyyMMdd}",entidad.FechaDocumento), 
            string.Format("{0:yyyyMMdd}",entidad.FechaVencimiento), string.Format("{0:yyyyMMdd}",entidad.FechaPago),
            entidad.PorIgv, 

            entidad.ImporteAfecto, 
            entidad.ImporteInafecto, 
            entidad.ImporteIgv, 
            entidad.Importe, 

            entidad.ImporteAfDol, 
            entidad.ImporteInafDol, 
            entidad.ImporteIgvDol, 
            entidad.ImporteDocDol, 

            entidad.Moneda, 
            entidad.libro, entidad.NumeroVoucher, entidad.AsientoTipo,  entidad.TipDocGuia, 
            entidad.TipTransGuia, entidad.NroGuia, 
            entidad.FechaGuia, entidad.TipoCambio, entidad.Concepto,  entidad.CodCte,
            entidad.AnioOrdCom, 
            entidad.MesOrdCom, 

            entidad.AfectoDetraccion,  entidad.AfectoRet, entidad.NroAutorizacion, 
            entidad.DetraTipoOperacion, entidad.DetraTipoServicio, 
            entidad.DetraPorcentaje, entidad.DetraImporte, entidad.DetraImporte_Equiv, 
            entidad.BienesoServicioSunat,  
            entidad.NroDocRef, entidad.CentroCosto,
            entidad.DocModTipo, entidad.DocModNumero, string.Format("{0:yyyyMMdd}", entidad.DocModFecha), 
            out @flag, out @cMsgRetorno);
        }
        public string Actualizar_DocumentosContabilizados(string @cCodEmp, string @cAno, string @cMes, string @cTipoOrd, string @cNroOrd, string @TipoDocumento, string @Nrodocumento, string @Proveedor, string @CO05ANOORDCOM, string @CO05MESORDCOM, string @Libro, string @NumVou, string @AsientoTipo, out string @cMsgRetorno)
        {
            return Accessor.Sp_Com_Upd_ProvisionFactura_AsienCont(@cCodEmp, @cAno, @cMes, @cTipoOrd, @cNroOrd, @TipoDocumento, @Nrodocumento, @Proveedor, @CO05ANOORDCOM, @CO05MESORDCOM, @Libro, @NumVou, @AsientoTipo, out @cMsgRetorno);
        }
        public void Actualizar(ProvisionFactura entidad, out int @flag, out string @cMsgRetorno)
        {
            Accessor.Spu_Com_Upd_ProvisionFactura(entidad.Empresa, entidad.Anio, entidad.Mes,
            entidad.Tipo, entidad.Codigo, entidad.TipoDocumento, entidad.NroDoc, string.Format("{0:yyyyMMdd}", entidad.FechaDocumento),
            string.Format("{0:yyyyMMdd}", entidad.FechaVencimiento), string.Format("{0:yyyyMMdd}", entidad.FechaPago),
            entidad.PorIgv,entidad.ImporteAfecto, entidad.ImporteInafecto, entidad.ImporteIgv, entidad.Importe,


            entidad.ImporteAfDol, entidad.ImporteInafDol, entidad.ImporteIgvDol, entidad.ImporteDocDol, 

            entidad.Moneda, 
            entidad.libro, entidad.NumeroVoucher, entidad.AsientoTipo, entidad.TipDocGuia, 
            entidad.TipTransGuia, entidad.NroGuia, 
            entidad.FechaGuia,  entidad.TipoCambio, entidad.Concepto, entidad.CodCte,                                    


            entidad.AnioOrdCom,
            entidad.MesOrdCom,

           entidad.AfectoDetraccion, entidad.AfectoRet, entidad.NroAutorizacion,
            entidad.DetraTipoOperacion, entidad.DetraTipoServicio,
            entidad.DetraPorcentaje, entidad.DetraImporte, entidad.DetraImporte_Equiv,

            entidad.BienesoServicioSunat,  
            entidad.NroDocRef, entidad.CentroCosto,
            entidad.DocModTipo, entidad.DocModNumero, string.Format("{0:yyyyMMdd}", entidad.DocModFecha),
            out @flag, out @cMsgRetorno);

            //Falta anio ordencompra, mes orden compra
            //Afecto Detraccion
        }
        public DataTable TraerConcepto_Spu_Com_Trae_Concepto_co07MotivosDocPorPagar(string @CO07CODEMP, string @CO07DESCRIPCION) 
        {
            return Accessor.Spu_Com_Trae_Concepto_co07MotivosDocPorPagar(@CO07CODEMP, @CO07DESCRIPCION);
        }

        public void ActualizaProvisionFacturaPago(string @cCodEmp,string @cAno,string @cMes,string @cTipoOrd,string @cNroOrd,
        string @TipoDocumento, string @Nrodocumento, double @ImporteDocumento, double @ImportePagos, string @CO05ANOORDCOM, string @CO05MESORDCOM,
        string @Proveedor, string @CO05AFECTODETRACCION, string @CO05DETRATIPOPERACION, string @CO05DETRATIPOSERVICIO, double @CO05DETRAPORCENTAJE,
        double @CO05DETRAIMPORTE, double @CO05DETRAIMPORTE_EQUI)
        { 
            
            Accessor.Spu_Com_Upd_ProvisionFacturaPagos(@cCodEmp,@cAno,@cMes,@cTipoOrd,@cNroOrd,
                @TipoDocumento,@Nrodocumento,@ImporteDocumento,@ImportePagos,@CO05ANOORDCOM,@CO05MESORDCOM,
                @Proveedor,@CO05AFECTODETRACCION,@CO05DETRATIPOPERACION, @CO05DETRATIPOSERVICIO, @CO05DETRAPORCENTAJE, 
                @CO05DETRAIMPORTE, @CO05DETRAIMPORTE_EQUI);
        }

        public List<Spu_Com_Trae_FlujoDePago> ComprasTraeFlujoPago(string @CO05CODEMP, string @CO05CODCTE,
        string @co05tipdoc, string @co05nrodoc)
        {
            return Accessor.Spu_Com_Trae_FlujoDePago(@CO05CODEMP, @CO05CODCTE, @co05tipdoc, @co05nrodoc);
        }
        public List<Libro> TraeAyudaLibroTodos(string @cEmpresa, string @cAnio, string @cCampo, string @cFiltro)
        {
            return Accessor.Spu_Com_Trae_ComAyudaLibroTodos(@cEmpresa, @cAnio, @cCampo, @cFiltro);
                
        }
        public void TraeRetencion(string @ccm02Emp, string @ccm02tipana, string @ccm02cod,
          string @facturafecha, double @facturavaloensoles, string @flagafectodetraccion,
          string @DocumentoTipoCodigo, out int @afecto)
        {
            Accessor.Spu_com_trae_retencion(@ccm02Emp, @ccm02tipana, @ccm02cod,
            @facturafecha, @facturavaloensoles, @flagafectodetraccion,
            @DocumentoTipoCodigo, out @afecto);
        }
        public void InsertarMovimiento(string @cCodEmp, string @cAnno, string @cMes, string @cTipoDocu,
        string @cDocumento, string @dFechaDoc, string @cCodTra, string @cTransac, string @cMoneda, double @nTipoCambio,
        string @cProveedor, string @cCliente, string @cCenCosto, string @cResponsable, string @cObra, string @cMaquinas,
        string @cOrdCom, string @cLotes, string @cPedidos, string @cAlmaEm, string @cAlmaRe, string @cDocuNumer,
        string @IN06ANOORDCOMP,string @IN06PRODNATURALEZA, out int @flag, out string @cMsgRetorno)
        {
            Accessor.Spu_Com_Ins_DoumentoMovimiento(@cCodEmp, @cAnno, @cMes, @cTipoDocu,
             @cDocumento, @dFechaDoc, @cCodTra, @cTransac, @cMoneda, @nTipoCambio,
             @cProveedor, @cCliente, @cCenCosto, @cResponsable, @cObra, @cMaquinas,
             @cOrdCom, @cLotes, @cPedidos, @cAlmaEm, @cAlmaRe, @cDocuNumer,
             @IN06ANOORDCOMP, @IN06PRODNATURALEZA, out @flag, out  @cMsgRetorno);
        }

        public void TraeCorrelativoVoucher(string @ccd01emp, string @ccd01ano, string @ccd01mes, string @ccd01subd,
        string @ccd01numer, out string @Newccd01numer)
        {
            Accessor.Spu_Com_Trae_CorrelativoVoucher(@ccd01emp, @ccd01ano, @ccd01mes, @ccd01subd, @ccd01numer, out @Newccd01numer);
        }

        public List<ProvisionamientoOrdenCompraDetalle> TraeDocumentosSinOC(string @cCodemp, string @cAno, string @cTipAna,
       string @cTipo, string @cCodigo, string @cFecIni, string @cFecFin,  string @cFiltro, 
            string @FacturaTipo, string @FacturaNro)
        {
            return Accessor.Spu_Com_Trae_ProvisionesSinOC(@cCodemp, @cAno, @cTipAna,
                     @cTipo, @cCodigo, @cFecIni, @cFecFin, @cFiltro, @FacturaTipo, 
                     @FacturaNro);
        }
        public List<ProvisionamientoOrdenCompraDetalle> TraeDocumentosSinOCPorPeriododeregistro(string @cCodemp, string @cAno, string @cMes, 
       string @cTipo, string @cTipAna)
        {
            return Accessor.Spu_Com_Trae_ProvisionesSinOCPorPeriodo(@cCodemp, @cAno, @cMes, @cTipo, @cTipAna);
        }
        //nuevo
        public DataTable TraeMotivosDocPorPagar(string @CO07CODEMP, string @Anio) 
        {
            return Accessor.Spu_Com_Trae_co07MotivosDocPorPagar(@CO07CODEMP, @Anio);
        }
        //NUEVO
        public DataTable Trae_Spu_Com_Trae_AsientoContable(string @CO05CODEMP, string @CO05AA, string @CO05MES, string @opcion, string @opcionFiltro, string @XmlFiltro)
        {
            return Accessor.Spu_Com_Trae_AsientoContable(@CO05CODEMP, @CO05AA, @CO05MES, @opcion,@opcionFiltro,@XmlFiltro);
        }
        public string Insertar_co07MotivosDocPorPagar(string @CO07CODEMP, string @co07descripcion, string @AsientoTipoCod, string @NOMENCLATURA, out int @flag, out string @Msg) 
        {
            return Accessor.Spu_Com_Ins_co07MotivosDocPorPagar(@CO07CODEMP, @co07descripcion, @AsientoTipoCod, @NOMENCLATURA, out @flag, out @Msg);
        }
        public string Actualizar_co07MotivosDocPorPagar(string @CO07CODEMP, string @co07descripcion, int @CO07ITEM, string @AsientoTipoCod, string @NOMENCLATURA, out int @flag, out string @Msg) 
        {
            return Accessor.Spu_Com_Upd_co07MotivosDocPorPagar(@CO07CODEMP, @co07descripcion, @CO07ITEM, @AsientoTipoCod, @NOMENCLATURA, out @flag, out @Msg);
        }

        public string Eliminar_co07MotivosDocPorPagar(string @CO07CODEMP, string @co07descripcion, int @CO07ITEM, out int @flag, out string @Msg)
        {
            return Accessor.Spu_Com_Del_co07MotivosDocPorPagar(@CO07CODEMP, @co07descripcion, @CO07ITEM, out @flag, out @Msg);
        }
        public DataTable AutoCompletaMotivoProvision(string @cCodEmp,string @filtro)
        {
            return Accessor.Spu_Com_Trae_AutoCompletarMotivoProvision(@cCodEmp, @filtro);
        }

        public void TraeValidaProvSunat(string @ccm02emp, string @flag_tipo_actualizacion, 
                                        string @ccm02tipana, string @ccm02cod, out string @msgretorno)
        {
            Accessor.Spu_Com_Trae_ValidaProvSunat(@ccm02emp, @flag_tipo_actualizacion, @ccm02tipana, @ccm02cod, out @msgretorno);
        }


        public void Eliminar(string @cCodemp, string @cAno, string @cMes, string @cTipoOrd,
        string @cCodigoOrd, string @cTipDoc, string @cNroDoc, string @CO05ANOORDCOM, string @CO05MESORDCOM, string @ctacte,
        out int @flag, out string @cMsgRetorno) { 

            Accessor.Spu_Com_Del_ProvisionFactura(@cCodemp, @cAno, @cMes, @cTipoOrd, @cCodigoOrd, @cTipDoc, 
                            @cNroDoc, @CO05ANOORDCOM, @CO05MESORDCOM, @ctacte, out @flag, out @cMsgRetorno);
        }


        public void EliminarDocumentoContabilidad(string @cEmpresa, string @cAno, string @cMes,
        string @cLibro, string @cVoucher, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.Spu_Com_Del_Voucher( @cEmpresa, @cAno, @cMes, @cLibro, @cVoucher,
                                        out  @flag,out  @cMsgRetorno);
        }


        public void EliminarDocumentoInventario(string @cCodEmp, string @cAnno, string @cMes, string @cTipDoc,
        string @cNumDoc, string @cTranMov, string @dFechaDoc, string @nTipoCambio, string @cMoneda,
        out int @flag, out string @cMsgRetorno)
        { 
             Accessor.Spu_Com_Del_Documento(@cCodEmp, @cAnno, @cMes, @cTipDoc, @cNumDoc, @cTranMov,
                                    @dFechaDoc, @nTipoCambio,@cMoneda, out @flag,out @cMsgRetorno);
        }


        public void TraeControlOrdCompXOrdCom(string @co04codemp, string @co04aa, string @CO04MES,
        string @co04tipo, string @co04codigo)
        { 
            Accessor.Spu_Com_Trae_ControlOrdCompXOrdCom(@co04codemp, @co04aa, @CO04MES,
                                @co04tipo, @co04codigo);
        }

        

        #region Accessor

        private static ProvisionFacturaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ProvisionFacturaAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
