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

namespace Prod.UI.Win
{
    public partial class FrmProduccionxDia : frmBaseReporte
    {

        private frmMDI FrmParent { get; set; }
        private static FrmProduccionxDia _aForm;
        public static FrmProduccionxDia Instance(frmMDI mdiPrincipal) 
        {
            if (_aForm != null) return new FrmProduccionxDia(mdiPrincipal);
            _aForm = new FrmProduccionxDia(mdiPrincipal);
            return _aForm;
        }
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importarMP;

        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;

        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ver_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = vista_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = imprimir_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = refrescar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility =  importar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;

                    break;
                case "nuevo":

                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    break;
                case "editar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    break;
                case "grabar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    break;
                case "cancelar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    break;
            }

        }
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a,
                                                                    out editar_a, out eliminar_a, out ver_a, out imprimir_a,
                                                                     out refrescar_a, out importar_a, out vista_a,
                                                                    out guardar_a, out cancelar_a, out expmovi_a, out importarMP);
        }
        private void IniciarFormulario() {
            CargarPeriodos(cboperiodosini);
            CargarPeriodos(cboperiodosfin);
            CargarLineas(cboLineas);
            cboperiodosini.SelectedValue = Logueo.Mes;
            cboperiodosfin.SelectedValue = Logueo.Mes;
            dtpFechaini.Value = DateTime.Now;
            dtpFechafin.Value = DateTime.Now;
            rbPeriodo.CheckState = CheckState.Checked;
            CrearColumnas();
        }
        public FrmProduccionxDia(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();

            menu = toolBar.CommandBarElement.Rows[0].Strips[0];

            cbbNuevo = menu.Items["cbbNuevo"];
            cbbEditar = menu.Items["cbbEditar"];
            cbbEliminar = menu.Items["cbbEliminar"];

            cbbVer = menu.Items["cbbVer"];
            cbbVista = menu.Items["cbbVista"];
            cbbImprimir = menu.Items["cbbImprimir"];
            cbbRefrescar = menu.Items["cbbRefrescar"];
            cbbImportar = menu.Items["cbbImportar"];

            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            accesobtonesxperfil();
            ComportarmientoBotones("cargar");
        }
        private void CargarPeriodos(RadDropDownList cbo) 
        {
            try
            {
                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa, Logueo.Anio);
                cbo.DataSource = periodo;
                cbo.DisplayMember = "ccb03des";
                cbo.ValueMember = "ccb03cod";
                string anio = "";
                string mes = "";
                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();
                cbo.SelectedValue = anio + mes;

            }
            catch (Exception) { 
            
            }
        }
        private void CrearColumnas() 
        {
            RadGridView Grid = this.CreateGrid(gridControl);
            CreateGridColumn(Grid, "Codigo", "codigo", 0, "", 80);
            CreateGridColumn(Grid, "Descripcion", "descripcion", 0, "", 120);
        }
        private void CargarLineas(RadDropDownList cbo) {
            var lineas = LineaLogic.Instance.LineaAyuda(Logueo.CodigoEmpresa);
            cbo.DataSource = lineas;

            cbo.ValueMember = "codigo";
            cbo.DisplayMember = "descripcion";
            
        }

        protected override void OnVista()
        {
            if (gridControl.SelectedRows.Count > 1) {
                RadMessageBox.Show("No puede seleccionar mas de una actividad", "Sistema", MessageBoxButtons.OK, 
                                    RadMessageIcon.Error);
                return;
            }
            string bandera = "";
            if (rbFecha.IsChecked) {
                bandera = "R";
            }else if (rbPeriodo.IsChecked)            
            {
                bandera = "P";            
            }
            
            //Llenar XML
            string[] seleccionados = new string[this.gridControl.SelectedRows.Count];
            int x = 0;
            foreach (var r in gridControl.SelectedRows) {
                seleccionados[x] = r.Cells["codigo"].Value.ToString();
                x++;
            }

            Cursor.Current = Cursors.WaitCursor;

            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            DataTable datos = null;
            
            
            string fecini = "";
            string fecfin = "";
            
            if (rbFecha.IsChecked)
            {
                fecini = dtpFechaini.Value.ToString();
                fecfin = dtpFechafin.Value.ToString();
            }
            else {
                fecini = cboperiodosini.SelectedValue.ToString();
                fecfin = cboperiodosfin.SelectedValue.ToString();
            }

            if (RbtMensual.IsChecked)
            {
                Titulo = "PRODUCCION POR PROCESO";
                reporte.Nombre = "RptProduccionxdia.rpt";
                SubTitulo = "Del " + fecini + " Al " + fecfin;
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Trae_Prodxdia(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                         cboLineas.SelectedValue.ToString(),
                                                                         fecini, fecfin, bandera, Util.ConvertiraXML(seleccionados));
            }
            else if (RbtDiario.IsChecked)
            {

                Titulo = "PRODUCCION POR PROCESO";
                reporte.Nombre = "RptProduccionXdiaDiario.rpt";
                SubTitulo = "Del " + fecini + " Al " + fecfin;
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Trae_ProdDiaria(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                         cboLineas.SelectedValue.ToString(),
                                                                         fecini, fecfin, bandera, Util.ConvertiraXML(seleccionados));

            }
            else if (RbtReportingServices.IsChecked)
            {
                
                
                //rptViewer.ProcessingMode = ProcessingMode.Remote; // ProcessingMode will be Either Remote or Local
                //rptViewer.ServerReport.ReportServerUrl = new Uri(urlReportServer); //Set the ReportServer Url
                //rptViewer.ServerReport.ReportPath = "/ReportName"; //Passing the Report Path   
            }

            if (!RbtReportingServices.IsChecked)
            {
                reporte.DataSource = datos;
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
                reporte.FormulasFields.Add(new Formula("titulo", Titulo));
                reporte.FormulasFields.Add(new Formula("subtitulo", SubTitulo));
                ReporteControladora controles = new ReporteControladora(reporte);
                controles.VistaPrevia(enmWindowState.Normal);
                Cursor.Current = Cursors.Default;
            }
            else { 
                // Reporte de Sql SSRS
                Cursor.Current = Cursors.WaitCursor;
                ReporteViewer reportesql = new ReporteViewer("Documento");

                reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS(); // obtener el nombre de la carpeta donde esta nuestro reporte
                reportesql.Ruta = Logueo.GetDirectorySSRRS();
                reportesql.Nombre = "RptProduccionxActividad";

                
                Paramentro pEmpresa = new Paramentro("IN07CODEMP", Logueo.CodigoEmpresa);
                reportesql.ParametersFields.Add(pEmpresa);
                Paramentro pLinea = new Paramentro("in06prodlineacod", cboLineas.SelectedValue.ToString());
                reportesql.ParametersFields.Add(pLinea);
                Paramentro pActividad = new Paramentro("in06prodActiNivel1Cod", this.gridControl.CurrentRow.Cells[0].Value.ToString());
                reportesql.ParametersFields.Add(pActividad);
                Paramentro pFecIni = new Paramentro("fechaIni", this.dtpFechaini.Value.ToShortDateString());
                reportesql.ParametersFields.Add(pFecIni);
                Paramentro pFecFin = new Paramentro("fechaFin", this.dtpFechafin.Value.ToShortDateString());
                reportesql.ParametersFields.Add(pFecFin);
                               
                ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);
                controlsql.VistaPrevia(enmWindowState.Normal);
                Cursor.Current = Cursors.Default;
            }
        }
        private void verReporte() { 
        
        }

        private void cboLineas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLineas.SelectedValue == null) return;
            var actividaddes = ActividadNivel1Logic.Instance.ActividadNivel1TraerAyuda(Logueo.CodigoEmpresa,
                               cboLineas.SelectedValue.ToString());
            this.gridControl.DataSource = actividaddes;
        }
    }
}
