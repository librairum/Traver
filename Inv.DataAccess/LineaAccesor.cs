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
    public abstract class LineaAccesor : AccessorBase<LineaAccesor>
    {
        [SprocName("Spu_Pro_Ins_PRO08LINEA")]
        public abstract void Spu_Pro_Ins_PRO08LINEA(string @PRO08CODEMP, string @PRO08COD, string @PRO08DESC,
                                                    out string @msgretorno);
        [SprocName("Spu_Pro_Upd_PRO08LINEA")]
        public abstract void Spu_Pro_Upd_PRO08LINEA(string @PRO08CODEMP, string @PRO08COD, string @PRO08DESC, 
                                                     out string @msgretorno);
        [SprocName("Spu_Pro_Del_PRO08LINEA")]
        public abstract void Spu_Pro_Del_PRO08LINEA(string @PRO08CODEMP, string @PRO08COD, out string @msgretorno);

        [SprocName("Spu_Pro_trae_PRO08LINEA")]
        public abstract List<Linea> Spu_Pro_Trae_PRO08LINEA(string @PRO08CODEMP);

        [SprocName("Spu_Pro_Trae_CodigoLinea")]
        public abstract void Spu_Pro_Trae_CodigoLinea(string @codigoEmpresa, out string @codigo);

        [SprocName("Spu_Pro_Traer_LineaRegistro")]
        public abstract Linea Spu_Pro_Traer_LineaRegistro(string @codigoEmpresa,  string @codigo);
        
        [SprocName("sp_Pro_Help_Linea")]
        public abstract List<Linea> sp_Pro_Help_Linea(string @cCodEmp, string @cCampo, string @cFiltro);

        [SprocName("Spu_Pro_Trae_LineasMasTodos")]
        public abstract List<Linea> Spu_Pro_Trae_LineasMasTodos(string @PRO08CODEMP);

        [SprocName("Spu_Pro_Traer_OTxLinea")]
        public abstract List<Spu_Pro_Traer_OTxLinea> Spu_Pro_Traer_OTxLinea(string @PRO13CODEMP, string @PRO13AA, 
            string @fechaIni, string @fechaFin, string @PRO13LINEACOD );
    }
}
