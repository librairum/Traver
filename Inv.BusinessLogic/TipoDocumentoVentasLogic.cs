using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data.SqlClient;
using System.Data;
namespace Inv.BusinessLogic
{
   public class TipoDocumentoVentasLogic
    {

        #region Singleton
        private static volatile TipoDocumentoVentasLogic instance;
        private static object syncRoot = new Object();

        private TipoDocumentoVentasLogic() { }

        public static TipoDocumentoVentasLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TipoDocumentoVentasLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
        public List<TipoDocumentoVentas> TraerTipoDocumentoVentas(string @FAC01CODEMP, string @campo, string @filtro) 
        {
            return Accessor.TraerTipoDocumentoVentas(@FAC01CODEMP, @campo, @filtro);
        }

        public void InsertarTipoDocumentVentas(TipoDocumentoVentas documento, out int @flag, out string msj)
        {
            Accessor.InsertarTipoDocumentVentas(documento.FAC01CODEMP, documento.FAC01COD,
            documento.FAC01DESC, documento.FAC01TIPDOC,  documento.FAC01FETIPDOC, 
            documento.FAC01CODLIBRO, out  @flag, out msj);
        }
       
		public void ActualizarTipoDocumentoVentas(TipoDocumentoVentas documento, out int @flag, out string msj) {
            Accessor.ActualizarTipoDocumentoVentas(documento.FAC01CODEMP, documento.FAC01COD,
            documento.FAC01DESC, documento.FAC01TIPDOC,  documento.FAC01FETIPDOC, 
            documento.FAC01CODLIBRO, out @flag, out msj);
        }
        public void EliminarTipoDocumentVentas(TipoDocumentoVentas documento, out int @flag, out string msj)
        {
            Accessor.EliminarTipoDocumentVentas(documento.FAC01CODEMP, documento.FAC01COD, out @flag, out msj);
        }

        #region Accessor

        private static TipoDocumentoVentasAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return TipoDocumentoVentasAccesor.CreateInstance(); }
            //get { return TipoDocumentoVentasAccesor.CreateInstance(); }
        }

        #endregion Accessor
    }
}
