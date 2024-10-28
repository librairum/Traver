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
    public abstract class CostosProduccionAccessor : AccessorBase<CostosProduccionAccessor>
    {
        [SprocName("Spu_Cos_Del_CostosProduccion")]
        public abstract void Spu_Cos_Del_CostosProduccion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, out string @msgretorno);

        [SprocName("Spu_Cos_Ins_CostosProduccion")]
        public abstract void Spu_Cos_Ins_CostosProduccion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, string @COS01CODIGOUSUARIO,
                                                         string @COS01SISTEMA, out string @mensaje, out int @flag);



        [SprocName("Spu_Cos_Del_CostosProduccionImportacion")]
        public abstract void Spu_Cos_Del_CostosProduccionImportacion(string @COS01CODEMP, string @USUARIO, out string @msgretorno);

        [SprocName("Spu_Cos_Ins_CostosProduccionImportacion")]
        public abstract void Spu_Cos_Ins_CostosProduccionImportacion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
         string @COS01CONTGASMOVANO, string @COS01CONTGASMOVMES, string @COS01CONTGASMOVSUBD,
         string @COS01CONTGASMOVNUMER, double @COS01CONTGASMOVORD, string @COS01CTACBLECOD,
         string @COS01CTACBLEDESC, string @COS01TIPOCOSTOCOD, string @COS01TIPOCOSTODESC, string @COS01COSTOCOD,
         string @COS01COSTODESC, double @COS01IMPORTE, string @COS01FIJOOVARIABLE,
         string @COS01DIRECTOOINDIRECTO, string @COS01FLAG, string @COS01ERRORES, int @COS01CANTERRORES,
         string @COS01CODIGOUSUARIO, string @COS01SISTEMA, out string @mensaje, out int @flag);

        [SprocName("Spu_Cos_Traer_CostosProduccionImportar")]
        public abstract List<CostosProduccion> Spu_Cos_Traer_CostosProduccionImportar(string @COS01CODEMP, string @USUARIO);

        [SprocName("Spu_Cos_Traer_CostosProduccionxEmpresa")]
        public abstract List<CostosProduccion> Spu_Cos_Traer_CostosProduccionxEmpresa(string @Empresa, string @Anio, string @Mes);



    }
}
