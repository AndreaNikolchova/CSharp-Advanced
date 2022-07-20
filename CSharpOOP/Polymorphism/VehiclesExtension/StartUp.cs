namespace Vehicles
{
    using Models;
    using Core;
    using IO;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Read();
            IWriter writer = new Write();
            string[] carLine = reader.ReadLine().Split(' ',System.StringSplitOptions.RemoveEmptyEntries);
            string[] truckLine = reader.ReadLine().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string[] busLine = reader.ReadLine().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            Vehicle car  =  new Car(double.Parse(carLine[1]), double.Parse(carLine[2]),double.Parse(carLine[3]));
            Vehicle truck  =  new Truck(double.Parse(truckLine[1]), double.Parse(truckLine[2]), double.Parse(truckLine[3]));
            Vehicle bus  =  new Bus(double.Parse(busLine[1]), double.Parse(busLine[2]), double.Parse(busLine[3]));

            Engine engine = new Engine(car,truck,bus,reader,writer);

            engine.Start();
        }
    }
}
