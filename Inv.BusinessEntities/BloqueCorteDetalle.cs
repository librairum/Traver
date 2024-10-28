using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in04axal")]
    public class BloqueCorteDetalle
    {
            
        [MapField("PRO16CODEMP")]
        public string Empresa {get;set;}
    
        [MapField("PRO16AA")]
        public string Anio {get;set;}
    
        [MapField("PRO16MM")]
        public string Mes {get;set;}
    
        [MapField("PRO16TIPDOC")]
        public string TipoDocu {get;set;}
    
        [MapField("PRO16CODDOC")]
        public string CodigDocumento {get;set;}
    
        [MapField("PRO16KEY")]
        public string CodBloque { get; set; }

    
        [MapField("PRO16ORDEN")]
        public double orden  {get;set;}

    
        [MapField("PRO16CORRELATIVO")]
        public int correlativo {get;set;}
    
        [MapField("PRO16BLOQUEANCHO")]
        public double AnchoBloque { get; set; }
    
        [MapField("PRO16BLOQUELARGO")]
        public double LargoBloque { get; set; }

    
        [MapField("PRO16BLOQUEALTO")]
        public double AlturaBloque { get; set; }
    
        [MapField("PRO16BLOQUEESCLAT1")]
        public double lado1 { get; set; }
    
        [MapField("PRO16BLOQUEESCLAT2")]
        public double lado2 { get; set; }
    
        [MapField("PRO16BLOQUEESCSUP")]
        public double Superior {get;set;}
    //PRO16BLOQUELADODELCORTE	CHAR(2), --AN=Ancho,LA=Largo,AL=Alto
        [MapField("PRO16BLOQUELADODELCORTE")]
        public string BloqueLadoCorte  {get;set;}
    
        [MapField("PRO16ESCALLAALMACENCOD")]
        public string CodAlmEscalla { get; set; }
    
        [MapField("PRO16ESCALLAPRODUCTOCOD")]
        public string CodEscalla { get; set; }        
    
        [MapField("PRO16COSTRAALMACENCOD")]
        public string CodAlmCostra { get; set; }
    
        [MapField("PRO16COSTRAPRODUCTOCOD")]
        public string CodCostra { get; set; }

        [MapField("DesAlmEscalla")]
        public string DesAlmEscalla { get; set; }
        [MapField("DesAlmCostra")]
        public string DesAlmCostra { get; set; }
        [MapField("Escalla")]
        public string Escalla { get; set; }
        [MapField("Costra")]
        public string Costra { get; set; }
        [MapField("AltoCostra")]
        public string AltoCostra { get; set; }

    }
}
