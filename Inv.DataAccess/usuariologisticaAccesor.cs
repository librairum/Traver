using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{

    public abstract class usuariologisticaAccesor : AccessorBase<usuariologisticaAccesor>
    {
       [SprocName("Spu_Com_Trae_UsuarioLogistica")]
       public abstract List<UsuarioLogistica> TraeAyudausuariologistica(string @cCodemp);
    }
}
