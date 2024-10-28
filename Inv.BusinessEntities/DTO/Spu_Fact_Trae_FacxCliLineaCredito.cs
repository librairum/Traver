using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Trae_FacxCliLineaCredito")]
    public class Spu_Fact_Trae_FacxCliLineaCredito
    {
            [MapField("FAC04CODEMP")]
            public string FAC04CODEMP {get;set;}

            [MapField("FAC01COD")]
            public string FAC01COD {get;set;}

            [MapField("FAC04NUMDOC")]
            public string FAC04NUMDOC {get;set;}
            
            [MapField("FAC04FECHA")]
            public Nullable<DateTime> FAC04FECHA {get;set;}

            [MapField("FAC04MONEDA")]
            public string FAC04MONEDA {get;set;}

            [MapField("FAC04IMPTOTAL")]
            public double FAC04IMPTOTAL {get;set;}

	        [MapField("FAC04CLAVE")]
            public string FAC04CLAVE {get;set;}

            [MapField("FAC04CLINOMBRE")]
            public string FAC04CLINOMBRE {get;set;}

            [MapField("FAC01DESC")]
            public string FAC01DESC {get;set;}

            [MapField("EstadoSunat")]
            public string EstadoSunat {get;set;}

            [MapField("cbajaFecha")]
            public Nullable<DateTime> cbajaFecha {get;set;}

            [MapField("cbMotivo")]
            public string cbMotivo {get;set;}

            [MapField("cbEstadoSunat")]
            public string cbEstadoSunat {get;set;}
            [MapField("NCNDFecha")]
            public Nullable<DateTime> NCNDFecha {get;set;}
            [MapField("NCNDTipo")]
            public string NCNDTipo {get;set;}
            [MapField("NCNDNumero")]
            public string NCNDNumero {get;set;}
            [MapField("EstadoPago")]
            public string EstadoPago {get;set;}
            [MapField("EstadoEnvioSecrex")]
            public string EstadoEnvioSecrex { get; set; }

            [MapField("FAC04ESTADOPAGO")]
            public string FAC04ESTADOPAGO { get; set; }
            [MapField("FAC04FLAGINFORMADAALSEGURO")]
            public string FAC04FLAGINFORMADAALSEGURO { get; set; }
    }
}
