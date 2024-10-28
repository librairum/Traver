using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In22Obra")]
    public class Obra
    {
        [MapField("In22Codigo")]
        public string Codigo { get; set; }
        [MapField("In22Descripcion")]
        public string Descripcion { get; set; }
    }
}
