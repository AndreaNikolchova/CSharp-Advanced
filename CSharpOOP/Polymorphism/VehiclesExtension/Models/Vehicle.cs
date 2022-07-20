namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using IO;
    public abstract class Vehicle
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private Vehicle()
        {
            this.FuelIncreasement = 0;
            this.reader = new Read();
            this.writer = new Write();
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapasity)
            : this()
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapasity;

        }
        private double tankCapasity;
        public double TankCapacity
        {
            get
            {
                return this.tankCapasity;
            }
            protected set
            {
                this.tankCapasity = value;
                if (this.tankCapasity < this.FuelQuantity)
                    this.FuelQuantity = 0;
            }
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
        public virtual string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (this.FuelQuantity < neededFuel)
            {
                return $"{GetType().Name} needs refueling";
            }
            this.FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters,double officialLitters)
        {
            if (liters <= 0)
                writer.WriteLine("Fuel must be a positive number");
            else
            {
                if (this.FuelQuantity + liters > this.TankCapacity)
                    writer.WriteLine($"Cannot fit {officialLitters} fuel in the tank");
                else
                    this.FuelQuantity += liters;
            }
        }
        public virtual string DriveEmpty(double distance)
        {
            return " ";
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
