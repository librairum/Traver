using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    

    public class ActividadesContableLogic
    {
        #region Singleton
        private static volatile ActividadesContableLogic instance;
        private static object syncRoot = new Object();
        private ActividadesContableLogic() { }
        public static ActividadesContableLogic Instance 
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) 
                    {
                        if (instance == null)
                            instance = new ActividadesContableLogic();
                    }
                }
                return instance;
            }
        }
        #endregion
        public  List<ActividadesContable> TraerActividadesContables(string @COS01CODEMP ) 
        {
            return Accessor.TraerActividadesContables(@COS01CODEMP);
        }
        public List<ActividadesContable> TraerActCtblxTipo(string @COS01CODEMP, string @COS01CODTIPO)
        {
            return Accessor.TraerActCtblxTipo(@COS01CODEMP, @COS01CODTIPO);
        }
        public void TraerCodigoCorrelativo(string @COS01CODEMP, out string @COS01CODIGO) {
            Accessor.TraerCodigoCorrelativo(@COS01CODEMP, out @COS01CODIGO);
        }
        public void InsertarActividadContable(ActividadesContable ActiConta, out string @msgretorno, out int @flag) 
        {
            Accessor.InsertarActividadContable(ActiConta.COS01CODEMP, ActiConta.COS01CODIGO, ActiConta.COS01DESCRIPCION, ActiConta.COS01CODTIPO, 
                                                ActiConta.COS01CTACBLE, out @msgretorno, out @flag);
        }

        public void ActualizarActividadContable(ActividadesContable ActiConta, out string @msgretorno, out int @flag) 
        {
            Accessor.ActualizarActividadContable(ActiConta.COS01CODEMP, ActiConta.COS01CODIGO, ActiConta.COS01DESCRIPCION, ActiConta.COS01CODTIPO,
                                                 ActiConta.COS01CTACBLE, out @msgretorno, out @flag);
        }
        public void EliminarActividadContable(ActividadesContable ActiConta, out string @msgretorno, out int @flag)
        {
            Accessor.EliminarActividadContable(ActiConta.COS01CODEMP, ActiConta.COS01CODIGO, ActiConta.COS01CODTIPO, out @msgretorno, out @flag);
        }
        public List<ActividadesContable> TraerActividadesContablexTipo(string @Empresa, string @ActContTipo)
        {
            return Accessor.TraerActividadesContablexTipo(@Empresa, @ActContTipo);
        }

        
        #region Accessor
            private static ActividadesContableAccesor Accessor
            {
                [System.Diagnostics.DebuggerStepThrough]
                get { return ActividadesContableAccesor.CreateInstance(); }
            }
        #endregion
    }
}
