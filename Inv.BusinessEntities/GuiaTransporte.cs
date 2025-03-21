using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;
namespace Inv.BusinessEntities
{
     [TableName("FAC34_GUIAREMISION")]
  public   class GuiaTransporte
    {
         //N° Documento
          [MapField("FAC34NROGUIA")]
         public string FAC34NROGUIA { get; set; }
         
         //Fecha
          [MapField("FAC34FECHA")]
          public Nullable<DateTime> FAC34FECHA { get; set; }

         //Unid.Transportista
          [MapField("FAC34TRAYCODIGO")]
          public string FAC34TRAYCODIGO { get; set; }
         
         //Transportista
          [MapField("FAC34CHOFNOMBRE")]
          public string FAC34CHOFNOMBRE { get; set; }
         
         //Estado
          [MapField("FAC67DESESTADO")]
          //public string FAC67DESESTADO { get; set; }
          
          public string FAC67DESESTADO {get; set;}
         //Pendiente
          [MapField("FAC34ESTADOLLENADO")]
          public string FAC34ESTADOLLENADO { get; set; }

          [MapField("FAC01COD")]
          public string FAC01COD { get; set; }

          [MapField("FAC34SERIEGUIA")]
          public string FAC34SERIEGUIA { get; set; }

          [MapField("FAC34CORRELATIVOGUIA")]
          public string FAC34CORRELATIVOGUIA { get; set; }

          [MapField("FAC03COD")]
          public string FAC03COD { get; set; }
	      [MapField("FAC03DESC")]
          public string FAC03DESC { get; set; }

          [MapField("FAC02COD")]
          public string FAC02COD { get; set; }

          [MapField("FAC03TIPART")]
          public string FAC03TIPART { get; set; }

          [MapField("FAC34FECHAINITRASLADO")]
          public string FAC34FECHAINITRASLADO { get; set; }

//'Origen
          [MapField("FAC34ORICODEMP")]
          public string FAC34ORICODEMP { get; set; }

          [MapField("FAC34ORICODESTAB")]
          public string FAC34ORICODESTAB { get; set; }

          [MapField("FAC34ORIDESESTAB")]
          public string FAC34ORIDESESTAB { get; set; }

         [MapField("FAC34ORIDOMPARTIDA")] 
         public string FAC34ORIDOMPARTIDA { get; set; }


//'Destino
         [MapField("FAC34DESCODEMP")]
         public string FAC34DESCODEMP { get; set; }

         [MapField("FAC34DESDESEMP")]
         public string FAC34DESDESEMP { get; set; }

         [MapField("FAC34DESCODESTAB")]
         public string FAC34DESCODESTAB { get; set; }

         [MapField("FAC34DESDESESTAB")]
         public string FAC34DESDESESTAB { get; set; }

         [MapField("FAC34DESTDIRECCION")]
        public string FAC34DESTDIRECCION { get; set; }

//'Transportitas
         [MapField("FAC34CODTRANSPORTISTA")]
         public string FAC34CODTRANSPORTISTA { get; set; }

         [MapField("FAC34DESTRANSPORTISTA")]
         public string FAC34DESTRANSPORTISTA { get; set; }


//'Vehiculo
  
         [MapField("FAC34TRAYPLACA")]
         public string FAC34TRAYPLACA { get; set; }

         [MapField("FAC34TRAYMARCA")]
         public string FAC34TRAYMARCA { get; set; }


         [MapField("FAC34TRAYMARCASR")]
         public string FAC34TRAYMARCASR { get; set; }

         [MapField("FAC34TRAYPLACASR")]
         public string FAC34TRAYPLACASR { get; set; }

//'Chofer
         [MapField("FAC34CHOFCOD")]
         public string FAC34CHOFCOD { get; set; }
         
         [MapField("FAC34CHOFLICCONDUCIR")]
         public string FAC34CHOFLICCONDUCIR { get; set; }

//'Estado de guia
         [MapField("FAC34ESTADO")]
         public string FAC34ESTADO { get; set; }

//'Motivo
         [MapField("FAC34MOTRASLCOD")]
         public string FAC34MOTRASLCOD { get; set; }

         [MapField("FAC34MOTRASLDESC")]
         public string FAC34MOTRASLDESC { get; set; }

         [MapField("FAC34MOTRASLDESCEXTRA")]
         public string FAC34MOTRASLDESCEXTRA { get; set; }

         [MapField("FAC34OBSERVACION")]
         public string FAC34OBSERVACION { get; set; }

