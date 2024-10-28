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
using System.Reflection;
using System.Data.Linq;
using System.Linq;
using Telerik.WinControls.Primitives;
namespace Fac.UI.Win.Maestros
{
    public partial class frmVehiculo : frmBaseMante
    {
        private bool isLoaded = false;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        CommandBarStripElement menu;
        Vehiculo vehiculo = new Vehiculo();
        public frmVehiculo()
        {
            InitializeComponent();
        }
        void removerBordes(RadPanel panel) {
            panel.PanelElement.PanelBorder.BoxStyle = BorderBoxStyle.FourBorders;
            panel.PanelElement.PanelBorder.TopWidth = 1;
            panel.PanelElement.PanelBorder.BottomWidth = 0;
            panel.PanelElement.PanelBorder.LeftWidth = 0;
            panel.PanelElement.PanelBorder.RightWidth = 0;
            panel.PanelElement.PanelText.TextAlignment = ContentAlignment.TopCenter;
       
        }
        public frmVehiculo(frmMDI formularioPadre)
        {
            InitializeComponent();
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            txtCodigo.MaxLength = 4;
            txtCodTransportista.MaxLength = 11;
            txtCodConductor.MaxLength = 8;
                    
            
        }
        
        private static frmVehiculo _aForm;
        private frmMDI frmParent { get; set; }
        public static frmVehiculo Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmVehiculo(formParent);
            _aForm = new frmVehiculo(formParent);
            return _aForm;
        }
       
        #region "metodos formulario"
       
