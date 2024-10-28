using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;

namespace Inv.UI.Win
{
    public partial class FrmAnalisisCentroCosto : frmBaseReporte
    {

        private frmMDI FrmParent { get; set; }
        private static FrmAnalisisCentroCosto _aForm;

        public static FrmAnalisisCentroCosto Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmAnalisisCentroCosto(mdiPrincipal);
            _aForm = new FrmAnalisisCentroCosto(mdiPrincipal);
            return _aForm;
        }
        public FrmAnalisisCentroCosto(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
            Cargar();
            //HabilitarBotones(false,false,false,false,false,true);
            rbPeriodo.IsChecked = true;
        }
        public void Cargar() 
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = DocumentoLogic.Instance.Trae_Centros_Costo(Logueo.CodigoEmpresa, Logueo.Anio);
            this.gridControl.DataSource = dt;
          //  HabilitarBotones(false,false,false,false,false,true);
        }
        private void IniciarFormulario()
        {
            CargarPeriodos(cboperiodos);
            
           // CargarPeriodos(cboperiodosfin);
            //cboperiodosfin.SelectedValue = Logueo.Mes;
            cboperiodos.SelectedValue = Logueo.Mes;
            dtpfechaIni.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            rbDetallada.CheckState = CheckState.Checked;
           // rbDetallado.CheckState = CheckState.Checked;

            Crearcolumnas();
            Cargar();
            //var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            //this.gridcontrol.DataSource = lista;
        }

        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGrid(this.gridControl);
            this.CreateGridColumn(gridControl, "Codigo", "ccb02cod", 0, "", 100, true,false,true);
            this.CreateGridColumn(gridControl, "Descripcion", "ccb02des", 0, "", 300, true, false, true);
            this.CreateGridColumn(gridControl, "flag", "flag", 0, "", 50, false, true, false);
            //grilla.Columns.Add("In21codigo", "Codigo", "In21codigo");

            //grilla.Columns.Add("In21descri", "Descripcion", "In21descri");
            //grilla.Columns[0].Width = 100;
            //grilla.Columns[1].Width = 300;
            //grilla.AllowEditRow = false;
        }
        private void crearGrilla()
        {
           
        }
        private void CargarPeriodos(RadDropDownList cbo)
        {
            try
            {

                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa, Logueo.Anio);
                cbo.DataSource = periodo;
                cbo.DisplayMember = "ccb03des";
                cbo.ValueMember = "ccb03cod";
                string anio = "";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();

                cbo.SelectedValue = anio + mes;
            }


            catch (Exception)
            {

                throw;
            }
        }

        protected override void OnBuscar()
        {
            //var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumentoxNaturaleza(Logueo.CodigoEmpresa, Logueo.PS_codnaturaleza);
            this.gridControl.DataSource = lista;
        }

        //protected override void OnEliminar()
        //{
           
        //    bool respuesta = Util.ShowQuestion("¿Dese eliminar el documento?");
        //    if (respuesta == false) { return; }
        //    string @cMsgRetorno = "";
        //    TipoDocumentoLogic.Instance.Eliminar_Rango_Impresion(Logueo.CodigoEmpresa, Logueo.nomPerfil, "TRANSA", out @cMsgRetorno);
        //    Util.ShowMessage(@cMsgRetorno, 1);
        //    Cargar();
        //}
        public void InsertarRangoImpresion() 
        {
            string Msg = "";
            CentroCostoLogic.Instance.Insertar_RangoImpresion(Logueo.CodigoEmpresa, Logueo.nomPerfil, "RepCenCos", "", out Msg);
            Util.ShowMessage(Msg,1);
        }
        protected override void OnVista()
        {
            try
            {
                string xml = "";
                string[] arreglo = new string[this.gridControl.SelectedRows.Count];
                int x = 0;
                string periodos = cboperiodos.Text;
                DataTable dt = new DataTable();
                
                foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                {
                    arreglo[x] = 
                                 Util.GetCurrentCellText(fila, "ccb02cod") + "|" + // 8
                                 Util.GetCurrentCellText(fila, "ccb02des") + "|" + // 9
 

                    x++;
                }
                //OBTENER PERIODO 12 - 2023
               

                xml = Util.ConvertiraXMLdinamico(arreglo);
                string @cMoneda = "S";
                if (rbPeriodo.IsChecked)
                {
                    string Mes = this.cboperiodos.SelectedValue.ToString();
                    string Periodo = "PER";
                    dt = CentroCostoLogic.Instance.TraerReporte_DetCentroCosto(Logueo.CodigoEmpresa, xml, Logueo.Anio, Mes, "", "", Periodo, @cMoneda);
                }
                else if(rbPorFechas.IsChecked)
                {
                     dt = CentroCostoLogic.Instance.TraerReporte_DetCentroCosto(Logueo.CodigoEmpresa, xml, Logueo.Anio, Logueo.Mes, dtpfechaIni.Text, dtpFechaFin.Text, "", @cMoneda);

                }
                  string anio = "";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();
                
                cboperiodos.SelectedValue = anio + mes;
                if (rbDetallada.IsChecked)
                {
                    string FechaInicio =dtpfechaIni.Text;
                    string FechaFin = dtpFechaFin.Text;
                    if (Logueo.sedetipodondeseejecutaelsistema == "ADMINISTRACION")
                    {
                        Reporte reporte = new Reporte("SqlDetCenCosVal.rpt");
                        reporte.Ruta = Logueo.GetRutaReporte();
                        reporte.DataSource = dt;
                        ReporteControladora controles = new ReporteControladora(reporte);
                        reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                        reporte.FormulasFields.Add(new Formula("TituloReporte", "Reporte Centro Costo Detallada"));
                        reporte.FormulasFields.Add(new Formula("Periodo", Logueo.Anio.ToString() + Logueo.Mes.ToString()));
                        reporte.FormulasFields.Add(new Formula("Importe", ""));
                        reporte.FormulasFields.Add(new Formula("NombreMoneda", ""));
                        controles.VistaPrevia(enmWindowState.Normal);
                        Cursor.Current = Cursors.Default;
                    }
                    else 
                    {
                        Reporte reporte = new Reporte("SqlDetCenCos.rpt");
                        reporte.Ruta = Logueo.GetRutaReporte();
                        reporte.DataSource = dt;
                        ReporteControladora controles = new ReporteControladora(reporte);
                        reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                        reporte.FormulasFields.Add(new Formula("TituloReporte", "Reporte Centro Costo Resumida"));
                        reporte.FormulasFields.Add(new Formula("Periodo", Logueo.Anio.ToString() + Logueo.Mes.ToString()));
                        reporte.FormulasFields.Add(new Formula("Importe", Logueo.Mes));
                        reporte.FormulasFields.Add(new Formula("NombreMoneda", Logueo.Mes));
                        controles.VistaPrevia(enmWindowState.Normal);
                        Cursor.Current = Cursors.Default;
                    }
          

                }
                else if (rbResumida.IsChecked)
                {
                    Reporte reporte = new Reporte("SqlResCenCos.rpt");
                    reporte.Ruta = Logueo.GetRutaReporte();
                    reporte.DataSource = dt;
                    ReporteControladora controles = new ReporteControladora(reporte);
                    reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                    reporte.FormulasFields.Add(new Formula("TituloReporte", "Reporte Centro Costo Resumida"));
                    reporte.FormulasFields.Add(new Formula("Periodo", anio.ToString() + mes.ToString()));
                   // reporte.FormulasFields.Add(new Formula("Importe", Logueo.Mes));
                   // reporte.FormulasFields.Add(new Formula("NombreMoneda", Logueo.Mes));

                    controles.VistaPrevia(enmWindowState.Normal);
 

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex) 
            {
                Util.ShowError("ERROR ==> "+ ex.Message);
            }
        }
        protected override void OnSeleccionarTodo()
        {
            gridControl.SelectAll();
        }

    }
}
