
namespace Formula1.Models
{
    using Contracts;
    using Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Pilot : IPilot
    {
        public Pilot(string fullName)
        {
            this.FullName = fullName;  
            this.CanRace = false;
        }
        private string fullName;
        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));

                this.fullName = value; 
            }
        }
        private IFormulaOneCar car;
        public IFormulaOneCar Car
        {
            get { return this.car; }
            private set 
            {
                if (value == null)
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);

                this.car = value; 
            }
        }

        public int NumberOfWins { get; private set; }

        private bool canRace;
        public bool CanRace
        {
            get { return this.canRace; }
            set { this.canRace = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }
        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
