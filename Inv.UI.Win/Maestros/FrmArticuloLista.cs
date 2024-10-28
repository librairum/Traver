using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI;
using System.Linq;
using Telerik.WinControls.UI.Docking;
namespace Inv.UI.Win
{
    public partial class FrmArticuloLista : frmBase
    {
        public FrmArticuloLista()
        {
            InitializeComponent();
            Crearcolumnas();
            OnBuscar();
            
        }
        public string naturalezAlmacen = "";
        public static FrmArticuloLista formulario;
        private frmMDI FrmParent { get; set; }
        private static FrmArticuloLista _aForm;
        public static FrmArticuloLista Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmArticuloLista(mdiPrincipal);
            _aForm = new FrmArticuloLista(mdiPrincipal);
            return _aForm;
        }
        public static FrmArticuloLista Instancia()
        {
            return _aForm;
        }
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a, cancelar_a, expmovi_a, importarMP;
        CommandBarStripElement menu;
        RadCommandBarBaseItem cbbNuevo;
        RadCommandBarBaseItem cbbEditar;
        RadCommandBarBaseItem cbbEliminar;

        RadCommandBarBaseItem cbbVer;
        RadCommandBarBaseItem cbbVista;
        RadCommandBarBaseItem cbbImprimir;
        RadCommandBarBaseItem cbbRefrescar;
        RadCommandBarBaseItem cbbImportar;

