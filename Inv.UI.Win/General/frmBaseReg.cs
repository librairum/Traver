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

namespace Inv.UI.Win
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
            this.HabilitarBotones(true, true, false, false,false);   
      
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

            }
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
        public void OcultarBarra() 
        {
            this.radCommandBar1.Visible = false;
        }

        internal void OcultarBotones() {
            cbbCancelar.Visibility = ElementVisibility.Collapsed;
            cbbGuardar.Visibility = ElementVisibility.Collapsed;
            cbbVistaPrevia.Visibility = ElementVisibility.Collapsed;
            cbbNuevo.Visibility = ElementVisibility.Collapsed;
            cbbEditar.Visibility = ElementVisibility.Collapsed;
            cbbEliminar.Visibility = ElementVisibility.Collapsed;
            cbbImprimir.Visibility = ElementVisibility.Collapsed;
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
        //AGREGADOS
        protected virtual void OnNuevo() 
        { }
        protected virtual void OnEditar()
        { }
        protected virtual void OnEliminar()
        { }

        //END
        protected virtual void OnVista()
        {
            
        }

        protected virtual void OnImprimir()
        {
        }
        protected virtual void OnVer() { 
            
        }
        protected virtual void OnPrimero() {
            
        }

        protected virtual void OnSiguiente() { 
        
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
        protected virtual void HabilitarRadBar(ElementVisibility barra1,ElementVisibility barra2){
            commandBarStripElement1.Visibility = barra1;
            commandBarStripElement2.Visibility = barra2;
            
        }
         protected virtual void HabilitarBotones(bool guardar,bool cancelar,
             bool vistaprevia,bool imprimir, bool navegacion) {
             ////Nuevo
             //    this.cbbNuevo.Visibility = Nuevo == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

             //    this.cbbEditar.Visibility = Editar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

             //    this.cbbEliminar.Visibility = Eliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

             ////end
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
         protected virtual void HabilitarBotonesCabecera(bool guardar, bool cancelar,
             bool vistaprevia, bool imprimir, bool navegacion, bool Nuevo, bool Editar, bool Eliminar)
         {
             ////Nuevo
             this.cbbNuevo.Visibility = Nuevo == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

             this.cbbEditar.Visibility = Editar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

             this.cbbEliminar.Visibility = Eliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

             ////end
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
         public void cargarPermisos(string nombreFormulario) { 
         
         }
         protected virtual void HabilitarBtnBind(ElementVisibility primero, ElementVisibility anterior,
             ElementVisibility siguiente, ElementVisibility ultimo) {
                 this.cmdPrimero.Visibility = primero;
                 this.cmdSiguiente.Visibility = siguiente;
                 this.cmdAnterior.Visibility = anterior;
                 this.cmdUltimo.Visibility = ultimo;
         }
         protected virtual void ActivarBotones(bool guardar, bool cancelar, bool vistaprevia, bool imprimir, bool Nuevo,
             bool Editar, bool Eliminar) {
             this.cbbGuardar.Enabled = guardar;
             this.cbbCancelar.Enabled = cancelar;
             this.cbbVistaPrevia.Enabled = vistaprevia;
             this.cbbImprimir.Enabled = imprimir;
             this.cbbNuevo.Enabled = Nuevo;
             this.cbbEditar.Enabled = Editar;
             this.cbbEliminar.Enabled = Eliminar;
         }
        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    OnGuardar();
        //}

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    OnCancelar();
        //}
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
         public void CreateGridDecimalColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString,
                                      int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true,
                                       bool isNumeric = false, string textaling = "")
         {
             Telerik.WinControls.UI.GridViewDataColumn newColumn;
             if (isNumeric)
             {
                 newColumn = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
             }
             else
             {
                 newColumn = new Telerik.WinControls.UI.GridViewTextBoxColumn();
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



           
             newColumn.FormatString = formatString;

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

         public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true, bool isNumeric = false, string textaling = "")
        {

            //Telerik.WinControls.UI.GridViewDataColumn newColumn;

            GridViewDataColumn newColumn;
            if (isNumeric)
            {
                newColumn = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
                //((GridViewMaskBoxColumn)newColumn).Mask = "0000.00";
                
                
            }
            else
            {
                newColumn = new Telerik.WinControls.UI.GridViewTextBoxColumn();
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

            if (isNumeric)
                ((GridViewMaskBoxColumn)newColumn).Mask = "f";     
                newColumn.FormatString = formatString;
            //    ((GridViewMaskBoxColumn)newColumn).Mask = "f4";
            //    newColumn.FormatString = formatString;
        }
        public void CreateButtonColumn(RadGridView cv,string headerText,string field,int width) {
            
                GridViewCommandColumn commandColumn = new GridViewCommandColumn();
                ((GridViewCommandColumn)commandColumn).TextAlignment = ContentAlignment.MiddleCenter;
                cv.MasterTemplate.Columns.Add(commandColumn);
                commandColumn.HeaderText = headerText;
                commandColumn.Width = width;                    
                commandColumn.FieldName = field;                                
                commandColumn.Name = field;
                commandColumn.IsVisible = true;
                //commandColumn.HeaderText = "Mantenimiento";
                //commandColumn.HeaderText = headerText;
               
        }
        /*
         GridViewCommandColumn commandColumn = new GridViewCommandColumn();
    commandColumn.Name = "CommandColumn";
    commandColumn.UseDefaultText = false;
    commandColumn.FieldName = "ProductName";
    commandColumn.HeaderText = "Order";
    radGridView1.MasterTemplate.Columns.Add(commandColumn);
         
         */
        public void CreateGridComboBoxColumn(RadGridView cv, IList datasource, string caption, string field, int visibleindex, string formatString, int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true)
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

        protected Extensions Extensions
        {
            get { return this._extensions; }
        }
        Control[] listaCajas(Form formulario)
        {
            int nrocajas = 0;
            Control[] controles = new Control[cantidadCajas(this)];
            //string controles = "";
            
            foreach (Control contenedores in formulario.Controls)
            {
                if (contenedores is RadPanel || contenedores is RadGroupBox)
                {
                    foreach (Control caja in contenedores.Controls)
                    {
                        if (caja is RadTextBox && caja.Enabled == true)
                        {
                            controles[nrocajas] = caja;
                            
                            nrocajas++;
                        }
                    }
                }                
            }
            
            return  controles;
        }
        int cantidadCajas(Form formulario)
        {
            int nrocajas = 0;
            foreach (Control contenedores in formulario.Controls)
            {
                if (contenedores is RadPanel || contenedores is RadGroupBox)
                {
                    foreach (Control caja in contenedores.Controls)
                    {
                        if (caja is RadTextBox && caja.Enabled == true)
                        {
                            nrocajas++;
                        }
                    }
                }                
            }
            return nrocajas;
        }

        Control ultimoControl()
        {
            //ordenar arreglo
            
            //si son 3 elementos 
            int cantidadElentos = listaCajas(this).Length - 1;
            int ctrlIndiceMayor = 0;
            int ctrlIndiceMenor = -1;
            int pnlIndiceMayor = 0;
            int pnlIndiceMenor = -1;
            Control nombre = null;
            for (int i = 0; i <= cantidadElentos; i++)
            {
                pnlIndiceMenor = listaCajas(this)[i].Parent.TabIndex;
                ctrlIndiceMenor = listaCajas(this)[i].TabIndex;
                if (pnlIndiceMenor > pnlIndiceMayor) {
                    pnlIndiceMayor = pnlIndiceMenor;
                    nombre = listaCajas(this)[i];
                }
                else if (pnlIndiceMenor == pnlIndiceMayor) {
                    if (ctrlIndiceMenor > ctrlIndiceMayor) {
                        nombre = listaCajas(this)[i];
                    }
                } 
            }
            return nombre;
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

        private void radButton1_Click(object sender, EventArgs e)
        {
            OnGuardar();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            OnCancelar();
        }

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
           try
           {
               if (e.KeyCode == Keys.Enter)
               {
                   if (cbbGuardar.IsMouseOver && cbbGuardar.IsFocused)
                   {
                       OnGuardar();
                       return;
                   }
               }
               if (ActiveControl is RadGridView || ActiveControl is DataGridView) return;
               if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Enter))
               {
                   Util.enfocar(ActiveControl, GetNextControl(ActiveControl, true), e, this, radCommandBar1);
               } 
           }
           catch (Exception ex) {            
           }         
        }
        private void FocusPreviousControl() {
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
        private void FocusNextControl() {
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
        private void frmBaseReg_KeyDown(object sender, KeyEventArgs e)
        {

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

        



    }
}
