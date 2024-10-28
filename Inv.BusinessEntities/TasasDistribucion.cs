using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("COS01TASASDISTRIBUCION")]
    public class TasasDistribucion
    {
        [MapField("COS01CODEMP")]
        public string COS01CODEMP { get; set; }
        [MapField("COS01ANIO")]
        public string COS01ANIO { get; set; }
        [MapField("COS01MES")]
        public string COS01MES { get; set; }
        [MapField("COS01LINEA")]
        public string COS01LINEA { get; set; }
        [MapField("COS01LOTE")]
        public string COS01LOTE { get; set; }
        [MapField("COS01ACTAPOYO")]
        public string COS01ACTAPOYO { get; set; }
        [MapField("COS01ACTPRINCIPAL")]
        public string COS01ACTPRINCIPAL { get; set; }
        [MapField("COS01TASA")]
        public double COS01TASA { get; set; }
        [MapField("COS01DESCRIPCION")]
        public string COS01DESCRIPCION { get; set; }

        [MapField("COS01CTACBLEAPOYO")]
        public string COS01CTACBLEAPOYO { get; set; }
        [MapField("COS01DESCRIPCIONAPOYO")]
        public string COS01DESCRIPCIONAPOYO { get; set; }
        [MapField("COS01CTACBLEPRINCIPAL")]
        public string COS01CTACBLEPRINCIPAL { get; set; }
        [MapField("COS01DESCRIPCIONPRINCIPAL")]
        public string COS01DESCRIPCIONPRINCIPAL { get; set; }
        [MapField("COS01IMPORTE")]
        public double COS01IMPORTE { get; set; }
        [MapField("COS01PORCENTAJE")]
        public double COS01PORCENTAJE { get; set; }
        [MapField("COS01IMPORTEORIGINAL")]
        public string COS01IMPORTEORIGINAL { get; set; }
    }
}
