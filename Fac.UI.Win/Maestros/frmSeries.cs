using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Fac.UI.Win.Maestros
{
    public partial class frmSeries : frmBaseMante
    {
        bool isLoaded = false;
        public frmSeries()
        {
            InitializeComponent();
        }
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbGrabar;
        Series serie = new Series();
        private static frmSeries _aForm;

        private frmMDI frmParent { get; set; }

        public static frmSeries Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmSeries(formParent);
            _aForm = new frmSeries(formParent);
            return _aForm;
        }

        void iniciarfrmSerie() { 
        
        }
        public frmSeries(frmMDI frmPadre) 
        {
            InitializeComponent();
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbGrabar = menu.Items["cbbGuardar"];
            crearColumnas();
            BaseHabilitarCajas(this, false);
            txtAyudaEstablecimientoDesc.Enabled = false;
            OnCargar();
            gestionarBotones(true, true, true, false, false);
            isMsgBox = false;
            isLoaded = true;
            Util.ResaltarAyuda(txtAyudaEstablecimiento);
        }

        void crearColumnas() {
            //gridTipDoc
            CreateGridVista(this.gridTipDoc);
            this.CreateGridColumn(this.gridTipDoc, "Codigo", "FAC01COD", 0, "", 70);
            this.CreateGridColumn(this.gridTipDoc, "Descripcion", "FAC01DESC", 0, "", 200);
            //gridSeries
            CreateGridVista(this.gridSeries);
           this.CreateGridColumn(this.gridSeries,"Serie","FAC07SERIE",0,"",100);
            this.CreateGridColumn(this.gridSeries,"Descripcion","FAC07DESC",0,"",250);
            this.CreateGridColumn(this.gridSeries, "Numero", "FAC07NUMERO", 0, "", 120, true, false,true);
            this.CreateGridColumn(this.gridSeries, "CodEstablecimiento", "FAC07AESTABLECIMIENTOCOD", 0, "", 120,true,true,false);
            
                
        }
        
        void cargarEntidad() {
            serie.FAC07CODEMP = Logueo.CodigoEmpresa;
            serie.FAC01COD = this.gridTipDoc.CurrentRow.Cells["FAC01COD"].Value.ToString();
            serie.FAC07SERIE = txtCodigo.Text.Trim();
            serie.FAC07DESC = txtDescripcion.Text.Trim();
            serie.FAC07AESTABLECIMIENTOCOD = txtAyudaEstablecimiento.Text.Trim();
            serie.FAC07ABREVIA = "";
            serie.FAC07NUMERO = txtNumero.Text.Trim();            
        }
        //carga los tipos de documentos
        void OnCargar(){            
            var lista = TipoDocumentoVentasLogic.Instance.TraerTipoDocumentoVentas(Logueo.CodigoEmpresa, "FAC01COD", "*");
            this.gridTipDoc.DataSource = lista;
           
        }
        void cargarRegistro()
        {
            try
            {
                cargarEntidad();
                var lista = SeriesLogic.Instance.TraeSeries(serie, "FAC07SERIE", "*");
                this.gridSeries.DataSource = lista;
            }
            catch (Exception ex)
            {
            }
        }
        bool Validar() {
            //cbbGrabar.IsMouseOver = false;
            cbbGrabar.IsMouseOver = false;
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim())) {                
                MessageBox.Show("Ingresar codigo");
                txtCodigo.Focus();                               
                return false;
            }
            if(string.IsNullOrEmpty(txtDescripcion.Text.Trim())){                
                MessageBox.Show("Ingresar descripcion");                
                txtDescripcion.Focus();                
                return false;
            }
            if (string.IsNullOrEmpty(txtNumero.Text.Trim())) {                
                MessageBox.Show("Ingresar numero");                
                txtNumero.Focus();
                return false;
            }
            
            return true;
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            BaseHabilitarCajas(this, true);
            BaselimpiarCajas(this);
            txtCodigo.Focus();
            gestionarBotones(false, false, false, true, true);
        }

        protected override void OnEditar()
        {
            if (gridSeries.Rows.Count == 0) return;
            Estado = FormEstate.Edit;
            BaseHabilitarCajas(this, true);
            this.txtCodigo.Enabled = false;
            txtDescripcion.Focus();
            gestionarBotones(false, false, false, true, true);
        }

        protected override void OnEliminar()
        {
            try
            {
                if (this.gridSeries.MasterView.Rows.Count == 0) return;

                cargarEntidad();

                string msj = string.Empty;
                int flag = 0;

                DialogResult res = MessageBox.Show("Esta seguro de eliminar el registro seleccionado : " +
                    serie.FAC01COD + "", "Sistema", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                
                if (res == System.Windows.Forms.DialogResult.Yes)
                {                    
                    SeriesLogic.Instance.EliminarSerie(serie, out flag, out msj);
                    Util.ShowMessage(msj, flag);
                    if (flag == 1)
                    {
                        int indice = gridSeries.MasterView.CurrentRow.Index;
                        cargarRegistro();
                        if (indice > 0)
                        {
                            gridSeries.MasterView.Rows[indice - 1].IsSelected = true;
                            gridSeries.MasterView.Rows[indice - 1].IsCurrent = true;
                        }    
                    }                    
                    
                }


            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
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
                int flag = 0;
                if (Estado == FormEstate.New)
                {
                    SeriesLogic.Instance.InsertarSerie(serie, out flag, out msj);                    
                    cbbNuevo.IsMouseOver = true;
                    cbbNuevo.Focus();
                }
                else if (Estado == FormEstate.Edit)
                {
                    SeriesLogic.Instance.ActualizarSerie(serie, out flag, out msj);                    
                    cbbNuevo.IsMouseOver = false;
                }

                Util.ShowMessage(msj, flag);

                if (flag == 1)
                {
                    cargarRegistro();
                    Util.enfocarFila(this.gridSeries, "FAC07SERIE", serie.FAC07SERIE);
                    OnCancelar();                    
                    Estado = FormEstate.List;
                }
                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            
        }
        void cargarSerie() {
            try
            {
                BaselimpiarCajas(this);
                if (gridSeries.RowCount == 0)
                    return;
                string codigo = string.Empty;
                string nombre = string.Empty;
                string numero = string.Empty;
                string CodEstablecimiento = string.Empty;
                string DescEstablecimiento = string.Empty;
                codigo = gridSeries.CurrentRow.Cells["FAC07SERIE"].Value.ToString();
                nombre = gridSeries.CurrentRow.Cells["FAC07DESC"].Value.ToString();
                numero = gridSeries.CurrentRow.Cells["FAC07NUMERO"].Value.ToString();
                CodEstablecimiento = gridSeries.CurrentRow.Cells["FAC07AESTABLECIMIENTOCOD"].Value.ToString();
              //Sacar Descripcion de establecimientos 

                GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + CodEstablecimiento, "1009", out DescEstablecimiento);


                //serie.
                txtCodigo.Text = codigo;
                txtDescripcion.Text = nombre;
                txtNumero.Text = numero;
                txtAyudaEstablecimiento.Text = CodEstablecimiento;
                txtAyudaEstablecimientoDesc.Text = DescEstablecimiento;
            }
            catch (Exception ex)
            {
            }
        }
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;            
            BaseHabilitarCajas(this, false);
            gestionarBotones(true, true, true, false, false);
            
            cargarSerie();
        
            //cargarRegistro();
        }
         
        private void gridTipDoc_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (!isLoaded) return;
                if (Estado == FormEstate.New) return;

                var row = e.CurrentRow.Cells;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["FAC01COD"].Value != null)
                    {
                        cargarRegistro();
                        cargarSerie();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        private void gridSeries_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (!isLoaded) return;
                if (Estado == FormEstate.New) return;
                var row = e.CurrentRow.Cells;
                if (e.CurrentRow.Cells != null) {
                    if (e.CurrentRow.Cells["FAC07SERIE"].Value != null)
                    {
                        cargarSerie();
                    }
                }
            }
            catch (Exception ex) 
            { 
            
            }
        }
        private void mostrarAyuda(enmAyuda tipo)
        {
            try
            {

                frmBusqueda frm;
                string[] datos;
                #region "Tipo de ayuda"
                switch (tipo)
                {
                    case enmAyuda.enmEstablecimientos:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();

                        if (frm.Result != null)
                        {
                            if (frm.Result.ToString() != "")
                            {
                                //datos = frm.Result.ToString().Split('|');    
                                txtAyudaEstablecimiento.Text = ((GuiaTransporte)frm.Result).FAC34DESCODESTAB.ToString().Trim();
                                txtAyudaEstablecimientoDesc.Text = ((GuiaTransporte)frm.Result).FAC34DESDESESTAB.ToString().Trim();

                            }
                        }
                        
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda: " + ex.Message);
            }

        }
        private void txtAyudaEstable_KeyDown(object sender, KeyEventArgs e)
        {
            try 
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                mostrarAyuda(enmAyuda.enmEstablecimientos);
                }

            }
            catch(Exception ex)
            {

            }
        }
    }
}
