using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using System.Data;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class PuntoVentaAccesor : AccessorBase<PuntoVentaAccesor>
    {
        [SprocName("Spu_Fact_Ins_FAC55_PuntoVenta")]
        public abstract void Spu_Fact_Ins_FAC55_PuntoVenta( string @FAC55CODEMP,
        string @FAC55COD,string @FAC55DESC,out int @flag,out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC55_PuntoVenta")]
        public abstract void Spu_Fact_Upd_FAC55_PuntoVenta(string @FAC55CODEMP,  
        string @FAC55COD, string @FAC55DESC, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Trae_FAC55_PuntoVenta")]
        public abstract List<PuntoVenta> Spu_Fact_Trae_FAC55_PuntoVenta(string @FAC55CODEMP, 
        string @campo, string @Filtro);

        [SprocName("Spu_Fact_Del_FAC55_PuntoVenta")]
        public abstract void Spu_Fact_Del_FAC55_PuntoVenta(string @FAC55CODEMP, string @FAC55COD,
        out int @flag, out string @msgretorno);
    }
}
