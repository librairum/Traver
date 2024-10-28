using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
     public class Spu_Inv_Trae_StockDetPP
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

         [MapField("in09descripcion")]
         public string in09descripcion { get; set; }

         [MapField("IngresoCantidad")]
         public string IngresoCantidad { get; set; }

         [MapField("SalidaCantidad")]
         public string SalidaCantidad { get; set; }



   
         [MapField("IngresoCantidadArea")]
         public string IngresoCantidadArea { get; set; }

         [MapField("SalidaCantidadArea")]
         public string SalidaCantidadArea { get; set; }
         
         [MapField("IngresoCantidadVolumen")]
         public string IngresoCantidadVolumen { get; set; }

         [MapField("SalidaCantidadVolumen")]
         public string SalidaCantidadVolumen { get; set; }
         

         [MapField("StockReal")]
         public double StockReal { get; set; }

         [MapField("StockRealArea")]
         public double StockRealArea { get; set; }
         [MapField("StockRealVolumen")]
         public string StockRealVolumen { get; set; }

         [MapField("IN07LARGO")]
         public string IN07LARGO { get; set; }
         [MapField("IN07ANCHO")]
         public string IN07ANCHO { get; set; }
         [MapField("IN07ALTO")]
         public string IN07ALTO { get; set; }

         [MapField("NROCanastilla")]
         public string NROCanastilla { get; set; }
         [MapField("in07observacion")]
         public string in07observacion { get; set; }
         [MapField("DocRespaldoNro")]
         public string DocRespaldoNro { get; set; }

         //campos para Sp de Traer Canastillas PP
         [MapField("in01key")]
         public string in01key {get;set;}
         [MapField("IN01DESLAR")]
         public string IN01DESLAR { get; set; }
         [MapField("IN01UNIMED")]
         public string IN01UNIMED {get;set;}
         [MapField("FechaIngresoUltima")]
         public string FechaIngresoUltima { get; set; }
         [MapField("Tipo")]
         public string Tipo { get; set; }
         [MapField("Color")]
         public string Color { get; set; }
         [MapField("Tonalidad")]
         public string Tonalidad { get; set; }
         [MapField("Formato")]
         public string Formato { get; set; }
         [MapField("Modelo")]
         public string Modelo { get; set; }
         
         [MapField("TransaDescripcion")]
         public string TransaDescripcion {get;set;}
         
        [MapField("MovimientoHoraSalida")]
        public string MovimientoHoraSalida { get; set; }
        [MapField("ProductoNombre")]
        public string ProductoNombre { get; set; }

        
        [MapField("IN07ORDENTRABAJO")]
        public string IN07ORDENTRABAJO { get; set; }
        [MapField("IN07ORDEN")]
        public string IN07ORDEN { get; set; }

    }
}
