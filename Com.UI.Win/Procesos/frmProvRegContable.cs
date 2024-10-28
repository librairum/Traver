using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
using  Com.UI.Win.Procesos;
using Telerik.WinControls.UI.Docking;
namespace Com.UI.Win
{
    public partial class frmProvFactRegContable : frmBaseMante
    {
        #region "Instancia"
        private static frmProvFactRegContable _aForm;
        #region "Instanci de Provision factura con Orden COmpra"
        private frmProvFacturaDetOC FrmParentConOC { get; set; }
        public static frmProvFactRegContable Instance(frmProvFacturaDetOC padre)
        {
            if (_aForm != null) return new frmProvFactRegContable(padre);
            _aForm = new frmProvFactRegContable(padre);
            return _aForm;        
        }
        #endregion

        #region "Provision de factura sin orden compra"
        private frmProvFacturaDetSinOC FrmParentSinOC { get; set; }
        public static frmProvFactRegContable Instance(frmProvFacturaDetSinOC padre)
        {
            if (_aForm != null) return new frmProvFactRegContable(padre);
            _aForm = new frmProvFactRegContable(padre);
            return _aForm;
        }
        #endregion


        #endregion
        bool esCarga = false, esSeleccion = false;
        double saldoSoles = 0, saldoDolares = 0, Impuesto = 0;

