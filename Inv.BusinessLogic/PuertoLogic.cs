using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class PuertoLogic
    {
        #region Singleton
        private static volatile PuertoLogic instance;
        private static object syncRoot = new Object();
        private PuertoLogic() { }
        public static PuertoLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PuertoLogic();
                    }
                }
                return instance;
            }
        }
        #endregion

        public List<Puertos> Spu_Fact_Trae_FAC52PUERTOS(string @campo, string @filtro)
        {
            return Accessor.Spu_Fact_Trae_FAC52PUERTOS(@campo, @filtro);
        }


        public void Spu_Fact_Ins_FAC52PUERTOS(string @FAC52CODPUERTO, string @FAC52DESCRIPCION,
                out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_FAC52PUERTOS(@FAC52CODPUERTO, @FAC52DESCRIPCION,
                out @flag, out @msgretorno);
        }


        public void Spu_Fact_Upd_FAC52PUERTOS(string @FAC52CODPUERTO, string @FAC52DESCRIPCION, 
            out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_FAC52PUERTOS(@FAC52CODPUERTO, @FAC52DESCRIPCION,  out @flag, out @msgretorno);
        }
        
        
        public void Spu_Fact_Del_FAC52PUERTOS(string @FAC52CODPUERTO, out int @flag ,out string @msgretorno )
        {
            Accessor.Spu_Fact_Del_FAC52PUERTOS(@FAC52CODPUERTO, out @flag, out @msgretorno);
        }
        
        public void Spu_Fact_Trae_CodigoFAC52PUERTOS(out string @cCodigoNuevo)
        {
            Accessor.Spu_Fact_Trae_CodigoFAC52PUERTOS(out @cCodigoNuevo);
        }
        #region Accessor
        private static PuertoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PuertoAccesor.CreateInstance(); } 
        }
        #endregion
    }
}
