
namespace SpaceStation.Models.Mission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        { 
            foreach(var astronaut in astronauts)
            {
                if(astronaut.CanBreath)
                {
                    while(true)
                    {
                        if (planet.Items.Count == 0 || !astronaut.CanBreath)
                            break;
                        else
                        {
                             var currentItem = planet.Items.First();
                             astronaut.Bag.Items.Add(currentItem);
                             astronaut.Breath();
                             planet.Items.Remove(currentItem);
                        }
                    }
                }
            }
        }
    }
}
