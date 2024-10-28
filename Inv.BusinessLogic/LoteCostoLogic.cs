using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class LoteCostoLogic
    {
        #region Single

        private static volatile LoteCostoLogic instance;
        private static object syncRoot = new Object();
        private LoteCostoLogic() { }
        public static LoteCostoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LoteCostoLogic();
                    }
                }
                return instance;
            }

        }
        #endregion
        public List<LoteCosto> TraerLoteCostoxEmpresa(string @Empresa, string @Anio, string @Mes, string @Linea)
        {
            return Accessor.TraerLoteCostoxEmpresa(@Empresa, @Anio, @Mes, @Linea);
        }
        public LoteCosto TraerLoteCosto(LoteCosto lotecosto)
        {
            return Accessor.TraerLoteCosto(lotecosto.CodigoEmpresa, lotecosto.Anio, lotecosto.Mes, lotecosto.CodigoLinea, lotecosto.Codigo);
        }
        public void InsertarLoteCosto(LoteCosto lotecosto, out string @msgretorno, out int @flag)
        {
            Accessor.InsertarLoteCosto(lotecosto.CodigoEmpresa, lotecosto.Anio,
                            lotecosto.Mes, lotecosto.CodigoLinea, lotecosto.Codigo,
                            lotecosto.Descripcion, out @msgretorno, out @flag);

        }
        public void ActualizarLoteCosto(LoteCosto lotecosto, out string @msgretorno, out int @flag)
        {
            Accessor.ActualizarLoteCosto(lotecosto.CodigoEmpresa, lotecosto.Anio,
                            lotecosto.Mes, lotecosto.CodigoLinea, lotecosto.Codigo,
                            lotecosto.Descripcion, out @msgretorno, out @flag);
        }
        public void EliminarLoteCosto(LoteCosto lotecosto, out string @msgretorno, out int @flag)
        {
            Accessor.EliminarLoteCosto(lotecosto.CodigoEmpresa, lotecosto.Anio,
                            lotecosto.Mes, lotecosto.CodigoLinea, lotecosto.Codigo,
                             out @msgretorno, out @flag);

        }
        public void TraerCodigoGenerado(string @Empresa, string anio, string mes, out string @codigo)
        {
            Accessor.TraerCodigoGenerado(Empresa, anio, mes, out codigo);
        }
        #region "Accessor"
        private static LoteCostoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return LoteCostoAccesor.CreateInstance(); }
        }
        #endregion  Accessor
    }
}