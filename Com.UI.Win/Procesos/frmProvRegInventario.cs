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
namespace Com.UI.Win
{
    public partial class frmProvRegInventario : frmBaseMante
    {

        #region "Instancia"
        private static frmProvRegInventario _aForm;
        private frmProvFacturaDetOC FrmParent { get; set; }

        #endregion
        GuiaCompraLogic LogicaGuia = GuiaCompraLogic.Instance;
        
        public static frmProvRegInventario Instance(frmProvFacturaDetOC padre)
        {
            if (_aForm != null) return new frmProvRegInventario(padre);
            _aForm = new frmProvRegInventario(padre);
            return _aForm;
        }

        public frmProvRegInventario(frmProvFacturaDetOC padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        
        
        private string DameDescripcion(string codigo, string flag)       
        {
            string descripcion = "";
            try
            {

                GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, 
                    codigo, flag, out descripcion);
            }
            catch (Exception ex)
            { 
                
            }
            return descripcion;
        }
        /// <summary>
        /// Cargar datos para la grilla de ProvGuia y los datos de las etiquetas
        /// </summary>
        private void CargarDetalle()
        {
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Traer data de la cabecerea

                var documentoInvCab = LogicaGuia.TraerRegistroInventarioCab(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, FrmParent.CodTranfInventario, FrmParent.NroTransfInventario);

                
                if (documentoInvCab != null)
                {
                    txtTransaccionCod.Text = documentoInvCab.TipoDoc;
                    lblTransaccionDesc.Text = DameDescripcion(Logueo.CodigoEmpresa+txtTransaccionCod.Text, "TRANSA"); ;
                    txtTransaccionNumero.Text = documentoInvCab.CodigoDoc;
                    dtpFechaDoc.Text = documentoInvCab.FechaDoc.ToString();
                    rbSoles.Checked = documentoInvCab.Moneda == "S" ? true : false;
                    rbDolares.Checked = documentoInvCab.Moneda == "D" ? true : false;
                    txttipodecambio.Text = documentoInvCab.TipoCambio.ToString();

                    txtDocRespaldoCod.Text = documentoInvCab.CodigoTransa;
                    txtDocRespDesc.Text = DameDescripcion(Logueo.CodigoEmpresa + txtDocRespaldoCod.Text, "TDG"); ;
                    txtDocRespNumero.Text = documentoInvCab.ReferenciaDoc;
                    txtProveedorCod.Text = documentoInvCab.CodigoProveedor;
                    this.txtRucCab.Text = documentoInvCab.CodigoProveedor;
                    //string codigo = Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + txtProveedorCod.Text.Trim();
                    //string descripcion = "";
                    //GlobalLogic.Instance.DameDescripcion(codigo, "PROVEEDOR", out descripcion);
                    //lblProveedorDesc.Text = descripcion;

                    //lblProveedorDesc.Text = documentoInvCab.ctactedocresnombre;

                    txtNroFacturaCab.Text = FrmParent.tipoDocumento;

                }

                //almacenamos los datos de la fila trabajado actualmente
                Movimiento movimientoregistro = new Movimiento();
                movimientoregistro.Orden = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Orden");

                List<Movimiento> lista = new List<Movimiento>();
                lista = LogicaGuia.TraeDetalleDocumento(Logueo.CodigoEmpresa, Logueo.Anio,
                    Logueo.Mes, txtTransaccionCod.Text, txtTransaccionNumero.Text);
                
                this.gridControl.DataSource = lista;
                MuestraTotales();
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error en cargar detalle");
            }
            /*
             
             */
        }
        private void MuestraTotales()
        { 
            
                try
                {
                    double totalCantidad = 0, totalCostoDolares = 0;
                    double totalImporteDolares = 0, totalCostoSoles = 0, totalImporteSoles;
                    string moneda = "";

                    if (rbSoles.Checked == true)
                    { moneda = "S"; }
                    else if (rbDolares.Checked == true)
                    { moneda = "D"; } 


                    //GuiaCompraLogic.Instance.Spu_Com_Dame_TotDocumento
                    LogicaGuia.TraeTotalesDocumento(Logueo.CodigoEmpresa, Logueo.Anio,
                        Logueo.Mes,
                        txtTransaccionNumero.Text,
                        txtTransaccionCod.Text,
                        moneda, out totalCantidad, out totalCostoDolares, out totalImporteDolares,
                        out totalCostoSoles, out totalImporteSoles);
                   
                }
                catch (Exception ex)
                {
                    Util.ShowError("Error al cargar detalle");
                }
        }
        private void CrearColumnas() {

            bool esVisibleSi = true, esVisibleNo = false, esNumericoSi = true, esNumericoNo = false;
            bool esLecturaSi = true, esLecturaNo = false, esEditableSi = true, esEditableNo = false;
            RadGridView Grid = CreateGridVista(this.gridControl);
            //Guia                        
            CreateGridColumn(Grid, "T.T", "Transaccion", 0, "", 90, esLecturaSi, esEditableNo, esVisibleNo);
            //Almacen
            //codigo
            CreateGridColumn(Grid, "Almacen", "CodigoAlmacen", 0, "", 90);
            //descripcion 
            CreateGridColumn(Grid, "Almacen\nDesc", "AlmacenDesc", 0, "", 90);
            CreateGridColumn(Grid, "Codigo", "CodigoArticulo", 0, "", 90, esLecturaSi, esEditableNo, esVisibleSi);
            CreateGridColumn(Grid, "Descripcion", "In01Deslar", 0, "", 150, esLecturaNo,esEditableSi,esVisibleSi);

            CreateGridColumn(Grid, "Unidad", "UnidadMedida", 0, "", 70, esLecturaNo, esEditableSi, esVisibleSi);
            CreateGridColumn(Grid, "Cantidad", "Cantidad", 0, "{0:F02}", 70, esLecturaNo, esEditableSi, esVisibleSi, esNumericoNo, "right");

            //ocultamos costo unidad e importe , campos que guardar valores finales si es Dolares o Soles la orden de compra
            //costo unitario e importe , por defecto esta en soles
            CreateGridColumn(Grid, "Costo", "CostoUnidad", 0, "{0:###,###0.000000}", 70, esLecturaNo, esEditableSi, esVisibleNo, esNumericoSi, "right");

            GridViewColumn columnaCostoUni = this.gridControl.Columns["CostoUnidad"];
            ((GridViewMaskBoxColumn)columnaCostoUni).Mask = "f6";

            CreateGridColumn(Grid, "Importe", "Importe", 0, "{0:F02}", 70, esLecturaNo, esEditableSi, esVisibleNo, esNumericoSi, "right");


            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, esLecturaNo, esEditableSi, esVisibleNo);
            
