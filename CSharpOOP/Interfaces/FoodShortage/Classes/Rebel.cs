using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    using Interfases;
    public class Rebel : IBuyer
    {
        public int Food { get; private set; }

        public void BuyFood() => Food += 5;
    }
}
