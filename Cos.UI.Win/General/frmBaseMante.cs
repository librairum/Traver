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
namespace Cos.UI.Win
{
    public partial class frmBaseMante : Telerik.WinControls.UI.RadForm
    {
        public frmBaseMante()
        {
            InitializeComponent();
           
            barraComando.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            barraComando.BorderWidth = 0;            
            radCommandBar1.AllowShowFocusCues = true;
            
            cbbNuevo.Focus();    
          
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

        //protected virtual void OnImprimir()
        //{
        //}
        
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
        //Estilo de la celdas bordes azules marinos y celeste claro en el fondde al celda .
        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {            
            
        }
        //dibujar en celda de grilla
        
        

        //Estilo de la cabecera de la grilla 
        private void radGridView1_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            
            Font nuevaFuente = new Font("Arial", 8f);
            //celeste claro
           //Estilo a la zonaq de la cabecera de la grilla
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
                
                //e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.DrawFillProperty, ValueResetFlags.Local);
                //e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.GradientStyleProperty, ValueResetFlags.Local);
                //e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.BackColorProperty, ValueResetFlags.Local);

                e.CellElement.ResetValue(Telerik.WinControls.UI.RadGridViewElement.ForeColorProperty, ValueResetFlags.Local);              
            }

           
            //Estilo a las celdas de la grilla 
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
            
            
            //cv.CellFormatting += new CellFormattingEventHandler(radGridView1_CellFormatting);
            return cv;
        }

        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, int withField = 0, 
                                     bool readOnly = true, bool allowEdit = false, bool visible = true, bool isNumeric = false)
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
                newColumn.FormatString = formatString;            
        }

        public void CreateGridComboBoxColumn(RadGridView cv, IList datasource, string caption, string field, int visibleindex, string formatString, 
                                             int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true)
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

        public void CreateGridCheckBoxColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, 
                                            int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true)
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

        //private void cbbImprimir_Click(object sender, EventArgs e)
        //{
        //    OnImprimir();
        //}

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
        }

        protected void ShowAlertOk(string titulo, string messaje)
        {
            //this.alertControl.AppearanceText.ForeColor = System.Drawing.Color.Green;
            //this.alertControl.Show(this, titulo, messaje);
            RadMessageBox.Show(messaje, titulo, MessageBoxButtons.OK, RadMessageIcon.Info);
        }

        protected void ShowAlertError(string titulo, string messaje)
        {
            //this.alertControl.AppearanceText.ForeColor = System.Drawing.Color.Red;
            //this.alertControl.Show(this, titulo, messaje);           
            RadMessageBox.Show(messaje, titulo, MessageBoxButtons.OK, RadMessageIcon.Error);
        }
        protected void ShowAlertQuestion(string titulo, string messaje, out DialogResult respuesta)
        {
            respuesta = RadMessageBox.Show(messaje, titulo, MessageBoxButtons.YesNo, RadMessageIcon.Question);
        }
        protected void ShowAlertExclamation(string titulo, string messaje)
        {
            RadMessageBox.Show(messaje, titulo, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
        }



    }
}
