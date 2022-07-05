using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliters)
        {
           this.Caffeine = caffeine;
        }
        public const double CoffeeMilliters = 50;
        public const decimal CoffeePrice = 3.50m;
        public double Caffeine { get; set; }
    }
}
