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
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using System.IO;
using System.IO.Compression;

namespace Com.UI.Win
{
    public partial class frmProveedor : frmBaseMante
    {

        private static frmProveedor _aForm;
        private frmMDI FrmParent { get; set; }

        public static frmProveedor Instance(frmMDI padre) {
            if (_aForm != null) return new frmProveedor(padre);
            _aForm = new frmProveedor(padre);
            return _aForm;

        }
        ComprasCuentaCorrienteLogic datos = ComprasCuentaCorrienteLogic.Instance;
        public frmProveedor(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }
        /*txtTipoAnalisis = fCuentaCorriente.dcCtaCte.Resultset("ccm02tipana")
    
    
    
    txtcodigo = fCuentaCorriente.dcCtaCte.Resultset("ccm02cod")
    txtNombre = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02nom"))
    txtDireccion = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02dir"))

    
    mskTelefono.Mask = "": mskTelefono = "": mskTelefono.Mask = "###-####---###-####---###-####---###-####---###-####"
    mskTelefono.SelText = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02tel"))
    
    chkHabilitar.Value = IIf(fCuentaCorriente.dcCtaCte.Resultset("ccm02activo") = "N", 0, 1)
        
    mskFecha.Mask = ""
    If IsNull(fCuentaCorriente.dcCtaCte.Resultset("ccm02fec")) Then
        mskFecha = ""
    Else
        mskFecha = Format(fCuentaCorriente.dcCtaCte.Resultset("ccm02fec"), "dd/mm/yyyy")
    End If
    mskFecha.Mask = "##/##/####"
    txtRuc = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02ruc"))
    MskFax.Mask = "": MskFax = "": MskFax.Mask = "###-####---###-####---###-####---###-####---###-####"
    MskFax.SelText = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02Fax"))

    txtCorreoElectronico = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02correo"))
    txtCorreoDocEle = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02CorreoFacturaElectronica"))
    TxtRubro = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02rubpro"))
    txtAtencion = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02Aten"))
    
    TxtFormaPago = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02ForPag"))
    lblFormaPago(0) = DameDescripcion(gbCodEmpresa & TxtFormaPago, "FORPAG")
    
    txtsituacionsunat = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02EstadoContribuyente"))
    lblFormaPago(1) = DameDescripcion("07" & Trim(txtsituacionsunat.Text), "GL")
    
    txtsituaciondomicilio = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02SituacionDomicilio"))
    lblFormaPago(2) = DameDescripcion("08" & Trim(txtsituaciondomicilio.Text), "GL")
    
    txtpais = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02paiscodigo"))
    lblpais(0) = DameDescripcion("35" & Trim(txtpais.Text), "GLO02")

    OptMoneda(0).Value = (aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02Moneda")) = "S")
    OptMoneda(1).Value = (aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02Moneda")) = "D")
    
    
    
    chktiposunat(0).Value = IIf(Mid(aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02TipoAgenteRetencion")), 1, 1) = "1", 1, 0)
    chktiposunat(1).Value = IIf(Mid(aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02TipoAgenteRetencion")), 2, 1) = "1", 1, 0)
    chktiposunat(2).Value = IIf(Mid(aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02TipoAgenteRetencion")), 3, 1) = "1", 1, 0)
    chktiposunat(3).Value = IIf(Mid(aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02TipoAgenteRetencion")), 4, 1) = "1", 1, 0)
    
    If aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02TipoRuc")) = "1" Then
        optTipoPersona(1).Value = True
    ElseIf aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02TipoRuc")) = "2" Then
         optTipoPersona(2).Value = True
    ElseIf aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02TipoRuc")) = "3" Then
        optTipoPersona(3).Value = True
    Else
        optTipoPersona(1).Value = False
        optTipoPersona(2).Value = False
        optTipoPersona(3).Value = False
    End If
    
    txtNom = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02Nombres"))
    txtApePat = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02ApePaterno"))
    txtApeMat = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02ApeMaterno"))
    txtctabancodetraccion.Mask = "##-###-######"
    txtctabancodetraccion.SelText = aTexto(fCuentaCorriente.dcCtaCte.Resultset("ccm02nroctadetraccion"))
    *
         
         
         */
        private void CrearColumnas() {
            RadGridView Grid = CreateGridVista(gridControl);
            bool VisibleNo = false, LecturaSi = true;
            bool EditableNo = false;

            CreateGridColumn(Grid, "Doc Identidad ", "ccm02tipdocidentidad", 0, "", 70, LecturaSi, EditableNo, true);
            CreateGridColumn(Grid, "Código", "ccm02cod", 0, "", 90);
            CreateGridColumn(Grid, "Nombre", "ccm02nom", 0, "", 300);
            CreateGridColumn(Grid, "R.U.C.", "ccm02ruc", 0, "", 100);
            CreateGridColumn(Grid, "Direccion", "ccm02dir", 0, "", 250);
            CreateGridColumn(Grid, "ccm02rubpro", "ccm02rubpro", 0, "", 150, LecturaSi, EditableNo, true);
            CreateGridColumn(Grid, "Contacto", "ccm02Aten", 0, "", 150, LecturaSi, EditableNo, true);
            CreateGridColumn(Grid, "Telefono", "ccm02tel", 0, "", 100, LecturaSi, EditableNo, true);
            CreateGridColumn(Grid, "Correo", "ccm02correo", 0, "", 120, LecturaSi, EditableNo, true);

            CreateGridColumn(Grid, "ccm02tipana", "ccm02tipana", 0, "", 70, LecturaSi, EditableNo,VisibleNo);
            CreateGridColumn(Grid, "ccm02activo", "ccm02activo", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02fec", "ccm02fec", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02Fax", "ccm02Fax", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02CorreoFacturaElectronica", "ccm02CorreoFacturaElectronica", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02TipoRuc", "ccm02TipoRuc", 0, "", 70, LecturaSi, EditableNo, false);
            CreateGridColumn(Grid, "ccm02ForPag", "ccm02ForPag", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02EstadoContribuyente", "ccm02EstadoContribuyente", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02SituacionDomicilio", "ccm02SituacionDomicilio", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02paiscodigo", "ccm02paiscodigo", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02Moneda", "ccm02Moneda", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02TipoAgenteRetencion", "ccm02TipoAgenteRetencion", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02Nombres", "ccm02Nombres", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02ApePaterno", "ccm02ApePaterno", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02ApeMaterno", "ccm02ApeMaterno", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            CreateGridColumn(Grid, "ccm02nroctadetraccion", "ccm02nroctadetraccion", 0, "", 70, LecturaSi, EditableNo, VisibleNo);
            
            //Actualizacion de proveedores
            RadGridView GridActualiza = CreateGridVista(gridActualizaProveedor);
            CreateGridColumn(GridActualiza, "Fecha", "cod_actualizacion", 0, "", 90, true, false, true);
            CreateGridColumn(GridActualiza, "Usuario","usuario" , 0, "", 120, true, false, true);
            CreateGridColumn(GridActualiza, "Estado", "estado", 0, "", 120, true, false, false);
                
                    
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Cargar();

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbImprimir);

            BotonesAsignarToolTip("imprimir", "Actualizar Proveedor");
            BotonAsignarImagen("imprimir");
            VerActualizacionProveedor(false);

       }
        private void AbrirFormulario() {
            var frmInstance = frmProveedorDetalle.Instance(this);
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedorDetalle);
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
        internal void Cargar() {
             List<CuentaCorriente> lista =  datos.Traer(Logueo.CodigoEmpresa, "02", "*", "");
             gridControl.DataSource = lista;
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            AbrirFormulario();
        }

