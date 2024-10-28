using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class FormaPagoLogic
    {
        #region Singleton
        private static volatile FormaPagoLogic instance;
        private static object syncRoot = new Object();
        private FormaPagoLogic() { }
        public static FormaPagoLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FormaPagoLogic();
                    }
                }
                return instance;
            }
        }
    
        #endregion
        public  void InsertarFormaPago(string @FAC53COD, string @FAC53DESC,
              string @FAC53DESCEEUU, int @FAC53DIAS, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_FAC53_FORMAPAGO(@FAC53COD, @FAC53DESC, @FAC53DESCEEUU,
                @FAC53DIAS, out @flag, out @msgretorno);
        }



        public void ActualizarFormaPago(string @FAC53COD, string @FAC53DESC,
        string @FAC53DESCEEUU, int @FAC53DIAS, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_FAC53_FORMAPAGO(@FAC53COD, @FAC53DESC, @FAC53DESCEEUU, 
                                                 @FAC53DIAS, out @flag, out @msgretorno);
        }


        public List<FormaPago> TraeFormaPagos(string @campo, string @filtro)
        {
            return Accessor.Spu_Fact_Trae_FAC53_FORMAPAGO(@campo, @filtro);
        }


        public void EliminarFormaPago(string @FAC53COD, out int @flag,
        out string @msgretorno)
        { 
            Accessor.Spu_Fact_Del_FAC53_FORMAPAGO(@FAC53COD, out @flag,
                                                        out @msgretorno);
        }
        public List<FormaPago> TraeHelpFormaPago(string @Co02Codemp, string @cOrden, string @cFiltro)
        {
            return Accessor.Spu_Fact_Help_FormaPago(@Co02Codemp, @cOrden, @cFiltro);
        }
        public List<FormaPago> TraeFormaPagoCompras(string @cCdoEmp)
        {
            return Accessor.Spu_Com_Trae_FormaPago(@cCdoEmp);
        }
        
        #region Accessor
        private static FormaPagoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return FormaPagoAccesor.CreateInstance(); }
        }
        #endregion 
    }
}
