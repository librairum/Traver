using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    [TableName("FAC02_PLANTILLA")]
    public class Plantilla
    {
        [MapField("FAC02CODEMP")]
        public string FAC02CODEMP { get; set; }
        [MapField("FAC02COD")]
        public string FAC02COD { get; set; }
        [MapField("FAC02DESC")]
        public string FAC02DESC { get; set; }

		// Plantilla para factura electronica
        [MapField("Fac70PlantillaFETipDoc")]
        public string  Fac70PlantillaFETipDoc	{get;set;}

        [MapField("PlantillaFETipDocDesc")]
        public string PlantillaFETipDocDesc	 {get;set;}

        [MapField("Fac70PlantillaFECod")]
        public string Fac70PlantillaFECod	 {get;set;}

        [MapField("Fac70PlantillaFEDesc")]
        public string Fac70PlantillaFEDesc { get; set; }

        // Campos apra usar en Spu_Fact_Trae_Plantillas
        [MapField("TipoDocuCod")]
        public string TipoDocuCod {get;set;}
        // Campos apra usar en Spu_Fact_Trae_Plantillas
        [MapField("TipoDocuDesc")]
        public string TipoDocuDesc { get; set; }

        // Campos para usar en Spu_Fact_Trae_PlantixCamposOpcionalesDetalle
        [MapField("Fac72PlantillaFETipDoc")]
        public string Fac72PlantillaFETipDoc { get; set; }
        // Campos para usar en Spu_Fact_Trae_PlantixCamposOpcionalesDetalle
        [MapField("FAC71TablaDesc")]
        public string FAC71TablaDesc { get; set; }

        // Campos para usar en Spu_Fact_Trae_PlantixCamposOpcionalesDetalle
        [MapField("FAC71CampoFEDesc")]
        public string FAC71CampoFEDesc { get; set; }

        // Campos para usar en Spu_Fact_Trae_PlantixCamposOpcionalesDetalle
        [MapField("FAC72CampoFEvalorDefecto")]
        public string FAC72CampoFEvalorDefecto { get; set; }
    }
}
