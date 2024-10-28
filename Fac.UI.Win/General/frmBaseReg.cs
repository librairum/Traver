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
using System.Drawing;
namespace Fac.UI.Win
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

            //(pageControl.ViewElement as RadPageViewStripElement).ShowItemCloseButton = false;
            //(pageControl.ViewElement as RadPageViewStripElement).StripButtons = StripViewButtons.Scroll;
            //this.miConstructor();

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
        public BaseTipoDocumento EstadoDocumento { get; set; }
        public OrigenInstancia TipoOrigen { get; set; }
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
        //protected virtual frmBaseReg() {
        //    InitializeComponent();
        //}
        protected virtual void OnNuevo()
        { }

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
        protected virtual void OnCambiarEstado()
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
        protected virtual void OnCopiar()
        {

        }
        protected virtual void OnRefrescar()
        {}
        protected virtual void OnGenerarPDF() { }
        protected virtual void OnGenerarFE() { }
        protected virtual void OnVerFE() { }
        protected virtual void OnDarBaja() { }
        protected virtual void OnGenerarFactura()
        {
        }
        protected virtual void OnModificarPeso(){ }
        protected virtual void OnVistaGE() { }
        protected virtual void OnGenerarBoleta()
        {

        }
        protected virtual void OnReporteCertificado() { }
        
        protected virtual void OnReporteFactura()
        { 
            
        }
        protected virtual void OnEnviarCorreo() { }

        private void cbbGuardar_Click(object sender, EventArgs e)
        {
            OnGuardar();
        }

        private void cbbCancelar_Click(object sender, EventArgs e)
        {
            OnCancelar();
        }

        internal void ActivaBotonesDeMenu()
        {
            //radCommandBar1.Rows[0].
            //commandBarStripElement1.
        }
        protected void HabilitaBotonPorNombre(BaseRegBotones nombreBoton)
        {

            VerBotones(nombreBoton);
        }
        internal void RenombrarInformacionlBoton(BaseRegBotones nombreBoton, string nuevoTooTipText)
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
                
                case BaseRegBotones.cbbGeneraPDF:
                    cbbGeneraPDF.ToolTipText = nuevoTooTipText;
                    break;

                case BaseRegBotones.cbbGenerarFE:
                    cbbGenerarFE.ToolTipText = nuevoTooTipText;
                    break;

                case BaseRegBotones.cbbVistaPrevia:
                    cbbVistaPrevia.ToolTipText = nuevoTooTipText;
                    break;

                case BaseRegBotones.cbbVerFE:
                    cbbVerFE.ToolTipText = nuevoTooTipText;
                    break;

                case BaseRegBotones.cbbImprimir:
                    cbbImprimir.ToolTipText = nuevoTooTipText;
                    break;
                
                case BaseRegBotones.cbbImportar:
                    cbbImportar.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbCancelar:
                    cbbCancelar.ToolTipText = nuevoTooTipText;
                    break;
                
                case BaseRegBotones.cbbCopiar:
                    cbbCopiar.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbEnviarCorreo:
                    cbbEnviarCorreo.ToolTipText = nuevoTooTipText;
                    break;
                
                case BaseRegBotones.cbbReporteCertificado:
                    cbbReporteCertificado.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbModificarPeso:
                    cbbModificarPeso.ToolTipText = nuevoTooTipText;
                    break;
                case BaseRegBotones.cbbRefrescar:
                    cbbRefrescar.ToolTipText = nuevoTooTipText;
                    break;

                    
            }
        }
        private void VerBotones(BaseRegBotones boton)
        {
            switch (boton)
            {
                case BaseRegBotones.cbbNuevo:
                    cbbNuevo.Visibility = ElementVisibility.Visible;
                    commandBarButton2.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEditar:
                    cbbEditar.Visibility = ElementVisibility.Visible;
                    commandBarButton2.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbEliminar:
                    cbbEliminar.Visibility = ElementVisibility.Visible;
                    commandBarButton2.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGuardar:
                    cbbGuardar.Visibility = ElementVisibility.Visible;
                    commandBarSeparator1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbCancelar:
                    cbbCancelar.Visibility = ElementVisibility.Visible;
                    commandBarSeparator1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVistaPrevia:
                    cbbVistaPrevia.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbImprimir:
                    cbbImprimir.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbExportar:
                    cbbExportar.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbImportar:
                    cbbImportar.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbNavegacion:
                    cmdPrimero.Visibility = ElementVisibility.Visible;
                    cmdSiguiente.Visibility = ElementVisibility.Visible;
                    cmdAnterior.Visibility = ElementVisibility.Visible;
                    cmdUltimo.Visibility = ElementVisibility.Visible;

                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cmdPrimero:
                    cmdPrimero.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cmdSiguiente:
                    cmdSiguiente.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cmdAnterior:
                    cmdAnterior.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cmdUltimo:
                    cmdUltimo.Visibility = ElementVisibility.Visible;
                    commandBarButton1.Visibility = ElementVisibility.Visible;
                    break;

                case BaseRegBotones.cbbCopiar:
                    cbbCopiar.Visibility = ElementVisibility.Visible;
                    commandBarButton8.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGeneraPDF:
                    cbbGeneraPDF.Visibility = ElementVisibility.Visible;
                    commandBarButton9.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGenerarFE:
                    cbbGenerarFE.Visibility = ElementVisibility.Visible;
                    commandBarButton4.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbVerFE:
                    cbbVerFE.Visibility = ElementVisibility.Visible;
                    commandBarButton4.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbDarBaja:
                    cbbDarBaja.Visibility = ElementVisibility.Visible;
                    commandBarButton4.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGenerarFactura:
                    cbbGenerarFactura.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbGenerarBoleta:
                    cbbGenerarBoleta.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbReporteCertificado:
                    cbbReporteCertificado.Visibility = ElementVisibility.Visible;
                    break;
               
                case BaseRegBotones.cbbEnviarCorreo:
                    cbbEnviarCorreo.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbReporteFactura:
                    cbbReporteFactura.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbModificarPeso:
                    cbbModificarPeso.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbRefrescar:
                    cbbRefrescar.Visibility = ElementVisibility.Visible;
                    break;
                case BaseRegBotones.cbbOnVistaGE:
                    cbbVistaGE.Visibility = ElementVisibility.Visible;
                    break;
                default:
                    break;
            }
        }
        internal void OcultarBotones()
        {

            cbbNuevo.Visibility = ElementVisibility.Collapsed;
            cbbEditar.Visibility = ElementVisibility.Collapsed;
            cbbEliminar.Visibility = ElementVisibility.Collapsed;
            commandBarButton2.Visibility = ElementVisibility.Collapsed;

            cbbGuardar.Visibility = ElementVisibility.Collapsed;
            cbbCancelar.Visibility = ElementVisibility.Collapsed;
            commandBarSeparator1.Visibility = ElementVisibility.Collapsed;

            cbbVistaPrevia.Visibility = ElementVisibility.Collapsed;
            cbbImprimir.Visibility = ElementVisibility.Collapsed;
            cbbExportar.Visibility = ElementVisibility.Collapsed;
            cbbImportar.Visibility = ElementVisibility.Collapsed;
            cmdPrimero.Visibility = ElementVisibility.Collapsed;
            cmdSiguiente.Visibility = ElementVisibility.Collapsed;
            cmdAnterior.Visibility = ElementVisibility.Collapsed;
            cmdUltimo.Visibility = ElementVisibility.Collapsed;
            commandBarButton1.Visibility = ElementVisibility.Collapsed;

            cbbCopiar.Visibility = ElementVisibility.Collapsed;
            commandBarButton8.Visibility = ElementVisibility.Collapsed;

            cbbGeneraPDF.Visibility = ElementVisibility.Collapsed;
            commandBarButton9.Visibility = ElementVisibility.Collapsed;

            cbbGenerarFE.Visibility = ElementVisibility.Collapsed;
            cbbVerFE.Visibility = ElementVisibility.Collapsed;
            cbbDarBaja.Visibility = ElementVisibility.Collapsed;
            commandBarButton4.Visibility = ElementVisibility.Collapsed;

            cbbGenerarFactura.Visibility = ElementVisibility.Collapsed;
            cbbGenerarBoleta.Visibility = ElementVisibility.Collapsed;
            
            cbbReporteCertificado.Visibility = ElementVisibility.Collapsed;
            cbbEnviarCorreo.Visibility = ElementVisibility.Collapsed;
            cbbReporteFactura.Visibility = ElementVisibility.Collapsed;
            
            //MODIFICAR PESO - cbb
            
            cbbModificarPeso.Visibility = ElementVisibility.Collapsed;
            cbbVistaGE.Visibility = ElementVisibility.Collapsed;
            cbbRefrescar.Visibility = ElementVisibility.Collapsed;

        }
        protected virtual void HabilitarBotones(bool guardar, bool cancelar,
        bool vistaprevia, bool imprimir, bool importar, bool exportar, bool navegacion,
        bool copiarDocumento = false, bool GenerarPDF = false, bool GenerarFE = false, bool VerFE = false,
            bool darBaja = false, bool nuevo = false, bool editar = false, bool eliminar = false,
            bool GenerarBoleta = false, bool GenerarFactura = false, bool ModificarPeso = false, bool Refrescar = false)
        {
            cbbNuevo.Visibility = nuevo == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbEditar.Visibility = editar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbEliminar.Visibility = eliminar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            if (nuevo == editar == eliminar == false)
            {
                commandBarButton2.Visibility = ElementVisibility.Collapsed;
            }

            cbbGuardar.Visibility = guardar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbCancelar.Visibility = cancelar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbVistaPrevia.Visibility = vistaprevia == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbImprimir.Visibility = imprimir == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbExportar.Visibility = exportar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            cbbImportar.Visibility = importar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;



            this.cmdPrimero.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cmdSiguiente.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cmdAnterior.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cmdUltimo.Visibility = navegacion == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            this.cbbCopiar.Visibility = copiarDocumento == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbGeneraPDF.Visibility = GenerarPDF == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbGenerarFE.Visibility = GenerarFE == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbVerFE.Visibility = VerFE == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbDarBaja.Visibility = darBaja == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbGenerarFactura.Visibility = GenerarFactura == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbGenerarBoleta.Visibility = GenerarBoleta == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            this.cbbRefrescar.Visibility = Refrescar == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
           this.cbbModificarPeso.Visibility = ModificarPeso == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            commandBarStripElement1.FitToSizeMode = RadFitToSizeMode.FitToParentContent;
        }
        protected virtual void HabilitarBtnBind(ElementVisibility primero, ElementVisibility anterior,
            ElementVisibility siguiente, ElementVisibility ultimo)
        {
            this.cmdPrimero.Visibility = primero;
            this.cmdSiguiente.Visibility = siguiente;
            this.cmdAnterior.Visibility = anterior;
            this.cmdUltimo.Visibility = ultimo;
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
            }

            if (!(e.CellElement is GridHeaderCellElement))
            {
                e.CellElement.Font = nuevaFuente;

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
            cv.AllowRowResize = false;
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

            
            newColumn.FormatString = formatString;

            if (isNumeric)
            {
                ((GridViewMaskBoxColumn)newColumn).Mask = "f";
                //((GridViewMaskBoxColumn)newColumn).Mask = "f4";
            }

            //newColumn.DisplayFormat.FormatType = formatType;
            //if (formatType == DevExpress.Utils.FormatType.Custom)
            //    gc.DisplayFormat.Format = new BaseFormatter();
            //gc.DisplayFormat.FormatString = formatString;

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
        
        public void CreateGridIntColumn(RadGridView cv, string caption, string field, int visibleindex, string formatString,
             int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true, string textaling = "")
        {
            Telerik.WinControls.UI.GridViewMaskBoxColumn newColumn;
            newColumn = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            //newColumn.MaskType = Telerik.WinControls.UI.MaskType.;
            newColumn.Mask = "D";
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
        public void CreateGridComboBoxColumn(RadGridView cv, IList datasource, string caption, string field, int visibleindex,
         string formatString, int withField = 0, bool readOnly = true, bool allowEdit = false, bool visible = true)
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

        
        internal void AgregarReporteCertificado()
        {
            try
            {
                CommandBarButton cbbReporteCertificado = new CommandBarButton();
                cbbReporteCertificado.AccessibleName = "ReporteCertificado";
                cbbReporteCertificado.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                cbbReporteCertificado.DisplayName = "ReporteCertificado";
                //convertir base 64 a imagen

                string base64img = "iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAABmJLR0QA/wD/AP+gvaeTAAABXUlEQVQ4Ec1UsUoDQRB9exeFoCJibFLYWaYWJD+hWFvYiyBR24CNopWNhaIfYGFlKwgWNrGytrEQxFptsuNb7zbc3TrZFCkMb/Lmzcw+9nYvAcb8MUU/OcEaBEvFWjRP8Wh2cO/naj7JuQuDVp6PRhbXHBwYJhRjxf83rJ6hf/xvnuWGFwEL5lk7YwTQDCd524fBtC8Y1Nj3qsSaoeVUj/E3BHU2FhkBdEODl2DaFwQzPq2yZugeeb86PIrWDLO1gldezgSFm2uQo9DfQ8E7V28zWryAc7LTpOHQDC13dml2cWM6+ECKA+rP4VZZVzNMaDCbjQD88X9xl+5mfUlldzZac53/Pk80fubAFg2nyVHohvZ37Qq/2zRr0HiKeRTVR5bBCgNLoyvqByTokTVIsVHeYYpV9DGXD3RpdMH8lsabjD3u8o66jD7eygVF8fzacooF15ZjLMsRmi6PxQ8QSEGdJgMeaQAAAABJRU5ErkJggg==";
                byte[] imageBytes = Convert.FromBase64String(base64img);
                using (Image image = Image.FromStream(new System.IO.MemoryStream(imageBytes)))
                {
                    cbbReporteCertificado.Image = image;
                }


                //cbbReporteCertificado.Image = ((System.Drawing.Image)(resources.GetObject("cbbCancelar.Image")));
                cbbReporteCertificado.Name = "cbbReporteCertificado";
                cbbReporteCertificado.Text = "ReporteCertificado";
                commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] { cbbReporteCertificado });
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al agregar reporte : " + ex.Message);
            }
        }
        internal void CrearBotonMenuCabecera(string nombreBoton, string rutaImagen)
        { 
                
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
        private void cbbCopiar_Click(object sender, EventArgs e)
        {
            OnCopiar();
        }

        private void frmBaseReg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Estado == FormEstate.New || Estado == FormEstate.Edit)
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

        private void cbbGeneraPDF_Click(object sender, EventArgs e)
        {
            OnGenerarPDF();
        }

        private void cbbGenerarFE_Click(object sender, EventArgs e)
        {
            OnGenerarFE();
        }

        private void cbbVerFE_Click(object sender, EventArgs e)
        {
            OnVerFE();
        }

        private void cbbDarBaja_Click(object sender, EventArgs e)
        {
            OnDarBaja();
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

        private void cbbGenerarFactura_Click(object sender, EventArgs e)
        {
            OnGenerarFactura();
        }

        private void cbbGenerarBoleta_Click(object sender, EventArgs e)
        {
            OnGenerarBoleta();
        }
        
        private void cbbReporteCertificado_Click(object sender, EventArgs e)
        {
            OnReporteCertificado();
        }

        

        private void cbbEnviarCorreo_Click(object sender, EventArgs e)
        {
            OnEnviarCorreo();
        }

        private void cbbReporteFactura_Click(object sender, EventArgs e)
        {
            OnReporteFactura();
        }

        private void frmBaseReg_Click(object sender, EventArgs e)
        {

        }

        private void cbbModificarPeso_Click(object sender, EventArgs e)
        {
            OnModificarPeso();
        }

        private void cbbVistaGE_Click(object sender, EventArgs e)
        {
            OnVistaGE();
        }

        private void cbbRefrescar_Click(object sender, EventArgs e)
        {
            OnRefrescar();
        }


    }
}
