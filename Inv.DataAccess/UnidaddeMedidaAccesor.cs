using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class UnidaddemedidaAccesor : AccessorBase<UnidaddemedidaAccesor>
    {
        [SprocName("sp_Inv_Help_Unidad_Medida")]
        public abstract List<UnidaddeMedida> TraerUnidaddeMedida(string @cCodEmp, string @cCampo, string @cFiltro);
        [SprocName("Spu_Inv_Ins_UnidadMedida")]
        public abstract void InsertarUnidadMedida(  string @cCodemp,string @In21codigo ,string @In21descri ,out string @cMsgRetorno);
        [SprocName("Spu_Inv_Up_UnidadMedida")]
        public abstract void ActualizarUnidadMedida(string @cCodemp,string @In21codigo ,string @In21descri ,out string @cMsgRetorno);
        [SprocName("Spu_Inv_Del_UnidadMedida")]
        public abstract void EliminarUnidadMedidad(string @cCodEmp, string @In21codigo, out string @cMsgRetorno);
        
        

    }

}
