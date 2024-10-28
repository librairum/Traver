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
using System.Linq;
using Telerik.WinControls.UI.Docking;
namespace Inv.UI.Win
{
    public partial class frmRepInvPermanenteValo : frmBaseReporte
    {
        public frmRepInvPermanenteValo()
        {
            InitializeComponent();

            
        }
        public string naturalezAlmacen = "";
        public static frmRepInvPermanenteValo formulario;
        private frmMDI FrmParent { get; set; }
        private static frmRepInvPermanenteValo _aForm;
        public static frmRepInvPermanenteValo Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmRepInvPermanenteValo(mdiPrincipal);
            _aForm = new frmRepInvPermanenteValo(mdiPrincipal);
            return _aForm;
        }
        private void CargarPeriodos(RadDropDownList cbo)
        {
            try
            {

                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa, Logueo.Anio);
                cbo.DataSource = periodo;
                cbo.DisplayMember = "ccb03des";
                cbo.ValueMember = "ccb03cod";
                string anio = "";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();

                cbo.SelectedValue = anio + mes;
            }


            catch (Exception)
            {

                throw;
            }
        }

        public static frmRepInvPermanenteValo Instancia()
        {
            return _aForm;
        }
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a, cancelar_a, expmovi_a, importar_MP;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;

        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbExportarMovimientos;
        public frmRepInvPermanenteValo(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            
        }
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a,
                                                                    out editar_a, out eliminar_a, out ver_a, out imprimir_a,
                                                                     out refrescar_a, out importar_a, out vista_a,
                                                                    out guardar_a, out cancelar_a, out expmovi_a, out importar_MP);
        }
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ver_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = vista_a ? ElementVisibility.Visible :
                                                                 ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = imprimir_a ? ElementVisibility.Visible :
                                                                      ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = refrescar_a ? ElementVisibility.Visible :
                                                                        ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = importar_a ? ElementVisibility.Visible :
                                                                      ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible :
                                                                    ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible :
                                                                        ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "nuevo":

                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "editar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "grabar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "cancelar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
            }

        }

        //void cargarPermisos()
        //{
        //    bool Nuevo, Editar, Eliminar, Ver, Imprimir, Refresh;
        //    if (SegMenuPorPerfilLogic.Instance.Trae_OpcionesPorPerfil(Logueo.codigoPerfil, "frmRepInvPermanenteValo") != null)
        //    {
        //        string variable = SegMenuPorPerfilLogic.Instance.Trae_OpcionesPorPerfil(Logueo.codigoPerfil, "frmRepInvPermanenteValo").opcxmenu;
        //        Nuevo = (variable.Substring(0, 1).CompareTo("1") == 0);
        //        Editar = (variable.Substring(1, 1).CompareTo("1") == 0);
        //        Eliminar = (variable.Substring(2, 1).CompareTo("1") == 0);
        //        Ver = (variable.Substring(4, 1).CompareTo("1") == 0);
        //        Refresh = (variable.Substring(6, 1).CompareTo("1") == 0);
              
        //    }

        //}
        private void Crearcolumnas()
        {
            RadGridView grilla =  this.CreateGrid(this.gridControl);
            this.CreateGridColumn(grilla, "Codigo", "in09PRODNATURALEZA", 0, "", 180, true, false, true);
            this.CreateGridColumn(grilla, "Naturaleza ", "NaturalezaDesc", 0, "", 150, true, false, true);
            this.CreateGridColumn(grilla, "Cod", "in09codigo", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "in09descripcion", 0, "", 240, true, false, true);
            //this.CreateGridColumn(grilla, "Color.", "color", 0, "", 85, true, false, true);
            //this.CreateGridColumn(grilla, "Tonalidad", "tonalidad", 0, "", 85, true, false, true);
            //this.CreateGridColumn(grilla, "Formato", "formato", 0, "", 85, true, false, true);
            //this.CreateGridColumn(grilla, "Acabado", "acabado", 0, "", 85, true, false, true);
            //this.CreateGridColumn(grilla, "Relleno", "relleno", 0, "", 85, true, false, true);
            //this.CreateGridColumn(grilla, "Borde", "borde", 0, "", 85, true, false, true);
            //this.CreateGridColumn(grilla, "Modelo", "modelo", 0, "", 100, true, false, true);            
        }
        
        protected override void OnRefrescar()
        {
            OnBuscar();
        }
        public void listar() {
            var lista = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa, Logueo.Anio,"03");
            this.gridControl.DataSource = lista;
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            DataTable lista = ArticuloLogic.Instance.Trae_AlmacenesLibLegal(Logueo.CodigoEmpresa);
            //Agregar SP GRILLA 

            this.gridControl.DataSource = lista;
        }
        
       
      
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.CurrentRow.Index;
            //OnCargar();
            OnBuscar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        //protected override void OnEliminar()
        //{
        //    if (this.gridControl.RowCount == 0)
        //        return;

        //    try
        //    {
        //        double CanMovimientos = 0;
        //        string codigoArticulo = this.gridControl.CurrentRow.Cells["IN01KEY"].Value.ToString();
        //        ArticuloLogic.Instance.TraerMovimientoxArticulo(Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo, out CanMovimientos);
        //        if (CanMovimientos > 0)
        //        {
        //            RadMessageBox.Show("No se puede eliminar un articulo que tiene movimientos", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
        //            return;
        //        }
        //        DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, 
        //                                                  MessageBoxButtons.YesNo, RadMessageIcon.Question);
        //        if (result == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            string msgRetorno = string.Empty;
        //            string codigoarticulo = string.Empty;
        //            codigoarticulo = this.gridControl.CurrentRow.Cells["IN01KEY"].Value.ToString();

        //            Articulo articulo = new Articulo();
        //            articulo.IN01CODEMP=Logueo.CodigoEmpresa;
        //            articulo.IN01AA=Logueo.Anio;
        //            articulo.IN01KEY = codigoarticulo;
                  
        //            ArticuloLogic.Instance.ArticuloEliminar(articulo,"N",Logueo.Mes,out msgRetorno);
        //            RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
        //            enfocaRegistroAnterior();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, 
        //                            MessageBoxButtons.OK, RadMessageIcon.Info);
        //    }


        //}

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.IsLoaded) {
                if (gridControl.RowCount > 0) {
                    if (e.Row.Cells["IN01KEY"].Value != null) {
                        //OnVer();
                    }
                }
            }
        }

        private void frmRepInvPermanenteValo_Load(object sender, EventArgs e)
        {
            Crearcolumnas();
            OnBuscar();
            CargarPeriodos(cboperiodos);
            rbRegistroInv121.Enabled = false;
            rbRegistroInv121.IsChecked = false;
            rbRegistroInv131.IsChecked = true;
            HabilitarBotones(true, false, false, true, true);
            //OcultarBotones();
            //HabilitaBotonPorNombre(BaseRegBotones.cbbVista);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbExportar);

               //HabilitaBotonPorNombre(BaseRegBotones.cbbExportar);
               //HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
               //HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
        }
        private string TraerXmlAlmcenes() {
            string xml = "";
            try
            {
                int cantidadFilasSeleccionadas = gridControl.SelectedRows.Count;
           
                string[] codigoSeleccionados = new string[cantidadFilasSeleccionadas];
                int x = 0;
                foreach (GridViewRowInfo filaSeleccionada in this.gridControl.SelectedRows) {
                      string codigoAlmacen = Util.GetCurrentCellText(filaSeleccionada, "in09codigo");
                      codigoSeleccionados[x] = codigoAlmacen;
                  
                    x++;
                }
                xml = Util.ConvertiraXMLdinamico(codigoSeleccionados);
            }
            catch (Exception ex)
            {

                Util.ShowError("Error al traer almacenes: " + ex.Message);
            }
            return xml;
        }

        protected override void OnVista()
        {
            //armar xml de almacenes seleccionados

            //Reporte reporte = new Reporte("RptInvRegisValorizado.rpt");
            Reporte reporte = new Reporte("RptKardexElectronico_reducido.rpt");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            //reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("TituloReporte", "Reporte Inventario permanente Valorizado"));
            reporte.FormulasFields.Add(new Formula("RUC","20420310383"));
            reporte.FormulasFields.Add(new Formula("Ano", cboperiodos.Text ));
            string CodAlmacen = Util.GetCurrentCellText(gridControl,"in09codigo");
            string xml = TraerXmlAlmcenes();
            //DataTable dt = PeriodoLogic.Instance.Traer_Rep_Kardex_Electronico(Logueo.CodigoEmpresa, Logueo.Anio, cboperiodos.SelectedValue.ToString(), CodAlmacen,"","","P","S");
            DataTable dt =  PeriodoLogic.Instance.Traer_Rep_Kardex_Electronico(Logueo.CodigoEmpresa,
                Logueo.Anio, cboperiodos.SelectedValue.ToString(), "TO", "P", xml);

            reporte.DataSource = dt;

            ReporteControladora controles = new ReporteControladora(reporte);
            
            //reporte.FormulasFields.Add(new Formula("Ano", Logueo.Anio + cboperiodos.SelectedValue.ToString()));
            controles.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
        protected override void OnSeleccionarTodo()
        {
            try
            {
                gridControl.SelectAll();
            }
            catch(Exception ex)
            {
                Util.ShowError("ERROR");
            }

        }
       
        protected override void OnExportar()
        {
            int x = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbDetalle = new StringBuilder();
                #region "Consultar datos"

                string Mes = cboperiodos.SelectedValue.ToString();
                string[] seleccionado = cboperiodos.SelectedItem.ToString().Split(' ');
                string Anio = seleccionado[1];
                string codigoalmacen = Util.GetCurrentCellText(gridControl.CurrentRow, "in09codigo");
                // DataTable dtRow = PeriodoLogic.Instance.Traer_Rep_Kardex_Electronico(Logueo.CodigoEmpresa,Anio,Mes,"02","","","P","S");
                //DataTable dtRow = PeriodoLogic.Instance.Traer_Rep_Kardex_Electronico(Logueo.CodigoEmpresa, Logueo.Anio, Mes, codigoalmacen, "", "", "P", "S");
                string xml = TraerXmlAlmcenes();
                DataTable dtRow = PeriodoLogic.Instance.Traer_Rep_Kardex_Electronico(Logueo.CodigoEmpresa, Logueo.Anio, Mes, "TO", "P",xml);
                #region "Detalle"

                string fila18, fila20, fila21, fila24;
               
                foreach (DataRow filaDetalle in dtRow.Rows)
                {
                    //asignar valor por defecto de cero a campos 
                    //fila18 = (filaDetalle[18].ToString() == "0") ? "0.00" : filaDetalle[18].ToString();
                    //fila20 = (filaDetalle[20].ToString() == "0") ? "0.00" : filaDetalle[20].ToString();
                    //fila21 = (filaDetalle[21].ToString() == "0") ? "0.00" : filaDetalle[21].ToString();
                    //fila24 = (filaDetalle[24].ToString() == "0") ? "0.00" : filaDetalle[24].ToString();
                    //string periodo_1 = "", codigoEstablecimiento_2 = "", 
                    //    codigoCatalogo_3 = "",
                    //    tipoExistencia_4 = "", codigoExistencia_5 = "";

                    //string fechaEmisionDocumento_6 = "", tipoDocumento_7 = "",
                    //    numeroSerieDocumento_8 = "", numeroDocumento_9 = "";
                    //string tipoOperacion_10 = "", descripcionExistencia_11="";
                    //string codigoUnidadMedida_12 = "", codigoMetodoValuaExistencia_13 = "";
                    //string cantidadUndIngreso_14 = "", costoUniIngreso_15 = "";
                    //string cantidadUniSalida_16 = "", costoUniSalida_17 = "";
                    //string cantidadUniSaldoFinal_18 = "", costoUniSaldoFinal_19 = "";
                    //string estadoOperacion_20 = "";

                    string campo1_Periodo="", campo2_CodUnicoOperacion = "" , campo3_NroCorrelativo="", campo4_CodEstablecimiento="";
                    string campo5_CodCatalogoUtilizado="", campo6_TipoExistencia="", campo7_CodPropioExistencia="", campo8_CodCatalogo="";
                    string campo9_CodExistencia="", campo10_FechaEmision="", campo11_TipoDocumentoTraslado="", campo12_NroSerieDocTraslado="",
                            campo13_NroDocumentoTraslado="", campo14_TipOperacionEfectuada="", campo15_DescripcionExistencia="",
                            campo16_CodUnidadMedida="", campo17_CodigoMetodValuacion="";
                    string campo18_CantUnidadING,campo19_CostoUnitarioING="",campo20_CostoTotalING="";
                    string campo21CantidadUndSAL="",campo22_CostoUndSAL="",campo23_CostoTotalSAL="";
                    string campo24_CantidadUndFINAL="", campo25_CostoUndSaldoFinal="", campo26_CostoTotalSaldoFinal="";
                    string campo27_IndicacionEstadoOperacion="";
                    campo1_Periodo = filaDetalle[0].ToString();
                    campo2_CodUnicoOperacion = filaDetalle[1].ToString();
                    campo3_NroCorrelativo = filaDetalle[2].ToString();
                    campo4_CodEstablecimiento = filaDetalle[3].ToString();
                    campo5_CodCatalogoUtilizado = filaDetalle[4].ToString();
                    campo6_TipoExistencia = filaDetalle[5].ToString();
                    campo7_CodPropioExistencia = filaDetalle[6].ToString();
                    campo8_CodCatalogo = filaDetalle[7].ToString();
                    campo9_CodExistencia = filaDetalle[8].ToString();
                    campo10_FechaEmision = filaDetalle[9].ToString();
                    campo11_TipoDocumentoTraslado = filaDetalle[10].ToString();
                    campo12_NroSerieDocTraslado = filaDetalle[11].ToString();
                    campo13_NroDocumentoTraslado = filaDetalle[12].ToString();
                    campo14_TipOperacionEfectuada = filaDetalle[13].ToString();
                    campo15_DescripcionExistencia = filaDetalle[14].ToString();
                    campo16_CodUnidadMedida = filaDetalle[15].ToString();
                    campo17_CodigoMetodValuacion = filaDetalle[16].ToString();
                    campo18_CantUnidadING = filaDetalle[17].ToString();
                    campo19_CostoUnitarioING = filaDetalle[18].ToString();
                    campo20_CostoTotalING = filaDetalle[19].ToString();
                    campo21CantidadUndSAL = filaDetalle[20].ToString();
                    campo22_CostoUndSAL = filaDetalle[21].ToString();
                    campo23_CostoTotalSAL = filaDetalle[22].ToString();
                    campo24_CantidadUndFINAL = filaDetalle[23].ToString();
                    campo25_CostoUndSaldoFinal = filaDetalle[24].ToString();
                    campo26_CostoTotalSaldoFinal = filaDetalle[25].ToString();
                    campo27_IndicacionEstadoOperacion = filaDetalle[26].ToString();
                    

                    //periodo_1 = filaDetalle[0].ToString();
                    //codigoEstablecimiento_2 =  filaDetalle[3].ToString();
                    //codigoCatalogo_3 = filaDetalle[4].ToString();
                    //tipoExistencia_4 = filaDetalle[5].ToString();
                    //codigoExistencia_5 = filaDetalle[6].ToString();
                    //fechaEmisionDocumento_6 = filaDetalle[9].ToString();
                    //tipoDocumento_7 = filaDetalle[10].ToString();
                    //numeroSerieDocumento_8 = filaDetalle[11].ToString();
                    //numeroDocumento_9 = filaDetalle[12].ToString();
                    //tipoOperacion_10 = filaDetalle[13].ToString();
                    //descripcionExistencia_11 = filaDetalle[14].ToString();
                    //codigoUnidadMedida_12 = filaDetalle[15].ToString();
                    //codigoMetodoValuaExistencia_13 = filaDetalle[16].ToString();
                    //cantidadUndIngreso_14 = filaDetalle[17].ToString();
                    //costoUniIngreso_15 = filaDetalle[18].ToString();
                    //cantidadUniSalida_16 = filaDetalle[20].ToString();
                    //costoUniSalida_17 = filaDetalle[21].ToString();
                    //cantidadUniSaldoFinal_18 = filaDetalle[23].ToString();
                    //costoUniSaldoFinal_19 = filaDetalle[24].ToString();
                    //estadoOperacion_20 = filaDetalle[26].ToString();

                    sbDetalle.AppendLine(campo1_Periodo +"|"+ campo2_CodUnicoOperacion+ "|" + 
                        campo3_NroCorrelativo + "|" + 
                        campo4_CodEstablecimiento + "|" + 
                        campo5_CodCatalogoUtilizado + "|" +
                        campo6_TipoExistencia + "|" + 
                        campo7_CodPropioExistencia + "|" + 
                        campo8_CodCatalogo + "|" + 
                        campo9_CodExistencia + "|" +
                        campo10_FechaEmision + "|" + 
                        campo11_TipoDocumentoTraslado + "|" + 
                        campo12_NroSerieDocTraslado + "|" + 
                        campo13_NroDocumentoTraslado + "|" +
                        campo14_TipOperacionEfectuada + "|" + 
                        campo15_DescripcionExistencia + "|" + 
                        campo16_CodUnidadMedida + "|" + 
                        campo17_CodigoMetodValuacion + "|" +
                        (campo18_CantUnidadING=="0"? "0.00" : campo18_CantUnidadING) + "|" + 
                        (campo19_CostoUnitarioING=="0" ? "0.00" : campo19_CostoUnitarioING) + "|" + 
                        (campo20_CostoTotalING=="0"  ? "0.00" : campo20_CostoTotalING)+"|"+
                        (campo21CantidadUndSAL == "0" ? "0.00" :campo21CantidadUndSAL)+"|"+
                        (campo22_CostoUndSAL=="0" ? "0.00" : campo22_CostoUndSAL)+ "|" +
                        (campo23_CostoTotalSAL=="0" ? "0.00" : campo23_CostoTotalSAL)+ "|"+
                        (campo24_CantidadUndFINAL=="0" ? "0.00" : campo24_CantidadUndFINAL) + "|"+
                        (campo25_CostoUndSaldoFinal=="0" ? "0.00" : campo25_CostoUndSaldoFinal) + "|"+
                        (campo26_CostoTotalSaldoFinal =="0"?"0.00": campo26_CostoTotalSaldoFinal)+ "|" +
                        (campo27_IndicacionEstadoOperacion =="0" ? "0.00" : campo27_IndicacionEstadoOperacion)+
                        "|"+"\n");

                    x++;
                }
                #endregion


                #endregion

                Cursor.Current = Cursors.Default;

                //string rutaBase = @"C:\Users\iatan\Documents\Exportacion\Suministro";

                string rutaBase = "";
                FolderBrowserDialog diag = new FolderBrowserDialog();
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string folder = diag.SelectedPath;  //selected folder path
                    rutaBase = folder;

                    //Nombredelibro = 
                    string prefijo = "LE";
                    string rucempresa = "20420310383";
                    string anio = Logueo.Anio;
                    string mes = cboperiodos.SelectedValue.ToString();
                    string dias = "00";
                    string identificadorLibro = "130100";
                    string codigoOportunidadEEFF = "00";
                    string indicadorOperacion = "1"; // empresa privada
                    string indicadorContenido = "1"; //Indicador del contenido del libro o registro = 1->Si tiene registro , 0-> no tiene registros
                    string indicadorMoneda = "1"; //indica el tipo de moneda utilizada 1-> soles , 2 -> doalres
                    string indicadorPLE = "1";
                                                                                //LERRRRRRRRRRRAAAAMM0013010000O1M1.TXT
                    string nombreArchivo = prefijo + rucempresa + anio + mes + dias + identificadorLibro + 
                                            codigoOportunidadEEFF + indicadorOperacion + 
                                            indicadorContenido + indicadorMoneda+indicadorPLE;

                    //LE RRRRRRRRRRR AAAA MM 00 130100 00 O I M 1.TXT                    
                    //LE 20420310383 2023 01 00 130100 00 1 1 1 1.txt
                    //LE 20420310383 2024 07 00 130100 00 1 1 1 1
                    //LE RRRRRRRRRRR AAAA MM 00 130100 00 O I M 1.TXT
                    System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, nombreArchivo + ".txt"), sbDetalle.ToString().Replace(Environment.NewLine, ""), Encoding.Default);
                    //System.IO.File.WriteAllText(System.IO.Path.Combine(rutaBase, "LE2042031038320230100130100001111" + ".txt"), sbDetalle.ToString().Replace(Environment.NewLine, ""), Encoding.Default);

                    Util.ShowMessage("Exportacion exitosa", 1);
                }
                else return;

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar exportacion de movimiento o el archivo esta siendo usado : " + ex.Message + " Fila error:" + x.ToString());
            }
        }
        

 

    }

}
