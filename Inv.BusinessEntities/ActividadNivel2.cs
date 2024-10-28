using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("PRO09ACTIVIDADNIVEL1")]
    public class ActividadNivel2
    {
        [MapField("PRO10CODEMP")]
        public string codigoEmpresa { get; set;}

        [MapField("PRO10COD")]
        public string codigo {get;set;}
        [MapField("PRO10DESC")]
        public string descripcion { get; set; }


        [MapField("PRO08COD")]
        public string codigoLinea { get; set; }

        [MapField("descripcionLinea")]
        public string descripcionLinea { get; set; }


        [MapField("PRO09COD")]
        public string codigoActividad { get; set; }

        [MapField("descripcionActividad")]
        public string descripcionActividad { get; set; }
    }
}
