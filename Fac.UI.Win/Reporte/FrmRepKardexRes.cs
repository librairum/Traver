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
    public partial class FrmRepKardexRes : frmBaseReporte
    {
        private bool isLoaded = false;

        private void FrmRepKardexRes_Load(object sender, EventArgs e)
        {
         rbtAl.CheckState = CheckState.Checked;
          // Fechas de hoy dia por defecto
            this.dtpalfechaini.Value = DateTime.Now;
            this.dtpranfechaini.Value = DateTime.Now;
            this.dtpranfechafin.Value = DateTime.Now;

          isLoaded = true;
        }

        public FrmRepKardexRes()
        {
            InitializeComponent();
        }

        
        protected override void OnVista()
        {
            Cursor.Current = Cursors.WaitCursor;

            //Capturar fechas
            string ranfecini;
            string ranfecfin;
            string flag;
            string subtitulo;

            
            if (rbtAl.CheckState == CheckState.Checked)
            {
            
                ranfecini = string.Format("{0:dd/MM/yyyy}", this.dtpalfechaini.Value);
                ranfecfin = string.Format("{0:dd/MM/yyyy}", this.dtpalfechaini.Value);
                subtitulo = (" AL " + ranfecini);
                flag = "A";
            }
            else
            {
                ranfecini = string.Format("{0:dd/MM/yyyy}", this.dtpranfechaini.Value);
                ranfecfin = string.Format("{0:dd/MM/yyyy}", this.dtpranfechafin.Value);
                subtitulo = ("DEL   " + ranfecini + "   AL  " + ranfecfin);
                flag = "R";
            }

            
            //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
            var datos = DocumentoLogic.Instance.RptKardexRes(Logueo.CodigoEmpresa,ranfecini, ranfecfin, flag);
            Reporte reporte = new Reporte("Documento");
            reporte.Ruta = Logueo.GetRutaReporte();
            reporte.Nombre = "RptkardexRes.rpt";
            reporte.DataSource = datos;

            

            reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
            reporte.FormulasFields.Add(new Formula("subtitulo", subtitulo));

            ReporteControladora control = new ReporteControladora(reporte);
            control.VistaPrevia(enmWindowState.Normal);

            Cursor.Current = Cursors.Default;
            
        }


   }
}