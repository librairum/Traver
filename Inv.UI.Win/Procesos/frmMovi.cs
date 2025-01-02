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
using Inv.BusinessEntities.DTO;
namespace Inv.UI.Win
{
        public partial class frmMovi : frmBaseReg
    {
        private bool isLoaded = false;
        private bool isOpened = false;

        private string tipoDocumento = string.Empty;
        private string nroDocumento = string.Empty;

        private bool esEntrada = false;
        public string _eCodigo { get; set; }

        private enmAyuda _tipoAyuda;
        //variable orgniza los grupos de las cabeceras de la grilla
        ColumnGroupsViewDefinition columnGroupsView;
        private string _codigoAlmacenSeleccionado = string.Empty;
        private string _PedidoVentaSeleccionado = string.Empty;

            public  int fila = 0;
            
            private frmDocu FrmParent { get; set; }

            CommandBarStripElement menu;
            RadCommandBarBaseItem cbbGuardar;
            private static frmMovi _aForm;
                    
            OrdenTrabajo orden = new OrdenTrabajo();

            public static frmMovi Instance(frmDocu mdiPrincipal)
            {
                if (_aForm != null) return new frmMovi(mdiPrincipal);
                _aForm = new frmMovi(mdiPrincipal);
                return _aForm;
            }
            //constructor para indicar el padre del formulario documento
            public frmMovi(frmDocu padre)
            {
                InitializeComponent();
                FrmParent = padre;
                //obtenemos el numero de documento                                
                Control ctrl = FrmParent.ParentForm.Controls.Find("radDock1", true)[0];
                // Iniciar el formulario modal de Stock Linea
                this.gridStockLinea.SendToBack();
                CrearColumnasStockLinea();
                Estado = FrmParent.Estado;

                if (Estado == FormEstate.New )
                {
                    fila = 0;
                }                
                else if (Estado == FormEstate.List || Estado == FormEstate.View || Estado == FormEstate.Edit) 
                {
                    nroDocumento = FrmParent.gridControl.CurrentRow.Cells["CodigoDoc"].Value.ToString();
                    tipoDocumento = FrmParent.gridControl.CurrentRow.Cells["TipoDoc"].Value.ToString();
                    fila = FrmParent.gridControl.CurrentRow.Index;
                }
                
                esEntrada = FrmParent.rbEntradas.IsChecked;
                                                                
                //metodos del frmMovi
                CrearColumnas();             
                crearGrupos();
                CargarCombos();
                menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
                cbbGuardar = menu.Items["cbbGuardar"];

                removerBordesdepaneles();

                this.MdiParent = FrmParent.ParentForm;
                ((RadDock)(ctrl)).ActivateMdiChild(this);
                //isLoaded = true;
            }
            /// <summary>
            /// metodo para agregar boton(grabar,editar,eliminar a la grilla del documento
            /// </summary>
            void agregarBoton() {
                
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
                
            }
            /// <summary>
            /// Metodo para usar al iniciar el formulario (unco uso) para remover border algunos paneles
            /// </summary>
            void removerBordesdepaneles() {
                this.rpDocRespaldo.PanelElement.PanelBorder.TopWidth = 0;
                this.rpMenuDetalle.PanelElement.PanelBorder.TopWidth = 0;                
                this.pnlCabecera.PanelElement.PanelBorder.TopWidth = 0;
                this.rpTransaccionAdiccional.PanelElement.PanelBorder.TopWidth = 0;              
                this.rpDocRespaldo.PanelElement.PanelBorder.Visibility = ElementVisibility.Hidden;
                this.rpTransaccionAdiccional.PanelElement.PanelBorder.Visibility = ElementVisibility.Hidden;
                
            }
            
            /// <summary>
            /// enfocar el registro segun el valor de la variable fila
            /// </summary>
            void enfocarregistro()
            {                
                FrmParent.gridControl.MasterView.Rows[fila].IsCurrent = true;
                FrmParent.gridControl.MasterView.Rows[fila].IsSelected = true;                
            }

            /// <summary>
            ///  metodo para asginar valores de la fila actual seleccionado
            /// </summary>
 
            void asignarValores()
            {
                //asigno los valores de la fila actual seleccionado

                nroDocumento = FrmParent.gridControl.MasterView.Rows[fila].Cells["CodigoDoc"].Value.ToString();
                tipoDocumento = FrmParent.gridControl.MasterView.Rows[fila].Cells["TipoDoc"].Value.ToString();
                txtNroDocumento.Text = FrmParent.gridControl.MasterView.Rows[fila].Cells["CodigoDoc"].Value.ToString();
                //cargo el resto de datos del dcoumneto por medio del codigo del documento.
                CargarDocumento();
                CargarMovimiento();
                _eCodigo = nroDocumento;

                Habilitar(false);
                //resalto el registro actual
                enfocarregistro();
            }
            /// <summary>
            /// Metodo para bloquear controles ocultos (cajas de texto) 
            /// </summary>
            private void BloquearControlesOcultos()
            {
                txtCodCliente.Enabled = false;
                txtCodCliente.Visible = false;
                txtCodCliente.TabStop = false;

                txtLote.Enabled = false;
                txtLote.TabStop = false;
                txtLote.Visible = false;

                txtCodMaquina.Enabled = false;
                txtCodMaquina.TabStop = false;
                txtCodMaquina.Visible = false;

                txtDesMaquina.Enabled = false;
                txtDesMaquina.TabStop = false;
                txtDesMaquina.Visible = false;                

                txtTipoDocumento.Enabled = false;
                txtTipoDocumento.TabStop = false;
                txtTipoDocumento.Visible = false;

                     
            }
            /// <summary>
            /// Metodo de navegacion para ir al primer registro de nuestros documentos
            /// </summary>
            protected override void OnPrimero()
            {
                fila = 0;
                asignarValores(); 
            }
            /// <summary>
            /// Metodo de navegacion para ir al siguiente registro de nuestros documentos
            /// </summary>
            protected override void OnSiguiente()
            {
                if (fila == FrmParent.gridControl.MasterView.Rows.Count - 1 
                    || fila == FrmParent.gridControl.MasterView.ChildRows.Count - 1)
                    return;
                fila++;
                asignarValores();
            }
            /// <summary>
            /// Metodo de navegacion para ir al anterior registros de nuestros documento
            /// </summary>
            protected override void OnAnterior()
            {                
                if (fila == 0)
                    return;
                fila--;
                asignarValores(); 
            }
            /// <summary>
            /// Metodo de navegacion para ir al ultimo registro de nuestors documentos
            /// </summary>
            protected override void OnUltimo()
            {
                fila = FrmParent.gridControl.MasterView.Rows.Count - 1;                
                asignarValores();    
              
            }
        

            private void frmMovi_Load(object sender, EventArgs e)
            {
                    if (this.Estado == FormEstate.New)
                    {
                        InicializarNuevo();
                        this.HabilitarBotones(true, true, false, false,false); 
                
                        this.gridControl.Columns["btnGrabar"].IsVisible = true;                
                        this.gridControl.Columns["btnCancelar"].IsVisible = true;                                
                        this.gridControl.Columns["btnEliminar"].IsVisible = true;                
                
                    }
                    else if(this.Estado == FormEstate.Edit)
                    {
                
                        isLoaded = true;

                        //cargar detalle, orden de trabajo y materia prima
                        CargarDocumento();                
                
                        //habilitar controles del documento
                        Habilitar(false);
                
                        //                                
                        this.dtpFechaDoc.Enabled = true;
                        this.txtCodTransa.Enabled = true;
                        this.txtNroReferencia.Enabled = true;
                        this.txtCodMoneda.Enabled = true;
                        this.txtCodProveedor.Enabled = true;

                        txtCodTransa.Focus();

                        this.HabilitarBotones(true,true,false,false,false);

                        this.gridControl.Columns["btnGrabar"].IsVisible = true;
                        this.gridControl.Columns["btnCancelar"].IsVisible = true;
                        this.gridControl.Columns["btnEliminar"].IsVisible = true;
                        ConfigurarDocumento(this.txtCodigoTipDoc.Text.Trim());
                
                    }
                    else if (this.Estado == FormEstate.View) {
                
                
                        isLoaded = true;
                        //cargar detalle, orden de trabajo y materia prima
                        CargarDocumento();                

                        //habilitar controles del documento
                        Habilitar(false);
                
                        //deshabilito control de Fecha del documento
                        this.dtpFechaDoc.Enabled = false;
                        //Habilitar controles de region de produccion del documento                                
                        this.txtCodTransa.Enabled = false;
                        this.txtCodProveedor.Enabled = false;
                
                        //configura los botones para el mantenimiento del formulario.
                        this.HabilitarBotones(false, true, false, false, true);   
                             
                    }
                    this.CargarMovimiento();
                    isLoaded = true;

        }            
            /// <summary>
            /// Metodo para iniciar un nuevo documento solo cabecera
            /// </summary>
        private void InicializarNuevo()
        {
            BloquearControlesOcultos();
            BloquearIngresoDatos();
            this.dtpFechaDoc.Value = DateTime.Now;                       
            this.txtCodigoTipDoc.Focus();
            this.txtTipoAnalisis.Text = "";
            //Ocultar el boton de agregar detalle al iniciar un nuevo documento
            btnAddDetalle.Visible = false;
            btnIngProduccion.Visible = false;

        }

