using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Data;
using BLToolkit.Mapping;
namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Trae_VentasContabilidad")]
    public class Spu_Fact_Trae_VentasContabilidad
    {
        [MapField("FAC04AA")]
        public string FAC04AA { get; set; }
        [MapField("FAC04MM")]
        public string FAC04MM { get; set; }
        [MapField("FAC01COD")]
        public string FAC01COD {get;set;}
        [MapField("DocTipo")]
        public string DocTipo {get;set;}
        [MapField("FAC04SERIEDOC")]
        public string FAC04SERIEDOC {get;set;}
        [MapField("ClasificacionVenta")]
        public string ClasificacionVenta {get;set;}
        [MapField("TipoDeVenta")]
        public string TipoDeVenta {get;set;}
        [MapField("FAC04NUMDOC")]
        public string FAC04NUMDOC {get;set;}
        [MapField("FAC04FECHA")]
        public Nullable<DateTime> FAC04FECHA  {get;set;}
        [MapField("FAC04CODCLI")]
        public string FAC04CODCLI {get;set;}
        [MapField("ClienteNombre")]
        public string ClienteNombre {get;set;}
        [MapField("OBSERVACION")]
        public string OBSERVACION {get;set;}
        [MapField("Guias")]
        public string Guias {get;set;}
        [MapField("O_COMPRA")]
        public string O_COMPRA  {get;set;}
        [MapField("LiquidacionNro")]
        public string LiquidacionNro {get;set;}
        [MapField("VoucherContable")]
        public string  VoucherContable {get;set;}
        [MapField("PaisDestino")]
        public string  PaisDestino {get;set;}
        [MapField("DOCMODTIPDOC")]
        public string  DOCMODTIPDOC {get;set;}
        [MapField("FAC04DOCMODNRO")]
        public string  FAC04DOCMODNRO {get;set;}
        [MapField("DOCMODFECHA")]
        public Nullable<DateTime> DOCMODFECHA { get; set; }

	    [MapField("EstadoSunat")]
        public string EstadoSunat { get; set; }
        
        [MapField("Estado")]
        public string Estado { get; set; }
        
        [MapField("FAC05CODFACDET")]
        public string FAC05CODFACDET { get; set; }
        
        [MapField("FAC05CODPROD")]
        public string FAC05CODPROD { get; set; }
        
        [MapField("FAC05DESCPROD")]
        public string FAC05DESCPROD { get; set; }
        
        [MapField("ProductoTipo")]
        public string  ProductoTipo {get;set;}
        
        [MapField("ProductoClasificacion")]
        public string  ProductoClasificacion {get;set;}

        [MapField("UNIMED")]
        public string  UNIMED {get;set;}
	    
        [MapField("CANTIDAD")]
        public double CANTIDAD { get; set; }
        
        [MapField("NROCAJAS")]
        public double NROCAJAS { get; set; }

        [MapField("NROETIQUETAS")]
        public double NROETIQUETAS { get; set; }
        
        [MapField("CANTIDAD_MT2oTM")]
        public double CANTIDAD_MT2oTM { get; set; }
        
        [MapField("TMSegun_MT")]
        public double TMSegun_MT { get; set; }
        
        [MapField("CANTIDAD_OtrasUniMed")]
        public double CANTIDAD_OtrasUniMed { get; set; }
        
        [MapField("FAC04MONEDA")]
        public string  FAC04MONEDA {get;set;}
        
        [MapField("FAC04TIPCAMBIO")]
        public double FAC04TIPCAMBIO { get; set; }
	
        [MapField("PRECIO_ORI")]
        public double PRECIO_ORI { get; set; }
        
        [MapField("DSCTO_ORI")]
        public double DSCTO_ORI { get; set; }
        
        [MapField("IGV_ORI")]
        public double IGV_ORI { get; set; }
        
        [MapField("SUBTOTAL_ORI")]
        public double SUBTOTAL_ORI { get; set; }
        
        [MapField("TOTAL_ORI")]
        public double TOTAL_ORI { get; set; }
        
        [MapField("PRECIO_SOLES")]
        public double PRECIO_SOLES { get; set; }
        
        [MapField("DSCTO_SOLES")]
        public double DSCTO_SOLES { get; set; }
        
        [MapField("IGV_SOLES")]
        public double IGV_SOLES { get; set; }
        
        [MapField("SUBTOTAL_SOLES")]
        public double SUBTOTAL_SOLES { get; set; }
        
        [MapField("TOTAL_SOLES")]
        public double TOTAL_SOLES { get; set; }
        
        [MapField("PRECIO_DOL")]
        public double PRECIO_DOL { get; set; }
        
        [MapField("DSCTO_DOL")]
        public double DSCTO_DOL { get; set; }
        
        [MapField("IGV_DOL")]
        public double IGV_DOL { get; set; }
        
        [MapField("SUBTOTAL_DOL")]
        public double SUBTOTAL_DOL { get; set; }
        
        [MapField("TOTAL_DOL")]
        public double TOTAL_DOL { get; set; }

        [MapField("FAC05PESO")]
        public double FAC05PESO { get; set; }

        [MapField("FAC05NROCAJA")]
        public string FAC05NROCAJA { get; set; }
        
        [MapField("FAC05GUIATIPDOC")]
        public string FAC05GUIATIPDOC { get; set; }
        
        [MapField("FAC05GUIANUMERO")]
        public string FAC05GUIANUMERO { get; set; }
        
        [MapField("FAC05GUIAITEM")]
        public int FAC05GUIAITEM { get; set; }
        
        [MapField("Color")]
        public string Color { get; set; }
        
        [MapField("Cantera")]
        public string Cantera { get; set; }
        
        [MapField("CanteraDesc")]
        public string CanteraDesc { get; set; }

        [MapField("VendedorNombre")]
        public string VendedorNombre { get; set; }
        [MapField("NroDeEtiquetas")]
        public float NroDeEtiquetas { get; set; }

    }
}