        internal bool seleccionaFilaaEditar = false;
        internal string FechaDocCab;
        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;
            OcultarBotones();
            //HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //HabilitarControles();
                //este metodo sera reemplazado con el evento desde la grilla editarGrilla
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al presionar  editar");
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnEliminar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
              

                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (respuesta == true)
                {
                    string mes = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.mesProvision : FrmParentSinOC.mesProvision;
                    string numeroOrden = Util.GetCurrentCellText(this.gridControl.CurrentRow, "orden");
                    int flag = 0; string mensaje = "";

                    LogicaVoucher.EliminaDetalle(Logueo.CodigoEmpresa, Logueo.Anio, mes, lblLibro.Text,
                        lblNroVoucher.Text, Convert.ToDouble(numeroOrden), out flag, out mensaje);

                    Util.ShowMessage(mensaje, flag);

                    if (flag == 1)
                    {
                        CargarDetalleRegistroContable(lblLibro.Text, lblNroVoucher.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al presionar  editar");
            }
            Cursor.Current = Cursors.Default;
        }



        internal string LeerMes()
        {
            string valor = "";
            valor = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.mesProvision : FrmParentSinOC.mesProvision;
            return valor;
        }
        internal string LeerLibro()
        {
            string valor = "";
            valor = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.libro : FrmParentSinOC.libro;
            return valor;
        }
        /// <summary>
        /// Retorno el valor de numero voucher dependiendo de la instancia del formuario,
        /// los valores declarados son publicos y declarado en el formulario.
        /// </summary>
        /// <returns></returns>
        internal string LeerNroVoucher()
        {
            string valor = "";
            valor = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.nroVoucher : FrmParentSinOC.nroVoucher;
            return valor;
        }
        /// <summary>
        /// Metodo para retornar el valor de una variable declarado como publico en el formulario.
        /// El formulario puede Provision con OC y Provision sin OC
        /// </summary>
        /// <returns></returns>
        internal string LeerAsientoTipo()
        {
            string valor = "";
            valor = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.asientoTipo : FrmParentSinOC.asientoTipo;
            return valor;
        }

        
        private double  Redondear(double numero, int cantidadDecimales) { 
            string valorNumero = "";
            valorNumero = numero.ToString();

            decimal numeroRedondeado = 0;
            
             numeroRedondeado =  decimal.Round(Convert.ToDecimal(valorNumero), cantidadDecimales);            
                
             return double.Parse(numeroRedondeado.ToString());
        }
        private void CalcularEquivalentes()
        {
            GridViewRowInfo fila = gridControl.CurrentRow;
            
            //lee el tipo de moneda de la cuenta contable detalle
            string tipoMoneda = LeerTipoMoneda(fila);
            //lee el tipo de moneda desde el inicio de sesion del programa
            string BiMoneda = Logueo.BiMoneda;
            double tipoCambio = LeerTipoCambio(fila);
            double montoDebeEquiv = 0, montoDebe = 0;
            double montoHaberEquiv = 0, montoHaber = 0;
            
            //refrescar la variable BiMoneda , en caso cambio de Periodo
            string codigoBiMoneda = Logueo.CodigoEmpresa+"|"+Logueo.Anio+"|"+ Logueo.nombreModulo;
            string valorBiMoneda = "";
            GlobalLogic.Instance.DameDescripcion(codigoBiMoneda, "BIMONEDA", out valorBiMoneda);

            try
            {
                //los valores de haber y debe debe ser 2 decimales
                
                montoDebe = LeerMontoDebe(fila); montoDebeEquiv = LeerMontoDebe(fila,true);
                montoHaber = LeerMontoHaber(fila); montoHaberEquiv = LeerMontoHaber(fila,true);
                //valido la moneda del formulario registro contable
                if (tipoMoneda == "S")
                {
                    //valido la moneda de la variable global
                    if (BiMoneda == "S")
                    {
                        //valido el valor de celda tipo de campo de la grilla
                        if (tipoCambio > 0)
                        {
                            montoDebeEquiv = Redondear((montoDebe / tipoCambio), 2);
                            montoHaberEquiv = Redondear((montoHaber / tipoCambio), 2);
                            Util.SetValueCurrentCellDbl(fila, "ImporteHaberEquivalencia", montoHaberEquiv);
                            Util.SetValueCurrentCellDbl(fila, "ImporteDebeEquivalencia", montoDebeEquiv);

                        }
                        else
                        {
                            montoDebeEquiv = 0; montoHaberEquiv = 0;
                            //asignar el valor de los montos equivalente deber y haber a los controles.
                            Util.SetValueCurrentCellDbl(fila, "ImporteHaberEquivalencia", montoHaberEquiv);
                            Util.SetValueCurrentCellDbl(fila, "ImporteDebeEquivalencia", montoDebeEquiv);
                        }

                        
                    }
                    else
                    {
                        montoDebeEquiv = 0; montoHaberEquiv = 0;
                        Util.SetValueCurrentCellDbl(fila, "ImporteDebeEquivalencia", montoDebeEquiv);
                        Util.SetValueCurrentCellDbl(fila, "ImporteHaberEquivalencia", montoHaberEquiv);
                    }
                }
                else {
                    //Si mi tipo de moneda en la actual es dolares, entocnes:
                    //calculo el valor de dolares en soles , 
                    
                    //inicio mis variables de importes soles
                    montoDebe = 0; montoHaber = 0;
                    //para luego asignar a sus respectivas celda de soles
                    montoDebe = montoDebeEquiv * tipoCambio;
                    montoHaber = montoHaberEquiv * tipoCambio;
                    //convertir a 2 decimales
                    Util.SetValueCurrentCellDbl(fila, "ImporteDebe", montoDebe);
                    Util.SetValueCurrentCellDbl(fila, "ImporteHaber", montoHaber);
                }
            }
            catch (Exception ex) {
                Util.ShowError("Error al calcular equivalentes");
            }
        }
        public frmProvFactRegContable(frmProvFacturaDetOC padre)
        {
            InitializeComponent();

            FrmParentConOC = padre;
            Util.ConfigGridToEnterNavigation(gridControl);
            OcultarBotones();
        }
        public frmProvFactRegContable(frmProvFacturaDetSinOC padre) {
            InitializeComponent();
            FrmParentSinOC = padre;
            Util.ConfigGridToEnterNavigation(gridControl);
        }
        
        private void cancelarGrilla() {
            OnBuscar();
        }
        
        private void CrearColumnas()
        {
            RadGridView Grid =  CreateGridVista(gridControl);

            Grid.EnableFiltering = false;
            //CreateGridColumn(Grid, "Origen", "Amarre", 0, "", 60, true, false, true);// origen de la cuenta contable
            CreateGridColumn(Grid, "flag", "flag", 0, "", 60, true, false, false, false);
            CreateGridColumn(Grid, "Ord", "orden", 0, "", 60,true,false,false); //Orden dle item detalle Voucher
            //agrega los botones de eliminar y editar
            agregarBoton();
            CreateGridColumn(Grid, "Tip", "Amarre", 0, "", 30, true, false, true); //amarre indica el origen de la cuenta contable
            #region "Cuenta contable"
            //Cuenta contable, caja de texto trae Ayuda - codigo
            CreateGridColumn(Grid, "cuenta", "cuenta", 0, "", 100); //cuenta contable 
            //"DesCuenta"
            //cuenta contable descripcion, caja de texto no editable
            CreateGridColumn(Grid, "cuenta\nDesc", "CtaCbleDesc", 0, "", 120);
            //concepto, caja de texto editable
            CreateGridColumn(Grid, "concepto", "glosa", 0, "", 100, false, true, true);
            #endregion
            
            
            #region "cuenta corriente"
            //codigo, caja de texto no editable trae ayuda
            //descripcion, caja de texto no editable
            CreateGridColumn(Grid, "CuentaCorriente", "CuentaCorriente", 0, "", 90);
            CreateGridColumn(Grid, "Cuenta\nCorrienteDesc", "CtaCteDesc", 0, "", 120);
            
            #endregion

            #region "igv"
            //caja texto trae ayuda
            //caja texto columna
            //posible valores Afecto, Inafecto y Columna(acepta valor ingresado por usuario)
            CreateGridColumn(Grid, "Col\nReg", "Afecto", 0, "", 30, false, true, true);
            
            #endregion

            #region "moneda"
            //caja de texto no editable trae ayuda
            //caja de texto no editable descripcion
            CreateGridColumn(Grid, "moneda", "moneda", 0, "", 30);
            CreateGridColumn(Grid, "ValorMoneda", "ValorMoneda", 0, "", 80,true, false, false);
                
            #endregion

            
            #region "tipo documento"
            CreateGridColumn(Grid, "Tip.\nDoc", "TipoDocumento", 0, "", 30);
            CreateGridColumn(Grid, "Tip.Doc\nDesc", "TipDocumentoDescrip", 0, "", 80);            
            CreateGridColumn(Grid, "NumDoc", "NumDoc", 0, "", 90, false, true, true);
            CreateGridDateColumn(Grid, "Fecha\nDoc", "FechaDoc", 0, "{0:dd/MM/yyyy}", 80, false, true, true);            
            CreateGridDateColumn(Grid, "Fecha\nVencimiento", "FechaVencimiento", 0, "{0:dd/MM/yyyy}", 80, false, true, true);
                        
            #endregion

            #region "Tipo cambio"
            CreateGridDecimalColumn(Grid, "T.C", "TipoCambio", 0, "{0:F04}", 40, true, false, true, true, "right");
            //CreateGridColumn(Grid, "T.C", "TipoCambio", 0, "{0:F04}", 40, true, false, true, true, "right");            
            #endregion

            
            //Importes
            //Deber soles            
            //"{0:###,###0.00}"
            CreateGridColumn(Grid, "S/. \nDebe", "ImporteDebe", 0, "{0:#,##0.00}", 60, false, true, true, true, "right");
            //Haber soles            
            CreateGridColumn(Grid, "S/. \nHaber", "ImporteHaber", 0, "{0:#,##0.00}", 60, false, true, true, true, "right");

            //Importes equivalentes            
            //Deber equivalencia dolares
            CreateGridColumn(Grid, "US$ \nCargo", "ImporteDebeEquivalencia", 0, "{0:#,##0.00}", 60, false, true, true, true, "right");
            //Haber equivalencia dolares            
            CreateGridColumn(Grid, "US$ \nAbono", "ImporteHaberEquivalencia", 0, "{0:#,##0.00}", 60, false, true, true, true, "right");


            #region "centro de costo"
            //codigo centro costo, caja texto ayuda
            CreateGridColumn(Grid, "Centro\nCosto", "CenCos", 0, "", 50); // cuenta contable o area de costos (otro nomrbe)            
            //descripcion centro costo, caja de texto no editable
            CreateGridColumn(Grid, "Centro Costo\nDesc.", "CCostoDesc", 0, "", 120);
            #endregion

            #region "centro de gestion"
            CreateGridColumn(Grid, "Gestion", "CenGes", 0, "", 50);
            CreateGridColumn(Grid, "Gestion\nDesc", "CGestionDescripcion", 0, "", 120);
            //codigo , caja de texto no editable
            //descripcion, caja de texto no editable

            #endregion


            //Columnas tipo flag de la tabla cuenta
            CreateGridColumn(Grid, "ccm01ana", "ccm01ana", 0, "", 60, false, true, false);
            CreateGridColumn(Grid, "ccm01cc", "ccm01cc", 0, "", 60, false, true, false);
            CreateGridColumn(Grid, "ccm01cg", "ccm01cg", 0, "", 60, false, true, false);
            CreateGridColumn(Grid, "ccm01ColReg", "ccm01ColReg", 0, "", 60, false, true, false);

            this.gridControl.Columns["btnEliminar"].MinWidth = 30;
            this.gridControl.Columns["btnEditar"].MinWidth = 30;
            
            //agregar suma de columnas
            //string[] columnas = { "debSol", "habSol", "DebDol","HabDol"  };
            string[] columnas = { "ImporteDebe", "ImporteHaber", "ImporteDebeEquivalencia", "ImporteHaberEquivalencia" };
            Util.AddGridSummarySum(gridControl, columnas);

            
            //Grid.CellFormatting += new CellFormattingEventHandler(GrillaMaestra_CellFormatting);
        }
        /// <summary>
        /// Metodo para pintar la celda segun configuracion de Cuenta contable
        /// </summary>
        /// <param name="nombreColumna">Nombre de la columan a evaluar su contenido</param>
        /// <param name="evento">Evento para pintar la celda</param>
        private void PintarCelda(string nombreColumna,  Telerik.WinControls.UI.CellFormattingEventArgs evento) {
            if (evento.Row.Cells[nombreColumna].Value == null) return;
            if (evento.Row.Cells[nombreColumna].Value.ToString() == "" || evento.Row.Cells[nombreColumna].Value.ToString() == "N")
            {
                evento.CellElement.DrawFill = true;
                evento.CellElement.ForeColor = Color.Black;
                evento.CellElement.NumberOfColors = 1;
                evento.CellElement.BackColor = Color.LightGray;    
            }                
                
        }
        #region "evento cellformating"
        ////sobre escribiendo el metodo de evento  cellformating de grilla base
        //private void GrillaMaestra_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        //{
        //    //System.Console.WriteLine("Cell formating maestro");
        //    if (e.CellElement.ColumnInfo is GridViewTextBoxColumn) {
        //        //seleccionamos las columnas que sera formateades segun condicion
        //        switch (e.CellElement.ColumnInfo.Name) {
        //            case ("CuentaCorriente"):                        
        //                     PintarCelda("ccm01ana", e);                         
        //                break;

        //            case "CuentaCorrienteDesc":
        //                    PintarCelda("ccm01ana",e);                        
        //                break;

        //            case "CenCos":                        
        //                    PintarCelda("ccm01cc", e);                        
        //                break;

        //            case "CenCosDesc":                                                
        //                 PintarCelda("ccm01cc", e);                        
        //                break;
                        
        //            case "Gestion":
        //                 PintarCelda("ccm01cg", e);                                                
        //                break;

        //            case "CenGesDesc":                        
        //                    PintarCelda("ccm01cg", e);                                                
        //                break;

        //            //case "Afecto":                        
        //            //        PintarCelda("ccm01ColReg", e);                        
        //            //    break;
                    
        //            default: break;

        //        }
               
        //    }
        //}
        #endregion
        //Leer datos de cabecera de documento
        //Leer los datos a 
        bool formularioCargado = false;
        private void frmProvFactRegContable_Load(object sender, EventArgs e)
        {
            
            
            CrearColumnas();
            if (Logueo.TipoProvision == "C/OC")
            {
                
                //cargar 1
                TraeDatosProvision();
                
                //cargar la grilla
                //se lee los datos de la cabecera
                CargarDetalleRegistroContable(lblLibro.Text, lblNroVoucher.Text);
                
            }
            else { 
                //cargar 2
                TraeDatosProvision();
                //TraeDatosProvSc();
                //se lee los datos del metodos con controles de la cabecera
                CargarDetalleRegistroContable(lblLibro.Text, lblNroVoucher.Text);
                //TraeRegContableSc();
            }
            OcultarBotones();
            

            //Cargar para el archivo de Detalle de Registro Contable (Voucher)
            //if (Logueo.ComprasPeriodoCerrado == "S") { return; }
            //HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            
            //Formatear controles de ingreso

            formularioCargado = true;
        }

   
        public string DameDescripcion(string codigo, string flag)
        { 
            string descripcion = "";
            GlobalLogic.Instance.ComprasDameDescripcion(Logueo.CodigoEmpresa,
                codigo, flag, out descripcion);
            return descripcion;
        }

        
        #region "registro contable"
      
        List<VoucherDetalle> listaVoucherDet = new List<VoucherDetalle>();
        private void TraeRegistroContable(double nroOrdenRegistro)
        {
           listaVoucherDet =  VoucherLogic.Instance.TraeDetalleVoucher(Logueo.CodigoEmpresa,
           Logueo.anioDocumento, Logueo.mesProvivision, Logueo.codigoLibro, Logueo.nroVoucher, nroOrdenRegistro);

        }
        public string tipoDocumento = "", nroDocumento = "",
        fechaDocumento = "", fechaVencimiento = "", libro = "",
        nroVoucher = "", tipoMoneda = "", tipoCambio = "",
        porcentajeIgv = "", importeAfecto = "", importeInafecto = "",
        importeIgv = "", importeDocumento = "", concepto = "";
        
        private void TraeDatosProvision() {
            try
            {
                GridViewRowInfo fila = Logueo.gridProvFactura.MasterView.CurrentRow;                
                
                ////traer descripcion de proveedor               
                lblTipDoc.Text =  Logueo.TipoProvision == "C/OC"? FrmParentConOC.tipoDocumento : FrmParentSinOC.tipoDocumento;
                tipoDocumento = lblTipDoc.Text;

                lblNroDocumento.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.nroDocumento : FrmParentSinOC.nroDocumento;
                FechaDocCab = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.fechaDocumento : FrmParentSinOC.fechaDocumento;
                lblFecDoc.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.fechaDocumento : FrmParentSinOC.fechaDocumento;
                lblFecVen.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.fechaVencimiento : FrmParentSinOC.fechaVencimiento;
                lblLibro.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.libro : FrmParentSinOC.libro;
                lblNroVoucher.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.nroVoucher : FrmParentSinOC.nroVoucher;
                lblMoneda.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.tipoMoneda : FrmParentSinOC.tipoMoneda;
                lblTipCambio.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.tipoCambio : FrmParentSinOC.tipoCambio;
                lblPorIgv.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.porcentajeIgv : FrmParentSinOC.porcentajeIgv;         
                lblImporteAfecto.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.importeAfecto : FrmParentSinOC.importeAfecto;
                lblImporteInafecto.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.importeInafecto :FrmParentSinOC.importeInafecto;                
                lblImporteIgv.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.importeIgv : FrmParentSinOC.importeIgv;                
                lblImporteDocumento.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.importeDocumento : FrmParentSinOC.importeDocumento;
                lblglosa.Text = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.concepto : FrmParentSinOC.concepto;

         
            }
            catch (Exception ex) {
                Util.ShowError("Error al traer datos de provision");
            }
        }
        private void TraeDatosProvSc()
        {         
        //Trae datos de proveedor        
            GridViewRowInfo fila = Logueo.gridProvFactura.MasterView.CurrentRow;        
            lblTipDoc.Text = Util.GetCurrentCellText(fila, "TipoDocumento");
            lblNroDocumento.Text = Util.GetCurrentCellText(fila, "NumeroDocumento");
            lblFecDoc.Text = Util.GetCurrentCellText(fila, "Fecha");
            lblFecVen.Text = Util.GetCurrentCellText(fila, "FechaVencimiento");
            lblLibro.Text = Util.GetCurrentCellText(fila, "Libro");
            lblNroVoucher.Text = Util.GetCurrentCellText(fila, "Voucher");
            lblMoneda.Text = Util.GetCurrentCellText(fila, "TipoMoneda") == "D" ? "DOLARES" : "SOLES";
            lblTipCambio.Text = Util.GetCurrentCellText(fila, "TipoCambio");
            lblPorIgv.Text = Util.GetCurrentCellText(fila, "PorIgv");
            lblImporteAfecto.Text = Util.GetCurrentCellText(fila, "ImpBruto");
            lblImporteInafecto.Text = Util.GetCurrentCellText(fila, "ImpIna");
            lblImporteIgv.Text = Util.GetCurrentCellText(fila, "ImpIgv");
            lblImporteDocumento.Text = Util.GetCurrentCellText(fila, "Importe");

            //double spnSDebe = 0, spnSHaber = 0, spnUsCargo = 0, spnUsAbono = 0;
            //VoucherLogic.Instance.TraeDameTotalVoucher(Logueo.CodigoEmpresa, 
            //    Logueo.anioDocumento, Logueo.mesProvivision, Logueo.codigoLibro, 
            //    Logueo.nroVoucher, out spnSDebe, 
            //    out spnSHaber, out spnUsCargo, 
            //    out spnUsAbono);
            
        }
        List<VoucherDetalle> listaDetalle = new List<VoucherDetalle>();
        private void TraeRegContableSc() { 
             GridViewRowInfo fila = Logueo.gridProvFactura.MasterView.CurrentRow;
            string anio =  Util.GetCurrentCellText(fila, "Anio");
            string mes = Util.GetCurrentCellText(fila, "Mes");
            double nroOrden = Util.GetCurrentCellDbl(gridControl.CurrentRow, "ccd01ord");
            listaDetalle = VoucherLogic.Instance.TraeDetalleVoucher(Logueo.CodigoEmpresa,
                            anio, mes, Logueo.codigoLibro, Logueo.nroVoucher, nroOrden);
            
        }
     
        VoucherLogic LogicaVoucher = VoucherLogic.Instance;
        internal string mes, anio;
        /// <summary>
        /// Metodo para asignar datos a la grilla de Detalle Registro Contable
        /// </summary>
        /// <param name="codigoLibro">Libro contable</param>
        /// <param name="nroVoucher">Voucher del registro Provision factura</param>
        /// <param name="itemRegistro">Si Valor es '0' trae todo los registros  sino trae el registro por numero de orden</param>
        internal void CargarDetalleRegistroContable(string codigoLibro, string nroVoucher, double itemRegistro = 0)
        {
            try
            {
                
                string mes = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.mesProvision : FrmParentSinOC.mesFactura;
                string anio = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.anioOrdenCompra : FrmParentSinOC.anioFactura;
                //Cargo los detalle de voucher generado
                List<VoucherDetalle> lista = LogicaVoucher.TraeDetalleVoucherCab(Logueo.CodigoEmpresa,
                                            anio, mes, codigoLibro, nroVoucher); // 0

                this.gridControl.DataSource = lista;
                //LeerFlagActivacion();

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar detalle registro contable");
            }
        }


        internal double LeerNumeroRegistro() {
            return 0;
        }
        internal string LeerMesPorTipoProvision() {
            return Logueo.TipoProvision == "C/OC" ? FrmParentConOC.mesProvision : FrmParentSinOC.mesFactura;
        }


        internal string LeerAnioPorTipoProvision() {
            return Logueo.TipoProvision == "C/OC" ? FrmParentConOC.anioOrdenCompra : FrmParentSinOC.anioFactura;

        }
        #region "metodos pasado"
        //private void LimpiarIGV() {
        //    rbAfecto.Checked = false;
        //    rbInafecto.Checked = false;
        //    rbNinguno.Checked = false;
        //    txtColumna.Text = "";
        //}
        //private void AsignarIGV(string codigoIGV) {
        //    LimpiarIGV();
        //    switch (codigoIGV.Trim()) { 
        //        case "A":
        //            rbAfecto.Checked = true;
        //            break;
        //        case "I":
        //            rbInafecto.Checked = true;
        //            break;
        //        default:
        //            rbNinguno.Checked = true;
        //            txtColumna.Text = codigoIGV;
        //            break;
        //    }
        //}
        //private void LimpiarMoneda() {
        //    rbSoles.Checked = false;
        //    rbDolares.Checked = false;
        //    rbCuotas.Checked = false;
        //}
        //private void AsignarMoneda(string codigoMoneda) {
        //    LimpiarMoneda();
        //    switch (codigoMoneda) { 
        //        case "S":
        //            rbSoles.Checked = true;
        //            break;

        //        case "D":
        //            rbDolares.Checked = true;
        //            break;
        //            //"C"
        //        default:
        //            rbCuotas.Checked = true;
        //            break;
        //    }
        //}
        #endregion
        /// <summary>
        /// Asignar montos segun el tipo de moneda seleccionado, 
        /// se obtiene el valor de la fila actual seleccionado actualmente.
        /// </summary>
        /// <param name="saldoSoles">Parametro tipo numero decimal</param>
        /// <param name="saldoDolares">Parametro tipo numero decimal</param>
        private void AsignarMontos(double saldoSoles, double saldoDolares)
        {
            double montoValor = 0;
            GridViewRowInfo fila = this.gridControl.CurrentRow;

            string tipoMoneda = Util.GetCurrentCellText(fila, "moneda");
            //validar si la moneda es Soles "S"

            if (tipoCambio == "S")
            {
                //importe no equivalente
                montoValor = saldoSoles < 0 ? Math.Abs(saldoSoles) : 0;
                Util.SetValueCurrentCellDbl(fila, "ImporteDebe", montoValor);

                montoValor = saldoSoles > 0 ? Math.Abs(saldoSoles) : 0;
                Util.SetValueCurrentCellDbl(fila, "ImporteHaber", montoValor);


                //Importes equivalentes
                montoValor = saldoDolares < 0 ? Math.Abs(saldoDolares) : 0;
                Util.SetValueCurrentCellDbl(fila, "ImporteDebeEquivalencia", 0);

                montoValor = saldoDolares > 0 ? Math.Abs(saldoDolares) : 0;
                Util.SetValueCurrentCellDbl(fila, "ImporteHaberEquivalencia", montoValor);


            }
            else if (tipoCambio == "D")
            {
                //importe no equivalente
                montoValor = saldoDolares < 0 ? Math.Abs(saldoDolares) : 0;
                Util.SetValueCurrentCellDbl(fila, "ImporteDebe", montoValor);
                //txtDebeMonto.Text = montoValor.ToString();

                montoValor = saldoDolares > 0 ? Math.Abs(saldoDolares) : 0;
                Util.SetValueCurrentCellDbl(fila, "ImporteHaber", montoValor);
                //txtHaberMonto.Text = montoValor.ToString();

                //importe equivalente

                montoValor = saldoSoles < 0 ? Math.Abs(saldoSoles) : 0;

                Util.SetValueCurrentCellDbl(fila, "ImporteDebeEquivalencia", montoValor);
                //txtDebeMontoEquiv.Text = montoValor.ToString();

                montoValor = saldoSoles > 0 ? Math.Abs(saldoSoles) : 0;
                Util.SetValueCurrentCellDbl(fila, "ImporteHaberEquivalencia", montoValor);
                //txtHaberMontoEquiv.Text = montoValor.ToString();
            }
        }

        private bool activaCentroCosto = false, activaCentroGestion = false;
        private bool activaCtaCte = false , activaColReg = false;
        /// <summary>
        /// Metodo para leer los valores de los flag para Centro Gestion, centro costo, Cuenta corriente, ColReg
        /// </summary>
        protected void LeerFlagActivacion() {                         
            string ana = Util.GetCurrentCellText(gridControl.CurrentRow, "ccm01ana");
            string cc = Util.GetCurrentCellText(gridControl.CurrentRow, "ccm01cc");
            string cg = Util.GetCurrentCellText(gridControl.CurrentRow, "ccm01cg");
            string colreg = Util.GetCurrentCellText(gridControl.CurrentRow, "ccm01ColReg");


            //valida que sea diferente de blanco y luego valida que sea diferente del N
            //En analisis validar que debe tener un valor numerico en reemplazo de un valor "S" -> Si
            if (ana.Trim() != "")
            {
                //validar que debe ser un numero entero en formato de dos digitos.
                if (ana.Trim() != "N" || ana.Length == 2) {
                    activaCtaCte = true;
                }
                
            }
            else {
                activaCtaCte = false;
            }
            
            //validar que debe ser diferente de valor vacion y debe tener un valor "S"->Si para activar el control
            switch (cc) {
                case "S":
                    activaCentroCosto = true;
                    break;
                case "N":
                    activaCentroCosto = false;
                    break;
                default:
                    activaCentroCosto = false;
                    break;
            }

            switch (cg) { 
                case "S":
                    activaCentroGestion = true;
                    break;
                case "N":
                    activaCentroGestion = false;
                    break;
                default:
                    activaCentroGestion = false;
                    break;
            }

            

            //if (colreg != "")
            //{
            //    activaColReg = true;
            //}
            //else {
            //    activaColReg = false;
            //}

            //configurando las celdas de ayuda segun el valor del flag de ayuda
            if (activaCentroCosto) {
                Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CenCos"]);
            }
            if (activaCentroGestion) {
                Util.ResaltarAyuda(gridControl.CurrentRow.Cells["Gestion"]);
            }
            if (activaCtaCte) {
                Util.ResaltarAyuda(gridControl.CurrentRow.Cells["CuentaCorriente"]);
            }         
        }
        private void TraerAyuda(enmAyuda tipo)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmBusqueda frm;
            
            
            string codigo = "";
            //el tipo de documento
            if (tipo == enmAyuda.enmDocumentosPendientes)
            {
                //buscar el control por el foco
                //si control grilla tiene foco                
                   codigo =  Util.GetCurrentCellText(gridControl.CurrentRow, "cuenta") + "|"+
                             Util.GetCurrentCellText(gridControl.CurrentRow, "CuentaCorriente")+"|"+
                             Util.GetCurrentCellText(gridControl.CurrentRow, "FechaDoc");                 
                frm = new frmBusqueda(tipo, codigo);

            }

            else if (tipo == enmAyuda.enmCentroGestion) {                
                    codigo = Util.GetCurrentCellText(gridControl.CurrentRow, "cuenta");                                
                    frm = new frmBusqueda(tipo, codigo);
            }
            else
            {
                //tipo de ayuda que no recibe parametros para traer datos
                frm = new frmBusqueda(tipo);
            }            
            Cursor.Current = Cursors.Default;

            frm.ShowDialog();
            if (frm.Result == null) return;
            if (frm.Result.ToString() == "") return;

            string[] datos = frm.Result.ToString().Split('|');
            
            try
            {
                GridViewRowInfo fila = gridControl.CurrentRow;
                switch (tipo)
                {
                     
                    //distribucion de gastos
                    case enmAyuda.enmHabyMov:

                        //0 -> ccm01cta , 1->ccm01des, 2->ccm01dn, 3->ccm01ana, 4->ccm01cc,5->ccm01cg
                            Util.SetValueCurrentCellText(fila, "cuenta", datos[0]);
                            Util.SetValueCurrentCellText(fila, "cuentaDesc", datos[1]);
                            Util.SetValueCurrentCellText(fila, "moneda", datos[2]);
                            Util.SetValueCurrentCellText(fila,"ccm01ana", datos[3]); 
                            Util.SetValueCurrentCellText(fila,"ccm01cc", datos[4]);
                            Util.SetValueCurrentCellText(fila,"ccm01cg", datos[5]);
                            //Util.SetValueCurrentCellText(fila, "ccm01ColReg", datos[5]);
                            LeerFlagActivacion();

                            //validar con flag si es activado la ayuda o celda de la fila actual
                           //valores para activar y descativar las celdas de ayuda.                        
                        
                        break;

                    case enmAyuda.enmCentroCosto:

                        if (gridControl.ContainsFocus)
                        {
                            Util.SetValueCurrentCellText(fila, "CenCos", datos[0]);
                            Util.SetValueCurrentCellText(fila, "CenCosDesc", datos[1]);
                        }
                        
                        
                        break;
                    case enmAyuda.enmCentroGestion:
                        if (gridControl.ContainsFocus)
                        {
                            Util.SetValueCurrentCellText(fila, "Gestion", datos[0]);
                            Util.SetValueCurrentCellText(fila, "CenGesDesc", datos[1]);
                        }
                        
                        
                        break;
                    case enmAyuda.enmProveedor:
                        if (gridControl.ContainsFocus)
                        {
                            Util.SetValueCurrentCellText(fila, "CuentaCorriente", datos[0]);
                            Util.SetValueCurrentCellText(fila, "CuentaCorrienteDesc", datos[1]);
                        }
                        
                        
                        break;
                    case enmAyuda.enmTipoDocumento:
                        if (gridControl.ContainsFocus)
                        {
                            Util.SetValueCurrentCellText(fila, "TipoDocumento", datos[0]);
                            Util.SetValueCurrentCellText(fila, "TipoDocumentoDesc", datos[1]);
                        } else { 
                        
                        }
                        //txtTipDoc.Text = datos[0];
                        //txtTipDocDesc.Text = datos[1];
                        break;
                    case enmAyuda.enmDocumentosPendientes:

                        if (gridControl.ContainsFocus)
                        {
                            Util.SetValueCurrentCellText(fila, "TipoDocumento", datos[0]);
                            Util.SetValueCurrentCellText(fila, "TipoDocumentoDesc", datos[1]);
                            if (Util.GetCurrentCellText(fila, "FechaDoc") == "") 
                            {
                                Util.SetValueCurrentCellText(fila, "FechaDoc", datos[2]);
                            }
                            saldoDolares = Util.GetCurrentCellDbl(fila, datos[3]);
                            saldoSoles = Util.GetCurrentCellDbl(fila, datos[4]);
                            AsignarMontos(saldoSoles, saldoDolares);


                        }
                        else {
                            //txtTipDoc.Text = datos[0];
                            //txtTipDocDesc.Text = datos[1];
                            //if (dtpFecDoc.Text == "")
                            //{
                            //    dtpFecDoc.Value = Convert.ToDateTime(datos[2]);
                            //}
                            //saldoDolares = Convert.ToDouble(datos[3]);
                            //saldoSoles = Convert.ToDouble(datos[4]);
                            //AsignarMontos(saldoSoles, saldoDolares);
                            //txtNroDoc.Focus();            
                        }
                        
                        break;
                    //ayuda para el bloque grupo Detraccion
                    case enmAyuda.enmTipDocParaVoucher:
                        txtTasa.Text = datos[0];
                        txtTasaDesc.Text = datos[1];
                        break;
                     
                    //case enmAyuda.enmCuentaContable:
                    //    break;

                    case enmAyuda.enmMoneda:
                        Util.SetValueCurrentCellText(fila, "moneda", datos[0]);
                        Util.SetValueCurrentCellText(fila, "ValorMoneda", datos[1]);
                        break;
                }
            }
            catch (Exception ex)
            { 
                Util.ShowError("Error al traer Ayuda");
            }
        }

     
        private void gridControl_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {


            if (gridControl.Rows.Count == 0) return;
              try
              {
                  //string mes = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.mesProvision : FrmParentSinOC.mesProvision;
                 
              }
              catch (Exception ex) {
                  Util.ShowError("Error al seleccionar registros");
              }
        }

        
    
