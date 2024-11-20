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

namespace Inv.UI.Win
{
    public partial class frmArticuloSuministroDet : frmBaseMante
    {

        private static frmArticuloSuministroDet _aForm;
        private frmArticuloSuministro FrmParent { get; set; }
        public static frmArticuloSuministroDet Instance(frmArticuloSuministro padre)
        {
            if (_aForm != null) return new frmArticuloSuministroDet(padre);
            _aForm = new frmArticuloSuministroDet(padre);
            return _aForm;
        }
        public frmArticuloSuministroDet(frmArticuloSuministro padre)
        {
            InitializeComponent();
            FrmParent = padre;
            // ============================ Asignar configueracion de navegacion .============================                        
            Util.ConfigGridToEnterNavigation(gridAlmacen);
        }
        DetalleAlmacen DetAlm = new DetalleAlmacen();
        string esEquivalente = "";
        string FlagMovimiento = "";
        string TipoPlanctas = "";
        bool existeDescripcionArticulo = false;
        int[] aLongitudCodigos;
        
        
        #region "Cabecera"

        private void ConfiguraEstadoFormulario(FormEstate estado)
        {
            OcultarBotones();
            this.OcultaBotonesDetalle();
            if (estado == FormEstate.New)
            {
                txtMontoEquivalente.Text = "0.0";
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                HabilitaArtiCab(true);

                this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnNuevoDet);
                //this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEditarDet);
                optactivo.Checked = true;
                optInsumo.Checked = true;
            }
            else if (estado == FormEstate.Edit)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
                HabilitaArtiCab(true);
                txtLinea.Enabled = false; txtGrupo.Enabled = false; txtSubGrupo.Enabled = false;
                txtDetalle.Enabled = false;

