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
    public abstract class ProvisionamientoAccesor : AccessorBase<ProvisionamientoAccesor>
    {
        [SprocName("Spu_Com_Trae_Provisionamientos")]
        public abstract List<ProvisionamientoOrdenCompra> Spu_Com_Trae_Provisionamientos(string @cCodemp,string @cFecIni,string @cFecFin,
        string @cTipAna,string @cTipOrden);


        [SprocName("Spu_Com_Trae_ConsultaFacturaxOrdenCompra")]
        public abstract List<ProvisionamientoConsulta> Spu_Com_Trae_ConsultaFacturaxOrdenCompra(string @cCodemp, string @cAno, string @cTipAna, string @cTipo, 
        string @cFecIni,string @cFecFin);


        [SprocName("Spu_Com_Trae_ProvisionamientosDetalle")]
        public abstract List<ProvisionamientoOrdenCompraDetalle> Spu_Com_Trae_ProvisionamientosDetalle(string @cEmpresa, string @cAno, string @cMes, 
        string @cTipoOrd,string @cCodigoOrd,string @CO05ANOORDCOM,string @CO05MESORDCOM);


    }
}
