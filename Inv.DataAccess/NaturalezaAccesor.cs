using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace Inv.DataAccess
{
    public abstract class NaturalezaAccesor : AccessorBase<NaturalezaAccesor>
    {
        /*
         Spu_Inv_Trae_ProductoNaturaleza
         */
        [SprocName("Spu_Inv_Trae_ProductoNaturaleza")]
        public abstract List<Naturaleza> TraerNaturaleza(string @cFiltro);

    }
}
