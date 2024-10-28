using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;
using System.Xml;

namespace Inv.DataAccess
{
    public abstract class PedidoVentaAccesor : AccessorBase<PedidoVentaAccesor>
    {
        [SprocName("Spu_Inv_Trae_PedVentaPend")]
        public abstract List<PedidoVentaCabecera> PedVentaPend(string @come01empresa);
    }
}