        private void frmVehiculo_Load(object sender, EventArgs e)
        {
            crearcolumnas();
            OnCargar();
            Estado = FormEstate.List;
            deshabilitaBotones();
            habilitaCtrl(false);
            isLoaded = true;
            gestionarBotones(true, true, true, false, false);
            if (gridControl.RowCount > 0)
            { CargarRegistro(); }
            
           
        }
        private void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtDesTransp.Text = "";
            txtDesConductor.Text="";
            txtPlaca.Text = "";
            txtMarcaRemolque.Text = "";
            txtPlacaSemi.Text = "";
            txtMarcaSemi.Text = "";
            txtCodConductor.Text = "";
            txtCodTransportista.Text = "";            
        }
        private void habilitaCtrl(bool valor)
        {
            txtCodigo.Enabled = valor;
            //txtDescripcion.Enabled = valor;
            txtPlaca.Enabled = valor;
            txtMarcaRemolque.Enabled = valor;
            txtPlacaSemi.Enabled = valor;
            txtMarcaSemi.Enabled = valor;
            txtCodTransportista.Enabled = valor;
            txtCodConductor.Enabled = valor;
        }

        private void deshabilitaBotones()
        {
            gestionarBotones(true, true, true, true, true);
        }
        #endregion

        #region "metodos botones"
   
        private void crearcolumnas()
        {
            RadGridView dgv = CreateGridVista(gridControl);
            
            CreateGridColumn(dgv, "CodEmp", "FAC69Empresa", 0, "", 100,true,false,false);
            
            CreateGridColumn(dgv, "Codigo", "FAC69codigo", 0, "", 100);
            CreateGridColumn(dgv, "Marca", "FAC69MarcaRemolque", 0, "", 100);
            CreateGridColumn(dgv, "Placa", "FAC69PlacaRemolque", 0, "", 100);
            CreateGridColumn(dgv, "Transportista", "FAC69CodTransportista", 0, "", 100);
            CreateGridColumn(dgv, "Conductor",  "FAC69Codchofer", 0,"",100);
            CreateGridColumn(dgv, "Marca Semi",  "FAC69MarcaSemiRemolque", 0,"",200,true,false,false);
            CreateGridColumn(dgv, "Placa Semi",  "FAC69PlacaSemiRemolque", 0,"",200,true,false,false);
            //CreateGridColumn(dgv, "", "codigoVehiculo", 0, "", 1, true, false, true);
        }
        private void OnCargar() {            
            var lista = VehiculoLogic.Instance.TraerVehiculo(Logueo.CodigoEmpresa, "", "*");
            this.gridControl.DataSource = lista;         
        }
      
        private void CargarRegistro()
        {
            try
            {
                if (gridControl.RowCount == 0)
                    return;

                GridViewRowInfo fila = gridControl.CurrentRow;
                txtCodigo.Text = fila.Cells["FAC69codigo"].Value.ToString();
                txtMarcaRemolque.Text = fila.Cells["FAC69MarcaRemolque"].Value.ToString();
                txtPlaca.Text = fila.Cells["FAC69PlacaRemolque"].Value.ToString();

                txtDescripcion.Text = txtMarcaRemolque.Text + " " + txtPlaca.Text;

                txtCodTransportista.Text = fila.Cells["FAC69CodTransportista"].Value.ToString();
                txtCodConductor.Text = fila.Cells["FAC69Codchofer"].Value.ToString();
                txtMarcaSemi.Text = fila.Cells["FAC69MarcaSemiRemolque"].Value == null ? "" : fila.Cells["FAC69MarcaSemiRemolque"].Value.ToString();
                txtPlacaSemi.Text = fila.Cells["FAC69PlacaSemiRemolque"].Value == null ? "" : fila.Cells["FAC69PlacaSemiRemolque"].Value.ToString();
            }
            catch (Exception ex) { 
            
            }                                    
        }

        private bool Validar()
        {
            cbbGuardar.IsMouseOver = false;
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim())) {
                MessageBox.Show("Ingresar codigo");
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMarcaRemolque.Text.Trim()))
            {
                txtMarcaRemolque.Focus();
                MessageBox.Show("Ingresar Marca remolque.");
                return false;
            }
            if (string.IsNullOrEmpty(txtPlaca.Text.Trim()))
            {
                txtPlaca.Focus();
                MessageBox.Show("Ingresar placa remoqule");
                return false;
            }
            if (string.IsNullOrEmpty(txtDesConductor.Text.Trim()) || txtDesConductor.Text.Trim() == "???")
            {
                txtCodConductor.Focus();
                MessageBox.Show("Ingresar un conductor");
                return false;
            }
            if (string.IsNullOrEmpty(txtDesTransp.Text.Trim()) || txtDesTransp.Text == "???")
            {
                txtCodTransportista.Focus();
                MessageBox.Show("Ingresar un transportista");
                return false;
            }
            
            return true;
        }
        protected override void OnNuevo()
        {            
            Estado = FormEstate.New;
            limpiar();
            habilitaCtrl(true);
            
            string nuevoCodigo = ""; int flagSalida = 0; string mensajeSalida = "";

            VehiculoLogic.Instance.TraerCodigoVehiculo(Logueo.CodigoEmpresa, out nuevoCodigo, out flagSalida, out mensajeSalida);
            txtCodigo.Focus();
            txtCodigo.Text = nuevoCodigo;
            gestionarBotones(false, false, false, true, true);
          
        }

        protected override void OnEditar()
        {
            if (gridControl.MasterView.Rows.Count == 0) return;
            Estado = FormEstate.Edit;
            habilitaCtrl(true);
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtDescripcion.Focus();
            gestionarBotones(false, false, false, true, true);            
        }

        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            limpiar();
            habilitaCtrl(false);
            CargarRegistro();
            gestionarBotones(true, true, true, false, false);            
        }
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.CurrentRow.Index;
            OnCargar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        void cargarEntidad() {
            
            vehiculo.FAC69Empresa = Logueo.CodigoEmpresa;
            vehiculo.FAC69codigo = txtCodigo.Text.Trim();
            vehiculo.FAC69MarcaRemolque = txtMarcaRemolque.Text.Trim();
            vehiculo.FAC69PlacaRemolque = txtPlaca.Text.Trim();
            vehiculo.FAC69CodTransportista = txtCodTransportista.Text.Trim();
            vehiculo.FAC69Codchofer = txtCodConductor.Text.Trim();
            vehiculo.FAC69MarcaSemiRemolque = txtMarcaSemi.Text.Trim();
            vehiculo.FAC69PlacaSemiRemolque = txtPlacaSemi.Text.Trim();
            
        }
        protected override void OnEliminar()
        {            
            if (gridControl.MasterView.Rows.Count == 0)
                return;
            cargarEntidad();
            DialogResult res = MessageBox.Show("¿Está seguro de eliminar registro : " + vehiculo.FAC69codigo + "?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                string msj = string.Empty;
                VehiculoLogic.Instance.EliminarVehiculo(vehiculo, out msj);               
                MessageBox.Show(msj);
                enfocaRegistroAnterior();
            }
     
        }
    
        protected override void OnGuardar()
        {
            try
            {                
                if (!Validar())
                    return;
                cargarEntidad();          

                string msj = string.Empty;
                if (Estado == FormEstate.New)
                {
                    VehiculoLogic.Instance.InsertarVehiculo(vehiculo, out msj);
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                }
                else if (Estado == FormEstate.Edit)
                {
                    VehiculoLogic.Instance.ActualizarVehiculo(vehiculo, out msj);
                    cbbNuevo.IsMouseOver = false;                    
                }

                MessageBox.Show(msj);
                //enfocaBotonNuevo();
                OnCancelar();
                OnCargar();

                Util.enfocarFila(this.gridControl, "FAC69codigo", vehiculo.FAC69codigo);

                Estado = FormEstate.List;
                cbbGuardar.IsMouseOver = false;
            }
            catch (Exception ex) {
                OnCancelar();
            }       
            
        }

        #endregion

        private void txtTransportista_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            if (Estado == FormEstate.New) return;
            if (txtCodTransportista.Text.Length == 0 || string.IsNullOrEmpty(txtCodTransportista.Text.Trim())) {
                txtDesTransp.Text = "";
                return;
            }            
            
            string nombre = string.Empty;
            string cCodigo = Logueo.CodigoEmpresa+"11"+txtCodTransportista.Text.Trim();
            Fac_GuiaTransporteLogic.Instance.Dame_Descripcion(cCodigo, "1026", out nombre);
            
            txtDesTransp.Text = nombre;

            /*
             Private Sub txtcodtransportista_LostFocus()
LblHelp(0).Caption = DameDescripcion(gbCodEmpresa + Trim(txtcodtransportista.Text), "1026")
             */
        }

        private void txtCodConductor_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            if (txtCodConductor.Text.Length == 0 || string.IsNullOrEmpty(txtCodConductor.Text)) {
                txtDesConductor.Text = "";
                return;
            }
            
            string nombre = string.Empty;
            Fac_GuiaTransporteLogic.Instance.Dame_Descripcion(Logueo.CodigoEmpresa+txtCodConductor.Text, "1016", out nombre);
            txtDesConductor.Text = nombre;

        }

        private void txtTransportista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) {
               frmBusqueda frm = new   frmBusqueda(enmAyuda.enmBuscaTransportista);
               frm.ShowDialog();
               if (frm.Result != null) {
                   txtCodTransportista.Text = ((CuentaCorriente)frm.Result).ccm02cod;
                   txtDesTransp.Text = ((CuentaCorriente)frm.Result).ccm02nom;
               }
            }
        }

        private void txtCodConductor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmBusqueda frm = new frmBusqueda(enmAyuda.enmBuscaConductor);
                frm.ShowDialog();
                if (frm.Result != null)
                {
                    txtCodConductor.Text = ((CuentaCorriente)frm.Result).ccm02cod;
                    txtDesConductor.Text = ((CuentaCorriente)frm.Result).ccm02nom;
                }
            }
        }
     
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            try
            {
                if (!isLoaded) return;
                if (Estado == FormEstate.New) return;
                var row = e.CurrentRow.Cells;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["FAC69codigo"].Value != null)
                    {
                        CargarRegistro();
                    }
                }
            }
            catch (Exception ex)
            {

            }
     
        }
      
        private void radButton1_Click(object sender, EventArgs e)
        {                       
        }
        
        private void radGroupBox1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnlCabecera_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
