using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapasity) : base(fuelQuantity, fuelConsumption, tankCapasity)
        {

        }
        private const double BusIncreasment = 1.4;
        public override double FuelIncreasement => BusIncreasment;
        public override string DriveEmpty(double distance)
        {
            double neededFuel = distance * (this.FuelConsumption-BusIncreasment);
            if (this.FuelQuantity < neededFuel)
            {
                return $"Bus needs refueling";
            }
            this.FuelQuantity -= neededFuel;
            return $"Bus travelled {distance} km";
        }
    }
}
