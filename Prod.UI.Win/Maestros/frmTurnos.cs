﻿using System;
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

namespace Prod.UI.Win
{
    public partial class frmTurnos : frmBaseMante
    {
        Turnos turnos;
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
        RadCommandBarBaseItem cbbExportarMovimientos;
        protected override void OnNuevo()
        {
            limpiar();
            HabilitarControles(true);
            //HabilitarBotones(false, false, false, true, true, false);
            ComportarmientoBotones("nuevo");
            string codigo = string.Empty;
            TurnosLogic.Instance.TurnosTraeCodigo(Logueo.CodigoEmpresa, out codigo);
            this.txtCodigo.Text = codigo;

            this.Estado = FormEstate.New;
        }
        protected override void OnEditar()
        {
            HabilitarControles(true);
            //HabilitarBotones(false, false, false, true, true, false);
            ComportarmientoBotones("editar");
            this.Estado = FormEstate.Edit;
        }
        protected override void OnEliminar()
        {
            turnos  = new Turnos();
            turnos.codigoEmpresa = Logueo.CodigoEmpresa;
            turnos.codigo = this.txtCodigo.Text.Trim();
            
            string mensaje = string.Empty;
            TurnosLogic.Instance.TurnosEliminar(turnos, out mensaje);
            RadMessageBox.Show(mensaje, "sistema", 
                                MessageBoxButtons.OK, RadMessageIcon.Info);
            OnCancelar();
        }
        private bool Validar() 
        {
            if (txtCodigo.Text.Trim() == "")
            {
                RadMessageBox.Show("Ingresar codigo de turno", "Sistema",
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            if (txtDescripcion.Text.Trim() == "") {
                RadMessageBox.Show("Ingresar descripcion de turno", "Sistema", 
                                    MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            return true;
        }
        protected override void OnGuardar()
        {
            if (!Validar()) return;
            turnos = new Turnos();
            turnos.codigoEmpresa = Logueo.CodigoEmpresa;
            turnos.codigo = this.txtCodigo.Text.Trim();

            turnos.horainicio = this.txtHoraInicio.Text;
            turnos.horafin = this.txtHoraFin.Text;
            turnos.horainicioextra = this.txtHoraInicioExt.Text;
            turnos.horafinextra = this.txtHoraFinExt.Text;
            turnos.descripcion = this.txtDescripcion.Text.Trim();
            string mensaje = string.Empty;
            if (this.Estado == FormEstate.New)
            {
                TurnosLogic.Instance.TurnosInsertar(turnos, out mensaje);
            }
            else if(this.Estado == FormEstate.Edit){
                TurnosLogic.Instance.TurnosActualizar(turnos, out mensaje);
            }
            
            RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
            ComportarmientoBotones("grabar");
            OnCancelar();
        }
        private void limpiar() 
        {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtHoraInicio.Text = "00:00";
            this.txtHoraFin.Text = "00:00";
            this.txtHoraInicioExt.Text = "00:00";
            this.txtHoraFinExt.Text = "00:00";
            
        }
        protected override void OnCancelar()
        {
            HabilitarControles(false);
           //HabilitarBotones(true, true, true, false, false, false);
            limpiar();
            OnBuscar();
            ComportarmientoBotones("cancelar");
            this.Estado = FormEstate.List;
        }
        void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "codigoEmpresa", "codigoEmpresa", 0, "", 70, true, 
                            false, false);
            CreateGridColumn(Grid, "Codigo", "codigo", 0, "", 70);
            CreateGridColumn(Grid, "Descripcion", "descripcion", 0, "", 200, true, false, false);
            CreateGridColumn(Grid, "Descripcion", "descripcioncompleto", 0, "", 200);
            CreateGridColumn(Grid, "H.Inicio", "horainicio", 0, "", 70);
            CreateGridColumn(Grid, "H.Fin", "horafin", 0, "", 70);
            CreateGridColumn(Grid, "H.InicioExtra", "horainicioextra", 0, "", 70);
            CreateGridColumn(Grid, "H.FinExtra", "horafinextra", 0, "", 70);
        }
        protected override void OnBuscar()
        {
            var lista = TurnosLogic.Instance.TurnosListar(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        void IniciarFormulario() {
            HabilitarBotones(true, true, true, false, false, false);
            HabilitarControles(false);          
            this.txtHoraInicio.MaskType = MaskType.DateTime;
            this.txtHoraInicio.Mask = "HH:mm";
            
            this.txtHoraFin.MaskType = MaskType.DateTime;
            this.txtHoraFin.Mask = "HH:mm";

            this.txtHoraInicioExt.MaskType = MaskType.DateTime;
            this.txtHoraInicioExt.Mask = "HH:mm";

            this.txtHoraFinExt.MaskType = MaskType.DateTime;
            this.txtHoraFinExt.Mask = "HH:mm";
            this.Estado = FormEstate.List;
        }
        void HabilitarControles(bool valor) {
            this.txtCodigo.Enabled = false;
            this.txtDescripcion.Enabled = valor;
            txtHoraInicio.Enabled = valor;
            txtHoraFin.Enabled = valor;
            txtHoraInicioExt.Enabled = valor;
            txtHoraFinExt.Enabled = valor;
            //this.dtpHoraInicio.Enabled = valor;
            //this.dtpHoraFin.Enabled = valor;
            //this.dtpHoraInicioExt.Enabled = valor;
            //this.dtpHoraFinExt.Enabled = valor;
            
        }
        private frmMDI FrmParent { get; set; }
        private static frmTurnos _aForm;
        public static frmTurnos Instance(frmMDI mdiPrincipal) 
        {
            if (_aForm != null) return new frmTurnos(mdiPrincipal);
            _aForm = new frmTurnos(mdiPrincipal);
            return _aForm;
        }
        public frmTurnos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
            CrearColumnas();
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
            cbbExportarMovimientos = menu.Items["cbbExportarMovimientos"];
            accesobtonesxperfil();
            OnBuscar();
            ComportarmientoBotones("cargar");
        }
        private void accesobtonesxperfil() {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.codModulo, this.Name, out nuevo_a, out editar_a,
                out eliminar_a, out ver_a, out imprimir_a, out refrescar_a, out importar_a, out vista_a,
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

        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                if (e.CurrentRow != null)
                {                   
                    //var registro = TurnosLogic.Instance.TurnosTraerRegistro(Logueo.CodigoEmpresa, txtCodigo.Text);
                    
                    this.txtCodigo.Text = e.CurrentRow.Cells["codigo"].Value.ToString();
                    this.txtDescripcion.Text = e.CurrentRow.Cells["descripcion"].Value.ToString();
                                        
                    this.txtHoraInicio.Text = e.CurrentRow.Cells["horainicio"].Value.ToString();

                    this.txtHoraFin.Text = e.CurrentRow.Cells["horafin"].Value.ToString();
                    
                    this.txtHoraInicioExt.Text = e.CurrentRow.Cells["horainicioextra"].Value.ToString();
                    
                    this.txtHoraFinExt.Text = e.CurrentRow.Cells["horafinextra"].Value.ToString();
                }
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
            }
        }
    }
}
