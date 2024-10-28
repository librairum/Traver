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

namespace Fac.UI.Win
{
    public partial class frmBaseHelp : Telerik.WinControls.UI.RadForm
    {        
        public frmBaseHelp()
        {
            InitializeComponent();
            _extensions = new Extensions();
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

        protected virtual void OnAceptar()
        { }

        protected virtual void OnCancelar()
        { this.Close(); }

        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    OnGuardar();
        //}

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    OnCancelar();
        //}

        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true)
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
            newColumn.FormatString = formatString;
        }
        public void CreateGridChkColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, int withField = 0, bool readOnly = true,
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            OnAceptar();
        }

    }
}
