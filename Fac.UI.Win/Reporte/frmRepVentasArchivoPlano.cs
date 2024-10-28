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
    public partial class frmRepVentasArchivoPlano : frmBaseReporte
    {
        #region "Instancia"
        
        private static frmRepVentasArchivoPlano _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepVentasArchivoPlano Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepVentasArchivoPlano(formParent);
            _aForm = new frmRepVentasArchivoPlano(formParent);
            return _aForm;
        }
        #endregion
       
        public frmRepVentasArchivoPlano(frmMDI padre)
        {
            InitializeComponent();
        }
        private void CrearColumnas()
        {
             RadGridView Grid =  CreateGrid(this.gridControl);
             gridControl.ShowRowHeaderColumn = true;
             
             CreateGridColumn(Grid, "Anio", "FAC04AA", 0, "", 60, true, false, true);
             CreateGridColumn(Grid, "Mes", "FAC04MM", 0, "", 60, true, false, true);
             CreateGridColumn(Grid, "TipDocCod", "FAC01COD", 0, "", 100, true, false, true);
             CreateGridColumn(Grid, "TipDocDesc", "DocTipo", 0, "", 100, true, false, true);
             CreateGridColumn(Grid, "Doc Serie", "FAC04SERIEDOC", 0, "", 120, true, false, true);
             CreateGridColumn(Grid, "Doc Nro", "FAC04NUMDOC", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Clasificacion Venta", "ClasificacionVenta", 0, "", 200, true, false, true);
             CreateGridColumn(Grid, "Tipo Venta", "TipoDeVenta", 0, "", 120, true, false, true);
             CreateGridColumn(Grid, "Fecha", "FAC04FECHA", 0, "{0:dd/MM/yyyy}", 80, true, false, true);
             CreateGridColumn(Grid, "Cliente Cod", "FAC04CODCLI", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Cliente Desc", "ClienteNombre", 0, "", 110, true, false, true);
             CreateGridColumn(Grid, "Observacion", "OBSERVACION", 0, "", 200, true, false, true);
             CreateGridColumn(Grid, "Guias", "Guias", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "O COMPRA", "O_COMPRA", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Liquidacion Nro", "LiquidacionNro", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Voucher Contable", "VoucherContable", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Pais Destino", "PaisDestino", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Doc Mod Cod", "DOCMODTIPDOC", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Doc Mod Nro", "FAC04DOCMODNRO", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Doc Mod Fecha", "DOCMODFECHA", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Estado Sunat", "EstadoSunat", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Estado", "Estado", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Producto Item", "FAC05CODFACDET", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Producto Cod", "FAC05CODPROD", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Producto Desc", "FAC05DESCPROD", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Prod Tipo", "ProductoTipo", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Prod Clasi", "ProductoClasificacion", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Uni Med", "UNIMED", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Cantidad", "CANTIDAD", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Nro Cajas", "NROCAJAS", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Nro Etiqueta", "NROETIQUETAS", 0, "{0:###,###0.00}", 80, true, false, true, "right");

            CreateGridColumn(Grid, "Cantidad Mt o TM", "CANTIDAD_MT2oTM", 0, "{0:###,###0.00}", 80, true, false, true, "right");             
             CreateGridColumn(Grid, "TM Segun MT", "TMSegun_MT", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Cantidad OtraUniMed", "CANTIDAD_OtrasUniMed", 0, "", 70, true, false, true, "right");
             CreateGridColumn(Grid, "Moneda", "FAC04MONEDA", 0, "", 70, true, false, true);
             CreateGridColumn(Grid, "Tipo Cambio", "FAC04TIPCAMBIO", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             // Moneda original
            CreateGridColumn(Grid, "Precio Ori", "PRECIO_ORI", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Dscto Ori", "DSCTO_ORI", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Igv Ori", "IGV_ORI", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Sub Total Ori", "SUBTOTAL_ORI", 0, "{0:###,###0.00}", 80, true, false, true, "right");
             CreateGridColumn(Grid, "Total Ori", "TOTAL_ORI", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            // Moneda Soles 
            CreateGridColumn(Grid, "Precio Sol", "PRECIO_SOLES", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Dscto Sol", "DSCTO_SOLES", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Igv Sol", "IGV_SOLES", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "SubTotal Sol", "SUBTOTAL_SOLES", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Total Sol", "TOTAL_SOLES", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            
            // Moneda Dolares
            CreateGridColumn(Grid, "Precio Dol", "PRECIO_DOL", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Dscto Dol", "DSCTO_DOL", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Igv Dol", "IGV_DOL", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Sub Total Dol", "SUBTOTAL_DOL", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Total Dol", "TOTAL_DOL", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            
            CreateGridColumn(Grid, "Peso", "FAC05PESO", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Guia TipDoc", "FAC05GUIATIPDOC", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Guia Nro", "FAC05GUIANUMERO", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Guia Item", "FAC05GUIAITEM", 0, "{0:###,###0.00}", 80, true, false, true, "right");
            CreateGridColumn(Grid, "Color", "Color", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Cantera Cod", "Cantera", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Cantera Desc", "CanteraDesc", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "VendedorNombre", "VendedorNombre", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "NroDeEtiquetas", "NroDeEtiquetas", 0, "", 70, true, false, true);

                string[] columnas = new string[8];
                columnas[0] = "IGV_SOLES";
                columnas[1] = "SUBTOTAL_SOLES";
                columnas[2] = "TOTAL_SOLES";
                columnas[3] = "IGV_DOL";
                columnas[4] = "SUBTOTAL_DOL";
                columnas[5] = "TOTAL_DOL";

                columnas[6] = "NROCAJAS";
                columnas[7] = "NROETIQUETAS";

                Util.AddGridSummarySum(Grid, columnas);

        }
        private void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Spu_Fact_Trae_VentasContabilidad> lista;
            string mesinicial = "", mesfinal = "";

            mesinicial = Util.convertiracadena(cbomesini.SelectedValue);
            mesfinal = Util.convertiracadena(cbomesfin.SelectedValue);
            lista = VentaDocumentoLogic.Instance.TraeVentasContabilidad(Logueo.CodigoEmpresa, Logueo.Anio, mesinicial, mesfinal);
            gridControl.DataSource = lista;
            Cursor.Current = Cursors.Default;
        }
        private void frmRepVentasArchivoPlano_Load(object sender, EventArgs e)
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
