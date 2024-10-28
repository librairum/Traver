using System.Collections;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
using Inv.BusinessEntities;
using System.Data;

namespace Inv.DataAccess
{
    public abstract class AlmacenAccesor: AccessorBase<AlmacenAccesor>
    {
        [SprocName("Sp_Inv_Rep_Stock_Valorizado")]
        public abstract DataTable Traer_StockValorizado(string @Empresa, string @Ano, string @Mes, string @Almacen, string XML, string @cUsuario, string @cMoneda);
        [SprocName("sp_Inv_Help_Almacen")]
        public abstract List<Almacen> TraerAlmacen(string @cCodEmp, string @cCampo, string @cFiltro);
   
        [SprocName("sp_Inv_Trae_Almacen")]
        public abstract List<Almacen> AlmacenTraer(string @cCodEmp,string @cOrden,string @cFiltro);

        [SprocName("Spu_Inv_Trae_AlmacenXLineaXActividad")]
        public abstract List<Almacen> traerAlmacenXLineaXActividad(string @empresa, string @linea, string @actividad);
        
        [SprocName("Spu_Inv_Trae_AlmacenesMasTodos")]
        public abstract List<Almacen> AlmacenesMasTodos(string @in09codemp, string @cCampo, string @Filtro);
       
        [SprocName("Spu_Inv_Trae_AlmacenRegistro")]
        public abstract Almacen AlmacenTraerRegistro(string @in09codemp, string @in09codigo);

        [SprocName("sp_Inv_Ins_Almacen")]
        public abstract void AlmacenInsertar(string @cCodEmp,string @cCodigo,string @cDescripcion,string @cUbicacion,string @cCuenta,string @cDebhab,
                                             string @in09PRODNATURALEZA, string @in09flagmaterecuperacion,string @in09flagMatRechazado,
 											 string @In09FlagConsiderarProduccion,string @in09flagProductoBueno, string @in09lineacod, 
                                             string @in09actividadnivel1cod, string @in09FlagCostear, 
                                             out string @cMsgRetorno);

        [SprocName("sp_Inv_Upd_Almacen")]
        public abstract void AlmacenModificar(string @cCodEmp,string @cCodigo,string @cDescripcion,string @cUbicacion,string @cCuenta,string @cDebhab,
                                              string @in09PRODNATURALEZA, string @in09flagmaterecuperacion, string @in09flagMatRechazado,
											  string @In09FlagConsiderarProduccion,
                                              string @in09flagProductoBueno, 
                                              string @in09lineacod,
                                              string @in09actividadnivel1cod,
                                              string @in09FlagCostear,
                                              out string @cMsgRetorno);
        
        [SprocName("sp_Inv_Del_Almacen")]
        public abstract void AlmacenEliminar(string @cCodEmp ,string @cCodigo ,out string @cMsgRetorno);
        

        //REGISTRO COSTO CANTERA 
        [SprocName("Spu_Inv_Trae_Cantera_MPCosto")]
        public abstract DataTable TraerCostoCantera(string @IN20CODEMP, string @ANIO, string @MES);

        [SprocName("Spu_Inv_Trae_Cantera_MPCosto_Detalle")]
        public abstract DataTable TraerCostoCantera_Detalle(string @IN40CODEMP, string @IN40ANIO, string @IN40MES,string @IN40CANTERACOD);

        [SprocName("Spu_Inv_Ins_IN40COSTOMPXCANTERA")]
        public abstract string Insertar_DetalleCantera(string @IN40CODEMP, string @IN40ANIO, string @IN40MES, string @IN40CANTERACOD, string @IN40COSTOTIPOMPCOD, decimal @IN40IMPORTE, out string @cMsgRetorno, out int @flag);

        [SprocName("Spu_Inv_Upd_IN40COSTOMPXCANTERA")]
        public abstract string Actualizar_DetalleCantera(string @IN40CODEMP, string @IN40ANIO, string @IN40MES, string @IN40CANTERACOD, string @IN40COSTOTIPOMPCOD, decimal @IN40IMPORTE, out string @cMsgRetorno, out int @flag);

        [SprocName("Spu_Inv_Del_IN40COSTOMPXCANTERA")]
        public abstract string Eliminar_DetalleCantera(string @IN40CODEMP, string @IN40ANIO, string @IN40MES, string @IN40CANTERACOD, string @IN40COSTOTIPOMPCOD, out string @cMsgRetorno, out int @flag);

        //REGISTRO COSTO TRANSPORTE 

        [SprocName("Spu_Inv_Trae_Transporte_MPCosto")]
        public abstract DataTable TraerCostoTransporte(string @IN20CODEMP, string @ANIO, string @MES);

        [SprocName("Spu_Inv_Trae_Transporte_MPCosto_Detalle")]
        public abstract DataTable TraerCostoTransporte_Detalle(string @IN41CODEMP, string @IN41ANIO, string @IN41MES, string @IN41CANTERACOD);

        [SprocName("Spu_Inv_Cal_CostoMP")]
        public abstract DataTable TraerCostoMP(string @IN07CODEMP, string @IN07AA, string @IN07MM);

         [SprocName("Spu_Inv_CostoxBloque")]
        public abstract DataTable TraerCostoxBloque(string @IN42EMPRESA, string @IN42ANIO, string @IN42MES);


        [SprocName("Spu_Inv_Ins_IN41COSTOTRANSPORTEMPXCANTERA")]
        public abstract string Insertar_DetalleTransporte(string @IN41CODEMP ,  
string @IN41ANIO,  
string @IN41MES ,  
string  @IN41CANTERACOD ,  
string  @IN41BLOQUEMPCOD , 
decimal @IN41BLOQUEMPCANTIDAD ,  
string @IN41COSTOTIPOMPCOD ,
string @IN41CODCTE ,  
string @IN41TIPDOC ,
string  @IN41NRODOC ,
decimal @IN41IMPORTE ,
out string @cMsgRetorno ,  
out int @flag );

        [SprocName("Spu_Inv_Upd_IN41COSTOTRANSPORTEMPXCANTERA")]
        public abstract string Actualizar_DetalleTransporte(string @IN41CODEMP,
string @IN41ANIO,
string @IN41MES,
string @IN41CANTERACOD,
string @IN41BLOQUEMPCOD,
decimal @IN41BLOQUEMPCANTIDAD,
string @IN41COSTOTIPOMPCOD,
string @IN41CODCTE,
string @IN41TIPDOC,
string @IN41NRODOC,
decimal @IN41IMPORTE,
out string @cMsgRetorno,
out int @flag);

        [SprocName("Spu_Inv_Del_IN41COSTOTRANSPORTEMPXCANTERA")]
        public abstract string Eliminar_DetalleTransporte(string @IN41CODEMP ,      
string @IN41ANIO ,      
string @IN41MES ,      
string @IN41CANTERACOD ,    
string @IN41BLOQUEMPCOD ,
string @IN41CODCTE ,
string @IN41TIPDOC ,
string @IN41NRODOC ,
out string @cMsgRetorno  ,      
out int @flag    );


        [SprocName("Spu_Inv_Trae_BloquesparacosteoMP")]
        public abstract DataTable Traer_BloqueCosteo(string @IN07CODEMP, string @IN07AA, string @IN07MM);

        [SprocName("Spu_Inv_trae_FactTranporteBloques")]
        public abstract DataTable Traer_FactTransporteBloques(string @CO05CODEMP, string @CO05AA, string @CO05MES);

    
    }

}
