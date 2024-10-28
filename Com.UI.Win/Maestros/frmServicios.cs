using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Com.UI.Win
{
    public partial class frmServicios : frmBaseMante
    {
        private static frmServicios _aForm;
        private frmMDI FrmParent { get; set; }

        public static frmServicios Instance(frmMDI padre) {
            if (_aForm != null) return new frmServicios(padre);
            _aForm = new frmServicios(padre);
            return _aForm;
        }

        public frmServicios(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
        ServiciosCompraLogic datos = ServiciosCompraLogic.Instance;
        private void Cargar() {
            try
            {
                List<ServiciosCompras> lista = new List<ServiciosCompras>();
                lista = datos.TraeServicios(Logueo.CodigoEmpresa);
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex) {
                System.Console.Write("Error al cargar");
            }
            
        }
        private void CrearColumnas() {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "codigoEmpresa", "codigoEmpresa", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "Codigo", "codigo", 0, "", 90);
            CreateGridColumn(Grid, "Descripcion", "descripcion", 0, "", 250);
            CreateGridColumn(Grid, "U.M", "unidadmedida", 0, "", 70); // Codigo            
            CreateGridColumn(Grid, "Descripcion", "UniMedDescripcion", 0, "", 200);
            CreateGridColumn(Grid, "Cta\nCtble", "ctagas", 0, "", 70); // Codigo
            CreateGridColumn(Grid, "Descripcion", "CuentaContableDescripcion", 0, "", 200);
            

            CreateGridColumn(Grid, "codgas", "codgas", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "alias", "alias", 0, "", 70, true, false, false);
        }

        private void Limpiar() {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCodUniMed.Text = "";
            txtDesUniMed.Text = "";
            txtCodCtaCble.Text = "";
            txtDesCtaCble.Text = "";
        }
        private void HabilitarControles(bool estado) {
            txtCodigo.Enabled = estado;
            txtDescripcion.Enabled = estado;
            txtCodUniMed.Enabled = estado;
            //txtDesUniMed.Enabled = estado;
            txtCodCtaCble.Enabled = estado;
            //txtDesCtaCble.Enabled = estado;
        }

        private void VistaPrevia() { 
        
        }
        private void Seleccionar(GridViewRowInfo fila) {

            try
            {
                if (this.gridControl.Rows.Count == 0) return;
                if (fila == null) return;
                string codigo = Util.GetCurrentCellText(fila, "codigo");
                string descripcion = Util.GetCurrentCellText(fila, "descripcion");
                string ctacble = Util.GetCurrentCellText(fila, "ctagas");
                string unimed = Util.GetCurrentCellText(fila, "unidadmedida");
                string ctacbleDescripcion = Util.GetCurrentCellText(fila, "CuentaContableDescripcion");
                string unimedDescripcion = Util.GetCurrentCellText(fila, "UniMedDescripcion");
                txtCodigo.Text = codigo.Trim(); 
                txtDescripcion.Text = descripcion.Trim();
                txtCodCtaCble.Text = ctacble.Trim(); 
                txtCodUniMed.Text = unimed.Trim();
                txtDesCtaCble.Text = ctacbleDescripcion.Trim();
                txtDesUniMed.Text = unimedDescripcion.Trim();

            }
            catch (Exception ex) {
                System.Console.Write("Error al seleccionar");
            }
        }

        protected override void OnNuevo()
        {            
            
            HabilitarControles(true);
            Limpiar();

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            txtCodigo.Focus();
            Estado = FormEstate.New;
        }
        protected override void OnEditar()
        {
            
            HabilitarControles(true);

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            txtDescripcion.Focus();
            Estado = FormEstate.Edit;
        }

        protected override void OnEliminar()
        {
            try
            {
                ServiciosCompras entidad = new ServiciosCompras();
                entidad.codigoEmpresa = Logueo.CodigoEmpresa;
                entidad.codigo = txtCodigo.Text.Trim();
                string mensaje = ""; int flag = 0;
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el servicio?");
                if (respuesta) {
                    ServiciosCompraLogic.Instance.EliminarServicios(entidad, out flag, out mensaje);
                    Util.ShowMessage(mensaje, flag);
                    if (flag == 1)
                    {
                        Cargar();
                    }
                    Estado = FormEstate.List;
                }
                
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al eliminar");
            }
        }
        protected override void OnCancelar()
        {
            

            Limpiar();
            HabilitarControles(false);

            
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVista);            
            Estado = FormEstate.List;
            Cargar();         
            gridControl.CurrentRow = gridControl.Rows[0];
        }

        
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try {

                DataTable dt =  datos.TraeReporteServicios(Logueo.CodigoEmpresa);

                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptServicios.rpt";
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
                

            }catch(Exception ex){
                System.Console.Write("Error en vista");
            }
            Cursor.Current = Cursors.Default;
        }
        private bool Validar() {
            bool datoValido = true;
            if (txtCodigo.Text.Trim() == "") {
                Util.ShowAlert("Ingresar codigo"); datoValido = false;
            }
            if(txtDescripcion.Text.Trim() == ""){
                Util.ShowAlert("Ingresar descripcion"); datoValido = false;
            }

            //if (txtCodCtaCble.Text.Trim() == "") {
            //    Util.ShowAlert("Ingresar cuenta contable"); datoValido = false;
            //}

            //if (txtCodUniMed.Text.Trim() == "") {
            //    Util.ShowAlert("Ingresar unidad de medida"); datoValido = false;
            //}
            return datoValido;
        }
        protected override void OnGuardar()
        {
            try
            {

                if (Validar() == false) return;
                ServiciosCompras entidad = new ServiciosCompras();
                entidad.codigoEmpresa = Logueo.CodigoEmpresa;
                entidad.codigo = txtCodigo.Text.Trim();
                entidad.descripcion = txtDescripcion.Text.Trim();
                entidad.ctagas = txtCodCtaCble.Text.Trim();
                entidad.unidadmedida = txtCodUniMed.Text.Trim();
                int flag =0; string mensaje = "";
                if (Estado == FormEstate.New) {
                    datos.InsertarServicios(entidad, out flag, out mensaje);
                }else if (Estado == FormEstate.Edit) {
                    datos.ActualizarServicios(entidad, out flag, out mensaje);
                }
                Util.ShowMessage(mensaje, flag);
                if (flag == 1) {
                    Cargar();
                    OnCancelar();
                }
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al guardar");
            }
        }
        private void frmServicios_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);            
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            CrearColumnas();
            Cargar();
            HabilitarControles(false);
            Estado = FormEstate.List;

        }

        private void gridControl_CurrentColumnChanged(object sender, CurrentColumnChangedEventArgs e)
        {
            
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                Seleccionar(this.gridControl.CurrentRow);                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cambiar seleccion");
            }
        }
        private void TraerAyuda(enmAyuda tipo) {
            frmBusqueda frm;
            string[] datos;
            switch (tipo) { 
                case enmAyuda.enmUniMed:
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodUniMed.Text = datos[0].Trim();
                    txtDesUniMed.Text = datos[1].Trim();
                    break;
                case enmAyuda.enmCuentaContable:
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    txtCodCtaCble.Text = datos[0].Trim();
                    txtDesCtaCble.Text = datos[1].Trim();
                    break;
            }
        }
        private void txtCodUniMed_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == (char)Keys.F1) {
                TraerAyuda(enmAyuda.enmUniMed);

            }
        }

        private void txtCodCtaCble_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyuda(enmAyuda.enmCuentaContable);
            }
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (Estado == FormEstate.Edit || Estado == FormEstate.New)
            {
                e.Cancel = true;
            }
        }


        
    }
}
