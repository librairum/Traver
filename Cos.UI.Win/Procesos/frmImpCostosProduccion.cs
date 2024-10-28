using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessLogic;
using Inv.BusinessEntities;


namespace Cos.UI.Win
{
    public partial class frmImpCostosProduccion : frmBase
    {
        private frmMDI FrmParent { get; set; }
        private static frmImpCostosProduccion _aForm;
       
        public frmImpCostosProduccion(frmMDI padre)
        {
            InitializeComponent();
            HabilitarBotones(false, false, false, false, false, false, false, true);
            CerrarModal();
            CrearColumnas();
            CrearColumnasImportacion();
            OnBuscar();
        }
        public static frmImpCostosProduccion Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmImpCostosProduccion(mdiPrincipal);
            _aForm = new frmImpCostosProduccion(mdiPrincipal);
            return _aForm;
        }
        private void CrearColumnas()
        {
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
            this.CreateGridColumn(Grid, "Importe", "COS01IMPORTE", 0, "{0:###,###0.00}", 90, true, false, true, "right");
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
            List<CostosProduccion> lista = CostosProduccionLogic.Instance.TraerCostosPrd(Logueo.CodigoEmpresa, 
                                                                                        Logueo.Anio, Logueo.Mes);
            this.gridControl.DataSource = lista;
        }
        #region "Panel Importacion"

