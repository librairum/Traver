using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Fac_Rep_ClienteAnalisis")]
    public class DocumentoVentasEmitido
    {
        [MapField("FAC01COD")]
        public string FAC01COD { get; set; }
        [MapField("FAC04NUMDOC")]
        public string FAC04NUMDOC { get; set; }
        [MapField("FAC04FECHA")]
        public Nullable<DateTime> FAC04FECHA { get; set; }
        public string FAC04CODCLI { get; set; }
        public string FAC04MONEDA { get; set; }


        public double SubtotalSoles { get; set; }
        public double IgvSoles { get; set; }
        public double totalSoles { get; set; }

        public double SubtotalDolares { get; set; }
        public double IgvDolares { get; set; }
        public double totalDolares { get; set; }

        public double SubtotalOtros { get; set; }
        public double IgvOtros { get; set; }
        public double totalOtros { get; set; }



        public string FAC04GUIAS { get; set; }
        //---- Plantilla documento      
        public string FAC03COD { get; set; }
        public string FAC02COD { get; set; }
        public string FAC03DESC { get; set; }

        //-- Tipo de Documento      
        //tipdoc.FAC01DESC,      
        public string FAC01DESC { get; set; }
        //-- Cliente         
        public string ClienteNombre { get; set; }
        //-- Estado Documento      

        public string DocumentoEstado { get; set; }
        public string FAC04GLOSA { get; set; }
        public string FAC04ORDENCOMPRA { get; set; }
        public Nullable<DateTime> FAC04FECORDCOMPRA { get; set; }
        public string FAC04TIENDA { get; set; }
        public double FAC04TIPCAMBIO { get; set; }
        public double FAC04IGV { get; set; }
        

    }
}
