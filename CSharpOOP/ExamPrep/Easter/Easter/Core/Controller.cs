
namespace Easter.Core
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Eggs;
    using Easter.Repositories;
    using Utilities.Messages;
    using Models.Workshops;

    public class Controller : IController
    {
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }
        private BunnyRepository bunnies;
        private EggRepository eggs;
        public string AddBunny(string bunnyType, string bunnyName)
        {
           if(bunnyType =="HappyBunny")
            {
                IBunny bunny = new HappyBunny(bunnyName);
                this.bunnies.Add(bunny); 
                return String.Format(OutputMessages.BunnyAdded,bunnyType, bunnyName);
            }
           else if(bunnyType == "SleepyBunny")
            {
                IBunny bunny = new SleepyBunny(bunnyName);
                this.bunnies.Add(bunny);
                return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = this.bunnies.FindByName(bunnyName);
            if(bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            else
            {
                bunny.AddDye(new Dye(power));
                return string.Format(OutputMessages.DyeAdded, power, bunnyName);
            }
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            this.eggs.Add(new Egg(eggName,energyRequired));
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var egg =  this.eggs.FindByName(eggName);
            List<IBunny> bunniesReady = this.bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x=>x.Energy).ToList();
            Workshop workshop = new Workshop();
            if(bunniesReady.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            foreach (var bunny in bunniesReady)
            {
                workshop.Color(egg, bunny);
                if(bunny.Energy==0)
                {
                    this.bunnies.Remove(bunny);
                }
            }
            if(egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone,eggName);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone,eggName);

            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var coloredEggs = this.eggs.Models.Where(x=>x.IsDone()==true).ToList();
            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunnys in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunnys.Name}");
                sb.AppendLine($"Energy: {bunnys.Energy}");
                var notFinishedDyes = bunnys.Dyes.Where(x=>x.IsFinished()==false).ToList();
                sb.AppendLine($"Dyes: {notFinishedDyes.Count} not finished");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
