using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class InventarioOrdenCompraLogic
    {
        #region Singleton
        private static volatile InventarioOrdenCompraLogic instance;
        private static object syncRoot = new Object();

        private InventarioOrdenCompraLogic() { }

        public static InventarioOrdenCompraLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new InventarioOrdenCompraLogic();
                    }
                }

                return instance;
            }
        }
        #endregion



        #region Accessor
        public List<DodcumentoOrdenCompra> TraeOrdenCompra(string @cCodEmp, string @cAno, string @cMes,
        string @cTipo, string @cTipAna, string @cCampo, string @cFiltro)
        { 
            return Accessor.TraeOrdenCompra( @cCodEmp,  @cAno,  @cMes,
                             @cTipo,  @cTipAna,  @cCampo,  @cFiltro);
        }
        private static InventarioOrdenCompraAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return InventarioOrdenCompraAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
