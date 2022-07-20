using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                this.name = value;
            }
        }
        private int cost;

        public int Cost
        {
            get 
            {
                return this.cost;
            }
            set 
            {
                if (value<0)
                    throw new ArgumentException("Money cannot be negative");
                this.cost = value; 
            }
        }
        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
