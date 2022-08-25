
namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Easter.Models.Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }
        private string name;
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                else
                {
                    this.name = value;
                }
            }
        }
        private int energy;
        public int Energy
        {
            get { return this.energy; }
            protected set
            {
                if(value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }
        private List<IDye> dyes;
        public ICollection<IDye> Dyes { get { return this.dyes.AsReadOnly(); } }

        public void AddDye(IDye dye)
        {
          this.dyes.Add(dye);
        }

        public abstract void Work();
        
    }
}
