using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using System;

namespace Fac.UI.Win
{
    public partial class frmNotaCreYNotDeb : frmBaseDocumento
    {
        TipoDocumentoLogic datos = TipoDocumentoLogic.Instance;
        private static frmNotaCreYNotDeb _aForm;
        private frmListaDocumentos FrmParent { get; set; }

        public static frmNotaCreYNotDeb Instance(frmListaDocumentos padre)
        {
            if (_aForm != null) return new frmNotaCreYNotDeb(padre);
            _aForm = new frmNotaCreYNotDeb(padre);
            return _aForm;
        }
        public frmNotaCreYNotDeb(frmListaDocumentos padre)
        {
            InitializeComponent();
            FrmParent = padre;
            this.gridControl.CellDoubleClick += new GridViewCellEventHandler(gridControl_CellDoubleClick);
            this.gridControl.KeyDown += new KeyEventHandler(gridControl_KeyDown);
        }
        internal bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
           cancelar_a, expmovi_a;
        #region "Seguridad"

        private void ComportarmientoBotones(string accion)
        {
            OcultarBotones();
            //leer variables boolean de frmListaDocumentos
            this.nuevo_a = FrmParent.nuevo_a;
            this.editar_a = FrmParent.editar_a;
            this.eliminar_a = FrmParent.eliminar_a;
            this.ver_a = FrmParent.ver_a;
            this.imprimir_a = FrmParent.imprimir_a;
            this.refrescar_a = FrmParent.refrescar_a;
            this.importar_a = FrmParent.importar_a;
            this.vista_a = FrmParent.vista_a;
            this.guardar_a = FrmParent.guardar_a;
            this.cancelar_a = FrmParent.cancelar_a;
            this.expmovi_a = FrmParent.expmovi_a;
            switch (accion)
            {
                case "cargar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    if (ver_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVer); }
                    //if (vista_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbvi
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
        void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridControl.Rows.Count == 0) { Util.ShowAlert("No tiene registro para seleccionar"); return; }
            OnVer();
            
        }

