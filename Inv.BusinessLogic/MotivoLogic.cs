using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    
    public class MotivoLogic
    {
    #region "Singleton"
        private static volatile MotivoLogic instance;
        private static object syncRoot = new Object();
        private MotivoLogic() { }
        public static MotivoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) 
                    {
                        if (instance == null)
                            instance = new MotivoLogic();
                    }
                }
                return instance;
            }
        }
    #endregion
        public void Insertar(Motivo motivo, out int @flag, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.Spu_Pro_Ins_Motivo(motivo.PRO15CODEMP, motivo.PRO15CODIGO, motivo.PRO15DESCRIPCION, out  @flag, out  @cMsgRetorno);
        }

        public void Actualizar(Motivo motivo, out int @flag, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.Spu_Pro_Upd_Motivo(motivo.PRO15CODEMP, motivo.PRO15CODIGO, motivo.PRO15DESCRIPCION, out @flag, out @cMsgRetorno);
        }

        public void Eliminar(Motivo motivo, out int @flag, out string @cMsgRetorno)
        {
                @cMsgRetorno = string.Empty;
                Accessor.Spu_Pro_Del_Motivo(motivo.PRO15CODEMP, motivo.PRO15CODIGO, motivo.PRO15DESCRIPCION, out @flag, out @cMsgRetorno);
        }

        public List<Motivo> TraerLista(string @PRO15CODEMP)
        { 
            return Accessor.Spu_Prod_Traer_Motivo(@PRO15CODEMP, "", "*");
        }
        public List<Motivo> TraerRegistro(string @PRO15CODEMP, string @PRO15CODIGO)
        {
            return Accessor.Spu_Prod_Traer_Motivo(@PRO15CODEMP, @PRO15CODIGO, "PRO15CODIGO");
        }
        public void TraerNuevoCodigo(string @PRO15CODEMP, out string @PRO15CODIGO)
        { 
            Accessor.Spu_Pro_Traer_CodigoMotivo(@PRO15CODEMP, out @PRO15CODIGO);
        }

        public DataTable TraerReporteMotivosMerma(string @empresa, string @anio, string @linea, string @fechaini,
                                                 string @fechafin, string @flag, string @XMLrango) 
        {
            return Accessor.Spu_Pro_Rep_Motivos(@empresa, @anio, @linea, @fechaini,
                                                 @fechafin, @flag, @XMLrango) ;
        }
        #region Accessor
        private static MotivoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MotivoAccesor.CreateInstance(); }
        }
        #endregion Accessor
    }
}
