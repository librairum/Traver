using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Fac.UI.Win
{
    public partial class frmRepVentasAnuales : frmBaseReporte
    {
        #region "Instancia"
        
        private static frmRepVentasAnuales _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepVentasAnuales Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepVentasAnuales(formParent);
            _aForm = new frmRepVentasAnuales(formParent);
            return _aForm;
        }
        #endregion
       
        public frmRepVentasAnuales(frmMDI padre)
        {
            InitializeComponent();
        }
        private void CrearColumnas()
        {
             RadGridView Grid =  CreateGrid(this.gridControl);
             gridControl.ShowRowHeaderColumn = true;
             
             CreateGridColumn(Grid, "Anio", "anio", 0, "", 60, true, false, true);
             CreateGridColumn(Grid, "Mes", "mes", 0, "", 60, true, false, true);
             CreateGridColumn(Grid, "Doc Nro", "numeroDocumento", 0, "", 100, true, false, true);
             CreateGridColumn(Grid, "fecha", "fecha", 0, "{0:dd/MM/yyyy}", 80, true, false, true);
             CreateGridColumn(Grid, "Cliente Cod", "codigoCliente", 0, "", 120, true, false, true);
             CreateGridColumn(Grid, "Moneda", "codigoMoneda", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Doc Tipo", "documentoTipo", 0, "", 120, true, false, true);
             CreateGridColumn(Grid, "Cliente Nombre", "clienteNombre", 0, "", 200, true, false, true);
             CreateGridColumn(Grid, "Estado", "estado", 0, "", 120, true, false, true);
             
             CreateGridColumn(Grid, "Iten", "codigoDetalle", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Producto Cod", "codigoProducto", 0, "", 110, true, false, true);
             CreateGridColumn(Grid, "Producto Desc", "descripcionProducto", 0, "", 200, true, false, true);
             CreateGridColumn(Grid, "Uni Med", "unidadMedida", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Cantidad", "cantidad", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Precio", "precio", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Peso", "peso", 0, "{0:###,###0.00}", 80, true, false, true, "right");             
             CreateGridColumn(Grid, "SubTotal", "subTotal", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "NroCaja", "nroCaja", 0, "", 70, true, false, true, "right");
            
                string[] columnas = new string[4];
                columnas[0] = "cantidad";
                columnas[1] = "precio";
                columnas[2] = "peso";
                columnas[3] = "subTotal";

                Util.AddGridSummarySum(Grid, columnas);

        }
        private void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Spu_Fact_Rep_VentasAnuales> lista;
            string mesinicial = "", mesfinal = "";

            mesinicial = Util.convertiracadena(cbomesini.SelectedValue);
            mesfinal = Util.convertiracadena(cbomesfin.SelectedValue);
            lista = VentaDocumentoLogic.Instance.TraeVentasAnuales(Logueo.CodigoEmpresa, Logueo.Anio, mesinicial, mesfinal);
            gridControl.DataSource = lista;
            Cursor.Current = Cursors.Default;
        }
        private void frmRepVentasAnuales_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                OcultarBotones();
                OcultarBarraBotones();

                CargarPeriodos(cbomesini);
                CargarPeriodos(cbomesfin);
                CrearColumnas();
                Cargar();

                gridControl.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar formulario , detalle : " + ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }
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
      
        private string ConvertSelectedDataToString(RadGridView grid)
        {
            StringBuilder strBuild = new StringBuilder();

            for (int row = 0; row < grid.SelectedRows.Count; row++)
            {
                for (int cell = 0; cell < grid.SelectedRows[row].Cells.Count; cell++)
                {
                    if (grid.Columns[cell].IsVisible == true)
                    {
                        strBuild.Append(grid.SelectedRows[row].Cells[cell].Value.ToString());
                        strBuild.Append("\t");
                    }
                }

                if (row < grid.SelectedRows.Count - 1)
                {
                    strBuild.Append("\n");
                }
            }

            return strBuild.ToString();
        }  

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
     
        private void gridControl_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {
               

                RadMenuItem itmCopiar = new RadMenuItem();
                itmCopiar.Name = "itmCopiar";
                itmCopiar.Text = "Copiar";
                itmCopiar.Click += new EventHandler(itmCopiar_Click);

                if (e.ContextMenuProvider is GridRowHeaderCellElement || 
                    e.ContextMenuProvider is GridDataCellElement)
                {
                    e.ContextMenu.Items.Clear();               
                    e.ContextMenu.Items.Add(itmCopiar);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al abrir menu contextual de grilla");
            }
        }

                
        private void SeleccionarTodoFilas()
        {
            try
            {
                gridControl.SelectAll();

                DataObject dataObj = gridControl.GetClipboardContent();
                if (dataObj != null)
                {
                    Clipboard.SetDataObject(dataObj);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al copiar todo las filas , detalle:" + ex.Message);
            }
        }
        
        void itmCopiar_Click(object sender, EventArgs e)
        {
            string copyStr = ConvertSelectedDataToString(this.gridControl);
            Clipboard.SetDataObject(copyStr);   
        }

        private void btnCopiarTodo_Click(object sender, EventArgs e)
        {
            SeleccionarTodoFilas();
        }

     

     
    }
}
