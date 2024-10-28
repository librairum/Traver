using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;

namespace Inv.BusinessLogic
{
    public class ArticuloCaracteristicasLogic
    {
         #region Singleton
        private static volatile ArticuloCaracteristicasLogic instance;
        private static object syncRoot = new Object();

        private ArticuloCaracteristicasLogic() { }

        public static ArticuloCaracteristicasLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ArticuloCaracteristicasLogic();
                    }
                }

                return instance;
            }
        }
        #endregion
         #region Accessor

        private static ArticuloCaracteristicasAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ArticuloCaracteristicasAccesor.CreateInstance(); }
            
        }

        #endregion Accessor

      public List<ArticuloCaracteristicas> TraerArticuloCaracteristicas(string codigotabla)
        {
            return Accessor.TraerArticuloCaracteristicas (codigotabla);
        }

      public List<ArticuloCaracteristicas> ArticuloCaracteristicasTablas(string flagtabla)
        {
            return Accessor.ArticuloCaracteristicasTablas(flagtabla);
        }

      public ArticuloCaracteristicas ArticuloCaracteristicasRegistro(string codigotabla, string codigo)
        {
            return Accessor.ArticuloCaracteristicasRegistro(codigotabla, codigo);
        }

      public List<ArticuloCaracteristicas> ArticuloCararcticasUnidMedXTipo(string codigotabla)
      {
          return Accessor.ArticuloCaracticasUnidMedXTipo(codigotabla);
      }
      public void ArticuloUnidadMedidaxTipoActualizar(ArticuloCaracteristicas entidad, out string @MsgRetorno)
      {
          @MsgRetorno = string.Empty;
          Accessor.ArticuloUnidadMedidaxTipoActualizar(entidad.codigotabla, entidad.codigo, entidad.glo01anchoUnimed, entidad.glo01largoUnimed,
              entidad.glo01altoUnimed, out @MsgRetorno);
      }
      // Mantenimiento
      public void ArticuloCaracteristicasInsertar(ArticuloCaracteristicas articulocaracteristicas, out int @flagok, out string @cMsgRetorno)
      {
          @cMsgRetorno = string.Empty;

          Accessor.ArticuloCaracteristicasInsertar(articulocaracteristicas.codigotabla, 
              articulocaracteristicas.codigo, articulocaracteristicas.descripcion, articulocaracteristicas.glo01texto1, 
              articulocaracteristicas.glocomentario, articulocaracteristicas.glo01lonCodTabla, articulocaracteristicas.glo01area,
              articulocaracteristicas.glo01descripcionAbreviada, out @flagok, out @cMsgRetorno);
      }

      public void ArticuloCaracteristicasModificar(ArticuloCaracteristicas articulocaracteristicas, out int @flagok, out string @cMsgRetorno)
      {
          @cMsgRetorno = string.Empty;

          Accessor.ArticuloCaracteristicasModificar(articulocaracteristicas.codigotabla, articulocaracteristicas.codigo, 
              articulocaracteristicas.descripcion, articulocaracteristicas.glo01texto1, articulocaracteristicas.glocomentario, 
              articulocaracteristicas.glo01lonCodTabla, articulocaracteristicas.glo01area, 
              articulocaracteristicas.glo01descripcionAbreviada,out @flagok, out @cMsgRetorno);
      }

      public void ArticuloCaracteristicasEliminar(ArticuloCaracteristicas articulocaracteristicas, out int @flagok , out string @cMsgRetorno)
      {
          @cMsgRetorno = string.Empty;

          Accessor.ArticuloCaracteristicasEliminar(articulocaracteristicas.codigotabla, articulocaracteristicas.codigo,out @flagok,out @cMsgRetorno);
      }

      
    }
       
}
