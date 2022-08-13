
namespace Formula1.Models.FormulaOneCars
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }
        private string model;
        public string Model
        {
            get { return this.model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel,value));

                this.model = value;
            }
        }
        private int hoursepower;
        public int Horsepower
        {
            get { return this.hoursepower; }
            private set
            {
                if(value<900||value>1050)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));

                this.hoursepower = value;
            }
        }
        private double engineDisplacement;
        public double EngineDisplacement
        {
            get
            {
                return this.engineDisplacement;
            }
            private set
            {
                if (value<1.6||value>2.00)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));

                this.engineDisplacement = value;
            }
        }

        public virtual double RaceScoreCalculator(int laps)
        {
            return this.EngineDisplacement / this.Horsepower * laps;
        }
    }
}
