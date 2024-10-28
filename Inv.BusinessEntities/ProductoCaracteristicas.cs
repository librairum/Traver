using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System.Text;

namespace Inv.BusinessEntities
{
    [TableName("GLO01PRODUCTOS")]
    public class ProductoCaracteristicas
    {
        [MapField("glo01codigotabla")]
        public string glo01codigotabla {get;set;}        
        
        [MapField("glo01codigo")]
        public string glo01codigo	 {get;set;}

        [MapField("glo01descripcion")]
        public string glo01descripcion{get;set;}

        [MapField("glo01texto1")]
        public string glo01texto1	{get;set;}

        [MapField("glocomentario")]
        public string glocomentario	{get;set;}

        [MapField("glo01lonCodTabla")]
        public int glo01lonCodTabla { get; set; }
        	

    }
}
