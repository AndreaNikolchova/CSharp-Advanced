namespace WildFarm.Core
{
    using Models;
    using IO;
    using System.Collections.Generic;
    using Factories;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<Animal> animals;
        private readonly Factory factory;
        private Engine()
        {
            factory = new Factory();
            animals = new List<Animal>();
        }
        public Engine(IWriter writer, IReader reader):this()
        {
            this.writer = writer;
            this.reader = reader;
        }
        public void Start()
        {
            while (true)
            {
                string[] animal =  reader.ReadLine().Split(' ',System.StringSplitOptions.RemoveEmptyEntries);
                if (animal[0] == "End")
                    break;
                string[] food = reader.ReadLine().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

                Animal currentAnimal = factory.CreateAnimal(animal);
                Food currentFood = factory.CreateFood(food);

                animals.Add(currentAnimal);
                writer.WriteLine(currentAnimal.ProduceSound());

                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (ExeptionTypeOfFood ex)
                {
                    writer.WriteLine(ex.Message);
                }

            }
            foreach (var animal in animals)
                writer.WriteLine(animal.ToString());
           
        }
    }
}
