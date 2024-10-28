using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS01CONTABILIDADGASTOSXEMP")]
    public class CostosProduccion
    {
        // COS01CODEMP	char(2)
        [MapField("COS01CODEMP")]
        public string COS01CODEMP { get; set; }

        //COS01ANIO	char(4)
        [MapField("COS01ANIO")]
        public string COS01ANIO { get; set; }

        //COS01MES	char(2)
        [MapField("COS01MES")]
        public string COS01MES { get; set; }

        //COS01CONTGASMOVANO	char	4
        [MapField("COS01CONTGASMOVANO")]
        public string COS01CONTGASMOVANO { get; set; }

        //COS01CONTGASMOVMES	char	2
        [MapField("COS01CONTGASMOVMES")]
        public string COS01CONTGASMOVMES { get; set; }


        //COS01CONTGASMOVSUBD	char	2
        [MapField("COS01CONTGASMOVSUBD")]
        public string COS01CONTGASMOVSUBD { get; set; }

        //COS01CONTGASMOVNUMER	varchar	10
        [MapField("COS01CONTGASMOVNUMER")]
        public string COS01CONTGASMOVNUMER { get; set; }

        //COS01CONTGASMOVORD	float	8
        [MapField("COS01CONTGASMOVORD")]
        public double COS01CONTGASMOVORD { get; set; }

        //COS01CTACBLECOD	varchar	30
        [MapField("COS01CTACBLECOD")]
        public string COS01CTACBLECOD { get; set; }

        //COS01CTACBLEDESC	varchar	100
        [MapField("COS01CTACBLEDESC")]
        public string COS01CTACBLEDESC { get; set; }

        //COS01TIPOCOSTOCOD	varchar	3
        [MapField("COS01TIPOCOSTOCOD")]
        public string COS01TIPOCOSTOCOD { get; set; }

        //COS01TIPOCOSTODESC	varchar	100
        [MapField("COS01TIPOCOSTODESC")]
        public string COS01TIPOCOSTODESC { get; set; }

        //COS01COSTOCOD	varchar	2
        [MapField("COS01COSTOCOD")]
        public string COS01COSTOCOD { get; set; }

        //COS01COSTODESC	varchar	100
        [MapField("COS01COSTODESC")]
        public string COS01COSTODESC { get; set; }

        //COS01IMPORTE	float	8
        [MapField("COS01IMPORTE")]
        public double COS01IMPORTE { get; set; }

        //COS01FIJOOVARIABLE	char	1
        [MapField("COS01FIJOOVARIABLE")]
        public string COS01FIJOOVARIABLE { get; set; }

        //COS01DIRECTOOINDIRECTO	char	1
        [MapField("COS01DIRECTOOINDIRECTO")]
        public string COS01DIRECTOOINDIRECTO { get; set; }

        //        @COS01FLAG	char(1),
        [MapField("COS01FLAG")]
        public string COS01FLAG { get; set; }
        //@COS01ERRORES	varchar(250),
        [MapField("COS01ERRORES")]
        public string COS01ERRORES { get; set; }
        //@COS01CANTERRORES	int,
        [MapField("COS01CANTERRORES")]
        public int COS01CANTERRORES { get; set; }
        //@COS01CODIGOUSUARIO	varchar(20),
        [MapField("COS01CODIGOUSUARIO")]
        public string COS01CODIGOUSUARIO { get; set; }
        //@COS01SISTEMA	varchar(10),
        [MapField("COS01SISTEMA")]
        public string COS01SISTEMA { get; set; }

    }
}
