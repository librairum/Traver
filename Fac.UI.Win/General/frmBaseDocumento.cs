using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;


namespace Fac.UI.Win
{
    public partial class frmBaseDocumento : Telerik.WinControls.UI.RadForm
    {
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
        private BaseTipoDocumento _tipoDocumento;
        public BaseTipoDocumento EstadoDocumento
        {
            get { return _tipoDocumento; }
            set
            {
                _tipoDocumento = value;
            }
        }
        internal void OcultarBarraBotones()
        {
            toolBar.Visible = false;
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

        public frmBaseDocumento()
        {
            InitializeComponent();
            _extensions = new Extensions();
        }
        protected virtual void HabilitarBotones(bool bNuevo, bool bEliminar,
            bool bEditar, bool bAnular,
            bool bCopiar, bool bVer, bool bAgregarDetalle, bool bGenerarPDF, bool bImprimir,
            bool bVistaPreliminar, bool bGenerarFE = false, bool bVerFE = false,
            bool bDarBajaFE = false)
        {
            cbbNuevo.Visibility = bNuevo == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbEliminar.Visibility = bEliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbEditar.Visibility = bEditar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbAnulado.Visibility = bAnular == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbCopiar.Visibility = bCopiar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbVer.Visibility = bVer == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbAgregarDetalle.Visibility = bAgregarDetalle == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbGeneraPDF.Visibility = bGenerarPDF == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbImprimir.Visibility = bImprimir == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbVistaPreliminar.Visibility = bVistaPreliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbGenerarFE.Visibility = bGenerarFE == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbVerFE.Visibility = bVerFE == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbDarBajaFE.Visibility = bDarBajaFE == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        }
        internal void OcultarBotones()
        {
            cbbNuevo.Visibility = ElementVisibility.Collapsed;
            cbbEliminar.Visibility = ElementVisibility.Collapsed;
            cbbEditar.Visibility = ElementVisibility.Collapsed;
            cbbAnulado.Visibility = ElementVisibility.Collapsed;
            cbbCopiar.Visibility = ElementVisibility.Collapsed;
            cbbVer.Visibility = ElementVisibility.Collapsed;
            commandBarButton1.Visibility = ElementVisibility.Collapsed;

            cbbAgregarDetalle.Visibility = ElementVisibility.Collapsed;
            commandBarButton2.Visibility = ElementVisibility.Collapsed;

            cbbGeneraPDF.Visibility = ElementVisibility.Collapsed;
            cbbImprimir.Visibility = ElementVisibility.Collapsed;
            cbbVistaPreliminar.Visibility = ElementVisibility.Collapsed;
            commandBarButton3.Visibility = ElementVisibility.Collapsed;

            cbbGenerarFE.Visibility = ElementVisibility.Collapsed;
            cbbVerFE.Visibility = ElementVisibility.Collapsed;
            cbbDarBajaFE.Visibility = ElementVisibility.Collapsed;
            cbbCancelar.Visibility = ElementVisibility.Collapsed;
        }
        internal void HabilitaBotonPorNombre(BaseRegBotones nombreBoton)
        {

            switch (nombreBoton)
            {
                case BaseRegBotones.cbbNuevo:
                    cbbNuevo.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEliminar:
                    cbbEliminar.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEditar:
                    cbbEditar.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbAnulado:
                    cbbAnulado.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbCopiar:
                    cbbCopiar.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVer:
                    cbbVer.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbAgregarDetalle:
                    cbbAgregarDetalle.Visibility = ElementVisibility.Visible;
                    commandBarButton2.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGeneraPDF:
                    cbbGeneraPDF.Visibility = ElementVisibility.Visible;
                    commandBarButton3.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbImprimir:
                    cbbImprimir.Visibility = ElementVisibility.Visible;
                    commandBarButton3.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVistaPreliminar:
                    cbbVistaPreliminar.Visibility = ElementVisibility.Visible;
                    commandBarButton3.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGenerarFE:
                    cbbGenerarFE.Visibility = ElementVisibility.Visible; ;
                    commandBarButton3.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVerFE:
                    cbbVerFE.Visibility = ElementVisibility.Visible;
                    commandBarButton3.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbDarBajaFE:
                    cbbDarBajaFE.Visibility = ElementVisibility.Visible;
                    commandBarButton3.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbCancelar:
                    cbbCancelar.Visibility = ElementVisibility.Visible;
                    commandBarButton3.Visibility = ElementVisibility.Visible;
                    break;
            }

        }

        protected virtual void OnNuevo()
        {

        }
        protected virtual void OnEliminar()
        {

        }

        protected virtual void OnEditar()
        {

        }

        protected virtual void OnAnular()
        {

        }

        protected virtual void OnCopiar()
        {

        }
        protected virtual void OnVer() { }

        protected virtual void OnAgregarDetalle()
        {

        }

        protected virtual void OnGeneraPDF()
        {

        }

        protected virtual void OnImprimir()
        {

        }

        protected virtual void OnVistaPreliminar()
        {

        }

        protected virtual void OnGenerarFE()
        {

        }

        protected virtual void OnVerFE()
        {

        }

        protected virtual void OnDarBajaFE()
        {

        }
        protected virtual void OnGuardar()
        {

        }
        protected virtual void OnCancelar()
        {

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
        public RadGridView CreateGridVista(RadGridView cv)
        {

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
        public void CreateGridColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString, int withField = 0,
            bool readOnly = true, bool allowEdit = false, bool visible = true, bool isNumeric = false, string textaling = "")
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
        private void cbbNuevo_Click(object sender, EventArgs e)
        {
            OnNuevo();
        }

        private void cbbEliminar_Click(object sender, EventArgs e)
        {
            OnEliminar();
        }

        private void cbbEditar_Click(object sender, EventArgs e)
        {
            OnEditar();
        }

        private void cbbAnulado_Click(object sender, EventArgs e)
        {
            OnAnular();
        }

        private void cbbCopiar_Click(object sender, EventArgs e)
        {
            OnCopiar();
        }

        private void cbbAgregarDetalle_Click(object sender, EventArgs e)
        {
            OnAgregarDetalle();
        }

        private void cbbGeneraPDF_Click(object sender, EventArgs e)
        {
            OnGeneraPDF();
        }

        private void cbbImprimir_Click(object sender, EventArgs e)
        {
            OnImprimir();
        }

        private void cbbVistaPreliminar_Click(object sender, EventArgs e)
        {
            OnVistaPreliminar();
        }

        private void cbbGenerarFE_Click(object sender, EventArgs e)
        {
            OnGenerarFE();
        }

        private void cbbVerFE_Click(object sender, EventArgs e)
        {
            OnVerFE();
        }

        private void cbbDarBajaFE_Click(object sender, EventArgs e)
        {
            OnDarBajaFE();
        }

        private void cbbVer_Click(object sender, EventArgs e)
        {
            OnVer();
        }

        //private void cbbGuardar_Click(object sender, EventArgs e)
        //{
        //    OnGuardar();
        //}

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar();
        }
    }
}
