using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in01arti")]
    public class CompraArticulo
    {
        [MapField("IN01CODEMP")]
        public string codigoEmpresa {get;set;}
        [MapField("IN01AA")]
        public string anio {get;set;}
        [MapField("IN01KEY")]
        public string codigoArticulo {get;set;}

        [MapField("IN01DESLAR")]
	    public string descripcion {get;set;}

        [MapField("IN01UNIMED")]
        public string unimed {get;set;}

        [MapField("IN01UNIDADEQUI")]
        public string unidadEquivalencia {get;set;}

        [MapField("IN01MONTOEQUI")]
        public double montoEquivalencia {get;set;}

        [MapField("IN01CODPRO")]
        public string codigoProveedor {get;set;}

	    [MapField("IN01MOV")]
        public string movimiento {get;set;}

        [MapField("IN01UNIDADMAYOR")]
        public string unidadMayor {get;set;}

        [MapField("IN01ESTADO")]
        public string estado {get;set;}

        [MapField("IN01TIPO")]
        public string tipo {get;set;}

        [MapField("IN01TIPOPLACTAS")]
        public string tipoPlactas { get; set; }


        public string codigoNaturaleza { get; set; }
    }
}
