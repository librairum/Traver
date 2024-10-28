using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("FAC01_TIPDOC")]
    public class TipoDocumentoVentas
    {
        [MapField("FAC01CODEMP")]
        public string FAC01CODEMP {get;set;}

        [MapField("FAC01COD")]
        public string FAC01COD {get;set;}

        [MapField("FAC01DESC")]
        public string FAC01DESC	 {get;set;}

        [MapField("FAC01TIPDOC")]
        public string FAC01TIPDOC {get;set;}

		[MapField("FAC01CODLIBRO")]
        public string FAC01CODLIBRO { get; set; }

        
        [MapField("FAC01FETIPDOC")]
        public string FAC01FETIPDOC { get; set; }

        [MapField("TipDocFecDesc")]
        public string TipDocFecDesc { get; set; }
    }
}
