using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Com.UI.Win;

namespace Com.UI.Win
{
    public partial class frmConcepto : frmBaseReg
    {
        #region "Instancia"
        private static frmConcepto _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmConcepto Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmConcepto(formParent);
            _aForm = new frmConcepto(formParent);
            return _aForm;
        }
        #endregion
        VentaDocumentoLogic datos = VentaDocumentoLogic.Instance;
        public frmConcepto(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            this.KeyPreview = false;
            CrearColumnas();

     
        }
        void IniciarControles()
        {
            
        }
        
        private void CrearColumnas()
        {

            RadGridView Grid = CreateGridVista(this.gridControl);
            // CreateGridColumn(Grid, "Cod Plantilla", "FAC89SUBPLANTILLACOD", 0, "{0:dd/MM/yyyy}", 90);  
            
            CreateGridColumn(Grid, "CO07ITEM", "CO07ITEM", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "CO07DESCRIPCION", "CO07DESCRIPCION", 0, "", 180, false,true,true);
            CreateGridColumn(Grid, "ASIENTO TIPO", "CO07ASIENTOTIPOCOD", 0, "", 150, true, false,true);
            CreateGridColumn(Grid, "ASIENTO TIPO DESC", "ccc03des", 0, "", 210, true, false,true);
            CreateGridColumn(Grid, "NOMENCLATURA", "CO07NOMENCLATURA", 0, "", 90, false, true,true);

            //CreateGridColumn(Grid, "Empresa", "FAC89CODEMP", 0, "", 90, true, false, false);
            //CreateGridColumn(Grid, "Tipo Doc Cod", "FAC89TIPDOCCOD", 0, "", 90, true, false, false);
            //CreateGridColumn(Grid, "Tipo Doc Desc", "TipDocDesc", 0, "", 90, true, false, false);
            //CreateGridColumn(Grid, "Plantilla Cod", "FAC89SUBPLANTILLACOD", 0, "", 90, true, false, true);
            //CreateGridColumn(Grid, "Plantilla Desc", "SubPlantillaDesc", 0, "", 150, true, false, true);
            //CreateGridColumn(Grid, "Correlativo", "FAC89CORRELATIVO", 0, "", 90, true, false, false);
            //CreateGridColumn(Grid, "Asiento Tipo Cod", "FAC89ASIENTOTIPOCOD", 0, "", 110, true, false, true);
            //CreateGridColumn(Grid, "Asiento Tipo Desc", "AsientoTipoDesc", 0, "", 170, true, false, true);
            //CreateGridColumn(Grid, "Moneda", "FAC89DOCMONEDA", 0, "", 90, true, false, true);
            //CreateGridColumn(Grid, "Estado Sunat", "FAC89DOCESTADOSUNAT", 0, "", 120, true, false, true);
            //CreateGridColumn(Grid, "Nomenclatura", "FAC89NUMERACIONNOMENCLATURA", 0, "", 120, false, true, true);
            
            //PRIMARY KEYS

        }
        private void ResaltarCamposAyuda()
        {



            int x = 0;
            foreach (GridViewRowInfo row in gridControl.Rows)
            {

                Util.ResaltarAyuda(gridControl, x, "CO07ASIENTOTIPOCOD");
                x++;
            }
        }
        private void ResetearCamposAyuda()
        {



            int x = 0;
            foreach (GridViewRowInfo row in gridControl.Rows)
            {

                Util.ResetearAyuda(gridControl, x, "CO07ASIENTOTIPOCOD");
                x++;
            }
        }
        protected override void OnNuevo()
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            Estado = FormEstate.New;

