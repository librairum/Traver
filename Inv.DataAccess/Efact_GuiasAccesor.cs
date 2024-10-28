using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using System.Data;

namespace Inv.DataAccess
{
    public abstract class Efact_GuiasAccesor : AccessorBase<Efact_GuiasAccesor>
    {
        [SprocName("Spu_Fac_Ins_EfactResponse")]
        public abstract string Insertar_EfactResponse(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento,
            string @serieNumero, string code, string description, string @bl_mensajeSunat,string @bl_xml_rsp, string Metodo,string Estado_SUNAT, out int @flag, out string @Mensaje);

        [SprocName("Spu_Fact_GenerarJSonGuiaElectronica")]
        public abstract DataTable Spu_Fact_GenerarJSonGuiaElectronica(string FAC35CODEMP, string XMLRango);
        //EFACT
        [SprocName("Spu_Fac_Ins_EfactError")]
        public abstract string Insertar_EfactErrorLog(string @NUMERODOCUMENTOEMISOR, string @SERIENUMERO, string @TIPODOCUMENTO,
            string @TIPODOCUMENTOEMISOR, string @CODIGOERROR, string @DESCRIPCIONERROR, string @FECHAREGISTRO, string @Metodo, out int @flag, out string @Mensaje);

        [SprocName("Spu_Fac_Trae_EfactResponse")]
        public abstract DataTable Spu_Fac_Trae_EfactResponse(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero);

        [SprocName("Spu_Fac_EFACT_RESPONSE_LOG")]
        public abstract DataTable Spu_Fac_EFACT_RESPONSE_LOG(string serieNumero, string @numeroDocumentoEmisor, string @tipoDocumento);

        [SprocName("Spu_Fact_EFACT_SERVICIOSAPI")]
        public abstract DataTable Spu_Fact_EFACT_SERVICIOSAPI(string @Codigo);
        //END EFACT
        [SprocName("Spu_Fac_Traer_EfactResponseStatus")]
        public abstract string Spu_Fac_Trae_EfactResponseStatus(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero, int flag, out string Mensaje);

        [SprocName("Spu_Fact_EFAC_ERROR_LOG")]
        public abstract DataTable Spu_Fact_EFAC_ERROR_LOG(string @numeroDocumentoEmisor, string @serienumero, string @TipoDocumento);

        [SprocName("Spu_Fact_Trae_GuiasEnProceso")]
        public abstract DataTable Spu_Fact_Trae_GuiasEnProceso(string @FAC34CODEMP, string @FAC34AA, string @FAC34MM);
        [SprocName("Spu_Fac_Trae_EfactResponseXML")]
        public abstract DataTable Spu_Fac_Trae_EfactResponseXML(string @bl_xml_rsp);

        [SprocName("Spu_Fact_Upd_GuiaRemisionPesoBruto")]
        public abstract string Spu_Fact_Upd_GuiaRemisionPesoBruto(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, string @FAC34PESOUNIMED, decimal @FAC34PESOCANTIDAD, out int @flag, out string @msj);

        [SprocName("Spu_Fact_Trae_GuiaRemisionPesoBruto")]
        public abstract DataTable Spu_Fact_Trae_GuiaRemisionPesoBruto(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, out string @FAC34PESOUNIMED, out decimal @FAC34PESOCANTIDAD);

        [SprocName("Spu_Fact_Validar_GUIAEFACT_RESPONSE")]
        public abstract DataTable Spu_Fact_Validar_GUIAEFACT_RESPONSE(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero);

    }
}
