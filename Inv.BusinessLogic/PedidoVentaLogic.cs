using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
using System.Transactions;

namespace Inv.BusinessLogic
{
    public class PedidoVentaLogic
    {
        #region Singleton
        private static volatile PedidoVentaLogic instance;
        private static object syncRoot = new Object();

        private PedidoVentaLogic() { }

        public static PedidoVentaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PedidoVentaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<PedidoVentaCabecera> PedVentaPend(string @come01empresa)
        {
            return Accessor.PedVentaPend(@come01empresa);
        }

        #region Accessor

        private static PedidoVentaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PedidoVentaAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
