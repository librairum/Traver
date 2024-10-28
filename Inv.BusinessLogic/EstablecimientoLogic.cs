using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class EstablecimientoLogic
    {
        #region Singleton
        private static volatile EstablecimientoLogic instance;
        private static object syncRoot = new Object();

        private EstablecimientoLogic() { }

        public static EstablecimientoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EstablecimientoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<Establecimiento> TraerEstablecimiento(string @CodigoEmpresa, string @Campo, string @Filtro)
        {
            return Accessor.TraerEstablecimiento(@CodigoEmpresa, @Campo, @Filtro);
        }

        #region Accessor

        private static EstablecimientoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return EstablecimientoAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
