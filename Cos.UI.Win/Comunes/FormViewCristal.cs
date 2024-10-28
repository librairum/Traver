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

namespace Cos.UI.Win
{
    public partial class FormViewCristal : Form
    {
        public FormViewCristal()
        {
            InitializeComponent();
        }

        public FormViewCristal(string titulo)
        {
            InitializeComponent();
            this.Titulo = titulo;
        }

        public Reporte Reporte { get; set; }
        public string Titulo { get; set; }

        #region Metodos Nuevos
        public void Output(DestinoReporte destino)
        {
            try
            {
                this.Text = this.Titulo;
                this.crv.Dock = DockStyle.Fill;
                this.crv.ShowRefreshButton = false;

                ReportDocument rep = new ReportDocument();
                
                //Abro el reporte y Asigna el DataSource
                rep.Load(this.Reporte.GetPathReporte());
                rep.SetDataSource(this.Reporte.DataSource);

                //Abro y Asigno subReportes si tuviera el reporte
                if (this.Reporte.SubReportes != null)
                {
                    this.SetSubReports(rep, this.Reporte.SubReportes);
                }

                //Capturo los parametros del reporte
                ParameterFields parameterFields = rep.ParameterFields;
                if (this.Reporte.ParametersFields != null)
                {
                    this.SetCurrentValuesForParameterField(rep, parameterFields, this.Reporte.ParametersFields);
                }

                //Capturo las Formulas y asigno los valores
                if (this.Reporte.FormulasFields != null)
                {
                    this.SetCurrentValuesForFormulaField(rep, this.Reporte.FormulasFields);
                }

                this.crv.ReportSource = rep;

                if (destino == DestinoReporte.impresora)
                {
                    //Imprime el reporte
                    this.crv.PrintReport();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SetSubReports(ReportDocument rep, IList<SubReporte> subReportes)
        {
            if (subReportes == null) return;
            if (subReportes.Count == 0) return;

            //En este bucle recorremos la lista de subreportes del reporte y le asignamos subReporte
            foreach (var item in subReportes)
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
        }

        private void FormViewCristal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Reporte != null) this.Reporte.Dispose();
            this.Reporte = null;
        }
    }
}
