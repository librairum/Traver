using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class ProductoCaracteristicasLogic
    {
        #region Singleton
        private static volatile ProductoCaracteristicasLogic instance;
        private static object syncRoot = new Object();

        private ProductoCaracteristicasLogic() { }

        public static ProductoCaracteristicasLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ProductoCaracteristicasLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region Accessor
        private static ProductoCaracteristicasAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ProductoCaracteristicasAccesor.CreateInstance(); }

        }
        #endregion Accessor

        public List<ProductoCaracteristicas> TraeCaracteristicas(string @cCampo, string @cFiltro)
        {
            return Accessor.Spu_Glo_Trae_GLO01PRODUCTOS(@cCampo, @cFiltro);
        }


        public List<ProductoCaracteristicas> TraerDetCaracteristica(string @glo01codigotabla, string @cCampo, string @cFiltro)
        { 
            return Accessor.Spu_Glo_Trae_GLO01PRODUCTOS_Det(@glo01codigotabla, @cCampo, @cFiltro);
        }

        public void InsertarCaracteristica(string @glo01codigotabla, string @glo01codigo, 
                        string @glo01descripcion, string @glo01texto1, string @glocomentario, 
                        out int @flag, out string @cMsgRetorno)
        {
            Accessor.Spu_Glo_Ins_GLO01PRODUCTOS(@glo01codigotabla, @glo01codigo, @glo01descripcion, 
                                        @glo01texto1, @glocomentario, out @flag, out @cMsgRetorno);
        }

        public void ActualizarCaracteristica(string @glo01codigotabla, string @glo01codigo, string @glo01descripcion,
        string @glo01texto1, string @glocomentario, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.Spu_Glo_Upd_GLO01PRODUCTOS(@glo01codigotabla, @glo01codigo, @glo01descripcion,
                    @glo01texto1, @glocomentario, out @flag, out @cMsgRetorno);
        }

        public void EliminarCaracteristica(string @glo01codigotabla, string @glo01codigo, out int @flag, out string @cMsgRetorno)
        { 
            Accessor.Spu_Glo_Del_GLO01PRODUCTOS(@glo01codigotabla, @glo01codigo, out @flag, out @cMsgRetorno);
        }
    }
}
