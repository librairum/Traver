using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
namespace Inv.BusinessLogic
{
  public  class DomicilioDestinoLogic
    {

        #region Singleton
      private static volatile DomicilioDestinoLogic instance;
        private static object syncRoot = new Object();

        private DomicilioDestinoLogic() { }

        public static DomicilioDestinoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DomicilioDestinoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        //[SprocName("Spu_Fact_Trae_FAC65_DESTINARIOESTAB")]c
        public List<DomicilioDestino> TraerDomiciliosDestino(string @FAC65CodEmp, string @campo, string @filtro) {
            return Accessor.TraerDomiciliosDestino(@FAC65CodEmp, @campo, @filtro);
        }

        //[SprocName("Spu_Fact_Ins_FAC65_DESTINARIOESTA")]
        public void InsertaarDomicilioDestino(DomicilioDestino domicilio,
            out string @msgretorno) {
                string msj = string.Empty;
                Accessor.InsertaarDomicilioDestino(
                domicilio.FAC65CODEMP, domicilio.FAC64CODIGO,
                domicilio.FAC65CODEST, domicilio.FAC65DESEST, domicilio.FAC65CODTIPEST,
                domicilio.FAC65DIRECCION, out @msgretorno);

        }

        //[SprocName("Spu_Fact_Upd_FAC65_DESTINARIOESTA")]
        public void ActualizarDomicilioDestino(DomicilioDestino domicilio, out string @msgretorno) {
            Accessor.ActualizarDomicilioDestino(domicilio.FAC65CODEMP, domicilio.FAC64CODIGO, domicilio.FAC65CODEST,
                    domicilio.FAC65DESEST, domicilio.FAC65CODTIPEST, domicilio.FAC65DIRECCION,
                    out @msgretorno);
        }
        public void EliminarDomicilioDestino(string @FAC65CODEMP, string @FAC64CODIGO, string @FAC65CODEST) {
            Accessor.EliminarDomicilioDestino(@FAC65CODEMP, @FAC64CODIGO, @FAC65CODEST);
        }
        #region Accessor

        private static DomicilioDestinoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DomicilioDestinoAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
