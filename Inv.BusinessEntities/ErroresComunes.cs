using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("PRO10ERRORESCOMUNES")]
    public class ErroresComunes
    {
        [MapField("PRO10CODEMP")]
        public string PRO10CODEMP { get; set; }
        [MapField("PRO10CODIGO")]
        public string PRO10CODIGO	{get;set;}
        [MapField("PRO10DESCRIPCION")]
        public string PRO10DESCRIPCION	 {get;set;}
        [MapField("PRO10ESTADO")]
        public string PRO10ESTADO	{get;set;}
        public bool EstadoError { get; set; }

    }
}
