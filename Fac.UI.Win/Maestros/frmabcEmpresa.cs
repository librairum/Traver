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

namespace Fac.UI.Win
{
    public partial class frmabcEmpresa : frmBaseMante
    {
        #region "Instancia"
        private static frmabcEmpresa _aForm;
        private frmempresa FrmParent { get; set; }
        public static frmabcEmpresa Instance(frmempresa formParent)
        {
            if (_aForm != null) return new frmabcEmpresa(formParent);
            _aForm = new frmabcEmpresa(formParent);
            return _aForm;
        }
        #endregion

        public frmabcEmpresa(frmempresa padre)
        {
            InitializeComponent();
            FrmParent = padre;
            gestionarBotones(false, false, false, true,true);
            Limpiar();
            txtCodEmpCont.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodEmpAlm.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodDpto.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodProvincia.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtCodDistrito.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            btnArriba.Click += new EventHandler(btnArriba_Click);
            btnAbajo.Click += new EventHandler(btnAbajo_Click);
        }

        void btnAbajo_Click(object sender, EventArgs e)
        {
            int anio = Convert.ToInt32(txtejercicio.Text);
            anio--;
            txtejercicio.Text = anio.ToString();
        }

        void btnArriba_Click(object sender, EventArgs e)
        {
            int anio = Convert.ToInt32(txtejercicio.Text);
            anio++;
            txtejercicio.Text = anio.ToString();
        }

        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            frmBusqueda frm;
            string[] datos;
            if (e.KeyValue == (char)Keys.F1)
            {            
            string TextBoxName = ((RadTextBox)sender).Name;

            switch (TextBoxName)
            {
                case "txtCodEmpCont":
                    frm = new frmBusqueda(enmAyuda.enmEmpContable, "");
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodEmpCont.Text = datos[0];
                    LblHelp0.Text = datos[1];
                    break;

                case "txtCodEmpAlm":
                    frm = new frmBusqueda(enmAyuda.enmEmpAlmacen, "");
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodEmpAlm.Text = datos[0];
                    LblHelp1.Text = datos[1];
                    break;

                case "txtCodDpto":
                    frm = new frmBusqueda(enmAyuda.enmCliente_Dpto, "");
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodDpto.Text = datos[0];
                    LblHelp2.Text = datos[1];
                    break;

                case "txtCodProvincia":
                    frm = new frmBusqueda(enmAyuda.enmCliente_Prov, txtCodDpto.Text.Trim());
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodProvincia.Text = datos[0];
                    LblHelp3.Text = datos[1];
                    break;

                case "txtCodDistrito":
                    frm = new frmBusqueda(enmAyuda.enmCliente_Dist, txtCodDpto.Text.Trim() + "|" 
                                                                    + txtCodProvincia.Text.Trim());
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodDistrito.Text =  datos[0];
                    LblHelp4.Text = datos[1];
                    break;


                default: 
                    break;
            }

            }
            
        }
        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtRepresentante.Text = "";
            txtCargo.Text = "";
            txtruc.Text = "";
            txtigv.Text = "";
            txtejercicio.Text = "";
            txtClave.Text = "";
            txtCodEmpCont.Text = "";
            txtCodEmpAlm.Text = "";

            txtCodDpto.Text = "";
            LblHelp2.Text = "";

            txtCodProvincia.Text = "";
            LblHelp3.Text = "";

            txtCodDistrito.Text = "";
            LblHelp4.Text = "";

