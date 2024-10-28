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
using Com.UI.Win.Reportes;
using System.IO;
namespace Com.UI.Win
{
    public partial class frmPagoDetraccionDet : frmBaseMante
    {
        private static frmPagoDetraccionDet _aForm;
        #region "Instancia de Provision factura con Orden COmpra"

        private FrmPagoDetraccionLista FrmParentDetraccion { get; set; }
        public frmPagoDetraccionDet(FrmPagoDetraccionLista padre)
        {
            InitializeComponent();
            FrmParentDetraccion = padre;
           this.Text = "Detraccion";
        }

        public static frmPagoDetraccionDet Instance(FrmPagoDetraccionLista padre)
        {
            if (_aForm != null) return new frmPagoDetraccionDet(padre);
            _aForm = new frmPagoDetraccionDet(padre);
            return _aForm;        
        }
        #endregion
        private void CrearColumnas() 
        {
            //resalte de ayuda
            RadGridView grid = CreateGridVista(gridControl);
            //GridViewRowInfo fila = FrmParentRetencion.gridControl.MasterView.CurrentRow;
            //grid.EnableFiltering = false;
          //  if(FrmParentDetraccion.Estado == ){}
            //CreateGridColumn(Grid, "Origen", "Amarre", 0, "", 60, true, false, true);// origen de la cuenta contable
            if (FrmParentDetraccion.Estado == FormEstate.View)
            {
                CrearColumnasCO26(grid);
                TraerDetraccionDet();
            }
            else if (FrmParentDetraccion.Estado == FormEstate.New)
            {
                CrearColumnasCO5(grid);
                //Cuando entra a nuevo saldran detracciones que faltan para pagar :)
                TraerDetraccionesxpagar();
            }
            //AddCmdButtonToGrid(gridControl, "btnEliminar", "", "btnEliminar");
            //AddCmdButtonToGrid(gridControl, "btnEditar", "", "btnEditar");
            //CreateGridColumn(grid, "Flag", "Flag", 0, "", 70, false, true, false);
        }
        private void CrearColumnasCO26(RadGridView grid) 
        {
            CreateGridColumn(grid, "Ruc", "CO26RUC", 0, "", 90, true, false, true);
            CreateGridColumn(grid, "Razon Social", "ccm02nom", 0, "", 200, true, false, true);
            CreateGridColumn(grid, "Tip", "CO26TIPDOC", 0, "", 70, true, false, true);
            CreateGridColumn(grid, "Nro Doc", "CO26NRODOC", 0, "", 90, true, false, true);
            CreateGridColumn(grid, "Fecha Doc", "CO26FECHADOC", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            CreateGridColumn(grid, "Importe S/.", "CO26IMPORTFACT", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
            CreateGridColumn(grid, "Tip Ope.Detra", "CO26TIPOPERACION", 0, "", 90, true, false, true, false, "right");
            CreateGridColumn(grid, "Tipo Detraccion", "CO26TIPOSERVICIO", 0, "", 110, true, false, true, false, "right");
            CreateGridColumn(grid, "% Detraccion", "CO26PORCENTAJE", 0, "{0:###,###0.00}", 90, true, false, false, false, "right");
            CreateGridColumn(grid, "Imp Detraccion", "CO26IMPORTEDETRA", 0, "{0:###,###0.00}", 100, true, false, true, false, "right");
            CreateGridColumn(grid, "Cta Bancaria", "CO26CTAPROVEEDOR", 0, "", 100, true, false, true);
            CreateGridColumn(grid, "Flag", "Flag", 0, "", 70, true, true, false);

            if (grid.MasterView.SummaryRows.Count == 0)
            {
                string[] fieldstosummary = { "CO26IMPORTEDETRA"};
                Util.AddGridSummarySum(grid, fieldstosummary);
            }

            grid.Rows.AddNew();
        }
        private void CrearColumnasCO5(RadGridView grid)
        {
            CreateGridColumn(grid, "Ruc", "CO05CODCTE", 0, "", 90, true, false, true);
            CreateGridColumn(grid, "Razon Social", "ccm02nom", 0, "", 150, true, false, true);
            CreateGridColumn(grid, "Tip", "CO05TIPDOC", 0, "", 70, true, false, true);
            CreateGridColumn(grid, "Nro Doc", "CO05NRODOC", 0, "", 90, true, false, true);
            CreateGridColumn(grid, "Fecha Doc", "CO05FECHA", 0, "{0:dd/MM/yyyy}", 90, true, false, true);
            CreateGridColumn(grid, "Importe S/.", "CO05IMPORT", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
            CreateGridColumn(grid, "Tip Ope.Detra", "CO05DETRATIPOPERACION", 0, "", 90, true, false, true, false, "right");
            CreateGridColumn(grid, "Tipo Detraccion", "CO05DETRATIPOSERVICIO", 0, "", 110, true, false, true, false, "right");
            CreateGridColumn(grid, "% Detraccion", "CO05DETRAPORCENTAJE", 0, "{0:###,###0.00}", 90, true, false, false, false, "right");
            CreateGridColumn(grid, "Imp Detraccion", "CO05DETRAIMPORTE", 0, "{0:###,###0.00}", 100, true, false, true, false, "right");
            CreateGridColumn(grid, "Cta Bancaria", "ccm02nroctadetraccion", 0, "", 100, true, false, true);
            CreateGridColumn(grid, "Flag", "Flag", 0, "", 70, true, true, false);
            grid.Rows.AddNew();
        }
        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
            //Grid.Columns[NameButon].BestFit();
        }
        private void frmPagoDetraccionDet_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            CrearColumnas();
          
            CargarControles(FrmParentDetraccion.Estado);
        }

        public void InsertarDetraccionDet() 
        {
            try {

                GridViewRowInfo filaparameters = gridControl.MasterView.CurrentRow;
                string[] nrodocumentos = new string[this.gridControl.SelectedRows.Count];
                

                  string CO05CODCTE = "";
                  string CO05TIPDOC = "";
                  string CO05NRODOC = "";
                int x = 0;
                foreach(GridViewRowInfo fila in this.gridControl.SelectedRows)
                {
                     CO05CODCTE = Util.GetCurrentCellText(fila, "CO05CODCTE");
                     CO05TIPDOC = Util.GetCurrentCellText(fila, "CO05TIPDOC");
                     CO05NRODOC = Util.GetCurrentCellText(fila, "CO05NRODOC");
                
                    //MessageBox.Show("CO05FECHA"+Convert.ToDateTime(Util.GetCurrentCellText(fila,"CO05FECHA")).ToString("dd/MM/yyyy"));
                    nrodocumentos[x] = CO05CODCTE + "|" +
                                        CO05TIPDOC + "|" +
                                        CO05NRODOC + "|" +
                                      Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO05FECHA")).ToString("dd/MM/yyyy") + "|" +
                                        Util.GetCurrentCellText(fila, "CO05IMPORT") + "|" +
                                        Util.GetCurrentCellText(fila, "CO05DETRATIPOPERACION") + "|" +
                                         Util.GetCurrentCellText(fila, "CO05DETRATIPOSERVICIO") + "|" +
                                         Util.GetCurrentCellText(fila, "CO05DETRAPORCENTAJE") + "|" +
                                         Util.GetCurrentCellText(fila, "CO05DETRAIMPORTE") + "|" +
                                         Util.GetCurrentCellText(fila, "ccm02nroctadetraccion");

                    x++;
                }

            string msgRetorno = "";
            string xml = Util.ConvertiraXMLdinamico(nrodocumentos);
            string insertarDetraccion = DetraccionLogic.Instance.Insertar_DetraccionDet(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, txtDetraNro.Text, txtDetFecha.Text, txtDetFechaIni.Text, txtDetFechaFin.Text, "000000000",CO05CODCTE,CO05TIPDOC,CO05NRODOC,xml,txtDetPeriodo.Text, out msgRetorno);
            //Mensaje de retorno
            Util.ShowMessage(msgRetorno, 1);
                //Actualizar Grid Detraccion
            FrmParentDetraccion.TraerDetraccion();
            }catch(Exception ex)
        {
            Util.ShowMessage("Error"+ex,1);
        }
        }
        public void TraerDetraccionesxpagar() 
        {
            try{
            List<Detraccionxpagar> ListaDetraccionxpagar = DetraccionLogic.Instance.TraeDetraccionxpagar(Logueo.CodigoEmpresa,txtDetFechaIni.Text,txtDetFechaFin.Text);
            gridControl.DataSource = ListaDetraccionxpagar;

            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        public void TraerDetraccionDet() 
        {
        
            try 
            {
                string LoteDetraNro = txtDetraNro.Text;
                DataTable ListaDetraccionDet = DetraccionLogic.Instance.TraerDetraccionDet(Logueo.CodigoEmpresa, LoteDetraNro);
                gridControl.DataSource = ListaDetraccionDet;
            }catch(Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
        }
        public string TraerLoteNro() 
        {
            string DetraccionResultado = "";
            string LoteNro = DetraccionLogic.Instance.Trae_LoteDetraccion(Logueo.CodigoEmpresa, Logueo.Anio, out DetraccionResultado);
            txtDetraNro.Text = DetraccionResultado;
            return DetraccionResultado;
        }
        
        public void CargarControles(FormEstate EstadoFrm) 
        {
            if (EstadoFrm == FormEstate.New)
            {
                TraerLoteNro();
                txtDetFecha.Value = DateTime.Now;
                txtDetFechaIni.Value = DateTime.Now;
                txtDetFechaFin.Value = DateTime.Now;
                DateTime date = DateTime.Now;
                txtDetPeriodo.Text = date.ToString("yyyyMM");
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                //HabilitaBotonPorNombre(BaseRegBotones.cbbExportar);
            }
            else if (EstadoFrm == FormEstate.View)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbExportar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
                CargarCabeceraDetraccion();
                TraerDetraccionDet();
                txtDetraNro.Enabled = false;
                txtDetFecha.Enabled = false;
                txtDetPeriodo.Enabled = false;
                txtDetFechaIni.Enabled = false;
                txtDetFechaFin.Enabled = false;
                btnFiltrar.Visible = false;
            }
        }
        protected override void OnExportar()
        {
            try
            {
                DataTable dt = DetraccionLogic.Instance.ExportarDetraccionTXT(Logueo.CodigoEmpresa, txtDetraNro.Text);

                StringBuilder StringB = new StringBuilder();
                //variables
                string Indi_Maestra = "*", Ruc_adquiriente = "", Nom_Adquiriente = "", num_lote = "", Cod_Operacion = "";
                string Tipdoc_proveedor = "", Ruc_Proveedor = "", razonsocial_proveedor = "",
                    Nro_proforma = "", Cod_Servicio = "", Cod_CtaBanco = "", Imp_Deposito = "",
                    Comprobante_Tipo = "", Comprobante_Serie = "", Comprobante_nro = "", Per_Tributario = "";

                double Imp_lote;
                GridViewRowInfo fila = FrmParentDetraccion.gridControl.MasterView.CurrentRow;
                num_lote = txtDetraNro.Text;

                Ruc_adquiriente = Logueo.rucEmpresa;
                Nom_Adquiriente = Logueo.NombreEmpresa;

                Imp_lote = Convert.ToDouble(Util.GetCurrentCellText(fila, "IMPORTETOTDET"));
                int ImpLoteEntero = Convert.ToInt32(Imp_lote* 100);

                string FormatoCebecera = Indi_Maestra + Ruc_adquiriente + Nom_Adquiriente.PadRight(35) + num_lote + FormatoCeros(ImpLoteEntero, 15);
                StringB.AppendLine(FormatoCebecera);





                //DETALLES
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Tipdoc_proveedor = Convert.ToString(dt.Rows[i]["Tipdoc_Proveedor"]);
                    Ruc_Proveedor = Convert.ToString(dt.Rows[i]["Ruc_proveedor"]);
                    razonsocial_proveedor = Convert.ToString(dt.Rows[i]["razonsocial_proveedor"]);
                    Nro_proforma = Convert.ToString(dt.Rows[i]["Nro_proforma"]);
                    Cod_Servicio = Convert.ToString(dt.Rows[i]["Cod_Servicio"]);
                    Cod_CtaBanco = Convert.ToString(dt.Rows[i]["Cod_CtaBanco"]);
                    //
                    Imp_Deposito = Convert.ToDouble(dt.Rows[i]["Imp_Deposito"]).ToString();
                    Cod_Operacion = Convert.ToString(dt.Rows[i]["Cod_Operacion"]);
                    Per_Tributario = Convert.ToString(dt.Rows[i]["Per_Tributario"]);
                    Comprobante_Tipo = Convert.ToString(dt.Rows[i]["Comprobante_Tipo"]);
                    Comprobante_Serie = Convert.ToString(dt.Rows[i]["Comprobante_Serie"]);
                    Comprobante_nro = Convert.ToString(dt.Rows[i]["Comprobante_nro"]);


                    int Imp_Int = Convert.ToInt32(Convert.ToDouble(Imp_Deposito)*100);
                    //string Formato = FormatoCeros(Imp_Int, 8);

                    //Detalles
                    StringB.AppendLine(Tipdoc_proveedor + Ruc_Proveedor + razonsocial_proveedor.PadRight(35) +
                        Nro_proforma + Cod_Servicio + Cod_CtaBanco + FormatoCeros(Imp_Int, 15) + Cod_Operacion.Replace(" ", "") + Per_Tributario +
                        Comprobante_Tipo + Comprobante_Serie + FormatoCeros(Convert.ToInt32(Comprobante_nro), 8));
                }
               
                
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (.txt)|.txt|All files (.)|.";
                sfd.Title = "Guardar Archivo texto";
                sfd.FileName = "D" + Logueo.rucEmpresa + txtDetraNro.Text;
                sfd.RestoreDirectory = true;
                string ruta = string.Empty;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ruta = sfd.FileName;
                }
                else 
                {
                    return;
                }


                System.IO.File.WriteAllText(ruta, string.Empty);
                System.IO.File.WriteAllText(ruta, StringB.ToString());
                Util.ShowMessage("Datos exportados", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no se logro la exportacion" + ex);
            }



        }
        public string FormatoCeros(float Numero, int longitudCeros) 
        {
            int longitudNumero = Numero.ToString().Length;
            int Total = longitudCeros - longitudNumero;

            string cadenareplicada = "".PadLeft(Total,Char.Parse("0")) + Numero;
            return cadenareplicada;
        }
        public void CargarCabeceraDetraccion() 
        {
            
            GridViewRowInfo fila = FrmParentDetraccion.gridControl.MasterView.CurrentRow;
            try
            {
                DateTime date = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO26FECHA"));

                txtDetraNro.Text =  Util.GetCurrentCellText(fila, "CO26NUMLOTE");
                txtDetPeriodo.Text =  date.ToString("yyyyMM");
                txtDetFecha.Value = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO26FECHA"));
                txtDetFechaIni.Value = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO26RANFECINI"));
                txtDetFechaFin.Value = Convert.ToDateTime(Util.GetCurrentCellText(fila, "CO26RANFECFIN"));
  
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar datos de cabera de documento, detalle: " + ex.Message);
            }
        }
        protected override void OnCancelar()
        {
            //FrmParentRetencion.TraerRetencion();
            this.Close();


        }
        public void TraerRetencionDetGrilla()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Spu_Com_Trae_RetencionDet> ListaRetencion = new List<Spu_Com_Trae_RetencionDet>();
            try
            {
                ListaRetencion = RetencionLogic.Instance.TraerRetencionDet(Logueo.CodigoEmpresa, txtDetraNro.Text);
              
                this.gridControl.DataSource = ListaRetencion;

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al traer datos de retencion : " + ex.Message);
            }
            
        }
        protected override void OnVista()
        {
            try
            {
                string nombreReporte = "";
                DataTable dt = new DataTable();
                string CodigoEmpresa = Logueo.CodigoEmpresa;

                string NroLote = "";
                NroLote = txtDetraNro.Text;
                nombreReporte = "RptDetraccionRes.rpt";
                dt = DetraccionLogic.Instance.TraerDetraccionDet(CodigoEmpresa, NroLote);
                List<Paramentro> parametros = new List<Paramentro>();
                Reporte reporte = new Reporte("Documento");
                reporte.Ruta = Logueo.GetRutaReporte();
                reporte.Nombre = nombreReporte;
                reporte.DataSource = dt;
                ReporteControladora control = new ReporteControladora(reporte);
                control.VistaPrevia(enmWindowState.Normal);
            }
            catch(Exception ex)
            {
                Util.ShowError("ERROR :: "+ex.Message);
            }
        }
        protected override void OnGuardar()
        {
            if (gridControl.Rows.Count == 0) {
                Util.ShowAlert("ERROR:: No hay Detraccion para insertar");
                    return;
            }
            InsertarDetraccionDet();
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbExportar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbVistaPrevia);
            txtDetraNro.Enabled = false;
            txtDetFecha.Enabled = false;
            txtDetPeriodo.Enabled = false;
            txtDetFechaIni.Enabled = false;
            txtDetFechaFin.Enabled = false;
            btnFiltrar.Visible = false;
            //Cargar grilla con ColumnaCO26
            RadGridView grid = CreateGridVista(gridControl);
            grid.EnableFiltering = false;
            CrearColumnasCO26(grid);
            TraerDetraccionDet();
           
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            TraerDetraccionesxpagar();
        }
    }
}
