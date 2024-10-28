using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace Com.UI.Win
{
    public enum enmWindowState
    { 
        Normal = 0,
        Maximizado = 1,
        Minimizado = 2
    }

    public class ReporteControladora
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
            catch (Exception ex) {
                throw;
            }
            finally
            {
                if (visor != null) visor.Dispose();
                visor = null;
            }
        }

        public void VistaPDF(enmWindowState windowState, string nombreArchivoPDF)
        {
            FormViewCristal visor = new FormViewCristal(this.Reporte.Titulo);
            visor.NombreArchivo = nombreArchivoPDF;
            try
            {
                if (!System.IO.File.Exists(this.Reporte.GetPathReporte()))
                {
                    throw new Exception("No existe reporte en ruta indicada");
                }
                visor.Reporte = this.Reporte;

                visor.Output(DestinoReporte.pdf);
            }
            catch (Exception ex)
            {
                throw;
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


        public void VistaPrevia(enmWindowState windowState, bool cerrarVentana = false)
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
                if (cerrarVentana == false)
                {
                    visor.Show();
                }
                else if (cerrarVentana == true)
                {
                    visor.Output(DestinoReporte.pantalla);
                }
                //visor.bool_cerrarVentana = true;


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

        public void VistaCorreo(enmWindowState windowState, string nombreArchivoPDF)
        {
            FormViewCristal visor = new FormViewCristal(this.Reporte.Titulo);
            visor.NombreArchivo = nombreArchivoPDF;
            try
            {
                if (!System.IO.File.Exists(this.Reporte.GetPathReporte()))
                {
                    throw new Exception("No existe reporte en ruta indicada");
                }
                visor.Reporte = this.Reporte;

                visor.Output(DestinoReporte.correo);
            }
            catch (Exception ex)
            {
                throw;
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
