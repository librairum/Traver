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
    public abstract class OptimizacionBloqueAccesor : AccessorBase<OptimizacionBloqueAccesor>
    {

        [SprocName("Spu_Pro_Trae_FormaOptimaCortarBloque")]
        public abstract List<Spu_Pro_Trae_FormaOptimaCortarBloque> Spu_Pro_Trae_FormaOptimaCortarBloque(string @empresa, Double @ProductoAncho, Double @ProductoLargo, Double @ProductoEspesor);

    }
}
