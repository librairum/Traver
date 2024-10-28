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
namespace Fac.UI.Win
{
    public partial class frmabcAsientoTipo : frmBaseReg
    {
        AsientoTipoLogic datos = AsientoTipoLogic.Instance;

        #region "Instancia"
        private frmAsientoTipo FrmParent { get; set; }

        private static frmabcAsientoTipo _aForm;
        public static frmabcAsientoTipo Instance(frmAsientoTipo frmParent)
        {
            if (_aForm != null) return new frmabcAsientoTipo(frmParent);
            _aForm = new frmabcAsientoTipo(frmParent);
            return _aForm;
        }
        #endregion
        public frmabcAsientoTipo(frmAsientoTipo padre)
        {
            InitializeComponent();
            
            FrmParent = padre;
            
        }
        private bool ValidaCabAsientoTipo()
        {
            if (txtCodigo.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar descripcion");
                txtCodigo.Focus();
                return false;
            }
            if (txtDescripcion.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar descripcion");
                txtDescripcion.Focus();
                return false;
            }
            if (txtLibroDesc.Text.Trim() == "")
            {
                Util.ShowAlert("Seleccionar libro");
                txtLibroCod.Focus();
                return false;
            }
            return true;
        }
        protected override void OnGuardar()
        {
            try
            {
                if (ValidaCabAsientoTipo() == false) return;
                string mensaje = "";
                
                datos.InsertarCabAsientoTipo(Logueo.CodigoEmpresa, txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(),
                    txtLibroCod.Text.Trim(), out mensaje);
                Util.ShowMessage(mensaje, 0);

                txtCodigo.Enabled = false;
                Estado = FormEstate.Edit;
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            btnAgregar.Enabled = true;
        }
        void HabilitarControles(bool valor)
        {
            txtCodigo.Enabled = valor;
            txtDescripcion.Enabled = valor;

            txtLibroCod.Enabled = valor;            
            txtLibroDesc.Enabled = valor;
        }
        void LimpiarControles()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtLibroCod.Text = "";
            txtLibroDesc.Text = "";
        }
        private void CrearColumnas()
        { 
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "FAC09CODEMP", "FAC09CODEMP", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "FAC08COD", "FAC08COD", 0, "", 90, true, false, false);// codigo varchar(5)
            CreateGridColumn(Grid, "Nº Orden", "FAC09ORDEN", 0, "", 90, false, true, true); //int campo editable
            
            // Cuenta contable
            
            CreateGridColumn(Grid , "Cta.Ctble", "FAC09CTA", 0, "", 90, true, false, true); //varchar campo de ayuda
            CreateGridColumn(Grid , "Descripcion", "FAC09CTA_Des", 0, "", 120); //varchar campo no editable 

            CreateGridColumn(Grid, "FAC09CAMPO", "FAC09CAMPO", 0, "", 90, true, false, false); // campo de codigo de ayuda
            CreateGridColumn(Grid, "Part.Doc", "FAC09CAMPO_des", 0, "", 120); // campo no editable  -- campo

            CreateGridColumn(Grid, "FAC09FLAG", "FAC09FLAG", 0, "", 90, true, false, false); // Codigo Cargo Abono campo de ayuda
            CreateGridColumn(Grid, "Cargo/Abono", "FAC09FLAG_des", 0, "", 120); //varchar Cargo Abono campo no editable
            
            CreateGridColumn(Grid, "Porcentaje", "FAC09PORCENTAJE", 0, "", 90, false, true, true); //double editable por teclado

            CreateGridColumn(Grid, "Columna", "FAC09COLUMNA", 0, "", 90,false, false, true); // FAC09COLUMNA	char editable por teclado

            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 90, true, false, false);                                                                                    

