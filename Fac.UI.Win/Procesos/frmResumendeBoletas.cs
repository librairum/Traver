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
    public partial class frmResumendeBoletas : frmBaseReg
    {
        #region "Instancia"
        private static frmResumendeBoletas _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmResumendeBoletas Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmResumendeBoletas(formParent);
            _aForm = new frmResumendeBoletas(formParent);
            return _aForm;
        }
        #endregion

        ResumenBoletaLogic datos = ResumenBoletaLogic.Instance;
        public frmResumendeBoletas(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
        }

        private void CargarResumen()
        {
            gridBoletasxResumenDetBoleta.DataSource = datos.TraeResumenBoletas(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, "03");    
            
        }
        
        private void CrearColumnasResumen()
        {
            RadGridView Grid = CreateGridVista(gridBoletasxResumenDetBoleta);
            CreateGridColumn(Grid, "TipoDocumento", "TipoDocumento", 0, "", 120);
            CreateGridColumn(Grid, "Fec.Emision", "FecEmisionComprobante", 0, "", 90);                        
            CreateGridColumn(Grid, "NumeroDocumento", "NumeroDocumento", 0, "", 90);            
            CreateGridColumn(Grid, "Cod.Cliente", "CodigoCliente", 0, "", 120);
            CreateGridColumn(Grid, "Nom.Cliente", "NombreCliente", 0, "", 150);
            /*  ESTADO DE BOLETA */
            CreateGridColumn(Grid, "Estado Proceso", "EstadoProcesoBizlink", 0, "", 120);
            CreateGridColumn(Grid, "Estado Sunat", "EstadoProcesoSUNAT", 0, "", 120);
            CreateGridColumn(Grid, "SubTotal", "SubTotal", 0, "", 70, true, false, true, true, "right");
            CreateGridColumn(Grid, "Igv", "Igv", 0, "", 50, true, false, true, true, "right");
            CreateGridColumn(Grid, "Total", "Total", 0, "", 70, true, false, true, true, "right");    

            /* RESUMEN DE COMROBANTE */ 
            CreateGridColumn(Grid, "ResumenId", "ResumenId", 0, "", 120);
            CreateGridColumn(Grid, "Fec.Resumen", "FecGeneraResumen", 0, "", 90);                        
            /*ESTADO DE RESUMEN */
            CreateGridColumn(Grid, "Estado Resumen", "EstadoResumen", 0, "", 120);
            CreateGridColumn(Grid, "Cod.TipDoc", "CodTipoDocumento", 0, "", 90, true, false, false);
            
              
        }

       
        private void frmResumendeBoletas_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OcultarBotones();
            CrearColumnasResumen();
            CargarResumen();
            
            //HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarFE);
            //RenombrarInformacionlBoton(BaseRegBotones.cbbGenerarFE, "Generar resumen de boletas");

            HabilitaBotonPorNombre(BaseRegBotones.cbbEnviarCorreo);
            RenombrarInformacionlBoton(BaseRegBotones.cbbEnviarCorreo, "Generar resumen de boletas");
            HabilitaBotonPorNombre(BaseRegBotones.cbbDarBajaFE);
            RenombrarInformacionlBoton(BaseRegBotones.cbbDarBajaFE, "Dar de baja el resumen");
            Cursor.Current = Cursors.Default;
            
        }
        protected override void OnEnviarCorreo()
        {
            bool respuesta = Util.ShowQuestion("¿Desea Generar el Documento Electronico?");

            if (respuesta == true)
            {
                //recorrer la grilla con los numerods de documentos y las fechas correspondientes

                string[] lista = new string[this.gridBoletasxResumenDetBoleta.SelectedRows.Count];
                int x = 0;
                string str_mensaje = ""; int int_flag = 0;
                string filtroAct = "", filtroUlt = "";
                string idResumen = "", resumenUlt = "";

                try
                {

                    //validar los documentos seleccionado debe ser de la misma fecha de emision 
                    // para generar su resumen

                    foreach (GridViewRowInfo fila in this.gridBoletasxResumenDetBoleta.SelectedRows)
                    {
                        lista[x] = Util.GetCurrentCellText(fila, "NumeroDocumento") + "|" + 
                                   Util.GetCurrentCellText(fila, "FecEmisionComprobante") + "|" +
                                   Util.GetCurrentCellText(fila, "CodTipoDocumento"); ;
                        filtroAct = Util.GetCurrentCellText(fila, "FecEmisionComprobante");
                        idResumen = Util.GetCurrentCellText(fila, "ResumenId");
                        x++;


                        if (x > 1 && filtroAct != filtroUlt)
                        {
                            Util.ShowAlert("La fecha de documentos seleccionados debe tener la misma fecha de Emision");
                            return;
                        }
                        filtroUlt = filtroAct;
                        //if (idResumen != "")
                        //{
                        //    Util.ShowAlert("El documento seleccionado ya tiene resumen generado");
                        //    return;
                        //}
                        //filtroUlt = filtroAct;
                    }

                    string xml = Util.ConvertiraXMLdinamico(lista);
                    string fechaEmisionComprobante = Util.GetCurrentCellText(this.gridBoletasxResumenDetBoleta, "FecEmisionComprobante");

                    datos.GenerarResumenComprobante(Logueo.CodigoEmpresa, "03", xml, fechaEmisionComprobante, fechaEmisionComprobante,
                                                    out int_flag, out str_mensaje);
                    Util.ShowMessage(str_mensaje, int_flag);
                    CargarResumen();
                }
                catch (Exception ex)
                {
                    Util.ShowAlert("Erro al guardar resumen, detalle:" + ex.Message);
                }
            }
        }
        protected override void OnGenerarFE()
        {
            
             //bool respuesta = Util.ShowQuestion("¿Desea Generar el Documento Electronico?");

             //if (respuesta == true)
             //{
             //    //recorrer la grilla con los numerods de documentos y las fechas correspondientes

             //    string[] lista = new string[this.gridBoletasxResumenDetBoleta.SelectedRows.Count];
             //    int x = 0;
             //    string str_mensaje = ""; int int_flag = 0;
             //    string filtroAct = "", filtroUlt = "";
             //    string idResumen = "", resumenUlt= "";

             //    try
             //    {

             //        //validar los documentos seleccionado debe ser de la misma fecha de emision 
             //        // para generar su resumen

             //        foreach (GridViewRowInfo fila in this.gridBoletasxResumenDetBoleta.SelectedRows)
             //        {
             //            lista[x] = Util.GetCurrentCellText(fila, "NumeroDocumento") + "|" + Util.GetCurrentCellText(fila, "FecEmisionComprobante");
             //            filtroAct = Util.GetCurrentCellText(fila, "FecEmisionComprobante");
             //            idResumen = Util.GetCurrentCellText(fila, "ResumenId");
             //            x++;


             //            if (x > 1 && filtroAct != filtroUlt)
             //            {
             //                Util.ShowAlert("La fecha de documentos seleccionados debe tener la misma fecha de Emision");
             //                return;
             //            }

             //            //if (idResumen != "")
             //            //{
             //            //    Util.ShowAlert("El documento seleccionado ya tiene resumen generado");
             //            //    return;
             //            //}
             //            //filtroUlt = filtroAct;
             //        }

             //        string xml = Util.ConvertiraXMLdinamico(lista);
             //        string fechaEmisionComprobante = Util.GetCurrentCellText(this.gridBoletasxResumenDetBoleta, "FecEmisionComprobante");

             //        datos.GenerarResumenComprobante(Logueo.CodigoEmpresa, "03", xml, fechaEmisionComprobante, fechaEmisionComprobante,
             //                                        out int_flag, out str_mensaje);
             //        Util.ShowMessage(str_mensaje, int_flag);
             //        CargarResumen();
             //    }
             //    catch (Exception ex)
             //    {
             //        Util.ShowAlert("Erro al guardar resumen, detalle:" + ex.Message);
             //    }
             //}
        }


    }
}
