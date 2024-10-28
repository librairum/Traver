using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Microsoft.Reporting.WinForms;

namespace Fac.UI.Win
{
    public partial class FormViewReport : Form
    {
        public FormViewReport()
        {
            InitializeComponent();
        }
        public FormViewReport(string titulo)
        {
            InitializeComponent();
            this.Titulo = titulo;

        }

        public ReporteViewer Reporte { get; set; }
        public string Titulo { get; set; }

        #region Metodos Nuevos
        public void Output(DestinoReporte destinno)
        {
            try
            {
                this.Text = this.Titulo;
                this.rpv.Dock = DockStyle.Fill;
                this.rpv.ShowRefreshButton = false;

                string urlReportServer = Reporte.RutaServidor;
                rpv.ProcessingMode = ProcessingMode.Remote; // ProcessingMode will be Either Remote or Local

                string reportPath = Reporte.GetPathReporte();

                rpv.ServerReport.ReportServerUrl = new Uri(urlReportServer); //Set the ReportServer Url
                rpv.ServerReport.ReportPath = reportPath; //Passing the Report Path 
                ArrayList reportParam = new ArrayList();
                reportParam = ReportDefaultParam();
                
                    ReportParameter[] param = new ReportParameter[reportParam.Count];
                    for (int k = 0; k < reportParam.Count; k++)
                    {
                        param[k] = (ReportParameter)reportParam[k];
                    }
                    // pass crendentitilas
                   //rpv.ServerReport.ReportServerCredentials.NetworkCredentials = new System.Net.NetworkCredential("administrador", "Ad2017Deisi**", "mineradeisi.com");
                    
                    rpv.ServerReport.SetParameters(param); //Set Report Parameters
                
                rpv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private ArrayList ReportDefaultParam()
        {
            ArrayList arrDefaultParam = new ArrayList();
            for (int x = 0; x < Reporte.ParametersFields.Count; x++)
            {
                string pname = Reporte.ParametersFields[x].Nombre;
                string pvalue = Reporte.ParametersFields[x].Valor;
                arrDefaultParam.Add(CreateReportParameter(pname, pvalue));
            }
            /*
             * arrDefaultParam.Add(CreateReportParameter("IN07CODEMP", Logueo.CodigoEmpresa));
            arrDefaultParam.Add(CreateReportParameter("in06prodlineacod", ));
            arrDefaultParam.Add(CreateReportParameter("in06prodActiNivel1Cod", "05"));
            arrDefaultParam.Add(CreateReportParameter("fechaIni","01/02/2017"));
            arrDefaultParam.Add(CreateReportParameter("fechaFin","20/02/2017"));
             * */
            return arrDefaultParam;
        }
        private ReportParameter CreateReportParameter(string paramName, string pnamValue)
        {
            ReportParameter aParam = new ReportParameter(paramName, pnamValue);
            return aParam;
        }
        #endregion

        private void FormViewReport_Load(object sender, EventArgs e)
        {

            //this.rpv.RefreshReport();
            this.Output(DestinoReporte.pantalla);
        }

        private void FormViewReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Reporte != null) this.Reporte.Dispose();
            this.Reporte = null;
        }

      

    }
}
