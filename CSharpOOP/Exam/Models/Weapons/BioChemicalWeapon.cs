﻿
namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class BioChemicalWeapon : Weapon
    {
        public BioChemicalWeapon(int destructionLevel) : base(destructionLevel, 3.2)
        {
        }
    }
}
