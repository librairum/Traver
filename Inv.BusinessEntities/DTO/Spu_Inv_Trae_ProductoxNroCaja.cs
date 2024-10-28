using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities.DTO
{

    [TableName("Spu_Inv_Trae_ProductoxNroCaja")]
    public class Spu_Inv_Trae_ProductoxNroCaja
    {
        [MapField("IN07CODEMP")]
        public string  IN07CODEMP {get;set;}

        [MapField("IN07AA")]
        public string IN07AA {get;set;}

        [MapField("IN07MM")]
        public string IN07MM {get;set;}

        [MapField("IN07TIPDOC")]
        public string IN07TIPDOC {get;set;}

        [MapField("IN07CODDOC")]
        public string IN07CODDOC {get;set;}
        
        //Campos usados en el la vista de la consulta
        [MapField("in07nrocaja")]
        public string in07nrocaja { get; set; }
        [MapField("StockReal")]
        public double StockReal { get; set; }
        [MapField("IN01KEY")]
        public string IN01KEY { get; set; }
        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }
        [MapField("StockRealArea")]
        public double StockRealArea { get; set; }
        [MapField("IN07UBICACION")]
        public string IN07UBICACION { get; set; }
        [MapField("in07unimed")]
        public string in07unimed { get; set; }
        // ====
        [MapField("IN07ANCHO")]
        public double IN07ANCHO { get; set; }
        [MapField("IN07LARGO")]
        public double IN07LARGO { get; set; }
        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }

        [MapField("in07observacion")]
        public string in07observacion { get; set; }

    }
}