        #endregion
        
        
        private void agregarBoton()
        {

            //GridViewCommandColumn colGrabar = new GridViewCommandColumn();
            //colGrabar.Name = "btnGrabar";
            //colGrabar.HeaderText = "";
            //gridControl.Columns.Add(colGrabar);
            //gridControl.Columns["btnGrabar"].BestFit();

            //GridViewCommandColumn colCancelar = new GridViewCommandColumn();
            //colCancelar.Name = "btnCancelar";
            //colCancelar.HeaderText = "";
            //gridControl.Columns.Add(colCancelar);
            //gridControl.Columns["btnCancelar"].BestFit();

            GridViewCommandColumn colEliminar = new GridViewCommandColumn();
            colEliminar.Name = "btnEliminar";
            colEliminar.HeaderText = "";
            gridControl.Columns.Add(colEliminar);
            gridControl.Columns["btnEliminar"].BestFit();


            GridViewCommandColumn colEditar = new GridViewCommandColumn();
            colEditar.Name = "btnEditar";
            colEditar.HeaderText = "";
            gridControl.Columns.Add(colEditar);
            gridControl.Columns["btnEditar"].BestFit();

        }
        private double LeerTipoCambio(GridViewRowInfo fila) {
            double valor = 0;
            //valor = Util.GetCurrentCellText(fila, "TipoCambio");
            valor = Util.GetCurrentCellDbl(fila, "TipoCambio");
            return valor;
        }
        private string LeerAfecto(GridViewRowInfo fila) {
            string valor = "";
            valor = Util.GetCurrentCellText(fila, "ValorIgv");            
            return valor;
        }
        private string LeerTipoMoneda(GridViewRowInfo fila) {
            string valor = "";
            valor =  Util.GetCurrentCellText(fila, "moneda");
            return valor;
        }

