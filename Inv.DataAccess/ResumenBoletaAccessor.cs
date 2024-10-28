using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
    public abstract class ResumenBoletaAccessor : AccessorBase<ResumenBoletaAccessor>
    {

        [SprocName("Spu_Fac_Ins_FEResumenComprobantes")]
        public abstract void Spu_Fac_Ins_FEResumenComprobantes(string @FAC04CODEMP, string @FAC01COD,  string @XMLrango, 
        string @FechaDocumento, string @FechaResumen, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Trae_ResumenBoletas")]
        public abstract List<Spu_Fac_Trae_ResumenBoletas> Spu_Fac_Trae_ResumenBoletas(string @Empresa, string @Anio, string @Mes, string @TipoDocumento);
    }
}
