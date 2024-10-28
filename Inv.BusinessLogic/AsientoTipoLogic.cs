using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using Inv.BusinessEntities;
using Inv.DataAccess;
namespace Inv.BusinessLogic
{
    public class AsientoTipoLogic
    {

        #region Singleton
        private static volatile AsientoTipoLogic instance;
        private static object syncRoot = new Object();
        private AsientoTipoLogic() { }
        public static AsientoTipoLogic Instance
        {
            get
            {
                if (instance == null)
                {

                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AsientoTipoLogic();
                    }
                }
                return instance;
            }
        }
        #endregion

        public List<AsientoTipo> TraerCabAsientoTipo(string @FAC08CODEMP,
        string @campo, string @filro)
        {
            return Accessor.Spu_Fact_Trae_FAC08_CABASIENTOTIPO(@FAC08CODEMP, @campo, @filro);
        }


        public void InsertarCabAsientoTipo(string @FAC08CODEMP,
        string @FAC08COD, string @FAC08DES, string @FAC08CODLIBRO, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_FAC08_CABASIENTOTIPO(@FAC08CODEMP, @FAC08COD, @FAC08DES,
                @FAC08CODLIBRO, out @msgretorno);
        }


        public void ActualizarAsientoTipo(string @FAC08CODEMP,
        string @FAC08COD, string @FAC08DES, string @FAC08CODLIBRO, out string @msgretorno)
        { 
            Accessor.Spu_Fact_Upd_FAC08_CABASIENTOTIPO(@FAC08CODEMP,@FAC08COD, @FAC08DES, 
                     @FAC08CODLIBRO, out @msgretorno);
        }


        public void EliminarAsientoTipo(string @FAC08CODEMP,
        string @FAC08COD, out int @flag ,out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FAC08_CABASIENTOTIPO(@FAC08CODEMP, @FAC08COD, out @flag, out @msgretorno);
        }
        public List<AsientoTipo> TraerDetalleAsientoTipo(string @FAC09CODEMP, string @Anio,
        string @FAC08COD, string @campo, string @filtro)
        {
            return Accessor.Spu_Fact_Trae_FAC09_DETASIENTOTIPO(@FAC09CODEMP, @Anio, @FAC08COD, @campo, @filtro);
        }

        public List<Libro> TraeAyudaLibros(string @ccb02emp, string @Campo, string @filtro)
        {
            return Accessor.Spu_Fact_Trae_Libros(@ccb02emp, @Campo, @filtro);
        }


        public void InsertarDetTipoAsiento(AsientoTipo entidad, out int @flag,out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_FAC09_DETASIENTOTIPO(entidad.FAC09CODEMP, entidad.FAC08COD, 
                     entidad.FAC09ORDEN,entidad.FAC09CTA, entidad.FAC09FLAG, entidad.FAC09CAMPO,
                     entidad.FAC09PORCENTAJE, entidad.FAC09COLUMNA,  out @flag, out @msgretorno);
        }


        public void ActualizarDetTipoAsiento(AsientoTipo entidad,out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Upd_FAC09_DETASIENTOTIPO(entidad.FAC09CODEMP, entidad.FAC08COD,
                              entidad.FAC09ORDEN, entidad.FAC09CTA, entidad.FAC09FLAG, entidad.FAC09CAMPO,
                              entidad.FAC09PORCENTAJE, entidad.FAC09COLUMNA, out @flag, out  @msgretorno);
        }
        public void EliminarDetTipoAsiento(string @FAC09CODEMP, string @FAC08COD, int @FAC09ORDEN, out int @flag, out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FAC09_DETASIENTOTIPO(@FAC09CODEMP, @FAC08COD, @FAC09ORDEN, out @flag, out @msgretorno);
        }
        public List<CuentaContable> TraeAyudaCuentaContable(string @cEmpresa, string @ccm01aa, string @cCampo, string @cFiltro)
        { 
            return Accessor.Spu_Fact_Help_ccm01cta(@cEmpresa, @ccm01aa, @cCampo, @cFiltro);
        }

        public List<TablaGlobal> TraeAyudaTablaGlobal(string @glo01codigotabla, string @cCampo, string @cFiltro)
        {
            return Accessor.Spu_Glo_Trae_glo01tablas_Det(@glo01codigotabla, @cCampo, @cFiltro);
        }
        public List<AsientoTipo> TraeCabAsientoTipo(string @FAC08CODEMP, string @campo, string @filtro)
        { 
            return Accessor.Spu_Fact_Help_FAC08_CABASIENTOTIPO(@FAC08CODEMP, @campo, @filtro);
        }


        public List<ComprasAsientoTipo> ComprasTraeAsientosTipo(string @cEmpresa,string @cAnio, string @cOrden, string @cFiltro)
        {
            return Accessor.Spu_Com_Trae_ComAsientosTipo(@cEmpresa, @cAnio, @cOrden, @cFiltro);
        }

        public List<ComprasAsientoTipoDetalle> TraeDetalleAsientoTipo(string @cEmpresa, string @cAsiTipo, string @cAnio)
        { 
            return Accessor.TraeDetalleAsientoTipo(@cEmpresa, @cAsiTipo,@cAnio);
        }
       
        #region Accessor
        private static AsientoTipoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get 
            {
                return AsientoTipoAccesor.CreateInstance();
            }
        }
        #endregion
    }
}