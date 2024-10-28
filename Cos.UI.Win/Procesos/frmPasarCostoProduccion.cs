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

namespace Cos.UI.Win
{
    public partial class frmPasarCostoProduccion : frmBase
    {
        private frmMDI FrmParent { get; set; }
        private static frmPasarCostoProduccion _aForm;
        public frmPasarCostoProduccion(frmMDI padre)
        {
            InitializeComponent();           
            HabilitarBotones(false, false, false, false, true, false, true, false);
            OnBuscar();
            
        }
        public static frmPasarCostoProduccion Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmPasarCostoProduccion(mdiPrincipal);
            _aForm = new frmPasarCostoProduccion(mdiPrincipal);
            return _aForm;
        }
        #region " Detalle "

         // el boton de refrescar se comportara como procesar
        protected override void OnRefrescar()
        {
            string msgokcostopp;
            string msgokcostopt;
            int flagokcostopp;
            int flagokcostopt;

           // int flagokcostopt;
            //Actualizar costo de PP
            try
            {
               
                ContabilidadGastosLogic.Instance.ActualizaCostoPP(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto, out msgokcostopp, out flagokcostopp);

                // Actualizar costo de PT
                ContabilidadGastosLogic.Instance.ActualizaCostoPT(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, out msgokcostopt, out flagokcostopt);

                if (flagokcostopp == 1 && flagokcostopt == 1)
                {
                    ShowAlertOk("Sistema", msgokcostopt);
                }
                else
                {
                    ShowAlertError("Sistema", msgokcostopt);
                }

            }
            catch (Exception ex) {
                ShowAlertError("Sistema", ex.Message);
            }
         }
        
        #endregion
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;
            ReporteViewer reportesql = new ReporteViewer("Documento");
            reportesql.RutaServidor = Logueo.GetPathServerrReportSSRS(); // obtener el nombre de la carpeta donde esta nuestro reporte
            reportesql.Ruta = Logueo.GetDirectorySSRRS();
            reportesql.Nombre = "RptCuadroCostos";

            Paramentro pEmpresa = new Paramentro("COS03CODEMP", Logueo.CodigoEmpresa);
            reportesql.ParametersFields.Add(pEmpresa);
            Paramentro pAnio = new Paramentro("COS03ANIO", Logueo.Anio);
            reportesql.ParametersFields.Add(pAnio);
            Paramentro pMes = new Paramentro("COS03MES", Logueo.Mes);
            reportesql.ParametersFields.Add(pMes);
            Paramentro pLinea = new Paramentro("COS03LINEA", Logueo.CodigoLinea);
            reportesql.ParametersFields.Add(pLinea);
            Paramentro pLote = new Paramentro("CO03LOTE", Logueo.CodigoLoteCosto);
            reportesql.ParametersFields.Add(pLote);

            ReporteViewerControladora controlsql = new ReporteViewerControladora(reportesql);
            controlsql.VistaPrevia(enmWindowState.Normal);
            Cursor.Current = Cursors.Default;
        }
    }
}
