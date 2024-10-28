using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("GLO02VALORESXDEFECTO")]
    public class ValorxDefecto
    {
        [MapField("GLO02EMPRESACOD")]
        public string GLO02EMPRESACOD { get; set; }
        [MapField("GLO02MODULOCOD")]
        public string GLO02MODULOCOD { get; set; }
        [MapField("GLO02CODIGO")]
        public string GLO02CODIGO { get; set; }
        [MapField("GLO02DESCRIPCION")]
        public string GLO02DESCRIPCION { get; set; }
        [MapField("GLO02VALOR")]
        public string GLO02VALOR { get; set; }
    }
}