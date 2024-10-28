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

namespace Inv.UI.Win.Maestros
{
    public partial class frmProductoProcDet : frmBaseReg
    {
        private bool isLoaded = false;
        private bool isOpened = false;

        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;

        public string _ArticuloCodigo = string.Empty;
        public string _NomAlmacen = string.Empty;

        int estadoGrilla = 0;
        public int pos = 0;

        public RadGridView _grid;
        private frmProductoProcLista frmParent { get; set; }
        private static frmProductoProcDet _aForm;

        public frmProductoProcDet(frmProductoProcLista padre)
        {
            InitializeComponent();
            frmParent = padre;
            CrearColumnas();
            menu = this.radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbGuardar = menu.Items["cbbGuardar"];
            cbbNuevo = menu.Items["cbbNuevo"];
        }
        public static frmProductoProcDet Instance(frmProductoProcLista mdiPrincipal)
        {
            if (_aForm != null) return new frmProductoProcDet(mdiPrincipal);
            _aForm = new frmProductoProcDet(mdiPrincipal);
            return _aForm;
        }
        private void frmProductoProcDet_Activated(object sender, EventArgs e) {

            //Ubica el mouse en TextBox Tipo de documento
            if (this.Estado == FormEstate.New && !isOpened)
            {
                //SendKeys.Send("{TAB}");
                //SendKeys.Send("{TAB}");
                //SendKeys.Send("{TAB}");
                //SendKeys.Send("{TAB}");
            }
            isOpened = true;
        }
        void CrearColumnas() {
            RadGridView grilla = this.CreateGridVista(this.gridControlAlmacen);

            this.CreateGridColumn(grilla, "Codigo", "In04CodAlm", 0, "", 50, false, true, true);
            this.CreateGridColumn(grilla, "Descripcion", "In09Descripcion", 0, "", 250, false, true, true);
        }
        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (this.txtcodigo.Text.Trim().Length == 0)
            {
                RadMessageBox.Show("Debe ingresar Codigo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcodigo.Focus();
                return false;
            }
            if (txtcolor.Text.Trim().Length == 0 || txthelpcolor.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Color", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtcolor.Focus();
                return false;
            }
            if (txttonalidad.Text.Trim().Length == 0 || txthelptonalidad.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Tonalidad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txttonalidad.Focus();
                return false;
            }
            if (txtformato.Text.Trim().Length == 0 || txthelpformato.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Formato", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtformato.Focus();
                return false;
            }
            if (txtacabado.Text.Trim().Length == 0 || txtacabado.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Acbado", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtacabado.Focus();
                return false;
            }
            if (txtrelleno.Text.Trim().Length == 0 || txthelprelleno.Text.Trim() == "???")
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

            if (txtcalidad.Text.Trim().Length == 0 || txthelpcalidad.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Calidad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtcalidad.Focus();
                return false;
            }
            if (txtmodelo.Text.Trim().Length == 0 || txthelpmodelo.Text.Trim() == "???")
            {
                RadMessageBox.Show("Debe ingresar Modelo", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtmodelo.Focus();
                return false;
            }
            if (this.txtdescripcion.Text.Trim().Length == 0)
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
        private void InicializarNuevo()
        {            
            Habilitar(true);
            Limpiar();
            estadoGrilla = 0;
        }
        protected override void OnGuardar()
        {
            if (!Validar())
                return;

            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
            string areapt = string.Empty;
            string estadopt = string.Empty;

            try
            {

                if (rbtareamodelo.CheckState == CheckState.Checked)
                { areapt = "M"; }
                else
                { areapt = "F"; }

                if (optptactivo.CheckState == CheckState.Checked)
                { estadopt = "A"; }
                else
                { estadopt = "B"; }

                Articulo articulo = new Articulo();
                articulo.IN01CODEMP = Logueo.CodigoEmpresa;
                articulo.IN01AA = Logueo.Anio;
                articulo.IN01KEY = txtcodigo.Text.ToUpper();
                articulo.IN01DESLAR = txtdescripcion.Text;
                articulo.IN01UNIMED = txtunimed.Text;
                articulo.IN01CODPRO = "";
                articulo.IN01MOV = "S";
                articulo.IN01UNIDADEQUI = txtunimed.Text;
                articulo.IN01MONTOEQUI = 1;
                articulo.IN01UNIDADMAYOR = "N";
                articulo.IN01ESTADO = estadopt;
                articulo.IN01TIPO = "T"; // T de productos terminados
                articulo.IN01FLAGTIPCALAREA = areapt;

                articulo.IN01PRODNATURALEZA = Logueo.PP_codnaturaleza;
                /*-----------------------------------SOLO DETALLE DE ARTICULO (ALMACEN,UNIDADES,STOCK) ----------------------*/
                /*este bloque es para ingresar a la tabla In04Axal donde el articulo se va guardar a cual almacen se asignara*/
                /*esta tabla se ingresa solo datos como codigo y stock entre otros detalles del articulo pero no 
                 la descripion y ubicaion del almacen*/

                ArticuloPorAlmacen articuloporalmacen = new ArticuloPorAlmacen();
                articuloporalmacen.IN04CODEMP = Logueo.CodigoEmpresa;
                articuloporalmacen.IN04AA = Logueo.Anio;
                articuloporalmacen.IN04KEY = txtcodigo.Text.ToUpper();
                /*por defecto es el 06 para mostrar el nombre se lista junto con la tabla de almacenes in09alma 
                 que contine el codigo y descripcion  - ubicacion 
                 */
                /*linea original de ocodigo */
                articuloporalmacen.IN04CODALM = Logueo.PP_AlmxDefecto; // Almacen por defecto                      
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
                //
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO

                    /*bloque de codigo añadido para grabar los almacenes asignado sl productos en caso de ser nuevo*/
                    ArticuloLogic.Instance.ArticuloInsertar(articulo, out mensajeRetorno);


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
                    ArticuloLogic.Instance.ArticuloModificar(articulo, out mensajeRetorno);

                    /*actualizar los almacenes en loq ue encuentro el articulo*/
                    if (this.gridControlAlmacen.RowCount > 0)
                    {
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
                this.frmParent.listar();
                
                //FrmArticuloLista.Instancia().listar();

            }
            catch (Exception)
            {


                RadMessageBox.Show("Ha ocurrido error inesperado al registrar el documento", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #region "metodos de Materia Prima"
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
                if (articulo.IN01FLAGTIPCALAREA == "M")
                {
                    this.rbtareamodelo.CheckState = CheckState.Checked;
                }
                else { this.rbtareaformato.CheckState = CheckState.Checked; }

                if (articulo.IN01ESTADO == "A")
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
        private void productoterminadoarmarcodigo()
        {
            try
            {
                this.txtcodigo.Text = txttipo.Text + txtcolor.Text + txttonalidad.Text + txtformato.Text + txtacabado.Text + txtrelleno.Text + txtborde.Text + txtcalidad.Text + txtmodelo.Text;

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
        protected override void OnPrimero()
        {
            pos = 0;
            asignarValores();
        }
        protected override void OnSiguiente()
        {
            if (pos == frmParent.gridControl.Rows.Count - 1 || pos == frmParent.gridControl.ChildRows.Count - 1)
            {
                return;
            }
            //if (pos == _grid.RowCount - 1 || pos == _grid.ChildRows.Count - 1)
            //    return;
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

            pos = frmParent.gridControl.MasterView.Rows.Count - 1;
            asignarValores();
        }
        #endregion
        void enfocarregistro()
        {
            frmParent.gridControl.MasterView.Rows[pos].IsCurrent = true;
            frmParent.gridControl.MasterView.Rows[pos].IsSelected = true;            
        }
        void asignarValores()
        {
            //asigno los valores de la fila actual seleccionado
            txtcodigo.Text =  frmParent.gridControl.MasterView.Rows[pos].Cells["IN01KEY"].Value.ToString();            
            _ArticuloCodigo = txtcodigo.Text;
            CargarDocumento();
            this.CargarAlmacenes();

            //resalto el registro actual
            enfocarregistro();
        }
        #region "materia x almacen

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
        private void GuardarAlmacen()
        {
            string fechaini = "";
            string mensajeRetorno1 = string.Empty;
            try
            {
                if (this.gridControlAlmacen.RowCount > 0)
                {
                    if (!string.IsNullOrEmpty(this.gridControlAlmacen.CurrentRow.Cells[0].Value.ToString()))
                    {
                        ArticuloPorAlmacen articuloporalmacen = new ArticuloPorAlmacen();
                        articuloporalmacen.IN04CODEMP = Logueo.CodigoEmpresa;
                        articuloporalmacen.IN04AA = Logueo.Anio;
                        articuloporalmacen.IN04KEY = txtcodigo.Text;
                        /*por defecto es el 06 para mostrar el nombre se lista junto con la tabla de almacenes in09alma 
                         que contine el codigo y descripcion  - ubicacion 
                         */
                        /*linea original de ocodigo */
                        articuloporalmacen.IN04CODALM = Logueo.PP_AlmxDefecto; // Almacen por defecto                      
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
            catch (Exception ex)
            {

            }


            CargarAlmacenes();
            this.gridControlAlmacen.AllowEditRow = false;
        }
        #endregion

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
            this.txtcodigo.Text = "";
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
        //public frmProductoProcDet()
        //{
        //    InitializeComponent();
        //}
        #region "Metodos Globales"
        void mensajeAviso(string msj)
        {
            RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
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

                        if (!string.IsNullOrEmpty(codigo))
                        {
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
                        codigoSeleccionado = frm.Result.ToString().ToUpper(); ;

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
                    frm = new frmBusqueda(tipoAyuda, Logueo.PP_codnaturaleza);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString().ToUpper();
                    if (!string.IsNullOrEmpty(codigoSeleccionado))
                    {
                        ObtenerDescripcion(enmAyuda.enmAlmacen, codigoSeleccionado);
                        gridControlAlmacen.Rows.AddNew();
                        gridControlAlmacen.CurrentRow.Cells[0].Value = codigoSeleccionado;
                        gridControlAlmacen.CurrentRow.Cells[1].Value = _NomAlmacen;
                        GuardarAlmacen();
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
        #endregion



        private void txtunimed_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmUniMed, this.txtunimed.Text);
        }

        private void txtunimed_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmUniMed);
        }


        private void txtcalidad_KeyDown(object sender, KeyEventArgs e)
        {
            //Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmCalidad);

        }

        private void txtcalidad_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmCalidad, this.txtcalidad.Text);
            this.productoterminadoarmarcodigo();
        }

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

        private void frmProductoProdDet_Load(object sender, EventArgs e) 
        {
            if (this.Estado == FormEstate.New)
            {
                InicializarNuevo();
                this.HabilitarRadBar(ElementVisibility.Visible, ElementVisibility.Collapsed);
                CrearColumnas();
            }
            else if (this.Estado == FormEstate.Edit)
            {
                double CanMovimientos = 0;
                ArticuloLogic.Instance.TraerMovimientoxArticulo(Logueo.CodigoEmpresa, Logueo.Anio, _ArticuloCodigo, out CanMovimientos);
                isLoaded = true;
                CargarDocumento();
                CrearColumnas();
                this.CargarAlmacenes();                
                Deshabilitarkeyarticulo();
                Habilitar(false);
                rbtareaformato.Enabled = true;
                rbtareamodelo.Enabled = true;
                optptactivo.Enabled = true;
                optptinactivo.Enabled = true;
                this.HabilitarBotones(true, true, true, true, false);
                txtunimed.Enabled = CanMovimientos == 0 ? true : false;
            }
            else if (this.Estado == FormEstate.View)
            {
                
                isLoaded = true;
                CrearColumnas();
                CargarDocumento();
                this.CargarAlmacenes();


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

        private void AgregarAlmacen()
        {
            try
            {
                this.MostrarAyuda(enmAyuda.enmAlmacen);
            }
            catch (Exception ex)
            {
            }
        }
        private void EliminarAlmacen()
        {
            /*articuloporalmacen.IN04CODEMP, articuloporalmacen.IN04AA,
             * articuloporalmacen.IN04KEY, articuloporalmacen.IN04CODALM, out @cMsgRetorno);*/
            if (this.gridControlAlmacen.Rows.Count != 0)
            {
                string msj = string.Empty;
                ArticuloPorAlmacen entidad = new ArticuloPorAlmacen();

                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);
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
        private void CancelarAlmacen()
        {
            this.gridControlAlmacen.AllowEditRow = false;
            CargarAlmacenes();
        }


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
        private void cmbBarCancelar_Click(object sender, EventArgs e)
        {
            Estado = FormEstate.List;

            this.gridControlAlmacen.AllowEditRow = false;
            estadoGrilla = 0;
            CancelarAlmacen();
        }

        private void txtmodelo_TextChanged(object sender, EventArgs e)
        {
            this.ObtenerDescripcion(enmAyuda.enmModelo, this.txtmodelo.Text);
            this.productoterminadoarmarcodigo();
        }
        private void btnAddDetalle_Click(object sender, EventArgs e) { 
            
        }
        private void gridControlAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (this.gridControlAlmacen.CurrentRow.Cells[0].IsCurrent == true)
            {
                if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmAlmacen);
            }

        }

       
      

    }
}
