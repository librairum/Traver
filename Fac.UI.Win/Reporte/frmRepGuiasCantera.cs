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
    public partial class frmRepGuiasCantera : frmBaseReporte
    {
        #region "Instancia"
        
        private static frmRepGuiasCantera _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepGuiasCantera Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepGuiasCantera(formParent);
            _aForm = new frmRepGuiasCantera(formParent);
            return _aForm;
        }
        #endregion
       
        public frmRepGuiasCantera(frmMDI padre)
        {
            InitializeComponent();
        }
        private void CrearColumnas()
        {
             RadGridView Grid =  CreateGrid(this.gridControl);
             gridControl.ShowRowHeaderColumn = true;
             
             CreateGridColumn(Grid, "Empresa", "FAC34CODEMP", 0, "", 60, true, false, true);
             CreateGridColumn(Grid, "Anio", "FAC34AA", 0, "", 60, true, false, true);
             CreateGridColumn(Grid, "Mes", "FAC34MM", 0, "", 100, true, false, true);
             CreateGridColumn(Grid, "Serie", "FAC34SERIEGUIA", 0, "", 100, true, false, true);
             CreateGridColumn(Grid, "Guia Nro", "FAC34NROGUIA", 0, "", 120, true, false, true);
             CreateGridColumn(Grid, "Fecha", "FAC34FECHA", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
             CreateGridColumn(Grid, "Origen", "FAC34ORIDESESTAB", 0, "", 200, true, false, true);
             CreateGridColumn(Grid, "Destino ", "FAC34DESDESESTAB", 0, "", 120, true, false, true);
             CreateGridColumn(Grid, "Destino Dir", "FAC34DESTDIRECCION", 0, "", 80, true, false, true);
             CreateGridColumn(Grid, "Motivo", "FAC34MOTRASLDESC", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Motivo Desc", "FAC34MOTRASLDESCEXTRA", 0, "", 110, true, false, true);
             CreateGridColumn(Grid, "Estado", "FAC34ESTADO", 0, "", 200, true, false, true);
             CreateGridColumn(Grid, "Transportista", "FAC34DESTRANSPORTISTA", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Destino", "FAC34DESDESEMP", 0, "", 70, true, false, true);
            								

            CreateGridColumn(Grid, "Item", "FAC35CODGUIADET", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Prod Cod", "FAC35CODPROD", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Prod Desc", "FAC35DESCPROD", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Prod Uni Med", "FAC35UNIMED", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Cantidad", "FAC35CANTIDAD", 0, "{0:###,###0.00}", 70, true, false, true);
            CreateGridColumn(Grid, "Piezas", "FA35NROPIEZAS", 0, "{0:###,###0.00}", 70, true, false, true);
            CreateGridColumn(Grid, "Pesos", "FA35PESO", 0, "{0:###,###0.00}", 70, true, false, true);
            CreateGridColumn(Grid, "Contratista", "FAC37CONTRATISTADESC", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Labor", "FAC37LABORDESC", 0, "", 70, true, false, true);

            string[] columnas = new string[3];
                columnas[0] = "FAC35CANTIDAD";
                columnas[1] = "FA35NROPIEZAS";
                columnas[2] = "FA35PESO";
                
                Util.AddGridSummarySum(Grid, columnas);
        }
        private void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Spu_Fact_Rep_GuiasCantera> lista;
            string mesinicial = "", mesfinal = "";

            mesinicial = Util.convertiracadena(cbomesini.SelectedValue);
            mesfinal = Util.convertiracadena(cbomesfin.SelectedValue);
            lista = VentaDocumentoLogic.Instance.TraeGuiasCantera(Logueo.CodigoEmpresa, Logueo.Anio, mesinicial, mesfinal);
            gridControl.DataSource = lista;
            Cursor.Current = Cursors.Default;
        }
        private void frmRepGuiasCantera_Load(object sender, EventArgs e)
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
