using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
namespace Inv.BusinessLogic
{
    public class PuntoVentaLogic
    {

         #region Singleton
        private static volatile PuntoVentaLogic instance;
        private static object syncRoot = new Object();

        private PuntoVentaLogic() { }

        public static PuntoVentaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PuntoVentaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public void InsertarPuntoDeVenta(string @FAC55CODEMP, string @FAC55COD, string @FAC55DESC,
            out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_FAC55_PuntoVenta(@FAC55CODEMP, @FAC55COD,
                @FAC55DESC, out @flag, out @msgretorno);
        }


        public void ActualizarPuntoDeVenta(string @FAC55CODEMP, string @FAC55COD, string  @FAC55DESC, 
            out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_FAC55_PuntoVenta(@FAC55CODEMP, @FAC55COD,
                @FAC55DESC, out @flag, out @msgretorno);
        }


        public List<PuntoVenta> TraePuntosDeVenta(string @FAC55CODEMP,
        string @campo, string @Filtro)
        {
           return  Accessor.Spu_Fact_Trae_FAC55_PuntoVenta(@FAC55CODEMP, @campo, @Filtro);
        }
        public  void EliminarPuntoDeVenta(string @FAC55CODEMP, string @FAC55COD,
        out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Del_FAC55_PuntoVenta(@FAC55CODEMP, @FAC55COD,
             out @flag, out @msgretorno);
        }
        #region Accessor
        private static PuntoVentaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PuntoVentaAccesor.CreateInstance(); }
        }
        #endregion Accessor

    }
}
