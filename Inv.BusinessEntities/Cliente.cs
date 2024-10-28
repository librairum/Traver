using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In31cliente")]
    public class Cliente
    {
        [MapField("In31codcli")]
        public string Codigo { get; set; }
        [MapField("In31nombre")]
        public string Nombre { get; set; }
    }
}
