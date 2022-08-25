namespace CarRacing.Models.Racers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CarRacing.Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;
    public abstract class Racer : IRacer
    {
        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }
        private string username;
        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                this.username = value;
            }
        }
        private string racingBehavior;
        public string RacingBehavior
        {
            get { return this.racingBehavior; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                this.racingBehavior = value;
            }
        }
        private int drivingExperience;
        public int DrivingExperience
        {
            get { return this.drivingExperience; }
            protected set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                this.drivingExperience = value;
            }
        }
        private ICar car;
        public ICar Car
        {
            get { return this.car; }
            private set 
            {
                if(value == null)
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace)
            {
                return true;
            }
            return false;
        }

        public virtual void Race()
        {
             this.Car.Drive();
           
        }
    }
}
