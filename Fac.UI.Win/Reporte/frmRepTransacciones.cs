﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
namespace Fac.UI.Win
{
    public partial class frmRepTransacciones : frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static frmRepTransacciones _aForm;
        public static frmRepTransacciones Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmRepTransacciones(mdiPrincipal);
            _aForm = new frmRepTransacciones(mdiPrincipal);
            return _aForm;
        }
        
        public frmRepTransacciones(frmMDI padre) {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
        }
        public frmRepTransacciones()
        {
            InitializeComponent();
            IniciarFormulario();         
        }

        private void frmRepTransacciones_Load(object sender, EventArgs e)
        {

        }

        private void IniciarFormulario()
        {
            CargarPeriodos(cboperiodosini);
            CargarPeriodos(cboperiodosfin);
            cboperiodosfin.SelectedValue = Logueo.Mes;
            cboperiodosini.SelectedValue = Logueo.Mes;
            dtpfechaIni.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            rbPeriodo.CheckState = CheckState.Checked;
            rbDetallado.CheckState = CheckState.Checked;

            Crearcolumnas();
            OnBuscar();
            //var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            //this.gridcontrol.DataSource = lista;
        }

        private void Crearcolumnas()
        {
            //this.gridcontrol.Columns.Clear();
            //this.gridcontrol.AllowAddNewRow = false;
            //this.gridcontrol.ShowGroupPanel = false;
            //this.gridcontrol.ShowFilteringRow = true;
            //this.gridcontrol.AllowColumnReorder = true;

            //this.gridcontrol.AutoGenerateColumns = false;
            ////this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            ////this.gridControl.AllowSearchRow = true;
            ////this.gridControl.SearchRowPosition = SystemRowPosition.Top;

            //this.gridcontrol.EnableHotTracking = true;
            //this.gridcontrol.ShowFilteringRow = true;
            //this.gridcontrol.EnableFiltering = true;
            RadGridView grilla =  this.CreateGrid(this.gridcontrol);

            this.CreateGridColumn(grilla, "Codigo", "In12tipDoc", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "In12DesLar", 0, "", 277, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "in12TipMov", 0, "", 50, true, false, true);


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
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            this.gridcontrol.DataSource = lista;
        }
        protected override void OnVista()
        {
            var codigosSeleccionados = new string[gridcontrol.SelectedRows.Count];
            var x = 0;


            foreach (var filaSeleccionado in gridcontrol.SelectedRows)
            {
                //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                codigosSeleccionados[x] = filaSeleccionado.Cells["In12tipDoc"].Value.ToString();
                //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
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

            // Capturar fecha ini y fecha final 
            if (rbPeriodo.CheckState == CheckState.Checked)
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
            else if (rbFecha.CheckState == CheckState.Checked)
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
                reporte.Nombre = "RptTransaccionDetallado.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_Transaccion_Res(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Util.ConvertiraXML(codigosSeleccionados), Flag);

            }
            else if (rbResumido.CheckState == CheckState.Checked)
            {
                titulo = "ANALISIS POR TIPO DE TRANSACCION - RESUMIDO";
                reporte.Nombre = "RptTransaccionResumido.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_Transaccion_Res(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Util.ConvertiraXML(codigosSeleccionados), Flag);

            }
            else if (rbsalidasporventas.CheckState == CheckState.Checked)
            {
                titulo = "SALIDA POR VENTA";
                reporte.Nombre = "RptMoviDocRespaldo.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_MovXDocRespaldo(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Flag, Util.ConvertiraXML(codigosSeleccionados));
            }
            else if (rbsalidasporventasguia.CheckState == CheckState.Checked)
            {
                titulo = "SALIDA POR VENTA POR DOC RESPALDO";
                reporte.Nombre = "RptMoviDocRespaldoGuia.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_MovXDocRespaldo(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Flag, Util.ConvertiraXML(codigosSeleccionados));
            }
            else if (rbingresoxproduccion.CheckState == CheckState.Checked)
            {
                titulo = "INGRESO POR PRODUCCION";
                reporte.Nombre = "RptIngresoProduccion.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_IngProduccion(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Flag, Logueo.TipoAnalisisFabricante, Util.ConvertiraXML(codigosSeleccionados));
            }

            //
            reporte.DataSource = datos;

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("titulo", titulo));
            reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

            ReporteControladora controles = new ReporteControladora(reporte);
            controles.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        
    }
}