        void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.Rows.Count == 0) { Util.ShowAlert("No tiene registro para seleccionar"); return; }
            //OnVer();
            OnEditar();
        }
        void CrearColumnas()
        {
            bool bVisibleON = true, bVisibleOFF = false, bEditableON = true, bEditableOFF = false,
                     bReadOnlyON = true, bReadOnlyOFF = false;
            RadGridView Grid = CreateGridVista(gridControl);


            CreateGridColumn(Grid, "Cliente", "ClienteNombre", 0, "", 150);
            CreateGridColumn(Grid, "Fecha", "FAC04FECHA", 0, "{0:dd/MM/yyyy}", 120, bReadOnlyON, bEditableOFF, bVisibleON); //datetime
            CreateGridColumn(Grid, "Nro", "FAC04NUMDOC", 0, "", 90); // varchar
            CreateGridColumn(Grid, "Descripcion", "FAC03DESC", 0, "", 200);            
            CreateGridColumn(Grid, "SubTotal", "FAC04IMPSUBTOTAL", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleON, true, "right"); //float        		
            CreateGridColumn(Grid, "IGV", "FAC04IMPIGV", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleON, true, "right"); // float
            CreateGridColumn(Grid, "Total", "FAC04IMPTOTAL", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleON, true, "right"); // float
            //Estado Proceso
            CreateGridColumn(Grid, "Estado Proceso", "EstadoProcesoBizlink", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleON);
            // Estado SUNAT
            CreateGridColumn(Grid, "Estado SUNAT", "EstadoProcesoSUNAT", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleON);

            // Resumen
            CreateGridColumn(Grid, "Resumen", "EstadoResumen", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleON);//varchar(200)
     

            CreateGridColumn(Grid, "FAC04TIPANA", "FAC04TIPANA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04CODEMP", "FAC04CODEMP", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC01COD", "FAC01COD", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04AA", "FAC04AA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(4)
            CreateGridColumn(Grid, "FAC04MM", "FAC04MM", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04NRODOC", "FAC04NRODOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(15)
            CreateGridColumn(Grid, "FAC04SERIEDOC", "FAC04SERIEDOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(5)

            CreateGridColumn(Grid, "FAC04CODCLI", "FAC04CODCLI", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(11)
            CreateGridColumn(Grid, "FAC04MONEDA", "FAC04MONEDA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04TIPCAMBIO", "FAC04TIPCAMBIO", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04DONSUBTOTAL", "FAC04DONSUBTOTAL", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04DONIGV", "FAC04DONIGV", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04DONTOTAL", "FAC04DONTOTAL", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC03COD", "FAC03COD", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC02COD", "FAC02COD", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04CLINOMBRE", "FAC04CLINOMBRE", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(100)
            CreateGridColumn(Grid, "FAC04CLIDIRECCION", "FAC04CLIDIRECCION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(100)
            CreateGridColumn(Grid, "FAC04CLIRUC", "FAC04CLIRUC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(11)
            CreateGridColumn(Grid, "FAC04GLOSA", "FAC04GLOSA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(100)
            CreateGridColumn(Grid, "FAC04DONGLAG", "FAC04DONGLAG", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(1)
            CreateGridColumn(Grid, "FAC04IGV", "FAC04IGV", 0, "{0:###,###0.00}", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04GUIAS", "FAC04GUIAS", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(100)
            CreateGridColumn(Grid, "FAC04DOCMODTIPDOC", "FAC04DOCMODTIPDOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "tipoDocDesc", "FAC01DESC", 0, "", 120, bReadOnlyON, bEditableOFF, bVisibleOFF);// tipoDocDesc
            CreateGridColumn(Grid, "FAC04DOCMODNRO", "FAC04DOCMODNRO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "FAC04DOCMODFECHA", "FAC04DOCMODFECHA", 0, "{0:dd/MM/yyyy}", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//datetime()
            CreateGridColumn(Grid, "FAC03TIPART", "FAC03TIPART", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04TIPMOTEMI", "FAC04TIPMOTEMI", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(1)
            CreateGridColumn(Grid, "FAC04TIPMOTEMIDES", "FAC04TIPMOTEMIDES", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(50)
            CreateGridColumn(Grid, "FAC04ESTADODOC", "FAC04ESTADODOC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(1)
            CreateGridColumn(Grid, "FAC04CONTASIENTOTIPO", "FAC04CONTASIENTOTIPO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(5)
            CreateGridColumn(Grid, "FAC04CONTLIBRO", "FAC04CONTLIBRO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04CONTVOUCHER", "FAC04CONTVOUCHER", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(5)
            CreateGridColumn(Grid, "FAC04ESTADOCONTABLE", "FAC04ESTADOCONTABLE", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(1)
            CreateGridColumn(Grid, "FAC04ATENCIONESGLAG", "FAC04ATENCIONESGLAG", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(1)
            CreateGridColumn(Grid, "FAC04FETIPONOTA", "FAC04FETIPONOTA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "DescMotivoNotaCredito", "DescMotivoNotaCredito", 0, "", 120, true, false, false);
            CreateGridColumn(Grid, "DescMotivoNotaDebito", "DescMotivoNotaDebito", 0, "", 120, true, false, false);
            CreateGridColumn(Grid, "FAC04TIENDA", "FAC04TIENDA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF); // varchar
            CreateGridColumn(Grid, "FAC04TOTALPESO", "FAC04TOTALPESO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);
            // ===============
            CreateGridColumn(Grid, "FAC04EXPCODPAISORIGEN", "FAC04EXPCODPAISORIGEN", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCODPAISDESTINO", "FAC04EXPCODPAISDESTINO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCODCONDPAGO", "FAC04EXPCODCONDPAGO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCODCONDDESPACHO", "FAC04EXPCODCONDDESPACHO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCODPUERTO", "FAC04EXPCODPUERTO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCODBCOLOCAL", "FAC04EXPCODBCOLOCAL", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCDDOCCRED", "FAC04EXPCDDOCCRED", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "FAC04EXPLCEMITIDA", "FAC04EXPLCEMITIDA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "FAC04EXPBANKCODE", "FAC04EXPBANKCODE", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(10)
            CreateGridColumn(Grid, "FAC04EXPNUMCUENTA", "FAC04EXPNUMCUENTA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "FAC04EXPNROCONTAINER", "FAC04EXPNROCONTAINER", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "FAC04EXPNROPRECINTO", "FAC04EXPNROPRECINTO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "FAC04ORDENCOMPRA", "FAC04ORDENCOMPRA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(50)
            CreateGridColumn(Grid, "FAC04CODTIPOVENTA", "FAC04CODTIPOVENTA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCODPUERTODES", "FAC04EXPCODPUERTODES", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04EXPCONOEMBARQUE", "FAC04EXPCONOEMBARQUE", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(20)
            CreateGridColumn(Grid, "FAC04TOTALPESOADUANA", "FAC04TOTALPESOADUANA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()

            CreateGridColumn(Grid, "FAC04TOTALCAJAS", "FAC04TOTALCAJAS", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04TOTALCANTIDAD", "FAC04TOTALCANTIDAD", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FETOTALGRAVADA", "FAC04FETOTALGRAVADA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FETOTALNOGRAVADA", "FAC04FETOTALNOGRAVADA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FETOTALEXONERADA", "FAC04FETOTALEXONERADA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FETOTALGRATUITA", "FAC04FETOTALGRATUITA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FETOTALDESCUENTO", "FAC04FETOTALDESCUENTO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04IMPORTELETRAS", "FAC04IMPORTELETRAS", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(250)
            CreateGridColumn(Grid, "FAC04FETOTALDETRACCION", "FAC04FETOTALDETRACCION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FEVALORREFDETRACCION", "FAC04FEVALORREFDETRACCION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FEPORCEDETRACCION", "FAC04FEPORCEDETRACCION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//float()
            CreateGridColumn(Grid, "FAC04FEDESCDETRACCION", "FAC04FEDESCDETRACCION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(100)
            CreateGridColumn(Grid, "FAC04MOTIVOBAJA", "FAC04MOTIVOBAJA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(200)
            CreateGridColumn(Grid, "FAC04FECHABAJA", "FAC04FECHABAJA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//datetime()
            CreateGridColumn(Grid, "FAC04FERESUMENFECHA", "FAC04FERESUMENFECHA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//datetime()
            CreateGridColumn(Grid, "FAC04FELUGARDESTINO", "FAC04FELUGARDESTINO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//varchar(30)
            CreateGridColumn(Grid, "FAC04ESTADOSUNAT", "FAC04ESTADOSUNAT", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04ESTADODEPROCESO", "FAC04ESTADODEPROCESO", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04FECORDCOMPRA", "FAC04FECORDCOMPRA", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF); // datetime
            CreateGridColumn(Grid, "TipoAnalisisDesc", "TipoAnalisisDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            //CreateGridColumn(Grid, "SubPlantillaDesc", "FAC03DESC", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2) // SubPlantillaDesc
            CreateGridColumn(Grid, "MonedaDesc", "MonedaDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "TiendaDesc", "TiendaDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "PaisOrigenDesc", "PaisOrigenDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "PaisDestinoDesc", "PaisDestinoDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "ExpCondPagoDesc", "ExpCondPagoDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "ExpCodCondDespachoDesc", "ExpCodCondDespachoDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "ExpPuertoEmbarqueDesc", "ExpPuertoEmbarqueDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "ExpPuertoDesembarqueDesc", "ExpPuertoDesembarqueDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "BancoDesc", "BancoDesc", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);//char(2)
            CreateGridColumn(Grid, "FAC04FETIPODEOPERACION", "FAC04FETIPODEOPERACION", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);
            CreateGridColumn(Grid, "FAC04FECODIGOANEXOEMISOR", "FAC04FECODIGOANEXOEMISOR", 0, "", 90, bReadOnlyON, bEditableOFF, bVisibleOFF);            
            
        }
        public void Cargar()
        {
            try
            {
                string codigoTipoDocumento = "";
                codigoTipoDocumento = Util.convertiracadena(FrmParent.gridControl.CurrentRow.Cells["FAC01COD"].Value);
                gridControl.DataSource = datos.TraerDocumentoxPeriodoFA(Logueo.CodigoEmpresa, codigoTipoDocumento,
                                                                         Logueo.Anio, Logueo.Mes, "FAC04NUMDOC", "*", Logueo.UserName);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar nota de credito o nota de debito: " + ex.Message);
            }
        }

        protected override void OnNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Inicio el constructor
            var frmInstance = frmCabNotCredYDeb.Instance(this);
            frmInstance.tipoDocumento = Util.GetCurrentCellText(FrmParent.gridControl.CurrentRow, "FAC01COD");
            // Luego de iniciar el constructor , envio el flag de tipo de operacion
            //frmInstance.Estado = FormEstate.New;
            Estado = FormEstate.New;
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCabNotCredYDeb);
            if (frmExist != null) { frmInstance.BringToFront(); return; }
            
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();
            Cursor.Current = Cursors.Default;
        }
        protected override void OnEditar()
        {
            if (gridControl.Rows.Count == 0) { Util.ShowAlert("No tiene registro para seleccionar"); return; }
            
            Cursor.Current = Cursors.WaitCursor;
            // Inicio el constructor
            var frmInstance = frmCabNotCredYDeb.Instance(this);
            frmInstance.tipoDocumento = Util.GetCurrentCellText(FrmParent.gridControl.CurrentRow, "FAC01COD");
            // Luego de iniciar el constructor , envio el flag de tipo de operacion
            //frmInstance.Estado = FormEstate.Edit;
            Estado = FormEstate.Edit;
            
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCabNotCredYDeb);
            if (frmExist != null) { frmInstance.BringToFront(); return; }

            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();

            Cursor.Current = Cursors.Default;
        }

        protected override void OnEliminar()
        {
            try
            {
                if (gridControl.Rows.Count == 0) { Util.ShowAlert("No tiene registro para seleccionar"); return; }

                bool res = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (res == true)
                {
                    int int_flag = 0; string str_Mensaje = "";
                    string str_TipDoc = Util.GetCurrentCellText(this.gridControl, "FAC01COD");
                    string str_nroDoc = Util.GetCurrentCellText(this.gridControl, "FAC04NUMDOC");
                    DocumentoFA documento = new DocumentoFA();
                    documento.FAC04CODEMP = Logueo.CodigoEmpresa;
                    documento.FAC01COD = str_TipDoc;
                    documento.FAC04NUMDOC = str_nroDoc;
                    Cursor.Current = Cursors.WaitCursor;
                    DocumentoLogic.Instance.Spu_Fact_Del_FAC04_CABFACTURA(documento, out int_flag, out str_Mensaje);
                    Util.ShowMessage(str_Mensaje, int_flag);
                    if (int_flag == 1)
                    {
                        Cargar();
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar :" + ex.Message);
            }
        }
        
        protected override void OnVer()
        {
            if (gridControl.Rows.Count == 0) { Util.ShowAlert("No tiene registro para seleccionar"); return; }
            Cursor.Current = Cursors.WaitCursor;
            var frmInstance = frmCabNotCredYDeb.Instance(this);
            frmInstance.tipoDocumento = Util.GetCurrentCellText(FrmParent.gridControl.CurrentRow, "FAC01COD");
            Estado = FormEstate.View;
            //frmInstance.Estado = FormEstate.View;
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCabNotCredYDeb);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();
            Cursor.Current = Cursors.Default;
        }
        protected override void OnVistaPreliminar()
        {
            
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string codigoTipoDocumento = "";
                string numeroDocumento = "";

                codigoTipoDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD");
                numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC04SERIEDOC") + "-" +
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "FAC04NRODOC");
                

                DataTable datosFactura = new DataTable();
                datosFactura = VentaDocumentoLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa,codigoTipoDocumento, numeroDocumento);

                Reporte reporte = new Reporte("Documento");
                //Codigo para reportes con logos dinamicos
                string rutalogo = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", Util.convertiracadena(Logueo.RucEmpresa) + ".png");
                string rutalogoxdefecto = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", "Logopordefecto.png");

                if (System.IO.File.Exists(rutalogo) == true)
                {
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogo));
                }
                else
                {
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogoxdefecto));
                }
                
                reporte.Ruta = Logueo.GetRutaReporte();

                if (codigoTipoDocumento == "07")
                {
                    reporte.Nombre = "RptNotaCredito.rpt";
                }
                else if (codigoTipoDocumento == "08")
                {
                    reporte.Nombre = "RptNotaDebito.rpt";
                }
                
                reporte.DataSource = datosFactura;

                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error en vista preliminar:" +ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnCancelar()
        {
            this.Close();
        }
        protected override void OnGeneraPDF()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string codigoTipoDocumento = "";
                string numeroDocumento = "";

                codigoTipoDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC01COD");

                numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC04SERIEDOC") + "-" +
                                  Util.GetCurrentCellText(gridControl.CurrentRow, "FAC04NRODOC");

                DataTable datosFactura = new DataTable();
                datosFactura = VentaDocumentoLogic.Instance.TraeReporteFactura(Logueo.CodigoEmpresa, codigoTipoDocumento, numeroDocumento);

                Reporte reporte = new Reporte("Documento");
                //Codigo para reportes con logos dinamicos
                string rutalogo = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", Util.convertiracadena(Logueo.RucEmpresa) + ".png");
                string rutalogoxdefecto = System.IO.Path.Combine(Logueo.GetRutaIcono(), "logos", "Logopordefecto.png");

                if (System.IO.File.Exists(rutalogo) == true)
                {
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogo));
                }
                else
                {
                    reporte.ParametersFields.Add(new Paramentro("@rutalogo", rutalogoxdefecto));
                }

                reporte.Ruta = Logueo.GetRutaReporte();
                if (codigoTipoDocumento == "07")
                {
                    reporte.Nombre = "RptNotaCredito.rpt";
                }
                else if (codigoTipoDocumento == "08")
                {
                    reporte.Nombre = "RptNotaDebito.rpt";
                }
                if (datosFactura.Rows.Count == 0)
                {
                    Util.ShowAlert("No tiene registro el documento seleccionado");
                    return;
                }
                reporte.DataSource = datosFactura;

                ReporteControladora control = new ReporteControladora(reporte);

                control.VistaPDF(enmWindowState.Normal,numeroDocumento);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al generar PDF:" + ex.Message);
            }
        }
        void IniciarBotones()
        {
           
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);           
            HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbGeneraPDF);
            
        }

        private void frmNotaCreYNotDeb_Load(object sender, System.EventArgs e)
        {
            IniciarBotones();
            CrearColumnas();
            Cargar();

            if (EstadoDocumento == BaseTipoDocumento.enmNotaCredito)
            {
                this.Text = "NOTA DE CREDITO";
            }
            else if (EstadoDocumento == BaseTipoDocumento.enmNotaDebito)
            {
                this.Text = "NOTA DE DEBBITO";
            }
            ComportarmientoBotones("cargar");
        }
        
    }
}
