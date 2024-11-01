﻿using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    public class ComprasArticuloAlmacen
    {

        [MapField("In04key")]
        public string In04key {get;set;}
        
        [MapField("In04CodAlm")]
        public string In04CodAlm { get; set; }
        
        [MapField("In09Descripcion")]
        public string In09Descripcion { get; set; }

        [MapField("In04Ubicac")]
        public string In04Ubicac { get; set; }

        [MapField("In04stock")]
        public double In04stock { get; set; }

    }
}
