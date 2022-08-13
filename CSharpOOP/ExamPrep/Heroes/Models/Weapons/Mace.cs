
namespace Heroes.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Mace : Weapon
    {
        private const int damageMace = 25;
        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (base.Durability - 1 < 0)
                return 0;
            else
            {
                base.Durability -= 1;
                return damageMace;

            }

        }
    }
}
