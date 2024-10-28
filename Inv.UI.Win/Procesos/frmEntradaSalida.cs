using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Telerik.WinControls.UI;
namespace Inv.UI.Win.Procesos
{
    public partial class frmEntradaSalida : frmBaseReporte
    {

        void OnBuscar(string fechaIni,string fechaFin){
          
            
            this.gridControl.DataSource = DocumentoLogic.Instance.Spu_Inv_Ing_Sal(Logueo.CodigoEmpresa,fechaIni,fechaFin);
        }
        RadGridView grilla;
        private frmMDI FrmParent { get; set; }
        private static frmEntradaSalida _aForm;
        public static frmEntradaSalida Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new Procesos.frmEntradaSalida(mdiPrincipal);
                //return new frmEntradaSalida(mdiPrincipal);
            _aForm = new frmEntradaSalida(mdiPrincipal);
            return _aForm;
        }
        public frmEntradaSalida(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;            
            crearColumnas();
           
            dtpFechaini.Value = DateTime.Now;
            dtpfechaFin.Value = DateTime.Now;
            OnBuscar(string.Format("{0:dd/MM/yyyy}", dtpFechaini.Value),string.Format("{0:dd/MM/yyyy}", dtpfechaFin.Value));

        }

        void crearColumnas() {
            grilla = this.CreateGrid(this.gridControl);
            this.CreateGridColumn(grilla, "Fecha", "Fecha", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            this.CreateGridColumn(grilla, "Nro.Caja", "NroCaja", 0, "", 85, true, false, true);
            this.CreateGridColumn(grilla, "Color", "Color", 0, "", 70);
            this.CreateGridColumn(grilla, "Relleno", "Relleno", 0, "", 75);
            this.CreateGridColumn(grilla, "Especial", "Especial", 0, "", 80);
            this.CreateGridColumn(grilla, "Calidad", "Calidad", 0, "", 80);
            this.CreateGridColumn(grilla, "Unidad", "Und.Medida", 0, "", 60);
            this.CreateGridColumn(grilla, "Cantidad", "Cantidad", 0, "{0:###,##0.00}", 80);
            this.CreateGridColumn(grilla, "Tipo", "Tipo", 0, "", 70);
            this.CreateGridColumn(grilla, "Espesor", "Espesor", 0, "{0:###,##0.00}", 80);
            //this.CreateGridColumn(grilla, "Cantidad", "IN07CANART", 0, "", 50);
            this.CreateGridColumn(grilla, "Ancho", "IN07ANCHO", 0, "{0:###,####0.0000}", 65);
            this.CreateGridColumn(grilla, "Largo", "IN07LARGO", 0, "{0:###,####0.0000}", 65);
            this.CreateGridColumn(grilla, "Area", "Area", 0, "{0:###,####0.0000}", 65);
            //this.CreateGridColumn(grilla, "Caja", "Caja", 0, "", 30);
            this.CreateGridColumn(grilla, "Cliente", "Cliente", 0, "", 100);
            
            this.CreateGridColumn(grilla, "Ord.Cliente", "OrdenCLiente", 0, "", 90);
            this.CreateGridColumn(grilla, "Estado", "EstDes", 0, "", 90);
            this.CreateGridColumn(grilla, "Fecha", "FecDes", 0, "{0:dd/MM/yyyy}", 90,true,false,true);
            //this.gridControl.AllowAddNewRow = false;
            //this.gridControl.AllowEditRow = false;            
            //gridControl.AllowDragToGroup = false;                 
        }
        
        public frmEntradaSalida()
        {
            InitializeComponent();                     
        }

        private void cbomesini_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {                       
            try {
                OnBuscar(string.Format("{0:dd/MM/yyyy}", dtpFechaini.Value), string.Format("{0:dd/MM/yyyy}", dtpfechaFin.Value));
            }
            catch (Exception ex) { 
            
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try {
                string ini = string.Format("{0:dd/MM/yyyy}", dtpFechaini.Value);
                string fin = string.Format("{0:dd/MM/yyyy}", dtpfechaFin.Value);
                Cursor.Current = Cursors.WaitCursor;
                OnBuscar(ini, fin);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) {
                MessageBox.Show("Error:" + ex.Message);
            }
            

        }

        private void gridControl_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
        {
            if (e.Column.Name == "Fecha")
            {
                e.FilterPopup = new RadListFilterPopup(e.Column, true);
            }
            if (e.Column.Name == "FecDes" ) {

                e.FilterPopup = new RadListFilterPopup(e.Column, true);
            }
        }


    }
}
