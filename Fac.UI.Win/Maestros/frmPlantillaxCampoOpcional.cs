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

namespace Fac.UI.Win
{
    public partial class frmPlantillaxCampoOpcional : frmBaseReg
    {
        #region "Instancia"
        private static frmPlantillaxCampoOpcional _aForm;
        private frmMDI FrmParent { get; set; }
        public static frmPlantillaxCampoOpcional Instance(frmMDI formParent)
        {
            if (_aForm != null) return new frmPlantillaxCampoOpcional(formParent);
            _aForm = new frmPlantillaxCampoOpcional(formParent);
            return _aForm;
        }
        #endregion
        PlantillaLogic datos = PlantillaLogic.Instance;
        public frmPlantillaxCampoOpcional(frmMDI padre)
        {
            InitializeComponent();
            FrmParent = padre;
           

            gridPlantilla.KeyUp += new KeyEventHandler(gridPlantilla_KeyUp);            
            gridPlantilla.CurrentRowChanged += new CurrentRowChangedEventHandler(gridPlantilla_CurrentRowChanged);                        
            gridCampos.CellBeginEdit += new GridViewCellCancelEventHandler(gridCampos_CellBeginEdit);            
            
            //HabilitarBotones(true, true, false, false, false, false, false);
        }

      

        void gridCampos_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            bool isChecked = false;
            if (e.Column.Name == "FAC72CampoFEvalorDefecto")
            {
                isChecked = Util.GetCurrentCellChkValue(e.Row, "Fac72PlantillaFETipDoc");

                if (isChecked == false)
                {
                    e.Cancel = true;
                }
            }

        }

        

        void gridPlantilla_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            { 
                SendKeys.Send("{TAB}");
            }
        }
        protected override void OnGuardar()
        {
            try
            {
                string xml = ObtenerRegistros();
                string TipDocCod = Util.GetCurrentCellText(gridPlantilla, "TipoDocuCod");
                string PlantiFECod = Util.GetCurrentCellText(gridPlantilla, "Fac70PlantillaFECod");
                //Spu_Fact_Ins_PlantixCamposOpcionales
                string str_Mensaje = ""; int int_flag = 0;
                PlantillaLogic.Instance.InsertaCamposEnPlantilla(TipDocCod, PlantiFECod, xml, out int_flag, out str_Mensaje);

                Util.ShowMessage(str_Mensaje, int_flag);

                if (int_flag == 1)
                    Cargar();
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al guardar: " +ex.Message);
            }
        }
        protected override void OnCancelar()
        {
            this.Close();
        }
        void gridPlantilla_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow != null)
            {
                string TipoDocuCod = Util.GetCurrentCellText(gridPlantilla, "TipoDocuCod");
                string PlantillaFECod = Util.GetCurrentCellText(gridPlantilla, "Fac70PlantillaFECod");
                CargarCamposPorPlantilla(TipoDocuCod, PlantillaFECod);                                
            }
        }
        void CrearColumnasPlantilla()
        { 
            RadGridView Grid =  CreateGridVista(gridPlantilla);
            CreateGridColumn(Grid, "TipoDocuCod", "TipoDocuCod", 0, "", 90);
            CreateGridColumn(Grid, "TipoDocuDesc", "TipoDocuDesc", 0, "", 200);
        
            //-- Plantilla de Factura electronica
            CreateGridColumn(Grid, "PlantillaFE", "Fac70PlantillaFECod", 0, "", 90);
            CreateGridColumn(Grid, "Plan.Fe.Desc", "Fac70PlantillaFEDesc", 0, "", 200);        
        }
        void CrearColumnasCamposxPlantilla()
        { 
            RadGridView Grid = CreateGridVista(gridCampos); 
            CreateGridColumn(Grid, "Tabla", "FAC71TablaDesc", 0, "", 200);
            CreateGridColumn(Grid, "Campo", "FAC71CampoFEDesc", 0, "", 200);
            
            //--'Tabla Campos x Plantilla'            
            CreateGridChkColumn(Grid, "Plant.TipDco", "Fac72PlantillaFETipDoc", 0, "", 90, false, true);                        
            CreateGridColumn(Grid, "ValorxDefecto", "FAC72CampoFEvalorDefecto", 0, "", 90, false, true);
            
        }
        private string ObtenerRegistros()
        {
            bool isSelected = false;
            string xmlCadena = "";
            xmlCadena = "<DataSet>";
            try
            {
                foreach (GridViewRowInfo row in gridCampos.Rows)
                {
                    isSelected = Util.GetCurrentCellChkValue(row, "Fac72PlantillaFETipDoc");
                    if (isSelected == true)
                    {

                        xmlCadena = xmlCadena + "<tbl>";
                        xmlCadena = xmlCadena + "<campo1>" +
                                    Util.GetCurrentCellText(row, "FAC71TablaDesc") + "</campo1>";
                        xmlCadena = xmlCadena + "<campo2>" +
                                    Util.GetCurrentCellText(row, "FAC71CampoFEDesc") + "</campo2>";
                        xmlCadena = xmlCadena + "<campo3>" +
                                    Util.GetCurrentCellText(row, "FAC72CampoFEvalorDefecto") + "</campo3>";
                        xmlCadena = xmlCadena + "</tbl>";
                    }
                }
                xmlCadena = xmlCadena + "</DataSet>";
            }
            catch (Exception ex)
            {
                Util.ShowError("Error al obtener registros: " + ex.Message);
            }
            return xmlCadena;
        }

        private void CrearColumnas()
        {
            CrearColumnasPlantilla();
            CrearColumnasCamposxPlantilla();
     
        }
        private void CargarCamposPorPlantilla(string parTipoDocuCod, string parPlantillaCodigo)
        {
            List<Plantilla> lista = datos.TraeCamposxPlantilla(parTipoDocuCod, parPlantillaCodigo);
            gridCampos.DataSource = lista;
        }
        private void Cargar()
        { 
            gridPlantilla.DataSource =  datos.TraePlantillas();            
        }

        private void frmPlantillaxCampoOpcional_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Cargar();

            Util.ConfigGridToEnterNavigation(gridPlantilla);
            Util.ConfigGridToEnterNavigation(gridCampos);

            OcultarBotones();
            HabilitaBotonPorNombre(BaseRegBotones.cbbGuardar);
            HabilitaBotonPorNombre(BaseRegBotones.cbbCancelar);
        }
    }
}
