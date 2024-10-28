using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Fac.UI.Win
{
    public partial class frmGenerarFacturaxGuia : frmBaseReg
    {
        public int CantidadRegistros = 0;
        // == Instancia para llamar desde Frm Mdi
        private static frmGenerarFacturaxGuia _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmGenerarFacturaxGuia Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmGenerarFacturaxGuia(padre);
            _aForm = new frmGenerarFacturaxGuia(padre);
            return _aForm;
        }
        
        public frmGenerarFacturaxGuia(frmMDI padre)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            CrearColumnas();
            Oncargar();
            OcultarBotones();
            IniciarBotones();
            gridControl.MultiSelect = true;


            dtpFechaFin.Value = DateTime.Now;
            dtpFechaIni.Value = DateTime.Now.AddDays(-7);

            dtpFechaFin.Enabled = false;
            dtpFechaIni.Enabled = false;
            Cursor.Current = Cursors.Default;
        }
        public void Oncargar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var lista = Fac_GuiaTransporteLogic.Instance.Spu_Fact_Trae_GuiasParaFacturar(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, (this.rbtmes.CheckState == CheckState.Checked) ? "M" : "R", dtpFechaIni.Text.Trim(), dtpFechaFin.Text.Trim());
                this.gridControl.DataSource = lista;
                Cursor.Current = Cursors.Default;
            }            
            catch (Exception ex)
            {
                Cursor.Current = Cursors.WaitCursor;
                Util.ShowError("Error al cargar guias: " + ex.Message);
            }
        }

        private void IniciarBotones()
        {
            //HabilitarBotones(true, true, false, false, false, false, false);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarBoleta);
            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarFactura);
        }
        protected override void OnGenerarBoleta()
        {
            TraerFactura("B");
        }
        protected override void OnGenerarFactura()
        {
            TraerFactura("F");
        }
        void CrearColumnas()
        {
           RadGridView Grid =   CreateGridVista(this.gridControl);
           this.CreateGridColumn(this.gridControl, "FAC34CODEMP", "FAC34CODEMP", 0, "", 100, true, false, false);
           //Codigo de plantilla
           //This.CreateGridColumn(this.gridControl, "Plantilla", "FAC03COD", 0, "", 100, true, false, true);
           //Tipo de documento
           this.CreateGridColumn(this.gridControl, "TipDocumento", "FAC01COD", 0, "", 90, true, false, false);
           this.CreateGridColumn(this.gridControl, "Unid.Transportista", "FAC34TRAYCODIGO", 0, "", 70, true, false, false);
           this.CreateGridColumn(this.gridControl, "Transportista", "FAC34CHOFNOMBRE", 0, "", 280, true, false, false);
           this.CreateGridColumn(this.gridControl, "Pendiente", "FAC34ESTADOLLENADO", 0, "", 100, true, false, false);
           this.CreateGridColumn(this.gridControl, "Anio", "FAC34AA", 0, "", 100, true, false, false);
           this.CreateGridColumn(this.gridControl, "Mes", "FAC34MM", 0, "", 100, true, false, false);

           // ==========================================================================================================================================================
           // ============================================================ Campos para presentar al usuario ============================================================
           // ==========================================================================================================================================================
           this.CreateGridColumn(this.gridControl, "Fecha", "FAC34FECHA", 0, "{0:dd/MM/yyyy}", 70, true, false, true);

           this.CreateGridColumn(this.gridControl, "N° Documento", "FAC34NROGUIA", 0, "", 100, true, false, true);
           
           // Motivo de traslado
            this.CreateGridColumn(this.gridControl, "Cod.Motivo", "FAC34MOTRASLCOD", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Motivo", "FAC34MOTRASLDESC", 0, "", 120, true, false, true);
            this.CreateGridColumn(this.gridControl, "Det. Motivo", "FAC34MOTRASLDESCEXTRA", 0, "", 120, true, false, true);

            // Producto que va en la guia
            this.CreateGridColumn(this.gridControl, "Producto", "ProdDesc", 0, "", 90, true, false, true);
                        
            // Subplantilla
            this.CreateGridColumn(this.gridControl, "Cod.Subplantilla", "FAC03COD", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Tipo", "FAC03DESC", 0, "", 120, true, false, false);
	
            // Tipo de cliente
            this.CreateGridColumn(this.gridControl, "Cod.TipoCliente", "TipoClienteCod", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Desc.TipoCliente", "TipoClienteDesc", 0, "", 120, true, false, false);

            // Cliente de OC
            this.CreateGridColumn(this.gridControl, "Cod.Cliente", "OCClienteCod", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Cliente", "OCClienteDesc", 0, "", 200, true, false, true);
            
            // Tipo de orden de compra
            this.CreateGridColumn(this.gridControl, "Cod.Tipo OC", "OCTipoCod", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Desc.Tipo OC", "OCTipoDesc", 0, "", 80, true, false, true);                            

            // Numero d orden de compra
            this.CreateGridColumn(this.gridControl, "Nro.OC", "FAC34OCNRO", 0, "", 90, true, false, true);

            //Contenedor
            this.CreateGridColumn(this.gridControl, "Contenedor", "FAC34CONTENEDOR", 0, "", 50, true, false, true);
            this.CreateGridColumn(this.gridControl, "Precinto", "FAC34PRECINTO", 0, "", 50, true, false, true); 

            //Estado de proceso
            this.CreateGridColumn(this.gridControl, "EstProceso.Cod", "FAC34ESTADOPROCESOCOD", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Estado Proceso", "FAC34ESTADOPROCESODES", 0, "", 120, true, false, true);

            //Estado de Validez
            this.CreateGridColumn(this.gridControl, "Estado Cod", "FAC34ESTADO", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Estado", "FAC67DESESTADO", 0, "", 70, true, false, true);
            
            //Destinatario
            this.CreateGridColumn(this.gridControl, "Cod.Destino", "FAC34DESCODEMP", 0, "", 70, true, false, false);
            this.CreateGridColumn(this.gridControl, "Destinatario", "FAC34DESDESEMP", 0, "", 120, true, false, true);

            // Estado de facturacion
            this.CreateGridColumn(this.gridControl, "Estado Facturacion", "ESTADODEFACTURACION", 0, "", 120, true, false, true);
        }
       
        private void TraerFactura(string FlagTipoDocumento)
        {
            try
            {

                if (gridControl.Rows.Count == 0) { Util.ShowAlert("No existen registros para generar factura o Boleta"); return; }
                // == 1.Consulta prar traer datos de la cabecera de la guia.

                // == 2.consulta para traer datos del detalle de la guia,

                // == 3.Traer la factura en modo nuevo
                Cursor.Current = Cursors.WaitCursor;
                Estado = FormEstate.New;

                if (FlagTipoDocumento == "B")
                {
                    EstadoDocumento = BaseTipoDocumento.enmBoleta;

                }
                else if (FlagTipoDocumento == "F")
                {
                    EstadoDocumento = BaseTipoDocumento.enmFactura;
                }

                frmfacturacab frmInstance = frmfacturacab.Instance(this);


                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];

                // == 4.Enviar datos de cliente            
                // == 5.Valores en duro de tipo de factura


                int x = 0;
                foreach (GridViewRowInfo row in gridControl.SelectedRows)
                {
                    frmInstance.GuiasSeleccionados[x] = Util.GetCurrentCellText(row, "FAC34NROGUIA") + "|" +
                                                        Util.GetCurrentCellText(row, "FAC01COD") + "|" +
                                                        Util.GetCurrentCellText(row, "FAC34AA") + "|" +
                                                        Util.GetCurrentCellText(row, "FAC34MM") + "|" +
                                                        Util.GetCurrentCellText(row, "FAC34OCNRO");

                    x++;
                }
                CantidadRegistros = x;
                frmInstance.MdiParent = this.ParentForm;





                ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
                frmInstance.Show();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error Traer factura : " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Validar que este activo Por rango de fechas 
            if (rbtrangofechas.IsChecked == true)
            {
                if (dtpFechaIni.Text == "" || dtpFechaFin.Text == "" ) 
                { 
                    Util.ShowAlert("Fecha No valida");
                    dtpFechaIni.Focus();
                    return;
                }
            }


            Oncargar();
            Cursor.Current = Cursors.Default;
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }

        private void rbtmes_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbtmes.CheckState == CheckState.Checked)
            {
                dtpFechaFin.Enabled = false;
                dtpFechaIni.Enabled = false;
            }

        }

        private void rbtrangofechas_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbtrangofechas.CheckState == CheckState.Checked)
            {
                dtpFechaFin.Enabled = true;
                dtpFechaIni.Enabled = true;
            }
        }
    }
}
