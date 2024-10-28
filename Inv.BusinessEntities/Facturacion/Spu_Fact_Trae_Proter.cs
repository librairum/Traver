using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    [TableName("Spu_Fact_Trae_Proter")]
    public class Spu_Fact_Trae_Proter
    {
        [MapField("IN01CODEMP")]
        public string IN01CODEMP { get; set; }

        [MapField("IN01AA")]
        public string IN01AA { get; set; }

        [MapField("IN01KEY")]
        public string IN01KEY { get; set; }

        [MapField("IN01DESLAR")]
        public string IN01DESLAR { get; set; }

        [MapField("IN01UNIMED")]
        public string IN01UNIMED { get; set; }

        [MapField("IN01UNIDADEQUI")]
        public string IN01UNIDADEQUI { get; set; }

        [MapField("IN01MONTOEQUI")]
        public double IN01MONTOEQUI { get; set; }

        [MapField("IN01CODPRO")]
        public string IN01CODPRO { get; set; }

        [MapField("IN01FLAALM")]
        public string IN01FLAALM { get; set; }

        [MapField("IN01FLADES")]
        public string IN01FLADES { get; set; }

        [MapField("IN01FLAFAB")]
        public string IN01FLAFAB { get; set; }

        [MapField("IN01FECMAT")]
        public string IN01FECMAT { get; set; }

        [MapField("IN01CTAINGRESO")]
        public string IN01CTAINGRESO { get; set; }

        [MapField("IN01CTAEGRESO")]
        public string IN01CTAEGRESO { get; set; }

        [MapField("IN01MOV")]
        public string IN01MOV { get; set; }

        [MapField("IN01CTAGTO")]
        public string IN01CTAGTO { get; set; }

        [MapField("IN01CTAING")]
        public string IN01CTAING { get; set; }

        [MapField("IN01FLAVEN")]
        public string IN01FLAGVEN { get; set; }

        [MapField("IN01UNIDADMAYOR")]
        public string IN01UNIDADMAYOR { get; set; }

        [MapField("tipo")]
        public string tipo {get;set;}
        [MapField("color")]
        public string color {get;set;}
        [MapField("tonalidad")]
        public string tonalidad { get; set; }
        [MapField("formato")]
        public string formato {get;set;}
        [MapField("acabado")]
        public string acabado {get;set;}
        [MapField("relleno")]
        public string relleno {get;set;}
        [MapField("borde")]
        public string  borde {get;set;}
        [MapField("calidad")]
        public string  calidad {get;set;}
        [MapField("modelo")]
        public  string  modelo  {get;set;}
        [MapField("IN01FLAGTIPCALAREA")]
        public string IN01FLAGTIPCALAREA { get; set; }
        [MapField("IN01ESTADO")]
        public string IN01ESTADO { get; set; }
        [MapField("IN01DESINGLES")]
        public string IN01DESINGLES { get; set; }
        [MapField("IN01DESESPANIOL")]
        public string IN01DESESPANIOL { get; set; }

        [MapField("IN01UNIMEDVENTA")]
        public string IN01UNIMEDVENTA { get; set; }

        [MapField("UniventaDesc")]
        public string UniventaDesc { get; set; }

        public string  tipodesc  {get;set;}
        public string  colordesc {get;set;}
        public string  tonalidaddesc  {get;set;}
        public string formatodesc  {get;set;}
        public string acabadodesc  {get;set;}
        public string rellenodesc  {get;set;}
        public string bordedesc    {get;set;}
        public string Calidaddesc { get; set; }
        public string modelodesc {get;set;}
        public string UnidadDesc { get; set; }
        

    }
}