        RadCommandBarBaseItem cbbGuardar;
        RadCommandBarBaseItem cbbCancelar;
        RadCommandBarBaseItem cbbExportarMovimientos;
        public FrmArticuloLista(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            OnBuscar();
            //this.cargarPermisos(this.Name);
            this.gridControl.FilterChanged += new GridViewCollectionChangedEventHandler(gridControl_FilterChanged);
            menu = toolBar.CommandBarElement.Rows[0].Strips[0];
            cbbNuevo = menu.Items["cbbNuevo"];
            cbbEditar = menu.Items["cbbEditar"];
            cbbEliminar = menu.Items["cbbEliminar"];

            cbbVer = menu.Items["cbbVer"];
            cbbVista = menu.Items["cbbVista"];
            cbbImprimir = menu.Items["cbbImprimir"];
            cbbRefrescar = menu.Items["cbbRefrescar"];
            cbbImportar = menu.Items["cbbImportar"];

            cbbGuardar = menu.Items["cbbGuardar"];
            cbbCancelar = menu.Items["cbbCancelar"];
            cbbExportarMovimientos = menu.Items["cbbExportarMovimientos"];
            accesobtonesxperfil();

            ComportarmientoBotones("cargar");
            formulario = this;
            
        }
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a,
                                                                    out editar_a, out eliminar_a, out ver_a, out imprimir_a,
                                                                     out refrescar_a, out importar_a, out vista_a,
                                                                    out guardar_a, out cancelar_a, out expmovi_a, out importarMP);
        }
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ver_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = vista_a ? ElementVisibility.Visible :
                                                                 ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = imprimir_a ? ElementVisibility.Visible :
                                                                      ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = refrescar_a ? ElementVisibility.Visible :
                                                                        ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = importar_a ? ElementVisibility.Visible :
                                                                      ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible :
                                                                    ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible :
                                                                        ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "nuevo":

                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "editar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = guardar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = cancelar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "grabar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
                case "cancelar":
                    if (cbbNuevo != null) cbbNuevo.Visibility = nuevo_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEditar != null) cbbEditar.Visibility = editar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                    if (cbbEliminar != null) cbbEliminar.Visibility = eliminar_a ? ElementVisibility.Visible : ElementVisibility.Collapsed;

                    if (cbbVer != null) cbbVer.Visibility = ElementVisibility.Collapsed;
                    if (cbbVista != null) cbbVista.Visibility = ElementVisibility.Collapsed;
                    if (cbbImprimir != null) cbbImprimir.Visibility = ElementVisibility.Collapsed;
                    if (cbbRefrescar != null) cbbRefrescar.Visibility = ElementVisibility.Collapsed;
                    if (cbbImportar != null) cbbImportar.Visibility = ElementVisibility.Collapsed;

                    if (cbbGuardar != null) cbbGuardar.Visibility = ElementVisibility.Collapsed;
                    if (cbbCancelar != null) cbbCancelar.Visibility = ElementVisibility.Collapsed;
                    if (cbbExportarMovimientos != null) cbbExportarMovimientos.Visibility = expmovi_a ? ElementVisibility.Visible :
                                                                                             ElementVisibility.Collapsed;
                    break;
            }

        }

        //void cargarPermisos()
        //{
        //    bool Nuevo, Editar, Eliminar, Ver, Imprimir, Refresh;
        //    if (SegMenuPorPerfilLogic.Instance.Trae_OpcionesPorPerfil(Logueo.codigoPerfil, "FrmArticuloLista") != null)
        //    {
        //        string variable = SegMenuPorPerfilLogic.Instance.Trae_OpcionesPorPerfil(Logueo.codigoPerfil, "FrmArticuloLista").opcxmenu;
        //        Nuevo = (variable.Substring(0, 1).CompareTo("1") == 0);
        //        Editar = (variable.Substring(1, 1).CompareTo("1") == 0);
        //        Eliminar = (variable.Substring(2, 1).CompareTo("1") == 0);
        //        Ver = (variable.Substring(4, 1).CompareTo("1") == 0);
        //        Refresh = (variable.Substring(6, 1).CompareTo("1") == 0);
              
        //    }

        //}
        private void Crearcolumnas()
        {
            RadGridView grilla =  this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 180, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 385, true, false, true);
            this.CreateGridColumn(grilla, "Unidad Medida", "IN01UNIMED", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "tipo", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Color.", "color", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Tonalidad", "tonalidad", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Formato", "formato", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Acabado", "acabado", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Relleno", "relleno", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Borde", "borde", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Modelo", "modelo", 0, "", 100, true, false, true);            
        }
        
        protected override void OnRefrescar()
        {
            OnBuscar();
        }
        public void listar() {
            var lista = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa, Logueo.Anio,"03");
            this.gridControl.DataSource = lista;
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa,Logueo.Anio,"03");
            this.gridControl.DataSource = lista;
        }
        
        protected override void OnNuevo()
        {            
            var instancia = FrmArticuloDet.Instance(this);
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmArticuloDet);

            if (frmexiste != null)
            {
                instancia.BringToFront();
                return;
            }

            instancia.Estado = FormEstate.New;
            instancia.MdiParent = this.ParentForm;
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia._grid = gridControl;
            instancia.Show();
        }
        protected override void OnVer()
        {
            string ArticuloCodigo = gridControl.CurrentRow.Cells["IN01KEY"].Value.ToString();
            var instancia = FrmArticuloDet.Instance(this);
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmArticuloDet);
            if (frmexiste != null)
            {
                instancia.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            instancia._ArticuloCodigo = ArticuloCodigo;
            instancia.Estado = FormEstate.View;
            instancia.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia._grid = gridControl;
            instancia.pos = gridControl.CurrentRow.Index;
            
            instancia.Show(); 
        }
       
        protected override void OnEditar()
        {
            if (this.gridControl.RowCount == 0)
                return;

            string ArticuloCodigo = string.Empty;
            ArticuloCodigo = this.gridControl.CurrentRow.Cells["IN01KEY"].Value.ToString();
            var instancia = FrmArticuloDet.Instance(this);
            var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmArticuloDet);
            //validar si la ventana esta abierta

            if (frmexiste != null)
            { //si encuentra  el formulario 
                //envia el foco al formulario encontrado
                instancia.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            //instancia del nuevo formulario
            instancia._ArticuloCodigo = ArticuloCodigo;
            instancia.Estado = FormEstate.Edit;
            instancia.MdiParent = this.ParentForm;
            ((RadDock)(ctrl)).ActivateMdiChild(instancia);
            instancia.Show();    
        }
        void enfocaRegistroAnterior()
        {
            int indice = gridControl.CurrentRow.Index;
            //OnCargar();
            OnBuscar();
            if (indice > 0)
            {
                gridControl.MasterView.Rows[indice - 1].IsSelected = true;
                gridControl.MasterView.Rows[indice - 1].IsCurrent = true;
            }
        }
        protected override void OnEliminar()
        {
            if (this.gridControl.RowCount == 0)
                return;

            try
            {
                double CanMovimientos = 0;
                string codigoArticulo = this.gridControl.CurrentRow.Cells["IN01KEY"].Value.ToString();
                ArticuloLogic.Instance.TraerMovimientoxArticulo(Logueo.CodigoEmpresa, Logueo.Anio, codigoArticulo, out CanMovimientos);
                if (CanMovimientos > 0)
                {
                    RadMessageBox.Show("No se puede eliminar un articulo que tiene movimientos", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, 
                                                          MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string msgRetorno = string.Empty;
                    string codigoarticulo = string.Empty;
                    codigoarticulo = this.gridControl.CurrentRow.Cells["IN01KEY"].Value.ToString();

                    Articulo articulo = new Articulo();
                    articulo.IN01CODEMP=Logueo.CodigoEmpresa;
                    articulo.IN01AA=Logueo.Anio;
                    articulo.IN01KEY = codigoarticulo;
                  
                    ArticuloLogic.Instance.ArticuloEliminar(articulo,"N",Logueo.Mes,out msgRetorno);
                    RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);
                    enfocaRegistroAnterior();
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, 
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
            }


        }

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.IsLoaded) {
                if (gridControl.RowCount > 0) {
                    if (e.Row.Cells["IN01KEY"].Value != null) {
                        OnVer();
                    }
                }
            }
        }

        private void gridControl_FilterChanged(object sender, 
            Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            var instancia = FrmArticuloDet.Instance(this);
            //inicializo mi variable de posicion  desde 0 para el nnuevo grupo de filas filtradas.
            instancia.pos = 0;
            //verifico si el filtro entrega datos despues de fitlrar
            if (gridControl.ChildRows.Count > 0)
            {
                //comparo si es filtrado o no 
                //enfoco al primero registro del resultado filtrado o no filtrado.

                if (gridControl.Rows.Count == gridControl.ChildRows.Count)
                {

                    gridControl.Rows[0].IsCurrent = true;
                    gridControl.Rows[0].IsSelected = true;
                }
                else
                {
                    gridControl.ChildRows[0].IsCurrent = true;
                    gridControl.ChildRows[0].IsSelected = true;
                }
            }

        }
 

    }

}
