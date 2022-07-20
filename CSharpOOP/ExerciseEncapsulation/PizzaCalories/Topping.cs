using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        //•	Meat - 1.2;
        //•	Veggies - 0.8;
        //•	Cheese - 1.1;
        //•	Sauce - 0.9;
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;
        private double oneOfFourToppings;
        private string invalidArgument;
        public Topping(string topping, int grams)
        {
            invalidArgument = topping;
            switch (topping.ToLower())
            {
                case "meat":
                    this.OneOfFourToppings = meat;
                    break;
                case "veggies":
                    this.OneOfFourToppings = veggies;
                    break;
                case "cheese":
                    this.OneOfFourToppings = cheese;
                    break;
                case "sauce":
                    this.oneOfFourToppings = sauce;
                    break;
                default:
                    this.OneOfFourToppings = 0;
                    break;
            }
            this.Grams = grams;
        }
        public double OneOfFourToppings
        {
            get
            {
                return this.oneOfFourToppings;
            }
            private set
            {
                if (value == 0)
                    throw new Exception($"Cannot place {this.invalidArgument} on top of your pizza.");
                else
                    this.oneOfFourToppings = value;
            }
        }
        private int grams;

        public int Grams
        {
            get 
            { 
                return this.grams; 
            }
           private set 
            {
                if (value < 1 || value > 50)
                    throw new Exception($"{this.invalidArgument} weight should be in the range [1..50].");
                else
                    this.grams = value;
            }
        }
        public double GramsTopping()
        {
            return this.Grams * 2 * this.OneOfFourToppings;
        }

    }
}
