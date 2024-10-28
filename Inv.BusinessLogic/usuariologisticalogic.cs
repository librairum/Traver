using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class usuariologisticalogic
    {
        #region Singleton
        private static volatile usuariologisticalogic instance;
        private static object syncRoot = new Object();
        private usuariologisticalogic() { }
        public static usuariologisticalogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new usuariologisticalogic();
                    }
                }
                return instance;
            }
        }
        #endregion

        public List<UsuarioLogistica> TraeAyudausuariologistica(string cCodemp)
        {
            return Accessor.TraeAyudausuariologistica(cCodemp);
        }


        #region Accessor
        private static usuariologisticaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return usuariologisticaAccesor.CreateInstance(); }
        }
        #endregion
    }
}
