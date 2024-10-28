using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Inv_Rep_MovimientosMP")]
    public class Spu_Inv_Rep_MovimientosMP
    {

        [MapField("IN07CODEMP")]
        public string IN07CODEMP { get; set; }
        
        [MapField("IN07AA")]
        public string IN07AA { get; set; }
        
        [MapField("IN07MM")]
        public string IN07MM { get; set; }
        
        [MapField("IN07TIPDOC")]
        public string IN07TIPDOC { get; set; }

        [MapField("IN07CODDOC")]
        public string IN07CODDOC { get; set; }
        
        [MapField("IN07CODALM")]
        public string IN07CODALM { get; set; }
        [MapField("IN07UNIMED")]
        public string IN07UNIMED { get; set; }

        [MapField("IN07FECDOC")]
        public Nullable<DateTime> IN07FECDOC { get; set; }
        
        
        [MapField("IN07KEY")]
        public string IN07KEY { get; set; }

        [MapField("CodProv")]
        public string CodProv { get; set; }
        
        [MapField("Proveedor")]
        public string Proveedor { get; set; }
        
        [MapField("CodigoCantera")]
        public string CodigoCantera { get; set; }
        
        [MapField("DescripcionCantera")]
        public string DescripcionCantera { get; set; }
        
        [MapField("CodigoContratista")]
        public string CodigoContratista { get; set; }

        [MapField("DescripcionContratista")]
        public string DescripcionContratista { get; set; }

        [MapField("descripcionMP")]
        public string descripcionMP { get; set; }

        [MapField("Color")]
        public string Color { get; set; }
        [MapField("Guia")]
        public string Guia { get; set; }

        [MapField("NroBloque")]
        public string NroBloque { get; set; }

        [MapField("IN07CODBLOQUEPROV")]
        public string IN07CODBLOQUEPROV { get; set; }

        [MapField("IN07LARGOCAN")]
        public double IN07LARGOCAN { get; set; }
        
        [MapField("IN07ANCHOCAN")]
        public double IN07ANCHOCAN { get; set; }
        
        [MapField("IN07ALTOCAN")]
        public double IN07ALTOCAN { get; set; }        
        
        [MapField("Volumen")]
        public double Volumen { get; set; }

        [MapField("IN07LARGO")]
        public double IN07LARGO { get; set; }
        [MapField("IN07ANCHO")]
        public double IN07ANCHO { get; set; }
        [MapField("IN07ALTO")]
        public double IN07ALTO { get; set; }
        [MapField("VolumenPL")]
        public double VolumenPL { get; set; }

        [MapField("ESTATUS")]
        public string ESTATUS { get; set; }
        [MapField("fechacorte")]
        public Nullable<DateTime> fechacorte { get; set; }
        /*
        	
01	2016	04	41	728402160404	03	MT3	2016-04-04 00:00:00.000	BLLAXXESPESPESPXXXXXXXXXXX	20420310383	MINERA DEISI S.A.C.	002	HUASCAR 2	20338067284	SERVICIOS MULTIPLES QUIN E.I.R.L.	BLOQUE TRAVERTINO Laguna ESPECIAL X ESPECIAL X ESPECIAL   	Laguna	16846	SMQ 4132	1.55	1.5	1.4	6.96696000	1.45	1.4	1.3	CORTADO	2016-04-04 00:00:00.000f
         */

    }
}
