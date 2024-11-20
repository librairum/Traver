using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class InventarioFisicoLogic
    {
        #region Singleton
        private static volatile InventarioFisicoLogic instance;
        private static object syncRoot = new Object();

        private InventarioFisicoLogic() { }

        public static InventarioFisicoLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new InventarioFisicoLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region principalesmetodos

        public void InventarioFisicoInsertar(InventarioFisico InventarioFisico, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.InventarioFisicoInsertar(InventarioFisico.IN04CODEMP, InventarioFisico.IN04CODALM, InventarioFisico.IN04AA, string.Format("{0:yyyyMMdd}", InventarioFisico.IN04FECINV), out @cMsgRetorno);
        }


        public void InventarioFisicoEliminar(InventarioFisico InventarioFisico, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.InventarioFisicoEliminar(InventarioFisico.IN04CODEMP, InventarioFisico.IN04CODALM, InventarioFisico.IN04AA, string.Format("{0:yyyyMMdd}", InventarioFisico.IN04FECINV), out @cMsgRetorno);
        }


        public List<InventarioFisico> InventarioFisicoPorAnio(string @IN04CODEMP, string @IN04AA)
        {
            return Accessor.InventarioFisicoPorAnio(@IN04CODEMP, @IN04AA);
        }

        public List<InventarioFisico> InventarioFisicoTraer(string @In04CodEmp, string @in04aa, string @In04CodAlm, string @cFecha)
        {
            //return Accessor.InventarioFisicoTraer(InvFis.IN04CODEMP, InvFis.IN04AA, InvFis.IN04CODALM, string.Format("{0:yyyyMMdd}", InvFis.IN04FECINV));
            return Accessor.InventarioFisicoTraer(@In04CodEmp, @in04aa, @In04CodAlm, @cFecha);
        }

        public DataTable InventarioFisicoRepToma(string @In04CodEmp, string @in04aa, string @In04CodAlm, string @cFecha)
        {
            return Accessor.InventarioFisicoRepToma(@In04CodEmp, @in04aa, @In04CodAlm, @cFecha);
        }

        public DataTable InventarioFisicoRepDife(string @In04CodEmp, string @in04aa, string @In04CodAlm, string @cFecha)
        {
            return Accessor.InventarioFisicoRepDife(@In04CodEmp, @in04aa, @In04CodAlm, @cFecha);
        }

        public void InventarioFisicoUpd(InventarioFisico InvFis, out int @FlagOK, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.InventarioFisicoUpd(InvFis.IN04CODEMP, InvFis.IN04AA, 
                string.Format("{0:yyyyMMdd}", InvFis.IN04FECINV), InvFis.IN04CODALM, 
                InvFis.IN04KEY, InvFis.IN04ITEM, InvFis.IN04CANTFISICA, 
                InvFis.in04observacion, InvFis.in04estado,
                out @FlagOK, out @cMsgRetorno);
        }


        public void ActualizarInventarioMasivo(string @CodEmp, string @Anio, string @FechaInventario,
            string @CodigoAlmacen, string @XMLRango, out int @FlagOK, out string @Msg) { 
            Accessor.Spu_Inv_Upd_InventarioMasivo(@CodEmp, @Anio,  @FechaInventario,@CodigoAlmacen, 
                @XMLRango, out @FlagOK, out @Msg);
        }
        
        #endregion


        #region Accessor

        private static InventarioFisicoAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return InventarioFisicoAccesor.CreateInstance(); }
        }
        
        #endregion Accessor
    }
}
