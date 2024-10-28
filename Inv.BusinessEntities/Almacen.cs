using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in09alma")]
    public class Almacen
    {
        [MapField("in09codemp")]
        public string in09codemp { get; set; }
        [MapField("in09codigo")]
        public string in09codigo { get; set; }
        [MapField("in09descripcion")]
        public string in09descripcion { get; set; }
        [MapField("in09ubicacion")]
        public string in09ubicacion { get; set; }
        [MapField("In09Cuenta")]
        public string In09Cuenta { get; set; }
        [MapField("In09DebHab")]
        public string In09DebHab { get; set; }
        [MapField("in09PRODNATURALEZA")]
        public string in09PRODNATURALEZA { get; set; }
        [MapField("in09flagmaterecuperacion")]
        public string in09flagmaterecuperacion { get; set; }
        [MapField("in09flagMatRechazado")]
        public string in09flagMatRechazado { get; set; }
        public string flagRecuperacion { get; set; }
        
        [MapField("In09FlagConsiderarProduccion")]
        public string In09FlagConsiderarProduccion { get; set; }
        
        
        
        [MapField("in09flagProductoBueno")]
        public string in09flagProductoBueno	 {get;set;}
        
        [MapField("in09lineacod")]
        public string in09lineacod	{get;set;}
        
        [MapField("in09lineaDesc")]
        public string in09lineaDesc { get; set; }

        
        [MapField("in09actividadnivel1cod")]
        public string in09actividadnivel1cod { get; set; }

        [MapField("in09ActNivel1Desc")]
        public string in09ActNivel1Desc { get; set; }


        
        
        [MapField("in09FlagCostear")]
        public string in09FlagCostear { get; set; }
    }
}
