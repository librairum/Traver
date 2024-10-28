using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("FAC65_DESTINARIOESTAB")]
   public class DomicilioDestino
    {
        [MapField("FAC65CODEMP")]
        public string FAC65CODEMP {get;set;}
        [MapField("FAC64CODIGO")]
        public string FAC64CODIGO { get; set; }
        [MapField("FAC65CODEST")]
        public string FAC65CODEST { get; set; }
        [MapField("FAC65DESEST")]
        public string FAC65DESEST { get; set; }
        [MapField("FAC65CODTIPEST")]
        public string FAC65CODTIPEST { get; set; }
        [MapField("FAC65DIRECCION")]
        public string FAC65DIRECCION { get; set; }
//       FAC65CODEMP	FAC64CODIGO	FAC65CODEST	FAC65DESEST	FAC65CODTIPEST	FAC65DIRECCION
//01	.	0211	Av Juan Pablo II y Obispo de Cabrera 382 TRUJILLO	  	AV. JUAN PABLO II OBISPO DE CABRERA 382 - TRUJILLO

    
    }
}
 