        internal string LeerTasa() {
            string valor = "";
            valor = txtTasa.Text.Trim();
            return valor;
        }
        #region "eventos y metodos pasado"
              

        private double LeerMontoDebe(GridViewRowInfo fila, bool esEquivalente = false)
        {
            //GridViewRowInfo fila;
            fila = gridControl.CurrentRow;
            string montoDebe = "";
            try
            {
                if (esEquivalente)
                {
                    //evaluadno los importes equivalentes

                    if (Util.GetCurrentCellText(fila, "ImporteDebeEquivalencia") == "")
                    {
                        Util.SetValueCurrentCellText(fila, "ImporteDebeEquivalencia", "0");
                    }
                    montoDebe = Util.GetCurrentCellText(fila, "ImporteDebeEquivalencia");
                    
                }
                else
                {
                    if (Util.GetCurrentCellText(fila, "ImporteDebe") == "")
                    {
                        Util.SetValueCurrentCellText(fila, "ImporteDebe", "0");
                    }
                    montoDebe = Util.GetCurrentCellText(fila, "ImporteDebe");
                    
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al leer monto debe");
            }
            return double.Parse(montoDebe);
        }
        private double LeerMontoHaber(GridViewRowInfo fila, bool esEquivalente = false)
        {            
            string monto = "";
            try
            {

                if (esEquivalente)
                {
                    if (Util.GetCurrentCellText(fila, "ImporteHaberEquivalencia") == "")
                    {
                        Util.SetValueCurrentCellText(fila, "ImporteHaberEquivalencia", "0");
                    }
                    monto = Util.GetCurrentCellText(fila, "ImporteHaberEquivalencia");                    
                }
                else
                {
                    if (Util.GetCurrentCellText(fila, "ImporteHaber") == "")
                    {
                        Util.SetValueCurrentCellText(fila, "ImporteHaber", "0");
                    }
                    monto = Util.GetCurrentCellText(fila, "ImporteHaber");
                    
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al leer monto haber");
            }
            return double.Parse(monto);
        }
        
        #endregion
        #region "eventos actuales"
        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {


            //evento que se inicia al cambiar el valor de la celda
            
            try
            {
                //validar que la celda de tipo debe y haber debe ser mayor a cero y solo numeros
                //la celda de soles activar el metodo calcular equivalente
                if (Util.IsCurrentColumn(e.Column, "ImporteDebe")  
                    || Util.IsCurrentColumn(e.Column, "ImporteDebeEquivalencia")
                    || Util.IsCurrentColumn(e.Column, "ImporteHaberEquivalencia")
                    || Util.IsCurrentColumn(e.Column, "ImporteHaber"))
                {
                    CalcularEquivalentes();
                }

                
            }
            catch (Exception ex) {
                Util.ShowAlert("Error en cellvaluchanged");
            }
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.gridControl.RowCount == 0)
                return;
            if (Util.GetCurrentCellText(gridControl.CurrentRow, "flag") == "") return;
            //validar que la fila sea editable para llamar a la ayuda
            //if (this.gridControl.CurrentRow.Cells["flag"].Value == null) return;
            if(e.KeyValue == (char)Keys.F1){                            
                switch (gridControl.CurrentColumn.Name) {
                    case "cuenta":
                        TraerAyuda(enmAyuda.enmHabyMov);
                        break;
                    case "CenCos":
                        if (activaCentroCosto) {
                            TraerAyuda(enmAyuda.enmCentroCosto);
                        }
                        
                        break;
                    case "Gestion":
                        if (activaCentroGestion) {
                            TraerAyuda(enmAyuda.enmCentroGestion);
                        }                        
                        break;
                    case "CuentaCorriente":
                        if (activaCtaCte) {
                            TraerAyuda(enmAyuda.enmProveedor);
                        }
                        
                        break;
                    case "TipoDocumento":
                        TraerAyuda(enmAyuda.enmTipoDocumento);
                        break;
                    case "NumeroDocumento":
                        TraerAyuda(enmAyuda.enmDocumentosPendientes);
                        break;
                    case "moneda":
                        TraerAyuda(enmAyuda.enmMoneda);
                        break;
                    default: 
                        break;
                }
            }
            if (e.KeyValue == (char)Keys.Delete) {
                
                //si al fila esta en mdoo lectura
                //if (Util.GetCurrentCellText(gridControl.CurrentRow, "flag") == "") {
                //    eliminarRegistroGrilla();
                //}

                if (Util.IsCurrentColumn(gridControl.CurrentColumn, "FechaVencimiento"))
                {
                    if (Util.GetCurrentCellText(gridControl.CurrentRow,"FechaVencimiento") == "01/01/0001"
                        || Util.GetCurrentCellText(gridControl.CurrentRow, "FechaVencimiento") == "1/01/0001")
                    {
                        gridControl.CurrentRow.Cells["FechaVencimiento"].Value = DBNull.Value;                        
                    }
                }

                if (Util.IsCurrentColumn(gridControl.CurrentColumn, "FechaDoc"))
                {
                    if (Util.GetCurrentCellText(gridControl.CurrentRow, "FechaDoc") == "01/01/0001"||
                        Util.GetCurrentCellText(gridControl.CurrentRow, "FechaDoc")== "1/01/0001" )
                    {
                        gridControl.CurrentRow.Cells["FechaDoc"].Value = DBNull.Value;
                    }
                }
                
            }
            
            



        }

        private void gridControl_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
            if (cellElement == null) return;

            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                RadButtonElement commandButton = ((RadButtonElement)((GridCommandCellElement)e.CellElement).Children[0]);
                if (Estado == FormEstate.View)
                {
                    //desactiva grabar, cancelar, eliminar, editar
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, false, false);
                    return;
                }

