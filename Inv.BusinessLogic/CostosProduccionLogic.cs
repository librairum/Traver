using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class CostosProduccionLogic
    {
        #region Singleton
        private static volatile CostosProduccionLogic instance;
        private static object syncRoot = new Object();
        private CostosProduccionLogic() { }
        public static CostosProduccionLogic Instance
        {
            get
            {
                if (instance == null)
                {

                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CostosProduccionLogic();
                    }
                }
                return instance;
            }
        }
        #endregion
        public void InsertarImportacion(CostosProduccion entidad,
            out string @msgretorno, out int @flag)
        {
            @msgretorno = string.Empty;
            Accessor.Spu_Cos_Ins_CostosProduccionImportacion(entidad.COS01CODEMP, entidad.COS01ANIO, entidad.COS01MES,
                entidad.COS01CONTGASMOVANO, entidad.COS01CONTGASMOVMES, entidad.COS01CONTGASMOVSUBD,
                entidad.COS01CONTGASMOVNUMER, entidad.COS01CONTGASMOVORD, entidad.COS01CTACBLECOD,
                entidad.COS01CTACBLEDESC, entidad.COS01TIPOCOSTOCOD, entidad.COS01TIPOCOSTODESC,
                entidad.COS01COSTOCOD, entidad.COS01COSTODESC, entidad.COS01IMPORTE,
                entidad.COS01FIJOOVARIABLE, entidad.COS01DIRECTOOINDIRECTO, entidad.COS01FLAG,
                entidad.COS01ERRORES, entidad.COS01CANTERRORES, entidad.COS01CODIGOUSUARIO,
                entidad.COS01SISTEMA, out @msgretorno, out @flag);

        }
        public void InsertarCostosProduccion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
                                                string @COS01CODIGOUSUARIO, string @COS01SISTEMA,
                                             out string @mensaje, out int @flag)
        {
            Accessor.Spu_Cos_Ins_CostosProduccion(@COS01CODEMP, @COS01ANIO, @COS01MES,
                                            @COS01CODIGOUSUARIO, @COS01SISTEMA, out @mensaje, out @flag);
        }
        public void EliminarCostosProduccion(CostosProduccion entidad, out string @msgretorno)
        {
            @msgretorno = string.Empty;

            Accessor.Spu_Cos_Del_CostosProduccion(entidad.COS01CODEMP, entidad.COS01ANIO,
                entidad.COS01MES, out @msgretorno);
        }

        public void EliminarImportacion(string @COS01CODEMP, string @USUARIO, out string @msgretorno)
        {
            @msgretorno = string.Empty;
            Accessor.Spu_Cos_Del_CostosProduccionImportacion(@COS01CODEMP, @USUARIO, out @msgretorno);
        }
        public List<CostosProduccion> TraerImportacion(string @COS01CODEMP, string @USUARIO)
        {
            return Accessor.Spu_Cos_Traer_CostosProduccionImportar(@COS01CODEMP, @USUARIO);
        }
        public List<CostosProduccion> TraerCostosPrd(string @Empresa, string @Anio, string @Mes)
        {
            return Accessor.Spu_Cos_Traer_CostosProduccionxEmpresa(@Empresa, @Anio, @Mes);
        }

        #region Accessor
        private static CostosProduccionAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return CostosProduccionAccessor.CreateInstance();
            }
        }
        #endregion
    }
}
