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
namespace Cos.UI.Win
{
    public partial class frmImpGastosContables : frmBase
    {
        private frmMDI FrmParent { get; set; }
        private static frmImpGastosContables _aForm;

        public frmImpGastosContables(frmMDI padre) {
            InitializeComponent();
            
            //this.FrmParent.capturarLoteCosto();

            //if (Util.convertiracadena(Logueo.CodigoLoteCosto) == "")
            //{
            //    MessageBox.Show("Sistema", "No tiene registros para importar");
            //    return;
            //}
            
            CrearColumnas();
            CrearColumnasImportacion();
            OnBuscar();
            HabilitarBotones(false, false, false, false, false, false, false, true);

            this.rpImportacion.SendToBack();
            this.rpImportacion.Visible = false;
        }
        

        public static frmImpGastosContables Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmImpGastosContables(mdiPrincipal);
            _aForm = new frmImpGastosContables(mdiPrincipal);
            return _aForm;
        }
        
        private void CrearColumnas() {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
           
            //Datos de los gastos contables
            this.CreateGridColumn(Grid, "Mov.Anio", "COS01CONTGASMOVANO", 0, "", 90);
            this.CreateGridColumn(Grid, "Mov.Mes", "COS01CONTGASMOVMES", 0, "", 90);
            this.CreateGridColumn(Grid, "Mov.Subd", "COS01CONTGASMOVSUBD", 0, "", 90);
            this.CreateGridColumn(Grid, "Mov.Numero", "COS01CONTGASMOVNUMER", 0, "", 100);
            this.CreateGridColumn(Grid, "Mov.Orden", "COS01CONTGASMOVORD", 0, "", 90);
            this.CreateGridColumn(Grid, "Cod.CtaCtble", "COS01CTACBLECOD", 0, "", 120);
            this.CreateGridColumn(Grid, "Des.CtaCtble", "COS01CTACBLEDESC", 0, "", 120);
            this.CreateGridColumn(Grid, "TipCosto Cod", "COS01TIPOCOSTOCOD", 0, "", 120);
            this.CreateGridColumn(Grid, "TipoCosto Desc", "COS01TIPOCOSTODESC", 0, "", 120);
            this.CreateGridColumn(Grid, "Costo Cod", "COS01COSTOCOD", 0, "", 80);
            this.CreateGridColumn(Grid, "Costo Desc", "COS01COSTODESC", 0, "", 100);
            this.CreateGridColumn(Grid, "Importe", "COS01IMPORTE", 0, "", 90);
            this.CreateGridColumn(Grid, "Fijo/Variable", "COS01FIJOOVARIABLE", 0, "", 90);
            this.CreateGridColumn(Grid, "Directo/Indirecto", "COS01DIRECTOOINDIRECTO", 0, "", 90);

            // Suma del importe
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "COS01IMPORTE";
            summaryItem.FormatString = "{0:###,###0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);

            Grid.SummaryRowsBottom.Add(summaryRowItem);

            Grid.MasterTemplate.ShowTotals = true;
            Grid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }
        
