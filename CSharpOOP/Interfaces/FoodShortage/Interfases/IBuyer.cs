using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Interfases
{
    public interface IBuyer
    {
        int Food { get; }
        void BuyFood();
    }
}
