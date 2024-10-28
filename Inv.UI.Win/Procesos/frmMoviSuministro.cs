using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Data.Linq;

using Telerik.Windows.Controls;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Inv.BusinessEntities.DTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Configuration;
namespace Inv.UI.Win
{
    public partial class frmMoviSuministro : frmBaseReg
    {
        public static frmMoviSuministro formulario;
        private frmDocuSuministro FrmParent { get; set; }
        private static frmMoviSuministro _aForm;

        public static frmMoviSuministro Instance(frmDocuSuministro mdiPrincipal)
        {
            
            if (_aForm != null) return new frmMoviSuministro(mdiPrincipal);
            _aForm = new frmMoviSuministro(mdiPrincipal);
            return _aForm;
        }

        private bool isLoaded = false;
        private bool isOpened = false;
        bool tbSubscribed = false;

        private string tipoDocumento = string.Empty;
        private string nroDocumento = string.Empty;

        private bool esEntrada = false;
        public string _eCodigo { get; set; }
        private string _codigoAlmacenSeleccionado = string.Empty;
        private string _StockAlmacenSeleccionado = string.Empty;
        private string TipoSedeEjecutaSistema = ConfigurationSettings.AppSettings["sedetipodondeseejecutaelsistema"];

        private enmAyuda _tipoAyuda;

        ColumnGroupsViewDefinition columnGroupsView;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbGuardar;
        public int fila = 0;

        public frmMoviSuministro(frmDocuSuministro padre)
        {
            InitializeComponent();
            FrmParent = padre;
            this.gridControl.CellEndEdit += gridControl_CellEndEdit; // Asocia el evento

            Util.ConfigGridToEnterNavigation(gridControl);
            Estado = FrmParent.Estado;

            if (Estado == FormEstate.New)
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
            CrearColumnas();
            Control ctrl = FrmParent.ParentForm.Controls.Find("radDock1", true)[0];
            this.MdiParent = FrmParent.ParentForm;
            ((RadDock)(ctrl)).ActivateMdiChild(this);
        }
        private void CrearColumnas()
        {
            RadGridView grilla = CreateGridVista(this.gridControl);

            this.CreateGridColumn(grilla, "Orden", "Orden", 0, "", 60, false, true, false);
            this.CreateGridColumn(grilla, "Cod.Almacén", "CodigoAlmacen", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Almacén", "DesAlmacen", 0, "", 120, false, true, true);

            this.CreateGridColumn(grilla, "Código \nProducto", "CodigoArticulo", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilla, "Descripción", "DescripcionArticulo", 0, "", 200, true, false, true);
                        AddCmdButtonToGrid(grilla, "btnMemo", "", "btnMemo");
            CreateGridColumn(grilla, "Memo", "Memo", 0, "", 70, false, true, false);//contenido de memmo
            this.CreateGridColumn(grilla, "Uni.Med", "UnidadMedida", 0, "", 50, false, true, true);

            this.CreateGridColumn(grilla, "Cantidad", "Cantidad", 0, "{0:F2}", 90,
                                                    false, true, true, false, "right");


            this.CreateGridDecimalColumn(grilla, "Costo Unidad", "CostoUnidad", 0, "{0:F6}", 100, false, true, true,
                false, "right");
            // oculto
            this.CreateGridColumn(grilla, "Importe", "Importe", 0, "{0:###,###0.00}", 120, false, false, true, true, "right");
            this.CreateGridColumn(grilla, "Observaciones", "in07observacion", 0, "", 200, false, true, true);

            //flag para validar si es un registro pendiente de grabar o actualizar
            this.CreateGridColumn(grilla, "flag", "flag", 0, "", 0, false, true, false);

            //BLOQUES
            this.CreateGridColumn(grilla, "BLOQUECODIGO", "CodBloEmp", 0, "", 60, false, true,false);
            this.CreateGridColumn(grilla, "BLOQUECODIGOPROVEEDOR", "CodBloqProv", 0, "", 60, false, true, false);
            //END BLOQUES

            //LARGO ANCHO - PLANTA Y CANTERA
            this.CreateGridColumn(grilla, "Largo", "Largo", 0, "", 60, false, true, false);
            this.CreateGridColumn(grilla, "Ancho", "Ancho", 0, "", 60, false, true, false);
            this.CreateGridColumn(grilla, "Alto", "Alto", 0, "", 60, false, true, false);
            this.CreateGridColumn(grilla, "LargoCan", "LargoCan", 0, "", 60, false, true, false);
            this.CreateGridColumn(grilla, "AnchoCan", "AnchoCan", 0, "", 60, false, true, false);
            this.CreateGridColumn(grilla, "AltoCan", "AltoCan", 0, "", 60, false, true, false);
            //END LARGO ANCHO 

            agregarBoton();
            this.gridControl.Columns["btnGrabar"].MinWidth = 30;
            this.gridControl.Columns["btnCancelar"].MinWidth = 30;
            this.gridControl.Columns["btnEliminar"].MinWidth = 30;
            this.gridControl.Columns["btnEditar"].MinWidth = 30;


            string[] columnas = new[] { "Cantidad", "CostoUnidad", "Importe" };
            Util.AddGridSummarySum(gridControl, columnas);

        }
        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
            //Grid.Columns[NameButon].BestFit();
        }

        private void agregarBoton()
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

        }
        
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {
           

            frmBusqueda frm;

            string codigoSeleccionado = string.Empty;
            string codigoArticulo = "";
            string descripcion = "";
   
            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoDocumento:
                   
                    frm = new frmBusqueda(tipoAyuda, esEntrada, Logueo.PS_codnaturaleza);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {

                        codigoSeleccionado = frm.Result.ToString().Split('|')[0];
                        if (codigoSeleccionado != "") 
                            txtCodigoTipDoc.Text = codigoSeleccionado;
                             txtDesTipDoc.Text = frm.Result.ToString().Split('|')[1];
                        string chkmanual = frm.Result.ToString().Split('|')[2];

                        if (chkmanual == "M")
                        {
                            txtNroDocumento.Enabled = true;
                        }
                        else
                        {
                            txtNroDocumento.Enabled = false;
                        }
                        //Llama al configurador
                        ConfigurarDocumento(txtCodigoTipDoc.Text);
                    }
                    
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
                    frm = new frmBusqueda(tipoAyuda, Logueo.TipoAnalisisProveedor);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodProveedor.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmCtaCteDesc:
                    frm = new frmBusqueda(tipoAyuda, txtTipoAnalisis.Text);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtdocrespaldoctacte.Text = codigoSeleccionado;
                    if (txtCodProveedor.Enabled == true) { this.txtCodProveedor.Text = codigoSeleccionado; }
                    if (txtCodCliente.Enabled == true) { this.txtCodCliente.Text = codigoSeleccionado; }

                  //End {HUARAL}

                    break;
                case enmAyuda.enmPedido:
                    break;
                case enmAyuda.enmCliente:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null) 
                    {
                        codigoSeleccionado = frm.Result.ToString();
                        txtCodCliente.Focus();
                    }
                        
                    if (codigoSeleccionado != "")
                    {
                        bool estado = txtCodCliente.ContainsFocus;
                        
                        //if (txtCodCliente.Focused == true || txtDescCliente.Focused == true)
                        if (txtCodCliente.ContainsFocus == true)
                        {
                            descripcion = "";
                            txtCodCliente.Text = codigoSeleccionado;
                            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + "01" + txtCodCliente.Text,
                                "CLIENTE", out descripcion);
                            txtDescCliente.Text = descripcion;
                        }
                        else if(gridControl.Focused == true) {
                            this.gridControl.CurrentRow.Cells["IN07CODCLI"].Value = codigoSeleccionado;
                            ObtenerDescripcion(enmAyuda.enmCliente, codigoSeleccionado);
                        }                                                
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
                case enmAyuda.enmarticulosconstocksuministros:
                    frm = new frmBusqueda(tipoAyuda, this._codigoAlmacenSeleccionado);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    
                        string codigoArticulopv = string.Empty;

                    if (codigoSeleccionado != "")
                    {
                        codigoArticulopv = codigoSeleccionado;
                        string[] separado = codigoArticulopv.Split('¦');

                        string articulo = separado[0];
                        string articulodesc = separado[1];
                        string articulounimed = separado[2];
                        _StockAlmacenSeleccionado = separado[3];

                     string transaccion = string.Empty;
                     string codigotran = Logueo.CodigoEmpresa + this.txtCodigoTipDoc.Text;
                     GlobalLogic.Instance.DameDescripcion(codigotran, "TIPDOCMOV", out transaccion);
             

                            if ((transaccion == "S") && (double.Parse(_StockAlmacenSeleccionado) <= 0) && TipoSedeEjecutaSistema == "PRODUCCION")  
                                {
                                            RadMessageBox.Show("No se puede realizar salida, Stock <= 0", "Validacion", MessageBoxButtons.OK, RadMessageIcon.Error);
                                            gridControl.CurrentColumn = this.gridControl.Columns["CodigoArticulo"];
                                            break; 
                                }
                        else
                            {
                                this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value = articulo.Trim();
                                this.gridControl.CurrentRow.Cells["DescripcionArticulo"].Value = articulodesc.Trim();
                                this.gridControl.CurrentRow.Cells["UnidadMedida"].Value = articulounimed.Trim();
                               // this.gridControl.CurrentRow.Cells["cantidad"].IsSelected = true;
                                gridControl.CurrentColumn = this.gridControl.Columns["cantidad"];

                            //ABRIR FLOTANTE
                                GridViewRowInfo info = this.gridControl.CurrentRow;
                                //string CodBloque = Util.GetCurrentCellText(info, "CodBloEmp");
                                string CodigoAlmacen = Util.GetCurrentCellText(info, "CodigoAlmacen");
                                if (CodigoAlmacen == Logueo.MP_AlmxDefecto)
                            {

                                VerObservacion();
                                ActiveControl = txtCodBloque;
                                txtCodBloque.Focus();
                            }
                                
                            }
                    }

