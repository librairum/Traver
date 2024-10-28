using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Glo01ProdTermCarac")]

    public class ArticuloCaracteristicas
    {
        [MapField("glo01codigotabla")]
        public string codigotabla { get; set; }

        [MapField("glo01codigo")]
        public string codigo { get; set; }

        [MapField("glo01descripcion")]
        public string descripcion { get; set; }

        [MapField("glo01texto1")]
        public string glo01texto1 { get; set; }

        [MapField("glocomentario")]
        public string glocomentario { get; set; }

        [MapField("glo01lonCodTabla")]
        public int glo01lonCodTabla { get; set; }

        [MapField("glo01area")]
        public double glo01area { get; set; }
        [MapField("glo01anchoUnimed")]
        public string glo01anchoUnimed { get; set; }

        [MapField("glo01largoUnimed")]
        public string glo01largoUnimed { get; set; }

        [MapField("glo01altoUnimed")]
        public string glo01altoUnimed { get; set; }
        [MapField("glo01descripcionAbreviada")]
        public string glo01descripcionAbreviada { get; set; }

        //-----
        private string flag;
        public string Flag
        {
            get
            {
                return flag;
            }
            set
            {
                this.flag = value;
            }
        }

       }
}
