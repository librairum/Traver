using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using System.Linq;
using Telerik.WinControls.UI.Docking;
//using Cos.UI.Win.Maestros;
//using Cos.UI.Win.Procesos;
namespace Cos.UI.Win
{
    public partial class frmMDI : Telerik.WinControls.UI.RadRibbonForm
    {
        private bool isLoaded = false;
        DocumentTabStrip docTabStrip;
        public frmMDI()
        {
            InitializeComponent();
            ContextMenuService menuService = this.radDock1.GetService<ContextMenuService>();
            menuService.ContextMenuDisplaying += menuService_ContextMenuDisplaying;
            string nombre = "";
            GlobalLogic.Instance.TraerNombreModulo(Logueo.codModulo, out nombre);
            this.Text = nombre;
            this.radRibbonBar1.Text = "..:::SISTEMA DE " + nombre + "::..";
            // DocumentWindow docu = new DocumentWindow("Titulo");
            capturarAniomes();
            capturarLinea();
            capturarLoteCosto();

        }
        private void menuService_ContextMenuDisplaying(object sender, ContextMenuDisplayingEventArgs e)
        {
            //the menu request is associated with a valid DockWindow instance, which resides within a DocumentTabStrip
            if (e.MenuType == ContextMenuType.DockWindow &&
                e.DockWindow.DockTabStrip is DocumentTabStrip)
            {
                //remove the "Close" menu item
                                
                for (int i = 0; i < e.MenuItems.Count; i++)
                {
                    RadMenuItemBase menuItem = e.MenuItems[i];
                    
                    if (menuItem.Text == "Close")
                    {
                        menuItem.Text = "Cerrar";
                    }
                }
            }
        }
        void creartabStrip(){
            try
            {
                //captura el tabstrip por defecto
                docTabStrip = this.radDock1.GetDefaultDocumentTabStrip(true);
                docTabStrip.TabStop = false;
                docTabStrip.ThemeName = "Windows8";
                //asigna color azul de fondo al control de la zona de tabs 
                
                ((Telerik.WinControls.UI.StripViewItemContainer)(this.docTabStrip.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), 
                    ((int)(((byte)(92)))),
                    ((int)(((byte)(153)))));
                ((Telerik.WinControls.UI.StripViewItemLayout)(this.docTabStrip.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.White;        
                                        
            }
            catch (Exception ex) { 
            
            }
            
        }
        private void menuService_ContextMenuItemClicked(object sender, ContextMenuItemClickEventArgs e)
        {
            if (e.Item.Text == "Cerrar") {
                e.DockWindow.Hide();
                e.Handled = true;
            }
        }
      
        #region "metodo Formulario Principal"
        public frmMDI(string perfilPermiso)
        {
            InitializeComponent();
            if (radRibbonBar1.CommandTabs.Count > 0)
            {
                radRibbonBar1.CommandTabs.Clear();     
            }
           
            cargarPermisos(perfilPermiso);
            //agregaBotonsalida();
            ContextMenuService menuService = this.radDock1.GetService<ContextMenuService>();
            menuService.ContextMenuDisplaying += menuService_ContextMenuDisplaying;
            menuService.ContextMenuItemClicked += menuService_ContextMenuItemClicked;
            Logueo.codigoPerfil = perfilPermiso.ToString();
            lblUsuario.Text = Logueo.UserName;
            lblPerfil.Text = Logueo.nomPerfil;
            
        }
        
        void cargarPermisos(string xcodigo)
        {
            try
            {
                
                var lista = SegMenuPorPerfilLogic.Instance.Trae_Menu_Por_Perfil(xcodigo,Logueo.codModulo);
                RibbonTab tab = null;
                RadRibbonBarGroup rbg = null;
                RadButtonElement btn = null;

                foreach (var itm in lista)
                {
                    string nivel1 = itm.CodigoFormulario.Substring(0, 2);
                    string nivel2 = itm.CodigoFormulario.Substring(2, 2);
                    string nivel3 = itm.CodigoFormulario.Substring(4, 2);

                    if (!nivel1.Equals("00") && nivel2.Equals("00") && nivel3.Equals("00")) // cabecera
                    {
                        tab = new RibbonTab();
                        tab.Text = itm.Etiqueta;
                        tab.Name = itm.CodigoFormulario;
                        tab.StretchVertically = true;
                        
                        radRibbonBar1.CommandTabs.Add(tab);
                    }
                    else if (!nivel2.Equals("00") && nivel3.Equals("00"))
                    {
                        if (tab.Items.Count == 0)
                        {
                            rbg = new RadRibbonBarGroup();                            
                            rbg.Text = "Opciones";
                            rbg.Name = "Opciones";
                            tab.Items.Add(rbg);
                        }

                        btn = new RadButtonElement();                       
                        btn.Text = itm.Etiqueta;
                        btn.AutoSize = false;
                        btn.Size = new Size(70, 50);
                        btn.TextWrap = true;
                        
                        btn.Name = itm.nombreFormulario;
                        
                        btn.Tag = itm;
                        
                        
                        //if (itm.nombreIcono != null)
                        //{

                        //    btn.Image = Image.FromFile(Logueo.GetRutaIcono()+@"\32x32\" + itm.nombreIcono);
                        //}
                        //else {
                        //    btn.Image = Image.FromFile(Logueo.GetRutaIcono() + "cartera.png");
                        //}


                        if (itm.nombreIcono != null)
                        {
                            //if (System.IO.File.Exists(Logueo.GetRutaIcono() + @"\32x32\" + itm.nombreIcono))
                            //{
                            //    btn.Image = Image.FromFile(Logueo.GetRutaIcono() + @"\32x32\" + itm.nombreIcono);    
                            //}                            
                            if (System.IO.File.Exists(Logueo.GetRutaIcono() + itm.nombreIcono))
                            {
                                btn.Image = Image.FromFile(Logueo.GetRutaIcono() + itm.nombreIcono);
                            }
                        }

                        btn.ImageAlignment = ContentAlignment.TopCenter;
                        //btn.TextAlignment = ContentAlignment.MiddleCenter;
                        
                        btn.TextImageRelation = TextImageRelation.ImageAboveText;                                                                                           
                        btn.Click += new EventHandler(xradButtonElement_Click);
                        rbg.Items.Add(btn);
                    }
                    else if (!nivel3.Equals("00"))
                    {

                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        //boton para abrir formularios y mostrar en los raddock(paneles)
        private void xradButtonElement_Click(object sender, EventArgs e)
        {
            string nombreform;
            creartabStrip();
            //Form frm = Application.OpenForms[nombreform];
            if (((RadButtonElement)(sender)).Name != null)
            {
                nombreform = ((RadButtonElement)(sender)).Name;
                Form frm = Application.OpenForms[nombreform] as Form;
                if (frm != null)
                {
                    this.radDock1.ActivateMdiChild(frm);
                }
                else
                {
                    Form formulario = AbrirFormulario(nombreform);
                    switch (nombreform.ToUpper())
                    {
                        
                        case "FRMUNIMEDTIPO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMACTIVIDADESCONTABLE":
                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMACTIVIDADESPROD":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCONCICONTABLEPROD":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMLINEAS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMLOTECOSTO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMDISTRIACTIVIDADESAPOYO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMIMPGASTOSCONTABLES":
                       
                            mostrarFormulario(formulario);
                            break;
                        case "FRMIMPPRODMOVI":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCALCULARCOSTO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMIMPCOSTOSPRODUCCION":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMDISTRIPRODUCCIONXLINEAS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMVOUCHERCOSTO":
                            mostrarFormulario(formulario);
                            break;    

                        case "FRMIMPORTACIONSALDOS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMPASARCOSTOPRODUCCION":
                            mostrarFormulario(formulario);
                            break;
                        default:                            
                            this.Close();
                            break;
                    }

                }
            }

        }

        void mostrarFormulario(Form frm)
        {
            if (frm == null) return;
            try
            {
                //mostrar la opcion de cerra en el tab del dcoumento 
                this.radDock1.ShowToolCloseButton = true;
                this.radDock1.ShowDocumentCloseButton = true;
                frm.MdiParent = this;
                frm.Show();
                radDock1.ActivateMdiChild(frm);                                                
            }
            catch (Exception ex)
            {
            }
        }
        private Form AbrirFormulario(string nombre)
        {
            switch (nombre.ToUpper())
            {
                case "FRMACTIVIDADESCONTABLE":
                    return frmActividadesContable.Instance(this);
                case "FRMACTIVIDADESPROD":
                    return frmActividadesProd.Instance(this);
                case "FRMCONCICONTABLEPROD":
                    return frmConciContableProd.Instance(this);    
                case "FRMLINEAS":
                    return frmLineas.Instance(this);
                case "FRMLOTECOSTO":
                    return frmLoteCosto.Instance(this);
                case "FRMDISTRIACTIVIDADESAPOYO":
                    return frmDistriActividadesApoyo.Instance(this);
                case "FRMIMPGASTOSCONTABLES":
                    return frmImpGastosContables.Instance(this);
                case "FRMIMPPRODMOVI":
                    return frmImpProdMovi.Instance(this);
                case "FRMCALCULARCOSTO":
                    return frmCalcularCosto.Instance(this);
                case "FRMIMPCOSTOSPRODUCCION":
                    return frmImpCostosProduccion.Instance(this);
                case "FRMDISTRIPRODUCCIONXLINEAS":
                    return frmDistriProduccionxLineas.Instance(this);
                case "FRMVOUCHERCOSTO":
                    return frmVoucherCosto.Instance(this);
                case "FRMIMPORTACIONSALDOS":
                    return frmImportacionSaldos.Instance(this);
                case "FRMPASARCOSTOPRODUCCION":
                    return frmPasarCostoProduccion.Instance(this);
                    
            }
            return null;
        }

        #endregion
                                       
        private void frmMDI_Load(object sender, EventArgs e)
        {
            try
            {
                this.radDock1.AutoDetectMdiChildren = true;
                this.IsMdiContainer = true;
                radDock1.MdiChildrenDockType = Telerik.WinControls.UI.Docking.DockType.Document;
                CargarPeriodos();
                isLoaded = true;
                CargarLineas();
                
                
                // Establecer añio y mes
                capturarAniomes();                
                capturarLinea();

                //Datos de Lotes de costo
                CargarLoteCosto();
                capturarLoteCosto();

                //Datos de suario
                lblPerfil.Text = Logueo.nomPerfil;
                lblUsuario.Text = Logueo.UserName;
                lblNomEmpresa.Text = Logueo.NombreEmpresa;
                
                //Propiedades de estilo para el raddock
                this.radDock1.ShowToolCloseButton = false;
                this.radDock1.ShowDocumentCloseButton = false;
                this.radDock1.RootElement.StretchVertically = true;
                this.radDock1.RootElement.StretchHorizontally = true;
                this.radStatusStrip1.BackColor = Color.FromArgb(0, 92, 153);
                
                
            }
            catch (Exception ex) { 
            
            }
            
            //creartabStrip();
          
            //this.documentWindow1.DocumentButtons &= ~Telerik.WinControls.UI.Docking.DocumentStripButtos.Close;
            // Cargar imagen de fondo del mdi
           // imagenfondomdidock();
        }

        class BusinessObject
        {

            public int ID { get; set; }

            public string Name { get; set; }

        }
        public void CargarLoteCosto() {
            try
            {
                cboLoteCosto.Items.Clear();

                var LotesCosto = LoteCostoLogic.Instance.TraerLoteCostoxEmpresa(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, 
                                                                                 Logueo.CodigoLinea);
                cboLoteCosto.DataSource = LotesCosto;
                cboLoteCosto.DisplayMember = "Descripcion";
                cboLoteCosto.ValueMember = "Codigo";
            }
            catch (Exception ex) { }
        }
        private void CargarPeriodos()
        {
            try
            {
                var periodo = PeriodoLogic.Instance.PeriodoTraerTodos(Logueo.CodigoEmpresa);
                cboperiodos.DataSource = periodo;
                cboperiodos.DisplayMember = "ccb03des";
                cboperiodos.ValueMember = "ccb03cod";
                
               
                string anio="";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();

                cboperiodos.SelectedValue = anio + mes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CargarLineas()
        {
            try
            {
                //var periodo = PeriodoLogic.Instance.PeriodoTraerTodos(Logueo.CodigoEmpresa);
                var linea = LineaLogic.Instance.LineaTraer(Logueo.CodigoEmpresa);
                cboLinea.DataSource = linea;
                cboLinea.DisplayMember = "descripcion";
                cboLinea.ValueMember = "codigo";


                string anio = "";
                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");
                anio = DateTime.Now.Year.ToString();

                cboperiodos.SelectedValue = anio + mes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private void cboperiodos_SelectedValueChanged(object sender, EventArgs e)
        {
            capturarAniomes();
            this.cboLoteCosto.Items.Clear();
            CargarLoteCosto();
        }
        private void capturarAniomes()
        { 
            //Si no ha cargado por completo la pantalla no realiza ninguna accion
            if (!isLoaded) return;
            Logueo.Anio = this.cboperiodos.SelectedValue.ToString().Substring(0,4);
            Logueo.Mes = this.cboperiodos.SelectedValue.ToString().Substring(4, 2);
        }
        public void capturarLoteCosto() {
            if (!isLoaded) return;

            Logueo.CodigoLoteCosto = Util.convertiracadena(this.cboLoteCosto.SelectedValue);
        }
        private void capturarLinea()
        {
            if (!isLoaded) return;
            Logueo.CodigoLinea = this.cboLinea.SelectedValue.ToString();
        }
        private void imagenfondomdidock()
        {
            var imagePrimitive = new ImagePrimitive();
            imagePrimitive.StretchHorizontally = true;
            imagePrimitive.StretchVertically = true;
            imagePrimitive.Image = new Bitmap(@"D:\MineraDeisi\PROTER\Desarrollo\Modulo Almacen\Imagenes\catalagoBaldosas.png");
            radDock1.MainDocumentContainer.SplitPanelElement.Children.Add(imagePrimitive);            
        }
        
        private void radDock1_DockWindowClosed(object sender, Telerik.WinControls.UI.Docking.DockWindowEventArgs e)
        {
            try
            {
                if (e.DockWindow.Name == "frmMovi1")
                {
                    string nombreform = "frmDocu";
                    Form frm = Application.OpenForms[nombreform] as Form;
                    if (frm != null)
                    {
                        this.radDock1.ActivateMdiChild(frm);
                        var dock = radDock1.DockWindows["frmDocu1"].TabStripItem;
                        dock.ShowCloseButton = true;
                        dock.BackColor2 = Color.FromArgb(255, 246, 218);
                        dock.GradientStyle = GradientStyles.Linear;
                        dock.BackColor = Color.FromArgb(255, 232, 166);
                        dock.ForeColor = Color.Black;                        
                    }
                }
                if (e.DockWindow.Name == "FrmArticuloDet1")
                {
                    string nombreform = "FrmArticuloLista";
                    Form frm = Application.OpenForms[nombreform] as Form;

                    if (frm != null)
                    {
                        this.radDock1.ActivateMdiChild(frm);

                        var dock = radDock1.DockWindows["FrmArticuloLista1"].TabStripItem;
                        dock.ShowCloseButton = true;
                        dock.BackColor2 = Color.FromArgb(255, 246, 218);
                        dock.GradientStyle = GradientStyles.Linear;
                        dock.BackColor = Color.FromArgb(255, 232, 166);
                        dock.ForeColor = Color.Black;
                    }
                }
                if (e.DockWindow.Name == "frmMateriaPrimaDet1")
                {
                    string nombreform = "frmMateriaPrimaLista";
                    Form frm = Application.OpenForms[nombreform] as Form;
                    if (frm != null) 
                    {
                        this.radDock1.ActivateMdiChild(frm);
                        var dock = radDock1.DockWindows["frmMateriaPrimaLista1"].TabStripItem;
                        dock.ShowCloseButton = true;
                        dock.BackColor2 = Color.FromArgb(255, 246, 218);
                        dock.GradientStyle = GradientStyles.Linear;
                        dock.BackColor = Color.FromArgb(255, 232, 166);
                        dock.ForeColor = Color.Black;
                        
                    }
                }
                if (e.DockWindow.Name == "frmMoviMP1") 
                {
                    string nombreform = "frmDocuMP";
                    Form frm = Application.OpenForms[nombreform] as Form;
                    if (frm != null) 
                    {
                        this.radDock1.ActivateMdiChild(frm);
                        var dock = radDock1.DockWindows["frmDocuMP1"].TabStripItem;
                        dock.ShowCloseButton = true;
                        dock.BackColor2 = Color.FromArgb(255, 246, 218);
                        dock.GradientStyle = GradientStyles.Linear;
                        dock.BackColor = Color.FromArgb(255, 232, 166);
                        dock.ForeColor = Color.Black;
                    }
                }
                
            }
            catch (Exception ex) { 
            
            }
            
        }

        private void frmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }                    
        private void radDock1_DockWindowAdded(object sender, DockWindowEventArgs e)
        {
            
            //tab seleccionado (foco) 
            //e.DockWindow.TabStripItem.GradientStyle = GradientStyles.Linear;
            
            e.DockWindow.TabStripItem.BackColor2 = Color.FromArgb(255, 246, 218);
            e.DockWindow.TabStripItem.GradientStyle = GradientStyles.Linear;
            e.DockWindow.TabStripItem.BackColor = Color.FromArgb(255, 232, 166);
            e.DockWindow.TabStripItem.ForeColor = Color.Black;
            Form frmMovi = Application.OpenForms["frmMovi"] as Form;
            if (frmMovi != null)
            {
                var dock = radDock1.DockWindows["frmDocu1"].TabStripItem;
                dock.ShowCloseButton = false;
                dock.BackColor = Color.FromArgb(0, 92, 153);
                dock.GradientStyle = GradientStyles.Solid;
                dock.ForeColor = Color.White;

            }
            Form frmArti = Application.OpenForms["FrmArticuloDet"] as Form;
            if (frmArti != null)
            {
                var dock = radDock1.DockWindows["FrmArticuloLista1"].TabStripItem;
                dock.ShowCloseButton = false;
                dock.BackColor = Color.FromArgb(0, 92, 153);
                dock.GradientStyle = GradientStyles.Solid;
                dock.ForeColor = Color.White;
                //radDock1.DockWindows["FrmArticuloLista1"].TabStripItem.ShowCloseButton = false;
            }
            Form frmMPDet = Application.OpenForms["frmMateriaPrimaDet"] as Form;
            if (frmMPDet != null) 
            {
                var dock = radDock1.DockWindows["frmMateriaPrimaLista1"].TabStripItem;
                dock.ShowCloseButton = false;
                dock.BackColor = Color.FromArgb(0, 92, 153);
                dock.GradientStyle = GradientStyles.Solid;
                dock.ForeColor = Color.White;
                
                //radDock1.DockWindows["frmMateriaPrimaLista1"].TabStripItem.ShowCloseButton = false;
            }
            Form frmDocuMP = Application.OpenForms["frmMoviMP"] as Form;
            if (frmDocuMP != null) 
            {
                var dock = radDock1.DockWindows["frmDocuMP1"].TabStripItem;
                dock.ShowCloseButton = false;
                dock.BackColor = Color.FromArgb(0, 92, 153);
                dock.GradientStyle = GradientStyles.Solid;
                dock.ForeColor = Color.White;
            }
            //formateardock();
        }

        private void radDock1_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            //tab deseleccionado

            e.OldTabStripItem.BackColor = Color.FromArgb(0, 92, 153);
            e.OldTabStripItem.GradientStyle = GradientStyles.Solid;
            e.OldTabStripItem.ForeColor = Color.White;
            ////tab seleccionado
            e.NewTabStripItem.BackColor2 = Color.FromArgb(255, 246, 218);
            e.NewTabStripItem.GradientStyle = GradientStyles.Linear;
            e.NewTabStripItem.BackColor = Color.FromArgb(255, 232, 166);
            e.NewTabStripItem.ForeColor = Color.Black;     
        }

        private void radDock1_SelectedTabChanging(object sender, SelectedTabChangingEventArgs e)
        {
            try
            {
                string nombre = radDock1[e.NewWindow.Name].Name;
                if (nombre == "frmDocu1")
                {
                    if (radDock1["frmMovi1"].Name != null)
                    {
                        MessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.");
                        if (e.NewWindow.Name == "frmDocu1")
                        {
                            e.Cancel = true;
                        }
                    }
                }
                if (nombre == "FrmArticuloLista1")
                {
                    if (radDock1["FrmArticuloDet1"].Name != null)
                    {
                        MessageBox.Show("Para ingresar a la cabecera debe terminar el detalle .");
                        if (e.NewWindow.Name == "FrmArticuloLista1")
                        {
                            e.Cancel = true;
                        }
                    }
                }
                if (nombre == "frmMateriaPrimaLista1") 
                {
                    if (radDock1["frmMateriaPrimaDet1"].Name != null) 
                    {
                        MessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.");
                        if (e.NewWindow.Name == "frmMateriaPrimaLista1")
                        {
                            e.Cancel = true;
                        }
                    }
                }
                if (nombre == "frmDocuMP1") 
                {
                    if (radDock1["frmMoviMP1"].Name != null)
                    {
                        MessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.");
                        if (e.NewWindow.Name == "frmDocuMP1") 
                        {
                            e.Cancel = true;
                        }
                    }
                }

            }
            catch (Exception ex) { 
            
            }
        }

        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void frmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


                DialogResult result = RadMessageBox.Show("¿Desea salir de la aplicacion?", "Sistema", MessageBoxButtons.YesNo, 
                                       RadMessageIcon.Question, MessageBoxDefaultButton.Button2);
                //if(result
                e.Cancel = result == System.Windows.Forms.DialogResult.Yes ? false : true;
            }
            catch (Exception ex) { 
            
            }
           
            //if (result == System.Windows.Forms.DialogResult.Yes)
            //{
            //    e.Cancel = false;
              
            //}
            //else {
            //    e.Cancel = true;
                
            //}
        }
        void formateardock() {
            foreach (DockWindow dock in radDock1.DockWindows) 
            {                
                dock.TabStripItem.BackColor = Color.FromArgb(0, 92, 153);
                dock.TabStripItem.GradientStyle = GradientStyles.Solid;                
                dock.TabStripItem.ForeColor = Color.White;
                if (dock.TabStripItem.Name == "frmMovi1" || dock.TabStripItem.Name == "FrmArticuloDet1"
                    || dock.TabStripItem.Name == "frmMateriaPrimaDet1" || dock.TabStripItem.Name == "frmMoviMP1")
                {
                    dock.TabStripItem.ShowCloseButton = false;
                }
                
                 
              }

            }
        
        private void radDock1_ActiveWindowChanged(object sender, DockWindowEventArgs e)
        {
            if (e.DockWindow == null) return;

            docTabStrip.ThemeName = "Windows8";
            //asigna color azul de fondo al control de la zona de tabs 

            ((Telerik.WinControls.UI.StripViewItemContainer)(this.docTabStrip.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))),
                ((int)(((byte)(92)))),
                ((int)(((byte)(153)))));
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.docTabStrip.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.White;

            formateardock();

            //estilo tab seleccionado
            var dock = e.DockWindow.TabStripItem;            
            dock.BackColor2 = Color.FromArgb(255, 246, 218);
            dock.GradientStyle = GradientStyles.Linear;
            dock.BackColor = Color.FromArgb(255, 232, 166);
            dock.ForeColor = Color.Black;
            
        }

        private void cboperiodos_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            try
            {

                string[] procesos = { "frmDocu1", "frmMovi1", "frmDocuMP1", "frmMoviMP1", "FrmInvFisico1", "frmUbicacionFisica1" };

                foreach (DockWindow dock in radDock1.DockWindows)
                {
                    for (int x = 0; x < procesos.Length; x++)
                    {
                        if (procesos[x] == dock.Name)
                        {
                            MessageBox.Show("Debe cerrar todos los formularios de Procesos para cambiar de periodo", "Sistema",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }
                }

            }
            catch (Exception)
            {

            }

        }

        private void radRibbonBar1_ExpandedStateChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("radRibbonBar1_ExpandedStateChanged");
            
        }

        private void radRibbonBar1_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("radRibbonBar1_SizeChanged");
        }

        private void radRibbonBar1_RootElement_ChildrenChanged(object sender, ChildrenChangedEventArgs e)
        {
            
        }
        
        private void cboLinea_SelectedValueChanged(object sender, EventArgs e)
        {
            capturarLinea();
            this.cboLoteCosto.Items.Clear();
            CargarLoteCosto();
        }

        private void cboLoteCosto_SelectedValueChanged(object sender, EventArgs e)
        {
            capturarLoteCosto();
        }

        private void cboLoteCosto_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {

        }

        private void cboLoteCosto_Enter(object sender, EventArgs e)
        {
            CargarLoteCosto();
        }
    }
}