        protected override void OnEditar()
        {

            Estado = FormEstate.Edit;
            AbrirFormulario();
        }

        protected override void OnEliminar()
        {
            if (this.gridControl.Rows.Count == 0) return;
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (respuesta == false) return;

                Cursor.Current = Cursors.WaitCursor;

                int flag = 0; string mensaje = "", tipoAnalisis = "", codigo = "";
                tipoAnalisis = Util.GetCurrentCellText(gridControl.CurrentRow, "ccm02tipana");
                codigo = Util.GetCurrentCellText(gridControl.CurrentRow, "ccm02cod");


                CuentaCorrienteLogic.Instance.ComprasEliminarCuentaCorriente(Logueo.CodigoEmpresa, tipoAnalisis, codigo, out flag, out mensaje);
                //datosCtacte.ComprasEliminarCuentaCorriente(Logueo.CodigoEmpresa, txtCodTipAnalisis.Text.Trim(),
                //    txtCodigo.Text.Trim(), out flag, out mensaje);
                Util.ShowMessage(mensaje, flag);
                if (flag == 1)
                {
                    Cargar();
                    
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al elimianr");
            }
        }

     protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                DataTable dt = CuentaCorrienteLogic.Instance.ComprasTraeRepCuentaCorriente(Logueo.CodigoEmpresa,
                              "02", "*", "");
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = "RptCuentaCorriente.rpt";
                reporte.DataSource = dt;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);

            }
            catch (Exception ex) {
                Util.ShowAlert("Error al generar reporte");
            }

            Cursor.Current = Cursors.Default;
        }
        //Abre actualizacion de proveedor
        protected override void OnImprimir()
        {
            if (gridControl.Rows.Count == 0) {
                Util.ShowAlert("Debe tener proveedor para actualizar");
                return;
            }
            
            VerActualizacionProveedor(true);
        }


        private void VerActualizacionProveedor(bool estado) {
            if (estado == true)
            {
                this.gpxProveedor.BringToFront();
                this.gpxProveedor.Visible = estado;
                rbComprasPeriodo.Checked = true;
            }
            else {
                this.gpxProveedor.SendToBack();
                this.gpxProveedor.Visible = estado;
            }
            

        }

        private void cbbVistaPreviaActProv_Click(object sender, EventArgs e)
        {

        }

        private void cbbSalirActProv_Click(object sender, EventArgs e)
        {
            VerActualizacionProveedor(false);
        }
        private void VerRegistro() { 
            
        }
        
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.Rows.Count == 0) return;

            Estado = FormEstate.View;
            AbrirFormulario();
        }

        private void TraerProvSunat(string opcion) {
            List<ProveedoresSunat> lista = 
            ProveedorLogic.Instance.TraerProveedorSunat(Logueo.CodigoEmpresa, 
                                            Logueo.Anio, Logueo.Mes, opcion);
            this.gridActualizaProveedor.DataSource = lista;

        }

        private void rbComprasPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbComprasPeriodo.Checked) {
                TraerProvSunat("1");
            }
            
        }

        private void rbTrabajadores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrabajadores.Checked) {
                TraerProvSunat("2");
            }
            
        }

        //public bool EsperaPorProceso(long taskid, long msecs = -1)
        //{
        //    long procHandle;
        //    procHandle = OpenProcess(0x100000, true, taskid);
        //    EsperaPorProceso = WaitForSingleObject(procHandle, msecs) != -1;
        //    CloseHandle(procHandle);
        //}
        //Comprime el archivo de txt en zip para enviar aun destino 
        private void ComprimirArchivos(string ruta, string archivoNombre)
        {
            string ejecutableZip = "";
            string origen = "", destino = "";
            origen = System.IO.Path.Combine(ruta, archivoNombre + ".txt");
            destino = System.IO.Path.Combine(ruta, archivoNombre);
            try
            {
                if (File.Exists(destino)) {
                    File.Delete(destino);
                }
                
            }
            catch (Exception ex) {
                Util.ShowAlert("Error al comprimir archivos");
            }
        }

        private void DescomprimirArchivos(string ruta, string archivoNombre) {
            try
            {

            }catch (Exception ex) { 
                
            }
        }

        private void InsertoProveedores(string codActualizacion, string flag) {


          gridActualizaProveedor.DataSource =  ProveedorLogic.Instance.ComprasTraeValidacionSunat(Logueo.CodigoEmpresa, 
                                                        codActualizacion, Logueo.Anio, Logueo.Mes, flag);


        }

        private void InsertaTabla(string nombreArchivo) { 
        
            //Abrir archivo
            //Cargar barra de progreso

            try
            {

            }
            catch (Exception ex) { 
            
            }
        }

    }
}