            //Costos unitarios
            //costo unitario soles , 6 decimales
            //CreateGridColumn(Grid, "Costo\nSoles", "CostoSoles", 0, "{0:F06}", 70, esLecturaNo, esEditableSi, esVisibleSi, esNumericoNo, "right");
            CreateGridDecimalColumn(Grid, "Costo\nSoles", "CostoSoles", 0, "{0:F06}", 70, esLecturaNo, esEditableSi, esVisibleSi, esNumericoNo, "right");

            //importe por defecto en soles            
            //importe soles , 2 decimales
            CreateGridColumn(Grid, "Imp.\nSoles", "ImporteSoles", 0, "{0:F02}", 70, esLecturaNo, esEditableSi, esVisibleSi, esNumericoNo, "right");
            
            
            //costo unitario dolares
            //CreateGridColumn(Grid, "Costo\nDolares", "CostoDolares", 0, "{0:F06}", 70, esLecturaNo, esEditableSi, esVisibleSi, esNumericoNo, "right");
            CreateGridDecimalColumn(Grid, "Costo\nDolares", "CostoDolares", 0, "{0:F06}", 70, esLecturaNo, esEditableSi, esVisibleSi, esNumericoNo, "right");

            //importe dolares
            CreateGridColumn(Grid, "Imp.\nDolares", "ImporteDolar", 0, "{0:F02}", 70, esLecturaNo, esEditableSi, esVisibleSi, esNumericoSi, "right");

            //Importe
            //Precio unitario
            //otros
            //IN07CANART	IN07COSUNI	    IN07COUNSO	    IN07COUNDO	IN07IMPORT	        IN07IMPSOL	        IN07IMPDOL
            //  39936.00	2.03818810096	2.03818810096	0	        81397.0799999385	81397.0799999385	0
            //orden detalle
            CreateGridColumn(Grid, "Orden", "Orden", 0, "{0:F02}", 70, esLecturaSi, esEditableNo, esVisibleNo);
            //botones
            agregarBoton();
            string[] columnas = { "CostoSoles", "CostoDolares", "Importe", "CostoUnidad", "Cantidad", "ImporteSoles", "ImporteDolar" };
            Util.AddGridSummarySum(gridControl, columnas);

            this.gridControl.Columns["btnGrabar"].MinWidth = 30;
            this.gridControl.Columns["btnCancelar"].MinWidth = 30;
            this.gridControl.Columns["btnEliminar"].MinWidth = 30;
            this.gridControl.Columns["btnEditar"].MinWidth = 30;
            this.gridControl.ShowItemToolTips = true;

