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
using Telerik.Windows.Controls;
using System.Globalization;
using System.Linq;
using System.Data.Linq;
using Telerik.WinControls.UI.Docking;
namespace Inv.UI.Win.Procesos
{
    public partial class frmMoviMP : frmBaseReg
    {
        private bool isLoaded = false;
        private bool isOpened = false;
        private string tipoDocumento = string.Empty;
        private string nroDocumento = string.Empty;
        private bool esEntrada = false;
        public string _eCodigo { get; set; }
        
        //variable orgniza los grupos de las cabeceras de la grilla
        ColumnGroupsViewDefinition columnGroupsView;
        private string _codigoAlmacenSeleccionado = string.Empty;
        private string _PedidoVentaSeleccionado = string.Empty;
        //private frmMDI FrmParent { get; set; }

        public RadGridView _grid;
        public int pos = 0;

        private frmDocuMP FrmParent { get; set; }
        public int ultimafila { get; set; }
        
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbGuardar;

        private static frmMoviMP _aForm;
        
        OrdenTrabajo orden = new OrdenTrabajo();

        public static frmMoviMP Instance(frmDocuMP mdiPrincipal)
        {
            if (_aForm != null) return new frmMoviMP(mdiPrincipal);
            _aForm = new frmMoviMP(mdiPrincipal);
            return _aForm;
        }
        public frmMoviMP(frmDocuMP padre)
        {
            InitializeComponent();
            FrmParent = padre;
            
            Control ctrl = FrmParent.ParentForm.Controls.Find("radDock1", true)[0];

            Estado = FrmParent.Estado;

            if (Estado == FormEstate.New)
            {
                pos = 0;
            }
            else if (Estado == FormEstate.List || Estado == FormEstate.View || Estado == FormEstate.Edit)
            {
                nroDocumento = FrmParent.gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
                tipoDocumento = FrmParent.gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
                pos = FrmParent.gridControl.CurrentRow.Index;
            }

            esEntrada = FrmParent.rbEntradas.IsChecked;

            CrearColumnas();
            crearColumnasOrdenTrabajo();
            crearColumnasMateriaPrima();
            crearGrupos();
            CargarCombos();
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbGuardar = menu.Items["cbbGuardar"];
            retirarBordePaneles();
            
            this.MdiParent = FrmParent.ParentForm;
            ((RadDock)(ctrl)).ActivateMdiChild(this);
            
        }

        void agregarBoton()
        {

            GridViewCommandColumn colGrabar = new GridViewCommandColumn();
            colGrabar.Name = "btnGrabar";
            colGrabar.HeaderText = "";
            gridControl.Columns.Add(colGrabar);
            gridControl.Columns["btnGrabar"].BestFit();

            GridViewCommandColumn colCancelar = new GridViewCommandColumn();
            colCancelar.Name = "btnCancelar";
            colCancelar.HeaderText = "";
            gridControl.Columns.Add(colCancelar);
            gridControl.Columns["btnCancelar"].BestFit();

            GridViewCommandColumn colEliminar = new GridViewCommandColumn();
            colEliminar.Name = "btnEliminar";
            colEliminar.HeaderText = "";
            gridControl.Columns.Add(colEliminar);
            gridControl.Columns["btnEliminar"].BestFit();

            GridViewCommandColumn colEditar = new GridViewCommandColumn();
            colEditar.Name = "btnEditar";
            colEditar.HeaderText = "";
            gridControl.Columns.Add(colEditar);
            gridControl.Columns["btnEditar"].BestFit();

            //this.gridControl.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }
        void retirarBordePaneles() {
            this.rpDocRespaldo.PanelElement.PanelBorder.TopWidth = 0;
            this.rpMenuDetalle.PanelElement.PanelBorder.TopWidth = 0;
            this.rpProduccionGrilla.PanelElement.PanelBorder.TopWidth = 0;
            this.rpTipoDoccumento.PanelElement.PanelBorder.TopWidth = 0;
            this.rpTransaccionAdiccional.PanelElement.PanelBorder.TopWidth = 0;
            this.rpDocRespaldo.PanelElement.PanelBorder.Visibility = ElementVisibility.Hidden;
            this.rpTransaccionAdiccional.PanelElement.PanelBorder.Visibility = ElementVisibility.Hidden;
        }
        void enfocarregistro()
        {
            FrmParent.gridControl.MasterView.Rows[pos].IsCurrent = true;
            FrmParent.gridControl.MasterView.Rows[pos].IsSelected = true;                        
        }
        void asignarValores()
        {
            //asigno los valores de la fila actual seleccionado

            nroDocumento = FrmParent.gridControl.MasterView.Rows[pos].Cells["CodigoDoc"].Value.ToString();
            tipoDocumento = FrmParent.gridControl.MasterView.Rows[pos].Cells["TipoDoc"].Value.ToString();
            txtNroDocumento.Text = FrmParent.gridControl.MasterView.Rows[pos].Cells["CodigoDoc"].Value.ToString();
            //cargo el resto de datos del dcoumneto por medio del codigo del documento.
            CargarDocumento();
            CargarMovimiento();
            _eCodigo = nroDocumento;

            Habilitar(false);
            //resalto el registro actual
            enfocarregistro();
        }

        protected override void OnPrimero()
        {
            pos = 0;
            asignarValores();
        }
        protected override void OnSiguiente()
        {
            if (pos == FrmParent.gridControl.MasterView.Rows.Count - 1 || pos == FrmParent.gridControl.MasterView.ChildRows.Count - 1)
                return;
            pos++;
            asignarValores();
        }
        protected override void OnAnterior()
        {
            //int filasFiltradas = _grid.ChildRows.Count;
            //int filasSinFiltrar = _grid.Rows.Count;
            if (pos == 0)
                return;
            pos--;
            asignarValores();
        }
        protected override void OnUltimo()
        {

            pos = FrmParent.gridControl.MasterView.Rows.Count - 1;
            asignarValores();

        }
        #region "Orden de trabajo"
        void crearColumnasOrdenTrabajo()
        {
            RadGridView grid = CreateGridVista(gridOrdenTrabajo);
            CreateGridColumn(grid, "codigoEmpresa", "codigoEmpresa", 0, "", 50, true, false, false);
            CreateGridColumn(grid, "Codigo", "codigo", 0, "", 40); // codigo de orden de trabajo
            CreateGridColumn(grid, "Cod.Prod", "codigoProducto", 0, "", 90, true, false, false); // codigo de producto
            CreateGridColumn(grid, "Descripcion", "productoObjetivo", 0, "", 120); // descripcion de producto
            CreateGridColumn(grid, "OP", "OrigenMP", 0, "", 70, false, true, true);
            CreateGridColumn(grid, "flag", "flag", 0, "", 30, false, true, false); // flag para validar el mantenimiento de orden de trabajo
            CreateGridColumn(grid, "PRO13DOCINGALMAA", "PRO13DOCINGALMAA", 0, "", 30, true, false, false);
            CreateGridColumn(grid, "PRO13DOCINGALMMM", "PRO13DOCINGALMMM", 0, "", 30, true, false, false);
            CreateGridColumn(grid, "PRO13DOCINGALMTIPDOC", "PRO13DOCINGALMTIPDOC", 0, "", 60, true, false, false);

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

            
        }
        void entidadOrdenTrabajo()
        {
            orden.codigoEmpresa = Logueo.CodigoEmpresa;
            orden.codigo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
            orden.codigoProducto = this.gridOrdenTrabajo.CurrentRow.Cells["codigoProducto"].Value.ToString();
            orden.DocuIngresoAlmacenAnio = Logueo.Anio;
            orden.DocuIngresoAlmacenMes = Logueo.Mes;
            orden.DocuIngresoAlmacenTipDoc = txtCodigoTipDoc.Text.Trim();

            orden.DocuIngresoAlmacenCodDoc = txtNroDocumento.Text.Trim();                        //numero de produccion
            orden.OrigenMP = this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].Value == null ? "" : this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].Value.ToString();

            orden.PRO13LINEACOD = txtCodLinea.Text.Trim();
            orden.PRO13ACTIVIDADNIVELCOD = txtCodProceso.Text.Trim();
            orden.PRO13AA = Logueo.Anio;
            orden.PRO13MM = Logueo.Mes;
            //orden.OrigenMP = this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].Value.ToString(); //--Orden de produccion
        }
        void CargarOrdenTrabajo()
        {
            var lista = OrdenTrabajoLogic.Instance.TraerOrdenTrabajo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                      txtNroDocumento.Text.Trim(), txtCodigoTipDoc.Text.Trim());
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
            string codigoOrdenTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
            string nroDoc = txtNroDocumento.Text.Trim();
            string codTipDoc = txtCodigoTipDoc.Text.Trim();
            var registro = DocumentoLogic.Instance.TraerMateriaPrimaxOT(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codTipDoc,
                                                                         nroDoc, codigoOrdenTrabajo);

