using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;

namespace Prod.UI.Win
{
    public partial class FrmRepRendimiento : frmBaseReporte
    {
        //public FrmRepRendimiento()
        //{
        //    InitializeComponent();
        //}
        private frmMDI FrmParent { get; set; }
        private static FrmRepRendimiento _aForm;
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a, cancelar_a
            , expmovi_a, importarMP;
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
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

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
        public static FrmRepRendimiento Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepRendimiento(mdiPrincipal);
            _aForm = new FrmRepRendimiento(mdiPrincipal);
            return _aForm;
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


            catch (Exception)
            {

                throw;
            }
        }
        private void CargarLineas(RadDropDownList cbo) {
            try
            {

                var linea = LineaLogic.Instance.LineaAyuda(Logueo.CodigoEmpresa);
                cbo.DataSource = linea;
                cbo.DisplayMember = "descripcion";
                cbo.ValueMember = "codigo";
                cbo.SelectedValue = "TO";
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
            }
        }
        private void CrearColumnas() 
        {
            RadGridView gridvista = this.CreateGrid(gridControl);

            this.CreateGridColumn(gridvista, "OrdenTrabajo", "OrdenTrabajo", 0, "", 70);
            this.CreateGridColumn(gridvista, "CodigoProducto", "CodigoProducto", 0, "", 220);
            this.CreateGridColumn(gridvista, "Descripcion", "Descripcion", 0, "", 450);
            this.CreateGridColumn(gridvista, "Ancho", "Ancho", 0, "{0:###,###0.00}", 70);
            this.CreateGridColumn(gridvista, "Alto", "Alto", 0, "{0:###,###0.00}", 70);
            this.CreateGridColumn(gridvista, "Espesor", "Espesor", 0, "{0:###,###0.00}", 70);
            this.CreateGridColumn(gridvista, "Color", "Color", 0, "", 100);
            
        }
        void CargarOrdenesTrabajo() {
            try
            {
                var lista = LineaLogic.Instance.TraerProductosxOT(Logueo.CodigoEmpresa, Logueo.Anio, 
                                                                cboperiodosini.SelectedValue.ToString(),
                                                                 cboperiodosfin.SelectedValue.ToString(), 
                                                                  cboLineas.SelectedValue.ToString());

                this.gridControl.DataSource = lista;
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
            }
            
        }
        private void IniciarFormulario() {
            CargarPeriodos(cboperiodosini);
            CargarPeriodos(cboperiodosfin);
            CargarLineas(cboLineas);
            cboperiodosfin.SelectedValue = Logueo.Mes;
            cboperiodosini.SelectedValue = Logueo.Mes;
            dtpfechaIni.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            var lista = LineaLogic.Instance.TraerProductosxOT(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                 Logueo.Mes, cboLineas.SelectedValue.ToString());
            this.gridControl.DataSource = lista;
            rbPeriodo.CheckState = CheckState.Checked;
            
        }

