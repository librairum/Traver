using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Come01PedidoVentaCab")]
    public class PedidoVentaCabecera
    {
        [MapField("come01fecha")]
        public DateTime come01fecha { get; set; }
        [MapField("come01fechaentrega")]
        public DateTime come01fechaentrega { get; set; }
        [MapField("come01clientefecdoc")]
        public DateTime come01clientefecdoc { get; set; }
        [MapField("come01clientefecentdoc")]
        public DateTime come01clientefecentdoc { get; set; }
        [MapField("come01pedvennum")]
        public string come01pedvennum { get; set; }
        [MapField("come01observaciones")]
        public string come01observaciones { get; set; }
        [MapField("come01clientecod")]
        public string come01clientecod { get; set; }
        [MapField("come01clientetipdoc")]
        public string come01clientetipdoc { get; set; }
        [MapField("come01clientenumdoc")]
        public string come01clientenumdoc { get; set; }
        [MapField("come01clientecodsededoc")]
        public string come01clientecodsededoc { get; set; }
        [MapField("come01clientecontacdoc")]
        public string come01clientecontacdoc { get; set; }
        [MapField("come01empresa")]
        public string come01empresa { get; set; }
        [MapField("come01anio")]
        public string come01anio { get; set; }
        [MapField("come01mes")]
        public string come01mes { get; set; }
        [MapField("comr01estadoproceso")]
        public string comr01estadoproceso { get; set; }
        [MapField("come01pedventipocod")]
        public string come01pedventipocod { get; set; }
        [MapField("come01clientetipana")]
        public string come01clientetipana { get; set; }

        // Datos por referencia
        [MapField("come04pedventadoccliDesc")]
        public string come04pedventadoccliDesc { get; set; }
        [MapField("ccm02nom")]
        public string ccm02nom { get; set; }

    }
}
