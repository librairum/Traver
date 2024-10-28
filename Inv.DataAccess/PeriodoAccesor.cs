using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;

namespace Inv.DataAccess
{
    public abstract class PeriodoAccesor : AccessorBase<PeriodoAccesor>
    {
        [SprocName("Spu_Inv_Trae_Periodos")]
        public abstract List<Periodo> PeriodoTraer(string @ccb03emp, string @anio);

        [SprocName("Spu_Inv_Trae_PeriodosTodos")]
        public abstract List<Periodo> PeriodoTraerTodos(string @ccb03emp);

        [SprocName("Spu_Inv_Trae_MesesxAnio")]
        public abstract List<Periodo> MesesxAnio(string @cEmpresa, string @cAno);

        [SprocName("Spu_Inv_Upd_PeriodoEstado")]
        public abstract void PeriodoModificarEstado(string @ccb03emp, string @ccb03cod, bool @ccb03proc, out int @flagok, out string @cMsgRetorno);

        [SprocName("sp_Inv_Genera_Periodo_Cierre")]
        public abstract void GeneraPeriodoCierre(string @cCodEmp, string @cAnnoOrigen, string @cAnnoDestino, out float @nRetornar);

        [SprocName("sp_Inv_Genera_Periodo_Apertura")]
        public abstract void GeneraPeriodoApertura(string @cCodEmp, string @cAnno, string @cAnnoDestino, string @cMes, out float @nRetornar);

        [SprocName("Spu_Inv_Rep_Kardex_Electronico")]
        public abstract DataTable Traer_Rep_Kardex_Electronico(string @EMPRESA, string @ANIO, string @MES, string @CODALM, string @cFiltro, string @XMLrango);
        //public abstract DataTable Traer_Rep_Kardex_Electronico(string @EMPRESA, string @ANIO, string @MES, string @CODALM, string @cFechaIni, string @cFechaFin, string @cFiltro, string @cMoneda);
        

        [SprocName("Spu_Inv_Rep_Kardex_Electronico")]
        public abstract DataTable Traer_Rep_Kardex_Electronico_txt();
        
   }
}
