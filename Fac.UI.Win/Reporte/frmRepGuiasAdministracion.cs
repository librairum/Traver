using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Inv.BusinessEntities;
using Inv.BusinessLogic;

namespace Fac.UI.Win
{
    public partial class frmRepGuiasAdministracion : frmBaseReporte
    {

        #region "Instancia"

        private static frmRepGuiasAdministracion _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmRepGuiasAdministracion Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmRepGuiasAdministracion(formParent);
            _aForm = new frmRepGuiasAdministracion(formParent);
            return _aForm;
        }
        #endregion

        public frmRepGuiasAdministracion(frmMDI padre)
        {
            InitializeComponent();
        }
        private void CrearColumnas()
        {
            try
            {
                RadGridView Grid = this.CreateGrid(this.gridControl);
                gridControl.ShowRowHeaderColumn = true;
                gridControl.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                CreateGridColumn(Grid, "Fecha", "Fecha", 0, "", 70, true, false, true);
                CreateGridColumn(Grid, "N°Guia", "NumeroGuia", 0, "", 80, true, false, true);
                CreateGridColumn(Grid, "OC", "OC", 0, "", 90, true, false, true);
                CreateGridColumn(Grid, "Ruc", "CodigoCliente", 0, "", 90, true, false, false);
                CreateGridColumn(Grid, "Cliente", "NombreCliente", 0, "", 200, true, false, true);
                CreateGridColumn(Grid, "Motivo", "Motivo", 0, "", 90, true, false, false);
                CreateGridColumn(Grid, "Motivo", "MotivoDescripcion", 0, "", 90, true, false, true);

                CreateGridColumn(Grid, "Baldosas", "CantidadBaldosasMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
                CreateGridColumn(Grid, "Mosaicos", "CantidadMosaicosMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
                CreateGridColumn(Grid, "Planchas", "CantidadPlanchasMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
                CreateGridColumn(Grid, "Otros", "CantidadOtrosMT2", 0, "{0:###,###0.00}", 80, true, false, true, "right");
                CreateGridColumn(Grid, "Total MT2", "TotalMT2", 0, "{0:###,###0.00}", 90, true, false, true, "right");

                CreateGridColumn(Grid, "Escalla", "CantidadEscallaTM", 0, "{0:###,###0.00}", 80, true, false, true, "right");
                CreateGridColumn(Grid, "Polvo", "CantidadPolvoTM", 0, "{0:###,###0.00}", 80, true, false, true, "right");
                CreateGridColumn(Grid, "Total TM", "TotalTM", 0, "{0:###,###0.00}", 90, true, false, true, "right");
                CreateGridColumn(Grid, "Observacion", "Observacion", 0, "", 160, true, false, true);


                string[] columnas = new string[8];
                columnas[0] = "CantidadBaldosasMT2";
                columnas[1] = "CantidadMosaicosMT2";
                columnas[2] = "CantidadPlanchasMT2";
                columnas[3] = "CantidadOtrosMT2";
                columnas[4] = "TotalMT2";
                columnas[5] = "CantidadEscallaTM";
                columnas[6] = "CantidadPolvoTM";
                columnas[7] = "TotalTM";

                Util.AddGridSummarySum(Grid, columnas);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al crear columnas");
            }

        }
        ColumnGroupsViewDefinition columnGroupsView;
        private void CrearGrupos()
        {
            int indiceGrupo = 0;
            try
            {
                indiceGrupo = 0;
                this.columnGroupsView = new ColumnGroupsViewDefinition();
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["Fecha"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["NumeroGuia"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["OC"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CodigoCliente"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["NombreCliente"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["Motivo"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["MotivoDescripcion"]);

                indiceGrupo = 1;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("MT2"));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadBaldosasMT2"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadMosaicosMT2"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadPlanchasMT2"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadOtrosMT2"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["TotalMT2"]);
                

                indiceGrupo = 2;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup("TM"));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadEscallaTM"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["CantidadPolvoTM"]);
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["TotalTM"]);
                

                indiceGrupo = 3;
                this.columnGroupsView.ColumnGroups.Add(new GridViewColumnGroup(""));
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows.Add(new GridViewColumnGroupRow());
                this.columnGroupsView.ColumnGroups[indiceGrupo].Rows[0].Columns.Add(this.gridControl.Columns["Observacion"]);
                this.gridControl.ViewDefinition = columnGroupsView;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agrupar columnas");
            }
        }
        private void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<TraeReporteGuiasAdministracion> lista =  VentaDocumentoLogic.Instance.TraeGuiasAdministracion(Logueo.CodigoEmpresa, "09", Logueo.Anio, Logueo.Mes, "TO");
                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar Reporte");
            }
            Cursor.Current = Cursors.Default;
        }
        private void SeleccionarTodoFilas()
        {
            try
            {

                gridControl.SelectAll();

                DataObject dataObj = gridControl.GetClipboardContent();
                if (dataObj != null)
                {
                    Clipboard.SetDataObject(dataObj);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al copiar todo las filas , detalle:" + ex.Message);
            }
        }

        private void VerReporte()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();
                Reporte reporte = new Reporte("Documento");
                dt = VentaDocumentoLogic.Instance.TraeReporteGuiasAdministracion(Logueo.CodigoEmpresa, "09", Logueo.Anio, Logueo.Mes, "TO");

                reporte.Ruta = Logueo.GetRutaReporte();
                string nombreReporte = "", titulo = "";

                nombreReporte = "RptGuiasAdministracion.rpt";
                titulo = "Guias de Remision";

                string subtitulo = "";
                subtitulo = "DEL " + Logueo.Mes + " AL " + Logueo.Mes;
                reporte.Nombre = nombreReporte;
                reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                reporte.FormulasFields.Add(new Formula("titulo", titulo));
                reporte.FormulasFields.Add(new Formula("Anio", Logueo.Anio));
                reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

                reporte.DataSource = dt;
                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al ver reporte, detalle : " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private void frmRepGuiasAdministracion_Load(object sender, EventArgs e)
        {
            OcultarBarraBotones();
            CrearColumnas();
            CrearGrupos();
            Cargar();
        }

        private void btnCopiarTodo_Click(object sender, EventArgs e)
        {
            SeleccionarTodoFilas();
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            VerReporte();
        }
    }
}
