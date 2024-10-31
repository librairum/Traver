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
using Inv.UI.Win.Maestros;
using Inv.UI.Win.Procesos;
namespace Inv.UI.Win
{
    public partial class frmMDI : Telerik.WinControls.UI.RadRibbonForm
    {
        private bool isLoaded = false;
        DocumentTabStrip docTabStrip;
        ActualizacionSistema configuracion = new ActualizacionSistema();
        
        public frmMDI()
        {
            InitializeComponent();
            ContextMenuService menuService = this.radDock1.GetService<ContextMenuService>();
            menuService.ContextMenuDisplaying += menuService_ContextMenuDisplaying;
            // DocumentWindow docu = new DocumentWindow("Titulo");


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
                            //if (System.IO.File.Exists(Logueo.GetRutaIcono() + @"\32x32\" + itm.nombreIcono))
                            //{
                            //    btn.Image = Image.FromFile(Logueo.GetRutaIcono() + @"\32x32\" + itm.nombreIcono);    
                            //}                            
                            if (System.IO.File.Exists(Logueo.GetRutaIcono() + itm.nombreIcono))
                            {
                                btn.Image = Image.FromFile(Logueo.GetRutaIcono() +  itm.nombreIcono);
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
                        case "FRMGENERARVOUCHER":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCONFIVOUCHERCONTABLE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMANALISISCENTROCOSTO":
                            mostrarFormulario(formulario);
                            break;
                            //MOSTRAR frmStockNegativos
                        case "FRMSTOCKNEGATIVOS":
                            mostrarFormulario(formulario);
                            break;
                            //NUEVO ARRIBA END
                        case "FRMDOCU":                            
                            mostrarFormulario(formulario);                                                        
                            break;
                        case "FRMUNIMED":                          
                            mostrarFormulario(formulario);
                            break;
                        case "FRMTIPODOCUMENTO":                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCUENTACORRIENTE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMALMACEN":                           
                            mostrarFormulario(formulario);
                            break;
                        case "FRMTRANSACCION":                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMDETALLEMOVI":
                            //formulario = new frmDetalleMovi();
                            mostrarFormulario(formulario);
                            break;
                        case "FRMINVFISICO":                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMMOVI":                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMUBICACIONFISICA":                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCAMBIARCLAVE":                            
                            //formulario = new Acceso.frmCambiarClave();
                            mostrarFormulario(formulario);
                            break;
                       
                        case "FRMARTICULOCARACLISTA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMARTICULOLISTA":
                            //if menu = "MP"
                            //mostrarFormulario(formulario,"01");
                            //else
                            //mostrarFormulario(formulario,"03");
                            mostrarFormulario(formulario);
                            break;

                        
                        case "FRMREPKARDEX":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPKARDEXVAL":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPKARDEXRES":
                            mostrarFormulario(formulario);
                            break;
                            	

                        case "FRMREPMOVIMIENTOS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPPRODFABRICANTE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPPROVMATERIAPRIMA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMSTOCKREP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMSTOCKREPVAL":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMPERIODOS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPDEVOLUCION":                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPTRANSACCIONES":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPTRANSACCIONESVAL":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMENTRADASALIDA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMVALIDACIONES":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCIERRE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMAPERTURA":                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMMATERIAPRIMALISTA":
                            mostrarFormulario(formulario);
                            break;                            
                        case "FRMMATERIAPRIMADET":
                            mostrarFormulario(formulario);
                            break;
                            
                        case "FRMDOCUMP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCANTERA":
                            
                            mostrarFormulario(formulario);
                            break;
                            //frmProductoProcLista
                        case "FRMPRODUCTOPROCLISTA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMMPSTOCK":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPKARDEXMP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMTIPOANALISIS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPMOVIMIENTOSMP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPTRANSACCIONESMP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMUNIMEDTIPO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMIMPORTARMOVPROD":
                            mostrarFormulario(formulario);
                            break;
                        //case "FRMSEGUIRCANASTILLA":
                        //    mostrarFormulario(formulario);
                        //    break;
                        case "FRMREPMPINGVSCORTE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMLINEAARTICULO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMARTICULOSUMINISTRO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMDOCUSUMINISTRO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMSUSTOCK":
                            mostrarFormulario(formulario);
                            break;

                        case "FRMREPKARDEXSUMINISTRO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPTRANSACCIONESSUMINISTRO":
                            
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPTRANSACCIONESSUMINISTROVAL":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMSTOCKREPSUMINISTRO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCONCILIAINVCONGUIAS":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMEQUIALMACENGUIA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPMOVPORRESPONSABLE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPMOVPORMESSUM":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMGENERAVOUCHER":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCALCULARCOSTOPROMEDIO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCONFIGURARVOUCHERCONTABLE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPALMACENESARCHIVOPLANO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMRESPONSABLES":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPINVPERMAVALORIZADO":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCOSTOCANTERA":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCOSTOTRANSPORTE":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMCOSTEARMP":
                            mostrarFormulario(formulario);
                            break;
                        case "FRMVALORIZADO": 
                            mostrarFormulario(formulario);
                            break;
                        case "FRMREPCONTABLE":
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
                Util.ShowError("Algo salio mal"+ex.ToString());
            }
        }
        private Form AbrirFormulario(string nombre)
        {
            switch (nombre.ToUpper())
            {
                case "FRMALMACEN":
                    return FrmAlmacen.Instance(this);
                case "FRMUNIMED":
                    return FrmUniMed.Instance(this);
                case "FRMCUENTACORRIENTE":
                    return FrmCuentaCorriente.Instance(this);
                case "FRMTIPODOCUMENTO":
                    return FrmTipoDocumento.Instance(this);
                   // return frmTransaccionVentana.Instance(this);
                case "FRMDOCU":
                    return frmDocu.Instance(this);
                case "FRMTRANSACCION":
                    return FrmTransaccion.Instance(this);
                case "FRMDETALLEMOVI":
                    return frmDetalleMovi.Instance(this);
                case "FRMINVFISICO":
                    return FrmInvFisico.Instance(this);
                /* Formulario hijo de formulario documento */
                //case "FRMMOVI":
                //    return frmMovi.Instance(this);
                /* Formulario hijo de formulario documento */
                case "FRMUBICACIONFISICA":
                    return frmUbicacionFisica.Instance(this);
                case "FRMCAMBIARCLAVE":                    
                    return Acceso.frmCambiarClave.Instance(this);
                case "FRMARTICULOCARACLISTA":
                    return FrmArticuloCaracLista.Instance(this);
                    
                case "FRMARTICULOLISTA":
                    //FrmArticuloLista.Instance(this).naturalezAlmacen = "";
                    return FrmArticuloLista.Instance(this);
             
                case "FRMREPKARDEX":
                    return FrmRepKardex.Instance(this);

                case "FRMREPKARDEXVAL":
                    return FrmRepKardexVal.Instance(this);    

                case "FRMREPMOVIMIENTOS":
                    return FrmRepMovimientos.Instance(this);
                case "FRMREPPRODFABRICANTE":
                    return FrmRepProdFabricante.Instance(this);
                case "FRMREPPROVMATERIAPRIMA":
                    return FrmRepProvMateriaPrima.Instance(this);
                case "FRMREPDEVOLUCION":
                    return frmRepControlDevoluciones.Instance(this);
                case "FRMSTOCKREP":
                    return FrmStockRep.Instance(this);
                case "FRMSTOCKREPVAL":
                    return FrmStockRepVal.Instance(this);
                case "FRMPERIODOS":
                    return FrmPeriodos.Instance(this);
                case "FRMREPTRANSACCIONES":
                    return frmRepTransacciones.Instance(this);
                case "FRMREPTRANSACCIONESVAL":
                    return frmRepTransaccionesVal.Instance(this);
                case "FRMENTRADASALIDA":
                    return Procesos.frmEntradaSalida.Instance(this);
                case "FRMVALIDACIONES":
                    return FrmValidaciones.Instance(this);
                case "FRMCIERRE":
                    return frmCierre.Instance(this);
                case "FRMAPERTURA":
                    return frmApertura.Instance(this);
                        
                case "FRMMATERIAPRIMALISTA":
                    return frmMateriaPrimaLista.Instance(this); 
                case "FRMDOCUMP":
                    return frmDocuMP.Instance(this);
                case "FRMCANTERA":
                    return frmCantera.Instance(this);
                case "FRMPRODUCTOPROCLISTA":
                    return frmProductoProcLista.Instance(this);
                case "FRMMPSTOCK":
                    return FrmMPStock.Instance(this);
                case "FRMREPKARDEXMP":
                    return FrmRepKardexMP.Instance(this);
                case "FRMTIPOANALISIS":
                    return FrmTipoAnalisis.Instance(this);
                case "FRMREPMOVIMIENTOSMP":
                    return FrmRepMovimientosMP.Instance(this);
                case "FRMREPTRANSACCIONESMP":
                    return frmRepTransaccionesMP.Instance(this);
                case "FRMUNIMEDTIPO":
                    return FrmUniMedTipo.Instance(this);
                case "FRMIMPORTARMOVPROD":
                    return frmImportarMovProd.Instance(this);
                case "FRMREPMPINGVSCORTE":
                    return FrmRepMPIngvsCorte.Instance(this);
                case "FRMLINEAARTICULO":
                    return frmLineaArticulo.Instance(this);
                case "FRMARTICULOSUMINISTRO":
                    return frmArticuloSuministro.Instance(this);
                case "FRMDOCUSUMINISTRO":
                    return frmDocuSuministro.Instance(this);
                case "FRMSUSTOCK":
                    return FrmSUStock.Instance(this);
                   // return CFrmSUStock.Instance(this);
                //case "FRMSEGUIRCANASTILLA":
                //    return FrmSeguirCanastilla.Instance(this);
                case "FRMREPKARDEXSUMINISTRO":
                    return FrmRepKardexSuministro.Instance(this);
                case "FRMREPTRANSACCIONESSUMINISTRO":
                        return FrmRepTransaccionesSuministro.Instance(this);
                case "FRMREPTRANSACCIONESSUMINISTROVAL":
                        return FrmRepTransaccionesSuministroVal.Instance(this);
                case "FRMCONCILIAINVCONGUIAS":
                    return FrmConciliaInvConGuias.Instance(this);
                case "FRMEQUIALMACENGUIA":
                    return FrmEquiAlmacenGuia.Instance(this);
                case "FRMREPMOVPORRESPONSABLE":
                    return FrmRepMovPorResponsable.Instance(this);
                case "FRMREPMOVPORMESSUM":
                    return FrmRepMovPorMesSum.Instance(this);
                case "FRMCALCULARCOSTOPROMEDIO":
                    return FrmCalcularcostopromedio.Instance(this);
                case "FRMREPALMACENESARCHIVOPLANO":
                    
                    return frmRepAlmacenesArchivoPlano.Instance(this);
                case "FRMRESPONSABLES":
                    return FrmResponsables.Instance(this);
                
                case "FRMSTOCKNEGATIVOS":
                    return frmStockNegativos.Instance(this);
                case "FRMANALISISCENTROCOSTO":
                   return FrmAnalisisCentroCosto.Instance(this);
             
                case "FRMREPINVPERMAVALORIZADO":
                   return frmRepInvPermanenteValo.Instance(this);
                case "FRMCOSTOCANTERA":
                   return FrmCostoCantera.Instance(this);
                case "FRMCOSTOTRANSPORTE":
                  return FrmCostoTransporte.Instance(this);
                case "FRMCOSTEARMP":
                  return frmCostearMP.Instance(this);
                case "FRMVALORIZADO":
                  return FrmValorizado.Instance(this);
                case "FRMCONFIGURARVOUCHERCONTABLE":
                  return FrmConfigurarVoucherContable.Instance(this);
                case "FRMGENERARVOUCHER" :
                  //return frmGenerarVoucher.Instance(this);
                  return frmVoucher.Instance(this);
                  //return frmGeneraVoucher.Instance(this);
                case "FRMREPCONTABLE":
                   return FrmRepContable.Instance(this);
                   break;

                    
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
                this.Text = ".::. SISTEMA DE INVENTARIOS .::." + " v." + configuracion.ObtenerVersion();

                radDock1.MdiChildrenDockType = Telerik.WinControls.UI.Docking.DockType.Document;
                CargarPeriodos();
                isLoaded = true;
                // Establecer añio y mes
                capturarAniomes();

                //primer registro de empresa seleccionada Inventario (Almacen)
                Empresa modulo=   GlobalLogic.Instance.TraerEmpresas("ALMACEN", "")[0];
                Logueo.RucEmpresa = modulo.Ruc;

                lblPerfil.Text = Logueo.nomPerfil;
                lblUsuario.Text = Logueo.UserName;
                lblNomEmpresa.Text = Logueo.NombreEmpresa;

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

        private void cboperiodos_SelectedValueChanged(object sender, EventArgs e)
        {
            capturarAniomes();
        }
        private void capturarAniomes()
        { 
            //Si no ha cargado por completo la pantalla no realiza ninguna accion
            if (!isLoaded) return;
            Logueo.Anio = this.cboperiodos.SelectedValue.ToString().Substring(0,4);
            Logueo.Mes = this.cboperiodos.SelectedValue.ToString().Substring(4, 2);
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
                if (e.DockWindow.Name == "frmMoviSuministro1")
                {
                    string nombreform = "frmDocuSuministro";
                    Form frm = Application.OpenForms[nombreform] as Form;
                    if (frm != null)
                    {
                        this.radDock1.ActivateMdiChild(frm);
                        var dock = radDock1.DockWindows["frmDocuSuministro1"].TabStripItem;
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
            Form frmDocuSuministro = Application.OpenForms["frmMoviSuministro"] as Form;
            if (frmDocuSuministro != null)
            {
                var dock = radDock1.DockWindows["frmDocuSuministro1"].TabStripItem;
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
                        RadMessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.", "Sistema",
                            MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        e.TabStrip.ActiveWindow = radDock1.DockWindows["frmMovi1"];
                        e.Cancel = true;
                    }
                }
                if (nombre == "FrmArticuloLista1")
                {
                    if (radDock1["FrmArticuloDet1"].Name != null)
                    {
                        RadMessageBox.Show("Para ingresar a la cabecera debe terminar el detalle .", "Sistema",
                                            MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        e.TabStrip.ActiveWindow = radDock1.DockWindows["FrmArticuloLista1"];
                        e.Cancel = true;
                    }
                }
                if (nombre == "frmMateriaPrimaLista1")
                {
                    if (radDock1["frmMateriaPrimaDet1"].Name != null)
                    {
                        RadMessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.", "Sistema",
                                            MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        e.TabStrip.ActiveWindow = radDock1.DockWindows["frmMateriaPrimaDet1"];
                        e.Cancel = true;
                    }
                }
                if (nombre == "frmProductoProcLista1") {
                    if (radDock1["frmProductoProcDet1"].Name != null)
                    {
                        RadMessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.", "Sistema", 
                                            MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        e.TabStrip.ActiveWindow = radDock1.DockWindows["frmProductoProcDet1"];
                        e.Cancel = true;
                    }
                }
                if (nombre == "frmDocuMP1")
                {
                    if (radDock1["frmMoviMP1"].Name != null)
                    {
                        RadMessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.", "Sistema",
                            MessageBoxButtons.OK, RadMessageIcon.Exclamation);

                        e.TabStrip.ActiveWindow = radDock1.DockWindows["frmMoviMP1"];
                        e.Cancel = true;
                    }
                }
                if (nombre == "frmDocuSuministro1")
                {
                    if (radDock1["frmMoviSuministro1"].Name != null)
                    {
                        RadMessageBox.Show("Para ingresar a la cabecera debe terminar el detalle.", "Sistema",
                                MessageBoxButtons.OK, RadMessageIcon.Exclamation);

                        e.TabStrip.ActiveWindow = radDock1.DockWindows["frmMoviSuministro1"];
                        e.Cancel = true;
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

                DialogResult result = RadMessageBox.Show("Desea salir de la aplicacion", "Sistema", MessageBoxButtons.YesNo,
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
                    || dock.TabStripItem.Name == "frmMateriaPrimaDet1" || dock.TabStripItem.Name == "frmMoviMP1"
                    || dock.TabStripItem.Name == "frmDocuSuministro1")
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

                string[] procesos = { "frmDocu1", "frmMovi1", "frmDocuMP1", "frmMoviMP1", "FrmInvFisico1", 
                                        "frmUbicacionFisica1", "frmDocuSuministro1" };

                foreach (DockWindow dock in radDock1.DockWindows)
                {
                    for (int x = 0; x < procesos.Length; x++)
                    {
                        if (procesos[x] == dock.Name)
                        {
                            MessageBox.Show("Debe cerrar todos los formularios de rPocesos para cambiar de periodo", "Sistema",
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
    }
}
