using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ProveedorAccesor: AccessorBase<ProveedorAccesor>
    {
        [SprocName("sp_Inv_Help_Proveedor")]
        public abstract List<Proveedor> TraerProveedor(string @cCodEmp, string @cTipAna, string @cCampo, string @cFiltro);


        [SprocName("Spu_Com_Trae_ProEmpVsProvSunat")]
        public abstract List<ProveedoresSunat> TraerProveedorSunat(string @cEmpresa, string @cAno, string @cMes, string @flag);

        [SprocName("Spu_Com_Trae_ValidacionSunat")]
        public abstract List<ProveedoresSunat> TraeValidacionSunat(string @cEmpresa, string @cod_actualizacion, string @cAno, 
        string @cMes,string @flag);
    }
}
