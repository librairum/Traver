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

namespace Fac.UI.Win
{
    public partial class frmBaseMante : Telerik.WinControls.UI.RadForm
    {
       public bool isMsgBox = false;
        public frmBaseMante()
        {
            InitializeComponent();
            
            commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            commandBarStripElement1.BorderWidth = 0;
            cbbNuevo.IsMouseOver = true;
            cbbNuevo.Focus();
            //cbbEliminar.Focus();
            //cbbEditar.Focus();
        }

        private void gridControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                OnEliminar();
            }
        }
        public void OnEnfocarRegistro(bool esNuevo, RadGridView gv, string codigoRegistro,string nomcol) {
            if (gv.IsLoaded) {
   
                
                    foreach (GridViewRowInfo row in gv.Rows) {
                        if (row.Cells[nomcol].Value.ToString() == codigoRegistro)
                        {
                            gv.Rows[row.Index].IsCurrent = true;
                            gv.Rows[row.Index].IsSelected = true;
                        }
                        
                    }                    
                
            }
        }
      
        private Extensions _extensions;

        public FormEstate Estado { get; set; }
        public DetailEstate EstadoDetalle { get; set; }
        public object Result { get; set; }
        public object Id { get; set; }
        public object Id1 { get; set; }
        public object Id2 { get; set; }

        public bool IsPrincipal { get; set; }
        public bool IsDetalle { get; set; }
        public bool IsSaveChanges { get; set; }
       
        private string _titulo;

        protected virtual void HabilitarBotones(bool nuevo, bool editar, bool eliminar,
            bool guardar, bool cancelar, bool vista)
        {


            cbbNuevo.Visibility = nuevo ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbEditar.Visibility = editar ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbEliminar.Visibility = eliminar ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbGuardar.Visibility = guardar ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbCancelar.Visibility = cancelar ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbVistaPrevia.Visibility = vista ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            VerBotonesNavegacion(false);
        }
        private void VerBotonesNavegacion(bool activa)
        {
            ElementVisibility estado;
            if (activa)
            {
                estado = ElementVisibility.Visible;
            }
            else
            {
                estado = ElementVisibility.Collapsed;
            }
            cbbPrimero.Visibility = estado;
            cbbAnterior.Visibility = estado;
            cbbSiguiente.Visibility = estado;
            cbbUltimo.Visibility = estado;
        }
        public RadCommandBar barraMenu
        {
            get
            {
                return this.radCommandBar1;
            }
        }
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
        public void BaselimpiarCajas(Control formulario) {

            foreach (Control ctrl in formulario.Controls) {
                if (ctrl is RadPanel || ctrl is RadGroupBox) {
                    BaselimpiarCajas(ctrl);
                }
                if (ctrl is RadTextBox) {
                    ((RadTextBox)ctrl).Text = "";

                }
                if (ctrl is TextBox) {
                    ((TextBox)ctrl).Text = "";
                }
                if (ctrl is RadCheckBox) {
                    ((RadCheckBox)ctrl).CheckState = CheckState.Unchecked;
                }
                if (ctrl is RadRadioButton) {
                    ((RadRadioButton)ctrl).CheckState = CheckState.Unchecked;
                }
            }
        }
        public void BaseHabilitarCajas(Control formulario,bool valor) {
            foreach (Control ctrl in formulario.Controls)
            {
                if (ctrl is RadPanel || ctrl is RadGroupBox) {
                    BaseHabilitarCajas(ctrl, valor);
                }

                if (ctrl is RadTextBox)
                {
                    ((RadTextBox)ctrl).Enabled = valor;

                }
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Enabled = valor;
                }
                if (ctrl is RadRadioButton ) {
                    ((RadRadioButton)ctrl).Enabled = valor;
                }
                if (ctrl is RadCheckBox) {
                    ((RadCheckBox)ctrl).Enabled = valor;
                }
            }
        }
        protected virtual void gestionarBotones(bool nuevo, bool editar, bool eliminar,
            bool guardar, bool  cancelar, bool vistapreliminar=false,bool imprimir=false, bool navegacion=false) {
                cbbNuevo.Visibility = nuevo == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbEditar.Visibility = editar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbEliminar.Visibility = eliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbGuardar.Visibility = guardar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbCancelar.Visibility = cancelar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                if (!guardar && !cancelar)
                {
                    barGuardaCancel.Visibility = ElementVisibility.Collapsed;
                }
                else {
                    barGuardaCancel.Visibility = ElementVisibility.Visible;
                }
                cbbVistaPrevia.Visibility = vistapreliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbImprimir.Visibility = imprimir == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                if (!imprimir && !vistapreliminar)
                {
                    barImprimir.Visibility = ElementVisibility.Collapsed;
                }
                else {
                    barImprimir.Visibility = ElementVisibility.Visible;
                }
                //cbbCambiarEstado.Visibility = cambiaestado == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                //cbbSeleccion.Visibility = bonos == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                //if (!cambiaestado && !bonos)
                //{
                //    barOtros.Visibility = ElementVisibility.Collapsed;
                //}
                //else {
                //    barOtros.Visibility = ElementVisibility.Visible;
                //}
                cbbPrimero.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbAnterior.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbSiguiente.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbUltimo.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                if (!navegacion)
                {
                    barNavegacion.Visibility = ElementVisibility.Collapsed;
                }
                else {
                    barNavegacion.Visibility = ElementVisibility.Visible;
                }
                //barGuardaCancel.Visibility = ElementVisibility.Collapsed;
                //barOtros.Visibility = ElementVisibility.Collapsed;
        }
        protected virtual void habilitarBotones(bool btnIUD, bool btnSC) {
            cbbNuevo.Enabled = btnIUD;
            cbbEditar.Enabled = btnIUD;
            cbbEliminar.Enabled = btnIUD;
            cbbGuardar.Enabled = btnSC;
            cbbCancelar.Enabled = btnSC;
            cbbVistaPrevia.Enabled = btnIUD;
            
        }
        protected virtual void botonesMantenimiento(bool nuevo, bool editar, bool eliminar,
            bool guardar, bool cancelar, bool navegacion) { 
                cbbNuevo.Visibility = nuevo == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbEditar.Visibility = editar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbEliminar.Visibility = eliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                
                cbbGuardar.Visibility = guardar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbCancelar.Visibility = cancelar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                if (!guardar && !cancelar)
                {
                    barGuardaCancel.Visibility = ElementVisibility.Collapsed;
                }
                else {
                    barGuardaCancel.Visibility = ElementVisibility.Visible;
                }
                cbbPrimero.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbAnterior.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbSiguiente.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                cbbUltimo.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                if (!navegacion)
                {
                    barNavegacion.Visibility = ElementVisibility.Collapsed;
                }
                else {
                    barNavegacion.Visibility = ElementVisibility.Visible;
                }
                cbbVistaPrevia.Visibility = ElementVisibility.Collapsed;
                cbbImprimir.Visibility = ElementVisibility.Collapsed;
                //cbbCambiarEstado.Visibility = ElementVisibility.Collapsed;
                //cbbSeleccion.Visibility = ElementVisibility.Collapsed;
                barImprimir.Visibility = ElementVisibility.Collapsed;
                //barOtros.Visibility = ElementVisibility.Collapsed;
        }


        internal void OcultarBotones()
        {
            cbbNuevo.Visibility = ElementVisibility.Collapsed;
            cbbEditar.Visibility = ElementVisibility.Collapsed;
            cbbEliminar.Visibility = ElementVisibility.Collapsed;
            barGuardaCancel.Visibility = ElementVisibility.Collapsed;
            cbbGuardar.Visibility = ElementVisibility.Collapsed;
            cbbCancelar.Visibility = ElementVisibility.Collapsed;
            cbbVistaPrevia.Visibility = ElementVisibility.Collapsed;
            cbbImprimir.Visibility = ElementVisibility.Collapsed;
            cbbPrimero.Visibility = ElementVisibility.Collapsed;
            cbbAnterior.Visibility = ElementVisibility.Collapsed;
            cbbSiguiente.Visibility = ElementVisibility.Collapsed;
            cbbUltimo.Visibility = ElementVisibility.Collapsed;

        }

        internal void HabilitaBotonPorNombre(BaseRegBotones nombreBoton)
        {
            switch (nombreBoton)
            { 
                case BaseRegBotones.cbbNuevo:
                    cbbNuevo.Visibility = ElementVisibility.Visible;
                    barGuardaCancel.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEditar:
                    cbbEditar.Visibility = ElementVisibility.Visible;
                    barGuardaCancel.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEliminar:
                    cbbEliminar.Visibility = ElementVisibility.Visible;
                    barGuardaCancel.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGuardar:
                    cbbGuardar.Visibility = ElementVisibility.Visible;
                    barImprimir.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbCancelar:
                    cbbCancelar.Visibility = ElementVisibility.Visible;
                    barImprimir.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVistaPreliminar:
                    cbbVistaPrevia.Visibility = ElementVisibility.Visible;
                    barNavegacion.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbImprimir:
                    cbbImprimir.Visibility = ElementVisibility.Visible;
                    barNavegacion.Visibility = ElementVisibility.Visible;
                    break;
                case  BaseRegBotones.cmdPrimero:
                    cbbPrimero.Visibility = ElementVisibility.Visible;                    
                    break;
                case BaseRegBotones.cmdAnterior:
                    cbbAnterior.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cmdSiguiente:
                    cbbSiguiente.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cmdUltimo:
                    cbbUltimo.Visibility = ElementVisibility.Visible;
                    break;
                default:
                    break;
            }

        }

        protected virtual void OnBuscar()
        {

        }
        protected virtual void OnNuevo()
        {
            
        }
        protected virtual void OnEditar()
        { }

        protected virtual void OnEliminar()
        { }


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
        protected virtual void OnCambiarEstado() { 
            
        }
        protected virtual void OnPrimero() { }
        protected virtual void OnSiguiente() { }
        protected virtual void OnAnterior() { }
        protected virtual void OnUltimo() { }
        
        private void cbbGuardar_Click(object sender, EventArgs e)
        {
            OnGuardar();  
            //barraMenu.
        }

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar();
            //cbbGuardar.IsMouseOver = false;
        }
        private void cbbNuevo_Click(object sender, EventArgs e)
        {
            OnNuevo();
            //cbbGuardar.IsMouseOver = false;
        }

        private void cbbEditar_Click(object sender, EventArgs e)
        {
            OnEditar();
            //cbbGuardar.IsMouseOver = false;
        }

        private void cbbEliminar_Click(object sender, EventArgs e)
        {
            OnEliminar();
        }
        
        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    OnGuardar();
        //}

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    OnCancelar();
        //}
        private void radGridView1_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement is GridTableHeaderRowElement)
            {
                e.RowElement.BackColor = Color.MediumAquamarine;
            }
        }

        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            e.CellElement.DrawFill = false;
            e.CellElement.BorderWidth = 1;
            e.CellElement.DrawBorder = true;
            e.CellElement.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            e.CellElement.BorderColor = Color.FromArgb(209, 225, 245);
            e.CellElement.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
        }
        private void radGridView1_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            
            Font nuevaFuente = new Font("Arial", 8f);
            //celeste claro
           
            if (e.CellElement is GridHeaderCellElement) {
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
            if (!(e.CellElement is GridHeaderCellElement))
            {
                e.CellElement.Font = nuevaFuente;

            }
            

        }

        private void radGridView_ViewRowFormatting(object sender, RowFormattingEventArgs e) {
          
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
        public RadGridView CreateGridEditable(RadGridView cv) {

            return cv;
        }
        public RadGridView CreateGridVista(RadGridView cv) {
            
            cv.Columns.Clear();
            cv.AutoGenerateColumns = false;

            //Deshabilitar
            cv.AllowAddNewRow = false;
            cv.ShowGroupPanel = false;
            cv.AllowDragToGroup = false;
            cv.AllowDeleteRow = false;
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
            //cv.KeyUp += new KeyEventHandler(gridControl_KeyUp);
            cv.MasterView.TableSearchRow.HighlightResults = false;
            return cv;
        }
        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true, bool isNumeric = false)
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

            if (isNumeric)
                ((GridViewMaskBoxColumn)newColumn).Mask = "f";

            //newColumn.DisplayFormat.FormatType = formatType;
            //if (formatType == DevExpress.Utils.FormatType.Custom)
            //    gc.DisplayFormat.Format = new BaseFormatter();
            //gc.DisplayFormat.FormatString = formatString;
            newColumn.FormatString = formatString;                                                                      
                                              
        }

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
      
        private void frmBaseMante_Load(object sender, EventArgs e)
        {
            
        }

        private void cbbPrimero_Click(object sender, EventArgs e)
        {
            OnPrimero();
        }

        private void cbbAnterior_Click(object sender, EventArgs e)
        {
            OnAnterior();
        }

        private void cbbSiguiente_Click(object sender, EventArgs e)
        {
            OnSiguiente();
        }

        private void cbbUltimo_Click(object sender, EventArgs e)
        {
            OnUltimo();
        }

        private void cbbCambiarEstado_Click(object sender, EventArgs e)
        {
            OnCambiarEstado();
        }

        private void commandBarStripElement1_ItemOutOfOverflow(object sender, EventArgs e)
        {                                     
        }
        protected virtual void menuBar_KeyUp(object sender, KeyEventArgs e) { 
            
        }
        private void radCommandBar1_KeyUp(object sender, KeyEventArgs e)
        {
    
        }

        private void commandBarStripElement1_ItemOverflowed(object sender, EventArgs e)
        {          
        }

        private void radCommandBar1_MouseHover(object sender, EventArgs e)
        { 
          
        }
                
        private void frmBaseMante_KeyUp(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter) {

                if (Estado == FormEstate.List)
                {
                    if (cbbNuevo.IsMouseOver && cbbNuevo.IsFocused)
                    {
                        OnNuevo();
                        return;
                    }
                }

                if (Estado == FormEstate.Edit || Estado == FormEstate.New)
                {
                    if (cbbGuardar.IsMouseOver && cbbGuardar.IsFocused)
                    {
                        OnGuardar();
                        return;
                    }
                }               
                                                                                              
            }
            if (ActiveControl is RadGridView) return;
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Enter))
            {
                Util.enfocar(ActiveControl, GetNextControl(ActiveControl, true), e, this, radCommandBar1);
            }
        }
        void enfocaBotonNuevo()
        {
            if (Estado == FormEstate.New)
            {
                cbbNuevo.IsMouseOver = true;
            }
            else if (Estado == FormEstate.Edit)
            {
                cbbNuevo.IsMouseOver = false;
            }
            cbbGuardar.IsMouseOver = false;
        }
        private void frmBaseMante_Click(object sender, EventArgs e)
        {
            //if (Estado == FormEstate.List && !cbbNuevo.IsMouseOver) {
            //    cbbNuevo.IsMouseOver = true;
             
            //}
        }

        private void radCommandBar1_MouseDown(object sender, MouseEventArgs e)
        {


            //string nombre = ((RadCommandBarBaseItem)sender).Name;
            //MessageBox.Show(nombre);
            //CommandBar
            
                //if(e.Button == System.Windows.Forms.MouseButtons.Left && cbbNuevo.IsMouseOver)
                //{
                    
                //}
            //((RadCommandBar)sender).CommandBarElement.Rows[0].Strips[0].Items[
        }

        private void frmBaseMante_Activated(object sender, EventArgs e)
        {
            cbbNuevo.Focus();
            //MessageBox.Show("Evento de foco");
        }
      
    }
}


