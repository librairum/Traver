using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Microsoft.Reporting;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WinForms;
using System.Net;
using System.Diagnostics;

namespace Fac.UI.Win
{

    public enum enWindowState
    {
        Normal = 0,
        Maximizado = 1,
        Minimizado = 2
    }
    public class ReporteViewerControladora : IDisposable
    {


        public ReporteViewer Reporte { get; set; }
        public ReporteViewerControladora(ReporteViewer reporte)
        {
            this.Reporte = reporte;
        }
        public ReporteViewerControladora(string titulo, string ruta, string rutaServidor, string nombreReporte, DataTable data)
        {
            this.Reporte = new ReporteViewer();
            this.Reporte.Titulo = titulo;
            this.Reporte.Ruta = ruta;
            this.Reporte.RutaServidor = rutaServidor;
            this.Reporte.Nombre = nombreReporte;
            this.Reporte.DataSource = data;
        }
        public void Imprimir()
        {
            /*FormViewCristal visor = new FormViewCristal(this.Reporte.Titulo);*/
            FormViewReport visor = new FormViewReport(this.Reporte.Titulo);
            try
            {
                //if (!System.IO.File.Exists(this.Reporte.GetPathReporte()))
                //{
                //    throw new Exception("No existe reporte en ruta indicada");
                //}

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

            FormViewReport visor = new FormViewReport(this.Reporte.Titulo);
            
            try
            {
                //if (!System.IO.File.Exists(this.Reporte.GetPathReporte()))
                //{
                //    throw new Exception("No existe reporte en ruta indicada");
                //}

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
            catch (Exception ex)
            {
                Util.ShowError("Error en vista previa de report viewer:" + ex.Message);
                //throw;
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
