namespace Vehicles
{
    using System;
    using Models;
    using Core;
    using IO;
    public class StartUp
    {
    
        static void Main(string[] args)
        {
            IReader reader = new Read();
            IWriter writer = new Write();
            string[] carLine = reader.ReadLine().Split();
            string[] truckLine = reader.ReadLine().Split();

            Vehicle car  =  new Car(double.Parse(carLine[1]), double.Parse(carLine[2]));
            Vehicle truck  =  new Truck(double.Parse(truckLine[1]), double.Parse(truckLine[2]));

            Engine engine = new Engine(car,truck,reader,writer);

            engine.Start();
        }
    }
}
