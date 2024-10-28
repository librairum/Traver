using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Rep_ArchiPlanoAlmacenes")]
    public class Spu_Inv_Rep_ArchiPlanoAlmacenes
    {
        [MapField("EmpresaCod")]
        public string EmpresaCod { get; set; }
        
        [MapField("Anio")]
        public string Anio { get; set; }
        
        [MapField("Mes")]
        public string Mes { get; set; }
        
        [MapField("TransaccionCod")]
        public string TransaccionCod { get; set; }

        [MapField("TransaccionDesc")]
        public string TransaccionDesc { get; set; }
        
        [MapField("EntradaoSalida")]
        public string EntradaoSalida { get; set; }
        
        [MapField("DocumentoNum")]
        public string DocumentoNum { get; set; }

        [MapField("Fecha")]
        public Nullable<DateTime> Fecha { get; set; }
        
        
        [MapField("DocRespaldoTip")]
        public string DocRespaldoTip { get; set; }

        [MapField("DocRespaldoDesc")]
        public string DocRespaldoDesc { get; set; }
        
        [MapField("DocRespaldoNro")]
        public string DocRespaldoNro { get; set; }

        [MapField("DocRespaldoCtaCteRUC")]
        public string DocRespaldoCtaCteRUC { get; set; }

        [MapField("DocRespaldoCtaCteDesc")]
        public string DocRespaldoCtaCteDesc { get; set; }

        [MapField("ProductoCod")]
        public string ProductoCod { get; set; }
        
        [MapField("ProductoDesc")]
        public string ProductoDesc { get; set; }

        [MapField("ProductoUniMed")]
        public string ProductoUniMed { get; set; }
        
        [MapField("Cantidad")]
        public double Cantidad { get; set; }

        [MapField("CostoSoles")]
        public double CostoSoles { get; set; }
        
        [MapField("ImporteSol")]
        public double ImporteSol { get; set; }
        
        [MapField("CostoPromedioSol")]
        public double CostoPromedioSol { get; set; }
    }
}
