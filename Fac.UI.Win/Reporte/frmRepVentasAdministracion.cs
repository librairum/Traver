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

namespace Fac.UI.Win
{
    public partial class frmRepVentasAdministracion : frmBaseReporte
    {

        #region "Instancia"
        private static frmRepVentasAdministracion _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepVentasAdministracion Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepVentasAdministracion(formParent);
            _aForm = new frmRepVentasAdministracion(formParent);
            return _aForm;
        }
        #endregion
        public frmRepVentasAdministracion(frmMDI padre)
        {
            InitializeComponent();
        }
        protected override void OnVista()
        {
            //VerReporteReportingServices();
        }
        public frmRepVentasAdministracion()
        {
            InitializeComponent();
        }

        private void traerAyuda(enmAyuda tipo)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                frmBusqueda frm;    
                string[] datos;
                switch (tipo)
                {
                    case enmAyuda.enmFactCab_SubPlantilla:
                        frm = new frmBusqueda(tipo, txtTipoCodigo.Text.Trim());
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtPlantillaCodigo.Text = datos[0];
                        txtPlantillaDescripcion.Text = datos[1];
                        break;
                    case enmAyuda.enmBuscaTipDoc:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                        if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                        datos = frm.Result.ToString().Split('|');
                        txtTipoCodigo.Text = datos[0];
                        txtTipoDescripcion.Text = datos[1];
                        break;
                }
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda");
            }
            Cursor.Current = Cursors.Default;
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGrid(this.gridControl);
            gridControl.ShowRowHeaderColumn = true;
            gridControl.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            CreateGridColumn(Grid, "Fecha", "Fecha", 0, "{0:dd/MM/yyyy}", 70, true, false, true);
            CreateGridColumn(Grid, "N.Fact", "NumeroDocumento", 0, "", 100, true, false, true);
            CreateGridColumn(Grid, "Cliente", "ClienteNombre", 0, "", 250, true, false, true);
            CreateGridColumn(Grid, "MT2oTM", "CantidadMT2oTM", 0, "{0:###,###0.00}", 100, true, false, true, "right");
            CreateGridColumn(Grid, "Otro Moneda", "ValorOtrasMonedas", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(Grid, "US$", "ValorVentaDol", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            CreateGridColumn(Grid, "T.C", "TipCambio", 0, "", 70, true, false, true, "right");
            CreateGridColumn(Grid, "S/.", "ValorVentaSol", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            CreateGridColumn(Grid, "Otro.UniMed", "CantidadOtrasUniMed", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(Grid, "NºCajas", "NROCAJAS", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(Grid, "N°ETIQUETAS", "NroEtiquetas", 0, "", 90, true, false, true, "right");
            CreateGridColumn(Grid, "Destino", "PAIS_DESTINO", 0, "", 150, true, false, true);
            CreateGridColumn(Grid, "Condicion Pago", "CONDICION_PAGO", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "Nº Ord.Compra", "NRO_ORDENCOMPRA", 0, "", 120, true, false, true);
            //Nro de Liquidacion
            
            CreateGridColumn(Grid, "N° De Liquid", "NroLiquidacion", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "Guias", "GuiaNroCabecera", 0, "", 90, true, false, true);

            CreateGridColumn(Grid, "Fecha", "GuiaFecha", 0, "{0:dd/MM/yyyy}", 90, true, false, true, "right");
            CreateGridColumn(Grid, "N° de Guia", "GuiaNro", 0, "", 120, true, false, true);
            CreateGridColumn(Grid, "M2", "GuiaCantidad", 0, "{0:###,###0.00}", 70, true, false, true, "right");

            CreateGridColumn(Grid, "MT2", "PlantaMT2", 0, "{0:###,###0.00}", 70, true, false, true, "right");

            CreateGridColumn(Grid, "MT2", "Diferencia", 0, "{0:###,###0.00}", 70, true, false, true, "right");

            CreateGridColumn(Grid, "Baldosas", "CantidadBaldosasMT2", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(Grid, "Mosaicos", "CantidadMosaicosMT2", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(Grid, "Planchas", "CantidadPlanchasMT2", 0, "{0:###,###0.00}", 90, true, false, true, "right");

            CreateGridColumn(Grid, "Escalla Planta", "CantidadEscallaPlantaTM", 0, "{0:###,###0.00}", 120, true, false, true, "right");
            CreateGridColumn(Grid, "Escalla Cantera", "CantidadEscallaCanteraTM", 0, "{0:###,###0.00}", 120, true, false, true, "right");
            CreateGridColumn(Grid, "Polvo Travertino", "CantidadPolvoTM", 0, "{0:###,###0.00}", 120, true, false, true, "right");

            CreateGridColumn(Grid, "Otros", "otros", 0, "", 120, true, false, true);
            CreateGridColumn(Grid, "Observacion", "observacion", 0, "", 120, true, false, true);

            CreateGridColumn(Grid, "Vendedor", "VendedorDesc", 0, "", 120, true, false, true);

            string[] columnas = new string[16];
            columnas[0] = "CantidadMT2oTM";
            columnas[1] = "ValorVentaDol";
            columnas[2] = "ValorVentaSol";
            columnas[3] = "CantidadOtrasUniMed";
            columnas[4] = "NROCAJAS";
            columnas[5] = "NroEtiquetas";
            columnas[6] = "GuiaCantidad";
            columnas[7] = "PlantaMT2";
            columnas[8] = "Diferencia";
            columnas[9] = "CantidadBaldosasMT2";
            columnas[10] = "CantidadMosaicosMT2";
            columnas[11] = "CantidadPlanchasMT2";
            columnas[12] = "CantidadEscallaPlantaTM";
            columnas[13] = "CantidadEscallaCanteraTM";
            columnas[14] = "CantidadPolvoTM";
            columnas[15] = "ValorOtrasMonedas";

            Util.AddGridSummarySum(Grid, columnas);
        }
        
        ColumnGroupsViewDefinition columnGroupsView;
        private void CrearGruposxPlantilla(string codigoPlantilla)
        {
            try
            {
                switch (codigoPlantilla)
                { 
                    case "01":
                        this.columnGroupsView = new ColumnGroupsViewDefinition();
                        this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
                        this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Fecha"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["NumeroDocumento"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["ClienteNombre"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CantidadMT2oTM"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["ValorOtrasMonedas"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["ValorVentaDol"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["TipCambio"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["ValorVentaSol"]);
                        this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CantidadOtrasUniMed"]);
                        break;

                    case "02":

                        break;

                    case "03":

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                Util.ShowError("Error al crear grupo por plantilla, detalle: " + ex.Message);
            }
        }
        
        private void CrearGrupos()
        {
            int indiceGrupo = 0;
            try
            {
                indiceGrupo = 0;
                this.columnGroupsView = new ColumnGroupsViewDefinition();
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["Fecha"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["NumeroDocumento"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["ClienteNombre"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadMT2oTM"]);
                // nueva columnas
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["ValorOtrasMonedas"]);
                /* */
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["ValorVentaDol"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["TipCambio"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["ValorVentaSol"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadOtrasUniMed"]);

                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["NROCAJAS"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["NroEtiquetas"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["PAIS_DESTINO"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CONDICION_PAGO"]);

                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["NRO_ORDENCOMPRA"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["NroLiquidacion"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["GuiaNroCabecera"]);

                indiceGrupo = 1;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Guia"));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["GuiaFecha"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["GuiaNro"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["GuiaCantidad"]);

                indiceGrupo = 2;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Planta"));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["PlantaMT2"]);

                indiceGrupo = 3;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Diferencia"));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["Diferencia"]);

                indiceGrupo = 4;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("M2 SEGÚN FACTURAS"));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadBaldosasMT2"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadMosaicosMT2"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadPlanchasMT2"]);


                indiceGrupo = 5;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("TM SEGÚN FACTURAS"));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadEscallaPlantaTM"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadEscallaCanteraTM"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadPolvoTM"]);

                indiceGrupo = 6;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["otros"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["observacion"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["VendedorDesc"]);

                this.gridControl.ViewDefinition = columnGroupsView;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agrupar columnas de rerpote, detalle:" + ex.Message);
            }
        }
        private void txtTipoCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                traerAyuda(enmAyuda.enmBuscaTipDoc);
                this.gridControl.Rows.Clear();
                txtPlantillaCodigo.Text = "";
                txtPlantillaDescripcion.Text = "";
                //TraerDatosPlantillaxDefecto(txtTipoCodigo.Text.Trim());
            }            
        }

        private void txtPlantillaCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                traerAyuda(enmAyuda.enmFactCab_SubPlantilla);
                if (txtPlantillaCodigo.Text != "")
                {
                    
                    if (txtTipoCodigo.Text.Trim() == "01") // Factura
                    {
                        if (txtPlantillaCodigo.Text.Trim() == "01")  //Factura por exportacion de travertinos
                        {
                            VerColumnasxPlantilla("01"); // 01 -> Factura Exportacion
                        }
                        else if (txtPlantillaCodigo.Text.Trim() == "06")
                        {
                            VerColumnasxPlantilla("03"); // 03 Factura nacional subprodcutos
                        }
                        else if (txtPlantillaCodigo.Text.Trim() != "01" && txtPlantillaCodigo.Text.Trim() != "06")
                        {
                            VerColumnasxPlantilla("02"); // 02 Factura  nacional o boleta nacional
                        }
                        else {
                            VerColumnasxPlantilla("04"); // Plantilla General Ventas administracion
                        }
                    }
                    else if (txtTipoCodigo.Text.Trim() == "03") // Boleta
                    {
                        VerColumnasxPlantilla("02");// 02 Factura nacion o boleta nacional
                    }
                    else {
                        //Para otros documentos no factura ni boleta trae
                        VerColumnasxPlantilla("04"); // Plantilla General Ventas administracion
                    }
                }
            }
        }

        private void Cargar()
        {
            try
            {
                string tipoDocumento = txtTipoCodigo.Text.Trim();
                string plantillaDocumento = txtPlantillaCodigo.Text.Trim();
                if (tipoDocumento != "" || plantillaDocumento != "")
                {
                    this.gridControl.DataSource = VentaDocumentoLogic.Instance.TraeVentasAdministracion(Logueo.CodigoEmpresa,
                                    Logueo.Anio, Logueo.Mes, tipoDocumento, plantillaDocumento);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar reporte, detalle : " + ex.Message);
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
        private void frmRepVentasAdministracion_Load(object sender, EventArgs e)
        {
            OcultarBarraBotones();
            CrearColumnas();                       
            CrearGrupos();

            Util.ResaltarAyuda(txtTipoCodigo);
            Util.ResaltarAyuda(txtPlantillaCodigo);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cargar();
            Cursor.Current = Cursors.Default;
        }

        private void btnCopiarTodo_Click(object sender, EventArgs e)
        {
            SeleccionarTodoFilas();
        }
      
        //OLCULTAR COLUMNAS  SEGUN TIPO DE PLANTILLA
        private void VerColumnasxPlantilla(string codigoPlantilla)
        {


            this.gridControl.Columns["NroEtiquetas"].IsVisible = true;
            this.gridControl.Columns["NroLiquidacion"].IsVisible = true;
            this.gridControl.Columns["NROCAJAS"].IsVisible = true;
            this.gridControl.Columns["PAIS_DESTINO"].IsVisible = true;
            this.gridControl.Columns["CONDICION_PAGO"].IsVisible = true;

            this.gridControl.Columns["CantidadEscallaPlantaTM"].IsVisible = true;
            this.gridControl.Columns["CantidadEscallaCanteraTM"].IsVisible = true;
            this.gridControl.Columns["CantidadPolvoTM"].IsVisible = true;


            this.gridControl.Columns["CantidadBaldosasMT2"].IsVisible = true;
            this.gridControl.Columns["CantidadMosaicosMT2"].IsVisible = true;
            this.gridControl.Columns["CantidadPlanchasMT2"].IsVisible = true;
            
            try
            {
                
                switch (codigoPlantilla)
                {
                    //01 Factura exportacion
                    case "01": 
                        this.gridControl.Columns["NroLiquidacion"].IsVisible = false;

                        this.gridControl.Columns["CantidadEscallaPlantaTM"].IsVisible = false;
                        this.gridControl.Columns["CantidadEscallaCanteraTM"].IsVisible = false;
                        this.gridControl.Columns["CantidadPolvoTM"].IsVisible = false;
                        break;

                    //02 Factura o boleta 
                    case "02":
                        
                        this.gridControl.Columns["NROCAJAS"].IsVisible = false;
                        this.gridControl.Columns["NroEtiquetas"].IsVisible = false;
                        this.gridControl.Columns["PAIS_DESTINO"].IsVisible = false;
                        
                    
                        this.gridControl.Columns["CantidadEscallaPlantaTM"].IsVisible = false;
                        this.gridControl.Columns["CantidadEscallaCanteraTM"].IsVisible = false;
                        this.gridControl.Columns["CantidadPolvoTM"].IsVisible = false;

                        break;

                    //03 Factura nacional subproductos
                    case "03":

                        this.gridControl.Columns["NROCAJAS"].IsVisible = false;
                        this.gridControl.Columns["NroEtiquetas"].IsVisible = false;
                        this.gridControl.Columns["PAIS_DESTINO"].IsVisible = false;
                        
                        
                        this.gridControl.Columns["CantidadBaldosasMT2"].IsVisible = false;
                        this.gridControl.Columns["CantidadMosaicosMT2"].IsVisible = false;
                        this.gridControl.Columns["CantidadPlanchasMT2"].IsVisible = false;
                            break;

                    default:

                            break;
                }
                
                
            }
            catch (Exception ex) {
                Util.ShowError("Error al crear columnas por plantilla, detalle:" + ex.Message);
            }
        }
        #region "Ver reporte"
        private void VerReporte()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();
                Reporte reporte = new Reporte("Documento");
                dt = VentaDocumentoLogic.Instance.TraeRepVentasAdministracion(Logueo.CodigoEmpresa,
                                    Logueo.Anio, Logueo.Mes, txtTipoCodigo.Text.Trim(),
                                     txtPlantillaCodigo.Text.Trim());
                reporte.Ruta = Logueo.GetRutaReporte();
                string nombreReporte = "", titulo = "";
                
                if (txtTipoCodigo.Text.Trim() == "01") // Factura
                {
                    if (txtPlantillaCodigo.Text.Trim() == "01")  //Factura por exportacion de travertinos
                    {
                        nombreReporte = "RptVentasExportacion.rpt"; // 01 -> Factura Exportacion
                        titulo = "Venta de Exportacion";
                    }
                    else if (txtPlantillaCodigo.Text.Trim() == "06")
                    {
                        nombreReporte = "RptVentasSubProductos.rpt"; // 03 Factura nacional subprodcutos
                        titulo = "Venta de SubProducto Nacional";
                    }
                    else if (txtPlantillaCodigo.Text.Trim() == "02")
                    {
                        nombreReporte = "RptVentasNacional.rpt"; // 02 Factura  nacional o boleta nacional
                        titulo = "Ventas Nacionales";
                    }
                    else {
                        //No Disponible
                        Util.ShowMessage("Esta plantilla no tiene un reporte disponible en vista previa", 1);
                        return;
                        //nombreReporte = "RptVentasAdministracion.rpt";
                        //titulo = "Ventas General";
                    }
                }
                else if (txtTipoCodigo.Text.Trim() == "03") // Boleta
                {
                    nombreReporte = "RptVentasNacional.rpt";// 02 Factura nacion o boleta nacional
                    titulo = "Ventas Nacionales";
                }
                else {
                    Util.ShowMessage("Esta plantilla no tiene un reporte disponible en vista previa", 1);
                    return;
                    //nombreReporte = "RptVentasAdministracion.rpt";
                    //titulo = "Ventas General";
                }
                string subtitulo = "";
                subtitulo = "DEL " + Logueo.Mes + " AL " + Logueo.Mes;
                reporte.Nombre = nombreReporte;
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("titulo", titulo));                
                reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
                reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

                reporte.DataSource = dt;
                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al ver reporte, detalle : " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
       
        #endregion

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            VerReporte();
        }
    }
}
