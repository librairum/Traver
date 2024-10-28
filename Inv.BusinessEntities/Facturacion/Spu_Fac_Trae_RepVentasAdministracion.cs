using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Fac_Trae_RepVentasAdministracion")]
    public class Spu_Fac_Trae_RepVentasAdministracion
    {
        [MapField("Fecha")]
        public string Fecha {get;set;}

        [MapField("NumeroDocumento")]
        public string NumeroDocumento {get;set;}

        [MapField("ClienteNombre")]
        public string ClienteNombre {get;set;}

        [MapField("CantidadMT2oTM")]
        public double CantidadMT2oTM {get;set;}

        [MapField("ValorVentaDol")]
        public double ValorVentaDol {get;set;}

        [MapField("TipCambio")]
        public string TipCambio {get;set;}

        [MapField("ValorVentaSol")]
        public double ValorVentaSol {get;set;}

        [MapField("NROCAJAS")]
        public double NROCAJAS {get;set;}

        [MapField("CantidadOtrasUniMed")]
        public double CantidadOtrasUniMed {get;set;}

        [MapField("NroEtiquetas")]
        public double NroEtiquetas {get;set;}

        [MapField("PAIS_DESTINO")]
        public string PAIS_DESTINO {get;set;}



        [MapField("NRO_ORDENCOMPRA")]
        public string NRO_ORDENCOMPRA {get;set;}



        [MapField("CONDICION_PAGO")]
        public string CONDICION_PAGO {get;set;}

        [MapField("GuiaNroCabecera")]
        public string GuiaNroCabecera {get;set;}

        [MapField("GuiaFecha")]
        //public Nullable<DateTime> GuiaFecha { get;set;}
        public string GuiaFecha { get; set; }

        [MapField("GuiaNro")]
        public string GuiaNro {get;set;}

        [MapField("GuiaCantidad")]
        public double GuiaCantidad {get;set;}

        [MapField("PlantaMT2")]
        public double PlantaMT2 {get;set;}

        [MapField("Diferencia")]
        public double Diferencia {get;set;}

        [MapField("CantidadBaldosasMT2")]
        public double CantidadBaldosasMT2 {get;set;}

        [MapField("CantidadMosaicosMT2")]
        public double  CantidadMosaicosMT2 {get;set;}

        [MapField("CantidadPlanchasMT2")]
        public double  CantidadPlanchasMT2 {get;set;}

        [MapField("CantidadEscallaPlantaTM")]
        public double CantidadEscallaPlantaTM {get;set;}

        [MapField("CantidadEscallaCanteraTM")]
        public double CantidadEscallaCanteraTM {get;set;}

        [MapField("CantidadPolvoTM")]
        public double CantidadPolvoTM {get;set;}

        [MapField("observacion")]
        public string observacion { get; set; }

        [MapField("NroLiquidacion")]
        public string NroLiquidacion { get; set; }
        [MapField("otros")]
        public string otros { get; set; }

        [MapField("ValorOtrasMonedas")]
        public double ValorOtrasMonedas { get; set; }

        [MapField("VendedorCod")]
        public string VendedorCod { get; set; }

        [MapField("VendedorDesc")]
        public string VendedorDesc { get; set; }

    }
}
