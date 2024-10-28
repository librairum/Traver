using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Cos.UI.Win.Properties;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Cos.UI.Win
{
    public partial class frmActividadesContable : frmBaseMante
    {        
        private frmMDI FrmParent { get; set; }
        private static frmActividadesContable _aForm;
        ActividadesContable ActiConta = new ActividadesContable();
        public frmActividadesContable(frmMDI padre) {
            InitializeComponent();
            HabilitarBotones(true, false, false, false, false, false);
            CrearColumnas();
            OnBuscar();
            
        }
        public static frmActividadesContable Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmActividadesContable(mdiPrincipal);
            _aForm = new frmActividadesContable(mdiPrincipal);
            return _aForm;
        }
        private void CrearColumnas() {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "COS01CODEMP", "COS01CODEMP", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "CodActContaTipo", "COS01CODTIPO", 0, "", 150, false, true, false); //-- Codigo de Actividad Contable Tipo 
            this.CreateGridColumn(Grid, "Tipo Actividad", "COS02DESCRIPCION", 0, "", 150); //--Descripcion  de actividad Contable tipo             
            this.CreateGridColumn(Grid, "Codigo", "COS01CODIGO", 0, "", 70, false, true);
            this.CreateGridColumn(Grid, "Descripcion", "COS01DESCRIPCION", 0, "", 200, false, true);
            this.CreateGridColumn(Grid, "Cuenta Contable", "COS01CTACBLE", 0, "", 200, false, true);
            this.CreateGridButton(Grid, "btnGrabar", "", 30);
            this.CreateGridButton(Grid, "btnCancelar", "", 30);
            this.CreateGridButton(Grid, "btnEditar", "", 30);
            this.CreateGridButton(Grid, "btnEliminar", "", 30);                        
            this.CreateGridColumn(Grid, "flag", "flag", 0, "", 30, false, true, false);
        }
        private void CreateGridButton(RadGridView GridView, string name, string texthead, int width) {
            GridViewCommandColumn button = new GridViewCommandColumn();
            button.Name = name;
            button.HeaderText = texthead;                        
            GridView.Columns.Add(button);
            GridView.Columns[name].MinWidth = width;
            GridView.Columns[name].BestFit();
        }
        protected override void OnBuscar()
        {
            //ActividadesContableLogic.Instance.TraerActividadesContables(Logueo.CodigoEmpresa, 
            var dt = ActividadesContableLogic.Instance.TraerActividadesContables(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = dt;
        }
        private void InsertarNuevaFila()
        {
            try
            {
                this.gridControl.Rows.AddNew();
                GridViewRowInfo row = this.gridControl.CurrentRow;
                string codCorrelativo = string.Empty;
                ActividadesContableLogic.Instance.TraerCodigoCorrelativo(Logueo.CodigoEmpresa, out codCorrelativo);
                row.Cells["COS01CODIGO"].Value = codCorrelativo;
                row.Cells["flag"].Value = "0";

                Util.ResaltarAyuda(row.Cells["COS02DESCRIPCION"]);                

                this.gridControl.Focus();
            }
            catch (Exception ex) { }
        }
        protected override void OnNuevo()
        {
            InsertarNuevaFila();                             
        }
        private void mostrarAyuda(enmAyuda tipo) {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipo) {
                case enmAyuda.enmActCtbleTipo:
                    frm = new frmBusqueda(enmAyuda.enmActCtbleTipo);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null) 
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado != "")
                        this.gridControl.CurrentRow.Cells["COS01CODTIPO"].Value = codigoSeleccionado;
                    break;
                default:                    
                    ShowAlertExclamation("Sistema", "Tipo de Ayuda No Valido");
                    break;
            }
        }
        
        private void ObtenerDescripcion(enmAyuda tipo, string codigo) {
            string descripcion = string.Empty;
            switch (tipo) { 
                case enmAyuda.enmActCtbleTipo:                    
                    GlobalLogic.Instance.DameDescripcion(codigo, "ACTCONTABLETIPO", out descripcion);
                    this.gridControl.CurrentRow.Cells["COS02DESCRIPCION"].Value = descripcion;
                    break;
                default:
                    //RadMessageBox.Show("Tipo de Ayuda No Valido", "Sistema", 
                    //                    MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    ShowAlertExclamation("Sistema", "Tipo de Ayuda No Valido");
                    break;
            }
        }
        
        private void gridControl_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            
        }
        private void AsignarImagexBoton(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
                                        bool bCancelar, bool bEliminar, bool bEditar) 
        {
            GridCommandCellElement cellElement = CommandCell;
            
            switch (nombre) 
            {
                case "btnEditar":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edit_enabled : Properties.Resources.edit_disabled;                    
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;
                case "btnEliminar":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.delete_enabled : Properties.Resources.Delete_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;
                case "btnGrabar":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;
                case "btnCancelar":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;
            }
        }
        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {
                    AsignarImagexBoton(e.Column.Name, cellElement, false, false, true, true);
                    
                }
                else {
                    AsignarImagexBoton(e.Column.Name, cellElement, true, true, false, false);
                    
                }                                             
            }
        }
        private bool Validar(GridViewRowInfo fila) 
        {
            if (Util.convertiracadena(fila.Cells["COS01CODTIPO"].Value) == "" ||
                Util.convertiracadena(fila.Cells["COS01CODTIPO"].Value) == "???")
            {
                ShowAlertExclamation("Sistema", "Ingresar Tipo");
                return false;
            }
            if (Util.convertiracadena(fila.Cells["COS01CODIGO"].Value) == "" ||
                Util.convertiracadena(fila.Cells["COS01CODIGO"].Value) == "???" )
            {
                ShowAlertExclamation("Sistema", "Ingresar Codigo");
                return false;
            }
            if (Util.convertiracadena(fila.Cells["COS01DESCRIPCION"].Value) == "" || 
                Util.convertiracadena(fila.Cells["COS01DESCRIPCION"].Value) == "???") 
            {
                ShowAlertExclamation("Sistema", "Ingresar Descripcion");
                return false;
            }
            if (Util.convertiracadena(fila.Cells["COS01CTACBLE"].Value) == "" ||
                Util.convertiracadena(fila.Cells["COS01CTACBLE"].Value) == "???")
            {
                ShowAlertExclamation("Sistema", "Ingresar Cuenta Contable");
                return false;
            }
            
            return true;
        }
        
        private void Guardar(GridViewRowInfo row) {
            string mensaje = string.Empty;
            int flag = 0;
            try
            {
                if (!Validar(row)) return;
                //Capturando los valores
                ActiConta.COS01CODEMP = Logueo.CodigoEmpresa;                
                ActiConta.COS01CODTIPO = row.Cells["COS01CODTIPO"].Value.ToString();
                ActiConta.COS01CODIGO = row.Cells["COS01CODIGO"].Value.ToString();
                ActiConta.COS01DESCRIPCION = row.Cells["COS01DESCRIPCION"].Value.ToString();
                ActiConta.COS01CTACBLE = row.Cells["COS01CTACBLE"].Value.ToString();
                if (row.Cells["flag"].Value.ToString() == "0")
                {
                    ActividadesContableLogic.Instance.InsertarActividadContable(ActiConta, out mensaje, out flag);
                    ShowAlertOk("Sistema", mensaje);
                }
                else if (row.Cells["flag"].Value.ToString() == "1")
                {
                    ActividadesContableLogic.Instance.ActualizarActividadContable(ActiConta, out mensaje, out flag);
                    ShowAlertOk("Sistema", mensaje);
                }
                if (flag == 0)
                {
                    OnBuscar();
                }
                else if(flag == -1) {
                    ShowAlertExclamation("Sistema", mensaje);
                }
            }
            catch (Exception ex) {
                ShowAlertError("Sistema", ex.Message);
            }

            
            
        }
        private void Editar(GridViewRowInfo row) {
           row.Cells["flag"].Value = "1";

           Util.ResaltarAyuda(row.Cells["COS02DESCRIPCION"]);           
        }
        private void Eliminar(GridViewRowInfo row) {
            string mensaje = string.Empty;

            DialogResult res;
            ShowAlertQuestion("Sistema", "¿Desea eliminar el registro?", out res);
            ActiConta.COS01CODEMP = Logueo.CodigoEmpresa;
            ActiConta.COS01CODIGO = row.Cells["COS01CODIGO"].Value.ToString();
            ActiConta.COS01CODTIPO = row.Cells["COS01CODTIPO"].Value.ToString();
            ActiConta.COS01CODIGO = row.Cells["COS01CODIGO"].Value.ToString();
            ActiConta.COS01DESCRIPCION = row.Cells["COS01DESCRIPCION"].Value.ToString();
            ActiConta.COS01CTACBLE = row.Cells["COS01CTACBLE"].Value.ToString();
            int flag = 0;
            if (res == System.Windows.Forms.DialogResult.Yes) {
                ActividadesContableLogic.Instance.EliminarActividadContable(ActiConta, out mensaje, out flag);
                ShowAlertOk("Sistema", mensaje);
                if (flag  == 0)
                {
                    OnBuscar();   
                }
                
            }
            
        }
        private void Cancelar(GridViewRowInfo row) {
            row.Cells["flag"].Value = null;
            string codigo = Util.convertiracadena(row.Cells["COS01CODIGO"].Value);
            OnBuscar();            
            Util.enfocarFila(gridControl, "COS01CODIGO", codigo);
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {          

            switch (this.gridControl.CurrentColumn.Name) 
            {
                case "btnGrabar":
                    Guardar(this.gridControl.CurrentRow);
                    break;
                case "btnEditar":
                    Editar(this.gridControl.CurrentRow);
                    break;
                case "btnEliminar":
                    Eliminar(this.gridControl.CurrentRow);
                    break;
                case "btnCancelar":
                    Cancelar(this.gridControl.CurrentRow);
                    break;
                default:
                    break;
            }
            
        }
               
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            //menu de ayuda de tipo de actividad
            if (e.KeyValue == (char)Keys.F1)
            {
                if (gridControl.CurrentColumn.Index == gridControl.CurrentRow.Cells["COS02DESCRIPCION"].ColumnInfo.Index)
                {
                    mostrarAyuda(enmAyuda.enmActCtbleTipo);                
                }
            }
            //evento para desplazar el foco de una celda a otra en al grilla de Actividad Contable
            if (e.KeyValue == (char)Keys.Enter) {
                gridControl.Focus();
                Util.SendTab(Keys.Enter.GetHashCode());
            }
        }

        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            
            if (gridControl.CurrentColumn.Index == gridControl.CurrentRow.Cells["COS02DESCRIPCION"].ColumnInfo.Index)
            {
                if (e.Row.Cells["COS01CODTIPO"] == null || e.Row.Cells["COS01CODTIPO"].Value == null) return;
                ObtenerDescripcion(enmAyuda.enmActCtbleTipo, this.gridControl.CurrentRow.Cells["COS01CODTIPO"].Value.ToString());
            }
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row == null) return;
            if (e.Row.Cells["flag"].Value == null)
            {
                e.Cancel = true;
            }
            else {
                if (gridControl.CurrentColumn.Index == gridControl.CurrentRow.Cells["COS01CODTIPO"].ColumnInfo.Index
                     || gridControl.CurrentColumn.Index == gridControl.CurrentRow.Cells["COS01CODIGO"].ColumnInfo.Index)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridControl_SelectionChanging(object sender, GridViewSelectionCancelEventArgs e)
        {
           
           
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if(e.CurrentRow == null) return;              
                    string FlagActual = Util.convertiracadena(e.CurrentRow.Cells["flag"].Value);
                    if (FlagActual == "0" || FlagActual == "1") {
                        e.Cancel = true;
                        if (e.NewRow.Cells["COS01CODIGO"].Value == null)
                        {
                            e.NewRow.Delete();
                        }                        
                        ShowAlertExclamation("Sistema", "Debe Completar el registro");                        
                    }                
            }
            catch (Exception ex) { 
                
            }
            //string codigoNuevo = Util.convertiracadena(e.NewRow.Cells["COS01CODIGO"].Value);                                        
        }
    }
}