         [MapField("FAC34REFERENCIA")]
         public string FAC34REFERENCIA { get; set; }

         [MapField("FAC34CONTENEDOR")]
         public string FAC34CONTENEDOR { get; set; }

         [MapField("FAC34PRECINTO")]
         public string FAC34PRECINTO { get; set; }

         [MapField("FAC34FLAGORIPROD")]
         public string FAC34FLAGORIPROD { get; set; }


//'Cargra totales
         [MapField("FAC34TOTAL1")]
         public string FAC34TOTAL1 { get; set; }

         [MapField("FAC34TOTAL2")]
         public string FAC34TOTAL2 { get; set; }

         [MapField("FAC34TOTAL3")]
         public string FAC34TOTAL3 { get; set; }

         [MapField("FAC34TOTAL4")]
         public string FAC34TOTAL4 { get; set; }

         [MapField("FAC03SERIEXDEF")]
         public string FAC03SERIEXDEF { get; set; }
         
        /*Cabecera de Guia */
         [MapField("FAC34CODEMP")]
         public string   FAC34CODEMP {get; set;}
         [MapField("FAC34AA")]
         public string   FAC34AA {get; set;}
         [MapField("FAC34MM")]
         public string   FAC34MM {get; set;}
         public string FAC66FLAGDESEXTRA { get; set; }
         
         [MapField("FAC34CLICOD")]
         public string FAC34CLICOD { get; set; }

         [MapField("FAC34CLIDES")]
         public string FAC34CLIDES { get; set; }

         [MapField("FAC34OCTIPCOD")]
         public string FAC34OCTIPCOD { get; set; }

         [MapField("FAC34OCTIPDES")]
         public string FAC34OCTIPDES { get; set; }

         [MapField("FAC34OCNRO")]
         public string FAC34OCNRO { get; set; }

         [MapField("FAC34INDITRASLADOVEHICATM1")]
         public string FAC34INDITRASLADOVEHICATM1 { get; set; }

         [MapField("FAC34MODATRASLADO")]
         public string FAC34MODATRASLADO { get; set; }


		 [MapField("FAC34ESTADOPROCESOCOD")]
         public string FAC34ESTADOPROCESOCOD { get; set; }

         [MapField("FAC34ESTADOPROCESODES")]
         public string FAC34ESTADOPROCESODES { get; set; }

         [MapField("TipoClienteCod")]
         public string TipoClienteCod { get; set; }

         [MapField("TipoClienteDesc")]
         public string TipoClienteDesc { get; set; }

		[MapField("OCClienteCod")]
         public string OCClienteCod { get; set; }


         [MapField("OCClienteDesc")]
         public string OCClienteDesc { get; set; }

         [MapField("OCTipoCod")]
         public string OCTipoCod { get; set; }

         [MapField("OCTipoDesc")]
         public string OCTipoDesc { get; set; }
         
         [MapField("FAC34CLAVE")]         
         public string FAC34CLAVE { get; set;}

         [MapField("ESTADODEFACTURACION")]
         public string ESTADODEFACTURACION { get; set; }



        [MapField("ProdDesc")]
         public string ProdDesc { get; set; }

         [MapField("FAC34PESOUNIMED")]
        public string FAC34PESOUNIMED { get; set; }

         [MapField("FAC34PESOCANTIDAD")]
         public decimal FAC34PESOCANTIDAD { get; set; }

         [MapField("GuiaElecEstadoSunat")]
         public string GuiaElecEstadoSunat { get; set; }
         //ELECTRONICA
         [MapField("GuiaElecEstadoEnvioaSUNAT")]
         public string GuiaElecEstadoEnvioaSUNAT { get; set; }
         [MapField("GuiaElecObservaciones")]
         public string GuiaElecObservaciones { get; set; }
         

         //FISICA
         [MapField("GuiaFisicaObservacion")]
         public string GuiaFisicaObservacion { get; set; }

         [MapField("GuiaFisicaEstado")]
         public string GuiaFisicaEstado { get; set; }



         //DATOS PROVEEDOR 
            [MapField("FAC34CODPROV")]
         public string FAC34CODPROV { get; set; }
       
           [MapField("FAC34DESCPROV")]
         public string FAC34DESCPROV { get; set; }

               [MapField("FAC34DIRECCPROV")]
           public string FAC34DIRECCPROV { get; set; }

        [MapField("FAC66FLAGPROVEEDORDEISI")]
        public string FAC66FLAGPROVEEDORDEISI { get; set; }




    }
}
