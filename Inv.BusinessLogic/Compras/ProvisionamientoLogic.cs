using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class ProvisionamientoLogic
    {
        #region Singleton
        private static volatile ProvisionamientoLogic instance;
        private static object syncRoot = new Object();

        private ProvisionamientoLogic() { }

        public static ProvisionamientoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ProvisionamientoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public List<ProvisionamientoOrdenCompra> TraeProvisionamientos(string @cCodemp, string @cFecIni, string @cFecFin, 
            string @cTipAna, string @cTipOrden)
        {
            return Accessor.Spu_Com_Trae_Provisionamientos(@cCodemp, @cFecIni, @cFecFin, @cTipAna, @cTipOrden);
        }



        public List<ProvisionamientoConsulta> TraeConsultaFacturaxOrdenCompra(string @cCodemp, string @cAno, string @cTipAna, string @cTipo,
        string @cFecIni, string @cFecFin)
        {
            return Accessor.Spu_Com_Trae_ConsultaFacturaxOrdenCompra(@cCodemp, @cAno, @cTipAna, @cTipo, @cFecIni, @cFecFin);
        }



        public List<ProvisionamientoOrdenCompraDetalle> TraeProvisionamientosDetalle(string @cEmpresa, string @cAno, string @cMes,
        string @cTipoOrd, string @cCodigoOrd, string @CO05ANOORDCOM, string @CO05MESORDCOM)
        { 
            return Accessor.Spu_Com_Trae_ProvisionamientosDetalle(@cEmpresa, @cAno, @cMes, @cTipoOrd, @cCodigoOrd, @CO05ANOORDCOM, @CO05MESORDCOM);
        }



        #region Accessor

        private static ProvisionamientoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ProvisionamientoAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
