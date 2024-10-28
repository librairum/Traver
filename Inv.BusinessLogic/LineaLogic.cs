using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
namespace Inv.BusinessLogic
{
   public class LineaLogic
    {
        #region Singleton
        private static volatile LineaLogic instance;
        private static object syncRoot = new Object();

        private LineaLogic() { }

        public static LineaLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LineaLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        

        public void LineaInsertar(Linea linea,out string @msgretorno){
           Accessor.Spu_Pro_Ins_PRO08LINEA(linea.codigoEmpresa, linea.codigo, linea.descripcion, out @msgretorno);
           }
        
    
        public void LineaActualizar(Linea linea, out string @msgretorno) 
        {
            Accessor.Spu_Pro_Upd_PRO08LINEA(linea.codigoEmpresa, linea.codigo, linea.descripcion, out @msgretorno);
        }
      
        public void LineaEliminar(Linea linea, out string @msgretorno)
        {
            Accessor.Spu_Pro_Del_PRO08LINEA(linea.codigoEmpresa, linea.codigo, out @msgretorno);
        }
       
        public List<Linea> LineaTraer(string @PRO08CODEMP) 
        {
            return Accessor.Spu_Pro_Trae_PRO08LINEA(@PRO08CODEMP);
        }
        public void LineaGeneraCodigo(string @codigoEmpresa, out string @codigo) {
             Accessor.Spu_Pro_Trae_CodigoLinea(@codigoEmpresa , out @codigo);
        }
        public Linea LineaTraerRegistro(string @codigoEmpresa,  string @codigo) 
        {
          return   Accessor.Spu_Pro_Traer_LineaRegistro(@codigoEmpresa,  @codigo);
        }
        public List<Linea> LineaAyuda(string codigoEmpresa) {
            return Accessor.sp_Pro_Help_Linea(codigoEmpresa, "", "*");
        }
        public List<Linea> LineasMasTodos(string codigoEmpresa)
        {
            return Accessor.Spu_Pro_Trae_LineasMasTodos(codigoEmpresa);
        }
        public List<Spu_Pro_Traer_OTxLinea> TraerProductosxOT(string @PRO13CODEMP, string @PRO13AA,
                                        string @fechaIni, string @fechaFin, string @PRO13LINEACOD)
        {
            return Accessor.Spu_Pro_Traer_OTxLinea(@PRO13CODEMP, @PRO13AA, @fechaIni, @fechaFin, @PRO13LINEACOD);
        }
        //
       //public LineaAyuda

        #region Accessor

        private static LineaAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return LineaAccesor.CreateInstance(); }
        }

        #endregion Accessor

    }
}
