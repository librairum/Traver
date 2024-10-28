using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class EquiAlmacenGuiaLogic
    {
        #region Singleton
        private static volatile EquiAlmacenGuiaLogic instance;
        private static object syncRoot = new Object();

        private EquiAlmacenGuiaLogic() { }

        public static EquiAlmacenGuiaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EquiAlmacenGuiaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        
        public List<EquiAlmacenGuias> TraerEquiAlmVSGuias(string EquiAlmacenGuiaAccesor)
        {
            return Accessor.TraerEquiAlmVSGuias(EquiAlmacenGuiaAccesor);
        }
        public void EquiAlmGuiaInsertar(EquiAlmacenGuias Equialmguia, out int @flag, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.EquiAlmGuiaInsertar(Equialmguia.in20empresacod, Equialmguia.in20codtraalm, Equialmguia.in20codmotivoguia, out @flag, out @cMsgRetorno);
        }

        public void EquiAlmGuiaEliminar(EquiAlmacenGuias Equialmguia, out int @flag, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.EquiAlmGuiaEliminar(Equialmguia.in20empresacod, Equialmguia.in20codtraalm, Equialmguia.in20codmotivoguia, out @flag, out @cMsgRetorno);
        }
        


        #region Accessor

        private static EquiAlmacenGuiaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return EquiAlmacenGuiaAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
