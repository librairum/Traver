using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using Inv.BusinessEntities;

namespace Inv.DataAccess
{
    public abstract class PackingListAccesor: AccessorBase<PackingListAccesor>
    {        
                                                         
        #region "Metodos en uso"
        [SprocName("Spu_Fac_Trae_PackingList")]
        public abstract List<PackingList> Spu_Fac_Trae_PackingList(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM);

        [SprocName("Spu_Fac_Trae_PackingDetalle")]
        public abstract List<PackingList> Spu_Fac_Trae_PackingDetalle(string @FAC61CODEMP, string @FAC61NUMERO);

        [SprocName("Spu_Fac_Trae_PackingListRegistro")]
        public abstract PackingList Spu_Fac_Trae_PackingListRegistro(string @FAC60CODEMP, string @FAC60NUMERO, string @FAC60AA, string @FAC60MM);

        [SprocName("Spu_Fac_Rep_PackingList")]
        public abstract DataTable Spu_Fac_Rep_PackingList(string @FAC60CODEMP, string @FAC60NUMERO);

        

        [SprocName("Spu_Fac_Trae_PackingListConsumible")]
        public abstract List<Spu_Fac_Trae_PackingListTodo> Spu_Fac_Trae_PackingListConsumible(string @FAC60CODEMP,
        string @FAC60AA, string @FAC60MM);

        

