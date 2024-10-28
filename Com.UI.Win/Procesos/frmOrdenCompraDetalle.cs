using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using CrystalDecisions.Shared;
namespace Com.UI.Win
{
    //VERDADERO
    public partial class frmOrdenCompraDetalle : frmBaseReg
    {
        private string EstadoDocumento = "", FlagCancelado = "", flagImporte = "";
        string InsertaroActualizarDetalle = ""; 
        int ultimacolumnavisibledelagrilla = 0;
        string InsertarOActualizarDetalle = ""; // N = Nuevo , M= Modficar, "2 = Ningua Operacion
        // == Instancia para Listado de Factura
        #region "Instancia desde Listado de factura"
        private static frmOrdenCompraDetalle _aForm;
        private frmOrdenesdeCompra FrmParent { get; set; }
        public static frmOrdenCompraDetalle Instance(frmOrdenesdeCompra padre)
        {
            if (_aForm != null) return new frmOrdenCompraDetalle(padre);
            _aForm = new frmOrdenCompraDetalle(padre);
            return _aForm;
        }
        #endregion
        
        

        public frmOrdenCompraDetalle(frmOrdenesdeCompra padre)
        {
            InitializeComponent();
            FrmParent = padre;
            //Util.ConfigGridToEnterNavigation(this.gridControlDetalle);
        }

        private void frmOrdenCompraDetalle_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            //detalle del documento                        
            CrearColumnas();
            //ocultar ventan de osbervacion
            
            OcultarObservacion();
            Util.ResaltarAyuda(txtEntregaCod);
            txtEntregaCod.Visible = true;
            txtIGVPorcentaje.Text = Logueo.Igv.ToString();
            txtIGVPorcentaje.Enabled = false;
            txtTipoOC.Text = FrmParent.tipoOrden;

            if (FrmParent.tipoOrden == "T") {
                this.Text = "Orden de trabajo Detalle";
            }
            else if (FrmParent.tipoOrden == "C") {
                this.Text = "Orden de compra Detalle";
            }

            if (FrmParent.Estado == FormEstate.New)
            {
                string nroOrden = "";
                CompraDocumentoLogic.Instance.TraeCodigoNroOrden(Logueo.CodigoEmpresa,Logueo.Anio, txtTipoOC.Text.Trim(), out nroOrden);
                txtOCNro.Text = nroOrden.Trim();
                
                txtUsuarioLogisticaDes.Text = Logueo.UserName;
                dsc1 = 0; dsc2 = 0;
                IniciarControles();
                
                MantenimientoFormularioPadre();
                Estado = FormEstate.New;
                
            }
            else if (FrmParent.Estado == FormEstate.Edit)
            {
                //LimpiarCabecera();
                txtOCNro.Text = FrmParent.numeroOrden;
                
                txtUsuarioLogisticaDes.Text = Logueo.UserName;
                CargarCabecera();
                CargarDetalle();
                //DeshabilitarTextos();
                txtOCNro.Enabled = false;
                //HabilitarTexto();
                MantenimientoFormularioPadre();
                Estado = FormEstate.Edit;
                
            }
            else if(FrmParent.Estado == FormEstate.View) { 
             //vista
                txtOCNro.Text = FrmParent.numeroOrden;
                CargarCabecera();
                DeshabilitarTextos();
                CargarDetalle();
                MantenimientoFormularioPadre();
                //Estado = FormEstate.View;
                Estado = FormEstate.Cancel;
                MantenimientoCabecera();
            }
            
        }
        
        private void TraerDatos()
        { 
            
        }
        private void OcultarObservacion()
        {
            gpxObservacion.Visible = false;
            gpxObservacion.SendToBack();
            
        }
        private void VerObservacion()
        {
            gpxObservacion.Visible = true;
            gpxObservacion.BringToFront();
            
            string memo = Util.GetCurrentCellText(this.gridControlDetalle.CurrentRow, "Memo");
            txtMemo.Text = "";
            if (memo != "")
            {
                
                txtMemo.Text = LeerContenidoMemo(memo);
            }
            txtMemo.Focus();
        }
        private string LeerContenidoMemo(string valorMemo)
        {
            string textoFormateado = "";
            string[] lineas = valorMemo.Split('§');
         
            
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (i < lineas.Length - 1)
                    {
                        textoFormateado += lineas[i] + Environment.NewLine;
                    }
                    else if (i == lineas.Length - 1)
                    {
                        textoFormateado += lineas[i];
                    }
                }

