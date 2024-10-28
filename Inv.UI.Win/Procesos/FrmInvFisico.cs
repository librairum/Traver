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

    public partial class FrmInvFisico : frmBaseMante
    {
        private bool isLoaded = false;
        RadGridView grilla;
        public FrmInvFisico()
        {
            InitializeComponent();
            Crearcolumnas();
            CrearColumnasDet();
            CargarAlmacenes(cboalmacenes);
            this.dtpFecha.Value = DateTime.Now;
            gbnuevo.Visible=false;
        }
        private frmMDI FrmParent { get; set; }


        private static FrmInvFisico _aForm;
        public static FrmInvFisico Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmInvFisico(mdiPrincipal) ;
            _aForm = new FrmInvFisico(mdiPrincipal);
            return _aForm;
        }

        public FrmInvFisico(frmMDI padre) {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            CrearColumnasDet();
            CargarAlmacenes(cboalmacenes);
            this.dtpFecha.Value = DateTime.Now;
            gbnuevo.Visible = false;
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = InventarioFisicoLogic.Instance.InventarioFisicoPorAnio(Logueo.CodigoEmpresa, Logueo.Anio);
            this.gridControl.DataSource = lista;
        }
        protected void OnBuscarDet()
        {
            if (this.gridControl.RowCount == 0)        
                return;
            
            string invfisalmacen = string.Empty;
            DateTime invfisfechadate;
            string invfisfecha = string.Empty;

            invfisalmacen = this.gridControl.CurrentRow.Cells["IN04CODALM"].Value.ToString();
            invfisfechadate = Convert.ToDateTime(this.gridControl.CurrentRow.Cells["IN04FECINV"].Value.ToString());
            invfisfecha = string.Format("{0:dd/MM/yyyy}", invfisfechadate);

            //base.OnBuscar();
            Cursor.Current = Cursors.WaitCursor;

            var lista = InventarioFisicoLogic.Instance.InventarioFisicoTraer(Logueo.CodigoEmpresa, Logueo.Anio,invfisalmacen,invfisfecha);
            this.gridControlDet.DataSource = lista;

            Cursor.Current = Cursors.Default;
        }   
        protected override void OnVista()
        {
            
             if (this.gridControl.RowCount == 0)
                return;

             try
             {
                 string invfisalmacen = string.Empty;
                 DateTime invfisfechadate;
                 string invfisfecha = string.Empty;

                 invfisalmacen = this.gridControl.CurrentRow.Cells["IN04CODALM"].Value.ToString();
                 invfisfechadate = Convert.ToDateTime(this.gridControl.CurrentRow.Cells["IN04FECINV"].Value.ToString());
                 invfisfecha = string.Format("{0:dd/MM/yyyy}", invfisfechadate);

                 Cursor.Current = Cursors.WaitCursor;
                 // Capturo los datos de la grilla

                 //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
                 Reporte reporte = new Reporte("Documento");
                 reporte.Ruta = Logueo.GetRutaReporte();

                 if (rbtinvfisicotoma.CheckState == CheckState.Checked)
                 {
                     var datos = InventarioFisicoLogic.Instance.InventarioFisicoRepToma(Logueo.CodigoEmpresa, Logueo.Anio, invfisalmacen, invfisfecha);
                     reporte.Nombre = "RptInvFisicotoma.rpt";
                     reporte.DataSource = datos;
                     reporte.FormulasFields.Add(new Formula("FechaInvFisico", invfisfecha));
                     reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                 }
                 else if (rbtinvfisicodiferencias.CheckState == CheckState.Checked)
                 {
                     var datosd = InventarioFisicoLogic.Instance.InventarioFisicoRepDife(Logueo.CodigoEmpresa, Logueo.Anio, invfisalmacen, invfisfecha);
                     reporte.Nombre = "RptInvFisicoDiferencias.rpt";
                     reporte.DataSource = datosd;
                     reporte.FormulasFields.Add(new Formula("FechaInvFisico", invfisfecha));
                     reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                 }

                 ReporteControladora control = new ReporteControladora(reporte);
                 control.VistaPrevia(enmWindowState.Normal);

                 Cursor.Current = Cursors.Default;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            gbnuevo.Visible=true;
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false, true);
        }
        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            HabilitarBotones(false, false, false, true, true, false);
            //habilitarBotones(false, true);
        }
        protected override void OnEliminar()
        {
            string invfisalmacen = string.Empty;
            DateTime invfisfechadate;
            string invfisfecha = string.Empty;
            string msgRetorno = string.Empty;

            if (this.gridControl.RowCount == 0)
                return;
            
            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    invfisalmacen = this.gridControl.CurrentRow.Cells["IN04CODALM"].Value.ToString();
                    invfisfechadate = Convert.ToDateTime(this.gridControl.CurrentRow.Cells["IN04FECINV"].Value.ToString());
                    invfisfecha = string.Format("{0:dd/MM/yyyy}", invfisfechadate);

                    InventarioFisico inventariofisico = new InventarioFisico();
                    
                    inventariofisico.IN04CODEMP=Logueo.CodigoEmpresa;
                    inventariofisico.IN04AA=Logueo.Anio;
                    inventariofisico.IN04CODALM=invfisalmacen;
                    inventariofisico.IN04FECINV = invfisfechadate;

                    InventarioFisicoLogic.Instance.InventarioFisicoEliminar(inventariofisico, out msgRetorno);
                    RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    OnBuscarDet();
                    if (gridControl.RowCount == 0) {
                        if (gridControlDet.RowCount > 0)
                        {
                            gridControlDet.Rows.Clear();
                        }
                    }
                    
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }


        }
        protected override void OnCancelar()
        {
            OnBuscar();            
                            //
            HabilitarBotones(true, true, true, false, false, true);
            //habilitarBotones(true, false);
            radLabel1.Visible = false;
            cboalmacenes.Visible = false;
            radLabel2.Visible = false;
            dtpFecha.Visible = false;
            gbnuevo.Visible = false;
        }
        protected override void OnGuardar()
        {
            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
            
            try
            {
                InventarioFisico inventariofisico = new InventarioFisico();
                inventariofisico.IN04CODEMP = Logueo.CodigoEmpresa;
                inventariofisico.IN04AA= Logueo.Anio;
                inventariofisico.IN04CODALM= this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);
                inventariofisico.IN04FECINV = this.dtpFecha.Value;
                
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    Cursor.Current = Cursors.WaitCursor;

                    InventarioFisicoLogic.Instance.InventarioFisicoInsertar(inventariofisico,out mensajeRetorno);
                    string fecha = inventariofisico.IN04FECINV.ToString();
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    // Ocultar group box
                    gbnuevo.Visible = false;
                    // refrescar grilla
                    OnBuscar();
                    OnBuscarDet();

                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    RadMessageBox.Show("Opcion no validad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
            }
            catch (Exception)
            {
                  RadMessageBox.Show("Ha ocurrido error inesperado al registrar ", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            HabilitarBotones(true, true, true, false, false, true);
            
        }
        #region metodosdemantenimineto
        private void Crearcolumnas()
        {
            //this.gridControl.Columns.Clear();
            //this.gridControl.AllowAddNewRow = false;
            //this.gridControl.ShowGroupPanel = false;
            //this.gridControl.ShowFilteringRow = true;
            //this.gridControl.AllowColumnReorder = true;

            //this.gridControl.AutoGenerateColumns = false;
            ////this.gridControl.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            ////this.gridControl.AllowSearchRow = true;
            ////this.gridControl.SearchRowPosition = SystemRowPosition.Top;

            //this.gridControl.EnableHotTracking = true;
            //this.gridControl.ShowFilteringRow = true;
            //this.gridControl.EnableFiltering = true;
            grilla = this.CreateGridVista(this.gridControl);            
            this.CreateGridColumn(grilla, "Almacen", "IN04CODALM", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilla, "Fecha", "IN04FECINV", 0, "{0:dd/MM/yyyy}", 100, true, false, true);
            
        }
        private void CrearColumnasDet()
        {
            RadGridView grilladet = this.CreateGridVista(this.gridControlDet);
            
            this.CreateGridColumn(grilladet, "Columna", "AlmacenColumna", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilladet, "Caja", "In04caja", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilladet, "Ubicacion", "In07ubicacion", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilladet, "Codigo", "in04key", 0, "", 200, true, false, true);
            this.CreateGridColumn(grilladet, "Descripcion", "in01deslar", 0, "", 345, true, false, true);
            this.CreateGridColumn(grilladet, "Uni Med", "in01unimed", 0, "", 80, true, false, true);
            this.CreateGridColumn(grilladet, "Cant. Fisica", "IN04CANTFISICA", 0, "", 80, false, true, true);

            this.CreateGridColumn(grilladet, "Fecha Inv", "IN04FECINV", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilladet, "Almacen", "IN04CODALM", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilladet, "Item", "IN04ITEM", 0, "", 50, true, false, false);


        } 
        #endregion metodosdemantenimineto
        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["IN04CODALM"].Value != null)
                    {
                        OnBuscarDet();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmInvFisico_Load(object sender, EventArgs e)
        {
            OnBuscar();
            //Capturo el primer registro valido 
            OnBuscarDet();
            isLoaded = true;
            HabilitarBotones(true, true, true, false, false, true);

            //this.habilitarBotones(true, false);
            //gestionarBotones(true, true, true, true,
              //  true, true);
        }
        private void CargarAlmacenes(RadDropDownList cbo)
        {
            try
            {
                var almacen = AlmacenLogic.Instance.AlmacenTraer(Logueo.CodigoEmpresa);
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los alamcenes
                cbo.SelectedValue = "06";
            }


            catch (Exception)
            {

                throw;
            }
        }
        private void gridControl_Click(object sender, EventArgs e)
        {

        }
        private void gridControlDet_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Value == null)
                return;
            try
            {

                if (e.Column.Name.CompareTo("IN04CANTFISICA") == 0)
                {
                    this.GuardarDetalle(this.gridControlDet.CurrentRow);
                }

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }
        private void GuardarDetalle(GridViewRowInfo info)
        {
            try
            {
                InventarioFisico invfis = new InventarioFisico();

                invfis.IN04CODEMP = Logueo.CodigoEmpresa;
                invfis.IN04AA = Logueo.Anio;
                invfis.IN04FECINV = Convert.ToDateTime(info.Cells["IN04FECINV"].Value.ToString());
                invfis.IN04CODALM = info.Cells["IN04CODALM"].Value.ToString();
                invfis.IN04KEY = info.Cells["IN04KEY"].Value.ToString();
                invfis.IN04ITEM = int.Parse(info.Cells["IN04ITEM"].Value.ToString());
                invfis.IN04CANTFISICA =double.Parse(info.Cells["IN04CANTFISICA"].Value.ToString());

                string mensajeRetorno = string.Empty;
                int flagok = 0;

                InventarioFisicoLogic.Instance.InventarioFisicoUpd(invfis, out flagok, out mensajeRetorno);

                if (flagok == -1)
                {
                    RadMessageBox.Show("Actualizar Stock Fisico", mensajeRetorno, MessageBoxButtons.OK, RadMessageIcon.Info);
                }

            }
            //RadMessageBox.Show("Grabar Nuevo Registro", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            catch (Exception)
            {

                throw;
            }
        }
   }
}