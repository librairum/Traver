using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class CentroCostoLogic
    {

        #region Singleton
        private static volatile CentroCostoLogic instance;
        private static object syncRoot = new Object();

        private CentroCostoLogic() { }

        public static CentroCostoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CentroCostoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public List<CentroCosto> TraerCentroCosto(string codigoEmpresa, string anio)
        {
            return Accessor.TraerCentroCosto(codigoEmpresa, "", "*", anio);
        }

        public List<ItemsList> ObtenerListItems(string codigoEmpresa, string anio)
        {
            var lista = Accessor.TraerCentroCosto(codigoEmpresa, "", "*", anio);
            return lista.Select(x => new ItemsList { Value = x.Codigo, Text = x.Descripcion }).ToList();
        }

        public DataTable ObtenerListDataTable(string codigoEmpresa, string anio)
        {
            var lista = Accessor.TraerCentroCosto(codigoEmpresa, "", "*", anio);
            DataTable table = new DataTable("CentroCosto");
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));

            foreach (var item in lista)
            {
                table.Rows.Add(item.Descripcion, item.Codigo);
            }
            return table;
        }
        //DELETE
        public string EliminarCentroCosto(string @cCodemp, string @cCodigo, out string @cMsgRetorno) 
        {
            return Accessor.EliminarCentroCosto(@cCodemp, @cCodigo,out @cMsgRetorno);
        }
        //INSERT
        public string InsertarCentroCosto(string @cCodemp, string @cCodigo,string @ccb02aa, string @cDescripcion, out string @cMsgRetorno)
        {
            return Accessor.InsertarCentroCosto(@cCodemp, @cCodigo, @ccb02aa, @cDescripcion, out @cMsgRetorno);
        }
        //UPDATE
        public string ActualizarCentroCosto(string @cCodemp, string @cCodigo, string @cDescripcion, out string @cMsgRetorno)
        {
            return Accessor.ActualizarCentroCosto(@cCodemp, @cCodigo, @cDescripcion, out @cMsgRetorno);
        }
        public DataTable TraerReporte_DetCentroCosto(string @cCodEmp, string @XMLrango, string @cAno, string @cMes, string @dFecini, string @dFecFin, string @cTI, string @cMoneda) 
        {
            return Accessor.TraerReporte_DetCentroCosto(@cCodEmp, @XMLrango, @cAno, @cMes, @dFecini, @dFecFin, @cTI, @cMoneda);
        }
        public DataTable Insertar_RangoImpresion(string @cEmpresa, string @cUsuario, string @cProceso, string @cValor, out string @cMsgRetorno) 
        {
            return Accessor.Ins_RangoImpresion(@cEmpresa, @cUsuario, @cProceso, @cValor, out @cMsgRetorno);
        }
        #region "Compras"
        public List<CentroCosto> TraeCentroCostoCompras(string @cCodEmp, string @anio)
        {
            return Accessor.TraeCentroCostoCompras(@cCodEmp, @anio);
        }
        #endregion
        #region Accessor

        private static CentroCostoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CentroCostoAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
