using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Fac.UI.Win
{
    public partial class frmArticuloSuministro : frmBase
    {

        private static frmArticuloSuministro _aForm;
        private frmMDI FrmParent { get; set; }

        public static frmArticuloSuministro Instance(frmMDI padre) {
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
            FrmParent = padre;
        }

        

        private void CrearColumnas() {
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

            CreateGridColumn(Grid, "In01estado", "In01estado", 0, "", 70, true, false, false);                        
            CreateGridColumn(Grid, "Estado", "CompraEstadoDescripcion", 0, "", 70, true, false, true);
            
            
        }

        public void Cargar(string filtro, string codigoTipo, string codigoEstado) {
            try
            {
                // TraeArticuloCompras
                List<Articulo> lista = ArticuloLogic.Instance.TraeArticuloCompras(Logueo.CodigoEmpresa,
                                        Logueo.Anio, "*", codigoTipo, codigoEstado,Logueo.PS_codnaturaleza);
                this.listaArticulo = lista;
                this.gridControl.DataSource = lista;

            }
            catch (Exception ex) {
                Util.ShowError("Error al cargar:" + ex.Message);
            }
        }
        private void frmArticulos_Load(object sender, EventArgs e)
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
            //rbInsumos.Checked = true;
            //rbActivo.Checked = true;
            Cursor.Current = Cursors.Default;
        }
        private void AbrirFormulario() {
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
        protected override void OnEliminar()
        {
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el articulo?");
                if (respuesta == true)
                {

                    string codigoArticulo = Util.GetCurrentCellText(gridControl.CurrentRow, "IN01KEY");
                    int nFlag = 0; string sMensaje = "";

                    CompraArticuloLogic.Instace.EliminarArticuloFact(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoArticulo, "N", out nFlag, out sMensaje);

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

        private void SeleccionarDatos() {
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
        protected override void OnVer()
        {
            Cursor.Current = Cursors.WaitCursor;


            try
            {
                SeleccionarDatos();
                this.listaArticulo = ArticuloLogic.Instance.TraeArticuloCompras(Logueo.CodigoEmpresa,
                                                        Logueo.Anio, "", tipo, estado,Logueo.PS_codnaturaleza);
                Estado = FormEstate.View;
                AbrirFormulario();
                //var frmInstance = frmArticulosActualizacionColqui.Instance(this);
                //var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticulosActualizacionColqui);

                //if (frmExist != null) {
                //    frmInstance.BringToFront();
                //    return;
                //}
                
                //Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                //frmInstance.MdiParent = this.ParentForm;

                //((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
                //frmInstance.Show();

            }
            catch (Exception ex) {
                Util.ShowError("Error al ver detalle:" + ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }


            
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable dt =  ArticuloLogic.Instance.TraeReporteArticuloCompras(Logueo.CodigoEmpresa, Logueo.Anio, "*", "", "",Logueo.PS_codnaturaleza);
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptArticulo.rpt";
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al generar reporte");
            }
            Cursor.Current = Cursors.Default;
        }
        

        private void gridControl_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            //if (e.CellElement == null) return;
            //try
            //{
             
            //}
            //catch (Exception ex) { 
                
            //}
        }

      
        private void gridControl_ViewRowFormatting(object sender, RowFormattingEventArgs e)
        {
            try
            {
                //if (e.RowElement is GridFilterRowElement) {
                //    e.RowElement.DrawFill = true;
                //    e.RowElement.GradientStyle = GradientStyles.Solid;
                //    e.RowElement.BackColor = Color.Yellow;
                //    e.RowElement.BackColor = Color.FromArgb(247, 249, 189);                    
                //}
                
            }
            catch (Exception ex)
            {

            }
        }

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (this.gridControl.Rows.Count == 0) return;
            OnVer();
        }
    }
}
