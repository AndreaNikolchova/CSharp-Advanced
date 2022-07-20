using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    using Interfases;
    public class Citizen : IBuyer
    {
        public int Food { get;  private set; }

        public void BuyFood() => Food += 10;
    }
}
