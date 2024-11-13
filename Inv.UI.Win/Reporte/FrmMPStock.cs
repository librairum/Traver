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

namespace Inv.UI.Win
{
    public partial class FrmMPStock : frmBaseReporte
    {
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        RadGridView grilla;
        private void FrmMPStock_Load(object sender, EventArgs e)
        {                               
            //isLoaded = true;
            //this.gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);            
        }
        private frmMDI FrmParent { get; set; }
        private static FrmMPStock _aForm;

         public static FrmMPStock Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmMPStock(mdiPrincipal);
            _aForm = new FrmMPStock(mdiPrincipal);
            return _aForm;
        }

         public FrmMPStock(frmMDI padre)
        {
            InitializeComponent();
            Crearcolumnas();
            CrearcolumnasDet();

            CrearColumnasStockDetallado();
            FrmParent = padre;
            CargarAlmacenes(this.cboalmacenes);
            OnBuscar();
            //OnBuscarDet();
            //CargarStockDetallado();
            //this.gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);
            HabilitarBotones(true, true, true, false,true);

            this.rpvGeneral.SelectedPage = this.rpvStockResumido;

            this.gridControl.CustomFiltering += new GridViewCustomFilteringEventHandler(abrirFiltro);
            this.rpvGeneral.SelectedPageChanged += new EventHandler(rpvGeneral_SelectedPageChanged);
            
            isLoaded = true;
        }

         protected override void OnSeleccionarTodo()
         {
             try
             {
                 gridControl.SelectAll();
             }
             catch (Exception ex)
             {
                 Util.ShowError("ERROR");
             }

         }
       

         

         #region "Stock detallado"
         private void CargarStockDetallado()
         {             
             if (this.gridControl.RowCount == 0)
                 return;
             
             string almacen = this.cboalmacenes.SelectedValue.ToString();
             
             Cursor.Current = Cursors.WaitCursor;
             
             var lista = ArticuloLogic.Instance.TraerDetalledoMPDet(Logueo.CodigoEmpresa, almacen);
             this.gridDetalle.DataSource = lista;

             Cursor.Current = Cursors.Default;
         }
         private void CrearColumnasStockDetallado()
         {
             RadGridView gridDet = this.CreateGrid(this.gridDetalle);

             this.CreateGridColumn(gridDet, "Fecha", "IN07FECDOC", 0, "", 75, true, false, true, "left");
             this.CreateGridColumn(gridDet, "Doc Respaldo", "DocRespaldoNro", 0, "", 100, true, false, true, "center");

             this.CreateGridColumn(gridDet, "Proveedor", "ProvBloqueNombre", 0, "", 150, true, false, true, "left");
             this.CreateGridColumn(gridDet, "Cantera", "CanteraNombre", 0, "", 150, true, false, true, "left");
             this.CreateGridColumn(gridDet, "Contratista", "ContratistaNombre", 0, "", 150, true, false, true, "left");
             this.CreateGridColumn(gridDet, "Almacen", "in09descripcion", 0, "", 150, true, false, true, "right");
             this.CreateGridColumn(gridDet, "Nro Bloque", "NROBLOQUE", 0, "", 100, true, false, true, "center");
             this.CreateGridColumn(gridDet, "Cod Proveedor", "IN07CODBLOQUEPROV", 0, "", 50, true, false, true, "center");
             this.CreateGridColumn(gridDet, "Cod.Producto", "IN07KEY", 0, "", 70, true, false, true, "center");
             // Medidad Planta
             this.CreateGridColumn(gridDet, "Largo", "IN07LARGO", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             this.CreateGridColumn(gridDet, "Ancho", "IN07ANCHO", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             this.CreateGridColumn(gridDet, "Alto", "IN07ALTO", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             this.CreateGridColumn(gridDet, "Volumen", "VolumenPlanta", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             // Medidad Cantera
             this.CreateGridColumn(gridDet, "largo ", "IN07LARGOCAN", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             this.CreateGridColumn(gridDet, "Ancho", "IN07ANCHOCAN", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             this.CreateGridColumn(gridDet, "Alto", "IN07ALTOCAN", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             this.CreateGridColumn(gridDet, "Volumen", "VolumenCantera", 0, "{0:###,###0.00}", 50, true, false, true, "right");
             //
             this.CreateGridColumn(gridDet, "Observacion", "in07observacion", 0, "", 250, true, false, true, "left");

             // Suma Stock VolumenPlanta
             GridViewSummaryItem summaryItemPlanta = new GridViewSummaryItem();
             summaryItemPlanta.Name = "VolumenPlanta";
             summaryItemPlanta.FormatString = "{0:###,###0.00}";
             summaryItemPlanta.Aggregate = GridAggregateFunction.Sum;


             // Conteo de VolumenCantera
             GridViewSummaryItem summaryItemCantera = new GridViewSummaryItem();
             summaryItemCantera.Name = "VolumenCantera";
             summaryItemCantera.FormatString = "{0:###,###0.00}";
             summaryItemCantera.Aggregate = GridAggregateFunction.Sum;


             GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItemPlanta, summaryItemCantera };
             //summaryRowItem.Add(summaryItem);

             gridDet.SummaryRowsBottom.Add(summaryRowItem);


             gridDet.MasterTemplate.ShowTotals = true;
             gridDet.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
             CrearGruposStockDetalle();
         }

         private void CrearGruposStockDetalle()
         {
             this.columnGroupsView = new ColumnGroupsViewDefinition();
             this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Producto"));
             this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07FECDOC"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["DocRespaldoNro"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["ProvBloqueNombre"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["CanteraNombre"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["ContratistaNombre"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["in09descripcion"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["NROBLOQUE"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07CODBLOQUEPROV"]);
             this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07KEY"]);

             this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Medidas de Planta"));
             this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
             this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07LARGO"]);
             this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07ANCHO"]);
             this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07ALTO"]);
             this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridDetalle.Columns["VolumenPlanta"]);

             this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Medidas de Cantera"));
             this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());

             this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07LARGOCAN"]);
             this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07ANCHOCAN"]);
             this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridDetalle.Columns["IN07ALTOCAN"]);
             this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridDetalle.Columns["VolumenCantera"]);

             this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
             this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
             this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridDetalle.Columns["in07observacion"]);

