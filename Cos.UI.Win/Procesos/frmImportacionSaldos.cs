using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Inv.BusinessLogic;
using Inv.BusinessEntities;

namespace Cos.UI.Win
{
    public partial class frmImportacionSaldos : frmBase
    {
        private frmMDI FrmParent { get; set; }
        private static frmImportacionSaldos _aForm;

        public frmImportacionSaldos(frmMDI padre)
        {
            InitializeComponent();
            HabilitarBotones(false, false, false, false, false, false, false, true);
            ocultarimportacion();
            CrearColumnas();
            CrearColumnasImportacion();
            OnBuscar();

        }

        private void CrearColumnas()
        {
            RadGridView Grid = this.CreateGridVista(this.gridControl);
            this.CreateGridColumn(Grid, "Empresa", "COS02CODEMP", 0, "", 90);              
            this.CreateGridColumn(Grid, "Anio", "COS02ANIO", 0, "", 90);                
            this.CreateGridColumn(Grid, "Mes", "COS02MES", 0, "", 90);        
            this.CreateGridColumn(Grid, "Cod.Almacen", "COS02ALMACOD", 0, "", 90);        
            this.CreateGridColumn(Grid, "Cod.Producto", "COS02PRODCOD", 0, "", 90);
            this.CreateGridColumn(Grid, "Prod.Cantidad", "COS02PRODCANTIDAD", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            this.CreateGridColumn(Grid, "Prod.Area", "COS02PRODAREA", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            this.CreateGridColumn(Grid, "Prod.Volumen", "COS02PRODVOLUMEN", 0, "{0:###,###0.00}", 90, true, false, true, "right");        
            this.CreateGridColumn(Grid, "Prod.Imp", "COS02PRODIMPSOL", 0, "", 90);
            this.CreateGridColumn(Grid, "Cod.Linea", "COS02LINEACOD", 0, "", 90);        
            this.CreateGridColumn(Grid, "Cod.Actividad", "COS02ACTCOD", 0, "", 90);
        }
        private void ocultarimportacion()
        {
            this.rpImportacion.SendToBack();
            this.rpImportacion.Visible = false;
            this.gridImportacion.Rows.Clear();
        }
        protected override void OnImportar()
        {
            mostrarimportacion();
        }
        
        private void procesardirecto()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ProduccionSaldoLogic.Instance.ImportarDirectoProduccionSaldo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
                ocultarimportacion();
                OnBuscar();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        
        #region "Importacion"
        private void OnBuscarImportacion()
        {
            List<ProduccionSaldo> lista =  ProduccionSaldoLogic.Instance.TraeSaldoProduccionImportar(Logueo.CodigoEmpresa, 
                                            Logueo.Anio, Logueo.Mes, Logueo.UserName, Logueo.nomModulo);
            this.gridImportacion.DataSource = lista;
        }
        private void leerarchivotexto()
        {
            ProduccionSaldo saldo = new ProduccionSaldo();
            saldo.COS02CODEMP = Logueo.CodigoEmpresa;
            saldo.COS02ANIO = Logueo.Anio;
            saldo.COS02MES = Logueo.Mes;

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
                int flag = 0;
                Cursor.Current = Cursors.WaitCursor;
                ProduccionSaldoLogic.Instance.EliminarProduccionSaldoArchivo(Logueo.CodigoEmpresa, Logueo.Anio,
                    Logueo.Mes, Logueo.UserName, Logueo.nomModulo, out flag, out mensaje);
                var sr = new System.IO.StreamReader(fc, Encoding.Default);
                //if (flag == 0)
                //{
                //    ShowAlertOk("Sistemas", mensaje);
                //}
                //else if (flag == -1)
                //{
                //    ShowAlertError("Sistema", mensaje);
                //    return;
                //}

               
                while (!sr.EndOfStream)
                {

                    string[] linea = sr.ReadLine().Split('|');
                    saldo.COS02ALMACOD = Util.convertiracadena(linea[0]);
                    saldo.COS02PRODCOD = Util.convertiracadena(linea[1]);
                    saldo.COS02PRODCANTIDAD = Convert.ToDouble(Util.convertiracero(linea[2]));
                    saldo.COS02PRODAREA = Convert.ToDouble(Util.convertiracero(linea[3]));
                    saldo.COS02PRODVOLUMEN = Convert.ToDouble(Util.convertiracero(linea[4]));
                    saldo.COS02PRODIMPSOL = Convert.ToDouble(Util.convertiracero(linea[5]));
                    saldo.COS02LINEACOD = Util.convertiracadena(linea[6]);
                    saldo.COS02ACTCOD = Util.convertiracadena(linea[7]);
                    saldo.COS01FLAG = "";
                    saldo.COS01ERRORES = "";
                    saldo.COS01CANTERRORES = 0;
                    saldo.COS01CODIGOUSUARIO = Logueo.UserName;
                    saldo.COS01SISTEMA = Logueo.nomModulo;
                    ProduccionSaldoLogic.Instance.InsertarProduccionSaldoArchivo(saldo, out flag, out mensaje);
                    //if (flag == 0)
                    //{
                    //    //ShowAlertOk("Sistema", mensaje);
                    //    //OnBuscarImportacion();
                    //}
                    //else if (flag == -1)
                    //{
                    //    ShowAlertError("Sistema", mensaje);
                    //    return;
                    //}
                }

                

                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                ShowAlertError("Sistema", ex.Message);
            }
        }
        private void procesararchivotexto()
        {

            int flag = 0;
            string mensaje = "";
            ProduccionSaldoLogic.Instance.InsertarProduccionSaldoImp(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                                                                      Logueo.UserName, Logueo.nomModulo, out flag, out mensaje);
            if (flag == 0)
            {
                ShowAlertOk("Sistema", mensaje);
                OnBuscar();
                ocultarimportacion();
            }
            else if (flag == -1)
            {
                ShowAlertError("Sistema", mensaje);
            }
            
        }

        private void CrearColumnasImportacion()
        {
            RadGridView Grid = this.CreateGridVista(this.gridImportacion);
            this.CreateGridColumn(Grid, "Empresa", "COS02CODEMP", 0, "", 90);
            this.CreateGridColumn(Grid, "Anio", "COS02ANIO", 0, "", 90);
            this.CreateGridColumn(Grid, "Mes", "COS02MES", 0, "", 90);
            this.CreateGridColumn(Grid, "Alm.Codigo", "COS02ALMACOD", 0, "", 90);
            this.CreateGridColumn(Grid, "Prod.Codigo", "COS02PRODCOD", 0, "", 90);
            this.CreateGridColumn(Grid, "Prod.Cant", "COS02PRODCANTIDAD", 0, "", 90);
            this.CreateGridColumn(Grid, "Prod.Area", "COS02PRODAREA", 0, "{0:###,###0.00}", 90);
            this.CreateGridColumn(Grid, "Prod.Volumen", "COS02PRODVOLUMEN", 0, "{0:###,###0.00}", 90);
            this.CreateGridColumn(Grid, "Prod.Imp", "COS02PRODIMPSOL", 0, "", 90);
            this.CreateGridColumn(Grid, "Linea.Codigo", "COS02LINEACOD", 0, "", 90);
            this.CreateGridColumn(Grid, "Act.Codigo", "COS02ACTCOD", 0, "", 90);
            this.CreateGridColumn(Grid, "Usuario", "COS01CODIGOUSUARIO", 0, "", 90);
            this.CreateGridColumn(Grid, "Sistema", "COS01SISTEMA", 0, "", 90);
                       
        }
        #endregion
        private void mostrarimportacion()
        {
            this.rpImportacion.BringToFront();
            this.rpImportacion.Visible = true;
        }
        public static frmImportacionSaldos Instance(frmMDI mdiPrincipal)
        {
            if (_aForm != null) return new frmImportacionSaldos(mdiPrincipal);
            _aForm = new frmImportacionSaldos(mdiPrincipal);
            return _aForm;
        }
        protected override void OnBuscar()
        {
            List<ProduccionSaldo> lista =  ProduccionSaldoLogic.Instance.Trae_ProduccionSaldo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes);
            this.gridControl.DataSource = lista;

        }

        private void btnProcesarImportacion_Click(object sender, EventArgs e)
        {
            if (rbImportarDirecto.CheckState == CheckState.Checked)
            {
                procesardirecto();
            }
            else if (rbImportarArchivo.CheckState == CheckState.Checked)
            {
                if (this.gridImportacion.Rows.Count == 0)
                {
                    ShowAlertError("Sistema","No tiene registros para importar");
                    return;
                }
                procesararchivotexto();
            }


        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            leerarchivotexto();
            OnBuscarImportacion();
        }

        private void btnSalirImprotacion_Click(object sender, EventArgs e)
        {
            ocultarimportacion();

        }

        private void rpImportacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private Point MouseDownLocation;
        private void rpImportacion_MouseMove(object sender, MouseEventArgs e)
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
