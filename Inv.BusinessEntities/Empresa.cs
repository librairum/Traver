using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Inv.BusinessEntities
{
    [TableName("Empresa")]
   public class Empresa
    {
        [MapField("Codigo")]
        public string Codigo { get; set; }

        [MapField("Nombre")]
        public string Nombre { get; set; }

        [MapField("Sistema")]
        public string Sistema { get; set; }

        [MapField("Direccion")]
        public string Direccion { get; set; }

        [MapField("Representante")]
        public string Representante { get; set; }

        [MapField("Cargo")]
        public string Cargo { get; set; }

        [MapField("Ruc")]
        public string Ruc { get; set; }

        [MapField("Igv")]
        public int Igv { get; set; }

        [MapField("Ejercicio")]
        public string Ejercicio { get; set; }

        [MapField("Clave")]
        public string Clave { get; set; }

        [MapField("CodEmpContabilidad")]
        public string CodEmpContabilidad { get; set; }

        [MapField("CodEmpAlmacen")]
        public string CodEmpAlmacen { get; set; }

        [MapField("DepartamentoCod")]
        public string DepartamentoCod { get; set; }

        [MapField("DepaDescrpicion")]
        public string DepaDescrpicion { get; set; }

        [MapField("ProvinciaCod")]
        public string ProvinciaCod { get; set; }

        [MapField("ProviDescripcion")]
        public string ProviDescripcion { get; set; }

        [MapField("DistritoCod")]
        public string DistritoCod { get; set; }

        [MapField("DisDescripcion")]
        public string DisDescripcion { get; set; }

        [MapField("urbanizacion")]
        public string urbanizacion { get; set; }

        [MapField("CorreoFacturaElectonica")]
        public string CorreoFacturaElectonica { get; set; }
        

        [MapField("DescAlmacen")]
        public string  DescAlmacen {get;set;}

        [MapField("DesCtaCtble")]
        public string DesCtaCtble {get;set;}

        [MapField("ImpRetencion")]
        public string ImpRetencion {get;set;}

        [MapField("FlagRetencion")]
        public string FlagRetencion { get; set; }

        [MapField("modifTC")]
        public string modifTC { get; set; }

        [MapField("BiMoneda")]
        public string BiMoneda { get; set; }


    }
}
