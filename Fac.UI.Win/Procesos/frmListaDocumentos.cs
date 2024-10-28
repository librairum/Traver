using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
namespace Fac.UI.Win
{
    public partial class frmListaDocumentos : frmBase
    {
        private static frmListaDocumentos _aForm;
        private frmMDI frmParent { get; set; }
        
        public static frmListaDocumentos Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmListaDocumentos(padre);
            _aForm = new frmListaDocumentos(padre);
            return _aForm;
        }
        
        internal bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
           cancelar_a, expmovi_a, importarMP;
        #region "Seguridad"
        private void accesobotonesperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.CodModulo,
            this.Name, out nuevo_a, out editar_a, out eliminar_a, out ver_a, out imprimir_a,
            out refrescar_a, out importar_a, out vista_a, out guardar_a, out cancelar_a,
            out expmovi_a, out importarMP);
        }
        #endregion
        public frmListaDocumentos(frmMDI padre)
        {
            InitializeComponent();
            frmParent = padre;
            gridControl.KeyDown += new KeyEventHandler(gridControl_KeyDown);
        }

        

        void CrearColumnas()
        {
            RadGridView Grid =  CreateGridVista(gridControl);
            CreateGridColumn(Grid, "Empresa", "FAC01CODEMP", 0, "", 90,false,true,false);
            CreateGridColumn(Grid, "Codigo", "FAC01COD", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "Descripcion", "FAC01DESC", 0, "", 250, true, false, true);
            CreateGridColumn(Grid, "Tip.Docu", "FAC01TIPDOC", 0, "", 90, false, true, false);
            CreateGridColumn(Grid, "Tip.Docu.FE", "FAC01FETIPDOC", 0, "", 90, false, true, false);
        }
        void Cargar()
        {
            try
            {
                gridControl.DataSource = TipoDocumentoLogic.Instance.TraerTipoDocumentoFA(Logueo.CodigoEmpresa,
                                                                   "FAC01COD", "*");
            }
            catch (Exception ex)
            { 
                Util.ShowError("Error al cargar lista de documentos: " + ex.Message);
            }
        }
        public override void OnCancelar()
        {
            this.Close();
        }

        private void frmListaDocumentos_Load(object sender, EventArgs e)
        {
            habilitarBotones(false, false, false, false, true, 
                             false, false, false, false, true);
            CrearColumnas();
            Cargar();
            accesobotonesperfil();
        }
        protected override void OnVer()
        {
            Cursor.Current = Cursors.WaitCursor;

            var frmInstance = frmFacturas.Instance(this);            
            frmInstance.Estado = FormEstate.New;
            
            //-----
            var frmInstance2 = frmNotaCreYNotDeb.Instance(this);
            frmInstance2.Estado = FormEstate.New;

            string str_CodigoDocumento = Util.GetCurrentCellText(gridControl, "FAC01COD");

            if (str_CodigoDocumento == "01")
            {
                frmInstance.EstadoDocumento = BaseTipoDocumento.enmFactura;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFacturas);
                if (frmExist != null)
                {
                    frmInstance.BringToFront();
                    return;
                }
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                frmInstance.MdiParent = this.ParentForm;

                ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
                frmInstance.Show();
            }
            else if (str_CodigoDocumento == "03")
            {
                frmInstance.EstadoDocumento = BaseTipoDocumento.enmBoleta;
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmFacturas);
                if (frmExist != null)
                {
                    frmInstance.BringToFront();
                    return;
                }
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                frmInstance.MdiParent = this.ParentForm;

                ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
                frmInstance.Show();
            }
            else if (str_CodigoDocumento == "07")
            {
                Logueo.FlagNotCreyDeb = "C";
                frmInstance2.EstadoDocumento = BaseTipoDocumento.enmNotaCredito;
                
                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNotaCreYNotDeb);
                if (frmExist != null)
                {
                    frmInstance2.BringToFront();
                    return;
                }
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                frmInstance2.MdiParent = this.ParentForm;

                ((RadDock)(ctrl)).ActivateMdiChild(frmInstance2);
                frmInstance2.Show();
                
            }
            else if (str_CodigoDocumento == "08")
            {
                Logueo.FlagNotCreyDeb = "D";
                frmInstance2.EstadoDocumento = BaseTipoDocumento.enmNotaDebito;                

                var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNotaCreYNotDeb);
                if (frmExist != null)
                {
                    frmInstance2.BringToFront();
                    return;
                }
                Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
                frmInstance2.MdiParent = this.ParentForm;

                ((RadDock)(ctrl)).ActivateMdiChild(frmInstance2);
                frmInstance2.Show();
            }


            Cursor.Current = Cursors.Default;
           
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridControl.Rows.Count == 0) { Util.ShowAlert("No tiene registro para seleccionar"); return; }
            OnVer();
        }
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (gridControl.Rows.Count == 0) { Util.ShowAlert("No tiene registro para seleccionar"); return; }
            OnVer();
        }
    }
}
