

using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities.DTO
{
    [TableName("Spu_Pro_Trae_PPStock")]
    public class Spu_Pro_Trae_PPStock
    {

        [MapField("codigo")]
        public string codigo { get; set; }
        [MapField("descripcion")]
        public string descripcion { get; set; }
        [MapField("unidadmedida")]
        public string unidadmedida { get; set; }
        [MapField("nrocaja")]
        public string nrocaja { get; set; }
        [MapField("DocingAA")]
        public string DocingAA { get; set; }
        [MapField("DocingMM")]
        public string DocingMM { get; set; }
        [MapField("DocingTD")]
        public string DocingTD { get; set; }
        [MapField("DocingCD")]
        public string DocingCD { get; set; }
        [MapField("DocingPT")]
        public string DocingPT { get; set; }
        [MapField("DocingNO")]
        public string DocingNO { get; set; }
        [MapField("CanPiezas")]
        public string CanPiezas { get; set; }
        [MapField("CanArea")]
        public string CanArea { get; set; }
        [MapField("ClientePedidonro")]
        public string ClientePedidonro { get; set; }

        [MapField("Cliente")]
        public string Cliente { get; set; }

        [MapField("AreaxUni")]
        public string AreaxUni { get; set; }
        
        [MapField("in09codigo")]
        public string in09codigo { get; set; }

        [MapField("in09descripcion")]
        public string in09descripcion { get; set; }

        [MapField("Largo")]
        public double Largo { get; set; }

        [MapField("Ancho")]
        public double Ancho { get; set; }

        [MapField("Alto")]
        public double Alto { get; set; }

        [MapField("Orden")]
        public double Orden { get; set; }

        [MapField("PPEspesor")]
        public double PPEspesor { get; set; }

        [MapField("PPLargo")]
        public double PPLargo { get; set; }

        [MapField("PPAncho")]
        public double PPAncho { get; set; }

        [MapField("codigoOperador")]
        public string codigoOperador { get; set; }

        [MapField("OrdenTrabajo")]
        public string OrdenTrabajo { get; set; }


        [MapField("FechaIngresoUltimo")]
        public Nullable<DateTime> FechaIngresoUltimo { get; set; }
        [MapField("FechaIngresoUltimotexto")]
        public string FechaIngresoUltimotexto { get; set; }
        [MapField("TransaDesc")]
        public string TransaDesc { get; set; }

        [MapField("HoraSalida")]
        public string HoraSalida { get; set; }

        public string chkSelect { get; set; }

        public string almptxdefecto { get; set; }
       

    }
}
