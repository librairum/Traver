using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Fac.UI.Win
{
    public partial class frmAsientoTipo : frmBaseMante
    {
        #region "Instancia"
        private static frmAsientoTipo _aForm;
        private frmMDI frmParent { get; set; }
        public static frmAsientoTipo Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmAsientoTipo(formParent);
            _aForm = new frmAsientoTipo(formParent);
            return _aForm;
        }
        #endregion
        AsientoTipoLogic dato = AsientoTipoLogic.Instance;
        public frmAsientoTipo(frmMDI frmPadre)
        {
            InitializeComponent();
            frmParent = frmPadre;
            CrearColumnas();
            CargarCabecera();
            cargarDetalle();
            gestionarBotones(true, true, true, false, false);
        }
        private void iniciarFilaNuevo(GridViewRowInfo fila)
        {
            Util.SetValueCurrentCellText(fila, "FAC08CODEMP", Logueo.CodigoEmpresa);
        }
        private void agregarNuevaFila()
        {
            
            if (gridControl.Rows.Count == 0)
            {
                GridViewRowInfo rowInfo = gridControl.Rows.AddNew();
                Util.SetValueCurrentCellText(rowInfo, "FAC08CODEMP", Logueo.CodigoEmpresa);
            }
            else if (gridControl.Rows.Count > 0)
            {
                //validar si termino de grabar o actualizar la fila actual
                
                GridViewRowInfo rowInfo = gridControl.Rows.AddNew();
                Util.SetValueCurrentCellText(rowInfo, "FAC08CODEMP", Logueo.CodigoEmpresa);
            }
        }

        protected override void OnNuevo()
        {
            var frmInstance = frmabcAsientoTipo.Instance(this);
            frmInstance.Estado = FormEstate.New;
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmabcAsientoTipo);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();
                        
            Estado = FormEstate.New;
        }

        protected override void OnEliminar()
        {
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea eliminar registro?");
                if (respuesta == true)
                {
                    //string  Util.GetCurrentCellText(gridControl, "FAC08CODEMP");
                    string AsientoTipoCodigo = Util.GetCurrentCellText(gridControl, "FAC08COD");
                    string mensaje = ""; int int_flag = 0;
                    dato.EliminarAsientoTipo(Logueo.CodigoEmpresa, AsientoTipoCodigo, out int_flag, out mensaje);

                    if (int_flag == 1)
                    {
                        Util.ShowMessage(mensaje, int_flag);
                        CargarCabecera();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }
        }

        protected override void OnEditar()
        {
            var frmInstance = frmabcAsientoTipo.Instance(this);
            frmInstance.Estado = FormEstate.Edit;
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmabcAsientoTipo);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);
            frmInstance.Show();
            //gestionarBotones(false, false, false, true, true);
            Estado = FormEstate.Edit;
        }

       
        protected override void OnCancelar()
        {
            gestionarBotones(true, true, true, false, false);
            
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "Empresa", "FAC08CODEMP", 0, "", 90); /*varchar(2)*/
            CreateGridColumn(Grid, "Codigo", "FAC08COD", 0, "", 90); /*varchar(5)*/
            CreateGridColumn(Grid, "Descripcion", "FAC08DES", 0, "", 150); /*varchar(80)*/
            CreateGridColumn(Grid, "Cod.Libro", "FAC08CODLIBRO", 0, "", 150); /*varchar(2)*/
            CreateGridColumn(Grid, "Desc.Libro", "LibroDesc", 0, "", 200);
        }

        public void CargarCabecera()
        {
            try
            {
                this.gridControl.DataSource = dato.TraerCabAsientoTipo(Logueo.CodigoEmpresa,
                                               "FAC08CODEMP", "*");
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar : " + ex.Message);
            }

        }
        
        private void cargarDetalle()
        { 
            
        }
    }
}
