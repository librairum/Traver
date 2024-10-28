using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class SeguridadAccesor : AccessorBase<SeguridadAccesor>
    {
        [SprocName("Spu_Seg_Trae_menuxperfil")]
       public List<SegMenuPorPerfil> Trae_menuxperfil(int @codigoPerfil);            
        
    }
}
