using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.BusinessEntities
{
    [TableName("co01compdetraSunat")]
    public class DetraccionImportar
    {
        [MapField("codigo")]
        public string codigo { get; set; }
        [MapField("Tipo_de_Cuenta")]
        public string Tipo_de_Cuenta { get; set; }
        [MapField("Numero_de_Cuenta")]
        public string Numero_de_Cuenta { get; set; }
        [MapField("Numero_Constancia")]
        public string Numero_Constancia { get; set; }
        [MapField("Periodo_Tributario")]
        public string Periodo_Tributario { get; set; }
        [MapField("RUC_Proveedor")]
        public string RUC_Proveedor { get; set; }
        [MapField("Nombre_Proveedor")]
        public string Nombre_Proveedor { get; set; }
        [MapField("Tipo_de_Documento_Adquiriente")]
        public string Tipo_de_Documento_Adquiriente { get; set; }
        [MapField("Numero_de_Documento_Adquiriente")]
        public string Numero_de_Documento_Adquiriente { get; set; }
        [MapField("NombreRazonSocial_del_Adquiriente")]
        public string NombreRazonSocial_del_Adquiriente { get; set; }
        [MapField("Fecha_Pago")]
        public string Fecha_Pago { get; set; }
        [MapField("Monto_Deposito")]
        public string Monto_Deposito { get; set; }
        [MapField("Tipo_Bien")]
        public string Tipo_Bien { get; set; }
        [MapField("Tipo_Operacion")]
        public string Tipo_Operacion { get; set; }
        [MapField("Tipo_de_Comprobante")]
        public string Tipo_de_Comprobante { get; set; }
        [MapField("Serie_de_Comprobante")]
        public string Serie_de_Comprobante { get; set; }
        [MapField("Numero_de_Comprobante")]
        public string Numero_de_Comprobante { get; set; }

        #region  Traerpagodetracion
        [MapField("co26ruc")]
        public string co26ruc { get; set; }

        [MapField("co26tipdoc")]
        public string co26tipdoc { get; set; }
        [MapField("co26nrodoc")]
        public string co26nrodoc { get; set; }
        [MapField("CO26CONST_CONSDETRA")]
        public string CO26CONST_CONSDETRA { get; set; }
        [MapField("CO26CONST_FECHA")]
        public string CO26CONST_FECHA { get; set; }
        [MapField("CO26IMPORTEDETRA")]
        public string CO26IMPORTEDETRA { get; set; }
        [MapField("ccm02nom")]
        public string ccm02nom { get; set; }
        [MapField("CO05FECHA")]
        public string CO05FECHA { get; set; }

       #endregion 

    }
}
