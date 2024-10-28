using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class CanterasLogic
    {
        #region Singleton
        private static volatile CanterasLogic instance;
        private static object syncRoot = new Object();

        private CanterasLogic() { }

        public static CanterasLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CanterasLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public List<Canteras> TraerCanteras(string @IN20CODEMP)
        {
            return Accessor.Spu_Inv_Traer_Canteras(@IN20CODEMP);
        }

        public List<Canteras> TraerCanterasxContratista(string @IN20CODEMP, string @Analisis, string @codigo)
        {
            return Accessor.Spu_Inv_Traer_CanterasxContratista(@IN20CODEMP, @Analisis, @codigo);
            //return CanterasAccesor.Spu_Inv_Traer_Canteras(@IN20CODEMP);
        }

        public void CanteraInsertar(Canteras cantera,out string @cMsgRetorno) {
            @cMsgRetorno = string.Empty;
            Accessor.Spu_Inv_Ins_Canteras(cantera.IN20CODEMP, cantera.IN20CODIGO, cantera.IN20DESC, cantera.IN20CODPROVEEDOR, out @cMsgRetorno);
        }

        public void CanteraActualizar(Canteras cantera, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.Spu_Inv_Upd_Canteras(cantera.IN20CODEMP, cantera.IN20CODIGO, cantera.IN20DESC, cantera.IN20CODPROVEEDOR, out @cMsgRetorno);
        }

        public void CanteraEliminar(Canteras cantera, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.Spu_Inv_Del_Canteras(cantera.IN20CODEMP, cantera.IN20CODIGO, cantera.IN20DESC, cantera.IN20CODPROVEEDOR, out @cMsgRetorno);
        }
        public Canteras CanteraTraerRegistro(string @IN20CODEMP, string @IN20CODIGO) {
            return Accessor.Spu_Inv_Traer_CanterasRegistro(@IN20CODEMP, @IN20CODIGO);
        }
        public void CanteraTraerCodigo(string @IN20CODEMP, out string @codigo) {
            Accessor.Spu_Inv_Traer_CanterasCodigo(@IN20CODEMP, out @codigo);
        }
        #region Accessor

        private static CanterasAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CanterasAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
