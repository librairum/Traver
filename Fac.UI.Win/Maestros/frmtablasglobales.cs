using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

namespace Fac.UI.Win
{
    public partial class frmtablasglobales : frmBase
    {
        GlobalLogic datos = GlobalLogic.Instance;
        public string TablaCodigo = "";
        #region "Instancia"
        private static frmtablasglobales _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmtablasglobales Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmtablasglobales(formParent);
            _aForm = new frmtablasglobales(formParent);
            return _aForm;
        }
        #endregion

        private void CargarBotonesPorDefecto()
        {
            habilitarBotones(false, false, false, false, 
                             true, false, false, false, false);
        }

        public frmtablasglobales(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;            
            //gestionarBotones(true, true, true,false, false, true,
            CargarBotonesPorDefecto();
            CrearColumnas();
            Cargar();
            gridControl.SelectionChanging += new GridViewSelectionCancelEventHandler(gridControl_SelectionChanging);
        }

        void gridControl_SelectionChanging(object sender, GridViewSelectionCancelEventArgs e)
        {
           
        }
        void Cargar()
        {            
            this.gridControl.DataSource = datos.TraeTablasGlobales("glo01codigotabla", "*");            
        }
        void CrearColumnas()
        { 
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid,"Tabla", "glo01codigotabla", 0, "", 120);
            CreateGridColumn(Grid,"Codigo", "glo01codigo", 0, "", 100);
            CreateGridColumn(Grid,"Descripcion","glo01descripcion", 0, "", 300);
            CreateGridColumn(Grid, "glo01texto1", "glo01texto1", 0, "", 300, true, false, false);
            CreateGridColumn(Grid, "glocomentario", "glocomentario", 0, "", 300, true, false, false);
        }
        private void AbrirFormulario(FormEstate pEstado)
        {

            var instancia = frmtablaglobalesDet.Instance(this);
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmtablaglobalesDet);
            if (frmexiste != null) { instancia.BringToFront(); return; }

            //instancia del  formulario
            instancia.Estado = pEstado;
            instancia.MdiParent = this.ParentForm;
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia.Show();

        }
        protected override void OnVer()
        {
            if (gridControl.RowCount == 0) return;
            TablaCodigo = Util.GetCurrentCellText(gridControl, "glo01codigotabla");
            Estado = FormEstate.View;
            AbrirFormulario(Estado);
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            TablaCodigo = Util.GetCurrentCellText(gridControl, "glo01codigotabla");
            AbrirFormulario(Estado);
        }

        protected override void OnEditar()
        {
            if (gridControl.RowCount == 0) return;
            TablaCodigo = Util.GetCurrentCellText(gridControl, "glo01codigotabla");
            Estado = FormEstate.Edit;
            AbrirFormulario(Estado);            
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

                entidad.glo01codigotabla =Util.GetCurrentCellText(gridControl, "glo01codigotabla");
                entidad.glo01codigo = Util.GetCurrentCellText(gridControl, "glo01codigo");

                datos.EliminarTablaGlobal(entidad, out int_flag, out str_mensaje);
                
                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1){ Cargar(); }
                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }


    }
}
