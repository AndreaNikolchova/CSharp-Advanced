
namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public abstract class Weapon : IWeapon
    {
        protected Weapon(int destructionLevel, double price)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }
        private double price;
        public double Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }
        private int destructionLevel;
        public int DestructionLevel
        {
            get { return this.destructionLevel;}
            protected set 
            {
                if (value < 1)
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                else if(value>10)
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);

                this.destructionLevel = value;
            }
        }
    }
}
