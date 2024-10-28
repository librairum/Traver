using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("PRO09ACTIVIDADNIVEL1")]
   public class ActividadNivel1
    {
        [MapField("PRO09CODEMP")]
        public string codigoEmpresa {get;set;}

        [MapField("PRO09LINEACOD")]
        public string codigoLinea { get; set; }
        
        [MapField("PRO09COD")]
        public string codigo {get;set;}

        [MapField("PRO09DESC")]
        public string descripcion { get; set;}

        [MapField("PRO09ALMACENCOD")]
        public string codigoAlmacen {get;set;}

        [MapField("PRO09ALMMPXDEFECTO")]
        public string almacenMP { get;set; }

        [MapField("NATURALEZAALMMP")]
        public string NATURALEZAALMMP { get; set; }

        [MapField("NATURALEZAALM")]
        public string NATURALEZAALM { get; set; }
        
        public string in09PRODNATURALEZA { get; set; }
        public string in09codigo { get; set; }

        [MapField("descripalmacen")]
        public string descripalmacen { get; set; }

        [MapField("descripalmacenxdefecto")]
        public string descripalmacenxdefecto { get; set; }
        [MapField("PRO08DESC")]
        public string descripcionLinea { get; set; }

        //Documento de transaccion por defecto de actividad
        [MapField("CodigoTransaSalxDefecto")]
        public string CodigoTransaSalxDefecto { get; set; }

        [MapField("descripTransaSalxDefecto")]
        public string descripTransaSalxDefecto { get; set; }

        //Tipo de documento de salida por defecto
        [MapField("CodigoDocRespSalxDefecto")]
        public string CodigoDocRespSalxDefecto { get; set; }

        [MapField("descripDocRespSalxDefecto")]
        public string descripDocRespSalxDefecto { get; set; }
    }
}
