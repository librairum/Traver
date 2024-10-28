using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("glo01tablas")]
    public class Moneda
    {
        [MapField("glo01codigo")]
        public string Codigo { get; set; }
        [MapField("glo01descripcion")]
        public string Descripcion { get; set; }
        //FAC54_MONEDA
        [MapField("FAC54CODIGO")]
        public string FAC54CODIGO { get; set; }

        [MapField("FAC54DESCRIPCION")]
        public string FAC54DESCRIPCION { get; set; }

        [MapField("FAC54ABREV")]
        public string FAC54ABREV { get; set; }

        [MapField("FAC54SIGNO")]
        public string FAC54SIGNO { get; set; }

        [MapField("FAC54FEMONEDACOD")]
        public string FAC54FEMONEDACOD { get; set; }

        public string glo04descripcion { get; set; }

        public double TipoCambio { get; set; }

    }
}
