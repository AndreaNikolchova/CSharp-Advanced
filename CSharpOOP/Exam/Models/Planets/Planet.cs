
namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using Utilities.Messages;
    using Repositories;
    using System.Linq;

    public class Planet : IPlanet
    {
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        public string Name
        {
            get { return this.name; }
            private set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                this.name = value; 
            }

        }
        private double budget;

        public double Budget
        {
            get { return this.budget; }
            private set 
            {
                if(value<0)
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);

                this.budget = value; 
            }
        }
        public double MilitaryPower
        {
            get
            {
                return CalculateMilitary();
            }
           
        }
        private double CalculateMilitary()
        {
            double totalAmount =
                  this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.units.Models.Any(x => x.GetType().Name.Contains("AnonymousImpactUnit")))
            {
                totalAmount *= 1.30;
            }
            else if (this.weapons.Models.Any(x => x.GetType().Name.Contains("NuclearWeapon")))
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get { return this.units.Models; }
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get { return this.weapons.Models; }
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            if(this.units.Models.Count == 0)
            {
                sb.AppendLine("--Forces: No units");
            }
            else
            {
                sb.AppendLine($"--Forces: {String.Join(" ,",this.units.Models.Select(x=>x.GetType().Name))}");
            }
            if(this.weapons.Models.Count == 0)
            {
                sb.AppendLine("--Combat equipment: No weapons");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: {String.Join(" ,", this.units.Models.Select(x => x.GetType().Name))}");
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
           this.Budget+=amount;
        }

        public void Spend(double amount)
        {
            if(this.Budget - amount<0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            else
            {
                this.Budget -= amount;
            }
        }   

        public void TrainArmy()
        {
           foreach(var unit in this.units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
