﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Fac.UI.Win;

using Telerik.WinControls.Data;

namespace Fac.UI.Win
{
    public partial class frmBase : Telerik.WinControls.UI.RadForm
    {

        //RadMessageLocalizationProvider.CurrentProvider = new Prove ();
        
        public frmBase()
        {
            InitializeComponent();
            _extensions = new Extensions();
            commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            commandBarStripElement1.BorderWidth = 0;
            
        }
        public void habilitarBotones(bool bNuevo,bool bEditar,bool bEliminar,
            bool bEstado, bool bVer, bool bVista, bool bImprimir, bool bRefresh, 
            bool bImportar, bool bCancelar = false, bool bProcesarEstado = false, 
            bool  bDeshacerEstado = false, bool bCopiarDocumento= false) {
                cbbNuevo.Visibility = bNuevo == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbEditar.Visibility = bEditar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbEliminar.Visibility = bEliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbCamEst.Visibility = bEstado == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbVer.Visibility = bVer == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbVista.Visibility = bVista == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbImprimir.Visibility = bImprimir == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbRefrescar.Visibility = bRefresh == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbImportar.Visibility = bRefresh == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbCancelar.Visibility = bCancelar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbProcesarEstado.Visibility = bProcesarEstado == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbDeshacerEstado.Visibility = bDeshacerEstado == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbCopiar.Visibility = bCopiarDocumento == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        }

        internal void OcultarBotones()
        {
            cbbNuevo.Visibility = ElementVisibility.Collapsed;
            cbbEditar.Visibility = ElementVisibility.Collapsed;
            cbbEliminar.Visibility = ElementVisibility.Collapsed;
            cbbCamEst.Visibility = ElementVisibility.Collapsed;
            cbbVer.Visibility = ElementVisibility.Collapsed;
            commandBarSeparator1.Visibility = ElementVisibility.Collapsed;
            
            cbbVista.Visibility = ElementVisibility.Collapsed;
            cbbImprimir.Visibility = ElementVisibility.Collapsed;
            commandBarSeparator2.Visibility = ElementVisibility.Collapsed;

           // cbbRefrescar.Visibility = ElementVisibility.Collapsed;
            cbbImportar.Visibility = ElementVisibility.Collapsed;
            cbbCancelar.Visibility = ElementVisibility.Collapsed;
            cbbProcesarEstado.Visibility = ElementVisibility.Collapsed;
            cbbDeshacerEstado.Visibility = ElementVisibility.Collapsed;
            cbbCopiar.Visibility = ElementVisibility.Collapsed;
        }

        internal void HabilitaBotonPorNombre(BaseRegBotones nombreBoton)
        {
            switch (nombreBoton)
            { 
                case BaseRegBotones.cbbNuevo:
                    cbbNuevo.Visibility = ElementVisibility.Visible;
                    commandBarSeparator1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEditar:
                    cbbEditar.Visibility = ElementVisibility.Visible;
                    commandBarSeparator1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEliminar:
                    cbbEliminar.Visibility = ElementVisibility.Visible;
                    commandBarSeparator1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbCamEst:
                    cbbCamEst.Visibility = ElementVisibility.Visible;
                    commandBarSeparator1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVer:
                    cbbVer.Visibility = ElementVisibility.Visible;
                    commandBarSeparator1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVista:
                    cbbVista.Visibility = ElementVisibility.Visible;
                    commandBarSeparator2.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbImprimir:
                    cbbImprimir.Visibility = ElementVisibility.Visible;
                    commandBarSeparator2.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbRefrescar:
                    cbbRefrescar.Visibility = ElementVisibility.Visible;
                    
                    break;
                case BaseRegBotones.cbbImportar:
                    cbbImportar.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbCancelar:
                    cbbCancelar.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbProcesarEstado:
                    cbbProcesarEstado.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbDeshacerEstado:
                    cbbDeshacerEstado.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbCopiar:
                    cbbCopiar.Visibility = ElementVisibility.Visible;
                    break;
            }
        }
      public  void OnEnforcarRegistro(bool esNuevo, RadGridView gv, string codigoRegistro,string nomCol)
        {
            if (gv.IsLoaded)
            {
                if (gv.RowCount > 0)
                {
                    if (esNuevo == true)
                    {
                        gv.Rows[gv.RowCount - 1].IsCurrent = true;
                        gv.Rows[gv.RowCount - 1].IsSelected = true;
                    }
                    else
                    {
                        if (!codigoRegistro.Equals("") && codigoRegistro != null)
                        {
                            foreach (GridViewDataRowInfo row in gv.Rows)
                            {
                                if (row.Cells[nomCol].Value.ToString() == codigoRegistro)
                                {

                                    gv.Rows[row.Index].IsCurrent = true;

                                }
                            }

                        }
                    }

                }
            }
        }
        private Extensions _extensions;

