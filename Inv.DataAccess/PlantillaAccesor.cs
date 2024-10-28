using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
  public abstract  class PlantillaAccesor : AccessorBase<PlantillaAccesor>
    {
      [SprocName("Spu_Fact_ins_Fac02_PLANTILLA")]
      public abstract void InsertarPlantilla(  string @FAC02CODEMP, string @FAC02COD,  
          string @FAC02DESC,  out string @msgretorno);
      
      [SprocName("Spu_Fact_Upd_Fac02_PLANTILLA")]
      public abstract void ActualizarPlantilla(string @FAC02CODEMP, string @FAC02COD, 
          string @FAC02DESC, out string @msgretorno );
       
      [SprocName("Spu_Fact_Trae_Fac02_PLANTILLA")]
      public abstract List<Plantilla> TraerPlantilla(string @FAC02CODEMP,  string @campo,   string @filro);

      [SprocName("Spu_Fact_Del_FAC02_PLANTILLA")]
      public abstract void EliminarPlantilla(string @FAC02CODEMP, string @FAC02COD, out string @msgretorno);

      // Facturacion Electronica
      [SprocName("Spu_Fact_Trae_PlantillaFE")]
      public abstract List<Plantilla> Spu_Fact_Trae_PlantillaFE(string @empresa);

      [SprocName("Spu_Fact_Ins_FAC70_PlantillaFE")]
      public abstract void Spu_Fact_Ins_FAC70_PlantillaFE(string @Fac70PlantillaFETipDoc,  
      string @Fac70PlantillaFECod ,  string @Fac70PlantillaFEDesc , 
      out int @flag, out  string @msgretorno);
      [SprocName("Spu_Fact_Upd_FAC70_PlantillaFE")]
      public abstract void Spu_Fact_Upd_FAC70_PlantillaFE(string @Fac70PlantillaFETipDoc, string @Fac70PlantillaFECod, 
          string @Fac70PlantillaFEDesc,
          out int @flag, out string @msgretorno);

      [SprocName("Spu_Fact_Del_FAC70_PlantillaFE")]
      public abstract void Spu_Fact_Del_FAC70_PlantillaFE(string @Fac70PlantillaFETipDoc, string @Fac70PlantillaFECod, 
      out int @flag,out string @msgretorno);
      [SprocName("Spu_Fact_Trae_Plantillas")]
      public abstract List<Plantilla> Spu_Fact_Trae_Plantillas(string @empresa);
      [SprocName("Spu_Fact_Trae_PlantixCamposOpcionalesDetalle")]
      public abstract List<Plantilla> Spu_Fact_Trae_PlantixCamposOpcionalesDetalle(string @Fac72PlantillaFETipDoc, string @Fac72PlantillaFECod);

      [SprocName("Spu_Fact_Ins_PlantixCamposOpcionales")]
      public abstract void Spu_Fact_Ins_PlantixCamposOpcionales(string @Fac72PlantillaFETipDoc, string @Fac72PlantillaFECod, 
      string @rango, out int @flag, out string @mensaje);

      [SprocName("Spu_Fact_Help_TraePlantillFE")]
      public abstract List<Plantilla> Spu_Fact_Help_TraePlantillFE(string @Fac70PlantillaFETipDoc);


      
    }
}
