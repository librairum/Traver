using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class EquiAlmacenGuiaAccesor : AccessorBase<EquiAlmacenGuiaAccesor>
    {
        [SprocName("Spu_Inv_Trae_In20EquiAlmVSGuias")]
        public abstract List<EquiAlmacenGuias> TraerEquiAlmVSGuias(string @in20empresacod);

 
        [SprocName("Spu_Inv_Ins_In20EquiAlmVSGuias")]
        public abstract void EquiAlmGuiaInsertar(string @in20empresacod, string @in20codtraalm, string @in20codmotivoguia, out int @flag,  out string @cMsgRetorno);


        [SprocName("Spu_Inv_Del_In20EquiAlmVSGuias")]
        public abstract void EquiAlmGuiaEliminar(string @in20empresacod, string @in20codtraalm, string @in20codmotivoguia, out int @flag, out string @cMsgRetorno);

    }
}
