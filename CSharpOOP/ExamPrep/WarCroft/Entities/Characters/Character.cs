
namespace WarCroft.Entities.Characters.Contracts
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;

    public abstract class Character  
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }
        public double BaseHealth;
        private double health;
        public double Health
        {
            get { return this.health; }
            private set
            {
                if (value > this.BaseHealth)
                    this.health = this.BaseHealth;

                else if (value < 0)
                    this.health = 0;

                this.health = value;
            }
        }
        public double BaseArmor;
        private double armor;
        public double Armor
        {
            get { return this.armor; }
            private set
            {
                if (value > this.BaseArmor)
                    this.armor = this.BaseArmor;

                else if (value < 0)
                    this.armor = 0;

                this.armor = value;

            }
        }
        public double AbilityPoints { get; private set; }

        public bool IsAlive { get; set; } = true;

        private IBag bag;
        public IBag Bag
        {
            get { return this.bag; }
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            if(!this.IsAlive)
            {
                if(this.Armor - hitPoints>0)
                {
                    this.Armor-=hitPoints;
                }
                else
                {
                    double points = hitPoints - this.Armor;
                    this.Armor -=hitPoints;
                    this.Health -=points;
                    if(this.Health == 0)
                    {
                        this.IsAlive = false;
                    }
                }
            }
        }


    }
}