using System;
using System.Collections;
using System.Collections.Generic;
using Inv.BusinessEntities;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System.Data;

namespace Inv.DataAccess
{
    public abstract class ServiciosCompraAccesor : AccessorBase<ServiciosCompraAccesor>
    {
        [SprocName("Spu_Com_Help_UnidadMedida")]
        public abstract List<UnidaddeMedida> TraeAyudaUnidadMedida(string @cCodEmp);

        [SprocName("Spu_Com_Help_CuentasSoloMov")]
        public abstract List<CuentaContable> TraeAyudaCuentasSoloMov( string @cEmpresa,  string @ccm01aa );


        [SprocName("Spu_Com_Trae_Servicios")]
        public abstract List<ServiciosCompras> TraeServicios(string @cCodEmp);

        [SprocName("Spu_Com_Del_Servicios")]
        public abstract void EliminarServicios(string @cCodEmp, string @cCodigo, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Ins_Servicios")]
        public abstract void InsertarServicios(string @cCodEmp, string @cCodigo, string @cDescripcion, string @cUnidad,
                                                string @cCuenta, out int @flag, out string @cMsgRetorno);

        [SprocName("Spu_Com_Upd_Servicios")]
        public abstract void ActualizarServicios(string @cCodemp, string @cCodigo, string @cDescripcion, string @cUnidad, 
        string @cCuenta, out int @flag,out string @cMsgRetorno);


        #region "Reporte"
        [SprocName("Spu_Com_Trae_Servicios")]
        public abstract DataTable TraeReporteServicios(string @cCodEmp);

        #endregion
    }
}
