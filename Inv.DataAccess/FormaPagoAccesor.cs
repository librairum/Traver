using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class FormaPagoAccesor : AccessorBase<FormaPagoAccesor>
    {
        [SprocName("Spu_Fact_Ins_FAC53_FORMAPAGO")]
        public abstract void Spu_Fact_Ins_FAC53_FORMAPAGO(string @FAC53COD, string  @FAC53DESC, 
                  string @FAC53DESCEEUU, int @FAC53DIAS,  out int @flag , out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC53_FORMAPAGO")]
        public abstract void Spu_Fact_Upd_FAC53_FORMAPAGO(string @FAC53COD, string @FAC53DESC,  
        string @FAC53DESCEEUU, int @FAC53DIAS,  out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Trae_FAC53_FORMAPAGO")]
        public abstract  List<FormaPago> Spu_Fact_Trae_FAC53_FORMAPAGO(string @campo,  string @filtro);

        [SprocName("Spu_Fact_Del_FAC53_FORMAPAGO")]
        public abstract void Spu_Fact_Del_FAC53_FORMAPAGO(string @FAC53COD, out int @flag,
        out string @msgretorno);
        [SprocName("Spu_Fact_Help_FormaPago")]
        public abstract List<FormaPago> Spu_Fact_Help_FormaPago(string @Co02Codemp, string @cOrden, string @cFiltro);

        [SprocName("Spu_Com_Trae_FormaPago")]
        public abstract List<FormaPago> Spu_Com_Trae_FormaPago(string @cCdoEmp);


    }
}
