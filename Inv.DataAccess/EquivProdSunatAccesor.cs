using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;

using System;

using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class EquivProdSunatAccesor : AccessorBase<EquivProdSunatAccesor>
    {
        [SprocName("Spu_Fac_Ins_EquivalenciaProductoSunat")]
        public abstract void Spu_Fac_Ins_EquivalenciaProductoSunat( string @FAC88CODEMP, string @FAC88PRODEMPRESA, string @FAC88PRODSUNATCODIGO, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Upd_EquivalenciaProductoSunat")]
        public abstract void Spu_Fac_Upd_EquivalenciaProductoSunat(string @FAC88CODEMP, string @FAC88PRODEMPRESA, string @FAC88PRODSUNATCODIGO, out int @flag, out string @msgretorno);


        [SprocName("Spu_Fac_Del_EquivalenciaProductoSunat")]
        public abstract void Spu_Fac_Del_EquivalenciaProductoSunat(string @FAC88CODEMP, string @FAC88PRODEMPRESA, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Trae_EquivalenciasProductoSunat")]
        public abstract List<EquivProdSunat> Spu_Fac_Trae_EquivalenciasProductoSunat (string @FAC88CODEMP);
        [SprocName("Spu_Fact_Trae_EquiProdSunat")]
        public abstract List<EquivProdSunat> Spu_Fact_Trae_EquiProdSunat(string @glo01codigotabla);

        [SprocName("Spu_Fact_Trae_ProdEquiSunat")]
        public abstract List<Spu_Fact_Trae_ProdEquiSunat> Spu_Fact_Trae_ProdEquiSunat(string @glo04CodigoTabla);
    }
}
