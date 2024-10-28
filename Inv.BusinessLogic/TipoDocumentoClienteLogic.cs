using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class TipoDocumentoClienteLogic
    {
        #region Singleton
        private static volatile TipoDocumentoClienteLogic instance;
        private static object syncRoot = new Object();

        private TipoDocumentoClienteLogic() { }

        public static TipoDocumentoClienteLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TipoDocumentoClienteLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<TipoDocumentoCliente> TraerTipoDocumentoCliente(string @come04empresa)
        {
            return Accessor.TraerTipoDocumentoCliente(@come04empresa);
        }

        public List<ItemsList> ObtenerListItems(string codigoEmpresa)
        {
            var lista = Accessor.TraerTipoDocumentoCliente(codigoEmpresa);
            return lista.Select(x => new ItemsList { Value = x.Codigo, Text = x.Descripcion }).ToList();
        }

        #region Accessor

        private static TipoDocumentoClienteAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TipoDocumentoClienteAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }


}
