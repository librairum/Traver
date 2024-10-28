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
    public partial class FrmTipoDocumento : frmBaseMante
    {
        private bool isLoaded = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        public FrmTipoDocumento()
        {
             
            InitializeComponent();
            Crearcolumnas();
            //habilito botones nuevo ,editar,eliminar deshabilito guardar cancelar
            //habilitarBotones(true, false);
            HabilitarBotones(true, true, true, false, false, false);

            //gestionarBotones(true, true, true, false, false, false);
        }
        private frmMDI FrmParent { get; set; }
        private static FrmTipoDocumento _aForm;
        public static FrmTipoDocumento Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmTipoDocumento(mdiPrincipal);
            _aForm = new FrmTipoDocumento(mdiPrincipal);
            return _aForm;
        }
        private void Ctrl_Up(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);
        }
        public FrmTipoDocumento(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGuardar = menu.Items["cbbGuardar"];
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            Habilitar(true);
            Limpiar();
            this.txtcodigo.Focus();
            //deshabilito botones nuevo ,editar,eliminar habilito guardar cancelar
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false,true);
        }
        protected override void OnCancelar()
        {
            Habilitar(false);
            //habilito botones nuevo ,editar,eliminar deshabilito guardar cancelar
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);            
        }
        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            Habilitar(true);
            //Deshabilito los valores que no se pueden modificar
            txtcodigo.Enabled = false;
            //deshabilito botones nuevo ,editar,eliminar habilito guardar cancelar
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false,true);
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
        protected override void OnEliminar()
        {
            if (this.gridControl.RowCount == 0)
                return;

            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", 
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, 
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    string codigotipodocumento = string.Empty;
                    codigotipodocumento = this.gridControl.CurrentRow.Cells["In12tipDoc"].Value.ToString();

                    TipoDocumento tipodocumento = new TipoDocumento();
                    tipodocumento.in12codemp = Logueo.CodigoEmpresa;
                    tipodocumento.In12tipDoc = codigotipodocumento;
                    tipodocumento.in12WorStr = OnCargarOpciones(); // Por Mientras


                    TipoDocumentoLogic.Instance.TipoDocumentoEliminar(tipodocumento, out msgRetorno);
                    RadMessageBox.Show(msgRetorno, 
                        Constantes.MensajesGenericos.MSG_TITULO_INFO, 
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                    enfocaRegistroAnterior();
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, 
                    Constantes.MensajesGenericos.MSG_TITULO_ERROR, 
                    MessageBoxButtons.OK, RadMessageIcon.Info);
            }

            OnCancelar();
        }
        private string OnCargarOpciones() {
            string cCadena = "";
            cCadena += (chkopcion1.CheckState == CheckState.Checked) ? "1" : "0"; // proveedor
            cCadena += (chkopcion2.CheckState == CheckState.Checked) ? "1" : "0"; //Centro costo
            cCadena += (chkopcion3.CheckState == CheckState.Checked) ? "1" : "0"; //Responsable de almacen
            cCadena += (chkopcion4.CheckState == CheckState.Checked) ? "1" : "0"; //Responsable de recepcion
            cCadena += (chkopcion5.CheckState == CheckState.Checked) ? "1" : "0"; //Obra
            cCadena += (chkopcion6.CheckState == CheckState.Checked) ? "1" : "0";//Orden de trabajo
            cCadena += (chkopcion7.CheckState == CheckState.Checked) ? "1" : "0";//Maquina
            cCadena += (chkopcion8.CheckState == CheckState.Checked) ? "1" : "0"; //materia prima
            cCadena += (chkopcion9.CheckState == CheckState.Checked) ? "1" : "0"; // lote 
            cCadena += (chkopcion10.CheckState == CheckState.Checked) ? "1" : "0"; // cantera
            cCadena += (chkopcion11.CheckState == CheckState.Checked) ? "1" : "0"; //contratista
            cCadena += (chkopcion12.CheckState == CheckState.Checked) ? "1" : "0"; // nota salida
            cCadena += (chkopcion13.CheckState == CheckState.Checked) ? "1" : "0"; //Comprobante Salida Almacen
            cCadena += (chkopcion14.CheckState == CheckState.Checked) ? "1" : "0"; // Linea
            cCadena += (chkopcion15.CheckState == CheckState.Checked) ? "1" : "0"; // Proceso
            cCadena += (chkopcion16.CheckState == CheckState.Checked) ? "1" : "0"; // Turno
            cCadena += (chkopcion17.CheckState == CheckState.Checked) ? "1" : "0"; //cliente
            return cCadena;
        }
        protected override void OnGuardar()
        {
             
            if (!Validar())
                return;
            TipoDocumento tipodocumento = new TipoDocumento();
            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
            string tipomovimiento = string.Empty;
            try
            {

                if (rbtingreso.CheckState==CheckState.Checked)
                {
                    tipomovimiento="E";
                }
                else
                {
                    tipomovimiento="S";
                }
                
               
                tipodocumento.in12codemp = Logueo.CodigoEmpresa;
                tipodocumento.In12tipDoc = txtcodigo.Text;
                tipodocumento.In12DesLar = txtdescripcion.Text;
                tipodocumento.in12TipMov = tipomovimiento;                
                tipodocumento.In12ExigeDevu = (chkExigeDev.CheckState == CheckState.Checked) ? "1" : "0";
                tipodocumento.in12FlagGeneraDocNum = (chkmanual.CheckState == CheckState.Checked) ? "M" : "A";    
                tipodocumento.in12WorStr = OnCargarOpciones(); // Por Mientras
                tipodocumento.in12naturaleza = this.txtCodigoNaturaleza.Text.Trim();
//                tipodocumento.in12ca
                int cantidadCaracteres = 0;
                if (txtlongitud.Text.Trim() != "") {
                    cantidadCaracteres = Convert.ToInt32(txtlongitud.Text);
                }
                
                tipodocumento.in12longitudDocNum = cantidadCaracteres;
                tipodocumento.in12FlagGeneraAsientoContable = chkAsientoContable.CheckState == CheckState.Checked ? "S": "N";
                tipodocumento.in12FlagCalCostoPromedio = chkCalculaCosto.CheckState == CheckState.Checked ? "S" : "N";


                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    TipoDocumentoLogic.Instance.TipoDocumentoInsertar(tipodocumento, out mensajeRetorno);

                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    Habilitar(false);
                    
                }
                else if (this.Estado == FormEstate.Edit)
                {
                    //Modificar
                    TipoDocumentoLogic.Instance.TipoDocumentoModificar(tipodocumento, out mensajeRetorno);

                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    Habilitar(false);
                    
                }
                else
                {
                    RadMessageBox.Show("Opcion no validad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

            }
            catch (Exception)
            {

                RadMessageBox.Show("Ha ocurrido error inesperado al registrar ", "Aviso",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            OnCancelar();
            if (Estado == FormEstate.New) {
                this.OnEnfocarRegistro(true, gridControl, tipodocumento.In12tipDoc, "In12tipDoc");
                cbbNuevo.IsMouseOver = true;
                cbbNuevo.Focus();
            }
            else if (Estado == FormEstate.Edit) {
                this.OnEnfocarRegistro(false, gridControl, tipodocumento.In12tipDoc, "In12tipDoc");
            }
            this.Estado = FormEstate.List;
       
        }
        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            
            if (this.txtcodigo.Text.Trim() == "")
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }

            if (this.txtdescripcion.Text.Trim() == "")
            {
                RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcion.Focus();
                return false;
            }

            if (this.txtCodigoNaturaleza.Text.Trim() == "" || this.txtDescripcionNaturaleza.Text.Trim() == "???") {
                RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtCodigoNaturaleza.Focus();
                return false;
            }
          
            return true;
        }
        #region metodosdemantenimineto

        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            this.txtcodigo.Enabled = valor;
            this.txtdescripcion.Enabled = valor;
            this.rbtingreso.Enabled = valor;
            this.rbtsalida.Enabled = valor;
            this.radGroupBox3.Enabled = valor;
            this.chkExigeDev.Enabled = valor;
            this.txtCodigoNaturaleza.Enabled = valor;
            this.txtlongitud.Enabled = valor;
            this.chkAsientoContable.Enabled = valor;
            this.chkCalculaCosto.Enabled = valor;
        }

        public void Limpiar()
        {
            this.txtcodigo.Text = "";
            this.txtdescripcion.Text = "";
            this.txtCodigoNaturaleza.Text = "";
            this.rbtingreso.CheckState = CheckState.Checked;
            this.txtlongitud.Text = "";
            this.chkCalculaCosto.CheckState = CheckState.Unchecked;
            this.chkExigeDev.CheckState = CheckState.Unchecked;
            this.chkAsientoContable.CheckState = CheckState.Unchecked;

            LimpiarOpciones();
            
        }
        private void LimpiarOpciones() {
            foreach (Control c in this.radGroupBox3.Controls) {
                if (c is RadCheckBox) {
                    ((RadCheckBox)c).Checked = false;
                }
            }
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
                this.txtcodigo.Text = tipodocumento.In12tipDoc;
                this.txtdescripcion.Text = tipodocumento.In12DesLar;
                this.txtCodigoNaturaleza.Text = tipodocumento.in12naturaleza;
                this.txtlongitud.Text = tipodocumento.in12longitudDocNum.ToString().Trim();
                if (tipodocumento.in12TipMov == "E")
                {
                    rbtingreso.CheckState = CheckState.Checked;
                }
                else
                {
                    rbtsalida.CheckState = CheckState.Checked;
                }

                if (tipodocumento.In12ExigeDevu == "1")
                {
                    chkExigeDev.CheckState = CheckState.Checked;
                }
                else {
                    chkExigeDev.CheckState = CheckState.Unchecked;
                }
                if (tipodocumento.in12FlagGeneraDocNum == "M")
                {
                    chkmanual.CheckState = CheckState.Checked;
                }
                else
                {
                    chkmanual.CheckState = CheckState.Unchecked;
                }

                if (tipodocumento.in12FlagCalCostoPromedio == "S")
                {
                    chkCalculaCosto.CheckState = CheckState.Checked;
                }
                else {
                    chkCalculaCosto.CheckState = CheckState.Unchecked;
                }

                if (tipodocumento.in12FlagGeneraAsientoContable == "S")
                {
                    chkAsientoContable.CheckState = CheckState.Checked;
                }
                else {
                    chkAsientoContable.CheckState = CheckState.Unchecked;
                }

                string miCadena = TipoDocumentoLogic.Instance.DameVariable(Logueo.CodigoEmpresa,tipodocumento.In12tipDoc);

                //proveedor
                chkopcion1.CheckState = (LeerEstado(miCadena, 0) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //centro de costo
                chkopcion2.CheckState = (LeerEstado(miCadena, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //responsable de almacen
                chkopcion3.CheckState = (LeerEstado(miCadena, 2) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //responsable de recepcion
                chkopcion4.CheckState = (LeerEstado(miCadena, 3) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible -> obra
                chkopcion5.CheckState = (LeerEstado(miCadena, 4) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //disponible -> orden de compra / orde de trabajo
                chkopcion6.CheckState = (LeerEstado(miCadena, 5) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //Maquina
                chkopcion7.CheckState = (LeerEstado(miCadena, 6) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //materia prima
                chkopcion8.CheckState = (LeerEstado(miCadena, 7) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //Lote
                chkopcion9.CheckState = (LeerEstado(miCadena, 8) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //Cantera
                chkopcion10.CheckState = (LeerEstado(miCadena, 9) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //Contratista
                chkopcion11.CheckState = (LeerEstado(miCadena, 10) == "1") ? CheckState.Checked : CheckState.Unchecked;

                //Nota Salida
                chkopcion12.CheckState = (LeerEstado(miCadena, 11) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //Comprobante salida almacen.
                chkopcion13.CheckState = (LeerEstado(miCadena, 12) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //linea
                chkopcion14.CheckState = (LeerEstado(miCadena, 13) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //proceso
                chkopcion15.CheckState = (LeerEstado(miCadena, 14) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //turno                
                chkopcion16.CheckState = (LeerEstado(miCadena, 15) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //chkopcion16.CheckState = (miCadena.Substring(15, 1) == "1") ? CheckState.Checked : CheckState.Unchecked;
                //cliente
                chkopcion17.CheckState = (LeerEstado(miCadena, 16) == "1") ? CheckState.Checked : CheckState.Unchecked;


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
            RadGridView grilla =  this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(this.gridControl, "Codigo", "In12tipDoc", 0, "", 50, true, false, true);
            this.CreateGridColumn(this.gridControl, "Descripcion", "In12DesLar", 0, "", 350, true, false, true);
       

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
        private void FrmTipoDocumento_Load(object sender, EventArgs e)
        {
            OnBuscar();
            //Capturo el primer registro valido 
            CargarRegistro();
            isLoaded = true;
            //habilito botones nuevo ,editar,eliminar deshabilito guardar cancelar
            //this.cargarPermisos(this.Name);
            HabilitarBotones(true, true, true, false, false, false);
            //habilitarBotones(true, false);
            //desactivo controles 
            Habilitar(false);
        }
        private void obtenerDescripcion(enmAyuda tipoAyuda, string codigo) {
            try
            {
                string descripcion = string.Empty;
                switch (tipoAyuda) 
                {
                    case enmAyuda.enmNaturaleza:
                        this.txtDescripcionNaturaleza.Text = "";
                        if (!string.IsNullOrEmpty(codigo)) {
                            GlobalLogic.Instance.DameDescripcion(this.txtCodigoNaturaleza.Text.Trim(),
                                                                        "NATURALEZA", out descripcion);
                        }
                        this.txtDescripcionNaturaleza.Text = descripcion;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { 
            
            }
        }
        private void mostrarAyuda(enmAyuda tipoAyuda) {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda) 
            {
                case enmAyuda.enmNaturaleza:
                    frm = new frmBusqueda(enmAyuda.enmNaturaleza);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    this.txtCodigoNaturaleza.Text = codigoSeleccionado;
                    break;
                default:
                    break;
            }
        }
        private void txtCodigoNaturaleza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1) {
                mostrarAyuda(enmAyuda.enmNaturaleza);
            }
        }
        private void txtCodigoNaturaleza_TextChanged(object sender, EventArgs e)
        {
            obtenerDescripcion(enmAyuda.enmNaturaleza, this.txtCodigoNaturaleza.Text.Trim());
        }

        private void txtlongitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

    }
}
