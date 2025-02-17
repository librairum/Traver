﻿using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_PtStock")]
    public class Spu_Inv_Trae_PtStock
    {
        [MapField("codigo")]
        public string codigo { get; set; }
        
        [MapField("descripcion")]
        public string descripcion { get; set; }
        
        [MapField("UnidadMedida")]
        public string UnidadMedida { get; set; }

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
        public double DocingNO { get; set; }

        [MapField("CanPiezas")]
        public double CanPiezas { get; set; }

        [MapField("CanArea")]
        public double CanArea { get; set; }

        [MapField("ClientePedidonro")]
        public string ClientePedidonro { get; set; }

        [MapField("Cliente")]
        public string Cliente { get; set; }

        [MapField("AreaxUni")]
        public double AreaxUni { get; set; }

        public string clienteNombre { get; set; }

        [MapField("IN07LARGO")]
        public double IN07LARGO {get;set;}
	    
        [MapField("IN07ANCHO")]
        public double IN07ANCHO {get;set;}
        
        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }

        [MapField("IN07CALIDADMP")]
        public string IN07CALIDADMP { get; set; }

    }
}
