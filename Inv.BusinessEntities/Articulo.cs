using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in01arti")]

    public class Articulo
    {
        [MapField("IN01CODEMP")]
        public string IN01CODEMP { get; set; }

        [MapField("IN01AA")]
        public string IN01AA { get; set; }

        [MapField("IN01KEY")]
        public string IN01KEY { get; set; }

        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }
        
        [MapField("IN01UNIMED")]
        public string IN01UNIMED { get; set; }

        [MapField("IN01UNIDADEQUI")]
        public string IN01UNIDADEQUI { get; set; }

        [MapField("IN01MONTOEQUI")]
        public double IN01MONTOEQUI { get; set; }

        [MapField("IN01CODPRO")]
        public string IN01CODPRO { get; set; }
                                                
        [MapField("IN01FLAALM")]
        public string IN01FLAALM { get; set; }

        [MapField("IN01FLADES")]
        public string IN01FLADES { get; set; }

        [MapField("IN01FLAFAB")]
        public string IN01FLAFAB { get; set; }

        [MapField("IN01FECMAT")]
        public string IN01FECMAT { get; set; }
                
        [MapField("IN01CTAINGRESO")]
        public string IN01CTAINGRESO { get; set; }

        [MapField("IN01CTAEGRESO")]
        public string IN01CTAEGRESO { get; set; }
        
        [MapField("IN01MOV")]
        public string IN01MOV { get; set; }
        
        [MapField("IN01CTAGTO")]
        public string IN01CTAGTO { get; set; }
        
        [MapField("IN01CTAING")]
        public string IN01CTAING { get; set; }

		[MapField("IN01FLAGVEN")]
        public string IN01FLAGVEN { get; set; }

        [MapField("IN01UNIDADMAYOR")]
        public string IN01UNIDADMAYOR { get; set; }
        
        [MapField("In01CtaContable")]
        public string In01CtaContable { get; set; }
        
        [MapField("In01DebeHaber")]
        public string In01DebeHaber { get; set; }
        
        [MapField("In01RubPro")]
        public string In01RubPro { get; set; }

        [MapField("In01Especial")]
        public string In01Especial { get; set; }
        
        [MapField("IN01ESTADO")]
        public string IN01ESTADO { get; set; }
        
        [MapField("IN01TIPO")]
        public string IN01TIPO { get; set; }

        [MapField("IN01tipoarticulo")]
        public string IN01tipoarticulo { get; set; }

        [MapField("IN01FLAGTIPCALAREA")]
        public string IN01FLAGTIPCALAREA { get; set; }

        // Detalle de sus caracteristicas
        [MapField("tipo")]
        public string tipo { get; set; }

        [MapField("color")]
        public string color { get; set; }

        [MapField("tonalidad")]
        public string tonalidad { get; set; }

        [MapField("formato")]
        public string formato { get; set; }

        [MapField("acabado")]
        public string acabado { get; set; }

        [MapField("relleno")]
        public string relleno { get; set; }

        [MapField("borde")]
        public string borde { get; set; }

        [MapField("calidad")]
        public string calidad { get; set; }

        [MapField("modelo")]
        public string modelo { get; set; }

        // Medidas
        [MapField("Largonum")]
        public double largonum { get; set; }

        [MapField("Anchonum")]
        public double anchonum { get; set; }

        [MapField("Espesornum")]
        public double espesornum { get; set; }

        // Medidas
        [MapField("Largotext")]
        public string largotext { get; set; }

        [MapField("Anchotext")]
        public string anchotext { get; set; }

        [MapField("Espesortext")]
        public string espesortext { get; set; }

        //

        [MapField("Stock")]
        public double Stock{ get; set; }

        [MapField("StockRealArea")]
        public double StockRealArea { get; set; }

        [MapField("StockReservaArea")]
        public double StockReservaArea { get; set; }

        [MapField("StockProduccionArea")]
        public double StockProduccionArea { get; set; }

        [MapField("StockDisponibleArea")]
        public double StockDisponibleArea { get; set; }

        [MapField("CajasCantidad")]
        public double CajasCantidad { get; set; }
        
        //
        [MapField("AreaxUni")]
        public double AreaxUni { get; set; }
        [MapField("IN01PRODNATURALEZA")]
        public string IN01PRODNATURALEZA { get; set; }

        // Para Materia Prima
        [MapField("StockRealVolumen")]
        public double StockRealVolumen { get; set; }

        [MapField("BloquesCantidad")]
        public double BloquesCantidad { get; set; }

        [MapField("IN01DESINGLES")]
        public string IN01DESINGLES {get;set;}

        [MapField("IN01DESESPANIOL")]
        public string IN01DESESPANIOL {get;set;}

        [MapField("IN01UNIMEDVENTA")]
        public string IN01UNIMEDVENTA { get; set; }

        [MapField("UniventaDesc")]
        public string UniventaDesc { get; set; }

        [MapField("in01Ubicacion")]
        public string in01Ubicacion { get; set; }

        #region "Compra"
        
        public string CompraEstadoDescripcion { get; set; }

        public string CompraTipoDescripcion { get; set; }

        [MapField("IN01TIPOPLACTAS")]
        public string IN01TIPOPLACTAS {get;set;}

        [MapField("In01key1")]
        public string In01key1 { get; set; }

        #endregion

    }

   
}