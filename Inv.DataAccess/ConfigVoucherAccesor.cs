using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    
    public abstract class ConfigVoucherAccesor : AccessorBase<ConfigVoucherAccesor>
    {
        [SprocName("Spu_Inv_Trae_ConfigVocuherConta")]
        public abstract List<ConfiguraVoucherContable> Traer(string @IN29CODEMP, string @IN29AA);

        [SprocName("Spu_Inv_Ins_ConfigVocuherConta")]
        public abstract void Insertar(string @IN29CODEMP,string @IN29AA,string @IN29CODALM, string @in29transaccionCod,
        string @IN29TIPOARTI, string @IN29CTAALMACEN,string @IN29CTAGASTOS, string @IN29CTAVAREXISTENCIAS,
        string @IN29CTANUEVE,string @in29CuentaDebe,  string @in29CuentaHaber, out int @flag, out string @mensaje);

        [SprocName("Spu_Inv_Upd_ConfigVocuherConta")]
        public abstract void Actualizar(string @IN29CODEMP, string @IN29AA, string @IN29CODALM, string @in29transaccionCod,
        string @IN29TIPOARTI, string @IN29CTAALMACEN, string @IN29CTAGASTOS, string @IN29CTAVAREXISTENCIAS,
        string @IN29CTANUEVE, string @in29CuentaDebe, string @in29CuentaHaber, out int @flag, out string @mensaje);

        [SprocName("Spu_Inv_Del_ConfigVocuherConta")]
        public abstract void Eliminar(string @IN29CODEMP, string @IN29AA, string @IN29CODALM, string @in29transaccionCod,
        string @IN29TIPOARTI, out int @flag, out string @mensaje);



    }
}
