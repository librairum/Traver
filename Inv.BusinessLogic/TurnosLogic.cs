using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
   public class TurnosLogic
    {

       #region Singleton
        private static volatile TurnosLogic instance;
        private static object syncRoot = new Object();

        private TurnosLogic() { }

        public static TurnosLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TurnosLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public void TurnosInsertar(Turnos turno, out string @msgretorno) {
            Accessor.Spu_Pro_Ins_PRO12TURNOS(turno.codigoEmpresa, turno.codigo, turno.descripcion,turno.horainicio, 
                turno.horafin ,turno.horainicioextra, turno.horafinextra,
                out @msgretorno);
        }


        public void TurnosActualizar(Turnos turno, out string @msgretorno) {
            Accessor.Spu_Pro_Upd_PRO12TURNOS(turno.codigoEmpresa, turno.codigo, turno.descripcion,
                    turno.horainicio,
                turno.horafin, turno.horainicioextra, turno.horafinextra,
                out @msgretorno);
        }


        public void TurnosEliminar(Turnos turno, out string @msgretorno) {
            Accessor.Spu_Pro_Del_PRO12TURNOS(turno.codigoEmpresa, turno.codigo, out @msgretorno);
        }


        public List<Turnos> TurnosListar(string @PRO12CODEMP) {
            return Accessor.Spu_Pro_Trae_PRO12TURNOS(@PRO12CODEMP);
        }

        public void TurnosTraeCodigo(string @codigoEmpresa, out string @codigo) {
            Accessor.Spu_Pro_Trae_CodigoTurnos(@codigoEmpresa, out @codigo);
        } 
       public Turnos TurnosTraerRegistro(string @codigoEmpresa, string @codigo){
           return Accessor.Spu_Pro_Traer_RegistroPRO12TURNOS(@codigoEmpresa, @codigo);
       }
       
        #region Accessor

        private static TurnosAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TurnosAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
