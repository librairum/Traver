using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class FuncionesLogic
    {
        #region Singleton
        private static volatile FuncionesLogic instance;
        private static object sycnRoot = new Object();
        private FuncionesLogic(){}
        public static FuncionesLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (sycnRoot)
                    {
                        if (instance == null)
                            instance = new FuncionesLogic();
                    }
                }
                return instance;
            }
        }
        #endregion
        #region PrincipalesMetodos
        #endregion
        #region Accessor
        //private static FuncionesAccessor Accessor
        //{
            
        //}
        //[System.Diagnostics.DebuggerStepThrough]
        //get{ return FuncionesAccessor.c }
        #endregion

        //        public  List<???> TraerFunciones (
// string @Empresa,
// string @CodigoModulo)
//{
//Accessor.Spu_Pro_Trae_funciones(
//@Empresa,
//@CodigoModulo); }

    }
}
