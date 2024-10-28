using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("PRO11ERRORESCOMUNESDET")]
    public class ErroresComunesDetalle
    {
        [MapField("PRO11CODEMP")]
        public string PRO11CODEMP { get; set; }
        [MapField("PRO11CODIGO")]
        public string  PRO11CODIGO	{get;set;}
        [MapField("PRO11DETCODEMP")]
        public string PRO11DETCODEMP {get;set;}
        [MapField("PRO11DETAA")]
        public string PRO11DETAA {get; set;}
        [MapField("PRO11DETMM")]
        public string PRO11DETMM {get;set;}
        [MapField("PRO11DETTIPDOC")]
        public string PRO11DETTIPDOC {get;set;}
        [MapField("PRO11DETCODDOC")]
        public string  PRO11DETCODDOC {get;set;}
        [MapField("PRO11DETKEY")]
        public string PRO11DETKEY	{get;set;}
        [MapField("PRO11DETORDEN")]
        public double  PRO11DETORDEN {get;set;}

    }
}
