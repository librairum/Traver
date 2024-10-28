using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
namespace Inv.BusinessLogic
{
   
   public  class VehiculoLogic
    {
        #region Singleton
        private static volatile VehiculoLogic instance;
        private static object syncRoot = new Object();

        private VehiculoLogic() { }

        public static VehiculoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new VehiculoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public List<Vehiculo> TraerVehiculo(string @cCodEmp, string @cCampo, string @cFiltro) {
            return Accessor.TraerVehiculo(@cCodEmp, @cCampo, @cFiltro);
        }
        public void InsertarVehiculo(Vehiculo vehiculo, out string @msgretorno) {            
                Accessor.InsertarVehiculo(vehiculo.FAC69Empresa, vehiculo.FAC69codigo, vehiculo.FAC69MarcaRemolque,
                 vehiculo.FAC69PlacaRemolque, vehiculo.FAC69MarcaSemiRemolque, vehiculo.FAC69PlacaSemiRemolque,
                 vehiculo.FAC69CodTransportista, vehiculo.FAC69Codchofer, out  @msgretorno);
        }

        public void ActualizarVehiculo(Vehiculo vehiculo, out  string @msgretorno) { 
            
        Accessor.ActualizarVehiculo( vehiculo.FAC69Empresa,  vehiculo.FAC69codigo,  vehiculo.FAC69MarcaRemolque,
             vehiculo.FAC69PlacaRemolque,  vehiculo.FAC69MarcaSemiRemolque,  vehiculo.FAC69PlacaSemiRemolque,
             vehiculo.FAC69CodTransportista,  vehiculo.FAC69Codchofer, out @msgretorno);
        }



        public List<CuentaCorriente> BuscarTransportista(string @FAC60CodEmp, string @campo, string @filtro) {
            return Accessor.BuscarTransportista(@FAC60CodEmp, @campo, @filtro);
        }


        public List<CuentaCorriente> BuscarConductor(string @FAC61CodEmp, string @campo, string @filtro) {
            return Accessor.BuscarConductor(@FAC61CodEmp, @campo, @filtro);
        }

        public void EliminarVehiculo(Vehiculo vehiculo, out string @msgretorno)
        {
            Accessor.EliminarVehiculo(vehiculo.FAC69Empresa, vehiculo.FAC69codigo, out @msgretorno);
        }
        public void TraerCodigoVehiculo(string @FAC69Empresa, out string @CodigoGenerado, out int @flag, out string @mensaje)
        { 
            Accessor.GenerarCodigoVehiculo(@FAC69Empresa, out @CodigoGenerado, out @flag, out @mensaje);
        }
        #region Accessor

        private static VehiculoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return VehiculoAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
