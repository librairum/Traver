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

namespace Fac.UI.Win
{
    public partial class frmPlantillaXVoucher : frmBaseReg
    {
        #region "Instancia"
        private static frmPlantillaXVoucher _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmPlantillaXVoucher Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmPlantillaXVoucher(formParent);
            _aForm = new frmPlantillaXVoucher(formParent);
            return _aForm;
        }
        #endregion
        VentaDocumentoLogic datos = VentaDocumentoLogic.Instance;
        public frmPlantillaXVoucher(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            this.KeyPreview = false;
            CrearColumnas();
                    
            //this.OptEstado0.Click += new EventHandler(OptEstado_Click);
            //this.OptEstado1.Click += new EventHandler(OptEstado_Click);
            //this.OptEstado2.Click += new EventHandler(OptEstado_Click);
            //IniciarControles();
        }
        void IniciarControles()
        {
            OptEstado0.CheckState = CheckState.Checked;            
        }
        //private void FiltrarFacturaPorEstadoContable()
        //{
        //    //RadRadioButton opt = (RadRadioButton)sender;
        //    if (OptEstado0.IsChecked)
        //    {                
        //        traerfacturas("0");
        //    }
        //    else if (OptEstado1.IsChecked)
        //    {                
        //        traerfacturas("1");
        //    }
        //    else if (OptEstado2.IsChecked)
        //    {                
        //        traerfacturas("2");
        //    }
        //    ResaltarCamposAyuda();
        //            }
        //void OptEstado_Click(object sender, EventArgs e)
        //{
        //    FiltrarFacturaPorEstadoContable();
        //}
       
