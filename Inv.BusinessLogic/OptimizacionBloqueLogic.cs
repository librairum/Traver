using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
namespace Inv.BusinessLogic
{
    public class OptimizacionBloqueLogic
    {
          #region Singleton
        private static volatile OptimizacionBloqueLogic instance;
        private static object syncRoot = new Object();

        private OptimizacionBloqueLogic() { }

        public static OptimizacionBloqueLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new OptimizacionBloqueLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<Spu_Pro_Trae_FormaOptimaCortarBloque> FormaOptimaCortarBloqueTraer(string @empresa, Double @ProductoAncho, Double @ProductoLargo, Double @ProductoEspesor) 
        {
            return Accessor.Spu_Pro_Trae_FormaOptimaCortarBloque(@empresa,@ProductoAncho, @ProductoLargo,@ProductoEspesor);
        }

       //public LineaAyuda
        #region Accessor

        private static OptimizacionBloqueAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return OptimizacionBloqueAccesor.CreateInstance(); }
        }
        #endregion Accessor
    }
}
