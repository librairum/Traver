using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using System;
using System.Collections.Generic;

namespace Inv.UI.Win
{
    public partial class frmArticuloSuministro : frmBase
    {
        private static frmArticuloSuministro _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmArticuloSuministro Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmArticuloSuministro(padre);
            _aForm = new frmArticuloSuministro(padre);
            return _aForm;
        }
        internal string codigoArticulo = "";
        internal string descripcionArticulo = "";
        internal string tipoplactas = "";
        internal string unimed = "";
        internal string uniequiv = "";
        internal string unimayor = "";
        internal string montoequiv = "";
        internal string tipo = "";
        internal string estado = "";
        internal List<Articulo> listaArticulo = new List<Articulo>();
        public frmArticuloSuministro(frmMDI padre)
        {
            InitializeComponent();
            FrmParent =padre;
        }
        private void CrearColumnas()
        {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            //RadGridView Grid = this.CreateGridVistaFiltro(this.gridControl);



            CreateGridColumn(Grid, "Codigo", "IN01KEY", 0, "", 90);
            CreateGridColumn(Grid, "Descripcion", "IN01DESLAR", 0, "", 200);
            CreateGridColumn(Grid, "Tipo\nPlactas", "IN01TIPOPLACTAS", 0, "", 70, true, false, true);

            CreateGridColumn(Grid, "Uni\nMed", "In01UniMed", 0, "", 50, true, false, true);

            CreateGridColumn(Grid, "Uni\nEquiv.", "In01UnidadEqui", 0, "", 70, true, false, true);

            CreateGridColumn(Grid, "Uni.\nMayor", "IN01UNIDADMAYOR", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Monto\nEquiv", "IN01MONTOEQUI", 0, "", 70, true, false, true);

            CreateGridColumn(Grid, "CodTipo", "In01tipo", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "Tipo", "CompraTipoDescripcion", 0, "", 70, true, false, true);
            //Proveedor
            CreateGridColumn(Grid, "Proveedor", "IN01CODPRO", 0, "", 70, true, false, true);

            CreateGridColumn(Grid, "In01estado", "In01estado", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "Estado", "CompraEstadoDescripcion", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Mov", "IN01MOV", 0, "", 70, true, false, true);
            //CreateGridColumn(Grid, "TipoPlanCtas", "IN01TIPOPLACTAS", 0, "", 70, true, false, false);

        }
        public void Cargar(string filtro, string codigoTipo, string codigoEstado)
        {
            try
            {
                // TraeArticuloCompras
                List<Articulo> lista = ArticuloLogic.Instance.TraeArticuloCompras(Logueo.CodigoEmpresa,
                                        Logueo.Anio, "*", codigoTipo, codigoEstado, Logueo.PS_codnaturaleza);

                this.listaArticulo = lista;
                this.gridControl.DataSource = lista;

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar:" + ex.Message);
            }
        }
        private void frmArticuloSuministro_Load(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVista);
            CrearColumnas();
            Cargar("*", "", "");
        }

        private void AbrirFormulario()
        {

            var frmInstance = frmArticuloSuministroDet.Instance(this);
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticuloSuministroDet);

            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }

            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();
        }

        protected override void OnNuevo()
        {
            SeleccionarDatos();
            this.codigoArticulo = "";
            Estado = FormEstate.New;
            AbrirFormulario();
        }
        protected override void OnEditar()
        {
            SeleccionarDatos();
            Estado = FormEstate.Edit;
            AbrirFormulario();
        }
        protected override void OnVista()
        {
            SeleccionarDatos();
            Estado = FormEstate.View;
            AbrirFormulario();
        }
        protected override void OnEliminar()
        {
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el articulo?");
                if (respuesta == true)
                {

                    string codigoArticulo = Util.GetCurrentCellText(gridControl.CurrentRow, "IN01KEY");
                    int nFlag = 0; string sMensaje = "";

                    CompraArticuloLogic.Instace.EliminarArticulo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                        codigoArticulo, "N", out nFlag, out sMensaje);

                    Util.ShowMessage(sMensaje, nFlag);

                    if (nFlag == 1)
                    {
                        //refrescar 
                        Cargar("*", "", "");
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al eliminar articulo");
            }
            Estado = FormEstate.List;
        }
      

        private void SeleccionarDatos()
        {
            this.codigoArticulo = Util.GetCurrentCellText(this.gridControl.CurrentRow, "IN01KEY");
            this.descripcionArticulo = Util.GetCurrentCellText(this.gridControl.CurrentRow, "IN01DESLAR");
            this.tipoplactas = Util.GetCurrentCellText(this.gridControl.CurrentRow, "IN01TIPOPLACTAS");
            this.unimed = Util.GetCurrentCellText(this.gridControl.CurrentRow, "In01UniMed");
            this.uniequiv = Util.GetCurrentCellText(this.gridControl.CurrentRow, "In01UnidadEqui");
            this.unimayor = Util.GetCurrentCellText(this.gridControl.CurrentRow, "IN01UNIDADMAYOR");

            this.montoequiv = Util.GetCurrentCellText(this.gridControl.CurrentRow, "IN01MONTOEQUI");
            this.tipo = Util.GetCurrentCellText(this.gridControl.CurrentRow, "In01tipo");
            this.estado = Util.GetCurrentCellText(this.gridControl.CurrentRow, "In01estado");

        }

        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarDatos();
            Estado = FormEstate.View;
            AbrirFormulario();
        }
    }
}
