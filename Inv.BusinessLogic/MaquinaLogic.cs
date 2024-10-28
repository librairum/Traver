using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class MaquinaLogic
    {
       #region Singleton
       private static volatile MaquinaLogic instance;
        private static object syncRoot = new Object();

        private MaquinaLogic() { }

        public static MaquinaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new MaquinaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public void MaquinaInsertar(Maquina maquina, out string @msgretorno) 
        {
            Accessor.Spu_Pro_Ins_PRO11MAQUINA(maquina.codigoEmpresa, maquina.codigo, maquina.descripcion, maquina.actrelacionada,out @msgretorno);
        }
        public void MaquinaActualizar(Maquina maquina, out string @msgretorno) {
            Accessor.Spu_Pro_Upd_PRO11MAQUINA(maquina.codigoEmpresa, maquina.codigo, maquina.descripcion, maquina.actrelacionada, out @msgretorno);
        }
        public void MaquinaEliminar(Maquina maquina, out string @msgretorno) {
           Accessor.Spu_Pro_Del_PRO11MAQUINA(maquina.codigoEmpresa,maquina.codigo, out @msgretorno);
        }

        public List<Maquina> MaquinaTraer(string @PRO11CODEMP) 
        {
            return Accessor.Spu_Pro_Trae_PRO11MAQUINA(@PRO11CODEMP);
        }

        public void MaquinaTraerCodigo(string @codigoEmpresa, out string @codigo) {
            Accessor.Spu_Pro_Trae_CodigoMaquina(@codigoEmpresa, out @codigo);
        }
        public Maquina TraerMaquinaRegistro(string codigoEmpresa, string codigo) {
            return Accessor.Spu_Pro_Trae_PRO11MAQUINARegistro(codigoEmpresa, codigo);
        }
        public List<Maquina> TraerMaquinaxLineaActividad(string @PRO11CODEMP, string @PRO11ACTIVIDADREL) {
            return Accessor.Spu_Pro_Trae_MaquinaxLineaActividad(@PRO11CODEMP, @PRO11ACTIVIDADREL);
        }

        #region"Inventario"
        public List<MaquinaInventario> TraeMaquinaInventario(string @cCodEmp, string @cCampo, string @cFiltro)
        { 
            return Accessor.TraeMaquinaInventario(@cCodEmp, @cCampo, @cFiltro);
        }
        #endregion

        #region Accessor

        private static MaquinaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MaquinaAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