        private void CrearColumnasImportacion()
        {
            RadGridView Grid = this.CreateGridVista(this.gridImportacion);
                        
            CreateGridColumn(Grid, "COS01CODEMP", "COS01CODEMP", 0, "", 70, true, false, false);// oculto
            CreateGridColumn(Grid, "COS01ANIO", "COS01ANIO", 0, "", 70, true, false, false);// oculto
            CreateGridColumn(Grid, "COS01MES", "COS01MES", 0, "", 70, true, false, false);// oculto
            CreateGridColumn(Grid, "Mov.Anio", "COS01CONTGASMOVANO", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Mov.Mes", "COS01CONTGASMOVMES", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Mov.Subd", "COS01CONTGASMOVSUBD", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Mov.Numero", "COS01CONTGASMOVNUMER", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Mov.orden", "COS01CONTGASMOVORD", 0, "", 70, true, false, true);

            CreateGridColumn(Grid, "CodigoCtactble", "COS01CTACBLECOD", 0, "", 70, true, false, false); // oculto
            CreateGridColumn(Grid, "Cta.Cble", "COS01CTACBLEDESC", 0, "", 120, true, false, true);
            CreateGridColumn(Grid, "TipoCostoCod", "COS01TIPOCOSTOCOD", 0, "", 70, true, false, false); // oculto
            CreateGridColumn(Grid, "Tipo Costo", "COS01TIPOCOSTODESC", 0, "", 120, true, false, true);
            CreateGridColumn(Grid, "COS01COSTOCOD", "COS01COSTOCOD", 0, "", 70, true, false, false); // oculto
            CreateGridColumn(Grid, "Costo", "COS01COSTODESC", 0, "", 120, true, false, true);
            CreateGridColumn(Grid, "Importe", "COS01IMPORTE", 0, "{0:###,###0.00}", 70, true, false, true,"right");
            CreateGridColumn(Grid, "Fijo o variable", "COS01FIJOOVARIABLE", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "Directo o indirecto", "COS01DIRECTOOINDIRECTO", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "COS01FLAG", "COS01FLAG", 0, "", 70, true, false, false); // oculto
            CreateGridColumn(Grid, "Errores", "COS01ERRORES", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "Cant.Errores", "COS01CANTERRORES", 0, "", 70, true, false, false);
            CreateGridColumn(Grid, "COS01CODIGOUSUARIO", "COS01CODIGOUSUARIO", 0, "", 70, true, false, false); // oculto
            CreateGridColumn(Grid, "Sistema", "COS01SISTEMA", 0, "", 70, true, false, true);
            
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "COS01IMPORTE";
            summaryItem.FormatString = "{0:###,##0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem rowItem = new GridViewSummaryRowItem() { summaryItem };
            Grid.SummaryRowsBottom.Add(rowItem);
            Grid.MasterTemplate.ShowTotals = true;
            Grid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }
        private Point MouseDownLocation;
        private void rpImportacion_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rpImportacion.Left = e.X + rpImportacion.Left - MouseDownLocation.X;
                rpImportacion.Top = e.Y + rpImportacion.Top - MouseDownLocation.Y;
            }
        }

        private void rpImportacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void CerrarModal() {
            rpImportacion.Visible = false;
            this.gridImportacion.Rows.Clear();
        }
        private void btnSalirImprotacion_Click(object sender, EventArgs e)
        {
            CerrarModal();
        }
        private void procesarimportacionxtexto()
        { 
            string mensaje = "";
            int flag = 0;
            CostosProduccionLogic.Instance.InsertarCostosProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                            Logueo.UserName, Logueo.nomModulo, out mensaje, out flag);
            if (flag == 1)
            {
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                rpImportacion.Visible = false;
                rpImportacion.SendToBack();
                OnBuscar();
            }
            else if (flag == -1)
            {
                RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            
        }
        private void procesarimportacionxdirecto()
        { 

        }
        private void importacionxtexto()
        { 
            CostosProduccion costos = new CostosProduccion();
                costos.COS01CODEMP = Logueo.CodigoEmpresa;
                costos.COS01ANIO = Logueo.Anio;
                costos.COS01MES = Logueo.Mes;

                try
                {
                    OpenFileDialog opf = new OpenFileDialog();
                    string fc = "";
                    if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                    {
                        fc = opf.FileName;
                    }
                    else return;
                    string mensaje = string.Empty;

                    //limpair la tabla temporal antes de importar
                    //ContabilidadGastosLogic.Instance.EliminarGastosContabilidadImp(Logueo.CodigoEmpresa, Logueo.UserName, out mensaje);
                    CostosProduccionLogic.Instance.EliminarImportacion(Logueo.CodigoEmpresa, Logueo.UserName, out mensaje);

                    //CostosProduccionLogic.Instance.EliminarCostosProduccion(costos, out mensaje);
                    var sr = new System.IO.StreamReader(fc, Encoding.Default);
                    string mensaje2 = string.Empty;
                    int flag = 0;
                    while (!sr.EndOfStream)
                    {
                        string[] linea = sr.ReadLine().Split('|');
                        costos.COS01CODEMP = Logueo.CodigoEmpresa;
                        costos.COS01ANIO = Logueo.Anio;
                        costos.COS01MES = Logueo.Mes;
                        costos.COS01CONTGASMOVANO = Util.convertiracadena(linea[1]);
                        costos.COS01CONTGASMOVMES = Util.convertiracadena(linea[2]);
                        costos.COS01CONTGASMOVSUBD = Util.convertiracadena(linea[3]);
                        costos.COS01CONTGASMOVNUMER = Util.convertiracadena(linea[4]);

                        costos.COS01CONTGASMOVORD = Convert.ToDouble(Util.convertiracadena(linea[5]));
                        costos.COS01CTACBLECOD = Util.convertiracadena(linea[6]);
                        costos.COS01CTACBLEDESC = Util.convertiracadena(linea[7]);
                        costos.COS01TIPOCOSTOCOD = Util.convertiracadena(linea[8]);
                        costos.COS01TIPOCOSTODESC = Util.convertiracadena(linea[9]);
                        costos.COS01COSTOCOD = Util.convertiracadena(linea[10]);
                        costos.COS01COSTODESC = Util.convertiracadena(linea[11]);
                        costos.COS01IMPORTE = Convert.ToDouble(Util.convertiracadena(linea[12]));
                        costos.COS01FIJOOVARIABLE = Util.convertiracadena(linea[13]);
                        costos.COS01DIRECTOOINDIRECTO = Util.convertiracadena(linea[14]);
                        costos.COS01CODIGOUSUARIO = Logueo.UserName;
                        costos.COS01SISTEMA = Logueo.nomModulo;
                        CostosProduccionLogic.Instance.InsertarImportacion(costos, out mensaje2, out flag);
                        //if (@flag == -1)
                        //{

                        //}
                        //else if (@flag == 0)
                        //{ 
                            
                        //}
                    }
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);

                }
            
        }
        private void importacionxdirecto()
        { 
            
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            //GastosContabilidad gastos = new GastosContabilidad();
            
            try
            {

                if (rbArchivoTexto.CheckState == CheckState.Checked)
                {
                    importacionxtexto();
                    OnBuscarImportacion();
                }
                else if (rbImportarDirecto.CheckState == CheckState.Checked)
                {                    
                    importacionxdirecto();        
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error" + ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            
            
        }
        private void cargarentidad()
        { 
            
        }
        private void guardardatosimportados()
        { 
            
            //CostosProduccionLogic.Instance.InsertarCostosProduccion(
        }
        private void btnProcesarImportacion_Click(object sender, EventArgs e)
        {
            
            if (rbArchivoTexto.CheckState == CheckState.Checked)
            {
                if (this.gridImportacion.Rows.Count == 0)
                {
                    RadMessageBox.Show("Debe importar datos", "Sistema", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                procesarimportacionxtexto();
               

            }
            else if (rbImportarDirecto.CheckState == CheckState.Checked) 
            {
                procesarimportacionxdirecto();
            }
            
        }

        private void OnBuscarImportacion()
        {
            List<CostosProduccion> lista =  CostosProduccionLogic.Instance.TraerImportacion(Logueo.CodigoEmpresa, Logueo.UserName);
            this.gridImportacion.DataSource = lista;
            
        }
        protected override void OnImportar()
        {
            this.rpImportacion.Visible = true;
        }
        private void rbImportarDirecto_CheckStateChanged(object sender, EventArgs e)
        {
            btnImportar.Visible = false;
            this.gridImportacion.Rows.Clear();
        }

        private void rbArchivoTexto_CheckStateChanged(object sender, EventArgs e)
        {
            btnImportar.Visible = true;
        }
        #endregion
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Reporte de Sql SSRS
            ReporteViewer reportesql = new ReporteViewer("Documento");

            reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS(); // obtener el nombre de la carpeta donde esta nuestro reporte
            reportesql.Ruta = Logueo.GetDirectorySSRRS();
            reportesql.Nombre = "RptCostProdxLinea";

            // agregar parametros de entradas
            Paramentro pEmoresa = new Paramentro("COS01CODEMP", Logueo.CodigoEmpresa);
            reportesql.ParametersFields.Add(pEmoresa);

            Paramentro pAnio = new Paramentro("COS01ANIO", Logueo.Anio);
            reportesql.ParametersFields.Add(pAnio);

            Paramentro pMes = new Paramentro("COS01MES", Logueo.Anio);
            reportesql.ParametersFields.Add(pMes);             

            ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
       

       

    }
}
