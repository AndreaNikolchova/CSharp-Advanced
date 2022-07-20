
namespace Vehicles.Core
{
    using Models;
    using IO;
    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(Vehicle car,Vehicle truck, Vehicle bus, IReader reader, IWriter writer)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
            this.writer = writer;
            this.reader = reader;
        }
        public void Start()
        {
            int num = int.Parse(reader.ReadLine());
            for (int i = 0; i <num; i++)
            {
                string[] command = reader.ReadLine().Split(' ',System.StringSplitOptions.RemoveEmptyEntries);
                if (command[0]=="Drive")
                {
                    if (command[1]=="Car")
                    {
                        writer.WriteLine(this.car.Drive(double.Parse(command[2])));
                    }
                    else if (command[1]== "Truck")
                    {
                        writer.WriteLine(this.truck.Drive(double.Parse(command[2])));
                    }
                    else
                    {
                        writer.WriteLine(this.bus.Drive(double.Parse(command[2])));
                    }
                }
                else if(command[0]=="Refuel")
                {
                    if (command[1] == "Car")
                    {
                        this.car.Refuel(double.Parse(command[2]), double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        this.truck.Refuel(double.Parse(command[2]),double.Parse(command[2]));

                    }
                    else
                    {
                        this.bus.Refuel(double.Parse(command[2]), double.Parse(command[2]));
                    }
                }
                else
                {
                    writer.WriteLine(this.bus.DriveEmpty(double.Parse(command[2])));
                }
            }
            writer.WriteLine(this.car.ToString());
            writer.WriteLine(this.truck.ToString());
            writer.WriteLine(this.bus.ToString());

        }
    }
}
