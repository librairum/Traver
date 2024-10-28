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
using Com.UI.Win.Procesos;
using Telerik.WinControls.UI.Docking;
using Com.UI.Win.Reportes;
using System.IO;
namespace Com.UI.Win
{
    public partial class FrmRetencionVoucher : frmBaseMante
    {
        private static FrmRetencionVoucher _aForm;
        VoucherLogic LogicaVoucher = VoucherLogic.Instance;
        
        public FrmRetencionVoucher(frmMDI padre)
        {
            InitializeComponent();
        }

        public static FrmRetencionVoucher Instance(frmMDI padre)
        {
            if (_aForm != null) return new FrmRetencionVoucher(padre);
            _aForm = new FrmRetencionVoucher(padre);
            return _aForm;        
        }
        private void CrearColumnas() 
        {
            //resalte de ayuda
            RadGridView grid = CreateGridVista(gridControl);
            grid.EnableFiltering = false;
          //  if(FrmParentDetraccion.Estado == ){}
            //CreateGridColumn(Grid, "Origen", "Amarre", 0, "", 60, true, false, true);// origen de la cuenta contable
            CreateGridColumn(grid, "Retencion", "RetencionNro", 0, "", 90, true, false, true);
            CreateGridColumn(grid, "Fecha", "RetencionFecha", 0, "", 90, true, false, true);
            CreateGridColumn(grid, "RUC", "Ban01Ruc", 0, "", 90, true, false, true);
            CreateGridColumn(grid, "Razon Social ", "Ban01Proveedor", 0, "", 200, true, false, true);
            CreateGridColumn(grid, "Moneda", "Ban01Mon", 0, "", 70, true, false, true);
            CreateGridColumn(grid, "%", "Ban01Porcentaje", 0, "", 90, true, false, true,false,"right");
            CreateGridColumn(grid, "Total S/.", "TotalSoles", 0, "{0:###,###0.00}", 90, true, false, true,false,"right");
            CreateGridColumn(grid, "Ret S/.", "RetencionSoles", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
            CreateGridColumn(grid, "Total US$", "TotalDolares", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
            CreateGridColumn(grid, "Retencion US$", "RetencionDolares", 0, "{0:###,###0.00}", 90, true, false, true, false, "right");
            CreateGridColumn(grid, "Estado SUNAT", "EstadoSunat", 0, "", 200, true, false, true, false, "");
            CreateGridColumn(grid, "Reversion", "reEstadoSunat", 0, "", 200, true, false, true, false, "");
            CreateGridColumn(grid, "Ret.", "Flag", 0, "", 70, true, true, false);
            grid.Rows.AddNew();
        }
        private void FrmRetencionVoucher_Load(object sender, EventArgs e)
        {
           
            OcultarBotones();
            CrearColumnas();
            TraerRetencionVoucher();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGenerarVoucher);
        }
        public void TraerRetencionVoucher() 
        {
            List<RetencionCab> dt = RetencionLogic.Instance.TraerRetencion(Logueo.CodigoEmpresa,Logueo.Anio, Logueo.Mes);
            gridControl.DataSource = dt;
          
        }
        protected override void OnGenerarVoucher()
        {
            bool respuesta = Util.ShowQuestion("¿Desea Generar Voucher?");
            try
            {

            if (respuesta == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GenerarVoucher();
                    Cursor.Current = Cursors.Default;
                    }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex.Message);
                Cursor.Current = Cursors.Default;
            }
        }
        public void GenerarVoucher() 
        {
            try
            {
                if (gridControl.RowCount == 0)
                {
                    MessageBox.Show("No existen Retenciones");
                }
                if (gridControl.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe Seleccionar Rango");
                }
                else
                {
                    string[] nrodocumentos = new string[this.gridControl.SelectedRows.Count];
                    int x = 0;
                    foreach (GridViewRowInfo fila in gridControl.SelectedRows)
                    {
                        nrodocumentos[x] = Util.GetCurrentCellText(fila, "RetencionNro") + "|"+
                                        Util.GetCurrentCellText(fila, "reEstadoSunat");
                        x++;
                    }
                    string xml = Util.ConvertiraXMLdinamico(nrodocumentos);
                    string msgretorno = "";
                    
                    RetencionLogic.Instance.Generar_Voucher(Logueo.CodigoEmpresa, Logueo.Anio, Logueo.Mes, xml, out msgretorno);

                    Util.ShowMessage(msgretorno, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        protected override void OnCancelar()
        {
            this.Close();
        }
        
               
    }
}
