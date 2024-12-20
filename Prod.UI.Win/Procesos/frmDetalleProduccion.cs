﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Prod.UI.Win.Comunes;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
using Inv.BusinessEntities.DTO;
using System.Linq;
using Telerik.WinControls.UI.Docking;
namespace Prod.UI.Win.Procesos
{
    public partial class frmDetalleProduccion : frmBaseReg
    {
        #region "variables"
        public static frmDetalleProduccion DetalleOrden;
        private string codigoDocumento = "";
        private string tipoDocumento = "";
        public string almacenDeProceso = "";
        
        private bool esEntrada = false; 

        private frmProduccion FrmParent { get; set; }
        ColumnGroupsViewDefinition columnGroupsView;        
        private static frmDetalleProduccion _aForm;

        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbEditar;
        public int fila = 0;
        
        #endregion
        #region "Instancias"
        OrdenTrabajo orden = new OrdenTrabajo();
        Documento doc = new Documento();
        Movimiento mov = new Movimiento();
        #endregion
                        
        public static frmDetalleProduccion Instance(frmProduccion mdiPrincipal) 
        {
            if (_aForm != null) return new frmDetalleProduccion(mdiPrincipal);
            _aForm = new frmDetalleProduccion(mdiPrincipal);
            return _aForm;
        }       
        public frmDetalleProduccion(frmProduccion padre)
        {
            InitializeComponent();
            
            FrmParent = padre;
                 
            Control ctrl = FrmParent.ParentForm.Controls.Find("radDock1", true)[0];
            this.pnlHoraMuerta.Visible = false;
            this.pnlHoraMuerta.SendToBack();
            // Panel de Errores Detalle
            this.popupErroresDetalle.Visible = false;
            this.popupErroresDetalle.SendToBack();
            // Panel de resumen
            this.popupResumen.Visible = false;
            this.popupResumen.SendToBack();

            this.popupSaldos.SendToBack();
            Estado = FrmParent.Estado;
            //aplicando estilo al borde del boton  Agregar Orden de Trabajo
            btnAddOT.ButtonElement.BorderElement.BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            btnAddOT.ButtonElement.BorderElement.TopColor = Color.FromArgb(101, 147, 207);
            btnAddOT.ButtonElement.BorderElement.BottomColor = Color.FromArgb(101, 147, 207);
            btnAddOT.ButtonElement.BorderElement.LeftColor = Color.FromArgb(101, 147, 207);
            btnAddOT.ButtonElement.BorderElement.RightColor = Color.FromArgb(101, 147, 207);

            if (Estado == FormEstate.Edit || Estado == FormEstate.List || Estado == FormEstate.View)
            {
                codigoDocumento = FrmParent.gridControl.CurrentRow.Cells["Numero"].Value.ToString();
                tipoDocumento = FrmParent.gridControl.CurrentRow.Cells["CodTipDoc"].Value.ToString();
                fila = FrmParent.gridControl.CurrentRow.Index;
            }
            
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGuardar = menu.Items["cbbGuardar"];
            cbbEditar = menu.Items["cbbEditar"];

            //Identificar si esentrada o salida
            esEntrada = (FrmParent.rbIngreso.IsChecked ? true : false);
            btnAgregaMasivo.Visible = (FrmParent.rbIngreso.IsChecked) ? true : false;

            //construccion de columnas de las grillas
            crearColumnasOrdenTrabajo();
            crearColumnasProductosDet();
            crearGrupos();
            //crearColumnasMateriaPrima();
            CrearColumnasMPResumido();
            CrearColumnasErrores();
            CrearColumnasResumen();
            CrearColumnasSaldos();

            ////Ventana de escalla
            //CrearColumnasEscalla();
            //CrearGruposEscallas();
            ////Ventana de saldo x bloque
            //crearColumnasSaldoxBloque();

            //this.gridEscalla.BeginEditMode = RadGridViewBeginEditMode.BeginEditProgrammatically;
            // ================================================ Asignar configueracion de navegacion . ======================================================
            Util.ConfigGridToEnterNavigation(gridEscalla);
            Util.ConfigGridToEnterNavigation(gridSaldos);
            Util.ConfigGridToEnterNavigation(gridExcel);
                                    
            // ================================================ Enfocar todo al fila de la grilla. ==========================================================
            seleccionatFilaCompleta(gridMateriaPrima);
            seleccionatFilaCompleta(gridControl);
 
            // ================================================ Asigno como formulario padre a frmMDI  =======================================================
            this.MdiParent = FrmParent.ParentForm;

            // ================================================ Enfoco el formulario ==========================================================================
            ((RadDock)(ctrl)).ActivateMdiChild(this);
            removerBordesdepaneles();

            if (FrmParent.Estado == FormEstate.New)
            {
                limpiarCabeceraProduccion();
                limpiarDetalleProduccion();
                BloquearIngresoDatos();
                //habilitarControles(true);                                                                              
                //btnAddOT.Visible = false; // ocultamos los btones de agregar ot
                mostrarControlMateriPrima(FrmParent.rbIngreso.IsChecked);
                
                btnAddOT.Visible = false; // oculto  boton de orden de trabajo
                btnAddMateria.Visible = false; // oculto boton de materia prima

                HabilitarBotones(true, true, false, false, false); // botones de mantenimiento

                this.Estado = FormEstate.New;

                if (txtCodTipoDocumento.Enabled == true)
                { txtCodTipoDocumento.Focus(); }
            }

            else if (FrmParent.Estado == FormEstate.Edit)
            {
                cargarCabeceraDocumento();
                CargarOrdenTrabajo();
                //cargarMateriaPrima();
                CargarMPResumido();
                // Si no tiene OT, cargar todos los productos
                if (gridOrdenTrabajo.Enabled == false)
                {
                    cargarProductosDetTodos();
                }
                                
                ////habilito controles de la cabecera del documento
                //habilitarControles(true);

                //Configuracion
                configurarDocumento(txtCodTipoDocumento.Text.Trim());

                txtCodTipoDocumento.Enabled = false;
                txtCodLinea.Enabled = false;
                txtCodProceso.Enabled = false;

                mostrarControlMateriPrima(FrmParent.rbIngreso.IsChecked); 
                
                //Boton para agregar materia prima 
                btnAddMateria.Enabled = (gridOrdenTrabajo.Rows.Count == 0) ? false : true;
                                                 
                HabilitarBotones(true, true, false, false, false); // botones mantenimiento de detalle de produccion
                                
                this.Estado = FormEstate.Edit;
                btnAdd.Enabled = true;
            }
            else if (FrmParent.Estado == FormEstate.View)
            {

                cargarCabeceraDocumento();
                CargarOrdenTrabajo();
                CargarMPResumido();
                //cargarMateriaPrima();
              
                // Si no tiene OT, cargar todos los productos
                if (gridOrdenTrabajo.Enabled == false)
                {
                    cargarProductosDetTodos();
                }
                               
                habilitarControles(false);
                
                dtpFechaOT.Enabled = false;                
                txtNroDocRespaldo.Enabled = false;
                
                mostrarControlMateriPrima(FrmParent.rbIngreso.IsChecked);


                btnAdd.Visible = false; // boton para agregar producto producido
                btnAddOT.Visible = false; // boton para agregar orden de trabajo
                btnAddMateria.Visible = false;
                
                //Detalle de movimiento
                btnAgregaMasivo.Visible = false; // boton Agrega masivo de movimeinto 
                btnHoraMuerta.Visible = false; // boton Agregar hora muerta en movimiento
                btnInsertarEscalla.Visible = false;// Boton insertar escalle en movimiento                
                btnInsertar.Visible = false; // Boton ingresar detalle de movimiento
                HabilitarBotones(false, true, false, false, true); // botones de mantenimiento
                Estado = FormEstate.View;
                
            }
            
            removerBordesdepaneles();

            // asignar tamaño de ventana resumen
            dimensionarresumen(1257, 400);
            // asingar ubicacion de ventana  resumen
            posicionarresumen(50, 90);

            // =====================================================================================================================================
            // ==================================================== EVENTOS ========================================================================
            // =====================================================================================================================================
            
            //==================================================== Eventos para formulario =========================================================
            this.FormClosing += new FormClosingEventHandler(frmDetalleProduccion_FormClosing);
            //==================================================== Grilla Detalle de documento =====================================================
            this.gridControl.CurrentRowChanged += new CurrentRowChangedEventHandler(gridControl_CurrentRowChanged);
            this.gridControl.GroupSummaryEvaluate += new GroupSummaryEvaluateEventHandler(gridControl_GroupSummaryEvaluate);
            //==================================================== Grilla orden de trabajo =========================================================
            this.gridOrdenTrabajo.CurrentRowChanging += new CurrentRowChangingEventHandler(gridOrdenTrabajo_CurrentRowChanging);
            //====================================================  Grilla resunen =================================================================
            this.gridResumen.ContextMenuOpening += new ContextMenuOpeningEventHandler(gridResumen_ContextMenuOpening);


            //==================================================== Evento para la ventan de Escalla ================================================== 

            //==================================================== Evento para boton de traer Escalla ================================================
            this.btnInsertarEscalla.Click += new EventHandler(btnInsertarEscalla_Click);
            // ==================================================== Eventos para gridEscalla =========================================================
            this.gridEscalla.CellValueChanged += new GridViewCellEventHandler(gridEscalla_CellValueChanged);
            this.gridEscalla.CurrentCellChanged += new CurrentCellChangedEventHandler(gridEscalla_CurrentCellChanged);
            this.gridEscalla.KeyUp += new KeyEventHandler(gridEscalla_KeyUp);

            // ==================================================== Evento para gridExcel   ==========================================================
            this.gridExcel.CurrentCellChanged += new CurrentCellChangedEventHandler(gridExcel_CurrentCellChanged);
            this.gridExcel.KeyUp += new KeyEventHandler(gridExcel_KeyUp);

            // ==================================================== Eventos para gridSaldos ==========================================================
            this.gridSaldos.CurrentCellChanged += new CurrentCellChangedEventHandler(gridSaldos_CurrentCellChanged);
            this.gridSaldos.KeyUp += new KeyEventHandler(gridSaldos_KeyUp);

            // ==================================================== Eventos para gridMateriaPrima ====================================================
            this.gridMateriaPrima.CurrentRowChanging += new CurrentRowChangingEventHandler(gridMateriaPrima_CurrentRowChanging);
            this.gridMateriaPrima.CurrentRowChanged += new CurrentRowChangedEventHandler(gridMateriaPrima_CurrentRowChanged);
            
            //this.gridControl.CurrentCell.
        }

        void gridControl_GroupSummaryEvaluate(object sender, GroupSummaryEvaluationEventArgs e)
        {
            
        }

        void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            //relacionarDetalleconMP();
        }        
        private void gridOrdenTrabajo_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (this.gridOrdenTrabajo.Rows.Count == 0) return;
            
            //-------------------------------------------------VALIDAR MP SIN CONSUMIR----------------------------------------------------------
            string TipdocCodigo = this.txtCodTipoDocumento.Text.Trim();
            string DocuCodigo = this.txtNumeroDoc.Text.Trim();
            
            string OrdenTrabajoCodigo = Util.GetCurrentCellText(gridOrdenTrabajo, "codigo");
            

