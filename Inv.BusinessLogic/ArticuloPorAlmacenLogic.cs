using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class ArticuloPorAlmacenLogic
    {
         #region Singleton
        private static volatile ArticuloPorAlmacenLogic instance;
        private static object syncRoot = new Object();

        private ArticuloPorAlmacenLogic() { }

        public static ArticuloPorAlmacenLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ArticuloPorAlmacenLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
         #region Accessor

        private static ArticuloPorAlmacenAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ArticuloPorAlmacenAccesor.CreateInstance(); }
            
        }

        #endregion Accessor

        public void ArticuloPorAlmacenInsertar(ArticuloPorAlmacen articuloporalmacen,string @fechaini, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.ArticuloPorAlmacenInsertar(articuloporalmacen.IN04CODEMP, articuloporalmacen.IN04AA, articuloporalmacen.IN04KEY, articuloporalmacen.IN04CODALM, 
                articuloporalmacen.IN04UBICAC,
                articuloporalmacen.IN04STOMIN, articuloporalmacen.IN04STOSEG, articuloporalmacen.IN04STOMAX, articuloporalmacen.IN04STOREP, articuloporalmacen.IN04STOCK,
                articuloporalmacen.IN04PROMDOL, 0, articuloporalmacen.IN04PROMSOL,0,@fechaini, out @cMsgRetorno); 
        }

        public void ArticuloPorAlmacenModificar(ArticuloPorAlmacen articuloporalmacen,string @fechaini, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.ArticuloPorAlmacenModificar(articuloporalmacen.IN04CODEMP, articuloporalmacen.IN04AA, articuloporalmacen.IN04KEY, articuloporalmacen.IN04CODALM,
                articuloporalmacen.IN04UBICAC,
                articuloporalmacen.IN04STOMIN, articuloporalmacen.IN04STOSEG, articuloporalmacen.IN04STOMAX, articuloporalmacen.IN04STOREP, articuloporalmacen.IN04STOCK,
                articuloporalmacen.IN04PROMDOL, 0, articuloporalmacen.IN04PROMSOL, 0, @fechaini, out @cMsgRetorno);
        }

        public void ArticuloPorAlmacenEliminar(ArticuloPorAlmacen articuloporalmacen, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.ArticuloPorAlmacenEliminar(articuloporalmacen.IN04CODEMP, articuloporalmacen.IN04AA, articuloporalmacen.IN04KEY, articuloporalmacen.IN04CODALM, out @cMsgRetorno);
        }

        }
       
}
