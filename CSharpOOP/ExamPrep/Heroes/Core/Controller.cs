namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Repositories;
    using Models;
    using Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Weapons;
    using System.Linq;
    using Models.Map;

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (this.heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero { heroName  } does not exist.");
            }
            else
            {
                if (this.weapons.FindByName(weaponName) == null)
                {
                    throw new InvalidOperationException($"Weapon { weaponName} does not exist.");
                }
                else
                {
                    var hero = this.heroes.FindByName(heroName);
                    var weapon = this.weapons.FindByName(weaponName);
                    if (hero.Weapon!=null)
                    {
                        throw new InvalidOperationException($"Hero { heroName } is well-armed.");
                    }
                    else
                    {
                       hero.AddWeapon(weapon);
                       this.weapons.Remove(weapon);
                        return $"Hero {hero.Name} can participate in battle using a { weapon.GetType().Name.ToLower()}.";
                    }
                }
            }

        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if(this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }
            else if(type == "Barbarian" )
            {
                this.heroes.Add(new Barbarian(name, health, armour));
                return $"Successfully added Barbarian { name } to the collection.";
            }
            else if(type == "Knight")
            {
                this.heroes.Add(new Knight(name, health, armour));
                return $"Successfully added Sir { name } to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }
            else if (type == "Claymore")
            {
                this.weapons.Add(new Claymore(name,durability));
                return $"A { type.ToLower() } { name } is added to the collection.";
            }
            else if (type == "Mace")
            {
                this.weapons.Add(new Mace(name,durability));
                return $"A { type.ToLower() } { name } is added to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
        }

        public string HeroReport()
        {
            List<IHero> heroesReadyToPrint = this.heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(H => H.Health).ThenBy(n => n.Name).ToList();
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var hero in heroesReadyToPrint)
            {
                stringBuilder.AppendLine($"{ hero.GetType().Name }: { hero.Name }");
                stringBuilder.AppendLine($"--Health: { hero.Health}");
                stringBuilder.AppendLine($"--Armour: { hero.Armour}");
                if (hero.Weapon == null)
                    stringBuilder.AppendLine($"Unarmed");
                else
                    stringBuilder.AppendLine($"--Weapon: { hero.Weapon.Name}");

            }
            return stringBuilder.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
             return map.Fight(this.heroes.Models.Where(x => x.Weapon != null).Where(x => x.IsAlive == true).ToList());
        }
    }
}
