using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class ResumenBoletaLogic
    {

        #region Singleton
        private static volatile ResumenBoletaLogic instance;
        private static object syncRoot = new Object();

        private ResumenBoletaLogic() { }

        public static ResumenBoletaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ResumenBoletaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        //-- Tabla Resumen de detalle x Cab.Boleta --------------
        
        
      
        public void GenerarResumenComprobante(string @FAC04CODEMP, string @FAC01COD, string @XMLrango,
        string @FechaDocumento, string @FechaResumen, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Ins_FEResumenComprobantes(@FAC04CODEMP, @FAC01COD, @XMLrango,
            @FechaDocumento, @FechaResumen, out @flag, out @msgretorno);
        }
        public List<Spu_Fac_Trae_ResumenBoletas> TraeResumenBoletas(string Empresa, string Anio, string Mes, string TipoDocumento)
        {
            return Accessor.Spu_Fac_Trae_ResumenBoletas(@Empresa, @Anio, @Mes, @TipoDocumento);
        }

        #region Accessor
        private static ResumenBoletaAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ResumenBoletaAccessor.CreateInstance(); }
        }
        #endregion Accessor
    }
}
