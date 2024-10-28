using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Cos_Trae_GastosDistribuidos")]
    public class Spu_Cos_Trae_GastosDistribuidos
    {
        [MapField("FlagDistribucion")]
        public string FlagDistribucion { get; set; }
        [MapField("COS01ACTIVIDADORIGEN")]
        public string COS01ACTIVIDADORIGEN { get; set; }
        [MapField("COS01ACTIVIDADORIGENDESC")]
        public string COS01ACTIVIDADORIGENDESC { get; set; }
        [MapField("COS01ACTIVIDADDESTINO")]
        public string COS01ACTIVIDADDESTINO { get; set; }
        [MapField("COS01ACTIVIDADDESTINODESC")]
        public string COS01ACTIVIDADDESTINODESC { get; set; }
        [MapField("COS01PORCENTAJE")]
        public double COS01PORCENTAJE { get; set; }
        [MapField("COS01IMPORTEORIGINAL")]
        public double COS01IMPORTEORIGINAL { get; set; }
        [MapField("COS01CTACBLECOD")]
        public string COS01CTACBLECOD { get; set; }
        [MapField("COS01CTACBLEDESC")]
        public string COS01CTACBLEDESC { get; set; }
        [MapField("COS01TIPOCOSTOCOD")]
        public string COS01TIPOCOSTOCOD { get; set; }
        [MapField("COS01TIPOCOSTODESC")]
        public string COS01TIPOCOSTODESC { get; set; }
        [MapField("COS01COSTOCOD")]
        public string COS01COSTOCOD { get; set; }
        [MapField("COS01COSTODESC")]
        public string COS01COSTODESC { get; set; }
        [MapField("COS01IMPORTE")]
        public double COS01IMPORTE { get; set; }
        [MapField("COS01FIJOOVARIABLE")]
        public string COS01FIJOOVARIABLE { get; set; }
        [MapField("COS01DIRECTOOINDIRECTO")]
        public string COS01DIRECTOOINDIRECTO { get; set; }
    }
}