            AddButonsToGrid();
        }
        bool ValidarDetalle()
        { 
            
                if( Util.GetCurrentCellText(gridControl, "FAC08COD") == "" ||
                    Util.GetCurrentCellText(gridControl, "FAC09ORDEN") == "" ||
                    Util.GetCurrentCellText(gridControl, "FAC09CTA") == "" ||
                    Util.GetCurrentCellText(gridControl, "FAC09FLAG") == "" ||
                    Util.GetCurrentCellText(gridControl, "FAC09CAMPO") == "" ||
                    Util.GetCurrentCellText(gridControl, "FAC09PORCENTAJE") == "")
                {
                    Util.ShowAlert("Debe completar los datos del registro");
                    return false;    
                }
                return true;
        }
        void GuardarDetalle()
        {

            try
            {
                if (ValidarDetalle() == false) return;
                AsientoTipo ent = new AsientoTipo();

                ent.FAC09CODEMP = Logueo.CodigoEmpresa;
                ent.FAC08COD = Util.GetCurrentCellText(gridControl, "FAC08COD");
                ent.FAC09ORDEN = Util.GetCurrentCellInt(gridControl, "FAC09ORDEN");
                ent.FAC09CTA = Util.GetCurrentCellText(gridControl, "FAC09CTA");
                ent.FAC09FLAG = Util.GetCurrentCellText(gridControl, "FAC09FLAG");
                ent.FAC09CAMPO = Util.GetCurrentCellText(gridControl, "FAC09CAMPO");
                ent.FAC09PORCENTAJE = Util.GetCurrentCellDbl(gridControl, "FAC09PORCENTAJE");
                ent.FAC09COLUMNA = Util.GetCurrentCellText(gridControl, "FAC09COLUMNA");
                string mensaje = "";
                
                string sFlag = Util.GetCurrentCellText(gridControl, "flag");
                int int_flag = 0;
                if (sFlag == "0")
                {
                    //Insertar
                    datos.InsertarDetTipoAsiento(ent, out int_flag, out mensaje);                    
                }
                else if (sFlag == "1")
                {
                    //Actualizar
                    datos.ActualizarDetTipoAsiento(ent, out int_flag, out mensaje);                    
                }
                
                Util.ShowMessage(mensaje, int_flag);

                if (int_flag == 1)
                {
                    
                    //Actualizar la ventana actual de mantenimiento.
                    CancelarDetalle();

                    //Actualizar la grilla principal
                    FrmParent.CargarCabecera();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Guardar detalle : " + ex.Message);
            }
            
        }
        void EliminarDetalle()
        {
            try
            {
                if (HasRowToSave() > 0)
                {
                    Util.ShowAlert("Debe completar registro");
                    return;
                }

                bool res = Util.ShowQuestion("¿Desea eliminar el registro?");
                int int_flag = 0;
                if (res == true)
                {
                    string codigoDetalle = Util.GetCurrentCellText(gridControl, "FAC08COD");
                    int ordenDetalle = Util.GetCurrentCellInt(gridControl, "FAC09ORDEN");
                    string mensaje = "";

                    datos.EliminarDetTipoAsiento(Logueo.CodigoEmpresa, codigoDetalle, ordenDetalle,  out int_flag,out mensaje);

                    Util.ShowMessage(mensaje, int_flag);
                    if (int_flag == 1)
                    {
                        CancelarDetalle();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle: " + ex.Message);
            }

            
        }
        void CancelarDetalle()
        {            
            TraeDetAsientoTipo();
            txtCodigo.Enabled = false;
        }
        void EditarDetalle()
        {
            if (HasRowToSave() > 0) { Util.ShowAlert("Debe completar registro"); return; }
            
            Util.ResaltarAyuda(gridControl, "FAC09CTA_Des");
            Util.ResaltarAyuda(gridControl, "FAC09FLAG_des");
            Util.ResaltarAyuda(gridControl, "FAC09CAMPO_des");

            Util.SetValueCurrentCellText(gridControl, "flag", "1");        // flag de registro en modo actualizacion
            this.gridControl.CurrentRow.Cells["flagBotones"].Value = "E"; //  flag de edicion de fila 
            this.gridControl.CurrentColumn = this.gridControl.Columns["FAC09CTA"];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
        }
        #region "Metodos"
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Tab)
            {
                this.gridControl.CurrentRow.Cells[this.gridControl.CurrentColumn.Index].BeginEdit();
            }
            if(gridControl.Rows.Count == 0) return;

            string sFlag = Util.GetCurrentCellText(gridControl, "flag");
            if (sFlag == "0" || sFlag == "1")
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    string ColumnName = gridControl.CurrentColumn.Name;
                    if (ColumnName == gridControl.Columns["FAC09CTA_Des"].Name)
                    {
                        mostrarAyuda(enmAyuda.enmCtaContable);
                    }
                    else if (ColumnName == gridControl.Columns["FAC09FLAG_des"].Name)
                    {
                        mostrarAyuda(enmAyuda.enmFlagCargoAbono);
                    }
                    else if (ColumnName == gridControl.Columns["FAC09CAMPO_des"].Name)
                    {
                        mostrarAyuda(enmAyuda.enmTipoImporteDocu);
                    }
                }
            }
        }
        private void CargaDetalle()
        {
            //Carga la cabecera del detalle asiento tipo
            txtCodigo.Text = Util.convertiracadena(FrmParent.gridControl.CurrentRow.Cells["FAC08COD"].Value);
            txtDescripcion.Text = Util.convertiracadena(FrmParent.gridControl.CurrentRow.Cells["FAC08DES"].Value);
            txtLibroCod.Text = Util.convertiracadena(FrmParent.gridControl.CurrentRow.Cells["FAC08CODLIBRO"].Value);
            txtLibroDesc.Text = Util.convertiracadena(FrmParent.gridControl.CurrentRow.Cells["LibroDesc"].Value);
            TraeDetAsientoTipo();
        }
        private void TraeDetAsientoTipo()
        {
            //Carga el detalle asiento tipo
            try
            {
                List<AsientoTipo> lista = AsientoTipoLogic.Instance.TraerDetalleAsientoTipo(Logueo.CodigoEmpresa, "2018",
                                          txtCodigo.Text.Trim(), "FAC09CTA", "*");
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar el detallde de tipo de asiento : " + ex.Message);
            }
        }

        private void AgregarFila()
        {
            try
            {
               
                if (gridControl.Rows.Count > 0)
                {
                    if (gridControl.CurrentRow.Cells["flag"].Value != null)
                    {
                        Util.ShowAlert("Debe completar el registro actual");
                        return;
                    }
                  
                }
                gridControl.Rows.AddNew();
                Util.SetValueCurrentCellText(gridControl, "FAC09CODEMP", Logueo.CodigoEmpresa);
                Util.SetValueCurrentCellText(gridControl, "FAC08COD", txtCodigo.Text.Trim());

                Util.ResaltarAyuda(gridControl,"FAC09CTA_Des");
                Util.ResaltarAyuda(gridControl, "FAC09FLAG_des");
                Util.ResaltarAyuda(gridControl,"FAC09CAMPO_des");

                Util.SetValueCurrentCellText(gridControl, "flag", "0");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agrega fila: " + ex.Message);
            }
            this.gridControl.Focus();

        }
        private void AddButonsToGrid()
        {
            AddCmdButtonToGrid(gridControl, "btnGrabarDet", "", "btnGrabarDet");
            AddCmdButtonToGrid(gridControl, "btnCancelarDet", "", "btnCancelarDet");
            AddCmdButtonToGrid(gridControl, "btnEliminarDet", "", "btnEliminarDet");
            AddCmdButtonToGrid(gridControl, "btnEditarDet", "", "btnEditarDet");
        }
        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
            //Grid.Columns[NameButon].BestFit();
        }
        private void deshabilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":

                    cellElement.CommandButton.Image = Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnCancelarDet":
                    cellElement.CommandButton.Image = Properties.Resources.cancel_disabled;
                    
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEliminarDet":
                    cellElement.CommandButton.Image = Properties.Resources.delete_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                case "btnEditarDet":
                    cellElement.CommandButton.Image = Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = false;
                    break;
                default:
                    break;
            }

        }
        private int HasRowToSave()
        {
            int rowsaffected = 0;

            foreach (GridViewRowInfo row in gridControl.Rows)
            {
                if (Util.GetCurrentCellText(row, "flagBotones") == "E")
                    rowsaffected++;
            }
            return rowsaffected;
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
                    case enmAyuda.enmLibros:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();

                        if (frm.Result != null)
                        {
                            if (frm.Result.ToString() != "")
                            {
                                datos = frm.Result.ToString().Split('|');
                                txtLibroCod.Text = Util.convertiracadena(datos[0]);
                                txtLibroDesc.Text = Util.convertiracadena(datos[1]);
                            }
                        }
                        break;
                    case enmAyuda.enmCtaContable:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result != null)
                        {
                            if (frm.Result.ToString() != "")
                            {
                                datos = frm.Result.ToString().Split('|');
                                Util.SetValueCurrentCellText(gridControl, "FAC09CTA", datos[0]);
                                Util.SetValueCurrentCellText(gridControl, "FAC09CTA_Des", datos[1]);

                            }
                        }
                        break;
                    case enmAyuda.enmFlagCargoAbono:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result != null)
                        {
                            if (frm.Result.ToString() != "")
                            {
                                datos = frm.Result.ToString().Split('|');
                                Util.SetValueCurrentCellText(gridControl, "FAC09FLAG", datos[0]);
                                Util.SetValueCurrentCellText(gridControl, "FAC09FLAG_des", datos[1]);
                            }
                        }
                        break;
                    case enmAyuda.enmTipoImporteDocu:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result != null)
                        {
                            if (frm.Result.ToString() != "")
                            {
                                datos = frm.Result.ToString().Split('|');
                                Util.SetValueCurrentCellText(gridControl, "FAC09CAMPO", datos[0]);
                                Util.SetValueCurrentCellText(gridControl, "FAC09CAMPO_des", datos[1]);
                            }
                        }
                        break;
                    default:
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda: " + ex.Message);
            }
            
        }
        #endregion
        #region "Eventos"
        private void txtLibroCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                mostrarAyuda(enmAyuda.enmLibros);
            }
        }
        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {

            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {

                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);

                if (Estado == FormEstate.View)
                {
                    deshabilitarBotonProdDet(e.Column.Name, cellElement);
                    return;
                }

                //if (gridControl.Rows[e.RowIndex].Cells["Orden"].Value == null) return;

                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                }
                else
                {
                    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);
                }
            }

        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabarDet"].IsCurrent)
            { 
                //GuardarDetProducto(this.gridControl.CurrentRow);
                GuardarDetalle();
            }

            if (this.gridControl.Columns["btnEditarDet"].IsCurrent)
            { 
                //editarDetProducto();
                EditarDetalle();
            }

            if (this.gridControl.Columns["btnEliminarDet"].IsCurrent)
            { 
                //EliminarDetProducto();
                EliminarDetalle();
            }

            if (this.gridControl.Columns["btnCancelarDet"].IsCurrent)
            { 
                //cancelarDetProducto();
                CancelarDetalle();
            }

            
        }
        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.Row != null)
                    if (Util.GetCurrentCellText(e.Row, "flag") == "")
                        e.Cancel = true;
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        private void frmabcAsientoTipo_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

            CrearColumnas();
            
            HabilitarControles(false);
                        
            if (Estado == FormEstate.New)
            {
                LimpiarControles();
                txtCodigo.Enabled = true;
                txtDescripcion.Enabled = true;
                txtLibroCod.Enabled = true;
                btnAgregar.Enabled = false;                
                
            }
            else if (Estado == FormEstate.Edit)
            {
                txtLibroCod.Enabled = true;
                CargaDetalle();
                txtDescripcion.Enabled = true;
            }

        }
        
        #endregion
        
        
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
                                            bool bCancelar, bool bEliminar, bool bEditar)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelarDet":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminarDet":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.delete_enabled : Properties.Resources.delete_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditarDet":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edit_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;

                default:
                    break;
            }
        }

        private void frmabcAsientoTipo_Activated(object sender, EventArgs e)
        {
            
            
        }

       

    }
}
