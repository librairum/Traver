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

namespace Cos.UI.Win
{
    public partial class frmLoteCosto : frmBaseMante
    {       
        LoteCosto lotecosto;
        private frmMDI FrmParent { get; set; }
        private static frmLoteCosto _aForm;
        
        
        public frmLoteCosto(frmMDI padre) 
        {
            InitializeComponent();
            FrmParent = padre;
            HabilitarBotones(true, false, false, false, false, false);
            CrearColumnas();
           
            OnBuscar();     
            
        }

        public static frmLoteCosto Instance(frmMDI mdiPrincipal) 
        {
            if (_aForm != null) return new frmLoteCosto(mdiPrincipal);
            _aForm = new frmLoteCosto(mdiPrincipal);
            return _aForm;
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
        private void CrearColumnas() {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "CodigoEmpresa", "CodigoEmpresa", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Anio", "Anio", 0, "", 70, true, false);
            this.CreateGridColumn(Grid, "Mes", "Mes", 0, "", 70, true, false);

            this.CreateGridColumn(Grid, "CodigoLinea", "CodigoLinea", 0, "", 100, true, false, false);
            this.CreateGridColumn(Grid, "Desc.Linea", "DescripcionLinea", 0, "", 180, true, false, false);

            this.CreateGridColumn(Grid, "Codigo", "Codigo", 0, "", 100, true, false);
            this.CreateGridColumn(Grid, "Descripcion", "Descripcion", 0, "", 180, false, true);
            
            
            this.CreateGridbutton(Grid, "btnGrabar", "", 30);
            this.CreateGridbutton(Grid,"btnCancelar", "", 30);
            this.CreateGridbutton(Grid, "btnEliminar", "", 30);
            this.CreateGridColumn(Grid, "flag", "flag", 0, "", 70, true, false,false);
        }
        private void CreateGridbutton(RadGridView GridView, string name, string texthead, int width) 
        {
                GridViewCommandColumn button = new GridViewCommandColumn();
            button.Name = name;
            button.HeaderText = texthead;
            GridView.Columns.Add(button);
            GridView.Columns[name].MinWidth = width;
            GridView.Columns[name].BestFit();
        }
        protected override void OnBuscar()
        {
            var lista = LoteCostoLogic.Instance.TraerLoteCostoxEmpresa(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Logueo.CodigoLinea);
            this.gridControl.DataSource = lista;
        }
        protected override void OnNuevo()
        {
            InsertarNuevaFila();
        }
        protected override void OnEditar()
        {
            
        }
        private void InsertarNuevaFila() 
        {
            try
            {
                this.gridControl.Rows.AddNew();
                GridViewRowInfo row = this.gridControl.CurrentRow;
                row.Cells["CodigoEmpresa"].Value = Logueo.CodigoEmpresa;
                row.Cells["Anio"].Value = Logueo.Anio;
                row.Cells["Mes"].Value = Logueo.Mes;
                row.Cells["flag"].Value = "0";
                row.Cells["CodigoLinea"].Value = Logueo.CodigoLinea;
                
                Util.ResaltarAyuda(row.Cells["CodigoLinea"]);                
               
                this.gridControl.Focus();
                
                string codigo = string.Empty;
                LoteCostoLogic.Instance.TraerCodigoGenerado(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, out codigo);
                row.Cells["codigo"].Value = codigo;                                                    
            }
            catch (Exception ex) { }
        }
        
        private void Guardar(GridViewRowInfo fila) 
        {
            string mensaje = string.Empty;
            int flag = 0;
            if (!Validar(fila)) return;

            lotecosto = new LoteCosto();
            lotecosto.CodigoEmpresa = Logueo.CodigoEmpresa;
            lotecosto.Anio = fila.Cells["Anio"].Value.ToString();
            lotecosto.Mes = fila.Cells["Mes"].Value.ToString();
            lotecosto.CodigoLinea = fila.Cells["CodigoLinea"].Value.ToString();
            lotecosto.Codigo = fila.Cells["Codigo"].Value.ToString();
            lotecosto.Descripcion = fila.Cells["descripcion"].Value.ToString();

            if (fila.Cells["flag"].Value.ToString() == "0")
                LoteCostoLogic.Instance.InsertarLoteCosto(lotecosto, out mensaje, out flag);
            else if (fila.Cells["flag"].Value.ToString() == "1")
                LoteCostoLogic.Instance.ActualizarLoteCosto(lotecosto, out mensaje, out flag);
            //Valido el flag si esta OK la operacion
                if (flag == 1)
                {
                    ShowAlertOk("Sistema", mensaje);
                    OnBuscar();

                    // Que capture variable logueo
                    this.FrmParent.CargarLoteCosto();
                    this.FrmParent.capturarLoteCosto();
                    
                }
                else
                {
                    ShowAlertExclamation("Sistema", mensaje);
                }

                FrmParent.CargarLoteCosto();
        }

        private bool Validar(GridViewRowInfo fila) {            
            if (Util.convertiracadena(fila.Cells["CodigoLinea"].Value) == "" ||
                Util.convertiracadena(fila.Cells["CodigoLinea"].Value) == "???") {
                    ShowAlertExclamation("Sistema", "Ingresar codigo de Linea");
                return false;
            }
            if (Util.convertiracadena(fila.Cells["DescripcionLinea"].Value) == "" ||
                Util.convertiracadena(fila.Cells["DescripcionLinea"].Value) == "???") {
                    ShowAlertExclamation("Sistema", "Ingresar codigo de Linea");
                    return false;
            }
            if (Util.convertiracadena(fila.Cells["Codigo"].Value) == "")
            {
                ShowAlertExclamation("Sistema", "Ingresar Codigo");
                return false;
            }

            if (Util.convertiracadena(fila.Cells["descripcion"].Value) == "")
            {
                ShowAlertExclamation("Sistema", "Ingresar Descripcion");
                return false;
            }
            return true;
        }

        private void Eliminar(GridViewRowInfo fila) 
        {
            string mensaje = string.Empty;
            int flag = 0;
            lotecosto = new LoteCosto();
            lotecosto.CodigoEmpresa = Logueo.CodigoEmpresa;
            lotecosto.Anio = fila.Cells["Anio"].Value.ToString();
            lotecosto.Mes = fila.Cells["Mes"].Value.ToString();
            lotecosto.CodigoLinea = fila.Cells["CodigoLinea"].Value.ToString();
            lotecosto.Codigo = fila.Cells["Codigo"].Value.ToString();
            //lotecosto.Codigo = fila.Cells["descripcion"].Value.ToString();
            //LoteCostoLogic.Instance.ActualizarLoteCosto(lotecosto, out mensaje, out flag);
            DialogResult res;
            ShowAlertQuestion("Sistema", "¿Desea eliminar el registo?", out res);
            if( res == System.Windows.Forms.DialogResult.Yes)
            {
                LoteCostoLogic.Instance.EliminarLoteCosto(lotecosto, out mensaje, out flag);
                if (mensaje != "")
                {
                    if (flag == 1)
                    {
                        ShowAlertOk("Sistema", mensaje);
                        // Que capture variable logueo
                        this.FrmParent.CargarLoteCosto();
                        this.FrmParent.capturarLoteCosto();
                    }
                    else
                    {
                        ShowAlertExclamation("Sistema", mensaje);
                    }
                }
                
             }
                OnBuscar();
                FrmParent.CargarLoteCosto();
        }

        private void Cancelar(GridViewRowInfo fila) 
        {
            OnBuscar();
        }

        private void Editar(GridViewRowInfo fila) 
        {
            this.gridControl.CurrentRow.Cells["flag"].Value = "1";
            Util.ResaltarAyuda(fila.Cells["CodigoLinea"]);
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

        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {            
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {
                    //Activo los botones de Grabar y cancelar
                    AsignarImagexBoton(e.Column.Name, cellElement, false, false, true, true);
                    
                }
                else
                {
                    //Activo los botones de Editar e Eliminar
                    AsignarImagexBoton(e.Column.Name, cellElement, true, true, false, false);                    
                }            
            }                                   
        }


        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if (e.CurrentRow == null) return;
                string FlagFilaActual = Util.convertiracadena(e.CurrentRow.Cells["flag"].Value);
                if (FlagFilaActual == "0") // fila en modo edicion o nuevo
                {
                    e.Cancel = true; // cancelo el evento de cambiar de foco de fila

                    //evaluo si la fila selecciona tie en blanco el campo codigo 
                    if (e.NewRow.Cells["COS03CODLINEAPRODUCCION"].Value == null)
                    {
                        //elimino la fila de la grilal si tiene su ncampo codigo en blanco
                        e.NewRow.Delete();
                    }
                    ShowAlertExclamation("Sistema", "Debe Completar el registro");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            //no permite usar al aydua si el registero no modo edicion o nuevo
            if (this.gridControl.CurrentRow.Cells["flag"].Value == null) return; 


            if (e.KeyValue == (char)Keys.F1)
            {
                if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["CodigoLinea"].ColumnInfo.Index)
                {
                    mostrarAyuda(enmAyuda.enmLinea);
                }
            }
            
        }
        private void mostrarAyuda(enmAyuda tipo) {
            string codigoSeleccionado = string.Empty;
            frmBusqueda frm;
            switch (tipo) 
            {
                case enmAyuda.enmLinea:
                    frm = new frmBusqueda(tipo);
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    if (codigoSeleccionado == "") return;
                        this.gridControl.CurrentRow.Cells["CodigoLinea"].Value = codigoSeleccionado;
                    break;
            }
        }
        private void ObtenerDescripcion(enmAyuda tipo, string codigo) 
        {
            string descripcion = string.Empty;
            switch (tipo) 
            {
                case enmAyuda.enmLinea:
                    codigo = Logueo.CodigoEmpresa + codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo, "LINEAPROD", out descripcion);
                    this.gridControl.CurrentRow.Cells["DescripcionLinea"].Value = descripcion;
                    break;
            }
        }

        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Index == this.gridControl.CurrentRow.Cells["CodigoLinea"].ColumnInfo.Index) 
            {
                ObtenerDescripcion(enmAyuda.enmLinea, this.gridControl.CurrentRow.Cells["CodigoLinea"].Value.ToString());                
            }
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (this.gridControl.CurrentRow.Cells["flag"].Value == null) {               
                    e.Cancel = true;              
            }
        }
                           
    }
}
