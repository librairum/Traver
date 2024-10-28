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
    public partial class FrmCalcularcostopromedio : frmBaseMante
    {
        private bool isLoaded = false;
        
        private frmMDI FrmParent { get; set; }
        private static FrmCalcularcostopromedio _aForm;
        public static FrmCalcularcostopromedio Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmCalcularcostopromedio(mdiPrincipal);
            _aForm = new FrmCalcularcostopromedio(mdiPrincipal);
            return _aForm;
        }
        public FrmCalcularcostopromedio(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
           
        }
        
      

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string mensaje = "";
            try
            {
                DocumentoLogic.Instance.CalculoStockyCostos(Logueo.CodigoEmpresa, Logueo.Anio,
                Logueo.Mes, out mensaje);
                Util.ShowMessage(mensaje, 1);
            }
            catch (Exception ex) {
                Util.ShowError("Error al calcular");
            }
            Cursor.Current = Cursors.Default;
            
        }

        private void FrmCalcularcostopromedio_Load(object sender, EventArgs e)
        {
            OcultaBarraBotones();
        }
        
    }
}