                    break;
               
                case enmAyuda.enmAlmacen:
                    
                    frm = new frmBusqueda(tipoAyuda, Logueo.PS_codnaturaleza+"01", "");
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    
                        if (codigoSeleccionado != "")
                    {
                        this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value = codigoSeleccionado.Trim();
                        this.gridControl.CurrentRow.Cells["CodigoArticulo"].IsSelected = true;

                    }

                    break;
                #region "comentario"
                #endregion
                case enmAyuda.enmMoneda:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();

                    if (codigoSeleccionado != "") this.txtCodMoneda.Text = codigoSeleccionado;

                    break;
         
                case enmAyuda.enmOrdenTrabajo:
                    frm = new frmBusqueda(enmAyuda.enmOrdenTrabajo);
                    frm.ShowDialog();
                    break;
                case enmAyuda.enmOrdenCompra:
                    if (txtAnioOrdCompra.Text.Trim() != "")
                    {
                        frm = new frmBusqueda(enmAyuda.enmOrdenCompra, txtAnioOrdCompra.Text.Trim());
                    }else{
                        Util.ShowAlert("ingresar año");
                        txtAnioOrdCompra.Focus();
                        return;
                    }
                    
                    
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    txtOrdCompra.Text = frm.Result.ToString().Split('|')[1];
                    txtOrdCompraProv.Text =frm.Result.ToString().Split('|')[0];
                    // frm.Result.ToString().Split('|')[1]
                    break;
                case enmAyuda.enmAlmacenTodos:
                    frm = new frmBusqueda(enmAyuda.enmAlmacenTodos);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    txtAlmEmisorCod.Text =  frm.Result.ToString();
                    descripcion = "";
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtAlmEmisorCod.Text, "ALMACEN", out descripcion);
                    txtAlmEmisorDesc.Text = descripcion;
                    break;
                case enmAyuda.enmMaquinaInventario:
                    frm = new frmBusqueda(enmAyuda.enmMaquinaInventario);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    txtCodMaquina.Text = frm.Result.ToString();
                    descripcion = "";
                    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodMaquina.Text, "MAQUINA", out descripcion);
                    txtDescMaquina.Text = descripcion;
                    break;
                default:
                    break;
            }
            this.KeyPreview = true;
        }
        /// <summary>
        /// Carga de los detalles del movimeinto en la grilla del documento.
        /// </summary>
        private void CargarMovimiento()
        {
            try
            {
                string OrdenTrabajo = "";
                this.gridControl.DataSource = DocumentoLogic.Instance.TraerMovimiento(Logueo.CodigoEmpresa, 
                    Logueo.Anio, Logueo.Mes,this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, OrdenTrabajo);

            GridViewRowInfo row = this.gridControl.CurrentRow;
            txtLargoPlanta.Text = Util.GetCurrentCellText(row, "Largo");

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
                            codigo = Logueo.CodigoEmpresa + codigo + Logueo.PS_codnaturaleza + (this.esEntrada ? "E" : "S");
                            GlobalLogic.Instance.DameDescripcion(codigo, "TIPDOC", out descripcion);
                            this.txtDesTipDoc.Text = descripcion;
                            ConfigurarDocumento(txtCodigoTipDoc.Text);

                            TipoDocumento registro =  TipoDocumentoLogic.Instance.TraerTipoDocumentoRegistro(Logueo.CodigoEmpresa,
                                                       txtCodigoTipDoc.Text.Trim());

                            if (Estado == FormEstate.New)
                            {
                                if (Util.convertiracadena(registro.in12FlagGeneraDocNum) != "")
                                {
                                    txtNroDocumento.Enabled = registro.in12FlagGeneraDocNum == "M" ? true : false;
                                }
                                    
                                //if (registro.in12longitudDocNum > 0)
                                //{
                                //    txtNroDocumento.MaxLength = registro.in12longitudDocNum;
                                //}
                            }                            
                            
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
                            codigo = Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROVEEDOR", out descripcion);
                            this.txtDesProveedor.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmCtaCteDesc:
                        this.txtdocrespaldoctacteDesc.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + txtTipoAnalisis.Text + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CTACTE", out descripcion);
                            this.txtdocrespaldoctacteDesc.Text = descripcion;
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
                  
           
                    // F1 - CLIENTE
                    case enmAyuda.enmCliente:


                        if (txtCodCliente.Text.Trim() != "") {
                            
                            string descripcionCliente = "";
                            GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + "01" + this.txtCodCliente.Text, 
                                "PROVEEDOR", out descripcionCliente);
                            this.txtDescCliente.Text = descripcionCliente;
                        }

                        this.gridControl.CurrentRow.Cells["ClienteNombre"].Value = null;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + "01" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "CLIENTE", out descripcion);
                            this.gridControl.CurrentRow.Cells["ClienteNombre"].Value = descripcion;
                        }

                        break;
                    // F1 - PROV.MATERIA PRIMA
                    case enmAyuda.enmprovmateriaprima:

                        if (codigo != "")
                        {
                            codigo = Logueo.CodigoEmpresa + "10" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROVMATERIA", out descripcion);
                            this.gridControl.CurrentRow.Cells["ProvMatPrimaNombre"].Value = descripcion;
                        }
                        break;

                    //F1 - ALMACEN
                    case enmAyuda.enmAlmacen:
                        if (codigo != "")
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

                //throw;
            }


        }
        /// <summary>
        /// Bloquear datos (cajas de datos) de la acebecera del documento
        /// </summary>
        private void DeshabilitarCamposConfigTpDoc()
        {
            //bloqyue controles (cajas texto de la cabecera)
            this.txtAnioOrdCompra.Enabled = false;
            this.txtOrdCompra.Enabled = false;
            this.txtOrdCompraProv.Enabled = false;
            this.txtCodProveedor.Enabled = false;
            this.txtCodCentroCosto.Enabled = false;
            this.txtCodResponsable.Enabled = false; // Lotes
            this.txtAlmEmisorCod.Enabled = false;
            this.txtCodObra.Enabled = false;
            this.txtCodMaquina.Enabled = false;            
            this.txtCodRepReceptor.Enabled = false;
            this.txtCodCliente.Enabled = false;
        }
        #region"Posiciones de permisos"
        /*
         proveedor -> 0
         * centro de costo ->1
         * responsable almacen ->2 
         * responsable de recepcion ->3
         *  orden compra ->4
         *  ->5
         *  Maquina ->6
         *  Materia Prima ->7
         *  Lote -> 8
         *  Cantera  ->9
         *  Contratista -> 10
         *  Nota salida -> 11
         *  comprobante salida almacen -> 12
         *  linea -> 13
         *  proceso -> 14
         *  turno -> 15
         */
        #endregion
        private void ConfigurarDocumento(string tipoDocumento)
        {
            DeshabilitarCamposConfigTpDoc();

            string variable = TipoDocumentoLogic.Instance.DameVariable(Logueo.CodigoEmpresa, tipoDocumento);
            //Configura el documento

            if (string.IsNullOrEmpty(variable)) return;
            if (variable.Trim().Length < 16) return;

            //proveedor -- 1
            this.txtCodProveedor.Enabled = (variable.Substring(0, 1).CompareTo("1") == 0);
            //centro de costos -- 2
            this.txtCodCentroCosto.Enabled = (variable.Substring(1, 1).CompareTo("1") == 0);

            //Responsable de Almacen -- 3
            this.txtCodResponsable.Enabled = (variable.Substring(2, 1).CompareTo("1") == 0);

            //Responsable de recepcion --4

            this.txtCodRepReceptor.Enabled = (variable.Substring(3, 1).CompareTo("1") == 0);

            //Obra -- 5
            this.txtCodObra.Enabled = (variable.Substring(4, 1).CompareTo("1") == 0);

            //orden de trabajo / orden de compra //6
            this.txtOrdCompra.Enabled = (variable.Substring(5, 1).CompareTo("1") == 0);
            this.txtAnioOrdCompra.Enabled = (variable.Substring(5, 1).CompareTo("1") == 0);
            if (this.Estado == FormEstate.New)
            {
                if (this.txtAnioOrdCompra.Enabled && this.txtAnioOrdCompra.Text.Trim() == "")
                {
                    //por defecto llenar con el año del periodo seleccionado
                    
                    this.txtAnioOrdCompra.Text = Logueo.Anio;
                }
            }
            
            
            
            //Maquina // 7
            this.txtCodMaquina.Enabled = (variable.Substring(6, 1).CompareTo("1") == 0);

            //Materia Prima - 8          
            // Lote - 9 --=> en Inventario de suministros debe activar a Responsable receptor

            // cantera - 10
            //contratista - 11 
            // nota salida - 12 

            // comprobante salida almacen -- 13
            //txtAnioOrdCompra.Enabled = (variable.Substring(12, 1).CompareTo("1") == 0);
            //txtOrdCompra.Enabled = (variable.Substring(12, 1).CompareTo("1") == 0);

            //Linea - 14

            //Proceso -- 15
            //Turno - 16
            //cliente -- 17
            string activarcodcliente = variable.Substring(16, 1);
            this.txtCodCliente.Enabled = (variable.Substring(16, 1).CompareTo("1") == 0);

            //txtCodCliente.Enabled = false;
            //txtDescCliente.Enabled = false;

            if (!this.txtCodProveedor.Enabled) this.txtCodProveedor.Text = string.Empty;
            if (!this.txtCodCliente.Enabled) this.txtCodCliente.Text = string.Empty;
            if (!this.txtCodCentroCosto.Enabled) this.txtCodCentroCosto.Text = string.Empty;
            if (!this.txtCodResponsable.Enabled) this.txtCodResponsable.Text = string.Empty;
            if (!this.txtCodRepReceptor.Enabled) this.txtCodRepReceptor.Text = string.Empty;
            if (!this.txtCodObra.Enabled) this.txtCodObra.Text = string.Empty;
            if (!this.txtCodMaquina.Enabled) this.txtCodMaquina.Text = string.Empty;

            if (!this.txtAnioOrdCompra.Enabled) this.txtAnioOrdCompra.Text = string.Empty;
            if (!this.txtOrdCompra.Enabled) this.txtOrdCompra.Text = string.Empty;
            if (!this.txtOrdCompraProv.Enabled) this.txtOrdCompraProv.Text = string.Empty;
            if (!this.txtAlmEmisorCod.Enabled) this.txtAlmEmisorCod.Text = string.Empty;
            if (!this.txtCodCliente.Enabled) this.txtCodCliente.Text = string.Empty;
            Activarcontrolesdeayuda();
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            decimal DivisionTotal = 0;
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["Importe"].ColumnInfo.Index) 
            {
                //enter al importe
                if (e.KeyCode == Keys.Enter) 
                {
                    //decimal cantidad = Convert.ToDecimal(gridControl.CurrentRow.Cells["Cantidad"].Value.ToString());
                    //decimal Importe = Convert.ToDecimal(gridControl.CurrentRow.Cells["Importe"].Value.ToString());
                    //decimal CostoUnidad = Convert.ToDecimal(gridControl.CurrentRow.Cells["CostoUnidad"].Value.ToString());
                    ////if (cantidad != 0 && Importe != 0)
                    //{
                        
                        //if (cantidad != 0 && Importe != 0 && CostoUnidad == 0)
                        //{
                           
                        //   DivisionTotal = Importe / cantidad; 
                        //    this.gridControl.CurrentRow.Cells["CostoUnidad"].Value = DivisionTotal.ToString();
                        //}

                      
                    }
                //}
            }            
            if (this.gridControl.RowCount == 0)
                return;

            //F1-Pedido de venta
            if (this.gridControl.CurrentRow.Cells["flag"].Value == null) return;


            //F1-Almacen
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["CodigoAlmacen"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                    //if (double.Parse(this.gridControl.CurrentRow.Cells["Orden"].Value.ToString()) == 0)
                        this.MostrarAyuda(enmAyuda.enmAlmacen);
            }

            //F1-Articulo
            if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["CodigoArticulo"].ColumnInfo.Index)
            {
                if (e.KeyCode == Keys.F1)
                {
                    //valida si tiene orden de trabajo para llamar a la ayuda de articulo                    
                    //if (this.gridControl.CurrentRow.Cells["CodigoArticulo"].Value == null &&
                    //    double.Parse(this.gridControl.CurrentRow.Cells["Orden"].Value.ToString()) == 0)
                    //{
                    //}
                        if (this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value == null)
                        {
                            RadMessageBox.Show("Debe seleccionar un Almacén", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                            return;
                        }

                        this._codigoAlmacenSeleccionado = this.gridControl.CurrentRow.Cells["CodigoAlmacen"].Value.ToString();
                        this.MostrarAyuda(enmAyuda.enmarticulosconstocksuministros);
                                            
                }
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

           
            
        }

        private void txtCodigoTipDoc_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTipoDocumento);
        }

        private void txtCodMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmMoneda);
            if (e.KeyCode == Keys.Enter) 
            {
                txtDesMoneda.Text = (txtCodMoneda.Text == "S") ? "Soles" : "Dolares";
            }
        }

        private void txtCodTransa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTransaccion);
        }

        private void txtAnioOrdCompra_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.F1)  this.MostrarAyuda(enmAyuda.enmOrdenCompra);
        }

        private void txtCodProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmProveedor);
        }

        private void txtCodCentroCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmCentroCosto);
        }

        private void txtCodResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmResponsable);
        }

        private void txtAlmEmisorCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmAlmacenTodos);
        }

        private void txtCodObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmObra);
        }

        private void txtCodMaquina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmMaquinaInventario);
        }

        private void txtCodRepReceptor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmResponsableReceptor);
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmCliente);
        }
     
        /// <summary>
        /// Habilitar controles(cajas de texto) de la cabecera del documento
        /// </summary>
        /// <param name="flag">true  para habilitar y false para deshabilitar </param>
        public void Habilitar(bool flag)
        {
            this.txtCodigoTipDoc.Enabled = flag;
            this.txtNroDocumento.Enabled = flag;
            this.dtpFechaDoc.Enabled = flag;
            this.txtCodTransa.Enabled = flag;
            this.txtNroReferencia.Enabled = flag;
            //this.txtdocrespaldoctacte.Enabled = flag;
            this.txtCodMoneda.Enabled = flag;
            this.txtAnioOrdCompra.Enabled = flag;
            this.txtOrdCompraProv.Enabled = flag;
            this.txtOrdCompra.Enabled = flag;
            this.txtCodObra.Enabled = flag;
            this.txtCodProveedor.Enabled = flag;
            this.txtCodMaquina.Enabled = flag;
            this.txtCodCliente.Enabled = flag;
            this.txtCodCentroCosto.Enabled = flag;
            this.txtCodResponsable.Enabled = flag;
            this.txtCodRepReceptor.Enabled = flag;
            this.txtdocrespaldoctacte.Enabled = flag;

        }
        /// <summary>
        /// Cargar datos en cabecera del documento
        /// </summary>
        private void CargarDocumento()
        {
            isLoaded = true;
            //Carga el documento y su detalle
            var documento = DocumentoLogic.Instance.ObtenerDocumento(Logueo.CodigoEmpresa,
                Logueo.Anio, Logueo.Mes, this.tipoDocumento, this.nroDocumento);
            if (documento != null)
            {

                this.txtCodigoTipDoc.Text = documento.TipoDoc;
                string descripcion = "";
                string TipoMovi = "";
                if (esEntrada)
                {
                    TipoMovi = "E";
                }
                else 
                {
                    TipoMovi = "S";
                }
         
                

                this.txtNroDocumento.Text = documento.CodigoDoc;

                this.dtpFechaDoc.Value = (DateTime)documento.FechaDoc;

                this.txtCodTransa.Text = documento.CodigoTransa;
                
                this.txtCodProveedor.Text = documento.CodigoProveedor;
                this.ObtenerDescripcion(enmAyuda.enmProveedor, this.txtCodProveedor.Text);
                
                this.txtCodMoneda.Text = documento.Moneda;
                this.ObtenerDescripcion(enmAyuda.enmMoneda, this.txtCodMoneda.Text);

                this.txtCodRepReceptor.Text = documento.ResponsableReceptor;
                this.txtCodResponsable.Text = documento.Responsable;

                this.txtCodCentroCosto.Text = documento.CodigoCentroCosto;
                this.txtCodObra.Text = documento.CodigoObra;
                
                this.txtTipoAnalisis.Text = documento.IN06DOCRESCTACTETIPANA;
                this.txtdocrespaldoctacte.Text = documento.IN06DOCRESCTACTENUMERO;
                this.ObtenerDescripcion(enmAyuda.enmCtaCteDesc, this.txtdocrespaldoctacte.Text);                                
                            
                this.txtNroReferencia.Text = documento.ReferenciaDoc;

                this.txtCodMaquina.Text = documento.CodigoMaquina;
                this.txtCodCliente.Text = documento.CodigoCliente;
                this.ObtenerDescripcion(enmAyuda.enmCliente, this.txtCodCliente.Text);
                
                this.txtAlmEmisorCod.Text = documento.CodigoAlmacenEmisor;
                this.txtOrdCompra.Text = documento.OrdenCompra;
                this.txtAnioOrdCompra.Text = documento.AnioOrdenCompra;

                //DAME DESCRIPCION
                //TipDoc
                GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodigoTipDoc.Text + "04" + TipoMovi.ToString(), "TIPDOC", out descripcion);
                this.txtDesTipDoc.Text = descripcion;
                //Doc Responsable
                GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodTransa.Text.ToString(), "TRANSAC", out descripcion);
                this.txtDesTransa.Text = descripcion;

                //Centro Costo
                GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodCentroCosto.Text.ToString(), "CENCOSTO", out descripcion);
                this.txtDesCentroCosto.Text = descripcion;
                
                //LLENAR CODBLOQUE Y CODBLOQUEPROVEEDOR
                //txtCodBloque.Text = documento

            }
        }


   

     
        private void txtCodigoTipDoc_TextChanged(object sender, EventArgs e)
        {
            //if (txtCodigoTipDoc.Text.Trim().Length == 0)
            //{
            //    DeshabilitarCamposConfigTpDoc();
            //    //habilitar el control numero documento segun flag

            //}
            //else
            //{
            //    string origennumercion="";
            //    this.ObtenerDescripcion(enmAyuda.enmTipoDocumento, this.txtCodigoTipDoc.Text);
            //    GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa+ txtCodigoTipDoc.Text, "ORIGENTIPO", out origennumercion);

            //    string numeroDocumento = "";
            //    if (origennumercion=="M")
            //         {
            //           txtNroDocumento.Text = "";
            //           txtNroDocumento.Enabled = true;
            //         }
            //    else
            //         {
            //            DocumentoLogic.Instance.DameNumeroDocumento(Logueo.CodigoEmpresa,
            //                Logueo.Anio, Logueo.Mes, txtCodigoTipDoc.Text.Trim(), out numeroDocumento);
            //            txtNroDocumento.Text = numeroDocumento;
            //            txtNroDocumento.Enabled = false;
            //          }
            //}
        }
        private void txtCodTransa_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmTransaccion, this.txtCodTransa.Text);
        }
        private void txtCodProveedor_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmProveedor, this.txtCodProveedor.Text);
            //Logueo.TipoAnalisisProveedor = "";
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
        BaseGridEditor _gridEditor;
        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.gridControl.ActiveEditor == null) { return; }
                    
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
                        else
                        {
                            return;
                        }
                    }

                    //Modo vista cancelar todo las ediciones
                    if (this.Estado == FormEstate.View)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (e.Column.Name == "flag")
                    {
                        e.Cancel = false;
                        return;
                    }
                    
                    if (e.Column.Name == "codigo" || e.Column.Name == "Cantidad" ||
                         e.Column.Name == "DesAlmacen" || e.Column.Name == "CostoUnidad")
                    {

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

                    _gridEditor = this.gridControl.ActiveEditor as BaseGridEditor;

                    if (_gridEditor != null)
                    {
                        RadItem editorElement = _gridEditor.EditorElement as RadItem;
                        editorElement.KeyDown += new KeyEventHandler(gridControl_KeyDown);
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

               

                if (e.Column.Name.CompareTo("CostoUnidad") == 0)
                {
                    
                    decimal cantidad = this.gridControl.CurrentRow.Cells["Cantidad"].Value != null ? decimal.Parse(this.gridControl.CurrentRow.Cells["Cantidad"].Value.ToString()) : 0;
                        //decimal.Parse(this.gridControl.CurrentRow.Cells["Cantidad"].Value.ToString());
                    decimal costoUnidad = this.gridControl.CurrentRow.Cells["CostoUnidad"].Value != null ? decimal.Parse(this.gridControl.CurrentRow.Cells["CostoUnidad"].Value.ToString()) : 0;
                    //costoUnidad = decimal.Parse(e.Value.ToString());
                    decimal subtotal = cantidad * costoUnidad;
                    this.gridControl.CurrentRow.Cells["Importe"].Value = subtotal.ToString();
                  
                    
                }
                if (e.Column.Name.CompareTo("Cantidad") == 0)
                {
                    decimal DivisionTotal = 0;
                    decimal cantidad = 0;
                    decimal costoUnidad = 0;

                    cantidad = this.gridControl.CurrentRow.Cells["Cantidad"].Value != null ? decimal.Parse(this.gridControl.CurrentRow.Cells["Cantidad"].Value.ToString()) : 0;
                    costoUnidad = this.gridControl.CurrentRow.Cells["CostoUnidad"].Value != null ? decimal.Parse(this.gridControl.CurrentRow.Cells["CostoUnidad"].Value.ToString()) : 0;

                        decimal subtotal = cantidad * costoUnidad;
                        this.gridControl.CurrentRow.Cells["Importe"].Value = subtotal.ToString();

                      

                }

                //Dividir el resultado antes de grabar, por si no le da enter en el campo Importe
                if (e.ColumnIndex == gridControl.Columns["Importe"].Index)
                {
                    decimal DivisionTotal = 0;
                    decimal cantidad = 0;
                    decimal Importe = Convert.ToDecimal(gridControl.CurrentRow.Cells["Importe"].Value.ToString());
                     cantidad = Convert.ToDecimal(gridControl.CurrentRow.Cells["Cantidad"].Value.ToString());
                     decimal CostoUnidad = Convert.ToDecimal(gridControl.CurrentRow.Cells["CostoUnidad"].Value.ToString());
                    
                    if (cantidad != 0 && Importe != 0 && CostoUnidad == 0)
                    {
                        DivisionTotal = Importe / cantidad;
                        string formatearDivision = DivisionTotal.ToString("F6");

                        this.gridControl.CurrentRow.Cells["CostoUnidad"].Value = formatearDivision;
                    }
                }
              //  decimal cantidad = this.gridControl.CurrentRow.Cells["Cantidad"].Value != null ? decimal.Parse(this.gridControl.CurrentRow.Cells["Cantidad"].Value.ToString()) : 0;
                

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
            if (_gridEditor != null)
            {
                RadItem editorElement = _gridEditor.EditorElement as RadItem;
                editorElement.KeyDown -= gridControl_KeyDown;
            }
            _gridEditor = null;

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
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, false, false,false);
                    return;
                }
                if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value == null) return;
                if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value.ToString() != "0"
                    && gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {// si es modo ver 
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true,true);
                    btnGuardarObservacion.Enabled = false;
                }
                else
                {// si es modo grabar o cancelar
                    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false,true);
                    btnGuardarObservacion.Enabled = true;
                }
                

            }

        }
        private void gridControl_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    this.gridControl.Focus();

            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        Util.SendTab(Keys.Enter.GetHashCode());
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }
        
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
         

            if (this.gridControl.Columns["btnGrabar"].IsCurrent)
            {
                GuardarDetalle(this.gridControl.CurrentRow);
                //ACTIVA LOS BOTONES DE LA CABECERA
                this.HabilitarBotonesCabecera(false,false,true,true,true,true,true,true);
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
                Estado = FormEstate.Edit;
            }
            if (Util.IsCurrentColumn(this.gridControl.CurrentColumn, "btnMemo"))
            {
                Estado = FormEstate.Edit;
                VerObservacion();
            }

        }
        public void LimpiarCamposgridflotante() 
        {
            txtCodBloque.Text = null;
            txtCodBloqueProveedor.Text = null;
            txtLargoPlanta.Text = null;
            txtAnchoPlanta.Text = null;
            txtAltoPlanta.Text = null;


            txtLargoCantera.Text = null;
            txtAnchoCantera.Text = null;
            txtAltoCantera.Text = null;

            txtTotalPlanta.Text = null;
            txtTotalCantera.Text = null;

            txtDiferencia.Text = null;
        }
        private void VerObservacion() 
        {
            try { 
                GridViewRowInfo info = gridControl.CurrentRow;
    
            string CodigoAlmacen = Util.GetCurrentCellText(info, "CodigoAlmacen");
            if (CodigoAlmacen == Logueo.MP_AlmxDefecto)
            {

                this.gpxObservacion.Visible = true;
                if (Estado == FormEstate.View || Estado == FormEstate.Edit)
                {
                    MostrarDatosVentanaEmergente();
                    CalcularVolumenBloque();
                    this.ActiveControl = txtCodBloque;
                    txtCodBloque.Focus();
                }

            }
            else 
            {
                this.gpxObservacion.Visible = false;
            }
          
            }catch(Exception ex)
            {
                Util.ShowError("ERROR:: Algo Salio Mal"+ex);
            }
        }

        //private void gpxObservacion_Shown(object sender, EventArgs e)
        //{
        //    // Establecer el foco en el TextBox al mostrar el formulario
        //    if (Estado == FormEstate.Edit || Estado == FormEstate.New)
        //    {
        //        txtCodBloque.Focus();
        //    }
        //}
        //private void gpxObservacion_Activated(object sender, EventArgs e)
        //{
        //    // Establecer el foco en el TextBox cada vez que el formulario se activa
        //    if (Estado == FormEstate.New || Estado == FormEstate.Edit)
        //    {
        //        txtCodBloque.Focus();
        //    }
        //}
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
                    info.Cells["Cantidad"].Value = 0;                    
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
                    info.Cells["Cantidad"].Value = 0;                    
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

               
            }

        
        }
        private void gridControl_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            RadTextBoxEditor tbEditor = this.gridControl.ActiveEditor as RadTextBoxEditor;
            if (tbEditor != null)
            {
                if (!tbSubscribed)
                {
                    tbSubscribed = true;
                    RadTextBoxEditorElement tbElement = (RadTextBoxEditorElement)tbEditor.EditorElement;
                    tbElement.KeyPress += new KeyPressEventHandler(tbElement_KeyPress);
                }
            }
        }

        void tbElement_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Util.IsCurrentColumn(gridControl.CurrentColumn, "CodigoArticulo"))
            {
                if (e.KeyChar != (char)Keys.F1)
                {
                    e.Handled = true;
                }
            }
            if (Util.IsCurrentColumn(gridControl.CurrentColumn, "CodigoAlmacen"))
            {
                if (e.KeyChar != (char)Keys.F1)
                {
                    e.Handled = true;
                }
            }
        }

        #region Agregar y quitar Item

        private void btnAddDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCamposgridflotante();
                this.gridControl.Focus();
                //Valida que la cabecera debe estar guardado
                //if (this.txtCodigoTipDoc.Enabled)
                //{
                //    RadMessageBox.Show("Para registrar detalles debe guardar el documento", "Aviso",
                //                        MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                //    return;
                //}


                if (this.gridControl.RowCount == 0)
                {
                    Estado = FormEstate.New;
                    //Agregamos una nueva fila a la grila 
                    this.KeyPreview = false;
                    GridViewRowInfo rowInfo = this.gridControl.Rows.AddNew();
                    rowInfo.Cells["Orden"].Value = 0;
                    rowInfo.Cells["CodigoAlmacen"].Value = "";// --> PRO09ALMACENCOD    
                    rowInfo.Cells["Cantidad"].Value = 0;
                    //Flag para indicar esta fila esta en modo edicion 
                    rowInfo.Cells["flag"].Value = "0";
                    
                    //Resaltar las celda de Ayuda - Color: Amarillo0
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoAlmacen"]);
                    
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);

                    //SendKeys.Send("-{TAB}");
                    Util.SetCellInitEdit(gridControl, "CodigoAlmacen");
                }
                else
                {
                    //Existe registro en el detalle, eotnces agregar fila segun esta condicion
                    // Capturo almacen Anterior
                    string AlmacenCodFilaAnt = this.gridControl.Rows[this.gridControl.RowCount - 1].Cells["CodigoAlmacen"].Value.ToString();


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

                    //this.gridControl.Focus();
                    //this.KeyPreview = false;
                    
                    //Agregar una nueva fila
                    GridViewRowInfo rowInfo = this.gridControl.Rows.AddNew();
                    //Resaltar las celda de ayuda de Color : Amarillo
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoAlmacen"]);
                    Util.ResaltarAyuda(rowInfo.Cells["CodigoArticulo"]);                                                                                

                    //Asginando valores vacio o cero para la nueva fila
                    //Asigno el codigo del ultimo almacen
                    rowInfo.Cells["Orden"].Value = 0;
                    //Flag para indicar esta fila en modo edicion                                        
                    rowInfo.Cells["Cantidad"].Value = 0;
                    rowInfo.Cells["flag"].Value = "0";
                    rowInfo.Cells["CodigoAlmacen"].Value = AlmacenCodFilaAnt;
                    //Iniciar esta celda para iniciar a digitar
                    rowInfo.Cells["CodigoAlmacen"].BeginEdit();
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
        bool ValidarDetalle(GridViewRowInfo fila)
        {

            GridViewRowInfo row = gridControl.CurrentRow;
            string CodigoAlmacen = Util.GetCurrentCellText(row, "CodigoAlmacen");
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
           
            if (txtCodBloque.Text == ""
         && txtCodBloqueProveedor.Text == ""
                //PLANTA
         && txtLargoPlanta.Text == ""
         && txtAnchoPlanta.Text == ""
         && txtAltoPlanta.Text == ""
                //CANTERA
         && txtLargoCantera.Text == ""
         && txtAnchoCantera.Text == ""
         && txtAltoCantera.Text == ""
                && CodigoAlmacen == Logueo.MP_AlmxDefecto)
            {
                Util.ShowError("ERROR:: Ingrese datos faltantes");
                return false;
            }
            // Validar Formato
            string codigoArticulo = fila.Cells["CodigoArticulo"].Value.ToString();
            string codigo = string.Empty;
            string tipcalculoarea = string.Empty;

            codigo = Logueo.CodigoEmpresa + Logueo.Anio + codigoArticulo;

            GlobalLogic.Instance.DameDescripcion(codigo, "FLAGTIPCALAREA", out tipcalculoarea);


            if (fila.Cells["Cantidad"] == null || Convert.ToDecimal(fila.Cells["Cantidad"].Value) == 0)
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
            Cursor.Current = Cursors.WaitCursor;
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

                mov.CodigoAlmacen = info.Cells["CodigoAlmacen"].Value == null ? null : info.Cells["CodigoAlmacen"].Value.ToString();
                mov.CodigoTransaccion = this.txtCodTransa.Text;
                mov.Transaccion = transaccion;
                if (info.Cells["Cantidad"].Value.ToString() == null || info.Cells["CostoUnidad"].Value.ToString() == null) { Util.ShowError("ERROR :: No se ha ingresado Cantidad o Costo Unidad, vuelva a intentarlo"); }
                mov.Cantidad = double.Parse(info.Cells["Cantidad"].Value.ToString());
                mov.CostoUnidad = double.Parse(info.Cells["CostoUnidad"].Value.ToString());
                mov.Importe = double.Parse(info.Cells["Importe"].Value.ToString());
                //mov.Areaxuni = double.Parse(info.Cells["Areaxuni"].Value == null ? "0" : info.Cells["Areaxuni"].Value.ToString());
                mov.FechaDoc = this.dtpFechaDoc.Value;

                //NUEVOS INPUTS
                //CODIGO BLOQUE 
                mov.CodBloEmp = txtCodBloque.Text;
                mov.CodBloqProv = txtCodBloqueProveedor.Text;
                //END CODIGO BLOQUE
                //PLANTA

                if (mov.CodigoAlmacen == Logueo.MP_AlmxDefecto)
                {
                    mov.Largo = double.Parse(txtLargoPlanta.Text);
                    mov.Ancho = double.Parse(txtAnchoPlanta.Text);
                    mov.Alto = double.Parse(txtAltoPlanta.Text);
                    //total

                    mov.LargoCan = double.Parse(txtLargoCantera.Text);
                    mov.AnchoCan = double.Parse(txtLargoCantera.Text);
                    mov.AltoCan = double.Parse(txtAltoCantera.Text);
                }

                //
                //END INPUTS

                //Trae numero de orden                
                mov.UnidadMedida = info.Cells["UnidadMedida"].Value == null ? null : info.Cells["UnidadMedida"].Value.ToString();
                mov.in07observacion = info.Cells["in07observacion"].Value == null ? null : info.Cells["in07observacion"].Value.ToString();
               

                
                string mensajeRetorno = string.Empty;
                int flag = 0;
                double orden = 0;

                if (double.Parse(info.Cells["Orden"].Value.ToString()) == 0)
                {
                    //NUEVO              
                    //Si el detall no tiene orden de  trabajo                
                    orden = 0;

                    DocumentoLogic.Instance.TraerNroOrden(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.txtCodigoTipDoc.Text,
                                                            this.txtNroDocumento.Text, mov.CodigoArticulo, out orden);
                    mov.Orden = orden;

                    DocumentoLogic.Instance.InsertarDetalle(mov, double.Parse(txtTipoCambio.Text), this.txtCodMoneda.Text, out flag, out mensajeRetorno);
                    info.Cells["Orden"].Value = orden;

                    // si el flag es  -1  entonces el proceso tiene error
                    if (flag == -1)
                    {
                   
                        gridControl.CurrentRow.Cells["flag"].Value = null;
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                        CargarMovimiento();
                    }
                    else
                    {
                        //es OK
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                      //  gridControl.CurrentRow.Cells["flag"].Value = null;
                        CargarMovimiento();
                        //agrego nueva fila
                        btnAddDetalle_Click(null, null);
                    }
                }
                else
                {
                    //EDITAR
                    mov.Orden = double.Parse(info.Cells["Orden"].Value.ToString());

                    DocumentoLogic.Instance.ActualizarDetalle(mov, double.Parse(txtTipoCambio.Text), this.txtCodMoneda.Text, out flag, out mensajeRetorno);
                    info.Cells["Orden"].Value = mov.Orden;

                    if (flag == -1)
                    {
                        gridControl.CurrentRow.Cells["flag"].Value = null;
                        RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);

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
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);

                //throw;
            }
            Cursor.Current = Cursors.Default;
        }

        #endregion  

        #region Guardar
        /// <summary>
        /// Metodo de validacion para los datos de la cebera del documento
        /// </summary>
        /// <returns> Si es true entonces validacion es OK</returns>
        private bool Validar()
        {
            //cbbGuardar.IsMouseOver = false;

            if (this.txtCodigoTipDoc.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Tran", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.txtCodigoTipDoc.Focus();
                return false;
            }
            if (this.txtDesTipDoc.Text.Trim() == "" || this.txtDesTipDoc.Text.Trim() == "???")
            {
                RadMessageBox.Show("Transaccion No Valida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.txtCodigoTipDoc.Focus();
                return false;
            }

            //Campos de Transaccion
            if (this.txtCodTransa.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Transacción", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.txtCodTransa.Focus();
                return false;
            }


            if (this.txtDesTransa.Text.Trim() == "" || this.txtDesTransa.Text.Trim() == "???")
            {
                RadMessageBox.Show("Tipo Documento Respaldo No Valido", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.txtCodTransa.Focus();
                return false;
            }

            if (this.txtdocrespaldoctacte.Enabled)
                 {
            if (this.txtdocrespaldoctacteDesc.Text.Trim() == "" || this.txtdocrespaldoctacteDesc.Text.Trim() == "???")
            {
                RadMessageBox.Show("Cta Cte Doc Respaldo No Valido", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.txtdocrespaldoctacte.Focus();
                return false;
            }
                 }

            //Campos proveedor y de monea

            if (this.txtCodProveedor.Enabled)
            {
                if (this.txtCodProveedor.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Proveedor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.txtCodProveedor.Focus();
                    return false;
                }
            }



            //Campos adicionales
            if (this.txtCodRepReceptor.Enabled)
            {
                if (this.txtCodRepReceptor.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Responsable receptor", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.txtCodRepReceptor.Focus();
                    return false;
                }
            }

            if (this.txtCodResponsable.Enabled)
            {
                if (this.txtCodResponsable.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Responsable entrega", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.txtCodResponsable.Focus();
                    return false;
                }
            }

            if (this.txtCodCentroCosto.Enabled)
            {
                if (this.txtCodCentroCosto.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Centro de costo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.txtCodCentroCosto.Focus();
                    return false;
                }
            }

            if (this.txtCodObra.Enabled)
            {
                if (this.txtCodObra.Text.Length == 0)
                {
                    RadMessageBox.Show("Debe ingresar Obra", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.txtCodObra.Focus();
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
            Cursor.Current = Cursors.WaitCursor;
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
                documento.Moneda = this.txtCodMoneda.Text;
                documento.ResponsableReceptor = this.txtCodRepReceptor.Text;
                documento.Responsable = this.txtCodResponsable.Text;
                documento.CodigoCentroCosto = this.txtCodCentroCosto.Text;
                documento.CodigoObra = this.txtCodObra.Text;

                //Tipo de cambio
                documento.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                documento.IN06PRODNATURALEZA = Logueo.PS_codnaturaleza;
                documento.IN06DOCRESCTACTETIPANA = this.txtTipoAnalisis.Text;
                documento.IN06DOCRESCTACTENUMERO = txtdocrespaldoctacte.Text.Trim();
                string origentipo = "";
                GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodigoTipDoc.Text, "ORIGENTIPO", out origentipo);
                documento.OrigenTipo = origentipo;
                
                documento.CodigoMaquina = this.txtCodMaquina.Text;
                documento.AnioOrdenCompra = this.txtAnioOrdCompra.Text;
                documento.OrdenCompra = this.txtOrdCompra.Text;
                documento.CodigoCliente = this.txtCodCliente.Text;
                documento.CodigoAlmacenEmisor = this.txtAlmEmisorCod.Text;

                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    string nroDocumentoRetorno = string.Empty;
                    nroDocumentoRetorno = documento.CodigoDoc;

                    DocumentoLogic.Instance.InsertarDocumento(documento, out nroDocumentoRetorno, out mensajeRetorno, txtNroDocumento.Text.Trim());
                  
                    if (nroDocumentoRetorno != "")
                    { // valdamos si obtenemos un valor de retorno 
                        this.txtNroDocumento.Text = nroDocumentoRetorno;

                        //deshabilitamos algunos controles de la cabcera del documento
                        Habilitar(false);
                        this.HabilitarBotonesCabecera(true,true,false,false,false,false,false,false);
                        //asginsmo estado de edicion
                        this.Estado = FormEstate.Edit;

                        //si la operacion fue exitosa hacemos visible a boton de agregar detalle
                        btnAddDetalle.Visible = true;
                        
                    }
                }
                else
                {
                    //MODIFICA
                    DocumentoLogic.Instance.ActualizarDocumento(documento, out mensajeRetorno);
                    //HABILITAR BOTONES
                    this.HabilitarBotonesCabecera(false, false, true, true, true, true, true, true);
                    this.btnAddDetalle.Visible = true;
                }
                
                
                this.gridControl.Columns["btnGrabar"].IsVisible = true;
                this.gridControl.Columns["btnCancelar"].IsVisible = true;
                this.gridControl.Columns["btnEliminar"].IsVisible = true;
                this.gridControl.Columns["btnEditar"].IsVisible = true;


                RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);                
                frmDocuSuministro.formulario.Listar();
            }
            catch (Exception ex )
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar el documento" + ex, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            Cursor.Current = Cursors.Default;
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

        private void btnAddDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
            bool bEliminar, bool bEditar, bool bMemo)
        {
            GridViewRowInfo info = this.gridControl.CurrentRow;
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
                case "btnMemo":
               string CodigoAlmacen = Util.GetCurrentCellText(info, "CodigoAlmacen");
               if (CodigoAlmacen == Logueo.MP_AlmxDefecto)
               {

                   cellElement.CommandButton.Image = bMemo ? Properties.Resources.memo_enabled : Properties.Resources.memo_disabled;
                   cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                   cellElement.CommandButton.Enabled = bMemo;

               }
               else
               {
                   cellElement.CommandButton.Image = Properties.Resources.memo_disabled;
                   cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                   cellElement.CommandButton.Enabled = bMemo;
               }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Metod para eliminar el registro seleccionado del detalle de movimiento
        /// </summary>        
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

                GridViewRowInfo info = this.gridControl.CurrentRow;

                // eliminar movimiento sin orde de trabajo 
                if (double.Parse(info.Cells["Orden"].Value.ToString()) > 0)
                {
                    string mensajeRetorno = string.Empty;

                        //Eliminar detall de grilla con flag ->  S  (salida de produccion)
                        //DocumentoLogic.Instance.EliminarSalidasPPLinea(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, this.txtCodigoTipDoc.Text,
                        //    this.txtNroDocumento.Text.Trim(), info.Cells["CodigoArticulo"].Value.ToString(),
                        //    double.Parse(info.Cells["Orden"].Value.ToString()),
                        //    out mensajeRetorno);
                    double nroOrden = double.Parse(Util.GetCurrentCellText(gridControl.CurrentRow, "Orden"));
                    string codigoArticulo = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoArticulo");

                        DocumentoLogic.Instance.EliminarDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                        this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text.Trim(), codigoArticulo, 
                        nroOrden , out mensajeRetorno); 

                        //this.gridControl.Rows.Remove(this.gridControl.CurrentRow);
                        RadMessageBox.Show(mensajeRetorno);
                        CargarMovimiento();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void MostrarDatosVentanaEmergente() 
        {
            //LIMPIAR CAMPOS 
            //LimpiarCamposgridflotante();
            txtCodBloque.Focus();
            GridViewRowInfo info = this.gridControl.CurrentRow;
            //string CodBloque = Util.GetCurrentCellText(info, "CodBloEmp");
            string CodigoAlmacen = Util.GetCurrentCellText(info, "CodigoAlmacen");
            //PLANTA
            double LargoPlanta;
            double AnchoPlanta;
            double AltoPlanta;
            //CANTERA
            double LargoCantera;
            double AnchoCantera;
            double AltoCantera;

            //TOTAL
            double TotalPlanta;
            double TotalCantera;

            //CODIGO BLOQUE
            if (Estado == FormEstate.Edit || Estado == FormEstate.View)
            {
                txtCodBloqueProveedor.Text = Util.GetCurrentCellText(info, "CodBloqProv");
                txtCodBloque.Text = Util.GetCurrentCellText(info, "CodBloEmp");

                CalcularVolumenBloque();
                //PLANTA

                txtLargoPlanta.Text = Convert.ToDouble(Util.GetCurrentCellText(info, "Largo")).ToString();
                txtAnchoPlanta.Text = Convert.ToDouble(Util.GetCurrentCellText(info, "Ancho")).ToString();
                txtAltoPlanta.Text = Convert.ToDouble(Util.GetCurrentCellText(info, "Alto")).ToString();

                //CANTERA
                txtLargoCantera.Text = Convert.ToDouble(Util.GetCurrentCellText(info, "LargoCan")).ToString();
                txtAnchoCantera.Text = Convert.ToDouble(Util.GetCurrentCellText(info, "AnchoCan")).ToString();
                txtAltoCantera.Text = Convert.ToDouble(Util.GetCurrentCellText(info, "AltoCan")).ToString();
        
            LargoPlanta = Convert.ToDouble(txtLargoPlanta.Text);
            AnchoPlanta = Convert.ToDouble(txtAnchoPlanta.Text);
            AltoPlanta = Convert.ToDouble(txtAltoPlanta.Text);


            LargoCantera = Convert.ToDouble(txtLargoCantera.Text);
            AnchoCantera = Convert.ToDouble(txtAnchoCantera.Text);
            AltoCantera = Convert.ToDouble(txtAltoCantera.Text);
          


            //TOTAL - PLANTA 

            txtTotalPlanta.Text = Convert.ToString(LargoPlanta * AnchoPlanta * AltoPlanta);

            ////TOTAL -CANTERA

            txtTotalCantera.Text = Convert.ToString(LargoCantera * AnchoCantera * AltoCantera);

            TotalPlanta = Convert.ToDouble(txtTotalPlanta.Text);
            TotalCantera = Convert.ToDouble(txtTotalCantera.Text);

            ////DIFERENCIA 
            txtDiferencia.Text = Convert.ToString(TotalPlanta - TotalCantera);
            double diferencia = double.Parse(txtDiferencia.Text);
            if(diferencia < 0)
            {
                double nropositivo = Math.Abs(diferencia);
                txtDiferencia.Text = Convert.ToString(nropositivo);

            }
            }
        }
        /// <summary>
        /// Metodo para habilitar los campos paraedicion de registro
        /// </summary>
        void editarRegistroGrilla()
        {
            //MOSTRAR DATOS DE LA VENTANA EMERGENTE SI ES EDITAR
            MostrarDatosVentanaEmergente();
            //END MOSTRAR DATOS EMERGENTE
            //Flaga pra fila en modo edicion
            gridControl.CurrentRow.Cells["flag"].Value = "0";

            string orden = gridControl.CurrentRow.Cells["Orden"].Value.ToString();
            //enfocar fila actual
            Util.enfocarFila(gridControl, "Orden", orden);
            //Resaltar celdas de ayuda  color:Amarillo
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CodigoAlmacen"]);            
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CodigoArticulo"]);           
            

              
             
          
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

        /// <summary>
        /// Metodo para iniciar un nuevo documento solo cabecera
        /// </summary>
     
        /// <summary>
        /// Metodo para bloquear controles ocultos (cajas de texto) 
        /// </summary>
     
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
        private void dtpFechaDoc_KeyDown_1(object sender, KeyEventArgs e)
        {
            this.dtpFechaDoc.ReadOnly = (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) ? true : false;
        }
        private void Activarcontrolesdeayuda()
        {
            ActivarAyuda(txtCodigoTipDoc);
            ActivarAyuda(txtCodTransa);
            ActivarAyuda(txtdocrespaldoctacte);
            ActivarAyuda(txtCodProveedor);
            ActivarAyuda(txtCodMoneda);
            ActivarAyuda(txtCodCentroCosto);
            ActivarAyuda(txtCodResponsable);
            ActivarAyuda(txtCodObra);
            ActivarAyuda(txtCodMaquina);
            //ActivarAyuda(txtAnioOrdCompra);
            ActivarAyuda(txtCodRepReceptor);
            ActivarAyuda(txtCodCliente);
            ActivarAyuda(txtAlmEmisorCod);
            
        }
        private void ActivarAyuda(RadTextBox nombreControl)
        {

            if (nombreControl.Enabled)
            {
                  Util.ResaltarAyuda(nombreControl);
            }else{
                Util.ResetearAyuda(nombreControl);
            }
            

        }
        
        public void LimpiarCamposCabecera( ) 
        {
           
            this.txtCodigoTipDoc.Text = "";
            this.txtDesTipDoc.Text = "";
            this.txtNroDocumento.Text = "";
            this.dtpFechaDoc.Text = "";
            this.txtCodTransa.Text = "";
            this.txtNroReferencia.Text = "";
            this.txtdocrespaldoctacte.Text = "";
            this.txtCodMoneda.Text = "";
            this.txtAnioOrdCompra.Text = ""; 
            this.txtOrdCompraProv.Text = "";
            this.txtOrdCompra.Text = "";
            this.txtCodObra.Text = "";
            this.txtCodProveedor.Text = "";
            this.txtCodMaquina.Text = "";
            this.txtCodCliente.Text = "";
            this.txtCodCentroCosto.Text = "";
            this.txtCodResponsable.Text = "";
            this.txtCodRepReceptor.Text = "";
        }
        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            isLoaded = true;
            //LimpiarTextos
       
            //end
            //cargar detalle, orden de trabajo y materia prima
            CargarDocumento();
            //habilitar controles del documento
            //
            this.Habilitar(true);
            this.btnAddDetalle.Visible = true;
            // Deshabilitar lo que no se puede modificar 
            this.txtCodigoTipDoc.Enabled = true;
            this.txtNroDocumento.Enabled = true;


            this.HabilitarBotonesCabecera(true,true,false,false,false,false,false,false);
            this.gridControl.Columns["btnGrabar"].IsVisible = true;
            this.gridControl.Columns["btnCancelar"].IsVisible = true;
            this.gridControl.Columns["btnEliminar"].IsVisible = true;
            this.gridControl.Columns["btnEditar"].IsVisible = true;
            //Deshabilito y habilito segun configuracion de TipDoc

            DeshabilitarCamposConfigTpDoc();
            ConfigurarDocumento(this.txtCodigoTipDoc.Text.Trim());

            Activarcontrolesdeayuda();

        }
        protected override void OnEliminar()
        {

            string TipDoc = txtCodigoTipDoc.Text;
            string nroDoc = txtNroDocumento.Text;
            int cantidad = 0;
            DocumentoLogic.Instance.TraerCantidadDetallexNroDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, TipDoc, nroDoc, out cantidad);

            if (cantidad > 0)
            {
                RadMessageBox.Show("No se puede eliminar porque el documento tiene detalle. ", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            DialogResult result = RadMessageBox.Show("Está seguro de eliminar el movimiento", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                                                        MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                string tipoDocumento = string.Empty;
                string codigoDocumento = string.Empty;
                string transMov = string.Empty;
                string fechaDoc = string.Empty;
                string moneda = string.Empty;
                double tipoCambio = 0;

                string msgRetorno = string.Empty;

                tipoDocumento = txtCodigoTipDoc.Text;
                codigoDocumento = txtNroDocumento.Text;

                transMov = this.FrmParent.gridControl.CurrentRow.Cells["Transaccion"].Value.ToString();
                fechaDoc = string.Format("{0:yyyyMMdd}", DateTime.Parse(this.FrmParent.gridControl.CurrentRow.Cells["FechaDoc"].Value.ToString()));
                moneda = txtCodMoneda.Text;
                tipoCambio = double.Parse(txtTipoCambio.Text);

                DocumentoLogic.Instance.EliminarDocumento(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, tipoDocumento, codigoDocumento, transMov, fechaDoc,
                                                          tipoCambio, moneda, out msgRetorno);

                RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
               // OnBuscar();
                this.Cursor = Cursors.Default;
                this.Close();
                FrmParent.Listar();

            }
        }
        protected override void OnNuevo()
        {
            LimpiarCamposCabecera();
            this.gridControl.Rows.Clear();
            //Habilito controles Generales
            this.Habilitar(true);
            Estado = FormEstate.New;
            // Deshabilito controles configurables por Tip DOC
            DeshabilitarCamposConfigTpDoc();
            btnAddDetalle.Visible = true;
            // Valores Iniciales
            this.dtpFechaDoc.Value = DateTime.Now;
            this.txtCodMoneda.Text = "S";

            // Botones de despligue y guardar y cancelar

            this.HabilitarBotonesCabecera(true, true, false, false, false, false, false, false);

            this.gridControl.Columns["btnGrabar"].IsVisible = true;
            this.gridControl.Columns["btnCancelar"].IsVisible = true;
            this.gridControl.Columns["btnEliminar"].IsVisible = true;

            Activarcontrolesdeayuda();

            this.txtCodigoTipDoc.Focus();
        }
        private void frmMoviSuministro_Load(object sender, EventArgs e)
        {
    
            //GPXOBSERVACION
            txtTotalPlanta.Enabled = false;
            txtTotalCantera.Enabled = false;
            txtDiferencia.Enabled = false;
      
            //END GPXOBSERVACION
            this.gpxObservacion.Visible = false;


            if (this.Estado == FormEstate.New)
            {
             
                //Habilito controles Generales
                this.Habilitar(true);
                // Deshabilito controles configurables por Tip DOC
                DeshabilitarCamposConfigTpDoc();
                btnAddDetalle.Visible = false;
                // Valores Iniciales
                this.dtpFechaDoc.Value = DateTime.Now;
                this.txtCodMoneda.Text= "S";

            
                // Botones de despligue y guardar y cancelar
                this.HabilitarBotonesCabecera(true, true, false, false, false,false,false,false);

                this.gridControl.Columns["btnGrabar"].IsVisible = true;
                this.gridControl.Columns["btnCancelar"].IsVisible = true;
                this.gridControl.Columns["btnEliminar"].IsVisible = true;

                Activarcontrolesdeayuda();

                //txtCodigoTipDoc.Text = "";
                //txtCodigoTipDoc.Focus();
                //txtCodigoTipDoc.Select();
                this.ActiveControl = txtCodigoTipDoc;
            }

            else if (this.Estado == FormEstate.Edit)
            {
                this.Habilitar(true);

                //cargar detalle, orden de trabajo y materia prima
                CargarDocumento();
                //Deshabilito y habilito segun configuracion de TipDoc

                ConfigurarDocumento(this.txtCodigoTipDoc.Text.Trim());
                //habilitar controles del documento
                Activarcontrolesdeayuda();
                //

     
                // Deshabilitar lo que no se puede modificar 
                this.txtCodigoTipDoc.Enabled = false;
                this.txtNroDocumento.Enabled = false;


                this.HabilitarBotonesCabecera(true,true,false,false,false,false,false,false);
                this.btnAddDetalle.Visible = true;
               this.gridControl.Columns["btnGrabar"].IsVisible = true;
               this.gridControl.Columns["btnCancelar"].IsVisible = true;
               this.gridControl.Columns["btnEliminar"].IsVisible = true;
               this.gridControl.Columns["btnEditar"].IsVisible = true;



                this.CargarMovimiento();
            }
            else if (this.Estado == FormEstate.View)
            {
              
                CargarDocumento();
                //Deshabilitar controles del documento
                Activarcontrolesdeayuda();

                Habilitar(false);
                //Deshabilitar los controles configurables
                //Deshabilito y habilito segun configuracion de TipDoc
                ConfigurarDocumento(this.txtCodigoTipDoc.Text.Trim());

                this.HabilitarBotonesCabecera(false, true, true, false, true, true, true, true);

                //deshabilito control de Fecha del documento
                this.gridControl.Columns["btnGrabar"].IsVisible = true;
                this.gridControl.Columns["btnCancelar"].IsVisible = true;
                this.gridControl.Columns["btnEliminar"].IsVisible = true;
                this.gridControl.Columns["btnEditar"].IsVisible = true;

                btnAddDetalle.Enabled = true;
                Estado = FormEstate.Edit;
                //configura los botones para el mantenimiento del formulario


                this.CargarMovimiento();                
            }


            isLoaded = true;

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
        /// enfocar el registro segun el valor de la variable fila
        /// </summary>
        void enfocarregistro()
        {
            FrmParent.gridControl.MasterView.Rows[fila].IsCurrent = true;
            FrmParent.gridControl.MasterView.Rows[fila].IsSelected = true;
        }
        protected override void OnPrimero()
        {
            fila = 0;
            asignarValores(); 
        }
        protected override void OnAnterior()
        {
            if (fila == 0)
                return;
            fila--;
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

        protected override void OnUltimo()
        {
            fila = FrmParent.gridControl.MasterView.Rows.Count - 1;
            asignarValores();    
        }

        private void txtdocrespaldoctacte_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmCtaCteDesc, this.txtdocrespaldoctacte.Text);
        }

        private void txtdocrespaldoctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmCtaCteDesc);

        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMemo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnGuardarObservacion_Click(object sender, EventArgs e)
        {
            if(txtLargoCantera.Text == "" || txtAnchoCantera.Text == "" || txtAltoCantera.Text =="")
            {
                txtLargoCantera.Text = "0";
                txtAnchoCantera.Text = "0";
                txtAltoCantera.Text = "0";
            }
            if (Util.NumerNoNegativo(txtLargoPlanta.Text) != "")
            {
                Util.ShowError("Validar : Largo Planta debe ser numero positivo");
                return;

            }
            if (Util.NumerNoNegativo(txtAnchoPlanta.Text) != "")
            {
                    Util.ShowError("Validar : Ancho Planta debe ser numero positivo");
                    return;
            
            }

            if (Util.NumerNoNegativo(txtAltoPlanta.Text) != "")
            {
                Util.ShowError("Validar : Alto Planta debe ser numero positivo");
                return;

            }
            //END PLANTA
            if (Util.NumerNoNegativo(txtLargoCantera.Text) != "")
            {
                Util.ShowError("Validar : Largo Cantera debe ser numero positivo");
               
                return;

            }
            if (Util.NumerNoNegativo(txtAnchoCantera.Text) != "")
            {
                Util.ShowError("Validar : Ancho Cantera debe ser numero positivo");
          
                return;

            }
            if (Util.NumerNoNegativo(txtAltoCantera.Text) != "")
            {
                Util.ShowError("Validar : Alto Cantera debe ser numero positivo");
         
                return;

            }

            //NONUMERICO

            if (Util.IsNumerico(txtLargoPlanta.Text) == false)
            {
                Util.ShowError("Validar : Largo Planta debe ser Numerico");
                return;

            }
            if (Util.IsNumerico(txtAnchoPlanta.Text) == false)
            {
                Util.ShowError("Validar : Ancho Planta debe ser Numerico");
                return;

            }

            if (Util.IsNumerico(txtAltoPlanta.Text) == false)
            {
                Util.ShowError("Validar : Alto Planta debe ser Numerico");
                return;

            }
            //END PLANTA
            //if (Util.IsNumerico(txtLargoCantera.Text) == false)
            //{
            //    Util.ShowError("Validar : Largo Cantera debe ser Numerico");
            //    return;

            //}
            //if (Util.IsNumerico(txtAnchoCantera.Text) == false)
            //{
            //    Util.ShowError("Validar : Ancho Cantera debe ser Numerico");
            //    return;

            //}
            //if (Util.IsNumerico(txtAltoCantera.Text) == false)
            //{
            //    Util.ShowError("Validar : Alto Cantera debe ser Numerico");
            //    return;

            //}

            //if(txtCodBloque.Text == "")
            //{
            //    Util.ShowError("ERROR:: Codigo Bloque faltante");
            //    return;
            //}
            //if (txtCodBloqueProveedor.Text == "") 
            //{
            //    Util.ShowError("Validar : Codigo bloque proveedor faltante");
            //    return;
            //}

            double totalplanta = double.Parse(txtTotalPlanta.Text);

            Util.SetValueCurrentCellDbl(gridControl, "Cantidad", totalplanta);
            //UBICAR CURSOR A UNA GRILLA
            gridControl.CurrentColumn = this.gridControl.Columns["CostoUnidad"];
            gpxObservacion.Visible = false;
               
  
          
            //grilla.cantidad =txtTotalPlanta
            //enfoque de Label grilla lock pasa
       
        
        }

        private void btnCancelarObservacion_Click(object sender, EventArgs e)
        {
            this.gpxObservacion.Visible = false;
        }


        private void radLabel29_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalPlanta_Leave(object sender, EventArgs e)
        {
          
            
        }

        private void txtAltoPlanta_Leave(object sender, EventArgs e)
        {
            
            CalcularVolumenBloque();
        }

        private void CalcularVolumenBloque()
          
        {
            try 
            {

          
            
            //LOGICA SEÑORA CARLA
            if(
                //   Util.IsNumerico(txtLargoCantera.Text)
                //&& Util.IsNumerico(txtAnchoCantera.Text)
                //&& Util.IsNumerico(txtAltoCantera.Text)

                 Util.IsNumerico(txtLargoPlanta.Text)
                && Util.IsNumerico(txtAnchoPlanta.Text)
                && Util.IsNumerico(txtAltoPlanta.Text))   
            {

                if (txtLargoCantera.Text == "" || txtAnchoCantera.Text == "" || txtAltoCantera.Text == "") 
                {
                  //NO HAGAS NADA
                    txtLargoCantera.Text = Convert.ToString(0.0);
                    txtAnchoCantera.Text = Convert.ToString(0.0);
                    txtAltoCantera.Text = Convert.ToString(0.0);

                }
                double LargoCantera = Convert.ToDouble(txtLargoCantera.Text.ToString());
                double AnchoCantera = Convert.ToDouble(txtAnchoCantera.Text.ToString());
                double AltoCantera = Convert.ToDouble(txtAltoCantera.Text.ToString());

                double Largoplanta = Convert.ToDouble(txtLargoPlanta.Text);
                double Anchoplanta = Convert.ToDouble(txtAnchoPlanta.Text);
                double Altoplanta = Convert.ToDouble(txtAltoPlanta.Text);

                Double TotalPlanta = Largoplanta * Anchoplanta * Altoplanta;
                Double TotalCantera = LargoCantera * AnchoCantera * AltoCantera;

                txtTotalCantera.Text = TotalCantera.ToString("F2");
                txtTotalPlanta.Text = TotalPlanta.ToString("F2");

                //DIFERENCIA
                double TotalCanteraDiferencia = Convert.ToDouble(txtTotalCantera.Text);
                double TotalPlantaDiferencia = Convert.ToDouble(txtTotalPlanta.Text);
                double diferencia = TotalCanteraDiferencia - TotalPlantaDiferencia;
                double positivo = Math.Abs(diferencia);
                txtDiferencia.Text = Convert.ToString(positivo);
              }

            }
            catch(Exception ex)
            {
                Util.ShowError("ERROR:: Algo sucedio");
            }

       
            
        }
        private void txtAltoCantera_Leave(object sender, EventArgs e)
        {
            CalcularVolumenBloque();
        }

        private void txtDiferencia_Leave(object sender, EventArgs e)
        {
         
        }

        private void txtCodBloque_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtLargoPlanta.Focus(); 
            }
        }

        private void txtCodBloqueProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtCodBloqueProveedor.Focus();
            }
        }

        private void txtLargoPlanta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAnchoPlanta.Focus();
            }
        }

        private void txtLargoPlanta_Leave(object sender, EventArgs e)
        {
         
            CalcularVolumenBloque();
        }

        private void txtLargoCantera_Leave(object sender, EventArgs e)
        {

            CalcularVolumenBloque();
        }

        private void txtAnchoPlanta_Leave(object sender, EventArgs e)
        {
          
            CalcularVolumenBloque();
        }

        private void txtAnchoCantera_Leave(object sender, EventArgs e)
        {
         
            CalcularVolumenBloque();
        }

        private void dtpFechaDoc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double TipoCambio;

                Compra_Traer_TipoCambioLogic.Instance.TipoCambioTraer(dtpFechaDoc.Text, out TipoCambio);

                txtTipoCambio.Text = TipoCambio.ToString();
            }catch(Exception ex)
            {
                Util.ShowError("ERROR:: Algo Salio mal, intentalo de nuevo");
            }
            }

        private void frmMoviSuministro_Shown(object sender, EventArgs e)
        {
            if (this.Estado == FormEstate.New)
            {

                txtCodigoTipDoc.Focus();

            }

            else if (this.Estado == FormEstate.Edit)
            {
                txtCodigoTipDoc.Focus();

            }
            else if (this.Estado == FormEstate.View)
            {

            }
              
        }

        private void txtAltoCantera_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    gpxObservacion.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Salio error en la ventana de medidas");
            }
        }

        private void txtdocrespaldoctacte_Leave(object sender, EventArgs e)
        {
            if (txtCodProveedor.Enabled == true) { this.txtCodProveedor.Text = txtdocrespaldoctacte.Text; txtDesProveedor.Text = txtdocrespaldoctacteDesc.Text; }
            if (txtCodCliente.Enabled == true) { this.txtCodCliente.Text = txtdocrespaldoctacte.Text;txtDescCliente.Text=txtdocrespaldoctacteDesc.Text; }

        }

  


    }

}
