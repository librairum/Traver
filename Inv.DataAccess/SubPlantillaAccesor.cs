using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
  public abstract  class SubPlantillaAccesor : AccessorBase<SubPlantillaAccesor>
    {
      [SprocName("Spu_Fact_Ins_FAC03_SUBPLANTILLA")]
      public abstract void InsertarSubPlantilla(string @FAC03CODEMP, string @FAC03COD, string @FAC01COD,
      string @FAC02COD, string @FAC03DESC, string @FAC03FLAGNUMERA, int @FAC03CANITEMS,
      string @FAC03SERIEXDEF, string @FAC03TIPART, string @FAC03TIPOVENTA, string @FAC03PLANTILLAFE,
      string @FAC03TIPOOPERACIONFE, out int @flag, out string @msgretorno);


      [SprocName("Spu_Fact_Upd_FAC03_SUBPLANTILLA")]
      public abstract void ActualizarSubPlantilla(string @FAC03CODEMP, string @FAC03COD,
          string @FAC01COD, string @FAC02COD, string @FAC03DESC,
          string @FAC03FLAGNUMERA, int @FAC03CANITEMS, string @FAC03SERIEXDEF,
          string @FAC03TIPART, string @FAC03TIPOVENTA, string @FAC03PLANTILLAFE,
          string @FAC03TIPOOPERACIONFE, out int @flag, out string @msgretorno);

      [SprocName("Spu_Fact_DEL_FAC03_SUBPLANTILLA")]
      public abstract void EliminarSubPlantilla(string @FAC03CODEMP, string @FAC03COD, string @FAC01COD, out int @flag, out string @msgretorno);

      [SprocName("Spu_Fact_Trae_FAC03_SUBPLANTILLA")]
      public abstract List<SubPlantilla> TraeSubPlantilla(string @FAC03CODEMP, string @campo, string @filro);

      [SprocName("Spu_Fact_Dame_Descripcion")]
      public abstract void DameDescripcion(string @cCodigo, string @cFlag, out string @cDescripcion);



      //Set dcHelp.Recordset = CLS_COMANDO.Ejec_Comando_1("Spu_Fact_Trae_FAC01_TIPDOC", gbCodEmpresa$, "FAC01COD", "*")
      [SprocName("Spu_Fact_Trae_FAC01_TIPDOC")]
      public abstract List<TipoDocumentoVentas> TraeAyudaTipDoc(string @FAC01CODEMP,string @campo, string @filtro);
      //Set dcHelp.Recordset = CLS_COMANDO.Ejec_Comando_1("Spu_Fact_Trae_FAC02_PLANTILLA", gbCodEmpresa$, "FAC02COD", "*")
      [SprocName("Spu_Fact_Trae_FAC02_PLANTILLA")]
      public abstract List<Plantilla> TraeAyudaPlantilla(string @FAC02CODEMP, string @campo, string @filro);
          //Set dcHelp.Recordset = CLS_COMANDO.Ejec_Comando_1("Spu_Glo_Trae_glo01tablas_Det", "13", "glo01codigo", "*")
      
      //Trae los tipos de articulos
      [SprocName("Spu_Glo_Trae_glo01tablas_Det")]
      public abstract List<TablaGlobal> TraeAyudaProductos(string @glo01codigotabla, string @cCampo, string @cFiltro);


    }
}
