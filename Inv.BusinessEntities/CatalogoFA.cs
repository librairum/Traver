using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    [TableName("Glo04catalogoFE")]
    public class CatalogoFA
    {
        [MapField("glo04CodigoTabla")]
        public string glo04CodigoTabla	{get;set;}
        
        [MapField("glo04FlagTabla")]
        public string glo04FlagTabla	{get;set;}
        
        [MapField("glo04Codigo")]
        public string glo04Codigo	{get;set;}
        
        [MapField("glo04descripcion")]
        public string glo04descripcion	{get;set;}

        [MapField("glo04longitud")]
        public int glo04longitud	{get;set;}

        [MapField("glo04campotexto1")]
        public string glo04campotexto1	{get;set;}

        [MapField("glo04campotexto2")]
        public string glo04campotexto2	{get;set;}

        [MapField("glo04campoNumerico1")]
        public double glo04campoNumerico1 {get;set;}

        [MapField("glo04campoNumerico2")]
        public double glo04campoNumerico2 {get;set;}

        [MapField("glo04comentario")]
        public string glo04comentario { get; set; }
    }
}
