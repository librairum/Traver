using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Inv.BusinessEntities;
using Inv.BusinessLogic;

namespace Fac.UI.Win
{
    public partial class frmempresa : frmBaseMante
    {
        #region "Instancia"
        private static frmempresa _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmempresa Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmempresa(formParent);
            _aForm = new frmempresa(formParent);
            return _aForm;
        }
        #endregion
        public frmempresa(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            gestionarBotones(true, true, true, false, false);
            CrearColumnas();
            Cargar();
        }
        private void AbrirFormulario(FormEstate pEstado)
        {
            try
            {
                var instancia = frmabcEmpresa.Instance(this);

                var frmexiste = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmabcEmpresa);
                if (frmexiste != null) { instancia.BringToFront(); return; }

                //instancia del  formulario
                instancia.Estado = pEstado;
                instancia.MdiParent = this.ParentForm;
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                ((RadDock)(ctrl)).ActivateMdiChild(instancia);
                instancia.Show();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        protected override void OnNuevo()
        {
            Estado = FormEstate.New;
            AbrirFormulario(FormEstate.New);
        }
        protected override void OnEditar()
        {
            if (gridControl.RowCount == 0) return;
            Estado = FormEstate.Edit;
            //ClienteCodigo = Util.GetCurrentCellText(gridControl, "ccm02cod");
            AbrirFormulario(FormEstate.Edit);
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "Sistema", "Sistema", 0, "", 120);//Sistema	varchar
            CreateGridColumn(Grid, "Codigo", "Codigo", 0, "", 90); // Codigo	varchar
            CreateGridColumn(Grid, "Nombre", "Nombre", 0, "", 120);//Nombre	varchar
            CreateGridColumn(Grid, "Direccion", "Direccion", 0, "", 120);//Direccion varchar
            CreateGridColumn(Grid, "Representante", "Representante", 0, "", 120);//Representante	varchar
            CreateGridColumn(Grid, "Cargo", "Cargo", 0, "", 90);//Cargo	varchar
            CreateGridColumn(Grid, "Ruc", "Ruc", 0, "", 90); // Ruc varchar
            CreateGridColumn(Grid, "Igv", "Igv", 0, "", 90);
            CreateGridColumn(Grid, "Ejercicio", "Ejercicio", 0, "", 90); //Ejercicio
            CreateGridColumn(Grid, "Clave", "Clave", 0, "", 90); //Clave varchar
            CreateGridColumn(Grid, "CodEmpContabilidad", "CodEmpContabilidad", 0, "", 90); //CodEmpContabilidad
            CreateGridColumn(Grid, "CodEmpAlmacen", "CodEmpAlmacen", 0, "", 90); //CodEmpAlmacen
            CreateGridColumn(Grid, "DepartamentoCod", "DepartamentoCod", 0, "", 90); //DepartamentoCod
            CreateGridColumn(Grid, "DepaDescrpicion", "DepaDescrpicion", 0, "", 90); //DepaDescrpicion
            CreateGridColumn(Grid, "ProvinciaCod", "ProvinciaCod", 0, "", 90); //ProvinciaCod
            CreateGridColumn(Grid, "ProviDescripcion", "ProviDescripcion", 0, "", 90); //ProviDescripcion
            CreateGridColumn(Grid, "DistritoCod", "DistritoCod", 0, "", 90); //DistritoCod
            CreateGridColumn(Grid, "DisDescripcion", "DisDescripcion", 0, "", 90); //DisDescripcion
            CreateGridColumn(Grid, "urbanizacion", "urbanizacion", 0, "", 90); //urbanizacion
            CreateGridColumn(Grid, "CorreoFacturaElectonica", "CorreoFacturaElectonica", 0, "", 90);

            CreateGridColumn(Grid, "DescAlmacen", "DescAlmacen", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "DesCtaCtble", "DesCtaCtble", 0, "", 90, true, false, false);
            
            

        }
        internal void Cargar()
        {            
            List<Empresa> lista = null;
            lista  = GlobalLogic.Instance.TraerEmpresas(Logueo.nombreModulo, "Codigo ASC");

            this.gridControl.DataSource = lista;
        }

    }
}
