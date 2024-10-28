using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ObraLogic
    {
        #region Singleton
        private static volatile ObraLogic instance;
        private static object syncRoot = new Object();

        private ObraLogic() { }

        public static ObraLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ObraLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<Obra> TraerObra(string codigoEmpresa)
        {
            return Accesor.TraerObra(codigoEmpresa, "", "*");
        }

        #region Accessor

        private static ObraAccesor Accesor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ObraAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