        private string _subTitulo;
        public string SubTitulo
        {
            get { return _subTitulo; }
            set
            {
                _subTitulo = value;
                //this.npMain.Text = _subTitulo;

            }
        }

        private FormEstate _estadoForm;
        public FormEstate Estado
        {
            get { return _estadoForm; }
            set
            {
                _estadoForm = value;
                if (this._estadoForm == FormEstate.New || this._estadoForm == FormEstate.Edit || this._estadoForm == FormEstate.View)
                {
                    //this.navOpcionesGenerales.Visible = false;
                    //this.navOpcionesServicio.Visible = false;
                    //this.navMantenimiento.Visible = true;
                }
                else
                {
                    //this.navOpcionesGenerales.Visible = true;
                    //this.navOpcionesServicio.Visible = true;
                    //this.navMantenimiento.Visible = false;
                }

                //Si es de Modo Consulta, Deshabilita el botón Guardar
                if (this._estadoForm == FormEstate.View)
                {
                    //this.btnGrabar.Enabled = false;
                }
                else
                {
                    //this.btnGrabar.Enabled = true;
                }
            }
        }

        protected Extensions Extensions
        {
            get { return this._extensions; }
        }

        #region Autocomplete

        protected void SetupAutoComplete(RadAutoCompleteBox radAutoCompleteBox, DataTable datatable)
        {
            radAutoCompleteBox.Items.CollectionChanged += this.OnItemsCollectionChanged;
            radAutoCompleteBox.AutoCompleteDisplayMember = "Text";
            radAutoCompleteBox.AutoCompleteValueMember = "Value";
            radAutoCompleteBox.ListElement.VisualItemFormatting += this.OnListElementVisualItemFormatting;
            radAutoCompleteBox.AutoCompleteDataSource = new BindingSource(datatable, string.Empty);
            radAutoCompleteBox.DropDownMaxSize = new Size(radAutoCompleteBox.Width, 0);
        }

        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RadTokenizedTextItemCollection items = sender as RadTokenizedTextItemCollection;
        }

        private void OnListElementVisualItemFormatting(object sender, VisualItemFormattingEventArgs e)
        {
            RadListDataItem dataItem = e.VisualItem.Data;
            e.VisualItem.Text = string.Format("{0} <{1}>", dataItem.Text, dataItem.Value);
        }

        #endregion
      

        /*evento para cambiar de color las cabecera  de la grilla*/

