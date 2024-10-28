using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class RetencionLogic
    {
        #region Singleton
        private static volatile RetencionLogic instance;
        private static object syncRoot = new Object();
        private RetencionLogic() { }
        public static RetencionLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RetencionLogic();
                    }
                }
                return instance;
            }
        }
        #endregion

        public List<RetencionCab> TraerRetencion(string Ban01Empresa, string Ban01Anio, string Ban01Mes)
        {
            return Accessor.TraerRetencion(Ban01Empresa, Ban01Anio, Ban01Mes);
        }
        public DataTable Traer_RegistroRetenciones(string @Ban01Empresa, string @Ban01Anio, string @Ban01Mes) 
        {
            return Accessor.Traer_RegistroRetenciones(@Ban01Empresa, @Ban01Anio, @Ban01Mes);
        }
        public DataTable TraerRetencionReporte(string Ban01Empresa, string Ban01Numero)
        {
            return Accessor.TraerRetencionReporte(Ban01Empresa, Ban01Numero);
        }
        public List<Spu_Com_Trae_RetencionDet> TraerRetencionDet(string Ban01Empresa, string Ban01Numero)
        {
            return Accessor.TraerRetencionDet(Ban01Empresa, Ban01Numero);
        }
        public void InsertarRetencion(string Ban01Empresa, string Ban01Numero, string Ban01Anio,string Ban01Mes, string Ban01FechaEmi,string Ban01Proveedor,string Ban01Ruc, string Ban01TipoCambio,string Ban01Mon, string Ban01Porcentaje,string Ban01Usuario,out string MsgRetorno)
        {
            Accessor.InsertarRetencion(Ban01Empresa, Ban01Numero, Ban01Anio, Ban01Mes, Ban01FechaEmi, Ban01Proveedor, Ban01Ruc, Ban01TipoCambio, Ban01Mon, Ban01Porcentaje, Ban01Usuario, out MsgRetorno);
        }

        public void InsertarRetencionDet(string @Ban01Empresa, string @Ban01Numero, string @Ban01Ruc, string @Ban01Tipo, string @Ban01NroDoc, string @Ban01Codigo, string @Ban01Id, string @Ban01Nro, decimal @Ban01Pago, decimal @Ban01Retenido, decimal @Ban01PagoDolares, decimal @Ban01RetenidoDolares, out string @cMsgRetorno) 
        {
            Accessor.InsertarRetencionDet(Ban01Empresa, Ban01Numero, Ban01Ruc, Ban01Tipo, Ban01NroDoc, Ban01Codigo, Ban01Id, Ban01Nro, @Ban01Pago, Ban01Retenido, Ban01PagoDolares, Ban01RetenidoDolares, out cMsgRetorno);
        }

        public string TraerRetencionNro(string @Ban01Empresa, string @serie, out string @RetencionNro)
        {
          return Accessor.TraerRetencionNro(Ban01Empresa, serie,out RetencionNro);
        }

        public List<Proveedor> TraerRetencionNro(string @cCodEmp, string @cTipAna,string @cCampo, string @cFiltro)
        {
            return Accessor.Traer_HelpProveedor(cCodEmp, cTipAna, cCampo, cFiltro);
        }
        public List<DocumentoXProveedor> TraerDocumentoXProveedor(string CO05CODEMP, string CO05CODCTE, string campo, string filtro)
        {
            return Accessor.TraerDocumentoXProveedor(CO05CODEMP, CO05CODCTE, campo, filtro);
        }
        public string Eliminar_RetencionDet(string Ban01Empresa, string Ban01Numero, string Ban01Ruc, string Ban01Tipo, string Ban01NroDoc, string Ban01Codigo, out string cMsgRetorno)
        {
          return  Accessor.Eliminar_RetencionDet(Ban01Empresa, Ban01Numero, Ban01Ruc, Ban01Tipo, Ban01NroDoc, Ban01Codigo, out cMsgRetorno);
        }

        public void Eliminar_Retencion(string Ban01Empresa, string Ban01Numero, out string cMsgRetorno)
        {
            Accessor.Eliminar_Retencion(Ban01Empresa,  Ban01Numero,out cMsgRetorno);
        }

        public string Actualizar_Retencion(string Ban01Empresa, string Ban01Numero, string Ban01Anio, string Ban01Mes, string Ban01FechaEmi, string Ban01Proveedor, string Ban01Ruc, decimal Ban01TipoCambio, string Ban01Mon, int Ban01Porcentaje, string Ban01Usuario, out string cMsgRetorno)
        {
          return Accessor.Actualizar_Retencion(Ban01Empresa,Ban01Numero,Ban01Anio,Ban01Mes, Ban01FechaEmi, Ban01Proveedor, Ban01Ruc,  Ban01TipoCambio,  Ban01Mon,  Ban01Porcentaje, Ban01Usuario, out cMsgRetorno);
        }
        public string Actualizar_RetencionDet(string Ban01Empresa, string Ban01Numero, string Ban01Ruc, string Ban01Tipo, string Ban01NroDoc, string Ban01Codigo, string Ban01Id, string Ban01Nro, decimal Ban01Pago, decimal Ban01Retenido, decimal Ban01PagoDolares, decimal Ban01RetenidoDolares, out string cMsgRetorno) 
        {
            return Accessor.Actualizar_RetencionDet(Ban01Empresa, Ban01Numero, Ban01Ruc, Ban01Tipo, Ban01NroDoc, Ban01Codigo, Ban01Id, Ban01Nro, Ban01Pago, Ban01Retenido, Ban01PagoDolares, Ban01RetenidoDolares, out cMsgRetorno);
        }
        public string Generar_Voucher(string @Ban01Empresa, string @Anio, string @Mes, string @XMLrango, out string @msgretorno)
        {
            return Accessor.Generar_Voucher(Ban01Empresa, Anio, Mes, XMLrango, out msgretorno);
        }
        public string Insertar_Reversion(string @Ban01Empresa, string @Ban01Numero, string @FechaReversion, string @motivoReversion, out string @msgretorno, out int @flag)
        {
            return Accessor.Insertar_Reversion(@Ban01Empresa, @Ban01Numero, @FechaReversion, @motivoReversion, out @msgretorno, out @flag);
        }
        public string Insertar_RetencionElectronica(string @Ban01Empresa, string @Ban01Numero, out string @msgretorno)
        {
            return Accessor.Insertar_RetencionElectronica(@Ban01Empresa, @Ban01Numero, out @msgretorno);
        }
        public string Trae_RetencionElectronicaOnline(string @empresa, string @tipoDocumentoEmisor, string @numeroDocumentoEmisor, string @tipoDocumento, string @serieNumero, out string @linkRetencionElectronica)
        {
            return Accessor.Trae_RetencionElectronicaOnline(@empresa, @tipoDocumentoEmisor, @numeroDocumentoEmisor, @tipoDocumento, @serieNumero, out @linkRetencionElectronica);
        }
        #region Accessor
        private static RetencionAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return RetencionAccesor.CreateInstance(); }
        }
        #endregion
    }
}
