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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Inv.UI.Win
{
    public partial class frmUbicacionFisica : frmBaseReg
    {
        private bool isLoaded = false;
        private bool isOpened = false;
        private string _tipoDocumento = string.Empty;
        private string _nroDocumento = string.Empty;

        private enmAyuda _tipoAyuda;

        private string _codigoAlmacenSeleccionado = string.Empty;
        private string _PedidoVentaSeleccionado = string.Empty;
        private frmMDI FrmParent { get; set; }
        private static frmUbicacionFisica _aForm;
        public static frmUbicacionFisica Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmUbicacionFisica(mdiPrincipal);
            _aForm = new frmUbicacionFisica(mdiPrincipal);
            return _aForm;
        }

        public frmUbicacionFisica(frmMDI padre)
        {
            InitializeComponent();
            
            CrearColumnas();
            FrmParent = padre;
            HabilitarBotones(true, true, true, true,false);

        }
        //public frmUbicacionFisica()
        //{
        //    InitializeComponent();
        //    CrearColumnas();
        //}

        public frmUbicacionFisica(string tipoDocumento, string nroDocumento)
        {
            InitializeComponent();
            CrearColumnas();
        }

        private void frmUbicacionFisica_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
           isLoaded = true;
            this.CargarUbicacionFisica();
            isLoaded = true;

            HabilitarBotones(true, true, true, true, false);
            Cursor.Current = Cursors.Default;
        }
        
        private void CrearColumnas()
        {
            RadGridView grilla = this.CreateGridVista(this.gridControl);
            //this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            // Datos del pedido de venta cuando es ingreso
            this.CreateGridColumn(grilla, "Fecha", "IN07FECHA", 0, "{0:dd/MM/yyyy}", 185, true, false, true);
            this.CreateGridColumn(grilla, "Caja Nro", "in07nrocaja", 0, "", 190, true, false, true);
            this.CreateGridColumn(grilla, "Ubicacion Fisica", "in07ubicacion", 0, "", 100, false, true, true);
            
            // Suma del Area
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "in07nrocaja";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Count;
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);
            grilla.SummaryRowsBottom.Add(summaryRowItem);
            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

            //Crear columnas de detalles de ubicacion
            RadGridView grillaProductos = this.CreateGridVista(this.gridDetalles);
            this.CreateGridColumn(grillaProductos, "NroCaja", "in07nrocaja", 0, "", 80);            
            this.CreateGridColumn(grillaProductos, "Codigo", "IN01KEY", 0, "", 150, true, false, false);
            this.CreateGridColumn(grillaProductos, "Descripcion", "IN01DESLAR", 0, "", 250);
            this.CreateGridColumn(grillaProductos, "Uni.Med", "in07unimed", 0, "", 70);
            this.CreateGridColumn(grillaProductos, "Cant.Piezas", "StockReal", 0, "{0:###,###0.00}", 70, true, false, true, true);
            this.CreateGridColumn(grillaProductos, "Area M²", "StockRealArea", 0, "{0:###,###0.00}", 70, true, false, true, true);

            this.CreateGridColumn(grillaProductos, "Ancho", "IN07ANCHO", 0, "{0:###,###0.00}", 70, true, false, true, true);
            this.CreateGridColumn(grillaProductos, "largo", "IN07LARGO", 0, "{0:###,###0.00}", 70, true, false, true, true);
            this.CreateGridColumn(grillaProductos, "Alto", "IN07ALTO", 0, "{0:###,###0.00}", 70, true, false, true, true);            
            this.CreateGridColumn(grillaProductos, "Observaciones", "in07observacion", 0, "", 100);
        }

        private void CargarProductosxNroCaja() {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.gridControl.Rows.Count == 0) return;
                string[] seleccionados = new string[this.gridControl.SelectedRows.Count];
                int x = 0;
                for (int i = 0; i < this.gridControl.SelectedRows.Count; i++)
                {
                    seleccionados[x] = this.gridControl.SelectedRows[i].Cells["in07nrocaja"].Value.ToString();                                        
                    x++;
                }
                var productos = DocumentoLogic.Instance.TraerProductosxNroCaja(Logueo.CodigoEmpresa ,Util.ConvertiraXML(seleccionados));
                this.gridDetalles.DataSource = productos;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) { 
            
            }
           
            //var productosxNroCaja = DocumentoLogic.Instance.TraerProductosxNroCaja(
            
        }
        private void CargarUbicacionFisica()
        {
            try
            {
                var UbicacionFisica = DocumentoLogic.Instance.TraerUbicacionFisica(Logueo.CodigoEmpresa);
                this.gridControl.DataSource = UbicacionFisica;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnVista()
        {
            if (this.gridControl.Rows.Count == 0) return;
            string[] seleccionados = new string[this.gridControl.SelectedRows.Count];
            int x = 0;
            for (int i = 0; i < this.gridControl.SelectedRows.Count; i++)
            {
                seleccionados[x] = this.gridControl.SelectedRows[i].Cells["in07nrocaja"].Value.ToString();
                x++;
            }
            Cursor.Current = Cursors.WaitCursor;

            var productos = DocumentoLogic.Instance.Reporte_ProductosNroCaja(Logueo.CodigoEmpresa, Util.ConvertiraXML(seleccionados));
            //ranfecini = this.cbomesini.SelectedValue.ToString().Substring(0, 2);
            //ranfecfin = this.cbomesfin.SelectedValue.ToString().Substring(0, 2);


            frmBaseReporte frmReporte = new frmBaseReporte();
            //frmReporte.SubTitulo = "Reporte Productos por Nro de Cajas";
            
            Reporte reporte = new Reporte("Documento");
            
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptProductosxNroCaja.rpt";
            reporte.DataSource = productos;

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));            
            reporte.FormulasFields.Add(new Formula("titulo", "Reporte Productos por Nro de Cajas"));
            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

            Cursor.Current = Cursors.Default;
        }

        private void frmUbicacionFisica_Activated(object sender, EventArgs e)
        {
            //Ubica el mouse en TextBox Tipo de documento
            if (this.Estado == FormEstate.New && !isOpened)
                SendKeys.Send("{TAB}");
            isOpened = true;
        }
        private void gridControl_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Value == null)
                return;
            try
            {

                if (e.Column.Name.CompareTo("in07ubicacion") == 0)
                {
                    this.GuardarDetalle(this.gridControl.CurrentRow);
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }

        private void GuardarDetalle(GridViewRowInfo info)
        {
            try
            {
                UbicacionFisica ubifis = new UbicacionFisica();

                ubifis.IN07CODEMP = Logueo.CodigoEmpresa;
                ubifis.IN07UBICACION = info.Cells["IN07UBICACION"].Value.ToString();
                ubifis.IN07NROCAJA = info.Cells["IN07NROCAJA"].Value.ToString();
                ubifis.IN07USUARIO = Logueo.UserName;

                string mensajeRetorno = string.Empty;
                string flagok = string.Empty;

                DocumentoLogic.Instance.UbicacionFisicaActualizar(ubifis, out flagok, out mensajeRetorno);

                if (flagok == "-1")
                {
                    RadMessageBox.Show("Actualizar Ubicacion fisica", mensajeRetorno, MessageBoxButtons.OK, RadMessageIcon.Info);
                }

            }
            //RadMessageBox.Show("Grabar Nuevo Registro", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            catch (Exception)
            {

                throw;
            }
        }

        private void radCommandBar1_Click(object sender, EventArgs e)
        {

        }
        protected override void OnVer()
        {
           
        }
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            //if (e.CurrentRow.Cells["IN07NROCAJA"] != null)
            //{
            //    CargarProductosxNroCaja();
            //} 
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            CargarProductosxNroCaja();
        }

        private void gridControl_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            gridControl.ClearSelection();
        }

      

        
    }
}
