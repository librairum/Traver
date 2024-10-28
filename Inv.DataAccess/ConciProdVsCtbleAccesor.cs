using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using BLToolkit.Data;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
    public abstract class ConciProdVsCtbleAccesor : AccessorBase<ConciProdVsCtbleAccesor>
    {
        [SprocName("Spu_Cos_Trae_ConciProdVsCtble")]
        public abstract List<ConciProdVsCtble> TraerConciProdVsCtble(string @COS03CODEMP,  string @COS03CODLINEAPRODUCCION);
        [SprocName("Spu_Cos_Ins_ConciProdVsCtble")]
        public abstract void InsertarConciProdVsCtble(string @COS03CODEMP, string @COS03CODACTCONTABLE,
                                                            string @COS03CODLINEAPRODUCCION, string @COS03CODACTPRODUCCION, out string @msgretorno,
                                                            out int @flag);
        [SprocName("Spu_Cos_Del_ConciProdVsCtble")]
        public abstract void EliminarConciProdVsCtble(string @COS03CODEMP, string @COS03CODACTCONTABLE,
                                                            string @COS03CODLINEAPRODUCCION, string @COS03CODACTPRODUCCION, out string @msgretorno,
                                                            out int @flag);
    }
}
