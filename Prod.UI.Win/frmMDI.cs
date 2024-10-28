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
using Prod.UI.Win.Maestros;
using Prod.UI.Win.Procesos;
namespace Prod.UI.Win
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
        #region "metodos formulario"
        void creartabStrip()
        {
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
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }

        }
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
               
                var lista = SegMenuPorPerfilLogic.Instance.Trae_Menu_Por_Perfil(xcodigo, Logueo.codModulo);
                RibbonTab tab = null;
                RadRibbonBarGroup rbg = null;
                RadButtonElement btn = null;

                foreach (var itm in lista)
                {
                    string nivel1 = itm.CodigoFormulario.Substring(0, 2);
                    string nivel2 = itm.CodigoFormulario.Substring(2, 2);
                    string nivel3 = itm.CodigoFormulario.Substring(4, 2);
                    if (!nivel1.Equals("00") && nivel2.Equals("00") && nivel3.Equals("00"))
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

                        if (itm.nombreIcono != null)
                        {

                            btn.Image = Image.FromFile(Logueo.GetRutaIcono() + @"\32x32\" + itm.nombreIcono);
                        }
                        else
                        {
                            btn.Image = Image.FromFile(Logueo.GetRutaIcono() + "cartera.png");
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
                Util.ShowError(ex.Message);
            }

        }
        private void menuService_ContextMenuItemClicked(object sender, ContextMenuItemClickEventArgs e)
        {
            if (e.Item.Text == "Cerrar")
            {
                e.DockWindow.Hide();
                e.Handled = true;
            }
        }
  

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
                       
                        case "FRMLINEAS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMACTIVIDADNIVEL1":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMACTIVIDADNIVEL2":
                            mostrarFormulario(formulario);
                            break;
                            
                        case "FRMPRODUCCION":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMPPSTOCK":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMPPSTOCKVAL":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPKARDEXPP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPKARDEXPPVAL":
                            mostrarFormulario(formulario);
                            break;
                       case "FRMMAQUINAS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMRENDIXBLOQUE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMRENDIXPRODUCTO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMPRODUCCIONXOPERARIO":
                            mostrarFormulario(formulario);
                            break;

                        case "FRMREPRENDIMIENTO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMPRODUCCIONXDIA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMVALIDACIONPP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPCONXACTMP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMSEGUIRCANASTILLA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMTURNOS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMHORAMUERTA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMMOTIVOS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPMPINGVSCORTE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMORDENTRABAJOTIPO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPHORASMUERTAS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPMOTIVOS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPCONTROLPRODUCCION":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMERRORESCOMUNES":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPERRORESCOMUNES":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPMERMA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPTRANSACCIONESPP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPTRANSACCIONESPPVAL":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMVALORESXDEFECTO":
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
                case "FRMLINEAS":
                    return frmLineas.Instance(this);
                case "FRMACTIVIDADNIVEL1":
                    return frmActividadNivel1.Instance(this);
                case "FRMACTIVIDADNIVEL2":
                    return frmActividadNivel2.Instance(this);
                case "FRMPRODUCCION":
                    return frmProduccion.Instance(this);
                case "FRMPPSTOCK":
                    return FrmPPStock.Instance(this);
                case "FRMPPSTOCKVAL":
                    return FrmPPStockVal.Instance(this);
                case "FRMREPKARDEXPP":
                    return frmRepKardexPP.Instance(this);
                case "FRMREPKARDEXPPVAL":
                    return FrmRepKardexPPVal.Instance(this);
                case "FRMMAQUINAS":
                    return frmMaquinas.Instance(this);
                //case "FRMRENDIXBLOQUE":
                //    return Frmrendixbloque.Instance(this);
               case "FRMPRODUCCIONXOPERARIO":
                    return Frmproduccionxoperario.Instance(this);
                case "FRMREPRENDIMIENTO":
                    return FrmRepRendimiento.Instance(this);
                case "FRMPRODUCCIONXDIA":
                    return FrmProduccionxDia.Instance(this);
                case "FRMVALIDACIONPP":
                    return FrmValidacionPP.Instance(this);
                case "FRMREPCONXACTMP":
                    return FrmRepConxActMP.Instance(this);
                case "FRMSEGUIRCANASTILLA":
                    return FrmSeguirCanastilla.Instance(this);
                case "FRMTURNOS":
                    return frmTurnos.Instance(this);
                case "FRMHORAMUERTA":
                    return FrmHoraMuerta.Instance(this);
                case "FRMMOTIVOS":
                    return frmMotivos.Instance(this);
                case "FRMORDENTRABAJOTIPO":
                    return frmOrdenTrabajoTipo.Instance(this);
                case "FRMREPHORASMUERTAS":
                    return FrmRepHorasMuertas.Instance(this);
                case "FRMREPMOTIVOS":
                    return FrmRepMotivos.Instance(this);
                case "FRMREPCONTROLPRODUCCION":
                    return FrmRepControlProduccion.Instance(this);
                case "FRMERRORESCOMUNES":
                    return frmErroresComunes.Instance(this);
                case "FRMREPERRORESCOMUNES":
                    return FrmRepErroresComunes.Instance(this);
                case "FRMREPMERMA":
                    return FrmRepMerma.Instance(this);
                case "FRMREPTRANSACCIONESPP":
                    return FrmRepTransaccionesPP.Instance(this);
                case "FRMREPTRANSACCIONESPPVAL":
                    return FrmRepTransaccionesPPVal.Instance(this);
                case "FRMVALORESXDEFECTO":
                    return frmValoresxDefecto.Instance(this);
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
                // Establecer añio y mes
                capturarAniomes();
                lblPerfil.Text = Logueo.nomPerfil;
                lblUsuario.Text = Logueo.UserName;
                lblNomEmpresa.Text = Logueo.NombreEmpresa;

                this.radDock1.ShowToolCloseButton = false;
                this.radDock1.ShowDocumentCloseButton = false;
                this.radDock1.RootElement.StretchVertically = true;
                this.radDock1.RootElement.StretchHorizontally = true;
                this.radStatusStrip1.BackColor = Color.FromArgb(0, 92, 153);

            }
            catch (Exception ex)
            {

            }
        }
        class BusinessObject
        {

            public int ID { get; set; }

            public string Name { get; set; }

        }

        private void CargarPeriodos()
        {
            try
            {
                var periodo = PeriodoLogic.Instance.PeriodoTraerTodos(Logueo.CodigoEmpresa);
                cboperiodos.DataSource = periodo;
                cboperiodos.DisplayMember = "ccb03des";
                cboperiodos.ValueMember = "ccb03cod";


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
        
        private void capturarAniomes()
        {
            //Si no ha cargado por completo la pantalla no realiza ninguna accion
            if (!isLoaded) return;

            Logueo.Anio = this.cboperiodos.SelectedValue.ToString().Substring(0, 4);
            Logueo.Mes = this.cboperiodos.SelectedValue.ToString().Substring(4, 2);
        }
        
        private void cboperiodos_SelectedValueChanged(object sender, EventArgs e)
        {
            capturarAniomes();
        }
        
        private void imagenfondomdidock()
        {
            var imagePrimitive = new ImagePrimitive();
            imagePrimitive.StretchHorizontally = true;
            imagePrimitive.StretchVertically = true;
            imagePrimitive.Image = new Bitmap(@"D:\MineraDeisi\PROTER\Desarrollo\Modulo Almacen\Imagenes\catalagoBaldosas.png");
            radDock1.MainDocumentContainer.SplitPanelElement.Children.Add(imagePrimitive);
        }

        private void radDock1_DockWindowClosed(object sender, DockWindowEventArgs e)
        {
            try
            {
               
                if (e.DockWindow.Name == "frmDetalleProduccion1")
                {
                    string nombreform = "frmProduccion";
                    Form frm = Application.OpenForms[nombreform] as Form;

                    if (frm != null)
                    {
                        this.radDock1.ActivateMdiChild(frm);
                        radDock1.DockWindows["frmProduccion1"].TabStripItem.ShowCloseButton = true;
                    }
                    this.cboperiodos.Enabled = true;
                }

              
            }
            catch (Exception ex)
            {

            }
        }

        private void radDock1_DockWindowAdded(object sender, DockWindowEventArgs e)
        {
            e.DockWindow.TabStripItem.BackColor2 = Color.FromArgb(255, 246, 218);
            e.DockWindow.TabStripItem.GradientStyle = GradientStyles.Linear;
            e.DockWindow.TabStripItem.BackColor = Color.FromArgb(255, 232, 166);
            e.DockWindow.TabStripItem.ForeColor = Color.Black;          
            
            Form frmDetProduccion = Application.OpenForms["frmDetalleProduccion"] as Form;
            if (frmDetProduccion != null) 
            {
                //radDock1.DockWindows["frmProduccion1"].TabStripItem.ShowCloseButton = false;
                var dock = radDock1.DockWindows["frmProduccion1"].TabStripItem;
                dock.ShowCloseButton = false;
                dock.BackColor = Color.FromArgb(0, 92, 153);
                dock.GradientStyle = GradientStyles.Solid;
                dock.ForeColor = Color.White;
                //this.cboperiodos.Enabled = false;
            }
        }

        private void radDock1_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            //tab deseleccionado

            e.OldTabStripItem.BackColor = Color.FromArgb(0, 92, 153);
            e.OldTabStripItem.GradientStyle = GradientStyles.Solid;
            e.OldTabStripItem.ForeColor = Color.White;
            //tab seleccionado
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

                if (nombre == "frmProduccion1")
                {
                    if (radDock1["frmDetalleProduccion1"].Name != null)
                    {
                        MessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.");
                        if (e.NewWindow.Name == "frmProduccion1")
                        {
                            e.Cancel = true;
                            e.OldWindow.Focus();
                        }
                    }
                }
            }
            catch (Exception ex) { 
            
            }
        }

        private void frmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                DialogResult result = RadMessageBox.Show("Desea salir de la aplicacion", "Sistema", MessageBoxButtons.YesNo,
               RadMessageIcon.Question, MessageBoxDefaultButton.Button2);
                //if(result
                e.Cancel = result == System.Windows.Forms.DialogResult.Yes ? false : true;
            }
            catch (Exception ex)
            {

            }
        }

        private void frmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cboperiodos_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            try
            {
                string[] procesos = { "frmProduccion1"};

                foreach (DockWindow dock in radDock1.DockWindows)
                {
                    for (int x = 0; x < procesos.Length; x++)
                    {
                        if (procesos[x] == dock.Name)
                        {
                            RadMessageBox.Show("Debe cerrar todos los formularios de Procesos para cambiar de periodo", "Sistema", 
                                                MessageBoxButtons.OK, RadMessageIcon.Info);
                            //MessageBox.Show("Debe cerrar todos los formularios de Procesos para cambiar de periodo", "Sistema",
                            //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { 
            
            }
            
        }
        void formateardock() { 
         foreach (DockWindow dock in radDock1.DockWindows) 
            {                
                dock.TabStripItem.BackColor = Color.FromArgb(0, 92, 153);
                dock.TabStripItem.GradientStyle = GradientStyles.Solid;                
                dock.TabStripItem.ForeColor = Color.White;
                //if (dock.TabStripItem.Name == "frmMovi1" || dock.TabStripItem.Name == "FrmArticuloDet1"
                //    || dock.TabStripItem.Name == "frmMateriaPrimaDet1" || dock.TabStripItem.Name == "frmMoviMP1")
                //{
                //    dock.TabStripItem.ShowCloseButton = false;
                //}
                                 
             }            
        }
        private void radDock1_ActiveWindowChanged(object sender, DockWindowEventArgs e)
        {
            if (e.DockWindow == null) return;
            docTabStrip.ThemeName = "Windows8";
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

        
    }
}
