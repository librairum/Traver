using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SolverFoundation.Services;
using Inv.BusinessEntities;

namespace Prod.UI.Win
{
    public class Profit
    {
        public static IDictionary<Product, int> Maximize(IEnumerable<Product> products,double budget,double capacity)
        {
            // do stuff here
            //
            var solver = SolverContext.GetContext();
            solver.ClearModel();
            var model = solver.CreateModel();

            // Agregar Varible de decision
            var decisions = products.Select(it => new Decision(Domain.IntegerNonnegative, it.Name));
            model.AddDecisions(decisions.ToArray());

            //Agregar Objetivo
            var objective = new SumTermBuilder(decisions.Count());

            foreach (var product in products)
            {
                var productDecision = model.Decisions.First(
                   it => it.Name == product.Name);
                objective.Add(productDecision * product.Margin);
            }
            model.AddGoal("Profit", GoalKind.Maximize, objective.ToTerm());

            //Agrgar Restriccion
            var budgetComponents = new SumTermBuilder(decisions.Count());
            foreach (var product in products)
            {
                var productDecision = model.Decisions.First(
                   it => it.Name == product.Name);
                budgetComponents.Add(productDecision * product.Cost);
            }

            var budgetConstraint = budgetComponents.ToTerm() <= budget;
            model.AddConstraint("Budget", budgetConstraint);

            //
            var weightComponents = new SumTermBuilder(decisions.Count());
            foreach (var product in products)
            {
                var productDecision = model.Decisions.First(
                   it => it.Name == product.Name);
                weightComponents.Add(productDecision * product.Weight);
            }

            var weightConstraint = weightComponents.ToTerm() <= capacity;
            model.AddConstraint("Weight", weightConstraint);

            //
            var solution = solver.Solve();

            var orders = new Dictionary<Product, int>();
            if (solution.Quality == SolverQuality.Optimal)
            {
                foreach (var product in products)
                {
                    var productDecision = model.Decisions.First(it => it.Name == product.Name);
                    orders.Add(product, (int)productDecision.ToDouble());
                }
            }

            return orders;

        }

        public static IDictionary<Spu_Pro_Trae_FormaOptimaCortarBloque, int> MinimizarMerma(IEnumerable<Spu_Pro_Trae_FormaOptimaCortarBloque> Bloques, double AreaSolicitada,double margensuperior)
        {
            // Do stuff here
            var solver = SolverContext.GetContext();
            solver.ClearModel();
            var model = solver.CreateModel();

            var decisions = Bloques.Select(it => new Decision(Domain.IntegerNonnegative, it.BloqueNro));
            model.AddDecisions(decisions.ToArray());

            // Obetivo es minimizar la merma
            var objective = new SumTermBuilder(decisions.Count());
            foreach (var bloque in Bloques)
            {
                var productDecision = model.Decisions.First(it => it.Name == bloque.BloqueNro);
                objective.Add(productDecision * bloque.BaldosasAreaMaximaMerma);
             }

            model.AddGoal("Profit", GoalKind.Minimize, objective.ToTerm());



            // Restriccion exacta
            var budgetComponents = new SumTermBuilder(decisions.Count());
            foreach (var bloque in Bloques)
            {
                var productDecision = model.Decisions.First(it => it.Name == bloque.BloqueNro);
                budgetComponents.Add(productDecision * bloque.BaldosasAreaMaxima);
            }

            var budgetConstraint = budgetComponents.ToTerm() >= AreaSolicitada;
            model.AddConstraint("Budget", budgetConstraint);


            // Restriccion con holgura o margen 
            var AreaMinima = new SumTermBuilder(decisions.Count());
            foreach (var bloque in Bloques)
            {
                var productDecision = model.Decisions.First(it => it.Name == bloque.BloqueNro);
                AreaMinima.Add(productDecision * bloque.BaldosasAreaMaxima);
            }

            var AreaMinimaConstraint = AreaMinima.ToTerm() <= AreaSolicitada + margensuperior;
            model.AddConstraint("margensuperior", AreaMinimaConstraint);

           //constraint 2: min and max weight
            foreach (var bloque in Bloques)
            {
                var productDecision = model.Decisions.First(it => it.Name == bloque.BloqueNro);
                //var wtDecision = model.Decisions.First(it => it.Name == "wt" + sID.ToString());
                model.AddConstraint("bound" + bloque.BloqueNro, productDecision <= 1);
            }

           
            //
            var solution = solver.Solve();
            var orders = new Dictionary<Spu_Pro_Trae_FormaOptimaCortarBloque, int>();

            if (solution.Quality == SolverQuality.Optimal)
            {
                foreach (var bloque in Bloques)
                {
                    var productDecision = model.Decisions.First(it => it.Name == bloque.BloqueNro);
                    orders.Add(bloque, (int)productDecision.ToDouble());
                }
            }
            return orders;
        }
        
    }
}
