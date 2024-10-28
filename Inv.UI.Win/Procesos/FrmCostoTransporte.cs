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
    public partial class FrmCostoTransporte : frmBaseMante
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


        public FrmCostoTransporte()
        {
            InitializeComponent();
        }

        private static FrmCostoTransporte _aForm;
        private frmMDI frmParent { get; set; }

        public static FrmCostoTransporte Instance(frmMDI formParent)
        {
            if (_aForm != null) return new FrmCostoTransporte(formParent);
            _aForm = new FrmCostoTransporte(formParent);
            return _aForm;
        }
        public FrmCostoTransporte( frmMDI PADRE) 
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

        //private void FrmCostoTransporte_Load(object sender, EventArgs e)
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
            
            this.CreateGridColumn(grilla, "Importe", "IN41IMPORTE", 0, "", 60, true, false, true,true,alinear.derecha);
        }

        private void CrearcolumnasDet()
        {
            RadGridView grillaDet = this.CreateGridVista(this.gridDetalle);
            this.CreateGridColumn(grillaDet, "Cod Cantera", "IN41CANTERACOD", 0, "", 80, true, false, false);
            this.CreateGridColumn(grillaDet, "Cod Bloque", "IN41BLOQUEMPCOD", 0, "", 80, true, false, true);
            this.CreateGridColumn(grillaDet, "Cantidad", "IN41BLOQUEMPCANTIDAD", 0, "", 80, true, false, true,true,alinear.derecha);
            this.CreateGridColumn(grillaDet, "Tipo Costo", "IN41COSTOTIPOMPCOD", 0, "", 200, true, false, true);
            this.CreateGridColumn(grillaDet, "Nro Cliente", "IN41CODCTE", 0, "", 200, true, false, true);
            this.CreateGridColumn(grillaDet, "Tipo Doc", "IN41TIPDOC", 0, "", 200, true, false, true, true);
            this.CreateGridColumn(grillaDet, "Nro Documento", "IN41NRODOC", 0, "", 80, true, false, true);
            this.CreateGridColumn(grillaDet, "Importe", "IN41IMPORTE", 0, "", 80, true, false, true, true, alinear.derecha);

            // Suma Importe 
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "IN41IMPORTE";
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
            DataTable dt = AlmacenLogic.Instance.TraerCostoTransporte(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            gridControl.DataSource = dt;

        }
        public void CargarDetalle()
        {
            string IN20CODIGO = Util.GetCurrentCellText(gridControl.CurrentRow, "IN20CODIGO");
            
            DataTable dt = AlmacenLogic.Instance.TraerCostoTransporte_Detalle(Logueo.CodigoEmpresa, Logueo.Anio,Logueo.Mes, IN20CODIGO);
            gridDetalle.DataSource = dt;
        }

        #endregion

        private void txtdomiclioCod_KeyDown(object sender, KeyEventArgs e)
        {
            MostrarAyuda(enmAyuda.enmTipoCostoMP);
        }
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
                case enmAyuda.enmUniMed:
                     frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        registrosSeleccionados = frm.Result.ToString().Split('|');
                        txtUniMed.Text = registrosSeleccionados[0].ToString();
                    }
                    break;
                case enmAyuda.enmTipoCostoMP:

                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        registrosSeleccionados = frm.Result.ToString().Split('|');
                        txtTipCosto.Text = registrosSeleccionados[0].ToString();
                        txtTipoCostoDesc.Text = registrosSeleccionados[1].ToString();
                    }
                    if (codigoSeleccionado != "")
                        this.txtCodigo.Text = codigoSeleccionado;
                    break;
                case enmAyuda.enmBloquesCosteo:

                       frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        registrosSeleccionados = frm.Result.ToString().Split('|');
                        txtUniMed.Text = registrosSeleccionados[2].ToString();
                        txtCantidad.Text = registrosSeleccionados[3].ToString();
                        txtNroBloque.Text = registrosSeleccionados[0].ToString();
                        txtDescBloque.Text = registrosSeleccionados[1].ToString();
                        //txtCodigo.Text = registrosSeleccionados[0].ToString();
                        //txtDescripcion.Text = registrosSeleccionados[1].ToString();
                    }
                    break;
                case enmAyuda.enmFactTransportBloques:

                          frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                    {
                        registrosSeleccionados = frm.Result.ToString().Split('|');
                        txtTipDoc.Text = registrosSeleccionados[0].ToString();
                        txtNroDoc.Text = registrosSeleccionados[1].ToString();
                        txtcodcte.Text = registrosSeleccionados[2].ToString();
                        txtMoneda.Text = registrosSeleccionados[4].ToString();
                        txtImporte.Text = registrosSeleccionados[5].ToString();
                        txtConcepto.Text = registrosSeleccionados[6].ToString();
                        txtDescripcion.Text = registrosSeleccionados[7].ToString();
                        //txtUniMed.Text = registrosSeleccionados[2].ToString();
                        //txtCantidad.Text = registrosSeleccionados[3].ToString();
                        //txtNroBloque.Text = registrosSeleccionados[0].ToString();
                        //txtDescBloque.Text = registrosSeleccionados[1].ToString();
                        //txtCodigo.Text = registrosSeleccionados[0].ToString();
                        //txtDescripcion.Text = registrosSeleccionados[1].ToString();
                    }
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
            txtTipDoc.Text = "";
            ActivarAyuda(txtCodigo);
            ActivarAyuda(txtCodBloque);
            LimpiarTxts(true);

        }
        public void ActivarTxts(bool valorenabled) 
        {

            txtNroBloque.Enabled = valorenabled;
            txtDescBloque.Enabled = valorenabled;
            txtUniMed.Enabled = valorenabled;
            txtTipDoc.Enabled = valorenabled;
            txtNroDoc.Enabled = valorenabled;
            txtcodcte.Enabled = valorenabled;
            txtConcepto.Enabled = valorenabled;
            txtMoneda.Enabled = valorenabled;
            txtCantidad.Enabled = valorenabled;
            txtImporte.Enabled = valorenabled;
            txtTipCosto.Enabled = valorenabled;
            txtTipoCostoDesc.Enabled = valorenabled;
           // txtDescripcionBloque.Enabled = valor;
        }
        public void LimpiarTxts(bool valor) 
        {
            if (valor == true)
            {
                txtNroBloque.Text = "";
                txtDescBloque.Text = "";
                txtUniMed.Text = "";
                txtTipDoc.Text = "";
                txtNroDoc.Text = "";
                txtcodcte.Text = "";
                txtConcepto.Text = "";
                txtMoneda.Text = "";
                txtCantidad.Text = "";
                txtImporte.Text = "";
                txtTipDoc.Text = "";
                txtTipoCostoDesc.Text = "";
                txtTipCosto.Text = "";
                //txtDescripcionBloque.Text = "";
            }
            else 
            {
                return;
            }
          
        }
        private void FrmCostoTransporte_Load(object sender, EventArgs e)
        {
            ActivarTxts(true);
           // txtDescripcion.Enabled = false;
            Crearcolumnas();
            CrearcolumnasDet();
            Cargar();
            CargarDetalle();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            OcultaBarraBotones();
            OcultarBotones();

            ActivarAyuda(txtNroBloque);
            ActivarAyuda(txtTipDoc);
            ActivarAyuda(txtTipCosto);
            ActivarAyuda(txtUniMed);
            LimpiarTxts(true);
            ActivarTxts(false);
           

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
            CargarDetalle();
            txtTipCosto.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41COSTOTIPOMPCOD");
            string Descripcion = "";
            GlobalLogic.Instance.DameDescripcion("70" + txtTipCosto.Text, "GLOTA", out Descripcion);
            txtTipoCostoDesc.Text = Descripcion;

            txtNroBloque.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41BLOQUEMPCOD");
            txtCantidad.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41BLOQUEMPCANTIDAD");
            txtcodcte.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41CODCTE");
            txtTipDoc.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41TIPDOC");
            txtNroDoc.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41NRODOC");
            txtImporte.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41IMPORTE");
            DataTable dt = AlmacenLogic.Instance.Traer_BloqueCosteo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            var filasfiltradas = from DataRow fila in dt.Rows
                                 where fila.Field<string>("IN07CODBLOQUEEMP") == txtNroBloque.Text
                                 select fila;

            foreach (DataRow fila in filasfiltradas)
            {
                txtUniMed.Text = fila["IN07UNIMED"].ToString();
                txtDescBloque.Text = fila["IN01DESLAR"].ToString();

            }

            DataTable dtfactbloques = AlmacenLogic.Instance.Traer_FactTransporteBloques(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            var filasfiltradasfactbloques = from DataRow fila in dtfactbloques.Rows
                                            where fila.Field<string>("CO05NRODOC") == txtNroDoc.Text
                                            select fila;

            foreach (DataRow fila in filasfiltradasfactbloques)
            {
                txtConcepto.Text = fila["Concepto"].ToString();
                txtMoneda.Text = fila["CO05MONEDA"].ToString();
                //txtUniMed.Text = fila["IN07UNIMED"].ToString();
                //txtDescBloque.Text = fila["IN01DESLAR"].ToString();

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
                //if(txtCodigo.Text == "" || txtTipDoc.Text == "")
                //{
                //    Util.ShowError("ERROR:: Inserte los datos faltantes");
                //    return;
                //}
                string Codigo = txtCodigo.Text;
                decimal Importe = Convert.ToDecimal(txtTipDoc.Text.ToString());
                 string IN20CODIGO = Util.GetCurrentCellText(gridControl.CurrentRow, "IN20CODIGO");
                 string IN41BLOQUEMPCOD = txtCodBloque.Text;
                 decimal IN41BLOQUEMPCANTIDAD = Convert.ToDecimal(txtCantidad.Text);
                 string Msg = "";
                 int @flag = 0;
                 if (Estado == FormEstate.New)
                 {
                     AlmacenLogic.Instance.Insertar_DetalleTransporte(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, IN20CODIGO,txtNroBloque.Text,Convert.ToDecimal(txtCantidad.Text),txtTipCosto.Text,txtcodcte.Text,txtTipDoc.Text,txtNroDoc.Text,Convert.ToDecimal(txtImporte.Text),out Msg, out flag);
                 }
                 else if (Estado == FormEstate.Edit) 
                 {
                     AlmacenLogic.Instance.Actualizar_DetalleTransporte(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, IN20CODIGO, txtNroBloque.Text, Convert.ToDecimal(txtCantidad.Text), txtTipCosto.Text, txtcodcte.Text, txtTipDoc.Text, txtNroDoc.Text, Convert.ToDecimal(txtImporte.Text), out Msg, out flag);
                 }
                  if (@flag == 1)
                 {
                     Util.ShowMessage(Msg, @flag);
                     LimpiarTxts(true);

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
                  LimpiarTxts(true);
                  ActivarTxts(false);
                

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
            txtDescripcion.Enabled = false;
            Estado = FormEstate.Edit;
            ActivarAyuda(txtCodigo);
            ActivarAyuda(txtCodBloque);
            txtNroBloque.Enabled = false;
            txtDescBloque.Enabled = false;
            txtUniMed.Enabled = false;
            txtTipDoc.Enabled = false;
            txtNroDoc.Enabled = false;
            txtcodcte.Enabled = false;
            txtConcepto.Enabled = false;
            txtMoneda.Enabled = false;
            txtCantidad.Enabled = true;
            txtImporte.Enabled = true;
        }

        private void gridDetalle_CellClick(object sender, GridViewCellEventArgs e)
        {
            txtTipCosto.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41COSTOTIPOMPCOD");
            string Descripcion = "";
            GlobalLogic.Instance.DameDescripcion("70" + txtTipCosto.Text, "GLOTA", out Descripcion);
            txtTipoCostoDesc.Text = Descripcion;

            txtNroBloque.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41BLOQUEMPCOD");
            txtCantidad.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41BLOQUEMPCANTIDAD");
            txtcodcte.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41CODCTE");
            txtTipDoc.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41TIPDOC");
            txtNroDoc.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41NRODOC");
            txtImporte.Text = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41IMPORTE");
            DataTable dt = AlmacenLogic.Instance.Traer_BloqueCosteo(Logueo.CodigoEmpresa,Logueo.Anio,Logueo.Mes);
            var filasfiltradas = from DataRow fila in dt.Rows
                                 where fila.Field<string>("IN07CODBLOQUEEMP") == txtNroBloque.Text
                                 select fila;
        
            foreach(DataRow fila in filasfiltradas)
            {
                txtUniMed.Text = fila["IN07UNIMED"].ToString();
                txtDescBloque.Text = fila["IN01DESLAR"].ToString();

            }

            DataTable dtfactbloques = AlmacenLogic.Instance.Traer_FactTransporteBloques(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            var filasfiltradasfactbloques = from DataRow fila in dtfactbloques.Rows
                                 where fila.Field<string>("CO05NRODOC") == txtNroDoc.Text
                                 select fila;

            foreach (DataRow fila in filasfiltradasfactbloques)
            {
                txtConcepto.Text = fila["Concepto"].ToString();
                txtMoneda.Text = fila["CO05MONEDA"].ToString();
                //txtUniMed.Text = fila["IN07UNIMED"].ToString();
                //txtDescBloque.Text = fila["IN01DESLAR"].ToString();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
              //  string IN40COSTOTIPOMPCOD = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41COSTOTIPOMPCOD");
                string IN40CANTERACOD = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41CANTERACOD");
                string IN41BLOQUEMPCOD = txtNroBloque.Text;
                string IN41CODCTE = txtcodcte.Text;
                string IN41TIPDOC = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41TIPDOC");
                string IN41NRODOC = Util.GetCurrentCellText(gridDetalle.CurrentRow, "IN41NRODOC");
                if (gridControl.MasterView.Rows.Count == 0)
                    return;
                string msj = string.Empty;
                int flag = 0;
                DialogResult res = MessageBox.Show("¿Desea eliminar el registro?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    AlmacenLogic.Instance.Eliminar_DetalleTransporte(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, IN40CANTERACOD,IN41BLOQUEMPCOD,IN41CODCTE,IN41TIPDOC,IN41NRODOC, out msj, out flag);
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
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }
        }

        private void txtNroBloque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmBloquesCosteo);
                txtTipDoc.Focus();
            }
        }

        private void txtRefIngCod_KeyDown(object sender, KeyEventArgs e)
        {
 
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmFactTransportBloques);
            }
        }

        private void radTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmTipoCostoMP);
            }
        }

        private void txtUniMed_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (char)Keys.F1)
            {
                MostrarAyuda(enmAyuda.enmUniMed);
            }
            }
            catch(Exception ex)
            {
                Util.ShowError("ERROR :: Algo sucedio");
            }
        }



    }
}
