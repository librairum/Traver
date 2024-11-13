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
    public partial class FrmSUStock : frmBaseReporte
    {
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        RadGridView grilla;
        private void FrmSUStock_Load(object sender, EventArgs e)
        {                                            
            isLoaded = true;
        }
        private frmMDI FrmParent { get; set; }
        private static FrmSUStock _aForm;

         public static FrmSUStock Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmSUStock(mdiPrincipal);
            _aForm = new FrmSUStock(mdiPrincipal);
            return _aForm;
        }

         public FrmSUStock(frmMDI padre)
        {
            InitializeComponent();
            Crearcolumnas();
            CrearcolumnasDet();

            FrmParent = padre;
            CargarAlmacenes(this.cboalmacenes);
            OnBuscar();
            //OnBuscarDet();
            
            //this.gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);
            HabilitarBotones(true, true, true, false,true);

            
            this.gridControl.CustomFiltering += new GridViewCustomFilteringEventHandler(abrirFiltro);
            
            
        }
      
        #region "Metodos Generales"
       
         void abrirFiltro(object sender, GridViewCustomFilteringEventArgs e)
         {
             MessageBox.Show("Filtro de grilla");
         }

         private void CargarAlmacenes(RadDropDownList cbo)
         {
             try
             {

                 var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.PS_codnaturaleza);
                 //--AlmacenLogic.Instance.AlmacenesMasTodos(Logueo.CodigoEmpresa);                
                 cbo.DataSource = almacen;
                 cbo.DisplayMember = "in09descripcion";
                 cbo.ValueMember = "in09codigo";

                 //Establesco por defecto Todos los alamcenes
                 cbo.SelectedValue = Logueo.PS_AlmaxDefectoStock;
             }


             catch (Exception ex)
             {
                 //RadMessageBox.Show(ex.Message, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);

             }
         }

         protected override void OnRefrescar()
         {
                 OnBuscar();
          }
         protected override void OnVista()
         {
             //string mensajeOut = string.Empty;
             string periodostock;
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
                     codigosSeleccionados[x] = filaSeleccionado.Cells["IN01KEY"].Value.ToString();                     
                     x++;
                 }
                 xml = Util.ConvertiraXML(codigosSeleccionados);
             }

             Cursor.Current = Cursors.WaitCursor;

             periodostock = (Logueo.Anio + "-" + Logueo.Mes);
             

             

             Reporte reporte = new Reporte("Documento");
             reporte.Ruta = Logueo.GetRutaReporte();

             if (Logueo.sedetipodondeseejecutaelsistema == "ADMINISTRACION")
             {
                 var datos = DocumentoLogic.Instance.Spu_Inv_Rep_StockSuministrosVal(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoAlmacen, "S", xml);
                 reporte.Nombre = "RptStockSuministrosVal.rpt";
                 reporte.DataSource = datos;
             }
             else
             {
                 var datos1 = DocumentoLogic.Instance.RptStockSuministros(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoAlmacen, flagfiltro, xml);
                 reporte.Nombre = "RptStockSuministros.rpt";
                 reporte.DataSource = datos1;
             }  
             
             reporte.FormulasFields.Add(new Formula("periodostock", periodostock));
             reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

             ReporteControladora control = new ReporteControladora(reporte);
             control.VistaPrevia(enmWindowState.Normal);
             
             Cursor.Current = Cursors.Default;

         }
        #endregion
        
        #region "Stock resumido" 
        private void Crearcolumnas()
        {
             grilla =  this.CreateGrid(this.gridControl);
            //{0:###,###0.00} {0:###,###0.00}
           
             this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 500, true, false, true);
            this.CreateGridColumn(grilla, "Unidad Medida", "IN01UNIMED", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Stock", "Stock", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            //columna editable
            this.CreateGridColumn(grilla, "Ubicacion", "in01Ubicacion", 0, "", 120, false, true, true);

            // Suma Stock Real
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "Stock";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem};
            //summaryRowItem.Add(summaryItem);

            grilla.SummaryRowsBottom.Add(summaryRowItem);


            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            //crearGrupos();
            
        }
        private void CrearcolumnasDet()
        {

            RadGridView gridDet = this.CreateGrid(this.gridControlDet);
            
            this.CreateGridColumn(gridDet, "Almacen Cod", "AlmacenCod", 0, "", 80, true, false, true, "left");
            this.CreateGridColumn(gridDet, "Almacen", "AlmDescripcion", 0, "", 200, true, false, true, "left");
            this.CreateGridColumn(gridDet, "Stock", "Stock", 0, "{0:###,###0.00}", 50, true, false, true, "right");

            // Suma Stock Real
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "Stock";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem };
            //summaryRowItem.Add(summaryItem);

            gridDet.SummaryRowsBottom.Add(summaryRowItem);


            gridDet.MasterTemplate.ShowTotals = true;
            gridDet.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

            
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

            var lista = ArticuloLogic.Instance.TraerSUStockxAlm(Logueo.CodigoEmpresa, Logueo.Anio, almacen, codigoproducto);
            this.gridControlDet.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;
            if (this.cboalmacenes.SelectedValue == null) return;
            string codigoAlmacen = this.cboalmacenes.SelectedValue.ToString();
            var lista = ArticuloLogic.Instance.TraerSUStock(Logueo.CodigoEmpresa, Logueo.Anio, codigoAlmacen);
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
        private void gridControl_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                //if (e.Value == null) return;
                if (e.Column.Name.ToUpper().CompareTo("IN01UBICACION") == 0)
                {
                    GuardarDetalle(e.Row);
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al terminar la edicion ");
            }
        }
        private void cboalmacenes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!isLoaded) return;
            OnBuscar();

        }
        #endregion
        private void GuardarDetalle(GridViewRowInfo info)
        {
            try
            {
                

                    string codigoProducto = Util.GetCurrentCellText(gridControl.CurrentRow, "IN01KEY");
                    string ubicacion = Util.GetCurrentCellText(gridControl.CurrentRow, "in01Ubicacion");

                string mensajeRetorno = string.Empty;
                int flagok = -1;

                ArticuloLogic.Instance.ActualizaArtiSuministro(Logueo.CodigoEmpresa, Logueo.Anio,
                    ubicacion, codigoProducto, out flagok, out mensajeRetorno);
                

                if (flagok == -1)
                {
                    RadMessageBox.Show("Actualizar Ubicacion", mensajeRetorno, MessageBoxButtons.OK, RadMessageIcon.Info);
                }

            }
            //RadMessageBox.Show("Grabar Nuevo Registro", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            catch (Exception)
            {

                throw;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string[] registros = new string[gridControl.Rows.Count];
                int x = 0;

                

                //foreach (GridViewRowInfo fila in gridControl.Rows)
                //{

                //    string codigoProducto = Util.GetCurrentCellText(fila, "IN01KEY");
                //    string ubicacion = Util.GetCurrentCellText(fila, "in01Ubicacion");
                //    registros[x] = codigoProducto + "|" + ubicacion;
                //    x++;
                    
                //}

                //int flag = 0; string mensaje = "";
                //string xml = Util.ConvertiraXMLdinamico(registros);
                //ArticuloLogic.Instance.ActualizaArtiSuministro(Logueo.CodigoEmpresa, Logueo.Anio, xml, out flag, out mensaje);
                //Util.ShowMessage(mensaje, flag);


                //if (flag == 1)
                //{
                //    OnBuscar();
                //}
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar");
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnSeleccionarTodo()
        {
           
            gridControl.SelectAll();
        }


    }

}