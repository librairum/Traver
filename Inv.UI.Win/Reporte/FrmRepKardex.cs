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
    public partial class FrmRepKardex : frmBaseReporte
    {
        private bool isLoaded = false;
        RadGridView grilla;
        ColumnGroupsViewDefinition columnGroupsView;
        private void FrmRepKardex_Load(object sender, EventArgs e)
        {
            Crearcolumnas();
            isLoaded = true;
            OnBuscar();
            HabilitarBotones(true, true, true,false,true);
            //gestionarBotones(ElementVisibility.Visible, ElementVisibility.Visible, ElementVisibility.Visible);
        }
         private frmMDI FrmParent { get; set; }
         private static FrmRepKardex _aForm;

        public static FrmRepKardex Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmRepKardex(mdiPrincipal);
            _aForm = new FrmRepKardex(mdiPrincipal);
            return _aForm;
        }

        public FrmRepKardex(frmMDI padre)
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

        public FrmRepKardex()
        {
            InitializeComponent();
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
        }

        private void Crearcolumnas()
        {
             grilla =  this.CreateGrid(this.gridControl);

            this.CreateGridColumn(grilla, "Codigo", "IN01KEY", 0, "", 160, true, false, true);
            this.CreateGridColumn(grilla, "Descripcion", "IN01DESLAR", 0, "", 400, true, false, true);
            this.CreateGridColumn(grilla, "Unidad Medida", "IN01UNIMED", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilla, "Tipo", "tipo", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Color.", "color", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilla, "Tonalidad", "tonalidad", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Formato", "formato", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Acabado", "acabado", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Relleno", "relleno", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Borde", "borde", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Modelo", "modelo", 0, "", 90, true, false, true);
            crearGrupos();
        }
        private void crearGrupos() {
            this.columnGroupsView = new ColumnGroupsViewDefinition();
            this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("Producto"));
            this.columnGroupsView.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
              
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN01KEY"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN01DESLAR"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["IN01UNIMED"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["tipo"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["color"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["tonalidad"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["formato"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["acabado"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["relleno"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["borde"]);
            this.columnGroupsView.ColumnGroups[0].Rows[0].Columns.Add(this.gridControl.Columns["modelo"]);
            this.gridControl.ViewDefinition = columnGroupsView;
                        
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.PT_codnaturaleza);
            
            this.gridControl.DataSource = lista;
        }
        protected override void OnRefrescar()
        {

            var lista = ArticuloLogic.Instance.TraerArticulo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.PT_codnaturaleza);

            this.gridControl.DataSource = lista;
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


            var datos = DocumentoLogic.Instance.RptKardexDet(Logueo.CodigoEmpresa, Logueo.Anio, almacen, 
                                    ranfecini, ranfecfin, flag, Util.ConvertiraXML(codigosSeleccionados));
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();


            if (rbtopcdetallado.CheckState == CheckState.Checked)
            {
                reporte.Nombre = "Rptkardex.rpt";
                reporte.DataSource = datos;
            }
            else if (rbtopcresumidoxprod.CheckState == CheckState.Checked)
            {
                reporte.Nombre = "RptkardexPorProducto.rpt";
                reporte.DataSource = datos;
            }
            else if (rbtopcresumido.CheckState == CheckState.Checked)
            {
                reporte.Nombre = "RptkardexResumido.rpt";
                reporte.DataSource = datos;
            }

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
            reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

            Cursor.Current = Cursors.Default;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            OnBuscar();
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
                var almacen = AlmacenLogic.Instance.AlmacenesxNaturaleza(Logueo.CodigoEmpresa, Logueo.PT_codnaturaleza);
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

        private void gridControl_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
        {
          
        }

        private void cboalmacenes_SelectedValueChanged(object sender, EventArgs e)
        {
            OnBuscar();
        }
        protected override void OnSeleccionarTodo()
        {
            gridControl.SelectAll();
        }
       
    }

}