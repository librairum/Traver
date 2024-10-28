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
    public partial class frmConciContableProd : frmBaseMante
    {
        private frmMDI FrmParent { get; set; }
        private static frmConciContableProd _aForm;
        public frmConciContableProd(frmMDI padre)
        {
            InitializeComponent();
            HabilitarBotones(true, false, false, false, false, false);
            CrearColumnas();
            AgruparColumnas();
            OnBuscar();
        }
        public static frmConciContableProd Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmConciContableProd(mdiPrincipal);
            _aForm = new frmConciContableProd(mdiPrincipal);
            return _aForm;
        }
        ConciProdVsCtble conciliacion = new ConciProdVsCtble();
        private void CrearColumnas() {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "CodigoLinea", "COS03CODLINEAPRODUCCION", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Linea", "PRO08DESC", 0, "", 120);
            this.CreateGridColumn(Grid, "Codigo Actividad", "COS03CODACTPRODUCCION", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Actividad", "PRO09DESC", 0, "", 120);
            this.CreateGridColumn(Grid, "CodigoActContable", "COS03CODACTCONTABLE", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "", "COS01DESCRIPCION", 0, "", 200);

            this.CreateGridButton(Grid, "btnGrabar", "", 30);
            this.CreateGridButton(Grid, "btnCancelar", "", 30);
            this.CreateGridButton(Grid, "btnEliminar", "", 30);
            
            this.CreateGridColumn(Grid, "flag", "flag", 0, "", 70, false, true, false);
        }

        ColumnGroupsViewDefinition columnGroupView;

        private void AgruparColumnas() {
            this.columnGroupView = new ColumnGroupsViewDefinition();
            this.columnGroupView.ColumnGroups.Add(new GridViewColumnGroup("Actividad Produccion"));
            this.columnGroupView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["PRO08DESC"]);
            this.columnGroupView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["PRO09DESC"]);

            this.columnGroupView.ColumnGroups.Add(new GridViewColumnGroup("Actividad Contable"));
            
            this.columnGroupView.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupView.ColumnGroups[1].Rows[0].Columns.Add(this.gridControl.Columns["COS01DESCRIPCION"]);

            this.columnGroupView.ColumnGroups.Add(new GridViewColumnGroup(""));
            this.columnGroupView.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            this.columnGroupView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["btnGrabar"]);
            this.columnGroupView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["btnCancelar"]);
            this.columnGroupView.ColumnGroups[2].Rows[0].Columns.Add(this.gridControl.Columns["btnEliminar"]);
           

            this.gridControl.ViewDefinition = columnGroupView;
        }
        private void CreateGridButton(RadGridView GridView, string name, string texthead, int width)
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
            var lista = ConciProdVsCtbleLogic.Instance.Traer(Logueo.CodigoEmpresa, Logueo.CodigoLinea);
            this.gridControl.DataSource = lista;
        }
        private void InsertarNuevaFila()
        {
            try
            {
                this.gridControl.Rows.AddNew();
                GridViewRowInfo row = this.gridControl.CurrentRow;                
                row.Cells["flag"].Value = "0";
                row.Cells["COS03CODLINEAPRODUCCION"].Value = Logueo.CodigoLinea;
                this.gridControl.Focus();
                this.gridControl.CurrentColumn = this.gridControl.Columns["PRO08DESC"];
                
                Util.ResaltarAyuda(row.Cells["PRO08DESC"]);
                Util.ResaltarAyuda(row.Cells["PRO09DESC"]);
                Util.ResaltarAyuda(row.Cells["COS01DESCRIPCION"]);
            }
            catch (Exception ex) { }
        }
        protected override void OnNuevo()
        {
            InsertarNuevaFila();
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
                else
                {
                    AsignarImagexBoton(e.Column.Name, cellElement, true, true, false, false);
                }
            }
        }
        private void mostrarAyuda(enmAyuda tipo) 
        { 
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipo) {
                case enmAyuda.enmLinea:
                    frm = new frmBusqueda(enmAyuda.enmLinea);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)                     
                        codigoSeleccionado = frm.Result.ToString();
                        this.gridControl.CurrentRow.Cells["COS03CODLINEAPRODUCCION"].Value = codigoSeleccionado;
                    break;
                case enmAyuda.enmActNivel1:
                    string codigoLinea = Util.convertiracadena(this.gridControl.CurrentRow.Cells["COS03CODLINEAPRODUCCION"].Value);
                    frm = new frmBusqueda(enmAyuda.enmActNivel1, codigoLinea);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    this.gridControl.CurrentRow.Cells["COS03CODACTPRODUCCION"].Value = codigoSeleccionado;
                    break;
                case enmAyuda.enmActCtble:
                    frm = new frmBusqueda(enmAyuda.enmActCtble);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if (frm.Result != null)
                        codigoSeleccionado = frm.Result.ToString();
                    this.gridControl.CurrentRow.Cells["COS03CODACTCONTABLE"].Value = codigoSeleccionado;
                    break;
            }
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                //Ayuda de Linea
                if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["PRO08DESC"].ColumnInfo.Index)
                {
                    mostrarAyuda(enmAyuda.enmLinea);
                }

                //Ayuda de Actividad de Produccion
                //COS01DESCRIPCION
                //if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["COS03CODACTPRODUCCION"].ColumnInfo.Index)
                if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["PRO09DESC"].ColumnInfo.Index)
                {
                    mostrarAyuda(enmAyuda.enmActNivel1);
                }

                //Ayuda de Actividad Contable
                if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["COS01DESCRIPCION"].ColumnInfo.Index)
                {
                    mostrarAyuda(enmAyuda.enmActCtble);
                }

            }
            if (e.KeyValue == (char)Keys.Enter)
            {
                gridControl.Focus();
                Util.SendTab(Keys.Enter.GetHashCode());
            }
            
        }
        private void ObtenerDescripcion(enmAyuda tipo, string codigo) { 
            string descripcion = string.Empty;

            switch (tipo) { 
                case enmAyuda.enmLinea:
                    codigo = Logueo.CodigoEmpresa + codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo,"LINEAPROD", out descripcion);
                    this.gridControl.CurrentRow.Cells["PRO08DESC"].Value = descripcion;
                    break;
                case enmAyuda.enmActNivel1:
                    codigo = Logueo.CodigoEmpresa +
                              Util.convertiracadena(this.gridControl.CurrentRow.Cells["COS03CODLINEAPRODUCCION"].Value) +
                              codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo, "ACTIVIDADNIVEL1", out descripcion);
                    this.gridControl.CurrentRow.Cells["PRO09DESC"].Value = descripcion;
                    break;
                case enmAyuda.enmActCtble:
                    codigo = Logueo.CodigoEmpresa  + codigo;
                    GlobalLogic.Instance.DameDescripcion(codigo, "ACTCONTABLE", out descripcion);
                    this.gridControl.CurrentRow.Cells["COS01DESCRIPCION"].Value = descripcion;
                    break;
                default:
                    break;
            }
        }
        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.CurrentColumn.Index == gridControl.CurrentRow.Cells["PRO08DESC"].ColumnInfo.Index) {
                if (e.Row.Cells["COS03CODLINEAPRODUCCION"] == null || e.Row.Cells["COS03CODLINEAPRODUCCION"].Value == null) return;
                ObtenerDescripcion(enmAyuda.enmLinea, this.gridControl.CurrentRow.Cells["COS03CODLINEAPRODUCCION"].Value.ToString());
            }

            if (gridControl.CurrentColumn.Index == gridControl.CurrentRow.Cells["PRO09DESC"].ColumnInfo.Index)
            {
                if (e.Row.Cells["COS03CODACTPRODUCCION"] == null || e.Row.Cells["COS03CODACTPRODUCCION"].Value == null) return;
                ObtenerDescripcion(enmAyuda.enmActNivel1, this.gridControl.CurrentRow.Cells["COS03CODACTPRODUCCION"].Value.ToString());
            }
            
            if (gridControl.CurrentColumn.Index == gridControl.CurrentRow.Cells["COS01DESCRIPCION"].ColumnInfo.Index)
            {
                if (e.Row.Cells["COS03CODACTCONTABLE"] == null || e.Row.Cells["COS03CODACTCONTABLE"].Value == null) return;
                ObtenerDescripcion(enmAyuda.enmActCtble, this.gridControl.CurrentRow.Cells["COS03CODACTCONTABLE"].Value.ToString());
            }

        }
        private bool Validar(GridViewRowInfo fila) {
            if (Util.convertiracadena(fila.Cells["PRO08DESC"].Value) == "" || 
                Util.convertiracadena(fila.Cells["PRO08DESC"].Value) == "???" ) 
            {
                ShowAlertExclamation("Sistema", "Ingresar Linea");
                return false;
            }

            if (Util.convertiracadena(fila.Cells["PRO09DESC"].Value) == "" || 
                Util.convertiracadena(fila.Cells["PRO09DESC"].Value) == "???")
            {
                ShowAlertExclamation("Sistema", "Ingresar Actividad Produccion");
                return false;
            }


            if (Util.convertiracadena(fila.Cells["COS01DESCRIPCION"].Value) == "" || 
                Util.convertiracadena(fila.Cells["COS01DESCRIPCION"].Value) == "???")
            {
                ShowAlertExclamation("Sistema", "Ingresar Actividad Contable");
                return false;
            }

            return true;   
        }
        private void Guardar(GridViewRowInfo fila) {
            string mensaje = string.Empty;
            int flag = 0;
            try
            {
                if (!Validar(fila)) return;
                conciliacion.COS03CODEMP = Logueo.CodigoEmpresa;
                conciliacion.COS03CODLINEAPRODUCCION = this.gridControl.CurrentRow.Cells["COS03CODLINEAPRODUCCION"].Value.ToString();
                conciliacion.COS03CODACTCONTABLE = this.gridControl.CurrentRow.Cells["COS03CODACTCONTABLE"].Value.ToString();
                conciliacion.COS03CODACTPRODUCCION = this.gridControl.CurrentRow.Cells["COS03CODACTPRODUCCION"].Value.ToString();
                if (fila.Cells["flag"].Value.ToString() == "0")
                {
                    ConciProdVsCtbleLogic.Instance.Insertar(conciliacion, out mensaje, out flag);
                    ShowAlertOk("Sistema", mensaje);
                }
                if (flag == 0)
                {
                    OnBuscar();
                }
            }
            catch (Exception ex) {
                ShowAlertExclamation("Sistema", ex.Message);
            }
        }
        private void Editar(GridViewRowInfo fila) {

            //modo editar
            this.gridControl.CurrentRow.Cells["flag"].Value = "1";
            Util.ResaltarAyuda(fila.Cells["PRO08DESC"]);
            Util.ResaltarAyuda(fila.Cells["COS03CODACTPRODUCCION"]);
            Util.ResaltarAyuda(fila.Cells["COS01DESCRIPCION"]);
        }
        private void Eliminar(GridViewRowInfo fila) {
            string mensaje = string.Empty;
            int flag = 0;
            conciliacion.COS03CODEMP = Logueo.CodigoEmpresa;
            conciliacion.COS03CODLINEAPRODUCCION = this.gridControl.CurrentRow.Cells["COS03CODLINEAPRODUCCION"].Value.ToString();
            conciliacion.COS03CODACTCONTABLE = this.gridControl.CurrentRow.Cells["COS03CODACTCONTABLE"].Value.ToString();
            conciliacion.COS03CODACTPRODUCCION = this.gridControl.CurrentRow.Cells["COS03CODACTPRODUCCION"].Value.ToString();
            DialogResult res;

            ShowAlertQuestion("Sistema", "¿Desea eliminar el registro?", out res);
            if (res == System.Windows.Forms.DialogResult.Yes) {
                ConciProdVsCtbleLogic.Instance.Eliminar(conciliacion, out mensaje, out flag);
                if (flag == 0)
                {
                    ShowAlertOk("Sistema", mensaje);
                }
                else {
                    ShowAlertExclamation("Sistema", mensaje);
                }
            }
            OnBuscar();
            
        }
        private void Cancelar(GridViewRowInfo fila) {
            
            OnBuscar();
        
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            switch (this.gridControl.CurrentColumn.Name)
            {
                case "btnGrabar":
                    Guardar(this.gridControl.CurrentRow);
                    break;
                //case "btnEditar":
                //    Editar(this.gridControl.CurrentRow);
                //    break;
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

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            //if (e.Row.Cells[""].Value == null) {
            //    e.Cancel = true;
            //}
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if (e.CurrentRow == null) return;
                string FlagActual = Util.convertiracadena(e.CurrentRow.Cells["flag"].Value);
                if (FlagActual == "0" )
                {
                    e.Cancel = true;
                    if (e.NewRow.Cells["COS03CODLINEAPRODUCCION"].Value == null)
                    {
                        e.NewRow.Delete();
                    }
                    ShowAlertExclamation("Sistema", "Debe Completar el registro");
                }
            }
            catch (Exception ex) { 
            
            }
        }
    }
}
