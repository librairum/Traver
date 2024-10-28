using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class UnidaddeMedidaLogic
    {

        #region Singleton
        private static volatile UnidaddeMedidaLogic instance;
        private static object syncRoot = new Object();

        private UnidaddeMedidaLogic() { }

        public static UnidaddeMedidaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UnidaddeMedidaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public List<UnidaddeMedida> TraerUnidaddeMedida(string codigoEmpresa)
        {
            return Accessor.TraerUnidaddeMedida(codigoEmpresa, "", "*");
        }
        public void InsertarUnidadMedida(string codigoEmpresa,UnidaddeMedida entidad, out string @MsgRetorno) {
            @MsgRetorno = string.Empty;
            Accessor.InsertarUnidadMedida(codigoEmpresa, entidad.in21codigo, entidad.in21descri, out @MsgRetorno);
        }
        public void ActualizarUnidadMedida(string codigoEmpresa, UnidaddeMedida entidad, out string @MsgRetorno) {
            @MsgRetorno = string.Empty;
            Accessor.ActualizarUnidadMedida(codigoEmpresa, entidad.in21codigo, entidad.in21descri, out @MsgRetorno);
        }
        public void EliminarUnidadMedidad(string codigoEmpresa, UnidaddeMedida entidad, out string @MsgRetorno) {
            @MsgRetorno = string.Empty;
            Accessor.EliminarUnidadMedidad(codigoEmpresa, entidad.in21codigo, out @MsgRetorno);
        }
        #region Accessor

        private static UnidaddemedidaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UnidaddemedidaAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
