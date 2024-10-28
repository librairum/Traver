using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
   public abstract class ActividadesContableAccesor : AccessorBase<ActividadesContableAccesor>
    {
       [SprocName("Spu_Cos_Trae_ActividadesContables")]
       public abstract List<ActividadesContable> TraerActividadesContables(string @COS01CODEMP);
       [SprocName("Spu_Cos_Trae_ActividadesContablesxTipo")]
       public abstract List<ActividadesContable> TraerActCtblxTipo(string @COS01CODEMP, string @COS01CODTIPO);
       [SprocName("Spu_Cos_Trae_CodCorrelativoActividadesContables")]
       public abstract  void TraerCodigoCorrelativo(string @COS01CODEMP, out string @COS01CODIGO );

       [SprocName("Spu_Cos_Ins_COS01ACTIVIDADCONTABLE")]
       public abstract void InsertarActividadContable(string @COS01CODEMP, string @COS01CODIGO, string @COS01DESCRIPCION,
                                                        string @COS01CODTIPO, string @COS01CTACBLE, out string @msgretorno, 
                                                        out int @flag);

       [SprocName("Spu_Cos_Upd_COS01ACTIVIDADCONTABLE")]
       public abstract void ActualizarActividadContable(string @COS01CODEMP, string @COS01CODIGO, string @COS01DESCRIPCION, string @COS01CODTIPO,
                                                        string @COS01CTACBLE, out string @msgretorno, out int @flag);
       [SprocName("Spu_Cos_Del_COS01ACTIVIDADCONTABLE")]       
       public abstract void EliminarActividadContable(string @COS01CODEMP, string @COS01CODIGO, string @COS01CODTIPO, out string @msgretorno, out int @flag);
       [SprocName("Spu_Cos_Trae_ActividadesContablexTipo")]
       public abstract List<ActividadesContable> TraerActividadesContablexTipo(string @Empresa, string @ActContTipo);
    }
}
