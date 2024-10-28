using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Fac.UI.Win
{
    public partial class frmFacturasCancelar : frmBaseDocumento
    {
        TipoDocumentoLogic datos = TipoDocumentoLogic.Instance;
        
        private static frmFacturasCancelar _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmFacturasCancelar Instance(frmMDI padre)        
        {
            if (_aForm != null) return new frmFacturasCancelar(padre);
            _aForm = new frmFacturasCancelar(padre);
            return _aForm;
        }


        public frmFacturasCancelar(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            
            
        }
        void CrearColumnnasClientes()
        { 
             bool bVisibleON = true, bVisibleOFF = false, bEditableON = true, bEditableOFF = false,
                bReadOnlyON = true, bReadOnlyOFF = false;
            RadGridView Grid = CreateGridVista(gridClientes);
            CreateGridColumn(Grid, "Codigo", "ccm02cod", 0, "", 90);
            CreateGridColumn(Grid, "nombre", "ccm02nom", 0, "", 250);
            CreateGridColumn(Grid, "Importe concedito", "ccm02LineaCreditoImporteConcedido", 0, "{0:###,###0.00}", 70, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");
            CreateGridColumn(Grid, "Divisa", "ccm02LineaCreditoMoneda", 0, "", 50);
            CreateGridColumn(Grid, "Importe solicitado", "ccm02LineaCreditoImporteSolicitado", 0, "{0:###,###0.00}", 70, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");
            CreateGridColumn(Grid, "Condicion pago", "ccm02LineaCreditoCondicionPago", 0, "", 70, bReadOnlyON, bEditableOFF, bVisibleON, false, "right");

     
        }
        void cargarClientes()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                gridClientes.DataSource = DocumentoLogic.Instance.TraeClientesConLineaCredito(Logueo.CodigoEmpresa, "01");
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            Cursor = Cursors.Default;
        }
        private void CargarFacturasxCliente(string codigoCliente) 
        {
            
            Cursor = Cursors.WaitCursor;
            label1.Text = Util.GetCurrentCellText(gridClientes.CurrentRow, "ccm02nom");
            try
            { 
                gridControl.DataSource =  DocumentoLogic.Instance.TraeFacxCliLineaCredito(Logueo.CodigoEmpresa, 
                    "01", codigoCliente);

            }catch (Exception ex){
                Util.ShowError("CargarFacturasxCliente : " + ex.Message);  

            }
            Cursor = Cursors.Default;
        }
        void CrearColumnasFacturas()
        {
            bool bVisibleON = true, bVisibleOFF = false, bEditableON = true, bEditableOFF = false,
           bReadOnlyON = true, bReadOnlyOFF = false;

            RadGridView Grid = CreateGridVista(gridControl);


            CreateGridColumn(Grid, "Clave", "FAC04CLAVE", 0, "", 200, bReadOnlyON, bEditableOFF, bVisibleOFF);
            CreateGridColumn(Grid, "Numero", "FAC04NUMDOC", 0, "", 90);
            CreateGridColumn(Grid, "Moneda", "FAC04MONEDA", 0, "", 70);
            CreateGridColumn(Grid, "Importe", "FAC04IMPTOTAL", 0, "{0:###,###0.00}", 70, bReadOnlyON, bEditableOFF, bVisibleON, true, "right");
            CreateGridColumn(Grid, "Fecha", "FAC04FECHA", 0, "{0:dd/MM/yyyy}", 70);
            CreateGridColumn(Grid, "tipoCodigo", "FAC01COD", 0, "", 70,bReadOnlyON, bEditableOFF, bVisibleOFF);
            CreateGridColumn(Grid, "codigoEstadoPago", "FAC04ESTADOPAGO", 0, "", 70, bReadOnlyON, bEditableOFF, bVisibleOFF);
            CreateGridColumn(Grid, "codigoInformarSecret", "FAC04FLAGINFORMADAALSEGURO", 0, "", 70, bReadOnlyON, bEditableOFF, bVisibleOFF);
            // Agregar columna boton
            Telerik.WinControls.UI.GridViewCommandColumn newColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            newColumn1.HeaderText = "Estado Pago";
            newColumn1.FieldName = "EstadoPago";
            newColumn1.Name = "EstadoPago";
            newColumn1.TextAlignment = ContentAlignment.MiddleCenter;
            newColumn1.Width = 90;
            gridControl.MasterTemplate.Columns.Add(newColumn1);

            Telerik.WinControls.UI.GridViewCommandColumn newColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            newColumn2.HeaderText = "Informada a secrex";
            newColumn2.FieldName = "EstadoEnvioSecrex";
            newColumn2.Name = "EstadoEnvioSecrex";            
            newColumn2.TextAlignment = ContentAlignment.MiddleCenter;
            newColumn2.Width = 90;
            gridControl.MasterTemplate.Columns.Add(newColumn2);
        }
        
        
        private void CancelarFactura(string tipoDocumento, string numeroDocumento, string codigoCliente, string estadoPago)
        {
            Cursor = Cursors.WaitCursor;            
            
            string mensaje = "";
            string clave = "";
            int flag = 0;
            bool respuesta = false;
            if (estadoPago == "0")
            {
                estadoPago = "1";
            }
            else
            {
                respuesta = Util.ShowQuestion("¿Desea cambiar el estado a pendiente?");
                if (respuesta == false)
                {
                    Cursor = Cursors.Default;
                    return;
                }
                estadoPago = "0";
            }
            
            clave = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC04CLAVE");

            DocumentoLogic.Instance.ActualizarFacturaEstadoPago(Logueo.CodigoEmpresa, tipoDocumento,
                                                numeroDocumento, estadoPago, out flag, out mensaje);
            // Si hay erroro muestra mensaje
            if (flag != 1)
            {             
            Util.ShowMessage(mensaje, flag);
            }

            if (flag == 1)
            {                
                CargarFacturasxCliente(codigoCliente);
                Util.enfocarFila(gridControl, "FAC04CLAVE", clave);                
            }

            Cursor = Cursors.Default;
        }
        private void InformarSecret(string tipoDocumento, string numeroDocumento, string codigoCliente, string informarSecrex)
        {
            Cursor = Cursors.WaitCursor;

            string mensaje = "";
            string clave = "";
            int flag = 0;
            bool respuesta = false;
            if (informarSecrex == "0")
            {
                informarSecrex = "1";
            }
            else {
                respuesta = Util.ShowQuestion("¿Desea cambiar el estado a no enviado?");
                if (respuesta == false)
                {
                    Cursor = Cursors.Default;
                    return;
                }
                informarSecrex = "0";
            }
            clave = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC04CLAVE");
            DocumentoLogic.Instance.ActualizarInformarSecret(Logueo.CodigoEmpresa, tipoDocumento,
                                                numeroDocumento, informarSecrex, out flag, out mensaje);

            // Si hay error muestra mensaje
            if (flag != 1)
            {
            Util.ShowMessage(mensaje, flag);
            }

            if (flag == 1)
            {
                CargarFacturasxCliente(codigoCliente);
                Util.enfocarFila(gridControl, "FAC04CLAVE", clave);
            }
            Cursor = Cursors.Default;
        }
                
        private void frmFacturasCancelar_Load(object sender, EventArgs e)
        {
            OcultarBarraBotones();            
            CrearColumnnasClientes();
            CrearColumnasFacturas();            
            cargarClientes();            
        }
                             
        private void gridClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (gridClientes.Rows.Count == 0) return;
            if (gridClientes.CurrentRow == null) return;
            string codigoCliente = Util.GetCurrentCellText(gridClientes.CurrentRow, "ccm02cod");
            CargarFacturasxCliente(codigoCliente);
        }
       
        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                
                if (cellElement == null) return;
                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                if (e.Column.Name == "EstadoPago")
                {
                    
                    if (commandButton.Text == "PENDIENTE")
                    {
                        commandButton.ForeColor = Color.DarkRed;
                        
                    }
                    else {
                        commandButton.ForeColor = Color.DarkBlue;
                        
                    }
                }
                if (e.Column.Name == "EstadoEnvioSecrex")
                {
                    if (commandButton.Text == "ENVIADO")
                    {
                        commandButton.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        commandButton.ForeColor = Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
            

        }

        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
           
        }

        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                string codigoCliente = "", codigoEstadoPago = "", tipoDocumento = "", numeroOocumento = "", codigoInformarSecrex = "";

                codigoCliente = Util.GetCurrentCellText(gridClientes.CurrentRow, "ccm02cod");
                codigoEstadoPago = Util.GetCurrentCellText(gridControl.CurrentRow, "FAC04ESTADOPAGO");
                tipoDocumento = Util.GetCellText(gridControl.CurrentRow, "FAC01COD");
                numeroOocumento = Util.GetCellText(gridControl.CurrentRow, "FAC04NUMDOC");
                codigoInformarSecrex = Util.GetCellText(gridControl.CurrentRow, "FAC04FLAGINFORMADAALSEGURO");

                if (Util.IsCurrentColumn(gridControl.CurrentColumn, "EstadoPago"))
                {
                    CancelarFactura(tipoDocumento, numeroOocumento, codigoCliente, codigoEstadoPago);
                }

                if (Util.IsCurrentColumn(gridControl.CurrentColumn, "EstadoEnvioSecrex"))
                {
                    InformarSecret(tipoDocumento, numeroOocumento, codigoCliente, codigoInformarSecrex);
                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

       

       

    }
}
