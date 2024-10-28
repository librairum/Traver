using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using Inv.BusinessEntities.DTO;
namespace Inv.DataAccess
{
    public abstract class EstadoCostoAccesor : AccessorBase<EstadoCostoAccesor>
    {
        [SprocName("Spu_Cos_Gen_AsientoCostos")]
        public abstract List<Spu_Cos_Gen_AsientoCostos> EstadoCostoProduccion(string @Empresa,
                                                                string @Anio, string @Mes, string @Linea);

        //[SprocName("Spu_Cos_Ins_DistribucionTasaxLinea")]
        //public abstract void Spu_Cos_Ins_DistribucionTasaxLinea(string @XMLrango, out string @mensaje, out int @flag);

        //[SprocName("Spu_Cos_Trae_GastosDistribuidosProduccion")]
        //public abstract List<ContaGastosxEmpresaxLinea> TraerDistribucionesProduccion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, string @COS01LINEACOD);

        //[SprocName("Spu_Cos_Cal_DistxLinea")]
        //public abstract void Spu_Cos_Cal_DistxLinea(string @COS01CODEMP, string @COS01ANIO, string @COS01MES);
    }
}
