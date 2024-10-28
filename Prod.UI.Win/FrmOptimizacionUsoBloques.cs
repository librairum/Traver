using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SolverFoundation.Services;
using System.Diagnostics;
using Inv.BusinessEntities;
using Inv.BusinessLogic;


namespace Prod.UI.Win
{
    public partial class FrmOptimizacionUsoBloques : Form
    {
        public FrmOptimizacionUsoBloques()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            var clock = new Stopwatch();
            clock.Start();

            
            int Aremaxima;
            int margensuperior;
            int ProdAncho;
            int ProdLargo;
            int ProdEspesor;

            ProdAncho = int.Parse(txtprodancho.Text.ToString());
            ProdLargo = int.Parse(txtprodlargo.Text.ToString());
            ProdEspesor = int.Parse(txtprodespesor.Text.ToString());


            Aremaxima = int.Parse(txtareamaxima.Text.ToString());
            margensuperior = int.Parse(txtmargensuperior.Text.ToString());


            var bloques = OptimizacionBloqueLogic.Instance.FormaOptimaCortarBloqueTraer(Logueo.CodigoEmpresa, ProdAncho, ProdLargo, ProdEspesor);

            var solution = Profit.MinimizarMerma(bloques, Aremaxima,margensuperior);

            clock.Stop();

            // Limpiar Grilla
            dgvoptimizacion.Rows.Clear();
            foreach (var bloque in solution)
            {
                if (bloque.Value > 0)
                {
                    //Console.WriteLine(product.Key.Name + ": " + product.Value);
                    DataGridViewRow row = (DataGridViewRow)dgvoptimizacion.Rows[0].Clone();
                    row.Cells[0].Value = bloque.Value;
                    row.Cells[1].Value = bloque.Key.BloqueNro;
                    row.Cells[2].Value = bloque.Key.BloqueAncho;
                    row.Cells[3].Value = bloque.Key.BloqueLargo;
                    row.Cells[4].Value = bloque.Key.BloqueEspesor;
                    row.Cells[5].Value = bloque.Key.BloqueVolumen;
                    row.Cells[6].Value = bloque.Key.BloqueAreaTotal;

                    row.Cells[7].Value = bloque.Key.BaldosasAreaMaximaForma;
                    row.Cells[8].Value = bloque.Key.BaldosasAreaMaxima;
                    row.Cells[9].Value = bloque.Key.BaldosasAreaMaximaMerma;

                    row.Cells[10].Value = bloque.Key.BaldosaMermaRatio;
                    
                    //row.Cells
                    //agregas todos los campos
                    dgvoptimizacion.Rows.Add(row);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
               var random = new Random();
               var products = new List<Product>();
               for (var i = 0; i < 100; i++)
               {
                  var product = new Product(
                     "Name" + i.ToString(),
                     10d*random.NextDouble(),
                     20d*random.NextDouble(),
                     50d*random.NextDouble());
                  products.Add(product);
               }

               var clock = new Stopwatch();
               clock.Start();
               var solution = Profit.Maximize(products, 500d, 1000d);
               clock.Stop();
               Console.WriteLine("Time (ms): " + clock.ElapsedMilliseconds);

               // Limpiar Grilla
                dgvoptimizacion.Rows.Clear();

               foreach (var product in solution)
               {
                  if (product.Value > 0)
                  {
                     //Console.WriteLine(product.Key.Name + ": " + product.Value);
                      DataGridViewRow row = (DataGridViewRow)dgvoptimizacion.Rows[0].Clone();
                      row.Cells[0].Value = product.Key.Name;
                      row.Cells[1].Value = product.Value;
                      

                      //row.Cells
                      //agregas todos los campos
                      dgvoptimizacion.Rows.Add(row);

                  }
               }

               Console.ReadLine();
        }
    }
}