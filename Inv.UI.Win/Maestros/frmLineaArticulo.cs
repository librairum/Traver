using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Inv.UI.Win
{
    public partial class frmLineaArticulo : frmBase
    {


        private static frmLineaArticulo _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmLineaArticulo Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmLineaArticulo(padre);
            _aForm = new frmLineaArticulo(padre);
            return _aForm;
        }
        public frmLineaArticulo(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

       
        #region"Metodo general"
        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
            //Grid.Columns[NameButon].BestFit();
        }
        private void CrearColumnas()
        {
            RadGridView GridArti = CreateGridVista(this.gridLineaArticulo);
            CreateGridColumn(GridArti, "CodigoEmpresa", "CodigoEmpresa", 0, "", 70, false, false, false);
            CreateGridColumn(GridArti, "Codigo", "Codigo", 0, "", 90, false, true, true);
            CreateGridColumn(GridArti, "Descripcion", "Descripcion", 0, "", 150, false, true, true);
            CreateGridColumn(GridArti, "Flag", "Flag", 0, "", 70, false, false, false);
            AddCmdButtonToGrid(GridArti, "btnEliminarDet", "", "btnEliminarDet");
            AddCmdButtonToGrid(GridArti, "btnEditarDet", "", "btnEditarDet");
            AddCmdButtonToGrid(GridArti, "btnCancelarDet", "", "btnCancelarDet");
            AddCmdButtonToGrid(GridArti, "btnGrabarDet", "", "btnGrabarDet");


            RadGridView GridGrupoArti = CreateGridVista(this.gridGrupoArticulo);
            CreateGridColumn(GridGrupoArti, "CodigoEmpresa", "CodigoEmpresa", 0, "", 70, false, false, false);
            CreateGridColumn(GridGrupoArti, "CodigoLinea", "CodigoLinea", 0, "", 70, false, false, false);
            CreateGridColumn(GridGrupoArti, "Codigo", "Codigo", 0, "", 70, false, true, true);
            CreateGridColumn(GridGrupoArti, "Descripcion", "Descripcion", 0, "", 120, false, true, true);
            CreateGridColumn(GridGrupoArti, "Flag", "Flag", 0, "", 70, false, false, false);
            AddCmdButtonToGrid(GridGrupoArti, "btnEliminarDet", "", "btnEliminarDet");
            AddCmdButtonToGrid(GridGrupoArti, "btnEditarDet", "", "btnEditarDet");
            AddCmdButtonToGrid(GridGrupoArti, "btnCancelarDet", "", "btnCancelarDet");
            AddCmdButtonToGrid(GridGrupoArti, "btnGrabarDet", "", "btnGrabarDet");

            RadGridView GridSubGrupoArti = CreateGridVista(this.gridSubGrupoArticulo);
            CreateGridColumn(GridSubGrupoArti, "CodigoEmpresa", "CodigoEmpresa", 0, "", 70, false, false, false);
            CreateGridColumn(GridSubGrupoArti, "CodigoLineaArticulo", "CodigoLineaArticulo", 0, "", 70, false, false, false);
            CreateGridColumn(GridSubGrupoArti, "CodigoGrupoArticulo", "CodigoGrupoArticulo", 0, "", 70, false, false, false);
            CreateGridColumn(GridSubGrupoArti, "Codigo", "Codigo", 0, "", 70, false, true, true);
            CreateGridColumn(GridSubGrupoArti, "Descripcion", "Descripcion", 0, "", 150, false, true, true);
            CreateGridColumn(GridSubGrupoArti, "Flag", "Flag", 0, "", 70, false, false, false);
            AddCmdButtonToGrid(GridSubGrupoArti, "btnEliminarDet", "", "btnEliminarDet");
            AddCmdButtonToGrid(GridSubGrupoArti, "btnEditarDet", "", "btnEditarDet");
            AddCmdButtonToGrid(GridSubGrupoArti, "btnCancelarDet", "", "btnCancelarDet");
            AddCmdButtonToGrid(GridSubGrupoArti, "btnGrabarDet", "", "btnGrabarDet");
        }
        #endregion
        #region "Comentarios"


        //private void Grid_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        //{
        //    //string nombreGrilla = ((RadGridView)sender).Name;
        //    if (e.Row != null)
        //    {
        //        if (Util.convertiracadena(e.Row.Cells["Flag"].Value) == "")
        //        {
        //            e.Cancel = true;
        //        }
        //    }

        //}
        //private void Grid_CommandCellClick(object sender, EventArgs e)
        //{
        //    RadGridView Grid;
        //    if (this.gridLineaArticulo.Focused)
        //    {
        //        Grid = this.gridLineaArticulo;
        //    }
        //    else if (this.gridGrupoArticulo.Focused)
        //    {
        //        Grid = this.gridGrupoArticulo;
        //    }
        //    else if (this.gridSubGrupoArticulo.Focused)
        //    {
        //        Grid = this.gridSubGrupoArticulo;
        //    }

        //    //Grid.Columns[""].IsCurrent


        //}
        //private void Grid_CellFormating(object sender, CellFormattingEventArgs e)
        //{

        //}
        //private void Grid_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        //{



        //    string nombre = ((RadGridView)sender).Name;
        //    switch (nombre)
        //    {
        //        case "gridGrupoArticulo":

        //            if (((RadGridView)sender).IsLoaded)
        //            {
        //                string codigoLineaArticulo = Util.GetCurrentCellText(e.CurrentRow, "CodigoLinea");
        //                string codigoGrupoArticulo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");
        //            }
        //            break;
        //        case "gridLineaArticulo":

        //            if (((RadGridView)sender).IsLoaded)
        //            {
        //                string codigo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");
        //            }
        //            break;
        //        case "gridSubGrupoArticulo":
        //            if (((RadGridView)sender).IsLoaded)
        //            {

        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //private void Grid_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        //{

        //}
        #endregion

        

        private void Cargar()
        {

            try
            {
                List<LineaArticulo> listaLineaArti = LineaArticuloLogic.Instance.TraeLineaArticulo(Logueo.CodigoEmpresa);
                this.gridLineaArticulo.DataSource = listaLineaArti;

                string CodigoLineaArticulo = "";
                CodigoLineaArticulo = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");
                List<GrupoArticulo> listaGrupoArti = LineaArticuloLogic.Instance.TraeGrupoArticulo(Logueo.CodigoEmpresa, CodigoLineaArticulo);
                this.gridGrupoArticulo.DataSource = listaGrupoArti;


                string CodigoGrupoArticulo = "";
                CodigoGrupoArticulo = Util.GetCurrentCellText(this.gridSubGrupoArticulo.CurrentRow, "Codigo");
                List<SubGrupoArticulo> ListaSubGrupoArti = LineaArticuloLogic.Instance.TraeSubGrupoArticulo(Logueo.CodigoEmpresa, CodigoLineaArticulo, CodigoGrupoArticulo);
                this.gridSubGrupoArticulo.DataSource = ListaSubGrupoArti;


            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar");
            }

        }

        private void CargarLineaArticulo()
        {
            List<LineaArticulo> listaLineaArti = LineaArticuloLogic.Instance.TraeLineaArticulo(Logueo.CodigoEmpresa);
            this.gridLineaArticulo.DataSource = listaLineaArti;
        }
        private void CargarGrupoArticulo(string CodigoLineaArticulo)
        {

            List<GrupoArticulo> listaGrupoArti = LineaArticuloLogic.Instance.TraeGrupoArticulo(Logueo.CodigoEmpresa, CodigoLineaArticulo);
            this.gridGrupoArticulo.DataSource = listaGrupoArti;

        }

        private void CargarSubGrupoArticulo(string CodigoLineaArticulo, string CodigoGrupoArticulo)
        {


            List<SubGrupoArticulo> ListaSubGrupoArti = LineaArticuloLogic.Instance.TraeSubGrupoArticulo(Logueo.CodigoEmpresa,
                                                        CodigoLineaArticulo, CodigoGrupoArticulo);

            this.gridSubGrupoArticulo.DataSource = ListaSubGrupoArti;
        }


   
        

        private void gridLineaArticulo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            try
            {
                if (e.CurrentRow != null)
                {
                    string codigo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");
                    CargarGrupoArticulo(codigo);
                    if (this.gridGrupoArticulo.Rows.Count == 0)
                    {
                        this.gridSubGrupoArticulo.Rows.Clear();
                    }
                    else
                    {
                        string codigoGrupo = Util.GetCurrentCellText(this.gridGrupoArticulo.CurrentRow, "Codigo");
                        CargarSubGrupoArticulo(codigo, codigoGrupo);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.Write("Error en currentRowChanged");
            }

        }

        private void gridGrupoArticulo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            try
            {
                if (e.CurrentRow != null)
                {
                    string codigoLineaArticulo = Util.GetCurrentCellText(e.CurrentRow, "CodigoLinea");
                    string codigoGrupoArticulo = Util.GetCurrentCellText(e.CurrentRow, "Codigo");

                    CargarSubGrupoArticulo(codigoLineaArticulo, codigoGrupoArticulo);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write("Error en currentRowChanged");
            }

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
                    cellElement.CommandButton.Image = Properties.Resources.deleted_disabled;
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
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditarDet":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edited_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;

                default:
                    break;
            }
        }
        private void gridLineaArticulo_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {


                    if (gridLineaArticulo.Rows[e.RowIndex].Cells["flag"].Value == null)
                        habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                    else
                        habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);


                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error cellformating: " + ex.Message);
            }
        }

        private void gridGrupoArticulo_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {


                    if (gridGrupoArticulo.Rows[e.RowIndex].Cells["flag"].Value == null)
                        habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                    else
                        habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);


                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error cellformating : " + ex.Message);
            }
        }

        private void gridSubGrupoArticulo_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {


                    if (gridSubGrupoArticulo.Rows[e.RowIndex].Cells["flag"].Value == null)
                        habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                    else
                        habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);


                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error cellformating: " + ex.Message);
            }
        }

        private void btnAgregarLineaArticulo_Click(object sender, EventArgs e)
        {
            this.gridSubGrupoArticulo.Enabled = false;
            this.gridGrupoArticulo.Enabled = false;
            this.btnAgregarGrupoArticulo.Enabled = false;
            this.btnAgregaSubGrupoArticulo.Enabled = false;

            AgregarRegistro(this.gridLineaArticulo);



        }

        private void btnAgregarGrupoArticulo_Click(object sender, EventArgs e)
        {


            this.btnAgregarLineaArticulo.Enabled = false;
            this.btnAgregaSubGrupoArticulo.Enabled = false;
            this.gridLineaArticulo.Enabled = false;
            this.gridSubGrupoArticulo.Enabled = false;

            AgregarRegistro(this.gridGrupoArticulo);



        }


        int indiceEditable = 0;
        private void AgregarRegistro(RadGridView tabla)
        {
            try
            {
                tabla.Rows.AddNew();
                tabla.CurrentRow.Cells["Flag"].Value = "0";
                tabla.CurrentRow.Cells["Descripcion"].BeginEdit();
                indiceEditable = tabla.Rows[tabla.RowCount - 1].Index;

                string codigoGenerado = "";
                if (tabla.Name.ToUpper() == "GRIDLINEAARTICULO")
                {
                    LineaArticuloLogic.Instance.TraeCodigLineaArticulo(Logueo.CodigoEmpresa, out codigoGenerado);
                    Util.SetValueCurrentCellText(tabla.CurrentRow, "Codigo", codigoGenerado);
                    Util.SetValueCurrentCellText(tabla.CurrentRow, "Flag", "0");
                }
                else if (tabla.Name.ToUpper() == "GRIDGRUPOARTICULO")
                {
                    string lineaArticulo = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");

                    LineaArticuloLogic.Instance.TraeCodigoGrupoArticulo(Logueo.CodigoEmpresa, lineaArticulo, out codigoGenerado);
                    Util.SetValueCurrentCellText(tabla.CurrentRow, "Codigo", codigoGenerado);
                    Util.SetValueCurrentCellText(tabla.CurrentRow, "Flag", "0");
                }
                else if (tabla.Name.ToUpper() == "GRIDSUBGRUPOARTICULO")
                {
                    string lineaArticulo = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");
                    string grupoArticulo = Util.GetCurrentCellText(this.gridGrupoArticulo.CurrentRow, "Codigo");

                    LineaArticuloLogic.Instance.TraeCodigoSubGrupoArticulo(Logueo.CodigoEmpresa,
                                                lineaArticulo, grupoArticulo, out codigoGenerado);

                    Util.SetValueCurrentCellText(tabla.CurrentRow, "Codigo", codigoGenerado);
                    Util.SetValueCurrentCellText(tabla.CurrentRow, "Flag", "0");
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar registro:" + ex.Message);
            }


        }

        private void gridLineaArticulo_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                string flag = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Flag");
                if (flag != "")
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write("Error en currentRowChanging");
            }


        }

        private void gridGrupoArticulo_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                string flag = Util.GetCurrentCellText(this.gridGrupoArticulo.CurrentRow, "Flag");
                if (flag != "")
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write("Error en currentRowChanging");
            }


        }

        private void gridSubGrupoArticulo_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                string flag = Util.GetCurrentCellText(this.gridSubGrupoArticulo.CurrentRow, "Flag");
                if (flag != "")
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write("Error en currentRowChanging");
            }


        }
        #region "Linea de articulo"
        private void GuardarLineaArticulo(GridViewRowInfo filadetabla)
        {
            //guardar y refrescar grilla
            string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");
            string descripcion = Util.GetCurrentCellText(filadetabla, "Descripcion");

            if (codigo == "") { Util.ShowAlert("Ingresar codigo"); return; }
            if (descripcion == "") { Util.ShowAlert("Ingresar descripcion"); return; }
            bool esNuevo = false;
            esNuevo = Util.GetCurrentCellText(filadetabla, "Flag") == "0" ? true : false;
            int flag = 0;
            string mensaje = "";
            if (esNuevo)
            {
                LineaArticuloLogic.Instance.InsertarLinArt(Logueo.CodigoEmpresa, codigo, descripcion, 
                                                        Logueo.Anio, out flag, out mensaje);
            }
            else
            {
                LineaArticuloLogic.Instance.ActualizarLinArt(Logueo.CodigoEmpresa, codigo, descripcion, out flag, out mensaje);
            }


            if (flag != -1)
            {
                Util.ShowMessage(mensaje, flag);
                CargarLineaArticulo();
                Util.enfocarFila(this.gridLineaArticulo, "Codigo", codigo);
                this.btnAgregarGrupoArticulo.Enabled = true;
                this.btnAgregaSubGrupoArticulo.Enabled = true;
                this.gridGrupoArticulo.Enabled = true;
                this.gridSubGrupoArticulo.Enabled = true;
            }


        }

        private void EditarLineaArticulo(GridViewRowInfo filadetabla)
        {
            //tabladatos.CurrentRow.Cells["Flag"].Value = "0";
            filadetabla.Cells["Flag"].Value = "1";
        }

        private void EliminarLineaArticulo(GridViewRowInfo filadetabla)
        {
            //ellminar yu refrescar grilla
            string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");
            int flag = 0; string mensaje = "";
            bool esNuevo = false;
            esNuevo = Util.GetCurrentCellText(filadetabla, "Flag") == "0" ? true : false;

            LineaArticuloLogic.Instance.EliminarLineaArticulo(Logueo.CodigoEmpresa, codigo, out flag, out mensaje);
            Util.ShowMessage(mensaje, flag);

            if (flag != -1)
            {
                CargarLineaArticulo();
            }

        }

        private void CancelarLineaArticulo(GridViewRowInfo filadetabla)
        {
            //tabladatos.CurrentRow.Cells["Flag"].Value = "";
            filadetabla.Cells["Flag"].Value = "";

            this.gridSubGrupoArticulo.Enabled = true;
            this.gridGrupoArticulo.Enabled = true;
            this.btnAgregarGrupoArticulo.Enabled = true;
            this.btnAgregaSubGrupoArticulo.Enabled = true;

            CargarLineaArticulo();


        }
        #endregion
        #region "Grupo de articulo"
        private void GuardarGrupoArticulo(GridViewRowInfo filadetabla)
        {
            string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");
            string descripcion = Util.GetCurrentCellText(filadetabla, "Descripcion");

            string codigoLinea = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");

            if (codigo == "") { Util.ShowAlert("Ingresar codigo"); return; }
            if (descripcion == "") { Util.ShowAlert("Ingresar descripcion"); return; }

            bool esNuevo = false;
            esNuevo = Util.GetCurrentCellText(filadetabla, "Flag") == "0" ? true : false;

            int flag = 0;
            string mensaje = "";

            if (esNuevo)
            {
                LineaArticuloLogic.Instance.InsertarGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea, codigo, 
                    descripcion, Logueo.Anio, out flag, out mensaje);
            }
            else
            {
                LineaArticuloLogic.Instance.ActualizarGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea, codigo,
                    descripcion,  out flag, out mensaje);
            }


            if (flag != -1)
            {
                Util.ShowMessage(mensaje, flag);
                CargarGrupoArticulo(codigoLinea);
                Util.enfocarFila(this.gridGrupoArticulo, "Codigo", codigo);
                this.btnAgregarLineaArticulo.Enabled = true;
                this.btnAgregaSubGrupoArticulo.Enabled = true;
                this.gridLineaArticulo.Enabled = true;
                this.gridSubGrupoArticulo.Enabled = true;
            }


        }
        private void EditarGrupoArticulo(GridViewRowInfo filadetabla)
        {
            filadetabla.Cells["Flag"].Value = "1";
        }

        private void EliminarGrupoArticulo(GridViewRowInfo filadetabla)
        {
            string codigoLinea = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");
            string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");
            int flag = 0; string mensaje = "";
            LineaArticuloLogic.Instance.EliminarGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea, codigo, out flag, out mensaje);
            Util.ShowMessage(mensaje, flag);
            if (flag != -1)
            {
                CargarGrupoArticulo(codigoLinea);
                this.btnAgregarLineaArticulo.Enabled = true;
                this.btnAgregaSubGrupoArticulo.Enabled = true;
                this.gridLineaArticulo.Enabled = true;
                this.gridSubGrupoArticulo.Enabled = true;
            }
        }
        private void CancelarGrupoArticulo(GridViewRowInfo filadetabla)
        {


            filadetabla.Cells["Flag"].Value = "";

            this.btnAgregarLineaArticulo.Enabled = true;
            this.btnAgregaSubGrupoArticulo.Enabled = true;
            this.gridLineaArticulo.Enabled = true;
            this.gridSubGrupoArticulo.Enabled = true;

            string codigoLinea = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");
            CargarGrupoArticulo(codigoLinea);

        }
        #endregion
        #region"SubGrupo Articulo"
        private void GuardarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {
            string codigoLinea = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");
            string codigoGrupo = Util.GetCurrentCellText(this.gridGrupoArticulo.CurrentRow, "Codigo");
            string codigo = Util.GetCurrentCellText(this.gridSubGrupoArticulo.CurrentRow, "Codigo");
            string descripcion = Util.GetCurrentCellText(this.gridSubGrupoArticulo.CurrentRow, "Descripcion");
            if (codigo == "")
            {
                Util.ShowAlert("Ingresar codigo"); return;
            }
            if (descripcion == "")
            {
                Util.ShowAlert("Ingresar descripcion"); return;
            }
            bool esNuevo = false;
            esNuevo = Util.GetCurrentCellText(filadetabla, "Flag") == "0" ? true : false;

            int flag = 0;
            string mensaje = "";

            if (esNuevo)
            {
                LineaArticuloLogic.Instance.InsertarSubGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea,
                                                codigoGrupo, codigo, descripcion,
                                                Logueo.Anio, out flag, out mensaje);
            }
            else
            {
                LineaArticuloLogic.Instance.ActualizarSubGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea,
                    codigoGrupo, codigo, descripcion, out flag, out mensaje);
            }
            if (flag != -1)
            {
                Util.ShowMessage(mensaje, flag);

                CargarSubGrupoArticulo(codigoLinea, codigoGrupo);
                Util.enfocarFila(this.gridSubGrupoArticulo, "Codigo", codigo);

                this.btnAgregarLineaArticulo.Enabled = true;
                this.btnAgregarGrupoArticulo.Enabled = true;

                this.gridLineaArticulo.Enabled = true;
                this.gridGrupoArticulo.Enabled = true;
            }




        }

        private void EditarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {
            filadetabla.Cells["Flag"].Value = "1";
        }

        private void EliminarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {
            string codigoLinea = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");
            string codigoGrupo = Util.GetCurrentCellText(this.gridGrupoArticulo.CurrentRow, "Codigo");
            string codigo = Util.GetCurrentCellText(filadetabla, "Codigo");

            int flag = 0; string mensaje = "";

            LineaArticuloLogic.Instance.EliminarSubGrupoArticulo(Logueo.CodigoEmpresa, codigoLinea, codigoGrupo, codigo, out flag, out mensaje);
            Util.ShowMessage(mensaje, flag);
            if (flag != -1)
            {

                CargarSubGrupoArticulo(codigoLinea, codigoGrupo);
                this.btnAgregarLineaArticulo.Enabled = true;
                this.btnAgregarGrupoArticulo.Enabled = true;
                this.gridLineaArticulo.Enabled = true;
                this.gridGrupoArticulo.Enabled = true;
            }


            //CargarSubGrupoArticulo(codigoLinea);
        }

        private void CancelarSubGrupoArticulo(GridViewRowInfo filadetabla)
        {

            filadetabla.Cells["Flag"].Value = "";

            this.btnAgregarLineaArticulo.Enabled = true;
            this.btnAgregarGrupoArticulo.Enabled = true;

            this.gridLineaArticulo.Enabled = true;
            this.gridGrupoArticulo.Enabled = true;

            string codigoLinea = Util.GetCurrentCellText(this.gridLineaArticulo.CurrentRow, "Codigo");
            string codigoGrupo = Util.GetCurrentCellText(this.gridGrupoArticulo.CurrentRow, "Codigo");
            //CargarGrupoArticulo(codigoLinea);
            CargarSubGrupoArticulo(codigoLinea, codigoGrupo);
        }

        #endregion

        private void gridLineaArticulo_CommandCellClick(object sender, EventArgs e)
        {
            GridViewRowInfo fila = this.gridLineaArticulo.CurrentRow;
            if (this.gridLineaArticulo.Columns["btnGrabarDet"].IsCurrent)
            {

                GuardarLineaArticulo(fila);
            }

            if (this.gridLineaArticulo.Columns["btnCancelarDet"].IsCurrent)
            {
                CancelarLineaArticulo(fila);
            }

            if (this.gridLineaArticulo.Columns["btnEliminarDet"].IsCurrent)
            {
                EliminarLineaArticulo(fila);
            }

            if (this.gridLineaArticulo.Columns["btnEditarDet"].IsCurrent)
            {
                EditarLineaArticulo(fila);
            }
        }

        private void gridGrupoArticulo_CommandCellClick(object sender, EventArgs e)
        {
            GridViewRowInfo fila = this.gridGrupoArticulo.CurrentRow;
            Cursor.Current = Cursors.WaitCursor;
            if (this.gridGrupoArticulo.Columns["btnGrabarDet"].IsCurrent)
            {
                GuardarGrupoArticulo(fila);
            }

            if (this.gridGrupoArticulo.Columns["btnCancelarDet"].IsCurrent)
            {
                CancelarGrupoArticulo(fila);
            }

            if (this.gridGrupoArticulo.Columns["btnEliminarDet"].IsCurrent)
            {
                EliminarGrupoArticulo(fila);
            }

            if (this.gridGrupoArticulo.Columns["btnEditarDet"].IsCurrent)
            {
                EditarGrupoArticulo(fila);
            }
            Cursor.Current = Cursors.Default;
        }

        private void gridSubGrupoArticulo_CommandCellClick(object sender, EventArgs e)
        {
            GridViewRowInfo fila = this.gridSubGrupoArticulo.CurrentRow;
            Cursor.Current = Cursors.WaitCursor;
            if (this.gridSubGrupoArticulo.Columns["btnGrabarDet"].IsCurrent)
            {
                GuardarSubGrupoArticulo(fila);
            }

            if (this.gridSubGrupoArticulo.Columns["btnCancelarDet"].IsCurrent)
            {
                CancelarSubGrupoArticulo(fila);
            }

            if (this.gridSubGrupoArticulo.Columns["btnEliminarDet"].IsCurrent)
            {
                EliminarSubGrupoArticulo(fila);
            }

            if (this.gridSubGrupoArticulo.Columns["btnEditarDet"].IsCurrent)
            {
                EditarSubGrupoArticulo(fila);
            }
            Cursor.Current = Cursors.Default;
        }

        private void gridLineaArticulo_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row != null)
            {
                if (Util.convertiracadena(e.Row.Cells["Flag"].Value) == "")
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridGrupoArticulo_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row != null)
            {
                if (Util.convertiracadena(e.Row.Cells["Flag"].Value) == "")
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridSubGrupoArticulo_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row != null)
            {
                if (Util.convertiracadena(e.Row.Cells["Flag"].Value) == "")
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnAgregaSubGrupoArticulo_Click(object sender, EventArgs e)
        {
            this.btnAgregarLineaArticulo.Enabled = false;
            this.btnAgregarGrupoArticulo.Enabled = false;
            this.gridLineaArticulo.Enabled = false;
            this.gridGrupoArticulo.Enabled = false;
            AgregarRegistro(this.gridSubGrupoArticulo);

        }

        private void frmLineaArticulo_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                OcultarBarra();
                //HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                CrearColumnas();
                Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al iniciar formulario");
            }
            Cursor.Current = Cursors.Default;
        }

      
        
    }
}
