using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inv.BusinessEntities
{
    public class DocumentoFA
    {
        public string FAC04CODEMP { get; set; }
        public string FAC01COD { get; set; }
        public string FAC04NUMDOC { get; set; }
        public string FAC04AA { get; set; }
        public string FAC04MM { get; set; }
        public string FAC04NRODOC { get; set; }
        public string FAC04SERIEDOC { get; set; }
        public Nullable<DateTime> FAC04FECHA { get; set; }
        public string FAC04TIPANA { get; set; }
        public string FAC04CODCLI { get; set; }
        public string FAC04MONEDA { get; set; }
        public double FAC04TIPCAMBIO { get; set; }
        public double FAC04DONSUBTOTAL { get; set; }
        public double FAC04DONIGV { get; set; }
        public double FAC04DONTOTAL { get; set; }
        public string FAC02COD { get; set; }
        public string FAC03COD { get; set; }
        public string FAC03TIPART { get; set; }
        public string FAC04CLINOMBRE { get; set; }
        public string FAC04CLIDIRECCION { get; set; }
        public string FAC04CLIRUC { get; set; }
        public string FAC04GLOSA { get; set; }
        public string FAC04DONGLAG { get; set; }
        public double FAC04IGV { get; set; }
        public string FAC04GUIAS { get; set; }
        public string FAC04DOCMODTIPDOC { get; set; }
        public string FAC04DOCMODNRO { get; set; }
        public Nullable<DateTime> FAC04DOCMODFECHA { get; set; }
        public string FAC04TIPMOTEMI { get; set; }
        public string FAC04TIPMOTEMIDES { get; set; }
        public string FAC04EXPCONOEMBARQUE { get; set; }
        public string FAC04EXPCODPAISORIGEN { get; set; }
        public string FAC04EXPCODPAISDESTINO { get; set; }
        public string FAC04EXPCODCONDPAGO { get; set; }
        public string FAC04EXPCODCONDDESPACHO { get; set; }
        public string FAC04EXPCODPUERTO { get; set; }
        public string FAC04EXPCODPUERTODES { get; set; }
        public string FAC04EXPCODBCOLOCAL { get; set; }
        public string FAC04EXPCDDOCCRED { get; set; }
        public string FAC04EXPLCEMITIDA { get; set; }
        public string FAC04EXPBANKCODE { get; set; }
        public string FAC04EXPNUMCUENTA { get; set; }
        public string FAC04EXPNROCONTAINER { get; set; }
        public string FAC04EXPNROPRECINTO { get; set; }
        public string FAC04ORDENCOMPRA { get; set; }
        public Nullable<DateTime> FAC04FECORDCOMPRA { get; set; }
        public string FAC04CODTIPOVENTA { get; set; }
        public string FAC04ESTADODEPROCESO { get; set; }
        public string FAC04TIENDA { get; set; }
        public double FAC04DESCUENTOGLOBAL { get; set; }
        public string FAC04FETIPONOTA { get; set; }
        public string FAC04LIQUIDACIONNRO { get; set; }

        public string FAC04FETIPODEOPERACION { get; set; }
        public string FAC04FECODIGOANEXOEMISOR { get; set; }
        public string FAC04FORMAPAGOSUNAT { get; set; }
        public int FAC04FORMAPAGOSUNATCUOTAS { get; set; }
        public int FAC04FORMAPAGOSUNATDIAS { get; set; }

        

        //campos de detalle de documento
        public string FAC05CODEMP { get; set; }        
        
        
        public int FAC05CODFACDET { get; set; }
        public string FAC05CODPROD { get; set; }       
        public string FAC05DESCPROD { get; set; }        
        public string FAC05UNIMED { get; set; }        
        public double FAC05CANTIDAD { get; set; }        
        public double FAC05PRECIO { get; set; }        
        public double FAC05SUBTOTAL { get; set; }        
        public double FAC05MINTMH { get; set; }        
        public double FAC05MINTMS { get; set; }
        
        public double FAC05MINTMP { get; set; }        
        public string FAC05MINLOTE { get; set; }        
        public string FAC05MINCONTRATO { get; set; }        
        public string FAC05MINENMIENDA { get; set; }        
        public string FAC05MINGUIAS { get; set; }        
        public double FAC05MINTMH_PRO { get; set; }        
        public double FAC05MINTMS_PRO { get; set; }        
        public double FAC05MINTMP_PRO { get; set; }        
        public double FAC05PRECIO_PRO { get; set; }        
        public double FAC05SUBTOTAL_PRO { get; set; }        
        public double FAC05SUBTOTAL_FIN { get; set; }        
        public string FAC05DESCLARGA { get; set; }

        public string FAC05PARTARAN { get; set; }        
        public double FAC05PESO { get; set; }        
        public double FAC05PESOADUANA { get; set; }        
        public double FAC05NROCAJA { get; set; }        
        public string FAC05SUBGRUPO { get; set; }        
        public double FAC05FEIMPORTECONIGV { get; set; }        
        public double FAC05FEIMPUNICONIMPTO { get; set; }        
        public string FAC05FECODIMPUNICONIMPTO { get; set; }        
        public string FAC05FECODRAZEXONERACION { get; set; }        
        public double FAC05FEIMPDSCTO { get; set; }
        public string FAC05FECODIMPREF { get; set; }        
        public string FAC05FEPRODUCTOTIPO { get; set; }

        public double FAC05FEIMPORTEREFERENCIAL { get; set; }        
        public double FAC05FEIMPORTECARGO { get; set; }

        public string FAC05FECODPRODSUNAT { get; set; }
        public double FAC05FEIGVTASA { get; set; }

        public string FAC04FECODBIENOSERVDETRACCION	 { get; set; }
        public double FAC04FEPORCEDETRACCION  { get; set; }
        public double FAC04FETOTALDETRACCION  { get; set; }

        public string FAC04VENDEDORCOD { get; set; }
        public string FAC04VENDEDORNOMBRE { get; set; }


        
        //public string @msgretorno { get; set; }
    }
}
