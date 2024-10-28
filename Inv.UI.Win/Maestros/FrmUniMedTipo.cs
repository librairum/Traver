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
using Telerik.WinControls.UI.Docking;

namespace Inv.UI.Win
{
    public partial class FrmUniMedTipo : frmBaseMante
    {
        //public FrmUniMedTipo()
        //{
        //    InitializeComponent();
        //}
        private bool isLoaded = false;
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a, cancelar_a;
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
        private frmMDI FrmParent { get; set; }
        private static FrmUniMedTipo _aForm;
        public static FrmUniMedTipo Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmUniMedTipo(mdiPrincipal);
            _aForm = new FrmUniMedTipo(mdiPrincipal);
            return _aForm;
        }
       
        
        protected override void OnNuevo()
        {
            HabilitarBotones(false, false, false, false, false, false);
        }

        protected override void OnEditar()
        {
            //base.OnEditar();
            HabilitarBotones(false, false, false, false, false, false);
        }

        protected override void OnGuardar()
        {
            base.OnGuardar();
        }
        
        private void agregarColumnasBotones() 
        {
            GridViewCommandColumn colModificar = new GridViewCommandColumn();
            colModificar.Name = "btnModificar";
            colModificar.HeaderText = "";
            gridControl.Columns.Add(colModificar);
            gridControl.Columns["btnModificar"].BestFit();
            gridControl.Columns["btnModificar"].MinWidth = 30;
            GridViewCommandColumn colGrabar = new GridViewCommandColumn();
            colGrabar.Name = "btnGrabar";
            colGrabar.HeaderText = "";
            gridControl.Columns.Add(colGrabar);
            gridControl.Columns["btnGrabar"].BestFit();
            gridControl.Columns["btnGrabar"].MinWidth = 30;
            GridViewCommandColumn colCancelar = new GridViewCommandColumn();
            colCancelar.Name = "btnCancelar";
            colCancelar.HeaderText = "";
            gridControl.Columns.Add(colCancelar);
            gridControl.Columns["btnCancelar"].BestFit();
            gridControl.Columns["btnCancelar"].MinWidth = 30;
        }
        public FrmUniMedTipo(frmMDI padre) 
        {
            InitializeComponent();
            FrmParent = padre;
            crearColumnas();
            OnBuscar();
            
            HabilitarBotones(false, false, false, false, false, false);
        }

        protected override void OnBuscar()
        {
            var lista = ArticuloCaracteristicasLogic.Instance.ArticuloCararcticasUnidMedXTipo("01");
            this.gridControl.DataSource = lista;
        }
        
        void crearColumnas() {

         RadGridView Grilla = CreateGridVista(gridControl);
         CreateGridColumn(Grilla, "glo01codigotabla", "codigotabla", 0, "", 30, true, false, false);
         CreateGridColumn(Grilla, "Codigo", "Codigo", 0, "", 70);
         CreateGridColumn(Grilla, "Descripcion", "Descripcion", 0, "", 140);
         CreateGridColumn(Grilla, "Ancho", "glo01anchoUnimed", 0, "", 100,true, false);
         CreateGridColumn(Grilla, "Largo", "glo01largoUnimed", 0, "", 100, true, false);
         CreateGridColumn(Grilla, "Alto", "glo01altoUnimed", 0, "", 100, true, false);
         CreateGridColumn(Grilla, "flag", "flag", 0, "", 50, true, false, false);
         agregarColumnasBotones();
        }

        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;
            if (e.Column.Name == "btnModificar") {
                cellElement.CommandButton.Image = Properties.Resources.edited_enabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
            }
            if (e.Column.Name == "btnGrabar")
            {
                cellElement.CommandButton.Image = Properties.Resources.save_enabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
            }

