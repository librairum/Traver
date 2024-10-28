using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
  public  class ActividadNivel2Logic
    {
       #region Singleton
       private static volatile ActividadNivel2Logic instance;
        private static object syncRoot = new Object();

        private ActividadNivel2Logic() { }

        public static ActividadNivel2Logic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ActividadNivel2Logic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public void ActividadNivel2Insertar(ActividadNivel2 actividad, out string @msgretorno) {
            Accessor.Spu_Pro_Ins_PRO10ACTIVIDADNIVEL2(actividad.codigoEmpresa, actividad.codigoLinea, actividad.codigoActividad, 
                                                      actividad.codigo, actividad.descripcion, out @msgretorno);
        }

        public void ActividadNivel2Actualizar(ActividadNivel2 actividad, out string @msgretorno) {
            Accessor.Spu_Pro_Upd_PRO10ACTIVIDADNIVEL2(actividad.codigoEmpresa, actividad.codigoLinea, actividad.codigoActividad, actividad.codigo,
                actividad.descripcion, out @msgretorno);
        
        }

        public void ActividadNivel2Eliminar(ActividadNivel2 actividad, out string @msgretorno)
        {
            Accessor.Spu_Pro_Del_PRO10ACTIVIDADNIVEL2(actividad.codigoEmpresa, actividad.codigoLinea, actividad.codigoActividad, 
                actividad.codigo,out @msgretorno);
        }

        public List<ActividadNivel2> ActividadNivel2Traer(string @PRO10CODEMP) {
            return Accessor.Spu_Pro_Trae_PRO10ACTIVIDADNIVEL2(@PRO10CODEMP);
        }
        public void ActividdadNivel2TraeCodigo(string @codigoEmpresa, out string @codigo) {
            Accessor.Spu_Pro_Trae_CodigoActividadNivel2(@codigoEmpresa, out @codigo);
        }

        public ActividadNivel2 ActividadNivel2TraerRegistro(ActividadNivel2 actividad) {
            return Accessor.Spu_Pro_Trae_PRO10ACTIVIDADNIVEL2REGISTRO(actividad.codigoEmpresa, actividad.codigoLinea, actividad.codigoActividad, actividad.codigo);
        }

        #region Accessor

        private static ActividadNivel2Accesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ActividadNivel2Accesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
