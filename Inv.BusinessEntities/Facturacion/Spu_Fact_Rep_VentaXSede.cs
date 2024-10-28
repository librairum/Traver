using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;
using BLToolkit.Data;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Rep_VentaXSede")]
    public class Spu_Fact_Rep_VentaXSede
    {
        [MapField("DocTipo")]
        public string DocTipo {get;set;}

        [MapField("DocNumero")]
        public string DocNumero {get;set;}

        [MapField("Anio")]
        public string Anio {get;set;}

        [MapField("Mes")]
        public string Mes  {get;set;}

        [MapField("Moneda")]
        public string Moneda {get;set;}
        [MapField("ClienteNombre")]
        public string  ClienteNombre {get; set;}
        [MapField("Estado")]
        public string Estado {get;set;}
        [MapField("TiendaDesc")]
        public string TiendaDesc {get; set; }
        
        [MapField("TipoDeVenta")]
        public string TipoDeVenta { get; set; }
        
        [MapField("SubtotalSoles")]
        public double SubtotalSoles {get;set;}

        [MapField("IgvSoles")]
        public double IgvSoles {get;set;}

        [MapField("totalSoles")]
        public double totalSoles {get;set;}

        [MapField("SubtotalDolares")]
        public double SubtotalDolares {get;set;}

        [MapField("IgvDolares")]
        public double IgvDolares {get;set;}

        [MapField("totalDolares")]
        public double totalDolares {get;set;}

        public string DocumentoEstado { get; set; }
    }
}
