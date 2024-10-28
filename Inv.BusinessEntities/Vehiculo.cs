using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("FAC69_VEHICULO")]
  public  class Vehiculo
    {
        [MapField("codigoVehiculo")]
        public string codigoVehiculo { get; set; }
        [MapField("FAC69Empresa")]
        public string FAC69Empresa { get; set; }
        [MapField("FAC69codigo")]
        public string FAC69codigo { get; set; }
        [MapField("FAC69MarcaRemolque")]
        public string FAC69MarcaRemolque { get; set; }
        [MapField("FAC69PlacaRemolque")]
        public string FAC69PlacaRemolque { get; set; }
        [MapField("FAC69MarcaSemiRemolque")]
        public string FAC69MarcaSemiRemolque { get; set; }
        [MapField("FAC69PlacaSemiRemolque")]
        public string FAC69PlacaSemiRemolque { get; set; }
        [MapField("FAC69CodTransportista")]
        public string FAC69CodTransportista { get; set; }
        [MapField("FAC69Codchofer")]
        public string FAC69Codchofer { get; set; }
        
        /*
         FAC69Empresa	FAC69codigo	FAC69MarcaRemolque	FAC69PlacaRemolque	FAC69MarcaSemiRemolque	FAC69PlacaSemiRemolque	FAC69CodTransportista	FAC69Codchofer
01	0107	FREIGHTLINER	B4A-887		D3T-997	20551015239	07122261
         */
    }
}
