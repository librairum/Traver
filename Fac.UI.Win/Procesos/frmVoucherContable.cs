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
    public partial class frmVoucherContable : frmBaseReg
    {
        #region "Instancia"
        private static frmVoucherContable _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmVoucherContable Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmVoucherContable(formParent);
            _aForm = new frmVoucherContable(formParent);
            return _aForm;
        }
        #endregion
        VentaDocumentoLogic datos = VentaDocumentoLogic.Instance;
        public frmVoucherContable(frmMDI padre)
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
        private void FiltrarFacturaPorEstadoContable()
        {
            //RadRadioButton opt = (RadRadioButton)sender;
            if (OptEstado0.IsChecked)
            {                
                traerfacturas("0");
            }
            else if (OptEstado1.IsChecked)
            {                
                traerfacturas("1");
            }
            else if (OptEstado2.IsChecked)
            {                
                traerfacturas("2");
            }
            ResaltarCamposAyuda();
            }
        //void OptEstado_Click(object sender, EventArgs e)
        //{
        //    FiltrarFacturaPorEstadoContable();
        //}
       
        private void CrearColumnas()
        {
            bool bVisibleON = true, bVisibleOFF = false, bEditableON = true, bEditableOFF = false,
                 bReadOnlyON = true, bReadOnlyOFF = false;

            RadGridView Grid =  CreateGridVista(this.gridControl);           
            CreateGridColumn(Grid, "Fecha", "FAC04FECHA", 0, "{0:dd/MM/yyyy}", 90);  
            CreateGridColumn(Grid, "Tipo Doc", "FAC01COD", 0, "", 90, true, false, false);  
            CreateGridColumn(Grid, "Descripcion", "FAC01DESC", 0, "", 90);
            CreateGridColumn(Grid, "Cliente", "NOMBRECLIENTE", 0, "", 90,true,false,false);
            CreateGridColumn(Grid, "Tipo.Doc", "TipoDoc", 0, "", 200);
            CreateGridColumn(Grid, "Nro", "FAC04NUMDOC", 0, "", 100);  
            CreateGridColumn(Grid, "Moneda", "FAC04MONEDA", 0, "", 50);  
            CreateGridColumn(Grid, "T.Cambio", "FAC04TIPCAMBIO", 0, "{0:###,###0.0000}", 50, bReadOnlyON, bEditableOFF, bVisibleON, true, "right"); //float
            CreateGridColumn(Grid, "SubTotal", "FAC04IMPSUBTOTAL", 0, "{0:###,###0.00}", 100, bReadOnlyON, bEditableOFF, bVisibleON, true, "right"); //float
            CreateGridColumn(Grid, "IGV", "FAC04IMPIGV", 0, "{0:###,###0.00}", 80, bReadOnlyON, bEditableOFF, bVisibleON, true, "right"); //float
            CreateGridColumn(Grid, "Total", "FAC04IMPTOTAL", 0, "{0:###,###0.00}", 100, bReadOnlyON, bEditableOFF, bVisibleON, true, "right"); //float
            CreateGridColumn(Grid, "Est.Sunat", "EstadoSunat", 0, "", 120);
            CreateGridColumn(Grid, "Est.Usuario", "EstadoUsuario", 0, "", 80);
            CreateGridColumn(Grid, "Asien.Tipo", "FAC04CONTASIENTOTIPO", 0, "", 100);  
            CreateGridColumn(Grid, "Libro", "FAC04CONTLIBRO", 0, "", 70, false, true);
            CreateGridColumn(Grid, "Voucher", "FAC04CONTVOUCHER", 0, "", 120, false, true);
        
        }
        private void ResaltarCamposAyuda()
        {
            int x = 0;
            foreach(GridViewRowInfo row in gridControl.Rows)
            {
                
                Util.ResaltarAyuda(gridControl, x, "FAC04CONTASIENTOTIPO");
                    x++;
            }            
        }

        protected override void OnGuardar()
        {

            string glosa = "";
            string xmlCadena = "";
            string valor = "";

            try
            {


                if (gridControl.SelectedRows.Count == 0) { Util.ShowAlert("Seleccionar documentos para generar voucher"); return; }

                //Recorro la grilla para validar los documento seleccionados debe contener asiento tipo libro y voucher.
                int x = 0;
                for (x = 0; x < gridControl.SelectedRows.Count; x++)
                {
                    if (Util.GetCurrentCellText(gridControl, "FAC04CONTASIENTOTIPO") == ""
                        || Util.GetCurrentCellText(gridControl, "FAC04CONTLIBRO") == ""
                        || Util.GetCurrentCellText(gridControl, "FAC04CONTVOUCHER") == "")
                    {
                        Util.ShowAlert("Validacion :: Debe Ingresar : Asiento Tipo , Libro y Voucher ");
                        return;
                    }

                }


                //Si paso la validacion anterio preparrar los datos para enviar en un xml.
                
                string[] registrosSeleccionados = new string[this.gridControl.SelectedRows.Count];
                int j = 0;

                foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                {
                    // Glosa
                    string DesAsientoTipo;
                    DesAsientoTipo = "";
                    GlobalLogic.Instance.DameDescripcionFA(Logueo.CodigoEmpresa + Util.GetCurrentCellText(fila, "FAC04CONTASIENTOTIPO"), "ASITIPODESC", out DesAsientoTipo);
                    glosa = "";
                    glosa = DesAsientoTipo + " " + Util.GetCurrentCellText(fila, "FAC04NUMDOC") + " " + Util.GetCurrentCellText(fila, "NOMBRECLIENTE");


                    registrosSeleccionados[j] =
                    Util.GetCurrentCellText(fila, "FAC04CONTASIENTOTIPO") + "|" +
                    Util.GetCurrentCellText(fila, "FAC04CONTLIBRO") + "|" +
                    Util.GetCurrentCellText(fila, "FAC04CONTVOUCHER") + "|" +
                    Util.GetCurrentCellText(fila, "FAC01COD") + "|" +
                    Util.GetCurrentCellText(fila, "FAC04NUMDOC") + "|" + glosa;

                  j++;
                }
                xmlCadena = Util.ConvertiraXMLdinamico(registrosSeleccionados);
                string mensaje = "";
                int flag = 0;

                datos.InsertarVoucheContable(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, xmlCadena, out flag, out mensaje);

                if (flag == 1)
                {
                    Util.ShowMessage(mensaje, flag);
                    IniciarControles();
                    traerfacturas("0");
                }
                else
                {
                    Util.ShowMessage(mensaje, flag);
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar Voucher contable.:" + ex.Message);
            }

        }

        protected override void OnCancelar()
        {
            
            this.Close();
        }

        // == Evento para cargar la grilla segun la opcion seleccionado
        private void traerfacturas(string estadocontable)
        {
            try
            {
                List<Spu_Fact_Trae_DocParaVouCont> lista = datos.TraeDocParaVouCount(Logueo.CodigoEmpresa,
                                                             Logueo.Anio, Logueo.Mes, estadocontable);


                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro al traer factura:" + ex.Message);
            }
        }

        private void frmVoucherContable_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IniciarControles();

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

            traerfacturas("0");
            ResaltarCamposAyuda();
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
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC04CONTASIENTOTIPO", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC04CONTLIBRO", datos[1]);
                    Util.SetCellInitEdit(gridControl, "FAC04CONTVOUCHER");       
                    break;
                default: break;
            }

            Cursor.Current = Cursors.Default;
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                if (Util.IsCurrentColumn(gridControl, "FAC04CONTASIENTOTIPO"))
                {
                    TraerAyuda(enmAyuda.enmAsiento);
                }
            }
        }

        private void OptEstado0_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            FiltrarFacturaPorEstadoContable();
        }

        private void OptEstado1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            FiltrarFacturaPorEstadoContable();
        }

        private void OptEstado2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            FiltrarFacturaPorEstadoContable();
        }
    }
}
