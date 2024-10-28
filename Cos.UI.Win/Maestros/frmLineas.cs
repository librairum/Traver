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
    public partial class frmLineas : frmBaseMante
    {
        private frmMDI FrmParent { get; set; }
        private static frmLineas _aForm;
        public frmLineas(frmMDI padre)
        {
            InitializeComponent();
            HabilitarBotones(false, false, false, false, false, false);            
            CrearColumnas();
            OnBuscar();            
        }
        private void CrearColumnas() 
        {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "Empresa", "codigoEmpresa", 0, "", 70);
            this.CreateGridColumn(Grid, "Codigo", "codigo", 0, "", 120);
            this.CreateGridColumn(Grid, "Descripcion", "descripcion", 0, "", 200); 
        }
        protected override void OnBuscar()
        {
            var lista = LineaLogic.Instance.LineaTraer(Logueo.CodigoEmpresa);
            this.gridControl.DataSource = lista;
        }
        public static frmLineas Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmLineas(mdiPrincipal);
            _aForm = new frmLineas(mdiPrincipal);
            return _aForm;
        }
    }
}
