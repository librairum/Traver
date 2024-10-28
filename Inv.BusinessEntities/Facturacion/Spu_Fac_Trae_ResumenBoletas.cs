using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inv.DataAccess
{
    public class Spu_Fac_Trae_ResumenBoletas
    {

        public string CodigoCliente {get;set;}
        public string NumeroDocumento {get;set;}
        public string ResumenId { get; set; }        
        public string FecEmisionComprobante {get;set;}
        public string FecGeneraResumen { get; set; }        
        public string NombreCliente { get; set; }
        public string EstadoProcesoBizlink { get; set; }
        public string EstadoProcesoSUNAT { get; set; }
        public string SubTotal { get; set; }
        public string Igv { get; set; }
        public string Total { get; set; }
        public string EstadoResumen { get; set; }
        public string CodTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
    }
}
