using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class TipoVentaLogic
    {
        #region Singleton
        private static volatile TipoVentaLogic instance;
        private static object syncRoot = new Object();

        private TipoVentaLogic() { }

        public static TipoVentaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TipoVentaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<TipoPuntoVenta> TraerTipoVenta(string @come02empresa)
        {
            return Accessor.TraerTipoVenta(@come02empresa);
        }

        public List<ItemsList> ObtenerListItems(string codigoEmpresa)
        {
            var lista = Accessor.TraerTipoVenta(codigoEmpresa);
            return lista.Select(x => new ItemsList { Value = x.Codigo, Text = x.Descripcion }).ToList();
        }


        #region Accessor

        private static TipoVentaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TipoVentaAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
