using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class Efact_GuiaLogic
    {
        #region Singleton
        private static volatile Efact_GuiaLogic instance;
        private static object syncRoot = new Object();

        private Efact_GuiaLogic() { }

        public static Efact_GuiaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Efact_GuiaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public DataTable Traer_GuiaElectronica(string CodEmp, string XMLRango)
        {
            return Accessor.Spu_Fact_GenerarJSonGuiaElectronica(CodEmp, XMLRango);
        }
        public DataTable Spu_Fact_EFAC_ERROR_LOG(string @numeroDocumentoEmisor, string @serienumero, string @TipoDocumento) 
        {
            return Accessor.Spu_Fact_EFAC_ERROR_LOG(@numeroDocumentoEmisor, @serienumero, @TipoDocumento);
        }
        public DataTable Traer_EstadoProceso(string @FAC34CODEMP, string @FAC34AA, string @FAC34MM) 
        {
            return Accessor.Spu_Fact_Trae_GuiasEnProceso(@FAC34CODEMP, @FAC34AA, @FAC34MM);
        }
        public string Insertar_EfactResponse(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento,
            string @serieNumero, string code, string description, string @bl_mensajeSunat, string @bl_xml_rsp, string Metodo, string Estado_SUNAT, out int @flag, out string @Mensaje)
        {
            return Accessor.Insertar_EfactResponse(@tipoDocumentoEmisor, @numeroDocumentoEmisor, @tipoDocumento,
             @serieNumero, code, description, @bl_mensajeSunat, @bl_xml_rsp, Metodo, Estado_SUNAT, out @flag, out @Mensaje);
        }
        public string Insertar_EfactErrorLog(string @NUMERODOCUMENTOEMISOR, string @SERIENUMERO, string @TIPODOCUMENTO,
            string @TIPODOCUMENTOEMISOR, string @CODIGOERROR, string @DESCRIPCIONERROR, string @FECHAREGISTRO, string @Metodo, out int @flag, out string @Mensaje)
        {
            return Accessor.Insertar_EfactErrorLog(@NUMERODOCUMENTOEMISOR, @SERIENUMERO, @TIPODOCUMENTO,
             @TIPODOCUMENTOEMISOR, @CODIGOERROR, @DESCRIPCIONERROR, @FECHAREGISTRO, @Metodo, out @flag, out @Mensaje);
        }
        public DataTable Traer_EFACTRESPONSE(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero)
        {
            return Accessor.Spu_Fac_Trae_EfactResponse(@tipoDocumentoEmisor, @numeroDocumentoEmisor, @tipoDocumento, @serieNumero);
        }
        public DataTable Traer_EFACT_SERVICIOSAPI(string Codigo) 
        {
            return Accessor.Spu_Fact_EFACT_SERVICIOSAPI(Codigo);
        }
        public DataTable Spu_Fac_EFACT_RESPONSE_LOG(string serieNumero, string @numeroDocumentoEmisor, string @tipoDocumento) 
        {
            return Accessor.Spu_Fac_EFACT_RESPONSE_LOG(serieNumero, @numeroDocumentoEmisor, @tipoDocumento);
        }

        public string Spu_Fac_Trae_EfactResponseStatus(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero, int flag, out string Mensaje)
        {
            return Accessor.Spu_Fac_Trae_EfactResponseStatus(@tipoDocumentoEmisor, @numeroDocumentoEmisor, @tipoDocumento, @serieNumero, flag, out Mensaje);
        }
        //PRUEBA DAEMON
        public DataTable Spu_Fac_Trae_EfactResponseXML(string @bl_xml_rsp)
        {
            return Accessor.Spu_Fac_Trae_EfactResponseXML(@bl_xml_rsp);
        }
        public string Spu_Fact_Upd_GuiaRemisionPesoBruto(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, string @FAC34PESOUNIMED, decimal @FAC34PESOCANTIDAD, out int @flag, out string @msj) 
        {
            return Accessor.Spu_Fact_Upd_GuiaRemisionPesoBruto( @FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, @FAC34PESOUNIMED, @FAC34PESOCANTIDAD, out @flag, out @msj);
        }
        public DataTable Spu_Fact_Trae_GuiaRemisionPesoBruto(string @FAC34CODEMP, string @FAC01COD, string @FAC34NROGUIA, out string @FAC34PESOUNIMED, out decimal @FAC34PESOCANTIDAD) 
        {
            return Accessor.Spu_Fact_Trae_GuiaRemisionPesoBruto(@FAC34CODEMP, @FAC01COD, @FAC34NROGUIA, out @FAC34PESOUNIMED, out @FAC34PESOCANTIDAD);
        }
        public DataTable Spu_Fact_Validar_GUIAEFACT_RESPONSE(string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero) 
        {
            return Accessor.Spu_Fact_Validar_GUIAEFACT_RESPONSE(@tipoDocumentoEmisor, @numeroDocumentoEmisor, @tipoDocumento, @serieNumero);
        }
        #region Accessor

        private static Efact_GuiasAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return Efact_GuiasAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
