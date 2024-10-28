using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Com.UI.Win.Acceso
{
    public partial class frmCambiarClave : frmBaseReg
    {
        public frmCambiarClave()
        {
            InitializeComponent();
            OcultarBotones();
            txtUsuario.Text = Logueo.UserName;
            txtUsuario.Enabled = false;
            
        }
        private frmMDI FrmParent { get; set; }
        private static frmCambiarClave _aForm;
        public static frmCambiarClave Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmCambiarClave(mdiPrincipal);
            _aForm = new frmCambiarClave(mdiPrincipal);
            return _aForm;
        }

        public frmCambiarClave(frmMDI padre)
        {
            InitializeComponent();
            OcultarBotones();
            txtUsuario.Text = Logueo.UserName;
            txtUsuario.Enabled = false;
                FrmParent = padre;        
            }

        private void cerrarFormulario() 
        {
            txtUsuario.Enabled = false;

            this.Close();
  
        }
        protected override void OnCancelar()
        {
            txtClavepasada.Text = "";
            txtClaveNueva2.Text = "";
            txtClaveNueva1.Text = "";
            this.Close();
        }
        bool validar() {
            if (txtClavepasada.Text.Length == 0) {
                MessageBox.Show("Ingresar clave anterior");
                return false;
            }

            if (txtClaveNueva1.Text.Length == 0 || txtClaveNueva2.Text.Length == 0) {
                MessageBox.Show("Ingresar claves anteriores");
                return false;
            }

            if (txtClavepasada.Text.Length == 0) {
                MessageBox.Show("Ingresar clave anterior");
                return false;
            }

            return true;

        }
        protected override void OnGuardar()
        {
            SegUsuario ent = new SegUsuario();
            if (!validar()) {
                return;
            }     
            ent.CodigoEmpresa = Logueo.CodigoEmpresa;
            ent.NombreUsuario = txtUsuario.Text;
            ent.ClaveUsuario = SegUsuarioLogic.Instance.Encripta(txtClaveNueva1.Text);
            if (txtClavepasada.Text != Logueo.clavePasada) {
                MessageBox.Show("Error:CLave anterior no coincide");
                return;
            }
            if (txtClaveNueva1.Text != txtClaveNueva2.Text) {
                MessageBox.Show("Error:Clave 1 y Clave 2 son diferentes");
                return;
            }
            ent.ClaveUsuario = SegUsuarioLogic.Instance.Encripta(txtClaveNueva1.Text);
            ent.CodigoEmpresa = Logueo.CodigoEmpresa;
            ent.CodigoPerfil = Logueo.codigoPerfil;
            string salida = string.Empty;
            
            SegUsuarioLogic.Instance.Spu_Seg_Actualizar_Clave(ent, out salida);
            MessageBox.Show(salida);
            txtClavepasada.Text = "";
            txtClaveNueva1.Text = "";
            txtClaveNueva2.Text = "";


        }

        private void Ctrl_Up(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);
        }

    }
}
