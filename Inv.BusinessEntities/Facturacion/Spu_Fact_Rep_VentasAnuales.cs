using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Data;
using BLToolkit.Mapping;
namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Rep_VentasAnuales")]
    public class Spu_Fact_Rep_VentasAnuales
    {
        [MapField("FAC04AA")]
        public string anio {get;set;} 
        [MapField("FAC04MM")]
        public string mes {get;set;}
        [MapField("FAC04NUMDOC")]
        public string numeroDocumento {get;set;}
        [MapField("FAC04FECHA")]
        public Nullable<DateTime> fecha  {get;set;}
        [MapField("FAC04CODCLI")]
        public string codigoCliente {get;set;}
        [MapField("FAC04MONEDA")]
        public string codigoMoneda {get;set;}
        [MapField("DocTipo")]
        public string documentoTipo {get;set;}
        [MapField("ClienteNombre")]
        public string clienteNombre {get;set;}
        [MapField("Estado")]
        public string estado {get;set;}
        [MapField("FAC05CANTIDAD")]
        public double cantidad {get;set;}
         
        [MapField("FAC05CODFACDET")]
        public int codigoDetalle {get;set;}
        [MapField("FAC05CODPROD")]
        public string codigoProducto {get;set;}
        [MapField("FAC05DESCPROD")]
        public string descripcionProducto {get;set;}
        [MapField("FAC05NROCAJA")]
        public double nroCaja {get;set;}
        [MapField("FAC05PESO")]
        public double peso {get;set;}
        [MapField("FAC05PRECIO")]
        public double precio  {get;set;}
        [MapField("FAC05SUBTOTAL")]
        public double subTotal {get;set;}

        [MapField("FAC05UNIMED")]
        public string  unidadMedida {get;set;}

	
	

    }
}
