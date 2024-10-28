using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ReportesLogic
    {
        #region Singleton
        private static volatile ReportesLogic instance;
        private static object syncRoot = new Object();
        private ReportesLogic() { }
        public static ReportesLogic Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ReportesLogic();
                    }
                }
                return instance;
            }
        }
        #endregion

        public DataTable Traer_StockNegativos(string @IN04CODEMP, string @IN04AA, string @IN04MM)
        {
            return Accessor.Traer_StockNegativos(@IN04CODEMP, @IN04AA, @IN04MM);
        }


        #region Accessor
        private static ReportesAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ReportesAccesor.CreateInstance(); }
        }
        #endregion
    }
}
