using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Inv.BusinessEntities;
using Inv.BusinessLogic;
namespace Inv.UI.Win
{
    public partial class frmImportarMovProd : frmBase
    {
    //    public frmImportarMovProd()
    //    {
    //        InitializeComponent();
    //    }
        public frmImportarMovProd(frmMDI padre) { 
            InitializeComponent();
        }
        public static frmImportarMovProd formulario;
        private frmMDI FrmParent { get; set; }
        private static frmImportarMovProd _aForm;
        public static frmImportarMovProd Instance(frmMDI mdiPrincipal) 
        {
            if(_aForm != null) return new frmImportarMovProd(mdiPrincipal);
            _aForm = new frmImportarMovProd(mdiPrincipal);
            return _aForm;
        }
        protected override void OnRefrescar()
        {
            RadMessageBox.Show("Refrescado", "Sistema", 
                                MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        private void CrearColumnasImportacion() { 
            
        }
        #region "Procesar Movimientos"
        ImportarMovimientos importacion = new ImportarMovimientos();
        private void InsertarMovimiento() 
        {
            OpenFileDialog opf = new OpenFileDialog();
            string filename = "";
            try
            {
                if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
                {
                    filename = opf.FileName;
                }
                else return;
                //Eliminar los registro de la tabla de importador( registor temporales)
                string mensaje = string.Empty;
                DocumentoLogic.Instance.EliminarMovimientosImportados(Logueo.CodigoEmpresa, Logueo.UserName, "COSTOS");
                System.IO.StreamReader sr = new System.IO.StreamReader(filename, Encoding.Default);
                while (!sr.EndOfStream) 
                {
                    string[] lineas = sr.ReadLine().Split('|');
                    //Cabecera documento
                        importacion.FLAG = lineas[1];
                        if (lineas[1] == "C")
                        {
                        importacion.IN07CODEMP = lineas[2];
                        importacion.IN07TIPDOC = lineas[3];
                        importacion.IN07CODDOC = lineas[4];
                        importacion.IN07FECDOC = lineas[5];
                        importacion.IN07TRANSA = lineas[6];
                        importacion.IN06REFDOC = lineas[7];
                        importacion.IN06CODPRO = lineas[8];//Codigo de proveedor
                        importacion.IN06MONEDA = lineas[9];
                        //Produccion
                        importacion.IN06MAQUINA = lineas[17];
                        importacion.in06prodlineacod = lineas[18];
                        importacion.in06prodActiNivel1Cod = lineas[19];
                        importacion.in06prodTurnoCod = lineas[20];
                        importacion.IN06CANTERACOD = lineas[21];
                        importacion.IN06CONTRATISTACOD = lineas[22];
                        importacion.IN06PRODNATURALEZA = lineas[23];
                        importacion.IN06ORIGENTIPO = lineas[24];
                        importacion.IN07AA = lineas[25];
                        importacion.IN07MM = lineas[26];

                        //ordne de produccion
                        
                        //Detalle de documento
                        
                        DocumentoLogic.Instance.InsertarMovimientosImportados(importacion, out mensaje);
                        }
                        else if (lineas[1] == "D") {
                            importacion.FLAG = lineas[1];
                            importacion.IN07CODEMP = lineas[2];
                            importacion.IN07AA = lineas[3];
                            importacion.IN07MM = lineas[4];
                            importacion.IN07TIPDOC = lineas[5];
                            importacion.IN07CODDOC = lineas[6];
                            importacion.IN07KEY = lineas[7];
                            importacion.IN07ORDEN = Convert.ToDouble(lineas[8]);
                            importacion.IN07UNIMED = lineas[9];
                            importacion.IN07FECDOC = lineas[10];
                            importacion.IN07CODALM = lineas[11];
                            importacion.IN07CODTRA = lineas[12];
                            importacion.IN07TRANSA = lineas[13];
                            importacion.IN07CANART = Convert.ToInt32(lineas[14]);
                            importacion.IN07IMPORT = Convert.ToDouble(lineas[17]);
                            //importacion.
                            //DocumentoLogic.Instance.InsertarMovimientosImportados(importacion, out mensaje);
                        }
                   
                }
            }
            catch (Exception ex) { 
            
            }
        }

        private void btnMovImp_Click(object sender, EventArgs e)
        {
            InsertarMovimiento();
        }
        //private void InsertarMovimientos() 
        //{
        //    OpenFileDialog opf = new OpenFileDialog();
        //    string filename = "";
        //    try
        //    {
        //        if (opf.ShowDialog() == DialogResult.OK && opf.FileName.Length > 0)
        //        {
        //            filename = opf.FileName;
        //        }
        //        else return;
        //        //Eliminar los registro de la tabla de importador( registor temporales)
        //        string mensaje = string.Empty;
        //        DocumentoLogic.Instance.EliminarMovimientosImportados(Logueo.CodigoEmpresa, Logueo.UserName, "COSTOS");

        //        System.IO.StreamReader sr = new System.IO.StreamReader(filename, Encoding.Default);
        //                while (!sr.EndOfStream) 
        //                {
        //                    string[] lineas = sr.ReadLine().Split('|');
        //                    importacion.FLAG = lineas[1];
        //                    //--Cabecera de dooducmento -- //
        //                    importacion.IN07CODEMP = lineas[2];
        //                    importacion.IN07TIPDOC = lineas[3];
        //                    importacion.IN07CODDOC = lineas[4];
        //                    importacion.IN07FECDOC = lineas[5];
        //                    importacion.IN07TRANSA = lineas[6];
        //                    importacion.IN06REFDOC = lineas[7];
        //                    importacion.IN06CODPRO = lineas[8]; // Proveedor
        //                    importacion.IN06MONEDA = lineas[9];
        //                    //Datos de Producccion
        //                    importacion.IN06MAQUINA = lineas[17];
        //                    importacion.in06prodlineacod = lineas[18];
        //                    importacion.in06prodActiNivel1Cod = lineas[19];
        //                    importacion.in06prodTurnoCod = lineas[20];
        //                    importacion.IN06CANTERACOD = lineas[21];
        //                    importacion.IN06CONTRATISTACOD = lineas[22];
        //                    importacion.IN06PRODNATURALEZA = lineas[23];
        //                    importacion.IN06ORIGENTIPO = lineas[24};
        //                }
        
                
        //    }
        //    catch (Exception ex) {
        //        RadMessageBox.Show(ex.Message);
        //    }
        //}
        #endregion
    }
}
