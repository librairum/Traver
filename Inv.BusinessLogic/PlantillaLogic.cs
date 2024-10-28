using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
namespace Inv.BusinessLogic
{
   public  class PlantillaLogic
    {
        #region Singleton
        private static volatile PlantillaLogic instance;
        private static object syncRoot = new Object();

        private PlantillaLogic() { }

        public static PlantillaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PlantillaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        
        public void InsertarPlantilla(Plantilla plantilla ,out string @msgretorno) {

            Accessor.InsertarPlantilla(plantilla.FAC02CODEMP, plantilla.FAC02COD,
            plantilla.FAC02DESC, out @msgretorno);
        }


        public void ActualizarPlantilla(Plantilla plantilla, out string @msgretorno) {
            Accessor.ActualizarPlantilla(plantilla.FAC02CODEMP, plantilla.FAC02COD,
                plantilla.FAC02DESC, out @msgretorno);
        }


        public List<Plantilla> TraerPlantilla(string @FAC02CODEMP, string @campo,  string @filro) {
            return Accessor.TraerPlantilla(@FAC02CODEMP, @campo, @filro);
        }
        public void EliminarPlantilla(Plantilla plantilla,out string @msgretorno) {
            Accessor.EliminarPlantilla(plantilla.FAC02CODEMP, plantilla.FAC02COD, out @msgretorno);
        }

        public List<Plantilla> TraePlantillasFE(string @empresa = "")
        { 
            return Accessor.Spu_Fact_Trae_PlantillaFE("");
        }

        public void InsertarPlantillaFE(string @Fac70PlantillaFETipDoc, string @Fac70PlantillaFECod, 
        string @Fac70PlantillaFEDesc, out int @flag, out  string @msgretorno)
        { 
            Accessor.Spu_Fact_Ins_FAC70_PlantillaFE(@Fac70PlantillaFETipDoc,
            @Fac70PlantillaFECod, @Fac70PlantillaFEDesc, out @flag, out  @msgretorno);
        }

        public void ActualizarPlantillaFE(string @Fac70PlantillaFETipDoc,  string @Fac70PlantillaFECod, 
            string @Fac70PlantillaFEDesc, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_FAC70_PlantillaFE(@Fac70PlantillaFETipDoc,  @Fac70PlantillaFECod, 
                     @Fac70PlantillaFEDesc, out @flag, out @msgretorno);
        }
        public void EliminarPlantillaFE(string @Fac70PlantillaFETipDoc, string @Fac70PlantillaFECod,
        out int @flag, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Del_FAC70_PlantillaFE(@Fac70PlantillaFETipDoc, @Fac70PlantillaFECod, 
                                                                        out @flag, out @msgretorno);
        }
       // ===  Mantenimiento de Campos x Plantilla Factura Electronica
        public List<Plantilla> TraePlantillas()
        {
            return Accessor.Spu_Fact_Trae_Plantillas("01");
        }
    
        public List<Plantilla> TraeCamposxPlantilla(string @Fac72PlantillaFETipDoc, 
            string @Fac72PlantillaFECod)
        { 
            return Accessor.Spu_Fact_Trae_PlantixCamposOpcionalesDetalle( @Fac72PlantillaFETipDoc, 
             @Fac72PlantillaFECod);
        }

        public void InsertaCamposEnPlantilla(string @Fac72PlantillaFETipDoc, string @Fac72PlantillaFECod,
        string @rango, out int @flag, out string @mensaje)
        {
            Accessor.Spu_Fact_Ins_PlantixCamposOpcionales(@Fac72PlantillaFETipDoc, @Fac72PlantillaFECod, 
            @rango, out @flag, out @mensaje);
        }

        public List<Plantilla> TraePlantillaFE(string @Fac70PlantillaFETipDoc)
        {
            return Accessor.Spu_Fact_Help_TraePlantillFE(@Fac70PlantillaFETipDoc);
        }


        #region Accessor

        private static PlantillaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PlantillaAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
