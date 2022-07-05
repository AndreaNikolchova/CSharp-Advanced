using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get; set; } 
        public virtual void Drive(double kilometers)
        {
            double fuel = this.Fuel - DefaultFuelConsumption * kilometers;
            this.Fuel = fuel;
        }
    }
}
