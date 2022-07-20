namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public abstract class Vehicle
    {
        private Vehicle() => this.FuelIncreasement = 0;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
            : this()
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        private double fuelConsumption;
        public double FuelConsumption 
        { 
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelIncreasement;
            } 
        }

        public virtual double FuelIncreasement { get; }
        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (this.FuelQuantity<neededFuel)
            {
                return $"{GetType().Name} needs refueling";
            }
            this.FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
