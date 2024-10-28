using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI;

namespace Fac.UI.Win
{
    public class LoadReporteBackGround
    {
        private int porcentaje = 0;
        public LoadReporteBackGround()
        {
         
        }
        
        public void cargarReporte()
        {
            string tipodocumento = "", numeroguia = "";
            //tipodocumento = txttipdoc.Text;
            //numerooguia = txtserie.Text + "-" + txtnrodocumento.Text;

            var codigosSeleccionados = new string[1];
            codigosSeleccionados[0] = tipodocumento + numeroguia;
            //DataTable datosGuia = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Rep_Guias(Logueo.CodigoEmpresa,Util.ConvertiraXML(codigosSeleccionados));
            DataTable datosGuia = GlobalLogic.Instance.Spu_Glo_Trae_ConsultaTest();
            if (datosGuia.Rows.Count == 0)
            {
                MessageBox.Show("La guia no contiene detalle.");
                return;
            }


            Reporte reporte = new Reporte("Guia");
            reporte.Ruta = Logueo.GetRutaReporte();
            string str_SubPlantilla = "";
            str_SubPlantilla = "01";
            if (str_SubPlantilla == "01")
            {
                reporte.Nombre = "RptTest.rpt";

            }
            else if (str_SubPlantilla == "02")
            {
                reporte.Nombre = "RptGuiasNacional.rpt";

            }
            else if (str_SubPlantilla == "03")
            {
                reporte.Nombre = "RptGuiasObras.rpt";
            }


            reporte.DataSource = datosGuia;
            ReporteControladora control = new ReporteControladora(reporte);
            bool esVista = false;
            esVista = true;
            if (esVista)
            {
                control.VistaPrevia(enmWindowState.Normal, true);
            }
            else
            {
                control.Imprimir();
            }
            esVista = true;                       
        }
        internal void LoadEventForBackGroundWorker(BackgroundWorker ctrlWorker)
        {
            ctrlWorker.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            ctrlWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            ctrlWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
        private void backgroundWorker1_DoWork(object sender,
           DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                cargarReporte();
                worker.ReportProgress(porcentaje);
                porcentaje = 100;
                e.Result = porcentaje;
            }

        }
        private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            //this.pgbProgreso.Value = e.ProgressPercentage;

            //this.resultLabel.Text = e.ProgressPercentage.ToString();
        }

        // This event handler deals with the results of the
        // background operation.
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {

                //resultLabel.Text = "Canceled";
                //pgbProgreso.Visibility = ElementVisibility.Collapsed;
                //Util.ShowAlert("Proceso interrumpido");
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                if (e.Result != null)
                {
                    //resultLabel.Text = e.Result.ToString();
                    //resultLabel.Text = "100";
                    // pgbProgreso.Visibility = ElementVisibility.Collapsed;
                    //Util.ShowAlert("Termino de cargar subproceso");
                }
            }


        }
    }
    
}
