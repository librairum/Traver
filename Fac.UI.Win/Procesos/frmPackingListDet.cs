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
using System.IO;
using System.Diagnostics;

namespace Fac.UI.Win
{
    public partial class frmPackingListDet : frmBaseReg
    {
        internal string numeroDocumento = "";
        private string InsertaroActualizarDetalle = ""; // N=Nuevo,M=Modificar,""=Ninguna Operacion
        int ultimacolumnavisibledelagrilla = 0;
        bool esInsercion = false, flagLima = false;

        private static frmPackingListDet _aForm;
        PackingListLogic datos = PackingListLogic.Instance;
        private frmPackingList FrmParent { get; set; }
        public static frmPackingListDet Instance(frmPackingList padre)
        {
            if (_aForm != null) return new frmPackingListDet(padre);
            _aForm = new frmPackingListDet(padre);
            return _aForm;
        }
        public frmPackingListDet(frmPackingList padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Util.ConfigGridToEnterNavigation(gridControl);
            
        }
      
        private void frmPackingListDet_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //AgregarReporteCertificado();
            RenombrarInformacionlBoton(BaseRegBotones.cbbReporteFactura, "Ver reporte factura"); // Generar reporte factura
            RenombrarInformacionlBoton(BaseRegBotones.cbbEnviarCorreo, "Enviar correo"); // Enviar correo

            RenombrarInformacionlBoton(BaseRegBotones.cbbVistaPrevia, "Ver reporte packing"); // Generar reporte certificado origen
            RenombrarInformacionlBoton(BaseRegBotones.cbbReporteCertificado, "Ver reporte certificado origen"); // Generar reporte packing

            CrearColumnasDetalle();


            HabilitaBotonesCabeceraPorEstadoFormulario();

            DesactivTodoBotonesCabDetalle();

            if (Estado == FormEstate.New)
            {
                string nuevoNumeroDocumento = "";
                string mensaje = ""; int flag = 0;
                datos.TraePackingListNumero(Logueo.CodigoEmpresa, out nuevoNumeroDocumento, out mensaje, out flag);
                txtNumero.Text = nuevoNumeroDocumento;
                txtNumero.Enabled = false;
                dtpFecha.Value = DateTime.Now;
            }
            else if (Estado == FormEstate.Edit)
            {
                txtNumero.Enabled = false;
                CargarCabecera();
                CargarDetalle();
                Editar();
            }
            else if (Estado == FormEstate.View)
            {
                CargarCabecera();
                CargarDetalle();                
            }
            Cursor.Current = Cursors.Default;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InsertaroActualizarDetalle = "N";
            ultimacolumnavisibledelagrilla = ObtenerUltimaColumnaVisible();

            AgregarRegistroDetalle();

