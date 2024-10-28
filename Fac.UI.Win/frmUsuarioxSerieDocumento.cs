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
namespace Fac.UI.Win
{
    public partial class frmUsuarioxSerieDocumento : frmBase
    {

        private frmMDI FrmParent { get; set; }
        private static frmUsuarioxSerieDocumento _aForm;
        public static frmUsuarioxSerieDocumento Instance(frmMDI formParent)
        {
            //InitializeComponent();
            if (_aForm != null) return new frmUsuarioxSerieDocumento(formParent);
            _aForm = new frmUsuarioxSerieDocumento(formParent);
            return _aForm;

        }

        public  frmUsuarioxSerieDocumento(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "TipDocSerie", "CodigoSerie", 0, "", 90, false, true, false);
            CreateGridColumn(Grid, "Usuario", "CodigoUsuario", 0, "", 90);
            CreateGridColumn(Grid, "Tipo Documento", "CodTipoDocumento", 0, "", 90);
            CreateGridColumn(Grid, "Descripcion", "DesTipoDocumento", 0, "", 220);
            CreateGridColumn(Grid, "Serie", "CodSerie", 0, "", 90);
            CreateGridColumn(Grid, "Descripcion", "DesSerie", 0, "", 220);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 70, false, false, false);
            Util.AddButtonsToGrid(Grid, BaseRegBotonesDetalle.btnCancelarDet);
            Util.AddButtonsToGrid(Grid, BaseRegBotonesDetalle.btnGuardarDet);
            Util.AddButtonsToGrid(Grid, BaseRegBotonesDetalle.btnEliminarDet);
        }
        private void Cargar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<SegUsuario> lista =  SegUsuarioLogic.Instance.TraeTipoDocumentoxUsuario();
                this.gridControl.DataSource = lista;
            }catch(Exception ex){
                Util.ShowAlert("Error al cargar");
            }
            Cursor.Current = Cursors.Default;
        }

        private void frmUsuarioxSerieDocumento_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Cargar();
            Util.ConfigGridToEnterNavigation(gridControl);
            if (gridControl.Rows.Count > 0)
            { 
                
            }

        }
        

        private void TraerAyuda(enmAyuda tipo)
        {
            string[] datos;
            frmBusqueda frm = new frmBusqueda(tipo);
            frm.ShowDialog();
            if (frm.Result == null) return;
            if (frm.Result.ToString() == "") return;
            datos = frm.Result.ToString().Split('|');
            switch (tipo)
            {
                    
                case enmAyuda.enmSegUsuario:                    
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "CodigoUsuario",  datos[0]);
                    break;
                    
                case enmAyuda.enmSegTipoDocumento:
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "CodigoSerie", datos[0] + datos[2]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "CodTipoDocumento", datos[0]); //TipoDocumento ´ + CodigoSerie     
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "DesTipoDocumento", datos[1]); //Descripcion de Tipo documento FAC01DESC
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "CodSerie",  datos[2]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "DesSerie", datos[3]);
                    break;

                default: 
                    break;
            }
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(gridControl.Rows.Count == 0) return;

            
            if (FlagMantenimiento() == "1" || FlagMantenimiento() == "0")
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    if (Util.IsCurrentColumn(gridControl.CurrentColumn, "CodigoUsuario"))
                    {
                        TraerAyuda(enmAyuda.enmSegUsuario);
                    }
                    else if (Util.IsCurrentColumn(gridControl.CurrentColumn, "CodTipoDocumento"))
                    {
                        TraerAyuda(enmAyuda.enmSegTipoDocumento);
                    }
                }
            }
            
        }

        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;
            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                //string flag = Util.GetCurrentCellText(gridControl.CurrentRow, "flag");

                if (FlagMantenimiento() == "")
                {

                    
                    if (cellElement.ColumnInfo.Name == "btnEliminarDet")
                    {
                        Util.habilitarBotonDetalle(BaseRegBotonesDetalle.btnEliminarDet, cellElement);
                    }
                    if (cellElement.ColumnInfo.Name == "btnGrabarDet")
                    {
                        Util.deshabilitarBotonDetalle(BaseRegBotonesDetalle.btnGuardarDet, cellElement);
                    }
                    if (cellElement.ColumnInfo.Name == "btnCancelarDet")
                    {
                        Util.deshabilitarBotonDetalle(BaseRegBotonesDetalle.btnCancelarDet, cellElement);
                    }

                }
                else if (FlagMantenimiento() == "0" || FlagMantenimiento() == "1")
                {

                    if (cellElement.ColumnInfo.Name == "btnEliminarDet")
                    {
                        Util.deshabilitarBotonDetalle(BaseRegBotonesDetalle.btnEliminarDet, cellElement);
                    }
                    if (cellElement.ColumnInfo.Name == "btnGrabarDet")
                    {                     
                        Util.habilitarBotonDetalle(BaseRegBotonesDetalle.btnGuardarDet, cellElement);
                    }
                    if (cellElement.ColumnInfo.Name == "btnCancelarDet")
                    {
                        Util.habilitarBotonDetalle(BaseRegBotonesDetalle.btnCancelarDet, cellElement);
                    }
                }
            }
        }
        private void Procesar(DetalleEstado accion)
        {
            Cursor.Current = Cursors.WaitCursor;
            string nombreMetodo = "";
            try
            {
                switch(accion)
                {
                    case DetalleEstado.Guarda:
                        Guarda();
                        nombreMetodo  = "Guarda";
                        break;
                    case DetalleEstado.Edita:
                        Edita();
                        nombreMetodo = "Edita";
                        break;
                    case DetalleEstado.Cancela:
                        Cancela();
                        nombreMetodo = "Cancela";
                        break;
                    case DetalleEstado.Nuevo:
                        Nuevo();
                        nombreMetodo = "Nuevo";
                        break;
                    case DetalleEstado.Elimina:
                        Elimina();
                        nombreMetodo = "Elimina";
                        break;
                    default: 
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.ShowAlert(string.Format("Error al procesar {0}, {1}", nombreMetodo,  ex.Message)); 
            }
            Cursor.Current = Cursors.Default;
        }
        private void Guarda()
        {

            string codigoSerie = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoSerie");
            string codigoUsuario = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoUsuario");
            int flagRespuesta = 0;
            string mensaje = "";
            if (FlagMantenimiento() == "0")
            {
                SegUsuarioLogic.Instance.InsertarUsuarioxSerie(codigoSerie, codigoUsuario, out flagRespuesta, out mensaje);
                Util.ShowMessage(mensaje, flagRespuesta);
                if (flagRespuesta == 1)
                {
                    Cargar();
                }
            }
            
        }
        private void Cancela()
        {
            Cargar();

        }
        private void Edita()
        {
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "flag", "1"); // nuevo
        }
        protected override void OnNuevo()
        {
            Procesar(DetalleEstado.Nuevo);
        }
        private void Nuevo()
        {
            if (gridControl.Rows.Count > 0)
            {                                
                if (FlagMantenimiento() == "1" || FlagMantenimiento()  == "0")
                {
                    Util.ShowAlert("Debe completar la accion de registrar o editar del registro");
                    return;
                }
            }

            gridControl.Rows.AddNew();
            Util.SetValueCurrentCellText(gridControl.CurrentRow, "flag", "0"); // nuevo
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CodigoUsuario"]);
            Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CodTipoDocumento"]);

        }
        private void Elimina()
        {
            if (Util.ShowQuestion("¿Desea eliminar el registro?") == false)
            {
                return;
            }
            string codigoSerie = Util.GetCurrentCellText(gridControl.CurrentRow, "CodSerie");
            string codigoUsuario = Util.GetCurrentCellText(gridControl.CurrentRow, "CodigoUsuario");
            int flag = 0; string mensaje = "";
            SegUsuarioLogic.Instance.EliminarUsuarioxSerie(codigoSerie, codigoUsuario, out flag, out mensaje);
            Util.ShowMessage(mensaje, flag);
            if (flag == 1)
            {
                Cargar();
            }
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            
            if (Util.IsCurrentColumn(gridControl.CurrentColumn, "btnGrabarDet"))
            {
                Procesar(DetalleEstado.Guarda);
            }
            else if (Util.IsCurrentColumn(gridControl.CurrentColumn, "btnCancelarDet"))
            {
                Procesar(DetalleEstado.Cancela);
            }
            else if (Util.IsCurrentColumn(gridControl.CurrentColumn, "btnEliminarDet"))
            {
                Procesar(DetalleEstado.Elimina);
            }
        }
        private string FlagMantenimiento()
        {
            string valor = "";
            if (gridControl.Rows.Count == 0)
            {
                valor = "";
            }
            else {
                valor = Util.GetCurrentCellText(gridControl.CurrentRow, "flag");
            }
            return valor;
        }
        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (FlagMantenimiento() == "1" || FlagMantenimiento() == "0") {
                e.Cancel = true;
            } 
        }

        /*
         CodigoSerie	CodigoUsuario	CodTipoDocumento	DesTipoDocumento	CodSerie	DesSerie
            01F001	    eliana	        01	                FACTURA	            F001	    VENTAS OTRAS
         */
    }
}
