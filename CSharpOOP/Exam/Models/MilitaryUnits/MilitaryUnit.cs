
namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }
        private double cost;
        public double Cost
        {
            get { return this.cost; }
            private set { this.cost = value; }
        }
        private int enduranceLevel;
        public int EnduranceLevel
        {
            get { return this.enduranceLevel;}
            private set { this.enduranceLevel = value; }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel += 1;
            if (this.EnduranceLevel ==21)
            {
                this.enduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);

            }
        }
    }
}
