
namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using Contracts;
    public class Controller : IController
    {
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
                return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else if (aquariumType == "SaltwaterAquarium")
            { 
                aquarium = new SaltwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
                return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
                this.decorations.Add(decoration);
                return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else if (decorationType == "Plant")
            {

                decoration = new Plant();
                this.decorations.Add(decoration);
                return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish= null;
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                if(aquarium.GetType().Name != "FreshwaterAquarium")
                    return OutputMessages.UnsuitableWater;

                fish = new FreshwaterFish(fishName,fishSpecies,price);
                aquarium.AddFish(fish);
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType().Name != "SaltwaterAquarium")
                    return OutputMessages.UnsuitableWater;

                fish = new SaltwaterFish(fishName, fishSpecies, price); ;
                aquarium.AddFish(fish);
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType,aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);
            decimal sum = 0;
            foreach(var fish in aquarium.Fish)
            {
                sum +=fish.Price;
            } 
            foreach(var decoration in aquarium.Decorations)
            {
                sum += decoration.Price;
            }

            return String.Format(OutputMessages.AquariumValue, aquariumName, sum);
          
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.First(x => x.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }
            else
            {
                var aquarium = this.aquariums.First(x => x.Name == aquariumName);
                aquarium.AddDecoration(decoration);
                this.decorations.Remove(decoration);
                return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var aquarium in this.aquariums)
            {
                sb.Append(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
