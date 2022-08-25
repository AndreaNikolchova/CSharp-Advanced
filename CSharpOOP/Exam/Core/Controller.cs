
namespace PlanetWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Repositories;
    using Utilities.Messages;
    using Models.MilitaryUnits;
    using System.Linq;
    using Models.Weapons;

    public class Controller : IController
    {
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        private PlanetRepository planets;
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                
                if(unitTypeName == "AnonymousImpactUnit")
                {
                    if(planet.Army.FirstOrDefault(x=>x.GetType().Name == "AnonymousImpactUnit") == null)
                    {
                        planet.Spend(30);
                        planet.AddUnit(new AnonymousImpactUnit());
                        return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
                    }
                    else
                    {
                        throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                    }

                }
                else if(unitTypeName == "SpaceForces")
                {
                    if (planet.Army.FirstOrDefault(x => x.GetType().Name == "SpaceForces") == null)
                    {
                        planet.Spend(11);
                        planet.AddUnit(new SpaceForces());
                        return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
                    }
                    else
                    {
                        throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,planetName));
                    }

                }
                else if(unitTypeName == "StormTroopers")
                {
                    if (planet.Army.FirstOrDefault(x => x.GetType().Name == "StormTroopers") == null)
                    {
                        planet.Spend(2.5);
                        planet.AddUnit(new StormTroopers());
                        return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
                    }
                    else
                    {
                        throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                    }
                }
                else
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
                }
            }

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                var weapon = planet.Weapons.FirstOrDefault(x=>x.GetType().Name == weaponTypeName);
                if(weapon == null)
                {
                    if(weaponTypeName == "BioChemicalWeapon")
                    {
                        planet.Spend(3.2);
                        try
                        {
                             planet.AddWeapon(new BioChemicalWeapon(destructionLevel));

                        }
                        catch (Exception e)
                        {
                            planet.Profit(3.2);
                            throw e;
                        }
                        return String.Format(OutputMessages.WeaponAdded, planet.Name, weaponTypeName);
                    }
                    else if( weaponTypeName == "NuclearWeapon")
                    {
                        planet.Spend(15);
                        try
                        {
                            planet.AddWeapon(new NuclearWeapon(destructionLevel));

                        }
                        catch (Exception e)
                        {
                            planet.Profit(15);
                            throw e;
                        }
                        return String.Format(OutputMessages.WeaponAdded, planet.Name, weaponTypeName);
                    }
                    else 
                    {
                        planet.Spend(8.75);
                        try
                        {
                            planet.AddWeapon(new SpaceMissiles(destructionLevel));

                        }
                        catch (Exception e)
                        {
                            planet.Profit(8.75);
                            throw e;
                        }
                        return String.Format(OutputMessages.WeaponAdded, planet.Name, weaponTypeName);
                    }
                }
                else
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }


            }

        }

        public string CreatePlanet(string name, double budget)
        {
            var planet = this.planets.FindByName(name);
            if (planet == null)
            {
                this.planets.AddItem(new Planet(name, budget));
                return string.Format(OutputMessages.NewPlanet, name);
            }
            else
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach(var planet in this.planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planetAttacker = this.planets.FindByName(planetOne);
            var planetDeffender = this.planets.FindByName(planetTwo);
            if (planetAttacker.MilitaryPower == planetDeffender.MilitaryPower)
            {
                var attackerNucliar = planetAttacker.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");
                var deffenderNucliar = planetDeffender.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");
                if(attackerNucliar != null && deffenderNucliar != null||attackerNucliar ==null && deffenderNucliar == null)
                {
                    planetAttacker.Spend(planetAttacker.Budget / 2);
                    planetDeffender.Spend(planetDeffender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
                else if(attackerNucliar!=null && deffenderNucliar == null)
                {
                    planetAttacker.Spend(planetAttacker.Budget / 2);
                    planetAttacker.Profit(planetDeffender.Budget / 2);
                    foreach (var unit in planetDeffender.Army)
                    {
                        if (unit.GetType().Name == "AnonymousImpactUnit")
                        {

                            planetAttacker.Profit(30);
                        }
                        else if (unit.GetType().Name == "SpaceForces")
                        {
                            planetAttacker.Profit(11);
                        }
                        else
                        {
                            planetAttacker.Profit(2.5);
                        }
                    }
                    foreach (var weapons in planetDeffender.Weapons)
                    {
                        if (weapons.GetType().Name == "BioChemicalWeapon")
                        {

                            planetAttacker.Profit(3.2);
                        }
                        else if (weapons.GetType().Name == "NuclearWeapon")
                        {
                            planetAttacker.Profit(15);
                        }
                        else
                        {
                            planetAttacker.Profit(8.75);
                        }
                    }
                    planetDeffender.Spend(planetDeffender.Budget / 2);
                    this.planets.RemoveItem(planetTwo);
                    return String.Format(OutputMessages.WinnigTheWar,planetOne,planetTwo);
                }
                else
                {
                    planetDeffender.Spend(planetDeffender.Budget / 2);
                    planetDeffender.Profit(planetAttacker.Budget / 2);
                    foreach (var unit in planetAttacker.Army)
                    {
                        if (unit.GetType().Name == "AnonymousImpactUnit")
                        {

                            planetDeffender.Profit(30);
                        }
                        else if (unit.GetType().Name == "SpaceForces")
                        {
                            planetDeffender.Profit(11);
                        }
                        else
                        {
                            planetDeffender.Profit(2.5);
                        }
                    }
                    foreach (var weapons in planetAttacker.Weapons)
                    {
                        if (weapons.GetType().Name == "BioChemicalWeapon")
                        {

                            planetDeffender.Profit(3.2);
                        }
                        else if (weapons.GetType().Name == "NuclearWeapon")
                        {
                            planetDeffender.Profit(15);
                        }
                        else
                        {
                            planetDeffender.Profit(8.75);
                        }
                    }
                    planetAttacker.Spend(planetAttacker.Budget / 2);
                    this.planets.RemoveItem(planetOne);
                    return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                
            }
            else
            {
                if (planetAttacker.MilitaryPower > planetDeffender.MilitaryPower)
                {
                    planetAttacker.Spend(planetAttacker.Budget / 2);
                    planetAttacker.Profit(planetDeffender.Budget / 2);
                    foreach (var unit in planetDeffender.Army)
                    {
                        if (unit.GetType().Name == "AnonymousImpactUnit")
                        {

                            planetAttacker.Profit(30);
                        }
                        else if (unit.GetType().Name == "SpaceForces")
                        {
                            planetAttacker.Profit(11);
                        }
                        else
                        {
                            planetAttacker.Profit(2.5);
                        }
                    }
                    foreach (var weapons in planetDeffender.Weapons)
                    {
                        if (weapons.GetType().Name == "BioChemicalWeapon")
                        {

                            planetAttacker.Profit(3.2);
                        }
                        else if (weapons.GetType().Name == "NuclearWeapon")
                        {
                            planetAttacker.Profit(15);
                        }
                        else
                        {
                            planetAttacker.Profit(8.75);
                        }
                    }
                    planetDeffender.Spend(planetDeffender.Budget / 2);
                    this.planets.RemoveItem(planetTwo);
                    return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    planetDeffender.Spend(planetDeffender.Budget / 2);
                    planetDeffender.Profit(planetAttacker.Budget / 2);
                    foreach (var unit in planetAttacker.Army)
                    {
                        if (unit.GetType().Name == "AnonymousImpactUnit")
                        {

                            planetDeffender.Profit(30);
                        }
                        else if (unit.GetType().Name == "SpaceForces")
                        {
                            planetDeffender.Profit(11);
                        }
                        else
                        {
                            planetDeffender.Profit(2.5);
                        }
                    }
                    foreach (var weapons in planetAttacker.Weapons)
                    {
                        if (weapons.GetType().Name == "BioChemicalWeapon")
                        {

                            planetDeffender.Profit(3.2);
                        }
                        else if (weapons.GetType().Name == "NuclearWeapon")
                        {
                            planetDeffender.Profit(15);
                        }
                        else
                        {
                            planetDeffender.Profit(8.75);
                        }
                    }
                    planetAttacker.Spend(planetAttacker.Budget / 2);
                    this.planets.RemoveItem(planetOne);
                    return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
            
            }
        }

        public string SpecializeForces(string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                if (planet.Army.Count == 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
                }
                else
                {
                    planet.Spend(1.25);
                    planet.TrainArmy();
                    return String.Format(OutputMessages.ForcesUpgraded, planetName);
                }
            }
        }
    }
}
