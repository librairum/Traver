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
namespace Fac.UI.Win
{
    public partial class frmCabNotCredYDeb : frmBaseReg
    {
        string str_tipoanalisis = "";
        internal string tipoDocumento = "";
        private static frmCabNotCredYDeb _aForm;
        private frmNotaCreYNotDeb FrmParent { get; set; }
        public static frmCabNotCredYDeb Instance(frmNotaCreYNotDeb padre)
        {
            if (_aForm != null) return new frmCabNotCredYDeb(padre);
            _aForm = new frmCabNotCredYDeb(padre);
            return _aForm;
        }

        #region "Seguridad"
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
          cancelar_a, expmovi_a;
        private void ComportarmientoBotones(string accion)
        {
            OcultarBotones();
            //leer variables boolean de frmListaDocumentos
            this.nuevo_a = FrmParent.nuevo_a;
            this.editar_a = FrmParent.editar_a;
            this.eliminar_a = FrmParent.eliminar_a;
            this.ver_a = FrmParent.ver_a;
            this.imprimir_a = FrmParent.imprimir_a;
            this.refrescar_a = FrmParent.refrescar_a;
            this.importar_a = FrmParent.importar_a;
            this.vista_a = FrmParent.vista_a;
            this.guardar_a = FrmParent.guardar_a;
            this.cancelar_a = FrmParent.cancelar_a;
            this.expmovi_a = FrmParent.expmovi_a;
            switch (accion)
            {
                case "cargar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    break;

                case "nuevo":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "editar":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "grabar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    break;

                case "cancelar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    break;

                case "ver":
                    //if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    //if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    //if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    if (ver_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVer); }
                    if (vista_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia); }
                    //if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }

                    break;
            }

        }
        #endregion
        public frmCabNotCredYDeb(frmNotaCreYNotDeb padre)
        {
            InitializeComponent();
            FrmParent = padre;

            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.CurrentCellChanged += new CurrentCellChangedEventHandler(gridControl_CurrentCellChanged);
            gridControl.CellValueChanged += new GridViewCellEventHandler(gridControl_CellValueChanged);
            gridControl.KeyUp += new KeyEventHandler(gridControl_KeyUp);
            //gridControl.KeyDown += new KeyEventHandler(gridControl_KeyDown);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            
            txtsubplantilla.KeyDown += new KeyEventHandler(txtsubplantilla_KeyDown);
            txtdocmodtipdoc.KeyDown += new KeyEventHandler(txtdocmodtipdoc_KeyDown);
            txtdocmodnro.KeyDown += new KeyEventHandler(txtdocmodnro_KeyDown);
            txtMotivoCod.KeyDown += new KeyEventHandler(txtMotivoCod_KeyDown);

            txtmoneda.KeyDown += new KeyEventHandler(txtmoneda_KeyDown);
            txtTipoCambio.KeyDown += new KeyEventHandler(txtTipoCambio_KeyDown);
            TxtObservacion.KeyDown += new KeyEventHandler(TxtObservacion_KeyDown);
            txtNumeroDocumento.KeyDown += new KeyEventHandler(txtNumeroDocumento_KeyDown);
            dtpFechaDoc.KeyDown += new KeyEventHandler(dtpFechaDoc_KeyDown);

            btnGuardarBaja.Click += new EventHandler(btnGuardarBaja_Click);
            btnCancelarBaja.Click += new EventHandler(btnCancelarBaja_Click);            
            OcultarDarBaja();

            Util.ConfigGridToEnterNavigation(this.gridControl);
        }

        
        private void FocusNextControl(KeyEventArgs paramEvent)
        {
            if (paramEvent.KeyValue == (char)Keys.Enter || paramEvent.KeyValue == (char)Keys.Down)
                SendKeys.Send("{TAB}");
            else if (paramEvent.KeyValue == (char)Keys.Up)
                SendKeys.Send("+{TAB}");
        }
        void dtpFechaDoc_KeyDown(object sender, KeyEventArgs e)
        {            
           FocusNextControl(e);
        }

        void TxtObservacion_KeyDown(object sender, KeyEventArgs e)
        {           
           FocusNextControl(e);
        }

        void txtTipoCambio_KeyDown(object sender, KeyEventArgs e)
        {            
           FocusNextControl(e);
        }

