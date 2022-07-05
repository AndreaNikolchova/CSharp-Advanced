using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!")
                    break;
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (type)
                {
                    case "Dog":
                        Dog dog = new Dog(line[0], int.Parse(line[1]), line[2]);
                        list.Add(dog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(line[0], int.Parse(line[1]), line[2]);
                        list.Add(cat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(line[0], int.Parse(line[1]), line[2]);
                        list.Add(frog);
                        break;
                    case "Kittens":
                        Kitten kitten = new Kitten(line[0], int.Parse(line[1]));
                        list.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(line[0], int.Parse(line[1]));
                        list.Add(tomcat);
                        break;

                }

            }
            foreach(var animal in list)
                Console.WriteLine(animal);
             
        }
    }
}
