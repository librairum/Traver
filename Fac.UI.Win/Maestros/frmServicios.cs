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
    public partial class frmServicios : frmBase
    {
        #region "Instancia"
        private static frmServicios _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmServicios Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmServicios(formParent);
            _aForm = new frmServicios(formParent);
            return _aForm;
        }
        #endregion
        ServiciosLogic datos = ServiciosLogic.Instance;

        public frmServicios(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;            
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            Util.ConfigGridToEnterNavigation(this.gridControl);
            CrearColumnas();
            Cargar();
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
                Util.SetValueCurrentCellText(gridControl, "FAC10CODEMP", Logueo.CodigoEmpresa);
                Util.SetValueCurrentCellText(gridControl, "FAC10SERVCOD", nuevoCodigo);
                Util.ResaltarAyuda(gridControl, "FAC10SERVCODSUNAT");
                Util.SetCellGridFocus(gridControl, "FAC10SERVDESC");
                Util.SetCellInitEdit(gridControl, "FAC10SERVDESC");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar fila: " + ex.Message);
            }
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);
            
            CreateGridColumn(Grid, "FAC10CODEMP", "FAC10CODEMP", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "Codigo", "FAC10SERVCOD", 0, "", 70);
            CreateGridColumn(Grid, "Descripcion", "FAC10SERVDESC", 0, "", 250, false, true, true);
            CreateGridColumn(Grid, "Prod.Sunat", "FAC10SERVCODSUNAT", 0, "", 120);
            CreateGridColumn(Grid, "Desc.Sunat", "FAC10SERVCODSUNATDESCRIPCION", 0, "", 350);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 70, true, false, false);

            Util.AddButtonsToGrid(Grid);
        }
        private void TraerAyuda(enmAyuda tipo)
        {
            frmBusqueda frm = new frmBusqueda(tipo);
            string[] datos;

            frm.ShowDialog();
            if(frm.Result == null) return;
            if(frm.Result.ToString() == "") return;
            datos = frm.Result.ToString().Split('|');
            if (datos.Length == 0) return;
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC10SERVCODSUNAT", datos[0]);
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC10SERVCODSUNATDESCRIPCION", datos[1]);

        }
        private bool Validar()
        {

            return true;
        }
        private void GuardarDetalle()
        {
            try
            {
                string str_mensaje = "", str_flag = "";
                int int_flag = 0;

                Servicios servicio = new Servicios();

                servicio.FAC10CODEMP = Util.GetCurrentCellText(gridControl, "FAC10CODEMP");
                servicio.FAC10SERVCOD = Util.GetCurrentCellText(gridControl, "FAC10SERVCOD");
                servicio.FAC10SERVDESC = Util.GetCurrentCellText(gridControl, "FAC10SERVDESC");
                servicio.FAC10SERVCODSUNAT = Util.GetCurrentCellText(gridControl, "FAC10SERVCODSUNAT");
                
                if (Validar() == false) return;
                str_flag = Util.GetCurrentCellText(gridControl, "flag");

                if (str_flag == "0")
                {                    
                    datos.Inserta(servicio, out int_flag, out str_mensaje);                    
                }
                else
                {
                    datos.Actualiza(servicio, out int_flag, out str_mensaje);                    
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                {
                    Cargar();
                    Util.enfocarFila(gridControl, "FAC10SERVCOD", servicio.FAC10SERVCOD);
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
                Util.ResaltarAyuda(gridControl, "FAC10SERVCODSUNAT");
                Util.SetCellGridFocus(gridControl, "FAC10SERVDESC");
                Util.SetCellInitEdit(gridControl, "FAC10SERVDESC");
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
                string MonedaCodigo = "";
                int int_flag = 0; string str_mensaje = "";
                
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                
                if (respuesta == true)
                {
                    Servicios servicio = new Servicios();
                    servicio.FAC10CODEMP = Util.GetCurrentCellText(gridControl, "FAC10CODEMP");
                    servicio.FAC10SERVCOD = Util.GetCurrentCellText(gridControl, "FAC10SERVCOD");
                    datos.Elimina(servicio, out int_flag, out str_mensaje);                    
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
        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (Util.GetCurrentCellText(gridControl, "flag") == "") return;

            if (e.KeyValue == (char)Keys.F1)
                if (Util.IsCurrentColumn(gridControl, "FAC10SERVCODSUNAT"))
                    TraerAyuda(enmAyuda.enmProductoSunat);

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
                        if (Util.IsCurrentColumn(e.Column, "FAC10CODEMP") || 
                            Util.IsCurrentColumn(e.Column, "FAC10SERVCOD") ||
                            Util.IsCurrentColumn(e.Column, "FAC10SERVCODSUNAT"))
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
        protected override void OnNuevo()
        {
            AgregarFila();

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
    }

    
}
