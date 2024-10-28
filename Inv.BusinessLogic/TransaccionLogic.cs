using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class TransaccionLogic
    {
        #region Singleton
        private static volatile TransaccionLogic instance;
        private static object syncRoot = new Object();

        private TransaccionLogic() { }

        public static TransaccionLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TransaccionLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public TipoTransaccion TraerTransaccionRegistro(string codigo, string codigo1)
        {
            return Accessor.TransaccionTraerRegistro(codigo, codigo1);
        }
        public List<TipoTransaccion> TraerTransaccion(string codigoEmpresa)
        {
            return Accessor.TransaccionTraer(codigoEmpresa, "in15Codigo", "*");
        }
        public void TransaccionInsertar(TipoTransaccion transaccion, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.TransaccionInsertar(transaccion.in15codemp,transaccion.in15Codigo,transaccion.in15Descripcion,transaccion.in15TipoMovimiento,
                                         transaccion.in15Valorizado, transaccion.in15Liquidacion, transaccion.in15ctactetipana,out @cMsgRetorno);
        }
        public void TransaccionModificar(TipoTransaccion transaccion, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.TransaccionModificar(transaccion.in15codemp, transaccion.in15Codigo, transaccion.in15Descripcion, transaccion.in15TipoMovimiento, 
                                          transaccion.in15Valorizado, transaccion.in15Liquidacion, transaccion.in15ctactetipana,out @cMsgRetorno);
        }
        public void TransaccionEliminar(TipoTransaccion transaccion, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.TransaccionEliminar(transaccion.in15codemp,transaccion.in15Codigo, out @cMsgRetorno);
        }
        


        #region Accessor

        private static TransaccionAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TransaccionAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
