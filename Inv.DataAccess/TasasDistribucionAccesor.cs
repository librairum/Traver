using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using Inv.BusinessEntities.DTO;
namespace Inv.DataAccess
{
    public abstract class TasasDistribucionAccesor : AccessorBase<TasasDistribucionAccesor>
    {
        [SprocName("Spu_Cos_Ins_CO01TASASDISTRIBUCION")]
        public abstract void InsertarTasasDsitribucion(string @Empresa, string @Anio, string @Mes, string @Linea, string @Lote,
                                                       string @ActividadApoyo, string @ActividadPrincipal, double @Tasa,
                                                       out string @msgretorno, out int @flag);
        [SprocName("Spu_Cos_Upd_CO01TASASDISTRIBUCION")]
        public abstract void ActualizarTasasDistribucion(string @Empresa, string @Anio, string @Mes, string @Linea, string @Lote,
                                                       string @ActividadApoyo, string @ActividadPrincipal, double @Tasa,
                                                       out string @msgretorno, out int @flag);
        //Trae las actividad principales + su porcentaje de distribcion filtraod por tipo de Actividad de apoyo.
        [SprocName("Spu_Cos_Traer_DistribucionxActividadApoyo")]
        public abstract List<Spu_Cos_Traer_DistribucionxActividadApoyo> TraerDistribucionxActividadApoyo(string @COS01CODEMP,
                                                                string @COS01ANIO, string @COS01MES, string @COS01LINEA,
                                                                string @COS01LOTE, string @COS01ACTAPOYO,
                                                                string @COS03CODLINEAPRODUCCION);

        [SprocName("Spu_Cos_Trae_GastosDistribuidos")]
        public abstract List<Spu_Cos_Trae_GastosDistribuidos> TraerGastosDistribuidos(string @COS01CODEMP,
                                                                string @COS01ANIO, string @COS01MES, string @COS01LINEA,
                                                                string @COS01LOTE);


        [SprocName("Spu_Cos_Traer_TasasDistribucion")]
        public abstract int TraerCantidadRegistros(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
                                                   string @COS01LINEA, string @COS01LOTE, string @COS01ACTAPOYO,
                                                   string @COS01ACTPRINCIPAL, out int @Cantidad);

        //Traer Distribucion de actividad de apoyo
        [SprocName("Spu_Cos_Traer_ContGastosDistri")]
        public abstract List<TasasDistribucion> TraerGastDistri(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
                                                    string @COS01LINEA, string @COS01LOTE);

        //Generar Distribucion de actividad de apoyo
        [SprocName("Spu_Cos_Ins_GenerarDistribucion")]
        public abstract void GenerarDistribucion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
                                                  string @COS01LINEA, string @COS01LOTE);

        [SprocName("Spu_Cos_Trae_DistribucionLineaxActApoyo")]
        public abstract List<Spu_Cos_Trae_DistribucionLineaxActApoyo> TraerDisttribucionLinea(string @PRO08CODEMP,
                                                        string @COS01ANIO, string @COS01MES, string @COS01ACTAPOYO);

        [SprocName("Spu_Cos_Ins_DistribucionTasaxLinea")]
        public abstract void Spu_Cos_Ins_DistribucionTasaxLinea(string @XMLrango, out string @mensaje, out int @flag);

        [SprocName("Spu_Cos_Trae_GastosDistribuidosProduccion")]
        public abstract List<ContaGastosxEmpresaxLinea> TraerDistribucionesProduccion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, string @COS01LINEACOD);
        [SprocName("Spu_Cos_Cal_DistxLinea")]
        public abstract void Spu_Cos_Cal_DistxLinea(string @COS01CODEMP, string @COS01ANIO, string @COS01MES);
    }
}
