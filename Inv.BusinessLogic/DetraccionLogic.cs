using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class DetraccionLogic
    {
        #region Singleton
        private static volatile DetraccionLogic instance;
        private static object syncRoot = new Object();
        private DetraccionLogic() { }
        public static DetraccionLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DetraccionLogic();
                    }
                }
                return instance;
            }
        }
        #endregion
        public DataTable TraerCabDetraccion(string @empresa, string @Anio ,string @Mes) 
        {
            return Accessor.TraerCabDetraccion(@empresa,@Anio,@Mes);
        }
        public DataTable TraerDetDetraccion(string @empresa, string @Anio, string @Mes,string @codigo) 
        {
            return Accessor.TraerDetDetraccion(@empresa,  @Anio,  @Mes, @codigo);
        }
        public List<Detraccion> TraerDetraccion(string CO26CODEMP, string CO26AA, string CO26MES)
        {
            return Accessor.TraeDetraccion(CO26CODEMP,CO26AA,CO26MES);
        }
        public DataTable TraerDetraccionDet(string @CO26CODEMP, string @CO26NUMLOTE)
        {
            return Accessor.TraeDetraccionDet(CO26CODEMP, CO26NUMLOTE);
        }
        public List<Detraccionxpagar> TraeDetraccionxpagar(string @CO05CODEMP, string @CO05FECHAINI, string @CO05FECHAFIN)
        {
            return Accessor.TraeDetraccionxpagar(@CO05CODEMP, @CO05FECHAINI, @CO05FECHAFIN);
        }
        public string Trae_LoteDetraccion(string CO26CODEMP, string CO26AA, out string CO26MES)
        {
            return Accessor.Trae_LoteDetraccion(CO26CODEMP, CO26AA, out CO26MES);
        }
        public string Actualizar_DetraccionDet(string @CO26CODEMP, string @CO26NUMLOTE, string @CO26CONST_CONSDETRA, string @CO26CONST_NUMOPERACION,string @CO26CONST_FECHA,out string @msgretorno)
        {
            return Accessor.Actualizar_DetraccionDet(@CO26CODEMP, @CO26NUMLOTE, @CO26CONST_CONSDETRA, @CO26CONST_NUMOPERACION, @CO26CONST_FECHA, out @msgretorno);
        }
        public string Insertar_DetraccionDet(string @CO26CODEMP, string @CO26AA, string @CO26MES, string @CO26NUMLOTE, string @CO26FECHA, string @CO26RANFECINI, string @CO26RANFECFIN, string @CO26NUMPROFORMA,string @CO26RUC,string @CO26TIPDOC,string @CO26NRODOC, string xml, string CO26periodotributario, out string @msgretorno)
        {
            return Accessor.InsertarDetraccionDet(CO26CODEMP, CO26AA, CO26MES, CO26NUMLOTE, CO26FECHA, CO26RANFECINI, CO26RANFECFIN, CO26NUMPROFORMA, CO26RUC, CO26TIPDOC, CO26NRODOC, xml, CO26periodotributario, out msgretorno);
        }
        public string Insertar_DetraccionImportetxt(string @empresa,string @codigo, string @XMLrango, out string mensaje, out int flag)
        {
            return Accessor.InsertarImporteTXT(@empresa, @codigo, @XMLrango, out mensaje, out flag);
        }
        public string Eliminar_Detraccion(string CO26CODEMP, string CO26NUMLOTE, out string msgretorno)
        {
            return Accessor.Eliminar_Detraccion(CO26CODEMP, CO26NUMLOTE, out msgretorno);
        }
        public DataTable ExportarDetraccionTXT(string CO26CODEMP, string CO26NUMLOTE) 
        {
            return Accessor.ExportarDetraccionTXT(CO26CODEMP, CO26NUMLOTE);
        }
        public List<DetraccionImportar> TraerPagoDetraccion(string @empresa,string @Anio,string @Mes, string @codigo, out string @msgretorno, out int @flag)
        {
            return Accessor.TraerPagoDetraccion(empresa, @Anio, @Mes, codigo, out @msgretorno, out @flag);
        }
        
        #region Accessor
        private static DetraccionAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DetraccionAccesor.CreateInstance(); }
        }
        #endregion
    }
}
