using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class ResponsableLogic
    {

        #region Singleton
        private static volatile ResponsableLogic instance;
        private static object syncRoot = new Object();

        private ResponsableLogic() { }

        public static ResponsableLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ResponsableLogic();
                    }
                }

                return instance;
            }
        }
        #endregion


        public List<Responsable> TraerResponsable(string codigoEmpresa,string tipo)
        {
            return Accessor.TraerResponsable(codigoEmpresa, "In23Codigo", "*", tipo);
        }

        public List<Responsable> TraerResponsableXAlm(string codigoEmpresa)
        {
            return Accessor.TraerResponsableXAlm(codigoEmpresa);
        }

        public List<Responsable> TraerResponsables(string codigoEmpresa)
        {
            return Accessor.TraerResponsables(codigoEmpresa);
        }

        public void InsertarResponsables(string @cCodEmp,
        string @cCodigo, string @cDescripcion, string @cTipo, out string @cMsgRetorno)
        {
            Accessor.sp_Inv_Ins_Responsable(@cCodEmp,@cCodigo,@cDescripcion, @cTipo, out @cMsgRetorno);
        }
        
        public void ActualizarResponsables(string @cCodEmp,
        string @cCodigo, string @cDescripcion, string @cTipo, out string @cMsgRetorno)
        {
            Accessor.sp_Inv_Upd_Responsable(@cCodEmp,@cCodigo, @cDescripcion, @cTipo, out @cMsgRetorno);
        }

        public void EliminarResponsables(string @cCodEmp, string @cCodigo,
        out string @cMsgRetorno)
        {
            Accessor.sp_Inv_Del_Responsable(@cCodEmp, @cCodigo, out @cMsgRetorno);
        }

        public void TraerResponsableNuevoCodigo(string codigoEmpresa, out string codigo)
        {
            Accessor.Spu_Inv_Trae_ResponsablesCodigo(codigoEmpresa, out codigo);
        }

        #region Accessor

        private static ResponsableAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ResponsableAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
