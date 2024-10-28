using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("FAC08_CABASIENTOTIPO")]
    public class AsientoTipo
    {
        [MapField("FAC08CODEMP")]
        public string FAC08CODEMP { get; set; }

        [MapField("FAC08COD")]
        public string FAC08COD { get; set; }

        [MapField("FAC08DES")]
        public string FAC08DES { get; set; }

        [MapField("FAC08CODLIBRO")]
        public string FAC08CODLIBRO { get; set; }

        [MapField("FAC09CODEMP")]  
        public string FAC09CODEMP  { get;  set; } 

        //[MapField("FAC08COD")]  
        //public string FAC08COD  { get;  set; } 

        [MapField("FAC09ORDEN")]  
        public int FAC09ORDEN  { get;  set; } 

        [MapField("FAC09CTA")]  
        public string FAC09CTA  { get;  set; } 

        [MapField("FAC09FLAG")]  
        public string FAC09FLAG  { get;  set; } 

        [MapField("FAC09CAMPO")]  
        public string FAC09CAMPO  { get;  set; } 

        [MapField("FAC09PORCENTAJE")]  
        public double FAC09PORCENTAJE  { get;  set; }

        [MapField("FAC09COLUMNA")]
        public string FAC09COLUMNA { get; set; }
        public string FAC09CTA_Des	 {get;set;}
        public string FAC09FLAG_des	 {get;set;}
        public string FAC09CAMPO_des { get; set; }

        public string LibroDesc { get; set; }

        
    }
}