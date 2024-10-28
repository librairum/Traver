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
    
    public partial class FrmRepMovPorResponsable: frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static FrmRepMovPorResponsable _aForm;
        public static FrmRepMovPorResponsable Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepMovPorResponsable(mdiPrincipal);
            _aForm = new FrmRepMovPorResponsable(mdiPrincipal);
            return _aForm;
        }

        public FrmRepMovPorResponsable(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
           
        }
        public FrmRepMovPorResponsable()
        {
            InitializeComponent();
        }
        private void FrmRepMovPorResponsable_Load(object sender, EventArgs e)
        {
                  
            //
            this.rbtrangoperiodo.CheckState = CheckState.Checked;
            // Llenar combo mese
            CargarPeriodos(cbomesini);
            CargarPeriodos(cbomesfin);
        
            // Periodo por defecto
            this.cbomesini.SelectedValue = DateTime.Now.Month.ToString("0#"); 
            this.cbomesfin.SelectedValue = DateTime.Now.Month.ToString("0#");

            // llenar grilla
            Crearcolumnas();
            OnBuscar();
       }

        
        private void Crearcolumnas()
        {
            RadGridView grilla = this.CreateGrid(this.gridcontrol);
            this.CreateGridColumn(grilla, "Codigo", "codigo", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "nombre", 0, "", 277, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "tipo", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilla, "Desc Tipo", "TipoDesc", 0, "", 100, true, false, true);
        }
       protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            string ranfecini = "";
            string ranfecfin = "";

            string titulo = "";
           // string subtitulo = "";
            
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptMoviPorResponsableSum.rpt";
            DataTable datos = null;

            // Parametros
            ranfecini = this.cbomesini.SelectedValue.ToString();
            ranfecfin = this.cbomesfin.SelectedValue.ToString();

           string ResponsableCodigo = Util.GetCurrentCellText(gridcontrol.CurrentRow, "codigo");
           string ResponsableTipo = Util.GetCurrentCellText(gridcontrol.CurrentRow, "tipo");


            //Funciones
                titulo = "MOVIMIENTO POR RESPONSABLE";
                
                //if (ranfecini == ranfecfin)
                //{
                //    subtitulo = ranfecini + "-" + Logueo.Anio;
                //}
                //else
                //{
                //    subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                //}

                var codigosSeleccionados = new string[gridcontrol.SelectedRows.Count];
                var x = 0;
                foreach (var filaSeleccionado in gridcontrol.SelectedRows)
                {
                    //codigosSeleccionados[x] = (string)gridControl.Columns["CodigoEmpleado"].value((int) filaSeleccionado);
                    codigosSeleccionados[x] = filaSeleccionado.Cells["codigo"].Value.ToString();
                    //e.CellElement.RowInfo.Cells["Title"].Value.ToString();
                    x++;
                }

                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_MovXResponsable(Logueo.CodigoEmpresa, Logueo.Anio, "P",
                ranfecini, ranfecfin, ResponsableTipo, ResponsableCodigo, Util.ConvertiraXML(codigosSeleccionados));

            //
            reporte.DataSource = datos;

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("titulo", titulo));
            //reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));
            //reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
           
            ReporteControladora controles = new ReporteControladora(reporte);
            controles.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
        protected override void OnBuscar()
        {
            var lista = ResponsableLogic.Instance.TraerResponsableXAlm(Logueo.CodigoEmpresa);
            this.gridcontrol.DataSource = lista;
        }
        private void CargarPeriodos(RadDropDownList cbo )
        {
            try
            {
                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa,Logueo.Anio);
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
        protected override void OnSeleccionarTodo()
        {
            gridcontrol.SelectAll();
        }
       
        
    }
}