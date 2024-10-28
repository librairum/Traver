using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class BancoAccesor: AccessorBase<BancoAccesor>
    {
        [SprocName("Spu_Fact_Ins_FAC50BANCOS")]
        public abstract void Spu_Fact_Ins_FAC50BANCOS(string @FAC50CODBANCO,  string @FAC50DESCRIPCION,  
        string @FAC50BANKCODE, string @FAC50ACOUNTNUMBER, out int @flag, out string @msgretorno);
        
        [SprocName("Spu_Fact_Upd_FAC50BANCOS")]
        public abstract void Spu_Fact_Upd_FAC50BANCOS(string @FAC50CODBANCO, string @FAC50DESCRIPCION, 
        string @FAC50BANKCODE, string @FAC50ACOUNTNUMBER, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Del_FAC50BANCOS")]
        public abstract void Spu_Fact_Del_FAC50BANCOS(string @FAC50CODBANCO, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Trae_FAC50BANCOS")]
        public abstract List<Bancos> Spu_Fact_Trae_FAC50BANCOS(string @campo,string @filtro);

    }
}
