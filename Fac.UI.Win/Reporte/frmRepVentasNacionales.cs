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
using Microsoft.Reporting.WinForms;
using System.Net;

namespace Fac.UI.Win
{
    public partial class frmRepVentasNacionales : frmBaseReporte
    {

        #region "Instancia"
        private static frmRepVentasNacionales _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepVentasNacionales Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepVentasNacionales(formParent);
            _aForm = new frmRepVentasNacionales(formParent);
            return _aForm;
        }
        #endregion

        private void CargarPeriodos(RadDropDownList cbo)
        {
            try
            {
                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa, Logueo.Anio);
                cbo.DataSource = periodo;
                cbo.DisplayMember = "ccb03des";
                cbo.ValueMember = "ccb03cod";

                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");

                cbo.SelectedValue = mes;
            }


            catch (Exception)
            {

                throw;
            }
        }
        public frmRepVentasNacionales(frmMDI padre)
        {
            InitializeComponent();
        }
        protected override void OnVista()
        {
           //VerReporteReportingServices();
            VerReportingServices_ReportViewer();

        }
        private void VerReportingServices_ReportViewer() 
        {
            try 
            {
                List<ReportParameter> parametros = new List<ReportParameter>();
                string nombrereporte = string.Empty;
                //// Crear una instancia de ReportViewer
                ReportViewer reportViewer = new ReportViewer();
                ReportParameter[] parameters = new ReportParameter[4];
                //// Configurar la URL del servidor de informes y la ruta del informe
                reportViewer.ProcessingMode = ProcessingMode.Remote; // Modo de procesamiento remoto
                reportViewer.ServerReport.ReportServerUrl = new Uri("http://SERVIDOR1:8080/ReportServer");
                if (rbVentaGeneral.IsChecked == true)
                {
                     //flag = "G";
                    nombrereporte = "VentasNacional";
                    parametros.Add(new ReportParameter("Flag", "G"));
                    parametros.Add(new ReportParameter("CodigoCliente", ""));
                }
                else if (rbVentaGeneralxCliente.IsChecked == true)
                {
                    //flag = "C";
                    nombrereporte = "VentasNacionalPorCliente";
                    parametros.Add(new ReportParameter("CodigoCliente", txtCodCliente.Text.ToString().Trim()));
                    parametros.Add(new ReportParameter("Flag", "C"));
                   
                    if (txtCodCliente.Text == "") 
                    {
                        Util.ShowError("VALIDAR :: Selecciona un cliente para visualizar el Reporte");
                        return;
                    }  
                }
                reportViewer.ServerReport.ReportPath = "/ReportesVentaNacional/"+nombrereporte ; // Ruta del informe en el servidor de informes
                reportViewer.Dock = DockStyle.Fill; //ajustar el tamaño del reporte con el formulario



                parametros.Add(new ReportParameter("Empresa",Logueo.CodigoEmpresa));
                parametros.Add(new ReportParameter("Anio", Logueo.Anio));
                parametros.Add(new ReportParameter("MesInicio", this.cbomesini.SelectedValue.ToString()));
                parametros.Add(new ReportParameter("MesFinal", this.cbomesfin.SelectedValue.ToString()));

                //// Configurar las credenciales de red para la autenticación en el servidor de informes
                reportViewer.ServerReport.ReportServerCredentials.NetworkCredentials = new NetworkCredential("administrador", "AdDeisi2023**");
                reportViewer.ServerReport.SetParameters(parametros);
                Cursor.Current = Cursors.WaitCursor;
                FrmReporteVentas s = new FrmReporteVentas();
                s.Controls.Add(reportViewer);
                reportViewer.RefreshReport();

                s.ShowDialog();

                Cursor.Current = Cursors.Default;
            }catch(Exception ex)
            {
                Util.ShowError("ERROR :: "+ex.ToString());
            }
        }
        private void VerReporteReportingServices()
        {
            try
            {


                Cursor.Current = Cursors.WaitCursor;
                string flag = "";
                ReporteViewer reportesql = new ReporteViewer("Documento");

                reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS(); // obtener el nombre de la carpeta donde esta nuestro reporte

                reportesql.Ruta = Logueo.GetDirectorySSRRS();

                Paramentro pEmpresa = new Paramentro("Empresa", Logueo.CodigoEmpresa);
                reportesql.ParametersFields.Add(pEmpresa);

                Paramentro pAnio = new Paramentro("Anio", Logueo.Anio);
                reportesql.ParametersFields.Add(pAnio);

                Paramentro pMesIni = new Paramentro("MesInicio", this.cbomesini.SelectedValue.ToString());
                reportesql.ParametersFields.Add(pMesIni);

                Paramentro pMesFin = new Paramentro("MesFinal", this.cbomesfin.SelectedValue.ToString());
                reportesql.ParametersFields.Add(pMesFin);

                if (rbVentaGeneral.IsChecked == true)
                {
                    flag = "G";
                    reportesql.Nombre = "VentasNacional";
                }
                else if (rbVentaGeneralxCliente.IsChecked == true)
                {
                    flag = "C";
                    reportesql.Nombre = "VentasNacionalPorCliente";
                }
                Paramentro pFlag = new Paramentro("Flag", flag);
                reportesql.ParametersFields.Add(pFlag);

                Paramentro pCodigoCliente = new Paramentro("CodigoCliente", flag == "G" ? "01" : txtCodCliente.Text.Trim());
                reportesql.ParametersFields.Add(pCodigoCliente);



                ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);

                controlsql.VistaPrevia(enmWindowState.Normal);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer reporte: " + ex.Message);
            }
        }
        
        private void frmRepVentasNacionales_Load(object sender, EventArgs e)
        {
            CargarPeriodos(cbomesini);
            CargarPeriodos(cbomesfin);
            rbVentaGeneral.IsChecked = true;
            txtCodCliente.Text = "";
            txtDescCliente.Text = "";
            Util.ResaltarAyuda(txtCodCliente);
        }

        private void rbVentaGeneralxCliente_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            txtCodCliente.Enabled = true;
        }

        private void rbVentaGeneral_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            txtCodCliente.Enabled = false;
            txtCodCliente.Text = "";
            txtDescCliente.Text = "";

        }
        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                frmBusqueda frm = new frmBusqueda(enmAyuda.enmFactCab_Cliente, "01");
                frm.ShowDialog();
                if (frm.Result == null) return;
                if (frm.Result.ToString() == "") return;
                string[] datos = frm.Result.ToString().Split('|');
                txtCodCliente.Text =  datos[0];
                txtDescCliente.Text = datos[1];
            }
        }

      


    }
}
