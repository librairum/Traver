using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Transactions;
using System.Data;
using System.Collections;

namespace Inv.BusinessLogic
{
    public class TipoAnalisisLogic
    {

        #region Singleton
        private static volatile TipoAnalisisLogic instance;
        private static object syncRoot = new Object();

        private TipoAnalisisLogic() { }

        public static TipoAnalisisLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TipoAnalisisLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<TipoAnalisis> TraerTipoAnalisis(string codigoEmpresa)
        {
            return Accessor.TraerTipoAnalisis(codigoEmpresa);
        }

        public List<ItemsList> ObtenerListItems(string codigoEmpresa)
        {
            var lista = Accessor.TraerTipoAnalisis(codigoEmpresa);
            return lista.Select(x => new ItemsList { Value = x.Codigo, Text = x.Descripcion }).ToList();
        }

        //public List<TipoAnalisis> TraerTipoAnalisis(string codemp)
        //{
        //    return Accessor.Spu_Inv_Trae_cca(codemp);
        //}

        public void InsertarTipoAnalisis(TipoAnalisis analisis, out string @CMSGRETORNO)
        {
            Accessor.Spu_Inv_Ins_TipoAnalisis(analisis.CodigoEmpresa, analisis.Codigo, analisis.Descripcion, out @CMSGRETORNO);
        }


        public void ActualizarTipoAnalisis(TipoAnalisis analisis, out string @CMSGRETORNO)
        {
            Accessor.Spu_Inv_Upd_TipoAnalisis(analisis.CodigoEmpresa, analisis.Codigo, analisis.Descripcion, out @CMSGRETORNO);
        }


        public void EliminarTipoAnalisis(TipoAnalisis analisis, out string @CMSGRETORNO)
        {
            Accessor.Spu_Inv_Del_TipoAnalisis(analisis.CodigoEmpresa, analisis.Codigo, out @CMSGRETORNO);
        }

        public void TraerTipoAnalisisCodigo(string codigoEmpresa, out string codigo)
        {
            Accessor.Spu_Inv_Trae_TipoAnalisisCodigo(codigoEmpresa, out codigo);
        }

        public List<TipoAnalisis> TraerTipoAnalisisRegistro(string @ccb17emp, string @ccb17cdgo)
        {
            return Accessor.Spu_Inv_Traer_TipoAnalisisRegistro(@ccb17emp, @ccb17cdgo);
        }

        #region Accessor

        private static TipoAnalisisAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TipoAnalisisAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
