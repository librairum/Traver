using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace Inv.UI.Win
{
    public enum enmWindowState
    {
        Normal = 0,
        Maximizado = 1,
        Minimizado = 2
    }
    public class ReporteControladora : IDisposable
    {

        public Reporte Reporte { get; set; }

        public ReporteControladora(Reporte reporte)
        {
            this.Reporte = reporte;
        }

        public ReporteControladora(string titulo, string ruta, string nombreReporte, DataTable data)
        {
            this.Reporte = new Reporte();
            this.Reporte.Titulo = titulo;
            this.Reporte.Ruta = ruta;
            this.Reporte.Nombre = nombreReporte;
            this.Reporte.DataSource = data;
        }

        public void Imprimir()
        {
            FormViewCristal visor = new FormViewCristal(this.Reporte.Titulo);
            try
            {
                if (!System.IO.File.Exists(this.Reporte.GetPathReporte()))
                {
                    throw new Exception("No existe reporte en ruta indicada");
                }

                visor.Reporte = this.Reporte;
                visor.Output(DestinoReporte.impresora);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (visor != null) visor.Dispose();
                visor = null;
            }
        }

        public void VistaPrevia(enmWindowState windowState)
        {
            FormViewCristal visor = new FormViewCristal(this.Reporte.Titulo);
            try
            {
                if (!System.IO.File.Exists(this.Reporte.GetPathReporte()))
                {
                    throw new Exception("No existe reporte en ruta indicada");
                }

                visor.Reporte = this.Reporte;

                switch (windowState)
                {
                    case enmWindowState.Normal:
                        visor.WindowState = System.Windows.Forms.FormWindowState.Normal;
                        break;
                    case enmWindowState.Maximizado:
                        visor.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        break;
                    case enmWindowState.Minimizado:
                        visor.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                        break;
                }
                visor.Show();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //if (visor != null) visor.Dispose();
                //visor = null;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
