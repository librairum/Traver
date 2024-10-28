using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ContabilidadGastosLogic
    {
        #region Singleton
        private static volatile ContabilidadGastosLogic instance;
        private static object syncRoot = new Object();
        private ContabilidadGastosLogic() { }
        public static ContabilidadGastosLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ContabilidadGastosLogic();
                    }

                }
                return instance;
            }
        }
        #endregion

        public void InsertarGastosContabilidadImp(GastosContabilidad gastosconta, out string @msgretorno)
        {
            Accessor.InsertarGastosContabilidadImp(gastosconta.COS01CODEMP, gastosconta.COS01ANIO, gastosconta.COS01MES,
            gastosconta.COS01LINEA, gastosconta.COS01LOTE, gastosconta.COS01CONTGASMOVANO, gastosconta.COS01CONTGASMOVMES,
            gastosconta.COS01CONTGASMOVSUBD, gastosconta.COS01CONTGASMOVNUMER, gastosconta.COS01CONTGASMOVORD,
            gastosconta.COS01CTACBLECOD, gastosconta.COS01CTACBLEDESC, gastosconta.COS01TIPOCOSTOCOD,
            gastosconta.COS01TIPOCOSTODESC, gastosconta.COS01COSTOCOD, gastosconta.COS01COSTODESC, gastosconta.COS01IMPORTE,
            gastosconta.COS01FIJOOVARIABLE, gastosconta.COS01DIRECTOOINDIRECTO,
             gastosconta.COS01CODIGOUSUARIO,
            gastosconta.COS01SISTEMA, out @msgretorno);
        }
        public void EliminarGastosContabilidadImp(string @COS01CODEMP, string @usuario, out string @msgretorno)
        {
            Accessor.EliminarGastosContabilidadImp(@COS01CODEMP, @usuario, out @msgretorno);
        }
        public List<GastosContabilidad> TraerGastosContabilidadImp(string @Empresa, string @Anio, string @Mes, string @Linea,
                                                                           string @Lote, string @Usuario, string @Sistema)
        {
            return Accessor.TraerGastosContabilidadImp(@Empresa, @Anio, @Mes, @Linea, @Lote, @Usuario, @Sistema);
        }
        public void EliminarContabilidadGastos(string @Empresa, string @Anio, string @Mes,
                                                string @Linea, string @Lote, out string @msgretorno, out int @flag)
        {
            Accessor.EliminarContabilidadGastos(@Empresa, @Anio, @Mes, @Linea, @Lote, out @msgretorno, out @flag);
        }
        public void InsertarContabilidadGastos(string @Empresa, string @Anio, string @Mes, string @Linea,
        string @Lote, string @Codigousuario, string @Sistema, out string @msgretorno, out int @flag)
        {
            Accessor.InsertarContabilidadGastos(@Empresa, @Anio, @Mes, @Linea, @Lote, @Codigousuario, @Sistema,
                                                out @msgretorno, out @flag);
        }
        public List<GastosContabilidad> TraerContabilidadGastos(string @Empresa, string @Anio, string @Mes,
                                                     string @Linea, string @Lote)
        {
            return Accessor.TraerContabilidadGastos(@Empresa, @Anio, @Mes, @Linea, @Lote);
        }
        
        public void CalcularCostos(string @COS03CODEMP, string @COS03ANIO, string @COS03MES,string @COS03LINEA, string @CO03LOTE, string @MSGRETORNO)
        {
            Accessor.Spu_Cos_Cal_Costos(@COS03CODEMP, @COS03ANIO, @COS03MES, @COS03LINEA,@CO03LOTE, @MSGRETORNO);
        }

        public void ActualizaCostoPP(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, string @COS01LINEA, string @COS01LOTE, out string @MSGRETORNO, out int @flag)
        {
            Accessor.Spu_Cos_Upd_CostoMovPP(@COS01CODEMP, @COS01ANIO, @COS01MES, @COS01LINEA, @COS01LOTE, out @MSGRETORNO,out @flag);
        }

        public void ActualizaCostoPT(string @IN07CODEMP, string @IN07AA, string @IN07MM, out string @MSGRETORNO, out int @flag)
        {
            Accessor.Spu_Cos_Upd_CPdePT(@IN07CODEMP, @IN07AA, @IN07MM, out @MSGRETORNO,out @flag);
        }

        public void InsercionDirectoGastosContables(string COS01CODEMP, string COS01ANIO, string COS01MES,string COS01LINEA, string COS01LOTE)
        {
            Accessor.Spu_Cos_Ins_GastosContables(COS01CODEMP, COS01ANIO, COS01MES,COS01LINEA, COS01LOTE);
        }

        #region Accessor
        private static ContabilidadGastosAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return ContabilidadGastosAccesor.CreateInstance();
            }
        }
        #endregion Accessor
    }
}