            //columna codigo busqueda
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
        private void AsignarEstadoLectura(Control datoControl, bool estado = false)
        {
            if (datoControl.Tag != null)
            {
                if (datoControl.Tag.ToString() == "lectura")
                {
                    datoControl.Enabled = estado;
                    //(c(RadTextBox))
                }
            }
        }
        private void BloquearPorTipo(Control tipoControl)
        {
            switch (tipoControl.ToString())
            { 
                case "RadTextBox":

                    break;
                case "RadCheckBox":

                    break;
                case "TextBox":
                    break;
                case "MaskedTextBox":

                    break;
                default: break;
            }
        }
        private void LimpiarSubControles(Control subControl)
        {
            switch (subControl.GetType().ToString())
            {                    
                case "Telerik.WinControls.UI.RadTextBox":
                    subControl.Text = "";
                    break;
                
                case "System.Windows.Forms.TextBox":
                    subControl.Text = "";
                    break;
                case "System.Windows.Forms.MaskedTextBox":
                    subControl.Text = "";
                    break;
                default:
                    break;
            }
        }
        private void LimpiarControles()
        {
            foreach (Control c in this.Controls)
            {
                if (c is RadPanel)
                { 
                    foreach(Control controlesPanel in c.Controls)
                    {
                        LimpiarSubControles(controlesPanel);
                    }
                }
            }
        }
        private void BloquearControlesTexto(bool estado = false)
        {
            foreach (Control c in this.Controls)
            {
                
                if (c is RadPanel)
                { 
                    foreach(Control controlesPanel in c.Controls)
                    {
                        
                            
                        if (controlesPanel is RadTextBox)
                        {
                            AsignarEstadoLectura(controlesPanel, estado);
                              
                        }
                        if (controlesPanel is RadioButton)

                        {
                            AsignarEstadoLectura(controlesPanel);
                           
                        }
                    }
                }
                
                
            }
        }
        private void OcultaBOtonesMantenimiento(bool estado = false)
        {
            //btnNuevo.Visibility = estado == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            //btnEditar.Visibility = estado == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            //btnEliminar.Visibility = estado == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            //btnGuardar.Visibility = estado == false ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            //btnCancelar.Visibility = estado == false ? ElementVisibility.Visible : ElementVisibility.Collapsed;

        }
        private void VerBotonesPorEstado(FormEstate estado)
        {
            //OcultaBOtonesMantenimiento();
            //switch (estado)
            //{ 
            //    case FormEstate.New:
            //        btnGuardar.Visibility = ElementVisibility.Visible;
            //        btnCancelar.Visibility = ElementVisibility.Visible;
            //        break;
            //    case FormEstate.Edit:
            //        btnGuardar.Visibility = ElementVisibility.Visible;
            //        btnCancelar.Visibility = ElementVisibility.Visible;
            //        break;
            //    case FormEstate.List:
            //        btnNuevo.Visibility = ElementVisibility.Visible;
            //        btnEditar.Visibility = ElementVisibility.Visible;
            //        btnEliminar.Visibility = ElementVisibility.Visible;
            //        break;
            //    default:
            //        System.Console.Write("Opcion no valido");
            //        break;
            //}
        }
        private void HabilitarControles(bool estado)
        {
            
            
            //txtCodigo.Enabled = estado;
            ////txtCodigoDesc.Enabled = false;
            //txtAlmacen.Enabled = estado;
            ////txtAlmacenDesc.Enabled = false;
            //txtDescripcion.Enabled = estado;
            //txtCantidad.Enabled = estado;
            //txtUnidad.Enabled = estado;
            //txtCostoSoles.Enabled = estado;
            //txtImporteSoles.Enabled = estado;
            //txtCostoDolares.Enabled = estado;
            //txtImporteDolares.Enabled = estado;

        }
        
