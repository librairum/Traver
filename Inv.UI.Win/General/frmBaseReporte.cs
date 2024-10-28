using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Inv.UI.Win;
using Telerik.WinControls.Data;

namespace Inv.UI.Win
{
    public partial class frmBaseReporte : Telerik.WinControls.UI.RadForm
    {
        public frmBaseReporte()
        {
            InitializeComponent();
            _extensions = new Extensions();

            //(radPageView.ViewElement as RadPageViewStripElement).ShowItemCloseButton = false;
            //(radPageView.ViewElement as RadPageViewStripElement).StripButtons = StripViewButtons.Scroll;
            commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            commandBarStripElement1.BorderWidth = 0;
            HabilitarBotones(true, true, false, false);
           
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

        //public void CreateGridColumnCheckBox(DevExpress.XtraGrid.Views.Base.ColumnView cv, string caption, string field, int visibleindex, DevExpress.Utils.FormatType formatType, string formatString, int withField = 0, bool readOnly = true, bool allowEdit = false)
        //{
        //    DevExpress.XtraGrid.Columns.GridColumn gc = cv.Columns.Add();

        //    DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
        //    chk.Name = field;

        //    //chk.Columns.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem());
        //    //lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember));

        //    gc.Caption = caption;
        //    gc.FieldName = field;
        //    gc.Name = field;
        //    gc.VisibleIndex = visibleindex;
        //    gc.OptionsColumn.ReadOnly = readOnly;
        //    gc.OptionsColumn.AllowEdit = allowEdit;

        //    if (withField != 0)
        //        gc.Width = withField;

        //    gc.ColumnEdit = chk;

        //    gc.DisplayFormat.FormatType = formatType;
        //    if (formatType == DevExpress.Utils.FormatType.Custom)
        //        gc.DisplayFormat.Format = new BaseFormatter();
        //    gc.DisplayFormat.FormatString = formatString;
        //}
        /*Evento para pintar la cabeceras de la grilla*/
        private void radGridView1_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            
            //celeste claro
            Font nuevaFuente = new Font("Arial", 8f);
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
        public void HabilitarBotones(bool bVista, bool bImprimir, bool bRefrescar, bool bExportar, bool bSeleccionarTodo = false) {
            cbbVista.Visibility = bVista ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbImprimir.Visibility = bImprimir ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbRefrescar.Visibility = bRefrescar ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbExportarMovi.Visibility = bExportar ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbSeleccionarTodo.Visibility = bSeleccionarTodo ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        }
     
        private void RadGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            e.ContextMenu.Items.Clear();
            RadMenuItem itmSeleccionar = new RadMenuItem();
            itmSeleccionar.Name = "itmSeleccionar";
            itmSeleccionar.Text = "Seleccionar todo los registros";
            itmSeleccionar.Click += new EventHandler(delegate(object r, EventArgs a)
            {
                foreach (var fila in ((RadGridView)sender).ChildRows)
                {
                    fila.IsSelected = true;
                }
            });
            e.ContextMenu.Items.Add(itmSeleccionar);
        }

        public RadGridView CreateGrid(RadGridView cv)
        {

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
            
            cv.ThemeName = "Office2013Light";

            //oculta el indent la zona que tiene de margen la grilla con sus datos
            cv.ShowRowHeaderColumn = false;
            //formateo  el color de las columnas a celeste claro
            cv.ViewCellFormatting += new CellFormattingEventHandler(radGridView1_ViewCellFormatting);
            cv.ContextMenuOpening += new ContextMenuOpeningEventHandler(RadGridView1_ContextMenuOpening);
            cv.CellMouseMove += new CellMouseMoveEventHandler(delegate(object sender, MouseEventArgs e)
            {

                GridCellElement cell = cv.ElementTree.GetElementAtPoint(e.Location) as GridCellElement;
                if (cell != null && cell.Value != null)
                {

                    cell.ToolTipText = Util.convertiracadena(cell.Value);
                }
            });
            return cv;
        }
        
        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true,string textaling="", bool isNumeric = false)
        {

            Telerik.WinControls.UI.GridViewDataColumn newColumn = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            
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
            
            if (textaling == "left")
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else if (textaling=="center")
            {
                newColumn.TextAlignment = ContentAlignment.MiddleCenter;
            }
            else if (textaling == "right")
            {
                newColumn.TextAlignment = ContentAlignment.MiddleRight;
            }
            else
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
            
            //if(isNumeric)
            //    ((GridViewMaskBoxColumn)newColumn).Mask = "f4";
            newColumn.FormatString = formatString;
            //cv.EnableFiltering = true;

            //cv.MasterTemplate.ShowHeaderCellButtons = true;
            //cv.MasterTemplate.ShowFilteringRow = false;
            //cv.AllowDragToGroup = false;
            //cv.AllowAddNewRow = false;
            //cv.ShowGroupPanel = false;
            
            //cv.AllowColumnReorder = true;
            //cv.AutoGenerateColumns = false;
     
            //cv.EnableHotTracking = true;
            //cv.AllowAddNewRow = false;
           
        }
      
        //public void CreateGridColumnLookUpEdit(DevExpress.XtraGrid.Views.Base.ColumnView cv, string caption, string field, int visibleindex, DevExpress.Utils.FormatType formatType, string formatString, IList datasource, string displayMember, string valueMember)
        //{
        //    DevExpress.XtraGrid.Columns.GridColumn gc = cv.Columns.Add();

        //    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
        //    lue.Name = field;

        //    lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember));
        //    lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember));

        //    lue.ShowHeader = false;

        //    if (datasource != null)
        //        lue.DataSource = datasource;

        //    lue.DisplayMember = displayMember;
        //    lue.ValueMember = valueMember;

        //    gc.Caption = caption;
        //    gc.FieldName = field;
        //    gc.Name = field;
        //    gc.VisibleIndex = visibleindex;
        //    gc.ColumnEdit = lue;

        //    gc.DisplayFormat.FormatType = formatType;
        //    if (formatType == DevExpress.Utils.FormatType.Custom)
        //        gc.DisplayFormat.Format = new BaseFormatter();
        //    gc.DisplayFormat.FormatString = formatString;
        //}

        private string _titulo;

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
      
        public virtual void OnCancelar()
        { }

      
        protected virtual void OnSalir()
        { }

     

        protected virtual void OnVista()
        { }

        protected virtual void OnImprimir()
        { }
        protected virtual void OnRefrescar()         
        { }
        protected virtual void OnSeleccionarTodo()
        { }
        protected virtual void OnExportar() 
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

        private void cbbSeleccionarTodo_Click(object sender, EventArgs e)
        {
            OnSeleccionarTodo();
        }

        private void OnExportarMovimientos_Click(object sender, EventArgs e)
        {
            OnExportar();
        }

     
    }
}
