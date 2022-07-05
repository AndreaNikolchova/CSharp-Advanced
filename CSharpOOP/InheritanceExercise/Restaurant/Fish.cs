using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        public Fish(string name, decimal price) : base(name, price, GramsFish)
        {
        }
        public const double GramsFish = 22;
    }
}
