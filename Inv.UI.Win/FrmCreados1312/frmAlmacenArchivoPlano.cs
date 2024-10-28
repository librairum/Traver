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
namespace Inv.UI.Win
{
    public partial class frmAlmacenArchivoPlano : frmBaseReporte
    {
        #region "Instancia"
        
        private static frmAlmacenArchivoPlano _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmAlmacenArchivoPlano Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmAlmacenArchivoPlano(formParent);
            _aForm = new frmAlmacenArchivoPlano(formParent);
            return _aForm;
        }
        #endregion
       
        public frmAlmacenArchivoPlano(frmMDI padre)
        {
            InitializeComponent();
        }
        private void CrearColumnas()
        {
             RadGridView Grid =  CreateGrid(this.gridControl);
             gridControl.ShowRowHeaderColumn = true;

	         CreateGridColumn(Grid, "Empresa", "EmpresaCod", 0, "", 40, true, false, true);
             CreateGridColumn(Grid, "Anio", "Anio", 0, "", 60, true, false, true);
             CreateGridColumn(Grid, "Mes", "Mes", 0, "", 40, true, false, true);
             CreateGridColumn(Grid, "TransaccionCod", "TransaccionCod", 0, "", 40, true, false, true);
             CreateGridColumn(Grid, "TransaccionDesc", "TransaccionDesc", 0, "", 80, true, false, true);
             CreateGridColumn(Grid, "EntradaoSalida", "EntradaoSalida", 0, "", 40, true, false, true);
             CreateGridColumn(Grid, "DocumentoNum", "DocumentoNum", 0, "", 100, true, false, true);
             CreateGridColumn(Grid, "Fecha", "Fecha", 0, "{0:dd/MM/yyyy}", 80, true, false, true);
             CreateGridColumn(Grid, "Doc Res Tip", "DocRespaldoTip", 0, "", 40, true, false, true);
             CreateGridColumn(Grid, "Doc Res TipDesc", "DocRespaldoDesc", 0, "", 80, true, false, true);
             CreateGridColumn(Grid, "Doc Res Nro", "DocRespaldoNro", 0, "", 80, true, false, true);
             CreateGridColumn(Grid, "Doc Res CtaCte", "DocRespaldoCtaCteRUC", 0, "", 80, true, false, true);
             CreateGridColumn(Grid, "Doc Res CtaCte Desc", "DocRespaldoCtaCteDesc", 0, "", 80, true, false, true);

             CreateGridColumn(Grid, "Prod Cod", "ProductoCod", 0, "", 80, true, false, true);
             CreateGridColumn(Grid, "Prod UniMed ", "ProductoUniMed", 0, "", 40, true, false, true);
             CreateGridColumn(Grid, "Prod Desc", "ProductoDesc", 0, "", 150, true, false, true);
             
             CreateGridColumn(Grid, "Cantidad", "Cantidad", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "CostoSoles", "CostoSoles", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "ImporteSol", "ImporteSol", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "CostoPromedioSol", "CostoPromedioSol", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            
                string[] columnas = new string[8];
                columnas[0] = "Cantidad";
                columnas[1] = "ImporteSol";
                 Util.AddGridSummarySum(Grid, columnas);

        }
        private void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Spu_Inv_Rep_ArchiPlanoAlmacenes> lista;
            string mesinicial = "", mesfinal = "";

            mesinicial = Util.convertiracadena(cbomesini.SelectedValue);
            mesfinal = Util.convertiracadena(cbomesfin.SelectedValue);
          // DataTable lista = DocumentoLogic.Instance.TraeArchivoPlanoAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, mesinicial, mesfinal);

          //  gridControl.DataSource = lista;
            Cursor.Current = Cursors.Default;
        }

        private void frmAlmacenArchivoPlano_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //OcultarBotones();
                //OcultarBarraBotones();

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