            /// <summary>
            /// Bloquear datos (cajas de datos) de la acebecera del documento
            /// </summary>
        private void BloquearIngresoDatos()
        {
            //bloqyue controles (cajas texto de la cabecera)
            this.txtCodProveedor.Enabled = false;
            this.txtCodCliente.Enabled = false;
            this.txtCodCentroCosto.Enabled = false;
            this.txtCodResponsable.Enabled = false;
            this.txtCodRepReceptor.Enabled = false;
            this.txtCodObra.Enabled = false;
            this.txtCodMaquina.Enabled = false;
            this.txtLote.Enabled = false;
            this.txtNotaSalida.Enabled = false;                                                
        }
            /// <summary>
            /// Habilitar controles(cajas de texto) de la cabecera del documento
            /// </summary>
            /// <param name="flag">true  para habilitar y false para deshabilitar </param>
        public void Habilitar(bool flag)
        {            
            this.txtCodigoTipDoc.Enabled = flag;
            this.txtNroDocumento.Enabled = flag;            
            this.txtCodMoneda.Enabled = flag;
            this.txtNroReferencia.Enabled = flag;
            this.txtCodProveedor.Enabled = flag;
            this.txtTipoDocumento.Enabled = flag;
            this.txtNroReferencia.Enabled = flag;
        }
            /// <summary>
            /// Cargar datos en cabecera del documento
            /// </summary>
        private void CargarDocumento()
        {
            //Cargar datos en la cebecera del documento
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
                
                this.ObtenerDescripcion(enmAyuda.enmProveedor, this.txtCodProveedor.Text);
                
                
            }
        }
        
            
         /// <summary>
        ///Crear Columnas para grilla de detalle (la grilla de abajo)
        /// </summary>
        private void CrearColumnas()
        {
            //this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            var lista = AlmacenLogic.Instance.ObtenerListItems1(Logueo.CodigoEmpresa);
            
            RadGridView grilla = this.CreateGridVista(this.gridControl);

            grilla.AutoGenerateColumns = false;
            // Datos del pedido de venta cuando es ingreso
            
            this.CreateGridColumn(grilla, "PedVen Numero", "in07pedvennum", 0, "", 100, true, true, true);
            this.CreateGridColumn(grilla, "PedVen Item", "in07pedvenitem", 0, "", 100, true, false, false);
            
            
            this.CreateGridColumn(grilla, "Cod Prov Mat Prima", "IN07PROVMATPRIMA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "OT", "IN07ORDENTRABAJO", 0, "", 50, true, false, true);
            //this.CreateGridColumn(grilla, "Canast.Ing", "IN07NROCAJAINGRESO", 0, "", 60, false, true);  // reemplazado por Orden Trabajo
            
            this.CreateGridColumn(grilla, "Prov.Materia Prima", "ProvMatPrimaNombre", 0, "", 90 , true, false, true);
            //oculto
            this.CreateGridColumn(grilla, "MP.Calidad", "IN07CALIDADMP", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Codcli", "IN07CODCLI", 0, "", 150,true,false,false);
            
            this.CreateGridColumn(grilla, "Cliente", "ClienteNombre", 0, "", 90);            
            //oculto
            this.CreateGridColumn(grilla, "Orden", "OrdenProduccion", 0, "", 150, false, true, false);
            this.CreateGridColumn(grilla, "Nro", "NroPedidoVenta", 0, "", 50, false, true, true);
            this.CreateGridColumn(grilla, "Nro Caja", "NroCaja", 0, "", 65, false, true, true);
            
            this.CreateGridColumn(grilla, "Cod.Almacén", "CodigoAlmacen", 0, "", 60, false, true, true);
            this.CreateGridColumn(grilla, "Almacén", "DesAlmacen", 0, "", 90, false, true, true);
            this.CreateGridColumn(grilla, "Código \nProducto", "CodigoArticulo", 0, "", 80, false, true, true);
            this.CreateGridColumn(grilla, "Descripción", "DescripcionArticulo", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Uni.Med", "UnidadMedida", 0, "", 50, true, false, true);
            
            this.CreateGridColumn(grilla, "Ancho", "Ancho", 0, "{0:###,##0.00}", 60, false,true, true,true,"right");
            this.CreateGridColumn(grilla, "Largo", "Largo", 0, "{0:###,##0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(grilla, "Espesor", "Alto", 0, "{0:###,##0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(grilla, "Cantidad", "Cantidad", 0, "{0:###,##0.00}", 60, false, false, true, true, "right");            
            this.CreateGridColumn(grilla, "Area X Uni", "Areaxuni", 0, "{0:###,###0.00}", 80,true, false, true, true, "right");
            
            this.CreateGridColumn(grilla, "Area", "Area", 0, "{0:###,###0.00}", 55, true, false, true, true, "right"); 
           // oculto
            this.CreateGridColumn(grilla, "Costo Unidad", "CostoUnidad", 0, "{0:###,###0.00}", 60, false, false, false, true, "right");
            // oculto
            this.CreateGridColumn(grilla, "Importe", "Importe", 0, "{0:###,###0.00}", 60, true, false, false,true,"right");
            // oculto
            this.CreateGridColumn(grilla, "Orden", "Orden", 0, "{0:###,###0.00}", 50, true, false, false);
            //
            this.CreateGridColumn(grilla, "Flag", "IN07FLAGSTOCKREAL", 0, "", 50, false, true, false); // oculto
            this.CreateGridColumn(grilla, "Observaciones", "in07observacion", 0, "", 100, false, true, true);

            //  Agrega filas ocultas para capturar los ingresos de las salidas

            this.CreateGridColumn(grilla, "IN07DocIngAA", "IN07DocIngAA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngMM", "IN07DocIngMM", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngTIPDOC", "IN07DocIngTIPDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngCODDOC", "IN07DocIngCODDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngKEY", "IN07DocIngKEY", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngORDEN", "IN07DocIngORDEN", 0, "", 0, true, false, false, true);
            //flag para validar si es un registro pendiente de grabar o actualizar
            this.CreateGridColumn(grilla, "flag", "flag", 0, "", 0, false, true, false); 

            this.CreateGridColumn(grilla, "Transaccion", "Transaccion", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "detallesxml", "detallesxml", 0, "", 50,true, false, true);
            this.CreateGridColumn(grilla, "IN07FLAGORIPRODUCCION", "IN07FLAGORIPRODUCCION", 0, "", 50, true, false, true);
            // Suma del Area
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "Area";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);

            grilla.SummaryRowsBottom.Add(summaryRowItem);

            grilla.MasterTemplate.ShowTotals = true;
            grilla.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
   


            //this.gridControl.DefaultValuesNeeded += new GridViewRowEventHandler(gridControl_DefaultValuesNeeded);
        }
        /// <summary>
        /// Crea los grupos de de visualizacion en la Grilla de detalle
        /// </summary>
        void crearGrupos()
        {
            agregarBoton();
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Pedido"));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["in07pedvennum"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["in07pedvenitem"]);    
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07PROVMATPRIMA"]);

            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07ORDENTRABAJO"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["ProvMatPrimaNombre"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07CALIDADMP"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN07CODCLI"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["ClienteNombre"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["OrdenProduccion"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["NroPedidoVenta"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["NroCaja"]);
            

            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Datos del producto"));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["CodigoAlmacen"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["DesAlmacen"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["CodigoArticulo"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["DescripcionArticulo"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["UnidadMedida"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Ancho"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Largo"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Alto"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Cantidad"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Area"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["CostoUnidad"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["Importe"]);
            
                //this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["Unbound"]);
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["Orden"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["in07observacion"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["flag"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["Transaccion"]);
            //this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["IN07FLAGORIPRODUCCION"]);
            
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup());            
            this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControl.Columns["btnGrabar"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns[0].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControl.Columns["btnCancelar"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns[1].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControl.Columns["btnEliminar"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns[2].MinWidth = 30;
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridControl.Columns["btnEditar"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns[3].MinWidth = 30;

            this.gridControl.ViewDefinition = columnGroupsView;
        }
        /// <summary>
        /// Metodo para cargar combos del documento de cabecera
        /// </summary>
        private void CargarCombos()
        {
            try
            {
                var tipoDoc = TipoDocumentoLogic.Instance.ObtenerListItems(Logueo.CodigoEmpresa);
                //tipoDoc.Insert(0, new ItemsList(enmDroDownItems.Seleccione.ToString(), Constantes.DropDownItems.Seleccione));                
                var trans = TipoTransaccionLogic.Instance.ObtenerListItems(Logueo.CodigoEmpresa);
                //trans.Insert(0, new ItemsList(enmDroDownItems.Seleccione.ToString(), Constantes.DropDownItems.Seleccione));
            }
            catch (Exception)
            {

                throw;
            }
        }
            /// <summary>
            /// Metodo para habilitar campos (cajas de texto) segun la configuracion el tipo de documento 
            /// </summary>
            /// <param name="tipoDocumento">Codigo del tipo de documento</param>
        private void ConfigurarDocumento(string tipoDocumento)
        {
            BloquearIngresoDatos();
            string variable = TipoDocumentoLogic.Instance.DameVariable(Logueo.CodigoEmpresa, tipoDocumento);
            //Configura el documento

            if (string.IsNullOrEmpty(variable)) return;
            if (variable.Trim().Length < 16) return;


            //this.txtCodCliente.Enabled = (variable.Substring(5, 1).CompareTo("1") == 0); // orden de trabajo
            this.txtCodProveedor.Enabled = (variable.Substring(0, 1).CompareTo("1") == 0);
            this.txtCodCentroCosto.Enabled = (variable.Substring(1, 1).CompareTo("1") == 0);
            this.txtCodResponsable.Enabled = (variable.Substring(2, 1).CompareTo("1") == 0);
            this.txtCodRepReceptor.Enabled = (variable.Substring(3, 1).CompareTo("1") == 0);

            //this.txtCodObra.Enabled = (variable.Substring(2, 1).CompareTo("1") == 0);
            this.txtCodObra.Enabled = (variable.Substring(4, 1).CompareTo("1") == 0);
            
            
            
            this.txtLote.Enabled = (variable.Substring(8, 1).CompareTo("1") == 0);
            //(variable.Substring(9, 1).CompareTo("1") == 0); -> Cantera
            // variable.Substring(10, 1).CompareTo("1") == 0 -> contatista.
            // ->comprobante salida almacen
            this.txtNotaSalida.Enabled = (variable.Substring(11, 1).CompareTo("1") == 0);
            
            // (variable.Substring(12, 1). Comprobante salida
            //this.txtPedido.Enabled = (variable.Substring(7, 1).CompareTo("1") == 0);
            //OrdenCompra = (variable.Substring(11, 1).CompareTo("1") == 0);
            //string txtPedido = (variable.Substring(7, 1).CompareTo("0") == 0 ? "N" : "S");
            //this.txtCodMaquina.Enabled = (variable.Substring(6, 1).CompareTo("1") == 0);            

            if (!this.txtCodProveedor.Enabled) this.txtCodProveedor.Text = string.Empty;
            if (!this.txtCodCliente.Enabled) this.txtCodCliente.Text = string.Empty;
            if (!this.txtCodCentroCosto.Enabled) this.txtCodCentroCosto.Text = string.Empty;
            if (!this.txtCodResponsable.Enabled) this.txtCodResponsable.Text = string.Empty;
            if (!this.txtCodRepReceptor.Enabled) this.txtCodRepReceptor.Text = string.Empty;
            if (!this.txtCodObra.Enabled) this.txtCodObra.Text = string.Empty;
            if (!this.txtCodMaquina.Enabled) this.txtCodMaquina.Text = string.Empty;
            if (!this.txtLote.Enabled) this.txtLote.Text = string.Empty;            

        }

            /// <summary>
            /// Carga de los detalles del movimeinto en la grilla del documento.
            /// </summary>
        private void CargarMovimiento()
        {
            try
            {                
                string OrdenTrabajo = "";                               
                this.gridControl.DataSource = DocumentoLogic.Instance.TraerMovimiento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                                                                                        this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, OrdenTrabajo );              
            }
            catch (Exception)
            {
                //throw;
            }
        }
        
        private void ObtenerDescripcion(enmAyuda tipoAyuda, string codigo)
        {
            string filtro = "";
            DataRow[] dr;
            //Si no ha cargado por completo la pantalla no realiza ningun accion
            if (!isLoaded) return;

            try
            {
                string descripcion = string.Empty;
                switch (tipoAyuda)
                {
                    case enmAyuda.enmTipoDocumento:
                        this.txtDesTipDoc.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            //Se modifico el procedimiento de traer descripcion solo para la opcion TipDoc 
                            //agregando ahora tipoNaturaleza y si es entrada o salida para le fitraldo                            
                            codigo = Logueo.CodigoEmpresa + codigo + Logueo.PT_codnaturaleza + (this.esEntrada ? "E" : "S");
                            GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOC", out descripcion);
                            this.txtDesTipDoc.Text = descripcion;
                            ConfigurarDocumento(txtCodigoTipDoc.Text);
                        }
                        break;
                    case enmAyuda.enmTransaccion:
                        this.txtDesTransa.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo; // codigo de transaccion
                            GlobalLogic.Instance.DameDescripcion(codigo, "TRANSAC", out descripcion);
                            txtDesTransa.Text = descripcion; // descripcion de transaccion

                            this.txtTipoAnalisis.Text = "";
                            string tipoAnalisis = string.Empty; // iniciamos un campo tipo de Analisis 
                            DocumentoLogic.Instance.TraerAnalisisxDocumentoRespaldo(Logueo.CodigoEmpresa, txtCodTransa.Text.Trim(), 
                                                                                     out tipoAnalisis); // Traemos analisis por documento Respaldo
                            txtTipoAnalisis.Text = tipoAnalisis;
                            
                            
                        }
                        break;
                    case enmAyuda.enmProveedor:
                        this.txtDesProveedor.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + txtTipoAnalisis.Text + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROVEEDOR", out descripcion);
                            this.txtDesProveedor.Text = descripcion;
                        }
                        break;
                        // F1 - PEDIDO
                    case enmAyuda.enmPedido:
                        this.txtDesProveedor.Text = string.Empty;
                        codigo = Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + codigo;

                        string codigoCliente = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(codigo, "CLIPED", out codigoCliente);
                        if (codigoCliente != "???") 
                            this.txtCodCliente.Text = codigoCliente;
                        break;
                        //F1 - CENTRO DE COSTO
                    case enmAyuda.enmCentroCosto:
                        this.txtDesCentroCosto.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CENCOSTO", out descripcion);
                            this.txtDesCentroCosto.Text = descripcion;
                        }
                        break;
                         //F1 -  RESPONSABLE RECEPTOR
                    case enmAyuda.enmResponsableReceptor:
                        this.txtDesRespReceptor.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "RESPONSABLE", out descripcion);
                            this.txtDesRespReceptor.Text = descripcion;
                        }
                        break;
                        // F1 - RESPONSABLE
                    case enmAyuda.enmResponsable:
                        this.txtDesResponsable.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "RESPONSABLE", out descripcion);
                            this.txtDesResponsable.Text = descripcion;
                        }
                        break;
                         // F1 - OBRA
                    case enmAyuda.enmObra:
                        this.txtDesObra.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "OBRA", out descripcion);
                            this.txtDesObra.Text = descripcion;
                        }
                        break;
                        // F1 - MONEDA
                    case enmAyuda.enmMoneda:
                        this.txtDesMoneda.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Constantes.Tablas.CODIGO_TABLA_MONEDA + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "GLOTA", out descripcion);
                            this.txtDesMoneda.Text = descripcion;
                        }
                        break;
                         // F1 - NOTA SALIDA
                    case enmAyuda.enmNotaSalida:
                        this.txtNotaSalidaDesc.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "NOTASALIDA", out descripcion);
                            this.txtNotaSalidaDesc.Text = descripcion;
                        }
                        break;
                         // F1 - CLIENTE
                    case enmAyuda.enmCliente:
                        this.gridControl.CurrentRow.Cells["ClienteNombre"].Value = null;
                        if (!string.IsNullOrEmpty(codigo)) {
                            codigo = Logueo.CodigoEmpresa + "01" + codigo ;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CLIENTE", out descripcion);
                            this.gridControl.CurrentRow.Cells["ClienteNombre"].Value = descripcion;                                                        
                        }
                        
                        break;
                         // F1 - PROV.MATERIA PRIMA
                    case enmAyuda.enmprovmateriaprima:
                        
                        if (codigo != "") {
                            codigo = Logueo.CodigoEmpresa + "10" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROVMATERIA", out descripcion);
                            this.gridControl.CurrentRow.Cells["ProvMatPrimaNombre"].Value = descripcion;
                        }
                        break;
                    
                    //F1 - ALMACEN
                    case enmAyuda.enmAlmacen:
                        if (codigo != "")
                        {
                            codigo =  Logueo.CodigoEmpresa + codigo;
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

                //throw;
            }


        }

        private void txtCodProveedor_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmProveedor, this.txtCodProveedor.Text);
            //Logueo.TipoAnalisisProveedor = "";
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
            if (txtCodigoTipDoc.Text.Trim().Length == 0)
            {
                BloquearIngresoDatos();
            }
            else {
                this.ObtenerDescripcion(enmAyuda.enmTipoDocumento, this.txtCodigoTipDoc.Text);
            }
            
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

        private void frmMovi_Activated(object sender, EventArgs e)
        {
            //Ubica el mouse en TextBox Tipo de documento
            if (this.Estado == FormEstate.New && !isOpened)
            {
                
                if (txtCodigoTipDoc.Enabled == true)
                { txtCodigoTipDoc.Focus(); }
                
                //SendKeys.Send("{TAB}");
                //SendKeys.Send("{TAB}");
                //SendKeys.Send("{TAB}");
                //SendKeys.Send("{TAB}");
            }
            //if (this.Estado == FormEstate.Edit && !isOpened) {

            //    SendKeys.Send("{TAB}");
            //    SendKeys.Send("{TAB}");
            //    SendKeys.Send("{TAB}");
            //    SendKeys.Send("{TAB}");
            //    SendKeys.Send("{TAB}");
            //}
            
            isOpened = true;
           
        }

        string codigoCliente = string.Empty;
        string codigoAnalisis = string.Empty;        
        /// <summary>
            /// Mostrar ayuda para cabecera y detalle de movimiento
            /// </summary>
            /// <param name="tipoAyuda"></param>
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {

            frmBusqueda frm;
            
            string codigoSeleccionado = string.Empty;
            string codigoEmpresa = "", anio = "", mes = "", tipDoc = "", CodDoc = "";
            string codigoArticulo = "";
            string fechaDoc = "", codTransa = "", transa = "S",codAlm = "";

            //string[] registrosSeleccionados;
            //string[] datos;
            //double cantArt = 0;
            //string CodProd = "", uniMed = "", codAlm = "", nrocaja = "",;
            //string DocingAA = "", DocingMM = "", DocingTD = "", DocingPT = "";
            //string DocingNO = "", DocingCD = "", codCliente = "";
            //string canPiezas = "", canArea = "", AreaxUni = "";
            
            

            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
                    
                    frm = new frmBusqueda(tipoAyuda,esEntrada, Logueo.PT_codnaturaleza);
                    frm.Owner = this;                    
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") {
                        this.txtCodigoTipDoc.Text = codigoSeleccionado.Split('|')[0];
                        this.txtDesTipDoc.Text = codigoSeleccionado.Split('|')[1];
                    }
                    break;
                    
                case enmAyuda.enmTransaccion:
                    frm = new frmBusqueda(tipoAyuda);
                    
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)                        
                        codigoSeleccionado = frm.Result.ToString();

                    if(codigoSeleccionado !="") 
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
                    break;
                case enmAyuda.enmCentroCosto:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodCentroCosto.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmResponsableReceptor:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodRepReceptor.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmResponsable:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodResponsable.Text = codigoSeleccionado;
                    break;
             
                case enmAyuda.enmObra:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodObra.Text = codigoSeleccionado;
                    break;              
                case enmAyuda.enmLote:
                    break;
                case enmAyuda.enmProductoXAlmacen:
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado,"",900);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                       {
                                                
                        string xmldinamico = frm.Result.ToString();

                        // Pasa como parametro de procedimiento
                        codigoEmpresa = Logueo.CodigoEmpresa;
                        anio = Logueo.Anio;
                        mes = Logueo.Mes;
                        tipDoc = txtCodigoTipDoc.Text.Trim();
                        CodDoc = txtNroDocumento.Text.Trim();
                        fechaDoc = dtpFechaDoc.Value.ToShortDateString();
                        codTransa = txtCodTransa.Text.Trim();

                        codAlm = this._codigoAlmacenSeleccionado;
                        
                        transa = "S";
                       
                        int outFlag = 0; string outMsg = "";
                        DocumentoLogic.Instance.InsertarDetalleSalMultiple(codigoEmpresa, anio, mes, tipDoc, CodDoc,
                        fechaDoc, codAlm, codTransa, xmldinamico, out outFlag, out outMsg);
                        Util.ShowMessage(outMsg, outFlag);
                        if (outFlag == 1)
                        {
                            //Refrescar
                            CargarMovimiento();
                        }

                       }                                                            
                    break;

                    //frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado,"");
                    //frm.Owner = this;
                    //frm.ShowDialog();
                    //if (frm.Result != null)
                    //    codigoSeleccionado = frm.Result.ToString();

                    //string codigoArticulo = string.Empty;
                    //if (codigoSeleccionado != "")
                    //{
                    //    codigoArticulo = codigoSeleccionado;
                        
                    //     string[] separado = codigoArticulo.Split('/');

                    //     codigoArticulo = separado[0];
                    //     string DocingAA = separado[1];
                    //     string DocingMM = separado[2];
                    //     string DocingTD = separado[3];
                    //     string DocingCD = separado[4];
                    //     string DocingPT = separado[5];
                    //     string DocingNO = separado[6];
                    //     string CanPiezas = separado[7];
                    //     string CanArea = separado[8];
                    //     string nrocaja = separado[9];
                    //     string Cliente = separado[10];
                    //     string clienteNombre = separado[11];
                    //     string ClientePedidonro = separado[12];
                    //     string AreaxUni = separado[13];


                    //     this.gridControl.CurrentRow.Cells["IN07DocIngAA"].Value = DocingAA;
                    //     this.gridControl.CurrentRow.Cells["IN07DocIngMM"].Value = DocingMM;
                    //     this.gridControl.CurrentRow.Cells["IN07DocIngTIPDOC"].Value = DocingTD;
                    //     this.gridControl.CurrentRow.Cells["IN07DocIngCODDOC"].Value = DocingCD;
                    //     this.gridControl.CurrentRow.Cells["IN07DocIngKEY"].Value = DocingPT;
                    //     this.gridControl.CurrentRow.Cells["IN07DocIngORDEN"].Value = DocingNO;
                    //     this.gridControl.CurrentRow.Cells["Cantidad"].Value = CanPiezas;
                    //     this.gridControl.CurrentRow.Cells["AreaxUni"].Value = AreaxUni;
                    //     this.gridControl.CurrentRow.Cells["Area"].Value = CanArea;
                    //     this.gridControl.CurrentRow.Cells["NroCaja"].Value = nrocaja;
                    //     this.gridControl.CurrentRow.Cells["IN07CODCLI"].Value = Cliente;
                    //     this.gridControl.CurrentRow.Cells["clienteNombre"].Value = clienteNombre;
                    //     this.gridControl.CurrentRow.Cells["NroPedidoVenta"].Value = ClientePedidonro;
                        
                    //    //Carga los datos de un Articulo
                    //    string descripcion = string.Empty;
                    //    GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "ARTICULO", out  descripcion);
                    //    this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = codigoArticulo.Trim();
                    //    this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = descripcion.Trim();

                    //    string unidad = string.Empty;
                    //    GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "UNIDADARTICULO", out  unidad);
                    //    this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = unidad.Trim();

                    //    // Trae las medidaas delarticulo
                    //    Movimiento movimiento = new Movimiento();
                        
                    //    movimiento.CodigoEmpresa=Logueo.CodigoEmpresa;
                    //    movimiento.Anio=DocingAA;
                    //    movimiento.Mes=DocingMM;
                    //    movimiento.CodigoTipoDocumento= DocingTD;
                    //    movimiento.CodigoDocumento=DocingCD;
                    //    movimiento.CodigoArticulo=DocingPT;
                    //    movimiento.Orden = double.Parse(DocingNO);

                    //    Articulo articulo = ArticuloLogic.Instance.ProterMedidasSalida(movimiento);

                    //    double Anchonum = articulo.anchonum;
                    //    double largonum = articulo.largonum;
                    //    double Espesornum = articulo.espesornum;

                    //    string Anchotext = articulo.anchotext;
                    //    string largotext = articulo.largotext;
                    //    string Espesortext = articulo.espesortext;


                    //    // ================= Largo
                    //    //Como es salida no separado puede modificar el largo
                    //    this.gridControl.CurrentRow.Cells["Largo"].Value = largonum;
                    //    this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = true;

                    //    // ================= Ancho
                    //    this.gridControl.CurrentRow.Cells["Ancho"].Value = Anchonum;
                    //    this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = true;

                    //    //=================  Espesor
                    //    this.gridControl.CurrentRow.Cells["Alto"].Value = Espesornum;
                    //    this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = true;


                    //   //Presiono tecla Enter para que avance
                    //    Util.SendTab(Keys.Enter.GetHashCode());
                    //    Util.SendTab(Keys.Enter.GetHashCode());
                    //    Util.SendTab(Keys.Enter.GetHashCode());
                    //}

                    //break;
                
                case enmAyuda.enmProductoXAlmacenIng:
                  
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado,"");
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                        codigoArticulo = string.Empty;

                    if (codigoSeleccionado != "")
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

                        // Trae las medidaas delarticulo
                        Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo.Trim());


                        double largonum = articulo.largonum;
                        double Anchonum = articulo.anchonum;
                        double Espesornum = articulo.espesornum;

                        string largotext = articulo.largotext;
                        string Anchotext = articulo.anchotext;
                        string Espesortext = articulo.espesortext;    

                        // ================= Largo
                        if (largotext.ToString() == "ESP")
                        {
                            this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = false;
                        }
                        else
                        {
                            this.gridControl.CurrentRow.Cells["Largo"].Value = largonum;
                            this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = true;
                        }

                        // ================= Ancho
                        if (Anchotext.ToString() == "ESP")
                        {
                            // habilita control para introducir cantidad
                            this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = false;
                        }
                        else
                        {
                            // Toma el valor y bloque a para que no lo modifiquen
                            this.gridControl.CurrentRow.Cells["Ancho"].Value = Anchonum;
                            this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = true;
                        }

                        //=================  Espesor
                        if (Espesortext.ToString() == "ESP")
                        {
                            this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = false;
                        }
                        else
                        {
                            this.gridControl.CurrentRow.Cells["Alto"].Value = Espesornum;
                            this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = true;
                        }
                                
                            Util.SendTab(Keys.Enter.GetHashCode());
                            Util.SendTab(Keys.Enter.GetHashCode());
                            Util.SendTab(Keys.Enter.GetHashCode());
                            Util.SendTab(Keys.Enter.GetHashCode());
                            Util.SendTab(Keys.Enter.GetHashCode());                                                
                    }

                    break;
                case enmAyuda.enmAlmacen:                    
                    frm = new frmBusqueda(tipoAyuda, Logueo.PT_codnaturaleza,"");
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "") {
                        this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value = codigoSeleccionado.Trim();
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].IsSelected = true;
                        
                    }
                  
                    break;
                case enmAyuda.enmPedVentIng:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
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
                            salpedvennum  = item.campotexto11;
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
                    frm = new frmBusqueda(tipoAyuda,this._codigoAlmacenSeleccionado, this._PedidoVentaSeleccionado);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    string codigoArticulopv = string.Empty;

                    if (codigoSeleccionado != "")
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
                        
                    if (codigoSeleccionado != "")
                    {
                        this.gridControl.CurrentRow.Cells["IN07PROVMATPRIMA"].Value = codigoSeleccionado;
                        ObtenerDescripcion(tipoAyuda, codigoSeleccionado);
                        // Presiono tecla Enter para que avance
                        //Util.SendTab(Keys.Enter.GetHashCode());
                    }
                    break;
                case enmAyuda.enmMoneda:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodMoneda.Text = codigoSeleccionado;
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
                case enmAyuda.enmOrdenTrabajo:
                    frm = new frmBusqueda(enmAyuda.enmOrdenTrabajo);
                    frm.ShowDialog();
                    break;            
                case enmAyuda.enmCalidadMP:
                    frm = new frmBusqueda(enmAyuda.enmCalidadMP);
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "IN07CALIDADMP", frm.Result.ToString());                        
                    }
                    break;

                    default:
                    break;
            }
            this.KeyPreview = true;
        }

        private void txtCodigoTipDoc_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTipoDocumento);
        }
     
        private void txtNroReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
        }

        private void txtCodTransa_KeyDown(object sender, KeyEventArgs e)
        {         
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTransaccion);
        }

        private void txtCodProveedor_KeyDown(object sender, KeyEventArgs e)
        {         
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmProveedor);
        }

        private void txtPedido_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
        }

        private void txtCodCentroCosto_KeyDown(object sender, KeyEventArgs e)
        {         
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmCentroCosto);
        }

        private void txtCodRepReceptor_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmResponsableReceptor);
        }

        private void txtCodResponsable_KeyDown(object sender, KeyEventArgs e)
        {            
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
        List<Control> listaCtrl = new List<Control>();
            
                  
        /// <summary>
        /// Modo lectura los campos si un orden t rabajo en celda 
        /// </summary>
        /// <param name="valor"></param>
        private void BloquearCamposxOT(bool valor) {            
            this.gridControl.CurrentRow.Cells["CodigoAlmacen"].ReadOnly = valor;
            this.gridControl.CurrentRow.Cells["CodigoArticulo"].ReadOnly = valor;
            this.gridControl.CurrentRow.Cells["Ancho"].ReadOnly = valor;
            this.gridControl.CurrentRow.Cells["Largo"].ReadOnly = valor;
            this.gridControl.CurrentRow.Cells["Alto"].ReadOnly = valor;
            this.gridControl.CurrentRow.Cells["Cantidad"].ReadOnly = valor;
            this.gridControl.CurrentRow.Cells["IN07ORDENTRABAJO"].ReadOnly = valor;            
        }
        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.gridControl.ActiveEditor != null)
                {
                    //Limitar la edicion de las celdas si tiene un orden de trabajo en su registro
                    
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

                   //si estoy en la columna de codigo de almacen

                    if (e.Column.Name.CompareTo("CodigoAlmacen") == 0)
                    {                                             
                        if (this.gridControl.CurrentRow.Cells["flag"].Value == null)
                        {
                            //si campo flag es nuevlo entonces no puedo modificar campo codigo de almacen
                            e.Cancel = true;
                            return;
                        }
                        else {
                            //si mi campo flag es diferente de vacio(modo edicion) 
                            //campo codigo de almacen es editable si mi campo orden de trabajo es nulo
                            //campo codigo de almacen es editable si mi campo origen produccion es nulo o N
                            e.Cancel = this.gridControl.CurrentRow.Cells["IN07FLAGORIPRODUCCION"].Value.ToString() == "S";
                       return;
                        }
                                                                                                                            
                    }

          

                    //Modo vista cancelar todo las ediciones
                    if (this.Estado == FormEstate.View) {
                        e.Cancel = true;
                        return;
                    }
                    if (e.Column.Name == "flag") {
                        e.Cancel = false;
                        return;
                    }
                    //CostoUnidad - NroPedidoVenta -NroCaja
                    if (e.Column.Name == "codigo" ||e.Column.Name == "Ancho" || e.Column.Name == "Largo" || e.Column.Name == "Alto" 
                        || e.Column.Name == "Cantidad" || e.Column.Name == "CodBloqProv" || e.Column.Name == "AnchoCan"
                        || e.Column.Name == "LargoCan" || e.Column.Name == "AltoCan" || e.Column.Name == "CostoUnidad"
                        || e.Column.Name == "NroPedidoVenta" || e.Column.Name == "IN07ORDENTRABAJO" || e.Column.Name == "NroCaja"
                        || e.Column.Name == "DesAlmacen")
                    {

                        if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                           
                    }

                    if (e.Column.Name == "NroCaja") 
                    {
                        if (e.Row.Cells["Transaccion"].Value.ToString() == "S") 
                        {
                            e.Cancel = true;
                            return;
                        }                       
                    }

                    //CodigoArticulo
                    if (e.Column.Name == "Largo" || e.Column.Name == "Ancho" || e.Column.Name == "Alto") 
                    {
                        if (this.gridControl.CurrentRow.Cells["IN07FLAGORIPRODUCCION"].Value.ToString() == "S")
                        {
                            e.Cancel = false;
                        }
                        else {
                            string codigoArticulo = e.Row.Cells["CodigoArticulo"].Value.ToString();
                            Articulo articulo = ArticuloLogic.Instance.ProterMedidas(codigoArticulo);
                            string largotext = articulo.largotext;
                            string Anchotext = articulo.anchotext;
                            string Espesortext = articulo.espesortext;
                            if (e.Column.Name == "Largo")
                            {
                                e.Cancel = largotext.ToString() != "ESP" ? true : false;
                            }

                            if (e.Column.Name == "Ancho")
                            {
                                e.Cancel = Anchotext.ToString() != "ESP" ? true : false;
                            }

                            if (e.Column.Name == "Alto")
                            {
                                e.Cancel = Espesortext.ToString() != "ESP" ? true : false;
                            }
                        }
                        
                        
                    }
                    if (e.Column.Name == "IN07NROCAJAINGRESO") {
                        if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    if (e.Column.Name == "in07observacion")
                    {
                        if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
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
            //Si la columnad del cual termino la mdoo edicion es diferente de Columna - > Codigo de Articulo
            if (e.Column.Name.CompareTo("CodigoArticulo") != 0)
            {
                //Limpiar loa celdas de CodigoAlmacen y descripcion de aritculo 
                if (this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value == null) return;
                if (this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value == null && e.Column.Name.CompareTo("CodigoAlmacen") != 0) return;
            }

           
            try
            {
             
               
                //Ayuda para Almacen
                //Si la columna terminado de editar es codigo de Almacen 
                if (e.Column.Name.CompareTo("CodigoAlmacen") == 0)
                {
                    {
                        string codigoAlmacen = e.Value.ToString();
                        string descriAlmacen = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}", Logueo.CodigoEmpresa, codigoAlmacen), "ALMACEN", out  descriAlmacen);
                        if (descriAlmacen.CompareTo("???") == 0)
                            this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value = string.Empty;

                        //string codigoAlmacen = e.Value.ToString() + Logueo.PT_codnaturaleza.ToString();
                        //string descriAlmacen = string.Empty;
                        //GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}", Logueo.CodigoEmpresa, codigoAlmacen), "ALMACENXNAT", out  descriAlmacen);
                        //if (descriAlmacen.CompareTo("???") == 0)
                        //    this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value = string.Empty;
                    }
                }


                if (e.Column.Name.CompareTo("CodigoArticulo") == 0)
                {
                    string codigoArticulo = e.Value.ToString();
                    string descripcion = string.Empty;
                    GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "ARTICULO", out  descripcion);
                    this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = descripcion.Trim();

                    string unidad = string.Empty;
                    GlobalLogic.Instance.DameDescripcion(string.Format("{0}{1}{2}", Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo), "UNIDADARTICULO", out  unidad);
                    this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = unidad.Trim();
                }
                
                decimal subtotal = 0;
                decimal cantidad = 0;
                decimal costoUnidad = 0;

                //Variables para calcular area
                string UniMed = string.Empty;
                string Ptcodigo = string.Empty;
                decimal Area = 0;
                double Ancho = 0;
                double Largo = 0;
                double AreaxUni = 0;
                
                if (e.Column.Name.CompareTo("Cantidad") == 0 ||
                    e.Column.Name.CompareTo("Ancho") == 0 ||
                    e.Column.Name.CompareTo("Largo") == 0)
                {
                    //cantidad = decimal.Parse(e.Value.ToString());

                    cantidad = decimal.Parse(this.gridControl.CurrentRow.Cells["Cantidad"].Value.ToString());
                    costoUnidad = decimal.Parse(this.gridControl.CurrentRow.Cells["CostoUnidad"].Value.ToString());
                    
                    subtotal = cantidad * costoUnidad;
                    this.gridControl.CurrentRow.Cells["Importe"].Value = subtotal.ToString();

                    // Calcular AreaCodigoArticulo
                    Ptcodigo=gridControl.CurrentRow.Cells["CodigoArticulo"].Value.ToString();
                    UniMed =gridControl.CurrentRow.Cells["UnidadMedida"].Value.ToString();
                    Ancho = double.Parse(gridControl.CurrentRow.Cells["Ancho"].Value.ToString());
                    Largo = double.Parse(gridControl.CurrentRow.Cells["largo"].Value.ToString());

                    // Traer area x unidad del articulo
                    // si se esta modificando y es salida, que no calcule, si no que tome el area x unidad guardado
                    string tipotransaccion = string.Empty;
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + this.txtCodigoTipDoc.Text, "TIPDOCMOV", out tipotransaccion);

                    

                    if (tipotransaccion=="S") //Verifico Que sea salida
                    {
                        if (double.Parse(gridControl.CurrentRow.Cells["Orden"].Value.ToString()) != 0) // Solo para las modificaciones
                        {
                            AreaxUni = double.Parse(gridControl.CurrentRow.Cells["Areaxuni"].Value.ToString());
                        }
                        else
                        {
                            Articulo articulo = ArticuloLogic.Instance.ProterAreaxUni(Logueo.CodigoEmpresa, Logueo.Anio, Ptcodigo, Ancho, Largo);
                            AreaxUni = articulo.AreaxUni;
                        }
                    }
                    else
                    {
                      Articulo articulo = ArticuloLogic.Instance.ProterAreaxUni(Logueo.CodigoEmpresa,Logueo.Anio,Ptcodigo,Ancho,Largo);
                       AreaxUni = articulo.AreaxUni;
                    }

                        // Calculo Area

                        Area = (decimal)(AreaxUni * Convert.ToDouble(cantidad));

                        this.gridControl.CurrentRow.Cells["Areaxuni"].Value = AreaxUni.ToString();
                        this.gridControl.CurrentRow.Cells["Area"].Value = Area.ToString();
                        
                }
               
                if (e.Column.Name.CompareTo("CostoUnidad") == 0)
                {
                    
                    cantidad = decimal.Parse(this.gridControl.CurrentRow.Cells["Cantidad"].Value.ToString());
                    costoUnidad = decimal.Parse(e.Value.ToString());
                    subtotal = cantidad * costoUnidad;
                    this.gridControl.CurrentRow.Cells["Importe"].Value = subtotal.ToString();
                    //this.GuardarDetalle(this.gridControl.CurrentRow);
                }
                
                if (e.Column.Name.CompareTo("OrdenProduccion") == 0 ||
                    e.Column.Name.CompareTo("NroPedidoVenta") == 0 ||
                    e.Column.Name.CompareTo("NroCaja") == 0 ||
                    e.Column.Name.CompareTo("IN07FLAGSTOCKREAL") == 0 ||
                    e.Column.Name.CompareTo("ProvMatPrimaNombre") == 0 
                    )
                {
                    //this.GuardarDetalle(this.gridControl.CurrentRow);
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }
        protected void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;



            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                if (Estado == FormEstate.View)
                {
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, false, false);
                    return;
                }
                if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value == null) return;
                if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value.ToString() != "0"
                    && gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {// si es modo ver 
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                }
                else
                {// si es modo grabar o cancelar
                    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);
                }
                if (Util.convertiracadena(gridControl.Rows[e.RowIndex].Cells["IN07FLAGORIPRODUCCION"].Value) == "S")
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, false);

            }

        }
        private void gridControl_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.gridControl.Focus();

                if (e.KeyCode == Keys.Enter)
                {
                    Util.SendTab(Keys.Enter.GetHashCode());
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabar"].IsCurrent)
            {
                GuardarDetalle(this.gridControl.CurrentRow);
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
            catch (Exception ex)
            {

            }
        }
        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            GridViewRowInfo info = this.gridControl.CurrentRow;

            if (e.Column.Name == "CodigoArticulo")
            {
                //Si el campo es captura como nulo o vacio

                if (e.Value == null)
                {
                    info.Cells["DescripcionArticulo"].Value = null;
                    info.Cells["UnidadMedida"].Value = null;
                    info.Cells["Ancho"].Value = null;
                    info.Cells["Largo"].Value = null;
                    info.Cells["Alto"].Value = null;
                    info.Cells["Cantidad"].Value = 0;
                    info.Cells["Area"].Value = 0;
                    info.Cells["Importe"].Value = 0;

                    return;
                }

                //capturo el nuevo valor de la celda 
                string nuevoValor = e.Value.ToString();
                //Si el campo codigo de codigo de articulo es diferente del codigo anterior limpiar los campos                
                if (nuevoValor != info.Cells["CodigoArticulo"].Value.ToString())
                {
                    info.Cells["DescripcionArticulo"].Value = null;
                    info.Cells["UnidadMedida"].Value = null;
                    info.Cells["Ancho"].Value = null;
                    info.Cells["Largo"].Value = null;
                    info.Cells["Alto"].Value = null;
                    info.Cells["Cantidad"].Value = 0;
                    info.Cells["Area"].Value = 0;
                    info.Cells["Importe"].Value = 0;

                }
            }

            if (e.Column.Name == "CodigoAlmacen")
            {
                ObtenerDescripcion(enmAyuda.enmAlmacen, Util.convertiracadena(e.Row.Cells["CodigoAlmacen"].Value));
                if (e.Value == null)
                {
                    info.Cells["CodigoArticulo"].Value = null;
                }

                if (Util.convertiracadena(info.Cells["IN07FLAGORIPRODUCCION"].Value) == "")
                {

                    info.Cells["CodigoArticulo"].Value = null;
                }
            }

            ////Si mi columnas es de orden de trabajo
            //if (e.Column.Name == "IN07ORDENTRABAJO")
            //{
            //    //Si el valor de la celda es vacio 
            //    if (e.Value == null)
            //    {
            //        //Limpiar las celdas de la fial actual
            //        info.Cells["CodigoAlmacen"].Value = null;
            //        info.Cells["CodigoArticulo"].Value = null;
            //        info.Cells["DescripcionArticulo"].Value = null;
            //        info.Cells["UnidadMedida"].Value = null;
            //        info.Cells["Ancho"].Value = null;
            //        info.Cells["Largo"].Value = null;
            //        info.Cells["Alto"].Value = null;
            //        info.Cells["Cantidad"].Value = 0;
            //        info.Cells["Area"].Value = 0;
            //        info.Cells["Importe"].Value = 0;
            //        info.Cells["NroCaja"].Value = null;
            //    }

            //}
        }

        //private void gridControl_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        //{
        //    //Evento de celda cambiado(pasado) accion de cambio hecho

        //    try
        //    {
        //        if (this.gridControl.CurrentRow.Cells["flag"].Value == null) return;

        //        if (e.CurrentCell.ColumnInfo.Name == "IN07ORDENTRABAJO")
                
        //        if (this.gridControl.CurrentRow.Cells["IN07ORDENTRABAJO"].Value.ToString() != "")
        //            { BloquearCamposxOT(true); }

        //    }
        //    catch (Exception ex) { }
        //}
        
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            // la variabel Orden es para saber si esta guatdaddo la cabecera del docuemnto
            this.gridControl.Focus();

            if (this.gridControl.RowCount == 0)
                return;

            //F1-Pedido de venta
            if (this.gridControl.CurrentRow.Cells["flag"].Value == null) return;


            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["in07pedvennum"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                    if (double.Parse(this.gridControl.CurrentRow.Cells["Orden"].Value.ToString()) == 0)
                        this.MostrarAyuda(enmAyuda.enmPedVentIng);
            }

            //F1-Almacen
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["CodigoAlmacen"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                    if (double.Parse(this.gridControl.CurrentRow.Cells["Orden"].Value.ToString()) == 0)
                        this.MostrarAyuda(enmAyuda.enmAlmacen);
            }

            //F1-Proveedor de Materia Prima
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["ProvMatPrimaNombre"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                    this.MostrarAyuda(enmAyuda.enmprovmateriaprima);
            }

            //F1-Articulo
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["CodigoArticulo"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                {
                    //valida si tiene orden de trabajo para llamar a la ayuda de articulo                    
                    if (this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value == null &&
                        double.Parse(this.gridControl.CurrentRow.Cells["Orden"].Value.ToString()) == 0)
                    {
                        if (this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value == null)
                        {
                            RadMessageBox.Show("Debe seleccionar un Almacén", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                            return;
                        }
                        this._codigoAlmacenSeleccionado = this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();

                        string codigo = string.Empty;
                        string transaccion = string.Empty;
                        codigo = Logueo.CodigoEmpresa + this.txtCodigoTipDoc.Text;
                        GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOCMOV", out transaccion);

                        if (this.gridControl.CurrentRow.Cells["in07pedvennum"].Value == null)
                        {
                            this._PedidoVentaSeleccionado = "";
                        }
                        else
                        {
                            this._PedidoVentaSeleccionado = this.gridControl.CurrentRow.Cells["in07pedvennum"].Value.ToString();
                        }


                        if (transaccion == "E")
                        {
                            if (this._PedidoVentaSeleccionado == "")
                            {
                                this.MostrarAyuda(enmAyuda.enmProductoXAlmacenIng);
                            }
                            else
                            {
                                this.MostrarAyuda(enmAyuda.enmPedVentIngPT);
                            }
                        }
                        else if (transaccion == "S")
                        {
                            if (this._PedidoVentaSeleccionado == "")
                            {
                                this.MostrarAyuda(enmAyuda.enmProductoXAlmacen);
                            }
                            else
                            {
                                this.MostrarAyuda(enmAyuda.enmProductoXPedVenSalida);
                            }

                            //this.GuardarDetalle(this.gridControl.CurrentRow);
                        }


                    }
                }
            }
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["ClienteNombre"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                    this.MostrarAyuda(enmAyuda.enmCliente);
            }


            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["btnGrabar"].ColumnInfo.Index
                || this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["btnCancelar"].ColumnInfo.Index
                || this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["btnEliminar"].ColumnInfo.Index
                )
            {
                if (e.KeyCode == Keys.Enter)
                {
                    gridControl_CommandCellClick(null, null);
                }

            }

            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["IN07CALIDADMP"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                {
                    this.MostrarAyuda(enmAyuda.enmCalidadMP);
                }
            }

        }

        #region Agregar y quitar Item
      
        private void btnAddDetalle_Click(object sender, EventArgs e)
        {            
            try
            {
                this.gridControl.Focus();
                //Valida que la cabecera debe estar guardado
                if (this.txtCodigoTipDoc.Enabled)
                {
                    RadMessageBox.Show("Para registrar detalles debe guardar el documento", "Aviso", 
                                        MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                                           

                if (this.gridControl.RowCount == 0)
                {
                    
                    //Agregamos una nueva fila a la grila 
                    this.KeyPreview = false;
                    GridViewRowInfo rowInfo = this.gridControl.Rows.AddNew();                    
                    rowInfo.Cells["Orden"].Value = 0;
                    rowInfo.Cells["CodigoAlmacen"].Value = "";// --> PRO09ALMACENCOD    
                    rowInfo.Cells["Cantidad"].Value = 0;                    
                    //Flag para indicar esta fila esta en modo edicion 
                    rowInfo.Cells["flag"].Value = "0";
                    rowInfo.Cells["IN07FLAGORIPRODUCCION"].Value = null;
                    //Resaltar las celda de Ayuda - Color: Amarillo0
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoAlmacen"]);
                    Util.ResaltarAyuda(rowInfo.Cells["ProvMatPrimaNombre"]);
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);
                    Util.ResaltarAyuda(rowInfo.Cells["in07pedvennum"]);
                    Util.ResaltarAyuda(rowInfo.Cells["ClienteNombre"]);
                    Util.ResaltarAyuda(rowInfo.Cells["IN07CALIDADMP"]);
                    //Util.ResaltarAyuda(rowInfo.Cells["IN07NROCAJAINGRESO"]);
                    //Util.ResaltarAyuda(rowInfo.Cells["IN07ORDENTRABAJO"]);
                    if (FrmParent.rbEntradas.IsChecked)
                    {
                        this.gridControl.CurrentColumn = this.gridControl.Columns["ProvMatPrimaNombre"];
                        rowInfo.Cells["ProvMatPrimaNombre"].BeginEdit();
                    }
                    else {
                        this.gridControl.CurrentColumn = this.gridControl.Columns["NroCaja"];
                    }
                }
                else
                {

                    if (this.gridControl.CurrentRow.Cells["flag"].Value != null)
                    {
                        RadMessageBox.Show("Debe completar el registro actual", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }
                    if (double.Parse(this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["Orden"].Value.ToString()) == 0)
                    {
                        RadMessageBox.Show("No ha completado registrar el detalle de documento", "Aviso",
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }    

                    if (this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["DescripcionArticulo"].Value.ToString().CompareTo("???") == 0)
                    {
                        RadMessageBox.Show("Debe ingresar correctamente los artículos en el documento", "Aviso",
                            MessageBoxButtons.OK, RadMessageIcon.Info);
                        return;
                    }

                    this.gridControl.Focus();
                    this.KeyPreview = false;
                    //Capturar codigo del ultimo de almacen.
                    //string lastCodigoAlmacen = this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["CodigoAlmacen"].Value.ToString();
                    
                    //Agregar una nueva fila
                    GridViewRowInfo rowInfo = this.gridControl.Rows.AddNew();

                    //Resaltar las celda de ayuda de Color : Amarillo
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoAlmacen"]);
                    Util.ResaltarAyuda(rowInfo.Cells["ProvMatPrimaNombre"]);
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);
                    Util.ResaltarAyuda(rowInfo.Cells["in07pedvennum"]);
                    Util.ResaltarAyuda(rowInfo.Cells["ClienteNombre"]);
                    Util.ResaltarAyuda(rowInfo.Cells["IN07CALIDADMP"]);
                    //Util.ResaltarAyuda(rowInfo.Cells["IN07ORDENTRABAJO"]);
                    
                    //Asginando valores vacio o cero para la nueva fila
                    //Asigno el codigo del ultimo almacen
                    rowInfo.Cells["Orden"].Value = 0;

                    //Si tengo un valor en almacen x Proceso
                    //if (codigodeAlmacen != "") {
                    //     //Asgino valor el almacen x Proceso
                    //    rowInfo.Cells["CodigoAlmacen"].Value = codigodeAlmacen;    
                    //}

                    
                    
                    //Flag para indicar esta fila en modo edicion
                    rowInfo.Cells["NroCaja"].Value = null;
                    rowInfo.Cells["NroPedidoVenta"].Value = null;
                    rowInfo.Cells["Cantidad"].Value = 0;
                    rowInfo.Cells["flag"].Value = "0";
                    rowInfo.Cells["IN07FLAGORIPRODUCCION"].Value = null;
                    //Iniciar esta celda para iniciar a digitar
                    rowInfo.Cells["ProvMatPrimaNombre"].BeginEdit();

                               
                  
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
            /// Validar los campos del detalle de movimiento
            /// </summary>
            /// <param name="fila"></param>
            /// <returns></returns>
        bool ValidarDetalle(GridViewRowInfo fila) {

            if (fila.Cells["ClienteNombre"] == null || fila.Cells["ClienteNombre"].Value == null)
            {
                RadMessageBox.Show("Ingresar Cliente.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                
                gridControl.CurrentColumn = this.gridControl.Columns["ClienteNombre"];
                return false;
            }

            if (fila.Cells["NroCaja"] == null || fila.Cells["NroCaja"].Value == null)
            {
                RadMessageBox.Show("Ingresar numero de caja.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);                
                gridControl.CurrentColumn = this.gridControl.Columns["NroCaja"];
                return false;
            }

            if (fila.Cells["CodigoAlmacen"] == null || fila.Cells["CodigoAlmacen"].Value == null)
            {
                RadMessageBox.Show("Ingresar Almacen", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);                
                gridControl.CurrentColumn = this.gridControl.Columns["CodigoAlmacen"];
                return false;
            }

            if (fila.Cells["CodigoArticulo"] == null || fila.Cells["CodigoArticulo"].Value == null) 
            {
                RadMessageBox.Show("Ingresar Articulo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);                
                gridControl.CurrentColumn = this.gridControl.Columns["CodigoArticulo"];
                return false;
            }

            // Validar Formato
            string codigoArticulo = fila.Cells["CodigoArticulo"].Value.ToString();
            string codigo = string.Empty;
            string tipcalculoarea = string.Empty;

            codigo = Logueo.CodigoEmpresa + Logueo.Anio + codigoArticulo;

            GlobalLogic.Instance.DameDescripcion(codigo, "FLAGTIPCALAREA", out tipcalculoarea);

            //GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOCMOV", out transaccion);
            
            
            if (tipcalculoarea=="F") // Validar si el producto se calcula por formato
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
           
            if (fila.Cells["Cantidad"] == null || Convert.ToDecimal(fila.Cells["Cantidad"].Value) == 0 ) 
            {
                RadMessageBox.Show("Ingresar Cantidad", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);                
                gridControl.CurrentColumn = this.gridControl.Columns["Cantidad"];
                return false;
            }
                      
            
            return true;
        }
       /// <summary>
       /// Metodo praa guardar el detalle del movimiento 
       /// </summary>
       /// <param name="info">Datos de la fila actual (ejemplo : this.gridcontol.currentRow </param>
        private void GuardarDetalle(GridViewRowInfo info)
        {
            try
            {
                if (!ValidarDetalle(info)) return;

                string nrocanastillaingreso = this.gridControl.CurrentRow.Cells["NroCaja"].Value == null ? "" : 
                                              Util.convertiracadena(this.gridControl.CurrentRow.Cells["NroCaja"].Value.ToString());               
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

                mov.Largo = double.Parse(info.Cells["largo"].Value.ToString());
                mov.Ancho = double.Parse(info.Cells["ancho"].Value.ToString());
                mov.Alto = double.Parse(info.Cells["Alto"].Value.ToString());

                mov.CodigoAlmacen = info.Cells["CodigoAlmacen"].Value == null ? null : info.Cells["CodigoAlmacen"].Value.ToString();
                mov.CodigoTransaccion = this.txtCodTransa.Text;
                mov.Transaccion = transaccion;
                mov.Cantidad = double.Parse(info.Cells["Cantidad"].Value.ToString());
                mov.CostoUnidad = double.Parse(info.Cells["CostoUnidad"].Value.ToString());
                mov.Importe = double.Parse(info.Cells["Importe"].Value.ToString());
                mov.Areaxuni = double.Parse(info.Cells["Areaxuni"].Value == null ? "0" : info.Cells["Areaxuni"].Value.ToString());
                mov.FechaDoc = this.dtpFechaDoc.Value;


                //Trae numero de orden                
                mov.UnidadMedida = info.Cells["UnidadMedida"].Value == null ? null : info.Cells["UnidadMedida"].Value.ToString();
                mov.in07observacion = info.Cells["in07observacion"].Value == null ? null : info.Cells["in07observacion"].Value.ToString();
                mov.IN07ORDENTRABAJO = Util.convertiracadena(info.Cells["IN07ORDENTRABAJO"].Value);
                mov.IN07CALIDADMP = Util.convertiracadena(info.Cells["IN07CALIDADMP"].Value);
                //Nuevos campos
                if (info.Cells["NroPedidoVenta"].Value != null) mov.NroPedidoVenta = info.Cells["NroPedidoVenta"].Value.ToString();
                if (info.Cells["NroCaja"].Value != null) mov.NroCaja = info.Cells["NroCaja"].Value.ToString();
                if (info.Cells["OrdenProduccion"].Value != null) mov.OrdenProduccion = "";
                    //--info.Cells["OrdenProduccion"].Value.ToString();
                if (info.Cells["IN07CODCLI"].Value != null) mov.in07codcli = info.Cells["IN07CODCLI"].Value.ToString();
                
                if (info.Cells["OrdenProduccion"].Value != null) mov.OrdenProduccion = info.Cells["OrdenProduccion"].Value.ToString();
                if (info.Cells["IN07PROVMATPRIMA"].Value != null) mov.IN07PROVMATPRIMA = info.Cells["IN07PROVMATPRIMA"].Value.ToString();
                if (info.Cells["IN07FLAGSTOCKREAL"].Value != null) mov.IN07FLAGSTOCKREAL = info.Cells["IN07FLAGSTOCKREAL"].Value.ToString();

                
                //Si el campo pedido de venta tiene algun valor
                    if (info.Cells["in07pedvennum"].Value != null)
                    {
                        if (info.Cells["in07pedvennum"].Value != null) mov.in07pedvennum = info.Cells["in07pedvennum"].Value.ToString();
                        if (info.Cells["CodigoArticulo"].Value != null) mov.in07pedvencodprod = info.Cells["CodigoArticulo"].Value.ToString();
                        if (info.Cells["in07pedvenitem"].Value != null) mov.in07pedvenitem = double.Parse(info.Cells["in07pedvenitem"].Value.ToString());
                    }
               

                // Campos que relacionan la salida con su respectivo ingreso
                if (transaccion == "S")
                {
                    if (info.Cells["IN07DocIngAA"].Value != null) mov.IN07DocIngAA = info.Cells["IN07DocIngAA"].Value.ToString();
                    if (info.Cells["IN07DocIngMM"].Value != null) mov.IN07DocIngMM = info.Cells["IN07DocIngMM"].Value.ToString();
                    if (info.Cells["IN07DocIngTIPDOC"].Value != null) mov.IN07DocIngTIPDOC = info.Cells["IN07DocIngTIPDOC"].Value.ToString();
                    if (info.Cells["IN07DocIngCODDOC"].Value != null) mov.IN07DocIngCODDOC = info.Cells["IN07DocIngCODDOC"].Value.ToString();
                    if (info.Cells["IN07DocIngKEY"].Value != null) mov.IN07DocIngKEY = info.Cells["IN07DocIngKEY"].Value.ToString();
                    if (info.Cells["IN07DocIngORDEN"].Value != null) mov.IN07DocIngORDEN = 
                        double.Parse(info.Cells["IN07DocIngORDEN"].Value.ToString());                    
                }
                //mov.IN07NROCAJAINGRESO = Util.convertiracadena(info.Cells["IN07NROCAJAINGRESO"].Value);
                string mensajeRetorno = string.Empty;
                 int flag = 0;
                double orden = 0;

                if (double.Parse(info.Cells["Orden"].Value.ToString()) == 0)
                {
                    //NUEVO              
                    //Si el detall no tiene orden de  trabajo 
                    //
                    //if (Util.convertiracadena(info.Cells["IN07FLAGORIPRODUCCION"].Value) == "")
                    //{
                        orden = 0;

                        DocumentoLogic.Instance.TraerNroOrden(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.txtCodigoTipDoc.Text,
                                                                this.txtNroDocumento.Text, mov.CodigoArticulo, out orden);
                        mov.Orden = orden;

                        DocumentoLogic.Instance.InsertarDetalle(mov, Logueo.TipoCambio, this.txtCodMoneda.Text, out flag, out mensajeRetorno);
                        info.Cells["Orden"].Value = orden;


                    //}
                    //else
                    //{

                    //    orden = 0;
                    //    DocumentoLogic.Instance.TraerNroOrden(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.txtCodigoTipDoc.Text,
                    //                                            this.txtNroDocumento.Text, mov.CodigoArticulo, out orden);
                    //    mov.Orden = orden;
                    //    string xml = info.Cells["detallesxml"].Value.ToString();

                    //    DocumentoLogic.Instance.InsertarDetalleDocumentoxCanastIng(mov, Logueo.TipoCambio, this.txtCodMoneda.Text,
                    //                                        Logueo.OrigenTipo_automatico, xml, out flag, out mensajeRetorno);
                    //    info.Cells["Orden"].Value = mov.Orden;
                    //}
                    // si el flag es  -1  entonces el proceso tiene error
                    if (flag == -1)
                    {
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                    else
                    {
                        //es OK
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                        gridControl.CurrentRow.Cells["flag"].Value = null;
                        CargarMovimiento();
                        //agrego nueva fila
                        btnAddDetalle_Click(null, null);
                    }
                }
                else
                {
                    //EDITAR
                        mov.Orden = double.Parse(info.Cells["Orden"].Value.ToString());

                        DocumentoLogic.Instance.ActualizarDetalle(mov, Logueo.TipoCambio, this.txtCodMoneda.Text, out flag, out mensajeRetorno);
                        info.Cells["Orden"].Value = mov.Orden;

                        if (flag == -1)
                        {
                            RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                        }
                        else
                        {
                            gridControl.CurrentRow.Cells["flag"].Value = null;
                            CargarMovimiento();
                            RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                            Util.enfocarFila(gridControl, "Orden", mov.Orden.ToString());
                            this.KeyPreview = true;
                        }
                    
                    
                }
            }
            catch (Exception ex )
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                
                //throw;
            }
        }

        #endregion        
  
        #region Guardar
        /// <summary>
        /// Metodo de validacion para los datos de la cebera del documento
        /// </summary>
        /// <returns> Si es true entonces validacion es OK</returns>
        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;

            if (this.txtCodigoTipDoc.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Tran", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodigoTipDoc.Focus();
                return false;
            }
            if (this.txtDesTipDoc.Text.Trim() == "" || this.txtDesTipDoc.Text.Trim() == "???")
            {
                RadMessageBox.Show("Transaccion No Valida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodigoTipDoc.Focus();
                return false;
            }
                                          
            //Campos de Transaccion
            if (this.txtCodTransa.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Transacción", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodTransa.Focus();
                return false;
            }

            if (this.txtDesTransa.Text.Trim() == "" || this.txtDesTransa.Text.Trim() == "???")
            {
                RadMessageBox.Show("Tipo Documento Respaldo No Valido", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodTransa.Focus();
                return false;
            }


            //Campos proveedor y de monea

            if (this.txtCodProveedor.Enabled)
            {
                if (this.txtCodProveedor.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Proveedor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodProveedor.Focus();
                    return false;
                }
            }
           
   
            
            //Campos adicionales
            if (this.txtCodRepReceptor.Enabled)
            {
                if (this.txtCodRepReceptor.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Responsable receptor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodRepReceptor.Focus();
                    return false;
                }
            }

            if (this.txtCodResponsable.Enabled)
            {
                if (this.txtCodResponsable.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Responsable entrega", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodResponsable.Focus();
                    return false;
                }
            }

            if (this.txtCodCentroCosto.Enabled)
            {
                if (this.txtCodCentroCosto.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Centro de costo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodCentroCosto.Focus();
                    return false;
                }
            }

            if (this.txtCodObra.Enabled)
            {
                if (this.txtCodObra.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Obra", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtCodObra.Focus();
                    return false;
                }
            }
            if (this.txtNotaSalida.Enabled)
            {
                if (this.txtNotaSalida.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Nota de salida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtNotaSalida.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Guardar los datos de la cabecera del documento
        /// </summary>
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
                this.txtCodMoneda.Text = Logueo.MonedaxDefecto;
                documento.Moneda = this.txtCodMoneda.Text;
                documento.ResponsableReceptor = this.txtCodRepReceptor.Text;
                documento.Responsable = this.txtCodResponsable.Text;
                documento.CodigoCentroCosto = this.txtCodCentroCosto.Text;
                documento.CodigoObra = this.txtCodObra.Text;
                
                //Tipo de cambio
                documento.TipoCambio = Logueo.TipoCambio;
                documento.IN06PRODNATURALEZA = Logueo.PT_codnaturaleza;
                documento.IN06DOCRESCTACTETIPANA = this.txtTipoAnalisis.Text;
                documento.IN06DOCRESCTACTENUMERO = txtCodProveedor.Text.Trim();

                ////Datos de Produccion
                //documento.codigoLinea = this.txtCodLinea.Text.Trim();
                //documento.codigoActiNivel1 = this.txtCodProceso.Text.Trim();
                //documento.codigoTurno = this.txtCodTurno.Text.Trim();
                //documento.CodigoMaquina = this.txtCodigoMaquina.Text.Trim();

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
                    DocumentoLogic.Instance.InsertarDocumento(documento, out nroDocumentoRetorno, out mensajeRetorno);
                    if (nroDocumentoRetorno != "") { // valdamos si obtenemos un valor de retorno 
                        this.txtNroDocumento.Text = nroDocumentoRetorno;
                        
                        //deshabilitamos algunos controles de la cabcera del documento
                        Habilitar(false);
                        
                        //asginsmo estado de edicion
                        this.Estado = FormEstate.Edit;
                        
                        //si la operacion fue exitosa hacemos visible a boton de agregar detalle
                        btnAddDetalle.Visible = true;
                        btnIngProduccion.Visible = true;
                      
                    }                   
                }
                else
                {
                    //MODIFICA
                    DocumentoLogic.Instance.ActualizarDocumento(documento, out mensajeRetorno);
                }

                RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);                
                frmDocu.formulario.Listar();
                
            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar el documento", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
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
        
        private void btnAddDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnAddDetalle_Click(null, null);
            }
        }

        
        /// <summary>
            /// Metodo para habilitar o deshabilitar los botones del mantenimeinto detalle Moviemiento
            /// </summary>
            /// <param name="nombre"></param>
            /// <param name="CommandCell"></param>
            /// <param name="bGrabar"></param>
            /// <param name="bCancelar"></param>
            /// <param name="bEliminar"></param>
            /// <param name="bEditar"></param>
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar, bool bCancelar,
            bool bEliminar, bool bEditar) 
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabar":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelar":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminar":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditar":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edited_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;
                default:
                    break;
            }
        }     
        /// <summary>
        /// Metod para eliminar el registro seleccionado del detalle de movimiento
        /// </summary>        
        private void eliminarRegistroGrilla() {
            
             try
             {
              
                 if (this.gridControl.RowCount == 0)
                     return;
                 
                 DialogResult dialog = RadMessageBox.Show("Está seguro de eliminar Item seleccionado?", "Aviso",
                     MessageBoxButtons.YesNo, RadMessageIcon.Question);
                 if (dialog == System.Windows.Forms.DialogResult.No)
                     return;

                 GridViewRowInfo info = this.gridControl.CurrentRow;

                 // eliminar movimiento sin orde de trabajo 
                     if (double.Parse(info.Cells["Orden"].Value.ToString()) > 0)
                     {
                         string mensajeRetorno = string.Empty;
                         
                         if (Util.convertiracadena(info.Cells["IN07FLAGORIPRODUCCION"].Value) == "")
                         {
                             DocumentoLogic.Instance.EliminarDetalle(Logueo.CodigoEmpresa, Logueo.Anio,
                             Logueo.Mes, this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text,
                              info.Cells["CodigoArticulo"].Value.ToString(),
                             double.Parse(info.Cells["Orden"].Value.ToString()), out mensajeRetorno);

                             this.gridControl.Rows.Remove(this.gridControl.CurrentRow);
                             RadMessageBox.Show(mensajeRetorno);
                         }
                         else
                         {
                             //Eliminar detall de grilla con flag ->  S  (salida de produccion)
                             DocumentoLogic.Instance.EliminarSalidasPPLinea(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.txtCodigoTipDoc.Text,
                                 this.txtNroDocumento.Text.Trim(), info.Cells["CodigoArticulo"].Value.ToString(),
                                 double.Parse(info.Cells["Orden"].Value.ToString()),
                                 out mensajeRetorno);

                             this.gridControl.Rows.Remove(this.gridControl.CurrentRow);
                             RadMessageBox.Show(mensajeRetorno);

                         }
                         CargarMovimiento();
                     }
             }
             catch (Exception)
             {
                 throw;
             }
        }
        /// <summary>
        /// Metodo para habilitar los campos paraedicion de registro
        /// </summary>
        void editarRegistroGrilla()
        {
           

            // Validar si es un registro de Linea
            if (Util.convertiracadena(this.gridControl.CurrentRow.Cells["IN07FLAGORIPRODUCCION"].Value.ToString()) == "S")
            {
                RadMessageBox.Show("Registro no editable por su origen de stock linea", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            //Flaga pra fila en modo edicion
            gridControl.CurrentRow.Cells["flag"].Value = "0";

            string orden = gridControl.CurrentRow.Cells["Orden"].Value.ToString();
            //enfocar fila actual
            Util.enfocarFila(gridControl, "Orden", orden);
            //Resaltar celdas de ayuda  color:Amarillo
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CodigoAlmacen"]);
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["ProvMatPrimaNombre"]);
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CodigoArticulo"]);
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["in07pedvennum"]);
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["ClienteNombre"]);
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["IN07CALIDADMP"]);
            
            if (this.gridControl.CurrentRow.Cells["IN07FLAGORIPRODUCCION"].Value.ToString() == "S")
            {
                BloquearCamposxOT(true);
            }
            else
            {
                BloquearCamposxOT(false);
                
            }
        }
        /// <summary>
        /// Metodo para cancelar la insercion del registro en el detalle de movimiento
        /// </summary>
        void cancelarRegistroGrilla()
        {
            Movimiento mov = new Movimiento();
            mov.Orden = double.Parse(this.gridControl.CurrentRow.Cells["orden"].Value.ToString());
            CargarMovimiento(); Util.enfocarFila(gridControl, "orden", mov.Orden.ToString());
        }

        
                    
        private void txtCodLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) MostrarAyuda(enmAyuda.enmLinea);                        
        }
        private void txtCodProceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) MostrarAyuda(enmAyuda.enmActividadNivel1);                        
        }                           
        private void txtCodigoMaquina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)            
                MostrarAyuda(enmAyuda.enmMaquina);            
        }    
        

        #region "Ingreso produccion Stock LInea"

        private void CrearColumnasStockLinea()
        {            
            RadGridView grilla = this.CreateGridVista(this.gridStockLinea);
            this.gridStockLinea.SelectionMode = GridViewSelectionMode.CellSelect;
            //grilla.AutoGenerateColumns = false;
            this.CreateGridColumn(grilla, "Ped.Num", "in07pedvennum", 0, "", 50, true, false, false);
            // Orden de trabajo 
            this.CreateGridColumn(grilla, "OT", "IN07ORDENTRABAJO", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "PedVenta", "IN07PEDVEN", 0, "", 60, true, false, false);
            //Proveedor de materia prima
            this.CreateGridColumn(grilla, "Cod Prov Mat Prima", "IN07PROVMATPRIMA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "Prov. Materia Prima", "ProvMatPrimaNombre", 0, "", 90, true, false, true);

            //Calidad Materia Prima
            this.CreateGridColumn(grilla, "MP.Calidad", "IN07CALIDADMP", 0, "", 90, true, false, true);

            //Datos de cliente
            this.CreateGridColumn(grilla, "Codcli", "IN07CODCLI", 0, "", 150, true, false, false);
            this.CreateGridColumn(grilla, "Nombre", "ClienteNombre", 0, "", 90);

            // Datos del detalle de movimiento                         
            //oculto
            this.CreateGridColumn(grilla, "Pedido", "NroPedidoVenta", 0, "", 80, false, true, true);
            this.CreateGridColumn(grilla, "Nro Caja", "NroCaja", 0, "", 90, false, true, true);
            // Almacen
            this.CreateGridColumn(grilla, "Cód.", "CodigoAlmacen", 0, "", 70, false, true, true);
            this.CreateGridColumn(grilla, "Nombre", "DesAlmacen", 0, "", 150, false, true, true);

            //Producto 
            this.CreateGridColumn(grilla, "Cód.", "CodigoArticulo", 0, "", 70, false, true, true);
            this.CreateGridColumn(grilla, "Descripción", "DescripcionArticulo", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Uni.Med", "UnidadMedida", 0, "", 90, true, false, true);

            this.CreateGridColumn(grilla, "Ancho", "Ancho", 0, "{0:###,##0.00}", 70, false, true, true, true, "right");
            this.CreateGridColumn(grilla, "Largo", "Largo", 0, "{0:###,##0.00}", 60, false, true, true, true, "right");
            this.CreateGridColumn(grilla, "Espesor", "Alto", 0, "{0:###,##0.00}", 70, false, true, true, true, "right");
            // Datos de Detalle de movimieto
            this.CreateGridColumn(grilla, "Cantidad", "Cantidad", 0, "{0:###,##0.00}", 80, false, false, true, true, "right");
            //oculto
            this.CreateGridColumn(grilla, "Area X Uni", "Areaxuni", 0, "{0:###,###0.00}", 80, true, false, false, true, "right");
            //oculto
            this.CreateGridColumn(grilla, "Area", "Area", 0, "{0:###,###0.00}", 55, true, false, false, true, "right");
            //oculto
            this.CreateGridColumn(grilla, "Costo Unidad", "CostoUnidad", 0, "{0:###,###0.00}", 60, false, false, false, true, "right");
            this.CreateGridColumn(grilla, "Importe", "Importe", 0, "{0:###,###0.00}", 60, true, false, false, true, "right");
            //oculto
            this.CreateGridColumn(grilla, "Orden", "Orden", 0, "{0:###,###0.00}", 50, true, false, false);
            //oculto
            this.CreateGridColumn(grilla, "Flag", "IN07FLAGSTOCKREAL", 0, "", 50, false, true, false);
            this.CreateGridColumn(grilla, "Observaciones", "in07observacion", 0, "", 100, false, true, true);

            //  Agrega filas ocultas para capturar los ingresos de las salidas

            this.CreateGridColumn(grilla, "IN07DocIngAA", "IN07DocIngAA", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngMM", "IN07DocIngMM", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngTIPDOC", "IN07DocIngTIPDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngCODDOC", "IN07DocIngCODDOC", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngKEY", "IN07DocIngKEY", 0, "", 0, true, false, false, false);
            this.CreateGridColumn(grilla, "IN07DocIngORDEN", "IN07DocIngORDEN", 0, "", 0, true, false, false, true);
            //flag para validar si es un registro pendiente de grabar o actualizar
            this.CreateGridColumn(grilla, "flag", "flag", 0, "", 0, false, true, false);
            //oculto
            this.CreateGridColumn(grilla, "Transaccion", "Transaccion", 0, "", 50, true, false, false);
            //oculto
            this.CreateGridColumn(grilla, "detallesxml", "detallesxml", 0, "", 50, true, false, false);
            //oculto
            this.CreateGridColumn(grilla, "IN07FLAGORIPRODUCCION", "IN07FLAGORIPRODUCCION", 0, "", 50, true, false, false);
            //campo oculto 
            

            /*Datos de ingreso de stock linea*/
            this.CreateGridColumn(grilla, "IngLineanroCaja", "IngLineanroCaja", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "IngLineaOT", "IngLineaOT", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "IngLineaAlmCod", "IngLineaAlmCod", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "IngLineaProductoCod", "IngLineaProductoCod", 0, "", 50, true, false, false);
            CrearGruposStockLinea();
        }
        private void CrearGruposStockLinea()
        {
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Produccion"));  
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            /*this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridStockLinea.Columns["in07pedvennum"]);*/
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridStockLinea.Columns["IN07ORDENTRABAJO"]);
            /*Proveedor*/
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridStockLinea.Columns["IN07PROVMATPRIMA"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridStockLinea.Columns["ProvMatPrimaNombre"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridStockLinea.Columns["IN07CALIDADMP"]);
            
            /*Grupo Cliente*/
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Cliente"));
            this.columnGroupsView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            
            /*Dato cliente*/
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridStockLinea.Columns["IN07CODCLI"]);
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridStockLinea.Columns["ClienteNombre"]);
            
            /*Nro pediddo , caja*/
            this.columnGroupsView.ColumnGroups[1].Rows[0].Columns.Add(this.gridStockLinea.Columns["NroPedidoVenta"]);
                                    
            /* Almacen */
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Almacen"));            
            this.columnGroupsView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridStockLinea.Columns["NroCaja"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridStockLinea.Columns["CodigoAlmacen"]);
            this.columnGroupsView.ColumnGroups[2].Rows[0].Columns.Add(this.gridStockLinea.Columns["DesAlmacen"]);
            
            /*Grupo Producto*/
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Producto"));
            this.columnGroupsView.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());                        
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["CodigoArticulo"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["DescripcionArticulo"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["UnidadMedida"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["Ancho"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["Largo"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["Alto"]);           
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["Cantidad"]);
            this.columnGroupsView.ColumnGroups[3].Rows[0].Columns.Add(this.gridStockLinea.Columns["in07observacion"]);
            this.gridStockLinea.ViewDefinition = columnGroupsView;
        }
        private void CargarGridStockLinea()
        {

        }
        
        private void CrearFilasStockLinea() 
        {            
            for (int i = 0; i < 30; i++)
            {
                this.gridStockLinea.Rows.AddNew();
            }
            this.gridStockLinea.CurrentRow = this.gridStockLinea.Rows[0];
        }

        private void IniciarStockLinea()
        {
            this.rpcStockLinea.BringToFront();
            CrearFilasStockLinea();
            this.rpcStockLinea.Show();
            this.gridStockLinea.Focus();

            // Traer valores por defecto
            //Almacen de Stock linea            
            this.gridStockLinea.CurrentRow.Cells["CodigoAlmacen"].Value = Logueo.PT_AlmxDefecto;
        }
        private void OcultarStockLinea()
        {            
            
            this.gridStockLinea.Rows.Clear();
            this.rpcStockLinea.Hide();
        }
        private void btnIngProduccion_Click(object sender, EventArgs e)
        {
            IniciarStockLinea();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            OcultarStockLinea();
        }
        private int GetColumnIndex(RadGridView GridView, string namecolumn)
        {
            return GridView.Columns[namecolumn].Index;
        }
        private void MostrarAyudaStockLinea(enmAyuda tipoAyuda)
        {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch(tipoAyuda)
            {
                case enmAyuda.enmprovmateriaprima:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                        
                    if (codigoSeleccionado != "")
                    {
                        this.gridStockLinea.CurrentRow.Cells["IN07PROVMATPRIMA"].Value = codigoSeleccionado;
                        ObtenerDescripcionStockLinea(tipoAyuda, codigoSeleccionado);                        
                    }
                    break;
                case enmAyuda.enmCliente:
                     frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                        if (codigoSeleccionado != "")
                        {
                            this.gridStockLinea.CurrentRow.Cells["IN07CODCLI"].Value = codigoSeleccionado;
                            ObtenerDescripcionStockLinea(enmAyuda.enmCliente, codigoSeleccionado);
                        }   
                    break;
                case enmAyuda.enmStockLinea:
                    frm = new frmBusqueda(enmAyuda.enmStockLinea, "", "", 900);
                    frm.ShowDialog();
                    if (frm.Result != null && frm.Result.ToString().Length > 0)
                    {
                        string[] coleccion = (string[])frm.Result;
                        if (coleccion.Length == 0)
                        {
                            RadMessageBox.Show("No selecciono registros", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            return;
                        }
                        int rowIndexSelected = this.gridStockLinea.CurrentRow.Index;
                        int arrayIndex = 0;
                        for (int i = rowIndexSelected; i < (rowIndexSelected + coleccion.Length); i++)
                        {
                            string[] stocklinea = coleccion[arrayIndex].Split('|');
                            this.gridStockLinea.Rows[i].Cells["IN07ORDENTRABAJO"].Value = stocklinea[0];// OT
                            //this.gridStockLinea.Rows[i].Cells["CodigoAlmacen"].Value = stocklinea[1];
                            //this.gridStockLinea.Rows[i].Cells["DesAlmacen"].Value = stocklinea[2];
                            this.gridStockLinea.Rows[i].Cells["CodigoArticulo"].Value = stocklinea[3]; // codigo prod   
                            this.gridStockLinea.Rows[i].Cells["DescripcionArticulo"].Value = stocklinea[4]; //  desc. prod
                            this.gridStockLinea.Rows[i].Cells["UnidadMedida"].Value = stocklinea[5]; // UM
                            this.gridStockLinea.Rows[i].Cells["Cantidad"].Value = stocklinea[7];
                            this.gridStockLinea.Rows[i].Cells["Ancho"].Value = stocklinea[8]; //  ancho
                            this.gridStockLinea.Rows[i].Cells["Alto"].Value = stocklinea[9]; // alto
                            this.gridStockLinea.Rows[i].Cells["Largo"].Value = stocklinea[10]; // largo
                            this.gridStockLinea.Rows[i].Cells["Areaxuni"].Value = stocklinea[11];
                            this.gridStockLinea.Rows[i].Cells["Area"].Value = stocklinea[12];
                            this.gridStockLinea.Rows[i].Cells["IngLineanroCaja"].Value = stocklinea[13]; // campo oculto
                            this.gridStockLinea.Rows[i].Cells["IngLineaAlmCod"].Value = stocklinea[1]; //  campop oculto
                            this.gridStockLinea.Rows[i].Cells["NroCaja"].Value = stocklinea[13]; //  nro de caja x default
                            arrayIndex++;
                        }
                    }
                    break;

                case enmAyuda.enmAlmacen:
                    frm = new frmBusqueda(tipoAyuda, Logueo.PT_codnaturaleza,"");
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "") {
                        this.gridStockLinea.CurrentRow.Cells["CodigoAlmacen"].Value = codigoSeleccionado.Trim();    
                        
                        this.gridStockLinea.CurrentRow.Cells["CodigoArticulo"].IsSelected = true;
                        ObtenerDescripcionStockLinea(enmAyuda.enmAlmacen, codigoSeleccionado.Trim());
                    }
                    break;
                case enmAyuda.enmCalidadMP:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        Util.SetValueCurrentCellText(gridStockLinea.CurrentRow, "IN07CALIDADMP", frm.Result.ToString());
                    break;
                default:
                    break;
            }
        }
        private void gridStockLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                int currentcolindex = this.gridStockLinea.CurrentColumn.Index;
               
                
                if (currentcolindex == GetColumnIndex(gridStockLinea, "ProvMatPrimaNombre") )
                {
                    MostrarAyudaStockLinea(enmAyuda.enmprovmateriaprima);
                }

                if (currentcolindex == GetColumnIndex(gridStockLinea, "ClienteNombre") ) 
                {
                    MostrarAyudaStockLinea(enmAyuda.enmCliente);
                }

                if (currentcolindex == GetColumnIndex(gridStockLinea, "CodigoAlmacen"))
                {
                    MostrarAyudaStockLinea(enmAyuda.enmAlmacen);
                }

                // Traer todo las ordenes de trabajo 
                if (currentcolindex == GetColumnIndex(gridStockLinea, "IN07ORDENTRABAJO"))
                {
                    MostrarAyudaStockLinea(enmAyuda.enmStockLinea);
                }
                if (currentcolindex == GetColumnIndex(gridStockLinea, "IN07CALIDADMP"))
                {
                    MostrarAyudaStockLinea(enmAyuda.enmCalidadMP);
                }
               
            }

            //  Metodo para copiar y pegar valor de celda
            bool isRowSelected = this.gridStockLinea.SelectionMode == GridViewSelectionMode.FullRowSelect;
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (isRowSelected)
                    CopyRow();
                else
                    CopyCell();

            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                if (isRowSelected)
                    PasteRow();
                else
                    PasteCell();
            }
        }
        private void CopyCell()
        {
            try
            {
                GridViewRowInfo row = this.gridStockLinea.CurrentRow;
                int currentCellIndex = this.gridStockLinea.CurrentCell.ColumnIndex;
                valores = null;
                valores = new object[1];
                switch (this.gridStockLinea.Columns[currentCellIndex].Name)
                {

                    case "DesAlmacen":
                        valores[0] = this.gridStockLinea.CurrentRow.Cells["DesAlmacen"].Value;
                        break;
                    case "CodigoAlmacen":
                        valores[0] = this.gridStockLinea.CurrentRow.Cells["CodigoAlmacen"].Value;
                        break;
                    case "ProvMatPrimaNombre":
                        valores[0] = this.gridStockLinea.CurrentRow.Cells["IN07PROVMATPRIMA"].Value;
                        break;
                    case "ClienteNombre":
                        valores[0] = this.gridStockLinea.CurrentRow.Cells["IN07CODCLI"].Value;
                        break;
                    default:
                        valores[0] = this.gridStockLinea.CurrentCell.Value;
                        break;
                }
            }
            catch (Exception ex)
            { }
            
        }

        private void PasteCell()
        {
            try
            {
                if (valores != null)

                    if (this.gridStockLinea.SelectedCells.Count > 1)
                    {
                        for (int i = 0; i < this.gridStockLinea.SelectedCells.Count; i++)
                        {
                            this.gridStockLinea.SelectedCells[i].Value = valores[0];
                        }
                    }
                    else
                    {
                        GridViewRowInfo row = this.gridStockLinea.CurrentRow;

                        int currentCellIndex = this.gridStockLinea.CurrentColumn.Index;
                        string[] almacenarray = null;
                        switch (this.gridStockLinea.Columns[currentCellIndex].Name)
                        {
                            case "ProvMatPrimaNombre":
                                row.Cells["IN07PROVMATPRIMA"].Value = valores[0];
                                ObtenerDescripcionStockLinea(enmAyuda.enmprovmateriaprima, valores[0].ToString());
                                break;
                            case "ClienteNombre":
                                row.Cells["IN07CODCLI"].Value = valores[0];
                                ObtenerDescripcionStockLinea(enmAyuda.enmCliente, valores[0].ToString());
                                break;
                            case "DesAlmacen":
                                row.Cells["CodigoAlmacen"].Value = valores[0].ToString();
                                //ObtenerDescripcionStockLinea(enmAyuda.enmAlmacen, valores[0].ToString());
                                break;
                            case "CodigoAlmacen":
                                row.Cells["CodigoAlmacen"].Value = valores[0].ToString();
                                break;
                            default:
                                this.gridStockLinea.CurrentRow.Cells[currentCellIndex].Value = valores[0].ToString();
                                break;
                        }

                    }
            }
            catch (Exception ex)
            { 
            
            }
        }
        object[] valores = null;
        private void ClearCell()
        {
            this.gridStockLinea.CurrentCell.Value = null;
        }
        private void CopyRow()
        {
            try
            {
                valores = null;
                valores = new object[this.gridStockLinea.CurrentRow.Cells.Count];
                for (int c = 0; c < this.gridStockLinea.CurrentRow.Cells.Count; c++)
                {
                    valores[c] = this.gridStockLinea.CurrentRow.Cells[c].Value;
                }
            }
            catch (Exception ex)
            { 
            
            }

        }

        private void PasteRow()
        {
            try
            {
                //validamos si tenemos registro para pegar
                if (valores != null)
                {
                    //primero recorremos por fila
                    for (int f = 0; f < this.gridStockLinea.SelectedRows.Count; f++)
                    {
                        //    //recorremos por celdas para copai la data
                        for (int c = 0; c < this.gridStockLinea.SelectedRows[f].Cells.Count; c++)
                        {
                            this.gridStockLinea.SelectedRows[f].Cells[c].Value = valores[c];
                            //en caso de ser la columna de almacen 
                            if (gridStockLinea.SelectedRows[f].Cells[c].Value != null)
                            {
                                if (gridStockLinea.SelectedRows[f].Cells[c].ColumnInfo.Index == gridStockLinea.Columns["CodigoAlmacen"].Index)
                                    //traer la descripcion del codigo de almacen copiado                                
                                    ObtenerDescripcionStockLinea(enmAyuda.enmAlmacen, gridStockLinea.SelectedRows[f].Cells[c].Value.ToString());

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            { 
            
            }


        }
        private void clearRow()
        {
            foreach (GridViewCellInfo celda in this.gridStockLinea.CurrentRow.Cells)
            {
                celda.Value = null;
            }
        }
        private void ObtenerDescripcionStockLinea(enmAyuda tipoAyuda, string codigo)
        {
            string descripcion = string.Empty;
            switch (tipoAyuda)
            { 
                case  enmAyuda.enmCliente:
                    this.gridStockLinea.CurrentRow.Cells["ClienteNombre"].Value = null;
                        if (!string.IsNullOrEmpty(codigo)) {
                            codigo = Logueo.CodigoEmpresa + "01" + codigo ;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CLIENTE", out descripcion);
                            this.gridStockLinea.CurrentRow.Cells["ClienteNombre"].Value = descripcion;                                                        
                        }
                    break;
                case enmAyuda.enmprovmateriaprima:
                    
                    if (codigo != "")
                    {
                        codigo = Logueo.CodigoEmpresa + "10" + codigo;
                        GlobalLogic.Instance.DameDescripcion(codigo, "PROVMATERIA", out descripcion);
                        this.gridStockLinea.CurrentRow.Cells["ProvMatPrimaNombre"].Value = descripcion;
                    }
                    break;
                case enmAyuda.enmAlmacen:
                    if (codigo != "")
                    {
                        codigo = Logueo.CodigoEmpresa + codigo;
                        GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                        this.gridStockLinea.CurrentRow.Cells["DesAlmacen"].Value = descripcion;
                    }
                    break;
                default:
                    break;
            }
        }
        private void btnGuardarStockLinea_Click(object sender, EventArgs e)
        {
            //Grabar datos de Grid Stock Linea
            try
            {
                int x = 0;
                string[] filas;
                foreach (GridViewRowInfo fila in this.gridStockLinea.Rows)
                {
                    if (fila.Cells["IN07ORDENTRABAJO"].Value != null)
                    {
                        x++;
                    }

                }

                filas = new string[x];

                //comenzar la lectura de los datos de la grlla
                int i = 0;
                foreach (GridViewRowInfo row in this.gridStockLinea.Rows)
                {
                    if (row.Cells["CodigoArticulo"].Value != null)
                    {
                        filas[i] = Util.convertiracadena(row.Cells["CodigoArticulo"].Value) + "|" + //  ProductoCod
                        Util.convertiracadena(i + 1) + "|" + // nro orden
                       Util.convertiracadena(row.Cells["IN07PEDVEN"].Value) + "|" + //Pedventa
                        Util.convertiracadena(row.Cells["IN07ORDENTRABAJO"].Value) + "|" + //OT
                        Util.convertiracadena(row.Cells["IN07PROVMATPRIMA"].Value) + "|" + //ProMatP
                        Util.convertiracadena(row.Cells["NroCaja"].Value) + "|" + //NroCaja
                        Util.convertiracadena(row.Cells["IN07CODCLI"].Value) + "|" + //Cliente
                        Util.convertiracadena(row.Cells["NroPedidoVenta"].Value) + "|" + //ClientePedidoNro
                        Util.convertiracadena(row.Cells["CodigoAlmacen"].Value) + "|" + // AlmCodigo
                        Util.convertiracadena(row.Cells["UnidadMedida"].Value) + "|" + // UniMed
                        Util.convertiracadena(row.Cells["Ancho"].Value) + "|" + //ancho
                        Util.convertiracadena(row.Cells["Largo"].Value) + "|" + //Largo
                           Util.convertiracadena(row.Cells["Alto"].Value) + "|" + //Alto
                           Util.convertiracadena(row.Cells["Cantidad"].Value) + "|" +//Cantidad
                           Util.convertiracadena(row.Cells["in07observacion"].Value) + "|" +// observacion

                           // Orden Trabajo
                           Util.convertiracadena(row.Cells["IN07ORDENTRABAJO"].Value) + "|" +  //IngLineaOT
                            // Nro de caja
                           Util.convertiracadena(row.Cells["IngLineanroCaja"].Value) + "|" + //IngNroCaja
                            // Alm cod
                           Util.convertiracadena(row.Cells["IngLineaAlmCod"].Value) + "|" + //IngAlmCod
                            // linea codigo producto
                           Util.convertiracadena(row.Cells["CodigoArticulo"].Value) + "|" +
                           //Calidad Materia Prima
                           Util.convertiracadena(row.Cells["IN07CALIDADMP"].Value); //IngLineaProductoCod

                        i++;
                    }
                }
                Movimiento mov = new Movimiento();
                mov.CodigoEmpresa = Logueo.CodigoEmpresa;
                mov.Anio = Logueo.Anio; mov.Mes = Logueo.Mes; mov.CodigoTipoDocumento = txtCodigoTipDoc.Text.Trim();
                mov.CodigoDocumento = txtNroDocumento.Text.Trim();
                string msj = string.Empty;
                int flag = 0;
                DocumentoLogic.Instance.InsertarStockLinea(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, txtCodigoTipDoc.Text.Trim(),
                    txtNroDocumento.Text.Trim(), txtCodTransa.Text.Trim(), string.Format("{0:yyyyMMdd}", dtpFechaDoc.Value.ToShortDateString(), 103),
                    Util.ConvertiraXMLStockLinea(filas), out flag, out msj);
                
                if (flag == 0)
                {
                    MessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OcultarStockLinea();
                    CargarMovimiento();
                }
                else if (flag == -1)
                {
                    MessageBox.Show(msj, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error :" + ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void gridStockLinea_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Index == this.gridStockLinea.CurrentRow.Cells["CodigoAlmacen"].ColumnInfo.Index)
            {
                ObtenerDescripcionStockLinea(enmAyuda.enmAlmacen,
                this.gridStockLinea.CurrentRow.Cells["CodigoAlmacen"].Value.ToString());
            }
        }

        private Point MouseDownLocation;

        private void rpCabStockLinea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void rpCabStockLinea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rpCabStockLinea.Left = e.X + rpCabStockLinea.Left - MouseDownLocation.X;
                rpCabStockLinea.Top = e.Y + rpCabStockLinea.Top - MouseDownLocation.Y;
            }
        }

        private void gridStockLinea_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name == "CodigoArticulo" || e.Column.Name == "DescripcionArticulo" ||
                e.Column.Name == "UnidadMedida" || e.Column.Name == "Ancho" ||
                e.Column.Name == "Largo" || e.Column.Name == "Alto" ||
                e.Column.Name == "Cantidad" || e.Column.Name == "IN07ORDENTRABAJO" ||
                e.Column.Name == "DesAlmacen")
                e.Cancel = true;

        }
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            //validar datos del Grid Stock Linea
        }
        
        #endregion

        //private void dtpFechaDoc_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Up)
        //    {
        //        this.txtCodTransa.Focus();
        //    }
        //    else if (e.KeyValue == (char)Keys.Down)
        //    {
        //        this.txtCodigoTipDoc.Focus();
        //    }
        //}
        

        private void dtpFechaDoc_KeyDown_1(object sender, KeyEventArgs e)
        {
            this.dtpFechaDoc.ReadOnly = (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) ? true : false;
        }

        private void btnAddDetalle_ClientSizeChanged(object sender, EventArgs e)
        {

        } 

        //private void dtpFechaDoc_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Util.SendTab(e.KeyCode.GetHashCode());
        //    //this.dtpFechaDoc.ReadOnly = (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) ? true : false;

        //}

      
    

        
                                              
    }
}