        private void CrearColumnas()
        {

            RadGridView Grid =  CreateGridVista(this.gridControl);
           // CreateGridColumn(Grid, "Cod Plantilla", "FAC89SUBPLANTILLACOD", 0, "{0:dd/MM/yyyy}", 90);  

            CreateGridColumn(Grid, "Empresa", "FAC89CODEMP", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Tipo Doc Cod", "FAC89TIPDOCCOD", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Tipo Doc Desc", "TipDocDesc", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Plantilla Cod", "FAC89SUBPLANTILLACOD", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "Plantilla Desc", "SubPlantillaDesc", 0, "", 150, true, false, true);
            CreateGridColumn(Grid, "Correlativo", "FAC89CORRELATIVO", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Asiento Tipo Cod", "FAC89ASIENTOTIPOCOD", 0, "", 110, true, false, true);
            CreateGridColumn(Grid, "Asiento Tipo Desc", "AsientoTipoDesc", 0, "", 170, true, false, true);
            CreateGridColumn(Grid, "Moneda", "FAC89DOCMONEDA", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "Estado Sunat", "FAC89DOCESTADOSUNAT", 0, "", 120,true,false,true);
            CreateGridColumn(Grid, "Nomenclatura", "FAC89NUMERACIONNOMENCLATURA", 0, "", 120, false, true, true);
            //PRIMARY KEYS

        }
        private void ResaltarCamposAyuda()
        {



            int x = 0;
            foreach (GridViewRowInfo row in gridControl.Rows)
            {

                Util.ResaltarAyuda(gridControl,x, "FAC89SUBPLANTILLACOD");
                Util.ResaltarAyuda(gridControl,x, "FAC89DOCMONEDA");
                Util.ResaltarAyuda(gridControl, x, "FAC89ASIENTOTIPOCOD");
                Util.ResaltarAyuda(gridControl, x, "FAC89DOCESTADOSUNAT");
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
            ResaltarCamposAyuda();

        }
       
        protected override void OnEliminar()
        {
            //OBTENGO LOS DATOS DE LA GRILLA
            GridViewRowInfo info = gridControl.CurrentRow;
            //PRIMARY KEYS
            string FAC89CODEMP = info.Cells["FAC89CODEMP"].Value.ToString();
            string FAC89TIPDOCCOD = info.Cells["FAC89TIPDOCCOD"].Value.ToString();
            string FAC89SUBPLANTILLACOD = info.Cells["FAC89SUBPLANTILLACOD"].Value.ToString();
            int FAC89CORRELATIVO = Convert.ToInt32(info.Cells["FAC89CORRELATIVO"].Value.ToString());
            //END PRIMARY KEYS

            //Eliminar FAC89_SUBPLANTILLA_X_VOUCHER
            string Msg = "";
            int flag = 0;
            VoucherLogic.Instance.Eliminar_FAC89_SUBPLANTILLA_X_VOUCHER(FAC89CODEMP, FAC89TIPDOCCOD, FAC89SUBPLANTILLACOD, FAC89CORRELATIVO, out Msg, out flag);

            if (flag == 1)
            {
                Util.ShowMessage(Msg, 1);
                Cargar();
                //ResaltarCamposAyuda();

            }
            else 
            {
                Util.ShowMessage(Msg,1);
                ResaltarCamposAyuda();
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
            //OBTENGO LOS DATOS DE LA GRILLA
             GridViewRowInfo info = gridControl.CurrentRow;

            //PRIMARY KEYS
            //string FAC89CODEMP = info.Cells["FAC89CODEMP"].Value.ToString();
            //string FAC89TIPDOCCOD = info.Cells["FAC89TIPDOCCOD"].Value.ToString();
            //string FAC89SUBPLANTILLACOD = info.Cells["FAC89SUBPLANTILLACOD"].Value.ToString();
           
            ////END PRIMARY KEYS
            //string FAC89ASIENTOTIPOCOD = info.Cells["FAC89ASIENTOTIPOCOD"].Value.ToString();
            //string FAC89DOCMONEDA = info.Cells["FAC89DOCMONEDA"].Value.ToString();
            //string FAC89DOCESTADOSUNAT = info.Cells["FAC89DOCESTADOSUNAT"].Value.ToString();
            //string FAC89NUMERACIONNOMENCLATURA = info.Cells["FAC89NUMERACIONNOMENCLATURA"].Value.ToString();

            //PRIMARY KEYS
             string FAC89CODEMP = Logueo.CodigoEmpresa;
             string FAC89TIPDOCCOD = Util.GetCurrentCellText(gridControl, "FAC89TIPDOCCOD");
             string FAC89SUBPLANTILLACOD = Util.GetCurrentCellText(gridControl, "FAC89SUBPLANTILLACOD");

            //END PRIMARY KEYS
             string FAC89ASIENTOTIPOCOD = Util.GetCurrentCellText(gridControl, "FAC89ASIENTOTIPOCOD"); 
             string FAC89DOCMONEDA = Util.GetCurrentCellText(gridControl, "FAC89DOCMONEDA"); 
             string FAC89DOCESTADOSUNAT = Util.GetCurrentCellText(gridControl, "FAC89DOCESTADOSUNAT");
             string FAC89NUMERACIONNOMENCLATURA = Util.GetCurrentCellText(gridControl, "FAC89NUMERACIONNOMENCLATURA");

            int flag=0;
            string Msg = "";

            if (Estado == FormEstate.New)
            {
                //Insertar FAC89_SUBPLANTILLA_X_VOUCHER
                int FAC89CORRELATIVO = 0;
             VoucherLogic.Instance.Insertar_FAC89_SUBPLANTILLA_X_VOUCHER(FAC89CODEMP, FAC89TIPDOCCOD, FAC89SUBPLANTILLACOD, FAC89CORRELATIVO, FAC89ASIENTOTIPOCOD, FAC89DOCMONEDA, FAC89DOCESTADOSUNAT, FAC89NUMERACIONNOMENCLATURA, out Msg, out flag);
       
               
            }
            else if(Estado == FormEstate.Edit) 
            {
                int FAC89CORRELATIVO = Convert.ToInt32(info.Cells["FAC89CORRELATIVO"].Value.ToString());
                //Insertar FAC89_SUBPLANTILLA_X_VOUCHER
             
                VoucherLogic.Instance.Actualizar_FAC89_SUBPLANTILLA_X_VOUCHER(FAC89CODEMP, FAC89TIPDOCCOD, FAC89SUBPLANTILLACOD, FAC89CORRELATIVO, FAC89ASIENTOTIPOCOD, FAC89DOCMONEDA, FAC89DOCESTADOSUNAT, FAC89NUMERACIONNOMENCLATURA, out Msg,out flag);
           
              
            }

            //this.Cargar();
            //ResaltarCamposAyuda();
            //OcultarBotones();
            //HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);

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
                Util.ShowMessage(Msg, flag);
                ResaltarCamposAyuda();
            }         


        }

        protected override void OnCancelar()
        {
            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
           // HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            if(Estado == FormEstate.New)
            {
                //Eliminar fila si se activa el boton cancelar
                GridViewRowInfo fila = gridControl.CurrentRow;
                gridControl.Rows.Remove(fila);
                
            }
            int x = 0;
            foreach (GridViewRowInfo row in gridControl.Rows)
            {

                Util.ResetearAyuda(gridControl, x, "FAC89SUBPLANTILLACOD");
                Util.ResetearAyuda(gridControl, x, "FAC89DOCMONEDA");
                Util.ResetearAyuda(gridControl, x, "FAC89ASIENTOTIPOCOD");
                Util.ResetearAyuda(gridControl, x, "FAC89DOCESTADOSUNAT");
                x++;
            }
            Estado = FormEstate.View;

        }

        // == Evento para cargar la grilla segun la opcion seleccionado
        private void Cargar()
        {
            try
            {
                DataTable dt = VoucherLogic.Instance.Traer_FAC89_SUBPLANTILLA_X_VOUCHER(Logueo.CodigoEmpresa);

                this.gridControl.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer factura:" + ex.Message);
            }
        }

        private void frmPlantillaXVoucher_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IniciarControles();
            //Oculta opciones de combobox
            radGroupBox2.Visible = false;
            OcultarBotones();
            //HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);

            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

            Cargar();
            Estado = FormEstate.View;
            //ResaltarCamposAyuda();
           
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
                    if(frm.Result == null) return;
                    if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89ASIENTOTIPOCOD", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "AsientoTipoDesc", datos[2]);
                    //Util.SetCellInitEdit(gridControl, "FAC04CONTVOUCHER");       

                    break;
                case enmAyuda.enmFactCab_Moneda:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                      if(frm.Result == null) return;
                    if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89DOCMONEDA", datos[0]);
      

                    break;
                case enmAyuda.enmFAC03SubPlantillaFAC89:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                      if(frm.Result == null) return;
                    if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');

                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89TIPDOCCOD", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow,"FAC89SUBPLANTILLACOD",datos[1]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "SubPlantillaDesc", datos[2]);

                    break;
                case enmAyuda.enmEstadoSUNAT:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                       if(frm.Result == null) return;
                    if(frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89DOCESTADOSUNAT", datos[1]);
                    break;
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
                    if (Util.IsCurrentColumn(gridControl, "FAC89SUBPLANTILLACOD"))
                    {
                        TraerAyuda(enmAyuda.enmFAC03SubPlantillaFAC89);
                    }
                    if (Util.IsCurrentColumn(gridControl, "FAC89DOCMONEDA"))
                    {
                        TraerAyuda(enmAyuda.enmFactCab_Moneda);
                    }
                    if (Util.IsCurrentColumn(gridControl, "FAC89ASIENTOTIPOCOD"))
                    {
                        TraerAyuda(enmAyuda.enmAsiento);
                    }

                    if (Util.IsCurrentColumn(gridControl, "FAC89DOCESTADOSUNAT"))
                    {
                        TraerAyuda(enmAyuda.enmEstadoSUNAT);
                    }
                }
            }
        }

        private void OptEstado0_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            //FiltrarFacturaPorEstadoContable();
        }

        private void OptEstado1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            //FiltrarFacturaPorEstadoContable();
        }

        private void OptEstado2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            //FiltrarFacturaPorEstadoContable();
        }
    }
}
