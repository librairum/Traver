using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inv.BusinessEntities;
using Inv.DataAccess;
using System.Data;

namespace Inv.BusinessLogic
{
    public class AlmacenLogic
    {
        #region Singleton
        private static volatile AlmacenLogic instance;
        private static object syncRoot = new Object();

        private AlmacenLogic() { }

        public static AlmacenLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AlmacenLogic();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region principalesmetodos
        public void AlmacenInsertar(Almacen almacen, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;
            Accessor.AlmacenInsertar(almacen.in09codemp, almacen.in09codigo, almacen.in09descripcion, almacen.in09ubicacion, almacen.In09Cuenta, almacen.In09DebHab, 
                                     almacen.in09PRODNATURALEZA, almacen.in09flagmaterecuperacion, almacen.in09flagMatRechazado,
                                     almacen.In09FlagConsiderarProduccion,almacen.in09flagProductoBueno, 
                                     almacen.in09lineacod, almacen.in09actividadnivel1cod,  almacen.in09FlagCostear,
                                     out @cMsgRetorno);
        }

        public void AlmacenModificar(Almacen almacen, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.AlmacenModificar(almacen.in09codemp, almacen.in09codigo, almacen.in09descripcion, almacen.in09ubicacion, almacen.In09Cuenta, almacen.In09DebHab,
                                      almacen.in09PRODNATURALEZA, almacen.in09flagmaterecuperacion, almacen.in09flagMatRechazado,
                                      almacen.In09FlagConsiderarProduccion, 
                                      almacen.in09flagProductoBueno, 
                                      almacen.in09lineacod, 
                                      almacen.in09actividadnivel1cod, 
                                      almacen.in09FlagCostear,
                                      out @cMsgRetorno);
        }

        public void AlmacenEliminar(Almacen almacen, out string @cMsgRetorno)
        {
            @cMsgRetorno = string.Empty;

            Accessor.AlmacenEliminar(almacen.in09codemp, almacen.in09codigo, out @cMsgRetorno);
        }

        public List<Almacen> AlmacenTraer(string empresa)
        {
            return Accessor.AlmacenTraer(empresa, "in09codigo", "*");
        }
        public List<Almacen> AlmacenTraerxNaturaleza(string empresa, string codigonaturaleza)
        {
            return Accessor.AlmacenTraer(empresa, "naturaleza", codigonaturaleza);
        }
        public List<Almacen> traerAlmacenXLineaXActividad(string empresa,string linea, string actividad)
        {
            return Accessor.traerAlmacenXLineaXActividad(empresa, linea, actividad);
        }
        
        public List<Almacen> AlmacenAutoComplete(string empresa) { 
            return Accessor.AlmacenTraer(empresa, "in09codigo", "autocomplete" );
        }
        public List<Almacen> AlmacenesMasTodos(string empresa)
        {
            return Accessor.AlmacenesMasTodos(empresa, "", "*");
        }

        public List<Almacen> AlmacenesxNaturaleza(string empresa, string naturaleza) //Se usa para cargar combos no ventasn de ayuda
        {
            return Accessor.AlmacenesMasTodos(empresa, naturaleza, "in09PRODNATURALEZA");
        }
        public Almacen AlmacenTraerRegistro(string empresa,string codigo)
        {
            return Accessor.AlmacenTraerRegistro(empresa, codigo);
        }
        #endregion principalesmetodos

        public List<Almacen> TraerAlmacen(string codigoEmpresa,string filtro) //  se usara para las ventasn de ayuda 
        {
            return Accessor.TraerAlmacen(codigoEmpresa, "sumiymatprima", filtro);
        }
        public List<Almacen> TraerTodos(string codigoEmpresa)
        {
            return Accessor.TraerAlmacen(codigoEmpresa, "", "*");
        }
        public List<ItemsList> ObtenerListItems(string codigoEmpresa)
        {
            var lista = Accessor.TraerAlmacen(codigoEmpresa, "", "*");
            return lista.Select(x => new ItemsList { Value = x.in09codigo, Text = x.in09descripcion}).ToList();
        }

        public List<ItemsList> ObtenerListItems1(string codigoEmpresa)
        {
            var lista = Accessor.TraerAlmacen(codigoEmpresa, "", "*");
            return lista.Select(x => new ItemsList { Value = x.in09codigo, Text = x.in09descripcion}).ToList();
        }
        //COSTO CANTERA 
        public DataTable TraerCostoCantera_Detalle(string @IN20CODEMP, string @ANIO, string @MES,string @IN40CANTERACOD)
        {
            return Accessor.TraerCostoCantera_Detalle(@IN20CODEMP, @ANIO, @MES, @IN40CANTERACOD);
        }
        public DataTable TraerCostoCantera(string @IN20CODEMP, string @ANIO, string @MES)
        {
            return Accessor.TraerCostoCantera(@IN20CODEMP, @ANIO, @MES);
        }
        public string Insertar_DetalleCantera(string @IN40CODEMP, string @IN40ANIO, string @IN40MES, string @IN40CANTERACOD, string @IN40COSTOTIPOMPCOD, decimal @IN40IMPORTE, out string @cMsgRetorno, out int @flag)
        {
            return Accessor.Insertar_DetalleCantera(@IN40CODEMP, @IN40ANIO, @IN40MES, @IN40CANTERACOD,@IN40COSTOTIPOMPCOD,@IN40IMPORTE, out @cMsgRetorno, out @flag);
        }
        public string Actualizar_DetalleCantera(string @IN40CODEMP, string @IN40ANIO, string @IN40MES, string @IN40CANTERACOD, string @IN40COSTOTIPOMPCOD, decimal @IN40IMPORTE, out string @cMsgRetorno, out int @flag)
        {
            return Accessor.Actualizar_DetalleCantera(@IN40CODEMP, @IN40ANIO, @IN40MES, @IN40CANTERACOD, @IN40COSTOTIPOMPCOD, @IN40IMPORTE, out @cMsgRetorno, out @flag);
        }
        public string Eliminar_DetalleCantera(string @IN40CODEMP, string @IN40ANIO, string @IN40MES, string @IN40CANTERACOD, string @IN40COSTOTIPOMPCOD, out string @cMsgRetorno, out int @flag)
        {
            return Accessor.Eliminar_DetalleCantera(@IN40CODEMP, @IN40ANIO, @IN40MES, @IN40CANTERACOD, @IN40COSTOTIPOMPCOD, out @cMsgRetorno, out @flag);
        }
        //COSTO CANTERA END