            DesactivTodoBotonesCabDetalle();
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }
       

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistroDetalle();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GuardarRegistroDetalle();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarRegistroDetalle();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (gridControl.Rows.Count == 0) return;
            try
            {

                DesactivTodoBotonesCabDetalle();
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;

                esInsercion = true;
                InsercionDinamica();
            }
            catch (System.Data.SqlClient.SqlException exSQL)
            {
                Util.ShowError("Error al insertar fila : " + exSQL.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al insertar fila : " + ex.Message);
            }
        }
        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmFactCab_Cliente);
            }
            if (e.KeyValue == (char)Keys.Enter)
            {
                txtcontenedor.Focus();
            }
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.Row == null) return;
                
                string str_flag = Util.GetCurrentCellText(gridControl.CurrentRow, "flag");
                bool flagPerfilLima =  PermitirOperacionLima();
                if (str_flag == ""){ e.Cancel = true; return; }

                //asignar un comportanmiento especial de edicion si tiene un flag de perfil Lima
                if (flagPerfilLima == true)
                {
                    //si es perfil facturacion Lima, si una columna no pertenece a unidad, precio o subtotal 
                    //no puede ser editado.
                    if (Util.IsCurrentColumn(gridControl.CurrentColumn, "VentaUnidaMedida") == false &&
                        Util.IsCurrentColumn(gridControl.CurrentColumn, "VentaPrecio") == false)
                    {
                        e.Cancel = true;
                    }
                }
                                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al editar celda: " + ex.Message);
            }
        }
        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {

                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);

                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                    Util.habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, false);
                else
                    Util.habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, false);

            }
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (Util.IsCurrentColumn(gridControl.CurrentColumn, "btnEliminarDet"))
            {
                EliminarRegistroDetalle();
            }
        }
        private void gridControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (gridControl.Rows.Count == 0) return;
            // Si no hay ultiam columna visisble sale 
            if (ultimacolumnavisibledelagrilla == 0) return;
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (InsertaroActualizarDetalle == "N")
                {
                    if (gridControl.CurrentColumn.IsVisible == true)
                    {
                        if (gridControl.CurrentColumn.Index == ultimacolumnavisibledelagrilla)
                        {
                            //agregar nueva fila
                            AgregarRegistroDetalle();
                            //Durante este evento aparte de agregar la fila salta la primera celda de la siguiente
                            // fila agregado, por ello , agrego este código para ubicar mi foco en la column del producto.
                            SendKeys.Send("+{TAB}");
                        }
                    }
                }
            }
        }
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (gridControl.Rows.Count == 0) return;
                if (InsertaroActualizarDetalle == "N" || InsertaroActualizarDetalle == "M")
                {
                    if (e.CurrentRow != null)
                    {
                        Util.ResaltarAyuda(gridControl, e.CurrentRow.Index, "ProductoEmpresa");
                        Util.ResaltarAyuda(gridControl, e.CurrentRow.Index, "VentaUnidaMedida");
                    }
                    //Si  tenemos solo una fila omitir el metodo para retirar 
                    // el resaltado de ayuda de la fila anterio
                    if (gridControl.Rows.Count == 1) return;
                    if (e.OldRow != null)
                    {
                        Util.ResetearAyuda(gridControl, e.OldRow.Index, "ProductoEmpresa");
                        Util.ResetearAyuda(gridControl, e.OldRow.Index, "VentaUnidaMedida");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cambiar de fila : " + ex.Message);
            }
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {

            string flag = Util.GetCurrentCellText(this.gridControl.CurrentRow, "flag");
            if (flag == "") return;            
            if (e.KeyValue == (char)Keys.F1)
            {
                if (PermitirOperacionLima() == false)
                {
                    //Activa la ayuda para los perfiles de Huaral
                    if (Util.IsCurrentColumn(gridControl.CurrentColumn, "ProductoEmpresa"))
                    {
                        TraerAyuda(enmAyuda.enmFactDet_ArtxTipo);
                    }
                }
                else if (PermitirOperacionLima() == true)
                {
                    //Activa la ayuda para los perfiles de Lima
                    if (Util.IsCurrentColumn(gridControl.CurrentColumn, "VentaUnidaMedida"))
                    {
                        TraerAyuda(enmAyuda.enmUniMed);
                    }
                }
                
            }

        }
        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (this.gridControl.Rows.Count == 0) return;
            try
            {
                if (PermitirOperacionLima() == true)
                {
                    //calculo de subtotal
                    if (Util.IsCurrentColumn(e.Column, "VentaUnidaMedida") ||
                        Util.IsCurrentColumn(e.Column, "VentaPrecio") ||
                        Util.IsCurrentColumn(e.Column, "VentaSubTotal"))
                    {
                        string unidadMedida, subTotalventaTexto ;
                        double precioVenta = 0, subtotalVenta = 0, area = 0, totalPiezas = 0;

                        unidadMedida = Util.GetCurrentCellText(e.Row, "VentaUnidaMedida");                        
                        precioVenta = Util.GetCurrentCellDbl(e.Row, "VentaPrecio");
                        area = Util.GetCurrentCellDbl(e.Row, "Area");
                        totalPiezas = Util.GetCurrentCellDbl(e.Row, "Cantidad");

                        if (unidadMedida.ToUpper() == "MT2")
                        {
                            subtotalVenta = area * precioVenta;
                        }
                        else
                        {
                            subtotalVenta =  totalPiezas* precioVenta;
                        }
                        subTotalventaTexto = Util.convertiracadena(subtotalVenta);
                        Util.SetValueCurrentCellDbl(gridControl.CurrentRow, "VentaSubTotal", subtotalVenta);
                    }

                }
                else
                {
                    //calculo de MT2
                    if (Util.IsCurrentColumn(e.Column, "PzasxCaja") ||
                        Util.IsCurrentColumn(e.Column, "Cajas"))
                    {
                        double pzasxCaja = 0, cajas = 0, totalPiezas = 0;
                        string totalPiezasTexto ;
                        pzasxCaja = Util.GetCurrentCellDbl(e.Row, "PzasxCaja");
                        cajas = Util.GetCurrentCellDbl(e.Row, "Cajas");
                        totalPiezas = pzasxCaja * cajas;
                        totalPiezasTexto = Util.convertiracadena(totalPiezas);
                        Util.SetValueCurrentCellText(gridControl.CurrentRow, "Cantidad", totalPiezasTexto);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro al editar valor de celda: " + ex.Message);
            }


        }

        private bool PermitirOperacionLima()
        {
            string codigoPerfil = Logueo.codigoPerfil;
            if (codigoPerfil == "01") // 16 - facturacion lima
            {
                return true;
            }
            return false;
        }
     

  

        private void TraerAyuda(enmAyuda tipoAyuda)
        {
            
            frmBusqueda frm;
            string[] datos;
            int flag = 0; string mensaje = "";
            switch (tipoAyuda)
            {
                case enmAyuda.enmFactCab_Cliente:
                    frm = new frmBusqueda(tipoAyuda, "01");
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodCliente.Text = datos[0];
                    txtDescCliente.Text = datos[1];
                    txtDireccion.Text = datos[2];                   
                    break;                
                case enmAyuda.enmFactDet_ArtxTipo:
                    frm = new frmBusqueda(enmAyuda.enmFactDet_ArtxTipo, "01");
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "ProductoEmpresa", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "ProductoDescripcion", datos[1]);
                    Util.SetCellInitEdit(gridControl.CurrentRow, "ProductoDescripcion");
                    break;                    
                case enmAyuda.enmUniMed:
                    frm = new frmBusqueda(enmAyuda.enmUniMed);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "VentaUnidaMedida", datos[0]);                    
                    break;
                default: break;
            }
        }
        private string TraerNuevoNumeroItem()
        {
            int nuevoItem = 0;
            string itemTexto = "";
            try
            {
                int ultimoItem = 0;
                int mayorItem = 0;
                foreach (GridViewRowInfo row in gridControl.Rows)
                {
                    ultimoItem = Util.GetCurrentCellInt(row, "Item");

                    if (ultimoItem > mayorItem)
                    {
                        mayorItem = ultimoItem;
                    }
                }
                itemTexto = (mayorItem+1).ToString();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer nuevo numero de item :" + ex.Message);
            }
            return itemTexto;
        }
        private void AgregarRegistroDetalle()
        {
            
            try
            {
                if (gridControl.Rows.Count > 0)
                {
                    if (ValidarDetalle(gridControl.CurrentRow) == false) return;
                }                                
                
                this.gridControl.Rows.AddNew();
                
                Util.SetValueCurrentCellText(gridControl.CurrentRow, "flag", "0");
                Util.SetCellInitEdit(gridControl, "Proforma");

                string numeroDocumento = "", nuevoItemDetalle = "";
                numeroDocumento = txtNumero.Text.Trim();                
                nuevoItemDetalle = TraerNuevoNumeroItem();

                Util.SetValueCurrentCellText(gridControl.CurrentRow, "Item", nuevoItemDetalle);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar registro detalle: " + ex.Message);
            }
            
        }
        private bool ValidarDetalle(GridViewRowInfo fila)
        {
            if (gridControl.Rows.Count == 0) return false;
            if (Util.GetCurrentCellText(fila,"Proforma") == ""
                || Util.GetCurrentCellText(fila, "ProductoDescripcion") == "")
            {
                Util.ShowAlert("Debe ingresar datos en el registro vacio");
                Util.SetCellInitEdit(fila, "Proforma");
                return false;
            }
            return true;
        }
        private void EliminarRegistroDetalle()
        {
            try
            {
                if (gridControl.Rows.Count == 0) return;
                PackingList packing = new PackingList();
                packing.Empresa = Logueo.CodigoEmpresa;
                packing.NumeroDocumento = txtNumero.Text.Trim();
                packing.Item = Util.GetCurrentCellInt(gridControl.CurrentRow, "Item");
                string flagEstadoFila = Util.GetCurrentCellText(gridControl.CurrentRow, "flag");
                

                int flag = 0; string mensaje = "";

                if (flagEstadoFila == "0") //  registro sin guardar
                {
                    this.gridControl.Rows.RemoveAt(this.gridControl.CurrentRow.Index);
                }
                else { //  registro guardado en base de datos
                    bool respuesta = Util.ShowQuestion("¿Eliminar el registro?");
                    if (respuesta == true)
                    {
                        datos.EliminarPackingListDetManual(packing, out flag, out mensaje);
                        Util.ShowMessage(mensaje, flag);
                        if (flag == 1)
                        {
                            CargarDetalle();
                        }
                    }
                }
                
            }
            catch (System.Data.SqlClient.SqlException exSQL)
            {
                Util.ShowError("Error al eliminar registro detalle: " + exSQL.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar registro detalle: " + ex.Message);
            }
        }
        private void EditarRegistroDetalle()
        {

            PackingList packing = new PackingList();
            if (gridControl.Rows.Count == 0) return;
            
            InsertaroActualizarDetalle = "M"; // flag de modifcar en la grilla para activar el foco de ayuda
            packing.Item = Util.GetCurrentCellInt(gridControl.CurrentRow, "Item");
            DesactivTodoBotonesCabDetalle();            
            ActivarBotonesDetallePorEstado(true);
            //Habilitar todo los campos de canajsa y cantidad
            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                Util.SetValueCurrentCellText(row, "flag", "1");
            }
            gridControl.Focus();
            Util.enfocarFila(gridControl, "Item", packing.Item.ToString());
            Util.ResaltarAyuda(gridControl, gridControl.CurrentRow.Index, "VentaUnidaMedida");
            
        }
        private void EditarRegistroDetallePrecio()
        {
            PackingList packing = new PackingList();
            if (gridControl.Rows.Count == 0) return;
            InsertaroActualizarDetalle = "M";// flag de modifcar en la grilla para activar el foco de ayuda
            packing.Item = Util.GetCurrentCellInt(gridControl.CurrentRow, "Item");
            DesactivTodoBotonesCabDetalle();
            ActivarBotonesDetallePorEstado(true);

            //Habilitar todo los campos de canajsa y cantidad
            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                Util.SetValueCurrentCellText(row, "flag", "1");
            }

            gridControl.Focus();
            Util.enfocarFila(gridControl, "Item", packing.Item.ToString());
            Util.ResaltarAyuda(gridControl, gridControl.CurrentRow.Index, "VentaUnidaMedida");
        }
        
                         
        private void GuardarRegistroDetalle()
        {
            try
            {
                string numeroDocumento = "", xml = "", mensaje= "";
                int flag = 0;
                PackingList packing = new PackingList();
                string[] registros = new string[gridControl.Rows.Count];
                int x = 0;
                foreach (GridViewRowInfo row in gridControl.Rows)
                {
                    registros[x] =                        
                        
                    Util.GetCurrentCellInt(row, "Item") + "|" +
                    Util.GetCurrentCellText(row, "Proforma") + "|" +
                    Util.GetCurrentCellText(row, "ProductoEmpresa") + "|" +
                    Util.GetCurrentCellText(row, "ProductoDescripcion") + "|" +
                    Util.GetCurrentCellText(row, "PzasxCaja") + "|" +
                    Util.GetCurrentCellText(row, "Cajas") + "|" +
                    Util.GetCurrentCellText(row, "Cantidad") + "|" +
                    Util.GetCurrentCellText(row, "Area") + "|" +
                    Util.GetCurrentCellText(row, "Peso") + "|" +
                    Util.GetCurrentCellText(row, "Observaciones") +"|"+
                    Util.GetCurrentCellText(row, "VentaUnidaMedida") + "|" +
                    Util.GetCurrentCellText(row, "VentaPrecio") + "|" +
                    Util.GetCurrentCellText(row, "VentaSubTotal") + "|" +
                    (x+1).ToString();
                    x++;
                }


                xml = Util.ConvertiraXMLdinamico(registros);
                //string xmlformato 
                packing.Empresa = Logueo.CodigoEmpresa;
                packing.NumeroDocumento = txtNumero.Text.Trim();
                datos.InsertarPackingListDetManual(packing, xml, out flag, out mensaje);
                
                Util.ShowMessage(mensaje, flag);
                if (flag == 1)
                {
                    CancelarRegistroDetalle();
                    Util.enfocarFila(FrmParent.gridControl, "NumeroDocumento", packing.NumeroDocumento);
                }
            }
            catch (System.Data.SqlClient.SqlException exSQL)
            {
                Util.ShowError("Error al guardar detalle de packing list:" + exSQL.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle:" + ex.Message);
            }
        }
        private void CancelarRegistroDetalle()
        {            
            DesactivTodoBotonesCabDetalle();
            ActivarBotonesDetallePorEstado(false);
            
            CargarDetalle();
            //desactivar el flag para no ver el resaltae de ayuda en modo vista  de la grilla
            InsertaroActualizarDetalle = "";
            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                Util.ResetearAyuda(gridControl, row.Index, "ProductoEmpresa");
                Util.ResetearAyuda(gridControl, row.Index, "VentaUnidaMedida");
            }
            
        }
        private void ActivarBotonesDetallePorEstado(bool activarGuardarCancelar)
        {
            // Si las operacion no es en lima
            if (PermitirOperacionLima() == false)
            {

                if (activarGuardarCancelar == false)
                {
                    btnAgregar.Enabled = true;                    
                    btnEditar.Enabled = true;
                    btnInsertar.Enabled = true;
                }
                else
                {
                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
            } 
            else {

                if (activarGuardarCancelar == false)
                {
                    btnEditarPrecio.Enabled = true;
                }
                else
                {
                    btnEditarPrecio.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
                
            }


        }        
    


        private void CargarCabecera()
        {

            try
            {
                txtNumero.Text = numeroDocumento.Trim();
                PackingList registro = PackingListLogic.Instance.TraePackingListRegistro(Logueo.CodigoEmpresa,
                txtNumero.Text.Trim(), Logueo.Anio, Logueo.Mes);
                //txtNumero.Text = registro.NumeroDocumento.Trim();
                txtCodCliente.Text = registro.ClienteCodigo.Trim();
                txtDescCliente.Text = registro.ClienteDesc.Trim();
                txtcontenedor.Text = registro.ContainerNro;
                txtprecinto.Text = registro.PrecintoNros;
                dtpFecha.Text = registro.FechaTexto;
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                Util.ShowError("Error en sql: " + exSql.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar cabecera: " + ex.Message);
            }
        }
        private void CrearColumnasDetalle()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            bool visibleSi = true, visibleNo = false, numericoSi = true, numericoNo = false;
            bool sololecturaNo = false, sololecturaSi = true, permiteEdicionSi = true, permiteEdicionNo = false;
            bool ocultarColumnas = PermitirOperacionLima();
           
            CreateGridColumn(Grid, "Empresa", "Empresa", 0, "", 90, false, true, false);
            CreateGridColumn(Grid, "NumeroDocumento", "NumeroDocumento", 0, "", 90, false, true, false);

            CreateGridColumn(Grid, "Item", "Item", 0, "", 40, sololecturaSi, permiteEdicionNo, visibleSi, numericoNo);
            CreateGridColumn(Grid, "Proforma", "Proforma", 0, "", 80, sololecturaNo, permiteEdicionSi, visibleSi, numericoNo);            
            CreateGridColumn(Grid, "Codigo", "ProductoEmpresa", 0, "", 120, sololecturaSi, permiteEdicionNo, visibleSi, numericoNo);
            CreateGridColumn(Grid, "ProductoDescripcion", "ProductoDescripcion", 0, "", 400, sololecturaNo, permiteEdicionSi, visibleSi, numericoNo);
            CreateGridColumn(Grid, "PzasxCaja", "PzasxCaja", 0, "", 75, sololecturaNo, permiteEdicionSi, visibleSi, numericoSi, "right");

            CreateGridColumn(Grid, "Cajas", "Cajas", 0, "", 60, sololecturaNo, permiteEdicionSi, visibleSi, numericoSi, "right");
            CreateGridColumn(Grid, "TotalPiezas", "Cantidad", 0, "", 75, sololecturaNo, permiteEdicionSi, visibleSi, numericoSi, "right"); // cantidad
            CreateGridColumn(Grid, "MT2", "Area", 0, "", 75, sololecturaNo, permiteEdicionSi, visibleSi, numericoSi, "right");
            CreateGridColumn(Grid, "Peso", "Peso", 0, "", 75, sololecturaNo, permiteEdicionSi, visibleSi, numericoSi, "right");
            
            CreateGridColumn(Grid, "Observaciones", "Observaciones", 0, "", 90, sololecturaNo, permiteEdicionSi, visibleSi, numericoNo);                        
            
            CreateGridColumn(Grid, "Unidad", "VentaUnidaMedida", 0, "", 90, sololecturaSi, permiteEdicionNo, ocultarColumnas, numericoNo);
            CreateGridColumn(Grid, "Precio", "VentaPrecio", 0, "", 90, sololecturaNo, permiteEdicionSi, ocultarColumnas, numericoSi);
            CreateGridColumn(Grid, "SubTotal", "VentaSubTotal", 0, "", 90, sololecturaNo, permiteEdicionSi, ocultarColumnas, numericoSi);            
            
            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, sololecturaNo, permiteEdicionSi, visibleNo, numericoNo);
            Util.AddButtonsToGrid(Grid, BaseRegBotonesDetalle.btnEliminarDet);
            string[] columnasSumatoria;
            
       
            if (ocultarColumnas == false)
            {
                columnasSumatoria = new string[4] { "Cajas", "Cantidad", "Area", "Peso" };
            }
            else {
                columnasSumatoria = new string[5] { "Cajas", "Cantidad", "Area", "Peso", "VentaSubTotal" };
            }
            
            Util.AddGridSummarySum(Grid, columnasSumatoria);
        }
        private void CargarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<PackingList> lista = PackingListLogic.Instance.TraePackingDetalleFacturacion(Logueo.CodigoEmpresa, txtNumero.Text.Trim());
                gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar detalle: " + ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }
        #region "Correo outlook"
        //Retorno la ruta del archivo a exportar
        private string GenerarArchivoExportacion()
        {
            string rutaDelArchivo = "";
            try
            {

                StringBuilder sb = new StringBuilder();
                //en caso es desde el detalle tomar el numero documento desde la caja de texto

                #region "Cabecera de documento"
                string numeroDocumento = txtNumero.Text.Trim();
                PackingList packingCabecera = PackingListLogic.Instance.TraePackingListRegistro(Logueo.CodigoEmpresa,
                                                                               numeroDocumento, Logueo.Anio, Logueo.Mes);

                string flag = "C";
                sb.AppendLine(flag +
                    "|" + packingCabecera.Empresa +
                    "|" + packingCabecera.NumeroDocumento +
                    "|" + packingCabecera.anio +
                    "|" + packingCabecera.mes +
                    "|" + packingCabecera.FechaTexto +
                    "|" + packingCabecera.ClienteCodigo +
                    "|" + packingCabecera.ContainerNro +
                    "|" + packingCabecera.PrecintoNros);

                #endregion

                #region "Detalle"
                string flagDetalle = "D";
                List<PackingList> detalles = PackingListLogic.Instance.TraePackingDetalleFacturacion(Logueo.CodigoEmpresa, numeroDocumento);
                foreach (PackingList registro in detalles)
                {
                    sb.AppendLine(flagDetalle + // 0
                        "|" + registro.Empresa + //1
                        "|" + registro.NumeroDocumento + //2
                        "|" + registro.Item + //3
                        "|" + registro.Secuencia + //4
                        "|" + registro.ProductoCliente + // 5
                        "|" + registro.ProductoEmpresa + // 6
                        "|" + registro.ProductoDescripcion + // 7
                        "|" + registro.Largo + // 8
                        "|" + registro.Ancho + // 9
                        "|" + registro.Alto + // 10
                        "|" + registro.LargoTexto + //11
                        "|" + registro.AnchoTexto + //12
                        "|" + registro.AltoTexto + // 13
                        "|" + registro.PzasxCaja + // 14
                        "|" + registro.Cantidad + // 15
                        "|" + registro.Cajas + // 16
                        "|" + registro.Area + //17
                        "|" + registro.Peso + // 18
                        "|" + registro.Proforma + // 19
                        "|" + registro.PedidoNumero + // 20
                        "|" + registro.PedidoItem + // 21
                        "|" + registro.Area + // 22
                        "|" + registro.Observaciones + //23
                        "|" + registro.VentaUnidaMedida + // 24
                        "|" + registro.VentaPrecio + // 25
                        "|" + registro.VentaSubTotal+ // 26
                        "|" + Logueo.Anio + //27
                        "|" + Logueo.Mes); //28
                }
                //PackingList packingDetalle = PackingListLogic.Instance.tra
                #endregion


                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.Title = "Guardar Archivo texto";
                sfd.FileName = "ARCHIVO";
                sfd.RestoreDirectory = true;
                string ruta = string.Empty;

                ruta = Path.Combine(Application.StartupPath, sfd.FileName + ".txt");
                //limpio la informacion del contenido del archivo
                System.IO.File.WriteAllText(ruta, string.Empty);
                //asigno el valor al archivo de texto.
                System.IO.File.WriteAllText(ruta, sb.ToString());

                rutaDelArchivo = ruta;
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Util.ShowError("Error en exportacion de datos : " + sqlEx.Message);
            }
            catch (IOException ioEx)
            {
                Util.ShowError("Error al guardar archivo: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro en exportacion de datos :" + ex.Message);
            }
            return rutaDelArchivo;
        }

        private void EnviarCorreoPorOutlook()
        {
            try
            {
                AbrirVentanaDeEnviarNuevoCorreoOutlook();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al enviar correo:" + ex.Message);
            }
        }

        private void AbrirVentanaDeEnviarNuevoCorreoOutlook()
        {
            Cursor.Current = Cursors.WaitCursor;
            Microsoft.Office.Interop.Outlook.Application Correo = new Microsoft.Office.Interop.Outlook.Application();

            Microsoft.Office.Interop.Outlook.NameSpace Login = Correo.GetNamespace("mapi");
            Microsoft.Office.Interop.Outlook._MailItem Mensaje = Correo.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);


            Mensaje.Subject = "";
            Mensaje.HTMLBody = "";
            
            
            
            //Envio de doucumento packing list por correo
            if (PermitirOperacionLima() == false)
            {

                Mensaje.Subject = "Exportacion packing " + txtNumero.Text.Trim();

                string codigoTablaHtml = "", rutaArchivo = "";
                
                PackingListLogic.Instance.TraeTablaHtml(out codigoTablaHtml);
                Mensaje.HTMLBody = codigoTablaHtml;

                rutaArchivo = GenerarArchivoExportacion();
                if (rutaArchivo == "") { Util.ShowAlert("Fallo al generar el archivo de exportacion"); return; }

                if (File.Exists(rutaArchivo))
                {
                    Mensaje.Attachments.Add(rutaArchivo, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, rutaArchivo);
                }
                
            }
            else // Envio de documento packing, factura y certificado
            {
                Mensaje.Subject = "Envio sunat " + txtNumero.Text.Trim();

                string packing = "", certificado = "", factura = "";
                string[] documentos;

                documentos = GenerarEnvioSunat().Split('|');
                
                if(documentos.Length < 3) { Util.ShowAlert("Fallo al generar documento para enviar "); return;}
                
                certificado = documentos[0]; factura = documentos[1]; packing = documentos[2];

                Mensaje.Attachments.Add(certificado, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, certificado);
                Mensaje.Attachments.Add(factura, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, factura);
                Mensaje.Attachments.Add(packing, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, packing);
                
            }

            Mensaje.Display(true);      // Se muestra el correo
            Login.Logoff();             // Cerrar sesion OutLook

            Mensaje = null;
            Login = null;
            Correo = null;
            Cursor.Current = Cursors.Default;
        }
        
        #endregion
        #region "Envio de Packing - certificado de origen - factura"
        private string GenerarEnvioSunat()
        {
            string rutaArchivo = "";
            try
            {
                VerReporteCertificadoOrigen(false);
                VerReporteFactura(false);
                VerReportePacking(false);

                rutaArchivo = Application.StartupPath;
                string archivoCertificadoOrigen = "", archivoFactura = "", archivoPacking = "";

                archivoCertificadoOrigen ="CO" + txtNumero.Text.Trim() + ".pdf";
                archivoFactura = "FA" + txtNumero.Text.Trim() + ".pdf";
                archivoPacking = "PL" + txtNumero.Text.Trim() + ".pdf";
                rutaArchivo = Path.Combine(rutaArchivo, archivoCertificadoOrigen) + "|" +
                             Path.Combine(rutaArchivo, archivoFactura) + "|" +
                             Path.Combine(rutaArchivo, archivoPacking);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar envio de sunat : " + ex.Message);
            }
            return rutaArchivo;
        }
        #endregion
        #region "Reportes"
        private void VerReporteFactura(bool visualizarReporte = true)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string codigoTipoDocumento = "";
                string codigonumeroPacking = "";
                string codigoPlantilla = "";

                codigoTipoDocumento = "01";
                codigonumeroPacking = txtNumero.Text.Trim();
                codigoPlantilla = "01";

                DataTable datosFactura = new DataTable();
                datosFactura = PackingListLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa, numeroDocumento);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptPackingFactura.rpt";
                reporte.DataSource = datosFactura;

                ReporteControladora control = new ReporteControladora(reporte);
                if (visualizarReporte == true)
                {
                    control.VistaPrevia(enmWindowState.Normal);
                }
                else if (visualizarReporte == false)
                {
                    control.VistaCorreo(enmWindowState.Normal,
                            "FA" + codigonumeroPacking);
                }
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error en vista: " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void VerReporteCertificadoOrigen(bool visualizarReporte = true)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Reporte rep = new Reporte("Documento");
                string codigonumeroPacking = "", codigoEmpreas;
                DataTable dt = new DataTable();

                codigonumeroPacking = txtNumero.Text.Trim();
                codigoEmpreas = Logueo.CodigoEmpresa;


                dt = PackingListLogic.Instance.TraeReporteCertificadoOrigen(codigoEmpreas, codigonumeroPacking);

                Reporte reporte = new Reporte("Documento");

                //Codigo para reportes con logos dinamicos
                string rutalogo = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", Util.convertiracadena(Logueo.RucEmpresa) + ".png");
                string rutalogoxdefecto = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", "Logopordefecto.png");

                if (System.IO.File.Exists(rutalogo) == true)
                {
                    //Util.ShowAlert("No existe el archivo logo en la ruta :" + rutalogo);
                    //return;
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogo));
                }
                else
                {
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogoxdefecto));
                }

                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptCertificadoOrigen.rpt";
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                if (visualizarReporte == true)
                {
                    control.VistaPrevia(enmWindowState.Normal);
                }
                else if (visualizarReporte == false)
                {
                    control.VistaCorreo(enmWindowState.Normal,
                            "CO" + codigonumeroPacking);
                }
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer reporte de certificado de origen : " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void VerReportePacking(bool visualizarReporte = true)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Reporte rep = new Reporte("Documento");
                string codigonumeroPacking = "", codigoEmpreas;
                DataTable dt = new DataTable();
                codigoEmpreas = Logueo.CodigoEmpresa;
                codigonumeroPacking = txtNumero.Text;


                dt = PackingListLogic.Instance.TraeReportePackingList(codigoEmpreas, codigonumeroPacking);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptPackingList.rpt";
                reporte.DataSource = dt;
                ReporteControladora control = new ReporteControladora(reporte);
                if (visualizarReporte == true)
                {
                    control.VistaPrevia(enmWindowState.Normal);
                }
                else if (visualizarReporte == false)
                {
                    control.VistaCorreo(enmWindowState.Normal, 
                            "PL" + codigonumeroPacking);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar reporte packing: " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }


        protected override void OnReporteFactura()
        {
            VerReporteFactura(true);
        }     
        //Trae reporte certificado de origen
        protected override void OnReporteCertificado()
        {
            VerReporteCertificadoOrigen(true);
            //Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    Reporte rep = new Reporte("Documento");
            //    string codigonumeroPacking = "", codigoEmpreas;
            //    DataTable dt = new DataTable();

            //    codigonumeroPacking = txtNumero.Text.Trim();
            //    codigoEmpreas = Logueo.CodigoEmpresa;


            //    dt = PackingListLogic.Instance.TraeReporteCertificadoOrigen(codigoEmpreas, codigonumeroPacking);

            //    Reporte reporte = new Reporte("Documento");
            //    reporte.Ruta = Logueo.GetRutaReporte();
            //    reporte.Nombre = "RptCertificadoOrigen.rpt";
            //    reporte.DataSource = dt;

            //    ReporteControladora control = new ReporteControladora(reporte);
            //    control.VistaPrevia(enmWindowState.Normal);
            //}
            //catch (Exception ex)
            //{
            //    Util.ShowError("Error al traer reporte de certificado de origen : " + ex.Message);
            //}
            //Cursor.Current = Cursors.Default;
        }
        //Trae reporte de packing
        protected override void OnVista()
        {
            //VerReporteFactura(true);
            VerReportePacking(true);
        }


        protected override void OnEnviarCorreo()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                EnviarCorreoPorOutlook();
    
                
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al enviar correo :" + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }


        #endregion
        protected override void OnPrimero()
        {
            int indice = 0;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[indice];
            numeroDocumento = Util.GetCurrentCellText(FrmParent.gridControl.MasterView.CurrentRow, "NumeroDocumento");
            CargarCabecera();
            CargarDetalle();
        }
        protected override void OnSiguiente()
        {
            int indice = FrmParent.gridControl.MasterView.CurrentRow.Index + 1;
            if (indice > FrmParent.gridControl.MasterView.Rows.Count - 1)
            { return; }
            FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[indice];
            numeroDocumento = Util.GetCurrentCellText(FrmParent.gridControl.MasterView.CurrentRow, "NumeroDocumento");
            CargarCabecera();
            CargarDetalle();
        }
        protected override void OnAnterior()
        {
            int indice = FrmParent.gridControl.MasterView.CurrentRow.Index - 1;
            if (indice < 0)
            {
                return;
            }
            FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[indice];
            numeroDocumento = Util.GetCurrentCellText(FrmParent.gridControl.MasterView.CurrentRow, "NumeroDocumento");
            CargarCabecera();
            CargarDetalle();
        }
        protected override void OnUltimo()
        {
            int indice = FrmParent.gridControl.Rows.Count - 1;
            FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[indice];
            numeroDocumento = Util.GetCurrentCellText(FrmParent.gridControl.MasterView.CurrentRow, "NumeroDocumento");
            CargarCabecera();
            CargarDetalle();
        }
        
        protected override void OnGuardar()
        {
            Cursor.Current = Cursors.WaitCursor;
            PackingList packingCabecera = new PackingList();
            int flag = 0; string mensaje = "";

            packingCabecera.Empresa = Logueo.CodigoEmpresa;
            packingCabecera.NumeroDocumento = txtNumero.Text.Trim();
            packingCabecera.anio = Logueo.Anio;
            packingCabecera.mes = Logueo.Mes;
            packingCabecera.Fecha = dtpFecha.Value;
            packingCabecera.ClienteCodigo = txtCodCliente.Text.Trim();
            packingCabecera.ContainerNro = txtcontenedor.Text.Trim();
            packingCabecera.PrecintoNros =  txtprecinto.Text.Trim();
            try
            {
                if (Estado == FormEstate.New)
                {
                    datos.InsertarPackingCab(packingCabecera, out flag, out mensaje);
                    Estado = FormEstate.Edit;
                    HabilitaBotonesCabeceraPorEstadoFormulario();
                }
                else if (Estado == FormEstate.Edit)
                {
                    datos.ActualizarPackingCab(packingCabecera, out flag, out mensaje);                    
                }
                else
                {
                    Util.ShowAlert("OPCION NO VALIDA");
                }

                Util.ShowMessage(mensaje, flag);

                if (flag == 1)
                {
                    ActivarBotonesDetallePorEstado(false);
                    FrmParent.Cargar();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Util.ShowError("Error al guardar cabecera : " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar cabecera:" + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void HabilitaBotonesCabeceraPorEstadoFormulario()
        {
            OcultarBotones();

            if (Estado == FormEstate.New)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            }
            else if (Estado == FormEstate.Edit)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);                                                

                HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia); //Reporte packing
                HabilitaBotonPorNombre(BaseRegBotones.cbbEnviarCorreo); // Envio packig para huaral y envio suant para Lima
                HabilitaBotonPorNombre(BaseRegBotones.cbbNavegacion);

                if (PermitirOperacionLima() == true)
                {
                    HabilitaBotonPorNombre(BaseRegBotones.cbbReporteCertificado);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbReporteFactura);
                }
                                                
                
            }
            else if (Estado == FormEstate.View)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia); // Generar reporte certificado origen                
                HabilitaBotonPorNombre(BaseRegBotones.cbbEnviarCorreo); // Envio packig para huaral y envio suant para Lima
                HabilitaBotonPorNombre(BaseRegBotones.cbbNavegacion);
                if (PermitirOperacionLima() == true)
                {
                    HabilitaBotonPorNombre(BaseRegBotones.cbbReporteCertificado);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbReporteFactura);
                }
                     
            }
            

            


            
        }        
       
        private void Editar()
        {
            if (PermitirOperacionLima() == true)
            {
                //btnEditar.Enabled = true;
                btnEditarPrecio.Enabled = true;
            }
            else {
                
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
                btnInsertar.Enabled = true;
                txtNumero.Enabled = false;
            }
            
            
        }
  
        

        private int ObtenerUltimaColumnaVisible()
        {
            int indiceMayor;
            indiceMayor = 0;
            foreach (GridViewColumn col in this.gridControl.Columns)
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
        private void DesactivTodoBotonesCabDetalle()
        {                        
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnInsertar.Enabled = false;
            btnEditarPrecio.Enabled = false;
        }
     
        private void InsercionDinamica()
        {

            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                Util.SetValueCurrentCellText(row, "flag", "1");
            }

            esInsercion = true;
            object[,] datos;
            int indiceInsertaFila = gridControl.CurrentRow.Index;
            int indiceUltimaFila = gridControl.Rows.Count - 1;
            int cantidadFilasaDesplazar = (indiceUltimaFila + 1) - indiceInsertaFila;
            datos = new object[cantidadFilasaDesplazar, gridControl.Columns.Count];
            //copiar datos
            for (int x = 0; x < cantidadFilasaDesplazar; x++)
            {
                for (int y = 0; y < gridControl.Columns.Count; y++)
                    datos[x, y] = gridControl.Rows[indiceInsertaFila + x].Cells[y].Value;
            }

            // ==================================================== limpiar fila ================================================================================
            for (int c = 0; c < this.gridControl.Columns.Count; c++)
            {
                this.gridControl.CurrentRow.Cells[c].Value = null;
            }


            // ==================================================== Agregar nueva fila ===========================================================================
            this.gridControl.Rows.AddNew();


            // ============================================================== pegar datos ========================================================================         
            for (int f = 1; f < cantidadFilasaDesplazar + 1; f++)
            {
                for (int c = 0; c < this.gridControl.Columns.Count; c++)
                {
                    this.gridControl.Rows[indiceInsertaFila + f].Cells[c].Value = datos[(f - 1), c];
                }
            }

            this.gridControl.Rows[indiceInsertaFila].IsCurrent = true;
            GridViewRowInfo rowInfo = this.gridControl.CurrentRow;
            //Configurar la neuva fila con valores por defecto
            string  nuevoItemTexto = TraerNuevoNumeroItem();
            Util.SetValueCurrentCellText(rowInfo, "Item", nuevoItemTexto);
            Util.SetValueCurrentCellText(rowInfo, "flag", "1");

            Util.SetCellInitEdit(rowInfo, "Proforma");

        }
        
        private void btnEditarPrecio_Click(object sender, EventArgs e)
        {
            EditarRegistroDetallePrecio();
        }

        private void txtcontenedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                txtprecinto.Focus();
            }
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                txtCodCliente.Focus();
            }
        }

      
    }
}
