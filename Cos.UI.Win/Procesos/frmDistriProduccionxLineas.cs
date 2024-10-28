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
    public partial class frmDistriProduccionxLineas : frmBaseReg
    {
        private frmMDI FrmParent { get; set; }
        private static frmDistriProduccionxLineas _aForm;
        private bool isloaded = false;
        public frmDistriProduccionxLineas(frmMDI padre)
        {
            InitializeComponent();
            HabilitarBotones(true, false, true, false, false);
            
            CrearColumnasActividadesApoyo();
            CargarActividadesApoyo();

            CrearColumnasLineas();
            CargarLineas();

            CrearColumnasDistribucion();
            CargarDistribucion();
            isloaded = true;
        }
        public static frmDistriProduccionxLineas Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmDistriProduccionxLineas(mdiPrincipal);
            _aForm = new frmDistriProduccionxLineas(mdiPrincipal);
            return _aForm;
        }

        protected override void OnVista()
        {
            ReporteViewer reportesql = new ReporteViewer("Documento");
            reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS(); // obtener el nombre de la carpeta donde esta nuestro reporte
            reportesql.Ruta = Logueo.GetDirectorySSRRS();
            reportesql.Nombre = "RptCostProdxLinea";
             // agregar parametros de entradas
            Paramentro pEmoresa = new Paramentro("COS01CODEMP", Logueo.CodigoEmpresa);
            reportesql.ParametersFields.Add(pEmoresa);
            Paramentro pAnio = new Paramentro("COS01ANIO", Logueo.Anio);
            reportesql.ParametersFields.Add(pAnio);
            Paramentro pMes = new Paramentro("COS01MES", Logueo.Mes);
            reportesql.ParametersFields.Add(pMes);         
            ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }


        private void CrearColumnasLineas()
        {
            RadGridView Grid = this.CreateGridVista(this.gridLineas);
            this.CreateGridColumn(Grid, "codigoEmpresa", "PRO08CODEMP", 0, "", 90, true, false, false);
            this.CreateGridColumn(Grid, "Codigo", "PRO08COD", 0, "", 90);
            this.CreateGridColumn(Grid, "Descripcion", "PRO08DESC", 0, "", 120);
            this.CreateGridColumn(Grid, "Tasa", "COS01TASA", 0, "", 70, false, true);
        }
        private void CargarLineas() 
        {
            string CodActApoyo = Util.convertiracadena(this.gridActApoyo.CurrentRow.Cells["COS01CODIGO"].Value);
            List<Spu_Cos_Trae_DistribucionLineaxActApoyo> lista = TasasDistribucionLogic.Instance.TraerDisttribucionLinea(Logueo.CodigoEmpresa,
                                                                                                                          Logueo.Anio, Logueo.Mes,
                                                                                                                          CodActApoyo);
            this.gridLineas.DataSource = lista;
            
        }

        private void CrearColumnasActividadesApoyo()
        {
            RadGridView Grid = this.CreateGridVista(this.gridActApoyo);
            this.CreateGridColumn(Grid, "Codigo", "COS01CODIGO", 0, "", 60);
            this.CreateGridColumn(Grid, "Descripcion", "COS01DESCRIPCION", 0, "", 250);
        }
        private void CargarActividadesApoyo()
        {
            var actapoyo = ActividadesContableLogic.Instance.TraerActividadesContablexTipo(Logueo.CodigoEmpresa, Logueo.ActContableTipo);
            this.gridActApoyo.DataSource = actapoyo;
        }

        private void gridActApoyo_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!isloaded) return;
            CargarLineas();
        }
        protected override void OnGuardar()
        {
            string[] lista = new string[this.gridLineas.Rows.Count];
            int x = 0;
            string codactapoyo = Util.convertiracadena(this.gridActApoyo.CurrentRow.Cells["COS01CODIGO"].Value);
            foreach (GridViewRowInfo fila in this.gridLineas.Rows)
            {
                    
                    lista[x] = Util.convertiracadena(fila.Cells["PRO08CODEMP"].Value) + "|" +
                            Logueo.Anio + "|" + Logueo.Mes + "|" + codactapoyo + "|" +
                            Util.convertiracadena(fila.Cells["PRO08COD"].Value) + "|" +
                            Util.convertiracadena(fila.Cells["COS01TASA"].Value);

                    x++;       
            }
            string mensaje = "";
            int flag = 0;
            
            try
            {
                TasasDistribucionLogic.Instance.GuardarDistribucionTasaxLinea(Util.ConvertirXMLDinamico(lista), out mensaje, out flag);
                if (flag == -1)
                {
                    RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else {
                    RadMessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            
        }
        private void CrearColumnasDistribucion()
        { 
           //[MapField("COS01CODEMP")]
          RadGridView Grid = this.CreateGridVista(this.gridActDistribuida);
            this.CreateGridColumn(Grid, "Empresa", "COS01CODEMP", 0, "", 70, true, false, false);
        //public string COS01CODEMP { get; set; }
            this.CreateGridColumn(Grid, "Anio", "COS01ANIO", 0, "", 70);
        //[MapField("COS01ANIO")]        
            this.CreateGridColumn(Grid, "Mes", "COS01MES", 0, "", 70);
        //[MapField("COS01MES")]
        
            this.CreateGridColumn(Grid, "Cod.Linea", "COS01LINEACOD", 0, "", 90);
            this.CreateGridColumn(Grid, "Des.Linea", "PRO08DESC", 0, "", 120);            
          
          //actapoyo.COS01CTACBLE,
            this.CreateGridColumn(Grid, "Cod.CtaCtble", "COS01CTACBLE", 0, "", 90);
          //actapoyo.COS01DESCRIPCION
            this.CreateGridColumn(Grid, "Des.CtaCtble", "COS01DESCRIPCION", 0, "", 120);

            //distribucion.COS01TASADISTRIBUCION,
            this.CreateGridColumn(Grid, "Tasa %", "COS01TASADISTRIBUCION", 0, "", 90, true, false, true, true, "right");
            //distribucion.COS01IMPORTE,
            this.CreateGridColumn(Grid, "Importe", "COS01IMPORTE", 0, "{0:###,###0.00}", 90, true, false, true, true, "right");

            //distribucion.COS01IMPORTEDISTRIBUCION,	  
            this.CreateGridColumn(Grid, "Imp.Distribucion", "COS01IMPORTEDISTRIBUCION", 0, "{0:###,###0.00}", 90, true, false, true, true, "right");
            

            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "COS01IMPORTEDISTRIBUCION";
            summaryItem.FormatString = "{0:###,##0.00}";
            summaryItem.Aggregate = GridAggregateFunction.Sum;

            GridViewSummaryRowItem rowItem = new GridViewSummaryRowItem() { summaryItem };
            Grid.SummaryRowsBottom.Add(rowItem);
            Grid.MasterTemplate.ShowTotals = true;
            Grid.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }
        private void CargarDistribucion()
        {
            try
            {
                string codigolinea = Util.convertiracadena(this.gridLineas.CurrentRow.Cells["PRO08COD"].Value);
                List<ContaGastosxEmpresaxLinea> lista = TasasDistribucionLogic.Instance.TraerDistribucionesProduccion(Logueo.CodigoEmpresa,
                                                                                                                       Logueo.Anio,
                                                                                                                       Logueo.Mes,
                                                                                                                       Logueo.CodigoLinea);

                this.gridActDistribuida.DataSource = lista;
            }
            catch (Exception ex)
            { }
        }

        private void btnDistribuir_Click(object sender, EventArgs e)
        {
            TasasDistribucionLogic.Instance.CalcularDistribucionProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            CargarDistribucion();
        }

        private void gridLineas_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            CargarDistribucion();
        }
    }
}
