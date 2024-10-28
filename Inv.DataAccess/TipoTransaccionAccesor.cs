using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class TipoTransaccionAccesor : AccessorBase<TipoTransaccionAccesor>
    {
        [SprocName("sp_Inv_Help_Transaccion")]
        public abstract List<TipoTransaccion> TraerTipoTransaccion(string @cCodEmp, string @cCampo, string @cFiltro);

        [SprocName("sp_Inv_Trae_Transaccion")]
        public abstract List<TipoTransaccion> TraerTipoTransaccion1(string @cCodEmp, string @cOrden, string @cFiltro);

    }
}