        private void radGridView1_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            Font nuevaFuente = new Font("Arial", 8f);
            //celeste claro
            if (e.CellElement is GridRowHeaderCellElement)
            {
                e.CellElement.DrawBorder = true;
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.CellElement.BackColor = Color.Aquamarine;
            }
            if (e.CellElement is GridHeaderCellElement)
            {
                e.CellElement.DrawBorder = true;
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.CellElement.BackColor = Color.FromArgb(224, 236, 252);

                e.CellElement.GradientStyle = GradientStyles.Solid;
                e.CellElement.BackColor2 = Color.White;
                e.CellElement.BorderColor = Color.FromArgb(158, 182, 206);
                e.CellElement.BorderWidth = 1;

                GridViewRowInfo infoGrilla = e.CellElement.RowInfo;
                GridCellElement celda = e.CellElement;

            }
            else
            {
                e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.DrawBorderProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.DrawFillProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.GradientStyleProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.BackColorProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.ForeColorProperty, ValueResetFlags.Local);
                //e.CellElement.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local);
                /*e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);*/
            }

            
            if (!(e.CellElement is GridHeaderCellElement))
            {
                e.CellElement.Font = nuevaFuente;

            }
        }
        private void radGridView_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
        {

            RadGridView Grilla = ((RadGridView)sender);

            if (Grilla.ChildRows.Count > 0)
            {
                Grilla.ClearSelection();
                Grilla.CurrentRow = null;

                Grilla.ChildRows[0].IsCurrent = true;
                Grilla.ChildRows[0].IsSelected = true;
            }
        }
        public RadGridView CreateGridVista(RadGridView cv) {
            cv.Columns.Clear();
            cv.AutoGenerateColumns = false;

            //Deshabilitar
            cv.AllowAddNewRow = false;
            cv.ShowGroupPanel = false;
            cv.AllowDragToGroup = false;

            // Opciones de orden
            cv.AllowColumnReorder = true;

            // Opciones de filtro
            cv.EnableFiltering = true;
            cv.ShowFilteringRow = false;
            cv.ShowHeaderCellButtons = true;


            //Opciones de selecccion
            cv.SelectionMode = GridViewSelectionMode.FullRowSelect;
            cv.MultiSelect = true;


            // Posicion de la grillas
            cv.SearchRowPosition = SystemRowPosition.Top;

            //Resaltar filas al pasar mouse
            cv.EnableHotTracking = true;

            //aplico el estilo a la grilla 
            cv.ThemeName = "Office2013Light";

            //oculta el indent la zona que tiene de margen la grilla con sus datos
            cv.ShowRowHeaderColumn = false;
            
            //formateo  el color de las columnas a celeste claro
            cv.ViewCellFormatting += new CellFormattingEventHandler(radGridView1_ViewCellFormatting);
            cv.FilterChanged += new GridViewCollectionChangedEventHandler(radGridView_FilterChanged);
            return cv;
        }
        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString,
            int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true)
        {

            Telerik.WinControls.UI.GridViewDataColumn  newColumn = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            cv.MasterTemplate.Columns.Add(newColumn);

            //newColumn.tit = caption;
            newColumn.HeaderText = caption;
            newColumn.FieldName = field;
            newColumn.Name = field;
            newColumn.IsVisible = visible;
            newColumn.ReadOnly = readOnly;
            //newColumn.Index = visibleindex;

            if (withField != 0)
                newColumn.Width = withField;


            //newColumn.DisplayFormat.FormatType = formatType;
            //if (formatType == DevExpress.Utils.FormatType.Custom)
            //    gc.DisplayFormat.Format = new BaseFormatter();
            //gc.DisplayFormat.FormatString = formatString;
            
            newColumn.FormatString = formatString;
           
            
            //cv.FilterPopupRequired += new Telerik.WinControls.UI.FilterPopupRequiredEventHandler(filterPopupReq);
        }


        public void CreateGridDateColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString,
             int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true)
        {
            //Telerik.WinControls.UI.GridViewMaskBoxColumn newColumn = new GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn newColumn = new GridViewDateTimeColumn();
            newColumn.Format = DateTimePickerFormat.Short;
            cv.MasterTemplate.Columns.Add(newColumn);            
            newColumn.HeaderText = caption;
            newColumn.FieldName = field;
            newColumn.Name = field;

            newColumn.IsVisible = visible;
            newColumn.ReadOnly = readOnly;
            if (withField != 0)
                newColumn.Width = withField;
            newColumn.FormatString = formatString;


        }
       
        private string _titulo;
        public void gestionrBotones(ElementVisibility nuevo, ElementVisibility modificar, ElementVisibility eliminar, ElementVisibility cambiar,
            ElementVisibility ver, ElementVisibility vistaPrevia, ElementVisibility imprimir, ElementVisibility refrescar,
            ElementVisibility Importar) {
                cbbNuevo.Visibility = nuevo;
                cbbEditar.Visibility = modificar;
                cbbEliminar.Visibility = eliminar;
                cbbVer.Visibility = ver;
                cbbVista.Visibility = vistaPrevia;
            cbbImprimir.Visibility = imprimir;
            cbbRefrescar.Visibility = refrescar;
            cbbImportar.Visibility = Importar;
            cbbCamEst.Visibility = cambiar;
        }
        
        protected virtual void OnFormatGrid()
        {

        }

        protected virtual void OnInit()
        {

        }

        public virtual void RefreshFormState(FormEstate estado)
        {

        }

        protected virtual void OnBuscar()
        {

        }
        protected virtual void OnLimpiar()
        {

        }
        protected virtual void OnGuardar()
        { }

        public virtual void OnCancelar()
        { }

        protected virtual void OnNuevo()
        {
        }
        protected virtual void OnRefrescar()
        {
        }

        protected virtual void OnEditar()
        { }

        protected virtual void OnVer()
        {
            this.Estado = FormEstate.View;
        }

        protected virtual void OnDetalle()
        { }

        protected virtual void OnEliminar()
        { }

        protected virtual void Anular()
        { }

        protected virtual void OnSalir()
        { }

        protected virtual void OnProcesar()
        { }

        protected virtual void OnConfirmar()
        { }

        protected virtual void OnDeshacer()
        { }

        protected virtual void OnValidar()
        { }
        protected virtual void OnCopiar()
        { 
            
        }
        protected virtual bool OnValidar(ref  StringBuilder sb)
        {
            return true;
        }

        protected virtual void OnVista()
        { }

        protected virtual void OnImprimir()
        { }
        protected virtual void OnCambiar() { 
        
        }
        protected virtual void OnImportar() {                     }
        protected virtual void OnProcesarEstado()
        { 
            
        }

        protected virtual void OnDeshacerEstado()
        { }

        #region Metodos Publicos
        //public void CreateColumns(string vstrNombre, string vstrFielName, string vstrTitulo, int vintAncho, bool vbolVisible, bool vbolReadOnly, int vintVisibleIndex)
        //{
        //    DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();

        //    column.Name = vstrNombre;
        //    column.FieldName = vstrFielName;
        //    column.Caption = vstrTitulo;
        //    column.Width = vintAncho;
        //    column.Visible = vbolVisible;
        //    column.VisibleIndex = vintVisibleIndex;

        //    //this.gvBandeja.Columns.Add(column);
        //    //this.gvBandeja.GridControl = this.gcBandeja;
        //}
        #endregion


        #region Propiedades
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                //this.lblTitulo.Text = _titulo;
                this.Text = _titulo;
                //this.npMain.Text = _titulo;
            }
        }

        private bool _progressBarVisible = true;
        public bool AcProgressBarVisible
        {
            get { return _progressBarVisible; }
            set
            {
                //this.progressPanel.Visible = value;
                //_progressBarVisible = value;
            }
        }

        private bool _opcionesServicioVisible = true;
        public bool AcOpcionesServicioVisible
        {
            get { return _opcionesServicioVisible; }
            set
            {
                //this.navOpcionesServicio.Visible = value;
                //_opcionesServicioVisible = value;
            }
        }

        private bool _opcionGeneralesVisible = true;
        public bool AcOpcionesGeneralesVisible
        {
            get { return _opcionGeneralesVisible; }
            set
            {
                //this.navOpcionesGenerales.Visible = value;
                //_opcionGeneralesVisible = value;
            }
        }

        private bool _opcionesMantenimientoVisible = true;
        public bool AcOpcionesMantenimientoVisible
        {
            get { return _opcionesMantenimientoVisible; }
            set
            {
                //this.navMantenimiento.Visible = value;
                //_opcionesMantenimientoVisible = value;
            }
        }

        private bool _agregarVisible = true;
        public bool AcAgregarVisible
        {
            get { return _agregarVisible; }
            set
            {
                //this.btnAgregar.Visible = value;
                //_agregarVisible = value;
            }
        }

        private bool _editarVisible = true;
        public bool AcEditarVisible
        {
            get { return _editarVisible; }
            set
            {
                //this.btnEditar.Visible = value;
                //_editarVisible = value;
            }
        }

        private bool _eliminarVisible = true;
        public bool AcEliminarVisible
        {
            get { return _eliminarVisible; }
            set
            {
                //this.btnEliminar.Visible = value;
                //_eliminarVisible = value;
            }
        }

        private bool _verVisible = true;
        public bool AcVerVisible
        {
            get { return _verVisible; }
            set
            {
                //this.btnVer.Visible = value;
                //_verVisible = value;
            }
        }

        private bool _grabarVisible = true;
        public bool AcGrabarVisible
        {
            get { return _grabarVisible; }
            set
            {
                //this.btnGrabar.Visible = value;
                //_grabarVisible = value;
            }
        }

        private bool _cancelarVisible = true;
        public bool AcCancelarVisible
        {
            get { return _cancelarVisible; }
            set
            {
                //this.btnCancelar.Visible = value;
                //_cancelarVisible = value;
            }
        }
        #endregion

        protected void ShowAlertOk(string titulo, string messaje)
        {
            //this.alertControl.AppearanceText.ForeColor = System.Drawing.Color.Green;
            //this.alertControl.Show(this, titulo, messaje);
        }

        protected void ShowAlertError(string titulo, string messaje)
        {
            //this.alertControl.AppearanceText.ForeColor = System.Drawing.Color.Red;
            //this.alertControl.Show(this, titulo, messaje);
        }

        protected void onProcessing(bool estado = true)
        {
            //this.progressPanel.Visible = estado;
            if (estado)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cbbNuevo_Click(object sender, EventArgs e)
        {
            OnNuevo();
        }

        private void cbbEditar_Click(object sender, EventArgs e)
        {
            OnEditar();
        }

        private void cbbEliminar_Click(object sender, EventArgs e)
        {
            OnEliminar();
        }

        private void cbbImprimir_Click(object sender, EventArgs e)
        {
            OnImprimir();
        }

        private void cbbVista_Click(object sender, EventArgs e)
        {
            OnVista();
        }

        private void cbbRefrescar_Click(object sender, EventArgs e)
        {
            OnRefrescar();
        }

        private void cbbVer_Click(object sender, EventArgs e)
        {
            
            OnVer();
        }

        private void cbbImportar_Click(object sender, EventArgs e)
        {
            OnImportar();
        }

        private void cbbCamEst_Click(object sender, EventArgs e)
        {
            OnCambiar();
        }

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar();
        }

        private void cbbProcesarEstado_Click(object sender, EventArgs e)
        {
            OnProcesarEstado();
        }

        private void cbbDeshacerEstado_Click(object sender, EventArgs e)
        {
            OnDeshacerEstado();
        }

        private void cbbCopiar_Click(object sender, EventArgs e)
        {
            OnCopiar();
        }

        internal void OcultarBarra()
        {
            this.toolBar.Visible = false;
        }

        internal void RenombrarNombreBoton(BaseRegBotones nombreBoton, string nuevoTooTipText)
        {
            switch (nombreBoton)
            {
                case BaseRegBotones.cbbNuevo:
                    cbbNuevo.ToolTipText = nuevoTooTipText;                    
                    break;
                case BaseRegBotones.cbbEditar:
                    cbbEditar.ToolTipText = nuevoTooTipText;             
                    break;
                case BaseRegBotones.cbbEliminar:
                    cbbEliminar.ToolTipText = nuevoTooTipText;                    
                    break;
                case BaseRegBotones.cbbCamEst:
                    cbbCamEst.ToolTipText = nuevoTooTipText;                    
                    break;
                case BaseRegBotones.cbbVer:
                    cbbVer.ToolTipText = nuevoTooTipText;                    
                    break;
                case BaseRegBotones.cbbVista:
                    cbbVista.ToolTipText = nuevoTooTipText;                    
                    break;
                case BaseRegBotones.cbbImprimir:
                    cbbImprimir.ToolTipText = nuevoTooTipText;                    
                    break;
                case BaseRegBotones.cbbRefrescar:
                    cbbRefrescar.ToolTipText = nuevoTooTipText;

                    break;
                case BaseRegBotones.cbbImportar:
                    cbbImportar.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbCancelar:
                    cbbCancelar.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbProcesarEstado:
                    cbbProcesarEstado.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbDeshacerEstado:
                    cbbDeshacerEstado.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbCopiar:
                    cbbCopiar.ToolTipText = nuevoTooTipText;
                    break;

            }
        }
        //protected virtual void  OnActivaFormulario(){ }
        //private void frmBase_Activated(object sender, EventArgs e)
        //{
        //    OnActivaFormulario();
        //}
    }
}