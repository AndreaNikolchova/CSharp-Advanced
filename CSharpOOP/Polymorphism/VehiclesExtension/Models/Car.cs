using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption,double tankCapasity) : base(fuelQuantity, fuelConsumption,tankCapasity)
        {
        }

        private const double CarIncreasment = 0.9;

        public override double FuelIncreasement => CarIncreasment;
    }
}
