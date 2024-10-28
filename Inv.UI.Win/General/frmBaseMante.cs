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
using Inv.BusinessLogic;
namespace Inv.UI.Win
{
    public partial class frmBaseMante : Telerik.WinControls.UI.RadForm
    {
        public frmBaseMante()
        {
            InitializeComponent();
           
            barraComando.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            barraComando.BorderWidth = 0;            
            radCommandBar1.AllowShowFocusCues = true;
            //focao de boton nuevo
            cbbNuevo.Focus();    
          
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
           // cv.ContextMenuOpening += new ContextMenuOpeningEventHandler(RadGridView1_ContextMenuOpening);
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

        //metodo para mostrar los botones asignados
        public void cargarPermisos(string nombreFormulario)
        { 
            bool nuevo, editar, eliminar, guardar, cancelar, vista;
            //el procedimiento Trae_OpcionesPorPerfil devuelve perfil,menu y opciones
            //codigoperfil	codigoMenu	opcxmenu
            //10	        42	        10000000000000000000
            var permisos = SegMenuPorPerfilLogic.Instance.Trae_OpcionesPorPerfil(Logueo.codigoPerfil, Logueo.codModulo, this.Name);
            if (permisos != null)
            {
                string variable = permisos.opcxmenu;
                /*
                 1	Nuevo
                 2	Editar
                 3	Eliminar
                 4	Ver
                 5	Imprimir
                 6	Refrescar
                 7	Importar
                 8	Vista Previa
                 9	Guardar
                 10	Cancelar
                 */
                nuevo = (variable.Substring(0, 1).CompareTo("1") == 0);
                editar = (variable.Substring(1, 1).CompareTo("1") == 0);
                eliminar = (variable.Substring(2, 1).CompareTo("1") == 0);
                guardar = (variable.Substring(8, 1).CompareTo("1") == 0);
                cancelar = (variable.Substring(9, 1).CompareTo("1") == 0);
                vista = (variable.Substring(7, 1).CompareTo("1") == 0);
                HabilitarBotones(nuevo, editar, eliminar, guardar, cancelar, vista);
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

        protected virtual void HabilitarBotones(bool nuevo , bool editar, bool eliminar,
            bool  guardar , bool cancelar, bool vista) {


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
            else {
                estado = ElementVisibility.Collapsed;
            }
            cbbPrimero.Visibility = estado;
            cbbAnterior.Visibility = estado;
            cbbSiguiente.Visibility = estado;
            cbbUltimo.Visibility = estado;                        
        }
        internal void OcultaBarraBotones()
        {
            this.radCommandBar1.Visible = false;

        }
        internal void OcultarBotones()
        {
            cbbNuevo.Visibility = ElementVisibility.Collapsed;
            cbbEditar.Visibility = ElementVisibility.Collapsed;
            cbbEliminar.Visibility = ElementVisibility.Collapsed;                        
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
                    
                    break;
                case BaseRegBotones.cbbEditar:
                    cbbEditar.Visibility = ElementVisibility.Visible;
                    
                    break;
                case BaseRegBotones.cbbEliminar:
                    cbbEliminar.Visibility = ElementVisibility.Visible;
                    
                    break;
                case BaseRegBotones.cbbGuardar:
                    cbbGuardar.Visibility = ElementVisibility.Visible;
                    
                    break;
                case BaseRegBotones.cbbCancelar:
                    cbbCancelar.Visibility = ElementVisibility.Visible;
                    
                    break;
                case BaseRegBotones.cbbVistaPreliminar:
                    cbbVistaPrevia.Visibility = ElementVisibility.Visible;
                    
                    break;

                case BaseRegBotones.cbbImprimir:
                    cbbImprimir.Visibility = ElementVisibility.Visible;
                    
                    break;
                case BaseRegBotones.cmdPrimero:
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
        protected virtual void OnPrimero() { }
        protected virtual void OnSiguiente() { }
        protected virtual void OnAnterior() { }
        protected virtual void OnUltimo() { }
        private void cbbGuardar_Click(object sender, EventArgs e)
        {
            OnGuardar();
           
        }

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar();
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

        private void radGridView_ViewRowFormatting(object sender, RowFormattingEventArgs e) {
          
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
        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, 
                                     int withField = 0, bool readOnly = true, bool allowEdit = false,
                                     bool visible = true, bool isNumeric = false, alinear alinamiento = alinear.izquierda)
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
            {
                ((GridViewMaskBoxColumn)newColumn).Mask = "f";
                newColumn.FormatString = formatString;
            }

            if (alinamiento == alinear.izquierda)
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else if (alinamiento == alinear.centro)
            {
                newColumn.TextAlignment = ContentAlignment.MiddleCenter;
            }
            else if (alinamiento == alinear.derecha)
            {
                newColumn.TextAlignment = ContentAlignment.MiddleRight;
            }
            else
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }

        public void CreateGridComboBoxColumn(RadGridView cv, IList datasource, string caption, string field, int visibleindex, 
                    string formatString, int withField = 0, bool readOnly = true, 
            bool allowEdit = false, bool visible = true,  alinear alinamiento = alinear.derecha)
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

            if (alinamiento == alinear.izquierda)
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else if (alinamiento == alinear.centro)
            {
                newColumn.TextAlignment = ContentAlignment.MiddleCenter;
            }
            else if (alinamiento == alinear.derecha)
            {
                newColumn.TextAlignment = ContentAlignment.MiddleRight;
            }
            else
            {
                newColumn.TextAlignment = ContentAlignment.MiddleLeft;
            }
        }


        
        public enum alinear
        {
            izquierda = 0,
            derecha = 1,
            centro = 2
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

        private void frmBaseMante_KeyUp(object sender, KeyEventArgs e)
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
            //try
            //{
            //    if (this.ActiveControl is RadGridView) return;
            //    if (e.KeyValue == (char)Keys.Enter)
            //    {

            //        if (cbbGuardar.IsMouseOver && cbbGuardar.IsFocused)
            //        {
            //            OnGuardar();
            //            return;
            //        }
            //    }

            //    if (e.KeyValue == (char)Keys.Enter)
            //    {
            //        FocusNextControl();
            //    }

            //    if (e.KeyValue == (char)Keys.Down)
            //    {
            //        FocusNextControl();
            //    }

            //    if (e.KeyValue == (char)Keys.Up)
            //    {
            //        FocusPreviousControl();
            //    }
            //}
            //catch (Exception ex)
            //{
            //}   
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
        Control[] listaCajas(Form formulario)
        {
            int nrocajas = 0;
            Control[] controles = new Control[cantidadCajas(this)];
            //string controles = "";

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
                else if(control is RadTextBox && control.Enabled == true){
                    controles[nrocajas] = control;
                    nrocajas++;
                }                
            }

            return controles;
        }
        int cantidadCajas(Form formulario)
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
                } else if(control is RadTextBox && control.Enabled == true){
                    nrocajas++;                        
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
        
       
        private void cbbImprimir_Click_1(object sender, EventArgs e)
        {
            OnImprimir();
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
    }
}
