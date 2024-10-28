using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Pro_Trae_SalidaMPResumida")]
    public class Spu_Pro_Trae_SalidaMPResumida
    {
        [MapField("IN07CODEMP")]
        public string IN07CODEMP { get; set; }

        [MapField("IN07DocIngAA")]
        public string IN07DocIngAA { get; set; }

        [MapField("IN07DocIngMM")]
        public string IN07DocIngMM { get; set; }

        [MapField("IN07DocIngTIPDOC")]
        public string IN07DocIngTIPDOC { get; set; }

        [MapField("IN07DocIngCODDOC")]
        public string IN07DocIngCODDOC { get; set; }

        [MapField("IN07DocIngKEY")]
        public string IN07DocIngKEY { get; set; }

        //Descripcion de articulo                
        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }

        
        [MapField("IN07ORDENTRABAJO")]
        public string IN07ORDENTRABAJO { get; set; }

        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }

        //Descripcion de almacen
        [MapField("in09descripcion")]
        public string in09descripcion { get; set; }   

        [MapField("IN07KEY")]
        public string IN07KEY { get; set; }

        [MapField("IN07NROCAJA")]
        public string IN07NROCAJA { get; set; }

        [MapField("IN07HORASALIDA")]
        public string IN07HORASALIDA { get; set; }

        [MapField("IN07LARGO")]
        public double IN07LARGO { get; set; }

        [MapField("IN07ANCHO")]
        public double IN07ANCHO { get; set; }

        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }

        [MapField("Cantidad")]
        public double Cantidad { get; set; }

        [MapField("Area")]
        public double Area { get; set; }

        [MapField("Volumen")]
        public double Volumen { get; set; }

        [MapField("IN01UNIMED")]
        public string IN01UNIMED { get; set; }

        [MapField("CajaUnica")]
        public string CajaUnica { get; set; }

        [MapField("RedimientoRatio")]
        public double RedimientoRatio { get; set; }
       
    }
}
