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

namespace Prod.UI.Win
{
    public partial class FrmRepTransaccionesPP : frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static FrmRepTransaccionesPP _aForm;
        
        public FrmRepTransaccionesPP(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            rbingresoxcompra.Visible = false;
            rbsalidasporproduccion.Visible = false;
            
            iniciarformulario();
        }
        public static FrmRepTransaccionesPP Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepTransaccionesPP(mdiPrincipal);
            _aForm = new FrmRepTransaccionesPP(mdiPrincipal);
            return _aForm;
        }
        private void CrearColumnas()
        {
            RadGridView grilla = this.CreateGrid(this.gridControl);
            this.CreateGridColumn(grilla, "Codigo", "In12tipDoc", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "In12DesLar", 0, "", 277, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "in12TipMov", 0, "", 50, true, false, true);
        }
        private void iniciarformulario()
        {
            CargarAlmacenes(this.cboalmacenes);
            CargarPeriodos(cboperiodosini);
            CargarPeriodos(cboperiodosfin);
            cboperiodosfin.SelectedValue = Logueo.Mes;
            cboperiodosini.SelectedValue = Logueo.Mes;
            dtpfechaIni.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            rbtPeriodo.CheckState = CheckState.Checked;
            rbDetallado.CheckState = CheckState.Checked;
            CrearColumnas();
            OnBuscar();
        }
        private void CargarAlmacenes(RadDropDownList cbo)
        {
            try
            {
                var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.PP_codnaturaleza);
                //var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.MP_codnaturaleza);
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los alamcenes
                cbo.SelectedValue = Logueo.PP_AlmxDefecto;
            }


            catch (Exception)
            {

                throw;
            }
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
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumentoxNaturaleza(Logueo.CodigoEmpresa, Logueo.PP_codnaturaleza);
            this.gridControl.DataSource = lista;
        }

        protected override void OnVista()
        {
            var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
            var x = 0;


            foreach (var filaSeleccionado in gridControl.SelectedRows)
            {
                codigosSeleccionados[x] = filaSeleccionado.Cells["In12tipDoc"].Value.ToString();
                x++;
            }
            Cursor.Current = Cursors.WaitCursor;


            string ranfecini = "";
            string ranfecfin = "";

            string titulo = "";
            string subtitulo = "";
            string Flag = "";

            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();

            DataTable datos = null;
            string almacen = this.cboalmacenes.SelectedValue.ToString();
            // Capturar fecha ini y fecha final 
            if (rbtPeriodo.CheckState == CheckState.Checked)
            {
                ranfecini = this.cboperiodosini.SelectedValue.ToString();
                ranfecfin = this.cboperiodosfin.SelectedValue.ToString();
                Flag = "P";

                if (ranfecini == ranfecfin)
                {
                    subtitulo = ranfecini + "-" + Logueo.Anio;
                }
                else
                {
                    subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                }
            }
            else if (rbtFecha.CheckState == CheckState.Checked)
            {
                ranfecini = string.Format("{0:dd/MM/yyyy}", this.dtpfechaIni.Value);
                ranfecfin = string.Format("{0:dd/MM/yyyy}", this.dtpFechaFin.Value);
                Flag = "R";
                subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
            }

            //
            if (rbDetallado.CheckState == CheckState.Checked)
            {
                titulo = "ANALISIS POR TIPO DE TRANSACCION - DETALLADO";
                reporte.Nombre = "RptTransacPPDet.rpt";
                
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Rep_TransaccionPP(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini, ranfecfin,
                                               Flag, Logueo.PP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));              

            }
            else if (rbtResumido.CheckState == CheckState.Checked)
            {
                titulo = "ANALISIS POR TIPO DE TRANSACCION - RESUMIDO";
                reporte.Nombre = "RptTransacPPRes.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Pro_Rep_TransaccionPP(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini, ranfecfin,
                                               Flag, Logueo.PP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));
            }           
          
            
            reporte.DataSource = datos;

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("titulo", titulo));
            reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

            ReporteControladora controles = new ReporteControladora(reporte);
            controles.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
    }
}
