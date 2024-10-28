using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data; 

namespace Inv.DataAccess
{
    public abstract class PaisesAccesor : AccessorBase<PaisesAccesor>
    {

        [SprocName("Spu_Fact_Trae_FAC51PAISES")]
        public abstract List<Paises> Spu_Fact_Trae_FAC51PAISES(string @campo,string @filtro);

        [SprocName("Spu_Fact_Ins_FAC51PAISES")]
        public abstract void Spu_Fact_Ins_FAC51PAISES(string @FAC51CODPAIS,string @FAC51DESCRIPCION,out int @flag,out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC51PAISES")]
        public abstract void Spu_Fact_Upd_FAC51PAISES(string @FAC51CODPAIS,string @FAC51DESCRIPCION, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Del_FAC51PAISES")]
        public abstract void Spu_Fact_Del_FAC51PAISES(string @FAC51CODPAIS,  out int @flag,out string @msgretorno);
        
    }

}
