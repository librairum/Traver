using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("CO26PAGODETRACCION")]
    public class DetraccionDet
    {
        [MapField("CO26CODEMP")]
        public string CO26CODEMP { get; set; }
        [MapField("CO26AA")]
        public string CO26AA { get; set; }
        [MapField("CO26MES")]
        public string CO26MES { get; set; }
        [MapField("CO26NUMLOTE")]
        public string CO26NUMLOTE { get; set; }
        [MapField("CO26FECHA")]
        public DateTime CO26FECHA { get; set; }
        [MapField("CO26RANFECINI")]
        public DateTime CO26RANFECINI { get; set; }
        [MapField("CO26RANFECFIN")]
        public DateTime CO26RANFECFIN { get; set; }
        [MapField("CO26NUMPROFORMA")]
        public string CO26NUMPROFORMA { get; set; }
        [MapField("CO26RUC")]
        public string CO26RUC { get; set; }
        [MapField("CO26TIPDOC")]
        public string CO26TIPDOC { get; set; }
        [MapField("CO26NRODOC")]
        public string CO26NRODOC { get; set; }
        [MapField("CO26FECHADOC")]
        public DateTime CO26FECHADOC { get; set; }
        [MapField("CO26IMPORTFACT")]
        public decimal CO26IMPORTFACT { get; set; }
        [MapField("CO26TIPOPERACION")]
        public string CO26TIPOPERACION { get; set; }
        [MapField("CO26TIPOSERVICIO")]
        public string CO26TIPOSERVICIO { get; set; }
        [MapField("CO26PORCENTAJE")]
        public decimal CO26PORCENTAJE { get; set; }
        [MapField("CO26TIPOCAMBIO")]
        public decimal CO26TIPOCAMBIO { get; set; }
        [MapField("CO26IMPORTEDETRA")]
        public decimal CO26IMPORTEDETRA { get; set; }
        [MapField("CO26IMPORTEDETRADOL")]
        public decimal CO26IMPORTEDETRADOL { get; set; }
        [MapField("CO26CTAPROVEEDOR")]
        public string CO26CTAPROVEEDOR { get; set; }
        [MapField("ccm02nom")]
        public string ccm02nom { get; set; }
    }
}
