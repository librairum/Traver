using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Data;
using BLToolkit.Mapping;
namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Rep_GuiasCantera")]
    public class Spu_Fact_Rep_GuiasCantera
    {
        [MapField("FAC34CODEMP")]
        public string FAC34CODEMP { get; set; }
        [MapField("FAC34AA")]
        public string FAC34AA { get; set; }
        [MapField("FAC34MM")]
        public string FAC34MM {get;set;}
        [MapField("FAC34SERIEGUIA")]
        public string FAC34SERIEGUIA {get;set;}
        [MapField("FAC34NROGUIA")]
        public string FAC34NROGUIA {get;set;}
        [MapField("FAC34FECHA")]
        public Nullable<DateTime> FAC34FECHA {get;set;}
        [MapField("FAC34ORIDESESTAB")]
        public string FAC34ORIDESESTAB {get;set;}
        [MapField("FAC34DESDESESTAB")]
        public string FAC34DESDESESTAB {get;set;}
        [MapField("FAC34DESTDIRECCION")]
        public string FAC34DESTDIRECCION {get;set;}
        [MapField("FAC34MOTRASLDESC")]
        public string FAC34MOTRASLDESC {get;set;}
        [MapField("FAC34MOTRASLDESCEXTRA")]
        public string FAC34MOTRASLDESCEXTRA {get;set;}
        
        [MapField("FAC34ESTADO")]
        public string FAC34ESTADO {get;set;}
        [MapField("FAC34DESTRANSPORTISTA")]
        public string FAC34DESTRANSPORTISTA  {get;set;}
        [MapField("FAC34DESDESEMP")]
        public string FAC34DESDESEMP {get;set;}
        
        [MapField("FAC35CODGUIADET")]
        public string  FAC35CODGUIADET {get;set;}
        [MapField("FAC35CODPROD")]
        public string  FAC35CODPROD {get;set;}
        
        [MapField("FAC35DESCPROD")]
        public string  FAC35DESCPROD {get;set;}
        
        [MapField("FAC35UNIMED")]
        public string  FAC35UNIMED {get;set;}

        [MapField("FAC35CANTIDAD")]
        public double FAC35CANTIDAD { get; set; }

        [MapField("FA35NROPIEZAS")]
        public double FA35NROPIEZAS { get; set; }
        
        [MapField("FA35PESO")]
        public double FA35PESO { get; set; }
        
        [MapField("FAC37CONTRATISTADESC")]
        public string FAC37CONTRATISTADESC { get; set; }

        [MapField("FAC37LABORDESC")]
        public string FAC37LABORDESC { get; set; }
        
    }
}
