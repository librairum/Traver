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
using System.Linq;
using System.Data.Linq;
namespace Inv.UI.Win
{
    public partial class FrmCostoCantera : frmBaseMante
    {
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;
        CuentaCorriente cuenta = new CuentaCorriente();
        Sede sede = new Sede();
        private bool isLoaded = false;


        public FrmCostoCantera()
        {
            InitializeComponent();
        }

        private static FrmCostoCantera _aForm;
        private frmMDI frmParent { get; set; }

        public static FrmCostoCantera Instance(frmMDI formParent)
        {
            if (_aForm != null) return new FrmCostoCantera(formParent);
            _aForm = new FrmCostoCantera(formParent);
            return _aForm;
        }
        public FrmCostoCantera( frmMDI PADRE) 
        {
            InitializeComponent();
        }
        #region "metodos botones"
             

        void enfocaRegistroAnterior()
        {
            int indice = gridControl.MasterView.CurrentRow.Index;
    
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        protected override void OnEliminar()
        {
            try
            {
                if (gridControl.MasterView.Rows.Count == 0)
                    return;
                if (gridDetalle.MasterView.Rows.Count > 0)
                {
                    Util.ShowError("Debe eliminar los domicilios del destinario");
                    return;
                }


                string msj = string.Empty;
                int flag = 0;
                DialogResult res = MessageBox.Show("¿Desea eliminar el registro " + cuenta.ccm02cod + "?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    CuentaCorrienteLogic.Instance.Fac_CuentaCorrienteEliminar(cuenta, out flag, out msj);
                    MessageBox.Show(msj);
                    enfocaRegistroAnterior();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }
        }     


        #endregion



        #region "metodos formulario"

        //private void FrmCostoCantera_Load(object sender, EventArgs e)
        //{             
        //    Crearcolumnas();
        //    CrearcolumnasDet();
        //    Cargar();
        //    CargarDetalle();
        //    ////focoMenu();
        //    //ResaltarCajasAyuda();

        //}

        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "Codigo", "IN20CODIGO", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN20DESC", 0, "", 120, true, false, true);
            this.CreateGridColumn(grilla, "Año", "IN40ANIO", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Mes", "IN40MES", 0, "", 70, true, false, false);
            this.CreateGridColumn(grilla, "Importe", "IN40IMPORTE", 0, "", 100, true, false, true,true,alinear.derecha);
        }

        private void CrearcolumnasDet()
        {
            RadGridView grillaDet = this.CreateGridVista(this.gridDetalle);
            this.CreateGridColumn(grillaDet, "Anio", "IN40ANIO", 0, "", 30, true, false,false);
            this.CreateGridColumn(grillaDet, "MES", "IN40MES", 0, "", 80, true, false, false);
            this.CreateGridColumn(grillaDet, "CANTERA COD", "IN40CANTERACOD", 0, "", 20, true, false, false);
            this.CreateGridColumn(grillaDet, "Codigo", "IN40COSTOTIPOMPCOD", 0, "", 80, true, false, true);
            this.CreateGridColumn(grillaDet, "Descripcion", "glo01descripcion", 0, "", 150, true, false, true);
            this.CreateGridColumn(grillaDet, "Importe", "IN40IMPORTE", 0, "", 80, true, false, true,true, alinear.derecha);

            // Suma Importe 
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "IN40IMPORTE";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem() { summaryItem };
            //summaryRowItem.Add(summaryItem);

            grillaDet.SummaryRowsBottom.Add(summaryRowItem);


            grillaDet.MasterTemplate.ShowTotals = true;
            grillaDet.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            //this.gridControl.MasterView.SummaryRows[1].PinPosition = PinnedRowPosition.Bottom;
            //crearGrupos();
        }

        public void Cargar()
        {
            try
            {
            
                DataTable dt = AlmacenLogic.Instance.TraerCostoCantera(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                gridControl.DataSource = dt;
            }catch(Exception ex)
            {
                Util.ShowError("ERROR::"+ex.Message);
            }

        }
        public void CargarDetalle()
        {
            string IN20CODIGO = Util.GetCurrentCellText(gridControl.CurrentRow, "IN20CODIGO");
            DataTable dt = AlmacenLogic.Instance.TraerCostoCantera_Detalle(Logueo.CodigoEmpresa, Logueo.Anio,Logueo.Mes, IN20CODIGO);
            gridDetalle.DataSource = dt;
        }

        #endregion

        private void mostrarXocultaBtnDomicilio(bool valor)
        {
            btnNuevo.Visibility = valor == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnEditar.Visibility = valor == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnEliminar.Visibility = valor == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnGuardar.Visibility = valor == true ? ElementVisibility.Collapsed : ElementVisibility.Visible;
            btnCancelar.Visibility = valor == true ? ElementVisibility.Collapsed : ElementVisibility.Visible;

        }
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {

            frmBusqueda frm;

            string codigoSeleccionado = string.Empty;
            string codigoEmpresa = "", anio = "", mes = "", tipDoc = "", CodDoc = "";
            string codigoArticulo = "";
            string fechaDoc = "", codTransa = "", transa = "S", codAlm = "";

            string[] registrosSeleccionados = new string[2];
            //string[] datos;
            //double cantArt = 0;
            //string CodProd = "", uniMed = "", codAlm = "", nrocaja = "",;
            //string DocingAA = "", DocingMM = "", DocingTD = "", DocingPT = "";
            //string DocingNO = "", DocingCD = "", codCliente = "";
            //string canPiezas = "", canArea = "", AreaxUni = "";



            switch (tipoAyuda)
            {
                case enmAyuda.enmTipoCostoMP:

                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        registrosSeleccionados = frm.Result.ToString().Split('|');
                        txtCodigo.Text = registrosSeleccionados[0].ToString();
                        txtDescripcion.Text = registrosSeleccionados[1].ToString();
                    }
                    if (codigoSeleccionado != "")
                        this.txtCodigo.Text = codigoSeleccionado;
                    break;
            }
            this.KeyPreview = true;
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ActivarTxts(true);
            txtDescripcion.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            Estado = FormEstate.New;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtImporte.Text = "";
            ActivarAyuda(txtCodigo);
            txtCodigo.Focus();

        }
        public void ActivarTxts(bool valor) 
        {
            txtCodigo.Enabled = valor;
            txtDescripcion.Enabled = valor;
            txtImporte.Enabled = valor;
        }

        private void FrmCostoCantera_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            ActivarTxts(false);
            txtDescripcion.Enabled = false;
            Crearcolumnas();
            CrearcolumnasDet();
            Cargar();
            CargarDetalle();
            string Descripcion = "";
            txtCodigo.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40COSTOTIPOMPCOD");
            GlobalLogic.Instance.DameDescripcion("70" + txtCodigo.Text, "GLOTA", out Descripcion);
            txtDescripcion.Text = Descripcion;
            txtImporte.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40IMPORTE");
            
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            OcultaBarraBotones();
            OcultarBotones();
            ActivarAyuda(txtCodigo);

        }
        private void ActivarAyuda(RadTextBox nombreControl)
        {

            if (nombreControl.Enabled)
            {
                Util.ResaltarAyuda(nombreControl);
            }
            else
            {
                Util.ResetearAyuda(nombreControl);
            }


        }
        private void gridControl_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                CargarDetalle();
                string Descripcion = "";


                //string codigo = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40COSTOTIPOMPCOD");
                //GlobalLogic.Instance.DameDescripcion("70" + codigo, "GLOTA", out Descripcion);
                //Util.SetValueCurrentCellText(gridDetalle.CurrentRow, "IN40COSTOTIPOMPDESCRIPCION", Descripcion);



                //string Descripcion = "";
                //string Codigo = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40COSTOTIPOMPCOD");
                txtCodigo.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40COSTOTIPOMPCOD");
                GlobalLogic.Instance.DameDescripcion("70" + txtCodigo.Text, "GLOTA", out Descripcion);
                txtDescripcion.Text = Descripcion;
                txtImporte.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40IMPORTE");
 
            }
            catch(Exception ex)
            {
                Util.ShowError("ERROR::"+ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            ActivarTxts(false);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                if(txtCodigo.Text == "" || txtImporte.Text == "")
                {
                    Util.ShowError("ERROR:: Inserte los datos faltantes");
                    return;
                }
              
                string Codigo = txtCodigo.Text;
                bool IsNumerico = Util.IsNumerico(txtImporte.Text);
                if (IsNumerico == false)
                {
                    Util.ShowError("ERROR:: El importe ingresado no es un numerico");
                    return;
                }
                decimal Importe = Convert.ToDecimal(txtImporte.Text.ToString());
                 string IN20CODIGO = Util.GetCurrentCellText(gridControl.CurrentRow, "IN20CODIGO");
                 string Msg = "";
                 int @flag = 0;
                 if (Estado == FormEstate.New)
                 {
                     AlmacenLogic.Instance.Insertar_DetalleCantera(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, IN20CODIGO, Codigo, Importe, out Msg, out @flag);
                 }
                 else if (Estado == FormEstate.Edit) 
                 {
                     AlmacenLogic.Instance.Actualizar_DetalleCantera(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, IN20CODIGO, Codigo, Importe, out Msg, out @flag);
                 }
                  if (@flag == 1)
                 {
                     Util.ShowMessage(Msg, @flag);
                 }
                 else 
                 {
                     Util.ShowError(Msg);
                 }
                  CargarDetalle();
                  Cargar();
                  ActivarTxts(false);
                  btnGuardar.Enabled = false;
                  btnCancelar.Enabled = false;
                  btnNuevo.Enabled = true;
                  btnEditar.Enabled = true;
                  btnEliminar.Enabled = true;

            }catch(Exception ex)
            {
                Util.ShowError("ERROR::" + ex.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            ActivarTxts(true);
            txtDescripcion.Enabled = false;
            Estado = FormEstate.Edit;
            ActivarAyuda(txtCodigo);
            txtCodigo.Enabled = false;
            txtImporte.Focus();
        }

        private void gridDetalle_CellClick(object sender, GridViewCellEventArgs e)
        {
            txtCodigo.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40COSTOTIPOMPCOD");
            string Descripcion = "";
            GlobalLogic.Instance.DameDescripcion("70"+txtCodigo.Text,"GLOTA",out Descripcion);
            txtDescripcion.Text = Descripcion;
            txtImporte.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40IMPORTE");


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string IN40COSTOTIPOMPCOD = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40COSTOTIPOMPCOD");
                string IN40CANTERACOD = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN40CANTERACOD");
                if (gridControl.MasterView.Rows.Count == 0)
                    return;
                string msj = string.Empty;
                int flag = 0;
                DialogResult res = MessageBox.Show("¿Desea eliminar el registro?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    AlmacenLogic.Instance.Eliminar_DetalleCantera(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, IN40CANTERACOD, IN40COSTOTIPOMPCOD, out msj, out flag);
                    if (flag == 1)
                    {
                        Util.ShowMessage(msj,flag);

                    }
                    else 
                    {
                        Util.ShowError(msj);
                    }
                  
                }
                CargarDetalle();
                Cargar();
                ActivarTxts(false);
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                Limpiartxts(true);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }
        }
        public void Limpiartxts(bool Validar) 
        {
            if(Validar == true)
            {
                txtCodigo.Text = "";
                 txtDescripcion.Text = "";
                 txtImporte.Text = "";
            }
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmTipoCostoMP);
            }
         
        }

    }
}
