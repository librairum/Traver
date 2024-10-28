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
namespace Cos.UI.Win
{
    public partial class frmImpProdMovi : frmBase
    {
        private frmMDI FrmParent { get; set; }
        private static frmImpProdMovi _aForm;
        public frmImpProdMovi(frmMDI padre) {
            InitializeComponent();
            HabilitarBotones(false, false, false, false, false, false, false, true);
            this.rpImportacion.SendToBack();
            this.rpImportacion.Visible = false;
            CrearColumnas();
            CrearColumnasImportacion();
            OnBuscar();
            
        }
        public static frmImpProdMovi Instance(frmMDI mdiPrincipal) {
            if (_aForm != null) return new frmImpProdMovi(mdiPrincipal);
            _aForm = new frmImpProdMovi(mdiPrincipal);
            return _aForm;
        }


        private void CrearColumnas() 
        { 
        
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "Empresa", "COS01CODEMP", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Anio", "COS01ANIO", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Mes", "COS01MES", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Cod.Linea", "COS01LINEA", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Cod.Lote", "COS01LOTE", 0, "", 70, true, false, false);            
            this.CreateGridColumn(Grid, "Mov.Anio", "COS01MOVIPRODAA", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Mov.Mes", "COS01MOVIPRODMM", 0, "", 70, true, false, false);
            
            this.CreateGridColumn(Grid, "Fecha", "COS01FECDOC", 0, "{0:dd/MM/yyyy}", 70);
            this.CreateGridColumn(Grid, "TipDoc", "COS01MOVIPRODTIPDOC", 0, "", 90);
            this.CreateGridColumn(Grid, "Cod.Tran", "COS01CODTRA", 0, "", 80);
            this.CreateGridColumn(Grid, "Transaccion", "COS01TRANSA", 0, "", 50);

            this.CreateGridColumn(Grid, "CodDoc", "COS01MOVIPRODCODDOC", 0, "", 90);
            this.CreateGridColumn(Grid, "NroCaja", "COS01NROCAJA", 0, "", 70);
            this.CreateGridColumn(Grid, "Cod.Alm", "COS01CODALM", 0, "", 70);
            this.CreateGridColumn(Grid, "Cod.Prod", "COS01MOVIPRODKEY", 0, "", 200);
            this.CreateGridColumn(Grid, "Uni.Med", "COS01UNIMED", 0, "", 70);

            this.CreateGridColumn(Grid, "Orden", "COS01MOVIPRODORDEN", 0, "", 50, true, false, false);                
            this.CreateGridColumn(Grid, "Cod.Linea", "COS01PRODLINEACOD", 0, "", 70);                 
            this.CreateGridColumn(Grid, "Cod.Act.", "COS01RODACTNIV1COD", 0, "", 70);    
            
            this.CreateGridColumn(Grid, "OT", "COS01ORDENTRABAJO", 0, "", 60);          
            this.CreateGridColumn(Grid, "Naturaleza", "COS01PRODNATURALEZA", 0, "", 70, true, false, false);                
                                    
            this.CreateGridColumn(Grid, "COS01COSUNI", "COS01COSUNI", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01COUNSO", "COS01COUNSO", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01COUNDO", "COS01COUNDO", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS03IMPORT", "COS03IMPORT", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01IMPSOL", "COS01IMPSOL", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01IMPDOL", "COS01IMPDOL", 0, "", 70, true, false, false);

            this.CreateGridColumn(Grid, "Largo", "COS01LARGO", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            this.CreateGridColumn(Grid, "Ancho", "COS01ANCHO", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            this.CreateGridColumn(Grid, "Alto", "COS01ALTO", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            this.CreateGridColumn(Grid, "Cantidad", "COS01CANART", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            this.CreateGridColumn(Grid, "Area", "COS01AREA", 0, "{0:###,###0.00}", 70, true, false, true, "right");
            this.CreateGridColumn(Grid, "Volumen", "COS01VOLUMEN", 0, "{0:###,###0.00}", 70, true, false, true, "right");

            this.CreateGridColumn(Grid, "COS01DocIngAA", "COS01DocIngAA", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngMM", "COS01DocIngMM", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngTIPDOC", "COS01DocIngTIPDOC", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngCODDOC", "COS01DocIngCODDOC", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngKEY", "COS01DocIngKEY", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngORDEN", "COS01DocIngORDEN", 0, "{0:###,###0.00}", 70, true, false, false);

            this.CreateGridColumn(Grid, "AreaxUni", "COS01AREAXUNI", 0, "{0:###,###0.000000}", 70, true, false, false, "right");

            string[] fieldstosummary = { "COS01CANART", "COS01AREA", "COS01VOLUMEN"};
            Util.AddGridSummarySum(Grid, fieldstosummary);
        }

        private void OnBuscarImportacion()
        {
            
            this.gridImportacion.DataSource = DocumentoLogic.Instance.TraeMovimientosProduccionImp(Logueo.CodigoEmpresa,
                                                Logueo.Anio, Logueo.Mes, Logueo.UserName);
        }
        protected override void OnBuscar(){
            //Traer movimiento de produccion
            List<MovimientosProduccion> lista = DocumentoLogic.Instance.TraerImportarMovimientosProduccion(Logueo.CodigoEmpresa,
                                                            Logueo.Anio, Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto);
            this.gridControl.DataSource = lista;
        }
        #region "Importacion"
        private void CrearColumnasImportacion()
        { 
             RadGridView Grid = this.CreateGridVista(this.gridImportacion);
            this.CreateGridColumn(Grid, "Empresa", "COS01CODEMP", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Anio", "COS01ANIO", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Mes", "COS01MES", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Cod.Linea", "COS01LINEA", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Cod.Lote", "COS01LOTE", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Mov.Anio", "COS01MOVIPRODAA", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Mov.Mes", "COS01MOVIPRODMM", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Mov.TipDoc", "COS01MOVIPRODTIPDOC", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Mov.CodDoc", "COS01MOVIPRODCODDOC", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Mov.Producto", "COS01MOVIPRODKEY", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Mov.Orden", "COS01MOVIPRODORDEN", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Prod.Linea", "COS01PRODLINEACOD", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "ActNivel1", "COS01RODACTNIV1COD", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "Orden Trabajo", "COS01ORDENTRABAJO", 0, "", 70, true, false, false);            
            this.CreateGridColumn(Grid, "Prod.Naturaleza", "COS01PRODNATURALEZA", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "UniMed", "COS01UNIMED", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Fec.Doc", "COS01FECDOC", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Cod.Alm", "COS01CODALM", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Cod.Tra", "COS01CODTRA", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Transa", "COS01TRANSA", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "Cantidad", "COS01CANART", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "COS01COSUNI", "COS01COSUNI", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01COUNSO", "COS01COUNSO", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01COUNDO", "COS01COUNDO", 0, "", 70, true, false, false);            
            this.CreateGridColumn(Grid, "Importe", "COS03IMPORT", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01IMPSOL", "COS01IMPSOL", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01IMPDOL", "COS01IMPDOL", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01LARGO", "COS01LARGO", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "COS01ANCHO", "COS01ANCHO", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "COS01ALTO", "COS01ALTO", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "COS01NROCAJA", "COS01NROCAJA", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngAA", "COS01DocIngAA", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngMM", "COS01DocIngMM", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngTIPDOC", "COS01DocIngTIPDOC", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngCODDOC", "COS01DocIngCODDOC", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngKEY", "COS01DocIngKEY", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01DocIngORDEN", "COS01DocIngORDEN", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01AREAXUNI", "COS01AREAXUNI", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01AREA", "COS01AREA", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01VOLUMEN", "COS01VOLUMEN", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01COSPROMSOL", "COS01COSPROMSOL", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01COSPROMDOL", "COS01COSPROMDOL", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01FLAG", "COS01FLAG", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01ERRORES", "COS01ERRORES", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01CANTERRORES", "COS01CANTERRORES", 0, "", 70, true, false, false);
            this.CreateGridColumn(Grid, "COS01CODIGOUSUARIO", "COS01CODIGOUSUARIO", 0, "", 70, true, false, true);
            this.CreateGridColumn(Grid, "COS01SISTEMA", "COS01SISTEMA", 0, "", 70, true, false, true);
        }
        protected override void OnImportar()
        {
            if (this.gridControl.Rows.Count == 0)
            {
                IniciarModal();
            }
            else
            {
                DialogResult res;
                ShowAlertQuestion("Sistema", "Los registros contables se eliminara despues de importar, " +
                                    "¿Desea continuar?", out res);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    IniciarModal();
                }
                else
                {
                    CerrarModal();
                }
            }
        }
        private bool ValidarImportacion(){
            if (this.gridImportacion.Rows.Count == 0) {
                ShowAlertExclamation("Sistema", "No tiene movimiento para guardar");
                return false;
            }
            return true;
        }
        private void IniciarModal() {
            this.rpImportacion.Visible = true;
            this.gridImportacion.Rows.Clear();            
            this.rpImportacion.BringToFront();
            
        }
        private void CerrarModal() {
            this.rpImportacion.Visible = false;
            this.gridImportacion.Rows.Clear();
            this.rpImportacion.SendToBack();
        }
        //private void OnBuscarImportacion() { }
        #endregion

        private void btnSalirImprotacion_Click(object sender, EventArgs e)
        {
            CerrarModal();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            MovimientosProduccion mov = new MovimientosProduccion();
            if (rbImportarArchivo.CheckState == CheckState.Checked)
            {
                importaciontexto();
            }
            else if (rbImportarDirecto.CheckState == CheckState.Checked) { 
                //Ejecutar procedimeinto y llenar en la tabla de vista temporal
                
            }
            OnBuscarImportacion();
        }
        private void importaciontexto()
        {
            MovimientosProduccion mov = new MovimientosProduccion();
            mov.COS01CODEMP = Logueo.CodigoEmpresa;
            mov.COS01ANIO = Logueo.Anio;
            mov.COS01MES = Logueo.Mes;
            mov.COS01LINEA = Logueo.CodigoLinea;
            mov.COS01LOTE = Logueo.CodigoLoteCosto;
            mov.COS01CODIGOUSUARIO = Logueo.UserName;
            mov.COS01SISTEMA = Logueo.nomModulo;

            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                string fc = "";
                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    fc = opf.FileName;
                }
                else return;
                string mensaje = string.Empty;
                DocumentoLogic.Instance.EliminarMovProduccionImp(Logueo.CodigoEmpresa, Logueo.UserName, Logueo.nomModulo, out mensaje);
                var sr = new System.IO.StreamReader(fc, Encoding.Default);
                string mensaje2 = string.Empty;
                int flag = 0;
                Cursor.Current = Cursors.WaitCursor;
                while (!sr.EndOfStream)
                {
                    string currentline = sr.ReadLine();
                    if (!string.IsNullOrEmpty(currentline))
                    {
                        string[] linea = currentline.Split('|');
                        mov.COS01MOVIPRODAA = Util.convertiracadena(linea[0]);
                        mov.COS01MOVIPRODMM = Util.convertiracadena(linea[1]);
                        mov.COS01MOVIPRODTIPDOC = Util.convertiracadena(linea[2]);
                        mov.COS01MOVIPRODCODDOC = Util.convertiracadena(linea[3]);
                        mov.COS01MOVIPRODKEY = Util.convertiracadena(linea[4]);
                        mov.COS01MOVIPRODORDEN = Convert.ToDouble(Util.convertiracero(linea[5]));
                        mov.COS01PRODLINEACOD = Util.convertiracadena(linea[6]);
                        mov.COS01RODACTNIV1COD = Util.convertiracadena(linea[7]);
                        mov.COS01ORDENTRABAJO = Util.convertiracadena(linea[8]);
                        mov.COS01PRODNATURALEZA = Util.convertiracadena(linea[9]);
                        mov.COS01UNIMED = Util.convertiracadena(linea[10]);

                        mov.COS01FECDOC = Convert.ToDateTime(Util.convertiracadena(linea[11]));
                        mov.COS01CODALM = Util.convertiracadena(linea[12]);
                        mov.COS01CODTRA = Util.convertiracadena(linea[13]);
                        mov.COS01TRANSA = Util.convertiracadena(linea[14]);
                        mov.COS01CANART = Util.convertiracadena(linea[15]);
                        mov.COS01COSUNI = Util.convertiracadena(linea[16]);
                        mov.COS01COUNSO = Util.convertiracadena(linea[17]);
                        mov.COS01COUNDO = Util.convertiracadena(linea[18]);
                        mov.COS03IMPORT = Util.convertiracadena(linea[19]);
                        mov.COS01IMPSOL = Util.convertiracadena(linea[20]);
                        mov.COS01IMPDOL = Util.convertiracadena(linea[21]);
                        mov.COS01LARGO = Convert.ToDouble(Util.convertiracero(linea[22]));
                        mov.COS01ANCHO = Convert.ToDouble(Util.convertiracero(linea[23]));
                        mov.COS01ALTO = Convert.ToDouble(Util.convertiracero(linea[24]));
                        mov.COS01NROCAJA = Util.convertiracadena(linea[25]);
                        mov.COS01DocIngAA = Util.convertiracadena(linea[26]);
                        mov.COS01DocIngMM = Util.convertiracadena(linea[27]);
                        mov.COS01DocIngTIPDOC = Util.convertiracadena(linea[28]);
                        mov.COS01DocIngCODDOC = Util.convertiracadena(linea[29]);
                        mov.COS01DocIngKEY = Util.convertiracadena(linea[30]);
                        mov.COS01DocIngORDEN = Convert.ToDouble(Util.convertiracero(linea[31]));
                        mov.COS01AREAXUNI = Convert.ToDouble(Util.convertiracero(linea[32]));
                        mov.COS01AREA = Convert.ToDouble(Util.convertiracero(linea[33]));
                        mov.COS01VOLUMEN = Convert.ToDouble(Util.convertiracero(linea[34]));
                        mov.COS01COSPROMSOL = Convert.ToDouble(Util.convertiracero(linea[35]));
                        mov.COS01COSPROMDOL = Convert.ToDouble(Util.convertiracero(linea[36]));
                        DocumentoLogic.Instance.InsertarMovProduccionImp(mov, out flag, out mensaje2);
                    }
                }
                OnBuscarImportacion();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
 
           
           
        }
        private void btnProcesarImportacion_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = string.Empty;
                int flag = 0;
                if (rbImportarArchivo.CheckState == CheckState.Checked) {
                     //Traer movimiento desde archivo de texto
                    //if (!ValidarImportacion()) return;
                    if (this.gridImportacion.Rows.Count == 0)
                    {
                        ShowAlertError("Sistema", "No tiene datos importados para guardar"); 
                        return;
                    }
                    DocumentoLogic.Instance.GuardarMovProduccionImp(Logueo.CodigoEmpresa, Logueo.Anio,
                                                    Logueo.Mes, Logueo.CodigoLinea, Logueo.CodigoLoteCosto,Logueo.UserName, out flag, out mensaje);

                    if (flag == 0)
                    {
                        ShowAlertOk("Sistema", mensaje);
                        this.gridImportacion.Rows.Clear();
                        this.rpImportacion.Hide();
                        OnBuscar();
                        

                    }
                    else if (flag == -1)
                    {
                        ShowAlertError("Sistema", mensaje);
                    }
                }
                else if (rbImportarDirecto.CheckState == CheckState.Checked) { 
                    //Ejecutar Procedimiento 
                    DocumentoLogic.Instance.ImportarMovimientosProduccion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, Logueo.CodigoLinea,
                        Logueo.CodigoLoteCosto, out mensaje, out flag);
                    if (flag == 1)
                    {
                        // Si ooperacion fue exitoso 
                        ShowAlertOk("Sistema", mensaje);
                        //limpiar grilla de importacion

                        this.gridImportacion.Rows.Clear();
                        //oculta el panel de importacion
                        this.rpImportacion.Hide();
                        //refrescarha grilla de Gastos Contables
                        OnBuscar();
                    }
                    else
                    {
                        // Si op0eracion no fue exitoso
                        ShowAlertError("sistema", mensaje);
                    }
                }
               

            }
            catch (Exception ex)
            {
                ShowAlertError("Sistema", ex.Message);
            }
        }

        private void rbImportarDirecto_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.rbImportarArchivo.CheckState == CheckState.Checked)
            {
                this.btnImportar.Visible = true;
            }
            else
            {
                this.btnImportar.Visible = false;
            }
        }
        private Point MouseDownLocation;
        private void rpImportacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void rpImportacion_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rpImportacion.Left = e.X + rpImportacion.Left - MouseDownLocation.X;
                //this.Left = e.X + this.Left - MouseDownLocation.X;
                rpImportacion.Top = e.Y + rpImportacion.Top - MouseDownLocation.Y;
                //this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }
    }
}
