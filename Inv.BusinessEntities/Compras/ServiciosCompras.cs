using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    
    [TableName("Co01Serv")]
    public class ServiciosCompras
    {
        [MapField("IN01CODEMP")]
        public string codigoEmpresa {get;set;}
        [MapField("IN01KEY1")]
        public string codigo {get;set;}

        [MapField("IN01DESLAR")]
        public string descripcion {get;set;}

        [MapField("IN01UNIMED")]
        public string unidadmedida {get;set;}

        [MapField("IN01CODGAS")]
        public string codgas {get;set;}

        [MapField("IN01ALIAS")]
        public string alias {get;set;}

        [MapField("IN01CTAGAS")]
        public string ctagas { get; set; }

        [MapField("CuentaContableDescripcion")]
        public string CuentaContableDescripcion { get; set; }

        [MapField("UniMedDescripcion")]
        public string UniMedDescripcion { get; set; }


    }
}
