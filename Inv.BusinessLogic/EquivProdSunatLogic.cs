using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class EquivProdSunatLogic
    {
        #region Singleton
        private static volatile EquivProdSunatLogic instance;
        private static object syncRoot = new Object();
        private EquivProdSunatLogic() { }
        public static EquivProdSunatLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EquivProdSunatLogic();
                    }

                }
                return instance;
            }
        }
        #endregion

        public void Inserta(EquivProdSunat equivalencia, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Ins_EquivalenciaProductoSunat( equivalencia.FAC88CODEMP, 
            equivalencia.FAC88PRODEMPRESA, equivalencia.FAC88PRODSUNATCODIGO, out @flag, out @msgretorno);
        }
        public void Actualiza(EquivProdSunat equivalencia, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Upd_EquivalenciaProductoSunat(equivalencia.FAC88CODEMP, equivalencia.FAC88PRODEMPRESA,
            equivalencia.FAC88PRODSUNATCODIGO, out @flag, out @msgretorno);
        }

        public void Elimina(EquivProdSunat equivalencia, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Del_EquivalenciaProductoSunat(equivalencia.FAC88CODEMP, equivalencia.FAC88PRODEMPRESA,
            out @flag, out @msgretorno);
        }

        public  List<EquivProdSunat> Listar(string @FAC88CODEMP)
        {
            return Accessor.Spu_Fac_Trae_EquivalenciasProductoSunat(@FAC88CODEMP); 
        }
        public List<EquivProdSunat> ListaEquivalenciasSunat(string @glo01codigotabla)
        { 
            return Accessor.Spu_Fact_Trae_EquiProdSunat(@glo01codigotabla);
        }
        public List<Spu_Fact_Trae_ProdEquiSunat> TraeAyudaEquivalencia(string @glo04CodigoTabla)
        {
            return Accessor.Spu_Fact_Trae_ProdEquiSunat(@glo04CodigoTabla);
        }
        #region Accessor
        private static EquivProdSunatAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return EquivProdSunatAccesor.CreateInstance(); }
        }
        #endregion Accessor
    }
}
