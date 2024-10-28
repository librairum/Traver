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
using Fac.UI.Win.Maestros;
namespace Fac.UI.Win
{
    public partial class frmMDI : Telerik.WinControls.UI.RadRibbonForm
    {
        private bool isLoaded = false;
        private int porcentaje = 0;
        DocumentTabStrip docTabStrip;
        LoadReporteBackGround obj = new LoadReporteBackGround();
		ActualizacionSistema configuracion = new ActualizacionSistema();

        
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
                
                ((Telerik.WinControls.UI.StripViewItemContainer)(this.docTabStrip.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(153)))));
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
        /*en este metodo agregar evento y perfiles */
        #region "metodo Formulario Principal"
        public frmMDI(string perfilPermiso)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

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

            //Cargar los eventos para generar el reporte.
            obj.LoadEventForBackGroundWorker(backgroundWorker1);

            
            lblUsuario.Text = Logueo.UserName;
            lblPerfil.Text = Logueo.nomPerfil;

        }
        void agregarBtnCambiaClave() { 
            Acceso.frmCambiarClave f = new Acceso.frmCambiarClave();
            this.Opacity = 200;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            
            //f.ControlBox = false;
            f.ShowDialog();
            //mostrarFormulario(f);
        }
        private void  btnSalida_Click(object sender ,EventArgs e) {
            this.Close();
            Application.Exit();
        }
        private void btnCambiarPass_Click(object sender, EventArgs e) {
            agregarBtnCambiaClave();
        }
        void cargarPermisos(string xcodigo)
        {
            try
            {
                var lista = SegMenuPorPerfilLogic.Instance.Trae_Menu_Por_Perfil(xcodigo,"03");
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
                        
                        //btn.Tag = itm;
                        
                        //if (itm.nombreIcono != null)
                        //{
                        //    btn.Image = Image.FromFile(Logueo.GetRutaIcono()+@"\32x32\" + itm.nombreIcono);
                        //}
                        //else {
                        //    btn.Image = Image.FromFile(Logueo.GetRutaIcono() + "cartera.png");
                        //}
                        //btn.ImageAlignment = ContentAlignment.TopCenter;                                                
                        //btn.TextImageRelation = TextImageRelation.ImageAboveText;                                                                                           
                        //btn.Click += new EventHandler(xradButtonElement_Click);
                        //rbg.Items.Add(btn);

                       btn.Tag = itm;
                        
                        if (itm.nombreIcono != "")
                        {
                            btn.Image = Image.FromFile(Logueo.GetRutaIcono()+@"\32x32\" + itm.nombreIcono);
                            btn.ImageAlignment = ContentAlignment.TopCenter;
                            btn.TextImageRelation = TextImageRelation.ImageAboveText;
                        }
                        
                        btn.Click += new EventHandler(xradButtonElement_Click);
                        rbg.Items.Add(btn);
                    
                    }
                 }

                //seleccionar tab de menu por defecto
                foreach (RibbonTab menucabecera in this.radRibbonBar1.CommandTabs)
                {
                    if (menucabecera.Text == "Procesos")
                    {
                        menucabecera.IsSelected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //boton para abrir formularios y mostrar en los raddock(paneles)
         private void xradButtonElement_Click(object sender, EventArgs e)
        {
            string nombreform = "";
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
                    if (nombreform.ToUpper() != "")
                    {
                        mostrarFormulario(formulario);
                    }
                    else
                    {
                        this.Close();
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
                frm.Shown += new EventHandler(frm_Shown);
               
                //MessageBox.Show(frm.Focused.ToString());
                radDock1.ActivateMdiChild(frm);                                                
                
            }
            catch (Exception ex)
            {
                Util.ShowError("ERROR::" +ex);
            }            
        }
        void frm_Shown(object sender, EventArgs e) {
            frmBaseMante f =  sender as frmBaseMante;
            
            if (f != null) {                
                f.barraMenu.Focus();
            }
            
        }
        private Form AbrirFormulario(string nombre)
        {
            switch (nombre.ToUpper())
            {
                
                case "FRMGUIATRANSPORTISTA":
                    return frmGuiaTransportista.Instance(this);

                case "FRMTRANSPORTISTA":
                    return frmTransportista.Instance(this);

                case "FRMCONDUCTORES":
                    return frmConductores.Instance(this);

                case "FRMDESTINATARIOS":                    
                    return frmDestinatarios.Instance(this);

                case "FRMVEHICULO":
                    return frmVehiculo.Instance(this);

                case"FRMTIPDOCVENTAS":
                    return frmTipDocVentas.Instance(this);
                
                case "FRMPLANTILLAS":
                    return frmPlantillas.Instance(this);

                case "FRMSERIES":
                    return frmSeries.Instance(this);
                case "FRMSUBPLANTILLA":
                    return frmSubPlantilla.Instance(this);
                case "FRMASIENTOTIPO":
                    return frmAsientoTipo.Instance(this);
                case "FRMLISTADOCUMENTOS":
                    return frmListaDocumentos.Instance(this);
                case "FRMBANCOS":
                    return frmBancos.Instance(this);
                case "FRMCAMPOSOPCIONALES":
                    return frmCamposOpcionales.Instance(this);
                case "FRMCLIENTE":
                    return frmcliente.Instance(this);
                case "FRMEMPRESA":
                    return frmempresa.Instance(this);
                case "FRMFORMAPAGO":
                    return frmFormaPago.Instance(this);
                case "FRMMONEDA":
                    return frmMoneda.Instance(this);
                case "FRMPAISES":
                    return frmPaises.Instance(this);
                case "FRMPLANTILLADOCELE":
                    return frmPlantillaDocEle.Instance(this);
                case "FRMPLANTILLAXCAMPOOPCIONAL":
                    return frmPlantillaxCampoOpcional.Instance(this);
                case "FRMPRODUCTOS":
                    return frmProductos.Instance(this);
                case "FRMPUERTOS":
                    return frmPuertos.Instance(this);
                case "FRMPUNTOVENTA":
                    return frmPuntoVenta.Instance(this);
                case "FRMREPCONSULTAXCLIENTE":
                    return frmRepConsultaxcliente.Instance(this);
                case "FRMRESUMENDEBOLETAS":
                    return frmResumendeBoletas.Instance(this);
                case "FRMSEGURIDAD":
                    return frmseguridad.Instance(this);
                case "FRMTABGLOPROD":
                    return frmTabGloProd.Instance(this);
                case "FRMTABLASGLOBALES":
                    return frmtablasglobales.Instance(this);
                case "FRMVOUCHERCONTABLE":
                    return frmVoucherContable.Instance(this);
                case "FRMGENERARFACTURAXGUIA":
                    return frmGenerarFacturaxGuia.Instance(this);
                case "FRMGENERARDOCPROVISIONAL":
                    return frmGenerarDocProvisional.Instance(this);
                case "FRMCAMBIARCLAVE":
                      return Acceso.frmCambiarClave.Instance(this);
                case "FRMFACTURASCANCELAR":
                      return frmFacturasCancelar.Instance(this);
                case "FRMPACKINGLIST":
                      return frmPackingList.Instance(this);
                case "FRMSERVICIOS":
                      return frmServicios.Instance(this);
                case "FRMEQUIVPRODSUNAT":
                      return frmEquivProdSunat.Instance(this);
                case "FRMPRODUCTOSVARIOS":
                      return frmProductosVarios.Instance(this);
                case "FRMREPVENTASANUALES":
                      return frmRepVentasAnuales.Instance(this);
                case "FRMREPVENTAPORSEDE":
                      return frmRepVentaPorSede.Instance(this);
                case "FRMREPVENTASNACIONALES":
                      return frmRepVentasNacionales.Instance(this);
                case "FRMREPARTICLIXARTIPROD":
                      return frmRepArtiClixArtiProd.Instance(this);
                case "FRMREPVENTASADMINISTRACION":
                      return frmRepVentasAdministracion.Instance(this);
                case "FRMREPGUIASADMINISTRACION":
                      return frmRepGuiasAdministracion.Instance(this);
                case "FRMUSUARIOXSERIEDOCUMENTO":
                    return frmUsuarioxSerieDocumento.Instance(this);
                case "FRMREPVENTASARCHIVOPLANO":
                    return frmRepVentasArchivoPlano.Instance(this);
                case "FRMMOSTRADORLINEAARTICULO":
                    return frmMostradorLineaArticulo.Instance(this);
                case "FRMARTICULOSUMINISTRO":
                    return frmArticuloSuministro.Instance(this);
                case "FRMUNIMED":
                    return FrmUniMed.Instance(this);
                case "FRMTIPOCAMBIOMONEDA":
                    return frmTipoCambioMoneda.Instance(this);
               case "FRMREPGUIASCANTERA":
                    return frmRepGuiasCantera.Instance(this);
               case "FRMPLANTILLAXVOUCHER":
                    return frmPlantillaXVoucher.Instance(this);
              
                    
            }
            return null;
        }
        #endregion                

        private void frmMDI_Load(object sender, EventArgs e)
        {
            
            this.radDock1.AutoDetectMdiChildren = true;
            this.IsMdiContainer = true;
			//this.Text = ".::. SISTEMA DE FACTURACION - LIMA .::." + " v." + configuracion.ObtenerVersion();
            this.Text = ".::. SISTEMA DE FACTURACION - LIMA (Produccion) .::." + " v." + configuracion.ObtenerVersion();
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

            backgroundWorker1.RunWorkerAsync();
            //creartabStrip();
          
            //this.documentWindow1.DocumentButtons &= ~Telerik.WinControls.UI.Docking.DocumentStripButtos.Close;
            // Cargar imagen de fondo del mdi
           // imagenfondomdidock();

            //correr reporte en segundo plano
                //llamr al reporte
                //cerralo

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
            Logueo.periodo = Logueo.Anio + Logueo.Mes;
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

                string nombreDockVentana = e.DockWindow.Name;
                if (nombreDockVentana == "frmcliente" || 
                    nombreDockVentana == "frmAsientoTipo" || 
                    nombreDockVentana  == "frmProductos")
                {
                    OcultaBotonCerrarFormularioPadre(nombreDockVentana);
                }
                

                if (radDock1.DocumentManager.ActiveDocument != null)
                {
                    
                    radDock1.DocumentManager.ActiveDocument.TabStripItem.BackColor2 = Color.FromArgb(255, 246, 218);
                    radDock1.DocumentManager.ActiveDocument.TabStripItem.GradientStyle = GradientStyles.Linear;
                    radDock1.DocumentManager.ActiveDocument.TabStripItem.BackColor = Color.FromArgb(255, 233, 166);
                    radDock1.DocumentManager.ActiveDocument.TabStripItem.ForeColor = Color.Black;
                }
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
            }
            
        }
        private void OcultaBotonCerrarFormularioPadre(string nombreFormularioPadre)
        {
            string nombreDockWindow = "";
            nombreDockWindow = nombreFormularioPadre + "1";

            Form frm = Application.OpenForms[nombreFormularioPadre] as Form;
            if (frm != null)
            {
                this.radDock1.ActivateMdiChild(frm);
                radDock1.DockWindows[nombreDockWindow].TabStripItem.ShowCloseButton = true;
            }
        }
        private void frmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
      
       //evento para el tab agreado al radDock
        private void radDock1_DockWindowAdded(object sender, DockWindowEventArgs e)
        {
            if (radDock1.DockWindows.Count > 1)
            { 
                // Dar formato a los tab no activo
                int  x = 0;
                for (x = 0; x < radDock1.DockWindows.Count; x++)
                {
                    radDock1.DockWindows[x].TabStripItem.BackColor = Color.FromArgb(0, 92, 153);
                    radDock1.DockWindows[x].TabStripItem.GradientStyle = GradientStyles.Solid;
                    //color del texto del tab menu raddock deseleccionado.
                    radDock1.DockWindows[x].TabStripItem.ForeColor = Color.White;
                }
            }
            
            //Asignar color amarillo al dockwindow activo
                e.DockWindow.TabStripItem.BackColor2 = Color.FromArgb(255, 246, 218);
                e.DockWindow.TabStripItem.GradientStyle = GradientStyles.Linear;
                e.DockWindow.TabStripItem.BackColor = Color.FromArgb(255, 232, 166);
                e.DockWindow.TabStripItem.ForeColor = Color.Black;
                
                
                // Form frmMovi = Application.OpenForms["frmMovi"] as Form;
                // if (frmMovi != null)
                // {
                //    radDock1.DockWindows["frmDocu1"].TabStripItem.ShowCloseButton = false;
                //}
                // Form frmArti = Application.OpenForms["FrmArticuloDet"] as Form;
                // if (frmArti != null)
                // {
                //     radDock1.DockWindows["FrmArticuloLista1"].TabStripItem.ShowCloseButton = false;
                // }

                // Form frmGuiaTranporte = Application.OpenForms["fabcGuiasTransporte"] as Form;
                // if (frmGuiaTranporte != null)
                // {
                //     radDock1.DockWindows["frmGuiaTransportista1"].TabStripItem.ShowCloseButton = false;
                // }
        }

        void DockWindow_GotFocus(object sender, EventArgs e)
        {
            
        }

        private void radDock1_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            ////tab deseleccionado            
            ////color de fondo de tab menu raddock deseleccionado
            //e.OldTabStripItem.BackColor = Color.FromArgb(0, 92, 153);
            //e.OldTabStripItem.GradientStyle = GradientStyles.Solid;
            ////color del texto del tab menu raddock deseleccionado.
            //e.OldTabStripItem.ForeColor = Color.White;

            int x = 0;
            for (x = 0; x < radDock1.DockWindows.Count; x++)
            {
                radDock1.DockWindows[x].TabStripItem.BackColor = Color.FromArgb(0, 92, 153);
                radDock1.DockWindows[x].TabStripItem.GradientStyle = GradientStyles.Solid;
                //color del texto del tab menu raddock deseleccionado.
                radDock1.DockWindows[x].TabStripItem.ForeColor = Color.White;
            }

            if (radDock1.DocumentManager.BoldActiveDocument == true)
            {
                //tab seleccionado    
                radDock1.DocumentManager.ActiveDocument.TabStripItem.BackColor2 = Color.FromArgb(255, 246, 218);
                radDock1.DocumentManager.ActiveDocument.TabStripItem.GradientStyle = GradientStyles.Linear;
                radDock1.DocumentManager.ActiveDocument.TabStripItem.BackColor = Color.FromArgb(255, 233, 166);
                radDock1.DocumentManager.ActiveDocument.TabStripItem.ForeColor = Color.Black;
            }
            
            
        }
        //private void EnfocarFormularioPadre(string nombreFormularioPadre, string nombreFormularioHijo)
        //{
        //    string nombreDock = "", tituloDetalleDocumento = "", tituloListaDocumento = "";
        //    nombreDock = nombreFormularioPadre + "1";


        //    if (nombreFormularioPadre == "frmGuiaTransportista" || nombreFormularioPadre == "frmFacturas" ||
        //        nombreFormularioPadre == "frmListaDocumentos" || nombreFormularioPadre == "")
        //    { 
                
        //    }

        //}
        private bool ValidarFormularioPadreAbierto(string nombreFormularioPadre, string nombreFormularioHijo, DockWindow ventanaAcoplamiento)
        {
            bool bloquearVentanaPadre = true;
            string nombre = ventanaAcoplamiento.Name;
            string tituloDetalleDocumento = "", tituloListaDocumento = "", acoplamientoPadre = "", acoplamientoHijo = "";
                
            try
            {
                acoplamientoPadre = nombreFormularioPadre;
                acoplamientoHijo = nombreFormularioHijo;

                if (nombre == acoplamientoPadre)
                {
                    if (radDock1[acoplamientoHijo].Name != null)
                    {
                        tituloListaDocumento = radDock1[acoplamientoPadre].Text;
                        tituloDetalleDocumento = radDock1[acoplamientoHijo].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        if (ventanaAcoplamiento.Name == acoplamientoPadre)
                        {
                            bloquearVentanaPadre = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                //Util.ShowError("Error al validar formulario abierto: " + ex.Message);
            }
            return bloquearVentanaPadre;
        }
        private void radDock1_SelectedTabChanging(object sender, SelectedTabChangingEventArgs e)
        {
            try
            {
                string nombre = e.NewWindow.Name;
                string tituloDetalleDocumento = "", tituloListaDocumento = "";

                if (nombre == "frmcliente1")
                {
                    if (radDock1["frmClienteDet1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmcliente1"].Text;
                        tituloDetalleDocumento = radDock1["frmClienteDet1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);                        
                        e.Cancel = true;                        
                    }
                }
                if (nombre == "frmListaDocumentos1")
                {
                    if (radDock1["frmFacturas1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmListaDocumentos1"].Text;
                        tituloDetalleDocumento = radDock1["frmFacturas1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                    else if (radDock1["frmNotaCreYNotDeb1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmListaDocumentos1"].Text;
                        tituloDetalleDocumento = radDock1["frmNotaCreYNotDeb1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                    
                }
                if (nombre == "frmFacturas1")
                {
                    if (radDock1["frmfacturacab1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmFacturas1"].Text;
                        tituloDetalleDocumento = radDock1["frmfacturacab1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                    
                }
                if (nombre == "frmNotaCreYNotDeb1")
                {
                    if (radDock1["frmCabNotCredYDeb1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmNotaCreYNotDeb1"].Text;
                        tituloDetalleDocumento = radDock1["frmCabNotCredYDeb1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                }

                if (nombre == "frmtablasglobales1")
                {
                    if (radDock1["frmtablaglobalesDet1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmtablasglobales1"].Text;
                        tituloDetalleDocumento = radDock1["frmtablaglobalesDet1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                }
                if (nombre == "frmProductos1")
                {
                    if (radDock1["frmProductosDet1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmProductos1"].Text;
                        tituloDetalleDocumento = radDock1["frmProductosDet1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                }
                if (nombre == "frmGuiaTransportista1")
                {
                    if (radDock1["frmabcGuiasTransporte1"] != null)
                    { 
                        tituloListaDocumento = radDock1["frmGuiaTransportista1"].Text;
                        tituloDetalleDocumento = radDock1["frmabcGuiasTransporte1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                }

                if (nombre == "frmAsientoTipo1")
                {
                    if (radDock1["frmabcAsientoTipo1"] != null)
                    {
                        tituloListaDocumento = radDock1["frmAsientoTipo1"].Text;
                        tituloDetalleDocumento = radDock1["frmabcAsientoTipo1"].Text;
                        Util.ShowAlert("Cierre " + tituloDetalleDocumento + " para ver " + tituloListaDocumento);
                        e.Cancel = true;
                    }
                }
                                      
            }
            catch (Exception ex)
            {

            }
        }


        private void frmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool respuesta = Util.ShowQuestion("¿Desea salir de la aplicacion?");
                if (respuesta == false)
                {
                    e.Cancel = true;                    
                }                
                
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }

        private void cboperiodos_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            try
            {
                string[] formularios = { "frmFacturas1", "frmNotaCreYNotDeb1", "frmfacturacab1", 
                                            "frmCabNotCredYDeb1", "frmPackingList1", "frmPackingListDet1",
                                       "frmVoucherContable1","frmResumendeBoletas1", "frmGuiaTransportista1", 
                                       "frmGenerarFacturaxGuia1", "frmFacturasCancelar1" };
                foreach (DockWindow dock in radDock1.DockWindows)
                {
                    for (int x = 0; x < formularios.Length; x++)
                    {
                        if (formularios[x] == dock.Name)
                        {
                            RadMessageBox.Show("Debe cerrar todos los formularios de Procesos para cambiar de periodo", "Sistema",
                                                MessageBoxButtons.OK, RadMessageIcon.Info);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                
            }
        }

        private void radDock1_Click(object sender, EventArgs e)
        {

        }

        private void documentContainer1_Click(object sender, EventArgs e)
        {

        }
                   
    }
}