            if (e.Column.Name == "btnCancelar")
            {
                cellElement.CommandButton.Image = Properties.Resources.cancel_enabled;
                cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
            }

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                RadButtonElement button = (RadButtonElement)e.CellElement.Children[0];
                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {
                    if (e.Column.Name == "btnGrabar")
                    {

                        cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnCancelar")
                    {
                        //cellElement.CommandButton.Image = Properties.Resources.arrow_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnModificar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.edited_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }
                }
                else {
                    if (e.Column.Name == "btnGrabar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.save_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }
                    if (e.Column.Name == "btnCancelar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.cancel_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }
                    if (e.Column.Name == "btnModificar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                }
            }

        }
        private void cancelarRegistroGrilla() {            
            OnBuscar();
            Util.enfocarFila(gridControl, "Codigo", articulo.codigo);            
        }

        private void editarRegistroGrilla() {
            gridControl.CurrentRow.Cells["flag"].Value = "0";
            string codigo = gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
            Util.enfocarFila(gridControl, "Codigo", codigo);
            //this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].ReadOnly = false;
            
            //this.gridControl.CurrentRow.Cells["glo01largoUnimed"].ReadOnly = false;
            //this.gridControl.CurrentRow.Cells["glo01altoUnimed"].ReadOnly = false;
        }
        ArticuloCaracteristicas articulo = new ArticuloCaracteristicas();
        private void cargarEntidad() {
            articulo.codigotabla = "01";
            GridViewRowInfo fila = this.gridControl.CurrentRow;

            articulo.codigo = fila.Cells["Codigo"].Value.ToString();
            articulo.codigotabla = "01"; //-- codigo de tabla
            articulo.glo01altoUnimed = fila.Cells["glo01altoUnimed"].Value.ToString();
            articulo.glo01largoUnimed = fila.Cells["glo01largoUnimed"].Value.ToString();
            articulo.glo01anchoUnimed = fila.Cells["glo01anchoUnimed"].Value.ToString();

        }
        private bool Validar() {
            
            if (this.gridControl.CurrentRow.Cells["glo01altoUnimed"].Value.ToString().Trim() == "" 
                || this.gridControl.CurrentRow.Cells["glo01altoUnimed"].Value.ToString().Trim() == "???") {
                RadMessageBox.Show("Ingresar alto", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            if (this.gridControl.CurrentRow.Cells["glo01largoUnimed"].Value.ToString().Trim() == "" ||
                this.gridControl.CurrentRow.Cells["glo01largoUnimed"].Value.ToString().Trim() == "???")
            {
                RadMessageBox.Show("Ingresar largo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            if(this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].Value.ToString().Trim() == "" ||
                this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].Value.ToString().Trim() == "???"){
                RadMessageBox.Show("Ingresar ancho", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            return true;
        }
        private  void grabarRegistroGrilla(GridViewRowInfo fila) {
            if (!Validar()) return;
            cargarEntidad();
            string mensaje = string.Empty;
            ArticuloCaracteristicasLogic.Instance.ArticuloUnidadMedidaxTipoActualizar(articulo, out mensaje);
            RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            
            OnBuscar();
            cancelarRegistroGrilla();
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabar"].IsCurrent)
            {
                grabarRegistroGrilla(this.gridControl.CurrentRow);
            }

            if (this.gridControl.Columns["btnCancelar"].IsCurrent)
            {
                cancelarRegistroGrilla();
            }

            if (this.gridControl.Columns["btnModificar"].IsCurrent)
            {
                editarRegistroGrilla();
            }
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (this.gridControl.ActiveEditor != null)
            {
                if (e.Row.Cells["flag"] == null || 
                    e.Row.Cells["flag"].Value == null)
                {
                    e.Cancel = true;
                    return;
                }
                else if (e.Row.Cells["flag"].Value.ToString() == "0" 
                    && (e.Column.Name == "btnGrabar" || e.Column.Name == "btnCancelar" || e.Column.Name == "btnModificar"))
                {

                    e.Cancel = false;
                }            
            }
           
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (e.CurrentRow == null || e.CurrentRow.Cells["flag"].Value == null) return;
            if (e.CurrentRow.Cells["flag"].Value.ToString() == "0") {
                RadMessageBox.Show("Debe completar el registro", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                e.Cancel = true;
            }
        }
        private void ObtenerDescripcion(enmAyuda tipoAyuda,string codigo) {
            try
            {
                string descripcion = string.Empty;
                switch (tipoAyuda) 
                {
                    case enmAyuda.enmUniMed:
                        codigo = Logueo.CodigoEmpresa + codigo;
                        GlobalLogic.Instance.DameDescripcion(codigo, "UNIDAD", out descripcion);
                        this.gridControl.CurrentCell.Value = descripcion;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { 
                
            }
        }
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda)
            {
                case enmAyuda.enmUniMed:
                    frm = new frmBusqueda(tipoAyuda);
                     frm.Owner = this;                     
                     frm.ShowDialog();
                     if (frm.Result != null)
                         codigoSeleccionado = frm.Result.ToString();
                     this.gridControl.CurrentCell.Value = codigoSeleccionado;
                     //ObtenerDescripcion(tipoAyuda, codigoSeleccionado);
                    break;
                default:
                    break;
            }
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.gridControl.CurrentRow.Cells["flag"] != null &&
                this.gridControl.CurrentRow.Cells["flag"].Value != null) 
            {
                if (e.KeyData == Keys.F1)
                {
                    if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["glo01altoUnimed"].ColumnInfo.Index
                        || this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["glo01largoUnimed"].ColumnInfo.Index
                        || this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].ColumnInfo.Index)
                    {
                        this.MostrarAyuda(enmAyuda.enmUniMed); 
                    }
                   
                }
            }
            
        }
    }
}
