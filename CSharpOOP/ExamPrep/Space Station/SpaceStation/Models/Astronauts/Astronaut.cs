
namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Bags.Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;

            this.bag = new Backpack();
        }
        private string name;
        public string Name 
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                this.name = value;
            }
        }
        private double oxygen; 
        public double Oxygen
        {
            get { return this.oxygen; }
            protected set 
            {
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath
        {
            get 
            { return this.Oxygen > 0; }
            
        }
        private IBag bag;
        public IBag Bag
        {
            get { return this.bag; }
            private set { this.bag = value;}
        }

        public virtual void Breath()
        {
         
                this.Oxygen -= 10;
           
        }
    }
}
