using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Inv.BusinessLogic;
using Inv.BusinessEntities;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
//using Inv.UI.Win.Maestros;

namespace Fac.UI.Win
{
    public partial class frmProductos : frmBase
    {
        #region "Instancia"
        private static frmProductos _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmProductos Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmProductos(formParent);
            _aForm = new frmProductos(formParent);
            return _aForm;
        }
        #endregion
        internal string ProductoCodigo = "";
        ArticuloLogic datos = ArticuloLogic.Instance;
        public frmProductos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importarMP;

        #region "Seguridad"
        private void accesobotonesperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.CodModulo,
            this.Name, out nuevo_a, out editar_a, out eliminar_a, out ver_a, out imprimir_a,
            out refrescar_a, out importar_a, out vista_a, out guardar_a, out cancelar_a,
            out expmovi_a, out importarMP);
        }
        private void ComportarmientoBotones(string accion)
        {
            OcultarBotones();
            switch (accion)
            {
                case "cargar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    if (ver_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVer); }
                    break;

                case "nuevo":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "editar":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "grabar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    break;

                case "cancelar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    break;
            }

        }
        #endregion
        private void AbrirFormulario(FormEstate pEstado)
        {
          
            var instancia = frmProductosDet.Instance(this);
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductosDet);
            if (frmexiste != null) { instancia.BringToFront(); return; }

            //instancia del  formulario
            instancia.Estado = pEstado;
            instancia.MdiParent = this.ParentForm;
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia.Show();

        }
        protected override void OnNuevo()
        {
            AbrirFormulario(FormEstate.New);
        }

        protected override void OnEditar()
        {
            if (gridControl.RowCount == 0) return;
            ProductoCodigo = Util.GetCurrentCellText(gridControl, "IN01KEY");
            AbrirFormulario(FormEstate.Edit);
        }

        protected override void OnEliminar()
        {
            if (gridControl.RowCount == 0) return;
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                int int_flag = 0; string str_mensaje = "";
                if (respuesta == false) return;
                
                    string ProductoCodigo = "";
                    ProductoCodigo = Util.GetCurrentCellText(gridControl, "IN01KEY");
                    datos.ProductoEliminar(Logueo.CodigoEmpresa, Logueo.Anio, ProductoCodigo, 
                                            out int_flag, out str_mensaje);
                    
                    Util.ShowMessage(str_mensaje, int_flag);

                    if (int_flag == 1)
                        Cargar();
                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
           //ArticuloLogic.Instance.EliminarProducto(Logueo.CodigoEmpresa, Logueo.Anio, 
        }

        protected override void OnVer()
        {
            if (gridControl.RowCount == 0) return;
            ProductoCodigo = Util.GetCurrentCellText(gridControl, "IN01KEY");
            AbrirFormulario(FormEstate.View);
        }

        protected override void OnRefrescar()
        {
            Cargar();
        }

        public void Cargar()
        {            
            List<Spu_Fact_Trae_Proter> lista = ArticuloLogic.Instance.TraerProductos(Logueo.CodigoEmpresa,
                                                                    Logueo.Anio, Logueo.PT_codnaturaleza);
            gridControl.DataSource = lista;
        }
        void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);
            bool VisibleON = true, VisibleOFF = false, ReadOnlyON = true, ReadOnlyOFF = false, EditableON = true, EditableOFF = false;
            this.CreateGridColumn(Grid, "Codigo", "IN01KEY", 0, "", 180);
            this.CreateGridColumn(Grid, "Descripcion", "IN01DESLAR", 0, "", 385);
            this.CreateGridColumn(Grid, "Unidad Medida", "IN01UNIMED", 0, "", 50);
            this.CreateGridColumn(Grid, "UnidadDesc", "UnidadDesc", 0, "", 70);

            this.CreateGridColumn(Grid, "Unidad venta", "IN01UNIMEDVENTA", 0, "", 70);
            this.CreateGridColumn(Grid, "Univenta Desc", "UniventaDesc", 0, "", 70);

            this.CreateGridColumn(Grid, "CodTipo", "tipo", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodColor.", "color", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodTonalidad", "tonalidad", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodFormato", "formato", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodAcabado", "acabado", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodRelleno", "relleno", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodCalidad", "calidad", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodBorde", "borde", 0, "", 85, ReadOnlyON, EditableON, VisibleOFF);
            this.CreateGridColumn(Grid, "CodModelo", "modelo", 0, "", 100, ReadOnlyON, EditableON, VisibleOFF);

            CreateGridColumn(Grid, "Tipo", "tipodesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Color", "colordesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Tonalidad", "tonalidaddesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Formato", "formatodesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Acabado", "acabadodesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Relleno", "rellenodesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Borde", "bordedesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Calidad", "Calidaddesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);
            CreateGridColumn(Grid, "Modelo", "modelodesc", 0, "", 100, ReadOnlyON, EditableON, VisibleON);

            CreateGridColumn(Grid, "IN01FLAGTIPCALAREA", "IN01FLAGTIPCALAREA", 0, "", 100, ReadOnlyON, EditableON, VisibleOFF);
            CreateGridColumn(Grid, "Estado", "IN01ESTADO", 0, "", 100, ReadOnlyON, EditableON, VisibleOFF);
            CreateGridColumn(Grid, "Ingles", "IN01DESINGLES", 0, "", 100, ReadOnlyON, EditableON, VisibleOFF);
            CreateGridColumn(Grid, "Espanol", "IN01DESESPANIOL", 0, "", 100, ReadOnlyON, EditableON, VisibleOFF);

        }
       
        private void frmProductos_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Cargar();
            habilitarBotones(true, true, true, false, false, false, false, false, false);

            accesobotonesperfil();
            ComportarmientoBotones("cargar");

        }
    }
}
