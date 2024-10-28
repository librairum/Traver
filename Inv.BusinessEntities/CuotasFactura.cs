using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("FAC12_FACTURACUOTAS")]
    public class CuotasFactura
    {
        [MapField("FAC12CODEMP")]
        public string FAC12CODEMP { get; set; }
        [MapField("FAC12COD")]
        public string FAC12COD { get; set; }
        [MapField("FAC12NUMDOC")]
        public string FAC12NUMDOC { get; set; }
        [MapField("FAC12CUOTANRO")]
        public string FAC12CUOTANRO { get; set; }
        [MapField("FAC12DIAS")]
        public int FAC12DIAS { get; set; }
        [MapField("FAC12FECHA")]
        public DateTime FAC12FECHA { get; set; }
        [MapField("FAC12IMPORTEBASE")]
        public double FAC12IMPORTEBASE { get; set; }
        [MapField("FAC12IMPORTEIGV")]
        public double FAC12IMPORTEIGV { get; set; }
        [MapField("FAC12IMPORTEDETRACCION")]
        public double FAC12IMPORTEDETRACCION { get; set; }
        [MapField("FAC12IMPORTERETENCION")]
        public double FAC12IMPORTERETENCION { get; set; }
        [MapField("FAC12IMPORTEOTROSDCTOS")]
        public double FAC12IMPORTEOTROSDCTOS { get; set; }
        [MapField("FAC12IMPORTECUOTANETO")]
        public double FAC12IMPORTECUOTANETO { get; set; }

    }
}
