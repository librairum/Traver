using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{

    public class Compra_Traer_TipoCambioLogic
    {

             #region Singleton
        private static volatile Compra_Traer_TipoCambioLogic instance;
        private static object syncRoot = new Object();

        private Compra_Traer_TipoCambioLogic() { }

        public static Compra_Traer_TipoCambioLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Compra_Traer_TipoCambioLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public void TipoCambioTraer(string @fecha, out double @nTipCam)
        {
            Accessor.Spu_Comp_Trae_TipoCambio(@fecha, out @nTipCam);

        }
        #region Accessor

        private static Compras_TraerTipoCambioAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return Compras_TraerTipoCambioAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }

}
