using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inv.BusinessEntities
{
    public class TraeAnticiposPorAplicar
    {

        public string FAC04FECHA {get;set;}
		public string FAC01COD {get;set;}
		public string FAC04NUMDOC {get;set;}
        public double FAC04IMPSUBTOTAL { get; set; }
		public double FAC04IMPIGV {get;set;}
		public double FAC04IMPTOTAL {get;set;}

    }
}
