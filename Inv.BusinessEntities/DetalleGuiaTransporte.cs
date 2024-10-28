using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("FAC35_DETGUIA")]
   public class DetalleGuiaTransporte
    {
        [MapField("FAC35CODEMP")]
        public string FAC35CODEMP	 {get;set;}
        [MapField("FAC01COD")]
        public string FAC01COD {get;set;}
        [MapField("FAC34NROGUIA")]
        public string FAC34NROGUIA {get;set;}
        [MapField("FAC35CODGUIADET")]
        public string FAC35CODGUIADET {get;set;}
        [MapField("FAC35CODPROD")]
        public string FAC35CODPROD { get; set; }
        [MapField("FAC35DESCPROD")]
        public string FAC35DESCPROD { get; set; }
        [MapField("FAC35UNIMED")]
        public string FAC35UNIMED	{get;set;}
        [MapField("FAC35CANTIDAD")]        
        public double FAC35CANTIDAD {get;set;}
        [MapField("FA35NROPIEZAS")]
        public double FA35NROPIEZAS {get;set;}
        [MapField("FA35PESO")]
        public double  FA35PESO {get;set;}
        [MapField("FA35NROCAJAS")]
        public double FA35NROCAJAS {get;set;}
        [MapField("FAC35CODPROD_PROV")]
        public string FAC35CODPROD_PROV {get;set;}
        [MapField("FAC35DESCPROD_PROV")]
        public string FAC35DESCPROD_PROV {get;set;}
        [MapField("FAC35UNIMED_PROV")]
        public string FAC35UNIMED_PROV {get;set;}
[MapField("IN01UNIMEDVENTA")]
        public string IN01UNIMEDVENTA { get; set; }

        public string rucdestino { get; set; }
        public string tipoarticulo { get; set; }
        public int FLAGPROVEEDOR { get; set; }	

    }
}
