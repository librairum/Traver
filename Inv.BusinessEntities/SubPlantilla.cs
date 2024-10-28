using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{

    /*
     FAC03_SUBPLANTILLA
     */
    [TableName("FAC03_SUBPLANTILLA")]

  public   class SubPlantilla
    {
        [MapField("FAC03CODEMP")]
        public string FAC03CODEMP { get; set; }
        
        [MapField("FAC03COD")]
        public string FAC03COD { get; set; }
        
        [MapField("FAC01COD")]
        public string FAC01COD { get; set; }
        
        [MapField("FAC02COD")]
        public string FAC02COD { get; set; }
        
        [MapField("FAC03DESC")]
        public string FAC03DESC { get; set; }
        
        [MapField("FAC03FLAGNUMERA")]
        public string FAC03FLAGNUMERA { get; set; }
        
        [MapField("FAC03CANITEMS")]
        public int FAC03CANITEMS { get; set; }
        
        [MapField("FAC03SERIEXDEF")]
        public string FAC03SERIEXDEF { get; set; }
        
        [MapField("FAC03TIPART")]
        public string FAC03TIPART { get; set; }

        public string FAC01DESC { get; set; }

        public string FAC02DESC { get; set; }
        
        [MapField("FAC03TIPOVENTA")]
        public string FAC03TIPOVENTA { get; set; }

        [MapField("FAC03PLANTILLAFE")]
        public string FAC03PLANTILLAFE { get; set; }

        [MapField("FAC03TIPOOPERACIONFE")]
        public string FAC03TIPOOPERACIONFE { get; set; }

        private string filtro;
        public string Filtro 
        {
            get 
            {
                return this.FAC03COD + this.FAC01COD + this.FAC02COD;
            }
            set
            {
                this.filtro = value;
            }
        }
    }
}