        protected override void OnBuscar()
        {
            var contabgastos = ContabilidadGastosLogic.Instance.TraerContabilidadGastos(Logueo.CodigoEmpresa, Logueo.Anio,
                                                   Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto);
            this.gridControl.DataSource = contabgastos;
        }
        #region "Panel Importacion"
        protected override void OnImportar()
        {
            if (this.gridControl.Rows.Count == 0)
            {
                this.rpImportacion.BringToFront();
                this.rpImportacion.Visible = true;
            }
            else {
                DialogResult res;
                ShowAlertQuestion("Sistema", "Los registros contables se eliminara despues de importar, "+ 
                                    "¿Desea continuar?", out res);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    this.rpImportacion.BringToFront();
                    this.rpImportacion.Visible = true;
                }
                else {                    
                    this.rpImportacion.SendToBack();
                    this.rpImportacion.Visible = false;
                }
            }
            
            
        }
        private void CrearColumnasImportacion() {
            RadGridView Grid =  this.CreateGridVista(this.gridImportacion);

            this.CreateGridColumn(Grid, "CodigoEmpresa", "COS01CODEMP", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Anio", "COS01ANIO", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Mes", "COS01MES", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Linea", "COS01LINEA", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Lote", "COS01LOTE", 0, "", 70);
            this.CreateGridColumn(Grid, "Mov.Anio", "COS01CONTGASMOVANO", 0, "", 70);
            this.CreateGridColumn(Grid, "Mov.Mes", "COS01CONTGASMOVMES", 0, "", 70);
            this.CreateGridColumn(Grid, "Mov.Subd", "COS01CONTGASMOVSUBD", 0, "", 70);
            this.CreateGridColumn(Grid, "Mov.Numero", "COS01CONTGASMOVNUMER", 0, "", 70);
            this.CreateGridColumn(Grid, "Mov.Orden", "COS01CONTGASMOVORD", 0, "", 70);

            this.CreateGridColumn(Grid, "Cod.CtaCble", "COS01CTACBLECOD", 0, "", 70);
            this.CreateGridColumn(Grid, "Des.CtaCble", "COS01CTACBLEDESC", 0, "", 70);

            this.CreateGridColumn(Grid, "Cod.Tipo Costo", "COS01TIPOCOSTOCOD", 0, "", 70);
            this.CreateGridColumn(Grid, "Des.Tipo Costos", "COS01TIPOCOSTODESC", 0, "", 70);
            this.CreateGridColumn(Grid, "Cod.Costo", "COS01COSTOCOD", 0, "", 70);
            this.CreateGridColumn(Grid, "Des.Costo", "COS01COSTODESC", 0, "", 70);
            this.CreateGridColumn(Grid, "Importe", "COS01IMPORTE", 0, "{0:###,###0.00}", 70);

            this.CreateGridColumn(Grid, "Fijo/Variable", "COS01FIJOOVARIABLE", 0, "{0:###,###0.00}", 70);
            this.CreateGridColumn(Grid, "Directo/Indirecto", "COS01DIRECTOOINDIRECTO", 0, "{0:###,###0.00}", 70);


        }
       
        private Point MouseDownLocation;
        private void rpImportacion_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rpImportacion.Left = e.X + rpImportacion.Left - MouseDownLocation.X;
                //this.Left = e.X + this.Left - MouseDownLocation.X;
                rpImportacion.Top = e.Y + rpImportacion.Top - MouseDownLocation.Y;
                //this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void rpImportacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void IniciarModal() {
            
        }
        private void CerrarModal() 
        {
            rpImportacion.Visible = false;
            this.gridImportacion.Rows.Clear();
            
        }

        private void btnSalirImprotacion_Click(object sender, EventArgs e)
        {
            CerrarModal();            
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            GastosContabilidad gastos = new GastosContabilidad();
            //gastos.COS01CODEMP = Logueo.CodigoEmpresa;

            OpenFileDialog opf = new OpenFileDialog();
            string fc = "";
            if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
            {
                fc = opf.FileName;
            }
            else return;
            string mensaje = string.Empty;
            
            //limpair la tabla temporal antes de importar
            ContabilidadGastosLogic.Instance.EliminarGastosContabilidadImp(Logueo.CodigoEmpresa, Logueo.UserName, out mensaje);
            var sr = new System.IO.StreamReader(fc, Encoding.Default);
            string mensaje2 = string.Empty;
            while (!sr.EndOfStream) {
                string[] linea = sr.ReadLine().Split('|');               
                    
                    //gastos.COS01CODEMP = Util.convertiracadena(linea[1]);
                    gastos.COS01CODEMP = Logueo.CodigoEmpresa;
                    //gastos.COS01ANIO = Util.convertiracadena(linea[2]);
                    gastos.COS01ANIO = Logueo.Anio;
                    //gastos.COS01MES = Util.convertiracadena(linea[3]);
                    gastos.COS01MES = Logueo.Mes;
                    //gastos.COS01LINEA = Util.convertiracadena(linea[4]);
                    gastos.COS01LINEA = Logueo.CodigoLinea;
                    //gastos.COS01LOTE = Util.convertiracadena(linea[5]);
                    gastos.COS01LOTE = Logueo.CodigoLoteCosto;                  
                    //
                    gastos.COS01CONTGASMOVANO = Util.convertiracadena(linea[1]);
                    gastos.COS01CONTGASMOVMES = Util.convertiracadena(linea[2]);
                    gastos.COS01CONTGASMOVSUBD = Util.convertiracadena(linea[3]);
                    gastos.COS01CONTGASMOVNUMER = Util.convertiracadena(linea[4]);
                    gastos.COS01CONTGASMOVORD = Convert.ToDouble(linea[5]);

                    gastos.COS01CTACBLECOD = Util.convertiracadena(linea[6]);
                    gastos.COS01CTACBLEDESC = Util.convertiracadena(linea[7]);

                    gastos.COS01TIPOCOSTOCOD = Util.convertiracadena(linea[8]);
                    gastos.COS01TIPOCOSTODESC = Util.convertiracadena(linea[9]);

                    gastos.COS01COSTOCOD = Util.convertiracadena(linea[10]);
                    gastos.COS01COSTODESC = Util.convertiracadena(linea[11]);

                    gastos.COS01IMPORTE = Convert.ToDouble(linea[12]);

                    gastos.COS01FIJOOVARIABLE = Util.convertiracadena(linea[13]);
                    gastos.COS01DIRECTOOINDIRECTO = Util.convertiracadena(linea[14]);

                    gastos.COS01CODIGOUSUARIO = Logueo.UserName;
                    gastos.COS01SISTEMA = Logueo.nomModulo;

                    ContabilidadGastosLogic.Instance.InsertarGastosContabilidadImp(gastos, out mensaje2);                
            }

            OnBuscarImportacion();

            
        }
        private void OnBuscarImportacion()
        {
            var datosimportados = ContabilidadGastosLogic.Instance.TraerGastosContabilidadImp(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
               Logueo.CodigoLinea, Logueo.CodigoLoteCosto, Logueo.UserName, Logueo.nomModulo);
            this.gridImportacion.DataSource = datosimportados;
        }
        private bool ValidarImportacion() {
            if (rbArchivoTexto.CheckState == CheckState.Checked) { 
                if (this.gridImportacion.Rows.Count == 0) {
                    ShowAlertExclamation("Sistema", "No tiene registros para importar");
                    return false;
                }
            }
            
            return true;
        }
        private void procesarimportacionxtexto()
        {
            if (!ValidarImportacion()) return;
            string mensaje = string.Empty;
            int flag = 0;

            //Si no tenemos registros en Gastos Contables                
            ContabilidadGastosLogic.Instance.InsertarContabilidadGastos(Logueo.CodigoEmpresa, Logueo.Anio,
                Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto, Logueo.UserName, Logueo.nomModulo,
                out mensaje, out flag);

            if (flag == 1)
            {
                // Si ooperacion fue exitoso 
                ShowAlertOk("Sistema", mensaje);
                //limpiar grilla de importacion
                this.gridImportacion.Rows.Clear();
                //oculta el panel de importacion
                this.rpImportacion.Hide();
                //refrescarha grilla de Gastos Contables
                OnBuscar();
            }
            else
            {
                //Si op0eracion no fue exitoso
                ShowAlertError("sistema", mensaje);
            }
        }
        private void procesarimportacionxdirecto()
        {
            ContabilidadGastosLogic.Instance.InsercionDirectoGastosContables(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                                          Logueo.CodigoLinea, Logueo.CodigoLoteCosto);
            //------------------------------------------------------------------------------------------------------------------------
            string mensaje = ""; int flag = 0;
            //------------------------------------------------------------------------------------------------------------------------
            OnBuscar();
            this.rpImportacion.Visible = false;
            this.rpImportacion.SendToBack();
        }
        private void btnProcesarImportacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbArchivoTexto.CheckState == CheckState.Checked)
                {
                    procesarimportacionxtexto();
                }
                else {
                    procesarimportacionxdirecto();
                    
                }                                                            
            }
            catch (Exception ex) {
                ShowAlertError("Sistema", ex.Message);
            }
        }
        protected override void OnEliminar()
        {
            string mensaje = string.Empty;
            int flag = 0;
            ContabilidadGastosLogic.Instance.EliminarContabilidadGastos(Logueo.CodigoEmpresa, Logueo.Anio,
                Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto, out mensaje, out flag);
            if (flag == 1)
            {
                ShowAlertOk("sistema", mensaje);
                
            }
            else {
                ShowAlertError("sistema", mensaje);
            }
        }
      

        #endregion

        private void rbArchivoTexto_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbArchivoTexto.CheckState == CheckState.Checked)
            {
                this.btnImportar.Visible = true;
            }
            
        }

        private void rbImportarDirecto_CheckStateChanged(object sender, EventArgs e)
        {
            if (rbImportarDirecto.CheckState == CheckState.Checked)
            {
                this.gridControl.Rows.Clear();
                btnImportar.Visible = false;
            }
            

        }

    }
}
