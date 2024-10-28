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
    public partial class FrmValorizado : frmBaseReporte
    {


        public static frmTransaccionVentana formulario;

        private frmMDI FrmParent { get; set; }
        private static FrmValorizado _aForm;
        public static FrmValorizado Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmValorizado(mdiPrincipal);
            _aForm = new FrmValorizado(mdiPrincipal);
            return _aForm;
        }

        private bool isLoaded = false;
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a;
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

        public FrmValorizado(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
                        
        }
        public FrmValorizado() 
        {
            InitializeComponent();
        }
        protected override void OnVista()
        {
           
                try
                {

                    //Insertar XML PARA FILTRO Stock Valorizado

                    if (gridControl.SelectedRows.Count == 0)
                    {
                        Util.ShowError("VALIDAR :: Es necesario seleccionar los registros para visualizar el Reporte");
                        return;
                    }
                    Reporte reporte;
                    //Empresa
                    //usuario
                    //VALORI
                    //VALOR DEL PRODUCTO
                    
                       string almacen = this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);
                       if (almacen == "TO") { gridControl.SelectAll(); }
                       string[] registros = new string[this.gridControl.SelectedRows.Count];
                       int x = 0;
                       foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                       {

                           registros[x] = Logueo.CodigoEmpresa + "|" +
                                          Logueo.UserName + "|" + 
                                          "VALORI" + "|" +
                                          Util.GetCurrentCellText(fila, "IN04KEY");

                           x++;
                       }

                       string XML = Util.ConvertiraXMLdinamico(registros);
                       DataTable lista = AlmacenLogic.Instance.Traer_StockValorizado(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, almacen, XML, "carla", "S");

                       if (chktipoArti.Checked == true)
                       {
                            reporte = new Reporte("RptSqlValorizacion_TipoArt.rpt");
                       }
                       else 
                       {
                            reporte = new Reporte("RptSqlValorizacion.rpt");
                       }
                    //Si selecciona "TODOS" que me habra el reporte con todos los almacenes
           
                  
                    reporte.Ruta = Logueo.GetRutaReporte();
                    reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                    reporte.FormulasFields.Add(new Formula("NombreMes", Logueo.Mes));
                    reporte.FormulasFields.Add(new Formula("NombreMoneda", "S"));

                    reporte.DataSource = lista;
                    ReporteControladora controles = new ReporteControladora(reporte);
                    controles.VistaPrevia(enmWindowState.Normal);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Util.ShowError("ERROR ==> " + ex.Message);
                }
          
        }
        private void FrmValorizado_Load(object sender, EventArgs e)
        {

                 Crearcolumnas();
                 CargarCombo();
                 Cargar();
                 double TipoCambio;
                  DateTime fechaactual = DateTime.Now;
                 string fechaFormateada = fechaactual.ToString("dd/MM/yyyy");
                 Compra_Traer_TipoCambioLogic.Instance.TipoCambioTraer(fechaFormateada, out TipoCambio);
                 //Convert.ToDouble(Logueo.TipoCambio).ToString();
                 txtTipoCambio.Text = Convert.ToDouble(TipoCambio).ToString();
                 //HabilitarBotones(false, false, false, false, false, true);
                 //cboalmacenes.ZoomGesture

        }
        public void Cargar() 
        {
            try 
            {
                string almacen = this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);
                DataTable dt = ArticuloLogic.Instance.TraerArticulo_Valorizado(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, almacen.ToString(), "in04KEY", "");
              gridControl.DataSource = dt;
            }catch(Exception ex)
            {
                Util.ShowError("ERROR"+ex.ToString());
            }
        }
        public void CargarCombo() 
        {
            try 
            {
                string comboTODOS = "TODOS";
                var ListaAlmacen = AlmacenLogic.Instance.TraerAlmacen(Logueo.CodigoEmpresa,
                           "0401");   
                //------------------------------------/------------------------------------------------
               Almacen TODOAlmacen = new Almacen
               {
                   in09codigo = "TO",
                   in09descripcion = "TODOS"
               };
               ListaAlmacen.Add(TODOAlmacen);

               cboalmacenes.DataSource = ListaAlmacen;
               cboalmacenes.DisplayMember = "in09descripcion";
               cboalmacenes.ValueMember = "in09codigo";

            }catch(Exception ex)
            {
                Util.ShowError("ERROR:: CargarCombo"+ex.ToString());
            }
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        //protected override void OnNuevo()
        //{
        //    this.Estado = FormEstate.New;
        //    Habilitar(true);
        //    Limpiar();
        //    //this.txtcodigo.Focus();
        //    //deshabilito botones nuevo ,editar,eliminar habilito guardar cancelar
        //   // HabilitarBotones(false, false, false, true, true, false);
        //    //habilitarBotones(false,true);
        //}
        //protected override void OnCancelar()
        //{
        //    Habilitar(false);
        //    //habilito botones nuevo ,editar,eliminar deshabilito guardar cancelar
        //    //this.cargarPermisos(this.Name);
        //    //HabilitarBotones(true, true, true, false, false, false);
        //}
        //protected override void OnEditar()
        //{
        //    this.Estado = FormEstate.Edit;
        //    Habilitar(true);
        //    //Deshabilito los valores que no se pueden modificar
        //    //txtcodigo.Enabled = false;
        //    //deshabilito botones nuevo ,editar,eliminar habilito guardar cancelar
        //    //HabilitarBotones(false, false, false, true, true, false);
        //    //habilitarBotones(false,true);
        //}
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
        //        DialogResult result = RadMessageBox.Show("Está seguro de eliminar",
        //            Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
        //            MessageBoxButtons.YesNo, RadMessageIcon.Question);
        //        if (result == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            string msgRetorno = string.Empty;
        //            string codigotipodocumento = string.Empty;
        //            codigotipodocumento = this.gridControl.CurrentRow.Cells["In12tipDoc"].Value.ToString();

        //            TipoDocumento tipodocumento = new TipoDocumento();
        //            tipodocumento.in12codemp = Logueo.CodigoEmpresa;
        //            tipodocumento.In12tipDoc = codigotipodocumento;
        //            //tipodocumento.in12WorStr = OnCargarOpciones(); // Por Mientras


        //            TipoDocumentoLogic.Instance.TipoDocumentoEliminar(tipodocumento, out msgRetorno);
        //            RadMessageBox.Show(msgRetorno,
        //                Constantes.MensajesGenericos.MSG_TITULO_INFO,
        //                MessageBoxButtons.OK, RadMessageIcon.Info);
        //            enfocaRegistroAnterior();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO,
        //            Constantes.MensajesGenericos.MSG_TITULO_ERROR,
        //            MessageBoxButtons.OK, RadMessageIcon.Info);
        //    }

        //    OnCancelar();
        //}
        //private string OnCargarOpciones()
        //{
        //    string cCadena = "";
        //    cCadena += (chkopcion1.CheckState == CheckState.Checked) ? "1" : "0"; // proveedor
        //    cCadena += (chkopcion2.CheckState == CheckState.Checked) ? "1" : "0"; //Centro costo
        //    cCadena += (chkopcion3.CheckState == CheckState.Checked) ? "1" : "0"; //Responsable de almacen
        //    cCadena += (chkopcion4.CheckState == CheckState.Checked) ? "1" : "0"; //Responsable de recepcion
        //    cCadena += (chkopcion5.CheckState == CheckState.Checked) ? "1" : "0"; //Obra
        //    cCadena += (chkopcion6.CheckState == CheckState.Checked) ? "1" : "0";//Orden de trabajo
        //    cCadena += (chkopcion7.CheckState == CheckState.Checked) ? "1" : "0";//Maquina
        //    cCadena += (chkopcion8.CheckState == CheckState.Checked) ? "1" : "0"; //materia prima
        //    cCadena += (chkopcion9.CheckState == CheckState.Checked) ? "1" : "0"; // lote 
        //    cCadena += (chkopcion10.CheckState == CheckState.Checked) ? "1" : "0"; // cantera
        //    cCadena += (chkopcion11.CheckState == CheckState.Checked) ? "1" : "0"; //contratista
        //    cCadena += (chkopcion12.CheckState == CheckState.Checked) ? "1" : "0"; // nota salida
        //    cCadena += (chkopcion13.CheckState == CheckState.Checked) ? "1" : "0"; //Comprobante Salida Almacen
        //    cCadena += (chkopcion14.CheckState == CheckState.Checked) ? "1" : "0"; // Linea
        //    cCadena += (chkopcion15.CheckState == CheckState.Checked) ? "1" : "0"; // Proceso
        //    cCadena += (chkopcion16.CheckState == CheckState.Checked) ? "1" : "0"; // Turno
        //    cCadena += (chkopcion17.CheckState == CheckState.Checked) ? "1" : "0"; //cliente
        //    return cCadena;
        //}
        //protected override void OnGuardar()
        //{


        //    if (!Validar())
        //        return;
        //    TipoDocumento tipodocumento = new TipoDocumento();
        //    string mensajeRetorno = string.Empty;
        //    string mensajeRetorno1 = string.Empty;
        //    string fechaini = string.Empty;
        //    string tipomovimiento = string.Empty;
        //    try
        //    {

        //        //if (rbtingreso.CheckState == CheckState.Checked)
        //        //{
        //        //    tipomovimiento = "E";
        //        //}
        //        //else
        //        //{
        //        //    tipomovimiento = "S";
        //        //}


        //        //tipodocumento.in12codemp = Logueo.CodigoEmpresa;
        //        //tipodocumento.In12tipDoc = txtcodigo.Text;
        //        //tipodocumento.In12DesLar = txtdescripcion.Text;
        //        //tipodocumento.in12TipMov = tipomovimiento;
        //        //tipodocumento.In12ExigeDevu = (chkExigeDev.CheckState == CheckState.Checked) ? "1" : "0";
        //        //tipodocumento.in12FlagGeneraDocNum = (chkmanual.CheckState == CheckState.Checked) ? "M" : "A";
        //        //tipodocumento.in12WorStr = OnCargarOpciones(); // Por Mientras
        //        //tipodocumento.in12naturaleza = this.txtCodigoNaturaleza.Text.Trim();
        //        //                tipodocumento.in12ca
        //        int cantidadCaracteres = 0;
        //        //if (txtlongitud.Text.Trim() != "")
        //        //{
        //        //    cantidadCaracteres = Convert.ToInt32(txtlongitud.Text);
        //        //}

        //        //tipodocumento.in12longitudDocNum = cantidadCaracteres;
        //        //tipodocumento.in12FlagGeneraAsientoContable = chkAsientoContable.CheckState == CheckState.Checked ? "S" : "N";
        //        //tipodocumento.in12FlagCalCostoPromedio = chkCalculaCosto.CheckState == CheckState.Checked ? "S" : "N";


        //        if (this.Estado == FormEstate.New)
        //        {
        //            //NUEVO
        //            TipoDocumentoLogic.Instance.TipoDocumentoInsertar(tipodocumento, out mensajeRetorno);

        //            RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

        //            OnBuscar();
        //            Habilitar(false);

        //        }
        //        else if (this.Estado == FormEstate.Edit)
        //        {
        //            //Modificar
        //            TipoDocumentoLogic.Instance.TipoDocumentoModificar(tipodocumento, out mensajeRetorno);

        //            RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

        //            OnBuscar();
        //            Habilitar(false);

        //        }
        //        else
        //        {
        //            RadMessageBox.Show("Opcion no validad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
        //            return;
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        RadMessageBox.Show("Ha ocurrido error inesperado al registrar ", "Aviso",
        //            MessageBoxButtons.OK, RadMessageIcon.Error);
        //    }
        //    OnCancelar();
        //    if (Estado == FormEstate.New)
        //    {
        //       // this.OnEnfocarRegistro(true, gridControl, tipodocumento.In12tipDoc, "In12tipDoc");
        //        cbbNuevo.IsMouseOver = true;
        //        cbbNuevo.Focus();
        //    }
        //    else if (Estado == FormEstate.Edit)
        //    {
        //       // this.OnEnfocarRegistro(false, gridControl, tipodocumento.In12tipDoc, "In12tipDoc");
        //    }
        //    this.Estado = FormEstate.List;

        //}
        private bool Validar()
        {
            //cbbGuardar.IsMouseOver = false;

            //if (this.txtcodigo.Text.Trim() == "")
            //{
            //    RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    this.txtcodigo.Focus();
            //    return false;
            //}

            //if (this.txtdescripcion.Text.Trim() == "")
            //{
            //    RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    this.txtdescripcion.Focus();
            //    return false;
            //}

            //if (this.txtCodigoNaturaleza.Text.Trim() == "" || this.txtTipoCambio.Text.Trim() == "???")
            //{
            //    RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    this.txtCodigoNaturaleza.Focus();
            //    return false;
            //}

            return true;
        }
        #region metodosdemantenimineto

        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            //this.txtcodigo.Enabled = valor;
            //this.txtdescripcion.Enabled = valor;
            //this.rbtingreso.Enabled = valor;
            //this.rbtsalida.Enabled = valor;
            ////this.radGroupBox3.Enabled = valor;
            //this.chkExigeDev.Enabled = valor;
            //this.txtCodigoNaturaleza.Enabled = valor;
            //this.txtlongitud.Enabled = valor;
            //this.chkAsientoContable.Enabled = valor;
            //this.chkCalculaCosto.Enabled = valor;
        }

        public void Limpiar()
        {
            //this.txtcodigo.Text = "";
            //this.txtdescripcion.Text = "";
            //this.txtCodigoNaturaleza.Text = "";
            //this.rbtingreso.CheckState = CheckState.Checked;
            //this.txtlongitud.Text = "";
            //this.chkCalculaCosto.CheckState = CheckState.Unchecked;
            //this.chkExigeDev.CheckState = CheckState.Unchecked;
            //this.chkAsientoContable.CheckState = CheckState.Unchecked;

            LimpiarOpciones();

        }
        private void LimpiarOpciones()
        {
            //foreach (Control c in this.radGroupBox3.Controls)
            //{
            //    if (c is RadCheckBox)
            //    {
            //        ((RadCheckBox)c).Checked = false;
            //    }
            //}
        }
        private void CargarRegistro()
        {

            if (this.gridControl.RowCount == 0)
                return;

            string codigo = string.Empty;
            codigo = this.gridControl.CurrentRow.Cells["In12tipDoc"].Value.ToString();


            var tipodocumento = TipoDocumentoLogic.Instance.TraerTipoDocumentoRegistro(Logueo.CodigoEmpresa, codigo);

            if (tipodocumento != null)
            {
                //this.txtcodigo.Text = tipodocumento.In12tipDoc;
                //this.txtdescripcion.Text = tipodocumento.In12DesLar;
                //this.txtCodigoNaturaleza.Text = tipodocumento.in12naturaleza;
                //this.txtlongitud.Text = tipodocumento.in12longitudDocNum.ToString().Trim();
                
                //if (tipodocumento.in12TipMov == "E")
                //{
                //    rbtingreso.CheckState = CheckState.Checked;
                //}
                //else
                //{
                //    rbtsalida.CheckState = CheckState.Checked;
                //}

                //if (tipodocumento.In12ExigeDevu == "1")
                //{
                //    chkExigeDev.CheckState = CheckState.Checked;
                //}
                 
                //else
                //{   
                //    chkExigeDev.CheckState = CheckState.Unchecked;
                //}
                //if (tipodocumento.in12FlagGeneraDocNum == "M")
                //{
                //    chkmanual.CheckState = CheckState.Checked;
                //}
                //else 
                //{
                //    chkmanual.CheckState = CheckState.Unchecked;
                //}
                //if (tipodocumento.in12FlagCalCostoPromedio == "S")
                //{
                //    chkCalculaCosto.CheckState = CheckState.Checked;
                //}
                //else
                //{
                //    chkCalculaCosto.CheckState = CheckState.Unchecked;
                //}

                //if (tipodocumento.in12FlagGeneraAsientoContable == "S")
                //{
                //    chkAsientoContable.CheckState = CheckState.Checked;
                //}
                //else
                //{
                //    chkAsientoContable.CheckState = CheckState.Unchecked;
                //}

                //string miCadena = TipoDocumentoLogic.Instance.DameVariable(Logueo.CodigoEmpresa, tipodocumento.In12tipDoc);

                ////proveedor
                //chkopcion1.CheckState = (LeerEstado(miCadena, 0) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////centro de costo
                //chkopcion2.CheckState = (LeerEstado(miCadena, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////responsable de almacen
                //chkopcion3.CheckState = (LeerEstado(miCadena, 2) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////responsable de recepcion
                //chkopcion4.CheckState = (LeerEstado(miCadena, 3) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////disponible -> obra
                //chkopcion5.CheckState = (LeerEstado(miCadena, 4) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////disponible -> orden de compra / orde de trabajo
                //chkopcion6.CheckState = (LeerEstado(miCadena, 5) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////Maquina
                //chkopcion7.CheckState = (LeerEstado(miCadena, 6) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////materia prima
                //chkopcion8.CheckState = (LeerEstado(miCadena, 7) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////Lote
                //chkopcion9.CheckState = (LeerEstado(miCadena, 8) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////Cantera
                //chkopcion10.CheckState = (LeerEstado(miCadena, 9) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////Contratista
                //chkopcion11.CheckState = (LeerEstado(miCadena, 10) == "1") ? CheckState.Checked : CheckState.Unchecked;

                ////Nota Salida
                //chkopcion12.CheckState = (LeerEstado(miCadena, 11) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////Comprobante salida almacen.
                //chkopcion13.CheckState = (LeerEstado(miCadena, 12) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////linea
                //chkopcion14.CheckState = (LeerEstado(miCadena, 13) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////proceso
                //chkopcion15.CheckState = (LeerEstado(miCadena, 14) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////turno                
                //chkopcion16.CheckState = (LeerEstado(miCadena, 15) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////chkopcion16.CheckState = (miCadena.Substring(15, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                ////cliente
                //chkopcion17.CheckState = (LeerEstado(miCadena, 16) == "1") ? CheckState.Checked : CheckState.Unchecked;


            }
        }
        private string LeerEstado(string cadenaPermisos, int posicionDocumento)
        {
            string resultado;

            try
            {
                resultado = cadenaPermisos.Substring(posicionDocumento, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                resultado = "0";
            }


            return resultado;
        }


        private void Crearcolumnas()
        {

            //this.gridControl.Columns.Clear();
            //this.gridControl.AllowAddNewRow = false;
            //this.gridControl.ShowGroupPanel = false;
            //this.gridControl.ShowFilteringRow = true;
            //this.gridControl.AllowColumnReorder = true;

            //this.gridControl.AutoGenerateColumns = false;
            ////this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            ////this.gridControl.AllowSearchRow = true;
            ////this.gridControl.SearchRowPosition = SystemRowPosition.Top;

            //this.gridControl.EnableHotTracking = true;
            //this.gridControl.ShowFilteringRow = true;
            //this.gridControl.EnableFiltering = true;

            //this.gridControl.MultiSelect = true;
            //RadGridView grilla = this.CreateGridVista(this.gridControl);
            RadGridView Gridcantera = CreateGrid(this.gridControl);
            //gridControl.SelectAll();
            this.CreateGridColumn(Gridcantera, "Codigo", "IN04KEY", 0, "", 70, true, false, true);
            this.CreateGridColumn(Gridcantera, "Descripcion", "IN01DESLAR", 0, "", 350, true, false, true);

            //// Agregar columna boton
            //Telerik.WinControls.UI.GridViewCommandColumn newColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
            //newColumn.HeaderText = "Accion";
            //newColumn.FieldName = "PeriodoEstado";
            //newColumn.Name = "PeriodoEstado";
            //gridControl.MasterTemplate.Columns.Add(newColumn);

        }
        #endregion metodosdemantenimineto
        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["In12tipDoc"].Value != null)
                    {
                        CargarRegistro();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridControl_CurrentRowChanged_1(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["In12tipDoc"].Value != null)
                    {
                        CargarRegistro();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboalmacenes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try 
            {
                string almacen = this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);
                Cargar();
            }catch(Exception ex)
            {
                Util.ShowError("ERROR");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl.SelectAll();

                //foreach(GridViewRowInfo row in gridControl.Rows)
                //{
                //    row.IsSelected = true;

                //    foreach (GridViewCellInfo cell in row.Cells)
                //    {
                //        cell.IsSelected = true;
                //    }
                //}
           

            }
            catch (Exception ex)
            {
                Util.ShowError("ERROR::" + ex.ToString());
            }
        }

        protected override void OnSeleccionarTodo()
        {
            gridControl.SelectAll();
        }





    }
}