            string transaccion = esEntrada ? "E" : "S";
            string linea = txtCodLinea.Text.Trim();
            string actividad = txtCodProceso.Text.Trim();
            string mensaje = "";
            int flag = 0;
            if (OrdenTrabajoCodigo == "")
            {
                return;
            }
            DocumentoLogic.Instance.ValidarMPSinConsumir(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, TipdocCodigo,
            DocuCodigo, OrdenTrabajoCodigo, transaccion, linea, actividad, out mensaje, out flag);
            if (flag == -1)
            {
                Util.ShowAlert(mensaje);
                e.Cancel = true;
            }
           
        }

        private void frmDetalleProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            string TipdocCodigo = this.txtCodTipoDocumento.Text.Trim();
            string DocuCodigo = this.txtNumeroDoc.Text.Trim();
            string OrdenTrabajoCodigo = Util.GetCurrentCellText(gridOrdenTrabajo, "codigo");
            string transaccion = esEntrada ? "E" : "S";
            string linea = txtCodLinea.Text.Trim();
            string actividad = txtCodProceso.Text.Trim();
            string mensaje = "";
            int flag = 0;
            DocumentoLogic.Instance.ValidarMPSinConsumir(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, TipdocCodigo,
            DocuCodigo, OrdenTrabajoCodigo, transaccion, linea, actividad, out mensaje, out flag);
            if (flag == -1)
            {
                Util.ShowAlert(mensaje);                
                e.Cancel = true;
            }
        }

        //----------------------------------------------------------------------------METODOS GENERALES -----------------------------------------------------------
        #region "Metodos Generales"
        void seleccionatFilaCompleta(RadGridView Grid)
        {
            Grid.SelectionMode = GridViewSelectionMode.FullRowSelect;
        }        
        private void obtenerDescripcion(enmAyuda tipo)
        {
            string codigo = string.Empty;
            string descripcion = string.Empty;
            switch (tipo)
            {

                case enmAyuda.enmTipoDocumento:
                    codigo = Logueo.CodigoEmpresa + this.txtCodTipoDocumento.Text + Logueo.PP_codnaturaleza + (esEntrada ? "E" : "S");
                    GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOC", out descripcion);
                    txtDesTipoDocumento.Text = descripcion;

                    break;
                case enmAyuda.enmTransaccion:
                    codigo = Logueo.CodigoEmpresa + txtCodDocRespaldo.Text;
                    GlobalLogic.Instance.DameDescripcion(codigo, "TRANSAC", out descripcion);
                    txtDesDocRespaldo.Text = descripcion;
                    break;
                case enmAyuda.enmTurnos:
                    codigo = Logueo.CodigoEmpresa + this.txtCodTurno.Text;
                    GlobalLogic.Instance.DameDescripcion(codigo, "TURNO", out descripcion);
                    txtDesTurno.Text = descripcion;                                                            
                    break;
                case enmAyuda.enmTurnosxDetalle:

                    codigo = Logueo.CodigoEmpresa + Util.convertiracadena(this.gridControl.CurrentRow.Cells["in07prodTurnoCod"].Value);
                    GlobalLogic.Instance.DameDescripcion(codigo, "TURNO", out descripcion);
                    this.gridControl.CurrentRow.Cells["in07prodturnoDesc"].Value = descripcion;
                    break;
                case enmAyuda.enmLinea:
                    codigo = Logueo.CodigoEmpresa + txtCodLinea.Text;
                    GlobalLogic.Instance.DameDescripcion(codigo, "LINEAPROD", out descripcion);
                    txtDesLinea.Text = descripcion;
                    break;
                case enmAyuda.enmActividadNivel1:
                    codigo = Logueo.CodigoEmpresa + this.txtCodLinea.Text.Trim() + this.txtCodProceso.Text.Trim();
                    GlobalLogic.Instance.DameDescripcion(codigo, "ACTIVIDADNIVEL1", out descripcion);
                    txtDesProceso.Text = descripcion;
                    if (txtDesProceso.Text == "???" || txtDesProceso.Text == "" || txtDesProceso.Text.Length == 0)
                    {
                        lblAlmxDefecto.Text = "";
                        return;
                    }
                    else
                    {
                        var alm = ActividadNivel1Logic.Instance.TraerAlmacenxDefecto(Logueo.CodigoEmpresa, txtCodProceso.Text.Trim());
                        lblAlmxDefecto.Text = alm.in09codigo;

                    }

                    break;
                case enmAyuda.enmProductoXAlmacen:

                    break;
                case enmAyuda.enmMaquinaxLineaActividad:
                    codigo = Logueo.CodigoEmpresa + this.txtCodLinea.Text + this.txtCodProceso.Text + this.txtCodigoMaquina.Text.Trim();
                    GlobalLogic.Instance.DameDescripcion(codigo, "MAQUINAPROD", out descripcion);
                    this.txtDescripcionMaquina.Text = descripcion;
                    break;
                case enmAyuda.enmAlmacen:
                    codigo = Logueo.CodigoEmpresa + this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                    GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                    this.gridControl.CurrentRow.Cells["DesAlmacen"].Value = descripcion;
                    break;
                //case enm
            }
        }
        private void obtenerDescripcionIgnMasivo(enmAyuda tipo, string valor)
        {
            string descripcion = "";
            switch (tipo)
            {
                case enmAyuda.enmProductoXAlmacen:

                    string codigoSeleccionado = valor;
                    if (codigoSeleccionado == "") return;
                    this.gridExcel.CurrentRow.Cells["CodigoArticulo"].Value = codigoSeleccionado;

                    Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoSeleccionado);

                    double largonum = articulo.largonum;
                    double Anchonum = articulo.anchonum;
                    double Espesornum = articulo.espesornum;

                    string largotext = articulo.largotext;
                    string Anchotext = articulo.anchotext;
                    string Espesortext = articulo.espesortext;

                    // ================= Largo
                    Util.GetCurrentCell(gridExcel, "Largo").ReadOnly = largotext.ToString().ToUpper() == "ESP" ? true : false;
                    // ================= Ancho
                    Util.GetCurrentCell(gridExcel, "Ancho").ReadOnly = Anchotext.ToString().ToUpper() == "ESP" ? true : false;
                    //=================  Espesor
                    Util.GetCurrentCell(gridExcel, "Alto").ReadOnly = Espesortext.ToString().ToUpper() == "ESP" ? true : false;
                    break;
					case enmAyuda.enmTurnosxDetalle:
                     //in07prodTurnoDesc

                    codigoSeleccionado = Logueo.CodigoEmpresa + Util.convertiracadena(this.gridExcel.CurrentRow.Cells["in07prodTurnoCod"].Value);
                    GlobalLogic.Instance.DameDescripcion(codigoSeleccionado, "TURNO", out descripcion);
                    this.gridExcel.CurrentRow.Cells["in07prodturnoDesc"].Value = descripcion;
                    break;
                default:
                    break;
            }
        }
        private void mostrarAyuda(enmAyuda tipo)
        {
            frmBusqueda frm;
            string codigoSeleccionado = "";
            switch (tipo)
            {
                case enmAyuda.enmTipoDocumento:
                    frm = new frmBusqueda(tipo, (this.esEntrada ? "E" : "S"));
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                            txtCodTipoDocumento.Text = codigoSeleccionado;
                        //obtenerDescripcion(tipo);

                    }
                    break;
                case enmAyuda.enmTransaccion:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "") txtCodDocRespaldo.Text = codigoSeleccionado;                        
                    }
                    break;
                case enmAyuda.enmTurnos:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {                            
                            txtCodTurno.Text = codigoSeleccionado;                  
                            obtenerDescripcion(enmAyuda.enmTurnos);
                        }
                        //if (codigoSeleccionado != "") txtCodTurno.Text = codigoSeleccionado;                  
                    }
                    break;
                case enmAyuda.enmTurnosxDetalle:
                    frm = new frmBusqueda(enmAyuda.enmTurnos);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                    {
                        this.gridControl.CurrentRow.Cells["in07prodTurnoCod"].Value = codigoSeleccionado;
                        obtenerDescripcion(enmAyuda.enmTurnosxDetalle);
                    }
                        
                    break;

                case enmAyuda.enmLinea:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "") txtCodLinea.Text = codigoSeleccionado;
                    }

                    break;

                case enmAyuda.enmActividadNivel1:
                    frm = new frmBusqueda(tipo, txtCodLinea.Text.Trim());
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "") txtCodProceso.Text = codigoSeleccionado;

                        //obtenerDescripcion(tipo);
                        var alm = ActividadNivel1Logic.Instance.TraerAlmacenxDefecto(Logueo.CodigoEmpresa, txtCodProceso.Text.Trim());
                        lblAlmxDefecto.Text = alm.in09codigo;
                    }
                    break;

                case enmAyuda.enmProducObjetivo:
                    frm = new frmBusqueda(tipo, lblAlmxDefecto.Text);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        this.gridOrdenTrabajo.CurrentRow.Cells["codigoProducto"].Value = ((Articulo)frm.Result).IN01KEY;
                        this.gridOrdenTrabajo.CurrentRow.Cells["productoObjetivo"].Value = ((Articulo)frm.Result).IN01DESLAR;
                    }
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    string codigoAlmacen = this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                    //string codAlm = this.gri
                    frm = new frmBusqueda(tipo, codigoAlmacen, null, 1000, 400);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();

                        if (codigoSeleccionado == "") return;
                        string[] separado = codigoSeleccionado.Split('/');
                        string codigoArticulo = separado[0];
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticulo;
                        this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = separado[1];
                        this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = separado[2];
                        Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo);

                        double largonum = articulo.largonum;
                        double Anchonum = articulo.anchonum;
                        double Espesornum = articulo.espesornum;

                        string largotext = articulo.largotext;
                        string Anchotext = articulo.anchotext;
                        string Espesortext = articulo.espesortext;

                        // ================= Largo
                        bool esEditable = largotext.ToString().ToUpper() == "ESP";
                        Util.IsReadOnlyCurrentCell(gridControl, "Largo", esEditable);                        
                        largonum = esEditable == true ? 0 : largonum;
                        Util.SetValueCurrentCellDbl(gridControl, "Largo", largonum);
                        // ================= Ancho
                        esEditable = Anchotext.ToString().ToUpper() == "ESP";
                        Util.IsReadOnlyCurrentCell(gridControl, "Ancho", esEditable);
                        Anchonum = esEditable == true ? 0 : Anchonum;
						Util.SetValueCurrentCellDbl(gridControl, "Ancho", Anchonum);
                        //=================  Espesor
                        esEditable = Espesortext.ToString().ToUpper() == "ESP";
                        Util.IsReadOnlyCurrentCell(gridControl, "Alto", esEditable);
                        Espesornum = esEditable == true ? 0 : Espesornum;
                        Util.SetValueCurrentCellDbl(gridControl, "Alto", Espesornum);
                        this.gridControl.CurrentColumn = this.gridControl.Columns["Largo"];
                        this.gridControl.CurrentRow.Cells["Largo"].BeginEdit();

                    }
                    break;
                case enmAyuda.enmMaquinaxLineaActividad:
                    string lineamaq = txtCodLinea.Text.Trim();
                    string actividadmaq = txtCodProceso.Text.Trim();

                    frm = new frmBusqueda(tipo, lineamaq + actividadmaq);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {
                            this.txtCodigoMaquina.Text = codigoSeleccionado;
                        }
                    }
                    break;

                case enmAyuda.enmCanastillas:
                    Cursor.Current = Cursors.WaitCursor;
                    codigoAlmacen = "";
                    codigoAlmacen = gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                    var proceso = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim());

                    if (codigoAlmacen == "") return;
                    frm = new frmBusqueda(enmAyuda.enmCanastillas, codigoAlmacen);

                    frm.Owner = this;
                    frm.ShowDialog();
                    Cursor.Current = Cursors.Default;
                    if (frm.Result != null && frm.Result.ToString() != "")
                    {
                        TraerMovimientoPP((Spu_Pro_Trae_PPStock)frm.Result);
                    }

                    break;
                case enmAyuda.enmAlmacen:
                    if (esEntrada == true)
                    {
                        //frm = new frmBusqueda(enmAyuda.enmAlmacen);
                        string lineaalm = txtCodLinea.Text.Trim();
                        string actividadalm = txtCodProceso.Text.Trim();

                        frm = new frmBusqueda(enmAyuda.enmAlmacenxlineaxactividad, lineaalm, actividadalm);
                    }
                    else
                    {
                        var actividad = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim());
                        string naturaleza = actividad == null ? Logueo.PP_codnaturaleza : actividad.NATURALEZAALM;
                        frm = new frmBusqueda(enmAyuda.enmAlmacenxNaturaleza, naturaleza);
                    }

                    frm.Owner = this;
                    frm.ShowDialog();

                    if (frm.Result != null)
                    {
                        if (FrmParent.rbIngreso.IsChecked)
                        {
                            //ayuda de almacen para detalle        

                            string almacenSeleccionado = frm.Result.ToString();
                            string almacenAnterior =  Util.convertiracadena(this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value);
                            if (almacenSeleccionado != almacenAnterior) // verifico si el almacen seleccionado es el mismo codigo de almacen con 
                            {                                                           //el almacen de la grilla.
                                this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value = almacenSeleccionado;
                                
                                this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = null;
                                obtenerDescripcion(enmAyuda.enmAlmacen);
                            }

                        }
                        else
                        {
                            this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value = frm.Result.ToString();
                            obtenerDescripcion(enmAyuda.enmAlmacen);
                        }
                    }
                    break;

                case enmAyuda.enmOperador:
                    frm = new frmBusqueda(enmAyuda.enmOperador);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        this.gridControl.CurrentRow.Cells["codigoOperador"].Value = frm.Result.ToString();
                        string codigo = Logueo.CodigoEmpresa + "14" + frm.Result.ToString();
                        string descripcion = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(codigo, "OPERARIO", out descripcion);
                        this.gridControl.CurrentRow.Cells["Operador"].Value = descripcion;
                        this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORAINICIO"];
                        this.gridControl.CurrentRow.Cells["IN07HORAINICIO"].BeginEdit();
                    }
                    break;
                case enmAyuda.enmMotivo:
                    frm = new frmBusqueda(enmAyuda.enmMotivo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();                        
                        this.gridControl.CurrentRow.Cells["IN07MOTIVOCOD"].Value = codigoSeleccionado;                        
                    }
                    break;
                case enmAyuda.enmOrdenTrabajoTipo:
                    frm = new frmBusqueda(enmAyuda.enmOrdenTrabajoTipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        string[] cadena = frm.Result.ToString().Split('|');
                        this.gridOrdenTrabajo.CurrentRow.Cells["CodTipoOT"].Value = cadena[0];
                        this.gridOrdenTrabajo.CurrentRow.Cells["DesTipoOT"].Value = cadena[1];                        
                    }
                    break;                    
            }
        }
        private void configurarDocumento(string codigoTipoDocumento)
        {
            string variable = TipoDocumentoLogic.Instance.DameVariable(Logueo.CodigoEmpresa, codigoTipoDocumento);

            //configura el documento
            if (string.IsNullOrEmpty(variable)) return;
            if (variable.Trim().Length < 16) return;

            //cabecera
            this.txtCodLinea.Enabled = (variable.Substring(13, 1).CompareTo("1") == 0);
            this.txtCodProceso.Enabled = (variable.Substring(14, 1).CompareTo("1") == 0);
            this.txtCodTurno.Enabled = (variable.Substring(15, 1).CompareTo("1") == 0);
            this.txtCodigoMaquina.Enabled = (variable.Substring(6, 1).CompareTo("1") == 0);

            //Panel de Orden trabajo
            rpControlOrden.Enabled = (variable.Substring(5, 1).CompareTo("1") == 0);
            btnAddOT.Visible = rpControlOrden.Enabled ? true : false; // oculto el boton si el control esta inhabilitado
            ////Panel de Materia Prima
            rpControlMateriaPrima.Enabled = variable.Substring(7, 1).CompareTo("1") == 0;

            // oculto boton si el control materia prima esta inhabilitado
            btnAddMateria.Visible = rpControlMateriaPrima.Enabled ? true : false;

            // rpMateria.Enabled = (variable.Substring(7, 1).CompareTo("0") == 0);
            // //Label de Materia Prima
            // radLabel4.Enabled= (variable.Substring(7, 1).CompareTo("0") == 0);
            // //Label de Orden de Trabajo
            // lblnroOT.Enabled = (variable.Substring(7, 1).CompareTo("0") == 0);
            // //boton para agregar materia prima
            // btnAddMateria.Enabled = (variable.Substring(7, 1).CompareTo("0") == 0);
            // //grilla de materia prima.
            // gridMateriaPrima.Enabled = (variable.Substring(7, 1).CompareTo("0") == 0);s



            if (!this.txtCodLinea.Enabled) this.txtCodLinea.Text = string.Empty;
            if (!this.txtCodProceso.Enabled) this.txtCodProceso.Text = string.Empty;
            if (!this.txtCodTurno.Enabled) this.txtCodTurno.Text = string.Empty;
            if (!this.txtCodigoMaquina.Enabled) this.txtCodigoMaquina.Text = string.Empty;

            if (!this.rpControlOrden.Enabled) this.gridOrdenTrabajo.Rows.Clear();
            if (!this.rpControlMateriaPrima.Enabled) this.gridMateriaPrima.Rows.Clear();

        }
        private void cargarCabeceraDocumento()
        {
            Documento resultado = DocumentoLogic.Instance.ObtenerDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipoDocumento, codigoDocumento);
            if (resultado == null) return;

            txtNumeroDoc.Text = resultado.CodigoDoc;
            txtCodTipoDocumento.Text = resultado.TipoDoc;
            dtpFechaOT.Value = (DateTime)resultado.FechaDoc;

            txtCodDocRespaldo.Text = resultado.CodigoTransa;
            doc.Transaccion = resultado.Transaccion;
            txtNroDocRespaldo.Text = resultado.ReferenciaDoc;

            txtCodLinea.Text = resultado.codigoLinea;
            txtCodTurno.Text = resultado.codigoTurno; //campo no usado
            txtCodProceso.Text = resultado.codigoActiNivel1;
            txtCodigoMaquina.Text = resultado.CodigoMaquina;
        }
        private void BloquearIngresoDatos()
        {
            txtCodProceso.Enabled = false;
            txtCodLinea.Enabled = false;
            txtCodTurno.Enabled = false;
            txtCodigoMaquina.Enabled = false;

            rpControlMateriaPrima.Enabled = false;
            rpControlOrden.Enabled = false;
        }
        private void removerBordesdepaneles()
        {
            this.rpDocRespaldo.PanelElement.PanelBorder.TopWidth = 0;
            this.rpMenuDetalle.PanelElement.PanelBorder.TopWidth = 0;
            this.rpProduccionGrilla.PanelElement.PanelBorder.TopWidth = 0;
            this.rpTipoDocumento.PanelElement.PanelBorder.TopWidth = 0;
            this.rpControlMateriaPrima.PanelElement.PanelBorder.Visibility = ElementVisibility.Hidden;
            this.rpDocRespaldo.PanelElement.PanelBorder.Visibility = ElementVisibility.Hidden;
        }
        private void TraerMovimientoPP(Spu_Pro_Trae_PPStock detalle)
        {
            this.gridControl.CurrentRow.Cells["codigoOperador"].Value = detalle.codigoOperador == null ? "" : detalle.codigoOperador;
            this.gridControl.CurrentRow.Cells["NroCaja"].Value = detalle.nrocaja;
            this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = detalle.DocingPT;
            this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = detalle.descripcion;
            this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = detalle.unidadmedida;

            this.gridControl.CurrentRow.Cells["Ancho"].Value = Convert.ToDouble(detalle.Ancho);
            this.gridControl.CurrentRow.Cells["Largo"].Value = Convert.ToDouble(detalle.Largo);
            this.gridControl.CurrentRow.Cells["Alto"].Value = Convert.ToDouble(detalle.Alto);

            this.gridControl.CurrentRow.Cells["Cantidad"].Value = detalle.CanPiezas;

            //Datos del ingreso
            gridControl.CurrentRow.Cells["IN07DocIngAA"].Value = detalle.DocingAA;
            gridControl.CurrentRow.Cells["IN07DocIngMM"].Value = detalle.DocingMM;
            gridControl.CurrentRow.Cells["IN07DocIngTIPDOC"].Value = detalle.DocingTD;
            gridControl.CurrentRow.Cells["IN07DocIngCODDOC"].Value = detalle.DocingCD;
            gridControl.CurrentRow.Cells["IN07DocIngKEY"].Value = detalle.DocingPT;
            gridControl.CurrentRow.Cells["IN07DocIngORDEN"].Value = detalle.DocingNO;

        }
        #endregion
        //----------------------------------------------------------------------------MATERIA PRIMA ---------------------------------------------------------------
        #region "Materia Prima"  
        private void agregarBotonMateriaPrima()
        {
            GridViewCommandColumn colEliminar = new GridViewCommandColumn();
            colEliminar.Name = "btnEliminarMat";
            colEliminar.HeaderText = "";
            gridMateriaPrima.Columns.Add(colEliminar);
            gridMateriaPrima.Columns["btnEliminarMat"].BestFit();
            gridMateriaPrima.Columns["btnEliminarMat"].MinWidth = 30;
        }      
        private void EliminarMateriaPrima()
        {
   
            try
            {
                DialogResult res = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                string cCodigoArticulo = Util.convertiracadena(this.gridMateriaPrima.CurrentRow.Cells["IN07DocIngKEY"].Value);
                if (cCodigoArticulo == "")
                {
                    this.gridMateriaPrima.Rows.RemoveAt(this.gridMateriaPrima.CurrentRow.Index);
                    return;
                }
                if (res == System.Windows.Forms.DialogResult.Yes)
                {

                    string cDocIngKey = this.gridMateriaPrima.CurrentRow.Cells["IN07DocIngKEY"].Value.ToString();

                    
                    string ordenTrabajo = this.gridMateriaPrima.CurrentRow.Cells["IN07ORDENTRABAJO"].Value.ToString();
                    string cNroCaja = this.gridMateriaPrima.CurrentRow.Cells["IN07NROCAJA"].Value.ToString();
                    string cCodAlm = this.gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value.ToString();

                    // Capturo los datos del docuemnto de salida
                    string cDocIngAnio = this.gridMateriaPrima.CurrentRow.Cells["IN07DocIngAA"].Value.ToString();
                    string cDocIngMes = this.gridMateriaPrima.CurrentRow.Cells["IN07DocIngMM"].Value.ToString();
                    string cDocIngTipDoc = this.gridMateriaPrima.CurrentRow.Cells["IN07DocIngTIPDOC"].Value.ToString();
                    string cDocIngCodDoc = this.gridMateriaPrima.CurrentRow.Cells["IN07DocIngCODDOC"].Value.ToString();
                    string cHoraSalida = this.gridMateriaPrima.CurrentRow.Cells["IN07HORASALIDA"].Value.ToString();
                    
                    string msj = string.Empty;
                    int flag = 0;
                    DocumentoLogic.Instance.EliminarSalidaMPResumida(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, cDocIngAnio , 
                            cDocIngMes, cDocIngTipDoc, cDocIngCodDoc, cDocIngKey, ordenTrabajo,cCodAlm, cNroCaja, cHoraSalida, 
                            out flag, out msj);
                     Util.ShowMessage(msj, flag);
                    //RadMessageBox.Show(msj, "..::Mensaje::..", MessageBoxButtons.OK, RadMessageIcon.Info);

                }
            }
            catch (Exception ex)
            {
               RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            //cargarMateriaPrima();
            CargarMPResumido();
            
        }
        private void mostrarControlMateriPrima(bool valor)
        {
            //Panel de todo el boque de Materia prima
            rpControlMateriaPrima.Visible = valor;
            // boton para agregar materia prima
            btnAddMateria.Visible = valor;

            //etiqueta de materia prima y codigo de OT
            radLabel4.Visible = valor;
            lblnroOT.Visible = valor;

            //grilla y panel de Materia Prima           
            gridMateriaPrima.Visible = valor;
        }                        
        #endregion
        //----------------------------------------------------------------------------ORDEN DE TRABAJO-----------------------------------------------------------
        #region "Orden Trabajo"
        void crearColumnasOrdenTrabajo()
        {
            RadGridView grid = CreateGridVista(gridOrdenTrabajo);
            CreateGridColumn(grid, "codigoEmpresa", "codigoEmpresa", 0, "", 50, true, false, false);
            CreateGridColumn(grid, "Codigo", "codigo", 0, "", 70);
            CreateGridColumn(grid, "Cod.Prod", "codigoProducto", 0, "", 90, true, false, false);
            CreateGridColumn(grid, "Descripcion", "productoObjetivo", 0, "", 120);

            CreateGridColumn(grid, "Cod.Tipo", "CodTipoOT", 0, "", 70, true, false, false);
            CreateGridColumn(grid, "Des.Tipo", "DesTipoOT", 0, "", 90, true, false, true);        

            CreateGridColumn(grid, "PRO13DOCINGALMAA", "PRO13DOCINGALMAA", 0, "", 30, true, false, false);
            CreateGridColumn(grid, "PRO13DOCINGALMMM", "PRO13DOCINGALMMM", 0, "", 30, true, false, false);
            CreateGridColumn(grid, "PRO13DOCINGALMTIPDOC", "PRO13DOCINGALMTIPDOC", 0, "", 60, true, false, false);
            
            CreateGridColumn(grid, "OP", "OrigenMP", 0, "", 70, false, true, true);
            CreateGridColumn(grid, "flag", "flag", 0, "", 30, false, true, false);
            
            agregarBotonOrdenTrabajo();
            gridOrdenTrabajo.Columns["btnGrabarOT"].MinWidth = 35;
            gridOrdenTrabajo.Columns["btnCancelarOT"].MinWidth = 35;
            gridOrdenTrabajo.Columns["btnEliminarOT"].MinWidth = 35;
            gridOrdenTrabajo.Columns["btnEditarOT"].MinWidth = 35;
            gridOrdenTrabajo.MultiSelect = false;
        }
        void agregarBotonOrdenTrabajo()
        {
            GridViewCommandColumn colGrabar = new GridViewCommandColumn();
            colGrabar.Name = "btnGrabarOT";
            colGrabar.HeaderText = "";
            gridOrdenTrabajo.Columns.Add(colGrabar);
            gridOrdenTrabajo.Columns["btnGrabarOT"].BestFit();

            GridViewCommandColumn colCancelar = new GridViewCommandColumn();
            colCancelar.Name = "btnCancelarOT";
            colCancelar.HeaderText = "";
            gridOrdenTrabajo.Columns.Add(colCancelar);
            gridOrdenTrabajo.Columns["btnCancelarOT"].BestFit();

            GridViewCommandColumn colEliminar = new GridViewCommandColumn();
            colEliminar.Name = "btnEliminarOT";
            colEliminar.HeaderText = "";
            gridOrdenTrabajo.Columns.Add(colEliminar);
            gridOrdenTrabajo.Columns["btnEliminarOT"].BestFit();

            GridViewCommandColumn colEditar = new GridViewCommandColumn();
            colEditar.Name = "btnEditarOT";
            colEditar.HeaderText = "";
            gridOrdenTrabajo.Columns.Add(colEditar);
            gridOrdenTrabajo.Columns["btnEditarOT"].BestFit();
            
            //this.gridOrdenTrabajo.CommandCellClick += new CommandCellClickEventHandler(gridOrdenTrabajo_CommandCellClick);
        }
      
        void entidadOrdenTrabajo()
        {
            orden.codigoEmpresa = Logueo.CodigoEmpresa;
            orden.codigo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
            orden.codigoProducto = this.gridOrdenTrabajo.CurrentRow.Cells["codigoProducto"].Value.ToString();
            orden.DocuIngresoAlmacenAnio = Logueo.Anio;
            orden.DocuIngresoAlmacenMes = Logueo.Mes;
            orden.DocuIngresoAlmacenTipDoc = txtCodTipoDocumento.Text.Trim();
            orden.DocuIngresoAlmacenCodDoc = txtNumeroDoc.Text.Trim();                        //numero de produccion
            orden.OrigenMP  = this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].Value == null ? "" : this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].Value.ToString();
            
            orden.PRO13LINEACOD = txtCodLinea.Text.Trim();
            orden.PRO13ACTIVIDADNIVELCOD = txtCodProceso.Text.Trim();
            orden.PRO13AA = Logueo.Anio;
            orden.PRO13MM = Logueo.Mes;
            orden.CodTipoOT = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["CodTipoOT"].Value);
            //orden.OrigenMP = this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].Value.ToString(); //--Orden de produccion
        }
        void CargarOrdenTrabajo()
        {
            var lista = OrdenTrabajoLogic.Instance.TraerOrdenTrabajo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                      txtNumeroDoc.Text.Trim(), txtCodTipoDocumento.Text.Trim());
            this.gridOrdenTrabajo.DataSource = lista;
            
        }
        bool ValidarOrdenTrabajo()
        {
            GridViewRowInfo fila = this.gridOrdenTrabajo.CurrentRow;

            string codigo = fila.Cells["codigo"].Value.ToString();
            string producto = fila.Cells["productoObjetivo"].Value == null ? "" : fila.Cells["productoObjetivo"].Value.ToString();

            string OrigenMP = fila.Cells["OrigenMP"].Value == null ? "" : fila.Cells["OrigenMP"].Value.ToString();
            //if (string.IsNullOrEmpty(codigo))
            //{
            //    MessageBox.Show("Error ..:::.. Ingresar producto");
            //    fila.Cells["codigoProducto"].IsSelected = true;
            //    return false;
            //}
            if (string.IsNullOrEmpty(producto))
            {
                RadMessageBox.Show("Ingresar producto", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridOrdenTrabajo.CurrentRow = this.gridOrdenTrabajo.CurrentRow;
                this.gridOrdenTrabajo.CurrentColumn = this.gridControl.Columns["codigoProducto"];
                return false;
            }
            return true;
        }
        void EliminarOrdenTrabajo()
        {
            entidadOrdenTrabajo();
            string mensaje = string.Empty;
            string codigoOrdenTrabajo=  this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
            string nroDoc = txtNumeroDoc.Text.Trim();
            string codTipDoc = txtCodTipoDocumento.Text.Trim();
            var registro = DocumentoLogic.Instance.TraerMateriaPrimaxOT(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codTipDoc,
                                                                         nroDoc, codigoOrdenTrabajo);
                        
            if (registro.Count > 0) {
                RadMessageBox.Show("Esta orden de trabajo tiene materia prima consumida.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            var prodFabricadas  = DocumentoLogic.Instance.TraerProduccionDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codTipDoc, nroDoc, codigoOrdenTrabajo);
            //var prodFabricadas = DocumentoLogic.Instance.TraerTodosDetalleProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
            //                                                                          codTipDoc, nroDoc);
            if (prodFabricadas.Count > 0) {
                RadMessageBox.Show("Esta orden de trabajo tiene productos fabricados.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            
            DialogResult res = RadMessageBox.Show("¿Desea eliminar el OT?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes) {
                OrdenTrabajoLogic.Instance.EliminarOrdenTrabajo(orden, out mensaje);
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }                        

        }
        void GuardarOrdenTrabajo(GridViewRowInfo fila)
        {
            if (!ValidarOrdenTrabajo()) return;
           
            try
            {
                entidadOrdenTrabajo();
                string mensaje = string.Empty;
                int flag = 0;
                if (fila.Cells["flag"].Value.ToString() == "0") // modo insercion o registro una nueva orden de trabajo
                {
                    OrdenTrabajoLogic.Instance.InsertarOrdenTrabajo(orden, out flag, out mensaje);
                }
                else if (fila.Cells["flag"].Value.ToString() == "1") { // es modo edicion de la orden de trabajo
                    OrdenTrabajoLogic.Instance.ActualizarOrdenTrabajo(orden, out flag, out mensaje);
                }

                this.gridOrdenTrabajo.CurrentRow.Cells["flag"].Value = 0; // asingamos valor de celor a nuestro flag - celda solo de lectura.
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);

                CargarOrdenTrabajo(); // refresco la grilla de ordenes de trabajo.
                Util.enfocarFila(gridOrdenTrabajo, "codigo", orden.codigo); // enfocamos al ultimo registro insertado o actualizado.

               string codigoOT = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString(); // obtnemos codigo de orden de trabajo seleccionado.
               var ordenTrabajo =  OrdenTrabajoLogic.Instance.TraerRegistroOT(Logueo.CodigoEmpresa, codigoOT); // validamos si existe al orden de trabajo seleccionado

               if (esEntrada == true)
               {
                   if (ordenTrabajo != null)// si tenemos registros de orden trabajo
                   {
                       btnAddMateria.Visible = true;//activa boton de agregar materia
                   }
                   else
                   {
                       btnAddMateria.Visible = false; //desactiva boton de agregar materia
                   }
               }
               else { //  si es documento de salida
                   if (ordenTrabajo != null) // si existe el orden de trabajo
                   {
                       btnAdd.Visible = true; // mostramos el boton de agregar detalle de producto
                   }
                   else {
                       btnAdd.Visible = false; //ocltamos el boton de agregar detalle de producto
                   }
               }                
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }

        void EditarOrdenTrabajo()
        {
            this.gridOrdenTrabajo.CurrentRow.Cells["flag"].Value = "1";
            this.gridOrdenTrabajo.Focus();
            this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].BeginEdit();
            //Dar foco a la descripcion del producto
            this.gridOrdenTrabajo.CurrentColumn = this.gridOrdenTrabajo.Columns["productoObjetivo"];
            //Resaltar ayuda Color: Amarillo.
            Util.ResaltarAyuda(this.gridOrdenTrabajo.CurrentRow.Cells["productoObjetivo"]);
            //this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].BeginEdit();
            
        }
        #endregion
        //----------------------------------------------------------------------------DETALLE DE DOCUMENTO-----------------------------------------------------------
        #region "Detalle Documento"
        private void ocultarcolumnasxdesdoblado()
        {
            if (txtCodProceso.Text == Logueo.codProcesoDesdoblado)
            {
                this.gridControl.Columns["IN07DESCABEZADOSUP"].IsVisible = true;
                this.gridControl.Columns["IN07DESCABEZADOINF"].IsVisible = true;
            }
            else
            {
                this.gridControl.Columns["IN07DESCABEZADOSUP"].IsVisible = false;
                this.gridControl.Columns["IN07DESCABEZADOINF"].IsVisible = false;
            }
        }

        void crearColumnasProductosDet()
        {

            RadGridView grilla =  this.CreateGridVista(this.gridControl);

            this.CreateGridColumn(grilla, "Codigo", "codigoOperador", 0, "", 50, true, false, false);
            this.CreateGridDateColumn(grilla, "Fecha", "IN07FECHAPROCESO", 0, "{0:dd/MM/yyyy}", 70, false, true);            
            this.CreateGridColumn(grilla, "Operador", "Operador", 0, "", 70, true, false, esEntrada);
            
            // Turno 
            this.CreateGridColumn(grilla, "Turno", "in07prodTurnoCod", 0, "", 90, true, false, false);
            this.CreateGridColumn(grilla, "Turno.Desc.", "in07prodTurnoDesc", 0, "", 50, true, false, true);

            //
            this.CreateGridColumn(grilla, "H.Fin", "IN07HORAFINAL", 0, "", 50, false, true);
            this.CreateGridColumn(grilla, "H.Ini", "IN07HORAINICIO", 0, "", 50, false, true);
            this.CreateGridColumn(grilla, "Cana.Ing", "IN07NROCAJAINGRESO", 0, "", 65, false, true);
            this.CreateGridColumn(grilla, "CajaUnica", "CajaUnica", 0, "", 70, true, false, false);

            this.CreateGridColumn(grilla, "Sup.", "IN07DESCABEZADOSUP", 0, "{0:###,##0}", 30, false, true, true, true, "right");
            this.CreateGridColumn(grilla, "Inf.", "IN07DESCABEZADOINF", 0, "{0:###,##0}", 30, false, true, true, true, "right");

            // Campos ocultos
            this.CreateGridColumn(grilla, "Cod.Bloque", "CodigoBloque", 0, "", 140, false, true,false);
            this.CreateGridColumn(grilla, "CodMaquina", "CodMaquina", 0, "", 140, false, true, false);            
            this.CreateGridColumn(grilla, "Maquina", "DesMaquina", 0, "", 140, false, true, false);
            // Cantidad
            this.CreateGridColumn(grilla, "Cantidad", "Cantidad", 0, "{0:###,###0.00}", 70, false, false, true, true, "right");

            // Datos del producto
            this.CreateGridColumn(grilla, "Cod.Almacén", "CodigoAlmacen", 0, "", 30, false, true, true);
            this.CreateGridColumn(grilla, "Almacén", "DesAlmacen", 0, "", 90); // Descripcion de almacen
            this.CreateGridColumn(grilla, "Código Producto", "CodigoArticulo", 0, "", 30, true, false);            
            
            this.CreateGridColumn(grilla, "Descripción", "DescripcionArticulo", 0, "", 250, true, false, true);           
            this.CreateGridColumn(grilla, "UM", "UnidadMedida", 0, "", 40, true, false, true);
            // Medidas del producto
            this.CreateGridColumn(grilla, "Largo", "Largo", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");            
            this.CreateGridColumn(grilla, "Ancho", "Ancho", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(grilla, "Espesor", "Alto", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");

            //Datos Calculados
            this.CreateGridColumn(grilla, "Areaxuni", "Areaxuni", 0, "{0:###,###0.00}", 90, false, false, true, true ,"right");
            this.CreateGridColumn(grilla, "Orden", "Orden", 0, "{0:###,###0.00}", 70, true, false, false, true, "right");
            this.CreateGridColumn(grilla, "MTS2", "MTS2", 0, "{0:###,###0.00}", 60, true, false, true, true, "right");   
            this.CreateGridColumn(grilla, "MTS3", "MTS3", 0, "{0:###,###0.00}", 60, true, false, true, true, "right");
            this.CreateGridColumn(grilla, "Area", "Area", 0, "{0:###,###0.00}", 100, false, false, false, true, "right");
            //
            this.CreateGridColumn(grilla, "#Cana/Blo", "NroCaja", 0, "", 70, false, true, true, false, "right");
                        //
            
            //this.CreateGridTimeColumn(grilla, "H.Salida", "IN07HORASALIDA", 0, "##:##", 75, false, true);
            this.CreateGridColumn(grilla, "H.Sal", "IN07HORASALIDA", 0, "", 60, false, true);
            this.CreateGridColumn(grilla, "flag", "flag", 0, "", 30, false, true, false);
            this.CreateGridColumn(grilla, "flagBotones", "flagBotones", 0, "", 40, false, true, false);

            //  Agrega filas ocultas para capturar los ingresos de las salidas

            this.CreateGridColumn(grilla, "IN07DocIngAA", "IN07DocIngAA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngMM", "IN07DocIngMM", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngTIPDOC", "IN07DocIngTIPDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngCODDOC", "IN07DocIngCODDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngKEY", "IN07DocIngKEY", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngORDEN", "IN07DocIngORDEN", 0, "", 0, true, false, false, true);
            this.CreateGridColumn(grilla, "IN07SECUENCIA", "IN07SECUENCIA", 0, "", 0, true, false, false);
            this.CreateGridColumn(grilla, "Cod.Motivo", "IN07MOTIVOCOD", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Motivo", "DesMotivo", 0, "", 60, false, true);

            string[] fieldstosummary = { "Operador", "Cantidad", "MTS2", "MTS3" };
            Util.AddGridSummarySum(gridControl, fieldstosummary);
            
        }
        // Traer los detalles de produccion filtrado por nro de orden de produccion.
        void cargarProductosDet()
        {
            try
            {
                string ordenTrabajo = "";                
                ordenTrabajo = gridOrdenTrabajo.Rows.Count == 0 ? "" : this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();

                var lista = DocumentoLogic.Instance.TraerProduccionDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                                                                            txtCodTipoDocumento.Text.Trim(),txtNumeroDoc.Text.Trim(), ordenTrabajo);
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        // Metodo para traer todo el detalle de produccion , pero  sin filtro por orden de trabajo
        void cargarProductosDetTodos()
        {
            try
            {
                string ordenTrabajo = "";
                var lista = DocumentoLogic.Instance.TraerProduccionDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                                                                            txtCodTipoDocumento.Text.Trim(),
                                                                            txtNumeroDoc.Text.Trim(), ordenTrabajo);
                this.gridControl.DataSource = lista;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddCmdButtonToGrid(RadGridView Grid, string name, string text, string columnGrid)
        {
            GridViewCommandColumn  cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = name;
            cmdbtn.HeaderText = text;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[name].BestFit();
        }
        void agregarBotonDetProducto()
        {
			AddCmdButtonToGrid(gridControl, "btnGrabarDet", "", "btnGrabarDet");         
            AddCmdButtonToGrid(gridControl, "btnCancelarDet", "", "btnCancelarDet");
            AddCmdButtonToGrid(gridControl, "btnEliminarDet", "", "btnEliminarDet");
            AddCmdButtonToGrid(gridControl, "btnEditarDet", "", "btnEditarDet");
        }
                
        void crearGrupos()
        {
            agregarBotonDetProducto();

            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos de Producto"));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Operador"]);

            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["in07prodTurnoCod"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["in07prodTurnoDesc"]);

            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07FECHAPROCESO"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07HORAINICIO"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07HORAFINAL"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07NROCAJAINGRESO"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CajaUnica"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07DESCABEZADOSUP"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07DESCABEZADOINF"]);

            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Cantidad"]);

            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CodigoBloque"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CodMaquina"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DesMaquina"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CodigoAlmacen"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DesAlmacen"]);
            
            if (FrmParent.rbIngreso.IsChecked)
            {
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CodigoArticulo"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DescripcionArticulo"]);
            }
            else {

                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["NroCaja"]);
                
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CodigoArticulo"]);
                this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DescripcionArticulo"]);
            }

            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["UnidadMedida"]);
            //
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Largo"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Ancho"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Alto"]);
            //                       
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Destino MP"));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Orden"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["MTS2"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["MTS3"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Area"]);
            if (FrmParent.rbIngreso.IsChecked)
            {
                this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["NroCaja"]);                
            }

            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["IN07HORASALIDA"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["flag"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["flagBotones"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["DesMotivo"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["btnGrabarDet"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns[0].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["btnCancelarDet"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns[1].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["btnEliminarDet"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns[2].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["btnEditarDet"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns[3].MinWidth = 30;
            this.gridControl.ViewDefinition = columnGroupsView;
        }

        void limpiarDetalleProduccion()
        {
            //orden de trabajo
            this.gridOrdenTrabajo.Rows.Clear();
            this.gridMateriaPrima.Rows.Clear();
            this.gridControl.Rows.Clear();
        }
        bool esInsercion = false;
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (this.gridControl.Rows.Count == 0) return;
            try
            {
                esInsercion = true;

                //Tomar el indice de la fila seleccionada anteriormente                
                mov.IN07SECUENCIA = Util.GetCurrentCellDbl(gridControl, "IN07SECUENCIA");
                inserciondinamica();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #endregion
        //----------------------------------------------------------------------------CABECERA DE DOCUMENTO-----------------------------------------------------------
        #region "Cabecera Documento"

        void limpiarCabeceraProduccion()
        {
            this.txtCodTipoDocumento.Text = "";
            this.txtCodDocRespaldo.Text = "";
            this.txtCodProceso.Text = "";
            this.txtNroDocRespaldo.Text = "";
            this.txtNumeroDoc.Text = "";
            this.txtCodLinea.Text = "";
            this.txtCodTurno.Text = "";
            this.txtDesDocRespaldo.Text = "";
            this.txtDesLinea.Text = "";
            this.txtDesProceso.Text = "";
            this.txtDesTipoDocumento.Text = "";
            this.txtDesTurno.Text = "";
            this.txtDescripcionMaquina.Text = "";
            this.lblnroOT.Text = "";
            dtpFechaOT.Value = DateTime.Now;
        }
       
        protected override void OnGuardar()
        {
            if (!Validar()) return;
            
            //cargarEntidad();
            
            //captura de datos
            doc.CodigoEmpresa = Logueo.CodigoEmpresa;
            doc.Anio = Logueo.Anio;
            doc.Mes = Logueo.Mes;
            doc.TipoDoc = txtCodTipoDocumento.Text.Trim();
            doc.FechaDoc = dtpFechaOT.Value;
            doc.CodigoTransa = txtCodDocRespaldo.Text.Trim();
            //doc.Transaccion = "E";
            doc.Transaccion = (this.esEntrada == true ? "E" : "S");
            doc.ReferenciaDoc = txtNroDocRespaldo.Text.Trim();
            doc.codigoLinea = txtCodLinea.Text.Trim();
            doc.codigoTurno = txtCodTurno.Text.Trim();
            doc.codigoActiNivel1 = txtCodProceso.Text.Trim();
            doc.IN06PRODNATURALEZA = Logueo.PP_codnaturaleza;
            doc.CodigoMaquina = txtCodigoMaquina.Text.Trim();
            doc.OrigenTipo = Logueo.OrigenTipo_Manual;

            string mensaje = string.Empty;
            int flag = 0;
            if (Estado == FormEstate.New) // registro  nuevo documento
            {
                string numero = string.Empty;

                DocumentoLogic.Instance.InsertarProduccionCabecera(doc, out numero, out flag, out mensaje);
                txtNumeroDoc.Text = numero;

                if (flag == 1) { // si la operacion fue exitosa 
                    this.Estado = FormEstate.Edit;
                    habilitarControles(false);
                    btnAdd.Enabled = true;
                    //btnAddOT.Visible = true;// muestro el boton de agregar orden de trabajo
                }
                 
            } 
            else if (Estado == FormEstate.Edit) //actualizacion documento
            {
                doc.CodigoDoc = txtNumeroDoc.Text.Trim();
                DocumentoLogic.Instance.ActualizarProduccionCabecera(doc, out flag, out mensaje); 
            }
            RadMessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info); frmProduccion.formulario.listar();
            
        }
        void habilitarControles(bool valor)
        {
            this.txtCodLinea.Enabled = valor;
            this.txtDesLinea.Enabled = false;
            this.txtCodProceso.Enabled = valor;
            this.txtDesProceso.Enabled = false;
            this.txtCodTipoDocumento.Enabled = valor;
            this.txtDesTipoDocumento.Enabled = false;
            this.txtCodTurno.Enabled = valor; 
            this.txtDesTurno.Enabled = false;
            this.txtCodDocRespaldo.Enabled = valor;
            this.txtDesDocRespaldo.Enabled = false;
            this.txtCodigoMaquina.Enabled = valor;
            this.txtDescripcionMaquina.Enabled = false;
        }
        bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (txtCodTipoDocumento.Text.Trim() == "" || txtDesTipoDocumento.Text == "???")
            {
                RadMessageBox.Show("Ingresar Tipo documento", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                
                txtCodTipoDocumento.Focus();
                return false;
            }
           
            if (txtCodDocRespaldo.Text.Trim() == ""|| txtDesDocRespaldo.Text == "???")
            {
                RadMessageBox.Show("Ingresar Documento respaldo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtCodDocRespaldo.Focus();
                return false;
            }

            if (txtNroDocRespaldo.Text.Trim() == "")
            {
                RadMessageBox.Show("Ingresar numero documento respaldo", "Sistema", MessageBoxButtons.OK , RadMessageIcon.Info);
                txtNroDocRespaldo.Focus();
                return false;
            }

            

            if (txtCodLinea.Enabled) {
                if (txtCodLinea.Text.Trim() == "" || txtDesLinea.Text == "???")
                {
                    RadMessageBox.Show("Ingresar Linea", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    txtCodLinea.Focus();
                    return false;
                }
            }

            if (txtCodProceso.Enabled)
            {
                if (txtCodProceso.Text.Trim() == "" || txtDesProceso.Text == "???")
                {
                    RadMessageBox.Show("Ingresar proceso", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    txtCodProceso.Focus();
                    return false;
                }
            }
            // -- Desativar validacion de campo turno
            if (txtCodTurno.Enabled)
            {
                if (txtCodTurno.Text.Trim() == "" || txtDesTurno.Text == "???")
                {
                    RadMessageBox.Show("Ingresar Turno", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    txtCodTurno.Focus();
                    return false;
                }
            }



            if (txtCodigoMaquina.Enabled) {
                if (txtCodigoMaquina.Text.Trim() == "" || txtDescripcionMaquina.Text == "???")
                {
                    RadMessageBox.Show("Ingresar Maquina", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    txtCodigoMaquina.Focus();
                    return false;
                }
            }

            

            //if (rpControlOrden.Enabled) {
                
            //}

            //if (rpControlMateriaPrima.Enabled)
            //{

            //}
            return true;
        }

        void cargarEntidad()
        {
            doc.CodigoEmpresa = Logueo.CodigoEmpresa;
            doc.Anio = Logueo.Anio;
            doc.Mes = Logueo.Mes;
            doc.TipoDoc = txtCodTipoDocumento.Text.Trim();
            doc.FechaDoc = dtpFechaOT.Value;
            doc.CodigoTransa = txtCodDocRespaldo.Text.Trim();
            //doc.Transaccion = "E";
            doc.Transaccion = (this.esEntrada == true ? "E" : "S");
            doc.ReferenciaDoc = txtNroDocRespaldo.Text.Trim();
            doc.codigoLinea = txtCodLinea.Text.Trim();
            doc.codigoTurno = txtCodTurno.Text.Trim();
            doc.codigoActiNivel1 = txtCodProceso.Text.Trim();
            doc.IN06PRODNATURALEZA = Logueo.PP_codnaturaleza;
            doc.CodigoMaquina = txtCodigoMaquina.Text.Trim();
            doc.OrigenTipo = Logueo.OrigenTipo_Manual;
        }
        private void txtNroDocRespaldo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                cbbGuardar.IsMouseOver = true;
                OnGuardar();
                cbbGuardar.IsMouseOver = false;
            }
        } 
        #endregion        
        //----------------------------------------------------------------------------CONTROLES DE CABECERA DE DOCUMENTO -----------------------------------------------------------
        #region "Controles de Cabecera Documento"
        private void frmDetalleProduccion_Load(object sender, EventArgs e)
        {
            if (esEntrada)
            {
                btnAdd.Enabled = (gridMateriaPrima.Rows.Count == 0) ? false : true;
            }
            else
            {
                btnAdd.Enabled = (gridOrdenTrabajo.Rows.Count == 0) ? false : true;
            }
            this.rpAgregaMasivo.Visible = false;
        }
        private void txtCodigoMaquina_TextChanged(object sender, EventArgs e)
        {
            obtenerDescripcion(enmAyuda.enmMaquinaxLineaActividad);
        }
        private void txtCodigoMaquina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmMaquinaxLineaActividad);
            }
        }
        private void txtCodTipoDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmTipoDocumento);

            }
        }
        private void txtCodDocRespaldo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmTransaccion);

            }
        }
        private void txtCodLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmLinea);
            }
        }
        private void txtCodTurno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmTurnos);
            }
        }
        private void txtCodProceso_KeyDown(object sender, KeyEventArgs e)
        {          
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmActividadNivel1);
            }
        }      
        private void txtCodTipoDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtCodTipoDocumento.Text.Trim().Length == 0)
            {
                BloquearIngresoDatos();
            }
            else
            {
                this.obtenerDescripcion(enmAyuda.enmTipoDocumento);
                configurarDocumento(txtCodTipoDocumento.Text.Trim());
            }
            
        }

        private void txtCodDocRespaldo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodDocRespaldo.Text != "" || txtCodDocRespaldo.Text.Length > 0)
            {
                obtenerDescripcion(enmAyuda.enmTransaccion);
            }
            else
            {
                txtDesDocRespaldo.Text = "";
            }
        }

        private void txtCodLinea_TextChanged(object sender, EventArgs e)
        {
            if (txtCodLinea.Text != "" || txtCodLinea.Text.Length > 0)
            {
                obtenerDescripcion(enmAyuda.enmLinea);
            }
            else
            {
                txtDesLinea.Text = "";
            }
        }

        private void txtCodTurno_TextChanged(object sender, EventArgs e)
        {
            if (txtCodTurno.Text != "" || txtCodTurno.Text.Length > 0)
            {
                obtenerDescripcion(enmAyuda.enmTurnos);
            }
            else
            {
                txtDesTurno.Text = "";
            }
        }

        private void txtCodProceso_TextChanged(object sender, EventArgs e)
        {
            if (txtCodProceso.Text != "" || txtCodProceso.Text.Length > 0)
            {
                obtenerDescripcion(enmAyuda.enmActividadNivel1);
            }
            else
            {
                txtDesProceso.Text = "";
            }

            //Muestra u oculta las  columnas de superior - inferior.
            ocultarcolumnasxdesdoblado();
        }
        
        #endregion
        //----------------------------------------------------------------------------CONTROLES DE TALLE DE DOCUMENTO -----------------------------------------------------------
        #region "Controles Detalle documento"
        private bool ValidarNroCanastilla(string cNroCanastilla)
        {
            bool encontro = true;
                      
            if (this.gridMateriaPrima.Visible == true)
            {
                if (this.gridMateriaPrima.Rows.Count > 0)
                {
                    encontro = false;

                    for (int i = 0; i < this.gridMateriaPrima.Rows.Count; i++)
                    {
                        if (Util.convertiracadena(this.gridMateriaPrima.Rows[i].Cells["IN07NROCAJA"].Value).ToUpper() == cNroCanastilla.ToUpper())
                        {
                            encontro = true;
                            //Salir de for
                        }
                    }
                }
            }
           
            return encontro;
        }        
        bool validarControlOT()
        {

            if (gridOrdenTrabajo.Rows.Count == 0)
            {
                RadMessageBox.Show("Para registrar detalles debe registrar orden de trabajo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;
            }
            string codigodeOrdenTrabajo = gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
            var registro = OrdenTrabajoLogic.Instance.TraerRegistroOT(Logueo.CodigoEmpresa, codigodeOrdenTrabajo);
            if (registro == null) //validamos si existe esta orden de trabajo
            {
                RadMessageBox.Show("Para registrar detalles debe registrar orden de trabajo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                gridMateriaPrima.CurrentColumn = this.gridMateriaPrima.Columns["NroCaja"];
                return false;
            }
            return true;

        }
        bool validarControlMP()
        {
            if (gridMateriaPrima.Rows.Count == 0)
            {
                RadMessageBox.Show("Para registrar detalles debe registrar materia prima", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;
            }            
            
            bool processOK = Util.ValidateCellText(gridMateriaPrima, "IN07NROCAJA", "", "Para registrar detalles debe registrar materia prima");

            if (processOK == false)
            {
                gridMateriaPrima.CurrentColumn = this.gridMateriaPrima.Columns["IN07NROCAJA"];
                return false;
            }          
            return true;
        }
        private bool ValidarHora()
        {
            string horaSalida = Util.convertirahoras(this.gridControl.CurrentRow.Cells["IN07HORASALIDA"].Value.ToString());
            string horaInicio = Util.convertirahoras(this.gridControl.CurrentRow.Cells["IN07HORAINICIO"].Value.ToString());
            string horaFinal = Util.convertirahoras(this.gridControl.CurrentRow.Cells["IN07HORAFINAL"].Value.ToString());
            //-----------------------

            int posicion = 0;

            posicion = horaInicio.IndexOf(':');
            bool horaValido = false; bool minutoValido = false;


            //-------
            //No encontro dos punto 
            if (posicion == -1)
            {
                RadMessageBox.Show("Formato H.Inicio No valido de tiempo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;
            }

            horaValido = Util.ValidarHora(horaInicio.Substring(0, posicion));
            minutoValido = Util.ValidarMinuto(horaInicio.Substring(posicion + 1, 2));

            if (!horaValido)
            {
                RadMessageBox.Show("H.Inicio Hora No Valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORAINICIO"];
                return false;
            }

            if (!minutoValido)
            {
                RadMessageBox.Show("H.Inicio Minuto No Valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORAINICIO"];
                return false;
            }



            //-------
            posicion = horaFinal.IndexOf(':');
            if (posicion == -1)
            {
                RadMessageBox.Show("Formato H.Final No valido de tiempo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;
            }

            horaValido = Util.ValidarHora(horaFinal.Substring(0, posicion));
            minutoValido = Util.ValidarMinuto(horaFinal.Substring(posicion + 1, 2));
            if (!horaValido)
            {
                RadMessageBox.Show("H.Final Hora No Valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORAFINAL"];
                return false;
            }

            if (!minutoValido)
            {
                RadMessageBox.Show("H.Final Minuto No Valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORAFINAL"];
                return false;
            }

            //-------
            posicion = horaSalida.IndexOf(':');
            if (posicion == -1)
            {
                RadMessageBox.Show("Formato H.Salida No valido de tiempo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;
            }

            horaValido = Util.ValidarHora(horaSalida.Substring(0, posicion));
            minutoValido = Util.ValidarMinuto(horaSalida.Substring(posicion + 1, 2));
            if (!horaValido)
            {
                RadMessageBox.Show("H.Salida Hora No Valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORASALIDA"];
                return false;
            }

            if (!minutoValido)
            {
                RadMessageBox.Show("H.Salida Minuto No Valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORASALIDA"];
                return false;
            }
            //----------------------       

            //VALIDACION  de HoraIngreso < Hora Salida
            if (Convert.ToDateTime(horaInicio) > Convert.ToDateTime(horaFinal))
            {
                RadMessageBox.Show("H.Inicio >  H.Final", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                this.gridControl.CurrentColumn = this.gridControl.Columns["IN07HORAFINAL"];
                return false;
            }          

            return true;
        }
        bool ValidarDetProducto()
        {
			GridViewRowInfo fila = this.gridControl.CurrentRow;            
            bool bandera = true;
            if (bandera != Util.ValidateCellText(fila, "CodigoAlmacen", "", "Ingresar Almacen")) return false;
            if (bandera != Util.ValidateCellText(fila, "CodigoArticulo", "", "Ingresar Articulo")) return false;



            //string codigoArticulo = Util.convertiracadena(this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value);
            //Articulo cArticulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo);
            //if (cArticulo.largotext != "XXX" && cArticulo.espesortext != "XXX" && cArticulo.anchotext != "XXX")
            //{
            //    if (bandera != Util.ValidateCellDbl(fila, "Ancho", 0, "Ingresar Ancho")) return false;
            //    if (bandera != Util.ValidateCellDbl(fila, "Largo", 0, "Ingresar Largo")) return false;
            //    if (bandera != Util.ValidateCellDbl(fila, "Alto", 0, "Ingresar Alto")) return false;
            //}


            //****validar formato si es no aplicable
            // Validar Formato
            string codigoArticulo = fila.Cells["CodigoArticulo"].Value.ToString();
            string codigo = string.Empty;
            string tipcalculoarea = string.Empty;

            codigo = Logueo.CodigoEmpresa + Logueo.Anio + codigoArticulo;

            GlobalLogic.Instance.DameDescripcion(codigo, "FLAGTIPCALAREA", out tipcalculoarea);

            //GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOCMOV", out transaccion);


            if (tipcalculoarea == "F") // Validar si el producto se calcula por formato
            {
                // traigo las medidas del articulo
                Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo.Trim());
                // Validar Largo    
                if (articulo.largotext == "XXX" || articulo.largotext == "VAR")
                {
                    // No pide cantidad
                }
                else
                {
                    if (fila.Cells["Largo"] == null || Convert.ToDecimal(fila.Cells["Largo"].Value) == 0)
                    {
                        RadMessageBox.Show("Ingresar Largo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                        gridControl.CurrentColumn = this.gridControl.Columns["Largo"];
                        return false;
                    }
                }

                // Validar Ancho
                if (articulo.anchotext == "XXX" || articulo.anchotext == "VAR")
                {
                    // No pide cantidad
                }
                else
                {
                    if (fila.Cells["Ancho"] == null || Convert.ToDecimal(fila.Cells["Ancho"].Value) == 0)
                    {
                        RadMessageBox.Show("Ingresar Ancho", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                        gridControl.CurrentColumn = this.gridControl.Columns["Ancho"];
                        return false;
                    }
                }

                // Validar Alto
                if (articulo.espesortext == "XXX" || articulo.espesortext == "VAR")
                {
                    // No pide cantidad
                }
                else
                {
                    if (fila.Cells["Alto"] == null || Convert.ToDecimal(fila.Cells["Alto"].Value) == 0)
                    {
                        RadMessageBox.Show("Ingresar Alto", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                        gridControl.CurrentColumn = this.gridControl.Columns["Alto"];
                        return false;
                    }
                }
            }

            //****




            //
            if (bandera != Util.ValidateCellDbl(fila, "Cantidad", 0, "Ingresar cantidad")) return false;
            if (bandera != Util.ValidateCellText(fila, "NroCaja", "", "Ingresar Numero caja")) return false;

            // valido si la columna operador es visible
            bool ColumnaEsVisible = this.gridControl.Columns["Operador"].IsVisible;
            if (ColumnaEsVisible == true)
            {
                if (bandera != Util.ValidateCellText(fila, "Operador", "", "Ingresar Operador")) return false;
            }
            
            return true;
        }
                
        //Guardar el detalle de producto
        void GuardarDetProducto(GridViewRowInfo fila)
        {
            try
            {
                if (!ValidarDetProducto()) return;
                //Convertirahoras                                                      
                string horaSalida =  fila.Cells["IN07HORASALIDA"].Value == null ? 
                                    Util.convertirahoras("")
                                    : Util.convertirahoras(fila.Cells["IN07HORASALIDA"].Value.ToString());

                string horaInicio = fila.Cells["IN07HORAINICIO"].Value == null ? Util.convertirahoras("") 
                                    : Util.convertirahoras(fila.Cells["IN07HORAINICIO"].Value.ToString());
                
                string horaFinal = fila.Cells["IN07HORAFINAL"].Value == null ? Util.convertirahoras("")
                                   : Util.convertirahoras(fila.Cells["IN07HORAFINAL"].Value.ToString());
                
                this.gridControl.CurrentRow.Cells["IN07HORASALIDA"].Value= horaSalida;
                this.gridControl.CurrentRow.Cells["IN07HORAINICIO"].Value = horaInicio;
                this.gridControl.CurrentRow.Cells["IN07HORAFINAL"].Value = horaFinal;

                 
                //
                if (!ValidarHora()) return;
                //string nrocanastillaingreso = fila.Cells["IN07NROCAJAINGRESO"].Value == null ? "" :
                //    Util.convertiracadena(fila.Cells["IN07NROCAJAINGRESO"].Value.ToString());
                string nrocanastillaingreso = fila.Cells["CajaUnica"].Value == null ? "" :
                    Util.convertiracadena(fila.Cells["CajaUnica"].Value.ToString());
                
                //Desactivar el codigo de vlaidacion de Validacion Nro Canastilla
                //if (this.rpControlMateriaPrima.Enabled == true)
                //{
                //    if (!ValidarNroCanastilla(nrocanastillaingreso))
                //    {
                //        RadMessageBox.Show("El Nro de Caja No Existe", "Sistema", MessageBoxButtons.OK, 
                //                            RadMessageIcon.Exclamation);
                //        return;
                //    } 
                //}
                

                mov.CodigoEmpresa = Logueo.CodigoEmpresa;
                mov.Anio = Logueo.Anio;
                mov.Mes = Logueo.Mes;
                mov.in07codcli = Logueo.codigoClientxDefecto;
                mov.CodigoTipoDocumento = txtCodTipoDocumento.Text.Trim();
                mov.CodigoDocumento = txtNumeroDoc.Text.Trim();
                mov.CodigoArticulo = fila.Cells["CodigoArticulo"].Value.ToString();

                mov.Ancho = Convert.ToDouble(fila.Cells["Ancho"].Value.ToString());
                mov.Largo = Convert.ToDouble(fila.Cells["Largo"].Value.ToString());
                mov.Alto = Convert.ToDouble(fila.Cells["Alto"].Value.ToString());

                //agregado recien para el detall de producccion
                mov.operador = fila.Cells["codigoOperador"].Value == null ? "" : fila.Cells["codigoOperador"].Value.ToString();

                string almacen = gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                mov.CodigoAlmacen = almacen;
                mov.CodigoTransaccion = txtCodDocRespaldo.Text.Trim();
                mov.Cantidad = Convert.ToDouble(fila.Cells["Cantidad"].Value.ToString());
                mov.UnidadMedida = fila.Cells["UnidadMedida"].Value.ToString();
                mov.FechaDoc = (DateTime)dtpFechaOT.Value;

                mov.NroCaja = gridControl.CurrentRow.Cells["NroCaja"].Value.ToString();
                bool value =  false;
                //double.TryParse(mov.NroCaja, value out );
                 
                
                mov.Areaxuni = Convert.ToDouble(this.gridControl.CurrentRow.Cells["Areaxuni"].Value);

                mov.NroPedidoVenta = "";
                mov.IN07PROVMATPRIMA = "";
                mov.OrdenProduccion = "";

                mov.in07prodTurnoCod = Util.convertiracadena(this.gridControl.CurrentRow.Cells["in07prodTurnoCod"].Value);
                // Pasar los valores del ingreso
                // Campos que relacionan la salida con su respectivo ingreso
                mov.Transaccion = (this.esEntrada == true ? "E" : "S");

                mov.IN07HORASALIDA = gridControl.CurrentRow.Cells["IN07HORASALIDA"].Value.ToString();

                mov.IN07NROCAJAINGRESO = nrocanastillaingreso;
                

                mov.IN07HORAINICIO = gridControl.CurrentRow.Cells["IN07HORAINICIO"].Value.ToString();

                mov.IN07HORAFINAL = gridControl.CurrentRow.Cells["IN07HORAFINAL"].Value.ToString();
                string cMotivoCod = Util.convertiracadena(gridControl.CurrentRow.Cells["IN07MOTIVOCOD"].Value);
				mov.IN07MOTIVOCOD = cMotivoCod;
                if (mov.Transaccion == "S")
                {
                    if (gridControl.CurrentRow.Cells["IN07DocIngAA"].Value != null) 
                        mov.IN07DocIngAA = gridControl.CurrentRow.Cells["IN07DocIngAA"].Value.ToString();
                    if (gridControl.CurrentRow.Cells["IN07DocIngMM"].Value != null) 
                        mov.IN07DocIngMM = gridControl.CurrentRow.Cells["IN07DocIngMM"].Value.ToString();
                    if (gridControl.CurrentRow.Cells["IN07DocIngTIPDOC"].Value != null) 
                        mov.IN07DocIngTIPDOC = gridControl.CurrentRow.Cells["IN07DocIngTIPDOC"].Value.ToString();
                    if (gridControl.CurrentRow.Cells["IN07DocIngCODDOC"].Value != null) 
                        mov.IN07DocIngCODDOC = gridControl.CurrentRow.Cells["IN07DocIngCODDOC"].Value.ToString();
                    if (gridControl.CurrentRow.Cells["IN07DocIngKEY"].Value != null) 
                        mov.IN07DocIngKEY = gridControl.CurrentRow.Cells["IN07DocIngKEY"].Value.ToString();
                    if (gridControl.CurrentRow.Cells["IN07DocIngORDEN"].Value != null) 
                        mov.IN07DocIngORDEN = double.Parse(gridControl.CurrentRow.Cells["IN07DocIngORDEN"].Value.ToString());
                }
                
                    mov.IN07FECHAPROCESO = gridControl.CurrentRow.Cells["IN07FECHAPROCESO"].Value == null ? (DateTime?) null : 
                                           DateTime.Parse(gridControl.CurrentRow.Cells["IN07FECHAPROCESO"].Value.ToString());

                    //si el proceso es desdoblado
                    bool esDesdoblado = Logueo.codProcesoDesdoblado == txtCodProceso.Text.Trim();
                    //capturar valores de superio e inferio
                    mov.IN07DESCABEZADOSUP = esDesdoblado == true ? Convert.ToDouble(fila.Cells["IN07DESCABEZADOSUP"].Value) : 0;
                    mov.IN07DESCABEZADOINF = esDesdoblado == true ? Convert.ToDouble(fila.Cells["IN07DESCABEZADOINF"].Value) : 0;

                // Solo Manda OT, si la Grilla de Ot esta visible
                if (gridOrdenTrabajo.Rows.Count > 0)
                    mov.IN07ORDENTRABAJO = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                else
                    mov.IN07ORDENTRABAJO = "";


                string msj = string.Empty;
                int flag = 0;
                //----------varaibles para validacion de regla denegocio
                string mensajevalida = "";
                int flagvalida = 0;

                if (double.Parse(fila.Cells["Orden"].Value.ToString()) == 0)
                {
                    //NUEVO
                    double orden = 0;
                    
                    //Asignar flag de insercion para saltar proceso de Insercion
                    string  flaginsercion = "N";
                    if (esInsercion)
                    {
                        flaginsercion = "I";
                        
                    }else {
                      
                        flaginsercion = "N";
                    }

                    DocumentoLogic.Instance.TraerNroOrden(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, txtCodTipoDocumento.Text.Trim(),
                      txtNumeroDoc.Text.Trim(), mov.CodigoArticulo, out orden);
                    mov.Orden = orden;

                    //------------------------Validacion de insercion -----------------------------------------------------------------
                   
                    /*Validacion de reglan n28 para Baldosas - Actividad:Corte , una caja no debe pasra mas de 40mts2*/

                    DocumentoLogic.Instance.ValidarInsertarProduccionDetalle(mov, "I",out mensajevalida, out flagvalida);


                    // si flag es 0 entonces procedemos a guardar
                    if (flagvalida == 0)
                        { GuardarDetalledeproduccion(mov, flaginsercion); }
                    else if (flagvalida == -1) //  flag para preguntar si desea continuar
                    {
                        DialogResult res = RadMessageBox.Show(mensajevalida, "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        //si decide continuar entonces guardar
                        if (res == System.Windows.Forms.DialogResult.Yes)
                        { GuardarDetalledeproduccion(mov, flaginsercion); }

                    }
                    
                    
                }
                else
                {
                    //ACTUALIZAR
                    mov.Orden = double.Parse(fila.Cells["Orden"].Value.ToString());
                    DocumentoLogic.Instance.ValidarInsertarProduccionDetalle(mov, "U", out mensajevalida, out flagvalida);

                    // si flag es 0 entonces procedemos a guardar
                    if (flagvalida == 0)
                    { ActualizarDetalledeproduccion(mov); }

                    else if (flagvalida == -1) //  flag para preguntar si desea continuar
                    {
                        DialogResult res = RadMessageBox.Show(mensajevalida, "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        //si decide continuar entonces guardar
                        if (res == System.Windows.Forms.DialogResult.Yes)
                        { ActualizarDetalledeproduccion(mov); }

                    }

                    
                  
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);                
            }
            
        }
        private void GuardarDetalledeproduccion(Movimiento movi, string pflaginsercion)
        {
            /*Insertar el detalle de movimiento*/
            string msj = "";
            string cajaunica="";
            int flag = 0;
            DocumentoLogic.Instance.InsertarProduccionDetalle(movi, pflaginsercion, out flag, out msj);
            bool processok = Util.ShowMessage(msj, flag);
            if (processok == true)
            {
                //Flag indica insercion es exitoso
                //this.gridControl.CurrentRow.Cells["flag"].Value = null;
                Util.SetClearCurrentCellText(gridControl, "flag");
                //refrescar grilla
                
                //Refrescar y enfocar Materia Prima
                //CapturarFilaEnfocacda
                cajaunica = gridControl.CurrentRow.Cells["CajaUnica"].Value.ToString();
                CargarMPResumido();
                Util.enfocarFila(gridMateriaPrima, "CajaUnica", cajaunica);

                //enforcar fila recien insertada
                cargarProductosDet();
                Util.enfocarFila(gridControl, "Orden", movi.Orden.ToString());
                

                if (esInsercion == false)
                //agrego nueva fila
                { btnAdd_Click(null, null); }
            }
        }
        private void ActualizarDetalledeproduccion(Movimiento movi)
        {
            string msj = ""; int flag = 0;
            string cajaunica = "";
            DocumentoLogic.Instance.ActualizarProduccionDetalle(movi, out flag, out msj);
            bool processok = Util.ShowMessage(msj, flag);
            if (processok == true)
            {
                //this.gridControl.CurrentRow.Cells["flag"].Value = null;
                
                // Refrescar grilla Materia Prima
                cajaunica = gridControl.CurrentRow.Cells["CajaUnica"].Value.ToString();
                CargarMPResumido();
                Util.enfocarFila(gridMateriaPrima, "CajaUnica", cajaunica);

                //
                Util.SetClearCurrentCellText(gridControl, "flag");
                cargarProductosDet();
                Util.enfocarFila(gridControl, "Orden", movi.Orden.ToString());
                //Enforcar columna hora de inicio
                this.gridControl.Columns["IN07HORAINICIO"].IsCurrent = true;
            }
        }

        void EliminarDetProducto()
        {
            this.KeyPreview = true;
            if (HasRowToSave() > 0)
            {
                Util.ShowAlert("Debe completar registro");
                return;
            }

            try
            {
                string msj = string.Empty;
                string cajaunica = "";
                GridViewRowInfo fila = this.gridControl.CurrentRow;
                string codArt = fila.Cells["CodigoArticulo"].Value.ToString();
                string unidad = fila.Cells["UnidadMedida"].Value.ToString();

                double orden = Convert.ToDouble(fila.Cells["Orden"].Value.ToString());
                DialogResult res = RadMessageBox.Show("¿Desea eliminar?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    DocumentoLogic.Instance.EliminarProduccionDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, txtCodTipoDocumento.Text.Trim(),
                    txtNumeroDoc.Text.Trim(), txtCodDocRespaldo.Text.Trim(), string.Format("{0:yyyyMMdd}", dtpFechaOT.Value), codArt, unidad, orden, out msj);
                }

                // Refrescar grilla Materia Prima
                cajaunica = gridControl.CurrentRow.Cells["CajaUnica"].Value.ToString();
                CargarMPResumido();
                Util.enfocarFila(gridMateriaPrima, "CajaUnica", cajaunica);

                //MessageBox.Show(msj);
                cargarProductosDet();
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message, "Sistema");
            }
            
            //Util.enfocarFila(gridControl, "Orden", Convert.ToInt32(mov.Orden).ToString());            
        }
        void cancelarDetProducto()
        {
            this.KeyPreview = true;
            cargarProductosDet();
            if (gridControl.Rows.Count > 0)
            {
                this.gridControl.CurrentRow.IsCurrent = true;
            }
            

        }
        void editarDetProducto() {
            
            this.KeyPreview = false;
            if (HasRowToSave() > 0)
            {
                Util.ShowAlert("Debe completar registro");
                return;
            }

            //Asginar a al fila mdo edicion
            this.gridControl.CurrentRow.Cells["flag"].Value = "0";            
            this.gridControl.CurrentRow.Cells["flagBotones"].Value = "E";
            this.gridControl.CurrentColumn = this.gridControl.Columns["CodigoArticulo"];
            Util.ResaltarAyuda(this.gridControl.CurrentRow.Cells["CodigoAlmacen"]);
            Util.ResaltarAyuda(this.gridControl.CurrentRow.Cells["Operador"]);  // provmatprimaNombre
            Util.ResaltarAyuda(this.gridControl.CurrentRow.Cells["CodigoArticulo"]);
            Util.ResaltarAyuda(this.gridControl.CurrentRow.Cells["in07prodTurnoDesc"]);
            if (esEntrada == false) {                
                this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = false;
                this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = false;
                this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = false;
            }
        }
		private int HasRowToSave() {
            int rowsaffected = 0;
            
            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                if(Util.GetCurrentCellText(row, "flagBotones") == "E")                
                    rowsaffected++;                
            }
            return rowsaffected;
        }                
        private void deshabilitarBotonProdDet(string nombre,GridCommandCellElement CommandCell) 
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":                   
                       
                    cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnCancelarDet":
                    cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEliminarDet":
                    cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEditarDet":
                    cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                default:
                    break;
            }
            
        }
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar, 
                                            bool bCancelar, bool bEliminar, bool bEditar)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre) 
            {
                case "btnGrabarDet":                                            
                        cellElement.CommandButton.Image =  bGrabar ?  Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelarDet":                    
                        cellElement.CommandButton.Image = bCancelar ?  Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;                   
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminarDet":               
                        cellElement.CommandButton.Image = bEliminar ? Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditarDet":
                        cellElement.CommandButton.Image = bEditar ? Properties.Resources.edited_enabled : Properties.Resources.edited_disabled;                  
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = bEditar;
                    break;
                    
                default:
                    break;
            }
        }
        private void enfocaBotonesProductDet(string nombre)
        {
            RadButtonElement btnGrabarDet = buscarBoton("btnGrabarDet");
            RadButtonElement btnCancelarDet = buscarBoton("btnCancelarDet");
            RadButtonElement btnEliminarDet = buscarBoton("btnEliminarDet");
            RadButtonElement btnEditarDet = buscarBoton("btnEditarDet");
            btnGrabarDet.IsMouseOver = false; btnCancelarDet.IsMouseOver = false; btnEliminarDet.IsMouseOver = false; btnEditarDet.IsMouseOver = false;

            switch (nombre)
            {
                case "btnGrabarDet":
                    btnGrabarDet.IsMouseOver = true;
                    break;
                case "btnCancelarDet":
                    btnCancelarDet.IsMouseOver = true;
                    break;
                case "btnEliminarDet":
                    btnEliminarDet.IsMouseOver = true;
                    break;
                case "btnEditarDet":
                    btnEditarDet.IsMouseOver = true;
                    break;
                default:
                    btnGrabarDet.IsMouseOver = false; btnCancelarDet.IsMouseOver = false; btnEliminarDet.IsMouseOver = false; btnEditarDet.IsMouseOver = false;
                    break;
            }

        }
        private RadButtonElement buscarBoton(string nombreBoton)
        {
            RadButtonElement boton = null;
            try
            {
                GridViewRowInfo currentRow = this.gridControl.CurrentRow;
                GridViewCellInfo celda1 = currentRow.Cells[nombreBoton];
                currentRow.EnsureVisible();
                GridCellElement cellElement1 = gridControl.TableElement.GetCellElement(celda1.RowInfo, celda1.ColumnInfo);
                boton = (RadButtonElement)cellElement1.Children[0];
            }
            catch (Exception ex)
            {

            }
            return boton;
        }

        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabarDet"].IsCurrent)
            { GuardarDetProducto(this.gridControl.CurrentRow);}

            if (this.gridControl.Columns["btnEditarDet"].IsCurrent)
            { editarDetProducto(); }

            if (this.gridControl.Columns["btnEliminarDet"].IsCurrent)
            { EliminarDetProducto(); }

            if (this.gridControl.Columns["btnCancelarDet"].IsCurrent)
            { cancelarDetProducto(); }

            if (this.gridControl.Columns["btnEditarDet"].IsCurrent)
            { editarDetProducto(); }
        }
        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {

                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);

                if (Estado == FormEstate.View)
                {
                    deshabilitarBotonProdDet(e.Column.Name, cellElement);
                    return;
                }

                if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value == null) return;

                if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value.ToString() != "0"
                    && gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);

                }
                else
                {
                    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);
                }


            }

        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {                    
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Tab)
            {
                this.gridControl.CurrentRow.Cells[this.gridControl.CurrentColumn.Index].BeginEdit();
            }
                                
            if (Estado == FormEstate.List || Estado == FormEstate.View) return; // inhabilito el evento si no es modo Edicio
                                    
            try
            {
                if (this.gridControl.CurrentRow.Cells["flag"] == null) return;
                if (this.gridControl.CurrentRow.Cells["flag"].Value == null) return;
                //Enfocar y grabar cuando se encuenta en la ultima columan de la fila actual

                
                //Menu de ayuda
                if (e.KeyValue == (char)Keys.F1)
                {
                    GridViewRowInfo fila = gridControl.CurrentRow;
                    GridViewColumn columna = this.gridControl.CurrentColumn;
                    
                    if (columna.Index == fila.Cells["CodigoArticulo"].ColumnInfo.Index ||
                        columna.Index == fila.Cells["NroCaja"].ColumnInfo.Index)
                    {
                        if (fila.Cells["CodigoAlmacen"].Value == null)
                        {
                            RadMessageBox.Show("Seleccionar almacen", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                            return;
                        }
                        if (fila.Cells["CodigoAlmacen"].Value.ToString() == "")
                        {
                            RadMessageBox.Show("Seleccionar almacen", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                            return;
                        }
                    }

                    if (columna.Index == fila.Cells["DesMaquina"].ColumnInfo.Index) { mostrarAyuda(enmAyuda.enmMaquina); }
                    if (columna.Index == fila.Cells["Operador"].ColumnInfo.Index) { mostrarAyuda(enmAyuda.enmOperador); }
                    if (columna.Index == fila.Cells["DesMotivo"].ColumnInfo.Index) { mostrarAyuda(enmAyuda.enmMotivo); }

                    //F1 --  Ayuda de Turno            
                    if (columna.Index == fila.Cells["in07prodTurnoDesc"].ColumnInfo.Index) 
                    {
                        mostrarAyuda(enmAyuda.enmTurnosxDetalle);
                    }
                    //Habilito ayuda si la transaccion es Ingreso o Salida
                    if (FrmParent.rbIngreso.IsChecked) // si el documento es de Ingreso permito 
                    {
                        // no permito llamar a la ayuda de articulo si esta en modo editar                      
                            if (columna.Index == fila.Cells["CodigoAlmacen"].ColumnInfo.Index) {mostrarAyuda(enmAyuda.enmAlmacen);}
                            if (columna.Index == fila.Cells["CodigoArticulo"].ColumnInfo.Index) 
                            {                              
                                mostrarAyuda(enmAyuda.enmProductoXAlmacen);
                            }
                      

                    }
                    else
                    {
                        if (Convert.ToDouble(fila.Cells["Orden"].Value) != 0) return;
                        //Permito llamar ayuda de NroCaja y Codigo de Almacen (Almacen)  solo si es una fila nueva                            
                        if (columna.Index == fila.Cells["NroCaja"].ColumnInfo.Index) { mostrarAyuda(enmAyuda.enmCanastillas); }
                        if (columna.Index == fila.Cells["CodigoAlmacen"].ColumnInfo.Index) { mostrarAyuda(enmAyuda.enmAlmacen); }
                    }

                }
                //-> Menu Ayuda 

            }
            catch (Exception ex)
            {
            }
        }
        private void gridControl_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
           ////Variables para calcular area
            double cantidad = 0;
            string UniMed = string.Empty;
            string Ptcodigo = string.Empty;
            double Area = 0;
            double Volumen = 0;
            double Ancho = 0;
            double Largo = 0;
            double Alto = 0;
            try
            {

                if (e.Column.Name.CompareTo("Cantidad") == 0 ||
               e.Column.Name.CompareTo("Ancho") == 0 ||
               e.Column.Name.CompareTo("Largo") == 0||
               e.Column.Name.CompareTo("Alto") == 0)
                {
                    
                    // Capturas valores de la grilla
                    Ptcodigo = gridControl.CurrentRow.Cells["CodigoArticulo"].Value.ToString();
                    UniMed = gridControl.CurrentRow.Cells["UnidadMedida"].Value.ToString();

                    cantidad = double.Parse(this.gridControl.CurrentRow.Cells["Cantidad"].Value.ToString());
                    Ancho = double.Parse(gridControl.CurrentRow.Cells["Ancho"].Value.ToString());
                    Largo = double.Parse(gridControl.CurrentRow.Cells["Largo"].Value.ToString());
                    Alto = double.Parse(gridControl.CurrentRow.Cells["Alto"].Value.ToString());

                    // Traer area y volumen
                    ArticuloLogic.Instance.TraerAreaVolumenPP(Ptcodigo, UniMed, Ancho, Largo, Alto, cantidad,Logueo.PP_codnaturaleza, out Area, out Volumen);
                    //Capturar valores para calcular area x uni
                  
                    Articulo articulo = ArticuloLogic.Instance.ProterAreaxUni(Logueo.CodigoEmpresa, Logueo.Anio, Ptcodigo, Ancho, Largo);
                    double AreaxUni = articulo.AreaxUni;

                    this.gridControl.CurrentRow.Cells["Areaxuni"].Value = AreaxUni;   

                    //Asignar area y volumen
                    this.gridControl.CurrentRow.Cells["MTS2"].Value = Area.ToString();
                    this.gridControl.CurrentRow.Cells["MTS3"].Value = Volumen.ToString();

                }
            }
            catch (Exception ex)
            {

            }



        }                
        private void btnAgregaMasivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodTipoDocumento.Text == "")
                {
                    RadMessageBox.Show("Para registrar detalles debe guardar el documento", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (rpControlOrden.Enabled) // si orden de trabajo esta habilitado
                {
                    if (!validarControlOT()) return;
                }

                if (rpControlMateriaPrima.Enabled)
                { // si MP esta habilitado
                    if (!validarControlMP()) return;
                }

                this.KeyPreview = false;
                this.rpAgregaMasivo.BringToFront(); // LLEVAMOS ADELANTE EL MODAL(RADPENL)

                //Validamos la cabecera del documenta para cargar la ventana de  [Agregar Masivo]               
                this.inicializarModalIngMasivo();

                this.rpAgregaMasivo.Show();
                this.gridExcel.Focus();
                timer1.Enabled = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                this.gridControl.Focus();


                esInsercion = false;
                if (this.txtCodTipoDocumento.Text == "")
                {
                    RadMessageBox.Show("Para registrar detalles debe guardar el documento", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (rpControlOrden.Enabled) // si orden de trabajo esta habilitado
                {
                    if (!validarControlOT()) return;
                }

                if (rpControlMateriaPrima.Enabled)
                { // si MP esta habilitado
                    if (!validarControlMP()) return;
                }

                string codigodeAlmacen = "";
                if (txtCodLinea.Text.Trim() != "" && txtCodProceso.Text.Trim() != "")
                {
                    ActividadNivel1Logic.Instance.TraerAlmacenxProceso(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(),
                                                                        txtCodProceso.Text.Trim(), out codigodeAlmacen);
                }
                if (gridControl.Rows.Count == 0)
                {
                    //Agregamos nueva fila a la grilla
                    this.KeyPreview = false;
                    GridViewRowInfo rowInfo = gridControl.Rows.AddNew();
                    // ========================================== Enfocar la ultima fila =================================

                    // ========================================== Asignar valores a la nueva fila ========================
                    rowInfo.Cells["Orden"].Value = 0;
                    rowInfo.Cells["CodigoAlmacen"].Value = codigodeAlmacen;// --> PRO09ALMACENCOD                                                            
                    rowInfo.Cells["IN07HORASALIDA"].Value = "00:00";
                    rowInfo.Cells["IN07FECHAPROCESO"].Value = this.dtpFechaOT.Value;
                    rowInfo.Cells["in07prodTurnoCod"].Value = this.txtCodTurno.Text;
                    rowInfo.Cells["flag"].Value = "0";
                    rowInfo.Cells["flagBotones"].Value = "E";

                    string cajaUnica = Util.GetCurrentCellText(gridMateriaPrima, "CajaUnica");
                    rowInfo.Cells["CajaUnica"].Value = cajaUnica;

                    string cajaIngreso = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
                    // Verificar si existe la celda "In07NroCaja"                 
                    rowInfo.Cells["IN07NROCAJAINGRESO"].Value = cajaIngreso;


                    //Resaltar ayuda
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoAlmacen"]);
                    Util.ResaltarAyuda(rowInfo.Cells["Operador"]);  // provmatprimaNombre
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);
                    Util.ResaltarAyuda(rowInfo.Cells["in07prodTurnoDesc"]);

                    if (FrmParent.rbIngreso.IsChecked)
                    {
                        this.gridControl.CurrentColumn = this.gridControl.Columns["Operador"];
                        rowInfo.Cells["Operador"].BeginEdit();
                        //rowInfo.Cells["Operador"].IsSelected = true;

                    }
                    else
                    {
                        this.gridControl.CurrentColumn = this.gridControl.Columns["NroCaja"];
                        rowInfo.Cells["NroCaja"].BeginEdit();
                    }

                    this.gridControl.CurrentRow = rowInfo;

                }
                else //// Caso contrario si tiene mas de un registro
                {
                    if (this.gridControl.CurrentRow.Cells["flag"].Value != null)
                    {
                        RadMessageBox.Show("Debe completar el registro actual", "Aviso",
                                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    if (this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["Orden"].Value.ToString() == "0")
                    {
                        RadMessageBox.Show("No ha completado registrar el detalle de documento", "Aviso",
                                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }

                    this.gridControl.Focus();
                    this.KeyPreview = false;

                    GridViewRowInfo rowInfo = gridControl.Rows.AddNew();
                    // ========================================== Asignar valores a la nueva fila ========================
                    //Resaltar ayuda
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoAlmacen"]);
                    Util.ResaltarAyuda(rowInfo.Cells["Operador"]);
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);
                    Util.ResaltarAyuda(rowInfo.Cells["in07prodTurnoDesc"]);
                    //==== copiar la fila anterior de la grilla           
                    int i = 0;
                    foreach (GridViewCellInfo celda in gridControl.Rows[this.gridControl.CurrentRow.Index - 1].Cells)
                    {
                        this.gridControl.CurrentRow.Cells[i].Value = celda.Value;
                        i++;
                    }


                    // ========================================= Asignando valores vacio o cero para la nueva fila  ========================================
                    rowInfo.Cells["Orden"].Value = 0;
                    rowInfo.Cells["CodigoAlmacen"].Value = codigodeAlmacen; // --> PRO09ALMACENCOD    
                    rowInfo.Cells["Cantidad"].Value = 0;
                    rowInfo.Cells["Areaxuni"].Value = 0;
                    rowInfo.Cells["MTS2"].Value = 0;
                    rowInfo.Cells["MTS3"].Value = 0;
                    rowInfo.Cells["Area"].Value = 0;
                    rowInfo.Cells["flag"].Value = "0";// esta fila es editable   
                    rowInfo.Cells["flagBotones"].Value = "E";
                    rowInfo.Cells["IN07MOTIVOCOD"].Value = null;
                    rowInfo.Cells["DesMotivo"].Value = null;

                    string cajaUnica = Util.GetCurrentCellText(gridMateriaPrima, "CajaUnica");
                    rowInfo.Cells["CajaUnica"].Value = cajaUnica;

                    string cajaIngreso = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
                    rowInfo.Cells["IN07NROCAJAINGRESO"].Value = cajaIngreso;


                    if (FrmParent.rbIngreso.IsChecked)
                    {
                        this.gridControl.Columns["IN07HORAINICIO"].IsCurrent = true;
                    }
                    else
                    {
                        this.gridControl.Columns["NroCaja"].IsCurrent = true;
                        rowInfo.Cells["NroCaja"].ReadOnly = true;
                    }

                    // ================================================== Enfocando la ultima fila  ==================================================
                    this.gridControl.CurrentRow = rowInfo;

                }
            }
            catch (Exception)
            {

            }
        }
        #endregion      
        //----------------------------------------------------------------------------CONTROLES DE ORDEN DE TRABAJO -------------------------------------------------------------
        #region "Controles Orden Trabajo"
        private void gridOrdenTrabajo_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridOrdenTrabajo.RowCount > 0)

                if (e.KeyValue == (char)Keys.F1)
                {
                    if (this.gridOrdenTrabajo.CurrentRow.Cells["flag"].Value == null) return;
                    int columnIndex = this.gridOrdenTrabajo.CurrentColumn.Index;
                    
                    switch (this.gridOrdenTrabajo.CurrentColumn.Name)
                    {
                        case "productoObjetivo":
                            //validar si el registor de ot tiene materia prima seleccionado.
                            if (gridMateriaPrima.Rows.Count > 0)
                            {
                                RadMessageBox.Show("No puede modificar si tiene materia prima consumido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                return;
                            }
                            mostrarAyuda(enmAyuda.enmProducObjetivo);
                            break;
                        case "DesTipoOT":
                            mostrarAyuda(enmAyuda.enmOrdenTrabajoTipo);
                            break;

                        default: 
                            break;
                    }                    
                }
        }
        private void gridOrdenTrabajo_CommandCellClick(object sender, EventArgs e)
        {
            //GridCommandCellElement boton = (sender as GridCommandCellElement);
            OrdenTrabajo ord = new OrdenTrabajo();
            if (this.gridOrdenTrabajo.Columns["btnGrabarOT"].IsCurrent)
            {
                this.GuardarOrdenTrabajo(this.gridOrdenTrabajo.CurrentRow);
                return;
            }

            if (this.gridOrdenTrabajo.Columns["btnCancelarOT"].IsCurrent)
            {
                ord.codigo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                CargarOrdenTrabajo();
                Util.enfocarFila(gridOrdenTrabajo, "codigo", ord.codigo);
                return;
            }
            if (this.gridOrdenTrabajo.Columns["btnEditarOT"].IsCurrent)
            {
               
                EditarOrdenTrabajo();
                return;
            }

            if (this.gridOrdenTrabajo.Columns["btnEliminarOT"].IsCurrent)
            {
                EliminarOrdenTrabajo();
                CargarOrdenTrabajo();
                
                //si no tenemos registro limpiamos numero de orden  y oculta boton de agregar materia prima
                if (gridOrdenTrabajo.Rows.Count == 0) 
                { 
                    btnAddMateria.Visible = false; 
                    lblnroOT.Text = ""; 
                }  
                return;
            }

           
        }

        private void habilitarBotonOrdenTrabajo(string nombre, GridCommandCellElement CommandCell, bool bGrabar, bool bCancelar, bool bEliminar, bool bEditar) 
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarOT":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;
                case "btnCancelarOT":
                     cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled :  Properties.Resources.cancel_disabled;
                     cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                     cellElement.CommandButton.Enabled = bCancelar;
                    break;
                case "btnEliminarOT":
                    cellElement.CommandButton.Image =  bEliminar ?  Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;
                case "btnEditarOT":
                    cellElement.CommandButton.Image =  bEditar? Properties.Resources.edited_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;
                default:
                    break;
            }
        }

        private void gridOrdenTrabajo_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;                                               
                if (cellElement == null) return;
                if (Estado == FormEstate.View) {
                    habilitarBotonOrdenTrabajo(e.Column.Name, cellElement, false, false, false, false);                    
                    return;
                }              

                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {                    
                    if (gridOrdenTrabajo.Rows[e.RowIndex].Cells["flag"].Value != null) { 
                        habilitarBotonOrdenTrabajo(e.Column.Name, cellElement, true, true, false, false); 
                    }  else { 
                        habilitarBotonOrdenTrabajo(e.Column.Name, cellElement, false, false, true, true); }
                }                
            }
            catch (Exception ex)
            {

            }

        }

        private void gridOrdenTrabajo_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (gridOrdenTrabajo.ActiveEditor != null)
            {
                if (gridOrdenTrabajo.CurrentRow.Cells["flag"].Value != null)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }
       
        private void gridOrdenTrabajo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (gridOrdenTrabajo.Rows.Count == 0) return;                
                if (e.CurrentRow != null)
                {
                    if (e.CurrentRow.Cells["codigo"] != null)
                    {
                        if (e.CurrentRow.Cells["codigo"].Value != null)
                        {
                         
      
                            //-------------------------------------------MOSTRAR MATERIA PRIMAR Y PRODUCCION X ORDEN DE TRABAJO----------------------------------
                                string OT = e.CurrentRow.Cells["codigo"].Value.ToString();

                                OrdenTrabajo orden = OrdenTrabajoLogic.Instance.TraerRegistroOT(Logueo.CodigoEmpresa, OT);
                                if (orden == null)
                                {
                                    lblnroOT.Text = "";
                                    this.gridMateriaPrima.Rows.Clear();
                                    this.gridControl.Rows.Clear();
                                    this.btnAddMateria.Enabled = false;
                                }
                                else
                                {
                                    lblnroOT.Text = e.CurrentRow.Cells["codigo"].Value.ToString();
                                    cargarProductosDet();
                                    CargarMPResumido();
                                    btnAddMateria.Enabled = true;
                                }
                            
                        } else {
                          
                            gridMateriaPrima.Rows.Clear();
                            gridControl.Rows.Clear();
                        }
                       
                    }
                   
                                        
                }
            }
            catch (Exception ex)
            {

            }

        }
        private void btnAddOT_Click(object sender, EventArgs e)
        {
            
            //-------------------------------------------------------------------------------------------------------------------------------------
            string codigo = string.Empty;
          
            var documento = DocumentoLogic.Instance.ObtenerDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, txtCodTipoDocumento.Text.Trim(),
                            txtNumeroDoc.Text.Trim());
            if (documento == null)
            {
                RadMessageBox.Show("Debe registrar el registro para agregar ordenes de trabajo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            
            if (txtCodProceso.Text.Trim() == "" || txtDesProceso.Text == "???")
            {
                RadMessageBox.Show("Para registrar una Orden de Trabajo debe ingresar proceso", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            //--------------------------------------------------------------------------------------------------------------------------------------
            
            //obtengo el codigo de una nueva OT            
            OrdenTrabajoLogic.Instance.TraerNumeroOT(Logueo.CodigoEmpresa, out codigo);
            
            if (gridOrdenTrabajo.Rows.Count == 0)
            {

                //--------------------------------------------------AGREGAR NUEVA FILA ----------------------------------------------------------
                GridViewRowInfo rowInfo = gridOrdenTrabajo.Rows.AddNew();
                rowInfo.Cells["codigo"].Value = codigo;
                //Fila en modo edicion
                rowInfo.Cells["flag"].Value = "0";
                
                
                //Resaltar ayuda Color: Amarillo.
                Util.ResaltarAyuda(rowInfo.Cells["productoObjetivo"]);
                Util.ResaltarAyuda(rowInfo.Cells["DesTipoOT"]);
                //Dar foco a la descripcion del producto 
                this.gridOrdenTrabajo.CurrentRow.Cells["productoObjetivo"].IsSelected = true;
                
            }
            else
            {
                if (gridOrdenTrabajo.Rows[gridOrdenTrabajo.Rows.Count - 1].Cells["codigoProducto"].Value == null)
                {
                    RadMessageBox.Show("Completar el registro actual", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                if (gridOrdenTrabajo.Rows[gridOrdenTrabajo.Rows.Count - 1].Cells["OrigenMP"].Value == null)
                {
                    RadMessageBox.Show("Completar el registro actual","Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                    
                //-------------------------------------------------VALIDAR MP SIN CONSUMIR----------------------------------------------------------
                string TipdocCodigo = this.txtCodTipoDocumento.Text.Trim();
                string DocuCodigo = this.txtNumeroDoc.Text.Trim();
                string OrdenTrabajoCodigo = Util.GetCurrentCellText(gridOrdenTrabajo, "codigo");
                string transaccion = esEntrada ? "E" : "S";
                string linea = txtCodLinea.Text.Trim();
                string actividad = txtCodProceso.Text.Trim();
                string mensaje = "";
                int flag = 0;
                DocumentoLogic.Instance.ValidarMPSinConsumir(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, TipdocCodigo,
                DocuCodigo, OrdenTrabajoCodigo, transaccion, linea, actividad, out mensaje, out flag);
                if (flag == -1)
                {
                    Util.ShowAlert(mensaje);
                    return;
                }
                //------------------------------------------------------------------------------------------------------------------------------------
                
                //-----------------------------------------------------AGREGAR NUEVA LINEA------------------------------------------------------------
                GridViewRowInfo rowInfo = gridOrdenTrabajo.Rows.AddNew();
                rowInfo.Cells["codigo"].Value = codigo;
                //Fila en modo edicion
                rowInfo.Cells["flag"].Value = "0";
                
                //Resaltar ayuda Color: Amarillo.
                Util.ResaltarAyuda(rowInfo.Cells["productoObjetivo"]);
                Util.ResaltarAyuda(rowInfo.Cells["DesTipoOT"]);
                //Dar foco a la descripcion de producto.                
                this.gridOrdenTrabajo.CurrentRow.Cells["productoObjetivo"].IsSelected = true;                
            }
            gridOrdenTrabajo.Focus();
            SendKeys.Send("{TAB}"); 
                                                            
        }
        private void gridOrdenTrabajo_CellMouseMove(object sender, MouseEventArgs e)
        {
            GridCellElement cell = this.gridOrdenTrabajo.ElementTree.GetElementAtPoint(e.Location) as GridCellElement;
            if (cell != null && cell.Value != null)
            {

                cell.ToolTipText = Util.convertiracadena(cell.Value);
            }
        }
        #endregion
        //----------------------------------------------------------------------------CONTROLES DE MATERIA PRIMA------------------------------------------------------------------
        #region "Controles Materia Prima"
        private void btnAddMateria_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!validarControlOT()) return;
                
                if (gridMateriaPrima.Rows.Count > 0) {
                    if (gridMateriaPrima.CurrentRow.Cells[0].Value == null)
                    {
                        RadMessageBox.Show("Completar Registro", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                }

                this.gridMateriaPrima.Focus();
                this.gridMateriaPrima.Rows.AddNew();

                //Establecer la columna pr defecto para el foco
                this.gridMateriaPrima.CurrentRow = this.gridMateriaPrima.CurrentRow;
                this.gridMateriaPrima.CurrentColumn = this.gridMateriaPrima.Columns["IN07NROCAJA"];                

                //Traer el alamcen por defectro
                var almacen = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa,txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim()).almacenMP;
                //Asignar a celda almacen valor desde base de datos 
                this.gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value = almacen;
                
                
                //Resaltar celdas de ayuda Color : Amarillo                
                Util.ResaltarAyuda(this.gridMateriaPrima.CurrentRow.Cells["IN07CODALM"]);                
                Util.ResaltarAyuda(this.gridMateriaPrima.CurrentRow.Cells["IN07NROCAJA"]);
                
            }
            catch (Exception ex) { 
            
            }
          
        }
        private void mostrarAyudaMP(enmAyuda tipo) {
            string codigoAlmacen = "";
            frmBusqueda frm;
            string codigoSeleccionado = "";
            string FlagDeValidacion = "1";
            string FlagDeretorno = "0";

            switch (tipo) 
            {
                case enmAyuda.enmAlmacen:
                  if (esEntrada == true)
                    {
                        frm = new frmBusqueda(enmAyuda.enmAlmacen);
                    }
                    else {
                        var actividad = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim());
                        frm = new frmBusqueda(enmAyuda.enmAlmacenxNaturaleza, actividad.NATURALEZAALM);
                    }
                    
                    frm.Owner = this;
                    frm.ShowDialog();
                   
                    if (frm.Result!= null) 
                    {
                        if (FrmParent.rbIngreso.IsChecked)
                        {
                            //ayuda de almacen para materia prima                                                        
                           //this.gridMateriaPrima.CurrentRow.Cells["codigoAlmacen"].Value = frm.Result.ToString();                            
                            this.gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value = frm.Result.ToString();
                        }                        
                    }
                    break;
                 case enmAyuda.enmCanastillasMultipleMP:
                    Cursor.Current = Cursors.WaitCursor;
                    //string codigoAlmacen = ""; 
                    //codigoAlmacen = gridMateriaPrima.CurrentRow.Cells["codigoAlmacen"].Value.ToString();
                    codigoAlmacen = gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value.ToString();
                    //var proceso = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa,txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim());

                    if (codigoAlmacen == "") return;

                    frm = new frmBusqueda(enmAyuda.enmCanastillasMultipleMP, codigoAlmacen, null, 1000, 474); // Cuando la naturaleza es 01: MP,entonces traig bloque

                    frm.Owner = this;
                    frm.ShowDialog();
                    Cursor.Current = Cursors.Default;

                    if (Util.convertiracadena(frm.Result) != "")
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {

                            var seleccionados = (List<Spu_Inv_Trae_StockDetMPTodos>)frm.Result;
                            string[] registros = new string[seleccionados.Count];
                            int x = 0;

                            foreach (Spu_Inv_Trae_StockDetMPTodos fila in seleccionados)
                            {

                                registros[x] = Logueo.CodigoEmpresa + "|" + fila.DocingAA + "|" + fila.DocingMM + "|" + fila.DocingTD + "|" + fila.DocingCD + "|" +
                                                fila.DocingMP + "|" + fila.DocingNO + "|" + fila.StockRealVolumen + "|" + "" + "|" + "";
                                x++;
                            }
                            string ordenTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                            string mensaje = string.Empty;
                            FlagDeValidacion = "0";

                            DocumentoLogic.Instance.SalidasProductosProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                                    string.Format("{0:yyyyMMdd}", dtpFechaOT.Value),
                                                                                    ordenTrabajo, Logueo.OrigentTipo_Automatico,
                                                                                    Util.ConvertiraXMLMateriaPrima(registros),
                                                                                    FlagDeValidacion, out FlagDeretorno, out mensaje);


                            if (mensaje != "")
                            {
                                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }

                        }
                        //cargarMateriaPrima();
                        CargarMPResumido();
                    }

                    break;


                case enmAyuda.enmCanastillasMultiplePP:
                    Cursor.Current = Cursors.WaitCursor;

                    codigoAlmacen = gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value.ToString();

                    if (codigoAlmacen == "") return;


                    frm = new frmBusqueda(enmAyuda.enmCanastillasMultiplePP, codigoAlmacen, null, 1000, 474); // indico si es canastilla de Productos en proceso

                    frm.Owner = this;
                    frm.ShowDialog();

                    Cursor.Current = Cursors.Default;

                    if (Util.convertiracadena(frm.Result) != "")
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {

                            var seleccionados = (List<Spu_Pro_Trae_PPStock>)frm.Result;
                            string[] registros = new string[seleccionados.Count];
                            int x = 0;

                            foreach (Spu_Pro_Trae_PPStock fila in seleccionados)
                            {
                                registros[x] = Logueo.CodigoEmpresa + "|" + 
                                                fila.DocingAA + "|" + 
                                                fila.DocingMM + "|" + 
                                                fila.DocingTD + "|" + 
                                                fila.DocingCD + "|" + 
                                                fila.DocingPT + "|" + 
                                                fila.DocingNO + "|" + 
                                                fila.CanPiezas + "|" +
                                                fila.OrdenTrabajo + fila.nrocaja + fila.HoraSalida + "|" +
                                                "";
                                x++;
                            }

                            string ordenTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                            string mensaje = string.Empty;

                            FlagDeValidacion = "0";
                            DocumentoLogic.Instance.SalidasProductosProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                              string.Format("{0:yyyyMMdd}", dtpFechaOT.Value),
                                                                              ordenTrabajo, Logueo.OrigentTipo_Automatico,
                                                                              Util.ConvertiraXMLMateriaPrima(registros),
                                                                              FlagDeValidacion, out FlagDeretorno,
                                                                              out mensaje);                           

                            if (mensaje != "")
                            {
                                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                        }
                        //cargarMateriaPrima();
                        CargarMPResumido();
                    }


                    break;
                    
                default:
                    break;
            }
        }
        private void mostrarAyudaMPConParametros(enmAyuda tipo, string filtro = "", string campo = "")
        {
            string codigoAlmacen = "";
            frmBusqueda frm;
            string codigoSeleccionado = "";
            string FlagDeValidacion = "1";
            string FlagDeretorno = "0";

            switch (tipo)
            {
                case enmAyuda.enmCanastillasMultipleMPConParametros:
                    Cursor.Current = Cursors.WaitCursor;
                    codigoAlmacen = gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value.ToString();

                    if (codigoAlmacen == "") return;

                    frm = new frmBusqueda(enmAyuda.enmCanastillasMultipleMPConParametros,
                    codigoAlmacen + "|" + filtro + "|" + campo, null, 1000, 474); // Cuando la naturaleza es 01: MP,entonces traig bloque

                    frm.Owner = this;
                    frm.ShowDialog();
                    Cursor.Current = Cursors.Default;

                    if (Util.convertiracadena(frm.Result) != "")
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {

                            var seleccionados = (List<Spu_Inv_Trae_StockDetMPTodos>)frm.Result;
                            string[] registros = new string[seleccionados.Count];
                            int x = 0;

                            foreach (Spu_Inv_Trae_StockDetMPTodos fila in seleccionados)
                            {

                                registros[x] = Logueo.CodigoEmpresa + "|" + fila.DocingAA + "|" + fila.DocingMM + "|" + fila.DocingTD + "|" + fila.DocingCD + "|" +
                                                fila.DocingMP + "|" + fila.DocingNO + "|" + fila.StockRealVolumen + "|" + "" + "|" + "";
                                x++;
                            }
                            string ordenTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                            string mensaje = string.Empty;
                            FlagDeValidacion = "0";

                            DocumentoLogic.Instance.SalidasProductosProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                                    string.Format("{0:yyyyMMdd}", dtpFechaOT.Value),
                                                                                    ordenTrabajo, Logueo.OrigentTipo_Automatico,
                                                                                    Util.ConvertiraXMLMateriaPrima(registros),
                                                                                    FlagDeValidacion, out FlagDeretorno, out mensaje);


                            if (mensaje != "")
                            {
                                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }

                        }
                        //cargarMateriaPrima();
                        CargarMPResumido();
                    }

                    break;
                default:
                    break;
            }
        }


        private void habilitarBotonMateriaPrima(string nombre, GridCommandCellElement CommandCell,
                                                 bool bEliminar)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnEliminarMat":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                default:
                    break;
            }
        }
        private void gridMateriaPrima_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridMateriaPrima.Columns["btnEliminarMat"].IsCurrent)
            {
                EliminarMateriaPrima();
            }
        }        
        private void gridMateriaPrima_KeyDown(object sender, KeyEventArgs e)
        {
            if (Estado == FormEstate.View || Estado == FormEstate.List) return;

            string Almacenseleccionado = gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value.ToString();

            string NaturalezaAlmacenSeleccionado;
            ActividadNivel1Logic.Instance.TraerNaturalezaDeAlmacen(Logueo.CodigoEmpresa, Almacenseleccionado, 
                                                                            out NaturalezaAlmacenSeleccionado);

            if (e.KeyValue == (char)Keys.F1)
            {
                // Traer materia prima               
                if (this.gridMateriaPrima.CurrentColumn.Index == gridMateriaPrima.CurrentRow.Cells["IN07NROCAJA"].ColumnInfo.Index)
                {                    
                    if (NaturalezaAlmacenSeleccionado == Logueo.MP_codnaturaleza)
                        mostrarAyudaMP(enmAyuda.enmCanastillasMultipleMP);
                    else if (NaturalezaAlmacenSeleccionado == Logueo.PP_codnaturaleza)                        
                        mostrarAyudaMPResumido(enmAyuda.enmCanastMultiPPResumido);
                }
                else
                    if (this.gridMateriaPrima.CurrentColumn.Index == gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].ColumnInfo.Index)
                       { mostrarAyudaMPResumido(enmAyuda.enmAlmacen); }  
            }
            else if (e.KeyValue == (char)Keys.F2)
            { 
                if  (this.gridMateriaPrima.CurrentColumn.Index == gridMateriaPrima.CurrentRow.Cells["IN07NROCAJA"].ColumnInfo.Index)
                {
                    if (NaturalezaAlmacenSeleccionado == Logueo.MP_codnaturaleza)
                    {
                        string nroCanastilla = "";
                        nroCanastilla = RadInputBox.Show("Ingresar numero de canastilla", "");
                        if (nroCanastilla != "")
                        {
                            mostrarAyudaMPConParametros(enmAyuda.enmCanastillasMultipleMPConParametros, nroCanastilla, "Canastilla");
                        }
                    }
                }

            
            }

        }        
        private void gridMateriaPrima_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;
            if (Estado == FormEstate.View) {
                habilitarBotonMateriaPrima(e.Column.Name, cellElement, false);                
                return;
            }
            habilitarBotonMateriaPrima(e.Column.Name, cellElement, true);
            
        }
        #endregion
        //----------------------------------------------------------------------------metodos de DETALLE  DE DOCUMENTO----------------------------------------------------------------
        #region "Metodos Detalle documento"

        private void gridControl_CellMouseMove(object sender, MouseEventArgs e)
        {

            GridCellElement cell = this.gridControl.ElementTree.GetElementAtPoint(e.Location) as GridCellElement;
            if (cell != null && cell.Value != null)
            {

                cell.ToolTipText = Util.convertiracadena(cell.Value);
            }

        }

        void enfocarRegistro() {
            FrmParent.gridControl.MasterView.Rows[fila].IsCurrent = true;
            FrmParent.gridControl.MasterView.Rows[fila].IsSelected = true;
        }
        void asignarValores()
        {

            this.codigoDocumento = FrmParent.gridControl.MasterView.Rows[fila].Cells["Numero"].Value.ToString();
            this.tipoDocumento = FrmParent.gridControl.MasterView.Rows[fila].Cells["CodTipDoc"].Value.ToString();

            cargarCabeceraDocumento();
            CargarOrdenTrabajo();
            enfocarRegistro();

            habilitarControles(false);

            btnAddOT.Visible = false;
            btnAddMateria.Visible = false;
            btnAdd.Visible = false;
            
            
        }
        void inserciondinamica()
        {
            esInsercion = true;
            object[,] datos;

            int insertionIndexRow = this.gridControl.CurrentRow.Index;
            int lastIndexRow = this.gridControl.Rows[this.gridControl.Rows.Count - 1].Index;
            int rowcount = (lastIndexRow + 1) - insertionIndexRow;
            datos = new object[rowcount, this.gridControl.Columns.Count];
            //copiar datos
            for (int x = 0; x < rowcount; x++)
            {
                for (int y = 0; y < this.gridControl.Columns.Count; y++)
                    datos[x, y] = this.gridControl.Rows[insertionIndexRow + x].Cells[y].Value;
            }


            // ==================================================== limpiar fila ================================================================================
            for (int c = 0; c < this.gridControl.Columns.Count; c++)
            {
                this.gridControl.CurrentRow.Cells[c].Value = null;
            }

            //
            // ==================================================== Agregar nueva fila ===========================================================================
            this.gridControl.Rows.AddNew();

            // ============================================================== pegar datos ========================================================================         
            for (int f = 1; f < rowcount + 1; f++)
            {
                for (int c = 0; c < this.gridControl.Columns.Count; c++)
                {
                    this.gridControl.Rows[insertionIndexRow + f].Cells[c].Value = datos[(f - 1), c];
                }
            }
            this.gridControl.Rows[insertionIndexRow].IsCurrent = true;
            GridViewRowInfo rowInfo = this.gridControl.CurrentRow;
            // ====================================================== Iniciar valores de nueva Fila ============================================================== 
            // ============================================================== Editar Fila ========================================================================
            this.gridControl.CurrentRow.Cells["flag"].Value = "0";

            // ============================================================== Resaltar ayuda =====================================================================            
            Util.ResaltarAyuda(rowInfo.Cells["CodigoAlmacen"]);
            Util.ResaltarAyuda(rowInfo.Cells["Operador"]);  // provmatprimaNombre
            Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);
            rowInfo.Cells["CodigoArticulo"].Value = null;

            string codigodeAlmacen = "";
            ActividadNivel1Logic.Instance.TraerAlmacenxProceso(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim(), out codigodeAlmacen);

            rowInfo.Cells["Orden"].Value = 0;
            rowInfo.Cells["CodigoAlmacen"].Value = codigodeAlmacen;// --> PRO09ALMACENCOD                                                            
            rowInfo.Cells["IN07HORASALIDA"].Value = "00:00";
            rowInfo.Cells["IN07FECHAPROCESO"].Value = this.dtpFechaOT.Value;

            // ============================================ Asignar valor a de nro caja a celda  ==================================================================
            string cajaUnica = Util.GetCurrentCellText(gridMateriaPrima, "CajaUnica");
            rowInfo.Cells["CajaUnica"].Value = cajaUnica;

            string cajaIngreso = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
            rowInfo.Cells["IN07NROCAJAINGRESO"].Value = cajaIngreso;

            // ============================================ Enfocar celda por Tipo de transaccion =================================================================
            if (FrmParent.rbIngreso.IsChecked)
            {
                this.gridControl.CurrentColumn = this.gridControl.Columns["Operador"];
                rowInfo.Cells["Operador"].BeginEdit();
            }
            else
            {
                this.gridControl.CurrentColumn = this.gridControl.Columns["NroCaja"];
                rowInfo.Cells["NroCaja"].BeginEdit();
            }
        }       
        void seleccionarFilasxCajaMP(string codigoCaja)
        {
            for (int i = 0; i < gridMateriaPrima.Rows.Count; i++)
            { 
                
            }
        }
        void sumaVolumenxAlmacen()
        {
            
            foreach (GridViewRowInfo row in this.gridControl.Rows)
            { 
                
            }
        }
        protected override void OnPrimero()
        {
            fila = 0;
            asignarValores();

        }
        protected override void OnSiguiente()
        {
            if (fila == FrmParent.gridControl.MasterView.Rows.Count - 1 
                || fila == FrmParent.gridControl.MasterView.ChildRows.Count - 1)
                return;
            fila++;
            asignarValores();         
        }
        protected override void OnAnterior()
        {
            if (fila == 0) return;
            fila--;
            asignarValores();
        }
        protected override void OnUltimo()
        {
            fila = FrmParent.gridControl.MasterView.Rows.Count - 1;
            asignarValores();         
        }
        
        #endregion
        //=================================================================== metodos Grilla DETALLE  DE DOCUMENTO ===========================================================
        #region "Metodos Grilla Detalle Documento"

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if (e.CurrentRow == null) return;
                if (e.CurrentRow.Cells["Orden"] == null) return;
                if (e.CurrentRow.Cells["flag"] == null) return;
                
            }
            catch (Exception ex)
            {

            }
        }        
        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            
            try
            {
                
                    if (this.gridControl.ActiveEditor == null) return;
                                                          
                    if (this.Estado == FormEstate.View) { e.Cancel = true; return; }
                  
                    
                    if (this.gridControl.Rows[e.RowIndex].Cells["flag"].Value == null) { e.Cancel = true; return; }                                    
                    
                    //Capturo la Fila Actual y La Columna Actual
                    GridViewRowInfo row = this.gridControl.CurrentRow;
                    GridViewColumn col = this.gridControl.CurrentColumn;
                

                    if (esEntrada == true)
                    {
                        //Celda de Articulo debe ser diferente de nulo o vacio
                        string cCodigoArticulo = Util.convertiracadena(row.Cells["CodigoArticulo"].Value);
                        if (cCodigoArticulo != "") 
                        {
                            string codigoArticulo = cCodigoArticulo;

                            Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo);
                            row.Cells["Ancho"].ReadOnly = articulo.anchotext.ToUpper() == "ESP" ? false : true;
                            row.Cells["Largo"].ReadOnly = articulo.largotext.ToUpper() == "ESP" ? false : true;
                            row.Cells["Alto"].ReadOnly = articulo.espesortext.ToUpper() == "ESP" ? false : true;
                        }
                        
                        //El 0 indico es modo editable ,si es diferente de este no debe permitir editar 
                        //Las celdas Codigo de Almacen y Codigo de Articulo.
                        // Si el flag es modo actualizacion de registro
                        if(Util.GetCurrentCellDbl(row,"Orden") != 0)
                        {
                            //No permitir edicion de cleda de codigo almacen, codigo articulo y nro de caja ingreso
                            if (row.Cells["CodigoAlmacen"].ColumnInfo.Index == this.gridControl.CurrentColumn.Index) { e.Cancel = true; }
                            if (row.Cells["CodigoArticulo"].ColumnInfo.Index == this.gridControl.CurrentColumn.Index) { e.Cancel = true; }
                            if (row.Cells["IN07NROCAJAINGRESO"].ColumnInfo.Index == this.gridControl.CurrentColumn.Index) { e.Cancel = true; }

                        }
                        
                        // Si celda esta en modo insercion de registro
                        if (Util.GetCurrentCellDbl(row, "Orden") == 0)
                        {
                            if (row.Cells["IN07NROCAJAINGRESO"].ColumnInfo.Index == this.gridControl.CurrentColumn.Index) { e.Cancel = true; } 
                        }

                    }
                    else
                    {
                         e.Cancel = col.Name == "Largo" || col.Name == "Ancho" || col.Name == "Alto" ? true : false;                        
                        if (Convert.ToDouble(row.Cells["Orden"].Value) != 0)
                        {
                            if (row.Cells["CodigoAlmacen"].ColumnInfo.Index == this.gridControl.CurrentColumn.Index) 
                                { e.Cancel = true; }
                            if (row.Cells["NroCaja"].ColumnInfo.Index == this.gridControl.CurrentColumn.Index) 
                                { e.Cancel = true; }
                            e.Cancel = col.Name == "CodigoAlmacen" || col.Name == "NroCaja" ? true : false;
                        }

                    }

             
                
            }
            catch (Exception ex) { 
            
            }
          
        }
		private void limpiarCeldas(GridViewRowInfo CurrentSelectedRow)
        {
            GridViewRowInfo row = CurrentSelectedRow;
            Util.SetClearCurrentCellText(row, "CodigoArticulo");
            Util.SetClearCurrentCellText(row, "DescripcionArticulo");
            Util.SetClearCurrentCellText(row, "UnidadMedida");
            Util.SetClearCurrentCellInt(row, "Ancho");
            Util.SetClearCurrentCellInt(row, "Largo");
            Util.SetClearCurrentCellInt(row, "Alto");
            //Util.SetClearCurrentCellInt(row, "Cantidad");
            Util.SetClearCurrentCellInt(row, "Areaxuni");
        }
        
        //Evento de celda para ver si es diferente al nuevo valor a ingresa a la celda.
        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                GridViewRowInfo info = this.gridControl.CurrentRow;
                if (e.Column.Name == "CodigoAlmacen")
                {
                    obtenerDescripcion(enmAyuda.enmAlmacen);
                    string cValorActual = Util.convertiracadena(this.gridControl.CurrentCell.Value);
                    string cValorNuevo = Util.convertiracadena(e.Value);
                    //si limpio el valor de la celda es limpiado 
                    if (cValorNuevo == "" || cValorActual == "")
                    {
                        limpiarCeldas(info);
                        return;
                    }
                   // si el codigo de almacen es diferente del almacen actual                    
                    string cCodigoArticulo = Util.GetCurrentCellText(info, "CodigoArticulo");
                    string cCodigoAlmacen = Util.GetCurrentCellText(info, "CodigoAlmacen");
                    string outCodigoArticulo = "";
                    DocumentoLogic.Instance.TraerValidacionArtixAlm(Logueo.codModulo, Logueo.Mes,
                                Logueo.Anio, cCodigoAlmacen, cCodigoArticulo, out outCodigoArticulo);

                    if (Util.convertiracadena(outCodigoArticulo) == "") limpiarCeldas(info);                    
                }

                //--  Evento para celda de CodigoArticulo
                if (e.Column.Name == "CodigoArticulo")
                {
                    string cValorActual = Util.convertiracadena(this.gridControl.CurrentCell.Value);
                    string cValorNuevo = Util.convertiracadena(e.Value);
                    if (cValorNuevo == "" || cValorActual == "") return;
                    if (cValorNuevo != cValorActual)
                    {
                        info.Cells["DescripcionArticulo"].Value = null;
                        info.Cells["UnidadMedida"].Value = null;
                        info.Cells["Ancho"].Value = 0;
                        info.Cells["Largo"].Value = 0;
                        info.Cells["Alto"].Value = 0;
                        info.Cells["Cantidad"].Value = 0;
                        info.Cells["Areaxuni"].Value = 0;
                    }
                }
                // -- evento para columna motivo 
                if (e.Column.Name == "DesMotivo")
                {
                    string cValorNuevo = Util.convertiracadena(e.Value);
                    if (cValorNuevo  == "")
                        info.Cells["IN07MOTIVOCOD"].Value = null;                                                                
                }              

                // -- Evento para columna Turno
                if (e.Column.Name == "in07prodTurnoCod")
                {
                    string cValorNuevo = Util.convertiracadena(e.Value);
                    string cValorActual = Util.convertiracadena(this.gridControl.CurrentCell.Value);
                    if (cValorNuevo == "" || cValorActual == "") return;
                    if (cValorNuevo != cValorActual)
                    {
                        string descripcion = "";

                        string cProdTurnoCod = Util.GetCurrentCellText(gridControl, "in07prodTurnoCod");
                        string codigo = Logueo.CodigoEmpresa + cProdTurnoCod;
                        GlobalLogic.Instance.DameDescripcion(codigo, "TURNO", out descripcion);
                        this.gridControl.CurrentRow.Cells["in07prodturnoDesc"].Value = descripcion;
                    }
                }

                if (e.Column.Name == "IN07MOTIVOCOD")
                {
                    string descripcion = "";
                    string codigo = "";

                    string cMotivoCod = Util.GetCurrentCellText(gridControl, "IN07MOTIVOCOD");

                    codigo = Logueo.CodigoEmpresa + cMotivoCod;
                    GlobalLogic.Instance.DameDescripcion(codigo, "MOTIVO", out descripcion);
                    this.gridControl.CurrentRow.Cells["DesMotivo"].Value = descripcion;
                }
                if (e.Column.Name == "CajaUnica")
                {
                    //relacionarDetalleconMP();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void gridControl_KeyUp(object sender, KeyEventArgs e)
        {
            //Metodo para grabar presionando enter
            if (e.KeyValue == (char)Keys.Enter)
                //Si mi columna enfocada es grabar detalle
                if (this.gridControl.CurrentColumn.Name ==
                    this.gridControl.Columns["btnGrabarDet"].Name) GuardarDetProducto(this.gridControl.CurrentRow);
            //Luego de guardar exitoso o no , enfocar a al celda de Hora Incio
            
        }
        #endregion
        //=================================================================== EVENTOS GRILLA MATERIA PRIMA ===================================================================
        #region "Eventos Grilla Materia Prima"
        private void relacionarMPConDetalle()
        {
            if (gridMateriaPrima.Rows.Count == 0) return;
            if (gridControl.Rows.Count == 0) return;
            // ===== Limpiar filas de color resaltado 
            gridControl.ClearSelection();

            string nroCajaMP = Util.GetCurrentCellText(gridMateriaPrima.CurrentRow, "CajaUnica");

            if (nroCajaMP != "")
                foreach (GridViewRowInfo row in gridControl.Rows)
                {
                    string nroCajaDet = Util.GetCurrentCellText(row, "CajaUnica");
                    if (nroCajaMP == nroCajaDet) row.IsSelected = true;
                } 
        }
        private void relacionarDetalleconMP()
        {
            if (gridMateriaPrima.Rows.Count == 0) return;
            if (gridControl.Rows.Count == 0) return;
            // ===== Limpiar filas de color resaltado 
            gridMateriaPrima.ClearSelection();

            string nroCajaDet = Util.GetCurrentCellText(gridControl.CurrentRow, "CajaUnica");

            if (nroCajaDet != "")
                foreach (GridViewRowInfo row in gridMateriaPrima.Rows)
                {
                    string nroCajaMP = Util.GetCurrentCellText(row, "CajaUnica");
                    if (nroCajaMP == nroCajaDet)
                    {
                        row.IsSelected = true;
                        row.IsCurrent = true;
                    }
                }
        }
        void gridMateriaPrima_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            relacionarMPConDetalle();
        }
        void gridMateriaPrima_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (gridMateriaPrima.Rows.Count == 0) return;
            if (gridMateriaPrima.CurrentRow == null) return;
            if (e.CurrentRow == null) return;
            string flagDetDocumento = Util.GetCurrentCellText(gridControl, "flag"); // ver si flag de detalle documento es modo edicion

            // si es diferente de vacio entonces cancelar evento de rowChanging            
            if (flagDetDocumento != "") e.Cancel = true;
                
        }
        private void gridMateriaPrima_CellValueChanged(object sender, GridViewCellEventArgs e)
        {           
            //asginar nombre de almacen , si cambio el valor del campo codigo de almacen
            string cCodigoAlmacen = Util.convertiracadena(e.Row.Cells["IN07CODALM"].Value);

            if ( cCodigoAlmacen != "")
            {
                string descripcion = string.Empty;                
                string codigo = Logueo.CodigoEmpresa + cCodigoAlmacen;

                GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);             
                e.Row.Cells["in09descripcion"].Value = descripcion;
            }
        }
        private void gridMateriaPrima_CellMouseMove(object sender, MouseEventArgs e)
        {
            GridCellElement cell = this.gridMateriaPrima.ElementTree.GetElementAtPoint(e.Location) as GridCellElement;
            if (cell != null && cell.Value != null)  cell.ToolTipText = Util.convertiracadena(cell.Value);            
        }
        #endregion

        // =================================================================== Formulario de ingreso masivo=================================================================== 
        #region "Formulario Ingreso Masivo"
        object[] valores = null;
        private Point MouseDownLocation;
        //metodos de4 la grilla masiva
        private void inicializarModalIngMasivo() {
            try
            {
                this.gridExcel.Focus();
                if (this.gridExcel.Columns.Count == 0) 
                {
                    this.crearColumnasModal();
                    crearColumnasMensaje();
                }
                if (this.gridExcel.Rows.Count == 0) {
                    this.agregarFilasIngresoMasivo();
                }
                string codigodeAlmacen = "";
                if (txtCodLinea.Text.Trim() != "" && txtCodProceso.Text.Trim() != "")
                {
                    ActividadNivel1Logic.Instance.TraerAlmacenxProceso(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim(), out codigodeAlmacen);
                }
                                 
                    GridViewRowInfo info = this.gridExcel.Rows[0];

                    // iniciando variables
                    info.Cells["CodigoAlmacen"].Value = codigodeAlmacen;                    
                    info.Cells["MTS3"].Value = 0;
                    info.Cells["MTS2"].Value = 0;                    
                    info.Cells["Cantidad"].Value = 0;
                    info.Cells["Area"].Value = 0;
                    info.Cells["Areaxuni"].Value = 0;
                   
                    this.gridExcel.CurrentColumn = this.gridExcel.Columns["CodigoArticulo"];
                    info.Cells["CodigoArticulo"].BeginEdit();                
                
              
            }
            catch (Exception ex) { 
                
            }
            //this.gridExcel.SelectionMode = GridViewSelectionMode.FullRowSelect;
        }
        private void crearColumnasModal()
        {
            RadGridView gridExcel = this.CreateGridVista(this.gridExcel);
            this.CreateGridColumn(gridExcel, "Codigo", "codigoOperador", 0, "", 70, true, false, false);            
            this.CreateGridDateColumn(gridExcel, "Fecha", "IN07FECHAPROCESO", 0, "{0:dd/MM/yyyy}", 70, false, true);            
            this.CreateGridColumn(gridExcel, "Operador", "Operador", 0, "", 100, true, false, esEntrada);
            // Turno 
            this.CreateGridColumn(this.gridExcel, "Turno", "in07prodTurnoCod", 0, "", 90, true, false, false);
            this.CreateGridColumn(this.gridExcel, "Turno.Desc.", "in07prodTurnoDesc", 0, "", 90, true, false, true);

            this.CreateGridColumn(gridExcel, "H.Ini", "IN07HORAINICIO", 0, "", 60, false, true);
            ((GridViewTextBoxColumn)this.gridExcel.Columns["IN07HORAINICIO"]).MaxLength = 5;

            this.CreateGridColumn(gridExcel, "H.Fin", "IN07HORAFINAL", 0, "", 60, false, true);
            ((GridViewTextBoxColumn)this.gridExcel.Columns["IN07HORAFINAL"]).MaxLength = 5;

            this.CreateGridColumn(gridExcel, "#Cana.Ing", "IN07NROCAJAINGRESO", 0, "", 70, false, true);
            this.CreateGridColumn(gridExcel, "Cantidad", "Cantidad", 0, "{0:###,###0.00}", 60, false, false, true, true, "right");

            this.CreateGridColumn(gridExcel, "Cod.Bloque", "CodigoBloque", 0, "", 140, false, true, false);            
            this.CreateGridColumn(gridExcel, "CodMaquina", "CodMaquina", 0, "", 140, false, true, false);            
            this.CreateGridColumn(gridExcel, "Maquina", "DesMaquina", 0, "", 140, false, true, false);            

            this.CreateGridColumn(gridExcel, "Almacén", "CodigoAlmacen", 0, "", 50, false, true, true);
            this.CreateGridColumn(gridExcel, "Código Producto", "CodigoArticulo", 0, "", 150, true, true);
            this.CreateGridColumn(gridExcel, "Descripción", "DescripcionArticulo", 0, "", 180, true, true, true);
            this.CreateGridColumn(gridExcel, "UM", "UnidadMedida", 0, "", 60, true, false, true);

            this.CreateGridColumn(gridExcel, "Largo", "Largo", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(gridExcel, "Ancho", "Ancho", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(gridExcel, "Espesor", "Alto", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");

            
            this.CreateGridColumn(gridExcel, "Areaxuni", "Areaxuni", 0, "{0:###,###0.00}", 90, false, false, false, true, "right");
            this.CreateGridColumn(gridExcel, "Orden", "Orden", 0, "{0:###,###0.00}", 70, true, false, false, true, "right");
            this.CreateGridColumn(gridExcel, "MTS2", "MTS2", 0, "{0:###,###0.00}", 40, true, false, false, true, "right");
            this.CreateGridColumn(gridExcel, "MTS3", "MTS3", 0, "{0:###,###0.00}", 40, true, false, false, true, "right");
            this.CreateGridColumn(gridExcel, "Area", "Area", 0, "{0:###,###0.00}", 40, false, false, false, true, "right");
            //this.CreateGridColumn(gridExcel, "Acabado", "Acabado", 0,"", 60);
            this.CreateGridColumn(gridExcel, "#Cana/Blo", "NroCaja", 0, "", 80, false, true, true, false, "right");
            this.CreateGridColumn(gridExcel, "H.Sal", "IN07HORASALIDA", 0, "", 60, false, true);
            ((GridViewTextBoxColumn)this.gridExcel.Columns["IN07HORASALIDA"]).MaxLength = 5;
            this.CreateGridColumn(gridExcel, "flag", "flag", 0, "", 30, false, true, false);


            //  Agrega filas ocultas para capturar los ingresos de las salidas

            this.CreateGridColumn(gridExcel, "IN07DocIngAA", "IN07DocIngAA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridExcel, "IN07DocIngMM", "IN07DocIngMM", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridExcel, "IN07DocIngTIPDOC", "IN07DocIngTIPDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridExcel, "IN07DocIngCODDOC", "IN07DocIngCODDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridExcel, "IN07DocIngKEY", "IN07DocIngKEY", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridExcel, "IN07DocIngORDEN", "IN07DocIngORDEN", 0, "", 0, true, false, false, true);
            this.CreateGridColumn(gridExcel, "CodMotivo", "IN07MOTIVOCOD", 0, "", 60, true, false, false);
            this.CreateGridColumn(gridExcel, "Motivo", "DesMotivo", 0, "", 120,false, true);
            //    Movimiento m = new Movimiento();
            
            this.gridExcel.SelectionMode = GridViewSelectionMode.CellSelect;

            this.gridExcel.MultiSelect = true;

        }
        void crearColumnasMensaje()
        {
            RadGridView Grid = this.CreateGridVista(this.gridMensaje);
            this.CreateGridColumn(Grid, "Fila", "fila", 0, "", 100);
            this.CreateGridColumn(Grid, "Mensaje", "mensaje", 0, "", 500);
        }
        void cargarMensaje()
        {
            string ordTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();            
            this.gridMensaje.DataSource = DocumentoLogic.Instance.cargarMensajeValidacion(Logueo.CodigoEmpresa, Logueo.UserName, 
                                    Logueo.Anio, Logueo.Mes, txtCodTipoDocumento.Text.Trim(),txtNumeroDoc.Text.Trim(), ordTrabajo);
        }
        void agregarFilasIngresoMasivo()
        {
            for (int i = 0; i <= 40; i++)
            {
                this.gridExcel.Rows.AddNew();
            }
            gridExcel.Rows[0].Cells["IN07FECHAPROCESO"].Value = dtpFechaOT.Value;            
        }        
        private void mostrarDescripcionIngMasiva(enmAyuda tipo, string codigo)
        {
            string descripcion = "";
            switch (tipo)
            {
                case enmAyuda.enmProductoXAlmacen:
                    if (codigo == "") return;
                    Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigo);

                    double largonum = articulo.largonum;
                    double Anchonum = articulo.anchonum;
                    double Espesornum = articulo.espesornum;

                    string largotext = articulo.largotext;
                    string Anchotext = articulo.anchotext;
                    string Espesortext = articulo.espesortext;

                    // ================= Largo
                    this.gridExcel.CurrentRow.Cells["Largo"].Value = 0;
                    if (largotext.ToString().ToUpper() == "ESP")
                    {
                        this.gridExcel.CurrentRow.Cells["Largo"].ReadOnly = false;
                    }
                    else
                    {
                        this.gridExcel.CurrentRow.Cells["Largo"].Value = largonum;
                        this.gridExcel.CurrentRow.Cells["Largo"].ReadOnly = true;
                    }

                    // ================= Ancho
                    this.gridExcel.CurrentRow.Cells["Ancho"].Value = 0;
                    if (Anchotext.ToString().ToUpper() == "ESP")
                    {
                        // habilita control para introducir cantidad
                        this.gridExcel.CurrentRow.Cells["Ancho"].ReadOnly = false;
                    }
                    else
                    {
                        // Toma el valor y bloque a para que no lo modifiquen
                        this.gridExcel.CurrentRow.Cells["Ancho"].Value = Anchonum;
                        this.gridExcel.CurrentRow.Cells["Ancho"].ReadOnly = true;
                    }

                    //=================  Espesor
                    this.gridExcel.CurrentRow.Cells["Alto"].Value = 0;
                    if (Espesortext.ToString().ToUpper() == "ESP")
                    {
                        this.gridExcel.CurrentRow.Cells["Alto"].ReadOnly = false;
                    }
                    else
                    {
                        this.gridExcel.CurrentRow.Cells["Alto"].Value = Espesornum;
                        this.gridExcel.CurrentRow.Cells["Alto"].ReadOnly = true;
                    }

                    this.gridExcel.CurrentColumn = this.gridControl.Columns["Cantidad"];
                    break;
                case enmAyuda.enmTurnosxDetalle:

                    break;
                case enmAyuda.enmMotivo:
                    codigo = Util.convertiracadena(this.gridExcel.CurrentRow.Cells["IN07MOTIVOCOD"].Value);
                    codigo =  Logueo.CodigoEmpresa + codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo, "MOTIVO", out descripcion);
                    this.gridExcel.CurrentRow.Cells["DesMotivo"].Value = descripcion;
                    break;
                default:
                    break;
            }
        }
        private void mostrarAyudaIngMasiva(enmAyuda tipo)
        {
            frmBusqueda frm;
            string codigoSeleccionado = "";
            switch (tipo)
            {
                case enmAyuda.enmOperador:
                    frm = new frmBusqueda(enmAyuda.enmOperador);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {

                        this.gridExcel.CurrentRow.Cells["codigoOperador"].Value = frm.Result.ToString();
                        string codigo = Logueo.CodigoEmpresa + "14" + frm.Result.ToString();
                        string descripcion = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(codigo, "OPERARIO", out descripcion);
                        this.gridExcel.CurrentRow.Cells["Operador"].Value = descripcion;
                    }
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    string codigoAlmacen = this.gridExcel.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();                    
                                                            
                    frm = new frmBusqueda(tipo, codigoAlmacen);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();

                        if (codigoSeleccionado == "") return;
                        string[] separado = codigoSeleccionado.Split('/');
                        string codigoArticulo = separado[0];
                        this.gridExcel.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticulo;
                        this.gridExcel.CurrentRow.Cells["DescripcionArticulo"].Value = separado[1];
                        this.gridExcel.CurrentRow.Cells["UnidadMedida"].Value = separado[2];
                        
                        Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo);

                        double largonum = articulo.largonum;
                        double Anchonum = articulo.anchonum;
                        double Espesornum = articulo.espesornum;

                        string largotext = articulo.largotext;
                        string Anchotext = articulo.anchotext;
                        string Espesortext = articulo.espesortext;

                        // ================= Largo
                        this.gridExcel.CurrentRow.Cells["Largo"].Value = 0;
                        if (largotext.ToString().ToUpper() == "ESP")
                        {
                            this.gridExcel.CurrentRow.Cells["Largo"].ReadOnly = false;
                        }
                        else
                        {
                            this.gridExcel.CurrentRow.Cells["Largo"].Value = largonum;
                            this.gridExcel.CurrentRow.Cells["Largo"].ReadOnly = true;
                        }

                        // ================= Ancho
                        this.gridExcel.CurrentRow.Cells["Ancho"].Value = 0;
                        if (Anchotext.ToString().ToUpper() == "ESP")
                        {
                            // habilita control para introducir cantidad
                            this.gridExcel.CurrentRow.Cells["Ancho"].ReadOnly = false;
                        }
                        else
                        {
                            // Toma el valor y bloque a para que no lo modifiquen
                            this.gridExcel.CurrentRow.Cells["Ancho"].Value = Anchonum;
                            this.gridExcel.CurrentRow.Cells["Ancho"].ReadOnly = true;
                        }

                        //=================  Espesor
                        this.gridExcel.CurrentRow.Cells["Alto"].Value = 0;
                        if (Espesortext.ToString().ToUpper() == "ESP")
                        {
                            this.gridExcel.CurrentRow.Cells["Alto"].ReadOnly = false;
                        }
                        else
                        {
                            this.gridExcel.CurrentRow.Cells["Alto"].Value = Espesornum;
                            this.gridExcel.CurrentRow.Cells["Alto"].ReadOnly = true;
                        }

                        this.gridExcel.CurrentColumn = this.gridControl.Columns["Cantidad"];

                    }
                    break;
                case enmAyuda.enmProductoxColorFormat:
                     codigoAlmacen = this.gridExcel.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                    string ArticuloAnterior  = "";
                    if (this.gridExcel.CurrentRow.Index > 0)
                    {
                        int indiceanterio = this.gridExcel.CurrentRow.Index - 1;
                        ArticuloAnterior = this.gridExcel.Rows[indiceanterio].Cells["CodigoArticulo"].Value.ToString();
                    }
                    
                     frm = new frmBusqueda(tipo, codigoAlmacen, ArticuloAnterior, 1000);                    
                     frm.Owner = this;
                     frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();

                        if (codigoSeleccionado == "") return;
                        string[] separado = codigoSeleccionado.Split('|');
                        string codigoArticulo = separado[0];
                        this.gridExcel.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticulo;
                        this.gridExcel.CurrentRow.Cells["DescripcionArticulo"].Value = separado[1];
                        this.gridExcel.CurrentRow.Cells["UnidadMedida"].Value = separado[2];
                        //this.gridExcel.CurrentRow.Cells["Acabado"].Value = separado[5];
                        Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo);

                        double largonum = articulo.largonum;
                        double Anchonum = articulo.anchonum;
                        double Espesornum = articulo.espesornum;

                        string largotext = articulo.largotext;
                        string Anchotext = articulo.anchotext;
                        string Espesortext = articulo.espesortext;

                        // ================= Largo
                        this.gridExcel.CurrentRow.Cells["Largo"].Value = 0;
                        if (largotext.ToString().ToUpper() == "ESP")
                        {
                            this.gridExcel.CurrentRow.Cells["Largo"].ReadOnly = false;
                        }
                        else
                        {
                            this.gridExcel.CurrentRow.Cells["Largo"].Value = largonum;
                            this.gridExcel.CurrentRow.Cells["Largo"].ReadOnly = true;
                        }

                        // ================= Ancho
                        this.gridExcel.CurrentRow.Cells["Ancho"].Value = 0;
                        if (Anchotext.ToString().ToUpper() == "ESP")
                        {
                            // habilita control para introducir cantidad
                            this.gridExcel.CurrentRow.Cells["Ancho"].ReadOnly = false;
                        }
                        else
                        {
                            // Toma el valor y bloque a para que no lo modifiquen
                            this.gridExcel.CurrentRow.Cells["Ancho"].Value = Anchonum;
                            this.gridExcel.CurrentRow.Cells["Ancho"].ReadOnly = true;
                        }

                        //=================  Espesor
                        this.gridExcel.CurrentRow.Cells["Alto"].Value = 0;
                        if (Espesortext.ToString().ToUpper() == "ESP")
                        {
                            this.gridExcel.CurrentRow.Cells["Alto"].ReadOnly = false;
                        }
                        else
                        {
                            this.gridExcel.CurrentRow.Cells["Alto"].Value = Espesornum;
                            this.gridExcel.CurrentRow.Cells["Alto"].ReadOnly = true;
                        }

                        this.gridExcel.CurrentColumn = this.gridControl.Columns["Cantidad"];

                    }
                    break;
                case enmAyuda.enmAlmacen:
                    if (esEntrada == true)
                    {
                        frm = new frmBusqueda(enmAyuda.enmAlmacen);
                    }
                    else
                    {
                        var actividad = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim());
                        frm = new frmBusqueda(enmAyuda.enmAlmacenxNaturaleza, actividad.NATURALEZAALM);
                    }

                    frm.Owner = this;
                    frm.ShowDialog();

                    if (frm.Result != null)
                    {
                        if (FrmParent.rbIngreso.IsChecked)
                        {
                            string almacenSeleccionado = frm.Result.ToString();
                            if (this.gridExcel.CurrentRow.Cells["codigoAlmacen"].Value != null)
                            {
                                string almacenAnterior = this.gridExcel.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                                if (almacenSeleccionado.CompareTo(almacenAnterior) == -1) // verifico si el almacen seleccionado es el mismo codigo de almacen con 
                                {                                                           //el almacen de la grilla.
                                    this.gridExcel.CurrentRow.Cells["CodigoArticulo"].Value = null;
                                }
                            }

                        }
                        this.gridExcel.CurrentRow.Cells["CodigoAlmacen"].Value = frm.Result.ToString();
                    }
                    break;
                case enmAyuda.enmMaquina:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {
                            this.txtCodigoMaquina.Text = codigoSeleccionado;
                        }
                    }
                    break;
                case enmAyuda.enmMotivo:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado= frm.Result.ToString();
                        this.gridExcel.CurrentRow.Cells["IN07MOTIVOCOD"].Value = codigoSeleccionado;
                        //this.gridExcel.CurrentRow.Cells["DesMotivo"].Value = cadena[1];
                        
                    }
                    break;
                case enmAyuda.enmTurnosxDetalle:
                    frm = new frmBusqueda(enmAyuda.enmTurnos);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        this.gridExcel.CurrentRow.Cells["in07prodTurnoCod"].Value = codigoSeleccionado;
                        obtenerDescripcionIgnMasivo(enmAyuda.enmTurnosxDetalle, codigoSeleccionado);
                    }
                    break;
                default:
                    break;
            }
        }
        private void CopyCell()
        {
            valores = null;
            valores = new object[1];
            valores[0] = this.gridExcel.CurrentCell.Value;
        }

        private void PasteCell() 
        {
            if (valores != null)
                if (this.gridExcel.SelectedCells.Count > 0)
                    for (int i = 0; i < this.gridExcel.SelectedCells.Count; i++)
                         this.gridExcel.SelectedCells[i].Value = valores[0];
                else
                    this.gridExcel.CurrentCell.Value = valores[0];
        }
        
        private void ClearCell() 
        {
            this.gridExcel.CurrentCell.Value = null;
        }
        private void CopyRow()
        {
            valores = null;
            valores = new object[this.gridExcel.CurrentRow.Cells.Count];
            for (int c = 0; c < this.gridExcel.CurrentRow.Cells.Count; c++)
            {
                valores[c] = this.gridExcel.CurrentRow.Cells[c].Value;
            }

        }
        
        private void PasteRow()
        {
            //validamos si tenemos registro para pegar
            if (valores != null)
            {
                //primero recorremos por fila
                for (int f = 0; f < this.gridExcel.SelectedRows.Count; f++)
                {
                    //    //recorremos por celdas para copai la data
                    for (int c = 0; c < this.gridExcel.SelectedRows[f].Cells.Count; c++)
                    {
                        this.gridExcel.SelectedRows[f].Cells[c].Value = valores[c];
                        //en caso de ser la columna de almacen 
                        if (gridExcel.SelectedRows[f].Cells[c].Value != null)
                        {
                            if (gridExcel.SelectedRows[f].Cells[c].ColumnInfo.Index == gridExcel.Columns["CodigoArticulo"].Index)
                                //traer la descripcion del codigo de almacen copiado
                                obtenerDescripcionIgnMasivo(enmAyuda.enmProductoXAlmacen, gridExcel.SelectedRows[f].Cells[c].Value.ToString());
                        }
                    }
                }

            }
           
                
        }
        private void clearRow()
        {            
            foreach (GridViewCellInfo celda in this.gridExcel.CurrentRow.Cells)
            {
                celda.Value = null;
            }
        }
        private void GuardarDatosTemporal()
        {
            try
            {                
                string[] registros = new string[this.gridExcel.Rows.Count];
                int x = 0;

                for (int i = 0; i < this.gridExcel.Rows.Count; i++)
                {
                    //validacion para el caso de no registrar una hora inicio nulo el valor sera 00:00
                    DateTime? fechaproceso = this.gridExcel.Rows[i].Cells["IN07FECHAPROCESO"].Value == null ?
                                              this.dtpFechaOT.Value  : 
                                              DateTime.Parse(this.gridExcel.Rows[i].Cells["IN07FECHAPROCESO"].Value.ToString());
                    string hInicio = this.gridExcel.Rows[i].Cells["IN07HORAINICIO"].Value == null ? "00:00" :
                                             this.gridExcel.Rows[i].Cells["IN07HORAINICIO"].Value.ToString();
                    
                    //validacion para el caso de no registrar una hora final nulo el valor sera 00:00
                    string hFinal = this.gridExcel.Rows[i].Cells["IN07HORAFINAL"].Value == null ? "00:00" :
                                            this.gridExcel.Rows[i].Cells["IN07HORAFINAL"].Value.ToString();
                    
                    //validacion para el caso de no registrar una hora salida nulo el valor sera 00:00
                    string hSalida = this.gridExcel.Rows[i].Cells["IN07HORASALIDA"].Value == null ? "00:00" :
                                             this.gridExcel.Rows[i].Cells["IN07HORASALIDA"].Value.ToString();

                    string ordentrabajo = "";
                    //Si tenemos una orden de trabajo
                    if (gridOrdenTrabajo.Rows.Count > 0)
                    {
                        //capturo codigo de la orden de trabajo seleccionado 
                        ordentrabajo = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);
                    }

                    registros[x] = Logueo.CodigoEmpresa + "|" + Logueo.Anio + "|" + Logueo.Mes + "|" +
                               this.txtCodTipoDocumento.Text + "|" + this.txtNumeroDoc.Text + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["CodigoArticulo"].Value) + "|" +
                               (x + 1).ToString() + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["UnidadMedida"].Value) + "|" +
                                string.Format("{0:yyyyMMdd}", this.dtpFechaOT.Value) + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["CodigoAlmacen"].Value) + "|" +
                               this.txtCodDocRespaldo.Text + "|" +
                               "E" + "|" +
                               Util.convertiracero(this.gridExcel.Rows[i].Cells["Cantidad"].Value) + "|" +
                               Util.convertiracero(this.gridExcel.Rows[i].Cells["Largo"].Value) + "|" +
                               Util.convertiracero(this.gridExcel.Rows[i].Cells["Ancho"].Value) + "|" +
                               Util.convertiracero(this.gridExcel.Rows[i].Cells["Alto"].Value) + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["NroCaja"].Value) + "|" +
                               "0" + "|" +
                               ordentrabajo + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["codigoOperador"].Value) + "|" +
                               Util.convertirahoras(hSalida) + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["IN07NROCAJAINGRESO"].Value) + "|" +

                               Util.convertirahoras(hInicio) + "|" +
                               Util.convertirahoras(hFinal) + "|" +
                               string.Format("{0:yyyyMMdd}", fechaproceso, 103) + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["IN07MOTIVOCOD"].Value) + "|" +
                               Util.convertiracadena(this.gridExcel.Rows[i].Cells["in07prodTurnoCod"].Value) + "|" + 
                               Logueo.UserName;
                    x++;


                }
                
                DocumentoLogic.Instance.InsertarMoviMasivoTemporal(Logueo.CodigoEmpresa, Logueo.UserName,
                                                                        Util.ConvertiraXMLvariasColumnas(registros));
                
            }
            catch (Exception ex)
            {
                //RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
        }
        private void cerrarModal()
        {
            this.KeyPreview = true;
            this.timer1.Enabled = false; // inicio el timer
            // limpiamos las filas de la grilal de ingreso masivo
            if (this.gridExcel.Rows.Count > 0)
            {
                this.gridExcel.Rows.Clear();
            }

            //this.btnGuardar.Enabled = false;
            //this.btnGuardar.Image = Properties.Resources.save16_disabled;
            rpAgregaMasivo.Hide();
        }
        private int CantidadRegistrosEnBlanco()
        {

            int contador = 0;
            foreach (GridViewRowInfo row in this.gridExcel.Rows)
            {
                if (Util.convertiracadena(row.Cells["CodigoArticulo"].Value) == "") { contador++; }
            }
            return contador;
        }                         
         
        //eventos de ingreso masivo
        private void pnlAgregaMasivo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void pnlAgregaMasivo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rpAgregaMasivo.Left = e.X + rpAgregaMasivo.Left - MouseDownLocation.X;
                //this.Left = e.X + this.Left - MouseDownLocation.X;
                rpAgregaMasivo.Top = e.Y + rpAgregaMasivo.Top - MouseDownLocation.Y;
                //this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }                
        private void pnlBotonesModal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rpAgregaMasivo.Left = e.X + rpAgregaMasivo.Left - MouseDownLocation.X;
                rpAgregaMasivo.Top = e.Y + rpAgregaMasivo.Top - MouseDownLocation.Y;
            }
        }
        private void pnlBotonesModal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void btnCerrarModal_Click(object sender, EventArgs e)
        {
            cerrarModal();            
        }
        private void EliminarDatosTemporal()
        {
            DocumentoLogic.Instance.EliminarMovMasivoTemporal(Logueo.CodigoEmpresa, Logueo.UserName);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            try
            {
                //Guardo  temporal 
                GuardarDatosTemporal();
                 //Cargo los mensaje de validacion
                cargarMensaje();
                
                if (this.gridMensaje.Rows.Count > 0)
                {
                    RadMessageBox.Show("Corregir los erroes parar guardar los datos", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                DocumentoLogic.Instance.InsertarMoviMasivo(Logueo.CodigoEmpresa, Logueo.UserName, out mensaje);
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                cargarProductosDet(); // refresco grilal de detalle de producto.
                cerrarModal();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error al intentar guardar datos : " + ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }


        }       
        private void gridExcel_KeyDown(object sender, KeyEventArgs e)
        {
            if (Estado == FormEstate.List || Estado == FormEstate.View) return; 
            // inhabilito el evento si no es modo Edicio
            gridExcel.Focus();
            try
            {            
                if (e.KeyValue == (char)Keys.F1)
                {
                    GridViewRowInfo fila = gridExcel.CurrentRow;
                    GridViewColumn columna = this.gridExcel.CurrentColumn;

                    if (columna.Index == fila.Cells["CodigoArticulo"].ColumnInfo.Index ||
                        columna.Index == fila.Cells["NroCaja"].ColumnInfo.Index)
                    {
                        if (fila.Cells["CodigoAlmacen"].Value == null)
                        {
                            RadMessageBox.Show("Seleccionar almacen", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                            return;
                        }
                        if (fila.Cells["CodigoAlmacen"].Value.ToString() == "")
                        {
                            RadMessageBox.Show("Seleccionar almacen", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                            return;
                        }
                    }                    

                    if (columna.Index == fila.Cells["Operador"].ColumnInfo.Index)
                    {
                        mostrarAyudaIngMasiva(enmAyuda.enmOperador);
                    }

                    //Habilito ayuda si la transaccion es Ingreso o Salida
                    if (FrmParent.rbIngreso.IsChecked) // si el documento es de Ingreso permito 
                    {
                        if (columna.Index == fila.Cells["CodigoAlmacen"].ColumnInfo.Index)
                        {
                            mostrarAyudaIngMasiva(enmAyuda.enmAlmacen);                            
                        }

                        if (columna.Index == fila.Cells["CodigoArticulo"].ColumnInfo.Index)
                        {                                                         
                            if (txtCodProceso.Text == Logueo.CodigoLinea)
                            {
                                //Cuando mi proceso o actividad es Linea 
                                mostrarAyudaIngMasiva(enmAyuda.enmProductoxColorFormat);
                                this.gridExcel.Columns["Largo"].IsCurrent = true;
                            }
                            else { 
                                //Cuando se trata de otro proceso difernte a proceso Linea
                                mostrarAyudaIngMasiva(enmAyuda.enmProductoXAlmacen);
                                this.gridExcel.Columns["Largo"].IsCurrent = true;
                            }
                            
                        }
                        if (columna.Index == fila.Cells["DesMotivo"].ColumnInfo.Index)
                        {
                            mostrarAyudaIngMasiva(enmAyuda.enmMotivo);
                        }
                        if (columna.Index == fila.Cells["in07prodTurnoDesc"].ColumnInfo.Index)
                        {
                            mostrarAyudaIngMasiva(enmAyuda.enmTurnosxDetalle);
                        }

                    }
                    else
                    {                        
                        //Permito llamar ayuda de NroCaja y Codigo de Almacen (Almacen)  solo si es una fila nueva                            
                        if (columna.Index == fila.Cells["NroCaja"].ColumnInfo.Index)
                        {
                            mostrarAyudaIngMasiva(enmAyuda.enmCanastillas);
                        }

                        if (columna.Index == fila.Cells["CodigoAlmacen"].ColumnInfo.Index)
                        {
                            mostrarAyudaIngMasiva(enmAyuda.enmAlmacen);
                        }
                           //this.CreateGridColumn(gridExcel, "CodMotivo", "IN07MOTIVOCOD", 0, "", 60, true, false, false);
                            //this.CreateGridColumn(gridExcel, "Motivo", "DesMotivo", 0, "", 60);
                        
                    }

                }
                int CellsCount = this.gridExcel.SelectedCells.Count;;
                
                int ColumnsCount = this.gridExcel.Columns.Count;;
                bool isRowSelected = this.gridExcel.SelectionMode == GridViewSelectionMode.FullRowSelect;
                if (e.Control && e.KeyCode == Keys.C)
                {                    
                    if (isRowSelected)
                        CopyRow();
                    else 
                        CopyCell();
                                        
                }
                
                if(e.Control &&  e.KeyCode == Keys.V)
                {                    
                    if (isRowSelected)
                        PasteRow();
                    else 
                        PasteCell();
                }

            }
            catch (Exception ex)
            {

            }

        }
        private void gridExcel_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            //if (isEscallaLoaded == true)
            //{
            string columname = this.gridExcel.CurrentColumn.Name;
            Util.SetCellInitEdit(gridExcel, columname);
            //}
        }
        private void gridExcel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void rpBotonesModal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rpAgregaMasivo.Left = e.X + rpAgregaMasivo.Left - MouseDownLocation.X;
                rpAgregaMasivo.Top = e.Y + rpAgregaMasivo.Top - MouseDownLocation.Y;
            }
        }
        private void rpBotonesModal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void dtpFechaOT_KeyDown(object sender, KeyEventArgs e)
        {
            this.dtpFechaOT.ReadOnly = (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) ? true : false;
        }                        
        private void gridExcel_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu.Items.Clear();
            RadMenuItem itmCopiarFila = new RadMenuItem();
            itmCopiarFila.Text = "Copiar Fila";
            itmCopiarFila.Name = "CopyRow";
            itmCopiarFila.Click += new EventHandler(delegate(object r, EventArgs a)
            {
                CopyRow();
            });
            RadMenuItem itmPegarFila = new RadMenuItem();
            itmPegarFila.Text = "Pegar Fila";
            itmPegarFila.Name = "PasteRow";
            itmPegarFila.Click += new EventHandler(delegate(object r, EventArgs a)
            {
                PasteRow();
            });
            RadMenuItem itmLimpiarFila = new RadMenuItem();
            itmLimpiarFila.Text = "Limpiar Fila";
            itmLimpiarFila.Name = "ClearRow";
            itmLimpiarFila.Click += new EventHandler(delegate(object r, EventArgs a)
            {
                clearRow();
            });
            e.ContextMenu.Items.Add(itmCopiarFila);
            e.ContextMenu.Items.Add(itmPegarFila);
            e.ContextMenu.Items.Add(itmLimpiarFila);

            RadMenuItem itmCopiarCelda = new RadMenuItem();
            itmCopiarCelda.Text = "Copiar Celda";
            itmCopiarCelda.Name = "CopiarCelda";
            itmCopiarCelda.Click += new EventHandler(delegate(object r, EventArgs a)
            {
                CopyCell();
            });
            RadMenuItem itmPegarCelda = new RadMenuItem();
            itmPegarCelda.Text = "Pegar Celda";
            itmPegarCelda.Name = "PegarCelda";
            itmPegarCelda.Click += new EventHandler(delegate(object r, EventArgs a)
                {
                    PasteCell();
                });
            RadMenuItem itmLimpiarCelda = new RadMenuItem();
            itmLimpiarCelda.Text = "Limpiar Celda";
            itmLimpiarCelda.Name = "LimpiarCelda";
            itmLimpiarCelda.Click += new EventHandler(delegate(object r, EventArgs a)
                {
                    ClearCell();
                });
            e.ContextMenu.Items.Add(itmCopiarCelda);
            e.ContextMenu.Items.Add(itmPegarCelda);
            e.ContextMenu.Items.Add(itmLimpiarCelda);
        }        
        private void timer1_Tick(object sender, EventArgs e)
        {
            GuardarDatosTemporal();
            cargarMensaje(); // cargar al tabla de mensaje si tiene errores los registros
        }
        private void gridExcel_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewRowHeaderColumn)
            {
                this.gridExcel.SelectionMode = GridViewSelectionMode.FullRowSelect;
                this.gridExcel.CurrentRow.IsCurrent = true;
                this.gridExcel.CurrentRow.IsSelected = true;
            }
            else
            {
                this.gridExcel.SelectionMode = GridViewSelectionMode.CellSelect;

            }
        }
        private void gridExcel_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "IN07MOTIVOCOD")
            {
                mostrarDescripcionIngMasiva(enmAyuda.enmMotivo, this.gridExcel.CurrentRow.Cells["IN07MOTIVOCOD"].Value.ToString());
                //if (e.Value == null)
                //{
                //    this.gridExcel.CurrentRow.Cells["IN07MOTIVOCOD"].Value = null;
                //}
            }
        }    
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            GuardarDatosTemporal();
            cargarMensaje();
        }

        private void pnlAgregaMasivo_Cerrar(object sende, EventArgs e)
        {
            rpAgregaMasivo.Hide();
        }
        #endregion                       
        // =================================================================== Formulario de hora muerta ===================================================================
        #region "Formulario Hora Muerta"
        int esNuevoHM = 0;
        private void limpiarHM()
        {
            this.txtCodMotivo.Text = "";
            this.txtDesMotivo.Text = "";
            this.dtpHMFecha.Value = dtpFechaOT.Value;
            this.txtHMHoraInicio.Text = Util.GetCurrentCellText(gridControl, "IN07HORAFINAL");
            this.txtHMHoraFin.Text = "00:00";

            this.txtObservacionesHM.Text = "";
        }
        private bool ValidarHM()
        {
            if (txtCodMotivo.Text.Trim().Length == 0)
            {
                Util.ShowAlert("Ingresar Motivo");
                return false;
            }
            if (txtDesMotivo.Text.Trim().Length == 0 || txtDesMotivo.Text == "???")
            {
                Util.ShowAlert("Ingresar Motivo");
                return false;
            }

            // Convertiendo los valor de string a datetyime (hora)
            int initime = 0;
            int fintime = 0;
            
            initime = Convert.ToInt32(txtHMHoraInicio.Text.Remove(2, 1));
            fintime = Convert.ToInt32(txtHMHoraFin.Text.Remove(2, 1));

            if (initime >= fintime)
            {
                Util.ShowAlert("Hora Inicio es mayor o igual a Hora Final");                
                return false;
            }
            return true;
        }
        private void iniciarVentanaHM()
        {

            esNuevoHM = 0;
            HabilitarBtnHM(true);
            HabilitarCtrlHM(false);
            this.dtpHMFecha.Value = dtpFechaOT.Value;
            CargarGridHM();
            //btnNuevoHM.IsMouseOver = true;
            this.pnlHoraMuerta.Focus();


            this.txtHMHoraInicio.Format = DateTimePickerFormat.Custom;
            this.txtHMHoraInicio.ShowUpDown = true;
            this.txtHMHoraInicio.CustomFormat = "HH:mm";
            //this.txtHMHoraInicio.Text = this.gridControl.CurrentRow.Cells["IN07HORASALIDA"].Value.ToString();

            //string horaSalida = Util.convertirahoras(this.gridControl.CurrentRow.Cells["IN07HORASALIDA"].Value.ToString());

            this.txtHMHoraFin.Format = DateTimePickerFormat.Custom;
            this.txtHMHoraFin.ShowUpDown = true;
            this.txtHMHoraFin.CustomFormat = "HH:mm";
            //this.txtHMHoraFin.Text = "";
        }
        private void CancelarHM()
        {
            esNuevoHM = 0;
            HabilitarBtnHM(true);
            HabilitarCtrlHM(false);
            CargarGridHM();
        }
        private void GuardarHM()
        {
            if (!ValidarHM())
                return;

            HoraMuertaDetalle hmd = new HoraMuertaDetalle();
            hmd.PRO01CODEMP = Logueo.CodigoEmpresa;
            hmd.PRO01DOCMOVAA = this.dtpFechaOT.Value.Year.ToString();
            hmd.PRO01DOCMOVMM = this.dtpFechaOT.Value.Month.ToString("0#");

            hmd.PRO01DOCMOVTIPDOC = this.txtCodTipoDocumento.Text.Trim();
            hmd.PRO01DOCMOVCODDOC = this.txtNumeroDoc.Text;
            hmd.PRO01CODMOTIVO = this.txtCodMotivo.Text;
            string horaInicio = this.txtHMHoraInicio.Text;
            hmd.PRO01HORAINICIO = horaInicio;
            string horaFin = this.txtHMHoraFin.Text;
            hmd.PRO01HORAFIN = horaFin;
            hmd.PRO01FECHA = this.dtpFechaOT.Value;
            hmd.PRO01OBSERVACION = this.txtObservacionesHM.Text;

            string mensaje = "";
            int flag = 0;
 // capturar valores de correlativo, Moviemiento Key, Movimiento Orden, codigo articulo, orden
            GridViewRowInfo row = this.gridControl.CurrentRow;
            if (esNuevoHM == 1)
            {
                int correlativo = 0;
                HoraMuertaDetalleLogic.Instance.TraerCorrelativo(hmd, out correlativo);
                hmd.PRO01CORRELATIVO = correlativo;
                string cCodigoArticulo = Util.convertiracadena(row.Cells["CodigoArticulo"].Value);
                string cOrden = Util.convertiracadena(row.Cells["Orden"].Value);    
                hmd.PRO01DOCMOVKEY = Util.convertiracadena(cCodigoArticulo);
                hmd.PRO01DOCMOVORDEN = double.Parse(cOrden);

                HoraMuertaDetalleLogic.Instance.InsertarHoraMuertaDet(hmd, out mensaje, out flag);
                //Mostrar mensaje
                Util.ShowMessage(mensaje, flag);             
            }
            else if (esNuevoHM == 2)
            {
                int correlativo = Util.GetCurrentCellInt(gridHorasMuerta, "PRO01CORRELATIVO");
                string cDocMovKey = Util.GetCurrentCellText(gridHorasMuerta, "PRO01DOCMOVKEY");
                string cDocMovOrden = Util.GetCurrentCellText(gridHorasMuerta, "PRO01DOCMOVORDEN");
                hmd.PRO01CORRELATIVO = correlativo;
                hmd.PRO01DOCMOVKEY = cDocMovKey;                
                hmd.PRO01DOCMOVORDEN = double.Parse(cDocMovOrden);

                HoraMuertaDetalleLogic.Instance.ActualizarHoraMuertaDet(hmd, out mensaje, out flag);
                Util.ShowMessage(mensaje, flag);
            }
            else
            {
                Util.ShowAlert("Error en opcion");
            }
            CancelarHM();
        }
        private void HabilitarCtrlHM(bool valor)
        {
            this.txtCodMotivo.Enabled = valor;
            this.txtDesMotivo.Enabled = false;
            this.dtpHMFecha.Enabled = false;
            this.txtHMHoraInicio.Enabled = valor;
            this.txtHMHoraFin.Enabled = valor;
            this.txtObservacionesHM.Enabled = valor;
        }
        private void HabilitarBtnHM(bool valor)
        {
            this.btnNuevoHM.Visibility = (valor == true) ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.btnEditarHM.Visibility = (valor == true) ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.btnEliminarHM.Visibility = (valor == true) ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.btnGuardarHM.Visibility = (!valor == true) ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.btnCancelarHM.Visibility = (!valor == true) ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.pnlRight.Visible = valor;

        }
        private void NuevoHM()
        {
            limpiarHM();
            esNuevoHM = 1;
            HabilitarCtrlHM(true);
            HabilitarBtnHM(false);
            this.dtpHMFecha.Value = dtpFechaOT.Value;
            this.txtCodMotivo.Focus();
        }
        private void SalirHM()
        {
            esNuevoHM = 0;            
            Util.MostrarPanel(pnlHoraMuerta, false);
            limpiarHM();
        }
        private void CrearColumnasHM()
        {
            RadGridView Grid = this.CreateGridVista(this.gridHorasMuerta);
            this.CreateGridColumn(Grid, "PRO01CODEMP", "PRO01CODEMP", 0, "", 50, true, false, false);
            this.CreateGridColumn(Grid, "PRO01DOCMOVAA", "PRO01DOCMOVAA", 0, "", 50, true, false, false);
            this.CreateGridColumn(Grid, "PRO01DOCMOVMM", "PRO01DOCMOVMM", 0, "", 50, true, false, false);
            this.CreateGridColumn(Grid, "PRO01DOCMOVTIPDOC", "PRO01DOCMOVTIPDOC", 0, "", 50, true, false, false);
            this.CreateGridColumn(Grid, "PRO01DOCMOVCODDOC", "PRO01DOCMOVCODDOC", 0, "", 50, true, false, false);

            this.CreateGridColumn(Grid, "PRO01DOCMOVKEY", "PRO01DOCMOVKEY", 0, "", 50, true, false, false);
            this.CreateGridColumn(Grid, "PRO01DOCMOVORDEN", "PRO01DOCMOVORDEN", 0, "", 50, true, false, false);

            this.CreateGridColumn(Grid, "PRO01CORRELATIVO", "PRO01CORRELATIVO", 0, "", 50, true, false, false);
            this.CreateGridColumn(Grid, "Cod.Motivo", "PRO01CODMOTIVO", 0, "", 80);
            this.CreateGridColumn(Grid, "Des.Motivo", "PRO01DESCRIPCION", 0, "", 90);
            this.CreateGridColumn(Grid, "Fecha", "PRO01FECHA", 0, "{0:dd/MM/yyyy}", 70);
            this.CreateGridColumn(Grid, "H.Inicio", "PRO01HORAINICIO", 0, "", 60);
            this.CreateGridColumn(Grid, "H.Fin", "PRO01HORAFIN", 0, "", 60);
            this.CreateGridColumn(Grid, "Observacion", "PRO01OBSERVACION", 0, "", 100);
        }
        private void CargarGridHM()
        {
            HoraMuertaDetalle hmd = new HoraMuertaDetalle();
            hmd.PRO01CODEMP = Logueo.CodigoEmpresa;
            hmd.PRO01DOCMOVAA = this.dtpFechaOT.Value.Year.ToString();
            hmd.PRO01DOCMOVMM = this.dtpFechaOT.Value.Month.ToString("0#");
            hmd.PRO01DOCMOVTIPDOC = this.txtCodTipoDocumento.Text.Trim();
            hmd.PRO01DOCMOVCODDOC = this.txtNumeroDoc.Text;

            var lista = HoraMuertaDetalleLogic.Instance.TraerHoraMuertaDetalle(hmd, "PRO01DOCMOVCODDOC");
            this.gridHorasMuerta.DataSource = lista;
        }
        private void EditarHM()
        {
            HabilitarCtrlHM(true);
            HabilitarBtnHM(false);
            esNuevoHM = 2;
        }
        private void EliminarHM()
        {

            try
            {
                HoraMuertaDetalle hmd = new HoraMuertaDetalle();
                hmd.PRO01CODEMP = Logueo.CodigoEmpresa;
                hmd.PRO01DOCMOVAA = this.dtpFechaOT.Value.Year.ToString();
                hmd.PRO01DOCMOVMM = this.dtpFechaOT.Value.Month.ToString("0#");
                hmd.PRO01DOCMOVTIPDOC = this.txtCodTipoDocumento.Text.Trim();
                hmd.PRO01DOCMOVCODDOC = this.txtNumeroDoc.Text;
                string cDocMovKey = Util.convertiracadena(this.gridHorasMuerta.CurrentRow.Cells["PRO01DOCMOVKEY"].Value);
                hmd.PRO01DOCMOVKEY = cDocMovKey;

                string cDocMovOrden = Util.convertiracadena(this.gridHorasMuerta.CurrentRow.Cells["PRO01DOCMOVORDEN"].Value);
                hmd.PRO01DOCMOVORDEN = double.Parse(cDocMovOrden);
                hmd.PRO01CORRELATIVO = Convert.ToInt32(this.gridHorasMuerta.CurrentRow.Cells["PRO01CORRELATIVO"].Value);

                DialogResult respuesta = RadMessageBox.Show("Desea eliminar el registro", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    string mensaje = "";
                    int flag = 0;
                    HoraMuertaDetalleLogic.Instance.EliminarHoraMuertaDet(hmd, out mensaje, out flag);
                    if (flag == 1)
                    {
                        RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                HabilitarBtnHM(true);
                HabilitarCtrlHM(false);
                CargarGridHM();
                limpiarHM();
            }
            catch (Exception ex)
            {

            }
        }
        private void SeleccionHM()
        {
            GridViewRowInfo current = this.gridHorasMuerta.CurrentRow;

            this.txtCodMotivo.Text = current.Cells["PRO01CODMOTIVO"].Value.ToString();
            this.dtpHMFecha.Value = Convert.ToDateTime(current.Cells["PRO01FECHA"].Value);
            this.txtHMHoraInicio.Text = current.Cells["PRO01HORAINICIO"].Value.ToString();
            this.txtHMHoraFin.Text = current.Cells["PRO01HORAFIN"].Value.ToString();
            this.txtObservacionesHM.Text = current.Cells["PRO01OBSERVACION"].Value.ToString();
        }
        private void btnHoraMuerta_Click(object sender, EventArgs e)
        {
            if (this.txtCodTipoDocumento.Text == "")
            {
               Util.ShowAlert("Para registrar Hora Muerta debe guardar el documento");
                return;
            }
            if (this.gridOrdenTrabajo.Rows.Count == 0)
            {
                Util.ShowAlert("Para registrar Hora Muerta debe Ingresar Orden de Trabajo");
                return;
            }
            if (this.gridMateriaPrima.Rows.Count == 0)
            {
                Util.ShowAlert("Para registrar Hora Muerta debe Ingresar Materia Prima");                
                return;
            }
            Util.MostrarPanel(pnlHoraMuerta, true);
        }

        private void pnlHoraMuerta_VisibleChanged(object sender, EventArgs e)
        {
            if (this.gridHorasMuerta.Columns.Count == 0)
            {
                CrearColumnasHM();
            }
            if (this.pnlHoraMuerta.Visible == true)
            {
                this.pnlHoraMuerta.Location = new Point(this.ClientSize.Width / 2 - this.pnlHoraMuerta.Width / 2,
                    this.ClientSize.Height / 2 - this.pnlHoraMuerta.Height / 2);
                iniciarVentanaHM();
            }
        }

        private void btnNuevoHM_Click(object sender, EventArgs e)
        {
            NuevoHM();
        }

        private void btnEditarHM_Click(object sender, EventArgs e)
        {
            EditarHM();
        }

        private void btnEliminarHM_Click(object sender, EventArgs e)
        {
            EliminarHM();
        }

        private void btnGuardarHM_Click(object sender, EventArgs e)
        {
            GuardarHM();
        }

        private void btnCancelarHM_Click(object sender, EventArgs e)
        {
            CancelarHM();
        }

        private void btnSalirHM_Click(object sender, EventArgs e)
        {
            SalirHM();
        }

        private void txtCodMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                frmBusqueda frm = new frmBusqueda(enmAyuda.enmMotivoHoraMuerta);
                frm.ShowDialog();
                if (frm.Result != null)
                {
                    string[] datos = frm.Result.ToString().Split('|');
                    this.txtCodMotivo.Text = datos[0].ToString();
                    this.txtDesMotivo.Text = datos[1].ToString();

                }
            }

        }

        private void gridHorasMuerta_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (this.gridHorasMuerta.Rows.Count == 0)
                return;
            if (e.CurrentRow != null)
            {
                SeleccionHM();
            }
        }

        private void txtCodMotivo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCodMotivo.Text.Trim() != "")
            {
                string cCodigo = Logueo.CodigoEmpresa + this.txtCodMotivo.Text.Trim();
                string cDescripcion = "";
                GlobalLogic.Instance.DameDescripcion(cCodigo, "HORAMUERTA", out cDescripcion);
                this.txtDesMotivo.Text = cDescripcion;
            }
        }

        private void btnCerrarHM_Click(object sender, EventArgs e)
        {
            SalirHM();
        }

        private void txtObservacionesHM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                btnGuardarHM.IsMouseOver = true;
                GuardarHM();
            }
        }


        #endregion "Fin region Hora muerta"                                             
        // =================================================================== ESCALLA ===================================================================
        #region "Escalla"

        private string unimedEscalla = "";
        private string unimedCostra = "";

        
        private void ConfigurarVentanaEscalla()
        {
            Util.dimensionarPopUp(this.popupEscalla, 1170, 220);
            Util.posicionarPopUp(this.popupEscalla, 90, 50);
            Util.MostrarPopUp(this.popupEscalla, true);
            this.popupEscalla.Focus();
            this.gridEscalla.Focus();
            lblEscallaTitulo.Text = "ESCALLA";
            this.gridEscalla.BeginEditMode = RadGridViewBeginEditMode.BeginEditOnKeystrokeOrF2;
            
        }
        private void crearGruposColumnasSaldoxBloque()
        {
            this.columnGroupsView = new ColumnGroupsViewDefinition();

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["CodigoEmpresa"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["Anio"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["Mes"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["CodigoTipoDocumento"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["CodigoDocumento"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["CodigoArticulo"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["UnidadMedida"]);


            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridEscalla.Columns["Orden"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridEscalla.Columns["FechaDoc"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridEscalla.Columns["CodigoAlmacen"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridEscalla.Columns["Cantidad"]);


            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["IN07NROCAJAINGRESO"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["Largo"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["Ancho"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["Alto"]);

            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["Volumen"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["in07observacion"]);


            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
            this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridEscalla.Columns["NroCaja"]);

            this.gridEscalla.ViewDefinition = columnGroupsView;
        }

        private  bool isEscallaLoaded = false;
        private bool isFormatoEscalla = false;
        private void MostrarVentanaEscalla()
        {
            isFormatoEscalla = true;
            //ocultar controles  de lado corte
            label2.Visible = false;
            rbAlto.Visible = false;
            rbAncho.Visible = false;
            rbLargo.Visible = false;

            //Cargar datos de escall de la base de datos
            TraerEscalla();
            // Si la grilla no carga nada de la base entonces preparar nuevo registro
            if (this.gridEscalla.RowCount == 0)
            {

                this.gridEscalla.Rows.AddNew();
                limpiarescalla();
            
            //Asignar foco de celda
            this.gridEscalla.CurrentColumn = this.gridEscalla.Columns["Largo"];
         
            
            //Traer datos de medida de Materia Prima
            string codEscalla = "", codCostra = "", codalmEscalla = "", codalmCostra = "";
                
            //Obtener valores de Materia prima
            double mpLargo = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07LARGO");
            double mpAncho = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07ANCHO");
            double mpAlto = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07ALTO");
            string codbloque = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngKEY");
            

            //Obtener valores por defecto 
            GlobalLogic.Instance.DameValorxDefecto(Logueo.CodigoEmpresa, Logueo.codModulo,
                                                   "00001", out codalmEscalla);

            GlobalLogic.Instance.DameValorxDefecto(Logueo.CodigoEmpresa, Logueo.codModulo,
                                                    "00002", out codalmCostra);

            DocumentoLogic.Instance.TraerCodProdGeneradoxBloqueMP(Logueo.CodigoEmpresa,
                                   Logueo.codModulo, "00003", codbloque, out codEscalla);

            DocumentoLogic.Instance.TraerCodProdGeneradoxBloqueMP(Logueo.CodigoEmpresa,
                                    Logueo.codModulo, "00004", codbloque, out codCostra);

            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + Logueo.Anio + codEscalla, "UNIDADARTICULO", out unimedEscalla);
            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + Logueo.Anio + codCostra, "UNIDADARTICULO", out unimedCostra);
            
            Util.SetValueCurrentCellDbl(gridEscalla, "LargoBloque", mpLargo);
            Util.SetValueCurrentCellDbl(gridEscalla, "AnchoBloque", mpAncho);
            Util.SetValueCurrentCellDbl(gridEscalla, "AlturaBloque", mpAlto);
            Util.SetValueCurrentCellText(gridEscalla, "CodBloque", codbloque);                       
            Util.SetValueCurrentCellText(gridEscalla, "CodAlmEscalla", codalmEscalla);
            Util.SetValueCurrentCellText(gridEscalla, "CodAlmCostra", codalmCostra);
            Util.SetValueCurrentCellText(gridEscalla, "CodEscalla", codEscalla);
            Util.SetValueCurrentCellText(gridEscalla, "CodCostra", codCostra);
            Util.SetValueCurrentCellText(gridEscalla, "EscallaUniMed", unimedEscalla);
            Util.SetValueCurrentCellText(gridEscalla, "CostraUniMed", unimedCostra); 

            //Util.SetValueCurrentCellText(gridEscalla, "", nrocajaescalla);
            //Util.SetValueCurrentCellText(gridEscalla, "", nrocajacostra);
            }
            ConfigurarVentanaEscalla();
            Util.SetCellInitEdit(gridEscalla, "Largo");            
            isEscallaLoaded  = true;
        }
		private void SetCellFocus(RadGridView DataGrid, string name)
        {
            if (gridEscalla.RowCount > 0)
            { 
                DataGrid.CurrentRow.Cells[name].BeginEdit();
            }
        }
        /* ================================================  Evento para traer la ayuda de grilla Escalla o SaldoxBloque ==================================================== */
        private void gridEscalla_CellValueChanged(object sender, GridViewCellEventArgs e)
        {

                string descripcion = "";
                /* ========================================== Si el formato escalla esta activo  ============================================================================ */
                if (isFormatoEscalla == true)
                { 
                    if (Util.IsCurrentColumn(e.Column, "CodEscalla"))
                    {
                        string codEscalla = Util.GetCurrentCellText(gridEscalla, "CodEscalla");
                        string codigo = Logueo.CodigoEmpresa + Logueo.Anio + codEscalla;
                        GlobalLogic.Instance.DameDescripcion(codigo, "ARTICULO", out descripcion);
                        Util.SetValueCurrentCellText(gridEscalla, "Escalla", descripcion);                    
                    }
                    if (Util.IsCurrentColumn(e.Column, "CodCostra"))
                    {
                        string codCostra = Util.GetCurrentCellText(gridEscalla, "CodCostra");
                        string codigo = Logueo.CodigoEmpresa + Logueo.Anio + codCostra;
                        GlobalLogic.Instance.DameDescripcion(codigo, "ARTICULO", out descripcion);
                        Util.SetValueCurrentCellText(gridEscalla, "Costra", descripcion);                    
                    }
                     if (Util.IsCurrentColumn(e.Column, "CodAlmEscalla"))
                    {
                        string codigo = Util.GetCurrentCellText(gridEscalla, "CodAlmEscalla");
                        codigo = Logueo.CodigoEmpresa + codigo;
                        GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                        Util.SetValueCurrentCellText(gridEscalla, "DesAlmEscalla", descripcion);
                    }
                     if (Util.IsCurrentColumn(e.Column, "CodAlmCostra"))
                    {
                        string codigo = Util.GetCurrentCellText(gridEscalla, "CodAlmCostra");
                        codigo = Logueo.CodigoEmpresa + codigo;
                        GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                        Util.SetValueCurrentCellText(gridEscalla, "DesAlmCostra", descripcion);                    
                    }
                }
                /* ========================================== Si el formato saldo x bloque esta activo  ==================================================================== */
                else if (isFormatoSaldoxBloque == true)
                {
                    if (Util.IsCurrentColumn(e.Column, "Largo") ||
                        Util.IsCurrentColumn(e.Column, "Ancho") ||
                        Util.IsCurrentColumn(e.Column, "Alto"))
                    {
                        double largo, ancho, alto, volumen = 0;
                        largo = Util.GetCurrentCellDbl(e.Row, "Largo");
                        ancho = Util.GetCurrentCellDbl(e.Row, "Ancho");
                        alto = Util.GetCurrentCellDbl(e.Row, "Alto");

                        volumen = 1 * (largo * ancho * alto);
                        
                        Util.SetValueCurrentCellDbl(gridEscalla, "Volumen",volumen);
                    }                   
                }                            
        }
        private void gridEscalla_KeyDown(object sender, KeyEventArgs e)
         {
             GridViewColumn currentColum = this.gridEscalla.CurrentColumn;
             if (isFormatoEscalla == true)
             { 
                 if (e.KeyValue == (char)Keys.F1)
                 {
                     if (Util.IsCurrentColumn(currentColum, "Escalla"))
                     {
                         TraerAyudaEscalla(enmAyuda.enmEscalla);
                     }
                     if (Util.IsCurrentColumn(currentColum, "Costra"))
                     {
                         TraerAyudaEscalla(enmAyuda.enmCostra);
                     }
                     if (Util.IsCurrentColumn(currentColum, "DesAlmEscalla"))
                     {
                         TraerAyudaEscalla(enmAyuda.enmAlmacenxNaturaleza);
                     }
                     else if (Util.IsCurrentColumn(currentColum, "DesAlmCostra"))
                     {
                         TraerAyudaEscalla(enmAyuda.enmAlmacenxNaturaleza);
                     }

                 }
             }
             else if (isFormatoSaldoxBloque == true)
             {

                 this.gridEscalla.BeginEdit();
             }
         }        
        private void CrearColumnasEscalla()
        {
            RadGridView GridEscalla = CreateGridVista(this.gridEscalla);
            
            this.CreateGridColumn(GridEscalla, "Largo", "LargoBloque", 0, "{0:###,###0.00}", 70, true, false, true, true);
            this.CreateGridColumn(GridEscalla, "Ancho", "AnchoBloque", 0, "{0:###,###0.00}", 70, true, false, true, true);
            this.CreateGridColumn(GridEscalla, "Altura", "AlturaBloque", 0, "{0:###,###0.00}", 70, true, false, true, true);
            this.CreateGridColumn(GridEscalla, "Superior", "Superior", 0, "{0:###,###0.00}", 70, false, true, true, true);
            this.CreateGridColumn(GridEscalla, "Lado 1", "lado1", 0, "{0:###,###0.00}", 70, false, true, true, true);
            this.CreateGridColumn(GridEscalla, "Lado 2", "lado2", 0, "{0:###,###0.00}", 70, false, true, true, true);
            //Codigo de Bloque MP
            this.CreateGridColumn(GridEscalla, "CodBloque", "CodBloque", 0, "", 70);
            //Almacen
            this.CreateGridColumn(GridEscalla, "Alm.Escalla", "CodAlmEscalla", 0, "", 40, true, false, false);
            this.CreateGridColumn(GridEscalla, "Almacen", "DesAlmEscalla", 0, "", 120);
            //oculto Cod Escalla
            this.CreateGridColumn(GridEscalla, "Cod.Escalla", "CodEscalla", 0, "", 60, true, false, false);
            this.CreateGridColumn(GridEscalla, "Escalla", "Escalla", 0, "", 150);
            //Almacen 
            this.CreateGridColumn(GridEscalla, "Alm.Costra", "CodAlmCostra", 0, "", 40, true, false, false);
            this.CreateGridColumn(GridEscalla, "Almacen", "DesAlmCostra", 0, "", 120);
            //oculto Cod Costra
            this.CreateGridColumn(GridEscalla, "Cod.Costra", "CodCostra", 0, "", 60, false, true, false);
            this.CreateGridColumn(GridEscalla, "Costra", "Costra", 0, "", 150);
            this.CreateGridColumn(GridEscalla, "Alto", "AltoCostra", 0, "{0:###,###0.00}", 70, false, true, true, true);
            this.CreateGridColumn(GridEscalla, "correlativo", "correlativo", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridEscalla, "EscallaUniMed", "EscallaUniMed", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridEscalla, "CostraUniMed", "CostraUniMed", 0, "", 70, true, false, false); 

            
        }
        private void CrearGruposEscallas()
        {
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Medidas de Bloque"));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["LargoBloque"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["AnchoBloque"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridEscalla.Columns["AlturaBloque"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Cepillado de bloque"));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridEscalla.Columns["Superior"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridEscalla.Columns["lado1"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridEscalla.Columns["lado2"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos de Escalla"));
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["CodAlmEscalla"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["CodEscalla"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["DesAlmEscalla"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridEscalla.Columns["Escalla"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos de Costra"));
            this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridEscalla.Columns["CodAlmCostra"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridEscalla.Columns["CodCostra"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridEscalla.Columns["DesAlmCostra"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridEscalla.Columns["Costra"]);

            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridEscalla.Columns["AltoCostra"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridEscalla.Columns["correlativo"]);
            this.gridEscalla.ViewDefinition = columnGroupsView;
        }
        private void TraerAyudaEscalla(enmAyuda tipo)
        {
            frmBusqueda frm;
            switch (tipo)
            { 
                case enmAyuda.enmEscalla:
                    frm = new frmBusqueda(enmAyuda.enmProductoXAlmacen, "22");
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        string[] datos = frm.Result.ToString().Split('/');
                        if (datos.Length > 0)
                        {
                            Util.SetValueCurrentCellText(gridEscalla, "CodEscalla", datos[0]);
                            Util.SetValueCurrentCellText(gridEscalla, "Escalla", datos[1]);
                            //unimedEscalla = Util.convertiracadena(datos[2]);
                            Util.SetValueCurrentCellText(gridEscalla, "EscallaUniMed", datos[2]);                            
                            //this.gridEscalla.CurrentRow.Cells["Escalla"].Value = datos[1];
                        }
                    }
                    break;
                case enmAyuda.enmCostra:
                    frm = new frmBusqueda(enmAyuda.enmProductoXAlmacen, "23");
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        string[] datos = frm.Result.ToString().Split('/');
                        if (datos.Length > 0)
                        {
                            Util.SetValueCurrentCellText(gridEscalla, "CodCostra", datos[0]);
                            Util.SetValueCurrentCellText(gridEscalla, "Costra", datos[1]);
                            //unimedCostra = Util.convertiracadena(datos[2]);
                            Util.SetValueCurrentCellText(gridEscalla, "CostraUniMed", datos[2]);
                        }
                    }
                    break;
                case enmAyuda.enmAlmacenxNaturaleza:
                    frm = new frmBusqueda(enmAyuda.enmAlmacenxNaturaleza, "02");
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        string codigo = Util.convertiracadena(frm.Result);

                        if (Util.IsCurrentColumn(gridEscalla.CurrentColumn, "DesAlmEscalla"))
                        {
                            Util.SetValueCurrentCellText(gridEscalla, "CodAlmEscalla", codigo);
                        }
                        else if (Util.IsCurrentColumn(gridEscalla.CurrentColumn, "DesAlmCostra"))
                        {
                            Util.SetValueCurrentCellText(gridEscalla, "CodAlmCostra", codigo);  
                        }
                        
                    }
                    break;
                default:
                    break;
            }
            
        }
        
        void limpiarescalla() {                     
            //Dimension de la escalla
            Util.SetValueCurrentCellInt(gridEscalla, "LargoBloque", 0);
            Util.SetValueCurrentCellInt(gridEscalla, "AnchoBloque", 0);
            Util.SetValueCurrentCellInt(gridEscalla, "AlturaBloque", 0);
            Util.SetValueCurrentCellInt(gridEscalla, "Superior", 0);
            Util.SetValueCurrentCellInt(gridEscalla, "lado1", 0);
            Util.SetValueCurrentCellInt(gridEscalla, "lado2", 0);
            //Escalls
            Util.SetClearCurrentCellText(gridEscalla, "CodEscalla");
            Util.SetClearCurrentCellText(gridEscalla, "Escalla");
            //Costra
            Util.SetClearCurrentCellText(gridEscalla, "Costra");
            Util.SetValueCurrentCellInt(gridEscalla, "AltoCostra", 0);
        }
        private bool ValidarEscalla()
        {
            GridViewRowInfo fila = this.gridEscalla.CurrentRow;
            if (fila.Cells["LargoBloque"].Value == null || double.Parse(Util.convertiracero(fila.Cells["LargoBloque"].Value)) == 0)
            {
                RadMessageBox.Show("Ingresar Largo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;
            }
            
            if (fila.Cells["AnchoBloque"].Value == null || double.Parse(Util.convertiracero(fila.Cells["AnchoBloque"].Value)) == 0)
            {
                RadMessageBox.Show("Ingresar Ancho", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                gridEscalla.CurrentColumn = this.gridEscalla.Columns["AnchoBloque"];
                return false;
            }
            if (fila.Cells["AlturaBloque"].Value == null || double.Parse(Util.convertiracero(fila.Cells["AlturaBloque"].Value)) == 0)
            {
                RadMessageBox.Show("Ingresar Altura", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                gridEscalla.CurrentColumn = this.gridEscalla.Columns["AlturaBloque"];
                return false;
            }
            if (fila.Cells["Superior"].Value == null || double.Parse(Util.convertiracero(fila.Cells["Superior"].Value)) == 0)
            {
                RadMessageBox.Show("Ingresar Cepillado Superior", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                gridEscalla.CurrentColumn = this.gridEscalla.Columns["Superior"];
                return false;
            }
            if (fila.Cells["lado1"].Value == null || double.Parse(Util.convertiracero(fila.Cells["lado1"].Value)) == 0)
            {
                RadMessageBox.Show("Ingresar Cepillado lado 1", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                gridEscalla.CurrentColumn = this.gridEscalla.Columns["lado1"];
                return false;
            }
            if (fila.Cells["lado2"].Value == null || double.Parse(Util.convertiracero(fila.Cells["lado2"].Value)) == 0)
            {
                RadMessageBox.Show("Ingresar Cepillado lado 2", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                gridEscalla.CurrentColumn = this.gridEscalla.Columns["lado2"];
                return false;
            }
            bool bandera = true;
            bandera = Util.ValidateCellText(fila, "DesAlmEscalla", "???", "Ingresar almacen escalla");
            if (bandera == false) return false;
            
            bandera = Util.ValidateCellText(fila, "Escalla", "???", "Ingresar Escalla");
            if (bandera == false) return false;

            bandera = Util.ValidateCellText(fila, "DesAlmCostra", "???", "Ingresar Almacen costra");
            if (bandera == false) return false;

            bandera = Util.ValidateCellText(fila, "Costra", "???", "Ingresar Costra");
            if (bandera == false) return false;

            bandera = Util.ValidateCellDbl(fila, "AltoCostra", 0, "Ingresar altura de costra");
            if (bandera == false) return false;
            //if (rbAlto.Checked == false && rbAncho.Checked == false && rbLargo.Checked == false) 
            //{                
            //    RadMessageBox.Show("Seleccionar Lado de corte", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            //    return false;
            //}
            
            if (gridControl.Rows.Count == 0)
            {
                RadMessageBox.Show("Debe ingresar detalle produccion", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return false;    
            }
            bandera = Util.ValidateCellText(gridControl, "codigoOperador", "", "Codigo de operador no valido");
            if (bandera == false) return false;
            bandera = Util.ValidateCellText(gridControl, "NroCaja", "", "Nro de caja no valido");
            if (bandera == false) return false;
            bandera = Util.ValidateCellText(gridControl, "UnidadMedida", "", "Unidad de medida no valido");
            if (bandera == false) return false;
            bandera = Util.ValidateCellText(gridControl, "IN07NROCAJAINGRESO", "", "Nro de caja ingreso no valido");
            if (bandera == false) return false;
            bandera = Util.ValidateCellText(gridControl, "IN07FECHAPROCESO", "", "Fecha de proceso  no valido");
            if (bandera == false) return false;
            bandera = Util.ValidateCellDbl(gridControl, "Orden", 0, "Nro de orden no valido");
            if (bandera == false) return false;

            return true;
        }
        private void guardarEnModalxFlag()
        {
            if (isEscallaLoaded == true)
            {

            }
            else if (isSaldoxBloqueloaded == true)
            { 
            
            }
        }
        private void guardarEscalla()
        {
            // ===================================================== Guardar x flag de escalla =============================================================================
            double largo = double.Parse(Util.convertiracero(this.gridEscalla.CurrentRow.Cells["LargoBloque"].Value));
            double ancho = double.Parse(Util.convertiracero(this.gridEscalla.CurrentRow.Cells["AnchoBloque"].Value));
            double alto = double.Parse(Util.convertiracero(this.gridEscalla.CurrentRow.Cells["AlturaBloque"].Value));

            double superior = double.Parse(Util.convertiracero(this.gridEscalla.CurrentRow.Cells["Superior"].Value));
            double lado1 = double.Parse(Util.convertiracero(this.gridEscalla.CurrentRow.Cells["lado1"].Value));
            double lado2 = double.Parse(Util.convertiracero(this.gridEscalla.CurrentRow.Cells["lado2"].Value));
            double altoCostra = Util.GetCurrentCellDbl(gridEscalla, "AltoCostra");

            // Medidas de escalla superior
            double escsupLargo = largo;
            double escsupAncho = ancho;
            double escsupAlto = superior * 10; // se conviero a milimetros
            // Medidas de escalla lateral 1
            double esclat1Largo = largo;
            double esclat1Ancho = alto;
            double esclat1Alto = lado1 * 10;

            // Medidas de escalla lateral 2
            double esclat2Largo = largo;
            double esclat2Ancho = alto;
            double esclat2Alto = lado2 * 10;

            // Medidas de costra
            double costraLargo = largo;
            double costraAncho = ancho;
            double costraAlto = altoCostra * 10;



            /* Caoturar valores de  detalle de documento */
            string operador = Util.convertiracadena(this.gridControl.CurrentRow.Cells["codigoOperador"].Value); // 1
            string fecha = dtpFechaOT.Value.ToShortDateString(); //2
            string hinicio = "0"; //3
            string hfin = "0"; //4
            string hsalida = "0"; //5
            string canastilla = Util.convertiracadena(this.gridControl.CurrentRow.Cells["NroCaja"].Value); //6
            int cantidad = 1; // 7                                    
            string unidad = Util.convertiracadena(this.gridControl.CurrentRow.Cells["UnidadMedida"].Value);
            string codTurno = Util.convertiracadena(this.gridControl.CurrentRow.Cells["in07prodTurnoCod"].Value);
            double nrodeorden = double.Parse(this.gridControl.CurrentRow.Cells["Orden"].Value.ToString());
            DateTime fechaproceso = Convert.ToDateTime(Util.convertiracadena(this.gridControl.CurrentRow.Cells["IN07FECHAPROCESO"].Value));

            //Capturar valores de escalla
            string pedidoventa = "";

            string articuloalmEscalla = Util.GetCurrentCellText(gridEscalla, "CodAlmEscalla");
            string articuloEscalla = Util.convertiracadena(this.gridEscalla.CurrentRow.Cells["CodEscalla"].Value);
            string articuloalmCostra = Util.GetCurrentCellText(gridEscalla, "CodAlmCostra");
            string articuloCostra = Util.GetCurrentCellText(this.gridEscalla, "CodCostra");
            string codcliente = Logueo.codigoClientxDefecto;
            unimedEscalla = Util.GetCurrentCellText(this.gridEscalla, "EscallaUniMed");
            unimedCostra = Util.GetCurrentCellText(this.gridEscalla, "CostraUniMed");



            /// Orden de trabajo
            string ordentrabajo = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);



            string MPEmpresa = Logueo.CodigoEmpresa;
            string MPAnio = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngAA");
            string MPMes = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngMM");
            string MPTipDoc = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngTIPDOC");
            string MPCoddoc = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngCODDOC");
            string MPKey = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngKEY");
            string nrocajaingreso = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");

            double MPAncho = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07ANCHO");
            double MPLargo = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07LARGO");
            double MPAlto = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07ALTO");

            double ALtoCostra = Util.GetCurrentCellDbl(gridEscalla, "AltoCostra");

            double nuevoNroOrden = 0;
            DocumentoLogic.Instance.TraerNroOrden(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                txtCodTipoDocumento.Text, txtNumeroDoc.Text, "", out nuevoNroOrden);

            // Traer nro de caja por defecto
            string nrocajacostra = "", nrocajaescalla = "";
            GlobalLogic.Instance.DameValorxDefecto(Logueo.CodigoEmpresa, Logueo.codModulo, "00005", out nrocajaescalla);
            GlobalLogic.Instance.DameValorxDefecto(Logueo.CodigoEmpresa, Logueo.codModulo, "00006", out  nrocajacostra);

            string[] filas = new string[4];
            // Registro de escalla
            filas[0] = Logueo.CodigoEmpresa + "|" +  //1
                        Logueo.Anio + "|" +  //2
                        Logueo.Mes + "|" +  //3
                        this.txtCodTipoDocumento.Text.Trim() + "|" + //4
                        this.txtNumeroDoc.Text.Trim() + "|" +  //5
                        articuloEscalla + "|" + //6
                        (nuevoNroOrden + 1) + "|" +  //7
                        unimedEscalla + "|" +  //8
                        string.Format("{0:yyyyMMdd}", dtpFechaOT.Value, 103) + "|" +  //9
                        articuloalmEscalla + "|" +  //10
                        txtCodDocRespaldo.Text.Trim() + "|" +  //11 - IN07CODTRA
                        "E" + "|" + //12
                        cantidad.ToString() + "|" +  //13
                        escsupLargo + "|" + //14
                        escsupAncho + "|" + //15
                        escsupAlto + "|" + //16
                        nrocajaescalla + "|" + //17 --> NROCAJA
                        pedidoventa + "|" + //18
                        (largo * ancho * superior) + "|" + //19                        
                        ordentrabajo + "|" +  //20
                        operador + "|" +  //21
                        Util.convertirahoras(hsalida) + "|" +  //22
                        nrocajaingreso + "|" +  //23
                        Util.convertirahoras(hinicio) + "|" +  //24
                        Util.convertirahoras(hfin) + "|" +  //25
                        string.Format("{0:yyyyMMdd}", fechaproceso, 103) + "|" +//26
                        codTurno + "|";
            //proveedorMP + "|" +  //27
            //codcliente + "|";  //28                                                                                              

            //Registro de escalla
            filas[1] = Logueo.CodigoEmpresa + "|" +  //1
                        Logueo.Anio + "|" +  //2
                        Logueo.Mes + "|" +  //3
                        this.txtCodTipoDocumento.Text.Trim() + "|" + //4
                        this.txtNumeroDoc.Text.Trim() + "|" +  //5
                        articuloEscalla + "|" + //6
                        (nuevoNroOrden + 2) + "|" +  //7
                        unimedEscalla + "|" +  //8
                        string.Format("{0:yyyyMMdd}", dtpFechaOT.Value, 103) + "|" +  //9
                        articuloalmEscalla + "|" +  //10
                        txtCodDocRespaldo.Text.Trim() + "|" +  //11 - IN07CODTRA
                        "E" + "|" + //12
                        cantidad.ToString() + "|" +  //13
                        esclat1Largo + "|" + //14
                        esclat1Ancho + "|" + //15
                        esclat1Alto + "|" + //16
                        nrocajaescalla + "|" + //17 --> NROCAJA
                        pedidoventa + "|" + //18
                        (largo * alto * lado1) + "|" +  //19
                        ordentrabajo + "|" +  //20
                        operador + "|" +  //21
                        Util.convertirahoras(hsalida) + "|" +  //22
                        nrocajaingreso + "|" +  //23
                        Util.convertirahoras(hinicio) + "|" +  //24
                        Util.convertirahoras(hfin) + "|" +  //25
                        string.Format("{0:yyyyMMdd}", fechaproceso, 103) + "|" + //26
                        codTurno + "|";
            //Registros escalla
            filas[2] = Logueo.CodigoEmpresa + "|" +  //1
            Logueo.Anio + "|" +  //2
            Logueo.Mes + "|" +  //3
            this.txtCodTipoDocumento.Text.Trim() + "|" + //4
            this.txtNumeroDoc.Text.Trim() + "|" +  //5
            articuloEscalla + "|" + //6
            (nuevoNroOrden + 3) + "|" +  //7
            unimedEscalla + "|" +  //8
            string.Format("{0:yyyyMMdd}", dtpFechaOT.Value, 103) + "|" +  //9
            articuloalmEscalla + "|" +  //10
            txtCodDocRespaldo.Text.Trim() + "|" +  //11 - IN07CODTRA
            "E" + "|" + //12
            cantidad.ToString() + "|" +  //13
            esclat2Largo + "|" + //14
            esclat2Ancho + "|" + //15
            esclat2Alto + "|" + //16
            nrocajaescalla + "|" + //17 --> NROCAJA
            pedidoventa + "|" + //18
            (largo * alto * lado2) + "|" + // 19
            ordentrabajo + "|" +  //20
            operador + "|" +  //21
            Util.convertirahoras(hsalida) + "|" +  //22
            nrocajaingreso + "|" +  //23
            Util.convertirahoras(hinicio) + "|" +  //24
            Util.convertirahoras(hfin) + "|" +  //25
            string.Format("{0:yyyyMMdd}", fechaproceso, 103) + "|" +//26
            codTurno + "|";

            //Registro de costra
            filas[3] = Logueo.CodigoEmpresa + "|" +  //1
                        Logueo.Anio + "|" +  //2
                        Logueo.Mes + "|" +  //3
                        this.txtCodTipoDocumento.Text.Trim() + "|" + //4
                        this.txtNumeroDoc.Text.Trim() + "|" +  //5
                        articuloCostra + "|" + //6
                        (nuevoNroOrden + 4) + "|" +  //7
                        unimedCostra + "|" +  //8
                        string.Format("{0:yyyyMMdd}", dtpFechaOT.Value, 103) + "|" +  //9
                        articuloalmCostra + "|" +
                        txtCodDocRespaldo.Text.Trim() + "|" +
                        "E" + "|" +
                        cantidad.ToString() + "|" +
                        costraLargo + "|" + //14
                        costraAncho + "|" + //15
                        costraAlto + "|" + //16
                        nrocajacostra + "|" +
                        pedidoventa + "|" +
                        (largo * altoCostra * ancho) + "|" +
                        ordentrabajo + "|" +
                        operador + "|" +
                        Util.convertirahoras(hsalida) + "|" +
                        nrocajaingreso + "|" +
                        Util.convertirahoras(hinicio) + "|" +
                        Util.convertirahoras(hfin) + "|" +
                        string.Format("{0:yyyyMMdd}", fechaproceso, 103) + "|" +
                        codTurno + "|";
            string xmldata = ConvertiraXMLvariasColumnas(filas);
            string cMsgreturn = "";
            int cFlag = 0;

            //cargar e insertar data de escalla
            double EscallaLat1 = lado1;
            double Escallalat2 = lado2;
            double EscallalaSup = superior;


            string EscallaLadoCorte = "";
            if (rbAlto.Checked) { EscallaLadoCorte = "AL"; }
            if (rbAncho.Checked) { EscallaLadoCorte = "AN"; }
            if (rbLargo.Checked) { EscallaLadoCorte = "LA"; }
            string EscallaAlmCod = articuloalmEscalla;
            string EscallaCodProd = articuloEscalla;
            string CostraAlmacenCod = articuloalmCostra;
            string CostraCodProd = articuloCostra;

            //Metodo para insertar a tabla de bloque detalle , escallas y costra
            string bloquenro = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
            DocumentoLogic.Instance.InsercionEscalla(MPEmpresa, bloquenro, MPAncho, MPLargo, MPAlto, EscallaLat1,
            Escallalat2, EscallalaSup, EscallaLadoCorte, EscallaAlmCod, EscallaCodProd,
            CostraAlmacenCod, CostraCodProd, ALtoCostra, xmldata, out cMsgreturn, out cFlag);

            Util.ShowMessage(cMsgreturn, cFlag);

            //refrescar grilla de detalle de produccion
            cargarProductosDet();
            popupEscalla.Hide();

        }
        
    
        // ============================================================================================================================================================
        // ======================================================== Botones de mantenimiento ==========================================================================
        // ======================================================= Al modal de "escalla" o "saldo x Bloque" ===========================================================
        // ============================================================================================================================================================
        private void cmbGuardarEscalla_Click(object sender, EventArgs e)
        {            
            if (isFormatoEscalla == true)
            {
                if (!ValidarEscalla()) return;
                guardarEscalla();
            }
            else if (isFormatoSaldoxBloque == true)
            {
                if (!ValidarSaldoxBloque()) return;
                guardarSaldoxBloque();
            }
        }
        private void cmbEliminarEscalla_Click(object sender, EventArgs e)
        {
            if (isFormatoEscalla == true)
            {
                EliminarEscalla();                
            }
            else if (isFormatoSaldoxBloque == true)
            {                
                EliminarSaldoxBloque();
            }
        }
        private void cmbCancelarEscalla_Click(object sender, EventArgs e)
        {
            if (isFormatoEscalla == true)
            {
                foreach (GridViewCellInfo celda in gridEscalla.CurrentRow.Cells)
                {
                    celda.Value = null;
                }
                this.popupEscalla.Hide();                
            }
            else if (isFormatoSaldoxBloque == true)
            {
                this.popupEscalla.Hide();
            }
        }

        // ==================================================================== Metodos de Escalla ====================================================================
        private void TraerEscalla()
        {
            try
            {
                rbAlto.Checked = false; rbAncho.Checked = false; rbLargo.Checked = false;                               
                string nrobloque = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
                List<BloqueCorteDetalle> lista = DocumentoLogic.Instance.TraerEscalla(Logueo.CodigoEmpresa,  Logueo.Anio, nrobloque);

                //Cargar datos en la grilla

                this.gridEscalla.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowAlert(ex.Message);
            }
        }
        private void EliminarEscalla()
        {
            string MPEmpresa = Logueo.CodigoEmpresa;
            string MPAnio = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngAA");
            string MPMes = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngMM");
            string MPTipDoc = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngTIPDOC");
            string MPCoddoc = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngCODDOC");
            string MPKey = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngKEY");
            //double MPOrden = Util.GetCurrentCellDbl(gridMateriaPrima, "Orden");
            double MPAncho = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07ANCHO");
            double MPLargo = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07LARGO");
            double MPAlto = Util.GetCurrentCellDbl(gridMateriaPrima, "IN07ALTO");
            
            int cFlag = 0;
            string cMsgRetorno = "";
            //DocumentoLogic.Instance.EliminarEscalla(MPEmpresa, MPAnio, MPMes, MPTipDoc,
            //    MPCoddoc, MPKey, MPOrden, out cFlag, out cMsgRetorno);
            double MPOrden = 0;

            string bloquenro = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
            int bloquecorrelativo = Util.GetCurrentCellInt(gridEscalla, "correlativo");
            
            DocumentoLogic.Instance.EliminarEscalla(MPEmpresa, bloquenro, bloquecorrelativo, out cFlag, out cMsgRetorno);
            bool processOK = Util.ShowMessage(cMsgRetorno, cFlag);
            if (processOK == true)
            {
                Util.MostrarPopUp(this.popupEscalla, false);
                cargarProductosDet();
            }

        }
        private string ConvertiraXMLvariasColumnas(IEnumerable<string> lista) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<DataSet>");
            foreach(string itm in lista)
            {
                string[] datos = itm.Split('|');

                sb.Append("<tbl><campo1>");
                sb.Append(datos[0]);
                sb.Append("</campo1>");
                //
                sb.Append("<campo2>");
                sb.Append(datos[1]);
                sb.Append("</campo2>");
                //
                sb.Append("<campo3>");
                sb.Append(datos[2]);
                sb.Append("</campo3>");
                //
                sb.Append("<campo4>");
                sb.Append(datos[3]);
                sb.Append("</campo4>");
                //
                sb.Append("<campo5>");
                sb.Append(datos[4]);
                sb.Append("</campo5>");
                //
                sb.Append("<campo6>");
                sb.Append(datos[5]);
                sb.Append("</campo6>");
                //
                sb.Append("<campo7>");
                sb.Append(datos[6]);
                sb.Append("</campo7>");
                //
                sb.Append("<campo8>");
                sb.Append(datos[7]);
                sb.Append("</campo8>");
                //
                sb.Append("<campo9>");
                sb.Append(datos[8]);
                sb.Append("</campo9>");
                //
                sb.Append("<campo10>");
                sb.Append(datos[9]);
                sb.Append("</campo10>");
                //
                sb.Append("<campo11>");
                sb.Append(datos[10]);
                sb.Append("</campo11>");
                //
                sb.Append("<campo12>");
                sb.Append(datos[11]);
                sb.Append("</campo12>");
                //
                sb.Append("<campo13>");
                sb.Append(datos[12]);
                sb.Append("</campo13>");
                //
                sb.Append("<campo14>");
                sb.Append(datos[13]);
                sb.Append("</campo14>");
                //
                sb.Append("<campo15>");
                sb.Append(datos[14]);
                sb.Append("</campo15>");
                //
                sb.Append("<campo16>");
                sb.Append(datos[15]);
                sb.Append("</campo16>");
                //
                sb.Append("<campo17>");
                sb.Append(datos[16]);
                sb.Append("</campo17>");
                //
                sb.Append("<campo18>");
                sb.Append(datos[17]);
                sb.Append("</campo18>");
                //
                sb.Append("<campo19>");
                sb.Append(datos[18]);
                sb.Append("</campo19>");
                //
                sb.Append("<campo20>");
                sb.Append(datos[19]);
                sb.Append("</campo20>");
                //
                sb.Append("<campo21>");
                sb.Append(datos[20]);
                sb.Append("</campo21>");
                //
                sb.Append("<campo22>");
                sb.Append(datos[21]);
                sb.Append("</campo22>");
                //
                sb.Append("<campo23>");
                sb.Append(datos[22]);
                sb.Append("</campo23>");
                //
                sb.Append("<campo24>");
                sb.Append(datos[23]);
                sb.Append("</campo24>");
                //
                sb.Append("<campo25>");
                sb.Append(datos[24]);
                sb.Append("</campo25>");
                //
                sb.Append("<campo26>");
                sb.Append(datos[25]);
                sb.Append("</campo26>");
                //
                sb.Append("<campo27>");
                sb.Append(datos[26]);
                sb.Append("</campo27></tbl>");
                //
                //sb.Append("<campo28>");
                //sb.Append(datos[27]);
                //sb.Append("</campo28></tbl>");
                //
            }
            sb.Append("</DataSet>");
            return sb.ToString();
        }
        
        // ==================================================================== Abrir el modal de Escalla =============================================================
        private void btnInsertarEscalla_Click(object sender, EventArgs e)
        {
            if (this.gridMateriaPrima.Rows.Count == 0)
            {
                RadMessageBox.Show("Debe agregar un registro al menos", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }
            // ==================================================== Crear columnas de la grilla escalla ==============================================================
            if (gridEscalla.Columns.Count > 0)
            {
                gridEscalla.Columns.Clear();
            }
            CrearColumnasEscalla();
            CrearGruposEscallas();
            // ==================================================== Agrupar las columnas de la grilla escalla. ========================================================
            MostrarVentanaEscalla();
        }
        
        // ================================================================ Eventos de la ventana modal Escall o "Saldo x bloque"
        private void popupEscalla_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void popupEscalla_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                popupEscalla.Left = e.X + popupEscalla.Left - MouseDownLocation.X;                
                popupEscalla.Top = e.Y + popupEscalla.Top - MouseDownLocation.Y;                
            }
        }

        private void rcbInsercionEscalla_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void rcbInsercionEscalla_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                popupEscalla.Left = e.X + popupEscalla.Left - MouseDownLocation.X;
                popupEscalla.Top = e.Y + popupEscalla.Top - MouseDownLocation.Y;                
            }
        }

        // ============================================================== Boton para salir del pop up de escalla o pop up de saldo x bloque. ===========================
        private void btnSalirEscalla_Click(object sender, EventArgs e)
        {           
            this.popupEscalla.Hide();
        }

        void gridEscalla_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            if (isFormatoEscalla == true)
            {
                if (isEscallaLoaded == true)
                {
                    string columname = this.gridEscalla.CurrentColumn.Name;
                    Util.SetCellInitEdit(gridEscalla, columname, 0, 15);
                }
            }else{             
                string columnName = this.gridEscalla.CurrentColumn.Name;
                Util.SetCellInitEdit(gridEscalla, columnName, 0, 6);             
                }                       
        }
        void gridEscalla_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }        
        #endregion
        // =================================================================== SALDO X BLOQUE ===================================================================
        #region "Saldos x bloque"
        
        
        private bool isSaldoxBloqueloaded = false;
        private bool isFormatoSaldoxBloque = false;
        private void ConfigurarVentanaSaldoxBloque()
        {
            Util.dimensionarPopUp(this.popupEscalla, 620, 220);
            Util.posicionarPopUp(this.popupEscalla, 90, 50);
            Util.MostrarPopUp(this.popupEscalla, true);
            this.popupEscalla.Focus();
            this.gridEscalla.Focus();
            
            lblEscallaTitulo.Text = "SALDO X BLOQUE";
            Util.ConfigGridToEnterNavigation(gridEscalla);            
        }
        private void MostrarVentanaSaldoxBloque()
        {
            isFormatoSaldoxBloque = true;
            //ocultar controles  de lado corte
            label2.Visible = false;
            rbAlto.Visible = false;
            rbAncho.Visible = false;
            rbLargo.Visible = false;
            
            TraerSaldoxBloque();
            // si en nuestra grilla de saldo por bloque
            // tneemos cero filas
            if (gridEscalla.RowCount == 0)
            {
                //Agregar una fila a la grilla.
                this.gridEscalla.Rows.AddNew();
                limpiarSaldoxBloque();
            }
            ConfigurarVentanaSaldoxBloque();

            //Asignar el foco al tipo de documento                        
            double largo = Util.GetCurrentCellDbl(gridEscalla, "Largo");
            double ancho = Util.GetCurrentCellDbl(gridEscalla, "Ancho");
            double alto = Util.GetCurrentCellDbl(gridEscalla, "Alto");

            double volumen = (largo* ancho * alto)  * 1;
            Util.SetValueCurrentCellDbl(gridEscalla, "Volumen", volumen);

            string cajaIngreso = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
            Util.SetValueCurrentCellText(gridEscalla, "IN07NROCAJAINGRESO", cajaIngreso);

            Util.SetCellInitEdit(gridEscalla, "Largo");

            isSaldoxBloqueloaded = true;
        }
        //
        private void limpiarSaldoxBloque()
        {
            //Obtener valor de  grilla detalle y  grilla cabecera , 
            //para asignar los campo de grilla "Saldo x Bloque".
            Util.SetValueCurrentCellText(gridEscalla, "CodigoEmpresa", Logueo.CodigoEmpresa);
            Util.SetValueCurrentCellText(gridEscalla, "Anio", Logueo.Anio);
            Util.SetValueCurrentCellText(gridEscalla, "Mes", Logueo.Mes);

            //Obtener el codigo de tipo de documento 
            //Util.SetValueCurrentCellText(gridEscalla, "IN07TIPDOC", 

            //Dimension de la escalla
            Util.SetValueCurrentCellInt(gridEscalla, "Cantidad", 1);
            Util.SetValueCurrentCellInt(gridEscalla, "Largo", 0);
            Util.SetValueCurrentCellInt(gridEscalla, "Ancho", 0);
            Util.SetValueCurrentCellInt(gridEscalla, "Alto", 0);
            Util.SetValueCurrentCellDbl(gridEscalla, "Volumen", 0);
        }
        private void crearColumnasSaldoxBloque()
        {
            RadGridView GridSaldoxBloque = CreateGridVista(this.gridEscalla);
            bool readOnlyOK = true , visibleOK = true, editableOK = true, numericOK = true;
            string numericAlign = "right";
            //Campos Ocultos
            this.CreateGridColumn(GridSaldoxBloque, "Empresa", "CodigoEmpresa", 0, "", 70, readOnlyOK, editableOK, !visibleOK);
            this.CreateGridColumn(GridSaldoxBloque, "Anio", "Anio", 0, "", 70, readOnlyOK, !editableOK, !visibleOK);
            this.CreateGridColumn(GridSaldoxBloque, "Mes", "Mes", 0, "", 70, readOnlyOK, !editableOK, !visibleOK);
            this.CreateGridColumn(GridSaldoxBloque, "Tip.Doc", "CodigoTipoDocumento", 0, "", 70, readOnlyOK, !editableOK, !visibleOK);
            this.CreateGridColumn(GridSaldoxBloque, "Cod.Doc", "CodigoDocumento", 0, "", 70, readOnlyOK, !editableOK, !visibleOK);
            this.CreateGridColumn(GridSaldoxBloque, "Cod.Prod", "CodigoArticulo", 0, "", 70, readOnlyOK, !editableOK, !visibleOK);
            this.CreateGridColumn(GridSaldoxBloque, "Uni.Med", "UnidadMedida", 0, "", 40, !readOnlyOK, editableOK, !visibleOK);
            //oculto
            // float    - oculto
            this.CreateGridColumn(GridSaldoxBloque, "Orden", "Orden", 0, "{0:###,###0.00}", 70, readOnlyOK, !editableOK, !visibleOK, numericOK, numericAlign);
            //Datetime  - oculto
            this.CreateGridColumn(GridSaldoxBloque, "Fec.Doc", "FechaDoc", 0, "{0:ddMMyyyy}", 120, readOnlyOK, !editableOK, !visibleOK);
            // Campos   - Oculto
            this.CreateGridColumn(GridSaldoxBloque, "Cod.Alm", "CodigoAlmacen", 0, "", 60, readOnlyOK, !editableOK,!visibleOK);
            //Decimal   - Oculto
            this.CreateGridColumn(GridSaldoxBloque, "Cantidad", "Cantidad", 0, "{0:###,###0.00}", 150, !readOnlyOK, editableOK, !visibleOK);

            this.CreateGridColumn(GridSaldoxBloque, "Caja Ingreso", "IN07NROCAJAINGRESO", 0, "", 90, readOnlyOK, editableOK, visibleOK);
            // float
            this.CreateGridColumn(GridSaldoxBloque, "Largo", "Largo", 0, "{0:###,###0.00}", 60, !readOnlyOK, editableOK, visibleOK, numericOK, numericAlign);
            this.CreateGridColumn(GridSaldoxBloque, "Ancho", "Ancho", 0, "{0:###,###0.00}", 60, !readOnlyOK, editableOK, visibleOK, numericOK, numericAlign);
            this.CreateGridColumn(GridSaldoxBloque, "Alto", "Alto", 0, "{0:###,###0.00}", 60, !readOnlyOK, editableOK, visibleOK, numericOK, numericAlign);

            this.CreateGridColumn(GridSaldoxBloque, "Volumen", "Volumen", 0, "{0:###,###0.00}", 60, readOnlyOK, editableOK, visibleOK, numericOK, numericAlign);

            this.CreateGridColumn(GridSaldoxBloque, "Observacion", "in07observacion", 0, "", 250, !readOnlyOK, editableOK, visibleOK);
            //oculto
            this.CreateGridColumn(GridSaldoxBloque, "NroCaja", "NroCaja", 0, "", 120, readOnlyOK, !editableOK, !visibleOK);

        }
        private void TraerSaldoxBloque()
        {
            try
            {
                rbAlto.Checked = false; rbAncho.Checked = false; rbLargo.Checked = false;

                string nroCajaIngreso = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");

                List<Movimiento> lista = DocumentoLogic.Instance.TraeSaldoxBloque(Logueo.CodigoEmpresa, nroCajaIngreso);                

                ////Cargar datos en la grilla saldoxbloque
                this.gridEscalla.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowAlert(ex.Message);
            }
        }
        private void TraerAyudaSaldoxBloque()
        { 
        }
        private void EliminarSaldoxBloque()
        {
            if (this.gridEscalla.Rows.Count == 0) { return; }
            GridViewRowInfo row =  this.gridEscalla.CurrentRow;
            bool isConfirmed =  Util.ShowQuestion("¿Desea eliminar el registro?");
            if (isConfirmed == true)
            {
                string tipoDocumento = Util.GetCurrentCellText(row, "CodigoTipoDocumento");
                string codigoDocumento = Util.GetCurrentCellText(row, "CodigoDocumento");
                string codigoProducto = Util.GetCurrentCellText(row, "CodigoArticulo");
                double orden = 1;
                string nroCaja = Util.GetCurrentCellText(row, "NroCaja");
                int flag = 0;
                string mensaje = "";
                DocumentoLogic.Instance.EliminarSaldoxBloque(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipoDocumento,
                    codigoDocumento, codigoProducto, orden, nroCaja, out flag, out mensaje);
                Util.ShowMessage(mensaje, flag);
            }
            TraerSaldoxBloque();
            //oculta nuestro panel de saldo x bloque
            this.popupEscalla.Hide();
        }
        private bool ValidarSaldoxBloque()
        {
            bool bandera = false;
            GridViewRowInfo row = this.gridEscalla.CurrentRow;
            
            bandera = Util.ValidateCellDbl(row, "Largo", 0, "Ingresar largo");
            if (bandera == false) return false;
            bandera = Util.ValidateCellDbl(row, "Alto", 0, "Ingresar alto");
            if (bandera == false) return false;
            bandera = Util.ValidateCellDbl(row, "Ancho", 0, "Ingresar ancho");
            if (bandera == false) return false;            
            bandera = Util.ValidateCellText(row, "in07observacion", "", "Ingresar observacion");
            if (bandera == false) return false;

            bandera = Util.ValidateCellText(gridMateriaPrima, "IN07NROCAJA", "", "Ingresar nro de caja");
            if (bandera == false) return false;
            return bandera;
        }
        private void guardarSaldoxBloque()
        {

            string codigoArticulo = Util.GetCurrentCellText(gridMateriaPrima, "IN07DocIngKEY");
            string unidadArticulo = Util.GetCurrentCellText(gridMateriaPrima, "IN01UNIMED");
            double alto = 0, largo = 0, ancho = 0; double volumen = 1;


            largo = Util.GetCurrentCellDbl(gridEscalla, "Largo");
            alto = Util.GetCurrentCellDbl(gridEscalla, "Alto");
            ancho = Util.GetCurrentCellDbl(gridEscalla, "Ancho");
            volumen =  Util.GetCurrentCellDbl(gridEscalla, "Volumen");
            string nroCajaDeBloqueSaldo = "";
            nroCajaDeBloqueSaldo = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
            string codigoOrdenTrabajo = Util.GetCurrentCellText(gridOrdenTrabajo, "codigo");
            string observacion = Util.GetCurrentCellText(gridEscalla, "in07observacion");
            int flag = 0; string mensaje = "";
            DocumentoLogic.Instance.InsertarSaldoxBloque(Logueo.CodigoEmpresa,
                Logueo.Anio,
                Logueo.Mes,
                dtpFechaOT.Value,
                codigoArticulo,
                unidadArticulo,
                volumen,
                largo,
                ancho,
                alto,
                nroCajaDeBloqueSaldo,
                codigoOrdenTrabajo,
                observacion,
                out flag,
                out mensaje);
            if (flag == 0)
                Util.ShowMessage(mensaje, flag);
            else if (flag == -1)
                Util.ShowAlert(mensaje);

            //Si el flag es cero traer saldo x bloque desde la base de datos
            if (flag == 0)
                TraerSaldoxBloque();
        }
        // ============================================== Boton para mostrar la ventan de insercion saldo x bloque ====================================================
        private void btnInsertarSaldoxBloque_Click(object sender, EventArgs e)
        {
            
            if (this.gridMateriaPrima.Rows.Count == 0)
            {
                Util.ShowAlert("Agregar canastilla/bloque MP");
                return;
            }

            //si tengo agregado un fila , validar si tiene en al fila agregado un nro de bloque MP.
           bool bandera =  Util.ValidateCellText(this.gridMateriaPrima.CurrentRow, "IN07NROCAJA", "", "Agregar canastilla/bloque MP");
           if (bandera == false)
           {
               return;
           }
            // ==================================================== Crear columnas saldo x bloque ==================================================== 
            if (gridEscalla.Columns.Count > 0)
            {
                gridEscalla.Columns.Clear();
            }

            crearColumnasSaldoxBloque();
            crearGruposColumnasSaldoxBloque();
            MostrarVentanaSaldoxBloque();
        }

        #endregion
        // =================================================================== ERRORES ====================================================================================
        #region "Errores"
        private void CentrarErrorDetalle()
        {
                        
        }
        private void CrearColumnasErrores()
        {
            RadGridView Grid = CreateGridVista(this.gridErroresDetalle);
            CreateGridColumn(Grid, "Codigo", "PRO10CODIGO", 0, "", 70, true);
            CreateGridColumn(Grid, "Descripcion", "PRO10DESCRIPCION", 0, "", 150, true);                            
            CreateGridChkColumn(Grid, "Estado", "EstadoError", 0, "", 70, false, true);
        }
        private void CargarErroresDetalle()
        { 
            
            List<ErroresComunes> lista = ErroresComunesLogic.Instance.TraerErroresDetalle(Logueo.CodigoEmpresa,
                Logueo.Anio, Logueo.Mes, txtCodTipoDocumento.Text, txtNumeroDoc.Text,
                Util.convertiracadena(this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value),
                Convert.ToDouble(this.gridControl.CurrentRow.Cells["Orden"].Value));
            this.gridErroresDetalle.DataSource = lista;

        }

        private void btnInsertarErrores_Click(object sender, EventArgs e)
        {
            CentrarErrorDetalle();
            string codigoOperario = Util.convertiracadena(this.gridControl.CurrentRow.Cells["codigoOperador"].Value);
            string nombreOperario = Util.convertiracadena(this.gridControl.CurrentRow.Cells["Operador"].Value);

            if (codigoOperario == "")
            {
                RadMessageBox.Show("No tiene asignado codigo de operario asignado", "Sistema", 
                                            MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }
            this.popupErroresDetalle.BringToFront();
            this.popupErroresDetalle.Visible = true;
            
            CargarErroresDetalle();
            this.txtCodigoOperador.Text = codigoOperario;
            this.txtDescripcionOperador.Text = nombreOperario;
            this.txtCodigoOperador.Enabled = false;
            this.txtDescripcionOperador.Enabled = false;
        }

        private void rbGuardarError_Click(object sender, EventArgs e)
        {
            try
            {
                ErroresComunesDetalle detalle = new ErroresComunesDetalle();
                detalle.PRO11CODEMP = Logueo.CodigoEmpresa;
                detalle.PRO11DETCODEMP = Logueo.CodigoEmpresa;
                detalle.PRO11DETAA = Logueo.Anio; 
                detalle.PRO11DETMM = Logueo.Mes;
                detalle.PRO11DETTIPDOC = txtCodTipoDocumento.Text;
                detalle.PRO11DETCODDOC = txtNumeroDoc.Text;
                detalle.PRO11DETKEY = Util.convertiracadena(this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value);
                detalle.PRO11DETORDEN = Convert.ToDouble(this.gridControl.CurrentRow.Cells["Orden"].Value);

                string pmensaje = "";
                int registrosSelecciondos = 0;
//Primer for para obtener la cantidad de registros seleccionados
                foreach (GridViewRowInfo row in this.gridErroresDetalle.Rows)
                {
                    bool esSeleccionado = Convert.ToBoolean(row.Cells["EstadoError"].Value);
                    if ( esSeleccionado == true)
                    {
                        registrosSelecciondos = registrosSelecciondos + 1;
                    }
                    
                }
                string[] filas = new string[registrosSelecciondos];
                
                //For para obtener capturar y asignar al arreglo
                int x = 0;
                foreach (GridViewRowInfo row in this.gridErroresDetalle.Rows)
                {
                    bool esSeleccionado = Convert.ToBoolean(row.Cells["EstadoError"].Value);
                    if (esSeleccionado == true)
                    {
                        
                        string codigo = Util.convertiracadena(row.Cells["PRO10CODIGO"].Value);
                        filas[x] = codigo; 
                        x++;
                    }
                }

                ErroresComunesLogic.Instance.InsertarErroresDetalle(detalle, Util.ConvertiraXML(filas), out pmensaje);
                RadMessageBox.Show(pmensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);                
            }

            //ocultar panel
            //this.popupErroresDetalle.SendToBack();
            //this.popupErroresDetalle.Visible = false;
            Util.MostrarPopUp(popupErroresDetalle, false);
        }
        private void btnSalirErrores_Click(object sender, EventArgs e)
        {
            this.popupErroresDetalle.SendToBack();
            this.popupErroresDetalle.Visible = false;
        }
        #endregion
        // =================================================================== RESUMEN ====================================================================================
        #region "Resumen"
private bool flagResumenEdit = false; //  0 - > Asigna modo no editable ,1 -> Asigna modo editable 
        private void dimensionarresumen(int pwidth, int pheight)
        {
            this.popupResumen.Width = pwidth;
            this.popupResumen.Height = pheight;
        }
        private void posicionarresumen(int pointx, int pointy)
        {
            Point newlocation = new Point();
            newlocation.X = pointx;
            newlocation.Y = pointy;
            this.popupResumen.Location = newlocation;
        }
        private void gridResumen_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            GridViewColumn UserCurrentColumn = this.gridResumen.CurrentColumn;
            GridViewColumn AlmacenDesColumn = this.gridResumen.Columns["DesAlmacen"];
            GridViewColumn ArticuloDesColumn = this.gridResumen.Columns["DescripcionArticulo"];
            GridViewColumn NroCajaColumn = this.gridResumen.Columns["NroCaja"];
            GridViewColumn horaSalidaColumn = this.gridResumen.Columns["IN07HORASALIDA"];

            e.ContextMenu.Items.Clear();
            if (UserCurrentColumn.Name == AlmacenDesColumn.Name)
            {
                RadMenuItem itmModificarAlmacen = new RadMenuItem();
                itmModificarAlmacen.Text = "Modificar almacen";
                itmModificarAlmacen.Name = "modificaralmacen";
                // asignar evento click al menu
                itmModificarAlmacen.Click += new EventHandler(customMenuAlmacen_Click);
                e.ContextMenu.Items.Add(itmModificarAlmacen);
            }

            if (UserCurrentColumn.Name == ArticuloDesColumn.Name)
            {                
                RadMenuItem itmModificarArt = new RadMenuItem();
                itmModificarArt.Text = "Modificar articulo";
                itmModificarArt.Name = "modificararticulo";
                itmModificarArt.Click += new EventHandler(customMenuArticulo_Click);
                e.ContextMenu.Items.Add(itmModificarArt);
            }

            if (UserCurrentColumn.Name == NroCajaColumn.Name)
            {
                
                RadMenuItem itmModificarNroCaja = new RadMenuItem();
                itmModificarNroCaja.Text = "Modificar NroCaja";
                itmModificarNroCaja.Name = "modificarnrocaja";
                itmModificarNroCaja.Click += new EventHandler(customMenuNroCaja_Click);
                e.ContextMenu.Items.Add(itmModificarNroCaja);
            }
            if (UserCurrentColumn.Name == horaSalidaColumn.Name)
            {

                RadMenuItem itmModificarHoraSalida = new RadMenuItem();
                itmModificarHoraSalida.Text = "Modificar Hora Salida";
                itmModificarHoraSalida.Name = "modificarhorasalida";
                itmModificarHoraSalida.Click += new EventHandler(customMenuHoraSalida_Click);
                e.ContextMenu.Items.Add(itmModificarHoraSalida);
            }

}
        private void customMenuArticulo_Click(object sender, EventArgs e)
        {
            TraerAyudaResumen(enmAyuda.enmProductoXAlmacen);
            CargarResumen();
            cargarProductosDet();
            
        }
        private void customMenuNroCaja_Click(object sender, EventArgs e)
        {
            flagResumenEdit = true;
            this.gridResumen.CurrentRow.Cells["NroCaja"].BeginEdit();
        }

        private void customMenuHoraSalida_Click(object sender, EventArgs e)
        {
            flagResumenEdit = true;
            this.gridResumen.CurrentRow.Cells["IN07HORASALIDA"].BeginEdit();
        }

        private void customMenuAlmacen_Click(object sender, EventArgs e)
        {
            //trae los almacenes
            TraerAyudaResumen(enmAyuda.enmAlmacen);
            //refrescar grilla
            CargarResumen();
            cargarProductosDet();
        }

        private void CrearColumnasResumen()
        {
            RadGridView Grid = CreateGridVista(this.gridResumen);
            /*CreateGridColumn(Grid, "Cod.Alm", "IN07CODALM", 0, "", 60);*/
            CreateGridColumn(Grid, "Cod.Alm", "CodigoAlmacen", 0, "", 0, true, false, false);
            CreateGridColumn(Grid, "DesAlmacen", "DesAlmacen", 0, "", 150);

            CreateGridColumn(Grid, "NroCaja", "NroCaja", 0, "", 90, false, true);
            CreateGridColumn(Grid, "Hora Salida", "IN07HORASALIDA", 0, "", 70, false, true);

            CreateGridColumn(Grid, "Cod.Prod", "CodigoArticulo", 0, "", 100, true, false, false);
            CreateGridColumn(Grid, "Prod.Des", "DescripcionArticulo", 0, "", 350);

            CreateGridColumn(Grid, "Color", "Color", 0, "", 80);

            CreateGridColumn(Grid, "Cantidad", "Cantidad", 0, "", 80);
            
            CreateGridColumn(Grid, "Ancho", "Ancho", 0, "", 60);
            CreateGridColumn(Grid, "Largo", "Largo", 0, "", 60);
            CreateGridColumn(Grid, "Alto", "Alto", 0, "", 60);
            CreateGridColumn(Grid, "Area", "Area", 0, "", 60);
            CreateGridColumn(Grid, "Volumen", "Volumen", 0, "", 60);
            CreateGridColumn(Grid, "Peso", "Peso", 0, "", 60);
            
        }
        private void CargarResumen()
        { 
            string nroordentrabajo =  Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);
            List<MovimientoResponse> lista =  DocumentoLogic.Instance.TraerResumen(Logueo.CodigoEmpresa, Logueo.Anio, 
                                                  Logueo.Mes, txtCodTipoDocumento.Text, 
                                                  txtNumeroDoc.Text,nroordentrabajo);

            this.gridResumen.DataSource = lista;
        }
        private void btnResume_Click(object sender, EventArgs e)
        {
            CargarResumen();
            this.popupResumen.BringToFront();
            this.popupResumen.Visible = true;
    
            CargarResumen();             
            Util.MostrarPopUp(popupResumen, true);

            this.gridResumen.CellEndEdit += new GridViewCellEventHandler(gridResumen_CellEndEdit);
            this.gridResumen.CellBeginEdit += new GridViewCellCancelEventHandler(gridResumen_CellBeginEdit);
        }
        
        private void gridResumen_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            // si evento se ejecuta en NroCaja
            if (e.Column.Name == this.gridResumen.Columns["NroCaja"].Name)
            {
                //guardar NroCaja anterior
                string cNroCaja = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["NroCaja"].Value);
                //asignar nrocaja anterior al tag de la celda NroCaja
                gridResumen.CurrentRow.Cells["NroCaja"].Tag = cNroCaja;
                e.Cancel = !flagResumenEdit;
            }
            else if (e.Column.Name == this.gridResumen.Columns["IN07HORASALIDA"].Name)
            {
                
                // Capturo Caja 
                string cNroCaja = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["NroCaja"].Value);
                //asignar nrocaja anterior al tag de la celda NroCaja
                gridResumen.CurrentRow.Cells["NroCaja"].Tag = cNroCaja;

                //Capturo Hora Salida
                string horaSalida = this.gridResumen.CurrentRow.Cells["IN07HORASALIDA"].Value == null ?
                                   Util.convertirahoras("")
                                   : Util.convertirahoras(this.gridResumen.CurrentRow.Cells["IN07HORASALIDA"].Value.ToString());

                string HoraSalidaAnterior = Util.convertiracadena(horaSalida);
                //asignar nrocaja anterior al tag de la celda NroCaja
                gridResumen.CurrentRow.Cells["IN07HORASALIDA"].Tag = HoraSalidaAnterior;
                e.Cancel = !flagResumenEdit;
            }
            
        }

        private void gridResumen_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                flagResumenEdit = false;
                

                Movimiento mov = new Movimiento();

                mov.CodigoEmpresa = Logueo.CodigoEmpresa;
                mov.Anio = Logueo.Anio;
                mov.Mes = Logueo.Mes;
                mov.CodigoTipoDocumento = txtCodTipoDocumento.Text;
                mov.CodigoDocumento = txtNumeroDoc.Text;
                mov.CodigoArticulo = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["CodigoArticulo"].Value);
                mov.CodigoAlmacen = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["CodigoAlmacen"].Value);
                mov.IN07ORDENTRABAJO = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);
                string anteriorNrocaja = Util.convertiracadena(gridResumen.CurrentRow.Cells["NroCaja"].Tag);
                mov.NroCaja = anteriorNrocaja;
                string nuevonrocaja = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["NroCaja"].Value);
                
                string pmensaje = "";
                int pflag = 0;


                // Si el evento se ejecuta en NroCaja
                if (e.Column.Name == this.gridResumen.Columns["NroCaja"].Name)
                {
                    
                    //Formateo el campo hora para que no salga error; Nota : el sistema no lo toma en cuenta pues solo actualiza caja 
                    string nuevoHoraSalidaCaja = Util.convertirahoras("00:00");

                    DocumentoLogic.Instance.ActualizarResumenxFlag(mov, "", nuevonrocaja, nuevoHoraSalidaCaja, "", "C", out pflag, out pmensaje);
                    Util.ShowMessage(pmensaje, pflag);
                    CargarResumen();
                    cargarProductosDet();
                    
                }
                else if (e.Column.Name == this.gridResumen.Columns["IN07HORASALIDA"].Name)
                {
                    string anteriorHoraSalida = Util.convertiracadena(gridResumen.CurrentRow.Cells["IN07HORASALIDA"].Tag);
                    mov.IN07HORASALIDA = anteriorHoraSalida;

                    string nuevoHoraSalida = this.gridResumen.CurrentRow.Cells["IN07HORASALIDA"].Value == null ?
                                   Util.convertirahoras("")
                                   : Util.convertirahoras(this.gridResumen.CurrentRow.Cells["IN07HORASALIDA"].Value.ToString());

                    //string nuevoHoraSalida = Util.convertiracadena(horaSalidanueva);

                    
                                        
                    DocumentoLogic.Instance.ActualizarResumenxFlag(mov, "", "", nuevoHoraSalida, "", "H", out pflag, out pmensaje);
                    Util.ShowMessage(pmensaje, pflag);
                    CargarResumen();
                    cargarProductosDet();
                }

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSalirResumen_Click(object sender, EventArgs e)
        {
            this.popupResumen.SendToBack();
            this.popupResumen.Visible = false;
        }
        private void TraerAyudaResumen(enmAyuda tipo)
        {
            Movimiento mov = new Movimiento();
            frmBusqueda frm;
            string[] datos;
            switch (tipo)
            {
                case enmAyuda.enmAlmacen:
                    frm = new frmBusqueda(enmAyuda.enmAlmacen);
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        if (frm.Result.ToString() == "")
                        {
                            return;
                        }
                                                
                        string ordentrabajo = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);
                        string nrocaja = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["NroCaja"].Value);
                        
                        string nuevoalmacen = frm.Result.ToString();
                        int pflagretorno = 0;
                        string pmensaje = "";
                        mov.CodigoEmpresa = Logueo.CodigoEmpresa;
                        mov.Anio = Logueo.Anio;
                        mov.Mes = Logueo.Mes;
                        mov.CodigoTipoDocumento = txtCodTipoDocumento.Text;
                        mov.CodigoDocumento = txtNumeroDoc.Text;
                        mov.CodigoArticulo = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["CodigoArticulo"].Value);
                        mov.IN07ORDENTRABAJO = ordentrabajo;
                        mov.CodigoAlmacen = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["CodigoAlmacen"].Value);
                        mov.NroCaja = nrocaja;
                        DocumentoLogic.Instance.ActualizarResumenxFlag(mov, nuevoalmacen, "","00:00", "", "A", out pflagretorno, out pmensaje);
                        Util.ShowMessage(pmensaje, pflagretorno);                        
                    }
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    string codAlmacen = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["CodigoAlmacen"].Value);
                    frm = new frmBusqueda(enmAyuda.enmProductoXAlmacen,codAlmacen);
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        if (Util.convertiracadena(frm.Result) == "") return;                        
                        datos = frm.Result.ToString().Split('/');
                        
                        //this.gridResumen.CurrentRow.Cells["CodigoArticulo"].Value = datos[0];
                        string cCodigoArticulo = Util.convertiracadena(datos[0]);
                        
                        //Traer descripcion
                        
                        
                        // Actualizar el codigo de producto
                        string nuevocodart = cCodigoArticulo;
                        string ordentrabajo = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);
                        string nrocaja = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["NroCaja"].Value);
                        mov.CodigoEmpresa = Logueo.CodigoEmpresa;
                        mov.Anio = Logueo.Anio;
                        mov.Mes = Logueo.Mes;
                        mov.CodigoTipoDocumento = txtCodTipoDocumento.Text;
                        mov.CodigoDocumento = txtNumeroDoc.Text;
                        mov.CodigoArticulo = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["CodigoArticulo"].Value);
                        mov.IN07ORDENTRABAJO = ordentrabajo;
                        mov.CodigoAlmacen = Util.convertiracadena(this.gridResumen.CurrentRow.Cells["CodigoAlmacen"].Value);
                        mov.NroCaja = nrocaja;
                        string pmensaje = "";
                        int pflagretorno = 0;

                        DocumentoLogic.Instance.ActualizarResumenxFlag(mov, "", "","00:00", nuevocodart, "P", out pflagretorno, out pmensaje);
                        Util.ShowMessage(pmensaje, pflagretorno);

                        //ObtenerDescripcionResumen(enmAyuda.enmProductoXAlmacen, cCodigoArticulo);
                    }
                    break;
                default:
                    break;
            }
            
        }
        
        private void ObtenerDescripcionResumen(enmAyuda tipo, string codigo)
        {
            string resultado = "";
            switch (tipo)
            {
                case enmAyuda.enmAlmacen:
                    codigo = Logueo.CodigoEmpresa + codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out resultado);
                    gridResumen.CurrentRow.Cells["DesAlmacen"].Value = resultado;
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    codigo = Logueo.CodigoEmpresa + Logueo.Anio + Logueo.Mes + codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo, "ARTICULO", out resultado);
                    gridResumen.CurrentRow.Cells["DescripcionArticulo"].Value = resultado;
                    break;
                    
                default:
                    break;
            }
        }

        #endregion                      
        // =================================================================== SALDOS =====================================================================================
        #region "Saldos"
        private void IniciarSaldosProduccion()
        {
            Util.MostrarPopUp(popupSaldos, true);
            CargarSaldosProduccion();
        }
        private void GuardarSaldosProduccion()
        {
            try
            {

                string[] registros = new string[this.gridSaldos.Rows.Count];
                int x = 0;
                double cNroOrden = 0;
                DocumentoLogic.Instance.TraerNroOrden(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, txtCodTipoDocumento.Text,
                                                      txtNumeroDoc.Text, "", out cNroOrden);
                for (int i = 0; i < this.gridSaldos.Rows.Count; i++)
                {
                    //validacion para el caso de no registrar una hora inicio nulo el valor sera 00:00
                    string cHInicio = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["IN07HORAINICIO"].Value);

                    DateTime? fechaproceso = this.dtpFechaOT.Value;
                    string hInicio = cHInicio == "" ? "00:00" : Util.convertirahoras(cHInicio);
                    
                    //validacion para el caso de no registrar una hora final nulo el valor sera 00:00
                    string cHFinal = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["IN07HORAFINAL"].Value);

                    string hFinal = cHFinal == "" ? "00:00" : Util.convertirahoras(cHFinal);

                    //validacion para el caso de no registrar una hora salida nulo el valor sera 00:00
                    string cHSalida = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["IN07HORASALIDA"].Value);
                    string hSalida = cHSalida == "" ? "00:00" : Util.convertirahoras(cHSalida);
                    
                    string ordentrabajo = "";
                    //Si tenemos una orden de trabajo
                    if (gridOrdenTrabajo.Rows.Count > 0)
                    {
                        //capturo codigo de la orden de trabajo seleccionado 
                        ordentrabajo = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);
                    }
                    string cCodigoArticulo = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["CodigoArticulo"].Value);
                    string cUnidadMedida = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["UnidadMedida"].Value);
                    string cCodigoAlmacen = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["CodigoAlmacen"].Value);
                    string cCantidad = Util.convertiracero(this.gridSaldos.Rows[i].Cells["Cantidad"].Value);
                    string cLargo = Util.convertiracero(this.gridSaldos.Rows[i].Cells["Largo"].Value);
                    string cAncho = Util.convertiracero(this.gridSaldos.Rows[i].Cells["Ancho"].Value);
                    string cAlto = Util.convertiracero(this.gridSaldos.Rows[i].Cells["Alto"].Value);
                    string cNroCaja = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["NroCaja"].Value);
                    string cCodigoOperador = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["codigoOperador"].Value);
                    string cNrocajaIngreso = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["IN07NROCAJAINGRESO"].Value);
                    string cMotivoCod = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["IN07MOTIVOCOD"].Value);
					
                    string cProdTurnoCod = Util.convertiracadena(this.gridSaldos.Rows[i].Cells["in07prodTurnoCod"].Value);

                    registros[x] = Logueo.CodigoEmpresa + "|" + Logueo.Anio + "|" + Logueo.Mes + "|" +
                               this.txtCodTipoDocumento.Text + "|" + this.txtNumeroDoc.Text + "|" +
                               cCodigoArticulo + "|" + (x + cNroOrden).ToString() + "|" + cUnidadMedida+ "|" +
                                string.Format("{0:yyyyMMdd}", this.dtpFechaOT.Value) + "|" +
                               cCodigoAlmacen + "|" + this.txtCodDocRespaldo.Text + "|" + 
                               "E" + "|" + cCantidad + "|"  + cLargo + "|" + cAncho + "|" + 
                               cAlto + "|" +  cNroCaja  + "|"  + "0" + "|" + ordentrabajo +  "|" + 
                               cCodigoOperador  + "|" +  hSalida + "|" + cNrocajaIngreso  + "|" + 
                               hInicio + "|" + hFinal + "|"  +
                               string.Format("{0:yyyyMMdd}", fechaproceso, 103) + "|" +
                               cMotivoCod + "|" + cProdTurnoCod + "|" + Logueo.UserName;
                    x++;


                }
                
                string mensaje = "";
                int flag = 0;
                DocumentoLogic.Instance.InsertarSaldos(Util.ConvertiraXMLvariasColumnas(registros), out mensaje, out flag);
                if (Util.ShowMessage(mensaje, flag) == true)
                {
                    Util.MostrarPopUp(popupSaldos, false);
                    cargarProductosDet();
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
        }
        private void CrearColumnasSaldos()
        {
            RadGridView  gridSaldos = this.CreateGridVista(this.gridSaldos);
            this.CreateGridColumn(gridSaldos, "Codigo", "codigoOperador", 0, "", 70, true, false, false);
            this.CreateGridDateColumn(gridSaldos, "Fecha", "FechaDoc", 0, "{0:dd/MM/yyyy}", 70, false, true);
            this.CreateGridColumn(gridSaldos, "Operador", "Operador", 0, "", 100, true, false, esEntrada);
            // Turno 
            this.CreateGridColumn(gridSaldos, "Turno", "in07prodTurnoCod", 0, "", 90, true, false, true);
            this.CreateGridColumn(gridSaldos, "Turno.Desc.", "in07prodTurnoDesc", 0, "", 90, true, false, true);

            this.CreateGridColumn(gridSaldos, "H.Ini", "IN07HORAINICIO", 0, "", 60, false, true);
            ((GridViewTextBoxColumn)gridSaldos.Columns["IN07HORAINICIO"]).MaxLength = 5;

            this.CreateGridColumn(gridSaldos, "H.Fin", "IN07HORAFINAL", 0, "", 60, false, true);
            ((GridViewTextBoxColumn)gridSaldos.Columns["IN07HORAFINAL"]).MaxLength = 5;

            this.CreateGridColumn(gridSaldos, "#Cana.Ing", "IN07NROCAJAINGRESO", 0, "", 70, false, true);
            this.CreateGridColumn(gridSaldos, "Cantidad", "Cantidad", 0, "{0:###,###0.00}", 60, false, false, true, true, "right");

            this.CreateGridColumn(gridSaldos, "Cod.Bloque", "CodigoBloque", 0, "", 140, false, true, false);
            this.CreateGridColumn(gridSaldos, "CodMaquina", "CodMaquina", 0, "", 140, false, true, false);
            this.CreateGridColumn(gridSaldos, "Maquina", "DesMaquina", 0, "", 140, false, true, false);

            this.CreateGridColumn(gridSaldos, "Almacén", "CodigoAlmacen", 0, "", 50, false, true, true);
            this.CreateGridColumn(gridSaldos, "Código Producto", "CodigoArticulo", 0, "", 80, true, true);
            this.CreateGridColumn(gridSaldos, "Descripción", "DescripcionArticulo", 0, "", 180, true, true, true);
            this.CreateGridColumn(gridSaldos, "UM", "UnidadMedida", 0, "", 60, true, false, true);

            this.CreateGridColumn(gridSaldos, "Largo", "Largo", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(gridSaldos, "Ancho", "Ancho", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(gridSaldos, "Espesor", "Alto", 0, "{0:###,###0.00}", 60, false, true, true, true, "right");


            this.CreateGridColumn(gridSaldos, "Areaxuni", "Areaxuni", 0, "{0:###,###0.00}", 90, false, false, false, true, "right");
            this.CreateGridColumn(gridSaldos, "Orden", "Orden", 0, "{0:###,###0.00}", 70, true, false, false, true, "right");
            this.CreateGridColumn(gridSaldos, "MTS2", "MTS2", 0, "{0:###,###0.00}", 40, true, false, false, true, "right");
            this.CreateGridColumn(gridSaldos, "MTS3", "MTS3", 0, "{0:###,###0.00}", 40, true, false, false, true, "right");
            this.CreateGridColumn(gridSaldos, "Area", "Area", 0, "{0:###,###0.00}", 40, false, false, false, true, "right");
            //this.CreateGridColumn(gridSaldos, "Acabado", "Acabado", 0,"", 60);
            this.CreateGridColumn(gridSaldos, "#Cana/Blo", "NroCaja", 0, "", 80, false, true, false, false, "right");
            this.CreateGridColumn(gridSaldos, "H.Sal", "IN07HORASALIDA", 0, "", 60, false, true, false);
            ((GridViewTextBoxColumn)gridSaldos.Columns["IN07HORASALIDA"]).MaxLength = 5;
            this.CreateGridColumn(gridSaldos, "flag", "flag", 0, "", 30, false, true, false);


            //  Agrega filas ocultas para capturar los ingresos de las salidas

            this.CreateGridColumn(gridSaldos, "IN07DocIngAA", "IN07DocIngAA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridSaldos, "IN07DocIngMM", "IN07DocIngMM", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridSaldos, "IN07DocIngTIPDOC", "IN07DocIngTIPDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridSaldos, "IN07DocIngCODDOC", "IN07DocIngCODDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridSaldos, "IN07DocIngKEY", "IN07DocIngKEY", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(gridSaldos, "IN07DocIngORDEN", "IN07DocIngORDEN", 0, "", 0, true, false, false, true);
            this.CreateGridColumn(gridSaldos, "CodMotivo", "IN07MOTIVOCOD", 0, "", 60, true, false, false);
            this.CreateGridColumn(gridSaldos, "Motivo", "DesMotivo", 0, "", 120, false, true, false);
            //    Movimiento m = new Movimiento();

            this.gridSaldos.SelectionMode = GridViewSelectionMode.CellSelect;

            this.gridSaldos.MultiSelect = true;
        }
        private void CargarSaldosProduccion()
        {
            //Tomar salidas de materia prima codigo almacen saldo
            string ordentrabajo = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);

            List<MovimientoResponse> lista = DocumentoLogic.Instance.TraerSaldoxOT(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                                                                txtCodTipoDocumento.Text, txtNumeroDoc.Text, ordentrabajo, "16");

             this.gridSaldos.DataSource = lista;
        }
      
        private void btnGuardarSaldos_Click(object sender, EventArgs e)
        {
           GuardarSaldosProduccion();            
        }

        private void btnInsertarSaldos_Click(object sender, EventArgs e)
        {
            IniciarSaldosProduccion();
        }
        private void btnCerrarModalSaldos_Click(object sender, EventArgs e)
        {
            Util.MostrarPopUp(this.popupSaldos, false);
        }

        private void rpCabSaldos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void rpCabSaldos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                popupSaldos.Left = e.X + popupSaldos.Left - MouseDownLocation.X;                
                popupSaldos.Top = e.Y + popupSaldos.Top - MouseDownLocation.Y;                
            }
        }
        private void TraerAyudaSaldos(enmAyuda tipo)
        {
            frmBusqueda frm;
            string codigoSeleccionado = "";

            switch(tipo)
            {
                case enmAyuda.enmOperador:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = Util.convertiracadena(frm.Result);
                        this.gridSaldos.CurrentRow.Cells["codigoOperador"].Value = codigoSeleccionado;                        
                    }
                    break;
                case enmAyuda.enmAlmacen:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = Util.convertiracadena(frm.Result);
                        this.gridSaldos.CurrentRow.Cells["CodigoAlmacen"].Value = codigoSeleccionado;
                    }                    
                    break;
                case enmAyuda.enmMotivo:
                    frm = new frmBusqueda(tipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = Util.convertiracadena(frm.Result);
                        
                        if (codigoSeleccionado != "")
                        {
                            this.gridSaldos.CurrentRow.Cells["IN07MOTIVOCOD"].Value = codigoSeleccionado;   
                        }
                    }
                    break;
                case enmAyuda.enmTurnosxDetalle:
                    frm = new frmBusqueda(enmAyuda.enmTurnos);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                    {
                        this.gridSaldos.CurrentRow.Cells["in07prodTurnoCod"].Value = codigoSeleccionado;                        
                    }
                    break;
                
                default:
                    break;
            }
            
        }
        private void TraerDescripcionSaldos(enmAyuda tipo)
        {
            string codigo = "", descripcion = "";
            switch (tipo)
            { 
                case enmAyuda.enmOperador:                    
                    string codOperador = Util.convertiracadena(this.gridSaldos.CurrentRow.Cells["codigoOperador"].Value);
                    codigo = Logueo.CodigoEmpresa + "14" + codOperador;                    
                    GlobalLogic.Instance.DameDescripcion(codigo, "OPERARIO", out descripcion);
                    this.gridSaldos.CurrentRow.Cells["Operador"].Value = descripcion;
                    break;
                case enmAyuda.enmAlmacen:
                    string codAlmacen = Util.convertiracadena(this.gridSaldos.CurrentRow.Cells["CodigoAlmacen"].Value);
                    codigo = Logueo.CodigoEmpresa +  codAlmacen;
                    GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                    //this.gridSaldos.CurrentRow.Cells[""].Value = descripcion;
                    break;
                case enmAyuda.enmMotivo:
                    codigo = Util.convertiracadena(this.gridSaldos.CurrentRow.Cells["IN07MOTIVOCOD"].Value);
                    codigo =  Logueo.CodigoEmpresa + codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo, "MOTIVO", out descripcion);
                    this.gridSaldos.CurrentRow.Cells["DesMotivo"].Value = descripcion;
                    break;
                case enmAyuda.enmTurnosxDetalle:                    
                    codigo = Logueo.CodigoEmpresa + Util.convertiracadena(this.gridSaldos.CurrentRow.Cells["in07prodTurnoCod"].Value);
                    GlobalLogic.Instance.DameDescripcion(codigo, "TURNO", out descripcion);
                    this.gridSaldos.CurrentRow.Cells["in07prodTurnoDesc"].Value = descripcion;
                    break;
                default:
                    break;
            }
        }

        private void gridSaldos_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.Name == "codigoOperador")
            {
                TraerDescripcionSaldos(enmAyuda.enmOperador);
            }
            if (e.Column.Name == "CodigoAlmacen")
            {
                TraerDescripcionSaldos(enmAyuda.enmAlmacen);
            }
            if (e.Column.Name == "IN07MOTIVOCOD")
            {
                TraerDescripcionSaldos(enmAyuda.enmMotivo);
            }
            if (e.Column.Name == "in07prodTurnoCod")
            {
                TraerDescripcionSaldos(enmAyuda.enmTurnosxDetalle);
            }
        }

        private void gridSaldos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                if (this.gridSaldos.CurrentColumn.Name == "CodigoAlmacen")
                {
                    TraerAyudaSaldos(enmAyuda.enmAlmacen);
                }

                if (this.gridSaldos.CurrentColumn.Name  == "Operador")
                {
                    TraerAyudaSaldos(enmAyuda.enmOperador);
                }
                if (this.gridSaldos.CurrentColumn.Name == "DesMotivo")
                {
                    TraerAyudaSaldos(enmAyuda.enmMotivo);
                }
                if (this.gridSaldos.CurrentColumn.Name == "in07prodTurnoDesc")
                {
                    TraerAyudaSaldos(enmAyuda.enmTurnosxDetalle);
                }
            }
            
            if (e.Control && e.KeyCode == Keys.C)
            {
                    CopyCellSaldos();

            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                    PasteCellSaldos();
            }
        }
        private void gridSaldos_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name != "NroCaja" && e.Column.Name != "IN07HORAINICIO" && e.Column.Name != "IN07HORAFINAL" &&
                e.Column.Name != "IN07NROCAJAINGRESO" && e.Column.Name != "NroCaja"  &&
                e.Column.Name != "CodigoAlmacen" && e.Column.Name != "IN07HORASALIDA")
            {
                e.Cancel = true;
            }
            
        }
        void gridSaldos_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            string columname = this.gridSaldos.CurrentColumn.Name;

            Util.SetCellInitEdit(gridSaldos, columname);
        }
        void gridSaldos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        string datos = "";
        private void CopyCellSaldos()
        {
            GridViewRowInfo row = this.gridSaldos.CurrentRow;
            if (this.gridSaldos.CurrentColumn.Name == "Operador")
            {

                 datos = Util.convertiracadena(row.Cells["codigoOperador"].Value) + "|" +
                         Util.convertiracadena(row.Cells["Operador"].Value);
            }
            else if (this.gridSaldos.CurrentColumn.Name == "in07prodTurnoDesc")
            {
                datos = Util.convertiracadena(row.Cells["in07prodTurnoCod"].Value);
                
            }
            else if (this.gridSaldos.CurrentColumn.Name == "DesMotivo")
            {
                datos = Util.convertiracadena(row.Cells["IN07MOTIVOCOD"].Value);

            }
            else if (this.gridSaldos.CurrentColumn.Name == "in07prodTurnoDesc")
            {
                datos = Util.convertiracadena(row.Cells["in07prodTurnoCod"].Value);
            }
            else
            {
                valores = null;
                valores = new object[1];
                valores[0] = this.gridSaldos.CurrentCell.Value;
            }

        }
        private void PasteCellSaldos()
        {
            //string datos = "";
            if (this.gridSaldos.CurrentColumn.Name == "Operador")
            {
                /*datos = Util.convertiracadena(this.gridSaldos.CurrentRow.Cells["codigoOperador"].Value) + "|" +
                        Util.convertiracadena(this.gridSaldos.CurrentRow.Cells["Operador"].Value);*/
                 string[] cadena =  datos.Split('|');
                 this.gridSaldos.CurrentRow.Cells["codigoOperador"].Value = cadena[0];
                 this.gridSaldos.CurrentRow.Cells["Operador"].Value = cadena[1];
            }
            else if (this.gridSaldos.CurrentColumn.Name == "DesMotivo")
            {
                this.gridSaldos.CurrentRow.Cells["IN07MOTIVOCOD"].Value = datos;

            }
            else if (this.gridSaldos.CurrentColumn.Name == "in07prodTurnoDesc")
            {
                this.gridSaldos.CurrentRow.Cells["in07prodTurnoCod"].Value = datos; 
            }else{
                if (valores != null)
                    if (this.gridSaldos.SelectedCells.Count > 0)
                        for (int i = 0; i < this.gridSaldos.SelectedCells.Count; i++)
                            this.gridSaldos.SelectedCells[i].Value = valores[0];
                    else
                        this.gridSaldos.CurrentCell.Value = valores[0];
            }
        
        }
        

        #endregion                               
        // =================================================================== MP RESUMIDO ================================================================================
        #region "MP Resumido"
        private void mostrarAyudaMPResumido(enmAyuda tipo)
        {
            string codigoAlmacen = "";
            frmBusqueda frm;
            string codigoSeleccionado = "";
            string FlagDeValidacion = "1";
            string FlagDeretorno = "0";
            
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                switch (tipo)
                {
                    case enmAyuda.enmCanastMultiPPResumido:
                        codigoAlmacen = gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value.ToString();
                        if (codigoAlmacen == "") return;
                        frm = new frmBusqueda(enmAyuda.enmCanastMultiPPResumido, codigoAlmacen, null, 1000, 474);
                        frm.Owner = this;
                        frm.ShowDialog();
                        if (Util.convertiracadena(frm.Result) != "")
                        {
                            //obtener los datos de la opciones seleccionados
                            List<Spu_Pro_Trae_MPResumida> lista = (List<Spu_Pro_Trae_MPResumida>)(frm.Result);
                            
                            // si tiene Materia prima entonces
                            if (lista.Count > 0)
                            {
                                
                                string[] seleccionados = new string[lista.Count];
                                // Procesar la informacion para convertir en xml
                                int x = 0;
                                foreach (var itm in lista)
                                {
                                    
                                    seleccionados[x] = itm.Empresa + "|" +
                                                         itm.Anio + "|" +
                                                         itm.Mes + "|" +
                                                         itm.CodTipDoc + "|" +
                                                         itm.DocumentoCodigo + "|" +
                                                         itm.NroOrdenTrabajo + "|" +
                                                         itm.AlmacenCodigo + "|" +
                                                         itm.ProductoCodigo + "|" +
                                                         itm.nrocaja + "|" +
                                                         itm.HoraSalida;
                                    x++;
                                }
                                string mensajederetorno = "";
                                int flagderetorno = 0;
                                string ordenTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                                DocumentoLogic.Instance.InsertarSalidasPPResumido(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                    string.Format("{0:yyyyMMdd}", dtpFechaOT.Value), ordenTrabajo, Logueo.OrigentTipo_Automatico,
                                    Util.ConvertiraXMLdinamico(seleccionados), out flagderetorno, out mensajederetorno);
                                bool processOk = Util.ShowMessage(mensajederetorno, flagderetorno);
                                CargarMPResumido();
                            }
                        }

                        break;

                    case enmAyuda.enmAlmacen:
                        if (esEntrada == true)
                        {
                            frm = new frmBusqueda(enmAyuda.enmAlmacen);
                        }
                        else
                        {
                            var actividad = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim());
                            frm = new frmBusqueda(enmAyuda.enmAlmacenxNaturaleza, actividad.NATURALEZAALM);
                        }
                        frm.Owner = this;
                        frm.ShowDialog();
                        if (frm.Result != null)
                        {
                            this.gridMateriaPrima.CurrentRow.Cells["IN07CODALM"].Value = frm.Result.ToString();
                        }
                        break;

                    default:
                        break;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowAlert(ex.Message);
            }
            
        }
        private void CrearColumnasMPResumido()
        {
            RadGridView GridResumenMP = this.CreateGridVista(this.gridMateriaPrima);

            this.CreateGridColumn(GridResumenMP, "IN07CODEMP", "IN07CODEMP", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridResumenMP, "IN07DocIngAA", "IN07DocIngAA", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridResumenMP, "IN07DocIngMM", "IN07DocIngMM", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridResumenMP, "IN07DocIngTIPDOC", "IN07DocIngTIPDOC", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridResumenMP, "IN07DocIngCODDOC", "IN07DocIngCODDOC", 0, "", 70, true, false, false);
                        
            this.CreateGridColumn(GridResumenMP, "OT", "IN07ORDENTRABAJO", 0, "", 50, true, false, false);
            this.CreateGridColumn(GridResumenMP, "Hora Salida", "IN07HORASALIDA", 0, "", 90, true, false, false);
            // Almacen
            this.CreateGridColumn(GridResumenMP, "CodigoAlm", "IN07CODALM", 0, "", 50);
            this.CreateGridColumn(GridResumenMP, "Almacen", "in09descripcion", 0, "", 120);

            this.CreateGridColumn(GridResumenMP, "Canastilla/Bloque", "IN07NROCAJA", 0, "", 75);
            this.CreateGridColumn(GridResumenMP, "% Liquidacion", "RedimientoRatio", 0, "", 75);
            //
            this.CreateGridColumn(GridResumenMP, "CajaUnica", "CajaUnica", 0, "", 90, true, false, false); // Oculto
            //Articulo
            this.CreateGridColumn(GridResumenMP, "CodigoArticulo", "IN07DocIngKEY", 0, "", 50);
            this.CreateGridColumn(GridResumenMP, "Articulo", "IN01DESLAR", 0, "", 85);

                        
            this.CreateGridColumn(GridResumenMP, "IN07KEY", "IN07KEY", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridResumenMP, "Unidad", "IN01UNIMED", 0, "", 70, true, false, false);
            this.CreateGridColumn(GridResumenMP, "Largo", "IN07LARGO", 0, "{0:###,##0.00}", 60, true, false, true, true, "right");
            this.CreateGridColumn(GridResumenMP, "Ancho", "IN07ANCHO", 0, "{0:###,##0.00}", 60, true, false, true, true, "right");
            this.CreateGridColumn(GridResumenMP, "Alto", "IN07ALTO", 0, "{0:###,##0.00}", 60, true, false, true, true, "right");

            this.CreateGridColumn(GridResumenMP, "Cant.", "Cantidad", 0, "{0:###,##0.00}", 60, true, false, true, true, "right");

            this.CreateGridColumn(GridResumenMP, "Area", "Area", 0, "{0:###,##0.00}", 70, true, false, true, true, "right");
            this.CreateGridColumn(GridResumenMP, "Volumen", "Volumen", 0, "{0:###,##0.00}", 70, true, false, true, true, "right");
            this.gridMateriaPrima.MultiSelect = false;
            agregarBotonMateriaPrima();

            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "Area";
            summaryItem.FormatString = "{0:###,##0.00}";

            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryItem summaryItem2 = new GridViewSummaryItem();
            summaryItem2.Name = "Volumen";
            summaryItem2.FormatString = "{0:###,##0.00}";
            summaryItem2.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem rowItem = new GridViewSummaryRowItem() { summaryItem, summaryItem2 };

            gridMateriaPrima.SummaryRowsBottom.Add(rowItem);
            gridMateriaPrima.MasterTemplate.ShowTotals = true;
            gridMateriaPrima.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

           

        }
        private void CargarMPResumido()
        {             
            string nroordentrabajo = Util.GetCurrentCellText(gridOrdenTrabajo, "codigo");

            List<Spu_Pro_Trae_SalidaMPResumida> lista = DocumentoLogic.Instance.TraerSalidaMPResumida(Logueo.CodigoEmpresa, 
                                                                                 Logueo.Anio, Logueo.Mes, nroordentrabajo);
            this.gridMateriaPrima.DataSource = lista;
        }
        #endregion

        private void btnVerBloqueMerma_Click(object sender, EventArgs e)
        {
            string nroCaja = Util.GetCurrentCellText(gridMateriaPrima, "IN07NROCAJA");
            
            DataTable dt = new DataTable();
            dt = DocumentoLogic.Instance.Spu_Pro_Rep_BloqueMerma(Logueo.CodigoEmpresa, "", "", "B", nroCaja);
            if (dt == null) 
            {
                Util.ShowAlert("No tiene datos para ver el reporte");
                return;
            }

            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptRendiMermaxBloque.rpt";
            reporte.DataSource = dt;
            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

        }

        public void OnEnfocarRegistro(bool esNuevo, RadGridView gv, string codigoRegistro, string nomcol)
        {
            if (gv.IsLoaded)
            {

                foreach (GridViewRowInfo row in gv.Rows)
                {
                    if (row.Cells[nomcol].Value.ToString() == codigoRegistro)
                    {
                        gv.Rows[row.Index].IsCurrent = true;
                        gv.Rows[row.Index].IsSelected = true;
                    }

                }

            }
        }
             
    }
}
