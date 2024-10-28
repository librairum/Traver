using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS01CONTABILIDADGASTOS")]
    public class GastosContabilidad
    {
        [MapField("COS01CODEMP")]
        public string COS01CODEMP { get; set; }
        [MapField("COS01ANIO")]
        public string COS01ANIO { get; set; }
        [MapField("COS01MES")]
        public string COS01MES { get; set; }
        [MapField("COS01LINEA")]
        public string COS01LINEA { get; set; }
        [MapField("COS01LOTE")]
        public string COS01LOTE { get; set; }
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
        //COS01COSTOCOD	varchar	2
        [MapField("COS01COSTOCOD")]
        public string COS01COSTOCOD { get; set; }

        [MapField("COS01COSTODESC")]
        public string COS01COSTODESC { get; set; }
        //COS01IMPORTE	float	8
        [MapField("COS01IMPORTE")]
        public double COS01IMPORTE { get; set; }
        [MapField("COS01FLAG")]
        public string COS01FLAG { get; set; }
        [MapField("COS01ERRORES")]
        public string COS01ERRORES { get; set; }
        [MapField("COS01CANTERRORES")]
        public int COS01CANTERRORES { get; set; }
        [MapField("COS01CODIGOUSUARIO")]
        public string COS01CODIGOUSUARIO { get; set; }
        [MapField("COS01SISTEMA")]
        public string COS01SISTEMA { get; set; }

        [MapField("COS01CODIGO")]
        public string COS01CODIGO { get; set; }
        [MapField("COS01DESCRIPCION")]
        public string COS01DESCRIPCION { get; set; }

        [MapField("COS01FIJOOVARIABLE")]
        public string COS01FIJOOVARIABLE { get; set; }
        [MapField("COS01DIRECTOOINDIRECTO")]
        public string COS01DIRECTOOINDIRECTO { get; set; }



    }
}