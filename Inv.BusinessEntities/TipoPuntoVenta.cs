using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("Come02pedventatipo")]
    public class TipoPuntoVenta
    {
        [MapField("come02pedventatipdesc")]
        public string Descripcion { get; set; }
        [MapField("come02empresa")]
        public string CodigoEmpresa { get; set; }
        [MapField("come02pedventatipcod")]
        public string Codigo { get; set; }
    }
}
