using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Inv.BusinessLogic;
using Inv.BusinessEntities;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Fac.UI.Win
{
    public partial class frmProductosDet : frmBaseReg
    {

        public string _ArticuloCodigo;
        private static frmProductosDet _aForm;
        private frmProductos FrmParent { get; set; }
        public static frmProductosDet Instance(frmProductos formParent)
        {
            if (_aForm != null) return new frmProductosDet(formParent);
            _aForm = new frmProductosDet(formParent);
            return _aForm;
        }

        public frmProductosDet(frmProductos padre)
        {
            InitializeComponent();
            FrmParent = padre;
            
            
            

            _ArticuloCodigo = FrmParent.ProductoCodigo;
            txttipo.KeyDown += new KeyEventHandler(txttipo_KeyDown);
            txtcolor.KeyDown += new KeyEventHandler(txtcolor_KeyDown);
            txttonalidad.KeyDown += new KeyEventHandler(txttonalidad_KeyDown);
            txtformato.KeyDown += new KeyEventHandler(txtformato_KeyDown);
            txtacabado.KeyDown += new KeyEventHandler(txtacabado_KeyDown);
            txtrelleno.KeyDown += new KeyEventHandler(txtrelleno_KeyDown);
            txtborde.KeyDown += new KeyEventHandler(txtborde_KeyDown);
            txtcalidad.KeyDown += new KeyEventHandler(txtcalidad_KeyDown);
            txtmodelo.KeyDown += new KeyEventHandler(txtmodelo_KeyDown);
            txtunimed.KeyDown += new KeyEventHandler(txtunimed_KeyDown);
            txtuniventa.KeyDown += new KeyEventHandler(txtuniventa_KeyDown);

            txttipo.TextChanged += new EventHandler(TextBox_TextChanged);
            txtcolor.TextChanged += new EventHandler(TextBox_TextChanged);
            txttonalidad.TextChanged += new EventHandler(TextBox_TextChanged);
            txtformato.TextChanged += new EventHandler(TextBox_TextChanged);
            txtacabado.TextChanged += new EventHandler(TextBox_TextChanged);
            txtrelleno.TextChanged += new EventHandler(TextBox_TextChanged);
            txtborde.TextChanged += new EventHandler(TextBox_TextChanged);
            txtcalidad.TextChanged += new EventHandler(TextBox_TextChanged);
            txtmodelo.TextChanged += new EventHandler(TextBox_TextChanged);
            txtunimed.TextChanged += new EventHandler(TextBox_TextChanged);
            txtuniventa.TextChanged += new EventHandler(TextBox_TextChanged);
            OnBuscarEquivalencias();
        }
        void TextBox_TextChanged(object sender, EventArgs e)
        { 
            string NombreControl =  ((RadTextBox)sender).Name;
            switch (NombreControl)
            {
                case "txttipo":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtcolor":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txttonalidad":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtformato":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtacabado":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtrelleno":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtborde":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtcalidad":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtmodelo":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtunimed":
                    this.productoterminadoarmarcodigo();
                    break;
                case "txtuniventa":
                    break;
                default:
                    break;
            }
        }
        void txtcolor_TextChanged(object sender, EventArgs e)
        {
            //if(txtcolor.TextChanged != "")
                
        }

        void txttipo_TextChanged(object sender, EventArgs e)
        {
            if (txttipo.Text != "")
                productoterminadoarmarcodigo();
        }
        bool validar()
        {

            
            if (txtunimed.Text == "")
            {
                Util.ShowAlert("Ingresar unidad");
                txtunimed.Focus();
                return false;
            }
            if (txtuniventa.Text == "")
            {
                Util.ShowAlert("Ingresar unidad de venta");
                txtuniventa.Focus();
                return false;
            }
            if (txtdescripcion.Text == "")
            {
                Util.ShowAlert("Ingresar descripcion");
                txtdescripcion.Focus();
                return false;
            }

            //if (txtDescIngles.Text == "")
            //{
            //    Util.ShowAlert("Ingresar descripcion Ingles");
            //    txtDescIngles.Focus();
            //    return false;
            //}

            //if (txtDescEspaniol.Text == "")
            //{
            //    Util.ShowAlert("Ingresar descripcion Español");
            //    txtDescEspaniol.Focus();
            //    return false;
            //}

            if (txttipo.Text == "")
            {
                Util.ShowAlert("Ingresar tipo");
                txttipo.Focus();
                return false;
            }

            if (txtcolor.Text == "")
            {
                Util.ShowAlert("Ingresar color");
                txtcolor.Focus();
                return false;
            }

            if (txttonalidad.Text == "")
            {
                Util.ShowAlert("Ingresar tonalidad");
                txttonalidad.Focus();
                return false;
            }

            if (txtformato.Text == "")
            {
                Util.ShowAlert("Ingresar formato");
                txtformato.Focus();
                return false;
            }

            if (txtacabado.Text == "")
            {
                Util.ShowAlert("Ingresar acabado");
                txtacabado.Focus();
                return false;
            }

            if (txtrelleno.Text == "")
            {
                Util.ShowAlert("Ingresar relleno");
                txtrelleno.Focus();
                return false;
            }

            if (txtborde.Text == "")
            {
                Util.ShowAlert("Ingresar borde");
                txtborde.Focus();
                return false;
            }

            if (txtcalidad.Text == "")
            {
                Util.ShowAlert("Ingresar calidad");
                txtcalidad.Focus();
                return false;
            }

            if (txtmodelo.Text == "")
            {
                Util.ShowAlert("Ingresar modelo");
                txtmodelo.Focus();
                return false;
            }

            if (rbtareaformato.CheckState == CheckState.Unchecked 
                && rbtareamodelo.CheckState == CheckState.Unchecked)
            {
                Util.ShowAlert("Seleccionar area"); return false;
            }

            if(optptactivo.CheckState == CheckState.Unchecked 
               && optptinactivo.CheckState == CheckState.Unchecked)
            {
                Util.ShowAlert("Seleccionar estado"); return false;
            }
            return true;
        }
        protected override void OnGuardar()
        {
            try
            {
                string estadopt = "";
                string areapt = "";
                int int_flag = 0;
                string str_mensaje = "";
                Articulo producto = new Articulo();

                if (validar() == false) return;

                if (rbtareamodelo.CheckState == CheckState.Checked)
                { areapt = "M"; }
                else
                { areapt = "F"; }

                if (optptactivo.CheckState == CheckState.Checked)
                { estadopt = "A"; }
                else
                { estadopt = "B"; }


                producto.IN01CODEMP = Logueo.CodigoEmpresa;
                producto.IN01AA = Logueo.Anio;
                producto.IN01KEY = txtcodigo.Text.ToUpper();
                producto.IN01DESLAR = txtdescripcion.Text;
                producto.IN01UNIMED = txtunimed.Text;
                producto.IN01UNIDADEQUI = txtunimed.Text;
                producto.IN01MONTOEQUI = 1;
                producto.IN01CODPRO = "";
                producto.IN01FECMAT = DateTime.Now.ToShortDateString();
                producto.IN01MOV = "S";
                producto.IN01UNIDADMAYOR = "N";
                producto.IN01ESTADO = estadopt;
                producto.IN01TIPO = "T"; // T de productos terminados
                producto.IN01FLAGTIPCALAREA = areapt;
                producto.IN01PRODNATURALEZA = Logueo.PT_codnaturaleza;
                producto.IN01DESINGLES = txtDescIngles.Text.Trim();
                producto.IN01DESESPANIOL = txtDescEspaniol.Text.Trim();
                producto.IN01UNIMEDVENTA = txtuniventa.Text.Trim();
                if (Estado == FormEstate.New)
                {
                    ArticuloLogic.Instance.ProductoInsertar(producto, out int_flag, out str_mensaje);
                }
                else
                {
                    ArticuloLogic.Instance.ProductoActualizar(producto, out int_flag, out str_mensaje);
                }

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1)
                {
                    Habilitar(FormEstate.Edit);
                    Estado = FormEstate.Edit;
                    //Refrescar la grilla de listado de productos
                    FrmParent.Cargar();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar : " + ex.Message);
            }
        }
              
        void BloquearControles(bool valor)
        {
            txtcodigo.Enabled = false;

            bool EnabledState = !valor;

            txtunimed.Enabled = EnabledState;
            txtdescripcion.Enabled = false;
            txtDescIngles.Enabled = EnabledState;
            txtDescEspaniol.Enabled = EnabledState;

            txttipo.Enabled = EnabledState;
            txtcolor.Enabled = EnabledState;
            txttonalidad.Enabled = EnabledState;
            txtformato.Enabled = EnabledState;
            txtacabado.Enabled = EnabledState;
            txtrelleno.Enabled = EnabledState;
            txtborde.Enabled = EnabledState;
            txtcalidad.Enabled = EnabledState;
            txtmodelo.Enabled = EnabledState;
            txtuniventa.Enabled = EnabledState;

            optptactivo.Enabled = EnabledState;
            optptinactivo.Enabled = EnabledState;

            rbtareaformato.Enabled = EnabledState;
            rbtareamodelo.Enabled = EnabledState;
            
                
        }

        void Habilitar(FormEstate pEstado)
        {

            if (pEstado == FormEstate.New)
            {
                BloquearControles(false);
            }
            else if (pEstado == FormEstate.Edit)
            {
                BloquearControles(true);
                
                //Activar solo campos modificables
                txtDescEspaniol.Enabled = true;
                txtDescIngles.Enabled = true;
                txtunimed.Enabled = true;
                txtuniventa.Enabled = true;
                rbtareamodelo.Enabled = true;
                rbtareaformato.Enabled = true;
                optptinactivo.Enabled = true;
                optptactivo.Enabled = true;
                
            }
            else if (pEstado == FormEstate.View)
            {
                BloquearControles(true);
                cmdAgregarEquivalencia.Enabled = false;
                cmdEliminarEquivalencia.Enabled = false;
            }
        }
        void txtunimed_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtunimed.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmUniMed);
        }
        void txtuniventa_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtuniventa.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmUniVenta);
            
        }
        void txtmodelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtmodelo.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmModelo);
            //else
            //    Util.FocusNextControl(e);
        }

        void txtcalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtcalidad.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmCalidad);
            //else
            //    Util.FocusNextControl(e);
        }

        void txtborde_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtborde.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmBorde);
            //else
            //    Util.FocusNextControl(e);
        }

        void txtrelleno_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtrelleno.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmRelleno);
            //else
            //    Util.FocusNextControl(e);
        }
        void txtacabado_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtacabado.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmAcabado);
            //else
            //    Util.FocusNextControl(e);
        }
        void txtformato_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtformato.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmFormato);
            //else
            //    Util.FocusNextControl(e);
        }
        void txttonalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (txttonalidad.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmTonalidad);
            //else
            //    Util.FocusNextControl(e);
        }
        void txtcolor_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtcolor.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmColor);
            //else
            //    Util.FocusNextControl(e);
        }
        void txttipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txttipo.Enabled == false) return;
            if (e.KeyValue == (char)Keys.F1)
                TraerAyuda(enmAyuda.enmTipo);
            //else
            //    Util.FocusNextControl(e);
        }
        string[] EntregarDatosDeAyuda(enmAyuda tipo, int cantidaddatos)
        {
            string[] valores = new string[cantidaddatos];
            frmBusqueda frm = new frmBusqueda(tipo);
            frm.ShowDialog();
            if (frm.Result != null)
            {
                if (frm.Result.ToString() != "")
                {
                    valores = frm.Result.ToString().Split('|');
                }
            }
            return valores;
        }
        void TraerAyuda(enmAyuda tipo)
        {
            try
            {
                string[] datos;
                switch (tipo)
                {
                    case enmAyuda.enmTipo:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txttipo.Text = datos[0];
                        txthelptipo.Text = datos[1];
                        break;
                    case enmAyuda.enmColor:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtcolor.Text = datos[0];
                        txthelpcolor.Text = datos[1];
                        break;
                    case enmAyuda.enmTonalidad:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txttonalidad.Text = datos[0];
                        txthelptonalidad.Text = datos[1];
                        break;
                    case enmAyuda.enmFormato:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtformato.Text = datos[0];
                        txthelpformato.Text = datos[1];
                        break;
                    case enmAyuda.enmAcabado:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtacabado.Text = datos[0];
                        txthelpacabado.Text = datos[1];
                        break;
                    case enmAyuda.enmRelleno:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtrelleno.Text = datos[0];
                        txthelprelleno.Text = datos[1];
                        break;
                    case enmAyuda.enmBorde:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtborde.Text = datos[0];
                        txthelpborde.Text = datos[1];
                        break;
                    case enmAyuda.enmCalidad:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtcalidad.Text = datos[0];
                        txthelpcalidad.Text = datos[1];
                        break;
                    case enmAyuda.enmModelo:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtmodelo.Text = datos[0];
                        txthelpmodelo.Text = datos[1];
                        break;
                    case enmAyuda.enmUniMed:
                        datos = EntregarDatosDeAyuda(tipo, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtunimed.Text = datos[0];
                        txthelpunimed.Text = datos[1];
                        break;
                    case enmAyuda.enmUniVenta:
                        datos = EntregarDatosDeAyuda(enmAyuda.enmUniMed, 2);
                        if (datos[0] == null || datos[1] == null) return;
                        txtuniventa.Text = datos[0];
                        txthelpuniventa.Text = datos[1];
                        break;
                    case enmAyuda.enmEquivalenciaProducto:

                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda: " + ex.Message);
            }                                           
        }
        void IniciarControles()
        { 
            
        }

        protected override void OnCancelar()
        {
            this.Close();
        }
        private void LimpiarControles()
        {                                      
            txtcodigo.Text = "";
            txtdescripcion.Text = "";
                
            txtDescIngles.Text = "";
            txtDescEspaniol.Text = "";

            txtunimed.Text = "";

            txttipo.Text = "";
            txthelptipo.Text = "";

            txtcolor.Text = "";
            txthelpcolor.Text = "";

            txttonalidad.Text = "";
            txthelptonalidad.Text = "";

            txtcalidad.Text = "";
            txthelpcalidad.Text = "";

            txtformato.Text = "";
            txthelpformato.Text = "";

            txtacabado.Text = "";
            txthelpacabado.Text = "";

            txtrelleno.Text = "";
            txthelprelleno.Text = "";

            txtborde.Text = "";
            txthelpborde.Text = "";

            txtmodelo.Text = "";
            txthelpmodelo.Text = "";

            txtuniventa.Text = "";
            txthelpuniventa.Text = "";
                
            optptactivo.CheckState = CheckState.Checked;
            //optptinactivo.CheckState = CheckState.Unchecked;
            rbtareaformato.CheckState = CheckState.Checked;
            //rbtareamodelo.CheckState = CheckState.Unchecked;
        }
        private void frmProductosDet_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            if (Estado != FormEstate.View)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            }
            crearColumnasEquivalencia();

            LimpiarControles();
            Habilitar(Estado);            

            if (FrmParent.ProductoCodigo != "") 
            {
                
                
                //Traer datos de registro a los campos del formulario.
                GridViewRowInfo row = FrmParent.gridControl.CurrentRow;
                txtcodigo.Text =  Util.GetCurrentCellText(row, "IN01KEY");
                _ArticuloCodigo = txtcodigo.Text.Trim();
                txtdescripcion.Text =  Util.GetCurrentCellText(row, "IN01DESLAR");

                txtunimed.Text = Util.GetCurrentCellText(row, "IN01UNIMED");
                txthelpunimed.Text = Util.GetCurrentCellText(row, "UnidadDesc");

                txtuniventa.Text = Util.GetCurrentCellText(row, "IN01UNIMEDVENTA");
                txthelpuniventa.Text = Util.GetCurrentCellText(row, "UniventaDesc");

                txttipo.Text = Util.GetCurrentCellText(row, "tipo");
                txthelptipo.Text = Util.GetCurrentCellText(row, "tipodesc");

                txtcolor.Text = Util.GetCurrentCellText(row, "color");
                txthelpcolor.Text = Util.GetCurrentCellText(row, "colordesc");
                
                txttonalidad.Text = Util.GetCurrentCellText(row, "tonalidad");
                txthelptonalidad.Text = Util.GetCurrentCellText(row, "tonalidaddesc");
                
                txtcalidad.Text = Util.GetCurrentCellText(row, "calidad");
                txthelpcalidad.Text = Util.GetCurrentCellText(row, "Calidaddesc");

                txtformato.Text = Util.GetCurrentCellText(row, "formato");
                txthelpformato.Text = Util.GetCurrentCellText(row, "formatodesc");
                
                txtacabado.Text = Util.GetCurrentCellText(row, "acabado");
                txthelpacabado.Text = Util.GetCurrentCellText(row, "acabadodesc");
                
                txtrelleno.Text = Util.GetCurrentCellText(row, "relleno");
                txthelprelleno.Text = Util.GetCurrentCellText(row, "rellenodesc");
                
                txtborde.Text = Util.GetCurrentCellText(row, "borde");
                txthelpborde.Text = Util.GetCurrentCellText(row, "bordedesc");

                txtmodelo.Text = Util.GetCurrentCellText(row, "modelo");
                txthelpmodelo.Text = Util.GetCurrentCellText(row, "modelodesc");

                txtDescIngles.Text = Util.GetCurrentCellText(row, "IN01DESINGLES");
                txtDescEspaniol.Text = Util.GetCurrentCellText(row, "IN01DESESPANIOL");
                


                TraerEstado(row);
                TraerTipCalArea(row);               
                
            }
            FrmParent.ProductoCodigo = "";
        }
        private void TraerEstado(GridViewRowInfo pRow)
        {
            optptactivo.CheckState = CheckState.Unchecked;
            optptinactivo.CheckState = CheckState.Unchecked;

            if (Util.GetCurrentCellText(pRow, "IN01ESTADO") == "A")
                optptactivo.CheckState = CheckState.Checked;
            else if (Util.GetCurrentCellText(pRow, "IN01ESTADO") == "B")
                optptinactivo.CheckState = CheckState.Checked;
            

        }
        private void TraerTipCalArea(GridViewRowInfo pRow)
        {
            rbtareaformato.CheckState = CheckState.Unchecked;
            rbtareamodelo.CheckState = CheckState.Unchecked;
            if (Util.GetCurrentCellText(pRow, "IN01FLAGTIPCALAREA") == "F")
                rbtareaformato.CheckState = CheckState.Checked;
            else if (Util.GetCurrentCellText(pRow, "IN01FLAGTIPCALAREA") == "M")
                rbtareamodelo.CheckState = CheckState.Checked;
        }
        private void productoterminadoarmarcodigo()
        {
            try
            {
                this.txtcodigo.Text = txttipo.Text.Trim() + txtcolor.Text.Trim() + txttonalidad.Text.Trim() + txtformato.Text.Trim() + txtacabado.Text.Trim() + txtrelleno.Text.Trim() + txtborde.Text.Trim() + txtcalidad.Text.Trim() + txtmodelo.Text.Trim();
                var articulo = ArticuloLogic.Instance.ProterDescripcion(txtcodigo.Text);

                if (articulo != null)
                {
                    this.txtdescripcion.Text = articulo.IN01DESLAR.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al armar codigo: " + ex.Message);
            }
        }

        #region "Equivalencia de producto"
        int estadoEquivalencia = 0;
        private bool ValidarEquivalencia()
        {
            var grilla = gridEquivalenciaProxCli.CurrentRow;
            var indiceActual = gridEquivalenciaProxCli.CurrentColumn.Index;
            if (grilla.Cells[indiceActual].Value == null)
            {
                Util.ShowAlert("Completar el registro");
                return false;
            }

            return true;
        }
        private void cmdAgregarEquivalencia_Click(object sender, EventArgs e)
        {
            if (Estado == FormEstate.New)
            {
                Util.ShowAlert("Debe registrar el producto primero");
            }
            else if(Estado == FormEstate.Edit)
            {
                OnNuevoEquivalencia();
            }
        }
        private void cmdEliminarEquivalencia_Click(object sender, EventArgs e)
        {
            OnEliminarEquivalencia();
        }
        private void OnNuevoEquivalencia()
        {
            this.gridEquivalenciaProxCli.Rows.AddNew();
            TraerAyudaEquivalenciaProducto();
            estadoEquivalencia = 1;

        }
        private void OnCancelarEquivalencia()
        {
            OnBuscarEquivalencias();
            estadoEquivalencia = 0;
        }
        private void OnBuscarEquivalencias()
        {
            try
            {
                if (Estado == FormEstate.Edit)
                {
                    _ArticuloCodigo = txtcodigo.Text;
                    if (_ArticuloCodigo == "")
                    {
                        Util.ShowAlert("El valor de codigo de producto debe ser diferente de vacio"); return;
                    }
                }

                if (_ArticuloCodigo != "")
                {
                    List<ProductoEquivalentes> lista = ArticuloClienteLogic.Instance.TraeEquivalenciaProductosCliente(Logueo.CodigoEmpresa, _ArticuloCodigo);

                    if (lista != null)
                    {
                        this.gridEquivalenciaProxCli.DataSource = lista;
                    }
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer equivalencia: " + ex.Message);
            }
        }
        private void OnEliminarEquivalencia()
        {
            try
            {
                if (this.gridEquivalenciaProxCli.Rows.Count != 0)
                {

                    bool respuesta = Util.ShowQuestion("Está seguro de eliminar");
                    if (respuesta == true)
                    {
                        #region "Eliminar de equivalencia"
                        ArticuloCliente entidad = new ArticuloCliente();
                        entidad.In20codemp = Logueo.CodigoEmpresa;
                        string codig1 = this.gridEquivalenciaProxCli.CurrentRow.Cells[0].Value.ToString();
                        entidad.In20clientecod = codig1;
                        string m_In20Codigo = this.gridEquivalenciaProxCli.CurrentRow.Cells["FAC20PROVPRODCOD"].Value.ToString();
                        entidad.In20Codigo = m_In20Codigo;

                        string msj = string.Empty;
                        string codigoProductoDeisi = "", codigoProveedor = "", codigoProductoProveedor = "";


                        codigoProductoDeisi = txtcodigo.Text.Trim();
                        codigoProveedor = Util.GetCurrentCellText(gridEquivalenciaProxCli.CurrentRow, "FAC20PROVCODIGO");
                        codigoProductoProveedor = Util.GetCurrentCellText(gridEquivalenciaProxCli.CurrentRow, "FAC20PROVPRODCOD");


                        ArticuloClienteLogic.Instance.EliminarEquivalenciaProducto(Logueo.CodigoEmpresa, codigoProductoDeisi,
                        codigoProveedor, codigoProductoProveedor, out msj);

                        //ArticuloClienteLogic.Instance.EliminarEquivalencia(Logueo.CodigoEmpresa, codig1, m_In20Codigo, txtcodigo.Text, out msj);

                        RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                        OnBuscarEquivalencias();
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar equivalencia: " + ex.Message);
            }
        }
        private void TraerAyudaEquivalenciaProducto()
        {
            
            try
            {
                frmBusqueda frm;
                frm = new frmBusqueda(enmAyuda.enmEquivalenciaProducto);
                frm.Owner = this;
                frm.ShowDialog();
                if (frm.Result != null)
                {
                #region "lectura de datos"
                    List<ArticuloCliente> milista_ayuda = (List<ArticuloCliente>)frm.Result;
                    var grilla = gridEquivalenciaProxCli.CurrentRow;

                    grilla.Cells["FAC20PROVCODIGO"].Value = milista_ayuda[0].In20clientecod;
                    grilla.Cells["NombreCliente"].Value = milista_ayuda[0].NombreCliente;
                    grilla.Cells["FAC20PROVPRODCOD"].Value = milista_ayuda[0].In20Codigo;
                    grilla.Cells["FAC20PROVPRODDESC"].Value = milista_ayuda[0].In20Descripcion;
                    grilla.Cells["FAC20PROVPRODUNIMED"].Value = milista_ayuda[0].In20UndMed;

                    string msj = string.Empty;
                    string codigoProductoDeisi = "", codigoProveedor = "", codigoProductoProveedor = "", descProductoProveedor = "",
                        unidadProductoProveedor = "";

                    codigoProductoDeisi = txtcodigo.Text.Trim();
                    codigoProveedor = Util.GetCurrentCellText(gridEquivalenciaProxCli.CurrentRow, "FAC20PROVCODIGO");
                    codigoProductoProveedor = Util.GetCurrentCellText(gridEquivalenciaProxCli.CurrentRow, "FAC20PROVPRODCOD");
                    descProductoProveedor = Util.GetCurrentCellText(gridEquivalenciaProxCli.CurrentRow, "FAC20PROVPRODDESC");
                    unidadProductoProveedor = Util.GetCurrentCellText(gridEquivalenciaProxCli.CurrentRow, "FAC20PROVPRODUNIMED");

                    Cursor.Current = Cursors.WaitCursor;
                    ArticuloClienteLogic.Instance.InsertarEquivalenciaProducto(Logueo.CodigoEmpresa, codigoProductoDeisi, codigoProveedor,
                    codigoProductoProveedor, descProductoProveedor, unidadProductoProveedor, out msj);
                    RadMessageBox.Show(msj, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscarEquivalencias();
                    Cursor.Current = Cursors.Default;

                #endregion
                }
                else
                {
                    gridEquivalenciaProxCli.Rows.RemoveAt(gridEquivalenciaProxCli.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda equivalencia de producto: " + ex.Message);
                gridEquivalenciaProxCli.Rows.RemoveAt(gridEquivalenciaProxCli.CurrentRow.Index);
            }
        }
        private void crearColumnasEquivalencia()
        {
            RadGridView gridEquivalenciaProxCli = CreateGridVista(this.gridEquivalenciaProxCli);

            CreateGridColumn(gridEquivalenciaProxCli, "Codigo Cliente", "FAC20PROVCODIGO", 0, "", 150, true, true, true);
            CreateGridColumn(gridEquivalenciaProxCli, "Nombre Cliente", "NombreCliente", 0, "", 120, true, true, true);
            CreateGridColumn(gridEquivalenciaProxCli, "Codigo", "FAC20PROVPRODCOD", 0, "", 100, true, true, true);
            CreateGridColumn(gridEquivalenciaProxCli, "Descripcion", "FAC20PROVPRODDESC", 0, "", 320, true, true, true);
            CreateGridColumn(gridEquivalenciaProxCli, "Unidad", "FAC20PROVPRODUNIMED", 0, "", 90, true, true, true);


        }

        #endregion
    }

}
