using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI;

namespace Inv.UI.Win
{
    public partial class FrmRepKardexSuministro : frmBaseReporte
    {

        RadGridView grilla;
        ColumnGroupsViewDefinition columnGroupsView;
        private bool isLoaded = false;
        private frmMDI FrmParent { get; set; }
        private static FrmRepKardexSuministro _aForm;

        public static FrmRepKardexSuministro Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepKardexSuministro(mdiPrincipal);
            _aForm = new FrmRepKardexSuministro(mdiPrincipal);
            return _aForm;
        }
        public FrmRepKardexSuministro(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
         
            // Establecer el mes por defecto
            rbtrangoperiodo.CheckState = CheckState.Checked;
            rbtopcdetallado.CheckState = CheckState.Checked;

            //Cargar alamcenes
            CargarAlmacenes(cboalmacenes);

            // Llenar combo mese
            CargarPeriodos(cbomesini);
            CargarPeriodos(cbomesfin);

            // Periodo por defecto
            this.cbomesini.SelectedValue = Logueo.Mes;
            this.cbomesfin.SelectedValue = Logueo.Mes;


            this.dtpFechaini.Value = DateTime.Now;
            this.dtpFechafin.Value = DateTime.Now;

            OnBuscar();
        }
        private void Crearcolumnas()
        {
            grilla = this.CreateGrid(this.gridControl);

            this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 160, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 400, true, false, true);
            this.CreateGridColumn(grilla, "Uni Med", "IN01UNIMED", 0, "", 90, true, false, true);
        }
        protected override void OnBuscar()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (isLoaded == false) return;                    
            try
            {
                
                var lista = ArticuloLogic.Instance.TraerArticuloxNatyAlm(Logueo.CodigoEmpresa,
                    Logueo.Anio, Logueo.PS_codnaturaleza, cboalmacenes.SelectedValue.ToString(),"S");
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
            //string mensajeOut = string.Empty;

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

            string almacen;
            string ranfecini;
            string ranfecfin;
            string flag;
            string subtitulo;

            almacen = this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);

            if (rbtrangoperiodo.CheckState == CheckState.Checked)
            {

                ranfecini = this.cbomesini.SelectedValue.ToString().Substring(0, 2);
                ranfecfin = this.cbomesfin.SelectedValue.ToString().Substring(0, 2);
                flag = "P";

                if (ranfecini == ranfecfin)
                {
                    subtitulo = ranfecini + "-" + Logueo.Anio;
                }
                else
                {
                    subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                }


            }
            else
            {
                ranfecini = string.Format("{0:dd/MM/yyyy}", this.dtpFechaini.Value);
                ranfecfin = string.Format("{0:dd/MM/yyyy}", this.dtpFechafin.Value);
                subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                flag = "R";
            }
            string @sedeTipo = Logueo.sedetipodondeseejecutaelsistema.ToUpper() == "ADMINISTRACION" ? "A" : "P";
            string @xml = Util.ConvertiraXML(codigosSeleccionados);
            var datos = DocumentoLogic.Instance.RptKardexSuministros(Logueo.CodigoEmpresa, Logueo.Anio, almacen,
                                    ranfecini, ranfecfin, flag, Util.ConvertiraXML(codigosSeleccionados), @sedeTipo);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();

            if (rbtopcdetallado.CheckState == CheckState.Checked)
            {
           
                reporte.Nombre = Logueo.sedetipodondeseejecutaelsistema.ToUpper() == "ADMINISTRACION" ? "RptKardexSumVal.rpt" : "RptKardexSum.rpt";
                reporte.DataSource = datos;
            }
            else if (rbtopcresumido.CheckState == CheckState.Checked)
            {
           
                reporte.Nombre = Logueo.sedetipodondeseejecutaelsistema.ToUpper() == "ADMINISTRACION" ? "RptkardexSumResVal.rpt" : "RptkardexSumRes.rpt";
                reporte.DataSource = datos;
            }

       
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
                reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));
                reporte.FormulasFields.Add(new Formula("Mes", this.cbomesini.SelectedValue.ToString().Substring(0, 2)));
            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

            Cursor.Current = Cursors.Default;
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

                cbo.SelectedValue = anio;
            }


            catch (Exception)
            {

                throw;
            }
        }
        private void CargarAlmacenes(RadDropDownList cbo)
        {
            try
            {
                //var almacen = AlmacenLogic.Instance.AlmacenesMasTodos(Logueo.CodigoEmpresa);
                var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.PS_codnaturaleza);
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los alamcenes
                cbo.SelectedValue = Logueo.PT_AlmxDefecto;
            }


            catch (Exception)
            {

                throw;
            }
        }
        private void cboalmacenes_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                OnBuscar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar detalle");
            }
            
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            OnBuscar();
        }
        private void FrmRepKardexSuministro_Load(object sender, EventArgs e)
        {
            try
            {
                Crearcolumnas();
                isLoaded = true;
                OnBuscar();
                HabilitarBotones(true, true, false, false,true);

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar formulario");
            }
            
        }
       
        protected override void OnSeleccionarTodo()
        {
            gridControl.SelectAll();
        }
    }
}
