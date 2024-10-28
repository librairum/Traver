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
using Com.UI.Win;

namespace Com.UI.Win
{
    public partial class frmGenerarAsientos : frmBaseReg
    {
        #region "Instancia"
        private static frmGenerarAsientos _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmGenerarAsientos Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmGenerarAsientos(formParent);
            _aForm = new frmGenerarAsientos(formParent);
            return _aForm;
        }
        #endregion
        VentaDocumentoLogic datos = VentaDocumentoLogic.Instance;
        public frmGenerarAsientos(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
            this.KeyPreview = false;
            CrearColumnas();

            //this.OptEstado0.Click += new EventHandler(OptEstado_Click);
            //this.OptEstado1.Click += new EventHandler(OptEstado_Click);
            //this.OptEstado2.Click += new EventHandler(OptEstado_Click);
            //IniciarControles();
        }

        public frmGenerarAsientos()
        {
            // TODO: Complete member initialization
        }
        void IniciarControles()
        {
            OptEstado0.CheckState = CheckState.Checked;
        }
        private void FiltrarFacturaPorEstadoContable()
        {
            //RadRadioButton opt = (RadRadioButton)sender;
            if (OptEstado0.IsChecked)
            {
                Cargar("1","1","");
            }
            else if (OptEstado1.IsChecked)
            {
                Cargar("2", "1", "");
            }
            else if (OptEstado2.IsChecked)
            {
                Cargar("3", "1", "");
            }
            ResaltarCamposAyuda();
        }

        private void traerfacturas(string estadocontable)
        {
            try
            {
                List<Spu_Fact_Trae_DocParaVouCont> lista = datos.TraeDocParaVouCount(Logueo.CodigoEmpresa,
                                                             Logueo.Anio, Logueo.Mes, estadocontable);


                this.gridControl.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro al traer datos:" + ex.Message);
            }
        }
        void OptEstado_Click(object sender, EventArgs e)
        {
            // FiltrarFacturaPorEstadoContable();
        }

        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            // CreateGridColumn(Grid, "Cod Plantilla", "FAC89SUBPLANTILLACOD", 0, "{0:dd/MM/yyyy}", 90);  

            CreateGridColumn(Grid, "Tipo.Doc", "ccb02des", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "Proveedor RUC", "CO05CODCTE", 0, "", 80, true, false, true);
            CreateGridColumn(Grid, "Proveedor Desc", "ProveedorDesc", 0, "", 120, true, true, true);
            CreateGridColumn(Grid, "Doc.Tip", "CO05TIPDOC", 0, "", 50, true, false,true);
            CreateGridColumn(Grid, "Doc.Nro", "CO05NRODOC", 0, "", 90, true, false,true);
            CreateGridColumn(Grid, "Concepto", "CO05CON", 0, "", 100, true, true, true);
            CreateGridColumn(Grid, "Fecha", "CO05FECHA", 0, "", 90, true, true, true);
            CreateGridColumn(Grid, "Moneda", "CO05MONEDA", 0, "", 30, true, true, true);
            CreateGridColumn(Grid, "Tipo Cambio", "CO05TC", 0, "", 50, true, true, true);

            CreateGridColumn(Grid, "Imp Afecto", "ImporteAfecto", 0, "", 90, true, true, true);
            CreateGridColumn(Grid, "IGV", "ImporteIgv", 0, "", 90, true, true, true);
            CreateGridColumn(Grid, "Imp Inafecto", "ImporteInafecto", 0, "", 90, true, true, true);
            CreateGridColumn(Grid, "Imp Documento", "ImporteDocumento", 0, "", 90, true, true, true);

            //CreateGridColumn(Grid, "Moneda", "CO07MONEDACOD", 0, "", 90, true, true, false);
            CreateGridColumn(Grid, "A.T Cod", "CO07ASIENTOTIPOCOD", 0, "", 70, true, true, true);
            CreateGridColumn(Grid, "A.T Desc", "ASIENTOTIPODESC", 0, "", 120, true, true, true);
            CreateGridColumn(Grid, "Libro", "VoucherLibro", 0, "", 30, true, true, true);
            //CreateGridColumn(Grid, "NOMENCLATURA", "CO07NOMENCLATURA", 0, "", 140, true, true, true);
            CreateGridColumn(Grid, "Voucher", "VoucherNumero", 0, "", 70, false, true, true);

