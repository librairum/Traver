using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("COS01PRODUCCIONMOVIMIENTO")]
    public class MovimientosProduccion
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
        [MapField("COS01MOVIPRODAA")]
        public string COS01MOVIPRODAA { get; set; }
        [MapField("COS01MOVIPRODMM")]
        public string COS01MOVIPRODMM { get; set; }
        [MapField("COS01MOVIPRODTIPDOC")]
        public string COS01MOVIPRODTIPDOC { get; set; }
        [MapField("COS01MOVIPRODCODDOC")]
        public string COS01MOVIPRODCODDOC { get; set; }
        [MapField("COS01MOVIPRODKEY")]
        public string COS01MOVIPRODKEY { get; set; }
        [MapField("COS01MOVIPRODORDEN")]
        public double COS01MOVIPRODORDEN { get; set; }

        [MapField("COS01PRODLINEACOD")]
        public string COS01PRODLINEACOD { get; set; }
        [MapField("COS01RODACTNIV1COD")]
        public string COS01RODACTNIV1COD { get; set; }
        [MapField("COS01ORDENTRABAJO")]
        public string COS01ORDENTRABAJO { get; set; }
        [MapField("COS01PRODNATURALEZA")]
        public string COS01PRODNATURALEZA { get; set; }
        [MapField("COS01UNIMED")]
        public string COS01UNIMED { get; set; }
        [MapField("COS01FECDOC")]
        public Nullable<DateTime> COS01FECDOC { get; set; }
        [MapField("COS01CODALM")]
        public string COS01CODALM { get; set; }
        [MapField("COS01CODTRA")]
        public string COS01CODTRA { get; set; }
        [MapField("COS01TRANSA")]
        public string COS01TRANSA { get; set; }
        [MapField("COS01CANART")]
        public string COS01CANART { get; set; }
        [MapField("COS01COSUNI")]
        public string COS01COSUNI { get; set; }
        [MapField("COS01COUNSO")]
        public string COS01COUNSO { get; set; }

        [MapField("COS01COUNDO")]
        public string COS01COUNDO { get; set; }

        [MapField("COS03IMPORT")]
        public string COS03IMPORT { get; set; }
        [MapField("COS01IMPSOL")]
        public string COS01IMPSOL { get; set; }
        [MapField("COS01IMPDOL")]
        public string COS01IMPDOL { get; set; }
        [MapField("COS01LARGO")]
        public double COS01LARGO { get; set; }

        [MapField("COS01ANCHO")]
        public double COS01ANCHO { get; set; }
        [MapField("COS01ALTO")]
        public double COS01ALTO { get; set; }
        [MapField("COS01NROCAJA")]
        public string COS01NROCAJA { get; set; }
        [MapField("COS01DocIngAA")]
        public string COS01DocIngAA { get; set; }

        [MapField("COS01DocIngMM")]
        public string COS01DocIngMM { get; set; }
        [MapField("COS01DocIngTIPDOC")]
        public string COS01DocIngTIPDOC { get; set; }
        [MapField("COS01DocIngCODDOC")]
        public string COS01DocIngCODDOC { get; set; }
        [MapField("COS01DocIngKEY")]
        public string COS01DocIngKEY { get; set; }
        [MapField("COS01DocIngORDEN")]
        public double COS01DocIngORDEN { get; set; }
        [MapField("COS01AREAXUNI")]
        public double COS01AREAXUNI { get; set; }
        [MapField("PRO09DESC")]
        public string PRO09DESC { get; set; }
        //campos de intervencion
        [MapField("COS01AREA")]
        //double @COS01AREA,
        public double COS01AREA { get; set; }
        [MapField("COS01VOLUMEN")]
        public double COS01VOLUMEN { get; set; }

        [MapField("COS01COSPROMSOL")]
        public double COS01COSPROMSOL { get; set; }
        [MapField("COS01COSPROMDOL")]
        public double COS01COSPROMDOL { get; set; }
        [MapField("COS01FLAG")]
        public string COS01FLAG { get; set; }

        [MapField("COS01ERRORES")]
        public string COS01ERRORES { get; set; }
        [MapField("COS01CANTERRORES")]
        public int COS01CANTERRORES { get; set; }
        //propiedades de table  importacion 
        [MapField("COS01CODIGOUSUARIO")]
        public string COS01CODIGOUSUARIO { get; set; }
        [MapField("COS01SISTEMA")]
        public string COS01SISTEMA { get; set; }



    }

}
