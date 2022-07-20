using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
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
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                else 
                    this.name = value;
            } 
        }
        public Dough Dough { get;  set; }
        private List<Topping> toppings;
        public int Count { get { return toppings.Count; } }
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public double TotalCalories { get; private set; }
        public void AddTopings(Topping topping)
        {
            toppings.Add(topping);
        }
        private double Calories()
        {
            double sumOfToppings = 0;
            foreach (Topping topping in toppings)
                sumOfToppings += topping.GramsTopping();
            this.TotalCalories = sumOfToppings + this.Dough.Grams();
            return this.TotalCalories;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories():f2} Calories.";
        }
    }
}
