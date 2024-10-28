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
    public partial class frmRepTransaccionesMP : frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static frmRepTransaccionesMP _aForm;
        public frmRepTransaccionesMP(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            IniciarFormulario();
        }
       public static frmRepTransaccionesMP Instance(frmMDI mdiPrincipal) 
        {
            if (_aForm != null) return new frmRepTransaccionesMP(mdiPrincipal);
            _aForm = new frmRepTransaccionesMP(mdiPrincipal);
            return _aForm;
        }
        private void Crearcolumnas()
        {         
            RadGridView grilla = this.CreateGrid(this.gridControl);

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
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumentoxNaturaleza(Logueo.CodigoEmpresa, Logueo.MP_codnaturaleza);
            this.gridControl.DataSource = lista;
        }
        private void CargarAlmacenes(RadDropDownList cbo)
        {
            try
            {
                var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.MP_codnaturaleza);
                //var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.MP_codnaturaleza);
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los alamcenes
                cbo.SelectedValue = Logueo.MP_AlmxDefecto;
            }


            catch (Exception)
            {

                throw;
            }
        }
        private void IniciarFormulario()
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

            Crearcolumnas();
            OnBuscar();
            //var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            //this.gridcontrol.DataSource = lista;

            

        }
        protected override void OnVista()
        {
            var codigosSeleccionados = new string[gridControl.SelectedRows.Count];
            var x = 0;


            foreach (var filaSeleccionado in gridControl.SelectedRows)
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
                reporte.Nombre = "RptTransacMPDet.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransaccionMP(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini, ranfecfin, 
                                               Flag, Logueo.MP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));
                //datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_Transaccion_Res(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                //ranfecfin, Util.ConvertiraXML(codigosSeleccionados), Flag);

            }
            else if (rbtResumido.CheckState == CheckState.Checked)
            {
                titulo = "ANALISIS POR TIPO DE TRANSACCION - RESUMIDO";
                reporte.Nombre = "RptTransacMPRes.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransaccionMP(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini, ranfecfin,
                                               Flag, Logueo.MP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));
                //datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_Transaccion_Res(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                //ranfecfin, Util.ConvertiraXML(codigosSeleccionados), Flag);

            }
            else if (rbsalidasporproduccion.CheckState == CheckState.Checked)
            {
                titulo = "SALIDA POR PRODUCCION";
                reporte.Nombre = "RptTransaSalMpaProd.rpt";
                //datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TranSalMPaProd(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                //ranfecfin, Flag, Util.ConvertiraXML(codigosSeleccionados));
                
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TranSalMPaProd(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini, ranfecfin,
                    Flag, Logueo.MP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));
            }
            
            else if (rbingresoxcompra.CheckState == CheckState.Checked)
            {
                titulo = "INGRESO POR COMPRA";
                reporte.Nombre = "RptTransacMPIngxCompra.rpt";

                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransIngXCompra(Logueo.CodigoEmpresa, Logueo.Anio, 
                    ranfecini, ranfecfin, Flag, Logueo.MP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));
            }
            else if (rbingresoxcompralima.CheckState == CheckState.Checked)
            {
                titulo = "INGRESO POR COMPRA LIMA";
                reporte.Nombre = "RptTransacMPIngxCompraLima.rpt";

                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransIngXCompra(Logueo.CodigoEmpresa, Logueo.Anio,
                    ranfecini, ranfecfin, Flag, Logueo.MP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));
            }

            else if (rbtsalidaxlinea.CheckState == CheckState.Checked)
            {
                titulo = "SALIDA POR LINEA DE PRODUCCION";
                reporte.Nombre = "RptTransacMPResXlinea.rpt";

                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransaccionMP(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini, ranfecfin,
                                               Flag, Logueo.MP_codnaturaleza, almacen, Util.ConvertiraXML(codigosSeleccionados));
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
        protected override void OnSeleccionarTodo()
        {
            gridControl.SelectAll();
        }
       

    }
}
