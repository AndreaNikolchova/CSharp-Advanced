
namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public abstract class Fish : IFish
    {
        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }
        private string name;
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);

               this.name = value; 
            }
        }
        private string species;
        public string Species
        {
            get { return species; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);

                this.species = value;
            }
        }
        private int size;
        public  int Size { get { return this.size; } protected set { this.size = value; } }

        private decimal price;
        public decimal Price
        {

            get { return price; }
            private set
            {
                if (value<=0)
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);

                this.price = value;
            }
        }

        public abstract void Eat(); 
      
    }
}
