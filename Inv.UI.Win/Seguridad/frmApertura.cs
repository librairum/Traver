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
    public partial class frmApertura : Telerik.WinControls.UI.RadForm
    {
        

        public frmApertura(frmMDI principal) {
            InitializeComponent();            
            CargarPeriodos();
            txtAnioApertura.Text = (Convert.ToInt32(Logueo.Anio) + 1).ToString();
            txtAnioCerrar.Text = Logueo.Anio;;
        }
        private frmMDI FrmParent { get; set; }
        private static frmApertura _aForm;
        public static frmApertura Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmApertura(mdiPrincipal);
            _aForm = new frmApertura(mdiPrincipal);
            return _aForm;
        }
        bool ValidarDatos()
        {
            string anio = ddlPeriodo.SelectedValue.ToString().Substring(0, 4);
            if (txtAnioCerrar.Text == "")
            {
                MessageBox.Show("Seleccionar año de cierre");
                return false;
            }
            if (txtAnioApertura.Text == "")
            {
                MessageBox.Show("Ingresar año de apertura.");
                return false;
            }
            if (txtAnioCerrar.Text != anio)
            {
                MessageBox.Show("El Año a Cerrar debe pertenecer al periodo Actual ");
                return false;
            }
            if (txtAnioCerrar.TextLength < 4 || txtAnioApertura.TextLength < 4)
            {
                MessageBox.Show("El año tiene 4 digitos");
            }
            if (Convert.ToInt32(txtAnioCerrar.Text) > Convert.ToInt32(txtAnioApertura.Text)
                || txtAnioCerrar.Text == txtAnioApertura.Text)
            {
                MessageBox.Show("El Año a Generar debe ser mayor que el Año a Cerrar ");
                return false;
            }

            return true;
        }
       
        private void CargarPeriodos()
        {
            try
            {
                var periodo = PeriodoLogic.Instance.PeriodoTraerTodos(Logueo.CodigoEmpresa);
                ddlPeriodo.DataSource = periodo;
                ddlPeriodo.DisplayMember = "ccb03des";
                ddlPeriodo.ValueMember = "ccb03cod";


                string anio = "";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();

                //ddlPeriodo.SelectedValue = anio + mes;
                ddlPeriodo.SelectedValue = Logueo.Anio + "12";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbbGuardar_Click(object sender, EventArgs e)
        {
            //    Logueo.Anio = this.cboperiodos.SelectedValue.ToString().Substring(0,4);
            //Logueo.Mes = this.cboperiodos.SelectedValue.ToString().Substring(4, 2);
            
            if (!ValidarDatos())
                return;
            DialogResult result = MessageBox.Show("Se va actulizar los saldo iniciales del año '" + txtAnioApertura.Text +
                   "' a partir del saldo final del año '" + txtAnioCerrar.Text + "' \nEsta seguro de aperturar :  ", "Sistema",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string anio = ddlPeriodo.SelectedValue.ToString().Substring(0,4);
            string mes =  ddlPeriodo.SelectedValue.ToString().Substring(4,2);
            float nRetornar = 0;
            PeriodoLogic.Instance.GeneraPeriodoApertura(Logueo.CodigoEmpresa, anio, txtAnioApertura.Text, mes, out  nRetornar);
            
            if (nRetornar == 0)
            {
                MessageBox.Show("OK :: Se aperturo correctamente"); 
            }
            else if (nRetornar == 1)
            {
                MessageBox.Show("ERROR :: No se pudo aperturar");
            }
        }

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlPeriodo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlPeriodo.SelectedValue != null) { 
                
            }
        }

        private void frmApertura_KeyUp(object sender, KeyEventArgs e)
        {
            Util.SendEnter(e, ActiveControl, this);
        }
        //void cargarAnhos()
        //{
        //    for (int i = 2004; i <= DateTime.Now.Year; i++)
        //    {
        //        ddlAnhoCierre.Items.Add(i.ToString());
        //        ddlAnhoApertura.Items.Add(i.ToString());
        //    }

        //}
    }
}
