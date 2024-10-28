using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("MovimientoDTO")]
    public class MovimientoResponse
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
        public decimal Orden { get; set; }
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
        public decimal Cantidad { get; set; }
        [MapField("IN07COSUNI")]
        public double CostoUnidad { get; set; }
        [MapField("IN07COUNSO")]
        public double CostoSoles { get; set; }
        [MapField("IN07COUNDO")]
        public double CostoDolares { get; set; }
        [MapField("IN07IMPORT")]
        public double Importe { get; set; }
        [MapField("IN07IMPSOL")]
        public double ImporteSoles { get; set; }
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
        [MapField("IN07LARGO")]
        public double Largo { get; set; }
        [MapField("IN07ANCHO")]
        public double Ancho { get; set; }
        [MapField("IN07ALTO")]
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
        [MapField("In01DesLar")]
        public string DescripcionArticulo { get; set; }
        [MapField("IN07PEDVEN")]
        public string NroPedidoVenta { get; set; }
        [MapField("IN07ORDPROD")]
        public string OrdenProduccion { get; set; }
        [MapField("IN07NROCAJA")]
        public string NroCaja { get; set; }
        [MapField("IN07AREAXUNI")]
        public double Areaxuni { get; set; }
        [MapField("IN07FLAGSTOCKREAL")]
        public string IN07FLAGSTOCKREAL { get; set; }

        // Area
        [MapField("IN07AREA")]
        public double Area { get; set; }

        [MapField("IN07VOLUMEN")]
        public double Volumen { get; set; }

        [MapField("IN07PESO")]
        public double Peso { get; set; }

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

        [MapField("IN07PROVMATPRIMA")]
        public string IN07PROVMATPRIMA { get; set; }

        [MapField("ProvMatPrimaNombre")]
        public string ProvMatPrimaNombre { get; set; }
        
        //
        [MapField("in07pedvennum")]
        public string in07pedvennum { get; set; }
        [MapField("in07pedvencodprod")]
        public string in07pedvencodprod { get; set; }
        [MapField("in07pedvenitem")]
        public double in07pedvenitem { get; set; }

        [MapField("IN07CODCLI")]
        public string IN07CODCLI { get; set; }

        [MapField("in07observacion")]
        public string in07observacion { get; set; }

        [MapField("IN07DESCABEZADOSUP")]
        public double IN07DESCABEZADOSUP { get; set; }
        [MapField("IN07DESCABEZADOINF")]
        public double IN07DESCABEZADOINF { get; set; }



        public string Color { get; set; }
        public string ClienteNombre { get; set; }
        public object Botones { get; set; }

        public string CodigoBloque { get; set; }
        public string DesMaquina { get; set; }

        private string difVol;
        public string DifVol 
        {
            get 
            {

                return ((Largo * Alto * Ancho) - (LargoCan * AltoCan * AnchoCan)).ToString("0.00");
            }
            set 
            {
                this.difVol = value;
            }
        }

        private double volumenCan;        
        public double VolumenCan 
        {
            get 
            {
                return (LargoCan * AltoCan * AnchoCan);
            }
            set 
            {
                this.volumenCan = value;
            }
        }

        private string flag;
        public string Flag 
        {
            get 
            {                                
                return flag;
            }
            set 
            {
                this.flag = value;
            }
        }
        
        [MapField("MTS2")]
        public double MTS2 { get; set;}
        
        [MapField("MTS3")]
        public double MTS3 { get; set; }

        [MapField("codigoOperador")]
        public string codigoOperador { get; set; }

        [MapField("Operador")]
        public string Operador { get; set; }

        //Hora de salida para detalle de Produccion
        [MapField("IN07HORASALIDA")]
        public string IN07HORASALIDA { get; set; }
        
        [MapField("IN07NROCAJAINGRESO")]
        public string IN07NROCAJAINGRESO { get; set; }
        
        [MapField("IN07HORAINICIO")]
        public string IN07HORAINICIO { get; set; }
        
        [MapField("IN07HORAFINAL")]
        public string IN07HORAFINAL { get; set; }
        //Fecha de Proceso para el modulo de Detalle de Produccion
        [MapField("IN07FECHAPROCESO")]
        public Nullable<DateTime> IN07FECHAPROCESO { get; set; }

        [MapField("IN07ORDENTRABAJO")]
        public string IN07ORDENTRABAJO { get; set; }
        [MapField("IN07FLAGORIPRODUCCION")]
        public string IN07FLAGORIPRODUCCION {get;set;}
        [MapField("IN07SECUENCIA")]
        public string IN07SECUENCIA { get; set; }
        [MapField("IN07MOTIVOCOD")] // Campo para el codigo de motivo
        public string IN07MOTIVOCOD { get; set; }
        [MapField("DesMotivo")] // descripcion de motivo
        public string DesMotivo { get; set; }
        [MapField("DesAlmacen")]
        public string DesAlmacen { get; set; }

        [MapField("in07prodTurnoCod")]
        public string in07prodTurnoCod { get; set; }
        [MapField("in07prodTurnoDesc")]
        public string in07prodTurnoDesc { get; set; }
        private string flagBotones;
        public string FlagBotones
        {
            get
            {
                return flagBotones;
            }
            set
            {
                this.flagBotones = value;
            }
        }
        [MapField("CajaUnica")]
        public string CajaUnica { get; set; }

        [MapField("IN07CALIDADMP")]
        public string IN07CALIDADMP { get; set; }

        [MapField("IN07CODTRAANTERIOR")]
        public string IN07CODTRAANTERIOR { get; set; }
        

    }
}
