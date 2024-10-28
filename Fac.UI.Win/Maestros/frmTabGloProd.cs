using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessEntities;
using Inv.BusinessLogic;

namespace Fac.UI.Win
{
    public partial class frmTabGloProd : frmBaseMante
    {
        #region "Instancia"
        private static frmTabGloProd _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmTabGloProd Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmTabGloProd(formParent);
            _aForm = new frmTabGloProd(formParent);
            return _aForm;
        }
        #endregion
        private bool nuevo_a, editar_a, eliminar_a, ver_a, imprimir_a, refrescar_a, importar_a, vista_a, guardar_a,
            cancelar_a, expmovi_a, importarMP;

        #region "Seguridad"
        private void accesobotonesperfil()
        {
            SegMenuPorPerfilLogic.Instance.asiganrpermisosxbotones(Logueo.codigoPerfil, Logueo.CodModulo,
            this.Name, out nuevo_a, out editar_a, out eliminar_a, out ver_a, out imprimir_a,
            out refrescar_a, out importar_a, out vista_a, out guardar_a, out cancelar_a,
            out expmovi_a, out importarMP);
        }
        private void ComportarmientoBotones(string accion)
        {
            OcultarBotones();
            
            switch (accion)
            {
                case "cargar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    if (ver_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbVer); }
                    break;

                case "nuevo":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "editar":
                    if (guardar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar); }
                    if (cancelar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar); }
                    break;

                case "grabar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar); }
                    break;

