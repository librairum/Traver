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
    public partial class FrmRepKardexPPVal : frmBaseReporte
    {
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        RadGridView grilla;
        private frmMDI FrmParent { get; set; }
        private static FrmRepKardexPPVal _aForm;
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importar_MP;
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
                                                                    out guardar_a, out cancelar_a, out expmovi_a, out importar_MP);
        }
        public static FrmRepKardexPPVal Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepKardexPPVal(mdiPrincipal);
            _aForm = new FrmRepKardexPPVal(mdiPrincipal);
            return _aForm;
        }
        public FrmRepKardexPPVal(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            isLoaded = true;
            Crearcolumnas();
            rbtrangoperiodo.CheckState = CheckState.Checked;
            rbtopcdetallado.CheckState = CheckState.Checked;

            //Cargar alamcenes
            CargarAlmacenes(cboalmacenes);

            // Llenar combo mese
            CargarPeriodos(cbomesini);
            CargarPeriodos(cbomesfin);

            // Periodo por defecto
            this.cbomesini.SelectedValue = Logueo.Mes;
            this.cbomesfin.SelectedValue = Logueo.Mes;


            this.dtpFechaini.Value = DateTime.Now;
            this.dtpFechafin.Value = DateTime.Now;

            OnBuscar();
            isLoaded = true;
            gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);


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
        private void CargarAlmacenes(RadDropDownList cbo)
        {

            try
            {
                //var almacen = AlmacenLogic.Instance.AlmacenesMasTodos(Logueo.CodigoEmpresa);
                var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.PP_codnaturaleza);
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los alamcenes
                cbo.SelectedValue = Logueo.PP_AlmxDefecto;
            }


            catch (Exception)
            {

                throw;
            }

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

                cbo.SelectedValue = anio;
            }


            catch (Exception)
            {

                throw;
            }
        }

        protected override void OnBuscar()
        {
            //base.OnBuscar();
            string almacen = "";
             almacen = this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);

            var lista = ArticuloLogic.Instance.TraerArticuloxNatyAlm(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.PP_codnaturaleza,almacen);

            this.gridControl.DataSource = lista;
        }

        protected override void OnRefrescar()
        {
            var lista = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.PP_codnaturaleza);

            this.gridControl.DataSource = lista;
        }

        protected override void OnVista()
        {
            //string mensajeOut = string.Empty;

            var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
            var x = 0;

            foreach (var filaSeleccionado in gridControl.SelectedRows)
            {
                //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                codigosSeleccionados[x] = filaSeleccionado.Cells["IN01KEY"].Value.ToString();
                //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
                x++;
            }


            Cursor.Current = Cursors.WaitCursor;

            string almacen;
            string ranfecini;
            string ranfecfin;
            string flag;
            string subtitulo;

            almacen = this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);

            if (rbtrangoperiodo.CheckState == CheckState.Checked)
            {

                ranfecini = this.cbomesini.SelectedValue.ToString().Substring(0, 2);
                ranfecfin = this.cbomesfin.SelectedValue.ToString().Substring(0, 2);
                flag = "P";

                if (ranfecini == ranfecfin)
                {
                    subtitulo = ranfecini + "-" + Logueo.Anio;
                }
                else
                {
                    subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                }


            }
            else
            {
                ranfecini = string.Format("{0:dd/MM/yyyy}", this.dtpFechaini.Value);
                ranfecfin = string.Format("{0:dd/MM/yyyy}", this.dtpFechafin.Value);
                subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                flag = "R";
            }


            var datos = DocumentoLogic.Instance.RptKardexDetPP(Logueo.CodigoEmpresa, Logueo.Anio, almacen, ranfecini, ranfecfin, flag,
                                                              Util.ConvertiraXML(codigosSeleccionados),Logueo.PP_codnaturaleza);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();


            if (rbtopcdetallado.CheckState == CheckState.Checked)
            {
                reporte.Nombre = "RptKardexPPVal.rpt";
                reporte.DataSource = datos;
            }
            else if (rbtopcresumido.CheckState == CheckState.Checked)
            {
                reporte.Nombre = "RptkardexPPResVal.rpt";
                reporte.DataSource = datos;
            }

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

            Cursor.Current = Cursors.Default;
        }

        private void Crearcolumnas()
        {
            grilla = this.CreateGrid(this.gridControl);

            this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 160, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 400, true, false, true);
            this.CreateGridColumn(grilla, "Unidad Medida", "IN01UNIMED", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "tipo", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Color.", "color", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Tonalidad", "tonalidad", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Formato", "formato", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Acabado", "acabado", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Relleno", "relleno", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Borde", "borde", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Modelo", "modelo", 0, "", 90, true, false, true);
            crearGrupos();
        }
        private void crearGrupos()
        {
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Producto"));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());

            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN01KEY"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN01DESLAR"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN01UNIMED"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["tipo"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["color"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["tonalidad"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["formato"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["acabado"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["relleno"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["borde"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["modelo"]);
            this.gridControl.ViewDefinition = columnGroupsView;

        }

        private void cboalmacenes_SelectedValueChanged(object sender, EventArgs e)
        {
            OnBuscar();
        }

 
        private void cboalmacenes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!isLoaded) return;
            OnBuscar();
        }
    }
    }
