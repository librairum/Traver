﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Prod.UI.Win.Acceso
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        public frmLogin()
        {
            InitializeComponent();
            cboEmpresa.DataSource = SegUsuarioLogic.Instance.listar_empresa();
            cboEmpresa.ValueMember = "Codigo";
            cboEmpresa.DisplayMember = "Nombre";
            string nombre = string.Empty;
            GlobalLogic.Instance.TraerNombreModulo(Logueo.codModulo, out nombre);
            
            this.Text = nombre;
            
            //cboPerfil.DataSource = SegUsuarioLogic.Instance.listar_perfil();
            //cboPerfil.ValueMember = "codigo";
            //cboPerfil.DisplayMember = "nombre";
            txtUsuario.Focus();
            this.Activate();
        }
        private bool Validar()
        {
            if (txtUsuario.Text.Length == 0)
            {
                RadMessageBox.Show("Ingresa usuario", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            if (txtContrasenia.Text.Length == 0)
            {
                RadMessageBox.Show("Ingresar clave", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
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

                if (tabla.Count > 0)
                {
                    //MessageBox.Show("Bienvenido" + tabla[0].NombreUsuario);
                    // 01 -> Modulo Ventas (Inventario)
                    
                    var tablaPermisos = SegMenuPorPerfilLogic.Instance.Trae_Menu_Por_Perfil(tabla[0].CodigoPerfil, Logueo.codModulo);
                    frmMDI m = new frmMDI(tabla[0].CodigoPerfil);
                    Logueo.UserName = txtUsuario.Text.Trim().ToLower();
                    Logueo.codigoPerfil = tabla[0].CodigoPerfil;
                    Logueo.nomPerfil = tabla[0].NomPerfil;
                    //Logueo.NombreEmpresa = tabla[0].NomEmpresa;
                    Logueo.clavePasada = txtContrasenia.Text;
                    Logueo.CodigoEmpresa = cboEmpresa.SelectedValue.ToString();
                    m.Show();
                    this.Hide();
                    this.txtUsuario.Clear();
                    this.txtContrasenia.Clear();
                }
                else
                {
                    RadMessageBox.Show("Los credenciales no son validas", "Sistem",
                        MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }    
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)(e.KeyChar) == Keys.Enter)
            {
                txtContrasenia.Focus();
            }
        }

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Keys)e.KeyChar) == Keys.Enter)
            {
                btnIngresar_Click(null, null);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
