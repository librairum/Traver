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
    public partial class FrmRepTransaccionesSuministro : frmBaseReporte
    {

        private frmMDI FrmParent { get; set; }
        private static FrmRepTransaccionesSuministro _aForm;

        public static FrmRepTransaccionesSuministro Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepTransaccionesSuministro(mdiPrincipal);
            _aForm = new FrmRepTransaccionesSuministro(mdiPrincipal);
            return _aForm;
        }
        public FrmRepTransaccionesSuministro(frmMDI padre)
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
            dtpfechaIni.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            rbPeriodo.CheckState = CheckState.Checked;
            rbDetallado.CheckState = CheckState.Checked;

            Crearcolumnas();
            CrearColumnasArti();
            CargarArticulos();
            CargarAlmacenes(cboalmacenes);
            OnBuscar();

           // rbTransacciones.IsChecked = true;
            //var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento1(Logueo.CodigoEmpresa);
            //this.gridcontrol.DataSource = lista;
        }

        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGrid(this.gridControl);

            this.CreateGridColumn(grilla, "Codigo", "In12tipDoc", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "In12DesLar", 0, "", 277, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "in12TipMov", 0, "", 50, true, false, true);
        }
        private void CrearColumnasArti() 
        {
            //RadGridView grilla = this.CreateGrid(this.gridArticulos);

            //this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 80, true, false, true);
            //this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 277, true, false, true);
        }
        private void CargarAlmacenes(RadDropDownList cbo)
        {
            try
            {

                var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.PS_codnaturaleza);
                //--AlmacenLogic.Instance.AlmacenesMasTodos(Logueo.CodigoEmpresa);                
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los alamcenes
                cbo.SelectedValue = Logueo.PS_AlmaxDefectoStock;
            }


            catch (Exception ex)
            {
                //RadMessageBox.Show(ex.Message, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);

            }
        }

        private void CargarArticulos() 
        {
            //try 
            //{
            //    DataTable dt = ArticuloLogic.Instance.TraerRepCatalogo(Logueo.CodigoEmpresa,Logueo.Anio);
            //    gridArticulos.DataSource = dt;
            //}catch(Exception ex)
            //{
            //    Util.ShowError("error en cargar articulo");
            //}
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
            //var lista = TipoDocumentoLogic.Instance.TraerTipoDocumentoxNaturaleza(Logueo.CodigoEmpresa, Logueo.PS_codnaturaleza);
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumentoxNaturaleza(Logueo.CodigoEmpresa, Logueo.PS_codnaturaleza);

            this.gridControl.DataSource = lista;
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
                titulo = "ANALISIS POR TRANSACCION - DETALLADO";
                reporte.Nombre = Logueo.sedetipodondeseejecutaelsistema == "ADMINISTRACION" ? "RptTransaccionSumiVal.rpt" : "RptTransaccionSumi.rpt";
                reporte.Nombre = "RptTransaccionSumiVal.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransaccionSum(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Util.ConvertiraXML(codigosSeleccionados),this.cboalmacenes.SelectedValue.ToString(), Flag);

            }
            else if (rbResumido.CheckState == CheckState.Checked)
            {
                titulo = "ANALISIS POR TRANSACCION - RESUMIDO";
                reporte.Nombre = Logueo.sedetipodondeseejecutaelsistema == "ADMINISTRACION" ? "RptTransaccionSumiResVal.rpt" : "RptTransaccionSumiRes.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransaccionSum(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Util.ConvertiraXML(codigosSeleccionados), this.cboalmacenes.SelectedValue.ToString(), Flag);

            }
            else if (rbIngresolima.CheckState == CheckState.Checked)
            {
                titulo = "ANALISIS POR TRANSACCION - INGRESO CONTABILIDAD";
                reporte.Nombre = Logueo.sedetipodondeseejecutaelsistema == "ADMINISTRACION" ? "RptTransaccionSumiIngLimaVal.rpt" : "RptTransaccionSumiIngLima.rpt";
                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_TransaccionSum(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Util.ConvertiraXML(codigosSeleccionados), this.cboalmacenes.SelectedValue.ToString(), Flag);
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
      //  private void SeleccionarFilaGrilla(DataGridView data) 
      //  {
      //      try 
      //      {
      //             // Verificar si hay al menos una fila seleccionada
      //          if (data.SelectedRows.Count > 0)
      //     {
     
      //  // Aquí puedes acceder a
      // // la fila seleccionada y realizar la lógica deseada
      //         DataGridViewRow filaSeleccionada = data.SelectedRows[0];
      //  // Por ejemplo, obtener el valor de una celda
      ////  string valorCelda = filaSeleccionada.Cells["NombreColumna"].Value.ToString();
        
      //  // Realizar cualquier otra acción necesaria con la fila seleccionada
      //  //MessageBox.Show("Se seleccionó la fila en");
      //   }
   

      //      }catch(Exception ex)
      //      {
      //          Util.ShowError("ERROR");
      //      }
      //  }
        protected override void OnSeleccionarTodo()
        {
            try
            {
                
                gridControl.SelectAll();
                //if (rbTransacciones.IsChecked)
                //{
                //    gridControl.SelectAll();
                //  //  gridArticulos.ClearSelection();
                //}
                //if (rbArticulos.IsChecked)
                //{
                //    gridArticulos.SelectAll();
                //}
            }
            catch (Exception ex)
            {
                Util.ShowError("ERROR :: en las grillas");
            }

         //   gridControl.SelectAll();
        }
   
       
    }
}