        [SprocName("Spu_Fac_Ins_PackingListDetXml")]
        public abstract void Spu_Fac_Ins_PackingListDetXml(string @FAC61CODEMP, string @FAC61NUMERO, string @XMLdetalle, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Trae_PedidosDisponibles")]
        public abstract List<Spu_Fac_Trae_PedidosDisponibles> Spu_Fac_Trae_PedidosDisponibles(string @come01empresa, string @come01clientetipdoc, string @come01clientecod);

        [SprocName("Spu_Fac_Ins_PackingListCab")]
        public abstract void Spu_Fac_Ins_PackingListCab(string @FAC60CODEMP,string @FAC60NUMERO,string @FAC60AA,string @FAC60MM,string @FAC60FECHA,string @FAC60CLIENTECOD,
        string @FAC60CONTAINERNRO, string @FAC60PRECINTONROS, out int @flag,out string @msgretorno);

        [SprocName("Spu_Fac_upd_packinglistcab")]
        public abstract void Spu_Fac_upd_packinglistcab(string @FAC60CODEMP, string @FAC60NUMERO, string @FAC60AA, string @FAC60MM, string @FAC60FECHA, string @FAC60CLIENTECOD, 
        string @FAC60CONTAINERNRO, string @FAC60PRECINTONROS, out int @flag, out string @msgretorno);

        [SprocName("Spu_Fac_Trae_PackingListNumero")]
        public abstract void Spu_Fac_Trae_PackingListNumero(string @FAC61CODEMP, out string @Numero, out string @msgretorno, out int @flag);


        
        
        #endregion                
        
        #region "Packing list manual"
        [SprocName("Spu_Fac_Ins_PackingListDetXmlManual")]
        public abstract void Spu_Fac_Ins_PackingListDetXmlManual(string @FAC61CODEMP, string @FAC61NUMERO,string @XMLdetalle,out int @flag,out string @msgretorno);

        [SprocName("Spu_Fac_Del_PackingListDetManual")]
        public abstract void Spu_Fac_Del_PackingListDetManual(string @FAC61CODEMP, string @FAC61NUMERO, int @FAC61ITEM, out int @flag, out string @msgretorno);
        
        [SprocName("Spu_Fac_Trae_TablaHtmlCorreo")]
        public abstract void Spu_Fac_Trae_TablaHtmlCorreo(out string @codigoHtmlOut);
        [SprocName("Spu_Fac_Ins_PackingImportar")]
        public abstract void Spu_Fac_Ins_PackingImportar(string @FAC60CODEMP, string @FAC60NUMERO, string @FAC60AA,
        string @FAC60MM, string @FAC60FECHA, string @FAC60CLIENTECOD, string @FAC60CONTAINERNRO, string @FAC60PRECINTONROS, 
        int @FAC61ITEM, int @FAC61SECUENCIA, string @FAC61PRODCODCLIENTE, string @FAC61PRODCODEMPRESA, string @FAC61PRODDESCRIPCION, 
        double @FAC61PRODLARGO, double @FAC61PRODANCHO, double @FAC61PRODALTO, string @FAC61PRODLARGOTEXTO, 
        string @FAC61PRODANCHOTEXTO, string @FAC61PRODALTOTEXTO, double @FAC61PRODPIEZASXCAJAS, double @FAC61PRODCANTIDAD,
        double @FAC61PRODCAJASCANTIDAD, double @FAC61PRODAREA, double @FAC61PRODPESO, string @FAC61PRODNROPROFORMACLIENTE, 
        string @FAC61PEDIDONUM, int @FAC61PEDITEM, string @FAC61OBSERVACIONES,  string @FAC61VENTAUNIMED, double @FAC61VENTAPRECIO, 
        double @FAC61VENTASUBTOTAL, string @flag, string @errores,  int @canterrores, string @codigousuario, string @sistema, 
        out int @flagEstadoOperacion, out string @msgretorno);
        
        [SprocName("Spu_Fac_Del_PackingImportar")]
        public abstract void Spu_Fac_Del_PackingImportar(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM, string @sistema, string @codigousuario, 
        out int @flag, out string @msgretorno);
        [SprocName("Spu_Fac_Ins_PackingDesdePackingImportar")]
        public abstract void Spu_Fac_Ins_PackingDesdePackingImportar(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM, 
        string @codigousuario, string @sistema,
        out int @flag, out string @msgretorno);
        [SprocName("Spu_Fac_Trae_ValidacionPackingImportador")]
        public abstract List<PackingImportar> Spu_Fac_Trae_ValidacionPackingImportador(string @FAC60CODEMP, string @FAC60AA, string @FAC60MM,
        string @sistema, string @usuario);
        [SprocName("Spu_Fac_Rep_PackingListFactura")]
        public abstract DataTable Spu_Fac_Rep_PackingListFactura(string @FAC60CODEMP, string @FAC60NUMERO);


        [SprocName("Spu_Fac_Rep_CertificadoOrigen")]
        public abstract DataTable Spu_Fac_Rep_CertificadoOrigen(string @FAC60CODEMP, string @FAC60NUMERO);
        [SprocName("Spu_Fac_Del_PackingList")]
        public abstract void Spu_Fac_Del_PackingList(string @FAC60CODEMP, string @FAC60NUMERO,
        out int @flag, out string @msgretorno);
        #endregion

        #region "Fuera de uso"
        [SprocName("Spu_Fac_Trae_PackingListTodo")]
        public abstract List<Spu_Come_Trae_PackingListTodo> Spu_Fac_Trae_PackingListTodo(string @FAC60CODEMP, string @FAC60AA,
        string @FAC60MM);
        [SprocName("Spu_Fac_Upd_PackingListDetXml")]
        public abstract void Spu_Fac_Upd_PackingListDetXml(string @FAC61CODEMP, string @FAC61NUMERO, string @XMLdetalle, 
        out int @flag, out string @msgretorno);
        [SprocName("Spu_Fac_Ins_FAC61_PACKINGLISTDET")]
        public abstract void Spu_Fac_Ins_FAC61_PACKINGLISTDET(string @FAC61CODEMP, string @FAC61NUMERO, int @FAC61ITEM, int @FAC61SECUENCIA,
        string @FAC61PRODCODCLIENTE, string @FAC61PRODCODEMPRESA, string @FAC61PRODDESCRIPCION, double @FAC61PRODLARGO,
        double @FAC61PRODANCHO, double @FAC61PRODALTO, string @FAC61PRODLARGOTEXTO, string @FAC61PRODANCHOTEXTO,
        string @FAC61PRODALTOTEXTO, double @FAC61PRODPIEZASXCAJAS, double @FAC61PRODCANTIDAD, double @FAC61PRODCAJASCANTIDAD,
        double @FAC61PRODAREA, double @FAC61PRODPESO, string @FAC61PRODNROPROFORMACLIENTE, string @FAC61PEDIDONUM, int @FAC61PEDITEM,
        string @FAC61OBSERVACIONES, string @FAC61VENTAUNIMED, double @FAC61VENTAPRECIO, double @FAC61VENTASUBTOTAL, out int @flag, out string @msgretorno);
        [SprocName("Spu_Fac_Trae_PackingDetalleNuevoItem")]
        public abstract void Spu_Fac_Trae_PackingDetalleNuevoItem(string @FAC61CODEMP, string @FAC61NUMERO, out int @NUEVO1ITEM, out int @flag, out string @msgretorno);
        #endregion
    }
}
