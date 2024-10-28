using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class TipoVentaAccesor : AccessorBase<TipoVentaAccesor>
    {
        [SprocName("spu_Come_Help_Come02pedventatipo")]
        public abstract List<TipoPuntoVenta> TraerTipoVenta(string @come02empresa);
    }
}
