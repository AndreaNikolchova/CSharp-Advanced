
namespace Easter.Models.Eggs
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public class Egg : IEgg
    {
        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        private string name;
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                else
                    this.name = value;
            }
        }
        private int energyRequired;
        public int EnergyRequired
        {
            get { return this.energyRequired; }
            private set
            {
                if(value < 0)
                {
                    this.energyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }
            }
        }

        public void GetColored()
        {
            if(this.EnergyRequired-10<0)
            {
                this.EnergyRequired = 0;
            }
            else
            {
                this.EnergyRequired -= 10;
            }
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
            {
                return true;
            }
            return false;
        }
    }
}
