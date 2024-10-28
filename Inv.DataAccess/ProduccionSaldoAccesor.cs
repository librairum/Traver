using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ProduccionSaldoAccesor : AccessorBase<ProduccionSaldoAccesor>
    {
        [SprocName("Spu_Cos_Trae_SaldoInicial")]
        public abstract void Spu_Cos_Trae_SaldoInicial(string @COS02CODEMP, string @COS02ANIO, string @COS02MES);

        [SprocName("Spu_Cos_Trae_ProduccionSaldo")]
        public abstract List<ProduccionSaldo> Spu_Cos_Trae_ProduccionSaldo(string @COS02CODEMP, string @COS02ANIO, string @COS02MES);
        [SprocName("Spu_Cos_Trae_ProduccionSaldoImportar")]
        public abstract List<ProduccionSaldo> Spu_Cos_Trae_ProduccionSaldoImportar(string @COS02CODEMP, string @COS02ANIO,
                                                        string @COS02MES, string @COS01CODIGOUSUARIO, string @COS01SISTEMA);
        [SprocName("Spu_Cos_Ins_ProduccionSaldoArchivo")]
        public abstract void Spu_Cos_Ins_ProduccionSaldoArchivo(string @COS02CODEMP,
        string @COS02ANIO, string @COS02MES, string @COS02ALMACOD, string @COS02PRODCOD,
        double @COS02PRODCANTIDAD, double @COS02PRODAREA, double @COS02PRODVOLUMEN,
        double @COS02PRODIMPSOL, string @COS02LINEACOD, string @COS02ACTCOD,
        string @COS01CODIGOUSUARIO, string @COS01SISTEMA, out int @flag, out string @mensaje);

        [SprocName("Spu_Cos_Ins_ProduccionSaldoImportar")]
        public abstract void Spu_Cos_Ins_ProduccionSaldoImportar(string @COS02CODEMP, string @COS02ANIO, string @COS02MES,
        string @COS01CODIGOUSUARIO, string @COS01SISTEMA, out int @flag, out string @mensaje);

        [SprocName("Spu_Cos_Del_ProduccionSaldoArchivo")]
        public abstract void Spu_Cos_Del_ProduccionSaldoArchivo(string @COS02CODEMP,
            string @COS02ANIO, string @COS02MES, string @COS01CODIGOUSUARIO,
            string @COS01SISTEMA, out int @flag,
            out string @mensaje);
    }
}
