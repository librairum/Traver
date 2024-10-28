using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ServiciosLogic
    {

      #region Singleton
        private static volatile ServiciosLogic instance;
        private static object syncRoot = new Object();

        private ServiciosLogic() { }

        public static ServiciosLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ServiciosLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public void Inserta(Servicios servicio, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Ins_Servicio( servicio.FAC10CODEMP, servicio.FAC10SERVCOD, servicio.FAC10SERVDESC, servicio.FAC10SERVCODSUNAT, out @flag, out @msgretorno);
        }
        public void Actualiza(Servicios servicio, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Upd_Servicio( servicio.FAC10CODEMP, servicio.FAC10SERVCOD, servicio.FAC10SERVDESC, servicio.FAC10SERVCODSUNAT,
            out @flag, out @msgretorno);
        }

        public void Elimina(Servicios servicio, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fac_Del_Servicio(servicio.FAC10CODEMP, servicio.FAC10SERVCOD, out @flag, out @msgretorno);
        }
        public  List<Servicios> Listar(string @FAC10CODEMP)
        {
            return Accessor.Spu_Fac_Trae_Servicios(@FAC10CODEMP); 
        }
        public void TraerNuevoCodigo(string @FAC10CODEMP, out string @CodigoNuevo)
        {
            Accessor.TraerNuevoCodigo(@FAC10CODEMP, out  @CodigoNuevo);
        }
        #region Accessor

        private static ServiciosAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ServiciosAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
