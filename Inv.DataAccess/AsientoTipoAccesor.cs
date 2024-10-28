using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using Inv.BusinessEntities;
using Inv.DataAccess;
namespace Inv.DataAccess
{
    public abstract class AsientoTipoAccesor : AccessorBase<AsientoTipoAccesor>
    {
        [SprocName("Spu_Fact_Trae_FAC08_CABASIENTOTIPO")]
        public abstract List<AsientoTipo> Spu_Fact_Trae_FAC08_CABASIENTOTIPO(string @FAC08CODEMP,
        string @campo,string @filro);

        [SprocName("Spu_Fact_Ins_FAC08_CABASIENTOTIPO")]
        public abstract void Spu_Fact_Ins_FAC08_CABASIENTOTIPO (string @FAC08CODEMP,
        string @FAC08COD, string @FAC08DES,string @FAC08CODLIBRO,out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC08_CABASIENTOTIPO")]
        public abstract void Spu_Fact_Upd_FAC08_CABASIENTOTIPO (string @FAC08CODEMP,
        string @FAC08COD,string @FAC08DES,string @FAC08CODLIBRO, out string @msgretorno);

        [SprocName("Spu_Fact_Del_FAC08_CABASIENTOTIPO")]
        public abstract void Spu_Fact_Del_FAC08_CABASIENTOTIPO (string @FAC08CODEMP,
        string @FAC08COD, out int @flag, out string @msgretorno);

        // Traer el detalle de asiento tipo
        [SprocName("Spu_Fact_Trae_FAC09_DETASIENTOTIPO")]
        public abstract List<AsientoTipo> Spu_Fact_Trae_FAC09_DETASIENTOTIPO(string @FAC09CODEMP, string @Anio, 
        string @FAC08COD, string @campo, string @filtro);

        [SprocName("Spu_Fact_Trae_Libros")]
        public abstract  List<Libro>  Spu_Fact_Trae_Libros(string @ccb02emp, string @Campo, string @filtro);

        [SprocName("Spu_Fact_Ins_FAC09_DETASIENTOTIPO")]
        public abstract void Spu_Fact_Ins_FAC09_DETASIENTOTIPO(string @FAC09CODEMP, string @FAC08COD, int @FAC09ORDEN,
        string @FAC09CTA, string @FAC09FLAG, string @FAC09CAMPO, double @FAC09PORCENTAJE, string @FAC09COLUMNA,
        out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Upd_FAC09_DETASIENTOTIPO")]
        public abstract void Spu_Fact_Upd_FAC09_DETASIENTOTIPO(string @FAC09CODEMP, string @FAC08COD,
        int @FAC09ORDEN, string @FAC09CTA, string @FAC09FLAG, string @FAC09CAMPO,
        double @FAC09PORCENTAJE, string @FAC09COLUMNA, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fact_Del_FAC09_DETASIENTOTIPO")]
        public abstract void Spu_Fact_Del_FAC09_DETASIENTOTIPO(string @FAC09CODEMP, string @FAC08COD, int @FAC09ORDEN, out int @flag, 
        out string @msgretorno);

        [SprocName("Spu_Fact_Help_ccm01cta")]
        public abstract List<CuentaContable> Spu_Fact_Help_ccm01cta(string @cEmpresa,string @ccm01aa,string @cCampo,string @cFiltro);

        [SprocName("Spu_Glo_Trae_glo01tablas_Det")]
        public abstract List<TablaGlobal> Spu_Glo_Trae_glo01tablas_Det(string @glo01codigotabla, string @cCampo, string @cFiltro);

        [SprocName("Spu_Fact_Help_FAC08_CABASIENTOTIPO")]
        public abstract List<AsientoTipo> Spu_Fact_Help_FAC08_CABASIENTOTIPO(string @FAC08CODEMP, string @campo, string @filtro);

        //[SprocName("Spu_Fact_Ins_Rango_Impresion")]
        //public abstract void Spu_Fact_Ins_Rango_Impresion(string @cEmpresa, string @cUsuario, string @cProceso, string @cValor, 
        //out int @flag,out string @cMsgRetorno);
              
        //[SprocName("Spu_Fact_Del_Rango_Impresion")]
        //public abstract void   Spu_Fact_Del_Rango_Impresion(string @cEmpresa,  string @cUsuario,  string @cProceso, 
        //out int @flag ,out string @msgretorno);
        
        

        [SprocName("Spu_Com_Trae_DetalleAsiTipo")]
        public abstract List<ComprasAsientoTipoDetalle> TraeDetalleAsientoTipo(string @cEmpresa, string @cAsiTipo, string @cAnio);

        [SprocName("Spu_Com_Trae_ComAsientosTipo")]
        public abstract List<ComprasAsientoTipo> Spu_Com_Trae_ComAsientosTipo(string @cEmpresa, string @cAnio, string @cOrden, string @cFiltro); 



    }
}
