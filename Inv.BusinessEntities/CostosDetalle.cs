using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("COS03COSTOSDETALLE")]
    public class CostosDetalle
    {
        [MapField("COS03CODEMP")]
        public string COS03CODEMP { get; set; }
        [MapField("COS03ANIO")]
        public string COS03ANIO { get; set; }
        [MapField("COS03MES")]
        public string COS03MES { get; set; }
        [MapField("COS03LINEA")]
        public string COS03LINEA { get; set; }
        [MapField("CO03LOTE")]
        public string CO03LOTE { get; set; }
        [MapField("COS03MOVPRODAA")]
        public string COS03MOVPRODAA { get; set; }
        [MapField("COS03MOVPRODMM")]
        public string COS03MOVPRODMM { get; set; }
        [MapField("COS03MOVPRODTIPDOC")]
        public string COS03MOVPRODTIPDOC { get; set; }
        [MapField("COS03MOVPRODCODDOC")]
        public string COS03MOVPRODCODDOC { get; set; }
        [MapField("COS03MOVPRODKEY")]
        public string COS03MOVPRODKEY { get; set; }
        [MapField("COS03MOVPRODORDEN")]
        public double COS03MOVPRODORDEN { get; set; }
        [MapField("COS03LINEACOD")]
        public string COS03LINEACOD { get; set; }
        [MapField("COS03ACTIVIDADNIVELCOD")]
        public string COS03ACTIVIDADNIVELCOD { get; set; }
        [MapField("COS03TIPOCOSTO")]
        public string COS03TIPOCOSTO { get; set; }
        [MapField("COS03COSTO")]
        public string COS03COSTO { get; set; }
        [MapField("COS03ORDENTRABAJO")]
        public string COS03ORDENTRABAJO { get; set; }
        [MapField("COS03IMPORTEACTIVIDAD")]
        public double COS03IMPORTEACTIVIDAD { get; set; }
        [MapField("COS03RATIOOTXACTIVIDAD")]
        public double COS03RATIOOTXACTIVIDAD { get; set; }
        [MapField("COS03IMPORTEOTXACTIVIDAD")]
        public double COS03IMPORTEOTXACTIVIDAD { get; set; }
        [MapField("COS03IMPORTE")]
        public double COS03IMPORTE { get; set; }
        [MapField("COS03RATIOPRODUCTOXOT")]
        public double COS03RATIOPRODUCTOXOT { get; set; }
        [MapField("COS03IMPORTEXPRODUCTOXOT")]
        public double COS03IMPORTEXPRODUCTOXOT { get; set; }
        [MapField("COS03TIPOCOSTODESC")]
        public string COS03TIPOCOSTODESC { get; set; }
        [MapField("COS03COSTODESC")] 
        public string COS03COSTODESC { get; set; }
        // Campo adiconal para nombre de actividad
        [MapField("ActividadDes")]
        public string ActividadDes { get; set; }
        
    }
}
