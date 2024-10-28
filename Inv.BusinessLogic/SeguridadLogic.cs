using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Seg.BusinessLogic
{
   public  class SeguridadLogic
    {
         #region Singleton
       private static volatile SeguridadLogic instance;
        private static object syncRoot = new Object();

        private SeguridadLogic() { }

        public static AlmacenLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SeguridadLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


    }
}
