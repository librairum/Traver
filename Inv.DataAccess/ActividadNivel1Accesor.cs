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
    public abstract class ActividadNivel1Accesor : AccessorBase<ActividadNivel1Accesor>
    {
      [SprocName("Spu_Pro_Ins_PRO09ACTIVIDADNIVEL1")]
        public abstract void Spu_Pro_Ins_PRO09ACTIVIDADNIVEL1(string @PRO09CODEMP, string @PRO09LINEACOD, string @PRO09COD, string @PRO09DESC, 
                                                              string @PRO09ALMACENCOD, string @PRO09ALMMPXDEFECTO,
                                                              string @PRO09TIPDOCSALXDEFECTOMP, string @PRO09TRANSALXDEFECTOMP, out string @msgretorno);
        [SprocName("Spu_Pro_Upd_PRO09ACTIVIDADNIVEL1")]
        public abstract void Spu_Pro_Upd_PRO09ACTIVIDADNIVEL1(string @PRO09CODEMP, string @PRO09LINEACOD, string @PRO09COD, string @PRO09DESC,
                                                             string @PRO09ALMACENCOD, string @PRO09ALMMPXDEFECTO, string @PRO09TIPDOCSALXDEFECTOMP, 
                                                            string @PRO09TRANSALXDEFECTOMP,
                                                                out string @msgretorno);

        [SprocName("Spu_Pro_Del_PRO09ACTIVIDADNIVEL1")]
        public abstract void Spu_Pro_Del_PRO09ACTIVIDADNIVEL1( string @PRO09CODEMP, string @PRO09LINEACOD, string @PRO09COD, out string @msgretorno);

        [SprocName("Spu_Pro_Trae_PRO09ACTIVIDADNIVEL1")]
        public abstract List<ActividadNivel1> Spu_Pro_Trae_PRO09ACTIVIDADNIVEL1(string @PRO09CODEMP, string @PRO09LINEACOD);
        
        [SprocName("Spu_Pro_Trae_ActividadNivel1xLinea")]
        public abstract void Spu_Pro_Trae_ActividadNivel1xLinea(string @PRO09CODEMP, string @PRO09LINEACOD, string @PRO09COD, out string @actividadNivel1);

        [SprocName("Spu_Pro_Traer_PRO09ACTIVIDADNIVEL1REGISTRO")]
        public abstract ActividadNivel1 Spu_Pro_Traer_PRO09ACTIVIDADNIVEL1REGISTRO(string @PRO09CODEMP,string @PRO09LINEACOD,string @PRO09COD);

        [SprocName("Spu_Pro_Traer_AlmacenxProceso")]
        public abstract void Spu_Pro_Traer_AlmacenxProceso(string @PRO09CODEMP, string @PRO09LINEACOD, string @PRO09COD, out string @PRO09ALMACENCOD);

        [SprocName("Spu_Pro_Trae_CodigoActividadNivel1")]
        public abstract void Spu_Pro_Trae_CodigoActividadNivel1(string @codigoEmpresa, out string @codigo);

        [SprocName("Spu_Pro_Trae_ArtXActividad")]
        public abstract void Spu_Pro_Trae_ArtXActividad( string @IN04CODEMP, string @IN04AA, string @PRO09LINEACOD, string @PRO09COD);

        [SprocName("Spu_Inv_TraerNaturalxAlmacen")]
        public abstract ActividadNivel1 Spu_Inv_TraerNaturalxAlmacen(string @PRO09CODEMP, string @PRO09COD);

        [SprocName("Spu_Pro_Help_PRO09ACTIVIDADNIVEL1")]
        public abstract List<ActividadNivel1> Spu_Pro_Help_PRO09ACTIVIDADNIVEL1(string @PRO09CODEMP, string @PRO09LINEACOD);
        
        [SprocName("Spu_Cos_Trae_ActProduccion")]
        public abstract List<ActividadNivel1> TraerActividadesProdxEmpresa(string @Empresa);
        
        [SprocName("Spu_Pro_Rep_ConsumoMPxActividad")]
        public abstract DataTable TraerConsumoMPxActividad(string @Empresa, string @Anio, string @MesIni, 
                                                            string @MesFin, string @XMLrango);
        [SprocName("Spu_Inv_Traer_NaturalezaxAlmacen")]
        public abstract void Spu_Inv_Traer_NaturalezaxAlmacen( string @Empresa, string @codigo, out string @naturaleza);
        [SprocName("Spu_Pro_Trae_ActividadesRelacionadas")]
        public abstract List<ActividadNivel1> TraerActividadRelacionada(string @PRO09CODEMP);

    }
}
