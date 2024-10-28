using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("ccb02subd")]
    public class Libro
    {
        [MapField("ccb02emp")]
        public string ccb02emp	    {get;set;}

        [MapField("ccb02cod")]
        public string ccb02cod	    {get;set;}

        [MapField("ccb02des")]
        public string ccb02des	    {get;set;}

        [MapField("ccb02asig1")]
        public string ccb02asig1	{get;set;}

        [MapField("ccb02asig2")]
        public string ccb02asig2    {get;set;}

        [MapField("ccb02asig3")]
        public string ccb02asig3    {get;set;}

        [MapField("ccb02tip")]
        public string  ccb02tip	    {get;set;}

        [MapField("ccb02man")]
        public string ccb02man      {get; set;}
    }
}
