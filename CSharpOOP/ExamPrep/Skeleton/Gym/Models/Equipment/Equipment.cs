namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    public abstract class Equipment : IEquipment
    {
        public double Weight { get; private set; }

        public decimal Price { get; private set; }

        protected Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }
    }
}
