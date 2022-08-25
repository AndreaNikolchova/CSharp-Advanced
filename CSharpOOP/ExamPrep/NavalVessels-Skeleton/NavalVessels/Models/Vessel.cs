
namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public abstract class Vessel : IVessel
    {
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }
        private string name;
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                this.name = value;
            }
        }
        private ICaptain captain;
        public ICaptain Captain
        {
            get { return this.captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                this.captain = value;
            }
        }
        private double armorThickness;
        public double ArmorThickness
        {
            get
            {
                return this.armorThickness;
            }
            set
            {
                this.armorThickness = value;
            }
        }
        private double mainWeaponCaliber;
        public double MainWeaponCaliber
        {
            get
            {
                return this.mainWeaponCaliber;
            }
            protected set
            {
                this.mainWeaponCaliber = value;
            }
        }
        private double speed;
        public double Speed
        {
            get { return this.speed; }
            protected set
            {
                this.speed = value;
            }
        }
        private List<string> targets;
        public ICollection<string> Targets
        {
            get
            {
                return this.targets.AsReadOnly();
            }
        }

        public void Attack(IVessel target)
        {
            if(target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            if (target.ArmorThickness - this.MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0;

            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }
                this.targets.Add(target.Name);
        }

        public abstract void RepairVessel();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if(this.targets.Count ==0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ",this.targets)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
