using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
   public  class ConciProdVsCtbleLogic
   {
       #region Singleton
       private static volatile ConciProdVsCtbleLogic instance;
       private static object syncRoot = new Object();
       private ConciProdVsCtbleLogic() { }
       public static ConciProdVsCtbleLogic Instance 
       {
           get 
           {
               if (instance == null) 
               {
                   lock (syncRoot) 
                   {
                       if (instance == null)
                           instance = new ConciProdVsCtbleLogic();
                   }
               }
               return instance;
           }
       }
       #endregion

       public List<ConciProdVsCtble> Traer(string @COS03CODEMP, string @COS03CODLINEAPRODUCCION)
       {
           return Accessor.TraerConciProdVsCtble(@COS03CODEMP, @COS03CODLINEAPRODUCCION);
       }

       public void Insertar(ConciProdVsCtble conciliacion, out string @msgretorno, out int @flag) 
       {
           Accessor.InsertarConciProdVsCtble(conciliacion.COS03CODEMP, conciliacion.COS03CODACTCONTABLE, 
                                           conciliacion.COS03CODLINEAPRODUCCION, conciliacion.COS03CODACTPRODUCCION, 
                                                out @msgretorno,out @flag);
       }

       public void Eliminar(ConciProdVsCtble conciliacion, out string @msgretorno, out int @flag) 
       {
           Accessor.EliminarConciProdVsCtble(conciliacion.COS03CODEMP, conciliacion.COS03CODACTCONTABLE, conciliacion.COS03CODLINEAPRODUCCION,
                                            conciliacion.COS03CODACTPRODUCCION, out @msgretorno, 
                                                out @flag); 
       }

       #region Accessor
       private static ConciProdVsCtbleAccesor Accessor
       {
           [System.Diagnostics.DebuggerStepThrough]
           get { return ConciProdVsCtbleAccesor.CreateInstance(); }
       }
       #endregion   
   }
}
