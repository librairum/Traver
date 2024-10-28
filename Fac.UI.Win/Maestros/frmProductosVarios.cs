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
    public partial class frmProductosVarios : frmBase
    {
        #region "Instancia"
        ProductosVariosLogic datos = ProductosVariosLogic.Instance;
        private static frmProductosVarios _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmProductosVarios Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmProductosVarios(formParent);
            _aForm = new frmProductosVarios(formParent);
            return _aForm;
        }
        #endregion
        public frmProductosVarios(frmMDI padre)
        {
            InitializeComponent();
        }
        private bool Validar()
        {
            bool procesoExitoso = true;
            ProductosVarios productos = new ProductosVarios();
            productos.FAC11CODEMP = Logueo.CodigoEmpresa;
            productos.FAC11PRODCOD = Util.GetCurrentCellText(gridControl, "FAC11PRODCOD");
            productos.FAC11PRODCODSUNAT = Util.GetCurrentCellText(gridControl, "FAC11PRODCODSUNAT");
            productos.FAC11PRODDESC = Util.GetCurrentCellText(gridControl, "FAC11PRODDESC");
            productos.FAC11PRODUNIMED = Util.GetCurrentCellText(gridControl, "FAC11PRODUNIMED");

            if (productos.FAC11PRODCODSUNAT == "")
            {
                Util.ShowAlert("Elegir codigo de producto sunat");
                procesoExitoso = false;
            }
            if (productos.FAC11PRODUNIMED == "")
            {
                Util.ShowAlert("Elegir unidad de medida");
                procesoExitoso = false;
            }
            return procesoExitoso;
        }
        private void GuardarDetalle()
        {
            try
            {
                string str_mensaje = "", str_flag = "";
                int int_flag = 0;

                ProductosVarios productos = new ProductosVarios();
                productos.FAC11CODEMP = Logueo.CodigoEmpresa;
                productos.FAC11PRODCOD = Util.GetCurrentCellText(gridControl, "FAC11PRODCOD");
                productos.FAC11PRODCODSUNAT = Util.GetCurrentCellText(gridControl, "FAC11PRODCODSUNAT");
                productos.FAC11PRODDESC = Util.GetCurrentCellText(gridControl, "FAC11PRODDESC");
                productos.FAC11PRODUNIMED = Util.GetCurrentCellText(gridControl, "FAC11PRODUNIMED");

                if (Validar() == false) return;
                str_flag = Util.GetCurrentCellText(gridControl, "flag");

                if (str_flag == "0")
                {
                    datos.Inserta(productos, out int_flag, out str_mensaje);
                }
                else
                {
                    datos.Actualiza(productos, out int_flag, out str_mensaje);
                }

                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                {
                    Cargar();
                    Util.enfocarFila(gridControl, "FAC11PRODCOD", productos.FAC11PRODCOD);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle: " + ex.Message);
            }
        }

        private void EditarDetalle()
        {
            try
            {
                Util.SetValueCurrentCellText(gridControl, "flag", "1");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
                Util.ResaltarAyuda(gridControl, "FAC11PRODCODSUNAT");
                Util.SetCellGridFocus(gridControl, "FAC11PRODDESC");
                Util.SetCellInitEdit(gridControl, "FAC11PRODDESC");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void EliminarDetalle()
        {
            try
            {                
                int int_flag = 0; string str_mensaje = "";

                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");

                if (respuesta == true)
                {
                    ProductosVarios productos = new ProductosVarios();
                    productos.FAC11CODEMP = Logueo.CodigoEmpresa;
                    productos.FAC11PRODCOD = Util.GetCurrentCellText(gridControl, "FAC11PRODCOD");
                    productos.FAC11PRODCODSUNAT = Util.GetCurrentCellText(gridControl, "FAC11PRODCODSUNAT");
                    productos.FAC11PRODDESC = Util.GetCurrentCellText(gridControl, "FAC11PRODDESC");
                    productos.FAC11PRODUNIMED = Util.GetCurrentCellText(gridControl, "FAC11PRODUNIMED");

                    datos.Elimina(productos, out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle: " + ex.Message);
            }
        }

        private void CancelarDetalle()
        {
            try
            {
                Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        private void Cargar()
        {
            try
            {
                gridControl.DataSource = datos.Listar(Logueo.CodigoEmpresa);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar: " + ex.Message);
            }


        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);

            CreateGridColumn(Grid, "Empresa", "FAC11CODEMP", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "Codigo", "FAC11PRODCOD", 0, "", 70);
            CreateGridColumn(Grid, "Descripcion", "FAC11PRODDESC", 0, "", 250, false, true, true);
            CreateGridColumn(Grid, "Unidad", "FAC11PRODUNIMED", 0, "", 120);
            CreateGridColumn(Grid, "Descripcion", "FAC11PRODUNIMEDDESCRIPCION", 0, "", 120);
            CreateGridColumn(Grid, "Sunat", "FAC11PRODCODSUNAT", 0, "", 120);
            CreateGridColumn(Grid, "Descripcion", "FAC11SERVCODSUNATDESCRIPCION", 0, "", 350);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 70, true, false, false);
            Util.AddButtonsToGrid(Grid);
        }
        private void TraerAyuda(enmAyuda tipo)
        {
            frmBusqueda frm = new frmBusqueda(tipo);
            string[] datos;
            switch (tipo)
            { 
            
                case enmAyuda.enmProductoSunat:
                     frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    if (datos.Length == 0) return;
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC11PRODCODSUNAT", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC11SERVCODSUNATDESCRIPCION", datos[1]);
                    break;
                case enmAyuda.enmUniMed:
                     frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    if (datos.Length == 0) return;
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC11PRODUNIMED", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC11PRODUNIMEDDESCRIPCION", datos[1]);
                    break;
                default:
                    break;
            }
           

        }
        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (Util.GetCurrentCellText(gridControl, "flag") == "") return;

            if (e.KeyValue == (char)Keys.F1)
                if (Util.IsCurrentColumn(gridControl, "FAC11PRODCODSUNAT"))
                {
                    TraerAyuda(enmAyuda.enmProductoSunat);
                }
                else if (Util.IsCurrentColumn(gridControl, "FAC11PRODUNIMED"))
                {
                    TraerAyuda(enmAyuda.enmUniMed);
                }

        }
        void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabarDet"].IsCurrent)
            {
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

        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (gridControl.Rows.Count == 0) return;

            try
            {
                if (e.Row != null)
                    if (Util.GetCurrentCellText(e.Row, "flag") == "")
                        e.Cancel = true;
                    // Si es modo editar
                    else if (Util.GetCurrentCellText(e.Row, "flag") == "1")
                        // Bloquear si la columna es codigo
                        if (Util.IsCurrentColumn(e.Column, "FAC11CODEMP") ||
                            Util.IsCurrentColumn(e.Column, "FAC11PRODCOD") ||
                            Util.IsCurrentColumn(e.Column, "FAC11PRODUNIMED") || 
                            Util.IsCurrentColumn(e.Column, "FAC11PRODCODSUNAT"))
                            //Bloqueo para emprewsa, codigo, codigo sunat
                            e.Cancel = true;

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Util.FormateoBotones(gridControl, Estado, e);
        }
        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if (Util.GetCurrentCellText(gridControl.CurrentRow, "flag") == "1" ||
                    Util.GetCurrentCellText(gridControl.CurrentRow, "flag") == "0")
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cambiar de fila: " + ex.Message);
            }
        }
        protected override void OnNuevo()
        {
            AgregarFila();

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

                GridViewRowInfo row = this.gridControl.CurrentRow;
                Util.SetValueCurrentCellText(gridControl, "flag", "0");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");


                string nuevoCodigo = "";
                datos.TraerNuevoCodigo(Logueo.CodigoEmpresa, out nuevoCodigo);


                Util.SetValueCurrentCellText(gridControl, "FAC11CODEMP", Logueo.CodigoEmpresa);
                Util.SetValueCurrentCellText(gridControl, "FAC11PRODCOD", nuevoCodigo);
                Util.ResaltarAyuda(gridControl, "FAC11PRODCODSUNAT");
                Util.SetCellGridFocus(gridControl, "FAC11PRODDESC");
                Util.SetCellInitEdit(gridControl, "FAC11PRODDESC");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
            }
        }
        

        private void frmProductosVarios_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            Util.ConfigGridToEnterNavigation(this.gridControl);
            CrearColumnas();
            Cargar();
        }
    }
}
