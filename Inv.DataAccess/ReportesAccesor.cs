using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;

namespace Inv.DataAccess
{

    public abstract class ReportesAccesor : AccessorBase<ReportesAccesor>
    {
        [SprocName("sp_inv_verifica_stock_negativos")]
        public abstract DataTable Traer_StockNegativos(string @IN04CODEMP, string @IN04AA, string @IN04MM);

    }
}
