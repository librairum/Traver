using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using System.Data;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ErroresComunesAccesor : AccessorBase<ErroresComunesAccesor>
    {
        [SprocName("Spu_Pro_Ins_ErroresComunesDetalle")]
        public abstract void Spu_Pro_Ins_ErroresComunesDetalle(string @PRO11CODEMP,
                                        string @PRO11DETCODEMP, string @PRO11DETAA,
                                        string @PRO11DETMM, string @PRO11DETTIPDOC, 
                                    string @PRO11DETCODDOC,  string @PRO11DETKEY,
                                    double @PRO11DETORDEN, string @XMLrango, out string @mensaje);
        
        [SprocName("Spu_Pro_Trae_ErroresComunesDetalle")]
        public abstract List<ErroresComunes> Spu_Pro_Trae_ErroresComunesDetalle(
                                                    string @PRO11DETCODEMP,string @PRO11DETAA, 
                                                    string @PRO11DETMM, string @PRO11DETTIPDOC, 
                                                    string @PRO11DETCODDOC, string @PRO11DETKEY, 
                                                    double @PRO11DETORDEN);
        
        //Mantenimiento de errores comunes
        [SprocName("Spu_Pro_Ins_ErroresComunes")]
        public abstract void Spu_Pro_Ins_ErroresComunes(string @PRO10CODEMP, string @PRO10CODIGO, 
                                                    string @PRO10DESCRIPCION, string @PRO10ESTADO, 
                                                                out string @mensaje, out int @flag);
        [SprocName("Spu_Pro_Upd_ErroresComunes")]
        public abstract void Spu_Pro_Upd_ErroresComunes(string @PRO10CODEMP, string @PRO10CODIGO, 
                                                    string @PRO10DESCRIPCION, string @PRO10ESTADO, 
                                                                out string @mensaje, out int @flag);
        [SprocName("Spu_Pro_Del_ErroresComunes")]
        public abstract void Spu_Pro_Del_ErroresComunes(string @PRO10CODEMP, string @PRO10CODIGO, 
                                                                out string @mensaje, out int @flag);
        [SprocName("Spu_Pro_Traer_ErrroresDetalleTodos")]
        public abstract List<ErroresComunes> Spu_Pro_Traer_ErrroresDetalleTodos(string @PRO10CODEMP, 
                                                                string @PRO10CODIGO, string @FILTRO);
        [SprocName("Spu_Pro_Trae_ErroresComunesCodigo")]
        public abstract void Spu_Pro_Trae_ErroresComunesCodigo(string @PRO10CODEMP, out string @PRO10CODIGO);
        #region "Reporte"
        [SprocName("Spu_Pro_Rep_ErroresComunesxOperador")]
        public abstract DataTable Spu_Pro_Rep_ErroresComunesxOperador(string @Empresa, string @Anio,
                                string @flag, string @fecIni, string @fecFin, string @XmlRango);
        #endregion
    }
}
