using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
   public class MotivoHoraMuertaLogic
   {
       #region Singleton
        private static volatile MotivoHoraMuertaLogic instance;
        private static object syncRoot = new Object();
        private MotivoHoraMuertaLogic() { }
        public static MotivoHoraMuertaLogic Instance 
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new MotivoHoraMuertaLogic();
                    }
                }
                return instance;
            }
        }
       #endregion
        
        public void InsertarMotivoHoraMuerta(MotivoHoraMuerta mhm, out string @msg, out int @flag)
        {
            Accessor.InsertarMotivoHoraMuerta(mhm.PRO01CODEMP, mhm.PRO01CODIGO, mhm.PRO01DESCRIPCION, out @msg, out @flag);
        }

        public void ActualizarMotivoHoraMuerta(MotivoHoraMuerta mhm, out string @msg, out  int @flag)
        {
            Accessor.ActualizarMotivoHoraMuerta(mhm.PRO01CODEMP, mhm.PRO01CODIGO, mhm.PRO01DESCRIPCION, out @msg, out  @flag);
        }

        public void EliminarMotivoHoraMuerta(MotivoHoraMuerta mhm, out string @msg, out int @flag)
        {
            Accessor.EliminarMotivoHoraMuerta(mhm.PRO01CODEMP, mhm.PRO01CODIGO, out @msg, out @flag);
        }

        public List<MotivoHoraMuerta> TraerMotivoHoraMuesta(MotivoHoraMuerta mhm, string @Tipo) 
        {
            return Accessor.TraerMotivoHoraMuesta(mhm.PRO01CODEMP, mhm.PRO01CODIGO, @Tipo);
        }
        public  void TraerCodigo(string @PRO01CODEMP, out string @nuevocodigo) {
            Accessor.TraerCodigo(@PRO01CODEMP, out @nuevocodigo);
        }

       #region Accessor
           private static MotivoHoraMuertaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MotivoHoraMuertaAccesor.CreateInstance(); }
        }
       #endregion
   }
}