        public FrmRepRendimiento(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
            CrearColumnas();
            CargarOrdenesTrabajo();
            rbReporteGeneral.CheckState = CheckState.Checked;

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
            //IniciarFormulario();
        }
        protected override void OnVista()
        {
            
            string[] seleccionados = new string[this.gridControl.SelectedRows.Count];
            var x = 0;
            string filtroAct  = string.Empty;
            string filtroUlt = string.Empty;
            if (this.gridControl.SelectedRows.Count == 0)
            { 
                RadMessageBox.Show("Debe seleccionar registros.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            DataTable datos = null;
            
            if (rbReporteGeneral.CheckState == CheckState.Checked) {


                Titulo = "Reporte de Rendimiento General";
                reporte.Nombre = "RptRendimiento.rpt";
                SubTitulo = "Del " + cboperiodosini.SelectedValue.ToString() + " Al " + cboperiodosfin.SelectedValue.ToString();

                //Util.ConvertiraXML(
                foreach (var r in gridControl.SelectedRows)
                {
                    seleccionados[x] = r.Cells["OrdenTrabajo"].Value.ToString();
                    x++;
                }
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Rep_Rendimiento(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                     cboperiodosini.SelectedValue.ToString(),
                                                                     cboperiodosfin.SelectedValue.ToString(), "",
                                                                    Util.ConvertiraXML(seleccionados), cboLineas.SelectedValue.ToString());
            }
            else if (rbtGraficoRendimiento.CheckState == CheckState.Checked)
            {
                Titulo = "Rendimiento";
                reporte.Nombre = "RptProduccionxdia.rpt";
                SubTitulo = "Del  " + cboperiodosini.SelectedValue.ToString() + " Al " + cboperiodosfin.SelectedValue.ToString();
                
                //foreach (var r in gridControl.SelectedRows)
                //{
                //    seleccionados[x] = r.Cells["OrdenTrabajo"].Value.ToString();
                //    filtroAct = r.Cells["Ancho"].Value.ToString();
                //    x++;
                //    if (x > 1 && filtroAct != filtroUlt)
                //    {
                //        RadMessageBox.Show("El filtro debe ser un sola dimension.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                //        return;
                //    }
                //    filtroUlt = filtroAct;
                //}
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Trae_Prodxdia(Logueo.CodigoEmpresa, Logueo.Anio,cboLineas.SelectedValue.ToString(),
                                                                     cboperiodosini.SelectedValue.ToString(),
                                                                     cboperiodosfin.SelectedValue.ToString(), "P",
                                                                    Util.ConvertiraXML(seleccionados) );
            }

            else if (rbtValidaCanastillas.CheckState == CheckState.Checked)
            {
                Titulo = "Rendimiento";
                reporte.Nombre = "RptValidacionesCanastilla.rpt";
                SubTitulo = "Del  " + cboperiodosini.SelectedValue.ToString() + " Al " + cboperiodosfin.SelectedValue.ToString();

                datos = TipoDocumentoLogic.Instance.Spu_Pro_Rep_Validaciones(Logueo.CodigoEmpresa);
                
            }
            else if (rbRendimientoxAncho.CheckState == CheckState.Checked)
            {
                Titulo = "Reporte de Rendimiento por ancho ";
                reporte.Nombre = "RptRendimiento.rpt";
                SubTitulo = "Del  " + cboperiodosini.SelectedValue.ToString() + " Al " + cboperiodosfin.SelectedValue.ToString();
                foreach (var r in gridControl.SelectedRows)
                {
                    seleccionados[x] = r.Cells["OrdenTrabajo"].Value.ToString();
                    filtroAct = r.Cells["Ancho"].Value.ToString();
                    x++;
                    if (x > 1 && filtroAct != filtroUlt)
                    {
                        RadMessageBox.Show("El filtro debe ser un sola dimension.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    filtroUlt = filtroAct;
                }
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Rep_Rendimiento(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                     cboperiodosini.SelectedValue.ToString(),
                                                                     cboperiodosfin.SelectedValue.ToString(), "",
                                                                    Util.ConvertiraXML(seleccionados), cboLineas.SelectedValue.ToString());
            }
            else if (rbRendimientoxColor.CheckState == CheckState.Checked)
            {
                Titulo = "Reporte de Rendimiento por color";
                reporte.Nombre = "RptRendimiento.rpt";
                SubTitulo = "Del " + cboperiodosini.SelectedValue.ToString() + " Al " + cboperiodosfin.SelectedValue.ToString();
                foreach (var r in gridControl.SelectedRows)
                {
                    seleccionados[x] = r.Cells["OrdenTrabajo"].Value.ToString();
                    filtroAct = r.Cells["Color"].Value.ToString();
                    x++;
                    if (x > 1 && filtroAct != filtroUlt)
                    {
                        RadMessageBox.Show("El filtro debe ser un solo color", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    filtroUlt = filtroAct;
                }
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Rep_Rendimiento(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                     cboperiodosini.SelectedValue.ToString(),
                                                                     cboperiodosfin.SelectedValue.ToString(), "",
                                                                    Util.ConvertiraXML(seleccionados), cboLineas.SelectedValue.ToString());
            }
            else if (rbRendimientoxColorAncho.CheckState == CheckState.Checked)
            {
                Titulo = "Reporte de Rendimiento por color y ancho";
                reporte.Nombre = "RptRendimiento.rpt";
                SubTitulo = "Del " + cboperiodosini.SelectedValue.ToString() + " Al " + cboperiodosfin.SelectedValue.ToString();
                foreach (var r in gridControl.SelectedRows)
                {
                    seleccionados[x] = r.Cells["OrdenTrabajo"].Value.ToString();
                    filtroAct = r.Cells["Ancho"].Value.ToString() + r.Cells["Color"].Value.ToString();

                    x++;

                    if (x > 1 && filtroAct != filtroUlt)
                    {
                        RadMessageBox.Show("El filtro debe ser de solo una medida y Color", "Sistema",
                                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    filtroUlt = filtroAct;
                }
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Rep_Rendimiento(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                     cboperiodosini.SelectedValue.ToString(),
                                                                     cboperiodosfin.SelectedValue.ToString(), "",
                                                                    Util.ConvertiraXML(seleccionados), 
                                                                    cboLineas.SelectedValue.ToString());
            }
            reporte.DataSource = datos;
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("titulo", Titulo));
            reporte.FormulasFields.Add(new Formula("subtitulo", SubTitulo));
            ReporteControladora controles = new ReporteControladora(reporte);
            controles.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }

        private void gridControl_FilterChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
          
        }

        private void rbReporteGeneral_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
           
            
                
            
            
        }
        void seleccionarTodo(object sender, EventArgs e)
        {            
            foreach (var r in gridControl.ChildRows)
            {            
                r.IsSelected = true;
            }
        }
        private void gridControl_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu.Items.Clear();
            RadMenuItem itmSeleccionar = new RadMenuItem();
            itmSeleccionar.Name = "itmSeleccionar";
            itmSeleccionar.Text = "Seleccionar todo los registros.";
            itmSeleccionar.Click += new EventHandler(seleccionarTodo);
            e.ContextMenu.Items.Add(itmSeleccionar);
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarOrdenesTrabajo();
        }

        private void cboLineas_SelectedValueChanged(object sender, EventArgs e)
        {
          
        }
    }
}
