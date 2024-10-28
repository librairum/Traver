using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prod.UI.Win
{
    public class Product
    {
        public Product(string name, double cost, double price, double weight)
        {
            this.Name = name;
            this.Cost = cost;
            this.Price = price;
            this.Weight = weight;
        }

        public string Name { get; private set; }
        public double Cost { get; private set; }
        public double Price { get; private set; }
        public double Weight { get; private set; }
        public double Margin
        {
            get { return this.Price - this.Cost; }
        }
    }
}
