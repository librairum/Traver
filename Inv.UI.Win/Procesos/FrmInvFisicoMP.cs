using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI;
using System.IO;

namespace Inv.UI.Win
{

    public partial class FrmInvFisicoMP : frmBaseMante
    {
        private bool isLoaded = false;
        RadGridView grilla;
        public FrmInvFisicoMP()
        {
            InitializeComponent();
            Crearcolumnas();
            CrearColumnasDet();
            CargarAlmacenes(cboalmacenes);
            this.dtpFecha.Value = DateTime.Now;
            //gbnuevo.Visible=false;
        }
        private frmMDI FrmParent { get; set; }


        private static FrmInvFisicoMP _aForm;
        public static FrmInvFisicoMP Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new FrmInvFisicoMP(mdiPrincipal) ;
            _aForm = new FrmInvFisicoMP(mdiPrincipal);
            return _aForm;
        }

        public FrmInvFisicoMP(frmMDI padre) {
            InitializeComponent();
            FrmParent = padre;
            Crearcolumnas();
            CrearColumnasDet();
            CargarAlmacenes(cboalmacenes);
            this.dtpFecha.Value = DateTime.Now;
            //gbnuevo.Visible = false;
        }

        private void HabilitarcontrolesxEstado(FormEstate  estadoFormulario) {
      

            switch (estadoFormulario)
            {
                case FormEstate.List:
                    dtpFecha.Enabled = false;
                    cboalmacenes.Enabled = false;
                    rbtinvfisicodiferencias.Enabled = true;
                    rbtinvfisicotoma.Enabled = true;
                    lblmensaje.Visible = false;
                    break;
                case FormEstate.New:
                    rbtinvfisicodiferencias.Enabled = false;
                    rbtinvfisicotoma.Enabled = false;
                    dtpFecha.Enabled = true;
                    cboalmacenes.Enabled = true;
                    lblmensaje.Visible = false;
                    break;
                case FormEstate.Edit:
                    dtpFecha.Enabled = false;
                    cboalmacenes.Enabled = false;
                    rbtinvfisicotoma.Enabled = false;
                    rbtinvfisicodiferencias.Enabled = false;
                    lblmensaje.Visible = true;
                    break;
                case FormEstate.View:
                       dtpFecha.Enabled = false;
                    cboalmacenes.Enabled = false;
                    rbtinvfisicodiferencias.Enabled = true;
                    rbtinvfisicotoma.Enabled = true;
                    lblmensaje.Visible = false;
                    break;
                default:
                    break;
            }
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = InventarioFisicoLogic.Instance.InventarioFisicoPorAnio(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.MP_codnaturaleza);
            this.gridControl.DataSource = lista;
        }
        protected void OnBuscarDet()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.gridControl.RowCount == 0)
                    return;

                string invfisalmacen = string.Empty;
                DateTime invfisfechadate;
                string invfisfecha = string.Empty;

                invfisalmacen = this.gridControl.CurrentRow.Cells["IN04CODALM"].Value.ToString();
                invfisfechadate = Convert.ToDateTime(this.gridControl.CurrentRow.Cells["IN04FECINV"].Value.ToString());
                invfisfecha = string.Format("{0:dd/MM/yyyy}", invfisfechadate);

                //base.OnBuscar();
                

                var lista = InventarioFisicoLogic.Instance.InventarioFisicoTraer(Logueo.CodigoEmpresa, Logueo.Anio, invfisalmacen, invfisfecha);
                this.gridControlDet.DataSource = lista;

                if (Estado == FormEstate.Edit)
                {
                    //resaltar la columna de estado por ser una columan tipo ayuda
                    Util.ResaltarAyudaColumna(gridControlDet, "estadoinventariodesc");
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) {
                Util.ShowError("Error al traer detalle:" + ex.Message);
              
            }
            Cursor.Current = Cursors.Default;
        }   
        protected override void OnVista()
        {
            
             if (this.gridControl.RowCount == 0)
                return;

             try
             {
                 string invfisalmacen = string.Empty;
                 DateTime invfisfechadate;
                 string invfisfecha = string.Empty;

                 invfisalmacen = this.gridControl.CurrentRow.Cells["IN04CODALM"].Value.ToString();
                 invfisfechadate = Convert.ToDateTime(this.gridControl.CurrentRow.Cells["IN04FECINV"].Value.ToString());
                 invfisfecha = string.Format("{0:dd/MM/yyyy}", invfisfechadate);

                 Cursor.Current = Cursors.WaitCursor;
                 // Capturo los datos de la grilla

                 //GlobalLogic.Instance.InsertarRangoImpresion(Logueo.CodigoEmpresa, "Admin", this.txtCodigoTipDoc.Text, this.txtNroDocumento.Text, out mensajeOut);
                 Reporte reporte = new Reporte("Documento");
                 reporte.Ruta = Logueo.GetRutaReporte();

                 if (rbtinvfisicotoma.CheckState == CheckState.Checked)
                 {
                     
                         var datos = InventarioFisicoLogic.Instance.InventarioFisicoRepToma(Logueo.CodigoEmpresa, Logueo.Anio, invfisalmacen, invfisfecha);
                         reporte.Nombre = "RptInvFisicotomaBloque.rpt";
                         reporte.DataSource = datos;
                         reporte.FormulasFields.Add(new Formula("FechaInvFisico", invfisfecha));
                         reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                     
                         
                     
                 
                 }
                 else if (rbtinvfisicodiferencias.CheckState == CheckState.Checked)
                 {


                     var datosd = InventarioFisicoLogic.Instance.InventarioFisicoRepDife(Logueo.CodigoEmpresa, Logueo.Anio, invfisalmacen, invfisfecha, "D");
                     reporte.Nombre = "RptInvFisicoDiferenciasBloque.rpt";
                     reporte.DataSource = datosd;
                     reporte.FormulasFields.Add(new Formula("FechaInvFisico", invfisfecha));
                     reporte.FormulasFields.Add(new Formula("NombreEmpresa", Logueo.NombreEmpresa));
                 }

                 ReporteControladora control = new ReporteControladora(reporte);
                 control.VistaPrevia(enmWindowState.Normal);

                 Cursor.Current = Cursors.Default;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            //gbnuevo.Visible=true;

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            
            HabilitarcontrolesxEstado(this.Estado);
            
        }
        protected override void OnEditar()
        {
            this.Estado = FormEstate.Edit;
            //HabilitarBotones(false, false, false, false, true, false);
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            HabilitarcontrolesxEstado(this.Estado);
            //Util.ResaltarAyuda(gridControlDet.CurrentRow.Cells["in04estado"]);
            Util.ResaltarAyudaColumna(gridControlDet, "estadoinventariodesc");
            //ver boton de importar inventario
            btnImportarInventarioMasivo.Visible = true;
        }
        protected override void OnEliminar()
        {
            string invfisalmacen = string.Empty;
            DateTime invfisfechadate;
            string invfisfecha = string.Empty;
            string msgRetorno = string.Empty;

            if (this.gridControl.RowCount == 0)
                return;
            
            try
            {
                DialogResult result = RadMessageBox.Show("Está seguro de eliminar", Constantes.MensajesGenericos.MSG_TITULO_CONFIRMAR, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    invfisalmacen = this.gridControl.CurrentRow.Cells["IN04CODALM"].Value.ToString();
                    invfisfechadate = Convert.ToDateTime(this.gridControl.CurrentRow.Cells["IN04FECINV"].Value.ToString());
                    invfisfecha = string.Format("{0:dd/MM/yyyy}", invfisfechadate);

                    InventarioFisico inventariofisico = new InventarioFisico();
                    
                    inventariofisico.IN04CODEMP=Logueo.CodigoEmpresa;
                    inventariofisico.IN04AA=Logueo.Anio;
                    inventariofisico.IN04CODALM=invfisalmacen;
                    inventariofisico.IN04FECINV = invfisfechadate;

                    InventarioFisicoLogic.Instance.InventarioFisicoEliminar(inventariofisico, out msgRetorno);
                    RadMessageBox.Show(msgRetorno, Constantes.MensajesGenericos.MSG_TITULO_INFO, MessageBoxButtons.OK, RadMessageIcon.Info);

                    OnBuscar();
                    OnBuscarDet();
                    if (gridControl.RowCount == 0) {
                        if (gridControlDet.RowCount > 0)
                        {
                            gridControlDet.Rows.Clear();
                        }
                    }
                    
                }
            }
            catch (Exception)
            {

                RadMessageBox.Show(Constantes.MensajesGenericos.MSG_ERROR_INESPERADO, Constantes.MensajesGenericos.MSG_TITULO_ERROR, MessageBoxButtons.OK, RadMessageIcon.Info);
            }


        }
        int ultimoRegistroSeleccionado = -1;
        protected override void OnCancelar()
        {
            try
            {
                if (gridControl.Rows.Count > 0) {
                    ultimoRegistroSeleccionado = gridControl.CurrentRow.Index;
                    OnBuscar();
                    gridControl.CurrentRow = gridControl.Rows[ultimoRegistroSeleccionado];
                
                }
                
                //
                //HabilitarBotones(true, true, true, false, false, true);
                Estado = FormEstate.List;
                OcultarBotones();
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
                HabilitarcontrolesxEstado(Estado);
                OnBuscarDet();
                //enfocar ultimo registro selecionado de la grilla de inventario generado
                btnImportarInventarioMasivo.Visible = false;
            }
            catch (Exception ex) { 
            
            }
            

        }
        protected override void OnGuardar()
        {
            string mensajeRetorno = string.Empty;
            string mensajeRetorno1 = string.Empty;
            string fechaini = string.Empty;
            
            try
            {
                InventarioFisico inventariofisico = new InventarioFisico();
                inventariofisico.IN04CODEMP = Logueo.CodigoEmpresa;
                inventariofisico.IN04AA= Logueo.Anio;
                inventariofisico.IN04CODALM= this.cboalmacenes.SelectedValue.ToString().Substring(0, 2);
                inventariofisico.IN04FECINV = this.dtpFecha.Value;
                
                if (this.Estado == FormEstate.New)
                {
                    //NUEVO
                    Cursor.Current = Cursors.WaitCursor;

                    InventarioFisicoLogic.Instance.InventarioFisicoInsertar(inventariofisico,out mensajeRetorno);
                    string fecha = inventariofisico.IN04FECINV.ToString();
                    RadMessageBox.Show(mensajeRetorno, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    // Ocultar group box
                    //gbnuevo.Visible = false;
                    // refrescar grilla
                    OnBuscar();
                    OnBuscarDet();
                    HabilitarcontrolesxEstado(FormEstate.List);

                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    RadMessageBox.Show("Opcion no validad", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
            }
            catch (Exception ex )
            {
                  RadMessageBox.Show("Ha ocurrido error inesperado al registrar:  " + ex.Message, "Aviso", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            //HabilitarBotones(true, true, true, false, false, true);
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            
        }
        #region metodosdemantenimineto
        
        private void Crearcolumnas()
        {
            
            grilla = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(grilla, "Almacen", "IN04CODALM", 0, "", 30, true, false, true);
            this.CreateGridColumn(grilla, "Almacen.Desc.", "in09descripcion", 0, "", 130, true, false, true);
            this.CreateGridColumn(grilla, "Fecha", "IN04FECINV", 0, "{0:dd/MM/yyyy}", 75, true, false, true);

            
        }
    

        private void CrearColumnasDet()
        {
            
            RadGridView grilladet = this.CreateGridVista(this.gridControlDet);
            //this.CreateGridColumn(grilladet, "Item", "ItemCorrelativo", 0, "", 50, true, false, false);

            this.CreateGridColumn(grilladet, "Item", "IN04ITEM", 0, "", 50, false, true, true);

            this.CreateGridColumn(grilladet, "Columna", "AlmacenColumna", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilladet, "Bloque", "In04caja", 0, "", 70, true, false, true);
            this.CreateGridColumn(grilladet, "Ubicacion", "In07ubicacion", 0, "", 90, true, false, true);
            this.CreateGridColumn(grilladet, "Codigo", "in04key", 0, "", 100, true, false, true);
            this.CreateGridColumn(grilladet, "Descripcion", "in01deslar", 0, "", 200, true, false, true);
            this.CreateGridColumn(grilladet, "Uni Med", "in01unimed", 0, "", 50, true, false, true);
            this.CreateGridColumn(grilladet, "Volumen", "IN04CANTFISICA", 0, "", 80, false, true, true);

            this.CreateGridColumn(grilladet, "Fecha Inv", "IN04FECINV", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilladet, "Almacen", "IN04CODALM", 0, "", 50, true, false, false);

            this.CreateGridColumn(grilladet, "Estado", "in04estado", 0, "", 50, true, false, false);
            this.CreateGridColumn(grilladet, "DescEstado", "estadoinventariodesc", 0, "", 100, true, false, false);

            this.CreateGridColumn(grilladet, "Obs", "in04observacion", 0, "", 200, false, true, true);
            
            
            //--AgregarColumnaCombo();


        } 
        #endregion metodosdemantenimineto
        private void gridControl_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["IN04CODALM"].Value != null)
                    {
                        OnBuscarDet();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }
        }
        private void FrmInvFisicoMP_Load(object sender, EventArgs e)
        {
            OnBuscar();
            //Capturo el primer registro valido 
            OnBuscarDet();
            isLoaded = true;
            //HabilitarBotones(true, true, true, false, false, true);
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPreliminar);
            Estado = FormEstate.List;
            HabilitarcontrolesxEstado(Estado);
            btnImportarInventarioMasivo.Visible = false;
        }
        private void CargarAlmacenes(RadDropDownList cbo)
        {
            try
            {
                //var almacen = AlmacenLogic.Instance.AlmacenTraer(Logueo.CodigoEmpresa);
                var almacen = AlmacenLogic.Instance.AlmacenTraerxNaturaleza(Logueo.CodigoEmpresa, Logueo.MP_codnaturaleza);
                cbo.DataSource = almacen;
                cbo.DisplayMember = "in09descripcion";
                cbo.ValueMember = "in09codigo";

                //Establesco por defecto Todos los alamcenes
                cbo.SelectedValue = "06";
            }


            catch (Exception)
            {

                throw;
            }
        }
        private void gridControl_Click(object sender, EventArgs e)
        {

        }
        private void gridControlDet_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Value == null)
                return;
            try
            {

                if (e.Column.Name.CompareTo("IN04CANTFISICA") == 0 )
                {
                    if (e.Value != null) {
                        bool esNumero = Util.IsNumerico(e.Value.ToString());
                        if (esNumero)
                        {
                            this.GuardarDetalle(this.gridControlDet.CurrentRow);
                        }
                        else
                        {
                            Util.ShowError("Ingresar un valor numerico entero");
                        }
                        
                        
                    }


                }
                else if (e.Column.Name.CompareTo("in04observacion") == 0) 
                {
                    if (e.Value != null) {
                        this.GuardarDetalle(this.gridControlDet.CurrentRow);
                    }
                    
                
                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
            }

        }
        private void GuardarDetalle(GridViewRowInfo info)
        {
            try
            {
                InventarioFisico invfis = new InventarioFisico();

                invfis.IN04CODEMP = Logueo.CodigoEmpresa;
                invfis.IN04AA = Logueo.Anio;
                invfis.IN04FECINV = Convert.ToDateTime(info.Cells["IN04FECINV"].Value.ToString());
                invfis.IN04CODALM = info.Cells["IN04CODALM"].Value.ToString();
                invfis.IN04KEY = info.Cells["IN04KEY"].Value.ToString();
                invfis.IN04ITEM = int.Parse(info.Cells["IN04ITEM"].Value.ToString());
                invfis.IN04CANTFISICA =double.Parse(info.Cells["IN04CANTFISICA"].Value.ToString());

                if (info.Cells["in04observacion"].Value != null) {
                    invfis.in04observacion = info.Cells["in04observacion"].Value.ToString();
                }

                if(info.Cells["in04estado"].Value != null){
                    invfis.in04estado = info.Cells["in04estado"].Value.ToString();
                }


                string mensajeRetorno = string.Empty;
                int flagok = 0;

                InventarioFisicoLogic.Instance.InventarioFisicoUpd(invfis, out flagok, out mensajeRetorno);

                if (flagok == -1)
                {
                    RadMessageBox.Show("Actualizar Stock Fisico", mensajeRetorno, MessageBoxButtons.OK, RadMessageIcon.Info);
                }

            }
            //RadMessageBox.Show("Grabar Nuevo Registro", "Aviso", MessageBoxButtons.OK, RadMessageIcon.Info);
            catch (Exception ex)
            {

                Util.ShowError("Error al guardar detalle:" + ex.Message);
            }
        }

        private void gridControlDet_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {

            try
            {
                if (e.Column.Name == "IN04CANTFISICA" || e.Column.Name == "in04observacion")
                {
                    if (Estado == FormEstate.Edit)
                    {
                        e.Cancel = false;

                    }
                    else if (Estado == FormEstate.New || Estado == FormEstate.List || Estado == FormEstate.View)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex) {
                Util.ShowError("Error al iniciar edicion:" + ex.Message);
            }
            
            
        }

        private void gridControlDet_CellValidating(object sender, CellValidatingEventArgs e)
        {
            try
            {
                if (e.Column.Name == "IN04CANTFISICA")
                {
                    double numero;

                    if (Double.TryParse(e.Value.ToString(), out  numero) == false)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex) {
                Util.ShowError("Error al validar valor ingresado a celda: " + ex.Message);
            }
            
        }
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {

            frmBusqueda frm;
            string codigoSeleccionado = string.Empty;
            switch (tipoAyuda) { 
                case enmAyuda.enmEstadoInventarioFisico:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.Owner = this;
                    frm.ShowDialog();
                    if(frm.Result != null)
                    {
                        //codigoSeleccionado = 
                            string[]  valores = frm.Result.ToString().Split('|');

                        Util.SetValueCurrentCellText(gridControlDet.CurrentRow, "in04estado",valores[0]);
                        Util.SetValueCurrentCellText(gridControlDet.CurrentRow, "estadoinventariodesc", valores[1]);
                    }

                    break;
                default: break;
            }
            
        }
        private void gridControlDet_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (Util.IsCurrentColumn(gridControlDet, "in04estado") || Util.IsCurrentColumn(gridControlDet, "estadoinventariodesc"))
            {
                if (Estado == FormEstate.Edit) {
                    if (e.KeyCode == Keys.F1)
                    {
                        MostrarAyuda(enmAyuda.enmEstadoInventarioFisico);
                    }
                }
                
                    
            }
        }

        private void gridControlDet_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                //columna estado inventario
                if (Util.IsCurrentColumn(gridControlDet, "estadoinventariodesc")
                    || Util.IsCurrentColumn(gridControlDet, "in04estado"))
                {
                    GuardarDetalle(gridControlDet.CurrentRow);
                }
            }
            catch (Exception ex) {
                Util.ShowError("Error en evento cellvalue changed:");
            }
            
        }

        private void btnImportarInventario_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = "";
                //abrir archivo
                OpenFileDialog opf = new OpenFileDialog();
                var fic = "";
                var filename = "";
                //abre el Dialog en la carpeta que desees 
                opf.InitialDirectory = descripcion;
                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    fic = opf.FileName;
                    filename = opf.SafeFileName;
                }
                else return;
                var StreamReader = new System.IO.StreamReader(fic, Encoding.Default);
                string msj = string.Empty;
                
                int contador = 0;  // Contador de líneas
                using (var reader = new StreamReader(fic, Encoding.Default))
                {
                    

                    // Leer el archivo línea por línea
                    while (reader.ReadLine() != null)
                    {
                        contador++;  // Incrementamos el contador por cada línea
                    }
                    
                    // Mostrar el número de líneas
                    //Console.WriteLine($"El archivo tiene {lineCount} líneas.");
                 }
                //iniciar el arreglo 
                string[] registros = new string[contador];
                int x = 0;
                while (!StreamReader.EndOfStream) 
                {
                    //string[] linea = StreamReader.ReadLine().Split('|');
                    //string codigoproducto = string.IsNullOrEmpty(linea[0]) ? "" : linea[0];
                    //string cantidad = string.IsNullOrEmpty(linea[1]) ? "": linea[1];
                    //string estado = string.IsNullOrEmpty(linea[2]) ? "":linea[2];
                    //string observacion = string.IsNullOrEmpty(linea[3]) ? "": linea[3];
                    

                    registros[x] = StreamReader.ReadLine();
                        x++;
                    

                    //contador = contador + 1;
                    //insertar en xml 
                }
                string xmldinamico =  Util.ConvertiraXMLdinamico(registros);
                //Console.WriteLine(xmldinamico);

                string fechaInventario = Util.GetCurrentCellText(gridControl, "IN04FECINV");
                string codigoAlmacen = Util.GetCurrentCellText(gridControl, "IN04CODALM");
                int flag = 0;
                string mensaje = "";
                InventarioFisicoLogic.Instance.ActualizarInventarioMasivo(Logueo.CodigoEmpresa,
                    Logueo.Anio, fechaInventario, codigoAlmacen, xmldinamico, out flag, out mensaje);

                if(flag == 1){
                    Util.ShowMessage("Importacion correcta",1);

                    OnBuscarDet();
                }else{
                    Util.ShowError("Fallo importacion: " + mensaje);
                    
                }


            }
            catch (Exception ex) {
                Util.ShowError("Error al importar: " + ex.Message);
            }
        }

        private void btnImportarInventarioMasivo_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = "";
                //abrir archivo
                OpenFileDialog opf = new OpenFileDialog();
                var fic = "";
                var filename = "";
                //abre el Dialog en la carpeta que desees 
                opf.InitialDirectory = descripcion;
                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    fic = opf.FileName;
                    filename = opf.SafeFileName;
                }
                else return;
                var StreamReader = new System.IO.StreamReader(fic, Encoding.Default);
                string msj = string.Empty;

                int contador = 0;  // Contador de líneas
                using (var reader = new StreamReader(fic, Encoding.Default))
                {


                    // Leer el archivo línea por línea
                    while (reader.ReadLine() != null)
                    {
                        contador++;  // Incrementamos el contador por cada línea
                    }

                    // Mostrar el número de líneas
                    //Console.WriteLine($"El archivo tiene {lineCount} líneas.");
                }
                //iniciar el arreglo 
                string[] registros = new string[contador];
                int x = 0;
                while (!StreamReader.EndOfStream)
                {
                    //string[] linea = StreamReader.ReadLine().Split('|');
                    //string codigoproducto = string.IsNullOrEmpty(linea[0]) ? "" : linea[0];
                    //string cantidad = string.IsNullOrEmpty(linea[1]) ? "": linea[1];
                    //string estado = string.IsNullOrEmpty(linea[2]) ? "":linea[2];
                    //string observacion = string.IsNullOrEmpty(linea[3]) ? "": linea[3];


                    registros[x] = StreamReader.ReadLine();
                    x++;


                    //contador = contador + 1;
                    //insertar en xml 
                }
                string xmldinamico = Util.ConvertiraXMLdinamico(registros);
                //Console.WriteLine(xmldinamico);

                string fechaInventario = Util.GetCurrentCellText(gridControl, "IN04FECINV");
                string codigoAlmacen = Util.GetCurrentCellText(gridControl, "IN04CODALM");
                int flag = 0;
                string mensaje = "";
                InventarioFisicoLogic.Instance.ActualizarInventarioMasivo(Logueo.CodigoEmpresa,
                    Logueo.Anio, fechaInventario, codigoAlmacen, xmldinamico, out flag, out mensaje);

                if (flag == 1)
                {
                    Util.ShowMessage("Importacion correcta", 1);

                    OnBuscarDet();
                }
                else
                {
                    Util.ShowError("Fallo importacion: " + mensaje);

                }


            }
            catch (Exception ex)
            {
                Util.ShowError("Error al importar: " + ex.Message);
            }
        }
   }
}