            // Ocultos para generar voucher
            CreateGridColumn(Grid, "Imp Afecto equi ", "ImporteAfectoEquiv", 0, "", 90, true, true, false);
            CreateGridColumn(Grid, "IGV equi", "ImporteIgvEquiv", 0, "", 90, true, true, false);
            CreateGridColumn(Grid, "Imp Inafecto equi", "ImporteInafectoEquiv", 0, "", 90, true, true, false);
            CreateGridColumn(Grid, "Imp Documento equi", "ImporteDocumentoEquiv", 0, "", 90, true, true, false);

            CreateGridColumn(Grid, "CO05CENTRODECOSTO", "CO05CENTRODECOSTO", 0, "", 70, false, true, false);
            CreateGridColumn(Grid, "CO05DOCMODTIPO", "CO05DOCMODTIPO", 0, "", 70, false, true, false);
            CreateGridColumn(Grid, "CO05DOCMODNUMERO", "CO05DOCMODNUMERO", 0, "", 70, false, true, false);
            CreateGridColumn(Grid, "CO05DOCMODFECHA", "CO05DOCMODFECHA", 0, "", 70, false, true, false);

            CreateGridColumn(Grid, "CO05FECVEN", "CO05FECVEN", 0, "", 70, false, true, false);

            CreateGridColumn(Grid, "CO05TIPO", "CO05TIPO", 0, "", 70, false, true, false);
            CreateGridColumn(Grid, "CO05CODIGO", "CO05CODIGO", 0, "", 70, false, true, false);
            CreateGridColumn(Grid, "CO05ANOORDCOM", "CO05ANOORDCOM", 0, "", 70, false, true, false);
            CreateGridColumn(Grid, "CO05MESORDCOM", "CO05MESORDCOM", 0, "", 70, false, true, false);





