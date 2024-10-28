using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_StockDetMP")]
    public class Spu_Inv_Trae_StockDetMP
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

        [MapField("IN07FECDOC")]
        public string IN07FECDOC { get; set; }
        
        [MapField("IngresoCantidad")]
        public double IngresoCantidad { get; set; }

        [MapField("SalidaCantidad")]
        public double SalidaCantidad { get; set; }

        [MapField("IngresoCantidadVolumen")]
        public double IngresoCantidadVolumen { get; set; }

        [MapField("SalidaCantidadVolumen")]
        public double SalidaCantidadVolumen { get; set; }

        [MapField("StockRealVolumen")]
        public double StockRealVolumen { get; set; }

        [MapField("IN07LARGO")]
        public double IN07LARGO { get; set; }

        [MapField("IN07ANCHO")]
        public double IN07ANCHO { get; set; }

        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }

        [MapField("VolumenPlanta")]
        public double VolumenPlanta { get; set; }

        [MapField("IN07LARGOCAN")]
        public double IN07LARGOCAN { get; set; }

        [MapField("IN07ANCHOCAN")]
        public double IN07ANCHOCAN { get; set; }

        [MapField("IN07ALTOCAN")]
        public double IN07ALTOCAN { get; set; }

        [MapField("VolumenCantera")]
        public double VolumenCantera { get; set; }

        [MapField("NROBLOQUE")]
        public string NROBLOQUE { get; set; }

        [MapField("IN07CODBLOQUEEMP")]
        public string IN07CODBLOQUEEMP { get; set; }

        [MapField("IN07CODBLOQUEPROV")]
        public string IN07CODBLOQUEPROV { get; set; }

        [MapField("in07observacion")]
        public string in07observacion { get; set; }

        [MapField("ContratistaNombre")]
        public string ContratistaNombre { get; set; }

        [MapField("CanteraNombre")]
        public string CanteraNombre { get; set; }

        [MapField("ProvBloqueNombre")]
        public string ProvBloqueNombre { get; set; }

        [MapField("DocRespaldoNro")]
        public string DocRespaldoNro { get; set; }

        [MapField("in09descripcion")]
        public string in09descripcion { get; set; }
        [MapField("IN07KEY")]
        public string IN07KEY { get; set; }

    }
}
