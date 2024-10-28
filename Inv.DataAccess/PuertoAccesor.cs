using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class PuertoAccesor : AccessorBase<PuertoAccesor>
    {

        [SprocName("Spu_Fact_Trae_FAC52PUERTOS")]
        public abstract List<Puertos> Spu_Fact_Trae_FAC52PUERTOS(string @campo, string @filtro);

        [SprocName("Spu_Fact_Ins_FAC52PUERTOS")]
        public abstract void Spu_Fact_Ins_FAC52PUERTOS(string @FAC52CODPUERTO, string @FAC52DESCRIPCION,out int @flag, out string @msgretorno);
        [SprocName("Spu_Fact_Upd_FAC52PUERTOS")]
        public abstract void Spu_Fact_Upd_FAC52PUERTOS(string @FAC52CODPUERTO, string @FAC52DESCRIPCION, 
            out int @flag, out string @msgretorno);
        
        [SprocName("Spu_Fact_Del_FAC52PUERTOS")]
        public abstract void Spu_Fact_Del_FAC52PUERTOS(string @FAC52CODPUERTO, out int @flag ,out string @msgretorno );


        [SprocName("Spu_Fact_Trae_CodigoFAC52PUERTOS")]
        public abstract void Spu_Fact_Trae_CodigoFAC52PUERTOS(out string @cCodigoNuevo);


    }
}
