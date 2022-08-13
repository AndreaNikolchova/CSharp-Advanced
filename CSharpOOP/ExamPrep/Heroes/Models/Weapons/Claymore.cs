using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public const int claymoreDamage = 20;
        public Claymore(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (base.Durability - 1 < 0)
                return 0;
            else
            {
                base.Durability -= 1;
                return claymoreDamage;

            }
        }
        
    }
}
