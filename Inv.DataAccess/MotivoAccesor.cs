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
    public abstract class MotivoAccesor: AccessorBase<MotivoAccesor>
    {
        [SprocName("Spu_Pro_Ins_Motivo")]
        public  abstract void Spu_Pro_Ins_Motivo( string @PRO15CODEMP,string @PRO15CODIGO, string @PRO15DESCRIPCION, out int @flag, out string @cMsgRetorno);
        [SprocName("Spu_Pro_Upd_Motivo")]
        public abstract void Spu_Pro_Upd_Motivo(string @PRO15CODEMP, string @PRO15CODIGO, string @PRO15DESCRIPCION, out int @flag, out string @cMsgRetorno);
        [SprocName("Spu_Pro_Del_Motivo")]
        public abstract void Spu_Pro_Del_Motivo(string @PRO15CODEMP, string @PRO15CODIGO, string @PRO15DESCRIPCION, out int @flag, out string @cMsgRetorno);
        [SprocName("Spu_Prod_Traer_Motivo")]
        public abstract List<Motivo> Spu_Prod_Traer_Motivo(string @PRO15CODEMP, string @PRO15CODIGO, string @Tipo);
        [SprocName("Spu_Pro_Traer_CodigoMotivo")]
        public abstract void Spu_Pro_Traer_CodigoMotivo(string @PRO15CODEMP, out string @PRO15CODIGO);

        [SprocName("Spu_Pro_Rep_MotivosMerna")]
        public abstract DataTable Spu_Pro_Rep_Motivos(string @empresa, string @anio, string @linea, string @fechaini, 
                                                 string @fechafin, string @flag, string @XMLrango);

    }
}
