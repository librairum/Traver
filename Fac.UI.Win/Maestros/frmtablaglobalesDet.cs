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
    public partial class frmtablaglobalesDet : frmBaseMante
    {

        #region "Instancia"
        private static frmtablaglobalesDet _aForm;
        private frmtablasglobales FrmParent { get; set; }
        public static frmtablaglobalesDet Instance(frmtablasglobales formParent)
        {
            if (_aForm != null) return new frmtablaglobalesDet(formParent);
            _aForm = new frmtablaglobalesDet(formParent);
            return _aForm;
        }
        #endregion
        GlobalLogic datos = GlobalLogic.Instance;
        public frmtablaglobalesDet(frmtablasglobales padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Estado = FrmParent.Estado;
            Util.ConfigGridToEnterNavigation(gridControl);
            VerBotonesPorEstado(FormEstate.List);
            CrearColumnas();
            Cargar();
            CargarBotonesPorDefecto();
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            gridControl.SelectionChanging += new GridViewSelectionCancelEventHandler(gridControl_SelectionChanging);
            gridControl.CellFormatting += new CellFormattingEventHandler(gridControl_CellFormatting);
            gridControl.CommandCellClick += new CommandCellClickEventHandler(gridControl_CommandCellClick);
        }

        void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabarDet"].IsCurrent)
            {
                GuardarDetalle();
            }

            if (this.gridControl.Columns["btnEditarDet"].IsCurrent)
            {
                EditarDetalle();
            }

            if (this.gridControl.Columns["btnEliminarDet"].IsCurrent)
            {
                EliminarDetalle();
            }

            if (this.gridControl.Columns["btnCancelarDet"].IsCurrent)
            {
                CancelarDetalle();
            }
        }
        bool Validar()
        {
            GridViewRowInfo row = this.gridControl.CurrentRow;
            TablaGlobal entidad = new TablaGlobal();

            entidad.glo01codigotabla = Util.GetCurrentCellText(row, "glo01codigotabla");
            entidad.glo01codigo = Util.GetCurrentCellText(row, "glo01codigo");
            entidad.glo01descripcion = Util.GetCurrentCellText(row, "glo01descripcion");
            entidad.glo01texto1 = Util.GetCurrentCellText(row, "glo01texto1");
            entidad.glocomentario = Util.GetCurrentCellText(row, "glocomentario");
            if (entidad.glo01codigotabla == "")
            {
                Util.ShowAlert("El codigo de tabla no es valido");
                Util.SetCellInitEdit(row, "glo01codigotabla");
                return false;
            }
            if (entidad.glo01codigo == "")
            {
                Util.ShowAlert("Ingresar codigo ");
                Util.SetCellInitEdit(row, "glo01codigo");
                return false;
            }
            if (entidad.glo01descripcion == "")
            {
                Util.ShowAlert("Ingresar descripcion");
                Util.SetCellGridFocus(row, "glo01descripcion");
                return false;
            }

           
            return true;
        }
        private void GuardarDetalle()
        {
            if (Validar() == false) return;
            TablaGlobal entidad = new TablaGlobal();
            GridViewRowInfo row = this.gridControl.CurrentRow;
            entidad.glo01codigotabla = Util.GetCurrentCellText(row, "glo01codigotabla");
            entidad.glo01codigo = Util.GetCurrentCellText(row, "glo01codigo");
            entidad.glo01descripcion = Util.GetCurrentCellText(row, "glo01descripcion");
            entidad.glo01texto1 = Util.GetCurrentCellText(row, "glo01texto1");
            entidad.glocomentario = Util.GetCurrentCellText(row, "glocomentario");

            int int_flag = 0;
            string str_Mensaje = "";
            bool EsNuevo = Util.GetCurrentCellFlag(row, "flag");
            if (EsNuevo == true)
            {
                GlobalLogic.Instance.InsertarTablaGlobal(entidad, out int_flag, out str_Mensaje);
            }
            else
            {
                GlobalLogic.Instance.ActualizarTablaGlobal(entidad, out int_flag, out str_Mensaje);
            }

            Util.ShowMessage(str_Mensaje, int_flag);

            if (int_flag != -1)
                OnCancelar();
        }

        private void EditarDetalle()
        {
            Estado = FormEstate.Edit;
            GridViewRowInfo row = gridControl.CurrentRow;
            Util.SetValueCurrentCellText(row, "flag", "1");
            //Util.SetValueCurrentCellText(row, "flagBotones", "E");
            Util.SetCellGridFocus(row, "glo01codigotabla");
            Util.SetCellInitEdit(gridControl, "glo01codigotabla");
        }

        private void EliminarDetalle()
        {
            if (gridControl.RowCount == 0) return;
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                int int_flag = 0; string str_mensaje = "";
                if (respuesta == false) return;

                TablaGlobal entidad = new TablaGlobal();

                entidad.glo01codigotabla = Util.GetCurrentCellText(gridControl, "glo01codigotabla");
                entidad.glo01codigo = Util.GetCurrentCellText(gridControl, "glo01codigo");

                datos.EliminarTablaGlobal(entidad, out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1) { Cargar(); }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void CancelarDetalle()
        {
            Cargar();
            CargarBotonesPorDefecto();
        }
        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Util.FormateoBotones(gridControl, FormEstate.Edit, e);           
        }

        void gridControl_SelectionChanging(object sender, GridViewSelectionCancelEventArgs e)
        {
            if (gridControl.RowCount == 0) return;
            //if(e.Rows[
            GridViewRowInfo row = gridControl.CurrentRow;
            string str_flag = Util.GetCurrentCellText(row, "flag");

            if (str_flag == "0" || str_flag == "1")
            {
                e.Cancel = true;
            }
        }
        
        void CargarBotonesPorDefecto()
        {
            gestionarBotones(true, false, false, false, false);
        }
       

        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            string str_flag = Util.GetCurrentCellText(e.Row, "flag");
            if(str_flag == "")
            {
                e.Cancel = true;
            }            
        }
        private void Cargar()
        {
            this.gridControl.DataSource = datos.TraeRegistrosDeTablaGlobal(FrmParent.TablaCodigo, "glo01codigo", "*");
            
        }
        private void CrearColumnas()
        { 
            RadGridView Grid = CreateGridVista(gridControl);
            CreateGridColumn(Grid, "glo01codigotabla", "glo01codigotabla", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Codigo", "glo01codigo", 0, "", 90, false, true);
            CreateGridColumn(Grid, "Descripcion", "glo01descripcion", 0, "", 300, false, true);
            CreateGridColumn(Grid, "Texto", "glo01texto1", 0, "", 90, false, true, false);
            CreateGridColumn(Grid, "Comentario", "glocomentario", 0, "", 90, false, true, false);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, false, true, false);
            Util.AddButtonsToGrid(Grid);
        }
        protected override void OnNuevo()
        {
            VerBotonesPorEstado(FormEstate.New);
            AgregarFila();
        }
        protected override void OnEditar()
        {
            VerBotonesPorEstado(FormEstate.Edit);
            Util.SetValueCurrentCellText(gridControl, "flag", "1");
            Util.SetCellGridFocus(gridControl, "glo01codigo");
        }
        protected override void OnEliminar()
        {

            if (gridControl.RowCount == 0) return;
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                int int_flag = 0; string str_mensaje = "";
                if (respuesta == false) return;

                TablaGlobal entidad = new TablaGlobal();

                entidad.glo01codigotabla = Util.GetCurrentCellText(gridControl, "glo01codigotabla");
                entidad.glo01codigo = Util.GetCurrentCellText(gridControl, "glo01codigo");

                datos.EliminarTablaGlobal(entidad, out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1) { Cargar(); }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        protected override void OnCancelar()
        {
            //this.Close();
            Cargar();
            CargarBotonesPorDefecto();
        }
        protected override void OnGuardar()
        {
            TablaGlobal entidad = new TablaGlobal();
            GridViewRowInfo row = this.gridControl.CurrentRow;
            entidad.glo01codigotabla = Util.GetCurrentCellText(row ,"glo01codigotabla");
            entidad.glo01codigo = Util.GetCurrentCellText(row, "glo01codigo");
            entidad.glo01descripcion = Util.GetCurrentCellText(row, "glo01descripcion");
            entidad.glo01texto1 = Util.GetCurrentCellText(row, "glo01texto1");
            entidad.glocomentario = Util.GetCurrentCellText(row, "glocomentario");

            int int_flag = 0;
            string str_Mensaje = "";
            bool EsNuevo = Util.GetCurrentCellFlag(row, "flag");
            if (EsNuevo == true)
            {
                GlobalLogic.Instance.InsertarTablaGlobal(entidad, out int_flag, out str_Mensaje);
            }
            else {
                GlobalLogic.Instance.ActualizarTablaGlobal(entidad, out int_flag, out str_Mensaje);
            }

            Util.ShowMessage(str_Mensaje, int_flag);

            if (int_flag != -1)
                OnCancelar();
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

                this.gridControl.Rows.AddNew();
                GridViewRowInfo row = this.gridControl.CurrentRow;
                
                Util.SetValueCurrentCellText(row, "glo01codigotabla", FrmParent.TablaCodigo);
                Util.SetValueCurrentCellText(row, "flag", "0");

                Util.SetCellGridFocus(row, "glo01codigotabla");


            }
            catch (Exception ex)
            { 
            
            }
        }
        void VerBotonesPorEstado(FormEstate parEstado)
        {
            if (parEstado == FormEstate.New)
            {                
                //gestionarBotones(false, false, false, true, true);
                gestionarBotones(true, false, false, false, false);
            }
            else if (parEstado == FormEstate.Edit)
            {                
                //gestionarBotones(false, false, false, true, true);
                gestionarBotones(true, false, false, false, false);
            }
            else if (parEstado == FormEstate.View)
            {
                gestionarBotones(true, false, false, false, false);
            }
        }


    }
}
