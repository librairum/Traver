using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Collections;

namespace Prod.UI.Win
{
    public partial class frmBaseReg : Telerik.WinControls.UI.RadForm
    {
        public frmBaseReg()
        {
            InitializeComponent();
            _extensions = new Extensions();
            commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            commandBarStripElement1.BorderWidth = 0;
            //this.radPanel1.Visible = false;
            this.HabilitarBotones(true, true, false, false, true);
        }
        public void OnEnforcarRegistro(bool esNuevo, RadGridView gv, string codigoRegistro, string nomCol)
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
                            GridViewSearchRowInfo gvs = gv.MasterView.TableSearchRow;
                            gvs.HighlightResults = false;
                            gvs.Cells[nomCol].ViewTemplate.MasterViewInfo.TableSearchRow.Search(codigoRegistro);

                        }
                    }

                }
            }
        }
        private Extensions _extensions;

        public FormEstate Estado { get; set; }
        public object Result { get; set; }
        public object Id { get; set; }
        public object Id1 { get; set; }
        public object Id2 { get; set; }

        public bool IsPrincipal { get; set; }
        public bool IsDetalle { get; set; }
        public bool IsSaveChanges { get; set; }

        private string _titulo;
        private bool _esMantenimiento = false;

        #region Propiedades
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                //this.lblTitulo.Text = _titulo;
                this.Text = _titulo;
            }
        }

        #endregion

        protected virtual void OnGuardar()
        { }

        protected virtual void OnCancelar()
        { this.Close(); }

        protected virtual void OnVista()
        {

        }

        protected virtual void OnImprimir()
        {
        }

        protected virtual void OnPrimero()
        {

        }

        protected virtual void OnSiguiente()
        {

        }
        protected virtual void OnUltimo()
        {

        }
        protected virtual void OnAnterior()
        {

        }
        private void cbbGuardar_Click(object sender, EventArgs e)
        {
            OnGuardar();
        }

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar();
        }
        protected virtual void HabilitarRadBar(ElementVisibility barra1, ElementVisibility barra2)
        {
            commandBarStripElement1.Visibility = barra1;
            commandBarStripElement2.Visibility = barra2;

        }
        protected virtual void HabilitarBotones(bool guardar, bool cancelar,
            bool vistaprevia, bool imprimir, bool navegacion)
        {
            this.cbbGuardar.Visibility = guardar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            this.cbbCancelar.Visibility = cancelar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbVistaPrevia.Visibility = vistaprevia == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbImprimir.Visibility = imprimir == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            commandBarRowElement1.Visibility = guardar || cancelar || vistaprevia || imprimir ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            this.cmdPrimero.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cmdSiguiente.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cmdAnterior.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cmdUltimo.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            commandBarStripElement2.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

        }
        protected virtual void HabilitarBtnBind(ElementVisibility primero, ElementVisibility anterior,
            ElementVisibility siguiente, ElementVisibility ultimo)
        {
            this.cmdPrimero.Visibility = primero;
            this.cmdSiguiente.Visibility = siguiente;
            this.cmdAnterior.Visibility = anterior;
            this.cmdUltimo.Visibility = ultimo;
        }
        protected virtual void ActivarBotones(bool guardar, bool cancelar, bool vistaprevia, bool imprimir)
        {
            this.cbbGuardar.Enabled = guardar;
            this.cbbCancelar.Enabled = cancelar;
            this.cbbVistaPrevia.Enabled = vistaprevia;
            this.cbbImprimir.Enabled = imprimir;
        }
        private void radGridView1_ViewRowFormatting(object sender, RowFormattingEventArgs e)
        {
            //if (e.RowElement is GridTableHeaderRowElement)
            //{
            //    if(e.RowElement.IsSelected)
            //    e.RowElement.DrawFill = true;
            //    e.RowElement.BackColor = Color.Navy;
            //}
            //else {
            //    e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
            //    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            //    e.RowElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
            //    e.RowElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            //}
        }
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
            else
            {

            }
          
            if (e.CellElement is GridHeaderCellElement || e.CellElement is GridTableHeaderCellElement)
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
            }

            /*if (!(e.CellElement is GridHeaderCellElement))
            {
                e.CellElement.Font = nuevaFuente;

            }*/

        }               

        public RadGridView CreateGridVista(RadGridView cv)
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
            cv.SelectionMode = GridViewSelectionMode.CellSelect;
            cv.MultiSelect = true;


            // Posicion de la grillas
            cv.SearchRowPosition = SystemRowPosition.Top;

            //Resaltar filas al pasar mouse
            cv.EnableHotTracking = true;

            //aplico el estilo a la grilla 
            cv.ThemeName = "Office2013Light";

            //oculta el indent la zona que tiene de margen la grilla con sus datos
            cv.ShowRowHeaderColumn = true;

            cv.ShowItemToolTips = true;

            //formateo  el color de las columnas a celeste claro
            cv.ViewCellFormatting += new CellFormattingEventHandler(radGridView1_ViewCellFormatting);
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
        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, 
                                      int withField = 0, bool readOnly = true, bool allowEdit = false, 
                                      bool visible = true, bool isNumeric = false, string textaling = "")
        {

            Telerik.WinControls.UI.GridViewDataColumn newColumn;
            if (isNumeric)
            {
                newColumn = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            }
            else
            {
                newColumn = new Telerik.WinControls.UI.GridViewTextBoxColumn();
                newColumn.FormatString = formatString;
            }

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
            newColumn.MinWidth = withField;
            if (isNumeric)
            {
                ((GridViewMaskBoxColumn)newColumn).Mask = "f";
                newColumn.FormatString = formatString;
            }
                 
            
            //cv.EnableFiltering = true;
            //cv.MasterTemplate.ShowHeaderCellButtons = true;
            //cv.MasterTemplate.ShowFilteringRow = false;
            if (textaling == "left")
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else if (textaling == "center")
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
            
        }

        public void CreateGridComboBoxColumn(RadGridView cv, IList datasource, string caption, 
                                             string field, int visibleindex, string formatString,  
                                             int withField = 0, bool readOnly = true,
                                             bool allowEdit = false, bool visible = true)
        {

            Telerik.WinControls.UI.GridViewComboBoxColumn newColumn = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            cv.MasterTemplate.Columns.Add(newColumn);

            newColumn.DataSource = datasource;
            newColumn.ValueMember = "Value";
            newColumn.DisplayMember = "Text";

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
        }
        public void CreateGridDateColumn(RadGridView cv, string caption, string field, int visibleindex,
                                         string formatString, int withField = 0,
                                         bool readOnly = true, bool allowEdit = false,
                                         bool visible = true, string textaling = "")
        {
            Telerik.WinControls.UI.GridViewMaskBoxColumn newColumn;

            newColumn = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            newColumn.MaskType = Telerik.WinControls.UI.MaskType.DateTime;
            newColumn.Mask = "d";

            newColumn.FormatString = formatString;
            cv.MasterTemplate.Columns.Add(newColumn);
            newColumn.HeaderText = caption;
            newColumn.FieldName = field;
            newColumn.Name = field;
            newColumn.IsVisible = visible;
            newColumn.ReadOnly = readOnly;
            if (withField != 0)
                newColumn.Width = withField;
            newColumn.MinWidth = withField;
            if (textaling == "left")
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else if (textaling == "center")
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

        }
        public void CreateGridChkColumn(RadGridView cv, string caption, string field, int visibleindex, 
                                        string formatString, int withField = 0, bool readOnly = true,
                                        bool allowEdit = false, bool visible = true)
        {
            Telerik.WinControls.UI.GridViewCheckBoxColumn newColumn = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
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

        private void cbbVistaPrevia_Click(object sender, EventArgs e)
        {
            OnVista();
        }

        private void cbbImprimir_Click(object sender, EventArgs e)
        {
            OnImprimir();
        }

        private void cmdPrimero_Click(object sender, EventArgs e)
        {
            OnPrimero();
        }

        private void cmdAnterior_Click(object sender, EventArgs e)
        {
            OnAnterior();
        }

        private void cmdSiguiente_Click(object sender, EventArgs e)
        {
            OnSiguiente();
        }

        private void cmdUltimo_Click(object sender, EventArgs e)
        {
            OnUltimo();
        }
        
        private void frmBaseReg_KeyUp(object sender, KeyEventArgs e)
        {                       
            if (this.ActiveControl is RadGridView) return;
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (cbbGuardar.IsMouseOver && cbbGuardar.IsFocused)
                {
                    OnGuardar();
                    return;
                }
            }

            if (e.KeyValue == (char)Keys.Enter) 
            {
                FocusNextControl();                
            }
            
            if (e.KeyValue == (char)Keys.Down) {
                FocusNextControl();
            }

            if (e.KeyValue == (char)Keys.Up) {
                FocusPreviousControl();
            }

           

        }

        #region "navegacion entre controles"
        private Control[] listaCajas(Form formulario)
        {
            int nrocajas = 0;
            Control[] controles = new Control[cantidadCajas(this)];
            foreach (Control control in formulario.Controls)
            {
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls)
                    {
                        if (childControl is RadTextBox && childControl.Enabled == true)
                        {
                            controles[nrocajas] = childControl;
                            nrocajas++;
                        }
                    }
                }
                else
                {
                    controles[nrocajas] = control;
                    nrocajas++;
                }

            }
            return controles;
        }
        private int cantidadCajas(Form formulario)
        {
            int nrocajas = 0;
            foreach (Control control in formulario.Controls)
            {
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls)
                    {
                        if (childControl is RadTextBox && childControl.Enabled == true)
                        {
                            nrocajas++;
                        }
                    }
                }
                else if (!(control is RadGridView))
                {
                    nrocajas++;
                }
            }
            return nrocajas;
        }
        private Control ultimoControl()
        {
            int cantidadElementos = listaCajas(this).Length - 1;
            int ctrlIndiceMayor = 0;
            int ctrlIndiceMenor = -1;
            int pnlIndiceMayor = 0;
            int pnlIndiceMenor = -1;

            Control nombre = null;
            for (int i = 0; i <= cantidadElementos; i++)
            {
                pnlIndiceMenor = listaCajas(this)[i].Parent.TabIndex;
                ctrlIndiceMenor = listaCajas(this)[i].TabIndex;
                if (pnlIndiceMenor > pnlIndiceMayor)
                {
                    pnlIndiceMayor = pnlIndiceMenor;
                    nombre = listaCajas(this)[i];
                }
                else if (pnlIndiceMenor == pnlIndiceMayor)
                {
                    if (ctrlIndiceMenor > ctrlIndiceMayor)
                    {
                        nombre = listaCajas(this)[i];
                    }
                }
            }
            return nombre;
        }
        private void FocusNextControl()
        {
            string ultimocontrol = ultimoControl().Name;

            if (GetNextControl(this.ActiveControl, false).Name == ultimocontrol)
            {
                cbbGuardar.IsMouseOver = true;
                cbbGuardar.Focus();
            }
            else
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            } 
        }
        private void FocusPreviousControl() 
        {
            string ultimocontrol = ultimoControl().Name;
            // veo si el control actual es ultimo control activado del formulario
            if (GetNextControl(this.ActiveControl, false).Name == ultimocontrol) 
            {
                cbbGuardar.IsMouseOver = true;
                cbbGuardar.Focus();
            }
            else
            {
                this.SelectNextControl(this.ActiveControl, false, true, true, true);                
            }
        }
        #endregion
        private void frmBaseReg_KeyDown(object sender, KeyEventArgs e)
        {
           
            //RadDateTimePicker ctrlFecha = GetNextControl(this.ActiveControl, false) as RadDateTimePicker;

            //if (e.KeyValue == (char)Keys.Up)
            //{
            //    ctrlFecha.ReadOnly = true;
            //}
            //else if (e.KeyValue == (char)Keys.Down)
            //{
            //    ctrlFecha.ReadOnly = false;
            //}
        }

    }
}
