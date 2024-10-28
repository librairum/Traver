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
using System.Configuration;

namespace Fac.UI.Win.Acceso
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        

        public frmLogin()
        {
            InitializeComponent();
            cboEmpresa.DataSource = SegUsuarioLogic.Instance.listar_empresa();
            cboEmpresa.ValueMember = "Codigo";
            cboEmpresa.DisplayMember = "Nombre";

            cboPerfil.DataSource = SegUsuarioLogic.Instance.listar_perfil();
            cboPerfil.ValueMember = "codigo";
            cboPerfil.DisplayMember = "nombre";
            txtUsuario.Focus();
            this.Activate();
         
        }
        private bool Validar() {
            if (txtUsuario.Text.Length == 0)
            {
                RadMessageBox.Show("Ingresa usuario", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtUsuario.Focus();
                return false;
            }
            if (txtContrasenia.Text.Length == 0) {
                RadMessageBox.Show("Ingresa clave","Sistema",MessageBoxButtons.OK,RadMessageIcon.Info);
                txtContrasenia.Focus();
                return false;
            }
            return true;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                    return;
                string encriptado = SegUsuarioLogic.Instance.Encripta(txtContrasenia.Text);
                var tabla = SegUsuarioLogic.Instance.Seg_Trae_Autenticacion_Usuario(txtUsuario.Text, encriptado,
                    cboEmpresa.SelectedValue.ToString());

                if (tabla.Count == 0) { 
                    RadMessageBox.Show("Las credenciales no son validas", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return; 
                }

                var tablaPermisos = SegMenuPorPerfilLogic.Instance.Trae_Menu_Por_Perfil(tabla[0].CodigoPerfil, "03");
                
                if (tablaPermisos.Count == 0) {
                    RadMessageBox.Show("El perfil del usuario no tiene permiso asignado al perfil.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }                                 
                    frmMDI m = new frmMDI(tabla[0].CodigoPerfil);
                    Logueo.UserName = txtUsuario.Text;
                    Logueo.codigoPerfil = tabla[0].CodigoPerfil;
                    Logueo.nomPerfil = tabla[0].NomPerfil;
                    Logueo.clavePasada = txtContrasenia.Text;
                    Logueo.CodigoEmpresa = cboEmpresa.SelectedValue.ToString();
                    
                    // Traer datos de empresa
                    //List<Empresa> lista = null;
                    var lista = GlobalLogic.Instance.TraerEmpresaDet(Logueo.nombreModulo,Logueo.CodigoEmpresa);
                    if (lista.Count == 0) 
                    {
                        Logueo.NombreEmpresa = "XXXX";
                        Logueo.RucEmpresa = "XXXX";
                    }
                    else
                    {
                        Logueo.NombreEmpresa = lista[0].Nombre;
                        Logueo.RucEmpresa = lista[0].Ruc;
                    }
                    Logueo.NombreEmpresa = cboEmpresa.SelectedItem.ToString();
                    
                    m.Show();
                    this.Hide();
                    this.txtUsuario.Clear();
                    this.txtContrasenia.Clear();


            }
            catch (Exception ex)
            {

            }
           

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (txtUsuario.Text.Length == 0 || txtContrasenia.Text.Length == 0)
            //{
            //    MessageBox.Show("Completar datos");
            //    return;
            //}
            
        }

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (txtUsuario.Text.Length == 0 || txtContrasenia.Text.Length == 0)
            //{
            //    MessageBox.Show("Completar datos");
            //    return;
            //}
            if (((Keys)e.KeyChar) == Keys.Enter)
            {
                btnIngresar.Focus();                
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)(e.KeyChar) == Keys.Enter) {
                txtContrasenia.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Focus();

            txtUsuario.Focus();
            
            
            
        }
    }
}
