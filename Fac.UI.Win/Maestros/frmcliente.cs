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
    public partial class frmcliente : frmBase
    {
        #region "Instancia"
        private static frmcliente _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmcliente Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmcliente(formParent);
            _aForm = new frmcliente(formParent);
            return _aForm;
        }

        CuentaCorrienteLogic datos = CuentaCorrienteLogic.Instance;
        internal string ClienteCodigo = "";
        #endregion
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

        public frmcliente(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
        }
        public void Cargar()
        {             
            List<CuentaCorriente> lista = datos.TraeCliente(Logueo.CodigoEmpresa, "01", "ccm02cod", "*");
            this.gridControl.DataSource = lista;
        }

        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridControl);

            CreateGridColumn(gridControl, "ccm02emp","ccm02emp", 0, "", 80, true, false, false);
            
            CreateGridColumn(gridControl, "Tip.Analisis", "ccm02tipana",0, "", 70);
            CreateGridColumn(gridControl, "Codigo", "ccm02cod", 0, "", 90);
            CreateGridColumn(gridControl, "Nombre", "ccm02nom", 0, "", 420);
            CreateGridColumn(gridControl, "Direccion", "ccm02dir", 0, "", 650);      
            // Campos Ocultos
            CreateGridColumn(gridControl, "Telefono", "ccm02tel", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "Fecha", "ccm02fec", 0, "{0:dd/MM/yyyy}", 70);

            // Descripcion de los campos                     
            CreateGridColumn(gridControl, "PaisCod", "ccm02FEPaisCod", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "PaisDescripcion", "PaisDescripcion", 0, "", 70, true, false, false);

            CreateGridColumn(gridControl, "DepartamentoCod", "ccm02FEDepartamentoCod", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "DepaDescrpicion", "DepaDescrpicion", 0, "", 70, true, false, false);

            CreateGridColumn(gridControl, "ProvinciaCod", "ccm02FEProvinciaCod", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "ProviDescripcion", "ProviDescripcion", 0, "", 70, true, false, false);

            CreateGridColumn(gridControl, "DistritoCod", "ccm02FEDistritoCod", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "DisDescripcion", "DisDescripcion", 0, "", 70, true, false, false);



            CreateGridColumn(gridControl, "TipIdentidadCod", "ccm02tipdocidentidad", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "TipDocDesc", "TipDocDesc", 0, "", 120, true, false, false);

            CreateGridColumn(gridControl, "Ruc", "ccm02ruc", 0, "", 70, true, false, false);

            CreateGridColumn(gridControl, "Fax", "ccm02Fax", 0, "", 70, true, false, false);

            CreateGridColumn(gridControl, "Correo", "ccm02correo", 0, "", 100, true, false, false);

            CreateGridColumn(gridControl, "RubPro", "ccm02rubpro", 0, "", 70, true, false, false);

            CreateGridColumn(gridControl, "Atencion", "ccm02Aten", 0, "", 120, true, false, false);

            CreateGridColumn(gridControl, "FormaPago", "ccm02ForPag", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "FormaPagoDesc.", "Co02descripcion", 0, "", 120, true, false, false);

            CreateGridColumn(gridControl, "SunatCod", "ccm02EstadoContribuyente", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "SunatDesc", "SituacionSunatDesc",0, "", 120, true, false, false);

            CreateGridColumn(gridControl, "DomicilioCod", "ccm02SituacionDomicilio", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "DomicilioDesc", "SituacionDomicilioDesc", 0, "", 120, true, false, false);
            
            CreateGridColumn(gridControl, "Moneda", "ccm02Moneda", 0, "", 70, true, false, false);
            CreateGridColumn(gridControl, "T.AgenteRetencion", "ccm02TipoAgenteRetencion", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "T.Ruc", "ccm02TipoRuc", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "Nombres", "ccm02Nombres", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "Ap.Paterno", "ccm02ApePaterno", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "Ape.Materno", "ccm02ApeMaterno", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "CorreoFactura", "ccm02CorreoFacturaElectronica", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "Urbanizacion", "ccm02FEUrbanizacion", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "CCM02TIPOCLIENTECOD", "CCM02TIPOCLIENTECOD", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "CCM02TIPOCLIENTEDESC", "CCM02TIPOCLIENTEDESC", 0, "", 120, true, false, false);

            CreateGridColumn(gridControl, "ccm02LineaCreditoMoneda", "ccm02LineaCreditoMoneda", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "ccm02LineaCreditoImporteSolicitado", "ccm02LineaCreditoImporteSolicitado", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "ccm02LineaCreditoImporteConcedido", "ccm02LineaCreditoImporteConcedido", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "ccm02LineaCreditoCondicionPago", "ccm02LineaCreditoCondicionPago", 0, "", 120, true, false, false);
            CreateGridColumn(gridControl, "ccm02FlagDescripcionCliente", "ccm02FlagDescripcionCliente", 0, "", 120, true, false, false);
                
        }

        private void AbrirFormulario(FormEstate pEstado)
        {
            try
            {
                var instancia = frmClienteDet.Instance(this);

                var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmClienteDet);
                if (frmexiste != null) { instancia.BringToFront(); return; }

                //instancia del  formulario
                instancia.Estado = pEstado;
                instancia.MdiParent = this.ParentForm;
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                ((RadDock)(ctrl)).ActivateMdiChild(instancia);
                instancia.Show();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al abrir formulario: " + ex.Message);
            }
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            AbrirFormulario(FormEstate.New);
        }
        protected override void OnEditar()
        {
            
            if (gridControl.RowCount == 0) return;
            Estado = FormEstate.Edit;
            ClienteCodigo = Util.GetCurrentCellText(gridControl, "ccm02cod");
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
                string ClienteCodigo = "", TipoAnalisis = "";                

                ClienteCodigo = Util.GetCurrentCellText(gridControl, "ccm02cod");
                TipoAnalisis =    Util.GetCurrentCellText(gridControl,"ccm02tipana");
                datos.EliminarCliente(Logueo.CodigoEmpresa, TipoAnalisis, ClienteCodigo, 
                                        out int_flag, out str_mensaje);
                if (int_flag == 1)
                {
                    Cargar();
                }
                else {
                    Util.ShowAlert(str_mensaje);
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al elininar cliente: " + ex.Message);
            }
        }
        protected override void OnVer()
        {
            if (gridControl.RowCount == 0) return;
            Estado = FormEstate.View;
            ClienteCodigo = Util.GetCurrentCellText(gridControl, "ccm02cod");
            AbrirFormulario(FormEstate.View);
        }
        private void frmcliente_Load(object sender, EventArgs e)
        {
            try
            {
                CrearColumnas();
                Cargar();
                accesobotonesperfil();
                ComportarmientoBotones("cargar");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.Rows.Count == 0)
            {

                Util.ShowAlert("No tiene registro para seleccionar");
                return;
            }
            OnVer();
            
        }
    }
}
