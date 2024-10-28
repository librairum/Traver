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
    public abstract class LoteCostoAccesor : AccessorBase<LoteCostoAccesor>
    {
        [SprocName("Spu_Cos_Trae_CodigoGeneradoLoteCosto")]
        public abstract void TraerCodigoGenerado(string @Empresa, string anio, string mes, out string @codigo);

        [SprocName("Spu_Cos_Traer_LoteCostoTodos")]
        public abstract List<LoteCosto> TraerLoteCostoxEmpresa(string @Empresa, string @Anio, string @Mes, string @Linea);

        [SprocName("Spu_Cos_Traer_LoteCosto")]
        public abstract LoteCosto TraerLoteCosto(string @Empresa, string @Anio, string @Mes,
                                                 string @Linea, string @Codigo);

        [SprocName("Spu_Cos_Ins_LoteCosto")]
        public abstract void InsertarLoteCosto(string @COS01CODEMP, string @COS01ANIO,
                            string @COS01MES, string @COS01LINEA, string @COS01CODIGO,
                            string @COS01DESCRIPCION, out string @msgretorno, out int @flag);

        [SprocName("Spu_Cos_Upd_LoteCosto")]
        public abstract void ActualizarLoteCosto(string @COS01CODEMP, string @COS01ANIO,
                            string @COS01MES, string @COS01LINEA, string @COS01CODIGO,
                            string @COS01DESCRIPCION, out string @msgretorno, out int @flag);

        [SprocName("Spu_Cos_Del_LoteCosto")]
        public abstract void EliminarLoteCosto(string @COS01CODEMP, string @COS01ANIO,
                            string @COS01MES, string @COS01LINEA, string @COS01CODIGO,
                            out string @msgretorno, out int @flag);


    }
}
