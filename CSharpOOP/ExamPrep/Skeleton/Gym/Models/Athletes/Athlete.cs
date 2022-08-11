
namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public abstract class Athlete : IAthlete
    {
        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }
        private string fullName;
        public string FullName
        {
            get { return this.fullName; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                this.fullName = value; 
            }
        }
        private string motivation;
        public string Motivation
        {
            get { return this.motivation; }
            private set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                this.motivation = value;
            }
        }

        public int Stamina { get; protected set; }

        private int numberOFMedals;
        public int NumberOfMedals
        {
            get { return this.numberOFMedals; }
            private set
            {
                if(value<0)
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                this.numberOFMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
