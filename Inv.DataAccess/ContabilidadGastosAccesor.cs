using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class ContabilidadGastosAccesor : AccessorBase<ContabilidadGastosAccesor>
    {
        #region "Importacion"
        [SprocName("Spu_Cos_Ins_ContabilidadGastoImp")]
        public abstract void InsertarGastosContabilidadImp(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
            string @COS01LINEA, string @COS01LOTE, string @COS01CONTGASMOVANO, string @COS01CONTGASMOVMES,
            string @COS01CONTGASMOVSUBD, string @COS01CONTGASMOVNUMER,
            double @COS01CONTGASMOVORD, string @COS01CTACBLECOD, string @COS01CTACBLEDESC, string @COS01TIPOCOSTOCOD,
            string @COS01TIPOCOSTODESC, string @COS01COSTOCOD, string @COS01COSTODESC, double @COS01IMPORTE,
            string @COS01FIJOOVARIABLE, string @COS01DIRECTOOINDIRECTO,
            //string @COS01FLAG, string @COS01ERRORES, int @COS01CANTERRORES, 
            string @COS01CODIGOUSUARIO,
            string @COS01SISTEMA, out string @msgretorno);

        [SprocName("Spu_Inv_Del_ContabilidadGastoImp")]
        public abstract void EliminarGastosContabilidadImp(string @COS01CODEMP, string @usuario, out string @msgretorno);

        [SprocName("Spu_Cos_Traer_ContabilidadGastosImp")]
        public abstract List<GastosContabilidad> TraerGastosContabilidadImp(string @Empresa, string @Anio, string @Mes, string @Linea,
                                                string @Lote, string @Usuario, string @Sistema);

        [SprocName("Spu_Cos_Ins_GastosContables")]
        public abstract void Spu_Cos_Ins_GastosContables(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, string @COS01LINEA,
                                                         string @COS01LOTE);

        #endregion
        #region "Procesar Contabilidad Gastos"
        [SprocName("Spu_Cos_Del_ContabilidadGastos")]
        public abstract void EliminarContabilidadGastos(string @Empresa, string @Anio, string @Mes,
                                                string @Linea, string @Lote, out string @msgretorno, out int @flag);
        [SprocName("Spu_Cos_Ins_ContabilidadGastos")]
        public abstract void InsertarContabilidadGastos(string @Empresa, string @Anio, string @Mes,
                                string @Linea, string @Lote, string @Codigousuario, string @Sistema,
                                out string @msgretorno, out int @flag);
        
        [SprocName("Spu_Cos_Traer_ContabilidadGastos")]
        public abstract List<GastosContabilidad> TraerContabilidadGastos(string @Empresa, string @Anio, string @Mes,
                                                     string @Linea, string @Lote);

        [SprocName("Spu_Cos_Cal_Costos")]
        public abstract void Spu_Cos_Cal_Costos(string @COS03CODEMP, string @COS03ANIO,string @COS03MES, string @COS03LINEA, string @CO03LOTE, string @MSGRETORNO);
        #endregion

        #region "Traspasar costo Produccion"

        [SprocName("Spu_Cos_Upd_CostoMovPP")]
        public abstract void Spu_Cos_Upd_CostoMovPP(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, string @COS01LINEA, string @COS01LOTE, out string @MSGRETORNO, out int @flag);

        [SprocName("Spu_Cos_Upd_CPdePT")]
        public abstract void Spu_Cos_Upd_CPdePT(string @IN07CODEMP, string @IN07AA, string @IN07MM, out string @MSGRETORNO, out int @flag);

        #endregion
    }
}