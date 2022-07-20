using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                this.name = value;
            }
        }
        private int money;

        public int Money
        {
            get 
            { 
                return this.money;
            }
            private set 
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                this.money = value; 
            }
        }
        private List<Product> bagOfProducts;

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get { return bagOfProducts.AsReadOnly(); }
        }
        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }
        public void Check(Person person, Product product)
        {
            if (person.Money>=product.Cost)
            {
                person.Money -= product.Cost;
                Console.WriteLine($"{person.Name} bought {product.Name}");
                bagOfProducts.Add(product);
            }
            else
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
        }
        public override string ToString()
        {
            return $"{this.Name} - {string.Join(", ", bagOfProducts)}";
        }
    }
}
