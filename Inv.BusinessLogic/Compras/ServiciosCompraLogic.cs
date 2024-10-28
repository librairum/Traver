using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ServiciosCompraLogic
    {

        #region Singleton
        private static volatile ServiciosCompraLogic instance;
        private static object syncRoot = new Object();

        private ServiciosCompraLogic() { }

        public static ServiciosCompraLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ServiciosCompraLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public  List<UnidaddeMedida> TraeAyudaUnidadMedida(string @cCodEmp)
        {
            return Accesor.TraeAyudaUnidadMedida(@cCodEmp);
        }


        public  List<CuentaContable> TraeAyudaCuentasSoloMov(string @cEmpresa, string @ccm01aa)
        {
            return Accesor.TraeAyudaCuentasSoloMov(@cEmpresa, @ccm01aa);
        }

        public  List<ServiciosCompras> TraeServicios(string @cCodEmp)
        {
            return Accesor.TraeServicios(@cCodEmp);
        }


        public  void EliminarServicios(ServiciosCompras entidad, out int @flag, out string @cMsgRetorno)
        {
            Accesor.EliminarServicios(entidad.codigoEmpresa, entidad.codigo, out @flag, out @cMsgRetorno);
        }


        public  void InsertarServicios(ServiciosCompras entidad,out int @flag, out string @cMsgRetorno)
        { 
            Accesor.InsertarServicios(entidad.codigoEmpresa, entidad.codigo, entidad.descripcion,
                                entidad.unidadmedida, entidad.ctagas, out @flag, out @cMsgRetorno);
        }


        public void ActualizarServicios(ServiciosCompras entidad, out int @flag, out string @cMsgRetorno)
        {
            Accesor.ActualizarServicios(entidad.codigoEmpresa, entidad.codigo, entidad.descripcion,
                                entidad.unidadmedida, entidad.ctagas, out @flag, out @cMsgRetorno);
        }

        #region "Reporte"
        public DataTable TraeReporteServicios(string @cCodEmp)
        {
            return Accesor.TraeReporteServicios(@cCodEmp);
        }

        #endregion

        #region Accessor

        private static ServiciosCompraAccesor Accesor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ServiciosCompraAccesor.CreateInstance(); }
        }

        #endregion Accessor


    }
}
