﻿
namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SaltwaterFish : Fish
    {
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            base.Size = 5;
        }

        public override void Eat()
        {
            base.Size += 2;
        }
    }
}
