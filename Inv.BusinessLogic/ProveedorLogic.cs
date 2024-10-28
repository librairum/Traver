using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ProveedorLogic
    {

        #region Singleton
        private static volatile ProveedorLogic instance;
        private static object syncRoot = new Object();

        private ProveedorLogic() { }

        public static ProveedorLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ProveedorLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<Proveedor> TraerProveedor(string codigoEmpresa, string tipoAnalisis)
        {
            return Accessor.TraerProveedor(codigoEmpresa, tipoAnalisis, "", "*");
        }

        public List<ItemsList> ObtenerListItems(string codigoEmpresa, string tipoAnalisis)
        {
            var lista = Accessor.TraerProveedor(codigoEmpresa, tipoAnalisis, "", "*");
            return lista.Select(x => new ItemsList { Value = x.Codigo, Text = x.Nombre }).ToList();
        }

        public DataTable ObtenerListDataTable(string codigoEmpresa, string tipoAnalisis)
        {
            var lista = Accessor.TraerProveedor(codigoEmpresa, tipoAnalisis, "", "*");
            DataTable table = new DataTable("Proveedores");
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));

            foreach (var item in lista)
            {
                table.Rows.Add(item.Nombre, item.Codigo);
            }
            return table;
        }

        public List<ProveedoresSunat> TraerProveedorSunat(string @cEmpresa, string @cAno, string @cMes, string @flag)
        { 
            return Accessor.TraerProveedorSunat(@cEmpresa, @cAno, @cMes, @flag);
        }
        public List<ProveedoresSunat> ComprasTraeValidacionSunat(string @cEmpresa, string @cod_actualizacion, string @cAno,
        string @cMes, string @flag)
        { 
            return Accessor.TraeValidacionSunat(@cEmpresa, @cod_actualizacion, @cAno, @cMes, @flag);
        }
    
        #region Accessor

        private static ProveedorAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ProveedorAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
