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
    public partial class FrmSeguirCanastilla : frmBaseReporte
    {
        ColumnGroupsViewDefinition columnGroupsView;
        //RadGridView grilla;
        private frmMDI FrmParent { get; set; }
        private static FrmSeguirCanastilla _aForm;
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
        RadCommandBarBaseItem cbbGenerarSalida;
        
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
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = refrescar_a ? ElementVisibility.Visible 
                                                  : ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    if (cbbGenerarSalida != null) cbbGenerarSalida.Visibility = ElementVisibility.Visible;
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
        public static FrmSeguirCanastilla Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new FrmSeguirCanastilla(mdiPrincipal);
            _aForm = new FrmSeguirCanastilla(mdiPrincipal);
            return _aForm;
        }
        private void CrearColumnas() {            
            RadGridView grilla = this.CreateGrid(this.gridControl);

            // -- campo para armar el xml de Generacion de Salida x regularizacion
            this.CreateGridColumn(grilla,"IN07CODEMP","IN07CODEMP", 0, "", 70, true, false, false); // oculto
            this.CreateGridColumn(grilla, "IN07AA", "IN07AA", 0, "", 70, true, false, false); // oculto
            this.CreateGridColumn(grilla, "IN07MM", "IN07MM", 0, "", 70, true, false, false); // oculto
            this.CreateGridColumn(grilla, "IN07TIPDOC", "IN07TIPDOC", 0, "", 70, true, false, false); // oculto
            this.CreateGridColumn(grilla, "IN07CODDOC", "IN07CODDOC", 0, "", 70, true, false, false); // oculto
            this.CreateGridColumn(grilla, "IN07KEY", "IN07KEY", 0, "", 70, true, false, false); // oculto
            this.CreateGridColumn(grilla, "IN07ORDEN", "IN07ORDEN", 0, "", 70, true, false, false); // oculto

            this.CreateGridColumn(grilla, "Fecha", "in07fecdoc", 0, "{0:dd/MM/yyyy}", 70);
            this.CreateGridColumn(grilla, "Hora", "HoraSalida", 0, "", 70);
            this.CreateGridColumn(grilla, "Doc.Referencia", "IN06REFDOC", 0, "", 70);
            this.CreateGridColumn(grilla, "Orden Trabajo", "IN07ORDENTRABAJO", 0, "", 70);
            this.CreateGridColumn(grilla, "TransaDescripcion", "TransaDescripcion", 0, "", 120);
            this.CreateGridColumn(grilla, "CodigoAlmacen", "IN07CODALM", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Almacen", "AlmaDescripcion", 0, "", 120);

            this.CreateGridColumn(grilla, "CodigoArticulo", "CodigoArticulo", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Producto", "ProdDescripcion", 0, "", 120);
            this.CreateGridColumn(grilla, "Cantidad", "IN07CANART", 0, "{0:###,##0.00}", 90, true, false, true, "right");
            this.CreateGridColumn(grilla, "Ancho", "IN07ANCHO", 0, "{0:###,##0.00}", 90, true, false, true, "right");
            this.CreateGridColumn(grilla, "Largo", "IN07LARGO", 0, "{0:###,##0.00}", 90, true, false, true, "right");
            this.CreateGridColumn(grilla, "Alto", "IN07ALTO", 0, "{0:###,##0.00}", 90, true, false, true, "right");

            // Salida
            this.CreateGridColumn(grilla, "Fecha", "Sal_in07fecdoc", 0, "{0:dd/MM/yyyy}", 70);
            this.CreateGridColumn(grilla, "Hora", "Sal_HoraInicio", 0, "", 70);
            this.CreateGridColumn(grilla, "Doc.Referencia", "Sal_IN06REFDOC", 0, "", 70);
            this.CreateGridColumn(grilla, "Orden Trabajo", "Sal_IN07ORDENTRABAJO", 0, "", 70);
            this.CreateGridColumn(grilla, "Transaccion", "Sal_TransaDescripcion", 0, "", 70);
            
        }
        private void CrearColumnasMovimientos() {
            RadGridView Grid = this.CreateGrid(this.gridMovimientos);
            this.CreateGridColumn(Grid, "Fecha", "IN07FECDOC", 0, "{0:dd/MM/yyyy}", 70);
            this.CreateGridColumn(Grid, "OT", "IN07ORDENTRABAJO", 0, "", 60);
            this.CreateGridColumn(Grid, "Doc.Referencia", "IN06REFDOC", 0, "", 100);
            this.CreateGridColumn(Grid, "H.Ingreso", "HoraIngreso", 0, "", 70);
            this.CreateGridColumn(Grid, "H.Salida", "HoraSalida", 0, "", 70);

            this.CreateGridColumn(Grid, "Transaccion", "Transaccion", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "TransaDescripcion", "TransaDescripcion", 0, "", 350);

            this.CreateGridColumn(Grid, "CodigoAlmacen", "CodigoAlmacen", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Almacen", "AlmaDescripcion", 0, "", 140);

            this.CreateGridColumn(Grid, "CodigoArticulo", "CodigoArticulo", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Producto", "ProdDescripcion", 0, "", 200);


            this.CreateGridColumn(Grid, "Cant.", "IN07CANART", 0, "{0:###,##0.00}", 60, true, false, true, "right");
            this.CreateGridColumn(Grid, "Ancho", "IN07ANCHO", 0, "{0:###,##0.00}", 60, true, false, true, "right");
            this.CreateGridColumn(Grid, "Largo", "IN07LARGO", 0, "{0:###,##0.00}", 60, true, false, true, "right");
            this.CreateGridColumn(Grid, "Alto", "IN07ALTO", 0, "{0:###,##0.00}", 60, true, false, true, "right");
            //crearGrupos();
        }
        void crearGrupos()
        {
            RadGridView grilla = this.gridControl;
            try
            {

                this.columnGroupsView = new ColumnGroupsViewDefinition();

                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Ingresos"));
                this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());

                //this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["in07fecdoc"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["HoraSalida"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN06REFDOC"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN07ORDENTRABAJO"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["TransaDescripcion"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN07CODALM"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["AlmaDescripcion"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["CodigoArticulo"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["ProdDescripcion"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN07CANART"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN07ANCHO"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN07LARGO"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN07ALTO"]);

                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Salidas"));
                this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());

                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["Sal_in07fecdoc"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["Sal_HoraInicio"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["Sal_IN06REFDOC"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["Sal_IN07ORDENTRABAJO"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["Sal_TransaDescripcion"]);

                grilla.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grilla.ViewDefinition = columnGroupsView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro crear Grupo:" + ex.Message);
            }


        }

        private void Cargar() 
        {
            Cursor.Current = Cursors.WaitCursor;
            var datos = DocumentoLogic.Instance.TraerSeguimientosCajas(Logueo.CodigoEmpresa, dtpFechaIni.Value.ToShortDateString(), 
                        dtpFechaFin.Value.ToShortDateString(), txtNroCaja.Text.Trim());
            this.gridControl.DataSource = datos;
            Cursor.Current = Cursors.Default;
        }
        private void CargarMovimientos() 
        {
            Cursor.Current = Cursors.WaitCursor;
            var movimientos = DocumentoLogic.Instance.TraerMovimientosCajas(Logueo.CodigoEmpresa, dtpFechaIni.Value.ToShortDateString(),
                dtpFechaFin.Value.ToShortDateString(), txtNroCaja.Text.Trim());
            this.gridMovimientos.DataSource = movimientos;
            Cursor.Current = Cursors.Default;

        }
        private void IniciarFormulario() 
        {
            this.dtpFechaIni.Format = DateTimePickerFormat.Short;
            this.dtpFechaIni.Value = this.dtpFechaFin.Value.AddDays(-15);
            this.dtpFechaFin.Format = DateTimePickerFormat.Short;
            this.dtpFechaFin.Value = DateTime.Now;
            CrearColumnasMovimientos();
            CrearColumnas();
            this.rbEntradaSalida.IsChecked = true;
            this.rpvSeguimiento.SelectedPage = this.rpEntradaSalida;
        }
        public FrmSeguirCanastilla(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Cursor.Current = Cursors.WaitCursor;
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
            cbbGenerarSalida = menu.Items["cbbGenerarSalida"];
            accesobtonesxperfil();
            ComportarmientoBotones("cargar");
            Cursor.Current = Cursors.Default;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            if (this.rpvSeguimiento.SelectedPage == this.rpEntradaSalida)
            {
                this.rbEntradaSalida.IsChecked = true;
                this.rbMovimientos.IsChecked = false;
                Cargar();
            }
            else if (this.rpvSeguimiento.SelectedPage == this.rpMovimientos)
            {
                this.rbEntradaSalida.IsChecked = false;
                this.rbMovimientos.IsChecked = true;
                CargarMovimientos();

            }
            
            Cursor.Current = Cursors.Default;
        }

        private void txtNroCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter) {
                Cursor.Current = Cursors.WaitCursor;
                if (this.rpvSeguimiento.SelectedPage == this.rpEntradaSalida)
                {
                    this.rbEntradaSalida.IsChecked = true;
                    this.rbMovimientos.IsChecked = false;
                    Cargar();
                }
                else if (this.rpvSeguimiento.SelectedPage == this.rpMovimientos)
                {
                    this.rbEntradaSalida.IsChecked = false;
                    this.rbMovimientos.IsChecked = true;
                    CargarMovimientos();

                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void rbEntradaSalida_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.rbEntradaSalida.CheckState == CheckState.Checked) {
                this.rpvSeguimiento.SelectedPage = this.rpEntradaSalida;
                Cargar();
            }
        }

        private void rbMovimientos_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.rbMovimientos.CheckState == CheckState.Checked) {
                this.rpvSeguimiento.SelectedPage = this.rpMovimientos;
                CargarMovimientos();
            }
        }

        private void rpvSeguimiento_SelectedPageChanged(object sender, EventArgs e)
        {            
            if (this.rpvSeguimiento.SelectedPage == this.rpEntradaSalida) {
                this.rbEntradaSalida.IsChecked = true;
                this.rbMovimientos.IsChecked = false;
                Cargar();
            }
            else if (this.rpvSeguimiento.SelectedPage == this.rpMovimientos) {
                this.rbEntradaSalida.IsChecked = false;
                this.rbMovimientos.IsChecked = true;
                CargarMovimientos();
                
            }
        }

        protected override void OnGenerarSalida()
        {
            try
            {
                string transaccion = Util.GetCurrentCellText(gridControl, "Sal_TransaDescripcion");
                if (this.rbMovimientos.CheckState == CheckState.Checked)
                {
                    Util.ShowAlert("Seleccionar opcion Entradas y salidas");
                    return;
                }
                if (transaccion != "")
                {
                    Util.ShowAlert("Seleccionar un registro diferente");
                    return;
                }
                
                string[] registros = new string[this.gridControl.SelectedRows.Count];
                int x = 0;
                foreach (GridViewRowInfo row in this.gridControl.SelectedRows)
                {
                    string cCodEmp = Util.GetCurrentCellText(row, "IN07CODEMP"); // campo1 
                    string cAnio = Util.GetCurrentCellText(row, "IN07AA"); //  campo2 
                    string cMes = Util.GetCurrentCellText(row, "IN07MM"); // campo3 
                    string cTipDoc = Util.GetCurrentCellText(row, "IN07TIPDOC"); // campo4
                    string cCodDoc = Util.GetCurrentCellText(row, "IN07CODDOC"); //  campo5 
                    string cArticulo = Util.GetCurrentCellText(row, "IN07KEY"); // cmapo6 
                    string cOrden = Util.GetCurrentCellText(row, "IN07ORDEN"); // campo7 
                    registros[x] = cCodEmp + "|" + cAnio + "|" + cMes + "|" + cTipDoc + "|" + cCodDoc  + "|" + cArticulo + "|" + cOrden;
                    x++;
                }
                string xml = Util.ConvertiraXMLdinamico(registros);
                int cFlag = 0;
                string cMensaje = "";

                DocumentoLogic.Instance.InsertarSalidasxRegularizacion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, xml, Logueo.PP_codnaturaleza, out cFlag, out cMensaje);
                Util.ShowMessage(cMensaje, cFlag);
                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            Cargar();
        }

    }
}
