using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ServicioDetraccionLogic
    {

        #region Singleton
        private static volatile ServicioDetraccionLogic instance;
        private static object syncRoot = new Object();
        private ServicioDetraccionLogic() { }
        public static ServicioDetraccionLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ServicioDetraccionLogic();
                    }
                }
                return instance;
            }
        }
    
        #endregion

        public List<ServicioDetraccion> TraeAyuda(string @cCampo, string @cFiltro, string @facturafecha)
        { 
            return Accessor.TraeAyuda(@cCampo, @cFiltro, @facturafecha);
        }

        #region Accessor
        private static ServicioDetraccionAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ServicioDetraccionAccesor.CreateInstance(); }
        }
        #endregion 

    }
}
