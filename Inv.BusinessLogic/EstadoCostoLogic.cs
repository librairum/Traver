using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using Inv.BusinessEntities.DTO;
namespace Inv.BusinessLogic
{
    public class EstadoCostoLogic
    {
        #region Single

        private static volatile EstadoCostoLogic instance;
        private static object syncRoot = new Object();
        private EstadoCostoLogic() { }
        public static EstadoCostoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EstadoCostoLogic();
                    }
                }
                return instance;
            }

        }
        #endregion

        

        
        /// <summary>
        /// Trae las actividades principales por cada activida de apoyo para la distribucion de porcentaje en cada actividad principales.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<Spu_Cos_Gen_AsientoCostos> EstadoCostoProduccion(string @Empresa,
                                                                string @Anio, string @Mes, string @Linea)
        {
            return Accessor.EstadoCostoProduccion(@Empresa, @Anio, @Mes, @Linea);
        }

        #region "Accessor"

        private static EstadoCostoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return EstadoCostoAccesor.CreateInstance(); }
        }
        #endregion  Accessor
    }
}
