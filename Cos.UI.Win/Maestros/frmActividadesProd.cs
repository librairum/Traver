using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
namespace Cos.UI.Win
{
    public partial class frmActividadesProd : frmBaseMante
    {
        private frmMDI FrmParent { get; set; }
        private static frmActividadesProd _aForm;
        public frmActividadesProd(frmMDI padre) {
            InitializeComponent();
            HabilitarBotones(false, false, false, false, false, false);
            CrearColumnas();
            OnBuscar();
        }
        //public frmActividadesProd()
        //{                        
        //}
        private void CrearColumnas() {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "descripcionLinea", "descripcionLinea", 0,"", 120);
            CreateGridColumn(Grid, "codigo", "codigo", 0, "", 70);
            CreateGridColumn(Grid, "descripcion", "descripcion", 0, "", 120);

        }
        protected override void OnBuscar()
        {
            var lista = ActividadNivel1Logic.Instance.TraerActiProdxEmpresa(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        public static frmActividadesProd Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmActividadesProd(mdiPrincipal);
            _aForm = new frmActividadesProd(mdiPrincipal);
            return _aForm;
        }
    }
}
