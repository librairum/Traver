using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace Inv.UI.Win
{
    public enum DestinoReporte
    {
        pantalla = 0,
        impresora = 1
    }

    public class Reporte : IDisposable
    {
        private IList<SubReporte> subReportes;

        public Reporte()
        {
            this.subReportes = new List<SubReporte>();
            this.FormulasFields = new List<Formula>();
            this.ParametersFields = new List<Paramentro>();
        }

        public Reporte(string nombre)
        {
            this.Nombre = nombre;
            this.subReportes = new List<SubReporte>();
            this.FormulasFields = new List<Formula>();
            this.ParametersFields = new List<Paramentro>();
        }


        public string Titulo { get; set; }
        public string Ruta { get; set; }
        public string Nombre { get; set; }
        public object DataSource { get; set; }
        public IList<Paramentro> ParametersFields { get; set; }
        public IList<Formula> FormulasFields { get; set; }
        public IList<SubReporte> SubReportes { get; set; }
        public string GetPathReporte()
        {
            return string.Format("{0}{1}", this.Ruta, this.Nombre);
        }

        public void AddSubReporte(IEnumerable data)
        {
            SubReporte subreport = new SubReporte();
            subreport.Nombre = this.Nombre;
            subreport.DataSource = data;
            this.subReportes.Add(subreport);
        }



        #region IDisposable Members

        public void Dispose()
        {
            if (this.subReportes != null)
            {
                this.subReportes.Clear();
            }
            this.subReportes = null;
        }

        #endregion
    }
}
