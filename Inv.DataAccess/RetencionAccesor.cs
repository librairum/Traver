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
    public abstract class RetencionAccesor : AccessorBase<RetencionAccesor>
    {
        [SprocName("Spu_Com_Rep_RegistroRetenciones")]
        public abstract DataTable Traer_RegistroRetenciones(string @Ban01Empresa, string @Ban01Anio,string @Ban01Mes);
        //Traer Retenciones
        [SprocName("Spu_Com_Trae_Retenciones")]
        public abstract List<RetencionCab> TraerRetencion(string @Ban01Empresa, string @Ban01Anio, string @Ban01Mes);

        [SprocName("Spu_Com_Rep_RetencionComprobante")]
        public abstract DataTable TraerRetencionReporte(string @Ban01Empresa, string @Ban01Numero);

        [SprocName("Spu_Com_Trae_RetencionDet")]
        public abstract List<Spu_Com_Trae_RetencionDet> TraerRetencionDet(string @Ban01Empresa, string @Ban01Numero);

        [SprocName("Spu_Com_Ins_Retencion")]
        public abstract void InsertarRetencion(string @Ban01Empresa, string @Ban01Numero, string @Ban01Anio,string @Ban01Mes, string @Ban01FechaEmi,string @Ban01Proveedor,string @Ban01Ruc, string@Ban01TipoCambio,string @Ban01Mon, string @Ban01Porcentaje,string @Ban01Usuario,out string @cMsgRetorno);

        [SprocName("Spu_Com_Ins_RetencionDet")]
        public abstract void InsertarRetencionDet(string @Ban01Empresa, string @Ban01Numero, string @Ban01Ruc, string @Ban01Tipo, string @Ban01NroDoc, string @Ban01Codigo, string @Ban01Id, string @Ban01Nro, decimal @Ban01Pago, decimal @Ban01Retenido, decimal @Ban01PagoDolares, decimal @Ban01RetenidoDolares, out string @cMsgRetorno);

        [SprocName("Spu_Com_Trae_RetencionNro")]
        public abstract string TraerRetencionNro(string @Ban01Empresa, string @serie, out string @RetencionNro);

        [SprocName("sp_Com_Help_Proveedor")]
        public abstract List<Proveedor> Traer_HelpProveedor(string @cCodEmp, string @cTipAna, string @cCampo, string @cFiltro);

        [SprocName("Spu_Com_Trae_DocXProveedor")]
        public abstract List<DocumentoXProveedor> TraerDocumentoXProveedor(string @CO05CODEMP, string @CO05CODCTE, string @campo, string @filtro);

        [SprocName("Spu_Com_Del_RetencionDet")]
        public abstract string Eliminar_RetencionDet(string @Ban01Empresa, string @Ban01Numero, string @Ban01Ruc, string @Ban01Tipo, string @Ban01NroDoc, string @Ban01Codigo, out string @cMsgRetorno);

        [SprocName("Spu_Com_Del_Retencion")]
        public abstract void Eliminar_Retencion(string @Ban01Empresa, string @Ban01Numero, out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_Retencion")]
        public abstract string Actualizar_Retencion(string @Ban01Empresa, string @Ban01Numero, string @Ban01Anio, string @Ban01Mes, string @Ban01FechaEmi, string @Ban01Proveedor, string @Ban01Ruc, decimal @Ban01TipoCambio, string @Ban01Mon, int @Ban01Porcentaje, string @Ban01Usuario, out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_RetencionDet")]
        public abstract string Actualizar_RetencionDet(string @Ban01Empresa, string @Ban01Numero, string @Ban01Ruc, string @Ban01Tipo, string @Ban01NroDoc, string @Ban01Codigo, string @Ban01Id, string @Ban01Nro, decimal @Ban01Pago, decimal @Ban01Retenido, decimal @Ban01PagoDolares, decimal @Ban01RetenidoDolares, out string @cMsgRetorno);

        [SprocName("Spu_Com_Gen_VoucherRetencion")]
        public abstract string Generar_Voucher(string @Ban01Empresa, string @Anio, string @Mes, string @XMLrango, out string @msgretorno);

        [SprocName("Spu_Com_Ins_Reversion")]
        public abstract string Insertar_Reversion(string @Ban01Empresa, string @Ban01Numero, string @FechaReversion, string @motivoReversion, out string @msgretorno, out int @flag);

        [SprocName("Spu_Com_Ins_RetencionElectronica")]
        public abstract string Insertar_RetencionElectronica(string @Ban01Empresa, string @Ban01Numero, out string @msgretorno);

        [SprocName("Spu_Com_Trae_RetencionElectronicaOnline")]
        public abstract string Trae_RetencionElectronicaOnline(string @empresa, string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero, out string @linkRetencionElectronica);
    }

}
