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
    public abstract class DetraccionAccesor : AccessorBase<DetraccionAccesor>
    {
        //Traer Retenciones
        [SprocName("Spu_Com_Trae_CO26PAGODETRACCION")]
        public abstract List<Detraccion> TraeDetraccion(string @CO26CODEMP, string @CO26AA, string @CO26MES);
        //Detalle
     
     

        #region DetraccionDetalle
        [SprocName("Spu_Com_Trae_CO26PAGODETRACCIONDet")]
        public abstract DataTable TraeDetraccionDet(string @CO26CODEMP, string @CO26NUMLOTE);
        [SprocName("Spu_Com_Ins_CO26PAGODETRACCION")]
        
        public abstract string InsertarDetraccionDet(string @CO26CODEMP, string @CO26AA, string @CO26MES, string @CO26NUMLOTE, string @CO26FECHA, string @CO26RANFECINI, string @CO26RANFECFIN, string @CO26NUMPROFORMA,string @CO26RUC,string @CO26TIPDOC,string CO26NRODOC,string @xml ,string @CO26periodotributario, out string @msgretorno);

        [SprocName("Spu_Com_Trae_LoteDetraccion")]
        public abstract string Trae_LoteDetraccion(string @CO26CODEMP, string @CO26AA, out string @Numero);

        [SprocName("Spu_Com_Upd_CO26PAGODETRACCION")]
        public abstract string Actualizar_DetraccionDet(string @CO26CODEMP, string @CO26NUMLOTE, string @CO26CONST_CONSDETRA, string @CO26CONST_NUMOPERACION, string @CO26CONST_FECHA, out string @msgretorno);

        [SprocName("Spu_Com_Del_CO26PAGODETRACCION")]
        public abstract string Eliminar_Detraccion(string @CO26CODEMP, string @CO26NUMLOTE, out string @msgretorno);
        

        [SprocName("Spu_Com_Trae_Detracciones")]
        public abstract List<Detraccionxpagar> TraeDetraccionxpagar(string @CO05CODEMP, string @CO05FECHAINI, string @CO05FECHAFIN);

        [SprocName("Spu_Com_Trae_ExportaDetraccion")]
        public abstract DataTable ExportarDetraccionTXT(string @CO26CODEMP, string @CO26NUMLOTE);

        [SprocName("Spu_com_ins_co01compdetraSunat")]
        public abstract string InsertarImporteTXT(string @empresa,string codigo , string @XMLrango, out string @msgretorno, out int flag); 
        
       [SprocName("Spu_com_upd_pagodetraccion")]
        public abstract List<DetraccionImportar> TraerPagoDetraccion(string @empresa,string @Anio,string @Mes, string @codigo, out string @msgretorno, out int @flag);



       [SprocName("Spu_Com_Trae_Detracciones_Cab")]
       public abstract DataTable TraerCabDetraccion(string @empresa, string @Anio,string @Mes);

        [SprocName("Spu_Com_Trae_Detracciones_Det")]
       public abstract DataTable TraerDetDetraccion(string @empresa, string @Anio, string @Mes,string @codigo);

        #endregion
    }

}
