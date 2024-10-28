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
namespace Prod.UI.Win
{
    public partial class frmValoresxDefecto : frmBaseMante
    {
        #region "variables"
        bool isloaded = true;
        private frmMDI FrmParent { get; set; }
        private static frmValoresxDefecto _aForm;
        #endregion
        #region "Instancias"
        ValorxDefecto valor = new ValorxDefecto();
        #endregion

        #region "Metodos Generales"
        public static frmValoresxDefecto Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmValoresxDefecto(mdiPrincipal);
            _aForm = new frmValoresxDefecto(mdiPrincipal);
            return _aForm;
        }

        public frmValoresxDefecto(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            gridControl.CellBeginEdit += new GridViewCellCancelEventHandler(gridControl_CellBeginEdit);
            iniciarFormulario();
        }
        private void iniciarFormulario()
        {
            Estado = FormEstate.List;
            HabilitarBotones(true, true, true, false, false, false);
            crearColumnas();
            cargar();
        }
        void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (isloaded == false) return;
            
            if (Estado == FormEstate.List || 
                Estado == FormEstate.View)
            {
                if ( e.Column.Name == "GLO02DESCRIPCION" ||
                    e.Column.Name == "GLO02VALOR" )
                {
                    e.Cancel = true;
                }
            }
            
        }
        #endregion

        #region "Eventos"

        #endregion
      
        private void crearColumnas()
        { 
            RadGridView Grid =  CreateGridVista(this.gridControl);
            bool readOnlyOK = true; bool editableOK = true; bool numericOK = true;bool visibleOK = true;

            CreateGridColumn(Grid, "GLO02EMPRESACOD", "GLO02EMPRESACOD", 0, "", 70,     !readOnlyOK, editableOK, !visibleOK, !numericOK);
            CreateGridColumn(Grid, "GLO02MODULOCOD", "GLO02MODULOCOD", 0, "", 70,       !readOnlyOK, editableOK, !visibleOK, !numericOK);
            CreateGridColumn(Grid, "Codigo", "GLO02CODIGO", 0, "", 90, readOnlyOK, !editableOK, visibleOK, !numericOK);
            CreateGridColumn(Grid, "Descripcion", "GLO02DESCRIPCION", 0, "", 250,   !readOnlyOK, editableOK, visibleOK, !numericOK);
            CreateGridColumn(Grid, "Valor", "GLO02VALOR", 0, "", 150,               !readOnlyOK, editableOK, visibleOK, !numericOK);                         
        }
        private void cargar()
        {
            Estado = FormEstate.List;
            List<ValorxDefecto> lista =  GlobalLogic.Instance.TraerValorxDefecto(Logueo.CodigoEmpresa, Logueo.codModulo);
            this.gridControl.DataSource = lista;

        }

        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            HabilitarBotones(false, false, false, true, true, false);
            this.gridControl.Rows.AddNew();
            string codigo = "";
            GlobalLogic.Instance.TraeValoresxDefectoCodigo(Logueo.CodigoEmpresa, Logueo.codModulo, out codigo);
            GridViewRowInfo row = this.gridControl.CurrentRow;
            Util.SetValueCurrentCellText(row, "GLO02EMPRESACOD", Logueo.CodigoEmpresa);
            Util.SetValueCurrentCellText(row, "GLO02MODULOCOD", Logueo.codModulo);
            Util.SetValueCurrentCellText(row, "GLO02CODIGO", codigo);
            
        }
        protected override void OnGuardar()
        {
            GridViewRowInfo row =  gridControl.CurrentRow;
            valor = new ValorxDefecto();
            valor.GLO02EMPRESACOD = Util.GetCurrentCellText(row, "GLO02EMPRESACOD");
            valor.GLO02MODULOCOD = Util.GetCurrentCellText(row, "GLO02MODULOCOD");
            valor.GLO02CODIGO = Util.GetCurrentCellText(row, "GLO02CODIGO");
            valor.GLO02DESCRIPCION = Util.GetCurrentCellText(row, "GLO02DESCRIPCION");
            valor.GLO02VALOR = Util.GetCurrentCellText(row, "GLO02VALOR");
            int flag = 0; string mensaje = "";
            if (Estado == FormEstate.New)
            {
                GlobalLogic.Instance.InsertarValorxDefecto(valor, out flag, out mensaje);
            }
            else if (Estado == FormEstate.Edit)
            {
                GlobalLogic.Instance.ActualizarValorxDefecto(valor, out flag, out mensaje);
            }

            
            Util.ShowMessage(mensaje, flag);

            if (flag == 0)
            {
                OnCancelar();
            }

        }
        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            HabilitarBotones(false, false, false, true, true, false);
            Util.SetCellInitEdit(gridControl, "GLO02DESCRIPCION");

        }

        protected override void OnEliminar()
        {
            Estado = FormEstate.List;
            
            valor = new ValorxDefecto();
            GridViewRowInfo row = this.gridControl.CurrentRow;

            valor.GLO02EMPRESACOD = Util.GetCurrentCellText(row, "GLO02EMPRESACOD");
            valor.GLO02MODULOCOD = Util.GetCurrentCellText(row, "GLO02MODULOCOD");
            valor.GLO02CODIGO = Util.GetCurrentCellText(row, "GLO02CODIGO");
            
            bool isConfirmed = Util.ShowQuestion("¿Desea elimianr el registro?");
            int flag = 0; string mensaje = "";
                if(isConfirmed == true)
                {
                    GlobalLogic.Instance.EliminarValorxDefecto(valor, out flag, out mensaje);
                    Util.ShowMessage(mensaje, flag);
                    if (flag == 0)
                    {
                        OnCancelar();
                    }
                }
        }

        protected override void OnCancelar()
        {
            iniciarFormulario();
        }
    }
}
