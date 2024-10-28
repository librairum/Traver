using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using System.Data;
using Inv.BusinessEntities;
namespace Inv.DataAccess
{
    public abstract class HoraMuertaDetalleAccesor : AccessorBase<HoraMuertaDetalleAccesor>
    {
        [SprocName("Spu_Pro_Ins_HoraMuertaDetalle")]
        public abstract void InsertarHoraMuertaDet(string @PRO01CODEMP, string @PRO01DOCMOVAA, string @PRO01DOCMOVMM,
          string @PRO01DOCMOVTIPDOC, string @PRO01DOCMOVCODDOC, string @PRO01DOCMOVKEY, double @PRO01DOCMOVORDEN,
        int @PRO01CORRELATIVO,
          string @PRO01CODMOTIVO, string @PRO01FECHA, string @PRO01HORAINICIO,
          string @PRO01HORAFIN, string @PRO01OBSERVACION, out string @msg, out int @flag);

        [SprocName("Spu_Pro_Upd_HoraMuertaDetalle")]
        public abstract void ActualizarHoraMuertaDet(string @PRO01CODEMP, string @PRO01DOCMOVAA, string @PRO01DOCMOVMM,
                             string @PRO01DOCMOVTIPDOC, string @PRO01DOCMOVCODDOC, string @PRO01DOCMOVKEY, double @PRO01DOCMOVORDEN,
                             int @PRO01CORRELATIVO,
                             string @PRO01CODMOTIVO, string @PRO01FECHA, string @PRO01HORAINICIO,
                             string @PRO01HORAFIN, string @PRO01OBSERVACION, out string @msg, out int @flag);

        [SprocName("Spu_Pro_Del_HoraMuertaDetalle")]
        public abstract void EliminarHoraMuertaDet(string @PRO01CODEMP, string @PRO01DOCMOVAA, string @PRO01DOCMOVMM,
                                        string @PRO01DOCMOVTIPDOC, string @PRO01DOCMOVCODDOC, string @PRO01DOCMOVKEY, double @PRO01DOCMOVORDEN,
                                          int @PRO01CORRELATIVO,
                                          out string @msg, out int @flag);
        [SprocName("Spu_Pro_Traer_HoraMuertaDetalle")]
        public abstract List<HoraMuertaDetalle> TraerHoraMuertaDetalle(string @PRO01CODEMP, string @PRO01DOCMOVAA,
                        string @PRO01DOCMOVMM, string @PRO01DOCMOVTIPDOC, string @PRO01DOCMOVCODDOC,
                        string @Tipo);

        [SprocName("Spu_Pro_Traer_CorrelativoxHoraMuertaDetalle")]
        public abstract void TraerCorrelativo(string @PRO01CODEMP, string @PRO01DOCMOVAA, string @PRO01DOCMOVMM,
                                              string @PRO01DOCMOVTIPDOC, string @PRO01DOCMOVCODDOC,
                                              string @PRO01CODMOTIVO, out int @Correlativo);

        [SprocName("Spu_Pro_Rep_HorasMuertas")]
        public abstract DataTable Spu_Pro_Rep_HorasMuertas(string @empresa, string @anio, string @linea, string @fechaIni, string @fechaFin,
                                                        string @flag, string @XMLrango);

    }
}
