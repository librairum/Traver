using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
  public  class NaturalezaLogic
    {
       #region Singleton
      private static volatile NaturalezaLogic instance;
        private static object syncRoot = new Object();

        private NaturalezaLogic() { }

        public static NaturalezaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new NaturalezaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
     
      public List<Naturaleza> TraerNaturaleza(string @cFiltro) 
      {
          return Accessor.TraerNaturaleza(@cFiltro);
      }

        #region Accessor
      private static NaturalezaAccesor Accessor
      {
          [System.Diagnostics.DebuggerStepThrough]
          get { return NaturalezaAccesor.CreateInstance(); }
      }

        #endregion

    }
}
