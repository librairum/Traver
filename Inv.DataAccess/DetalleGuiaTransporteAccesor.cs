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
    public abstract class DetalleGuiaTransporteAccesor:AccessorBase<DetalleGuiaTransporteAccesor>
    {
        [SprocName("Spu_Fact_Trae_FAC35_DETGUIAXGUIA")]

        public abstract List<DetalleGuiaTransporte>  Spu_Fact_Trae_FAC35_DETGUIAXGUIA(string @FAC35CODEMP, string @FAC01COD, string @FAC34NROGUIA);

    }
}
