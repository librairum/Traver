using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("Co05docu")]
    public class Detraccionxpagar
    {
        [MapField("CO05CODCTE")]
        public string CO05CODCTE { get; set; }
        [MapField("ccm02nom")]
        public string ccm02nom { get; set; }

        [MapField("CO05TIPDOC")]
        public string CO05TIPDOC { get; set; }

        [MapField("CO05NRODOC")]
        public string CO05NRODOC { get; set; }
        [MapField("CO05FECHA")]
        public DateTime CO05FECHA { get; set; }

        [MapField("CO05IMPORT")]
        public float CO05IMPORT { get; set; }
        [MapField("CO05DETRATIPOPERACION")]
        public string CO05DETRATIPOPERACION { get; set; }
        [MapField("CO05DETRATIPOSERVICIO")]
        public string CO05DETRATIPOSERVICIO { get; set; }

        [MapField("CO05DETRAPORCENTAJE")]
        public float CO05DETRAPORCENTAJE { get; set; }

        [MapField("CO05DETRAIMPORTE")]
        public float CO05DETRAIMPORTE { get; set; }
        [MapField("ccm02nroctadetraccion")]
        public string ccm02nroctadetraccion { get; set; }
        //[MapField("co01codigo")]
        //public string Codigo { get; set; }
        //[MapField("co01descripcion")]
        //public string Descripcion { get; set; }
        //[MapField("co01Tasaretencion")]
        //public double Porcentaje { get; set; }
        //public double Importe { get; set; }
    }
}
