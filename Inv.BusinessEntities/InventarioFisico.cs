using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In04InvFisico")]
    public class InventarioFisico
    {
        [MapField("IN04CODEMP")]
        public string IN04CODEMP { get; set; }
        [MapField("IN04AA")]
        public string IN04AA { get; set; }
        [MapField("IN04FECINV")]
        public Nullable<DateTime> IN04FECINV { get; set; }
        [MapField("IN04CODALM")]
        public string IN04CODALM { get; set; }
        [MapField("IN04KEY")]
        public string IN04KEY { get; set; }
        [MapField("IN04ITEM")]
        public int IN04ITEM { get; set; }
        [MapField("IN04CAJA")]
        public string IN04CAJA { get; set; }
        [MapField("IN04CANTFISICA")]
        public double IN04CANTFISICA { get; set; }
        [MapField("IN04CANTANTERIOR")]
        public double IN04CANTANTERIOR { get; set; }
        [MapField("IN04CANTINGRESO")]
        public double IN04CANTINGRESO { get; set; }
        [MapField("IN04CANTSALIDA")]
        public double IN04CANTSALIDA { get; set; }
        [MapField("IN04STOCK")]
        public double IN04STOCK { get; set; }
        // Datos relacionados
        [MapField("AlmacenColumna")]
        public string  AlmacenColumna { get; set; }
        [MapField("In07ubicacion")]
        public string In07ubicacion { get; set; }
        [MapField("in01deslar")]
        public string in01deslar { get; set; }
        [MapField("in01unimed")]
        public string in01unimed { get; set; }

        [MapField("in04observacion")]
        public string in04observacion {get;set;}
        
        [MapField("in04estado")]
        public string in04estado { get; set; }
        public string estadoInventarioDesc { get; set; }

        [MapField("in09descripcion")]
        public string in09descripcion { get; set; }


        public int ItemCorrelativo { get; set; }

    }
}