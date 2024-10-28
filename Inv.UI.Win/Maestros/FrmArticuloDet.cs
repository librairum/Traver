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
    public partial class FrmArticuloDet : frmBaseReg
    {
        private bool isLoaded = false;
        private bool isOpened = false;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        
        public string _ArticuloCodigo = string.Empty;
        private string _NomAlmacen = string.Empty;
        int estadoGrilla=0;
        public  int pos = 0; 
        public RadGridView _grid;
        private FrmArticuloLista frmParent { get; set; }
        private static FrmArticuloDet _aForm;
        
        public static FrmArticuloDet Instance(FrmArticuloLista mdiPrincipal)
        {
            if (_aForm != null) return new FrmArticuloDet(mdiPrincipal);
            _aForm = new FrmArticuloDet(mdiPrincipal);
            return _aForm;
        }

        #region "Metodos de ArticuloPorAlmacen"
        void enfocarregistro()
        {
            FrmArticuloLista.formulario.gridControl.MasterView.Rows[pos].IsCurrent = true;
            FrmArticuloLista.formulario.gridControl.MasterView.Rows[pos].IsSelected = true;
            //FrmArticuloLista.Instancia().gridControl.MasterView.Rows[pos].IsCurrent = true;
            //FrmArticuloLista.Instancia().gridControl.MasterView.Rows[pos].IsSelected = true;
        }

        private void AgregarAlmacen() {
            try 
            {                               
              this.MostrarAyuda(enmAyuda.enmAlmacenTodos);                
            }
            catch (Exception ex) {                            
            }                        
        }
        void asignarValores()
        {
            //asigno los valores de la fila actual seleccionado
            txtcodigo.Text = _grid.MasterView.Rows[pos].Cells["IN01KEY"].Value.ToString();
            _ArticuloCodigo = txtcodigo.Text;
            CargarDocumento();
            this.CargarAlmacenes();
            OnBuscarEquivalencias();
            //resalto el registro actual
            enfocarregistro();
        }
        private bool validarAlmacenes() {
            var grilla = gridControlAlmacen.CurrentRow;
            if (grilla.Cells[0].Value == null) {
                mensajeAviso("Completar registro");
                return false;
            }
            if (grilla.Cells[1].Value == null)
            {
                mensajeAviso("Completar registro");
                return false;
            }
            return true;
        }
        private void EliminarAlmacen() { 
            /*articuloporalmacen.IN04CODEMP, articuloporalmacen.IN04AA,
             * articuloporalmacen.IN04KEY, articuloporalmacen.IN04CODALM, out @cMsgRetorno);*/
            if (this.gridControlAlmacen.Rows.Count != 0) {
                string msj = string.Empty;
                ArticuloPorAlmacen entidad = new ArticuloPorAlmacen();

                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    entidad.IN04CODEMP = Logueo.CodigoEmpresa;
                    entidad.IN04AA = Logueo.Anio;
                    entidad.IN04KEY = txtcodigo.Text;
                    entidad.IN04CODALM = (string)gridControlAlmacen.CurrentRow.Cells[0].Value;
                    ArticuloPorAlmacenLogic.Instance.ArticuloPorAlmacenEliminar(entidad, out msj);
                    RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                CargarAlmacenes();
                
            }
           
        }
        private void GuardarAlmacen() {
            string fechaini = "";
            string mensajeRetorno1 = string.Empty;
            try {
                if (this.gridControlAlmacen.RowCount > 0)
                {
                    if (!string.IsNullOrEmpty(this.gridControlAlmacen.CurrentRow.Cells[0].Value.ToString())) {
                        ArticuloPorAlmacen articuloporalmacen = new ArticuloPorAlmacen();
                        articuloporalmacen.IN04CODEMP = Logueo.CodigoEmpresa;
                        articuloporalmacen.IN04AA = Logueo.Anio;
                        articuloporalmacen.IN04KEY = txtcodigo.Text;
                        /*por defecto es el 06 para mostrar el nombre se lista junto con la tabla de almacenes in09alma 
                         que contine el codigo y descripcion  - ubicacion 
                         */
                        /*linea original de ocodigo */

                        articuloporalmacen.IN04CODALM = Logueo.PT_AlmxDefecto; // Almacen por defecto                      
                        /*linea original de ocodigo */
                        articuloporalmacen.IN04UBICAC = "";
                        articuloporalmacen.IN04STOMIN = 0;
                        articuloporalmacen.IN04STOSEG = 0;
                        articuloporalmacen.IN04STOMAX = 0;
                        articuloporalmacen.IN04STOREP = 0;
                        articuloporalmacen.IN04STOCKINICIALMES = 0;
                        articuloporalmacen.IN04PROMDOL = 0;
                        articuloporalmacen.IN04PROMDOL = 0;
                        articuloporalmacen.IN04PROMSOL = 0;
                        articuloporalmacen.IN04PROMSOL = 0;

                        fechaini = DateTime.Now.ToString("dd/MM/yyyy");
                        articuloporalmacen.IN04CODALM = this.gridControlAlmacen.CurrentRow.Cells[0].Value.ToString();
                        ArticuloPorAlmacenLogic.Instance.ArticuloPorAlmacenInsertar(articuloporalmacen, fechaini, out mensajeRetorno1);
                        RadMessageBox.Show(mensajeRetorno1, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                   
                }
            }
            catch (Exception ex) { 
            
            }


            CargarAlmacenes();
            this.gridControlAlmacen.AllowEditRow = false;
        }
        private void CancelarAlmacen() {
            this.gridControlAlmacen.AllowEditRow = false;
            CargarAlmacenes();   
        }
            
        #endregion

      
            protected override void  OnPrimero()
            {
                pos = 0;
                asignarValores(); 
            }            
            protected override void OnSiguiente()
            {
                if (pos == _grid.RowCount - 1 || pos == _grid.ChildRows.Count - 1)
                    return;
                pos++;
                asignarValores();
            }
            protected override void OnAnterior()
            {
                
                if (pos == 0)
                    return;
                pos--;
                asignarValores();      
            }
            protected override void OnUltimo()
            {
                pos = _grid.MasterView.Rows.Count - 1;
                asignarValores();   
            }

            /*Constructor del  formulario detalle de Articulo*/
        
            public FrmArticuloDet(FrmArticuloLista padre)
            {
                InitializeComponent();
                frmParent = padre;
                CrearColumnas();
                crearColumnasEquivalencia();
                txttipo.Focus();
                menu = this.radCommandBar1.CommandBarElement.Rows[0].Strips[0];
                cbbGuardar = menu.Items["cbbGuardar"];
            }


        private void FrmArticuloDet_Load(object sender, EventArgs e)
        {
            double CanMovimientos = 0;
            
        if (this.Estado == FormEstate.New)
            {
                InicializarNuevo();
                this.HabilitarRadBar(ElementVisibility.Visible, ElementVisibility.Collapsed);
                
            }
            else if(this.Estado == FormEstate.Edit)
            {
                crearColumnasEquivalencia();
                ArticuloLogic.Instance.TraerMovimientoxArticulo(Logueo.CodigoEmpresa, Logueo.Anio, _ArticuloCodigo, out CanMovimientos);

                isLoaded = true;
                CargarDocumento();
                this.CargarAlmacenes();                
                OnBuscarEquivalencias();                
                Deshabilitarkeyarticulo();
                Habilitar(false);
                rbtareaformato.Enabled = true;
                rbtareamodelo.Enabled = true;
                optptactivo.Enabled = true;
                optptinactivo.Enabled = true;
                this.HabilitarBotones(true, true, true, true, false);

                txtunimed.Enabled = CanMovimientos == 0 ? true : false;                          
            }
            else if (this.Estado == FormEstate.View) {
                isLoaded = true;
                CargarDocumento();
                this.CargarAlmacenes();
                
                OnBuscarEquivalencias();
                Habilitar(false);
                this.HabilitarBotones(false, true, false, false, true);                
                Deshabilitarkeyarticulo();
                rbtareaformato.Enabled = false;
                rbtareamodelo.Enabled = false;
                optptactivo.Enabled = false;
                optptinactivo.Enabled = false;
                //barra de agregar,eliminar de Almacen o Equivalencia de producto
                BarAddDel_Almacen.Enabled = false;
                //barra de Nuevo y eliminar de Almacen o Equivalencia de producto
                cmdBarDetalleProducto.Enabled = false;
            }
           
            isLoaded = true;
            
        }
        private void frmArticuloDet_Activated(object sender, EventArgs e)
        {
            //Ubica el mouse en TextBox Tipo de documento
            if (this.Estado == FormEstate.New && !isOpened)
            {
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
                //SendKeys.Send("{TAB}");
            }
            
            isOpened = true;
        }
        /*crea columnas de la grilal de almacen*/
        private void CrearColumnas()
        {
            RadGridView grilla =  this.CreateGridVista(this.gridControlAlmacen);
            
            this.CreateGridColumn(grilla, "Codigo", "In04CodAlm", 0, "", 50, false, true, true);
            this.CreateGridColumn(grilla, "Descripcion", "In09Descripcion", 0, "", 250, false, true, true);
            
            //this.gridControl.DefaultValuesNeeded += new GridViewRowEventHandler(gridControl_DefaultValuesNeeded);
        }
      
        private void CargarAlmacenes()
        {
            try
            {
                var Almacenes = ArticuloLogic.Instance.TraerAlmacenxArticulo(Logueo.CodigoEmpresa, Logueo.Anio, 
                    Logueo.Mes, this.txtcodigo.Text, "*");
                this.gridControlAlmacen.DataSource = Almacenes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        void cargaRegistro(string xcodigoArt){
           _ArticuloCodigo = xcodigoArt;
           var articulo = ArticuloLogic.Instance.ArticuloTraerRegistro(Logueo.CodigoEmpresa, Logueo.Anio, xcodigoArt);
           if (articulo != null)
            {
                this.txtcodigo.Text = articulo.IN01KEY;
                this.txtdescripcion.Text = articulo.IN01DESLAR;
                this.txtunimed.Text = articulo.IN01UNIMED;
                if (articulo.IN01FLAGTIPCALAREA=="M") {
                    this.rbtareamodelo.CheckState = CheckState.Checked;}
                else {this.rbtareaformato.CheckState=CheckState.Checked;}

                if (articulo.IN01ESTADO== "A")
                {
                    this.optptactivo.CheckState = CheckState.Checked;
                }
                else { this.optptinactivo.CheckState = CheckState.Checked; }

                // Caracteristicas del articulo
                this.txttipo.Text = articulo.tipo;
                this.txtcolor.Text = articulo.color;
                this.txttonalidad.Text = articulo.tonalidad;
                this.txtformato.Text = articulo.formato;
                this.txtacabado.Text = articulo.acabado;
                this.txtrelleno.Text = articulo.relleno;
                this.txtborde.Text = articulo.borde;
                this.txtcalidad.Text = articulo.calidad;
                this.txtmodelo.Text = articulo.modelo;
                this.CargarAlmacenes();
                OnBuscarEquivalencias();
            }
       }
        private void InicializarNuevo()
        {
           // HabyDesControles(this, false);
           // LimpiarControles(this);
            Habilitar(true);
            Limpiar();
            estadoGrilla = 0;
            
        }
        //metod parea cargar la grilla del detalle de un  producto seleccionado.
        private void CargarDocumento()
        {
            //BloquearIngresoDatos();
            //Carga el documento y su detalle

            var articulo = ArticuloLogic.Instance.ArticuloTraerRegistro(Logueo.CodigoEmpresa, Logueo.Anio, _ArticuloCodigo);
            
            if (articulo != null)
            {
                this.txtcodigo.Text = articulo.IN01KEY;
                this.txtdescripcion.Text = articulo.IN01DESLAR;
                this.txtunimed.Text = articulo.IN01UNIMED;
                if (articulo.IN01FLAGTIPCALAREA=="M") {
                    this.rbtareamodelo.CheckState = CheckState.Checked;}
                else {this.rbtareaformato.CheckState=CheckState.Checked;}

                if (articulo.IN01ESTADO== "A")
                {
                    this.optptactivo.CheckState = CheckState.Checked;
                }
                else { this.optptinactivo.CheckState = CheckState.Checked; }

                // Caracteristicas del articulo
                this.txttipo.Text = articulo.tipo;
                this.txtcolor.Text = articulo.color;
                this.txttonalidad.Text = articulo.tonalidad;
                this.txtformato.Text = articulo.formato;
                this.txtacabado.Text = articulo.acabado;
                this.txtrelleno.Text = articulo.relleno;
                this.txtborde.Text = articulo.borde;
                this.txtcalidad.Text = articulo.calidad;
                this.txtmodelo.Text = articulo.modelo;
                
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
                    case enmAyuda.enmTipo:
                        this.txthelptipo.Text = string.Empty;
                        

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "01" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelptipo.Text = descripcion;
                       }
                        break;
                    case enmAyuda.enmColor:
                        this.txthelpcolor.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "02" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelpcolor.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmTonalidad:
                        this.txthelptonalidad.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "03" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelptonalidad.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmFormato:
                        this.txthelpformato.Text = string.Empty;
                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "11" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelpformato.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmAcabado:
                        this.txthelpacabado.Text = string.Empty;
                        codigo = "07" + codigo;

                        string codigoCliente = string.Empty;
                        GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out codigoCliente);
                        if (codigoCliente.CompareTo("???") != 0)
                            this.txthelpacabado.Text = codigoCliente;

                        break;
                    case enmAyuda.enmRelleno:
                        this.txthelprelleno.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "08" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelprelleno.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmBorde:
                        this.txthelpborde.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "09" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelpborde.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmCalidad:
                        this.txthelpcalidad.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "12" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelpcalidad.Text = descripcion;
                        }
                        break;

                    case enmAyuda.enmModelo:
                        this.txthelpmodelo.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = "10" + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "PROTER", out descripcion);
                            this.txthelpmodelo.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmUniMed:
                        this.txthelpunimed.Text = string.Empty;

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "UNIDAD", out descripcion);
                            this.txthelpunimed.Text = descripcion;
                        }
                        break;
                    case enmAyuda.enmAlmacen:
                        
                        if (!string.IsNullOrEmpty(codigo)) {                           
                            codigo = Logueo.CodigoEmpresa + codigo;
                            GlobalLogic.Instance.DameDescripcion(codigo, "ALMACEN", out descripcion);
                            _NomAlmacen = descripcion;
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

        private void txttipo_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmTipo, this.txttipo.Text);
            this.productoterminadoarmarcodigo();
        }

         private void txtcolor_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmColor, this.txtcolor.Text);
            this.productoterminadoarmarcodigo();
        }

        private void txttonalidad_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmTonalidad, this.txttonalidad.Text);
            this.productoterminadoarmarcodigo();
        }

        private void txtformato_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmFormato, this.txtformato.Text);
            this.productoterminadoarmarcodigo();
        }

        private void txtacabado_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmAcabado, this.txtacabado.Text);
            this.productoterminadoarmarcodigo();
        }

        private void txtrelleno_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmRelleno, this.txtrelleno.Text);
            this.productoterminadoarmarcodigo();
        }

        private void txtborde_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmBorde, this.txtborde.Text);
            this.productoterminadoarmarcodigo();
        }


        private void txtmodelo_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmModelo, this.txtmodelo.Text);
            this.productoterminadoarmarcodigo();
        }

        private void txtunimed_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmUniMed, this.txtunimed.Text);
        }
        private void txtcalidad_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmCalidad, this.txtcalidad.Text);
            this.productoterminadoarmarcodigo();
        }

        private void txthelpcalidad_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void btnAddDetalle_Click(object sender, EventArgs e)
        {
            frmDetalleMovi frm = new frmDetalleMovi();
            frm.Estado = FormEstate.New;
            frm.Owner = this;
            frm.ShowDialog();
        }

       
      //}

     //   private void HabyDesControles(Control f, bool valor) {
     //    try {
     //        // Botones de ayuda
     //        foreach (Control ctlControl in f.Controls) {
     //            // Botones
                 
     //            if ((ctlControl is TextBox)) {
     //                ((System.Windows.Forms.TextBox)(ctlControl)).ReadOnly = !valor;
     //            }

     //            //if ((ctlControl.GetType() == Button))
     //            //{
     //            //    // CType(ctlControl, System.Windows.Forms.Button).Enabled = valor
     //            //    if ((((System.Windows.Forms.Button)(ctlControl)).Name.Substring(0, 7).ToString.ToUpper == "btnhelp".ToUpper))
     //            //    {
     //            //        ((System.Windows.Forms.Button)(ctlControl)).Enabled = valor;
     //            //    }
     //            //    // textbox
     //            //}


     //            else if ((ctlControl is CheckBox)) {
     //                ((System.Windows.Forms.CheckBox)(ctlControl)).Enabled = valor;
     //            }
     //            else if ((ctlControl is RadioButton)) {
     //                ((System.Windows.Forms.RadioButton)(ctlControl)).Enabled = valor;
     //                // controles dentro de panel's
     //            }
     //            else if ((ctlControl is MaskedTextBox)) {
     //                ((System.Windows.Forms.MaskedTextBox)(ctlControl)).ReadOnly = !valor;
     //            }
     //            else if ((ctlControl is ComboBox)) {
     //                ((System.Windows.Forms.ComboBox)(ctlControl)).Enabled = valor;
     //                // controles dentro de panel's
     //            }
     //            //else if ((ctlControl is Panel)) {
     //            //    HabyDesControles(((System.Windows.Forms.Panel)(ctlControl)), valor);
     //            //    // controles dentro de Group box
     //            //}
     //            else if ((ctlControl is GroupBox)) {
     //                HabyDesControles(((System.Windows.Forms.GroupBox)(ctlControl)), valor);
     //                // controles dentro de Tab's
     //            }
     //            else if ((ctlControl is TabControl)) {
     //                HabyDesControles(((System.Windows.Forms.TabControl)(ctlControl)), valor);
     //            }
                 
     //                // ==============  Para los controles telerik
     //            else if ((ctlControl is RadPageView))
     //            {
     //                HabyDesControles(((Telerik.WinControls.UI.RadPageView)(ctlControl)), valor);

     //            }
     //            else if ((ctlControl is RadPageViewPage))
     //            {
     //                HabyDesControles(((Telerik.WinControls.UI.RadPageViewPage)(ctlControl)), valor);

     //            }
     //            else if ((ctlControl is RadGroupBox))
     //            {
     //                HabyDesControles(((Telerik.WinControls.UI.RadGroupBox)(ctlControl)), valor);

     //            }
     //            else if ((ctlControl is RadTextBox))
     //            {
     //                ((Telerik.WinControls.UI.RadTextBox)(ctlControl)).ReadOnly = !valor;
     //            }
     //            else if ((ctlControl is RadButton))
     //            {
     //                ((Telerik.WinControls.UI.RadButton)(ctlControl)).Enabled = valor;
     //            }

     //            else if ((ctlControl is RadGridView))
     //            {
     //                ((Telerik.WinControls.UI.RadGridView)(ctlControl)).Enabled = valor;
     //            }
     //        }
     //    }
     //    catch (Exception ex) {
     //        MessageBox.Show(ex.Message);
     //    }
     //}

     //   private void LimpiarControles(Control f) {
     //    try {
     //        // Limpiar 
     //        foreach (Control ctlControl in f.Controls)
     //        {
     //            // Si es texto
     //            if ((ctlControl is TextBox)) {
     //                ((System.Windows.Forms.TextBox)(ctlControl)).Text = "";
     //            }
     //            else if ((ctlControl is ComboBox)) {
     //                ((System.Windows.Forms.ComboBox)(ctlControl)).Text = "";
     //            }
     //            else if ((ctlControl is MaskedTextBox)) {
     //                ((System.Windows.Forms.MaskedTextBox)(ctlControl)).Text = "";
     //            }
     //            else if ((ctlControl is CheckBox)) {
     //                ((System.Windows.Forms.CheckBox)(ctlControl)).Checked = false;
     //            }
     //            else if ((ctlControl is RadioButton)) {
     //                ((System.Windows.Forms.RadioButton)(ctlControl)).Checked = false;
     //            }

     //            //else if ((ctlControl is Label)) {
     //                // Se verificac que es mayor que 7 por que cuando la longitud del nombre del label es menor,sale un error de indice
     //              //  if ((((System.Windows.Forms.Label)(ctlControl)).Name.Length >= 7)) {
     //              //      if ((((System.Windows.Forms.Label)(ctlControl)).Name.Substring(0, 7).ToString.ToUpper == "lblhelp".ToUpper)) {
     //              //          ((System.Windows.Forms.Label)(ctlControl)).Text = "???";
     //              //      }
     //              //  }
     //            //}
     //            else if ((ctlControl is  Panel)) {
     //                LimpiarControles(((System.Windows.Forms.Panel)(ctlControl)));
     //            }
     //            else if ((ctlControl is GroupBox)) {
     //                LimpiarControles(((System.Windows.Forms.GroupBox)(ctlControl)));
     //            }
     //            else if ((ctlControl is TabControl)) {
     //                LimpiarControles(((System.Windows.Forms.TabControl)(ctlControl)));
     //            }
     //        }
     //    }
     //    catch (Exception ex) {
     //        MessageBox.Show(ex.Message);
     //    }
     //}

        private void txttipo_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTipo);
        }

        private void txtcolor_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmColor);
            
        }

        private void txttonalidad_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmTonalidad);
        }

        private void txtformato_KeyDown(object sender, KeyEventArgs e)
        { 
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmFormato);
        }

        private void txtrelleno_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmRelleno);
        }

        private void txtborde_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmBorde);
        }
        private void txtmodelo_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmModelo);
        }
        private void txtacabado_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmAcabado);
        }
        private void txtunimed_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmUniMed);
        }
        private void txtcalidad_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmCalidad);

        }
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda)
            {
                case enmAyuda.enmTipo:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txttipo.Text = codigoSeleccionado;

                    break;
                case enmAyuda.enmColor:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtcolor.Text = codigoSeleccionado;

                    break;
                case enmAyuda.enmTonalidad:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txttonalidad.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmFormato:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtformato.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmAcabado:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtacabado.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmRelleno:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();;

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtrelleno.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmBorde:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtborde.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmCalidad:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtcalidad.Text = codigoSeleccionado;
                    break;

                case enmAyuda.enmModelo:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtmodelo.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmUniMed:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();

                    if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtunimed.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmAlmacen:
                    frm = new frmBusqueda(tipoAyuda, Logueo.PT_codnaturaleza);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();
                     ObtenerDescripcion(enmAyuda.enmAlmacen, codigoSeleccionado);
                    gridControlAlmacen.Rows.AddNew();
                    gridControlAlmacen.CurrentRow.Cells[0].Value = codigoSeleccionado;
                    gridControlAlmacen.CurrentRow.Cells[1].Value = _NomAlmacen;

                    GuardarAlmacen();

                    break;
                case enmAyuda.enmEquivalenciaProducto:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        List<ArticuloCliente> milista_ayuda = (List<ArticuloCliente>)frm.Result;                     
                        var grilla = gridEquivalenciaProxCli.CurrentRow;
                        grilla.Cells[0].Value = milista_ayuda[0].In20clientecod;
                        grilla.Cells[1].Value = milista_ayuda[0].NombreCliente;
                        grilla.Cells[2].Value = milista_ayuda[0].In20Codigo;
                        grilla.Cells[3].Value = milista_ayuda[0].In20Descripcion;
                        grilla.Cells[4].Value = milista_ayuda[0].In20UndxCaja;
                        grilla.Cells[5].Value = milista_ayuda[0].In20PiezasxCaja;
                        string msj = string.Empty;
                        ArticuloClienteLogic.Instance.Actualizar_CodigoPropio(Logueo.CodigoEmpresa, grilla.Cells[0].Value.ToString(), grilla.Cells[2].Value.ToString(),
                            txtcodigo.Text, out msj);
                        RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);

                        OnBuscarEquivalencias();
                    }
                    else {
                        gridEquivalenciaProxCli.Rows.RemoveAt(gridEquivalenciaProxCli.CurrentRow.Index);
                    }
                                              
                    break;
                case enmAyuda.enmAlmacenTodos:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        codigoSeleccionado = frm.Result.ToString().ToUpper();
                        if (!string.IsNullOrEmpty(codigoSeleccionado))
                        {
                            ObtenerDescripcion(enmAyuda.enmAlmacen, codigoSeleccionado);
                            gridControlAlmacen.Rows.AddNew();
                            gridControlAlmacen.CurrentRow.Cells[0].Value = codigoSeleccionado;
                            gridControlAlmacen.CurrentRow.Cells[1].Value = _NomAlmacen;
                            GuardarAlmacen();
                        }

                    }
                    break;
               default:
                    break;
            }
        }

        #region Guardar
        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (this.txtcodigo.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }
            if (txtcolor.Text.Length == 0 || txthelpcolor.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Color", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcolor.Focus();
                return false;
            }
            if (txttonalidad.Text.Length == 0 || txthelptonalidad.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Tonalidad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txttonalidad.Focus();
                return false;
            }
            if (txtformato.Text.Length == 0 || txthelpformato.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Formato", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtformato.Focus();
                return false;
            }
            if (txtacabado.Text.Length == 0 || txtacabado.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Acbado", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtacabado.Focus();
                return false;
            }
            if (txtrelleno.Text.Length == 0 || txthelprelleno.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Relleno", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtrelleno.Focus();
                return false;
            }
            if (txtborde.Text.Length == 0 || txthelpborde.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Borde", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtborde.Focus();
                return false;
            }

            if (txtcalidad.Text.Length == 0 || txthelpcalidad.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Calidad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtcalidad.Focus();
                return false;
            }
            if (txtmodelo.Text.Length == 0 || txthelpmodelo.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Modelo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtmodelo.Focus();
                return false;
            }
            if (this.txtdescripcion.Text.Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Descripcion", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtdescripcion.Focus();
                return false;
            }


            if (this.txtunimed.Enabled)
            {
                if (this.txtunimed.Text.Length == 0 || txthelpunimed.Text.Trim() == "???")
                {
                    RadMessageBox.Show("Debe ingresar Unidad de medida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.txtunimed.Focus();
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
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
            string areapt=string.Empty;
            string estadopt = string.Empty;

            try
            {

                if (rbtareamodelo.CheckState == CheckState.Checked)
                    {areapt ="M";}
                else
                    {areapt = "F";}

                if (optptactivo.CheckState == CheckState.Checked)
                { estadopt = "A"; }
                else
                { estadopt = "B"; }
                
                Articulo articulo = new Articulo();
                articulo.IN01CODEMP= Logueo.CodigoEmpresa;
                articulo.IN01AA= Logueo.Anio;
                articulo.IN01KEY= txtcodigo.Text.ToUpper();
                articulo.IN01DESLAR= txtdescripcion.Text;
                articulo.IN01UNIMED=txtunimed.Text;
                articulo.IN01CODPRO="";
                articulo.IN01MOV="S";
                articulo.IN01UNIDADEQUI=txtunimed.Text ;
                articulo.IN01MONTOEQUI=1;
                articulo.IN01UNIDADMAYOR="N";
                articulo.IN01ESTADO = estadopt;
                articulo.IN01TIPO="T" ; // T de productos terminados
                articulo.IN01FLAGTIPCALAREA = areapt;
                articulo.IN01PRODNATURALEZA = Logueo.PT_codnaturaleza;
                /*-----------------------------------SOLO DETALLE DE ARTICULO (ALMACEN,UNIDADES,STOCK) ----------------------*/
                /*este bloque es para ingresar a la tabla In04Axal donde el articulo se va guardar a cual almacen se asignara*/
                /*esta tabla se ingresa solo datos como codigo y stock entre otros detalles del articulo pero no 
                 la descripion y ubicaion del almacen*/

                ArticuloPorAlmacen articuloporalmacen = new ArticuloPorAlmacen();
                articuloporalmacen.IN04CODEMP=Logueo.CodigoEmpresa;
                articuloporalmacen.IN04AA=Logueo.Anio;
                articuloporalmacen.IN04KEY = txtcodigo.Text.ToUpper();
                /*por defecto es el 06 para mostrar el nombre se lista junto con la tabla de almacenes in09alma 
                 que contine el codigo y descripcion  - ubicacion 
                 */
                /*linea original de ocodigo */
                articuloporalmacen.IN04CODALM = Logueo.PT_AlmxDefecto; // Almacen por defecto                      
                /*linea original de ocodigo */
                articuloporalmacen.IN04UBICAC="";
                articuloporalmacen.IN04STOMIN=0;
                articuloporalmacen.IN04STOSEG=0;
                articuloporalmacen.IN04STOMAX=0;
                articuloporalmacen.IN04STOREP=0;
                articuloporalmacen.IN04STOCKINICIALMES=0;
                articuloporalmacen.IN04PROMDOL=0;
                articuloporalmacen.IN04PROMDOL=0;
                articuloporalmacen.IN04PROMSOL=0;
                articuloporalmacen.IN04PROMSOL=0;
                fechaini = DateTime.Now.ToString("dd/MM/yyyy");
                //
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO

                    /*bloque de codigo añadido para grabar los almacenes asignado sl productos en caso de ser nuevo*/
                    ArticuloLogic.Instance.ArticuloInsertar(articulo,out mensajeRetorno);


                    //INSERTA ALMACEN POR DEFECTO
                    /*bloque original*/
                    ArticuloPorAlmacenLogic.Instance.ArticuloPorAlmacenInsertar(articuloporalmacen, fechaini, out mensajeRetorno1);
                    /*bloque original*/
              /*----------------------------------------SOLO DETALLE DE ARTICULO (ALMACEN,UNIDADES,STOCK) ------------------------*/
                    Habilitar(false);
                    
                    //this.HabyDesControles(this, true);
                    this.Estado = FormEstate.Edit;

                }
                else
                {
                    //MODIFICA
                    ArticuloLogic.Instance.ArticuloModificar(articulo,out mensajeRetorno);

                    /*actualizar los almacenes en loq ue encuentro el articulo*/
                        if (this.gridControlAlmacen.RowCount > 0 ) {
                        for (int j = 0; j < this.gridControlAlmacen.RowCount; j++)
                        {
                            articuloporalmacen.IN04CODALM = (string)this.gridControlAlmacen.Rows[j].Cells[0].Value;
                            ArticuloPorAlmacenLogic.Instance.ArticuloPorAlmacenInsertar(articuloporalmacen, fechaini, out mensajeRetorno1);
                        }
                    }
                    
                }


                RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                CargarAlmacenes();
                //this.Close();
                FrmArticuloLista.formulario.listar();
                
            }
            catch (Exception)
            {

                
                RadMessageBox.Show("Ha ocurrido error inesperado al registrar el documento", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #endregion
        private void productoterminadoarmarcodigo()
        {
            try
            {
                this.txtcodigo.Text = txttipo.Text.Trim() + txtcolor.Text.Trim() + txttonalidad.Text.Trim() + txtformato.Text.Trim() + txtacabado.Text.Trim() + txtrelleno.Text.Trim() + txtborde.Text.Trim() + txtcalidad.Text.Trim() + txtmodelo.Text.Trim();

                var articulo = ArticuloLogic.Instance.ProterDescripcion(txtcodigo.Text);

                if (articulo != null)
                {
                    this.txtdescripcion.Text = articulo.IN01DESLAR;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Habilitar(bool valor)
        {
            //Estos controles siempre estan deshabilitados, por que se arman
            this.txtcodigo.Enabled = false;
            this.txtdescripcion.Enabled = false;

            this.txtunimed.Enabled = valor;

            //this.rbtareaformato.Enabled = valor;
            //this.rbtareamodelo.Enabled = valor;

            // Caracteristicas del articulo
            this.txttipo.Enabled = valor;
            this.txtcolor.Enabled = valor;
            this.txttonalidad.Enabled = valor;
            this.txtformato.Enabled = valor;
            this.txtacabado.Enabled = valor;
            this.txtrelleno.Enabled = valor;
            this.txtborde.Enabled = valor;
            this.txtcalidad.Enabled = valor;
            this.txtmodelo.Enabled = valor;
            
  
        }

        public void Deshabilitarkeyarticulo()
        {
            this.txtcodigo.Enabled = false;
            this.txtdescripcion.Enabled = false;
            // Caracteristicas del articulo
            this.txttipo.Enabled = false;
            this.txtcolor.Enabled = false;
            this.txttonalidad.Enabled = false;
            this.txtformato.Enabled = false;
            this.txtacabado.Enabled = false;
            this.txtrelleno.Enabled = false;
            this.txtborde.Enabled = false;
            this.txtcalidad.Enabled = false;
            this.txtmodelo.Enabled = false;
            }

        public void Limpiar()
        {
            this.txtcodigo.Text= "";
            this.txtdescripcion.Text = "";
            this.txtunimed.Text = "";
            // Caracteristicas del articulo
            this.txttipo.Text = "";
            this.txtcolor.Text = "";
            this.txttonalidad.Text = "";
            this.txtformato.Text = "";
            this.txtacabado.Text = "";
            this.txtrelleno.Text = "";
            this.txtborde.Text = "";
            this.txtcalidad.Text = "";
            this.txtmodelo.Text = "";
            // Limpiar Ayudas
            this.rbtareaformato.CheckState = CheckState.Checked;

        }
      

        /*0 - NoEstado 1 - Nuevo  2 - Editar */
        private void cmdBarAgregar_Click(object sender, EventArgs e)
        {


            if (Estado == FormEstate.New)
            {
                estadoGrilla = 1;
                mensajeAviso("Debe registro de articulo primero.");
            }
            else if (Estado == FormEstate.Edit)
            {
                AgregarAlmacen();
            }
            
            
        }

        private void cmdBarEliminar_Click(object sender, EventArgs e)
        {
            EliminarAlmacen();
            estadoGrilla = 0;
        }

        private void cmdBarGuardar_Click(object sender, EventArgs e)
        {
            GuardarAlmacen();
            estadoGrilla = 0;
        }

        private void gridControlAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (this.gridControlAlmacen.CurrentRow.Cells[0].IsCurrent == true) {
                if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmAlmacen);
            }
            
        }

        private void cmbBarCancelar_Click(object sender, EventArgs e)
        {
            Estado = FormEstate.List;

            this.gridControlAlmacen.AllowEditRow = false;
            estadoGrilla = 0;
            CancelarAlmacen();
        }

        
        #region "Metodos Equivalencia"
        private void crearColumnasEquivalencia()
        {
            this.gridEquivalenciaProxCli.Columns.Clear();
            this.gridEquivalenciaProxCli.ShowGroupPanel = false;
            this.gridEquivalenciaProxCli.AllowAddNewRow = false;
            this.gridEquivalenciaProxCli.AllowEditRow = false;
            this.gridEquivalenciaProxCli.EnableHotTracking = true;
            this.gridEquivalenciaProxCli.AllowColumnReorder = false;
            this.gridEquivalenciaProxCli.EnableSorting = false;
            this.gridEquivalenciaProxCli.AutoGenerateColumns = false;

            this.CreateGridColumn(this.gridEquivalenciaProxCli, "Codigo Cliente", "In20clientecod", 0, "", 100, true, true, true);
            this.CreateGridColumn(this.gridEquivalenciaProxCli, "Nombre Cliente", "NombreCliente", 0, "", 120, true, true, true);
            this.CreateGridColumn(this.gridEquivalenciaProxCli, "Codigo", "In20Codigo", 0, "", 100, true, true, true);
            this.CreateGridColumn(this.gridEquivalenciaProxCli, "Descripcion", "In20Descripcion", 0, "", 320, true, true, true);
            this.CreateGridColumn(this.gridEquivalenciaProxCli, "Unid x Caja", "In20UndxCaja", 0, "", 70, true, true, true);
            this.CreateGridColumn(this.gridEquivalenciaProxCli, "Pza x Caja", "in20PiezasxCaja", 0, "", 70, true, true, true);
        }
      
        int estadoEquivalencia = 0;
        private void OnGuardarEquivalencia(){
            ArticuloCliente entidad = new ArticuloCliente();
            if(this.gridEquivalenciaProxCli.Rows.Count > 0 )
            if (!ValidarEquivalencia())
                return;
            if (estadoEquivalencia == 1)
            {
               
                string codig1 = this.gridEquivalenciaProxCli.CurrentRow.Cells[0].Value.ToString();
                string m_In20Codigo = this.gridEquivalenciaProxCli.CurrentRow.Cells["In20Codigo"].Value.ToString();
                string msj = string.Empty;
                ArticuloClienteLogic.Instance.Actualizar_CodigoPropio(Logueo.CodigoEmpresa, codig1, m_In20Codigo, 
                    txtcodigo.Text.Trim(), out msj);                                
                RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                _ArticuloCodigo = txtcodigo.Text;
                OnBuscarEquivalencias();
                
            }
            estadoEquivalencia = 0;
            
        }
        private void OnBuscarEquivalencias()
        {
            try
            {
                _ArticuloCodigo = txtcodigo.Text;
                var equivalencias = ArticuloClienteLogic.Instance.TraerEquiProdClientes(Logueo.CodigoEmpresa, "01", _ArticuloCodigo);
                if (equivalencias != null)
                {
                    this.gridEquivalenciaProxCli.DataSource = equivalencias;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnNuevoEquivalencia()
        {
            this.gridEquivalenciaProxCli.Rows.AddNew();
            
             this.MostrarAyuda(enmAyuda.enmEquivalenciaProducto);
            //estadoEquivalencia = 1;
        }
        private void OnEliminarEquivalencia() {
            if (this.gridEquivalenciaProxCli.Rows.Count != 0) { 
            
            
             DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 ArticuloCliente entidad = new ArticuloCliente();
                 entidad.In20codemp = Logueo.CodigoEmpresa;
                 string codig1 = this.gridEquivalenciaProxCli.CurrentRow.Cells[0].Value.ToString();
                 entidad.In20clientecod = codig1;
                 string m_In20Codigo = this.gridEquivalenciaProxCli.CurrentRow.Cells["In20Codigo"].Value.ToString();
                 entidad.In20Codigo = m_In20Codigo;
                 
                 string msj = string.Empty;

                 ArticuloClienteLogic.Instance.EliminarEquivalencia(Logueo.CodigoEmpresa, codig1, m_In20Codigo, txtcodigo.Text, out msj);
                 RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                 OnBuscarEquivalencias();
             }
            }
        }
        private void OnCancelarEquivalencia() {            
            OnBuscarEquivalencias();
            estadoEquivalencia = 0;
        }
        #endregion
        

        private void gridEquivalenciaProxCli_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmEquivalenciaProducto);
        }
        void mensajeAviso(string msj) {
            RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        private bool ValidarEquivalencia(){
            var grilla = gridEquivalenciaProxCli.CurrentRow;
            if (grilla.Cells[0].Value == null) {
                mensajeAviso("Completo el registro");   
                return false;
            }
            if (grilla.Cells[1].Value == null) {
                mensajeAviso("Completar el registro");
                return false;
            }
            if (grilla.Cells[2].Value == null) {
                mensajeAviso("Completar el registro");
                return false;
            }
            if (grilla.Cells[3].Value == null)
            {
                mensajeAviso("Completar el registro");
                return false;
            }
            if (grilla.Cells[4].Value == null)
            {
                mensajeAviso("Completar el registro");
                return false;
            }

            if (grilla.Cells[5].Value == null)
            {
                mensajeAviso("Completar el registro");
                return false;
            }
            return true;

        }
        private void cmdAgregarEquivalencia_Click(object sender, EventArgs e)
        {

            if (Estado == FormEstate.New)
            {
                mensajeAviso("Debe registrar el articulo primero");

            }
            else
            {
                OnNuevoEquivalencia();
            }
        }
        private void cmdGrabarEquivalencia_Click(object sender, EventArgs e)
        {
            OnGuardarEquivalencia();            
        }
        private void cmdEliminarEquivalencia_Click(object sender, EventArgs e)
        {
            OnEliminarEquivalencia();
        }
        private void cmdCancelarEquivalencia_Click(object sender, EventArgs e)
        {
            estadoEquivalencia = 0;
            OnBuscarEquivalencias();
        }
                
        }
      }
