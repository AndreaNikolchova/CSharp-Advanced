
namespace Heroes.Models.Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Contracts;
    public abstract class Hero : IHero
    {
        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }
        private string name;
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Hero name cannot be null or empty.");
                this.name = value; 
            }
        }
        private int health;
        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if(value< 0)
                    throw new ArgumentException("Hero health cannot be below 0.");
                this.health = value;
            }
        }
        private int armour;
        public int Armour
        {
            get 
            {
                return this.armour;
            }
            private set
            {
                if(value<0)
                    throw new ArgumentException("Hero armour cannot be below 0.");
                this.armour = value;
            }
        }
        private IWeapon weapon;

        public IWeapon Weapon
        {
            get
            {
                return this.weapon;
            }
            private set 
            {
                if (value == null)
                    throw new ArgumentException("Weapon cannot be null.");
                this.weapon = value; 
            }
        }

        public bool IsAlive
        {
            get 
            { 
                if (this.Health > 0)
                    return true; 
                else 
                    return false; 
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if(this.Armour>0 && this.Armour>points)
            {
                this.Armour -= points;
            }
            else if(this.Health>0)
            {
                points -= this.Armour;
                this.Armour = 0;
                if(this.Health-points<0)
                {
                    this.Health = 0;
                }
                else
                    this.Health -= points;
                
            }

        }
    }
}
