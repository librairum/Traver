using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Inv.BusinessEntities
{
    [TableName("Spu_Fac_Trae_PackingListTodo")]
    public  class Spu_Fac_Trae_PackingListTodo
    {
        [MapField("come01empresa")]
        public string Empresa { get; set; }
        [MapField("come01anio")]
        public string anio { get; set; }
        [MapField("come01mes")]
        public string mes { get; set; }
        [MapField("come01clientecod")]
        public string ClienteCodigo { get; set; }
        [MapField("come01clientedec")]
        public string ClienteDescripcion { get; set; }
        [MapField("come01clientenumdoc")]
        public string ClienteNumDoc { get; set; }
        [MapField("come01pedvencodprod")]
        public string ProductoCodigo { get; set; }
        [MapField("come01pedvendescprod")]
        public string ProductoDescripcion { get; set; }
        [MapField("come01productocantidad")]
        public double ProductoCantidad { get; set; }

        [MapField("come01productosespesorcliente")]
        public double EspesorProductoCli { get; set; }

        [MapField("come01productoanchocliente")]
        public double AnchoProductoCli { get; set; }

        [MapField("come01productolargocliente")]
        public double LargoProductoCli { get; set; }

        [MapField("come01pedvennum")]
        public string PedidoNum { get; set; }

        [MapField("come01pedvenitem")]
        public int PedVenItem { get; set; }

        [MapField("come01productocodcliente")]
        public string ProductoClienteCodigo { get; set; }

        [MapField("come01productodesccliente")]
        public string ProductoClienteDescripcion { get; set; }
    }
}
