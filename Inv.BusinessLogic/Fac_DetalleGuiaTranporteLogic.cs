using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
namespace Inv.BusinessLogic
{
  public  class Fac_DetalleGuiaTranporteLogic
    {
       #region Singleton
      private static volatile Fac_DetalleGuiaTranporteLogic instance;
        private static object syncRoot = new Object();

        private Fac_DetalleGuiaTranporteLogic() { }

        public static Fac_DetalleGuiaTranporteLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Fac_DetalleGuiaTranporteLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
      public List<DetalleGuiaTransporte> TraerGuiasTransporteDetalle(string codigoEmpresa, string codigoDocumento, string nroGuia)
      {
          return Accessor.Spu_Fact_Trae_FAC35_DETGUIAXGUIA(codigoEmpresa, codigoDocumento, nroGuia);
          
      }

      #region Accessor

      private static DetalleGuiaTransporteAccesor Accessor
      {
          [System.Diagnostics.DebuggerStepThrough]
          get { return DetalleGuiaTransporteAccesor.CreateInstance(); }
      }

      #endregion Accessor
    }
}
