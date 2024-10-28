using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using BLToolkit.Data;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ProductosVariosAccesor : AccessorBase<ProductosVariosAccesor>
    {

        [SprocName("Spu_Fac_Ins_ProductosVarios")]
        public abstract void Spu_Fac_Ins_ProductosVarios(string @FAC11CODEMP, string @FAC11PRODCOD, string @FAC11PRODDESC, 
        string @FAC11PRODUNIMED, string @FAC11PRODCODSUNAT, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Upd_ProductoVarios")]
        public abstract void Spu_Fac_Upd_ProductoVarios(string @FAC11CODEMP, string @FAC11PRODCOD, string @FAC11PRODDESC, 
        string @FAC11PRODUNIMED, string @FAC11PRODCODSUNAT, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Del_ProductosVarios")]
        public abstract void Spu_Fac_Del_ProductosVarios(string @FAC11CODEMP, string @FAC11PRODCOD, 
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Trae_ProductosVarios")]
        public abstract List<ProductosVarios> Spu_Fac_Trae_ProductosVarios (string @FAC11CODEMP);

        [SprocName("Spu_Fac_Trae_NuevoCodigoProductosVarios")]
        public abstract void Spu_Fac_Trae_NuevoCodigoProductosVarios(string @FAC11CODEMP, out string @CodigoNuevo);
    }
}