        //COSTO TRANSPORTE
        public DataTable TraerCostoTransporte_Detalle(string @IN20CODEMP, string @ANIO, string @MES, string @IN41CANTERACOD)
        {
            return Accessor.TraerCostoTransporte_Detalle(@IN20CODEMP, @ANIO, @MES, @IN41CANTERACOD);
        }
        public DataTable TraerCostoTransporte(string @IN20CODEMP, string @ANIO, string @MES)
        {
            return Accessor.TraerCostoTransporte(@IN20CODEMP, @ANIO, @MES);
        }
        public DataTable TraerCostoMP(string @IN07CODEMP, string @IN07AA, string @IN07MM) 
        {
            return Accessor.TraerCostoMP(@IN07CODEMP, @IN07AA, @IN07MM);
        }
        //
        public DataTable TraerCostoxBloque(string @IN42EMPRESA, string @IN42ANIO, string @IN42MES)
        {
            return Accessor.TraerCostoxBloque(@IN42EMPRESA, @IN42ANIO, @IN42MES);
        }
        public string Insertar_DetalleTransporte(string @IN41CODEMP,
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
out int @flag)
        {
            return Accessor.Insertar_DetalleTransporte( @IN41CODEMP ,  
 @IN41ANIO,  
 @IN41MES ,  
  @IN41CANTERACOD ,  
  @IN41BLOQUEMPCOD , 
 @IN41BLOQUEMPCANTIDAD ,  
 @IN41COSTOTIPOMPCOD ,
 @IN41CODCTE ,  
 @IN41TIPDOC ,
  @IN41NRODOC ,
 @IN41IMPORTE ,
out  @cMsgRetorno ,  
out  @flag );
        }
        public string Actualizar_DetalleTransporte(string @IN41CODEMP,
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
out int @flag)
        {
            return Accessor.Actualizar_DetalleTransporte( @IN41CODEMP ,  
 @IN41ANIO,  
 @IN41MES ,  
  @IN41CANTERACOD ,  
  @IN41BLOQUEMPCOD , 
 @IN41BLOQUEMPCANTIDAD ,  
 @IN41COSTOTIPOMPCOD ,
 @IN41CODCTE ,  
 @IN41TIPDOC ,
  @IN41NRODOC ,
 @IN41IMPORTE ,
out  @cMsgRetorno ,  
out  @flag);
        }
        public string Eliminar_DetalleTransporte(string @IN41CODEMP,
string @IN41ANIO,
string @IN41MES,
string @IN41CANTERACOD,
string @IN41BLOQUEMPCOD,
string @IN41CODCTE,
string @IN41TIPDOC,
string @IN41NRODOC,
out string @cMsgRetorno,
out int @flag)
        {
            return Accessor.Eliminar_DetalleTransporte(@IN41CODEMP, @IN41ANIO, @IN41MES, @IN41CANTERACOD, @IN41BLOQUEMPCOD, @IN41CODCTE, @IN41TIPDOC, @IN41NRODOC, out  @cMsgRetorno, out  @flag);
        }

        //COSTO TRANSPORTE END
        //Traer_BloqueCosteo
        public DataTable Traer_BloqueCosteo(string @IN07CODEMP, string @IN07AA, string @IN07MM)
        {
            return Accessor.Traer_BloqueCosteo(@IN07CODEMP,@IN07AA,@IN07MM);
        }
        //Traer_FactTransporteBloques
        public DataTable Traer_FactTransporteBloques(string @CO05CODEMP, string @CO05AA, string @CO05MES)
        {
            return Accessor.Traer_FactTransporteBloques(@CO05CODEMP, @CO05AA, @CO05MES);
        }
        public DataTable Traer_StockValorizado(string @Empresa,string @Ano,string @Mes,string @Almacen,string XML,string @Usuario,string @moneda) 
        {
            return Accessor.Traer_StockValorizado(@Empresa, @Ano, @Mes, @Almacen, XML, @Usuario, @moneda);
        }
   
        #region Accessor

        private static AlmacenAccesor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return AlmacenAccesor.CreateInstance(); }
        }
        
        #endregion Accessor
    }
}