            txtUrbanizacion.Text = "";
            txtCorreo.Text = "";
        }
        
        private void CargarRegistro()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                GridViewRowInfo row = FrmParent.gridControl.CurrentRow;
                txtCodigo.Text = Util.GetCurrentCellText(row, "Codigo");
                txtNombre.Text = Util.GetCurrentCellText(row, "Nombre");
                txtDireccion.Text = Util.GetCurrentCellText(row, "Direccion");
                txtRepresentante.Text = Util.GetCurrentCellText(row, "Representante");
                txtCargo.Text = Util.GetCurrentCellText(row, "Cargo");
                txtruc.Text = Util.GetCurrentCellText(row, "Ruc");
                txtigv.Text = Util.GetCurrentCellText(row, "Igv");

                //cboejercicio.Value = Util.GetCurrentCellText(row, "Ejercicio");

                txtejercicio.Text = Util.GetCurrentCellText(row, "Ejercicio");

                txtClave.Text = Util.GetCurrentCellText(row, "Clave");
                txtCodEmpCont.Text = Util.GetCurrentCellText(row, "CodEmpContabilidad");
                LblHelp0.Text = Util.GetCurrentCellText(row, "DesCtaCtble");

                txtCodEmpAlm.Text = Util.GetCurrentCellText(row, "CodEmpAlmacen");
                LblHelp1.Text = Util.GetCurrentCellText(row, "DescAlmacen");

                txtCodDpto.Text = Util.GetCurrentCellText(row, "DepartamentoCod");
                LblHelp2.Text = Util.GetCurrentCellText(row, "DepaDescrpicion");

                txtCodProvincia.Text = Util.GetCurrentCellText(row, "ProvinciaCod");
                LblHelp3.Text = Util.GetCurrentCellText(row, "ProviDescripcion");

                txtCodDistrito.Text = Util.GetCurrentCellText(row, "DistritoCod");
                LblHelp4.Text = Util.GetCurrentCellText(row, "DisDescripcion");

                txtUrbanizacion.Text = Util.GetCurrentCellText(row, "urbanizacion");
                txtCorreo.Text = Util.GetCurrentCellText(row, "CorreoFacturaElectonica");

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            Cursor.Current = Cursors.Default; 
        }

        private void frmabcEmpresa_Load(object sender, EventArgs e)
        {
            
            Estado = FrmParent.Estado;
                if(Estado == FormEstate.New)
                {
                    //cboejercicio.Value = DateTime.Now.Year;
                    txtejercicio.Text = DateTime.Now.Year.ToString();

                }else if(Estado == FormEstate.Edit)
                {
                    CargarRegistro();
                }else if(Estado == FormEstate.View)
                {
                    
                }
        }
        bool Validar()
        {
            if (txtCodigo.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo");
                return false;
            }
            if(txtNombre.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar nombre");
                return false;
            }
            
            return true;
        }
        protected override void OnGuardar()
        {
            if (Validar() == false) return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Estado = FrmParent.Estado;
                string sistema = Logueo.nombreModulo;

                Empresa entidad = new Empresa();
                entidad.Sistema = sistema;
                entidad.Codigo = txtCodigo.Text.Trim();
                entidad.Nombre = txtNombre.Text.Trim();
                entidad.Direccion = txtDireccion.Text.Trim();
                entidad.Representante = txtRepresentante.Text.Trim();
                entidad.Cargo = txtCargo.Text.Trim();
                entidad.Igv = Convert.ToInt32(txtigv.Text.Trim());
                entidad.Ruc = txtruc.Text.Trim();
                entidad.Ejercicio = txtejercicio.Text;
                entidad.Clave = txtClave.Text.Trim();
                entidad.CodEmpContabilidad = txtCodEmpCont.Text.Trim();
                entidad.CodEmpAlmacen = txtCodEmpAlm.Text.Trim();
                entidad.CorreoFacturaElectonica = txtCorreo.Text.Trim();
                entidad.DepartamentoCod = txtCodDpto.Text.Trim();
                entidad.ProvinciaCod = txtCodProvincia.Text.Trim();
                entidad.DistritoCod = txtCodDistrito.Text.Trim();
                entidad.urbanizacion = txtUrbanizacion.Text.Trim();

                int int_flag = 0; string str_mensaje = "";

                if (Estado == FormEstate.New)
                {
                    GlobalLogic.Instance.InsertarEmpresa(entidad, out int_flag, out str_mensaje);
                }
                else if (Estado == FormEstate.Edit)
                {
                    GlobalLogic.Instance.ActualizarEmpresa(entidad, out int_flag, out str_mensaje);
                }

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1) { Estado = FormEstate.Edit; }

                FrmParent.Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
                

        }

        protected override void OnCancelar()
        {
            this.Close();
        }
    }
}
