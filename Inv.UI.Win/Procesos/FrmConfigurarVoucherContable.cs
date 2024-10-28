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
    public partial class FrmConfigurarVoucherContable : frmBaseMante
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
        private static FrmConfigurarVoucherContable _aForm;
        public static FrmConfigurarVoucherContable Instance(frmMDI mdiPrincipal)
        {   
            if (_aForm != null) return new FrmConfigurarVoucherContable(mdiPrincipal);
            _aForm = new FrmConfigurarVoucherContable(mdiPrincipal);
            return _aForm;
        }
       
        
        protected override void OnNuevo()
        {
            //HabilitarBotones(false, false, false, false, false, false);
            gridControl.Rows.AddNew();
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "flag", "0");

        }

        //protected override void OnEditar()
        //{
        //    //base.OnEditar();
            
        //    HabilitarBotones(false, false, false, false, false, false);
        //}

        //protected override void OnGuardar()
        //{
        //    base.OnGuardar();
        //}
        
        private void agregarColumnasBotones() 
        {

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

            GridViewCommandColumn colEliminar = new GridViewCommandColumn();
            colEliminar.Name = "btnEliminar";
            colEliminar.HeaderText = "";
            gridControl.Columns.Add(colEliminar);
            gridControl.Columns["btnEliminar"].BestFit();
            gridControl.Columns["btnEliminar"].MinWidth = 30;


            GridViewCommandColumn colModificar = new GridViewCommandColumn();
            colModificar.Name = "btnModificar";
            colModificar.HeaderText = "";
            gridControl.Columns.Add(colModificar);
            gridControl.Columns["btnModificar"].BestFit();
            gridControl.Columns["btnModificar"].MinWidth = 30;

                                    
        }
        public FrmConfigurarVoucherContable(frmMDI padre) 
        {
            InitializeComponent();
            FrmParent = padre;
            
        }

        protected override void OnBuscar()
        {
            //var lista = ArticuloCaracteristicasLogic.Instance.ArticuloCararcticasUnidMedXTipo("01");
            //this.gridControl.DataSource = lista;

            var lista =  ConfigVoucherLogic.Instance.Traer(Logueo.CodigoEmpresa, Logueo.Anio);
            this.gridControl.DataSource = lista;
        }
        
        void crearColumnas() {

         RadGridView Grilla = CreateGridVista(gridControl);
            //oculto
            CreateGridColumn(Grilla, "IN29CODEMP", "IN29CODEMP", 0, "", 70, false, true, false);
            CreateGridColumn(Grilla, "IN29AA", "IN29AA", 0, "", 70, false, true, false);
            CreateGridColumn(Grilla, "Cod.Alm", "IN29CODALM", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Transa", "in29transaccionCod", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Tipo.Art", "IN29TIPOARTI", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Cta.Alm", "IN29CTAALMACEN", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Cta.Gastos", "IN29CTAGASTOS", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Cta.Existencia", "IN29CTAVAREXISTENCIAS", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Cta.Nueve", "IN29CTANUEVE", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Cuenta Debe", "in29CuentaDebe", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "Cuenta Haber", "in29CuentaHaber", 0, "", 70, false, true, true);
            CreateGridColumn(Grilla, "flag", "flag", 0, "", 70, false, true, false);
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
            if (e.Column.Name == "btnEliminar")
            {
                cellElement.CommandButton.Image = Properties.Resources.deleted_enabled;
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
                        cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }
                    if (e.Column.Name == "btnModificar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.edited_enabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = true;
                    }

                    if (e.Column.Name == "btnEliminar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.deleted_enabled;
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

                    if (e.Column.Name == "btnEliminar")
                    {
                        cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
                        cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                        cellElement.CommandButton.Enabled = false;
                    }

                    
                }
            }

        }
        private void cancelarRegistroGrilla() {            
            OnBuscar();

            //Util.enfocarFila(gridControl, "Codigo", articulo.codigo);            
        }

        private void editarRegistroGrilla() {
            gridControl.CurrentRow.Cells["flag"].Value = "1";

            //string codigo = gridControl.CurrentRow.Cells["Codigo"].Value.ToString();
            //Util.enfocarFila(gridControl, "Codigo", codigo);
            //this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].ReadOnly = false;
            
            //this.gridControl.CurrentRow.Cells["glo01largoUnimed"].ReadOnly = false;
            //this.gridControl.CurrentRow.Cells["glo01altoUnimed"].ReadOnly = false;
        }
        private void eliminarRegistroGrilla() {
            try
            {
                
                string almacen = "",transaccion = "", tipoArticulo = "", mensaje = "";
                int flag = 0;
                almacen = Util.GetCurrentCellText(gridControl.CurrentRow, "IN29CODALM");
                transaccion = Util.GetCurrentCellText(gridControl.CurrentRow, "in29transaccionCod");
                tipoArticulo = Util.GetCurrentCellText(gridControl.CurrentRow, "IN29TIPOARTI");
                
                ConfigVoucherLogic.Instance.Eliminar(Logueo.CodigoEmpresa,
                    Logueo.Anio, almacen, transaccion, tipoArticulo, out flag, out mensaje);
                Util.ShowMessage(mensaje, flag);
                if (flag == 1)
                {
                    OnBuscar();
                }
                
            }
            catch (Exception ex) {
                Util.ShowError("Error al eliminar registro");
            }
        }
        //ArticuloCaracteristicas articulo = new ArticuloCaracteristicas();
        
      
        //private bool Validar() {
            
        //    if (this.gridControl.CurrentRow.Cells["glo01altoUnimed"].Value.ToString().Trim() == "" 
        //        || this.gridControl.CurrentRow.Cells["glo01altoUnimed"].Value.ToString().Trim() == "???") {
        //        RadMessageBox.Show("Ingresar alto", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
        //        return false;
        //    }
        //    if (this.gridControl.CurrentRow.Cells["glo01largoUnimed"].Value.ToString().Trim() == "" ||
        //        this.gridControl.CurrentRow.Cells["glo01largoUnimed"].Value.ToString().Trim() == "???")
        //    {
        //        RadMessageBox.Show("Ingresar largo", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
        //        return false;
        //    }
        //    if(this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].Value.ToString().Trim() == "" ||
        //        this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].Value.ToString().Trim() == "???"){
        //        RadMessageBox.Show("Ingresar ancho", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
        //        return false;
        //    }
        //    return true;
        //}
        private  void grabarRegistroGrilla(GridViewRowInfo fila) {
            //if (!Validar()) return;
                        
            ConfiguraVoucherContable cvc = new ConfiguraVoucherContable();

            try
            {
                cvc.IN29CODEMP = Logueo.CodigoEmpresa;
                cvc.IN29AA = Logueo.Anio;
                cvc.IN29CODALM = Util.GetCurrentCellText(fila, "IN29CODALM");
                cvc.in29transaccionCod = Util.GetCurrentCellText(fila, "in29transaccionCod");
                cvc.IN29TIPOARTI = Util.GetCurrentCellText(fila, "IN29TIPOARTI");
                cvc.IN29CTAALMACEN = Util.GetCurrentCellText(fila, "IN29CTAALMACEN");
                cvc.IN29CTAGASTOS = Util.GetCurrentCellText(fila, "IN29CTAGASTOS");
                cvc.IN29CTAVAREXISTENCIAS = Util.GetCurrentCellText(fila, "IN29CTAVAREXISTENCIAS");
                cvc.IN29CTANUEVE = Util.GetCurrentCellText(fila, "IN29CTANUEVE");
                cvc.in29CuentaDebe = Util.GetCurrentCellText(fila, "in29CuentaDebe");
                cvc.in29CuentaHaber = Util.GetCurrentCellText(fila, "in29CuentaHaber");

                string flagEstado = Util.GetCurrentCellText(fila, "flag");
                int flag = 0; string mensaje = "";

                if (flagEstado == "0")
                {
                    ConfigVoucherLogic.Instance.Insertar(cvc, out flag, out mensaje);
                }
                else if (flagEstado == "1")
                {
                    ConfigVoucherLogic.Instance.Actualizar(cvc, out flag, out mensaje);
                }
                //ArticuloCaracteristicasLogic.Instance.ArticuloUnidadMedidaxTipoActualizar(articulo, out mensaje);
                Util.ShowMessage(mensaje, flag);
                if (flag == 1)
                {
                    //RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    OnBuscar();
                    cancelarRegistroGrilla();
                }
                
            
            }
            catch (Exception ex) {
                Util.ShowError("Error al guardar");
            }
            
            
            
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

            if (this.gridControl.Columns["btnEliminar"].IsCurrent) {
                eliminarRegistroGrilla();
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
                else if (e.Row.Cells["flag"].Value.ToString() == "1") {
                    if (e.Column.Name == "IN29CODALM" || e.Column.Name == "in29transaccionCod"
                        || e.Column.Name == "IN29TIPOARTI") {
                            e.Cancel = true;
                            return;
                    }
                    
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
        //private void ObtenerDescripcion(enmAyuda tipoAyuda,string codigo) {
        //    try
        //    {
        //        string descripcion = string.Empty;
        //        switch (tipoAyuda) 
        //        {
        //            case enmAyuda.enmUniMed:
        //                codigo = Logueo.CodigoEmpresa + codigo;
        //                GlobalLogic.Instance.DameDescripcion(codigo, "UNIDAD", out descripcion);
        //                this.gridControl.CurrentCell.Value = descripcion;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { 
                
        //    }
        //}
        //private void MostrarAyuda(enmAyuda tipoAyuda)
        //{
        //    frmBusqueda frm;
        //    string codigoSeleccionado = string.Empty;
        //    switch (tipoAyuda)
        //    {
        //        case enmAyuda.enmUniMed:
        //            frm = new frmBusqueda(tipoAyuda);
        //             frm.Owner = this;                     
        //             frm.ShowDialog();
        //             if (frm.Result != null)
        //                 codigoSeleccionado = frm.Result.ToString();
        //             this.gridControl.CurrentCell.Value = codigoSeleccionado;
        //             //ObtenerDescripcion(tipoAyuda, codigoSeleccionado);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (this.gridControl.CurrentRow.Cells["flag"] != null &&
            //    this.gridControl.CurrentRow.Cells["flag"].Value != null) 
            //{
            //    if (e.KeyData == Keys.F1)
            //    {
            //        if (this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["glo01altoUnimed"].ColumnInfo.Index
            //            || this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["glo01largoUnimed"].ColumnInfo.Index
            //            || this.gridControl.CurrentColumn.Index == this.gridControl.CurrentRow.Cells["glo01anchoUnimed"].ColumnInfo.Index)
            //        {
            //            this.MostrarAyuda(enmAyuda.enmUniMed); 
            //        }
                   
            //    }
            //}
            
        }

        private void FrmConfigurarVoucherContable_Load(object sender, EventArgs e)
        {
            crearColumnas();
            OnBuscar();
            //OcultaBarraBotones();
            OcultarBotones();
            //HabilitarBotones(false, false, false, false, false, false);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
        }
    }
}
