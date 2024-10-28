using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PRO13ORDENTRABAJOEJECUTADA")]
    public class OrdenTrabajo
    {

        [MapField("PRO13CODEMP")]
        public string codigoEmpresa {get;set;}

        [MapField("PRO13COD")]
        public string codigo {get;set;}
        [MapField("PRO13PRODUCTOCOD")]
        public string codigoProducto {get;set;}
        [MapField("PRO13DOCINGALMAA")]
        public string DocuIngresoAlmacenAnio {get;set;}
        [MapField("PRO13DOCINGALMMM")]
        public string DocuIngresoAlmacenMes {get;set;}
        [MapField("PRO13DOCINGALMTIPDOC")]
        public string DocuIngresoAlmacenTipDoc {get;set;}
        [MapField("PRO13DOCINGALMCODDOC")]
        public string DocuIngresoAlmacenCodDoc { get; set; }

        [MapField("PRO13LINEACOD")]
        public string PRO13LINEACOD { get; set; }
        [MapField("PRO13ACTIVIDADNIVELCOD")]
        public string PRO13ACTIVIDADNIVELCOD { get; set; }
        
        [MapField("IN01DESLAR")]
        public string productoObjetivo { get; set; }
        [MapField("PRO13ORDPROD")]
        public string OrigenMP { get; set; }
        [MapField("PRO13AA")]
        public string PRO13AA { get; set; }
        
        [MapField("PRO13MM")]
        public string  PRO13MM {get;set;}

        [MapField("CodTipoOT")]
        public string CodTipoOT { get; set; }
        
        [MapField("DesTipoOT")]
        public string DesTipoOT { get; set; }
    }
}
