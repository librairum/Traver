using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{

    public abstract class ActividadContableTipoAccesor : AccessorBase<ActividadContableTipoAccesor>
    {
       [SprocName("Spu_Cos_trae_TipoActContable")]
       public abstract List<ActividadContableTipo> TraerTipoActividadContable();
    }
}
