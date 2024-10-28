using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{

    [TableName("TiCambioOtrasMonedas")]
    public class TipoCambioMoneda
    {

        [MapField("Fecha")]
        public Nullable<DateTime> fecha {get;set;}

        //Fecha				Datetime   Not Null,	

        
	//MonedaOrigenCod		varchar(2) Not Null,			
	//MonedaDestinoCod	varchar(2) Not Null,				
	//TipoCambio			decimal(9,6)

        [MapField("MonedaOrigenCod")]
        public string origencod {get;set;}
        
        [MapField("MonedaDestinoCod")]
        public string destinocod { get;set;}


        [MapField("TipoCambio")]
        public double tipocambio { get; set; }



    }
}