             this.gridDetalle.ViewDefinition = columnGroupsView;
         }
       #endregion

        #region "Metodos Generales"
         void rpvGeneral_SelectedPageChanged(object sender, EventArgs e)
         {
             if (rpvGeneral.SelectedPage == rpvStockResumido)
             {
                 OnBuscar();
             }
             else if (rpvGeneral.SelectedPage == rpvStockDetallado)
             {
                 CargarStockDetallado();
             }
         }

         void abrirFiltro(object sender, GridViewCustomFilteringEventArgs e)
         {
             MessageBox.Show("Filtro de grilla");
         }

         private void CargarAlmacenes(RadDropDownList cbo)
         {
             try
             {

                 var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.MP_codnaturaleza);
                 //--AlmacenLogic.Instance.AlmacenesMasTodos(Logueo.CodigoEmpresa);                
                 cbo.DataSource = almacen;
                 cbo.DisplayMember = "in09descripcion";
                 cbo.ValueMember = "in09codigo";

                 //Establesco por defecto Todos los alamcenes
                 cbo.SelectedValue = Logueo.MP_AlmxDefecto;
             }


             catch (Exception ex)
             {
                 //RadMessageBox.Show(ex.Message, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);

             }
         }
    
         protected override void OnRefrescar()
         {
             if (rpvGeneral.SelectedPage == this.rpvStockResumido)
             {
                 OnBuscar();
             }
             else if (rpvGeneral.SelectedPage == this.rpvStockDetallado)
             {
                 CargarStockDetallado();
             }
         }
         protected override void OnVista()
         {
             //string mensajeOut = string.Empty;
             string periodostock;
             string periodoreporte;
             string flagfiltro = "";
             
             string codigoAlmacen = this.cboalmacenes.SelectedValue.ToString();
             
             string xml = "";
             var x = 0;

             if (rpvGeneral.SelectedPage == rpvStockResumido)
             {
                 flagfiltro = "P";
                 var codigosSeleccionados = new string[gridControl.SelectedRows.Count];

                 foreach (var filaSeleccionado in gridControl.SelectedRows)
                 {
                     //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                     codigosSeleccionados[x] = filaSeleccionado.Cells["IN01KEY"].Value.ToString();
                     //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
                     x++;
                 }
                 xml = Util.ConvertiraXML(codigosSeleccionados);
             }
             else if (rpvGeneral.SelectedPage == rpvStockDetallado)
             {
                 flagfiltro = "B";
                 string[] codigoseleccionados1 = new string[gridDetalle.SelectedRows.Count];
             
                 foreach (GridViewRowInfo filaseleccionado in gridDetalle.SelectedRows)
                 {
                     codigoseleccionados1[x] = filaseleccionado.Cells["NROBLOQUE"].Value.ToString();
                     x++;
                 }

                 xml = Util.ConvertiraXML(codigoseleccionados1);
             }

             Cursor.Current = Cursors.WaitCursor;

             periodostock = (Logueo.Mes + "-" + Logueo.Anio);
             periodoreporte = (Logueo.Anio + Logueo.Mes);

             var datos = DocumentoLogic.Instance.RptMateriaPrimaStock(Logueo.CodigoEmpresa, periodoreporte,codigoAlmacen,flagfiltro, xml);

             Reporte reporte = new Reporte("Documento");
             reporte.Ruta = Logueo.GetRutaReporte();

             if (rpvGeneral.SelectedPage == rpvStockResumido)

             {
                 reporte.Nombre = "RptStockMP_Res.rpt";
                 reporte.DataSource = datos;

                 reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
                 reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

                 ReporteControladora control = new ReporteControladora(reporte);
                 control.VistaPrevia(enmWindowState.Normal);
             }
             else if (rpvGeneral.SelectedPage == rpvStockDetallado)
             {

                 reporte.Nombre = "RptStockMP_Det.rpt";
                 reporte.DataSource = datos;

                 reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
                 reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

                 ReporteControladora control = new ReporteControladora(reporte);
                 control.VistaPrevia(enmWindowState.Normal);
             }

             Cursor.Current = Cursors.Default;

         }
        #endregion
        
        #region "Stock resumido" 
        private void Crearcolumnas()
        {
             grilla =  this.CreateGrid(this.gridControl);
            //{0:###,###0.00} {0:###,###0.00}
           
             this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 300, true, false, true);
            this.CreateGridColumn(grilla, "Unidad Medida", "IN01UNIMED", 0, "", 40, true, false, true);
            this.CreateGridColumn(grilla, "Volumen", "StockRealVolumen", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            this.CreateGridColumn(grilla, "#Bloques", "BloquesCantidad", 0, "{0:###,###0.00}", 85, true, false, true, "right");
            this.CreateGridColumn(grilla, "Tipo", "tipo", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Color.", "color", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Tonalidad", "tonalidad", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Formato", "formato", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Modelo", "modelo", 0, "", 100, true, false, true);


            // Suma Stock Real
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "StockRealVolumen";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;


            // Conteo de Bloques
            GridViewSummaryItem summaryItemCajas = new GridViewSummaryItem();
            summaryItemCajas.Name = "BloquesCantidad";
            summaryItemCajas.FormatString = "{0}";
            summaryItemCajas.Aggregate = GridAggregateFunction.Sum;


            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem , summaryItemCajas};
                        //summaryRowItem.Add(summaryItem);

            grilla.SummaryRowsBottom.Add(summaryRowItem);


            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            crearGrupos();
            
        }
        void crearGrupos()
        {
            try {

                this.columnGroupsView = new ColumnGroupsViewDefinition();
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("General"));
                this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());

                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01KEY"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01DESLAR"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(grilla.Columns["IN01UNIMED"]);

                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Stock"));
                this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["StockRealVolumen"]);
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(grilla.Columns["BloquesCantidad"]);



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
            catch (Exception ex) {
                MessageBox.Show("Erro crear Grupo:" + ex.Message);
            }
            

        }
        void crearGruposDetalle() 
        {
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Producto"));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07FECDOC"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["DocRespaldoNro"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["ProvBloqueNombre"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["CanteraNombre"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["ContratistaNombre"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["in09descripcion"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["NROBLOQUE"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07CODBLOQUEPROV"]);

            
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Medidas de Planta"));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07LARGO"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07ANCHO"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07ALTO"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControlDet.Columns["VolumenPlanta"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Medidas de Cantera"));
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07LARGOCAN"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07ANCHOCAN"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControlDet.Columns["IN07ALTOCAN"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControlDet.Columns["VolumenCantera"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
            this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControlDet.Columns["in07observacion"]);

            this.gridControlDet.ViewDefinition = columnGroupsView;
            //in07observacion
        }
        private void CrearcolumnasDet()
        {

            RadGridView gridDet = this.CreateGrid(this.gridControlDet);
           
            this.CreateGridColumn(gridDet, "Fecha", "IN07FECDOC", 0, "", 75, true, false, true, "left");
            this.CreateGridColumn(gridDet, "Doc Respaldo", "DocRespaldoNro", 0, "", 100, true, false, true, "center");

            this.CreateGridColumn(gridDet, "Proveedor", "ProvBloqueNombre", 0, "", 150, true, false, true, "left");
            this.CreateGridColumn(gridDet, "Cantera", "CanteraNombre", 0, "", 150, true, false, true, "left");
            this.CreateGridColumn(gridDet, "Contratista", "ContratistaNombre", 0, "", 150, true, false, true, "left");
            this.CreateGridColumn(gridDet, "Almacen", "in09descripcion", 0, "", 150, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Nro Bloque", "NROBLOQUE", 0, "", 100, true, false, true, "center");
            this.CreateGridColumn(gridDet, "Cod Proveedor", "IN07CODBLOQUEPROV", 0, "", 50, true, false, true, "center");
            // Medidad Planta
            this.CreateGridColumn(gridDet, "Largo", "IN07LARGO", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Ancho", "IN07ANCHO", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Alto", "IN07ALTO", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Volumen", "VolumenPlanta", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            // Medidad Cantera
            this.CreateGridColumn(gridDet, "largo ", "IN07LARGOCAN", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Ancho", "IN07ANCHOCAN", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Alto", "IN07ALTOCAN", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Volumen", "VolumenCantera", 0, "{0:###,###0.00}", 50, true, false, true, "right");
            //
            this.CreateGridColumn(gridDet, "Observacion", "in07observacion", 0, "", 250, true, false, true, "left");
            crearGruposDetalle();
        }
        protected  void OnBuscarDet()
        {
            string codigoproducto = string.Empty;
            if (this.gridControl.RowCount == 0)
                return;

            codigoproducto = this.gridControl.CurrentRow.Cells["in01key"].Value.ToString();
            string almacen = this.cboalmacenes.SelectedValue.ToString();
            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;
            
            var lista = ArticuloLogic.Instance.TraerMPStockDet(Logueo.CodigoEmpresa, codigoproducto, almacen);
            this.gridControlDet.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;
            if (this.cboalmacenes.SelectedValue == null) return;
            string codigoAlmacen = this.cboalmacenes.SelectedValue.ToString();
            var lista = ArticuloLogic.Instance.TraerMPStock(Logueo.CodigoEmpresa, Logueo.Anio, codigoAlmacen);
            //this.gridControl.DataSource = lista;
            grilla.DataSource = lista;
           
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

        private void rbtRefresh_Click(object sender, EventArgs e)
        {
            if (rpvGeneral.SelectedPage == this.rpvStockResumido)
            {
                OnBuscar();
            }
            else if (rpvGeneral.SelectedPage == this.rpvStockDetallado)
            { 
                
            }
        }

        private void cboalmacenes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            if (rpvGeneral.SelectedPage == this.rpvStockResumido)
            {
                OnBuscar();
            }
            else if (rpvGeneral.SelectedPage == this.rpvStockDetallado)
            {
                CargarStockDetallado();
            }
            
        }

        private void cboalmacenes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!isLoaded) return;

        }
        #endregion
    }

}