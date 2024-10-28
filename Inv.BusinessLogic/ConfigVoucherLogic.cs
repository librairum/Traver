using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;


namespace Inv.BusinessLogic
{
    public class ConfigVoucherLogic
    {

        #region Singleton
        private static volatile ConfigVoucherLogic instance;
        private static object syncRoot = new Object();

        private ConfigVoucherLogic() { }

        public static ConfigVoucherLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ConfigVoucherLogic();
                    }
                }

                return instance;
            }
        }
        #endregion



        public List<ConfiguraVoucherContable> Traer(string @IN29CODEMP, string @IN29AA)
        { 
            return Accessor.Traer(@IN29CODEMP, @IN29AA);
        }


        public void Insertar(ConfiguraVoucherContable configVoucher, out int @flag, out string @mensaje)
        {
            Accessor.Insertar(configVoucher.IN29CODEMP, configVoucher.IN29AA, configVoucher.IN29CODALM, 
                configVoucher.in29transaccionCod, configVoucher.IN29TIPOARTI, configVoucher.IN29CTAALMACEN, 
                configVoucher.IN29CTAGASTOS, configVoucher.IN29CTAVAREXISTENCIAS,configVoucher.IN29CTANUEVE, 
                configVoucher.in29CuentaDebe, configVoucher.in29CuentaHaber, out @flag, out @mensaje);
        }


        public void Actualizar(ConfiguraVoucherContable configVoucher, out int @flag, out string @mensaje) 
        {
            Accessor.Actualizar(configVoucher.IN29CODEMP, configVoucher.IN29AA, configVoucher.IN29CODALM,
                configVoucher.in29transaccionCod, configVoucher.IN29TIPOARTI, configVoucher.IN29CTAALMACEN,
                configVoucher.IN29CTAGASTOS, configVoucher.IN29CTAVAREXISTENCIAS, configVoucher.IN29CTANUEVE,
                configVoucher.in29CuentaDebe, configVoucher.in29CuentaHaber, out @flag, out @mensaje);
        }


        public void Eliminar(string @IN29CODEMP, string @IN29AA, string @IN29CODALM, string @in29transaccionCod,
        string @IN29TIPOARTI, out int @flag, out string @mensaje)
        { 
            Accessor.Eliminar(@IN29CODEMP, @IN29AA, @IN29CODALM, @in29transaccionCod, 
                @IN29TIPOARTI, out @flag, out @mensaje);
        }


        #region Accessor

        private static ConfigVoucherAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ConfigVoucherAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
