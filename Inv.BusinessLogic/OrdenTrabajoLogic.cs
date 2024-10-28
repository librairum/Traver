using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Transactions;
using System.Data;
using System.Collections;

namespace Inv.BusinessLogic
{
   public class OrdenTrabajoLogic 
    {
        #region Singleton
        private static volatile OrdenTrabajoLogic instance;
        private static object syncRoot = new Object();

        private OrdenTrabajoLogic() { }

        public static OrdenTrabajoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new OrdenTrabajoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<OrdenTrabajo> TraerOrdenTrabajo(string codEmpresa,string anio, string mes,string coddoc, string tipdoc) {
            return Accessor.TraerOrdenTrabajo(codEmpresa, anio, mes, coddoc, tipdoc);
        }
        public void InsertarOrdenTrabajo(OrdenTrabajo orden, out int @flag,out string @msgretorno) {
            
            Accessor.InsertarOrdenTrabajo(orden.codigoEmpresa, orden.codigo, orden.codigoProducto, orden.DocuIngresoAlmacenAnio, 
                orden.DocuIngresoAlmacenMes, orden.DocuIngresoAlmacenTipDoc,
                orden.DocuIngresoAlmacenCodDoc, orden.OrigenMP, orden.PRO13LINEACOD, orden.PRO13ACTIVIDADNIVELCOD, orden.PRO13AA, orden.PRO13MM,
                orden.CodTipoOT, out  @flag, out @msgretorno);
        }
        public void ActualizarOrdenTrabajo(OrdenTrabajo orden, out int @flag,out string @msgretorno) {
            Accessor.ActualizarOrdenTrabajo(orden.codigoEmpresa, orden.codigo, orden.codigoProducto, orden.DocuIngresoAlmacenAnio,
                    orden.DocuIngresoAlmacenMes, orden.DocuIngresoAlmacenTipDoc, orden.DocuIngresoAlmacenCodDoc,
                    orden.OrigenMP, orden.PRO13LINEACOD, orden.PRO13ACTIVIDADNIVELCOD, orden.PRO13AA, orden.PRO13MM, 
                    orden.CodTipoOT, out  @flag, out @msgretorno);
        }
        public void EliminarOrdenTrabajo(OrdenTrabajo orden, out string @msgretorno) {
            Accessor.EliminarOrdenTrabajo(orden.codigoEmpresa, orden.codigo, out @msgretorno);
        }
        public void TraerNumeroOT(string @PRO13CODEMP, out string @NumOT) {
            Accessor.TraerNumeroOT(@PRO13CODEMP, out @NumOT);
        }
        public OrdenTrabajo TraerRegistroOT(string @PRO13CODEMP, string @PRO13COD) {
            return Accessor.TraerRegistroOT(@PRO13CODEMP, @PRO13COD);
        }
        #region "Orden trabajo tipo"

        public List<OrdenTrabajoTipo> TraerOrdenTrabajoTipo(string @Empresa, string @Codigo)
        {
            return Accessor.TraerOrdenTrabajoTipo(@Empresa, @Codigo);
        }
        public void TraerNroOrdenTrabajoTipo(string @Empresa, out string @Codigo, out int @flag, out string @mensaje)
        { 
            Accessor.TraerNroOrdenTrabajoTipo(@Empresa, out @Codigo, out @flag, out @mensaje);
        }
        public void InsertarOrdenTrabajoTipo(string @Empresa, string @Codigo, string @Descripcion, out  int @flag, out string @mensaje)
        { 
            Accessor.InsertarOrdenTrabajoTipo(@Empresa, @Codigo, @Descripcion, out  @flag, out @mensaje);
        }
        public void ActualizarOrdenTrabajoTipo(string @Empresa, string @Codigo, string @Descripcion, out  int @flag, out string @mensaje)
        {
            Accessor.ActualizarOrdenTrabajoTipo(@Empresa, @Codigo, @Descripcion, out  @flag, out @mensaje);
        }

        public void EliminarOrdenTrabajoTipo(string @Empresa, string @Codigo, out int @flag, out string @mensaje) { 
            Accessor.EliminarOrdenTrabajoTipo(@Empresa, @Codigo, out @flag, out @mensaje);
        }
        #endregion
        /*
            public abstract void EliminarOrdenTrabajo(string @PRO13CODEMP, string @PRO13COD, out string @msgretorno);
            */
        #region Accessor

        private static OrdenTrabajoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return OrdenTrabajoAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
