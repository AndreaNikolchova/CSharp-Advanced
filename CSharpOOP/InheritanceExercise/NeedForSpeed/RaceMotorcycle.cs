using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public double DefaultFuelConsumptionRace = 8;
        public override void Drive(double kilometers)
        {
            double fuel = this.Fuel - DefaultFuelConsumptionRace * kilometers;
            this.Fuel = fuel;
        }
    }
}
