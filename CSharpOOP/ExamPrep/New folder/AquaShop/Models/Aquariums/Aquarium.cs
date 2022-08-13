
namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using Contracts;
    public abstract class Aquarium : IAquarium
    {
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        private string name;
        public string Name
        {

            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);

                this.name = value;
            }


        }
        private int capacity;
        public int Capacity { get { return this.capacity; } private set { this.capacity = value; } }

        public int Comfort
        {
            get
            {
                int comfort = 0;
                foreach (var comf in this.decorations)
                {
                    comfort += comf.Comfort;
                }
                return comfort;
            }
        }
                

        private readonly List<IDecoration> decorations;
        public ICollection<IDecoration> Decorations 
        {
            get { return this.decorations.AsReadOnly(); } 
        }
        private readonly List<IFish> fish;
        public ICollection<IFish> Fish
        {
            get { return this.fish.AsReadOnly(); }
        }
        public void AddDecoration(IDecoration decoration)
        {
           this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
           if(this.fish.Count == this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
           else
                this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach(var f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
        {
            if (this.fish.Count == 0)
            {
                return $"{this.Name} ({this.GetType().Name}):{Environment.NewLine}Fish: none{Environment.NewLine}Decorations:{this.Decorations.Count}{Environment.NewLine}Comfort: {this.Comfort}{Environment.NewLine}";

            }
            else
                return $"{this.Name} ({this.GetType().Name}):{Environment.NewLine}Fish: {string.Join(", ",this.fish.Select(x=>x.Name))}{Environment.NewLine}Decorations:{this.Decorations.Count}{Environment.NewLine}Comfort: {this.Comfort}{Environment.NewLine}";
        }

        public bool RemoveFish(IFish fish)
        {
           return this.fish.Remove(fish);
        }
    }
}
