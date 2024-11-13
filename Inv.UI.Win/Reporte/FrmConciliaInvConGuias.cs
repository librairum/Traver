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
    public partial class FrmConciliaInvConGuias : frmBaseReporte
    {
        private bool isLoaded = false;
        ColumnGroupsViewDefinition columnGroupsView;
        RadGridView grilla;
        private void FrmConciliaInvConGuias_Load(object sender, EventArgs e)
        {           
           // CargarCombos();                                                
            //this.gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);            
        }
        private frmMDI FrmParent { get; set; }
        private static FrmConciliaInvConGuias _aForm;

         public static FrmConciliaInvConGuias Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmConciliaInvConGuias(mdiPrincipal);
            _aForm = new FrmConciliaInvConGuias(mdiPrincipal);
            return _aForm;
        }
      
         public FrmConciliaInvConGuias(frmMDI padre)
        {
            InitializeComponent();
            Crearcolumnas();
            CrearcolumnasDet();
            FrmParent = padre;
            OnBuscar();
            HabilitarBotones(true, true, true,false,true);

            this.gridControl.CustomFiltering += new GridViewCustomFilteringEventHandler(abrirFiltro);
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
       
         void abrirFiltro(object sender, GridViewCustomFilteringEventArgs e) {
             MessageBox.Show("Filtro de grilla");
         }
        public FrmConciliaInvConGuias()
        {
            InitializeComponent();
        }

        private void Crearcolumnas()
        {
             grilla =  this.CreateGrid(this.gridControl);
            //{0:###,###0.00} {0:###,###0.00}

             this.CreateGridColumn(grilla, "Almacen Tran Cod", "AlmacenTranCod", 0, "", 50, true, false, true);
             this.CreateGridColumn(grilla, "Almacen Tran Desc", "AlmacenTranDesc", 0, "", 150, true, false, true);
             this.CreateGridColumn(grilla, "Almacen Cant MT2", "AlmacenCantMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             this.CreateGridColumn(grilla, "Almacen Cant OtraUniMed", "AlmacenCantOtraUniMed", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             this.CreateGridColumn(grilla, "Guia MovTra Cod", "GuiaMovTraCod", 0, "", 50, true, false, true);
             this.CreateGridColumn(grilla, "Guia MovTra Desc", "GuiaMovTraDesc", 0, "", 150, true, false, true);
             this.CreateGridColumn(grilla, "Guia Cant MT2", "GuiaCantMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             this.CreateGridColumn(grilla, "Guia Cant OtraUniMed", "GuiaCantOtraUniMed", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             this.CreateGridColumn(grilla, "Diferencia CantMT2", "DiferenciaCantMT2", 0, "{0:###,###0.00}", 70, true, false, true, "right");
             this.CreateGridColumn(grilla, "Diferencia Cant OtraUniMed", "DiferenciaCantOtraUniMed", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            
            // Suma Stock Real
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "AlmacenCantMT2";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            // Suma Stock Reserva
            GridViewSummaryItem summaryStockReserva = new GridViewSummaryItem();
            summaryStockReserva.Name = "AlmacenCantOtraUniMed";
            summaryStockReserva.FormatString = "{0:###,###0.00}";
            summaryStockReserva.Aggregate = GridAggregateFunction.Sum;

            // Suma Stock produccion a pedido
            GridViewSummaryItem summaryStockProduccion = new GridViewSummaryItem();
            summaryStockProduccion.Name = "GuiaCantMT2";
            summaryStockProduccion.FormatString = "{0:###,###0.00}";
            summaryStockProduccion.Aggregate = GridAggregateFunction.Sum;

            // Suma Stok disponible
            GridViewSummaryItem summaryStockDisponible = new GridViewSummaryItem();
            summaryStockDisponible.Name = "GuiaCantOtraUniMed";
            summaryStockDisponible.FormatString = "{0:###,###0.00}";
            summaryStockDisponible.Aggregate = GridAggregateFunction.Sum;

            
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem, summaryStockReserva, summaryStockProduccion, summaryStockDisponible };
            grilla.SummaryRowsBottom.Add(summaryRowItem);
            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }
       
        private void CrearcolumnasDet()
        {
            RadGridView gridDet = this.CreateGrid(this.gridControlDet);


            this.CreateGridColumn(gridDet, "Almacen Guia", "AlmacenGuia", 0, "", 80, true, false, true);
            this.CreateGridColumn(gridDet, "Cantidad MT2", "CantidadMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Cantidad OtraUniMed", "CantidadOtraUniMed", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Guia Nro", "Guia_Nro", 0, "", 80, true, false, true);
            this.CreateGridColumn(gridDet, "Guia Estado", "Guia_Estado", 0, "", 50, true, false, true);
            this.CreateGridColumn(gridDet, "Guia CantidadMT2", "GuiaCantidadMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            this.CreateGridColumn(gridDet, "Guia Cantidad OtraUniMed", "GuiaCantidadOtraUniMed", 0, "{0:###,###0.00}", 50, true, false, true, "right");

            string[] columnas = new string[4];
            columnas[0] = "CantidadMT2";
            columnas[1] = "CantidadOtraUniMed";
            columnas[2] = "GuiaCantidadMT2";
            columnas[3] = "GuiaCantidadOtraUniMed";
            
            Util.AddGridSummarySum(gridDet, columnas);
        }
     
        protected override void OnRefrescar()
        {
            //OnBuscar();
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;
            var lista = ArticuloLogic.Instance.TraeConciliaAlmConGuias(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            
            //this.gridControl.DataSource = lista;
            grilla.DataSource = lista;
           
            Cursor.Current = Cursors.Default;
        }
        protected void OnBuscarDet()
        {
            string CodTransaccionAlmacen = string.Empty;
            string CodMotivoGuia = string.Empty;

            
            if (this.gridControl.RowCount == 0)
                return;

            CodTransaccionAlmacen = this.gridControl.CurrentRow.Cells["AlmacenTranCod"].Value.ToString();
            CodMotivoGuia = this.gridControl.CurrentRow.Cells["GuiaMovTraCod"].Value.ToString();
            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;

            var lista = ArticuloLogic.Instance.TraeConciliaAlmConGuiasDet(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, CodTransaccionAlmacen, CodMotivoGuia);
            this.gridControlDet.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }
        protected override void OnVista()
        {
           
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
                    if (e.CurrentRow.Cells["AlmacenTranCod"].Value != null)
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
            
        }

        private void gridControl_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            
        }

        private void cboalmacenes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void cboalmacenes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            OnBuscar();
        }
    }

}