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

namespace Com.UI.Win
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        public frmLogin()
        {
            InitializeComponent();
            cboEmpresa.DataSource = SegUsuarioLogic.Instance.listar_empresa();
            cboEmpresa.ValueMember = "Codigo";
            cboEmpresa.DisplayMember = "Nombre";
            //txtUsuario.Text = "carla";
            //txtContrasenia.Text = "carla";
            
            txtUsuario.Focus();
            this.Activate();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string encriptado = SegUsuarioLogic.Instance.Encripta(txtContrasenia.Text);
            var tabla = SegUsuarioLogic.Instance.Seg_Trae_Autenticacion_Usuario(txtUsuario.Text, encriptado,
                cboEmpresa.SelectedValue.ToString());

            if (tabla.Count == 0)
            {
                RadMessageBox.Show("Las credenciales no son validas", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }
            var tablaPermisos = SegMenuPorPerfilLogic.Instance.Trae_Menu_Por_Perfil(tabla[0].CodigoPerfil, "04");
            string valorbimoneda = "";
            string codigobusqueda = Logueo.CodigoEmpresa + "|" +Logueo.Anio +"|"+ Logueo.nombreModulo;
            GlobalLogic.Instance.DameDescripcion(codigobusqueda, "BIMONEDA", out valorbimoneda);
            if (tablaPermisos.Count == 0)
            {
                RadMessageBox.Show("El perfil del usuario no tiene permiso asignado al perfil.", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            frmMDI m = new frmMDI(tabla[0].CodigoPerfil);
            Logueo.UserName = txtUsuario.Text;
            Logueo.codigoPerfil = tabla[0].CodigoPerfil;
            Logueo.nomPerfil = tabla[0].NomPerfil;

            Logueo.clavePasada = txtContrasenia.Text;
            Logueo.CodigoEmpresa = cboEmpresa.SelectedValue.ToString();
            Logueo.NombreEmpresa = cboEmpresa.SelectedItem.ToString();

            Logueo.BiMoneda = valorbimoneda;
            m.Show();
            this.Hide();
            this.txtUsuario.Clear();
            this.txtContrasenia.Clear();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                txtContrasenia.Focus();    
            }
            
        }

        private void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                btnIngresar.Focus();
            }
        }

        private void btnIngresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtContrasenia.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar credenciales");
                txtUsuario.Focus();
                return;
            }

            if(e.KeyValue == (char)Keys.Enter)
            {
                btnIngresar_Click(null, null);
            }
        }
    }
}
