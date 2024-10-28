using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities.DTO
{
    [TableName("Spu_Inv_Trae_StockDetMPTodos")]
    public class Spu_Inv_Trae_StockDetMPTodos
    {
        [MapField("IN07CODEMP")]
        public string IN07CODEMP { get; set; }

        [MapField("CodigoProducto")]
        public string CodigoProducto { get; set; }

        [MapField("descripcion")]
        public string descripcion { get; set; }

        [MapField("nrocaja")]
        public string nrocaja { get; set; }

        [MapField("IN09CODIGO")]
        public string IN09CODIGO { get; set; }

        [MapField("StockRealVolumen")]
        public string StockRealVolumen { get; set; }

        [MapField("MPAncho")]
        public string MPAncho { get; set; }

        [MapField("MPAlto")]
        public string MPAlto { get; set; }

        [MapField("MPlargo")]
        public string MPlargo { get; set; }

        [MapField("UnidadMedida")]
        public string UnidadMedida { get; set; }

        [MapField("DocingAA")]
        public string DocingAA { get; set; }

        [MapField("DocingMM")]
        public string DocingMM { get; set; }

        [MapField("DocingTD")]
        public string DocingTD { get; set; }

        [MapField("DocingCD")]
        public string DocingCD { get; set; }

        [MapField("DocingMP")]
        public string DocingMP { get; set; }

        [MapField("DocingNO")]
        public string DocingNO { get; set; }

        [MapField("codigoOperador")]
        public string codigoOperador { get; set; }

        public string chkSelect { get; set; }

        /*
         
         IN07CODEMP	CodigoProducto	descripcion	nrocaja	StockRealVolumen	ancho	alto	largo	UnidadMedida	DocingAA	DocingMM	DocingTD	DocingCD	DocingMP	DocingNO
01	BLLAXXXXXXXXXXXXXXX	BLOQUE TRAVERTINO Laguna    	16878	4.26000000	1	2	3	MT3	2016	04	41	201604112174	BLLAXXXXXXXXXXXXXXX	16878
         */

    }
}