                if (gridControl.Rows[e.RowIndex].Cells["flag"].Value == null)
                {// si es modo ver 
                    //desactiva grabar, cancelar , activar eliminar , editar
                    habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                }
                else
                {// si es modo grabar o cancelar
                    //activa grabar, cancelar, activa elimina, editar
                    habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);
                }


            }
          
        }

        /// <summary>
        /// Metodo para habilitar o deshabilitar los botones del mantenimeinto detalle Moviemiento
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="CommandCell"></param>
        /// <param name="bGrabar"></param>
        /// <param name="bCancelar"></param>
        /// <param name="bEliminar"></param>
        /// <param name="bEditar"></param>
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar, bool bCancelar,
            bool bEliminar, bool bEditar)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabar":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelar":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminar":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditar":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edited_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Metod para eliminar el registro seleccionado del detalle de movimiento
        /// </summary>        
        private void eliminarRegistroGrilla()
        {

            try
            {

                string OrigenODestino = Util.GetCurrentCellText(gridControl.CurrentRow, "Amarre");

                if (OrigenODestino == "D")
                {
                    Util.ShowError("¨Validar:: No se puede Eliminar Registro Destino, Elimine desde el Origen");
                    Cursor.Current = Cursors.Default;
                    return;
                }

                if (this.gridControl.RowCount == 0)
                    return;

                DialogResult dialog = RadMessageBox.Show("Está seguro de eliminar Item seleccionado?", "Aviso",
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.No)
                    return;

                GridViewRowInfo info = this.gridControl.CurrentRow;

                // eliminar movimiento sin orde de trabajo 
                if (double.Parse(info.Cells["orden"].Value.ToString()) > 0)
                {
                                        
                    string mes = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.mesProvision : FrmParentSinOC.mesProvision;
                    double numeroOrden = 0;
                    string libro = "", nroVoucher = "";
                    libro = lblLibro.Text;
                    nroVoucher = lblNroVoucher.Text;
                    
                    numeroOrden = Util.GetCurrentCellDbl(this.gridControl.CurrentRow, "orden");

                    int flag = 0; string mensaje = "";

                    LogicaVoucher.EliminaDetalle(Logueo.CodigoEmpresa, Logueo.Anio, mes, libro, 
                                                    nroVoucher, numeroOrden, out flag, out mensaje);

                    Util.ShowMessage(mensaje, flag);

                    if (flag == 1) {
                        CargarDetalleRegistroContable(libro, nroVoucher); 
                    }
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Metodo para habilitar los campos paraedicion de registro
        /// </summary>
        void editarRegistroGrilla()
        {
            //Flaga pra fila en modo edicion
            //gridControl.CurrentRow.Cells["flag"].Value = "1";

            seleccionaFilaaEditar = true;

            
            Cursor.Current = Cursors.WaitCursor;

            string OrigenODestino = Util.GetCurrentCellText(gridControl.CurrentRow, "Amarre");

            if (OrigenODestino == "D")
            {
                Util.ShowError("¨Validar:: No se puede Modificar Registro Destino, Modifique desde el Origen");
                Cursor.Current = Cursors.Default;
                return;
            }

            var frmInstance = frmRegistroContableDet.Instance(this);
            frmInstance.Estado = FormEstate.Edit;
            //var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvFacturaDet);
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRegistroContableDet);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);

            frmInstance.Show();


            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// Metodo para cancelar la insercion del registro en el detalle de movimiento
        /// </summary>
        void cancelarRegistroGrilla()
        {
            //Movimiento mov = new Movimiento();
            //mov.Orden = double.Parse(this.gridControl.CurrentRow.Cells["orden"].Value.ToString());
            //CargarMovimiento(); 
            //Util.enfocarFila(gridControl, "orden", mov.Orden.ToString());
            string libro = lblLibro.Text.Trim();            
            string nroVoucher = lblNroVoucher.Text.Trim();
            CargarDetalleRegistroContable(libro, nroVoucher);
            
        }
        
        private void GuardarDetalle(GridViewRowInfo fila) {

            int flag = 0;
            string mensaje = "";
            try
            {
                VoucherDetalle entidad = new VoucherDetalle();


                string codMoneda  = Util.GetCurrentCellText(gridControl.CurrentRow, "moneda");
                
                double importeDebe = 0, importeHaber = 0, importeDebeEquiv = 0, importeHaberEquiv = 0;

                importeDebe = Util.GetCurrentCellDbl(fila, "ImporteDebe");
                importeHaber = Util.GetCurrentCellDbl(fila, "ImporteHaber");
                importeDebeEquiv = Util.GetCurrentCellDbl(fila, "ImporteDebeEquivalencia");
                importeHaberEquiv = Util.GetCurrentCellDbl(fila, "ImporteHaberEquivalencia");

                if (codMoneda == "S") {
                    //valida que solo uno de los importe debe ser mayor a cero
                    if (importeDebe > 0 && importeHaber > 0) {
                        Util.ShowAlert("Solo se permite ingresar valor en Debe o Haber");
                        return;
                    }
                    
                } else if (codMoneda == "D") {
                    if (importeDebeEquiv > 0 && importeHaberEquiv > 0) {
                        Util.ShowAlert("Solo se permite ingresar valor en debe o haber");
                        return;
                    }
                }
                //validacion de valores de Debe y haber 
                
                //string moneda = LeerTipoMoneda();
                string moneda = codMoneda;

                //string afecto = LeerAfecto();
                string afecto = Util.GetCurrentCellText(fila, "Afecto");
                
                
                
                //string fecha = LeerFechaDocumento();
                string fecha = Util.GetCurrentCellText(fila, "FechaDoc");
                string jalar = "";
                entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                entidad.Anio = Logueo.Anio;
                //Leo el mes desde la variable de instancia del formulario padre
                entidad.Mes = LeerMes();
                //lee el codigo de libro deepende la instancia del formulario padre
                entidad.libro = LeerLibro();
                //lee el codigo de 
                entidad.NumeroVoucher = LeerNroVoucher();

                //entidad.cuenta = txtCuenta.Text;
                entidad.cuenta = Util.GetCurrentCellText(fila, "cuenta");
                entidad.ImporteDebe = importeDebe;
                entidad.ImporteHaber = importeHaber;
                
                
                //entidad.glosa = txtConcepto.Text;
                entidad.glosa = Util.GetCurrentCellText(fila, "glosa");
                
                //entidad.TipoDocumento = txtTipDoc.Text;
                entidad.TipoDocumento = Util.GetCurrentCellText(fila, "TipoDocumento");
                //entidad.NumDoc = txtNroDoc.Text;
                entidad.NumDoc = Util.GetCurrentCellText(fila, "NumDoc");
                //entidad.FechaDoc = dtpFecDoc.Value;
                if (gridControl.CurrentRow.Cells["FechaDoc"].Value == null)
                {
                    entidad.FechaDoc = null;
                }
                else {
                    entidad.FechaDoc = Convert.ToDateTime(gridControl.CurrentRow.Cells["FechaDoc"].Value);
                }
                
                //entidad.FechaDoc =  Convert.ToDateTime(Util.GetCurrentCellText(fila, "FechaDoc"));
                
                //entidad.FechaVencimiento = dtpFecVen.Value;
                
                //entidad.FechaVencimiento = Convert.ToDateTime(Util.GetCurrentCellText(fila, "FechaVencimiento"));
                if (gridControl.CurrentRow.Cells["FechaVencimiento"].Value == null)
                {
                    entidad.FechaVencimiento = null;
                }
                else {
                    entidad.FechaVencimiento = Convert.ToDateTime(gridControl.CurrentRow.Cells["FechaVencimiento"].Value);
                }
                

                //entidad.CuentaCorriente = txtCuentaCorriente.Text;
                entidad.CuentaCorriente = Util.GetCurrentCellText(fila, "CuentaCorriente");
                //entidad.CuentaCorriente = Util.GetCurrentCellText(fila, "CuentaCorriente"));

                //entidad.moneda = LeerTipoMoneda();
                entidad.moneda = codMoneda;
                //entidad.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                entidad.TipoCambio = Util.GetCurrentCellDbl(fila, "TipoCambio");
                //entidad.Afecto = LeerAfecto();
                entidad.Afecto = Util.GetCurrentCellText(fila, "Afecto");
                //entidad.CenCos = txtCentroCosto.Text;
                entidad.CenCos =   Util.GetCurrentCellText(fila, "CenCos");
                //entidad.CenGes = txtCentroGestion.Text;
                entidad.CenGes = Util.GetCurrentCellText(fila, "Gestion");
                //trae el asientipo dependiendo de la instancia de formulario
                entidad.AsientoTipo = LeerAsientoTipo();
                entidad.ImporteDebeEquivalencia = importeDebeEquiv;
                entidad.ImporteHaberEquivalencia = importeHaberEquiv;
                //entidad.DebDol = debeDol;
                //entidad.HabDol = haberDol;

                entidad.transa = "N";
                entidad.Amarre = "";// amarrar con ccd01ord, no es necesario asignar valor
                entidad.Porcentaje = txtTasa.Text.Trim();

                //entidad.Amarre = Util.GetCurrentCellText(gridControl, "ccd01ord");
                //campo detraccion
                //entidad.NroPago = txtNroPago.Text;
                //entidad.Porcentaje = txtTasa.Text
                //txtTasa
                //txtTasaDesc

                //entidad.FechaPago = null;

                //entidad.orden = Util.GetCurrentCellDbl(gridControl, "orden");
                //ver si la fila esta en modo nuevo o editar : 0-> nuevo, 1-> actualizar
                string flagEstado = Util.GetCurrentCellText(fila, "flag");
                if (flagEstado == "0") {
                    string libro = "";
                    libro = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.libro : FrmParentSinOC.libro;

                    string tipoLibro = DameDescripcion(Logueo.CodigoEmpresa + libro, "03");

                    afecto = "";
                    afecto = DameDescripcion(Logueo.CodigoEmpresa + Logueo.Anio + entidad.cuenta, "FA");
                    if ((tipoLibro == "C" || tipoLibro == "V") && (afecto == "A"))
                    {
                        if (Util.ShowQuestion("¿Desea Calcular IGV Automaticamente?") == true)
                        {
                            jalar = "I";
                        }
                    }


                    entidad.valida = jalar;
                    LogicaVoucher.InsertarDetalle(entidad, out flag, out mensaje);
                    Util.ShowMessage(mensaje, flag);
                }
                else if (flagEstado == "1") {

                    entidad.orden = Util.GetCurrentCellDbl(gridControl.CurrentRow, "orden");
                    LogicaVoucher.ActualizoDetalle(entidad, out flag, out mensaje);
                    Util.ShowMessage(mensaje, flag);
                }

                //if (Estado == FormEstate.New)
                //{
                    
                //}
                //else if (Estado == FormEstate.Edit) {

                   
                //}

                if (flag == 1)
                {
                    TraeDatosProvision();
                    //almacenar la varaible de orden
                    //Registro contable
                    VoucherDetalle voucherregistro = new VoucherDetalle();
                    voucherregistro.orden = Util.GetCurrentCellDbl(gridControl.CurrentRow, "orden");

                    CargarDetalleRegistroContable(lblLibro.Text, lblNroVoucher.Text);
                    
                    Util.enfocarFila(gridControl, "orden", voucherregistro.orden.ToString());
                    //LogicaVoucher.InsertarDetalle(
                    OcultarBotones();
                    HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                    //un metodo debe dispara un evento para enviar la edicion de celda s a modo lectura
                    //InhabilitarControles();
                }
                
                
            }
            catch (Exception ex) {
                Util.ShowError(ex.Message);
            }
        }
        internal double LeerNumeroOrden() {
            return Util.GetCurrentCellDbl(gridControl.CurrentRow, "orden");
        }
        private void gridControl_CommandCellClick(object sender, EventArgs e)
        {
            if (this.gridControl.Columns["btnGrabar"] != null) {
                if (this.gridControl.Columns["btnGrabar"].IsCurrent)
                {
                    this.GuardarDetalle(this.gridControl.CurrentRow);
                }
            }


            if (this.gridControl.Columns["btnCancelar"] != null) {
                if (this.gridControl.Columns["btnCancelar"].IsCurrent)
                {
                    this.cancelarRegistroGrilla();
                }
            }


            if (this.gridControl.Columns["btnEliminar"] != null) {
                if (this.gridControl.Columns["btnEliminar"].IsCurrent)
                {
                    this.eliminarRegistroGrilla();
                }
            }


            if (this.gridControl.Columns["btnEditar"] != null) { 
                if (this.gridControl.Columns["btnEditar"].IsCurrent)
                {
                    //el boton elimianr no se permite segun el origen de la cuenta contable
                    //if (Util.GetCurrentCellText(this.gridControl.CurrentRow, "ccd01ama") != "D")
                    //{
                        this.editarRegistroGrilla();
                    //}
                    //else {
                    //    Util.ShowAlert("No puede eliminar una cuenta contable de origen detalle");
                    //}
                }
            }
        }

        private void gridControl_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.gridControl.ActiveEditor == null) { return; }

                if (e.Row == null) return;
                string flag = Util.GetCurrentCellText(e.Row, "flag");
                string moneda = Util.GetCurrentCellText(e.Row, "moneda");
                //fila modo edicion y grabar
                if (flag == "")
                {
                    e.Cancel = true;
                }
                else { 
                    
                    //Activar los controles permitidos


                    //valido segun el flag 1 -> editar, 0-> nuevo
                    if (flag == "0") {

                        //La edicion de la columna tipo Cambio dependel flag Tipo cambio
                        if (Util.IsCurrentColumn(e.Column, "TipoCambio") && Logueo.ModifTC != "S")
                        {
                            //desactiva la edicion en tipo cambio
                            e.Cancel = true;
                            
                        }
                     
                    }else  if(flag== "1"){

                        //si la moneda no es dolares, es Soles
                        if (Util.GetCurrentCellText(e.Row, "moneda") != "D") {
                            //si estoy en la columna tipo cambio
                            if (Util.IsCurrentColumn(e.Column, "TipoCambio"))
                            {
                                //desactivar la edicion cuando mi moneda sea Soles
                                e.Cancel = true;
                            }
                        }

                        //si estoy en la columna cuenta y estoy actualizando
                        if (Util.IsCurrentColumn(e.Column, "cuenta"))
                        {
                            //inaactivo la edicion cuenta contable
                            e.Cancel = true;

                        }                                               

                    }
                    
                    // en modo nuevo y editar aplicar al siguiente regla
                    //edicion de las columnas debe ,haber -  cargo,abono

                    /* A pedido de nueva solicitud se procedera a editar las 4 columnas Debe y ahber (moneda nacional soles), y debe haber (moneda extranjera, dolares)
                    if (moneda == "S")
                    {

                        if (Util.IsCurrentColumn(e.Column, "ImporteDebeEquivalencia") || Util.IsCurrentColumn(e.Column, "ImporteHaberEquivalencia"))
                        {
                            e.Cancel = true;
                        }

                    }
                    else if (moneda == "D")
                    {
                        if (Util.IsCurrentColumn(e.Column, "ImporteDebe") || Util.IsCurrentColumn(e.Column, "ImporteHaber"))
                        {
                            e.Cancel = true;
                        }                        
                    }
                     */
                    //modo editar

                    
                    
                }
            }
            catch (Exception ex) {
                Util.ShowError("Error al editar grilla");
            }
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            seleccionaFilaaEditar = false;

            
            //OcultarBotones();
            //HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

            Cursor.Current = Cursors.WaitCursor;
            var frmInstance = frmRegistroContableDet.Instance(this);

            NuevoDetalleCuentaContable();
                        //frm = new frmBusqueda(enmAyuda.enmHabyMov);
            frmInstance.Estado = FormEstate.New;
            //var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvFacturaDet);
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRegistroContableDet);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);

              frmInstance.Show();
              //string[] datos = frm.Result.ToString().Split('|');
            Cursor.Current = Cursors.Default;
            //OnNuevo();
        }

        
        #region "antigup codigo registro nuevo cuenta contable detalle 04102022"
        
        
        private void NuevoDetalleCuentaContable(){
            try
            {
 
                DateTime fecDoc, fecVen;
                             //asignar valores a celdas cuando se crear un nuevo registro
                concepto = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.concepto : FrmParentSinOC.concepto;
              
                tipoCambio = "1.00";
           
                tipoDocumento = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.tipoDocumento : FrmParentSinOC.tipoDocumento;
                
                nroDocumento = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.nroDocumento : FrmParentSinOC.nroDocumento;
                fecDoc = Logueo.TipoProvision == "C/OC" ? Convert.ToDateTime(FrmParentConOC.fechaDocumento) : Convert.ToDateTime(FrmParentSinOC.fechaDocumento);
                fecVen = Logueo.TipoProvision == "C/OC" ? Convert.ToDateTime(FrmParentConOC.fechaVencimiento) : Convert.ToDateTime(FrmParentSinOC.fechaVencimiento);
                tipoCambio = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.tipoCambio : FrmParentSinOC.tipoCambio;
                tipoMoneda = Logueo.TipoProvision == "C/OC" ? FrmParentConOC.tipoMoneda : FrmParentSinOC.tipoMoneda;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al presionar  nuevo");
            }
        }
          

        #endregion
        private void gridControl_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            System.Console.WriteLine("Evento Cell end edit");
        }
        private bool editandoCeldaFecVenc = false;
        private bool editandoCeldaFecDoc = false;
        private void gridControl_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (e.Row != null) {
                if (e.Column.Name == "FechaVencimiento")
                {
                    editandoCeldaFecVenc = true;
                }
                if (e.Column.Name == "FechaDoc")
                {
                    editandoCeldaFecDoc = true;
                }
                //Console.WriteLine("nombre de columna:" + e.Column.Name);
                //Console.WriteLine("Evento editor initialized");
                
                //if (e.Value != null) {
                //    Console.WriteLine("Valor de cleda:" + e.Value.ToString());
                //}
                
            }
            
        }

        private void gridControl_CurrentColumnChanged(object sender, CurrentColumnChangedEventArgs e)
        {
            
        }

        private void gridControl_CurrentRowChanging(object sender, CurrentRowChangingEventArgs e)
        {
            try
            {
                if (formularioCargado == true)
                {

                    if (gridControl.Rows.Count == 0) return;

                    if (e.CurrentRow.Cells["flag"].Value != null)
                    {
                        if (Util.GetCurrentCellText(e.CurrentRow, "flag") == "1" ||
                            Util.GetCurrentCellText(e.CurrentRow, "flag") == "0")
                        {
                            e.Cancel = true;
                        }


                    }
                }
            }
            catch (Exception ex) { 
            
            }
            
        }
        
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            seleccionaFilaaEditar = true;

            Estado = FormEstate.List;
            Cursor.Current = Cursors.WaitCursor;
            var frmInstance = frmRegistroContableDet.Instance(this);
            //var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProvFacturaDet);
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRegistroContableDet);
            if (frmExist != null)
            {
                frmInstance.BringToFront();
                return;
            }
            Control ctrl = this.ParentForm.Controls.Find("radDock1", true)[0];
            frmInstance.MdiParent = this.ParentForm;

            ((RadDock)(ctrl)).ActivateMdiChild(frmInstance);

            frmInstance.Show();


            Cursor.Current = Cursors.Default;
        }

        private void lblMoneda_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblImporteAfecto_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}
