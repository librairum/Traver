using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("ccm02cta")]
    public class CuentaCorriente
    {
        [MapField("ccm02emp")]
        public string ccm02emp { get; set; }
        [MapField("ccm02tipana")]
        public string ccm02tipana { get; set; }
        [MapField("ccm02cod")]
        public string ccm02cod { get; set; }
        [MapField("ccm02nom")]
        public string ccm02nom { get; set; }
        [MapField("ccm02dir")]
        public string ccm02dir { get; set; }
        [MapField("ccm02tel")]
        public string ccm02tel { get; set; }
        [MapField("ccm02fec")]
        public DateTime ccm02fec { get; set; }
        [MapField("ccm02ruc")]
        public string ccm02ruc { get; set; }
        [MapField("ccm02ncta")]
        public string ccm02ncta { get; set; }
        [MapField("ccm02tpag")]
        public string ccm02tpag { get; set; }
        [MapField("ccm02nctadol")]
        public string ccm02nctadol { get; set; }
        [MapField("ccm02fax")]
        public string ccm02fax { get; set; }
        [MapField("ccm02respon")]
        public string ccm02respon { get; set; }
        [MapField("ccm02rubpro")]
        public string ccm02rubpro { get; set; }
        [MapField("ccm02Aten")]
        public string ccm02Aten { get; set; }
        [MapField("ccm02moneda")]
        public string ccm02moneda { get; set; }
        [MapField("Ccm02Forpag")]
        public string Ccm02Forpag { get; set; }
        [MapField("ccm02activo")]
        public string ccm02activo { get; set; }
        [MapField("ccm02correo")]
        public string ccm02correo { get; set; }
        [MapField("ccm02tel2")]
        public string ccm02tel2 { get; set; }
        [MapField("ccm02fecnac")]
        public DateTime ccm02fecnac { get; set; }
        [MapField("ccm02tipojuridico")]
        public string ccm02tipojuridico { get; set; }
        [MapField("ccm02descuento")]
        public double ccm02descuento { get; set; }
        [MapField("ccm02TipoAgenteRetencion")]
        public string ccm02TipoAgenteRetencion { get; set; }
        [MapField("ccm02dni")]
        public string ccm02dni { get; set; }
        [MapField("ccm02localidad")]
        public string ccm02localidad { get; set; }
        [MapField("ccm02TipoRuc")]
        public string ccm02TipoRuc { get; set; }
        [MapField("ccm02ApePaterno")]
        public string ccm02ApePaterno { get; set; }
        [MapField("ccm02ApeMaterno")]
        public string ccm02ApeMaterno { get; set; }
        [MapField("ccm02Nombres")]
        public string ccm02Nombres { get; set; }
        [MapField("ccm02EstadoContribuyente")]
        public string ccm02EstadoContribuyente { get; set; }
        [MapField("ccm02SituacionDomicilio")]
        public string ccm02SituacionDomicilio { get; set; }
        [MapField("ccm02Brevete")]
        public string ccm02Brevete { get; set; }
        [MapField("ccm02nomabrev")]
        public string ccm02nomabrev { get; set; }
        [MapField("ccm02nroctadetraccion")]
        public string ccm02nroctadetraccion { get; set; }
        [MapField("ccm02tipdocidentidad")]
        public string ccm02tipdocidentidad { get; set; }
        [MapField("ccm02CorreoFacturaElectronica")]
        public string ccm02CorreoFacturaElectronica { get; set; }
        [MapField("ccm02FEDepartamentoCod")]
        public string ccm02FEDepartamentoCod { get; set; }
        [MapField("ccm02FEProvinciaCod")]
        public string ccm02FEProvinciaCod { get; set; }
        [MapField("ccm02FEDistritoCod")]
        public string ccm02FEDistritoCod { get; set; }
        [MapField("ccm02FEUrbanizacion")]
        public string ccm02FEUrbanizacion { get; set; }
        [MapField("ccm02FEPaisCod")]
        public string ccm02FEPaisCod { get; set; }

        [MapField("ccm02FlagDescripcionCliente")]
        public string ccm02FlagDescripcionCliente { get; set; }

        
        [MapField("PaisDescripcion")]
        public string PaisDescripcion { get; set; }
        
        [MapField("DepaDescrpicion")]
        public string DepaDescrpicion { get; set; }
        
        [MapField("ProviDescripcion")]
        public string ProviDescripcion { get; set; }

        [MapField("DisDescripcion")]
        public string DisDescripcion { get; set; }
        
        //[MapField("TipDocDesc")]
        public string TipDocDesc { get; set; }

        [MapField("SituacionSunatDesc")]
        public string SituacionSunatDesc { get; set; }

        [MapField("SituacionDomicilioDesc")]
        public string SituacionDomicilioDesc { get; set; }

        [MapField("Co02descripcion")]
        public string Co02descripcion { get; set; }
		[MapField("CCM02TIPOCLIENTECOD")]
        public string CCM02TIPOCLIENTECOD { get; set; }

        [MapField("CCM02TIPOCLIENTEDESC")]
        public string CCM02TIPOCLIENTEDESC { get; set; }

        //Linea de credito
        [MapField("ccm02LineaCreditoMoneda")]
        public string ccm02LineaCreditoMoneda { get; set; }
        [MapField("ccm02LineaCreditoImporteSolicitado")]
        public double ccm02LineaCreditoImporteSolicitado { get; set; }
        [MapField("ccm02LineaCreditoImporteConcedido")]
        public double ccm02LineaCreditoImporteConcedido { get; set; }
        [MapField("ccm02LineaCreditoCondicionPago")]
        public int ccm02LineaCreditoCondicionPago { get; set; }

        [MapField("ccm02paiscodigo")]
        public string ccm02paiscodigo { get; set; }

        [MapField("ccm02EntidadEmiCod")]
        public string ccm02EntidadEmiCod { get; set; }

        [MapField("ccm02NroRegistroMTC")]
        public string ccm02NroRegistroMTC { get; set; }

        [MapField("ccm02TarjetaUnicaCirculacion")]
        public string ccm02TarjetaUnicaCirculacion { get; set; }

        public string txtfecnac { get; set; }
        public string txtfec { get; set; }
    }
}




