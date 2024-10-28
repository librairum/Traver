using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In31cliente")]
    public class ContaGastosxEmpresaxLinea
    {
        [MapField("COS01CODEMP")]
        public string COS01CODEMP { get; set; }
        [MapField("COS01ANIO")]
        public string COS01ANIO { get; set; }
        [MapField("COS01MES")]
        public string COS01MES { get; set; }
        [MapField("COS01LINEACOD")]
        public string COS01LINEACOD { get; set; }
        [MapField("COS01CONTGASMOVANO")]
        public string COS01CONTGASMOVANO { get; set; }
        [MapField("COS01CONTGASMOVMES")]
        public string COS01CONTGASMOVMES { get; set; }
        [MapField("COS01CONTGASMOVSUBD")]
        public string COS01CONTGASMOVSUBD { get; set; }
        [MapField("COS01CONTGASMOVNUMER")]
        public string COS01CONTGASMOVNUMER { get; set; }
        [MapField("COS01CONTGASMOVORD")]
        public double COS01CONTGASMOVORD { get; set; }
        [MapField("COS01CTACBLECOD")]
        public string COS01CTACBLECOD { get; set; }
        [MapField("COS01CTACBLEDESC")]
        public string COS01CTACBLEDESC { get; set; }
        [MapField("COS01TIPOCOSTOCOD")]
        public string COS01TIPOCOSTOCOD { get; set; }
        [MapField("COS01TIPOCOSTODESC")]
        public string COS01TIPOCOSTODESC { get; set; }
        [MapField("COS01COSTOCOD")]
        public string COS01COSTOCOD { get; set; }
        [MapField("COS01COSTODESC")]
        public string COS01COSTODESC { get; set; }
        [MapField("COS01IMPORTE")]
        public double COS01IMPORTE { get; set; }
        [MapField("COS01FIJOOVARIABLE")]
        public string COS01FIJOOVARIABLE { get; set; }
        [MapField("COS01DIRECTOOINDIRECTO")]
        public string COS01DIRECTOOINDIRECTO { get; set; }
        [MapField("COS01FLAGDISTRIBUCION")]
        public string COS01FLAGDISTRIBUCION { get; set; }
        [MapField("COS01TASADISTRIBUCION")]
        public double COS01TASADISTRIBUCION { get; set; }
        [MapField("COS01IMPORTEDISTRIBUCION")]
        public double COS01IMPORTEDISTRIBUCION { get; set; }
        // descripcion de linea
        [MapField("PRO08DESC")]
        public string PRO08DESC { get; set; }

        //Actividad de apoyo
        public string COS01CTACBLE { get; set; }
        //actapoyo.COS01CTACBLE,
        //actapoyo.COS01DESCRIPCION
        public string COS01DESCRIPCION { get; set; }
    }
}
