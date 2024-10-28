using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ErroresComunesLogic
    {
        #region Singleton
        private static volatile ErroresComunesLogic instance;
        private static object syncRoot = new Object();
        private ErroresComunesLogic()
        { 
            
        }
        public static ErroresComunesLogic Instance
        {
            get {

                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ErroresComunesLogic();
                    }
                }
                return instance;
            }
        }
        #endregion
        public List<ErroresComunes> TraerErroresDetalle( string @PRO11DETCODEMP, string @PRO11DETAA,
                                                    string @PRO11DETMM, string @PRO11DETTIPDOC,
                                                    string @PRO11DETCODDOC, string @PRO11DETKEY,
                                                    double @PRO11DETORDEN)
        {
            return Accessor.Spu_Pro_Trae_ErroresComunesDetalle( @PRO11DETCODEMP, @PRO11DETAA,
                                                    @PRO11DETMM, @PRO11DETTIPDOC,
                                                    @PRO11DETCODDOC, @PRO11DETKEY,
                                                    @PRO11DETORDEN);
        }

        public void InsertarErroresDetalle(ErroresComunesDetalle entidad, string @XmlRango ,out string @mensaje)
        {
            Accessor.Spu_Pro_Ins_ErroresComunesDetalle(entidad.PRO11CODEMP, entidad.PRO11DETCODEMP, entidad.PRO11DETAA,
                entidad.PRO11DETMM, entidad.PRO11DETTIPDOC, entidad.PRO11DETCODDOC, entidad.PRO11DETKEY,
                entidad.PRO11DETORDEN, @XmlRango, out @mensaje);
        }

        public void InsertarErroresComunes(ErroresComunes entidad,
                                               out string @mensaje, out int @flag)
        { 
            
            Accessor.Spu_Pro_Ins_ErroresComunes(entidad.PRO10CODEMP, entidad.PRO10CODIGO, 
                                                entidad.PRO10DESCRIPCION,  entidad.PRO10ESTADO, 
                                                out @mensaje, out @flag);
        }

        public void ActualizarErroresComunes(ErroresComunes entidad, 
                                               out string @mensaje, out int @flag)
        {
            Accessor.Spu_Pro_Upd_ErroresComunes(entidad.PRO10CODEMP, entidad.PRO10CODIGO, 
                                                entidad.PRO10DESCRIPCION, entidad.PRO10ESTADO, 
                                                out @mensaje, out @flag);
        }

        public void EliminarErroresComunes(string @PRO10CODEMP, string @PRO10CODIGO,
                                               out string @mensaje, out int @flag)
        { 
            Accessor.Spu_Pro_Del_ErroresComunes(@PRO10CODEMP, @PRO10CODIGO,
                                                out @mensaje, out @flag);
        }
        
        public List<ErroresComunes> ListarErroresTodos(string @PRO10CODEMP,
                                                               string @PRO10CODIGO, string @FILTRO)
        {
            return Accessor.Spu_Pro_Traer_ErrroresDetalleTodos(@PRO10CODEMP, @PRO10CODIGO, @FILTRO);
        }
        public void TraerCodigoNuevo(string @PRO10CODEMP, out string @PRO10CODIGO)
        {
            Accessor.Spu_Pro_Trae_ErroresComunesCodigo(@PRO10CODEMP, out @PRO10CODIGO);
        }
        #region "Reporte"
        public DataTable TraerReporteErroresComununes(string @Empresa, string @Anio,
                           string @flag, string @fecIni, string @fecFin, string @XmlRango)
        { 
            return Accessor.Spu_Pro_Rep_ErroresComunesxOperador(@Empresa, @Anio, @flag, @fecIni, 
                    @fecFin, @XmlRango);
        }
        #endregion
        #region Accessor
        private static ErroresComunesAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ErroresComunesAccesor.CreateInstance(); }
        }
        #endregion
    }
}
