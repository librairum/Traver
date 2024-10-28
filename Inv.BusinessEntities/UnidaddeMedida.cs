using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("in21unidad")]
    public class UnidaddeMedida
    {
        [MapField("in21codigo")]
        public string in21codigo { get; set; }
        [MapField("in21descri")]
        public string in21descri { get; set; }
        //flag para validar la edicion del registro en la grilla.
        public string flag { get; set; }
    }
}
