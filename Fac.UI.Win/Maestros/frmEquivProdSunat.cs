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
    public partial class frmEquivProdSunat : frmBase
    {
        #region "Instancia"
        private static frmEquivProdSunat _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmEquivProdSunat Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmEquivProdSunat(formParent);
            _aForm = new frmEquivProdSunat(formParent);
            return _aForm;
        }
        #endregion

        EquivProdSunatLogic datos = EquivProdSunatLogic.Instance;
        public frmEquivProdSunat(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        private void frmEquivProdSunat_Load(object sender, EventArgs e)
        {            
            OcultarBarra();
            Util.ConfigGridToEnterNavigation(this.gridControl);
            CrearColumnas();
            Cargar();
        }

        private void CrearColumnas()
        { 
            RadGridView Grid = CreateGridVista(gridControl);
            CreateGridColumn(Grid, "Tipo", "TipoCodigo", 0, "", 70);
            CreateGridColumn(Grid, "Descripcion", "TipoDescripcion", 0, "",150);
            CreateGridColumn(Grid, "ProdSunat", "ProdSunatCodigo", 0, "",70);
            CreateGridColumn(Grid, "Descripcion", "ProdSunatDescripcion", 0, "", 250);
            CreateGridColumn(Grid, "Segmento", "ProdSunatSegmento", 0, "", 350);
            CreateGridColumn(Grid, "Clase", "ProdSunatClase", 0, "", 350);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 70, true, false, false);
            AgregarBotones();
        }
        private void AgregarBotones()
        {
            GridViewCommandColumn btnEditarDet = new GridViewCommandColumn();
            btnEditarDet.Name = "btnEditarDet";
            btnEditarDet.HeaderText = "";
            gridControl.Columns.Add(btnEditarDet);
            gridControl.Columns["btnEditarDet"].Width = 30;


            GridViewCommandColumn btnGrabarDet = new GridViewCommandColumn();
            btnGrabarDet.Name = "btnGrabarDet";
            btnGrabarDet.HeaderText = "";
            gridControl.Columns.Add(btnGrabarDet);
            gridControl.Columns["btnGrabarDet"].Width = 30;

            GridViewCommandColumn btnCancelarDet = new GridViewCommandColumn();
            btnCancelarDet.Name = "btnCancelarDet";
            btnCancelarDet.HeaderText = "";
            gridControl.Columns.Add(btnCancelarDet);
            gridControl.Columns["btnCancelarDet"].Width = 30;
        }
        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Util.FormateoBotones(gridControl, Estado, e);
        }

        private void GuardarDetalle()
        {
            try
            {
                string str_mensaje = "", str_flag = "";
                int int_flag = 0;

                EquivProdSunat equivalencia = new EquivProdSunat();
                equivalencia.FAC88CODEMP = Logueo.CodigoEmpresa;
                equivalencia.FAC88PRODEMPRESA = Util.GetCurrentCellText(gridControl.CurrentRow, "TipoCodigo");
                equivalencia.FAC88PRODSUNATCODIGO = Util.GetCurrentCellText(gridControl.CurrentRow, "ProdSunatCodigo");
                str_flag = Util.GetCurrentCellText(gridControl, "flag");

                if (str_flag == "0")
                {
                    datos.Inserta(equivalencia, out int_flag, out str_mensaje);
                }
                else
                {
                    datos.Actualiza(equivalencia, out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                {
                    Cargar();
                    Util.enfocarFila(gridControl, "TipoCodigo", equivalencia.FAC88PRODEMPRESA);

                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al editar: " + ex.Message);
            }
        }

        private void EditarDetalle()
        {
            try
            {
                Util.SetValueCurrentCellText(gridControl, "flag", "1");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
                Util.ResaltarAyuda(gridControl, "ProdSunatCodigo");
                Util.SetCellGridFocus(gridControl, "ProdSunatCodigo");
                Util.SetCellInitEdit(gridControl, "ProdSunatCodigo");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al editar: " + ex.Message);
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
                Util.ShowError("Error al editar: " + ex.Message);
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
                EditarDetalle();
            }          

            if (this.gridControl.Columns["btnCancelarDet"].IsCurrent)
            {               
                CancelarDetalle();
            }
        }
        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (Util.GetCurrentCellText(gridControl, "flag") == "") return;

            if (e.KeyValue == (char)Keys.F1)
                if (Util.IsCurrentColumn(gridControl, "ProdSunatCodigo"))
                    TraerAyuda(enmAyuda.enmProductoSunat);

        }
        private void TraerAyuda(enmAyuda tipo)
        {
            frmBusqueda frm = new frmBusqueda(tipo);
            string[] datos;

            frm.ShowDialog();
            if (frm.Result == null) return;
            if (frm.Result.ToString() == "") return;
            datos = frm.Result.ToString().Split('|');
            if (datos.Length == 0) return;
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "ProdSunatCodigo", datos[0]);
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "ProdSunatDescripcion", datos[1]);
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "ProdSunatSegmento", datos[3]);
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "ProdSunatClase", datos[5]);
            
            
                
        }
        private void Cargar()
        {
            try
            {
                gridControl.DataSource = datos.ListaEquivalenciasSunat("01");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar :" + ex.Message);
            }
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
