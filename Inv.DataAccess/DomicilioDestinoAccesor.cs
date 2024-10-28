using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class DomicilioDestinoAccesor : AccessorBase<DomicilioDestinoAccesor>
    {
        [SprocName("Spu_Fact_Trae_FAC65_DESTINARIOESTAB")]
        public abstract List<DomicilioDestino> TraerDomiciliosDestino(string @FAC65CodEmp, string @campo,string @filtro);
        
        [SprocName("Spu_Fact_Ins_FAC65_DESTINARIOESTA")]
        public abstract void InsertaarDomicilioDestino (string @FAC65CODEMP,  string @FAC64CODIGO,  
            string @FAC65CODEST,string @FAC65DESEST ,string @FAC65CODTIPEST,string @FAC65DIRECCION ,  
            out string @msgretorno );
     
        [SprocName("Spu_Fact_Upd_FAC65_DESTINARIOESTA")]
        public abstract void ActualizarDomicilioDestino(  string @FAC65CODEMP,  string @FAC64CODIGO  ,  string @FAC65CODEST  ,  
                string @FAC65DESEST ,  string @FAC65CODTIPEST  ,  string @FAC65DIRECCION  ,  out string @msgretorno  );
        [SprocName("Spu_Fact_Del_FAC65_DESTINARIOESTA")]
        public abstract void EliminarDomicilioDestino(string @FAC65CODEMP, string @FAC64CODIGO, string @FAC65CODEST);
    }
}
