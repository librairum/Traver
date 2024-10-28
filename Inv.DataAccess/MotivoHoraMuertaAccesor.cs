using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
    public abstract class MotivoHoraMuertaAccesor : AccessorBase<MotivoHoraMuertaAccesor>
    {
        [SprocName("Spu_Pro_Ins_MotivoHoraMuerta")]
        public abstract void InsertarMotivoHoraMuerta(string @PRO01CODEMP, string @PRO01CODIGO, string @PRO01DESCRIPCION, out string @msg, out int @flag);
        [SprocName("Spu_Pro_Upd_MotivoHoraMuerta")]
        public abstract void ActualizarMotivoHoraMuerta(string @PRO01CODEMP, string @PRO01CODIGO, string @PRO01DESCRIPCION, out string @msg, out  int @flag);
        [SprocName("Spu_Pro_Del_MotivohoraMuerta")]
        public abstract void EliminarMotivoHoraMuerta(string @PRO01CODEMP, string @PRO01CODIGO, out string @msg, out int @flag);
        [SprocName("Spu_Pro_Traer_MotivoHoraMuerta")]
        public abstract List<MotivoHoraMuerta> TraerMotivoHoraMuesta(string @PRO01CODEMP, string @PRO01CODIGO, string @Tipo);
        [SprocName("Spu_Pro_Traer_CodigoMotivoHoraMuerta")]
        public abstract void TraerCodigo(string @PRO01CODEMP, out string @nuevocodigo);
    }


}
