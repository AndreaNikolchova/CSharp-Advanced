
namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class HappyBunny : Bunny
    {
        public HappyBunny(string name) : base(name, 100)
        {
        }

        public override void Work()
        {
            if (base.Energy - 10 < 0)
            {
                base.Energy = 0;
            }
            else
            {
                base.Energy -= 10;
            }
        }
    }
}
