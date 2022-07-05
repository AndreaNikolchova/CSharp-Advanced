using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public const double DefaultFuelConsumptionSportCar = 10;
        public override void Drive(double kilometers)
        {
            double fuel = this.Fuel - DefaultFuelConsumptionSportCar * kilometers;
            this.Fuel = fuel;
        }
    }
}
