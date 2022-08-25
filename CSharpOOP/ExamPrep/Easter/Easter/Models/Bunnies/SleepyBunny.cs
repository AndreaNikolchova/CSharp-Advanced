
namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SleepyBunny : Bunny
    {
        public SleepyBunny(string name) : base(name, 50)
        {
        }

        public override void Work()
        {
            if (base.Energy - 15 < 0)
            {
                base.Energy = 0;
            }
            else
            {
                base.Energy -= 15;
            }
        }
    }
}
