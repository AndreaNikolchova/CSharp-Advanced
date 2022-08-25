
namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Biologist : Astronaut
    {
        public Biologist(string name) : base(name, 70)
        {

        }
        public override void Breath()
        {
           
            
            
                base.Oxygen -= 5;
            
        }
    }
}
