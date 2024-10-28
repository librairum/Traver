using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
    public abstract class VehiculoAccesor : AccessorBase<VehiculoAccesor>
    {
        [SprocName("Spu_Fact_Trae_FAC69_VEHICULO")]
        
        public abstract List<Vehiculo> TraerVehiculo(string @FAC69Empresa, string @campo, string @filtro);

        [SprocName("Spu_Fact_Ins_FAC69_VEHICULO")]
        public abstract void InsertarVehiculo (string @FAC69Empresa ,  string @FAC69codigo ,  string @FAC69MarcaRemolque , 
            string @FAC69PlacaRemolque ,  string @FAC69MarcaSemiRemolque ,  string @FAC69PlacaSemiRemolque ,  
            string @FAC69CodTransportista ,   string @FAC69Codchofer,  out string @msgretorno );

        [SprocName("Spu_Fact_Upd_FAC69_VEHICULO")]        
        public abstract void ActualizarVehiculo(string @FAC69Empresa, string @FAC69codigo, string @FAC69MarcaRemolque,
            string @FAC69PlacaRemolque, string @FAC69MarcaSemiRemolque, string @FAC69PlacaSemiRemolque,
            string @FAC69CodTransportista, string @FAC69Codchofer, out  string @msgretorno);
        

        [SprocName("Spu_Fact_Help_FAC60_TRANSPORTISTA")]
        public abstract List<CuentaCorriente> BuscarTransportista(string @FAC60CodEmp,  string @campo,  string @filtro);

        [SprocName("Spu_Fact_Help_FAC61_CHOFER")]
        public abstract List<CuentaCorriente> BuscarConductor(string @FAC61CodEmp, string @campo, string @filtro);

        [SprocName("Spu_Fact_Del_FAC69_VEHICULO")]
        public abstract void EliminarVehiculo(string @FAC69Empresa, string @FAC69codigo, out string @msgretorno);

        [SprocName("Spu_Fact_Trae_VehiculoCodigoGenerado")]
        public abstract void GenerarCodigoVehiculo(string @FAC69Empresa,out string @CodigoGenerado,out int @flag, out string @mensaje);
        //[SprocName("")]
        //public abstract List<Vehiculo> TraerVehiculoRegistro(string 
    }
}
