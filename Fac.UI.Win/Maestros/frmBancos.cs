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
    public partial class frmBancos : frmBase
    {
        bool isLoaded = false;

        #region "Instancia"
        private static frmBancos _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmBancos Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmBancos(formParent);
            _aForm = new frmBancos(formParent);
            return _aForm;
        }
        #endregion
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        public frmBancos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;

            Util.ConfigGridToEnterNavigation(gridControl);
            Util.seleccionatFilaCompleta(gridControl);

            habilitarBotones(true, false, false, false, false, false, false, false, false);
            //Personalizar la grilla
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
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
        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (gridControl.Rows.Count == 0) return;

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
        void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            Util.FormateoBotones(gridControl, Estado, e);
        }
        private void frmBancos_Load(object sender, EventArgs e)
        {            
            CrearColumnas();
            Cargar();
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

                GridViewRowInfo row = gridControl.CurrentRow;
                Util.SetValueCurrentCellText(gridControl, "flag", "0");
                Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
                Util.SetCellGridFocus(gridControl, "FAC50CODBANCO");
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro al agregar fila:" +ex.Message);
            }
        }
        private bool Validar()
        {
            string BancoCodigo = "", BancoNombre = "", BancoBankCode = "",
                        BancoAcountNumber = "";

            BancoCodigo = Util.GetCurrentCellText(gridControl, "FAC50CODBANCO");
            BancoNombre = Util.GetCurrentCellText(gridControl, "FAC50DESCRIPCION");
            BancoBankCode = Util.GetCurrentCellText(gridControl, "FAC50BANKCODE");
            BancoAcountNumber = Util.GetCurrentCellText(gridControl, "FAC50ACOUNTNUMBER");
            if (BancoCodigo == "")
            {
                Util.ShowAlert("Ingresar codigo de banco");
                Util.SetCellGridFocus(gridControl, "FAC50CODBANCO");
                return false;
            }
            if (BancoNombre == "")
            {
                Util.ShowAlert("Ingresar nombre de banco");
                Util.SetCellGridFocus(gridControl, "FAC50DESCRIPCION");
                return false;
            }
            if (BancoBankCode == "")
            {
                Util.ShowAlert("Ingresar bank code");
                Util.SetCellGridFocus(gridControl, "FAC50BANKCODE");
                return false;
            }
            if (BancoAcountNumber == "")
            {
                Util.ShowAlert("Ingresar cuenta de banco");
                Util.SetCellGridFocus(gridControl, "FAC50ACOUNTNUMBER");
                return false;
            }
            return true;
        }
        private void GuardarDetalle()
        {
            try
            {
                string str_mensaje = "", str_flag = "";
                int int_flag = 0;
                string BancoCodigo = "", BancoNombre = "", BancoBankCode = "",
                    BancoAcountNumber = "";

                BancoCodigo = Util.GetCurrentCellText(gridControl, "FAC50CODBANCO");
                BancoNombre = Util.GetCurrentCellText(gridControl, "FAC50DESCRIPCION");
                BancoBankCode = Util.GetCurrentCellText(gridControl, "FAC50BANKCODE");
                BancoAcountNumber = Util.GetCurrentCellText(gridControl, "FAC50ACOUNTNUMBER");

                if (Validar() == false) return;
                


                str_flag = Util.GetCurrentCellText(gridControl, "flag");
                if (str_flag == "0")
                {
                    BancoLogic.Instance.InsertarBanco(BancoCodigo, BancoNombre,
                    BancoBankCode, BancoAcountNumber, out int_flag, out str_mensaje);
                }
                else if (str_flag == "1")
                {
                    BancoLogic.Instance.ActualizarBanco(BancoCodigo, BancoNombre,
                    BancoBankCode, BancoAcountNumber, out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    Cargar();

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar detalle: " +ex.Message);
            }
        }

        private void EditarDetalle()
        {
            Util.SetValueCurrentCellText(gridControl, "flag", "1");
            Util.SetValueCurrentCellText(gridControl, "flagBotones", "E");
            Util.SetCellGridFocus(gridControl, "FAC50DESCRIPCION");
            Util.SetCellInitEdit(gridControl, "FAC50DESCRIPCION");
        }

        private void EliminarDetalle()
        {
            try
            {
                string BancoCodigo = "";
                int int_flag = 0; string str_mensaje = "";
                BancoCodigo = Util.GetCurrentCellText(gridControl, "FAC50CODBANCO");
                bool respuesta = Util.ShowQuestion("¿Desea eliminar registro?");
                if (respuesta == true)
                {
                    BancoLogic.Instance.EliminarBanco(BancoCodigo, out int_flag, out str_mensaje);
                }
                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                {
                    Cargar();
                }
                //
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar detalle : "+ ex.Message);
            }
        }

        private void CancelarDetalle()
        {
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                List<Bancos> lista = BancoLogic.Instance.TraeBancos("", "*");
                gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar : " + ex.Message);
            }
        }

        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "Cod.Banco", "FAC50CODBANCO", 0, "", 90, false, true);
            CreateGridColumn(Grid, "Desc.Banco", "FAC50DESCRIPCION", 0, "", 200, false, true);
            CreateGridColumn(Grid, "BankCode", "FAC50BANKCODE", 0, "", 90, false, true);
            CreateGridColumn(Grid, "AccountNumber", "FAC50ACOUNTNUMBER", 0, "", 90, false, true);

            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "flagBotones", "flagBotones", 0, "", 90, true, false, false);

            Util.AddButtonsToGrid(Grid);
        }

        
    }
}