                this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnNuevoDet);
                this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEditarDet);
                this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEliminarDet);
            }
            else if (estado == FormEstate.View)
            {
                HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
                HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
                HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
                HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);
                OcultaBotonesDetalle();

                HabilitaArtiCab(false);
            }
        }
        string gloValorMovimiento = "";
        private bool VerificaCodigoArti(string linea, string grupo, string subgrupo, string detalle)
        {
            
            //string codigocompleto = linea.Trim() + grupo.Trim() + subgrupo.Trim();

            //if (linea.Trim().Length < aLongitudCodigos[0])
            //{

            //    Util.ShowAlert("La linea articulo debe ser " + aLongitudCodigos[0] + " digitos");
            //    return false;
            //}


            //if (linea.Length + grupo.Length < aLongitudCodigos[1])
            //{
            //    Util.ShowAlert("El grupo debe ser " + aLongitudCodigos[1] + " digitos");
            //    return false;
            //}

            //if (linea.Length + grupo.Length + subgrupo.Length < aLongitudCodigos[2])
            //{
            //    Util.ShowAlert("El subgrupo debe ser " + aLongitudCodigos[2] + " digitos");
            //    return false;
            //}

            //if (linea.Length + grupo.Length + subgrupo.Length + detalle.Length < aLongitudCodigos[3])
            //{
            //    Util.ShowAlert("El detalle debe ser " + aLongitudCodigos[3] + " digitos");
            //    return false;
            //}

            ////validacion la existencia en base base de datos de lso registros de linea, grupo, subgrupo             
            //for (int x = 0; x < aLongitudCodigos.Length - 1; x++)
            //{

            //    System.Data.DataTable dt = CompraArticuloLogic.Instace.TraeEstructuraArticulo(Logueo.CodigoEmpresa,
            //                                                Logueo.Anio, codigocompleto.Substring(0, aLongitudCodigos[x]));

            //    if (dt.Rows.Count == 0)
            //    {
            //        Util.ShowAlert("No tiene registrado un  " + aLongitudCodigos[x]);
            //        return false;
            //    }
            //    else
            //    {

            //        if (x == aLongitudCodigos.Length - 1)
            //        {
            //            gloValorMovimiento = "S";
            //        }
            //        else
            //        {
            //            gloValorMovimiento = "N";
            //        }
            //    }
            //}



            gloValorMovimiento = "S";
            //linea.Trim() + grupo.Trim()
            return true;
        }


        protected override void OnNuevo()
        {
            Cursor.Current = Cursors.WaitCursor;
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

            LimpiarCabecera();

            //habilita cajas de cabecera articulo

            HabilitaArtiCab(true);
            txtLinea.Focus();

            IniciarDatos();

            this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnNuevoDet);

            Estado = FormEstate.New;
            Cursor.Current = Cursors.Default;
            this.gpxFlotante.Visible = false;
        }

        private string TraeTipo()
        {
            string respuesta = "";
            if (optInsumo.Checked == true)
            {
                respuesta = "A";
            }
            else if (optactivofijo.Checked == true)
            {
                respuesta = "F";
            }
            return respuesta;
        }
        private string TraeEstado()
        {
            string respuesta = "";
            if (optactivo.Checked == true)
            {
                respuesta = "A";
                //respuesta = "1";
            }
            else if (optinactivo.Checked == true)
            {
                respuesta = "B";
                //respuesta = "0";
            }
            return respuesta;
        }
        private string TraeEquivalente()
        {
            string respuesta = "";
            if (txtUnidad.Text.Trim() != txtUniEquiv.Text.Trim())
            {
                respuesta = "S";
            }
            else
            {
                respuesta = "N";
            }
            //if (OptEquivaleSi.Checked == true) {
            //    respuesta = "S";
            //}
            //else if (OptEquivaleNo.Checked == true) {
            //    respuesta = "N";
            //}
            return respuesta;
        }

        private string TraerTipoMovimiento()
        {
            string respuesta = "";
            string verificarcodigo = "";
            if (txtDetalle.Enabled == true)
            {

                CompraArticuloLogic.Instace.TraeVerificacionCodigosColqui(Logueo.CodigoEmpresa, Logueo.Anio, txtLinea.Text.Trim(), "LINA", out verificarcodigo);
                if (verificarcodigo == "N")
                {
                    Util.ShowAlert("La Linea de Articulo no esta Registrada, Verifique");
                    txtLinea.Focus();
                    respuesta = verificarcodigo;
                    return respuesta;
                }
                CompraArticuloLogic.Instace.TraeVerificacionCodigosColqui(Logueo.CodigoEmpresa, Logueo.Anio, txtLinea.Text.Trim() + txtGrupo.Text.Trim(),
                    "LINA", out verificarcodigo);
                if (verificarcodigo == "N")
                {
                    Util.ShowAlert("El Grupo de Articulo no esta Registrada, Verifique");
                    txtGrupo.Focus();
                    respuesta = verificarcodigo;
                    txtGrupo.Focus();
                    return respuesta;
                }

                CompraArticuloLogic.Instace.TraeVerificacionCodigosColqui(Logueo.CodigoEmpresa, Logueo.Anio,
                    txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim(),
                    "LINA", out verificarcodigo);
                if (verificarcodigo == "N")
                {
                    Util.ShowAlert("El Sub Grupo de Articulo no esta Registrada, Verifique");
                    txtGrupo.Focus();
                    respuesta = verificarcodigo;
                    txtSubGrupo.Focus();
                    return respuesta;
                }
                if (txtDetalle.Text.Length < 3)
                {
                    Util.ShowAlert("Debe Ingresar El Codigo Correlativo del Articulo (3 Digitos)");
                    txtDetalle.Focus();
                    return respuesta;
                }
                if (txtDescripcion.Text.Trim() == "")
                {
                    Util.ShowAlert("Ingrese descripcion del articulo");

                    return respuesta;
                }

            }
            else
            {

            }
            respuesta = verificarcodigo;
            return respuesta;
        }


        string valorunidadmedida = "";
        private void validarunidaddemedidas(string unidad, string unidadmedidaequivalente, double monto)
        {
            valorunidadmedida = "";
            if (unidad.Trim() == unidadmedidaequivalente.Trim())
            {
                if (monto == 1)
                {
                    valorunidadmedida = "";
                    return;
                }
                else
                {
                    valorunidadmedida = "Error: El monto equivalente de dos unidade de medida iguales debe ser = [1]";
                    return;
                }
            }
            else
            {
                if (monto == 1 || monto == 0)
                {
                    valorunidadmedida = "Error: El monto equivalente de dos unidades de medida diferentes debe ser <> [1]";
                    return;
                }
                else
                {
                    valorunidadmedida = "";
                    return;
                }
            }
        }

        protected override void OnEditar()
        {
            HabilitaArtiCab(true);
            txtLinea.Enabled = false;
            txtGrupo.Enabled = false;
            txtSubGrupo.Enabled = false;
            txtDetalle.Enabled = false;
            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);

            HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnNuevoDet);
            HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEditarDet);
            HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEliminarDet);

            Estado = FormEstate.Edit;
            this.gpxFlotante.Visible = false;
        }



        protected override void OnGuardar()
        {
            Cursor.Current = Cursors.WaitCursor;
            string parCodArti = txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();
            //int[] parArregloCodigos = this.aEstArticulo;

            string parAccion = "";
            if (Estado == FormEstate.New)
            {
                parAccion = "A";
            }
            else if (Estado == FormEstate.Edit)
            {
                parAccion = "M";
            }

            //List<Articulo> parLista = FrmParent.listaArticulo;
            string valormovimiento = "";
            
            if (parAccion == "A")
            {
                bool verifcadoCodArt = VerificaCodigoArti(txtLinea.Text.Trim(),
                    txtGrupo.Text.Trim(), txtSubGrupo.Text.Trim(), txtDetalle.Text.Trim());
                //este metodo devuelve verdadero
                
                if (!verifcadoCodArt)
                {
                    valormovimiento = "N";
                    txtDetalle.Focus();

                    return;
                }
                else
                {
                    //si valor validacion es verdadero
                    valormovimiento = "S"; // paso todo los 
                }

            }
            else
            {
                valormovimiento = FlagMovimiento;
            }


            //VerificaCodigo(parCodArti, parArregloCodigos, parAccion, parLista);

            //string valormovimiento = "";
            //valormovimiento = valorCodigoVerificado;
            //if (valormovimiento == "") {
            //    txtDetalle.Focus();
            //    return;
            //}
            #region "verificar codigos"
            //string swx = "";
            //string valorSalida = "";
            ////campoa correlativo del articulo
            //if (txtDetalle.Enabled == true)
            //{
            //    CompraArticuloLogic.Instace.TraeVerificacionCodigosColqui(Logueo.CodigoEmpresa, Logueo.Anio,
            //                                                    txtLinea.Text.Trim(), "LINA", out valorSalida);
            //    if (valorSalida == "N")
            //    {
            //        Util.ShowAlert("La linea articulo no esta registrada, verifique");
            //        return;
            //    }

            //    CompraArticuloLogic.Instace.TraeVerificacionCodigosColqui(Logueo.CodigoEmpresa, Logueo.Anio,
            //                                                    txtLinea.Text.Trim() + txtGrupo.Text.Trim(),
            //                                                    "LINA", out valorSalida);
            //    if (valorSalida == "N")
            //    {
            //        Util.ShowAlert("El grupo articulo no esta registrada, verifique");
            //        return;
            //    }

            //    CompraArticuloLogic.Instace.TraeVerificacionCodigosColqui(Logueo.CodigoEmpresa, Logueo.Anio,
            //                                                    txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim(),
            //                                                    "LINA", out valorSalida);

            //    if (valorSalida == "N")
            //    {
            //        Util.ShowAlert("El sub grupo de articulo no esta registrada, verifique");
            //        return;
            //    }


            //    if (txtDetalle.Text.Trim().Length < 3)
            //    {
            //        Util.ShowAlert("Debe ingresar el codigo correlativo de 3 digitos");
            //        return;
            //    }
            //    if (txtDescripcion.Text.Trim() == "")
            //    {
            //        Util.ShowAlert("Ingrese descripcion de articulo");
            //        return;
            //    }


            //    //CompraArticuloLogic.Instace.TraeVerificacionCodigosColqui(Logueo.CodigoEmpresa, Logueo.Anio,
            //    //                            txtDescripcion.Text.Trim().ToUpper(), "DESLA", out valorSalida);

            //    //if (valorSalida == "S" && Estado == FormEstate.New)
            //    //{
            //    //    Util.ShowAlert("La descripcion esta registrada, verifique");
            //    //    txtDescripcion.Focus();
            //    //    return;
            //    //}

                
            //    if (lblUnidadMedida.Text.Trim() == "" || lblUnidadMedida.Text.Trim() == "???")
            //    {
            //        Util.ShowAlert("Unidad de medida no valida");
            //        txtUnidad.Focus();
            //        return;
            //    }

            //    if (txtMontoEquivalente.Text == "")
            //    {
            //        Util.ShowAlert("Ingrese el monto equivalente");
            //        txtMontoEquivalente.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        double numeroSalida = 0;
            //        Double.TryParse(txtMontoEquivalente.Text.Trim(), out numeroSalida);
            //        if (numeroSalida == 0)
            //        {
            //            Util.ShowAlert("El valor ingresado  no tiene formato numero");
            //            txtMontoEquivalente.Focus();
            //            return;
            //        }
            //    }

            //    string unidad, unidadequiv;
            //    double montoequiv = 0;
            //    unidad = txtUnidad.Text.Trim();
            //    unidadequiv = txtUniEquiv.Text.Trim();
            //    montoequiv = Convert.ToDouble(txtMontoEquivalente.Text.Trim());

            //    validarunidaddemedidas(unidad, unidadequiv, montoequiv);
            //    //llamar a varialbe valorunidadmedida para ver el valor devuelto.
            //    if (valorunidadmedida != "")
            //    {
            //        Util.ShowAlert(valorunidadmedida);
            //        return;
            //    }


            //}
            //else
            //{
            //    if (lblUnidadMedida.Text.Trim() == "" || lblUnidadMedida.Text.Trim() == "???")
            //    {
            //        Util.ShowAlert("Unidad de medida no valida");
            //        txtUnidad.Focus();
            //        return;

            //    }
            //    if (lblUnidadEquivalente.Text.Trim() == "" || lblUnidadEquivalente.Text.Trim() == "???")
            //    {
            //        Util.ShowAlert("Unidad medidad equivalente no valida");
            //        txtUniEquiv.Focus();
            //        return;
            //    }

            //    if (txtMontoEquivalente.Text == "")
            //    {
            //        Util.ShowAlert("Ingrese el monto equivalente");
            //        txtMontoEquivalente.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        double numero = 0;
            //        double.TryParse(txtMontoEquivalente.Text.Trim(), out numero);
            //        if (numero == 0)
            //        {
            //            Util.ShowAlert("El monto debe ser un valor numerico");
            //            txtMontoEquivalente.Focus();
            //            return;
            //        }
            //        string uni = txtUnidad.Text.Trim(); string uniEquiv = txtUniEquiv.Text.Trim();
            //        double montoEquiv = 0; montoEquiv = Convert.ToDouble(txtMontoEquivalente.Text.Trim());
            //        validarunidaddemedidas(uni, uniEquiv, montoEquiv);
            //        if (valorunidadmedida != "")
            //        {
            //            Util.ShowAlert(valorunidadmedida);
            //            return;
            //        }

            //    }

            //}
            #endregion


            //validacion de descripcion en tabla de articulo
            //            //if (existeDescripcionArticulo == true)
            //{
            //    Util.ShowAlert("La descripcion a registrar existe en el sistema");
            //    txtDescripcion.Focus();
            //    return;
            //}si tiene la descripcion el flag de ArticuloRegistrado, no debemos permitir guardar.

            //valormovimiento = 
            CompraArticulo entidad = new CompraArticulo();
            entidad.codigoEmpresa = Logueo.CodigoEmpresa;
            entidad.anio = Logueo.Anio;
            entidad.codigoArticulo = txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();
            entidad.descripcion = txtDescripcion.Text.Trim();
            entidad.unimed = txtUnidad.Text.Trim();
            entidad.codigoProveedor = "";
            entidad.movimiento = valormovimiento;
            entidad.unidadEquivalencia = txtUniEquiv.Text.Trim();
            entidad.tipo = TraeTipo();
            entidad.estado = TraeEstado(); // 1: activo , 0: inactivo tipo de dato cadena
            entidad.montoEquivalencia = string.IsNullOrEmpty(txtMontoEquivalente.Text.Trim()) ? 0.0 :Convert.ToDouble(txtMontoEquivalente.Text.Trim());
            entidad.unidadMayor = TraeEquivalente();
            
            //en esta linea guardo el codigo de proveedor
            //entidad.tipoPlactas = TipoPlanctas;
            entidad.tipoPlactas = txttipoctacble.Text.Trim();
            entidad.codigoProveedor = txtProveedorCod.Text.Trim();
            
            //puedo usar otro naturaleza para los suministros del Invetanrio en Lima.
            //04 - > suministro de huaral, 05 Suminitro Lima
            entidad.codigoNaturaleza = "04";
            int flag = 0;
            string mensaje = "";
            try
            {
                if (Estado == FormEstate.New)
                {
                    //if (TraerTipoMovimiento() == "S")
                    //{
                        //Generar XML
                        string[] datosXml = new string[gridAlmacen.Rows.Count];

                        string codAlmacen = "";
                        string ubicacion = "";
                        string fecha = "";

                        //CompraArticuloLogic.Instace.InsertarCabecera(entidad, out flag, out mensaje); // metodo de guardar antiguo
                        int x = 0;
                        foreach (GridViewRowInfo fila in gridAlmacen.Rows)
                        {
                            codAlmacen = Util.GetCurrentCellText(fila, "In04CodAlm");
                            //ubicacion = Util.GetCurrentCellText(fila, "In04Ubicac");
                            //fecha = Util.GetCurrentCellText(fila, "In04FecIni");
                            datosXml[x] =
                                Logueo.CodigoEmpresa + "|" + Logueo.Anio + "|"
                                + txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() +
                                txtDetalle.Text.Trim() + "|" + codAlmacen;
                            x++;
                        }

                        string xmldinamico = Util.ConvertiraXMLdinamico(datosXml);

                        //metodo de guardar nuevo

                        CompraArticuloLogic.Instace.InsertarTodoArticulo(entidad, xmldinamico, out flag, out mensaje);
                        if (flag == 1)
                        {
                            Util.ShowMessage(mensaje, flag);
                        }
                        else
                        {
                            Util.ShowAlert(mensaje);
                        }



                    //}

                }
                else if (Estado == FormEstate.Edit)
                {
                    CompraArticuloLogic.Instace.ActualizarCabecera(entidad, out flag, out mensaje);
                    if (flag == 1)
                    {
                        Util.ShowMessage(mensaje, flag);
                    }
                    else
                    {
                        Util.ShowAlert(mensaje);
                    }

                }


                if (flag == 1)
                {
                    HabilitaArtiCab(false);
                    OcultarBotones();
                    HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
                    HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);
                    HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
                    HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
                    HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
                    HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);
                    FrmParent.Cargar("*", FrmParent.tipo, FrmParent.estado);

                    //Mantenimiento de Almacen
                    this.OcultaBotonesDetalle();
                    this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnNuevoDet);
                    this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEditarDet);
                    this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEliminarDet);

                    //Estado = FormEstate.List;
                    Estado = FormEstate.View;
                }

                //luego de guardar o actualizar
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar");
            }

            Cursor.Current = Cursors.Default;
        }

        protected override void OnCancelar()
        {
            HabilitaArtiCab(false);


            OcultarBotones();

            HabilitaBotonPorNombre(BaseRegBotones.cbbNuevo);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEditar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbEliminar);

            HabilitaBotonPorNombre(BaseRegBotones.cmdPrimero);
            HabilitaBotonPorNombre(BaseRegBotones.cmdAnterior);
            HabilitaBotonPorNombre(BaseRegBotones.cmdSiguiente);
            HabilitaBotonPorNombre(BaseRegBotones.cmdUltimo);

            this.OcultaBotonesDetalle();

            

            this.gpxFlotante.Visible = false;
            //Si flag es nuevo , entonces, debe apuntar aun registro al ultimo registro ingresado 
            if (Estado == FormEstate.New)
            {
                LimpiarCabecera();
                if (FrmParent.gridControl.Rows.Count > 0)
                {

                    FrmParent.gridControl.CurrentRow = FrmParent.gridControl.MasterView.Rows[0];
                    CargarArticulo();
                }
            }
            //Si flag es editar, entonces, no recargar la grilla , solo desactivar los controles volver a cargar el registro.
            else if (Estado == FormEstate.Edit)
            {
                CargarArticulo();
            }
            //Asignar el estado de Lista o Vista , limpia de los valores tomado del formulario padre.
            
            Estado = FormEstate.View;
            //Seleccionar una fila del registros
            
        }

        protected override void OnEliminar()
        {
            Estado = FormEstate.List;
            bool respuesta = Util.ShowQuestion("¿Desea eliminar el articulo?");
            if (respuesta == true)
            {

                string codigoArticulo = this.txtLinea.Text.Trim() + txtGrupo.Text.Trim() +
                                    txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();
                int nFlag = 0; string sMensaje = "";

                CompraArticuloLogic.Instace.EliminarArticulo(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoArticulo, "N", out nFlag, out sMensaje);

                Util.ShowMessage(sMensaje, nFlag);

                if (nFlag == 1)
                {
                    OnCancelar();
                    //refresco al grilla de listado                    
                    FrmParent.Cargar("*", FrmParent.tipo, FrmParent.estado);
                    this.Close();
                    
                }
                else
                {

                }
            }


        }
        protected override void OnPrimero()
        {
            int iIndice = 0;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarArticulo();
        }
        protected override void OnAnterior()
        {
            int iIndice = FrmParent.gridControl.MasterView.CurrentRow.Index - 1;
            if (iIndice < 0)
            {
                return;
            }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarArticulo();
        }
        protected override void OnSiguiente()
        {
            int iIndice = FrmParent.gridControl.MasterView.CurrentRow.Index + 1;
            if (iIndice > FrmParent.gridControl.MasterView.Rows.Count - 1)
            {
                return;
            }
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarArticulo();
        }
        protected override void OnUltimo()
        {
            int iIndice = FrmParent.gridControl.MasterView.Rows.Count - 1;
            FrmParent.gridControl.MasterView.CurrentRow = FrmParent.gridControl.MasterView.Rows[iIndice];
            CargarArticulo();
        }
        private void HabilitaArtiCab(bool estado)
        {
            txtLinea.Enabled = estado;
            txtGrupo.Enabled = estado;
            txtSubGrupo.Enabled = estado;
            txtDetalle.Enabled = estado;
            txtDescripcion.Enabled = estado;
            
            //campo de cuenta contable
            txttipoctacble.Enabled = estado;

            txtProveedorCod.Enabled = estado;
            txtUniEquiv.Enabled = estado;
            txtUnidad.Enabled = estado;
            txtMontoEquivalente.Enabled = estado;

            optInsumo.Enabled = estado;
            optactivofijo.Enabled = estado;

            optactivo.Enabled = estado;
            optinactivo.Enabled = estado;
            esEquivalente = "";

        }
        private void LimpiarCabecera()
        {
            txtLinea.Text = "";
            txtGrupo.Text = "";
            txtSubGrupo.Text = "";
            txtDetalle.Text = "";
            //textarea
            txtDescripcion.Text = "";

            //campo cuenta contable
            txttipoctacble.Text = "";
            txttipoctacbleDesc.Text = "";

            //lblhelp.Text = "";
            txtProveedorCod.Text = "";
            txtProveedorDesc.Text = "";
            optInsumo.Checked = false;
            optactivofijo.Checked = false;

            optactivo.Checked = false;
            optinactivo.Checked = false;

            txtUniEquiv.Text = "";
            lblUnidadEquivalente.Text = "";

            txtUnidad.Text = "";
            lblUnidadMedida.Text = "";

            txtMontoEquivalente.Text = "0.0";


            esEquivalente = "";
            //OptEquivaleSi.Text = "";
            //OptEquivaleNo.Text = "";
        }
        private void IniciarDatos()
        {
            lblUnidadEquivalente.Text = "2";
            txtMontoEquivalente.Text = "1";
            esEquivalente = "S";
            optactivo.Checked = true;
            optInsumo.Checked = true;


            string codigoArticulo = txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();


            this.gridAlmacen.DataSource = DetAlm.TraerAlmacenesxArticulo(codigoArticulo);

            optactivo.Checked = true;
        }
        private void TraerAyudaCab(enmAyuda tipo)
        {
            try
            {

                frmBusqueda frm;
                string codigoGenerado = "";
                string descripcion = "";
                switch (tipo)
                {
                    case enmAyuda.enmLineaArti:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) return;
                        if (frm.Result.ToString() == "") return;
                        txtLinea.Text = frm.Result.ToString();
                        break;
                    case enmAyuda.enmGrupoArti:
                        frm = new frmBusqueda(tipo, txtLinea.Text.Trim());
                        frm.ShowDialog();
                        if (frm.Result == null) return;
                        if (frm.Result.ToString() == "") return;
                        txtGrupo.Text = frm.Result.ToString();
                        break;
                    case enmAyuda.enmSubGrupoArti:
                        frm = new frmBusqueda(tipo, txtLinea.Text.Trim() + "|" + txtGrupo.Text.Trim());
                        frm.ShowDialog();
                        if (frm.Result == null) return;
                        if (frm.Result.ToString() == "") return;
                        txtSubGrupo.Text = frm.Result.ToString();
                        CompraArticuloLogic.Instace.TraeCodigoGeneradoArtiColqui(Logueo.CodigoEmpresa,
                            Logueo.Anio, txtLinea.Text.Trim(), txtGrupo.Text.Trim(), txtSubGrupo.Text.Trim(),
                            out codigoGenerado);
                        this.txtDetalle.Text = codigoGenerado;
                        break;
                    case enmAyuda.enmCuentaContable:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) return;
                        if (frm.Result.ToString() == "") return;
                        if(frm.Result.ToString().Split('|').Length == 0) return;
                        this.txttipoctacble.Text = frm.Result.ToString().Split('|')[0];
                        this.txttipoctacbleDesc.Text = frm.Result.ToString().Split('|')[1];
                    //    this.lblhelp.Text = frm.Result.ToString().Split('|')[1];
                        break;
                    case enmAyuda.enmUniMed:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) return;
                        if (frm.Result.ToString() == "") return;
                        this.txtUnidad.Text = frm.Result.ToString().Split('|')[0];
                        GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtUnidad.Text, "UNIDAD", out descripcion);
                        lblUnidadMedida.Text = descripcion;
                        //this.lblUnidadMedida.Text = frm.Result.ToString().Split('|')[1];
                        break;
                    case enmAyuda.enmUniMedEquiv:
                        frm = new frmBusqueda(tipo);
                        frm.ShowDialog();
                        if (frm.Result == null) return;
                        if (frm.Result.ToString() == "") return;
                        this.txtUniEquiv.Text = frm.Result.ToString().Split('|')[0];
                        GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + txtUniEquiv.Text, "UNIDAD", out descripcion);
                        lblUnidadEquivalente.Text = descripcion;
                        //this.lblUnidadEquivalente.Text = frm.Result.ToString().Split('|')[1];
                        break;
                    case enmAyuda.enmProveedor:
                        frm = new frmBusqueda(tipo, "02");
                        frm.ShowDialog();
                        if (frm.Result == null) return;
                        if (frm.Result.ToString() == "") return;
                        txtProveedorCod.Text = frm.Result.ToString().Split('|')[0];
                        GlobalLogic.Instance.DameDescripcion(Logueo.CodigoEmpresa + "02" + txtProveedorCod.Text, "PROVEEDOR", out descripcion);
                        txtProveedorDesc.Text = descripcion;
                        //txtProveedorDesc.Text = frm.Result.ToString().Split('|')[1];
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error en traer ayuda: " + ex.Message);
            }
        }
        #endregion

        #region "Detalle"

        private void LimpiarDetalle()
        {

        }
        #endregion
        private void CargarArticulo()
        {

            GridViewRowInfo row = FrmParent.gridControl.MasterView.CurrentRow;

            //string codigoArticulo = FrmParent.codigoArticulo;
            string codigoArticulo = Util.GetCurrentCellText(row, "IN01KEY");
            switch (codigoArticulo.Length)
            {
                case 2:
                    txtLinea.Text = codigoArticulo;
                    txtGrupo.Text = ""; txtSubGrupo.Text = ""; txtDetalle.Text = "";
                    break;
                case 4:
                    txtLinea.Text = codigoArticulo.Substring(0, 2);
                    txtGrupo.Text = codigoArticulo.Substring(2, 2);
                    txtSubGrupo.Text = "";
                    txtDetalle.Text = "";
                    break;
                case 6:
                    txtLinea.Text = codigoArticulo.Substring(0, 2);
                    txtGrupo.Text = codigoArticulo.Substring(2, 2);
                    txtSubGrupo.Text = codigoArticulo.Substring(4, 2);
                    txtDetalle.Text = "";
                    break;
                case 9:
                    txtLinea.Text = codigoArticulo.Substring(0, 2);
                    txtGrupo.Text = codigoArticulo.Substring(2, 2);
                    txtSubGrupo.Text = codigoArticulo.Substring(4, 2);
                    txtDetalle.Text = codigoArticulo.Substring(6, 3);
                    break;
                default:

                    break;
            }


            //txtDescripcion.Text = FrmParent.descripcionArticulo;
            txtDescripcion.Text = Util.GetCurrentCellText(row, "IN01DESLAR");

            txttipoctacble.Text = FrmParent.tipoplactas;
            
            //txttipoctacble.Text = Util.GetCurrentCellText(row, "IN01TIPOPLACTAS");
            //debo pasar la lectura de la grilla lectura
            txtProveedorCod.Text = "";

            string descripcion = "";
            ArticuloCabecera ac = new ArticuloCabecera();

            //Cuenta contable 
            ac.DameDescripcion("55" + txttipoctacble.Text.Trim(), "GL", out descripcion);
            txttipoctacbleDesc.Text = descripcion;
            //lblhelp.Text = descripcion;

            descripcion = "";

            //txtUnidad.Text = FrmParent.unimed;
            txtUnidad.Text = Util.GetCurrentCellText(row, "In01UniMed");
            ac.DameDescripcion(Logueo.CodigoEmpresa + txtUnidad.Text.Trim(), "UNIDAD", out descripcion);
            lblUnidadMedida.Text = descripcion;

            txtUniEquiv.Text = Util.GetCurrentCellText(row, "In01UnidadEqui");
            ac.DameDescripcion(Logueo.CodigoEmpresa + txtUniEquiv.Text.Trim(), "UNIDAD", out descripcion);
            lblUnidadEquivalente.Text = descripcion;


            string unimayor = Util.GetCurrentCellText(row, "IN01UNIDADMAYOR");
            if (unimayor == "S")
            {

                esEquivalente = "S";
            }
            else
            {

                esEquivalente = "N";
            }

            txtMontoEquivalente.Text = Util.GetCurrentCellText(row, "IN01MONTOEQUI");

            optactivofijo.Checked = false;
            optactivo.Checked = false;

            string tipo = Util.GetCurrentCellText(row, "In01tipo");
            string estado = Util.GetCurrentCellText(row, "In01estado");
            if (estado == "1") // *
            {
                optactivo.Checked = true;
            }
            else
            {
                optinactivo.Checked = true;
            }

            FlagMovimiento = Util.GetCurrentCellText(row, "IN01MOV");
           // TipoPlanctas = Util.GetCurrentCellText(row, "IN01TIPOPLACTAS");
            
            optInsumo.Checked = false;
            optactivofijo.Checked = false;

            if (tipo == "A")
            {
                optInsumo.Checked = true;
            }
            else
            {
                optactivofijo.Checked = true;
            }
            txtProveedorCod.Text = Util.GetCurrentCellText(row, "IN01CODPRO");


            string gbxarticulo = txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();

            gridAlmacen.DataSource = DetAlm.TraerAlmacenesxArticulo(gbxarticulo);
        }
        private void CrearColumnasSugerencia()
        {


            RadGridView Grid = CreateGridVista(this.gridSugerencia);
            Grid.ShowColumnHeaders = false;
            CreateGridColumn(Grid, "Codigo", "IN01KEY", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Descripcion", "IN01DESLAR", 0, "", 250);
        }

        #region  "Evento KeyDown"
        private void txtLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyudaCab(enmAyuda.enmLineaArti);
            }
        }

        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyudaCab(enmAyuda.enmGrupoArti);
            }
        }

        private void txtSubGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyudaCab(enmAyuda.enmSubGrupoArti);
            }
        }

        private void txttipoctacble_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyudaCab(enmAyuda.enmCuentaContable);
            }
        }

        private void txtUniEquiv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyudaCab(enmAyuda.enmUniMedEquiv);
            }
        }

        private void txtUnidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyudaCab(enmAyuda.enmUniMed);
            }

        }


        /*
          radLabel9
         txtMontoEquivalente
         */
        #endregion
        #region"Eventos detalle"
        private void CargarKeyDown()
        {

            this.txtMinimo.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtSeguridad.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtMaximo.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtReponer.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtStockIni.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtPromDolar.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtImpDolar.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtPromSoles.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.txtImpSoles.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
            this.dtpFecha.KeyDown += new KeyEventHandler(EventoTextoKeyDown);
        }
        #endregion

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {


            //List<Articulo> lista =  CompraArticuloLogic.Instace.AutocompletarArticulo(Logueo.CodigoEmpresa,
            //                                            Logueo.Anio, "C", "In01DesLar", txtDescripcion.Text);
            //System.Console.Write( "Texto :" + this.txtDescripcion.Text + 
            //    "Resultados:" +  lista.Count.ToString());

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            //if (txtDescripcion.Enabled == true)
            //{

            //    ArticuloCabecera ArtiCab = new ArticuloCabecera();
            //    this.gridSugerencia.DataSource = ArtiCab.AutocompletarArticulo(txtDescripcion.Text);
            //    if (gridSugerencia.Rows.Count == 0)
            //    {
            //        this.gpxFlotante.Visible = false;
            //        existeDescripcionArticulo = false;
            //    }
            //    else
            //    {
            //        this.gpxFlotante.Visible = true;
            //        existeDescripcionArticulo = true;
            //    }


            //}


        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == (char)Keys.Escape)
            //{
            //    this.gpxFlotante.Visible = false;
            //}
        }
        private void EnfocarAnteriorControl(string nombreControl)
        {
            switch (nombreControl)
            {
                case "txtMinimo":
                    txtSeguridad.Focus();
                    break;

                case "txtSeguridad":
                    txtMinimo.Focus();
                    break;
                case "txtMaximo":
                    txtSeguridad.Focus();
                    break;
                case "txtReponer":
                    txtMaximo.Focus();
                    break;

                case "txtStockIni":
                    txtReponer.Focus();
                    break;
                case "txtPromDolar":
                    txtStockIni.Focus();
                    break;
                case "txtImpDolar":
                    txtPromDolar.Focus();
                    break;
                case "txtPromSoles":
                    txtImpDolar.Focus();
                    break;

                case "txtImpSoles":
                    txtPromSoles.Focus();
                    break;
                case "dtpFecha":
                    txtImpSoles.Focus();
                    break;
                default: break;
            }
        }
        private void EnfocarSiguienteControl(string nombreControl)
        {
            switch (nombreControl)
            {

                case "txtMinimo":
                    txtSeguridad.Focus();
                    break;
                case "txtSeguridad":
                    txtMaximo.Focus();
                    break;
                case "txtMaximo":
                    txtReponer.Focus();
                    break;
                case "txtReponer":
                    txtStockIni.Focus();
                    break;

                case "txtStockIni":
                    txtPromDolar.Focus();
                    break;
                case "txtPromDolar":
                    txtImpDolar.Focus();
                    break;
                case "txtImpDolar":
                    txtPromSoles.Focus();
                    break;
                case "txtPromSoles":
                    txtImpSoles.Focus();
                    break;

                case "txtImpSoles":
                    dtpFecha.Focus();
                    break;
                case "dtpFecha":
                    txtMinimo.Focus();
                    break;
                default: break;
            }
        }
        private void EventoTextoKeyDown(object sender, KeyEventArgs e)
        {
            //sender
            string nombreControl = ((RadTextBox)sender).Name;
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Down)
            {
                EnfocarSiguienteControl(nombreControl);
            }
            else if (e.KeyValue == (char)Keys.Up)
            {
                EnfocarAnteriorControl(nombreControl);
            }

        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Down)
            {
                txtMinimo.Focus();
            }
            else if (e.KeyValue == (char)Keys.Up)
            {
                txtImpSoles.Focus();
            }
        }

        private void txtUniEquiv_TextChanged(object sender, EventArgs e)
        {
            //if(txtUnidad
            if (txtUnidad.Text.Trim() == txtUniEquiv.Text.Trim())
            {
                radLabel9.Visible = false;
                txtMontoEquivalente.Visible = false;
                //asignar por defecto el valor de uno a monto Equivalente  si las unidades tiene el mismo valor
                txtMontoEquivalente.Text = "1";
            }
            else
            {
                radLabel9.Visible = true;
                txtMontoEquivalente.Visible = true;
                txtMontoEquivalente.Text = "";
            }
            //txtUnidad

            //txtUniEquiv
        }

        private void txtUnidad_TextChanged(object sender, EventArgs e)
        {
            if (txtUnidad.Text.Trim() == txtUniEquiv.Text.Trim())
            {
                radLabel9.Visible = false;
                txtMontoEquivalente.Visible = false;
                //asignar por defecto el valor de uno a monto Equivalente  si las unidades tiene el mismo valor
                txtMontoEquivalente.Text = "1";
            }
            else
            {
                radLabel9.Visible = true;
                txtMontoEquivalente.Visible = true;
                txtMontoEquivalente.Text = "";
            }
        }
        private void frmArticuloSuministroDet_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            System.Data.DataTable dt = CompraArticuloLogic.Instace.TraeEstructuraCodigo("TODOS", 
                                                                Logueo.CodigoEmpresa, "TODAS");
            if (dt.Rows.Count > 0)
            {
                aLongitudCodigos = new int[dt.Rows.Count];
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    aLongitudCodigos[x] = Convert.ToInt32(dt.Rows[x]["Fin"]);
                }
            }

            CrearColumnasAlmacen();
            //VerMantenimiento(true); // Mantenimiento detalle de Articulo (Almacen)
            //txtImpDolar.ReadOnly = true; txtImpSoles.ReadOnly = true;
            txtImpDolar.Enabled = false; txtImpSoles.Enabled = false;

            if (FrmParent.codigoArticulo != "")
            {
                CargarArticulo();
            }

            //Iniciar la ventana de agregar descripcion de producto.
            Point ubicacionGrupoFlotante = new Point();
            ubicacionGrupoFlotante.X = this.txtDescripcion.Location.X;
            ubicacionGrupoFlotante.Y = this.txtDescripcion.Location.Y + this.txtDescripcion.Height;
            this.gpxFlotante.Location = ubicacionGrupoFlotante;
            this.gpxFlotante.Visible = false;
            CrearColumnasSugerencia();



            //Iniciar los botones y cotnroles segun el estado del formulario
            Estado = FrmParent.Estado;
            ConfiguraEstadoFormulario(Estado);

            //oculta panel de detalle de almacen
            rpDetalleAlmacen.Visible = false;
            (rpvDetalle.ViewElement as RadPageViewStripElement).ShowItemCloseButton = false;

        }



        private void TraeAyudaDetalle(enmAyuda tipo)
        {
            // * -> Todos
            frmBusqueda frm = new frmBusqueda(tipo, "04");
            frm.ShowDialog();
            if (frm.Result == null) return;
            if (frm.Result.ToString() == "") return;

            string[] datos = frm.Result.ToString().Split('|');

            Util.SetValueCurrentCellText(gridAlmacen.CurrentRow, "In04CodAlm", datos[0]);
                Almacen registro =     AlmacenLogic.Instance.AlmacenTraerRegistro(Logueo.CodigoEmpresa,
                                        Util.GetCurrentCellText(gridAlmacen.CurrentRow, "In04CodAlm"));
                
                Util.SetValueCurrentCellText(gridAlmacen.CurrentRow, "In09Descripcion", registro.in09descripcion);
            GuardarAlmacen(Estado);
        }
        #region "Formulario Almacen"
        private void GuardarAlmacen(FormEstate estadoCabecera)
        {
            //Si la cabecera es Nuevo
            if (estadoCabecera == FormEstate.New)
            {
                //Permitir agregar mas ayuda sin guardar de manera directa a la BD.

            }
            //else if (estadoCabecera == FormEstate.List || estadoCabecera == FormEstate.View)
            else if (estadoCabecera == FormEstate.Edit)
            {
                //DetAlm.InsertaDetArtixAlm(
                GuardarAlm();
            }
        }
        private void CargarAlm()
        {
            try
            {
                string codigoArticulo = txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();
                this.gridAlmacen.DataSource = DetAlm.TraerAlmacenesxArticulo(codigoArticulo);
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al cargar");
            }

        }

        private void GuardarAlm()
        {
            Cursor.Current = Cursors.WaitCursor;
            string sCodigoProducto = txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();

            string sCodigoAlmacen = "";
            string sUbicacion = "";

            //sUbicacion =  Util.GetCurrentCellText(gridAlmacen.CurrentRow, "In04Ubicac");
            sUbicacion = txtUbicacion.Text.Trim();
            sCodigoAlmacen = Util.GetCurrentCellText(gridAlmacen.CurrentRow, "In04CodAlm");

            double nMinimo = 0, nSeguridad = 0, nMaximo = 0, nReponer = 0, nStockInicial = 0, nPromDolar = 0, nImpoDolar = 0, nPromSoles = 0, nImpSoles = 0;




            nMinimo = txtMinimo.Text.Trim() == "" ? 0 : Convert.ToDouble(txtMinimo.Text.Trim());
            nSeguridad = txtSeguridad.Text.Trim() == "" ? 0 : Convert.ToDouble(txtSeguridad.Text.Trim());
            nMaximo = txtMaximo.Text.Trim() == "" ? 0 : Convert.ToDouble(txtMaximo.Text.Trim());
            nReponer = txtReponer.Text.Trim() == "" ? 0 : Convert.ToDouble(txtReponer.Text.Trim());
            nStockInicial = txtStockIni.Text.Trim() == "" ? 0 : Convert.ToDouble(txtStockIni.Text.Trim());
            nPromDolar = txtPromDolar.Text.Trim() == "" ? 0 : Convert.ToDouble(txtPromDolar.Text.Trim());
            nImpoDolar = txtImpDolar.Text.Trim() == "" ? 0 : Convert.ToDouble(txtImpDolar.Text.Trim());
            nPromSoles = txtPromSoles.Text.Trim() == "" ? 0 : Convert.ToDouble(txtPromSoles.Text.Trim());
            nImpSoles = txtImpSoles.Text.Trim() == "" ? 0 : Convert.ToDouble(txtImpSoles.Text.Trim());

            DateTime dFecha;



            try
            {
                int nFlag = 0; string sMensaje = "";
                if (EstadoDetalle == DetailEstate.New)
                {

                    dFecha = DateTime.Now;
                    DetAlm.InsertaDetArtixAlm(sCodigoProducto, sCodigoAlmacen, sUbicacion, nMinimo, nSeguridad, nMaximo, nReponer, nStockInicial, nPromDolar,
                        nImpoDolar, nPromSoles, nImpSoles, dFecha.ToShortDateString(), out nFlag, out sMensaje);
                }
                else if (EstadoDetalle == DetailEstate.Edit)
                {
                    dFecha = dtpFecha.Value;
                    DetAlm.ActualizaDettArtixAlm(sCodigoProducto, sCodigoAlmacen, sUbicacion, nMinimo, nSeguridad, nMaximo, nReponer,
                    nStockInicial, nPromDolar, nImpoDolar, nPromSoles, nImpSoles, dFecha.ToShortDateString(), out nFlag, out sMensaje);
                }

                Util.ShowMessage(sMensaje, nFlag);
                if (nFlag == 1)
                {
                    //VerMantenimiento(true);
                    HabilitaControlAlmacen(false);
                    

                    string codigoAlmacen = Util.GetCurrentCellText(gridAlmacen.CurrentRow, "In04CodAlm");
                    CargarAlm();
                    Util.enfocarFila(gridAlmacen, "In04CodAlm", codigoAlmacen);
                    EstadoDetalle = DetailEstate.Read;
                }
                else if (nFlag == -1) 
                {
                    EliminarFilaSeleccionada(gridAlmacen);
                }

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al guardar Almacen ");
            }
            Cursor.Current = Cursors.Default;
        }
        public void EliminarFilaSeleccionada(RadGridView gridView) 
        {

            //IMITANDO EN GRID DE ESTA MANERA
            var Grilla = new List<GridViewRowInfo>();

            foreach (GridViewRowInfo row in gridView.SelectedRows)
            {
                Grilla.Add(row);
            }
            foreach (GridViewRowInfo info in Grilla)
            {
                gridView.Rows.Remove(info);
            }

            
        }
        private void AgregarFilaAlmacen()
        {
            try
            {
                if (gridAlmacen.Rows.Count > 0)
                {
                    Util.RestoreFila(gridAlmacen, gridAlmacen.Rows[gridAlmacen.Rows.Count - 1]);
                }
                gridAlmacen.Rows.AddNew();
                Util.SetCellGridFocus(gridAlmacen.CurrentRow, "In04CodAlm");
                Util.ResaltarAyuda(gridAlmacen.CurrentRow.Cells["In04CodAlm"]);
                Util.SetValueCurrentCellText(gridAlmacen.CurrentRow, "flag", "0");
                TraeAyudaDetalle(enmAyuda.enmAlmacen);
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al agregar fila de almacen");
            }
        }
        private void CancelarAlm()
        {
            try
            {
                LimpiarAlmacen();
                //VerMantenimiento(true);
                rpDetalleAlmacen.Visible = false;
                this.OcultaBotonesDetalle();
                this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnNuevoDet);
                this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEditarDet);
                this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnEliminarDet);
                HabilitaControlAlmacen(false);

                EstadoDetalle = DetailEstate.Read; // Habilia el cambio de fila en la grilla
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al cancelar");
            }
        }
        private void NuevoAlm()
        {
            try
            {
                
                if (Estado == FormEstate.New || Estado == FormEstate.Edit)
                {
                    EstadoDetalle = DetailEstate.New;
                    AgregarFilaAlmacen();
                }
                else
                {
                    Util.ShowAlert("Debe terminar el proceso de Guardar Articulo"); return;
                }

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al crear nuevo almacen");
            }
        }
        private void EditaAlm()
        {

            if (gridAlmacen.Rows.Count == 0) return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (Estado == FormEstate.Edit || Estado == FormEstate.New)
                {
                    //VerMantenimiento(false);
                    rpDetalleAlmacen.Visible = true;
                    this.OcultaBotonesDetalle();
                    this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnGuardarDet);
                    this.HabilitaBotonesDetalle(BaseRegBotonesDetalle.btnCancelarDet);

                    HabilitaControlAlmacen(true);



                    CargarRegistroAlmacen();

                    txtUbicacion.Focus();

                    EstadoDetalle = DetailEstate.Edit;
                }
                else
                {
                    Util.ShowAlert("Debe terminar el proceso actual");

                }
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al editar almacen");
            }
            Cursor.Current = Cursors.Default;
        }

        private void EliminarAlm()
        {
            try
            {
                if (gridAlmacen.Rows.Count == 0) return;
                if (Estado == FormEstate.List || Estado == FormEstate.View || Estado == FormEstate.Edit)
                {

                    string flag = Util.GetCurrentCellText(gridAlmacen.CurrentRow, "flag");
                    if (flag == "0") // 0-> Nuevo, 1 -> Edita
                    {
                        int indiceFila = gridAlmacen.CurrentRow.Index;
                        gridAlmacen.Rows.RemoveAt(indiceFila);
                    }
                    else
                    {
                        bool respuesta = Util.ShowQuestion("¿Estás Seguro de Borrar el Almacen?");
                        if (respuesta == true)
                        {

                            string codArt = txtLinea.Text.Trim() + txtGrupo.Text.Trim() + txtSubGrupo.Text.Trim() + txtDetalle.Text.Trim();
                            int nFlag = 0; string sMensaje = "";
                            string codigoAlmacen = Util.GetCurrentCellText(gridAlmacen.CurrentRow, "In04CodAlm");
                            DetAlm.EliminarDetArtixAlm(codArt, codigoAlmacen, out nFlag, out sMensaje);
                            if (nFlag == 1)
                            {
                                CargarAlm();
                            }

                        }
                    }

                }
                else
                {
                    Util.ShowAlert("Debe terminar el proceso actual");

                }
            }
            catch (Exception ex)
            {
                Util.ShowAlert("Erro al elimianr almacen");
            }
        }

        private void IniciaDetalleAlmacen()
        {

            //txtCodAlm.Text = "01"; txtUbicacion.Text = "";
            txtMinimo.Text = "0"; txtSeguridad.Text = "0";
            txtMaximo.Text = "0"; txtReponer.Text = "0";
            txtStockIni.Text = "0"; txtPromDolar.Text = "0";
            txtImpDolar.Text = "0";
            txtPromSoles.Text = "0"; txtImpSoles.Text = "0";
            dtpFecha.Value = DateTime.Now;
        }
        //private void VerMantenimiento(bool estado) {
        //    rcbAlmacenPrincipal.Enabled = estado;
        //    rcbAlmacenProceso.Enabled = !estado;

        //}
        private void OcultaBotonesDetalle()
        {
            cbbNuevoAlmacen.Enabled = false;
            cbbEditaAlmacen.Enabled = false;
            cbbEliminaAlmacen.Enabled = false;
            cbbCancelarAlmacen.Enabled = false;
            cbbGuardarAlmacen.Enabled = false;
        }
        private void HabilitaBotonesDetalle(BaseRegBotonesDetalle nombre)
        {
            switch (nombre)
            {
                case BaseRegBotonesDetalle.btnNuevoDet:
                    cbbNuevoAlmacen.Enabled = true;
                    break;
                case BaseRegBotonesDetalle.btnEditarDet:
                    cbbEditaAlmacen.Enabled = true;
                    break;
                case BaseRegBotonesDetalle.btnEliminarDet:
                    cbbEliminaAlmacen.Enabled = true;
                    break;
                case BaseRegBotonesDetalle.btnCancelarDet:
                    cbbCancelarAlmacen.Enabled = true;
                    break;
                case BaseRegBotonesDetalle.btnGuardarDet:
                    cbbGuardarAlmacen.Enabled = true;
                    break;

                default:
                    break;
            }
        }
        private void HabilitaControlAlmacen(bool estado)
        {
            //txtCodAlm.Enabled = estado;
            //lblAlmacen.Enabled = false;

            txtUbicacion.Enabled = estado;

            txtMinimo.Enabled = estado;
            txtSeguridad.Enabled = estado;
            txtMaximo.Enabled = estado;
            txtReponer.Enabled = estado;


            txtStockIni.Enabled = estado;
            txtPromDolar.Enabled = estado;
            //txtImpDolar.Enabled = estado;
            txtPromSoles.Enabled = estado;
            //txtImpSoles.Enabled = estado;
            //txtFecha.Enabled = estado;
            dtpFecha.Enabled = estado;

            lblStockActual.ForeColor = Color.RosyBrown;
            lblStockActual.Enabled = false;
            lblUltimaCompra.Enabled = false;
            lblCostoPromSoles.Enabled = false;
            lblUltimoCostoSoles.Enabled = false;
            lblCostoPromDolar.Enabled = false;
            lblUltimoCostoDolar.Enabled = false;

            //Util.SetValueCurrentCellText(gridAlmacen.CurrentRow, "flag", "1");

        }
        private void AddCmdButtonToGrid(RadGridView Grid, string NameButon, string TextButton, string ColumnGrid)
        {
            GridViewCommandColumn cmdbtn = new GridViewCommandColumn();
            cmdbtn.Name = NameButon;
            cmdbtn.HeaderText = TextButton;
            Grid.Columns.Add(cmdbtn);
            Grid.Columns[NameButon].Width = 30;
        }

        private void CrearColumnasAlmacen()
        {
            bool EditaSi = true, EditaNo = false, LecturaSi = true, LecturaNo = false;
            bool VisibleSi = true, VisibleNo = false;
            RadGridView Grid = CreateGridVista(this.gridAlmacen);
            CreateGridColumn(Grid, "Alm", "In04CodAlm", 0, "", 70);
            CreateGridColumn(Grid, "Descripción", "In09Descripcion", 0, "", 200);

            //CreateGridColumn(Grid, "Ubicación", "In04Ubicac", 0, "", 70,LecturaNo, EditaSi, VisibleSi);                                                                        
            CreateGridColumn(Grid, "Stock Actual", "In04Stock", 0, "", 70, true, false, true, true, alinear.derecha);
            CreateGridColumn(Grid, "flag", "flag", 0, "", 90, LecturaNo, EditaSi, VisibleNo);

            //AddCmdButtonToGrid(Grid, "btnEliminarDet", "", "btnEliminarDet");
            //AddCmdButtonToGrid(Grid, "btnEditarDet", "", "btnEditarDet");
            //AddCmdButtonToGrid(Grid, "btnCancelarDet", "", "btnCancelarDet");
            //AddCmdButtonToGrid(Grid, "btnGrabarDet", "", "btnGrabarDet");
        }

        private void cbbGuardarAlmacen_Click(object sender, EventArgs e)
        {
            GuardarAlm();
        }

        private void cbbCancelarAlmacen_Click(object sender, EventArgs e)
        {
            CancelarAlm();
        }

        private void cbbNuevoAlmacen_Click(object sender, EventArgs e)
        {
            NuevoAlm();
        }

        private void cbbEditaAlmacen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            EditaAlm();
            Cursor.Current = Cursors.Default;
        }

        private void cbbEliminaAlmacen_Click(object sender, EventArgs e)
        {
            EliminarAlm();

        }
        private void LimpiarAlmacen()
        {
            //Limpiar controles
            lblCodAlmcen.Text = ""; lblDesAlmacen.Text = "";
            txtUbicacion.Text = "";
            txtMinimo.Text = "";
            txtSeguridad.Text = "";
            txtMaximo.Text = "";
            txtReponer.Text = "";
            txtStockIni.Text = "";
            txtPromDolar.Text = "";
            txtImpDolar.Text = "";
            txtPromSoles.Text = "";
            //Limpiar controles
            lblStockActual.Text = "";
            lblUltimaCompra.Text = "";
            lblCostoPromSoles.Text = "";
            lblUltimoCostoSoles.Text = "";
            lblCostoPromDolar.Text = "";
            lblUltimoCostoDolar.Text = "";
        }
        private void CargarRegistroAlmacen()
        {

            try
            {
                string codigoAlmacen = Util.GetCurrentCellText(this.gridAlmacen, "In04CodAlm");
                string descripcionAlmacen = Util.GetCurrentCellText(this.gridAlmacen, "In09Descripcion");
                string codigoArticulo = this.txtLinea.Text.Trim() +
                                        this.txtGrupo.Text.Trim() +
                                        this.txtSubGrupo.Text.Trim() +
                                        this.txtDetalle.Text.Trim();

                LimpiarAlmacen();
                //Carga datos de base de datos

                List<ArticuloPorAlmacen> lista = DetAlm.TraeRegistro(codigoAlmacen, codigoArticulo);
                if (lista.Count > 0)
                {


                    lblCodAlmcen.Text = codigoAlmacen;
                    lblDesAlmacen.Text = descripcionAlmacen;

                    txtUbicacion.Text = Util.convertiracadena(lista[0].IN04UBICAC);
                    txtMinimo.Text = Util.convertiracadena(lista[0].IN04STOMIN);
                    txtSeguridad.Text = Util.convertiracadena(lista[0].IN04STOSEG);
                    txtMaximo.Text = Util.convertiracadena(lista[0].IN04STOMAX);
                    txtReponer.Text = Util.convertiracadena(lista[0].IN04STOREP);
                    txtStockIni.Text = Util.convertiracadena(lista[0].IN04STOCK);
                    txtPromDolar.Text = Util.convertiracadena(lista[0].IN04PROMDOL);
                    txtImpDolar.Text = (Convert.ToDouble(txtStockIni.Text) * Convert.ToDouble(txtPromDolar.Text)).ToString();
                    txtPromSoles.Text = Util.convertiracadena(lista[0].IN04PROMSOL);

                    txtImpSoles.Text = (Convert.ToDouble(txtStockIni.Text) * Convert.ToDouble(txtPromSoles.Text)).ToString();

                    if (lista[0].IN04FECINI == "")
                    {
                        dtpFecha.SetToNullValue();
                        dtpFecha.Value = DateTime.Now;
                    }
                    else
                    {
                        dtpFecha.Value = Convert.ToDateTime(lista[0].IN04FECINI);
                    }

                }


                List<ArticuloPorAlmacen> listaEtiqueta = DetAlm.TraeRegistroEtiqueta(codigoAlmacen, codigoArticulo);
                if (listaEtiqueta.Count > 0)
                {
                    lblStockActual.Text = Util.convertiracadena(listaEtiqueta[0].IN04STOCK);
                    lblUltimaCompra.Text = Util.convertiracadena(listaEtiqueta[0].IN04FECHAING);
                    lblCostoPromSoles.Text = Util.convertiracadena(listaEtiqueta[0].IN04PROMSOL);
                    lblUltimoCostoSoles.Text = Util.convertiracadena(listaEtiqueta[0].IN04ULTCOSSOL);
                    lblCostoPromDolar.Text = Util.convertiracadena(listaEtiqueta[0].IN04PROMDOL);
                    lblUltimoCostoDolar.Text = Util.convertiracadena(listaEtiqueta[0].IN04ULTCOSDOL);
                }

            }
            catch (Exception ex)
            {
                Util.ShowAlert("Error al seleccionar registro de almacen:" + ex.Message);
            }
        }
        private void gridAlmacen_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            //CargarRegistroAlmacen();
        }
        private void gridAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {

                if (Util.IsCurrentColumn(gridAlmacen, "In04CodAlm"))
                {
                    TraeAyudaDetalle(enmAyuda.enmAlmacen);
                }
            }
        }
        private void gridAlmacen_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                GridCommandCellElement cellElement = e.CellElement as GridCommandCellElement;
                if (cellElement == null) return;
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {
                    if (gridAlmacen.Rows[e.RowIndex].Cells["flag"].Value == null)
                        habilitarBotonProdDet(e.Column.Name, cellElement, false, false, true, true);
                    else
                        habilitarBotonProdDet(e.Column.Name, cellElement, true, true, false, false);


                }

            }
            catch (Exception ex)
            {
                Util.ShowError("Error cellformating: " + ex.Message);
            }
        }
        private void gridAlmacen_CommandCellClick(object sender, EventArgs e)
        {
            //GridViewRowInfo fila = this.gridAlmacen.CurrentRow;
            if (this.gridAlmacen.Columns["btnGuardarDet"].IsCurrent)
            {
                //GuardarGrupoArticulo(fila);
                GuardarAlm();
            }

            if (this.gridAlmacen.Columns["btnCancelarDet"].IsCurrent)
            {
                CancelarAlm();
            }

            if (this.gridAlmacen.Columns["btnEliminarDet"].IsCurrent)
            {
                //EliminarGrupoArticulo(fila);
                EliminarAlm();
            }

            if (this.gridAlmacen.Columns["btnEditarDet"].IsCurrent)
            {
                //EditarGrupoArticulo(fila);
                EditaAlm();
            }
        }

        #endregion
        private void habilitarBotonProdDet(string nombre, GridCommandCellElement CommandCell, bool bGrabar,
                                           bool bCancelar, bool bEliminar, bool bEditar)
        {
            GridCommandCellElement cellElement = CommandCell;
            switch (nombre)
            {
                case "btnGrabarDet":
                    cellElement.CommandButton.Image = bGrabar ? Properties.Resources.save_enabled : Properties.Resources.save_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bGrabar;
                    break;

                case "btnCancelarDet":
                    cellElement.CommandButton.Image = bCancelar ? Properties.Resources.cancel_enabled : Properties.Resources.cancel_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bCancelar;
                    break;

                case "btnEliminarDet":
                    cellElement.CommandButton.Image = bEliminar ? Properties.Resources.deleted_enabled : Properties.Resources.deleted_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEliminar;
                    break;

                case "btnEditarDet":
                    cellElement.CommandButton.Image = bEditar ? Properties.Resources.edited_enabled : Properties.Resources.edited_disabled;
                    cellElement.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
                    cellElement.CommandButton.Enabled = bEditar;
                    break;

                default:
                    break;
            }
        }

        private void txtProveedorCod_TextChanged(object sender, EventArgs e)
        {
            //lblHelp(4) = DameDescripcion(gbCodEmpresa$ + gbTipoAnaPro$ + txtProveedor, "PROVEEDOR")
            if (txtProveedorCod.Text.Trim() == "")
            {
                txtProveedorDesc.Text = "";
            }
            else {
                ArticuloCabecera artiLogico = new ArticuloCabecera();
                string descripcion = "";
                artiLogico.DameDescripcion(Logueo.CodigoEmpresa + Logueo.TipoAnalisisProveedor + txtProveedorCod.Text.Trim(),
                    "PROVEEDOR", out descripcion);
                txtProveedorDesc.Text = descripcion;
            }
            
            
        }

        private void txtProveedorCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                TraerAyudaCab(enmAyuda.enmProveedor);
            }
        }

        private void gridAlmacen_Click(object sender, EventArgs e)
        {

        }

        //private void txttipoctacble_KeyDown_1(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == (char)Keys.F1)
        //    {
        //        TraerAyudaCab(enmAyuda.enmCuentaContable);
        //    }
        //}
    }
    
    #region "Cabecera Articulo Actualizacion"
    public class ArticuloCabecera
    {
        public ArticuloCabecera() { }
        public void DameDescripcion(string codigoBusqueda, string flagBusqueda, out string descripcion)
        {
            GlobalLogic.Instance.DameDescripcionCompras(codigoBusqueda, flagBusqueda, out descripcion);
        }

        public List<Articulo> AutocompletarArticulo(string @cFiltro)
        {
            return CompraArticuloLogic.Instace.AutocompletarArticulo(Logueo.CodigoEmpresa, Logueo.Anio, "C", "In01DesLar", @cFiltro);
        }

    }
    #endregion
    #region"Detalle Ubicacion(Almacenn)"
    public class DetalleAlmacen
    {
        public DetalleAlmacen() { }

        //public List<ComprasArticuloUbicacion> TraeDetalle(string codigoArticulo, string codigoAlmacen){

        //        return CompraArticuloLogic.Instace.TraeUbicacion(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, codigoArticulo, codigoAlmacen);
        //}
        public List<ComprasArticuloAlmacen> TraerAlmacenesxArticulo(string codigoArticulo)
        {
            return CompraArticuloLogic.Instace.TraeAlmacenesxArti(Logueo.CodigoEmpresa, Logueo.Anio,
                Logueo.Mes, codigoArticulo, "*");
        }

        public List<ArticuloPorAlmacen> TraeRegistro(string codigoAlmacen, string codigoArticulo)
        {
            return CompraArticuloLogic.Instace.TraeAlmxArtiRegistro(Logueo.CodigoEmpresa,
             Logueo.Anio, codigoAlmacen, codigoArticulo);
        }
        public List<ArticuloPorAlmacen> TraeRegistroEtiqueta(string codigoAlmacen, string codigoArticulo)
        {

            return CompraArticuloLogic.Instace.TraeAlmxArtiRegistroEtiqueta(Logueo.CodigoEmpresa,
                Logueo.Anio, Logueo.Mes, codigoAlmacen, codigoArticulo);
        }
        public void InsertaDetArtixAlm(string @cCodigo,
       string @cCodAlm, string @cUbicacion, double @nMinimo, double @nSeguridad,
       double @nMaximo, double @nReponer, double @nStockInicial, double @nPromDolar,
       double @nImpDolar, double @nPromSoles, double @nImpSoles, string @dFecha,
       out int @flag, out string @cMsgRetorno)
        {
            CompraArticuloLogic.Instace.InsertaDetArtixAlm(Logueo.CodigoEmpresa,
             Logueo.Anio,Logueo.Mes, @cCodigo, @cCodAlm, @cUbicacion, @nMinimo,
             @nSeguridad, @nMaximo, @nReponer, @nStockInicial, @nPromDolar,
             @nImpDolar, @nPromSoles, @nImpSoles, @dFecha, out  @flag, out  @cMsgRetorno);
        }



        public void EliminarDetArtixAlm(string @cCodigo, string @cCodAlm,
         out int @flag, out string @cMsgRetorno)
        {
            CompraArticuloLogic.Instace.EliminarDetArtixAlm(Logueo.CodigoEmpresa, Logueo.Anio,
             @cCodigo, @cCodAlm, out @flag, out @cMsgRetorno);
        }


        public List<Almacen> TraeAyuda()
        {
            return CompraArticuloLogic.Instace.TraeAyudaAlmacen(Logueo.CodigoEmpresa, "", "*");
        }


        public void ActualizaDettArtixAlm(string @cCodigo, string @cCodAlm,
        string @cUbicacion, double @nMinimo, double @nSeguridad, double @nMaximo, double @nReponer,
        double @nStockInicial, double @nPromDolar, double @nImpDolar, double @nPromSoles, double @nImpSoles,
        string @dFecha, out int @flag, out string @cMsgRetorno)
        {
            CompraArticuloLogic.Instace.ActualizaDettArtixAlm(Logueo.CodigoEmpresa,
            Logueo.Anio, @cCodigo, @cCodAlm,
            @cUbicacion, @nMinimo, @nSeguridad, @nMaximo, @nReponer,
            @nStockInicial, @nPromDolar, @nImpDolar, @nPromSoles, @nImpSoles,
            @dFecha, out @flag, out @cMsgRetorno);

        }



    }
    #endregion


}
