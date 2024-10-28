using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using Inv.BusinessEntities.DTO;
namespace Inv.BusinessLogic
{
    public class TasasDistribucionLogic
    {
        #region Single

        private static volatile TasasDistribucionLogic instance;
        private static object syncRoot = new Object();
        private TasasDistribucionLogic() { }
        public static TasasDistribucionLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TasasDistribucionLogic();
                    }
                }
                return instance;
            }

        }
        #endregion

        public void InsertarTasasDsitribucion(TasasDistribucion tasadistribucion,
                                                     out string @msgretorno, out int @flag)
        {
            Accessor.InsertarTasasDsitribucion(tasadistribucion.COS01CODEMP, tasadistribucion.COS01ANIO, tasadistribucion.COS01MES,
                                               tasadistribucion.COS01LINEA, tasadistribucion.COS01LOTE,
                                               tasadistribucion.COS01ACTAPOYO, tasadistribucion.COS01ACTPRINCIPAL, tasadistribucion.COS01TASA,
                                               out @msgretorno, out @flag);
        }

        public void ActualizarTasasDistribucion(TasasDistribucion tasadistribucion,
                                                       out string @msgretorno, out int @flag)
        {
            Accessor.ActualizarTasasDistribucion(tasadistribucion.COS01CODEMP, tasadistribucion.COS01ANIO, tasadistribucion.COS01MES,
                                                 tasadistribucion.COS01LINEA, tasadistribucion.COS01LOTE,
                                                 tasadistribucion.COS01ACTAPOYO, tasadistribucion.COS01ACTPRINCIPAL,
                                                 tasadistribucion.COS01TASA, out @msgretorno, out @flag);
        }
        /// <summary>
        /// Trae las actividades principales por cada activida de apoyo para la distribucion de porcentaje en cada actividad principales.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<Spu_Cos_Traer_DistribucionxActividadApoyo> TraerDistribucionActividades(string @COS01CODEMP,
                            string @COS01ANIO, string @COS01MES, string @COS01LINEA, string @COS01LOTE, string @COS01ACTAPOYO,
                            string @COS03CODLINEAPRODUCCION)
        {
            return Accessor.TraerDistribucionxActividadApoyo(@COS01CODEMP, @COS01ANIO, @COS01MES, @COS01LINEA,
                @COS01LOTE, @COS01ACTAPOYO, @COS03CODLINEAPRODUCCION);
        }

        public List<Spu_Cos_Trae_GastosDistribuidos> TraerGastosDistribuidos(string @COS01CODEMP,
                            string @COS01ANIO, string @COS01MES, string @COS01LINEA, string @COS01LOTE)
        {
            return Accessor.TraerGastosDistribuidos(@COS01CODEMP, @COS01ANIO, @COS01MES, @COS01LINEA,
                @COS01LOTE);
        }

        public List<ContaGastosxEmpresaxLinea> TraerDistribucionesProduccion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES, string @COS01LINEACOD)
        {
            return Accessor.TraerDistribucionesProduccion(@COS01CODEMP, @COS01ANIO, @COS01MES, @COS01LINEACOD);
        }
        public int TraerCantidadRegistros(TasasDistribucion tasadistribucion, out int @Cantidad)
        {
            return Accessor.TraerCantidadRegistros(tasadistribucion.COS01CODEMP, tasadistribucion.COS01ANIO, tasadistribucion.COS01MES,
                                                    tasadistribucion.COS01LINEA, tasadistribucion.COS01LOTE, tasadistribucion.COS01ACTAPOYO,
                                                   tasadistribucion.COS01ACTPRINCIPAL, out @Cantidad);
        }
        public List<TasasDistribucion> TraerGastDistri(string @COS01CODEMP, string @COS01ANIO, string @COS01MES,
                                                    string @COS01LINEA, string @COS01LOTE)
        {
            return Accessor.TraerGastDistri(@COS01CODEMP, @COS01ANIO, @COS01MES,
                                                    @COS01LINEA, @COS01LOTE);
        }

        public void GenerarDistribucion(string @COS01CODEMP, string @COS01ANIO,
                        string @COS01MES, string @COS01LINEA, string @COS01LOTE)
        {
            Accessor.GenerarDistribucion(@COS01CODEMP, @COS01ANIO,
                                @COS01MES, @COS01LINEA, @COS01LOTE);
        }
        public List<Spu_Cos_Trae_DistribucionLineaxActApoyo> TraerDisttribucionLinea(string @PRO08CODEMP, string @COS01ANIO, string @COS01MES, string @COS01ACTAPOYO)
        {
            return Accessor.TraerDisttribucionLinea(@PRO08CODEMP, @COS01ANIO, @COS01MES, @COS01ACTAPOYO);
        }

        public void GuardarDistribucionTasaxLinea(string @XMLrango, out string @mensaje, out int @flag)
        {
            Accessor.Spu_Cos_Ins_DistribucionTasaxLinea(@XMLrango, out @mensaje, out @flag);
        }
        public void CalcularDistribucionProduccion(string @COS01CODEMP, string @COS01ANIO, string @COS01MES)
        {
            Accessor.Spu_Cos_Cal_DistxLinea(@COS01CODEMP, @COS01ANIO, @COS01MES);
        }
        #region "Accessor"

        private static TasasDistribucionAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TasasDistribucionAccesor.CreateInstance(); }
        }
        #endregion  Accessor
    }
}
