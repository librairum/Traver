using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Trae_ListaPPStock")]
    public class Spu_Inv_Trae_ListaPPStock
    {
        /*
           Select In01key,in01deslar,IN01UNIMED,IN07UNIMED,                            
  --         
  Isnull(StockRealArea,0) as StockRealArea,         
  Isnull(StockRealVolumen,0) as StockRealVolumen,                        
  --                  
  Isnull(CanastillasCantidad,0) as CanastillasCantidad,                            
  Tipo,Color,Tonalidad,Formato,Espesor,Modelo    
         */
        [MapField("In01key")]
        public string In01key { get; set; }

        [MapField("in01deslar")]
        public string in01deslar { get; set; }

        [MapField("IN01UNIMED")]
        public string IN01UNIMED { get; set; }
        [MapField("StockReal")]
        public double StockReal { get; set; }
        [MapField("StockRealArea")]
        public string StockRealArea { get; set; }

        [MapField("StockRealVolumen")]
        public string StockRealVolumen { get; set; }

        [MapField("CanastillasCantidad")]
        public string CanastillasCantidad { get; set; }

        [MapField("Tipo")]
        public string Tipo { get; set; }

        [MapField("Color")]
        public string Color { get; set; }

        [MapField("Tonalidad")]
        public string Tonalidad { get; set; }

        [MapField("Formato")]
        public string Formato { get; set; }

        [MapField("Espesor")]
        public string Espesor { get; set; }

        [MapField("Modelo")]
        public string Modelo { get; set; }

    }
}
