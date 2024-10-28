using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ObraAccesor: AccessorBase<ObraAccesor>
    {
        [SprocName("sp_Inv_Help_Obra")]
        public abstract List<Obra> TraerObra(string @cCodEmp, string @cCampo, string @cFiltro);
    }
}
