﻿namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public abstract class Car : ICar
    {
        protected Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.fuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        private string make;
        public string Make
        {
            get { return this.make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);

                this.make = value;
            }
        }
        private string model;
        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);

                this.model = value;
            }
        }
        private string vin;

        public string VIN
        {
            get { return this.vin; }
            private set
            {
                if (value.Length != 17)
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                this.vin = value;
            }
        }
        private int hoursePower;
        public int HorsePower
        {
            get { return this.hoursePower; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                this.hoursePower = value;
            }
        }
        private double fuelAvailable;
        public double FuelAvailable
        {
            get { return this.fuelAvailable; }
            private set
            {
                if (value < 0)
                    this.FuelAvailable = 0;

                this.fuelAvailable = value;
            }
        }
        private double fuelConsumprionPerRace;
        public double FuelConsumptionPerRace
        {
            get { return this.FuelConsumptionPerRace; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                this.FuelConsumptionPerRace = value;
            }
        }
        public void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
            if (this.GetType().Name == "TunedCar")
            {
                this.HorsePower = int.Parse(Math.Round(this.hoursePower * 0.97,MidpointRounding.AwayFromZero).ToString());
            }
        }
    }
}
