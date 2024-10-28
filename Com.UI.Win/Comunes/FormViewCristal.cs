using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Com.UI.Win
{
    public partial class FormViewCristal : Form
    {
        public FormViewCristal()
        {
            InitializeComponent();
        }

        public FormViewCristal(string titulo) {
            InitializeComponent();
            
        }

        public Reporte Reporte { get; set; }
        public string Titulo { get; set; }
        public string NombreArchivo { get; set; }

        #region "Metodos Nuevos"
        public void Output(DestinoReporte destino) {

            try
            {
                this.Text = this.Titulo;
                this.crv.Dock = DockStyle.Fill;
                this.crv.ShowRefreshButton = false;

                ReportDocument rep = new ReportDocument();

                //Abro el repote y asigno el datasource
                rep.Load(this.Reporte.GetPathReporte());
                rep.SetDataSource(this.Reporte.DataSource);

                //Abro y asigno subreporte si tuviera el reporte
                if (this.Reporte.SubReportes != null) {
                    this.SetSubReports(rep, this.Reporte.SubReportes);
                }

                ParameterFields parameterFields = rep.ParameterFields;

                if (this.Reporte.ParametersFields != null)
                {
                    this.SetCurrentValuesForParameterField(rep, parameterFields, this.Reporte.ParametersFields);
                }

                if (this.Reporte.FormulasFields != null) {
                    this.SetCurrentValuesForFormulaField(rep, this.Reporte.FormulasFields);
                }

                this.crv.ReportSource = rep;

                if (destino == DestinoReporte.impresora) {
                    this.crv.PrintReport();
                }
                else if (destino == DestinoReporte.pdf) {
                    Util.ExportarEnFormatoPDF(rep, this.NombreArchivo);
                }
                else if (destino == DestinoReporte.correo) {
                    Util.ExportarEnCorreo(rep, this.NombreArchivo);
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetSubReports(ReportDocument rep, IList<SubReporte> suBReportes) 
        {
            if (suBReportes == null) return;
            if (suBReportes.Count == 0) return;

            foreach (var item in suBReportes) 
            {
                rep.OpenSubreport(item.Nombre).SetDataSource(item.DataSource);
            }


        }
        private void SetCurrentValuesForFormulaField(ReportDocument rep, IList<Formula> formulas) 
        {
            //En este bucle recorremos la lista de parametros del reporte y le asignamos valores
            foreach (var item in formulas) 
            {
                rep.DataDefinition.FormulaFields[item.Nombre].Text = "'" + item.Valor + "'";
            }
        }

        private void SetCurrentValuesForParameterField(ReportDocument rep, ParameterFields parameterFields, IList<Paramentro> parametros)
        {
            if (parametros == null) return;
            ParameterValues currentParameterValues = new ParameterValues();

            foreach (var item in parametros)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = item.Valor;
                currentParameterValues.Add(parameterDiscreteValue);

                ParameterField parameterField = parameterFields[item.Nombre];
                parameterField.CurrentValues = currentParameterValues;

                //Asigno Parametros al Reporte
                rep.ParameterFields[item.Nombre].CurrentValues.Add(parameterDiscreteValue);
            }
        }
        #endregion


        public DataTable RPTData { get; set; }
        public string RPTName { get; set; }


        private void FormViewCristal_Load(object sender, EventArgs e)
        {
            this.Output(DestinoReporte.pantalla);
            //if (bool_cerrarVentana == true)
            //{
            //this.Close();

        }

        private void FormViewCristal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Reporte != null) this.Reporte.Dispose();
            this.Reporte = null;
        }
    }
}