            //PRIMARY KEYS

        }
        private void ResaltarCamposAyuda()
        {
            int x = 0;
            foreach (GridViewRowInfo row in gridControl.Rows)
            {

                Util.ResaltarAyuda(gridControl, x, "CO07ASIENTOTIPOCOD");
                x++;
            }
        }
        private void ResetearCamposAyuda()
        {
            int x = 0;
            foreach (GridViewRowInfo row in gridControl.Rows)
            {

                Util.ResetearAyuda(gridControl, x, "CO07ASIENTOTIPOCOD");
                x++;
            }
        }
        protected override void OnNuevo()
        {
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            Estado = FormEstate.New;

            gridControl.Rows.AddNew();

            ResaltarCamposAyuda();

        }

        protected override void OnEliminar()
        {

        }
        protected override void OnEditar()
        {
            Estado = FormEstate.Edit;

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            ResaltarCamposAyuda();

        }
        private void GrabarVoucher(string Voucheranio, string vouchermes, string voucherlibro, string vouchernumero, DateTime voucherfecha, string voucherglosa, string voucheraasientotipo,

               string ImporteAfecto, string ImporteAfectoEquiv, string ImporteInafecto, string ImporteInafectoEquiv, string ImporteIgv, string ImporteIgvEquiv, string ImporteDocumento, string ImporteDocumentoEquiv,

              string docproveedor, string doctipo, string docnumero, DateTime docfechaEmision, DateTime docfechaVencimiento, string docmoneda, string docticambio, string doccentrocosto,
              string docModtipo, string docModnumero, DateTime docModfechaEmision)
        {
            GlobalLogic LogicaGlobal = GlobalLogic.Instance;
            VoucherLogic LogicaVoucher = VoucherLogic.Instance;
            AsientoTipoLogic LogicaAsientoTipo = AsientoTipoLogic.Instance;
            try
            {

                float cantidadRegistros = 0;
                LogicaGlobal.ComprasTraeDimeExisteVoucher(Logueo.CodigoEmpresa, Voucheranio,
                vouchermes, voucherlibro, vouchernumero, out cantidadRegistros);

                // ======  Validaciones
                if (cantidadRegistros > 0)
                {
                    Util.ShowAlert("Ya existe voucher");
                    return;
                }

                Voucher entidad = new Voucher();
                int flag = 0; string msj = "";



                entidad = new Voucher();
                entidad.CodigoEmpresa = Logueo.CodigoEmpresa;
                entidad.Anio = Logueo.Anio;
                entidad.Mes = vouchermes;
                entidad.libro = voucherlibro;

                entidad.fecha = voucherfecha;
                entidad.detalle = voucherglosa;
                entidad.astip = voucheraasientotipo;
                entidad.trans = "N";
                string nroVoucher = "";

                // ====== Insertar Cabecera
                LogicaVoucher.InsertarCabecera(entidad, vouchernumero, out nroVoucher, out flag, out msj);

                // ====== Insertar Detalle
                List<ComprasAsientoTipoDetalle> listaDetAsientoTipo = new List<ComprasAsientoTipoDetalle>();
                if (flag == 1)
                {
                    listaDetAsientoTipo = LogicaAsientoTipo.TraeDetalleAsientoTipo(Logueo.CodigoEmpresa, voucheraasientotipo, Logueo.Anio);
                }
                string descripcion = "";
                LogicaGlobal.ComprasDameDescripcion(Logueo.CodigoEmpresa, doctipo, "SG", out descripcion);

                foreach (ComprasAsientoTipoDetalle itm in listaDetAsientoTipo)
                {
                    double DebSol = 0, DebDol = 0;
                    double HabSol = 0, HabDol = 0;



                    if (itm.ccd03ca == "C") // si es cargo
                    {
                        if (descripcion == "+") // si tipo documento es ingresos
                        {
                            HabSol = 0; HabDol = 0;
                            // asiganar valores al debe soles y debe dolares
                            AsignarDebSolesyDebDolares(docmoneda, ImporteAfecto, ImporteAfectoEquiv, ImporteInafecto, ImporteInafectoEquiv, ImporteIgv, ImporteIgvEquiv, ImporteDocumento, ImporteDocumentoEquiv,
                                itm.ccd03afin, out DebSol, out DebDol);
                        }
                        else // si tipo documento es egreso
                        {
                            DebSol = 0;
                            DebDol = 0;
                            // asiganar valores al haber
                            AsignarHabSolesyHabDolares(docmoneda, ImporteAfecto, ImporteAfectoEquiv, ImporteInafecto, ImporteInafectoEquiv, ImporteIgv, ImporteIgvEquiv, ImporteDocumento, ImporteDocumentoEquiv,
                                itm.ccd03afin, out HabSol, out HabDol);

                        }
                    }
                    else // si es abono
                    {

                        if (descripcion == "+")
                        {
                            DebSol = 0;
                            DebDol = 0;
                            HabSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumento, ImporteDocumentoEquiv);
                            HabDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumentoEquiv, ImporteDocumento);
                        }
                        else
                        {
                            HabSol = 0;
                            HabDol = 0;
                            DebSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumento, ImporteDocumentoEquiv);
                            DebDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumentoEquiv, ImporteDocumento); ;

                        }
                    }

                    string descripcionSalida = "";

                    string centroCosto = "";

                    LogicaGlobal.ComprasDameDescripcion(Logueo.CodigoEmpresa, Logueo.CodigoEmpresa + Logueo.Anio + itm.ccd03def,
                                                                "FC", out descripcionSalida);
                    centroCosto = descripcionSalida;


                    double factor = Convert.ToDouble(decimal.Round(decimal.Parse(itm.ccd03porcen.ToString()) / 100, 4));

                    DebSol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(DebSol * factor), 2));
                    HabSol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(HabSol * factor), 2));
                    DebDol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(DebDol * factor), 2));
                    HabDol = Convert.ToDouble(decimal.Round(Convert.ToDecimal(HabDol * factor), 2));

                    VoucherDetalle detalle = new VoucherDetalle();

                    detalle = LeerDetalleVoucher(itm, DebSol, HabSol, DebDol, HabDol, vouchermes, voucherlibro, vouchernumero, voucherglosa,
                                                    docproveedor, doctipo, docnumero, docfechaEmision, docfechaVencimiento, docmoneda, docticambio,
                                                    doccentrocosto, docModtipo, docModnumero, docModfechaEmision);

                    string mensajeSalida = "";
                    int flagSalida = 0;
                    LogicaVoucher.InsertarDetalle(detalle, out flagSalida, out mensajeSalida);
                }

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al grabar voucher");
            }
        }

        private VoucherDetalle LeerDetalleVoucher(ComprasAsientoTipoDetalle registro,
            double importeDebe, double importeHaber, double importeDebeEquivalencia, double importeHaberEquivalencia,
            string vouchermes, string voucherlibro, string vouchernumero, string voucherglosa,
            string docproveedor, string doctipo, string docnumero, DateTime docfechaEmision, DateTime docfechaVencimiento, string docmoneda, string docticambio, string doccentrocosto,
            string docModtipo, string docModnumero, DateTime docModfechaEmision

            )
        {
            VoucherDetalle detalle = new VoucherDetalle();
            detalle.CodigoEmpresa = Logueo.CodigoEmpresa;
            detalle.Anio = Logueo.Anio;
            detalle.Mes = vouchermes;
            detalle.libro = voucherlibro;
            detalle.NumeroVoucher = vouchernumero;
            detalle.cuenta = registro.ccd03def;
            detalle.ImporteDebe = importeDebe;
            detalle.ImporteHaber = importeHaber;
            //detalle.debSol = DebeSoles;
            //detalle.habSol = HaberSoles;
            detalle.glosa = voucherglosa;
            detalle.TipoDocumento = doctipo;
            detalle.NumDoc = docnumero;
            detalle.FechaDoc = docfechaEmision;
            detalle.FechaVencimiento = docfechaVencimiento;
            //
            detalle.DocModTipo = docModtipo.Trim();
            detalle.DocModNumero = docModnumero.Trim();
            detalle.DocModFecha = docModfechaEmision;

            detalle.CuentaCorriente = docproveedor.Trim();
            detalle.moneda = docmoneda.ToUpper().Trim();
            detalle.TipoCambio = double.Parse(docticambio);
            detalle.Afecto = registro.ccd03afin;
            detalle.CenCos = doccentrocosto;
            detalle.CenGes = "";
            detalle.AsientoTipo = registro.ccd03cod;
            detalle.valida = "";
            detalle.ImporteDebeEquivalencia = importeDebeEquivalencia;
            detalle.ImporteHaberEquivalencia = importeHaberEquivalencia;
            detalle.transa = "N";
            detalle.Amarre = "";
            detalle.NroPago = "";
            detalle.FechaPago = null;
            detalle.Porcentaje = "";

            return detalle;
        }

        private double DevolverImportePorMoneda(string tipoMoneda, string Importe1, string Importe2)
        {
            double importeSalida = 0;
            if (tipoMoneda.ToUpper().Trim() == "S")
            {
                importeSalida = Convert.ToDouble(Importe1);
            }
            else
            {
                importeSalida = Convert.ToDouble(Importe2);
            }
            return importeSalida;

        }
        private void AsignarHabSolesyHabDolares(
            string docmoneda,
            string ImporteAfecto, string ImporteAfectoEquiv, string ImporteInafecto, string ImporteInafectoEquiv, string ImporteIgv, string ImporteIgvEquiv, string ImporteDocumento, string ImporteDocumentoEquiv,
            string ValorAfin, out double SalidaHabSoles, out double SalidaHabDolares)
        {
            double HabSol = 0, HabDol = 0;
            if (ValorAfin == "1" || ValorAfin == "2" || ValorAfin == "3")
            {

                HabSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteAfecto, ImporteAfectoEquiv);
                HabDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteAfectoEquiv, ImporteAfecto);
            }

            if (ValorAfin == "4" || ValorAfin == "5" || ValorAfin == "9" || ValorAfin == "2")
            {
                HabSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteInafecto, ImporteInafectoEquiv);
                HabDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteInafectoEquiv, ImporteInafecto);
            }

            if (ValorAfin == "6" || ValorAfin == "7" || ValorAfin == "8")
            {
                HabSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteIgv, ImporteIgvEquiv);
                HabDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteIgvEquiv, ImporteIgv);
            }

            if (ValorAfin == "0")
            {
                HabSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumento, ImporteDocumentoEquiv);
                HabDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumentoEquiv, ImporteDocumento);
            }
            SalidaHabSoles = HabSol;
            SalidaHabDolares = HabDol;

        }
        private void AsignarDebSolesyDebDolares(string docmoneda,
            string ImporteAfecto, string ImporteAfectoEquiv, string ImporteInafecto, string ImporteInafectoEquiv, string ImporteIgv, string ImporteIgvEquiv, string ImporteDocumento, string ImporteDocumentoEquiv,
            string ValorAfin, out double SalidaDebSoles, out double SalidaDebDolares)
        {



            double DebSol = 0, DebDol = 0;
            if (ValorAfin == "1" || ValorAfin == "2" || ValorAfin == "3")
            {
                DebSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteAfecto, ImporteAfectoEquiv);
                DebDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteAfectoEquiv, ImporteAfecto);
            }

            if (ValorAfin == "4" || ValorAfin == "5" || ValorAfin == "9")
            {
                DebSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteInafecto, ImporteInafectoEquiv);
                DebDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteInafectoEquiv, ImporteInafecto);
            }
            if (ValorAfin == "6" || ValorAfin == "7" || ValorAfin == "8")
            {
                DebSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteIgv, ImporteIgvEquiv);
                DebDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteIgvEquiv, ImporteIgv);
            }

            if (ValorAfin == "0")
            {
                DebSol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumento, ImporteDocumentoEquiv);
                DebDol = DevolverImportePorMoneda(docmoneda.ToUpper().Trim(), ImporteDocumentoEquiv, ImporteDocumento);
            }

            SalidaDebSoles = DebSol;
            SalidaDebDolares = DebDol;
        }
        protected override void OnGuardar()
        {
            string glosa = "";
            string xmlCadena = "";

            string Voucheranio;
            string vouchermes;
            string voucherlibro;
            string vouchernumero;
            DateTime voucherfecha;
            string voucherglosa;
            string voucheraasientotipo;
            string ImporteAfecto;
            string ImporteAfectoEquiv;
            string ImporteInafecto;
            string ImporteInafectoEquiv;
            string ImporteIgv;
            string ImporteIgvEquiv;
            string ImporteDocumento;
            string ImporteDocumentoEquiv;
            string docproveedor;
            string doctipo;
            string docnumero;
            DateTime docfechaEmision;
            DateTime docfechaVencimiento;
            string docmoneda;
            string docticambio;
            string doccentrocosto;
            string docModtipo;
            string docModnumero;
            DateTime docModfechaEmision;
            string ordenCompraTip;
            string ordenCompraCod;
            string ordenCompraAnio;
            string ordenCompraMes;
            string msj;

            try
            {


                if (gridControl.SelectedRows.Count == 0) { Util.ShowAlert("Seleccionar documentos para generar voucher"); return; }

                //Recorro la grilla para validar los documento seleccionados debe contener asiento tipo libro y voucher.
                int x = 0;
                for (x = 0; x < gridControl.SelectedRows.Count; x++)
                {
                    if (Util.GetCurrentCellText(gridControl, "CO07ASIENTOTIPOCOD") == ""
                        || Util.GetCurrentCellText(gridControl, "VoucherLibro") == ""
                        || Util.GetCurrentCellText(gridControl, "VoucherNumero") == "")
                    {
                        Util.ShowAlert("Validacion :: Debe Ingresar : Asiento Tipo , Libro y Voucher ");
                        return;
                    }
                }


                //Si paso la validacion anterio preparrar los datos para enviar en un xml.
                string[] registrosSeleccionados = new string[this.gridControl.SelectedRows.Count];
                int j = 0;

                foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                {

                    Voucheranio = "";
                    vouchermes = "";
                    voucherlibro = "";
                    vouchernumero = "";
                    voucherglosa = "";
                    voucheraasientotipo = "";
                    ImporteAfecto = "";
                    ImporteAfectoEquiv = "";
                    ImporteInafecto = "";
                    ImporteInafectoEquiv = "";
                    ImporteIgv = "";
                    ImporteIgvEquiv = "";
                    ImporteDocumento = "";
                    ImporteDocumentoEquiv = "";
                    docproveedor = "";
                    doctipo = "";
                    docnumero = "";
                    //docfechaEmision=; 
                    //docfechaVencimiento="";
                    docmoneda = "";
                    docticambio = "";
                    doccentrocosto = "";
                    docModtipo = "";
                    docModnumero = "";
                    //docModfechaEmision="";
                    ordenCompraTip = "";
                    ordenCompraCod = "";
                    ordenCompraAnio = "";
                    ordenCompraMes = "";




                    //
                    Voucheranio = Logueo.Anio;
                    vouchermes = Logueo.Mes;
                    voucherlibro = Util.GetCurrentCellText(fila, "VoucherLibro");
                    vouchernumero = Util.GetCurrentCellText(fila, "VoucherNumero");
                    voucherfecha = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO05FECHA"));
                    voucherglosa = Util.GetCurrentCellText(fila, "CO05CON");
                    voucheraasientotipo = Util.GetCurrentCellText(fila, "CO07ASIENTOTIPOCOD");

                    ImporteAfecto = Util.GetCurrentCellText(fila, "ImporteAfecto");
                    ImporteAfectoEquiv = Util.GetCurrentCellText(fila, "ImporteAfectoEquiv");

                    ImporteInafecto = Util.GetCurrentCellText(fila, "ImporteInafecto");
                    ImporteInafectoEquiv = Util.GetCurrentCellText(fila, "ImporteInafectoEquiv");

                    ImporteIgv = Util.GetCurrentCellText(fila, "ImporteIgv");
                    ImporteIgvEquiv = Util.GetCurrentCellText(fila, "ImporteIgvEquiv");

                    ImporteDocumento = Util.GetCurrentCellText(fila, "ImporteDocumento");
                    ImporteDocumentoEquiv = Util.GetCurrentCellText(fila, "ImporteDocumentoEquiv");

                    docproveedor = Util.GetCurrentCellText(fila, "CO05CODCTE");
                    doctipo = Util.GetCurrentCellText(fila, "CO05TIPDOC");
                    docnumero = Util.GetCurrentCellText(fila, "CO05NRODOC");
                    docfechaEmision = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO05FECHA"));
                    docfechaVencimiento = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO05FECVEN"));
                    docmoneda = Util.GetCurrentCellText(fila, "CO05MONEDA");
                    docticambio = Util.GetCurrentCellText(fila, "CO05TC");
                    doccentrocosto = Util.GetCurrentCellText(fila, "CO05CENTRODECOSTO");
                    docModtipo = Util.GetCurrentCellText(fila, "CO05DOCMODTIPO");
                    docModnumero = Util.GetCurrentCellText(fila, "CO05DOCMODNUMERO");
                    docModfechaEmision = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO05DOCMODFECHA"));

                    ordenCompraTip = Util.GetCurrentCellText(fila, "CO05TIPO"); ;
                    ordenCompraCod = Util.GetCurrentCellText(fila, "CO05CODIGO"); ;
                    ordenCompraAnio = Util.GetCurrentCellText(fila, "CO05ANOORDCOM"); ;
                    ordenCompraMes = Util.GetCurrentCellText(fila, "CO05MESORDCOM"); ;

                    GrabarVoucher(Voucheranio, vouchermes, voucherlibro, vouchernumero, voucherfecha, voucherglosa, voucheraasientotipo,
                        ImporteAfecto, ImporteAfectoEquiv, ImporteInafecto, ImporteInafectoEquiv, ImporteIgv, ImporteIgvEquiv,
                        ImporteDocumento, ImporteDocumentoEquiv, docproveedor, doctipo,
                        docnumero, docfechaEmision, docfechaVencimiento, docmoneda, docticambio, doccentrocosto, docModtipo, docModnumero, docModfechaEmision
                        );

                    // Actualizo estado de provision
                    // ====== Insertar Cabecera
                    ProvisionFacturaLogic.Instance.Actualizar_DocumentosContabilizados(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                        ordenCompraTip, ordenCompraCod, doctipo, docnumero, docproveedor, ordenCompraAnio, ordenCompraMes,
                       voucherlibro, vouchernumero, voucheraasientotipo, out msj);


                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar Voucher contable.:" + ex.Message);
            }

            ////OBTENGO LOS DATOS DE LA GRILLA
            //GridViewRowInfo info = gridControl.CurrentRow;

            ////PRIMARY KEYS

            //string CO07CODEMP = Util.GetCurrentCellText(gridControl, "CO07CODEMP");
            //int CO07ITEM = Convert.ToInt32(Util.GetCurrentCellText(gridControl, "CO07ITEM"));

            ////END PRIMARY KEYS
            //string AsientoTipoCod = Util.GetCurrentCellText(gridControl, "CO07ASIENTOTIPOCOD");
            //string NOMENCLATURA = Util.GetCurrentCellText(gridControl, "CO07NOMENCLATURA");
            ////string FAC89DOCESTADOSUNAT = Util.GetCurrentCellText(gridControl, "FAC89DOCESTADOSUNAT");
            ////string FAC89NUMERACIONNOMENCLATURA = Util.GetCurrentCellText(gridControl, "FAC89NUMERACIONNOMENCLATURA");

            //int flag = 0;
            //string Msg = "";

            //ProvisionFacturaLogic.Instance.Actualizar_co07MotivosDocPorPagar(Logueo.CodigoEmpresa, CO07ITEM, AsientoTipoCod, NOMENCLATURA,out flag,out Msg);



            //if (flag == 1)
            //{
            //    // Ver mensaje de registro actualizado
            //    Util.ShowMessage(Msg, flag);
            //    this.Cargar();
            //    //ResaltarCamposAyuda();
            //    OcultarBotones();
            //    HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            //    HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);

            //}
            //else
            //{
            //    Util.ShowError(Msg);
            //    ResaltarCamposAyuda();
            //}


        }

        protected override void OnCancelar()
        {

            OcultarBotones();

            //HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            //HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
            //// HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            //if (Estado == FormEstate.New)
            //{
            //    //Eliminar fila si se activa el boton cancelar
            //    GridViewRowInfo fila = gridControl.CurrentRow;
            //    gridControl.Rows.Remove(fila);

            //}
            ResetearCamposAyuda();
            Estado = FormEstate.View;

        }

        // == Evento para cargar la grilla segun la opcion seleccionado
        private void Cargar(string opcion,string opcionFiltro,string xmlfiltro )
        {
            try
            {
                DataTable dt = ProvisionFacturaLogic.Instance.Trae_Spu_Com_Trae_AsientoContable(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, opcion,opcionFiltro,xmlfiltro);
                this.gridControl.DataSource = dt;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error traer Documentos para contabilizar:" + ex.Message);
            }
        }

        private void frmGenerarAsientos_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            IniciarControles();
            ////Oculta opciones de combobox
            radGroupBox2.Visible = true;
            radGroupBox2.Enabled = true;
            OcultarBotones();
            ////HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);

            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            //traerfacturas("0");
            CrearColumnas();
            Cargar("1","1","");
            ResaltarCamposAyuda();

            Cursor.Current = Cursors.Default;

        }

        private void TraerAyuda(enmAyuda tipoAyuda)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmBusqueda frm;
            string[] datos;
            switch (tipoAyuda)
            {
                case enmAyuda.enmAsiento:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "CO07ASIENTOTIPOCOD", datos[0]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "ASIENTOTIPODESC", datos[1]);
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "VoucherLibro", datos[2]);
                    //Util.SetCellInitEdit(gridControl, "FAC04CONTVOUCHER");       

                    break;
                case enmAyuda.enmFactCab_Moneda:
                    frm = new frmBusqueda(tipoAyuda);
                    frm.ShowDialog();
                    if (frm.Result == null) return;
                    if (frm.Result.ToString() == "") return;
                    datos = frm.Result.ToString().Split('|');
                    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89DOCMONEDA", datos[0]);


                    break;
                //case enmAyuda.enmFAC03SubPlantillaFAC89:
                //    frm = new frmBusqueda(tipoAyuda);
                //    frm.ShowDialog();
                //    if (frm.Result == null) return;
                //    if (frm.Result.ToString() == "") return;
                //    datos = frm.Result.ToString().Split('|');

                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89TIPDOCCOD", datos[0]);
                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89SUBPLANTILLACOD", datos[1]);
                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "SubPlantillaDesc", datos[2]);

                //    break;
                //case enmAyuda.enmEstadoSUNAT:
                //    frm = new frmBusqueda(tipoAyuda);
                //    frm.ShowDialog();
                //    if (frm.Result == null) return;
                //    if (frm.Result.ToString() == "") return;
                //    datos = frm.Result.ToString().Split('|');
                //    Util.SetValueCurrentCellText(gridControl.CurrentRow, "FAC89DOCESTADOSUNAT", datos[1]);
                //    break;
                default: break;
            }
            Cursor.Current = Cursors.Default;
        }
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (Estado == FormEstate.View)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyValue == (char)Keys.F1)
                {
                    //if (Util.IsCurrentColumn(gridControl, "FAC89SUBPLANTILLACOD"))
                    //{
                    //    TraerAyuda(enmAyuda.enmFAC03SubPlantillaFAC89);
                    //}
                    //if (Util.IsCurrentColumn(gridControl, "FAC89DOCMONEDA"))
                    //{
                    //    TraerAyuda(enmAyuda.enmFactCab_Moneda);
                    //}
                    if (Util.IsCurrentColumn(gridControl, "CO07ASIENTOTIPOCOD"))
                    {
                        TraerAyuda(enmAyuda.enmAsiento);
                    }
                }
            }
        }

        private void OptEstado0_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            FiltrarFacturaPorEstadoContable();
        }

        private void OptEstado1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            FiltrarFacturaPorEstadoContable();
        }

        private void OptEstado2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            FiltrarFacturaPorEstadoContable();
        }
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            var filasFiltradas = gridControl.ChildRows;

            DataTable dt = (DataTable)gridControl.DataSource;

            DataTable datatableFiltrado = dt.Clone();

            // arreglo =new string[0];
           /// string[] arreglo = new string[datatableFiltrado.Rows.Count];
           // string xml = "";
            foreach (var fila in filasFiltradas)
            {
                DataRowView dataRowView = fila.DataBoundItem as DataRowView;
                if (dataRowView != null)
                {
                 
                        datatableFiltrado.ImportRow(dataRowView.Row);


                    //int x = 0;
                    //arreglo[x] =
                    //    Util.GetCurrentCellText(fila, "CO05TIPDOC") + "|" + // 8
                    //    Util.GetCurrentCellText(fila, "CO05CODCTE") + "|" + // 9
                    //    Util.GetCurrentCellText(fila, "CO05NRODOC");


                    //x++;
                }
            }
           // xml = Util.ConvertiraXMLdinamico(arreglo);
           // Cargar("1", "2", xml);

            string xml = "";
            //var datatableFiltradoCount = datatableFiltrado.Rows.Count;
            //var datatableFiltradoRows = datatableFiltrado.Rows;
            //ARREGLO FILTRADO DE ROWS - HECHO 
            string[] arreglo = new string[datatableFiltrado.Rows.Count];
             int x = 0;

            foreach (DataRow fila in datatableFiltrado.Rows)
            {

                arreglo[x] = fila["CO05TIPDOC"] + "|" +
                              fila["CO05CODCTE"] + "|" +
                              fila["CO05NRODOC"];

                //arreglo[x] =
                //             Util.GetCurrentCellText(fila, "CO05TIPDOC") + "|" + // 8
                //             Util.GetCurrentCellText(fila, "CO05CODCTE") + "|" + // 9
                //             Util.GetCurrentCellText(fila, "CO05NRODOC");


                x++;
            }

            xml = Util.ConvertiraXMLdinamico(arreglo);
             Cargar("1", "2", xml);
          

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (OptEstado0.IsChecked)
            {
                Cargar("1", "1", "");
            }
            else if (OptEstado1.IsChecked)
            {
                Cargar("2", "1", "");
            }
            else if (OptEstado2.IsChecked)
            {
                Cargar("3", "1", "");
            }
            ResaltarCamposAyuda();
        }



    }
}