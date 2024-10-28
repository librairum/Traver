using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("In07movi")]
    public class Movimiento
    {
        [MapField("IN07CODEMP")]
        public string CodigoEmpresa { get; set; }
        [MapField("IN07AA")]
        public string Anio { get; set; }
        [MapField("IN07MM")]
        public string Mes { get; set; }
        [MapField("IN07TIPDOC")]
        public string CodigoTipoDocumento { get; set; }
        [MapField("IN07CODDOC")]
        public string CodigoDocumento { get; set; }

        [MapField("IN07KEY")]
        public string CodigoArticulo { get; set; }

        [MapField("IN07ORDEN")]
        public double Orden { get; set; }
        [MapField("IN07UNIMED")]
        public string UnidadMedida { get; set; }
        [MapField("IN07FECDOC")]
        public Nullable<DateTime> FechaDoc { get; set; }
        [MapField("IN07CODALM")]
        public string CodigoAlmacen { get; set; }
        [MapField("IN07CODTRA")]
        public string CodigoTransaccion { get; set; }
        [MapField("IN07TRANSA")]
        public string Transaccion { get; set; }

        [MapField("IN07CANART")]
        public double Cantidad { get; set; }
        [MapField("IN07IMPORT")]
        public double Importe { get; set; }
        [MapField("IN07COSUNI")]
        public double CostoUnidad { get; set; }

        [MapField("IN07COUNSO")]
        public double CostoSoles { get; set; }
        [MapField("IN07IMPSOL")]
        public double ImporteSoles { get; set; }

        [MapField("IN07COUNDO")]
        public double CostoDolares { get; set; }
        [MapField("IN07IMPDOL")]
        public double ImporteDolar { get; set; }

        

        

        [MapField("IN07COSALM")]
        public double CostoAlmacen { get; set; }
        [MapField("IN07IMPALM")]
        public double ImporteAlmacen { get; set; }
        [MapField("IN07COALSO")]
        public double CostoAlmacenSoles { get; set; }
        [MapField("IN07IMALSO")]
        public double ImporteAlmacenSoles { get; set; }
        [MapField("IN07COALDO")]
        public double CostoAlmacenDolar { get; set; }
        [MapField("IN07IMALDO")]
        public double ImporteAlmacenDolar { get; set; }
        [MapField("IN07CTAGTO")]
        public string CuentaGasto { get; set; }
        [MapField("IN07CTAING")]
        public string CuentaIngreso { get; set; }
        [MapField("Largo")]
        public double Largo { get; set; }
        [MapField("Ancho")]
        public double Ancho { get; set; }
        [MapField("Alto")]
        public double Alto { get; set; }
        [MapField("IN07LARGOCAN")]
        public double LargoCan { get; set; }
        [MapField("IN07ANCHOCAN")]
        public double AnchoCan { get; set; }
        [MapField("IN07ALTOCAN")]
        public double AltoCan { get; set; }
        [MapField("IN07PROMSOL")]
        public double PromedioSoles { get; set; }
        [MapField("IN07PROMDOL")]
        public double PromedioDolar { get; set; }
        [MapField("IN07STATUS")]
        public string Estado { get; set; }
        [MapField("IN07CODBLOQUEEMP")]
        public string CodBloEmp { get; set; }
        [MapField("IN07CODBLOQUEPROV")]
        public string CodBloqProv { get; set; }
        [MapField("IN07PEDVEN")]
        public string NroPedidoVenta { get; set; }
        [MapField("IN07ORDPROD")]
        public string OrdenProduccion { get; set; }
        [MapField("IN07NROCAJA")]
        public string NroCaja { get; set; }
        [MapField("IN07AREAXUNI")]
        public double Areaxuni { get; set; }
        //
        [MapField("IN07DocIngAA")]
        public string IN07DocIngAA { get; set; }
        [MapField("IN07DocIngMM")]
        public string IN07DocIngMM { get; set; }
        [MapField("IN07DocIngTIPDOC")]
        public string IN07DocIngTIPDOC { get; set; }
        [MapField("IN07DocIngCODDOC")]
        public string IN07DocIngCODDOC { get; set; }
        [MapField("IN07DocIngKEY")]
        public string IN07DocIngKEY { get; set; }
        [MapField("IN07DocIngORDEN")]
        public double IN07DocIngORDEN { get; set; }
        //
        [MapField("IN07FLAGSTOCKREAL")]
        public string IN07FLAGSTOCKREAL { get; set; }
        //
        [MapField("IN07PROVMATPRIMA")]
        public string IN07PROVMATPRIMA { get; set; }
        //

        [MapField("in07pedvennum")]
        public string in07pedvennum { get; set; }
        [MapField("in07pedvencodprod")]
        public string in07pedvencodprod { get; set; }
        [MapField("in07pedvenitem")]
        public double in07pedvenitem { get; set; }

        [MapField("IN07CODCLI")]
        public string in07codcli {get;set;}

        public string ClienteNombre { get; set; }

        [MapField("AlmacenDesc")]
        public string AlmacenDesc { get; set; }

        public string ProductoDesc { get; set; }
        
        [MapField("In01Deslar")]
        public string In01DesLar { get; set; }


        [MapField("IN07ORDENTRABAJO")]
        public string IN07ORDENTRABAJO { get; set; }
        
        public string in09descripcion { get; set; }

        [MapField("in07observacion")]
        public string in07observacion { get; set; }

        [MapField("IN07OPERADOR")]
        public string operador { get; set; }

        [MapField("Area")]
        public double Area { get; set; }
        [MapField("volumen")]
        public double volumen { get; set; }
        [MapField("IN07HORASALIDA")]
        public string IN07HORASALIDA { get; set; }
        [MapField("IN07HORASALIDATEXTO")]
        public string IN07HORASALIDATEXTO { get; set; }
        [MapField("IN07NROCAJAINGRESO")]
        public string IN07NROCAJAINGRESO { get; set; }
        [MapField("IN07HORAINICIO")]
        public string IN07HORAINICIO { get; set; }
        [MapField("IN07HORAFINAL")]
        public string IN07HORAFINAL {get;set;}
        //Fecha de Proceso para el modulo de Detalle de Produccion
        [MapField("IN07FECHAPROCESO")]
        public Nullable<DateTime> IN07FECHAPROCESO { get; set; }
        [MapField("IN07SECUENCIA")]
        public double IN07SECUENCIA { get; set; }

        [MapField("IN07MOTIVOCOD")] // Codigo de motivo
        public string IN07MOTIVOCOD { get; set; }
        // campos para ayuda de Stock Linea
        [MapField("FechaIngresoUltima")]
        public string FechaIngresoUltima { get; set; }
        [MapField("Stock")]
        public string Stock { get; set; }

        public string chkSelect { get; set; }

        /*Campos de ingreso de stock de linea*/
        [MapField("IngLineanroCaja")]
        public string IngLineanroCaja { get; set; }        
        [MapField("IngLineaOT")]
        public string IngLineaOT {get;set;}
        [MapField("IngLineaAlmCod")]
        public string IngLineaAlmCod { get; set; }
        [MapField("IngLineaProductoCod")]
        public string IngLineaProductoCod { get; set; }
        [MapField("in07prodTurnoCod")]
        public string in07prodTurnoCod { get; set; }
        
        // Campo Color 
        public string Color { get; set; }

        [MapField("IN07DESCABEZADOSUP")]
        public double IN07DESCABEZADOSUP { get; set; }
        [MapField("IN07DESCABEZADOINF")]
        public double IN07DESCABEZADOINF { get; set; }
        // Campos para relaciona Packing con Detalle de salida de movimiento
        [MapField("IN01COD")]
        public string GuiaTipoDocumento { get; set; }
        [MapField("FAC34NROGUIA")]
        public string GuiaNro { get; set; }

        [MapField("IN07GUIACODDET")]
        public int GuiaItem { get; set; }

        [MapField("IN07GUIACODPROD")]
        public string GuiaCodProd { get; set; }

        [MapField("IN07GUIATIPDOCCOD")]
        public string GuiaTipCod { get; set; }

        [MapField("IN07GUIAPRODANCHO")]
        public double GuiaProdAncho { get; set; }

        [MapField("IN07GUIAPRODLARGO")]
        public double GuiaProdLargo { get; set; }

        [MapField("IN07GUIAPRODESPESOR")]
        public double GuiaProdAlto { get; set; }

        [MapField("IN07GUIACANTIDAD")]
        public double GuiaCantidad { get; set; }

        [MapField("IN06REFDOC")]
        public string ReferenciaDoc { get; set; }

        [MapField("FlagRelacion")]
        public string FlagRelacion { get; set; }
        
        [MapField("FAC35CODPROD")]
        public string GuiaCodigoProd { get; set; }

        [MapField("come01pedvenproancho")]
        public string PedVenAncho { get; set; }

        [MapField("come01pedvenprolargo")]
        public string PedVenLargo { get; set; }

        [MapField("come01pedvenproespesor")]
        public string PedVenAlto { get; set; }

        [MapField("DocSalidaGuiaNro")]
        public string DocSalidaGuiaNro { get; set; }

        [MapField("XMLDetalle")]
        public string @XMLDetalle { get; set; }

        [MapField("IN07CALIDADMP")]
        public string IN07CALIDADMP { get; set; }
        
        //codigo de orden fila
        private string ordenfila;
        public string obtenerOrden{
            get{
                return this.CodigoEmpresa + this.Anio + this.Mes +
                this.CodigoTipoDocumento + this.CodigoDocumento +
                this.CodigoArticulo + this.Orden;
            }
                
        }
            
        
        
    }
}
