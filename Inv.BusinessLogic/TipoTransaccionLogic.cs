using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class TipoTransaccionLogic
    {
        #region Singleton
        private static volatile TipoTransaccionLogic instance;
        private static object syncRoot = new Object();

        private TipoTransaccionLogic() { }

        public static TipoTransaccionLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TipoTransaccionLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<TipoTransaccion> TraerTipoTransaccion(string @cCodEmp, string @cCampo, string @cFiltro)
        {
            return Accessor.TraerTipoTransaccion(cCodEmp, cCampo, cFiltro);
        }

        public List<ItemsList> ObtenerListItems(string codigoEmpresa)
        {
            var lista = Accessor.TraerTipoTransaccion(codigoEmpresa, "", "*");
            return lista.Select(x => new ItemsList { Value = x.in15Codigo, Text = x.in15Descripcion }).ToList();
        }

        public List<TipoTransaccion> TraerTipoTransaccion1(string codigoEmpresa)
        {
            return Accessor.TraerTipoTransaccion1(codigoEmpresa, "in15Codigo", "*");
        }
   
        
    
        #region Accessor

        private static TipoTransaccionAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TipoTransaccionAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