        void txtmoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmFactCab_Moneda);
            else
                FocusNextControl(e);
        }
		void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            FocusNextControl(e);
        }
        private void OcultarDarBaja()
        {
            gpxDarBaja.SendToBack();
            gpxDarBaja.Hide();
            dtpFechaBaja.Text = ""; txtMotivoBaja.Text = "";
            dtpFechaBaja.Value = DateTime.Now;
        }
        private void MostrarDarBaja()
        {
            dtpFechaBaja.Focus();            
            gpxDarBaja.BringToFront();
            gpxDarBaja.Show();
            
        }
        private bool Validar_fecha_vs_periodo(DateTime fecha, string periodoactivo)
        {
            string str_mesdefecha;
            string str_aniodefecha;
            //inicializo la funcion
            bool b_flag = false;
            str_mesdefecha = fecha.Month.ToString();
            if (str_mesdefecha.Length == 2)
            {
                str_mesdefecha = fecha.Month.ToString();
            }
            else
            {
                str_mesdefecha = "0" + str_mesdefecha;
            }
            str_aniodefecha = fecha.Year.ToString();

            if (Convert.ToDouble(str_aniodefecha + str_mesdefecha) == Convert.ToDouble(periodoactivo))
            {

            }
            else
            {
                if (Convert.ToDouble(str_aniodefecha + str_mesdefecha) > Convert.ToDouble(periodoactivo))
                {
                    Util.ShowAlert("Error: Fecha no valida.Posiblemente sea de un periodo posterior al periodo actual, DEBE CORREGIR LA FECHA PARA SEGUI TRABAJANDO");
                    b_flag = true;
                }
                else
                {
                    bool respuesta = Util.ShowQuestion("Error: Fecha No Valida.Posiblemente Sea De Un Periodo Anterior Al Periodo Actual,¿ESTA SEGURO QUE LA FECHA QUE ESTA INGRESANDO ES CORRECTA?");
                    if (respuesta == true)
                        b_flag = false;
                    else
                        b_flag = true;

                }

            }
            return b_flag;
        }
        void btnCancelarBaja_Click(object sender, EventArgs e)
        {
            OcultarDarBaja();
        }

        void btnGuardarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea dar de baja el documento?");
                if (respuesta == false) return;
                int int_flag = 0; string str_mensaje = "";
                if (dtpFechaBaja.Text == "") { Util.ShowAlert("Ingresar fecha"); return; }
                if (txtMotivoBaja.Text == "") { Util.ShowAlert("Ingresar motivo"); return; }


                DocumentoLogic.Instance.DarComunicadoBaja(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(),
                    txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), dtpFechaDoc.Text.Trim(),
                    dtpFechaBaja.Text.Trim(), txtMotivoBaja.Text.Trim(), out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1)
                {
                    OcultarDarBaja();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar baja:" + ex.Message);
            }
        }
        BaseGridEditor _gridEditor;
        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.Row != null)
                    // Descripcion                                      valor
                    // Bloquear las celdas si el flag es modo lectura   ""

                    if (Util.GetCurrentCellText(e.Row, "flag") == "")
                        e.Cancel = true;
                    //else
                    //    if (Util.IsCurrentColumn(e.Column, "FAC05CODPROD"))
                    //        e.Cancel = true;

                        //if (txtcodplantilla.Text == "03")                        
                        //    if (Util.IsCurrentColumn(e.Column, "FAC05CODPROD"))
                        //        e.Cancel = true;
                        //else if (txtcodplantilla.Text == "02")
                        //        if (Util.IsCurrentColumn(e.Column, "FAC05CODPROD"))
                        //            e.Cancel = true;

                
                _gridEditor = this.gridControl.ActiveEditor as BaseGridEditor;

                if (_gridEditor != null)
                {
                    RadItem editorElement = _gridEditor.EditorElement as RadItem;
                    editorElement.KeyDown += new KeyEventHandler(gridControl_KeyDown);
                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            //if (Estado == FormEstate.View) { return; }
            if (FrmParent.Estado == FormEstate.View) { return; }
            if (this.gridControl.Columns["btnGrabarDet"].IsCurrent)
            {
                GuardarDetalle();
            }

            if (this.gridControl.Columns["btnEditarDet"].IsCurrent)
            {                
                EditarDetalle();
            }

            if (this.gridControl.Columns["btnEliminarDet"].IsCurrent)
            {                
                EliminarDetalle();

            }

            if (this.gridControl.Columns["btnCancelarDet"].IsCurrent)
            {                
                CancelarDetalle();
            }
        }

        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridControl.Rows.Count == 0) return;
            
            //FocusNextControl(e);
            
            // Validar para traer la ayuda  si el usuario esta en modo nuevo o edicion.
            string str_flag = Util.GetCurrentCellText(gridControl, "flag");

            if (str_flag == "0" || str_flag == "1")
                if (e.KeyValue == (char)Keys.F1)
                {
                    if (Util.IsCurrentColumn(gridControl.CurrentColumn, "FAC05CODPROD"))
                    {
                          traerAyuda(enmAyuda.enmNotaCD_ArtxTipo);
                     }
                }
        }

        void txtMotivoCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmNotaCD_Motivo);
            else 
                FocusNextControl(e);
            
        }

        void txtdocmodnro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmNotaCD_NroDocumento);
            else 
                FocusNextControl(e);
            
        }

        void txtdocmodtipdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                traerAyuda(enmAyuda.enmNotaCD_TipoDocumento);
            else 
                FocusNextControl(e);
            
        }

        void txtsubplantilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)            
                traerAyuda(enmAyuda.enmNotaCD_SubPlantilla);
            else 
                FocusNextControl(e);                        
        }
        void calculartotales()
        {
            try
            {
                double dbl_cantidad = Util.GetCurrentCellDbl(this.gridControl, "FAC05CANTIDAD");
                double dbl_precio = Util.GetCurrentCellDbl(this.gridControl, "FAC05PRECIO");
                double dbl_subtotal = 0, dbl_total = 0;

                // obtener IGV de la cabecera del documento
                double dbl_igv = Convert.ToDouble(txtigvPorcen.Text) / 100;

                dbl_subtotal = dbl_cantidad * dbl_precio;
                dbl_total = dbl_subtotal + (dbl_subtotal * dbl_igv);

                Util.SetValueCurrentCellDbl(this.gridControl, "FAC05IGV", dbl_igv * dbl_subtotal);
                Util.SetValueCurrentCellDbl(this.gridControl, "FAC05SUBTOTAL", dbl_subtotal);
                Util.SetValueCurrentCellDbl(this.gridControl, "FAC05IMPTOTAL", dbl_total);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al calcular detalles :  " + ex.Message);
            }
        }
        void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
        
            if(gridControl.Rows.Count == 0) return;
            if(e.Value == null) return;
            if(e.Column.Name == "FAC05CANTIDAD" || e.Column.Name == "FAC05PRECIO")            
                calculartotales();
                         
        }

        void gridControl_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == (char)Keys.Enter)
            //    SendKeys.Send("{TAB}");
        }

        void gridControl_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            //try
            //{
            //    if (e.CurrentCell == null) return;
            //    string str_ColumnName = gridControl.CurrentColumn.Name;
            //    Util.SetCellInitEdit(gridControl, str_ColumnName);
            //}
            //catch (Exception ex)
            //{
            //    Util.ShowError(ex.Message);
            //}
        }
        
        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {

                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);                

                //if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value == null) return;
                
                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                { habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true); }
                else { habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false); }


            }
        }        
        private void IniciarControles()
        {
            
            //txtTipoCambio.Text = "1.000";
            
            txtigvPorcen.Text = Logueo.Igv.ToString();
            
            dtpFechaDoc.Value = DateTime.Now;
            //Traer tipo de cambio por defecto
            //double TipoCambio;
            //GlobalLogic.Instance.TipoCambioTraer(dtpFechaDoc.Text, out TipoCambio);
            //txtTipoCambio.Text = TipoCambio.ToString();

            

        }
        private void LimpiarControles()
        {
            TxtCliente.Text = "";
            txtDireccion.Text = "";
            txtNumeroDocumento.Text = "";
            txtserie.Text = "";
            txtsubplantilla.Text = "";
            LblHelp0.Text = "";
            txtRazon.Text = "";
            TxtObservacion.Text = "";
            TxtRuc.Text = "";
            txtmoneda.Text = "";
            txttipdoc.Text = "";
            txtcodplantilla.Text = "";
            txttipoarticulo.Text = "";
            txttipoventa.Text = "";
            dtpFechaDoc.SetToNullValue();
            dtpDocModFecha.SetToNullValue();
            txtdocmodnro.Text = "";
            LblHelp1.Text = "";
            txtdocmodtipdoc.Text = "";
            LblHelp2.Text = "";
            txtotrosespecificar.Text = "";
            txtMotivoCod.Text = "";
            LblHelp3.Text = "";
            txtTipoOperacionFE.Text = "";
            txtCodigoAnexoEmisorFE.Text = "";
            gridControl.DataSource = null;
        }
        private void EditarControles()
        {

             // Inhabilitar Campos de ayuda    
            txtsubplantilla.Enabled = true;
            txtdocmodtipdoc.Enabled = true;
            txtdocmodnro.Enabled = true;
            
            txtMotivoCod.Enabled = true;
            txtmoneda.Enabled = true;

            txtserie.Enabled = false;
            TxtCliente.Enabled = false;
            txtDireccion.Enabled = false;


            txtNumeroDocumento.Enabled = false;


            txtRazon.Enabled = false;
            TxtObservacion.Enabled = true;
            TxtRuc.Enabled = false;


            txtTipoCambio.Enabled = true;
            dtpFechaDoc.Enabled = true;
            dtpDocModFecha.Enabled = false;

            gpbMotivo.Enabled = true;
    
        }
        protected override void OnGuardar()
        {
            try
            {
                if (ValidarCabecera() == false) return;
                string motivo = "";
                DocumentoFA entidadDocumento = new DocumentoFA();
                if (dtpFechaDoc.Text == "")
                {
                    Util.ShowAlert("Debe seleccionar fecha de documento");
                    return;
                }
                entidadDocumento.FAC04CODEMP = Logueo.CodigoEmpresa; //            @FAC04CODEMP  char(2),                            
                entidadDocumento.FAC01COD = txttipdoc.Text.Trim(); //@FAC01COD  char(2),                            
                entidadDocumento.FAC04NUMDOC = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();//@FAC04NUMDOC  varchar(20),                            
                entidadDocumento.FAC04AA = Logueo.Anio;//@FAC04AA  char(4),                            
                entidadDocumento.FAC04MM = Logueo.Mes; //@FAC04MM  char(2),                            
                entidadDocumento.FAC04NRODOC = txtNumeroDocumento.Text.Trim(); //@FAC04NRODOC  varchar(15),                            
                entidadDocumento.FAC04SERIEDOC = txtserie.Text.Trim(); //@FAC04SERIEDOC  varchar(5),                            
                entidadDocumento.FAC04FECHA = Convert.ToDateTime(dtpFechaDoc.Text.Trim()); //@FAC04FECHA  varchar(10),                            
                entidadDocumento.FAC04TIPANA = str_tipoanalisis;  //@FAC04TIPANA  char(2),                            
                entidadDocumento.FAC04CODCLI = TxtCliente.Text.Trim(); //@FAC04CODCLI  varchar(11),                            
                entidadDocumento.FAC04MONEDA = txtmoneda.Text.Trim();//@FAC04MONEDA  char(2),                            
                entidadDocumento.FAC04TIPCAMBIO = Convert.ToDouble(txtTipoCambio.Text.Trim()); //@FAC04TIPCAMBIO float,                            
                entidadDocumento.FAC04DONSUBTOTAL = 0;//@FAC04DONSUBTOTAL float,                            
                entidadDocumento.FAC04DONIGV = 0;//@FAC04DONIGV   float,                            
                entidadDocumento.FAC04DONTOTAL = 0;//@FAC04DONTOTAL  float,                            
                entidadDocumento.FAC02COD = txtcodplantilla.Text.Trim();//@FAC02COD   char(2),                            
                entidadDocumento.FAC03COD = txtsubplantilla.Text.Trim();//@FAC03COD   char(2),                            
                entidadDocumento.FAC03TIPART = txttipoarticulo.Text.Trim();//@FAC03TIPART   char(2),                            
                entidadDocumento.FAC04CLINOMBRE = txtRazon.Text.Trim();//@FAC04CLINOMBRE  varchar(100),                            
                entidadDocumento.FAC04CLIDIRECCION = txtDireccion.Text.Trim();//@FAC04CLIDIRECCION varchar(100),                            
                entidadDocumento.FAC04CLIRUC = TxtRuc.Text.Trim();//@FAC04CLIRUC   varchar(11),                            
                entidadDocumento.FAC04GLOSA = TxtObservacion.Text.Trim();//@FAC04GLOSA   varchar(250),                            
                entidadDocumento.FAC04DONGLAG = "N";//@FAC04DONGLAG   char(1),                            
                entidadDocumento.FAC04IGV = Convert.ToDouble(txtigvPorcen.Text.Trim()); //@FAC04IGV   float,                            
                entidadDocumento.FAC04GUIAS = ""; //@FAC04GUIAS   varchar(100),                            
                entidadDocumento.FAC04DOCMODTIPDOC = txtdocmodtipdoc.Text.Trim(); //@FAC04DOCMODTIPDOC   char(2),                            
                entidadDocumento.FAC04DOCMODNRO = txtdocmodnro.Text.Trim();//@FAC04DOCMODNRO         Varchar(20),    
                
                if (dtpDocModFecha.Text == "")
                {
                    entidadDocumento.FAC04DOCMODFECHA = null;
                }
                else
                {
                    entidadDocumento.FAC04DOCMODFECHA = Convert.ToDateTime(dtpDocModFecha.Text.Trim());//@FAC04DOCMODFECHA  Varchar(10),                            
                }
                entidadDocumento.FAC04TIPMOTEMI = motivo;//@FAC04TIPMOTEMI   Char(1),                            
                entidadDocumento.FAC04TIPMOTEMIDES = txtotrosespecificar.Text.Trim();//@FAC04TIPMOTEMIDES  Varchar(500),                            
                entidadDocumento.FAC04EXPCONOEMBARQUE = ""; //@FAC04EXPCONOEMBARQUE  Varchar(20), 1
                entidadDocumento.FAC04EXPCODPAISORIGEN = "";//@FAC04EXPCODPAISORIGEN  Char(2),     2                       
                entidadDocumento.FAC04EXPCODPAISDESTINO = "";//@FAC04EXPCODPAISDESTINO Char(2), 3
                entidadDocumento.FAC04EXPCODCONDPAGO = "";//@FAC04EXPCODCONDPAGO  Char(2),     4                 
                entidadDocumento.FAC04EXPCODCONDDESPACHO = "";//@FAC04EXPCODCONDDESPACHO Char(2), 5                            
                entidadDocumento.FAC04EXPCODPUERTO = "";//@FAC04EXPCODPUERTO   Char(2),            6     
                entidadDocumento.FAC04EXPCODPUERTODES = "";//@FAC04EXPCODPUERTODES   Char(2),       7                 
                entidadDocumento.FAC04EXPCODBCOLOCAL = "";//@FAC04EXPCODBCOLOCAL  Char(2),           8                 
                entidadDocumento.FAC04EXPCDDOCCRED = "";//@FAC04EXPCDDOCCRED  Varchar(20),            9                
                entidadDocumento.FAC04EXPLCEMITIDA = "";//@FAC04EXPLCEMITIDA  Varchar(20),           10               
                entidadDocumento.FAC04EXPBANKCODE = "";//@FAC04EXPBANKCODE  Varchar(10),              11            
                entidadDocumento.FAC04EXPNUMCUENTA = ""; //@FAC04EXPNUMCUENTA  Varchar(20),            12
                entidadDocumento.FAC04EXPNROCONTAINER = ""; //@FAC04EXPNROCONTAINER  Varchar(20),                      13
                entidadDocumento.FAC04EXPNROPRECINTO = ""; //@FAC04EXPNROPRECINTO  Varchar(20),                        14  
                entidadDocumento.FAC04ORDENCOMPRA = ""; //@FAC04ORDENCOMPRA  Varchar(50),                            15
                entidadDocumento.FAC04FECORDCOMPRA = null; //@FAC04FECORDCOMPRA  Varchar(10),                            16
                entidadDocumento.FAC04CODTIPOVENTA = txttipoventa.Text.Trim();//@FAC04CODTIPOVENTA  Char(2),            
                entidadDocumento.FAC04ESTADODEPROCESO = "L";//@FAC04ESTADODEPROCESO  Char(1),            
                entidadDocumento.FAC04TIENDA = txtCodTienda.Text.Trim();//@FAC04TIENDA  char(3),            
                entidadDocumento.FAC04DESCUENTOGLOBAL = 0;//@FAC04DESCUENTOGLOBAL float,            
                entidadDocumento.FAC04FETIPONOTA = txtMotivoCod.Text.Trim();//@FAC04FETIPONOTA char(2),  
                entidadDocumento.FAC04LIQUIDACIONNRO = "";//@FAC04LIQUIDACIONNRO char(2),  
                entidadDocumento.FAC04FETIPODEOPERACION = txtTipoOperacionFE.Text;
                entidadDocumento.FAC04FECODIGOANEXOEMISOR = txtCodigoAnexoEmisorFE.Text;
                entidadDocumento.FAC04TIENDA = txtCodTienda.Text.Trim();
                string MensajeRespuesta = "";
                int int_Flag = 0;
                if (Estado == FormEstate.New)
                {
                    DocumentoLogic.Instance.Spu_Fact_Ins_FAC04_CABFACTURA(entidadDocumento, out int_Flag, out MensajeRespuesta);
                }
                else if (Estado == FormEstate.Edit)
                {
                    DocumentoLogic.Instance.Spu_Fact_Upd_FAC04_CABFACTURA(entidadDocumento, out int_Flag, out MensajeRespuesta);
                }
                Util.ShowMessage(MensajeRespuesta, int_Flag);
                if (int_Flag == 1)
                {
                    ActivarModoVer();
                    VerBotonesCabVer();
                    VerBotonesDelDetalle();
                    EditarControles();
                    Estado = FormEstate.Edit;
                    //ComportarmientoBotones("cargar");
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar cabecera de nota de creidto o noa de debito: " + ex.Message);
            }
        }
        private void VerBotonesCabGuardar()
        {
            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
        }
        private void VerBotonesCabCancelar()
        {
            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbGeneraPDF);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVerFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
        }
        private void VerBotonesCabVer()
        {
            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbNavegacion);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbCopiar);

            HabilitaBotonPorNombre(BaseRegBotones.cbbGeneraPDF);
            
            //HabilitaBotonPorNombre(BaseRegBotones.cbbDarBaja);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);

            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVerFE);            
            HabilitaBotonPorNombre(BaseRegBotones.cbbDarBaja);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);

        }
        protected override void OnNuevo()
        {
         
                // Limpiar los campos de cabecera y detalle del fromulario
                LimpiarControles();
                //iniciar controles
                IniciarControles();
                // 1.Ver los botones de guardar y cancelar                
                VerBotonesCabGuardar();

                //2.Asignar el valor de tipo de documento a nuestro control.
                txttipdoc.Text = tipoDocumento;

                // 3.Activar el resto de campos necesarios del formulario.
                // 3.1.Activar los campos 
                EditarControles();
                txtsubplantilla.Enabled = true;

                //habilitar el campo serie
                txtserie.Enabled = false;
                txtNumeroDocumento.Enabled = true;
                // 4.Ocultamos los botones del detalle
                OcultarBotonesDelDetalle();
                ResaltarControlesAyuda(true);
                txttipdoc.Focus();
                Estado = FormEstate.New;
            
         
        }
        protected override void OnEditar()
        {
            EditarControles();            
            // 3.Ver los botones 
            VerBotonesCabGuardar();
            // 4:Ver botones de la cabecera del documento            
            //VerTodoBotonesCabDetalle();
            OcultarBotonesDelDetalle();
            // 5:Habilitar los botones para el mantenimiento de la grilla                    
            ResaltarControlesAyuda(true);
            Estado = FormEstate.Edit;
        }
        protected override void OnCancelar()
        {            
            // 1.Bloquea los controles de ingreso de datos
            ActivarModoVer();
            // 2.Veo los botones utiles para el modo ver en nuestro formulario
            VerBotonesCabVer();
            // 3.Ocultamos los botones del detalle del formulario.
            VerBotonesDelDetalle();                
            // 4.Trae datos del ultimo registro seleccionado
            CargaDetalle();
            
            ResaltarControlesAyuda(false);
            Estado = FormEstate.View;
        }
		void ResaltarControlesAyuda(bool resaltarControles)
        {
            if (resaltarControles == true)
            {
                Util.ResaltarAyuda(txtsubplantilla);
                Util.ResaltarAyuda(txtdocmodtipdoc);
                Util.ResaltarAyuda(txtdocmodnro);
                Util.ResaltarAyuda(txtMotivoCod);
            }
            else
            {
                Util.ResetearAyuda(txtsubplantilla);
                Util.ResetearAyuda(txtdocmodtipdoc);                
                Util.ResetearAyuda(txtdocmodnro);
                Util.ResetearAyuda(txtMotivoCod);
            }
        }
		void OcultarBotonesDelDetalle()
        {
            btnAdd.Visible = false;
        }
        void VerBotonesDelDetalle() {
            btnAdd.Visible = true;
            btnAdd.Enabled = true;
        }
        private void CargaDetalle()
        {
            if (FrmParent.gridControl.Rows.Count > 0)
            {
                GridViewRowInfo row =  FrmParent.gridControl.CurrentRow;
                
                TxtCliente.Text = Util.GetCurrentCellText(row, "FAC04CODCLI");                
                txtDireccion.Text = Util.GetCurrentCellText(row, "FAC04CLIDIRECCION");                
                txtNumeroDocumento.Text = Util.GetCurrentCellText(row, "FAC04NRODOC");                
                txtserie.Text = Util.GetCurrentCellText(row, "FAC04SERIEDOC");                
                txtsubplantilla.Text = Util.GetCurrentCellText(row, "FAC03COD");                               
                LblHelp0.Text = Util.GetCurrentCellText(row, "FAC03DESC"); // SubPlantillaDesc                                
                txtRazon.Text = Util.GetCurrentCellText(row, "FAC04CLINOMBRE");                
                TxtObservacion.Text = Util.GetCurrentCellText(row, "FAC04GLOSA");                                

                str_tipoanalisis = Util.GetCurrentCellText(row, "FAC04TIPANA");
                TxtRuc.Text =  Util.GetCurrentCellText(row, "FAC04CLIRUC");
                txtmoneda.Text = Util.GetCurrentCellText(row, "FAC04MONEDA");
                // traer descripcion de moneda
                txtMonedaDesc.Text = Util.GetCurrentCellText(row, "MonedaDesc");
                txtTipoCambio.Text = Util.GetCurrentCellText(row, "FAC04TIPCAMBIO");// --> debe asignar el tipo de cambio de la Factura , debeo asignar tipo de cambia de la fecha del dia
                txttipdoc.Text = Util.GetCurrentCellText(row, "FAC01COD");
                txtcodplantilla.Text = Util.GetCurrentCellText(row, "FAC02COD");
                txttipoarticulo.Text = Util.GetCurrentCellText(row, "FAC03TIPART");                
                txttipoventa.Text = Util.GetCurrentCellText(row, "FAC04CODTIPOVENTA");

                
                ActivarDesactivarTab(txttipoventa.Text);
                
                if (Util.GetCurrentCellText(row, "FAC04FECHA") == "")
                { dtpFechaDoc.SetToNullValue(); } 
                else
                { dtpFechaDoc.Text = Util.GetCurrentCellText(row, "FAC04FECHA"); }

                
                if (Util.GetCurrentCellText(row, "FAC04DOCMODFECHA") == "") { dtpDocModFecha.SetToNullValue(); }
                else { dtpDocModFecha.Text = Util.GetCurrentCellText(row, "FAC04DOCMODFECHA"); }

                txtigvPorcen.Text = Util.GetCurrentCellText(row, "FAC04IGV");
                txtdocmodtipdoc.Text = Util.GetCurrentCellText(row, "FAC04DOCMODTIPDOC");

                string TipDocDescripcion = "";
                GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txtdocmodtipdoc.Text.Trim(), "1000", out TipDocDescripcion);

                LblHelp1.Text = TipDocDescripcion;
                
                
                txtdocmodnro.Text = Util.GetCurrentCellText(row, "FAC04DOCMODNRO");
                

                txtotrosespecificar.Text = Util.GetCurrentCellText(row, "FAC04TIPMOTEMIDES");
                txtMotivoCod.Text = Util.GetCurrentCellText(row, "FAC04FETIPONOTA");
                
                if(Logueo.FlagNotCreyDeb == "C")
                {
                    LblHelp3.Text = Util.GetCurrentCellText(row, "DescMotivoNotaCredito");
                }
                else if (Logueo.FlagNotCreyDeb == "D")
                {
                    LblHelp3.Text = Util.GetCurrentCellText(row, "DescMotivoNotaDebito");
                }

                txtTipoOperacionFE.Text = Util.GetCurrentCellText(row, "FAC04FETIPODEOPERACION");
                txtCodigoAnexoEmisorFE.Text = Util.GetCurrentCellText(row, "FAC04FECODIGOANEXOEMISOR");

                txtCodTienda.Text = Util.GetCurrentCellText(row, "FAC04TIENDA");                                
                string sDescripcion = "";
                GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txtCodTienda.Text, "PUNTOVENTA", out sDescripcion);                
                txtDescTienda.Text = sDescripcion;
                
                traersubdetalle();
            }
        }     
        private void traerAyuda(enmAyuda tipo)
        {
            frmBusqueda frm;
            string[] datos;
            string numeroDocumento = "";
            string descripcion = "";
            switch (tipo)
            {
                    
                case enmAyuda.enmNotaCD_SubPlantilla:
                    frm = new frmBusqueda(tipo, tipoDocumento);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');                                                  
                    txtsubplantilla.Text = datos[0];
                    LblHelp0.Text = datos[1];
                    txtcodplantilla.Text = datos[3];
                    txttipoarticulo.Text = datos[6];
                    txttipdoc.Text = datos[2];
                    txtserie.Text = datos[5];
                    txttipoventa.Text = datos[7];
                    txtTipoOperacionFE.Text = datos[8];


                    GlobalLogic.Instance.DameNroDocumento(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(), 
                                                            txtserie.Text.Trim(),  out numeroDocumento);
                    txtNumeroDocumento.Text = numeroDocumento;
                    string establecimientocod="";
                      GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + tipoDocumento + txtserie.Text,
                    "ESTABLECIMIENTO", out establecimientocod);

                      txtCodigoAnexoEmisorFE.Text = establecimientocod;

                    ActivarDesactivarTab(txttipoventa.Text.Trim());
                    txtNumeroDocumento.Focus();
                 

                    break;
                case enmAyuda.enmNotaCD_TipoDocumento:                                        
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if(frm.Result == null) return; if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');

                    txtdocmodtipdoc.Text = datos[0];
                    LblHelp1.Text = datos[1];
                    txtdocmodtipdoc.Focus();
                    break;

                case enmAyuda.enmNotaCD_ArtxTipo:
                    frm = new frmBusqueda(tipo, txttipoarticulo.Text.Trim());
                    frm.ShowDialog();
                    if(frm.Result == null) return; if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');                                        
                    Util.SetValueCurrentCellText(gridControl, "FAC05CODPROD", datos[0]);
                    Util.SetValueCurrentCellText(gridControl, "FAC05DESCPROD", datos[1]);
                    Util.SetValueCurrentCellText(gridControl, "FAC05UNIMED", datos[2]);
                    Util.SetValueCurrentCellText(gridControl, "FAC05FECODPRODSUNAT", datos[3]);
                    SendKeys.Send("{TAB}");
                    break;

                case enmAyuda.enmNotaCD_NroDocumento:
                    Cursor.Current = Cursors.WaitCursor;

                    frm = new frmBusqueda(tipo, txtdocmodtipdoc.Text);
                    frm.ShowDialog();
                    if (frm.Result == null) return; if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtdocmodnro.Text = datos[1];
                    txtRazon.Text = datos[2];
                    TxtRuc.Text = datos[4];
                    TxtCliente.Text = datos[7];
                    txtDireccion.Text = datos[3];
                    
                    str_tipoanalisis = datos[6];
                    dtpDocModFecha.Text = datos[5];
                    txtmoneda.Text = datos[8]; // trae codigo de moneda
                    txtCodTienda.Text = datos[9];
                    txtTipoCambio.Text = datos[10];
                    GlobalLogic.Instance.DameDescripcionFA(txtmoneda.Text.Trim(), "MONEDAFAC", out descripcion);
                    txtMonedaDesc.Text = descripcion;
                    
                    GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + txtCodTienda.Text, "PUNTOVENTA", out descripcion);
                    txtDescTienda.Text = descripcion;

                    txtotrosespecificar.Text = LblHelp1.Text + " N°     " + txtdocmodnro.Text + "   de Fecha     " + dtpDocModFecha.Text;
                    TxtObservacion.Focus();

                    
                    Cursor.Current = Cursors.Default;
                    break;
                case enmAyuda.enmNotaCD_Motivo:
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if (frm.Result == null) return; if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtMotivoCod.Text = datos[0];
                    LblHelp3.Text = datos[1];
                    txtotrosespecificar.Enabled = false;
                    
                    if (datos[2] == "1")
                    {
                        txtotrosespecificar.Enabled = true;
                    }
                    txtMotivoCod.Focus();
                    
                    break;
                case enmAyuda.enmFactCab_Moneda:
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if (frm.Result == null) { Util.ShowAlert("No Selecciono registro"); return; }
                    if (frm.Result.ToString() == "") { Util.ShowAlert("No Selecciono registro"); return; }
                    datos = frm.Result.ToString().Split('|');
                    txtmoneda.Text = datos[0];
                    txtMonedaDesc.Text = datos[1];
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
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
                default:
                    break;
            }

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
        #region "Metodos para Grilla"
        void CrearColumnas()
        {
            bool bVisibleON = true, bVisibleOFF = false, bEditableON = true,
                bEditableOFF = false, bReadOnlyON = true, bReadOnlyOFF = false;
            RadGridView Grid = CreateGridVista(gridControl);
            Grid.EnableFiltering = false;
            CreateGridColumn(Grid, "Empresa", "FAC05CODEMP", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "Codigo", "FAC01COD", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "Nro.Doc", "FAC04NUMDOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "Cod.Det", "FAC05CODFACDET", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//int()

            CreateGridColumn(Grid, "Cod.Prod", "FAC05CODPROD", 0, "", 90, bReadOnlyOFF, bEditableON, bVisibleON);//varchar(20)
            CreateGridColumn(Grid, "Desc.Prod", "FAC05DESCPROD", 0, "", 250, bReadOnlyOFF, bEditableON, bVisibleON);//varchar(250)
            CreateGridColumn(Grid, "Unidad", "FAC05UNIMED", 0, "", 60, bReadOnlyOFF, bEditableON, bVisibleON);//varchar(5) 
            CreateGridColumn(Grid, "Cantidad", "FAC05CANTIDAD", 0, "{0:###,###0.00}", 70, bReadOnlyOFF, bEditableON, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "Precio", "FAC05PRECIO", 0, "{0:###,###0.00}", 70, bReadOnlyOFF, bEditableON, bVisibleON, true, "right");//float()

            CreateGridColumn(Grid, "Importe", "FAC05SUBTOTAL", 0, "{0:###,###0.00}", 70, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "IGV", "FAC05IGV", 0, "{0:###,###0.00}", 70, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");//float()
            CreateGridColumn(Grid, "Total", "FAC05IMPTOTAL", 0, "{0:###,###0.00}", 80, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");//float()
            
            
            //CreateGridColumn(Grid, "Total", "FAC04IMPTOTAL", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleON); //float
            
            // Campos ocultos
            CreateGridColumn(Grid, "Part.Arancel", "FAC05PARTARAN", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar()
            CreateGridColumn(Grid, "Peso", "FAC05PESO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "NroCaja", "FAC05NROCAJA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "Peso Aduana", "FAC05PESOADUANA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "SubGrupo", "FAC05SUBGRUPO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar                  

            CreateGridColumn(Grid, "FAC05FECODRAZEXONERACION", "FAC05FECODRAZEXONERACION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FEIMPDSCTO", "FAC05FEIMPDSCTO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float
            CreateGridColumn(Grid, "FAC05FECODIMPREF", "FAC05FECODIMPREF", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FEPRODUCTOTIPO", "FAC05FEPRODUCTOTIPO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FEIMPORTEREFERENCIAL", "FAC05FEIMPORTEREFERENCIAL", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(15)
            CreateGridColumn(Grid, "FAC05FEIMPORTECARGO", "FAC05FEIMPORTECARGO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FECODPRODSUNAT", "FAC05FECODPRODSUNAT", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char
            CreateGridColumn(Grid, "FAC05FEIGVTASA", "FAC05FEIGVTASA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char


            //personalizar columnas 
            //Dar formato de mascara de 6 decimales a columna precio
            GridViewDataColumn columnaPrecio = this.gridControl.Columns["FAC05PRECIO"];
            ((GridViewMaskBoxColumn)columnaPrecio).Mask = "f6";


            //Columnas para la sumatoria
            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 90, true, false, false);
            AddButonsToGrid();

            // Columnas agregado para el mantenimiento de la grilla
            if (gridControl.MasterView.SummaryRows.Count == 0)
            {
                string[] fieldstosummary = { "FAC05SUBTOTAL", "FAC05IGV", "FAC05IMPTOTAL" };

                Util.AddGridSummarySum(gridControl, fieldstosummary);
            }


        }
        private void AddButonsToGrid()
        {
            AddCmdButtonToGrid(gridControl, "btnGrabarDet", "", "btnGrabarDet");
            AddCmdButtonToGrid(gridControl, "btnCancelarDet", "", "btnCancelarDet");
            AddCmdButtonToGrid(gridControl, "btnEliminarDet", "", "btnEliminarDet");
            AddCmdButtonToGrid(gridControl, "btnEditarDet", "", "btnEditarDet");
        }
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
                                            bool bCancelar, bool bEliminar, bool bEditar)
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

                default:
                    break;
            }
        }
       

        private void traersubdetalle()
        {
            try
            {
                gridControl.DataSource = DocumentoLogic.Instance.TraerDetalleFactura(Logueo.CodigoEmpresa,
                            txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), txttipdoc.Text);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer subdetalle :  "+ ex.Message);
            }
        }
        private bool ValidarCabecera()
        {
            if (txtNumeroDocumento.Text.Trim() == "") { Util.ShowAlert("Ingrese Nro de factura"); txtNumeroDocumento.Focus(); return false; }
            if (txtserie.Text.Trim() == "") { Util.ShowAlert("Ingrese serie"); txtNumeroDocumento.Focus();  return false; }
            if (Validar_fecha_vs_periodo(dtpFechaDoc.Value, Logueo.periodo) == true) { return false; }
            if (txtsubplantilla.Text.Trim() == "") { Util.ShowAlert("Ingrese tipo de factura"); txtsubplantilla.Focus(); return false; }
            if (str_tipoanalisis.Trim() == "") { Util.ShowAlert("Tipo de Analisis No Valido"); TxtCliente.Focus(); return false; }
            if(TxtCliente.Text.Trim() == "") { Util.ShowAlert("Ingrese Cliente"); TxtCliente.Focus(); return false; }
            if (txtmoneda.Text.Trim() != "S" && txtmoneda.Text.Trim() !="D" ) { Util.ShowAlert("Ingrese moneda"); txtmoneda.Focus(); return false; }            
            if (Convert.ToDouble(txtigvPorcen.Text) <0) { Util.ShowAlert("IGV No Valido"); return false; }
            if (txttipoventa.Text.Trim() == "") { Util.ShowAlert("Tipo De Venta Nacional/Extranjera No Valido"); return false; }
            if (txtMotivoCod.Text.Trim() == "") { Util.ShowAlert("Debe ingresar motivo"); return false; }
            //Si el control tiene un valor , entonces, valido si es numero.
            if (txtTipoCambio.Text.Trim() != "") 
            {
                double flagTipoCambio = 0;
                double.TryParse(txtTipoCambio.Text.Trim(), out flagTipoCambio);
                if (flagTipoCambio == 0)
                {
                    Util.ShowAlert("El valor de tipo de cambio no es valido");
                    return false;
                }
            }
            return true;
        }
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
        private void GuardarDetalle()
        {
            if (ValidarDetalle(gridControl.CurrentRow) == false) return;   
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                #region "Cargar parametros"
                DocumentoFA documento = new DocumentoFA();
                documento.FAC05CODEMP = Logueo.CodigoEmpresa;
                documento.FAC01COD    = txttipdoc.Text.Trim();
                documento.FAC04NUMDOC =  txtserie.Text.Trim() + "-" +txtNumeroDocumento.Text.Trim();
                
                documento.FAC05CODFACDET= 0;
                documento.FAC05CODPROD  = Util.GetCurrentCellText(this.gridControl, "FAC05CODPROD");
                documento.FAC05DESCPROD  = Util.GetCurrentCellText(this.gridControl, "FAC05DESCPROD");
                documento.FAC05UNIMED = Util.GetCurrentCellText(this.gridControl, "FAC05UNIMED");
                documento.FAC05CANTIDAD = Util.GetCurrentCellDbl(this.gridControl, "FAC05CANTIDAD");
                documento.FAC05PRECIO = Util.GetCurrentCellDbl(this.gridControl, "FAC05PRECIO");
                documento.FAC05SUBTOTAL  = Util.GetCurrentCellDbl(this.gridControl, "FAC05SUBTOTAL");
                documento.FAC05PARTARAN  = "";
                documento.FAC05PESO   = 0;
                documento.FAC05NROCAJA = 0;
                documento.FAC05PESOADUANA = 0; 
                documento.FAC05SUBGRUPO  = "";
                documento.FAC05FECODRAZEXONERACION = "";
                documento.FAC05FEIMPDSCTO   = 0;
                documento.FAC05FECODIMPREF = "";
                documento.FAC05FEPRODUCTOTIPO  = "P";
                documento.FAC05FEIMPORTEREFERENCIAL = 0;
                documento.FAC05FEIMPORTECARGO = 0;
                documento.FAC05FECODPRODSUNAT = Util.GetCurrentCellText(this.gridControl, "FAC05FECODPRODSUNAT");
                documento.FAC05FEIGVTASA = Util.GetCurrentCellDbl(this.gridControl, "FAC05FEIGVTASA");


                string str_Flag = Util.GetCurrentCellText(this.gridControl, "flag");
                #endregion
                string str_Mensaje = "";
                int int_flag = 0;

                if (str_Flag == "0")
                {
                    DocumentoLogic.Instance.Spu_Fact_Ins_FAC05_DETFACTURA(documento, out int_flag, out str_Mensaje);
                }
                else if (str_Flag == "1")
                {
                    documento.FAC05CODFACDET = Util.GetCurrentCellInt(this.gridControl, "FAC05CODFACDET");
                    DocumentoLogic.Instance.Spu_Fact_Upd_FAC05_DETFACTURA(documento, out int_flag, out str_Mensaje);
                }

                Util.ShowMessage(str_Mensaje, int_flag);

                if (int_flag == 1)
                {
                    traersubdetalle();
                    FrmParent.Cargar();
                    //Si el flag del registro a Ingresar es nuevo
                    if (str_Flag == "0")                        
                        //Entonces, agregar nueva fila despues de grabar
                        AgregarFila();
                                            
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer detalle: " + ex.Message);
            }
            
            Cursor.Current = Cursors.Default;
        }

        private void EditarDetalle()
        {
            if (HasRowToSave() > 0) { Util.ShowAlert("Debe completar registro"); return; }
            Util.SetValueCurrentCellText(this.gridControl, "flag", "1");
            Util.SetValueCurrentCellText(this.gridControl, "flagBotones", "E");
            Util.SetCellGridFocus(this.gridControl, "FAC05CODPROD");
            Util.SetCellInitEdit(this.gridControl, "FAC05CODPROD");
            Util.ResaltarAyuda(this.gridControl, "FAC05CODPROD");
        }

        private void EliminarDetalle()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (HasRowToSave() > 0) { Util.ShowAlert("Debe completar registro"); return; }
                bool res = Util.ShowQuestion("¿Desea eliminar el registro?");
                int int_flag = 0; string str_Mensaje = "";
                int int_CodigoFacturaDetalle = Util.GetCurrentCellInt(this.gridControl, "FAC05CODFACDET");
                if (res == true)
                {
                    DocumentoLogic.Instance.Spu_Fact_Del_FAC05_DETFACTURA(Logueo.CodigoEmpresa,
                     txttipdoc.Text.Trim(), txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(),
                     int_CodigoFacturaDetalle, out int_flag, out str_Mensaje);
                }
                Util.ShowMessage(str_Mensaje, int_flag);
                if (int_flag == 1)
                {
                    traersubdetalle();
                    FrmParent.Cargar();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle: " +ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void CancelarDetalle()
        {
            traersubdetalle();
        }

        #endregion
        #region "Metodos Generales"
        void ActivarModoVer()
        {
            txtsubplantilla.Enabled = false;
            dtpFechaDoc.Enabled = false;
            txtdocmodtipdoc.Enabled = false;
            txtdocmodnro.Enabled = false;
            dtpDocModFecha.Enabled = false;
            TxtCliente.Enabled = false;
            TxtRuc.Enabled = false;
            txtmoneda.Enabled = false;
            txtTipoCambio.Enabled = false;
            txtigvPorcen.Enabled = false;
            TxtObservacion.Enabled = false;
            txtMotivoCod.Enabled = false;
            txtotrosespecificar.Enabled = false;
            txtNumeroDocumento.Enabled = false;
            btnAdd.Enabled = false;
            btnAdd.Visible = false;
            OcultarBotones();
            
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); 
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNavegacion); 
            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVerFE);
            HabilitaBotonPorNombre(BaseRegBotones.cbbDarBaja);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGeneraPDF);

            //HabilitarBotones(Constantes.Botones.bGuardarOFF, 
                //Constantes.Botones.bCancelarON,
            //                 Constantes.Botones.bVistaPreviaON, 
            //Constantes.Botones.bImprimirOFF,
            //                 Constantes.Botones.bImportarOFF, 
            //Constantes.Botones.bExportarOFF,
            //                 Constantes.Botones.bNavegacionON, 
            //Constantes.Botones.bCopiarOFF,
            //                 Constantes.Botones.bGenerarPdfOFF, 
            //Constantes.Botones.bGenerarFeON,
            //                 Constantes.Botones.bVerFeON, 
            //Constantes.Botones.bDarBajaON);

            
                             
        }
        private int HasRowToSave()
        {
            int rowsaffected = 0;

            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                if (Util.GetCurrentCellText(row, "flagBotones") == "E")
                    rowsaffected++;
            }
            return rowsaffected;
        }
        void ActivarDesactivarTab(string tipoventa)
        {
            //Nacional
            if (tipoventa == "01") { txtigvPorcen.Text = Util.convertiracadena(Logueo.Igv); }
            //Internacional
            else if (tipoventa == "02")
            {
                txtigvPorcen.Text = "0";
                // No valido
            }
            else
            {
                txtsubplantilla.Text = "";
                Util.ShowAlert("Operacion No Valida, No se Especifico Si la Factura es nacional O Importada ; Asigne el valor en la configuracionde Sub Plantillas");
                txttipoventa.Focus();
            }
        }
        void MuestraBotones()
        {

            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
            

            //Muestra los botones
            //HabilitarBotones(Constantes.Botones.bGuardarON,
            //    Constantes.Botones.bCancelarON,
            //    Constantes.Botones.bVistaPreviaON,
            //    Constantes.Botones.bImprimirOFF,
            //    Constantes.Botones.bImportarOFF,
            //    Constantes.Botones.bExportarOFF,
            //    Constantes.Botones.bNavegacionOFF);
            txtNumeroDocumento.Enabled = false;
            txtserie.Enabled = false;
            TxtCliente.Enabled = true;
            txtDireccion.Enabled = true;
            
        }

        protected override void OnAnterior()
        {
            int int_indice = FrmParent.gridControl.MasterView.CurrentRow.Index - 1;
            if (int_indice < 0)
            {
                return;
            }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            CargaDetalle();
        }

        protected override void OnSiguiente()
        {
            int int_indice = FrmParent.gridControl.MasterView.CurrentRow.Index + 1;
            if (int_indice > FrmParent.gridControl.MasterView.Rows.Count - 1)
            { return; }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            CargaDetalle();
        }

        protected override void OnPrimero()
        {
            int int_indice = 0;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice]; 
            CargaDetalle();
        }

        protected override void OnUltimo()
        {
            int int_indice = FrmParent.gridControl.MasterView.Rows.Count - 1;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[int_indice];
            CargaDetalle();
        }

        protected override void OnDarBaja()
        {
            MostrarDarBaja();
            //bool respuesta = Util.ShowQuestion("¿Desea dar de baja el documento?");
            //if (respuesta == true)
            //{
             
            //}
        }
        protected override void OnGenerarFE()
        {
            try
            {
                string str_mensaje = ""; int int_flag = 0;
                string str_mensajeError = "";
                bool respuesta = Util.ShowQuestion("¿Desea Generar el Documento Electronico?");
                
                if (respuesta == true)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    DocumentoLogic.Instance.GenerarFacturaElectronica(Logueo.CodigoEmpresa, txttipdoc.Text.Trim(),
                    txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), out int_flag, out str_mensaje);
                    
                    //Esperar 1 segundos para validar tabla errore
                    System.Threading.Thread.Sleep(2000);

                    // Verirficar que no hay habido error en 
                    if (int_flag == 1)
                    {
                        DocumentoLogic.Instance.Spu_Fac_Trae_ErrorLocalFE(txttipdoc.Text.Trim(), txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), out str_mensajeError);

                        if (str_mensajeError != "")
                        {
                            Util.ShowMessage(str_mensajeError, -1);
                        }

                        else
                        {
                            Util.ShowMessage(str_mensaje, int_flag);
                        }
                    }
                    else
                    {
                        Util.ShowMessage(str_mensaje, int_flag);
                    }

                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            
        }
        protected override void OnVerFE()
        {
            string str_result, str_pdfWebPath;
            str_result = ""; str_pdfWebPath = "";
            try
            {
                DocumentoLogic.Instance.TraeFacturaElectronicaOnline(Logueo.CodigoEmpresa, "6", Logueo.RucEmpresa, 
                txttipdoc.Text.Trim(),txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim(), out str_pdfWebPath);

                if (str_pdfWebPath == "")
                {
                    Util.ShowAlert("Documento no disponible, Vuelva  Intentarlo");
                }
                else
                {
                    System.Diagnostics.Process.Start(str_pdfWebPath);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string codigoTipoDocumento = "";
                string numeroDocumento = "";

                codigoTipoDocumento = tipoDocumento;

                numeroDocumento = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();

                DataTable datosFactura = new DataTable();
                datosFactura = VentaDocumentoLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa, codigoTipoDocumento, numeroDocumento);

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
                if (codigoTipoDocumento == "07")
                {
                    reporte.Nombre = "RptNotaCredito.rpt";
                }
                else if (codigoTipoDocumento == "08")
                {
                    reporte.Nombre = "RptNotaDebito.rpt";
                }
             
                reporte.DataSource = datosFactura;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnGenerarPDF()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string codigoTipoDocumento = "";
                string numeroDocumento = "";

                codigoTipoDocumento = tipoDocumento;

                numeroDocumento = txtserie.Text + "-" +
                                  txtNumeroDocumento.Text;

                DataTable datosFactura = new DataTable();
                datosFactura = VentaDocumentoLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa, codigoTipoDocumento, numeroDocumento);

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

                if (codigoTipoDocumento == "07")
                {
                    reporte.Nombre = "RptNotaCredito.rpt";
                }
                else if (codigoTipoDocumento == "08")
                {
                    reporte.Nombre = "RptNotaDebito.rpt";
                }
                if (datosFactura.Rows.Count == 0)
                {
                    Util.ShowAlert("No tiene registro el documento seleccionado");
                    return;
                }
                reporte.DataSource = datosFactura;

                ReporteControladora control = new ReporteControladora(reporte);

                control.VistaPDF(enmWindowState.Normal,numeroDocumento);
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        #endregion
        #region "Eventos Generales"
        private void frmCabNotCredYDeb_Load(object sender, EventArgs e)
        {            
            

            CrearColumnas();

            if (FrmParent.EstadoDocumento == BaseTipoDocumento.enmNotaCredito)
            {
                this.Text = "DETALLE DE NOTA DE CREDITO";
            }
            else if (FrmParent.EstadoDocumento == BaseTipoDocumento.enmNotaDebito)
            {
                this.Text = "DETALLE DE NOTA DE DEBITO";
            }

            Estado = FrmParent.Estado;
            if (Estado == FormEstate.New)
            {
                IniciarControles();
                txtNumeroDocumento.Enabled = true;
				ResaltarControlesAyuda(true);
                VerBotonesCabGuardar();
                OcultarBotonesDelDetalle();
            }
            else if (Estado == FormEstate.Edit)
            {
                //EditarControles();
				ResaltarControlesAyuda(false);
                CargaDetalle();
                traersubdetalle();
                ActivarModoVer();
				//VerBotonesCabGuardar();
                VerBotonesCabVer();
                //OcultarBotonesDelDetalle();
                VerBotonesDelDetalle();
            }
            else if (Estado == FormEstate.View)
            {
                CargaDetalle();
                traersubdetalle();
                ActivarModoVer();				
                //VerBotonesDelDetalle();
                OcultarBotonesDelDetalle();
                ComportarmientoBotones("ver");
            }
            
        }
        #endregion
        #region "Metodos de Grilla"
        private void AgregarFila()
        {
            GridViewRowInfo fila;
            try
            {
                

                if (this.gridControl.Rows.Count > 0)
                {
                    if (gridControl.CurrentRow.Cells["flag"].Value != null)
                    {
                        Util.ShowAlert("Debe completar el registro actual");
                        return;
                    }
                }

                //Agregar fila y asignar valores por defecto.
                gridControl.Rows.AddNew();

                //seleccionar al fila agregado
                fila = this.gridControl.CurrentRow;

                Util.SetValueCurrentCellText(fila, "FAC05CODEMP", Logueo.CodigoEmpresa);
                Util.SetValueCurrentCellText(fila, "FAC04NUMDOC", txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim());
                Util.SetValueCurrentCellText(fila, "FAC01COD", txttipdoc.Text.Trim());

                Util.SetValueCurrentCellText(fila, "FAC05CODPROD", "");
                Util.SetValueCurrentCellText(fila, "FAC05DESCPROD", "");
                Util.SetValueCurrentCellText(fila, "FAC05UNIMED", "");
                Util.SetValueCurrentCellDbl(fila, "FAC05PRECIO", 0);
                Util.SetValueCurrentCellText(fila, "FAC05FEIGVTASA", txtigvPorcen.Text);

                Util.SetValueCurrentCellText(fila, "flag", "0");
                Util.SetValueCurrentCellText(fila, "flagBotones", "E");

                #region "Configurar la nueva fila segun el codigo de plantilla"

                if (txtcodplantilla.Text == "01")
                {
                    Util.ShowAlert("No Existe Plantilla Especial Para Nota de Credito/Debito");
                    return;
                }
                else if (txtcodplantilla.Text == "02")
                {
                    Util.SetValueCurrentCellDbl(fila, "FAC05CANTIDAD", 0);                                        
                }
                else if (txtcodplantilla.Text == "03") // otros servicios
                {
                    // No editar el campo cantidad ni unidad
                    //Bloquear celdas
                    fila.Cells["FAC05CANTIDAD"].ReadOnly = true;
                    fila.Cells["FAC05UNIMED"].ReadOnly = true;
                    
                    Util.SetValueCurrentCellDbl(fila, "FAC05CANTIDAD", 1);
                }

                this.gridControl.Focus();

                Util.ResaltarAyuda(this.gridControl, "FAC05CODPROD");                
                Util.SetCellInitEdit(fila, "FAC05CODPROD");

                
                #endregion
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila:" +ex.Message);
            }


          
        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {           
            AgregarFila();
        }

        private void dtpFechaDoc_Leave(object sender, EventArgs e)
        {
            //double TipoCambo;
            ////Validar si la fecha es valida
            //if (dtpFechaDoc.Text != "")
            //{
            //    GlobalLogic.Instance.TipoCambioTraer(dtpFechaDoc.Text, out TipoCambo);
            //    txtTipoCambio.Text = TipoCambo.ToString();
            //}
            //else
            //{
            //    Util.ShowAlert("Fecha No Valida");
            //    dtpFechaDoc.Focus();
            //}
        }
        protected override void OnEliminar()
        {
            try
            {
                if (txtserie.Text.Trim() == "")
                {
                    Util.ShowAlert("serie No Valida");
                    return;
                }

                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    Util.ShowAlert("Numero de documento no valido");
                    return;
                }

                bool res = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (res == true)
                {

                    int int_flag = 0; string str_mensaje = "";

                    DocumentoFA doc = new DocumentoFA();
                    doc.FAC04CODEMP = Logueo.CodigoEmpresa;
                    doc.FAC01COD = txttipdoc.Text.Trim();
                    doc.FAC04NUMDOC = txtserie.Text.Trim() + "-" + txtNumeroDocumento.Text.Trim();

                    Cursor.Current = Cursors.WaitCursor;

                    DocumentoLogic.Instance.Spu_Fact_Del_FAC04_CABFACTURA(doc, out int_flag, out str_mensaje);

                    Util.ShowMessage(str_mensaje, int_flag);
                    if (int_flag == 1)
                    {
                        if (FrmParent != null)
                        {
                            // 1.Refrescar la grilla de lista de facturas    
                            FrmParent.Cargar();
                            // 2.Cerrar el formulario
                            this.Close();
                        }
                        else if (FrmParent == null)
                        {
                            this.Close();
                        }
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        void tbElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Util.IsCurrentColumn(gridControl.CurrentColumn, "FAC05CODPROD"))
            {
                if (e.KeyChar != (char)Keys.F1)
                {
                    e.Handled = true;
                }
            }
        }

        bool tbSubscribed = false;
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

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                //Caso cuando presiona Cancelar         // refrescar grilla y no ResatalEstiloCelda
                //Caso cuando presiona EliminarDetalle // ResaltarEstiloCelda (anterior)

                //Caseo cuando presioan nuevo  // ResaltarEstiloCelda(seleccionado)
                //Caso cuando presioan editar //  ResaltarEstiloCelda(seleccionado)

                if (gridControl.Rows.Count == 0) return;
                
                if(Util.GetCurrentCellText(gridControl.CurrentRow, "flag") == "")
                {
                    return;
                }
                if (e.CurrentRow != null)
                {
                    Util.ResaltarAyuda(gridControl, e.CurrentRow.Index, "FAC05CODPROD");

                }
                 if (e.OldRow != null)
                 {
                     Util.ResetearAyuda(gridControl, e.OldRow.Index, "FAC05CODPROD");
                 }
              

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }

        }

        private void gridControl_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (_gridEditor != null)
            {
                RadItem editorElement = _gridEditor.EditorElement as RadItem;
                editorElement.KeyDown -= gridControl_KeyDown;
            }
            _gridEditor = null;
        }                
    }
}
