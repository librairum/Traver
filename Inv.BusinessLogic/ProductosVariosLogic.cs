using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
 

    public class ProductosVariosLogic
    {

        #region Singleton
            private static volatile ProductosVariosLogic instance;
            private static object syncRoot = new Object();
            private ProductosVariosLogic() { }
            public static ProductosVariosLogic Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (syncRoot)
                        {
                            if (instance == null)
                                instance = new ProductosVariosLogic();
                        }
                    }
                    return instance;
                }

            }
            #endregion

            
            public void Inserta(ProductosVarios productos, 
            out int flag, out string msgretorno)
            {
                Accessor.Spu_Fac_Ins_ProductosVarios(productos.FAC11CODEMP, 
                productos.FAC11PRODCOD, productos.FAC11PRODDESC, productos.FAC11PRODUNIMED, 
                productos.FAC11PRODCODSUNAT, out flag, out msgretorno);
            }
            public void Actualiza(ProductosVarios productos, out int flag, 
            out string msgretorno)
            {
                Accessor.Spu_Fac_Upd_ProductoVarios(productos.FAC11CODEMP, productos.FAC11PRODCOD,
                productos.FAC11PRODDESC, productos.FAC11PRODUNIMED, productos.FAC11PRODCODSUNAT, 
                out flag, out msgretorno);
            }

            public void Elimina(ProductosVarios productos, 
            out int flag, out string msgretorno)
            {
                Accessor.Spu_Fac_Del_ProductosVarios(productos.FAC11CODEMP,
                productos.FAC11PRODCOD, out flag, out msgretorno);
            }

            public List<ProductosVarios> Listar(string FAC11CODEMP)
            {
                return Accessor.Spu_Fac_Trae_ProductosVarios(FAC11CODEMP);
            }

            public void TraerNuevoCodigo(string FAC11CODEMP, out string CodigoNuevo)
            {
                Accessor.Spu_Fac_Trae_NuevoCodigoProductosVarios(FAC11CODEMP, out CodigoNuevo);
            }

        #region Accessor
        private static ProductosVariosAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ProductosVariosAccesor.CreateInstance(); }
         }   
        #endregion Accessor
    }
}
