using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Inv.BusinessLogic;
using Inv.BusinessEntities;
using Telerik.WinControls.UI.Docking;
using System.Diagnostics;
using System.IO;
namespace Fac.UI.Win
{
    public partial class frmPackingList : frmBase
    {
        private static frmPackingList _aForm;
        private frmMDI frmParent { get; set; }
        public static frmPackingList Instance(frmMDI padre)
        {
            if (_aForm != null) return new frmPackingList(padre);
            _aForm = new frmPackingList(padre);
            return _aForm;
        }

        private bool PermitirOperacionPorPerfil(string codigoPerfil)
        {
            bool aceptaOperacion = true;
            //16 perfil facturacionLima
            if (codigoPerfil != "08")
            {
                aceptaOperacion = true;
            }
            else {
                aceptaOperacion = false;
            }
            return aceptaOperacion;
        }
        public frmPackingList(frmMDI padre)
        {
            InitializeComponent();
            frmParent = padre;
        }
        private void frmPackingList_Load(object sender, EventArgs e)
        {
            OcultarImportacion();
            OcultarBotones();
            //Validar el perfil debe ser facturacion huaral
            if (PermitirOperacionPorPerfil(Logueo.codigoPerfil) == false)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
                HabilitaBotonPorNombre(BaseRegBotones.cbbImportar);
                RenombrarNombreBoton(BaseRegBotones.cbbImportar, "Exportar packing");
            }
            else
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbVer);
                HabilitaBotonPorNombre(BaseRegBotones.cbbImportar);
                RenombrarNombreBoton(BaseRegBotones.cbbImportar, "Importar packing");
            }
                        
            RenombrarNombreBoton(BaseRegBotones.cbbGeneraPDF, "Certificado de origen");
            

            CrearColumnas();
            CrearColumnasValidacion();
            Cargar();
        }
   
        private void CrearColumnasValidacion()
        {
            RadGridView Grid = CreateGridVista(this.gridValidacion);
            CreateGridColumn(Grid, "CantErrores", "CANTERRORES", 0, "", 90);
            CreateGridColumn(Grid, "Erroes", "ERRORES", 0, "", 150);
            CreateGridColumn(Grid, "FAC60CODEMP", "FAC60CODEMP", 0, "", 70, true, false, false); //oculto
            CreateGridColumn(Grid, "Num.Doc", "FAC60NUMERO", 0, "", 70);
            CreateGridColumn(Grid, "Anio", "FAC60AA", 0, "", 70);
            CreateGridColumn(Grid, "Mes", "FAC60MM", 0, "", 70);
            CreateGridColumn(Grid, "FAC60FECHA", "FAC60FECHA", 0, "", 70, true, false, false); // oculto
            CreateGridColumn(Grid, "Cliente", "FAC60CLIENTECOD", 0, "", 70);
            CreateGridColumn(Grid, "FAC60CONTAINERNRO", "FAC60CONTAINERNRO", 0, "", 70, true, false, false);//oculto
            CreateGridColumn(Grid, "FAC60PRECINTONROS", "FAC60PRECINTONROS", 0, "", 70, true, false, false); //oculto
            CreateGridColumn(Grid, "FAC61ITEM", "FAC61ITEM", 0, "", 70, true, false, false);//oculto
            CreateGridColumn(Grid, "FAC61SECUENCIA", "FAC61SECUENCIA", 0, "", 70, true, false, false); //oculto
            CreateGridColumn(Grid, "FAC61PRODCODCLIENTE", "FAC61PRODCODCLIENTE", 0, "", 70, true, false, false); // oculto
            CreateGridColumn(Grid, "Prod.Codi", "FAC61PRODCODEMPRESA", 0, "", 90);
            CreateGridColumn(Grid, "Prod.Desc", "FAC61PRODDESCRIPCION", 0, "", 120);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 70);
            CreateGridColumn(Grid, "codigousuario", "codigousuario", 0, "", 70); //oculto
            CreateGridColumn(Grid, "sistema", "sistema", 0, "", 70); //oculto
		 
        }
        private void CargarValidacion()
        {
            gridValidacion.DataSource = PackingListLogic.Instance.TraeValidacionImportacion(Logueo.CodigoEmpresa, Logueo.Anio,
                                        Logueo.Mes, Logueo.nombreModulo, Logueo.UserName); 
        }
        internal void Cargar()
        {
            try
            {
                gridControl.DataSource = PackingListLogic.Instance.TraePackingList(Logueo.CodigoEmpresa, 
                                                                                Logueo.Anio, Logueo.Mes);
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar grilla: " + ex.Message);
            }
        }
        private void EliminarPackingList()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar packing list : " + ex.Message);
            }
        }
        protected override void OnEliminar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {


                string numeroDocumento = "";
                int flag = 0; string mensaje = "";

                bool respuesta = Util.ShowQuestion("¿Desea eliminar el registro?");
                if (respuesta == false) { return; }

               
                numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "NumeroDocumento");
                

                PackingListLogic.Instance.EliminaPackingList(Logueo.CodigoEmpresa, numeroDocumento,
                out flag, out mensaje);

                Util.ShowMessage(mensaje, flag);

                if (flag == 1)
                {
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al eliminar :" + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        protected override void OnNuevo()
        {
          

            Cursor.Current = Cursors.WaitCursor;
            // Inicio el constructor

            var frmInstance = frmPackingListDet.Instance(this);
            frmInstance.Estado = FormEstate.New;
            
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPackingListDet);
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
        protected override void OnEditar()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Inicio el constructor

            var frmInstance = frmPackingListDet.Instance(this);
            frmInstance.Estado = FormEstate.Edit;
            frmInstance.numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "NumeroDocumento");
            
            Estado = FormEstate.Edit;
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPackingListDet);
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
        protected override void OnVer()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Inicio el constructor

            var frmInstance = frmPackingListDet.Instance(this);
            frmInstance.Estado = FormEstate.Edit;
            frmInstance.numeroDocumento = Util.GetCurrentCellText(gridControl.CurrentRow, "NumeroDocumento");
            Estado = FormEstate.View;
            var frmExist = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPackingListDet);
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
        protected override void OnImportar()
        {
            ProcesarInformacionPacking();
            
        }
        private void CrearColumnas()
        {
            RadGridView Grid = CreateGridVista(this.gridControl);
            CreateGridColumn(Grid, "NumeroDocumento", "NumeroDocumento", 0, "", 100, true, false, true);
            CreateGridColumn(Grid, "Fecha", "FechaTexto", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "ClienteCodigo", "ClienteCodigo", 0, "", 90, true, false, true);
            CreateGridColumn(Grid, "ClienteDesc", "ClienteDesc", 0, "", 250, true, false, true);
            CreateGridColumn(Grid, "ContainerNro", "ContainerNro", 0, "", 70, true, false, true);
            CreateGridColumn(Grid, "PrecintoNros", "PrecintoNros", 0, "", 120, true, false, true);

        }
        #region "Enviar correo"
        private string GenerarArchivoExportacion()
        {
            string rutaDelArchivo = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (GridViewRowInfo row in gridControl.SelectedRows)
                {
                    #region "Cabecera de documento"
                    string numeroDocumento = Util.GetCurrentCellText(row, "NumeroDocumento");
                    PackingList packingCabecera = PackingListLogic.Instance.TraePackingListRegistro(Logueo.CodigoEmpresa,
                                                                                   numeroDocumento, Logueo.Anio, Logueo.Mes);

                    string flag = "C";
                    sb.AppendLine(flag +
                        "|" + packingCabecera.Empresa +
                        "|" + packingCabecera.NumeroDocumento +
                        "|" + packingCabecera.anio +
                        "|" + packingCabecera.mes +
                        "|" + packingCabecera.FechaTexto +
                        "|" + packingCabecera.ClienteCodigo +
                        "|" + packingCabecera.ContainerNro +
                        "|" + packingCabecera.PrecintoNros);

                    #endregion

                    #region "Detalle"
                    string flagDetalle = "D";
                    List<PackingList> detalles = PackingListLogic.Instance.TraePackingDetalleFacturacion(Logueo.CodigoEmpresa, numeroDocumento);
                    foreach (PackingList registro in detalles)
                    {
                        sb.AppendLine(flagDetalle + //0
                            "|" + registro.Empresa + //1
                            "|" + registro.NumeroDocumento + //2
                            "|" + registro.Item + //3
                            "|" + registro.Secuencia + //4
                            "|" + registro.ProductoCliente + //5
                            "|" + registro.ProductoEmpresa + //6
                            "|" + registro.ProductoDescripcion + //7
                            "|" + registro.Largo + //8
                            "|" + registro.Ancho + //9
                            "|" + registro.Alto + //10
                            "|" + registro.LargoTexto + //11
                            "|" + registro.AnchoTexto + //12
                            "|" + registro.AltoTexto + //13
                            "|" + registro.PzasxCaja + //14
                            "|" + registro.Cantidad + //15
                            "|" + registro.Cajas + //16
                            "|" + registro.Area + //17
                            "|" + registro.Peso + //18
                            "|" + registro.Proforma + //19
                            "|" + registro.PedidoNumero + //20
                            "|" + registro.PedidoItem + //21                             
                            "|" + registro.Observaciones + //22
                            "|" + registro.VentaUnidaMedida + //23
                            "|" + registro.VentaPrecio + //24
                            "|" + registro.VentaSubTotal + //25
                            "|" + Logueo.Anio + //26
                            "|" + Logueo.Mes);  //27

                    }
                    //PackingList packingDetalle = PackingListLogic.Instance.tra
                    #endregion

                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.Title = "Guardar Archivo texto";
                sfd.FileName = "EXPORTACIONPACKING.txt";
                sfd.RestoreDirectory = true;
                string ruta = string.Empty;
                ruta = Path.Combine(Application.StartupPath, sfd.FileName);
                //limpio la informacion del contenido del archivo
                System.IO.File.WriteAllText(ruta, string.Empty);
                //asigno el valor al archivo de texto.
                System.IO.File.WriteAllText(ruta, sb.ToString());

                rutaDelArchivo = ruta;
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Util.ShowError("Error en exportacion de datos : " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Util.ShowError("Erro en exportacion de datos :" + ex.Message);
            }
            return rutaDelArchivo;
        }
        private bool ProcesarInformacionPacking()
        {
            //Ejecutar el proceso segun el perfil de usuario

            bool procesoExitoso = true;

            if (Logueo.codigoPerfil == "08")
            {
                EnviarCorreoPorOutlook();
            }
            else 
            {
                VerImportacion();
            }

            return procesoExitoso;
        }

        private bool OutLookAbierto()
        {
            foreach (Process proceso in Process.GetProcesses())
            {
                if ((proceso.ProcessName.Equals("OUTLOOK", StringComparison.CurrentCultureIgnoreCase)))
                    return true;
            }

            return false;
        }

        private void EnviarCorreoPorOutlook()
        {
            try
            {
                AbrirVentanaDeEnviarNuevoCorreoOutlook();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al enviar correo:" + ex.Message);
            }
        }
        private void AbrirVentanaDeEnviarNuevoCorreoOutlook()
        {
            Cursor.Current = Cursors.WaitCursor;
            Microsoft.Office.Interop.Outlook.Application Correo = new Microsoft.Office.Interop.Outlook.Application();

            Microsoft.Office.Interop.Outlook.NameSpace Login = Correo.GetNamespace("mapi");
            Microsoft.Office.Interop.Outlook._MailItem Mensaje = Correo.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);


            Mensaje.Subject = "";
            string codigoTablaHtml = "";
            PackingListLogic.Instance.TraeTablaHtml(out codigoTablaHtml);
            Mensaje.HTMLBody = codigoTablaHtml;
            string rutadeAplicacion = Application.StartupPath;
            string rutaArchivo = GenerarArchivoExportacion();

            if (rutaArchivo == "") { Util.ShowAlert("Fallo al generar el archivo de exportacion"); return; }

            if (File.Exists(rutaArchivo))
            {
                Mensaje.Attachments.Add(rutaArchivo, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, rutaArchivo);
            }

            Mensaje.Display(true);      // Se muestra el correo
            Login.Logoff();             // Cerrar sesion OutLook

            Mensaje = null;
            Login = null;
            Correo = null;
            Cursor.Current = Cursors.Default;
        }
        #endregion
        #region "importacion de packing list"
        private bool InsertarImportacion()
        {
            bool operacionExitosa = false;
            int flagSalida = 0, flag = 0; 
            string mensajeSalida = "", mensaje = ""; 
            

            PackingImportar importacion = new PackingImportar();

            try
            {

                PackingListLogic.Instance.EliminarPackingImportar(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, "VENTAS",
                Logueo.UserName, out flagSalida, out mensajeSalida);

                if (flagSalida == -1)
                {
                    operacionExitosa = false;
                    Util.ShowMessage(mensajeSalida, flagSalida);
                }
                else if (flagSalida == 1)
                {
                    for (int x = 0; x < txtImportado.Lines.Length; x++)
                    {
                        #region "Leer lineas  de importacion"
                        importacion = new PackingImportar();
                        string[] datos = txtImportado.Lines[x].Split('|');
                        if (datos[0] == "C")
                        {
                            #region "Cabecera importado"
                            importacion.FAC60CODEMP = datos[1];
                            importacion.FAC60NUMERO = datos[2];
                            importacion.FAC60AA = datos[3];
                            importacion.FAC60MM = datos[4];
                            importacion.FAC60FECHA = datos[5];
                            importacion.FAC60CLIENTECOD = datos[6];
                            importacion.FAC60CONTAINERNRO = datos[7];
                            importacion.FAC60PRECINTONROS = datos[8];
                            importacion.codigousuario = Logueo.UserName;
                            importacion.sistema = "VENTAS";
                            importacion.flag = datos[0]; // C (cabecera) o D (detalle)
                            #endregion
                        }
                        else if (datos[0] == "D")
                        {
                            #region "Detalle importado"
                            importacion.FAC60CODEMP = datos[1];
                            importacion.FAC60NUMERO = datos[2];
                            importacion.FAC61ITEM = Convert.ToInt32(datos[3]);
                            importacion.FAC61SECUENCIA = Convert.ToInt32(datos[4]);
                            importacion.FAC61PRODCODCLIENTE = datos[5];
                            importacion.FAC61PRODCODEMPRESA = datos[6];
                            importacion.FAC61PRODDESCRIPCION = datos[7];
                            importacion.FAC61PRODLARGO = Convert.ToDouble(datos[8]);
                            importacion.FAC61PRODANCHO = Convert.ToDouble(datos[9]);
                            importacion.FAC61PRODALTO = Convert.ToDouble(datos[10]);
                            importacion.FAC61PRODLARGOTEXTO = datos[11];
                            importacion.FAC61PRODANCHOTEXTO = datos[12];
                            importacion.FAC61PRODALTOTEXTO = datos[13];
                            importacion.FAC61PRODPIEZASXCAJAS = Convert.ToDouble(datos[14]);
                            importacion.FAC61PRODCANTIDAD = Convert.ToDouble(datos[15]);
                            importacion.FAC61PRODCAJASCANTIDAD = Convert.ToDouble(datos[16]);
                            importacion.FAC61PRODAREA = Convert.ToDouble(datos[17]);
                            importacion.FAC61PRODPESO = Convert.ToDouble(datos[18]);
                            importacion.FAC61PRODNROPROFORMACLIENTE = datos[19];
                            importacion.FAC61PEDIDONUM = datos[20];
                            importacion.FAC61PEDITEM = Convert.ToInt32(datos[21]);
                            importacion.FAC61PRODAREA = Convert.ToDouble(datos[22]);
                            importacion.FAC61OBSERVACIONES = datos[23];
                            importacion.FAC61VENTAUNIMED = datos[24];
                            importacion.FAC61VENTAPRECIO = Convert.ToDouble(datos[25]);
                            importacion.FAC61VENTASUBTOTAL = Convert.ToDouble(datos[26]);
                            importacion.FAC60AA = datos[27];
                            importacion.FAC60MM = datos[28];

                            importacion.sistema = "VENTAS";
                            importacion.codigousuario = Logueo.UserName;
                            importacion.flag = datos[0]; // C (cabecera) o D (detalle)

                            #endregion
                        }

                        PackingListLogic.Instance.Importar(importacion, out flag, out mensaje);
                        if (flag == -1)
                        {
                            Util.ShowAlert("Sucedio error al procesar informacion importado : " + mensaje);
                        }
                       
                        #endregion
                    }
                    //Util.ShowMessage(mensaje, flag);
                    if (flag == 1)
                    {
                        #region "Evalua errores de importacion"
                        //evaluar si tiene errores la importacion
                        CargarValidacion();
                        int cantidadErrores = 0;

                        cantidadErrores = Util.GetCurrentCellInt(gridValidacion.Rows[0], "Canterrores");
                        if (cantidadErrores > 0)
                        {
                            operacionExitosa = false;
                            Util.ShowAlert("Corregir los registros con error");
                        }
                        else if(cantidadErrores == 0)
                        {
                            operacionExitosa = true;
                        }
                        #endregion

                    }
                }

            }
            catch (System.Data.SqlClient.SqlException exSQL)
            {
                Util.ShowError("Error al insertar importacion : " + exSQL.Message + " Numero de linea:" + exSQL.LineNumber);
            }
            catch (System.ArgumentOutOfRangeException exOutRange)
            {
                Util.ShowError("Error al insertar importacion : " + exOutRange.Message);
            }catch (Exception ex)
            {
                Util.ShowError("Error al insertar importacion : " + ex.Message + " Origen de error : " + ex.Source + " Detalle: " + ex.Data);
            }
            return operacionExitosa;

        }
        private void GuardarPackingImportado()
        { 
            int flag = 0; string mensaje = "";
            try
            {
                PackingListLogic.Instance.InsertaPackingImportado(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes,
                Logueo.UserName, "VENTAS", out flag, out mensaje);
                Util.ShowMessage(mensaje, flag);
                if (flag == 1)
                {
                    Cargar();
                    OcultarImportacion();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Util.ShowError("Error al guardar packing importado :" + sqlEx.Message);
            } catch (Exception ex)
            {
                Util.ShowError("Error al guardar packing importado :" + ex.Message);
            }

        }
        private void LimpiarImportacion()
        {
            txtImportado.Text = "";
            gridValidacion.DataSource = null;
        }
        private void OcultarImportacion()
        {
            LimpiarImportacion();
            this.gpxImportarPacking.Visible = false;
        }
        private void VerImportacion()
        {
            
            this.gpxImportarPacking.Visible = true;
        }
        #endregion
        private void gridControl_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            OnVer();
        }
        private void gridControl_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            
        }
        private void btnGuardarImportacion_Click(object sender, EventArgs e)
        {
            if (InsertarImportacion() == false)
            {
                return;
            }
            else { 
                //Guardar datos importados a tabla de packing
                GuardarPackingImportado();
            }
            
        }
        private void btnCancelarImportacion_Click(object sender, EventArgs e)
        {
            OcultarImportacion();
        }
        private Point MouseDownLocation;
        private void gpxImportarPacking_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void gpxImportarPacking_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                gpxImportarPacking.Left = e.X + gpxImportarPacking.Left - MouseDownLocation.X;                
                gpxImportarPacking.Top = e.Y + gpxImportarPacking.Top - MouseDownLocation.Y;                
            }
        }
        private void btnValidar_Click(object sender, EventArgs e)
        {
            InsertarImportacion();
        }
        
    }
}
