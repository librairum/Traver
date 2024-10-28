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
    public partial class FrmRepMovPorMesSum : frmBaseReporte
    {

        private frmMDI FrmParent { get; set; }
        private static FrmRepMovPorMesSum _aForm;

        public static FrmRepMovPorMesSum Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepMovPorMesSum(mdiPrincipal);
            _aForm = new FrmRepMovPorMesSum(mdiPrincipal);
            return _aForm;
        }
        public FrmRepMovPorMesSum(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
        }
        private void IniciarFormulario()
        {
            CargarPeriodos(cboperiodosini);
            CargarPeriodos(cboperiodosfin);
            cboperiodosfin.SelectedValue = Logueo.Mes;
            cboperiodosini.SelectedValue = Logueo.Mes;
            rbPeriodo.CheckState = CheckState.Checked;
            rbSalidas.CheckState = CheckState.Checked;

            Crearcolumnas();
            OnBuscar();
            //var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            //this.gridcontrol.DataSource = lista;
        }

        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGrid(this.gridControl);
            this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 160, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 400, true, false, true);
            this.CreateGridColumn(grilla, "Uni Med", "IN01UNIMED", 0, "", 90, true, false, true);
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
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                var lista = ArticuloLogic.Instance.TraerArticuloxNatyAlm(Logueo.CodigoEmpresa,
                    Logueo.Anio, Logueo.PS_codnaturaleza, "TO", "S");
                //var lista = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.PS_codnaturaleza,"S");
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar detalle");
                Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
        }


        protected override void OnVista()
        {
            var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
            var x = 0;


            foreach (var filaSeleccionado in gridControl.SelectedRows)
            {
                //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                codigosSeleccionados[x] = filaSeleccionado.Cells["IN01KEY"].Value.ToString();
                //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
                x++;
            }

            Cursor.Current = Cursors.WaitCursor;


            string ranfecini = "";
            string ranfecfin = "";

            string titulo = "";
            string Flag = "";

            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();

            DataTable datos = null;

            // Capturar fecha ini y fecha final 
            if (rbPeriodo.CheckState == CheckState.Checked)
            {
                ranfecini = this.cboperiodosini.SelectedValue.ToString();
                ranfecfin = this.cboperiodosfin.SelectedValue.ToString();
            }

            //

            if (rbSalidas.CheckState == CheckState.Checked)
            { Flag ="S";}
            else if (rbIngresos.CheckState == CheckState.Checked)
            { Flag = "E"; }

                titulo = "MOVIMIENTO POR MES";
                reporte.Nombre = "RptMovPorMesSum.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_MovPorMes(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Flag,Util.ConvertiraXML(codigosSeleccionados));
            

            //
            reporte.DataSource = datos;

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("titulo", titulo));
            
            ReporteControladora controles = new ReporteControladora(reporte);
            controles.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
        protected override void OnSeleccionarTodo()
        {
            gridControl.SelectAll();
        }
       
    }
}
