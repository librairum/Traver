using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Inv.BusinessEntities;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;

namespace Inv.DataAccess
{
    public abstract class InventarioOrdenCompraAccesor : AccessorBase<InventarioOrdenCompraAccesor>
    {
        [SprocName("sp_Inv_Help_Orden_Compra")]
        public abstract List<DodcumentoOrdenCompra> TraeOrdenCompra(string @cCodEmp,string @cAno,string @cMes,
        string @cTipo,string @cTipAna,string @cCampo,string @cFiltro);

    }
}
