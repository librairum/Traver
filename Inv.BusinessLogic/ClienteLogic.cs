using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ClienteLogic
    {
        #region Singleton
        private static volatile ClienteLogic instance;
        private static object syncRoot = new Object();

        private ClienteLogic() { }

        public static ClienteLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ClienteLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public List<Cliente> TraerCliente(string codigoEmpresa)
        {
            return Accessor.TraerCliente(codigoEmpresa, "", "*");
        }

        public List<ItemsList> ObtenerListItems(string codigoEmpresa)
        {
            var lista = Accessor.TraerCliente(codigoEmpresa, "", "*");
            return lista.Select(x => new ItemsList { Value = x.Codigo, Text = x.Nombre}).ToList();
        }

        public DataTable ObtenerListDataTable(string codigoEmpresa)
        {
            var lista = Accessor.TraerCliente(codigoEmpresa, "", "*");
            DataTable table = new DataTable("Cliente");
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));

            foreach (var item in lista)
            {
                table.Rows.Add(item.Nombre, item.Codigo);
            }
            return table;
        }


        public List<SedesCliente> TraerSedesCliente(string @come05empresa, string @come05clientetipana, string @come05clientecod)
        {
            return Accessor.TraerSedesCliente(@come05empresa, @come05clientetipana, @come05clientecod);
        }

        public SedesCliente ObtenerSedesCliente(string @come05empresa, string @come05clientetipana, string @come05clientecod, 
            string @come05sedeclientescod)
        {
            return Accessor.ObtenerSedesCliente(@come05empresa, @come05clientetipana, @come05clientecod, @come05sedeclientescod);
        }

        #region Accessor

        private static ClienteAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ClienteAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
