using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
namespace Inv.BusinessLogic
{
   public  class ActividadNivel1Logic
    {
        #region Singleton
       private static volatile ActividadNivel1Logic instance;
        private static object syncRoot = new Object();

        private ActividadNivel1Logic() { }

        public static ActividadNivel1Logic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ActividadNivel1Logic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public  void ActividadNivel1Insertar(ActividadNivel1 actividad, out string @msgretorno) { 
        Accessor.Spu_Pro_Ins_PRO09ACTIVIDADNIVEL1(actividad.codigoEmpresa, actividad.codigoLinea, actividad.codigo, actividad.descripcion,
                                                              actividad.codigoAlmacen, actividad.almacenMP, actividad.CodigoDocRespSalxDefecto,
                                                              actividad.CodigoTransaSalxDefecto ,out @msgretorno);
        }
        public  void ActividadNivel1Actualizar(ActividadNivel1 actividad, out string @msgretorno) { 
            Accessor.Spu_Pro_Upd_PRO09ACTIVIDADNIVEL1(actividad.codigoEmpresa, actividad.codigoLinea, actividad.codigo, actividad.descripcion,
                                                             actividad.codigoAlmacen, actividad.almacenMP, actividad.CodigoDocRespSalxDefecto,
                                                              actividad.CodigoTransaSalxDefecto, out @msgretorno);        
        }
        public  void ActividadNivel1Eliminar(ActividadNivel1 actividad, out string @msgretorno) {
            Accessor.Spu_Pro_Del_PRO09ACTIVIDADNIVEL1(actividad.codigoEmpresa, actividad.codigoLinea, actividad.codigo, out @msgretorno);
        }

        public List<ActividadNivel1> ActividadNivel1Traer(string @PRO09CODEMP, string @PRO09LINEACOD)
        {
            return Accessor.Spu_Pro_Trae_PRO09ACTIVIDADNIVEL1(@PRO09CODEMP, @PRO09LINEACOD);        
        }
        public List<ActividadNivel1> ActividadNivel1TraerAyuda(string @PRO09CODEMP, string @PRO09LINEACOD) {
            return Accessor.Spu_Pro_Help_PRO09ACTIVIDADNIVEL1(@PRO09CODEMP, @PRO09LINEACOD);
        }
       public void ActividadNivel1TraerxLinea(string @PRO09CODEMP, string @PRO09LINEACOD, string @PRO09COD, out string @actividadNivel1){
           Accessor.Spu_Pro_Trae_ActividadNivel1xLinea(@PRO09CODEMP, @PRO09LINEACOD, @PRO09COD, out @actividadNivel1);
       }

        public void ActividadNivelTraeCodigo(string @codigoEmpresa, out string @codigo) {
            Accessor.Spu_Pro_Trae_CodigoActividadNivel1(@codigoEmpresa, out @codigo);
        }
        public ActividadNivel1 ActividadNivel1TraerRegistro(string @PRO09CODEMP,string @PRO09LINEACOD, string @PRO09COD) {
            return Accessor.Spu_Pro_Traer_PRO09ACTIVIDADNIVEL1REGISTRO(@PRO09CODEMP,@PRO09LINEACOD, @PRO09COD);
        }
       public void TraerAlmacenxProceso(string @PRO09CODEMP, string @PRO09LINEACOD, string @PRO09COD, out string @PRO09ALMACENCOD){
           Accessor.Spu_Pro_Traer_AlmacenxProceso(@PRO09CODEMP, @PRO09LINEACOD, @PRO09COD, out @PRO09ALMACENCOD);
       }
       
        public ActividadNivel1 TraerAlmacenxDefecto(string @PRO09CODEMP, string @PRO09COD) {
            return Accessor.Spu_Inv_TraerNaturalxAlmacen(@PRO09CODEMP, @PRO09COD);
        }
        public void TraerNaturalezaDeAlmacen(string @Empresa, string @codigo, out string @naturaleza) {
            Accessor.Spu_Inv_Traer_NaturalezaxAlmacen(@Empresa, @codigo, out @naturaleza);
        }
        /// <summary>
        /// Trae las Actividad de produccion por codigo de Empresa
        /// </summary>
        /// <param name="Empresa">Ingresar codigo de Empresa</param>
        /// <returns>Las Actividad de produccion por codigo de Empresa</returns>
        public List<ActividadNivel1> TraerActiProdxEmpresa(string @Empresa)
        {
            return Accessor.TraerActividadesProdxEmpresa(@Empresa);
        }
        // Reporte 

        public DataTable TraerConsumoMPxActividad(string @Empresa, string @Anio, string @MesIni,
                                                            string @MesFin, string @XMLrango) 
        {
            return Accessor.TraerConsumoMPxActividad(@Empresa, @Anio, @MesIni, @MesFin, @XMLrango);
        }
        public List<ActividadNivel1> TraerActividadRelacionada(string @PRO09CODEMP) {
            return Accessor.TraerActividadRelacionada(@PRO09CODEMP);
        }
        #region Accessor

        private static ActividadNivel1Accesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ActividadNivel1Accesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
