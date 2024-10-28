
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System;

namespace Inv.BusinessEntities
{
    public class EntidadAyuda
    {
        //USAR UNA CLASE ENTIDAD
        public EntidadAyuda(string campotexto1, string campotexto2, string campotexto3, string campotexto4, string campotexto5,
            string campotexto6, string campotexto7, string campotexto8, string campotexto9, string campotexto10,
            string campotexto11, string campotexto12, string campotexto13, string campotexto14, string campotexto15,
            double camponumero1, double camponumero2, double camponumero3, double camponumero4, double camponumero5)
        {
            this.campotexto1 = campotexto1;
            this.campotexto2 = campotexto2;
            this.campotexto3 = campotexto3;
            this.campotexto4 = campotexto4;
            this.campotexto5 = campotexto5;
            this.campotexto6 = campotexto6;
            this.campotexto7 = campotexto7;
            this.campotexto8 = campotexto8;
            this.campotexto9 = campotexto9;
            this.campotexto10 = campotexto10;
            this.campotexto11 = campotexto11;
            this.campotexto12 = campotexto12;
            this.campotexto13 = campotexto13;
            this.campotexto14 = campotexto14;
            this.campotexto15 = campotexto15;

            this.camponumero1 = camponumero1;
            this.camponumero2 = camponumero2;
            this.camponumero3 = camponumero3;
            this.camponumero4 = camponumero4;
            this.camponumero5 = camponumero5;

        }
        /// <summary>
        /// contructor para capturar los datos de la ayuda de Equipos por cliente
        /// </summary>
        /// <param name="campo1"></param>
        public EntidadAyuda(string cNombreCliente,string cIn20Codigo,string cIn20Descripcion,double cIn20UndxCaja,int cIn20PiezasxCaja) {
            this.NombreCliente_ = cNombreCliente;
            this.In20Codigo_ = cIn20Codigo;
            this.In20Descripcion_ = cIn20Descripcion;
            this.In20UndxCaja_ = cIn20UndxCaja;
            this.In20PiezasxCaja_ = cIn20PiezasxCaja;
        }
        public string NombreCliente_ { get; set; }
        public string In20Codigo_ { get; set; }
        public string In20Descripcion_ { get; set; }
        public double In20UndxCaja_ { get; set; }
        public int In20PiezasxCaja_ { get; set; }


        public string campotexto1 { get; set; }
        public string campotexto2 { get; set; }
        public string campotexto3 { get; set; }
        public string campotexto4 { get; set; }
        public string campotexto5 { get; set; }
        public string campotexto6 { get; set; }
        public string campotexto7 { get; set; }
        public string campotexto8 { get; set; }
        public string campotexto9 { get; set; }
        public string campotexto10 { get; set; }
        public string campotexto11 { get; set; }
        public string campotexto12 { get; set; }
        public string campotexto13 { get; set; }
        public string campotexto14 { get; set; }
        public string campotexto15 { get; set; }

        public double camponumero1 { get; set; }
        public double camponumero2 { get; set; }
        public double camponumero3 { get; set; }
        public double camponumero4 { get; set; }
        public double camponumero5 { get; set; }
    }
}
