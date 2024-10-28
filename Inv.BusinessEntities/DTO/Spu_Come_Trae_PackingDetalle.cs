using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Come_Trae_PackingDetalle")]
    public class Spu_Come_Trae_PackingDetalle
    {
        [MapField("CodigoEmpresa")]
        public string CodigoEmpresa { get; set; }
        [MapField("NroPackingCab")]
        public string NroPackingCab {get;set;}

    }
}
