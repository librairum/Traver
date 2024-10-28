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
namespace Fac.UI.Win
{
    public partial class FrmUniMed : frmBaseMante
    {
        private bool isLoaded = false;
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importarMP;
        CommandBarStripElement menu;

        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;

        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbExportarMovimientos;
        private frmMDI FrmParent { get; set; }
        private static FrmUniMed _aForm;
        public static FrmUniMed Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return  new FrmUniMed(mdiPrincipal);
            _aForm = new FrmUniMed(mdiPrincipal);
            return _aForm;
        }
        public FrmUniMed(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            ConfigurarEventos();
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbEliminar = menu.Items["cbbEliminar"];
            cbbEditar = menu.Items["cbbEditar"];

            cbbVer = menu.Items["cbbVer"];
            cbbVista = menu.Items["cbbVista"];
            cbbImprimir = menu.Items["cbbImprimir"];
            cbbRefrescar = menu.Items["cbbRefrescar"];
            cbbImportar = menu.Items["cbbImportar"];

            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];

            accesobotonesperfil();
            ComportarmientoBotones("cargar");
            //HabilitarBotones(true, true, true, false, false, false);
        }
        
        void ConfigurarEventos()
        {
            crearGrilla();
            OnBuscar();
            this.HabilitarBotones(true, true, true, false, false, false);
        }
        //public FrmUniMed()
        //{
        //    InitializeComponent();
        //    crearGrilla();
        //    OnBuscar();
        //    this.HabilitarBotones(true, true, true, false, false, false);
        //    habilitarBotones(true, false);
        //}
        void seleccionaActualizado(string codigo, RadGridView grid, string nomCol)
        {
            foreach (GridViewRowInfo r in grid.Rows)
            {
                if (r.Cells[nomCol].Value.Equals(codigo))
                {
                    grid.Rows[r.Index].IsCurrent = true;
                    grid.Rows[r.Index].IsSelected = true;
                }
            }
        }
        int indiceEditable = 0;
        //crear grilla para permitir edicion
        private void crearGrilla() {
            RadGridView grilla =  this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(gridControl, "Codigo", "In21codigo", 0, "", 100,false, true);
            this.CreateGridColumn(gridControl, "Descripcion", "In21descri", 0, "", 300, false, true);
            this.CreateGridColumn(gridControl, "flag", "flag", 0, "", 50, false, true, false);
            //grilla.Columns.Add("In21codigo", "Codigo", "In21codigo");

            //grilla.Columns.Add("In21descri", "Descripcion", "In21descri");
            //grilla.Columns[0].Width = 100;
            //grilla.Columns[1].Width = 300;
            //grilla.AllowEditRow = false;
        }

        protected override void OnBuscar() {
          
            var lista = UnidaddeMedidaLogic.Instance.TraerUnidaddeMedida(Logueo.CodigoEmpresa);
            
            this.gridControl.DataSource = lista; 
            
        }
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;

                    break;
                case "nuevo":

                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    break;
                case "editar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    break;
                case "grabar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    break;
                case "cancelar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    break;
            }
        }
        void accesobotonesperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.CodModulo, this.Name, out nuevo_a, out editar_a,
              out eliminar_a, out ver_a, out imprimir_a, out refrescar_a, out importar_a, out vista_a,
              out guardar_a, out cancelar_a, out expmovi_a, out importarMP);
        }
        protected override void OnNuevo() {
          
            //this.gridControl.AllowEditRow = true;
          
            this.gridControl.Rows.AddNew();
            Estado = FormEstate.New;
            
            this.gridControl.CurrentRow.Cells["flag"].Value = "0"; // asigno un valor a flag para ver si es editable o registro nuevo para iniciar el modo edicio de la fila.
            this.gridControl.CurrentRow.Cells["In21codigo"].BeginEdit();
            /*bucle para bloquear las filas anteior a la nueva para evitar modificaciones de las anterioes filas*/
            indiceEditable = gridControl.Rows[gridControl.RowCount - 1].Index;
            //habilito los botones para grabar o cancelar            
            //HabilitarBotones(false, false, false, true, true, false);
            ComportarmientoBotones("nuevo");
        }
        protected override void OnEditar() {
            try {
                Estado = FormEstate.Edit;
                //this.gridControl.AllowEditRow = true;
                this.gridControl.CurrentRow.Cells["flag"].Value = "0";
                
                this.gridControl.CurrentRow.Cells["In21codigo"].ReadOnly = true;
                this.gridControl.CurrentRow.Cells["In21descri"].ReadOnly = false;
                
                
                /**bloqueo columna de codigo de la undia de medida */               
                indiceEditable = this.gridControl.CurrentRow.Index;
                //gridControl.CurrentRow.Cells["In21codigo"].Style.ForeColor = Color.Red;
                //gridControl.CurrentRow.Cells["In21descri"].Style.ForeColor = Color.Red;
                
            }
            catch (Exception ex) { 
            
            }
            ComportarmientoBotones("editar");
            //retorno la configuracion de los botones a su  configuracion inciial
            //HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false, true);
            
        }
        protected override void OnCancelar()
        {                     
            //this.gridControl.AllowEditRow = false;
            //retorno la configuracion de los botones a su  configuracion inciial 
            this.gridControl.CurrentRow.Cells["flag"].Value = null;
            Estado = FormEstate.List;
            //this.gridControl.AllowAddNewRow = false;
            ComportarmientoBotones("cancelar");
            OnBuscar();
            //HabilitarBotones(true, true, true, false, false, false); 
        }
        protected override void OnEliminar()            
        {
            try {
                Estado = FormEstate.List;
                if (gridControl.SelectedRows.Count == 0)
                    return;
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", 
                    Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR,
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    UnidaddeMedida entidad = new UnidaddeMedida();
                    string mensaje = string.Empty;
                    entidad.in21codigo = this.gridControl.CurrentRow.Cells["In21codigo"].Value.ToString();
                    UnidaddeMedidaLogic.Instance.EliminarUnidadMedidad(Logueo.CodigoEmpresa, entidad, out mensaje);
                    RadMessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                }

                OnBuscar();                                          
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                //RadMessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar();

        }
        private bool Validar() {
            try {
                if (this.gridControl.CurrentRow.Cells[0].Value == null ||
                    this.gridControl.CurrentRow.Cells[1].Value == null)
                {
                    RadMessageBox.Show("Completar el registro", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return false;
                }
            }
            catch (Exception ex) { 
            
            }            
            return true;
        }
        protected override void OnGuardar() {
            UnidaddeMedida entidad = new UnidaddeMedida();
            try {

                if (!Validar())
                    return;              
                entidad.in21codigo = this.gridControl.CurrentRow.Cells["In21codigo"].Value.ToString();
                entidad.in21descri = this.gridControl.CurrentRow.Cells["In21descri"].Value.ToString();

                string mensaje = string.Empty;
                if (Estado == FormEstate.New)
                {
                    UnidaddeMedidaLogic.Instance.InsertarUnidadMedida(Logueo.CodigoEmpresa, entidad, out mensaje);
                    RadMessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);                                        
                }
                else if (Estado == FormEstate.Edit)
                {
                    UnidaddeMedidaLogic.Instance.ActualizarUnidadMedida(Logueo.CodigoEmpresa, entidad, out mensaje);
                    RadMessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);                                                            
                }
                else
                {
                    RadMessageBox.Show("Opcion invalida", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar(); // cancelo y actualizo la grilla , asgino al bandera de Form - estado  a List
            Util.enfocarFila(gridControl, "In21codigo", entidad.in21codigo);         
        }


        private void gridControl_SelectionChanged(object sender, EventArgs e)
        {           
        }

        private void gridControl_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try {
                //if (Estado == FormEstate.Edit || Estado == FormEstate.New ) {
                //    gridControl.Rows[indiceEditable].IsSelected = true;
                //    gridControl.Rows[indiceEditable].IsCurrent = true;
                //}
                
            }
            catch (Exception ex) {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (Estado == FormEstate.List || Estado == FormEstate.View)
            {
                e.Cancel = true;
            }
            else {
                e.Cancel = e.Row.Cells["flag"].Value == null ? true : false;
               
            }
            
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (Estado == FormEstate.New || Estado == FormEstate.Edit)
            {
                e.Cancel = true;                

                RadMessageBox.Show("Debe completar o cancelar la operacion en el fila actual", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);

            }
        }
        
    }
}
