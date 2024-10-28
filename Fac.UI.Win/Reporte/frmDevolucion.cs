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
using System.Data.SqlClient;

namespace Fac.UI.Win
{
    public partial class frmDevolucion : frmBaseReporte
    {
        public frmDevolucion()
        {
            InitializeComponent();
        }

           
        DocumentoLogic datos = DocumentoLogic.Instance;
        private void CrearColumnas()
        {
        
            RadGridView Grid = CreateGrid(this.gridCabecera);

            CreateGridColumn(Grid, "Anio", "Anio", 0, "", 70);
            CreateGridColumn(Grid, "Mes", "Mes", 0, "", 70);
            CreateGridColumn(Grid, "Fec.Doc", "Fecha", 0, "{0:dd/MM/yyyy}", 90);
            CreateGridColumn(Grid, "Tip.Doc", "CodigoTipDoc", 0, "", 90, true, false, false);
            CreateGridColumn(Grid, "Tip.Des", "DescripcionTipDoc", 0, "", 250);
            CreateGridColumn(Grid, "Nro.Doc", "CodigoDocumento", 0, "", 100);
            CreateGridColumn(Grid, "Cliente", "NombreCliente", 0, "", 200);
            CreateGridColumn(Grid, "Transaccion", "DescripcionTransaccion", 0, "", 200);
            CreateGridColumn(Grid, "ReferenciaDoc", "ReferenciaDoc", 0, "", 120);
            Grid.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            
            

            RadGridView GridDetalle = CreateGrid(this.gridDetalle);

            CreateGridColumn(GridDetalle, "CodigoProducto","CodigoProducto", 0, "", 90);
            CreateGridColumn(GridDetalle, "DescripcionProducto","DescripcionProducto", 0, "", 350);
            CreateGridColumn(GridDetalle, "UM", "UnidadMedida", 0, "", 70);
            CreateGridColumn(GridDetalle, "NroCajas", "NroCajas", 0, "", 90); // cadena
            
            CreateGridColumn(GridDetalle, "Largo", "Largo", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(GridDetalle, "Ancho", "Ancho", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(GridDetalle, "Alto", "Alto", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(GridDetalle, "Cantidad", "Cantidad", 0, "{0:###,###0.00}", 90, true, false, true, "right");
            CreateGridColumn(GridDetalle, "Area", "Area", 0, "{0:###,###0.00}", 90, true, false, true, "right"); // double 
            this.gridDetalle.Columns[1].WrapText = true;
            this.gridDetalle.TableElement.RowHeight = 50;
        }
        private void CargarPeriodos(RadDropDownList cbo)
        {
            try
            {
                var periodo = PeriodoLogic.Instance.MesesxAnio(Logueo.CodigoEmpresa, Logueo.Anio);
                cbo.DataSource = periodo;
                cbo.DisplayMember = "ccb03des";
                cbo.ValueMember = "ccb03cod";

                string mes = "";

                mes = DateTime.Now.Month.ToString("0#");

                cbo.SelectedValue = mes;
            }


            catch (Exception)
            {

                throw;
            }
        }
        private void Cargar()
        {
            string mesInicial = "", mesFinal = "";
            mesInicial = Util.convertiracadena(cbomesini.SelectedValue);
            mesFinal = Util.convertiracadena(cbomesfin.SelectedValue);
            try
            {
                List<Devolucion> lista = datos.TraeDevolucionCab(Logueo.CodigoEmpresa, Logueo.Anio, mesInicial, mesFinal);
                this.gridCabecera.DataSource = lista;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error alc argar cabecera de movimiento , detalle : " + ex.Message);
            }
        }

        
        private void CargarDetalle()
        {
            string aniomov = "", mesmov = "", tipoDocumento = "", numeroDocumento = "";
            aniomov = Util.GetCurrentCellText(gridCabecera.CurrentRow, "Anio");
            mesmov = Util.GetCurrentCellText(gridCabecera.CurrentRow, "Mes"); ;
            tipoDocumento = Util.GetCurrentCellText(gridCabecera.CurrentRow, "CodigoTipDoc");
            numeroDocumento = Util.GetCurrentCellText(gridCabecera.CurrentRow, "CodigoDocumento");
            try
            {

                List<Devolucion> listaDetalle = datos.TraeDevolucionDet(Logueo.CodigoEmpresa, aniomov,
                                                mesmov, tipoDocumento, numeroDocumento);
                this.gridDetalle.DataSource = listaDetalle;
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al cargar detalle : " + ex.Message);
            }
        }
        private void frmDevolucion_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            CargarPeriodos(cbomesini);
            CargarPeriodos(cbomesfin);
            Cargar();
            }

        private void gridCabecera_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

            try
            {
                if (e.CurrentRow != null)
                {
                    
                        if (e.CurrentRow.Cells != null)
                        {
                            string valorCelda = "";
                            valorCelda = Util.GetCurrentCellText(gridCabecera.CurrentRow, "CodigoDocumento");
                            if (valorCelda != "")
                            {
                                CargarDetalle();
                            }
                        }

                    
                }
            }
            catch (Exception ex)
            {
                //Util.ShowError("Error al seleccionar fila de grilla cabecera , detalle : " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

    }
}
