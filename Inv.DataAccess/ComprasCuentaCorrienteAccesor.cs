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
    public abstract class ComprasCuentaCorrienteAccesor : AccessorBase<ComprasCuentaCorrienteAccesor>
    {

        [SprocName("Spu_Com_Trae_CuentaCorriente")]
        public abstract List<CuentaCorriente> Spu_Com_Trae_CuentaCorriente(string @cCodEmp, string @cTipAnal, string @cTipoFiltro, string @cFiltro);

    }
}