            gridControl.Rows.AddNew();
            GridViewRowInfo row = gridControl.CurrentRow;
           
            
            ResaltarCamposAyuda();
           
        }

        protected override void OnEliminar()
        {
             bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
             if (respuesta == true)
             {
                 //OBTENGO LOS DATOS DE LA GRILLA
                 GridViewRowInfo info = gridControl.CurrentRow;
                 //PRIMARY KEYS
                 int CO07ITEM = Convert.ToInt32(Util.GetCurrentCellText(gridControl, "CO07ITEM"));
                 string Descripcion = Util.GetCurrentCellText(gridControl, "CO07DESCRIPCION");
                 //END PRIMARY KEYS


                 string Msg = "";
                 int flag = 0;
                 ProvisionFacturaLogic.Instance.Eliminar_co07MotivosDocPorPagar(Logueo.CodigoEmpresa, Descripcion, CO07ITEM, out flag, out Msg);
                 if (flag == 1)
                 {
                     Util.ShowMessage(Msg, 1);
                     Cargar();
                     //ResaltarCamposAyuda();

                 }
                 else
                 {
                     Util.ShowError(Msg);
                     //ResaltarCamposAyuda();
                     Cargar();
                 }
             }
             else 
             {
                 return;
             }
        }
        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            ResaltarCamposAyuda();

        }
        protected override void OnGuardar()
        {
            try
            {
                //OBTENGO LOS DATOS DE LA GRILLA
                GridViewRowInfo info = gridControl.CurrentRow;

                //PRIMARY KEYS

                string CO07CODEMP = Logueo.CodigoEmpresa;
        
                //string FAC89DOCESTADOSUNAT = Util.GetCurrentCellText(gridControl, "FAC89DOCESTADOSUNAT");
                //string FAC89NUMERACIONNOMENCLATURA = Util.GetCurrentCellText(gridControl, "FAC89NUMERACIONNOMENCLATURA");
               

                //END PRIMARY KEYS
                string AsientoTipoCod = Util.GetCurrentCellText(gridControl, "CO07ASIENTOTIPOCOD");
                string NOMENCLATURA = Util.GetCurrentCellText(gridControl, "CO07NOMENCLATURA");
                string Descripcion = Util.GetCurrentCellText(gridControl, "CO07DESCRIPCION");
                int flag = 0;
                string Msg = "";
                if (Estado == FormEstate.New)
                {

                    ProvisionFacturaLogic.Instance.Insertar_co07MotivosDocPorPagar(Logueo.CodigoEmpresa, Descripcion, AsientoTipoCod, NOMENCLATURA, out flag, out Msg);
                
                }
                else if(Estado == FormEstate.Edit)
                {
                    int CO07ITEM = Convert.ToInt32(Util.GetCurrentCellText(gridControl, "CO07ITEM"));
                    ProvisionFacturaLogic.Instance.Actualizar_co07MotivosDocPorPagar(Logueo.CodigoEmpresa, Descripcion, CO07ITEM, AsientoTipoCod, NOMENCLATURA, out flag, out Msg);
                
                }


                if (flag == 1)
                {
                    // Ver mensaje de registro actualizado
                    Util.ShowMessage(Msg, flag);
                    this.Cargar();
                    //ResaltarCamposAyuda();
                    OcultarBotones();
                    HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);

                }
                else
                {
                    Util.ShowError(Msg);
                    ResaltarCamposAyuda();
                }
            }catch(Exception ex)
            {
                Util.ShowError("ERROR");
            }

        }

        protected override void OnCancelar()
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            if (Estado == FormEstate.New)
            {
                //Eliminar fila si se activa el boton cancelar
                GridViewRowInfo fila = gridControl.CurrentRow;
                gridControl.Rows.Remove(fila);

            }
            ResetearCamposAyuda();
            Estado = FormEstate.View;

        }

        // == Evento para cargar la grilla segun la opcion seleccionado
        private void Cargar()
        {
            try
            {

                DataTable dt = ProvisionFacturaLogic.Instance.TraeMotivosDocPorPagar(Logueo.CodigoEmpresa, Logueo.Anio);
                
                this.gridControl.DataSource = dt;

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer factura:" + ex.Message);
            }
        }

        private void frmMotivosxPagar_Load(object sender, EventArgs e)
        {
            
            Cursor.Current = Cursors.WaitCursor;
            IniciarControles();
            ////Oculta opciones de combobox
            
            OcultarBotones();
            ////HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            Util.IsReadOnlyCurrentCell(gridControl, "CO07NOMENCLATURA", false);
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
        
            CrearColumnas();
            Cargar();
            //GridViewRowInfo row = gridControl.CurrentRow;
            //ResaltarCamposAyuda();
            //Estado = FormEstate.View;
            //ResaltarCamposAyuda();
            //Estado = FormEstate.View;
            Cursor.Current = Cursors.Default;

        }
        private void TraerAyuda(enmAyuda tipoAyuda)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmBusqueda frm;
            string[] datos;
            switch (tipoAyuda)
            {
                case enmAyuda.enmAsiento:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "CO07ASIENTOTIPOCOD", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "ccc03des", datos[1]);
                    //Util.SetCellInitEdit(gridControl, "FAC04CONTVOUCHER");       

                    break;
                case enmAyuda.enmFactCab_Moneda:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89DOCMONEDA", datos[0]);


                    break;
                //case enmAyuda.enmFAC03SubPlantillaFAC89:
                //    frm = new frmBusqueda(tipoAyuda);
                //    frm.ShowDialog();
                //    if (frm.Result == null) return;
                //    if (frm.Result.ToString() == "") return;
                //    datos = frm.Result.ToString().Split('|');

                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89TIPDOCCOD", datos[0]);
                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89SUBPLANTILLACOD", datos[1]);
                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "SubPlantillaDesc", datos[2]);

                //    break;
                //case enmAyuda.enmEstadoSUNAT:
                //    frm = new frmBusqueda(tipoAyuda);
                //    frm.ShowDialog();
                //    if (frm.Result == null) return;
                //    if (frm.Result.ToString() == "") return;
                //    datos = frm.Result.ToString().Split('|');
                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89DOCESTADOSUNAT", datos[1]);
                //    break;
                default: break;
            }
            Cursor.Current = Cursors.Default;
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (Estado == FormEstate.View)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    //if (Util.IsCurrentColumn(gridControl, "FAC89SUBPLANTILLACOD"))
                    //{
                    //    TraerAyuda(enmAyuda.enmFAC03SubPlantillaFAC89);
                    //}
                    //if (Util.IsCurrentColumn(gridControl, "FAC89DOCMONEDA"))
                    //{
                    //    TraerAyuda(enmAyuda.enmFactCab_Moneda);
                    //}
                    if (Util.IsCurrentColumn(gridControl, "CO07ASIENTOTIPOCOD"))
                    {
                        TraerAyuda(enmAyuda.enmAsiento);
                    }
                }
            }
        }
        private void SeleccionarTodoFilas()
        {
            try
            {

                gridControl.SelectAll();

                DataObject dataObj = gridControl.GetClipboardContent();
                if (dataObj != null)
                {
                    Clipboard.SetDataObject(dataObj);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al copiar todo las filas , detalle:" + ex.Message);
            }
        }
        private void btnCopiarTodo_Click(object sender, EventArgs e)
        {
            SeleccionarTodoFilas();
        }

     


    }
}
