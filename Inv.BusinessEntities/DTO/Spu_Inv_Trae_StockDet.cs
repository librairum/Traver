using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_StockDet")]
    public class Spu_Inv_Trae_StockDet
    {
        [MapField("IN07CODEMP")]
        public string IN07CODEMP { get; set; }
        
        [MapField("IN07AA")]
        public string IN07AA { get; set; }
        
        [MapField("IN07MM")]
        public string IN07MM { get; set; }

        [MapField("IN07TIPDOC")]
        public string IN07TIPDOC { get; set; }

        [MapField("IN07CODDOC")]
        public string IN07CODDOC { get; set; }

        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }

        [MapField("IN07UNIMED")]
        public string IN07UNIMED { get; set; }

        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA { get; set; }

        [MapField("IngresoCantidad")]
        public double IngresoCantidad { get; set; }

        [MapField("SalidaCantidad")]
        public double SalidaCantidad { get; set; }

        [MapField("ReservaCantidad")]
        public double ReservaCantidad { get; set; }

        [MapField("IngresoCantidadArea")]
        public double IngresoCantidadArea { get; set; }

        [MapField("SalidaCantidadArea")]
        public double SalidaCantidadArea { get; set; }

        [MapField("StockRealArea")]
        public double StockRealArea { get; set; }

        [MapField("StockProduccionArea")]
        public double StockProduccionArea { get; set; }

        [MapField("StockReservaArea")]
        public double StockReservaArea { get; set; }

        [MapField("StockDisponibleArea")]
        public double StockDisponibleArea { get; set; }

        [MapField("Cliente")]
        public string Cliente { get; set; }

        [MapField("ProvMP")]
        public string ProvMP { get; set; }
        

        [MapField("ClientePedidonro")]
        public string ClientePedidonro { get; set; }

        [MapField("Ubicacion")]
        public string Ubicacion { get; set; }

        [MapField("IN07ANCHO")]
        public double IN07ANCHO { get; set; }

        [MapField("IN07LARGO")]
        public double IN07LARGO { get; set; }

        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }

        [MapField("in07observacion")]
        public string in07observacion { get; set; }
    }
}
