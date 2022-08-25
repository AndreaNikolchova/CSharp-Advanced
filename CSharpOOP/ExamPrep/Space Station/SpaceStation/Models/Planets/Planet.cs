
namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public class Planet : IPlanet
    {
        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }
        private List<string> items;
        public ICollection<string> Items
        {
            get { return this.items; }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                this.name = value;
            }
        }
    }
}
