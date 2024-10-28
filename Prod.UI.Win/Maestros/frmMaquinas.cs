using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
using Prod.UI.Win.Comunes;
namespace Prod.UI.Win.Maestros
{
    public partial class frmMaquinas : frmBaseMante
    {
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importarMP;
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
        
        private frmMDI FrmParent { get; set; }
        private static frmMaquinas _aForm;
        public static frmMaquinas Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmMaquinas(mdiPrincipal);
            _aForm = new frmMaquinas(mdiPrincipal);
            return _aForm;
        }
       
        Maquina maquina = new Maquina();
        void crearColumnas()
        {
            RadGridView grilla = CreateGridVista(this.gridControl);
            //PRO11CODEMP, PRO11COD, PRO11DESC
            this.CreateGridColumn(grilla, "codigoEmpresa", "codigoEmpresa", 0, "", 30, true, false, false);
            this.CreateGridColumn(grilla, "Codigo", "codigo", 0, "", 150);
            this.CreateGridColumn(grilla, "Descripcion", "descripcion", 0, "", 300);
            this.CreateGridColumn(grilla, "Act.Relacionada", "actrelacionada", 0, "", 120, true, false, false);
            this.CreateGridColumn(grilla, "Act.Relacionada", "descactrelacionada", 0, "", 120);
        }
        public frmMaquinas(frmMDI padre) 
        {
            InitializeComponent();
            FrmParent = padre;
            crearColumnas();
            OnBuscar();
            //HabilitarBotones(true, true, true, false, false, false);
            HabilitaControles(false);
            menu = radCommandBar1.CommandBarElement.Rows[0].Strips[0];
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
            accesobtonesxperfil();
            ComportarmientoBotones("cargar");
        }
        private void ComportarmientoBotones(string accion)
        {

            switch (accion)
            {
                case "cargar":
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
                    break;
            }

        }
        private void accesobtonesxperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, 
                                                                    out nuevo_a, out editar_a, out eliminar_a, 
                                                                    out ver_a, out imprimir_a, out refrescar_a, 
                                                                    out importar_a, out vista_a, out guardar_a,
                                                                    out cancelar_a, out expmovi_a, out importarMP);
        }
        void HabilitaControles(bool valor) 
        {
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = valor;
            txtCodActividad.Enabled = valor;
            txtDesActividad.Enabled = false;
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            limpiar();
            string codigo = string.Empty;
            MaquinaLogic.Instance.MaquinaTraerCodigo(Logueo.CodigoEmpresa, out codigo);
            txtCodigo.Text = codigo;
            HabilitarBotones(false, false, false, true, true, false);
            HabilitaControles(true);
        }

        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            HabilitarBotones(false, false, false, true, true,false);
            HabilitaControles(true);
        }

        protected override void OnBuscar()
        {
            var lista = MaquinaLogic.Instance.MaquinaTraer(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        protected override void OnEliminar()
        {
           cargarEntidad();
            string mensaje = string.Empty;
            Estado = FormEstate.List;
            DialogResult res = RadMessageBox.Show("¿Desea eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes) 
            {
                MaquinaLogic.Instance.MaquinaEliminar(maquina, out mensaje);
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            OnCancelar();
            Util.enfocarFila(gridControl, "codigo", maquina.codigo);
        }
        void limpiar() {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtCodActividad.Text = "";
            this.txtDesActividad.Text = "";
        }
        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            HabilitarBotones(true, true, true, false, false, false);
            limpiar();
            OnBuscar();
            HabilitaControles(false);
        }
        void cargarEntidad() 
        {
            maquina = new Maquina();
            maquina.codigoEmpresa = Logueo.CodigoEmpresa;
            maquina.codigo = txtCodigo.Text.Trim();
            maquina.descripcion = txtDescripcion.Text.Trim();
            maquina.actrelacionada = txtCodActividad.Text.Trim();
        }
        bool Validar() {
            if (txtDescripcion.Text.Length == 0 || txtDescripcion.Text == "")
            {
                RadMessageBox.Show("Ingresar descripcion", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            return true;
        }
        
        protected override void OnGuardar()
        {
            if(!Validar()) return;
            cargarEntidad();
            string mensaje = string.Empty;
            if (Estado == FormEstate.New) 
            {
                MaquinaLogic.Instance.MaquinaInsertar(maquina, out mensaje);
                Estado = FormEstate.List;
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            else if (Estado == FormEstate.Edit)
            {

                MaquinaLogic.Instance.MaquinaActualizar(maquina, out mensaje);
                Estado = FormEstate.List;
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            else {
                RadMessageBox.Show("Opcion no valido", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
           
            OnCancelar();
            OnBuscar();
            Util.enfocarFila(gridControl, "codigo", maquina.codigo);
        }

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow == null) return;
            if(e.CurrentRow.Cells["codigo"] == null ) return;
            string codigo = e.CurrentRow.Cells["codigo"].Value.ToString();
            var dato = MaquinaLogic.Instance.TraerMaquinaRegistro(Logueo.CodigoEmpresa, codigo);
            txtCodigo.Text = dato.codigo;
            txtDescripcion.Text = dato.descripcion;
            txtCodActividad.Text = dato.actrelacionada;
        }

        private void txtCodActividad_KeyDown(object sender, KeyEventArgs e)
        {
            frmBusqueda frm;
             string codigo = "";
            if (e.KeyValue == (char)Keys.F1) {
                frm = new frmBusqueda(enmAyuda.enmActividadesRelacionadas);
                frm.ShowDialog();
                if (frm.Result != null) 
                     codigo = frm.Result.ToString();
                if (codigo != "")

                    this.txtCodActividad.Text = codigo;
                       
                
            }

        }

        private void txtCodActividad_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCodActividad.Text != "")
            {
                string descripcion = string.Empty;
                GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtCodActividad.Text.Trim(), "ACTIVIDADNIVEL1", out descripcion);
                this.txtDesActividad.Text = descripcion;
            }
            else {
                txtDesActividad.Text = string.Empty;
            }
            
        }

    }
}
