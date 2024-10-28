using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

namespace Fac.UI.Win
{
    public partial class frmRepConsultaxcliente : frmBaseReporte
    {
        #region "Instancia"
        private static frmRepConsultaxcliente _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepConsultaxcliente Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepConsultaxcliente(formParent);
            _aForm = new frmRepConsultaxcliente(formParent);
            return _aForm;
        }
        #endregion
        public frmRepConsultaxcliente(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            
        }

        private void CrearColumnas()
        {
            RadGridView Grid = CreateGrid(this.gridControl);
                CreateGridColumn(Grid, "FAC01COD", "FAC01COD", 0, "", 70, true, false, false);
                CreateGridColumn(Grid, "Tipo Documento", "FAC01DESC", 0, "", 120);
                CreateGridColumn(Grid, "FAC03COD", "FAC03COD", 0, "", 150, true, false, false);
                CreateGridColumn(Grid, "Plantilla", "FAC03DESC", 0, "", 150, true, false, false);
                CreateGridColumn(Grid, "Cliente", "ClienteNombre", 0, "", 120);
                CreateGridColumn(Grid, "Fecha", "FAC04FECHA", 0, "{0:dd/MM/yyyy}", 80);
                CreateGridColumn(Grid, "Numero", "FAC04NUMDOC", 0, "", 90);
                CreateGridColumn(Grid, "Mone", "FAC04MONEDA", 0, "", 70);
            
                CreateGridColumn(Grid, "Subtotal S/", "SubtotalSoles", 0, "{0:###,###0.00}", 90, true, false, true, "right");
                CreateGridColumn(Grid, "Igv S/", "IgvSoles", 0, "{0:###,###0.00}", 90, true, false, true, "right");
                CreateGridColumn(Grid, "Total S/", "totalSoles", 0, "{0:###,###0.00}", 90, true, false, true, "right");

                CreateGridColumn(Grid, "Subtotal US$ ", "SubtotalDolares", 0, "{0:###,###0.00}", 90, true, false, true, "right");
                CreateGridColumn(Grid, "Igv US$", "IgvDolares", 0, "{0:###,###0.00}", 90, true, false, true, "right");
                CreateGridColumn(Grid, "total US$", "totalDolares", 0, "{0:###,###0.00}", 90, true, false, true, "right");

                CreateGridColumn(Grid, "Guias", "FAC04GUIAS", 0, "{0:###,###0.00}", 90, true, false, true, "right");
                CreateGridColumn(Grid, "Estado", "DocumentoEstado", 0, "{0:###,###0.00}", 90, true, false, true, "right");

                AgregarBotonesaGrilla(Grid, "btnVerDetalle", "VerDetalle");


            string[] camposSumatorio = new string[6];
            camposSumatorio[0] = "SubtotalSoles";
            camposSumatorio[1] = "IgvSoles";
            camposSumatorio[2] = "totalSoles";
            camposSumatorio[3] = "SubtotalDolares";
            camposSumatorio[4] = "IgvDolares";
            camposSumatorio[5] = "totalDolares";

            Util.AddGridSummarySum(Grid, camposSumatorio);
 
        }
        private void Cargar()
        {
            try
            {
                string fechaInicio = dtpFechaInicio.Value.ToShortDateString();
                string fechaFin = dtpFechaFin.Value.ToShortDateString();

                string empresa = Logueo.CodigoEmpresa;
                string tipoOpcion = "", tipoAnalisis = "", codigoCliente = "";
                tipoAnalisis = txtTipoAnalisisCodigo.Text.Trim();
                codigoCliente = txtClienteCodigo.Text.Trim();

                if (rbRangoFecha.CheckState == CheckState.Checked)
                {
                    tipoOpcion = "R";
                }
                else if (rbHistorico.CheckState == CheckState.Checked)
                {
                    tipoOpcion = "H";
                }

                List<DocumentoVentasEmitido> lista = VentaDocumentoLogic.Instance.TraeDocumentosVentaEmitido(Logueo.CodigoEmpresa, 
                                                                    fechaInicio, fechaFin,tipoOpcion, tipoAnalisis, codigoCliente);
                gridControl.DataSource = lista;                
            }
            catch (SqlException exSql)
            {
                Util.ShowError("Error al cargar datos , detalle: " + exSql.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar datos, detalle : " + ex.Message);
            }
        }
        //enmFactCab_TipoAnalisis
        //enmFactCab_Cliente
        private void frmRepConsultaxcliente_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            VerBotones(BaseRegBotones.cbbVista);
            Cursor.Current = Cursors.WaitCursor;

            rbRangoFecha.CheckState = CheckState.Checked;
            rbHistorico.CheckState = CheckState.Unchecked;
            HabilitarPorOpcion("R");

            DateTime fechaActual = DateTime.Now;
            DateTime primerDiaMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

            dtpFechaInicio.Value = primerDiaMes;
            dtpFechaFin.Value = ultimoDiaMes;
                        
            CrearColumnas();
            Cargar();

            txtTipoAnalisisCodigo.Text = "01";
            string codigoGlobal = Logueo.CodigoEmpresa + txtTipoAnalisisCodigo.Text.Trim();
            string nombreSalida = "";
            GlobalLogic.Instance.DameDescripcion(codigoGlobal, "TIPOANALISIS", out nombreSalida);
            txtTipoAnalisisDescripcion.Text = nombreSalida;

            Util.ResaltarAyuda(txtClienteCodigo);
            Util.ResaltarAyuda(txtTipoAnalisisCodigo);
            Cursor.Current = Cursors.Default;                    
        }
        private void DeshabilitarControles()
        {
            dtpFechaFin.Enabled = false;
            dtpFechaInicio.Enabled = false;
            txtTipoAnalisisCodigo.Enabled = false;
            txtClienteCodigo.Enabled = false;
            
        }
        private void TraerAyuda(enmAyuda tipo)
        {
            frmBusqueda frm;
            string parametro1 = "";
            object variables;
            string[] datos;
            switch (tipo)
            {
                case enmAyuda.enmFactCab_Cliente:
                    //parametro1 = txtClienteCodigo.Text.Trim();
                    variables = txtTipoAnalisisCodigo.Text.Trim();
                    frm = new frmBusqueda(tipo, variables);
                    frm.ShowDialog();
                    if(frm.Result == null) { return;}
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtClienteCodigo.Text = datos[0].Trim();
                    txtClienteDescripcion.Text = datos[1].Trim();
                    break;

                case enmAyuda.enmFactCab_TipoAnalisis:
                    
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if(frm.Result == null) { return;}
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtTipoAnalisisCodigo.Text = datos[0].Trim();
                    txtTipoAnalisisDescripcion.Text =  datos[1].Trim();                    
                    break;

                default:
                    break;
            }
        }
        private void txtTipoAnalisisCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmFactCab_TipoAnalisis);
            }
        }

        private void txtClienteCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmFactCab_Cliente);
            }
        }
        private void HabilitarPorOpcion(string tipoBusqueda)
        {
            DeshabilitarControles();
            if (tipoBusqueda == "R") //Rango de fecha
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFin.Enabled = true;
            }
            else if(tipoBusqueda == "H"){  // historico
                txtTipoAnalisisCodigo.Enabled = true;
                txtClienteCodigo.Enabled = true;                
            }
        }
        private void rbRangoFecha_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            HabilitarPorOpcion("R");
        }

        private void rbHistorico_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            HabilitarPorOpcion("H");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        private void VerDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string codigoTipoDocumento = "";
                string numeroDocumento = "";
                string codigoPlantilla = "";

                DataTable datosFactura = new DataTable();
                Reporte reporte = new Reporte("Documento");
                GridViewRowInfo fila = this.gridControl.CurrentRow;

                codigoTipoDocumento = Util.GetCurrentCellText(fila, "FAC01COD");
                numeroDocumento = Util.GetCurrentCellText(fila, "FAC04NUMDOC");
                codigoPlantilla = Util.GetCurrentCellText(fila,"FAC03COD");
                datosFactura = VentaDocumentoLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa, codigoTipoDocumento, numeroDocumento);
                reporte.Ruta = Logueo.GetRutaReporte();
                switch (codigoTipoDocumento) 
                {
                    case "01":
                        reporte.Nombre = "RptFactura.rpt";
                        break;
                    case "03":
                        reporte.Nombre = "RptBoleta.rpt";
                        break;
                    case "07":
                        reporte.Nombre = "RptNotaCredito.rpt";
                        break;
                    case "08":
                        reporte.Nombre = "RptNotaDebito.rpt";
                        break;
                    default: break;
                }
                
                //reporte.FormulasFields.Add(new Formula("Empresa", logueo.nombrempresa));
                //reporte.FormulasFields.Add(new Formula("titulo", "Analisis de ventas"));
                reporte.DataSource = datosFactura;
                
                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (SqlException exSQL)
            {
                Util.ShowError("Error en base de datos, detalle : " + exSQL.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error en aplicacion, detalle : " + ex.Message);
            }

            Cursor.Current = Cursors.Default;
            
        }
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            VerDetalle();
        }
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string tipoDocumento = "", numeroDocumento = "";

                string[] registros = new string[this.gridControl.SelectedRows.Count];

                int contador = 0;
                foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                {
                    tipoDocumento = Util.GetCurrentCellText(fila, "FAC01COD");
                    numeroDocumento = Util.GetCurrentCellText(fila, "FAC04NUMDOC");

                    registros[contador] = tipoDocumento + "|" + numeroDocumento;
                    contador++;
                }
                string xml = Util.ConvertiraXMLdinamico(registros);

                string fechaInicio = "", fechaFin = "", tipoAnalisis = "", codigoCliente = "";

                fechaInicio = dtpFechaInicio.Value.ToShortDateString();
                fechaFin = dtpFechaFin.Value.ToShortDateString();
                tipoAnalisis = txtTipoAnalisisCodigo.Text.Trim();
                codigoCliente = txtClienteCodigo.Text.Trim();

                Reporte reporte = new Reporte("Documento");
                DataTable dt = new DataTable();
                dt = VentaDocumentoLogic.Instance.TraeReporteDocumentosVenta(Logueo.CodigoEmpresa, xml);
                
                
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptAnalisisVentas.rpt";
                reporte.FormulasFields.Add(new Formula("Empresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("titulo", "Analisis de ventas"));

                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al ver reporte de analisis de ventana, detalle :" + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {

                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                HabilitarBotonVerDetalle(cellElement);
            }

        }

        private void AgregarBotonesaGrilla(RadGridView grilla, 
            string nombreBoton, string textoCabeceraBoton)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = nombreBoton;
            cmdbtn.HeaderText = textoCabeceraBoton;
            grilla.Columns.Add(cmdbtn);
            grilla.Columns[nombreBoton].Width = 30;
        }
        private void HabilitarBotonVerDetalle(GridCommandCellElement CommandCell)
        { 
            GridCommandCellElement cellElement = CommandCell;
            cellElement.CommandButton.Image = Properties.Resources.verdetalle_enabled;
            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
            cellElement.CommandButton.Enabled = true;
        }
        private void VerDetalleDocumento()
        {
            try
            {
                VerDetalle();
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro9r al ver detalle de documento , detalle : " + ex.Message);
            }
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            
            if (this.gridControl.Columns["btnVerDetalle"].IsCurrent)
            {
                VerDetalleDocumento();
            }
        }

        
    }
}
