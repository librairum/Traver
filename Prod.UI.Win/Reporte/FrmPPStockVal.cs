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
    public partial class FrmPPStockVal : frmBaseReporte
    {
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        RadGridView grilla;
        private frmMDI FrmParent { get; set; }
        private static FrmPPStockVal _aForm;
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
        
        
        
        public static FrmPPStockVal Instance(frmMDI mdiPrincipal) 
        {
            if (_aForm != null) return new FrmPPStockVal(mdiPrincipal);
            _aForm = new FrmPPStockVal(mdiPrincipal);
            return _aForm;
        }

        public FrmPPStockVal(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            CrearcolumnasDet();
            CrearColumnasCanastillas();
            CargarAlmacenes(this.cboalmacenes);
            OnBuscarStockResumido();
            //OnBuscarDet();
            //OnBuscarCanastillas();
            this.gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);
            this.rbtrepstockresumido.IsChecked = true;
            this.rpvStock.SelectedPage = this.rpProductos;
            
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
            
                        isLoaded = true;
        }

        //------------------------------------------------- Metodos Generales---------------------------------------------------------------
        #region "Metodos Generales"
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
        private void CargarAlmacenes(RadDropDownList cbo)
        {
            try
            {

                var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.PP_codnaturaleza);
                //--AlmacenLogic.Instance.AlmacenesMasTodos(Logueo.CodigoEmpresa);                
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los almacenes
                //cbo.SelectedValue = "10";
                //if (this.cboalmacenes.SelectedIndex == null) return;
                cbo.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
                //RadMessageBox.Show(ex.Message, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }                 
        protected override void OnRefrescar()
        {
            string selectedpage = rpvStock.SelectedPage.Name;
            if (selectedpage == rpCanastillas.Name)
            {
                OnBuscarCanastillas();
            }
            else if (selectedpage == rpProductos.Name)
            {
                OnBuscarStockResumido();
            }
            
            
        }
        protected override void OnVista()
        {
            //string mensajeOut = string.Empty;
            string periodostock;
            string periodoreporte;

            string[] codigosSeleccionados = null;
            string codigoAlmacen = this.cboalmacenes.SelectedValue.ToString();
            // == GENERANDO XML PARA REPORTES
            //--------------------------------------------------------- STOCK RESUMIDO ----------------------------------------------------------------------------
            // == GENERAR XML DE STOCK RESUMIDO
            if (this.rpvStock.SelectedPage == this.rpProductos)
            {
                 codigosSeleccionados = new string[gridControl.SelectedRows.Count];
                var x = 0;
                foreach (var filaSeleccionado in gridControl.SelectedRows)
                {
                    //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                    codigosSeleccionados[x] = filaSeleccionado.Cells["IN01KEY"].Value.ToString();
                    //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
                    x++;
                }
            }
            //--------------------------------------------------------- STOCK DETALLADO ----------------------------------------------------------------------------
            // == GENERAR XML DE STOCK DETALLADO
            else if(this.rpvStock.SelectedPage == this.rpCanastillas){

                codigosSeleccionados = new string[gridCanastillas.SelectedRows.Count];
                var x = 0;
                foreach (var filaseleccionado in gridCanastillas.SelectedRows) {
                    codigosSeleccionados[x] = filaseleccionado.Cells["in01key"].Value.ToString();
                    x++;
                }
            }

            Cursor.Current = Cursors.WaitCursor;
            // == OPCION DE REPORTE
            // == SI SELECCIONO OPCION (RADIO BUTTON) STOCK RESUMIDO 
            if (rbtrepstockresumido.CheckState == CheckState.Checked)
            {
                periodostock = (Logueo.Mes + "-" + Logueo.Anio);
                periodoreporte = (Logueo.Anio + Logueo.Mes);


                var datos = DocumentoLogic.Instance.RptProductoProcesoStock(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoAlmacen,
                            Util.ConvertiraXML(codigosSeleccionados));
                int cantidad = datos.Rows.Count;
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                //reporte.Nombre = "RptStockRes.rpt";
                reporte.Nombre = "RptStockPP_ResVal.rpt";
                if (datos == null) MessageBox.Show("Dt Vacio");
                reporte.DataSource = datos;

                reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            // == SI SELECCIONO OPCION (RADIO BUTTON) STOCK DETALLADO
            else if (rbtrepstockdetallado.CheckState == CheckState.Checked)
            {
                var datos = DocumentoLogic.Instance.RptProductoProcesoStock(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoAlmacen,
                            Util.ConvertiraXML(codigosSeleccionados));
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptStockPP_DetVal.rpt";
                reporte.DataSource = datos;

                periodostock = (Logueo.Mes + "" + Logueo.Anio);
                reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            
            Cursor.Current = Cursors.Default;
        }       
        private void cboalmacenes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            if (this.rpvStock.SelectedPage == this.rpProductos) {
                OnBuscarStockResumido();
            }
            else if (this.rpvStock.SelectedPage == this.rpCanastillas) {
                OnBuscarCanastillas();
            }
           
        }
      

        private void rpvStock_SelectedPageChanged(object sender, EventArgs e)
        {
            string selectedPage =  this.rpvStock.SelectedPage.Name;
            this.rbtrepstockdetallado.IsChecked = false;
            this.rbtrepstockresumido.IsChecked = false;
          
            if (selectedPage == this.rpProductos.Name)
            {
                this.rbtrepstockresumido.IsChecked = true;                
                OnBuscarStockResumido();
            }
            else if (selectedPage == this.rpCanastillas.Name)
            {                
                this.rbtrepstockdetallado.IsChecked = true;
                OnBuscarCanastillas();
            }
          
        }
        #endregion
        //------------------------------------------------- Stock Resumido-------------------------------------------------------------------
        #region "Stock Resumido"
        private void Crearcolumnas()
        {
            grilla = this.CreateGrid(this.gridControl);

            this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 300, true, false, true);
            this.CreateGridColumn(grilla, "Unidad Medida", "IN01UNIMED", 0, "", 40, true, false, true);
            this.CreateGridColumn(grilla, "Cantidad", "StockReal", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(grilla, "Area", "StockRealArea", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            this.CreateGridColumn(grilla, "# Canastillas", "CanastillasCantidad", 0, "{0:###,###0.00}", 85, true, false, true, "right");
            this.CreateGridColumn(grilla, "Tipo", "tipo", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Color.", "color", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Tonalidad", "tonalidad", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Formato", "formato", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Modelo", "modelo", 0, "", 100, true, false, true);

            // Suma Stock Real
            string[] fieldstosummary = { "StockReal","StockRealArea"};
            Util.AddGridSummarySum(this.gridControl, fieldstosummary);
            crearGrupos();

        }
        void crearGrupos()
        {
            try
            {

                this.columnGroupsView = new ColumnGroupsViewDefinition();

                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("General"));
                this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());

                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01KEY"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01DESLAR"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01UNIMED"]);

                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Stock"));
                this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["StockReal"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["StockRealArea"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["CanastillasCantidad"]);



                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("detalle"));

                this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["tipo"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["color"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["tonalidad"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["formato"]);
                this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(grilla.Columns["modelo"]);

                grilla.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grilla.ViewDefinition = columnGroupsView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro crear Grupo:" + ex.Message);
            }


        }
        private void CrearcolumnasDet()
        {

            RadGridView gridDet = this.CreateGrid(this.gridControlDet);

            this.CreateGridColumn(gridDet, "Almacen", "in09descripcion", 0, "", 150, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Nro Canastilla", "NROCanastilla", 0, "", 100, true, false, true, "center");

            // Medidas
            this.CreateGridColumn(gridDet, "UNI MED", "IN07UNIMED", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Cantidad", "StockReal", 0, "{0:###,###0.00}", 100, true, false, true, "right");

            this.CreateGridColumn(gridDet, "Ancho", "IN07ANCHO", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Largo", "IN07LARGO", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Alto", "IN07ALTO", 0, "{0:###,###0.00}", 100, true, false, true, "right");

            this.CreateGridColumn(gridDet, "Area", "StockRealArea", 0, "{0:###,###0.00}", 100, true, false, true, "right");



        }
        private void OnBuscarStockResumido()
        {

            Cursor.Current = Cursors.WaitCursor;
            if (this.cboalmacenes.SelectedValue == null) return;
            string codigoAlmacen = this.cboalmacenes.SelectedValue.ToString();

            var lista = ArticuloLogic.Instance.TraerPPStock(Logueo.CodigoEmpresa, Logueo.Anio, codigoAlmacen);            
            gridControl.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }
        protected void OnBuscarDet()
        {
            string codigoproducto = string.Empty;
            if (this.gridControl.RowCount == 0)
                return;

            codigoproducto = this.gridControl.CurrentRow.Cells["in01key"].Value.ToString();
            string almacen = this.cboalmacenes.SelectedValue.ToString();

            Cursor.Current = Cursors.WaitCursor;

            var lista = ArticuloLogic.Instance.TraerPPStockDet(Logueo.CodigoEmpresa, codigoproducto, almacen);
            this.gridControlDet.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }
        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;


                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["IN01KEY"].Value != null)
                    {
                        OnBuscarDet();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void rbtrepstockresumido_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.rbtrepstockresumido.CheckState == CheckState.Checked)
            {
                this.rpvStock.SelectedPage = this.rpProductos;
            }

        }
        #endregion

        //-----------------------------------------------"Stock Detallado"--------------------------------------------------------------------
        #region "Stock Detallado"
        private void rbtrepstockdetallado_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbtrepstockdetallado.CheckState == CheckState.Checked)
            {
                this.rpvStock.SelectedPage = this.rpCanastillas;
            }
        }
        private void CrearColumnasCanastillas()
        {

            RadGridView GridCanastilla = this.CreateGrid(this.gridCanastillas);
            this.CreateGridColumn(GridCanastilla, "Ult.Ing", "FechaIngresoUltima", 0, "{0:dd/MM/yyyy}", 75);
            this.CreateGridColumn(GridCanastilla, "Cod.Prod", "in01key", 0, "", 80);
            this.CreateGridColumn(GridCanastilla, "Descripcion", "IN01DESLAR", 0, "", 140);
            this.CreateGridColumn(GridCanastilla, "Almacen", "in09descripcion", 0, "", 150, true, false, true, "center");
            this.CreateGridColumn(GridCanastilla, "Nro Canastilla", "NROCanastilla", 0, "", 100, true, false, true, "center");

            this.CreateGridColumn(GridCanastilla, "Tipo", "Tipo", 0, "", 70);
            this.CreateGridColumn(GridCanastilla, "Color", "Color", 0, "", 70);
            this.CreateGridColumn(GridCanastilla, "Tonalidad", "Tonalidad", 0, "", 70);
            this.CreateGridColumn(GridCanastilla, "Formato", "Formato", 0, "", 70);
            this.CreateGridColumn(GridCanastilla, "Modelo", "Modelo", 0, "", 70);

            // Medidas
            this.CreateGridColumn(GridCanastilla, "UNI MED", "IN07UNIMED", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            

            this.CreateGridColumn(GridCanastilla, "Ancho", "IN07ANCHO", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            this.CreateGridColumn(GridCanastilla, "Largo", "IN07LARGO", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            this.CreateGridColumn(GridCanastilla, "Alto", "IN07ALTO", 0, "{0:###,###0.00}", 70, true, false, true, "right");

            this.CreateGridColumn(GridCanastilla, "Cantidad", "StockReal", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            this.CreateGridColumn(GridCanastilla, "Area", "StockRealArea", 0, "{0:###,###0.00}", 70, true, false, true, "right");

            string[] fieldstosummary = { "StockReal", "StockRealArea" };
            Util.AddGridSummarySum(this.gridCanastillas, fieldstosummary);
        }

        private void OnBuscarCanastillas()
        {
            string almacen = this.cboalmacenes.SelectedValue.ToString();
            Cursor.Current = Cursors.WaitCursor;
            this.gridCanastillas.DataSource = ArticuloLogic.Instance.TraerCanastillaPP(Logueo.CodigoEmpresa, Logueo.Anio, almacen);
            Cursor.Current = Cursors.Default;
        }
        #endregion

        //------------------------------------------------"Stock x Canastilla"-----------------------------------------------------------------
        
       
        
      
    }
}