        string correlativo = "";
        private void TraerAyuda(enmAyuda tipo)
        {
            frmBusqueda frm;
            string codigo = "";
            string[] datos;
            switch (tipo)
            { 
                  
                case enmAyuda.enmArticulosOrdenCompra:
                    codigo =  FrmParent.anioOrdenCompra + "|"+                        
                              FrmParent.mesOrdenCompra + "|" +
                              FrmParent.tipoOrdenCompra + "|" +
                              FrmParent.nroDocumentoOrdenCompra;
                    Cursor.Current = Cursors.WaitCursor;
                    frm = new frmBusqueda(tipo,codigo);                    
                    frm.ShowDialog();
                    Cursor.Current = Cursors.Default;
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    
                    //evaluar si la moneda seleccionado
                    double tipoCambio = 0, cantidad = 0, importeSoles = 0, 
                            importeDolares = 0, costoSoles = 0, costoDolares = 0, importe = 0,
                            costoUnitarioSoles = 0, costoUnitarioDolares = 0;
                    //1.Valores a pasar del registro ayuda seleccionado:
                    //1.1.Codigo producto
                    //1.2.descripcion producto
                    //1.3.unidad
                    //1.4.
                    //evaluo segun el valor tipo de moneda seleccionado de la cabecera del documento
                    if (rbSoles.Checked)
                    {
                        //Asignar valores de columnas
                        
                            
                            //celdas datos detalle
                            Util.SetValueCurrentCellText(gridControl.CurrentRow, "CodigoArticulo", datos[0]);
                            Util.SetValueCurrentCellText(gridControl.CurrentRow, "Cantidad", datos[2]);
                            Util.SetValueCurrentCellText(gridControl.CurrentRow, "In01Deslar", datos[1]);
                            Util.SetValueCurrentCellText(gridControl.CurrentRow, "UnidadMedida", datos[6]);
                            //el costo unitario por defecto esta en soles
                            Util.SetValueCurrentCellText(gridControl.CurrentRow, "Importe", datos[4]);
                             
                            //el importe por defecto esta en Soles                            
                            importe = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Importe");

                            cantidad = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Cantidad");



                            tipoCambio = Convert.ToDouble(txttipodecambio.Text);
                            importeSoles = importe;
                            costoUnitarioSoles = importeSoles / cantidad;
                            
                            //transformo a dolares 
                            importeDolares = (importeSoles / tipoCambio);
                            costoUnitarioDolares = importeDolares / cantidad;



                            Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoUnidad", costoUnitarioSoles);
                            //se obtiene el costo unitario dividiendo importe entre cantidad o se define por el usuario
                            Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoSoles", costoUnitarioSoles);
                            Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "ImporteSoles", importeSoles);

                            Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoDolares", costoUnitarioDolares);
                            Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "ImporteDolar", importeDolares);
                            
                            //IN07IMPDOL
                            //celdas para importes                                                                    

                        
                    }
                    else {
                        //datos generales
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "CodigoArticulo", datos[0]);
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "Cantidad", datos[2]);
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "In01Deslar", datos[1]);
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "UnidadMedida", datos[6]);

                        //asignar dolares
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "ImporteDolar", datos[4]);

                        //Leer los datos y almacenar en variable double
                        tipoCambio = Convert.ToDouble(txttipodecambio.Text);
                        cantidad = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Cantidad");

                        importeDolares = Util.GetCurrentCellDbl(gridControl.CurrentRow, "ImporteDolar");                        
                        importeSoles = importeDolares * tipoCambio;
                        
                        costoUnitarioSoles = importeSoles / cantidad;
                        costoUnitarioDolares = importeDolares / cantidad;


                        Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoUnidad", costoUnitarioSoles);
                        //se obtiene el costo unitario dividiendo importe entre cantidad o se define por el usuario
                        Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoSoles", costoUnitarioSoles);
                        Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "ImporteSoles", importeSoles);

                        Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoDolares", costoUnitarioDolares);
                        Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "ImporteDolar", importeDolares);

                     

                    }
                    correlativo = datos[5];
                    break;
                case enmAyuda.enmAlmacen:
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');

                    
                        //asignar codigo de almacen
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "CodigoAlmacen", datos[0]);
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "AlmacenDesc", datos[1]);
                        
                    
                    break;
            }
            //switch (tipo)
            //{ 
            //    //case enmAyuda.
            //}

            
        }
        private void frmProvRegInventario_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            OcultarBotones();
            BloquearControlesTexto();
            HabilitarControles(false);

            CargarDetalle();
            Util.ConfigGridToEnterNavigation(gridControl);
        }
        private void nuevoDetalle() {
            try
            {
                GridViewRowInfo fila;
                if (gridControl.Rows.Count == 0)
                {
                    //agregar nueva fila grilla
                    fila = gridControl.Rows.AddNew();
                    //resaltaar la ayuda
                    Util.ResaltarAyuda(gridControl, "CodigoAlmacen");
                    Util.ResaltarAyuda(gridControl, "CodigoArticulo");
                    Util.SetValueCurrentCellText(fila, "flag", "0");
                    Util.SetCellGridFocus(fila, "CodigoAlmacen");
                }
                else {
                    string flag = Util.GetCurrentCellText(gridControl.CurrentRow, "flag");

                    if (flag == "0" || flag == "1")
                    {
                        Util.ShowAlert("Debe completar el registro");
                        return;
                    }
                

                    fila = gridControl.Rows.AddNew();
                    //resaltaar la ayuda
                    Util.SetValueCurrentCellText(fila, "flag", "0");
                    

                    Util.ResaltarAyuda(gridControl, "CodigoAlmacen");
                    Util.ResaltarAyuda(gridControl, "CodigoArticulo");

                    Util.SetCellGridFocus(fila, "CodigoAlmacen");
                    
                }
                
                
            }
            catch (Exception ex) {
                Util.ShowError("error nuevo detalle");
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            nuevoDetalle();
            if (gridControl.ContainsFocus)
            {
                
            }
            else {
                /*
                LimpiarControles();

                HabilitarControles(true);
                Estado = FormEstate.New;
                VerBotonesPorEstado(FormEstate.New);
                txtCodigo.Focus();
                Util.ResaltarAyuda(txtCodigo);
                Util.ResaltarAyuda(txtAlmacen);
                 * */
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridControl.ContainsFocus)
            {
                editarDetalle();
            }
            else {
                HabilitarControles(true);
                Estado = FormEstate.Edit;
                VerBotonesPorEstado(FormEstate.Edit);
                //txtCodigo.Enabled = false;
                //Util.ResaltarAyuda(txtAlmacen);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            int flag = 0;
            //comentado temporalmente
            //Eliminar(out flag, out mensaje);
            if(flag == 1)
            {
                CargarDetalle();
            }
        }
        
        private double LeerImporteyCostos(string flagImpCos, string valorConvertido)
        {
            double valorDinero = 0;
            GridViewRowInfo fila = gridControl.CurrentRow;
            if (valorConvertido == "NO")
            { 

                if(flagImpCos =="Importe")
                {
                    valorDinero = rbSoles.Checked ? Util.GetCurrentCellDbl(fila, "ImporteSoles") : Util.GetCurrentCellDbl(fila, "ImporteDolar");
                    
                }else if (flagImpCos == "Costo")
                {
                    valorDinero = rbSoles.Checked ? Util.GetCurrentCellDbl(fila, "CostoSoles") : Util.GetCurrentCellDbl(fila, "CostoDolares");
                }
            }
            else if (valorConvertido == "SI")
            {
                if (flagImpCos == "Importe")
                {
                    valorDinero = rbSoles.Checked ? Util.GetCurrentCellDbl(fila, "ImporteDolar") : Util.GetCurrentCellDbl(fila, "ImporteSoles");
                }
                else if (flagImpCos == "Costo")
                {
                    valorDinero = rbSoles.Checked ? Util.GetCurrentCellDbl(fila, "CostoDolares") : Util.GetCurrentCellDbl(fila, "CostoSoles");
                }
            }
            return valorDinero;

        }
        private void Insertar( out  int flag, out string mensaje)
        {
            
            flag = 0; mensaje = "";
            try
            {
                //generar numero de orden
                double nroOrden = 0;

                string codigoProducto = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoArticulo");
                string codigoAlmacen = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoAlmacen");
                double cantidad = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Cantidad");
                
                GuiaCompraLogic.Instance.TraerNroIrdenMovimiento(Logueo.CodigoEmpresa, Logueo.anioDocumento,
                    Logueo.Mes, txtTransaccionCod.Text, txtTransaccionNumero.Text, out nroOrden);

                string unidad = "";
                string unimed = Util.GetCurrentCellText(gridControl.CurrentRow, "UnidadMedida");

                string moneda="";

                if (rbSoles.Checked==true)
                    {moneda="S";} 
                else if(rbDolares.Checked==true)
                    { moneda = "D";} 

                
                LogicaGuia.InsertarDetalleDocumento(Logueo.CodigoEmpresa,
                     Logueo.Anio,
                     dtpFechaDoc.Text,
                     txtTransaccionCod.Text,
                     txtTransaccionNumero.Text,
                     codigoProducto,
                     codigoAlmacen,
                     txtDocRespaldoCod.Text,
                     "E",
                     cantidad,
                     LeerImporteyCostos("Costo", "NO"),
                     LeerImporteyCostos("Importe", "NO"),
                     LeerImporteyCostos("Costo", "SI"),
                     LeerImporteyCostos("Importe", "SI"),
                     dtpFechaDoc.Text,
                     Convert.ToDouble(txttipodecambio.Text),
                     moneda,
                     nroOrden, 
                     Logueo.CodigoEmpresa,
                     FrmParent.nroDocumentoOrdenCompra,
                     correlativo,
                     unidad,
                     FrmParent.anioOrdenCompra,
                     out flag, out mensaje);
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al insertar");
            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //string nroOrdenDocumento = "";
                //int flag = 0; string mensaje = "";
                
                ////TraerMetodoLogico("numeroOrden", out nroOrdenDocumento);
                
                

                //if (Estado == FormEstate.New)
                //{
                //    Insertar(nroOrdenDocumento, out flag, out mensaje);
                //    if (flag == 1)
                //    {
                //        Estado = FormEstate.Edit;
                //    }
                    
                //}
                //else if(Estado == FormEstate.Edit) {
                    
                //    //la actualizacion pasa por eliminar e insertar.
                //    Eliminar(out flag, out mensaje);
                //    Util.ShowMessage(mensaje, flag);
                //    if (flag == 1)
                //    {
                //        Insertar(nroOrdenDocumento, out flag, out mensaje);
                //        Estado = FormEstate.Edit;
                //    }
                //}

                //if (flag == 1)
                //{
                //    //Refresco la grilla
                //    CargarDetalle();
                //    //Deshabilito todos los controles
                //    HabilitarControles(false);
                //    //Regreso a ver las opciones de Lista, Nuevo, Editar y Eliminar
                //    Estado = FormEstate.List;
                //    VerBotonesPorEstado(FormEstate.List);
                //}
                //Cursor.Current = Cursors.Default;   
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al prcocesar Guardar o Actualizar");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            Estado = FormEstate.List;
            VerBotonesPorEstado(Estado);
            //Util.ResetearAyuda(txtCodigo);
            //Util.ResetearAyuda(txtAlmacen);
        }
             
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.gridControl.RowCount == 0)
                return;
            //Traer ayuda
            if (e.KeyValue == (char)Keys.F1) {

                if (Util.IsCurrentColumn(gridControl.CurrentColumn, "CodigoAlmacen"))
                {
                    TraerAyuda(enmAyuda.enmAlmacen);
                }

                if (Util.IsCurrentColumn(gridControl.CurrentColumn, "CodigoArticulo"))
                {
                    TraerAyuda(enmAyuda.enmArticulosOrdenCompra);
                }
            }
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
                    //desactiva grabar, cancelar, eliminar, editar
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, false, false);
                    return;
                }
                
                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {// si es modo ver 
                    //desactiva grabar, cancelar , activar eliminar , editar
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                }
                else
                {// si es modo grabar o cancelar
                    //activa grabar, cancelar, activa elimina, editar
                    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);
                }
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

        private void guardarDetalle() {
            try
            {
                GridViewRowInfo fila = gridControl.CurrentRow;
                Cursor.Current = Cursors.WaitCursor;
                double nroOrdenDocumento = 0;
                int flag = 0; string mensaje = "";


                string moneda = "";

                if (rbSoles.Checked==true)
                    moneda="S";
                else
                    moneda="D";

                string flagEstado =  Util.GetCurrentCellText(fila, "flag");
                string codigoProducto = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoArticulo");
                string codigoAlmacen = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoAlmacen");
                double cantidad = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Cantidad");
                string unimed = Util.GetCurrentCellText(gridControl.CurrentRow, "UnidadMedida");

                if (flagEstado == "0") {
                    GuiaCompraLogic.Instance.TraeDameNoDetalleMovi(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                    txtTransaccionCod.Text, txtTransaccionNumero.Text, out nroOrdenDocumento);
                    //generar numero de orden
                    //double nroOrden = 0;
                    //Util.GetCurrentCellText("orden
                    LogicaGuia.InsertarDetalleDocumento(Logueo.CodigoEmpresa,
                         Logueo.Anio, Logueo.Mes,
                         txtTransaccionCod.Text, txtTransaccionNumero.Text, codigoProducto,
                         codigoAlmacen, txtDocRespaldoCod.Text, "E", cantidad,
                         LeerImporteyCostos("Costo", "NO"),
                         LeerImporteyCostos("Importe", "NO"),
                         LeerImporteyCostos("Costo", "SI"),
                         LeerImporteyCostos("Importe", "SI"),
                         dtpFechaDoc.Text, Convert.ToDouble(txttipodecambio.Text), moneda,
                         nroOrdenDocumento, Logueo.CodigoEmpresa, FrmParent.nroDocumentoOrdenCompra,
                         correlativo, unimed, FrmParent.anioOrdenCompra,
                         out flag, out mensaje);

                    //Insertar(nroOrdenDocumento, out flag, out mensaje);
                    //Insertar(

                }
                    //modo editar de la fila d eun agrilla
                else if (flagEstado == "1")
                {
                    //string txtcod = "";
                    //string codigoProducto = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoArticulo");
                    LogicaGuia.EliminarDetalleDocumento(Logueo.CodigoEmpresa, Logueo.Anio,
                    Logueo.Mes, txtTransaccionCod.Text,
                    txtTransaccionNumero.Text, codigoProducto, Util.GetCurrentCellDbl(gridControl, "Orden"),
                    "E", dtpFechaDoc.Text, Convert.ToDouble(txttipodecambio.Text), moneda,
                    FrmParent.nroDocumentoOrdenCompra, FrmParent.anioOrdenCompra, out flag,
                    out mensaje);

                    GuiaCompraLogic.Instance.TraeDameNoDetalleMovi(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                    txtTransaccionCod.Text, txtTransaccionNumero.Text, out nroOrdenDocumento);

                    LogicaGuia.InsertarDetalleDocumento(Logueo.CodigoEmpresa,
                        Logueo.Anio, Logueo.Mes,
                        txtTransaccionCod.Text, txtTransaccionNumero.Text, codigoProducto,
                        codigoAlmacen, txtDocRespaldoCod.Text, "E", cantidad,
                        LeerImporteyCostos("Costo", "NO"),
                        LeerImporteyCostos("Importe", "NO"),
                        LeerImporteyCostos("Costo", "SI"),
                        LeerImporteyCostos("Importe", "SI"),
                        dtpFechaDoc.Text, Convert.ToDouble(txttipodecambio.Text), moneda,
                        nroOrdenDocumento, Logueo.CodigoEmpresa, FrmParent.nroDocumentoOrdenCompra,
                        correlativo, unimed, FrmParent.anioOrdenCompra,
                        out flag, out mensaje);

                }
                
                Util.ShowMessage(mensaje, flag);

                if (flag == 1)
                {
                    //Almacenamos al varaible de orden de la fila trabajada
                    Movimiento movimientoregistro = new Movimiento();
                    movimientoregistro.Orden = nroOrdenDocumento;
                    Util.SetValueCurrentCellDbl(gridControl, "Orden", nroOrdenDocumento);
                    //Refresco la grilla
                    CargarDetalle();

                    //enfocamos la fila trabajado por su identificador de Orden.
                    Util.enfocarFila(gridControl, "Orden", movimientoregistro.Orden.ToString());

                }
                Cursor.Current = Cursors.Default;   
            }catch (Exception ex) {
                Util.ShowError("Error al guardar detalle:" + ex.Message);
            }
        }

        private void cancelarDetalle() {
            try
            {
                CargarDetalle();
            }
            catch (Exception ex) {
                Util.ShowError("Error al cancelar detalle");
            }
        }

        private void editarDetalle() {
            try
            {
                Util.ResaltarAyuda(gridControl, "CodigoAlmacen");
                Util.ResaltarAyuda(gridControl, "CodigoArticulo");
                Util.SetValueCurrentCellText(gridControl.CurrentRow, "flag", "1");
                Util.SetCellGridFocus(gridControl.CurrentRow, "CodigoAlmacen");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al editar detalle");
            }
        }

        private void eliminarDetalle() {
            int flag = 0; string mensaje = "";
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                string moneda = "";

                if (rbSoles.Checked == true)
                    moneda = "S";
                else
                    moneda = "D";

                if (respuesta == true) {
                    string codigoArticulo = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoArticulo");
                    LogicaGuia.EliminarDetalleDocumento(Logueo.CodigoEmpresa, Logueo.Anio,
                    Logueo.Mes,
                    txtTransaccionCod.Text,
                    txtTransaccionNumero.Text,
                    codigoArticulo,
                    Util.GetCurrentCellDbl(gridControl, "Orden"),
                    "E",
                    dtpFechaDoc.Text,
                    Convert.ToDouble(txttipodecambio.Text),
                    moneda,
                    FrmParent.nroDocumentoOrdenCompra,
                    FrmParent.anioOrdenCompra,
                    
                    out flag,
                    out mensaje);
                    Util.ShowMessage(mensaje, flag);
                    if (flag == 1) {
                        cancelarDetalle();
                    }

                }
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al Eliminar");
            }
        }

        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabar"].IsCurrent)
            {
                this.guardarDetalle();
            }
            if (this.gridControl.Columns["btnCancelar"].IsCurrent)
            {
                this.cancelarDetalle();
            }
            if (this.gridControl.Columns["btnEliminar"].IsCurrent)
            {
                this.eliminarDetalle();
            }
            if (this.gridControl.Columns["btnEditar"].IsCurrent)
            {
                this.editarDetalle();
            }
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.gridControl.ActiveEditor == null) { return; }

                if (e.Row == null) return;

                string flag = Util.GetCurrentCellText(e.Row, "flag");


                if (flag == "")
                {
                    e.Cancel = true;
                }
                else if(flag == "0"){
                    e.Cancel = false;
                }
                else if (flag == "1") {
                    if (e.Column.Name == "CodigoArticulo")
                    {
                        e.Cancel = true;
                    }
                    e.Cancel = false;
                }
            }
            catch (Exception ex) {
                Util.ShowError("Error cellbeginedit");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            nuevoDetalle();
        }

      
        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if (gridControl.Rows.Count == 0) return;

                if (e.CurrentRow.Cells["flag"].Value != null)
                {
                    if (Util.GetCurrentCellText(e.CurrentRow, "flag") == "1" ||
                        Util.GetCurrentCellText(e.CurrentRow, "flag") == "0")
                    {
                        e.Cancel = true;
                    }

                }
            }
            catch (Exception ex) {
                //Util.ShowAlert("Error en current row changing");
            }
            
        }

        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            double cantidad = 0;
            double importeSoles = 0, importeDolares = 0, costoUnitarioSoles = 0, costoUnitarioDolares = 0;
            //validar que debemos 
            if (e.Column.Name == "Cantidad")
            {
                
                cantidad = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Cantidad");
                
                //leer el valor de los costos unitario

                costoUnitarioDolares = Util.Redondear(Util.GetCurrentCellDbl(gridControl.CurrentRow, "CostoDolares"), 6);
                costoUnitarioSoles = Util.Redondear(Util.GetCurrentCellDbl(gridControl.CurrentRow, "CostoSoles"), 6);
                
                
                //calcular el costo unitario cuando se cambia el valor de la celda cantidad
                importeDolares = Util.Redondear(costoUnitarioDolares * cantidad, 2);
                importeSoles = Util.Redondear(costoUnitarioSoles * cantidad,2);
                              
            }
            if (e.Column.Name == "CostoDolares")
            {
                //leer los valores de costo dolares
                cantidad = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Cantidad");

                costoUnitarioDolares = Util.Redondear( Util.GetCurrentCellDbl(gridControl.CurrentRow, "CostoDolares"), 6);
                
                //convetir el valor Costo unitario Dolares en Costo unitario Soles
                costoUnitarioSoles = Util.Redondear(costoUnitarioDolares * Convert.ToDouble(txttipodecambio.Text), 6);
                Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoSoles", costoUnitarioSoles);
                //Calcular el importe de ambos tipo de moneda
                importeDolares = Util.Redondear(cantidad * costoUnitarioDolares,2);
                importeSoles = Util.Redondear(cantidad * costoUnitarioSoles,2);
                
            }
            if (e.Column.Name == "CostoSoles")
            {
                //leer los valores de costo soles
                cantidad = Util.GetCurrentCellDbl(gridControl.CurrentRow, "Cantidad");
                costoUnitarioSoles = Util.Redondear(Util.GetCurrentCellDbl(gridControl.CurrentRow, "CostoSoles"),6);
                
                //calcular el valor de costo unitario soles convertido en costo unitario dolares
                costoUnitarioDolares = Util.Redondear(costoUnitarioSoles / Convert.ToDouble(txttipodecambio.Text),6);
                
                Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "CostoDolares", costoUnitarioDolares);
                //calcular el importe 
                importeSoles = Util.Redondear(cantidad * costoUnitarioSoles,2);
                importeDolares = Util.Redondear(cantidad * costoUnitarioDolares,2);

            }
            if (e.Column.Name == "CostoSoles" || e.Column.Name == "CostoDolares" || e.Column.Name == "Cantidad")
            {
                //asignar los impotes a las celdas
                Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "ImporteDolar", importeDolares);
                Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "ImporteSoles", importeSoles);
            }
            

        }

        private void lblProveedor_TextChanged(object sender, EventArgs e)
        {

            string codigo = Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + txtProveedorCod.Text.Trim();
            string descripcion = "";
            GlobalLogic.Instance.DameDescripcion(codigo, "PROVEEDOR", out descripcion);
            this.lblProveedorDesc.Text = descripcion;
            this.txtClienteCab.Text = descripcion;
        }

        private void gpxObservacion_Click(object sender, EventArgs e)
        {

        }

        private void lblProveedorDesc_TextChanged(object sender, EventArgs e)
        {
            //string codigo = Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + txtProveedorCod.Text.Trim();
            //string descripcion = "";
            //GlobalLogic.Instance.DameDescripcion(codigo, "PROVEEDOR", out descripcion);
            //this.lblProveedorDesc.Text = descripcion;
            //this.txtClienteCab.Text = descripcion;
          
        }
    }
}
