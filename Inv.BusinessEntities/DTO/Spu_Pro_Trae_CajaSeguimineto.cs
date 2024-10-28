using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Pro_Trae_CajaSeguimineto")]
    public class Spu_Pro_Trae_CajaSeguimineto
    {
        [MapField("IN07CODEMP")]
        public string IN07CODEMP { get; set; }
        [MapField("IN07AA")]
        public string IN07AA { get; set; }
        [MapField("IN07MM")]
        public string IN07MM { get; set; }
        [MapField("IN07CODDOC")]
        public string IN07CODDOC { get; set; }

        [MapField("IN07FECDOC")]
        public Nullable<DateTime> IN07FECDOC { get; set; }

        [MapField("IN07ORDENTRABAJO")]
        public string IN07ORDENTRABAJO { get; set; }
        
        [MapField("HoraSalida")]
        public string HoraSalida { get; set; }
        
        [MapField("IN07TRANSA")]
        public string IN07TRANSA { get; set; }

        [MapField("IN07KEY")]
        public string IN07KEY { get; set; }

        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }

        [MapField("IN07CANART")]
        public double IN07CANART { get; set; }

        [MapField("IN07LARGO")]
        public double IN07LARGO { get; set; }

        [MapField("IN07ANCHO")]
        public double IN07ANCHO { get; set; }

        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }

        [MapField("IN06REFDOC")]
        public string IN06REFDOC { get; set; }

        [MapField("TransaDescripcion")]
        public string TransaDescripcion { get; set; }

        [MapField("ProdDescripcion")]
        public string ProdDescripcion { get; set; }

        [MapField("AlmaDescripcion")]
        public string AlmaDescripcion { get; set; }

        [MapField("Sal_in07fecdoc")]
        public Nullable<DateTime>  Sal_in07fecdoc { get; set; }

        [MapField("Sal_HoraInicio")]
        public string Sal_HoraInicio { get; set; }

        [MapField("Sal_IN07ORDENTRABAJO")]
        public string Sal_IN07ORDENTRABAJO { get; set; }

        [MapField("Sal_IN07TRANSA")]
        public string Sal_IN07TRANSA { get; set; }

        [MapField("Sal_IN07CANART")]
        public double Sal_IN07CANART { get; set; }

        [MapField("Sal_IN06REFDOC")]
        public string Sal_IN06REFDOC { get; set; }

        [MapField("IN07TIPDOC")]
        public string IN07TIPDOC { get; set; }
        [MapField("Sal_TransaDescripcion")]
        public string Sal_TransaDescripcion { get; set; }
        [MapField("IN07ORDEN")]
        public string IN07ORDEN { get; set; }

        


    }
}
