using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class ActividadContableTipoLogic
    {
        #region Singleton
        private static volatile ActividadContableTipoLogic instance;
        private static object syncRoot = new Object();
        private ActividadContableTipoLogic(){ }
        public static ActividadContableTipoLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ActividadContableTipoLogic();
                    }
                }
                return instance;
            }
        }
        #endregion

        public List<ActividadContableTipo> TraerTipoActividadContable()
        {
            return Accessor.TraerTipoActividadContable();
        }


        #region Accessor
        private static ActividadContableTipoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ActividadContableTipoAccesor.CreateInstance(); }
        }
        #endregion
    }
}