                case "cancelar":
                    if (nuevo_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo); }
                    if (editar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    if (eliminar_a == true) { HabilitaBotonPorNombre(BaseRegBotones.cbbEditar); }
                    break;
            }

        }
        #endregion

        private bool isLoaded = false;
        ProductoCaracteristicasLogic datos = ProductoCaracteristicasLogic.Instance;
        public frmTabGloProd(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            Mostrarcodformato(false);
            OnBuscar();
            habilitarBotones(true, false);
            Habilitar(false);
            Estado = FormEstate.List;
            this.gridCaracteristica.CurrentRowChanged += new CurrentRowChangedEventHandler(gridCaracteristica_CurrentRowChanged);
            this.gridCaracteristicaDet.CurrentRowChanged += new CurrentRowChangedEventHandler(gridCaracteristicaDet_CurrentRowChanged);
        }

        

        void gridCaracteristica_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                string codigotabla = "";
                var row = e.CurrentRow.Cells;
                if (!isLoaded) return;

                if (gridCaracteristica.Rows.Count == 0) return;
                if (e.CurrentRow != null)
                {
                    if (Util.GetCurrentCellText(gridCaracteristica, "codigotabla") != "")
                    {
                        codigotabla = Util.GetCurrentCellText(gridCaracteristica, "codigotabla");
                        OnBuscarDet(codigotabla);
                    }
                }
            }
            catch (Exception ex)
            { 
                
            }
            CargarDetalleDeCaracteristicas();
        }
        void gridCaracteristicaDet_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                string codigotabla = string.Empty;
                string codigo = string.Empty;
                var row = e.CurrentRow.Cells;

                //  Si no ha cargado la pantalla por complet 
                if (!isLoaded) return;

                if (e.CurrentRow.Cells != null)
                {
                    if (e.CurrentRow.Cells["codigotabla"].Value != null)
                    {
                        codigo = e.CurrentRow.Cells["codigo"].Value.ToString();
                        codigotabla = e.CurrentRow.Cells["codigotabla"].Value.ToString();
                        CargarDocumento(codigotabla, codigo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(gridCaracteristica);
            this.CreateGridColumn(Grid, "Codigo", "codigotabla", 0, "", 120, true, false, true);
            this.CreateGridColumn(Grid, "Descripcion", "descripcion", 0, "", 220, true, false, true);                        	
        }
        private void CrearColumnasDetalle()
        {
            RadGridView grillaDet = CreateGridVista(gridCaracteristicaDet);
            this.CreateGridColumn(grillaDet, "Codigo Tabla", "codigotabla", 0, "", 30, true, false, true);
            this.CreateGridColumn(grillaDet, "Codigo", "codigo", 0, "", 80, true, false, true);
            this.CreateGridColumn(grillaDet, "Descripcion", "descripcion", 0, "", 200, true, false, true);
            this.CreateGridColumn(grillaDet, "Area Modelo", "glo01area", 0, "", 80, true, false, true);               	
        }
        private void frmTabGloProd_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            CrearColumnasDetalle();
            isLoaded = true;
            BloquearControlesDatos(false);


            
            //txtcodigo.Enabled = false; txtdescripcion.Enabled = false;
            if (gridCaracteristica.IsLoaded)
            {
                if (gridCaracteristica.RowCount > 0) {
                    CargarDetalleDeCaracteristicas();
                    OnBuscarDet(Util.GetCurrentCellText(gridCaracteristica, "codigotabla"));
                }
            }
            gestionarBotones(true, true, true, false, false);
            habilitarBotones(true, false);

            accesobotonesperfil();
            ComportarmientoBotones("cargar");
        }
        protected override void OnBuscar()
        {
            //base.OnBuscar();
            var lista = ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasTablas("--");
            this.gridCaracteristica.DataSource = lista;
        }
      

        private void CargarDetalleDeCaracteristicas()
        {
            try
            {
                if (gridCaracteristica.IsLoaded)
                {
                    if (gridCaracteristica.RowCount > 0)
                    {

                        string TablaCodigo = Util.GetCurrentCellText(gridCaracteristica, "codigotabla");
                        string registroCodigo = Util.GetCurrentCellText(gridCaracteristica, "codigo");
                        List<ArticuloCaracteristicas> listaDatos = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(TablaCodigo);

                        this.gridCaracteristicaDet.DataSource = listaDatos;

                        //leer los datos de la grilla pra mostrar en als cajas de texto.

                        ArticuloCaracteristicas registroSeleccioando = ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasRegistro(TablaCodigo, registroCodigo);
                        if (registroSeleccioando != null)
                        {
                            this.txtcodigo.Text = registroSeleccioando.codigo;
                            this.txtdescripcion.Text = registroSeleccioando.descripcion;
                            this.txtarea.Text = Convert.ToString(registroSeleccioando.glo01area);
                            this.txtAbreviatura.Text = registroSeleccioando.glo01descripcionAbreviada;
                            if (TablaCodigo == Constantes.ProTerCarateristicas.formato)
                            {
                                txtancho.Text = registroSeleccioando.codigo.Substring(0, 3);
                                txtlargo.Text = registroSeleccioando.codigo.Substring(3, 3);
                                txtespesor.Text = registroSeleccioando.codigo.Substring(6, 3);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar detalle de caracteristicas: " + ex.Message);
            }
            

        }
       
        void HabilitarGrillas(bool valor)
        {
            gridCaracteristica.Enabled = valor;
            gridCaracteristicaDet.Enabled = valor;
        }
        
        
        
        private void OnBuscarDet(string codigoTabla)
        {
            try
            {
                var lista = ArticuloCaracteristicasLogic.Instance.TraerArticuloCaracteristicas(codigoTabla);
                this.gridCaracteristicaDet.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Errpr al buscar detalle: " + ex.Message);
            }
        }
        private void Habilitar(bool estado)
        {
            this.txtcodigo.Enabled = estado;
            this.txtdescripcion.Enabled = estado;
            this.txtAbreviatura.Enabled = estado;
        }
        private void BloquearControlesDatos(bool valor)
        {
            txtcodigo.Enabled = valor;
            txtdescripcion.Enabled = valor;
            txtarea.Enabled = valor;
            txtAbreviatura.Enabled = valor;
            //Para el formato
            Mostrarcodformato(false);
        }
        private void Mostrarcodformato(bool valor)
        {
            //Para el formato
            //txtlargo.Visible = valor;
            //txtancho.Visible = valor;
            //txtespesor.Visible = valor;
            rpFormato.Visible = valor;
            //txtcodigo.Enabled = !valor;
        }
        private void LimpiarControlesDatos()
        {
            txtcodigo.Text = "";
            txtdescripcion.Text = "";
            txtlargo.Text = "";
            txtancho.Text = "";
            txtespesor.Text = "";
            txtarea.Text = "";
            txtAbreviatura.Text = "";
        }
        private void CargarDocumento(string codigotabla, string codigo)
        {
            try
            {
                //Carga el documento y su detalle
                var articulocaracteristicas = ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasRegistro(codigotabla, codigo);

                if (articulocaracteristicas.codigo != null)
                {
                    this.txtcodigo.Text = articulocaracteristicas.codigo;
                    this.txtdescripcion.Text = articulocaracteristicas.descripcion;
                    this.txtarea.Text = Convert.ToString(articulocaracteristicas.glo01area);
                    this.txtAbreviatura.Text = articulocaracteristicas.glo01descripcionAbreviada;
                    // Si tiene codigo de formato separa las medidas del formato 
                    if (codigotabla == Constantes.ProTerCarateristicas.formato)
                    {
                        txtancho.Text = articulocaracteristicas.codigo.Substring(0, 3);
                        txtlargo.Text = articulocaracteristicas.codigo.Substring(3, 3);
                        txtespesor.Text = articulocaracteristicas.codigo.Substring(6, 3);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error cargar documento: " + ex.Message);
            }
        }
        protected override void OnNuevo()
        {
            this.Estado = FormEstate.New;
            BloquearControlesDatos(true);
            LimpiarControlesDatos();

            if (gridCaracteristica.RowCount>0)
                {
                    if (this.gridCaracteristica.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.formato)
                    {
                        Mostrarcodformato(true);
                    }
                    else
                    {
                        Mostrarcodformato(false);
                    }
                }

            if (gridCaracteristica.RowCount>0)
                {
            if (this.gridCaracteristica.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.modelo)
            {
                txtarea.Enabled = true;
            }
            else
            {
                txtarea.Enabled = false;
            }
            }

            gestionarBotones(false, false, false, true, true);
            habilitarBotones(false, true);
            //HabilitarGrillas(false);
            txtcodigo.Focus();

            //Estado = FormEstate.New;
        }

        protected override void OnEditar()
        {
            if (this.gridCaracteristica.RowCount == 0) return;
                        
            Estado = FormEstate.Edit;
            BloquearControlesDatos(true);

            txtcodigo.Enabled = false;

            if (this.gridCaracteristica.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.modelo)
            {
                txtarea.Enabled = true;
            }
            else
            {
                txtarea.Enabled = false;
            }
            if (this.gridCaracteristica.CurrentRow.Cells["codigotabla"].Value.ToString() == Constantes.ProTerCarateristicas.formato)
            {
                Mostrarcodformato(true);
            }
            //txtcodigo.Enabled = false;
            //txtdescripcion.Enabled = true;
            gestionarBotones(false, false, false, true, true);
            habilitarBotones(false, true);
            //HabilitarGrillas(false);
            
        }

        protected override void OnEliminar()
        {
            if (this.gridCaracteristicaDet.RowCount == 0) return;
            try
            {
                

                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                                                              
                if (respuesta == false) return;
                int int_flag = 0;
                string str_mensaje = "", TablaCodigo = "", CaracteristicaCodigo = "";

                //datos.EliminarCaracteristica(TablaCodigo, CaracteristicaCodigo, out int_flag, out str_mensaje);
                TablaCodigo = Util.GetCurrentCellText(gridCaracteristica, "codigotabla");
                CaracteristicaCodigo = Util.GetCurrentCellText(gridCaracteristicaDet, "codigo");

                ArticuloCaracteristicas articuloCaract = new ArticuloCaracteristicas();
                articuloCaract.codigotabla = TablaCodigo;
                articuloCaract.codigo = CaracteristicaCodigo;

                ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasEliminar(articuloCaract, 
                                                                       out int_flag, out str_mensaje);

                Util.ShowMessage(str_mensaje, int_flag);
                if (int_flag == 1)
                    CargarDetalleDeCaracteristicas();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar : " + ex.Message);
            }
            OnCancelar();
        }
        private bool Validar()
        {
            if (txtcodigo.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar codigo.");
                this.txtcodigo.Focus();
                return false;
            }
            if (txtdescripcion.Text.Trim() == "")
            {
                Util.ShowAlert("Ingresar descripcion.");
                this.txtdescripcion.Focus();
                return false;
            }
            return true;
        }
        protected override void OnGuardar()
        {
            double areamodelo = 0;
            try
            {

                if (!Validar()) return;
                int int_flag = 0, Caracteristicalong = 0;
                string str_mensaje = "", TablaCodigo = "", CaracteristicaCodigo = "";
                string CaracteristicaDesc = "", CaracteristicaTexto1 = "";
                string CaracteristicaComentario = "";
                
                 TablaCodigo = Util.GetCurrentCellText(gridCaracteristica, "codigotabla");
                 CaracteristicaCodigo = txtcodigo.Text.Trim();
                 CaracteristicaDesc = txtdescripcion.Text.Trim();
                                                
                
                
                ArticuloCaracteristicas articulocaracteristicas = new ArticuloCaracteristicas();

                if (Util.GetCurrentCellText(gridCaracteristica, "codigotabla") == Constantes.ProTerCarateristicas.modelo)
                {
                    areamodelo = Convert.ToDouble(txtarea.Text.Trim());
                }

                articulocaracteristicas.codigotabla = this.gridCaracteristica.CurrentRow.Cells["codigotabla"].Value.ToString();
                articulocaracteristicas.codigo = txtcodigo.Text;
                articulocaracteristicas.descripcion = txtdescripcion.Text;
                articulocaracteristicas.glo01area = areamodelo;
                articulocaracteristicas.glo01descripcionAbreviada = txtAbreviatura.Text.Trim();
                articulocaracteristicas.glo01altoUnimed = txtespesor.Text;
                articulocaracteristicas.glo01anchoUnimed = txtancho.Text;
                articulocaracteristicas.glo01largoUnimed = txtlargo.Text;

                if (Estado == FormEstate.New)
                {                    
                    ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasInsertar(articulocaracteristicas,
                        out int_flag, out str_mensaje);

                }
                else if (Estado == FormEstate.Edit)
                {                 
                    ArticuloCaracteristicasLogic.Instance.ArticuloCaracteristicasModificar(articulocaracteristicas,
                        out int_flag, out str_mensaje);
                }

                Util.ShowMessage(str_mensaje, int_flag);

                if (int_flag == 1)
                {
                    CargarDetalleDeCaracteristicas();
                }

                OnCancelar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar: " + ex.Message);
            }
        }

        protected override void OnCancelar()
        {
            Estado = FormEstate.List;
            if (gridCaracteristica.IsLoaded)
            {
                if (gridCaracteristica.RowCount > 0)
                {
                    OnBuscarDet(Util.GetCurrentCellText(gridCaracteristica, "codigotabla"));
                }
            }
            Habilitar(false);            
            gestionarBotones(true, true, true, false, false);
            habilitarBotones(true, false);
            BloquearControlesDatos(false);
            Mostrarcodformato(false);
            txtancho.Text = "";
            txtespesor.Text = "";
            txtlargo.Text = "";
            //HabilitarGrillas(false);
        }

        private void productoterminadoarmarcodigoformato()
        {
            try
            {
                this.txtcodigo.Text = txtancho.Text + txtlargo.Text + txtespesor.Text;

                var articulo = ArticuloLogic.Instance.ProterDescripcionFormato(txtcodigo.Text);

                if (articulo != null)
                {
                    this.txtdescripcion.Text = articulo.IN01DESLAR;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al armar codigo: " + ex.Message);
            }
        }

        private void txtancho_TextChanged(object sender, EventArgs e)
        {
            this.productoterminadoarmarcodigoformato();
        }        
        private void txtlargo_TextChanged(object sender, EventArgs e)
        {
            this.productoterminadoarmarcodigoformato();
        }
        private void txtespesor_TextChanged(object sender, EventArgs e)
        {
            this.productoterminadoarmarcodigoformato();
        }


        private void txtancho_KeyDown(object sender, KeyEventArgs e)
        {
            
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmAncho);
        }
        private void txtlargo_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmLargo);
        }        
        private void txtespesor_KeyDown(object sender, KeyEventArgs e)
        {
            Util.SendTab(e.KeyCode.GetHashCode());
            if (e.KeyCode == Keys.F1) this.MostrarAyuda(enmAyuda.enmEspesor);
        }

        private void gridCaracteristica_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (Estado == FormEstate.List) return;
            if (Estado == FormEstate.Edit || Estado == FormEstate.New)
            {
                Util.ShowAlert("Debe terminar el proceso actual");
                e.Cancel = true;
            }
        }

        private void gridCaracteristicaDet_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            if (Estado == FormEstate.List) return;
            if (Estado == FormEstate.New)
            {
                Util.ShowAlert("Debe terminar el proceso actual");
                e.Cancel = true;
            }
        }
        private void MostrarAyuda(enmAyuda tipoAyuda)
        {
            frmBusqueda frm = new frmBusqueda(tipoAyuda);
            string codigoSeleccionado = string.Empty;
            try
            {


                switch (tipoAyuda)
                {
                    case enmAyuda.enmLargo:
                        frm.Owner = this;
                        frm.ShowDialog();
                        if (frm.Result != null)
                            codigoSeleccionado = frm.Result.ToString();

                        if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtlargo.Text = codigoSeleccionado;

                        break;

                    case enmAyuda.enmAncho:
                        frm.Owner = this;
                        frm.ShowDialog();
                        if (frm.Result != null)
                            codigoSeleccionado = frm.Result.ToString();

                        if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtancho.Text = codigoSeleccionado;

                        break;
                    case enmAyuda.enmEspesor:
                        frm.Owner = this;
                        frm.ShowDialog();
                        if (frm.Result != null)
                            codigoSeleccionado = frm.Result.ToString();

                        if (!string.IsNullOrEmpty(codigoSeleccionado)) this.txtespesor.Text = codigoSeleccionado;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer ayuda: " + ex.Message);
            }
        }
    }
}
