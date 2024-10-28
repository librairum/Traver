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

namespace Fac.UI.Win
{
    public partial class FrmRepProvMateriaPrima: frmBaseReporte
    {
        private frmMDI FrmParent { get; set; }
        private static FrmRepProvMateriaPrima _aForm;
        public static FrmRepProvMateriaPrima Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepProvMateriaPrima(mdiPrincipal);
            _aForm = new FrmRepProvMateriaPrima(mdiPrincipal);
            return _aForm;
        }

        public FrmRepProvMateriaPrima(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
           
        }
        public FrmRepProvMateriaPrima()
        {
            InitializeComponent();
        }
        private void FrmRepProvMateriaPrima_Load(object sender, EventArgs e)
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
            this.CreateGridColumn(grilla, "Codigo", "In12tipDoc", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "In12DesLar", 0, "", 277, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "in12TipMov", 0, "", 50, true, false, true);
         }
       protected override void OnVista()
        {
            var codigosSeleccionados = new string[gridcontrol.SelectedRows.Count];
            var x = 0;


            foreach (var filaSeleccionado in gridcontrol.SelectedRows)
            {
                codigosSeleccionados[x] = filaSeleccionado.Cells["In12tipDoc"].Value.ToString();
                x++;
            }

            Cursor.Current = Cursors.WaitCursor;


            string ranfecini = "";
            string ranfecfin = "";

            string titulo = "";
            string subtitulo = "";
            
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptSalxProvMatPrima.rpt";
            DataTable datos = null;

            // Parametros
            ranfecini = this.cbomesini.SelectedValue.ToString();
            ranfecfin = this.cbomesfin.SelectedValue.ToString();

            //Funciones
                titulo = "SALIDAS POR PROVEEDOR DE MATERIA PRIMA";
                
                if (ranfecini == ranfecfin)
                {
                    subtitulo = ranfecini + "-" + Logueo.Anio;
                }
                else
                {
                    subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                }


                datos = TipoDocumentoLogic.Instance.Spu_Inv_Rep_ProvMatPriSalida(Logueo.CodigoEmpresa, Logueo.Anio, ranfecini,
                ranfecfin, Util.ConvertiraXML(codigosSeleccionados), Util.ConvertiraXML(codigosSeleccionados),Logueo.TipoAnalisisMateriaPrima);

            
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
        protected override void OnBuscar()
        {
            var lista = TipoDocumentoLogic.Instance.TraerTipoDocumento2(Logueo.CodigoEmpresa,"S");
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

        
    }
}