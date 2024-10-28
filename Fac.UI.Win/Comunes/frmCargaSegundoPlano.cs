using System;
using System.Collections;
using System.Threading;
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
    public partial class frmCargaSegundoPlano : Telerik.WinControls.UI.RadForm
    {
        private int porcentaje = 0;
        public frmCargaSegundoPlano()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            //cargarReporte();
            this.FormClosed += new FormClosedEventHandler(frmCargaSegundoPlano_FormClosed);
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
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                resultLabel.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                if (e.Result != null)
                { 
                    resultLabel.Text = e.Result.ToString();
                    //resultLabel.Text = "100";
                }
            }

            // Enable the UpDown control.
            //this.numericUpDown1.Enabled = true;

            // Enable the Start button.
            //startAsyncButton.Enabled = true;
            btnStarProcess.Enabled = true;
            // Disable the Cancel button.
            //cancelAsyncButton.Enabled = false;
            btnCancelProcess.Enabled = false;
        }
        private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.resultLabel.Text = e.ProgressPercentage.ToString();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork +=
                    new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);
        }
        void frmCargaSegundoPlano_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void cargarReporte()
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
            //esVista = true;
            if (esVista)
            {
                control.VistaPrevia(enmWindowState.Normal, false);
            }
            else
            {
                control.VistaPrevia(enmWindowState.Normal, true);
                //control.Imprimir();
            }
            esVista = true;
        }


        // This event handler is where the actual,
        // potentially time-consuming work is done.
        private void backgroundWorker1_DoWork(object sender,
            DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else {
                
                cargarReporte();
                
                worker.ReportProgress(porcentaje);
                porcentaje = 100;
                e.Result = porcentaje;
                //while (porcentaje < 100)
                //{ 
                    //Thread.Sleep(1000);
                    //porcentaje = porcentaje + 10;
                
                    
                    //worker.ReportProgress(porcentaje);
                    //e.Result = porcentaje;
                    
                //}
            }
            
            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            
            //worker.repor e.Result
            //e.Result = ComputeFibonacci((int)e.Argument, worker, e);
        }

        private void btnStarProcess_Click(object sender, EventArgs e)
        {
            // Reset the text in the result label.
            resultLabel.Text = String.Empty;
            //this.progressBar1.Value = 0;
            porcentaje = 0;
            // Disable the UpDown control until 
            // the asynchronous operation is done.
            //this.numericUpDown1.Enabled = false;

            // Disable the Start button until 
            // the asynchronous operation is done.
            this.btnStarProcess.Enabled = false;

            // Enable the Cancel button while 
            // the asynchronous operation runs.
            this.btnCancelProcess.Enabled = true;

            // Get the value from the UpDown control.
            //numberToCompute = (int)numericUpDown1.Value;

            // Reset the variable for percentage tracking.
            //highestPercentageReached = 0;

            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync();
            //progressBar1.Style = ProgressBarStyle.Marquee;
        }

        private void btnCancelProcess_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            btnCancelProcess.Enabled = false;
        }
    }
}
