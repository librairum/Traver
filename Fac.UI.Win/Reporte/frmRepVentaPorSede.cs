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
    public partial class frmRepVentaPorSede : frmBaseReporte
    {
        #region "Instancia"
        VentaDocumentoLogic datos = VentaDocumentoLogic.Instance;
        private static frmRepVentaPorSede _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepVentaPorSede Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepVentaPorSede(formParent);
            _aForm = new frmRepVentaPorSede(formParent);
            return _aForm;
        }
        #endregion
        public frmRepVentaPorSede(frmMDI padre)
        {
            InitializeComponent();

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
        private void CrearColumnas()
        { 
            RadGridView Grid =  CreateGrid(this.gridControl);
            gridControl.ShowRowHeaderColumn = true;

            CreateGridColumn(Grid, "Doc Tipo", "DocTipo", 0, "", 120, true, false, true);
            CreateGridColumn(Grid, "Doc Numero", "DocNumero", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "Anio", "Anio", 0, "", 60, true, false, true);
            CreateGridColumn(Grid, "Mes", "Mes", 0, "", 60, true, false, true);
            CreateGridColumn(Grid, "Cliente Nombre", "ClienteNombre", 0, "", 200, true, false, true);
            CreateGridColumn(Grid, "Tipo de Venta", "TipoDeVenta", 0, "", 200, true, false, true);
            CreateGridColumn(Grid, "Tienda Desc", "TiendaDesc", 0, "", 110, true, false, true);
            CreateGridColumn(Grid, "Estado ", "Estado", 0, "", 90, true, false, true);
            
            CreateGridColumn(Grid, "Moneda", "Moneda", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Subtotal S/.", "SubtotalSoles", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Igv S/.", "IgvSoles", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Total S/.", "totalSoles", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "SubTotal $", "SubtotalDolares", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Igv $", "IgvDolares", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Total $", "totalDolares", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            
            string[] columnas = new string[6];
            columnas[0] = "SubtotalSoles";
            columnas[1] = "IgvSoles";
            columnas[2] = "totalSoles";
            columnas[3] = "SubtotalDolares";
            columnas[4] = "IgvDolares";
            columnas[5] = "totalDolares";
            
            Util.AddGridSummarySum(Grid, columnas);
            
        }
        private void Cargar()
        {
            string mesinicial = "", mesfinal = "";
            List<Spu_Fact_Rep_VentaXSede> lista;
            try
            {
                mesinicial = Util.convertiracadena(cbomesini.SelectedValue);
                mesfinal = Util.convertiracadena(cbomesfin.SelectedValue);
                lista = datos.TraeVentaPorSede(Logueo.CodigoEmpresa, Logueo.Anio, mesinicial, mesfinal);
                gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar grilla : " + ex.Message);
            }
        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cargar();
            Cursor.Current = Cursors.Default;
        }

        private void frmRepVentaPorSede_Load(object sender, EventArgs e)
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
                Util.ShowMessage("Filas copiadas", 1);
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
