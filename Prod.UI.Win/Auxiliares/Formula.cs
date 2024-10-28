using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prod.UI.Win
{
    public   class Formula
    {
        public Formula(string nombre, object valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }

        public string Nombre { get; set; }
        public object Valor { get; set; }

    }

    public class Paramentro
    {
        public Paramentro(string nombre, string valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
