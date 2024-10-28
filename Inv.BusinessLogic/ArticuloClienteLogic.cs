using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;
namespace Inv.BusinessLogic
{
    
   public  class ArticuloClienteLogic
    {
       #region Singleton
       private static volatile ArticuloClienteLogic instance;
        private static object syncRoot = new Object();

        private ArticuloClienteLogic() { }

        public static ArticuloClienteLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ArticuloClienteLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        public  void InsertarArticuloCliente(ArticuloCliente entidad,out string mensaje) {
            Accessor.InsertarArticuloCliente(entidad.In20codemp, entidad.In20clientecod, entidad.In20Codigo, entidad.In20Descripcion, entidad.In20Familia, entidad.In20UndMed,
                entidad.In20Formato, entidad.In20Color, entidad.In20Pulido, entidad.In20Relleno, entidad.In20Comentario, entidad.In20Especial, entidad.In20Especial1,
                entidad.In20UndxCaja, entidad.In20PiezasxCaja, entidad.In20estado,entidad.In20CodigoPropio, out mensaje);
        }
        public  void ActualizarArticuloCliente(ArticuloCliente entidad, out string mensaje) {
            Accessor.ActualizarArticuloCliente(entidad.In20codemp, entidad.In20clientecod, entidad.In20Codigo, entidad.In20Descripcion, entidad.In20Familia, entidad.In20UndMed,
                entidad.In20Formato, entidad.In20Color, entidad.In20Pulido, entidad.In20Relleno, entidad.In20Comentario, entidad.In20Especial, entidad.In20Especial1,
                entidad.In20UndxCaja, entidad.In20PiezasxCaja, entidad.In20estado, entidad.In20CodigoPropio, out mensaje);


           
        }
        public  void EliminarArticuloCliente(ArticuloCliente entidad, out string mensaje)
        {
            Accessor.EliminarArticuloCliente(entidad.In20codemp, entidad.In20clientecod, entidad.In20Codigo,entidad.In20CodigoPropio, out mensaje);
        }
        public List<ArticuloCliente> TraerArticuloCliente(string codigoEmpresa,string codigoCliente) {
            return Accessor.TraerArticuloCliente(codigoEmpresa,codigoCliente);
        }
        public List<ArticuloCliente> BuscarArticuloCliente(string codigoEmpresa, string Anho, string codigoProducto)
        {
            return Accessor.BuscarArticuloCliente(codigoEmpresa, Anho, codigoProducto);
        }
        public void Actualizar_CodigoPropio(string xIn20codemp, string xIn20clientecod, string xIn20Codigo, string xIn20CodigoPropio,
         out string xcMsgRetorno) {
             Accessor.Actualizar_CodigoPropio(xIn20codemp, xIn20clientecod, xIn20Codigo, xIn20CodigoPropio, out xcMsgRetorno);
        }
       public void EliminarEquivalencia(string In20codemp,string In20clientecod,string In20Codigo,string In20CodigoPropio,
                                                   out string  cMsgRetorno ){
                                                        Accessor.EliminarEquivalencia(In20codemp, In20clientecod, In20Codigo, In20CodigoPropio, out cMsgRetorno);
       }
        public List<ArticuloCliente> TraerArticuloClienteHelp(string codigoEmpresa, string codtipana) {
            return Accessor.TraerArticuloClienteHelp(codigoEmpresa, codtipana);
        }
       
        public List<ArticuloCliente> TraerEquiProdClientes(string xIn20codemp, string xccm02tipana, string xIn20CodigoPropio) { 
            return Accessor.TraerEquiProdClientes(xIn20codemp,xccm02tipana,xIn20CodigoPropio);
        }

        public List<ProductoEquivalentes> TraeEquivalenciaProductosCliente(string @FAC20CODEMP, string @FAC20Codigo)
        {
            return Accessor.Spu_Fact_Trae_EquivalenciaProductoClientes(@FAC20CODEMP, @FAC20Codigo);
        }

        public void EliminarEquivalenciaProducto(string @FAC20CODEMP, string @FAC20Codigo, string @FAC20PROVCODIGO,
              string @FAC20PROVPRODCOD, out string @msgretorno)
        {
            Accessor.Spu_Fact_Del_FAC20_PRODUCTOPROV(@FAC20CODEMP, @FAC20Codigo, @FAC20PROVCODIGO,
            @FAC20PROVPRODCOD, out @msgretorno);
        }
        public void InsertarEquivalenciaProducto(string @FAC20CODEMP, string @FAC20Codigo, string @FAC20PROVCODIGO,
                string @FAC20PROVPRODCOD, string @FAC20PROVPRODDESC, string @FAC20PROVPRODUNIMED, out string @msgretorno)
        {
            Accessor.Spu_Fact_Ins_FAC20_PRODUCTOPROV(@FAC20CODEMP, @FAC20Codigo, @FAC20PROVCODIGO,
            @FAC20PROVPRODCOD, @FAC20PROVPRODDESC, @FAC20PROVPRODUNIMED, out @msgretorno);
        }


       public void TraeFlagProductoCliente(string @FAC20CODEMP, string @FAC20PROVCODIGO , out int  @flag)
       {
            Accessor.Spu_Fac_Trae_FlagProductoCliente(@FAC20CODEMP, @FAC20PROVCODIGO , out @flag);
       }

       #region Accessor

        private static ArticuloClienteAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ArticuloClienteAccesor.CreateInstance(); }
        }
       
        #endregion Accessor


    }
}