            if (registro.Count > 0)
            {
                RadMessageBox.Show("Esta orden de trabajo tiene materia prima consumida.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            var prodFabricadas = DocumentoLogic.Instance.TraerProduccionDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codTipDoc, nroDoc, codigoOrdenTrabajo);
            //var prodFabricadas = DocumentoLogic.Instance.TraerTodosDetalleProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
            //                                                                          codTipDoc, nroDoc);
            if (prodFabricadas.Count > 0)
            {
                RadMessageBox.Show("Esta orden de trabajo tiene productos fabricados.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            DialogResult res = RadMessageBox.Show("¿Desea eliminar el OT?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
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
                if (fila.Cells["flag"].Value.ToString() == "0")
                {
                    OrdenTrabajoLogic.Instance.InsertarOrdenTrabajo(orden, out flag, out mensaje);
                }
                else if (fila.Cells["flag"].Value.ToString() == "1")
                {
                    OrdenTrabajoLogic.Instance.ActualizarOrdenTrabajo(orden, out flag, out mensaje);
                }

                this.gridOrdenTrabajo.CurrentRow.Cells["flag"].Value = 0;
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                CargarOrdenTrabajo();
                Util.enfocarFila(gridOrdenTrabajo, "codigo", orden.codigo); // enfocamos al ultimo registro insertado o actualizado.

                string codigoOT = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString(); // obtnemos codigo de orden de trabajo seleccionado.
                var ordenTrabajo = OrdenTrabajoLogic.Instance.TraerRegistroOT(Logueo.CodigoEmpresa, codigoOT); // validamos si existe al orden de trabajo seleccionado
                if (ordenTrabajo != null)// si tenemos registros de orden trabajo
                {
                    btnAddMateria.Visible = true;//activa boton de agregar materia
                }
                else
                {
                    btnAddMateria.Visible = false; //desactiva boton de agregar materia
                }
                //Util.enfocarFila(gridOrdenTrabajo, "codigo", orden.codigo);

            }
            catch (Exception)
            {

            }

        }
        void EditarOrdenTrabajo()
        {
            this.gridOrdenTrabajo.CurrentRow.Cells["flag"].Value = "1";
            this.gridOrdenTrabajo.Focus();
            this.gridOrdenTrabajo.CurrentRow.Cells["OrigenMP"].BeginEdit();

            //Resaltar ayuda
            Util.ResaltarAyuda(this.gridOrdenTrabajo.CurrentRow.Cells["productoObjetivo"]);
            
        }
        #endregion
        #region "Materia prima"
        void crearColumnasMateriaPrima()
        {
            RadGridView gridMP = this.CreateGridVista(this.gridMateriaPrima);
            //OT	ALMACEN	Canastilla MP / Bloque	Producto	Cantidad
            this.CreateGridColumn(gridMP, "Anio", "Anio", 0, "", 90, true, false, false);
            this.CreateGridColumn(gridMP, "Mes", "Mes", 0, "", 90, true, false, false);
            this.CreateGridColumn(gridMP, "Tip Doc", "CodigoTipoDocumento", 0, "", 90, true, false, false);
            this.CreateGridColumn(gridMP, "Cod Doc", "CodigoDocumento", 0, "", 90, true, false, false);

            this.CreateGridColumn(gridMP, "OT", "IN07ORDENTRABAJO", 0, "", 50, true, false, false);
            this.CreateGridColumn(gridMP, "CodigoAlm.", "CodigoAlmacen", 0, "", 50, true, false, false);
            this.CreateGridColumn(gridMP, "Almacen", "AlmacenDesc", 0, "", 75);

            this.CreateGridColumn(gridMP, "Canastilla / Bloque", "NroCaja", 0, "", 75);
            this.CreateGridColumn(gridMP, "CodigoArticulo", "CodigoArticulo", 0, "", 50, true, false, false);
            this.CreateGridColumn(gridMP, "Producto", "ProductoDesc", 0, "", 85);

            
            this.CreateGridColumn(gridMP, "Largo", "Largo", 0, "{0:###,##0.00}", 70, true, false, true, true, "right");
            this.CreateGridColumn(gridMP, "Ancho", "Ancho", 0, "{0:###,##0.00}", 70, true, false, true, true, "right");
            this.CreateGridColumn(gridMP, "Alto", "Alto", 0, "{0:###,##0.00}", 70, true, false, true, true, "right");

            this.CreateGridColumn(gridMP, "Cantidad", "Cantidad", 0, "", 80, true, false, true, false, "right");
            this.CreateGridColumn(gridMP, "Orden", "Orden", 0, "", 50, true, false, false);
            this.gridMateriaPrima.MultiSelect = false;
            agregarBotonMateriaPrima();
        }
        void agregarBotonMateriaPrima()
        {
            GridViewCommandColumn colEliminar = new GridViewCommandColumn();
            colEliminar.Name = "btnEliminarMat";
            colEliminar.HeaderText = "";
            gridMateriaPrima.Columns.Add(colEliminar);
            gridMateriaPrima.Columns["btnEliminarMat"].BestFit();
            gridMateriaPrima.Columns["btnEliminarMat"].MinWidth = 35;
        }

        void cargarMateriaPrima()
        {
            try
            {
                string ordTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                //string ordTrabajo = txtNroDocRespaldo.Text.Trim();
                var lista = DocumentoLogic.Instance.TraerMateriaPrimaxOT(Logueo.CodigoEmpresa, Logueo.Anio,
                                                                        Logueo.Mes, txtCodigoTipDoc.Text.Trim(),
                                                                        txtNroDocumento.Text.Trim(), ordTrabajo);
                this.gridMateriaPrima.DataSource = lista;
            }
            catch (Exception ex)
            {

            }

        }
        void EliminarMateriaPrima()
        {
            if (gridControl.Rows.Count > 0)
            {
                RadMessageBox.Show("Para eliminar la materia prima primero elimine los detalles de Produccion.", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            //OrdenTrabajoLogic.Instance.TraerOrdenTrabajo
            DialogResult res = MessageBox.Show("¿Desea eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (this.gridMateriaPrima.CurrentRow.Cells["CodigoArticulo"].Value == null)
            {
                this.gridMateriaPrima.Rows.RemoveAt(this.gridMateriaPrima.CurrentRow.Index);
                return;
            }
            if (res == System.Windows.Forms.DialogResult.Yes)
            {

                string codigoArti = this.gridMateriaPrima.CurrentRow.Cells["CodigoArticulo"].Value.ToString();

                double ordenArti = double.Parse(this.gridMateriaPrima.CurrentRow.Cells["Orden"].Value.ToString());
                string ordenTrabajo = this.gridMateriaPrima.CurrentRow.Cells["IN07ORDENTRABAJO"].Value.ToString();
                string canasta = this.gridMateriaPrima.CurrentRow.Cells["NroCaja"].Value.ToString();

                // Capturo los datos del docuemnto de salida
                string DocAnio = this.gridMateriaPrima.CurrentRow.Cells["Anio"].Value.ToString();
                string DocMes = this.gridMateriaPrima.CurrentRow.Cells["Mes"].Value.ToString();
                string DocTipDoc = this.gridMateriaPrima.CurrentRow.Cells["CodigoTipoDocumento"].Value.ToString();
                string DocNumero = this.gridMateriaPrima.CurrentRow.Cells["CodigoDocumento"].Value.ToString();


                string msj = string.Empty;

                DocumentoLogic.Instance.EliminarMateriaPrima(Logueo.CodigoEmpresa, DocAnio, DocMes, DocTipDoc, DocNumero,
                                                                canasta, ordenTrabajo, out msj);
                RadMessageBox.Show(msj, "..::Mensaje::..", MessageBoxButtons.OK, RadMessageIcon.Info);

            }
            cargarMateriaPrima();

        }
        #endregion
        private void BloquearControlesOcultos() 
        {           
        txtCodCliente.Enabled = false; 
        txtCodCliente.Visible = false;
        txtCodCliente.TabStop = false;

        txtDesCliente.Enabled = false; 
        txtDesCliente.TabStop = false;
        txtDesCliente.Visible = false;

        txtLote.Enabled = false; 
        txtLote.TabStop = false; 
        txtLote.Visible = false;

        txtCodMaquina.Enabled = false;
        txtCodMaquina.TabStop = false;
        txtCodMaquina.Visible = false;
            
        txtDesMaquina.Enabled = false;
        txtDesMaquina.TabStop = false;
        txtDesMaquina.Visible = false;

        txtMes.Enabled = false;
        txtMes.TabStop = false;
        txtMes.Visible = false;

        txtAnho.Enabled = false;
        txtAnho.TabStop = false;
        txtAnho.Visible = false;

        txtTipoDocumento.Enabled = false;
        txtTipoDocumento.TabStop = false;
        txtTipoDocumento.Visible = false;

        radLabel15.Enabled = false;
        radLabel15.Visible = false;

        radLabel14.Enabled = false;
        radLabel14.Visible = false;

        CodNotaSalida.Visible = false;

        radLabel13.Enabled = false;            
        radLabel13.Visible = false;
        }
        private void BloquearIngresoDatos()
        {
            BloquearControlesOcultos();
            this.txtCodProveedor.Enabled = false;
            this.txtCodCliente.Enabled = false;
            this.txtCodCentroCosto.Enabled = false;
            this.txtCodResponsable.Enabled = false;
            this.txtCodRepReceptor.Enabled = false;
            this.txtCodObra.Enabled = false;
            this.txtCodMaquina.Enabled = false;
            this.txtLote.Enabled = false;
            this.txtNotaSalida.Enabled = false;
            this.txtCodContratista.Enabled = false;
            this.txtCodigoCantera.Enabled = false;

            //Controles de produccion
            this.txtCodLinea.Enabled = false;
            this.txtCodProceso.Enabled = false;
            this.txtCodTurno.Enabled = false;
            this.txtCodigoMaquina.Enabled = false;
            
            this.btnAddOT.Visible = false;
            this.gridOrdenTrabajo.Enabled = false;

            this.btnAddMateria.Visible = false;
            this.gridMateriaPrima.Enabled = false;

            this.btnAddDetalle.Visible = false;
            
            //this.txtPedido.Enabled = false;
        }
        private void InicializarNuevo()
        {
            BloquearIngresoDatos();
            this.dtpFechaDoc.Value = DateTime.Now;
            this.txtCodigoTipDoc.Focus();
            this.txtTipoAnalisis.Text = "";
            //txtDesTransa.Focus();
            //Tenemos el codigo de moneda por defecto

            //ocultamos los botones de agregar OT y Materia prima
            btnAddOT.Visible = false;
            btnAddMateria.Visible = false;

            //ocultamos el boton de agregar detalle 
            btnAddDetalle.Visible = false;
            

        }
        private void CargarDocumento()
        {
            BloquearIngresoDatos();
            //Carga el documento y su detalle

            var documento = DocumentoLogic.Instance.ObtenerDocumento(Logueo.CodigoEmpresa,
                Logueo.Anio, Logueo.Mes, this.tipoDocumento, this.nroDocumento);
            if (documento != null)
            {

                this.txtCodigoTipDoc.Text = documento.TipoDoc;
                this.txtNroDocumento.Text = documento.CodigoDoc;

                this.dtpFechaDoc.Value = (DateTime)documento.FechaDoc;

                this.txtCodTransa.Text = documento.CodigoTransa;
                this.txtNroReferencia.Text = documento.ReferenciaDoc;
                this.txtCodProveedor.Text = documento.CodigoProveedor;
                this.txtCodMoneda.Text = documento.Moneda;

                this.txtCodRepReceptor.Text = documento.ResponsableReceptor;
                this.txtCodResponsable.Text = documento.Responsable;

                this.txtNotaSalida.Text = documento.IN06NOTASALIDA;

                this.txtCodCentroCosto.Text = documento.CodigoCentroCosto;
                this.txtCodObra.Text = documento.CodigoObra;
                this.txtTipoAnalisis.Text = documento.IN06DOCRESCTACTETIPANA;
                this.txtCodProveedor.Text = documento.IN06DOCRESCTACTENUMERO;
                this.txtCodigoCantera.Text = documento.IN06CANTERACOD;
                this.txtCodContratista.Text = documento.IN06CONTRATISTACOD;
            }
        }
        public void Habilitar(bool flag)
        {
            this.txtCodigoTipDoc.Enabled = flag;
            this.txtNroDocumento.Enabled = flag;
            //this.dtpFechaDoc.Enabled = flag;
            this.txtCodMoneda.Enabled = flag;
            this.txtNroReferencia.Enabled = flag;
            this.txtCodProveedor.Enabled = flag;
            this.txtTipoDocumento.Enabled = flag;
            this.rpTransaccionAdiccional.Enabled = flag;
            this.txtCodContratista.Enabled = flag;
            this.txtCodigoCantera.Enabled = flag;
            

            //this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = true;
        }
      
        private void frmMoviMP_Load(object sender, EventArgs e) 
        {
            if (this.Estado == FormEstate.New)
            {
                InicializarNuevo();
                this.HabilitarBotones(true, true, false, false, false);

                this.gridControl.Columns["btnGrabar"].IsVisible = true;
                //this.gridControl.Columns["btnGrabar"].MinWidth = 40;

                this.gridControl.Columns["btnCancelar"].IsVisible = true;
                //this.gridControl.Columns["btnCancelar"].MinWidth = 40;

                this.gridControl.Columns["btnEliminar"].IsVisible = true;
                //this.gridControl.Columns["btnEliminar"].MinWidth = 40;

            }
            else if (this.Estado == FormEstate.Edit)
            {
                //this.HabilitarRadBar(ElementVisibility.Visible, ElementVisibility.Collapsed);
                isLoaded = true;
                CargarDocumento();
                
                Habilitar(false);
                this.rpTransaccionAdiccional.Enabled = true;
                this.txtCodTransa.Enabled = true;
                this.txtNroReferencia.Enabled = true;
                this.txtCodMoneda.Enabled = true;
                this.txtCodProveedor.Enabled = true;

                btnAddDetalle.Visible = true;
                
                ConfigurarDocumento(txtCodigoTipDoc.Text.Trim());
                txtCodTransa.Focus();
                
                this.HabilitarBotones(true, true, false, false,false);                


                this.gridControl.Columns["btnGrabar"].IsVisible = true;
                this.gridControl.Columns["btnCancelar"].IsVisible = true;
                this.gridControl.Columns["btnEliminar"].IsVisible = true;
                //ConfigurarDocumento(this.txtCodigoTipDoc.Text); //Configura el documento
                this.CargarMovimiento();

            }
            else if (this.Estado == FormEstate.View)
            {

                //this.ActivarBotones(false, false, false, false);
                isLoaded = true;
                CargarDocumento();
                //ConfigurarDocumento(this.txtCodigoTipDoc.Text); //Configura el documento
                //habilita los controles del formulario
                Habilitar(false);

                //panel de documentos adicionales
                rpTransaccionAdiccional.Enabled = false;
                
                //documentos para cabecera
                this.txtCodTransa.Enabled = false;
                this.txtCodProveedor.Enabled = false;
                //Confighura los botones para el mantenimineto del formulario 
                this.HabilitarBotones(false, true, false, false, true);

                //boton para agregar materia prima
                btnAddOT.Visible = false;
                //boton para agregar orden de trabajo
                btnAddMateria.Visible = false;
                //botn agrega detalle de documento 
                btnAddDetalle.Visible = false;
                
                //inhabilitando los botones de mantenimiento
                //this.gridControl.Columns["btnGrabar"].ReadOnly = true;
                //this.gridControl.Columns["btnCancelar"].ReadOnly = true;
                //this.gridControl.Columns["btnEliminar"].ReadOnly = true;
                //this.gridControl.Columns["btnEditar"].ReadOnly = true;
                this.CargarMovimiento();
            }
            
            isLoaded = true;
        }
        private void CrearColumnas()
        {            
            var lista = AlmacenLogic.Instance.ObtenerListItems1(Logueo.CodigoEmpresa);

            RadGridView grilla = this.CreateGridVista(this.gridControl);

            grilla.AutoGenerateColumns = false;            
            this.CreateGridColumn(grilla, "Cod.Alm", "CodigoAlmacen", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Almacen", "DesAlmacen", 0, "", 90);
            this.CreateGridColumn(grilla, "CodigoProducto", "CodigoArticulo", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilla, "DescripcionArticulo", "DescripcionArticulo", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "UM", "UnidadMedida", 0, "", 40, true, false, true);
            this.CreateGridColumn(grilla, "Codigo", "NroCaja", 0, "", 80, !true, !false, true);
            
            this.CreateGridColumn(grilla, "Largo", "Largo", 0, "{0:###,##0.00}", 60, !true, !false, true, true, "right");
            this.CreateGridColumn(grilla, "Ancho", "Ancho", 0, "{0:###,##0.00}", 60, !true, !false, true, true, "right");
            this.CreateGridColumn(grilla, "Alto", "Alto", 0, "{0:###,##0.00}", 60, !true, !false, true, true, "right");

            this.CreateGridColumn(grilla, "Volumen", "Cantidad", 0, "{0:###,##0.00}", 60, true, false, true, true, "right");
            this.CreateGridColumn(grilla, "Codigo", "CodBloqProv", 0, "", 90, !true, !false, true);
            
            this.CreateGridColumn(grilla, "Largo", "LargoCan", 0, "{0:###,##0.00}", 60, !true, !false, true, true,  "right");
            this.CreateGridColumn(grilla, "Ancho", "AnchoCan", 0, "{0:###,##0.00}", 60, !true, !false, true, true, "right");
            this.CreateGridColumn(grilla, "Alto", "AltoCan", 0, "{0:###,##0.00}", 60, !true, !false, true, true, "right");
            
            this.CreateGridColumn(grilla, "Volumen", "VolumenCan", 0, "{0:###,##0.00}", 60, true, false, true, true, "right");
            this.CreateGridColumn(grilla, "Dif.Volumen", "DifVol", 0, "{0:###,##0.00}", 70, true, false, true, true, "right");
            this.CreateGridColumn(grilla, "Orden", "Orden", 0, "", 10, true, false, false);
            this.CreateGridColumn(grilla, "flag", "flag", 0, "", 30, false, true, false);
            this.CreateGridColumn(grilla, "Observaciones", "in07observacion", 0, "", 90,false, true, true);
            this.CreateGridColumn(grilla, "AreaxUni", "Areaxuni", 0, "{0:###,##0.00}", 50, true, false, false);
            //this.CreateGridColumn(grilla, "Area", "Area", 0, "{0:###,##0.00}", 50, true, false, false);
            //  Agrega filas ocultas para capturar los ingresos de las salidas
            this.CreateGridColumn(grilla, "IN07DocIngAA", "IN07DocIngAA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngMM", "IN07DocIngMM", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngTIPDOC", "IN07DocIngTIPDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngCODDOC", "IN07DocIngCODDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngKEY", "IN07DocIngKEY", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngORDEN", "IN07DocIngORDEN", 0, "", 0, true, false, false, true);
            this.CreateGridColumn(grilla, "Cod.Motivo", "IN07MOTIVOCOD", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Des.Motivo", "DesMotivo", 0, "", 90, true, false, true);
            GridViewSummaryItem SumVolIng = new GridViewSummaryItem();
            SumVolIng.Name = "Cantidad";
            SumVolIng.FormatString = "{0:###,###0.00}";
            SumVolIng.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryItem SumVolIng2 = new GridViewSummaryItem();
            SumVolIng2.Name = "VolumenCan";
            SumVolIng2.FormatString = "{0:###,###0.00}";
            SumVolIng2.Aggregate = GridAggregateFunction.Sum;

            //GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            //summaryItem.Name = "DifVol";
            //summaryItem.FormatString = "{0:###,###0.00}";
            //summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summarytRowItem = new GridViewSummaryRowItem() { SumVolIng, SumVolIng2 };
            grilla.SummaryRowsBottom.Add(summarytRowItem);
            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

            //crearGrupos();
            
        }                

        void radGridView1_CommandCellClick(object sender, EventArgs e)
        {

        }
        void crearGrupos()
        {
            agregarBoton();
            
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CodigoAlmacen"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DesAlmacen"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["CodigoArticulo"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["DescripcionArticulo"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["UnidadMedida"]);

            
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Dimensiones planta"));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["NroCaja"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Largo"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Ancho"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Alto"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Cantidad"]);



            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Dimensiones cantera"));
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["CodBloqProv"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["LargoCan"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["AnchoCan"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["AltoCan"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["VolumenCan"]);

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
            this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControl.Columns["DifVol"]);
            //this.gridControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            //this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
            this.columnGroupsView.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(this.gridControl.Columns["flag"]);
            this.columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(this.gridControl.Columns["in07observacion"]);
            this.columnGroupsView.ColumnGroups[4].Rows[0].Columns.Add(this.gridControl.Columns["DesMotivo"]);
            
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
            this.columnGroupsView.ColumnGroups[5].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns.Add(this.gridControl.Columns["btnGrabar"]);
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns[0].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns.Add(this.gridControl.Columns["btnCancelar"]);
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns[1].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns.Add(this.gridControl.Columns["btnEliminar"]);
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns[2].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns.Add(this.gridControl.Columns["btnEditar"]);
            this.columnGroupsView.ColumnGroups[5].Rows[0].Columns[3].MinWidth = 30;



            //this.CreateGridColumn(grilla, "Observaciones", "in07observacion", 0, "", 100, false, true, true);

            this.gridControl.ViewDefinition = columnGroupsView;
        }
        private void CargarCombos()
        {
            try
            {
                var tipoDoc = TipoDocumentoLogic.Instance.ObtenerListItems(Logueo.CodigoEmpresa);
               // tipoDoc.Insert(0, new ItemsList(enmDroDownItems.Seleccione.ToString(), Constantes.DropDownItems.Seleccione));
                //this.Extensions.Bind(this.cboTipoDocumento, tipoDoc);
                var trans = TipoTransaccionLogic.Instance.ObtenerListItems(Logueo.CodigoEmpresa);
                //trans.Insert(0, new ItemsList(enmDroDownItems.Seleccione.ToString(), Constantes.DropDownItems.Seleccione));
                //this.Extensions.Bind(this.cboTransaccion, trans);
                //this.Extensions.Bind(this.cboTransa, trans);

                //this.Extensions.Bind(this.cboMoneda, MonedaLogic.Instance.ObtenerListItems());

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ConfigurarDocumento(string tipoDocumento)
        {
            string variable = TipoDocumentoLogic.Instance.DameVariable(Logueo.CodigoEmpresa, tipoDocumento);
            //Configura el documento

            if (string.IsNullOrEmpty(variable)) return;
            if (variable.Trim().Length < 12) return;

            this.txtCodProveedor.Enabled = (variable.Substring(0, 1).CompareTo("1") == 0);//chk1
            this.txtCodCliente.Enabled = (variable.Substring(5, 1).CompareTo("1") == 0);//chk6
            this.txtCodCentroCosto.Enabled = (variable.Substring(1, 1).CompareTo("1") == 0);//chk2
            this.txtCodResponsable.Enabled = (variable.Substring(3, 1).CompareTo("1") == 0);//chk4
            this.txtCodRepReceptor.Enabled = (variable.Substring(4, 1).CompareTo("1") == 0); //chk5
            this.txtCodObra.Enabled = (variable.Substring(2, 1).CompareTo("1") == 0); //chk3 -- Responsable obra(responsable almacen)

            this.txtCodMaquina.Enabled = (variable.Substring(6, 1).CompareTo("1") == 0); // chk7
            this.txtLote.Enabled = (variable.Substring(8, 1).CompareTo("1") == 0); //chk9
            //this.txtPedido.Enabled = (variable.Substring(7, 1).CompareTo("1") == 0);
            //OrdenCompra = (variable.Substring(11, 1).CompareTo("1") == 0);
            string txtPedido = (variable.Substring(7, 1).CompareTo("0") == 0 ? "N" : "S"); // chk8
            txtNotaSalida.Enabled = (variable.Substring(12, 1).CompareTo("1") == 0); //chk13
            this.txtCodigoCantera.Enabled = (variable.Substring(9, 1).CompareTo("1") == 0); //chk10
            this.txtCodContratista.Enabled = (variable.Substring(10,1).CompareTo("1") == 0 ); //chk11
            if (Estado == FormEstate.New) {
                if (!this.txtCodProveedor.Enabled) this.txtCodProveedor.Text = string.Empty;
                if (!this.txtCodCliente.Enabled) this.txtCodCliente.Text = string.Empty;
                if (!this.txtCodCentroCosto.Enabled) this.txtCodCentroCosto.Text = string.Empty;
                if (!this.txtCodResponsable.Enabled) this.txtCodResponsable.Text = string.Empty;
                if (!this.txtCodRepReceptor.Enabled) this.txtCodRepReceptor.Text = string.Empty;
                if (!this.txtCodObra.Enabled) this.txtCodObra.Text = string.Empty;
                if (!this.txtCodMaquina.Enabled) this.txtCodMaquina.Text = string.Empty;
                if (!this.txtLote.Enabled) this.txtLote.Text = string.Empty;
                if (this.txtCodContratista.Enabled) this.txtCodContratista.Text = string.Empty;
                if (this.txtCodigoCantera.Enabled) this.txtCodigoCantera.Text = string.Empty; 
            }
            
            //if (!this.txtPedido.Enabled) this.txtPedido.Text = string.Empty;

        }
        private void CargarMovimiento()
        {
            try
            {
                string OrdenTrabajo = "";
                if (gridOrdenTrabajo.Rows.Count == 0)
                {
                    OrdenTrabajo = "";
                }
                else
                {
                    OrdenTrabajo = Util.convertiracadena(this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value);
                }
                
                var movimiento = DocumentoLogic.Instance.TraerMovimiento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                                    this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, OrdenTrabajo);
                this.gridControl.DataSource = movimiento;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ObtenerDescripcion(enmAyuda tipoAyuda, string codigo)
        {
            //Si no ha cargado por completo la pantalla no realiza ninguna accion
            if (!isLoaded) return;

            try
            {
                string descripcion = string.Empty;
                switch (tipoAyuda)
                {
                    case enmAyuda.enmTipoDocumento:
                        this.txtDesTipDoc.Text = string.Empty;

                        if (codigo != "")
                        {
                            //Se modifico el procedimiento de traer descripcion solo para la opcion TipDoc 
                            //agregando ahora tipoNaturaleza y si es entrada o salida para le fitraldo -- 02052016
                            codigo = Logueo.CodigoEmpresa + codigo + Logueo.MP_codnaturaleza + (this.esEntrada ? "E" : "S");
                            GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOC", out descripcion);
                            this.txtDesTipDoc.Text = descripcion;
                            ConfigurarDocumento(txtCodigoTipDoc.Text);                         
                        }
                        break;
                    case enmAyuda.enmTransaccion:
                        this.txtDesTransa.Text = string.Empty;
                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "TRANSAC", out descripcion);
                            this.txtDesTransa.Text = descripcion;
                            this.txtTipoAnalisis.Text = "";
                            if (txtDesTransa.Text != "???")
                            {
                                IEnumerable<TipoTransaccion> transacciones = TipoTransaccionLogic.Instance.TraerTipoTransaccion1(Logueo.CodigoEmpresa);

                                var registro = from fila in transacciones
                                               where fila.in15Codigo == txtCodTransa.Text
                                               select fila.in15ctactetipana;
                                this.txtTipoAnalisis.Text = registro.First();
                            }
                            else { this.txtTipoAnalisis.Text = ""; }
                        }
                        break;
                    case enmAyuda.enmProveedor:
                        this.txtDesProveedor.Text = string.Empty;
                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + txtTipoAnalisis.Text + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROVEEDOR", out descripcion);
                            this.txtDesProveedor.Text = descripcion;
                        }
                        break;

                    case enmAyuda.enmPedido:
                        this.txtDesProveedor.Text = string.Empty;
                        codigo = Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + codigo;

                        string codigoCliente = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(codigo, "CLIPED", out codigoCliente);
                        if (codigoCliente.CompareTo("???") != 0)
                            this.txtCodCliente.Text = codigoCliente;

                        break;
                    case enmAyuda.enmCentroCosto:
                        this.txtDesCentroCosto.Text = string.Empty;

                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CENCOSTO", out descripcion);
                            this.txtDesCentroCosto.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmResponsableReceptor:
                        this.txtDesRespReceptor.Text = string.Empty;

                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "RESPONSABLE", out descripcion);
                            this.txtDesRespReceptor.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmResponsable:
                        this.txtDesResponsable.Text = string.Empty;

                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "RESPONSABLE", out descripcion);
                            this.txtDesResponsable.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmObra:
                        this.txtDesObra.Text = string.Empty;

                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "OBRA", out descripcion);
                            this.txtDesObra.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmMaquina:
                        this.txtDesMaquina.Text = string.Empty;

                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "MAQUINA", out descripcion);
                            this.txtDesMaquina.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmMoneda:
                        this.txtDesMoneda.Text = string.Empty;

                        if (codigo != "")
                        {
                            codigo = Constantes.Tablas.CODIGO_TABLA_MONEDA + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "GLOTA", out descripcion);
                            this.txtDesMoneda.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmNotaSalida:
                        this.txtNotaSalidaDesc.Text = string.Empty;

                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "NOTASALIDA", out descripcion);
                            this.txtNotaSalidaDesc.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmContratista:
                        txtDesContratista.Text = string.Empty;
                        if (codigo != "") {
                            //ccm02emp + ccm02tipana + ccm02cod
                            codigo = Logueo.CodigoEmpresa + "13" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CLIENTE", out descripcion);
                            this.txtDesContratista.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmCantera:
                        this.txtDesCantera.Text = string.Empty;
                        if (codigo != "") {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CANTERA", out descripcion);
                            this.txtDesCantera.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmCanterasxContratista:
                        this.txtDesCantera.Text = string.Empty;
                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CANTERA", out descripcion);
                            this.txtDesCantera.Text = descripcion;
                        }
                        break;

                    case enmAyuda.enmCliente:
                        if(!string.IsNullOrEmpty(codigo)){
                            
                            //this.gridControl.CurrentRow.Cells["ClienteNombre"].Value = 
                        }
                        break;
                    case enmAyuda.enmAlmacen:
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                            this.gridControl.CurrentRow.Cells["DesAlmacen"].Value = descripcion;
                        }
                        
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        private void txtCodProveedor_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmProveedor, this.txtCodProveedor.Text);
        }
        private void txtNotaSalida_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmNotaSalida, this.txtNotaSalida.Text);
        }
        private void txtCodTransa_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmTransaccion, this.txtCodTransa.Text);
        }
        private void txtCodigoTipDoc_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmTipoDocumento, this.txtCodigoTipDoc.Text);
        }
        private void txtPedido_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmPedido, this.txtCodigoTipDoc.Text);
        }
        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmCliente, this.txtCodCliente.Text);
        }
        private void txtCodRepReceptor_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmResponsableReceptor, this.txtCodRepReceptor.Text);
        }
        private void txtCodCentroCosto_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmCentroCosto, this.txtCodCentroCosto.Text);
        }
        private void txtCodResponsable_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmResponsable, this.txtCodResponsable.Text);
        }
        private void txtCodObra_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmObra, this.txtCodObra.Text);
        }
        private void txtCodMaquina_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmMaquina, this.txtCodMaquina.Text);
        }
        private void txtCodMoneda_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmMoneda, this.txtCodMoneda.Text);
        }
        private void frmMoviMP_Activated(object sender, EventArgs e)
        {
            isOpened = true;
        }
        string codigoCliente = string.Empty;
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
               

                    frm = new frmBusqueda(tipoAyuda, esEntrada, Logueo.MP_codnaturaleza);
                    frm.Owner = this;

                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    string[] Resultado = codigoSeleccionado.Split('|');

                    if (codigoSeleccionado != "") this.txtCodigoTipDoc.Text = Resultado[0].ToString(); this.txtDesTipDoc.Text = Resultado[1].ToString();

                    break;
                case enmAyuda.enmTransaccion:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                            this.txtCodTransa.Text = codigoSeleccionado;
                            
                    break;
                case enmAyuda.enmProveedor:
                    frm = new frmBusqueda(tipoAyuda, txtTipoAnalisis.Text);
                    frm.Owner = this;                    
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodProveedor.Text = codigoSeleccionado;

                    break;
                case enmAyuda.enmPedido:
                    break;
                case enmAyuda.enmCliente:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)

                        codigoSeleccionado = frm.Result.ToString();
                     if (codigoSeleccionado != "")
                     {
                         this.gridControl.CurrentRow.Cells["IN07CODCLI"].Value = codigoSeleccionado;
                         ObtenerDescripcion(enmAyuda.enmCliente, codigoSeleccionado);                       
                     }
                    Util.SendTab(Keys.Enter.GetHashCode());
                    break;
                case enmAyuda.enmCentroCosto:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodCentroCosto.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmResponsableReceptor:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodRepReceptor.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmResponsable:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodResponsable.Text = codigoSeleccionado;
                    break;

                case enmAyuda.enmObra:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodObra.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmMaquina:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodigoMaquina.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmLote:
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado, "");
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    string codigoArticulo = string.Empty;
                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                    {
                        codigoArticulo = codigoSeleccionado;

                        string[] separado = codigoArticulo.Split('/');

                        codigoArticulo = separado[0];
                        string DocingAA = separado[1];
                        string DocingMM = separado[2];
                        string DocingTD = separado[3];
                        string DocingCD = separado[4];
                        string DocingPT = separado[5];
                        string DocingNO = separado[6];
                        string CanPiezas = separado[7];
                        string CanArea = separado[8];
                        string nrocaja = separado[9];
                        string Cliente = separado[10];
                        string clienteNombre = separado[11];
                        string ClientePedidonro = separado[12];
                        string AreaxUni = separado[13];


                        this.gridControl.CurrentRow.Cells["IN07DocIngAA"].Value = DocingAA;
                        this.gridControl.CurrentRow.Cells["IN07DocIngMM"].Value = DocingMM;
                        this.gridControl.CurrentRow.Cells["IN07DocIngTIPDOC"].Value = DocingTD;
                        this.gridControl.CurrentRow.Cells["IN07DocIngCODDOC"].Value = DocingCD;
                        this.gridControl.CurrentRow.Cells["IN07DocIngKEY"].Value = DocingPT;
                        this.gridControl.CurrentRow.Cells["IN07DocIngORDEN"].Value = DocingNO;
                        this.gridControl.CurrentRow.Cells["Cantidad"].Value = CanPiezas;
                        this.gridControl.CurrentRow.Cells["AreaxUni"].Value = AreaxUni;
                        this.gridControl.CurrentRow.Cells["Area"].Value = CanArea;
                        this.gridControl.CurrentRow.Cells["NroCaja"].Value = nrocaja;
                        this.gridControl.CurrentRow.Cells["IN07CODCLI"].Value = Cliente;
                        this.gridControl.CurrentRow.Cells["clienteNombre"].Value = clienteNombre;
                        this.gridControl.CurrentRow.Cells["NroPedidoVenta"].Value = ClientePedidonro;

                        //Carga los datos de un Articulo
                        string descripcion = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "ARTICULO", out  descripcion);
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticulo.Trim();
                        this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = descripcion.Trim();

                        string unidad = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "UNIDADARTICULO", out  unidad);
                        this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = unidad.Trim();

                        // Trae las medidaas delarticulo
                        Movimiento movimiento = new Movimiento();

                        movimiento.CodigoEmpresa = Logueo.CodigoEmpresa;
                        movimiento.Anio = DocingAA;
                        movimiento.Mes = DocingMM;
                        movimiento.CodigoTipoDocumento = DocingTD;
                        movimiento.CodigoDocumento = DocingCD;
                        movimiento.CodigoArticulo = DocingPT;
                        movimiento.Orden = double.Parse(DocingNO);

                        Articulo articulo = ArticuloLogic.Instance.ProterMedidasSalida(movimiento);

                        double Anchonum = articulo.anchonum;
                        double largonum = articulo.largonum;
                        double Espesornum = articulo.espesornum;

                        string Anchotext = articulo.anchotext;
                        string largotext = articulo.largotext;
                        string Espesortext = articulo.espesortext;


                        // ================= Largo
                        //Como es salida no separado puede modificar el largo
                        this.gridControl.CurrentRow.Cells["Largo"].Value = largonum;
                        this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = true;

                        // ================= Ancho
                        this.gridControl.CurrentRow.Cells["Ancho"].Value = Anchonum;
                        this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = true;

                        //=================  Espesor
                        this.gridControl.CurrentRow.Cells["Alto"].Value = Espesornum;
                        this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = true;


                        //Presiono tecla Enter para que avance
                        Util.SendTab(Keys.Enter.GetHashCode());
                        Util.SendTab(Keys.Enter.GetHashCode());
                        Util.SendTab(Keys.Enter.GetHashCode());
                    }

                    break;

                case enmAyuda.enmProductoXAlmacenIng:
                    /*
                    this.CrearColumnasAyuda(tipoAyuda);
                    this.gridAyuda.Visible = true;
                    this.gridAyuda.Focus();
                     */
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado, "");
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    codigoArticulo = string.Empty;

                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                    {
                        codigoArticulo = codigoSeleccionado;

                        //Carga los datos de un Articulo
                        string descripcion = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "ARTICULO", out  descripcion);
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticulo.Trim();
                        this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = descripcion.Trim();

                        string unidad = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "UNIDADARTICULO", out  unidad);
                        this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = unidad.Trim();
                        this.gridControl.CurrentRow.Cells["NroCaja"].BeginEdit();                        

                        // Trae las medidaas delarticulo
                        Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo.Trim());
                    }

                    break;
                case enmAyuda.enmAlmacen:
                    this._codigoAlmacenSeleccionado = "01";
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado, "");
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                    {
                        this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value = codigoSeleccionado.Trim();
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = null;
                        this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = null;
                        this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = null;
                        ObtenerDescripcion(enmAyuda.enmAlmacen, codigoSeleccionado.Trim());
                        //Presiono tecla Enter para que avance
                        //this.gridControl.current
                        //Util.SendTab(Keys.Enter.GetHashCode());
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].IsSelected = true;
                    }
                    break;
                case enmAyuda.enmPedVentIng:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                    {
                        this.gridControl.CurrentRow.Cells["in07pedvennum"].Value = codigoSeleccionado.Trim();
                        //Presiono tecla Enter para que avance
                        Util.SendTab(Keys.Enter.GetHashCode());
                    }
                    break;
                case enmAyuda.enmProductoXPedVenSalida:
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado, this._PedidoVentaSeleccionado);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        List<EntidadAyuda> variableCapturar = (List<EntidadAyuda>)frm.Result;
                        string codigoArticuloSal = string.Empty;
                        string salpedvenDocingAA = string.Empty;
                        string salpedvenDocingMM = string.Empty;
                        string salpedvenDocingTD = string.Empty;
                        string salpedvenDocingCD = string.Empty;
                        string salpedvenDocingPT = string.Empty;
                        string salpedvenDocingNO = string.Empty;
                        string salpedvenCanPiezas = string.Empty;
                        string salpedvenCanArea = string.Empty;
                        string salpedvennrocaja = string.Empty;
                        string salpedvenAreaxUni = string.Empty;
                        string salpedvennum = string.Empty;
                        string salpedvenitem = string.Empty;


                        int contadorfilas = 1;

                        foreach (var item in variableCapturar)
                        {
                            //Limpio los valores
                            codigoArticuloSal = "";
                            salpedvenDocingAA = "";
                            salpedvenDocingMM = "";
                            salpedvenDocingTD = "";
                            salpedvenDocingCD = "";
                            salpedvenDocingPT = "";
                            salpedvenDocingNO = "";
                            salpedvenCanPiezas = "";
                            salpedvenCanArea = "";
                            salpedvennrocaja = "";
                            salpedvenAreaxUni = "";
                            salpedvennum = "";
                            salpedvenitem = "=";

                            codigoArticuloSal = item.campotexto1;
                            salpedvenDocingAA = item.campotexto2;
                            salpedvenDocingMM = item.campotexto3;
                            salpedvenDocingTD = item.campotexto4;
                            salpedvenDocingCD = item.campotexto5;
                            salpedvenDocingPT = item.campotexto6;
                            salpedvenDocingNO = item.campotexto7;
                            salpedvenCanPiezas = item.campotexto8;
                            salpedvenCanArea = item.campotexto9;
                            salpedvennrocaja = item.campotexto10;
                            salpedvennum = item.campotexto11;
                            salpedvenitem = item.campotexto12;
                            salpedvenAreaxUni = item.camponumero1.ToString();


                            // Si la lista tiene oun solo elemento, se agrega los valores en la fila agregada
                            //Agrego la fila a la grilla
                            //string lastCodigoAlmacen = this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["CodigoAlmacen"].Value.ToString();
                            // Agrega fila siempre y cuando la lsita tenga + de una fila
                            if (contadorfilas == 1)
                            {

                                // ===========  Paso los valores a la grilla
                                this.gridControl.CurrentRow.Cells["IN07DocIngAA"].Value = salpedvenDocingAA;
                                this.gridControl.CurrentRow.Cells["IN07DocIngMM"].Value = salpedvenDocingMM;
                                this.gridControl.CurrentRow.Cells["IN07DocIngTIPDOC"].Value = salpedvenDocingTD;
                                this.gridControl.CurrentRow.Cells["IN07DocIngCODDOC"].Value = salpedvenDocingCD;
                                this.gridControl.CurrentRow.Cells["IN07DocIngKEY"].Value = salpedvenDocingPT;
                                this.gridControl.CurrentRow.Cells["IN07DocIngORDEN"].Value = salpedvenDocingNO;
                                this.gridControl.CurrentRow.Cells["Cantidad"].Value = salpedvenCanPiezas;
                                this.gridControl.CurrentRow.Cells["AreaxUni"].Value = salpedvenAreaxUni;
                                this.gridControl.CurrentRow.Cells["Area"].Value = salpedvenCanArea;
                                this.gridControl.CurrentRow.Cells["NroCaja"].Value = salpedvennrocaja;
                                this.gridControl.CurrentRow.Cells["in07pedvennum"].Value = salpedvennum;
                                this.gridControl.CurrentRow.Cells["in07pedvenitem"].Value = salpedvenitem;

                                //this.gridControl.CurrentRow.Cells["OrdenProduccion"].Value = Cliente;
                                //this.gridControl.CurrentRow.Cells["NroPedidoVenta"].Value = ClientePedidonro;


                                //Carga los datos de un Articulo
                                string descripcion = string.Empty;
                                GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticuloSal), "ARTICULO", out  descripcion);
                                this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticuloSal.Trim();
                                this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = descripcion.Trim();

                                string unidad = string.Empty;
                                GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticuloSal), "UNIDADARTICULO", out  unidad);
                                this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = unidad.Trim();

                                // Trae las medidaas delarticulo
                                Movimiento movimiento = new Movimiento();

                                movimiento.CodigoEmpresa = Logueo.CodigoEmpresa;
                                movimiento.Anio = salpedvenDocingAA;
                                movimiento.Mes = salpedvenDocingMM;
                                movimiento.CodigoTipoDocumento = salpedvenDocingTD;
                                movimiento.CodigoDocumento = salpedvenDocingCD;
                                movimiento.CodigoArticulo = salpedvenDocingPT;
                                movimiento.Orden = double.Parse(salpedvenDocingNO);

                                Articulo articulo = ArticuloLogic.Instance.ProterMedidasSalida(movimiento);

                                double Anchonum = articulo.anchonum;
                                double largonum = articulo.largonum;
                                double Espesornum = articulo.espesornum;

                                string Anchotext = articulo.anchotext;
                                string largotext = articulo.largotext;
                                string Espesortext = articulo.espesortext;


                                // ================= Largo
                                //Como es salida no separado puede modificar el largo
                                this.gridControl.CurrentRow.Cells["Largo"].Value = largonum;
                                this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = true;

                                // ================= Ancho
                                this.gridControl.CurrentRow.Cells["Ancho"].Value = Anchonum;
                                this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = true;

                                //=================  Espesor
                                this.gridControl.CurrentRow.Cells["Alto"].Value = Espesornum;
                                this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = true;

                                // Grabar fila
                                this.GuardarDetalle(this.gridControl.CurrentRow);
                            }

                            else if (contadorfilas > 1)
                            {
                                // agrego una fil ala grilla
                                GridViewRowInfo rowInfo = this.gridControl.Rows.AddNew();
                                rowInfo.Cells["Orden"].Value = 0;
                                rowInfo.Cells["CodigoAlmacen"].Value = "06";

                                // ===========  Paso los valores a la grilla
                                rowInfo.Cells["IN07DocIngAA"].Value = salpedvenDocingAA;
                                rowInfo.Cells["IN07DocIngMM"].Value = salpedvenDocingMM;
                                rowInfo.Cells["IN07DocIngTIPDOC"].Value = salpedvenDocingTD;
                                rowInfo.Cells["IN07DocIngCODDOC"].Value = salpedvenDocingCD;
                                rowInfo.Cells["IN07DocIngKEY"].Value = salpedvenDocingPT;
                                rowInfo.Cells["IN07DocIngORDEN"].Value = salpedvenDocingNO;
                                rowInfo.Cells["Cantidad"].Value = salpedvenCanPiezas;
                                rowInfo.Cells["AreaxUni"].Value = salpedvenAreaxUni;
                                rowInfo.Cells["Area"].Value = salpedvenCanArea;
                                rowInfo.Cells["NroCaja"].Value = salpedvennrocaja;
                                rowInfo.Cells["in07pedvennum"].Value = salpedvennum;
                                rowInfo.Cells["in07pedvenitem"].Value = salpedvenitem;
                                //this.gridControl.CurrentRow.Cells["OrdenProduccion"].Value = Cliente;
                                //this.gridControl.CurrentRow.Cells["NroPedidoVenta"].Value = ClientePedidonro;


                                //Carga los datos de un Articulo
                                string descripcion = string.Empty;
                                GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticuloSal), "ARTICULO", out  descripcion);
                                rowInfo.Cells["CodigoArticulo"].Value = codigoArticuloSal.Trim();
                                rowInfo.Cells["DescripcionArticulo"].Value = descripcion.Trim();

                                string unidad = string.Empty;
                                GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticuloSal), "UNIDADARTICULO", out  unidad);
                                rowInfo.Cells["UnidadMedida"].Value = unidad.Trim();

                                // Trae las medidaas delarticulo
                                Movimiento movimiento = new Movimiento();

                                movimiento.CodigoEmpresa = Logueo.CodigoEmpresa;
                                movimiento.Anio = salpedvenDocingAA;
                                movimiento.Mes = salpedvenDocingMM;
                                movimiento.CodigoTipoDocumento = salpedvenDocingTD;
                                movimiento.CodigoDocumento = salpedvenDocingCD;
                                movimiento.CodigoArticulo = salpedvenDocingPT;
                                movimiento.Orden = double.Parse(salpedvenDocingNO);

                                Articulo articulo = ArticuloLogic.Instance.ProterMedidasSalida(movimiento);

                                double Anchonum = articulo.anchonum;
                                double largonum = articulo.largonum;
                                double Espesornum = articulo.espesornum;

                                string Anchotext = articulo.anchotext;
                                string largotext = articulo.largotext;
                                string Espesortext = articulo.espesortext;


                                // ================= Largo
                                //Como es salida no separado puede modificar el largo
                                rowInfo.Cells["Largo"].Value = largonum;
                                rowInfo.Cells["Largo"].ReadOnly = true;

                                // ================= Ancho
                                rowInfo.Cells["Ancho"].Value = Anchonum;
                                rowInfo.Cells["Ancho"].ReadOnly = true;

                                //=================  Espesor
                                rowInfo.Cells["Alto"].Value = Espesornum;
                                rowInfo.Cells["Alto"].ReadOnly = true;

                                this.GuardarDetalle(rowInfo);

                            }
                            // =============== Grabo la grilla

                            contadorfilas++;
                        }

                        //Refresco la grilla

                    }

                    break;
                case enmAyuda.enmPedVentIngPT:
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado, this._PedidoVentaSeleccionado);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    string codigoArticulopv = string.Empty;

                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                    {
                        codigoArticulopv = codigoSeleccionado;

                        string[] separado = codigoArticulopv.Split('/');

                        string pedvennum = separado[0];
                        codigoArticulopv = separado[1];
                        string pedvenitem = separado[2];

                        //
                        this.gridControl.CurrentRow.Cells["in07pedvenitem"].Value = pedvenitem;

                        //Carga los datos de un Articulo
                        string descripcion = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulopv), "ARTICULO", out  descripcion);
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticulopv.Trim();
                        this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = descripcion.Trim();

                        string unidad = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulopv), "UNIDADARTICULO", out  unidad);
                        this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = unidad.Trim();


                        Articulo articulo = ArticuloLogic.Instance.ProterMedidasPedVen(Logueo.CodigoEmpresa, pedvennum, codigoArticulopv, double.Parse(pedvenitem));


                        if (articulo == null) return;

                        double Anchonum = articulo.anchonum;
                        double largonum = articulo.largonum;
                        double Espesornum = articulo.espesornum;

                        string Anchotext = articulo.anchotext;
                        string largotext = articulo.largotext;
                        string Espesortext = articulo.espesortext;


                        // ================= Largo
                        //Como es salida no separado puede modificar el largo
                        this.gridControl.CurrentRow.Cells["Largo"].Value = largonum;
                        this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = true;

                        // ================= Ancho
                        this.gridControl.CurrentRow.Cells["Ancho"].Value = Anchonum;
                        this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = true;

                        //=================  Espesor
                        this.gridControl.CurrentRow.Cells["Alto"].Value = Espesornum;
                        this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = true;


                        //Presiono tecla Enter para que avance
                        Util.SendTab(Keys.Enter.GetHashCode());
                        Util.SendTab(Keys.Enter.GetHashCode());
                        Util.SendTab(Keys.Enter.GetHashCode());
                    }

                    break;
                case enmAyuda.enmprovmateriaprima:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                    {
                        //this.gridControl.CurrentRow.Cells["IN07PROVMATPRIMA"].Value = codigoSeleccionado.Trim();

                        this.gridControl.CurrentRow.Cells["IN07PROVMATPRIMA"].Value = ((Proveedor)frm.Result).Codigo;
                        this.gridControl.CurrentRow.Cells["ProvMatPrimaNombre"].Value = ((Proveedor)frm.Result).Nombre;
                        if (Convert.ToInt32(gridControl.CurrentRow.Cells["Orden"].Value) != 0)
                        {
                            this.GuardarDetalle(gridControl.CurrentRow);
                        }
                        //Presiono tecla Enter para que avance
                        Util.SendTab(Keys.Enter.GetHashCode());
                    }
                    break;
                case enmAyuda.enmMoneda:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtCodMoneda.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmNotaSalida:

                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();

                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                        this.txtNotaSalida.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmContratista:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "") {
                            txtCodContratista.Text = codigoSeleccionado;
                        }
                        //txtCodContratista.Text = ((CuentaCorriente)frm.Result).ccm02cod == null ? "" : ((CuentaCorriente)frm.Result).ccm02cod;
                        //txtDesContratista.Text = ((CuentaCorriente)frm.Result).ccm02nom == null ? "" : ((CuentaCorriente)frm.Result).ccm02nom;
                    }
                    break;
                case enmAyuda.enmCantera:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "") {
                            txtCodigoCantera.Text = frm.Result.ToString();
                        }
                        //= ((Canteras)frm.Result).IN20CODIGO == null ? "" : ((Canteras)frm.Result).IN20CODIGO;
                        //txtDesCantera.Text = ((Canteras)frm.Result).IN20DESC == null ? "" : ((Canteras)frm.Result).IN20DESC;
                    }
                    break;
                case enmAyuda.enmCanterasxContratista:

                    frm = new frmBusqueda(tipoAyuda, this.txtCodContratista.Text.Trim());
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {
                            txtCodigoCantera.Text = frm.Result.ToString();
                        }
                    }
                    break;
                case enmAyuda.enmMotivo:
                     frm = new frmBusqueda(enmAyuda.enmMotivo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        string[] cadena = frm.Result.ToString().Split('|');
                        this.gridControl.CurrentRow.Cells["IN07MOTIVOCOD"].Value = cadena[0];
                        this.gridControl.CurrentRow.Cells["DesMotivo"].Value = cadena[1];
                    }
                    
                    break;
                default:
                    break;
            }
        }
       /* private void CrearColumnasAyuda(enmAyuda tipoAyuda)
        {
            this.gridAyuda.Columns.Clear();
            this.gridAyuda.ShowGroupPanel = false;
            this.gridAyuda.AllowAddNewRow = false;
            this.gridAyuda.EnableHotTracking = true;
            this.gridAyuda.AllowColumnReorder = true;
            this.gridAyuda.ShowFilteringRow = true;


            this.gridAyuda.EnableFiltering = true;
            //this.gridAyuda.EnableCustomFiltering = true;

            this.gridAyuda.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.gridAyuda.AutoGenerateColumns = false;

            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    //var tipDocs = TipoDocumentoLogic.Instance.TraerTipoDocumento2(Logueo.CodigoEmpresa,");
                    var tipDocs = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
                    gridAyuda.DataSource = tipDocs;

                    break;
                case enmAyuda.enmTransaccion:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var tipTrans = TipoTransaccionLogic.Instance.TraerTipoTransaccion1(Logueo.CodigoEmpresa);
                    this.gridAyuda.DataSource = tipTrans;

                    break;
                case enmAyuda.enmProveedor:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var proveedores = ProveedorLogic.Instance.TraerProveedor(Logueo.CodigoEmpresa, Logueo.TipoAnalisisProveedor);
                    this.gridAyuda.DataSource = proveedores;

                    break;
                case enmAyuda.enmprovmateriaprima:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var provmateriaprima = ProveedorLogic.Instance.TraerProveedor(Logueo.CodigoEmpresa, Logueo.TipoAnalisisProveedor);
                    this.gridAyuda.DataSource = provmateriaprima;

                    break;
                case enmAyuda.enmPedido:
                    break;
                case enmAyuda.enmCliente:
                    break;
                case enmAyuda.enmCentroCosto:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var cencos = CentroCostoLogic.Instance.TraerCentroCosto(Logueo.CodigoEmpresa);
                    this.gridAyuda.DataSource = cencos;
                    break;
                case enmAyuda.enmResponsableReceptor:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var respReceptor = ResponsableLogic.Instance.TraerResponsable(Logueo.CodigoEmpresa);
                    this.gridAyuda.DataSource = respReceptor;
                    break;
                case enmAyuda.enmResponsable:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Nombre", "Nombre", 0, "", 300, true, false, true);

                    var resp = ResponsableLogic.Instance.TraerResponsable(Logueo.CodigoEmpresa);
                    this.gridAyuda.DataSource = resp;
                    break;
                case enmAyuda.enmObra:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Descripción", "Descripcion", 0, "", 300, true, false, true);

                    var obras = ObraLogic.Instance.TraerObra(Logueo.CodigoEmpresa);
                    this.gridAyuda.DataSource = obras;
                    break;
                case enmAyuda.enmMaquina:
                    break;
                case enmAyuda.enmLote:
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    this.CreateGridColumn(this.gridAyuda, "Código", "Codigo", 0, "", 120, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Descripción", "Descripcion", 0, "", 300, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Unidad de medida", "UnidadMedida", 0, "", 300, true, false, true);

                    var Articulos = ArticuloLogic.Instance.TraerArticuloXAlmacen(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, _codigoAlmacenSeleccionado);
                    this.gridAyuda.DataSource = Articulos;
                    break;
                case enmAyuda.enmNotaSalida:
                    this.CreateGridColumn(this.gridAyuda, "Codigo", "IN06CODDOC", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Anio", "IN06AA", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Mes", "IN06MM", 0, "", 50, true, false, true);
                    this.CreateGridColumn(this.gridAyuda, "Tipo documento", "Tipo_Documento", 0, "", 50, true, false, true);

                    var notas = DocumentoLogic.Instance.Spu_Inv_Trae_NotaSalida(Logueo.CodigoEmpresa);
                    gridAyuda.DataSource = notas;

                    break;
                default:
                    break;
            }

        }*/
        private void txtCodigoTipDoc_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTipoDocumento);
        }

        private void dtpFechaDoc_KeyDown(object sender, KeyEventArgs e)
        {
            this.dtpFechaDoc.ReadOnly = (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) ? true : false;
        }

        
        private void txtNroReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
        }
        private void txtCodTransa_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTransaccion);
        }
        private void txtCodProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmProveedor);
        }
        private void txtPedido_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
        }
        private void txtCodCentroCosto_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmCentroCosto);
        }
        private void txtCodRepReceptor_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmResponsableReceptor);
        }
        private void txtCodResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmResponsable);
        }

        private void cboMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
        }

        private void txtCodObra_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmObra);
        }

        private void txtCodMaquina_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
        }

        private void txtLote_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
        }

        private void txtCodMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmMoneda);
        }
        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.gridControl.ActiveEditor != null)
                {
                    //if (this.gridControl.CurrentRow.Cells["flag"].Value.ToString() == "1") 
                    //{                        
                    //    e.Cancel = true;
                    //    return;
                    //} 

                    if (e.Column.Name.CompareTo("CodigoArticulo") == 0)
                    {
                        if (double.Parse(this.gridControl.CurrentRow.Cells["Orden"].Value.ToString()) > 0)
                        {
                            e.Cancel = true;
                        }

                        if (this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value == null)
                        {
                            RadMessageBox.Show("Debe seleccionar un Almacén", "Aviso",
                                MessageBoxButtons.OK, RadMessageIcon.Info);
                            e.Cancel = true;
                            return;
                        }
                        if (this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString().CompareTo("") == 0)
                        {
                            RadMessageBox.Show("Debe seleccionar un Almacén", "Aviso",
                                MessageBoxButtons.OK, RadMessageIcon.Info);
                            e.Cancel = true;
                            return;
                        }
                    }

                    if (e.Column.Name.CompareTo("CodigoAlmacen") == 0)
                    {
                        if (this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value != null)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    
                    if (e.Column.Name == "NroCaja" || e.Column.Name == "Ancho" || e.Column.Name == "Largo" || e.Column.Name == "Alto"
                        || e.Column.Name == "Cantidad" || e.Column.Name == "CodBloqProv" || e.Column.Name == "AnchoCan"
                        || e.Column.Name == "LargoCan" || e.Column.Name == "AltoCan") 
                    {
                        if (gridControl.CurrentRow.Cells["flag"].Value == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }

            catch (Exception ex)
            {

            }

        }
        private void gridControl_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Value == null)
                return;
            try
            {
                /*
                    this.CreateGridColumn(grilla, "Ancho", "Ancho", 0, "", 60, !true, !false, true);
            this.CreateGridColumn(grilla, "Largo", "Largo", 0, "", 60, !true, !false, true);
            this.CreateGridColumn(grilla, "Espesor", "Alto", 0, "", 60, !true, !false, true);            
            this.CreateGridColumn(grilla, "Volumen", "Volumen", 0, "", 60, true, false, true);
                 */
                decimal subtotal = 0;
                decimal cantidad = 0;
                decimal costoUnidad = 0;

                string UniMed = string.Empty;
                string Ptcodigo = string.Empty;
                Ptcodigo = gridControl.CurrentRow.Cells["CodigoArticulo"].Value.ToString();
                decimal Area = 0;
                double volumen = 0;
                double ancho = 0;
                double largo = 0;
                double alto = 0;
                double AreaxUni = 0;
                ancho = double.Parse(gridControl.CurrentRow.Cells["Ancho"].Value.ToString());
                largo = double.Parse(gridControl.CurrentRow.Cells["Largo"].Value.ToString());
                alto = double.Parse(gridControl.CurrentRow.Cells["Alto"].Value.ToString());
                
                // Traer area x unidad del articulo
                // si se esta modificando y es salida, que no calcule, si no que tome el area x unidad guardado
                string tipotransaccion = string.Empty;
                GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + this.txtCodigoTipDoc.Text, "TIPDOCMOV", out tipotransaccion);

                if (tipotransaccion == "S") //Verifico Que sea salida
                {
                    if (double.Parse(gridControl.CurrentRow.Cells["Orden"].Value.ToString()) != 0) // Solo para las modificaciones
                    {
                        AreaxUni = double.Parse(gridControl.CurrentRow.Cells["Areaxuni"].Value.ToString());
                    }
                    else
                    {
                        Articulo articulo = ArticuloLogic.Instance.AreaxUniGeneral(Logueo.CodigoEmpresa, Logueo.Anio, Ptcodigo, ancho, largo,Logueo.MP_codnaturaleza);
                        AreaxUni = articulo.AreaxUni;
                        this.gridControl.CurrentRow.Cells["Areaxuni"].Value = AreaxUni.ToString();
                    }
                }
                else
                {
                    Articulo articulo = ArticuloLogic.Instance.AreaxUniGeneral(Logueo.CodigoEmpresa, Logueo.Anio, Ptcodigo, ancho, largo,Logueo.MP_codnaturaleza);
                    AreaxUni = articulo.AreaxUni;
                    this.gridControl.CurrentRow.Cells["Areaxuni"].Value = AreaxUni.ToString();
                }

                // Calculo Area
                Area = (decimal)(AreaxUni * Convert.ToDouble(cantidad));


                volumen = ancho * largo * alto;
                gridControl.CurrentRow.Cells["Cantidad"].Value = volumen;

                double anchoCan = 0;
                double largoCan = 0;
                double altoCan = 0;
                double volumenCan = 0;
                anchoCan = double.Parse(this.gridControl.CurrentRow.Cells["AnchoCan"].Value.ToString());
                largoCan = double.Parse(this.gridControl.CurrentRow.Cells["LargoCan"].Value.ToString());
                altoCan = double.Parse(this.gridControl.CurrentRow.Cells["AltoCan"].Value.ToString());

                volumenCan = anchoCan * largoCan * altoCan;
                gridControl.CurrentRow.Cells["VolumenCan"].Value = volumenCan;
 
                double difvol = volumen - volumenCan;
                this.gridControl.CurrentRow.Cells["DifVol"].Value = difvol;

                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        #region Agregar y quitar Item

        private void btnAddDetalle_Click(object sender, EventArgs e)
        {
            this.gridControl.Focus();
            try
            {
                //Valida que la cabecera debe estar guardado
                if (this.txtCodigoTipDoc.Enabled)
                {
                    RadMessageBox.Show("Para registrar detalles debe guardar el documento", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (this.gridControl.RowCount == 0)
                {
                    //Agregar fila nueva
                    GridViewRowInfo rowInfo = this.gridControl.Rows.AddNew();                    
                    rowInfo.Cells["Orden"].Value = 0;                    
                    rowInfo.Cells["CodigoAlmacen"].IsSelected = true;
                    //Flag para indicar la fila agregado es modo edicion
                    rowInfo.Cells["flag"].Value = "0";
                    //Resalta celda de ayuda Color: Amarillo
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);
                }
                else
                {
                    if (this.gridControl.CurrentRow.Cells["flag"].Value != null)
                    {
                        RadMessageBox.Show("Debe completar el registro actual", "Aviso",
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    if (this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["DescripcionArticulo"].Value.ToString().CompareTo("???") == 0)
                    {
                        RadMessageBox.Show("Debe ingresar correctamente los artículos en el documento", "Aviso",
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }

                    if (double.Parse(this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["Orden"].Value.ToString()) == 0)
                    {
                        RadMessageBox.Show("No ha completado registrar el detalle de documento", "Aviso",
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    this.gridControl.ClearSelection();
                    //Obtener el ultimo codigo de almacen
                    string lastCodigoAlmacen = this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["CodigoAlmacen"].Value.ToString();
                    //Agregar una nueva fila
                    GridViewRowInfo rowInfo = this.gridControl.Rows.AddNew();                    
                    //Asginar el ultimo codigo de Almacen
                    rowInfo.Cells["CodigoAlmacen"].Value = lastCodigoAlmacen;
                    rowInfo.Cells["Orden"].Value = 0;
                    //Flag para idnicar la fila en mdoo edicion.
                    rowInfo.Cells["flag"].Value = "0";

                    //Resalta celda de ayuda Color: Amarillo
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        bool ValidarDetalle(GridViewRowInfo fila) { 
            
            if (fila.Cells["CodigoAlmacen"].Value  == null) {
                RadMessageBox.Show("Ingresar codigo almacen", "Sistema", MessageBoxButtons.OK , RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["CodigoAlmacen"];
                return false;
            }
            if (fila.Cells["CodigoArticulo"].Value == null)
            {
                RadMessageBox.Show("Ingresar Articulo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["CodigoArticulo"];
                return false;
            }
            if (fila.Cells["DescripcionArticulo"].Value == null)
            {
                RadMessageBox.Show("Ingresar Articulo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["DescripcionArticulo"];
                return false;
            }

            if (fila.Cells["UnidadMedida"].Value == null)
            {
                RadMessageBox.Show("Ingresar unidad medida ", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["UnidadMedida"];
                return false;
            }

            if (fila.Cells["NroCaja"].Value.ToString() == "")
            {
                RadMessageBox.Show("Ingresar codigo Bloque Empresa", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["NroCaja"];
                return false;
            }

            if (double.Parse(fila.Cells["largo"].Value.ToString()) == 0) {
                RadMessageBox.Show("Ingresar largo de bloque empresa", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["largo"];
                return false;
            }

            if (double.Parse(fila.Cells["ancho"].Value.ToString()) == 0 ) {
                RadMessageBox.Show("Ingresar ancho de bloque empresa", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["ancho"];
                return false;
            }

            if (double.Parse(fila.Cells["Alto"].Value.ToString()) == 0)
            {
                RadMessageBox.Show("Ingresar alto de bloque empresa", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["Alto"];
                return false;
            }

            if (fila.Cells["CodBloqProv"].Value.ToString() == "") {
                RadMessageBox.Show("Ingresar codigo de bloque cantera", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["CodBloqProv"];
                return false;
            }
            if (double.Parse(fila.Cells["AnchoCan"].Value.ToString()) == 0) {
                RadMessageBox.Show("Ingresar ancho de bloque cantera", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["AnchoCan"];
                return false;
            }

            if (double.Parse(fila.Cells["LargoCan"].Value.ToString()) == 0) {
                RadMessageBox.Show("Ingresar largo de bloque cantera", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["LargoCan"];
                return false;
            }
            if (double.Parse(fila.Cells["AltoCan"].Value.ToString()) == 0) {
                RadMessageBox.Show("Ingresar Alto de bloque cantera", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.gridControl.CurrentColumn = gridControl.Columns["AltoCan"];
                return false;
            }
            return true;
        }
        
        private void GuardarDetalle(GridViewRowInfo info)
        {
            try
            {
                if (!ValidarDetalle(info)) return;
                //Capturar el tipo de movimiento segun el movimiento del tipo de documento
                string codigo = string.Empty;
                string transaccion = string.Empty;
                codigo = Logueo.CodigoEmpresa + this.txtCodigoTipDoc.Text;
                GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOCMOV", out transaccion);

                //Paso los valores
                Movimiento mov = new Movimiento();
                mov.CodigoEmpresa = Logueo.CodigoEmpresa;
                mov.Anio = Logueo.Anio;
                mov.Mes = Logueo.Mes;
                mov.CodigoTipoDocumento = this.txtCodigoTipDoc.Text;
                mov.CodigoDocumento = this.txtNroDocumento.Text;
                mov.CodigoArticulo = info.Cells["CodigoArticulo"].Value == null ? null : info.Cells["CodigoArticulo"].Value.ToString();
                
                //dimension de empresa
                mov.CodBloEmp = info.Cells["NroCaja"].Value.ToString();
                mov.NroCaja = info.Cells["NroCaja"].Value.ToString();
                
                mov.Largo = double.Parse(info.Cells["largo"].Value.ToString());
                mov.Ancho = double.Parse(info.Cells["ancho"].Value.ToString());
                mov.Alto = double.Parse(info.Cells["Alto"].Value.ToString());

                mov.CodigoAlmacen = info.Cells["CodigoAlmacen"].Value == null ? null : info.Cells["CodigoAlmacen"].Value.ToString();
                mov.CodigoTransaccion = this.txtCodTransa.Text;
                mov.Transaccion = transaccion;
                //volumen de bloque - empresa
                mov.Cantidad = double.Parse(info.Cells["Cantidad"].Value.ToString());
                
                mov.CodBloqProv = info.Cells["CodBloqProv"].Value.ToString();
                

                mov.AnchoCan = double.Parse(info.Cells["AnchoCan"].Value.ToString());
                mov.LargoCan = double.Parse(info.Cells["LargoCan"].Value.ToString());
                mov.AltoCan  = double.Parse(info.Cells["AltoCan"].Value.ToString());
                

                //mov.CostoUnidad = double.Parse(info.Cells["CostoUnidad"].Value.ToString());
                //mov.Importe = double.Parse(info.Cells["Importe"].Value.ToString());

                mov.Areaxuni = double.Parse(info.Cells["Areaxuni"].Value == null ? "0" : info.Cells["Areaxuni"].Value.ToString());
                mov.FechaDoc = this.dtpFechaDoc.Value;


                //Trae numero de orden                
                mov.UnidadMedida = info.Cells["UnidadMedida"].Value == null ? null : info.Cells["UnidadMedida"].Value.ToString();
                mov.in07observacion = info.Cells["in07observacion"].Value == null ? null : info.Cells["in07observacion"].Value.ToString();
                mov.IN07MOTIVOCOD = info.Cells["IN07MOTIVOCOD"].Value == null ? null : info.Cells["IN07MOTIVOCOD"].Value.ToString();
                // Campos que relacionan la salida con su respectivo ingreso
                if (transaccion == "S")
                {
                    if (info.Cells["IN07DocIngAA"].Value != null) mov.IN07DocIngAA = info.Cells["IN07DocIngAA"].Value.ToString();
                    if (info.Cells["IN07DocIngMM"].Value != null) mov.IN07DocIngMM = info.Cells["IN07DocIngMM"].Value.ToString();
                    if (info.Cells["IN07DocIngTIPDOC"].Value != null) mov.IN07DocIngTIPDOC = info.Cells["IN07DocIngTIPDOC"].Value.ToString();
                    if (info.Cells["IN07DocIngCODDOC"].Value != null) mov.IN07DocIngCODDOC = info.Cells["IN07DocIngCODDOC"].Value.ToString();
                    if (info.Cells["IN07DocIngKEY"].Value != null) mov.IN07DocIngKEY = info.Cells["IN07DocIngKEY"].Value.ToString();
                    if (info.Cells["IN07DocIngORDEN"].Value != null) mov.IN07DocIngORDEN = double.Parse(info.Cells["IN07DocIngORDEN"].Value.ToString());
                }

                string mensajeRetorno = string.Empty;
                int flag = 0;
                string @FlagValida = "0";
                if (double.Parse(info.Cells["Orden"].Value.ToString()) == 0)
                {
                    //NUEVO                    
                    double orden = 0;

                    DocumentoLogic.Instance.TraerNroOrden(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.txtCodigoTipDoc.Text, 
                                                           this.txtNroDocumento.Text, mov.CodigoArticulo, out orden);
                    mov.Orden = orden;
                    string salidaFlagvalida = "";
                    //validamos si este bloque esta con medida de bloque rechazado y no se guarda en el almacen de rechazado
                    DocumentoLogic.Instance.ValidaInsertarDetalleMP(mov, Logueo.TipoCambio, Logueo.MonedaxDefecto, @FlagValida, out salidaFlagvalida,
                        out flag, out mensajeRetorno);
                 

                    if (salidaFlagvalida == "1")
                    {
                        DialogResult res = RadMessageBox.Show(mensajeRetorno +  "¿Desea guardar?",
                                            "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (res == System.Windows.Forms.DialogResult.Yes)
                        {
                            //Con este flag salta la validacion
                            @FlagValida = "1";
                            //DocumentoLogic.Instance.InsertarDetalleMP(mov, Logueo.TipoCambio, Logueo.MonedaxDefecto, out flag, out mensajeRetorno);
                            DocumentoLogic.Instance.InsertarDetalleMP(mov, Logueo.TipoCambio, Logueo.MonedaxDefecto, out flag, out mensajeRetorno);
                            info.Cells["Orden"].Value = mov.Orden;
                            refrescarfila(flag, mensajeRetorno, mov.Orden, true);
                        }

                    }else { 
                        // si las medidas son correctas  al almacen ek cual se ingresar
                        DocumentoLogic.Instance.InsertarDetalleMP(mov, Logueo.TipoCambio, Logueo.MonedaxDefecto, out flag, out mensajeRetorno);
                        info.Cells["Orden"].Value = mov.Orden;
                        refrescarfila(flag, mensajeRetorno, mov.Orden, true);
                    }

                    
                }
                else
                {
                    
                    //EDITAR
                    mov.Orden = double.Parse(info.Cells["Orden"].Value.ToString());
                    string salidaFlagvalida = "";
                    DocumentoLogic.Instance.ValidarActualizarDetalleMP(mov, Logueo.TipoCambio, Logueo.MonedaxDefecto, @FlagValida, out salidaFlagvalida,
                                                                        out flag, out mensajeRetorno);

                    if (salidaFlagvalida == "1")
                    {
                        DialogResult res = RadMessageBox.Show(mensajeRetorno + "¿Desea actualizar?",
                                            "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (res == System.Windows.Forms.DialogResult.Yes)
                        {
                            //Con este flag salta la validacion
                            @FlagValida = "1";
                            DocumentoLogic.Instance.ActualizarDetalleMP(mov, Logueo.TipoCambio, Logueo.MonedaxDefecto, out flag, out mensajeRetorno);
                            
                            info.Cells["Orden"].Value = mov.Orden;
                            refrescarfila(flag, mensajeRetorno, mov.Orden, false);
                        }

                    } else {
                        DocumentoLogic.Instance.ActualizarDetalleMP(mov, Logueo.TipoCambio, Logueo.MonedaxDefecto, out flag, out mensajeRetorno);
                        
                        info.Cells["Orden"].Value = mov.Orden;
                        refrescarfila(flag, mensajeRetorno, mov.Orden, false);
                    }
                    
                    // Procesa, refresa y retonar mensaje de filla actual de la Grilla
                    
                }                                                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        private void refrescarfila(int cFlag, string cMensajeRetorno, double cOrden, bool esnuevo) {
            if (cFlag == -1)
            {
                RadMessageBox.Show(cMensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            else
            {
                CargarMovimiento();
                RadMessageBox.Show(cMensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                Util.enfocarFila(gridControl, "Orden", cOrden.ToString());
                gridControl.CurrentRow.Cells["flag"].Value = null;
                if (esnuevo == true) {
                    btnAddDetalle_Click(null, null);
                }
            }
        }
        #endregion
       
        #region Guardar
        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;

            if (this.txtCodigoTipDoc.Text == ""|| this.txtDesTipDoc.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Transaccion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodigoTipDoc.Focus();
                return false;
            }



            //if (this.txtDesTipDoc.Text.Trim() == "" || this.txtDesTipDoc.Text.Trim() == "???")
            //{
            //    RadMessageBox.Show("Transaccion No Valida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    this.txtCodigoTipDoc.Focus();
            //    return false;
            //}


            if ( this.txtCodTransa.Text == "" || this.txtDesTransa.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Transacción", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodTransa.Focus();
                return false;
            }

            //if (this.txtDesTransa.Text.Trim() == "" || )
            //{
            //    RadMessageBox.Show("Tipo Documento Respaldo No Valido", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    this.txtCodTransa.Focus();
            //    return false;
            //}

            if (this.txtCodProveedor.Enabled)
            {
                if (this.txtCodProveedor.Text == "" || txtDesProveedor.Text == "???")
                {
                    RadMessageBox.Show("Debe ingresar Proveedor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodProveedor.Focus();
                    return false;
                }
            }

            //if (this.txtCodProveedor.Enabled)
            //{
            //    if (this.txtCodProveedor.Text.Trim() == "" || this.txtDesProveedor.Text.Trim() == "???")
            //    {
            //        RadMessageBox.Show("Proveedor No Valido", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //        this.txtCodProveedor.Focus();
            //        return false;
            //    }
            //}

            //validacion de monea desactivado temporalmente el valor del control esta asignado por defecto es en Soles.
            //if (txtCodMoneda.Text == "" || txtDesMoneda.Text == "???")
            //{
            //    RadMessageBox.Show("Moneda No valida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    this.txtCodMoneda.Focus();
            //    return false;
            //}

            //if (this.txtDesMoneda.Text.Trim() == "" || this.txtDesMoneda.Text.Trim() == "???")
            //{
            //    RadMessageBox.Show("Debe ingresar Moneda", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    this.txtCodMoneda.Focus();
            //    return false;
            //}


            if (this.txtCodRepReceptor.Enabled)
            {
                if (this.txtCodRepReceptor.Text == "" || txtDesRespReceptor.Text == "???")
                {
                    RadMessageBox.Show("Debe ingresar Responsable receptor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodRepReceptor.Focus();
                    
                    return false;
                }
            }

            if (this.txtCodResponsable.Enabled)
            {
                if (this.txtCodResponsable.Text == "" || txtDesResponsable.Text == "???")
                {
                    RadMessageBox.Show("Debe ingresar Responsable entrega", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodResponsable.Focus();
                    return false;
                }
            }

            if (this.txtCodCentroCosto.Enabled)
            {
                if (this.txtCodCentroCosto.Text == "" || txtDesCentroCosto.Text == "???")
                {
                    RadMessageBox.Show("Debe ingresar Centro de costo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodCentroCosto.Focus();
                    return false;
                }
            }

            if (this.txtCodObra.Enabled)
            {
                if (this.txtCodObra.Text == "" || txtDesObra.Text == "???")
                {
                    RadMessageBox.Show("Debe ingresar Obra", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodObra.Focus();
                    return false;
                }
            }
            if (this.txtNotaSalida.Enabled)
            {
                if (this.txtNotaSalida.Text == "" || txtNotaSalidaDesc.Text == "???")
                {
                    RadMessageBox.Show("Debe ingresar Nota de salida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtNotaSalida.Focus();
                    return false;
                }
            }
            if (this.txtCodigoCantera.Enabled) 
            {
                if (this.txtCodigoCantera.Text== "" || txtDesCantera.Text == "???") 
                {
                    RadMessageBox.Show("Debe ingresar cantera", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodigoCantera.Focus();
                    return false;
                }
            }
            if (this.txtCodContratista.Enabled) {
                if (this.txtCodContratista.Text == "" || txtDesContratista.Text == "???") {
                    RadMessageBox.Show("Debe ingresar contratista", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodContratista.Focus();
                    return false;
                }
            }
            return true;
        }


        protected override void OnGuardar()
        {
            if (!Validar())
                return;

            string mensajeRetorno = string.Empty;
            try
            {
                string codigo = string.Empty;
                string transaccion = string.Empty;
                codigo = Logueo.CodigoEmpresa + this.txtCodigoTipDoc.Text;
                GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOCMOV", out transaccion);

                Documento documento = new Documento();
                documento.CodigoEmpresa = Logueo.CodigoEmpresa;
                documento.Anio = Logueo.Anio;
                documento.Mes = Logueo.Mes;

                documento.TipoDoc = this.txtCodigoTipDoc.Text;
                documento.CodigoDoc = this.txtNroDocumento.Text;

                documento.CodigoTransa = this.txtCodTransa.Text;
                documento.ReferenciaDoc = this.txtNroReferencia.Text;

                documento.Transaccion = transaccion;
                
                documento.FechaDoc = this.dtpFechaDoc.Value;
                documento.CodigoProveedor = this.txtCodProveedor.Text;

                //Fecha documento
                documento.Moneda = Logueo.MonedaxDefecto;
                documento.ResponsableReceptor = this.txtCodRepReceptor.Text;
                documento.Responsable = this.txtCodResponsable.Text;
                documento.CodigoCentroCosto = this.txtCodCentroCosto.Text;
                documento.CodigoObra = this.txtCodObra.Text;

                //Tipo de cambio
                documento.TipoCambio = Logueo.TipoCambio;
                documento.IN06CANTERACOD = this.txtCodigoCantera.Text.Trim();
                documento.IN06CONTRATISTACOD = this.txtCodContratista.Text.Trim();
                documento.IN06DOCRESCTACTETIPANA = txtTipoAnalisis.Text;
                documento.IN06DOCRESCTACTENUMERO = txtCodProveedor.Text;                                
                
                documento.IN06PRODNATURALEZA = Logueo.MP_codnaturaleza;
                
                // Capturo los datos del documento de salida
                if (txtNotaSalida.Text != "")
                {
                    documento.IN06NOTASALIDAAA = txtNotaSalida.Text.Substring(0, 4);
                    documento.IN06NOTASALIDAMM = txtNotaSalida.Text.Substring(4, 2);
                    documento.IN06NOTASALIDATIPDOC = txtNotaSalida.Text.Substring(6, 2);
                    documento.IN06NOTASALIDACODDOC = txtNotaSalida.Text.Substring(8, (txtNotaSalida.Text.Length - 8));
                }
                documento.OrigenTipo = Logueo.OrigenTipo_manual;
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    string nroDocumentoRetorno = string.Empty;
                    DocumentoLogic.Instance.InsertarDocumentoMP(documento, out nroDocumentoRetorno, out mensajeRetorno);

                    if (nroDocumentoRetorno != "") {
                        this.txtNroDocumento.Text = nroDocumentoRetorno;
                        Habilitar(false);
                        btnAddDetalle.Visible = true;
                        this.Estado = FormEstate.Edit;
                        CargarMovimiento();
                    }
                    

                    //RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    //MODIFICA
                    DocumentoLogic.Instance.ActualizarDocumentoMP(documento, out mensajeRetorno);
                }

                RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                FrmParent.Listar();
            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar el documento", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #endregion

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            // la variabel Orden es para saber si esta guatdaddo la cabecera del docuemnto

            if (this.Estado == FormEstate.View) return;
            if (this.gridControl.RowCount == 0) return;
            if (e.KeyValue == (char)Keys.Enter)
            {
                gridControl.Focus();
                Util.SendTab(Keys.Enter.GetHashCode());
            }
            

            //F1-Pedido de venta
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["CodigoArticulo"].ColumnInfo.Index)
            {
                if (gridControl.CurrentRow.Cells["CodigoAlmacen"] == null || gridControl.CurrentRow.Cells["CodigoAlmacen"].Value == null)
                {
                    RadMessageBox.Show("Seleccionar almacen", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                else {
                    this._codigoAlmacenSeleccionado = this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                }
                
                if (e.KeyCode == Keys.F1)
                {
                    if (this.gridControl.CurrentRow.Cells["flag"].Value.ToString() == "0")
                        this.MostrarAyuda(enmAyuda.enmProductoXAlmacenIng);                                    
                }
            }

           //F1 -- Almacen
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["CodigoAlmacen"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)                 
                    if (this.gridControl.CurrentRow.Cells["flag"].Value.ToString() == "0")                     
                        this.MostrarAyuda(enmAyuda.enmAlmacen);
            }
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["DesMotivo"].ColumnInfo.Index)    
            {
                if (e.KeyCode == Keys.F1)
                    if (this.gridControl.CurrentRow.Cells["flag"].Value != null)
                        if(this.gridControl.CurrentRow.Cells["flag"].Value.ToString() == "0")
                            this.MostrarAyuda(enmAyuda.enmMotivo);
            }                                               
        }

        #region Seleccionar Código: Temporal

        //private void gridAyuda_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        this.gridAyuda.Visible = false;
        //        return;
        //    }

        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        SeleccionarAyuda();
        //    }
        //}

        //private void gridAyuda_DoubleClick(object sender, EventArgs e)
        //{
        //    SeleccionarAyuda();
        //}

      /*  private void SeleccionarAyuda()
        {
            if (this.gridAyuda.RowCount == 0) return;
            this.Result = string.Empty;

            switch (this._tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
                    this.txtCodigoTipDoc.Text = this.gridAyuda.CurrentRow.Cells["Codigo"].Value.ToString();
                    this.txtCodigoTipDoc.Focus();
                    this.gridAyuda.Visible = false;
                    break;
                case enmAyuda.enmTransaccion:
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmProveedor:
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmPedido:
                    break;
                case enmAyuda.enmCliente:
                    break;
                case enmAyuda.enmCentroCosto:
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmResponsableReceptor:
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmResponsable:
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmObra:
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                case enmAyuda.enmMaquina:
                    break;
                case enmAyuda.enmLote:
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    this.Result = this.gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
                    break;
                default:
                    break;
            }


        }*/
        #endregion

        #region Impresion
        protected override void OnVista()
        {
            string mensajeOut = string.Empty;

            GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
            var datos = DocumentoLogic.Instance.ReporteDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "sqlrepdocumentos.rpt";
            reporte.DataSource = datos;
            reporte.FormulasFields.Add(new Formula("Ano", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("Mes", Logueo.Mes));
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

            //reporte.ParametersFields.Add(new Paramentro("@CodEmp", Logueo.CodigoEmpresa));
            //reporte.ParametersFields.Add(new Paramentro("@Ano", Logueo.Anio));
            //reporte.ParametersFields.Add(new Paramentro("@Mes", Logueo.Mes));

            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);
            GlobalLogic.Instance.EliminarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, out mensajeOut);
        }

        protected override void OnImprimir()
        {
            var datos = DocumentoLogic.Instance.ReporteDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "documentosal.Rpt";
            reporte.DataSource = datos;
            reporte.FormulasFields.Add(new Formula("Ano", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("Mes", Logueo.Mes));
            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));

            ReporteControladora control = new ReporteControladora(reporte);
            control.Imprimir();
        }


        #endregion

        private void txtNotaSalida_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmNotaSalida);
        }


        private void dtpFechaDoc_KeyUp(object sender, KeyEventArgs e)
        {

            //if (e.KeyValue == (char)Keys.Enter)
            //{
            //    this.txtCodTransa.Focus();
            //}
            //if (e.KeyValue == (char)Keys.Up)
            //{
            //    SendKeys.Send("+{TAB}");
            //}

            //if (e.KeyValue == (char)Keys.Down)
            //{
            //    this.txtCodTransa.Focus();
            //}


        }

        private void btnAddDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddDetalle_Click(null, null);
            }
        }

        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            GridViewRowInfo info = this.gridControl.CurrentRow;
            if (e.Column.Name == "CodigoAlmacen")
            {
                ObtenerDescripcion(enmAyuda.enmAlmacen, Util.convertiracadena(e.Row.Cells["CodigoAlmacen"].Value));
            }
            if (Estado == FormEstate.Edit)
            {

                //if (info.Cells[0].Tag == null)
                //{
                //    if (e.Column.Name == "IN07PROVMATPRIMA" || e.Column.Name == "IN07CODCLI" || e.Column.Name == "NroPedidoVenta" || e.Column.Name == "NroCaja")
                //    {
                       
                //    }
                //}
            }

        }

        protected void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;
            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                if (Estado == FormEstate.View) // desactivamos todos los botones de mantenimiento de la grilla
                {
                    //CodigoAlmacen
                    if (e.Column.Name == "btnGrabar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }

                    if (e.Column.Name == "btnCancelar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }

                    if (e.Column.Name == "btnEliminar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnEditar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    return;
                }
                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value.ToString() != "0" && gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                { // si el registro existe activamos los botones de eliminar y editar
                    if (e.Column.Name == "btnGrabar")
                    {

                        cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnCancelar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnEliminar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.deleted_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }
                    if (e.Column.Name == "btnEditar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.edited_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }
                    //button.ButtonFillElement.BackColor = Color.LightGray;
                    //button.ButtonFillElement.GradientStyle = GradientStyles.Solid;

                }
                else
                { // si es un registro nuevo entonces activamos el boton cancelar y grabar
                    if (e.Column.Name == "btnGrabar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.save_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }
                    if (e.Column.Name == "btnCancelar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.cancel_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }
                    if (e.Column.Name == "btnEliminar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnEditar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }

                }

            }
           

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                
               
               
                

            }


        }
        private void eliminarRegistroGrilla()
        {
            try
            {
                if (this.gridControl.RowCount == 0)
                    return;

                DialogResult dialog = RadMessageBox.Show("Está seguro de eliminar Item seleccionado?", "Aviso",
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.No)
                    return;

                GridViewRowInfo rowInfo = this.gridControl.CurrentRow;
                if (double.Parse(rowInfo.Cells["Orden"].Value.ToString()) > 0)
                {
                    string mensajeRetorno = string.Empty;
                    string codigo = string.Empty;
                    string transaccion = string.Empty;
                    codigo = Logueo.CodigoEmpresa + this.txtCodigoTipDoc.Text;
                    GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOCMOV", out transaccion);

                    DocumentoLogic.Instance.EliminarDetalleMP(Logueo.CodigoEmpresa, Logueo.Anio,
                        Logueo.Mes, this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text,
                        transaccion, string.Format("{0:yyyyMMdd}", this.dtpFechaDoc.Value),
                        Logueo.TipoCambio, this.txtCodMoneda.Text,
                        rowInfo.Cells["CodigoAlmacen"].Value.ToString(), rowInfo.Cells["CodigoArticulo"].Value.ToString(),
                        rowInfo.Cells["UnidadMedida"].Value.ToString(),
                        double.Parse(rowInfo.Cells["Cantidad"].Value.ToString()),
                        0, double.Parse(rowInfo.Cells["Orden"].Value.ToString()), out mensajeRetorno);
                }
                this.gridControl.Rows.Remove(this.gridControl.CurrentRow);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private RadButtonElement buscarBoton(string nombreBoton)
        {
            GridViewRowInfo currentRow = this.gridControl.CurrentRow;
            GridViewCellInfo celda1 = currentRow.Cells[nombreBoton];
            currentRow.EnsureVisible();
            GridCellElement cellElement1 = gridControl.TableElement.GetCellElement(celda1.RowInfo, celda1.ColumnInfo);
            RadButtonElement boton = (RadButtonElement)cellElement1.Children[0];
            return boton;
        }
        private void gridControl_removeFocusButton()
        {
            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                GridViewCellInfo celda1 = row.Cells["btnGrabar"];
                GridViewCellInfo celda2 = row.Cells["btnCancelar"];
                GridViewCellInfo celda3 = row.Cells["btnEliminar"];
                GridViewCellInfo celda4 = row.Cells["btnEditar"];
                GridCellElement cellElement1 = gridControl.TableElement.GetCellElement(celda1.RowInfo, celda1.ColumnInfo);
                GridCellElement cellElement2 = gridControl.TableElement.GetCellElement(celda2.RowInfo, celda2.ColumnInfo);
                GridCellElement cellElement3 = gridControl.TableElement.GetCellElement(celda3.RowInfo, celda3.ColumnInfo);
                GridCellElement cellElement4 = gridControl.TableElement.GetCellElement(celda4.RowInfo, celda4.ColumnInfo);
                RadButtonElement boton1 = (RadButtonElement)cellElement1.Children[0];
                boton1.IsMouseOver = false;

                RadButtonElement boton2 = (RadButtonElement)cellElement2.Children[0];
                boton2.IsMouseOver = false;

                RadButtonElement boton3 = (RadButtonElement)cellElement3.Children[0];
                boton3.IsMouseOver = false;

                RadButtonElement boton4 = (RadButtonElement)cellElement3.Children[0];
                boton4.IsMouseOver = false;
            }
        }
        private void gridControl_KeyUp(object sender, KeyEventArgs e)
        {          
            try
            {
                this.gridControl.Focus();
                if (e.KeyCode == Keys.Enter) {
                    Util.SendTab(Keys.Enter.GetHashCode());
                }
            }
            catch (Exception ex) {             
            }
        }
        private void gridControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

          
            try
            {
                if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["AltoCan"].ColumnInfo.Index)
                {
                    
                    if (e.KeyCode == Keys.Enter)
                    {
                        //Util.SendTab(Keys.Enter.GetHashCode()); Util.SendTab(Keys.Enter.GetHashCode());
                        //Util.SendTab(Keys.Enter.GetHashCode()); Util.SendTab(Keys.Enter.GetHashCode());
                        this.gridControl.CurrentColumn = this.gridControl.Columns["btnEditar"];
                        this.gridControl.CurrentCell.IsCurrent = true;
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        //Util.SendTab(Keys.Enter.GetHashCode()); Util.SendTab(Keys.Enter.GetHashCode());
                        //Util.SendTab(Keys.Enter.GetHashCode());
                        this.gridControl.CurrentColumn = this.gridControl.Columns["btnEditar"];
                        this.gridControl.CurrentCell.IsCurrent = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
           

        }
      

        private void txtCodContratista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) 
            {
                MostrarAyuda(enmAyuda.enmContratista);
            }            
        }

        private void txtCodigoCantera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) 
            {
                MostrarAyuda(enmAyuda.enmCantera);
            }            
        }

        private void txtCodContratista_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmContratista, this.txtCodContratista.Text);
        }

        private void txtCodigoCantera_TextChanged(object sender, EventArgs e)
        {
            ObtenerDescripcion(enmAyuda.enmCanterasxContratista, this.txtCodigoCantera.Text);
        }
        void editarRegistroGrilla() {
            this.gridControl.CurrentRow.Cells["flag"].Value = "0";
            string orden = gridControl.CurrentRow.Cells["Orden"].Value.ToString();
            
            Util.enfocarFila(gridControl, "Orden", orden);
            //Resaltar celda de Color : Amarillo
            Util.ResaltarAyuda(this.gridControl.CurrentRow.Cells["CodigoArticulo"]);
        }
        void cancelarRegistroGrilla() {
            Movimiento mov = new Movimiento();
            mov.Orden = double.Parse(this.gridControl.CurrentRow.Cells["orden"].Value.ToString());   
            CargarMovimiento();
            Util.enfocarFila(gridControl, "orden", mov.Orden.ToString());
            
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
                       
            if (this.gridControl.Columns["btnGrabar"].IsCurrent)
            {
                this.GuardarDetalle(gridControl.CurrentRow);                
            }

            if (this.gridControl.Columns["btnCancelar"].IsCurrent) 
            {
                cancelarRegistroGrilla();                
            }

            if (this.gridControl.Columns["btnEliminar"].IsCurrent) 
            {
                this.eliminarRegistroGrilla();                
            }

            if (this.gridControl.Columns["btnEditar"].IsCurrent) 
            {
                 this.editarRegistroGrilla();                    
            }
        }

        private void gridControl_SelectionChanged(object sender, EventArgs e)
        {
            //if (this.gridControl.CurrentRow != null)
          

        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            //if (gridControl.CurrentRow == null) return;

            //gridControl_removeFocusButton();
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if (e.CurrentRow == null) return;
                if (e.CurrentRow.Cells["Orden"] == null) return;
                if (e.CurrentRow.Cells["flag"] == null) return;
                if (this.gridControl.CurrentRow.Cells["flag"].Value.ToString() == "0")
                {
                    RadMessageBox.Show("Completar registro", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { 
            
            }
            
        }

        private void gridControl_RowValidating(object sender, RowValidatingEventArgs e)
        {           
        }

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

        }
        private void txtCodLinea_TextChanged(object sender, EventArgs e)
        {
            if (txtCodLinea.Text.Trim() != "")
            {
                ObtenerDescripcion(enmAyuda.enmLinea, txtCodLinea.Text.Trim());
            }
        }
        private void txtCodProceso_TextChanged(object sender, EventArgs e)
        {
            if (txtCodProceso.Text.Trim() != "")
            {
                ObtenerDescripcion(enmAyuda.enmActividadNivel1, txtCodLinea.Text.Trim() + txtCodProceso.Text.Trim());
            }
        }

        private void txtCodTurno_TextChanged(object sender, EventArgs e)
        {
            if (txtCodTurno.Text.Trim() != "")
            {
                ObtenerDescripcion(enmAyuda.enmTurnos, txtCodTurno.Text.Trim());
            }
        }

        private void txtCodLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmLinea);
            }

        }

        private void txtCodProceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmActividadNivel1);
            }

        }

        private void txtCodTurno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmTurnos);
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

        private void gridOrdenTrabajo_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;
                if (Estado == FormEstate.View)
                {
                    if (e.Column.Name == "btnGrabarOT")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnCancelarOT")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.cancel_disabled2;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnEliminarOT")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnEditarOT")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    return;
                }
              
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {
                    RadButtonElement button = (RadButtonElement)e.CellElement.Children[0];
                    RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                    if (gridOrdenTrabajo.Rows[e.RowIndex].Cells["flag"].Value == null)
                    {
                        if (e.Column.Name == "btnGrabarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = false;
                        }
                        if (e.Column.Name == "btnCancelarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.cancel_disabled2;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = false;
                        }
                        if (e.Column.Name == "btnEliminarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.deleted_enabled;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = true;
                        }
                        if (e.Column.Name == "btnEditarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.edited_enabled;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = true;
                        }


                    }
                    else
                    {
                        if (e.Column.Name == "btnGrabarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.save_enabled;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = true;
                        }
                        if (e.Column.Name == "btnCancelarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.cancel_enabled;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = true;
                        }
                        if (e.Column.Name == "btnEliminarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = false;
                        }
                        if (e.Column.Name == "btnEditarOT")
                        {
                            cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                            cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                            cellElement.CommandButton.Enabled = false;
                        }
                    }
                }


                //botonesGrilla(e);
            }
            catch (Exception ex)
            {

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

            if (this.gridOrdenTrabajo.Columns["btnEliminarOT"].IsCurrent)
            {
                EliminarOrdenTrabajo();
                CargarOrdenTrabajo();

                return;
            }

            if (this.gridOrdenTrabajo.Columns["btnEditarOT"].IsCurrent)
            {
                EditarOrdenTrabajo();
                return;
            }
        }

        private void gridOrdenTrabajo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (gridOrdenTrabajo.Rows.Count == 0) // limpiarmos el numero de orden de trabajo si no tenemos ningun registro en la grilla OT
                {
                    lblnroOT.Text = "";
                    return;
                }
                if (e.CurrentRow != null)
                {
                    if (e.CurrentRow.Cells["codigo"] != null)
                    {
                        if (e.CurrentRow.Cells["codigo"].Value != null)
                        {
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
                                cargarMateriaPrima();
                                btnAddMateria.Enabled = true;
                            }

                        }
                        else
                        {
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
        void cargarProductosDet()
        {
            try
            {
                string ordenTrabajo = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                var lista = DocumentoLogic.Instance.TraerProduccionDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                                                                            txtCodigoTipDoc.Text.Trim(),
                                                                            txtNroDocumento.Text.Trim(), ordenTrabajo);
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {

            }

        }


        private void gridOrdenTrabajo_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridOrdenTrabajo.SelectedRows.Count > 0)
            {

                if (e.KeyValue == (char)Keys.F1)
                {
                    if (this.gridOrdenTrabajo.CurrentRow.Cells["flag"].Value == null) return;


                    //if (this.gridOrdenTrabajo.CurrentColumn.Index == this.gridOrdenTrabajo.CurrentRow.Cells["codigoProducto"].ColumnInfo.Index)
                    //{
                    //    mostrarAyuda(enmAyuda.enmProducObjetivo);
                    //}
                    if (this.gridOrdenTrabajo.CurrentColumn.Index == this.gridOrdenTrabajo.CurrentRow.Cells["productoObjetivo"].ColumnInfo.Index)
                    {
                        MostrarAyuda(enmAyuda.enmProducObjetivo);

                    }
                }
            }
        }

        private void gridMateriaPrima_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;
            if (Estado == FormEstate.View)
            {
                if (e.Column.Name == "btnEliminarMat")
                {
                    cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                }
                return;
            }
            if (e.Column.Name == "btnEliminarMat")
            {
                cellElement.CommandButton.Image = Properties.Resources.remove;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
            }
        }

        private void gridMateriaPrima_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.Cells["CodigoAlmacen"].Value != null)
            {
                string descripcion = string.Empty;
                string codigo = Logueo.CodigoEmpresa + e.Row.Cells["CodigoAlmacen"].Value.ToString();
                GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                e.Row.Cells["AlmacenDesc"].Value = descripcion;

            }
        }

        private void gridMateriaPrima_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridMateriaPrima.Columns["btnEliminarMat"].IsCurrent)
            {
                EliminarMateriaPrima();
            }
        }

        private void gridMateriaPrima_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (e.CurrentRow == null) return;
                if (e.CurrentRow.Cells["NroCaja"] != null)
                {
                    if (e.CurrentRow.Cells["NroCaja"].Value != null)
                    {
                        string tipDoc = txtCodigoTipDoc.Text.Trim();
                        string codDoc = txtNroDocumento.Text.Trim();
                        string orden = this.gridOrdenTrabajo.CurrentRow.Cells["codigo"].Value.ToString();
                        string nroCaja = this.gridMateriaPrima.CurrentRow.Cells["NroCaja"].Value.ToString();

                        var mp = DocumentoLogic.Instance.TraerMateriaPrimaRegistro(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipDoc, codDoc, orden, nroCaja);
                        if (mp.NroCaja == null)
                        {
                            btnAddDetalle.Enabled = false;
                            gridControl.Rows.Clear();
                        }
                        else
                        {

                            btnAddDetalle.Enabled = true;
                            cargarProductosDet();
                        }

                    }
                    else
                    {
                        cargarProductosDet();
                        btnAddDetalle.Enabled = false;
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }

        private void gridMateriaPrima_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {

        }

        private void gridMateriaPrima_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                if (Estado == FormEstate.View || Estado == FormEstate.List) return;
                if (this.gridMateriaPrima.CurrentColumn.Index == gridMateriaPrima.CurrentRow.Cells["NroCaja"].ColumnInfo.Index)
                {
                    MostrarAyuda(enmAyuda.enmCanastillasMultiple);
                }
                else
                    if (this.gridMateriaPrima.CurrentColumn.Index == gridMateriaPrima.CurrentRow.Cells["CodigoAlmacen"].ColumnInfo.Index)
                    {
                        MostrarAyuda(enmAyuda.enmAlmacen);
                    }

            }
        }

        private void btnAddOT_Click(object sender, EventArgs e)
        {

            string codigo = string.Empty;
            //if (!txtCodLinea.Enabled) return;
            //var documento = DocumentoLogic.Instance.ObtenerDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
            //                                                          txtTipoDocumento.Text.Trim(), txtNroDocumento.Text.Trim());

            //if (documento == null) {
            //    RadMessageBox.Show("Primero debe registrar el documento", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            //    return;
            //}
            if (!txtCodProceso.Enabled)
            {
                RadMessageBox.Show("Para registrar una Orden de Trabajo debe ingresar proceso", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            if (txtCodProceso.Text.Trim() == "" || txtDesProceso.Text == "???")
            {
                RadMessageBox.Show("Para registrar una Orden de Trabajo debe ingresar proceso", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            OrdenTrabajoLogic.Instance.TraerNumeroOT(Logueo.CodigoEmpresa, out codigo);

            if (gridOrdenTrabajo.Rows.Count == 0)
            {

                GridViewRowInfo rowInfo = gridOrdenTrabajo.Rows.AddNew();
                rowInfo.Cells["codigo"].Value = codigo;
                rowInfo.Cells["flag"].Value = "0";
                Util.ResaltarAyuda(rowInfo.Cells["productoObjetivo"]);
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
                    RadMessageBox.Show("Completar el registro actual", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                GridViewRowInfo rowInfo = gridOrdenTrabajo.Rows.AddNew();
                rowInfo.Cells["codigo"].Value = codigo;
                rowInfo.Cells["flag"].Value = "0";
                Util.ResaltarAyuda(rowInfo.Cells["productoObjetivo"]);

            }
            gridOrdenTrabajo.Focus();
            SendKeys.Send("{TAB}");
        }

        private void btnAddMateria_Click(object sender, EventArgs e)
        {
            try
            {

                if (gridMateriaPrima.Rows.Count > 0)
                {
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
                this.gridMateriaPrima.CurrentColumn = this.gridMateriaPrima.Columns["NroCaja"];

                //Traer el alamcen por defectro
                var almacen = ActividadNivel1Logic.Instance.ActividadNivel1TraerRegistro(Logueo.CodigoEmpresa, txtCodLinea.Text.Trim(), txtCodProceso.Text.Trim()).almacenMP;
                this.gridMateriaPrima.CurrentRow.Cells["codigoAlmacen"].Value = almacen;
                
                //Resaltar celdas de ayuda 
                Util.ResaltarAyuda(this.gridMateriaPrima.CurrentRow.Cells["NroCaja"]);
                Util.ResaltarAyuda(this.gridMateriaPrima.CurrentRow.Cells["codigoAlmacen"]);

            }
            catch (Exception ex)
            {

            }
        }

        private void txtCodigoCantera_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       

    }
}
