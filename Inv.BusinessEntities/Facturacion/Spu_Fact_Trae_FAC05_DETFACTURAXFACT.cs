using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Trae_FAC05_DETFACTURAXFACT")]
    public class Spu_Fact_Trae_FAC05_DETFACTURAXFACT
    {

        [MapField("FAC05CODEMP")]
        public string FAC05CODEMP { get; set; }
        [MapField("FAC01COD")]
        public string FAC01COD { get; set; }
        [MapField("FAC04NUMDOC")]
        public string FAC04NUMDOC { get; set; }
        [MapField("FAC05CODFACDET")]
        public int FAC05CODFACDET { get; set; }
        [MapField("FAC05CODPROD")]
        public string FAC05CODPROD { get; set; }
        [MapField("FAC05DESCPROD")]
        public string FAC05DESCPROD { get; set; }
        [MapField("FAC05UNIMED")]
        public string FAC05UNIMED { get; set; }
        [MapField("FAC05CANTIDAD")]
        public double FAC05CANTIDAD { get; set; }
        [MapField("FAC05PRECIO")]
        public double FAC05PRECIO { get; set; }
        [MapField("FAC05SUBTOTAL")]
        public double FAC05SUBTOTAL { get; set; }
        [MapField("FAC05MINTMH")]
        public double FAC05MINTMH { get; set; }
        [MapField("FAC05MINTMS")]
        public double FAC05MINTMS { get; set; }
        [MapField("FAC05MINTMP")]
        public double FAC05MINTMP { get; set; }
        [MapField("FAC05MINLOTE")]
        public string FAC05MINLOTE { get; set; }
        [MapField("FAC05MINCONTRATO")]
        public string FAC05MINCONTRATO { get; set; }
        [MapField("FAC05MINENMIENDA")]
        public string FAC05MINENMIENDA { get; set; }
        [MapField("FAC05MINGUIAS")]
        public string FAC05MINGUIAS { get; set; }
        [MapField("FAC05MINTMH_PRO")]
        public double FAC05MINTMH_PRO { get; set; }
        [MapField("FAC05MINTMS_PRO")]
        public double FAC05MINTMS_PRO { get; set; }
        [MapField("FAC05MINTMP_PRO")]
        public double FAC05MINTMP_PRO { get; set; }
        [MapField("FAC05PRECIO_PRO")]
        public double FAC05PRECIO_PRO { get; set; }
        [MapField("FAC05SUBTOTAL_PRO")]
        public double FAC05SUBTOTAL_PRO { get; set; }
        [MapField("FAC05SUBTOTAL_FIN")]
        public double FAC05SUBTOTAL_FIN { get; set; }
        [MapField("FAC05DESCLARGA")]
        public string FAC05DESCLARGA { get; set; }
        [MapField("FAC04IMPSUBTOTAL")]
        public double FAC04IMPSUBTOTAL { get; set; }
        [MapField("FAC04IMPIGV")]
        public double FAC04IMPIGV { get; set; }
        [MapField("FAC04IMPTOTAL")]
        public double FAC04IMPTOTAL { get; set; }
        [MapField("FAC05PARTARAN")]
        public string FAC05PARTARAN { get; set; }
        
        [MapField("FAC05PESO")]
        public double FAC05PESO {get;set;}
        [MapField("FAC05NROCAJA")]
        public double FAC05NROCAJA {get;set;}
        [MapField("FAC05PESOADUANA")]
        public double FAC05PESOADUANA {get;set;}
        [MapField("FAC05SUBGRUPO")]
        public string FAC05SUBGRUPO {get;set;}
        [MapField("FAC05IGV")]
        public double FAC05IGV { get; set; }
        [MapField("FAC05IMPTOTAL")]
        public double FAC05IMPTOTAL { get; set; }
        [MapField("FAC04TOTALPESO")]
        public double FAC04TOTALPESO { get; set; }
        [MapField("FAC04TOTALPESOADUANA")]
        public double FAC04TOTALPESOADUANA {get;set;}
        [MapField("FAC04TOTALCAJAS")]
        public double FAC04TOTALCAJAS {get;set;}
        [MapField("FAC04TOTALCANTIDAD")]
        public double FAC04TOTALCANTIDAD {get;set;}
        
        [MapField("FAC04IGV")]
        public double FAC04IGV {get;set;}
        
        [MapField("FAC05GUIATIPDOC")]
        public string FAC05GUIATIPDOC {get;set;}

        [MapField("FAC05GUIANUMERO")]
        public string  FAC05GUIANUMERO {get;set;}

        [MapField("FAC05GUIAITEM")]
        public int FAC05GUIAITEM { get; set; }

        [MapField("FAC05FECODPRODSUNAT")]
        public string FAC05FECODPRODSUNAT { get; set; }

        [MapField("FAC05FEIGVTASA")]
        public double FAC05FEIGVTASA { get; set; }

        [MapField("FAC05FECODRAZEXONERACION")]
        public string FAC05FECODRAZEXONERACION { get; set; }

        [MapField("FAC05FECODIMPREF")]
        public string FAC05FECODIMPREF { get; set; }

        [MapField("FAC05FEPRODUCTOTIPO")]
        public string FAC05FEPRODUCTOTIPO { get; set; }

        [MapField("FAC05FEIMPDSCTO")]
        public double FAC05FEIMPDSCTO {get;set;}

        [MapField("FAC05FEIMPORTEREFERENCIAL")]
        public double FAC05FEIMPORTEREFERENCIAL {get;set;}

        [MapField("FAC05FEIMPORTECARGO")]
        public double FAC05FEIMPORTECARGO {get;set;}

        [MapField("FAC05CODPROD_PROV")]
        public string FAC05CODPROD_PROV { get; set; }

        [MapField("FAC05DESPROD_PROV")]
        public string FAC05DESPROD_PROV { get; set; }

        [MapField("FAC05UNIMED_PROV")]
        public string FAC05UNIMED_PROV { get; set; }


    }
}
