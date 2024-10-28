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
using Inv.BusinessEntities;

namespace Cos.UI.Win
{
    public partial class frmVoucherCosto : frmBaseReg
    {
        private frmMDI FrmParent { get; set; }
        private static frmVoucherCosto _aForm;
        private bool isloaded = false;
        public frmVoucherCosto(frmMDI padre)
        {
            InitializeComponent();
            HabilitarBotones(true, false, true, false, false);
            
            CrearColumnasLineas();
            CargarEstadoCosto();
            isloaded = true;
        }
        public static frmVoucherCosto Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmVoucherCosto(mdiPrincipal);
            _aForm = new frmVoucherCosto(mdiPrincipal);
            return _aForm;
        }

        

        private void CrearColumnasLineas()
        {
            RadGridView Grid = this.CreateGridVista(this.rgvEstadoCosto);
            this.CreateGridColumn(Grid, "Asiento", "Asiento", 0, "", 90, true);
            this.CreateGridColumn(Grid, "Motivo", "Motivo", 0, "", 250);
            this.CreateGridColumn(Grid, "Debe", "Debe", 0, "{0:###,###0.00}", 100, true, false, true, true, "right");
            this.CreateGridColumn(Grid, "Haber", "Haber", 0, "{0:###,###0.00}", 100,true,false,true,true,"right");
        }

        private void CargarEstadoCosto()
        {
            List<Spu_Cos_Gen_AsientoCostos> lista = EstadoCostoLogic.Instance.EstadoCostoProduccion(Logueo.CodigoEmpresa,Logueo.Anio, Logueo.Mes,Logueo.CodigoLinea);
            this.rgvEstadoCosto.DataSource = lista;

        }

        protected override void OnVista()
        {
            ReporteViewer reportesql = new ReporteViewer("Documento");
            reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS(); // obtener el nombre de la carpeta donde esta nuestro reporte
            reportesql.Ruta = Logueo.GetDirectorySSRRS();
            reportesql.Nombre = "RptCostProdxLinea";
             // agregar parametros de entradas
            Paramentro pEmoresa = new Paramentro("COS01CODEMP", Logueo.CodigoEmpresa);
            reportesql.ParametersFields.Add(pEmoresa);
            Paramentro pAnio = new Paramentro("COS01ANIO", Logueo.Anio);
            reportesql.ParametersFields.Add(pAnio);
            Paramentro pMes = new Paramentro("COS01MES", Logueo.Mes);
            reportesql.ParametersFields.Add(pMes);         
            ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }

    }
}
