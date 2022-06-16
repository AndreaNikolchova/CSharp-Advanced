using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //3
            //int number = int.Parse(Console.ReadLine());
            //Family member = new Family();
            //for(int i = 1; i <= number; i++)
            //{
            //    string[] line = Console.ReadLine().Split(' ');
            //    Person person = new Person();
            //    person.Name = line[0];
            //    person.Age = int.Parse(line[1]);
            //    member.AddMember(person);

            //}
            //Console.WriteLine(member.GetOldestMember().Name + " " + member.GetOldestMember().Age);
            //4
            //Person person = new Person();
            //int number = int.Parse(Console.ReadLine());
            //List<Person> list = new List<Person>();
            //for (int i = 1; i <= number; i++)
            //{
            //    string[] line = Console.ReadLine().Split(' ');
            //    person = new Person();
            //    person.Name = line[0];
            //    person.Age = int.Parse(line[1]);
            //    list.Add(person);
            //}
            //list= list.Where(x=>x.Age>0).OrderBy(x=> x.Name).ToList();
            //list.ForEach(x => Console.WriteLine(x.Name + " - " + x.Age));
            //5
            //int number = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();   
            //for (int i = 1; i <= number; i++)
            //{
            //    string[] line = Console.ReadLine().Split(' ');
            //    Car car = new Car(line[0], double.Parse(line[1]), double.Parse(line[2]));
            //    cars.Add(car);                
            //}
            //while (true)
            //{
            //    string[] command = Console.ReadLine().Split(' ');
            //    if (command[0] == "End")
            //        break;
            //    int index = cars.FindIndex(x => x.Model == command[1]);
            //    cars[index].CanItDrive(cars[index], double.Parse(command[2]));
            //}
            //cars.ForEach(x => Console.WriteLine($"{x.Model} {x.FuelAmount:f2} {x.TravelledDistance}"));
            //7
            //int number = int.Parse(Console.ReadLine());
            //List<Car> list = new List<Car>();
            //for (int i = 1; i <= number; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');
            //    Car car = new Car(input[0],
            //        int.Parse(input[1]),
            //        int.Parse(input[2]),
            //        int.Parse(input[3]),
            //        input[4],
            //        double.Parse(input[5]),
            //        int.Parse(input[6]),
            //        double.Parse(input[7]),
            //        int.Parse(input[8]),
            //        double.Parse(input[9]),
            //        int.Parse(input[10]),
            //        double.Parse(input[11]),
            //        int.Parse(input[12]));
            //    list.Add(car);
            //}
            //string command = Console.ReadLine();
            //if (command== "fragile")
            //{
            //    foreach(var car in list)
            //    {
            //        if (car.CargoList == "fragile" && car.Fragile())
            //        {
            //            Console.WriteLine(car.Model);
            //        }
            //    }
            //}
            //else if (command== "flammable")
            //{

            //    foreach (var car in list)
            //    {
            //        if (car.CargoList == "flammable" && car.enginePowerInt> 250)
            //        {
            //            Console.WriteLine(car.Model);
            //        }
            //    }
            //}
            //8
            //int engineNumber = int.Parse(Console.ReadLine());
            //List<Engine> engineList = new List<Engine>();
            //for (int i = 1; i <= engineNumber; i++)
            //{
            //    string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            //    switch (command.Length)
            //    {
            //        case 2:
            //            Engine engine = new Engine(command[0], int.Parse(command[1]), default, default);
            //            engineList.Add(engine);
            //            break;
            //        case 3:
            //            if (char.IsLetter(command[2][0]))
            //                engine = new Engine(command[0], int.Parse(command[1]), default, command[2]);
            //            else
            //                engine = new Engine(command[0], int.Parse(command[1]), int.Parse(command[2]), default);
            //            engineList.Add(engine);
            //            break;
            //        case 4:
            //            engine = new Engine(command[0], int.Parse(command[1]), int.Parse(command[2]), command[3]);
            //            engineList.Add(engine);
            //            break;
            //    }

            //}
            //int numberOfCars = int.Parse(Console.ReadLine());
            //List<Car> carList = new List<Car>();
            //for (int i = 1; i <= numberOfCars; i++)
            //{
            //    string[] command = Console.ReadLine().Split(' ');
            //    switch (command.Length)
            //    {
            //        case 2:
            //            Car car = new Car(command[0], engineList.Where(x => x.Model == command[1]).First(), default, default);
            //            carList.Add(car);
            //            break;
            //        case 3:
            //            if (char.IsLetter(command[2][0]))
            //                car = new Car(command[0], engineList.Where(x => x.Model == command[1]).First(), default, command[2]);
            //            else
            //                car = new Car(command[0], engineList.Where(x => x.Model == command[1]).First(), int.Parse(command[2]), default);
            //            carList.Add(car);
            //            break;
            //        case 4:
            //            car = new Car(command[0], engineList.Where(x => x.Model == command[1]).First(), int.Parse(command[2]), command[3]);
            //            carList.Add(car);
            //            break;
            //    }

            //}
            //foreach (var car in carList)
            //{
            //    Console.WriteLine(car.Model + ":");
            //    Console.WriteLine($" {car.Engine.Model}:");
            //    Console.WriteLine($"  Power: {car.Engine.Power}");
            //    if (car.Engine.Displacement == default)
            //        Console.WriteLine($"    Displacement: n/a");
            //    else
            //        Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            //    if (car.Engine.Efficiency == default)
            //        Console.WriteLine($"    Efficiency: n/a");
            //    else
            //        Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            //    if (car.Weight == default)
            //        Console.WriteLine($"  Weight: n/a");
            //    else
            //        Console.WriteLine($"  Weight: {car.Weight}");
            //    if (car.Color == default)
            //        Console.WriteLine("  Color: n/a");
            //    else
            //        Console.WriteLine($"  Color: {car.Color}");
            //}
            //9
            List<Trainer> trainers = new List<Trainer>();
            int count = 0;
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Tournament")
                    break;
                Trainer trainer = new Trainer(command[0], command[1], command[2], int.Parse(command[3]));
                foreach (Trainer person in trainers)
                {
                    if (person.Name == trainer.Name)
                    {
                        int index = trainers.IndexOf(person);
                        trainers[index].pokemons.Add(new Pokemon(command[1], command[2], int.Parse(command[3])));
                        count++;
                    }

                }
                if (count == 0)
                {
                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                    break;
                else if (command == "Fire" || command == "Water" || command == "Electricity")
                {
                    foreach (Trainer trainer in trainers)
                    {
                        if (trainer.CheckPokemonElement(command, trainer))
                        {
                            trainer.pokemons = trainer.PokimonsReducingHealt(trainer);
                        }
                    }
                }
            }
            List<Trainer> sortedList = trainers.OrderByDescending(x => x.Badges).ToList();
            foreach (Trainer trainer in sortedList)
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.pokemons.Count}");
        }
    }
}
