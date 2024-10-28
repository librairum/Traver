using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using System.Data;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class MonedaAccesor : AccessorBase<MonedaAccesor>
    {
//Ayuda de moneda
        [SprocName("Spu_Glo_Help_glo01tablas")]
        public abstract List<Moneda> TraerMoneda(string @glo01codigotabla);
//Trae todo las monedas
        [SprocName("Spu_Fact_Trae_FAC54MONEDA")]
        public abstract List<Moneda> TraerTodoMonedas(string @campo, string @filtro);

        [SprocName("Spu_Fact_Ins_FAC54MONEDA")]
        public abstract void Spu_Fact_Ins_FAC54_MONEDA(string @FAC54CODIGO,string @FAC54DESCRIPCION, 
        string @FAC54ABREV, string @FAC54SIGNO, string @FAC54FEMONEDACOD, out int @flag, 
        out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC54MONEDA")]
        public abstract void Spu_Fact_Upd_FAC54_MONEDA(string @FAC54CODIGO, string @FAC54DESCRIPCION,
        string @FAC54ABREV, string @FAC54SIGNO, string @FAC54FEMONEDACOD, out int @flag,
        out string @msgretorno);

        [SprocName("Spu_Fact_Del_FAC54MONEDA")]
        public abstract void Spu_Fact_Del_FAC54_MONEDA(string @FAC54CODIGO,out int @flag,out string @msgretorno);


        #region"Tipo cambio moneda otros"
        [SprocName("Spu_Fac_Ins_InsertarTipoCambioOtrosMonedas")]
        public abstract void Spu_Fac_Ins_InsertarTipoCambioOtrosMonedas(string @Fecha , string @MonedaOrigenCod  , string @MonedaDestinoCod  , 
        double @TipoCambio  , out int @flag , out string @msgretorno);


        [SprocName("Spu_Fac_Trae_TipoCambioOtrosMoneda")]
        public abstract DataTable Spu_Fac_Trae_TipoCambioOtrosMoneda();


        [SprocName("Spu_Fac_Upd_TipoCambioOtrosMoneda")]
        public abstract void Spu_Fac_Upd_TipoCambioOtrosMoneda(string @Fecha, string @MonedaOrigenCod, string @MonedaDestinoCod, double @TipoCambio, out int @flag, out string @msgretorno);


        [SprocName("Spu_Fac_Del_TipoCambioOtrosMoneda")]
        public abstract void Spu_Fac_Del_TipoCambioOtrosMoneda(string @Fecha,string @MonedaOrigenCod, string @MonedaDestinoCod, out int @flag, out string @msgretorno);
        #endregion
    }
}
