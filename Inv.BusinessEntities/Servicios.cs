using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
    [TableName("FAC10_SERVICIOS")]
    public class Servicios
    {
        [MapField("FAC10CODEMP")]
        public string FAC10CODEMP { get; set; }
        [MapField("FAC10SERVCOD")]
        public string FAC10SERVCOD { get; set; }
        [MapField("FAC10SERVDESC")]
        public string FAC10SERVDESC { get; set; }
        [MapField("FAC10SERVCODSUNAT")]
        public string FAC10SERVCODSUNAT { get; set; }
        [MapField("FAC10SERVCODSUNATDESCRIPCION")]
        public string FAC10SERVCODSUNATDESCRIPCION { get; set; }

    }

    

}