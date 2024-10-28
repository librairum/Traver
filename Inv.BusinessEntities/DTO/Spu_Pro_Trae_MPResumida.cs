using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;


namespace Inv.BusinessEntities
{
    [TableName("Spu_Pro_Trae_SalidaMPResumida")]
    public class Spu_Pro_Trae_MPResumida
    {
        [MapField("IN07CODEMP")]
        public string Empresa { get; set; }
        [MapField("IN07AA")]
        public string Anio { get; set; }

        [MapField("IN07MM")]
        public string Mes { get; set; }
        [MapField("IN07TIPDOC")]
        public string CodTipDoc { get; set; }

        [MapField("IN07CODDOC")]
        public string DocumentoCodigo { get; set; }
        [MapField("NroOrdenTrabajo")]
        public string NroOrdenTrabajo { get; set; }
        [MapField("AlmacenCodigo")]
        public string AlmacenCodigo { get; set; }

        [MapField("nrocaja")]
        public string nrocaja { get; set; }

        [MapField("IN07HORASALIDA")]
        public string HoraSalida { get; set; }

        [MapField("CanPiezas")]
        public double CanPiezas { get; set; }

        [MapField("CanArea")]
        public double CanArea { get; set; }

        [MapField("CanVolumen")]
        public double CanVolumen { get; set; }

        [MapField("Largo")]
        public double Largo { get; set; }

        [MapField("Ancho")]
        public double Ancho { get; set; }

        [MapField("Alto")]
        public double Alto { get; set; }

        [MapField("FechaIngresoUltima")]
        public DateTime? FechaIngresoUltima { get; set; }

        [MapField("IN07UNIMED")]
        public string unidadmedida { get; set; }

        [MapField("FechaIngresoUltimo")]
        public string FechaIngresoUltimo { get; set; }


        [MapField("ProductoCodigo")]
        public string ProductoCodigo { get; set; }

        [MapField("ProductoDescripcion")]
        public string ProductoDescripcion { get; set; }

        [MapField("TransaDesc")]
        public string TransaDesc { get; set; }

        [MapField("AlmacenDescripcion")]
        public string AlmacenDescripcion { get; set; }

    }
}
