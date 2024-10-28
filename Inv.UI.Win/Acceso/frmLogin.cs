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
namespace Inv.UI.Win.Acceso
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        public frmLogin()
        {
            InitializeComponent();
            try
            {
                string nombre = string.Empty;
                GlobalLogic.Instance.TraerNombreModulo(Logueo.codModulo, out nombre);
                this.Text = nombre;

                cboEmpresa.DataSource = SegUsuarioLogic.Instance.listar_empresa();
                cboEmpresa.ValueMember = "Codigo";
                cboEmpresa.DisplayMember = "Nombre";

                cboPerfil.DataSource = SegUsuarioLogic.Instance.listar_perfil();
                cboPerfil.ValueMember = "codigo";
                cboPerfil.DisplayMember = "nombre";
                txtUsuario.Focus();
                
                this.Activate();
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message  , "..::Error::.", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            
        }
        private bool Validar() {
            
            
            if (txtUsuario.Text.Length == 0)
            {
                RadMessageBox.Show("Ingresa usuario", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                txtUsuario.Focus();
                return false;
            }
            if (txtContrasenia.Text.Length == 0) {
                RadMessageBox.Show("Ingresar clave","Sistema",MessageBoxButtons.OK,RadMessageIcon.Info);
                txtContrasenia.Focus();
                return false;
            }
            return true;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
       
            try {
                if (!Validar())
                    return; 
                string encriptado = SegUsuarioLogic.Instance.Encripta(txtContrasenia.Text);
                var tabla = SegUsuarioLogic.Instance.Seg_Trae_Autenticacion_Usuario(txtUsuario.Text, encriptado,
                    cboEmpresa.SelectedValue.ToString());

                if (tabla.Count > 0)
                {
                    //MessageBox.Show("Bienvenido" + tabla[0].NombreUsuario);
                    // 01 -> Modulo Ventas (Inventario)
                    //Logueo.codModulo = "04";
                    //var tablaPermisos = SegMenuPorPerfilLogic.Instance.Trae_Menu_Por_Perfil(tabla[0].CodigoPerfil,Logueo.codModulo);
                    frmMDI m = new frmMDI(tabla[0].CodigoPerfil);
                    Logueo.UserName = txtUsuario.Text;
                    
                    //obtener descripcion de perfil
                    
                    Logueo.codigoPerfil = tabla[0].CodigoPerfil;
                    Logueo.nomPerfil = tabla[0].NomPerfil;
                    Logueo.UsuarioVerReporte = tabla[0].FlagVerReportesConImportes;
                    
                    Logueo.clavePasada =  txtContrasenia.Text;
                    Logueo.CodigoEmpresa = cboEmpresa.SelectedValue.ToString();
                    Logueo.NombreEmpresa = cboEmpresa.SelectedItem.ToString();
                    
                    string UbicacionDondeSeEjecutaElSistema = "";
                    GlobalLogic.Instance.DameDescripcion("ALMACEN" + Logueo.CodigoEmpresa, "UBISEDE", out UbicacionDondeSeEjecutaElSistema);
                   // Logueo.SedeDondeSeEjecuta = UbicacionDondeSeEjecutaElSistema;

                      //  private string TipoSedeEjecutaSistema = ConfigurationSettings.AppSettings["sedetipodondeseejecutaelsistema"];

                    Logueo.sedetipodondeseejecutaelsistema = ConfigurationSettings.AppSettings["sedetipodondeseejecutaelsistema"];

                    
                    m.Show();
                    this.Hide();
                    this.txtUsuario.Clear();
                    this.txtContrasenia.Clear();
                }
                else {
                    RadMessageBox.Show("Los credenciales no son validas", "Sistem",
                        MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }
                
            }catch(Exception ex){                
            }           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {           
            
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void frmLogin_KeyUp(object sender, KeyEventArgs e)
        {
            //if (ActiveControl is Telerik.WinControls.UI.RadLabel)
            //{ 
            
            //}
            
            //if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
            //{
            //    if (ActiveControl is Telerik.WinControls.UI.RadDropDownList) 
            //    {
            //        RadMessageBox.Show("El ultimo control es un combo", "Sistema");
            //    }
            //    if (ActiveControl.TabIndex == this.Controls.Count)
            //    {
            //        RadMessageBox.Show("El ultimo control de tab Index", "Sistema");
            //    }
            //    else {
            //        Util.enfocar(ActiveControl, GetNextControl(ActiveControl, true), e, this);
            //    } 
            //    //if(this.ActiveControl.TabIndex
            
            //}
            if (btnIngresar.Focused)
            {
                btnIngresar_Click(null, null);
                txtUsuario.Focus();
            }
        }
        void enfocarControl(KeyEventArgs evento) {
            if (evento.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
                return;
            }
            if (evento.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
                return;
            }
            if (evento.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Down)
            {
                txtContrasenia.Focus();
            }
        }

        private void txtContrasenia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Down)
            {
                btnIngresar.Focus();
            }
            //enfocarControl(e);
        }

    }
}
