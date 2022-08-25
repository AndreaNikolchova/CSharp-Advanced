
namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Repositories;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using Utilities.Messages;
    public class Controller : IController
    {
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        public string AddAstronaut(string type, string astronautName)
        {
            if(type == "Biologist" )
            {
                IAstronaut astronaut = new Biologist(astronautName);
                this.astronauts.Add(astronaut);
                return String.Format(OutputMessages.AstronautAdded,type,astronautName);
            }
            else if(type== "Geodesist")
            {
                IAstronaut astronaut = new Geodesist(astronautName);
                this.astronauts.Add(astronaut);
                return String.Format(OutputMessages.AstronautAdded, type, astronautName);
            }
            else if( type== "Meteorologist")
            {
                IAstronaut astronaut = new Meteorologist(astronautName);
                this.astronauts.Add(astronaut);
                return String.Format(OutputMessages.AstronautAdded, type, astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            this.planets.Add(planet);
            foreach(string item in items)
            {
                planet.Items.Add(item);
            }
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }
        private int countOfExploredPlanets = 0;
        public string ExplorePlanet(string planetName)
        {
            var astrounats = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            Mission mission = new Mission();
            if(astrounats.Count ==0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            else
            {
               mission.Explore(this.planets.FindByName(planetName), astrounats);
               var count = astrounats.Where(x => !x.CanBreath).Count();
               this.countOfExploredPlanets++;
               return String.Format(OutputMessages.PlanetExplored, planetName, count);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.countOfExploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach(var ast in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {ast.Name}");
                sb.AppendLine($"Oxygen: {ast.Oxygen}");
                if (ast.Bag.Items.Count == 0)
                    sb.AppendLine("Bag items: none");
                else
                    sb.AppendLine($"Bag items: {string.Join(", ", ast.Bag.Items)}");
            }
            return sb.ToString().TrimEnd();

        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaunt = this.astronauts.FindByName(astronautName);
            if( astronaunt == null )
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            else
            {
                this.astronauts.Remove(astronaunt);
                return String.Format(OutputMessages.AstronautRetired, astronautName);
            }

        }
    }
}
