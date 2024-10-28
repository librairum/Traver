using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
  public  abstract class ArticuloClienteAccesor:AccessorBase<ArticuloClienteAccesor>
    {
        /*
         Spu_Inv_Ins_ArtiCliente
         * Spu_Inv_Upd_ArtiCliente
         * Spu_Inv_Del_ArticuloCliente
         * Spu_Inv_Trae_ArticuloCliente
         */

      [SprocName("Spu_Inv_Ins_ArtiCliente")]

      public abstract void InsertarArticuloCliente(string @In20codemp,
string @In20clientecod,
string @In20Codigo,
string @In20Descripcion,
string @In20Familia,
string @In20UndMed,
string @In20Formato,
string @In20Color,
string @In20Pulido,
string @In20Relleno,
string @In20Comentario,
string @In20Especial,
string @In20Especial1,
double @In20UndxCaja,
int @In20PiezasxCaja,
string @In20estado,
string @In20CodigoPropio,
out string @cMsgRetorno);

      [SprocName("Spu_Inv_Upd_ArtiCliente")]
      public abstract void ActualizarArticuloCliente(string @In20codemp,
string @In20clientecod,
string @In20Codigo,
string @In20Descripcion,
string @In20Familia,
string @In20UndMed,
string @In20Formato,
string @In20Color,
string @In20Pulido,
string @In20Relleno,
string @In20Comentario,
string @In20Especial,
string @In20Especial1,
double @In20UndxCaja,
int @In20PiezasxCaja,
string @In20estado,
string @In20CodigoPropio,
out string @cMsgRetorno);
 
      [SprocName("Spu_Inv_Del_ArticuloCliente")]
      public abstract void EliminarArticuloCliente(string @In20codemp,
string @In20clientecod,
string @In20Codigo,string @In20CodigoPropio ,
out string @cMsgRetorno);
      //@In20codemp char(2),      codigo de empresa
       //@In20clientecod varchar(20)   codigo de cliente
      [SprocName("Spu_Inv_Trae_ArticuloCliente")]
      public abstract List<ArticuloCliente> TraerArticuloCliente(string @In20codemp, string @In20clientecod);

      /*para entregar los datos del producto mediante su codigo seleccionado*/
      //In01key - codigo original del producto 
      //in01aa - año del producto 
      // in02codemp  - codigo de la empresa
      [SprocName("Spu_Inv_BuscaArticuloxCliente")]
      public abstract List<ArticuloCliente> BuscarArticuloCliente(string @IN01CODEMP,string @IN01AA,string @IN01KEY);
      
      [SprocName("Spu_Inv_Help_in20artiClientes")]
      public abstract List<ArticuloCliente> TraerArticuloClienteHelp(string @In20codemp, string @ccm02tipana);
      //actualizo el campo de codigoPropio para ver en la grilal de equivalencias
      [SprocName("Spu_Inv_Ins_ArtEmpresaXArtClientes")]
      public abstract void Actualizar_CodigoPropio(string @In20codemp, string @In20clientecod, string @In20Codigo, string @In20CodigoPropio,
        out string @cMsgRetorno);
      //actualizo a vacio el campo de codigoPropio 
      [SprocName("Spu_Inv_Del_ArtEmpresaXArtClientes")]
      public abstract void EliminarEquivalencia(string @In20codemp, string @In20clientecod, string @In20Codigo, string @In20CodigoPropio,
                                                    out string @cMsgRetorno);

      //lista los de los productos que tiene relacion con los productos propios del cliente
      [SprocName("Spu_Inv_Trae_EquiProdClientes")]
      public abstract List<ArticuloCliente> TraerEquiProdClientes(string @In20codemp, string @ccm02tipana, string @In20CodigoPropio);


      [SprocName("Spu_Fact_Trae_EquivalenciaProductoClientes")]
      public abstract List<ProductoEquivalentes> Spu_Fact_Trae_EquivalenciaProductoClientes(string @FAC20CODEMP, string @FAC20Codigo);

      [SprocName("Spu_Fact_Del_FAC20_PRODUCTOPROV")]
      public abstract void Spu_Fact_Del_FAC20_PRODUCTOPROV(string @FAC20CODEMP, string @FAC20Codigo, string @FAC20PROVCODIGO,
      string @FAC20PROVPRODCOD, out string @msgretorno);

      [SprocName("Spu_Fact_Ins_FAC20_PRODUCTOPROV")]
      public abstract void Spu_Fact_Ins_FAC20_PRODUCTOPROV(string @FAC20CODEMP, string @FAC20Codigo, string @FAC20PROVCODIGO,
      string @FAC20PROVPRODCOD, string @FAC20PROVPRODDESC, string @FAC20PROVPRODUNIMED, out string @msgretorno);

      
      [SprocName("Spu_Fac_Trae_FlagProductoCliente")]
      public abstract void Spu_Fac_Trae_FlagProductoCliente(string @FAC20CODEMP, string @FAC20PROVCODIGO , out int @flag);

    }
}
