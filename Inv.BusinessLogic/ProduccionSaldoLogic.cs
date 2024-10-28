using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
namespace Inv.BusinessLogic
{
    public class ProduccionSaldoLogic
    {
        #region Singleton
        private static volatile ProduccionSaldoLogic instance;
        private static object syncRoot = new Object();
        private ProduccionSaldoLogic() { }
        public static ProduccionSaldoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ProduccionSaldoLogic();
                    }
                }
                return instance;
            }
        }
        #endregion

        public void ImportarDirectoProduccionSaldo(string @COS02CODEMP, string @COS02ANIO, string @COS02MES)
        {
            Accessor.Spu_Cos_Trae_SaldoInicial(@COS02CODEMP, @COS02ANIO, @COS02MES);
        }


        public List<ProduccionSaldo> Trae_ProduccionSaldo(string @COS02CODEMP, string @COS02ANIO, string @COS02MES)
        {
            return Accessor.Spu_Cos_Trae_ProduccionSaldo(@COS02CODEMP, @COS02ANIO, @COS02MES);
        }

        public List<ProduccionSaldo> TraeSaldoProduccionImportar(string @COS02CODEMP, string @COS02ANIO,
                                                string @COS02MES, string @COS01CODIGOUSUARIO, string @COS01SISTEMA)
        {
            return Accessor.Spu_Cos_Trae_ProduccionSaldoImportar(@COS02CODEMP, @COS02ANIO,
                                                @COS02MES, @COS01CODIGOUSUARIO, @COS01SISTEMA);
        }

        public void InsertarProduccionSaldoArchivo(ProduccionSaldo entidad, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Cos_Ins_ProduccionSaldoArchivo(entidad.COS02CODEMP,
                entidad.COS02ANIO, entidad.COS02MES,
            entidad.COS02ALMACOD, entidad.COS02PRODCOD,
            entidad.COS02PRODCANTIDAD, entidad.COS02PRODAREA, entidad.COS02PRODVOLUMEN,
            entidad.COS02PRODIMPSOL, entidad.COS02LINEACOD, entidad.COS02ACTCOD,
            entidad.COS01CODIGOUSUARIO, entidad.COS01SISTEMA,
            out @flag, out @mensaje);
        }


        public void InsertarProduccionSaldoImp(string @COS02CODEMP, string @COS02ANIO, string @COS02MES,
        string @COS01CODIGOUSUARIO, string @COS01SISTEMA, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Cos_Ins_ProduccionSaldoImportar(@COS02CODEMP, @COS02ANIO, @COS02MES, @COS01CODIGOUSUARIO,
                                                         @COS01SISTEMA, out @flag, out @mensaje);
        }

        public void EliminarProduccionSaldoArchivo(string @COS02CODEMP,
            string @COS02ANIO, string @COS02MES, string @COS01CODIGOUSUARIO,
            string @COS01SISTEMA, out int @flag,
            out string @mensaje)
        {
            Accessor.Spu_Cos_Del_ProduccionSaldoArchivo(@COS02CODEMP,
            @COS02ANIO, @COS02MES, @COS01CODIGOUSUARIO,
            @COS01SISTEMA, out @flag,
            out @mensaje);
        }
        #region Accessor
        private static ProduccionSaldoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ProduccionSaldoAccesor.CreateInstance(); }
        }
        #endregion
    }
}
