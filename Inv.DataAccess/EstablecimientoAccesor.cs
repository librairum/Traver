using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class EstablecimientoAccesor:AccessorBase<EstablecimientoAccesor>
    {
        [SprocName("Spu_Fact_Trae_Establecimientos")]
        public abstract List<Establecimiento> TraerEstablecimiento(string @CodigoEmpresa, string @Campo, string @Filtro);

    }
}
