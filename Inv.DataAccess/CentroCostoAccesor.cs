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
    public abstract class CentroCostoAccesor : AccessorBase<CentroCostoAccesor>
    {
        [SprocName("sp_Inv_Help_Centro_Costo")]
        public abstract List<CentroCosto> TraerCentroCosto(string @cCodEmp, string @cCampo, 
                                                            string @cFiltro, string @cAnio);

        [SprocName("Spu_Com_Trae_CentroCosto")]
        public abstract List<CentroCosto> TraeCentroCostoCompras(string @cCodEmp, string @anio);

        //crud centro costo

        [SprocName("sp_Inv_Del_Centro_Costo")]
        public abstract string EliminarCentroCosto(string @cCodemp, string @cCodigo, out string @cMsgRetorno);

        [SprocName("sp_Inv_Ins_Centro_Costo")]
        public abstract string InsertarCentroCosto(string @cCodemp, string @cCodigo, string @ccb02aa, string @cDescripcion, out string @cMsgRetorno);

        [SprocName("sp_Inv_Upd_Centro_Costo")]
        public abstract string ActualizarCentroCosto(string @cCodemp, string @cCodigo, string @cDescripcion, out string @cMsgRetorno);

        [SprocName("Sp_Inv_Rep_DetCentroCosto")]
        public abstract DataTable TraerReporte_DetCentroCosto(string @cCodEmp, string @XMLrango  , string @cAno, string @cMes, string @dFecini, string @dFecFin, string @cTI, string @cMoneda);

        [SprocName("sp_Inv_Ins_Rango_Impresion")]
        public abstract DataTable Ins_RangoImpresion(string @cEmpresa, string @cUsuario, string @cProceso, string @cValor, out string @cMsgRetorno);

    
    }
}
