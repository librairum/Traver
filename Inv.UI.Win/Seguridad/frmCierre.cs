using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
namespace Inv.UI.Win
{
    public partial class frmCierre : Telerik.WinControls.UI.RadForm
    {

        public frmCierre(frmMDI padre)
        {
            InitializeComponent();
            txtAnioCerrar.Text = Logueo.Anio;
            txtAnioGenera.Text = (Convert.ToInt32(Logueo.Anio) + 1).ToString();
            
        }
        private frmMDI FrmParent { get; set; }
        private static frmCierre _aForm;
        public static frmCierre Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmCierre(mdiPrincipal);
            _aForm = new frmCierre(mdiPrincipal);
            return _aForm;
        }
        
    
        bool ValidarDatos() {
            
            if (txtAnioCerrar.Text == "")
            {
                MessageBox.Show("Seleccionar año de cierre");
                return false;
            }
            if (txtAnioGenera.Text == "") {
                MessageBox.Show("Seleccionar año a agenerar.");
                return false;
            }
            if (txtAnioCerrar.Text != Logueo.Anio)
            {
                MessageBox.Show("El Año a Cerrar debe pertenecer al periodo Actual ");
                return false;
            }
            if (txtAnioCerrar.TextLength < 4 || txtAnioGenera.TextLength < 4) {
                MessageBox.Show("El año tiene 4 digitos");
            } 
            if( Convert.ToInt32(txtAnioCerrar.Text) > Convert.ToInt32(txtAnioGenera.Text )
                || txtAnioCerrar.Text == txtAnioGenera.Text)
            {
                    MessageBox.Show("El Año a Generar debe ser mayor que el Año a Cerrar ");
                    return false;
            }
                
            return   true;
        }
      

        private void radCommandBar1_Click(object sender, EventArgs e)
        {

        }

        private void cbbGuardar_Click(object sender, EventArgs e)
        {           
                  if (!ValidarDatos()) 
                    return;
                
                DialogResult result = MessageBox.Show("Se va a generar maestros para el "+txtAnioCerrar.Text+
                    " basados en el " + txtAnioGenera.Text + " \nEsta seguro de generar estos maestros : ", "Sistema",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                  if (result == System.Windows.Forms.DialogResult.No) {
                      return;
                  }
                  float pRetorna = 0;
                  PeriodoLogic.Instance.GeneraPeriodoCierre(Logueo.CodigoEmpresa, txtAnioCerrar.Text, txtAnioGenera.Text, out pRetorna);
                  if (pRetorna == 0)
                  {
                      MessageBox.Show("OK :: El periodo ha sido generado.");
                  }
                  else
                  {
                      MessageBox.Show("ERROR :: No se puedo generar.");

                  }
           
        }

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCierre_KeyUp(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);
        }
    }
}
