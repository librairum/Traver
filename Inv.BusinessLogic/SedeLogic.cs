using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class SedeLogic
    {
         #region Singleton
        private static volatile SedeLogic instance;
        private static object syncRoot = new Object();

        private SedeLogic() { }

        public static SedeLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SedeLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region principalesmetodos
        public List<Sede> TraeSede(string empresa, string codigo, string come05clientetipana)
        {
            return Accessor.TraeSede(empresa, codigo, come05clientetipana);
        }

        public Sede TraeSedeRegistro(string empresa, string clientetipana, string clientecod, string sedeclientescod) {
            return Accessor.TraeSedeRegistro(empresa, clientetipana, clientecod, sedeclientescod);
        }

        public void SedeInsertar(Sede entidad,out string @MsgRetorno) {
            @MsgRetorno = string.Empty;
             Accessor.SedeInsertar(entidad.come05empresa, entidad.come05clientetipana, entidad.come05clientecod, entidad.come05sedeclientescod, entidad.come05sedeclientesdesc,
                entidad.come05sedeclientesdireccion, entidad.come05sedeclientesreferencia, out @MsgRetorno);
        }
        public void SedeActualizar(Sede entidad, out string @MsgRetorno) {
            @MsgRetorno = string.Empty;
            Accessor.SedeActualiar(entidad.come05empresa, entidad.come05clientetipana, entidad.come05clientecod, entidad.come05sedeclientescod, entidad.come05sedeclientesdesc,
                entidad.come05sedeclientesdireccion, entidad.come05sedeclientesreferencia, out @MsgRetorno);
        }
        public void SedeElminar(Sede entidad, out string @MsgRetorno) {
            @MsgRetorno = string.Empty;
            Accessor.SedeEliminar(entidad.come05empresa, entidad.come05clientetipana, entidad.come05clientecod, entidad.come05sedeclientescod, out @MsgRetorno);
        }

        public void SedeGeneraCodigo(Sede entidad, out string @MsgRetorno) {
            @MsgRetorno = string.Empty;
            Accessor.SedeGeneraCodigo(entidad.come05empresa, entidad.come05clientetipana, entidad.come05clientecod, out @MsgRetorno);
        }
        #endregion

 #region "facturacion"
        public List<Sede> TraeDireccionDestinatario(string @cCodigoEmp,string @come05clientetipana, string @cCodigoCliente)
        {
            return Accessor.Spu_Fac_Trae_DomicilioDestinatario(@cCodigoEmp, @come05clientetipana, @cCodigoCliente);
        }
        #endregion
        #region "metodo Globales"

        public List<Sede> Glo_TraeSedes(string @cCodigoEmp, string @cCodigoCliente)
        {
            return Accessor.Glo_TraeSedes(@cCodigoEmp, @cCodigoCliente);
        }

        public void Glo_InsertarSede(Sede sede,
                 out int @flag,out string @cMsgRetorno)
        {
            Accessor.Glo_InsertarSede(sede.come05empresa, sede.come05clientetipana, sede.come05clientecod, sede.come05sedeclientescod,
                sede.come05sedeclientesdesc, sede.come05sedeclientesdireccion, sede.come05sedeclientesreferencia,sede.come05DepCod,sede.come05ProvCod,
                sede.come05DistCod,sede.come05FlagDimiFiscal,sede.come05PuertoCod, out @flag,out @cMsgRetorno);

        }

        public void Glo_ActualizarSede(Sede sede,out int @flag, out string @cMsgRetorno)
        {
            Accessor.Glo_ActualizarSede(sede.come05empresa, sede.come05clientetipana, sede.come05clientecod, sede.come05sedeclientescod,
                        sede.come05sedeclientesdesc, sede.come05sedeclientesdireccion, sede.come05sedeclientesreferencia, sede.come05DepCod, sede.come05ProvCod,
                sede.come05DistCod, sede.come05FlagDimiFiscal, sede.come05PuertoCod, out @flag, out @cMsgRetorno);
        }
     

        public void Glo_EliminarSede(Sede sede, out string @cMsgRetorno)
        {
            Accessor.EliminarSede(sede.come05empresa, sede.come05clientetipana, sede.come05clientecod, sede.come05sedeclientescod
                , out @cMsgRetorno);

        }

        public Sede Glo_TraeSedeRegistro(string @come05empresa, string @come05clientetipana,
                    string @come05clientecod, string @come05sedeclientescod)
        {
            return Accessor.Glo_TraeSedeRegistro(@come05empresa, @come05clientetipana,
                        @come05clientecod, @come05sedeclientescod);
        }

        public void Glo_SedeGeneraCodigo(string @cCodEmp, string @cCodigoClientepana, string @cCodigoClienteCod, out string @MsgRetorno)
        {
            Accessor.Glo_SedeGeneraCodigo(@cCodEmp, @cCodigoClientepana, @cCodigoClienteCod, out @MsgRetorno);

        }
        #endregion
        #region Accessor

        private static SedeAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return SedeAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
