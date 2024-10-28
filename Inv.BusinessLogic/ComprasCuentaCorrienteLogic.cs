using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
   public class ComprasCuentaCorrienteLogic
    {
       #region Singleton
        private static volatile ComprasCuentaCorrienteLogic instance;
        private static object syncRoot = new Object();

        private ComprasCuentaCorrienteLogic() { }

        public static ComprasCuentaCorrienteLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ComprasCuentaCorrienteLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<CuentaCorriente> Traer(string @cCodEmp, string @cTipAnal, string @cTipoFiltro, string @cFiltro)
        {
            return Accessor.Spu_Com_Trae_CuentaCorriente(@cCodEmp, @cTipAnal, @cTipoFiltro, @cFiltro);
        }


        #region Accessor

        private static ComprasCuentaCorrienteAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ComprasCuentaCorrienteAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
