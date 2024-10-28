using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class HoraMuertaDetalleLogic
    {
        #region Singleton
        private static volatile HoraMuertaDetalleLogic instance;
        private static object syncRoot = new Object();
        private HoraMuertaDetalleLogic() { }
        public static HoraMuertaDetalleLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new HoraMuertaDetalleLogic();
                    }
                }
                return instance;
            }

        }
        #endregion


        public void InsertarHoraMuertaDet(HoraMuertaDetalle hmd, out string @msg, out int @flag)
        {
            Accessor.InsertarHoraMuertaDet(hmd.PRO01CODEMP, hmd.PRO01DOCMOVAA, hmd.PRO01DOCMOVMM,
                     hmd.PRO01DOCMOVTIPDOC, hmd.PRO01DOCMOVCODDOC, hmd.PRO01DOCMOVKEY, hmd.PRO01DOCMOVORDEN,
                     hmd.PRO01CORRELATIVO, hmd.PRO01CODMOTIVO,
                      string.Format("{0:yyyyMMdd}", hmd.PRO01FECHA, 103), hmd.PRO01HORAINICIO, hmd.PRO01HORAFIN,
                      hmd.PRO01OBSERVACION, out @msg, out @flag);
        }


        public void ActualizarHoraMuertaDet(HoraMuertaDetalle hmd, out string @msg, out int @flag)
        {
            Accessor.ActualizarHoraMuertaDet(hmd.PRO01CODEMP, hmd.PRO01DOCMOVAA,
                      hmd.PRO01DOCMOVMM, hmd.PRO01DOCMOVTIPDOC, hmd.PRO01DOCMOVCODDOC, hmd.PRO01DOCMOVKEY, hmd.PRO01DOCMOVORDEN, hmd.PRO01CORRELATIVO,
                      hmd.PRO01CODMOTIVO, string.Format("{0:yyyyMMdd}", hmd.PRO01FECHA, 103), hmd.PRO01HORAINICIO, hmd.PRO01HORAFIN,
                      hmd.PRO01OBSERVACION, out @msg, out @flag);
        }


        public void EliminarHoraMuertaDet(HoraMuertaDetalle hmd, out string @msg, out int @flag)
        {
            Accessor.EliminarHoraMuertaDet(hmd.PRO01CODEMP, hmd.PRO01DOCMOVAA, hmd.PRO01DOCMOVMM,
            hmd.PRO01DOCMOVTIPDOC, hmd.PRO01DOCMOVCODDOC, hmd.PRO01DOCMOVKEY, hmd.PRO01DOCMOVORDEN, hmd.PRO01CORRELATIVO, out @msg, out @flag);
        }

        public List<HoraMuertaDetalle> TraerHoraMuertaDetalle(HoraMuertaDetalle hmd, string @Tipo)
        {
            return Accessor.TraerHoraMuertaDetalle(hmd.PRO01CODEMP, hmd.PRO01DOCMOVAA, hmd.PRO01DOCMOVMM,
                                hmd.PRO01DOCMOVTIPDOC, hmd.PRO01DOCMOVCODDOC, @Tipo);
        }
        public void TraerCorrelativo(HoraMuertaDetalle hmd, out int @Correlativo)
        {
            Accessor.TraerCorrelativo(hmd.PRO01CODEMP, hmd.PRO01DOCMOVAA, hmd.PRO01DOCMOVMM, hmd.PRO01DOCMOVTIPDOC,
                                                hmd.PRO01DOCMOVCODDOC, hmd.PRO01CODMOTIVO, out @Correlativo);
        }
        public DataTable TraerReporteHoraMuerta(string @empresa, string @anio, string @linea, string @fechaIni,
                                                                  string @fechaFin, string @flag, string @XMLrango)
        {
            return Accessor.Spu_Pro_Rep_HorasMuertas(@empresa, @anio, @linea, @fechaIni, @fechaFin, @flag, @XMLrango);
        }
        #region Accessor
        private static HoraMuertaDetalleAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return HoraMuertaDetalleAccesor.CreateInstance(); }
        }
        #endregion
    }
}
