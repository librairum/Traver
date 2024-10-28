using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class TipoDocumentoClienteAccesor : AccessorBase<TipoDocumentoClienteAccesor>
    {

        [SprocName("spu_Come_Help_come04PedVentaDocCliente")]
        public abstract List<TipoDocumentoCliente> TraerTipoDocumentoCliente(string @come04empresa);
    }
}
