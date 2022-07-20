using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapasity) : base(fuelQuantity, fuelConsumption, tankCapasity)
        {

        }

        private const double RefuelCoeffiecient = 0.95;
        private const double TruckConsumtion = 1.6;

        public override double FuelIncreasement => TruckConsumtion;

        public override void Refuel(double liters,double officialLiters)
        {
            base.Refuel(liters*RefuelCoeffiecient, liters);
        }
    }
}
