using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("CO26PAGODETRACCION")]
    public class Detraccion
    {
        [MapField("CO26NUMLOTE")]
        public string CO26NUMLOTE { get; set; }
        [MapField("CO26FECHA")]
        public DateTime CO26FECHA { get; set; }
        [MapField("CO26RANFECINI")]
        public DateTime CO26RANFECINI { get; set; }
        [MapField("CO26RANFECFIN")]
        public DateTime CO26RANFECFIN { get; set; }
        [MapField("CO26CONST_NUMOPERACION")]
        public string CO26CONST_NUMOPERACION { get; set; }
        [MapField("CO26CONST_FECHA")]
        public DateTime CO26CONST_FECHA { get; set; }
        [MapField("CO26CONST_NUMCOST")]
        public string CO26CONST_NUMCOST { get; set; }
        [MapField("CO26periodotributario")]
        public string CO26periodotributario { get; set; }
        [MapField("IMPORTETOTDOC")]
        public double IMPORTETOTDOC { get; set; }
        [MapField("IMPORTETOTDET")]
        public double IMPORTETOTDET { get; set; }
        [MapField("co01codigo")]
        public string co01codigo { get; set; }
        [MapField("co01descripcion")]
        public string co01descripcion { get; set; }
        [MapField("co01Tasaretencion")]
        public int co01Tasaretencion { get; set; }

        #region DetraccionExportar


        //tabla de detraccion exportar
        [MapField("Tipdoc_proveedor")]
        public string Tipdoc_proveedor { get; set; }
        [MapField("Ruc_proveedor")]
        public string Ruc_proveedor { get; set; }
        [MapField("razonsocial_proveedor")]
        public string razonsocial_proveedor { get; set; }
        [MapField("Nro_proforma")]
        public string Nro_proforma { get; set; }
        [MapField("Cod_Servicio")]
        public string Cod_Servicio { get; set; }
        [MapField("Cod_CtaBanco")]
        public string Cod_CtaBanco { get; set; }
        [MapField("Imp_Deposito")]
        public string Imp_Deposito { get; set; }
        [MapField("Cod_Operacion")]
        public string Cod_Operacion { get; set; }
        [MapField("Per_Tributario")]
        public string Per_Tributario { get; set; }
        [MapField("ccm02nom")]
        public string ccm02nom { get; set; }
        [MapField("Comprobante_Tipo")]
        public string Comprobante_Tipo { get; set; }
        [MapField("Comprobante_serie")]
        public string Comprobante_serie { get; set; }
        [MapField("Comprobante_nro")]
        public string Comprobante_nro { get; set; }




        #endregion
    }
}
