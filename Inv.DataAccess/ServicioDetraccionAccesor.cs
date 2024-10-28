using System;
using System.Collections;
using System.Collections.Generic;
using Inv.BusinessEntities;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System.Data;

namespace Inv.DataAccess
{
    public abstract class ServicioDetraccionAccesor : AccessorBase<ServicioDetraccionAccesor>
    {
        [SprocName("Spu_Com_Trae_AyudaServiciodetraccion")]
        public abstract List<ServicioDetraccion> TraeAyuda(string @cCampo,string @cFiltro,string @facturafecha);
    }
}