                return textoFormateado;
        }
        private void CrearColumnas()
        {            
            try
            {
                
            RadGridView Grid = CreateGridVista(this.gridControlDetalle);
            bool LecturaNo = false, LecturaSi = true, EditaSi = false, EditaNo = false, VisibleSi = true, VisibleNo = false;
            bool esNumericoSi = true, esNumericoNo = false;
            //bool flag = Grilla.columna.EditableNo;        //readOnly, AllowEdit, Visibel
                CreateGridColumn(Grid, "TipoOrdenDetalle", "TipoOrdenDetalle", 0, "", 70, LecturaNo, EditaSi, VisibleNo);//varchar
                CreateGridColumn(Grid, "Item", "Item", 0, "", 70, LecturaNo, EditaSi, VisibleNo);//varchar /
                CreateGridColumn(Grid, "Codigo", "CodigoArticulo", 0, "", 100, LecturaNo, EditaSi, VisibleSi);//varchar
                CreateGridColumn(Grid, "Descripcion", "NombreArticulo", 0, "", 200, LecturaNo, EditaNo, VisibleSi);//varchar //columna descripcion de articulo                
                //CreateGridColumn(Grid, "Especificacion", "Memo", 0, "", 100, LecturaNo, EditaSi, VisibleSi);//varchar

                AddCmdButtonToGrid(gridControlDetalle, "btnMemo", "", "btnMemo");
                CreateGridColumn(Grid, "Memo", "Memo", 0, "", 70, LecturaNo, EditaSi, VisibleNo);//contenido de memmo

                CreateGridColumn(Grid, "U.M", "Unidad", 0, "", 60, LecturaSi, EditaNo, VisibleSi);//varchar                
                CreateGridColumn(Grid, "Cantidad", "Cantidad", 0, "{0:F02}", 90, LecturaNo, EditaSi, VisibleSi, esNumericoNo, "right");//float                
                CreateGridColumn(Grid, "C.Atendida", "CantidadAtendida", 0, "{0:F02}", 90, LecturaSi, EditaNo, VisibleNo, esNumericoNo, "right");//float
                CreateGridColumn(Grid, "Precio\nUnitario", "Precio", 0, "{0:F06}", 90, LecturaNo, EditaSi, VisibleSi, esNumericoNo, "right");//float
                CreateGridColumn(Grid, "Subtotal", "ImporteBruto", 0, "{0:F02}", 90, LecturaNo, EditaSi, VisibleSi, esNumericoNo, "right");//float
                CreateGridColumn(Grid, "Dscto1", "Descuento1", 0, "{0:F02}", 80, LecturaNo, EditaSi, VisibleSi, esNumericoNo, "right");//float
                CreateGridColumn(Grid, "Dscto2", "Descuento2", 0, "{0:F02}", 80, LecturaNo, EditaSi, VisibleNo, esNumericoNo, "right");//float
                CreateGridColumn(Grid, "Base \nIgv", "BaseIGV", 0, "{0:F02}", 80, LecturaSi, EditaNo, VisibleSi, esNumericoNo, "right"); //

                //va a la cabecera -- > valor para representar porcentea
                CreateGridColumn(Grid, "Igv", "Igv", 0, "{0:F02}", 70, LecturaNo, EditaSi, VisibleNo, false, "right");//float -- | 

                CreateGridColumn(Grid, "Importe.\nIgv", "ImporteIgv", 0, "{0:F02}", 90, LecturaSi, EditaNo, VisibleSi, false, "right");//float
                CreateGridColumn(Grid, "Total", "Total", 0, "{0:F02}", 70, LecturaSi, EditaNo, VisibleSi, false, "right");//float
                
                
                // Columna con el codigo de destino
                CreateGridColumn(Grid, "Destino", "Destino", 0, "", 70, LecturaNo, EditaSi, VisibleNo);//varchar 

                // Columna creado desde la consulta , descrcipn Destino CO04AREADES
                CreateGridColumn(Grid, "Desc.", "DestinoDes", 0, "", 70, LecturaNo, EditaSi, VisibleNo);//varchar 

                //SUPUESTO IMAGEN
                CreateGridColumn(Grid, "Imagen", "ArchivoImg", 0, "", 100, LecturaNo, EditaSi, VisibleNo);//varchar
                
                CreateGridColumn(Grid, "Flag", "Flag", 0, "", 70, LecturaNo, EditaSi, VisibleNo);//varchar
                
                //Formato numero para Columna precio unitario

                //columna eliminar registro      
                AddCmdButtonToGrid(gridControlDetalle, "btnEliminarDet", "", "btnEliminarDet");

                //GridViewDataColumn columnaPrecioUnitario = this.gridControlDetalle.Columns["Precio"];
                //((GridViewMaskBoxColumn)columnaPrecioUnitario).Mask = "{0:F06}";

                //GridViewDataColumn columnaImpBruto = this.gridControlDetalle.Columns["ImporteBruto"];
                //((GridViewMaskBoxColumn)columnaImpBruto).Mask = "f2";

                //GridViewDataColumn columnaImpIgv = this.gridControlDetalle.Columns["ImporteIgv"];
                //((GridViewMaskBoxColumn)columnaImpIgv).Mask = "f2";

                //GridViewDataColumn columnaTotal = this.gridControlDetalle.Columns["Total"];
                //((GridViewMaskBoxColumn)columnaTotal).Mask = "f2";


                if (gridControlDetalle.MasterView.SummaryRows.Count == 0) 
                {
                    string[] fieldstosummary = { "ImporteBruto", "Descuento1", "BaseIGV", "ImporteIgv", "Total" };
                    Util.AddGridSummarySum(gridControlDetalle, fieldstosummary);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro en crear columnas, detalle: " + ex.Message);
            }


        }
        #region "Agregar botones a la grilla"



        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
            //Grid.Columns[NameButon].BestFit();
        }
        #endregion

        private bool ValidarDetalle(GridViewRowInfo fila)
        {
            if (Util.GetCurrentCellText(fila, "FAC05CODEMP") == ""
                            || Util.GetCurrentCellText(fila, "FAC01COD") == ""
                            || Util.GetCurrentCellText(fila, "FAC04NUMDOC") == ""
                            || Util.GetCurrentCellText(fila, "FAC05CODPROD") == ""
                            || Util.GetCurrentCellText(fila, "FAC05DESCPROD") == "")
            {
                Util.ShowAlert("Debe ingresar datos en el registro vacio");
                Util.SetCellInitEdit(fila, "FAC05CODPROD");
                return false;
            }
            if (Util.GetCurrentCellText(fila, "FAC05DESCPROD").Contains('|'))
            {
                Util.ShowAlert("La descripcion de producto no debe tener el caracter | en su descripcion");
                Util.SetCellInitEdit(fila, "FAC05DESCPROD");
                return false;
            }
            return true;
        }
        private void AgregarFila()
        {
            try
            {
               
                gridControlDetalle.Rows.AddNew();
                GridViewRowInfo row = this.gridControlDetalle.CurrentRow;
                int item = gridControlDetalle.Rows.Count;
                string codigoOrden = txtOCNro.Text;
                
                

                Util.SetValueCurrentCellText(row, "TipoOrdenDetalle", txtTipoOC.Text.Trim());
                
                
                Util.SetValueCurrentCellText(row, "Item", item.ToString());
                
                Util.SetValueCurrentCellText(row, "CodigoArticulo", "");
                Util.SetValueCurrentCellText(row, "NombreArticulo", "");
                Util.SetValueCurrentCellText(row, "Unidad", "");
                Util.SetValueCurrentCellInt(row, "Cantidad", 0);
                Util.SetValueCurrentCellDbl(row, "CantidadAtendida", 0);
                Util.SetValueCurrentCellInt(row, "Precio", 0);
                Util.SetValueCurrentCellInt(row, "Descuento1", 0);
                Util.SetValueCurrentCellInt(row, "Descuento2", 0);
                Util.SetValueCurrentCellInt(row, "ImporteBruto", 0);
                Util.SetValueCurrentCellInt(row, "Igv", 0);                
                Util.SetValueCurrentCellInt(row, "ImporteIgv", 0);
                Util.SetValueCurrentCellInt(row, "Total", 0);

                Util.SetValueCurrentCellText(row, "Destino", "");
                Util.SetValueCurrentCellText(row, "DestinoDes", "");

                Util.SetValueCurrentCellText(row, "ArchivoImg", "");
                Util.SetValueCurrentCellText(row, "Memo", "");
                
                
                //oflag para controlar el modo de la fila.
                Util.SetValueCurrentCellText(row, "Flag", "0"); // 0 -> Nuevo , 1 -> Editar , "" -> no edicion

                
                Util.ResaltarAyuda(gridControlDetalle.CurrentRow.Cells["CodigoArticulo"]);
                Util.ResaltarAyuda(gridControlDetalle.CurrentRow.Cells["Destino"]);
                Util.ResaltarAyuda(gridControlDetalle.CurrentRow.Cells["Memo"]);

                this.gridControlDetalle.Focus();
                Util.SetCellInitEdit(row, "CodigoArticulo");

                //Util.SetCellGridFocus(row, "CodigoArticulo");
                
                
                //if (Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "CodigoArticulo") == false) {
                //    Util.SetCellGridFocus(row, "CodigoArticulo");
                //    Util.SetCellInitEdit(row, "CodigoArticulo");    
                //}
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }



        }
        private void HabilitarTexto() 
        {
            foreach (Control c in this.Controls)
            {
                ((RadTextBox)c).Enabled = false;

            }
        }
        private void DeshabilitarTextos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is RadPanel)
                {
                    foreach (Control d in c.Controls)
                    {
                        if (d is RadTextBox)
                        {
                            ((RadTextBox)d).Enabled = false;
                        }
                        if (d is RadDateTimePicker)
                        {
                            ((RadDateTimePicker)d).Enabled = false;
                        }
                    }
                }                
            
            }
        }
        
        private void CargarCabecera()
        {
            try
            {

                GridViewRowInfo fila = FrmParent.gridControl.MasterView.CurrentRow;
                
                //txtTipoOC.Text = FrmParent.tipoOrden;
                txtOCNro.Text = Util.GetCurrentCellText(fila, "CodigoOrdenCompra");
                txtTipoOC.Text = Util.GetCurrentCellText(fila, "TipoOrdenCompra");
                dtpOCFecha.Value = Convert.ToDateTime(Util.GetCurrentCellText(fila, "FechaOrdenCompra"));
                txtProveedorCod.Text = Util.GetCurrentCellText(fila, "CodigoProveedor");
                txtProveedorDesc.Text = Util.GetCurrentCellText(fila, "NombreProveedor");
                EstadoDocumento = Util.GetCurrentCellText(fila, "Estado");
                FlagCancelado =  Util.GetCurrentCellText(fila, "FlagCancelado");
                flagImporte =  Util.GetCurrentCellText(fila, "FlagImporte");

                txtProveedorRuc.Text = Util.GetCurrentCellText(fila, "RucProveedor");
                txtProveedorTelf.Text =  Util.GetCurrentCellText(fila, "TelfProveedor");
                txtProveedorDirecc.Text =  Util.GetCurrentCellText(fila, "DireccProveedor");
                txtAtencion.Text =  Util.GetCurrentCellText(fila, "Atencion");
                txtNroSolicitud.Text =  Util.GetCurrentCellText(fila, "NroSolicitud");
                dtpFechaSolitud.Value = Convert.ToDateTime(Util.GetCurrentCellText(fila, "FechaSolicitud"));
                txtCentroCostroCod.Text =  Util.GetCurrentCellText(fila, "CentroCosto");
                txtCentroCostoDesc.Text =  Util.GetCurrentCellText(fila, "CentroCostoDesc");
                txtCompLocalExt.Text = Util.GetCurrentCellText(fila, "CompLocExt");
                txtFormaPagoCod.Text = Util.GetCurrentCellText(fila, "FormaPago");
                txtFormaPagoDesc.Text =  Util.GetCurrentCellText(fila, "FormaPagoDes");
                txtPlazoEntrega.Text = Util.GetCurrentCellText(fila, "PlazoEntrega");
                dtpFechaEntrega.Value = Convert.ToDateTime(Util.GetCurrentCellText(fila, "FechaEntrega"));

                txtEntregaCod.Text = Util.GetCurrentCellText(fila, "CodigoEntrega");
                txtEntregaDesc.Text = Util.GetCurrentCellText(fila, "DireccionEntrega");
                txtTipoCambio.Text = Util.GetCurrentCellText(fila, "TipoCambio");
                txtGiraCheque.Text = Util.GetCurrentCellText(fila, "GiraCheque");
                txtUsuarioLogisticaCod.Text = Util.GetCurrentCellText(fila, "UsuarioLogistica");
                txtUsuarioLogisticaDes.Text =  Util.GetCurrentCellText(fila, "UsuarioLogisticaDesc");
                txtDestino1.Text =  Util.GetCurrentCellText(fila, "Destino1");
                txtDestino2.Text = Util.GetCurrentCellText(fila, "Destino2");

                txtObservacion.Text = Util.GetCurrentCellText(fila, "Observacion").Trim();
                txtMonedaCod.Text = Util.GetCurrentCellText(fila, "TipoMoneda").Trim();
                txtMonedaDesc.Text = Util.GetCurrentCellText(fila, "TipoMonedaDesc").Trim();
                txtAreaCod.Text = Util.GetCurrentCellText(fila, "CodigoArea").Trim();
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al carga datos de cabera de documento, detalle: " + ex.Message);
            }
        }
        private void CargarDetalle()
        {
            try
            {

                List<DocumentoOrdenCompraDetalle> lista =  CompraDocumentoLogic.Instance.TraeDetalleOrdenCompra(Logueo.CodigoEmpresa,
                                                            Logueo.Anio, Logueo.Mes, txtTipoOC.Text.Trim(), txtOCNro.Text.Trim());
                if (lista.Count == 0)
                {
                    this.gridControlDetalle.Rows.Clear();
                }
                else {
                    
                    this.gridControlDetalle.DataSource = lista;

                }
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al carga datos de detalle de documento, detalle: " + ex.Message);
            }
        }
        private int ObtenerUltimaColumnaVisible()
        {
            int indiceMayor;
            indiceMayor = 0;
            foreach (GridViewColumn col in this.gridControlDetalle.Columns)
            {
                if (col.IsVisible && !(col is GridViewCommandColumn))
                {
                    //indiceMayor = col.Index;
                    if (col.Index > indiceMayor)
                    {
                        indiceMayor = col.Index;
                    }
                }
            }
            return indiceMayor;
        }
        
        
        private DodcumentoOrdenCompra CargarEntidad()
        {  
            DodcumentoOrdenCompra entidad = new DodcumentoOrdenCompra();
            entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
            entidad.Anio = Logueo.Anio;
            entidad.Mes = Logueo.Mes;
            // Tipo de orden tomando desde el formulario padre.
            
            entidad.TipoOrdenCompra =  txtTipoOC.Text.Trim();
            entidad.CodigoOrdenCompra = txtOCNro.Text.Trim();
            entidad.FechaOrdenCompra = dtpOCFecha.Value;
            entidad.CodigoProveedor = txtProveedorCod.Text.Trim();
            entidad.Atencion = txtAtencion.Text.Trim();
            entidad.NroSolicitud = txtNroSolicitud.Text.Trim();
            entidad.FechaSolicitud = dtpFechaSolitud.Value;
            entidad.CentroCosto = txtCentroCostroCod.Text.Trim();
            entidad.CompLocExt = txtCompLocalExt.Text.Trim();
            entidad.FormaPago = txtFormaPagoCod.Text.Trim();
            entidad.PlazoEntrega = txtPlazoEntrega.Text.Trim();
            entidad.FechaEntrega = dtpFechaEntrega.Value;
            //entidad.DireccionEntrega = txtDirEntregaCod.Text.Trim();
            //string CodigoEntrega = DameDescripcion(txtEntregaCod.Text,"LUGARENTREGA");
            entidad.CodigoEntrega = txtEntregaCod.Text.Trim();
            entidad.DireccionEntrega = txtEntregaDesc.Text.Trim();
            if (Util.EsNumero(txtTipoCambio.Text.Trim())==true)
                {entidad.TipoCambio = Convert.ToDouble(txtTipoCambio.Text.Trim());}
            else
            { entidad.TipoCambio = 1; }

            entidad.GiraCheque = txtGiraCheque.Text.Trim();
            entidad.Destino1 = txtDestino1.Text.Trim();
            entidad.Destino2 = txtDestino2.Text.Trim();
            entidad.Observacion = txtObservacion.Text.Trim();
            entidad.ImporteIgv = Logueo.Igv;
            entidad.TipoMoneda = txtMonedaCod.Text.Trim();
            entidad.UsuarioLogistica = txtUsuarioLogisticaCod.Text.Trim();
            entidad.CodigoArea = txtAreaCod.Text.Trim();
            
            return entidad;

        }
        private string DameDescripcion(string codigo, string flag)
        {

            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, codigo, flag, out descripcion);
            return descripcion;
        }
        #region "Cabecera del documento"
        private void IniciarControles()
        {
            txtTipoCambio.Text = "1.0000";
            
            dtpOCFecha.Value = DateTime.Now;
            dtpFechaEntrega.Value = DateTime.Now;
            dtpFechaSolitud.Value = DateTime.Now;

            Util.ResaltarAyuda(txtProveedorCod);
            Util.ResaltarAyuda(txtMonedaCod);
            Util.ResaltarAyuda(txtFormaPagoCod);
            Util.ResaltarAyuda(txtCentroCostroCod);
            Util.ResaltarAyuda(txtUsuarioLogisticaCod);
            Util.ResaltarAyuda(txtEntregaCod);

        }

        private void LimpiarControles()
        {
            txtOCNro.Text = "";
            txtTipoOC.Text = "";

            txtProveedorCod.Text = "";
            txtProveedorDesc.Text = "";
            txtProveedorRuc.Text = "";
            txtProveedorTelf.Text = "";
            txtProveedorDirecc.Text = "";


            txtMonedaCod.Text = "";
            txtMonedaDesc.Text = "";

            txtNroSolicitud.Text = "";

            txtAtencion.Text = "";

            dtpFechaSolitud.Text = "";

            txtAreaCod.Text = "";
            txtNroAreaDesc.Text = "";


            txtFormaPagoCod.Text = "";
            txtFormaPagoDesc.Text = "";

            txtPlazoEntrega.Text = "";
            dtpFechaEntrega.Text = "";
            txtEntregaDesc.Text = "";
            txtTipoCambio.Text = "1.000";

            txtGiraCheque.Text = "";
            txtDestino1.Text = "";
            txtDestino2.Text = "";
            txtObservacion.Text = "";

            txtCentroCostroCod.Text = "";
            txtCentroCostoDesc.Text = "";

            txtCompLocalExt.Text = "";

            /*Vetana de observacion*/
            txtMemo.Text = "";
            txtTextoFormateado.Text = "";
            
        }
        private void TraerAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm;
            string[] datos;
            switch (tipoAyuda)
            {
                case enmAyuda.enmProveedor:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtProveedorCod.Text = datos[0];
                    txtProveedorDesc.Text = datos[1];
                    txtProveedorRuc.Text = datos[4];
                    txtProveedorTelf.Text = datos[3];
                    txtProveedorDirecc.Text = datos[2];
                    txtGiraCheque.Text = txtProveedorDesc.Text.Trim();
                    txtAtencion.Text = datos[5];
                    txtMonedaCod.Text = datos[6];
                    txtFormaPagoCod.Text = datos[7];
                    //FORMA PAGO AYUDA
                   string FormaPagoDesc =  DameDescripcion(txtFormaPagoCod.Text, "FORMAPAGO");
                   txtFormaPagoDesc.Text = FormaPagoDesc;
                    //MONEDA AYUDA 
                   string Moneda = DameDescripcion(txtMonedaCod.Text,"MONEDA");
                   txtMonedaDesc.Text = Moneda;
                    break;
                case enmAyuda.enmDirEntrega:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    //txtDirEntregaCod.Text = datos[0];
                    txtEntregaDesc.Text = datos[1];
                    break;

                case enmAyuda.enmMoneda:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtMonedaCod.Text = datos[0];
                    txtMonedaDesc.Text = datos[1];
                    break;
                case enmAyuda.enmComprasFormaPago:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtFormaPagoCod.Text = datos[0];
                    txtFormaPagoDesc.Text = datos[1];
                    break;
                case enmAyuda.enmCentroCosto:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtCentroCostroCod.Text = datos[0];
                    txtCentroCostoDesc.Text = datos[1];
                    break;
                case enmAyuda.enmusuariologistica:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtUsuarioLogisticaCod.Text = datos[0];
                    txtUsuarioLogisticaDes.Text = datos[1];
                    break;
                case enmAyuda.LugarDeEntra:
                      frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) { return; }
                    if (frm.Result.ToString() == "") { return; }
                    datos = frm.Result.ToString().Split('|');
                    txtEntregaCod.Text = datos[0];
                    txtEntregaDesc.Text = datos[1];
                    break;
                default:
                    break;
            }

        }
        
        /// <summary>
        /// Metodo para enfocar al siguiente control
        /// </summary>
        /// <param name="paramEvent">El parametro se usa en el evento KeyDown</param>
        private void FocusNextControl(KeyEventArgs paramEvent)
        {
            if (paramEvent.KeyValue == (char)Keys.Enter || paramEvent.KeyValue == (char)Keys.Down)
                SendKeys.Send("{TAB}");
            else if (paramEvent.KeyValue == (char)Keys.Up)
                SendKeys.Send("+{TAB}");
        }
        private void EditarControles()
        {
            txtProveedorCod.Enabled = true;
            txtNroSolicitud.Enabled = true;
            txtAtencion.Enabled = true;
            dtpFechaSolitud.Enabled = true;
            txtMonedaCod.Enabled = true;
            txtAreaCod.Enabled = true;
            dtpOCFecha.Enabled = true;
            txtFormaPagoCod.Enabled = true;
            txtPlazoEntrega.Enabled = true;
            dtpFechaEntrega.Enabled = true;
            txtEntregaDesc.Enabled = true;
            txtTipoCambio.Enabled = true;
            txtGiraCheque.Enabled = true;
            txtDestino1.Enabled = true;
            txtDestino2.Enabled = true;
            txtObservacion.Enabled = true;
            txtUsuarioLogisticaCod.Enabled = true;
            txtCentroCostroCod.Enabled = true;
            txtCompLocalExt.Enabled = true;
            txtEntregaCod.Enabled = true;                    
        }


        protected override void OnGuardar()
        {
            Cursor.Current = Cursors.WaitCursor;            
            DodcumentoOrdenCompra entidad = CargarEntidad();
            int flag = 0; string mensaje = "";
            try
            {

                if (Estado == FormEstate.New)
                {
                    CompraDocumentoLogic.Instance.InsertarOrdenCompra(entidad, out flag, out mensaje);
                }
                else if (Estado == FormEstate.Edit)
                {

                    CompraDocumentoLogic.Instance.ActualizarOrdenCompra(entidad, out flag, out mensaje);
                }

                if (flag == 1)
                {
                    Util.ShowMessage(mensaje, flag);
                    DeshabilitarTextos();
                    //Refrescar grila prcinpal
                    FrmParent.RefrescarGrilla();                    
                    Estado = FormEstate.Cancel;
                    MantenimientoCabecera();
                    
                }
                else
                {
                    Util.ShowAlert(mensaje);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar el documento, detalle . " + ex.Message);
            }
            Cursor.Current = Cursors.Default;

        }

        protected override void OnNuevo()
        {
            string nroOrden = "";
            EditarControles();
            LimpiarControles();
            IniciarControles();

            //OrdenTrabajoLogic.Instance.TraerNumeroOT(Logueo.CodigoEmpresa, out numeroOT);
            //string tipoOrden = FrmParent.tipoOrden;
            txtTipoOC.Text = FrmParent.tipoOrden;
            CompraDocumentoLogic.Instance.TraeCodigoNroOrden(Logueo.CodigoEmpresa,Logueo.Anio, txtTipoOC.Text.Trim(), out nroOrden);
            txtOCNro.Text = nroOrden;
            
            Estado = FormEstate.New;            
            MantenimientoCabecera();
            //Limpiar si hay detalle en el grilla 
            if (gridControlDetalle.Rows.Count > 0) {
                gridControlDetalle.Rows.Clear();
            }
        }

        protected override void OnEditar()
        {
            EditarControles();
            Estado = FormEstate.Edit;            
            MantenimientoCabecera();
            //Resaltar ayuda de la grilla
            Util.SetCellGridFocus(gridControlDetalle.CurrentRow, "CodigoArticulo");
            Util.ResaltarAyuda(gridControlDetalle.CurrentRow.Cells["CodigoArticulo"]);
            Util.ResaltarAyuda(txtEntregaCod);
        }

        protected override void OnEliminar()
        {
            try
            {
                bool respuesta = Util.ShowQuestion("¿Dese eliminar el documento?");
                if (respuesta == false) { return; }
                Cursor.Current = Cursors.WaitCursor;
                string tipoOrden = "", numeroOrdenCompra = "", mensaje = "";
                int flag = 0;
                
                tipoOrden = txtTipoOC.Text.Trim();
                //numeroOrdenCompra = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoOrdenCompra");
                numeroOrdenCompra =  txtOCNro.Text.Trim();
                CompraDocumentoLogic.Instance.EliminarOrdenCompra(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                    tipoOrden, numeroOrdenCompra, out flag, out mensaje);
                Util.ShowMessage(mensaje, flag);
                //si proceso es exitoso 
                if (flag == 1)
                {
                    FrmParent.Cargar();
                    this.Close();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al eliminar");
            }
        }

        protected override void OnCancelar()
        {            
            
            //Si mi valor de numero no esta en blanco , leer el documento
            if (Estado == FormEstate.New) {
                if (FrmParent.gridControl.Rows.Count > 0) {
                    FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[0];                    
                    CargarCabecera();
                    CargarDetalle();
                }
            }
            else if (Estado == FormEstate.Edit) {
                //txtOCNro.Text = FrmParent.numeroOrden;
                CargarCabecera();                
                CargarDetalle();
            }
            //if (FrmParent.numeroOrden != "")
            //{ 
            //    //Leer documento de cabecera y detalle
            //    txtOCNro.Text = FrmParent.numeroOrden;
            //    CargarCabecera();
            //    CargarDetalle();
                
            //}
            DeshabilitarTextos();
            Estado = FormEstate.List;
            Estado = FormEstate.Cancel;
            MantenimientoCabecera();    
            //Leer datos del registro seleccionada desde formulario en caso existe
            
        }

        protected override void OnPrimero()
        {
            int iIndice = 0;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarCabecera();
            CargarDetalle();
            Estado = FormEstate.View;
        }

        protected override void OnAnterior()
        {
            int iIndice = FrmParent.gridControl.MasterView.CurrentRow.Index - 1;
            if (iIndice < 0)
            {
                return;
            }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarCabecera();
            CargarDetalle();
            Estado = FormEstate.View;
        }

        protected override void OnSiguiente()
        {
            int iIndice = FrmParent.gridControl.MasterView.CurrentRow.Index + 1;
            if (iIndice > FrmParent.gridControl.MasterView.Rows.Count - 1)
            {
                return;
            }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarCabecera();
            CargarDetalle();
            Estado = FormEstate.View;
        }

        protected override void OnUltimo()
        {
            int iIndice = FrmParent.gridControl.MasterView.Rows.Count - 1;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarCabecera();
            CargarDetalle();
            Estado = FormEstate.View;
        }

        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string nombreReporte = "RptOrdenCompra.rpt";
                string numeroDocumento = "", tipoOrdenCompra = "";
                
                //tipoOrdenCompra = Util.GetCurrentCellText(gridControl.CurrentRow, "TipoOrdenCompra");
                tipoOrdenCompra = txtTipoOC.Text.Trim();
                //numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoOrdenCompra");
                numeroDocumento = txtOCNro.Text.Trim();
                string[] documentosSeleccionados = new string[1];
                documentosSeleccionados[0] = tipoOrdenCompra + numeroDocumento;
                string xml =  Util.ConvertiraXMLdinamico(documentosSeleccionados);
                DataTable dt = CompraDocumentoLogic.Instance.TraeReporteOrdenCompra(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                    "02", xml);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = nombreReporte;
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al traer vista preliminar");
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion
        #region "Evento de la cabecera"
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validar que este grabado la cabecera de la factura
            //if (ValidarCabeceraFacturaEstaGrabado() == false) return;

            //Flag de detalle Nuevo
            InsertaroActualizarDetalle = "N";
            // Capturo ultima columna visible de la grilla de detalle
            ultimacolumnavisibledelagrilla = ObtenerUltimaColumnaVisible();

            // Agrego Fila
            AgregarFila();

            OcultarBotones();
            //DesactivaTodoBootonesCabDetalle();
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            
            //metodos para los botones del detalle
            EstadoDetalle = DetailEstate.Edit;
            MantenimientoDetalle();
            
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GuardarDetalle();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //int indiceFila = this.gridControlDetalle.CurrentRow.Index;
            //this.gridControlDetalle.Rows.RemoveAt(indiceFila);
            try
            {
                CargarDetalle();                
                Estado = FormEstate.Cancel;
                MantenimientoCabecera();
                InsertaroActualizarDetalle = "N";
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al cancelar");
            }
            
        }
        void HabilitarEdicionDelDetalle()
        {
            foreach (GridViewRowInfo row in gridControlDetalle.Rows)
            {
                Util.SetValueCurrentCellText(row, "flag", "1");
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.gridControlDetalle.Rows.Count == 0) return;

            EstadoDetalle = DetailEstate.Edit;
            MantenimientoDetalle();
            InsertaroActualizarDetalle = "N";
            HabilitarEdicionDelDetalle();
        }

        private void gridControlDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridControlDetalle.Rows.Count > 0)
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    if (Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "CodigoArticulo") == true)
                    {
                        TraerAyudaDetalle(enmAyuda.enmBuscaArti);
                    }
                    else if (Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "Destino") == true)
                    {
                        TraerAyudaDetalle(enmAyuda.enmCentroCosto);
                    }
                    //else if (Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "Memo") == true)
                    //{
                    //    //Leer datos de la celda y asignar a la caja de texto Memo
                    //    VerObservacion();
                    //}
                    
                }
            }
        }
        private string GuardarContenidoMemo(string[] memo)
        {
            string textoFormateado = "";
            for (int i = 0; i < memo.Length; i++)
            {
                if (i < memo.Length - 1)
                {
                    textoFormateado += memo[i] + "§";
                }
                else if (i == memo.Length - 1)
                {
                    textoFormateado += memo[i];
                }
            }

            return textoFormateado;
        }

        private void btnGuardarObservacion_Click(object sender, EventArgs e)
        {
            this.gpxObservacion.SendToBack();
            this.gpxObservacion.Visible = false;
            Util.SetValueCurrentCellText(gridControlDetalle.CurrentRow, "Memo", GuardarContenidoMemo(txtMemo.Lines));            
        }
        private void btnCancelarObservacion_Click(object sender, EventArgs e)
        {
            this.gpxObservacion.SendToBack();
            this.gpxObservacion.Visible = false;
        }

        BaseGridEditor _gridEditor;
        private void gridControlDetalle_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (gridControlDetalle.Rows.Count == 0) return;
                if (e.Row == null) return;
                string flag = Util.convertiracadena(Util.GetCurrentCellText(e.Row, "Flag"));
                if (flag == "")
                {
                    e.Cancel = true; return;
                }

                if (flag == "0")
                {
                    if (
                         Util.IsCurrentColumn(e.Column, "ImporteBruto") == true
                        || Util.IsCurrentColumn(e.Column, "ImporteIgv") == true
                        || Util.IsCurrentColumn(e.Column, "Total") == true
                        //|| Util.IsCurrentColumn(e.Column, "CodigoArticulo") == true
                        || Util.IsCurrentColumn(e.Column, "Memo") == true
                        || Util.IsCurrentColumn(e.Column, "Destino") == true
                        )
                    {
                        e.Cancel = true;
                    }

                }
                if (flag == "1")
                {
                    if (Util.IsCurrentColumn(e.Column, "CodigoArticulo") == true || Util.IsCurrentColumn(e.Column, "Unidad") == true)
                    {
                        e.Cancel = true;
                    }
                }

                

                _gridEditor = this.gridControlDetalle.ActiveEditor as BaseGridEditor;

                if (_gridEditor != null)
                {
                    RadItem editorElement = _gridEditor.EditorElement as RadItem;
                    editorElement.KeyDown += new KeyEventHandler(gridControlDetalle_KeyDown);
                } 
            }
            catch (Exception ex) {
                Util.ShowError("Error al iniciar edicion");
            }
            
        }
        private void txtProveedorCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmProveedor);
            }
            else
            {
                FocusNextControl(e);
            }

        }

        private void txtMonedaCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmMoneda);
            }
            else
            {
                FocusNextControl(e);
            }
        }

        private void txtFormaPagoCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmComprasFormaPago);
            }
            else
            {
                FocusNextControl(e);
            }
        }

        private void txtCentroCostroCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmCentroCosto);
            }
            else
            {
                FocusNextControl(e);
            }
        }
        
        #endregion
        #region "Detalle del documento"

        private void DesactivarBotones()
        {
            btnAgregar.Enabled = false;
            btnCancelar.Enabled = false;
            //btnCancelarObservacion.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            
            
        }
        //El estado List bloque todo los operacion de manteniemiento de cabecera y detalle 
        private void ActivarBotones(string estadoProcesoDetalle)
        {
            // estadoProcesoDetalle -> Estado de proceso de la cabecera
            DesactivarBotones();
            //Presiono boton Agregar
            if (estadoProcesoDetalle == "N")
            {
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else if (estadoProcesoDetalle == "E")
            {
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else if (estadoProcesoDetalle == "V")
            {
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
        private void TraerAyudaDetalle(enmAyuda tipo)
        {

            frmBusqueda frm;
            string[] datos;
            try
            {
                switch (tipo)
                {
                    case enmAyuda.enmBuscaArti:
                        Cursor.Current = Cursors.WaitCursor;
                        frm = new frmBusqueda(tipo, txtTipoOC.Text.Trim());
                        frm.ShowDialog();
                        Cursor.Current = Cursors.Default;
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        Util.SetValueCurrentCellText(gridControlDetalle.CurrentRow, "CodigoArticulo", datos[0].Trim());
                        Util.SetValueCurrentCellText(gridControlDetalle.CurrentRow, "NombreArticulo", datos[1]);
                        Util.SetValueCurrentCellText(gridControlDetalle.CurrentRow, "Unidad", datos[2]);


                        // Llenear datos de ultimo precio si la orden es de compra
                       if(txtTipoOC.Text.Trim() == "C")
                        {
                            // Trae el ultimo precio luego de seleccioanr el producto
                            double precioSalida = 0, dsctSalida = 0;
                            CompraDocumentoLogic.Instance.TraeUltimoPrecio(Logueo.CodigoEmpresa, datos[0], out precioSalida, out dsctSalida);

                            Util.SetValueCurrentCellDbl(gridControlDetalle.CurrentRow, "Precio", precioSalida);
                            Util.SetValueCurrentCellDbl(gridControlDetalle.CurrentRow, "Descuento1", dsctSalida);
                        }

                        //this.gridControlDetalle.Focus();
                        gridControlDetalle.CurrentColumn = gridControlDetalle.Columns[7];
                        //Util.SetCellGridFocus(gridControlDetalle.CurrentRow, "NombreArticulo");
                        //SendKeys.Send("{TAB}");
                        break;
                    case enmAyuda.enmCentroCosto:
                         frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) { return; }
                        if (frm.Result.ToString() == "") { return; }
                        datos = frm.Result.ToString().Split('|');
                        Util.SetValueCurrentCellText(gridControlDetalle.CurrentRow, "Destino", datos[0]); //Codigo de Destino
                        Util.SetValueCurrentCellText(gridControlDetalle.CurrentRow, "DestinoDes", datos[1]); //descripcion de Destino
                         
                        //txtNombreDestino = DameDescripcionConta(txtDestino, "T1")
                        break;
                  
                    case enmAyuda.enmComprasObservacion:
                        VerObservacion();
                        break;
                    default:
                        break;
                }
                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al taer ayuda de  detalle");
            }
        }

        double dsc1 = 0, dsc2 = 0;
        private void CalcularTotales()
        {
            try
            {
                double subtotal = 0, precio = 0, cantidad = 0;
                double descuento = 0, igv = 0, baseigv= 0, importeigv = 0;
                double total = 0;
                

                GridViewRowInfo fila = gridControlDetalle.CurrentRow;
                cantidad = Util.GetCurrentCellDbl(fila, "Cantidad");
                precio = Util.GetCurrentCellDbl(fila, "Precio");
                descuento = Util.GetCurrentCellDbl(fila, "Descuento1"); //expresado numericamente como importe
                dsc1 = descuento;
                igv = Logueo.Igv;
                subtotal = Math.Round((precio * cantidad),2);
                baseigv = subtotal - descuento;
                importeigv = Math.Round(baseigv * (igv / 100),2);
                total = subtotal - descuento + importeigv;

                Util.SetValueCurrentCellDbl(fila, "ImporteBruto", subtotal);
                Util.SetValueCurrentCellDbl(fila, "BaseIgv", baseigv);
                Util.SetValueCurrentCellDbl(fila, "ImporteIgv", importeigv);
                Util.SetValueCurrentCellDbl(fila, "Total", total);

            }
            catch (Exception ex) {
                Util.ShowAlert("Error al calcular Totales Nuevo");
            }
        }
        /*
        private void CalcularTotales()
        {
            double importeBruto, ImporteSinDescuento, Neto, Descuento, ImpIGV;
            double cantidad = 0,precio = 0, descuento1 = 1, descuento2 = 0;
            double igv = 0, igvbase = 0;
            //Util.GetCurrentCellDbl(gridControlDetalle.
            GridViewRowInfo fila = this.gridControlDetalle.CurrentRow;
            cantidad = Util.GetCurrentCellDbl(fila, "Cantidad");
            precio = Util.GetCurrentCellDbl(fila, "Precio");

            descuento1 = Util.GetCurrentCellDbl(fila, "Descuento1");
            descuento2 = Util.GetCurrentCellDbl(fila, "Descuento2");
            //igv = Util.GetCurrentCellDbl(fila, "Igv");
            igv = 18; //este valor debe ir en la cabecera del documento expresadon en porcentaje

            //ImporteSinDescuento = Convert.ToDouble(
            try
            {
                ImporteSinDescuento = cantidad * precio;
                if (descuento1 > 0)
                {
                    dsc1 = (ImporteSinDescuento * descuento1 / 100);
                    ImporteSinDescuento = ImporteSinDescuento - (ImporteSinDescuento * (descuento1 / 100));
                }
                else {
                    dsc1 = 0;
                }

                if (descuento1 > 0 && descuento2 > 0)
                {
                    dsc2 = ImporteSinDescuento * (descuento2 / 100);
                    ImporteSinDescuento = ImporteSinDescuento - (ImporteSinDescuento * (descuento2 / 100));
                }
                else {
                    dsc2 = 0;
                }
                importeBruto = ImporteSinDescuento;
                //ImpIGV = (importeBruto * igv) / 100;
                ImpIGV = importeBruto * (igv/100); //Igv esta epresand den cimal para opera con el mento
                Neto = importeBruto + ImpIGV;
                Util.SetValueCurrentCellDbl(fila, "ImporteBruto", importeBruto);
                Util.SetValueCurrentCellDbl(fila, "ImporteIgv", ImpIGV);
                Util.SetValueCurrentCellDbl(fila, "Total", Neto);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al calcular  totales del detalle");
            }
        }
        */
        
        private void GuardarDetalle()
        {
            try
            {
                //limpio los registro insertados y luego genero un xml para insertar todo el detalle desde el inicio.
                double NroItemDetalle = 0;

                CompraDocumentoLogic.Instance.TraeNumeroItemDetalle(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, txtTipoOC.Text.Trim(), txtOCNro.Text.Trim(), out NroItemDetalle);

                DocumentoOrdenCompraDetalle detalle = new DocumentoOrdenCompraDetalle();
                detalle.Empresa = Logueo.CodigoEmpresa;
                detalle.Anio = Logueo.Anio;
                detalle.Mes = Logueo.Mes;
                detalle.TipoOrden = txtTipoOC.Text.Trim();
                
                detalle.CodigoOrden = txtOCNro.Text.Trim();
                detalle.Item = "0";// genero en el xml o en la base de datos;
                //formatear el valor de la caja de texto 
                string xml = "";
                string[] arreglo = new string[this.gridControlDetalle.Rows.Count];
                int x = 0;

                foreach(GridViewRowInfo fila in gridControlDetalle.Rows)
                {
                    arreglo[x] = Logueo.CodigoEmpresa + "|" +  // 01
                                Logueo.Anio + "|" +  // 2
                                Logueo.Mes + "|" + // 3
                                txtTipoOC.Text.Trim() + "|" + // 4
                                txtOCNro.Text.Trim() + "|" + // 5
                               //"0" + "|" + // 6  -- indice de fila
                               (x+1).ToString() + "|" + // 6  -- indice de fila
                                txtTipoOC.Text.Trim() + "|" + // 7
                                 Util.GetCurrentCellText(fila, "CodigoArticulo") + "|" + // 8
                                 Util.GetCurrentCellText(fila, "Cantidad") + "|" + // 9
                                 Util.GetCurrentCellText(fila, "Precio") + "|" + // 10
                                 Util.GetCurrentCellText(fila, "Descuento1") + "|" + //11
                                 Util.GetCurrentCellText(fila, "Descuento2") + "|" + //12
                                 Util.GetCurrentCellText(fila, "Igv") + "|" + // 13
                                 Util.GetCurrentCellText(fila, "ImporteBruto") + "|" + //14
                                 Util.GetCurrentCellText(fila, "ImporteIgv") + "|" + //15
                                 Util.GetCurrentCellText(fila, "Total") + "|" + // 16
                                 Util.GetCurrentCellText(fila, "Destino") + "|" + // Area // 17 CO04AREA -> destino
                                  Util.GetCurrentCellText(fila, "NombreArticulo") + "|" + // 18
                                   Util.GetCurrentCellText(fila, "Unidad") + "|" + // 19
                                   "0" + "|" + // Estado // //20
                                   //Util.GetCurrentCellText(fila, "CodigoArticulo") + "|" + // Codigo de proveedor
                                   txtProveedorCod.Text.Trim() + "|" + // Codigo de proveedor //21
                                   dtpOCFecha.Value.ToShortDateString() + "|" +//22
                                   Util.GetCurrentCellText(fila, "CantidadAtendida") + "|" + //cantidad atendida //23
                                   Util.GetCurrentCellText(fila, "ArchivoImg") + "|" + //24
                                   Util.GetCurrentCellDbl(fila, "Descuento1") + "|" + // 25
                                   Util.GetCurrentCellDbl(fila, "Descuento2") + "|" + // 26
                                   //dsc1 + "|"  + //25
                                   //dsc2 + "|" + //26
                                   Util.GetCurrentCellText(fila, "Memo");//27
                                            
                             x++;
                }
            
                xml = Util.ConvertiraXMLdinamico(arreglo);
                int flag = 0; string mensaje = "";
                CompraDocumentoLogic.Instance.InsertarDetalleOrdenCompra(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                    txtTipoOC.Text.Trim(), txtOCNro.Text.Trim(), xml, out flag, out mensaje);
                Util.ShowMessage(mensaje, flag);
                if (flag == 1)
                {
                    CargarDetalle();
                    
                    EstadoDetalle = DetailEstate.Cancel;
                    MantenimientoDetalle();
                    InsertaroActualizarDetalle = "";
                }

           
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle");
            }
        }
        private void CancelarDetalle()
        {
            try
            {
                CargarDetalle();
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cancelar detalle");
            }
        }
        private void EliminarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            int flag = 0; string mensaje = "";
            try
            {
                string flagFila = Util.GetCurrentCellText(gridControlDetalle.CurrentRow, "Flag");
                if (flagFila == "0")
                {
                    int indiceFila = gridControlDetalle.CurrentRow.Index;
                    gridControlDetalle.Rows.RemoveAt(indiceFila);
                }
                else { 

                    CompraDocumentoLogic.Instance.EliminarDetalleOrdenCompra(Logueo.CodigoEmpresa, Logueo.Anio,
                        Logueo.Mes, txtTipoOC.Text.Trim(), txtOCNro.Text.Trim(),
                        Util.GetCurrentCellText(this.gridControlDetalle.CurrentRow, "CodigoArticulo"), out flag, out mensaje);

                    Util.ShowMessage(mensaje, flag);
                    if (flag == 1)
                    {
                        CargarDetalle();
                    }

                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle");
            }
            Cursor.Current = Cursors.Default;
        }
        
        #endregion

        private void gridControlDetalle_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "Cantidad") == true
                    || Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "Precio") == true
                    || Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "Descuento1") == true
                    || Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "Descuento2") == true
                    || Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "Igv") == true)
                {
                    CalcularTotales();
                }

                if (_gridEditor != null)
                {
                    RadItem editorElement = _gridEditor.EditorElement as RadItem;
                    editorElement.KeyDown -= gridControlDetalle_KeyDown;
                }
                _gridEditor = null;

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al editar celda");
            }                                                                                                        
        }
        

        private void gridControlDetalle_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;
            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {

                //RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                //if (EsModoGuiaTransporte == true) { deshabilitarBotonProdDet(e.Column.Name, cellElement); return; }
                if (FrmParent.Estado == FormEstate.List)
                {
                    deshabilitarBotonProdDet(e.Column.Name, cellElement); return;
                }
                if (gridControlDetalle.Rows[e.RowIndex].Cells["flag"].Value == null)
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, false, false);
                else
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, false, true);


            }
        }

        #region "Evento del detalle documento"
        /// <summary>
        /// Evento para deshabilitar los botones incluido en la fila de la grilla
        /// </summary>
        /// <param name="nombre">nombre del cmapo de la grilla  a desactivar</param>
        /// <param name="CommandCell">elemento celda para usar en GridCellFormating</param>
        private void deshabilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell)
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
                    cellElement.CommandButton.Image = Properties.Resources.delete_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEditarDet":
                    cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnMemo":
                    cellElement.CommandButton.Image = Properties.Resources.memo_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Metodo para activar los botones de mantenimeinti incluido en las filas de la grilla
        /// </summary>
        /// <param name="nombre">Nombre del campo del boton en la grilla</param>
        /// <param name="CommandCell">elemento celda de la grilla para usar en el evento GridCellFormating</param>
        /// <param name="bGrabar">Asignar valor true o false para activar boton grabar</param>
        /// <param name="bCancelar">Asignar valor true o false para activar boton cancelar</param>
        /// <param name="bEliminar">Asignar valor true o false para activar boton eliminar</param>
        /// <param name="bEditar">Asignar valor true o false para activar boton editar</param>
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
                                            bool bCancelar, bool bEliminar, bool bEditar, bool bMemo)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelarDet":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminarDet":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.delete_enabled : Properties.Resources.delete_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditarDet":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edit_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;
                case "btnMemo":
                    cellElement.CommandButton.Image = bMemo ? Properties.Resources.memo_enabled : Properties.Resources.memo_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bMemo;
                    break;
                default:
                    break;
            }
        }
        #endregion
    
        private void gridControlDetalle_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                if(Util.IsCurrentColumn(this.gridControlDetalle.CurrentColumn, "btnEliminarDet"))                    
                {
                    EliminarDetalle();
                }
                if (Util.IsCurrentColumn(this.gridControlDetalle.CurrentColumn, "btnMemo"))
                {
                    VerObservacion();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle");
            }
        }

        #region "Eventos Mantenimiento"
        private void MantenimientoFormularioPadre()
        {
            OcultarBotones();
            btnAgregar.Visible = false;
            btnCancelar.Visible = false;
            btnEditar.Visible = false;
            btnGrabar.Visible = false;

            if (FrmParent.Estado == FormEstate.New)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            }
            else if (FrmParent.Estado == FormEstate.Edit)
            {
                //HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                //HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                //HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                //HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

                //btnAgregar.Visible = true;                
                //btnCancelar.Visible = true;
                //btnCancelar.Enabled = false;
                //btnEditar.Visible = true;
                //btnGrabar.Visible = true;
                //btnGrabar.Enabled = false;
            }
            else if (FrmParent.Estado == FormEstate.View)
            { 
                //ver botones de navegacion
                
                HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
                HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
                HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
                HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
            }
        }
        //Evento para los cambio de estado desde el formulario de detalle
        private void MantenimientoCabecera()
        {
            OcultarBotones();
            btnAgregar.Visible = false;
            btnCancelar.Visible = false;
            btnEditar.Visible = false;
            btnGrabar.Visible = false;

            if (Estado == FormEstate.New)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            }
            else if (Estado == FormEstate.Edit)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            }//  si presiono el boton cancelar
            else if(Estado == FormEstate.Cancel){
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);

                HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
                HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
                HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
                HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
                btnAgregar.Visible = true;

                btnCancelar.Visible = true;
                btnCancelar.Enabled = false;

                btnEditar.Visible = true;

                btnGrabar.Visible = true;
                btnGrabar.Enabled = false;
            }
        }
        //private string EstadoDetalle = "";
        private void MantenimientoDetalle()
        {

            OcultarBotones();
            btnAgregar.Visible = false;
            btnCancelar.Visible = false;
            btnEditar.Visible = false;
            btnGrabar.Visible = false;
            if (EstadoDetalle == DetailEstate.New)
            {
                btnGrabar.Visible = true; btnGrabar.Enabled = true;
                btnCancelar.Visible = true; btnCancelar.Enabled = true;                
                Util.ResaltarAyuda(gridControlDetalle, "CodigoArticulo");
                Util.ResaltarAyuda(gridControlDetalle, "Memo");
                OcultarBotones();
            }
            else if (EstadoDetalle == DetailEstate.Edit)
            {
                btnGrabar.Visible = true; btnGrabar.Enabled = true;
                btnCancelar.Visible = true; btnCancelar.Enabled = true;                
                Util.ResaltarAyuda(gridControlDetalle, "CodigoArticulo");
                Util.ResaltarAyuda(gridControlDetalle, "Memo");

                OcultarBotones();
            }
            else if (EstadoDetalle == DetailEstate.Cancel)
            {
                btnAgregar.Enabled = true;
                btnAgregar.Visible = true;
                btnEditar.Enabled = true;
                btnEditar.Visible = true;
                //Activiar botones de eliminar detalle
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);

                HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
                HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
                HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
                HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);
                
            }
            else {
                Util.ShowAlert("Estado no configurado");
            }
          
        }
        #endregion

        private void gridControlDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            if (gridControlDetalle.Rows.Count == 0) return;
            if (ultimacolumnavisibledelagrilla == 0) return;
            try
            {
                if (e.KeyValue == (char)Keys.Enter) {
                    SendKeys.Send("{TAB}");
                    if (InsertaroActualizarDetalle == "N") {
                        if (gridControlDetalle.CurrentColumn.IsVisible == true) {
                            if (gridControlDetalle.CurrentColumn.Index == ultimacolumnavisibledelagrilla) {
                                AgregarFila();
                                SendKeys.Send("+{TAB}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { 
                
            }
        }

        private void gridControlDetalle_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (gridControlDetalle.Rows.Count == 0) return;
                if (InsertaroActualizarDetalle == "N" || InsertaroActualizarDetalle == "M") 
                {
                    if (e.CurrentRow != null) {
                        Util.ResaltarAyuda(this.gridControlDetalle.CurrentRow.Cells["CodigoArticulo"]);
                    }
                }
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al cambiar fila");
            }
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Tab || 
                   e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down) {
                txtMemo.Focus();
            }            
        }

        private void txtMemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Tab ||
                   e.KeyValue == (char)Keys.Up || e.KeyValue == (char)Keys.Down)
            {
                txtMemo.Focus();
            }        
        }

        

        

        private void txtCentroCostroCod_TextChanged(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, txtCentroCostroCod.Text.Trim(), "CENTROCOSTO", out descripcion);
            
            txtCentroCostoDesc.Text = descripcion;
        }

        private void gridControlDetalle_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            try
            {
                Util.SetCellInitEdit(gridControlDetalle.CurrentRow, 
                    gridControlDetalle.CurrentColumn.Name);
            }
            catch (Exception ex) { 

            }
            
        }
        //VERDADERO
        
        bool tbSubscribed = false;
        private void gridControlDetalle_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            RadTextBoxEditor tbEditor = this.gridControlDetalle.ActiveEditor as RadTextBoxEditor;
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
            if (Util.IsCurrentColumn(gridControlDetalle.CurrentColumn, "CodigoArticulo"))
            {
                if (e.KeyChar != (char)Keys.F1)
                {
                    e.Handled = true;
                }
            }
        }

        private void dtpOCFecha_Leave(object sender, EventArgs e)
        {
            double TipoCambo;
            //Validar si la fecha es valida
            if (dtpOCFecha.Text != "")
            {
                Compra_Traer_TipoCambioLogic.Instance.TipoCambioTraer(dtpOCFecha.Text, out TipoCambo);
                txtTipoCambio.Text = TipoCambo.ToString();
            }
            else
            {
                Util.ShowAlert("Fecha No Valida");
                dtpOCFecha.Focus();
            }
        }

        private void radCommandBar1_Click(object sender, EventArgs e)
        {

        }

        private void txtMonedaCod_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, txtMonedaCod.Text.Trim(), "MONEDA", out descripcion);
            txtMonedaDesc.Text = descripcion;
        
        }

        private void txtFormaPagoCod_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, txtFormaPagoCod.Text.Trim(), "FORMAPAGO", out descripcion);
            txtFormaPagoDesc.Text = descripcion;
        }

        private void txtUsuarioLogisticaCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmusuariologistica);
            }
            else
            {
                FocusNextControl(e);
            }
        }

        private void txtUsuarioLogisticaCod_Leave(object sender, EventArgs e)
        {
            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa, txtUsuarioLogisticaCod.Text.Trim(), "USULOGI", out descripcion);
            txtUsuarioLogisticaDes.Text = descripcion;
        }

      

        private void txtEntregaDesc_KeyDown_1(object sender, KeyEventArgs e)
        {
           
        }

        private void txtMemo_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel16_Click(object sender, EventArgs e)
        {

        }

        private void txtEntregaCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.LugarDeEntra);
            }
        }


    }

    class Grilla {
        class Columnas {
            bool EditableSi = true, EditableNo = false;
            bool LecturaSi = true, LecturaNo = false;
            bool VisibleSi = true, VisibleNo = false;
        }
    }
}
